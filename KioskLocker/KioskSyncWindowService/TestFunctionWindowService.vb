Imports Engine
Public Class TestFunctionWindowService
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Engine.LogFileENG.TestNLog()

        KioskInfoENG.SetKioskInfo()

        'Engine.SyncMasterDataENG.SyncMasterKioskSysconfig(1)
        'Engine.SyncMasterDataENG.SyncMasterKioskSysconfig(23)
        'Engine.SyncMasterDataENG.SyncMasterCabinet(23)
        'Engine.SyncMasterDataENG.SyncMasterKioskDevice(30)
        'Engine.SyncMasterDataENG.SyncMasterKioskLocker(23)

        'Engine.SyncMasterDataENG.SyncAllKioskMaster(34)
        'Engine.SyncMasterDataENG.SyncMasterPromotion(23)
        'Engine.SyncMasterDataENG.UpdateKioskPromotionExpired(1)

        'Engine.SyncMasterDataENG.TestTraceFrame("123")

        'Engine.SyncTransactionDataENG.SyncAllTransaction(KioskInfoENG.KioskID)
        'Engine.SyncTransactionDataENG.SyncDepositTransaction(KioskInfoENG.KioskID)
        'Engine.SyncTransactionDataENG.SyncCollectTransaction(KioskInfoENG.KioskID)
        'Engine.SyncTransactionDataENG.SyncStaffConsoleTransaction(23)
        'Engine.SyncTransactionDataENG.SyncDeleteCompleteTransaction(23)
        'Engine.SyncTransactionDataENG.ConvertDepositTransationCustImage(KioskInfoENG.KioskID)
        'Engine.SyncTransactionDataENG.SyncDepositTransactionCustImage(KioskInfoENG.KioskID)
        'Engine.SyncTransactionDataENG.SyncDeleteCompleteTransaction(KioskInfoENG.KioskID)

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
        Engine.SyncMasterDataENG.PullMasterMonitoringAlarm(KioskInfoENG.KioskID)
        'Engine.SyncMasterDataENG.PullMasterServiceRate(34)

        'SyncTransactionDataENG.ConvertCollectTransationCustImage(KioskInfoENG.KioskID)
        'SyncTransactionDataENG.SyncCollectTransactionCustImage(KioskInfoENG.KioskID)


    End Sub
End Class