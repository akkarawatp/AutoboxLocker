Public Class frmDialog_OK

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles lblOK.Click, btnOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class