Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = KioskLinqDB.ConnectDB.KioskDB
Imports KioskLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TB_LOG_TRANSACTION_ACTIVITY table KioskLinqDB.
    '[Create by  on November, 17 2017]
    Public Class TbLogTransactionActivityKioskLinqDB
        Public sub TbLogTransactionActivityKioskLinqDB()

        End Sub 
        ' TB_LOG_TRANSACTION_ACTIVITY
        Const _tableName As String = "TB_LOG_TRANSACTION_ACTIVITY"

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
        Dim _TRANS_DATE As DateTime = New DateTime(1,1,1)
        Dim _DEPOSIT_TRANS_NO As  String  = ""
        Dim _PICKUP_TRANS_NO As  String  = ""
        Dim _STAFF_CONSOLE_TRANS_NO As  String  = ""
        Dim _MS_APP_SCREEN_ID As Long = 0
        Dim _MS_APP_STEP_ID As Long = 0
        Dim _LOG_DESC As String = ""
        Dim _IS_PROBLEM As Char = "N"
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
        <Column(Storage:="_TRANS_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property TRANS_DATE() As DateTime
            Get
                Return _TRANS_DATE
            End Get
            Set(ByVal value As DateTime)
               _TRANS_DATE = value
            End Set
        End Property 
        <Column(Storage:="_DEPOSIT_TRANS_NO", DbType:="VarChar(50)")>  _
        Public Property DEPOSIT_TRANS_NO() As  String 
            Get
                Return _DEPOSIT_TRANS_NO
            End Get
            Set(ByVal value As  String )
               _DEPOSIT_TRANS_NO = value
            End Set
        End Property 
        <Column(Storage:="_PICKUP_TRANS_NO", DbType:="VarChar(50)")>  _
        Public Property PICKUP_TRANS_NO() As  String 
            Get
                Return _PICKUP_TRANS_NO
            End Get
            Set(ByVal value As  String )
               _PICKUP_TRANS_NO = value
            End Set
        End Property 
        <Column(Storage:="_STAFF_CONSOLE_TRANS_NO", DbType:="VarChar(50)")>  _
        Public Property STAFF_CONSOLE_TRANS_NO() As  String 
            Get
                Return _STAFF_CONSOLE_TRANS_NO
            End Get
            Set(ByVal value As  String )
               _STAFF_CONSOLE_TRANS_NO = value
            End Set
        End Property 
        <Column(Storage:="_MS_APP_SCREEN_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_APP_SCREEN_ID() As Long
            Get
                Return _MS_APP_SCREEN_ID
            End Get
            Set(ByVal value As Long)
               _MS_APP_SCREEN_ID = value
            End Set
        End Property 
        <Column(Storage:="_MS_APP_STEP_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_APP_STEP_ID() As Long
            Get
                Return _MS_APP_STEP_ID
            End Get
            Set(ByVal value As Long)
               _MS_APP_STEP_ID = value
            End Set
        End Property 
        <Column(Storage:="_LOG_DESC", DbType:="VarChar(500) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOG_DESC() As String
            Get
                Return _LOG_DESC
            End Get
            Set(ByVal value As String)
               _LOG_DESC = value
            End Set
        End Property 
        <Column(Storage:="_IS_PROBLEM", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_PROBLEM() As Char
            Get
                Return _IS_PROBLEM
            End Get
            Set(ByVal value As Char)
               _IS_PROBLEM = value
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
            _TRANS_DATE = New DateTime(1,1,1)
            _DEPOSIT_TRANS_NO = ""
            _PICKUP_TRANS_NO = ""
            _STAFF_CONSOLE_TRANS_NO = ""
            _MS_APP_SCREEN_ID = 0
            _MS_APP_STEP_ID = 0
            _LOG_DESC = ""
            _IS_PROBLEM = "N"
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


        '/// Returns an indication whether the current data is inserted into TB_LOG_TRANSACTION_ACTIVITY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_LOG_TRANSACTION_ACTIVITY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_LOG_TRANSACTION_ACTIVITY table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_LOG_TRANSACTION_ACTIVITY table successfully.
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


        '/// Returns an indication whether the record of TB_LOG_TRANSACTION_ACTIVITY by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_LOG_TRANSACTION_ACTIVITY by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbLogTransactionActivityKioskLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of TB_LOG_TRANSACTION_ACTIVITY by specified TRANS_DATE key is retrieved successfully.
        '/// <param name=cTRANS_DATE>The TRANS_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTRANS_DATE(cTRANS_DATE As DateTime, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TRANS_DATE", cTRANS_DATE) 
            Return doChkData("TRANS_DATE = @_TRANS_DATE", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_LOG_TRANSACTION_ACTIVITY by specified TRANS_DATE key is retrieved successfully.
        '/// <param name=cTRANS_DATE>The TRANS_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByTRANS_DATE(cTRANS_DATE As DateTime, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TRANS_DATE", cTRANS_DATE) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("TRANS_DATE = @_TRANS_DATE And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_LOG_TRANSACTION_ACTIVITY by specified MS_APP_SCREEN_ID_MS_APP_STEP_ID key is retrieved successfully.
        '/// <param name=cMS_APP_SCREEN_ID_MS_APP_STEP_ID>The MS_APP_SCREEN_ID_MS_APP_STEP_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_APP_SCREEN_ID_MS_APP_STEP_ID(cMS_APP_SCREEN_ID As Long, cMS_APP_STEP_ID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(3)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_APP_SCREEN_ID", cMS_APP_SCREEN_ID) 
            cmdPara(1) = DB.SetText("@_MS_APP_STEP_ID", cMS_APP_STEP_ID) 
            Return doChkData("MS_APP_SCREEN_ID = @_MS_APP_SCREEN_ID AND MS_APP_STEP_ID = @_MS_APP_STEP_ID", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_LOG_TRANSACTION_ACTIVITY by specified MS_APP_SCREEN_ID_MS_APP_STEP_ID key is retrieved successfully.
        '/// <param name=cMS_APP_SCREEN_ID_MS_APP_STEP_ID>The MS_APP_SCREEN_ID_MS_APP_STEP_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_APP_SCREEN_ID_MS_APP_STEP_ID(cMS_APP_SCREEN_ID As Long, cMS_APP_STEP_ID As Long, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(3)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_APP_SCREEN_ID", cMS_APP_SCREEN_ID) 
            cmdPara(1) = DB.SetText("@_MS_APP_STEP_ID", cMS_APP_STEP_ID) 
            cmdPara(2) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("MS_APP_SCREEN_ID = @_MS_APP_SCREEN_ID AND MS_APP_STEP_ID = @_MS_APP_STEP_ID And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_LOG_TRANSACTION_ACTIVITY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_LOG_TRANSACTION_ACTIVITY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_LOG_TRANSACTION_ACTIVITY table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_LOG_TRANSACTION_ACTIVITY table successfully.
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
            Dim cmbParam(14) As SqlParameter
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

            cmbParam(6) = New SqlParameter("@_TRANS_DATE", SqlDbType.DateTime)
            cmbParam(6).Value = _TRANS_DATE

            cmbParam(7) = New SqlParameter("@_DEPOSIT_TRANS_NO", SqlDbType.VarChar)
            If _DEPOSIT_TRANS_NO.Trim <> "" Then 
                cmbParam(7).Value = _DEPOSIT_TRANS_NO
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_PICKUP_TRANS_NO", SqlDbType.VarChar)
            If _PICKUP_TRANS_NO.Trim <> "" Then 
                cmbParam(8).Value = _PICKUP_TRANS_NO
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_STAFF_CONSOLE_TRANS_NO", SqlDbType.VarChar)
            If _STAFF_CONSOLE_TRANS_NO.Trim <> "" Then 
                cmbParam(9).Value = _STAFF_CONSOLE_TRANS_NO
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_MS_APP_SCREEN_ID", SqlDbType.BigInt)
            cmbParam(10).Value = _MS_APP_SCREEN_ID

            cmbParam(11) = New SqlParameter("@_MS_APP_STEP_ID", SqlDbType.BigInt)
            cmbParam(11).Value = _MS_APP_STEP_ID

            cmbParam(12) = New SqlParameter("@_LOG_DESC", SqlDbType.VarChar)
            cmbParam(12).Value = _LOG_DESC

            cmbParam(13) = New SqlParameter("@_IS_PROBLEM", SqlDbType.Char)
            cmbParam(13).Value = _IS_PROBLEM

            cmbParam(14) = New SqlParameter("@_SYNC_TO_SERVER", SqlDbType.Char)
            cmbParam(14).Value = _SYNC_TO_SERVER

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_LOG_TRANSACTION_ACTIVITY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("trans_date")) = False Then _trans_date = Convert.ToDateTime(Rdr("trans_date"))
                        If Convert.IsDBNull(Rdr("deposit_trans_no")) = False Then _deposit_trans_no = Rdr("deposit_trans_no").ToString()
                        If Convert.IsDBNull(Rdr("pickup_trans_no")) = False Then _pickup_trans_no = Rdr("pickup_trans_no").ToString()
                        If Convert.IsDBNull(Rdr("staff_console_trans_no")) = False Then _staff_console_trans_no = Rdr("staff_console_trans_no").ToString()
                        If Convert.IsDBNull(Rdr("ms_app_screen_id")) = False Then _ms_app_screen_id = Convert.ToInt64(Rdr("ms_app_screen_id"))
                        If Convert.IsDBNull(Rdr("ms_app_step_id")) = False Then _ms_app_step_id = Convert.ToInt64(Rdr("ms_app_step_id"))
                        If Convert.IsDBNull(Rdr("log_desc")) = False Then _log_desc = Rdr("log_desc").ToString()
                        If Convert.IsDBNull(Rdr("is_problem")) = False Then _is_problem = Rdr("is_problem").ToString()
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


        '/// Returns an indication whether the record of TB_LOG_TRANSACTION_ACTIVITY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As TbLogTransactionActivityKioskLinqDB
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
                        If Convert.IsDBNull(Rdr("trans_date")) = False Then _trans_date = Convert.ToDateTime(Rdr("trans_date"))
                        If Convert.IsDBNull(Rdr("deposit_trans_no")) = False Then _deposit_trans_no = Rdr("deposit_trans_no").ToString()
                        If Convert.IsDBNull(Rdr("pickup_trans_no")) = False Then _pickup_trans_no = Rdr("pickup_trans_no").ToString()
                        If Convert.IsDBNull(Rdr("staff_console_trans_no")) = False Then _staff_console_trans_no = Rdr("staff_console_trans_no").ToString()
                        If Convert.IsDBNull(Rdr("ms_app_screen_id")) = False Then _ms_app_screen_id = Convert.ToInt64(Rdr("ms_app_screen_id"))
                        If Convert.IsDBNull(Rdr("ms_app_step_id")) = False Then _ms_app_step_id = Convert.ToInt64(Rdr("ms_app_step_id"))
                        If Convert.IsDBNull(Rdr("log_desc")) = False Then _log_desc = Rdr("log_desc").ToString()
                        If Convert.IsDBNull(Rdr("is_problem")) = False Then _is_problem = Rdr("is_problem").ToString()
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


        'Get Insert Statement for table TB_LOG_TRANSACTION_ACTIVITY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (ID, CREATED_BY, CREATED_DATE, MS_KIOSK_ID, TRANS_DATE, DEPOSIT_TRANS_NO, PICKUP_TRANS_NO, STAFF_CONSOLE_TRANS_NO, MS_APP_SCREEN_ID, MS_APP_STEP_ID, LOG_DESC, IS_PROBLEM, SYNC_TO_SERVER)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_KIOSK_ID, INSERTED.TRANS_DATE, INSERTED.DEPOSIT_TRANS_NO, INSERTED.PICKUP_TRANS_NO, INSERTED.STAFF_CONSOLE_TRANS_NO, INSERTED.MS_APP_SCREEN_ID, INSERTED.MS_APP_STEP_ID, INSERTED.LOG_DESC, INSERTED.IS_PROBLEM, INSERTED.SYNC_TO_SERVER"
                Sql += " VALUES("
                sql += "@_ID" & ", "
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MS_KIOSK_ID" & ", "
                sql += "@_TRANS_DATE" & ", "
                sql += "@_DEPOSIT_TRANS_NO" & ", "
                sql += "@_PICKUP_TRANS_NO" & ", "
                sql += "@_STAFF_CONSOLE_TRANS_NO" & ", "
                sql += "@_MS_APP_SCREEN_ID" & ", "
                sql += "@_MS_APP_STEP_ID" & ", "
                sql += "@_LOG_DESC" & ", "
                sql += "@_IS_PROBLEM" & ", "
                sql += "@_SYNC_TO_SERVER"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_LOG_TRANSACTION_ACTIVITY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_KIOSK_ID = " & "@_MS_KIOSK_ID" & ", "
                Sql += "TRANS_DATE = " & "@_TRANS_DATE" & ", "
                Sql += "DEPOSIT_TRANS_NO = " & "@_DEPOSIT_TRANS_NO" & ", "
                Sql += "PICKUP_TRANS_NO = " & "@_PICKUP_TRANS_NO" & ", "
                Sql += "STAFF_CONSOLE_TRANS_NO = " & "@_STAFF_CONSOLE_TRANS_NO" & ", "
                Sql += "MS_APP_SCREEN_ID = " & "@_MS_APP_SCREEN_ID" & ", "
                Sql += "MS_APP_STEP_ID = " & "@_MS_APP_STEP_ID" & ", "
                Sql += "LOG_DESC = " & "@_LOG_DESC" & ", "
                Sql += "IS_PROBLEM = " & "@_IS_PROBLEM" & ", "
                Sql += "SYNC_TO_SERVER = " & "@_SYNC_TO_SERVER" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_LOG_TRANSACTION_ACTIVITY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_LOG_TRANSACTION_ACTIVITY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_KIOSK_ID, TRANS_DATE, DEPOSIT_TRANS_NO, PICKUP_TRANS_NO, STAFF_CONSOLE_TRANS_NO, MS_APP_SCREEN_ID, MS_APP_STEP_ID, LOG_DESC, IS_PROBLEM, SYNC_TO_SERVER FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
