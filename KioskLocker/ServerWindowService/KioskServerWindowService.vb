
Imports Engine.LogFileENG
'Imports Org.Mentalis.Files
Imports System.Windows.Forms

Public Class KioskServerWindowService

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        tmUpdateKioskMonitorInfo = New System.Timers.Timer
        tmUpdateKioskMonitorInfo.Interval = 60000
        AddHandler tmUpdateKioskMonitorInfo.Elapsed, AddressOf tmUpdateKioskMonitorInfo_Tick
        tmUpdateKioskMonitorInfo.Start()
        tmUpdateKioskMonitorInfo.Enabled = True

        tmUpdateLocationPromotion = New System.Timers.Timer
        tmUpdateLocationPromotion.Interval = 60000
        AddHandler tmUpdateLocationPromotion.Elapsed, AddressOf tmUpdateLocationPromotion_Tick
        tmUpdateLocationPromotion.Start()
        tmUpdateLocationPromotion.Enabled = True
    End Sub

    Dim tmUpdateLocationPromotion As System.Timers.Timer
    Private Sub tmUpdateLocationPromotion_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        tmUpdateLocationPromotion.Enabled = False
        Try
            CreateHartbeat("tmUpdateLocationPromotion")
            Engine.SyncMasterDataENG.SyncLocationPromotion()
        Catch ex As Exception

        End Try

        tmUpdateLocationPromotion.Enabled = True
    End Sub


    Dim tmUpdateKioskMonitorInfo As System.Timers.Timer
    Private Sub tmUpdateKioskMonitorInfo_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        tmUpdateKioskMonitorInfo.Enabled = False
        Try
            CreateHartbeat("tmUpdateKioskMonitorInfo")
            ServerUpdateMonitorENG.UpdateKioskOnlineStatus()
        Catch ex As Exception

        End Try

        tmUpdateKioskMonitorInfo.Enabled = True
    End Sub



    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

End Class
