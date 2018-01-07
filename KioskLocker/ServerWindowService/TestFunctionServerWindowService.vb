Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data

Public Class TestFunctionServerWindowService
    Private Sub TestFunctionServerWindowService_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'LockerReportMailENG.GenExcelTransactionLogReport(vDate, 1, "LockerTransactionReport.xlsx")

        'LockerReportMailENG.GenExcelSummaryReportByLocation(vDate, 1, "LockerSummaryReportByLocation.xlsx")
        'LockerReportMailENG.GenExcelSummaryReportBySize(vDate, 1, "LockerSummaryReportBySize.xlsx")

        'Dim vDate As DateTime = DateAdd(DateInterval.Day, -1, DateTime.Now.Date)
        'LockerReportMailENG.SendMailDailyReport(vDate)

        'Engine.SyncMasterDataENG.SyncMasterCabinet(1)
        'Engine.SyncMasterDataENG.SyncMasterKioskLocker(1)

        'Engine.SyncMasterDataENG.SyncLocationPromotion()

        'ServerUpdateMonitorENG.UpdateKioskOnlineStatus()
    End Sub


End Class