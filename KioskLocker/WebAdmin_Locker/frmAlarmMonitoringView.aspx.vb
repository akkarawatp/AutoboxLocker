Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports ServerLinqDB.ConnectDB
'Imports ServerLinqDB.TABLE

Public Class frmAlarmMonitoringView
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
            If KO_ID = 0 Then
                Response.Redirect("frmAlarmMonitoring.aspx")
                Exit Sub
            End If

        End If
        BindKiosk()
        BindHardware()
        BindPeripheral()
        BindStock()
        BindLockerInformation()
    End Sub

    Private Sub initFormPlugin()
        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Plugin", "initFormPlugin(); ", True)
    End Sub

    Private Sub BindKiosk()
        Dim DT As DataTable = BL.Alarm_Overview(KO_ID, UserName)
        If DT.Rows.Count = 0 Then
            Response.Redirect("frmAlarmMonitoring.aspx")
            Exit Sub
        End If

        lblIPAddress.Text = DT.Rows(0).Item("ip_address").ToString
        lblMacAddress.Text = DT.Rows(0).Item("mac_address").ToString
        lblComputerName.Text = DT.Rows(0).Item("com_name").ToString
        lblLocation.Text = DT.Rows(0).Item("location_name").ToString
    End Sub

    Private Sub BindHardware()

        Dim DT As DataTable = BL.Alarm_Overview(KO_ID, UserName) '= BL.vw_Hardware_Condition(KO_ID)
        Dim animate As Integer = 1
        If Not IsPostBack Then animate = 1000

        Dim Script As String = "$(document).ready(function() {" & vbLf
        '-----------------Bind Ram + CPU
        If DT.Rows.Count = 0 Then
            Script &= " renderPie('MainContent_Monitoring_Content_CPUPie', 'green', 0," & animate & ");" & vbLf
            Script &= " renderPie('MainContent_Monitoring_Content_RAMPie', 'green', 0," & animate & ");" & vbLf
        Else
            Dim TO_DAY_AVALIABLE As Integer = CInt(Val(DT.Rows(0).Item("today_available").ToString))
            Dim CPU As Integer = CInt(Val(DT.Rows(0).Item("cpu_usage").ToString))
            Dim RAM As Integer = CInt(Val(DT.Rows(0).Item("ram_usage").ToString))
            Dim DISK As Integer = CInt(Val(DT.Rows(0).Item("disk_usage").ToString))
            Dim AVALIABLE_STATUS As String = DT.Rows(0).Item("available_status").ToString
            Script &= " renderPie('" & avaliablepie.ClientID & "', '" & IIf(TO_DAY_AVALIABLE > 80, "green", IIf(TO_DAY_AVALIABLE > 60, "orange", "red")) & "', " & TO_DAY_AVALIABLE & "," & animate & ");" & vbLf
            Script &= " renderPie('" & CPUPie.ClientID & "', '" & IIf(CPU > 80, "red", IIf(CPU > 60, "orange", "green")) & "', " & CPU & "," & animate & ");" & vbLf
            Script &= " renderPie('" & RAMPie.ClientID & "', '" & IIf(RAM > 80, "red", IIf(RAM > 60, "orange", "green")) & "', " & RAM & "," & animate & ");" & vbLf
            Script &= " renderPie('" & DrivePie.ClientID & "', '" & IIf(DISK > 80, "red", IIf(DISK > 60, "orange", "green")) & "', " & DISK & "," & animate & ");" & vbLf

            'lblAvariableStatus.ForeColor = Drawing.Color.Red
            'lblAvariableStatus.Text = "Offline"
            'If AVALIABLE_STATUS = "Y" Then
            '    lblAvariableStatus.ForeColor = Drawing.Color.Green
            '    lblAvariableStatus.Text = "Online"
            'End If
        End If
        Script &= "});" & vbLf
        ScriptManager.RegisterStartupScript(Page, GetType(String), "CPU_RAM", Script, True)

        DriveScript = "$(document).ready(function() {"
        DriveScript &= "});" & vbLf
        ScriptManager.RegisterStartupScript(Page, GetType(String), "Drive_Info", DriveScript, True)
    End Sub

    Dim DriveScript As String = ""
    Dim animate As Integer = 1


