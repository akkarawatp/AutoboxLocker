Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports Engine.LogFileENG

Public Class ServerUpdateMonitorENG
    Public Shared Sub UpdateKioskOnlineStatus()
        Dim cfLnq As New CfServerSysconfigServerLinqDB
        cfLnq.GetDataByPK(1, Nothing)
        If cfLnq.ID > 0 Then
            Dim ws As New MonitorWebService.MonitorInfoWebService
            ws.Url = cfLnq.MONITOR_WEBSERVICE_URL
            ws.Timeout = 10000

            Dim kLnq As New MsKioskServerLinqDB
            Dim kDt As DataTable = kLnq.GetDataList("active_status='Y'", "", Nothing, Nothing)
            If kDt.Rows.Count > 0 Then
                For Each kDr As DataRow In kDt.Rows
                    Dim dt As DataTable = ws.GetMonitorComputerInfo(kDr("mac_address"))
                    If dt.Rows.Count > 0 Then
                        Dim dr As DataRow = dt.Rows(0)
                        kLnq = New MsKioskServerLinqDB
                        kLnq.GetDataByPK(kDr("id"), Nothing)
                        kLnq.ONLINE_STATUS = dr("online_status")
                        kLnq.TODAY_AVAILABLE = dr("today_available")
                        kLnq.CPU_USAGE = dr("cpupercent")
                        kLnq.RAM_USAGE = dr("rampercent")
                        kLnq.DISK_USAGE = dr("diskpercent")

                        Dim trans As New ServerTransactionDB
                        Dim ret As ExecuteDataInfo
                        If kLnq.ID > 0 Then
                            ret = kLnq.UpdateData(Environment.MachineName, trans.Trans)
                        Else
                            ret = kLnq.InsertData(Environment.MachineName, trans.Trans)
                        End If

                        If ret.IsSuccess = True Then
                            Dim kdLnq As New MsKioskDeviceServerLinqDB
                            kdLnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(Engine.ConstantENG.MS_DEVICE.NetworkConnection, kLnq.ID, trans.Trans)
                            If kdLnq.ID > 0 Then
                                Dim OldStatusId As Long = kdLnq.MS_DEVICE_STATUS_ID

                                kdLnq.MS_DEVICE_STATUS_ID = IIf(kLnq.ONLINE_STATUS = "Y", Engine.ConstantENG.DeviceStatus.Ready, Engine.ConstantENG.DeviceStatus.Disconnected)
                                If kdLnq.MS_DEVICE_STATUS_ID <> OldStatusId Then
                                    kdLnq.SYNC_TO_KIOSK = "N"
                                End If

                                ret = kdLnq.UpdateData(Environment.MachineName, trans.Trans)
                            End If
                            kdLnq = Nothing

                            If ret.IsSuccess = True Then
                                trans.CommitTransaction()
                            Else
                                trans.RollbackTransaction()
                                CreateServerLogAgent(ret.ErrorMessage & "KioskID=" & kLnq.ID)
                            End If
                        Else
                            trans.RollbackTransaction()
                            CreateServerLogAgent(ret.ErrorMessage & "KioskID=" & kLnq.ID)
                        End If

                        kLnq = Nothing
                    End If
                    dt.Dispose()
                Next
            End If
            kDt.Dispose()
            ws.Dispose()
        End If
        cfLnq = Nothing
    End Sub
End Class
