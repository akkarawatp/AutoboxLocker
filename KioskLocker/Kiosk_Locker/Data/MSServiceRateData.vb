Imports System.Data.SqlClient
Imports KioskLinqDB.ConnectDB

Namespace Data
    Public Class MSServiceRateData
        Dim _ServiceRateDepositList As New DataTable
        Dim _ServiceRateOvernightList As New DataTable
        Dim _ServiceRateHourList As New DataTable
        Dim _ServiceFineRateList As New DataTable

        Public ReadOnly Property ServiceRateDepositList As DataTable
            Get
                Return _ServiceRateDepositList
            End Get
        End Property

        Public ReadOnly Property ServiceRateOvernightList As DataTable
            Get
                Return _ServiceRateOvernightList
            End Get
        End Property

        Public ReadOnly Property ServiceRateHourList As DataTable
            Get
                Return _ServiceRateHourList
            End Get
        End Property
        Public ReadOnly Property ServiceFineRateList As DataTable
            Get
                Return _ServiceFineRateList
            End Get
        End Property

        Public Sub SetServiceRateData(MsKioskID As Long)
            Try
                Dim sql As String = "select srd.ms_cabinet_model_id, cm.model_name,0 service_hour, " & Environment.NewLine
                sql += " srd.deposit_rate service_rate, 'MS_SERVICE_RATE_DEPOSIT' data_group " & Environment.NewLine
                sql += " From MS_SERVICE_RATE sr " & Environment.NewLine
                sql += " inner join MS_SERVICE_RATE_DEPOSIT srd on sr.id=srd.ms_service_rate_id " & Environment.NewLine
                sql += " inner join MS_CABINET_MODEL cm On cm.id=srd.ms_cabinet_model_id " & Environment.NewLine
                sql += " where sr.ms_kiosk_id = @_KIOSK_ID " & Environment.NewLine
                sql += " union all " & Environment.NewLine

                sql += " select srh.ms_cabinet_model_id, cm.model_name, srh.service_hour, " & Environment.NewLine
                sql += " srh.service_rate, 'MS_SERVICE_RATE_HOUR' data_group " & Environment.NewLine
                sql += " from MS_SERVICE_RATE sr " & Environment.NewLine
                sql += " inner join MS_SERVICE_RATE_HOUR srh on sr.id=srh.ms_service_rate_id " & Environment.NewLine
                sql += " inner join MS_CABINET_MODEL cm On cm.id=srh.ms_cabinet_model_id " & Environment.NewLine
                sql += " where sr.ms_kiosk_id = @_KIOSK_ID " & Environment.NewLine
                sql += " union all " & Environment.NewLine

                sql += " select sro.ms_cabinet_model_id, cm.model_name, 0 service_hour, " & Environment.NewLine
                sql += " sro.service_rate_day, 'MS_SERVICE_RATE_OVERNIGHT' data_group " & Environment.NewLine
                sql += " From MS_SERVICE_RATE sr " & Environment.NewLine
                sql += " inner join MS_SERVICE_RATE_OVERNIGHT sro on sr.id=sro.ms_service_rate_id " & Environment.NewLine
                sql += " inner join MS_CABINET_MODEL cm On cm.id=sro.ms_cabinet_model_id " & Environment.NewLine
                sql += " where sr.ms_kiosk_id = @_KIOSK_ID " & Environment.NewLine
                sql += " union all" & Environment.NewLine

                sql += " select srf.ms_cabinet_model_id, cm.model_name, 0 service_hour, " & Environment.NewLine
                sql += " srf.fine_rate, 'MS_SERVICE_RATE_FINE' data_group " & Environment.NewLine
                sql += " From MS_SERVICE_RATE sr " & Environment.NewLine
                sql += " inner join MS_SERVICE_RATE_FINE srf on sr.id=srf.ms_service_rate_id " & Environment.NewLine
                sql += " inner join MS_CABINET_MODEL cm On cm.id=srf.ms_cabinet_model_id " & Environment.NewLine
                sql += " where sr.ms_kiosk_id = @_KIOSK_ID " & Environment.NewLine

                Dim pD(1) As SqlParameter
                pD(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)
                Dim dt As DataTable = KioskDB.ExecuteTable(sql, pD)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.RowFilter = "data_group='MS_SERVICE_RATE_DEPOSIT'"
                    If dt.DefaultView.Count > 0 Then
                        _ServiceRateDepositList = dt.DefaultView.ToTable.Copy
                    End If
                    dt.DefaultView.RowFilter = ""

                    dt.DefaultView.RowFilter = "data_group='MS_SERVICE_RATE_HOUR'"
                    If dt.DefaultView.Count > 0 Then
                        _ServiceRateHourList = dt.DefaultView.ToTable.Copy
                    End If
                    dt.DefaultView.RowFilter = ""

                    dt.DefaultView.RowFilter = "data_group='MS_SERVICE_RATE_OVERNIGHT'"
                    If dt.DefaultView.Count > 0 Then
                        _ServiceRateOvernightList = dt.DefaultView.ToTable.Copy
                    End If
                    dt.DefaultView.RowFilter = ""

                    dt.DefaultView.RowFilter = "data_group='MS_SERVICE_RATE_FINE'"
                    If dt.DefaultView.Count > 0 Then
                        _ServiceFineRateList = dt.DefaultView.ToTable.Copy
                    End If
                    dt.DefaultView.RowFilter = ""
                End If
                dt.Dispose()
            Catch ex As Exception
                _ServiceRateDepositList = New DataTable
                _ServiceRateHourList = New DataTable
                _ServiceRateOvernightList = New DataTable
            End Try
        End Sub
    End Class
End Namespace


