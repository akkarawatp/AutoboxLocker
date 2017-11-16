Public Class frmLockerOutOfService
    Private Sub frmVW_OutOfService_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
    End Sub

    Private Sub frmVW_OutOfService_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        lbl1.Focus()
        'If CkeckAutoScrollBar() Then Me.AutoScroll = True
        frmMain.pnlHead.Visible = True
        frmMain.pnlAds.Visible = False
    End Sub

    Private Sub SetFont()
        'lbl1.Font = GetFont_DB_HelvethaicaAIS_X_55_Regular(60, FontStyle.Bold)
    End Sub

End Class