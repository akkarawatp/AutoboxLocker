Imports Engine.LogFileENG
Imports System.Data.SqlClient
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Net.Mail

Public Class LockerNoticeValidExpireENG
    Public Shared Sub SendNoticeValidExpireDate()
        Try
            Dim sql As String = "select k.valid_expire_date, DATEDIFF(dd,getdate(),valid_expire_date) day_qty, l.location_name " & vbNewLine
            sql += " from ms_kiosk k " & vbNewLine
            sql += " inner join ms_location l on k.ms_location_id=l.id " & vbNewLine
            sql += " where k.active_status='Y'" & vbNewLine
            sql += " and DATEADD(dd,90,convert(date, getdate()))>convert(date, valid_expire_date)" & vbNewLine
            Dim dt As DataTable = ServerDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                'มี Locker ไกล้วันหมดอายุ

                'หา Email ของผู้รับ
                sql = " select distinct mgd.email " & vbNewLine
                sql += " From MS_REPORT_MAIL_GROUP_DETAIL mgd " & vbNewLine
                sql += " inner join MS_REPORT_MAIL_GROUP mg on mg.id=mgd.ms_report_mail_group_id " & vbNewLine
                sql += " where mg.active_status='Y' "

                Dim eDt As DataTable = ServerDB.ExecuteTable(sql)
                If eDt.Rows.Count > 0 Then
                    Dim Mail As New MailMessage
                    For i As Integer = 0 To eDt.Rows.Count - 1
                        Mail.To.Add(eDt.Rows(i)("email"))
                    Next

                    For Each dr As DataRow In dt.Rows
                        Dim strDate As String = Convert.ToDateTime(dr("valid_expire_date")).ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("th-TH"))

                        Dim MailSubject As String = "Server ของตู้ Locker ที่สาขา " & dr("location_name") & " ใกล้หมดอายุ"

                        Dim MailAlias As String = "Server ของ Locker ใกล้หมดอายุ"

                        Dim MailContent As String = "Dear All <br /><br />"
                        MailContent += "บริการ Server ของตู้ Locker ที่สาขา " & dr("location_name") & " กำลังจะหมดอายุในวันที่ " & strDate & " (" & dr("day_qty") & " วัน) <br />"
                        MailContent += "กรุณาต่ออายุก่อนครบกำหนด <br /><br />"
                        MailContent += "[Auto Mail please no reply]"

                        SendMailENG.SendMail(Mail, MailContent, MailSubject, MailAlias)
                    Next
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
    End Sub

End Class
