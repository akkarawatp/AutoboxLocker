Public Class ReportENG
#Region "Report Query"
    Public Shared Function GetQueryReportSummaryByLocation(wh As String) As String
        Dim sql As String = ""
        sql = "select a.ms_location_id, a.location_name, a.collect_time, " & Environment.NewLine
        sql += " a.sr_success, a.sr_amt, a.mr_success, a.mr_amt, a.lr_success, a.lr_amt, " & Environment.NewLine
        sql += " (a.sr_success+a.mr_success+a.lr_success) total_success, " & Environment.NewLine
        sql += "(a.sr_amt + a.mr_amt + a.lr_amt) total_amt " & Environment.NewLine
        sql += " from ( " & Environment.NewLine
        sql += "	Select t.ms_location_id, t.location_name, convert(date, t.collect_time) collect_time, " & Environment.NewLine
        sql += " 	sum(case when t.ms_cabinet_model_id=1 then 1 else 0 end) sr_success,  " & Environment.NewLine
        sql += "	sum(Case When t.ms_cabinet_model_id=1 Then t.service_amt +isnull(t.fine_amt,0) Else 0 End) sr_amt, " & Environment.NewLine
        sql += "	sum(case when t.ms_cabinet_model_id=2 then 1 else 0 end) mr_success,  " & Environment.NewLine
        sql += "	sum(Case When t.ms_cabinet_model_id=2 Then t.service_amt +isnull(t.fine_amt,0) Else 0 End) mr_amt, " & Environment.NewLine
        sql += "	sum(case when t.ms_cabinet_model_id=3 then 1 else 0 end) lr_success,  " & Environment.NewLine
        sql += "	sum(Case When t.ms_cabinet_model_id=3 Then t.service_amt +isnull(t.fine_amt,0) Else 0 End) lr_amt " & Environment.NewLine
        sql += "	from v_transaction_log t " & Environment.NewLine
        sql += "	where t.deposit_status=1 And t.collect_status=1 " & Environment.NewLine
        sql += wh
        sql += "	group by t.ms_location_id, t.location_name, convert(date, t.collect_time) " & Environment.NewLine
        sql += ") a" & Environment.NewLine
        sql += " order by a.location_name, a.collect_time"

        Return sql
    End Function

    Public Shared Function GetQueryReportReceiveByLocation(wh As String) As String
        Dim sql As String = "select l.location_name, convert(date, t.trans_start_time) trans_date, convert(varchar(8), t.trans_start_time,112) trans_date_str, 'DEPOSIT' rt_type, " & Environment.NewLine
        sql += " sum(t.receive_coin5) number_coin5, sum(t.receive_coin5*5) amount_coin5, " & Environment.NewLine
        sql += " sum(t.receive_coin10) number_coin10, sum(t.receive_coin10*10) amount_coin10, " & Environment.NewLine
        sql += " sum(t.receive_banknote20) number_banknote20, sum(t.receive_banknote20*20) amount_banknote20, " & Environment.NewLine
        sql += " sum(t.receive_banknote50) number_banknote50, sum(t.receive_banknote50*50) amount_banknote50, " & Environment.NewLine
        sql += " sum(t.receive_banknote100) number_banknote100, sum(t.receive_banknote100*100) amount_banknote100, " & Environment.NewLine
        sql += " sum(t.receive_banknote500) number_banknote500, sum(t.receive_banknote500*500) amount_banknote500, " & Environment.NewLine
        sql += " sum(t.receive_banknote1000) number_banknote1000, sum(t.receive_banknote1000*1000) amount_banknote1000, " & Environment.NewLine
        sql += " sum(t.change_coin5) num_change_coin5, sum(t.change_coin5*5) amt_change_coin5,"
        sql += " sum(t.change_banknote20) num_change_banknote20, sum(t.change_banknote20*20) amt_change_banknote20, "
        sql += " sum(t.change_banknote100) num_change_banknote100, sum(t.change_banknote100*100) amt_change_banknote100"
        sql += " from TB_DEPOSIT_TRANSACTION t " & Environment.NewLine
        sql += " inner join MS_KIOSK k On k.id=t.ms_kiosk_id " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=k.ms_location_id " & Environment.NewLine
        sql += " where 1=1 " & wh & Environment.NewLine
        sql += " group by l.location_name, convert(date, t.trans_start_time), convert(varchar(8), t.trans_start_time,112) " & Environment.NewLine

        sql += " UNION ALL " & Environment.NewLine

        sql += " select l.location_name, convert(date, t.trans_start_time) trans_date, convert(varchar(8), t.trans_start_time,112) trans_date_str, 'COLLECT' rt_type, " & Environment.NewLine
        sql += " sum(t.receive_coin5) number_coin5, sum(t.receive_coin5*5) amount_coin5, " & Environment.NewLine
        sql += " sum(t.receive_coin10) number_coin10, sum(t.receive_coin10*10) amount_coin10, " & Environment.NewLine
        sql += " sum(t.receive_banknote20) number_banknote20, sum(t.receive_banknote20*20) amount_banknote20, " & Environment.NewLine
        sql += " sum(t.receive_banknote50) number_banknote50, sum(t.receive_banknote50*50) amount_banknote50, " & Environment.NewLine
        sql += " sum(t.receive_banknote100) number_banknote100, sum(t.receive_banknote100*100) amount_banknote100, " & Environment.NewLine
        sql += " sum(t.receive_banknote500) number_banknote500, sum(t.receive_banknote500*500) amount_banknote500, " & Environment.NewLine
        sql += " sum(t.receive_banknote1000) number_banknote1000, sum(t.receive_banknote1000*1000) amount_banknote1000, " & Environment.NewLine
        sql += " sum(t.change_coin5) num_change_coin5, sum(t.change_coin5*5) amt_change_coin5," & Environment.NewLine
        sql += " sum(t.change_banknote20) num_change_banknote20, sum(t.change_banknote20*20) amt_change_banknote20, " & Environment.NewLine
        sql += " sum(t.change_banknote100) num_change_banknote100, sum(t.change_banknote100*100) amt_change_banknote100 " & Environment.NewLine
        sql += " from TB_PICKUP_TRANSACTION t " & Environment.NewLine
        sql += " inner join MS_KIOSK k On k.id=t.ms_kiosk_id " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=k.ms_location_id " & Environment.NewLine
        sql += " where 1=1 " & wh & Environment.NewLine
        sql += " group by l.location_name, convert(date, t.trans_start_time), convert(varchar(8), t.trans_start_time,112)"
        Return sql
    End Function


    Public Shared Function GetQueryReportSummaryBySize(wh As String, CurrentPeriod As Integer) As String
        Dim Sql As String = "Declare @MODE As INT=" & CInt(CurrentPeriod) & "; " + Environment.NewLine
        Sql += " Select dbo.udf_ReportTimeValue(isnull(p.pickup_time,s.trans_start_time),@MODE) TimeValue,  " + Environment.NewLine
        Sql += " dbo.udf_ReportTimeDisplay(isnull(p.pickup_time,s.trans_start_time),@MODE) TimeDisplay,  " + Environment.NewLine
        Sql += " cm.model_name, sum(convert(int, dbo.udf_CalTransServiceTime(isnull(s.paid_time,s.trans_start_time), p.pickup_time,'I'))) service_time_int,  " + Environment.NewLine
        Sql += " count(s.id) trans_qty," + Environment.NewLine
        Sql += " sum(case s.trans_status when '1' then 1 else 0 end) - sum(case when s.trans_status='1' and p.trans_status='1' then 1 else 0 end) waiting_collect," + Environment.NewLine
        Sql += " sum(case when s.trans_status = '1' and p.trans_status='1' then 1 else 0 end) trans_success, " + Environment.NewLine
        Sql += " sum(Case s.trans_status When '2' then 1 else 0 end) trans_canceled, " + Environment.NewLine
        Sql += " sum(case s.trans_status when '3' then 1 else 0 end) trans_problem, " + Environment.NewLine
        Sql += " sum(Case s.trans_status When '4' then 1 else 0 end) trans_timeout, " + Environment.NewLine
        Sql += " sum(case p.trans_status when '1' then p.service_amt else 0 end) sales_value, " + Environment.NewLine
        'ถ้าการฝากนั้น ยังไม่รับคือ หรือเป็นรายการฝากที่มีการกด Cancel by Admin ให้แสดงค่ามัดจำ
        Sql += " sum(case when (s.trans_status = '1' and (p.trans_status<>'1' or p.id is null)) or (s.trans_status='1' and (p.trans_status='5' or p.id is null)) then s.deposit_amt else 0 end) deposit_amt " + Environment.NewLine
        Sql += " from TB_DEPOSIT_TRANSACTION s " + Environment.NewLine
        Sql += " left join TB_PICKUP_TRANSACTION p on s.trans_no=p.deposit_trans_no and p.trans_status=1" + Environment.NewLine
        Sql += " inner join MS_LOCKER lo on lo.id=s.ms_locker_id " + Environment.NewLine
        Sql += " inner join MS_CABINET c on c.id=lo.ms_cabinet_id " + Environment.NewLine
        Sql += " inner join MS_CABINET_MODEL cm on cm.id=c.ms_cabinet_model_id " + Environment.NewLine
        Sql += " inner join MS_KIOSK k on k.id=s.ms_kiosk_id " + Environment.NewLine
        'sql += " inner join MS_LOCATION l On l.id=k.ms_location_id " + Environment.NewLine
        Sql += " where 1=1 " + Environment.NewLine
        Sql += wh
        Sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        Sql += " group by dbo.udf_ReportTimeValue(isnull(p.pickup_time,s.trans_start_time),@MODE), " + Environment.NewLine
        Sql += " dbo.udf_ReportTimeDisplay(isnull(p.pickup_time,s.trans_start_time),@MODE),  cm.model_name " + Environment.NewLine
        Sql += " order by cm.model_name, TimeValue"

        Return Sql
    End Function

    Public Shared Function GetQueryDepositTransactionPerformance(wh As String) As String
        Dim sql As String = ""

        sql += " select dbo.udf_ReportTimeValue(s.trans_start_time,@MODE) TimeValue,  " + Environment.NewLine
        sql += " dbo.udf_ReportTimeDisplay(s.trans_start_time,@MODE) TimeDisplay,  " + Environment.NewLine
        sql += " l.location_name, 'DEPOSIT' transaction_type,  " + Environment.NewLine
        sql += " sum(case s.trans_status when '1' then 1 else 0 end) trans_success, " + Environment.NewLine
        sql += " sum(Case s.trans_status When '2' then 1 else 0 end) trans_canceled, " + Environment.NewLine
        sql += " sum(case s.trans_status when '3' then 1 else 0 end) trans_problem, " + Environment.NewLine
        sql += " sum(Case s.trans_status When '4' then 1 else 0 end) trans_timeout, " + Environment.NewLine
        sql += " sum(case s.trans_status when '5' then 1 else 0 end) trans_cancel_by_admin, " + Environment.NewLine
        sql += " sum(case s.trans_status when '0' then 0 else 1 end) trans_total " + Environment.NewLine
        sql += " from TB_DEPOSIT_TRANSACTION s " + Environment.NewLine
        sql += " inner join MS_KIOSK k on k.id=s.ms_kiosk_id " + Environment.NewLine
        sql += " inner join MS_LOCATION l On l.id=k.ms_location_id " + Environment.NewLine
        sql += " where 1=1 " + Environment.NewLine
        sql += wh
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " group by dbo.udf_ReportTimeValue(s.trans_start_time,@MODE), " + Environment.NewLine
        sql += " dbo.udf_ReportTimeDisplay(s.trans_start_time,@MODE),  l.location_name " + Environment.NewLine
        Return sql
    End Function

    Public Shared Function GetQueryCollectTransactionPerformance(wh As String) As String
        Dim sql As String = ""
        'sql = "DECLARE @MODE AS INT=" & CurrentPeriod & "; " + Environment.NewLine
        sql += " select dbo.udf_ReportTimeValue(p.trans_start_time,@MODE) TimeValue,  " + Environment.NewLine
        sql += " dbo.udf_ReportTimeDisplay(p.trans_start_time,@MODE) TimeDisplay,  " + Environment.NewLine
        sql += " l.location_name, 'COLLECT' transaction_type,  " + Environment.NewLine
        sql += " sum(case p.trans_status when '1' then 1 else 0 end) trans_success, " + Environment.NewLine
        sql += " sum(Case p.trans_status When '2' then 1 else 0 end) trans_canceled, " + Environment.NewLine
        sql += " sum(case p.trans_status when '3' then 1 else 0 end) trans_problem, " + Environment.NewLine
        sql += " sum(Case p.trans_status When '4' then 1 else 0 end) trans_timeout, " + Environment.NewLine
        sql += " sum(case p.trans_status when '5' then 1 else 0 end) trans_cancel_by_admin, " + Environment.NewLine
        sql += " sum(case p.trans_status when '0' then 0 else 1 end) trans_total " + Environment.NewLine
        sql += " from TB_PICKUP_TRANSACTION p " + Environment.NewLine
        sql += " inner join MS_KIOSK k on k.id=p.ms_kiosk_id " + Environment.NewLine
        sql += " inner join MS_LOCATION l On l.id=k.ms_location_id " + Environment.NewLine
        sql += " where 1=1 " + Environment.NewLine
        sql += wh
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        sql += " group by dbo.udf_ReportTimeValue(trans_start_time,@MODE), " + Environment.NewLine
        sql += " dbo.udf_ReportTimeDisplay(trans_start_time,@MODE),  l.location_name " + Environment.NewLine

        Return sql
    End Function
