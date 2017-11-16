Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient

Public Class SyncLogDataENG
    Private Shared _KioskID As Long = 0

    Public Shared Sub SyncAllLog(MsKioskID As Long)
        SyncLogTransactionActivity(MsKioskID)
        SyncFillMoneyData(MsKioskID)
        SyncLogErrorData(MsKioskID)
        SyncLogKioskAgentData(MsKioskID)
    End Sub



#Region "Sync Log"
    Private Shared logDt As New DataTable
    Public Shared Sub SyncLogTransactionActivity(MsKioskID As Long)
        Try
            _KioskID = MsKioskID
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)
            Dim lnq As New TbLogTransactionActivityKioskLinqDB
            logDt = lnq.GetDataList("ms_kiosk_id=@_KIOSK_ID", "trans_date", Nothing, p)
            If logDt.Rows.Count > 0 Then
                logDt.TableName = "SyncLogTransactionActivity"

                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 100000
                ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
                AddHandler ws.SyncLogTransactionActivityCompleted, AddressOf SyncLogTransactionActivityCompleted

                ws.SyncLogTransactionActivityAsync(logDt, Environment.MachineName)
                ws.Dispose()
            End If
            lnq = Nothing
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub SyncLogTransactionActivityCompleted(sender As Object, e As SyncDataWebservice.SyncLogTransactionActivityCompletedEventArgs)
        If e.Result.ToString = "true" Then
            Dim kTrans As New KioskTransactionDB
            Dim re As Boolean = False
            For Each dr As DataRow In logDt.Rows
                Dim kLnq As New TbLogTransactionActivityKioskLinqDB
                If kLnq.DeleteByPK(dr("ID"), kTrans.Trans).IsSuccess = True Then
                    'ถ้าทำการ Sync แล้วให้ลบข้อมูลที่ Kiosk ทิ้งเลย
                    re = True
                Else
                    re = False
                    LogFileENG.CreateErrorLogAgent(_KioskID, kLnq.ErrorMessage)
                    Exit For
                End If
                kLnq = Nothing
            Next

            If re = True Then
                kTrans.CommitTransaction()
            Else
                kTrans.RollbackTransaction()
            End If

            logDt.Dispose()
        End If
    End Sub


