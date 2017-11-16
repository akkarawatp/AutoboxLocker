Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for MS_KIOSK_SCREEN_CONTROL table ServerLinqDB.
    '[Create by  on March, 1 2017]
    Public Class MsKioskScreenControlServerLinqDB
        Public sub MsKioskScreenControlServerLinqDB()

        End Sub 
        ' MS_KIOSK_SCREEN_CONTROL
        Const _tableName As String = "MS_KIOSK_SCREEN_CONTROL"

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
        Dim _MS_APP_SCREEN_ID As Long = 0
        Dim _CONTROL_NAME As String = ""
        Dim _TH_DISPLAY As String = ""
        Dim _EN_DISPLAY As String = ""
        Dim _CH_DISPLAY As String = ""
        Dim _JP_DISPLAY As String = ""
        Dim _SYNC_TO_KIOSK As Char = "N"
        Dim _SYNC_TO_SERVER As Char = "N"
        Dim _FONT_SIZE As Long = 0
        Dim _FONT_STYLE As Long = 0

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
        <Column(Storage:="_MS_APP_SCREEN_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_APP_SCREEN_ID() As Long
            Get
                Return _MS_APP_SCREEN_ID
            End Get
            Set(ByVal value As Long)
               _MS_APP_SCREEN_ID = value
            End Set
        End Property 
        <Column(Storage:="_CONTROL_NAME", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CONTROL_NAME() As String
            Get
                Return _CONTROL_NAME
            End Get
            Set(ByVal value As String)
               _CONTROL_NAME = value
            End Set
        End Property 
        <Column(Storage:="_TH_DISPLAY", DbType:="NVarChar(510) NOT NULL ",CanBeNull:=false)>  _
        Public Property TH_DISPLAY() As String
            Get
                Return _TH_DISPLAY
            End Get
            Set(ByVal value As String)
               _TH_DISPLAY = value
            End Set
        End Property 
        <Column(Storage:="_EN_DISPLAY", DbType:="NVarChar(510) NOT NULL ",CanBeNull:=false)>  _
        Public Property EN_DISPLAY() As String
            Get
                Return _EN_DISPLAY
            End Get
            Set(ByVal value As String)
               _EN_DISPLAY = value
            End Set
        End Property 
        <Column(Storage:="_CH_DISPLAY", DbType:="NVarChar(510) NOT NULL ",CanBeNull:=false)>  _
        Public Property CH_DISPLAY() As String
            Get
                Return _CH_DISPLAY
            End Get
            Set(ByVal value As String)
               _CH_DISPLAY = value
            End Set
        End Property 
        <Column(Storage:="_JP_DISPLAY", DbType:="NVarChar(510) NOT NULL ",CanBeNull:=false)>  _
        Public Property JP_DISPLAY() As String
            Get
                Return _JP_DISPLAY
            End Get
            Set(ByVal value As String)
               _JP_DISPLAY = value
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
        <Column(Storage:="_FONT_SIZE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property FONT_SIZE() As Long
            Get
                Return _FONT_SIZE
            End Get
            Set(ByVal value As Long)
               _FONT_SIZE = value
            End Set
        End Property 
        <Column(Storage:="_FONT_STYLE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property FONT_STYLE() As Long
            Get
                Return _FONT_STYLE
            End Get
            Set(ByVal value As Long)
               _FONT_STYLE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_APP_SCREEN_ID = 0
            _CONTROL_NAME = ""
            _TH_DISPLAY = ""
            _EN_DISPLAY = ""
            _CH_DISPLAY = ""
            _JP_DISPLAY = ""
            _SYNC_TO_KIOSK = "N"
            _SYNC_TO_SERVER = "N"
            _FONT_SIZE = 0
            _FONT_STYLE = 0
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


        '/// Returns an indication whether the current data is inserted into MS_KIOSK_SCREEN_CONTROL table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK_SCREEN_CONTROL table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK_SCREEN_CONTROL table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_KIOSK_SCREEN_CONTROL table successfully.
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


        '/// Returns an indication whether the record of MS_KIOSK_SCREEN_CONTROL by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_KIOSK_SCREEN_CONTROL by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsKioskScreenControlServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of MS_KIOSK_SCREEN_CONTROL by specified CONTROL_NAME_MS_APP_SCREEN_ID key is retrieved successfully.
        '/// <param name=cCONTROL_NAME_MS_APP_SCREEN_ID>The CONTROL_NAME_MS_APP_SCREEN_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCONTROL_NAME_MS_APP_SCREEN_ID(cCONTROL_NAME As String, cMS_APP_SCREEN_ID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(3)  As SQLParameter
            cmdPara(0) = DB.SetText("@_CONTROL_NAME", cCONTROL_NAME) 
            cmdPara(1) = DB.SetText("@_MS_APP_SCREEN_ID", cMS_APP_SCREEN_ID) 
            Return doChkData("CONTROL_NAME = @_CONTROL_NAME AND MS_APP_SCREEN_ID = @_MS_APP_SCREEN_ID", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_KIOSK_SCREEN_CONTROL by specified CONTROL_NAME_MS_APP_SCREEN_ID key is retrieved successfully.
        '/// <param name=cCONTROL_NAME_MS_APP_SCREEN_ID>The CONTROL_NAME_MS_APP_SCREEN_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCONTROL_NAME_MS_APP_SCREEN_ID(cCONTROL_NAME As String, cMS_APP_SCREEN_ID As Long, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(3)  As SQLParameter
            cmdPara(0) = DB.SetText("@_CONTROL_NAME", cCONTROL_NAME) 
            cmdPara(1) = DB.SetText("@_MS_APP_SCREEN_ID", cMS_APP_SCREEN_ID) 
            cmdPara(2) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("CONTROL_NAME = @_CONTROL_NAME AND MS_APP_SCREEN_ID = @_MS_APP_SCREEN_ID And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_KIOSK_SCREEN_CONTROL by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_KIOSK_SCREEN_CONTROL table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK_SCREEN_CONTROL table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_KIOSK_SCREEN_CONTROL table successfully.
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

            cmbParam(5) = New SqlParameter("@_MS_APP_SCREEN_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_APP_SCREEN_ID

            cmbParam(6) = New SqlParameter("@_CONTROL_NAME", SqlDbType.VarChar)
            cmbParam(6).Value = _CONTROL_NAME

            cmbParam(7) = New SqlParameter("@_TH_DISPLAY", SqlDbType.NVarChar)
            cmbParam(7).Value = _TH_DISPLAY

            cmbParam(8) = New SqlParameter("@_EN_DISPLAY", SqlDbType.NVarChar)
            cmbParam(8).Value = _EN_DISPLAY

            cmbParam(9) = New SqlParameter("@_CH_DISPLAY", SqlDbType.NVarChar)
            cmbParam(9).Value = _CH_DISPLAY

            cmbParam(10) = New SqlParameter("@_JP_DISPLAY", SqlDbType.NVarChar)
            cmbParam(10).Value = _JP_DISPLAY

            cmbParam(11) = New SqlParameter("@_SYNC_TO_KIOSK", SqlDbType.Char)
            cmbParam(11).Value = _SYNC_TO_KIOSK

            cmbParam(12) = New SqlParameter("@_SYNC_TO_SERVER", SqlDbType.Char)
            cmbParam(12).Value = _SYNC_TO_SERVER

            cmbParam(13) = New SqlParameter("@_FONT_SIZE", SqlDbType.Int)
            cmbParam(13).Value = _FONT_SIZE

            cmbParam(14) = New SqlParameter("@_FONT_STYLE", SqlDbType.Int)
            cmbParam(14).Value = _FONT_STYLE

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_KIOSK_SCREEN_CONTROL by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_app_screen_id")) = False Then _ms_app_screen_id = Convert.ToInt64(Rdr("ms_app_screen_id"))
                        If Convert.IsDBNull(Rdr("control_name")) = False Then _control_name = Rdr("control_name").ToString()
                        If Convert.IsDBNull(Rdr("TH_Display")) = False Then _TH_Display = Rdr("TH_Display").ToString()
                        If Convert.IsDBNull(Rdr("EN_Display")) = False Then _EN_Display = Rdr("EN_Display").ToString()
                        If Convert.IsDBNull(Rdr("CH_Display")) = False Then _CH_Display = Rdr("CH_Display").ToString()
                        If Convert.IsDBNull(Rdr("JP_Display")) = False Then _JP_Display = Rdr("JP_Display").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_kiosk")) = False Then _sync_to_kiosk = Rdr("sync_to_kiosk").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_server")) = False Then _sync_to_server = Rdr("sync_to_server").ToString()
                        If Convert.IsDBNull(Rdr("font_size")) = False Then _font_size = Convert.ToInt32(Rdr("font_size"))
                        If Convert.IsDBNull(Rdr("font_style")) = False Then _font_style = Convert.ToInt32(Rdr("font_style"))
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


        '/// Returns an indication whether the record of MS_KIOSK_SCREEN_CONTROL by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As MsKioskScreenControlServerLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_app_screen_id")) = False Then _ms_app_screen_id = Convert.ToInt64(Rdr("ms_app_screen_id"))
                        If Convert.IsDBNull(Rdr("control_name")) = False Then _control_name = Rdr("control_name").ToString()
                        If Convert.IsDBNull(Rdr("TH_Display")) = False Then _TH_Display = Rdr("TH_Display").ToString()
                        If Convert.IsDBNull(Rdr("EN_Display")) = False Then _EN_Display = Rdr("EN_Display").ToString()
                        If Convert.IsDBNull(Rdr("CH_Display")) = False Then _CH_Display = Rdr("CH_Display").ToString()
                        If Convert.IsDBNull(Rdr("JP_Display")) = False Then _JP_Display = Rdr("JP_Display").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_kiosk")) = False Then _sync_to_kiosk = Rdr("sync_to_kiosk").ToString()
                        If Convert.IsDBNull(Rdr("sync_to_server")) = False Then _sync_to_server = Rdr("sync_to_server").ToString()
                        If Convert.IsDBNull(Rdr("font_size")) = False Then _font_size = Convert.ToInt32(Rdr("font_size"))
                        If Convert.IsDBNull(Rdr("font_style")) = False Then _font_style = Convert.ToInt32(Rdr("font_style"))
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


        'Get Insert Statement for table MS_KIOSK_SCREEN_CONTROL
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, MS_APP_SCREEN_ID, CONTROL_NAME, TH_DISPLAY, EN_DISPLAY, CH_DISPLAY, JP_DISPLAY, SYNC_TO_KIOSK, SYNC_TO_SERVER, FONT_SIZE, FONT_STYLE)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_APP_SCREEN_ID, INSERTED.CONTROL_NAME, INSERTED.TH_DISPLAY, INSERTED.EN_DISPLAY, INSERTED.CH_DISPLAY, INSERTED.JP_DISPLAY, INSERTED.SYNC_TO_KIOSK, INSERTED.SYNC_TO_SERVER, INSERTED.FONT_SIZE, INSERTED.FONT_STYLE"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MS_APP_SCREEN_ID" & ", "
                sql += "@_CONTROL_NAME" & ", "
                sql += "@_TH_DISPLAY" & ", "
                sql += "@_EN_DISPLAY" & ", "
                sql += "@_CH_DISPLAY" & ", "
                sql += "@_JP_DISPLAY" & ", "
                sql += "@_SYNC_TO_KIOSK" & ", "
                sql += "@_SYNC_TO_SERVER" & ", "
                sql += "@_FONT_SIZE" & ", "
                sql += "@_FONT_STYLE"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_KIOSK_SCREEN_CONTROL
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_APP_SCREEN_ID = " & "@_MS_APP_SCREEN_ID" & ", "
                Sql += "CONTROL_NAME = " & "@_CONTROL_NAME" & ", "
                Sql += "TH_DISPLAY = " & "@_TH_DISPLAY" & ", "
                Sql += "EN_DISPLAY = " & "@_EN_DISPLAY" & ", "
                Sql += "CH_DISPLAY = " & "@_CH_DISPLAY" & ", "
                Sql += "JP_DISPLAY = " & "@_JP_DISPLAY" & ", "
                Sql += "SYNC_TO_KIOSK = " & "@_SYNC_TO_KIOSK" & ", "
                Sql += "SYNC_TO_SERVER = " & "@_SYNC_TO_SERVER" & ", "
                Sql += "FONT_SIZE = " & "@_FONT_SIZE" & ", "
                Sql += "FONT_STYLE = " & "@_FONT_STYLE" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_KIOSK_SCREEN_CONTROL
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_KIOSK_SCREEN_CONTROL
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_APP_SCREEN_ID, CONTROL_NAME, TH_DISPLAY, EN_DISPLAY, CH_DISPLAY, JP_DISPLAY, SYNC_TO_KIOSK, SYNC_TO_SERVER, FONT_SIZE, FONT_STYLE FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
