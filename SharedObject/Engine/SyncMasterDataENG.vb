
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient

Public Class SyncMasterDataENG
    Public Shared Sub SyncAllKioskMaster(MsKioskID As Long)
        'Pull Master Data คือ การดึงเอาข้อมูล Master ที่จะต้องมีเหมือนกันทุกเครื่อง จาก Server มาอัพเดทที่ Kiosk
        'ส่วนมากจะเป็นการ Update แต่ถ้าเป็นกรณี Insert ให้ set identity_insert [TABLE Name] on ก่อน เพื่อให้สามารถ Insert ID ได้;
        PullMasterAppScreen(MsKioskID)
        PullMasterAppStep(MsKioskID)
        PullMasterCabinetModel(MsKioskID)
        PullMasterDeviceType(MsKioskID)
        PullMasterDeviceStatus(MsKioskID)
        PullMasterDevice(MsKioskID)
        PullMasterMonitoringAlarm(MsKioskID)

        SyncMasterKioskSysconfig(MsKioskID)
        SyncMasterCabinet(MsKioskID)
        SyncMasterKioskDevice(MsKioskID)
        SyncMasterKioskLocker(MsKioskID)

    End Sub

#Region "Pull Master Data"
    Public Shared Sub PullMasterAppScreen(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetMasterAppScreen()
            If dt.Rows.Count > 0 Then

                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsAppScreenKioskLinqDB
                    kLnq.GetDataByPK(dr("id"), Nothing)

                    If kLnq.ID > 0 Then
                        kLnq.SCREEN_NAME = dr("SCREEN_NAME")
                        kLnq.FORM_NAME = dr("FORM_NAME")

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    Else
                        Dim Sql As String = "set identity_insert [MS_APP_SCREEN] on; " & vbNewLine
                        Sql += " insert into [MS_APP_SCREEN] (id,created_by,created_date,screen_name,form_name)" & vbNewLine
                        Sql += " values(@_ID,@_CREATED_BY,getdate(),@_SCREEN_NAME, @_FORM_NAME); " & vbNewLine
                        Sql += " set identity_insert [MS_APP_SCREEN] off;"

                        Dim p(4) As SqlParameter
                        p(0) = KioskDB.SetBigInt("@_ID", dr("id"))
                        p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                        p(2) = KioskDB.SetText("@_SCREEN_NAME", dr("SCREEN_NAME"))
                        p(3) = KioskDB.SetText("@_FORM_NAME", dr("FORM_NAME"))

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(Sql, kTrans.Trans, p)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    End If
                Next
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub PullMasterAppStep(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetMasterAppStep()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsAppStepKioskLinqDB
                    kLnq.GetDataByPK(dr("ID"), Nothing)

                    If kLnq.ID > 0 Then
                        kLnq.APP_STEP_CODE = dr("APP_STEP_CODE")
                        kLnq.MS_APP_SCREEN_ID = dr("MS_APP_SCREEN_ID")
                        kLnq.STEP_NAME_EN = dr("STEP_NAME_EN")
                        kLnq.STEP_NAME_TH = dr("STEP_NAME_TH")

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    Else
                        Dim sql As String = "set identity_insert [MS_APP_STEP] on; " & vbNewLine
                        sql += " insert into [MS_APP_STEP] (id,created_by,created_date,app_step_code,ms_app_screen_id,step_name_th,step_name_en)" & vbNewLine
                        sql += " values(@_ID,@_CREATED_BY,getdate(),@_APP_STEP_CODE, @_MS_APP_SCREEN_ID, @_STEP_NAME_TH, @_STEP_NAME_EN); " & vbNewLine
                        sql += " set identity_insert [MS_APP_STEP] off;"

                        Dim p(6) As SqlParameter
                        p(0) = KioskDB.SetBigInt("@_ID", dr("ID"))
                        p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                        p(2) = KioskDB.SetText("@_APP_STEP_CODE", dr("APP_STEP_CODE"))
                        p(3) = KioskDB.SetBigInt("@_MS_APP_SCREEN_ID", dr("MS_APP_SCREEN_ID"))
                        p(4) = KioskDB.SetText("@_STEP_NAME_TH", dr("STEP_NAME_TH"))
                        p(5) = KioskDB.SetText("@_STEP_NAME_EN", dr("STEP_NAME_EN"))

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    End If
                    kLnq = Nothing
                Next
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub PullMasterCabinetModel(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetMasterCabinetModel()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsCabinetModelKioskLinqDB
                    kLnq.GetDataByPK(dr("ID"), Nothing)
                    If kLnq.ID > 0 Then
                        kLnq.MODEL_NAME = dr("MODEL_NAME")
                        kLnq.CABINET_WIDTH = dr("CABINET_WIDTH")
                        kLnq.CABINET_HIGHT = dr("CABINET_HIGHT")
                        kLnq.CABINET_DEEP = dr("CABINET_DEEP")
                        kLnq.LOCKER_WIDTH = dr("LOCKER_WIDTH")
                        kLnq.LOCKER_HIGHT = dr("LOCKER_HIGHT")
                        kLnq.LOCKER_DEEP = dr("LOCKER_DEEP")
                        kLnq.SERVICE_RATE_HOUR = dr("SERVICE_RATE_HOUR")
                        kLnq.SERVICE_RATE_LIMIT_DAY = dr("SERVICE_RATE_LIMIT_DAY")
                        kLnq.DEPOSIT_AMT = dr("DEPOSIT_AMT")
                        kLnq.LOCKER_QTY = dr("LOCKER_QTY")
                        kLnq.ACTIVE_STATUS = dr("ACTIVE_STATUS")

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    Else

                        Dim sql As String = "set identity_insert [MS_CABINET_MODEL] on; " & vbNewLine
                        sql += " insert into [MS_CABINET_MODEL] (id,created_by,created_date,model_name,cabinet_width,cabinet_hight,cabinet_deep," & vbNewLine
                        sql += " locker_width, locker_hight, locker_deep, service_rate_hour, service_rate_limit_day,deposit_amt, locker_qty, active_status)" & vbNewLine
                        sql += " values(@_ID,@_CREATED_BY,getdate(),@_MODEL_NAME, @_CABINET_WIDTH, @_CABINET_HIGHT, @_CABINET_DEEP, "
                        sql += " @_LOCKER_WIDTH, @_LOCKER_HIGHT, @_LOCKER_DEEP, @_SERVICE_RATE_HOUR, @_SERVICE_RATE_LIMIT_DAY, @_DEPOSIT_AMT, @_LOCKER_QTY, @_ACTIVE_STATUS); " & vbNewLine
                        sql += " set identity_insert [MS_CABINET_MODEL] off;"

                        Dim p(14) As SqlParameter
                        p(0) = KioskDB.SetBigInt("@_ID", dr("ID"))
                        p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                        p(2) = KioskDB.SetText("@_MODEL_NAME", dr("MODEL_NAME"))
                        p(3) = KioskDB.SetFloat("@_CABINET_WIDTH", dr("CABINET_WIDTH"))
                        p(4) = KioskDB.SetFloat("@_CABINET_HIGHT", dr("CABINET_HIGHT"))
                        p(5) = KioskDB.SetFloat("@_CABINET_DEEP", dr("CABINET_DEEP"))
                        p(6) = KioskDB.SetFloat("@_LOCKER_WIDTH", dr("LOCKER_WIDTH"))
                        p(7) = KioskDB.SetFloat("@_LOCKER_HIGHT", dr("LOCKER_HIGHT"))
                        p(8) = KioskDB.SetFloat("@_LOCKER_DEEP", dr("LOCKER_DEEP"))
                        p(9) = KioskDB.SetFloat("@_SERVICE_RATE_HOUR", dr("SERVICE_RATE_HOUR"))
                        p(10) = KioskDB.SetFloat("@_SERVICE_RATE_LIMIT_DAY", dr("SERVICE_RATE_LIMIT_DAY"))
                        p(11) = KioskDB.SetFloat("@_DEPOSIT_AMT", dr("DEPOSIT_AMT"))
                        p(12) = KioskDB.SetInt("@_LOCKER_QTY", dr("LOCKER_QTY"))
                        p(13) = KioskDB.SetText("@_ACTIVE_STATUS", dr("ACTIVE_STATUS"))

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    End If
                    kLnq = Nothing
                Next
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub PullMasterDeviceType(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetMasterDeviceType()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsDeviceTypeKioskLinqDB
                    kLnq.GetDataByPK(dr("ID"), Nothing)
                    If kLnq.ID > 0 Then
                        kLnq.DEVICE_TYPE_NAME_TH = dr("DEVICE_TYPE_NAME_TH")
                        kLnq.DEVICE_TYPE_NAME_EN = dr("DEVICE_TYPE_NAME_EN")
                        kLnq.MOVEMENT_DIRECTION = dr("MOVEMENT_DIRECTION")
                        kLnq.ACTIVE_STATUS = dr("ACTIVE_STATUS")

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    Else
                        Dim sql As String = "set identity_insert [MS_DEVICE_TYPE] on; " & vbNewLine
                        sql += " insert into [MS_DEVICE_TYPE] (id,created_by,created_date,device_type_name_th,device_type_name_en,movement_direction,active_status )" & vbNewLine
                        sql += " values(@_ID,@_CREATED_BY,getdate(),@_DEVICE_TYPE_NAME_TH, @_DEVICE_TYPE_NAME_EN, @_MOVEMENT_DIRECTION, @_ACTIVE_STATUS ); " & vbNewLine
                        sql += " set identity_insert [MS_DEVICE_TYPE] off;"

                        Dim p(6) As SqlParameter
                        p(0) = KioskDB.SetBigInt("@_ID", dr("ID"))
                        p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                        p(2) = KioskDB.SetText("@_DEVICE_TYPE_NAME_TH", dr("DEVICE_TYPE_NAME_TH"))
                        p(3) = KioskDB.SetText("@_DEVICE_TYPE_NAME_EN", dr("DEVICE_TYPE_NAME_EN"))
                        p(4) = KioskDB.SetText("@_MOVEMENT_DIRECTION", dr("MOVEMENT_DIRECTION"))
                        p(5) = KioskDB.SetText("@_ACTIVE_STATUS", dr("ACTIVE_STATUS"))

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    End If
                    kLnq = Nothing
                Next
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub PullMasterDeviceStatus(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetMasterDeviceStatus()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsDeviceStatusKioskLinqDB
                    kLnq.GetDataByPK(dr("ID"), Nothing)
                    If kLnq.ID > 0 Then
                        kLnq.STATUS_NAME = dr("STATUS_NAME")
                        If Convert.IsDBNull(dr("IS_PROBLEM")) = False Then kLnq.IS_PROBLEM = dr("IS_PROBLEM").ToString
                        kLnq.MS_DEVICE_TYPE_ID = dr("MS_DEVICE_TYPE_ID")

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    Else
                        Dim sql As String = "set identity_insert [MS_DEVICE_STATUS] on; " & vbNewLine
                        sql += " insert into [MS_DEVICE_STATUS] (id,created_by,created_date,status_name,is_problem,ms_device_type_id)" & vbNewLine
                        sql += " values(@_ID,@_CREATED_BY,getdate(),@_STATUS_NAME, @_IS_PROBLEM, @_DEVICE_TYPE_ID ); " & vbNewLine
                        sql += " set identity_insert [MS_DEVICE_STATUS] off;"

                        Dim p(5) As SqlParameter
                        p(0) = KioskDB.SetBigInt("@_ID", dr("ID"))
                        p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                        p(2) = KioskDB.SetText("@_STATUS_NAME", dr("STATUS_NAME"))
                        p(3) = KioskDB.SetText("@_IS_PROBLEM", dr("IS_PROBLEM").ToString)
                        p(4) = KioskDB.SetBigInt("@_DEVICE_TYPE_ID", dr("MS_DEVICE_TYPE_ID"))

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    End If
                    kLnq = Nothing
                Next
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub PullMasterDevice(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetMasterDevice()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsDeviceKioskLinqDB
                    kLnq.GetDataByPK(dr("ID"), Nothing)
                    If kLnq.ID > 0 Then
                        kLnq.DEVICE_NAME_TH = dr("DEVICE_NAME_TH")
                        kLnq.DEVICE_NAME_EN = dr("DEVICE_NAME_EN")
                        If Convert.IsDBNull(dr("DEVICE_NAME_EN")) = False Then kLnq.MS_DEVICE_TYPE_ID = dr("MS_DEVICE_TYPE_ID")
                        kLnq.UNIT_VALUE = dr("UNIT_VALUE")
                        kLnq.MAX_QTY = dr("MAX_QTY")
                        kLnq.WARNING_QTY = dr("WARNING_QTY")
                        kLnq.CRITICAL_QTY = dr("CRITICAL_QTY")
                        If Convert.IsDBNull(dr("ICON_WHITE")) = False Then kLnq.ICON_WHITE = dr("ICON_WHITE")
                        If Convert.IsDBNull(dr("ICON_GREEN")) = False Then kLnq.ICON_GREEN = dr("ICON_GREEN")
                        If Convert.IsDBNull(dr("ICON_RED")) = False Then kLnq.ICON_RED = dr("ICON_RED")
                        kLnq.DEVICE_ORDER = dr("DEVICE_ORDER")
                        kLnq.ACTIVE_STATUS = dr("ACTIVE_STATUS")

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    Else

                        Dim sql As String = "set identity_insert [MS_DEVICE] on; " & vbNewLine
                        sql += " insert into [MS_DEVICE] (id,created_by,created_date,device_name_th,device_name_en,ms_device_type_id, " & vbNewLine
                        sql += " unit_value, max_qty, warning_qty, critical_qty, icon_white, icon_green, icon_red, device_order, active_status)" & vbNewLine
                        sql += " values(@_ID,@_CREATED_BY,getdate(),@_DEVICE_NAME_TH, @_DEVICE_NAME_EN,@_DEVICE_TYPE_ID, " & vbNewLine
                        sql += " @_UNIT_VALUE, @_MAX_QTY, @_WARNING_QTY, @_CRITICAL_QTY, @_ICON_WHITE, @_ICON_GREEN, @_ICON_RED, @_DEVICE_ORDER, @_ACTIVE_STATUS )"
                        sql += " set identity_insert [MS_DEVICE] off;"

                        Dim p(14) As SqlParameter
                        p(0) = KioskDB.SetBigInt("@_ID", dr("ID"))
                        p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                        p(2) = KioskDB.SetText("@_DEVICE_NAME_TH", dr("DEVICE_NAME_TH"))
                        p(3) = KioskDB.SetText("@_DEVICE_NAME_EN", dr("DEVICE_NAME_EN"))
                        p(4) = KioskDB.SetBigInt("@_DEVICE_TYPE_ID", dr("MS_DEVICE_TYPE_ID"))
                        p(5) = KioskDB.SetInt("@_UNIT_VALUE", dr("UNIT_VALUE"))
                        p(6) = KioskDB.SetInt("@_MAX_QTY", dr("MAX_QTY"))
                        p(7) = KioskDB.SetInt("@_WARNING_QTY", dr("WARNING_QTY"))
                        p(8) = KioskDB.SetInt("@_CRITICAL_QTY", dr("CRITICAL_QTY"))
                        p(9) = KioskDB.SetImage("@_ICON_WHITE", dr("ICON_WHITE"))
                        p(10) = KioskDB.SetImage("@_ICON_GREEN", dr("ICON_GREEN"))
                        p(11) = KioskDB.SetImage("@_ICON_RED", dr("ICON_RED"))
                        p(12) = KioskDB.SetInt("@_DEVICE_ORDER", dr("DEVICE_ORDER"))
                        p(13) = KioskDB.SetText("@_ACTIVE_STATUS", dr("ACTIVE_STATUS"))

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    End If
                    kLnq = Nothing
                Next
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub PullMasterMonitoringAlarm(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetMasterMonitoringAlarm()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsMasterMonitoringAlarmKioskLinqDB
                    kLnq.GetDataByPK(dr("ID"), Nothing)
                    If kLnq.ID > 0 Then
                        If Convert.IsDBNull(dr("MS_MASTER_MONITORING_TYPE_ID")) = False Then kLnq.MS_MASTER_MONITORING_TYPE_ID = dr("MS_MASTER_MONITORING_TYPE_ID")
                        If Convert.IsDBNull(dr("ALARM_CODE")) = False Then kLnq.ALARM_CODE = dr("ALARM_CODE")
                        If Convert.IsDBNull(dr("ALARM_PROBLEM")) = False Then kLnq.ALARM_PROBLEM = dr("ALARM_PROBLEM")
                        If Convert.IsDBNull(dr("ENG_DESC")) = False Then kLnq.ENG_DESC = dr("ENG_DESC")
                        If Convert.IsDBNull(dr("THA_DESC")) = False Then kLnq.THA_DESC = dr("THA_DESC")
                        If Convert.IsDBNull(dr("SMS_MESSAGE")) = False Then kLnq.SMS_MESSAGE = dr("SMS_MESSAGE")

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    Else

                        Dim sql As String = "Set identity_insert [MS_MASTER_MONITORING_ALARM] On; " & vbNewLine
                        sql += " insert into [MS_MASTER_MONITORING_ALARM] (id,created_by,created_date,ms_master_monitoring_type_id,alarm_code,alarm_problem, " & vbNewLine
                        sql += " eng_desc, tha_desc, sms_message)" & vbNewLine
                        sql += " values(@_ID,@_CREATED_BY,getdate(),@_MS_MASTER_MONITORING_TYPE_ID, @_ALARM_CODE,@_ALARM_PROBLEM, " & vbNewLine
                        sql += " @_ENG_DESC, @_THA_DESC, @_SMS_MESSAGE) " & vbNewLine
                        sql += " Set identity_insert [MS_MASTER_MONITORING_ALARM] off;"

                        Dim p(8) As SqlParameter
                        p(0) = KioskDB.SetBigInt("@_ID", dr("ID"))
                        p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                        p(2) = KioskDB.SetBigInt("@_MS_MASTER_MONITORING_TYPE_ID", dr("MS_MASTER_MONITORING_TYPE_ID"))
                        p(3) = KioskDB.SetText("@_ALARM_CODE", dr("ALARM_CODE"))
                        p(4) = KioskDB.SetText("@_ALARM_PROBLEM", dr("ALARM_PROBLEM"))
                        p(5) = KioskDB.SetText("@_ENG_DESC", dr("ENG_DESC"))
                        p(6) = KioskDB.SetText("@_THA_DESC", dr("THA_DESC"))
                        p(7) = KioskDB.SetText("@_SMS_MESSAGE", dr("SMS_MESSAGE"))

                        Dim kTrans As New KioskTransactionDB
                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                        If ret.IsSuccess = True Then
                            kTrans.CommitTransaction()
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    End If
                    kLnq = Nothing
                Next
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub PullMasterServiceRate(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim sr As SyncDataWebservice.MasterServiceRateData = ws.GetLockerServiceRate(MsKioskID)
            If sr.ServiceRate.Rows.Count > 0 And sr.ServiceRateDeposit.Rows.Count > 0 And sr.ServiceRateHour.Rows.Count > 0 And sr.ServiceRateOverNight.Rows.Count > 0 Then
                Dim dt As DataTable = sr.ServiceRate

                'Sync Service Rate Data at KIOSK
                Dim srID As Long = dt.Rows(0)("id")
                Dim kTrans As New KioskTransactionDB
                Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo
                Dim srKiosk As New MsServiceRateKioskLinqDB
                srKiosk.GetDataByPK(srID, Nothing)
                If srKiosk.ID > 0 Then
                    srKiosk.MS_KIOSK_ID = MsKioskID

                    ret = srKiosk.UpdateData(Environment.MachineName, kTrans.Trans)
                    If ret.IsSuccess = False Then
                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                    End If
                Else
                    Dim sql As String = "Set identity_insert [MS_SERVICE_RATE] On; " & vbNewLine
                    sql += " insert into [MS_SERVICE_RATE] (id,created_by,created_date,ms_kiosk_id)" & vbNewLine
                    sql += " values(@_ID,@_CREATED_BY,getdate(),@_MS_KIOSK_ID) " & vbNewLine
                    sql += " Set identity_insert [MS_SERVICE_RATE] off;"

                    Dim p(3) As SqlParameter
                    p(0) = KioskDB.SetBigInt("@_ID", srID)
                    p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                    p(2) = KioskDB.SetBigInt("@_MS_KIOSK_ID", MsKioskID)

                    ret = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                    If ret.IsSuccess = False Then
                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                    Else
                        srKiosk.ID = srID
                    End If
                End If

                If ret.IsSuccess = True Then
                    For Each dDr As DataRow In sr.ServiceRateDeposit.Rows
                        Dim kLnq As New MsServiceRateDepositKioskLinqDB
                        kLnq.GetDataByPK(Convert.ToInt64(dDr("id")), kTrans.Trans)
                        If kLnq.ID > 0 Then
                            kLnq.MS_SERVICE_RATE_ID = srID
                            kLnq.MS_CABINET_MODEL_ID = Convert.ToInt64(dDr("ms_cabinet_model_id"))
                            kLnq.DEPOSIT_RATE = Convert.ToInt64(dDr("deposit_rate"))

                            ret = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                            If ret.IsSuccess = False Then
                                LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                Exit For
                            End If
                        Else
                            Dim sql As String = "Set identity_insert [MS_SERVICE_RATE_DEPOSIT] On; " & vbNewLine
                            sql += " insert into [MS_SERVICE_RATE_DEPOSIT] (id,created_by,created_date,ms_service_rate_id,ms_cabinet_model_id, deposit_rate)" & vbNewLine
                            sql += " values(@_ID,@_CREATED_BY,getdate(),@_MS_SERVICE_RATE_ID,@_MS_CABINET_MODEL_ID, @_DEPOSIT_RATE) " & vbNewLine
                            sql += " Set identity_insert [MS_SERVICE_RATE_DEPOSIT] off;"

                            Dim p(5) As SqlParameter
                            p(0) = KioskDB.SetBigInt("@_ID", Convert.ToInt64(dDr("id")))
                            p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                            p(2) = KioskDB.SetBigInt("@_MS_SERVICE_RATE_ID", srID)
                            p(3) = KioskDB.SetBigInt("@_MS_CABINET_MODEL_ID", Convert.ToInt64(dDr("ms_cabinet_model_id")))
                            p(4) = KioskDB.SetBigInt("@_DEPOSIT_RATE", Convert.ToInt64(dDr("deposit_rate")))

                            ret = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                            If ret.IsSuccess = False Then
                                LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                Exit For
                            End If
                        End If
                        kLnq = Nothing
                    Next

                    If ret.IsSuccess = True Then
                        For Each dDr As DataRow In sr.ServiceRateHour.Rows
                            Dim kLnq As New MsServiceRateHourKioskLinqDB
                            kLnq.GetDataByPK(Convert.ToInt64(dDr("id")), kTrans.Trans)
                            If kLnq.ID > 0 Then
                                kLnq.MS_SERVICE_RATE_ID = srID
                                kLnq.MS_CABINET_MODEL_ID = Convert.ToInt64(dDr("ms_cabinet_model_id"))
                                kLnq.SERVICE_HOUR = Convert.ToInt16(dDr("service_hour"))
                                kLnq.SERVICE_RATE = Convert.ToInt16(dDr("service_rate"))

                                ret = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                                If ret.IsSuccess = False Then
                                    LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                    Exit For
                                End If
                            Else
                                Dim sql As String = "Set identity_insert [MS_SERVICE_RATE_HOUR] On; " & vbNewLine
                                sql += " insert into [MS_SERVICE_RATE_HOUR] (id,created_by,created_date,ms_service_rate_id,ms_cabinet_model_id, service_hour,service_rate)" & vbNewLine
                                sql += " values(@_ID,@_CREATED_BY,getdate(),@_MS_SERVICE_RATE_ID,@_MS_CABINET_MODEL_ID, @_SERVICE_HOUR, @_SERVICE_RATE) " & vbNewLine
                                sql += " Set identity_insert [MS_SERVICE_RATE_HOUR] off;"

                                Dim p(6) As SqlParameter
                                p(0) = KioskDB.SetBigInt("@_ID", Convert.ToInt64(dDr("id")))
                                p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                                p(2) = KioskDB.SetBigInt("@_MS_SERVICE_RATE_ID", srID)
                                p(3) = KioskDB.SetBigInt("@_MS_CABINET_MODEL_ID", Convert.ToInt64(dDr("ms_cabinet_model_id")))
                                p(4) = KioskDB.SetBigInt("@_SERVICE_HOUR", Convert.ToInt64(dDr("service_hour")))
                                p(5) = KioskDB.SetBigInt("@_SERVICE_RATE", Convert.ToInt64(dDr("service_rate")))

                                ret = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                                If ret.IsSuccess = False Then
                                    LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                    Exit For
                                End If
                            End If
                            kLnq = Nothing
                        Next

                        If ret.IsSuccess = True Then
                            For Each dDr As DataRow In sr.ServiceRateOverNight.Rows
                                Dim kLnq As New MsServiceRateOvernightKioskLinqDB
                                kLnq.GetDataByPK(Convert.ToInt64(dDr("id")), kTrans.Trans)
                                If kLnq.ID > 0 Then
                                    kLnq.MS_SERVICE_RATE_ID = srID
                                    kLnq.MS_CABINET_MODEL_ID = Convert.ToInt64(dDr("ms_cabinet_model_id"))
                                    kLnq.SERVICE_RATE_DAY = Convert.ToInt16(dDr("service_rate_day"))

                                    ret = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                                    If ret.IsSuccess = False Then
                                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                        Exit For
                                    End If
                                Else
                                    Dim sql As String = "Set identity_insert [MS_SERVICE_RATE_OVERNIGHT] On; " & vbNewLine
                                    sql += " insert into [MS_SERVICE_RATE_OVERNIGHT] (id,created_by,created_date,ms_service_rate_id,ms_cabinet_model_id, service_rate_day)" & vbNewLine
                                    sql += " values(@_ID,@_CREATED_BY,getdate(),@_MS_SERVICE_RATE_ID,@_MS_CABINET_MODEL_ID,  @_SERVICE_RATE_DAY) " & vbNewLine
                                    sql += " Set identity_insert [MS_SERVICE_RATE_OVERNIGHT] off;"

                                    Dim p(5) As SqlParameter
                                    p(0) = KioskDB.SetBigInt("@_ID", Convert.ToInt64(dDr("id")))
                                    p(1) = KioskDB.SetText("@_CREATED_BY", Environment.MachineName)
                                    p(2) = KioskDB.SetBigInt("@_MS_SERVICE_RATE_ID", srID)
                                    p(3) = KioskDB.SetBigInt("@_MS_CABINET_MODEL_ID", Convert.ToInt64(dDr("ms_cabinet_model_id")))
                                    p(4) = KioskDB.SetBigInt("@_SERVICE_RATE_DAY", Convert.ToInt64(dDr("service_rate_day")))

                                    ret = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                                    If ret.IsSuccess = False Then
                                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                        Exit For
                                    End If
                                End If
                                kLnq = Nothing
                            Next

                            If ret.IsSuccess = True Then
                                kTrans.CommitTransaction()
                            Else
                                kTrans.RollbackTransaction()
                            End If
                        Else
                            kTrans.RollbackTransaction()
                        End If
                    Else
                        kTrans.RollbackTransaction()
                    End If
                Else
                    kTrans.RollbackTransaction()
                End If
                srKiosk = Nothing
                dt.Dispose()
            End If
            sr = Nothing
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub
#End Region

#Region "Sync Kiosk Master Data"
    Private Shared Sub SyncMasterKioskSysconfig(MsKioskID As Long)
        '###########################
        'Sync Kiosk to Server
        '###########################
        Try
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)
            Dim kLnq As New CfKioskSysconfigKioskLinqDB
            Dim dt As DataTable = kLnq.GetDataList("sync_to_server='N' and ms_kiosk_id=@_KIOSK_ID", "", Nothing, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncMasterKioskSysconfig"
                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 10000
                ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncKioskSysconfig(dt, Environment.MachineName)
                If ret = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                    For Each dr As DataRow In dt.Rows
                        kLnq = New CfKioskSysconfigKioskLinqDB
                        kLnq.GetDataByPK(dr("id"), Nothing)
                        If kLnq.ID > 0 Then
                            'เสร็จแล้วให้ Update สถานะ sync_to_server ของข้อมูลที่ Kiosk ให้เป็น Y
                            kLnq.SYNC_TO_SERVER = "Y"

                            kRet = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                            If kRet.IsSuccess = False Then
                                Exit For
                            End If
                        End If
                        kLnq = Nothing
                    Next

                    If kRet.IsSuccess = True Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, kLnq.ErrorMessage)
                    End If
                End If
                ws.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, "1 :" & ex.Message, ex.StackTrace)
        End Try



        '###########################
        'Sync Server to Kiosk
        '###########################
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

            Dim dt As DataTable = ws.GetServerKioskSysconfig(MsKioskID)
            If dt.Rows.Count > 0 Then
                Dim kTrans As New KioskTransactionDB
                Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New CfKioskSysconfigKioskLinqDB
                    kLnq.ChkDataByMS_KIOSK_ID(MsKioskID, Nothing)
                    kLnq.MS_KIOSK_ID = MsKioskID
                    If Convert.IsDBNull(dr("MAC_ADDRESS")) = False Then kLnq.MAC_ADDRESS = dr("MAC_ADDRESS")
                    If Convert.IsDBNull(dr("IP_ADDRESS")) = False Then kLnq.IP_ADDRESS = dr("IP_ADDRESS")
                    If Convert.IsDBNull(dr("LOCATION_CODE")) = False Then kLnq.LOCATION_CODE = dr("LOCATION_CODE")
                    If Convert.IsDBNull(dr("LOCATION_NAME")) = False Then kLnq.LOCATION_NAME = dr("LOCATION_NAME")
                    kLnq.LOGIN_SSO = dr("LOGIN_SSO")
                    kLnq.KIOSK_OPEN_TIME = dr("KIOSK_OPEN_TIME")
                    kLnq.KIOSK_OPEN24 = dr("KIOSK_OPEN24")
                    kLnq.SCREEN_SAVER_SEC = dr("SCREEN_SAVER_SEC")
                    kLnq.TIME_OUT_SEC = dr("TIME_OUT_SEC")
                    kLnq.SHOW_MSG_SEC = dr("SHOW_MSG_SEC")
                    kLnq.PAYMENT_EXTEND_SEC = dr("PAYMENT_EXTEND_SEC")
                    kLnq.PINCODE_LEN = dr("PINCODE_LEN")
                    kLnq.LOCKER_WEBSERVICE_URL = dr("LOCKER_WEBSERVICE_URL")
                    kLnq.LOCKER_PC_POSITION = dr("LOCKER_PC_POSITION")
                    kLnq.SLEEP_TIME = dr("SLEEP_TIME")
                    kLnq.SLEEP_DURATION = dr("SLEEP_DURATION")
                    kLnq.CONTACT_CENTER_TELNO = dr("CONTACT_CENTER_TELNO")
                    If Convert.IsDBNull(dr("ALARM_WEBSERVICE_URL")) = False Then kLnq.ALARM_WEBSERVICE_URL = dr("ALARM_WEBSERVICE_URL")
                    kLnq.INTERVAL_SYNC_TRANSACTION_MIN = dr("INTERVAL_SYNC_TRANSACTION_MIN")
                    kLnq.INTERVAL_SYNC_LOG_MIN = dr("INTERVAL_SYNC_LOG_MIN")
                    kLnq.INTERVAL_SYNC_MASTER_MIN = dr("INTERVAL_SYNC_MASTER_MIN")
                    kLnq.SYNC_TO_KIOSK = "Y"

                    If kLnq.ID > 0 Then
                        kRet = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                    Else
                        kRet = kLnq.InsertData(Environment.MachineName, kTrans.Trans)
                    End If

                    If kRet.IsSuccess = False Then
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                        Exit For
                    End If
                Next

                If kRet.IsSuccess = True Then
                    Dim ret As String = ws.UpdateServerSyncKioskSysconfig(dt, Environment.MachineName)
                    If ret = "true" Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret)
                    End If
                Else
                    kTrans.RollbackTransaction()
                    LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                End If

            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, "2:" & ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub SyncMasterCabinet(MsKioskID As Long)
        '###########################
        'Sync Kiosk to Server
        '###########################
        Try
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)
            Dim klnq As New MsCabinetKioskLinqDB

            Dim dt As DataTable = klnq.GetDataList("sync_to_server='N' and ms_kiosk_id=@_KIOSK_ID", "", Nothing, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncMasterCabinet"
                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 10000
                ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncMasterKioskCabinet(dt, Environment.MachineName)
                If ret = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                    For Each dr As DataRow In dt.Rows
                        klnq = New MsCabinetKioskLinqDB
                        klnq.GetDataByPK(dr("id"), Nothing)
                        If klnq.ID > 0 Then
                            'เสร็จแล้วให้ Update สถานะ sync_to_server ของข้อมูลที่ Kiosk ให้เป็น Y
                            klnq.SYNC_TO_SERVER = "Y"
                            kRet = klnq.UpdateData(Environment.MachineName, kTrans.Trans)
                            If kRet.IsSuccess = False Then
                                LogFileENG.CreateErrorLogAgent(MsKioskID, klnq.ErrorMessage)
                                Exit For
                            End If
                        End If
                        klnq = Nothing
                    Next

                    If kRet.IsSuccess = True Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                    End If
                End If
                ws.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, "1 :" & ex.Message, ex.StackTrace)
        End Try



        '###########################
        'Sync Server to Kiosk
        '###########################
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetServerKioskCabinet(MsKioskID)
            If dt.Rows.Count > 0 Then
                Dim kTrans As New KioskTransactionDB
                Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo

                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsCabinetKioskLinqDB
                    kLnq.ChkDataByMS_CABINET_ID(dr("ID"), Nothing)
                    kLnq.MS_KIOSK_ID = MsKioskID
                    kLnq.MS_CABINET_ID = dr("ID")
                    kLnq.CABINET_NO = dr("CABINET_NO")
                    kLnq.ORDER_LAYOUT = dr("ORDER_LAYOUT")
                    kLnq.MS_CABINET_MODEL_ID = dr("MS_CABINET_MODEL_ID")
                    kLnq.SERVICE_RATE_HOUR = dr("SERVICE_RATE_HOUR")
                    kLnq.SERVICE_RATE_LIMIT_DAY = dr("SERVICE_RATE_LIMIT_DAY")
                    kLnq.DEPOSIT_AMT = dr("DEPOSIT_AMT")
                    kLnq.ACTIVE_STATUS = dr("ACTIVE_STATUS")
                    kLnq.SYNC_TO_KIOSK = "Y"

                    If kLnq.ID > 0 Then
                        kRet = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                    Else
                        kRet = kLnq.InsertData(Environment.MachineName, kTrans.Trans)
                    End If

                    If kRet.IsSuccess = False Then
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                        Exit For
                    End If
                Next

                If kRet.IsSuccess = True Then
                    Dim ret As String = ws.UpdateServerSyncKioskCabinet(dt, Environment.MachineName)
                    If ret = "true" Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret)
                    End If
                Else
                    kTrans.RollbackTransaction()
                    LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, "2 :" & ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub SyncMasterKioskDevice(MsKioskID As Long)
        '#############################################
        'Sync Kiosk to Server
        '#############################################
        Try
            Dim kLnq As New MsKioskDeviceKioskLinqDB
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim dt As DataTable = kLnq.GetDataList("sync_to_server='N' and ms_kiosk_id=@_KIOSK_ID", "", Nothing, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncMasterKioskDevice"
                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 10000
                ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncMasterKioskDevice(dt, Environment.MachineName)
                If ret = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                    For Each dr As DataRow In dt.Rows
                        kLnq = New MsKioskDeviceKioskLinqDB
                        kLnq.GetDataByPK(dr("id"), Nothing)
                        If kLnq.ID > 0 Then
                            'เสร็จแล้วให้ Update สถานะ sync_to_server ของข้อมูลที่ Kiosk ให้เป็น Y
                            kLnq.SYNC_TO_SERVER = "Y"
                            kRet = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                            If kRet.IsSuccess = False Then
                                LogFileENG.CreateErrorLogAgent(MsKioskID, kLnq.ErrorMessage)
                                Exit For
                            End If
                        End If
                        kLnq = Nothing
                    Next

                    If kRet.IsSuccess = True Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                    End If
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try

        '#############################################
        'Sync Server to Kiosk
        '#############################################
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

            Dim dt As DataTable = ws.GetServeKioskDevice(MsKioskID)
            If dt.Rows.Count > 0 Then
                Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                Dim kTrans As New KioskTransactionDB

                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsKioskDeviceKioskLinqDB
                    kLnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(dr("MS_DEVICE_ID"), MsKioskID, kTrans.Trans)
                    kLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    kLnq.MS_DEVICE_ID = dr("MS_DEVICE_ID")
                    kLnq.MAX_QTY = dr("MAX_QTY")
                    kLnq.WARNING_QTY = dr("WARNING_QTY")
                    kLnq.CRITICAL_QTY = dr("CRITICAL_QTY")

                    '###################### ข้อมูล CURRENT_QTY, CURRENT_MONEY, DEVICE_STATUS ไม่ต้อง Sync จาก Server มาหาตู้ Locker  #################
                    'kLnq.CURRENT_QTY = dr("CURRENT_QTY")
                    'If Convert.IsDBNull(dr("CURRENT_MONEY")) = False Then kLnq.CURRENT_MONEY = Convert.ToInt64(dr("CURRENT_MONEY"))
                    'kLnq.MS_DEVICE_STATUS_ID = dr("MS_DEVICE_STATUS_ID")
                    If Convert.IsDBNull(dr("COMPORT_VID")) = False Then kLnq.COMPORT_VID = dr("COMPORT_VID")
                    If Convert.IsDBNull(dr("DRIVER_NAME1")) = False Then kLnq.DRIVER_NAME1 = dr("DRIVER_NAME1")
                    If Convert.IsDBNull(dr("DRIVER_NAME2")) = False Then kLnq.DRIVER_NAME2 = dr("DRIVER_NAME2")
                    kLnq.SYNC_TO_KIOSK = "Y"

                    If kLnq.ID > 0 Then
                        kRet = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                    Else
                        kLnq.MS_DEVICE_STATUS_ID = 2
                        kRet = kLnq.InsertData(Environment.MachineName, kTrans.Trans)
                    End If

                    If kRet.IsSuccess = False Then
                        LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                        Exit For
                    End If
                    kLnq = Nothing
                Next

                If kRet.IsSuccess = True Then
                    Dim ret As String = ws.UpdateServerSyncKioskDevice(dt, Environment.MachineName)
                    If ret = "true" Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret)
                    End If
                Else
                    kTrans.RollbackTransaction()
                End If
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Shared Function GetKioskCabinetID(ServerCabinetID As Long, MsKioskID As Long) As Long
        Dim ret As Long = 0
        Try
            Dim kLnq As New MsCabinetKioskLinqDB
            kLnq.ChkDataByMS_CABINET_ID(ServerCabinetID, Nothing)
            If kLnq.ID > 0 Then
                ret = kLnq.ID
            End If
            kLnq = Nothing
        Catch ex As Exception
            ret = 0
        End Try
        Return ret
    End Function

    Private Shared Sub SyncMasterKioskLocker(MsKioskID As Long)
        '#############################################
        'Sync Kiosk to Server
        '#############################################
        Try
            Dim sql As String = " select l.id, l.locker_name, l.layout_name, l.ms_kiosk_id, c.ms_cabinet_id, l.model_name, "
            sql += " l.pin_solenoid, l.pin_led, l.pin_sensor, l.open_close_status, l.current_available, l.active_status, l.ms_locker_id"
            sql += " from ms_locker l "
            sql += " inner join ms_cabinet c on c.id=l.ms_cabinet_id "
            sql += " where l.sync_to_server='N'"
            sql += " and l.ms_kiosk_id=@_KIOSK_ID"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", MsKioskID)

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                dt.TableName = "SyncMasterKioskLocker"
                Dim ws As New SyncDataWebservice.ATBLockerWebService
                ws.Timeout = 10000
                ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL

                Dim ret As String = ws.SyncMasterKioskLocker(dt, Environment.MachineName)
                If ret = "true" Then
                    Dim kTrans As New KioskTransactionDB
                    Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                    For Each dr As DataRow In dt.Rows
                        Dim kLnq As New MsLockerKioskLinqDB
                        kLnq.GetDataByPK(dr("id"), Nothing)
                        If kLnq.ID > 0 Then
                            kLnq.SYNC_TO_SERVER = "Y"
                            kRet = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                            If kRet.IsSuccess = False Then
                                LogFileENG.CreateErrorLogAgent(MsKioskID, kLnq.ErrorMessage)
                                Exit For
                            End If
                        End If
                        kLnq = Nothing
                    Next
                    If kRet.IsSuccess = True Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                    End If
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, "Exception :" & ex.Message, ex.StackTrace)
        End Try


        '#############################################
        'Sync Server to Kiosk
        '#############################################
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim dt As DataTable = ws.GetServerKioskLocker(MsKioskID)
            If dt.Rows.Count > 0 Then
                Dim kRet As New KioskLinqDB.ConnectDB.ExecuteDataInfo
                Dim kTrans As New KioskTransactionDB

                For Each dr As DataRow In dt.Rows
                    Dim kLnq As New MsLockerKioskLinqDB
                    kLnq.ChkDataByMS_LOCKER_ID(dr("ID"), kTrans.Trans)
                    kLnq.MS_KIOSK_ID = dr("ms_kiosk_id")
                    kLnq.LOCKER_NAME = dr("LOCKER_NAME")
                    If Convert.IsDBNull(dr("LAYOUT_NAME")) = False Then kLnq.LAYOUT_NAME = dr("LAYOUT_NAME")
                    kLnq.MS_LOCKER_ID = dr("ID")
                    kLnq.MS_CABINET_ID = GetKioskCabinetID(dr("MS_CABINET_ID"), MsKioskID)
                    If Convert.IsDBNull(dr("MODEL_NAME")) Then kLnq.MODEL_NAME = dr("MODEL_NAME")
                    kLnq.PIN_SOLENOID = dr("PIN_SOLENOID")
                    kLnq.PIN_LED = dr("PIN_LED")
                    kLnq.PIN_SENSOR = dr("PIN_SENSOR")
                    kLnq.OPEN_CLOSE_STATUS = dr("OPEN_CLOSE_STATUS")
                    kLnq.CURRENT_AVAILABLE = dr("CURRENT_AVAILABLE")
                    kLnq.ACTIVE_STATUS = dr("ACTIVE_STATUS")
                    kLnq.SYNC_TO_KIOSK = "Y"

                    If kLnq.ID > 0 Then
                        kRet = kLnq.UpdateData(Environment.MachineName, kTrans.Trans)
                    Else
                        kRet = kLnq.InsertData(Environment.MachineName, kTrans.Trans)
                    End If

                    If kRet.IsSuccess = False Then
                        LogFileENG.CreateErrorLogAgent(MsKioskID, kRet.ErrorMessage)
                        Exit For
                    End If
                Next

                If kRet.IsSuccess = True Then
                    Dim ret As String = ws.UpdateSyncKioskLocker(dt, Environment.MachineName)
                    If ret = "true" Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret)
                    End If
                Else
                    kTrans.RollbackTransaction()
                End If
            End If
            dt.Dispose()
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, "Exception :" & ex.Message, ex.StackTrace)
        End Try
    End Sub

