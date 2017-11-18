Imports System
Imports System.Data
Imports System.Web
Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateMenu()
            DisplayUserInfo()

            If Not Session("ForceChangePW") Is Nothing AndAlso Session("ForceChangePW").ToString() = "Y" Then
                leftMenu.Visible = False
            End If
        End If

    End Sub

    Protected Sub DisplayUserInfo()
        Dim LT As DataTable = Session("List_User")
        If Session("UserName") Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
            Exit Sub
        End If
        lblUserName.InnerHtml = Session("UserName")
    End Sub

    Protected Sub PopulateMenu()
        ''-------------- By Authorize------------
        Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
        If ufDt Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
            Exit Sub
        End If

        Dim DT As DataTable = ufDt.Copy
        Dim BL As New LockerBL
        '-------------- Dashboard ----------------
        mnu_Dashboard.Visible = BL.GetFunctionalAuthorized(DT, 1) > 0

        ''-------------- Report ----------------
        mnu_Transaction_Log.Visible = BL.GetFunctionalAuthorized(DT, 2) > 0
        mnu_Transaction_Performance.Visible = BL.GetFunctionalAuthorized(DT, 22) > 0
        mnu_Transaction_Reports.Visible = mnu_Transaction_Log.Visible Or mnu_Transaction_Performance.Visible

        mnu_Summary_byLocation.Visible = BL.GetFunctionalAuthorized(DT, 23) > 0
        mnu_MoneyStock_byLocation.Visible = BL.GetFunctionalAuthorized(DT, 28) > 0
        mnu_Summary_Report.Visible = mnu_Summary_byLocation.Visible Or mnu_MoneyStock_byLocation.Visible

        mnu_Report.Visible = mnu_Transaction_Reports.Visible Or mnu_Summary_Report.Visible

        ''--------------Alarm & Monitoring-------------------
        mnu_Kiosk_Monitoring.Visible = BL.GetFunctionalAuthorized(DT, 6) > 0
        mnu_Alarm_Setting.Visible = BL.GetFunctionalAuthorized(DT, 7)

        mnu_Setting_Alarm_Monitoring.Visible = mnu_Kiosk_Monitoring.Visible Or mnu_Alarm_Setting.Visible

        ''--------------Master Data-------------------
        mnu_Setting_Location.Visible = BL.GetFunctionalAuthorized(DT, 8)
        mnu_Setting_Kiosk.Visible = BL.GetFunctionalAuthorized(DT, 9)

        mnu_Setting_Authorize_Role.Visible = BL.GetFunctionalAuthorized(DT, 13)
        mnu_Setting_Authorize_User.Visible = BL.GetFunctionalAuthorized(DT, 14)

        mnu_Setting_Authorize.Visible = mnu_Setting_Authorize_Role.Visible Or mnu_Setting_Authorize_User.Visible
        mnu_Master_Data.Visible = mnu_Setting_Location.Visible Or mnu_Setting_Kiosk.Visible Or mnu_Setting_Authorize.Visible



        '-------------- Setting Badge Count ---------
        SetBadgeCount(DT)

    End Sub

    Protected Sub SetBadgeCount(ByVal DT As DataTable)
        Dim Count_Report As Integer = 0
        Dim CountReport_Transactioin_Report As Integer = 0
        Dim CountReport_Summary_Report As Integer = 0
        Dim Count_Alarm_Monitoring As Integer = 0
        Dim Count_Master_Data As Integer = 0
        Dim Count_Setting_Authorize As Integer = 0

        CountReport_Transactioin_Report = Math.Abs(CInt(mnu_Transaction_Log.Visible)) + Math.Abs(CInt(mnu_Transaction_Performance.Visible))
        CountReport_Summary_Report = Math.Abs(CInt(mnu_Summary_byLocation.Visible)) + Math.Abs(CInt(mnu_MoneyStock_byLocation.Visible))
        Count_Report = CountReport_Transactioin_Report + CountReport_Summary_Report + Math.Abs(CInt(mnu_MailGroup_Report.Visible))
        Count_Alarm_Monitoring = Math.Abs(CInt(mnu_Kiosk_Monitoring.Visible)) + Math.Abs(CInt(mnu_Alarm_Setting.Visible))

        Count_Setting_Authorize = Math.Abs(CInt(mnu_Setting_Authorize_Role.Visible)) + Math.Abs(CInt(mnu_Setting_Authorize_User.Visible))
        Count_Master_Data = Count_Setting_Authorize + Math.Abs(CInt(mnu_Setting_Location.Visible)) + Math.Abs(CInt(mnu_Setting_Kiosk.Visible))

        badge_Report.InnerHtml = Count_Report
        badge_Transaction_Reports.InnerHtml = CountReport_Transactioin_Report
        badge_Summary_Report.InnerHtml = CountReport_Summary_Report

        badge_Alarm.InnerHtml = Count_Alarm_Monitoring
        badge_Master_Data.InnerHtml = Count_Master_Data
        badge_Setting_Authorize.InnerHtml = Count_Setting_Authorize
    End Sub


    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Remove("List_User_Functional")
        Session.Remove("List_User_Location")
        Session.Remove("UserName")

        Response.Redirect("frmLogin.aspx")
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Response.Redirect("frmChangePassword.aspx")
    End Sub
End Class