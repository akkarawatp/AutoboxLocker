Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE

Public Class SyncTransactionDataENG

    Private Shared _KioskID As Long = 0

    Public Shared Sub SyncAllTransaction(MsKioskID As Long)
        _KioskID = MsKioskID
        SyncDepositTransaction(MsKioskID)
        SyncCollectTransaction(MsKioskID)

        SyncDepositTransactionCustImage(MsKioskID)
        SyncCollectTransactionCustImage(MsKioskID)

        SyncStaffConsoleTransaction(MsKioskID)
        SyncDeleteCompleteTransaction(MsKioskID)
    End Sub


#Region "Sync Deposit Transaction Data"
    Public Shared Sub ConvertDepositTransationCustImage(MsKioskID As Long)
        _KioskID = MsKioskID
        Try
            Dim sql As String = "select id, trans_no, cust_image "
            sql += " from tb_deposit_transaction "
            sql += " where cust_image is not null "
            sql += " and ms_kiosk_id=@_KIOSK_ID"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "ConvertServiceTransationCustImage"

                Dim CustImagePath As String = Application.StartupPath & "\TempCustImage\Deposit\"
                If Directory.Exists(CustImagePath) = False Then
                    Directory.CreateDirectory(CustImagePath)
                End If

                Dim cf As CfKioskSysconfigKioskLinqDB = KioskInfoENG.GetLockerSysconfig(MsKioskID)
                Dim kTrans As New KioskTransactionDB
                Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                For Each dr As DataRow In dt.Rows
                    Try
                        Dim ret As String = "false"
                        Dim TransNo As String = dr("trans_no")
                        Dim CustImage As Byte() = CType(dr("cust_image"), Byte())
                        Dim FileName As String = CustImagePath & TransNo & ".png"
                        File.WriteAllBytes(FileName, CustImage)

                        If File.Exists(FileName) = True Then
                            Dim tLnq As New TbDepositTransactionKioskLinqDB
                            tLnq.GetDataByPK(dr("id"), kTrans.Trans)
                            If tLnq.ID > 0 Then
                                tLnq.CUST_IMAGE = Nothing
                                kRet = tLnq.UpdateData(cf.LOCATION_NAME, kTrans.Trans)
                                If kRet.IsSuccess = False Then
                                    Exit For
                                End If
                            End If
                            tLnq = Nothing
                        End If
                    Catch ex As Exception
                        LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
                    End Try
                Next

                If kRet.IsSuccess = True Then
                    kTrans.CommitTransaction()
                Else
                    kTrans.RollbackTransaction()
                    LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SyncDepositTransaction(MsKioskID As Long)
        _KioskID = MsKioskID

        Try
            Dim sql As String = " select  s.ID,  l.ms_locker_id "
            sql += " from tb_deposit_transaction s "
            sql += " left join ms_locker l on l.id=s.ms_locker_id"
            sql += " where s.ms_kiosk_id=@_KIOSK_ID "
            sql += " And s.sync_to_server='N'"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncServiceTransaction"
                Dim cf As CfKioskSysconfigKioskLinqDB = KioskInfoENG.GetLockerSysconfig(MsKioskID)
                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 200000
                ws.Url = cf.LOCKER_WEBSERVICE_URL

                For Each dr As DataRow In dt.Rows
                    Dim ret As String = "false"
                    Dim kTrans As New KioskTransactionDB
                    Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                    Dim kLnq As New TbDepositTransactionKioskLinqDB
                    kLnq.GetDataByPK(dr("id"), kTrans.Trans)
                    If kLnq.ID > 0 Then
                        Dim ServiceLockerID As Long = 0
                        Dim vGender As String = ""
                        If Convert.IsDBNull(dr("ms_locker_id")) = False Then ServiceLockerID = dr("ms_locker_id")
                        If kLnq.GENDER <> vbNullChar Then vGender = kLnq.GENDER.ToString

                        Try
                            ret = ws.SyncKioskDepositTransactionByRecord(cf.LOCATION_NAME, kLnq.TRANS_NO, kLnq.TRANS_START_TIME, kLnq.TRANS_END_TIME.Value, kLnq.MS_KIOSK_ID, ServiceLockerID, kLnq.PIN_CODE, kLnq.SERVICE_RATE, kLnq.SERVICE_RATE_LIMIT_DAY, kLnq.DEPOSIT_AMT, kLnq.PAID_TIME, kLnq.RECEIVE_COIN1, kLnq.RECEIVE_COIN2, kLnq.RECEIVE_COIN5, kLnq.RECEIVE_COIN10, kLnq.RECEIVE_BANKNOTE20, kLnq.RECEIVE_BANKNOTE50, kLnq.RECEIVE_BANKNOTE100, kLnq.RECEIVE_BANKNOTE500, kLnq.RECEIVE_BANKNOTE1000, kLnq.CHANGE_COIN1, kLnq.CHANGE_COIN2, kLnq.CHANGE_COIN5, kLnq.CHANGE_COIN10, kLnq.CHANGE_BANKNOTE20, kLnq.CHANGE_BANKNOTE50, kLnq.CHANGE_BANKNOTE100, kLnq.CHANGE_BANKNOTE500, kLnq.TRANS_STATUS, kLnq.MS_APP_SCREEN_ID, kLnq.MS_APP_STEP_ID)
                            If ret = "true" Then
                                kLnq.SYNC_TO_SERVER = "Y"
                                kRet = kLnq.UpdateData(cf.LOCATION_NAME, kTrans.Trans)
                            Else
                                kRet.IsSuccess = False
                                kRet.ErrorMessage = ret
                            End If
                        Catch ex As Exception
                            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
                            kRet.IsSuccess = False
                            kRet.ErrorMessage = ex.Message
                        End Try
                    End If
                    If kRet.IsSuccess = True Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                    End If

                    kLnq = Nothing
                Next
                ws.Dispose()
            End If
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SyncDepositTransactionCustImage(MsKioskID As Long)
        _KioskID = MsKioskID
        Try
            Dim CustImagePath As String = Application.StartupPath & "\TempCustImage\Deposit\"
            If Directory.Exists(CustImagePath) = True Then
                Dim cf As CfKioskSysconfigKioskLinqDB = KioskInfoENG.GetLockerSysconfig(MsKioskID)
                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 200000
                ws.Url = cf.LOCKER_WEBSERVICE_URL

                For Each f As String In Directory.GetFiles(CustImagePath, "*.png")
                    Dim fInfo As New FileInfo(f)
                    Dim TransNo As String = fInfo.Name.Replace(".png", "")
                    Dim CustImage As Byte() = File.ReadAllBytes(f)

                    Try
                        Dim ret As String = ws.SyncKioskDepositTransactionCustomerImage(cf.LOCATION_NAME, TransNo, CustImage)
                        If ret = "true" Then
                            File.SetAttributes(f, FileAttributes.Normal)
                            File.Delete(f)
                        Else
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret)
                        End If

                        fInfo = Nothing
                    Catch ex As Exception
                        LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message & vbNewLine & " TransNo:" & TransNo, ex.StackTrace)
                    End Try
                Next
                ws.Dispose()
            End If

        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

