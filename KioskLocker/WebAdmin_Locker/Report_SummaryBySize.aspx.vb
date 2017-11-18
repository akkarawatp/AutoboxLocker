Imports System.Data.SqlClient
Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports OfficeOpenXml

Public Class Report_SummaryBySize
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 25
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
                CurrentPeriod = LockerBL.ReportPeriod.Hourly
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

        BL.Bind_DDL_Sales_Month(ddlFromMonth)
        BL.Bind_DDL_Sales_Month(ddlToMonth)
        BL.Bind_DDL_Sales_Year(ddlFromYear)
        BL.Bind_DDL_Sales_Year(ddlToYear)

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        BindList()
    End Sub

    Private Sub BindList()
        lblHeader.Text = ""
        Dim parm(7) As SqlParameter

        lblHeader.Text = "รายงานสรุปยอดขายทั้งมูลค่าและปริมาณตาม Locker Size "
        Dim wh As String = ""
        If ddlLocation.SelectedValue.Trim <> "" Then
            wh += " And k.ms_location_id =@_LOCATION_ID " + Environment.NewLine
            parm(0) = ServerDB.SetBigInt("@_LOCATION_ID", ddlLocation.SelectedValue)
            lblHeader.Text &= " ที่ " & ddlLocation.Items(ddlLocation.SelectedIndex).Text & " "
        Else
            If Session("List_User_LocationID") IsNot Nothing Then
                wh += " and k.ms_location_id in (" & Session("List_User_LocationID") & ") " + Environment.NewLine
                lblHeader.Text &= " ทุก Location "
            Else
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
            End If
        End If

        Select Case CInt(CurrentPeriod)
            Case LockerBL.ReportPeriod.Hourly, LockerBL.ReportPeriod.Daily '-------------------Hourly/Daily----------------------
                If CInt(CurrentPeriod) = LockerBL.ReportPeriod.Hourly Then
                    lblHeader.Text &= " รายชั่วโมง"
                ElseIf CInt(CurrentPeriod) = LockerBL.ReportPeriod.Daily Then
                    lblHeader.Text &= " รายวัน"
                End If
                If txtStartDate.Text.Trim <> "" Then
                    Dim TimeStart As DateTime = Converter.ConvertTextToDate(txtStartDate.Text)
                    lblHeader.Text &= " ตั้งแต่ " & Converter.ConvertTextToDate(txtStartDate.Text).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                    wh += " and convert(date,isnull(p.pickup_time,s.trans_start_time))  >= @_TIME_START " + Environment.NewLine
                    parm(1) = ServerDB.SetDateTime("@_TIME_START", TimeStart)
                End If

                If txtEndDate.Text.Trim <> "" Then
                    Dim TimeEnd As DateTime = Converter.ConvertTextToDate(txtEndDate.Text)
                    lblHeader.Text &= " ถึง " & Converter.ConvertTextToDate(txtEndDate.Text).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                    wh += " And convert(date,isnull(p.pickup_time,s.trans_start_time)) <= @_TIME_END " + Environment.NewLine
                    parm(2) = ServerDB.SetDateTime("@_TIME_END", TimeEnd)
                End If
            Case LockerBL.ReportPeriod.Monthly '-------------------Monthly----------------------
                If ddlFromMonth.SelectedValue <> 0 And ddlFromMonth.SelectedValue = ddlToMonth.SelectedValue Then
                    lblHeader.Text &= " ประจำเดือน " & ddlFromMonth.Items(ddlFromMonth.SelectedIndex).Text & " "
                    wh += " and convert(varchar(6),isnull(p.pickup_time,s.trans_start_time),112) = @_MONTH_FROM " + Environment.NewLine
                    parm(3) = ServerDB.SetBigInt("@_MONTH_FROM", ddlFromMonth.SelectedValue)
                Else
                    lblHeader.Text &= " รายเดือน"
                    If ddlFromMonth.SelectedValue <> 0 Then
                        wh += " and convert(varchar(6),isnull(p.pickup_time,s.trans_start_time),112) >= @_MONTH_FROM " + Environment.NewLine
                        parm(3) = ServerDB.SetBigInt("@_MONTH_FROM", ddlFromMonth.SelectedValue)
                        lblHeader.Text &= " ตั้งแต่ " & ddlFromMonth.Items(ddlFromMonth.SelectedIndex).Text & " "
                    End If
                    If ddlToMonth.SelectedValue <> 0 Then
                        wh += " and convert(varchar(6),isnull(p.pickup_time,s.trans_start_time),112) <= @_MONTH_TO " + Environment.NewLine
                        parm(4) = ServerDB.SetBigInt("@_MONTH_TO", ddlToMonth.SelectedValue)
                        lblHeader.Text &= " ถึง " & ddlToMonth.Items(ddlToMonth.SelectedIndex).Text & " "
                    End If
                End If
            Case LockerBL.ReportPeriod.Yearly '-------------------Yearly----------------------

                If ddlFromYear.SelectedValue <> 0 And ddlFromYear.SelectedValue = ddlToYear.SelectedValue Then
                    lblHeader.Text &= " ประจำปี " & ddlFromYear.SelectedValue
                    wh += " and year(isnull(p.pickup_time,s.trans_start_time)) = @_YEAR_FROM" + Environment.NewLine
                    parm(5) = ServerDB.SetBigInt("@_YEAR_FROM", ddlFromYear.SelectedValue)
                Else
                    lblHeader.Text &= " รายปี "
                    If ddlFromYear.SelectedValue <> 0 Then
                        wh += " and year(isnull(p.pickup_time,s.trans_start_time)) >= @_YEAR_FROM" + Environment.NewLine
                        parm(5) = ServerDB.SetBigInt("@_YEAR_FROM", ddlFromYear.SelectedValue)
                        lblHeader.Text &= " ตั้งแต่ " & ddlFromYear.SelectedValue & " "
                    End If
                    If ddlToYear.SelectedValue <> 0 Then
                        wh += " and year(isnull(p.pickup_time,s.trans_start_time)) <= @_YEAR_TO" + Environment.NewLine
                        parm(6) = ServerDB.SetBigInt("@_YEAR_TO", ddlToYear.SelectedValue)
                        lblHeader.Text &= " ถึง " & ddlToYear.SelectedValue & " "
                    End If
                End If
        End Select

        Dim sql As String = Engine.ReportENG.GetQueryReportSummaryBySize(wh, CInt(CurrentPeriod))

        Select Case CurrentPeriod
            Case LockerBL.ReportPeriod.Hourly
                lblTimeDisplay.Text = "Hour"
            Case LockerBL.ReportPeriod.Daily
                lblTimeDisplay.Text = "Date"
            Case LockerBL.ReportPeriod.Monthly
                lblTimeDisplay.Text = "Month"
            Case LockerBL.ReportPeriod.Yearly
                lblTimeDisplay.Text = "Year"
        End Select

        Dim DT As DataTable = ServerDB.ExecuteTable(sql, parm)
        Session("Report_SummaryBySize") = DT
        rptList.DataSource = DT
        rptList.DataBind()

        If DT.Rows.Count = 0 Then
            lblHeader.Text &= " ไม่พบข้อมูล "
        Else
            lblHeader.Text &= " พบ " & DT.Rows.Count & " Record(s)"
        End If

        '--------------- Report Summary ------------
        Dim AVG_SERVICE_TIME As Object = DT.Compute("AVG(service_time_int)", "")
        Dim AVG_TRANS_QTY As Object = DT.Compute("AVG(trans_qty)", "")
        Dim AVG_WAITING_COLLECT As Object = DT.Compute("AVG(waiting_collect)", "")
        Dim AVG_SUCCESS_TRANSACTIONS As Object = DT.Compute("AVG(trans_success)", "")
        Dim AVG_CANCEL_TRANSACTIONS As Object = DT.Compute("AVG(trans_canceled)", "")
        Dim AVG_PROBLEM_TRANSACTIONS As Object = DT.Compute("AVG(trans_problem)", "")
        Dim AVG_TIMEOUT_TRANSACTIONS As Object = DT.Compute("AVG(trans_timeout)", "")
        Dim AVG_SALES_VALUE As Object = DT.Compute("AVG(sales_value)", "")
        Dim AVG_DEPOSIT_AMT As Object = DT.Compute("AVG(deposit_amt)", "")

        Dim SUM_SERVICE_TIME As Object = DT.Compute("SUM(service_time_int)", "")
        Dim SUM_TRANS_QTY As Object = DT.Compute("SUM(trans_qty)", "")
        Dim SUM_WAITING_COLLECT As Object = DT.Compute("SUM(waiting_collect)", "")
        Dim SUM_SUCCESS_TRANSACTIONS As Object = DT.Compute("SUM(trans_success)", "")
        Dim SUM_CANCEL_TRANSACTIONS As Object = DT.Compute("SUM(trans_canceled)", "")
        Dim SUM_PROBLEM_TRANSACTIONS As Object = DT.Compute("SUM(trans_problem)", "")
        Dim SUM_TIMEOUT_TRANSACTIONS As Object = DT.Compute("SUM(trans_timeout)", "")
        Dim SUM_SALES_VALUE As Object = DT.Compute("SUM(sales_value)", "")
        Dim SUM_DEPOSIT_AMT As Object = DT.Compute("SUM(deposit_amt)", "")

        '------------- Average------------
        If Not IsDBNull(AVG_SERVICE_TIME) Then
            lbl_AVG_Service_Time.Text = Engine.ReportENG.GetFormatServiceTime(AVG_SERVICE_TIME)
        Else
            lbl_AVG_Service_Time.Text = "-"
        End If
        If Not IsDBNull(AVG_TRANS_QTY) Then
            lbl_AVG_Transaction.Text = FormatNumber(AVG_TRANS_QTY, 0)
        Else
            lbl_AVG_Transaction.Text = "-"
        End If
        If Not IsDBNull(AVG_WAITING_COLLECT) Then
            lbl_AVG_WaitingCollect.Text = FormatNumber(AVG_WAITING_COLLECT, 0)
        Else
            lbl_AVG_WaitingCollect.Text = "-"
        End If
        If Not IsDBNull(AVG_SUCCESS_TRANSACTIONS) Then
            lbl_AVG_Trans_Success.Text = FormatNumber(AVG_SUCCESS_TRANSACTIONS, 0)
        Else
            lbl_AVG_Trans_Success.Text = "-"
        End If
        If Not IsDBNull(AVG_CANCEL_TRANSACTIONS) Then
            lbl_AVG_Trans_Cancel.Text = FormatNumber(AVG_CANCEL_TRANSACTIONS, 0)
        Else
            lbl_AVG_Trans_Cancel.Text = "-"
        End If
        If Not IsDBNull(AVG_PROBLEM_TRANSACTIONS) Then
            lbl_AVG_Trans_Problem.Text = FormatNumber(AVG_PROBLEM_TRANSACTIONS, 0)
        Else
            lbl_AVG_Trans_Problem.Text = "-"
        End If
        If Not IsDBNull(AVG_TIMEOUT_TRANSACTIONS) Then
            lbl_AVG_Trans_Timeout.Text = FormatNumber(AVG_TIMEOUT_TRANSACTIONS, 0)
        Else
            lbl_AVG_Trans_Timeout.Text = "-"
        End If
        If Not IsDBNull(AVG_SALES_VALUE) Then
            lbl_AVG_Sales_Value.Text = FormatNumber(AVG_SALES_VALUE, 0)
        Else
            lbl_AVG_Sales_Value.Text = "-"
        End If
        If Not IsDBNull(AVG_DEPOSIT_AMT) Then
            lbl_AVG_Deposit_Amount.Text = FormatNumber(AVG_DEPOSIT_AMT, 0)
        Else
            lbl_AVG_Deposit_Amount.Text = "-"
        End If

        '------------- Summary------------
        If Not IsDBNull(SUM_SERVICE_TIME) Then
            lbl_SUM_Service_Time.Text = Engine.ReportENG.GetFormatServiceTime(SUM_SERVICE_TIME)
        Else
            lbl_SUM_Service_Time.Text = "-"
        End If
        If Not IsDBNull(SUM_TRANS_QTY) Then
            lbl_SUM_Transaction.Text = FormatNumber(SUM_TRANS_QTY, 0)
        Else
            lbl_SUM_Transaction.Text = "-"
        End If
        If Not IsDBNull(SUM_WAITING_COLLECT) Then
            lbl_SUM_WaitingCollect.Text = FormatNumber(SUM_WAITING_COLLECT, 0)
        Else
            lbl_SUM_WaitingCollect.Text = "-"
        End If
        If Not IsDBNull(SUM_SUCCESS_TRANSACTIONS) Then
            lbl_SUM_Trans_Success.Text = FormatNumber(SUM_SUCCESS_TRANSACTIONS, 0)
        Else
            lbl_SUM_Trans_Success.Text = "-"
        End If
        If Not IsDBNull(SUM_CANCEL_TRANSACTIONS) Then
            lbl_SUM_Trans_Cancel.Text = FormatNumber(SUM_CANCEL_TRANSACTIONS, 0)
        Else
            lbl_SUM_Trans_Cancel.Text = "-"
        End If
        If Not IsDBNull(SUM_PROBLEM_TRANSACTIONS) Then
            lbl_SUM_Trans_Problem.Text = FormatNumber(SUM_PROBLEM_TRANSACTIONS, 0)
        Else
            lbl_SUM_Trans_Problem.Text = "-"
        End If
        If Not IsDBNull(SUM_TIMEOUT_TRANSACTIONS) Then
            lbl_SUM_Trans_Timeout.Text = FormatNumber(SUM_TIMEOUT_TRANSACTIONS, 0)
        Else
            lbl_SUM_Trans_Timeout.Text = "-"
        End If
        If Not IsDBNull(SUM_SALES_VALUE) Then
            lbl_SUM_Sales_Value.Text = FormatNumber(SUM_SALES_VALUE, 0)
        Else
            lbl_SUM_Sales_Value.Text = "-"
        End If
        If Not IsDBNull(SUM_DEPOSIT_AMT) Then
            lbl_SUM_Deposit_Amount.Text = FormatNumber(SUM_DEPOSIT_AMT, 0)
        Else
            lbl_SUM_Deposit_Amount.Text = "-"
        End If

    End Sub



    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim tdMode As HtmlTableCell = e.Item.FindControl("tdMode")
        Dim lblTime As Label = e.Item.FindControl("lblTime")
        Dim lblProductSize As Label = e.Item.FindControl("lblProductSize")
        Dim lblServiceTime As Label = e.Item.FindControl("lblServiceTime")
        Dim lblTransQty As Label = e.Item.FindControl("lblTransQty")
        Dim lblWaitingCollect As Label = e.Item.FindControl("lblWaitingCollect")
        Dim lblTransSuccess As Label = e.Item.FindControl("lblTransSuccess")
        Dim lblTransCancel As Label = e.Item.FindControl("lblTransCancel")
        Dim lblTransProblem As Label = e.Item.FindControl("lblTransProblem")
        Dim lblTransTimeout As Label = e.Item.FindControl("lblTransTimeout")
        Dim lblSalesValue As Label = e.Item.FindControl("lblSalesValue")
        Dim lblDepositAmount As Label = e.Item.FindControl("lblDepositAmount")

        lblTime.Text = e.Item.DataItem("TimeDisplay").ToString
        lblProductSize.Text = e.Item.DataItem("model_name").ToString
        lblServiceTime.Text = Engine.ReportENG.GetFormatServiceTime(e.Item.DataItem("service_time_int"))
        lblTransQty.Text = FormatNumber(e.Item.DataItem("trans_qty"), 0)
        lblWaitingCollect.Text = FormatNumber(e.Item.DataItem("waiting_collect"), 0)
        lblTransSuccess.Text = FormatNumber(e.Item.DataItem("trans_success"), 0)
        lblTransCancel.Text = FormatNumber(e.Item.DataItem("trans_canceled"), 0)
        lblTransProblem.Text = FormatNumber(e.Item.DataItem("trans_problem"), 0)
        lblTransTimeout.Text = FormatNumber(e.Item.DataItem("trans_timeout"), 0)
        lblSalesValue.Text = FormatNumber(e.Item.DataItem("sales_value"), 0)
        lblDepositAmount.Text = FormatNumber(e.Item.DataItem("deposit_amt"))

        Select Case CurrentPeriod
            Case LockerBL.ReportPeriod.Hourly
                tdMode.Attributes("data-title") = "Hour"
            Case LockerBL.ReportPeriod.Daily
                tdMode.Attributes("data-title") = "Date"
            Case LockerBL.ReportPeriod.Monthly
                tdMode.Attributes("data-title") = "Month"
            Case LockerBL.ReportPeriod.Yearly
                tdMode.Attributes("data-title") = "Year"
        End Select
    End Sub

