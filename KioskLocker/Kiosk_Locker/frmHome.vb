Imports MiniboxLocker.Data
Imports MiniboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB

Public Class frmHome

    Private Delegate Sub myDelegate(data As String)
    Private FormHomeError As myDelegate

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        FormHomeError = AddressOf SetFormError

        GetKioskConfig()
        GetKioskDeviceConfig()
    End Sub



    Private Sub frmHome_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        Me.Height = 997
        CheckForIllegalCrossThreadCalls = False
        frmMain.pnlCancel.Visible = False
        frmMain.btnPointer.Visible = True
        frmMain.TimerCheckOpenClose.Enabled = True

        'ต้อง Clear Transaction ทุกครั้งที่เข้าหน้า Home
        ServiceID = 0
        Deposit = New DepositTransactionData(KioskData.KioskID)
        Collect = New CollectTransactionData(KioskData.KioskID)
        StaffConsole = New StaffConsoleLogonData(KioskData.KioskID)
        WebCam = New WebCamera.DSCamCapture

        KioskConfig.SelectForm = KioskLockerForm.Home
        frmDepositSelectLocker.MdiParent = frmMain
        frmDepositSelectLocker.LoadLockerList()
        InsertLogTransactionActivity("", "", "", KioskLockerForm.Home, KioskLockerStep.Home_LoadLockerList, "", False)

        'Disable CashIn และ CoinIn เพื่อไม่ให้สามารถใส่เงินเข้าไปได้
        BanknoteIn.DisableDeviceCashIn()
        CoinIn.DisableDeviceCoinIn()

        SetLockerHomeData()

        SetLabelNotificationText()

        pbDeposit.Enabled = True
        pbCollect.Enabled = True

        frmLoading.Close()
        Application.DoEvents()
    End Sub


    Public Sub SetLabelNotificationText()
        Dim IsStorageFull As Boolean = False

        Dim LockerQty As Integer = 0
        LockerList.DefaultView.RowFilter = "active_status='Y'"
        LockerQty = LockerList.DefaultView.Count
        LockerList.DefaultView.RowFilter = ""

        LockerList.DefaultView.RowFilter = "current_available='N' and active_status='Y'"
        If LockerList.DefaultView.Count = LockerQty Then
            'ถ้าช่องฝากทั้งหมด ไม่ว่างแล้ว
            pbDeposit.BackgroundImage = My.Resources.IconDepositFull
            RemoveHandler pbDeposit.Click, AddressOf btnDeposit_Click
            pbDeposit.Enabled = False
            IsStorageFull = True
            Application.DoEvents()
        End If
        LockerList.DefaultView.RowFilter = ""

        If IsStorageFull = False Then

            Dim dvDt As DataTable = GetStatusAllDeviceDT()
            If dvDt.Rows.Count > 0 Then
                'แสดง Notification เมื่อเหรียญ5หมด
                dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.CoinOut_5 & " and stock_status='Critical'"
                If dvDt.DefaultView.Count > 0 Then
                    'lblLabelNotification.Text = GetNotificationText(2)
                    'lblLabelNotification.Visible = True
                End If
                dvDt.DefaultView.RowFilter = ""

                'แสดง Notification เมื่อแบงค์ 20 หมด
                dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.BankNoteOut_20 & " and stock_status='Critical'"
                If dvDt.DefaultView.Count > 0 Then
                    'lblLabelNotification.Text = GetNotificationText(3)
                    'lblLabelNotification.Visible = True
                End If
                dvDt.DefaultView.RowFilter = ""

                'แสดง Notification เมื่อแบงค์ 100 หมด
                dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.BankNoteOut_100 & " and stock_status='Critical'"
                If dvDt.DefaultView.Count > 0 Then
                    'lblLabelNotification.Text = GetNotificationText(4)
                    'lblLabelNotification.Visible = True
                End If
                dvDt.DefaultView.RowFilter = ""

                'แสดง Notification เมื่อแบงค์ 20 และ แบงค์ 100 หมดพร้อมกัน
                dvDt.DefaultView.RowFilter = " (device_id=" & DeviceID.BankNoteOut_20 & " and stock_status='Critical') or (device_id=" & DeviceID.BankNoteOut_100 & " and stock_status='Critical')"
                If dvDt.DefaultView.Count = 2 Then
                    'lblLabelNotification.Text = GetNotificationText(7)
                    'lblLabelNotification.Visible = True
                End If
                dvDt.DefaultView.RowFilter = ""

                Application.DoEvents()
            End If
            dvDt.Dispose()
        End If
    End Sub

    Private Sub SetFormError(MsAppStepID As String)
        ShowFormError("", "", KioskConfig.SelectForm, MsAppStepID, True)
    End Sub

    Private Sub SetLockerHomeData()
        Try
            Dim chk As String = ""

            'Update Current Status ลง DB
            UpdateAllDeviceStatusByComPort()
            UpdateAllDeviceStatusByUsbPort()
            'ตรวจสอบ Status จาก DB
            chk += CheckStockAndStatusAllDevice()

            If chk.Trim <> "" Then
                'Out Of Service
                InsertErrorLog(chk, "", "", "", KioskConfig.SelectForm, KioskLockerStep.Home_CheckHardwareStatus)
                Me.Invoke(FormHomeError, Convert.ToInt64(KioskLockerStep.Home_CheckHardwareStatus).ToString)
            Else
                SetLockerList()
                If LockerList.Rows.Count = 0 Then
                    InsertErrorLog("Locker information not found", "", "", "", KioskConfig.SelectForm, KioskLockerStep.Home_LoadLockerList)
                    Me.Invoke(FormHomeError, Convert.ToInt64(KioskLockerStep.Home_LoadLockerList).ToString)
                End If

                SetLabelNotificationText()

                ServiceRateData.SetServiceRateData(KioskData.KioskID)
                If ServiceRateData.ServiceRateDepositList.Rows.Count = 0 Or ServiceRateData.ServiceRateHourList.Rows.Count = 0 Or ServiceRateData.ServiceRateOvernightList.Rows.Count = 0 Then
                    InsertErrorLog("Service Rate Information not found", "", "", "", KioskConfig.SelectForm, KioskLockerStep.Home_LoadLockerList)
                    Me.Invoke(FormHomeError, Convert.ToInt64(KioskLockerStep.Home_LoadLockerList).ToString)
                End If
            End If

        Catch ex As Exception
            InsertErrorLog(ex.Message & vbNewLine & ex.StackTrace, "", "", "", KioskConfig.SelectForm, KioskLockerStep.Home_CheckHardwareStatus)
        End Try
    End Sub

