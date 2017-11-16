Public Class frmDialog_TimeOut

    Dim CountTime As Int32 = KioskConfig.TimeOutSec
    Private Sub frmDialog_TimeOut_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        pnlDialog.BackColor = bgColor
        lblCount.Text = CountTime
    End Sub

    Private Sub lblYes_Click(sender As Object, e As EventArgs) Handles lblYes.Click, btnYes.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub lblNo_Click(sender As Object, e As EventArgs) Handles lblNo.Click, btnNo.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub TimerCount_Tick(sender As Object, e As EventArgs) Handles TimerCount.Tick
        CountTime = CountTime - 1
        Application.DoEvents()
        lblCount.Text = CountTime
        If CountTime = 0 Then
            lblNo_Click(Nothing, Nothing)
        End If
    End Sub

End Class