#Region "Peripheral"
    Private Sub BindPeripheral()
        Dim DT As DataTable = BL.GetList_Kiosk_Device_Existing(KO_ID, "Y")
        DT.DefaultView.RowFilter = "ms_device_type_id in (1,2,3,4,5) AND (Max_Qty IS NOT NULL OR Warning_Qty IS NOT NULL OR Critical_Qty IS NOT NULL)"
        DT = DT.DefaultView.ToTable
        rptDevice.DataSource = DT
        rptDevice.DataBind()
    End Sub

    Private Sub rptDevice_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptDevice.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim spanDevice As HtmlGenericControl = e.Item.FindControl("spanDevice")
        Dim iconDevice As Image = e.Item.FindControl("iconDevice")
        Dim lblDeviceName As Label = e.Item.FindControl("lblDeviceName")
        Dim lblStatus As Label = e.Item.FindControl("lblStatus")
        Dim imgWarning As Image = e.Item.FindControl("imgWarning")

        lblDeviceName.Text = e.Item.DataItem("device_name_en").ToString
        spanDevice.Attributes("Title") = e.Item.DataItem("device_name_en").ToString
        iconDevice.ImageUrl = "Render_Hardware_Icon.aspx?C=W&D=" & e.Item.DataItem("ms_device_id")

        If Not IsDBNull(e.Item.DataItem("is_problem")) Then
            If e.Item.DataItem("is_problem") = "Y" Then
                spanDevice.Attributes("class") = "btn btn-danger col-sm-10 h7 text-left"
                lblStatus.Visible = True
                lblStatus.Text = e.Item.DataItem("status_name").ToString & " "
                lblStatus.ForeColor = Drawing.Color.Yellow
            Else
                spanDevice.Attributes("class") = "btn btn-info col-sm-10 h7 text-left"
                lblStatus.Visible = False
                lblStatus.Text = "OK "
                lblStatus.ForeColor = Drawing.Color.White
            End If
        Else
            spanDevice.Attributes("class") = "btn btn-default col-sm-10 h7 text-left"
            lblStatus.Text = "N/A "
            lblStatus.ForeColor = Drawing.Color.White
        End If
        imgWarning.Visible = lblStatus.Visible

    End Sub
#End Region

#Region "Stock"
    Private Sub BindStock()
        Dim DT As DataTable = BL.GetList_Kiosk_Device_Existing(KO_ID, "Y")
        DT.DefaultView.RowFilter = "ms_device_type_id in (1,2,3,4,5) AND (Max_Qty IS NOT NULL OR Warning_Qty IS NOT NULL OR Critical_Qty IS NOT NULL)"
        DT = DT.DefaultView.ToTable

        Script = "$(document).ready(function() {" & vbLf

        DT.DefaultView.Sort = "device_order"
        '------------ Money Stock -------------
        DT.DefaultView.RowFilter = "ms_device_type_id IN (1,2,3,4)"
        Dim Money As DataTable = DT.DefaultView.ToTable
        Money.DefaultView.RowFilter = ""
        rptMoney.DataSource = Money
        rptMoney.DataBind()
        '------------ Paper Stock -------------
        DT.DefaultView.RowFilter = "ms_device_type_id =5"
        Dim Paper As DataTable = DT.DefaultView.ToTable
        Paper.DefaultView.RowFilter = ""
        rptPrinter.DataSource = Paper
        rptPrinter.DataBind()

        Script &= "});" & vbLf
        'ScriptManager.RegisterStartupScript(Page, GetType(String), "Stock", Script, True)
    End Sub

    Dim Script As String = ""
    Private Sub rpt_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptMoney.ItemDataBound, rptPrinter.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim divAll As HtmlGenericControl = e.Item.FindControl("divAll")
        Dim divContainer As HtmlGenericControl = e.Item.FindControl("divContainer")
        Dim lblName As Label = e.Item.FindControl("lblName")
        Dim lblLevel As Label = e.Item.FindControl("lblLevel")
        Dim progress As HtmlGenericControl = e.Item.FindControl("progress")

        Dim rpt As Repeater = sender
        Dim DT As DataTable = rpt.DataSource

        Select Case True
            Case DT.Rows.Count = 1
                divAll.Attributes("class") = "col-sm-12"
            Case DT.Rows.Count = 3
                divAll.Attributes("class") = "col-sm-4"
            Case Else
                divAll.Attributes("class") = "col-sm-6"
        End Select
        '---------------- Control Level----------------
        Dim Max_Qty As Integer = e.Item.DataItem("Max_Qty")
        Dim Warning_Qty As Integer = e.Item.DataItem("Warning_Qty")
        Dim Critical_Qty As Integer = e.Item.DataItem("Critical_Qty")
        Dim Current_Qty As Integer = 0
        If Not IsDBNull(e.Item.DataItem("Current_Qty")) Then Current_Qty = e.Item.DataItem("Current_Qty")


        lblName.Text = e.Item.DataItem("device_name_en").ToString

        '--------------- Set Control Level -----------------------
        If Current_Qty < 0 Then Current_Qty = 0
        If Current_Qty > Max_Qty Then Current_Qty = Max_Qty
        lblLevel.Text = Current_Qty & " / " & Max_Qty

        Dim W As Integer = (Current_Qty * 100 / Max_Qty)
        progress.Style("width") = W & "%"


        Dim Direction As Integer = -1
        If Not IsDBNull(e.Item.DataItem("Movement_Direction")) Then
            Direction = e.Item.DataItem("Movement_Direction")
        End If
        Select Case Direction
            Case 1
                If Current_Qty >= Critical_Qty Then
                    divContainer.Attributes("class") = "row m-a-0 text-danger"
                    progress.Attributes("class") = "progress-bar progress-bar-danger"
                ElseIf Current_Qty >= Warning_Qty Then
                    divContainer.Attributes("class") = "row m-a-0 text-warning"
                    progress.Attributes("class") = "progress-bar progress-bar-warning"
                Else
                    divContainer.Attributes("class") = "row m-a-0 text-green"
                    progress.Attributes("class") = "progress-bar progress-bar-success"
                End If
            Case -1
                If Current_Qty <= Critical_Qty Then
                    divContainer.Attributes("class") = "row m-a-0 text-danger"
                    progress.Attributes("class") = "progress-bar progress-bar-danger"
                ElseIf Current_Qty <= Warning_Qty Then
                    divContainer.Attributes("class") = "row m-a-0 text-warning"
                    progress.Attributes("class") = "progress-bar progress-bar-warning"
                Else
                    divContainer.Attributes("class") = "row m-a-0 text-green"
                    progress.Attributes("class") = "progress-bar progress-bar-success"
                End If
        End Select
    End Sub