#End Region

    Private Shared Sub SyncFillMoneyData(MsKioskID As Long)
        Try
            'Dim sql As String = " select id "
            'sql += " from TB_FILL_MONEY"
            'sql += " where ms_kiosk_id=@_KIOSK_ID "
            'sql += " and sync_to_server='N'"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)
            Dim lnq As New TbFillMoneyKioskLinqDB
            Dim dt As DataTable = lnq.GetDataList("ms_kiosk_id=@_KIOSK_ID  and sync_to_server='N'", "id", Nothing, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncFillMoneyData"

                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 10000
                ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncLogFillMoneyData(dt, Environment.MachineName)
                If ret.ToLower.Trim = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim re As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                    For Each dr As DataRow In dt.Rows
                        Dim kLnq As New TbFillMoneyKioskLinqDB
                        kLnq.GetDataByPK(dr("id"), Nothing)
                        If kLnq.ID > 0 Then
                            If kLnq.IS_CONFIRM = "Z" Then
                                'ถ้ากำลังอยู่ระหว่างการทำงานการใน Fill Money ให้ทำการ Update Sync_To_Server
                                kLnq.SYNC_TO_SERVER = "Y"
                                re = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                                If re.IsSuccess = False Then
                                    LogFileENG.CreateErrorLogAgent(MsKioskID, kLnq.ErrorMessage)
                                    Exit For
                                End If
                            Else
                                'ถ้าในหน้าจอเป็นการคลิกปุ่ม Confirm หรือ Cancel แล้ว ให้ Delete ข้อมูลนี้จาก Kiosk เลย
                                re = kLnq.DeleteByPK(kLnq.ID, kTrans.Trans)
                                If re.IsSuccess = False Then
                                    LogFileENG.CreateErrorLogAgent(MsKioskID, kLnq.ErrorMessage)
                                    Exit For
                                End If
                            End If

                        End If
                        kLnq = Nothing
                    Next

                    If re.IsSuccess = True Then
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

    Private Shared Sub SyncLogErrorData(MsKioskID As Long)
        Try
            'Dim sql As String = " select id "
            'sql += " from tb_log_error "
            'sql += " where ms_kiosk_id=@_KIOSK_ID"
            'sql += " and sync_to_server='N'"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)
            Dim lnq As New TbLogErrorKioskLinqDB

            Dim dt As DataTable = lnq.GetDataList("ms_kiosk_id=@_KIOSK_ID", "id", Nothing, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncLogErrorData"

                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 10000
                ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncLogErrorData(dt, Environment.MachineName)
                If ret = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim re As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                    For Each dr As DataRow In dt.Rows

                        Dim kLnq As New TbLogErrorKioskLinqDB
                        re = kLnq.DeleteByPK(dr("ID"), kTrans.Trans)
                        If re.IsSuccess = False Then
                            'kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, kLnq.ErrorMessage)
                            Exit For
                        End If
                    Next
                    If re.IsSuccess = True Then
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

    Private Shared Sub SyncLogKioskAgentData(MsKioskID As Long)
        Try
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)
            Dim lnq As New TbLogKioskAgentKioskLinqDB
            Dim dt As DataTable = lnq.GetDataList("ms_kiosk_id=@_KIOSK_ID", "id", Nothing, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncLogKioskAgentData"

                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 100000
                ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncLogKioskAgentData(dt, Environment.MachineName)
                If ret = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim re As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                    For Each dr As DataRow In dt.Rows
                        'ถ้า Insert Log ที่ Server สำเร็จให้ทำการ Delete ที่ Kiosk เลย
                        Dim kLnq As New TbLogKioskAgentKioskLinqDB
                        re = kLnq.DeleteByPK(dr("ID"), kTrans.Trans)
                        If re.IsSuccess = False Then
                            LogFileENG.CreateErrorLogAgent(MsKioskID, kLnq.ErrorMessage)
                            Exit For
                        End If
                    Next
                    If re.IsSuccess = True Then
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

    Private Shared Function GetDataTableFromDataReader(ByVal dataReader As IDataReader) As DataTable
        Dim schemaTable As DataTable = dataReader.GetSchemaTable()
        Dim resultTable As DataTable = New DataTable()

        Dim dataRow As DataRow
        For Each dataRow In schemaTable.Rows
            Dim dataColumn As DataColumn = New DataColumn()
            dataColumn.ColumnName = dataRow("ColumnName").ToString()
            dataColumn.DataType = Type.GetType(dataRow("DataType").ToString())
            dataColumn.ReadOnly = CType(dataRow("IsReadOnly"), Boolean)
            dataColumn.AutoIncrement = CType(dataRow("IsAutoIncrement"), Boolean)
            dataColumn.Unique = CType(dataRow("IsUnique"), Boolean)

            resultTable.Columns.Add(dataColumn)
        Next

        While dataReader.Read()
            dataRow = resultTable.NewRow()
            Dim i As Integer
            For i = 0 To resultTable.Columns.Count - 1 - 1 Step i + 1
                dataRow(i) = dataReader(i)
            Next
            resultTable.Rows.Add(dataRow)
        End While

        Return resultTable
    End Function


    Private Shared Function GetAlarmMasterList() As DataTable
        Dim dt As DataTable
        Try
            Dim sql As String = "select alarm_problem, alarm_code,eng_desc, sms_message"
            sql += " from MS_MASTER_MONITORING_ALARM "
            dt = KioskDB.ExecuteTable(sql)
            dt.TableName = "AlarmMasterList"
        Catch ex As Exception
            dt = New DataTable
        End Try

        Return dt
    End Function
    Public Shared Sub SendAlarmData(MsKioskID As Long)
        Try
            Dim lnq As New MsKioskAlarmKioskLinqDB
            Dim dt As DataTable = lnq.GetDataList("is_send_alarm='N'", "", Nothing, Nothing)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SendAlarmData"

                Dim cf As CfKioskSysconfigKioskLinqDB = KioskInfoENG.GetLockerSysconfig(MsKioskID)

                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 100000
                ws.Url = cf.LOCKER_WEBSERVICE_URL
                'ws.Url = "http://localhost:47823/ATBLockerWebService.asmx?WSDL"

                'Dim alDt As DataTable = GetAlarmMasterList()
                Dim ret As String = ws.SendKiskAlarm(cf.MAC_ADDRESS, cf.LOCATION_NAME, dt)

                If ret.Trim = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                    For Each dr As DataRow In dt.Rows
                        Dim sql As String = " update MS_KIOSK_ALARM "
                        sql += " set is_send_alarm='Y', last_send_time=getdate(), updated_by=@_UPDATED_BY, updated_date=getdate()"
                        sql += " where id=@_ID"

                        Dim p(2) As SqlParameter
                        p(0) = KioskDB.SetBigInt("@_ID", dr("id"))
                        p(1) = KioskDB.SetText("@_UPDATED_BY", Environment.NewLine)

                        kRet = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
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
                cf = Nothing
                ws.Dispose()
            End If
            dt.Dispose()
            lnq = Nothing
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub
End Class
