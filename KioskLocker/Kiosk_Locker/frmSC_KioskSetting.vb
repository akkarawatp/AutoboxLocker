Imports System.Net.NetworkInformation
Imports MiniboxLocker.Data.KioskConfigData
'Imports MiniboxLocker.ServiceTransactionData
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Imports System.Management
Imports MiniboxLocker.Data

Public Class frmSC_KioskSetting
    Private Sub frmSC_KioskSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleKioskSetting
        'frmMain.lblSCHeader.Visible = False
    End Sub

    Private Sub frmSC_KioskSetting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmSC_Main.lblTitle.Text = "KIOSK SETTINGS"
        Application.DoEvents()
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleKioskSetting_OpenForm, "", False)

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleKioskSetting_SetKioskSetting, "", False)
        BindDDLNetworkDevice()

        txtKioskID.Text = KioskData.KioskID
        chkLoginSSO.Checked = KioskConfig.IsLoginSSO
        If KioskConfig.KioskOpen24Hours = True Then
            chkKioskOpen24.Checked = True
            pbCheckOpen24.BackgroundImage = My.Resources.imgCheckboxCheck
            txtOpenTimeH.Text = "00"
            txtOpenTimeM.Text = "00"
            txtCloseTimeH.Text = "00"
            txtCloseTimeM.Text = "00"

            txtOpenTimeH.Enabled = False
            txtOpenTimeM.Enabled = False
            txtCloseTimeH.Enabled = False
            txtCloseTimeM.Enabled = False
        Else
            chkKioskOpen24.Checked = False
            pbCheckOpen24.BackgroundImage = My.Resources.imgCheckboxUncheck
            txtOpenTimeH.Text = KioskConfig.KioskOpenTime.Split(":")(0)
            txtOpenTimeM.Text = KioskConfig.KioskOpenTime.Split(":")(1)
            txtCloseTimeH.Text = KioskConfig.KioskCloseTime.Split(":")(0)
            txtCloseTimeM.Text = KioskConfig.KioskCloseTime.Split(":")(1)

            txtOpenTimeH.Enabled = True
            txtOpenTimeM.Enabled = True
            txtCloseTimeH.Enabled = True
            txtCloseTimeM.Enabled = True
        End If

        txtScreenServer.Text = KioskConfig.ScreenSaverSec
        txtTimeOut.Text = KioskConfig.TimeOutSec
        txtMessage.Text = KioskConfig.ShowMsgSec
        txtExtend.Text = KioskConfig.PaymentExtendSec
        txtPincodeLenght.Text = KioskConfig.PincodeLen
        txtSyncMasterInterval.Text = KioskConfig.SyncMasterInterval
        txtSyncTransInterval.Text = KioskConfig.SyncTransInterval
        txtSyncLogInterval.Text = KioskConfig.SyncLogInterval
        txtContactCenter.Text = KioskConfig.ContactCenterTelno

        Dim SleepTime() As String = KioskConfig.SleepTime.Split(":")
        If SleepTime.Length = 2 Then
            txtSleepTimeH.Text = SleepTime(0)
            txtSleepTimeM.Text = SleepTime(1)
            txtSleepDuration.Text = KioskConfig.SleepDuration
        End If

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleKioskSetting_CheckAuthorize, "", False)
        SetStaffConsoleAuthorize()
        frmLoading.Close()
    End Sub

    Private Sub SetStaffConsoleAuthorize()
        If StaffConsole.AuthorizeInfo.Rows.Count > 0 Then
            AppScreenList.DefaultView.RowFilter = "id='" & Convert.ToInt16(KioskConfig.SelectForm) & "'"
            If AppScreenList.DefaultView.Count > 0 Then
                chkLoginSSO.Enabled = False
                txtOpenTimeH.Enabled = False
                txtOpenTimeM.Enabled = False
                txtCloseTimeH.Enabled = False
                txtCloseTimeM.Enabled = False
                chkKioskOpen24.Enabled = False
                txtScreenServer.Enabled = False
                txtTimeOut.Enabled = False
                txtMessage.Enabled = False
                txtExtend.Enabled = False
                txtSyncMasterInterval.Enabled = False
                txtSyncTransInterval.Enabled = False
                txtSyncLogInterval.Enabled = False
                btnSave.Visible = False

                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=18 and authorization_name='Edit'"
                If StaffConsole.AuthorizeInfo.DefaultView.Count > 0 Then
                    chkLoginSSO.Enabled = True
                    chkKioskOpen24.Enabled = True
                    If chkKioskOpen24.Checked = False Then
                        txtOpenTimeH.Enabled = True
                        txtOpenTimeM.Enabled = True
                        txtCloseTimeH.Enabled = True
                        txtCloseTimeM.Enabled = True
                    End If

                    txtScreenServer.Enabled = True
                    txtTimeOut.Enabled = True
                    txtMessage.Enabled = True
                    txtExtend.Enabled = True
                    txtSyncMasterInterval.Enabled = True
                    txtSyncTransInterval.Enabled = True
                    txtSyncLogInterval.Enabled = True
                    btnSave.Visible = True
                End If
                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""
            End If
            AppScreenList.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub BindDDLNetworkDevice()
        Dim dt As New DataTable
        Dim adapters() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        If adapters.Length > 0 Then
            For Each adp As NetworkInterface In adapters
                cbNetworkDevice.Items.Add(adp.Description)
            Next
        End If

        Dim ini As New Org.Mentalis.Files.IniReader(INIFileName)
        ini.Section = "Setting"
        cbNetworkDevice.SelectedIndex = cbNetworkDevice.FindStringExact(ini.ReadString("CardLanDesc"))
        ini = Nothing

        'Network Information
        SetNetworkInformation()

    End Sub

    Private Sub SetNetworkInformation()
        txtIPAddress.Text = ""
        txtMacAddress.Text = ""

        Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo As ManagementObject In moc
            If CStr(mo("Description")).Trim = cbNetworkDevice.Text Then
                If mo("IPEnabled") = True Then
                    txtIPAddress.Text = mo("IPAddress")(0)
                    txtMacAddress.Text = mo("MacAddress").ToString().Replace(":", "-")
                Else
                    InsertErrorLogSC(StaffConsole.Username, "Cannot found Network Device " + cbNetworkDevice.Text, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                End If
            End If
            mo.Dispose()
        Next
    End Sub


    Private Sub lblCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmLoading.Show(frmSC_Main)
        Application.DoEvents()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleKioskSetting_ClickCancel, "", False)
        Me.Close()
        frmSC_StockAndHardware.MdiParent = frmSC_Main
        frmSC_StockAndHardware.Show()
    End Sub

    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleKioskSetting_ClickSave, "", False)

        If chkKioskOpen24.Checked = False Then
            If txtOpenTimeH.Text.Trim = "" Then
                ShowDialogErrorMessageSC("Please enter Open Time")
                txtOpenTimeH.Focus()
                Exit Sub
            End If
            If txtOpenTimeM.Text.Trim = "" Then
                ShowDialogErrorMessageSC("Please enter Open Time")
                txtOpenTimeM.Focus()
                Exit Sub
            End If
            If txtCloseTimeH.Text.Trim = "" Then
                ShowDialogErrorMessageSC("Please enter Open Time")
                txtCloseTimeH.Focus()
                Exit Sub
            End If
            If txtCloseTimeM.Text.Trim = "" Then
                ShowDialogErrorMessageSC("Please enter Open Time")
                txtCloseTimeM.Focus()
                Exit Sub
            End If
        End If

        If txtKioskID.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Kiosk ID")
            Exit Sub
        End If
        If cbNetworkDevice.Text = "" Then
            ShowDialogErrorMessageSC("Please select Network Device")
            Exit Sub
        End If
        If txtIPAddress.Text = "" Then
            ShowDialogErrorMessageSC("Please enter IP Address")
            Exit Sub
        End If
        If txtMacAddress.Text = "" Then
            ShowDialogErrorMessageSC("Please enger Mac Address")
            Exit Sub
        End If

        If txtScreenServer.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Screen Server")
            Exit Sub
        End If
        If txtTimeOut.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Kiosk Time Out")
            Exit Sub
        End If
        If txtMessage.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Kiosk Message")
            Exit Sub
        End If
        If txtExtend.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Payment Extend")
            Exit Sub
        End If
        If txtPincodeLenght.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Pin Code Lenght")
            Exit Sub
        End If
        If txtSyncMasterInterval.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Sync Master Interval Minute")
            Exit Sub
        End If
        If txtSyncTransInterval.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Sync Transaction Interval Minute")
            Exit Sub
        End If
        If txtSyncLogInterval.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Sync Log Interval Minute")
            Exit Sub
        End If
        If txtContactCenter.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Contact Center")
            Exit Sub
        End If

        If txtSleepTimeH.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Sleep Time")
            txtSleepTimeH.Focus()
            Exit Sub
        End If
        If txtSleepTimeM.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Sleep Time")
            txtSleepTimeM.Focus()
            Exit Sub
        End If
        If txtSleepDuration.Text = "" Then
            ShowDialogErrorMessageSC("Please enter Sleep Duration")
            txtSleepDuration.Focus()
            Exit Sub
        End If

        Try
            frmLoading.Show(frmSC_Main)
            Application.DoEvents()

            Dim ini As New IniReader(INIFileName)
            ini.Section = "Setting"
            ini.Write("CardLanDesc", cbNetworkDevice.Text)
            ini = Nothing

            Dim lnq As New CfKioskSysconfigKioskLinqDB
            lnq.ChkDataByMS_KIOSK_ID(KioskData.KioskID, Nothing)
            If lnq.ID > 0 Then
                If chkKioskOpen24.Checked = False Then
                    lnq.KIOSK_OPEN24 = "N"
                    lnq.KIOSK_OPEN_TIME = txtOpenTimeH.Text.PadLeft(2, "0") & ":" & txtOpenTimeM.Text.PadLeft(2, "0") & "-" & txtCloseTimeH.Text.PadLeft(2, "0") & ":" & txtCloseTimeM.Text.PadLeft(2, "0")
                Else
                    lnq.KIOSK_OPEN24 = "Y"
                    lnq.KIOSK_OPEN_TIME = "00:00-00:00"
                End If

                lnq.LOGIN_SSO = IIf(chkLoginSSO.Checked = True, "Y", "N")
                lnq.SCREEN_SAVER_SEC = txtScreenServer.Text
                lnq.TIME_OUT_SEC = txtTimeOut.Text
                lnq.SHOW_MSG_SEC = txtMessage.Text
                lnq.PAYMENT_EXTEND_SEC = txtExtend.Text
                lnq.PINCODE_LEN = txtPincodeLenght.Text
                lnq.CONTACT_CENTER_TELNO = txtContactCenter.Text
                lnq.SLEEP_TIME = txtSleepTimeH.Text.PadLeft(2, "0") & ":" & txtSleepTimeM.Text.PadLeft(2, "0")
                lnq.SLEEP_DURATION = txtSleepDuration.Text
                lnq.INTERVAL_SYNC_MASTER_MIN = txtSyncMasterInterval.Text
                lnq.INTERVAL_SYNC_TRANSACTION_MIN = txtSyncTransInterval.Text
                lnq.INTERVAL_SYNC_LOG_MIN = txtSyncLogInterval.Text
                lnq.SYNC_TO_KIOSK = "Y"
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                Dim ret As ExecuteDataInfo = lnq.UpdateData(StaffConsole.Username, trans.Trans)
                If ret.IsSuccess = True Then
                    Dim kdLnq As New MsKioskDeviceKioskLinqDB
                    kdLnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(ConstantsData.DeviceID.NetworkConnection, txtKioskID.Text, Nothing)
                    If kdLnq.ID > 0 Then
                        kdLnq.DRIVER_NAME1 = cbNetworkDevice.Text
                        kdLnq.SYNC_TO_KIOSK = "Y"
                        kdLnq.SYNC_TO_SERVER = "N"

                        ret = kdLnq.UpdateData(StaffConsole.Username, trans.Trans)
                        If ret.IsSuccess = True Then

                            trans.CommitTransaction()

                            ShowDialogErrorMessageSC("Save Success")
                            Me.Close()
                            frmSC_StockAndHardware.MdiParent = frmSC_Main
                            frmSC_StockAndHardware.Show()
                        Else
                            frmLoading.Close()
                            trans.RollbackTransaction()

                            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleKioskSetting_ClickSave, ret.ErrorMessage, True)
                            ShowDialogErrorMessageSC(ret.ErrorMessage)
                        End If
                    End If
                    kdLnq = Nothing
                Else
                    frmLoading.Close()
                    trans.RollbackTransaction()
                    InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleKioskSetting_ClickSave, ret.ErrorMessage, True)
                    ShowDialogErrorMessageSC(ret.ErrorMessage)
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            frmLoading.Close()
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleKioskSetting_ClickSave, ex.Message & " " & ex.StackTrace, True)
            ShowDialogErrorMessageSC(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub cbNetworkDevice_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNetworkDevice.SelectionChangeCommitted
        If cbNetworkDevice.Text.Trim <> "" Then
            SetNetworkInformation()
        End If
    End Sub


    Private Sub txtOpenTimeFromH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOpenTimeH.KeyPress, txtCloseTimeH.KeyPress, txtCloseTimeH.KeyPress
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If txt.Text.Length = 0 Then
            Select Case e.KeyChar.ToString
                Case "0", "1", "2", vbBack
                Case Else
                    e.Handled = True
            End Select
        ElseIf txt.Text.Length = 1 Then
            If txt.Text.Trim = "2" Then
                Select Case e.KeyChar.ToString
                    Case "0", "1", "2", "3", vbBack
                    Case Else
                        e.Handled = True
                End Select
            Else
                Select Case e.KeyChar.ToString
                    Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", vbBack
                    Case Else
                        e.Handled = True
                End Select
            End If
        End If
    End Sub

    Private Sub txtOpenTimeFromM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOpenTimeM.KeyPress, txtCloseTimeM.KeyPress, txtSleepTimeM.KeyPress
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If txt.Text.Length = 0 Then
            Select Case e.KeyChar.ToString
                Case "0", "1", "2", "3", "4", "5", vbBack
                Case Else
                    e.Handled = True
            End Select
        ElseIf txt.Text.Length = 1 Then
            Select Case e.KeyChar.ToString
                Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", vbBack
                Case Else
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub txtOpenTimeFromH_LostFocus(sender As Object, e As EventArgs) Handles txtOpenTimeH.LostFocus, txtOpenTimeM.LostFocus, txtCloseTimeH.LostFocus, txtCloseTimeM.LostFocus, txtSleepTimeH.LostFocus, txtSleepTimeM.LostFocus
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If txt.Text.Length = 1 Then
            txt.Text = "0" & txt.Text
        End If
    End Sub

    Private Sub chkKioskOpen24_CheckedChanged(sender As Object, e As EventArgs) Handles chkKioskOpen24.CheckedChanged
        If chkKioskOpen24.Checked = True Then
            txtOpenTimeH.Text = "00"
            txtOpenTimeM.Text = "00"
            txtCloseTimeH.Text = "00"
            txtCloseTimeM.Text = "00"

            txtOpenTimeH.Enabled = False
            txtOpenTimeM.Enabled = False
            txtCloseTimeH.Enabled = False
            txtCloseTimeM.Enabled = False
        Else
            txtOpenTimeH.Text = KioskConfig.KioskOpenTime.Split(":")(0)
            txtOpenTimeM.Text = KioskConfig.KioskOpenTime.Split(":")(1)
            txtCloseTimeH.Text = KioskConfig.KioskCloseTime.Split(":")(0)
            txtCloseTimeM.Text = KioskConfig.KioskCloseTime.Split(":")(1)

            txtOpenTimeH.Enabled = True
            txtOpenTimeM.Enabled = True
            txtCloseTimeH.Enabled = True
            txtCloseTimeM.Enabled = True
        End If
    End Sub

    Private Sub pbCheckOpen24_Click(sender As Object, e As EventArgs) Handles pbCheckOpen24.Click
        If chkKioskOpen24.Checked = True Then
            pbCheckOpen24.BackgroundImage = My.Resources.imgCheckboxUncheck
            chkKioskOpen24.Checked = False
        Else
            pbCheckOpen24.BackgroundImage = My.Resources.imgCheckboxCheck
            chkKioskOpen24.Checked = True
        End If

        Application.DoEvents()
    End Sub
End Class