Imports System.Web.Configuration
Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient
Imports System.IO


Public Class frmMasterKiosk
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Dim DeviceList As DataTable
    Dim StatusList As DataTable

    Const FunctionalID As Int16 = 9
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

    Public Property Edit_KO_ID As Integer
        Get
            Try
                Return ViewState("KO_ID")
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(value As Integer)
            ViewState("KO_ID") = value
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

            BL.SetTextIntKeypress(txtIP1)
            BL.SetTextIntKeypress(txtIP2)
            BL.SetTextIntKeypress(txtIP3)
            BL.SetTextIntKeypress(txtIP4)

        End If
        initFormPlugin()
    End Sub

    'Protected Sub SetAuthorizedLevel(ByVal DT As DataTable)
    '    AuthorizedLevel = BL.GetFunctionalAuthorized(DT, FN_ID)
    'End Sub

    'Protected Sub SetAuthorizedAlarm(ByVal DT As DataTable)
    '    AuthorizedAlarm = BL.GetFunctionalAuthorized(DT, 21)
    'End Sub

    Private Sub initFormPlugin()
        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Plugin", "initFormPlugin(); ", True)
    End Sub

    Private Sub btnUpdateStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateStatus.Click
        BindList()
    End Sub

    Private Sub BindList()
        DeviceList = BL.GetList_Kiosk_Device_Existing(0, "Y")
        StatusList = BL.GetList_DeviceStatus(0, 0)

        'btnAdd.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit

        Dim dt As New DataTable
        dt = BL.GetList_Kiosk(UserName, 0)
        rptList.DataSource = dt
        rptList.DataBind()
        lblTotalList.Text = FormatNumber(dt.Rows.Count, 0)

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
                For i As Integer = 0 To rptList.Items.Count - 1
                    Dim btnEdit As LinkButton = rptList.Items(i).FindControl("btnEdit")
                    btnEdit.Text = "View Info"
                Next
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()
    End Sub

    Private Sub ClearEditForm()
        Edit_KO_ID = 0

        BL.Bind_DDL_Location(ddlLocation, UserName)

        txtComName.Text = ""
        txtIP1.Text = ""
        txtIP2.Text = ""
        txtIP3.Text = ""
        txtIP4.Text = ""
        txtMAC1.Text = ""
        txtMAC2.Text = ""
        txtMAC3.Text = ""
        txtMAC4.Text = ""
        txtMAC5.Text = ""
        txtMAC6.Text = ""

        ''------- Manage Material Stock Control Level --------
        BindMaterialStock()

        chkActive.Checked = False
        lblEditMode.Text = "Add"
    End Sub



    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        BindList()
    End Sub

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        '-------------- Main Kiosk Info---------------------
        Dim imgKioskIcon As Image = e.Item.FindControl("imgKioskIcon")
        Dim lblIP As Label = e.Item.FindControl("lblIP")
        Dim lblMacAddress As Label = e.Item.FindControl("lblMacAddress")
        Dim lblComName As Label = e.Item.FindControl("lblComName")
        Dim lblLocation As Label = e.Item.FindControl("lblLocation")
        Dim btnMonitor As LinkButton = e.Item.FindControl("btnMonitor")
        Dim btnEdit As LinkButton = e.Item.FindControl("btnEdit")

        btnMonitor.PostBackUrl = "frmAlarmMonitoringView.aspx?K=" & e.Item.DataItem("ms_kiosk_id")
        btnEdit.CommandArgument = e.Item.DataItem("ms_kiosk_id")
        btnEdit.OnClientClick &= "clearInterval(timerRefresh);"

        If e.Item.DataItem("active_status").ToString() = "Y" Then
            imgKioskIcon.ImageUrl = "images/icon/100/koisk_ok.png"
        Else
            imgKioskIcon.ImageUrl = "images/icon/100/koisk_ab.png"
        End If

        Dim trans As New ServerTransactionDB
        Dim lnqloc As New MsLocationServerLinqDB
        lnqloc.GetDataByPK(e.Item.DataItem("ms_location_id").ToString, trans.Trans)

        If lnqloc.LOCATION_NAME <> "" Then
            lblComName.Text = e.Item.DataItem("com_name").ToString
            lblLocation.Text = lnqloc.LOCATION_NAME
            lblIP.Text = e.Item.DataItem("ip_address").ToString
            lblMacAddress.Text = e.Item.DataItem("mac_address").ToString()
        End If
        trans.CommitTransaction()
        lnqloc = Nothing

        '--------------- Printer Info ---------------
        Dim Printer As uc_Printer_Stock_UI = e.Item.FindControl("Printer")
        Dim pnlBlankPrinter As Panel = e.Item.FindControl("pnlBlankPrinter")
        DeviceList.DefaultView.RowFilter = "ms_device_id=7 and ms_kiosk_id=" & e.Item.DataItem("ms_kiosk_id")
        If DeviceList.DefaultView.Count = 0 Then
            Printer.Visible = False
            pnlBlankPrinter.Visible = True
        Else
            Dim Max_Qty As Object = DeviceList.DefaultView(0).Item("Max_Qty")
            Dim Warning_Qty As Object = DeviceList.DefaultView(0).Item("Warning_Qty")
            Dim Critical_Qty As Object = DeviceList.DefaultView(0).Item("Critical_Qty")
            Dim Current_Qty As Object = DeviceList.DefaultView(0).Item("Current_Qty")
            Printer.BindPrinter(Current_Qty, Warning_Qty, Critical_Qty, Max_Qty)
        End If

        '--------------- Peripheral UI ---------------
        DeviceList.DefaultView.RowFilter = "ms_kiosk_id=" & e.Item.DataItem("ms_kiosk_id")
        Dim Peripheral As uc_Peripheral_UI = e.Item.FindControl("Peripheral")
        Peripheral.BindPeripheral(DeviceList.DefaultView.ToTable.Copy, StatusList)

        '-----------Money Stock Level ---------------
        DeviceList.DefaultView.RowFilter = "ms_kiosk_id=" & e.Item.DataItem("ms_kiosk_id") & " AND ms_device_type_id in(1,2,3,4) AND Max_Qty IS NOT NULL AND Warning_Qty IS NOT NULL AND Critical_Qty IS NOT NULL"
        Dim MoneyStock As uc_MoneyStock_UI = e.Item.FindControl("MoneyStock")
        MoneyStock.BindMoneyStock(DeviceList.DefaultView.ToTable.Copy)
    End Sub

    Private Sub rptList_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptList.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                ClearEditForm()
                Dim KO_ID As Integer = e.CommandArgument
                Edit_KO_ID = KO_ID
                Dim lblKioskCode As Label = e.Item.FindControl("lblKioskCode")
                Dim DT As DataTable = BL.GetList_Kiosk(UserName, KO_ID)
                If DT.Rows.Count = 0 Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & lblKioskCode.Text.Replace("'", """") & " is not found!');", True)
                    Exit Sub
                End If

                ddlLocation.SelectedValue = DT.Rows(0).Item("ms_location_id").ToString
                txtComName.Text = DT.Rows(0).Item("com_name").ToString

                Dim IP As String() = Split(DT.Rows(0).Item("ip_address").ToString, ".")
                If IP.Length > 0 Then txtIP1.Text = IP(0)
                If IP.Length > 1 Then txtIP2.Text = IP(1)
                If IP.Length > 2 Then txtIP3.Text = IP(2)
                If IP.Length > 3 Then txtIP4.Text = IP(3)

                BindMaterialStock()
                Dim mac_address As String() = Split(DT.Rows(0).Item("mac_address").ToString, "-")
                If mac_address.Length > 0 Then txtMAC1.Text = mac_address(0)
                If mac_address.Length > 1 Then txtMAC2.Text = mac_address(1)
                If mac_address.Length > 2 Then txtMAC3.Text = mac_address(2)
                If mac_address.Length > 3 Then txtMAC4.Text = mac_address(3)
                If mac_address.Length > 4 Then txtMAC5.Text = mac_address(4)
                If mac_address.Length > 5 Then txtMAC6.Text = mac_address(5)

                chkActive.Checked = IIf(DT.Rows(0).Item("active_status").ToString = "Y", True, False)
                lblEditMode.Text = "Edit"

                pnlList.Visible = False
                pnlEdit.Visible = True

                SetControlViewOnly()
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
                ddlLocation.Enabled = False
                txtComName.Enabled = False
                txtIP1.Enabled = False
                txtIP2.Enabled = False
                txtIP3.Enabled = False
                txtIP4.Enabled = False
                txtMAC1.Enabled = False
                txtMAC2.Enabled = False
                txtMAC3.Enabled = False
                txtMAC4.Enabled = False
                txtMAC5.Enabled = False
                txtMAC6.Enabled = False

                For i As Integer = 0 To rpt_Stock.Items.Count - 1
                    Dim txtMax As TextBox = rpt_Stock.Items(i).FindControl("txtMax")
                    Dim txtWarningDown As TextBox = rpt_Stock.Items(i).FindControl("txtWarningDown")
                    Dim txtCriticalDown As TextBox = rpt_Stock.Items(i).FindControl("txtCriticalDown")
                    Dim txtCriticalUp As TextBox = rpt_Stock.Items(i).FindControl("txtCriticalUp")
                    Dim txtWarningUp As TextBox = rpt_Stock.Items(i).FindControl("txtWarningUp")

                    txtMax.Enabled = False
                    txtWarningDown.Enabled = False
                    txtWarningUp.Enabled = False
                    txtCriticalDown.Enabled = False
                    txtCriticalUp.Enabled = False
                Next


                chkActive.Enabled = False
                btnSave.Visible = False
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()
    End Sub

#Region "Material Stock"
    Protected Sub BindMaterialStock()
        Dim DT As DataTable = BL.GetList_Kiosk_Device(Edit_KO_ID, "Y")
        DT.DefaultView.RowFilter = "ms_device_type_id in (1,2,3,4,5) AND (Max_Qty IS NOT NULL OR Warning_Qty IS NOT NULL OR Critical_Qty IS NOT NULL)"

        DT = DT.DefaultView.ToTable
        rpt_Stock.DataSource = DT
        rpt_Stock.DataBind()
    End Sub

    Private Sub rpt_Stock_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpt_Stock.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim imgIcon As Image = e.Item.FindControl("imgIcon")
        Dim lblDeviceName As Label = e.Item.FindControl("lblDeviceName")
        Dim txtMax As TextBox = e.Item.FindControl("txtMax")


        Dim pnlMoveDown As Panel = e.Item.FindControl("pnlMoveDown")
        Dim txtWarningDown As TextBox = e.Item.FindControl("txtWarningDown")
        Dim txtCriticalDown As TextBox = e.Item.FindControl("txtCriticalDown")

        Dim pnlMoveUp As Panel = e.Item.FindControl("pnlMoveUp")
        Dim txtWarningUp As TextBox = e.Item.FindControl("txtWarningUp")
        Dim txtCriticalUp As TextBox = e.Item.FindControl("txtCriticalUp")

        imgIcon.ImageUrl = "Render_Hardware_Icon.aspx?D=" & e.Item.DataItem("ms_device_id").ToString & "&C=G"
        lblDeviceName.Text = e.Item.DataItem("device_name_en").ToString
        If Not IsDBNull(e.Item.DataItem("Max_Qty")) Then
            txtMax.Text = e.Item.DataItem("Max_Qty")
        Else

        End If

        Select Case e.Item.DataItem("Movement_Direction")
            Case -1
                pnlMoveDown.Visible = True
                If Not IsDBNull(e.Item.DataItem("Warning_Qty")) Then
                    txtWarningDown.Text = e.Item.DataItem("Warning_Qty")
                Else

                End If
                If Not IsDBNull(e.Item.DataItem("Critical_Qty")) Then
                    txtCriticalDown.Text = e.Item.DataItem("Critical_Qty")
                Else

                End If
            Case 1
                pnlMoveUp.Visible = True
                If Not IsDBNull(e.Item.DataItem("Warning_Qty")) Then
                    txtWarningUp.Text = e.Item.DataItem("Warning_Qty")
                Else
                End If
                If Not IsDBNull(e.Item.DataItem("Critical_Qty")) Then
                    txtCriticalUp.Text = e.Item.DataItem("Critical_Qty")
                Else
                End If
        End Select
        txtMax.Attributes("ms_device_id") = e.Item.DataItem("ms_device_id")

        BL.SetTextIntKeypress(txtMax)
        BL.SetTextIntKeypress(txtWarningUp)
        BL.SetTextIntKeypress(txtWarningDown)
        BL.SetTextIntKeypress(txtCriticalUp)
        BL.SetTextIntKeypress(txtCriticalDown)
    End Sub

    Protected Function CurrentMaterialStock() As DataTable
        Dim DT As New DataTable
        DT.Columns.Add("ms_device_id", GetType(Integer))
        DT.Columns.Add("device_name_en", GetType(String))
        DT.Columns.Add("max_qty", GetType(Integer))
        DT.Columns.Add("warning_qty", GetType(Integer))
        DT.Columns.Add("critical_qty", GetType(Integer))
        DT.Columns.Add("movement_direction", GetType(Integer))

        For Each Item As RepeaterItem In rpt_Stock.Items
            If Item.ItemType <> ListItemType.Item And Item.ItemType <> ListItemType.AlternatingItem Then Continue For
            Dim DR As DataRow = DT.NewRow

            Dim lblDeviceName As Label = Item.FindControl("lblDeviceName")
            Dim txtMax As TextBox = Item.FindControl("txtMax")

            Dim pnlMoveDown As Panel = Item.FindControl("pnlMoveDown")
            Dim txtWarningDown As TextBox = Item.FindControl("txtWarningDown")
            Dim txtCriticalDown As TextBox = Item.FindControl("txtCriticalDown")

            Dim pnlMoveUp As Panel = Item.FindControl("pnlMoveUp")
            Dim txtWarningUp As TextBox = Item.FindControl("txtWarningUp")
            Dim txtCriticalUp As TextBox = Item.FindControl("txtCriticalUp")

            If pnlMoveUp.Visible Then
                DR("movement_direction") = 1
            Else
                DR("movement_direction") = -1
            End If

            DR("ms_device_id") = txtMax.Attributes("ms_device_id")
            DR("device_name_en") = lblDeviceName.Text
            If IsNumeric(txtMax.Text) Then
                DR("max_qty") = CInt(txtMax.Text)
            End If

            Select Case DR("movement_direction")
                Case -1
                    If IsNumeric(txtWarningDown.Text) Then
                        DR("warning_qty") = CInt(txtWarningDown.Text)
                    End If
                    If IsNumeric(txtCriticalDown.Text) Then
                        DR("critical_qty") = CInt(txtCriticalDown.Text)
                    End If
                Case 1
                    If IsNumeric(txtWarningUp.Text) Then
                        DR("warning_qty") = CInt(txtWarningUp.Text)
                    End If
                    If IsNumeric(txtCriticalUp.Text) Then
                        DR("critical_qty") = CInt(txtCriticalUp.Text)
                    End If
            End Select
            DT.Rows.Add(DR)
        Next
        Return DT
    End Function

#End Region
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

#Region "Validate"
        If ddlLocation.SelectedIndex < 1 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Select Location');", True)
            Exit Sub
        End If
        If Not IsNumeric(txtIP1.Text) Or Not IsNumeric(txtIP2.Text) Or Not IsNumeric(txtIP3.Text) Or Not IsNumeric(txtIP4.Text) Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Invalid format IP Adress');", True)
            Exit Sub
        End If

        Dim mac_address As String = txtMAC1.Text.Trim() & "-" & txtMAC2.Text.Trim() & "-" & txtMAC3.Text.Trim() & "-" & txtMAC4.Text.Trim() & "-" & txtMAC5.Text.Trim() & "-" & txtMAC6.Text.Trim()
        If mac_address.Replace("-", "").Length <> 12 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Invalid Mac Address');", True)
            Exit Sub
        End If

        Dim ip_address As String = txtIP1.Text.Trim() & "." & txtIP2.Text.Trim() & "." & txtIP3.Text.Trim() & "." & txtIP4.Text.Trim()
        Dim IsDupplicate As Boolean = BL.IsDupplicate_Kiosk(ip_address, mac_address, Edit_KO_ID)
        If IsDupplicate = True Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('IP Address or MAC Address is already existed');", True)
            Exit Sub
        End If

        Dim MatStock As DataTable = CurrentMaterialStock()
        Dim tmp As DataTable = MatStock.Copy

        tmp.DefaultView.RowFilter = "Max_Qty IS NULL"
        If tmp.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & tmp.DefaultView(0).Item("device_name_en") & "\' max quantity must be set');", True)
            Exit Sub
        End If
        tmp.DefaultView.RowFilter = "Warning_Qty IS NULL"
        If tmp.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & tmp.DefaultView(0).Item("device_name_en") & "\' warning quantity must be set');", True)
            Exit Sub
        End If
        tmp.DefaultView.RowFilter = "Critical_Qty IS NULL"
        If tmp.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & tmp.DefaultView(0).Item("device_name_en") & "\' critical quantity must be set');", True)
            Exit Sub
        End If

        tmp.DefaultView.RowFilter = "Max_Qty < 0"
        If tmp.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & tmp.DefaultView(0).Item("device_name_en") & "\' max quantity must be greater than zero');", True)
            Exit Sub
        End If
        tmp.DefaultView.RowFilter = "Warning_Qty < 0"
        If tmp.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & tmp.DefaultView(0).Item("device_name_en") & "\' warning quantity  must be greater than zero');", True)
            Exit Sub
        End If
        tmp.DefaultView.RowFilter = "Critical_Qty < 0"
        If tmp.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & tmp.DefaultView(0).Item("device_name_en") & "\' critical quantity  must be greater than zero');", True)
            Exit Sub
        End If

        Dim Filter As String = "(Movement_Direction=-1 AND Warning_Qty>Max_Qty) OR "
        Filter &= "(Movement_Direction=-1 AND Critical_Qty>Warning_Qty) OR "
        Filter &= "(Movement_Direction=1 AND Critical_Qty>Max_Qty) OR "
        Filter &= "(Movement_Direction=1 AND Warning_Qty>Critical_Qty)"

        tmp.DefaultView.RowFilter = Filter
        If tmp.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & tmp.DefaultView(0).Item("device_name_en") & "\' control level setting is not reasonable\n\nMax Qty > Warning Qty > Critical Qty');", True)
            Exit Sub
        End If
#End Region

#Region "Save"
        Dim trans As New ServerTransactionDB
        Try
            Dim lnqkiosk As New MsKioskServerLinqDB
            lnqkiosk.GetDataByPK(Edit_KO_ID, trans.Trans)
            With lnqkiosk
                .MS_LOCATION_ID = ddlLocation.SelectedValue
                .COM_NAME = txtComName.Text.Trim.Replace("'", "''")
                .IP_ADDRESS = ip_address
                .MAC_ADDRESS = mac_address
                .TODAY_AVAILABLE = 0
                .ACTIVE_STATUS = IIf(chkActive.Checked, "Y", "N")
            End With
            Dim ret As ExecuteDataInfo
            If lnqkiosk.ID > 0 Then
                ret = lnqkiosk.UpdateData(UserName, trans.Trans)
            Else
                ret = lnqkiosk.InsertData(UserName, trans.Trans)
            End If

            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
                Exit Sub
            End If

            If ret.IsSuccess = True AndAlso MatStock.Rows.Count > 0 Then
                For i As Integer = 0 To MatStock.Rows.Count - 1
                    With MatStock
                        Dim ms_device_id As Integer = CInt(.Rows(i)("ms_device_id"))
                        Dim device_name_en As String = .Rows(i)("device_name_en").ToString
                        Dim max_qty As Integer = CInt(.Rows(i)("max_qty"))
                        Dim warning_qty As Integer = CInt(.Rows(i)("warning_qty"))
                        Dim critical_qty As Integer = CInt(.Rows(i)("critical_qty"))
                        Dim movement_direction As Integer = CInt(.Rows(i)("movement_direction"))
                        Dim lnqkioskdevice = New MsKioskDeviceServerLinqDB
                        lnqkioskdevice.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(ms_device_id, lnqkiosk.ID, trans.Trans)

                        With lnqkioskdevice
                            .MS_KIOSK_ID = lnqkiosk.ID
                            .MS_DEVICE_ID = ms_device_id
                            .MAX_QTY = max_qty
                            .WARNING_QTY = warning_qty
                            .CRITICAL_QTY = critical_qty
                            .SYNC_TO_KIOSK = "N"
                            .SYNC_TO_SERVER = "Y"
                            .MS_DEVICE_STATUS_ID = "1"
                        End With

                        Dim d_ret As New ExecuteDataInfo
                        If lnqkioskdevice.ID > 0 Then
                            d_ret = lnqkioskdevice.UpdateData(UserName, trans.Trans)
                        Else
                            d_ret = lnqkioskdevice.InsertData(UserName, trans.Trans)
                        End If
                        If d_ret.IsSuccess = False Then
                            trans.RollbackTransaction()
                            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & d_ret.ErrorMessage & "');", True)
                            Exit Sub
                        End If

                        lnqkioskdevice = Nothing
                    End With 'MatStock
                Next
            End If 'MatStock.Rows.Count > 0 

            Dim ws As New AlarmWebService.ApplicationWebservice
            ws.Url = BL.GetServerSysconfig.ALARM_WEBSERVICE_URL
            ws.Timeout = 25000
            Dim wsRet As AlarmWebService.ExecuteDataInfo = ws.SaveConfigComputerList(UserName, lnqkiosk.COM_NAME, lnqkiosk.IP_ADDRESS, lnqkiosk.MAC_ADDRESS, "ATB-Locker", lnqkiosk.ACTIVE_STATUS, "Locker Service Info", "Left and Lug Alarm")

            If wsRet.IsSuccess Then
                'Save CF_KIOSK_SYSCONFIG Location Information
                Dim loLnq As New MsLocationServerLinqDB
                loLnq.GetDataByPK(ddlLocation.SelectedValue, trans.Trans)
                If loLnq.ID > 0 Then
                    Dim cfLnq As New CfKioskSysconfigServerLinqDB
                    cfLnq.ChkDataByMS_KIOSK_ID(lnqkiosk.ID, trans.Trans)
                    If cfLnq.ID > 0 Then
                        cfLnq.LOCATION_CODE = loLnq.LOCATION_CODE
                        cfLnq.LOCATION_NAME = loLnq.LOCATION_NAME
                        cfLnq.SYNC_TO_KIOSK = "N"

                        ret = cfLnq.UpdateData(UserName, trans.Trans)
                        If ret.IsSuccess = True Then
                            trans.CommitTransaction()

                            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Save success');", True)
                            BindList()
                        Else
                            trans.RollbackTransaction()

                            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
                            Exit Sub
                        End If
                    Else
                        trans.RollbackTransaction()

                        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & cfLnq.ErrorMessage & "');", True)
                        Exit Sub
                    End If
                    cfLnq = Nothing
                Else
                    trans.RollbackTransaction()

                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & loLnq.ErrorMessage & "');", True)
                    Exit Sub
                End If
                loLnq = Nothing
            Else
                trans.RollbackTransaction()
            End If
            ws.Dispose()
            lnqkiosk = Nothing

        Catch ex As Exception
            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ex.ToString() & "');", True)
        End Try
#End Region



    End Sub

End Class