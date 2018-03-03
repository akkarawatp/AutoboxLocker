Imports System
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Drawing
Imports System.Web.Configuration
Imports System.Data.SqlClient
Imports ServerLinqDB.TABLE
Imports ServerLinqDB.ConnectDB
Imports OfficeOpenXml

Public Class LockerBL

    'Dim Conn As SqlConnection = ServerDB.GetConnection

    Public Enum ReportPeriod
        Unknown = 0
        Hourly = 1
        Daily = 2
        Monthly = 3
        Yearly = 4
    End Enum

    Public Sub SetTextIntKeypress(txt As TextBox)
        txt.Attributes.Add("OnKeyPress", "ChkMinusInt(this,event);")
        txt.Attributes.Add("onKeyDown", "CheckKeyNumber(event);")
    End Sub

#Region "__DDL"
    Public Sub Bind_DDL_Location(ByRef ddl As DropDownList, ByVal UserName As String)
        Dim dt As DataTable = GetList_Location_ByUserLoc(UserName)

        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("...", ""))
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim Item As New ListItem(dt.Rows(i).Item("location_name"), dt.Rows(i).Item("id"))
            ddl.Items.Add(Item)
        Next
        ddl.SelectedIndex = 0
    End Sub
    Public Sub Bind_DDL_CabinetModel(ddl As DropDownList, Optional CabinetModelID As Long = 0)
        Dim DT As DataTable = GetList_CabinetModel(CabinetModelID)

        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("...", ""))
        For i As Integer = 0 To DT.Rows.Count - 1
            Dim Item As New ListItem(DT.Rows(i).Item("model_name"), DT.Rows(i).Item("id"))
            ddl.Items.Add(Item)
        Next
        ddl.SelectedValue = ""

        If CabinetModelID > 0 Then
            ddl.SelectedValue = CabinetModelID
        End If
    End Sub

    Public Sub Bind_DDL_Kiosk(UserName As String, ByRef ddl As DropDownList, ByVal LocationID As Long, Optional ByVal KioskID As Integer = 0)
        Dim DT As DataTable = GetList_Kiosk(UserName, 0)

        If LocationID <> 0 Then
            DT.DefaultView.RowFilter = "ms_location_id='" & LocationID & "'"
            DT = DT.DefaultView.ToTable
        End If

        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("...", ""))

        For i As Integer = 0 To DT.Rows.Count - 1
            Dim Item As New ListItem(DT.Rows(i).Item("com_name"), DT.Rows(i).Item("ms_kiosk_id"))
            ddl.Items.Add(Item)
        Next
        ddl.SelectedIndex = 0

        If KioskID <> 0 Then
            For i As Integer = 0 To ddl.Items.Count - 1
                If ddl.Items(i).Value = KioskID Then
                    ddl.SelectedIndex = i
                    Exit For
                End If
            Next
        End If

    End Sub
    Public Sub Bind_DDL_Sales_Month(ByRef DDL As DropDownList)
        Dim DT As DataTable = Get_Report_Sales_Date_Range(0, False)

        Dim Start_M As Integer = Now.Month
        Dim Start_Y As Integer = Now.Year
        Dim End_M As Integer = Now.Month
        Dim End_Y As Integer = Now.Year
        If DT.Rows.Count > 0 Then
            Start_M = DT.Rows(0).Item("Start_M")
            Start_Y = DT.Rows(0).Item("Start_Y")
            End_M = DT.Rows(0).Item("End_M")
            End_Y = DT.Rows(0).Item("End_Y")
        End If
        If Start_Y > 2500 Then Start_Y -= 543
        If End_Y > 2500 Then End_Y -= 543

        Dim StartDate As New DateTime(Start_Y, Start_M, 1)
        Dim EndDate As New DateTime(End_Y, End_M, 1)
        Dim ThisMonth As DateTime = StartDate

        DDL.Items.Clear()
        DDL.Items.Add(New ListItem("...", 0))

        While DateDiff(DateInterval.Month, ThisMonth, EndDate) >= 0
            Dim Item As New ListItem()
            Dim M As Integer = DatePart(DateInterval.Month, ThisMonth)
            Dim Y As Integer = DatePart(DateInterval.Year, ThisMonth)
            If Y > 2500 Then Y -= 543
            Item.Text = Converter.ToMonthNameEN(M) & " " & Y
            Item.Value = ThisMonth.Year & ThisMonth.Month.ToString.PadLeft(2, "0")
            ThisMonth = DateAdd(DateInterval.Month, 1, ThisMonth)
            DDL.Items.Add(Item)
        End While
    End Sub

    Public Sub Bind_DDL_Sales_Year(ByRef DDL As DropDownList)
        Dim DT As DataTable = Get_Report_Sales_Date_Range(0, False)

        Dim Start_Y As Integer = Now.Year
        Dim End_Y As Integer = Now.Year
        If DT.Rows.Count > 0 Then
            Start_Y = DT.Rows(0).Item("Start_Y")
            End_Y = DT.Rows(0).Item("End_Y")
        End If
        If Start_Y > 2500 Then Start_Y -= 543
        If End_Y > 2500 Then End_Y -= 543

        DDL.Items.Clear()
        DDL.Items.Add(New ListItem("...", 0))

        For i As Integer = Start_Y To End_Y
            Dim Item As New ListItem()
            Item.Text = i
            Item.Value = i
            DDL.Items.Add(Item)
        Next
    End Sub

    Public Function Get_Report_Sales_Date_Range(ByVal KO_ID As Integer, ByVal OnlyCompleted As Boolean) As DataTable
        Dim SQL As String = "SELECT MIN(trans_start_time) TXN_Start,MAX(trans_end_time) TXN_End" & vbLf
        SQL &= " FROM TB_DEPOSIT_TRANSACTION" & vbLf


        Dim DT As DataTable = ServerDB.ExecuteTable(SQL)
        DT.Columns.Add("Start_M", GetType(Integer))
        DT.Columns.Add("Start_Y", GetType(Integer))
        DT.Columns.Add("End_M", GetType(Integer))
        DT.Columns.Add("End_Y", GetType(Integer))

        If DT.Rows.Count > 0 AndAlso Not IsDBNull(DT.Rows(0).Item("TXN_Start")) AndAlso Not IsDBNull(DT.Rows(0).Item("TXN_End")) Then
            Dim DR As DataRow = DT.Rows(0)
            Dim TXN_Start As DateTime = DR("TXN_Start")
            Dim TXN_End As DateTime = DR("TXN_End")
            DR("Start_M") = DatePart(DateInterval.Month, TXN_Start)
            DR("Start_Y") = DatePart(DateInterval.Year, TXN_Start)
            DR("End_M") = DatePart(DateInterval.Month, TXN_End)
            DR("End_Y") = DatePart(DateInterval.Year, TXN_End)
        Else
            DT.Rows.Clear()
        End If

        DT.TableName = "Data"
        Return DT

    End Function
#End Region

