Public Class frmServerWindowSchedule

    Private Sub frmServerWindowSchedule_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim vDate As DateTime = DateAdd(DateInterval.Day, -1, DateTime.Now.Date)
        'Dim vDate As DateTime = DateTime.Now.Date
        LockerReportMailENG.SendMailDailyReport(vDate)

        LockerNoticeValidExpireENG.SendNoticeValidExpireDate()
        Application.Exit()
    End Sub
End Class
