Imports AutoboxLocker.Data.KioskConfigData
Imports KioskLinqDB.TABLE
Public Class frmSC_FillPaper

    Dim Warning As Integer = 0
    Dim Critical As Integer = 0
    Dim Max As Integer = 0

    Private Sub frmSC_FillPaper_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleFillPaper
        'frmMain.lblSCHeader.Visible = False
    End Sub

    Private Sub frmSC_FillPaper_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmSC_Main.lblTitle.Text = "FILL PAPER"
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillPaper_OpenForm, "", False)
        txtValue.Focus()

        Dim lnq As New MsKioskDeviceKioskLinqDB
        lnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(Data.ConstantsData.DeviceID.Printer, KioskData.KioskID, Nothing)
        If lnq.ID > 0 Then
            txtValue.Text = lnq.CURRENT_QTY
            txtValue.SelectAll()

            Warning = lnq.WARNING_QTY
            Critical = lnq.CRITICAL_QTY
            Max = lnq.MAX_QTY
        End If
        lnq = Nothing

        txtMax.Text = Max
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillPaper_CheckAuthorize, "", False)
        SetStaffConsoleAuthorize()
    End Sub

    Private Sub SetStaffConsoleAuthorize()
        If StaffConsole.AuthorizeInfo.Rows.Count > 0 Then
            AppScreenList.DefaultView.RowFilter = "id='" & Convert.ToInt16(KioskConfig.SelectForm) & "'"
            If AppScreenList.DefaultView.Count > 0 Then
                txtValue.Enabled = False
                btnConfirm.Visible = False

                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=16 and authorization_name='Edit'"
                If StaffConsole.AuthorizeInfo.DefaultView.Count > 0 Then
                    txtValue.Enabled = True
                    btnConfirm.Visible = True
                End If
                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""
            End If
            AppScreenList.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub txtValue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValue.KeyPress
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        ElseIf Asc(e.KeyChar) = 13 Then
            lblConfirm_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub lblCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillPaper_ClickCancel, "", False)
        Me.Close()
        frmSC_StockAndHardware.MdiParent = frmSC_Main
        frmSC_StockAndHardware.Show()
    End Sub

    Private Sub lblConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillPaper_ClickConfirm, "", False)

        If txtValue.Text = "" Then
            ShowDialogErrorMessageSC("กรุณากรอกข้อมูลจำนวนครั้งที่พิมพ์")
            Exit Sub
        ElseIf CInt(txtValue.Text) > Max Then
            ShowDialogErrorMessageSC("กรอกข้อมูลจำนวนครั้งที่พิมพ์ เกินจำนวนเต็มที่กำหนด")
            Exit Sub
        End If

        UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.Printer, CInt(txtValue.Text), 0, True)
        ShowDialogErrorMessageSC("Fill Paper Success")
        Me.Close()
        frmSC_StockAndHardware.MdiParent = frmSC_Main
        frmSC_StockAndHardware.Show()
    End Sub


End Class