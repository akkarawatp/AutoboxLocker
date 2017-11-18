Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for CF_SERVER_SYSCONFIG table ServerLinqDB.
    '[Create by  on November, 18 2017]
    Public Class CfServerSysconfigServerLinqDB
        Public sub CfServerSysconfigServerLinqDB()

        End Sub 
        ' CF_SERVER_SYSCONFIG
        Const _tableName As String = "CF_SERVER_SYSCONFIG"

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
        Dim _MONITOR_WEBSERVICE_URL As  String  = ""
        Dim _ALARM_WEBSERVICE_URL As  String  = ""
        Dim _MAIL_SERVER As  String  = ""
        Dim _MAIL_SENDER As  String  = ""
        Dim _MAIL_PASSWD As  String  = ""
        Dim _MAIL_PORT As  System.Nullable(Of Long) 
        Dim _MAIL_SSL As  System.Nullable(Of Char)  = ""

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
        <Column(Storage:="_MONITOR_WEBSERVICE_URL", DbType:="VarChar(255)")>  _
        Public Property MONITOR_WEBSERVICE_URL() As  String 
            Get
                Return _MONITOR_WEBSERVICE_URL
            End Get
            Set(ByVal value As  String )
               _MONITOR_WEBSERVICE_URL = value
            End Set
        End Property 
        <Column(Storage:="_ALARM_WEBSERVICE_URL", DbType:="VarChar(255)")>  _
        Public Property ALARM_WEBSERVICE_URL() As  String 
            Get
                Return _ALARM_WEBSERVICE_URL
            End Get
            Set(ByVal value As  String )
               _ALARM_WEBSERVICE_URL = value
            End Set
        End Property 
        <Column(Storage:="_MAIL_SERVER", DbType:="VarChar(50)")>  _
        Public Property MAIL_SERVER() As  String 
            Get
                Return _MAIL_SERVER
            End Get
            Set(ByVal value As  String )
               _MAIL_SERVER = value
            End Set
        End Property 
        <Column(Storage:="_MAIL_SENDER", DbType:="VarChar(100)")>  _
        Public Property MAIL_SENDER() As  String 
            Get
                Return _MAIL_SENDER
            End Get
            Set(ByVal value As  String )
               _MAIL_SENDER = value
            End Set
        End Property 
        <Column(Storage:="_MAIL_PASSWD", DbType:="VarChar(100)")>  _
        Public Property MAIL_PASSWD() As  String 
            Get
                Return _MAIL_PASSWD
            End Get
            Set(ByVal value As  String )
               _MAIL_PASSWD = value
            End Set
        End Property 
        <Column(Storage:="_MAIL_PORT", DbType:="Int")>  _
        Public Property MAIL_PORT() As  System.Nullable(Of Long) 
            Get
                Return _MAIL_PORT
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MAIL_PORT = value
            End Set
        End Property 
        <Column(Storage:="_MAIL_SSL", DbType:="Char(1)")>  _
        Public Property MAIL_SSL() As  System.Nullable(Of Char) 
            Get
                Return _MAIL_SSL
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _MAIL_SSL = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MONITOR_WEBSERVICE_URL = ""
            _ALARM_WEBSERVICE_URL = ""
            _MAIL_SERVER = ""
            _MAIL_SENDER = ""
            _MAIL_PASSWD = ""
            _MAIL_PORT = Nothing
            _MAIL_SSL = ""
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


        '/// Returns an indication whether the current data is inserted into CF_SERVER_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_SERVER_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_SERVER_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is deleted from CF_SERVER_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the record of CF_SERVER_SYSCONFIG by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of CF_SERVER_SYSCONFIG by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As CfServerSysconfigServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of CF_SERVER_SYSCONFIG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into CF_SERVER_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_SERVER_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is deleted from CF_SERVER_SYSCONFIG table successfully.
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
            Dim cmbParam(11) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MONITOR_WEBSERVICE_URL", SqlDbType.VarChar)
            If _MONITOR_WEBSERVICE_URL.Trim <> "" Then 
                cmbParam(5).Value = _MONITOR_WEBSERVICE_URL
            Else
                cmbParam(5).Value = DBNull.value
            End If

            cmbParam(6) = New SqlParameter("@_ALARM_WEBSERVICE_URL", SqlDbType.VarChar)
            If _ALARM_WEBSERVICE_URL.Trim <> "" Then 
                cmbParam(6).Value = _ALARM_WEBSERVICE_URL
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_MAIL_SERVER", SqlDbType.VarChar)
            If _MAIL_SERVER.Trim <> "" Then 
                cmbParam(7).Value = _MAIL_SERVER
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_MAIL_SENDER", SqlDbType.VarChar)
            If _MAIL_SENDER.Trim <> "" Then 
                cmbParam(8).Value = _MAIL_SENDER
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_MAIL_PASSWD", SqlDbType.VarChar)
            If _MAIL_PASSWD.Trim <> "" Then 
                cmbParam(9).Value = _MAIL_PASSWD
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_MAIL_PORT", SqlDbType.Int)
            If _MAIL_PORT IsNot Nothing Then 
                cmbParam(10).Value = _MAIL_PORT.Value
            Else
                cmbParam(10).Value = DBNull.value
            End IF

            cmbParam(11) = New SqlParameter("@_MAIL_SSL", SqlDbType.Char)
            If _MAIL_SSL.Value <> "" Then 
                cmbParam(11).Value = _MAIL_SSL.Value
            Else
                cmbParam(11).Value = DBNull.value
            End IF

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of CF_SERVER_SYSCONFIG by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("monitor_webservice_url")) = False Then _monitor_webservice_url = Rdr("monitor_webservice_url").ToString()
                        If Convert.IsDBNull(Rdr("alarm_webservice_url")) = False Then _alarm_webservice_url = Rdr("alarm_webservice_url").ToString()
                        If Convert.IsDBNull(Rdr("mail_server")) = False Then _mail_server = Rdr("mail_server").ToString()
                        If Convert.IsDBNull(Rdr("mail_sender")) = False Then _mail_sender = Rdr("mail_sender").ToString()
                        If Convert.IsDBNull(Rdr("mail_passwd")) = False Then _mail_passwd = Rdr("mail_passwd").ToString()
                        If Convert.IsDBNull(Rdr("mail_port")) = False Then _mail_port = Convert.ToInt32(Rdr("mail_port"))
                        If Convert.IsDBNull(Rdr("mail_ssl")) = False Then _mail_ssl = Rdr("mail_ssl").ToString()
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


        '/// Returns an indication whether the record of CF_SERVER_SYSCONFIG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As CfServerSysconfigServerLinqDB
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
                        If Convert.IsDBNull(Rdr("monitor_webservice_url")) = False Then _monitor_webservice_url = Rdr("monitor_webservice_url").ToString()
                        If Convert.IsDBNull(Rdr("alarm_webservice_url")) = False Then _alarm_webservice_url = Rdr("alarm_webservice_url").ToString()
                        If Convert.IsDBNull(Rdr("mail_server")) = False Then _mail_server = Rdr("mail_server").ToString()
                        If Convert.IsDBNull(Rdr("mail_sender")) = False Then _mail_sender = Rdr("mail_sender").ToString()
                        If Convert.IsDBNull(Rdr("mail_passwd")) = False Then _mail_passwd = Rdr("mail_passwd").ToString()
                        If Convert.IsDBNull(Rdr("mail_port")) = False Then _mail_port = Convert.ToInt32(Rdr("mail_port"))
                        If Convert.IsDBNull(Rdr("mail_ssl")) = False Then _mail_ssl = Rdr("mail_ssl").ToString()
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


        'Get Insert Statement for table CF_SERVER_SYSCONFIG
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, MONITOR_WEBSERVICE_URL, ALARM_WEBSERVICE_URL, MAIL_SERVER, MAIL_SENDER, MAIL_PASSWD, MAIL_PORT, MAIL_SSL)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MONITOR_WEBSERVICE_URL, INSERTED.ALARM_WEBSERVICE_URL, INSERTED.MAIL_SERVER, INSERTED.MAIL_SENDER, INSERTED.MAIL_PASSWD, INSERTED.MAIL_PORT, INSERTED.MAIL_SSL"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MONITOR_WEBSERVICE_URL" & ", "
                sql += "@_ALARM_WEBSERVICE_URL" & ", "
                sql += "@_MAIL_SERVER" & ", "
                sql += "@_MAIL_SENDER" & ", "
                sql += "@_MAIL_PASSWD" & ", "
                sql += "@_MAIL_PORT" & ", "
                sql += "@_MAIL_SSL"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table CF_SERVER_SYSCONFIG
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MONITOR_WEBSERVICE_URL = " & "@_MONITOR_WEBSERVICE_URL" & ", "
                Sql += "ALARM_WEBSERVICE_URL = " & "@_ALARM_WEBSERVICE_URL" & ", "
                Sql += "MAIL_SERVER = " & "@_MAIL_SERVER" & ", "
                Sql += "MAIL_SENDER = " & "@_MAIL_SENDER" & ", "
                Sql += "MAIL_PASSWD = " & "@_MAIL_PASSWD" & ", "
                Sql += "MAIL_PORT = " & "@_MAIL_PORT" & ", "
                Sql += "MAIL_SSL = " & "@_MAIL_SSL" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table CF_SERVER_SYSCONFIG
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table CF_SERVER_SYSCONFIG
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MONITOR_WEBSERVICE_URL, ALARM_WEBSERVICE_URL, MAIL_SERVER, MAIL_SENDER, MAIL_PASSWD, MAIL_PORT, MAIL_SSL FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
