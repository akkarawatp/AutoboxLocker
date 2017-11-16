Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TB_LOGIN_HISTORY table ServerLinqDB.
    '[Create by  on November, 2 2017]
    Public Class TbLoginHistoryServerLinqDB
        Public sub TbLoginHistoryServerLinqDB()

        End Sub 
        ' TB_LOGIN_HISTORY
        Const _tableName As String = "TB_LOGIN_HISTORY"

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
        Dim _TOKEN As String = ""
        Dim _USERNAME As String = ""
        Dim _FIRST_NAME As String = ""
        Dim _LAST_NAME As String = ""
        Dim _COMPANY_NAME As String = ""
        Dim _SYS_CODE As String = ""
        Dim _LOGON_TIME As DateTime = New DateTime(1,1,1)
        Dim _CLIENT_IP As String = ""
        Dim _CLIENT_BROWSER As  String  = ""
        Dim _SERVER_URL As  String  = ""
        Dim _WEBSERVICE_URL As String = ""

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
        <Column(Storage:="_TOKEN", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property TOKEN() As String
            Get
                Return _TOKEN
            End Get
            Set(ByVal value As String)
               _TOKEN = value
            End Set
        End Property 
        <Column(Storage:="_USERNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property FIRST_NAME() As String
            Get
                Return _FIRST_NAME
            End Get
            Set(ByVal value As String)
               _FIRST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property LAST_NAME() As String
            Get
                Return _LAST_NAME
            End Get
            Set(ByVal value As String)
               _LAST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property COMPANY_NAME() As String
            Get
                Return _COMPANY_NAME
            End Get
            Set(ByVal value As String)
               _COMPANY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SYS_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property SYS_CODE() As String
            Get
                Return _SYS_CODE
            End Get
            Set(ByVal value As String)
               _SYS_CODE = value
            End Set
        End Property 
        <Column(Storage:="_LOGON_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property LOGON_TIME() As DateTime
            Get
                Return _LOGON_TIME
            End Get
            Set(ByVal value As DateTime)
               _LOGON_TIME = value
            End Set
        End Property 
        <Column(Storage:="_CLIENT_IP", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLIENT_IP() As String
            Get
                Return _CLIENT_IP
            End Get
            Set(ByVal value As String)
               _CLIENT_IP = value
            End Set
        End Property 
        <Column(Storage:="_CLIENT_BROWSER", DbType:="VarChar(50)")>  _
        Public Property CLIENT_BROWSER() As  String 
            Get
                Return _CLIENT_BROWSER
            End Get
            Set(ByVal value As  String )
               _CLIENT_BROWSER = value
            End Set
        End Property 
        <Column(Storage:="_SERVER_URL", DbType:="VarChar(255)")>  _
        Public Property SERVER_URL() As  String 
            Get
                Return _SERVER_URL
            End Get
            Set(ByVal value As  String )
               _SERVER_URL = value
            End Set
        End Property 
        <Column(Storage:="_WEBSERVICE_URL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property WEBSERVICE_URL() As String
            Get
                Return _WEBSERVICE_URL
            End Get
            Set(ByVal value As String)
               _WEBSERVICE_URL = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _TOKEN = ""
            _USERNAME = ""
            _FIRST_NAME = ""
            _LAST_NAME = ""
            _COMPANY_NAME = ""
            _SYS_CODE = ""
            _LOGON_TIME = New DateTime(1,1,1)
            _CLIENT_IP = ""
            _CLIENT_BROWSER = ""
            _SERVER_URL = ""
            _WEBSERVICE_URL = ""
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


        '/// Returns an indication whether the current data is inserted into TB_LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the record of TB_LOGIN_HISTORY by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_LOGIN_HISTORY by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbLoginHistoryServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of TB_LOGIN_HISTORY by specified TOKEN key is retrieved successfully.
        '/// <param name=cTOKEN>The TOKEN key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTOKEN(cTOKEN As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TOKEN", cTOKEN) 
            Return doChkData("TOKEN = @_TOKEN", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_LOGIN_HISTORY by specified TOKEN key is retrieved successfully.
        '/// <param name=cTOKEN>The TOKEN key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByTOKEN(cTOKEN As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TOKEN", cTOKEN) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("TOKEN = @_TOKEN And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_LOGIN_HISTORY table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_LOGIN_HISTORY table successfully.
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

            cmbParam(5) = New SqlParameter("@_TOKEN", SqlDbType.VarChar)
            cmbParam(5).Value = _TOKEN

            cmbParam(6) = New SqlParameter("@_USERNAME", SqlDbType.VarChar)
            cmbParam(6).Value = _USERNAME

            cmbParam(7) = New SqlParameter("@_FIRST_NAME", SqlDbType.VarChar)
            cmbParam(7).Value = _FIRST_NAME

            cmbParam(8) = New SqlParameter("@_LAST_NAME", SqlDbType.VarChar)
            cmbParam(8).Value = _LAST_NAME

            cmbParam(9) = New SqlParameter("@_COMPANY_NAME", SqlDbType.VarChar)
            cmbParam(9).Value = _COMPANY_NAME

            cmbParam(10) = New SqlParameter("@_SYS_CODE", SqlDbType.VarChar)
            cmbParam(10).Value = _SYS_CODE

            cmbParam(11) = New SqlParameter("@_LOGON_TIME", SqlDbType.DateTime)
            cmbParam(11).Value = _LOGON_TIME

            cmbParam(12) = New SqlParameter("@_CLIENT_IP", SqlDbType.VarChar)
            cmbParam(12).Value = _CLIENT_IP

            cmbParam(13) = New SqlParameter("@_CLIENT_BROWSER", SqlDbType.VarChar)
            If _CLIENT_BROWSER.Trim <> "" Then 
                cmbParam(13).Value = _CLIENT_BROWSER
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_SERVER_URL", SqlDbType.VarChar)
            If _SERVER_URL.Trim <> "" Then 
                cmbParam(14).Value = _SERVER_URL
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_WEBSERVICE_URL", SqlDbType.VarChar)
            cmbParam(15).Value = _WEBSERVICE_URL

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_LOGIN_HISTORY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("token")) = False Then _token = Rdr("token").ToString()
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then _last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("sys_code")) = False Then _sys_code = Rdr("sys_code").ToString()
                        If Convert.IsDBNull(Rdr("logon_time")) = False Then _logon_time = Convert.ToDateTime(Rdr("logon_time"))
                        If Convert.IsDBNull(Rdr("client_ip")) = False Then _client_ip = Rdr("client_ip").ToString()
                        If Convert.IsDBNull(Rdr("client_browser")) = False Then _client_browser = Rdr("client_browser").ToString()
                        If Convert.IsDBNull(Rdr("server_url")) = False Then _server_url = Rdr("server_url").ToString()
                        If Convert.IsDBNull(Rdr("webservice_url")) = False Then _webservice_url = Rdr("webservice_url").ToString()
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


        '/// Returns an indication whether the record of TB_LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As TbLoginHistoryServerLinqDB
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
                        If Convert.IsDBNull(Rdr("token")) = False Then _token = Rdr("token").ToString()
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then _last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("sys_code")) = False Then _sys_code = Rdr("sys_code").ToString()
                        If Convert.IsDBNull(Rdr("logon_time")) = False Then _logon_time = Convert.ToDateTime(Rdr("logon_time"))
                        If Convert.IsDBNull(Rdr("client_ip")) = False Then _client_ip = Rdr("client_ip").ToString()
                        If Convert.IsDBNull(Rdr("client_browser")) = False Then _client_browser = Rdr("client_browser").ToString()
                        If Convert.IsDBNull(Rdr("server_url")) = False Then _server_url = Rdr("server_url").ToString()
                        If Convert.IsDBNull(Rdr("webservice_url")) = False Then _webservice_url = Rdr("webservice_url").ToString()
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


        'Get Insert Statement for table TB_LOGIN_HISTORY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, TOKEN, USERNAME, FIRST_NAME, LAST_NAME, COMPANY_NAME, SYS_CODE, LOGON_TIME, CLIENT_IP, CLIENT_BROWSER, SERVER_URL, WEBSERVICE_URL)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.TOKEN, INSERTED.USERNAME, INSERTED.FIRST_NAME, INSERTED.LAST_NAME, INSERTED.COMPANY_NAME, INSERTED.SYS_CODE, INSERTED.LOGON_TIME, INSERTED.CLIENT_IP, INSERTED.CLIENT_BROWSER, INSERTED.SERVER_URL, INSERTED.WEBSERVICE_URL"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_TOKEN" & ", "
                sql += "@_USERNAME" & ", "
                sql += "@_FIRST_NAME" & ", "
                sql += "@_LAST_NAME" & ", "
                sql += "@_COMPANY_NAME" & ", "
                sql += "@_SYS_CODE" & ", "
                sql += "@_LOGON_TIME" & ", "
                sql += "@_CLIENT_IP" & ", "
                sql += "@_CLIENT_BROWSER" & ", "
                sql += "@_SERVER_URL" & ", "
                sql += "@_WEBSERVICE_URL"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_LOGIN_HISTORY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "TOKEN = " & "@_TOKEN" & ", "
                Sql += "USERNAME = " & "@_USERNAME" & ", "
                Sql += "FIRST_NAME = " & "@_FIRST_NAME" & ", "
                Sql += "LAST_NAME = " & "@_LAST_NAME" & ", "
                Sql += "COMPANY_NAME = " & "@_COMPANY_NAME" & ", "
                Sql += "SYS_CODE = " & "@_SYS_CODE" & ", "
                Sql += "LOGON_TIME = " & "@_LOGON_TIME" & ", "
                Sql += "CLIENT_IP = " & "@_CLIENT_IP" & ", "
                Sql += "CLIENT_BROWSER = " & "@_CLIENT_BROWSER" & ", "
                Sql += "SERVER_URL = " & "@_SERVER_URL" & ", "
                Sql += "WEBSERVICE_URL = " & "@_WEBSERVICE_URL" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_LOGIN_HISTORY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_LOGIN_HISTORY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, TOKEN, USERNAME, FIRST_NAME, LAST_NAME, COMPANY_NAME, SYS_CODE, LOGON_TIME, CLIENT_IP, CLIENT_BROWSER, SERVER_URL, WEBSERVICE_URL FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
