Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for MS_CABINET_MODEL table ServerLinqDB.
    '[Create by  on November, 17 2017]
    Public Class MsCabinetModelServerLinqDB
        Public sub MsCabinetModelServerLinqDB()

        End Sub 
        ' MS_CABINET_MODEL
        Const _tableName As String = "MS_CABINET_MODEL"

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
        Dim _MODEL_NAME As String = ""
        Dim _CABINET_WIDTH As Double = 0
        Dim _CABINET_HIGHT As Double = 0
        Dim _CABINET_DEEP As Double = 0
        Dim _LOCKER_WIDTH As Double = 0
        Dim _LOCKER_HIGHT As Double = 0
        Dim _LOCKER_DEEP As Double = 0
        Dim _SERVICE_RATE_HOUR As Double = 0
        Dim _SERVICE_RATE_LIMIT_DAY As Double = 0
        Dim _DEPOSIT_AMT As Double = 0
        Dim _LOCKER_QTY As Long = 0
        Dim _ACTIVE_STATUS As Char = "Y"

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
        <Column(Storage:="_MODEL_NAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MODEL_NAME() As String
            Get
                Return _MODEL_NAME
            End Get
            Set(ByVal value As String)
               _MODEL_NAME = value
            End Set
        End Property 
        <Column(Storage:="_CABINET_WIDTH", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property CABINET_WIDTH() As Double
            Get
                Return _CABINET_WIDTH
            End Get
            Set(ByVal value As Double)
               _CABINET_WIDTH = value
            End Set
        End Property 
        <Column(Storage:="_CABINET_HIGHT", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property CABINET_HIGHT() As Double
            Get
                Return _CABINET_HIGHT
            End Get
            Set(ByVal value As Double)
               _CABINET_HIGHT = value
            End Set
        End Property 
        <Column(Storage:="_CABINET_DEEP", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property CABINET_DEEP() As Double
            Get
                Return _CABINET_DEEP
            End Get
            Set(ByVal value As Double)
               _CABINET_DEEP = value
            End Set
        End Property 
        <Column(Storage:="_LOCKER_WIDTH", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCKER_WIDTH() As Double
            Get
                Return _LOCKER_WIDTH
            End Get
            Set(ByVal value As Double)
               _LOCKER_WIDTH = value
            End Set
        End Property 
        <Column(Storage:="_LOCKER_HIGHT", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCKER_HIGHT() As Double
            Get
                Return _LOCKER_HIGHT
            End Get
            Set(ByVal value As Double)
               _LOCKER_HIGHT = value
            End Set
        End Property 
        <Column(Storage:="_LOCKER_DEEP", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCKER_DEEP() As Double
            Get
                Return _LOCKER_DEEP
            End Get
            Set(ByVal value As Double)
               _LOCKER_DEEP = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_RATE_HOUR", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_RATE_HOUR() As Double
            Get
                Return _SERVICE_RATE_HOUR
            End Get
            Set(ByVal value As Double)
               _SERVICE_RATE_HOUR = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_RATE_LIMIT_DAY", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_RATE_LIMIT_DAY() As Double
            Get
                Return _SERVICE_RATE_LIMIT_DAY
            End Get
            Set(ByVal value As Double)
               _SERVICE_RATE_LIMIT_DAY = value
            End Set
        End Property 
        <Column(Storage:="_DEPOSIT_AMT", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property DEPOSIT_AMT() As Double
            Get
                Return _DEPOSIT_AMT
            End Get
            Set(ByVal value As Double)
               _DEPOSIT_AMT = value
            End Set
        End Property 
        <Column(Storage:="_LOCKER_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCKER_QTY() As Long
            Get
                Return _LOCKER_QTY
            End Get
            Set(ByVal value As Long)
               _LOCKER_QTY = value
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


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MODEL_NAME = ""
            _CABINET_WIDTH = 0
            _CABINET_HIGHT = 0
            _CABINET_DEEP = 0
            _LOCKER_WIDTH = 0
            _LOCKER_HIGHT = 0
            _LOCKER_DEEP = 0
            _SERVICE_RATE_HOUR = 0
            _SERVICE_RATE_LIMIT_DAY = 0
            _DEPOSIT_AMT = 0
            _LOCKER_QTY = 0
            _ACTIVE_STATUS = "Y"
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


        '/// Returns an indication whether the current data is inserted into MS_CABINET_MODEL table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_CABINET_MODEL table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_CABINET_MODEL table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_CABINET_MODEL table successfully.
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


        '/// Returns an indication whether the record of MS_CABINET_MODEL by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_CABINET_MODEL by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsCabinetModelServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of MS_CABINET_MODEL by specified MODEL_NAME key is retrieved successfully.
        '/// <param name=cMODEL_NAME>The MODEL_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMODEL_NAME(cMODEL_NAME As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MODEL_NAME", cMODEL_NAME) 
            Return doChkData("MODEL_NAME = @_MODEL_NAME", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_CABINET_MODEL by specified MODEL_NAME key is retrieved successfully.
        '/// <param name=cMODEL_NAME>The MODEL_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMODEL_NAME(cMODEL_NAME As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MODEL_NAME", cMODEL_NAME) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("MODEL_NAME = @_MODEL_NAME And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_CABINET_MODEL by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_CABINET_MODEL table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_CABINET_MODEL table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_CABINET_MODEL table successfully.
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
            Dim cmbParam(16) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MODEL_NAME", SqlDbType.VarChar)
            cmbParam(5).Value = _MODEL_NAME

            cmbParam(6) = New SqlParameter("@_CABINET_WIDTH", SqlDbType.Float)
            cmbParam(6).Value = _CABINET_WIDTH

            cmbParam(7) = New SqlParameter("@_CABINET_HIGHT", SqlDbType.Float)
            cmbParam(7).Value = _CABINET_HIGHT

            cmbParam(8) = New SqlParameter("@_CABINET_DEEP", SqlDbType.Float)
            cmbParam(8).Value = _CABINET_DEEP

            cmbParam(9) = New SqlParameter("@_LOCKER_WIDTH", SqlDbType.Float)
            cmbParam(9).Value = _LOCKER_WIDTH

            cmbParam(10) = New SqlParameter("@_LOCKER_HIGHT", SqlDbType.Float)
            cmbParam(10).Value = _LOCKER_HIGHT

            cmbParam(11) = New SqlParameter("@_LOCKER_DEEP", SqlDbType.Float)
            cmbParam(11).Value = _LOCKER_DEEP

            cmbParam(12) = New SqlParameter("@_SERVICE_RATE_HOUR", SqlDbType.Float)
            cmbParam(12).Value = _SERVICE_RATE_HOUR

            cmbParam(13) = New SqlParameter("@_SERVICE_RATE_LIMIT_DAY", SqlDbType.Float)
            cmbParam(13).Value = _SERVICE_RATE_LIMIT_DAY

            cmbParam(14) = New SqlParameter("@_DEPOSIT_AMT", SqlDbType.Float)
            cmbParam(14).Value = _DEPOSIT_AMT

            cmbParam(15) = New SqlParameter("@_LOCKER_QTY", SqlDbType.Int)
            cmbParam(15).Value = _LOCKER_QTY

            cmbParam(16) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(16).Value = _ACTIVE_STATUS

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_CABINET_MODEL by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
                        If Convert.IsDBNull(Rdr("cabinet_width")) = False Then _cabinet_width = Convert.ToDouble(Rdr("cabinet_width"))
                        If Convert.IsDBNull(Rdr("cabinet_hight")) = False Then _cabinet_hight = Convert.ToDouble(Rdr("cabinet_hight"))
                        If Convert.IsDBNull(Rdr("cabinet_deep")) = False Then _cabinet_deep = Convert.ToDouble(Rdr("cabinet_deep"))
                        If Convert.IsDBNull(Rdr("locker_width")) = False Then _locker_width = Convert.ToDouble(Rdr("locker_width"))
                        If Convert.IsDBNull(Rdr("locker_hight")) = False Then _locker_hight = Convert.ToDouble(Rdr("locker_hight"))
                        If Convert.IsDBNull(Rdr("locker_deep")) = False Then _locker_deep = Convert.ToDouble(Rdr("locker_deep"))
                        If Convert.IsDBNull(Rdr("service_rate_hour")) = False Then _service_rate_hour = Convert.ToDouble(Rdr("service_rate_hour"))
                        If Convert.IsDBNull(Rdr("service_rate_limit_day")) = False Then _service_rate_limit_day = Convert.ToDouble(Rdr("service_rate_limit_day"))
                        If Convert.IsDBNull(Rdr("deposit_amt")) = False Then _deposit_amt = Convert.ToDouble(Rdr("deposit_amt"))
                        If Convert.IsDBNull(Rdr("locker_qty")) = False Then _locker_qty = Convert.ToInt32(Rdr("locker_qty"))
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
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


        '/// Returns an indication whether the record of MS_CABINET_MODEL by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As MsCabinetModelServerLinqDB
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
                        If Convert.IsDBNull(Rdr("model_name")) = False Then _model_name = Rdr("model_name").ToString()
                        If Convert.IsDBNull(Rdr("cabinet_width")) = False Then _cabinet_width = Convert.ToDouble(Rdr("cabinet_width"))
                        If Convert.IsDBNull(Rdr("cabinet_hight")) = False Then _cabinet_hight = Convert.ToDouble(Rdr("cabinet_hight"))
                        If Convert.IsDBNull(Rdr("cabinet_deep")) = False Then _cabinet_deep = Convert.ToDouble(Rdr("cabinet_deep"))
                        If Convert.IsDBNull(Rdr("locker_width")) = False Then _locker_width = Convert.ToDouble(Rdr("locker_width"))
                        If Convert.IsDBNull(Rdr("locker_hight")) = False Then _locker_hight = Convert.ToDouble(Rdr("locker_hight"))
                        If Convert.IsDBNull(Rdr("locker_deep")) = False Then _locker_deep = Convert.ToDouble(Rdr("locker_deep"))
                        If Convert.IsDBNull(Rdr("service_rate_hour")) = False Then _service_rate_hour = Convert.ToDouble(Rdr("service_rate_hour"))
                        If Convert.IsDBNull(Rdr("service_rate_limit_day")) = False Then _service_rate_limit_day = Convert.ToDouble(Rdr("service_rate_limit_day"))
                        If Convert.IsDBNull(Rdr("deposit_amt")) = False Then _deposit_amt = Convert.ToDouble(Rdr("deposit_amt"))
                        If Convert.IsDBNull(Rdr("locker_qty")) = False Then _locker_qty = Convert.ToInt32(Rdr("locker_qty"))
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
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


        'Get Insert Statement for table MS_CABINET_MODEL
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, MODEL_NAME, CABINET_WIDTH, CABINET_HIGHT, CABINET_DEEP, LOCKER_WIDTH, LOCKER_HIGHT, LOCKER_DEEP, SERVICE_RATE_HOUR, SERVICE_RATE_LIMIT_DAY, DEPOSIT_AMT, LOCKER_QTY, ACTIVE_STATUS)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MODEL_NAME, INSERTED.CABINET_WIDTH, INSERTED.CABINET_HIGHT, INSERTED.CABINET_DEEP, INSERTED.LOCKER_WIDTH, INSERTED.LOCKER_HIGHT, INSERTED.LOCKER_DEEP, INSERTED.SERVICE_RATE_HOUR, INSERTED.SERVICE_RATE_LIMIT_DAY, INSERTED.DEPOSIT_AMT, INSERTED.LOCKER_QTY, INSERTED.ACTIVE_STATUS"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MODEL_NAME" & ", "
                sql += "@_CABINET_WIDTH" & ", "
                sql += "@_CABINET_HIGHT" & ", "
                sql += "@_CABINET_DEEP" & ", "
                sql += "@_LOCKER_WIDTH" & ", "
                sql += "@_LOCKER_HIGHT" & ", "
                sql += "@_LOCKER_DEEP" & ", "
                sql += "@_SERVICE_RATE_HOUR" & ", "
                sql += "@_SERVICE_RATE_LIMIT_DAY" & ", "
                sql += "@_DEPOSIT_AMT" & ", "
                sql += "@_LOCKER_QTY" & ", "
                sql += "@_ACTIVE_STATUS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_CABINET_MODEL
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MODEL_NAME = " & "@_MODEL_NAME" & ", "
                Sql += "CABINET_WIDTH = " & "@_CABINET_WIDTH" & ", "
                Sql += "CABINET_HIGHT = " & "@_CABINET_HIGHT" & ", "
                Sql += "CABINET_DEEP = " & "@_CABINET_DEEP" & ", "
                Sql += "LOCKER_WIDTH = " & "@_LOCKER_WIDTH" & ", "
                Sql += "LOCKER_HIGHT = " & "@_LOCKER_HIGHT" & ", "
                Sql += "LOCKER_DEEP = " & "@_LOCKER_DEEP" & ", "
                Sql += "SERVICE_RATE_HOUR = " & "@_SERVICE_RATE_HOUR" & ", "
                Sql += "SERVICE_RATE_LIMIT_DAY = " & "@_SERVICE_RATE_LIMIT_DAY" & ", "
                Sql += "DEPOSIT_AMT = " & "@_DEPOSIT_AMT" & ", "
                Sql += "LOCKER_QTY = " & "@_LOCKER_QTY" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_CABINET_MODEL
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_CABINET_MODEL
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MODEL_NAME, CABINET_WIDTH, CABINET_HIGHT, CABINET_DEEP, LOCKER_WIDTH, LOCKER_HIGHT, LOCKER_DEEP, SERVICE_RATE_HOUR, SERVICE_RATE_LIMIT_DAY, DEPOSIT_AMT, LOCKER_QTY, ACTIVE_STATUS FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