#End Region

#Region "Sync Collect Transaction Data"
    Public Shared Sub ConvertCollectTransationCustImage(MsKioskID As Long)
        _KioskID = MsKioskID
        Try
            Dim sql As String = "select id, transaction_no, cust_image "
            sql += " from TB_PICKUP_TRANSACTION "
            sql += " where cust_image is not null and sync_to_server='Y' "
            sql += " and ms_kiosk_id=@_KIOSK_ID"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "ConvertCollectTransationCustImage"

                Dim CustImagePath As String = Application.StartupPath & "\TempCustImage\Collect\"
                If Directory.Exists(CustImagePath) = False Then
                    Directory.CreateDirectory(CustImagePath)
                End If

                Dim cf As CfKioskSysconfigKioskLinqDB = KioskInfoENG.GetLockerSysconfig(MsKioskID)
                Dim kTrans As New KioskTransactionDB
                Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                For Each dr As DataRow In dt.Rows
                    Try
                        Dim ret As String = "false"
                        Dim TransNo As String = dr("transaction_no")
                        Dim CustImage As Byte() = CType(dr("cust_image"), Byte())
                        Dim FileName As String = CustImagePath & TransNo & ".png"
                        File.WriteAllBytes(FileName, CustImage)

                        If File.Exists(FileName) = True Then
                            Dim tLnq As New TbPickupTransactionKioskLinqDB
                            tLnq.GetDataByPK(dr("id"), kTrans.Trans)
                            If tLnq.ID > 0 Then
                                tLnq.CUST_IMAGE = Nothing
                                kRet = tLnq.UpdateData(cf.LOCATION_NAME, kTrans.Trans)
                                If kRet.IsSuccess = False Then
                                    Exit For
                                End If
                            End If
                            tLnq = Nothing
                        End If
                    Catch ex As Exception
                        LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
                    End Try
                Next

                If kRet.IsSuccess = True Then
                    kTrans.CommitTransaction()
                Else
                    kTrans.RollbackTransaction()
                    LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SyncCollectTransaction(MsKioskID As Long)
        Try
            Dim sql As String = "SELECT p.ID, p.TRANSACTION_NO, p.TRANS_START_TIME, p.TRANS_END_TIME, p.MS_KIOSK_ID, p.MS_LOCKER_ID, p.DEPOSIT_TRANS_NO, "
            sql += " p.LOST_QR_CODE, p.SERVICE_AMT, p.PICKUP_TIME, p.PAID_TIME, p.RECEIVE_COIN1, p.RECEIVE_COIN2, p.RECEIVE_COIN5, p.RECEIVE_COIN10, "
            sql += " p.RECEIVE_BANKNOTE20, p.RECEIVE_BANKNOTE50, p.RECEIVE_BANKNOTE100, p.RECEIVE_BANKNOTE500, p.RECEIVE_BANKNOTE1000, "
            sql += " p.CHANGE_COIN1, p.CHANGE_COIN2, p.CHANGE_COIN5, p.CHANGE_COIN10, p.CHANGE_BANKNOTE20, p.CHANGE_BANKNOTE50, p.CHANGE_BANKNOTE100, "
            sql += " p.CHANGE_BANKNOTE500, p.TRANS_STATUS, p.MS_APP_SCREEN_ID, p.MS_APP_STEP_ID, l.locker_name "
            sql += " from TB_PICKUP_TRANSACTION p "
            sql += " left join MS_LOCKER l on l.id=p.ms_locker_id"
            sql += " where p.ms_kiosk_id=@_KIOSK_ID"
            sql += " And p.sync_to_server = 'N'"
            sql += " and p.trans_status<>'0'"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                Dim kTrans As New KioskTransactionDB
                Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                Dim cf As CfKioskSysconfigKioskLinqDB = KioskInfoENG.GetLockerSysconfig(MsKioskID)
                dt.TableName = "SyncPickupTransaction"
                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 10000
                ws.Url = cf.LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncKioskCollectTransaction(dt, cf.LOCATION_NAME)
                If ret = "true" Then
                    For Each dr As DataRow In dt.Rows
                        If Convert.IsDBNull(dr("deposit_trans_no")) = True Then
                            Dim kLnq As New TbPickupTransactionKioskLinqDB
                            kRet = kLnq.DeleteByPK(dr("ID"), kTrans.Trans)
                            kLnq = Nothing
                        Else
                            sql = "update TB_PICKUP_TRANSACTION "
                            sql += " set sync_to_server='Y'"
                            sql += " where id=@_ID"
                            ReDim p(1)
                            p(0) = KioskDB.SetBigInt("@_ID", dr("id"))

                            kRet = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                        End If

                        If kRet.IsSuccess = False Then
                            Exit For
                        End If
                    Next

                    If kRet.IsSuccess = True Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                    End If
                End If
                ws.Dispose()

            End If
            dt.Dispose()

        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub SyncCollectTransactionCustImage(MsKioskID As Long)
        _KioskID = MsKioskID
        Try
            Dim CustImagePath As String = Application.StartupPath & "\TempCustImage\Collect\"
            If Directory.Exists(CustImagePath) = True Then
                Dim cf As CfKioskSysconfigKioskLinqDB = KioskInfoENG.GetLockerSysconfig(MsKioskID)
                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 200000
                ws.Url = cf.LOCKER_WEBSERVICE_URL

                For Each f As String In Directory.GetFiles(CustImagePath, "*.png")
                    Dim fInfo As New FileInfo(f)
                    Dim TransNo As String = fInfo.Name.Replace(".png", "")
                    Dim CustImage As Byte() = File.ReadAllBytes(f)

                    Try
                        Dim ret As String = ws.SyncKioskCollectTransactionCustomerImage(cf.LOCATION_NAME, TransNo, CustImage)
                        If ret = "true" Then
                            File.SetAttributes(f, FileAttributes.Normal)
                            File.Delete(f)
                        Else
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret)
                        End If

                        fInfo = Nothing
                    Catch ex As Exception
                        LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message & vbNewLine & " TransNo:" & TransNo, ex.StackTrace)
                    End Try
                Next
                ws.Dispose()
            End If

        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub
