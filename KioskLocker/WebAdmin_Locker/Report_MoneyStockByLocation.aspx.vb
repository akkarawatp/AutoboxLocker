Imports System.Data.SqlClient
Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports OfficeOpenXml

Public Class Report_MoneyStockByLocation
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 28
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

        lblHeader.Text = "รายงานสรุปจำนวนและมูลค่าของเงินที่รับมาและเงินที่ทอนไป แยกตามชนิดเงิน (เหรียญ และ ธนบัตร) "
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

        lblHeader.Text &= " รายวัน"
        If txtStartDate.Text.Trim <> "" Then
            Dim TimeStart As String = Converter.ConvertTextToDate(txtStartDate.Text).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            lblHeader.Text &= " ตั้งแต่ " & Converter.ConvertTextToDate(txtStartDate.Text).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            wh += " and convert(varchar(8),t.trans_start_time,112)  >= @_TIME_START " + Environment.NewLine
            parm(1) = ServerDB.SetText("@_TIME_START", TimeStart)
        End If

        If txtEndDate.Text.Trim <> "" Then
            Dim TimeEnd As String = Converter.ConvertTextToDate(txtEndDate.Text).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            lblHeader.Text &= " ถึง " & Converter.ConvertTextToDate(txtEndDate.Text).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            wh += " And convert(varchar(8),t.trans_start_time,112) <= @_TIME_END " + Environment.NewLine
            parm(2) = ServerDB.SetText("@_TIME_END", TimeEnd)
        End If

        Dim sql As String = Engine.ReportENG.GetQueryReportReceiveByLocation(wh)
        Dim TmpDT As DataTable = ServerDB.ExecuteTable(sql, parm)
        If TmpDT.Rows.Count = 0 Then
            lblHeader.Text &= " ไม่พบข้อมูล "
            'Else
            '    lblHeader.Text &= " พบ " & DT.Rows.Count & " Record(s)"
        End If


        Dim rDt As DataTable = BuiltReceiveDT(TmpDT)
        Session("Report_ReceiveMoneyStock") = rDt
        rptReceiveList.DataSource = rDt
        rptReceiveList.DataBind()


        Dim cDt As DataTable = BuiltChangeDT(TmpDT)
        Session("Report_ChangeMoneyStock") = cDt
        rptChangeList.DataSource = cDt
        rptChangeList.DataBind()

#Region "--------------- Receive Summary ------------"
        Dim SUM_RECEIVE_DEPOSIT_AMT As Object = rDt.Compute("SUM(deposit_amount)", "")
        Dim SUM_RECEIVE_COLLECT_AMT As Object = rDt.Compute("SUM(collect_amount)", "")
        Dim SUM_RECEIVE_TOTAL_AMT As Object = rDt.Compute("SUM(total_amount)", "")

        ''------------- Summary------------
        If Not IsDBNull(SUM_RECEIVE_DEPOSIT_AMT) Then
            lblSumReceiveDepositAmount.Text = Convert.ToInt64(SUM_RECEIVE_DEPOSIT_AMT).ToString("#,##0.00")
        Else
            lblSumReceiveDepositAmount.Text = "-"
        End If
        If Not IsDBNull(SUM_RECEIVE_COLLECT_AMT) Then
            lblSumReceiveCollectAmount.Text = Convert.ToInt64(SUM_RECEIVE_COLLECT_AMT).ToString("#,##0.00")
        Else
            lblSumReceiveCollectAmount.Text = "-"
        End If

        If Not IsDBNull(SUM_RECEIVE_TOTAL_AMT) Then
            lblSumReceiveTotalNumber.Text = Convert.ToInt64(SUM_RECEIVE_TOTAL_AMT).ToString("#,##0.00")
        Else
            lblSumReceiveTotalNumber.Text = "-"
        End If
#End Region

