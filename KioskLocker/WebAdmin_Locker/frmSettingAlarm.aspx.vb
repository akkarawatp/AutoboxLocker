Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient

Public Class frmSettingAlarm
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 7
    Const FunctionalZoneID As Int16 = 3

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

        Dim IsViewOnly As Boolean = False
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
        BindKiosAlarmList(0)
        'BindServerAlarmList(0)
        'BindInterfaceAlarmList(0)

        pnlList.Visible = False
        pnlEdit.Visible = True
        'ChangeTab(btnTabKioskAlarm, e)
    End Sub

    Private Sub ClearEditForm()
        Edit_GRP_ID = 0

        txtGROUPCODE.Text = ""
        txtGROUPNAME.Text = ""

        rptKioskAlarm.DataSource = ""
        rptKioskAlarm.DataBind()

        rptComputerAlarm.DataSource = ""
        rptComputerAlarm.DataBind()

        rptEmailAlarm.DataSource = ""
        rptEmailAlarm.DataBind()

        chkActive.Checked = True
        lblEditMode.Text = "Add"
    End Sub

#Region "AlarmList"
    Private Sub BindList()
        Dim DT As DataTable = BL.GetList_Alarm_Group()
        rptList.DataSource = DT
        rptList.DataBind()

        'ColEdit.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
        'ColDelete.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
        'btnAdd.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit

        lblTotalList.Text = FormatNumber(DT.Rows.Count, 0)

        pnlList.Visible = True
        pnlEdit.Visible = False

        Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
        If ufDt Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End If

        Dim IsViewOnly As Boolean = False
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
        Dim lblGroupCode As Label = e.Item.FindControl("lblGroupCode")
        Dim lblGroupName As Label = e.Item.FindControl("lblGroupName")
        Dim lblCountAlarm As Label = e.Item.FindControl("lblCountAlarm")
        Dim lblCountEmail As Label = e.Item.FindControl("lblCountEmail")

        Dim btnEdit As Button = e.Item.FindControl("btnEdit")
        Dim ColEdit As HtmlTableCell = e.Item.FindControl("ColEdit")
        Dim btnDelete As Button = e.Item.FindControl("btnDelete")
        Dim cfmDelete As AjaxControlToolkit.ConfirmButtonExtender = e.Item.FindControl("cfmDelete")
        Dim ColDelete As HtmlTableCell = e.Item.FindControl("ColDelete")

        cfmDelete.ConfirmText = "Confirm to delete " & e.Item.DataItem("ALARM_GROUP_CODE").ToString & " ?"

        If Not IsNothing(e.Item.DataItem("ActiveStatus")) AndAlso Not IsDBNull(e.Item.DataItem("ActiveStatus")) AndAlso e.Item.DataItem("ActiveStatus") = "Y" Then
            td.Attributes("class") = "h5 text-green"
        Else
            td.Attributes("class") = "h5 text-danger"
        End If

        lblGroupCode.Text = e.Item.DataItem("ALARM_GROUP_CODE").ToString
        lblGroupName.Text = e.Item.DataItem("ALARM_GROUP_NAME").ToString
        lblCountAlarm.Text = e.Item.DataItem("COUNT_ALARM").ToString
        lblCountEmail.Text = e.Item.DataItem("COUNT_EMAIL").ToString

        btnEdit.CommandArgument = e.Item.DataItem("id")
        btnDelete.CommandArgument = e.Item.DataItem("id")
    End Sub

    Private Sub rptList_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptList.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                Dim GROUP_ID As String = e.CommandArgument
                Dim DT As DataTable = BL.Get_Alarm_Group_Info(GROUP_ID)
                Dim lblGroupCode As Label = e.Item.FindControl("lblGroupCode")
                If DT.Rows.Count = 0 Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & lblGroupCode.Text.Replace("'", """") & " is not found!');", True)
                    Exit Sub
                End If

                ClearEditForm()
                Edit_GRP_ID = GROUP_ID

                txtGROUPCODE.Text = DT.Rows(0).Item("ALARM_GROUP_CODE").ToString
                txtGROUPNAME.Text = DT.Rows(0).Item("ALARM_GROUP_NAME").ToString
                chkActive.Checked = IIf(DT.Rows(0).Item("ACTIVESTATUS").ToString = "Y", True, False)

                BindKiosAlarmList(GROUP_ID)
                'BindServerAlarmList(GROUP_ID)
                'BindInterfaceAlarmList(GROUP_ID)
                BindComputerAlarmList(GROUP_ID)
                'BindMobileAlarmList(GROUP_ID)
                BindEmailAlarmList(GROUP_ID)

                lblEditMode.Text = "Edit"

                pnlList.Visible = False
                pnlEdit.Visible = True


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
                        chkActive.Enabled = False
                        btnSave.Visible = False

                        'Disable Alarm List
                        chkHeadKioskAlarm.Enabled = False
                        For i As Integer = 0 To rptKioskAlarm.Items.Count - 1
                            Dim chkItemKioskAlarm As CheckBox = rptKioskAlarm.Items(i).FindControl("chkItemKioskAlarm")
                            If chkItemKioskAlarm IsNot Nothing Then
                                chkItemKioskAlarm.Enabled = False
                            End If
                        Next
                        lnkAddNewComputer.Visible = False

                        'Disable Computer Alarm
                        For i As Integer = 0 To rptComputerAlarm.Items.Count - 1
                            Dim txtMAC1 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC1")
                            Dim txtMAC2 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC2")
                            Dim txtMAC3 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC3")
                            Dim txtMAC4 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC4")
                            Dim txtMAC5 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC5")
                            Dim txtMAC6 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC6")
                            Dim btnDeleteComputer As Button = rptComputerAlarm.Items(i).FindControl("btnDeleteComputer")

                            txtMAC1.Enabled = False
                            txtMAC2.Enabled = False
                            txtMAC3.Enabled = False
                            txtMAC4.Enabled = False
                            txtMAC5.Enabled = False
                            txtMAC6.Enabled = False
                            btnDeleteComputer.Enabled = False
                        Next
                        lnkAddNewEmail.Visible = False

                        'Disable Email Alarm
                        For i As Integer = 0 To rptEmailAlarm.Items.Count - 1
                            Dim txtEmail As TextBox = rptEmailAlarm.Items(i).FindControl("txtEmail")
                            Dim btnDeleteEmail As Button = rptEmailAlarm.Items(i).FindControl("btnDeleteEmail")

                            txtEmail.Enabled = False
                            btnDeleteEmail.Enabled = False
                        Next
                    End If
                    auDt.Dispose()
                End If
                ufDt.Dispose()
            Case "Delete"
                BL.Drop_Alarm(e.CommandArgument)
                BindList()
        End Select
    End Sub
#End Region

#Region "Kiosk Alarm"
    Private Sub BindKiosAlarmList(GROUP_ID As Integer)
        Dim DT As DataTable = BL.GetList_Kiosk_Alarm(GROUP_ID)
        rptKioskAlarm.DataSource = DT
        rptKioskAlarm.DataBind()
    End Sub

    Private Sub rptKioskAlarm_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptKioskAlarm.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim chkItemKioskAlarm As CheckBox = e.Item.FindControl("chkItemKioskAlarm")
        Dim lblKioskAlamID As Label = e.Item.FindControl("lblKioskAlamID")
        Dim lblKioskAlarmCode As Label = e.Item.FindControl("lblKioskAlarmCode")
        Dim lblKioskAlarmProblem As Label = e.Item.FindControl("lblKioskAlarmProblem")
        Dim lblKioskEngDesc As Label = e.Item.FindControl("lblKioskEngDesc")
        Dim lblKioskSMSMessage As Label = e.Item.FindControl("lblKioskSMSMessage")

        chkItemKioskAlarm.Checked = False
        If e.Item.DataItem("SELECTED").ToString = "T" Then
            chkItemKioskAlarm.Checked = True
        End If

        lblKioskAlamID.Text = e.Item.DataItem("ID").ToString
        lblKioskAlarmCode.Text = e.Item.DataItem("ALARM_CODE").ToString
        lblKioskAlarmProblem.Text = e.Item.DataItem("ALARM_PROBLEM").ToString
        lblKioskEngDesc.Text = e.Item.DataItem("ENG_DESC").ToString
        lblKioskSMSMessage.Text = e.Item.DataItem("SMS_MESSAGE").ToString
    End Sub

    Private Sub btnCheckKioskAll_Click(sender As Object, e As EventArgs) Handles btnCheckKioskAll.Click
        For i As Integer = 0 To rptKioskAlarm.Items.Count - 1
            Dim chkItemKioskAlarm As CheckBox = rptKioskAlarm.Items(i).FindControl("chkItemKioskAlarm")
            chkItemKioskAlarm.Checked = Not chkHeadKioskAlarm.Checked
        Next
        chkHeadKioskAlarm.Checked = Not chkHeadKioskAlarm.Checked
    End Sub
#End Region

#Region "Computer Alarm"
    Private Sub BindComputerAlarmList(GROUP_ID As Integer)
        Dim DT As DataTable = BL.Get_Computer_Alarm_ByGroup(GROUP_ID)

        Dim dt_computer As New DataTable
        With dt_computer
            .Columns.Add("MAC1")
            .Columns.Add("MAC2")
            .Columns.Add("MAC3")
            .Columns.Add("MAC4")
            .Columns.Add("MAC5")
            .Columns.Add("MAC6")
        End With
        Dim dr_computer As DataRow
        If DT.Rows.Count > 0 Then
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim macaddress() As String = DT.Rows(i).Item("MACADDRESS").ToString.Split("-")
                If macaddress.Length = 6 Then
                    dr_computer = dt_computer.NewRow
                    dr_computer("MAC1") = macaddress(0)
                    dr_computer("MAC2") = macaddress(1)
                    dr_computer("MAC3") = macaddress(2)
                    dr_computer("MAC4") = macaddress(3)
                    dr_computer("MAC5") = macaddress(4)
                    dr_computer("MAC6") = macaddress(5)
                    dt_computer.Rows.Add(dr_computer)
                End If
            Next
        End If

        rptComputerAlarm.DataSource = dt_computer
        rptComputerAlarm.DataBind()
    End Sub
    Protected Function CurrentComputerAlarmList() As DataTable
        Dim DT As New DataTable
        DT.Columns.Add("MAC1")
        DT.Columns.Add("MAC2")
        DT.Columns.Add("MAC3")
        DT.Columns.Add("MAC4")
        DT.Columns.Add("MAC5")
        DT.Columns.Add("MAC6")

        For Each Item As RepeaterItem In rptComputerAlarm.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim DR As DataRow = DT.NewRow
            Dim txtMAC1 As TextBox = Item.FindControl("txtMAC1")
            Dim txtMAC2 As TextBox = Item.FindControl("txtMAC2")
            Dim txtMAC3 As TextBox = Item.FindControl("txtMAC3")
            Dim txtMAC4 As TextBox = Item.FindControl("txtMAC4")
            Dim txtMAC5 As TextBox = Item.FindControl("txtMAC5")
            Dim txtMAC6 As TextBox = Item.FindControl("txtMAC6")
            DT.Rows.Add(DR)

            DR("MAC1") = txtMAC1.Text
            DR("MAC2") = txtMAC2.Text
            DR("MAC3") = txtMAC3.Text
            DR("MAC4") = txtMAC4.Text
            DR("MAC5") = txtMAC5.Text
            DR("MAC6") = txtMAC6.Text
            DT.AcceptChanges()
        Next

        Return DT
    End Function
    Private Sub rptComputerAlarm_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptComputerAlarm.ItemCommand
        Select Case e.CommandName
            Case "Delete"
                Dim DT As DataTable = CurrentComputerAlarmList()
                Try
                    DT.Rows(e.Item.ItemIndex).Delete()
                    DT.AcceptChanges()
                Catch : End Try
                rptComputerAlarm.DataSource = DT
                rptComputerAlarm.DataBind()
        End Select
    End Sub

    Private Sub rptComputerAlarm_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptComputerAlarm.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim txtMAC1 As TextBox = e.Item.FindControl("txtMAC1")
        Dim txtMAC2 As TextBox = e.Item.FindControl("txtMAC2")
        Dim txtMAC3 As TextBox = e.Item.FindControl("txtMAC3")
        Dim txtMAC4 As TextBox = e.Item.FindControl("txtMAC4")
        Dim txtMAC5 As TextBox = e.Item.FindControl("txtMAC5")
        Dim txtMAC6 As TextBox = e.Item.FindControl("txtMAC6")
        Dim lblNo As Label = e.Item.FindControl("lblNo")
        Dim ColDelete As HtmlTableCell = e.Item.FindControl("ColDelete")

        lblNo.Text = e.Item.ItemIndex + 1
        If Not IsDBNull(e.Item.DataItem("MAC1")) Then
            txtMAC1.Text = e.Item.DataItem("MAC1")
        End If
        If Not IsDBNull(e.Item.DataItem("MAC2")) Then
            txtMAC2.Text = e.Item.DataItem("MAC2")
        End If
        If Not IsDBNull(e.Item.DataItem("MAC3")) Then
            txtMAC3.Text = e.Item.DataItem("MAC3")
        End If
        If Not IsDBNull(e.Item.DataItem("MAC4")) Then
            txtMAC4.Text = e.Item.DataItem("MAC4")
        End If
        If Not IsDBNull(e.Item.DataItem("MAC5")) Then
            txtMAC5.Text = e.Item.DataItem("MAC5")
        End If
        If Not IsDBNull(e.Item.DataItem("MAC6")) Then
            txtMAC6.Text = e.Item.DataItem("MAC6")
        End If

    End Sub

    Private Sub lnkAddNewComputer_Click(sender As Object, e As System.EventArgs) Handles lnkAddNewComputer.Click
        Dim DT As DataTable = CurrentComputerAlarmList()
        DT.Rows.Add()
        rptComputerAlarm.DataSource = DT
        rptComputerAlarm.DataBind()
    End Sub

#End Region

#Region "Email Alarm"
    Private Sub BindEmailAlarmList(GROUP_ID As Integer)
        Dim DT As DataTable = BL.Get_Email_Alarm_ByGroup(GROUP_ID)
        rptEmailAlarm.DataSource = DT
        rptEmailAlarm.DataBind()
    End Sub
    Protected Function CurrentEmailAlarmList() As DataTable
        Dim DT As New DataTable
        DT.Columns.Add("E_MAIL")

        For Each Item As RepeaterItem In rptEmailAlarm.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim DR As DataRow = DT.NewRow
            Dim txtEmail As TextBox = Item.FindControl("txtEmail")

            DT.Rows.Add(DR)
            If txtEmail.Text.Trim <> "" Then
                DR("E_MAIL") = txtEmail.Text
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
        If Not IsDBNull(e.Item.DataItem("E_MAIL")) Then
            txtEmail.Text = e.Item.DataItem("E_MAIL").ToString
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
        Dim lnqAlGroup As New TbAlarmGroupServerLinqDB
        If lnqAlGroup.ChkDuplicateByALARM_GROUP_CODE(txtGROUPCODE.Text.Trim, Edit_GRP_ID, trans.Trans) Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('This Alarm Group is already existed');", True)
            Exit Sub
        End If

        Dim group_id As String = Edit_GRP_ID
        Dim group_code As String = txtGROUPCODE.Text.Trim.Replace("'", "")
        Dim group_name As String = txtGROUPNAME.Text.Trim.Replace("'", "")
        Dim active_status As String = IIf(chkActive.Checked = True, "Y", "N")
        Dim user_name As String = Session("USER_ID")

        Dim dt_kiosk As New DataTable
        dt_kiosk.TableName = "TBKiosk"
        Dim dr_kiosk As DataRow
        dt_kiosk.Columns.Add("ID")
        dt_kiosk.Columns.Add("alarm_code")
        For i As Integer = 0 To rptKioskAlarm.Items.Count - 1
            Dim chkItemKioskAlarm As CheckBox = rptKioskAlarm.Items(i).FindControl("chkItemKioskAlarm")
            If chkItemKioskAlarm.Checked = True Then
                Dim lblKioskAlamID As Label = rptKioskAlarm.Items(i).FindControl("lblKioskAlamID")
                Dim lblKioskAlarmCode As Label = rptKioskAlarm.Items(i).FindControl("lblKioskAlarmCode")
                dr_kiosk = dt_kiosk.NewRow
                dr_kiosk("ID") = lblKioskAlamID.Text
                dr_kiosk("ALARM_CODE") = lblKioskAlarmCode.Text
                dt_kiosk.Rows.Add(dr_kiosk)
            End If
        Next

        Dim dt_computer As New DataTable
        dt_computer.TableName = "TBComputer"
        dt_computer.Columns.Add("MACADDRESS")
        Dim dr_computer As DataRow
        For i As Integer = 0 To rptComputerAlarm.Items.Count - 1
            Dim txtMAC1 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC1")
            Dim txtMAC2 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC2")
            Dim txtMAC3 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC3")
            Dim txtMAC4 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC4")
            Dim txtMAC5 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC5")
            Dim txtMAC6 As TextBox = rptComputerAlarm.Items(i).FindControl("txtMAC6")
            If txtMAC1.Text <> "" And txtMAC2.Text <> "" And txtMAC3.Text <> "" And txtMAC4.Text <> "" And txtMAC5.Text <> "" And txtMAC6.Text <> "" Then
                dr_computer = dt_computer.NewRow
                dr_computer("MACADDRESS") = txtMAC1.Text.ToUpper & "-" & txtMAC2.Text.ToUpper & "-" & txtMAC3.Text.ToUpper & "-" & txtMAC4.Text.ToUpper & "-" & txtMAC5.Text.ToUpper & "-" & txtMAC6.Text.ToUpper
                dt_computer.Rows.Add(dr_computer)
            End If
        Next

        Dim dt_email As New DataTable
        dt_email.TableName = "TBEmail"
        dt_email.Columns.Add("E_MAIL")
        Dim dr_email As DataRow
        For i As Integer = 0 To rptEmailAlarm.Items.Count - 1
            Dim txtEmail As TextBox = rptEmailAlarm.Items(i).FindControl("txtEmail")
            If txtEmail.Text <> "" Then
                dr_email = dt_email.NewRow
                dr_email("E_MAIL") = txtEmail.Text
                dt_email.Rows.Add(dr_email)
            End If
        Next

        Dim ret As String = InsertEdit_Setting_Alarm(group_id, group_code, group_name, active_status, dt_kiosk, dt_computer, dt_email, user_name)
        If ret = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Save success');", True)
            BindList()
        Else
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Can't Save Data');", True)
        End If

    End Sub

    Public Function InsertEdit_Setting_Alarm(ByVal GROUP_ID As Integer, GROUP_CODE As String, GROUP_NAME As String, ACTIVE_STATUS As String, DT_KIOSK As DataTable,
                                            DT_COMPUTER As DataTable, DT_EMAIL As DataTable, USER_NAME As String) As String
        Dim trans As New ServerTransactionDB
        Try
            '=== TB_ALARM_GROUP
            Dim lnqAlGroup As New TbAlarmGroupServerLinqDB
            lnqAlGroup.GetDataByPK(Edit_GRP_ID, trans.Trans)
            With lnqAlGroup
                .ALARM_GROUP_CODE = txtGROUPCODE.Text.Replace("'", "")
                .ALARM_GROUP_NAME = txtGROUPNAME.Text.Replace("'", "")
                .ACTIVESTATUS = IIf(chkActive.Checked, "Y", "N")
            End With
            Dim ret As ExecuteDataInfo
            If lnqAlGroup.ID > 0 Then
                ret = lnqAlGroup.UpdateData(UserName, trans.Trans)
            Else
                ret = lnqAlGroup.InsertData(UserName, trans.Trans)
            End If

            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
                Return ret.ErrorMessage
            End If

            '=== TB_ALARM_GROUP_MONITORING
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetText("@_GROUP_ID", lnqAlGroup.ID)
            ret = ServerDB.ExecuteNonQuery("DELETE FROM TB_ALARM_GROUP_MONITORING WHERE TB_ALARM_GROUP_ID=@_GROUP_ID", p)

            If ret.IsSuccess = True AndAlso DT_KIOSK.Rows.Count > 0 Then
                For i As Integer = 0 To DT_KIOSK.Rows.Count - 1
                    With DT_KIOSK
                        Dim alarm_id As String = .Rows(i)("ID").ToString
                        Dim lnqAlGroupMonitoring = New TbAlarmGroupMonitoringServerLinqDB

                        With lnqAlGroupMonitoring
                            .TB_ALARM_GROUP_ID = lnqAlGroup.ID
                            .MS_MASTER_MONITORING_ALARM_ID = alarm_id
                        End With

                        Dim d_ret As New ExecuteDataInfo
                        d_ret = lnqAlGroupMonitoring.InsertData(UserName, trans.Trans)

                        If d_ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & d_ret.ErrorMessage & "');", True)
                            Return d_ret.ErrorMessage
                        End If

                        lnqAlGroupMonitoring = Nothing
                    End With

                Next
            End If

            '===TB_ALARM_GROUP_COMPUTER
            Dim p_c(1) As SqlParameter
            p_c(0) = ServerDB.SetText("@_GROUP_ID", lnqAlGroup.ID)
            ret = ServerDB.ExecuteNonQuery("DELETE FROM TB_ALARM_GROUP_COMPUTER WHERE TB_ALARM_GROUP_ID=@_GROUP_ID", p_c)

            If ret.IsSuccess = True AndAlso DT_COMPUTER.Rows.Count > 0 Then
                For i As Integer = 0 To DT_COMPUTER.Rows.Count - 1
                    With DT_COMPUTER
                        Dim mac_address As String = .Rows(i)("MACADDRESS").ToString
                        Dim lnqAlGroupComputer = New TbAlarmGroupComputerServerLinqDB

                        With lnqAlGroupComputer
                            .TB_ALARM_GROUP_ID = lnqAlGroup.ID
                            .MACADDRESS = mac_address
                        End With

                        Dim d_ret As New ExecuteDataInfo
                        d_ret = lnqAlGroupComputer.InsertData(UserName, trans.Trans)

                        If d_ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & d_ret.ErrorMessage & "');", True)
                            Return d_ret.ErrorMessage
                        End If

                        lnqAlGroupComputer = Nothing
                    End With
                Next
            End If

            '===TB_ALARM_GROUP_EMAIL
            Dim p_e(1) As SqlParameter
            p_e(0) = ServerDB.SetText("@_GROUP_ID", lnqAlGroup.ID)
            ret = ServerDB.ExecuteNonQuery("DELETE FROM TB_ALARM_GROUP_EMAIL WHERE TB_ALARM_GROUP_ID=@_GROUP_ID", p_e)

            If ret.IsSuccess = True AndAlso DT_EMAIL.Rows.Count > 0 Then
                For i As Integer = 0 To DT_EMAIL.Rows.Count - 1
                    With DT_EMAIL
                        Dim e_mail As String = .Rows(i)("E_MAIL").ToString
                        Dim lnqAlGroupEmail = New TbAlarmGroupEmailServerLinqDB

                        With lnqAlGroupEmail
                            .TB_ALARM_GROUP_ID = lnqAlGroup.ID
                            .E_MAIL = e_mail
                        End With

                        Dim d_ret As New ExecuteDataInfo
                        d_ret = lnqAlGroupEmail.InsertData(UserName, trans.Trans)

                        If d_ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & d_ret.ErrorMessage & "');", True)
                            Return d_ret.ErrorMessage
                        End If

                        lnqAlGroupEmail = Nothing
                    End With
                Next
            End If

            Dim ws As New AlarmWebService.ApplicationWebservice
            ws.Url = BL.GetServerSysconfig.ALARM_WEBSERVICE_URL
            ws.Timeout = 25000
            Dim wsRet As String = ws.SendMasterAlarmGroup("ATB-Locker", UserName, lnqAlGroup.ALARM_GROUP_CODE, lnqAlGroup.ALARM_GROUP_NAME, lnqAlGroup.ACTIVESTATUS, DT_COMPUTER, DT_KIOSK, DT_EMAIL)
            If wsRet = "true" Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()

                Return wsRet
            End If
            ws.Dispose()

            lnqAlGroup = Nothing
            Return ""
        Catch ex As Exception
            trans.RollbackTransaction()
            Return ex.ToString()
        End Try
    End Function


End Class