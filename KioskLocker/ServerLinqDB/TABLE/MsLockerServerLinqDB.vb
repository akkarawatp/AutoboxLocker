Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for MS_LOCKER table ServerLinqDB.
    '[Create by  on January, 11 2017]
    Public Class MsLockerServerLinqDB
        Public sub MsLockerServerLinqDB()

        End Sub 
        ' MS_LOCKER
        Const _tableName As String = "MS_LOCKER"

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATED_BY As String = ""
        Dim _CREATED_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATED_BY As  String  = ""
        Dim _UPDATED_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _LOCKER_NAME As String = ""
        Dim _LAYOUT_NAME As  String  = ""
        Dim _MS_KIOSK_ID As Long = 0
        Dim _MS_CABINET_ID As Long = 0
        Dim _MODEL_NAME As String = ""
        Dim _PIN_SOLENOID As Long = 0
        Dim _PIN_LED As Long = 0
        Dim _PIN_SENSOR As String = ""
        Dim _OPEN_CLOSE_STATUS As Char = "C"
        Dim _CURRENT_AVAILABLE As Char = "Y"
        Dim _ACTIVE_STATUS As Char = "Y"
        Dim _SYNC_TO_SERVER As Char = "N"
        Dim _SYNC_TO_KIOSK As Char = "Y"

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_BY", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_BY() As String
            Get
                Return _CREATED_BY
            End Get
            Set(ByVal value As String)
               _CREATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_DATE() As DateTime
            Get
                Return _CREATED_DATE
            End Get
            Set(ByVal value As DateTime)
               _CREATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_BY", DbType:="VarChar(100)")>  _
        Public Property UPDATED_BY() As  String 
            Get
                Return _UPDATED_BY
            End Get
            Set(ByVal value As  String )
               _UPDATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_DATE", DbType:="DateTime")>  _
        Public Property UPDATED_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATED_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_LOCKER_NAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCKER_NAME() As String
            Get
                Return _LOCKER_NAME
            End Get
            Set(ByVal value As String)
               _LOCKER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LAYOUT_NAME", DbType:="VarChar(50)")>  _
        Public Property LAYOUT_NAME() As  String 
            Get
                Return _LAYOUT_NAME
            End Get
            Set(ByVal value As  String )
               _LAYOUT_NAME = value
            End Set
        End Property 
        <Column(Storage:="_MS_KIOSK_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_KIOSK_ID() As Long
            Get
                Return _MS_KIOSK_ID
            End Get
            Set(ByVal value As Long)
               _MS_KIOSK_ID = value
            End Set
        End Property 
        <Column(Storage:="_MS_CABINET_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_CABINET_ID() As Long
            Get
                Return _MS_CABINET_ID
            End Get
            Set(ByVal value As Long)
               _MS_CABINET_ID = value
            End Set
        End Property 
        <Column(Storage:="_MODEL_NAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MODEL_NAME() As String
            Get
                Return _MODEL_NAME
            End Get
            Set(ByVal value As String)
               _MODEL_NAME = value
            End Set
        End Property 
        <Column(Storage:="_PIN_SOLENOID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property PIN_SOLENOID() As Long
            Get
                Return _PIN_SOLENOID
            End Get
            Set(ByVal value As Long)
               _PIN_SOLENOID = value
            End Set
        End Property 
        <Column(Storage:="_PIN_LED", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property PIN_LED() As Long
            Get
                Return _PIN_LED
            End Get
            Set(ByVal value As Long)
               _PIN_LED = value
            End Set
        End Property 
        <Column(Storage:="_PIN_SENSOR", DbType:="VarChar(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property PIN_SENSOR() As String
            Get
                Return _PIN_SENSOR
            End Get
            Set(ByVal value As String)
               _PIN_SENSOR = value
            End Set
        End Property 
        <Column(Storage:="_OPEN_CLOSE_STATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property OPEN_CLOSE_STATUS() As Char
            Get
                Return _OPEN_CLOSE_STATUS
            End Get
            Set(ByVal value As Char)
               _OPEN_CLOSE_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_CURRENT_AVAILABLE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property CURRENT_AVAILABLE() As Char
            Get
                Return _CURRENT_AVAILABLE
            End Get
            Set(ByVal value As Char)
               _CURRENT_AVAILABLE = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE_STATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE_STATUS() As Char
            Get
                Return _ACTIVE_STATUS
            End Get
            Set(ByVal value As Char)
               _ACTIVE_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_SYNC_TO_SERVER", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SYNC_TO_SERVER() As Char
            Get
                Return _SYNC_TO_SERVER
            End Get
            Set(ByVal value As Char)
               _SYNC_TO_SERVER = value
            End Set
        End Property 
        <Column(Storage:="_SYNC_TO_KIOSK", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SYNC_TO_KIOSK() As Char
            Get
                Return _SYNC_TO_KIOSK
            End Get
            Set(ByVal value As Char)
               _SYNC_TO_KIOSK = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _LOCKER_NAME = ""
            _LAYOUT_NAME = ""
            _MS_KIOSK_ID = 0
            _MS_CABINET_ID = 0
            _MODEL_NAME = ""
            _PIN_SOLENOID = 0
            _PIN_LED = 0
            _PIN_SENSOR = ""
            _OPEN_CLOSE_STATUS = "C"
            _CURRENT_AVAILABLE = "Y"
            _ACTIVE_STATUS = "Y"
            _SYNC_TO_SERVER = "N"
            _SYNC_TO_KIOSK = "Y"
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction, cmdParm() As SqlParameter) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans, cmdParm)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>

        Public Function GetListBySql(Sql As String, trans As SQLTransaction, cmdParm() As SqlParameter) As DataTable
            Return DB.ExecuteTable(Sql, trans, cmdParm)
        End Function


        '/// Returns an indication whether the current data is inserted into MS_LOCKER table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(CreatedBy As String,trans As SQLTransaction) As ExecuteDataInfo
            If trans IsNot Nothing Then 
                _created_by = CreatedBy
                _created_date = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Dim ret As New ExecuteDataInfo
                ret.IsSuccess = False
                ret.SqlStatement = ""
                ret.ErrorMessage = _error
                Return ret
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to MS_LOCKER table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateData(UpdatedBy As String,trans As SQLTransaction) As ExecuteDataInfo
            If trans IsNot Nothing Then 
                If _id > 0 Then 
                    _UPDATED_BY = UpdatedBy
                    _UPDATED_DATE = DateTime.Now

                    Return doUpdate("ID = @_ID", trans)
                Else 
                    _error = "No ID Data"
                    Dim ret As New ExecuteDataInfo
                    ret.IsSuccess = False
                    ret.SqlStatement = ""
                    ret.ErrorMessage = _error
                    Return ret
                End If 
            Else 
                _error = "Transaction Is not null"
                Dim ret As New ExecuteDataInfo
                ret.IsSuccess = False
                ret.SqlStatement = ""
                ret.ErrorMessage = _error
                Return ret
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to MS_LOCKER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction, cmbParm() As SQLParameter) As ExecuteDataInfo
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans, cmbParm)
            Else 
                _error = "Transaction Is not null"
                Dim ret As New ExecuteDataInfo
                ret.IsSuccess = False
                ret.ErrorMessage = _error
                Return ret
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_LOCKER table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cID As Long, trans As SQLTransaction) As ExecuteDataInfo
            If trans IsNot Nothing Then 
                Dim p(1) As SQLParameter
                p(0) = DB.SetBigInt("@_ID", cID)
                Return doDelete("ID = @_ID", trans, p)
            Else 
                _error = "Transaction Is not null"
                Dim ret As New ExecuteDataInfo
                ret.IsSuccess = False
                ret.ErrorMessage = _error
                Return ret
            End If 
        End Function


        '/// Returns an indication whether the record of MS_LOCKER by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_LOCKER by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsLockerServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of MS_LOCKER by specified LOCKER_NAME_MS_KIOSK_ID key is retrieved successfully.
        '/// <param name=cLOCKER_NAME_MS_KIOSK_ID>The LOCKER_NAME_MS_KIOSK_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByLOCKER_NAME_MS_KIOSK_ID(cLOCKER_NAME As String, cMS_KIOSK_ID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(3)  As SQLParameter
            cmdPara(0) = DB.SetText("@_LOCKER_NAME", cLOCKER_NAME) 
            cmdPara(1) = DB.SetText("@_MS_KIOSK_ID", cMS_KIOSK_ID) 
            Return doChkData("LOCKER_NAME = @_LOCKER_NAME AND MS_KIOSK_ID = @_MS_KIOSK_ID", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_LOCKER by specified LOCKER_NAME_MS_KIOSK_ID key is retrieved successfully.
        '/// <param name=cLOCKER_NAME_MS_KIOSK_ID>The LOCKER_NAME_MS_KIOSK_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByLOCKER_NAME_MS_KIOSK_ID(cLOCKER_NAME As String, cMS_KIOSK_ID As Long, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(3)  As SQLParameter
            cmdPara(0) = DB.SetText("@_LOCKER_NAME", cLOCKER_NAME) 
            cmdPara(1) = DB.SetText("@_MS_KIOSK_ID", cMS_KIOSK_ID) 
            cmdPara(2) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("LOCKER_NAME = @_LOCKER_NAME AND MS_KIOSK_ID = @_MS_KIOSK_ID And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_LOCKER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_LOCKER table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As ExecuteDataInfo
            Dim ret As New ExecuteDataInfo
            If _haveData = False Then
                Try
                    Dim dt as DataTable = DB.ExecuteTable(SqlInsert, trans, SetParameterData())
                    If dt.Rows.Count = 0 Then
                        ret.IsSuccess = False
                        ret.ErrorMessage = DB.ErrorMessage
                    Else
                        _ID = dt.Rows(0)("ID")
                        _haveData = True
                        ret.IsSuccess = True
                        _information = MessageResources.MSGIN001
                        ret.InfoMessage = _information
                    End If
                Catch ex As ApplicationException
                    ret.IsSuccess = false
                    ret.ErrorMessage = ex.Message & "ApplicationException :" & ex.ToString()  
                    ret.SqlStatement = SqlInsert
                Catch ex As Exception
                    ret.IsSuccess = False
                    ret.ErrorMessage = MessageResources.MSGEC101 & " Exception :" & ex.ToString()  
                    ret.SqlStatement = SqlInsert
                End Try
            Else
                ret.IsSuccess = False
                ret.ErrorMessage = MessageResources.MSGEN002  
                ret.SqlStatement = SqlInsert
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to MS_LOCKER table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As ExecuteDataInfo
            Dim ret As New ExecuteDataInfo
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                Dim sql As String = SqlUpdate & tmpWhere
                If whText.Trim() <> ""
                    Try
                        ret = DB.ExecuteNonQuery(sql, trans, SetParameterData())
                        If ret.IsSuccess = False Then
                            _error = DB.ErrorMessage
                        Else
                            _information = MessageResources.MSGIU001
                            ret.InfoMessage = MessageResources.MSGIU001
                        End If
                    Catch ex As ApplicationException
                        ret.IsSuccess = False
                        ret.ErrorMessage = "ApplicationException:" & ex.Message & ex.ToString() 
                        ret.SqlStatement = sql
                    Catch ex As Exception
                        ret.IsSuccess = False
                        ret.ErrorMessage = "Exception:" & MessageResources.MSGEC102 &  ex.ToString() 
                        ret.SqlStatement = sql
                    End Try
                Else
                    ret.IsSuccess = False
                    ret.ErrorMessage = MessageResources.MSGEU003 
                    ret.SqlStatement = sql
                End If
            Else
                ret.IsSuccess = True
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from MS_LOCKER table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction, cmdPara() As SqlParameter) As ExecuteDataInfo
             Dim ret As New ExecuteDataInfo
             Dim tmpWhere As String = " Where " & whText
             Dim sql As String = SqlDelete & tmpWhere
             If whText.Trim() <> ""
                 Try
                     ret = DB.ExecuteNonQuery(sql, trans, cmdPara)
                     If ret.IsSuccess = False Then
                         _error = MessageResources.MSGED001
                     Else
                        _information = MessageResources.MSGID001
                        ret.InfoMessage = MessageResources.MSGID001
                     End If
                 Catch ex As ApplicationException
                     _error = "ApplicationException :" & ex.Message & ex.ToString() & "### SQL:" & sql
                     ret.IsSuccess = False
                     ret.ErrorMessage = _error
                     ret.SqlStatement = sql
                 Catch ex As Exception
                     _error =  " Exception :" & MessageResources.MSGEC103 & ex.ToString() & "### SQL: " & sql
                     ret.IsSuccess = False
                     ret.ErrorMessage = _error
                     ret.SqlStatement = sql
                 End Try
             Else
                 _error = MessageResources.MSGED003 & "### SQL: " & sql
                 ret.IsSuccess = False
                 ret.ErrorMessage = _error
                 ret.SqlStatement = sql
             End If

            Return ret
        End Function

        Private Function SetParameterData() As SqlParameter()
            Dim cmbParam(17) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_CREATED_BY", SqlDbType.VarChar)
            cmbParam(1).Value = _CREATED_BY

            cmbParam(2) = New SqlParameter("@_CREATED_DATE", SqlDbType.DateTime)
            cmbParam(2).Value = _CREATED_DATE

            cmbParam(3) = New SqlParameter("@_UPDATED_BY", SqlDbType.VarChar)
            If _UPDATED_BY.Trim <> "" Then 
                cmbParam(3).Value = _UPDATED_BY
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_UPDATED_DATE", SqlDbType.DateTime)
            If _UPDATED_DATE.Value.Year > 1 Then 
                cmbParam(4).Value = _UPDATED_DATE.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_LOCKER_NAME", SqlDbType.VarChar)
            cmbParam(5).Value = _LOCKER_NAME

            cmbParam(6) = New SqlParameter("@_LAYOUT_NAME", SqlDbType.VarChar)
            If _LAYOUT_NAME.Trim <> "" Then 
                cmbParam(6).Value = _LAYOUT_NAME
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_MS_KIOSK_ID", SqlDbType.BigInt)
            cmbParam(7).Value = _MS_KIOSK_ID

            cmbParam(8) = New SqlParameter("@_MS_CABINET_ID", SqlDbType.BigInt)
            cmbParam(8).Value = _MS_CABINET_ID

            cmbParam(9) = New SqlParameter("@_MODEL_NAME", SqlDbType.VarChar)
            cmbParam(9).Value = _MODEL_NAME

            cmbParam(10) = New SqlParameter("@_PIN_SOLENOID", SqlDbType.Int)
            cmbParam(10).Value = _PIN_SOLENOID

            cmbParam(11) = New SqlParameter("@_PIN_LED", SqlDbType.Int)
            cmbParam(11).Value = _PIN_LED

            cmbParam(12) = New SqlParameter("@_PIN_SENSOR", SqlDbType.VarChar)
            cmbParam(12).Value = _PIN_SENSOR

            cmbParam(13) = New SqlParameter("@_OPEN_CLOSE_STATUS", SqlDbType.Char)
            cmbParam(13).Value = _OPEN_CLOSE_STATUS

            cmbParam(14) = New SqlParameter("@_CURRENT_AVAILABLE", SqlDbType.Char)
            cmbParam(14).Value = _CURRENT_AVAILABLE

            cmbParam(15) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(15).Value = _ACTIVE_STATUS

            cmbParam(16) = New SqlParameter("@_SYNC_TO_SERVER", SqlDbType.Char)
            cmbParam(16).Value = _SYNC_TO_SERVER

            cmbParam(17) = New SqlParameter("@_SYNC_TO_KIOSK", SqlDbType.Char)
            cmbParam(17).Value = _SYNC_TO_KIOSK

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_LOCKER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans, cmdPara)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("locker_name")) = False Then _locker_name = Rdr("locker_name").ToString()
                        If Convert.IsDBNull(Rdr("layout_name")) = False Then _layout_name = Rdr("layout_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_kiosk_id")) = False Then _ms_kiosk_id = Convert.ToInt64(Rdr("ms_kiosk_id"))
                        If Convert.IsDBNull(Rdr("ms_cabinet_id")) = False Then _ms_cabinet_id = Convert.ToInt64(Rdr("ms_cabinet_id"))
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
                        If Convert.IsDBNull(Rdr("pin_solenoid")) = False Then _pin_solenoid = Convert.ToInt32(Rdr("pin_solenoid"))
                        If Convert.IsDBNull(Rdr("pin_led")) = False Then _pin_led = Convert.ToInt32(Rdr("pin_led"))
                        If Convert.IsDBNull(Rdr("pin_sensor")) = False Then _pin_sensor = Rdr("pin_sensor").ToString()
                        If Convert.IsDBNull(Rdr("open_close_status")) = False Then _open_close_status = Rdr("open_close_status").ToString()
                        If Convert.IsDBNull(Rdr("current_available")) = False Then _current_available = Rdr("current_available").ToString()
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_server")) = False Then _sync_to_server = Rdr("sync_to_server").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_kiosk")) = False Then _sync_to_kiosk = Rdr("sync_to_kiosk").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of MS_LOCKER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As MsLockerServerLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans, cmdPara)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("locker_name")) = False Then _locker_name = Rdr("locker_name").ToString()
                        If Convert.IsDBNull(Rdr("layout_name")) = False Then _layout_name = Rdr("layout_name").ToString()
                        If Convert.IsDBNull(Rdr("ms_kiosk_id")) = False Then _ms_kiosk_id = Convert.ToInt64(Rdr("ms_kiosk_id"))
                        If Convert.IsDBNull(Rdr("ms_cabinet_id")) = False Then _ms_cabinet_id = Convert.ToInt64(Rdr("ms_cabinet_id"))
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
                        If Convert.IsDBNull(Rdr("pin_solenoid")) = False Then _pin_solenoid = Convert.ToInt32(Rdr("pin_solenoid"))
                        If Convert.IsDBNull(Rdr("pin_led")) = False Then _pin_led = Convert.ToInt32(Rdr("pin_led"))
                        If Convert.IsDBNull(Rdr("pin_sensor")) = False Then _pin_sensor = Rdr("pin_sensor").ToString()
                        If Convert.IsDBNull(Rdr("open_close_status")) = False Then _open_close_status = Rdr("open_close_status").ToString()
                        If Convert.IsDBNull(Rdr("current_available")) = False Then _current_available = Rdr("current_available").ToString()
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_server")) = False Then _sync_to_server = Rdr("sync_to_server").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_kiosk")) = False Then _sync_to_kiosk = Rdr("sync_to_kiosk").ToString()
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function



        ' SQL Statements


        'Get Insert Statement for table MS_LOCKER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, LOCKER_NAME, LAYOUT_NAME, MS_KIOSK_ID, MS_CABINET_ID, MODEL_NAME, PIN_SOLENOID, PIN_LED, PIN_SENSOR, OPEN_CLOSE_STATUS, CURRENT_AVAILABLE, ACTIVE_STATUS, SYNC_TO_SERVER, SYNC_TO_KIOSK)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.LOCKER_NAME, INSERTED.LAYOUT_NAME, INSERTED.MS_KIOSK_ID, INSERTED.MS_CABINET_ID, INSERTED.MODEL_NAME, INSERTED.PIN_SOLENOID, INSERTED.PIN_LED, INSERTED.PIN_SENSOR, INSERTED.OPEN_CLOSE_STATUS, INSERTED.CURRENT_AVAILABLE, INSERTED.ACTIVE_STATUS, INSERTED.SYNC_TO_SERVER, INSERTED.SYNC_TO_KIOSK"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_LOCKER_NAME" & ", "
                sql += "@_LAYOUT_NAME" & ", "
                sql += "@_MS_KIOSK_ID" & ", "
                sql += "@_MS_CABINET_ID" & ", "
                sql += "@_MODEL_NAME" & ", "
                sql += "@_PIN_SOLENOID" & ", "
                sql += "@_PIN_LED" & ", "
                sql += "@_PIN_SENSOR" & ", "
                sql += "@_OPEN_CLOSE_STATUS" & ", "
                sql += "@_CURRENT_AVAILABLE" & ", "
                sql += "@_ACTIVE_STATUS" & ", "
                sql += "@_SYNC_TO_SERVER" & ", "
                sql += "@_SYNC_TO_KIOSK"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_LOCKER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "LOCKER_NAME = " & "@_LOCKER_NAME" & ", "
                Sql += "LAYOUT_NAME = " & "@_LAYOUT_NAME" & ", "
                Sql += "MS_KIOSK_ID = " & "@_MS_KIOSK_ID" & ", "
                Sql += "MS_CABINET_ID = " & "@_MS_CABINET_ID" & ", "
                Sql += "MODEL_NAME = " & "@_MODEL_NAME" & ", "
                Sql += "PIN_SOLENOID = " & "@_PIN_SOLENOID" & ", "
                Sql += "PIN_LED = " & "@_PIN_LED" & ", "
                Sql += "PIN_SENSOR = " & "@_PIN_SENSOR" & ", "
                Sql += "OPEN_CLOSE_STATUS = " & "@_OPEN_CLOSE_STATUS" & ", "
                Sql += "CURRENT_AVAILABLE = " & "@_CURRENT_AVAILABLE" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" & ", "
                Sql += "SYNC_TO_SERVER = " & "@_SYNC_TO_SERVER" & ", "
                Sql += "SYNC_TO_KIOSK = " & "@_SYNC_TO_KIOSK" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_LOCKER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_LOCKER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, LOCKER_NAME, LAYOUT_NAME, MS_KIOSK_ID, MS_CABINET_ID, MODEL_NAME, PIN_SOLENOID, PIN_LED, PIN_SENSOR, OPEN_CLOSE_STATUS, CURRENT_AVAILABLE, ACTIVE_STATUS, SYNC_TO_SERVER, SYNC_TO_KIOSK FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
