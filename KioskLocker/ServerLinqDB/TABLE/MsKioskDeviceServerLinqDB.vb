Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for MS_KIOSK_DEVICE table ServerLinqDB.
    '[Create by  on June, 9 2016]
    Public Class MsKioskDeviceServerLinqDB
        Public sub MsKioskDeviceServerLinqDB()

        End Sub 
        ' MS_KIOSK_DEVICE
        Const _tableName As String = "MS_KIOSK_DEVICE"

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
        Dim _MS_KIOSK_ID As Long = 0
        Dim _MS_DEVICE_ID As Long = 0
        Dim _MAX_QTY As Long = 0
        Dim _WARNING_QTY As Long = 0
        Dim _CRITICAL_QTY As Long = 0
        Dim _CURRENT_QTY As Long = 0
        Dim _CURRENT_MONEY As  System.Nullable(Of Long) 
        Dim _MS_DEVICE_STATUS_ID As Long = 0
        Dim _COMPORT_VID As  String  = ""
        Dim _DRIVER_NAME1 As  String  = ""
        Dim _DRIVER_NAME2 As  String  = ""
        Dim _SYNC_TO_KIOSK As Char = "N"
        Dim _SYNC_TO_SERVER As Char = "N"

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
        <Column(Storage:="_MS_KIOSK_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_KIOSK_ID() As Long
            Get
                Return _MS_KIOSK_ID
            End Get
            Set(ByVal value As Long)
               _MS_KIOSK_ID = value
            End Set
        End Property 
        <Column(Storage:="_MS_DEVICE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_DEVICE_ID() As Long
            Get
                Return _MS_DEVICE_ID
            End Get
            Set(ByVal value As Long)
               _MS_DEVICE_ID = value
            End Set
        End Property 
        <Column(Storage:="_MAX_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property MAX_QTY() As Long
            Get
                Return _MAX_QTY
            End Get
            Set(ByVal value As Long)
               _MAX_QTY = value
            End Set
        End Property 
        <Column(Storage:="_WARNING_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property WARNING_QTY() As Long
            Get
                Return _WARNING_QTY
            End Get
            Set(ByVal value As Long)
               _WARNING_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CRITICAL_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CRITICAL_QTY() As Long
            Get
                Return _CRITICAL_QTY
            End Get
            Set(ByVal value As Long)
               _CRITICAL_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CURRENT_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CURRENT_QTY() As Long
            Get
                Return _CURRENT_QTY
            End Get
            Set(ByVal value As Long)
               _CURRENT_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CURRENT_MONEY", DbType:="Int")>  _
        Public Property CURRENT_MONEY() As  System.Nullable(Of Long) 
            Get
                Return _CURRENT_MONEY
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _CURRENT_MONEY = value
            End Set
        End Property 
        <Column(Storage:="_MS_DEVICE_STATUS_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_DEVICE_STATUS_ID() As Long
            Get
                Return _MS_DEVICE_STATUS_ID
            End Get
            Set(ByVal value As Long)
               _MS_DEVICE_STATUS_ID = value
            End Set
        End Property 
        <Column(Storage:="_COMPORT_VID", DbType:="VarChar(50)")>  _
        Public Property COMPORT_VID() As  String 
            Get
                Return _COMPORT_VID
            End Get
            Set(ByVal value As  String )
               _COMPORT_VID = value
            End Set
        End Property 
        <Column(Storage:="_DRIVER_NAME1", DbType:="VarChar(100)")>  _
        Public Property DRIVER_NAME1() As  String 
            Get
                Return _DRIVER_NAME1
            End Get
            Set(ByVal value As  String )
               _DRIVER_NAME1 = value
            End Set
        End Property 
        <Column(Storage:="_DRIVER_NAME2", DbType:="VarChar(100)")>  _
        Public Property DRIVER_NAME2() As  String 
            Get
                Return _DRIVER_NAME2
            End Get
            Set(ByVal value As  String )
               _DRIVER_NAME2 = value
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
        <Column(Storage:="_SYNC_TO_SERVER", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property SYNC_TO_SERVER() As Char
            Get
                Return _SYNC_TO_SERVER
            End Get
            Set(ByVal value As Char)
               _SYNC_TO_SERVER = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_KIOSK_ID = 0
            _MS_DEVICE_ID = 0
            _MAX_QTY = 0
            _WARNING_QTY = 0
            _CRITICAL_QTY = 0
            _CURRENT_QTY = 0
            _CURRENT_MONEY = Nothing
            _MS_DEVICE_STATUS_ID = 0
            _COMPORT_VID = ""
            _DRIVER_NAME1 = ""
            _DRIVER_NAME2 = ""
            _SYNC_TO_KIOSK = "N"
            _SYNC_TO_SERVER = "N"
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


        '/// Returns an indication whether the current data is inserted into MS_KIOSK_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_KIOSK_DEVICE table successfully.
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


        '/// Returns an indication whether the record of MS_KIOSK_DEVICE by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_KIOSK_DEVICE by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsKioskDeviceServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of MS_KIOSK_DEVICE by specified MS_DEVICE_ID_MS_KIOSK_ID key is retrieved successfully.
        '/// <param name=cMS_DEVICE_ID_MS_KIOSK_ID>The MS_DEVICE_ID_MS_KIOSK_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(cMS_DEVICE_ID As Long, cMS_KIOSK_ID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(3)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_DEVICE_ID", cMS_DEVICE_ID) 
            cmdPara(1) = DB.SetText("@_MS_KIOSK_ID", cMS_KIOSK_ID) 
            Return doChkData("MS_DEVICE_ID = @_MS_DEVICE_ID AND MS_KIOSK_ID = @_MS_KIOSK_ID", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_KIOSK_DEVICE by specified MS_DEVICE_ID_MS_KIOSK_ID key is retrieved successfully.
        '/// <param name=cMS_DEVICE_ID_MS_KIOSK_ID>The MS_DEVICE_ID_MS_KIOSK_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_DEVICE_ID_MS_KIOSK_ID(cMS_DEVICE_ID As Long, cMS_KIOSK_ID As Long, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(3)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_DEVICE_ID", cMS_DEVICE_ID) 
            cmdPara(1) = DB.SetText("@_MS_KIOSK_ID", cMS_KIOSK_ID) 
            cmdPara(2) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("MS_DEVICE_ID = @_MS_DEVICE_ID AND MS_KIOSK_ID = @_MS_KIOSK_ID And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_KIOSK_DEVICE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_KIOSK_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_KIOSK_DEVICE table successfully.
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

            cmbParam(5) = New SqlParameter("@_MS_KIOSK_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_KIOSK_ID

            cmbParam(6) = New SqlParameter("@_MS_DEVICE_ID", SqlDbType.BigInt)
            cmbParam(6).Value = _MS_DEVICE_ID

            cmbParam(7) = New SqlParameter("@_MAX_QTY", SqlDbType.Int)
            cmbParam(7).Value = _MAX_QTY

            cmbParam(8) = New SqlParameter("@_WARNING_QTY", SqlDbType.Int)
            cmbParam(8).Value = _WARNING_QTY

            cmbParam(9) = New SqlParameter("@_CRITICAL_QTY", SqlDbType.Int)
            cmbParam(9).Value = _CRITICAL_QTY

            cmbParam(10) = New SqlParameter("@_CURRENT_QTY", SqlDbType.Int)
            cmbParam(10).Value = _CURRENT_QTY

            cmbParam(11) = New SqlParameter("@_CURRENT_MONEY", SqlDbType.Int)
            If _CURRENT_MONEY IsNot Nothing Then 
                cmbParam(11).Value = _CURRENT_MONEY.Value
            Else
                cmbParam(11).Value = DBNull.value
            End IF

            cmbParam(12) = New SqlParameter("@_MS_DEVICE_STATUS_ID", SqlDbType.BigInt)
            cmbParam(12).Value = _MS_DEVICE_STATUS_ID

            cmbParam(13) = New SqlParameter("@_COMPORT_VID", SqlDbType.VarChar)
            If _COMPORT_VID.Trim <> "" Then 
                cmbParam(13).Value = _COMPORT_VID
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_DRIVER_NAME1", SqlDbType.VarChar)
            If _DRIVER_NAME1.Trim <> "" Then 
                cmbParam(14).Value = _DRIVER_NAME1
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_DRIVER_NAME2", SqlDbType.VarChar)
            If _DRIVER_NAME2.Trim <> "" Then 
                cmbParam(15).Value = _DRIVER_NAME2
            Else
                cmbParam(15).Value = DBNull.value
            End If

            cmbParam(16) = New SqlParameter("@_SYNC_TO_KIOSK", SqlDbType.Char)
            cmbParam(16).Value = _SYNC_TO_KIOSK

            cmbParam(17) = New SqlParameter("@_SYNC_TO_SERVER", SqlDbType.Char)
            cmbParam(17).Value = _SYNC_TO_SERVER

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_KIOSK_DEVICE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_kiosk_id")) = False Then _ms_kiosk_id = Convert.ToInt64(Rdr("ms_kiosk_id"))
                        If Convert.IsDBNull(Rdr("ms_device_id")) = False Then _ms_device_id = Convert.ToInt64(Rdr("ms_device_id"))
                        If Convert.IsDBNull(Rdr("max_qty")) = False Then _max_qty = Convert.ToInt32(Rdr("max_qty"))
                        If Convert.IsDBNull(Rdr("warning_qty")) = False Then _warning_qty = Convert.ToInt32(Rdr("warning_qty"))
                        If Convert.IsDBNull(Rdr("critical_qty")) = False Then _critical_qty = Convert.ToInt32(Rdr("critical_qty"))
                        If Convert.IsDBNull(Rdr("current_qty")) = False Then _current_qty = Convert.ToInt32(Rdr("current_qty"))
                        If Convert.IsDBNull(Rdr("current_money")) = False Then _current_money = Convert.ToInt32(Rdr("current_money"))
                        If Convert.IsDBNull(Rdr("ms_device_status_id")) = False Then _ms_device_status_id = Convert.ToInt64(Rdr("ms_device_status_id"))
                        If Convert.IsDBNull(Rdr("comport_vid")) = False Then _comport_vid = Rdr("comport_vid").ToString()
                        If Convert.IsDBNull(Rdr("driver_name1")) = False Then _driver_name1 = Rdr("driver_name1").ToString()
                        If Convert.IsDBNull(Rdr("driver_name2")) = False Then _driver_name2 = Rdr("driver_name2").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_kiosk")) = False Then _sync_to_kiosk = Rdr("sync_to_kiosk").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_server")) = False Then _sync_to_server = Rdr("sync_to_server").ToString()
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


        '/// Returns an indication whether the record of MS_KIOSK_DEVICE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As MsKioskDeviceServerLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_kiosk_id")) = False Then _ms_kiosk_id = Convert.ToInt64(Rdr("ms_kiosk_id"))
                        If Convert.IsDBNull(Rdr("ms_device_id")) = False Then _ms_device_id = Convert.ToInt64(Rdr("ms_device_id"))
                        If Convert.IsDBNull(Rdr("max_qty")) = False Then _max_qty = Convert.ToInt32(Rdr("max_qty"))
                        If Convert.IsDBNull(Rdr("warning_qty")) = False Then _warning_qty = Convert.ToInt32(Rdr("warning_qty"))
                        If Convert.IsDBNull(Rdr("critical_qty")) = False Then _critical_qty = Convert.ToInt32(Rdr("critical_qty"))
                        If Convert.IsDBNull(Rdr("current_qty")) = False Then _current_qty = Convert.ToInt32(Rdr("current_qty"))
                        If Convert.IsDBNull(Rdr("current_money")) = False Then _current_money = Convert.ToInt32(Rdr("current_money"))
                        If Convert.IsDBNull(Rdr("ms_device_status_id")) = False Then _ms_device_status_id = Convert.ToInt64(Rdr("ms_device_status_id"))
                        If Convert.IsDBNull(Rdr("comport_vid")) = False Then _comport_vid = Rdr("comport_vid").ToString()
                        If Convert.IsDBNull(Rdr("driver_name1")) = False Then _driver_name1 = Rdr("driver_name1").ToString()
                        If Convert.IsDBNull(Rdr("driver_name2")) = False Then _driver_name2 = Rdr("driver_name2").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_kiosk")) = False Then _sync_to_kiosk = Rdr("sync_to_kiosk").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_server")) = False Then _sync_to_server = Rdr("sync_to_server").ToString()
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


        'Get Insert Statement for table MS_KIOSK_DEVICE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, MS_KIOSK_ID, MS_DEVICE_ID, MAX_QTY, WARNING_QTY, CRITICAL_QTY, CURRENT_QTY, CURRENT_MONEY, MS_DEVICE_STATUS_ID, COMPORT_VID, DRIVER_NAME1, DRIVER_NAME2, SYNC_TO_KIOSK, SYNC_TO_SERVER)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_KIOSK_ID, INSERTED.MS_DEVICE_ID, INSERTED.MAX_QTY, INSERTED.WARNING_QTY, INSERTED.CRITICAL_QTY, INSERTED.CURRENT_QTY, INSERTED.CURRENT_MONEY, INSERTED.MS_DEVICE_STATUS_ID, INSERTED.COMPORT_VID, INSERTED.DRIVER_NAME1, INSERTED.DRIVER_NAME2, INSERTED.SYNC_TO_KIOSK, INSERTED.SYNC_TO_SERVER"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MS_KIOSK_ID" & ", "
                sql += "@_MS_DEVICE_ID" & ", "
                sql += "@_MAX_QTY" & ", "
                sql += "@_WARNING_QTY" & ", "
                sql += "@_CRITICAL_QTY" & ", "
                sql += "@_CURRENT_QTY" & ", "
                sql += "@_CURRENT_MONEY" & ", "
                sql += "@_MS_DEVICE_STATUS_ID" & ", "
                sql += "@_COMPORT_VID" & ", "
                sql += "@_DRIVER_NAME1" & ", "
                sql += "@_DRIVER_NAME2" & ", "
                sql += "@_SYNC_TO_KIOSK" & ", "
                sql += "@_SYNC_TO_SERVER"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_KIOSK_DEVICE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_KIOSK_ID = " & "@_MS_KIOSK_ID" & ", "
                Sql += "MS_DEVICE_ID = " & "@_MS_DEVICE_ID" & ", "
                Sql += "MAX_QTY = " & "@_MAX_QTY" & ", "
                Sql += "WARNING_QTY = " & "@_WARNING_QTY" & ", "
                Sql += "CRITICAL_QTY = " & "@_CRITICAL_QTY" & ", "
                Sql += "CURRENT_QTY = " & "@_CURRENT_QTY" & ", "
                Sql += "CURRENT_MONEY = " & "@_CURRENT_MONEY" & ", "
                Sql += "MS_DEVICE_STATUS_ID = " & "@_MS_DEVICE_STATUS_ID" & ", "
                Sql += "COMPORT_VID = " & "@_COMPORT_VID" & ", "
                Sql += "DRIVER_NAME1 = " & "@_DRIVER_NAME1" & ", "
                Sql += "DRIVER_NAME2 = " & "@_DRIVER_NAME2" & ", "
                Sql += "SYNC_TO_KIOSK = " & "@_SYNC_TO_KIOSK" & ", "
                Sql += "SYNC_TO_SERVER = " & "@_SYNC_TO_SERVER" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_KIOSK_DEVICE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_KIOSK_DEVICE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_KIOSK_ID, MS_DEVICE_ID, MAX_QTY, WARNING_QTY, CRITICAL_QTY, CURRENT_QTY, CURRENT_MONEY, MS_DEVICE_STATUS_ID, COMPORT_VID, DRIVER_NAME1, DRIVER_NAME2, SYNC_TO_KIOSK, SYNC_TO_SERVER FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
