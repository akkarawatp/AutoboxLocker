Imports System.Data.SqlClient
Imports MiniboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB
Public Class frmDepositSetPINCode
    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Dim TimeOutCheckTime As DateTime = DateTime.Now

    Const DefaultNotictText As String = ""

    Private Sub frmDepositSetPINCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        KioskConfig.SelectForm = KioskLockerForm.DepositSetPinCode
    End Sub
    Private Sub frmDepositSetPINCode_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmMain.CloseAllChildForm(Me)
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = True
        lblLabelNotification.Text = DefaultNotictText

        Application.DoEvents()
        InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_OpenForm, "", False)
        TimeOutCheckTime = DateTime.Now
        TimerTimeOut.Enabled = True

        frmLoading.Close()
    End Sub


    Private Sub TimerTimeOut_Tick(sender As Object, e As EventArgs) Handles TimerTimeOut.Tick
        If KioskConfig.SelectForm = KioskLockerForm.DepositSetPinCode Then

            'lblTimeOut.Text = TimeOut
            If TimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
                frmLoading.Show(frmMain)
                Application.DoEvents()

                TimerTimeOut.Enabled = False
                TimerTimeOut.Stop()

                UpdateDepositStatus(Deposit.DepositTransactionID, DepositTransactionData.TransactionStatus.TimeOut, KioskLockerStep.DepositSetPinCode_Timeout)
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_Timeout, "", False)

                frmMain.CloseAllChildForm(frmLoading)
                Dim f As New frmHome
                f.MdiParent = frmMain
                f.Show()
            End If
        End If
    End Sub

    Private Function CheckNotUserPincode() As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New KioskLinqDB.TABLE.MsNotUsePincodeKioskLinqDB
            lnq.ChkDataByNOT_USE_PINCODE(TmpPinCode, Nothing)
            If lnq.ID > 0 Then
                ret = True
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Private Sub ClearAndConfirmPin()
        If Deposit.PinCode = "" Then
            If CheckNotUserPincode() = False Then
                Deposit.PinCode = TmpPinCode
                TmpPinCode = ""
                txtPincode1.Text = ""
                txtPincode2.Text = ""
                txtPincode3.Text = ""
                txtPincode4.Text = ""
                txtPincode5.Text = ""
                txtPincode6.Text = ""
                lblLabelNotification.Text = "ยืนยันรหัสผ่าน / Confirm Password"
            Else
                lblLabelNotification.Text = DefaultNotictText
                btnClear_Click(Nothing, Nothing)

                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_ConfirmPinCodeFail, "รหัสผ่านห้ามใช้งาน", False)
                ShowDialogErrorMessage(String.Format("รหัสผ่านไม่ถูกต้อง กรุณากำหนดรหัสใหม่" & vbNewLine & "Incorrect password. Please enter new password", KioskConfig.PincodeLen))
            End If
        Else
            If Deposit.PinCode = TmpPinCode Then
                frmLoading.Show(frmMain)
                Application.DoEvents()
                'ไปหน้าจอชำระเงินโลด
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_ConfirmPinCodeSuccess, "", False)
                Me.Close()

                frmDepositPayment.MdiParent = frmMain
                frmDepositPayment.Show()
            Else
                'ยืนยันรหัสส่วนตัวไม่ตรงกัน ให้เริ่มขั้นตอนใหม่

                lblLabelNotification.Text = DefaultNotictText
                btnClear_Click(Nothing, Nothing)

                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_ConfirmPinCodeFail, "", False)
                ShowDialogErrorMessage(String.Format("คุณยืนยันรหัสส่วนตัวไม่ถูกต้อง กรุณากำหนดรหัสใหม่" & vbNewLine & "Incorrect password. Please enter new password", KioskConfig.PincodeLen))
            End If
        End If
        Application.DoEvents()
    End Sub

#Region "Fill in PIN CODE"

    Dim TmpPinCode As String = ""
    Private Sub InsertNumber(ByVal Num As Int16)
        If TmpPinCode.Length >= KioskConfig.PincodeLen Then Exit Sub

        TmpPinCode = TmpPinCode & Num
        TimeOutCheckTime = DateTime.Now

        If TmpPinCode.Length = 1 Then
            txtPincode1.Text = Num
        End If
        If TmpPinCode.Length = 2 Then
            txtPincode2.Text = Num
        End If
        If TmpPinCode.Length = 3 Then
            txtPincode3.Text = Num
        End If
        If TmpPinCode.Length = 4 Then
            txtPincode4.Text = Num
        End If
        If TmpPinCode.Length = 5 Then
            txtPincode5.Text = Num
        End If
        If TmpPinCode.Length = 6 Then
            txtPincode6.Text = Num
        End If
    End Sub
    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        InsertNumber(0)
    End Sub
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        InsertNumber(1)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        InsertNumber(2)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        InsertNumber(3)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        InsertNumber(4)
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        InsertNumber(5)
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        InsertNumber(6)
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        InsertNumber(7)
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        InsertNumber(8)
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        InsertNumber(9)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If TmpPinCode.Length <> KioskConfig.PincodeLen Then
            ShowDialogErrorMessage(String.Format("กรุณากำหนดรหัสส่วนตัว {0} หลัก", KioskConfig.PincodeLen))
            btnClear_Click(Nothing, Nothing)
            Exit Sub
        End If

        ClearAndConfirmPin()
        TimeOutCheckTime = DateTime.Now
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Deposit.PinCode = ""
        TmpPinCode = ""
        txtPincode1.Text = ""
        txtPincode2.Text = ""
        txtPincode3.Text = ""
        txtPincode4.Text = ""
        txtPincode5.Text = ""
        txtPincode6.Text = ""
        TimeOutCheckTime = DateTime.Now
    End Sub

    Private Sub btn_MouseDown(sender As Object, e As MouseEventArgs) Handles btn0.MouseDown, btn1.MouseDown, btn2.MouseDown, btn3.MouseDown, btn4.MouseDown, btn5.MouseDown, btn6.MouseDown, btn7.MouseDown, btn8.MouseDown, btn9.MouseDown
        Dim btn As PictureBox = sender
        btn.BackColor = Color.Gray
    End Sub

    Private Sub btn_MouseUp(sender As Object, e As MouseEventArgs) Handles btn0.MouseUp, btn1.MouseUp, btn2.MouseUp, btn3.MouseUp, btn4.MouseUp, btn5.MouseUp, btn6.MouseUp, btn7.MouseUp, btn8.MouseUp, btn9.MouseUp
        Dim btn As PictureBox = sender
        btn.BackColor = Color.Transparent
    End Sub
#End Region

End Class