Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient
Partial Class frmSettingPromotions
    Inherits System.Web.UI.Page
    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 27
    Const FunctionalZoneID As Int16 = 4

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

    'Protected Sub SetAuthorizedLevel(ByVal DT As DataTable)
    '    'AuthorizedLevel = BL.GetFunctionalAuthorized(DT, FN_ID)
    'End Sub

    Private Sub initFormPlugin()
        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Plugin", "initFormPlugin(); ", True)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        ClearEditForm()
        BindPromotionHourList(0)
        BindCabinetModel()
        BindHourList()
        BindLocationList(0)

        pnlList.Visible = False
        pnlEdit.Visible = True
        ChangeTab(btnTabServiceRate, e)
    End Sub

    Private Sub ClearEditForm()
        Edit_GRP_ID = 0

        txtPROMOTIONCODE.Text = ""
        txtPROMOTIONNAME.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""

        BindPromotionHourList(0)
        BindCabinetModel()
        BindHourList()
        BindLocationList(0)

        'chkActive.Checked = False
        lblEditMode.Text = "Add"
    End Sub

    Private Sub BindList()
        Dim DT As DataTable = BL.GetList_Promotion()
        rptList.DataSource = DT
        rptList.DataBind()

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
                    Dim btnPublish As Button = rptList.Items(i).FindControl("btnPublish")
                    Dim btnDelete As Button = rptList.Items(i).FindControl("btnDelete")
                    btnEdit.Text = "View"

                    btnPublish.Enabled = False
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
        Dim lblPromotionCode As Label = e.Item.FindControl("lblPromotionCode")
        Dim lblPromotionName As Label = e.Item.FindControl("lblPromotionName")
        Dim lblCountLocation As Label = e.Item.FindControl("lblCountLocation")
        Dim lblPeriod As Label = e.Item.FindControl("lblPeriod")

        Dim btnEdit As Button = e.Item.FindControl("btnEdit")
        Dim ColEdit As HtmlTableCell = e.Item.FindControl("ColEdit")

        Dim btnPublish As Button = e.Item.FindControl("btnPublish")
        Dim ColPublish As HtmlTableCell = e.Item.FindControl("ColPublish")

        Dim btnDelete As Button = e.Item.FindControl("btnDelete")
        Dim cfmDelete As AjaxControlToolkit.ConfirmButtonExtender = e.Item.FindControl("cfmDelete")
        Dim ColDelete As HtmlTableCell = e.Item.FindControl("ColDelete")

        cfmDelete.ConfirmText = "Confirm to delete " & e.Item.DataItem("PROMOTION_CODE").ToString & " ?"

        lblPromotionCode.Text = e.Item.DataItem("PROMOTION_CODE").ToString
        lblPromotionName.Text = e.Item.DataItem("PROMOTION_NAME").ToString
        lblCountLocation.Text = e.Item.DataItem("COUNT_LOCATION").ToString
        lblPeriod.Text = e.Item.DataItem("PeriodDate").ToString

        btnEdit.CommandArgument = e.Item.DataItem("id")
        btnPublish.CommandArgument = e.Item.DataItem("id")
        btnDelete.CommandArgument = e.Item.DataItem("id")

        Dim IsPublish As String = e.Item.DataItem("publish_status").ToString
        Dim IsExpire As String = e.Item.DataItem("isExpire").ToString()
        If IsExpire = "1" Or IsPublish = "1" Then
            btnEdit.Text = "View"
            btnPublish.Visible = False
            btnDelete.Visible = False
        Else
            btnEdit.Text = "Edit"
            btnPublish.Visible = True
            btnDelete.Visible = True
        End If
    End Sub

    Dim cmDt As DataTable
    Dim hourDt As DataTable
    Dim proHourDt As DataTable

    Private Sub BindHourList()
        hourDt = BL.GetHourList()
        rptServiceRateHour.DataSource = hourDt
        rptServiceRateHour.DataBind()
    End Sub

    Private Sub BindPromotionHourList(Promotion_ID As Integer)
        proHourDt = BL.GetServiceRatePromotionHour(Promotion_ID)
    End Sub

    Private Sub BindCabinetModel()
        cmDt = BL.getDataCabinetModel()
        rptRateHeadModel.DataSource = cmDt
        rptRateHeadModel.DataBind()
    End Sub

    Private Sub rptList_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptList.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                Dim PROMOTION_ID As String = e.CommandArgument
                Dim DT As DataTable = BL.Get_Promotion_Info(PROMOTION_ID)
                Dim lblPromotionCode As Label = e.Item.FindControl("lblPromotionCode")
                If DT.Rows.Count = 0 Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & lblPromotionCode.Text.Replace("'", """") & " is not found!');", True)
                    Exit Sub
                End If

                ClearEditForm()
                Edit_GRP_ID = PROMOTION_ID

                txtPROMOTIONCODE.Text = DT.Rows(0).Item("PROMOTION_CODE").ToString
                txtPROMOTIONNAME.Text = DT.Rows(0).Item("PROMOTION_NAME").ToString

                txtStartDate.Text = Convert.ToDateTime(DT.Rows(0).Item("Start_Date")).ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
                txtEndDate.Text = Convert.ToDateTime(DT.Rows(0).Item("End_Date")).ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))

                BindPromotionHourList(PROMOTION_ID)
                BindCabinetModel()
                BindHourList()
                BindLocationList(PROMOTION_ID)

                lblEditMode.Text = "Edit"
                pnlList.Visible = False
                pnlEdit.Visible = True

                EnableControl(True)
                Dim IsPublish As String = DT.Rows(0).Item("publish_status").ToString
                Dim IsExpire As String = DT.Rows(0).Item("isExpire").ToString


                'ตรวจสอบสิทธิ์การแก้ไขข้อมูล
                Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
                If ufDt Is Nothing Then
                    Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
                End If
                If ufDt.Rows.Count > 0 Then
                    Dim auDt As DataTable = BL.GetList_User_Functional(2, FunctionalZoneID, FunctionalID, Session("Username"))
                    If auDt.Rows.Count = 0 Then

                        EnableControl(False)

                    End If
                    auDt.Dispose()
                End If
                ufDt.Dispose()

                If IsExpire = "1" Or IsPublish = "1" Then
                    EnableControl(False)
                End If

            Case "Delete"
                Dim PROMOTION_ID As String = e.CommandArgument
                BL.Drop_Promotion(PROMOTION_ID)
                BindList()

            Case "Publish"
                Dim PROMOTION_ID As String = e.CommandArgument
                If BL.Update_Publish_Status(PROMOTION_ID) = False Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Cant Publish This Promotion!');", True)
                    Exit Sub
                End If
                BindList()
        End Select

        CurrentTab = Tab.ServiceRate
    End Sub

    Sub EnableControl(IsEnable As Boolean)
        txtPROMOTIONCODE.Enabled = IsEnable
        txtPROMOTIONNAME.Enabled = IsEnable
        txtStartDate.Enabled = IsEnable
        txtEndDate.Enabled = IsEnable
        'chkActive.Enabled = False
        btnSave.Visible = IsEnable

        chkHeadLocation.Enabled = False
        For i As Integer = 0 To rptLocationList.Items.Count - 1
            Dim chkItemLocation As CheckBox = rptLocationList.Items(i).FindControl("chkItemLocation")
            If chkItemLocation IsNot Nothing Then
                chkItemLocation.Enabled = IsEnable
                chkHeadLocation.Enabled = IsEnable
            End If
        Next

        For i As Integer = 0 To rptServiceRateHour.Items.Count - 1
            Dim rptRateHourModel As Repeater = rptServiceRateHour.Items(i).FindControl("rptRateHourModel")
            For j As Integer = 0 To rptRateHourModel.Items.Count - 1
                Dim txtServiceRate As TextBox = rptRateHourModel.Items(j).FindControl("txtServiceRate")
                txtServiceRate.Enabled = IsEnable
            Next
        Next
    End Sub

    Private Sub rptRateHeadModel_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptRateHeadModel.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblRateHeadModelName As Label = e.Item.FindControl("lblRateHeadModelName")
        lblRateHeadModelName.Text = e.Item.DataItem("model_name")
    End Sub

    Private Sub rptServiceRateHour_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptServiceRateHour.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblServiceRateHour As Label = e.Item.FindControl("lblServiceRateHour")
        Dim rptRateHourModel As Repeater = e.Item.FindControl("rptRateHourModel")
        AddHandler rptRateHourModel.ItemDataBound, AddressOf rptRateHourModel_ItemDataBound

        lblServiceRateHour.Text = e.Item.DataItem("HOUR")
        rptRateHourModel.DataSource = cmDt
        rptRateHourModel.DataBind()
    End Sub

    Private Sub rptRateHourModel_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblServiceRateHour As Label = e.Item.Parent.Parent.FindControl("lblServiceRateHour")
        Dim lblHourCabinetModelID As Label = e.Item.FindControl("lblHourCabinetModelID")
        Dim txtServiceRate As TextBox = e.Item.FindControl("txtServiceRate")
        BL.SetTextIntKeypress(txtServiceRate)
        txtServiceRate.Text = "0"

        lblHourCabinetModelID.Text = e.Item.DataItem("id")
        If proHourDt.Rows.Count > 0 Then
            proHourDt.DefaultView.RowFilter = "promotion_hour='" & lblServiceRateHour.Text & "' and ms_cabinet_model_id='" & lblHourCabinetModelID.Text & "'"
            If proHourDt.DefaultView.Count > 0 Then
                txtServiceRate.Text = proHourDt.DefaultView(0)("service_rate")
            End If
            proHourDt.DefaultView.RowFilter = ""
        End If
    End Sub


#Region "Location"
    Private Sub BindLocationList(Promotion_ID As Integer)
        Dim DT As DataTable = BL.GetList_Promotion_Location(Promotion_ID)
        rptLocationList.DataSource = DT
        rptLocationList.DataBind()
    End Sub

    Private Sub rptLocationList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptLocationList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim chkItemLocation As CheckBox = e.Item.FindControl("chkItemLocation")
        Dim lblLocationID As Label = e.Item.FindControl("lblLocationID")
        Dim lblLocationName As Label = e.Item.FindControl("lblLocationName")

        chkItemLocation.Checked = False
        If e.Item.DataItem("SELECTED").ToString = "T" Then
            chkItemLocation.Checked = True
        End If

        lblLocationID.Text = e.Item.DataItem("ID").ToString
        lblLocationName.Text = e.Item.DataItem("LOCATION_NAME").ToString
    End Sub

    Private Sub btnCheckLocationAll_Click(sender As Object, e As EventArgs) Handles btnCheckLocationAll.Click
        For i As Integer = 0 To rptLocationList.Items.Count - 1
            Dim chkItemLocation As CheckBox = rptLocationList.Items(i).FindControl("chkItemLocation")
            chkItemLocation.Checked = Not chkHeadLocation.Checked
        Next
        chkHeadLocation.Checked = Not chkHeadLocation.Checked
    End Sub
#End Region

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        BindList()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click

        '## Start Validate 
        If txtPROMOTIONCODE.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Group Code');", True)
            Exit Sub
        End If
        If txtPROMOTIONNAME.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Group Name');", True)
            Exit Sub
        End If

        If txtStartDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Period From');", True)
            Exit Sub
        End If

        If txtEndDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Period To');", True)
            Exit Sub
        End If

        If Converter.StringToDate(txtStartDate.Text, "dd/MM/yyyy") > Converter.StringToDate(txtEndDate.Text, "dd/MM/yyyy") Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('The promotion period start date must be less than end date');", True)
            Exit Sub
        End If

        If Converter.StringToDate(txtStartDate.Text, "dd/MM/yyyy") <= DateTime.Now.Date Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('The promotion period start date must be date in advance');", True)
            Exit Sub
        End If

        Dim trans As New ServerTransactionDB
        Dim lnqpmt As New MsPromotionServerLinqDB
        If lnqpmt.ChkDuplicateByPROMOTION_CODE(txtPROMOTIONCODE.Text.Trim, Edit_GRP_ID, trans.Trans) Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('This Promotion is already existed');", True)
            Exit Sub
        End If

        For i As Integer = 0 To rptServiceRateHour.Items.Count - 1
            Dim rptRateHourModel As Repeater = rptServiceRateHour.Items(i).FindControl("rptRateHourModel")
            For j As Integer = 0 To rptRateHourModel.Items.Count - 1
                Dim txtServiceRate As TextBox = rptRateHourModel.Items(j).FindControl("txtServiceRate")
                If txtServiceRate.Text.Trim = "" Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Service Rate');", True)
                    Exit Sub
                End If
            Next
        Next

        Dim strLocationID As String = ""
        Dim strStartDate As String = Converter.StringToDate(txtStartDate.Text, "dd/MM/yyyy").ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Dim strEndDate As String = Converter.StringToDate(txtStartDate.Text, "dd/MM/yyyy").ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        For j As Integer = 0 To rptLocationList.Items.Count - 1
            Dim lblLocationID As Label = rptLocationList.Items(j).FindControl("lblLocationID")
            Dim lblLocationName As Label = rptLocationList.Items(j).FindControl("lblLocationName")
            Dim chkItemLocation As CheckBox = rptLocationList.Items(j).FindControl("chkItemLocation")
            If chkItemLocation IsNot Nothing AndAlso chkItemLocation.Checked = True Then
                strLocationID &= lblLocationID.Text & ","
                If BL.CheckPromotionDateOverlap(lblLocationID.Text, Edit_GRP_ID, strStartDate, strEndDate) = True Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Promotion period date is overlap');", True)
                    Exit Sub
                End If
            End If
        Next

        If strLocationID.Length > 1 Then
            strLocationID = strLocationID.Substring(0, strLocationID.Length - 1)
        End If

        If BL.CheckPromotionDateOverlapByPromotion(strStartDate, strEndDate, strLocationID, Edit_GRP_ID) = True Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Promotion period date is overlap');", True)
            Exit Sub
        End If

        '## End Validate

        Try

            Dim promotion_id As String = Edit_GRP_ID
            Dim promotion_code As String = txtPROMOTIONCODE.Text.Trim.Replace("'", "")
            Dim promotion_name As String = txtPROMOTIONNAME.Text.Trim.Replace("'", "")

            Dim lnqmspmt As New MsPromotionServerLinqDB
            lnqmspmt.GetDataByPK(Edit_GRP_ID, trans.Trans)
            With lnqmspmt
                .PROMOTION_CODE = txtPROMOTIONCODE.Text.Replace("'", "")
                .PROMOTION_NAME = txtPROMOTIONNAME.Text.Replace("'", "")
                .START_DATE = Converter.StringToDate(txtStartDate.Text, "dd/MM/yyyy")
                .END_DATE = Converter.StringToDate(txtEndDate.Text, "dd/MM/yyyy")
            End With
            Dim ret As ExecuteDataInfo
            If lnqmspmt.ID > 0 Then
                ret = lnqmspmt.UpdateData(UserName, trans.Trans)
            Else
                ret = lnqmspmt.InsertData(UserName, trans.Trans)
            End If

            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
                Exit Sub
            End If

            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetText("@_PROMOTION_ID", lnqmspmt.ID)
            ret = ServerDB.ExecuteNonQuery("DELETE FROM MS_PROMOTION_HOUR WHERE MS_PROMOTION_ID=@_PROMOTION_ID", p)
            If ret.IsSuccess Then
                For i As Integer = 0 To rptServiceRateHour.Items.Count - 1
                    Dim lblServiceRateHour As Label = rptServiceRateHour.Items(i).FindControl("lblServiceRateHour")
                    Dim rptRateHourModel As Repeater = rptServiceRateHour.Items(i).FindControl("rptRateHourModel")

                    For j As Integer = 0 To rptRateHourModel.Items.Count - 1
                        Dim lblHourCabinetModelID As Label = rptRateHourModel.Items(j).FindControl("lblHourCabinetModelID")
                        Dim txtServiceRate As TextBox = rptRateHourModel.Items(j).FindControl("txtServiceRate")

                        Dim lnqph As New MsPromotionHourServerLinqDB
                        With lnqph
                            .MS_CABINET_MODEL_ID = lblHourCabinetModelID.Text
                            .MS_PROMOTION_ID = lnqmspmt.ID
                            .PROMOTION_HOUR = lblServiceRateHour.Text
                            .SERVICE_RATE = txtServiceRate.Text
                        End With

                        ret = lnqph.InsertData(UserName, trans.Trans)
                        If ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
                            Exit Sub
                        End If
                    Next
                Next
            End If

            Dim pl(1) As SqlParameter
            pl(0) = ServerDB.SetText("@_PROMOTION_ID", lnqmspmt.ID)
            ret = ServerDB.ExecuteNonQuery("DELETE FROM MS_PROMOTION_LOCATION WHERE MS_PROMOTION_ID=@_PROMOTION_ID", pl)
            If ret.IsSuccess Then
                For j As Integer = 0 To rptLocationList.Items.Count - 1
                    Dim lblLocationID As Label = rptLocationList.Items(j).FindControl("lblLocationID")
                    Dim lblLocationName As Label = rptLocationList.Items(j).FindControl("lblLocationName")
                    Dim chkItemLocation As CheckBox = rptLocationList.Items(j).FindControl("chkItemLocation")
                    If chkItemLocation IsNot Nothing AndAlso chkItemLocation.Checked = True Then
                        Dim lnqpl As New MsPromotionLocationServerLinqDB
                        With lnqpl
                            .MS_LOCATION_ID = lblLocationID.Text
                            .MS_PROMOTION_ID = lnqmspmt.ID
                            .SYNC_TO_LOCATION = "N"
                        End With

                        ret = lnqpl.InsertData(UserName, trans.Trans)
                        If ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
                            Exit Sub
                        End If
                    End If
                Next
            End If


            trans.CommitTransaction()
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Save success');", True)
            BindList()
        Catch ex As Exception
            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Cant Save Data');", True)
        End Try


    End Sub

    '    Public Function InsertEdit_Setting_Alarm(ByVal GROUP_ID As Integer, GROUP_CODE As String, GROUP_NAME As String, ACTIVE_STATUS As String, DT_KIOSK As DataTable,
    '                                            DT_COMPUTER As DataTable, DT_EMAIL As DataTable, USER_NAME As String) As String

    '        Dim trans As New ServerTransactionDB
    '        Try

    '            '=== TB_ALARM_GROUP
    '            Dim lnqAlGroup As New TbAlarmGroupServerLinqDB
    '            lnqAlGroup.GetDataByPK(Edit_GRP_ID, trans.Trans)
    '            With lnqAlGroup
    '                .ALARM_GROUP_CODE = txtGROUPCODE.Text.Replace("'", "")
    '                .ALARM_GROUP_NAME = txtGROUPNAME.Text.Replace("'", "")
    '                .ACTIVESTATUS = IIf(chkActive.Checked, "Y", "N")
    '            End With
    '            Dim ret As ExecuteDataInfo
    '            If lnqAlGroup.ID > 0 Then
    '                ret = lnqAlGroup.UpdateData(UserName, trans.Trans)
    '            Else
    '                ret = lnqAlGroup.InsertData(UserName, trans.Trans)
    '            End If

    '            If ret.IsSuccess = False Then
    '                trans.RollbackTransaction()
    '                'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
    '                Return ret.ErrorMessage
    '            End If


    '            '=== TB_ALARM_GROUP_MONITORING
    '            Dim p(1) As SqlParameter
    '            p(0) = ServerDB.SetText("@_GROUP_ID", lnqAlGroup.ID)
    '            ret = ServerDB.ExecuteNonQuery("DELETE FROM TB_ALARM_GROUP_MONITORING WHERE TB_ALARM_GROUP_ID=@_GROUP_ID", p)

    '            If ret.IsSuccess = True AndAlso DT_KIOSK.Rows.Count > 0 Then
    '                For i As Integer = 0 To DT_KIOSK.Rows.Count - 1
    '                    With DT_KIOSK
    '                        Dim alarm_id As String = .Rows(i)("ID").ToString
    '                        Dim lnqAlGroupMonitoring = New TbAlarmGroupMonitoringServerLinqDB

    '                        With lnqAlGroupMonitoring
    '                            .TB_ALARM_GROUP_ID = lnqAlGroup.ID
    '                            .MS_MASTER_MONITORING_ALARM_ID = alarm_id
    '                        End With

    '                        Dim d_ret As New ExecuteDataInfo
    '                        d_ret = lnqAlGroupMonitoring.InsertData(UserName, trans.Trans)

    '                        If d_ret.IsSuccess = False Then
    '                            trans.RollbackTransaction()
    '                            'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & d_ret.ErrorMessage & "');", True)
    '                            Return d_ret.ErrorMessage
    '                        End If

    '                        lnqAlGroupMonitoring = Nothing
    '                    End With

    '                Next
    '            End If


    '            '===TB_ALARM_GROUP_COMPUTER
    '            Dim p_c(1) As SqlParameter
    '            p_c(0) = ServerDB.SetText("@_GROUP_ID", lnqAlGroup.ID)
    '            ret = ServerDB.ExecuteNonQuery("DELETE FROM TB_ALARM_GROUP_COMPUTER WHERE TB_ALARM_GROUP_ID=@_GROUP_ID", p_c)

    '            If ret.IsSuccess = True AndAlso DT_COMPUTER.Rows.Count > 0 Then
    '                For i As Integer = 0 To DT_COMPUTER.Rows.Count - 1
    '                    With DT_COMPUTER
    '                        Dim mac_address As String = .Rows(i)("MACADDRESS").ToString
    '                        Dim lnqAlGroupComputer = New TbAlarmGroupComputerServerLinqDB

    '                        With lnqAlGroupComputer
    '                            .TB_ALARM_GROUP_ID = lnqAlGroup.ID
    '                            .MACADDRESS = mac_address
    '                        End With

    '                        Dim d_ret As New ExecuteDataInfo
    '                        d_ret = lnqAlGroupComputer.InsertData(UserName, trans.Trans)

    '                        If d_ret.IsSuccess = False Then
    '                            trans.RollbackTransaction()
    '                            'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & d_ret.ErrorMessage & "');", True)
    '                            Return d_ret.ErrorMessage
    '                        End If

    '                        lnqAlGroupComputer = Nothing
    '                    End With

    '                Next
    '            End If


    '            '===TB_ALARM_GROUP_EMAIL
    '            Dim p_e(1) As SqlParameter
    '            p_e(0) = ServerDB.SetText("@_GROUP_ID", lnqAlGroup.ID)
    '            ret = ServerDB.ExecuteNonQuery("DELETE FROM TB_ALARM_GROUP_EMAIL WHERE TB_ALARM_GROUP_ID=@_GROUP_ID", p_e)

    '            If ret.IsSuccess = True AndAlso DT_EMAIL.Rows.Count > 0 Then
    '                For i As Integer = 0 To DT_EMAIL.Rows.Count - 1
    '                    With DT_EMAIL
    '                        Dim e_mail As String = .Rows(i)("E_MAIL").ToString
    '                        Dim lnqAlGroupEmail = New TbAlarmGroupEmailServerLinqDB

    '                        With lnqAlGroupEmail
    '                            .TB_ALARM_GROUP_ID = lnqAlGroup.ID
    '                            .E_MAIL = e_mail
    '                        End With

    '                        Dim d_ret As New ExecuteDataInfo
    '                        d_ret = lnqAlGroupEmail.InsertData(UserName, trans.Trans)

    '                        If d_ret.IsSuccess = False Then
    '                            trans.RollbackTransaction()
    '                            'ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & d_ret.ErrorMessage & "');", True)
    '                            Return d_ret.ErrorMessage
    '                        End If

    '                        lnqAlGroupEmail = Nothing
    '                    End With
    '                Next
    '            End If

    '            Dim ws As New AlarmWebService.ApplicationWebservice
    '            ws.Url = BL.GetServerSysconfig.ALARM_WEBSERVICE_URL
    '            ws.Timeout = 25000
    '            Dim wsRet As String = ws.SendMasterAlarmGroup("ATB-Locker", UserName, lnqAlGroup.ALARM_GROUP_CODE, lnqAlGroup.ALARM_GROUP_NAME, lnqAlGroup.ACTIVESTATUS, DT_COMPUTER, DT_KIOSK, DT_EMAIL)
    '            If wsRet = "true" Then
    '                trans.CommitTransaction()
    '            Else
    '                trans.RollbackTransaction()

    '                Return wsRet
    '            End If
    '            ws.Dispose()

    '            lnqAlGroup = Nothing
    '            Return ""
    '        Catch ex As Exception

    '            trans.RollbackTransaction()
    '            Return ex.ToString()
    '        End Try

    '    End Function

#Region "Tab"
    Protected Enum Tab
        Unknown = 0
        ServiceRate = 1
        Location = 2
    End Enum

    Protected Property CurrentTab As Tab
        Get
            Select Case True
                Case tabServiceRate.Visible
                    Return Tab.ServiceRate
                Case tabLocation.Visible
                    Return Tab.Location
                Case Else
                    Return Tab.Unknown
            End Select
        End Get
        Set(value As Tab)
            tabServiceRate.Visible = False
            tabLocation.Visible = False
            liTabServiceRate.Attributes("class") = ""
            liTabLocation.Attributes("class") = ""

            Select Case value
                Case Tab.ServiceRate
                    tabServiceRate.Visible = True
                    liTabServiceRate.Attributes("class") = "active"
                Case Tab.Location
                    tabLocation.Visible = True
                    liTabLocation.Attributes("class") = "active"
                Case Else
            End Select
        End Set
    End Property

    Private Sub ChangeTab(sender As Object, e As System.EventArgs) Handles btnTabServiceRate.Click, btnTabLocation.Click
        Select Case True
            Case Equals(sender, btnTabServiceRate)
                CurrentTab = Tab.ServiceRate
            Case Equals(sender, btnTabLocation)
                CurrentTab = Tab.Location
        End Select
    End Sub

    'Private Sub likPublishPromotion_Click(sender As Object, e As EventArgs) Handles likPublishPromotion.Click
    '    Dim ret As ExecuteDataInfo = SetPublishPromotion(lblLocationPromotionID.Text)
    '    If ret.IsSuccess = True Then
    '        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Publish Promotion Success');", True)
    '        BindList()
    '    Else
    '        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
    '    End If
    'End Sub
#End Region

End Class
