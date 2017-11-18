Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient

Public Class frmSettingMailGroup
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 12
    Const FunctionalZoneID As Int16 = 2

    Public Property Edit_GRP_ID As Integer
        Get
            Try
                Return ViewState("GRP_ID")
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(value As Integer)
            ViewState("GRP_ID") = value
        End Set
    End Property

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

    Protected Sub SetAuthorizedLevel(ByVal DT As DataTable)
        'AuthorizedLevel = BL.GetFunctionalAuthorized(DT, FN_ID)
    End Sub

    Private Sub initFormPlugin()
        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Plugin", "initFormPlugin(); ", True)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        ClearEditForm()
        BindReportList(0)
        BindLocationList(0)

        pnlList.Visible = False
        pnlEdit.Visible = True
    End Sub

    Private Sub ClearEditForm()
        Edit_GRP_ID = 0

        txtGROUPCODE.Text = ""
        txtGROUPNAME.Text = ""

        rptReportList.DataSource = ""
        rptReportList.DataBind()

        rptLocationList.DataSource = ""
        rptLocationList.DataBind()

        rptEmailAlarm.DataSource = ""
        rptEmailAlarm.DataBind()

        chkActive.Checked = False
        lblEditMode.Text = "Add"
    End Sub

#Region "MailGrouptList"
    Private Sub BindList()
        Dim DT As DataTable = BL.GetList_MailGroup()
        rptList.DataSource = DT
        rptList.DataBind()

        lblTotalList.Text = FormatNumber(DT.Rows.Count, 0)

        pnlList.Visible = True
        pnlEdit.Visible = False

        'ตรวจสอบสิทธิ์การแก้ไขข้อมูล
        Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
        If ufDt Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End If

        If ufDt.Rows.Count > 0 Then
            Dim auDt As DataTable = BL.GetList_User_Functional(2, FunctionalZoneID, FunctionalID, Session("Username"))
            If auDt.Rows.Count = 0 Then
                btnAdd.Visible = False

                For i As Integer = 0 To rptList.Items.Count - 1
                    Dim btnEdit As Button = rptList.Items(i).FindControl("btnEdit")
                    Dim btnDelete As Button = rptList.Items(i).FindControl("btnDelete")

                    btnEdit.Text = "View"
                    btnDelete.Enabled = False
                Next
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()
    End Sub

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim td As HtmlTableCell = e.Item.FindControl("td")
        'Dim lblGroupCode As Label = e.Item.FindControl("lblGroupCode")
        Dim lblGroupName As Label = e.Item.FindControl("lblGroupName")
        Dim lblCountReport As Label = e.Item.FindControl("lblCountReport")
        Dim lblCountLocation As Label = e.Item.FindControl("lblCountLocation")
        Dim lblCountEmail As Label = e.Item.FindControl("lblCountEmail")

        Dim btnEdit As Button = e.Item.FindControl("btnEdit")
        Dim ColEdit As HtmlTableCell = e.Item.FindControl("ColEdit")
        Dim btnDelete As Button = e.Item.FindControl("btnDelete")
        Dim cfmDelete As AjaxControlToolkit.ConfirmButtonExtender = e.Item.FindControl("cfmDelete")
        Dim ColDelete As HtmlTableCell = e.Item.FindControl("ColDelete")

        cfmDelete.ConfirmText = "Confirm to delete " & e.Item.DataItem("GROUP_NAME").ToString & " ?"

        If Not IsNothing(e.Item.DataItem("ACTIVE_STATUS")) AndAlso Not IsDBNull(e.Item.DataItem("ACTIVE_STATUS")) AndAlso e.Item.DataItem("ACTIVE_STATUS") = "Y" Then
            td.Attributes("class") = "h5 text-green"
        Else
            td.Attributes("class") = "h5 text-danger"
        End If

        lblGroupName.Text = e.Item.DataItem("GROUP_NAME").ToString
        lblCountReport.Text = e.Item.DataItem("COUNT_REPORT").ToString
        lblCountLocation.Text = e.Item.DataItem("COUNT_LOCATION").ToString
        lblCountEmail.Text = e.Item.DataItem("COUNT_MAIL").ToString

        btnEdit.CommandArgument = e.Item.DataItem("id")
        btnDelete.CommandArgument = e.Item.DataItem("id")
    End Sub

    Private Sub rptList_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptList.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                Dim GROUP_ID As String = e.CommandArgument
                Dim DT As DataTable = BL.Get_Mail_Group_Info(GROUP_ID)
                Dim lblGroupName As Label = e.Item.FindControl("lblGroupName")
                If DT.Rows.Count = 0 Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & lblGroupName.Text.Replace("'", """") & " is not found!');", True)
                    Exit Sub
                End If

                ClearEditForm()
                Edit_GRP_ID = GROUP_ID

                txtGROUPCODE.Text = DT.Rows(0).Item("GROUP_CODE").ToString
                txtGROUPNAME.Text = DT.Rows(0).Item("GROUP_NAME").ToString
                chkActive.Checked = IIf(DT.Rows(0).Item("ACTIVE_STATUS").ToString = "Y", True, False)

                BindReportList(GROUP_ID)
                BindLocationList(GROUP_ID)
                BindEmailList(GROUP_ID)

                lblEditMode.Text = "Edit"
                pnlList.Visible = False
                pnlEdit.Visible = True

                SetControlViewOnly()
            Case "Delete"
                BL.Drop_MailGroup(e.CommandArgument)
                BindList()
        End Select
    End Sub

    Private Sub SetControlViewOnly()
        'ตรวจสอบสิทธิ์การแก้ไขข้อมูล
        Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
        If ufDt Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End If
        If ufDt.Rows.Count > 0 Then
            Dim auDt As DataTable = BL.GetList_User_Functional(2, FunctionalZoneID, FunctionalID, Session("Username"))
            If auDt.Rows.Count = 0 Then
                txtGROUPCODE.Enabled = False
                txtGROUPNAME.Enabled = False

                chkHeadLocationList.Enabled = False
                For i As Integer = 0 To rptReportList.Items.Count - 1
                    Dim chkItemReportList As CheckBox = rptReportList.Items(i).FindControl("chkItemReportList")
                    chkItemReportList.Enabled = False
                Next

                chkHeadLocationList.Enabled = False
                For i As Integer = 0 To rptLocationList.Items.Count - 1
                    Dim chkItemLocationList As CheckBox = rptLocationList.Items(i).FindControl("chkItemLocationList")
                    chkItemLocationList.Enabled = False
                Next

                For i As Integer = 0 To rptEmailAlarm.Items.Count - 1
                    Dim txtEmail As TextBox = rptEmailAlarm.Items(i).FindControl("txtEmail")
                    Dim btnDeleteEmail As Button = rptEmailAlarm.Items(i).FindControl("btnDeleteEmail")

                    txtEmail.Enabled = False
                    btnDeleteEmail.Enabled = False
                Next
                lnkAddNewEmail.Visible = False

                chkActive.Enabled = False
                btnSave.Visible = False
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()
    End Sub
#End Region

#Region "Report List"
    Private Sub BindReportList(GROUP_ID As Integer)
        Dim DT As DataTable = BL.GetList_MailGroup_Report(GROUP_ID)
        rptReportList.DataSource = DT
        rptReportList.DataBind()
    End Sub

    Private Sub rptReportList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptReportList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim chkItemReportList As CheckBox = e.Item.FindControl("chkItemReportList")
        Dim lblReportID As Label = e.Item.FindControl("lblReportID")
        Dim lblReportName As Label = e.Item.FindControl("lblReportName")

        chkItemReportList.Checked = False
        If e.Item.DataItem("SELECTED").ToString = "T" Then
            chkItemReportList.Checked = True
        End If

        lblReportID.Text = e.Item.DataItem("ID").ToString
        lblReportName.Text = e.Item.DataItem("REPORT_NAME").ToString

    End Sub

    Private Sub btnCheckReportAll_Click(sender As Object, e As EventArgs) Handles btnCheckReportAll.Click
        For i As Integer = 0 To rptReportList.Items.Count - 1
            Dim chkItemKioskAlarm As CheckBox = rptReportList.Items(i).FindControl("chkItemReportList")
            chkItemKioskAlarm.Checked = Not chkHeadReportList.Checked
        Next
        chkHeadReportList.Checked = Not chkHeadReportList.Checked
    End Sub
#End Region

#Region "Location List"
    Private Sub BindLocationList(GROUP_ID As Integer)
        Dim DT As DataTable = BL.GetList_MailGroup_Location(GROUP_ID)
        rptLocationList.DataSource = DT
        rptLocationList.DataBind()
    End Sub
    Private Sub rptLocationList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptLocationList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim chkItemLocationList As CheckBox = e.Item.FindControl("chkItemLocationList")
        Dim lblLocationID As Label = e.Item.FindControl("lblLocationID")
        Dim lblLocationName As Label = e.Item.FindControl("lblLocationName")

        chkItemLocationList.Checked = False
        If e.Item.DataItem("SELECTED").ToString = "T" Then
            chkItemLocationList.Checked = True
        End If

        lblLocationID.Text = e.Item.DataItem("ID").ToString
        lblLocationName.Text = e.Item.DataItem("LOCATION_NAME").ToString
    End Sub

    Private Sub btnCheckLocationAll_Click(sender As Object, e As EventArgs) Handles btnCheckLocationAll.Click
        For i As Integer = 0 To rptLocationList.Items.Count - 1
            Dim chkItemLocationList As CheckBox = rptLocationList.Items(i).FindControl("chkItemLocationList")
            chkItemLocationList.Checked = Not chkHeadLocationList.Checked
        Next
        chkHeadLocationList.Checked = Not chkHeadLocationList.Checked
    End Sub

#End Region

#Region "Email Alarm"
    Private Sub BindEmailList(GROUP_ID As Integer)
        Dim DT As DataTable = BL.GetList_MailGroup_Mail(GROUP_ID)
        rptEmailAlarm.DataSource = DT
        rptEmailAlarm.DataBind()
    End Sub
    Protected Function CurrentEmailAlarmList() As DataTable
        Dim DT As New DataTable
        DT.Columns.Add("EMAIL")

        For Each Item As RepeaterItem In rptEmailAlarm.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim DR As DataRow = DT.NewRow
            Dim txtEmail As TextBox = Item.FindControl("txtEmail")

            DT.Rows.Add(DR)
            If txtEmail.Text.Trim <> "" Then
                DR("EMAIL") = txtEmail.Text
            End If

            DT.AcceptChanges()
        Next

        Return DT
    End Function
    Private Sub rptEmailAlarm_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptEmailAlarm.ItemCommand
        Select Case e.CommandName
            Case "Delete"
                Dim DT As DataTable = CurrentEmailAlarmList()
                Try
                    DT.Rows(e.Item.ItemIndex).Delete()
                    DT.AcceptChanges()
                Catch : End Try
                rptEmailAlarm.DataSource = DT
                rptEmailAlarm.DataBind()
        End Select
    End Sub

    Private Sub rptEmailAlarm_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptEmailAlarm.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim txtEmail As TextBox = e.Item.FindControl("txtEmail")
        Dim lblNo As Label = e.Item.FindControl("lblNo")
        Dim ColDelete As HtmlTableCell = e.Item.FindControl("ColDelete")

        lblNo.Text = e.Item.ItemIndex + 1
        If Not IsDBNull(e.Item.DataItem("EMAIL")) Then
            txtEmail.Text = e.Item.DataItem("EMAIL").ToString
        End If
    End Sub

    Private Sub lnkAddNewEmail_Click(sender As Object, e As System.EventArgs) Handles lnkAddNewEmail.Click
        Dim DT As DataTable = CurrentEmailAlarmList()
        DT.Rows.Add()
        rptEmailAlarm.DataSource = DT
        rptEmailAlarm.DataBind()
    End Sub
#End Region

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        BindList()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click

        If txtGROUPCODE.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Group Code');", True)
            Exit Sub
        End If
        If txtGROUPNAME.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Group Name');", True)
            Exit Sub
        End If

        Dim trans As New ServerTransactionDB
        Dim lnqMailGroup As New MsReportMailGroupServerLinqDB
        If lnqMailGroup.ChkDuplicateByGROUP_CODE(txtGROUPCODE.Text.Trim, Edit_GRP_ID, trans.Trans) Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('This Group Code is already existed');", True)
            Exit Sub
        End If
        If lnqMailGroup.ChkDuplicateByGROUP_NAME(txtGROUPNAME.Text.Trim, Edit_GRP_ID, trans.Trans) Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('This Group Name is already existed');", True)
            Exit Sub
        End If

        Dim group_id As String = Edit_GRP_ID
        Dim group_code As String = txtGROUPCODE.Text.Trim.Replace("'", "")
        Dim group_name As String = txtGROUPNAME.Text.Trim.Replace("'", "")
        Dim active_status As String = IIf(chkActive.Checked = True, "Y", "N")
        Dim user_name As String = Session("USER_ID")

        Dim dt_report As New DataTable
        Dim dr_report As DataRow
        dt_report.Columns.Add("ID")
        For i As Integer = 0 To rptReportList.Items.Count - 1
            Dim chkItemReportList As CheckBox = rptReportList.Items(i).FindControl("chkItemReportList")
            If chkItemReportList.Checked = True Then
                Dim lblReportID As Label = rptReportList.Items(i).FindControl("lblReportID")
                dr_report = dt_report.NewRow
                dr_report("ID") = lblReportID.Text
                dt_report.Rows.Add(dr_report)
            End If
        Next


        Dim dt_location As New DataTable
        Dim dr_location As DataRow
        dt_location.Columns.Add("ID")
        For i As Integer = 0 To rptLocationList.Items.Count - 1
            Dim chkItemLocationList As CheckBox = rptLocationList.Items(i).FindControl("chkItemLocationList")
            If chkItemLocationList.Checked = True Then
                Dim lblLocationID As Label = rptLocationList.Items(i).FindControl("lblLocationID")
                dr_location = dt_location.NewRow
                dr_location("ID") = lblLocationID.Text
                dt_location.Rows.Add(dr_location)
            End If
        Next


        Dim dt_email As New DataTable
        dt_email.Columns.Add("EMAIL")
        Dim dr_email As DataRow
        For i As Integer = 0 To rptEmailAlarm.Items.Count - 1
            Dim txtEmail As TextBox = rptEmailAlarm.Items(i).FindControl("txtEmail")
            If txtEmail.Text <> "" Then
                dr_email = dt_email.NewRow
                dr_email("EMAIL") = txtEmail.Text
                dt_email.Rows.Add(dr_email)
            End If
        Next

        Dim ret As String = InsertEdit_Setting_MailGroup(group_id, group_code, group_name, active_status, dt_report, dt_location, dt_email, user_name)
        If ret = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Save success');", True)
            BindList()
        Else
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Cant Save Data');", True)
        End If

    End Sub

    Public Function InsertEdit_Setting_MailGroup(ByVal GROUP_ID As Integer, GROUP_CODE As String, GROUP_NAME As String, ACTIVE_STATUS As String, DT_REPORT As DataTable,
                                            DT_LOCATION As DataTable, DT_EMAIL As DataTable, USER_NAME As String) As String

        Dim trans As New ServerTransactionDB
        Try

            '=== MS_REPORT_MAIL_GROUP
            Dim lnqMailGroup As New MsReportMailGroupServerLinqDB
            lnqMailGroup.GetDataByPK(Edit_GRP_ID, trans.Trans)
            With lnqMailGroup
                .GROUP_CODE = GROUP_CODE
                .GROUP_NAME = GROUP_NAME
                .ACTIVE_STATUS = ACTIVE_STATUS
            End With
            Dim ret As ExecuteDataInfo
            If lnqMailGroup.ID > 0 Then
                ret = lnqMailGroup.UpdateData(UserName, trans.Trans)
            Else
                ret = lnqMailGroup.InsertData(UserName, trans.Trans)
            End If

            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                Return ret.ErrorMessage
            End If


            '=== MS_REPORT_MAIL_GROUP_REPORTS
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetText("@_GROUP_ID", lnqMailGroup.ID)
            ret = ServerDB.ExecuteNonQuery("DELETE FROM MS_REPORT_MAIL_GROUP_REPORTS WHERE MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID", p)

            If ret.IsSuccess = True AndAlso DT_REPORT.Rows.Count > 0 Then
                For i As Integer = 0 To DT_REPORT.Rows.Count - 1
                    With DT_REPORT
                        Dim report_id As String = .Rows(i)("ID").ToString
                        Dim lnqMailGroupReport = New MsReportMailGroupReportsServerLinqDB
                        With lnqMailGroupReport
                            .MS_REPORT_MAIL_GROUP_ID = lnqMailGroup.ID
                            .MS_REPORTS_MAIL_ID = report_id
                        End With

                        Dim d_ret As New ExecuteDataInfo
                        d_ret = lnqMailGroupReport.InsertData(UserName, trans.Trans)

                        If d_ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            Return d_ret.ErrorMessage
                        End If

                        lnqMailGroupReport = Nothing
                    End With

                Next
            End If



            '=== MS_REPORT_MAIL_GROUP_LOCATION
            Dim p_l(1) As SqlParameter
            p_l(0) = ServerDB.SetText("@_GROUP_ID", lnqMailGroup.ID)
            ret = ServerDB.ExecuteNonQuery("DELETE FROM MS_REPORT_MAIL_GROUP_LOCATION WHERE MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID", p_l)

            If ret.IsSuccess = True AndAlso DT_LOCATION.Rows.Count > 0 Then
                For i As Integer = 0 To DT_LOCATION.Rows.Count - 1
                    With DT_LOCATION
                        Dim location_id As String = .Rows(i)("ID").ToString
                        Dim lnqMailGroupLocation = New MsReportMailGroupLocationServerLinqDB
                        With lnqMailGroupLocation
                            .MS_REPORT_MAIL_GROUP_ID = lnqMailGroup.ID
                            .MS_LOCATION_ID = location_id
                        End With

                        Dim d_ret As New ExecuteDataInfo
                        d_ret = lnqMailGroupLocation.InsertData(UserName, trans.Trans)

                        If d_ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            Return d_ret.ErrorMessage
                        End If

                        lnqMailGroupLocation = Nothing
                    End With

                Next
            End If


            '===MS_REPORT_MAIL_GROUP_DETAIL
            Dim p_e(1) As SqlParameter
            p_e(0) = ServerDB.SetText("@_GROUP_ID", lnqMailGroup.ID)
            ret = ServerDB.ExecuteNonQuery("DELETE FROM MS_REPORT_MAIL_GROUP_DETAIL WHERE MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID", p_e)

            If ret.IsSuccess = True AndAlso DT_EMAIL.Rows.Count > 0 Then
                For i As Integer = 0 To DT_EMAIL.Rows.Count - 1
                    With DT_EMAIL
                        Dim e_mail As String = .Rows(i)("EMAIL").ToString
                        Dim lnqAlGroupEmail = New MsReportMailGroupDetailServerLinqDB

                        With lnqAlGroupEmail
                            .MS_REPORT_MAIL_GROUP_ID = lnqMailGroup.ID
                            .EMAIL = e_mail
                        End With

                        Dim d_ret As New ExecuteDataInfo
                        d_ret = lnqAlGroupEmail.InsertData(UserName, trans.Trans)

                        If d_ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            Return d_ret.ErrorMessage
                        End If

                        lnqAlGroupEmail = Nothing
                    End With

                Next
            End If

            trans.CommitTransaction()
            lnqMailGroup = Nothing
            Return ""
        Catch ex As Exception

            trans.RollbackTransaction()
            Return ex.ToString()
        End Try

    End Function


End Class