#End Region

#Region "Sync Kiosk Promotion Data"
    Public Shared Sub SyncMasterPromotion(MsKioskID As Long)
        Try
            Dim ws As New SyncDataWebservice.ATBLockerWebService
            ws.Timeout = 10000
            ws.Url = KioskInfoENG.GetLockerSysconfig(MsKioskID).LOCKER_WEBSERVICE_URL
            Dim pd As SyncDataWebservice.MasterPromotionData = ws.GetLockerPromotion(MsKioskID)
            If pd.Promotion.Rows.Count > 0 And pd.PromotionHour.Rows.Count > 0 Then
                If pd.Promotion.Rows.Count > 0 Then
                    'ถ้ามีข้อมูลก็จะมีแค่ Row เดียว
                    Dim MsLocationPromotionID As Long = pd.Promotion.Rows(0)("ms_location_promotion_id")
                    Dim PromotionCode As String = pd.Promotion.Rows(0)("promotion_code")

                    'ถ้ามีข้อมูลให้หาว่ามีข้อมูลการ Sync แล้วหรือไม่ ดูจาก sync_kiosk_id is null
                    pd.Promotion.DefaultView.RowFilter = "sync_kiosk_id='" & MsKioskID & "'"
                    If pd.Promotion.DefaultView.Count = 0 Then
                        Dim kTrans As New KioskTransactionDB

                        'ลบข้อมูล Promotion Code เดิมที่ Kiosk ก่อนที่จะ Sync ข้อมูลใหม่
                        Dim Sql As String = " delete from MS_KIOSK_PROMOTION_HOUR "
                        Sql += " where ms_kiosk_promotion_id in (select id from MS_KIOSK_PROMOTION where promotion_code=@_PROMOTION_CODE) "

                        Dim kpDel(1) As SqlParameter
                        kpDel(0) = KioskDB.SetText("@_PROMOTION_CODE", PromotionCode)

                        Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(Sql, kTrans.Trans, kpDel)
                        If ret.IsSuccess = True Then
                            Sql = "delete from MS_KIOSK_PROMOTION where promotion_code=@_PROMOTION_CODE"
                            ReDim kpDel(1)
                            kpDel(0) = KioskDB.SetText("@_PROMOTION_CODE", PromotionCode)

                            ret = KioskDB.ExecuteNonQuery(Sql, kTrans.Trans, kpDel)
                            If ret.IsSuccess = True Then
                                Dim kpLnq As New MsKioskPromotionKioskLinqDB
                                kpLnq.MS_KIOSK_ID = MsKioskID
                                kpLnq.PROMOTION_CODE = pd.Promotion.Rows(0)("PROMOTION_CODE")
                                kpLnq.PROMOTION_NAME = pd.Promotion.Rows(0)("PROMOTION_NAME")
                                kpLnq.START_DATE = pd.Promotion.Rows(0)("START_DATE")
                                kpLnq.END_DATE = pd.Promotion.Rows(0)("END_DATE")
                                kpLnq.PUBLISH_STATUS = pd.Promotion.Rows(0)("PUBLISH_STATUS")

                                ret = kpLnq.InsertData(Environment.MachineName, kTrans.Trans)
                                If ret.IsSuccess = True Then

                                    'Insert MS_KIOSK_PROMOTION_HOUR
                                    For Each lphDr As DataRow In pd.PromotionHour.Rows
                                        Dim kphLnq As New MsKioskPromotionHourKioskLinqDB
                                        kphLnq.MS_KIOSK_PROMOTION_ID = kpLnq.ID
                                        kphLnq.MS_CABINET_MODEL_ID = lphDr("MS_CABINET_MODEL_ID")
                                        kphLnq.PROMOTION_HOUR = lphDr("PROMOTION_HOUR")
                                        kphLnq.SERVICE_RATE = lphDr("SERVICE_RATE")

                                        ret = kphLnq.InsertData(Environment.MachineName, kTrans.Trans)
                                        If ret.IsSuccess = False Then
                                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                            Exit For
                                        End If
                                    Next

                                    If ret.IsSuccess = True Then
                                        'Insert MS_LOCATION_PROMOTION_SYNC at Server
                                        Dim re As String = ws.InsertLocationPromotionSync(MsLocationPromotionID, MsKioskID, Environment.MachineName)
                                        If re = "true" Then
                                            kTrans.CommitTransaction()
                                        Else
                                            kTrans.RollbackTransaction()
                                            LogFileENG.CreateErrorLogAgent(MsKioskID, re)
                                        End If
                                    Else
                                        kTrans.RollbackTransaction()
                                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                    End If
                                Else
                                    kTrans.RollbackTransaction()
                                    LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                                End If
                            Else
                                kTrans.RollbackTransaction()
                                LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                            End If
                        Else
                            kTrans.RollbackTransaction()
                            LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                        End If
                    End If
                    pd.Promotion.DefaultView.RowFilter = ""
                End If
            End If
            pd = Nothing
            ws.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, "Exception :" & ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub UpdateKioskPromotionExpired(MsKioskID As Long)
        Try
            'ตรวจสอบวันที่สิ้นสุด Promotion และ Update ให้ Expired
            Dim vDate As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim sql As String = "select kp.id "
            sql += " from MS_KIOSK_PROMOTION kp "
            sql += " where  convert(varchar(8),kp.end_date,112) < @_DATE_NOW "
            sql += " and kp.publish_status=1"  '1=Publish
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetText("@_DATE_NOW", vDate)

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    sql = "update MS_KIOSK_PROMOTION "
                    sql += " set publish_status=2"   '2=Expired
                    sql += " , updated_by=@_UPDATED_BY "
                    sql += " , updated_date=getdate()"
                    sql += " where id=@_ID"

                    ReDim p(2)
                    p(0) = KioskDB.SetText("@_UPDATED_BY", Environment.NewLine)
                    p(1) = KioskDB.SetBigInt("@_ID", Convert.ToInt64(dr("id")))

                    Dim kTrans As New KioskTransactionDB
                    Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, kTrans.Trans, p)
                    If ret.IsSuccess = True Then
                        kTrans.CommitTransaction()
                    Else
                        kTrans.RollbackTransaction()
                        LogFileENG.CreateErrorLogAgent(MsKioskID, ret.ErrorMessage)
                    End If
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateExceptionLogAgent(MsKioskID, "Exception :" & ex.Message, ex.StackTrace)
        End Try
    End Sub
