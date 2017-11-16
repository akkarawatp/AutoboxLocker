Imports System.Reflection
Imports Engine
Imports Engine.LogFileENG

Public Class KioskSyncWindowService

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        ''### Current Class and Function name
        'Dim m As MethodBase = MethodBase.GetCurrentMethod()
        'Dim ThisClassName As String = m.ReflectedType.Name
        'Dim ThisFunctionName As String = m.Name
        KioskInfoENG.SetKioskInfo()

        CreateLogAgent(KioskInfoENG.KioskID, "Start KioskSyncWindowService")

        tmSyncMasterData = New System.Timers.Timer
        tmSyncMasterData.Interval = KioskInfoENG.SyncMasterMin * 60000
        AddHandler tmSyncMasterData.Elapsed, AddressOf tmSyncMasterData_Tick
        tmSyncMasterData.Start()
        tmSyncMasterData.Enabled = True

        'Interval ของการ Sync Service Rate ให้น้อยกว่าเวลา SyncMasterData 10 นาที
        Dim ServiceRateInterval As Integer = KioskInfoENG.SyncMasterMin - 10
        If ServiceRateInterval <= 10 Then
            ServiceRateInterval = 10
        End If
        tmSyncServiceRateData = New System.Timers.Timer
        tmSyncServiceRateData.Interval = ServiceRateInterval * 60000
        AddHandler tmSyncServiceRateData.Elapsed, AddressOf tmSyncServiceRateData_Tick
        tmSyncServiceRateData.Start()
        tmSyncServiceRateData.Enabled = True

        tmConvertCustImage = New System.Timers.Timer
        tmConvertCustImage.Interval = 60 * 1000
        AddHandler tmConvertCustImage.Elapsed, AddressOf tmConvertCustImage_Tick
        tmConvertCustImage.Start()
        tmConvertCustImage.Enabled = True

        tmSyncTransactionData = New System.Timers.Timer
        tmSyncTransactionData.Interval = KioskInfoENG.SyncTransactionMin * 60000
        AddHandler tmSyncTransactionData.Elapsed, AddressOf tmSyncTransactionData_Tick
        tmSyncTransactionData.Start()
        tmSyncTransactionData.Enabled = True


        tmSyncLogData = New System.Timers.Timer
        tmSyncLogData.Interval = KioskInfoENG.SyncLogMin * 60000
        AddHandler tmSyncLogData.Elapsed, AddressOf tmSyncLogData_Tick
        tmSyncLogData.Start()
        tmSyncLogData.Enabled = True

        tmSendAlarmData = New System.Timers.Timer
        tmSendAlarmData.Interval = 60000
        AddHandler tmSendAlarmData.Elapsed, AddressOf tmSendAlarmData_Tick
        tmSendAlarmData.Start()
        tmSendAlarmData.Enabled = True
    End Sub

    Private tmSendAlarmData As System.Timers.Timer
    Private Sub tmSendAlarmData_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        tmSendAlarmData.Enabled = False
        LogFileENG.CreateHartbeat("tmSendAlarmData")


        SyncLogDataENG.SendAlarmData(KioskInfoENG.KioskID)
        tmSendAlarmData.Enabled = True
    End Sub

    Private tmSyncLogData As System.Timers.Timer
    Private Sub tmSyncLogData_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        tmSyncLogData.Enabled = False
        LogFileENG.CreateHartbeat("tmSyncLogData")
        SyncLogDataENG.SyncAllLog(KioskInfoENG.KioskID)

        KioskInfoENG.SetKioskInfo()
        tmSyncLogData.Interval = KioskInfoENG.SyncLogMin * 60000
        tmSyncLogData.Enabled = True
    End Sub

    Private tmConvertCustImage As System.Timers.Timer
    Private Sub tmConvertCustImage_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        tmConvertCustImage.Enabled = False
        LogFileENG.CreateHartbeat("tmConvertCustImage")
        SyncTransactionDataENG.ConvertServiceTransationCustImage(KioskInfoENG.KioskID)
        tmConvertCustImage.Enabled = True
    End Sub

    Private tmSyncTransactionData As System.Timers.Timer
    Private Sub tmSyncTransactionData_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        tmSyncTransactionData.Enabled = False
        LogFileENG.CreateHartbeat("tmSyncTransactionData")
        SyncTransactionDataENG.SyncAllTransaction(KioskInfoENG.KioskID)

        KioskInfoENG.SetKioskInfo()
        tmSyncTransactionData.Interval = KioskInfoENG.SyncTransactionMin * 60000
        tmSyncTransactionData.Enabled = True
    End Sub


    Private tmSyncMasterData As System.Timers.Timer
    Private Sub tmSyncMasterData_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        ''### Current Class and Function name
        'Dim m As MethodBase = MethodBase.GetCurrentMethod()
        'Dim ThisClassName As String = m.ReflectedType.Name
        'Dim ThisFunctionName As String = m.Name

        tmSyncMasterData.Enabled = False
        LogFileENG.CreateHartbeat("tmSyncMasterData")
        SyncMasterDataENG.SyncAllKioskMaster(KioskInfoENG.KioskID)

        KioskInfoENG.SetKioskInfo()
        tmSyncMasterData.Interval = KioskInfoENG.SyncMasterMin * 60000
        tmSyncMasterData.Enabled = True
    End Sub

    Private tmSyncServiceRateData As System.Timers.Timer
    Private Sub tmSyncServiceRateData_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        ''### Current Class and Function name
        'Dim m As MethodBase = MethodBase.GetCurrentMethod()
        'Dim ThisClassName As String = m.ReflectedType.Name
        'Dim ThisFunctionName As String = m.Name

        Try
            'Sync ข้อมูลการเปลี่ยนแปลงราคาค่าบริการ
            'Service Rate, Promotion 
            tmSyncServiceRateData.Enabled = False
            LogFileENG.CreateHartbeat("tmSyncServiceRateData")
            SyncMasterDataENG.PullMasterServiceRate(KioskInfoENG.KioskID)
            SyncMasterDataENG.SyncMasterPromotion(KioskInfoENG.KioskID)
            SyncMasterDataENG.UpdateKioskPromotionExpired(KioskInfoENG.KioskID)

            KioskInfoENG.SetKioskInfo()
            'Interval ของการ Sync Service Rate ให้น้อยกว่าเวลา SyncMasterData 10 นาที
            Dim ServiceRateInterval As Integer = KioskInfoENG.SyncMasterMin - 10
            If ServiceRateInterval <= 10 Then
                ServiceRateInterval = 10
            End If

            tmSyncServiceRateData.Interval = ServiceRateInterval * 60000
            tmSyncServiceRateData.Enabled = True
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(KioskInfoENG.KioskID, ex.Message, ex.StackTrace)
        End Try

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.

    End Sub

End Class
