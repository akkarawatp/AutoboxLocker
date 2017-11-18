Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient

Public Class frmSettingRole
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 13
    Const FunctionalZoneID As Int16 = 4

    Protected ReadOnly Property UserName As String
        Get
            Try
                Return Session("UserName")
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Public Property Edit_Role_ID As Integer
        Get
            Try
                Return ViewState("Role_ID")
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(value As Integer)
            ViewState("Role_ID") = value
        End Set
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
            CloseAllDialog()
        End If
        initFormPlugin()
    End Sub

    Protected Sub SetAuthorizedLevel(ByVal DT As DataTable)
        'AuthorizedLevel = BL.GetFunctionalAuthorized(DT, FN_ID)
    End Sub

    Private Sub initFormPlugin()
        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Plugin", "initFormPlugin(); resizeScreen(); initDataTable(); ", True)
    End Sub

    Private Sub CloseAllDialog()
        pnlSelectUser.Visible = False
        'pnlNewUser.Visible = False
    End Sub

    Private Sub BindList()

        Dim DT As DataTable = BL.GetList_Role(0)

        rptList.DataSource = DT
        rptList.DataBind()

        lblTotalList.Text = FormatNumber(DT.Rows.Count, 0)

        pnlList.Visible = True
        pnlEdit.Visible = False
        CloseAllDialog()


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
                    Dim btnDelete As Button = rptList.Items(i).FindControl("btnDelete")
                    Dim btnEdit As Button = rptList.Items(i).FindControl("btnEdit")

                    btnEdit.Text = "View"
                    btnDelete.Enabled = False
                Next
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        ClearEditForm()

        '---------------- Bind AdminWeb ---------------
        BindRoleAdminWeb()

        '---------------- Bind Staff Console ---------------
        BindRoleStaffConsole()

        '---------------- Bind Members ---------------
        BindMember()

        pnlList.Visible = False
        pnlEdit.Visible = True
        ChangeTab(btnTabAdminWeb, e)
    End Sub

    Private Sub ClearEditForm()
        Edit_Role_ID = 0
        txtRoleName.Text = ""

        ''---------------- Bind AdminWeb ---------------
        'BindRoleAdminWeb()
        rptAdminWeb.DataSource = Nothing
        rptAdminWeb.DataBind()

        ''---------------- Bind Staff Console ---------------
        ' BindRoleStaffConsole()
        rptStaffConsole.DataSource = Nothing
        rptStaffConsole.DataBind()

        ''---------------- Bind Members ---------------
        'BindMember()
        rptUser.DataSource = Nothing
        rptUser.DataBind()

        ChangeTab(btnTabAdminWeb, Nothing)
        UpdateBadge()

        chkActive.Checked = False
        lblEditMode.Text = "Add"

        CloseAllDialog()

    End Sub

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        BindList()
    End Sub

    Dim FZ As DataTable
    Dim FN As DataTable
    Private Sub BindRoleAdminWeb()
        FZ = BL.GetList_Functional_Zone(LockerBL.Application_Type.ADMIN_WEB, 0)
        FN = BL.GetList_Functional(LockerBL.Application_Type.ADMIN_WEB, Edit_Role_ID)
        rptAdminWeb.DataSource = FZ
        rptAdminWeb.DataBind()
    End Sub

    Private Sub BindRoleStaffConsole()
        FZ = BL.GetList_Functional_Zone(LockerBL.Application_Type.KIOSK_STAFF_CONSOLE, 0)
        FN = BL.GetList_Functional(LockerBL.Application_Type.KIOSK_STAFF_CONSOLE, Edit_Role_ID)
        rptStaffConsole.DataSource = FZ
        rptStaffConsole.DataBind()
    End Sub

    Private Sub BindMember()
        Dim DT As DataTable = BL.GetList_User_Role("", IIf(Edit_Role_ID = 0, -1, Edit_Role_ID))
        Dim A As Integer = DT.Rows.Count
        rptUser.DataSource = DT
        rptUser.DataBind()
    End Sub

    Private Sub rptFZ_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptAdminWeb.ItemDataBound, rptStaffConsole.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub
        Dim lblHeader As Label = e.Item.FindControl("lblHeader")
        Dim rpt As Repeater = e.Item.FindControl("rpt")

        lblHeader.Text = e.Item.DataItem("FN_Zone_Name").ToString
        lblHeader.Attributes("FN_Zone_ID") = e.Item.DataItem("FN_Zone_ID")
        lblHeader.Attributes("App_ID") = e.Item.DataItem("App_ID")

        FN.DefaultView.RowFilter = "FN_Zone_ID=" & e.Item.DataItem("FN_Zone_ID")
        Dim DT As DataTable = FN.DefaultView.ToTable.Copy

        AddHandler rpt.ItemDataBound, AddressOf rptFN_ItemDataBound

        rpt.DataSource = DT
        rpt.DataBind()
    End Sub

    Private Function CurrentFunctionalZone() As DataTable
        Dim DT As New DataTable

        DT.Columns.Add("App_ID", GetType(Integer))
        DT.Columns.Add("FN_Zone_ID", GetType(Integer))
        DT.Columns.Add("FN_Zone_Name", GetType(String))

        '------------- Admin Web --------------
        For Each Item As RepeaterItem In rptAdminWeb.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim DR As DataRow = DT.NewRow
            Dim lblHeader As Label = Item.FindControl("lblHeader")
            DR("App_ID") = lblHeader.Attributes("App_ID")
            DR("FN_Zone_ID") = lblHeader.Attributes("FN_Zone_ID")
            DR("FN_Zone_Name") = lblHeader.Text
            DT.Rows.Add(DR)
        Next

        '------------ Merge Staff Console --------
        For Each Item As RepeaterItem In rptStaffConsole.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim DR As DataRow = DT.NewRow
            Dim lblHeader As Label = Item.FindControl("lblHeader")
            DR("App_ID") = lblHeader.Attributes("App_ID")
            DR("FN_Zone_ID") = lblHeader.Attributes("FN_Zone_ID")
            DR("FN_Zone_Name") = lblHeader.Text
            DT.Rows.Add(DR)
        Next

        Return DT
    End Function

    Private Function CurrentFunctional() As DataTable
        Dim DT As New DataTable

        DT.Columns.Add("APP_ID", GetType(Integer))
        DT.Columns.Add("FN_Zone_ID", GetType(Integer))
        DT.Columns.Add("FN_ID", GetType(Integer))
        DT.Columns.Add("FN_Name", GetType(String))
        DT.Columns.Add("Can_Edit", GetType(Boolean))
        DT.Columns.Add("Auth_ID", GetType(Integer))

        '------------- Admin Web --------------
        For Each _Item As RepeaterItem In rptAdminWeb.Items
            If _Item.ItemType <> ListItemType.Item And _Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim lblHeader As Label = _Item.FindControl("lblHeader")
            Dim rpt As Repeater = _Item.FindControl("rpt")
            For Each Item As RepeaterItem In rpt.Items
                If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
                Dim Selector2 As ucAuthorizeSelector2 = Item.FindControl("Selector2")
                Dim Selector3 As ucAuthorizeSelector3 = Item.FindControl("Selector3")
                Dim DR As DataRow = DT.NewRow
                Dim lblFN As Label = Item.FindControl("lblFN")
                DR("APP_ID") = LockerBL.Application_Type.ADMIN_WEB
                DR("FN_Zone_ID") = lblHeader.Attributes("FN_Zone_ID")
                DR("FN_ID") = lblFN.Attributes("FN_ID")
                DR("FN_Name") = lblFN.Text
                DR("Can_Edit") = Selector3.IsVisible
                If Selector3.IsVisible Then
                    DR("Auth_ID") = Selector3.SelectedRole
                Else
                    DR("Auth_ID") = Selector2.SelectedRole
                End If
                DT.Rows.Add(DR)
            Next
        Next

        '------------ Merge Staff Console --------
        For Each _Item As RepeaterItem In rptStaffConsole.Items
            If _Item.ItemType <> ListItemType.Item And _Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim lblHeader As Label = _Item.FindControl("lblHeader")
            Dim rpt As Repeater = _Item.FindControl("rpt")
            For Each Item As RepeaterItem In rpt.Items
                If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
                Dim Selector2 As ucAuthorizeSelector2 = Item.FindControl("Selector2")
                Dim Selector3 As ucAuthorizeSelector3 = Item.FindControl("Selector3")
                Dim DR As DataRow = DT.NewRow
                Dim lblFN As Label = Item.FindControl("lblFN")
                DR("APP_ID") = LockerBL.Application_Type.KIOSK_STAFF_CONSOLE
                DR("FN_Zone_ID") = lblHeader.Attributes("FN_Zone_ID")
                DR("FN_ID") = lblFN.Attributes("FN_ID")
                DR("FN_Name") = lblFN.Text
                DR("Can_Edit") = Selector3.IsVisible
                If DR("Can_Edit") Then
                    DR("Auth_ID") = Selector3.SelectedRole
                Else
                    DR("Auth_ID") = Selector2.SelectedRole
                End If
                DT.Rows.Add(DR)
            Next
        Next

        Return DT
    End Function

    Private Sub rptFN_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblFN As Label = e.Item.FindControl("lblFN")
        Dim Selector2 As ucAuthorizeSelector2 = e.Item.FindControl("Selector2")
        Dim Selector3 As ucAuthorizeSelector3 = e.Item.FindControl("Selector3")

        lblFN.Text = e.Item.DataItem("Functional_Name")
        lblFN.Attributes("FN_ID") = e.Item.DataItem("FN_ID")

        Selector3.IsVisible = False
        Selector2.IsVisible = False
        If e.Item.DataItem("Can_Edit") = "Y" Then
            Selector3.IsVisible = True
        Else
            Selector2.IsVisible = True
        End If

        Select Case e.Item.DataItem("Auth_ID")
            Case 2
                Selector3.SelectedRole = ucAuthorizeSelector3.Role.Edit
            Case 1
                If Selector2.IsVisible Then
                    Selector2.SelectedRole = ucAuthorizeSelector2.Role.View
                Else
                    Selector3.SelectedRole = ucAuthorizeSelector3.Role.View
                End If
            Case 0
                If Selector2.IsVisible Then
                    Selector2.SelectedRole = ucAuthorizeSelector2.Role.NA
                Else
                    Selector3.SelectedRole = ucAuthorizeSelector3.Role.NA
                End If
        End Select
    End Sub

    Private Sub rptUser_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptUser.ItemCommand
        Select Case e.CommandName
            Case "Delete"
                Dim DT As DataTable = CurrentSelectedUser()
                Try
                    DT.Rows.RemoveAt(e.Item.ItemIndex)
                    rptUser.DataSource = DT
                    rptUser.DataBind()
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub rptUser_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptUser.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                Dim lblUser As Label = e.Item.FindControl("lblUser")
                Dim btnDelete As LinkButton = e.Item.FindControl("btnDelete")
                lblUser.Text = e.Item.DataItem("username")
                btnDelete.CommandArgument = e.Item.DataItem("username")
            Case ListItemType.Footer
                lblTotalUser.Text = FormatNumber(rptUser.Items.Count, 0)
        End Select
    End Sub

    Private Function CurrentSelectedUser() As DataTable
        Dim DT As New DataTable
        DT.Columns.Add("username", GetType(String))

        For Each Item As RepeaterItem In rptUser.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim lblUser As Label = Item.FindControl("lblUser")
            Dim btnDelete As LinkButton = Item.FindControl("btnDelete")
            Dim DR As DataRow = DT.NewRow
            DR("username") = lblUser.Text
            DT.Rows.Add(DR)
        Next
        Return DT
    End Function

    Private Sub BindUnSelectedUser()
        Dim DT As DataTable = CurrentSelectedUser()
        Dim UT As DataTable
        UT = Engine.UserENG.GetListUser("", "", "", "", "", "")
        For i As Integer = 0 To DT.Rows.Count - 1
            UT.DefaultView.RowFilter = "username='" & DT.Rows(i).Item("username") & "'"
            If UT.DefaultView.Count > 0 Then
                UT.DefaultView(0).Row.Delete()
                UT.AcceptChanges()
            End If
        Next
        UT.Columns.Add("Selected", GetType(Boolean), "False")
        UT.DefaultView.RowFilter = ""
        rptUnselectedUser.DataSource = UT
        rptUnselectedUser.DataBind()
    End Sub

    Private Function CurrentUnSelectedUser() As DataTable
        Dim DT As New DataTable

        DT.Columns.Add("username", GetType(String))
        DT.Columns.Add("Selected", GetType(Boolean))

        For Each Item As RepeaterItem In rptUnselectedUser.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim lbl As Label = Item.FindControl("lbl")
            Dim chk As CheckBox = Item.FindControl("chk")
            Dim btn As Button = Item.FindControl("btn")
            Dim DR As DataRow = DT.NewRow
            DR("username") = lbl.Text
            DR("Selected") = chk.Checked
            DT.Rows.Add(DR)
        Next
        Return DT
    End Function

    Private Sub Setting_Role_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If pnlEdit.Visible Then UpdateBadge()
    End Sub

    Private Sub UpdateBadge()
        Dim DT As DataTable = CurrentFunctional()
        DT.DefaultView.RowFilter = "App_ID=" & CInt(LockerBL.Application_Type.ADMIN_WEB) & " AND Auth_ID>0"
        lblBadgeAdmin.Text = DT.DefaultView.Count
        DT.DefaultView.RowFilter = "App_ID=" & CInt(LockerBL.Application_Type.KIOSK_STAFF_CONSOLE) & " AND Auth_ID>0"
        lblBadgeStaffConsole.Text = DT.DefaultView.Count
        lblBadgeMember.Text = FormatNumber(CurrentSelectedUser.Rows.Count, 0)
    End Sub

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim td As HtmlTableCell = e.Item.FindControl("td")
        Dim lblRoleName As Label = e.Item.FindControl("lblRoleName")
        Dim lblAdmin As Label = e.Item.FindControl("lblAdmin")
        Dim lblStaffConsole As Label = e.Item.FindControl("lblStaffConsole")
        Dim lblMember As Label = e.Item.FindControl("lblMember")
        Dim btnEdit As Button = e.Item.FindControl("btnEdit")
        Dim btnDelete As Button = e.Item.FindControl("btnDelete")
        Dim cfmDelete As AjaxControlToolkit.ConfirmButtonExtender = e.Item.FindControl("cfmDelete")

        Dim ColEdit As HtmlTableCell = e.Item.FindControl("ColEdit")
        Dim ColDelete As HtmlTableCell = e.Item.FindControl("ColDelete")

        lblRoleName.Text = e.Item.DataItem("Role_Name").ToString
        If e.Item.DataItem("active_status").ToString = "N" Then
            td.Attributes("class") = "text-danger"
        Else
            td.Attributes("class") = "text-primary"
        End If
        If Not IsDBNull(e.Item.DataItem("Users")) Then
            lblMember.Text = FormatNumber(e.Item.DataItem("Users"), 0)
        End If
        If Not IsDBNull(e.Item.DataItem("Admin_Web")) Then
            lblAdmin.Text = FormatNumber(e.Item.DataItem("Admin_Web"), 0)
        End If
        If Not IsDBNull(e.Item.DataItem("Staff_Console")) Then
            lblStaffConsole.Text = FormatNumber(e.Item.DataItem("Staff_Console"), 0)
        End If
        btnEdit.CommandArgument = e.Item.DataItem("Role_ID")
        btnDelete.CommandArgument = e.Item.DataItem("Role_ID")

        'cfmDelete.ConfirmText = "Are you sure you want to delete '" & e.Item.DataItem("Role_Name").ToString.Replace("'", "''") & "'?"
        cfmDelete.ConfirmText = "Are you sure you want to delete '" & e.Item.DataItem("Role_Name").ToString() & "'?"


        'ColEdit.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
        'ColDelete.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
    End Sub

    Private Sub rptList_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptList.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                Dim Role_ID As Integer = e.CommandArgument
                Dim lblRoleName As Label = e.Item.FindControl("lblRoleName")
                Dim DT As DataTable = BL.GetList_Role(Role_ID)
                If DT.Rows.Count = 0 Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & lblRoleName.Text.Replace("'", """") & " is not found!');", True)
                    Exit Sub
                End If

                ClearEditForm()
                Edit_Role_ID = Role_ID

                txtRoleName.Text = DT.Rows(0).Item("Role_Name")

                '---------------- Bind AdminWeb ---------------
                BindRoleAdminWeb()

                '---------------- Bind Staff Console ---------------
                BindRoleStaffConsole()

                '---------------- Bind Members ---------------
                BindMember()

                ChangeTab(btnTabAdminWeb, Nothing)
                UpdateBadge()

                chkActive.Checked = IIf(DT.Rows(0).Item("active_status").ToString = "Y", True, False)
                lblEditMode.Text = "Edit"

                CloseAllDialog()

                pnlList.Visible = False
                pnlEdit.Visible = True

                SetControlViewOnly()
            Case "Delete"
                BL.Drop_Role(e.CommandArgument)
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
                txtRoleName.Enabled = False
                chkActive.Enabled = False
                btnSave.Visible = False

                For i As Integer = 0 To rptAdminWeb.Items.Count - 1
                    Dim _Item As RepeaterItem = rptAdminWeb.Items(i)
                    Dim rpt As Repeater = _Item.FindControl("rpt")
                    For j As Integer = 0 To rpt.Items.Count - 1
                        Dim Selector2 As ucAuthorizeSelector2 = rpt.Items(j).FindControl("Selector2")
                        Dim Selector3 As ucAuthorizeSelector3 = rpt.Items(j).FindControl("Selector3")

                        Selector2.IsEnable = False
                        Selector3.IsEnable = False
                    Next
                Next

                For i As Integer = 0 To rptStaffConsole.Items.Count - 1
                    Dim _Item As RepeaterItem = rptStaffConsole.Items(i)
                    Dim rpt As Repeater = _Item.FindControl("rpt")

                    For j As Integer = 0 To rpt.Items.Count - 1
                        Dim Selector2 As ucAuthorizeSelector2 = rpt.Items(j).FindControl("Selector2")
                        Dim Selector3 As ucAuthorizeSelector3 = rpt.Items(j).FindControl("Selector3")

                        Selector2.IsEnable = False
                        Selector3.IsEnable = False
                    Next
                Next

                For i As Integer = 0 To rptUser.Items.Count - 1
                    Dim btnDelete As LinkButton = rptUser.Items(i).FindControl("btnDelete")
                    btnDelete.Visible = False
                Next
                lnkAddMember.Visible = False
                lnkClearMember.Visible = False
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()
    End Sub

    Private Sub lnkClearMember_Click(sender As Object, e As EventArgs) Handles lnkClearMember.Click
        rptUser.DataSource = Nothing
        rptUser.DataBind()
    End Sub

    Private Sub btnCancelUser_Click(sender As Object, e As EventArgs) Handles btnCancelUser.Click
        pnlSelectUser.Visible = False
    End Sub


    Private Sub lnkAddMember_Click(sender As Object, e As EventArgs) Handles lnkAddMember.Click
        BindUnSelectedUser()
        txtBufferSearch.Text = ""
        'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "focus", "document.getElementById('" & txtNewUser.ClientID & "').focus();", True)
        pnlSelectUser.Visible = True
    End Sub

    Private Sub rptUnselectedUser_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptUnselectedUser.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim td As HtmlTableCell = e.Item.FindControl("td")
        Dim lbl As Label = e.Item.FindControl("lbl")
        Dim chk As CheckBox = e.Item.FindControl("chk")
        Dim btn As Button = e.Item.FindControl("btn")

        lbl.Text = e.Item.DataItem("username")
        td.Attributes("onclick") = "document.getElementById('" & btn.ClientID & "').click();"
        btn.CommandArgument = e.Item.DataItem("username")
        chk.Checked = e.Item.DataItem("Selected")
        SetDisplayUnSelectedItem(e.Item)
    End Sub

    Private Sub rptUnselectedUser_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptUnselectedUser.ItemCommand
        Select Case e.CommandName
            Case "Selected"
                Dim td As HtmlTableCell = e.Item.FindControl("td")
                Dim chk As CheckBox = e.Item.FindControl("chk")
                chk.Checked = Not chk.Checked
                SetDisplayUnSelectedItem(e.Item)
        End Select
    End Sub

    Private Sub SetDisplayUnSelectedItem(ByRef rptItem As RepeaterItem)
        Dim td As HtmlTableCell = rptItem.FindControl("td")
        Dim chk As CheckBox = rptItem.FindControl("chk")
        If chk.Checked Then
            td.Attributes("class") = "btn-primary"
        Else
            td.Attributes("class") = ""
        End If
    End Sub


    '---------- Merge Single User---------
    Private Function MergeUserTable(ByVal OldDT As DataTable, ByVal username As String) As DataTable
        OldDT.DefaultView.RowFilter = "username='" & username.Replace("'", "''") & "'"
        If OldDT.DefaultView.Count > 0 Then Return OldDT
        Dim DR As DataRow = OldDT.NewRow
        'DR("User_ID") = User_ID
        DR("username") = username
        If OldDT.Columns.IndexOf("Selected") > -1 Then DR("Selected") = True '---------- For UnSelectedLists
        OldDT.Rows.Add(DR)
        Return OldDT
    End Function

    '---------- Merge Multi User---------
    Private Function MergeUserTable(ByVal OldDT As DataTable, ByVal NewDT As DataTable) As DataTable
        For i As Integer = 0 To NewDT.Rows.Count - 1
            MergeUserTable(OldDT, NewDT.Rows(i).Item("username"))
        Next
        Return OldDT
    End Function


    Private Sub btnSelectUser_Click(sender As Object, e As EventArgs) Handles btnSelectUser.Click

        Dim NewSelUser As DataTable = CurrentUnSelectedUser()
        NewSelUser.DefaultView.RowFilter = "Selected = true"
        If NewSelUser.DefaultView.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Select user in the list\n\nPlease try again');", True)
            Exit Sub
        End If

        Dim SelUser As DataTable = CurrentSelectedUser()

        For i As Integer = 0 To NewSelUser.DefaultView.Count - 1
            SelUser.DefaultView.RowFilter = "username='" & NewSelUser.DefaultView(i).Item("username").ToString.Replace("'", "''") & "'"
            If SelUser.DefaultView.Count = 0 Then
                Dim DR As DataRow = SelUser.NewRow
                'DR("User_ID") = NewSelUser.DefaultView(i).Item("User_ID")
                DR("username") = NewSelUser.DefaultView(i).Item("username")
                SelUser.Rows.Add(DR)
            End If
        Next

        SelUser.DefaultView.RowFilter = ""
        rptUser.DataSource = SelUser
        rptUser.DataBind()

        pnlSelectUser.Visible = False

        UpdateBadge()
    End Sub

#Region "Tab"

    Protected Enum Tab
        Unknown = 0
        Admin = 1
        Kiosk = 2
        Member = 3
    End Enum

    Protected Property CurrentTab As Tab
        Get
            Select Case True
                Case tabAdminWeb.Visible
                    Return Tab.Admin
                Case tabStaffConsole.Visible
                    Return Tab.Kiosk
                Case tabMembers.Visible
                    Return Tab.Member
                Case Else
                    Return Tab.Unknown
            End Select
        End Get
        Set(value As Tab)
            tabAdminWeb.Visible = False
            tabStaffConsole.Visible = False
            tabMembers.Visible = False
            liTabAdminWeb.Attributes("class") = ""
            liTabStaffConsole.Attributes("class") = ""
            liTabMembers.Attributes("class") = ""

            Select Case value
                Case Tab.Admin
                    tabAdminWeb.Visible = True
                    liTabAdminWeb.Attributes("class") = "active"
                Case Tab.Kiosk
                    tabStaffConsole.Visible = True
                    liTabStaffConsole.Attributes("class") = "active"
                Case Tab.Member
                    tabMembers.Visible = True
                    liTabMembers.Attributes("class") = "active"
                Case Else
            End Select
        End Set
    End Property

    Private Sub ChangeTab(sender As Object, e As System.EventArgs) Handles btnTabAdminWeb.Click, btnTabStaffConsole.Click, btnTabMembers.Click
        Select Case True
            Case Equals(sender, btnTabAdminWeb)
                CurrentTab = Tab.Admin
            Case Equals(sender, btnTabStaffConsole)
                CurrentTab = Tab.Kiosk
            Case Equals(sender, btnTabMembers)
                CurrentTab = Tab.Member
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtRoleName.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert role name');", True)
            Exit Sub
        End If

        Dim DT As DataTable = BL.GetList_Role(0)
        DT.DefaultView.RowFilter = "Role_Name='" & txtRoleName.Text.Replace("'", "''") & "' AND Role_ID<>" & Edit_Role_ID
        If DT.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('This role name is already exists');", True)
            Exit Sub
        End If

        Dim trans As New ServerTransactionDB
        Try
            Dim ret As New ExecuteDataInfo
            Dim lnqrole As New MsRoleServerLinqDB
            With lnqrole
                .GetDataByPK(Edit_Role_ID, trans.Trans)
                .ROLE_NAME = txtRoleName.Text.Trim.Replace("'", "")
                .ACTIVE_STATUS = IIf(chkActive.Checked, "Y", "N")

                If .ID = 0 Then
                    ret = .InsertData(UserName, trans.Trans)
                Else
                    ret = .UpdateData(UserName, trans.Trans)
                End If

                If ret.IsSuccess = False Then
                    trans.RollbackTransaction()
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", "") & "');", True)
                    Exit Sub
                End If
            End With


            Dim p_rf(1) As SqlParameter
            p_rf(0) = ServerDB.SetInt("@_role_id", lnqrole.ID)
            ret = ServerDB.ExecuteNonQuery("delete from ms_role_functional where ms_role_id=@_role_id", trans.Trans, p_rf)
            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", "") & "');", True)
                Exit Sub
            End If

            Dim dt_rf As DataTable = CurrentFunctional()
            dt_rf.DefaultView.RowFilter = "Auth_ID>0"
            dt_rf = dt_rf.DefaultView.ToTable().Copy
            For i As Integer = 0 To dt_rf.Rows.Count - 1
                Dim functional_id As String = dt_rf.Rows(i).Item("FN_ID").ToString
                Dim auth_id As String = dt_rf.Rows(i).Item("Auth_ID").ToString
                Dim lnqrole_fuc As New MsRoleFunctionalServerLinqDB
                With lnqrole_fuc
                    .MS_ROLE_ID = lnqrole.ID
                    .MS_FUNCTIONAL_ID = functional_id
                    .MS_AUTHORIZATION_ID = auth_id
                    ret = .InsertData(UserName, trans.Trans)
                End With

                If ret.IsSuccess = False Then
                    trans.RollbackTransaction()
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", "") & "');", True)
                    Exit Sub
                End If
            Next

            Dim p_ur(1) As SqlParameter
            p_ur(0) = ServerDB.SetInt("@_role_id", lnqrole.ID)
            ret = ServerDB.ExecuteNonQuery("delete from ms_user_role where ms_role_id=@_role_id", trans.Trans, p_ur)
            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", "") & "');", True)
                Exit Sub
            End If
            Dim dt_ur As DataTable = CurrentSelectedUser()
            For i As Integer = 0 To dt_ur.Rows.Count - 1
                Dim _username As String = dt_ur.Rows(i)("username").ToString()
                Dim lnq_ur As New MsUserRoleServerLinqDB
                With lnq_ur
                    .USERNAME = _username
                    .MS_ROLE_ID = lnqrole.ID
                    ret = .InsertData(UserName, trans.Trans)

                    If ret.IsSuccess = False Then
                        trans.RollbackTransaction()
                        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", "") & "');", True)
                        Exit Sub
                    End If
                End With
            Next

            trans.CommitTransaction()
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Save success');", True)
            BindList()

        Catch ex As Exception
            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ex.ToString.Replace("'", "") & "');", True)
        End Try

    End Sub

#End Region


End Class