#Region "-------------------Change Summary------------------"
        Dim SUM_CHANGE_DEPOSIT_AMT As Object = cDt.Compute("SUM(deposit_amount)", "")
        Dim SUM_CHANGE_COLLECT_AMT As Object = cDt.Compute("SUM(collect_amount)", "")
        Dim SUM_CHANGE_TOTAL_AMT As Object = cDt.Compute("SUM(total_amount)", "")

        ''------------- Summary------------
        If Not IsDBNull(SUM_CHANGE_DEPOSIT_AMT) Then
            lblSumChangeDepositAmount.Text = Convert.ToInt64(SUM_CHANGE_DEPOSIT_AMT).ToString("#,##0.00")
        Else
            lblSumChangeDepositAmount.Text = "-"
        End If
        If Not IsDBNull(SUM_CHANGE_COLLECT_AMT) Then
            lblSumChangeCollectAmount.Text = Convert.ToInt64(SUM_CHANGE_COLLECT_AMT).ToString("#,##0.00")
        Else
            lblSumChangeCollectAmount.Text = "-"
        End If

        If Not IsDBNull(SUM_CHANGE_TOTAL_AMT) Then
            lblSumChangeTotalAmount.Text = Convert.ToInt64(SUM_CHANGE_TOTAL_AMT).ToString("#,##0.00")
        Else
            lblSumChangeTotalAmount.Text = "-"
        End If
