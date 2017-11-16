Imports KioskLinqDB.TABLE
Imports KioskLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports ServerLinqDB.ConnectDB

Public Class KioskInfoENG
    Private Shared _KioskID As String = ""
    Private Shared _LocationCode As String = ""
    Private Shared _LocationName As String = ""
    Private Shared _ComputerName As String = ""
    Private Shared _IpAddress As String = ""
    Private Shared _MacAddress As String = ""
    Private Shared _SyncTransactionMin As Integer = 0
    Private Shared _SyncMasterMin As Integer = 0
    Private Shared _SyncLogMin As Integer = 0


    Public Shared ReadOnly Property KioskID As String
        Get
            Return _KioskID.Trim
        End Get
    End Property

    Public Shared ReadOnly Property LocationCode As String
        Get
            Return _LocationCode.Trim
        End Get
    End Property

    Public Shared ReadOnly Property LocationName As String
        Get
            Return _LocationName.Trim
        End Get
    End Property
    Public Shared ReadOnly Property ComputerName As String
        Get
            Return _ComputerName.Trim
        End Get
    End Property

    Public Shared ReadOnly Property IpAddress As String
        Get
            Return _IpAddress.Trim
        End Get
    End Property

    Public Shared ReadOnly Property MacAddress As String
        Get
            Return _MacAddress.Trim
        End Get
    End Property
    Public Shared ReadOnly Property SyncTransactionMin As Integer
        Get
            Return _SyncTransactionMin
        End Get
    End Property
    Public Shared ReadOnly Property SyncMasterMin As Integer
        Get
            Return _SyncMasterMin
        End Get
    End Property
    Public Shared ReadOnly Property SyncLogMin As Integer
        Get
            Return _SyncLogMin
        End Get
    End Property

    Public Shared Sub SetKioskInfo()
        Try
            Dim lnq As New CfKioskSysconfigKioskLinqDB
            Dim dt As DataTable = lnq.GetDataList("", "", Nothing, Nothing)  'ใช้ข้อมูลจาก Row ที่ 1 เพื่อหา MS_KIOSK_ID
            If dt.Rows.Count > 0 Then
                _KioskID = dt.Rows(0)("ms_kiosk_id")
                _ComputerName = Environment.MachineName

                If _KioskID > 0 Then

                    Dim sql As String = " select k.id, l.location_code, l.location_name, k.ip_address, k.mac_address  "
                    sql += " from MS_KIOSK k "
                    sql += " inner join MS_LOCATION l on l.id=k.ms_location_id "
                    sql += " where k.id=@_KIOSK_ID"

                    Dim p(1) As System.Data.SqlClient.SqlParameter
                    p(0) = ServerDB.SetBigInt("@_KIOSK_ID", _KioskID)

                    Dim sDt As DataTable = ServerDB.ExecuteTable(sql, p)
                    If sDt.Rows.Count > 0 Then
                        _LocationCode = sDt.Rows(0)("location_code")
                        _LocationName = sDt.Rows(0)("location_name")
                        _IpAddress = sDt.Rows(0)("ip_address")
                        _MacAddress = sDt.Rows(0)("mac_address")
                    End If
                    sDt.Dispose()


                    'get Sync Sysconfig
                    Dim cfLnq As New CfKioskSysconfigKioskLinqDB
                    cfLnq.ChkDataByMS_KIOSK_ID(_KioskID, Nothing)
                    If cfLnq.ID > 0 Then
                        _SyncTransactionMin = cfLnq.INTERVAL_SYNC_TRANSACTION_MIN
                        _SyncMasterMin = cfLnq.INTERVAL_SYNC_MASTER_MIN
                        _SyncLogMin = cfLnq.INTERVAL_SYNC_LOG_MIN
                    Else
                        _SyncTransactionMin = 1
                        _SyncMasterMin = 10
                        _SyncLogMin = 1
                    End If

                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Function GetLockerSysconfig(MsKioskID As Long) As CfKioskSysconfigKioskLinqDB
        Dim lnq As New CfKioskSysconfigKioskLinqDB
        lnq.ChkDataByMS_KIOSK_ID(MsKioskID, Nothing)
        Return lnq
    End Function
End Class
