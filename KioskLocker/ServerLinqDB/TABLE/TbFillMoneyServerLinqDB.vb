Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TB_FILL_MONEY table ServerLinqDB.
    '[Create by  on November, 17 2017]
    Public Class TbFillMoneyServerLinqDB
        Public sub TbFillMoneyServerLinqDB()

        End Sub 
        ' TB_FILL_MONEY
        Const _tableName As String = "TB_FILL_MONEY"

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
        Dim _COIN_MONEY As Double = 0
        Dim _BANKNOTE_MONEY As Double = 0
        Dim _CHECKOUT_RECEIVE_MONEY As Char = "N"
        Dim _CHECKOUT_DATETIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CHANGE1_REMAIN As Long = 0
        Dim _CHANGE2_REMAIN As Long = 0
        Dim _CHANGE5_REMAIN As Long = 0
        Dim _CHANGE10_REMAIN As Long = 0
        Dim _CHANGE20_REMAIN As Long = 0
        Dim _CHANGE50_REMAIN As Long = 0
        Dim _CHANGE100_REMAIN As Long = 0
        Dim _CHANGE500_REMAIN As Long = 0
        Dim _CHECKIN_CHANGE_MONEY As Char = "N"
        Dim _CHECKIN_DATETIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _TOTAL_MONEY_REMAIN As Double = 0
        Dim _IS_CONFIRM As Char = "Z"
        Dim _CONFIRM_CANCEL_DATETIME As DateTime = New DateTime(1,1,1)
        Dim _CHANGE1_QTY As Long = 0
        Dim _CHANGE2_QTY As Long = 0
        Dim _CHANGE5_QTY As Long = 0
        Dim _CHANGE10_QTY As Long = 0
        Dim _CHANGE20_QTY As Long = 0
        Dim _CHANGE50_QTY As Long = 0
        Dim _CHANGE100_QTY As Long = 0
        Dim _CHANGE500_QTY As Long = 0
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
        <Column(Storage:="_COIN_MONEY", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property COIN_MONEY() As Double
            Get
                Return _COIN_MONEY
            End Get
            Set(ByVal value As Double)
               _COIN_MONEY = value
            End Set
        End Property 
        <Column(Storage:="_BANKNOTE_MONEY", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property BANKNOTE_MONEY() As Double
            Get
                Return _BANKNOTE_MONEY
            End Get
            Set(ByVal value As Double)
               _BANKNOTE_MONEY = value
            End Set
        End Property 
        <Column(Storage:="_CHECKOUT_RECEIVE_MONEY", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property CHECKOUT_RECEIVE_MONEY() As Char
            Get
                Return _CHECKOUT_RECEIVE_MONEY
            End Get
            Set(ByVal value As Char)
               _CHECKOUT_RECEIVE_MONEY = value
            End Set
        End Property 
        <Column(Storage:="_CHECKOUT_DATETIME", DbType:="DateTime")>  _
        Public Property CHECKOUT_DATETIME() As  System.Nullable(Of DateTime) 
            Get
                Return _CHECKOUT_DATETIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _CHECKOUT_DATETIME = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE1_REMAIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE1_REMAIN() As Long
            Get
                Return _CHANGE1_REMAIN
            End Get
            Set(ByVal value As Long)
               _CHANGE1_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE2_REMAIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE2_REMAIN() As Long
            Get
                Return _CHANGE2_REMAIN
            End Get
            Set(ByVal value As Long)
               _CHANGE2_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE5_REMAIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE5_REMAIN() As Long
            Get
                Return _CHANGE5_REMAIN
            End Get
            Set(ByVal value As Long)
               _CHANGE5_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE10_REMAIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE10_REMAIN() As Long
            Get
                Return _CHANGE10_REMAIN
            End Get
            Set(ByVal value As Long)
               _CHANGE10_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE20_REMAIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE20_REMAIN() As Long
            Get
                Return _CHANGE20_REMAIN
            End Get
            Set(ByVal value As Long)
               _CHANGE20_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE50_REMAIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE50_REMAIN() As Long
            Get
                Return _CHANGE50_REMAIN
            End Get
            Set(ByVal value As Long)
               _CHANGE50_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE100_REMAIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE100_REMAIN() As Long
            Get
                Return _CHANGE100_REMAIN
            End Get
            Set(ByVal value As Long)
               _CHANGE100_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE500_REMAIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE500_REMAIN() As Long
            Get
                Return _CHANGE500_REMAIN
            End Get
            Set(ByVal value As Long)
               _CHANGE500_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_CHECKIN_CHANGE_MONEY", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property CHECKIN_CHANGE_MONEY() As Char
            Get
                Return _CHECKIN_CHANGE_MONEY
            End Get
            Set(ByVal value As Char)
               _CHECKIN_CHANGE_MONEY = value
            End Set
        End Property 
        <Column(Storage:="_CHECKIN_DATETIME", DbType:="DateTime")>  _
        Public Property CHECKIN_DATETIME() As  System.Nullable(Of DateTime) 
            Get
                Return _CHECKIN_DATETIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _CHECKIN_DATETIME = value
            End Set
        End Property 
        <Column(Storage:="_TOTAL_MONEY_REMAIN", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property TOTAL_MONEY_REMAIN() As Double
            Get
                Return _TOTAL_MONEY_REMAIN
            End Get
            Set(ByVal value As Double)
               _TOTAL_MONEY_REMAIN = value
            End Set
        End Property 
        <Column(Storage:="_IS_CONFIRM", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_CONFIRM() As Char
            Get
                Return _IS_CONFIRM
            End Get
            Set(ByVal value As Char)
               _IS_CONFIRM = value
            End Set
        End Property 
        <Column(Storage:="_CONFIRM_CANCEL_DATETIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CONFIRM_CANCEL_DATETIME() As DateTime
            Get
                Return _CONFIRM_CANCEL_DATETIME
            End Get
            Set(ByVal value As DateTime)
               _CONFIRM_CANCEL_DATETIME = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE1_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE1_QTY() As Long
            Get
                Return _CHANGE1_QTY
            End Get
            Set(ByVal value As Long)
               _CHANGE1_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE2_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE2_QTY() As Long
            Get
                Return _CHANGE2_QTY
            End Get
            Set(ByVal value As Long)
               _CHANGE2_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE5_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE5_QTY() As Long
            Get
                Return _CHANGE5_QTY
            End Get
            Set(ByVal value As Long)
               _CHANGE5_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE10_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE10_QTY() As Long
            Get
                Return _CHANGE10_QTY
            End Get
            Set(ByVal value As Long)
               _CHANGE10_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE20_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE20_QTY() As Long
            Get
                Return _CHANGE20_QTY
            End Get
            Set(ByVal value As Long)
               _CHANGE20_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE50_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE50_QTY() As Long
            Get
                Return _CHANGE50_QTY
            End Get
            Set(ByVal value As Long)
               _CHANGE50_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE100_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE100_QTY() As Long
            Get
                Return _CHANGE100_QTY
            End Get
            Set(ByVal value As Long)
               _CHANGE100_QTY = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE500_QTY", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE500_QTY() As Long
            Get
                Return _CHANGE500_QTY
            End Get
            Set(ByVal value As Long)
               _CHANGE500_QTY = value
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
            _COIN_MONEY = 0
            _BANKNOTE_MONEY = 0
            _CHECKOUT_RECEIVE_MONEY = "N"
            _CHECKOUT_DATETIME = New DateTime(1,1,1)
            _CHANGE1_REMAIN = 0
            _CHANGE2_REMAIN = 0
            _CHANGE5_REMAIN = 0
            _CHANGE10_REMAIN = 0
            _CHANGE20_REMAIN = 0
            _CHANGE50_REMAIN = 0
            _CHANGE100_REMAIN = 0
            _CHANGE500_REMAIN = 0
            _CHECKIN_CHANGE_MONEY = "N"
            _CHECKIN_DATETIME = New DateTime(1,1,1)
            _TOTAL_MONEY_REMAIN = 0
            _IS_CONFIRM = "Z"
            _CONFIRM_CANCEL_DATETIME = New DateTime(1,1,1)
            _CHANGE1_QTY = 0
            _CHANGE2_QTY = 0
            _CHANGE5_QTY = 0
            _CHANGE10_QTY = 0
            _CHANGE20_QTY = 0
            _CHANGE50_QTY = 0
            _CHANGE100_QTY = 0
            _CHANGE500_QTY = 0
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


        '/// Returns an indication whether the current data is inserted into TB_FILL_MONEY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FILL_MONEY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FILL_MONEY table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_FILL_MONEY table successfully.
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


        '/// Returns an indication whether the record of TB_FILL_MONEY by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_FILL_MONEY by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbFillMoneyServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of TB_FILL_MONEY by specified MS_KIOSK_ID key is retrieved successfully.
        '/// <param name=cMS_KIOSK_ID>The MS_KIOSK_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_KIOSK_ID(cMS_KIOSK_ID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_KIOSK_ID", cMS_KIOSK_ID) 
            Return doChkData("MS_KIOSK_ID = @_MS_KIOSK_ID", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_FILL_MONEY by specified MS_KIOSK_ID key is retrieved successfully.
        '/// <param name=cMS_KIOSK_ID>The MS_KIOSK_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_KIOSK_ID(cMS_KIOSK_ID As Long, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_KIOSK_ID", cMS_KIOSK_ID) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("MS_KIOSK_ID = @_MS_KIOSK_ID And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_FILL_MONEY by specified CONFIRM_CANCEL_DATETIME key is retrieved successfully.
        '/// <param name=cCONFIRM_CANCEL_DATETIME>The CONFIRM_CANCEL_DATETIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCONFIRM_CANCEL_DATETIME(cCONFIRM_CANCEL_DATETIME As DateTime, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_CONFIRM_CANCEL_DATETIME", cCONFIRM_CANCEL_DATETIME) 
            Return doChkData("CONFIRM_CANCEL_DATETIME = @_CONFIRM_CANCEL_DATETIME", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_FILL_MONEY by specified CONFIRM_CANCEL_DATETIME key is retrieved successfully.
        '/// <param name=cCONFIRM_CANCEL_DATETIME>The CONFIRM_CANCEL_DATETIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCONFIRM_CANCEL_DATETIME(cCONFIRM_CANCEL_DATETIME As DateTime, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_CONFIRM_CANCEL_DATETIME", cCONFIRM_CANCEL_DATETIME) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("CONFIRM_CANCEL_DATETIME = @_CONFIRM_CANCEL_DATETIME And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_FILL_MONEY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_FILL_MONEY table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FILL_MONEY table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_FILL_MONEY table successfully.
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
            Dim cmbParam(31) As SqlParameter
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

            cmbParam(6) = New SqlParameter("@_COIN_MONEY", SqlDbType.Float)
            cmbParam(6).Value = _COIN_MONEY

            cmbParam(7) = New SqlParameter("@_BANKNOTE_MONEY", SqlDbType.Float)
            cmbParam(7).Value = _BANKNOTE_MONEY

            cmbParam(8) = New SqlParameter("@_CHECKOUT_RECEIVE_MONEY", SqlDbType.Char)
            cmbParam(8).Value = _CHECKOUT_RECEIVE_MONEY

            cmbParam(9) = New SqlParameter("@_CHECKOUT_DATETIME", SqlDbType.DateTime)
            If _CHECKOUT_DATETIME.Value.Year > 1 Then 
                cmbParam(9).Value = _CHECKOUT_DATETIME.Value
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_CHANGE1_REMAIN", SqlDbType.Int)
            cmbParam(10).Value = _CHANGE1_REMAIN

            cmbParam(11) = New SqlParameter("@_CHANGE2_REMAIN", SqlDbType.Int)
            cmbParam(11).Value = _CHANGE2_REMAIN

            cmbParam(12) = New SqlParameter("@_CHANGE5_REMAIN", SqlDbType.Int)
            cmbParam(12).Value = _CHANGE5_REMAIN

            cmbParam(13) = New SqlParameter("@_CHANGE10_REMAIN", SqlDbType.Int)
            cmbParam(13).Value = _CHANGE10_REMAIN

            cmbParam(14) = New SqlParameter("@_CHANGE20_REMAIN", SqlDbType.Int)
            cmbParam(14).Value = _CHANGE20_REMAIN

            cmbParam(15) = New SqlParameter("@_CHANGE50_REMAIN", SqlDbType.Int)
            cmbParam(15).Value = _CHANGE50_REMAIN

            cmbParam(16) = New SqlParameter("@_CHANGE100_REMAIN", SqlDbType.Int)
            cmbParam(16).Value = _CHANGE100_REMAIN

            cmbParam(17) = New SqlParameter("@_CHANGE500_REMAIN", SqlDbType.Int)
            cmbParam(17).Value = _CHANGE500_REMAIN

            cmbParam(18) = New SqlParameter("@_CHECKIN_CHANGE_MONEY", SqlDbType.Char)
            cmbParam(18).Value = _CHECKIN_CHANGE_MONEY

            cmbParam(19) = New SqlParameter("@_CHECKIN_DATETIME", SqlDbType.DateTime)
            If _CHECKIN_DATETIME.Value.Year > 1 Then 
                cmbParam(19).Value = _CHECKIN_DATETIME.Value
            Else
                cmbParam(19).Value = DBNull.value
            End If

            cmbParam(20) = New SqlParameter("@_TOTAL_MONEY_REMAIN", SqlDbType.Float)
            cmbParam(20).Value = _TOTAL_MONEY_REMAIN

            cmbParam(21) = New SqlParameter("@_IS_CONFIRM", SqlDbType.Char)
            cmbParam(21).Value = _IS_CONFIRM

            cmbParam(22) = New SqlParameter("@_CONFIRM_CANCEL_DATETIME", SqlDbType.DateTime)
            cmbParam(22).Value = _CONFIRM_CANCEL_DATETIME

            cmbParam(23) = New SqlParameter("@_CHANGE1_QTY", SqlDbType.Int)
            cmbParam(23).Value = _CHANGE1_QTY

            cmbParam(24) = New SqlParameter("@_CHANGE2_QTY", SqlDbType.Int)
            cmbParam(24).Value = _CHANGE2_QTY

            cmbParam(25) = New SqlParameter("@_CHANGE5_QTY", SqlDbType.Int)
            cmbParam(25).Value = _CHANGE5_QTY

            cmbParam(26) = New SqlParameter("@_CHANGE10_QTY", SqlDbType.Int)
            cmbParam(26).Value = _CHANGE10_QTY

            cmbParam(27) = New SqlParameter("@_CHANGE20_QTY", SqlDbType.Int)
            cmbParam(27).Value = _CHANGE20_QTY

            cmbParam(28) = New SqlParameter("@_CHANGE50_QTY", SqlDbType.Int)
            cmbParam(28).Value = _CHANGE50_QTY

            cmbParam(29) = New SqlParameter("@_CHANGE100_QTY", SqlDbType.Int)
            cmbParam(29).Value = _CHANGE100_QTY

            cmbParam(30) = New SqlParameter("@_CHANGE500_QTY", SqlDbType.Int)
            cmbParam(30).Value = _CHANGE500_QTY

            cmbParam(31) = New SqlParameter("@_SYNC_TO_SERVER", SqlDbType.Char)
            cmbParam(31).Value = _SYNC_TO_SERVER

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_FILL_MONEY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("coin_money")) = False Then _coin_money = Convert.ToDouble(Rdr("coin_money"))
                        If Convert.IsDBNull(Rdr("banknote_money")) = False Then _banknote_money = Convert.ToDouble(Rdr("banknote_money"))
                        If Convert.IsDBNull(Rdr("checkout_receive_money")) = False Then _checkout_receive_money = Rdr("checkout_receive_money").ToString()
                        If Convert.IsDBNull(Rdr("checkout_datetime")) = False Then _checkout_datetime = Convert.ToDateTime(Rdr("checkout_datetime"))
                        If Convert.IsDBNull(Rdr("change1_remain")) = False Then _change1_remain = Convert.ToInt32(Rdr("change1_remain"))
                        If Convert.IsDBNull(Rdr("change2_remain")) = False Then _change2_remain = Convert.ToInt32(Rdr("change2_remain"))
                        If Convert.IsDBNull(Rdr("change5_remain")) = False Then _change5_remain = Convert.ToInt32(Rdr("change5_remain"))
                        If Convert.IsDBNull(Rdr("change10_remain")) = False Then _change10_remain = Convert.ToInt32(Rdr("change10_remain"))
                        If Convert.IsDBNull(Rdr("change20_remain")) = False Then _change20_remain = Convert.ToInt32(Rdr("change20_remain"))
                        If Convert.IsDBNull(Rdr("change50_remain")) = False Then _change50_remain = Convert.ToInt32(Rdr("change50_remain"))
                        If Convert.IsDBNull(Rdr("change100_remain")) = False Then _change100_remain = Convert.ToInt32(Rdr("change100_remain"))
                        If Convert.IsDBNull(Rdr("change500_remain")) = False Then _change500_remain = Convert.ToInt32(Rdr("change500_remain"))
                        If Convert.IsDBNull(Rdr("checkin_change_money")) = False Then _checkin_change_money = Rdr("checkin_change_money").ToString()
                        If Convert.IsDBNull(Rdr("checkin_datetime")) = False Then _checkin_datetime = Convert.ToDateTime(Rdr("checkin_datetime"))
                        If Convert.IsDBNull(Rdr("total_money_remain")) = False Then _total_money_remain = Convert.ToDouble(Rdr("total_money_remain"))
                        If Convert.IsDBNull(Rdr("is_confirm")) = False Then _is_confirm = Rdr("is_confirm").ToString()
                        If Convert.IsDBNull(Rdr("confirm_cancel_datetime")) = False Then _confirm_cancel_datetime = Convert.ToDateTime(Rdr("confirm_cancel_datetime"))
                        If Convert.IsDBNull(Rdr("change1_qty")) = False Then _change1_qty = Convert.ToInt32(Rdr("change1_qty"))
                        If Convert.IsDBNull(Rdr("change2_qty")) = False Then _change2_qty = Convert.ToInt32(Rdr("change2_qty"))
                        If Convert.IsDBNull(Rdr("change5_qty")) = False Then _change5_qty = Convert.ToInt32(Rdr("change5_qty"))
                        If Convert.IsDBNull(Rdr("change10_qty")) = False Then _change10_qty = Convert.ToInt32(Rdr("change10_qty"))
                        If Convert.IsDBNull(Rdr("change20_qty")) = False Then _change20_qty = Convert.ToInt32(Rdr("change20_qty"))
                        If Convert.IsDBNull(Rdr("change50_qty")) = False Then _change50_qty = Convert.ToInt32(Rdr("change50_qty"))
                        If Convert.IsDBNull(Rdr("change100_qty")) = False Then _change100_qty = Convert.ToInt32(Rdr("change100_qty"))
                        If Convert.IsDBNull(Rdr("change500_qty")) = False Then _change500_qty = Convert.ToInt32(Rdr("change500_qty"))
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


        '/// Returns an indication whether the record of TB_FILL_MONEY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As TbFillMoneyServerLinqDB
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
                        If Convert.IsDBNull(Rdr("coin_money")) = False Then _coin_money = Convert.ToDouble(Rdr("coin_money"))
                        If Convert.IsDBNull(Rdr("banknote_money")) = False Then _banknote_money = Convert.ToDouble(Rdr("banknote_money"))
                        If Convert.IsDBNull(Rdr("checkout_receive_money")) = False Then _checkout_receive_money = Rdr("checkout_receive_money").ToString()
                        If Convert.IsDBNull(Rdr("checkout_datetime")) = False Then _checkout_datetime = Convert.ToDateTime(Rdr("checkout_datetime"))
                        If Convert.IsDBNull(Rdr("change1_remain")) = False Then _change1_remain = Convert.ToInt32(Rdr("change1_remain"))
                        If Convert.IsDBNull(Rdr("change2_remain")) = False Then _change2_remain = Convert.ToInt32(Rdr("change2_remain"))
                        If Convert.IsDBNull(Rdr("change5_remain")) = False Then _change5_remain = Convert.ToInt32(Rdr("change5_remain"))
                        If Convert.IsDBNull(Rdr("change10_remain")) = False Then _change10_remain = Convert.ToInt32(Rdr("change10_remain"))
                        If Convert.IsDBNull(Rdr("change20_remain")) = False Then _change20_remain = Convert.ToInt32(Rdr("change20_remain"))
                        If Convert.IsDBNull(Rdr("change50_remain")) = False Then _change50_remain = Convert.ToInt32(Rdr("change50_remain"))
                        If Convert.IsDBNull(Rdr("change100_remain")) = False Then _change100_remain = Convert.ToInt32(Rdr("change100_remain"))
                        If Convert.IsDBNull(Rdr("change500_remain")) = False Then _change500_remain = Convert.ToInt32(Rdr("change500_remain"))
                        If Convert.IsDBNull(Rdr("checkin_change_money")) = False Then _checkin_change_money = Rdr("checkin_change_money").ToString()
                        If Convert.IsDBNull(Rdr("checkin_datetime")) = False Then _checkin_datetime = Convert.ToDateTime(Rdr("checkin_datetime"))
                        If Convert.IsDBNull(Rdr("total_money_remain")) = False Then _total_money_remain = Convert.ToDouble(Rdr("total_money_remain"))
                        If Convert.IsDBNull(Rdr("is_confirm")) = False Then _is_confirm = Rdr("is_confirm").ToString()
                        If Convert.IsDBNull(Rdr("confirm_cancel_datetime")) = False Then _confirm_cancel_datetime = Convert.ToDateTime(Rdr("confirm_cancel_datetime"))
                        If Convert.IsDBNull(Rdr("change1_qty")) = False Then _change1_qty = Convert.ToInt32(Rdr("change1_qty"))
                        If Convert.IsDBNull(Rdr("change2_qty")) = False Then _change2_qty = Convert.ToInt32(Rdr("change2_qty"))
                        If Convert.IsDBNull(Rdr("change5_qty")) = False Then _change5_qty = Convert.ToInt32(Rdr("change5_qty"))
                        If Convert.IsDBNull(Rdr("change10_qty")) = False Then _change10_qty = Convert.ToInt32(Rdr("change10_qty"))
                        If Convert.IsDBNull(Rdr("change20_qty")) = False Then _change20_qty = Convert.ToInt32(Rdr("change20_qty"))
                        If Convert.IsDBNull(Rdr("change50_qty")) = False Then _change50_qty = Convert.ToInt32(Rdr("change50_qty"))
                        If Convert.IsDBNull(Rdr("change100_qty")) = False Then _change100_qty = Convert.ToInt32(Rdr("change100_qty"))
                        If Convert.IsDBNull(Rdr("change500_qty")) = False Then _change500_qty = Convert.ToInt32(Rdr("change500_qty"))
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


        'Get Insert Statement for table TB_FILL_MONEY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, MS_KIOSK_ID, COIN_MONEY, BANKNOTE_MONEY, CHECKOUT_RECEIVE_MONEY, CHECKOUT_DATETIME, CHANGE1_REMAIN, CHANGE2_REMAIN, CHANGE5_REMAIN, CHANGE10_REMAIN, CHANGE20_REMAIN, CHANGE50_REMAIN, CHANGE100_REMAIN, CHANGE500_REMAIN, CHECKIN_CHANGE_MONEY, CHECKIN_DATETIME, TOTAL_MONEY_REMAIN, IS_CONFIRM, CONFIRM_CANCEL_DATETIME, CHANGE1_QTY, CHANGE2_QTY, CHANGE5_QTY, CHANGE10_QTY, CHANGE20_QTY, CHANGE50_QTY, CHANGE100_QTY, CHANGE500_QTY, SYNC_TO_SERVER)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_KIOSK_ID, INSERTED.COIN_MONEY, INSERTED.BANKNOTE_MONEY, INSERTED.CHECKOUT_RECEIVE_MONEY, INSERTED.CHECKOUT_DATETIME, INSERTED.CHANGE1_REMAIN, INSERTED.CHANGE2_REMAIN, INSERTED.CHANGE5_REMAIN, INSERTED.CHANGE10_REMAIN, INSERTED.CHANGE20_REMAIN, INSERTED.CHANGE50_REMAIN, INSERTED.CHANGE100_REMAIN, INSERTED.CHANGE500_REMAIN, INSERTED.CHECKIN_CHANGE_MONEY, INSERTED.CHECKIN_DATETIME, INSERTED.TOTAL_MONEY_REMAIN, INSERTED.IS_CONFIRM, INSERTED.CONFIRM_CANCEL_DATETIME, INSERTED.CHANGE1_QTY, INSERTED.CHANGE2_QTY, INSERTED.CHANGE5_QTY, INSERTED.CHANGE10_QTY, INSERTED.CHANGE20_QTY, INSERTED.CHANGE50_QTY, INSERTED.CHANGE100_QTY, INSERTED.CHANGE500_QTY, INSERTED.SYNC_TO_SERVER"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MS_KIOSK_ID" & ", "
                sql += "@_COIN_MONEY" & ", "
                sql += "@_BANKNOTE_MONEY" & ", "
                sql += "@_CHECKOUT_RECEIVE_MONEY" & ", "
                sql += "@_CHECKOUT_DATETIME" & ", "
                sql += "@_CHANGE1_REMAIN" & ", "
                sql += "@_CHANGE2_REMAIN" & ", "
                sql += "@_CHANGE5_REMAIN" & ", "
                sql += "@_CHANGE10_REMAIN" & ", "
                sql += "@_CHANGE20_REMAIN" & ", "
                sql += "@_CHANGE50_REMAIN" & ", "
                sql += "@_CHANGE100_REMAIN" & ", "
                sql += "@_CHANGE500_REMAIN" & ", "
                sql += "@_CHECKIN_CHANGE_MONEY" & ", "
                sql += "@_CHECKIN_DATETIME" & ", "
                sql += "@_TOTAL_MONEY_REMAIN" & ", "
                sql += "@_IS_CONFIRM" & ", "
                sql += "@_CONFIRM_CANCEL_DATETIME" & ", "
                sql += "@_CHANGE1_QTY" & ", "
                sql += "@_CHANGE2_QTY" & ", "
                sql += "@_CHANGE5_QTY" & ", "
                sql += "@_CHANGE10_QTY" & ", "
                sql += "@_CHANGE20_QTY" & ", "
                sql += "@_CHANGE50_QTY" & ", "
                sql += "@_CHANGE100_QTY" & ", "
                sql += "@_CHANGE500_QTY" & ", "
                sql += "@_SYNC_TO_SERVER"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_FILL_MONEY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_KIOSK_ID = " & "@_MS_KIOSK_ID" & ", "
                Sql += "COIN_MONEY = " & "@_COIN_MONEY" & ", "
                Sql += "BANKNOTE_MONEY = " & "@_BANKNOTE_MONEY" & ", "
                Sql += "CHECKOUT_RECEIVE_MONEY = " & "@_CHECKOUT_RECEIVE_MONEY" & ", "
                Sql += "CHECKOUT_DATETIME = " & "@_CHECKOUT_DATETIME" & ", "
                Sql += "CHANGE1_REMAIN = " & "@_CHANGE1_REMAIN" & ", "
                Sql += "CHANGE2_REMAIN = " & "@_CHANGE2_REMAIN" & ", "
                Sql += "CHANGE5_REMAIN = " & "@_CHANGE5_REMAIN" & ", "
                Sql += "CHANGE10_REMAIN = " & "@_CHANGE10_REMAIN" & ", "
                Sql += "CHANGE20_REMAIN = " & "@_CHANGE20_REMAIN" & ", "
                Sql += "CHANGE50_REMAIN = " & "@_CHANGE50_REMAIN" & ", "
                Sql += "CHANGE100_REMAIN = " & "@_CHANGE100_REMAIN" & ", "
                Sql += "CHANGE500_REMAIN = " & "@_CHANGE500_REMAIN" & ", "
                Sql += "CHECKIN_CHANGE_MONEY = " & "@_CHECKIN_CHANGE_MONEY" & ", "
                Sql += "CHECKIN_DATETIME = " & "@_CHECKIN_DATETIME" & ", "
                Sql += "TOTAL_MONEY_REMAIN = " & "@_TOTAL_MONEY_REMAIN" & ", "
                Sql += "IS_CONFIRM = " & "@_IS_CONFIRM" & ", "
                Sql += "CONFIRM_CANCEL_DATETIME = " & "@_CONFIRM_CANCEL_DATETIME" & ", "
                Sql += "CHANGE1_QTY = " & "@_CHANGE1_QTY" & ", "
                Sql += "CHANGE2_QTY = " & "@_CHANGE2_QTY" & ", "
                Sql += "CHANGE5_QTY = " & "@_CHANGE5_QTY" & ", "
                Sql += "CHANGE10_QTY = " & "@_CHANGE10_QTY" & ", "
                Sql += "CHANGE20_QTY = " & "@_CHANGE20_QTY" & ", "
                Sql += "CHANGE50_QTY = " & "@_CHANGE50_QTY" & ", "
                Sql += "CHANGE100_QTY = " & "@_CHANGE100_QTY" & ", "
                Sql += "CHANGE500_QTY = " & "@_CHANGE500_QTY" & ", "
                Sql += "SYNC_TO_SERVER = " & "@_SYNC_TO_SERVER" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_FILL_MONEY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_FILL_MONEY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_KIOSK_ID, COIN_MONEY, BANKNOTE_MONEY, CHECKOUT_RECEIVE_MONEY, CHECKOUT_DATETIME, CHANGE1_REMAIN, CHANGE2_REMAIN, CHANGE5_REMAIN, CHANGE10_REMAIN, CHANGE20_REMAIN, CHANGE50_REMAIN, CHANGE100_REMAIN, CHANGE500_REMAIN, CHECKIN_CHANGE_MONEY, CHECKIN_DATETIME, TOTAL_MONEY_REMAIN, IS_CONFIRM, CONFIRM_CANCEL_DATETIME, CHANGE1_QTY, CHANGE2_QTY, CHANGE5_QTY, CHANGE10_QTY, CHANGE20_QTY, CHANGE50_QTY, CHANGE100_QTY, CHANGE500_QTY, SYNC_TO_SERVER FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
