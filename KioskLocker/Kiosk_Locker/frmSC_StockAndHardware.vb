Imports System.Data.SqlClient
Imports System.IO
Imports KioskLinqDB.ConnectDB
Imports MiniboxLocker.Data.KioskConfigData
Imports MiniboxLocker.Data.ConstantsData

Public Class frmSC_StockAndHardware

    Private Sub frmSC_StockAndHardware_Load(sender As Object, e As EventArgs) Handles Me.Load
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleStoakAndHardware
        Me.ControlBox = False
        pgStockCoinIn.Direction = ucStockProgress.ProgressDirection.RightToLeft
        pgStockBanknoteIn.Direction = ucStockProgress.ProgressDirection.RightToLeft
    End Sub

    Private Sub frmSC_StockAndHardware_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmSC_Main.lblTitle.Text = "DASHBOARD"

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_GetKioskConfig, "", False)
        GetKioskConfig()

        SetListDeviceInfo()
        GetKioskDeviceConfig()

        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleStoakAndHardware
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_SetStockAndHardwareStatus, "", False)
        SetStockAndHardwareStatus()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_CheckAuthorize, "", False)
        CheckStaffConsoleAuthorization()

        frmDepositSelectLocker.MdiParent = frmMain
        frmDepositSelectLocker.LoadLockerList()
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_LoadLockerList, "", False)

        frmLoading.Close()
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

            'Service Rate
            StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=30"
            If StaffConsole.AuthorizeInfo.DefaultView.Count = 0 Then
                lblServiceRate.Visible = False
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

                If IsProblem = False Then
                    SetDeviceStatus(dr("device_id"), IconGreen)
                Else
                    SetDeviceStatus(dr("device_id"), IconRed)
                End If

                'Material Stock
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
                                SetStock(dr("device_id"), CurrentQty, MaxQty, Color.FromArgb(6, 175, 143))
                            ElseIf CurrentQty < CriticalQty Then
                                'Warning
                                SetStock(dr("device_id"), CurrentQty, MaxQty, Color.Orange)
                            Else
                                'Critical
                                SetStock(dr("device_id"), CurrentQty, MaxQty, Color.Red)
                            End If
                        Else
                            If CurrentQty > WarningQty Then
                                'Normal
                                SetStock(dr("device_id"), CurrentQty, MaxQty, Color.FromArgb(6, 175, 143))
                            ElseIf CurrentQty > CriticalQty Then
                                'Warning
                                SetStock(dr("device_id"), CurrentQty, MaxQty, Color.Orange)
                            Else
                                'Critical
                                SetStock(dr("device_id"), CurrentQty, MaxQty, Color.Red)
                            End If
                        End If
                    End If
                    ''flpM_Stock.Controls.Add(frm)
                End If
            Next
            Application.DoEvents()
        End If
        Dt.Dispose()
    End Sub

    Sub SetDeviceStatus(vDeviceID As Long, ByVal ImgByte() As Byte)
        If ImgByte.Length > 0 Then
            Dim ms As New MemoryStream(ImgByte)

            Select Case vDeviceID
                Case DeviceID.BankNoteIn
                    pbStatusBanknoteIn.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.CoinIn
                    pbStatusCoinIn.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.BankNoteOut_20
                    pbStatusBanknoteOut20.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.BankNoteOut_50

                Case DeviceID.BankNoteOut_100
                    pbStatusBanknoteOut100.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.BankNoteOut_500

                Case DeviceID.CoinOut_1

                Case DeviceID.CoinOut_2

                Case DeviceID.CoinOut_5
                    pbStatusCoinOut5.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.CoinOut_10

                Case DeviceID.WebCamera
                    pbStatusWebcam.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.Printer
                    pbStatusPrinter.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.QRCodeReader
                    pbStatusQRCode.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.LEDBoard
                    pbStatusLED.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.SolenoidBoard
                    pbStatusSolenoid.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.SensorBoard
                    pbStatusSensor.BackgroundImage = Image.FromStream(ms)
                Case DeviceID.NetworkConnection
                    pbStatusNetwork.BackgroundImage = Image.FromStream(ms)
            End Select

        End If


    End Sub

    Sub SetStock(vDeviceID As Long, CurrValue As Integer, TotalValue As Integer, StatusColor As Color)
        Select Case vDeviceID
            Case DeviceID.BankNoteIn
                lblStockBanknoteIn.Text = CurrValue
                lblTotalBanknoteIn.Text = "/" & TotalValue
                lblStockBanknoteIn.ForeColor = StatusColor

                pgStockBanknoteIn.MaxValue = TotalValue
                pgStockBanknoteIn.Value = CurrValue
                pgStockBanknoteIn.BarColor = StatusColor
            Case DeviceID.CoinIn
                lblStockCoinIn.Text = CurrValue
                lblTotalCoinIn.Text = "/" & TotalValue
                lblStockCoinIn.ForeColor = StatusColor

                pgStockCoinIn.MaxValue = TotalValue
                pgStockCoinIn.Value = CurrValue
                pgStockCoinIn.BarColor = StatusColor

            Case DeviceID.BankNoteOut_20
                lblStockBanknote20.Text = CurrValue
                lblTotalBanknote20.Text = "/" & TotalValue
                lblStockBanknote20.ForeColor = StatusColor

                pgStockBanknote20.MaxValue = TotalValue
                pgStockBanknote20.Value = CurrValue
                pgStockBanknote20.BarColor = StatusColor

            Case DeviceID.BankNoteOut_100
                lblStockBanknote100.Text = CurrValue
                lblTotalBanknote100.Text = "/" & TotalValue
                lblStockBanknote100.ForeColor = StatusColor

                pgStockBanknote100.MaxValue = TotalValue
                pgStockBanknote100.Value = CurrValue
                pgStockBanknote100.ForeColor = StatusColor

            Case DeviceID.CoinOut_5
                lblStockCoinOut5.Text = CurrValue
                lblTotalCoinOut5.Text = "/" & TotalValue
                lblStockCoinOut5.ForeColor = StatusColor

                pgStockCoinOut5.MaxValue = TotalValue
                pgStockCoinOut5.Value = CurrValue
                pgStockCoinOut5.BarColor = StatusColor

            Case DeviceID.Printer
                lblStockPrinter.Text = CurrValue
                lblTotalPrinter.Text = "/" & TotalValue
                lblStockPrinter.ForeColor = StatusColor

                pgStockPrinter.MaxValue = TotalValue
                pgStockPrinter.Value = CurrValue
                pgStockPrinter.BarColor = StatusColor
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
        frmLoading.Show(frmSC_Main)
        Application.DoEvents()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickFillPaper, "", False)
        Me.Close()
        frmSC_FillPaper.MdiParent = frmSC_Main
        frmSC_FillPaper.Show()
    End Sub

    Private Sub lblFillMoney_Click(sender As Object, e As EventArgs) Handles lblFillMoney.Click, btnFillMoney.Click
        frmLoading.Show(frmSC_Main)
        Application.DoEvents()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickFillMoney, "", False)
        Me.Close()
        frmSC_FillMoney.MdiParent = frmSC_Main
        frmSC_FillMoney.Show()
        Application.DoEvents()
    End Sub

    Private Sub lblKioskSetting_Click(sender As Object, e As EventArgs) Handles lblKioskSetting.Click, btnKioskSetting.Click
        frmLoading.Show(frmSC_Main)
        Application.DoEvents()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickKioskSetting, "", False)
        Me.Close()
        frmSC_KioskSetting.MdiParent = frmSC_Main
        frmSC_KioskSetting.Show()
    End Sub

    Private Sub lblDeviceSetting_Click(sender As Object, e As EventArgs) Handles lblDeviceSetting.Click, btnDeviceSetting.Click
        frmLoading.Show(frmSC_Main)
        Application.DoEvents()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickDeviceSetting, "", False)
        Me.Close()
        frmSC_DeviceSetting.MdiParent = frmSC_Main
        frmSC_DeviceSetting.Show()
    End Sub

    Public Sub lblLockerSetting_Click(sender As Object, e As EventArgs) Handles lblLockerSetting.Click, btnLockerSetting.Click
        frmLoading.Show(frmSC_Main)
        Application.DoEvents()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickLockerSetting, "", False)
        SetCabinetInformation()
        SetCabinetModel()
        Me.Close()
        frmSC_LockerSetting.MdiParent = frmSC_Main
        frmSC_LockerSetting.Show()
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
            frmLoading.Show(frmSC_Main)
            Application.DoEvents()

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
            frmLoading.Close()
        End If

    End Sub

    Private Sub btnCollect_Click(sender As Object, e As EventArgs) Handles lblCollect.Click, btnCollect.Click
        If LockerList.Rows.Count = 0 Then
            InsertErrorLog("Locker Information not found", 0, 0, 0, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_ClickCollect)
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", True)
            ShowFormError("Out of service", "Locker Information not found", KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_ClickCollect, True)
            Exit Sub
        End If

        frmLoading.Show(frmMain)
        Application.DoEvents()
        'Create New Collect Transaction
        Dim ret As ExecuteDataInfo = CreateNewPickupTransaction()
        If ret.IsSuccess = True Then
            InsertLogTransactionActivity("", Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_ClickCollect, "", False)
            Collect.IsFine = True
            Me.Close()
            frmMain.CloseAllChildForm(frmLoading)
            frmMain.Show()
            frmDepositSelectLocker.Show()
            frmMain.btnPointer.Visible = False
            frmMain.TimerCheckOpenClose.Enabled = False
            Application.DoEvents()
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", False)
        Else
            InsertErrorLog(ret.ErrorMessage, "", "", StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLoadLockList_ClickCollect)
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", True)
            ShowDialogErrorMessage("Cannot create Collect transaction")
        End If
        frmLoading.Close()
    End Sub

    Private Sub lblServiceRate_Click(sender As Object, e As EventArgs) Handles lblServiceRate.Click, btnServiceRate.Click
        frmLoading.Show(frmSC_Main)
        Application.DoEvents()

        InsertLogTransactionActivity("", "", StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickServiceRate, "", False)
        Me.Close()
        frmSC_ServiceRate.MdiParent = frmSC_Main
        frmSC_ServiceRate.Show()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickClose, "", False)

        frmSC_Main.Close()
        frmMain.TimerCheckOpenClose.Enabled = True
        frmMain.Show()
    End Sub
End Class