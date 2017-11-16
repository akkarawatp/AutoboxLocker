Imports AutoboxLocker.Data
Imports AutoboxLocker.Data.KioskConfigData
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


    'Private Sub ClearLockerAvailableStatus()
    '    Try
    '        Dim sql As String = "select id from ms_locker "
    '        sql += " where current_available='N' and active_status='Y'"

    '        Dim dt As DataTable = KioskDB.ExecuteTable(sql)
    '        If dt.Rows.Count > 0 Then
    '            For Each dr As DataRow In dt.Rows
    '                sql = "select top 1 d.id " & vbNewLine
    '                sql += " from TB_SERVICE_TRANSACTION d " & vbNewLine
    '                sql += " where d.ms_locker_id=@_LOCKER_ID " & vbNewLine
    '                sql += " and d.ms_kiosk_id=@_KIOSK_ID " & vbNewLine
    '                sql += " and d.trans_no not in (select deposit_trans_no from TB_PICKUP_TRANSACTION where trans_status='" & DepositTransactionData.TransactionStatus.Success & "') "

    '                Dim p(2) As SqlClient.SqlParameter
    '                p(0) = KioskDB.SetBigInt("@_LOCKER_ID", Convert.ToInt64(dr("id")))
    '                p(1) = KioskDB.SetBigInt("@_KIOSK_ID", KioskData.KioskID)

    '                Dim dDt As DataTable = KioskDB.ExecuteTable(sql)
    '                If dDt.Rows.Count = 0 Then
    '                    sql = "update ms_locker "
    '                    sql += " set open_close_status='C'"
    '                    sql += " , current_available = 'Y'"
    '                    sql += " , sync_to_server = 'N'"
    '                    sql += " where id=@_LOCKER_ID"

    '                    ReDim p(1)
    '                    p(0) = KioskDB.SetBigInt("@_LOCKER_ID", Convert.ToInt64(dr("id")))

    '                    Dim trans As New KioskTransactionDB
    '                    Dim ret As ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, trans.Trans, p)
    '                    If ret.IsSuccess = True Then
    '                        trans.CommitTransaction()
    '                    Else
    '                        trans.RollbackTransaction()
    '                    End If
    '                End If
    '                dDt.Dispose()
    '            Next
    '        End If
    '        dt.Dispose()
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Sub frmHome_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        CheckForIllegalCrossThreadCalls = False
        frmMain.pnlAds.Visible = True
        frmMain.pnlFooter.Visible = False
        frmMain.btnPointer.Visible = True
        frmMain.TimerCheckOpenClose.Enabled = True
        frmMain.CloseAllChildForm(Me)

        frmLoading.Show(frmMain)
        Application.DoEvents()

        'ต้อง Clear Transaction ทุกครั้งที่เข้าหน้า Home
        Customer = New DepositTransactionData(KioskData.KioskID)
        Collect = New CollectTransactionData(KioskData.KioskID)
        StaffConsole = New StaffConsoleLogonData(KioskData.KioskID)

        KioskConfig.SelectForm = KioskLockerForm.Home
        frmDepositSelectLocker.MdiParent = frmMain
        frmDepositSelectLocker.LoadLockerList()
        InsertLogTransactionActivity("", "", "", KioskLockerForm.Home, KioskLockerStep.Home_LoadLockerList, "", False)

        'Disable CashIn และ CoinIn เพื่อไม่ให้สามารถใส่เงินเข้าไปได้
        BanknoteIn.DisableDeviceCashIn()
        CoinIn.DisableDeviceCoinIn()

        SetLockerHomeData()


        KioskConfig.Language = Data.ConstantsData.KioskLanguage.Thai
        frmMain.ChangeFormMainLanguage()
        SetChildFormLanguage()
        SetLabelNotificationText()

        pnlDeposit.Enabled = True
        pnlPickup.Enabled = True

        frmLoading.Close()
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
            pnlDeposit.BackgroundImage = My.Resources.IconDepositFull
            RemoveHandler pnlDeposit.Click, AddressOf btnDeposit_Click
            RemoveHandler lblDeposit.Click, AddressOf btnDeposit_Click
            lblDeposit.Enabled = False

            lblLabelNotification.Width = pnlDeposit.Width
            lblLabelNotification.Left = pnlDeposit.Left
            lblLabelNotification.Text = GetNotificationText(1)
            lblLabelNotification.Visible = True
            IsStorageFull = True
            Application.DoEvents()
        End If
        LockerList.DefaultView.RowFilter = ""

        If IsStorageFull = False Then

            Dim dvDt As DataTable = GetStatusAllDeviceDT()
            If dvDt.Rows.Count > 0 Then
                'แสดง Status ของเครื่องอ่่านบัตรประชาชนและ Passport
                dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.IDCardPassportScanner & " and ms_device_status_id<>1"
                If dvDt.DefaultView.Count > 0 Then
                    lblLabelNotification.Text = GetNotificationText(6)
                    pnlDeposit.BackgroundImage = My.Resources.IconDepositFull
                    RemoveHandler pnlDeposit.Click, AddressOf btnDeposit_Click
                    RemoveHandler lblDeposit.Click, AddressOf btnDeposit_Click
                    lblDeposit.Enabled = False
                    lblLabelNotification.Visible = True
                End If
                dvDt.DefaultView.RowFilter = ""




                'แสดง Notification เมื่อเหรียญ5หมด
                dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.CoinOut_5 & " and stock_status='Critical'"
                If dvDt.DefaultView.Count > 0 Then
                    lblLabelNotification.Text = GetNotificationText(2)
                    lblLabelNotification.Visible = True
                End If
                dvDt.DefaultView.RowFilter = ""

                'แสดง Notification เมื่อแบงค์ 20 หมด
                dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.BankNoteOut_20 & " and stock_status='Critical'"
                If dvDt.DefaultView.Count > 0 Then
                    lblLabelNotification.Text = GetNotificationText(3)
                    lblLabelNotification.Visible = True
                End If
                dvDt.DefaultView.RowFilter = ""

                'แสดง Notification เมื่อแบงค์ 100 หมด
                dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.BankNoteOut_100 & " and stock_status='Critical'"
                If dvDt.DefaultView.Count > 0 Then
                    lblLabelNotification.Text = GetNotificationText(4)
                    lblLabelNotification.Visible = True
                End If
                dvDt.DefaultView.RowFilter = ""

                'แสดง Notification เมื่อแบงค์ 20 และ แบงค์ 100 หมดพร้อมกัน
                dvDt.DefaultView.RowFilter = " (device_id=" & DeviceID.BankNoteOut_20 & " and stock_status='Critical') or (device_id=" & DeviceID.BankNoteOut_100 & " and stock_status='Critical')"
                If dvDt.DefaultView.Count = 2 Then
                    lblLabelNotification.Text = GetNotificationText(7)
                    lblLabelNotification.Visible = True
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
    Private Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles pnlDeposit.Click, lblDeposit.Click
        If LockerList.Rows.Count = 0 Then
            InsertErrorLog("Locker Information not found", 0, 0, 0, KioskConfig.SelectForm, KioskLockerStep.Home_ClickDeposit)
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", True)
            ShowFormError("Out of service", "Locker Information not found", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Home_ClickDeposit, True)
            Exit Sub
        End If

        'Create New Deposit Service Transaction
        Dim ret As ExecuteDataInfo = CreateNewDepositTransaction()
        If ret.IsSuccess = True Then
            InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskLockerForm.Home, KioskLockerStep.Home_ClickDeposit, "", False)
            frmDepositSelectLocker.Show()
            frmMain.btnPointer.Visible = False
            frmMain.TimerCheckOpenClose.Enabled = False
            Me.Close()
            'frmDepositSelectLocker.BringToFront()
            Application.DoEvents()
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", False)
        Else
            InsertErrorLog(ret.ErrorMessage, 0, 0, 0, KioskLockerForm.Home, KioskLockerStep.Home_ClickDeposit)
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", True)
            ShowDialogErrorMessage("Cannot create transaction")
        End If
    End Sub


#End Region

#Region "Pickup"
    Private Sub btnPickup_Click(sender As Object, e As EventArgs) Handles pnlPickup.Click, lblPickup.Click
        Dim ret As ExecuteDataInfo = CreateNewPickupTransaction()
        InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskLockerForm.Home, KioskLockerStep.Home_ClickPickup, "เริ่มทำรายการรับคืน", False)
        If ret.IsSuccess = True Then
            'Dim f As New frmCollectSelectDocument
            frmCollectSelectDocument.MdiParent = frmMain
            frmCollectSelectDocument.Show()
            frmMain.btnPointer.Visible = False
            frmMain.TimerCheckOpenClose.Enabled = False
            Me.Close()
            Application.DoEvents()
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", False)
        Else
            InsertErrorLog(ret.ErrorMessage, 0, 0, 0, KioskLockerForm.Home, KioskLockerStep.Home_ClickPickup)
            SendKioskAlarm("KIOSK_OUT_OF_SERVICE", False)
            ShowDialogErrorMessage("Cannot create transaction")
        End If
    End Sub

#End Region
End Class