Imports System.Data.SqlClient
Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports OfficeOpenXml

Public Class Report_SummaryByLocation
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 23
    Const FunctionalZoneID As Int16 = 2

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ตรวจสอบสิทธิ์การใช้งาน
        Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
        If ufDt Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End If
        If ufDt.Rows.Count > 0 Then
            Dim auDt As DataTable = BL.GetList_User_Functional(1, FunctionalZoneID, FunctionalID, Session("Username"))
            If auDt.Rows.Count = 0 Then
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
                Exit Sub
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()

        If Session("UserName") IsNot Nothing Then
            If Not IsPostBack Then
                BindSearchForm(Session("UserName"))
                BindList()
            End If
        Else
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End If
    End Sub

    Private Sub BindSearchForm(Username As String)

        BL.Bind_DDL_Location(ddlLocation, Username)
        ddlLocation.Items(0).Text = "All Locations"
        txtStartDate.Text = DateTime.Now.ToString("MMM dd yyyy", New System.Globalization.CultureInfo("en-US"))
        txtEndDate.Text = DateTime.Now.ToString("MMM dd yyyy", New System.Globalization.CultureInfo("en-US"))

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        BindList()
    End Sub

    Private Sub BindList()
        lblHeader.Text = ""
        Dim parm(7) As SqlParameter

        lblHeader.Text = "รายงานสรุปยอดขายทั้งมูลค่าและปริมาณตาม Location "
        Dim wh As String = ""
        If ddlLocation.SelectedValue.Trim <> "" Then
            wh += " And t.ms_location_id =@_LOCATION_ID " + Environment.NewLine
            parm(0) = ServerDB.SetBigInt("@_LOCATION_ID", ddlLocation.SelectedValue)
            lblHeader.Text &= " ที่ " & ddlLocation.Items(ddlLocation.SelectedIndex).Text & " "
        Else
            If Session("List_User_LocationID") IsNot Nothing Then
                wh += " and t.ms_location_id in (" & Session("List_User_LocationID") & ") " + Environment.NewLine
                lblHeader.Text &= " ทุก Location "
            Else
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
            End If
        End If

        lblHeader.Text &= " รายวัน"
        If txtStartDate.Text.Trim <> "" Then
            Dim TimeStart As String = Converter.ConvertTextToDate(txtStartDate.Text).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            lblHeader.Text &= " ตั้งแต่ " & Converter.ConvertTextToDate(txtStartDate.Text).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            wh += " and convert(varchar(8),t.collect_time,112)  >= @_TIME_START " + Environment.NewLine
            parm(1) = ServerDB.SetText("@_TIME_START", TimeStart)
        End If

        If txtEndDate.Text.Trim <> "" Then
            Dim TimeEnd As String = Converter.ConvertTextToDate(txtEndDate.Text).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            lblHeader.Text &= " ถึง " & Converter.ConvertTextToDate(txtEndDate.Text).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            wh += " And convert(varchar(8),t.collect_time,112) <= @_TIME_END " + Environment.NewLine
            parm(2) = ServerDB.SetText("@_TIME_END", TimeEnd)
        End If

        Dim sql As String = Engine.ReportENG.GetQueryReportSummaryByLocation(wh)
        Dim DT As DataTable = ServerDB.ExecuteTable(sql, parm)
        Session("Report_SummaryByLocation") = DT
        rptList.DataSource = DT
        rptList.DataBind()

        If DT.Rows.Count = 0 Then
            lblHeader.Text &= " ไม่พบข้อมูล "
        Else
            lblHeader.Text &= " พบ " & DT.Rows.Count & " Record(s)"
        End If

        '--------------- Report Summary ------------
        Dim SUM_SR_SUCCESS As Object = DT.Compute("SUM(sr_success)", "")
        Dim SUM_SR_AMT As Object = DT.Compute("SUM(sr_amt)", "")
        Dim SUM_MR_SUCCESS As Object = DT.Compute("SUM(mr_success)", "")
        Dim SUM_MR_AMT As Object = DT.Compute("SUM(mr_amt)", "")
        Dim SUM_LR_SUCCESS As Object = DT.Compute("SUM(lr_success)", "")
        Dim SUM_LR_AMT As Object = DT.Compute("SUM(lr_amt)", "")
        Dim SUM_TOTAL_SUCCESS As Object = DT.Compute("SUM(total_success)", "")
        Dim SUM_TOTAL_AMT As Object = DT.Compute("SUM(total_amt)", "")

        '------------- Summary------------
        If Not IsDBNull(SUM_SR_SUCCESS) Then
            lblSumSRSuccess.Text = FormatNumber(SUM_SR_SUCCESS, 0)
        Else
            lblSumSRSuccess.Text = "-"
        End If
        If Not IsDBNull(SUM_SR_AMT) Then
            lblSumSRServiceAmount.Text = Convert.ToInt64(SUM_SR_AMT).ToString("#,##0.00")
        Else
            lblSumSRServiceAmount.Text = "-"
        End If

        If Not IsDBNull(SUM_MR_SUCCESS) Then
            lblSumMRSuccess.Text = FormatNumber(SUM_MR_SUCCESS, 0)
        Else
            lblSumMRSuccess.Text = "-"
        End If
        If Not IsDBNull(SUM_MR_AMT) Then
            lblSumMRServiceAmount.Text = Convert.ToInt64(SUM_MR_AMT).ToString("#,##0.00")
        Else
            lblSumMRServiceAmount.Text = "-"
        End If
        If Not IsDBNull(SUM_LR_SUCCESS) Then
            lblSumLRSuccess.Text = FormatNumber(SUM_LR_SUCCESS, 0)
        Else
            lblSumLRSuccess.Text = "-"
        End If
        If Not IsDBNull(SUM_LR_AMT) Then
            lblSumLRServiceAmount.Text = Convert.ToInt64(SUM_LR_AMT).ToString("#,##0.00")
        Else
            lblSumLRServiceAmount.Text = "-"
        End If
        If Not IsDBNull(SUM_TOTAL_SUCCESS) Then
            lblSumTotalSuccess.Text = FormatNumber(SUM_TOTAL_SUCCESS, 0)
        Else
            lblSumTotalSuccess.Text = "-"
        End If
        If Not IsDBNull(SUM_TOTAL_AMT) Then
            lblSumTotalServiceAmount.Text = Convert.ToInt64(SUM_TOTAL_AMT).ToString("#,##0.00")
        Else
            lblSumTotalServiceAmount.Text = "-"
        End If

    End Sub

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim tdMode As HtmlTableCell = e.Item.FindControl("tdMode")
        Dim lblDate As Label = e.Item.FindControl("lblDate")
        Dim lblLocation As Label = e.Item.FindControl("lblLocation")

        Dim lblSRSuccess As Label = e.Item.FindControl("lblSRSuccess")
        Dim lblSRServiceAmount As Label = e.Item.FindControl("lblSRServiceAmount")
        Dim lblMRSuccess As Label = e.Item.FindControl("lblMRSuccess")
        Dim lblMRServiceAmount As Label = e.Item.FindControl("lblMRServiceAmount")
        Dim lblLRSuccess As Label = e.Item.FindControl("lblLRSuccess")
        Dim lblLRServiceAmount As Label = e.Item.FindControl("lblLRServiceAmount")
        Dim lblTotalSuccess As Label = e.Item.FindControl("lblTotalSuccess")
        Dim lblTotalServiceAmount As Label = e.Item.FindControl("lblTotalServiceAmount")

        lblDate.Text = Convert.ToDateTime(e.Item.DataItem("collect_time")).ToString("dd-MMM-yyyy", New Globalization.CultureInfo("en-US"))
        lblLocation.Text = e.Item.DataItem("location_name").ToString
        lblSRSuccess.Text = FormatNumber(e.Item.DataItem("sr_success"), 0)
        lblSRServiceAmount.Text = Convert.ToInt64(e.Item.DataItem("sr_amt")).ToString("#,##0.00")
        lblMRSuccess.Text = FormatNumber(e.Item.DataItem("mr_success"), 0)
        lblMRServiceAmount.Text = Convert.ToInt64(e.Item.DataItem("mr_amt")).ToString("#,##0.00")
        lblLRSuccess.Text = FormatNumber(e.Item.DataItem("lr_success"), 0)
        lblLRServiceAmount.Text = Convert.ToInt64(e.Item.DataItem("lr_amt")).ToString("#,##0.00")
        lblTotalSuccess.Text = FormatNumber(e.Item.DataItem("total_success"), 0)
        lblTotalServiceAmount.Text = Convert.ToInt64(e.Item.DataItem("total_amt")).ToString("#,##0.00")

    End Sub

    Private Sub lnkExcel_Click(sender As Object, e As EventArgs) Handles lnkExcel.Click
        Try
            Dim DT As DataTable = CType(Session("Report_SummaryByLocation"), DataTable)

            Dim TmpDT As New DataTable
            TmpDT = Engine.ReportENG.BuildReportSummaryByLocationExcelDatatable(TmpDT, DT)

            Dim DR As DataRow
            DR = TmpDT.NewRow
            DR("LOCATION") = "TOTAL"
            DR("DATE") = ""
            DR("SR SUCCESS") = lblSumSRSuccess.Text
            DR("SR SERVICE AMOUNT") = lblSumSRServiceAmount.Text
            DR("MR SUCCESS") = lblSumMRSuccess.Text
            DR("MR SERVICE AMOUNT") = lblSumMRServiceAmount.Text
            DR("LR SUCCESS") = lblSumLRSuccess.Text
            DR("LR SERVICE AMOUNT") = lblSumLRServiceAmount.Text
            DR("TOTAL SUCCESS") = lblSumTotalSuccess.Text
            DR("TOTAL SERVICE AMOUNT") = lblSumTotalServiceAmount.Text
            TmpDT.Rows.Add(DR)

            Using ep As New ExcelPackage
                Dim ws As ExcelWorksheet = ep.Workbook.Worksheets.Add("Detail")
                ws.Cells("A1").Value = lblHeader.Text
                ws.Cells("A1").Style.Font.Bold = True
                ws.Cells("A1").Style.Font.Size = 18

                BL.ExportExcelPackage(Response, TmpDT, "Report_SummaryByLocation.xlsx", 1, ep, ws, 2, 1)
            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class