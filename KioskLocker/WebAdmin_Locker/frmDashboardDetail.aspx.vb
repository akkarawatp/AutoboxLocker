Imports System.Data
Imports System.Data.SqlClient
Imports Engine
Imports System.Drawing

Partial Class frmDashboardDetail
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 1
    Const FunctionalZoneID As Int16 = 1
    'Dim LocationCode As String = ""

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        SetDashboardInfo()
        'BindChart()
        barifram.Src = "frmBarChart.aspx?LocationID=" & Request("LocationID")

    End Sub

    Private Sub SetDashboardInfo()
        Dim UserName As String = Session("UserName")
        Dim LocationID As String = Request("LocationID")
        BindWeekSection(LocationID)
        BindMonthIncome(LocationID)
        BindIncomeSummary(LocationID)

        Dim lnq As New ServerLinqDB.TABLE.MsLocationServerLinqDB
        lnq.GetDataByPK(LocationID, Nothing)
        If lnq.ID > 0 Then
            lblLocationName.Text = lnq.LOCATION_NAME

            lblGrossProfitRate.Text = lnq.GROSS_PROFIT_RATE
            lblRenterRate.Text = (100 - lnq.GROSS_PROFIT_RATE)

            Dim CompanyPercent As Double = (lblGrossProfitRate.Text / 100)
            If lblDailySales.Text.Trim <> "-" Then lblCompanyDayIncome.Text = (lblDailySales.Text * CompanyPercent).ToString("#,##0")
            If lblWeeklySales.Text.Trim <> "-" Then lblCompanyWeekIncome.Text = (lblWeeklySales.Text * CompanyPercent).ToString("#,##0")
            If lblMonthlySales.Text.Trim <> "-" Then lblCompanyMonthIncome.Text = (lblMonthlySales.Text * CompanyPercent).ToString("#,##0")

            Dim RenterPercent As Double = (lblRenterRate.Text / 100)
            If lblDailySales.Text.Trim <> "-" Then lblRenterDayIncome.Text = (lblDailySales.Text * RenterPercent).ToString("#,##0")
            If lblWeeklySales.Text.Trim <> "-" Then lblRenterWeekIncome.Text = (lblWeeklySales.Text * RenterPercent).ToString("#,##0")
            If lblMonthlySales.Text.Trim <> "-" Then lblRenterMonthIncome.Text = (lblMonthlySales.Text * RenterPercent).ToString("#,##0")
        End If
        lnq = Nothing
    End Sub

