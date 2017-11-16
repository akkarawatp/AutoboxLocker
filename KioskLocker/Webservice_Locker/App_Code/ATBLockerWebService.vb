Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports Engine

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ATBLockerWebService
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function

    <WebMethod()>
    Public Function LoginTIT(vUserName As String, vPassword As String, ModuleName As String) As LoginReturnData
        Dim ret As New LoginReturnData
        Try
            ret = UserENG.LoginTIT(vUserName, vPassword, "ATB-Locker", ModuleName, HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.Browser.Browser, HttpContext.Current.Request.Browser.Version, HttpContext.Current.Request.Url.AbsoluteUri)
        Catch ex As Exception
            ret = New LoginReturnData
        End Try

        Return ret
    End Function

    <WebMethod()>
    Public Function SendKiskAlarm(MacAddress As String, LocationName As String, AlarmDt As DataTable) As String
        Dim ret As String = "false"
        Try
            Dim sLnq As New CfServerSysconfigServerLinqDB
            sLnq.GetDataByPK(1, Nothing)

            Dim ws As New TITAlarmWebService.ApplicationWebservice
            ws.Url = sLnq.ALARM_WEBSERVICE_URL 'ConfigurationManager.AppSettings("TITAdminWebService.TITWebService").ToString
            ws.Timeout = 100000

            Dim alDt As DataTable = GetMasterMonitoringAlarm()
            If alDt.Rows.Count > 0 Then
                ret = ws.SendDTAlarmOtherApp(MacAddress, alDt, AlarmDt, LocationName, "Left & Lug Service Info " & LocationName)
            End If
            alDt.Dispose()
        Catch ex As Exception
            ret = "false|Exception SendKioskAlarm " & ex.Message
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function KioskLoginStaffConsole(vUserName As String, vPassword As String, ModuleName As String, MsKioskID As String) As Engine.LoginReturnData
        Dim ret As New Engine.LoginReturnData
        Try
            Dim sLnq As New CfServerSysconfigServerLinqDB
            sLnq.GetDataByPK(1, Nothing)
            ret = Engine.UserENG.LoginTIT(vUserName, vPassword, "ATB-Locker", ModuleName, HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.Browser.Browser, HttpContext.Current.Request.Browser.Version, HttpContext.Current.Request.Url.AbsoluteUri)
            If ret.LoginStatus = True Then
                'ตรวจสอบว่า Kiosk หมดอายุแล้วหรือยัง
                Dim sql As String = "select k.valid_expire_date, l.location_name " & vbNewLine
                sql += " from ms_kiosk k " & vbNewLine
                sql += " inner join ms_location l on k.ms_location_id=l.id " & vbNewLine
                sql += " where k.id=@_KIOSK_ID"

                Dim p(1) As SqlParameter
                p(0) = ServerDB.SetBigInt("@_KIOSK_ID", MsKioskID)

                Dim dt As DataTable = ServerDB.ExecuteTable(sql, Nothing, p)
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)
                    Dim kValidExpireDate As DateTime = Convert.ToDateTime(dr("valid_expire_date"))
                    Dim kLocationName As String = dr("location_name")
                    If DateTime.Now.Date.AddDays(90) >= kValidExpireDate.Date Then
                        Dim ValidDay As Integer = DateDiff(DateInterval.Day, DateTime.Now.Date, kValidExpireDate.Date)
                        Dim strValidDate As String = kValidExpireDate.ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("th-TH"))

                        ret.LoginStatus = True
                        ret.ErrorMessage = "บริการ Server ของสาขา " & kLocationName & " กำลังจะหมดอายุในวันที่ " & strValidDate & "(" & ValidDay & " วัน) กรุณาต่ออายุ"
                    ElseIf DateTime.Now.Date > kValidExpireDate.Date Then
                        ret.LoginStatus = False
                        ret.ErrorMessage = "บริการ Server ของสาขา " & kLocationName & " สิ้นสุดการให้บริการแล้ว"
                    End If
                Else
                    ret.LoginStatus = False
                    ret.ErrorMessage = "Kiosk data not found"
                End If
                dt.Dispose()
            End If
        Catch ex As Exception
            ret = New LoginReturnData
            ret.LoginStatus = False
            ret.ErrorMessage = "ATBLockerWebService.LoginTIT Exception " & ex.Message & vbNewLine & ex.StackTrace
        End Try

        Return ret
    End Function

    <WebMethod()>
    Public Function GetKioskStaffConsoleAuthorize(Username As String, MsKioskID As Long) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select distinct rf.id,rf.ms_role_id,rf.ms_functional_id, rf.ms_authorization_id, f.ms_functional_zone_id, "
            sql += " r.role_name, f.functional_name, a.authorization_name"
            sql += " from ms_user_role ur "
            sql += " inner join ms_role r On r.id=ur.ms_role_id "
            sql += " inner join ms_role_functional rf on r.id=rf.ms_role_id "
            sql += " inner join ms_functional f On f.id=rf.ms_functional_id "
            sql += " inner join ms_authorization a on a.id=rf.ms_authorization_id "
            sql += " inner join ms_user_location ul On ur.username=ul.username "
            sql += " inner join ms_kiosk k on k.ms_location_id=ul.ms_location_id "
            sql += " where f.ms_functional_zone_id=5"
            sql += " and ul.username=@_USERNAME and k.id=@_KIOSK_ID"

            Dim p(2) As SqlParameter
            p(0) = ServerDB.SetText("@_USERNAME", Username)
            p(1) = ServerDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            ret = ServerDB.ExecuteTable(sql, p)

        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetKioskStaffConsoleAuthorize"
        Return ret
    End Function

    <WebMethod()>
    Public Function ReportKioskCurrentQty(KioskComName As String, KioskID As Integer, DeviceID As Long, CurrentQty As Integer) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New MsKioskDeviceServerLinqDB
            lnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(DeviceID, KioskID, Nothing)
            If lnq.ID > 0 Then
                lnq.CURRENT_QTY = CurrentQty

                Dim trans As New ServerTransactionDB
                Dim re As ExecuteDataInfo = lnq.UpdateData(KioskComName, trans.Trans)
                If re.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
                ret = re.IsSuccess
            End If
            lnq = Nothing
        Catch ex As Exception

        End Try
        Return ret
    End Function