#Region "Change Mode"

    Protected Property CurrentPeriod As LockerBL.ReportPeriod
        Get
            Select Case True
                Case aByHour.CssClass = "btn btn-success"
                    Return LockerBL.ReportPeriod.Hourly
                Case aByDay.CssClass = "btn btn-success"
                    Return LockerBL.ReportPeriod.Daily
                Case aByMonth.CssClass = "btn btn-success"
                    Return LockerBL.ReportPeriod.Monthly
                Case aByYear.CssClass = "btn btn-success"
                    Return LockerBL.ReportPeriod.Yearly
                Case Else
                    Return LockerBL.ReportPeriod.Unknown
            End Select
        End Get
        Set(value As LockerBL.ReportPeriod)
            pnlFromDate.Visible = False
            pnlToDate.Visible = False
            pnlFromMonth.Visible = False
            pnlToMonth.Visible = False
            pnlFromYear.Visible = False
            pnlToYear.Visible = False

            aByHour.CssClass = "btn btn-default"
            aByDay.CssClass = "btn btn-default"
            aByMonth.CssClass = "btn btn-default"
            aByYear.CssClass = "btn btn-default"

            Select Case value
                Case LockerBL.ReportPeriod.Hourly
                    pnlFromDate.Visible = True
                    pnlToDate.Visible = True

                    aByHour.CssClass = "btn btn-success"
                Case LockerBL.ReportPeriod.Daily
                    pnlFromDate.Visible = True
                    pnlToDate.Visible = True

                    aByDay.CssClass = "btn btn-success"
                Case LockerBL.ReportPeriod.Monthly
                    pnlFromMonth.Visible = True
                    pnlToMonth.Visible = True

                    aByMonth.CssClass = "btn btn-success"
                Case LockerBL.ReportPeriod.Yearly
                    pnlFromYear.Visible = True
                    pnlToYear.Visible = True

                    aByYear.CssClass = "btn btn-success"
                Case Else
            End Select
        End Set
    End Property

    Private Sub aBy_Click(sender As Object, e As System.EventArgs) Handles aByDay.Click, aByHour.Click, aByMonth.Click, aByYear.Click
        Select Case True
            Case Equals(sender, aByHour)
                CurrentPeriod = LockerBL.ReportPeriod.Hourly
            Case Equals(sender, aByDay)
                CurrentPeriod = LockerBL.ReportPeriod.Daily
            Case Equals(sender, aByMonth)
                CurrentPeriod = LockerBL.ReportPeriod.Monthly
            Case Equals(sender, aByYear)
                CurrentPeriod = LockerBL.ReportPeriod.Yearly
        End Select

        BindList()
    End Sub



