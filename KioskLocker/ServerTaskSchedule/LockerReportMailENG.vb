Imports Engine.LogFileENG
Imports System.Data.SqlClient
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports OfficeOpenXml
Imports System.Net.Mail

Public Class LockerReportMailENG
    Public Shared Sub SendMailDailyReport(vReportDate As Date)
        Dim strReportDate As String = vReportDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Dim dt As DataTable = LockerReportMailENG.GetMailGroupReportInfo()
        If dt.Rows.Count > 0 Then
            Dim mlDt As New DataTable
            mlDt = dt.DefaultView.ToTable(True, "ms_location_id", "location_name", "ms_reports_mail_id", "report_name").Copy

            If mlDt.Rows.Count > 0 Then
                For Each mlDr As DataRow In mlDt.Rows
                    Dim MsLocationID As Long = Convert.ToInt64(mlDr("ms_location_id"))
                    Dim MsReportMailID As Long = Convert.ToInt64(mlDr("ms_reports_mail_id"))

                    'Generate Excel File
                    '1   Transaction Log Report
                    '2   Transaction Performance Report
                    '3   Summary Report By Location
                    '4   Summary Report By Product

                    Dim ReportFileName As String = Application.StartupPath & "\ExcelReports\" & vReportDate.Year & "\" & vReportDate.Year & vReportDate.ToString("MM") & "\" & strReportDate & "\"
                    If IO.Directory.Exists(ReportFileName) = False Then
                        IO.Directory.CreateDirectory(ReportFileName)
                    End If

                    Dim MailSubject As String = ""
                    Dim MailContent As String = ""
                    Dim ret As Boolean = False
                    Select Case Convert.ToInt16(mlDr("ms_reports_mail_id"))
                        'Case ReportName.SummaryReportByLocation
                        '    MailSubject = "Summary Report by Location at " & mlDr("location_name") & " on " & vReportDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
                        '    MailContent = "Dear All <br />" & MailSubject & " <br /><br />"
                        '    MailContent += "[Auto Mail please no reply]"

                        '    ReportFileName += "SummaryByLocation_" & mlDr("location_name") & "_" & strReportDate & ".xlsx"
                        '    ret = GenExcelSummaryReportByLocation(vReportDate, MsLocationID, ReportFileName)
                        'Case ReportName.SummaryReportByProduct
                        '    MailSubject = "Summary Report by Locker Size at " & mlDr("location_name") & " on " & vReportDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
                        '    MailContent = "Dear All <br />" & MailSubject & " <br /><br />"
                        '    MailContent += "[Auto Mail please no reply]"

                        '    ReportFileName += "SummaryBySize_" & mlDr("location_name") & "_" & strReportDate & ".xlsx"
                        '    ret = GenExcelSummaryReportBySize(vReportDate, MsLocationID, ReportFileName)
                        Case ReportName.TransactionLogReport
                            MailSubject = "Transaction Log Report at " & mlDr("location_name") & " on " & vReportDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
                            MailContent = "Dear All <br />" & MailSubject & " <br /><br />"
                            MailContent += "[Auto Mail please no reply]"

                            ReportFileName += "TransactionLogReport_" & mlDr("location_name") & "_" & strReportDate & ".xlsx"
                            ret = GenExcelTransactionLogReport(vReportDate, MsLocationID, ReportFileName)
                        Case ReportName.TransactionPerformanceReport
                            MailSubject = "Transaction Performance Report at " & mlDr("location_name") & " on " & vReportDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US"))
                            MailContent = "Dear All <br />" & MailSubject & " <br /><br />"
                            MailContent += "[Auto Mail please no reply]"

                            ReportFileName += "TransactionPerformanceReport_" & mlDr("location_name") & "_" & strReportDate & ".xlsx"
                            ret = GenExcelTransactionPerformanceReports(vReportDate, MsLocationID, ReportFileName)
                    End Select

                    If ret = True Then
                        dt.DefaultView.RowFilter = "ms_location_id = " & MsLocationID & " and ms_reports_mail_id = " & MsReportMailID
                        Dim eDT As New DataTable
                        eDT = dt.DefaultView.ToTable(True, "email")

                        If eDT.Rows.Count > 0 Then
                            Dim Mail As New MailMessage
                            For i As Integer = 0 To eDT.Rows.Count - 1
                                Mail.To.Add(eDT.Rows(i)("email"))
                            Next
                            Mail.Attachments.Add(New Attachment(ReportFileName))
                            SendMailENG.SendMail(Mail, MailContent, MailSubject, "Locker Daily Reports")
                        End If
                        eDT.Dispose()
                        dt.DefaultView.RowFilter = ""
                    End If
                Next
            End If
            mlDt.Dispose()
        End If
        dt.Dispose()
    End Sub

    Private Shared Function GetMailGroupReportInfo() As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select mg.group_code,mg.group_name, mgd.email, mgl.ms_location_id, l.location_name, mgr.ms_reports_mail_id, rm.report_name " & Environment.NewLine
            sql += " From MS_REPORT_MAIL_GROUP mg " & Environment.NewLine
            sql += " inner join MS_REPORT_MAIL_GROUP_DETAIL mgd on mg.id=mgd.ms_report_mail_group_id " & Environment.NewLine
            sql += " inner Join MS_REPORT_MAIL_GROUP_LOCATION mgl on mg.id=mgl.ms_report_mail_group_id " & Environment.NewLine
            sql += " inner join MS_LOCATION l on l.id=mgl.ms_location_id " & Environment.NewLine
            sql += " inner Join MS_REPORT_MAIL_GROUP_REPORTS mgr on mg.id=mgr.ms_report_mail_group_id " & Environment.NewLine
            sql += " inner join MS_REPORTS_MAIL rm on rm.id=mgr.ms_reports_mail_id " & Environment.NewLine
            sql += " where mg.active_status ='Y' and l.active_status='Y' and rm.active_status='Y'" & Environment.NewLine

            ret = ServerDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
            CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function