#End Region


    Private Sub BindLockerInformation()
        Dim dt As New DataTable
        dt = BL.GetLockerInformation(KO_ID)
        'dt = BL.GetLockerInformation(1)

        Dim str As New StringBuilder
        If dt.Rows.Count > 0 Then
            Dim sql As String = "select t.ms_locker_id, t.trans_no, t.trans_start_time,  " & vbNewLine
            sql += " t.cust_image, l.locker_name " & vbNewLine
            sql += " from TB_DEPOSIT_TRANSACTION t " & vbNewLine
            sql += " inner join MS_LOCKER l On l.id=t.ms_locker_id " & vbNewLine
            sql += " left join TB_PICKUP_TRANSACTION p On p.deposit_trans_no=t.trans_no and p.trans_status='1' " & vbNewLine
            sql += " where t.trans_status=1 And p.id Is null " & vbNewLine
            sql += " And l.current_available ='N' and l.active_status='Y'" & vbNewLine
            sql += " and t.ms_kiosk_id=@_KIOSK_ID "
            sql += " order by t.trans_start_time desc"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_KIOSK_ID", KO_ID)
            Dim InfoDt As DataTable = ServerDB.ExecuteTable(sql, p)

            Dim dt_cabinet As New DataTable
            dt_cabinet = dt.DefaultView.ToTable(True, "order_layout").Copy()

            Dim table_height As Integer = 400   'height of table
            Dim colwidth As Integer = dt_cabinet.Rows.Count * 100
            str.AppendLine("<center>")
            str.AppendLine("<table style='height:" & table_height & "px; width:" & colwidth & "px;padding: 0; border-spacing: 0' >")
            str.AppendLine("<tr>")

            Dim pcPosition As Long = BL.GetKioskSysconfig(KO_ID).LOCKER_PC_POSITION

            Dim dr As DataRow
            dr = dt_cabinet.NewRow
            dr("order_layout") = "-1"
            dt_cabinet.Rows.InsertAt(dr, (pcPosition - 1))
            For i As Integer = 0 To dt_cabinet.Rows.Count - 1
                Dim order_layout As String = dt_cabinet.Rows(i)("order_layout").ToString()
                dt.DefaultView.RowFilter = "order_layout = '" & order_layout & "'"

                Dim dt_detail As New DataTable
                dt_detail = dt.DefaultView.ToTable

                Dim cabinet_height As Integer = table_height
                If dt_detail.Rows.Count > 0 Then
                    cabinet_height = Math.Ceiling(table_height / dt_detail.Rows.Count)
                End If

                str.AppendLine("<td>")
                str.AppendLine("<table  border='1' style='height:" & table_height & "px; width:100px; padding: 0; border-spacing: 0'>")

                If order_layout = "-1" Then
                    str.AppendLine("<tr >")
                    str.AppendLine("    <td style='height:" & cabinet_height & "px; background-color:gray; text-align:center;'>&nbsp;</td>")
                    str.AppendLine("</tr>")
                Else
                    For j As Integer = 0 To dt_detail.Rows.Count - 1
                        Dim locker_name As String = dt_detail.Rows(j)("Locker_Name").ToString()
                        Dim current_available As String = dt_detail(j)("current_available").ToString()
                        Dim bgcolor As String = "#DD6777"
                        Dim forecolor As String = "#000000"
                        Dim ScriptDialog = ""
                        Dim CursorStyle = ""

                        If current_available = "Y" Then
                            bgcolor = "#FFFFFF"
                            forecolor = "#000000"
                        Else
                            InfoDt.DefaultView.RowFilter = "ms_locker_id=" & dt_detail.Rows(j)("ms_locker_id")
                            If InfoDt.DefaultView.Count > 0 Then
                                Dim iDr As DataRowView = InfoDt.DefaultView(0)
                                Dim DepositTime As String = ""
                                Dim CustImg As String = "&nbsp;"

                                If Convert.IsDBNull(iDr("trans_start_time")) = False Then DepositTime = Convert.ToDateTime(iDr("trans_start_time")).ToString("dd/MM/yyyy HH:mm", New Globalization.CultureInfo("en-US"))
                                If Convert.IsDBNull(iDr("cust_image")) = False Then
                                    CustImg = "data:image/" & iDr("trans_no") & ";base64," & Convert.ToBase64String(iDr("cust_image"))
                                End If


                                Dim TextInfo As String = "'<div class=' + 'col-sm-12  table-responsive' + ' >  "
                                TextInfo += "    <table class=' + 'table m-b' + ' >"
                                TextInfo += "       <thead>"
                                TextInfo += "           <tr>"
                                TextInfo += "               <th  class='+'h4 text-center'+'>Deposit Time :</th>"
                                TextInfo += "               <th  class='+'h4 text-center'+'>" & DepositTime & "</th>"
                                TextInfo += "           </tr>"
                                TextInfo += "       </thead>"
                                TextInfo += "       <tbody>"
                                TextInfo += "           <tr>"
                                TextInfo += "               <td colspan='+'2'+'><img src='+'" & CustImg & "'+' style='+'width:150px;'+'  /></td>"
                                TextInfo += "           </tr>"
                                TextInfo += "       </tbody>"
                                TextInfo += "   </table>"
                                TextInfo += "</div>'"
                                ScriptDialog = "onclick=""ShowDialogProfile('" & locker_name & "'," & TextInfo & ")"""

                                CursorStyle = "cursor:pointer;"
                            End If

                            InfoDt.DefaultView.RowFilter = ""
                        End If

                        str.AppendLine("<tr style='border-width:1px;padding: 0; border-spacing: 0; border-style:solid; border-color:black'>")
                        str.AppendLine("    <td " & ScriptDialog & " style='height:" & cabinet_height & "px; background-color:" & bgcolor & "; text-align:center; font-size:25px; color:" & forecolor & ";" & CursorStyle & "'>")
                        str.Append("        " & locker_name)
                        str.Append("    </td>")
                        str.AppendLine("</tr>")
                    Next
                End If

                str.AppendLine("</table>")
                str.AppendLine("</td>")
                dt.DefaultView.RowFilter = ""
            Next
            InfoDt.Dispose()

            str.AppendLine("</tr>")
            str.AppendLine("</table>")
            str.AppendLine("</center>")
            ltrlockerinfo.Text = str.ToString()
        Else
            ltrlockerinfo.Text = ""
        End If
    End Sub

    Private Sub btnUpdateStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateStatus.Click
        'จำเป็นต้องมี Sub นี้ไว้เพื่อใช้ Refresh หน้าจอ
    End Sub
End Class