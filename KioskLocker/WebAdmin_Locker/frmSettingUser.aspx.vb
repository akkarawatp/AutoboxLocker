Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient

Public Class frmSettingUser
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 14
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


    Public Property Edit_User_Name As String
        Get
            Try
                Return ViewState("User_Name ")
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(value As String)
            ViewState("User_Name ") = value
        End Set
    End Property

    Public Property Edit_User_ID As Integer
        Get
            Try
                Return ViewState("User_ID ")
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(value As Integer)
            ViewState("User_ID ") = value
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
        End If
        initFormPlugin()

        txtPassword.Attributes.Add("value", txtPassword.Text)
        txtConfirmPassword.Attributes.Add("value", txtConfirmPassword.Text)
        BL.SetTextIntKeypress(txtMobileNo)
    End Sub

    'Protected Sub SetAuthorizedLevel(ByVal DT As DataTable)
    '    AuthorizedLevel = BL.GetFunctionalAuthorized(DT, FN_ID)
    'End Sub

    Private Sub initFormPlugin()
        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Plugin", "initFormPlugin(); resizeScreen(); initDataTable(); ", True)
    End Sub

    Private Sub BindList()
        'SysCode=ATB-Locker
        Try
            Dim DT As New DataTable
            DT = Engine.UserENG.GetListUser("", "", "", "", "", "")
            rptList.DataSource = DT
            rptList.DataBind()

            lblTotalList.Text = FormatNumber(DT.Rows.Count, 0)

            'ColEdit.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
            'ColDelete.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
            'btnAdd.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit

            pnlList.Visible = True
            pnlEdit.Visible = False


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
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        ClearEditForm()

        '---------------- Bind AdminWeb ---------------
        BindRole()

        '---------------- Bind Staff Console ---------------
        BindLocation()

        pnlList.Visible = False
        pnlEdit.Visible = True

    End Sub

    Private Sub ClearEditForm()
        Edit_User_Name = ""
        Edit_User_ID = 0

        txtAccountNo.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtCompanyName.Text = ""
        txtEmail.Text = ""
        txtMobileNo.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtConfirmPassword.Text = ""

        txtUsername.Enabled = True
        txtPassword.Enabled = True
        txtConfirmPassword.Enabled = True

        '------------- Bind Role --------------
        rptRole.DataSource = Nothing
        rptRole.DataBind()

        '------------- Bind Location ----------
        rptLocation.DataSource = Nothing
        rptLocation.DataBind()

        UpdateBadge()

        ChangeTab(btnTabRole, Nothing)

        chkActive.Checked = False
        lblEditMode.Text = "Add"

    End Sub

    Private Sub btnUpdateBadge_Click(sender As Object, e As EventArgs) Handles btnUpdateBadge.Click
        UpdateBadge()
    End Sub

    Private Sub UpdateBadge()
        Dim DT As DataTable = CurrentRole()
        DT.DefaultView.RowFilter = "Selected=true"
        lblBadgeRole.Text = DT.DefaultView.Count
        DT = CurrentLocation()
        DT.DefaultView.RowFilter = "Selected=true"
        lblBadgeLocation.Text = DT.DefaultView.Count
    End Sub

    Dim RT As DataTable
    Dim LT As DataTable
    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        BindList()
    End Sub

    Private Sub BindRole()
        RT = BL.GetList_User_Role(Edit_User_Name, "Y")
        rptRole.DataSource = RT
        rptRole.DataBind()
    End Sub

    Private Sub BindLocation()
        LT = BL.GetList_User_Location(Edit_User_Name, "Y")
        rptLocation.DataSource = LT
        rptLocation.DataBind()
    End Sub

    Private Sub rptLocation_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptLocation.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lbl As Label = e.Item.FindControl("lbl")
        Dim chk As CheckBox = e.Item.FindControl("chk")

        lbl.Text = e.Item.DataItem("location_name").ToString
        chk.Attributes("id") = e.Item.DataItem("id").ToString
        chk.Checked = IIf(e.Item.DataItem("Selected").ToString() = "Y", True, False)

        chk.Attributes("onchange") = "document.getElementById('" & btnUpdateBadge.ClientID & "').click();"
    End Sub

    Private Function CurrentLocation() As DataTable
        Dim DT As New DataTable
        DT.Columns.Add("id", GetType(String))
        DT.Columns.Add("location_name", GetType(String))
        DT.Columns.Add("Selected", GetType(Boolean))

        For Each Item As RepeaterItem In rptLocation.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim lbl As Label = Item.FindControl("lbl")
            Dim chk As CheckBox = Item.FindControl("chk")
            Dim DR As DataRow = DT.NewRow
            DR("id") = chk.Attributes("id")
            DR("location_name") = lbl.Text
            DR("Selected") = chk.Checked
            DT.Rows.Add(DR)
        Next
        Return DT
    End Function

    Private Sub rptRole_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptRole.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lbl As Label = e.Item.FindControl("lbl")
        Dim chk As CheckBox = e.Item.FindControl("chk")

        lbl.Text = e.Item.DataItem("role_name").ToString
        chk.Attributes("id") = e.Item.DataItem("id").ToString
        chk.Checked = IIf(e.Item.DataItem("Selected").ToString() = "Y", True, False)

        chk.Attributes("onchange") = "document.getElementById('" & btnUpdateBadge.ClientID & "').click();"
    End Sub

    Private Function CurrentRole() As DataTable
        Dim DT As New DataTable
        DT.Columns.Add("id", GetType(String))
        DT.Columns.Add("role_name", GetType(String))
        DT.Columns.Add("Selected", GetType(Boolean))

        For Each Item As RepeaterItem In rptRole.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim lbl As Label = Item.FindControl("lbl")
            Dim chk As CheckBox = Item.FindControl("chk")
            Dim DR As DataRow = DT.NewRow

            DR("id") = chk.Attributes("id")
            DR("role_name") = lbl.Text
            DR("Selected") = chk.Checked
            DT.Rows.Add(DR)
        Next
        Return DT
    End Function

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim td As HtmlTableCell = e.Item.FindControl("td")
        Dim lblUserName As Label = e.Item.FindControl("lblUserName")
        Dim lblROles As Label = e.Item.FindControl("lblROles")
        Dim lblLocation As Label = e.Item.FindControl("lblLocation")
        Dim btnEdit As Button = e.Item.FindControl("btnEdit")
        Dim btnDelete As Button = e.Item.FindControl("btnDelete")
        Dim cfmDelete As AjaxControlToolkit.ConfirmButtonExtender = e.Item.FindControl("cfmDelete")

        Dim ColEdit As HtmlTableCell = e.Item.FindControl("ColEdit")
        Dim ColDelete As HtmlTableCell = e.Item.FindControl("ColDelete")

        Dim current_username As String = e.Item.DataItem("username").ToString
        lblUserName.Text = current_username

        Dim p_u(1) As SqlParameter
        p_u(0) = ServerDB.SetText("@_user_name", current_username)
        Dim dtrole As New DataTable
        dtrole = ServerDB.ExecuteTable("select count(id) roles from ms_user_role where username = @_user_name", p_u)
        lblROles.Text = "0"
        If dtrole.Rows.Count > 0 Then
            lblROles.Text = dtrole.Rows(0)("roles")
        End If

        Dim p_l(0) As SqlParameter
        p_l(0) = ServerDB.SetText("@_user_name", current_username)
        Dim dtloc As New DataTable
        dtloc = ServerDB.ExecuteTable("select count(id) locations from ms_user_location where username = @_user_name", p_l)
        lblLocation.Text = "0"
        If dtloc.Rows.Count > 0 Then
            lblLocation.Text = dtloc.Rows(0)("Locations")
        End If

        btnEdit.CommandArgument = e.Item.DataItem("id")
        btnDelete.CommandArgument = e.Item.DataItem("id") '& "##" & e.Item.DataItem("username")
        cfmDelete.ConfirmText = "Are you sure you want to delete '" & e.Item.DataItem("username").ToString.Replace("'", "''") & "'?"

        If e.Item.DataItem("active_status").ToString = "N" Then
            td.Attributes("class") = "text-danger"
        Else
            td.Attributes("class") = "text-primary"
        End If

        'ColEdit.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
        'ColDelete.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit

    End Sub

    Private Sub rptList_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptList.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                Try
                    ClearEditForm()

                    Edit_User_ID = e.CommandArgument
                    Dim lblUserName As Label = e.Item.FindControl("lblUserName")
                    Dim DT As New DataTable
                    DT = Engine.UserENG.GetListUser("", "", "", "", lblUserName.Text, "")

                    If DT.Rows.Count = 0 Then
                        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & lblUserName.Text.Replace("'", """") & " is not found!');", True)
                        Exit Sub
                    End If

                    Edit_User_Name = DT.Rows(0).Item("username").ToString
                    txtAccountNo.Text = DT.Rows(0).Item("account_no").ToString
                    txtFirstName.Text = DT.Rows(0).Item("first_name").ToString
                    txtLastName.Text = DT.Rows(0).Item("last_name").ToString
                    txtCompanyName.Text = DT.Rows(0).Item("company_name").ToString
                    txtEmail.Text = DT.Rows(0).Item("Email").ToString
                    txtMobileNo.Text = DT.Rows(0).Item("Mobile_No").ToString
                    txtUsername.Text = DT.Rows(0).Item("username").ToString
                    txtUsername.Enabled = False
                    txtPassword.Enabled = False
                    txtConfirmPassword.Enabled = False

                    '------------- Bind Role --------------
                    BindRole()

                    '------------- Bind Location ----------
                    BindLocation()

                    UpdateBadge()

                    ChangeTab(btnTabRole, Nothing)

                    chkActive.Checked = IIf(DT.Rows(0).Item("active_status").ToString = "Y", True, False)

                    lblEditMode.Text = "Edit"
                    pnlList.Visible = False
                    pnlEdit.Visible = True

                    SetControlViewOnly()
                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Cant display');", True)
                End Try


            Case "Delete"
                Dim lblUserName As Label = e.Item.FindControl("lblUserName")
                Dim userid As Long = e.CommandArgument
                Dim username As String = lblUserName.Text

                If BL.Drop_User(userid, username) = False Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Cant delete user');", True)
                    Exit Sub
                End If
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
                txtFirstName.Enabled = False
                txtLastName.Enabled = False
                txtCompanyName.Enabled = False
                txtEmail.Enabled = False
                txtMobileNo.Enabled = False

                txtUsername.Enabled = False
                txtPassword.Enabled = False
                txtConfirmPassword.Enabled = False

                For i As Integer = 0 To rptRole.Items.Count - 1
                    Dim chk As CheckBox = rptRole.Items(i).FindControl("chk")
                    chk.Enabled = False
                Next

                For i As Integer = 0 To rptLocation.Items.Count - 1
                    Dim chk As CheckBox = rptLocation.Items(i).FindControl("chk")
                    chk.Enabled = False
                Next

                chkActive.Enabled = False
                btnSave.Visible = False

            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'If txtAccountNo.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Acount No');", True)
        '    Exit Sub
        'End If

        If txtUsername.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert User Name');", True)
            Exit Sub
        End If

        If Edit_User_ID = 0 Then
            If txtPassword.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Password');", True)
                Exit Sub
            End If

            If txtConfirmPassword.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Confirm Password');", True)
                Exit Sub
            End If

            If txtPassword.Text <> txtConfirmPassword.Text Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Your password and Confirm Password dont match');", True)
                Exit Sub
            End If
        End If

        Dim trans As New ServerTransactionDB
        Try
            Dim firstname As String = txtFirstName.Text.Replace("'", "")
            Dim lastname As String = txtLastName.Text.Replace("'", "")
            Dim companyname As String = txtCompanyName.Text.Replace("'", "")
            Dim accountno As String = txtAccountNo.Text.Replace("'", "")
            Dim email As String = txtEmail.Text.Replace("'", "")
            Dim mobileno As String = txtMobileNo.Text.Replace("'", "")
            Dim user_name As String = txtUsername.Text.Replace("'", "")
            Dim password As String = txtPassword.Text.Replace("'", "")
            Dim activestatus As String = IIf(chkActive.Checked, "Y", "N")

            Dim retdup As Boolean
            retdup = Engine.UserENG.CheckDuplicateUserAccount(user_name, Edit_User_ID)
            If retdup Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('This User Name is already existed');", True)
                Exit Sub
            End If

            '== ms_user_role
            Dim p_r(1) As SqlParameter
            p_r(0) = ServerDB.SetText("@_user_name", user_name)
            Dim ret_wa As ExecuteDataInfo
            ret_wa = ServerDB.ExecuteNonQuery("delete from ms_user_role where username=@_user_name", trans.Trans, p_r)

            If ret_wa.IsSuccess = False Then
                trans.RollbackTransaction()
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret_wa.ErrorMessage & "');", True)
                Exit Sub
            End If

            Dim dtrole As New DataTable
            dtrole = CurrentRole()
            dtrole.DefaultView.RowFilter = "Selected=true"
            dtrole = dtrole.DefaultView.ToTable.Copy
            For i As Integer = 0 To dtrole.Rows.Count - 1
                Dim role_id As String = dtrole.Rows(i)("id").ToString()
                Dim lnqrole As New MsUserRoleServerLinqDB
                With lnqrole
                    .MS_ROLE_ID = role_id
                    .USERNAME = user_name
                End With
                ret_wa = lnqrole.InsertData(UserName, trans.Trans)

                If ret_wa.IsSuccess = False Then
                    trans.RollbackTransaction()
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret_wa.ErrorMessage & "');", True)
                    Exit Sub
                End If
            Next


            '== ms_user_location
            Dim p_l(1) As SqlParameter
            p_l(0) = ServerDB.SetText("@_user_name", user_name)
            ret_wa = ServerDB.ExecuteNonQuery("delete from ms_user_location where username=@_user_name", trans.Trans, p_l)
            If ret_wa.IsSuccess = False Then
                trans.RollbackTransaction()
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret_wa.ErrorMessage & "');", True)
                Exit Sub
            End If

            Dim dtloc As New DataTable
            dtloc = CurrentLocation()
            dtloc.DefaultView.RowFilter = "Selected=true"
            dtloc = dtloc.DefaultView.ToTable.Copy
            For i As Integer = 0 To dtloc.Rows.Count - 1
                Dim loc_id As String = dtloc.Rows(i)("id").ToString()
                Dim lnqloc As New MsUserLocationServerLinqDB
                With lnqloc
                    .MS_LOCATION_ID = loc_id
                    .USERNAME = user_name
                End With
                ret_wa = lnqloc.InsertData(UserName, trans.Trans)

                If ret_wa.IsSuccess = False Then
                    trans.RollbackTransaction()
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret_wa.ErrorMessage & "');", True)
                    Exit Sub
                End If
            Next


            Dim ret_ws As ExecuteDataInfo
            If Edit_User_ID = 0 Then
                ret_ws = Engine.UserENG.InsertUserAccount(firstname, lastname, companyname, email, mobileno, user_name, password, activestatus)
            Else
                ret_ws = Engine.UserENG.EditUserAccount(Edit_User_ID, firstname, lastname, companyname, email, mobileno, activestatus)
            End If

            If ret_ws.IsSuccess = False Then
                trans.RollbackTransaction()
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret_ws.ErrorMessage & "');", True)
                Exit Sub
            End If


            trans.CommitTransaction()
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Save success');", True)
            BindList()
        Catch ex As Exception
            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Cant Save data');", True)
        End Try
    End Sub

#Region "Tab"
    Protected Enum Tab
        Unknown = 0
        Role = 1
        Locatoin = 2
    End Enum

    Protected Property CurrentTab As Tab
        Get
            Select Case True
                Case tabRole.Visible
                    Return Tab.Role
                Case tabLocation.Visible
                    Return Tab.Locatoin
                Case Else
                    Return Tab.Unknown
            End Select
        End Get
        Set(value As Tab)
            tabRole.Visible = False
            tabLocation.Visible = False
            liTabRole.Attributes("class") = ""
            liTabLocation.Attributes("class") = ""

            Select Case value
                Case Tab.Role
                    tabRole.Visible = True
                    liTabRole.Attributes("class") = "active"
                Case Tab.Locatoin
                    tabLocation.Visible = True
                    liTabLocation.Attributes("class") = "active"
                Case Else
            End Select
        End Set
    End Property

    Private Sub ChangeTab(sender As Object, e As System.EventArgs) Handles btnTabRole.Click, btnTabLocation.Click
        Select Case True
            Case Equals(sender, btnTabRole)
                CurrentTab = Tab.Role
            Case Equals(sender, btnTabLocation)
                CurrentTab = Tab.Locatoin
        End Select
    End Sub


#End Region


End Class