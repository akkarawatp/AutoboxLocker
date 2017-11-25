Imports System.Data.SqlClient
Imports AutoboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB
Public Class frmDepositSetPINCode
    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Dim TimeOutCheckTime As DateTime = DateTime.Now

    Const DefaultNotictText As String = "กรุณากำหนดรหัสส่วนตัว {0} หลักสำหรับรับคืนสัมภาระ"

    Private Sub frmDepositSetPINCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        KioskConfig.SelectForm = KioskLockerForm.DepositSetPinCode
    End Sub
    Private Sub frmDepositSetPINCode_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = True
        lblLabelNotification.Text = String.Format(DefaultNotictText, KioskConfig.PincodeLen)

        Application.DoEvents()
        InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_OpenForm, "", False)
        TimeOutCheckTime = DateTime.Now
        TimerTimeOut.Enabled = True

    End Sub


    Private Sub TimerTimeOut_Tick(sender As Object, e As EventArgs) Handles TimerTimeOut.Tick
        If KioskConfig.SelectForm = KioskLockerForm.DepositSetPinCode Then
            Application.DoEvents()
            'lblTimeOut.Text = TimeOut
            If TimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
                TimerTimeOut.Enabled = False
                TimerTimeOut.Stop()

                UpdateDepositStatus(Deposit.DepositTransactionID, DepositTransactionData.TransactionStatus.TimeOut, KioskLockerStep.DepositSetPinCode_Timeout)
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_Timeout, "", False)

                frmMain.CloseAllChildForm()
                Dim f As New frmHome
                f.MdiParent = frmMain
                f.Show()
            End If
        End If
    End Sub

    Private Sub ClearAndConfirmPin()
        If Deposit.PinCode = "" Then
            Deposit.PinCode = txtPinCode.Text
            txtPinCode.Text = ""
            lblLabelNotification.Text = "กรุณายืนยันรหัสส่วนตัว"
        Else
            If Deposit.PinCode = txtPinCode.Text Then
                'เช็ค PIN CODE ซ้ำ
                If CheckDuplicatePinCode(Deposit.PinCode) = False Then
                    frmLoading.Show(frmMain)

                    'ไปหน้าจอชำระเงินโลด
                    InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_ConfirmPinCodeSuccess, "", False)

                    frmDepositPayment.MdiParent = frmMain
                    frmDepositPayment.Show()
                    frmLoading.Close()
                    Application.DoEvents()

                    Me.Close()
                Else
                    TimeOutCheckTime = DateTime.Now
                    InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_ConfirmPinCodeFail, " รหัสส่วนตัวซ้ำ", False)
                    ShowDialogErrorMessage(String.Format("รหัสส่วนตัวซ้ำ กรุณากำหนดรหัสส่วนตัว {0} หลัก", KioskConfig.PincodeLen))

                    lblLabelNotification.Text = String.Format(DefaultNotictText, KioskConfig.PincodeLen)
                    Deposit.PinCode = ""
                    txtPinCode.Text = ""
                End If
            Else
                'ยืนยันรหัสส่วนตัวไม่ตรงกัน ให้เริ่มขั้นตอนใหม่
                TimeOutCheckTime = DateTime.Now

                lblLabelNotification.Text = String.Format(DefaultNotictText, KioskConfig.PincodeLen)
                Deposit.PinCode = ""
                txtPinCode.Text = ""

                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSetPinCode_ConfirmPinCodeFail, "", False)
                ShowDialogErrorMessage(String.Format("คุณยืนยันรหัสส่วนตัวไม่ถูกต้อง กรุณากำหนดรหัสส่วนตัว {0} หลัก", KioskConfig.PincodeLen))
            End If
        End If
        Application.DoEvents()
    End Sub

    Private Function CheckDuplicatePinCode(PinCode As String) As Boolean
        Dim ret As Boolean = False
        Try
            'ตรวจสอบว่า PIN CODE ที่กรอกมานั้น จะต้องไม่ซ้ำกับตู้อื่น ที่ไม่ว่าง
            Dim sql As String = "select t.id, t.trans_no "
            sql += " from TB_DEPOSIT_TRANSACTION t"
            sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
            sql += " inner join MS_CABINET c on c.id=l.ms_cabinet_id"
            sql += " where t.pin_code=@_PIN_CODE "
            sql += " and t.trans_status=@_TRANS_STATUS"
            sql += " and t.paid_time is not null "

            Dim p(2) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_PIN_CODE", PinCode)
            p(1) = KioskDB.SetText("@_TRANS_STATUS", Convert.ToInt16(DepositTransactionData.TransactionStatus.Success))

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                'กรณีพบข้อมูล ให้ตรวจสอบจะต้องไม่มีรายการรับคืนที่ Success แล้ว
                sql = "select top 1 id "
                sql += " from TB_PICKUP_TRANSACTION "
                sql += " where deposit_trans_no=@_DEPOSIT_TRANS_NO "
                sql += " and trans_status=@_PICKUP_TRANS_STATUS "

                ReDim p(2)
                p(0) = KioskDB.SetText("@_DEPOSIT_TRANS_NO", dt.Rows(0)("trans_no"))
                p(1) = KioskDB.SetText("@_PICKUP_TRANS_STATUS", Convert.ToInt16(CollectTransactionData.TransactionStatus.Success))

                Dim pDt As DataTable = KioskDB.ExecuteTable(sql, p)
                If pDt.Rows.Count > 0 Then
                    ret = False
                Else
                    ret = True
                End If
                pDt.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

#Region "Fill in PIN CODE"

    Private Sub InsertNumber(ByVal Num As Int16)
        txtPinCode.Text = txtPinCode.Text & Num
        TimeOutCheckTime = DateTime.Now

        If txtPinCode.Text.Length = KioskConfig.PincodeLen Then
            ClearAndConfirmPin()
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

    Private Sub btnBackSpace_Click(sender As Object, e As EventArgs) Handles btnBackSpace.Click
        If txtPinCode.Text <> "" Then
            txtPinCode.Text = txtPinCode.Text.Substring(0, txtPinCode.Text.Length - 1)
        End If

        TimeOutCheckTime = DateTime.Now
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtPinCode.Text = ""
        TimeOutCheckTime = DateTime.Now
    End Sub
#End Region

End Class