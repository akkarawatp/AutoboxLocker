'Imports System.DirectoryServices.AccountManagement
Imports AutoboxLocker.Data.KioskConfigData
'Imports AutoboxLocker.ServiceTransactionData
Imports KioskLinqDB.TABLE
Imports KioskLinqDB.ConnectDB

Public Class frmSC_LockerSetting
    Private Sub frmSC_LogIn_Load(sender As Object, e As EventArgs) Handles Me.Load
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleKioskSetting
        Me.ControlBox = False

    End Sub

    Private Sub frmSC_DialogSetting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Me.WindowState = FormWindowState.Maximized
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLockerSetting_OpenForm, "", False)

        lblHeader.Text = "Kiosk Layout"
        LoadAllCabinetData()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLockerSetting_CheckAuthorize, "", False)
        SetStaffConsoleAuthorize()
    End Sub

    Private Sub LoadAllCabinetData()
        SetLockerList()
        SetCabinetInformation()

        'If CabinetList.Rows.Count > 0 Then
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLockerSetting_LoadCabinetInfo, "", False)

        UcCabinet1.LoadCabinetData(True, CabinetList)
        UcCabinet2.LoadCabinetData(True, CabinetList)
        UcCabinet3.LoadCabinetData(True, CabinetList)
        UcCabinet4.LoadCabinetData(True, CabinetList)
        UcCabinet5.LoadCabinetData(True, CabinetList)
        UcCabinet6.LoadCabinetData(True, CabinetList)
        UcCabinet7.LoadCabinetData(True, CabinetList)
        UcCabinet8.LoadCabinetData(True, CabinetList)
        UcCabinet9.LoadCabinetData(True, CabinetList)
        UcCabinet10.LoadCabinetData(True, CabinetList)
        txtPCPosition.Text = KioskConfig.LockerPCPosition

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLockerSetting_AdjustLayout, "", False)
        AdjustLockerLayout()
        Application.DoEvents()
        'End If

        If CabinetList.Rows.Count = 10 Then
            'ถ้ามีตู้ครบทั้ง 10 ตู้ให้ซ่อนปุ่ม Add โลด
            pnAdd.Visible = False
            lblAdd.Visible = False
        End If
    End Sub

    Private Sub SetStaffConsoleAuthorize()
        If StaffConsole.AuthorizeInfo.Rows.Count > 0 Then
            AppScreenList.DefaultView.RowFilter = "id='" & Convert.ToInt16(KioskConfig.SelectForm) & "'"
            If AppScreenList.DefaultView.Count > 0 Then
                UcCabinet1.Enabled = False
                UcCabinet2.Enabled = False
                UcCabinet3.Enabled = False
                UcCabinet4.Enabled = False
                UcCabinet5.Enabled = False
                UcCabinet6.Enabled = False
                UcCabinet7.Enabled = False
                UcCabinet8.Enabled = False
                UcCabinet9.Enabled = False
                UcCabinet10.Enabled = False
                txtPCPosition.Enabled = False
                pnSave.Visible = False

                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=20 and authorization_name='Edit'"
                If StaffConsole.AuthorizeInfo.DefaultView.Count > 0 Then
                    UcCabinet1.Enabled = True
                    UcCabinet2.Enabled = True
                    UcCabinet3.Enabled = True
                    UcCabinet4.Enabled = True
                    UcCabinet5.Enabled = True
                    UcCabinet6.Enabled = True
                    UcCabinet7.Enabled = True
                    UcCabinet8.Enabled = True
                    UcCabinet9.Enabled = True
                    UcCabinet10.Enabled = True
                    txtPCPosition.Enabled = True
                    pnSave.Visible = True
                End If
                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""
            End If
            AppScreenList.DefaultView.RowFilter = ""
        End If
    End Sub

    Dim AllPadding As Integer = 1
    Private Sub AdjustLockerLayout()
        'Dim PcWidth As Integer = 75
        Dim cbWith As Integer = 0

        If UcCabinet1.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet1.Width + AllPadding
        End If
        If UcCabinet2.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet2.Width + AllPadding
        End If
        If UcCabinet3.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet3.Width + AllPadding
        End If
        If UcCabinet4.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet4.Width + AllPadding
        End If
        If UcCabinet5.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet5.Width + AllPadding
        End If

        If UcCabinet6.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet6.Width + AllPadding
        End If

        If UcCabinet7.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet7.Width + AllPadding
        End If
        If UcCabinet8.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet8.Width + AllPadding
        End If
        If UcCabinet9.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet9.Width + AllPadding
        End If

        If UcCabinet10.CabinetActiveStatus = "Y" Then
            cbWith += UcCabinet10.Width + AllPadding
        End If

        'วิธีการคำนวณ 
        'ความกว้างทั้งหมดคือ (oQty*61)
        Dim pLeft As Integer = (Panel1.Width / 2) - ((cbWith + pnlPC.Width + AllPadding) / 2)

        If KioskConfig.LockerPCPosition = 1 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet1, pLeft)

        If KioskConfig.LockerPCPosition = 2 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet2, pLeft)

        If KioskConfig.LockerPCPosition = 3 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet3, pLeft)

        If KioskConfig.LockerPCPosition = 4 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet4, pLeft)

        If KioskConfig.LockerPCPosition = 5 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet5, pLeft)

        If KioskConfig.LockerPCPosition = 6 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet6, pLeft)

        If KioskConfig.LockerPCPosition = 7 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet7, pLeft)

        If KioskConfig.LockerPCPosition = 8 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet8, pLeft)

        If KioskConfig.LockerPCPosition = 9 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet9, pLeft)

        If KioskConfig.LockerPCPosition = 10 Then
            pLeft = SetPCPosition(pLeft)
        End If
        pLeft = SetCabinetPosition(UcCabinet10, pLeft)

        If KioskConfig.LockerPCPosition = 11 Then
            pLeft = SetPCPosition(pLeft)
        End If
    End Sub

    Private Function SetCabinetPosition(uc As ucCabinet, pLeft As Integer) As Integer
        If uc.CabinetActiveStatus = "Y" Then
            uc.Left = pLeft
            pLeft = pLeft + uc.Width + AllPadding
            uc.Visible = True
        Else
            uc.Visible = False
        End If
        Application.DoEvents()
        Return pLeft
    End Function
    Private Function SetPCPosition(pLeft As Integer) As Integer
        pnlPC.Left = pLeft
        pLeft = pLeft + pnlPC.Width + AllPadding

        Application.DoEvents()
        Return pLeft
    End Function

    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles lblSave.Click, pnSave.Click
        Try
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLockerSetting_ClickSave, "", False)
            If txtPCPosition.Text.Trim = "" Then
                ShowDialogErrorMessageSC("Please input PC Position")
                txtPCPosition.Focus()
                Exit Sub
            End If

            UcCabinet1.SaveLockerData()
            UcCabinet2.SaveLockerData()
            UcCabinet3.SaveLockerData()
            UcCabinet4.SaveLockerData()
            UcCabinet5.SaveLockerData()
            UcCabinet6.SaveLockerData()
            UcCabinet7.SaveLockerData()
            UcCabinet8.SaveLockerData()
            UcCabinet9.SaveLockerData()
            UcCabinet10.SaveLockerData()

            Dim lnq As New CfKioskSysconfigKioskLinqDB
            lnq.ChkDataByMS_KIOSK_ID(KioskData.KioskID, Nothing)
            If lnq.ID > 0 Then
                lnq.LOCKER_PC_POSITION = txtPCPosition.Text
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                Dim ret As ExecuteDataInfo = lnq.UpdateData(StaffConsole.Username, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()

                    KioskConfig.LockerPCPosition = lnq.LOCKER_PC_POSITION
                    SetCabinetInformation()
                    SetLockerList()
                Else
                    trans.RollbackTransaction()
                    InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLockerSetting_ClickSave, ret.ErrorMessage, True)
                    ShowDialogErrorMessageSC("Save Fail")
                    Exit Sub
                End If
            End If
            lnq = Nothing

            ShowDialogErrorMessageSC("Save Complete")

            AdjustLockerLayout()
            'MessageBox.Show("Save Complete", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLockerSetting_ClickSave, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, True)
            InsertErrorLogSC(StaffConsole.Username, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            ShowDialogErrorMessage("Save Fail")
        End Try

    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click, btnClose.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLockerSetting_ClickClose, "", False)
        Me.Close()
        frmMain.CloseAllChildForm()
        Dim f As New frmSC_StockAndHardware
        f.ShowDialog(frmMain)
    End Sub

    Private Sub UcCabinet_MoveLeftClick(sender As ucCabinet) Handles UcCabinet1.MoveLeftClick, UcCabinet2.MoveLeftClick, UcCabinet3.MoveLeftClick, UcCabinet4.MoveLeftClick, UcCabinet5.MoveLeftClick, UcCabinet6.MoveLeftClick, UcCabinet7.MoveLeftClick, UcCabinet8.MoveLeftClick, UcCabinet9.MoveLeftClick, UcCabinet10.MoveLeftClick
        Dim ucCb As ucCabinet = sender
        If CabinetList.Rows.Count > 0 Then
            'เช็คว่าตำแหน่งปัจจุบันไม่ใช่ตำแหน่งแรก
            If ucCb.OrderLayoutNo >= CabinetList.Rows(0)("order_layout") Then
                Dim FromPosition As Integer = ucCb.OrderLayoutNo
                Dim ToPosition As Integer = FromPosition - 1
                Dim ret As ExecuteDataInfo = MoveCabinetPosition(FromPosition, ToPosition, ucCb)

                If ret.IsSuccess = True Then
                    'ucCb.OrderLayoutNo = ToPosition
                    'LoadAllCabinetData()
                    Me.Close()
                    frmSC_StockAndHardware.lblLockerSetting_Click(Nothing, Nothing)
                    Application.DoEvents()
                Else
                    ShowDialogErrorMessage(ret.ErrorMessage)
                End If
            Else
                ShowDialogErrorMessage("ไม่สามารถย้ายตำแหน่งได้")
            End If
        End If
    End Sub

    Private Function MoveCabinetPosition(FromPosition As Integer, ToPosition As Integer, ucCb As ucCabinet) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo

        Dim TempPosition As Integer = -1
        Dim trans As New KioskTransactionDB
        '1. ต้องเปลี่ยน layout_order ของตำแหน่งปลายทาง ให้เป็นตำแหน่ง Temp ก่อน
        Dim cLnq As New MsCabinetKioskLinqDB
        cLnq.ChkDataByMS_KIOSK_ID_ORDER_LAYOUT(KioskData.KioskID, ToPosition, trans.Trans)
        If cLnq.ID > 0 Then
            cLnq.ORDER_LAYOUT = TempPosition
            cLnq.SYNC_TO_SERVER = "N"
            ret = cLnq.UpdateData(StaffConsole.Username, trans.Trans)
        End If

        '2. เปลี่ยนตำแหน่งของตู้ในตำแหน่งปัจจุบันให้อยู่ตำแหน่งปลายทาง
        If ret.IsSuccess = True Then
            cLnq.GetDataByPK(ucCb.CabinetID, trans.Trans)
            If cLnq.ID > 0 Then
                cLnq.ORDER_LAYOUT = ToPosition
                cLnq.SYNC_TO_SERVER = "N"
                ret = cLnq.UpdateData(StaffConsole.Username, trans.Trans)
            End If
        End If

        '3. เปลี่ยนตำแหน่งปลายทาง (TempPosition) ให้มาแทนที่ตำแหน่งปัจจุบัน
        If ret.IsSuccess = True Then
            cLnq.ChkDataByMS_KIOSK_ID_ORDER_LAYOUT(KioskData.KioskID, TempPosition, trans.Trans)
            If cLnq.ID > 0 Then
                cLnq.ORDER_LAYOUT = FromPosition
                cLnq.SYNC_TO_SERVER = "N"
                ret = cLnq.UpdateData(StaffConsole.Username, trans.Trans)
            End If
        End If

        If ret.IsSuccess = True Then

            trans.CommitTransaction()
            SetCabinetInformation()
        Else
            trans.RollbackTransaction()
        End If

        Return ret
    End Function

    Private Sub UcCabinet_MoveRightClick(sender As ucCabinet) Handles UcCabinet1.MoveRightClick, UcCabinet2.MoveRightClick, UcCabinet3.MoveRightClick, UcCabinet4.MoveRightClick, UcCabinet5.MoveRightClick, UcCabinet6.MoveRightClick, UcCabinet7.MoveRightClick, UcCabinet8.MoveRightClick, UcCabinet9.MoveRightClick, UcCabinet10.MoveRightClick
        Dim ucCb As ucCabinet = sender
        If CabinetList.Rows.Count > 0 Then
            'เช็คว่าตำแหน่งปัจจุบันไม่ใช่ตำแหน่งสุดท้าย
            Dim LastPos As Integer = CabinetList.Rows.Count - 1
            CabinetList.DefaultView.Sort = "order_layout"
            If ucCb.OrderLayoutNo <= CabinetList.DefaultView(LastPos)("order_layout") Then
                Dim FromPosition As Integer = ucCb.OrderLayoutNo
                Dim ToPosition As Integer = FromPosition + 1
                Dim ret As ExecuteDataInfo = MoveCabinetPosition(FromPosition, ToPosition, ucCb)

                If ret.IsSuccess = True Then
                    'ucCb.OrderLayoutNo = ToPosition
                    'LoadAllCabinetData()

                    Me.Close()
                    frmSC_StockAndHardware.lblLockerSetting_Click(Nothing, Nothing)
                    Application.DoEvents()
                Else
                    ShowDialogErrorMessage(ret.ErrorMessage)
                End If
            Else
                ShowDialogErrorMessageSC("ไม่สามารถย้ายตำแหน่งได้")
            End If
            CabinetList.DefaultView.Sort = ""
        End If

    End Sub

    Private Sub lblAdd_Click(sender As Object, e As EventArgs) Handles lblAdd.Click, pnAdd.Click
        Dim f As New frmSC_LayoutAdd
        f.lblHeader.Text = "เพิ่มตู้"
        If f.ShowDialog(Me.ParentForm) = DialogResult.OK Then
            AddNewCabinet(f)
        End If
    End Sub

    Private Function GetNextCabinetOrder() As Integer
        Dim ret As Integer = 1
        Try
            'Get Next Cabinet No from Server
            Dim sql As String = "select isnull(max(order_layout),0) + 1  order_layout "
            sql += " from MS_CABINET "
            sql += " where ms_kiosk_id=@_KIOSK_ID"
            Dim p(1) As SqlClient.SqlParameter
            p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_KIOSK_ID", KioskData.KioskID)

            Dim dt As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                ret = Convert.ToInt16(dt.Rows(0)("order_layout"))
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
        Return ret
    End Function

    Private Function GetNextLockerNo(_trans As SqlClient.SqlTransaction) As Integer
        Dim ret As Integer = 1
        Try
            'Get Next Cabinet No from Server
            Dim sql As String = "select isnull(max(id),0) + 1  locker_no "
            sql += " from MS_LOCKER "
            sql += " where ms_kiosk_id=@_KIOSK_ID"
            Dim p(1) As SqlClient.SqlParameter
            p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_KIOSK_ID", KioskData.KioskID)

            Dim dt As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, _trans, p)
            If dt.Rows.Count > 0 Then
                ret = Convert.ToInt16(dt.Rows(0)("locker_no"))
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
        Return ret
    End Function

    Private Sub AddNewCabinet(f As frmSC_LayoutAdd)
        Dim ModelID As Long = f.cmbModel.SelectedValue
        Dim mLnq As New ServerLinqDB.TABLE.MsCabinetModelServerLinqDB
        mLnq.GetDataByPK(ModelID, Nothing)
        If mLnq.ID > 0 Then
            Dim _CabinetOrder As Integer = GetNextCabinetOrder()

            'Add Cabinet to server
            Dim sLnq As New ServerLinqDB.TABLE.MsCabinetServerLinqDB
            sLnq.CABINET_NO = _CabinetOrder
            sLnq.MS_KIOSK_ID = KioskData.KioskID
            sLnq.MS_CABINET_MODEL_ID = mLnq.ID
            sLnq.ORDER_LAYOUT = _CabinetOrder
            sLnq.SERVICE_RATE_HOUR = mLnq.SERVICE_RATE_HOUR
            sLnq.SERVICE_RATE_LIMIT_DAY = mLnq.SERVICE_RATE_LIMIT_DAY
            sLnq.DEPOSIT_AMT = mLnq.DEPOSIT_AMT
            sLnq.ACTIVE_STATUS = "Y"
            sLnq.SYNC_TO_KIOSK = "Y"
            sLnq.SYNC_TO_SERVER = "Y"

            Dim sTrans As New ServerLinqDB.ConnectDB.ServerTransactionDB
            Dim sRet As ServerLinqDB.ConnectDB.ExecuteDataInfo = sLnq.InsertData(StaffConsole.Username, sTrans.Trans)
            If sRet.IsSuccess = True Then
                Dim cLnq As New MsCabinetKioskLinqDB
                cLnq.CABINET_NO = _CabinetOrder
                cLnq.MS_KIOSK_ID = KioskData.KioskID
                cLnq.MS_CABINET_MODEL_ID = mLnq.ID
                cLnq.ORDER_LAYOUT = _CabinetOrder
                cLnq.SERVICE_RATE_HOUR = mLnq.SERVICE_RATE_HOUR
                cLnq.SERVICE_RATE_LIMIT_DAY = mLnq.SERVICE_RATE_LIMIT_DAY
                cLnq.DEPOSIT_AMT = mLnq.DEPOSIT_AMT
                cLnq.MS_CABINET_ID = sLnq.ID
                cLnq.ACTIVE_STATUS = "Y"
                cLnq.SYNC_TO_KIOSK = "Y"
                cLnq.SYNC_TO_SERVER = "Y"

                Dim trans As New KioskTransactionDB
                Dim re As ExecuteDataInfo = cLnq.InsertData(StaffConsole.Username, trans.Trans)
                If re.IsSuccess = True Then
                    For i As Integer = 0 To mLnq.LOCKER_QTY - 1
                        Dim _LockerNo As Integer = GetNextLockerNo(trans.Trans)

                        'Add Locker To server
                        Dim slLnq As New ServerLinqDB.TABLE.MsLockerServerLinqDB
                        slLnq.LOCKER_NAME = mLnq.MODEL_NAME & _LockerNo
                        slLnq.MS_KIOSK_ID = KioskData.KioskID
                        slLnq.MS_CABINET_ID = sLnq.ID
                        slLnq.PIN_SOLENOID = 0
                        slLnq.PIN_LED = 0
                        slLnq.PIN_SENSOR = 0
                        slLnq.MODEL_NAME = mLnq.MODEL_NAME
                        slLnq.OPEN_CLOSE_STATUS = "C"
                        slLnq.CURRENT_AVAILABLE = "Y"
                        slLnq.ACTIVE_STATUS = "Y"
                        slLnq.SYNC_TO_SERVER = "Y"
                        slLnq.SYNC_TO_KIOSK = "Y"

                        sRet = slLnq.InsertData(StaffConsole.Username, sTrans.Trans)
                        If sRet.IsSuccess = True Then
                            Dim lLnq As New MsLockerKioskLinqDB
                            lLnq.LOCKER_NAME = mLnq.MODEL_NAME & _LockerNo
                            lLnq.MS_KIOSK_ID = KioskData.KioskID
                            lLnq.MS_CABINET_ID = cLnq.ID
                            lLnq.MS_LOCKER_ID = slLnq.ID
                            lLnq.PIN_SOLENOID = 0
                            lLnq.PIN_LED = 0
                            lLnq.PIN_SENSOR = 0
                            lLnq.MODEL_NAME = mLnq.MODEL_NAME
                            lLnq.OPEN_CLOSE_STATUS = "C"
                            lLnq.CURRENT_AVAILABLE = "Y"
                            lLnq.ACTIVE_STATUS = "Y"
                            lLnq.SYNC_TO_SERVER = "Y"
                            lLnq.SYNC_TO_KIOSK = "Y"

                            re = lLnq.InsertData(StaffConsole.Username, trans.Trans)
                            If re.IsSuccess = False Then
                                InsertErrorLogSC(StaffConsole.Username, re.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                                Exit For
                            End If
                        Else
                            InsertErrorLogSC(StaffConsole.Username, sRet.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                            Exit For
                        End If
                    Next

                    If re.IsSuccess = True And sRet.IsSuccess = True Then
                        trans.CommitTransaction()
                        sTrans.CommitTransaction()

                        Me.Close()
                        frmSC_StockAndHardware.lblLockerSetting_Click(Nothing, Nothing)
                        Application.DoEvents()
                    Else
                        trans.RollbackTransaction()
                        sTrans.RollbackTransaction()
                    End If
                Else
                    trans.RollbackTransaction()
                    sTrans.RollbackTransaction()

                    InsertErrorLogSC(StaffConsole.Username, re.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                End If
                cLnq = Nothing
            Else
                sTrans.RollbackTransaction()
                InsertErrorLogSC(StaffConsole.Username, sRet.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            End If
        End If
        mLnq = Nothing
    End Sub

    Private Sub UcCabinet_DeleteCabinet() Handles UcCabinet1.DeleteCabinet, UcCabinet2.DeleteCabinet, UcCabinet3.DeleteCabinet, UcCabinet4.DeleteCabinet, UcCabinet5.DeleteCabinet, UcCabinet6.DeleteCabinet, UcCabinet7.DeleteCabinet, UcCabinet8.DeleteCabinet, UcCabinet9.DeleteCabinet, UcCabinet10.DeleteCabinet

        'Re order Cabinet
        Dim sql As String = "select id"
        sql += " from ms_cabinet "
        sql += " order by order_layout "
        Dim dt As DataTable = KioskDB.ExecuteTable(sql)
        If dt.Rows.Count > 0 Then
            Dim ret As ExecuteDataInfo
            Dim trans As New KioskTransactionDB
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                sql = " update ms_cabinet "
                sql += " set cabinet_no=@_ORDER_LAYOUT "
                sql += ", order_layout=@_ORDER_LAYOUT "
                sql += ", sync_to_server='N'"
                sql += " where id=@_ID"

                Dim p(2) As SqlClient.SqlParameter
                p(0) = KioskDB.SetInt("@_ORDER_LAYOUT", (i + 1))
                p(1) = KioskDB.SetBigInt("@_ID", Convert.ToInt64(dr("id")))

                ret = KioskDB.ExecuteNonQuery(sql, trans.Trans, p)
                If ret.IsSuccess = False Then
                    Exit For
                End If
            Next

            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        End If
        dt.Dispose()

        Me.Close()
        frmSC_StockAndHardware.lblLockerSetting_Click(Nothing, Nothing)
        Application.DoEvents()
    End Sub
End Class