#Region "Week Section"
    Private Function GetWeekIncomeDetail(LocationID As Long) As DataTable
        Dim sql As String = "select k.ms_location_id, convert(varchar(8),p.pickup_time,112) pickup_date , " & vbNewLine
        sql += " sum(p.service_amt + p.fine_amt) net_income" & vbNewLine
        sql += "        From TB_DEPOSIT_TRANSACTION s" & vbNewLine
        sql += " inner join tb_pickup_transaction p On s.trans_no=p.deposit_trans_no" & vbNewLine
        sql += " inner join MS_KIOSK k on k.id=s.ms_kiosk_id" & vbNewLine
        sql += " where s.trans_status = 1 And p.trans_status = 1 " & vbNewLine
        sql += " And Convert(varchar(6), p.pickup_time, 112) = convert(varchar(6), getdate(),112)" & vbNewLine
        sql += " And convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) And convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " And k.ms_location_id=@_LOCATION_ID" & vbNewLine
        sql += " Group by k.ms_location_id, convert(varchar(8),p.pickup_time,112)" & vbNewLine
        sql += " order by convert(varchar(8),p.pickup_time,112) "

        Dim p(1) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_LOCATION_ID", LocationID)
        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        Return DT
    End Function
    Private Sub BindWeekSection(LocationID As Long)
        Dim dt As New DataTable
        dt.Columns.Add("week_no", GetType(Integer))
        dt.Columns.Add("date_start", GetType(DateTime))
        dt.Columns.Add("date_end", GetType(DateTime))

        Dim FirstDayOfWeek As Date = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        Dim LastDayOfWeek As Date = DateAdd(DateInterval.Day, 7 - (FirstDayOfWeek.DayOfWeek + 1), FirstDayOfWeek)

        For i As Integer = 1 To 5
            Dim dr As DataRow = dt.NewRow
            dr("week_no") = i
            dr("date_start") = FirstDayOfWeek
            dr("date_end") = LastDayOfWeek
            dt.Rows.Add(dr)

            FirstDayOfWeek = DateAdd(DateInterval.Day, 7, FirstDayOfWeek)
            If FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday Then
                FirstDayOfWeek = DateAdd(DateInterval.Day, 1, LastDayOfWeek)
            End If

            LastDayOfWeek = DateAdd(DateInterval.Day, 7, LastDayOfWeek)
            If LastDayOfWeek.Month <> DateTime.Now.Month Then
                LastDayOfWeek = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
            End If
        Next

        WeekDt = GetWeekIncomeDetail(LocationID)

        rtpWeekIncomeSection.DataSource = dt
        rtpWeekIncomeSection.DataBind()

    End Sub

    Dim WeekDt As New DataTable
    Private Sub rtpWeekIncomeSection_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rtpWeekIncomeSection.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblWeekNo As Label = e.Item.FindControl("lblWeekNo")
        Dim rptWeekDetail As Repeater = e.Item.FindControl("rptWeekDetail")
        AddHandler rptWeekDetail.ItemDataBound, AddressOf rptWeekDetail_ItemDataBound

        lblWeekNo.Text = e.Item.DataItem("week_no")

        Dim dt As New DataTable
        dt.Columns.Add("net_income", GetType(Integer))
        dt.Columns.Add("pickup_date", GetType(Date))
        Dim d As Date = Convert.ToDateTime(e.Item.DataItem("date_start"))
        Do
            Dim dr As DataRow = dt.NewRow
            dr("pickup_date") = d

            If WeekDt.Rows.Count > 0 Then
                WeekDt.DefaultView.RowFilter = "pickup_date='" & d.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'"
                If WeekDt.DefaultView.Count > 0 Then
                    dr("net_income") = WeekDt.DefaultView(0)("net_income")
                End If
                WeekDt.DefaultView.RowFilter = ""
            End If
            dt.Rows.Add(dr)

            d = DateAdd(DateInterval.Day, 1, d)
        Loop While d <= Convert.ToDateTime(e.Item.DataItem("date_end"))

        rptWeekDetail.DataSource = dt
        rptWeekDetail.DataBind()
    End Sub

    Private Sub rptWeekDetail_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub
        Dim lblPickupDate As Label = e.Item.FindControl("lblPickupDate")
        Dim lblIncome As Label = e.Item.FindControl("lblIncome")

        lblPickupDate.Text = Convert.ToDateTime(e.Item.DataItem("pickup_date")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
        If Convert.IsDBNull(e.Item.DataItem("net_income")) = False Then
            lblIncome.Text = Convert.ToInt64(e.Item.DataItem("net_income")).ToString("#,##0")
        Else
            lblIncome.Text = " - "
        End If
    End Sub
#End Region

#Region "Month Section"
    Private Sub BindMonthIncome(LocationID As Long)
        Dim sql As String = "select k.ms_location_id, month(p.pickup_time) pickup_month , " & vbNewLine
        sql += " sum(p.service_amt + p.fine_amt) net_income" & vbNewLine
        sql += "        From TB_DEPOSIT_TRANSACTION s" & vbNewLine
        sql += " inner join tb_pickup_transaction p On s.trans_no=p.deposit_trans_no" & vbNewLine
        sql += " inner join MS_KIOSK k on k.id=s.ms_kiosk_id" & vbNewLine
        sql += " where s.trans_status = 1 And p.trans_status = 1 " & vbNewLine
        sql += " And Convert(varchar(4), p.pickup_time, 112) = convert(varchar(4), getdate(),112)" & vbNewLine
        sql += " And convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) And convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " And k.ms_location_id=@_LOCATION_ID" & vbNewLine
        sql += " Group by k.ms_location_id, month(p.pickup_time)" & vbNewLine
        sql += " order by month(p.pickup_time) "

        Dim p(1) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_LOCATION_ID", LocationID)
        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)

        Dim mDt As New DataTable
        mDt.Columns.Add("month_name")
        mDt.Columns.Add("net_income", GetType(Integer))
        For i As Integer = 1 To 12
            Dim dr As DataRow = mDt.NewRow
            dr("month_name") = Converter.ToMonthNameEN(i)

            DT.DefaultView.RowFilter = "pickup_month = " & i
            If DT.DefaultView.Count > 0 Then
                dr("net_income") = DT.DefaultView(0)("net_income")
            End If
            DT.DefaultView.RowFilter = ""

            mDt.Rows.Add(dr)
        Next

        rptMonthIncome.DataSource = mDt
        rptMonthIncome.DataBind()
    End Sub

    Private Sub rptMonthIncome_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptMonthIncome.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblMonthName As Label = e.Item.FindControl("lblMonthName")
        Dim lblMonthIncome As Label = e.Item.FindControl("lblMonthIncome")

        lblMonthName.Text = e.Item.DataItem("month_name")
        If Convert.IsDBNull(e.Item.DataItem("net_income")) = False Then
            lblMonthIncome.Text = Convert.ToInt64(e.Item.DataItem("net_income")).ToString("#,##0")
        Else
            lblMonthIncome.Text = " - "
        End If
    End Sub