#End Region

    Private Sub lnkExcel_Click(sender As Object, e As EventArgs) Handles lnkExcel.Click
        Try
            Dim DT As DataTable = CType(Session("Report_SummaryBySize"), DataTable)

            Dim TimeDisplay As String = ""
            Select Case CurrentPeriod
                Case LockerBL.ReportPeriod.Hourly
                    TimeDisplay = "HOUR"
                Case LockerBL.ReportPeriod.Daily
                    TimeDisplay = "DATE"
                Case LockerBL.ReportPeriod.Monthly
                    TimeDisplay = "MONTH"
                Case LockerBL.ReportPeriod.Yearly
                    TimeDisplay = "YEAR"
                Case Else
            End Select

            Dim TmpDT As New DataTable
            TmpDT = Engine.ReportENG.BuildReportSummaryBySizeExcelDataTable(TmpDT, TimeDisplay, DT)
            Dim DR As DataRow = TmpDT.NewRow
            DR(TimeDisplay) = ""
            DR("PRODUCT") = "Average"
            DR("SERVICE_TIME") = lbl_AVG_Service_Time.Text
            DR("TRANSACTION") = lbl_AVG_Transaction.Text
            DR("WAIT_COLLECT") = lbl_AVG_WaitingCollect.Text
            DR("SUCCESS") = lbl_AVG_Trans_Success.Text
            DR("CANCELED") = lbl_AVG_Trans_Cancel.Text
            DR("PROBLEM") = lbl_AVG_Trans_Problem.Text
            DR("TIMEOUT") = lbl_AVG_Trans_Timeout.Text
            DR("SALES_VALUE") = lbl_AVG_Sales_Value.Text
            TmpDT.Rows.Add(DR)

            DR = TmpDT.NewRow
            DR(TimeDisplay) = ""
            DR("PRODUCT") = "Total"
            DR("SERVICE_TIME") = lbl_SUM_Service_Time.Text
            DR("TRANSACTION") = lbl_SUM_Transaction.Text
            DR("WAIT_COLLECT") = lbl_SUM_WaitingCollect.Text
            DR("SUCCESS") = lbl_SUM_Trans_Success.Text
            DR("CANCELED") = lbl_SUM_Trans_Cancel.Text
            DR("PROBLEM") = lbl_SUM_Trans_Problem.Text
            DR("TIMEOUT") = lbl_SUM_Trans_Timeout.Text
            DR("SALES_VALUE") = lbl_SUM_Sales_Value.Text
            TmpDT.Rows.Add(DR)

            Using ep As New ExcelPackage
                Dim ws As ExcelWorksheet = ep.Workbook.Worksheets.Add("Detail")
                ws.Cells("A1").Value = lblHeader.Text
                ws.Cells("A1").Style.Font.Bold = True
                ws.Cells("A1").Style.Font.Size = 18

                BL.ExportExcelPackage(Response, TmpDT, "Report_SummaryBySize.xlsx", 2, ep, ws, 2, 1)
            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class