#Region "Deposit"
    Private Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles pbDeposit.Click
        If LockerList.Rows.Count = 0 Then
            InsertErrorLog("Locker Information not found", 0, 0, 0, KioskConfig.SelectForm, KioskLockerStep.Home_ClickDeposit)
            SendKioskAlarm("LOCKER_OUT_OF_SERVICE", True)
            ShowFormError("Out of service", "Locker Information not found", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Home_ClickDeposit, True)
            Exit Sub
        End If

        frmLoading.Show(frmMain)
        Application.DoEvents()
        'Create New Deposit Service Transaction
        Dim ret As ExecuteDataInfo = CreateNewDepositTransaction()
        If ret.IsSuccess = True Then
            InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskLockerForm.Home, KioskLockerStep.Home_ClickDeposit, "", False)
            Me.Close()
            frmDepositSelectLocker.Show()
            frmMain.btnPointer.Visible = False
            frmMain.TimerCheckOpenClose.Enabled = False
            SendKioskAlarm("LOCKER_OUT_OF_SERVICE", False)
        Else
            frmLoading.Close()
            InsertErrorLog(ret.ErrorMessage, 0, 0, 0, KioskLockerForm.Home, KioskLockerStep.Home_ClickDeposit)
            SendKioskAlarm("LOCKER_OUT_OF_SERVICE", True)
            ShowDialogErrorMessage("Cannot create transaction")

        End If

    End Sub


#End Region

#Region "Collect"
    Private Sub pnlCollect_Click(sender As Object, e As EventArgs) Handles  pbCollect.Click
        Dim ret As ExecuteDataInfo = CreateNewPickupTransaction()
        InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskLockerForm.Home, KioskLockerStep.Home_ClickPickup, "เริ่มทำรายการรับคืน", False)
        If ret.IsSuccess = True Then
            frmLoading.Show(frmMain)
            Application.DoEvents()
            Me.Close()

            frmCollectScanQRCode.MdiParent = frmMain
            frmCollectScanQRCode.Show()
            frmMain.btnPointer.Visible = False
            frmMain.TimerCheckOpenClose.Enabled = False
            Application.DoEvents()
            SendKioskAlarm("LOCKER_OUT_OF_SERVICE", False)
        Else
            InsertErrorLog(ret.ErrorMessage, 0, 0, 0, KioskLockerForm.Home, KioskLockerStep.Home_ClickPickup)
            SendKioskAlarm("LOCKER_OUT_OF_SERVICE", True)
            ShowDialogErrorMessage("Cannot create transaction")
        End If
    End Sub



#End Region
End Class