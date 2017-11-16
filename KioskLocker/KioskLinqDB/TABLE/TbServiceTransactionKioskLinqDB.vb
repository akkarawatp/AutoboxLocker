Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = KioskLinqDB.ConnectDB.KioskDB
Imports KioskLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TB_SERVICE_TRANSACTION table KioskLinqDB.
    '[Create by  on July, 15 2016]
    Public Class TbServiceTransactionKioskLinqDB
        Public sub TbServiceTransactionKioskLinqDB()

        End Sub 
        ' TB_SERVICE_TRANSACTION
        Const _tableName As String = "TB_SERVICE_TRANSACTION"

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
        Dim _MS_LOCKER_ID As  System.Nullable(Of Long) 
        Dim _PASSPORT_NO As  String  = ""
        Dim _IDCARD_NO As  String  = ""
        Dim _NATION_CODE As  String  = ""
        Dim _FIRST_NAME As  String  = ""
        Dim _LAST_NAME As  String  = ""
        Dim _GENDER As  System.Nullable(Of Char)  = ""
        Dim _BIRTH_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _PASSPORT_EXPIRE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _IDCARD_EXPIRE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CUST_IMAGE() As Byte
        Dim _SERVICE_RATE As Double = 0
        Dim _SERVICE_RATE_LIMIT_DAY As Double = 0
        Dim _DEPOSIT_AMT As Double = 0
        Dim _PAID_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _RECEIVE_COIN1 As Long = 0
        Dim _RECEIVE_COIN2 As Long = 0
        Dim _RECEIVE_COIN5 As Long = 0
        Dim _RECEIVE_COIN10 As Long = 0
        Dim _RECEIVE_BANKNOTE20 As Long = 0
        Dim _RECEIVE_BANKNOTE50 As Long = 0
        Dim _RECEIVE_BANKNOTE100 As Long = 0
        Dim _RECEIVE_BANKNOTE500 As Long = 0
        Dim _RECEIVE_BANKNOTE1000 As Long = 0
        Dim _CHANGE_COIN1 As Long = 0
        Dim _CHANGE_COIN2 As Long = 0
        Dim _CHANGE_COIN5 As Long = 0
        Dim _CHANGE_COIN10 As Long = 0
        Dim _CHANGE_BANKNOTE20 As Long = 0
        Dim _CHANGE_BANKNOTE50 As Long = 0
        Dim _CHANGE_BANKNOTE100 As Long = 0
        Dim _CHANGE_BANKNOTE500 As Long = 0
        Dim _TRANS_STATUS As Char = "0"
        Dim _MS_APP_SCREEN_ID As Long = 0
        Dim _MS_APP_STEP_ID As Long = 0
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
        <Column(Storage:="_MS_LOCKER_ID", DbType:="BigInt")>  _
        Public Property MS_LOCKER_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_LOCKER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_LOCKER_ID = value
            End Set
        End Property 
        <Column(Storage:="_PASSPORT_NO", DbType:="VarChar(50)")>  _
        Public Property PASSPORT_NO() As  String 
            Get
                Return _PASSPORT_NO
            End Get
            Set(ByVal value As  String )
               _PASSPORT_NO = value
            End Set
        End Property 
        <Column(Storage:="_IDCARD_NO", DbType:="VarChar(50)")>  _
        Public Property IDCARD_NO() As  String 
            Get
                Return _IDCARD_NO
            End Get
            Set(ByVal value As  String )
               _IDCARD_NO = value
            End Set
        End Property 
        <Column(Storage:="_NATION_CODE", DbType:="VarChar(10)")>  _
        Public Property NATION_CODE() As  String 
            Get
                Return _NATION_CODE
            End Get
            Set(ByVal value As  String )
               _NATION_CODE = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME", DbType:="VarChar(100)")>  _
        Public Property FIRST_NAME() As  String 
            Get
                Return _FIRST_NAME
            End Get
            Set(ByVal value As  String )
               _FIRST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME", DbType:="VarChar(100)")>  _
        Public Property LAST_NAME() As  String 
            Get
                Return _LAST_NAME
            End Get
            Set(ByVal value As  String )
               _LAST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_GENDER", DbType:="Char(1)")>  _
        Public Property GENDER() As  System.Nullable(Of Char) 
            Get
                Return _GENDER
            End Get
            Set(ByVal value As  System.Nullable(Of Char) )
               _GENDER = value
            End Set
        End Property 
        <Column(Storage:="_BIRTH_DATE", DbType:="DateTime")>  _
        Public Property BIRTH_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _BIRTH_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _BIRTH_DATE = value
            End Set
        End Property 
        <Column(Storage:="_PASSPORT_EXPIRE_DATE", DbType:="DateTime")>  _
        Public Property PASSPORT_EXPIRE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _PASSPORT_EXPIRE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _PASSPORT_EXPIRE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_IDCARD_EXPIRE_DATE", DbType:="DateTime")>  _
        Public Property IDCARD_EXPIRE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _IDCARD_EXPIRE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _IDCARD_EXPIRE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_CUST_IMAGE", DbType:="IMAGE")>  _
        Public Property CUST_IMAGE() As  Byte() 
            Get
                Return _CUST_IMAGE
            End Get
            Set(ByVal value() As Byte)
               _CUST_IMAGE = value
            End Set
        End Property 
        <Column(Storage:="_SERVICE_RATE", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVICE_RATE() As Double
            Get
                Return _SERVICE_RATE
            End Get
            Set(ByVal value As Double)
               _SERVICE_RATE = value
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
        <Column(Storage:="_PAID_TIME", DbType:="DateTime")>  _
        Public Property PAID_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _PAID_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _PAID_TIME = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_COIN1", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_COIN1() As Long
            Get
                Return _RECEIVE_COIN1
            End Get
            Set(ByVal value As Long)
               _RECEIVE_COIN1 = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_COIN2", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_COIN2() As Long
            Get
                Return _RECEIVE_COIN2
            End Get
            Set(ByVal value As Long)
               _RECEIVE_COIN2 = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_COIN5", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_COIN5() As Long
            Get
                Return _RECEIVE_COIN5
            End Get
            Set(ByVal value As Long)
               _RECEIVE_COIN5 = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_COIN10", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_COIN10() As Long
            Get
                Return _RECEIVE_COIN10
            End Get
            Set(ByVal value As Long)
               _RECEIVE_COIN10 = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_BANKNOTE20", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_BANKNOTE20() As Long
            Get
                Return _RECEIVE_BANKNOTE20
            End Get
            Set(ByVal value As Long)
               _RECEIVE_BANKNOTE20 = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_BANKNOTE50", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_BANKNOTE50() As Long
            Get
                Return _RECEIVE_BANKNOTE50
            End Get
            Set(ByVal value As Long)
               _RECEIVE_BANKNOTE50 = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_BANKNOTE100", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_BANKNOTE100() As Long
            Get
                Return _RECEIVE_BANKNOTE100
            End Get
            Set(ByVal value As Long)
               _RECEIVE_BANKNOTE100 = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_BANKNOTE500", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_BANKNOTE500() As Long
            Get
                Return _RECEIVE_BANKNOTE500
            End Get
            Set(ByVal value As Long)
               _RECEIVE_BANKNOTE500 = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_BANKNOTE1000", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property RECEIVE_BANKNOTE1000() As Long
            Get
                Return _RECEIVE_BANKNOTE1000
            End Get
            Set(ByVal value As Long)
               _RECEIVE_BANKNOTE1000 = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_COIN1", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_COIN1() As Long
            Get
                Return _CHANGE_COIN1
            End Get
            Set(ByVal value As Long)
               _CHANGE_COIN1 = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_COIN2", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_COIN2() As Long
            Get
                Return _CHANGE_COIN2
            End Get
            Set(ByVal value As Long)
               _CHANGE_COIN2 = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_COIN5", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_COIN5() As Long
            Get
                Return _CHANGE_COIN5
            End Get
            Set(ByVal value As Long)
               _CHANGE_COIN5 = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_COIN10", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_COIN10() As Long
            Get
                Return _CHANGE_COIN10
            End Get
            Set(ByVal value As Long)
               _CHANGE_COIN10 = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_BANKNOTE20", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_BANKNOTE20() As Long
            Get
                Return _CHANGE_BANKNOTE20
            End Get
            Set(ByVal value As Long)
               _CHANGE_BANKNOTE20 = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_BANKNOTE50", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_BANKNOTE50() As Long
            Get
                Return _CHANGE_BANKNOTE50
            End Get
            Set(ByVal value As Long)
               _CHANGE_BANKNOTE50 = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_BANKNOTE100", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_BANKNOTE100() As Long
            Get
                Return _CHANGE_BANKNOTE100
            End Get
            Set(ByVal value As Long)
               _CHANGE_BANKNOTE100 = value
            End Set
        End Property 
        <Column(Storage:="_CHANGE_BANKNOTE500", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CHANGE_BANKNOTE500() As Long
            Get
                Return _CHANGE_BANKNOTE500
            End Get
            Set(ByVal value As Long)
               _CHANGE_BANKNOTE500 = value
            End Set
        End Property 
        <Column(Storage:="_TRANS_STATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property TRANS_STATUS() As Char
            Get
                Return _TRANS_STATUS
            End Get
            Set(ByVal value As Char)
               _TRANS_STATUS = value
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
            _MS_LOCKER_ID = Nothing
            _PASSPORT_NO = ""
            _IDCARD_NO = ""
            _NATION_CODE = ""
            _FIRST_NAME = ""
            _LAST_NAME = ""
            _GENDER = ""
            _BIRTH_DATE = New DateTime(1,1,1)
            _PASSPORT_EXPIRE_DATE = New DateTime(1,1,1)
            _IDCARD_EXPIRE_DATE = New DateTime(1,1,1)
             _CUST_IMAGE = Nothing
            _SERVICE_RATE = 0
            _SERVICE_RATE_LIMIT_DAY = 0
            _DEPOSIT_AMT = 0
            _PAID_TIME = New DateTime(1,1,1)
            _RECEIVE_COIN1 = 0
            _RECEIVE_COIN2 = 0
            _RECEIVE_COIN5 = 0
            _RECEIVE_COIN10 = 0
            _RECEIVE_BANKNOTE20 = 0
            _RECEIVE_BANKNOTE50 = 0
            _RECEIVE_BANKNOTE100 = 0
            _RECEIVE_BANKNOTE500 = 0
            _RECEIVE_BANKNOTE1000 = 0
            _CHANGE_COIN1 = 0
            _CHANGE_COIN2 = 0
            _CHANGE_COIN5 = 0
            _CHANGE_COIN10 = 0
            _CHANGE_BANKNOTE20 = 0
            _CHANGE_BANKNOTE50 = 0
            _CHANGE_BANKNOTE100 = 0
            _CHANGE_BANKNOTE500 = 0
            _TRANS_STATUS = "0"
            _MS_APP_SCREEN_ID = 0
            _MS_APP_STEP_ID = 0
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


        '/// Returns an indication whether the current data is inserted into TB_SERVICE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_SERVICE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_SERVICE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_SERVICE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the record of TB_SERVICE_TRANSACTION by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_SERVICE_TRANSACTION by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbServiceTransactionKioskLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of TB_SERVICE_TRANSACTION by specified TRANS_NO key is retrieved successfully.
        '/// <param name=cTRANS_NO>The TRANS_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTRANS_NO(cTRANS_NO As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TRANS_NO", cTRANS_NO) 
            Return doChkData("TRANS_NO = @_TRANS_NO", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_SERVICE_TRANSACTION by specified TRANS_NO key is retrieved successfully.
        '/// <param name=cTRANS_NO>The TRANS_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByTRANS_NO(cTRANS_NO As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TRANS_NO", cTRANS_NO) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("TRANS_NO = @_TRANS_NO And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_SERVICE_TRANSACTION by specified TRANS_START_TIME key is retrieved successfully.
        '/// <param name=cTRANS_START_TIME>The TRANS_START_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTRANS_START_TIME(cTRANS_START_TIME As DateTime, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TRANS_START_TIME", cTRANS_START_TIME) 
            Return doChkData("TRANS_START_TIME = @_TRANS_START_TIME", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_SERVICE_TRANSACTION by specified TRANS_START_TIME key is retrieved successfully.
        '/// <param name=cTRANS_START_TIME>The TRANS_START_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByTRANS_START_TIME(cTRANS_START_TIME As DateTime, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_TRANS_START_TIME", cTRANS_START_TIME) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("TRANS_START_TIME = @_TRANS_START_TIME And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_SERVICE_TRANSACTION by specified MS_LOCKER_ID key is retrieved successfully.
        '/// <param name=cMS_LOCKER_ID>The MS_LOCKER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_LOCKER_ID(cMS_LOCKER_ID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_LOCKER_ID", cMS_LOCKER_ID) 
            Return doChkData("MS_LOCKER_ID = @_MS_LOCKER_ID", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of TB_SERVICE_TRANSACTION by specified MS_LOCKER_ID key is retrieved successfully.
        '/// <param name=cMS_LOCKER_ID>The MS_LOCKER_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_LOCKER_ID(cMS_LOCKER_ID As Long, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_LOCKER_ID", cMS_LOCKER_ID) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("MS_LOCKER_ID = @_MS_LOCKER_ID And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of TB_SERVICE_TRANSACTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_SERVICE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_SERVICE_TRANSACTION table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_SERVICE_TRANSACTION table successfully.
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
            Dim cmbParam(44) As SqlParameter
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

            cmbParam(9) = New SqlParameter("@_MS_LOCKER_ID", SqlDbType.BigInt)
            If _MS_LOCKER_ID IsNot Nothing Then 
                cmbParam(9).Value = _MS_LOCKER_ID.Value
            Else
                cmbParam(9).Value = DBNull.value
            End IF

            cmbParam(10) = New SqlParameter("@_PASSPORT_NO", SqlDbType.VarChar)
            If _PASSPORT_NO.Trim <> "" Then 
                cmbParam(10).Value = _PASSPORT_NO
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_IDCARD_NO", SqlDbType.VarChar)
            If _IDCARD_NO.Trim <> "" Then 
                cmbParam(11).Value = _IDCARD_NO
            Else
                cmbParam(11).Value = DBNull.value
            End If

            cmbParam(12) = New SqlParameter("@_NATION_CODE", SqlDbType.VarChar)
            If _NATION_CODE.Trim <> "" Then 
                cmbParam(12).Value = _NATION_CODE
            Else
                cmbParam(12).Value = DBNull.value
            End If

            cmbParam(13) = New SqlParameter("@_FIRST_NAME", SqlDbType.VarChar)
            If _FIRST_NAME.Trim <> "" Then 
                cmbParam(13).Value = _FIRST_NAME
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_LAST_NAME", SqlDbType.VarChar)
            If _LAST_NAME.Trim <> "" Then 
                cmbParam(14).Value = _LAST_NAME
            Else
                cmbParam(14).Value = DBNull.value
            End If

            cmbParam(15) = New SqlParameter("@_GENDER", SqlDbType.Char)
            If _GENDER.Value <> "" Then 
                cmbParam(15).Value = _GENDER.Value
            Else
                cmbParam(15).Value = DBNull.value
            End IF

            cmbParam(16) = New SqlParameter("@_BIRTH_DATE", SqlDbType.DateTime)
            If _BIRTH_DATE.Value.Year > 1 Then 
                cmbParam(16).Value = _BIRTH_DATE.Value
            Else
                cmbParam(16).Value = DBNull.value
            End If

            cmbParam(17) = New SqlParameter("@_PASSPORT_EXPIRE_DATE", SqlDbType.DateTime)
            If _PASSPORT_EXPIRE_DATE.Value.Year > 1 Then 
                cmbParam(17).Value = _PASSPORT_EXPIRE_DATE.Value
            Else
                cmbParam(17).Value = DBNull.value
            End If

            cmbParam(18) = New SqlParameter("@_IDCARD_EXPIRE_DATE", SqlDbType.DateTime)
            If _IDCARD_EXPIRE_DATE.Value.Year > 1 Then 
                cmbParam(18).Value = _IDCARD_EXPIRE_DATE.Value
            Else
                cmbParam(18).Value = DBNull.value
            End If

            If _CUST_IMAGE IsNot Nothing Then 
                cmbParam(19) = New SqlParameter("@_CUST_IMAGE",SqlDbType.Image, _CUST_IMAGE.Length)
                cmbParam(19).Value = _CUST_IMAGE
            Else
                cmbParam(19) = New SqlParameter("@_CUST_IMAGE", SqlDbType.Image)
                cmbParam(19).Value = DBNull.value
            End If

            cmbParam(20) = New SqlParameter("@_SERVICE_RATE", SqlDbType.Float)
            cmbParam(20).Value = _SERVICE_RATE

            cmbParam(21) = New SqlParameter("@_SERVICE_RATE_LIMIT_DAY", SqlDbType.Float)
            cmbParam(21).Value = _SERVICE_RATE_LIMIT_DAY

            cmbParam(22) = New SqlParameter("@_DEPOSIT_AMT", SqlDbType.Float)
            cmbParam(22).Value = _DEPOSIT_AMT

            cmbParam(23) = New SqlParameter("@_PAID_TIME", SqlDbType.DateTime)
            If _PAID_TIME.Value.Year > 1 Then 
                cmbParam(23).Value = _PAID_TIME.Value
            Else
                cmbParam(23).Value = DBNull.value
            End If

            cmbParam(24) = New SqlParameter("@_RECEIVE_COIN1", SqlDbType.Int)
            cmbParam(24).Value = _RECEIVE_COIN1

            cmbParam(25) = New SqlParameter("@_RECEIVE_COIN2", SqlDbType.Int)
            cmbParam(25).Value = _RECEIVE_COIN2

            cmbParam(26) = New SqlParameter("@_RECEIVE_COIN5", SqlDbType.Int)
            cmbParam(26).Value = _RECEIVE_COIN5

            cmbParam(27) = New SqlParameter("@_RECEIVE_COIN10", SqlDbType.Int)
            cmbParam(27).Value = _RECEIVE_COIN10

            cmbParam(28) = New SqlParameter("@_RECEIVE_BANKNOTE20", SqlDbType.Int)
            cmbParam(28).Value = _RECEIVE_BANKNOTE20

            cmbParam(29) = New SqlParameter("@_RECEIVE_BANKNOTE50", SqlDbType.Int)
            cmbParam(29).Value = _RECEIVE_BANKNOTE50

            cmbParam(30) = New SqlParameter("@_RECEIVE_BANKNOTE100", SqlDbType.Int)
            cmbParam(30).Value = _RECEIVE_BANKNOTE100

            cmbParam(31) = New SqlParameter("@_RECEIVE_BANKNOTE500", SqlDbType.Int)
            cmbParam(31).Value = _RECEIVE_BANKNOTE500

            cmbParam(32) = New SqlParameter("@_RECEIVE_BANKNOTE1000", SqlDbType.Int)
            cmbParam(32).Value = _RECEIVE_BANKNOTE1000

            cmbParam(33) = New SqlParameter("@_CHANGE_COIN1", SqlDbType.Int)
            cmbParam(33).Value = _CHANGE_COIN1

            cmbParam(34) = New SqlParameter("@_CHANGE_COIN2", SqlDbType.Int)
            cmbParam(34).Value = _CHANGE_COIN2

            cmbParam(35) = New SqlParameter("@_CHANGE_COIN5", SqlDbType.Int)
            cmbParam(35).Value = _CHANGE_COIN5

            cmbParam(36) = New SqlParameter("@_CHANGE_COIN10", SqlDbType.Int)
            cmbParam(36).Value = _CHANGE_COIN10

            cmbParam(37) = New SqlParameter("@_CHANGE_BANKNOTE20", SqlDbType.Int)
            cmbParam(37).Value = _CHANGE_BANKNOTE20

            cmbParam(38) = New SqlParameter("@_CHANGE_BANKNOTE50", SqlDbType.Int)
            cmbParam(38).Value = _CHANGE_BANKNOTE50

            cmbParam(39) = New SqlParameter("@_CHANGE_BANKNOTE100", SqlDbType.Int)
            cmbParam(39).Value = _CHANGE_BANKNOTE100

            cmbParam(40) = New SqlParameter("@_CHANGE_BANKNOTE500", SqlDbType.Int)
            cmbParam(40).Value = _CHANGE_BANKNOTE500

            cmbParam(41) = New SqlParameter("@_TRANS_STATUS", SqlDbType.Char)
            cmbParam(41).Value = _TRANS_STATUS

            cmbParam(42) = New SqlParameter("@_MS_APP_SCREEN_ID", SqlDbType.BigInt)
            cmbParam(42).Value = _MS_APP_SCREEN_ID

            cmbParam(43) = New SqlParameter("@_MS_APP_STEP_ID", SqlDbType.BigInt)
            cmbParam(43).Value = _MS_APP_STEP_ID

            cmbParam(44) = New SqlParameter("@_SYNC_TO_SERVER", SqlDbType.Char)
            cmbParam(44).Value = _SYNC_TO_SERVER

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_SERVICE_TRANSACTION by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_locker_id")) = False Then _ms_locker_id = Convert.ToInt64(Rdr("ms_locker_id"))
                        If Convert.IsDBNull(Rdr("passport_no")) = False Then _passport_no = Rdr("passport_no").ToString()
                        If Convert.IsDBNull(Rdr("idcard_no")) = False Then _idcard_no = Rdr("idcard_no").ToString()
                        If Convert.IsDBNull(Rdr("nation_code")) = False Then _nation_code = Rdr("nation_code").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then _last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("gender")) = False Then _gender = Rdr("gender").ToString()
                        If Convert.IsDBNull(Rdr("birth_date")) = False Then _birth_date = Convert.ToDateTime(Rdr("birth_date"))
                        If Convert.IsDBNull(Rdr("passport_expire_date")) = False Then _passport_expire_date = Convert.ToDateTime(Rdr("passport_expire_date"))
                        If Convert.IsDBNull(Rdr("idcard_expire_date")) = False Then _idcard_expire_date = Convert.ToDateTime(Rdr("idcard_expire_date"))
                        If Convert.IsDBNull(Rdr("cust_image")) = False Then _cust_image = CType(Rdr("cust_image"), Byte())
                        If Convert.IsDBNull(Rdr("service_rate")) = False Then _service_rate = Convert.ToDouble(Rdr("service_rate"))
                        If Convert.IsDBNull(Rdr("service_rate_limit_day")) = False Then _service_rate_limit_day = Convert.ToDouble(Rdr("service_rate_limit_day"))
                        If Convert.IsDBNull(Rdr("deposit_amt")) = False Then _deposit_amt = Convert.ToDouble(Rdr("deposit_amt"))
                        If Convert.IsDBNull(Rdr("paid_time")) = False Then _paid_time = Convert.ToDateTime(Rdr("paid_time"))
                        If Convert.IsDBNull(Rdr("receive_coin1")) = False Then _receive_coin1 = Convert.ToInt32(Rdr("receive_coin1"))
                        If Convert.IsDBNull(Rdr("receive_coin2")) = False Then _receive_coin2 = Convert.ToInt32(Rdr("receive_coin2"))
                        If Convert.IsDBNull(Rdr("receive_coin5")) = False Then _receive_coin5 = Convert.ToInt32(Rdr("receive_coin5"))
                        If Convert.IsDBNull(Rdr("receive_coin10")) = False Then _receive_coin10 = Convert.ToInt32(Rdr("receive_coin10"))
                        If Convert.IsDBNull(Rdr("receive_banknote20")) = False Then _receive_banknote20 = Convert.ToInt32(Rdr("receive_banknote20"))
                        If Convert.IsDBNull(Rdr("receive_banknote50")) = False Then _receive_banknote50 = Convert.ToInt32(Rdr("receive_banknote50"))
                        If Convert.IsDBNull(Rdr("receive_banknote100")) = False Then _receive_banknote100 = Convert.ToInt32(Rdr("receive_banknote100"))
                        If Convert.IsDBNull(Rdr("receive_banknote500")) = False Then _receive_banknote500 = Convert.ToInt32(Rdr("receive_banknote500"))
                        If Convert.IsDBNull(Rdr("receive_banknote1000")) = False Then _receive_banknote1000 = Convert.ToInt32(Rdr("receive_banknote1000"))
                        If Convert.IsDBNull(Rdr("change_coin1")) = False Then _change_coin1 = Convert.ToInt32(Rdr("change_coin1"))
                        If Convert.IsDBNull(Rdr("change_coin2")) = False Then _change_coin2 = Convert.ToInt32(Rdr("change_coin2"))
                        If Convert.IsDBNull(Rdr("change_coin5")) = False Then _change_coin5 = Convert.ToInt32(Rdr("change_coin5"))
                        If Convert.IsDBNull(Rdr("change_coin10")) = False Then _change_coin10 = Convert.ToInt32(Rdr("change_coin10"))
                        If Convert.IsDBNull(Rdr("change_banknote20")) = False Then _change_banknote20 = Convert.ToInt32(Rdr("change_banknote20"))
                        If Convert.IsDBNull(Rdr("change_banknote50")) = False Then _change_banknote50 = Convert.ToInt32(Rdr("change_banknote50"))
                        If Convert.IsDBNull(Rdr("change_banknote100")) = False Then _change_banknote100 = Convert.ToInt32(Rdr("change_banknote100"))
                        If Convert.IsDBNull(Rdr("change_banknote500")) = False Then _change_banknote500 = Convert.ToInt32(Rdr("change_banknote500"))
                        If Convert.IsDBNull(Rdr("trans_status")) = False Then _trans_status = Rdr("trans_status").ToString()
                        If Convert.IsDBNull(Rdr("ms_app_screen_id")) = False Then _ms_app_screen_id = Convert.ToInt64(Rdr("ms_app_screen_id"))
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


        '/// Returns an indication whether the record of TB_SERVICE_TRANSACTION by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As TbServiceTransactionKioskLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_locker_id")) = False Then _ms_locker_id = Convert.ToInt64(Rdr("ms_locker_id"))
                        If Convert.IsDBNull(Rdr("passport_no")) = False Then _passport_no = Rdr("passport_no").ToString()
                        If Convert.IsDBNull(Rdr("idcard_no")) = False Then _idcard_no = Rdr("idcard_no").ToString()
                        If Convert.IsDBNull(Rdr("nation_code")) = False Then _nation_code = Rdr("nation_code").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then _last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("gender")) = False Then _gender = Rdr("gender").ToString()
                        If Convert.IsDBNull(Rdr("birth_date")) = False Then _birth_date = Convert.ToDateTime(Rdr("birth_date"))
                        If Convert.IsDBNull(Rdr("passport_expire_date")) = False Then _passport_expire_date = Convert.ToDateTime(Rdr("passport_expire_date"))
                        If Convert.IsDBNull(Rdr("idcard_expire_date")) = False Then _idcard_expire_date = Convert.ToDateTime(Rdr("idcard_expire_date"))
                        If Convert.IsDBNull(Rdr("cust_image")) = False Then _cust_image = CType(Rdr("cust_image"), Byte())
                        If Convert.IsDBNull(Rdr("service_rate")) = False Then _service_rate = Convert.ToDouble(Rdr("service_rate"))
                        If Convert.IsDBNull(Rdr("service_rate_limit_day")) = False Then _service_rate_limit_day = Convert.ToDouble(Rdr("service_rate_limit_day"))
                        If Convert.IsDBNull(Rdr("deposit_amt")) = False Then _deposit_amt = Convert.ToDouble(Rdr("deposit_amt"))
                        If Convert.IsDBNull(Rdr("paid_time")) = False Then _paid_time = Convert.ToDateTime(Rdr("paid_time"))
                        If Convert.IsDBNull(Rdr("receive_coin1")) = False Then _receive_coin1 = Convert.ToInt32(Rdr("receive_coin1"))
                        If Convert.IsDBNull(Rdr("receive_coin2")) = False Then _receive_coin2 = Convert.ToInt32(Rdr("receive_coin2"))
                        If Convert.IsDBNull(Rdr("receive_coin5")) = False Then _receive_coin5 = Convert.ToInt32(Rdr("receive_coin5"))
                        If Convert.IsDBNull(Rdr("receive_coin10")) = False Then _receive_coin10 = Convert.ToInt32(Rdr("receive_coin10"))
                        If Convert.IsDBNull(Rdr("receive_banknote20")) = False Then _receive_banknote20 = Convert.ToInt32(Rdr("receive_banknote20"))
                        If Convert.IsDBNull(Rdr("receive_banknote50")) = False Then _receive_banknote50 = Convert.ToInt32(Rdr("receive_banknote50"))
                        If Convert.IsDBNull(Rdr("receive_banknote100")) = False Then _receive_banknote100 = Convert.ToInt32(Rdr("receive_banknote100"))
                        If Convert.IsDBNull(Rdr("receive_banknote500")) = False Then _receive_banknote500 = Convert.ToInt32(Rdr("receive_banknote500"))
                        If Convert.IsDBNull(Rdr("receive_banknote1000")) = False Then _receive_banknote1000 = Convert.ToInt32(Rdr("receive_banknote1000"))
                        If Convert.IsDBNull(Rdr("change_coin1")) = False Then _change_coin1 = Convert.ToInt32(Rdr("change_coin1"))
                        If Convert.IsDBNull(Rdr("change_coin2")) = False Then _change_coin2 = Convert.ToInt32(Rdr("change_coin2"))
                        If Convert.IsDBNull(Rdr("change_coin5")) = False Then _change_coin5 = Convert.ToInt32(Rdr("change_coin5"))
                        If Convert.IsDBNull(Rdr("change_coin10")) = False Then _change_coin10 = Convert.ToInt32(Rdr("change_coin10"))
                        If Convert.IsDBNull(Rdr("change_banknote20")) = False Then _change_banknote20 = Convert.ToInt32(Rdr("change_banknote20"))
                        If Convert.IsDBNull(Rdr("change_banknote50")) = False Then _change_banknote50 = Convert.ToInt32(Rdr("change_banknote50"))
                        If Convert.IsDBNull(Rdr("change_banknote100")) = False Then _change_banknote100 = Convert.ToInt32(Rdr("change_banknote100"))
                        If Convert.IsDBNull(Rdr("change_banknote500")) = False Then _change_banknote500 = Convert.ToInt32(Rdr("change_banknote500"))
                        If Convert.IsDBNull(Rdr("trans_status")) = False Then _trans_status = Rdr("trans_status").ToString()
                        If Convert.IsDBNull(Rdr("ms_app_screen_id")) = False Then _ms_app_screen_id = Convert.ToInt64(Rdr("ms_app_screen_id"))
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


        'Get Insert Statement for table TB_SERVICE_TRANSACTION
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, TRANS_NO, TRANS_START_TIME, TRANS_END_TIME, MS_KIOSK_ID, MS_LOCKER_ID, PASSPORT_NO, IDCARD_NO, NATION_CODE, FIRST_NAME, LAST_NAME, GENDER, BIRTH_DATE, PASSPORT_EXPIRE_DATE, IDCARD_EXPIRE_DATE, CUST_IMAGE, SERVICE_RATE, SERVICE_RATE_LIMIT_DAY, DEPOSIT_AMT, PAID_TIME, RECEIVE_COIN1, RECEIVE_COIN2, RECEIVE_COIN5, RECEIVE_COIN10, RECEIVE_BANKNOTE20, RECEIVE_BANKNOTE50, RECEIVE_BANKNOTE100, RECEIVE_BANKNOTE500, RECEIVE_BANKNOTE1000, CHANGE_COIN1, CHANGE_COIN2, CHANGE_COIN5, CHANGE_COIN10, CHANGE_BANKNOTE20, CHANGE_BANKNOTE50, CHANGE_BANKNOTE100, CHANGE_BANKNOTE500, TRANS_STATUS, MS_APP_SCREEN_ID, MS_APP_STEP_ID, SYNC_TO_SERVER)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.TRANS_NO, INSERTED.TRANS_START_TIME, INSERTED.TRANS_END_TIME, INSERTED.MS_KIOSK_ID, INSERTED.MS_LOCKER_ID, INSERTED.PASSPORT_NO, INSERTED.IDCARD_NO, INSERTED.NATION_CODE, INSERTED.FIRST_NAME, INSERTED.LAST_NAME, INSERTED.GENDER, INSERTED.BIRTH_DATE, INSERTED.PASSPORT_EXPIRE_DATE, INSERTED.IDCARD_EXPIRE_DATE, INSERTED.CUST_IMAGE, INSERTED.SERVICE_RATE, INSERTED.SERVICE_RATE_LIMIT_DAY, INSERTED.DEPOSIT_AMT, INSERTED.PAID_TIME, INSERTED.RECEIVE_COIN1, INSERTED.RECEIVE_COIN2, INSERTED.RECEIVE_COIN5, INSERTED.RECEIVE_COIN10, INSERTED.RECEIVE_BANKNOTE20, INSERTED.RECEIVE_BANKNOTE50, INSERTED.RECEIVE_BANKNOTE100, INSERTED.RECEIVE_BANKNOTE500, INSERTED.RECEIVE_BANKNOTE1000, INSERTED.CHANGE_COIN1, INSERTED.CHANGE_COIN2, INSERTED.CHANGE_COIN5, INSERTED.CHANGE_COIN10, INSERTED.CHANGE_BANKNOTE20, INSERTED.CHANGE_BANKNOTE50, INSERTED.CHANGE_BANKNOTE100, INSERTED.CHANGE_BANKNOTE500, INSERTED.TRANS_STATUS, INSERTED.MS_APP_SCREEN_ID, INSERTED.MS_APP_STEP_ID, INSERTED.SYNC_TO_SERVER"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_TRANS_NO" & ", "
                sql += "@_TRANS_START_TIME" & ", "
                sql += "@_TRANS_END_TIME" & ", "
                sql += "@_MS_KIOSK_ID" & ", "
                sql += "@_MS_LOCKER_ID" & ", "
                sql += "@_PASSPORT_NO" & ", "
                sql += "@_IDCARD_NO" & ", "
                sql += "@_NATION_CODE" & ", "
                sql += "@_FIRST_NAME" & ", "
                sql += "@_LAST_NAME" & ", "
                sql += "@_GENDER" & ", "
                sql += "@_BIRTH_DATE" & ", "
                sql += "@_PASSPORT_EXPIRE_DATE" & ", "
                sql += "@_IDCARD_EXPIRE_DATE" & ", "
                sql += "@_CUST_IMAGE" & ", "
                sql += "@_SERVICE_RATE" & ", "
                sql += "@_SERVICE_RATE_LIMIT_DAY" & ", "
                sql += "@_DEPOSIT_AMT" & ", "
                sql += "@_PAID_TIME" & ", "
                sql += "@_RECEIVE_COIN1" & ", "
                sql += "@_RECEIVE_COIN2" & ", "
                sql += "@_RECEIVE_COIN5" & ", "
                sql += "@_RECEIVE_COIN10" & ", "
                sql += "@_RECEIVE_BANKNOTE20" & ", "
                sql += "@_RECEIVE_BANKNOTE50" & ", "
                sql += "@_RECEIVE_BANKNOTE100" & ", "
                sql += "@_RECEIVE_BANKNOTE500" & ", "
                sql += "@_RECEIVE_BANKNOTE1000" & ", "
                sql += "@_CHANGE_COIN1" & ", "
                sql += "@_CHANGE_COIN2" & ", "
                sql += "@_CHANGE_COIN5" & ", "
                sql += "@_CHANGE_COIN10" & ", "
                sql += "@_CHANGE_BANKNOTE20" & ", "
                sql += "@_CHANGE_BANKNOTE50" & ", "
                sql += "@_CHANGE_BANKNOTE100" & ", "
                sql += "@_CHANGE_BANKNOTE500" & ", "
                sql += "@_TRANS_STATUS" & ", "
                sql += "@_MS_APP_SCREEN_ID" & ", "
                sql += "@_MS_APP_STEP_ID" & ", "
                sql += "@_SYNC_TO_SERVER"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_SERVICE_TRANSACTION
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
                Sql += "MS_LOCKER_ID = " & "@_MS_LOCKER_ID" & ", "
                Sql += "PASSPORT_NO = " & "@_PASSPORT_NO" & ", "
                Sql += "IDCARD_NO = " & "@_IDCARD_NO" & ", "
                Sql += "NATION_CODE = " & "@_NATION_CODE" & ", "
                Sql += "FIRST_NAME = " & "@_FIRST_NAME" & ", "
                Sql += "LAST_NAME = " & "@_LAST_NAME" & ", "
                Sql += "GENDER = " & "@_GENDER" & ", "
                Sql += "BIRTH_DATE = " & "@_BIRTH_DATE" & ", "
                Sql += "PASSPORT_EXPIRE_DATE = " & "@_PASSPORT_EXPIRE_DATE" & ", "
                Sql += "IDCARD_EXPIRE_DATE = " & "@_IDCARD_EXPIRE_DATE" & ", "
                Sql += "CUST_IMAGE = " & "@_CUST_IMAGE" & ", "
                Sql += "SERVICE_RATE = " & "@_SERVICE_RATE" & ", "
                Sql += "SERVICE_RATE_LIMIT_DAY = " & "@_SERVICE_RATE_LIMIT_DAY" & ", "
                Sql += "DEPOSIT_AMT = " & "@_DEPOSIT_AMT" & ", "
                Sql += "PAID_TIME = " & "@_PAID_TIME" & ", "
                Sql += "RECEIVE_COIN1 = " & "@_RECEIVE_COIN1" & ", "
                Sql += "RECEIVE_COIN2 = " & "@_RECEIVE_COIN2" & ", "
                Sql += "RECEIVE_COIN5 = " & "@_RECEIVE_COIN5" & ", "
                Sql += "RECEIVE_COIN10 = " & "@_RECEIVE_COIN10" & ", "
                Sql += "RECEIVE_BANKNOTE20 = " & "@_RECEIVE_BANKNOTE20" & ", "
                Sql += "RECEIVE_BANKNOTE50 = " & "@_RECEIVE_BANKNOTE50" & ", "
                Sql += "RECEIVE_BANKNOTE100 = " & "@_RECEIVE_BANKNOTE100" & ", "
                Sql += "RECEIVE_BANKNOTE500 = " & "@_RECEIVE_BANKNOTE500" & ", "
                Sql += "RECEIVE_BANKNOTE1000 = " & "@_RECEIVE_BANKNOTE1000" & ", "
                Sql += "CHANGE_COIN1 = " & "@_CHANGE_COIN1" & ", "
                Sql += "CHANGE_COIN2 = " & "@_CHANGE_COIN2" & ", "
                Sql += "CHANGE_COIN5 = " & "@_CHANGE_COIN5" & ", "
                Sql += "CHANGE_COIN10 = " & "@_CHANGE_COIN10" & ", "
                Sql += "CHANGE_BANKNOTE20 = " & "@_CHANGE_BANKNOTE20" & ", "
                Sql += "CHANGE_BANKNOTE50 = " & "@_CHANGE_BANKNOTE50" & ", "
                Sql += "CHANGE_BANKNOTE100 = " & "@_CHANGE_BANKNOTE100" & ", "
                Sql += "CHANGE_BANKNOTE500 = " & "@_CHANGE_BANKNOTE500" & ", "
                Sql += "TRANS_STATUS = " & "@_TRANS_STATUS" & ", "
                Sql += "MS_APP_SCREEN_ID = " & "@_MS_APP_SCREEN_ID" & ", "
                Sql += "MS_APP_STEP_ID = " & "@_MS_APP_STEP_ID" & ", "
                Sql += "SYNC_TO_SERVER = " & "@_SYNC_TO_SERVER" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_SERVICE_TRANSACTION
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_SERVICE_TRANSACTION
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, TRANS_NO, TRANS_START_TIME, TRANS_END_TIME, MS_KIOSK_ID, MS_LOCKER_ID, PASSPORT_NO, IDCARD_NO, NATION_CODE, FIRST_NAME, LAST_NAME, GENDER, BIRTH_DATE, PASSPORT_EXPIRE_DATE, IDCARD_EXPIRE_DATE, CUST_IMAGE, SERVICE_RATE, SERVICE_RATE_LIMIT_DAY, DEPOSIT_AMT, PAID_TIME, RECEIVE_COIN1, RECEIVE_COIN2, RECEIVE_COIN5, RECEIVE_COIN10, RECEIVE_BANKNOTE20, RECEIVE_BANKNOTE50, RECEIVE_BANKNOTE100, RECEIVE_BANKNOTE500, RECEIVE_BANKNOTE1000, CHANGE_COIN1, CHANGE_COIN2, CHANGE_COIN5, CHANGE_COIN10, CHANGE_BANKNOTE20, CHANGE_BANKNOTE50, CHANGE_BANKNOTE100, CHANGE_BANKNOTE500, TRANS_STATUS, MS_APP_SCREEN_ID, MS_APP_STEP_ID, SYNC_TO_SERVER FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