#Region "Sync Data Webservice"
#Region "Pull Master Data"
    <WebMethod()>
    Public Function GetMasterAppScreen() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterAppScreen from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsAppScreenServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetMasterAppScreen"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetMasterAppStep() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterAppStep from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsAppStepServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing

        Catch ex As Exception
            dt = New DataTable
        End Try
        dt.TableName = "GetMasterAppStep"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetMasterKioskScreenControl() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterKioskScreenControl from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsKioskScreenControlServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetMasterKioskScreenControl"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetMasterKioskNotificationText() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterKioskNotificationText from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsKioskNotificationTextServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetMasterCabinetModel"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetMasterCabinetModel() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterCabinetModel from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsCabinetModelServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetMasterCabinetModel"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetMasterDeviceType() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterDeviceType from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsDeviceTypeServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetMasterDeviceType"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetMasterDeviceStatus() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterDeviceStatus from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsDeviceStatusServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetMasterDeviceStatus"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetMasterDevice() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterDevice from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsDeviceServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetMasterDevice"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetMasterMonitoringAlarm() As DataTable
        Dim dt As DataTable
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetMasterMonitoringAlarm from " & HttpContext.Current.Request.UserHostAddress)

            Dim lnq As New MsMasterMonitoringAlarmServerLinqDB
            dt = lnq.GetDataList("", "", Nothing, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetMasterMonitoringAlarm"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetLockerServiceRate(MsKioskID As Long) As MasterServiceRateData
        Dim sr As New MasterServiceRateData
        Try
            Engine.LogFileENG.CreateServerLogAgent("GetLockerServiceRate from " & HttpContext.Current.Request.UserHostAddress)

            'Find MS_SERVICE_RATE data
            Dim sql As String = "Select sr.id "
            sql += " from MS_SERVICE_RATE sr "
            sql += " inner join MS_LOCATION l On l.id=sr.ms_location_id "
            sql += " inner join MS_KIOSK k On l.id=k.ms_location_id "
            sql += " where k.id=@_KIOSK_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            sr.ServiceRate = ServerDB.ExecuteTable(sql, p)
            sr.ServiceRate.TableName = "ServiceRate"
            If sr.ServiceRate.Rows.Count > 0 Then
                Dim drID As Long = sr.ServiceRate.Rows(0)("id")

                sql = "Select id,ms_cabinet_model_id,deposit_rate "
                sql += " From MS_SERVICE_RATE_DEPOSIT"
                sql += " where ms_service_rate_id=@_SERVICE_RATE_ID"
                ReDim p(1)
                p(0) = ServerDB.SetBigInt("@_SERVICE_RATE_ID", drID)
                sr.ServiceRateDeposit = ServerDB.ExecuteTable(sql, p)
                sr.ServiceRateDeposit.TableName = "ServiceRateDeposit"


                sql = "Select id,ms_cabinet_model_id,service_hour,service_rate "
                sql += " From MS_SERVICE_RATE_HOUR"
                sql += " where ms_service_rate_id=@_SERVICE_RATE_ID"
                ReDim p(1)
                p(0) = ServerDB.SetBigInt("@_SERVICE_RATE_ID", drID)
                sr.ServiceRateHour = ServerDB.ExecuteTable(sql, p)
                sr.ServiceRateHour.TableName = "ServiceRateHour"


                sql = "Select id,ms_cabinet_model_id,service_rate_day"
                sql += " From MS_SERVICE_RATE_OVERNIGHT"
                sql += " where ms_service_rate_id=@_SERVICE_RATE_ID"
                ReDim p(1)
                p(0) = ServerDB.SetBigInt("@_SERVICE_RATE_ID", drID)
                sr.ServiceRateOverNight = ServerDB.ExecuteTable(sql, p)
                sr.ServiceRateOverNight.TableName = "ServiceRateOverNight"
            End If
        Catch ex As Exception
            sr = New MasterServiceRateData
        End Try

        Return sr
    End Function
#End Region

#Region "Sync Master Kiosk to Server"
    <WebMethod()>
    Public Function SyncKioskSysconfig(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncKioskSysconfig from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New CfKioskSysconfigServerLinqDB
                    sLnq.ChkDataByMS_KIOSK_ID(dr("ms_kiosk_id"), sTrans.Trans)
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    sLnq.MAC_ADDRESS = dr("MAC_ADDRESS")
                    sLnq.IP_ADDRESS = dr("IP_ADDRESS")
                    sLnq.LOCATION_CODE = dr("LOCATION_CODE")
                    sLnq.LOCATION_NAME = dr("LOCATION_NAME")
                    sLnq.LOGIN_SSO = dr("LOGIN_SSO")
                    sLnq.KIOSK_OPEN_TIME = dr("KIOSK_OPEN_TIME")
                    sLnq.KIOSK_OPEN24 = dr("KIOSK_OPEN24")
                    sLnq.SCREEN_SAVER_SEC = dr("SCREEN_SAVER_SEC")
                    sLnq.TIME_OUT_SEC = dr("TIME_OUT_SEC")
                    sLnq.SHOW_MSG_SEC = dr("SHOW_MSG_SEC")
                    sLnq.PAYMENT_EXTEND_SEC = dr("PAYMENT_EXTEND_SEC")
                    sLnq.CARD_EXPIRE_MONTH = dr("CARD_EXPIRE_MONTH")
                    sLnq.PASSPORT_EXPIRE_MONTH = dr("PASSPORT_EXPIRE_MONTH")
                    sLnq.LOCKER_WEBSERVICE_URL = dr("LOCKER_WEBSERVICE_URL")
                    sLnq.LOCKER_PC_POSITION = dr("LOCKER_PC_POSITION")
                    sLnq.SLEEP_TIME = dr("SLEEP_TIME")
                    sLnq.SLEEP_DURATION = dr("SLEEP_DURATION")
                    sLnq.CONTACT_CENTER_TELNO = dr("CONTACT_CENTER_TELNO")
                    sLnq.ALARM_WEBSERVICE_URL = dr("ALARM_WEBSERVICE_URL")
                    sLnq.INTERVAL_SYNC_TRANSACTION_MIN = dr("INTERVAL_SYNC_TRANSACTION_MIN")
                    sLnq.INTERVAL_SYNC_LOG_MIN = dr("INTERVAL_SYNC_LOG_MIN")
                    sLnq.INTERVAL_SYNC_MASTER_MIN = dr("INTERVAL_SYNC_MASTER_MIN")
                    sLnq.SYNC_TO_SERVER = "Y"

                    If sLnq.ID > 0 Then
                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                    Else
                        sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    End If

                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                    sLnq = Nothing
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"

                    Engine.LogFileENG.CreateServerLogAgent("SyncKioskSysconfig from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function


    <WebMethod()>
    Public Function SyncMasterKioskCabinet(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncMasterKioskCabinet from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sRet As New ExecuteDataInfo
                Dim sTrans As New ServerTransactionDB
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New MsCabinetServerLinqDB
                    sLnq.GetDataByPK(dr("MS_CABINET_ID"), sTrans.Trans)
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    sLnq.CABINET_NO = dr("CABINET_NO")
                    sLnq.ORDER_LAYOUT = dr("ORDER_LAYOUT")
                    sLnq.MS_CABINET_MODEL_ID = dr("MS_CABINET_MODEL_ID")
                    sLnq.SERVICE_RATE_HOUR = dr("SERVICE_RATE_HOUR")
                    sLnq.SERVICE_RATE_LIMIT_DAY = dr("SERVICE_RATE_LIMIT_DAY")
                    sLnq.DEPOSIT_AMT = dr("DEPOSIT_AMT")
                    sLnq.ACTIVE_STATUS = dr("ACTIVE_STATUS")
                    sLnq.SYNC_TO_SERVER = "Y"

                    If sLnq.ID > 0 Then
                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                    Else
                        sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    End If

                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                    sLnq = Nothing
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"

                    Engine.LogFileENG.CreateServerLogAgent("SyncMasterKioskCabinet from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function SyncMasterKioskDevice(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncMasterKioskDevice from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sRe As New ExecuteDataInfo
                Dim sTrans As New ServerTransactionDB
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New MsKioskDeviceServerLinqDB
                    sLnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(dr("MS_DEVICE_ID"), dr("ms_kiosk_id"), sTrans.Trans)
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    sLnq.MS_DEVICE_ID = dr("MS_DEVICE_ID")

                    '############## ข้อมูล MAX_QTY, WARNING_QTY, CRITICAL_QTY ไม่ต้อง Sync จากตู้มาหา Server #################
                    'If Convert.IsDBNull(dr("MAX_QTY")) = False Then sLnq.MAX_QTY = dr("MAX_QTY")
                    'If Convert.IsDBNull(dr("WARNING_QTY")) = False Then sLnq.WARNING_QTY = dr("WARNING_QTY")
                    'If Convert.IsDBNull(dr("CRITICAL_QTY")) = False Then sLnq.CRITICAL_QTY = dr("CRITICAL_QTY")
                    If Convert.IsDBNull(dr("CURRENT_QTY")) = False Then sLnq.CURRENT_QTY = dr("CURRENT_QTY")
                    If Convert.IsDBNull(dr("CURRENT_MONEY")) = False Then sLnq.CURRENT_MONEY = Convert.ToInt64(dr("CURRENT_MONEY"))
                    sLnq.MS_DEVICE_STATUS_ID = dr("MS_DEVICE_STATUS_ID")
                    If Convert.IsDBNull(dr("COMPORT_VID")) = False Then sLnq.COMPORT_VID = dr("COMPORT_VID")
                    If Convert.IsDBNull(dr("DRIVER_NAME1")) = False Then sLnq.DRIVER_NAME1 = dr("DRIVER_NAME1")
                    If Convert.IsDBNull(dr("DRIVER_NAME2")) = False Then sLnq.DRIVER_NAME2 = dr("DRIVER_NAME2")
                    sLnq.SYNC_TO_SERVER = "Y"

                    If sLnq.ID > 0 Then
                        sRe = sLnq.UpdateData(KioskName, sTrans.Trans)
                    Else
                        sRe = sLnq.InsertData(KioskName, sTrans.Trans)
                    End If
                    If sRe.IsSuccess = False Then
                        Exit For
                    End If
                    sLnq = Nothing
                Next
                If sRe.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("SyncMasterKioskDevice from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRe.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try

        Return ret
    End Function

    <WebMethod()>
    Public Function SyncMasterKioskLocker(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncMasterKioskLocker from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count Then
                Dim sRet As New ExecuteDataInfo
                Dim sTrans As New ServerTransactionDB

                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New MsLockerServerLinqDB
                    sLnq.GetDataByPK(dr("MS_LOCKER_ID"), sTrans.Trans)
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    sLnq.LOCKER_NAME = dr("LOCKER_NAME")
                    If Convert.IsDBNull(dr("LAYOUT_NAME")) = False Then sLnq.LAYOUT_NAME = dr("LAYOUT_NAME")
                    sLnq.MS_CABINET_ID = dr("MS_CABINET_ID")
                    sLnq.MODEL_NAME = dr("MODEL_NAME")
                    sLnq.PIN_SOLENOID = dr("PIN_SOLENOID")
                    sLnq.PIN_LED = dr("PIN_LED")
                    sLnq.PIN_SENSOR = dr("PIN_SENSOR")
                    sLnq.OPEN_CLOSE_STATUS = dr("OPEN_CLOSE_STATUS")
                    sLnq.CURRENT_AVAILABLE = dr("CURRENT_AVAILABLE")
                    sLnq.ACTIVE_STATUS = dr("ACTIVE_STATUS")
                    sLnq.SYNC_TO_SERVER = "Y"

                    If sLnq.ID > 0 Then
                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                    Else
                        sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    End If

                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                    sLnq = Nothing
                Next
                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"

                    Engine.LogFileENG.CreateServerLogAgent("SyncMasterKioskLocker from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

#End Region

#Region "Get Master Sync To Kiosk"
    <WebMethod()>
    Public Function GetServerKioskSysconfig(MsKioskID As Long) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select *"
            sql += " from CF_KIOSK_SYSCONFIG "
            sql += " where sync_to_kiosk='N'"
            sql += " and ms_kiosk_id=@_KIOSK_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            dt = ServerDB.ExecuteTable(sql, p)
            Engine.LogFileENG.CreateServerLogAgent("GetServerKioskSysconfig from KioskID " & MsKioskID & " " & dt.Rows.Count & " Records")
        Catch ex As Exception
            dt = New DataTable
        End Try

        dt.TableName = "GetServerSyncKioskSysconfig"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetServerKioskCabinet(MsKioskID As Long) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = " select * "
            sql += " from MS_CABINET c"
            sql += " where sync_to_kiosk='N'"
            sql += " and ms_kiosk_id=@_KIOSK_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            dt = ServerDB.ExecuteTable(sql, p)
            Engine.LogFileENG.CreateServerLogAgent("GetServerKioskCabinet from KioskID " & MsKioskID & " " & dt.Rows.Count & " Records")
        Catch ex As Exception
            dt = New DataTable
        End Try
        dt.TableName = "GetServerSyncKioskCabinet"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetServeKioskDevice(MsKioskID As Long) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select * "
            sql += " from ms_kiosk_device "
            sql += " where sync_to_kiosk='N'"
            sql += " and ms_kiosk_id=@_KIOSK_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            dt = ServerDB.ExecuteTable(sql, p)
            Engine.LogFileENG.CreateServerLogAgent("GetServeKioskDevice from KioskID " & MsKioskID & " " & dt.Rows.Count & " Records")
        Catch ex As Exception
            dt = New DataTable
        End Try
        dt.TableName = "GetServerSyncKioskDevice"
        Return dt
    End Function

    <WebMethod()>
    Public Function GetServerKioskLocker(MsKioskID As Long) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = " select * "
            sql += " from ms_locker "
            sql += " where sync_to_kiosk='N'"
            sql += " and ms_kiosk_id=@_KIOSK_ID"

            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_KIOSK_ID", MsKioskID)
            dt = ServerDB.ExecuteTable(sql, p)
            Engine.LogFileENG.CreateServerLogAgent("GetServerKioskLocker from KioskID " & MsKioskID & " " & dt.Rows.Count & " Records")
        Catch ex As Exception
            dt = New DataTable
        End Try
        dt.TableName = "GetServerSyncKioskLocker"
        Return dt
    End Function
#End Region

#Region "Update Server Sync to Kiosk"
    <WebMethod()>
    Public Function UpdateServerSyncKioskSysconfig(dt As DataTable, KioskName As String) As String
        Dim ret As String = ""
        Try
            Engine.LogFileENG.CreateServerLogAgent("UpdateServerSyncKioskSysconfig from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New CfKioskSysconfigServerLinqDB
                    sLnq.GetDataByPK(dr("id"), sTrans.Trans)
                    If sLnq.ID > 0 Then
                        sLnq.SYNC_TO_KIOSK = "Y"

                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                        If sRet.IsSuccess = False Then
                            Exit For
                        End If
                    End If
                    sLnq = Nothing
                Next
                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"

                    Engine.LogFileENG.CreateServerLogAgent("UpdateServerSyncKioskSysconfig from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function UpdateServerSyncKioskCabinet(dt As DataTable, KioskName As String) As String
        Dim ret As String = ""
        Try
            Engine.LogFileENG.CreateServerLogAgent("UpdateServerSyncKioskCabinet from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New MsCabinetServerLinqDB
                    sLnq.GetDataByPK(dr("id"), sTrans.Trans)
                    If sLnq.ID > 0 Then
                        sLnq.SYNC_TO_KIOSK = "Y"

                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                        If sRet.IsSuccess = False Then
                            Exit For
                        End If
                    End If
                    sLnq = Nothing
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("UpdateServerSyncKioskCabinet from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function UpdateServerSyncKioskDevice(dt As DataTable, KioskName As String) As String
        Dim ret As String = ""
        Try
            Engine.LogFileENG.CreateServerLogAgent("UpdateServerSyncKioskDevice from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New MsKioskDeviceServerLinqDB
                    sLnq.GetDataByPK(dr("id"), sTrans.Trans)
                    If sLnq.ID > 0 Then
                        sLnq.SYNC_TO_KIOSK = "Y"

                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                        If sRet.IsSuccess = False Then
                            Exit For
                        End If
                    End If
                    sLnq = Nothing
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("UpdateServerSyncKioskDevice from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function UpdateSyncKioskLocker(dt As DataTable, KioskName As String) As String
        Dim ret As String = ""
        Try
            Engine.LogFileENG.CreateServerLogAgent("UpdateSyncKioskLocker from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New MsLockerServerLinqDB
                    sLnq.GetDataByPK(dr("id"), sTrans.Trans)
                    If sLnq.ID > 0 Then
                        sLnq.SYNC_TO_KIOSK = "Y"

                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                        If sRet.IsSuccess = False Then
                            Exit For
                        End If
                    End If
                    sLnq = Nothing
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"

                    Engine.LogFileENG.CreateServerLogAgent("UpdateSyncKioskLocker from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region

#Region "Sync Transaction Data"
    <WebMethod()>
    Public Function SysnKioskTransactionCustomerImage(KioskName As String, TransNo As String, CustImage As Byte()) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SysnKioskTransactionCustomerImage " & KioskName)

            Dim sTrans As New ServerTransactionDB
            Dim sRet As New ExecuteDataInfo
            Dim sLnq As New TbServiceTransactionServerLinqDB
            sLnq.ChkDataByTRANS_NO(TransNo, sTrans.Trans)
            If sLnq.ID > 0 Then
                sLnq.CUST_IMAGE = CustImage

                sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
            End If

            If sRet.IsSuccess = True Then
                sTrans.CommitTransaction()
                ret = "true"
                Engine.LogFileENG.CreateServerLogAgent("SysnKioskTransactionCustomerImage from " & KioskName & " TransactionNo " & TransNo)
            Else
                sTrans.RollbackTransaction()
                ret = "false|" & sRet.ErrorMessage
                Engine.LogFileENG.CreateServerErrorLogAgent(ret)
            End If

            sLnq = Nothing
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try

        Return ret
    End Function

    <WebMethod()>
    Public Function SyncKioskServiceTransactionByRecord(KioskName As String, TransNo As String, TransStartTime As DateTime, TransEndTime As DateTime, MsKioskID As Long, ServerLockerID As Long,
                                                PassportNo As String, IDCardNo As String, NationCode As String, FirstName As String, LastName As String, Gender As String,
                                                BirthDate As DateTime, PassportExpireDate As DateTime, IDCardExpireDate As DateTime,
                                                ServiceRate As Double, ServiceRateLimitDay As Double, DepositAmt As Double, PaidTime As DateTime,
                                                ReceiveCoin1 As Long, ReceiveCoin2 As Long, ReceiveCoin5 As Long, ReceiveCoin10 As Long, ReceiveBanknote20 As Long, ReceiveBanknote50 As Long, ReceiveBanknote100 As Long, ReceiveBanknote500 As Long, ReceiveBanknote1000 As Long,
                                                ChangeCoin1 As Long, ChangeCoin2 As Long, ChangeCoin5 As Long, ChangeCoin10 As Long, ChangeBankNote20 As Long, ChangeBanknote50 As Long, ChangeBanknote100 As Long, ChangeBanknote500 As Long,
                                                TransStatus As String, MsAppScreenID As Long, MsAppStepID As Long) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncKioskServiceTransaction By Record from " & KioskName)

            Dim sTrans As New ServerLinqDB.ConnectDB.ServerTransactionDB
            Dim sRet As New ExecuteDataInfo

            Dim sLnq As New TbServiceTransactionServerLinqDB
            sLnq.ChkDataByTRANS_NO(TransNo, sTrans.Trans)
            sLnq.TRANS_NO = TransNo
            sLnq.TRANS_START_TIME = TransStartTime
            If TransEndTime.Year <> 1 Then sLnq.TRANS_END_TIME = Convert.ToDateTime(TransEndTime)
            sLnq.MS_KIOSK_ID = MsKioskID
            If ServerLockerID > 0 Then sLnq.MS_LOCKER_ID = ServerLockerID

            If PassportNo.Trim <> "" Then sLnq.PASSPORT_NO = PassportNo
            If IDCardNo.Trim <> "" Then sLnq.IDCARD_NO = IDCardNo
            If NationCode.Trim <> "" Then sLnq.NATION_CODE = NationCode
            If FirstName.Trim <> "" Then sLnq.FIRST_NAME = FirstName
            If LastName.Trim <> "" Then sLnq.LAST_NAME = LastName
            If Gender.Trim <> "" Then sLnq.GENDER = Gender
            If BirthDate.Year <> 1 Then sLnq.BIRTH_DATE = BirthDate
            If PassportExpireDate.Year <> 1 Then sLnq.PASSPORT_EXPIRE_DATE = PassportExpireDate
            If IDCardExpireDate.Year <> 1 Then sLnq.IDCARD_EXPIRE_DATE = IDCardExpireDate
            'If CustImage IsNot Nothing Then sLnq.CUST_IMAGE = CustImage
            sLnq.SERVICE_RATE = ServiceRate
            sLnq.SERVICE_RATE_LIMIT_DAY = ServiceRateLimitDay
            sLnq.DEPOSIT_AMT = DepositAmt
            If PaidTime.Year <> 1 Then sLnq.PAID_TIME = PaidTime
            sLnq.RECEIVE_COIN1 = ReceiveCoin1
            sLnq.RECEIVE_COIN2 = ReceiveCoin2
            sLnq.RECEIVE_COIN5 = ReceiveCoin5
            sLnq.RECEIVE_COIN10 = ReceiveCoin10
            sLnq.RECEIVE_BANKNOTE20 = ReceiveBanknote20
            sLnq.RECEIVE_BANKNOTE50 = ReceiveBanknote50
            sLnq.RECEIVE_BANKNOTE100 = ReceiveBanknote100
            sLnq.RECEIVE_BANKNOTE500 = ReceiveBanknote500
            sLnq.RECEIVE_BANKNOTE1000 = ReceiveBanknote1000
            sLnq.CHANGE_COIN1 = ChangeCoin1
            sLnq.CHANGE_COIN2 = ChangeCoin2
            sLnq.CHANGE_COIN5 = ChangeCoin5
            sLnq.CHANGE_COIN10 = ChangeCoin10
            sLnq.CHANGE_BANKNOTE20 = ChangeBankNote20
            sLnq.CHANGE_BANKNOTE50 = ChangeBanknote50
            sLnq.CHANGE_BANKNOTE100 = ChangeBanknote100
            sLnq.CHANGE_BANKNOTE500 = ChangeBanknote500
            sLnq.TRANS_STATUS = TransStatus
            If MsAppScreenID > 0 Then sLnq.MS_APP_SCREEN_ID = MsAppScreenID
            If MsAppStepID > 0 Then sLnq.MS_APP_STEP_ID = MsAppStepID
            sLnq.SYNC_TO_SERVER = "Y"

            If sLnq.ID > 0 Then
                sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
            Else
                sRet = sLnq.InsertData(KioskName, sTrans.Trans)
            End If

            If sRet.IsSuccess = True Then
                sTrans.CommitTransaction()
                ret = "true"
                Engine.LogFileENG.CreateServerLogAgent("SyncKioskServiceTransactionByRecord from " & KioskName & " TransactionNo " & TransNo)
            Else
                sTrans.RollbackTransaction()
                ret = "false|" & sRet.ErrorMessage
                Engine.LogFileENG.CreateServerErrorLogAgent(ret)
            End If

        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try

        Return ret
    End Function


    <WebMethod()>
    Public Function SyncKioskServiceTransaction(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncKioskServiceTransaction from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerLinqDB.ConnectDB.ServerTransactionDB
                Dim sRet As New ExecuteDataInfo

                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New TbServiceTransactionServerLinqDB
                    sLnq.ChkDataByTRANS_NO(dr("TRANS_NO"), sTrans.Trans)
                    sLnq.TRANS_NO = dr("TRANS_NO")
                    sLnq.TRANS_START_TIME = Convert.ToDateTime(dr("TRANS_START_TIME"))
                    If Convert.IsDBNull(dr("TRANS_END_TIME")) = False Then sLnq.TRANS_END_TIME = Convert.ToDateTime(dr("TRANS_END_TIME"))
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    If Convert.IsDBNull(dr("locker_name")) = False Then
                        sLnq.MS_LOCKER_ID = GetServerLockerID(dr("ms_kiosk_id"), dr("locker_name"), sTrans.Trans)
                    End If

                    If Convert.IsDBNull(dr("PASSPORT_NO")) = False Then sLnq.PASSPORT_NO = dr("PASSPORT_NO")
                    If Convert.IsDBNull(dr("IDCARD_NO")) = False Then sLnq.IDCARD_NO = dr("IDCARD_NO")
                    If Convert.IsDBNull(dr("NATION_CODE")) = False Then sLnq.NATION_CODE = dr("NATION_CODE")
                    If Convert.IsDBNull(dr("FIRST_NAME")) = False Then sLnq.FIRST_NAME = dr("FIRST_NAME")
                    If Convert.IsDBNull(dr("LAST_NAME")) = False Then sLnq.LAST_NAME = dr("LAST_NAME")
                    If Convert.IsDBNull(dr("GENDER")) = False Then sLnq.GENDER = Convert.ToString(Chr(dr("GENDER")))
                    If Convert.IsDBNull(dr("BIRTH_DATE")) = False Then sLnq.BIRTH_DATE = Convert.ToDateTime(dr("BIRTH_DATE"))
                    If Convert.IsDBNull(dr("PASSPORT_EXPIRE_DATE")) = False Then sLnq.PASSPORT_EXPIRE_DATE = Convert.ToDateTime(dr("PASSPORT_EXPIRE_DATE"))
                    If Convert.IsDBNull(dr("IDCARD_EXPIRE_DATE")) = False Then sLnq.IDCARD_EXPIRE_DATE = Convert.ToDateTime(dr("IDCARD_EXPIRE_DATE"))
                    If Convert.IsDBNull(dr("cust_image")) = False Then sLnq.CUST_IMAGE = CType(dr("cust_image"), Byte())
                    sLnq.SERVICE_RATE = dr("SERVICE_RATE")
                    sLnq.SERVICE_RATE_LIMIT_DAY = dr("SERVICE_RATE_LIMIT_DAY")
                    sLnq.DEPOSIT_AMT = dr("DEPOSIT_AMT")
                    If Convert.IsDBNull(dr("PAID_TIME")) = False Then sLnq.PAID_TIME = dr("PAID_TIME")
                    sLnq.RECEIVE_COIN1 = dr("RECEIVE_COIN1")
                    sLnq.RECEIVE_COIN2 = dr("RECEIVE_COIN2")
                    sLnq.RECEIVE_COIN5 = dr("RECEIVE_COIN5")
                    sLnq.RECEIVE_COIN10 = dr("RECEIVE_COIN10")
                    sLnq.RECEIVE_BANKNOTE20 = dr("RECEIVE_BANKNOTE20")
                    sLnq.RECEIVE_BANKNOTE50 = dr("RECEIVE_BANKNOTE50")
                    sLnq.RECEIVE_BANKNOTE100 = dr("RECEIVE_BANKNOTE100")
                    sLnq.RECEIVE_BANKNOTE500 = dr("RECEIVE_BANKNOTE500")
                    sLnq.RECEIVE_BANKNOTE1000 = dr("RECEIVE_BANKNOTE1000")
                    sLnq.CHANGE_COIN1 = dr("CHANGE_COIN1")
                    sLnq.CHANGE_COIN2 = dr("CHANGE_COIN2")
                    sLnq.CHANGE_COIN5 = dr("CHANGE_COIN5")
                    sLnq.CHANGE_COIN10 = dr("CHANGE_COIN10")
                    sLnq.CHANGE_BANKNOTE20 = dr("CHANGE_BANKNOTE20")
                    sLnq.CHANGE_BANKNOTE50 = dr("CHANGE_BANKNOTE50")
                    sLnq.CHANGE_BANKNOTE100 = dr("CHANGE_BANKNOTE100")
                    sLnq.CHANGE_BANKNOTE500 = dr("CHANGE_BANKNOTE500")
                    sLnq.TRANS_STATUS = dr("TRANS_STATUS")
                    If Convert.IsDBNull(dr("MS_APP_SCREEN_ID")) = False Then sLnq.MS_APP_SCREEN_ID = dr("MS_APP_SCREEN_ID")
                    If Convert.IsDBNull(dr("MS_APP_STEP_ID")) = False Then sLnq.MS_APP_STEP_ID = dr("MS_APP_STEP_ID")
                    sLnq.SYNC_TO_SERVER = "Y"

                    If sLnq.ID > 0 Then
                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                    Else
                        sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    End If

                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("SyncKioskServiceTransaction from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try

        Return ret
    End Function

    <WebMethod()>
    Public Function SyncKioskCollectTransaction(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncKioskCollectTransaction from " & KioskName & " " & dt.Rows.Count & " Records")
            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerLinqDB.ConnectDB.ServerTransactionDB
                Dim sRet As New ExecuteDataInfo

                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New TbPickupTransactionServerLinqDB
                    sLnq.ChkDataByTRANSACTION_NO(dr("TRANSACTION_NO"), sTrans.Trans)

                    sLnq.TRANSACTION_NO = dr("TRANSACTION_NO")
                    If Convert.IsDBNull(dr("TRANS_START_TIME")) = False Then sLnq.TRANS_START_TIME = Convert.ToDateTime(dr("TRANS_START_TIME"))
                    If Convert.IsDBNull(dr("TRANS_END_TIME")) = False Then sLnq.TRANS_END_TIME = Convert.ToDateTime(dr("TRANS_END_TIME"))
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    If Convert.IsDBNull(dr("locker_name")) = False Then
                        sLnq.MS_LOCKER_ID = GetServerLockerID(dr("ms_kiosk_id"), dr("locker_name"), sTrans.Trans)
                    End If
                    If Convert.IsDBNull(dr("deposit_trans_no")) = False Then
                        sLnq.DEPOSIT_TRANS_NO = dr("deposit_trans_no")
                    End If
                    If Convert.IsDBNull(dr("LOST_QR_CODE")) = False Then sLnq.LOST_QR_CODE = Convert.ToString(dr("LOST_QR_CODE"))
                    sLnq.SERVICE_AMT = dr("SERVICE_AMT")
                    If Convert.IsDBNull(dr("PICKUP_TIME")) = False Then sLnq.PICKUP_TIME = Convert.ToDateTime(dr("PICKUP_TIME"))
                    If Convert.IsDBNull(dr("PAID_TIME")) = False Then sLnq.PAID_TIME = Convert.ToDateTime(dr("PAID_TIME"))
                    sLnq.RECEIVE_COIN1 = dr("RECEIVE_COIN1")
                    sLnq.RECEIVE_COIN2 = dr("RECEIVE_COIN2")
                    sLnq.RECEIVE_COIN5 = dr("RECEIVE_COIN5")
                    sLnq.RECEIVE_COIN10 = dr("RECEIVE_COIN10")
                    sLnq.RECEIVE_BANKNOTE20 = dr("RECEIVE_BANKNOTE20")
                    sLnq.RECEIVE_BANKNOTE50 = dr("RECEIVE_BANKNOTE50")
                    sLnq.RECEIVE_BANKNOTE100 = dr("RECEIVE_BANKNOTE100")
                    sLnq.RECEIVE_BANKNOTE500 = dr("RECEIVE_BANKNOTE500")
                    sLnq.RECEIVE_BANKNOTE1000 = dr("RECEIVE_BANKNOTE1000")
                    sLnq.CHANGE_COIN1 = dr("CHANGE_COIN1")
                    sLnq.CHANGE_COIN2 = dr("CHANGE_COIN2")
                    sLnq.CHANGE_COIN5 = dr("CHANGE_COIN5")
                    sLnq.CHANGE_COIN10 = dr("CHANGE_COIN10")
                    sLnq.CHANGE_BANKNOTE20 = dr("CHANGE_BANKNOTE20")
                    sLnq.CHANGE_BANKNOTE50 = dr("CHANGE_BANKNOTE50")
                    sLnq.CHANGE_BANKNOTE100 = dr("CHANGE_BANKNOTE100")
                    sLnq.CHANGE_BANKNOTE500 = dr("CHANGE_BANKNOTE500")
                    sLnq.TRANS_STATUS = dr("TRANS_STATUS")
                    If Convert.IsDBNull(dr("MS_APP_SCREEN_ID")) = False Then sLnq.MS_APP_SCREEN_ID = dr("MS_APP_SCREEN_ID")
                    If Convert.IsDBNull(dr("MS_APP_STEP_ID")) = False Then sLnq.MS_APP_STEP_ID = dr("MS_APP_STEP_ID")
                    sLnq.SYNC_TO_SERVER = "Y"

                    If sLnq.ID > 0 Then
                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                    Else
                        sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    End If
                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("SyncKioskCollectTransaction from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    Private Function GetServerLockerID(MsKioskID As Long, LockerName As String, trans As SqlTransaction) As Long
        Dim ret As Long = 0
        Try
            Dim lnq As New MsLockerServerLinqDB
            lnq.ChkDataByLOCKER_NAME_MS_KIOSK_ID(LockerName, MsKioskID, trans)
            ret = lnq.ID
            lnq = Nothing
        Catch ex As Exception
            ret = 0
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function SyncKioskStaffConsoleTransaction(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncKioskStaffConsoleTransaction from " & KioskName & " " & dt.Rows.Count & " Records")

            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New TbStaffConsoleTransactionServerLinqDB
                    sLnq.ChkDataByTRANS_NO(dr("TRANS_NO"), sTrans.Trans)

                    sLnq.TRANS_NO = dr("TRANS_NO")
                    sLnq.TRANS_START_TIME = Convert.ToDateTime(dr("TRANS_START_TIME"))
                    If Convert.IsDBNull(dr("TRANS_END_TIME")) = False Then sLnq.TRANS_END_TIME = Convert.ToDateTime(dr("TRANS_END_TIME"))
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    If Convert.IsDBNull(dr("LOGIN_USERNAME")) = False Then sLnq.LOGIN_USERNAME = dr("LOGIN_USERNAME")
                    If Convert.IsDBNull(dr("LOGIN_FIRST_NAME")) = False Then sLnq.LOGIN_FIRST_NAME = dr("LOGIN_FIRST_NAME")
                    If Convert.IsDBNull(dr("LOGIN_LAST_NAME")) = False Then sLnq.LOGIN_LAST_NAME = dr("LOGIN_LAST_NAME")
                    If Convert.IsDBNull(dr("LOGIN_COMPANY_NAME")) = False Then sLnq.LOGIN_COMPANY_NAME = dr("LOGIN_COMPANY_NAME")
                    If Convert.IsDBNull(dr("LOGIN_BY")) = False Then sLnq.LOGIN_BY = Convert.ToString(dr("LOGIN_BY"))
                    If Convert.IsDBNull(dr("MS_APP_STEP_ID")) = False Then sLnq.MS_APP_STEP_ID = Convert.ToInt64(dr("MS_APP_STEP_ID"))
                    sLnq.SYNC_TO_SERVER = "Y"

                    If sLnq.ID > 0 Then
                        sRet = sLnq.UpdateData(KioskName, sTrans.Trans)
                    Else
                        sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    End If

                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("SyncKioskStaffConsoleTransaction from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|" & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try

        Return ret

    End Function
#End Region

#Region "Sync Kiosk Promotion Data"
    <WebMethod()>
    Public Function GetLockerPromotion(MsKioskID As Long) As MasterPromotionData
        Engine.LogFileENG.CreateServerLogAgent("GetLockerPromotion from KioskID " & MsKioskID)

        Dim pd As New MasterPromotionData
        Try
            Dim vDate As String = DateTime.Now.ToString("yyyyMMdd", New System.Globalization.CultureInfo("en-US"))
            Dim sql As String = "select lp.id ms_location_promotion_id, lp.promotion_code,lp.promotion_name, lp.start_date,lp.end_date,lp.publish_status, lps.ms_kiosk_id sync_kiosk_id " & Environment.NewLine
            sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
            sql += " left join MS_LOCATION_PROMOTION_SYNC lps On lp.id=lps.ms_location_promotion_id " & Environment.NewLine
            sql += " inner join MS_KIOSK k on k.ms_location_id=lp.ms_location_id " & Environment.NewLine
            sql += " where k.id=@_KIOSK_ID " & Environment.NewLine
            sql += " and @_DATE_NOW between convert(varchar(8), lp.start_date,112) and convert(varchar(8),lp.end_date,112) "
            sql += " and lp.publish_status=1"  '1=Publish

            Dim p(2) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_KIOSK_ID", MsKioskID)
            p(1) = ServerDB.SetText("@_DATE_NOW", vDate)

            pd.Promotion = ServerDB.ExecuteTable(sql, p)
            pd.Promotion.TableName = "Promotion"

            If pd.Promotion.Rows.Count > 0 Then
                'ถ้ามีข้อมูลก็จะมีแค่ Row เดียว
                sql = "select id, ms_cabinet_model_id, promotion_hour, service_rate "
                sql += " from MS_LOCATION_PROMOTION_HOUR "
                sql += " where ms_location_promotion_id=@_MS_LOCATION_PROMOTION_ID"
                sql += " order by promotion_hour "
                ReDim p(1)
                p(0) = ServerDB.SetBigInt("@_MS_LOCATION_PROMOTION_ID", pd.Promotion.Rows(0)("ms_location_promotion_id"))
                pd.PromotionHour = ServerDB.ExecuteTable(sql, p)
                pd.PromotionHour.TableName = "PromotionHour"

            End If
        Catch ex As Exception
            pd = New MasterPromotionData
        End Try

        Return pd
    End Function

    <WebMethod()>
    Public Function InsertLocationPromotionSync(LocationPromotionID As Long, MsKioskID As Long, KioskName As String) As String
        Engine.LogFileENG.CreateServerLogAgent("InsertLocationPromotionSync LocationPromotionID=" & LocationPromotionID & "&MsKioskID=" & MsKioskID & "&KioskName=" & KioskName)

        Dim ret As String = "false"
        'Insert MS_LOCATION_PROMOTION_SYNC at Server
        Dim syncLnq As New MsLocationPromotionSyncServerLinqDB
        syncLnq.MS_LOCATION_PROMOTION_ID = LocationPromotionID
        syncLnq.MS_KIOSK_ID = MsKioskID

        Dim sTrans As New ServerTransactionDB
        Dim sRet As ExecuteDataInfo = syncLnq.InsertData(KioskName, sTrans.Trans)
        If sRet.IsSuccess = True Then
            sTrans.CommitTransaction()
            ret = "true"
        Else
            sTrans.RollbackTransaction()
            ret = "false|" & sRet.ErrorMessage
            Engine.LogFileENG.CreateServerErrorLogAgent(ret)
        End If

        Return ret
    End Function
#End Region

#Region "Sync Log Data"
    <WebMethod()>
    Public Function SyncLogTransactionActivity(dt As DataTable, KioskName As String) As String
        Engine.LogFileENG.CreateServerLogAgent("SyncLogTransactionActivity from " & KioskName & " " & dt.Rows.Count & " Records")

        Dim ret As String = "false"
        Try
            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New TbLogTransactionActivityServerLinqDB
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    sLnq.TRANS_DATE = Convert.ToDateTime(dr("TRANS_DATE"))
                    If Convert.IsDBNull(dr("DEPOSIT_TRANS_NO")) = False Then sLnq.DEPOSIT_TRANS_NO = dr("DEPOSIT_TRANS_NO")
                    If Convert.IsDBNull(dr("PICKUP_TRANS_NO")) = False Then sLnq.PICKUP_TRANS_NO = dr("PICKUP_TRANS_NO")
                    If Convert.IsDBNull(dr("STAFF_CONSOLE_TRANS_NO")) = False Then sLnq.STAFF_CONSOLE_TRANS_NO = dr("STAFF_CONSOLE_TRANS_NO")
                    sLnq.MS_APP_SCREEN_ID = dr("MS_APP_SCREEN_ID")
                    sLnq.MS_APP_STEP_ID = dr("MS_APP_STEP_ID")
                    sLnq.LOG_DESC = dr("LOG_DESC")
                    sLnq.IS_PROBLEM = dr("IS_PROBLEM")
                    sLnq.SYNC_TO_SERVER = "Y"
                    sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("SyncLogTransactionActivity from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
        Catch ex As Exception
            ret = "false|Exception " & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function SyncLogFillMoneyData(dt As DataTable, KioskName As String) As String
        Engine.LogFileENG.CreateServerLogAgent("SyncLogFillMoneyData from " & KioskName & " " & dt.Rows.Count & " Records")

        Dim ret As String = "false"
        Try
            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo

                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New TbFillMoneyServerLinqDB
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    sLnq.COIN_MONEY = dr("COIN_MONEY")
                    sLnq.BANKNOTE_MONEY = dr("BANKNOTE_MONEY")
                    sLnq.CHECKOUT_RECEIVE_MONEY = dr("CHECKOUT_RECEIVE_MONEY")
                    If Convert.IsDBNull(dr("CHECKOUT_DATETIME")) = False Then sLnq.CHECKOUT_DATETIME = Convert.ToDateTime(dr("CHECKOUT_DATETIME"))
                    sLnq.CHANGE1_REMAIN = dr("CHANGE1_REMAIN")
                    sLnq.CHANGE2_REMAIN = dr("CHANGE2_REMAIN")
                    sLnq.CHANGE5_REMAIN = dr("CHANGE5_REMAIN")
                    sLnq.CHANGE10_REMAIN = dr("CHANGE10_REMAIN")
                    sLnq.CHANGE20_REMAIN = dr("CHANGE20_REMAIN")
                    sLnq.CHANGE50_REMAIN = dr("CHANGE50_REMAIN")
                    sLnq.CHANGE100_REMAIN = dr("CHANGE100_REMAIN")
                    sLnq.CHANGE500_REMAIN = dr("CHANGE500_REMAIN")
                    sLnq.CHECKIN_CHANGE_MONEY = dr("CHECKIN_CHANGE_MONEY")
                    If Convert.IsDBNull(dr("CHECKIN_DATETIME")) = False Then sLnq.CHECKIN_DATETIME = Convert.ToDateTime(dr("CHECKIN_DATETIME"))
                    sLnq.TOTAL_MONEY_REMAIN = dr("TOTAL_MONEY_REMAIN")
                    sLnq.IS_CONFIRM = dr("IS_CONFIRM")
                    sLnq.CONFIRM_CANCEL_DATETIME = Convert.ToDateTime(dr("CONFIRM_CANCEL_DATETIME"))
                    sLnq.CHANGE1_QTY = dr("CHANGE1_QTY")
                    sLnq.CHANGE2_QTY = dr("CHANGE2_QTY")
                    sLnq.CHANGE5_QTY = dr("CHANGE5_QTY")
                    sLnq.CHANGE10_QTY = dr("CHANGE10_QTY")
                    sLnq.CHANGE20_QTY = dr("CHANGE20_QTY")
                    sLnq.CHANGE50_QTY = dr("CHANGE50_QTY")
                    sLnq.CHANGE100_QTY = dr("CHANGE100_QTY")
                    sLnq.CHANGE500_QTY = dr("CHANGE500_QTY")
                    sLnq.SYNC_TO_SERVER = "Y"

                    sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    If sRet.IsSuccess = False Then
                        Engine.LogFileENG.CreateServerErrorLogAgent(sRet.ErrorMessage)
                        Exit For
                    End If
                Next

                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("SyncLogFillMoneyData from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|Exception " & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function SyncLogErrorData(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncLogErrorData from " & KioskName & " " & dt.Rows.Count & " Records")
            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New TbLogErrorServerLinqDB
                    sLnq.MS_KIOSK_ID = dr("MS_KIOSK_ID")
                    sLnq.CLASS_NAME = dr("CLASS_NAME")
                    sLnq.FUNCTION_NAME = dr("FUNCTION_NAME")
                    sLnq.ERROR_TIME = dr("ERROR_TIME")
                    sLnq.ERROR_DESC = dr("ERROR_DESC")
                    If Convert.IsDBNull(dr("DEPOSIT_TRANS_NO")) = False Then sLnq.DEPOSIT_TRANS_NO = dr("DEPOSIT_TRANS_NO")
                    If Convert.IsDBNull(dr("PICKUP_TRANS_NO")) = False Then sLnq.PICKUP_TRANS_NO = dr("PICKUP_TRANS_NO")
                    If Convert.IsDBNull(dr("STAFF_CONSOLE_TRANS_NO")) = False Then sLnq.STAFF_CONSOLE_TRANS_NO = dr("STAFF_CONSOLE_TRANS_NO")
                    If Convert.IsDBNull(dr("MS_APP_SCREEN_ID")) = False Then sLnq.MS_APP_SCREEN_ID = dr("MS_APP_SCREEN_ID")
                    If Convert.IsDBNull(dr("MS_APP_STEP_ID")) = False Then sLnq.MS_APP_STEP_ID = dr("MS_APP_STEP_ID")
                    sLnq.SYNC_TO_SERVER = "Y"

                    sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                Next
                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("SyncLogErrorData from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|Exception " & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function

    <WebMethod()>
    Public Function SyncLogKioskAgentData(dt As DataTable, KioskName As String) As String
        Dim ret As String = "false"
        Try
            Engine.LogFileENG.CreateServerLogAgent("SyncLogKioskAgentData from " & KioskName & " " & dt.Rows.Count & " Records")
            If dt.Rows.Count > 0 Then
                Dim sTrans As New ServerTransactionDB
                Dim sRet As New ExecuteDataInfo
                For Each dr As DataRow In dt.Rows
                    Dim sLnq As New TbLogKioskAgentServerLinqDB
                    sLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    sLnq.LOG_TIME = Convert.ToDateTime(dr("log_time"))
                    sLnq.LOG_TYPE = dr("LOG_TYPE")
                    sLnq.LOG_MESSAGE = dr("LOG_MESSAGE")
                    sLnq.CLASS_NAME = dr("CLASS_NAME")
                    sLnq.FUNCTION_NAME = dr("FUNCTION_NAME")
                    sLnq.LINE_NO = dr("LINE_NO")
                    sLnq.SYNC_TO_SERVER = "Y"

                    sRet = sLnq.InsertData(KioskName, sTrans.Trans)
                    If sRet.IsSuccess = False Then
                        Exit For
                    End If
                Next
                If sRet.IsSuccess = True Then
                    sTrans.CommitTransaction()
                    ret = "true"
                    Engine.LogFileENG.CreateServerLogAgent("SyncLogKioskAgentData from " & KioskName & " Success " & dt.Rows.Count & " Records")
                Else
                    sTrans.RollbackTransaction()
                    ret = "false|" & sRet.ErrorMessage
                    Engine.LogFileENG.CreateServerErrorLogAgent(ret)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "false|Exception " & ex.Message
            Engine.LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region


#End Region

    '<WebMethod()>
    'Public Function CreateLogServerAgent() As String
    '    Engine.LogFileENG.CreateServerLogAgent("CreateLogServerAgent")
    '    Return "true"
    'End Function

End Class