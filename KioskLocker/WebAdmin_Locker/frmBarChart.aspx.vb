Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Class frmBarChart
    Inherits System.Web.UI.Page
    Dim BL As New LockerBL
    Private Sub frmBarChart_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim UserName As String = Session("UserName")
        Dim LocationID As String = Request("LocationID")

        GenBar(UserName, LocationID)
    End Sub


    Private Sub GenBar(UserName As String, LocationID As Long)

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

        Dim dtt As New DataTable
        dtt.Columns.Add("TXN_HOUR")
        dtt.Columns.Add("trans_qty_DEPOSIT")
        dtt.Columns.Add("trans_qty_COLLECT")
        dtt.Columns.Add("trans_qty_LOST")

        Dim dr As DataRow
        Dim H As Integer = 22

        If DT.Rows.Count > 0 Then
            Dim tmp As DataTable = DT.DefaultView.ToTable

            For i As Integer = 6 To H
                dr = dtt.NewRow
                dr("TXN_HOUR") = i.ToString

                Dim obj As Object
                obj = tmp.Compute("sum(trans_qty)", "trans_type='DEPOSIT' and trans_status='SUCCESS' and TXN_HOUR='" & i & "'")
                If Not IsDBNull(obj) Then
                    dr("trans_qty_DEPOSIT") = CInt(obj)
                Else
                    dr("trans_qty_DEPOSIT") = 0
                End If

                obj = tmp.Compute("sum(trans_qty)", "trans_type='COLLECT' and trans_status='SUCCESS' and TXN_HOUR='" & i & "'")
                If Not IsDBNull(obj) Then
                    dr("trans_qty_COLLECT") = CInt(obj)
                Else
                    dr("trans_qty_COLLECT") = 0
                End If

                obj = tmp.Compute("sum(trans_qty)", "trans_status='LOST' and TXN_HOUR='" & i & "'")
                If Not IsDBNull(obj) Then
                    dr("trans_qty_LOST") = CInt(obj)
                Else
                    dr("trans_qty_LOST") = 0
                End If

                dtt.Rows.Add(dr)
            Next
        End If

        For i As Integer = 1 To dtt.Columns.Count - 1
            Dim series As New Series
            For Each dr2 As DataRow In dtt.Rows
                Dim y As Integer = CInt(dr2(i))
                series.Points.AddXY(dr2("TXN_HOUR").ToString(), y)
                series.IsValueShownAsLabel = True

                Dim LegendSeries As String = ""
                Select Case i.ToString
                    Case "1"
                        LegendSeries = "DEPOSIT"
                    Case "2"
                        LegendSeries = "COLLECT"
                    Case "3"
                        LegendSeries = "LOST"
                End Select
                series.Legend = "Legend1"
                series.Name = LegendSeries
            Next
            BarChart.Series.Add(series)
        Next

        BarChart.Series(0).Color = ColorTranslator.FromHtml("#36C3F2")
        BarChart.Series(1).Color = ColorTranslator.FromHtml("#000080")
        BarChart.Series(2).Color = ColorTranslator.FromHtml("#DD6777")


        BarChart.DataSource = dtt
        BarChart.DataBind()
    End Sub

End Class