#End Region
    Private Sub BindIncomeSummary(LocationID As Long)
        Dim sql As String = "select s.ms_kiosk_id, convert(date, p.pickup_time) TXN_DATE, convert(varchar(8),p.pickup_time,112) wh_date," & vbNewLine
        sql += " sum(p.service_amt+p.fine_amt) net_income" & vbNewLine
        sql += " from TB_DEPOSIT_TRANSACTION s" & vbNewLine
        sql += " inner join tb_pickup_transaction p On s.trans_no=p.deposit_trans_no" & vbNewLine
        sql += " inner join MS_KIOSK k on k.id=s.ms_kiosk_id" & vbNewLine
        sql += " where s.trans_status=1 and p.trans_status=1 " & vbNewLine
        sql += " And Convert(varchar(4), p.pickup_time, 112) = convert(varchar(4), getdate(),112)" & vbNewLine
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " and k.ms_location_id=@_LOCATION_ID " & vbNewLine
        sql += " group by s.ms_kiosk_id,  convert(date, p.pickup_time) , convert(varchar(8),p.pickup_time,112) " & vbNewLine
        sql += " order by convert(date, p.pickup_time)  "

        Dim p(1) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_LOCATION_ID", LocationID)
        'p(1) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_USERNAME", UserName)

        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        If DT.Rows.Count > 0 Then

            Dim Obj As Object
            Obj = DT.Compute("SUM(NET_INCOME)", "wh_date='" & Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'")
            If Not IsDBNull(Obj) Then
                lblDailySales.Text = FormatNumber(Obj, 0)
            Else
                lblDailySales.Text = "-"
            End If

            Dim StartWeek As String = Engine.ReportENG.GetFirstDayOfWeek(Now).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim EndWeek = Engine.ReportENG.GetLastDayOfWeek(Now).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Obj = DT.Compute("SUM(NET_INCOME)", "wh_date>='" & StartWeek & "' AND wh_date<='" & EndWeek & "'")
            If Not IsDBNull(Obj) Then
                lblWeeklySales.Text = FormatNumber(Obj, 0)
                lblSalesValues.Text = FormatNumber(Obj, 0)
            Else
                lblWeeklySales.Text = " - "
                lblSalesValues.Text = " - "
            End If

            Dim StartMonth As String = Now.ToString("yyyyMM", New Globalization.CultureInfo("en-US")) & "01"
            Dim EndMonth As String = Now.ToString("yyyyMM", New Globalization.CultureInfo("en-US")) & DateTime.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
            Obj = DT.Compute("SUM(NET_INCOME)", "wh_date>='" & StartMonth & "' AND wh_date<='" & EndMonth & "'")
            If Not IsDBNull(Obj) Then
                lblMonthlySales.Text = FormatNumber(Obj, 0)
            Else
                lblMonthlySales.Text = " - "
            End If

            Obj = DT.Compute("SUM(NET_INCOME)", "")
            If Not IsDBNull(Obj) Then
                lblYearlySales.Text = FormatNumber(Obj, 0)
            Else
                lblYearlySales.Text = " - "
            End If
        End If
        DT.Dispose()
    End Sub


    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click

    End Sub


End Class