#End Region

#Region "Built Excel Datatable"
    Public Shared Function BuildReportSummaryByLocationExcelDatatable(TmpDT As DataTable, DT As DataTable) As DataTable
        TmpDT.Columns.Add("LOCATION")
        TmpDT.Columns.Add("DATE")
        TmpDT.Columns.Add("SR SUCCESS")
        TmpDT.Columns.Add("SR SERVICE AMOUNT")
        TmpDT.Columns.Add("MR SUCCESS")
        TmpDT.Columns.Add("MR SERVICE AMOUNT")
        TmpDT.Columns.Add("LR SUCCESS")
        TmpDT.Columns.Add("LR SERVICE AMOUNT")
        TmpDT.Columns.Add("TOTAL SUCCESS")
        TmpDT.Columns.Add("TOTAL SERVICE AMOUNT")
        Dim DR As DataRow
        For i As Integer = 0 To DT.Rows.Count - 1
            DR = TmpDT.NewRow
            DR("LOCATION") = DT.Rows(i)("location_name")
            DR("DATE") = Convert.ToDateTime(DT.Rows(i)("collect_time")).ToString("dd-MMM-yyyy", New Globalization.CultureInfo("en-US"))
            DR("SR SUCCESS") = FormatNumber(DT.Rows(i)("sr_success"), 0)
            DR("SR SERVICE AMOUNT") = Convert.ToInt64(DT.Rows(i)("sr_amt")).ToString("#,##0.00")
            DR("MR SUCCESS") = FormatNumber(DT.Rows(i)("mr_success"), 0)
            DR("MR SERVICE AMOUNT") = Convert.ToInt64(DT.Rows(i)("mr_amt")).ToString("#,##0.00")
            DR("LR SUCCESS") = FormatNumber(DT.Rows(i)("lr_success"), 0)
            DR("LR SERVICE AMOUNT") = Convert.ToInt64(DT.Rows(i)("lr_amt")).ToString("#,##0.00")
            DR("TOTAL SUCCESS") = FormatNumber(DT.Rows(i)("total_success"), 0)
            DR("TOTAL SERVICE AMOUNT") = Convert.ToInt64(DT.Rows(i)("total_amt")).ToString("#,##0.00")
            TmpDT.Rows.Add(DR)
        Next

        Return TmpDT
    End Function

    Public Shared Function BuildReportSummaryBySizeExcelDataTable(TmpDT As DataTable, TimeDisplay As String, DT As DataTable) As DataTable
        TmpDT.Columns.Add(TimeDisplay)
        TmpDT.Columns.Add("PRODUCT")
        TmpDT.Columns.Add("SERVICE_TIME")
        TmpDT.Columns.Add("TRANSACTION")
        TmpDT.Columns.Add("WAIT_COLLECT")
        TmpDT.Columns.Add("SUCCESS")
        TmpDT.Columns.Add("CANCELED")
        TmpDT.Columns.Add("PROBLEM")
        TmpDT.Columns.Add("TIMEOUT")
        TmpDT.Columns.Add("SALES_VALUE")
        TmpDT.Columns.Add("DEPOSIT_AMT")
        Dim DR As DataRow
        For i As Integer = 0 To DT.Rows.Count - 1
            DR = TmpDT.NewRow
            DR(TimeDisplay) = DT.Rows(i)("TimeDisplay")
            DR("PRODUCT") = DT.Rows(i)("model_name")
            DR("SERVICE_TIME") = Engine.ReportENG.GetFormatServiceTime(DT.Rows(i)("service_time_int"))
            DR("TRANSACTION") = FormatNumber(DT.Rows(i)("trans_qty"), 0)
            DR("WAIT_COLLECT") = FormatNumber(DT.Rows(i)("waiting_collect"), 0)
            DR("SUCCESS") = FormatNumber(DT.Rows(i)("trans_success"), 0)
            DR("CANCELED") = FormatNumber(DT.Rows(i)("trans_canceled"), 0)
            DR("PROBLEM") = FormatNumber(DT.Rows(i)("trans_problem"), 0)
            DR("TIMEOUT") = FormatNumber(DT.Rows(i)("trans_timeout"), 0)
            DR("SALES_VALUE") = FormatNumber(DT.Rows(i)("sales_value"), 0)
            DR("DEPOSIT_AMT") = FormatNumber(DT.Rows(i)("deposit_amt"), 0)
            TmpDT.Rows.Add(DR)
        Next
        Return TmpDT
    End Function

    Public Shared Function BuiltReportTransactionReportExcelDataTable(TmpDT As DataTable, DT As DataTable)
        TmpDT.Columns.Add("DEPOSIT TRANSACTION")
        TmpDT.Columns.Add("START DATE")
        TmpDT.Columns.Add("START TIME")
        TmpDT.Columns.Add("DEPOSIT STATUS")
        TmpDT.Columns.Add("LOCATION")
        TmpDT.Columns.Add("KIOSK")
        TmpDT.Columns.Add("LOCKER")
        TmpDT.Columns.Add("DEPOSIT AMOUNT")
        TmpDT.Columns.Add("CUSTOMER NAME")
        TmpDT.Columns.Add("BIRTH DATE")
        TmpDT.Columns.Add("AGE")
        TmpDT.Columns.Add("CARD TYPE")
        TmpDT.Columns.Add("NATIONALITY")
        TmpDT.Columns.Add("DEPOSIT PAID DATE")
        TmpDT.Columns.Add("DEPOSIT PAID TIME")
        TmpDT.Columns.Add("LAST ACTIVITY")

        TmpDT.Columns.Add("DEPOSIT PAYMENT COIN5")
        TmpDT.Columns.Add("DEPOSIT PAYMENT COIN10")
        TmpDT.Columns.Add("DEPOSIT PAYMENT BANKNOTE20")
        TmpDT.Columns.Add("DEPOSIT PAYMENT BANKNOTE50")
        TmpDT.Columns.Add("DEPOSIT PAYMENT BANKNOTE100")
        TmpDT.Columns.Add("DEPOSIT PAYMENT BANKNOTE500")
        TmpDT.Columns.Add("DEPOSIT PAYMENT BANKNOTE1000")
        TmpDT.Columns.Add("DEPOSIT CHANGE COIN5")
        TmpDT.Columns.Add("DEPOSIT CHANGE BANKNOTE20")
        TmpDT.Columns.Add("DEPOSIT CHANGE BANKNOTE100")

        TmpDT.Columns.Add("COLLECT TRANSACTION")
        TmpDT.Columns.Add("COLLECT DATE")
        TmpDT.Columns.Add("COLLECT TIME")
        TmpDT.Columns.Add("COLLECT PAID DATE")
        TmpDT.Columns.Add("COLLECT PAID TIME")
        TmpDT.Columns.Add("COLLECT STATUS")
        TmpDT.Columns.Add("COLLECT CARD TYPE")
        TmpDT.Columns.Add("SERVICE TIME")
        TmpDT.Columns.Add("SERVICE AMOUNT")

        TmpDT.Columns.Add("COLLECT PAYMENT COIN5")
        TmpDT.Columns.Add("COLLECT PAYMENT COIN10")
        TmpDT.Columns.Add("COLLECT PAYMENT BANKNOTE20")
        TmpDT.Columns.Add("COLLECT PAYMENT BANKNOTE50")
        TmpDT.Columns.Add("COLLECT PAYMENT BANKNOTE100")
        TmpDT.Columns.Add("COLLECT PAYMENT BANKNOTE500")
        TmpDT.Columns.Add("COLLECT PAYMENT BANKNOTE1000")
        TmpDT.Columns.Add("COLLECT CHANGE COIN5")
        TmpDT.Columns.Add("COLLECT CHANGE BANKNOTE20")
        TmpDT.Columns.Add("COLLECT CHANGE BANKNOTE100")

        Dim DR As DataRow
        For i As Integer = 0 To DT.Rows.Count - 1
            DR = TmpDT.NewRow
            DR("DEPOSIT TRANSACTION") = DT.Rows(i)("deposit_transaction_no")
            DR("START DATE") = Convert.ToDateTime(DT.Rows(i)("trans_start_time")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            DR("START TIME") = Convert.ToDateTime(DT.Rows(i)("trans_start_time")).ToString("HH:mm:ss")
            DR("DEPOSIT STATUS") = DT.Rows(i)("deposit_status_name")
            DR("LOCATION") = DT.Rows(i)("location_name")
            DR("KIOSK") = DT.Rows(i)("com_name")
            DR("LOCKER") = DT.Rows(i)("locker_name")
            If DT.Rows(i)("deposit_status") = "1" Then DR("DEPOSIT AMOUNT") = DT.Rows(i)("deposit_amt")
            DR("CUSTOMER NAME") = DT.Rows(i)("first_name") & " " & DT.Rows(i)("last_name")
            If Convert.IsDBNull(DT.Rows(i)("birth_date")) = False Then
                DR("BIRTH DATE") = Convert.ToDateTime(DT.Rows(i)("birth_date")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                DR("AGE") = DateTime.Now.Year - Convert.ToDateTime(DT.Rows(i)("birth_date")).Year
            End If
            If Convert.IsDBNull(DT.Rows(i)("card_type")) = False Then DR("CARD TYPE") = DT.Rows(i)("card_type")
            If Convert.IsDBNull(DT.Rows(i)("nation_code")) = False Then DR("NATIONALITY") = DT.Rows(i)("nation_code").ToString
            If Convert.IsDBNull(DT.Rows(i)("deposit_paid_time")) = False Then
                DR("DEPOSIT PAID DATE") = Convert.ToDateTime(DT.Rows(i)("deposit_paid_time")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                DR("DEPOSIT PAID TIME") = Convert.ToDateTime(DT.Rows(i)("deposit_paid_time")).ToString("HH:mm:ss")
            End If
            If Convert.IsDBNull(DT.Rows(i)("step_name_th")) = False Then DR("LAST ACTIVITY") = DT.Rows(i)("step_name_th")

            If DT.Rows(i)("deposit_payment_coin5") > 0 Then DR("DEPOSIT PAYMENT COIN5") = DT.Rows(i)("deposit_payment_coin5")
            If DT.Rows(i)("deposit_payment_coin10") > 0 Then DR("DEPOSIT PAYMENT COIN10") = DT.Rows(i)("deposit_payment_coin10")
            If DT.Rows(i)("deposit_payment_banknote20") > 0 Then DR("DEPOSIT PAYMENT BANKNOTE20") = DT.Rows(i)("deposit_payment_banknote20")
            If DT.Rows(i)("deposit_payment_banknote50") > 0 Then DR("DEPOSIT PAYMENT BANKNOTE50") = DT.Rows(i)("deposit_payment_banknote50")
            If DT.Rows(i)("deposit_payment_banknote100") > 0 Then DR("DEPOSIT PAYMENT BANKNOTE100") = DT.Rows(i)("deposit_payment_banknote100")
            If DT.Rows(i)("deposit_payment_banknote500") > 0 Then DR("DEPOSIT PAYMENT BANKNOTE500") = DT.Rows(i)("deposit_payment_banknote500")
            If DT.Rows(i)("deposit_payment_banknote1000") > 0 Then DR("DEPOSIT PAYMENT BANKNOTE1000") = DT.Rows(i)("deposit_payment_banknote1000")
            If DT.Rows(i)("deposit_change_coin5") > 0 Then DR("DEPOSIT CHANGE COIN5") = DT.Rows(i)("deposit_change_coin5")
            If DT.Rows(i)("deposit_change_banknote20") > 0 Then DR("DEPOSIT CHANGE BANKNOTE20") = DT.Rows(i)("deposit_change_banknote20")
            If DT.Rows(i)("deposit_change_banknote100") > 0 Then DR("DEPOSIT CHANGE BANKNOTE100") = DT.Rows(i)("deposit_change_banknote100")

            If Convert.IsDBNull(DT.Rows(i)("collect_transaction_no")) = False Then DR("COLLECT TRANSACTION") = DT.Rows(i)("collect_transaction_no")
            If Convert.IsDBNull(DT.Rows(i)("collect_time")) = False Then
                DR("COLLECT DATE") = Convert.ToDateTime(DT.Rows(i)("collect_time")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                DR("COLLECT TIME") = Convert.ToDateTime(DT.Rows(i)("collect_time")).ToString("HH:mm:ss")
            End If
            If Convert.IsDBNull(DT.Rows(i)("collect_paid_time")) = False Then
                DR("COLLECT PAID DATE") = Convert.ToDateTime(DT.Rows(i)("collect_paid_time")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                DR("COLLECT PAID TIME") = Convert.ToDateTime(DT.Rows(i)("collect_paid_time")).ToString("HH:mm:ss")
            End If
            If Convert.IsDBNull(DT.Rows(i)("collect_status_name")) = False Then DR("COLLECT STATUS") = DT.Rows(i)("collect_status_name")
            If Convert.IsDBNull(DT.Rows(i)("lost_qr_code")) = False Then
                If DT.Rows(i)("lost_qr_code") <> "Z" Then
                    If DT.Rows(i)("lost_qr_code") = "Y" Then
                        If Convert.IsDBNull(DT.Rows(i)("card_type")) = False Then DR("COLLECT CARD TYPE") = DT.Rows(i)("card_type")
                    Else
                        DR("COLLECT CARD TYPE") = "QR Code"
                    End If

                End If
            End If
            If Convert.IsDBNull(DT.Rows(i)("deposit_status")) = False And Convert.IsDBNull(DT.Rows(i)("collect_status")) = False Then
                If DT.Rows(i)("deposit_status") = "1" And DT.Rows(i)("collect_status") = "1" Then
                    DR("SERVICE TIME") = DT.Rows(i)("service_time_str").ToString 'CalTransactionServiceTime(Convert.ToDateTime(DT.Rows(i)("deposit_paid_time")), Convert.ToDateTime(DT.Rows(i)("collect_time")))
                    If Convert.IsDBNull(DT.Rows(i)("service_amt")) = False Then DR("SERVICE AMOUNT") = Convert.ToDouble(DT.Rows(i)("service_amt")).ToString("#,##0")
                End If
            End If

            If DT.Rows(i)("collect_payment_coin5") > 0 Then DR("COLLECT PAYMENT COIN5") = DT.Rows(i)("collect_payment_coin5")
            If DT.Rows(i)("collect_payment_coin10") > 0 Then DR("COLLECT PAYMENT COIN10") = DT.Rows(i)("collect_payment_coin10")
            If DT.Rows(i)("collect_payment_banknote20") > 0 Then DR("COLLECT PAYMENT BANKNOTE20") = DT.Rows(i)("collect_payment_banknote20")
            If DT.Rows(i)("collect_payment_banknote50") > 0 Then DR("COLLECT PAYMENT BANKNOTE50") = DT.Rows(i)("collect_payment_banknote50")
            If DT.Rows(i)("collect_payment_banknote100") > 0 Then DR("COLLECT PAYMENT BANKNOTE100") = DT.Rows(i)("collect_payment_banknote100")
            If DT.Rows(i)("collect_payment_banknote500") > 0 Then DR("COLLECT PAYMENT BANKNOTE500") = DT.Rows(i)("collect_payment_banknote500")
            If DT.Rows(i)("collect_payment_banknote1000") > 0 Then DR("COLLECT PAYMENT BANKNOTE1000") = DT.Rows(i)("collect_payment_banknote1000")
            If DT.Rows(i)("collect_change_coin5") > 0 Then DR("COLLECT CHANGE COIN5") = DT.Rows(i)("collect_change_coin5")
            If DT.Rows(i)("collect_change_banknote20") > 0 Then DR("COLLECT CHANGE BANKNOTE20") = DT.Rows(i)("collect_change_banknote20")
            If DT.Rows(i)("collect_change_banknote100") > 0 Then DR("COLLECT CHANGE BANKNOTE100") = DT.Rows(i)("collect_change_banknote100")

            TmpDT.Rows.Add(DR)
        Next

        Return TmpDT
    End Function

    Public Shared Function BuiltReportTransactionPerformanceExcelDataTable(TmpDT As DataTable, TimeDisplay As String, DT As DataTable) As DataTable
        TmpDT.Columns.Add(TimeDisplay)
        TmpDT.Columns.Add("LOCATION")
        TmpDT.Columns.Add("TRANSACTION_TYPE")
        TmpDT.Columns.Add("SUCCESS")
        TmpDT.Columns.Add("CANCELED")
        TmpDT.Columns.Add("PROBLEM")
        TmpDT.Columns.Add("TIMEOUT")
        TmpDT.Columns.Add("TOTAL")

        For i As Integer = 0 To DT.Rows.Count - 1
            Dim DR As DataRow = TmpDT.NewRow
            DR(TimeDisplay) = DT.Rows(i)("TimeDisplay")
            DR("LOCATION") = DT.Rows(i)("location_name")
            DR("TRANSACTION_TYPE") = DT.Rows(i)("transaction_type")
            DR("SUCCESS") = FormatNumber(DT.Rows(i)("trans_success"), 0)
            DR("CANCELED") = FormatNumber(DT.Rows(i)("trans_canceled"), 0)
            DR("PROBLEM") = FormatNumber(DT.Rows(i)("trans_problem"), 0)
            DR("TIMEOUT") = FormatNumber(DT.Rows(i)("trans_timeout"), 0)
            DR("TOTAL") = FormatNumber(DT.Rows(i)("trans_total"), 0)
            TmpDT.Rows.Add(DR)
        Next

        Return TmpDT
    End Function

#End Region





    Public Shared Function GetFormatServiceTime(ByVal TimeSec As Integer) As String
        'แปลงเวลาจากวินาทีไปเป็น HH:mm:ss
        Dim ret As String = ""

        Dim tDay As Integer = 0
        Dim tHour As Integer = 0
        Dim tMin As Integer = 0
        Dim tSec As Integer = 0

        If TimeSec >= 86400 Then   'จำนวนวินาทีใน 1 วัน
            tDay = Math.Floor(TimeSec / 86400)

            Dim RemainSec As Integer = TimeSec - (tDay * 86400)
            If RemainSec >= 3600 Then
                tHour = Math.Floor(RemainSec / 3600) 'ชม.
                tMin = Math.Floor((RemainSec - (tHour * 3600)) / 60) ' นาที
                tSec = (RemainSec - (tHour * 3600)) Mod 60
            Else
                tMin = Math.Floor(TimeSec / 60)
                tSec = TimeSec Mod 60
            End If

            ret = tDay.ToString & " วัน " & tHour.ToString.PadLeft(2, "0") & ":" & tMin.ToString.PadLeft(2, "0") & ":" & tSec.ToString.PadLeft(2, "0")
        ElseIf TimeSec >= 3600 Then
            tHour = Math.Floor(TimeSec / 3600) 'ชม.
            tMin = Math.Floor((TimeSec - (tHour * 3600)) / 60) ' นาที
            tSec = (TimeSec - (tHour * 3600)) Mod 60
            ret = tHour.ToString.PadLeft(2, "0") & ":" & tMin.ToString.PadLeft(2, "0") & ":" & tSec.ToString.PadLeft(2, "0")
        Else
            tMin = Math.Floor(TimeSec / 60)
            tSec = TimeSec Mod 60
            ret = tHour.ToString.PadLeft(2, "0") & ":" & tMin.ToString.PadLeft(2, "0") & ":" & tSec.ToString.PadLeft(2, "0")
        End If

        Return ret
    End Function

    Public Shared Function GetFirstDayOfWeek(ByVal TxnDate As Date) As Date
        Dim FirstDayOfWeek As Date = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        Dim LastDayOfWeek As Date = DateAdd(DateInterval.Day, 7 - (FirstDayOfWeek.DayOfWeek + 1), FirstDayOfWeek)

        For i As Integer = 1 To 5
            If TxnDate.Date >= FirstDayOfWeek.Date And TxnDate.Date <= LastDayOfWeek.Date Then
                Return FirstDayOfWeek
            End If

            FirstDayOfWeek = DateAdd(DateInterval.Day, 7, FirstDayOfWeek).Date
            If FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday Then
                FirstDayOfWeek = DateAdd(DateInterval.Day, 1, LastDayOfWeek).Date
            End If

            LastDayOfWeek = DateAdd(DateInterval.Day, 7, LastDayOfWeek).Date
            If LastDayOfWeek.Month <> DateTime.Now.Month Then
                LastDayOfWeek = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).Date
            End If
        Next
    End Function

    Public Shared Function GetLastDayOfWeek(ByVal TxnDate As Date) As Date
        Dim FirstDayOfWeek As Date = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        Dim LastDayOfWeek As Date = DateAdd(DateInterval.Day, 7 - (FirstDayOfWeek.DayOfWeek + 1), FirstDayOfWeek)

        For i As Integer = 1 To 5
            If TxnDate.Date >= FirstDayOfWeek.Date And TxnDate.Date <= LastDayOfWeek.Date Then
                Return LastDayOfWeek
            End If

            FirstDayOfWeek = DateAdd(DateInterval.Day, 7, FirstDayOfWeek).Date
            If FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday Then
                FirstDayOfWeek = DateAdd(DateInterval.Day, 1, LastDayOfWeek).Date
            End If

            LastDayOfWeek = DateAdd(DateInterval.Day, 7, LastDayOfWeek).Date
            If LastDayOfWeek.Month <> DateTime.Now.Month Then
                LastDayOfWeek = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).Date
            End If
        Next
    End Function
End Class
