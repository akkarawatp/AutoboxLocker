Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TB_STAFF_CONSOLE_TRANSACTION table ServerLinqDB.
    '[Create by  on November, 17 2017]
    Public Class TbStaffConsoleTransactionServerLinqDB
        Public sub TbStaffConsoleTransactionServerLinqDB()

        End Sub 
        ' TB_STAFF_CONSOLE_TRANSACTION
        Const _tableName As String = "TB_STAFF_CONSOLE_TRANSACTION"

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
        Dim _TRANS_NO As String = ""
        Dim _TRANS_START_TIME As DateTime = New DateTime(1,1,1)
        Dim _TRANS_END_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MS_KIOSK_ID As Long = 0
        Dim _LOGIN_USERNAME As  String  = ""
        Dim _LOGIN_FIRST_NAME As  String  = ""
        Dim _LOGIN_LAST_NAME As  String  = ""
        Dim _LOGIN_COMPANY_NAME As  String  = ""
        Dim _LOGIN_BY As  System.Nullable(Of Char)  = "0"
        Dim _MS_APP_STEP_ID As  System.Nullable(Of Long) 
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
        <Column(Storage:="_TRANS_NO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property TRANS_NO() As String
            Get
                Return _TRANS_NO
            End Get
            Set(ByVal value As String)
               _TRANS_NO = value
            End Set
        End Property 
        <Column(Storage:="_TRANS_START_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property TRANS_START_TIME() As DateTime
            Get
                Return _TRANS_START_TIME
            End Get
            Set(ByVal value As DateTime)
               _TRANS_START_TIME = value
            End Set
        End Property 
        <Column(Storage:="_TRANS_END_TIME", DbType:="DateTime")>  _
        Public Property TRANS_END_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _TRANS_END_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _TRANS_END_TIME = value
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
        <Column(Storage:="_LOGIN_USERNAME", DbType:="VarChar(50)")>  _
        Public Property LOGIN_USERNAME() As  String 
            Get
                Return _LOGIN_USERNAME
            End Get
            Set(ByVal value As  String )
               _LOGIN_USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_FIRST_NAME", DbType:="VarChar(100)")>  _
        Public Property LOGIN_FIRST_NAME() As  String 
            Get
                Return _LOGIN_FIRST_NAME
            End Get
            Set(ByVal value As  String )
               _LOGIN_FIRST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_LAST_NAME", DbType:="VarChar(100)")>  _
        Public Property LOGIN_LAST_NAME() As  String 
            Get
                Return _LOGIN_LAST_NAME
            End Get
            Set(ByVal value As  String )
               _LOGIN_LAST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_COMPANY_NAME", DbType:="VarChar(255)")>  _
        Public Property LOGIN_COMPANY_NAME() As  String 
            Get
                Return _LOGIN_COMPANY_NAME
            End Get
            Set(ByVal value As  String )
               _LOGIN_COMPANY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_BY", DbType:="Char(1)")>  _
        Public Property LOGIN_BY() As  System.Nullable(Of Char) 
            Get
                Return _LOGIN_BY
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _LOGIN_BY = value
            End Set
        End Property 
        <Column(Storage:="_MS_APP_STEP_ID", DbType:="BigInt")>  _
        Public Property MS_APP_STEP_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_APP_STEP_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_APP_STEP_ID = value
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
            _TRANS_NO = ""
            _TRANS_START_TIME = New DateTime(1,1,1)
            _TRANS_END_TIME = New DateTime(1,1,1)
            _MS_KIOSK_ID = 0
            _LOGIN_USERNAME = ""
            _LOGIN_FIRST_NAME = ""
            _LOGIN_LAST_NAME = ""
            _LOGIN_COMPANY_NAME = ""
            _LOGIN_BY = "0"
            _MS_APP_STEP_ID = Nothing
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


        '/// Returns an indication whether the current data is inserted into TB_STAFF_CONSOLE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_STAFF_CONSOLE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_STAFF_CONSOLE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_STAFF_CONSOLE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the record of TB_STAFF_CONSOLE_TRANSACTION by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_STAFF_CONSOLE_TRANSACTION by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbStaffConsoleTransactionServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of TB_STAFF_CONSOLE_TRANSACTION by specified TRANS_NO key is retrieved successfully.
        '/// <param name=cTRANS_NO>The TRANS_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTRANS_NO(cTRANS_NO As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TRANS_NO", cTRANS_NO) 
            Return doChkData("TRANS_NO = @_TRANS_NO", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_STAFF_CONSOLE_TRANSACTION by specified TRANS_NO key is retrieved successfully.
        '/// <param name=cTRANS_NO>The TRANS_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByTRANS_NO(cTRANS_NO As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TRANS_NO", cTRANS_NO) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("TRANS_NO = @_TRANS_NO And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_STAFF_CONSOLE_TRANSACTION by specified LOGIN_USERNAME key is retrieved successfully.
        '/// <param name=cLOGIN_USERNAME>The LOGIN_USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByLOGIN_USERNAME(cLOGIN_USERNAME As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_LOGIN_USERNAME", cLOGIN_USERNAME) 
            Return doChkData("LOGIN_USERNAME = @_LOGIN_USERNAME", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_STAFF_CONSOLE_TRANSACTION by specified LOGIN_USERNAME key is retrieved successfully.
        '/// <param name=cLOGIN_USERNAME>The LOGIN_USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByLOGIN_USERNAME(cLOGIN_USERNAME As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_LOGIN_USERNAME", cLOGIN_USERNAME) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("LOGIN_USERNAME = @_LOGIN_USERNAME And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_STAFF_CONSOLE_TRANSACTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_STAFF_CONSOLE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_STAFF_CONSOLE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_STAFF_CONSOLE_TRANSACTION table successfully.
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
            Dim cmbParam(15) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_TRANS_NO", SqlDbType.VarChar)
            cmbParam(5).Value = _TRANS_NO

            cmbParam(6) = New SqlParameter("@_TRANS_START_TIME", SqlDbType.DateTime)
            cmbParam(6).Value = _TRANS_START_TIME

            cmbParam(7) = New SqlParameter("@_TRANS_END_TIME", SqlDbType.DateTime)
            If _TRANS_END_TIME.Value.Year > 1 Then 
                cmbParam(7).Value = _TRANS_END_TIME.Value
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_MS_KIOSK_ID", SqlDbType.BigInt)
            cmbParam(8).Value = _MS_KIOSK_ID

            cmbParam(9) = New SqlParameter("@_LOGIN_USERNAME", SqlDbType.VarChar)
            If _LOGIN_USERNAME.Trim <> "" Then 
                cmbParam(9).Value = _LOGIN_USERNAME
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_LOGIN_FIRST_NAME", SqlDbType.VarChar)
            If _LOGIN_FIRST_NAME.Trim <> "" Then 
                cmbParam(10).Value = _LOGIN_FIRST_NAME
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_LOGIN_LAST_NAME", SqlDbType.VarChar)
            If _LOGIN_LAST_NAME.Trim <> "" Then 
                cmbParam(11).Value = _LOGIN_LAST_NAME
            Else
                cmbParam(11).Value = DBNull.value
            End If

            cmbParam(12) = New SqlParameter("@_LOGIN_COMPANY_NAME", SqlDbType.VarChar)
            If _LOGIN_COMPANY_NAME.Trim <> "" Then 
                cmbParam(12).Value = _LOGIN_COMPANY_NAME
            Else
                cmbParam(12).Value = DBNull.value
            End If

            cmbParam(13) = New SqlParameter("@_LOGIN_BY", SqlDbType.Char)
            If _LOGIN_BY.Value <> "" Then 
                cmbParam(13).Value = _LOGIN_BY.Value
            Else
                cmbParam(13).Value = DBNull.value
            End IF

            cmbParam(14) = New SqlParameter("@_MS_APP_STEP_ID", SqlDbType.BigInt)
            If _MS_APP_STEP_ID IsNot Nothing Then 
                cmbParam(14).Value = _MS_APP_STEP_ID.Value
            Else
                cmbParam(14).Value = DBNull.value
            End IF

            cmbParam(15) = New SqlParameter("@_SYNC_TO_SERVER", SqlDbType.Char)
            cmbParam(15).Value = _SYNC_TO_SERVER

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_STAFF_CONSOLE_TRANSACTION by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("trans_no")) = False Then _trans_no = Rdr("trans_no").ToString()
                        If Convert.IsDBNull(Rdr("trans_start_time")) = False Then _trans_start_time = Convert.ToDateTime(Rdr("trans_start_time"))
                        If Convert.IsDBNull(Rdr("trans_end_time")) = False Then _trans_end_time = Convert.ToDateTime(Rdr("trans_end_time"))
                        If Convert.IsDBNull(Rdr("ms_kiosk_id")) = False Then _ms_kiosk_id = Convert.ToInt64(Rdr("ms_kiosk_id"))
                        If Convert.IsDBNull(Rdr("login_username")) = False Then _login_username = Rdr("login_username").ToString()
                        If Convert.IsDBNull(Rdr("login_first_name")) = False Then _login_first_name = Rdr("login_first_name").ToString()
                        If Convert.IsDBNull(Rdr("login_last_name")) = False Then _login_last_name = Rdr("login_last_name").ToString()
                        If Convert.IsDBNull(Rdr("login_company_name")) = False Then _login_company_name = Rdr("login_company_name").ToString()
                        If Convert.IsDBNull(Rdr("login_by")) = False Then _login_by = Rdr("login_by").ToString()
                        If Convert.IsDBNull(Rdr("ms_app_step_id")) = False Then _ms_app_step_id = Convert.ToInt64(Rdr("ms_app_step_id"))
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


        '/// Returns an indication whether the record of TB_STAFF_CONSOLE_TRANSACTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As TbStaffConsoleTransactionServerLinqDB
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
                        If Convert.IsDBNull(Rdr("trans_no")) = False Then _trans_no = Rdr("trans_no").ToString()
                        If Convert.IsDBNull(Rdr("trans_start_time")) = False Then _trans_start_time = Convert.ToDateTime(Rdr("trans_start_time"))
                        If Convert.IsDBNull(Rdr("trans_end_time")) = False Then _trans_end_time = Convert.ToDateTime(Rdr("trans_end_time"))
                        If Convert.IsDBNull(Rdr("ms_kiosk_id")) = False Then _ms_kiosk_id = Convert.ToInt64(Rdr("ms_kiosk_id"))
                        If Convert.IsDBNull(Rdr("login_username")) = False Then _login_username = Rdr("login_username").ToString()
                        If Convert.IsDBNull(Rdr("login_first_name")) = False Then _login_first_name = Rdr("login_first_name").ToString()
                        If Convert.IsDBNull(Rdr("login_last_name")) = False Then _login_last_name = Rdr("login_last_name").ToString()
                        If Convert.IsDBNull(Rdr("login_company_name")) = False Then _login_company_name = Rdr("login_company_name").ToString()
                        If Convert.IsDBNull(Rdr("login_by")) = False Then _login_by = Rdr("login_by").ToString()
                        If Convert.IsDBNull(Rdr("ms_app_step_id")) = False Then _ms_app_step_id = Convert.ToInt64(Rdr("ms_app_step_id"))
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


        'Get Insert Statement for table TB_STAFF_CONSOLE_TRANSACTION
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, TRANS_NO, TRANS_START_TIME, TRANS_END_TIME, MS_KIOSK_ID, LOGIN_USERNAME, LOGIN_FIRST_NAME, LOGIN_LAST_NAME, LOGIN_COMPANY_NAME, LOGIN_BY, MS_APP_STEP_ID, SYNC_TO_SERVER)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.TRANS_NO, INSERTED.TRANS_START_TIME, INSERTED.TRANS_END_TIME, INSERTED.MS_KIOSK_ID, INSERTED.LOGIN_USERNAME, INSERTED.LOGIN_FIRST_NAME, INSERTED.LOGIN_LAST_NAME, INSERTED.LOGIN_COMPANY_NAME, INSERTED.LOGIN_BY, INSERTED.MS_APP_STEP_ID, INSERTED.SYNC_TO_SERVER"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_TRANS_NO" & ", "
                sql += "@_TRANS_START_TIME" & ", "
                sql += "@_TRANS_END_TIME" & ", "
                sql += "@_MS_KIOSK_ID" & ", "
                sql += "@_LOGIN_USERNAME" & ", "
                sql += "@_LOGIN_FIRST_NAME" & ", "
                sql += "@_LOGIN_LAST_NAME" & ", "
                sql += "@_LOGIN_COMPANY_NAME" & ", "
                sql += "@_LOGIN_BY" & ", "
                sql += "@_MS_APP_STEP_ID" & ", "
                sql += "@_SYNC_TO_SERVER"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_STAFF_CONSOLE_TRANSACTION
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "TRANS_NO = " & "@_TRANS_NO" & ", "
                Sql += "TRANS_START_TIME = " & "@_TRANS_START_TIME" & ", "
                Sql += "TRANS_END_TIME = " & "@_TRANS_END_TIME" & ", "
                Sql += "MS_KIOSK_ID = " & "@_MS_KIOSK_ID" & ", "
                Sql += "LOGIN_USERNAME = " & "@_LOGIN_USERNAME" & ", "
                Sql += "LOGIN_FIRST_NAME = " & "@_LOGIN_FIRST_NAME" & ", "
                Sql += "LOGIN_LAST_NAME = " & "@_LOGIN_LAST_NAME" & ", "
                Sql += "LOGIN_COMPANY_NAME = " & "@_LOGIN_COMPANY_NAME" & ", "
                Sql += "LOGIN_BY = " & "@_LOGIN_BY" & ", "
                Sql += "MS_APP_STEP_ID = " & "@_MS_APP_STEP_ID" & ", "
                Sql += "SYNC_TO_SERVER = " & "@_SYNC_TO_SERVER" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_STAFF_CONSOLE_TRANSACTION
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_STAFF_CONSOLE_TRANSACTION
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, TRANS_NO, TRANS_START_TIME, TRANS_END_TIME, MS_KIOSK_ID, LOGIN_USERNAME, LOGIN_FIRST_NAME, LOGIN_LAST_NAME, LOGIN_COMPANY_NAME, LOGIN_BY, MS_APP_STEP_ID, SYNC_TO_SERVER FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
