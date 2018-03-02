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

        SetHeaderInfo()
        'BindChart()
        barifram.Src = "frmBarChart.aspx?LocationID=" & Request("LocationID")

    End Sub

    Private Sub SetHeaderInfo()
        Dim UserName As String = Session("UserName")
        Dim LocationID As String = Request("LocationID")

        Dim lnq As New ServerLinqDB.TABLE.MsLocationServerLinqDB
        lnq.GetDataByPK(LocationID, Nothing)
        If lnq.ID > 0 Then
            lblLocationName.Text = lnq.LOCATION_NAME
        End If
        lnq = Nothing

        BindLine(UserName, LocationID)
    End Sub

    Private Sub BindChart()
        Dim UserName As String = Session("UserName")
        Dim LocationID As String = Request("LocationID")

        BindLinePoint(UserName, LocationID)
        BindLine(UserName, LocationID)
        BindBar(UserName, LocationID)
        BindRadar(UserName, LocationID)
        BindNotification(UserName, LocationID)
    End Sub

    Private Sub BindLinePoint(UserName As String, LocationID As Long)
        Dim sql As String = "select s.ms_kiosk_id, convert(date, p.pickup_time) TXN_DATE, convert(varchar(8),p.pickup_time,112) wh_date," & vbNewLine
        sql += " sum(p.service_amt) net_income" & vbNewLine
        sql += " from TB_DEPOSIT_TRANSACTION s" & vbNewLine
        sql += " inner join tb_pickup_transaction p On s.trans_no=p.deposit_trans_no" & vbNewLine
        sql += " inner join MS_KIOSK k on k.id=s.ms_kiosk_id" & vbNewLine
        sql += " where s.trans_status=1 and p.trans_status=1 " & vbNewLine
        sql += " And Convert(varchar(4), p.pickup_time, 112) = convert(varchar(4), getdate(),112)" & vbNewLine
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " and k.ms_location_id=@_LOCATION_ID " & vbNewLine
        sql += " And k.ms_location_id In (Select ul.ms_location_id " & vbNewLine
        sql += " 	from MS_USER_LOCATION ul  " & vbNewLine
        sql += " 	inner join MS_LOCATION l On l.id=ul.ms_location_id " & vbNewLine
        sql += " 	where l.active_status='Y' and ul.username=@_USERNAME) " & vbNewLine
        sql += " group by s.ms_kiosk_id,  convert(date, p.pickup_time) , convert(varchar(8),p.pickup_time,112) " & vbNewLine
        sql += " order by convert(date, p.pickup_time)  "

        Dim p(2) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_LOCATION_ID", LocationID)
        p(1) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_USERNAME", UserName)

        Dim dtt As New DataTable
        dtt.Columns.Add("Dstr")
        dtt.Columns.Add("net_income")

        Dim dr As DataRow
        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        If DT.Rows.Count > 0 Then
            For i As Integer = 7 To 0 Step -1
                dr = dtt.NewRow
                Dim D As Date = DateAdd(DateInterval.Day, -i, Now)
                Dim Dstr As String = D.ToString("MMM dd yyyy")
                dr("Dstr") = Dstr
                DT.DefaultView.RowFilter = "wh_date='" & D.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'"

                If DT.DefaultView.Count > 0 Then
                    dr("net_income") = Convert.ToInt16(DT.DefaultView(0)("net_income"))
                Else
                    dr("net_income") = 0
                End If
                dtt.Rows.Add(dr)
                DT.DefaultView.RowFilter = ""
            Next

            'LineChart.ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.White
            'LineChart.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Thahoma", 10, FontStyle.Regular)

            LineChart.ChartAreas(0).BackColor = Color.Transparent
            LineChart.Series(0).IsValueShownAsLabel = True
            LineChart.Series(0).Color = ColorTranslator.FromHtml("#36C3F2")

            LineChart.DataSource = dtt
            LineChart.DataBind()
        End If
    End Sub

    Private Sub BindLine(UserName As String, LocationID As Long)
        Dim sql As String = "select s.ms_kiosk_id, convert(date, p.pickup_time) TXN_DATE, convert(varchar(8),p.pickup_time,112) wh_date," & vbNewLine
        sql += " sum(p.service_amt+p.fine_amt) net_income" & vbNewLine
        sql += " from TB_DEPOSIT_TRANSACTION s" & vbNewLine
        sql += " inner join tb_pickup_transaction p On s.trans_no=p.deposit_trans_no" & vbNewLine
        sql += " inner join MS_KIOSK k on k.id=s.ms_kiosk_id" & vbNewLine
        sql += " where s.trans_status=1 and p.trans_status=1 " & vbNewLine
        sql += " And Convert(varchar(4), p.pickup_time, 112) = convert(varchar(4), getdate(),112)" & vbNewLine
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " and k.ms_location_id=@_LOCATION_ID " & vbNewLine
        sql += " And k.ms_location_id In (Select ul.ms_location_id " & vbNewLine
        sql += " 	from MS_USER_LOCATION ul  " & vbNewLine
        sql += " 	inner join MS_LOCATION l On l.id=ul.ms_location_id " & vbNewLine
        sql += " 	where l.active_status='Y' and ul.username=@_USERNAME) " & vbNewLine
        sql += " group by s.ms_kiosk_id,  convert(date, p.pickup_time) , convert(varchar(8),p.pickup_time,112) " & vbNewLine
        sql += " order by convert(date, p.pickup_time)  "

        Dim p(2) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_LOCATION_ID", LocationID)
        p(1) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_USERNAME", UserName)

        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        If DT.Rows.Count > 0 Then
            '----------------- Line Chart For This Week ------------
            Dim Script As String = "$( document ).ready(function() {" & vbLf
            Script &= "var _lineData=[" & vbLf
            Dim C As New ConverterENG
            Dim Obj As Object
            For i As Integer = 7 To 0 Step -1
                Dim D As Date = DateAdd(DateInterval.Day, -i, Now)
                Dim Dstr As String = D.ToString("MMM dd yyyy")

                DT.DefaultView.RowFilter = "wh_date='" & D.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'"
                If DT.DefaultView.Count > 0 Then
                    Script &= "['" & Dstr & "', " & Convert.ToInt16(DT.DefaultView(0)("net_income")) & "]"
                Else
                    Script &= "['" & Dstr & "',0]"
                End If
                If i <> 7 Then Script &= ","
                Script &= vbLf

                DT.DefaultView.RowFilter = ""
            Next
            Script &= "];" & vbLf & vbLf
            Script &= "var lineData = [" & vbLf
            Script &= " {" & vbLf
            Script &= "     data: _lineData," & vbLf
            Script &= "     color:  '#fff'" & vbLf
            Script &= " }" & vbLf
            Script &= "];" & vbLf

            Script &= "render_Line(lineData);" & vbLf
            Script &= "});" & vbLf
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "LineChart", Script, True)

            Obj = DT.Compute("SUM(NET_INCOME)", "wh_date='" & Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) & "'")
            If Not IsDBNull(Obj) Then
                lblDailySales.Text = FormatNumber(Obj, 0) & " ฿"
            Else
                lblDailySales.Text = "-"
            End If

            Dim StartWeek As String = Engine.ReportENG.GetFirstDayOfWeek(Now).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim EndWeek = Engine.ReportENG.GetLastDayOfWeek(Now).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Obj = DT.Compute("SUM(NET_INCOME)", "wh_date>='" & StartWeek & "' AND wh_date<='" & EndWeek & "'")
            If Not IsDBNull(Obj) Then
                lblWeeklySales.Text = FormatNumber(Obj, 0) & " ฿"
                lblSalesValues.Text = FormatNumber(Obj, 0) & " ฿"
            Else
                lblWeeklySales.Text = " - "
                lblSalesValues.Text = " - "
            End If

            Dim StartMonth As String = Now.ToString("yyyyMM", New Globalization.CultureInfo("en-US")) & "01"
            Dim EndMonth As String = Now.ToString("yyyyMM", New Globalization.CultureInfo("en-US")) & DateTime.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
            Obj = DT.Compute("SUM(NET_INCOME)", "wh_date>='" & StartMonth & "' AND wh_date<='" & EndMonth & "'")
            If Not IsDBNull(Obj) Then
                lblMonthlySales.Text = FormatNumber(Obj, 0) & " ฿"
            Else
                lblMonthlySales.Text = " - "
            End If

            Obj = DT.Compute("SUM(NET_INCOME)", "")
            If Not IsDBNull(Obj) Then
                lblYearlySales.Text = FormatNumber(Obj, 0) & " ฿"
            Else
                lblYearlySales.Text = " - "
            End If
        End If
        DT.Dispose()
    End Sub



    Private Sub BindBar(UserName As String, LocationID As Long)
        Dim sql As String = "select  x.trans_type, x.trans_status, x.MONTH_NAME, x.TXN_MONTH, sum(x.trans_qty) trans_qty, x.ms_kiosk_id "
        sql += " from ( "
        sql += " 	select  datename(YEAR,isnull(s.trans_start_time,s.paid_time))  TXN_YEAR, "
        sql += " 	datename(MONTH,isnull(s.trans_start_time,s.paid_time)) MONTH_NAME, "
        sql += " 	convert(varchar(6),isnull(s.trans_start_time,s.paid_time),112) TXN_MONTH, "
        sql += " 	Case When s.trans_status = '1' then 'SUCCESS' else 'LOST' end trans_status, 'DEPOSIT' trans_type, "
        sql += " 	count(s.id) trans_qty, s.ms_kiosk_id "
        sql += " 	from TB_DEPOSIT_TRANSACTION s "
        sql += " 	group by datename(YEAR,isnull(s.trans_start_time,s.paid_time)) , "
        sql += " 	datename(MONTH,isnull(s.trans_start_time,s.paid_time)) , "
        sql += " 	convert(varchar(6),isnull(s.trans_start_time,s.paid_time),112) , "
        sql += " 	Case When s.trans_status = '1' then 'SUCCESS' else 'LOST' end, s.ms_kiosk_id "
        sql += " 	union all "
        sql += " 	Select  datename(YEAR,p.trans_start_time)  TXN_DATE, "
        sql += " 	datename(MONTH,p.trans_start_time) MONTH_NAME, "
        sql += " 	convert(varchar(6),p.trans_start_time,112) TXN_MONTH, "
        sql += " 	case when p.trans_status = '1' then 'SUCCESS' else 'LOST' end trans_status,  'COLLECT' trans_type, "
        sql += " 	count(p.id) trans_qty, p.ms_kiosk_id "
        sql += " 	from TB_PICKUP_TRANSACTION p "
        sql += " 	group by  datename(YEAR,p.trans_start_time), "
        sql += " 	datename(MONTH,p.trans_start_time) , "
        sql += " 	convert(varchar(6),p.trans_start_time,112) , "
        sql += " 	case when p.trans_status = '1' then 'SUCCESS' else 'LOST' end, p.ms_kiosk_id "
        sql += " ) x "
        sql += " inner join MS_KIOSK k on k.id=x.ms_kiosk_id"
        sql += " where convert(varchar(4), x.TXN_YEAR,112)=convert(varchar(4),getdate(),112) "
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " and k.ms_location_id = @_LOCATION_ID " & vbNewLine
        sql += " And k.ms_location_id In (Select ul.ms_location_id " & vbNewLine
        sql += " 			from MS_USER_LOCATION ul  " & vbNewLine
        sql += " 			inner join MS_LOCATION l On l.id=ul.ms_location_id " & vbNewLine
        sql += " 			where l.active_status='Y' and ul.username=@_USERNAME) " & vbNewLine
        sql += " group by x.TXN_YEAR, x.MONTH_NAME, x.TXN_MONTH, x.trans_type, x.trans_status, x.ms_kiosk_id "

        Dim p(2) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_LOCATION_ID", LocationID)
        p(1) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_USERNAME", UserName)
        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        If DT.Rows.Count > 0 Then
            Dim GL As New GenericLib
            Dim M As Integer = DatePart(DateInterval.Month, Now)
            Dim Obj As Object
            'Run Series
            Dim Script As String = "$( document ).ready(function() {" & vbLf
            Script &= "var barData = [" & vbLf

            '------------------- DEPOSIT SUCCESS Transaction --------------------
            Script &= "{" & vbLf
            Script &= " data: [" & vbLf
            For i As Integer = 1 To M
                Dim D As New DateTime(Now.Year, i, 1)
                Script &= " [" & GL.GetJavascriptTimestamp(D) & ","
                Obj = DT.Compute("sum(trans_qty)", "TXN_MONTH = '" & Now.Year & i.ToString.PadLeft(2, "0") & "' and trans_status='SUCCESS' and trans_type='DEPOSIT'")
                If Not IsDBNull(Obj) Then
                    Script &= CInt(Obj) & "]"
                Else
                    Script &= "0]"
                End If
                If i <> M Then
                    Script &= "," & vbLf
                Else
                    Script &= vbLf
                End If
            Next
            Script &= " ]," & vbLf
            Script &= " bars: {" & vbLf
            Script &= "    show: true," & vbLf
            Script &= "    barWidth: 7 * 24 * 60 * 60 * 1000," & vbLf
            Script &= "    fill: true," & vbLf
            Script &= "    lineWidth: 0," & vbLf
            Script &= "    order: 1," & vbLf
            Script &= "    fillColor: $.staticApp.primary" & vbLf
            Script &= "     }" & vbLf
            'Script &= ",{label:'Buy New SIM'}"
            Script &= "}," & vbLf

            '------------------- COLLECT SUCCESS Transaction --------------------
            Script &= "{" & vbLf
            Script &= " data: [" & vbLf
            For i As Integer = 1 To M
                Dim D As New DateTime(Now.Year, i, 1)
                Script &= " [" & GL.GetJavascriptTimestamp(D) & ","
                Obj = DT.Compute("sum(trans_qty)", "TXN_MONTH = '" & Now.Year & i.ToString.PadLeft(2, "0") & "' and trans_status='SUCCESS' and trans_type='COLLECT'")
                If Not IsDBNull(Obj) Then
                    Script &= CInt(Obj) & "]"
                Else
                    Script &= "0]"
                End If
                If i <> M Then
                    Script &= "," & vbLf
                Else
                    Script &= vbLf
                End If
            Next

            Script &= " ]," & vbLf
            Script &= " bars: {" & vbLf
            Script &= "    show: true," & vbLf
            Script &= "    barWidth: 7 * 24 * 60 * 60 * 1000," & vbLf
            Script &= "    fill: true," & vbLf
            Script &= "    lineWidth: 0," & vbLf
            Script &= "    order: 2," & vbLf
            Script &= "    fillColor: $.staticApp.success" & vbLf
            Script &= "     }" & vbLf
            'Script &= ",{label:'Topup Existing'}"
            Script &= "}," & vbLf

            '------------------- Lost Transaction --------------------
            Script &= "{" & vbLf
            Script &= " data: [" & vbLf
            For i As Integer = 1 To M
                Dim D As New DateTime(Now.Year, i, 1)
                Script &= " [" & GL.GetJavascriptTimestamp(D) & ","
                Obj = DT.Compute("sum(trans_qty)", "TXN_MONTH = '" & Now.Year & i.ToString.PadLeft(2, "0") & "' and trans_status='LOST' ")
                If Not IsDBNull(Obj) Then
                    Script &= CInt(Obj) & "]"
                Else
                    Script &= "0]"
                End If
                If i <> M Then
                    Script &= "," & vbLf
                Else
                    Script &= vbLf
                End If
            Next
            Script &= " ]," & vbLf
            Script &= " bars: {" & vbLf
            Script &= "    show: true," & vbLf
            Script &= "    barWidth: 7 * 24 * 60 * 60 * 1000," & vbLf
            Script &= "    fill: true," & vbLf
            Script &= "    lineWidth: 0," & vbLf
            Script &= "    order: 3," & vbLf
            Script &= "    fillColor: $.staticApp.danger" & vbLf
            Script &= "     }" & vbLf
            'Script &= ",{label:'Incompleted'}"
            Script &= "}" & vbLf
            Script &= "];" & vbLf
            Script &= " render_Bar(barData);" & vbLf
            Script &= "});" & vbLf
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "BarChart", Script, True)
        End If
        DT.Dispose()
    End Sub

    Private Sub BindRadar(UserName As String, LocationID As Long)
        Dim sql As String = "select x.TXN_MONTH, x.TXN_HOUR, x.trans_type, x.trans_status, x.ms_kiosk_id, sum(x.trans_qty) trans_qty " & vbNewLine
        sql += " from ( " & vbNewLine
        sql += "	select  datename(HOUR,isnull(s.trans_start_time,s.paid_time))  TXN_HOUR, " & vbNewLine
        sql += "	convert(varchar(6), isnull(s.trans_start_time,s.paid_time),112) TXN_MONTH, " & vbNewLine
        sql += "	case when s.trans_status = '1' then 'SUCCESS' else 'LOST' end trans_status, 'DEPOSIT' trans_type, " & vbNewLine
        sql += "	s.ms_kiosk_id, count(s.id) trans_qty " & vbNewLine
        sql += "	from TB_DEPOSIT_TRANSACTION s " & vbNewLine
        sql += "	group by s.ms_kiosk_id, datename(HOUR,isnull(s.trans_start_time,s.paid_time)) , " & vbNewLine
        sql += "	convert(varchar(6), isnull(s.trans_start_time,s.paid_time),112), " & vbNewLine
        sql += "	Case When s.trans_status = '1' then 'SUCCESS' else 'LOST' end " & vbNewLine
        sql += "	union all " & vbNewLine
        sql += "	Select  datename(HOUR,p.trans_start_time)  TXN_HOUR, " & vbNewLine
        sql += "	convert(varchar(6), p.trans_start_time,112) TXN_MONTH, " & vbNewLine
        sql += "	Case When p.trans_status = '1' then 'SUCCESS' else 'LOST' end trans_status,  'COLLECT' trans_type, " & vbNewLine
        sql += "	p.ms_kiosk_id, count(p.id) trans_qty " & vbNewLine
        sql += "	from TB_PICKUP_TRANSACTION p " & vbNewLine
        sql += "	group by p.ms_kiosk_id,  datename(HOUR,p.trans_start_time), " & vbNewLine
        sql += "	convert(varchar(6), p.trans_start_time,112), " & vbNewLine
        sql += "	case when p.trans_status = '1' then 'SUCCESS' else 'LOST' end " & vbNewLine
        sql += ") x " & vbNewLine
        sql += " inner join MS_KIOSK k on k.id=x.ms_kiosk_id" & vbNewLine
        sql += " where TXN_MONTH=convert(varchar(6),getdate(),112) " & vbNewLine
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " and k.ms_location_id = @_LOCATION_ID " & vbNewLine
        sql += " And k.ms_location_id In (Select ul.ms_location_id " & vbNewLine
        sql += " 			from MS_USER_LOCATION ul  " & vbNewLine
        sql += " 			inner join MS_LOCATION l On l.id=ul.ms_location_id " & vbNewLine
        sql += " 			where l.active_status='Y' and ul.username=@_USERNAME) " & vbNewLine
        sql += "group by x.TXN_MONTH, x.TXN_HOUR, x.trans_type, x.trans_status,  x.ms_kiosk_id" & vbNewLine

        Dim p(2) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_LOCATION_ID", LocationID)
        p(1) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_USERNAME", UserName)

        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        If DT.Rows.Count > 0 Then
            Dim tmp As DataTable = DT.DefaultView.ToTable
            Dim Obj As Object
            Dim Script As String = "$( document ).ready(function() {" & vbLf
            Script &= "var radarChartData = {" & vbLf
            Script &= " labels: ["
            For i As Integer = 0 To 23
                Script &= "'" & i.ToString.PadLeft(2, "0") & "'"
                If i <> 23 Then
                    Script &= ","
                End If
            Next
            Script &= "]," & vbLf

            '---------------DEPOSIT  SUCCESS------------------------
            Script &= " datasets: [{" & vbLf
            Script &= "            fillColor: '#009900'," & vbLf
            Script &= "            strokeColor: '#009900'," & vbLf
            Script &= "            pointColor: '#009900'," & vbLf
            'Script &= "            pointStrokeColor: '#fff'," & vbLf
            Script &= "            data: ["
            For i As Integer = 0 To 23
                Obj = tmp.Compute("sum(trans_qty)", "trans_type='DEPOSIT' and trans_status='SUCCESS' and TXN_HOUR='" & i & "'")
                If Not IsDBNull(Obj) Then
                    Script &= CInt(Obj)
                Else
                    Script &= "0"
                End If
                If i <> 23 Then
                    Script &= ","
                End If
            Next
            Script &= "]" & vbLf

            '---------------COLLECT  SUCCESS------------------------
            Script &= "     }," & vbLf
            Script &= "     {" & vbLf
            Script &= "            fillColor: '#6FC080'," & vbLf
            Script &= "            strokeColor: '#6FC080'," & vbLf
            Script &= "            pointColor: '#6FC080'," & vbLf
            'Script &= "            pointStrokeColor: '#fff'," & vbLf
            Script &= "            data: ["
            For i As Integer = 0 To 23
                Obj = tmp.Compute("sum(trans_qty)", "trans_type='COLLECT' and trans_status='SUCCESS' and TXN_HOUR='" & i & "'")
                If Not IsDBNull(Obj) Then
                    Script &= CInt(Obj)
                Else
                    Script &= "0"
                End If
                If i <> 23 Then
                    Script &= ","
                End If
            Next
            Script &= "]" & vbLf

            '---------------LOST Transaction------------------------
            Script &= "     }," & vbLf
            Script &= "     {" & vbLf
            Script &= "            fillColor: '#DD6777'," & vbLf
            Script &= "            strokeColor: '#DD6777'," & vbLf
            Script &= "            pointColor: '#DD6777'," & vbLf
            'Script &= "            pointStrokeColor: '#fff'," & vbLf
            Script &= "            data: ["
            For i As Integer = 0 To 23
                Obj = tmp.Compute("sum(trans_qty)", "trans_status='LOST' and TXN_HOUR='" & i & "'")
                If Not IsDBNull(Obj) Then
                    Script &= CInt(Obj)
                Else
                    Script &= "0"
                End If
                If i <> 23 Then
                    Script &= ","
                End If
            Next
            Script &= "]" & vbLf


            Script &= "}]" & vbLf
            Script &= "};"
            Script &= "render_Radar(radarChartData);" & vbLf
            Script &= "});" & vbLf
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "RadarChart", Script, True)
        End If
        DT.Dispose()

    End Sub

    Private Sub BindNotification(UserName As String, LocationID As Long)

        Dim sql As String = "select top 5 l.location_name, d.device_name_en, ds.status_name,  d.device_order " & vbNewLine
        sql += " from MS_KIOSK_DEVICE kd " & vbNewLine
        sql += " inner join MS_DEVICE d on d.id=kd.ms_device_id " & vbNewLine
        sql += " inner join ms_device_status ds On ds.id=kd.ms_device_status_id " & vbNewLine
        sql += " inner join MS_KIOSK k on k.id=kd.ms_kiosk_id " & vbNewLine
        sql += " inner join MS_LOCATION l On l.id=k.ms_location_id " & vbNewLine
        sql += " where d.active_status='Y' and ds.is_problem='Y' " & vbNewLine
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " and l.id = @_LOCATION_ID " & vbNewLine
        sql += " And l.id In (Select ul.ms_location_id " & vbNewLine
        sql += " 			from MS_USER_LOCATION ul  " & vbNewLine
        sql += " 			inner join MS_LOCATION l On l.id=ul.ms_location_id " & vbNewLine
        sql += " 			where l.active_status='Y' and ul.username=@_USERNAME) " & vbNewLine
        sql += " group by l.location_name, d.device_name_en, ds.status_name, d.device_order " & vbNewLine
        sql += " order by d.device_order" & vbNewLine

        Try
            Dim p(2) As SqlParameter
            p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_LOCATION_ID", LocationID)
            p(1) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_USERNAME", UserName)

            Dim dt As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                Dim builder As New StringBuilder
                builder.Append("<ul Class='notifications'>")
                builder.Append("<li>")
                builder.Append("<ul Class='notifications-list'>")

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim d_name As String = dt.Rows(i)("device_name_en").ToString
                    Dim problem As String = dt.Rows(i)("status_name").ToString
                    Dim location_name As String = dt.Rows(i)("location_name").ToString

                    builder.Append("<li>")
                    builder.Append("<a href = 'javascript:;' >")
                    builder.Append("<div class='notification-icon'>")
                    builder.Append("<div class='circle-icon bg-danger text-white'>")
                    builder.Append("<i class='icon-ban'></i>")
                    builder.Append("</div>")
                    builder.Append("</div>")
                    builder.Append("<span Class='notification-message'>" & d_name & "</span>")
                    builder.Append("<span Class='notification-message'>" & problem & "</span>")
                    builder.Append("<span Class='notification-message'>" & location_name & "</span>")
                    builder.Append("</a>")
                    builder.Append("</li>")
                Next

                builder.Append("</ul>")
                builder.Append("</li>")
                builder.Append("</ul>")

                lblNotificationList.Text = builder.ToString()
            End If
            dt.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click

    End Sub
End Class