#Region "__Master Kiosk"
    Public Function GetList_Location_ByUserLoc(ByVal user_name As String) As DataTable
        Dim sql As String = " Select distinct id,location_name from MS_LOCATION"
        sql &= " where 1 = 1 "
        If (user_name <> "") Then
            sql &= " And id in (select ms_location_id from MS_USER_LOCATION where username=@_USERNAME)"
        End If
        sql &= " order by location_name"

        Dim p(1) As sqlparameter
        p(0) = serverdb.settext("@_USERNAME", user_name)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)

        Return DT
    End Function

    Public Function GetLockerInformation(kiosk_id As Integer) As DataTable
        Dim sql As String = " Select l.id ms_locker_id, c.order_layout, l.locker_name, l.current_available"
        sql &= " From ms_cabinet c"
        sql &= " inner Join ms_locker l on c.id=l.ms_cabinet_id and l.ms_kiosk_id=c.ms_kiosk_id"
        sql &= " where l.ms_kiosk_id = @_KIOSK_ID"
        sql &= " And l.active_status='Y' and c.active_status='Y'"
        sql &= " order by c.order_layout"
        Dim dt As New DataTable
        Dim p(1) As sqlparameter
        p(0) = serverdb.setint("@_KIOSK_ID", kiosk_id)
        dt = serverdb.executetable(sql, p)
        Return dt
    End Function

    Public Function GetList_Device(ByVal Device_ID As Integer, ByVal IncludedInActive As String) As DataTable
        Dim sql As String = " Select d.id ms_device_id, d.device_name_en, dt.id ms_device_type_id, dt.device_type_name_en,"
        sql &= " d.unit_value, d.max_qty, d.warning_qty, d.critical_qty, DT.movement_direction,"
        sql &= " d.icon_white, d.icon_green, d.icon_red, d.device_order"
        sql &= " From ms_device d"
        sql &= " inner Join ms_device_type dt On d.ms_device_type_id=dt.id"
        If IncludedInActive <> "" Then
            sql &= " And d.active_status = @_IncludedInActive"
        End If
        If Device_ID <> 0 Then
            sql &= " where d.id = @_Device_ID"
        End If
        sql &= " order by d.device_order"

        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetText("@_IncludedInActive", IncludedInActive)
        p(1) = ServerDB.SetInt("@_Device_ID", Device_ID)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)

        Return dt
    End Function

    Public Function GetList_Kiosk_Device(ByVal KO_ID As Integer, ByVal IncludeInActive As String) As DataTable
        If KO_ID = 0 Then
            Return GetList_Kiosk_Device_Default()
        Else
            Return GetList_Kiosk_Device_Existing(KO_ID, IncludeInActive)
        End If
    End Function

    Public Function GetList_Kiosk_Device_Default() As DataTable
        Dim sql As String = ""
        sql &= " Select cast(null As int) ms_kiosk_id,d.id ms_device_id,D.device_name_en,dt.id ms_device_type_id,dt.device_type_name_en,"
        sql &= " d.unit_value,d.max_qty,d.warning_qty,d.critical_qty,cast(null As int) current_qty,dt.Movement_Direction,"
        sql &= " ds.id ms_device_status_id,ds.status_name,ds.is_problem,"
        sql &= " cast(null As datetime) start_time,cast(null As datetime) end_time,d.device_order"
        sql &= " from ms_device_type dt"
        sql &= " inner join ms_device d On  d.ms_device_type_id=dt.id"
        sql &= " left join ms_device_status ds On ds.id=2"
        sql &= " where d.active_status='Y'"
        sql &= " And d.ms_device_type_id In (1,2,3,4,5)"
        sql &= " order by d.device_order"

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql)
        Return dt
    End Function

    Public Function GetList_Kiosk_Device_Existing(ByVal Kiosk_ID As Integer, ByVal IncludeInActive As String) As DataTable

        Dim sql As String = "select k.id ms_kiosk_id, d.id ms_device_id, d.device_name_en, d.ms_device_type_id, dt.device_type_name_en, "
        sql &= " d.unit_value,"
        sql &= " isnull(kd.max_qty, d.max_qty) max_qty,"
        sql &= " isnull(kd.warning_qty, d.warning_qty) warning_qty,"
        sql &= " isnull(kd.critical_qty, d.critical_qty) critical_qty,kd.current_qty,dt.movement_direction,"
        sql &= " ds.id ms_device_status_id, ds.status_name, ds.is_problem, cast(null As datetime) start_time, cast(null As datetime) end_time,"
        sql &= " d.device_order"
        sql &= " From ms_kiosk k "
        sql &= " inner Join ms_kiosk_device kd On k.id=kd.ms_kiosk_id"
        sql &= " inner Join ms_device d On d.id=kd.ms_device_id"
        sql &= " inner Join ms_device_type dt On d.ms_device_type_id= dt.id"
        sql &= " inner Join ms_device_status ds on kd.ms_device_status_id=ds.id"
        sql &= " where 1=1 "
        If Kiosk_ID <> 0 Then
            sql &= " and k.id =@_Kiosk_ID"
        End If
        If IncludeInActive <> "" Then
            sql &= " and d.active_status = @_IncludedInActive"
        End If
        sql &= " order by d.device_order"

        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetText("@_IncludedInActive", IncludeInActive)
        p(1) = ServerDB.SetInt("@_Kiosk_ID", Kiosk_ID)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt

    End Function

    Public Function IsDupplicate_Kiosk(ip_address As String, mac_address As String, edit_kiosk_id As String) As Boolean
        Dim sql As String = ""
        sql &= " Select 'y' from ms_kiosk where (ip_address=@_IP_Address or mac_address=@_Mac_Address) and id <> @_KIOSK_ID"

        Dim p(3) As SqlParameter
        p(0) = ServerDB.SetText("@_IP_Address", ip_address)
        p(1) = ServerDB.SetText("@_Mac_Address", mac_address)
        p(2) = ServerDB.SetText("@_KIOSK_ID", edit_kiosk_id)
        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function GetList_Kiosk(user_name As String, ByVal kiosk_id As Integer) As DataTable
        Dim sql As String = ""

        sql &= " select id ms_kiosk_id,ms_location_id,com_name,ip_address,mac_address"
        sql &= " ,active_status,updated_by,updated_date, online_status"
        sql &= " from ms_kiosk "
        sql &= " where convert(varchar(8),getdate(),112) between convert(varchar(8),valid_start_date,112) and convert(varchar(8),valid_expire_date,112) "
        If kiosk_id <> 0 Then
            sql &= " And id =@_KIOSK_ID"
        End If
        If user_name <> "" Then
            sql &= " and ms_location_id IN (select ms_location_id from MS_USER_LOCATION where username=@_USER_NAME)"
        End If

        sql &= " order by id "

        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetText("@_USER_NAME", user_name)
        p(1) = ServerDB.SetInt("@_KIOSK_ID", kiosk_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_DeviceStatus(ByVal ms_device_id As Integer, ByVal ms_device_type_id As Integer) As DataTable
        Dim sql As String = "select id ms_device_status_id,ms_device_type_id,is_problem from ms_device_status where 1=1 "
        If ms_device_id <> 0 Then
            sql &= " and id =@_MS_DEVICE_ID"
        End If
        If ms_device_type_id Then
            sql &= " and ms_device_type_id =@_MS_DEVICE_TYPE_ID"
        End If

        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetInt("@_MS_DEVICE_ID", ms_device_id)
        p(1) = ServerDB.SetInt("@_MS_DEVICE_TYPE_ID", ms_device_type_id)
        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function DeleteMasterKiosk(master_kiosk_id As String) As Boolean
        Dim sql As String = "delete from ms_kiosk_device where ms_kiosk_id=@_KIOSK_ID"
        Dim pd(1) As SqlParameter
        pd(0) = ServerDB.SetText("@_KIOSK_ID", master_kiosk_id)

        Dim trans As New ServerTransactionDB
        Dim ret As New ExecuteDataInfo
        ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, pd)
        If ret.IsSuccess = False Then
            trans.RollbackTransaction()
            Return False
        End If

        sql = "delete from ms_kiosk where id=@_KIOSK_ID"
        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_KIOSK_ID", master_kiosk_id)
        ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
        If ret.IsSuccess = False Then
            trans.RollbackTransaction()
            Return False
        End If

        trans.CommitTransaction()
        Return True
    End Function
