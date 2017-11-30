Imports System.Data.SqlClient
Imports System.IO
Imports KioskLinqDB.ConnectDB
Imports AutoboxLocker.Data.KioskConfigData

Public Class frmSC_StockAndHardware

    Public Enum FormColor
        Red = 1
        Yellow = 2
        Green = 3
    End Enum
    Private Sub frmSC_StockAndHardware_Load(sender As Object, e As EventArgs) Handles Me.Load
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleStoakAndHardware
        Me.ControlBox = False
    End Sub

    Private Sub frmSC_StockAndHardware_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmSC_Main.lblTitle.Text = "DASHBOARD"
        Application.DoEvents()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_GetKioskConfig, "", False)
        GetKioskConfig()
        GetKioskDeviceConfig()

        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleStoakAndHardware
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_SetStockAndHardwareStatus, "", False)
        SetStockAndHardwareStatus()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_CheckAuthorize, "", False)
        CheckStaffConsoleAuthorization()

        'frmDepositSelectLocker.MdiParent = frmMain
        'frmDepositSelectLocker.LoadLockerList()
        'InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_LoadLockerList, "", False)
    End Sub

    Private Sub CheckStaffConsoleAuthorization()
        If StaffConsole.AuthorizeInfo.Rows.Count > 0 Then
            'Fill Paper
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=16"
            If StaffConsole.AuthorizeInfo.DefaultView.Count = 0 Then
                lblFillPaper.Visible = False
            End If
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""

            'Fill Money
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=17"
            If StaffConsole.AuthorizeInfo.DefaultView.Count = 0 Then
                lblFillMoney.Visible = False
            End If
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""

            'Kiosk Setting
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=18"
            If StaffConsole.AuthorizeInfo.DefaultView.Count = 0 Then
                lblKioskSetting.Visible = False
            End If
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""

            'Device Setting
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=19"
            If StaffConsole.AuthorizeInfo.DefaultView.Count = 0 Then
                lblDeviceSetting.Visible = False
            End If
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""

            'Locker Setting
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=20"
            If StaffConsole.AuthorizeInfo.DefaultView.Count = 0 Then
                lblLockerSetting.Visible = False
            End If
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""

            'Open All
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=21"
            If StaffConsole.AuthorizeInfo.DefaultView.Count = 0 Then
                lblOpenAll.Visible = False
            End If
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""

            'Collect
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=29"
            If StaffConsole.AuthorizeInfo.DefaultView.Count = 0 Then
                lblCollect.Visible = False
            End If
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""
        End If
    End Sub


    Private Sub SetStockAndHardwareStatus()
        Dim sql As String = "select kd.device_type_id, kd.device_id, kd.device_name_en, kd.icon_white, kd.icon_green, kd.icon_red,"
        sql += " kd.current_status_name, kd.is_problem,kd.movement_direction,"
        sql += " kd.kiosk_max_qty, kd.kiosk_warning_qty, kd.kiosk_critical_qty, kd.kiosk_current_qty"
        sql += " from v_kiosk_device_info kd "
        sql += " where kd.ms_kiosk_id=@_KIOSK_ID"
        sql += " and kd.type_active_status='Y' and kd.device_active_status='Y'"
        sql += " order by kd.device_order"
        Dim p(1) As SqlParameter
        p(0) = KioskDB.SetBigInt("@_KIOSK_ID", Convert.ToInt16(KioskData.KioskID))

        Dim Dt As DataTable = KioskDB.ExecuteTable(sql, p)
        If Dt.Rows.Count > 0 Then
            For i As Integer = 0 To Dt.Rows.Count - 1
                Dim dr As DataRow = Dt.Rows(i)

                Dim DeviceName As String = ""
                Dim IconGreen() As Byte = {}
                Dim IconYellow() As Byte = {}
                Dim IconRed() As Byte = {}

                DeviceName = dr("device_name_en")
                If Convert.IsDBNull(dr("icon_green")) = False Then
                    IconGreen = CType(dr("icon_green"), Byte())
                    IconYellow = CType(dr("icon_green"), Byte())
                End If
                If Convert.IsDBNull(dr("icon_red")) = False Then
                    IconRed = CType(dr("icon_red"), Byte())
                End If

                Dim StatusName As String = dr("current_status_name")
                Dim IsProblem As Boolean = IIf(dr("is_problem") = "Y", True, False)
                Dim Movement As String = dr("movement_direction")

                'Hardware Status
                Dim frm As New ucfrmStatus
                If IsProblem = False Then
                    SetForm(frm, IconGreen, FormColor.Green, DeviceName, StatusName)
                Else
                    SetForm(frm, IconRed, FormColor.Red, DeviceName, StatusName)
                End If
                'flpHWStatus.Controls.Add(frm)

                'Material Stock
                frm = New ucfrmStatus
                If Dt.Rows(i).Item("device_type_id") = Data.ConstantsData.DeviceType.BanknoteIn Or
                   Dt.Rows(i).Item("device_type_id") = Data.ConstantsData.DeviceType.BanknoteOut Or
                   Dt.Rows(i).Item("device_type_id") = Data.ConstantsData.DeviceType.CoinIn Or
                   Dt.Rows(i).Item("device_type_id") = Data.ConstantsData.DeviceType.CoinOut Or
                   Dt.Rows(i).Item("device_type_id") = Data.ConstantsData.DeviceType.Printer Then

                    If Movement <> "" Then
                        Dim CurrentQty As Integer = 0
                        Dim MaxQty As Integer = 0
                        Dim CriticalQty As Integer = 0
                        Dim WarningQty As Integer = 0

                        If Convert.IsDBNull(dr("kiosk_current_qty")) = False Then
                            CurrentQty = Convert.ToInt64(dr("kiosk_current_qty"))
                        End If
                        If Convert.IsDBNull(dr("kiosk_max_qty")) = False Then
                            MaxQty = Convert.ToInt64(dr("kiosk_max_qty"))
                        End If
                        If Convert.IsDBNull(dr("kiosk_critical_qty")) = False Then
                            CriticalQty = Convert.ToInt64(dr("kiosk_critical_qty"))
                        End If
                        If Convert.IsDBNull(dr("kiosk_warning_qty")) = False Then
                            WarningQty = Convert.ToInt64(dr("kiosk_warning_qty"))
                        End If

                        Dim Detail As String = CurrentQty.ToString & "/" & MaxQty.ToString
                        If Movement = "1" Then
                            If CurrentQty < WarningQty Then
                                'Normal
                                SetForm(frm, IconGreen, FormColor.Green, DeviceName, Detail)
                            ElseIf CurrentQty < CriticalQty Then
                                'Warning
                                SetForm(frm, IconYellow, FormColor.Yellow, DeviceName, Detail)
                            Else
                                'Critical
                                SetForm(frm, IconRed, FormColor.Red, DeviceName, Detail)
                            End If
                        Else
                            If CurrentQty > WarningQty Then
                                'Normal
                                SetForm(frm, IconGreen, FormColor.Green, DeviceName, Detail)
                            ElseIf CurrentQty > CriticalQty Then
                                'Warning
                                SetForm(frm, IconYellow, FormColor.Yellow, DeviceName, Detail)
                            Else
                                'Critical
                                SetForm(frm, IconRed, FormColor.Red, DeviceName, Detail)
                            End If
                        End If
                    End If
                    'flpM_Stock.Controls.Add(frm)
                End If
            Next
        End If
        Dt.Dispose()
    End Sub

    Sub SetForm(ByVal frm As ucfrmStatus, ByVal ImgByte() As Byte, ByVal frmColor As FormColor, ByVal frmHeader As String, ByVal frmMessage As String)
        If ImgByte.Length > 0 Then
            Dim ms As New MemoryStream(ImgByte)
            Dim im As Image
            im = Image.FromStream(ms)
            Dim Img As Image
            Img = im
            frm.pb.Image = Img
        End If

        frm.lblHeader.Text = frmHeader
        frm.lblDetail.Text = frmMessage
        Select Case frmColor
            Case FormColor.Red
                frm.pnlDetail.BackColor = Color.Red
            Case FormColor.Yellow
                frm.pnlDetail.BackColor = Color.Yellow
            Case FormColor.Green
                frm.pnlDetail.BackColor = Color.Green
        End Select

    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs)
        ServiceID = 0
        InsertLogTransactionActivity(StaffConsole.TransNo, Data.KioskConfigData.KioskLockerForm.StaffConsoleStoakAndHardware, KioskLockerStep.StaffConsoleStockAndHardware_ClickClose, "", False)
        frmMain.CloseAllChildForm()
        Dim f As New frmHome
        f.MdiParent = frmMain
        f.Show()

        Me.Close()
    End Sub

    Private Sub lblFillPaper_Click(sender As Object, e As EventArgs) Handles lblFillPaper.Click, btnFillPaper.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickFillPaper, "", False)
        Me.Close()
        frmSC_FillPaper.MdiParent = frmSC_Main
        frmSC_FillPaper.Show()

        Application.DoEvents()
    End Sub

    Private Sub lblFillMoney_Click(sender As Object, e As EventArgs) Handles lblFillMoney.Click, btnFillMoney.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickFillMoney, "", False)
        Me.Close()
        frmSC_FillMoney.MdiParent = frmSC_Main
        frmSC_FillMoney.Show()
        Application.DoEvents()
    End Sub

    Private Sub lblKioskSetting_Click(sender As Object, e As EventArgs) Handles lblKioskSetting.Click, btnKioskSetting.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickKioskSetting, "", False)

        Me.Hide()
        frmMain.CloseAllChildForm()
        Dim f As New frmSC_KioskSetting
        f.ShowDialog(frmMain)
    End Sub

    Private Sub lblDeviceSetting_Click(sender As Object, e As EventArgs) Handles lblDeviceSetting.Click, btnDeviceSetting.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickDeviceSetting, "", False)

        Me.Hide()
        frmMain.CloseAllChildForm()
        Dim f As New frmSC_DeviceSetting
        f.ShowDialog(frmMain)
    End Sub

    Public Sub lblLockerSetting_Click(sender As Object, e As EventArgs) Handles lblLockerSetting.Click, btnLockerSetting.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickLockerSetting, "", False)

        Me.Hide()
        frmMain.CloseAllChildForm()
        Dim f As New frmSC_LockerSetting
        f.ShowDialog(frmMain)
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs)
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickExitProgram, "", False)
        WebCam.Dispose()
        Application.Exit()
    End Sub

    Private Sub lblOpenAll_Click(sender As Object, e As EventArgs) Handles lblOpenAll.Click, btnOpenAll.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickOpenAll, "", False)

        Dim y As DialogResult = MessageBox.Show("ยืนยันการเปิดทุกช่องฝาก", "Comfirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If y = DialogResult.OK Then

            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickOpenAll, "ยืนยันการเปิดช่องฝากทั้งหมด", False)
            If LockerList.Rows.Count > 0 Then
                For Each dr As DataRow In LockerList.Rows
                    Try
                        If Convert.ToInt16(dr("pin_solenoid")) > 0 Then
                            BoardSolenoid.SolenoidOpen(dr("pin_solenoid"))
                            Threading.Thread.Sleep(2000)
                        End If
                    Catch ex As Exception

                    End Try
                Next

                Application.DoEvents()
            End If
        End If

    End Sub

    Private Sub btnCollect_Click(sender As Object, e As EventArgs) Handles lblCollect.Click, btnCollect.Click
        If LockerList.Rows.Count = 0 Then
            InsertErrorLog("Locker Information not found", 0, 0, 0, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_ClickCollect)
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", True)
            ShowFormError("Out of service", "Locker Information not found", KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_ClickCollect, True)
            Exit Sub
        End If

        'Create New Collect Transaction
        Dim ret As ExecuteDataInfo = CreateNewPickupTransaction()
        If ret.IsSuccess = True Then
            InsertLogTransactionActivity("", Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_ClickCollect, "", False)
            frmDepositSelectLocker.Show()
            frmMain.btnPointer.Visible = False
            frmMain.TimerCheckOpenClose.Enabled = False
            Me.Close()
            'frmDepositSelectLocker.BringToFront()
            Application.DoEvents()
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", False)
        Else
            InsertErrorLog(ret.ErrorMessage, "", "", StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_ClickCollect)
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", True)
            ShowDialogErrorMessage("Cannot create Collect transaction")
        End If
    End Sub
End Class