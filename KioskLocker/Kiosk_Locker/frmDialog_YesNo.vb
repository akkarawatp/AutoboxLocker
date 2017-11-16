Public Class frmDialog_YesNo

    Private Sub frmDialog_YesNo_Load(sender As Object, e As EventArgs) Handles Me.Load
        pnlDialog.BackColor = bgColor
    End Sub


    Private Sub btnYes_Paint(sender As Object, e As EventArgs) Handles btnYes.Click, lblYes.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnNo_Paint(sender As Object, e As EventArgs) Handles btnNo.Click, lblNo.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

End Class