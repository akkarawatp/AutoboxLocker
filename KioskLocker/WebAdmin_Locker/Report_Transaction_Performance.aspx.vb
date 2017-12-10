Imports System.Data.SqlClient
Imports System.Data
Imports ServerLinqDB.ConnectDB
Public Class Report_Transaction_Performance
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 22
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
        txtStartDate.Text = ""
        txtEndDate.Text = ""

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

        lblHeader.Text = "รายงานสรุป Transaction Performance"
        Dim wh As String = ""
        If ddlLocation.SelectedValue.Trim <> "" Then
            wh += " And l.id =@_LOCATION_ID " + Environment.NewLine
            parm(0) = ServerDB.SetBigInt("@_LOCATION_ID", ddlLocation.SelectedValue)
            lblHeader.Text &= " ที่ " & ddlLocation.Items(ddlLocation.SelectedIndex).Text & " "
        Else
            If Session("List_User_LocationID") IsNot Nothing Then
                wh += " and l.id in (" & Session("List_User_LocationID") & ") " + Environment.NewLine
                lblHeader.Text &= " ทุก Location " & ddlLocation.Items(ddlLocation.SelectedIndex).Text & " "
            Else
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
            End If
        End If

        Select Case CInt(CurrentPeriod)
            Case LockerBL.ReportPeriod.Hourly, LockerBL.ReportPeriod.Daily '-------------------Hourly/Daily----------------------
                If txtStartDate.Text.Trim <> "" Then
                    Dim TimeStart As DateTime = Converter.ConvertTextToDate(txtStartDate.Text)
                    lblHeader.Text &= " ตั้งแต่ " & Converter.ConvertTextToDate(txtStartDate.Text).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                    wh += " and convert(date,trans_start_time)  >= @_TIME_START " + Environment.NewLine
                    parm(1) = ServerDB.SetDateTime("@_TIME_START", TimeStart)
                End If

                If txtEndDate.Text.Trim <> "" Then
                    Dim TimeEnd As DateTime = Converter.ConvertTextToDate(txtEndDate.Text)
                    lblHeader.Text &= " ถึง " & Converter.ConvertTextToDate(txtEndDate.Text).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                    wh += " And convert(date,trans_start_time) <= @_TIME_END " + Environment.NewLine
                    parm(2) = ServerDB.SetDateTime("@_TIME_END", TimeEnd)
                End If
            Case LockerBL.ReportPeriod.Monthly '-------------------Monthly----------------------
                lblHeader.Text &= "รายเดือน"

                If ddlFromMonth.SelectedValue <> 0 And ddlFromMonth.SelectedValue = ddlToMonth.SelectedValue Then
                    lblHeader.Text &= " ประจำเดือน " & ddlFromMonth.Items(ddlFromMonth.SelectedIndex).Text & " "
                    wh += " and convert(varchar(6),trans_start_time,112) = @_MONTH_FROM " + Environment.NewLine
                    parm(3) = ServerDB.SetBigInt("@_MONTH_FROM", ddlFromMonth.SelectedValue)
                Else
                    If ddlFromMonth.SelectedValue <> 0 Then
                        wh += " and convert(varchar(6),trans_start_time,112) >= @_MONTH_FROM " + Environment.NewLine
                        parm(3) = ServerDB.SetBigInt("@_MONTH_FROM", ddlFromMonth.SelectedValue)
                        lblHeader.Text &= " ตั้งแต่ " & ddlFromMonth.Items(ddlFromMonth.SelectedIndex).Text & " "
                    End If
                    If ddlToMonth.SelectedValue <> 0 Then
                        wh += " and convert(varchar(6),trans_start_time,112) <= @_MONTH_TO " + Environment.NewLine
                        parm(4) = ServerDB.SetBigInt("@_MONTH_TO", ddlToMonth.SelectedValue)
                        lblHeader.Text &= " ถึง " & ddlToMonth.Items(ddlToMonth.SelectedIndex).Text & " "
                    End If
                End If
            Case LockerBL.ReportPeriod.Yearly '-------------------Yearly----------------------
                lblHeader.Text &= "รายปี "
                If ddlFromYear.SelectedValue <> 0 And ddlFromYear.SelectedValue = ddlToYear.SelectedValue Then
                    lblHeader.Text &= " ประจำปี " & ddlFromYear.SelectedValue
                    wh += " and year(trans_start_time) = @_YEAR_FROM" + Environment.NewLine
                    parm(5) = ServerDB.SetBigInt("@_YEAR_FROM", ddlFromYear.SelectedValue)
                Else
                    If ddlFromYear.SelectedValue <> 0 Then
                        wh += " and year(trans_start_time) >= @_YEAR_FROM" + Environment.NewLine
                        parm(5) = ServerDB.SetBigInt("@_YEAR_FROM", ddlFromYear.SelectedValue)
                        lblHeader.Text &= " ตั้งแต่ " & ddlFromYear.SelectedValue & " "
                    End If
                    If ddlToYear.SelectedValue <> 0 Then
                        wh += " and year(trans_start_time) <= @_YEAR_TO" + Environment.NewLine
                        parm(6) = ServerDB.SetBigInt("@_YEAR_TO", ddlToYear.SelectedValue)
                        lblHeader.Text &= " ถึง " & ddlToYear.SelectedValue & " "
                    End If
                End If
        End Select

        Dim sql As String = ""
        If rdiTransDeposit.CssClass.IndexOf("success") > -1 Then
            sql = "DECLARE @MODE AS INT=" & CInt(CurrentPeriod) & "; " + Environment.NewLine
            sql += Engine.ReportENG.GetQueryDepositTransactionPerformance(wh)
            sql += " order by l.location_name, TimeValue "
        Else
            sql = "DECLARE @MODE AS INT=" & CInt(CurrentPeriod) & "; " + Environment.NewLine
            sql += Engine.ReportENG.GetQueryCollectTransactionPerformance(wh)
            sql += " order by l.location_name, TimeValue "
        End If

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
        Session("Report_Transaction_Performance") = DT
        rptList.DataSource = DT
        rptList.DataBind()

        If DT.Rows.Count = 0 Then
            lblHeader.Text &= " ไม่พบข้อมูล "
        Else
            lblHeader.Text &= " พบ " & DT.Rows.Count & " Record(s)"
        End If

        '--------------- Report Summary ------------
        Dim AVG_TOTAL_TRANSACTIONS As Object = DT.Compute("AVG(trans_total)", "")
        Dim AVG_CANCEL_TRANSACTIONS As Object = DT.Compute("AVG(trans_canceled)", "")
        Dim AVG_PROBLEM_TRANSACTIONS As Object = DT.Compute("AVG(trans_problem)", "")
        Dim AVG_TIMEOUT_TRANSACTIONS As Object = DT.Compute("AVG(trans_timeout)", "")
        Dim AVG_SUCCESS_TRANSACTIONS As Object = DT.Compute("AVG(trans_success)", "")

        Dim SUM_TOTAL_TRANSACTIONS As Object = DT.Compute("SUM(trans_total)", "")
        Dim SUM_CANCEL_TRANSACTIONS As Object = DT.Compute("SUM(trans_canceled)", "")
        Dim SUM_PROBLEM_TRANSACTIONS As Object = DT.Compute("SUM(trans_problem)", "")
        Dim SUM_TIMEOUT_TRANSACTIONS As Object = DT.Compute("SUM(trans_timeout)", "")
        Dim SUM_SUCCESS_TRANSACTIONS As Object = DT.Compute("SUM(trans_success)", "")

        '------------- Average------------
        If Not IsDBNull(AVG_TOTAL_TRANSACTIONS) Then
            lbl_AVG_Trans_Total.Text = FormatNumber(AVG_TOTAL_TRANSACTIONS, 0)
        Else
            lbl_AVG_Trans_Total.Text = "-"
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
        If Not IsDBNull(AVG_SUCCESS_TRANSACTIONS) Then
            lbl_AVG_Trans_Success.Text = FormatNumber(AVG_SUCCESS_TRANSACTIONS, 0)
        Else
            lbl_AVG_Trans_Success.Text = "-"
        End If

        '------------- Summary------------
        If Not IsDBNull(SUM_TOTAL_TRANSACTIONS) Then
            lbl_SUM_Trans_Total.Text = FormatNumber(SUM_TOTAL_TRANSACTIONS, 0)
        Else
            lbl_SUM_Trans_Total.Text = "-"
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

        If Not IsDBNull(SUM_SUCCESS_TRANSACTIONS) Then
            lbl_SUM_Trans_Success.Text = FormatNumber(SUM_SUCCESS_TRANSACTIONS, 0)
        Else
            lbl_SUM_Trans_Success.Text = "-"
        End If

    End Sub

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim tdMode As HtmlTableCell = e.Item.FindControl("tdMode")
        Dim lblTime As Label = e.Item.FindControl("lblTime")
        Dim lblLocation As Label = e.Item.FindControl("lblLocation")
        Dim lblTransactionType As Label = e.Item.FindControl("lblTransactionType")
        Dim lblTransSuccess As Label = e.Item.FindControl("lblTransSuccess")
        Dim lblTransCancel As Label = e.Item.FindControl("lblTransCancel")
        Dim lblTransProblem As Label = e.Item.FindControl("lblTransProblem")
        Dim lblTransTimeout As Label = e.Item.FindControl("lblTransTimeout")
        Dim lblTransTotal As Label = e.Item.FindControl("lblTransTotal")

        lblTime.Text = e.Item.DataItem("TimeDisplay").ToString
        lblLocation.Text = e.Item.DataItem("location_name").ToString
        lblTransactionType.Text = e.Item.DataItem("transaction_type").ToString
        lblTransSuccess.Text = FormatNumber(e.Item.DataItem("trans_success"), 0)
        lblTransCancel.Text = FormatNumber(e.Item.DataItem("trans_canceled"), 0)
        lblTransProblem.Text = FormatNumber(e.Item.DataItem("trans_problem"), 0)
        lblTransTimeout.Text = FormatNumber(e.Item.DataItem("trans_timeout"), 0)
        lblTransTotal.Text = FormatNumber(e.Item.DataItem("trans_total"), 0)

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

            aByHour.CssClass = "btn btn-warning"
            aByDay.CssClass = "btn btn-warning"
            aByMonth.CssClass = "btn btn-warning"
            aByYear.CssClass = "btn btn-warning"

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
            Dim DT As DataTable = CType(Session("Report_Transaction_Performance"), DataTable)

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
            TmpDT = Engine.ReportENG.BuiltReportTransactionPerformanceExcelDataTable(TmpDT, TimeDisplay, DT)
            Dim DR As DataRow
            DR = TmpDT.NewRow
            DR(TimeDisplay) = ""
            DR("LOCATION") = "Average"
            DR("SUCCESS") = lbl_AVG_Trans_Success.Text
            DR("CANCELED") = lbl_AVG_Trans_Cancel.Text
            DR("PROBLEM") = lbl_AVG_Trans_Problem.Text
            DR("TIMEOUT") = lbl_AVG_Trans_Timeout.Text
            DR("TOTAL") = lbl_AVG_Trans_Total.Text
            TmpDT.Rows.Add(DR)

            DR = TmpDT.NewRow
            DR(TimeDisplay) = ""
            DR("LOCATION") = "Total"
            DR("SUCCESS") = lbl_SUM_Trans_Success.Text
            DR("CANCELED") = lbl_SUM_Trans_Cancel.Text
            DR("PROBLEM") = lbl_SUM_Trans_Problem.Text
            DR("TIMEOUT") = lbl_SUM_Trans_Timeout.Text
            DR("TOTAL") = lbl_SUM_Trans_Total.Text
            TmpDT.Rows.Add(DR)

            BL.ExportToExcel(Response, TmpDT, "Report_Transaction_Performance.xlsx", 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdiTransCollect_Click(sender As Object, e As EventArgs) Handles rdiTransCollect.Click, rdiTransDeposit.Click
        Dim a As LinkButton = sender

        '----------------- Deselected All---------------
        rdiTransDeposit.Text = "<i class=""fa fa-times""></i> DEPOSIT"
        rdiTransCollect.Text = "<i class=""fa fa-times""></i> COLLECT"
        rdiTransDeposit.CssClass = "btn btn-warning"
        rdiTransCollect.CssClass = "btn btn-warning"

        Select Case a.Attributes("role")
            Case "D"
                rdiTransDeposit.Text = "<i class=""fa fa-check""></i> DEPOSIT"
                rdiTransDeposit.CssClass = "btn btn-success"
            Case "C"
                rdiTransCollect.Text = "<i class=""fa fa-check""></i> COLLECT"
                rdiTransCollect.CssClass = "btn btn-success"
        End Select
    End Sub
End Class