#End Region

#Region "_Master Location"
    Public Function GetList_Location(location_code As String) As DataTable
        Dim sql As String = " select l.id,location_code,location_name, l.gross_profit_rate,l.active_status,count(k.id) total_kiosk, isnull(sr.id,0) ms_service_rate_id"
        sql &= " from ms_location l "
        sql &= " left join ms_kiosk k on l.id = k.ms_location_id "
        sql &= " left join MS_SERVICE_RATE sr on l.id=sr.ms_location_id"
        sql &= " where 1=1 "
        If location_code <> "" Then
            sql &= " And location_code = @_LOCATION_CODE"
        End If
        sql &= " group by l.id,location_code,location_name,l.gross_profit_rate, l.active_status, isnull(sr.id,0)"
        sql &= " order by location_code,location_name "

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_LOCATION_CODE", location_code)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function DeleteMasterLocation(location_code As String) As String
        Dim trans As New ServerTransactionDB
        Try
            Dim sql As String
            sql = "Select 'y' from ms_kiosk where ms_location_id=(select top 1 id from ms_location where location_code=@_LOCATION_CODE)"
            Dim p_k(1) As SqlParameter
            p_k(0) = ServerDB.SetText("@_LOCATION_CODE", location_code)
            Dim dt As New DataTable
            dt = ServerDB.ExecuteTable(sql, trans.Trans, p_k)
            If dt.Rows.Count > 0 Then
                Return "This Location is using by kiosk"
            End If

            sql = "Select 'y' from ms_user_location where ms_location_id=(select top 1 id from ms_location where location_code=@_LOCATION_CODE)"
            Dim p_ul(1) As SqlParameter
            p_ul(0) = ServerDB.SetText("@_LOCATION_CODE", location_code)
            dt = ServerDB.ExecuteTable(sql, trans.Trans, p_ul)
            If dt.Rows.Count > 0 Then
                Return "This Location is using by user location"
            End If

            sql = "delete from ms_location where location_code=@_LOCATION_CODE"
            Dim p_l(1) As SqlParameter
            p_l(0) = ServerDB.SetText("@_LOCATION_CODE", location_code)

            Dim ret As New ExecuteDataInfo
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_l)
            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                Return ret.ErrorMessage
            End If
            trans.CommitTransaction()
            Return ""
        Catch ex As Exception
            trans.RollbackTransaction()
            Return ex.ToString()
        End Try
    End Function
#End Region

#Region "_Kiosk Monitoring"
    Public Function Alarm_Overview(ByVal kiosk_id As Integer, username As String) As DataTable
        Dim sql As String = "select k.id, k.com_name, l.location_name, k.ip_address, k.mac_address," & vbNewLine
        sql &= " k.online_status available_status, k.today_available, k.hw_isproblem, " & vbNewLine
        sql &= " k.cpu_usage, k.ram_usage, k.disk_usage, k.last_sync_time, " & vbNewLine
        sql &= " 	 isnull((select top 1 is_problem " & vbNewLine
        sql &= " 	 from v_kiosk_device_info " & vbNewLine
        sql &= " 	 where ms_kiosk_id=k.id" & vbNewLine
        sql &= "     And is_problem ='Y' and device_active_status='Y'),'N') peripheral_condition," & vbNewLine
        sql &= " 	 isnull((select top 1 case stock_condition when 'CRITICAL' then 'Y' else 'N' end" & vbNewLine
        sql &= " 	 from v_kiosk_device_info " & vbNewLine
        sql &= " 	 where ms_kiosk_id=k.id" & vbNewLine
        sql &= "     And stock_condition='CRITICAL' and device_active_status='Y' ),'N') stock_level"
        sql &= " From MS_KIOSK k" & vbNewLine
        sql &= " inner join ms_location l on l.id=k.ms_location_id where 1=1" & vbNewLine
        sql += " and convert(varchar(8),getdate(),112) between convert(varchar(8),k.valid_start_date,112) and convert(varchar(8),k.valid_expire_date,112) " & vbNewLine
        If kiosk_id <> 0 Then
            sql &= " and k.id=@_KIOSK_ID" & vbNewLine
        End If
        If username <> "" Then
            sql &= " and k.ms_location_id in (select ms_location_id from ms_user_location where username=@_USERNAME)" & vbNewLine
        End If
        sql &= " order by com_name"

        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetInt("@_KIOSK_ID", kiosk_id)
        p(1) = ServerDB.SetText("@_USERNAME", username)
        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function
#End Region

