Imports AxWMPLib

Public Class frmScreenServer
    Private Sub frmScreenServer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub frmScreenServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VDO.settings.setMode("loop", True)
        VDO.URL = Application.StartupPath & "/VDO.avi"
        VDO.uiMode = "none"
        VDO.stretchToFit = True
        VDO.Ctlcontrols.play()
        TimerSync.Enabled = True
    End Sub

    Private Sub VDO_ClickEvent(sender As Object, e As _WMPOCXEvents_ClickEvent) Handles VDO.ClickEvent
        VDO.URL = ""
        Me.Close()
    End Sub

    Private Sub TimerSync_Tick(sender As Object, e As EventArgs) Handles TimerSync.Tick
        TimerSync.Enabled = False
        Try
            'Sycn Job Kiosk
            Dim WS As New DataSync
            WS.RunSyncByKoisk(KioskData.KioskID, getConnectionString)
        Catch ex As Exception : End Try
    End Sub
End Class