Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = KioskLinqDB.ConnectDB.KioskDB
Imports KioskLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for MS_DEVICE table KioskLinqDB.
    '[Create by  on October, 18 2016]
    Public Class MsDeviceKioskLinqDB
        Public sub MsDeviceKioskLinqDB()

        End Sub 
        ' MS_DEVICE
        Const _tableName As String = "MS_DEVICE"

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
        Dim _DEVICE_NAME_TH As String = ""
        Dim _DEVICE_NAME_EN As  String  = ""
        Dim _MS_DEVICE_TYPE_ID As Long = 0
        Dim _UNIT_VALUE As Long = 0
        Dim _MAX_QTY As Long = 0
        Dim _WARNING_QTY As Long = 0
        Dim _CRITICAL_QTY As Long = 0
        Dim _ICON_WHITE() As Byte
        Dim _ICON_GREEN() As Byte
        Dim _ICON_RED() As Byte
        Dim _DEVICE_ORDER As Long = 0
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
        <Column(Storage:="_DEVICE_NAME_TH", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property DEVICE_NAME_TH() As String
            Get
                Return _DEVICE_NAME_TH
            End Get
            Set(ByVal value As String)
               _DEVICE_NAME_TH = value
            End Set
        End Property 
        <Column(Storage:="_DEVICE_NAME_EN", DbType:="VarChar(100)")>  _
        Public Property DEVICE_NAME_EN() As  String 
            Get
                Return _DEVICE_NAME_EN
            End Get
            Set(ByVal value As  String )
               _DEVICE_NAME_EN = value
            End Set
        End Property 
        <Column(Storage:="_MS_DEVICE_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_DEVICE_TYPE_ID() As Long
            Get
                Return _MS_DEVICE_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _MS_DEVICE_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_UNIT_VALUE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property UNIT_VALUE() As Long
            Get
                Return _UNIT_VALUE
            End Get
            Set(ByVal value As Long)
               _UNIT_VALUE = value
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
        <Column(Storage:="_ICON_WHITE", DbType:="IMAGE")>  _
        Public Property ICON_WHITE() As  Byte() 
            Get
                Return _ICON_WHITE
            End Get
            Set(ByVal value() As Byte)
               _ICON_WHITE = value
            End Set
        End Property 
        <Column(Storage:="_ICON_GREEN", DbType:="IMAGE")>  _
        Public Property ICON_GREEN() As  Byte() 
            Get
                Return _ICON_GREEN
            End Get
            Set(ByVal value() As Byte)
               _ICON_GREEN = value
            End Set
        End Property 
        <Column(Storage:="_ICON_RED", DbType:="IMAGE")>  _
        Public Property ICON_RED() As  Byte() 
            Get
                Return _ICON_RED
            End Get
            Set(ByVal value() As Byte)
               _ICON_RED = value
            End Set
        End Property 
        <Column(Storage:="_DEVICE_ORDER", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property DEVICE_ORDER() As Long
            Get
                Return _DEVICE_ORDER
            End Get
            Set(ByVal value As Long)
               _DEVICE_ORDER = value
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
            _DEVICE_NAME_TH = ""
            _DEVICE_NAME_EN = ""
            _MS_DEVICE_TYPE_ID = 0
            _UNIT_VALUE = 0
            _MAX_QTY = 0
            _WARNING_QTY = 0
            _CRITICAL_QTY = 0
             _ICON_WHITE = Nothing
             _ICON_GREEN = Nothing
             _ICON_RED = Nothing
            _DEVICE_ORDER = 0
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


        '/// Returns an indication whether the current data is inserted into MS_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_DEVICE table successfully.
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


        '/// Returns an indication whether the record of MS_DEVICE by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_DEVICE by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsDeviceKioskLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of MS_DEVICE by specified DEVICE_NAME_TH key is retrieved successfully.
        '/// <param name=cDEVICE_NAME_TH>The DEVICE_NAME_TH key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByDEVICE_NAME_TH(cDEVICE_NAME_TH As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_DEVICE_NAME_TH", cDEVICE_NAME_TH) 
            Return doChkData("DEVICE_NAME_TH = @_DEVICE_NAME_TH", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_DEVICE by specified DEVICE_NAME_TH key is retrieved successfully.
        '/// <param name=cDEVICE_NAME_TH>The DEVICE_NAME_TH key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByDEVICE_NAME_TH(cDEVICE_NAME_TH As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_DEVICE_NAME_TH", cDEVICE_NAME_TH) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("DEVICE_NAME_TH = @_DEVICE_NAME_TH And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_DEVICE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_DEVICE table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_DEVICE table successfully.
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

            cmbParam(5) = New SqlParameter("@_DEVICE_NAME_TH", SqlDbType.VarChar)
            cmbParam(5).Value = _DEVICE_NAME_TH

            cmbParam(6) = New SqlParameter("@_DEVICE_NAME_EN", SqlDbType.VarChar)
            If _DEVICE_NAME_EN.Trim <> "" Then 
                cmbParam(6).Value = _DEVICE_NAME_EN
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_MS_DEVICE_TYPE_ID", SqlDbType.BigInt)
            cmbParam(7).Value = _MS_DEVICE_TYPE_ID

            cmbParam(8) = New SqlParameter("@_UNIT_VALUE", SqlDbType.Int)
            cmbParam(8).Value = _UNIT_VALUE

            cmbParam(9) = New SqlParameter("@_MAX_QTY", SqlDbType.Int)
            cmbParam(9).Value = _MAX_QTY

            cmbParam(10) = New SqlParameter("@_WARNING_QTY", SqlDbType.Int)
            cmbParam(10).Value = _WARNING_QTY

            cmbParam(11) = New SqlParameter("@_CRITICAL_QTY", SqlDbType.Int)
            cmbParam(11).Value = _CRITICAL_QTY

            If _ICON_WHITE IsNot Nothing Then 
                cmbParam(12) = New SqlParameter("@_ICON_WHITE",SqlDbType.Image, _ICON_WHITE.Length)
                cmbParam(12).Value = _ICON_WHITE
            Else
                cmbParam(12) = New SqlParameter("@_ICON_WHITE", SqlDbType.Image)
                cmbParam(12).Value = DBNull.value
            End If

            If _ICON_GREEN IsNot Nothing Then 
                cmbParam(13) = New SqlParameter("@_ICON_GREEN",SqlDbType.Image, _ICON_GREEN.Length)
                cmbParam(13).Value = _ICON_GREEN
            Else
                cmbParam(13) = New SqlParameter("@_ICON_GREEN", SqlDbType.Image)
                cmbParam(13).Value = DBNull.value
            End If

            If _ICON_RED IsNot Nothing Then 
                cmbParam(14) = New SqlParameter("@_ICON_RED",SqlDbType.Image, _ICON_RED.Length)
                cmbParam(14).Value = _ICON_RED
            Else
                cmbParam(14) = New SqlParameter("@_ICON_RED", SqlDbType.Image)
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_DEVICE_ORDER", SqlDbType.Int)
            cmbParam(15).Value = _DEVICE_ORDER

            cmbParam(16) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(16).Value = _ACTIVE_STATUS

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_DEVICE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("device_name_th")) = False Then _device_name_th = Rdr("device_name_th").ToString()
                        If Convert.IsDBNull(Rdr("device_name_en")) = False Then _device_name_en = Rdr("device_name_en").ToString()
                        If Convert.IsDBNull(Rdr("ms_device_type_id")) = False Then _ms_device_type_id = Convert.ToInt64(Rdr("ms_device_type_id"))
                        If Convert.IsDBNull(Rdr("unit_value")) = False Then _unit_value = Convert.ToInt32(Rdr("unit_value"))
                        If Convert.IsDBNull(Rdr("max_qty")) = False Then _max_qty = Convert.ToInt32(Rdr("max_qty"))
                        If Convert.IsDBNull(Rdr("warning_qty")) = False Then _warning_qty = Convert.ToInt32(Rdr("warning_qty"))
                        If Convert.IsDBNull(Rdr("critical_qty")) = False Then _critical_qty = Convert.ToInt32(Rdr("critical_qty"))
                        If Convert.IsDBNull(Rdr("icon_white")) = False Then _icon_white = CType(Rdr("icon_white"), Byte())
                        If Convert.IsDBNull(Rdr("icon_green")) = False Then _icon_green = CType(Rdr("icon_green"), Byte())
                        If Convert.IsDBNull(Rdr("icon_red")) = False Then _icon_red = CType(Rdr("icon_red"), Byte())
                        If Convert.IsDBNull(Rdr("device_order")) = False Then _device_order = Convert.ToInt32(Rdr("device_order"))
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


        '/// Returns an indication whether the record of MS_DEVICE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As MsDeviceKioskLinqDB
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
                        If Convert.IsDBNull(Rdr("device_name_th")) = False Then _device_name_th = Rdr("device_name_th").ToString()
                        If Convert.IsDBNull(Rdr("device_name_en")) = False Then _device_name_en = Rdr("device_name_en").ToString()
                        If Convert.IsDBNull(Rdr("ms_device_type_id")) = False Then _ms_device_type_id = Convert.ToInt64(Rdr("ms_device_type_id"))
                        If Convert.IsDBNull(Rdr("unit_value")) = False Then _unit_value = Convert.ToInt32(Rdr("unit_value"))
                        If Convert.IsDBNull(Rdr("max_qty")) = False Then _max_qty = Convert.ToInt32(Rdr("max_qty"))
                        If Convert.IsDBNull(Rdr("warning_qty")) = False Then _warning_qty = Convert.ToInt32(Rdr("warning_qty"))
                        If Convert.IsDBNull(Rdr("critical_qty")) = False Then _critical_qty = Convert.ToInt32(Rdr("critical_qty"))
                        If Convert.IsDBNull(Rdr("icon_white")) = False Then _icon_white = CType(Rdr("icon_white"), Byte())
                        If Convert.IsDBNull(Rdr("icon_green")) = False Then _icon_green = CType(Rdr("icon_green"), Byte())
                        If Convert.IsDBNull(Rdr("icon_red")) = False Then _icon_red = CType(Rdr("icon_red"), Byte())
                        If Convert.IsDBNull(Rdr("device_order")) = False Then _device_order = Convert.ToInt32(Rdr("device_order"))
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


        'Get Insert Statement for table MS_DEVICE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, DEVICE_NAME_TH, DEVICE_NAME_EN, MS_DEVICE_TYPE_ID, UNIT_VALUE, MAX_QTY, WARNING_QTY, CRITICAL_QTY, ICON_WHITE, ICON_GREEN, ICON_RED, DEVICE_ORDER, ACTIVE_STATUS)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.DEVICE_NAME_TH, INSERTED.DEVICE_NAME_EN, INSERTED.MS_DEVICE_TYPE_ID, INSERTED.UNIT_VALUE, INSERTED.MAX_QTY, INSERTED.WARNING_QTY, INSERTED.CRITICAL_QTY, INSERTED.ICON_WHITE, INSERTED.ICON_GREEN, INSERTED.ICON_RED, INSERTED.DEVICE_ORDER, INSERTED.ACTIVE_STATUS"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_DEVICE_NAME_TH" & ", "
                sql += "@_DEVICE_NAME_EN" & ", "
                sql += "@_MS_DEVICE_TYPE_ID" & ", "
                sql += "@_UNIT_VALUE" & ", "
                sql += "@_MAX_QTY" & ", "
                sql += "@_WARNING_QTY" & ", "
                sql += "@_CRITICAL_QTY" & ", "
                sql += "@_ICON_WHITE" & ", "
                sql += "@_ICON_GREEN" & ", "
                sql += "@_ICON_RED" & ", "
                sql += "@_DEVICE_ORDER" & ", "
                sql += "@_ACTIVE_STATUS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_DEVICE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "DEVICE_NAME_TH = " & "@_DEVICE_NAME_TH" & ", "
                Sql += "DEVICE_NAME_EN = " & "@_DEVICE_NAME_EN" & ", "
                Sql += "MS_DEVICE_TYPE_ID = " & "@_MS_DEVICE_TYPE_ID" & ", "
                Sql += "UNIT_VALUE = " & "@_UNIT_VALUE" & ", "
                Sql += "MAX_QTY = " & "@_MAX_QTY" & ", "
                Sql += "WARNING_QTY = " & "@_WARNING_QTY" & ", "
                Sql += "CRITICAL_QTY = " & "@_CRITICAL_QTY" & ", "
                Sql += "ICON_WHITE = " & "@_ICON_WHITE" & ", "
                Sql += "ICON_GREEN = " & "@_ICON_GREEN" & ", "
                Sql += "ICON_RED = " & "@_ICON_RED" & ", "
                Sql += "DEVICE_ORDER = " & "@_DEVICE_ORDER" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_DEVICE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_DEVICE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, DEVICE_NAME_TH, DEVICE_NAME_EN, MS_DEVICE_TYPE_ID, UNIT_VALUE, MAX_QTY, WARNING_QTY, CRITICAL_QTY, ICON_WHITE, ICON_GREEN, ICON_RED, DEVICE_ORDER, ACTIVE_STATUS FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