#Region "Transaction Performance "
    Private Shared Function GenExcelTransactionPerformanceReports(ReportDate As DateTime, MsLocationID As Long, ExcelFileName As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim wh As String = ""
            wh += " and l.id =@_LOCATION_ID " + Environment.NewLine
            wh += " and convert(date,trans_start_time)  >= @_TIME_START " + Environment.NewLine

            Dim parm(2) As SqlParameter
            parm(1) = ServerDB.SetDateTime("@_TIME_START", ReportDate)
            parm(0) = ServerDB.SetBigInt("@_LOCATION_ID", MsLocationID)

            Dim sql As String = "DECLARE @MODE AS INT=2; " + Environment.NewLine
            sql += Engine.ReportENG.GetQueryDepositTransactionPerformance(wh)
            sql += " UNION ALL " & Environment.NewLine
            sql += Engine.ReportENG.GetQueryCollectTransactionPerformance(wh)
            sql += " order by location_name, TimeValue "

            Dim DT As DataTable = ServerDB.ExecuteTable(sql, parm)
            If DT.Rows.Count > 0 Then
                Dim TmpDT As New DataTable
                TmpDT = Engine.ReportENG.BuiltReportTransactionPerformanceExcelDataTable(TmpDT, "DATE", DT)

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
                Dim DR As DataRow
                DR = TmpDT.NewRow
                '------------- Average------------
                If Not IsDBNull(AVG_TOTAL_TRANSACTIONS) Then
                    DR("TOTAL") = FormatNumber(AVG_TOTAL_TRANSACTIONS, 0)
                Else
                    DR("TOTAL") = "-"
                End If
                If Not IsDBNull(AVG_CANCEL_TRANSACTIONS) Then
                    DR("CANCELED") = FormatNumber(AVG_CANCEL_TRANSACTIONS, 0)
                Else
                    DR("CANCELED") = "-"
                End If
                If Not IsDBNull(AVG_PROBLEM_TRANSACTIONS) Then
                    DR("PROBLEM") = FormatNumber(AVG_PROBLEM_TRANSACTIONS, 0)
                Else
                    DR("PROBLEM") = "-"
                End If
                If Not IsDBNull(AVG_TIMEOUT_TRANSACTIONS) Then
                    DR("TIMEOUT") = FormatNumber(AVG_TIMEOUT_TRANSACTIONS, 0)
                Else
                    DR("TIMEOUT") = "-"
                End If
                If Not IsDBNull(AVG_SUCCESS_TRANSACTIONS) Then
                    DR("SUCCESS") = FormatNumber(AVG_SUCCESS_TRANSACTIONS, 0)
                Else
                    DR("SUCCESS") = "-"
                End If

                '------------- Summary------------
                If Not IsDBNull(SUM_TOTAL_TRANSACTIONS) Then
                    DR("TOTAL") = FormatNumber(SUM_TOTAL_TRANSACTIONS, 0)
                Else
                    DR("TOTAL") = "-"
                End If
                If Not IsDBNull(SUM_CANCEL_TRANSACTIONS) Then
                    DR("CANCELED") = FormatNumber(SUM_CANCEL_TRANSACTIONS, 0)
                Else
                    DR("CANCELED") = "-"
                End If
                If Not IsDBNull(SUM_PROBLEM_TRANSACTIONS) Then
                    DR("PROBLEM") = FormatNumber(SUM_PROBLEM_TRANSACTIONS, 0)
                Else
                    DR("PROBLEM") = "-"
                End If
                If Not IsDBNull(SUM_TIMEOUT_TRANSACTIONS) Then
                    DR("TIMEOUT") = FormatNumber(SUM_TIMEOUT_TRANSACTIONS, 0)
                Else
                    DR("TIMEOUT") = "-"
                End If
                If Not IsDBNull(SUM_SUCCESS_TRANSACTIONS) Then
                    DR("SUCCESS") = FormatNumber(SUM_SUCCESS_TRANSACTIONS, 0)
                Else
                    DR("SUCCESS") = "-"
                End If

                Dim lnq As MsLocationServerLinqDB = GetLocationInfo(MsLocationID)
                ret = ExportDatatableToExcel(TmpDT, ExcelFileName, 2, lnq.LOCATION_NAME)
                lnq = Nothing
            End If
            DT.Dispose()
        Catch ex As Exception
            ret = False
            CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region

#Region "Summary Report by Size"
    Private Shared Function GenExcelSummaryReportBySize(ReportDate As DateTime, MsLocationID As Long, ExcelFileName As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim wh As String = " and convert(date,isnull(p.pickup_time,s.trans_start_time))  =  @_TIME_START " + Environment.NewLine
            wh += " and k.ms_location_id = @_MS_LOCATION_ID "
            Dim parm(2) As SqlParameter
            parm(0) = ServerDB.SetDateTime("@_TIME_START", ReportDate)
            parm(1) = ServerDB.SetBigInt("@_MS_LOCATION_ID", MsLocationID)

            Dim sql As String = Engine.ReportENG.GetQueryReportSummaryBySize(wh, 2)
            Dim DT As DataTable = ServerDB.ExecuteTable(sql, parm)
            If DT.Rows.Count > 0 Then
                Dim TmpDT As New DataTable
                TmpDT = Engine.ReportENG.BuildReportSummaryBySizeExcelDataTable(TmpDT, "DATE", DT)

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
                Dim DR As DataRow
                DR = TmpDT.NewRow
                DR("PRODUCT") = "Average"
                If Not IsDBNull(AVG_SERVICE_TIME) Then
                    DR("SERVICE_TIME") = Engine.ReportENG.GetFormatServiceTime(AVG_SERVICE_TIME)
                Else
                    DR("SERVICE_TIME") = "-"
                End If
                If Not IsDBNull(AVG_TRANS_QTY) Then
                    DR("TRANSACTION") = FormatNumber(AVG_TRANS_QTY, 0)
                Else
                    DR("TRANSACTION") = "-"
                End If
                If Not IsDBNull(AVG_WAITING_COLLECT) Then
                    DR("WAIT_COLLECT") = FormatNumber(AVG_WAITING_COLLECT, 0)
                Else
                    DR("WAIT_COLLECT") = "-"
                End If
                If Not IsDBNull(AVG_SUCCESS_TRANSACTIONS) Then
                    DR("SUCCESS") = FormatNumber(AVG_SUCCESS_TRANSACTIONS, 0)
                Else
                    DR("SUCCESS") = "-"
                End If
                If Not IsDBNull(AVG_CANCEL_TRANSACTIONS) Then
                    DR("CANCELED") = FormatNumber(AVG_CANCEL_TRANSACTIONS, 0)
                Else
                    DR("CANCELED") = "-"
                End If
                If Not IsDBNull(AVG_PROBLEM_TRANSACTIONS) Then
                    DR("PROBLEM") = FormatNumber(AVG_PROBLEM_TRANSACTIONS, 0)
                Else
                    DR("PROBLEM") = "-"
                End If
                If Not IsDBNull(AVG_TIMEOUT_TRANSACTIONS) Then
                    DR("TIMEOUT") = FormatNumber(AVG_TIMEOUT_TRANSACTIONS, 0)
                Else
                    DR("TIMEOUT") = "-"
                End If
                If Not IsDBNull(AVG_SALES_VALUE) Then
                    DR("SALES_VALUE") = FormatNumber(AVG_SALES_VALUE, 0)
                Else
                    DR("SALES_VALUE") = "-"
                End If
                If Not IsDBNull(AVG_DEPOSIT_AMT) Then
                    DR("DEPOSIT_AMT") = FormatNumber(AVG_DEPOSIT_AMT, 0)
                Else
                    DR("DEPOSIT_AMT") = "-"
                End If
                TmpDT.Rows.Add(DR)



                DR = TmpDT.NewRow
                'DR(TimeDisplay) = ""
                DR("PRODUCT") = "Total"
                '------------- Summary------------
                If Not IsDBNull(SUM_SERVICE_TIME) Then
                    DR("SERVICE_TIME") = Engine.ReportENG.GetFormatServiceTime(SUM_SERVICE_TIME)
                Else
                    DR("SERVICE_TIME") = "-"
                End If
                If Not IsDBNull(SUM_TRANS_QTY) Then
                    DR("TRANSACTION") = FormatNumber(SUM_TRANS_QTY, 0)
                Else
                    DR("TRANSACTION") = "-"
                End If
                If Not IsDBNull(SUM_WAITING_COLLECT) Then
                    DR("WAIT_COLLECT") = FormatNumber(SUM_WAITING_COLLECT, 0)
                Else
                    DR("WAIT_COLLECT") = "-"
                End If
                If Not IsDBNull(SUM_SUCCESS_TRANSACTIONS) Then
                    DR("SUCCESS") = FormatNumber(SUM_SUCCESS_TRANSACTIONS, 0)
                Else
                    DR("SUCCESS") = "-"
                End If
                If Not IsDBNull(SUM_CANCEL_TRANSACTIONS) Then
                    DR("CANCELED") = FormatNumber(SUM_CANCEL_TRANSACTIONS, 0)
                Else
                    DR("CANCELED") = "-"
                End If
                If Not IsDBNull(SUM_PROBLEM_TRANSACTIONS) Then
                    DR("PROBLEM") = FormatNumber(SUM_PROBLEM_TRANSACTIONS, 0)
                Else
                    DR("PROBLEM") = "-"
                End If
                If Not IsDBNull(SUM_TIMEOUT_TRANSACTIONS) Then
                    DR("TIMEOUT") = FormatNumber(SUM_TIMEOUT_TRANSACTIONS, 0)
                Else
                    DR("TIMEOUT") = "-"
                End If
                If Not IsDBNull(SUM_SALES_VALUE) Then
                    DR("SALES_VALUE") = FormatNumber(SUM_SALES_VALUE, 0)
                Else
                    DR("SALES_VALUE") = "-"
                End If
                If Not IsDBNull(SUM_DEPOSIT_AMT) Then
                    DR("DEPOSIT_AMT") = FormatNumber(SUM_DEPOSIT_AMT, 0)
                Else
                    DR("DEPOSIT_AMT") = "-"
                End If
                TmpDT.Rows.Add(DR)

                Dim lnq As MsLocationServerLinqDB = GetLocationInfo(MsLocationID)
                ret = ExportDatatableToExcel(TmpDT, ExcelFileName, 2, lnq.LOCATION_NAME)
                lnq = Nothing
            End If

            DT.Dispose()
        Catch ex As Exception
            ret = False
            CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region

#Region "Summary Report By Location"
    Private Shared Function GenExcelSummaryReportByLocation(ReportDate As DateTime, MsLocationID As Long, ExcelFileName As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim wh As String = " and convert(date,isnull(p.pickup_time,s.trans_start_time))  =  @_TIME_START " + Environment.NewLine
            wh += " and k.ms_location_id = @_MS_LOCATION_ID "
            Dim parm(2) As SqlParameter
            parm(0) = ServerDB.SetDateTime("@_TIME_START", ReportDate)
            parm(1) = ServerDB.SetBigInt("@_MS_LOCATION_ID", MsLocationID)

            Dim sql As String = Engine.ReportENG.GetQueryReportSummaryByLocation(wh)
            Dim DT As DataTable = ServerDB.ExecuteTable(sql, parm)
            If DT.Rows.Count > 0 Then
                Dim TmpDT As New DataTable
                TmpDT = Engine.ReportENG.BuildReportSummaryByLocationExcelDatatable(TmpDT, DT)

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
                Dim DR As DataRow
                DR = TmpDT.NewRow
                If Not IsDBNull(AVG_SERVICE_TIME) Then
                    DR("SERVICE_TIME") = Engine.ReportENG.GetFormatServiceTime(AVG_SERVICE_TIME)
                Else
                    DR("SERVICE_TIME") = "-"
                End If
                If Not IsDBNull(AVG_TRANS_QTY) Then
                    DR("TRANSACTION") = FormatNumber(AVG_TRANS_QTY, 0)
                Else
                    DR("TRANSACTION") = "-"
                End If
                If Not IsDBNull(AVG_WAITING_COLLECT) Then
                    DR("WAIT_COLLECT") = FormatNumber(AVG_WAITING_COLLECT, 0)
                Else
                    DR("WAIT_COLLECT") = "-"
                End If
                If Not IsDBNull(AVG_SUCCESS_TRANSACTIONS) Then
                    DR("SUCCESS") = FormatNumber(AVG_SUCCESS_TRANSACTIONS, 0)
                Else
                    DR("SUCCESS") = "-"
                End If
                If Not IsDBNull(AVG_CANCEL_TRANSACTIONS) Then
                    DR("CANCELED") = FormatNumber(AVG_CANCEL_TRANSACTIONS, 0)
                Else
                    DR("CANCELED") = "-"
                End If
                If Not IsDBNull(AVG_PROBLEM_TRANSACTIONS) Then
                    DR("PROBLEM") = FormatNumber(AVG_PROBLEM_TRANSACTIONS, 0)
                Else
                    DR("PROBLEM") = "-"
                End If
                If Not IsDBNull(AVG_TIMEOUT_TRANSACTIONS) Then
                    DR("TIMEOUT") = FormatNumber(AVG_TIMEOUT_TRANSACTIONS, 0)
                Else
                    DR("TIMEOUT") = "-"
                End If
                If Not IsDBNull(AVG_SALES_VALUE) Then
                    DR("SALES_VALUE") = FormatNumber(AVG_SALES_VALUE, 0)
                Else
                    DR("SALES_VALUE") = "-"
                End If
                If Not IsDBNull(AVG_DEPOSIT_AMT) Then
                    DR("DEPOSIT_AMT") = FormatNumber(AVG_DEPOSIT_AMT, 0)
                Else
                    DR("DEPOSIT_AMT") = "-"
                End If
                TmpDT.Rows.Add(DR)

                DR = TmpDT.NewRow
                'DR(TimeDisplay) = ""
                DR("LOCATION") = "Total"
                '------------- Summary------------
                If Not IsDBNull(SUM_SERVICE_TIME) Then
                    DR("SERVICE_TIME") = Engine.ReportENG.GetFormatServiceTime(SUM_SERVICE_TIME)
                Else
                    DR("SERVICE_TIME") = "-"
                End If
                If Not IsDBNull(SUM_TRANS_QTY) Then
                    DR("TRANSACTION") = FormatNumber(SUM_TRANS_QTY, 0)
                Else
                    DR("TRANSACTION") = "-"
                End If
                If Not IsDBNull(SUM_WAITING_COLLECT) Then
                    DR("WAIT_COLLECT") = FormatNumber(SUM_WAITING_COLLECT, 0)
                Else
                    DR("WAIT_COLLECT") = "-"
                End If
                If Not IsDBNull(SUM_SUCCESS_TRANSACTIONS) Then
                    DR("SUCCESS") = FormatNumber(SUM_SUCCESS_TRANSACTIONS, 0)
                Else
                    DR("SUCCESS") = "-"
                End If
                If Not IsDBNull(SUM_CANCEL_TRANSACTIONS) Then
                    DR("CANCELED") = FormatNumber(SUM_CANCEL_TRANSACTIONS, 0)
                Else
                    DR("CANCELED") = "-"
                End If
                If Not IsDBNull(SUM_PROBLEM_TRANSACTIONS) Then
                    DR("PROBLEM") = FormatNumber(SUM_PROBLEM_TRANSACTIONS, 0)
                Else
                    DR("PROBLEM") = "-"
                End If
                If Not IsDBNull(SUM_TIMEOUT_TRANSACTIONS) Then
                    DR("TIMEOUT") = FormatNumber(SUM_TIMEOUT_TRANSACTIONS, 0)
                Else
                    DR("TIMEOUT") = "-"
                End If
                If Not IsDBNull(SUM_SALES_VALUE) Then
                    DR("SALES_VALUE") = FormatNumber(SUM_SALES_VALUE, 0)
                Else
                    DR("SALES_VALUE") = "-"
                End If
                If Not IsDBNull(SUM_DEPOSIT_AMT) Then
                    DR("DEPOSIT_AMT") = FormatNumber(SUM_DEPOSIT_AMT, 0)
                Else
                    DR("DEPOSIT_AMT") = "-"
                End If
                TmpDT.Rows.Add(DR)

                Dim lnq As MsLocationServerLinqDB = GetLocationInfo(MsLocationID)
                ret = ExportDatatableToExcel(TmpDT, ExcelFileName, 2, lnq.LOCATION_NAME)
                lnq = Nothing
            End If

            DT.Dispose()
        Catch ex As Exception
            ret = False
            CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region

#Region "Transaction Log Report"
    Private Shared Function GenExcelTransactionLogReport(ReportDate As DateTime, MsLocationID As Long, ExcelFileName As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim strDate As String = ReportDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim dt As DataTable = GetDataTransactionLogReport(ReportDate, MsLocationID)
            If dt.Rows.Count > 0 Then
                Dim lnq As MsLocationServerLinqDB = GetLocationInfo(MsLocationID)
                ret = ExportDatatableToExcel(dt, ExcelFileName, 0, lnq.LOCATION_NAME)
                lnq = Nothing
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = False
            CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    Private Shared Function GetDataTransactionLogReport(ReportDate As DateTime, MsLocationID As Long) As DataTable
        Dim ret As New DataTable
        Try
            Dim strDate As String = ReportDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim sql As String = "select * from v_transaction_log "
            sql += " where convert(varchar(8), isnull(collect_time,trans_start_time),112)=@_REPORT_DATE "
            sql += " and ms_location_id=@_LOCATION_ID "
            sql += " and deposit_status <> '0' "

            Dim p(2) As SqlParameter
            p(0) = ServerDB.SetText("@_REPORT_DATE", strDate)
            p(1) = ServerDB.SetBigInt("@_LOCATION_ID", MsLocationID)

            Dim DT As DataTable = ServerDB.ExecuteTable(sql, p)
            If DT.Rows.Count > 0 Then
                ret = Engine.ReportENG.BuiltReportTransactionReportExcelDataTable(ret, DT)

            Else
                CreateServerLogAgent("Transaction Log Report no data found on " & ReportDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US")))
            End If
            DT.Dispose()
        Catch ex As Exception
            ret = New DataTable
            CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try

        Return ret
    End Function

    Private Shared Function CalTransactionServiceTime(DepositPaidTime As DateTime, PickupTime As DateTime) As String
        Dim ret As String = ""
        Dim vHour As Integer = 0
        Dim ServiceSec As Integer = DateDiff(DateInterval.Second, DepositPaidTime, PickupTime)
        Dim HourDiff As Integer = Math.Ceiling(ServiceSec / 60 / 60)
        If HourDiff >= 24 Then
            Dim d As Integer = Math.Floor(HourDiff / 24)
            Dim h As Integer = HourDiff - (d * 24)
            vHour = h
            ret = d & " วัน " & h & " ชั่วโมง"
        Else
            vHour = HourDiff
            ret = vHour & " ชั่วโมง"
        End If

        Return ret
    End Function

#End Region


    Private Shared Function ExportDatatableToExcel(DT As DataTable, ByVal OutputFileName As String, RowNumberOfFooter As Integer, WorkSheetName As String) As Boolean
        Dim ret As Boolean = False
        If DT.Rows.Count > 0 Then
            Using ep As New ExcelPackage
                Dim ws As ExcelWorksheet = ep.Workbook.Worksheets.Add(WorkSheetName)

                ws.Cells("A1").LoadFromDataTable(DT, True)

                Using RowHeader As ExcelRange = ws.Cells(1, 1, 1, DT.Columns.Count)
                    RowHeader.Style.Font.Bold = True
                    RowHeader.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                    RowHeader.Style.Fill.BackgroundColor.SetColor(Color.Gray)
                    RowHeader.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
                    RowHeader.Style.Font.Color.SetColor(Color.Black)
                    'RowHeader.AutoFitColumns()
                End Using

                Using RowContent As ExcelRange = ws.Cells(2, 1, DT.Rows.Count + 1, DT.Columns.Count)
                    RowContent.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                    RowContent.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                    RowContent.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                    RowContent.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
                End Using

                For i As Integer = 0 To DT.Columns.Count - 1
                    Dim ColumType As String = DT.Columns(i).DataType.Name.ToLower
                    If ColumType = "datetime" Then
                        ws.Cells(2, i + 1, DT.Rows.Count + 1, i + 1).Style.Numberformat.Format = "mmm dd yyyy HH:MM:ss"
                        'ws.Cells(2, i + 1, DT.Rows.Count + 1, i + 1).AutoFitColumns()
                    End If
                Next

                ws.Cells(1, 1, DT.Rows.Count + 1, DT.Columns.Count).AutoFitColumns()

                If RowNumberOfFooter > 0 Then
                    Using RowFooter As ExcelRange = ws.Cells((DT.Rows.Count + 1) - (RowNumberOfFooter - 1), 1, DT.Rows.Count + 1, DT.Columns.Count)
                        RowFooter.Style.Font.Bold = True
                        'RowFooter.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                        'RowFooter.Style.Fill.BackgroundColor.SetColor(Color.Gray)
                        RowFooter.Style.Font.Color.SetColor(Color.Black)
                    End Using
                End If

                Dim f As New IO.FileInfo(OutputFileName)
                ep.SaveAs(f)
                Threading.Thread.Sleep(5000)

                If IO.File.Exists(f.FullName) = True Then
                    ret = True
                End If
                f = Nothing
            End Using
        End If
        Return ret
    End Function

    Private Shared Function GetLocationInfo(MsLocationID As Long) As MsLocationServerLinqDB
        Dim lnq As New MsLocationServerLinqDB
        Try
            lnq.GetDataByPK(MsLocationID, Nothing)
        Catch ex As Exception
            lnq = New MsLocationServerLinqDB
        End Try
        Return lnq
    End Function


    Private Enum ReportName
        TransactionLogReport = 1
        TransactionPerformanceReport = 2
        SummaryReportByLocation = 3
        SummaryReportByProduct = 4
    End Enum
End Class
