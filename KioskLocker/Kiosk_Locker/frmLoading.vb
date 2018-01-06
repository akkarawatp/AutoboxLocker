Public Class frmLoading
    Private Sub frmLoading_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        'Me.Height = 997
        Application.DoEvents()
    End Sub
End Class