#Region "_Setting Alarm"

    Public Function GetList_Alarm_Group() As DataTable
        Dim sql As String = "  Select  DISTINCT AGROUP.ID,ALARM_GROUP_CODE,ALARM_GROUP_NAME, ActiveStatus "
        sql &= " ,(SELECT COUNT(AGMON.MS_MASTER_MONITORING_ALARM_ID) FROM TB_ALARM_GROUP_MONITORING AGMON WHERE AGMON.TB_ALARM_GROUP_ID = AGROUP.ID) COUNT_ALARM"
        sql &= " ,(Select COUNT(AMAIL.ID) FROM TB_ALARM_GROUP_EMAIL AMAIL WHERE AMAIL.TB_ALARM_GROUP_ID = AGROUP.ID) COUNT_EMAIL"
        sql &= " From TB_ALARM_GROUP AGROUP"

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql)
        Return dt
    End Function

    Public Function Get_Alarm_Group_Info(group_id As String) As DataTable
        Dim sql As String = ""
        sql &= " SELECT * "
        sql &= " FROM TB_ALARM_GROUP AGROUP "
        sql &= " WHERE ID=@_GROUP_ID"

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_GROUP_ID", group_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function Drop_Alarm(ByVal group_id As String) As Boolean
        Dim trans As New ServerTransactionDB
        Dim sql As String
        Try
            Dim ret As ExecuteDataInfo
            sql = "DELETE FROM TB_ALARM_GROUP_MONITORING WHERE TB_ALARM_GROUP_ID=@_GROUP_ID"
            Dim p_m(1) As SqlParameter
            p_m(0) = ServerDB.SetText("@_GROUP_ID", group_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_m)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM TB_ALARM_GROUP_COMPUTER WHERE TB_ALARM_GROUP_ID=@_GROUP_ID"
            Dim p_c(1) As SqlParameter
            p_c(0) = ServerDB.SetText("@_GROUP_ID", group_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_c)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM TB_ALARM_GROUP_EMAIL WHERE TB_ALARM_GROUP_ID=@_GROUP_ID"
            Dim p_e(1) As SqlParameter
            p_e(0) = ServerDB.SetText("@_GROUP_ID", group_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_e)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM TB_ALARM_GROUP WHERE ID=@_GROUP_ID"
            Dim p_g(1) As SqlParameter
            p_g(0) = ServerDB.SetText("@_GROUP_ID", group_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_g)

            If ret.IsSuccess = False Then
                Return False
            End If

            trans.CommitTransaction()
            Return True
        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try
    End Function

    Public Function GetList_Kiosk_Alarm(ByVal group_id As String) As DataTable
        Dim sql As String = "SELECT ID,ALARM_CODE,ALARM_PROBLEM,ENG_DESC,SMS_MESSAGE,"
        sql &= " ISNULL((SELECT 'T' FROM TB_ALARM_GROUP_MONITORING TBMON WHERE TBMON.MS_MASTER_MONITORING_ALARM_ID = MSMON.ID AND TBMON.TB_ALARM_GROUP_ID=@_GROUP_ID) ,'F') SELECTED"
        sql &= " From MS_MASTER_MONITORING_ALARM MSMON"
        sql &= " WHERE MS_MASTER_MONITORING_TYPE_ID BETWEEN 1 AND 12"
        sql &= " ORDER BY ALARM_CODE"
        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_GROUP_ID", group_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function Get_Computer_Alarm_ByGroup(group_id As String) As DataTable
        Dim sql As String = "Select ID,TB_ALARM_GROUP_ID,MACADDRESS FROM TB_ALARM_GROUP_COMPUTER WHERE TB_ALARM_GROUP_ID=@_GROUP_ID"
        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_GROUP_ID", group_id)
        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)

        Return dt

    End Function

    Public Function Get_Email_Alarm_ByGroup(GROUP_ID As String) As DataTable
        Dim sql As String = "Select  ID,TB_ALARM_GROUP_ID,E_MAIL FROM TB_ALARM_GROUP_EMAIL WHERE TB_ALARM_GROUP_ID=@_GROUP_ID"
        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_GROUP_ID", GROUP_ID)
        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)

        Return dt
    End Function



#End Region

#Region "Role&User"
    Public Function GetList_User_Role(username As String, active_status As String) As DataTable
        Dim sql As String = "select r.id,role_name,active_status,ms_role_id,case isnull(ms_role_id,'') when '' then 'N' else 'Y' end Selected "
        sql &= " From ms_role r left join ms_user_role ur on r.id = ur.ms_role_id and ur.username= @_user_name"
        sql &= " where active_status = @_active_status"
        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetText("@_user_name", username)
        p(1) = ServerDB.SetText("@_active_status", active_status)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_User_Location(username As String, active_status As String) As DataTable
        Dim sql As String = "select l.id,location_code,location_name,active_status,ms_location_id,case isnull(ms_location_id,'') when '' then 'N' else 'Y' end Selected "
        sql &= " From ms_location l left join ms_user_location ml on l.id=ml.ms_location_id and ml.username=@_user_name"
        sql &= " where active_status =@_active_status  "
        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetText("@_user_name", username)
        p(1) = ServerDB.SetText("@_active_status", active_status)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_User_Functional(AuthorizeID As Long, FunctionalZoneID As Long, FunctionalID As Long, Username As String) As DataTable
        Dim ret As DataTable
        Try
            Dim p(4) As SqlParameter
            Dim Filter As String = " f.active_status='Y' and ap.id=1 "   'ap.id=1  คือ Web Admin
            If AuthorizeID <> 0 Then
                Filter &= " and rf.ms_authorization_id=@_AUTHORIZE_ID "
                p(0) = ServerDB.SetBigInt("@_AUTHORIZE_ID", AuthorizeID)
            End If
            If FunctionalZoneID <> 0 Then
                Filter &= " and f.ms_functional_zone_id=@_FUNCTIONAL_ZONE_ID "
                p(1) = ServerDB.SetBigInt("@_FUNCTIONAL_ZONE_ID", FunctionalZoneID)
            End If
            If FunctionalID <> 0 Then
                Filter &= " and f.id=@_FUNCTIONAL_ID "
                p(2) = ServerDB.SetBigInt("@_FUNCTIONAL_ID", FunctionalID)
            End If
            If Username <> "" Then
                Filter &= " and ur.username=@_USERNAME "
                p(3) = ServerDB.SetText("@_USERNAME", Username)
            End If

            Dim sql As String = "select ur.username, rf.ms_authorization_id, au.authorization_name, ur.ms_role_id, " & Environment.NewLine
            sql += " fz.ms_application_id, ap.app_name, rf.ms_functional_id, f.functional_name " & Environment.NewLine
            sql += " from MS_USER_ROLE ur " & Environment.NewLine
            sql += " inner join MS_ROLE_FUNCTIONAL rf On ur.ms_role_id=rf.ms_role_id " & Environment.NewLine
            sql += " inner join MS_FUNCTIONAL f on f.id=rf.ms_functional_id " & Environment.NewLine
            sql += " inner join MS_FUNCTIONAL_ZONE fz On fz.id=f.ms_functional_zone_id " & Environment.NewLine
            sql += " inner join MS_APPLICATION ap on ap.id=fz.ms_application_id " & Environment.NewLine
            sql += " inner join MS_AUTHORIZATION au On au.id=rf.ms_authorization_id " & Environment.NewLine
            sql += " where " & Filter
            sql += " order by ur.username, rf.ms_functional_id" & Environment.NewLine
            ret = ServerDB.ExecuteTable(sql, p)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Function Drop_User(ByVal userid As Long, username As String) As Boolean
        Dim trans As New ServerTransactionDB
        Dim sql As String
        Try


            Dim ret As ExecuteDataInfo
            sql = "DELETE FROM MS_USER_ROLE WHERE USERNAME=@_USERNAME"
            Dim p_m(1) As SqlParameter
            p_m(0) = ServerDB.SetText("@_USERNAME", username)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_m)

            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "DELETE FROM MS_USER_LOCATION WHERE USERNAME=@_USERNAME"
            Dim p_c(1) As SqlParameter
            p_c(0) = ServerDB.SetText("@_USERNAME", username)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_c)

            If ret.IsSuccess = False Then
                trans.RollbackTransaction()
                Return False
            End If

            '// delete user from webservice
            Dim ret_w As ExecuteDataInfo
            ret_w = Engine.UserENG.DeleteUserAccount(userid)

            If ret_w.IsSuccess = False Then
                trans.RollbackTransaction()
                Return False
            End If

            trans.CommitTransaction()
            Return True
        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try
    End Function
#End Region

#Region "PageAuthorized"

    Public Enum AuthorizedLevel
        None = 0
        View = 1
        Edit = 2
    End Enum

    Public Function GetFunctionalAuthorized(ByVal UDT As DataTable, ByVal FunctionalID As Integer) As AuthorizedLevel
        Dim Result As AuthorizedLevel = AuthorizedLevel.None
        Try
            UDT.DefaultView.RowFilter = "ms_functional_id=" & FunctionalID
            Result = UDT.DefaultView(0).Item("ms_authorization_id")
            UDT.DefaultView.RowFilter = ""
        Catch : End Try
        Return Result
    End Function
