Imports System.Net.Mail
Imports ServerLinqDB.TABLE

Public Class SendMailENG


    Public Shared Sub SendMail(Mail As MailMessage, MailContent As String, MailSubject As String, MailAlias As String)
        'ส่ง Email Alarm 
        Dim cfLnq As New CfServerSysconfigServerLinqDB
        cfLnq.GetDataByPK(1, Nothing)
        If cfLnq.ID > 0 Then
            Try
                Dim MailServer As String = cfLnq.MAIL_SERVER
                Dim Mailfrom As String = cfLnq.MAIL_SENDER
                Dim MailPass As String = cfLnq.MAIL_PASSWD
                Dim MailPort As String = cfLnq.MAIL_PORT
                Dim MailSSL As Boolean = (cfLnq.MAIL_SSL = "Y")

                Mail.Subject = MailSubject
                Mail.From = New MailAddress(Mailfrom, MailAlias)
                Mail.IsBodyHtml = True
                Mail.Body = MailContent 'Message Here
                Mail.BodyEncoding = System.Text.Encoding.UTF8
                'Mail.Attachments.Add()

                Dim SMTP As New SmtpClient(MailServer)
                SMTP.Credentials = New System.Net.NetworkCredential(Mailfrom, MailPass) '<-- ชื่อเมลที่เราจะใช้ส่ง และรหัส 
                SMTP.EnableSsl = MailSSL
                SMTP.Port = MailPort
                SMTP.Send(Mail)
            Catch ex As Exception
                Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
            End Try
        End If
        cfLnq = Nothing
    End Sub
End Class
