Imports System.Data
Imports System.Data.SqlClient
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE

Public Class Report_Transaction_Log
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL

    Const FunctionalID As Int16 = 2
    Const FunctionalZoneID As Int16 = 2

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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


        If Not IsPostBack Then
            If Session("UserName") IsNot Nothing Then
                Dim UserName As String = Session("UserName")

                BindSearchForm(UserName)
                BindList()
            End If
        Else
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Init", "initFormPlugin();", True)
        End If

    End Sub

    Private Sub BindSearchForm(UserName As String)
        BL.Bind_DDL_Location(ddlLocation, UserName)
        ddlLocation.Items(0).Text = "All Locations"
        ddlLocation_SelectedIndexChanged(ddlLocation, Nothing)

        BL.Bind_DDL_CabinetModel(ddlCabinetModel)
        ddlCabinetModel.Items(0).Text = "All Sizes"

        Dim D As DateTime = DateTime.Now
        txtStartDate.Text = D.ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
        txtEndDate.Text = D.ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))

        txtTimeStart.Text = "12:00 AM"
        txtTimeEnd.Text = "11:59 PM"

    End Sub

    Private Sub ddlLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLocation.SelectedIndexChanged
        If Session("UserName") IsNot Nothing Then
            pnlKiosk_On.Visible = ddlLocation.SelectedIndex > 0
            pnlKiosk_Off.Visible = Not pnlKiosk_On.Visible
            If pnlKiosk_On.Visible Then Bind_Kiosk(Session("UserName"))
        End If
    End Sub

    Private Sub Bind_Kiosk(UserName As String)
        BL.Bind_DDL_Kiosk(UserName, ddlKiosk, ddlLocation.SelectedValue)

        ddlKiosk.Items(0).Text = "All machine(s)"
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        BindList()
    End Sub

    Private Sub BindList()
        lblHeader.Text = "Customer Transaction Log "

        Dim parm(9) As SqlParameter
        Dim wh As String = " deposit_status <> '0' "

        If ddlKiosk.SelectedValue <> "" Then
            wh += " and ms_kiosk_id=@_KIOSK_ID"
            parm(1) = ServerDB.SetBigInt("@_KIOSK_ID", ddlKiosk.SelectedValue)
            lblHeader.Text &= "สำหรับตู้ " & ddlKiosk.Items(ddlKiosk.SelectedIndex).Text & " "
        End If

        If ddlLocation.SelectedValue.Trim <> "" Then
            wh += " and ms_location_id=@_LOCATION_ID " + Environment.NewLine
            parm(0) = ServerDB.SetBigInt("@_LOCATION_ID", ddlLocation.SelectedValue)

            lblHeader.Text &= "ที่ " & ddlLocation.Items(ddlLocation.SelectedIndex).Text & " "
        Else
            If Session("List_User_LocationID") IsNot Nothing Then
                wh += " and ms_location_id in (" & Session("List_User_LocationID") & ")"
                lblHeader.Text &= "ทุก Location "
            Else
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
            End If
        End If

        If txtDepositTransactionNo.Text.Trim <> "" Then
            wh += " and deposit_transaction_no like '%' + @_DEPOSIT_TRANS_NO + '%'"
            parm(2) = ServerDB.SetText("@_DEPOSIT_TRANS_NO", txtDepositTransactionNo.Text.Trim)
            lblHeader.Text &= " Deposit Transaction " & txtDepositTransactionNo.Text.Trim & " "
        End If
        If txtCollectTransactionNo.Text.Trim <> "" Then
            wh += " and collect_transaction_no like '%' + @_COLLECT_TRANS_NO + '%'"
            parm(3) = ServerDB.SetText("@_COLLECT_TRANS_NO", txtCollectTransactionNo.Text.Trim)
            lblHeader.Text &= " Collect Transaction " & txtCollectTransactionNo.Text.Trim & " "
        End If
        If ddlDepositStatus.SelectedValue <> "" Then
            wh += " and deposit_status=@_DEPOSIT_STATUS"
            parm(4) = ServerDB.SetText("@_DEPOSIT_STATUS", ddlDepositStatus.SelectedValue)
            lblHeader.Text &= " Deposit Status " & ddlDepositStatus.Items(ddlDepositStatus.SelectedIndex).Text & " "
        End If
        If ddlCollectStatus.SelectedValue <> "" Then
            wh += " and collect_status=@_COLLECT_STATUS"
            parm(5) = ServerDB.SetText("@_COLLECT_STATUS", ddlCollectStatus.SelectedValue)
            lblHeader.Text &= " Collect Status " & ddlCollectStatus.Items(ddlCollectStatus.SelectedIndex).Text & " "
        End If
        'If txtCustomer.Text.Trim <> "" Then
        '    wh += " and (first_name like '%' + @_CUSTOMER + '%' "
        '    wh += " or last_name like '%' + @_CUSTOMER + '%' "
        '    wh += " or nation_code like '%' + @_CUSTOMER + '%' "
        '    wh += " or idcard_no like '%' + @_CUSTOMER + '%' "
        '    wh += " or passport_no like '%' + @_CUSTOMER + '%' )"
        '    parm(6) = ServerDB.SetText("@_CUSTOMER", txtCustomer.Text.Trim)
        '    lblHeader.Text &= " ลูกค้า " & txtCustomer.Text.Trim & " "

        'End If
        If ddlCabinetModel.SelectedValue <> "" Then
            wh += " and ms_cabinet_model_id=@_CABINET_MODEL_ID"
            parm(6) = ServerDB.SetBigInt("@_CABINET_MODEL_ID", ddlCabinetModel.SelectedValue)
            lblHeader.Text &= " ขนาด " & ddlCabinetModel.Items(ddlCabinetModel.SelectedIndex).Text & " "
        End If

        If txtStartDate.Text.Trim <> "" Then
            Dim vDateStart As DateTime = Converter.ConvertTextToDate(txtStartDate.Text)
            Dim TimeStart As String = vDateStart.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
            lblHeader.Text &= "ตั้งแต่ " & vDateStart.ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            If txtTimeStart.Text.Trim <> "" Then
                TimeStart += " " & txtTimeStart.Text
                lblHeader.Text &= " เวลา " & txtTimeStart.Text
            End If

            wh += " and trans_start_time  >= @_TIME_START"
            parm(7) = ServerDB.SetText("@_TIME_START", TimeStart)
        End If

        If txtEndDate.Text.Trim <> "" Then
            Dim DateEnd As DateTime = Converter.ConvertTextToDate(txtEndDate.Text)
            Dim TimeEnd As String = DateEnd.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
            lblHeader.Text &= " ถึง " & DateEnd.ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            If txtTimeEnd.Text.Trim <> "" Then
                TimeEnd += " " & txtTimeEnd.Text.Trim
                lblHeader.Text &= " เวลา " & txtTimeEnd.Text.Trim
            End If

            wh += " and  trans_start_time <= @_TIME_END"
            parm(8) = ServerDB.SetText("@_TIME_END", TimeEnd)
        End If

        Dim sql As String = " select * from v_transaction_log"
        sql += " where " & wh
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),valid_start_date,112) and convert(varchar(8),valid_expire_date,112) " & vbNewLine

        Dim dt As DataTable = ServerDB.ExecuteTable(sql, parm)
        Session("Report_Transaction_Log") = dt

        rptList.DataSource = dt
        rptList.DataBind()

        If dt.Rows.Count = 0 Then
            lblHeader.Text &= "ไม่พบข้อมูล "
        Else
            lblHeader.Text &= " พบ " & dt.Rows.Count & " Record(s)"
        End If
    End Sub

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        'Dim tr As HtmlTableRow = e.Item.FindControl("tr")
        Dim lblDepositTransactionNo As Label = e.Item.FindControl("lblDepositTransactionNo")
        Dim lblStartTime As Label = e.Item.FindControl("lblStartTime")
        Dim lblDepositStatus As Label = e.Item.FindControl("lblDepositStatus")
        Dim lblLocation As Label = e.Item.FindControl("lblLocation")
        Dim lblKiosk As Label = e.Item.FindControl("lblKiosk")
        Dim lblLockerName As Label = e.Item.FindControl("lblLockerName")
        Dim lblDepositAmt As Label = e.Item.FindControl("lblDepositAmt")
        'Dim lblCustomerName As Label = e.Item.FindControl("lblCustomerName")
        'Dim lblBirthDate As Label = e.Item.FindControl("lblBirthDate")
        'Dim lblAge As Label = e.Item.FindControl("lblAge")
        'Dim lblCardType As Label = e.Item.FindControl("lblCardType")
        'Dim lblNationality As Label = e.Item.FindControl("lblNationality")
        Dim lblDepositPaidTime As Label = e.Item.FindControl("lblDepositPaidTime")
        Dim lblLastActivity As Label = e.Item.FindControl("lblLastActivity")
        Dim lblDepositPaymentCoin5 As Label = e.Item.FindControl("lblDepositPaymentCoin5")
        Dim lblDepositPaymentCoin10 As Label = e.Item.FindControl("lblDepositPaymentCoin10")
        Dim lblDepositPaymentBanknote20 As Label = e.Item.FindControl("lblDepositPaymentBanknote20")
        Dim lblDepositPaymentBanknote50 As Label = e.Item.FindControl("lblDepositPaymentBanknote50")
        Dim lblDepositPaymentBanknote100 As Label = e.Item.FindControl("lblDepositPaymentBanknote100")
        Dim lblDepositPaymentBanknote500 As Label = e.Item.FindControl("lblDepositPaymentBanknote500")
        Dim lblDepositPaymentBanknote1000 As Label = e.Item.FindControl("lblDepositPaymentBanknote1000")
        Dim lblDepositChangeCoin5 As Label = e.Item.FindControl("lblDepositChangeCoin5")
        Dim lblDepositChangeBanknote20 As Label = e.Item.FindControl("lblDepositChangeBanknote20")
        Dim lblDepositChangeBanknote100 As Label = e.Item.FindControl("lblDepositChangeBanknote100")

        Dim lblCollectTransactionNo As Label = e.Item.FindControl("lblCollectTransactionNo")
        Dim lblCollectTime As Label = e.Item.FindControl("lblCollectTime")
        Dim lblCollectPaidTime As Label = e.Item.FindControl("lblCollectPaidTime")
        Dim lblCollectStatus As Label = e.Item.FindControl("lblCollectStatus")

        Dim lblCollectBy As Label = e.Item.FindControl("lblCollectBy")
        Dim lblServiceTime As Label = e.Item.FindControl("lblServiceTime")
        Dim lblServiceAmt As Label = e.Item.FindControl("lblServiceAmt")
        Dim lblCollectPaymentCoin5 As Label = e.Item.FindControl("lblCollectPaymentCoin5")
        Dim lblCollectPaymentCoin10 As Label = e.Item.FindControl("lblCollectPaymentCoin10")
        Dim lblCollectPaymentBanknote20 As Label = e.Item.FindControl("lblCollectPaymentBanknote20")
        Dim lblCollectPaymentBanknote50 As Label = e.Item.FindControl("lblCollectPaymentBanknote50")
        Dim lblCollectPaymentBanknote100 As Label = e.Item.FindControl("lblCollectPaymentBanknote100")
        Dim lblCollectPaymentBanknote500 As Label = e.Item.FindControl("lblCollectPaymentBanknote500")
        Dim lblCollectPaymentBanknote1000 As Label = e.Item.FindControl("lblCollectPaymentBanknote1000")
        Dim lblCollectChangeCoin5 As Label = e.Item.FindControl("lblCollectChangeCoin5")
        Dim lblCollectChangeBanknote20 As Label = e.Item.FindControl("lblCollectChangeBanknote20")
        Dim lblCollectChangeBanknote100 As Label = e.Item.FindControl("lblCollectChangeBanknote100")

        Dim en_US As New Globalization.CultureInfo("en-US")
        With e.Item
            lblDepositTransactionNo.Text = .DataItem("deposit_transaction_no").ToString
            lblStartTime.Text = Convert.ToDateTime(.DataItem("trans_start_time")).ToString("MMM dd yyyy HH:mm:ss", en_US)
            lblDepositStatus.Text = .DataItem("deposit_status_name").ToString
            Select Case e.Item.DataItem("deposit_status_name").ToString.ToUpper
                Case "Cancel".ToUpper, "Timeout".ToUpper, "Cancel by Admin".ToUpper
                    lblDepositStatus.ForeColor = Drawing.Color.Black
                Case "Problem".ToUpper
                    lblDepositStatus.ForeColor = Drawing.Color.Red
                Case "Inprogress".ToUpper
                    lblDepositStatus.ForeColor = Drawing.Color.Gray
                Case "Success".ToUpper
                    lblDepositStatus.ForeColor = Drawing.Color.Green
            End Select

            lblLocation.Text = .DataItem("location_name").ToString
            lblKiosk.Text = .DataItem("com_name").ToString
            If Convert.IsDBNull(.DataItem("locker_name")) = False Then lblLockerName.Text = .DataItem("locker_name").ToString
            If .DataItem("deposit_status").ToString = "1" Or .DataItem("deposit_status").ToString = "5" Then lblDepositAmt.Text = .DataItem("deposit_amt").ToString  'Success แล้วถึงจะแสดง
            'lblCustomerName.Text = .DataItem("first_name").ToString & " " & .DataItem("last_name").ToString
            'If Convert.IsDBNull(.DataItem("birth_date")) = False Then
            '    lblBirthDate.Text = Convert.ToDateTime(.DataItem("birth_date")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            '    lblAge.Text = DateTime.Now.Year - Convert.ToDateTime(.DataItem("birth_date")).Year
            'End If

            'If Convert.IsDBNull(.DataItem("card_type")) = False Then lblCardType.Text = .DataItem("card_type").ToString
            'If Convert.IsDBNull(.DataItem("nation_code")) = False Then lblNationality.Text = .DataItem("nation_code").ToString
            If Convert.IsDBNull(.DataItem("deposit_paid_time")) = False Then lblDepositPaidTime.Text = Convert.ToDateTime(.DataItem("deposit_paid_time")).ToString("MMM dd yyyy HH:mm:ss", en_US)
            If Convert.IsDBNull(.DataItem("step_name_th")) = False Then lblLastActivity.Text = .DataItem("step_name_th")
            If .DataItem("deposit_payment_coin5") > 0 Then lblDepositPaymentCoin5.Text = .DataItem("deposit_payment_coin5")
            If .DataItem("deposit_payment_coin10") > 0 Then lblDepositPaymentCoin10.Text = .DataItem("deposit_payment_coin10")
            If .DataItem("deposit_payment_banknote20") > 0 Then lblDepositPaymentBanknote20.Text = .DataItem("deposit_payment_banknote20")
            If .DataItem("deposit_payment_banknote50") > 0 Then lblDepositPaymentBanknote50.Text = .DataItem("deposit_payment_banknote50")
            If .DataItem("deposit_payment_banknote100") > 0 Then lblDepositPaymentBanknote100.Text = .DataItem("deposit_payment_banknote100")
            If .DataItem("deposit_payment_banknote500") > 0 Then lblDepositPaymentBanknote500.Text = .DataItem("deposit_payment_banknote500")
            If .DataItem("deposit_payment_banknote1000") > 0 Then lblDepositPaymentBanknote1000.Text = .DataItem("deposit_payment_banknote1000")
            If .DataItem("deposit_change_coin5") > 0 Then lblDepositChangeCoin5.Text = .DataItem("deposit_change_coin5")
            If .DataItem("deposit_change_banknote20") > 0 Then lblDepositChangeBanknote20.Text = .DataItem("deposit_change_banknote20")
            If .DataItem("deposit_change_banknote100") > 0 Then lblDepositChangeBanknote100.Text = .DataItem("deposit_change_banknote100")

            If Convert.IsDBNull(.DataItem("collect_transaction_no")) = False Then lblCollectTransactionNo.Text = .DataItem("collect_transaction_no")
            If Convert.IsDBNull(.DataItem("collect_time")) = False Then lblCollectTime.Text = Convert.ToDateTime(.DataItem("collect_time")).ToString("MMM dd yyyy HH:mm:ss", en_US)
            If Convert.IsDBNull(.DataItem("collect_paid_time")) = False Then lblCollectPaidTime.Text = Convert.ToDateTime(.DataItem("collect_paid_time")).ToString("MMM dd yyyy HH:mm:ss", en_US)
            If Convert.IsDBNull(.DataItem("collect_status_name")) = False Then
                lblCollectStatus.Text = .DataItem("collect_status_name")

                Select Case .DataItem("collect_status_name").ToString.ToUpper
                    Case "Cancel".ToUpper, "Timeout".ToUpper
                        lblCollectStatus.ForeColor = Drawing.Color.Black
                    Case "Problem".ToUpper
                        lblCollectStatus.ForeColor = Drawing.Color.Red
                    Case "Inprogress".ToUpper
                        lblCollectStatus.ForeColor = Drawing.Color.Gray
                    Case "Success".ToUpper
                        lblCollectStatus.ForeColor = Drawing.Color.Green
                End Select
            End If

            If Convert.IsDBNull(.DataItem("lost_qr_code")) = False Then
                If .DataItem("lost_qr_code") <> "Z" Then
                    If .DataItem("lost_qr_code") = "Y" Then
                        lblCollectBy.Text = "PIN Code"
                    Else
                        lblCollectBy.Text = "QR Code"
                    End If
                End If
            End If

            If Convert.IsDBNull(.DataItem("deposit_status")) = False And Convert.IsDBNull(.DataItem("collect_status")) = False Then
                If .DataItem("deposit_status") = "1" And .DataItem("collect_status") = "1" Then
                    lblServiceTime.Text = .DataItem("service_time_str").ToString
                    If Convert.IsDBNull(.DataItem("service_amt")) = False Then lblServiceAmt.Text = Convert.ToDouble(.DataItem("service_amt")).ToString("#,##0")
                End If
            End If

            If .DataItem("collect_payment_coin5") > 0 Then lblCollectPaymentCoin5.Text = .DataItem("collect_payment_coin5")
            If .DataItem("collect_payment_coin10") > 0 Then lblCollectPaymentCoin10.Text = .DataItem("collect_payment_coin10")
            If .DataItem("collect_payment_banknote20") > 0 Then lblCollectPaymentBanknote20.Text = .DataItem("collect_payment_banknote20")
            If .DataItem("collect_payment_banknote50") > 0 Then lblCollectPaymentBanknote50.Text = .DataItem("collect_payment_banknote50")
            If .DataItem("collect_payment_banknote100") > 0 Then lblCollectPaymentBanknote100.Text = .DataItem("collect_payment_banknote100")
            If .DataItem("collect_payment_banknote500") > 0 Then lblCollectPaymentBanknote500.Text = .DataItem("collect_payment_banknote500")
            If .DataItem("collect_payment_banknote1000") > 0 Then lblCollectPaymentBanknote1000.Text = .DataItem("collect_payment_banknote1000")
            If .DataItem("collect_change_coin5") > 0 Then lblCollectChangeCoin5.Text = .DataItem("collect_change_coin5")
            If .DataItem("collect_change_banknote20") > 0 Then lblCollectChangeBanknote20.Text = .DataItem("collect_change_banknote20")
            If .DataItem("collect_change_banknote100") > 0 Then lblCollectChangeBanknote100.Text = .DataItem("collect_change_banknote100")

            For i As Integer = 1 To 36
                Dim td As HtmlTableCell = .FindControl("td" & i)
                td.Attributes("onclick") = "openPrintWindow('Report_Transaction_Info.aspx?T=" & e.Item.DataItem("deposit_transaction_no").ToString & "',1000,800);"
            Next
        End With
    End Sub

    Private Sub lnkExcel_Click(sender As Object, e As EventArgs) Handles lnkExcel.Click
        Try
            Dim DT As DataTable = CType(Session("Report_Transaction_Log"), DataTable)

            Dim TmpDT As New DataTable
            TmpDT = Engine.ReportENG.BuiltReportTransactionReportExcelDataTable(TmpDT, DT)

            BL.ExportToExcel(Response, TmpDT, "Report_Transaction_Log.xlsx", 0)
        Catch ex As Exception

        End Try
    End Sub
End Class