#End Region

#Region "SettingRole"
    Public Enum Application_Type
        ADMIN_WEB = 1
        KIOSK_STAFF_CONSOLE = 2
    End Enum
    Public Function GetList_Role(role_id As Integer) As DataTable
        Dim sql As String = "Select R.ID Role_ID,R.Role_Name," & Environment.NewLine
        sql &= " SUM(Case When App.ID=1 And RF.ID>0 Then 1 Else 0 End) Admin_Web," & Environment.NewLine
        sql &= " SUM(Case When App.ID=2 And RF.ID>0 Then 1 Else 0 End) Staff_Console," & Environment.NewLine
        sql &= " ISNULL(U.Users,0) Users,R.active_status" & Environment.NewLine
        sql &= " FROM ms_Role R" & Environment.NewLine
        sql &= " LEFT JOIN ms_Role_Functional RF On R.ID=RF.MS_ROLE_ID" & Environment.NewLine
        sql &= " And RF.ID > 0" & Environment.NewLine
        sql &= " Left JOIN ms_Functional FN On RF.MS_FUNCTIONAL_ID=FN.ID" & Environment.NewLine
        sql &= " LEFT JOIN ms_Functional_Zone FZ On FN.MS_FUNCTIONAL_ZONE_ID=FZ.ID" & Environment.NewLine
        sql &= " LEFT JOIN ms_Application App On FZ.MS_APPLICATION_ID=App.ID" & Environment.NewLine
        sql &= " LEFT JOIN" & Environment.NewLine
        sql &= " (" & Environment.NewLine
        sql &= " Select UR.MS_ROLE_ID,COUNT(USERNAME) Users" & Environment.NewLine
        sql &= " FROM ms_User_Role UR" & Environment.NewLine
        sql &= " GROUP BY UR.MS_ROLE_ID) U On R.ID=U.MS_ROLE_ID" & Environment.NewLine
        sql &= " WHERE FN.active_status='Y' "
        If role_id > 0 Then
            sql &= " and R.ID=@_ROLE_ID" & Environment.NewLine
        End If
        sql &= " GROUP BY R.ID,R.Role_Name,U.Users,R.Active_Status" & Environment.NewLine
        sql &= " ORDER BY R.ID" & Environment.NewLine

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetInt("@_ROLE_ID", role_id)
        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_Functional_Zone(application_id As Integer, function_zone_id As Integer) As DataTable
        Dim sql As String = "SELECT AP.ID App_ID,AP.App_Name," & Environment.NewLine
        sql &= " FZ.ID FN_Zone_ID,FZ.FN_Zone_Name" & Environment.NewLine
        sql &= " From MS_Application AP" & Environment.NewLine
        sql &= " INNER JOIN MS_Functional_Zone FZ On AP.ID=FZ.MS_APPLICATION_ID WHERE 1=1 " & Environment.NewLine
        If application_id > 0 Then
            sql &= " and AP.ID=@_application_id "
        End If
        If function_zone_id > 0 Then
            sql &= " And FZ.ID =@_function_id" & Environment.NewLine
        End If

        sql &= " ORDER BY AP.App_Order,FZ.FN_Zone_Order" & Environment.NewLine
        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetInt("@_application_id", application_id)
        p(1) = ServerDB.SetInt("@_function_id", function_zone_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_Functional(ByVal application_id As Integer, ByVal role_id As Integer) As DataTable
        Dim FN As DataTable = GetList_Functional(application_id, 0, 0)
        FN.Columns.Add("Auth_ID", GetType(Integer))
        Dim Auth As DataTable
        If role_id = 0 Then
            Auth = GetList_Role_Functional(application_id, 0, 0, -1)
        Else
            Auth = GetList_Role_Functional(application_id, 0, 0, role_id)
        End If
        For i As Integer = 0 To FN.Rows.Count - 1
            Auth.DefaultView.RowFilter = "FN_ID=" & FN.Rows(i).Item("FN_ID")
            If Auth.DefaultView.Count = 0 OrElse IsDBNull(Auth.DefaultView(0).Item("Auth_ID")) Then
                FN.Rows(i).Item("Auth_ID") = 0
            Else
                FN.Rows(i).Item("Auth_ID") = Auth.DefaultView(0).Item("Auth_ID")
            End If
        Next
        Return FN
    End Function

    Public Function GetList_Functional(ByVal application_id As Integer, ByVal functional_zone_id As Integer, ByVal functional_id As Integer) As DataTable
        Dim sql As String = " SELECT AP.ID App_ID,AP.App_Name," & Environment.NewLine
        sql &= " FZ.ID FN_Zone_ID,FZ.FN_Zone_Name," & Environment.NewLine
        sql &= " FN.ID FN_ID,FN.FUNCTIONAL_NAME,Can_Edit" & Environment.NewLine
        sql &= " FROM MS_Application AP" & Environment.NewLine
        sql &= " INNER JOIN MS_Functional_Zone FZ On AP.ID=FZ.MS_APPLICATION_ID" & Environment.NewLine
        sql &= " INNER JOIN MS_Functional FN ON FZ.ID=FN.MS_FUNCTIONAL_ZONE_ID WHERE FN.active_status='Y' " & Environment.NewLine
        Dim p(3) As SqlParameter
        If application_id > 0 Then
            sql &= " And AP.ID =@_application_id" & Environment.NewLine
            p(0) = ServerDB.SetInt("@_application_id", application_id)
        End If
        If functional_zone_id > 0 Then
            sql &= " and FZ.ID =@_functional_zone_id" & Environment.NewLine
            p(1) = ServerDB.SetInt("@_functional_zone_id", functional_zone_id)
        End If
        If functional_id > 0 Then
            sql &= " And FN.ID=@_functional_id" & Environment.NewLine
            p(2) = ServerDB.SetInt("@_functional_id", functional_id)
        End If
        sql &= " ORDER BY AP.App_Order,FZ.FN_Zone_Order,FN.FUNCTIONAL_Order"


        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt

    End Function


    Public Function GetList_Role_Functional(ByVal application_id As String, ByVal functional_zone_id As String, ByVal functional_id As Integer, ByVal role_id As Integer) As DataTable

        Dim sql As String = "Select  AP.ID App_ID,AP.App_Name," & Environment.NewLine
        sql &= " FZ.ID FN_Zone_ID, FZ.FN_Zone_Name," & Environment.NewLine
        sql &= " FN.ID FN_ID, FN.Functional_Name," & Environment.NewLine
        sql &= " R.ID Role_ID, R.Role_Name, A.ID Auth_ID, A.Authorization_Name" & Environment.NewLine
        sql &= " From ms_Role R" & Environment.NewLine
        sql &= " INNER Join ms_Role_Functional RF ON R.id=RF.ms_role_id" & Environment.NewLine
        sql &= " INNER Join ms_Functional FN On FN.id=RF.ms_functional_id" & Environment.NewLine
        sql &= " INNER Join ms_Functional_Zone FZ ON FZ.id=FN.ms_functional_zone_id" & Environment.NewLine
        sql &= " INNER Join ms_Application AP On AP.id=FZ.ms_application_id" & Environment.NewLine
        sql &= " Left Join MS_AUTHORIZATION A ON A.id=CASE WHEN Can_Edit='N'" & Environment.NewLine
        sql &= " And RF.ms_authorization_id = 2 Then 1 Else ISNULL(RF.ms_authorization_id,0) End" & Environment.NewLine
        sql &= " WHERE fn.active_status='Y'" & Environment.NewLine
        Dim p(4) As SqlParameter
        If application_id <> 0 Then
            sql &= " And AP.ID =@_application_id" & Environment.NewLine
            p(0) = ServerDB.SetText("@_application_id", application_id)
        End If
        If functional_zone_id <> 0 Then
            sql &= " And FZ.ID=@_functional_zone_id" & Environment.NewLine
            p(1) = ServerDB.SetInt("@_functional_zone_id", functional_zone_id)
        End If
        If functional_id <> 0 Then
            sql &= " And FN.ID=@_functional_id" & Environment.NewLine
            p(2) = ServerDB.SetInt("@_functional_id", functional_id)
        End If
        If role_id <> 0 Then
            sql &= " And R.ID=@_role_id" & Environment.NewLine
            p(3) = ServerDB.SetInt("@_role_id", role_id)
        End If
        sql &= " ORDER BY R.ID, AP.App_Order, FZ.FN_Zone_Order, FN.functional_order"


        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_User_Role(ByVal username As String, ByVal role_id As Integer) As DataTable
        Dim sql As String = "Select username,r.id role_id,r.role_name" & Environment.NewLine
        sql &= " From ms_user_role ur " & Environment.NewLine
        sql &= " inner Join ms_role r On r.id=ur.ms_role_id" & Environment.NewLine
        sql &= " where 1=1" & Environment.NewLine
        If username <> "" Then
            sql &= " And ur.username=@_username  " & Environment.NewLine
        End If
        If role_id <> 0 Then
            sql &= " And r.id=@_role_id" & Environment.NewLine
        End If

        sql &= " ORDER BY username, r.id"
        Dim p(2) As SqlParameter
        p(0) = ServerDB.SetText("@_username", username)
        p(1) = ServerDB.SetInt("@_role_id", role_id)
        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function Drop_Role(ByVal role_id As Integer) As Boolean
        Dim trans As New ServerTransactionDB
        Dim sql As String
        Try
            Dim ret As ExecuteDataInfo
            sql = "DELETE FROM MS_ROLE_FUNCTIONAL WHERE MS_ROLE_ID=@_ROLEID"
            Dim p_f(1) As SqlParameter
            p_f(0) = ServerDB.SetText("@_ROLEID", role_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_f)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM MS_USER_ROLE WHERE  MS_ROLE_ID=@_ROLEID"
            Dim p_u(1) As SqlParameter
            p_u(0) = ServerDB.SetText("@_ROLEID", role_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_u)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM MS_ROLE WHERE ID=@_ROLEID"
            Dim p_r(1) As SqlParameter
            p_r(0) = ServerDB.SetText("@_ROLEID", role_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_r)
            If ret.IsSuccess = False Then
                Return False
            End If

            trans.CommitTransaction()
            Return True
        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try
    End Function

#End Region

#Region "SettingMailGroup"
    Public Function GetList_MailGroup() As DataTable
        Dim sql As String = "SELECT DISTINCT G.ID,GROUP_CODE,GROUP_NAME,G.ACTIVE_STATUS,"
        sql &= " (SELECT COUNT(ID) FROM MS_REPORT_MAIL_GROUP_REPORTS R WHERE G.ID=R.MS_REPORT_MAIL_GROUP_ID) COUNT_REPORT,"
        sql &= "(SELECT COUNT(ID) FROM MS_REPORT_MAIL_GROUP_DETAIL M WHERE G.ID = M.MS_REPORT_MAIL_GROUP_ID) COUNT_MAIL,"
        sql &= " (SELECT COUNT(ID) FROM MS_REPORT_MAIL_GROUP_LOCATION L WHERE G.ID = L.MS_REPORT_MAIL_GROUP_ID) COUNT_LOCATION"
        sql &= " FROM MS_REPORT_MAIL_GROUP G"
        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql)
        Return dt
    End Function

    Public Function Get_Mail_Group_Info(group_id As String) As DataTable
        Dim sql As String = ""
        sql &= " SELECT GROUP_CODE,GROUP_NAME,ACTIVE_STATUS "
        sql &= " FROM MS_REPORT_MAIL_GROUP "
        sql &= " WHERE ID=@_GROUP_ID"

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_GROUP_ID", group_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_MailGroup_Report(group_id As String) As DataTable
        Dim sql As String = ""
        sql &= " SELECT RM.ID,REPORT_NAME ,"
        sql &= " ISNULL((SELECT 'T' FROM MS_REPORT_MAIL_GROUP_REPORTS GR WHERE GR.MS_REPORTS_MAIL_ID = RM.ID AND GR.MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID),'F') SELECTED "
        sql &= " FROM MS_REPORTS_MAIL RM ORDER BY REPORT_NAME"

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_GROUP_ID", group_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_MailGroup_Location(group_id As String) As DataTable
        Dim sql As String = ""
        sql &= " SELECT ML.ID,LOCATION_NAME,CASE ISNULL(GL.MS_LOCATION_ID,'') WHEN '' THEN 'F' ELSE 'T' END SELECTED"
        sql &= " FROM MS_REPORT_MAIL_GROUP_LOCATION GL RIGHT JOIN MS_LOCATION ML ON GL.MS_LOCATION_ID = ML.ID AND MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID"
        sql &= " ORDER BY LOCATION_NAME "

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_GROUP_ID", group_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetList_MailGroup_Mail(group_id As String) As DataTable
        Dim sql As String = ""
        sql &= " SELECT ID,EMAIL"
        sql &= " FROM MS_REPORT_MAIL_GROUP_DETAIL GD "
        sql &= " WHERE MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID"

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_GROUP_ID", group_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function Drop_MailGroup(ByVal group_id As String) As Boolean
        Dim trans As New ServerTransactionDB
        Dim sql As String
        Try
            Dim ret As ExecuteDataInfo
            sql = "DELETE FROM MS_REPORT_MAIL_GROUP_LOCATION WHERE MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID"
            Dim p_l(1) As SqlParameter
            p_l(0) = ServerDB.SetText("@_GROUP_ID", group_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_l)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM MS_REPORT_MAIL_GROUP_DETAIL WHERE MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID"
            Dim p_d(1) As SqlParameter
            p_d(0) = ServerDB.SetText("@_GROUP_ID", group_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_d)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM MS_REPORT_MAIL_GROUP_REPORTS WHERE MS_REPORT_MAIL_GROUP_ID=@_GROUP_ID"
            Dim p_r(1) As SqlParameter
            p_r(0) = ServerDB.SetText("@_GROUP_ID", group_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_r)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM MS_REPORT_MAIL_GROUP WHERE ID=@_GROUP_ID"
            Dim p_g(1) As SqlParameter
            p_g(0) = ServerDB.SetText("@_GROUP_ID", group_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_g)

            If ret.IsSuccess = False Then
                Return False
            End If

            trans.CommitTransaction()
            Return True
        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try
    End Function

