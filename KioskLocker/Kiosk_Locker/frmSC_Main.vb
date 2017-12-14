
Imports MiniboxLocker.Data.KioskConfigData
Public Class frmSC_Main
    Private Sub frmSC_Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Application.DoEvents()
        frmSC_StockAndHardware.MdiParent = Me
        frmSC_StockAndHardware.StartPosition = FormStartPosition.WindowsDefaultLocation
        frmSC_StockAndHardware.WindowState = FormWindowState.Normal
        frmSC_StockAndHardware.Show()


    End Sub

    Private Sub btnExitProgram_Click(sender As Object, e As EventArgs) Handles btnExitProgram.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleStockAndHardware_ClickExitProgram, "", False)
        WebCam.Dispose()
        Application.Exit()
    End Sub



    'Sub CloseAllChildForm(ShowFrm As Form)
    '    For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
    '        If My.Application.OpenForms.Item(i) IsNot Me Then
    '            If My.Application.OpenForms.Item(i) IsNot ShowFrm Then
    '                My.Application.OpenForms.Item(i).Close()
    '            End If
    '        End If
    '    Next i
    'End Sub
End Class