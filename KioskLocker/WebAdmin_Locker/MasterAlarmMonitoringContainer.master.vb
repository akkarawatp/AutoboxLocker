Imports System.Data
Public Class MasterAlarmMonitoringContainer
    Inherits System.Web.UI.MasterPage

    Dim BL As New LockerBL
    Protected ReadOnly Property UserName As String
        Get
            Try
                Return Session("UserName")
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Public ReadOnly Property KO_ID As Integer
        Get
            Try
                Return Request.QueryString("K")
            Catch ex As Exception
                Return 0
            End Try
        End Get

    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If KO_ID = 0 Then
                Response.Redirect("frmAlarmMonitoring.aspx")
                Exit Sub
            Else
                BindKiosk()
            End If
        End If
    End Sub

    Private Sub BindKiosk()
        Dim DT As DataTable = BL.Alarm_Overview(KO_ID, UserName)
        If DT.Rows.Count = 0 Then
            Response.Redirect("frmAlarmMonitoring.aspx")
            Exit Sub
        End If


        lblKO_Alias.Text = DT.Rows(0).Item("com_name").ToString
        If DT.Rows(0)("available_status") = "N" Then
            lblKO_Alias.Text += " (Offline)"

            lblKO_Alias.ForeColor = Drawing.Color.Red
        End If

    End Sub

End Class