Public Class frmLockerError

    Private Sub frmLockerError_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.LockerError
    End Sub

    Private Sub frmLockerError_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        lblDetail.Focus()
        frmMain.pnlAds.Visible = True
        frmMain.pnlFooter.Visible = False

        'lblDetail.Top = (Me.Height / 2) - (Me.Top / 2)
        SetChildFormLanguage()
        Application.DoEvents()

    End Sub

End Class