Imports System.Data.SqlClient
Imports AutoboxLocker.Data
Imports AutoboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Public Class frmCollectSelectDocument

    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Dim TimeOutCheckTime As DateTime = DateTime.Now

    Private Sub frmPickupSelectDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        Me.WindowState = FormWindowState.Maximized

        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.CollectSelectDocument
        'SetChildFormLanguage()
        SetLabelNotificationText()
    End Sub

    Private Sub frmPickupSelectDocument_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = True
        Application.DoEvents()

        InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupSelectDoc_OpenForm, "", False)
    End Sub

    Private Sub lblQRCode_Click(sender As Object, e As EventArgs) Handles lblQRCode.Click, pnlQRCode.Click
        InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskLockerForm.Home, KioskLockerStep.PickupSelectDoc_ClickQRCode, "", False)

        Dim f As New frmCollectScanQRCode
        f.MdiParent = frmMain
        f.Show()
        frmMain.btnPointer.Visible = False
        frmMain.TimerCheckOpenClose.Enabled = False
        Me.Close()
        Application.DoEvents()
        SendKioskAlarm("LOCKER_OUT_OF_SERVICE", False)
    End Sub

    Private Sub lblCaptionPinCode_Click(sender As Object, e As EventArgs) Handles lblCaptionPinCode.Click, pnlPinCode.Click, lblImagePinCode.Click
        InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupSelectDoc_ClickPinCode, "", False)
        Collect.LostQRCode = "Y"
        Dim ret As ExecuteDataInfo = UpdateCollectTransaction(Collect)
        If ret.IsSuccess = True Then
            frmLoading.Show(frmMain)
            Application.DoEvents()

            frmCollectByPINCode.MdiParent = frmMain
            frmCollectByPINCode.Show()
            'frmDepositScanPassport.MdiParent = frmMain
            'frmDepositScanPassport.Show()
            'frmDepositScanPassport.lblTitle.Visible = True
            'frmDepositScanPassport.StartInitialDevice()
            Application.DoEvents()

            frmLoading.Close()
            Me.Close()
        Else
            InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupSelectDoc_ClickPinCode, " Update Pickup Data Fail", True)
        End If
    End Sub

    Private Sub TimerTimeOut_Tick(sender As Object, e As EventArgs) Handles TimerTimeOut.Tick
        'TimeOut = TimeOut - 1
        Application.DoEvents()
        'lblTimeOut.Text = TimeOut
        If TimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
            InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupSelectDoc_Timeout, "", False)
            TimerTimeOut.Enabled = False
            UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.TimeOut, KioskLockerStep.PickupSelectDoc_Timeout)

            frmMain.CloseAllChildForm()
            Dim f As New frmHome
            f.MdiParent = frmMain
            f.Show()
        End If
    End Sub

    Public Sub SetLabelNotificationText()
        'แสดง Status ของเครื่องอ่าน QR Code
        Dim dvDt As DataTable = GetStatusAllDeviceDT()
        If dvDt.Rows.Count > 0 Then
            dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.QRCodeReader & " and ms_device_status_id<>1"
            If dvDt.DefaultView.Count > 0 Then
                'lblQRCodeNotification.Text = GetNotificationText(5)
                pnlQRCode.BackgroundImage = My.Resources.IconPickupQRCodeFail
                RemoveHandler pnlQRCode.Click, AddressOf lblQRCode_Click
                RemoveHandler lblQRCode.Click, AddressOf lblQRCode_Click
                lblQRCode.Enabled = False
                'lblQRCodeNotification.Visible = True
            End If
            dvDt.DefaultView.RowFilter = ""

            'dvDt.DefaultView.RowFilter = "device_id=" & DeviceID.IDCardPassportScanner & " and ms_device_status_id<>1"
            'If dvDt.DefaultView.Count > 0 Then
            '    ' lblLabelIDCardNotification.Text = GetNotificationText(6)
            '    pnlIDCard.BackgroundImage = My.Resources.IconPickupIDCardFail
            '    RemoveHandler pnlIDCard.Click, AddressOf lblIDCard_Click
            '    RemoveHandler lblIDCard.Click, AddressOf lblIDCard_Click
            '    RemoveHandler lblPassport.Click, AddressOf lblIDCard_Click
            '    lblIDCard.Enabled = False
            '    lblPassport.Enabled = False
            '    ' lblLabelIDCardNotification.Visible = True
            'End If
            'dvDt.DefaultView.RowFilter = ""

            Application.DoEvents()
        End If
        dvDt.Dispose()
    End Sub
End Class