#End Region

#Region "Get  Sysconfig"
    Public Function GetServerSysconfig() As CfServerSysconfigServerLinqDB
        Dim ret As New CfServerSysconfigServerLinqDB
        ret.GetDataByPK(1, Nothing)

        Return ret
    End Function

    Public Function GetKioskSysconfig(MsKioskID As Long) As CfKioskSysconfigServerLinqDB
        Dim ret As New CfKioskSysconfigServerLinqDB
        ret.ChkDataByMS_KIOSK_ID(MsKioskID, Nothing)

        Return ret
    End Function
#End Region

#Region "Master Cabinet Model"
    Public Function GetList_CabinetModel(CabinetModelID As Long) As DataTable
        Dim dt As DataTable
        Dim trans As New ServerTransactionDB
        Try
            Dim p(1) As SqlParameter
            Dim wh As String = "1=1"
            If CabinetModelID > 0 Then
                wh += " and id=@_ID"
                p(0) = ServerDB.SetBigInt("@_ID", CabinetModelID)
            End If

            Dim lnq As New MsCabinetModelServerLinqDB
            dt = lnq.GetDataList(wh, "id", trans.Trans, p)
            lnq = Nothing

        Catch ex As Exception
            trans.RollbackTransaction()
            dt = New DataTable
        End Try
        Return dt
    End Function
