Imports System.Data
Imports System.Data.SqlClient

Partial Class frmDashboardOverview
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 1
    Const FunctionalZoneID As Int16 = 1

    Private Sub frmDashboardOverview_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            Dim UserName As String = Session("UserName")
            BindList(UserName)
        End If

    End Sub

    Private Sub BindList(UserName As String)
        Dim sql As String = "select l.id ms_location_id, l.location_name " & vbNewLine
        sql += " from MS_LOCATION l  " & vbNewLine
        sql += " where  l.id In (Select ul.ms_location_id " & vbNewLine
        sql += " 	from MS_USER_LOCATION ul  " & vbNewLine
        sql += " 	inner join MS_LOCATION l On l.id=ul.ms_location_id " & vbNewLine
        sql += " 	where l.active_status='Y' and ul.username=@_USERNAME) " & vbNewLine
        sql += " order by l.location_name "

        Dim p(1) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_USERNAME", UserName)

        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        rptList.DataSource = DT
        rptList.DataBind()
    End Sub

    Private Function GetRemain(MsLocationID As Long) As Integer
        Dim ret As Integer = 0
        Dim sql As String = "select count(s.id) deposit_remain "
        sql += " from TB_SERVICE_TRANSACTION s " & Environment.NewLine
        sql += " left join TB_PICKUP_TRANSACTION p on p.deposit_trans_no=s.trans_no And p.trans_status = 1 " & Environment.NewLine
        sql += " inner join MS_KIOSK k On k.id=s.ms_kiosk_id " & Environment.NewLine
        sql += " where s.trans_status=1 " & Environment.NewLine
        sql += " And (p.trans_status <> 1 Or p.trans_status Is null) " & Environment.NewLine
        sql += " And k.ms_location_id=@_LOCATION_ID " & Environment.NewLine
        sql += " And convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) And convert(varchar(8),k.valid_expire_date,112) " & vbNewLine

        Dim p(1) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_LOCATION_ID", MsLocationID)
        Dim dt As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("deposit_remain")
        End If
        dt.Dispose()
        Return ret
    End Function

    Private Function GetDepositToday(MsLocationID As Long) As Integer
        Dim ret As Integer = 0
        Dim sql As String = "select count(s.id) deposit_success "
        sql += " from TB_SERVICE_TRANSACTION s " & Environment.NewLine
        sql += " inner join MS_KIOSK k On k.id=s.ms_kiosk_id " & Environment.NewLine
        sql += " where s.trans_status=1 " & Environment.NewLine
        sql += " And k.ms_location_id=@_LOCATION_ID " & Environment.NewLine
        sql += " and convert(varchar(8),s.paid_time,112)=convert(varchar(8),getdate(),112)" & Environment.NewLine
        sql += " And convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) And convert(varchar(8),k.valid_expire_date,112) " & vbNewLine

        Dim p(1) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_LOCATION_ID", MsLocationID)
        Dim dt As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("deposit_success")
        End If
        dt.Dispose()
        Return ret
    End Function

    Private Function GetCollectToday(MsLocationID As Long) As Integer()
        'หาจำนวนรายการที่ฝากและรับคืนในวันนี้ และเงินที่ได้รับในวันนี้
        Dim ret() As Integer = {0, 0}
        Dim sql As String = " Select sum(isnull(p.service_amt,0)) daily_sales," & vbNewLine
        sql += " count(p.id) collect_success" & vbNewLine
        sql += " From TB_SERVICE_TRANSACTION s" & vbNewLine
        sql += " inner Join TB_PICKUP_TRANSACTION p On s.trans_no=p.deposit_trans_no And p.trans_status = 1" & vbNewLine
        sql += " inner Join MS_KIOSK k on k.id=s.ms_kiosk_id" & vbNewLine
        sql += " inner Join MS_LOCATION l On l.id=k.ms_location_id " & vbNewLine
        sql += " where s.trans_status = 1  " & vbNewLine
        sql += " And Convert(varchar(8), p.pickup_time, 112) = Convert(varchar(8), getdate(), 112)" & vbNewLine
        sql += " And convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) And convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " And k.ms_location_id = @_LOCATION_ID" & vbNewLine

        Dim p(1) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_LOCATION_ID", MsLocationID)

        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        If DT.Rows.Count > 0 Then
            If Convert.IsDBNull(DT.Rows(0)("daily_sales")) = False Then ret(0) = DT.Rows(0)("daily_sales")
            If Convert.IsDBNull(DT.Rows(0)("collect_success")) = False Then ret(1) = DT.Rows(0)("collect_success")
        End If
        DT.Dispose()
        Return ret
    End Function

    Private Sub rptList_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblLocationName As LinkButton = e.Item.FindControl("lblLocationName")
        Dim lblDailySales As Label = e.Item.FindControl("lblDailySales")
        Dim lblDepositeSuccess As Label = e.Item.FindControl("lblDepositeSuccess")
        Dim lblCollectSuccess As Label = e.Item.FindControl("lblCollectSuccess")
        Dim lblRemain As Label = e.Item.FindControl("lblRemain")
        Dim lblStatus As Label = e.Item.FindControl("lblStatus")

        lblLocationName.Text = e.Item.DataItem("location_name")
        lblLocationName.PostBackUrl = "frmDashboardDetail.aspx?LocationID=" & e.Item.DataItem("ms_location_id")

        'หาจำนวนที่ฝากค้างอยู่จากวันก่อนๆ
        Dim DepositRemain As Integer = GetRemain(e.Item.DataItem("ms_location_id"))
        Dim DepositToday As Integer = GetDepositToday(e.Item.DataItem("ms_location_id"))
        Dim CollectToday() As Integer = GetCollectToday(e.Item.DataItem("ms_location_id"))

        If DepositRemain > 0 Then
            lblRemain.Text = DepositRemain
        Else
            lblRemain.Text = ""
        End If
        If DepositToday > 0 Then
            lblDepositeSuccess.Text = DepositToday
        Else
            lblDepositeSuccess.Text = ""
        End If

        If CollectToday.Length = 2 Then
            If CollectToday(0) > 0 Then
                lblDailySales.Text = FormatNumber(CollectToday(0)) & " ฿"
            End If
            If CollectToday(1) > 0 Then
                lblCollectSuccess.Text = CollectToday(1)
            End If

            Dim msgerror As String = "Error"
            Dim msgCaution As String = "Caution"
        Else
            lblDailySales.Text = ""
            lblCollectSuccess.Text = ""
        End If

        lblStatus.Text = "OK"
        Dim DTStatus As DataTable = GetStatusDT(e.Item.DataItem("ms_location_id"))
        If DTStatus.Rows.Count > 0 Then
            '1. ถ้า แผงควบคุม Solenoid, แผงควบคุม LED, แผงควบคุม Sensor อย่างใดอย่างนึงใช้งานไม่ได้ (ms_device_status<>1)ให้แสดง Error
            Dim tmpdr() As DataRow = DTStatus.Select("(device_id = 15 Or device_id = 16  Or device_id = 17) And ms_device_status_id <> 1")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Error"
                Exit Sub
            End If

            '3. ถ้าเครื่องรับเหรียญ กับเครื่องรับธนบัตรใช้งานไม่ได้พร้อมกัน ให้แสดง Error
            tmpdr = DTStatus.Select("(device_id = 4 And ms_device_status_id <> 1) Or (device_id = 1 And ms_device_status_id <> 1)")
            If tmpdr.Length = 2 Then
                lblStatus.Text = "Error"
                Exit Sub
            End If

            '4. ถ้าเครื่องอ่าน Passport กับเครื่องอ่าน QR Code ใช้งานไม่ได้พร้อมกันให้แสดง Error
            tmpdr = DTStatus.Select("(device_id = 8 Or device_id = 14) And ms_device_status_id <> 1")
            If tmpdr.Length = 2 Then
                lblStatus.Text = "Error"
                Exit Sub
            End If

            '5. ถ้า stock_status ของ เครื่องทอนเหรียญ 5 เป็น Critical ให้แสดง Error
            tmpdr = DTStatus.Select("device_id = 6  And stock_status = 'Critical'")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Caution"
                Exit Sub
            End If

            '2. ถ้าเครื่องทอนเหรียญ 5 บาท ใช้งานไม่ได้ (ms_device_status<>1) ให้แสดง Error
            tmpdr = DTStatus.Select("device_id = 6 and ms_device_status_id <> 1")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Caution"
                Exit Sub
            End If

            '6. ถ้า stock_status ของ เครื่องทอน 20 กับเครื่องทอน 100 อย่างใดอย่างหนึ่งเป็น Critical ให้แสดง Caution
            tmpdr = DTStatus.Select("(device_id = 2 or device_id = 3) and stock_status = 'Critical'")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Caution"
                Exit Sub
            End If

            '7. ถ้าเครื่องรับเหรียญ กับเครื่องรับธนบัตร อย่างใดอย่างหนึ่งใช้งานไม่ได้(ms_device_status<>1) ให้แสดง Caution 
            tmpdr = DTStatus.Select("(device_id = 4 or device_id = 1 ) and ms_device_status_id <> 1")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Caution"
                Exit Sub
            End If

            '8. ถ้าเครื่องอ่าน QR Code/Network/เครื่องอ่านบัตรประชาชนฯ/เครื่องพิมพ์ Slip อย่างใดอย่างหนึ่งใช้งานไม่ได้  ให้แสดง Caution
            tmpdr = DTStatus.Select("(device_id = 14 or device_id = 13 or device_id = 8 or device_id = 7 ) and ms_device_status_id <> 1")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Caution"
                Exit Sub
            End If

            '9. ถ้าเครื่องทอน 20 กับเครื่องทอน 100 อย่างใดอย่างหนึ่งใช้งานไม่ได้ ให้แสดง Caution
            tmpdr = DTStatus.Select("(device_id = 2 or device_id = 3 ) and ms_device_status_id <> 1")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Caution"
                Exit Sub
            End If

            '10. ถ้า stock_status ของ เครื่องรับเหรียญ กับเครื่องรับธนบัตร อย่างใดอย่างหนึง = Critical ให้แสดง Caution
            'ถ้าเท่ากับ Critical พร้อมกันให้แสดง Error
            tmpdr = DTStatus.Select("(device_id = 4 or device_id = 1 ) and stock_status = 'Critical'")
            If tmpdr.Length = 1 Then
                lblStatus.Text = "Caution"
                Exit Sub
            ElseIf tmpdr.Length = 2 Then
                lblStatus.Text = "Error"
                Exit Sub
            End If

            '11. ถ้า Priter ใช้งานไม่ได้  ให้แสดง Caution
            tmpdr = DTStatus.Select("device_id = 7 and ms_device_status_id <> 1 ")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Caution"
                Exit Sub
            End If

            '12. ถ้า stock_status ของกระดาษเป็น Critical ให้แสดง Coution
            tmpdr = DTStatus.Select("device_id = 7 and stock_status = 'Critical' ")
            If tmpdr.Length > 0 Then
                lblStatus.Text = "Caution"
                Exit Sub
            End If
        End If
    End Sub

    Function GetStatusDT(location_id As String) As DataTable
        Dim sql As String = "select d.id device_id, d.device_name_th," & vbNewLine
        sql += " (case dt.movement_direction " & vbNewLine
        sql += " when 1 then" & vbNewLine
        sql += "  Case when kd.current_qty>=kd.critical_qty then 'Critical'" & vbNewLine
        sql += "  when kd.current_qty>=kd.warning_qty then 'Warning'" & vbNewLine
        sql += " Else 'Normal'" & vbNewLine
        sql += "  End" & vbNewLine
        sql += " when -1 then" & vbNewLine
        sql += " Case when kd.current_qty<=kd.critical_qty then 'Critical'" & vbNewLine
        sql += " when kd.current_qty<=kd.warning_qty then 'Warning'" & vbNewLine
        sql += " Else 'Normal'" & vbNewLine
        sql += " End" & vbNewLine
        sql += " End) stock_status," & vbNewLine
        sql += " kd.ms_device_status_id" & vbNewLine
        sql += " From MS_KIOSK_DEVICE kd" & vbNewLine
        sql += " inner Join MS_DEVICE d on d.id=kd.ms_device_id" & vbNewLine
        sql += " inner join MS_DEVICE_TYPE dt on dt.id=d.ms_device_type_id" & vbNewLine
        sql += "  where kd.ms_kiosk_id in (select id from MS_KIOSK where ms_location_id=@_LOCATION_ID)" & vbNewLine
        sql += " And d.active_status='Y'"

        Dim p(1) As SqlParameter
        p(0) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_LOCATION_ID", location_id)

        Dim DT As DataTable = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
        Return DT
    End Function

    Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click

    End Sub
End Class