#End Region

        If Convert.IsDBNull(SUM_RECEIVE_TOTAL_AMT) = False And Convert.IsDBNull(SUM_CHANGE_TOTAL_AMT) = False Then
            lblTotalServiceAmount.Text = (Convert.ToInt64(SUM_RECEIVE_TOTAL_AMT) - Convert.ToInt64(SUM_CHANGE_TOTAL_AMT)).ToString("#,##0.00")
        End If
    End Sub

    Private Function BuiltChangeDT(TmpDt As DataTable) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("location_name")
        dt.Columns.Add("trans_date", GetType(Date))
        dt.Columns.Add("change")
        dt.Columns.Add("deposit_number", GetType(Integer))
        dt.Columns.Add("deposit_amount", GetType(Integer))
        dt.Columns.Add("collect_number", GetType(Integer))
        dt.Columns.Add("collect_amount", GetType(Integer))
        dt.Columns.Add("total_number", GetType(Integer))
        dt.Columns.Add("total_amount", GetType(Integer))

        If TmpDt.Rows.Count > 0 Then
            Dim lDt As New DataTable
            lDt = TmpDt.DefaultView.ToTable(True, "location_name", "trans_date", "trans_date_str").Copy
            If lDt.Rows.Count > 0 Then
                For Each lDr As DataRow In lDt.Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("change") = "Change Coin 5"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "num_change_coin5", "amt_change_coin5")
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("change") = "Change Banknote 20"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "num_change_banknote20", "amt_change_banknote20")
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("change") = "Change Banknote 100"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "num_change_banknote100", "amt_change_banknote100")
                    dt.Rows.Add(dr)
                Next
            End If
            lDt.Dispose()
        End If

        Return dt
    End Function

    Private Function BuiltReceiveDT(TmpDt As DataTable) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("location_name")
        dt.Columns.Add("trans_date", GetType(Date))
        dt.Columns.Add("receive")
        dt.Columns.Add("deposit_number", GetType(Integer))
        dt.Columns.Add("deposit_amount", GetType(Integer))
        dt.Columns.Add("collect_number", GetType(Integer))
        dt.Columns.Add("collect_amount", GetType(Integer))
        dt.Columns.Add("total_number", GetType(Integer))
        dt.Columns.Add("total_amount", GetType(Integer))

        If TmpDt.Rows.Count > 0 Then
            Dim lDt As New DataTable
            lDt = TmpDt.DefaultView.ToTable(True, "location_name", "trans_date", "trans_date_str").Copy
            If lDt.Rows.Count > 0 Then
                For Each lDr As DataRow In lDt.Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("receive") = "Receive Coin 5"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "number_coin5", "amount_coin5")
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("receive") = "Receive Coin 10"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "number_coin10", "amount_coin10")
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("receive") = "Receive Banknote 20"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "number_banknote20", "amount_banknote20")
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("receive") = "Receive Banknote 50"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "number_banknote50", "amount_banknote50")
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("receive") = "Receive Banknote 100"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "number_banknote100", "amount_banknote100")
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("receive") = "Receive Banknote 500"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "number_banknote500", "amount_banknote500")
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("receive") = "Receive Banknote 1000"
                    dr = SetReceiveDataRow(TmpDt, lDr, dr, "number_banknote1000", "amount_banknote1000")
                    dt.Rows.Add(dr)
                Next
            End If
            lDt.Dispose()
        End If

        Return dt
    End Function

    Private Function SetReceiveDataRow(TmpDt As DataTable, lDr As DataRow, dr As DataRow, NumberColName As String, AmountColName As String) As DataRow
        dr("location_name") = lDr("location_name")
        dr("trans_date") = Convert.ToDateTime(lDr("trans_date"))

        Dim TotalNumber As Integer = 0
        Dim TotalAmount As Integer = 0
        TmpDt.DefaultView.RowFilter = "location_name='" & lDr("location_name") & "' and trans_date_str='" & lDr("trans_date_str") & "' and rt_type='DEPOSIT'"
        If TmpDt.DefaultView.Count > 0 Then
            If Convert.IsDBNull(TmpDt.DefaultView(0)(NumberColName)) = False Then
                If Convert.ToInt32(TmpDt.DefaultView(0)(NumberColName)) > 0 Then
                    dr("deposit_number") = Convert.ToInt32(TmpDt.DefaultView(0)(NumberColName))
                End If
            End If
            If Convert.IsDBNull(TmpDt.DefaultView(0)(AmountColName)) = False Then
                If Convert.ToInt32(TmpDt.DefaultView(0)(AmountColName)) > 0 Then
                    dr("deposit_amount") = Convert.ToInt32(TmpDt.DefaultView(0)(AmountColName))
                End If
            End If

            TotalNumber += Convert.ToInt32(TmpDt.DefaultView(0)(NumberColName))
            TotalAmount += Convert.ToInt32(TmpDt.DefaultView(0)(AmountColName))
        End If
        TmpDt.DefaultView.RowFilter = ""

        TmpDt.DefaultView.RowFilter = "location_name='" & lDr("location_name") & "' and trans_date_str='" & lDr("trans_date_str") & "' and rt_type='COLLECT'"
        If TmpDt.DefaultView.Count > 0 Then
            If Convert.IsDBNull(TmpDt.DefaultView(0)(NumberColName)) = False Then
                If Convert.ToInt32(TmpDt.DefaultView(0)(NumberColName)) > 0 Then
                    dr("collect_number") = Convert.ToInt32(TmpDt.DefaultView(0)(NumberColName))
                End If
            End If
            If Convert.IsDBNull(TmpDt.DefaultView(0)(AmountColName)) = False Then
                If Convert.ToInt32(TmpDt.DefaultView(0)(AmountColName)) > 0 Then
                    dr("collect_amount") = Convert.ToInt32(TmpDt.DefaultView(0)(AmountColName))
                End If
            End If

            TotalNumber += Convert.ToInt32(TmpDt.DefaultView(0)(NumberColName))
            TotalAmount += Convert.ToInt32(TmpDt.DefaultView(0)(AmountColName))
        End If
        TmpDt.DefaultView.RowFilter = ""

        If TotalNumber > 0 Then dr("total_number") = TotalNumber
        If TotalAmount > 0 Then dr("total_amount") = TotalAmount

        Return dr
    End Function

    Private Sub rptReceiveList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptReceiveList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblLocation As Label = e.Item.FindControl("lblLocation")
        Dim lblDate As Label = e.Item.FindControl("lblDate")

        Dim lblReceive As Label = e.Item.FindControl("lblReceive")
        Dim lblDepositNumber As Label = e.Item.FindControl("lblDepositNumber")
        Dim lblDepositAmount As Label = e.Item.FindControl("lblDepositAmount")
        Dim lblCollectNumber As Label = e.Item.FindControl("lblCollectNumber")
        Dim lblCollectAmount As Label = e.Item.FindControl("lblCollectAmount")
        Dim lblTotalNumber As Label = e.Item.FindControl("lblTotalNumber")
        Dim lblTotalAmount As Label = e.Item.FindControl("lblTotalAmount")

        lblLocation.Text = e.Item.DataItem("location_name").ToString
        lblDate.Text = Convert.ToDateTime(e.Item.DataItem("trans_date")).ToString("dd-MMM-yyyy", New Globalization.CultureInfo("en-US"))
        lblReceive.Text = e.Item.DataItem("receive").ToString

        If Convert.IsDBNull(e.Item.DataItem("deposit_number")) = False Then lblDepositNumber.Text = Convert.ToInt64(e.Item.DataItem("deposit_number")).ToString("#,##0")
        If Convert.IsDBNull(e.Item.DataItem("deposit_amount")) = False Then lblDepositAmount.Text = Convert.ToInt64(e.Item.DataItem("deposit_amount")).ToString("#,##0.00")
        If Convert.IsDBNull(e.Item.DataItem("collect_number")) = False Then lblCollectNumber.Text = Convert.ToInt64(e.Item.DataItem("collect_number")).ToString("#,##0")
        If Convert.IsDBNull(e.Item.DataItem("collect_amount")) = False Then lblCollectAmount.Text = Convert.ToInt64(e.Item.DataItem("collect_amount")).ToString("#,##0.00")
        If Convert.IsDBNull(e.Item.DataItem("total_number")) = False Then lblTotalNumber.Text = Convert.ToInt64(e.Item.DataItem("total_number")).ToString("#,##0")
        If Convert.IsDBNull(e.Item.DataItem("total_amount")) = False Then lblTotalAmount.Text = Convert.ToInt64(e.Item.DataItem("total_amount")).ToString("#,##0.00")

    End Sub

    Private Sub rptChangeList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptChangeList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblLocation As Label = e.Item.FindControl("lblLocation")
        Dim lblDate As Label = e.Item.FindControl("lblDate")

        Dim lblChange As Label = e.Item.FindControl("lblChange")
        Dim lblDepositNumber As Label = e.Item.FindControl("lblDepositNumber")
        Dim lblDepositAmount As Label = e.Item.FindControl("lblDepositAmount")
        Dim lblCollectNumber As Label = e.Item.FindControl("lblCollectNumber")
        Dim lblCollectAmount As Label = e.Item.FindControl("lblCollectAmount")
        Dim lblTotalNumber As Label = e.Item.FindControl("lblTotalNumber")
        Dim lblTotalAmount As Label = e.Item.FindControl("lblTotalAmount")

        lblLocation.Text = e.Item.DataItem("location_name").ToString
        lblDate.Text = Convert.ToDateTime(e.Item.DataItem("trans_date")).ToString("dd-MMM-yyyy", New Globalization.CultureInfo("en-US"))
        lblChange.Text = e.Item.DataItem("change").ToString

        If Convert.IsDBNull(e.Item.DataItem("deposit_number")) = False Then lblDepositNumber.Text = Convert.ToInt64(e.Item.DataItem("deposit_number")).ToString("#,##0")
        If Convert.IsDBNull(e.Item.DataItem("deposit_amount")) = False Then lblDepositAmount.Text = Convert.ToInt64(e.Item.DataItem("deposit_amount")).ToString("#,##0.00")
        If Convert.IsDBNull(e.Item.DataItem("collect_number")) = False Then lblCollectNumber.Text = Convert.ToInt64(e.Item.DataItem("collect_number")).ToString("#,##0")
        If Convert.IsDBNull(e.Item.DataItem("collect_amount")) = False Then lblCollectAmount.Text = Convert.ToInt64(e.Item.DataItem("collect_amount")).ToString("#,##0.00")
        If Convert.IsDBNull(e.Item.DataItem("total_number")) = False Then lblTotalNumber.Text = Convert.ToInt64(e.Item.DataItem("total_number")).ToString("#,##0")
        If Convert.IsDBNull(e.Item.DataItem("total_amount")) = False Then lblTotalAmount.Text = Convert.ToInt64(e.Item.DataItem("total_amount")).ToString("#,##0.00")

    End Sub

    Private Sub lnkExcel_Click(sender As Object, e As EventArgs) Handles lnkExcel.Click
        Try
            Dim rDT As DataTable = CType(Session("Report_ReceiveMoneyStock"), DataTable)
            Dim cDT As DataTable = CType(Session("Report_ChangeMoneyStock"), DataTable)

            Dim TmpDT As New DataTable
            TmpDT.Columns.Add("LOCATION")
            TmpDT.Columns.Add("Date")
            TmpDT.Columns.Add("Receive/Change")
            TmpDT.Columns.Add("DEPOSIT NUMBER")
            TmpDT.Columns.Add("DEPOSIT AMOUNT")
            TmpDT.Columns.Add("COLLECT NUMBER")
            TmpDT.Columns.Add("COLLECT AMOUNT")
            TmpDT.Columns.Add("TOTAL NUMBER")
            TmpDT.Columns.Add("TOTAL AMOUNT")

            Dim DR As DataRow
            For i As Integer = 0 To rDT.Rows.Count - 1
                DR = TmpDT.NewRow
                DR("LOCATION") = rDT.Rows(i)("location_name")
                DR("Date") = Convert.ToDateTime(rDT.Rows(i)("trans_date")).ToString("dd-MMM-yyyy", New Globalization.CultureInfo("en-US"))
                DR("Receive/Change") = rDT.Rows(i)("receive")
                DR("DEPOSIT NUMBER") = rDT.Rows(i)("deposit_number")
                DR("DEPOSIT AMOUNT") = rDT.Rows(i)("deposit_amount")
                DR("COLLECT NUMBER") = rDT.Rows(i)("collect_number")
                DR("COLLECT AMOUNT") = rDT.Rows(i)("collect_amount")
                DR("TOTAL NUMBER") = rDT.Rows(i)("total_number")
                DR("TOTAL AMOUNT") = rDT.Rows(i)("total_amount")
                TmpDT.Rows.Add(DR)
            Next
            DR = TmpDT.NewRow
            DR("LOCATION") = ""
            DR("DATE") = ""
            DR("Receive/Change") = "TOTAL RECEIVE"
            DR("DEPOSIT AMOUNT") = lblSumReceiveDepositAmount.Text
            DR("COLLECT AMOUNT") = lblSumReceiveCollectAmount.Text
            DR("TOTAL AMOUNT") = lblSumReceiveTotalNumber.Text
            TmpDT.Rows.Add(DR)

            DR = TmpDT.NewRow
            TmpDT.Rows.Add(DR)


            For i As Integer = 0 To cDT.Rows.Count - 1
                DR = TmpDT.NewRow
                DR("LOCATION") = cDT.Rows(i)("location_name")
                DR("Date") = Convert.ToDateTime(cDT.Rows(i)("trans_date")).ToString("dd-MMM-yyyy", New Globalization.CultureInfo("en-US"))
                DR("Receive/Change") = cDT.Rows(i)("change")
                DR("DEPOSIT NUMBER") = cDT.Rows(i)("deposit_number")
                DR("DEPOSIT AMOUNT") = cDT.Rows(i)("deposit_amount")
                DR("COLLECT NUMBER") = cDT.Rows(i)("collect_number")
                DR("COLLECT AMOUNT") = cDT.Rows(i)("collect_amount")
                DR("TOTAL NUMBER") = cDT.Rows(i)("total_number")
                DR("TOTAL AMOUNT") = cDT.Rows(i)("total_amount")
                TmpDT.Rows.Add(DR)
            Next
            DR = TmpDT.NewRow
            DR("LOCATION") = ""
            DR("DATE") = ""
            DR("Receive/Change") = "TOTAL CHANGE"
            DR("DEPOSIT AMOUNT") = lblSumChangeDepositAmount.Text
            DR("COLLECT AMOUNT") = lblSumChangeCollectAmount.Text
            DR("TOTAL AMOUNT") = lblSumChangeTotalAmount.Text
            TmpDT.Rows.Add(DR)

            Using ep As New ExcelPackage
                Dim ws As ExcelWorksheet = ep.Workbook.Worksheets.Add("Detail")
                ws.Cells("A1").Value = lblHeader.Text
                ws.Cells("A1").Style.Font.Bold = True
                ws.Cells("A1").Style.Font.Size = 18

                Dim RowStart As Integer = 2
                Dim ColStart As Integer = 1

                'BL.ExportExcelPackage(Response, TmpDT, "Report_MoneyStockByLocation.xlsx", 1, ep, ws, 2, 1)

                'Dim ws As ExcelWorksheet = ep.Workbook.Worksheets.Add("Detail")
                ws.Cells(RowStart, ColStart).LoadFromDataTable(TmpDT, True)


                Using RowHeader As ExcelRange = ws.Cells(RowStart, ColStart, RowStart, ColStart + TmpDT.Columns.Count - 1)
                    RowHeader.Style.Font.Bold = True
                    RowHeader.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                    RowHeader.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray)
                    RowHeader.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
                    RowHeader.Style.Font.Color.SetColor(System.Drawing.Color.Black)
                End Using

                Using RowContent As ExcelRange = ws.Cells(RowStart + 1, ColStart, RowStart + TmpDT.Rows.Count, ColStart + TmpDT.Columns.Count - 1)
                    RowContent.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                    RowContent.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                    RowContent.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                    RowContent.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                End Using


                ws.Cells(RowStart, ColStart, TmpDT.Rows.Count + 1, TmpDT.Columns.Count).AutoFitColumns()

                'Footter Receive
                Using RowFooter As ExcelRange = ws.Cells(RowStart + rDT.Rows.Count + 1, ColStart, RowStart + rDT.Rows.Count + 1, ColStart + rDT.Columns.Count - 1)
                    RowFooter.Style.Font.Bold = True
                    RowFooter.Style.Font.Color.SetColor(System.Drawing.Color.Black)
                End Using

                'Footter
                Using RowFooter As ExcelRange = ws.Cells(RowStart + (TmpDT.Rows.Count), ColStart, RowStart + TmpDT.Rows.Count, ColStart + TmpDT.Columns.Count - 1)
                    RowFooter.Style.Font.Bold = True
                    RowFooter.Style.Font.Color.SetColor(System.Drawing.Color.Black)
                End Using

                ws.Cells(TmpDT.Rows.Count + RowStart + 3, ColStart).Value = "TOTAL SERVICE AMOUNT (Total Receive - Total Change)"
                ws.Cells(TmpDT.Rows.Count + RowStart + 3, ColStart).Style.Font.Bold = True
                ws.Cells(TmpDT.Rows.Count + RowStart + 3, ColStart).Style.Font.Size = 18

                ws.Cells(TmpDT.Rows.Count + RowStart + 3, TmpDT.Columns.Count).Value = lblTotalServiceAmount.Text
                ws.Cells(TmpDT.Rows.Count + RowStart + 3, TmpDT.Columns.Count).Style.Font.Bold = True
                ws.Cells(TmpDT.Rows.Count + RowStart + 3, TmpDT.Columns.Count).Style.Font.Size = 18


                '//Write it back to the client
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("content-disposition", "attachment;  filename=Report_MoneyStockByLocation.xlsx")
                Response.BinaryWrite(ep.GetAsByteArray())
                Response.End()
                Response.Flush()
            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class