#End Region

#Region "Export To Excel"

    Public Sub ExportToExcel(Response As HttpResponse, DT As DataTable, ByVal OutputFileName As String, RowNumberOfFooter As Integer)

        If DT.Rows.Count > 0 Then
            Using ep As New ExcelPackage
                ExportExcelPackage(Response, DT, OutputFileName, RowNumberOfFooter, ep)
            End Using
        End If
    End Sub


    Public Sub ExportExcelPackage(Response As HttpResponse, DT As DataTable, ByVal OutputFileName As String, RowNumberOfFooter As Integer, ep As ExcelPackage)
        Dim ws As ExcelWorksheet = ep.Workbook.Worksheets.Add("Detail")
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

        '//Write it back to the client
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.AddHeader("content-disposition", "attachment;  filename=" & OutputFileName)
        Response.BinaryWrite(ep.GetAsByteArray())
        Response.End()
        Response.Flush()

    End Sub


    Public Sub ExportExcelPackage(Response As HttpResponse, DT As DataTable, ByVal OutputFileName As String, RowNumberOfFooter As Integer, ep As ExcelPackage, ws As ExcelWorksheet, RowStart As Integer, ColStart As Integer)
        'Dim ws As ExcelWorksheet = ep.Workbook.Worksheets.Add("Detail")
        ws.Cells(RowStart, ColStart).LoadFromDataTable(DT, True)

        Using RowHeader As ExcelRange = ws.Cells(RowStart, ColStart, RowStart, ColStart + DT.Columns.Count - 1)
            RowHeader.Style.Font.Bold = True
            RowHeader.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
            RowHeader.Style.Fill.BackgroundColor.SetColor(Color.Gray)
            RowHeader.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
            RowHeader.Style.Font.Color.SetColor(Color.Black)
        End Using

        Using RowContent As ExcelRange = ws.Cells(RowStart + 1, ColStart, RowStart + DT.Rows.Count, ColStart + DT.Columns.Count - 1)
            RowContent.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
            RowContent.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
            RowContent.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
            RowContent.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin
        End Using

        For i As Integer = 0 To DT.Columns.Count - 1
            Dim ColumType As String = DT.Columns(i).DataType.Name.ToLower
            If ColumType = "datetime" Then
                ws.Cells(RowStart + 1, ColStart + i, RowStart + DT.Rows.Count, ColStart + i).Style.Numberformat.Format = "mmm dd yyyy HH:MM:ss"
            End If
        Next

        ws.Cells(RowStart, ColStart, DT.Rows.Count + 1, DT.Columns.Count).AutoFitColumns()

        If RowNumberOfFooter > 0 Then
            Using RowFooter As ExcelRange = ws.Cells(RowStart + (DT.Rows.Count) - (RowNumberOfFooter - 1), ColStart, RowStart + DT.Rows.Count, ColStart + DT.Columns.Count - 1)
                RowFooter.Style.Font.Bold = True
                RowFooter.Style.Font.Color.SetColor(Color.Black)
            End Using
        End If

        '//Write it back to the client
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.AddHeader("content-disposition", "attachment;  filename=" & OutputFileName)
        Response.BinaryWrite(ep.GetAsByteArray())
        Response.End()
        Response.Flush()

    End Sub
#End Region

