Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for MS_MASTER_MONITORING_ALARM table ServerLinqDB.
    '[Create by  on June, 12 2016]
    Public Class MsMasterMonitoringAlarmServerLinqDB
        Public sub MsMasterMonitoringAlarmServerLinqDB()

        End Sub 
        ' MS_MASTER_MONITORING_ALARM
        Const _tableName As String = "MS_MASTER_MONITORING_ALARM"

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
        Dim _MS_MASTER_MONITORING_TYPE_ID As  System.Nullable(Of Long) 
        Dim _ALARM_CODE As  String  = ""
        Dim _ALARM_PROBLEM As  String  = ""
        Dim _ENG_DESC As  String  = ""
        Dim _THA_DESC As  String  = ""
        Dim _SMS_MESSAGE As  String  = ""

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
        <Column(Storage:="_MS_MASTER_MONITORING_TYPE_ID", DbType:="BigInt")>  _
        Public Property MS_MASTER_MONITORING_TYPE_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_MASTER_MONITORING_TYPE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_MASTER_MONITORING_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_ALARM_CODE", DbType:="VarChar(255)")>  _
        Public Property ALARM_CODE() As  String 
            Get
                Return _ALARM_CODE
            End Get
            Set(ByVal value As  String )
               _ALARM_CODE = value
            End Set
        End Property 
        <Column(Storage:="_ALARM_PROBLEM", DbType:="VarChar(255)")>  _
        Public Property ALARM_PROBLEM() As  String 
            Get
                Return _ALARM_PROBLEM
            End Get
            Set(ByVal value As  String )
               _ALARM_PROBLEM = value
            End Set
        End Property 
        <Column(Storage:="_ENG_DESC", DbType:="VarChar(255)")>  _
        Public Property ENG_DESC() As  String 
            Get
                Return _ENG_DESC
            End Get
            Set(ByVal value As  String )
               _ENG_DESC = value
            End Set
        End Property 
        <Column(Storage:="_THA_DESC", DbType:="VarChar(255)")>  _
        Public Property THA_DESC() As  String 
            Get
                Return _THA_DESC
            End Get
            Set(ByVal value As  String )
               _THA_DESC = value
            End Set
        End Property 
        <Column(Storage:="_SMS_MESSAGE", DbType:="VarChar(255)")>  _
        Public Property SMS_MESSAGE() As  String 
            Get
                Return _SMS_MESSAGE
            End Get
            Set(ByVal value As  String )
               _SMS_MESSAGE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_MASTER_MONITORING_TYPE_ID = Nothing
            _ALARM_CODE = ""
            _ALARM_PROBLEM = ""
            _ENG_DESC = ""
            _THA_DESC = ""
            _SMS_MESSAGE = ""
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


        '/// Returns an indication whether the current data is inserted into MS_MASTER_MONITORING_ALARM table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(CreatedBy As String,trans As SQLTransaction) As ExecuteDataInfo
            If trans IsNot Nothing Then 
                _ID = DB.GetNextID("ID",tableName, trans)
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


        '/// Returns an indication whether the current data is updated to MS_MASTER_MONITORING_ALARM table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MASTER_MONITORING_ALARM table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_MASTER_MONITORING_ALARM table successfully.
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


        '/// Returns an indication whether the record of MS_MASTER_MONITORING_ALARM by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_MASTER_MONITORING_ALARM by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsMasterMonitoringAlarmServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of MS_MASTER_MONITORING_ALARM by specified ALARM_PROBLEM key is retrieved successfully.
        '/// <param name=cALARM_PROBLEM>The ALARM_PROBLEM key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByALARM_PROBLEM(cALARM_PROBLEM As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_ALARM_PROBLEM", cALARM_PROBLEM) 
            Return doChkData("ALARM_PROBLEM = @_ALARM_PROBLEM", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_MASTER_MONITORING_ALARM by specified ALARM_PROBLEM key is retrieved successfully.
        '/// <param name=cALARM_PROBLEM>The ALARM_PROBLEM key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByALARM_PROBLEM(cALARM_PROBLEM As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_ALARM_PROBLEM", cALARM_PROBLEM) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("ALARM_PROBLEM = @_ALARM_PROBLEM And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_MASTER_MONITORING_ALARM by specified MS_MASTER_MONITORING_TYPE_ID key is retrieved successfully.
        '/// <param name=cMS_MASTER_MONITORING_TYPE_ID>The MS_MASTER_MONITORING_TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_MASTER_MONITORING_TYPE_ID(cMS_MASTER_MONITORING_TYPE_ID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_MASTER_MONITORING_TYPE_ID", cMS_MASTER_MONITORING_TYPE_ID) 
            Return doChkData("MS_MASTER_MONITORING_TYPE_ID = @_MS_MASTER_MONITORING_TYPE_ID", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_MASTER_MONITORING_ALARM by specified MS_MASTER_MONITORING_TYPE_ID key is retrieved successfully.
        '/// <param name=cMS_MASTER_MONITORING_TYPE_ID>The MS_MASTER_MONITORING_TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_MASTER_MONITORING_TYPE_ID(cMS_MASTER_MONITORING_TYPE_ID As Long, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_MASTER_MONITORING_TYPE_ID", cMS_MASTER_MONITORING_TYPE_ID) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("MS_MASTER_MONITORING_TYPE_ID = @_MS_MASTER_MONITORING_TYPE_ID And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_MASTER_MONITORING_ALARM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_MASTER_MONITORING_ALARM table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_MASTER_MONITORING_ALARM table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_MASTER_MONITORING_ALARM table successfully.
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
            Dim cmbParam(10) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MS_MASTER_MONITORING_TYPE_ID", SqlDbType.BigInt)
            If _MS_MASTER_MONITORING_TYPE_ID IsNot Nothing Then 
                cmbParam(5).Value = _MS_MASTER_MONITORING_TYPE_ID.Value
            Else
                cmbParam(5).Value = DBNull.value
            End IF

            cmbParam(6) = New SqlParameter("@_ALARM_CODE", SqlDbType.VarChar)
            If _ALARM_CODE.Trim <> "" Then 
                cmbParam(6).Value = _ALARM_CODE
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_ALARM_PROBLEM", SqlDbType.VarChar)
            If _ALARM_PROBLEM.Trim <> "" Then 
                cmbParam(7).Value = _ALARM_PROBLEM
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_ENG_DESC", SqlDbType.VarChar)
            If _ENG_DESC.Trim <> "" Then 
                cmbParam(8).Value = _ENG_DESC
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_THA_DESC", SqlDbType.VarChar)
            If _THA_DESC.Trim <> "" Then 
                cmbParam(9).Value = _THA_DESC
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_SMS_MESSAGE", SqlDbType.VarChar)
            If _SMS_MESSAGE.Trim <> "" Then 
                cmbParam(10).Value = _SMS_MESSAGE
            Else
                cmbParam(10).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_MASTER_MONITORING_ALARM by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_master_monitoring_type_id")) = False Then _ms_master_monitoring_type_id = Convert.ToInt64(Rdr("ms_master_monitoring_type_id"))
                        If Convert.IsDBNull(Rdr("alarm_code")) = False Then _alarm_code = Rdr("alarm_code").ToString()
                        If Convert.IsDBNull(Rdr("alarm_problem")) = False Then _alarm_problem = Rdr("alarm_problem").ToString()
                        If Convert.IsDBNull(Rdr("eng_desc")) = False Then _eng_desc = Rdr("eng_desc").ToString()
                        If Convert.IsDBNull(Rdr("tha_desc")) = False Then _tha_desc = Rdr("tha_desc").ToString()
                        If Convert.IsDBNull(Rdr("sms_message")) = False Then _sms_message = Rdr("sms_message").ToString()
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


        '/// Returns an indication whether the record of MS_MASTER_MONITORING_ALARM by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As MsMasterMonitoringAlarmServerLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_master_monitoring_type_id")) = False Then _ms_master_monitoring_type_id = Convert.ToInt64(Rdr("ms_master_monitoring_type_id"))
                        If Convert.IsDBNull(Rdr("alarm_code")) = False Then _alarm_code = Rdr("alarm_code").ToString()
                        If Convert.IsDBNull(Rdr("alarm_problem")) = False Then _alarm_problem = Rdr("alarm_problem").ToString()
                        If Convert.IsDBNull(Rdr("eng_desc")) = False Then _eng_desc = Rdr("eng_desc").ToString()
                        If Convert.IsDBNull(Rdr("tha_desc")) = False Then _tha_desc = Rdr("tha_desc").ToString()
                        If Convert.IsDBNull(Rdr("sms_message")) = False Then _sms_message = Rdr("sms_message").ToString()
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


        'Get Insert Statement for table MS_MASTER_MONITORING_ALARM
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATED_BY, CREATED_DATE, MS_MASTER_MONITORING_TYPE_ID, ALARM_CODE, ALARM_PROBLEM, ENG_DESC, THA_DESC, SMS_MESSAGE)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_MASTER_MONITORING_TYPE_ID, INSERTED.ALARM_CODE, INSERTED.ALARM_PROBLEM, INSERTED.ENG_DESC, INSERTED.THA_DESC, INSERTED.SMS_MESSAGE"
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MS_MASTER_MONITORING_TYPE_ID" & ", "
                sql += "@_ALARM_CODE" & ", "
                sql += "@_ALARM_PROBLEM" & ", "
                sql += "@_ENG_DESC" & ", "
                sql += "@_THA_DESC" & ", "
                sql += "@_SMS_MESSAGE"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_MASTER_MONITORING_ALARM
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_MASTER_MONITORING_TYPE_ID = " & "@_MS_MASTER_MONITORING_TYPE_ID" & ", "
                Sql += "ALARM_CODE = " & "@_ALARM_CODE" & ", "
                Sql += "ALARM_PROBLEM = " & "@_ALARM_PROBLEM" & ", "
                Sql += "ENG_DESC = " & "@_ENG_DESC" & ", "
                Sql += "THA_DESC = " & "@_THA_DESC" & ", "
                Sql += "SMS_MESSAGE = " & "@_SMS_MESSAGE" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_MASTER_MONITORING_ALARM
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_MASTER_MONITORING_ALARM
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_MASTER_MONITORING_TYPE_ID, ALARM_CODE, ALARM_PROBLEM, ENG_DESC, THA_DESC, SMS_MESSAGE FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
