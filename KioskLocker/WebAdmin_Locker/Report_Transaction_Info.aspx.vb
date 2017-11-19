Imports System.Data
Imports System.Data.SqlClient
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE

Public Class Report_Transaction_Info
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL

    Private ReadOnly Property TXN_NO As String
        Get
            Try
                Return Request.QueryString("T")
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If TXN_NO = "" Then
            Response.Redirect("Report_Transaction_Log.aspx")
            Exit Sub
        End If
        BindLog()
    End Sub



    Private Sub BindLog()
        Dim sql As String = "select deposit_status_name, deposit_status, deposit_transaction_no, locker_name,location_name,com_name kiosk_name, " & Environment.NewLine
        sql += " card_type, nation_code, trans_start_time, deposit_paid_time, " & Environment.NewLine
        sql += " collect_transaction_no,collect_time, collect_paid_time,lost_qr_code, service_amt, service_time_str, " & Environment.NewLine
        sql += " first_name + ' ' + last_name customer_name, birth_date, cust_image deposit_cust_image, collect_cust_image " & Environment.NewLine
        sql += " from v_transaction_log" & Environment.NewLine
        sql += " where deposit_transaction_no=@_DEPOSIT_TRANS_NO" & Environment.NewLine
        sql += " order by isnull(collect_time,trans_start_time) desc" & Environment.NewLine

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_DEPOSIT_TRANS_NO", TXN_NO)
        Dim Header As DataTable = ServerDB.ExecuteTable(sql, p)
        If Header.Rows.Count = 0 Then
            Response.Write("Information is not found")
            Response.End()
            Exit Sub
        End If

        Dim hDr As DataRow = Header.Rows(0)
        'HEAD Deposit Transaction
        If Convert.IsDBNull(hDr("deposit_transaction_no")) = False Then lblTransactionNo.Text = hDr("deposit_transaction_no").ToString
        If Convert.IsDBNull(hDr("locker_name")) = False Then lblLockerName.Text = hDr("locker_name").ToString
        lblStatus.Text = hDr("deposit_status_name").ToString
        Select Case hDr("deposit_status").ToString
            Case "2", "4"
                lblStatus.ForeColor = Drawing.Color.Orange
            Case "1"
                lblStatus.ForeColor = Drawing.Color.Green
            Case "3"
                lblStatus.ForeColor = Drawing.Color.Red
        End Select

        lblLocation.Text = hDr("location_name").ToString
        lblKioskName.Text = hDr("kiosk_name").ToString
        'lblCustomerName.Text = hDr("customer_name")  'ชื่อตามสกุล ไม่เป็นค่า Null แน่ๆ
        'If Convert.IsDBNull(hDr("birth_date")) = False Then
        '    Dim vBirthDate As String = Convert.ToDateTime(hDr("birth_date")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
        '    Dim vAge As String = DateTime.Now.Year - Convert.ToDateTime(hDr("birth_date")).Year
        '    lblBirthDate.Text = vBirthDate & " (" & vAge & ")"
        'End If
        'If Convert.IsDBNull(hDr("card_type")) = False Then lblCardType.Text = hDr("card_type").ToString
        'If Convert.IsDBNull(hDr("nation_code")) = False Then lblNationCode.Text = hDr("nation_code").ToString
        If Convert.IsDBNull(hDr("deposit_cust_image")) = False Then
            imgCusImage.ImageUrl = "data:image/jpg;base64," & Convert.ToBase64String(hDr("deposit_cust_image"))
        Else
            imgCusImage.ImageUrl = "images/Person.png"
        End If

        lblDepositStartTime.Text = Convert.ToDateTime(hDr("trans_start_time")).ToString("MMM dd yyyy HH:mm:ss", New Globalization.CultureInfo("en-US"))
        If Convert.IsDBNull(hDr("deposit_paid_time")) = False Then lblDepositPaidTime.Text = Convert.ToDateTime(hDr("deposit_paid_time")).ToString("MMM dd yyyy HH:mm:ss", New Globalization.CultureInfo("en-US"))

        'HEAD Collect Transaction
        If Convert.IsDBNull(hDr("collect_transaction_no")) = False Then lblCollectTransNo.Text = hDr("collect_transaction_no")
        If Convert.IsDBNull(hDr("collect_time")) = False Then lblCollectTime.Text = Convert.ToDateTime(hDr("collect_time")).ToString("MMM dd yyyy HH:mm:ss", New Globalization.CultureInfo("en-US"))
        If Convert.IsDBNull(hDr("collect_paid_time")) = False Then lblCollectPaidTime.Text = Convert.ToDateTime(hDr("collect_paid_time")).ToString("MMM dd yyyy HH:mm:ss", New Globalization.CultureInfo("en-US"))
        If Convert.IsDBNull(hDr("lost_qr_code")) = False Then
            If hDr("lost_qr_code") <> "Z" Then
                lblLostQRCode.Text = IIf(hDr("lost_qr_code") = "Y", "YES", "NO")
            End If
        End If
        If Convert.IsDBNull(hDr("service_amt")) = False Then lblServiceAmt.Text = Convert.ToInt64(hDr("service_amt")).ToString("#,##0.00")
        If Convert.IsDBNull(hDr("service_time_str")) = False Then lblServiceTime.Text = hDr("service_time_str")
        If Convert.IsDBNull(hDr("collect_cust_image")) = False Then
            imgCollectCustImage.ImageUrl = "data:image/jpg;base64," & Convert.ToBase64String(hDr("collect_cust_image"))
        Else
            imgCollectCustImage.ImageUrl = "images/Person.png"
        End If

        'LIST Deposit Activity
        sql = "select distinct trans_date, log_desc , is_problem " & Environment.NewLine
        sql += " From TB_LOG_TRANSACTION_ACTIVITY " & Environment.NewLine
        sql += " where deposit_trans_no=@_DEPOSIT_TRANS_NO"
        sql += " and pickup_trans_no is null " & Environment.NewLine  'เอาเฉพาะ Log ของการฝากมาแสดง
        sql += " order by trans_date desc"

        Dim dp(1) As SqlParameter
        dp(0) = ServerDB.SetText("@_DEPOSIT_TRANS_NO", TXN_NO)

        Dim dDt As DataTable = ServerDB.ExecuteTable(sql, dp)
        rptDepositList.DataSource = dDt
        rptDepositList.DataBind()

        'LIST Collect Activity
        sql = " select distinct transaction_no,trans_start_time "
        sql += " from TB_PICKUP_TRANSACTION "
        sql += " where deposit_trans_no = @_DEPOSIT_TRANS_NO"
        sql += " order by trans_start_time"

        Dim cp(1) As SqlParameter
        cp(0) = ServerDB.SetText("@_DEPOSIT_TRANS_NO", TXN_NO)
        Dim cDt As DataTable = ServerDB.ExecuteTable(sql, cp)
        rptCollectHead.DataSource = cDt
        rptCollectHead.DataBind()
    End Sub

    Private Sub rptCollectHead_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptCollectHead.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        If Convert.IsDBNull(e.Item.DataItem("transaction_no")) = False Then
            Dim Sql As String = "select distinct l.trans_date, l.log_desc , l.is_problem, p.trans_status " & Environment.NewLine
            Sql += " From TB_LOG_TRANSACTION_ACTIVITY l" & Environment.NewLine
            Sql += " inner join TB_PICKUP_TRANSACTION p on l.pickup_trans_no=p.transaction_no "
            Sql += " where l.pickup_trans_no=@_PICKUP_TRANS_NO"
            Sql += " order by l.trans_date desc"

            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetText("@_PICKUP_TRANS_NO", e.Item.DataItem("transaction_no"))

            Dim dt As DataTable = ServerDB.ExecuteTable(Sql, p)
            If dt.Rows.Count > 0 Then
                Dim lblCollectTransNo As Label = e.Item.FindControl("lblCollectTransNo")
                lblCollectTransNo.Text = e.Item.DataItem("transaction_no").ToString.Trim

                Dim rptCollectList As Repeater = e.Item.FindControl("rptCollectList")
                AddHandler rptCollectList.ItemDataBound, AddressOf rptCollectList_ItemDataBound
                rptCollectList.DataSource = dt
                rptCollectList.DataBind()
            End If
            dt.Dispose()
        End If
    End Sub


    Private Sub rptCollectList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblTime As Label = e.Item.FindControl("lblTime")
        Dim lblDetail As Label = e.Item.FindControl("lblDetail")

        lblTime.Text = CType(e.Item.DataItem("trans_date"), DateTime).ToString("MMM dd yyyy HH:mm:ss", New Globalization.CultureInfo("en-US"))
        lblDetail.Text = e.Item.DataItem("log_desc").ToString
        Dim tr As HtmlTableRow = e.Item.FindControl("tr")
        If e.Item.DataItem("is_problem") = "Y" Then
            tr.Attributes("class") = "ErrorLog"
        End If
        If e.Item.DataItem("trans_status") = "1" And e.Item.ItemIndex = 0 Then
            tr.Attributes("class") = "SuccessLog"
        End If
    End Sub

    Private Sub rptDepositList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptDepositList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblTime As Label = e.Item.FindControl("lblTime")
        Dim lblDetail As Label = e.Item.FindControl("lblDetail")

        lblTime.Text = CType(e.Item.DataItem("trans_date"), DateTime).ToString("MMM dd yyyy HH:mm:ss", New Globalization.CultureInfo("en-US"))
        lblDetail.Text = e.Item.DataItem("log_desc").ToString
        Dim tr As HtmlTableRow = e.Item.FindControl("tr")
        If e.Item.DataItem("is_problem") = "Y" Then
            tr.Attributes("class") = "ErrorLog"
        End If
        If lblStatus.Text = "Success" And e.Item.ItemIndex = 0 Then
            tr.Attributes("class") = "SuccessLog"
        End If
    End Sub
End Class