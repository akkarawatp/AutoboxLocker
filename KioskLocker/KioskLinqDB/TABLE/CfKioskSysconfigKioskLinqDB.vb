Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = KioskLinqDB.ConnectDB.KioskDB
Imports KioskLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for CF_KIOSK_SYSCONFIG table KioskLinqDB.
    '[Create by  on November, 17 2017]
    Public Class CfKioskSysconfigKioskLinqDB
        Public sub CfKioskSysconfigKioskLinqDB()

        End Sub 
        ' CF_KIOSK_SYSCONFIG
        Const _tableName As String = "CF_KIOSK_SYSCONFIG"

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
        Dim _MAC_ADDRESS As String = ""
        Dim _IP_ADDRESS As String = ""
        Dim _LOCATION_CODE As String = ""
        Dim _LOCATION_NAME As String = ""
        Dim _LOGIN_SSO As Char = ""
        Dim _KIOSK_OPEN_TIME As String = ""
        Dim _KIOSK_OPEN24 As Char = "N"
        Dim _SCREEN_SAVER_SEC As Long = 0
        Dim _TIME_OUT_SEC As Long = 0
        Dim _SHOW_MSG_SEC As Long = 0
        Dim _PAYMENT_EXTEND_SEC As Long = 0
        Dim _CARD_EXPIRE_MONTH As Long = 0
        Dim _PASSPORT_EXPIRE_MONTH As Long = 0
        Dim _LOCKER_WEBSERVICE_URL As String = ""
        Dim _LOCKER_PC_POSITION As Long = 0
        Dim _SLEEP_TIME As String = ""
        Dim _SLEEP_DURATION As Long = 0
        Dim _CONTACT_CENTER_TELNO As String = ""
        Dim _ALARM_WEBSERVICE_URL As  String  = ""
        Dim _INTERVAL_SYNC_TRANSACTION_MIN As Long = 0
        Dim _INTERVAL_SYNC_MASTER_MIN As Long = 0
        Dim _INTERVAL_SYNC_LOG_MIN As Long = 0
        Dim _SYNC_TO_KIOSK As Char = "N"
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
        <Column(Storage:="_MAC_ADDRESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MAC_ADDRESS() As String
            Get
                Return _MAC_ADDRESS
            End Get
            Set(ByVal value As String)
               _MAC_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property IP_ADDRESS() As String
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As String)
               _IP_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_LOCATION_CODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCATION_CODE() As String
            Get
                Return _LOCATION_CODE
            End Get
            Set(ByVal value As String)
               _LOCATION_CODE = value
            End Set
        End Property 
        <Column(Storage:="_LOCATION_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCATION_NAME() As String
            Get
                Return _LOCATION_NAME
            End Get
            Set(ByVal value As String)
               _LOCATION_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_SSO", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOGIN_SSO() As Char
            Get
                Return _LOGIN_SSO
            End Get
            Set(ByVal value As Char)
               _LOGIN_SSO = value
            End Set
        End Property 
        <Column(Storage:="_KIOSK_OPEN_TIME", DbType:="VarChar(20) NOT NULL ",CanBeNull:=false)>  _
        Public Property KIOSK_OPEN_TIME() As String
            Get
                Return _KIOSK_OPEN_TIME
            End Get
            Set(ByVal value As String)
               _KIOSK_OPEN_TIME = value
            End Set
        End Property 
        <Column(Storage:="_KIOSK_OPEN24", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property KIOSK_OPEN24() As Char
            Get
                Return _KIOSK_OPEN24
            End Get
            Set(ByVal value As Char)
               _KIOSK_OPEN24 = value
            End Set
        End Property 
        <Column(Storage:="_SCREEN_SAVER_SEC", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SCREEN_SAVER_SEC() As Long
            Get
                Return _SCREEN_SAVER_SEC
            End Get
            Set(ByVal value As Long)
               _SCREEN_SAVER_SEC = value
            End Set
        End Property 
        <Column(Storage:="_TIME_OUT_SEC", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property TIME_OUT_SEC() As Long
            Get
                Return _TIME_OUT_SEC
            End Get
            Set(ByVal value As Long)
               _TIME_OUT_SEC = value
            End Set
        End Property 
        <Column(Storage:="_SHOW_MSG_SEC", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SHOW_MSG_SEC() As Long
            Get
                Return _SHOW_MSG_SEC
            End Get
            Set(ByVal value As Long)
               _SHOW_MSG_SEC = value
            End Set
        End Property 
        <Column(Storage:="_PAYMENT_EXTEND_SEC", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property PAYMENT_EXTEND_SEC() As Long
            Get
                Return _PAYMENT_EXTEND_SEC
            End Get
            Set(ByVal value As Long)
               _PAYMENT_EXTEND_SEC = value
            End Set
        End Property 
        <Column(Storage:="_CARD_EXPIRE_MONTH", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property CARD_EXPIRE_MONTH() As Long
            Get
                Return _CARD_EXPIRE_MONTH
            End Get
            Set(ByVal value As Long)
               _CARD_EXPIRE_MONTH = value
            End Set
        End Property 
        <Column(Storage:="_PASSPORT_EXPIRE_MONTH", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property PASSPORT_EXPIRE_MONTH() As Long
            Get
                Return _PASSPORT_EXPIRE_MONTH
            End Get
            Set(ByVal value As Long)
               _PASSPORT_EXPIRE_MONTH = value
            End Set
        End Property 
        <Column(Storage:="_LOCKER_WEBSERVICE_URL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCKER_WEBSERVICE_URL() As String
            Get
                Return _LOCKER_WEBSERVICE_URL
            End Get
            Set(ByVal value As String)
               _LOCKER_WEBSERVICE_URL = value
            End Set
        End Property 
        <Column(Storage:="_LOCKER_PC_POSITION", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property LOCKER_PC_POSITION() As Long
            Get
                Return _LOCKER_PC_POSITION
            End Get
            Set(ByVal value As Long)
               _LOCKER_PC_POSITION = value
            End Set
        End Property 
        <Column(Storage:="_SLEEP_TIME", DbType:="VarChar(5) NOT NULL ",CanBeNull:=false)>  _
        Public Property SLEEP_TIME() As String
            Get
                Return _SLEEP_TIME
            End Get
            Set(ByVal value As String)
               _SLEEP_TIME = value
            End Set
        End Property 
        <Column(Storage:="_SLEEP_DURATION", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property SLEEP_DURATION() As Long
            Get
                Return _SLEEP_DURATION
            End Get
            Set(ByVal value As Long)
               _SLEEP_DURATION = value
            End Set
        End Property 
        <Column(Storage:="_CONTACT_CENTER_TELNO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CONTACT_CENTER_TELNO() As String
            Get
                Return _CONTACT_CENTER_TELNO
            End Get
            Set(ByVal value As String)
               _CONTACT_CENTER_TELNO = value
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
        <Column(Storage:="_INTERVAL_SYNC_TRANSACTION_MIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property INTERVAL_SYNC_TRANSACTION_MIN() As Long
            Get
                Return _INTERVAL_SYNC_TRANSACTION_MIN
            End Get
            Set(ByVal value As Long)
               _INTERVAL_SYNC_TRANSACTION_MIN = value
            End Set
        End Property 
        <Column(Storage:="_INTERVAL_SYNC_MASTER_MIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property INTERVAL_SYNC_MASTER_MIN() As Long
            Get
                Return _INTERVAL_SYNC_MASTER_MIN
            End Get
            Set(ByVal value As Long)
               _INTERVAL_SYNC_MASTER_MIN = value
            End Set
        End Property 
        <Column(Storage:="_INTERVAL_SYNC_LOG_MIN", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property INTERVAL_SYNC_LOG_MIN() As Long
            Get
                Return _INTERVAL_SYNC_LOG_MIN
            End Get
            Set(ByVal value As Long)
               _INTERVAL_SYNC_LOG_MIN = value
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


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_KIOSK_ID = 0
            _MAC_ADDRESS = ""
            _IP_ADDRESS = ""
            _LOCATION_CODE = ""
            _LOCATION_NAME = ""
            _LOGIN_SSO = ""
            _KIOSK_OPEN_TIME = ""
            _KIOSK_OPEN24 = "N"
            _SCREEN_SAVER_SEC = 0
            _TIME_OUT_SEC = 0
            _SHOW_MSG_SEC = 0
            _PAYMENT_EXTEND_SEC = 0
            _CARD_EXPIRE_MONTH = 0
            _PASSPORT_EXPIRE_MONTH = 0
            _LOCKER_WEBSERVICE_URL = ""
            _LOCKER_PC_POSITION = 7
            _SLEEP_TIME = ""
            _SLEEP_DURATION = 0
            _CONTACT_CENTER_TELNO = ""
            _ALARM_WEBSERVICE_URL = ""
            _INTERVAL_SYNC_TRANSACTION_MIN = 1
            _INTERVAL_SYNC_MASTER_MIN = 10
            _INTERVAL_SYNC_LOG_MIN = 1
            _SYNC_TO_KIOSK = "N"
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


        '/// Returns an indication whether the current data is inserted into CF_KIOSK_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_KIOSK_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_KIOSK_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is deleted from CF_KIOSK_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the record of CF_KIOSK_SYSCONFIG by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of CF_KIOSK_SYSCONFIG by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As CfKioskSysconfigKioskLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of CF_KIOSK_SYSCONFIG by specified MS_KIOSK_ID key is retrieved successfully.
        '/// <param name=cMS_KIOSK_ID>The MS_KIOSK_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_KIOSK_ID(cMS_KIOSK_ID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_KIOSK_ID", cMS_KIOSK_ID) 
            Return doChkData("MS_KIOSK_ID = @_MS_KIOSK_ID", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of CF_KIOSK_SYSCONFIG by specified MS_KIOSK_ID key is retrieved successfully.
        '/// <param name=cMS_KIOSK_ID>The MS_KIOSK_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_KIOSK_ID(cMS_KIOSK_ID As Long, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MS_KIOSK_ID", cMS_KIOSK_ID) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("MS_KIOSK_ID = @_MS_KIOSK_ID And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of CF_KIOSK_SYSCONFIG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into CF_KIOSK_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is updated to CF_KIOSK_SYSCONFIG table successfully.
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


        '/// Returns an indication whether the current data is deleted from CF_KIOSK_SYSCONFIG table successfully.
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
            Dim cmbParam(29) As SqlParameter
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

            cmbParam(6) = New SqlParameter("@_MAC_ADDRESS", SqlDbType.VarChar)
            cmbParam(6).Value = _MAC_ADDRESS

            cmbParam(7) = New SqlParameter("@_IP_ADDRESS", SqlDbType.VarChar)
            cmbParam(7).Value = _IP_ADDRESS

            cmbParam(8) = New SqlParameter("@_LOCATION_CODE", SqlDbType.VarChar)
            cmbParam(8).Value = _LOCATION_CODE

            cmbParam(9) = New SqlParameter("@_LOCATION_NAME", SqlDbType.VarChar)
            cmbParam(9).Value = _LOCATION_NAME

            cmbParam(10) = New SqlParameter("@_LOGIN_SSO", SqlDbType.Char)
            cmbParam(10).Value = _LOGIN_SSO

            cmbParam(11) = New SqlParameter("@_KIOSK_OPEN_TIME", SqlDbType.VarChar)
            cmbParam(11).Value = _KIOSK_OPEN_TIME

            cmbParam(12) = New SqlParameter("@_KIOSK_OPEN24", SqlDbType.Char)
            cmbParam(12).Value = _KIOSK_OPEN24

            cmbParam(13) = New SqlParameter("@_SCREEN_SAVER_SEC", SqlDbType.Int)
            cmbParam(13).Value = _SCREEN_SAVER_SEC

            cmbParam(14) = New SqlParameter("@_TIME_OUT_SEC", SqlDbType.Int)
            cmbParam(14).Value = _TIME_OUT_SEC

            cmbParam(15) = New SqlParameter("@_SHOW_MSG_SEC", SqlDbType.Int)
            cmbParam(15).Value = _SHOW_MSG_SEC

            cmbParam(16) = New SqlParameter("@_PAYMENT_EXTEND_SEC", SqlDbType.Int)
            cmbParam(16).Value = _PAYMENT_EXTEND_SEC

            cmbParam(17) = New SqlParameter("@_CARD_EXPIRE_MONTH", SqlDbType.Int)
            cmbParam(17).Value = _CARD_EXPIRE_MONTH

            cmbParam(18) = New SqlParameter("@_PASSPORT_EXPIRE_MONTH", SqlDbType.Int)
            cmbParam(18).Value = _PASSPORT_EXPIRE_MONTH

            cmbParam(19) = New SqlParameter("@_LOCKER_WEBSERVICE_URL", SqlDbType.VarChar)
            cmbParam(19).Value = _LOCKER_WEBSERVICE_URL

            cmbParam(20) = New SqlParameter("@_LOCKER_PC_POSITION", SqlDbType.Int)
            cmbParam(20).Value = _LOCKER_PC_POSITION

            cmbParam(21) = New SqlParameter("@_SLEEP_TIME", SqlDbType.VarChar)
            cmbParam(21).Value = _SLEEP_TIME

            cmbParam(22) = New SqlParameter("@_SLEEP_DURATION", SqlDbType.Int)
            cmbParam(22).Value = _SLEEP_DURATION

            cmbParam(23) = New SqlParameter("@_CONTACT_CENTER_TELNO", SqlDbType.VarChar)
            cmbParam(23).Value = _CONTACT_CENTER_TELNO

            cmbParam(24) = New SqlParameter("@_ALARM_WEBSERVICE_URL", SqlDbType.VarChar)
            If _ALARM_WEBSERVICE_URL.Trim <> "" Then 
                cmbParam(24).Value = _ALARM_WEBSERVICE_URL
            Else
                cmbParam(24).Value = DBNull.value
            End If

            cmbParam(25) = New SqlParameter("@_INTERVAL_SYNC_TRANSACTION_MIN", SqlDbType.Int)
            cmbParam(25).Value = _INTERVAL_SYNC_TRANSACTION_MIN

            cmbParam(26) = New SqlParameter("@_INTERVAL_SYNC_MASTER_MIN", SqlDbType.Int)
            cmbParam(26).Value = _INTERVAL_SYNC_MASTER_MIN

            cmbParam(27) = New SqlParameter("@_INTERVAL_SYNC_LOG_MIN", SqlDbType.Int)
            cmbParam(27).Value = _INTERVAL_SYNC_LOG_MIN

            cmbParam(28) = New SqlParameter("@_SYNC_TO_KIOSK", SqlDbType.Char)
            cmbParam(28).Value = _SYNC_TO_KIOSK

            cmbParam(29) = New SqlParameter("@_SYNC_TO_SERVER", SqlDbType.Char)
            cmbParam(29).Value = _SYNC_TO_SERVER

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of CF_KIOSK_SYSCONFIG by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("mac_address")) = False Then _mac_address = Rdr("mac_address").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("location_code")) = False Then _location_code = Rdr("location_code").ToString()
                        If Convert.IsDBNull(Rdr("location_name")) = False Then _location_name = Rdr("location_name").ToString()
                        If Convert.IsDBNull(Rdr("login_sso")) = False Then _login_sso = Rdr("login_sso").ToString()
                        If Convert.IsDBNull(Rdr("kiosk_open_time")) = False Then _kiosk_open_time = Rdr("kiosk_open_time").ToString()
                        If Convert.IsDBNull(Rdr("kiosk_open24")) = False Then _kiosk_open24 = Rdr("kiosk_open24").ToString()
                        If Convert.IsDBNull(Rdr("screen_saver_sec")) = False Then _screen_saver_sec = Convert.ToInt32(Rdr("screen_saver_sec"))
                        If Convert.IsDBNull(Rdr("time_out_sec")) = False Then _time_out_sec = Convert.ToInt32(Rdr("time_out_sec"))
                        If Convert.IsDBNull(Rdr("show_msg_sec")) = False Then _show_msg_sec = Convert.ToInt32(Rdr("show_msg_sec"))
                        If Convert.IsDBNull(Rdr("payment_extend_sec")) = False Then _payment_extend_sec = Convert.ToInt32(Rdr("payment_extend_sec"))
                        If Convert.IsDBNull(Rdr("card_expire_month")) = False Then _card_expire_month = Convert.ToInt32(Rdr("card_expire_month"))
                        If Convert.IsDBNull(Rdr("passport_expire_month")) = False Then _passport_expire_month = Convert.ToInt32(Rdr("passport_expire_month"))
                        If Convert.IsDBNull(Rdr("locker_webservice_url")) = False Then _locker_webservice_url = Rdr("locker_webservice_url").ToString()
                        If Convert.IsDBNull(Rdr("locker_pc_position")) = False Then _locker_pc_position = Convert.ToInt32(Rdr("locker_pc_position"))
                        If Convert.IsDBNull(Rdr("sleep_time")) = False Then _sleep_time = Rdr("sleep_time").ToString()
                        If Convert.IsDBNull(Rdr("sleep_duration")) = False Then _sleep_duration = Convert.ToInt32(Rdr("sleep_duration"))
                        If Convert.IsDBNull(Rdr("contact_center_telno")) = False Then _contact_center_telno = Rdr("contact_center_telno").ToString()
                        If Convert.IsDBNull(Rdr("alarm_webservice_url")) = False Then _alarm_webservice_url = Rdr("alarm_webservice_url").ToString()
                        If Convert.IsDBNull(Rdr("interval_sync_transaction_min")) = False Then _interval_sync_transaction_min = Convert.ToInt32(Rdr("interval_sync_transaction_min"))
                        If Convert.IsDBNull(Rdr("interval_sync_master_min")) = False Then _interval_sync_master_min = Convert.ToInt32(Rdr("interval_sync_master_min"))
                        If Convert.IsDBNull(Rdr("interval_sync_log_min")) = False Then _interval_sync_log_min = Convert.ToInt32(Rdr("interval_sync_log_min"))
                        If Convert.IsDBNull(Rdr("sync_to_kiosk")) = False Then _sync_to_kiosk = Rdr("sync_to_kiosk").ToString()
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


        '/// Returns an indication whether the record of CF_KIOSK_SYSCONFIG by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As CfKioskSysconfigKioskLinqDB
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
                        If Convert.IsDBNull(Rdr("mac_address")) = False Then _mac_address = Rdr("mac_address").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("location_code")) = False Then _location_code = Rdr("location_code").ToString()
                        If Convert.IsDBNull(Rdr("location_name")) = False Then _location_name = Rdr("location_name").ToString()
                        If Convert.IsDBNull(Rdr("login_sso")) = False Then _login_sso = Rdr("login_sso").ToString()
                        If Convert.IsDBNull(Rdr("kiosk_open_time")) = False Then _kiosk_open_time = Rdr("kiosk_open_time").ToString()
                        If Convert.IsDBNull(Rdr("kiosk_open24")) = False Then _kiosk_open24 = Rdr("kiosk_open24").ToString()
                        If Convert.IsDBNull(Rdr("screen_saver_sec")) = False Then _screen_saver_sec = Convert.ToInt32(Rdr("screen_saver_sec"))
                        If Convert.IsDBNull(Rdr("time_out_sec")) = False Then _time_out_sec = Convert.ToInt32(Rdr("time_out_sec"))
                        If Convert.IsDBNull(Rdr("show_msg_sec")) = False Then _show_msg_sec = Convert.ToInt32(Rdr("show_msg_sec"))
                        If Convert.IsDBNull(Rdr("payment_extend_sec")) = False Then _payment_extend_sec = Convert.ToInt32(Rdr("payment_extend_sec"))
                        If Convert.IsDBNull(Rdr("card_expire_month")) = False Then _card_expire_month = Convert.ToInt32(Rdr("card_expire_month"))
                        If Convert.IsDBNull(Rdr("passport_expire_month")) = False Then _passport_expire_month = Convert.ToInt32(Rdr("passport_expire_month"))
                        If Convert.IsDBNull(Rdr("locker_webservice_url")) = False Then _locker_webservice_url = Rdr("locker_webservice_url").ToString()
                        If Convert.IsDBNull(Rdr("locker_pc_position")) = False Then _locker_pc_position = Convert.ToInt32(Rdr("locker_pc_position"))
                        If Convert.IsDBNull(Rdr("sleep_time")) = False Then _sleep_time = Rdr("sleep_time").ToString()
                        If Convert.IsDBNull(Rdr("sleep_duration")) = False Then _sleep_duration = Convert.ToInt32(Rdr("sleep_duration"))
                        If Convert.IsDBNull(Rdr("contact_center_telno")) = False Then _contact_center_telno = Rdr("contact_center_telno").ToString()
                        If Convert.IsDBNull(Rdr("alarm_webservice_url")) = False Then _alarm_webservice_url = Rdr("alarm_webservice_url").ToString()
                        If Convert.IsDBNull(Rdr("interval_sync_transaction_min")) = False Then _interval_sync_transaction_min = Convert.ToInt32(Rdr("interval_sync_transaction_min"))
                        If Convert.IsDBNull(Rdr("interval_sync_master_min")) = False Then _interval_sync_master_min = Convert.ToInt32(Rdr("interval_sync_master_min"))
                        If Convert.IsDBNull(Rdr("interval_sync_log_min")) = False Then _interval_sync_log_min = Convert.ToInt32(Rdr("interval_sync_log_min"))
                        If Convert.IsDBNull(Rdr("sync_to_kiosk")) = False Then _sync_to_kiosk = Rdr("sync_to_kiosk").ToString()
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


        'Get Insert Statement for table CF_KIOSK_SYSCONFIG
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, MS_KIOSK_ID, MAC_ADDRESS, IP_ADDRESS, LOCATION_CODE, LOCATION_NAME, LOGIN_SSO, KIOSK_OPEN_TIME, KIOSK_OPEN24, SCREEN_SAVER_SEC, TIME_OUT_SEC, SHOW_MSG_SEC, PAYMENT_EXTEND_SEC, CARD_EXPIRE_MONTH, PASSPORT_EXPIRE_MONTH, LOCKER_WEBSERVICE_URL, LOCKER_PC_POSITION, SLEEP_TIME, SLEEP_DURATION, CONTACT_CENTER_TELNO, ALARM_WEBSERVICE_URL, INTERVAL_SYNC_TRANSACTION_MIN, INTERVAL_SYNC_MASTER_MIN, INTERVAL_SYNC_LOG_MIN, SYNC_TO_KIOSK, SYNC_TO_SERVER)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_KIOSK_ID, INSERTED.MAC_ADDRESS, INSERTED.IP_ADDRESS, INSERTED.LOCATION_CODE, INSERTED.LOCATION_NAME, INSERTED.LOGIN_SSO, INSERTED.KIOSK_OPEN_TIME, INSERTED.KIOSK_OPEN24, INSERTED.SCREEN_SAVER_SEC, INSERTED.TIME_OUT_SEC, INSERTED.SHOW_MSG_SEC, INSERTED.PAYMENT_EXTEND_SEC, INSERTED.CARD_EXPIRE_MONTH, INSERTED.PASSPORT_EXPIRE_MONTH, INSERTED.LOCKER_WEBSERVICE_URL, INSERTED.LOCKER_PC_POSITION, INSERTED.SLEEP_TIME, INSERTED.SLEEP_DURATION, INSERTED.CONTACT_CENTER_TELNO, INSERTED.ALARM_WEBSERVICE_URL, INSERTED.INTERVAL_SYNC_TRANSACTION_MIN, INSERTED.INTERVAL_SYNC_MASTER_MIN, INSERTED.INTERVAL_SYNC_LOG_MIN, INSERTED.SYNC_TO_KIOSK, INSERTED.SYNC_TO_SERVER"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MS_KIOSK_ID" & ", "
                sql += "@_MAC_ADDRESS" & ", "
                sql += "@_IP_ADDRESS" & ", "
                sql += "@_LOCATION_CODE" & ", "
                sql += "@_LOCATION_NAME" & ", "
                sql += "@_LOGIN_SSO" & ", "
                sql += "@_KIOSK_OPEN_TIME" & ", "
                sql += "@_KIOSK_OPEN24" & ", "
                sql += "@_SCREEN_SAVER_SEC" & ", "
                sql += "@_TIME_OUT_SEC" & ", "
                sql += "@_SHOW_MSG_SEC" & ", "
                sql += "@_PAYMENT_EXTEND_SEC" & ", "
                sql += "@_CARD_EXPIRE_MONTH" & ", "
                sql += "@_PASSPORT_EXPIRE_MONTH" & ", "
                sql += "@_LOCKER_WEBSERVICE_URL" & ", "
                sql += "@_LOCKER_PC_POSITION" & ", "
                sql += "@_SLEEP_TIME" & ", "
                sql += "@_SLEEP_DURATION" & ", "
                sql += "@_CONTACT_CENTER_TELNO" & ", "
                sql += "@_ALARM_WEBSERVICE_URL" & ", "
                sql += "@_INTERVAL_SYNC_TRANSACTION_MIN" & ", "
                sql += "@_INTERVAL_SYNC_MASTER_MIN" & ", "
                sql += "@_INTERVAL_SYNC_LOG_MIN" & ", "
                sql += "@_SYNC_TO_KIOSK" & ", "
                sql += "@_SYNC_TO_SERVER"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table CF_KIOSK_SYSCONFIG
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_KIOSK_ID = " & "@_MS_KIOSK_ID" & ", "
                Sql += "MAC_ADDRESS = " & "@_MAC_ADDRESS" & ", "
                Sql += "IP_ADDRESS = " & "@_IP_ADDRESS" & ", "
                Sql += "LOCATION_CODE = " & "@_LOCATION_CODE" & ", "
                Sql += "LOCATION_NAME = " & "@_LOCATION_NAME" & ", "
                Sql += "LOGIN_SSO = " & "@_LOGIN_SSO" & ", "
                Sql += "KIOSK_OPEN_TIME = " & "@_KIOSK_OPEN_TIME" & ", "
                Sql += "KIOSK_OPEN24 = " & "@_KIOSK_OPEN24" & ", "
                Sql += "SCREEN_SAVER_SEC = " & "@_SCREEN_SAVER_SEC" & ", "
                Sql += "TIME_OUT_SEC = " & "@_TIME_OUT_SEC" & ", "
                Sql += "SHOW_MSG_SEC = " & "@_SHOW_MSG_SEC" & ", "
                Sql += "PAYMENT_EXTEND_SEC = " & "@_PAYMENT_EXTEND_SEC" & ", "
                Sql += "CARD_EXPIRE_MONTH = " & "@_CARD_EXPIRE_MONTH" & ", "
                Sql += "PASSPORT_EXPIRE_MONTH = " & "@_PASSPORT_EXPIRE_MONTH" & ", "
                Sql += "LOCKER_WEBSERVICE_URL = " & "@_LOCKER_WEBSERVICE_URL" & ", "
                Sql += "LOCKER_PC_POSITION = " & "@_LOCKER_PC_POSITION" & ", "
                Sql += "SLEEP_TIME = " & "@_SLEEP_TIME" & ", "
                Sql += "SLEEP_DURATION = " & "@_SLEEP_DURATION" & ", "
                Sql += "CONTACT_CENTER_TELNO = " & "@_CONTACT_CENTER_TELNO" & ", "
                Sql += "ALARM_WEBSERVICE_URL = " & "@_ALARM_WEBSERVICE_URL" & ", "
                Sql += "INTERVAL_SYNC_TRANSACTION_MIN = " & "@_INTERVAL_SYNC_TRANSACTION_MIN" & ", "
                Sql += "INTERVAL_SYNC_MASTER_MIN = " & "@_INTERVAL_SYNC_MASTER_MIN" & ", "
                Sql += "INTERVAL_SYNC_LOG_MIN = " & "@_INTERVAL_SYNC_LOG_MIN" & ", "
                Sql += "SYNC_TO_KIOSK = " & "@_SYNC_TO_KIOSK" & ", "
                Sql += "SYNC_TO_SERVER = " & "@_SYNC_TO_SERVER" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table CF_KIOSK_SYSCONFIG
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table CF_KIOSK_SYSCONFIG
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_KIOSK_ID, MAC_ADDRESS, IP_ADDRESS, LOCATION_CODE, LOCATION_NAME, LOGIN_SSO, KIOSK_OPEN_TIME, KIOSK_OPEN24, SCREEN_SAVER_SEC, TIME_OUT_SEC, SHOW_MSG_SEC, PAYMENT_EXTEND_SEC, CARD_EXPIRE_MONTH, PASSPORT_EXPIRE_MONTH, LOCKER_WEBSERVICE_URL, LOCKER_PC_POSITION, SLEEP_TIME, SLEEP_DURATION, CONTACT_CENTER_TELNO, ALARM_WEBSERVICE_URL, INTERVAL_SYNC_TRANSACTION_MIN, INTERVAL_SYNC_MASTER_MIN, INTERVAL_SYNC_LOG_MIN, SYNC_TO_KIOSK, SYNC_TO_SERVER FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
