Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient
Imports System.IO
Public Class frmAlarmMonitoring
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 6
    Const FunctionalZoneID As Int16 = 3

    Protected ReadOnly Property UserName As String
        Get
            Try
                Return Session("UserName")
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
        If ufDt Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End If
        If ufDt.Rows.Count > 0 Then
            Dim auDt As DataTable = BL.GetList_User_Functional(0, FunctionalZoneID, FunctionalID, Session("Username"))
            If auDt.Rows.Count = 0 Then
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
                Exit Sub
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()

        If Not IsPostBack Then
            BindList()
        End If
        initFormPlugin()
    End Sub

    Private Sub initFormPlugin()
        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Plugin", "initFormPlugin(); ", True)
    End Sub

    Private Sub btnUpdateStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateStatus.Click
        BindList()
    End Sub

    Private Sub BindList()
        Dim DT As DataTable = BL.Alarm_Overview(0, username)

        rptList.DataSource = DT
        rptList.DataBind()

        lblTotalList.Text = FormatNumber(DT.Rows.Count, 0)

    End Sub

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim aInfo As HtmlAnchor = e.Item.FindControl("aInfo")

        'Dim iconCam As HtmlAnchor = e.Item.FindControl("iconCam")

        Dim imgKioskIcon As Image = e.Item.FindControl("imgKioskIcon")
        Dim lblKioskCode As Label = e.Item.FindControl("lblKioskCode")
        Dim lblLocation As Label = e.Item.FindControl("lblLocation")
        Dim lblIP As Label = e.Item.FindControl("lblIP")
        Dim lblMac As Label = e.Item.FindControl("lblMac")
        Dim lblLastSyncTime As Label = e.Item.FindControl("lblLastSyncTime")

        Dim h3 As HtmlGenericControl = e.Item.FindControl("h3")
        Dim lnkHardware As LinkButton = e.Item.FindControl("lnkHardware")
        Dim lnkPeripheral As LinkButton = e.Item.FindControl("lnkPeripheral")
        Dim lnkStock As LinkButton = e.Item.FindControl("lnkStock")
        Dim lnkNetwork As LinkButton = e.Item.FindControl("lnkNetwork")

        lblKioskCode.Text = e.Item.DataItem("com_name").ToString
        lblLocation.Text = e.Item.DataItem("location_name").ToString
        lblIP.Text = e.Item.DataItem("ip_address").ToString
        lblMac.Text = e.Item.DataItem("mac_address").ToString
        If Convert.IsDBNull(e.Item.DataItem("last_sync_time")) = False Then lblLastSyncTime.Text = Convert.ToDateTime(e.Item.DataItem("last_sync_time")).ToString("dd MMM yyyy HH:mm:ss")
        aInfo.HRef = "frmAlarmMonitoringView.aspx?K=" & e.Item.DataItem("id")

        If e.Item.DataItem("hw_isproblem") = "Y" Or e.Item.DataItem("peripheral_condition") = "Y" Or
            e.Item.DataItem("stock_level") = "Y" Or e.Item.DataItem("available_status") = "N" Then
            h3.Attributes("class") = "m-a-0 text-red"
            imgKioskIcon.ImageUrl = "images/icon/100/koisk_ab.png"
        Else
            h3.Attributes("class") = "m-a-0 text-green"
            imgKioskIcon.ImageUrl = "images/icon/100/koisk_ok.png"
        End If

        If e.Item.DataItem("available_status") = "N" Then
            lnkNetwork.CssClass = "btn btn-danger btn-icon condition"
            'Exit Sub
        Else
            lnkNetwork.CssClass = "btn btn-info btn-icon condition"
        End If

        If e.Item.DataItem("hw_isproblem") = "Y" Then
            lnkHardware.CssClass = "btn btn-danger btn-icon condition"
        Else
            lnkHardware.CssClass = "btn btn-info btn-icon condition"
        End If

        If e.Item.DataItem("peripheral_condition") = "Y" Then
            lnkPeripheral.CssClass = "btn btn-danger btn-icon condition"
        Else
            lnkPeripheral.CssClass = "btn btn-info btn-icon condition"
        End If
        If e.Item.DataItem("stock_level") = "Y" Then
            lnkStock.CssClass = "btn btn-danger btn-icon condition"
        Else
            lnkStock.CssClass = "btn btn-info btn-icon condition"
        End If

    End Sub
End Class