#Region "Promotion"
    Public Function getDataCabinetModel() As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select id, model_name "
            sql += " from MS_CABINET_MODEL cm "
            sql += " where active_status='Y'"
            sql += " order by id"
            ret = ServerDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Function GetHourList() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("HOUR")

        For i As Integer = 1 To 24
            Dim dr As DataRow = dt.NewRow
            dr("HOUR") = i
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function GetList_Promotion() As DataTable
        Dim sql As String = "  select mp.id,promotion_code,promotion_name,convert(varchar(10),[start_date],103) + ' - ' + convert(varchar(10),end_date,103) PeriodDate"
        sql &= ",(SELECT COUNT(mpl.id) FROM ms_promotion_location mpl WHERE mp.id = mpl.ms_promotion_id) count_location,start_date,end_date"
        sql &= ",case when convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112) then  '1' else '0' end isExpire,publish_status"
        sql &= " From ms_promotion mp"

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql)
        Return dt
    End Function

    Public Function GetList_Promotion_Location(ByVal promotion_id As String) As DataTable
        Dim sql As String = "SELECT ID,LOCATION_NAME,"
        sql &= " ISNULL((SELECT 'T' FROM MS_PROMOTION_LOCATION MPL WHERE MPL.ms_location_id = MSL.ID AND MPL.ms_promotion_id=@_PROMOTION_ID) ,'F') SELECTED"
        sql &= " From MS_LOCATION MSL"
        sql &= " ORDER BY LOCATION_NAME"
        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_PROMOTION_ID", promotion_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function GetServiceRatePromotionHour(Promotion_ID As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select ms_cabinet_model_id, promotion_hour, service_rate "
            sql &= " from MS_Promotion_Hour "
            sql &= " where ms_promotion_id=@_Promoton_id"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetText("@_Promoton_id", Promotion_ID)

            ret = ServerDB.ExecuteTable(sql, p)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Function Get_Promotion_Info(promotion_id As String) As DataTable
        Dim sql As String = ""
        sql &= " SELECT *,case when convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112) then  '1' else '0' end isExpire "
        sql &= " FROM MS_PROMOTION "
        sql &= " WHERE ID=@_PROMOTION_ID"

        Dim p(1) As SqlParameter
        p(0) = ServerDB.SetText("@_PROMOTION_ID", promotion_id)

        Dim dt As New DataTable
        dt = ServerDB.ExecuteTable(sql, p)
        Return dt
    End Function

    Public Function Drop_Promotion(ByVal promotion_id As String) As Boolean
        Dim trans As New ServerTransactionDB
        Dim sql As String
        Try
            Dim ret As ExecuteDataInfo

            sql = "DELETE FROM MS_PROMOTION_HOUR WHERE MS_PROMOTION_ID=@_PROMOTION_ID"
            Dim p_h(1) As SqlParameter
            p_h(0) = ServerDB.SetText("@_PROMOTION_ID", promotion_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_h)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM MS_PROMOTION_LOCATION WHERE MS_PROMOTION_ID=@_PROMOTION_ID"
            Dim p_l(1) As SqlParameter
            p_l(0) = ServerDB.SetText("@_PROMOTION_ID", promotion_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_l)

            If ret.IsSuccess = False Then
                Return False
            End If

            sql = "DELETE FROM MS_PROMOTION WHERE ID=@_PROMOTION_ID"
            Dim p_g(1) As SqlParameter
            p_g(0) = ServerDB.SetText("@_PROMOTION_ID", promotion_id)
            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p_g)

            If ret.IsSuccess = False Then
                Return False
            End If

            trans.CommitTransaction()
            Return True
        Catch ex As Exception
            trans.RollbackTransaction()
            Return False
        End Try
    End Function

    Public Function Update_Publish_Status(ByVal promotion_id As String) As Boolean

        Dim sql As String
        Try
            Dim ret As ExecuteDataInfo
            sql = "UPDATE MS_PROMOTION SET PUBLISH_STATUS = 1 WHERE ID=@_PROMOTION_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetText("@_PROMOTION_ID", promotion_id)
            ret = ServerDB.ExecuteNonQuery(sql, p)

            If ret.IsSuccess = False Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CheckPromotionDateOverlap(Locationid As String, MsLocationPromotionID As Long, StartDate As String, EndDate As String) As Boolean
        Dim ret As Boolean = False
        Dim sql As String = " select lp.id, 1 as g " & Environment.NewLine
        sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=lp.ms_location_id " & Environment.NewLine
        sql += " where l.id=@_LOCATION_ID " & Environment.NewLine
        sql += " and lp.id<>@_LOCATION_PROMOTION_ID " & Environment.NewLine
        sql += " And @_END_DATE between convert(varchar(8),lp.start_date,112) And convert(varchar(8), lp.end_date,112) " & Environment.NewLine
        sql += " union all " & Environment.NewLine
        sql += " Select lp.id, 2 As g " & Environment.NewLine
        sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=lp.ms_location_id " & Environment.NewLine
        sql += " where l.id=@_LOCATION_ID " & Environment.NewLine
        sql += " and lp.id<>@_LOCATION_PROMOTION_ID " & Environment.NewLine
        sql += " and @_START_DATE<=convert(varchar(8),lp.start_date,112)  " & Environment.NewLine
        sql += " And @_END_DATE>=convert(varchar(8), lp.end_date,112) " & Environment.NewLine
        sql += " union all " & Environment.NewLine
        sql += " Select lp.id, 3 As g " & Environment.NewLine
        sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=lp.ms_location_id " & Environment.NewLine
        sql += " where l.id=@_LOCATION_ID " & Environment.NewLine
        sql += " and lp.id<>@_LOCATION_PROMOTION_ID " & Environment.NewLine
        sql += " and @_START_DATE>=convert(varchar(8),lp.start_date,112)  " & Environment.NewLine
        sql += " And @_END_DATE<=convert(varchar(8), lp.end_date,112) " & Environment.NewLine
        sql += " union all " & Environment.NewLine
        sql += " Select lp.id, 4 As g " & Environment.NewLine
        sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=lp.ms_location_id " & Environment.NewLine
        sql += " where l.id=@_LOCATION_ID " & Environment.NewLine
        sql += " and lp.id<>@_LOCATION_PROMOTION_ID " & Environment.NewLine
        sql += " and @_START_DATE between convert(varchar(8),lp.start_date,112) and convert(varchar(8), lp.end_date,112) " & Environment.NewLine

        'Dim vStartDate As String = Converter.StringToDate(StartDate, "yyyyMMdd").ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        'Dim vEndDate As String = Converter.StringToDate(EndDate).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

        Dim p(4) As SqlParameter
        p(0) = ServerDB.SetText("@_START_DATE", StartDate)
        p(1) = ServerDB.SetText("@_END_DATE", EndDate)
        p(3) = ServerDB.SetText("@_LOCATION_ID", Locationid)
        p(4) = ServerDB.SetBigInt("@_LOCATION_PROMOTION_ID", MsLocationPromotionID)

        Dim dt As DataTable = ServerDB.ExecuteTable(sql, p)
        If dt.Rows.Count > 0 Then
            ret = True
        End If
        dt.Dispose()

        Return ret

    End Function

    Public Function CheckPromotionDateOverlapByPromotion(StartDate As String, EndDate As String, LocationID As String, promotionId As String) As Boolean
        'Dim vStartDate As String = Converter.ConvertTextToDate(StartDate).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        'Dim vEndDate As String = Converter.ConvertTextToDate(EndDate).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

        'Declare @_START_DATE varchar(10)
        'Set @_START_DATE ='20160910'

        'Declare @_END_DATE varchar(10)
        'Set @_END_DATE = '20160930'

        Dim sql As String = "select * from (select distinct l.ms_location_id "
        sql &= " From ms_promotion p inner join ms_promotion_location l on p.id=l.ms_promotion_id"
        sql &= " where p.id <> @_PROMOTION_ID and  @_START_DATE between convert(varchar(8),p.start_date,112) And convert(varchar(8), p.end_date,112)"
        sql &= " union"
        sql &= " Select distinct l.ms_location_id"
        sql &= " from ms_promotion p inner join ms_promotion_location l on p.id=l.ms_promotion_id"
        sql &= " where p.id <> @_PROMOTION_ID and @_START_DATE>=convert(varchar(8),p.start_date,112)"
        sql &= " And @_END_DATE<=convert(varchar(8), p.end_date,112)"
        sql &= " union"
        sql &= " select distinct l.ms_location_id"
        sql &= " from ms_promotion p inner join ms_promotion_location l On p.id=l.ms_promotion_id"
        sql &= " where p.id <> @_PROMOTION_ID and @_END_DATE between convert(varchar(8),p.start_date,112) and convert(varchar(8), p.end_date,112) "
        sql &= " union"
        sql &= " select distinct l.ms_location_id "
        sql &= " from ms_promotion p inner join ms_promotion_location l On p.id=l.ms_promotion_id"
        sql &= " and p.id <> @_PROMOTION_ID and @_START_DATE<=convert(varchar(8),p.start_date,112)"
        sql &= " And @_END_DATE>=convert(varchar(8), p.end_date,112) ) T where ms_location_id in (@_LOCATION_ID)"

        Dim p(4) As SqlParameter
        p(0) = ServerDB.SetText("@_START_DATE", StartDate)
        p(1) = ServerDB.SetText("@_END_DATE", EndDate)
        p(2) = ServerDB.SetText("@_LOCATION_ID", LocationID)
        p(3) = ServerDB.SetText("@_PROMOTION_ID", promotionId)

        Dim dt As DataTable = ServerDB.ExecuteTable(sql, p)
        Dim ret As Boolean = False
        If dt.Rows.Count > 0 Then
            ret = True
        End If

        Return ret

    End Function
#End Region


End Class