#End Region



    Private Shared Sub SyncStaffConsoleTransaction(MsKioskID As Long)
        Try

            Dim kLnq As New TbStaffConsoleTransactionKioskLinqDB
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim dt As DataTable = kLnq.GetDataList("sync_to_server='N' and ms_kiosk_id = @_KIOSK_ID", "", Nothing, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncStaffConsoleTransaction"
                Dim cf As CfKioskSysconfigKioskLinqDB = KioskInfoENG.GetLockerSysconfig(MsKioskID)

                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 10000
                ws.Url = cf.LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncKioskStaffConsoleTransaction(dt, cf.LOCATION_NAME)
                If ret = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                    For Each dr As DataRow In dt.Rows
                        kLnq = New TbStaffConsoleTransactionKioskLinqDB
                        kRet = kLnq.DeleteByPK(dr("id"), kTrans.Trans)
                        If kRet.IsSuccess = False Then
                            LogFileENG.CreateErrorLogAgent(MsKioskID, kLnq.ErrorMessage)
                            Exit For
                        End If
                    Next
                    If kRet.IsSuccess = True Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                    End If
                End If
                ws.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SyncDeleteCompleteTransaction(MsKioskID As Long)

        '#################################
        'กรณีระบุว่า Transaction นั้นสำเร็จ คือ Success, Cancel, Problem, Timeout, Cancel by Admin
        '#################################
        Try
            Dim sql As String = "select id "
            sql += " from TB_DEPOSIT_TRANSACTION "
            sql += " where ms_kiosk_id=@_KIOSK_ID"
            sql += " and trans_status  in ('1','2','3','4','5')"
            'sql += " and trans_status  in ('5')"
            'sql += " and id=23602"
            sql += " and sync_to_server='Y' and cust_image is null"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim sDt As DataTable = KioskDB.ExecuteTable(sql, p)
            If sDt.Rows.Count > 0 Then
                For Each sDr As DataRow In sDt.Rows
                    Dim ServiceLnq As New TbDepositTransactionKioskLinqDB
                    ServiceLnq.GetDataByPK(sDr("id"), Nothing)
                    If ServiceLnq.ID > 0 Then

                        Dim pDt As DataTable = GetPickupTransaction(MsKioskID, ServiceLnq.TRANS_NO)  'ข้อมูล Pickup Transaction

                        Dim lDt As DataTable = GetLogTransaction(MsKioskID, ServiceLnq.TRANS_NO)  'ข้อมูล Log Transaction Activity

                        If pDt.Rows.Count > 0 Then
                            Dim IsDeleteTrans As Boolean = False

                            For i As Integer = pDt.Rows.Count - 1 To 0 Step -1
                                Dim pDr As DataRow = pDt.Rows(i)
                                Dim PickupLnq As New TbPickupTransactionKioskLinqDB
                                PickupLnq.GetDataByPK(pDr("id"), Nothing)
                                If PickupLnq.ID > 0 Then
                                    If ServiceLnq.TRANS_STATUS = CInt(TransactionStatus.Success).ToString Then   'ถ้าเป็น Transaction ที่ Success แล้ว
                                        Select Case PickupLnq.TRANS_STATUS
                                            Case CInt(TransactionStatus.Success).ToString
                                                IsDeleteTrans = True  'ทำการ Delete Transaction ได้
                                                Exit For

                                            Case CInt(TransactionStatus.Cancel).ToString, CInt(TransactionStatus.Problem).ToString, CInt(TransactionStatus.TimeOut).ToString
                                                'ถ้าเป็น Transaction ที่ Sync แล้ว
                                                If PickupLnq.SYNC_TO_SERVER = "Y" And PickupLnq.CUST_IMAGE Is Nothing Then
                                                    'Delete Pickup Transaction ได้เลย

                                                    Dim trans As New KioskTransactionDB
                                                    If PickupLnq.DeleteByPK(PickupLnq.ID, trans.Trans).IsSuccess = True Then
                                                        pDt.Rows.RemoveAt(i)  'เคสนี้อาจจะไม่เจอเลย
                                                        trans.CommitTransaction()
                                                    Else
                                                        trans.RollbackTransaction()
                                                        LogFileENG.CreateErrorLogAgent(MsKioskID, PickupLnq.ErrorMessage)
                                                    End If
                                                End If
                                        End Select
                                    ElseIf ServiceLnq.TRANS_STATUS = CInt(TransactionStatus.CancelByAdmin).ToString Then
                                        Select Case PickupLnq.TRANS_STATUS
                                            Case CInt(TransactionStatus.CancelByAdmin).ToString
                                                IsDeleteTrans = True  'ทำการ Delete Transaction ได้
                                                Exit For

                                            Case CInt(TransactionStatus.Cancel).ToString, CInt(TransactionStatus.Problem).ToString, CInt(TransactionStatus.TimeOut).ToString
                                                'ถ้าเป็น Transaction ที่ Sync แล้ว
                                                If PickupLnq.SYNC_TO_SERVER = "Y" And PickupLnq.CUST_IMAGE Is Nothing Then
                                                    'Delete Pickup Transaction ได้เลย

                                                    Dim trans As New KioskTransactionDB
                                                    If PickupLnq.DeleteByPK(PickupLnq.ID, trans.Trans).IsSuccess = True Then
                                                        pDt.Rows.RemoveAt(i)  'เคสนี้อาจจะไม่เจอเลย
                                                        trans.CommitTransaction()
                                                    Else
                                                        trans.RollbackTransaction()
                                                        LogFileENG.CreateErrorLogAgent(MsKioskID, PickupLnq.ErrorMessage)
                                                    End If
                                                End If
                                        End Select
                                    ElseIf ServiceLnq.TRANS_STATUS = CInt(TransactionStatus.Cancel).ToString Then
                                        Select Case PickupLnq.TRANS_STATUS
                                            Case CInt(TransactionStatus.Cancel).ToString, CInt(TransactionStatus.Problem).ToString, CInt(TransactionStatus.TimeOut).ToString
                                                'ถ้าเป็น Transaction ที่ Sync แล้ว
                                                If PickupLnq.SYNC_TO_SERVER = "Y" And PickupLnq.CUST_IMAGE Is Nothing Then
                                                    'Delete Pickup Transaction ได้เลย

                                                    Dim trans As New KioskTransactionDB
                                                    If PickupLnq.DeleteByPK(PickupLnq.ID, trans.Trans).IsSuccess = True Then
                                                        pDt.Rows.RemoveAt(i)  'เคสนี้อาจจะไม่เจอเลย
                                                        trans.CommitTransaction()

                                                        IsDeleteTrans = True  'ทำการ Delete Transaction ได้
                                                        Exit For
                                                    Else
                                                        trans.RollbackTransaction()
                                                        LogFileENG.CreateErrorLogAgent(MsKioskID, PickupLnq.ErrorMessage)
                                                    End If
                                                End If
                                        End Select
                                    Else
                                        'กรณีนี้ไม่น่าจะมี คือ Service No Success แต่มี Pickup Transaction
                                        'เขียน Log เก็บไว้ก่อน
                                        LogFileENG.CreateLogAgent(MsKioskID, ServiceLnq.TRANS_NO + " ยังไม่ Success แต่มีข้อมูลใน Pickup")
                                    End If
                                End If

                                PickupLnq = Nothing
                            Next

                            If IsDeleteTrans = True Then
                                If lDt.Rows.Count = 0 Then  'ถ้าไม่มี Log Transaction Activity ค้าอยู่ก็ให้ลบได้
                                    Dim ret As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                                    Dim trans As New KioskTransactionDB

                                    For Each pDr As DataRow In pDt.Rows
                                        If pDr("sync_to_server") = "Y" And Convert.IsDBNull(pDr("cust_image")) = True Then  'ถาเป็นรายการที่ถูก Sync แล้วถึงจะลบได้
                                            Dim pLnq As New TbPickupTransactionKioskLinqDB
                                            ret = pLnq.DeleteByPK(pDr("id"), trans.Trans)
                                            If ret.IsSuccess = False Then
                                                LogFileENG.CreateErrorLogAgent(MsKioskID, pLnq.ErrorMessage)
                                                Exit For
                                            End If
                                            pLnq = Nothing
                                        End If
                                    Next

                                    If ret.IsSuccess = True Then
                                        If ServiceLnq.DeleteByPK(ServiceLnq.ID, trans.Trans).IsSuccess = True Then
                                            trans.CommitTransaction()
                                        Else
                                            trans.RollbackTransaction()
                                            LogFileENG.CreateErrorLogAgent(MsKioskID, ServiceLnq.ErrorMessage)
                                        End If
                                    Else
                                        trans.RollbackTransaction()
                                        'LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                    End If
                                End If
                            End If
                        Else
                            'ถ้าไม่มี Table ลูกเลย
                            Select Case ServiceLnq.TRANS_STATUS
                                Case CInt(TransactionStatus.Cancel).ToString, CInt(TransactionStatus.Problem).ToString, CInt(TransactionStatus.TimeOut).ToString, CInt(TransactionStatus.CancelByAdmin).ToString
                                    If lDt.Rows.Count = 0 Then  'Log Transaction Activety ได้ถูก Sync ไปหมดแล้ว
                                        Dim trans As New KioskTransactionDB
                                        If ServiceLnq.DeleteByPK(ServiceLnq.ID, trans.Trans).IsSuccess = True Then
                                            trans.CommitTransaction()
                                        Else
                                            trans.RollbackTransaction()
                                            LogFileENG.CreateErrorLogAgent(MsKioskID, ServiceLnq.ErrorMessage)
                                        End If
                                    End If
                                Case TransactionStatus.Success.ToString
                                    'ถ้า Service Transaction ยัง Success อยู่แสดงว่าลูกค้าฝากของและยังไม่มาเอา  เราก็ยังไม่ต้องทำอะไร กับ Transaction นี้

                            End Select
                        End If
                        pDt.Dispose()
                    End If
                    ServiceLnq = Nothing
                Next
            End If
            sDt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try


        '#################################
        'กรณีระบุว่า Transaction นั้นไม่สำเร็จ คือ Inprogress ถ้าเกินกว่า 2 วันก็ให้ Delete โลด
        '#################################
        Try
            Dim sql As String = "select id "
            sql += " from TB_DEPOSIT_TRANSACTION "
            sql += " where ms_kiosk_id=@_KIOSK_ID"
            sql += " and trans_status  in ('0')"
            sql += " and sync_to_server='Y'"
            sql += " and DATEADD(d,2,created_date) < getdate()"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim sDt As DataTable = KioskDB.ExecuteTable(sql, p)
            If sDt.Rows.Count > 0 Then
                For Each dr As DataRow In sDt.Rows
                    Dim lnq As New TbDepositTransactionKioskLinqDB
                    Dim trans As New KioskTransactionDB
                    If lnq.DeleteByPK(dr("id"), trans.Trans).IsSuccess = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, lnq.ErrorMessage)
                    End If
                    lnq = Nothing
                Next
            End If
            sDt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Shared Function GetLogTransaction(MsKioskID As Long, DepositTransNo As Long) As DataTable
        Dim dt As New DataTable
        Try
            Dim lSql As String = "select id"
            lSql += " from TB_LOG_TRANSACTION_ACTIVITY "
            lSql += " where deposit_trans_no=@_DEPOSIT_TRANS_NO"
            lSql += " and sync_to_server='N'"
            Dim lp(1) As SqlParameter
            lp(0) = KioskDB.SetBigInt("@_DEPOSIT_TRANS_NO", DepositTransNo)

            dt = KioskDB.ExecuteTable(lSql, lp)
        Catch ex As Exception
            dt = New DataTable
        End Try

        Return dt
    End Function

    Private Shared Function GetPickupTransaction(MsKioskID As Long, DepositTransNo As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim pSql As String = "select id, trans_status, cust_image, sync_to_server"
            pSql += " from TB_PICKUP_TRANSACTION "
            pSql += " where deposit_trans_no=@_DEPOSIT_TRANS_NO"

            Dim pp(1) As SqlParameter
            pp(0) = KioskDB.SetBigInt("@_DEPOSIT_TRANS_NO", DepositTransNo)
            dt = KioskDB.ExecuteTable(pSql, pp)  'ข้อมูล Pickup Transaction
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Public Enum TransactionStatus
        Inprogress = 0
        Success = 1
        Cancel = 2
        Problem = 3
        TimeOut = 4
        CancelByAdmin = 5
    End Enum
End Class