#End Region

#Region "Sync Server Promotion Data"
    Public Shared Sub SyncLocationPromotion()
        Try
            Dim sql As String = "select p.id ms_promotion_id, pl.id ms_promotion_location_id, pl.ms_location_id,  "
            sql += " p.promotion_code, p.promotion_name, p.start_date, p.end_date, p.publish_status"
            sql += " From MS_PROMOTION p "
            sql += " inner join MS_PROMOTION_LOCATION pl on p.id=pl.ms_promotion_id"
            sql += " where p.publish_status='1' and pl.sync_to_location='N' "

            Dim dt As DataTable = ServerDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Dim MsPromotionID As Long = Convert.ToInt64(dt.Rows(0)("ms_promotion_id"))

                sql = "select ph.ms_cabinet_model_id, ph.promotion_hour, ph.service_rate "
                sql += " From MS_PROMOTION_HOUR ph "
                sql += " where ph.ms_promotion_id=@_MS_PROMOTION_ID"
                sql += " order by ph.ms_cabinet_model_id,ph.promotion_hour"

                Dim p(1) As SqlParameter
                p(0) = ServerDB.SetBigInt("@_MS_PROMOTION_ID", MsPromotionID)
                Dim hDt As DataTable = ServerDB.ExecuteTable(sql, p)
                If hDt.Rows.Count > 0 Then

                    Dim trans As New ServerTransactionDB
                    'Delete MS_LOCATION_PROMOTION Data
                    sql = "delete from MS_LOCATION_PROMOTION_HOUR  "
                    sql += " where ms_location_promotion_id in (select id from MS_LOCATION_PROMOTION where ms_promotion_id=@_MS_PROMOTION_ID)"
                    ReDim p(1)
                    p(0) = ServerDB.SetBigInt("@_MS_PROMOTION_ID", MsPromotionID)

                    Dim ret As ServerLinqDB.ConnectDB.ExecuteDataInfo = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
                    If ret.IsSuccess = True Then

                        sql = "delete from MS_LOCATION_PROMOTION_SYNC  "
                        sql += " where ms_location_promotion_id in (select id from MS_LOCATION_PROMOTION where ms_promotion_id=@_MS_PROMOTION_ID)"
                        ReDim p(1)
                        p(0) = ServerDB.SetBigInt("@_MS_PROMOTION_ID", MsPromotionID)

                        ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)

                        If ret.IsSuccess = True Then

                            sql = "delete from MS_LOCATION_PROMOTION  "
                            sql += " where ms_promotion_id=@_MS_PROMOTION_ID"
                            ReDim p(1)
                            p(0) = ServerDB.SetBigInt("@_MS_PROMOTION_ID", MsPromotionID)

                            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
                            If ret.IsSuccess = False Then
                                trans.RollbackTransaction()
                                LogFileENG.CreateServerErrorLogAgent(ret.ErrorMessage)
                            End If
                        Else
                            trans.RollbackTransaction()
                            LogFileENG.CreateServerErrorLogAgent(ret.ErrorMessage)
                        End If
                    Else
                        trans.RollbackTransaction()
                        LogFileENG.CreateServerErrorLogAgent(ret.ErrorMessage)
                    End If

                    If ret.IsSuccess = True Then
                        'Loop ตาม Location
                        For Each dr As DataRow In dt.Rows
                            Dim lnq As New MsLocationPromotionServerLinqDB
                            lnq.MS_PROMOTION_ID = MsPromotionID
                            lnq.MS_LOCATION_ID = Convert.ToInt64(dr("ms_location_id"))
                            lnq.PROMOTION_CODE = dr("promotion_code")
                            lnq.PROMOTION_NAME = dr("promotion_name")
                            lnq.START_DATE = Convert.ToDateTime(dr("start_date"))
                            lnq.END_DATE = Convert.ToDateTime(dr("end_date"))
                            lnq.PUBLISH_STATUS = dr("publish_status")

                            ret = lnq.InsertData(Environment.MachineName, trans.Trans)
                            If ret.IsSuccess = True Then
                                'แต่ละ Location ให้ Loop ตาม Data เป็นรายชั่วโมง
                                For Each hDr As DataRow In hDt.Rows
                                    Dim hLnq As New MsLocationPromotionHourServerLinqDB
                                    hLnq.MS_LOCATION_PROMOTION_ID = lnq.ID
                                    hLnq.MS_CABINET_MODEL_ID = Convert.ToInt64(hDr("ms_cabinet_model_id"))
                                    hLnq.PROMOTION_HOUR = Convert.ToInt16(hDr("promotion_hour"))
                                    hLnq.SERVICE_RATE = Convert.ToInt16(hDr("service_rate"))

                                    ret = hLnq.InsertData(Environment.MachineName, trans.Trans)
                                    If ret.IsSuccess = False Then
                                        trans.RollbackTransaction()
                                        LogFileENG.CreateServerErrorLogAgent(ret.ErrorMessage)
                                        Exit Sub
                                    End If
                                Next
                            Else
                                trans.RollbackTransaction()
                                LogFileENG.CreateServerErrorLogAgent(ret.ErrorMessage)
                                Exit Sub
                            End If


                            'Update MS_PROMOTION_LOCATION.sync_to_location
                            If ret.IsSuccess = True Then
                                Dim lLnq As New MsPromotionLocationServerLinqDB
                                lLnq.GetDataByPK(dr("ms_promotion_location_id"), trans.Trans)
                                If lLnq.ID > 0 Then
                                    lLnq.SYNC_TO_LOCATION = "Y"

                                    ret = lLnq.UpdateData(Environment.MachineName, trans.Trans)
                                    If ret.IsSuccess = False Then
                                        trans.RollbackTransaction()
                                        LogFileENG.CreateServerErrorLogAgent(ret.ErrorMessage)
                                        Exit Sub
                                    End If
                                End If
                                lLnq = Nothing
                            End If

                            LogFileENG.CreateServerLogAgent("Update MS_LOCATION_PROMOTION is ms_promotion_id=" & MsPromotionID & "&LocationID=" & Convert.ToInt64(dr("ms_location_id")))
                        Next
                    End If

                    'ถ้าทุกอย่างเสร็จค่อย Commit ทีเดียว
                    If ret.IsSuccess = True Then
                        trans.CommitTransaction()

                    End If
                End If
                hDt.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFileENG.CreateServerExceptionLogAgent(ex.Message, ex.StackTrace)
        End Try
    End Sub
#End Region

    Public Shared Sub TestTraceFrame(para As String)
        LogFileENG.TestTraceFrame()
    End Sub
End Class
