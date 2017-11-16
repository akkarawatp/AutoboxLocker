Imports Engine
Public Class TestFunctionWindowService
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Engine.LogFileENG.TestNLog()

        'KioskInfoENG.SetKioskInfo()

        'Engine.SyncMasterDataENG.SyncMasterKioskSysconfig(1)
        'Engine.SyncMasterDataENG.SyncMasterKioskSysconfig(23)
        'Engine.SyncMasterDataENG.SyncMasterCabinet(23)
        'Engine.SyncMasterDataENG.SyncMasterKioskDevice(30)
        'Engine.SyncMasterDataENG.SyncMasterKioskLocker(23)

        'Engine.SyncMasterDataENG.SyncAllKioskMaster(2)
        'Engine.SyncMasterDataENG.SyncMasterPromotion(23)
        'Engine.SyncMasterDataENG.UpdateKioskPromotionExpired(1)

        'Engine.SyncMasterDataENG.TestTraceFrame("123")

        'Engine.SyncTransactionDataENG.SyncAllTransaction(1)
        Engine.SyncTransactionDataENG.SyncServiceTransaction(34)
        'Engine.SyncTransactionDataENG.SyncPickupTransaction(23)
        'Engine.SyncTransactionDataENG.SyncStaffConsoleTransaction(23)
        'Engine.SyncTransactionDataENG.SyncDeleteCompleteTransaction(23)
        'Engine.SyncTransactionDataENG.ConvertServiceTransationCustImage(34)
        Engine.SyncTransactionDataENG.SyncServiceTransactionCustImage(34)

        'Engine.SyncLogDataENG.SyncLogTransactionActivity(23)
        'Engine.SyncLogDataENG.SyncFillMoneyData(23)
        'Engine.SyncLogDataENG.SyncLogErrorData(23)
        'Engine.SyncLogDataENG.SyncLogKioskAgentData(23)
        'Engine.SyncLogDataENG.SyncAllLog(2)
        'Engine.SyncLogDataENG.SendAlarmData(23)

        'Engine.SyncMasterDataENG.PullMasterAppScreen(23)
        'Engine.SyncMasterDataENG.PullMasterAppStep(23)
        'Engine.SyncMasterDataENG.PullMasterCabinetModel(2)
        'Engine.SyncMasterDataENG.PullMasterDeviceType(2)
        'Engine.SyncMasterDataENG.PullMasterDeviceStatus(23)
        'Engine.SyncMasterDataENG.PullMasterDevice(2)
        'Engine.SyncMasterDataENG.PullMasterKioskScreenControl(23)
        'Engine.SyncMasterDataENG.PullMasterKioskNotificationText(23)
        'Engine.SyncMasterDataENG.PullMasterMonitoringAlarm(2)
        'Engine.SyncMasterDataENG.PullMasterServiceRate(2)


    End Sub
End Class