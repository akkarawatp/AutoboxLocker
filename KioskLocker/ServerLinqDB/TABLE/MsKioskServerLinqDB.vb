Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports DB = ServerLinqDB.ConnectDB.ServerDB
Imports ServerLinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for MS_KIOSK table ServerLinqDB.
    '[Create by  on Febuary, 18 2018]
    Public Class MsKioskServerLinqDB
        Public sub MsKioskServerLinqDB()

        End Sub 
        ' MS_KIOSK
        Const _tableName As String = "MS_KIOSK"

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
        Dim _MS_LOCATION_ID As Long = 0
        Dim _COM_NAME As String = ""
        Dim _IP_ADDRESS As String = ""
        Dim _MAC_ADDRESS As String = ""
        Dim _ONLINE_STATUS As Char = "Y"
        Dim _TODAY_AVAILABLE As Double = 0
        Dim _HW_ISPROBLEM As Char = "N"
        Dim _CPU_USAGE As Double = 0
        Dim _RAM_USAGE As Double = 0
        Dim _DISK_USAGE As Double = 0
        Dim _ACTIVE_STATUS As Char = "Y"
        Dim _VALID_START_DATE As DateTime = New DateTime(1,1,1)
        Dim _VALID_EXPIRE_DATE As DateTime = New DateTime(1,1,1)
        Dim _LAST_SYNC_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_MS_LOCATION_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_LOCATION_ID() As Long
            Get
                Return _MS_LOCATION_ID
            End Get
            Set(ByVal value As Long)
               _MS_LOCATION_ID = value
            End Set
        End Property 
        <Column(Storage:="_COM_NAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property COM_NAME() As String
            Get
                Return _COM_NAME
            End Get
            Set(ByVal value As String)
               _COM_NAME = value
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
        <Column(Storage:="_MAC_ADDRESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property MAC_ADDRESS() As String
            Get
                Return _MAC_ADDRESS
            End Get
            Set(ByVal value As String)
               _MAC_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_ONLINE_STATUS", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ONLINE_STATUS() As Char
            Get
                Return _ONLINE_STATUS
            End Get
            Set(ByVal value As Char)
               _ONLINE_STATUS = value
            End Set
        End Property 
        <Column(Storage:="_TODAY_AVAILABLE", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property TODAY_AVAILABLE() As Double
            Get
                Return _TODAY_AVAILABLE
            End Get
            Set(ByVal value As Double)
               _TODAY_AVAILABLE = value
            End Set
        End Property 
        <Column(Storage:="_HW_ISPROBLEM", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property HW_ISPROBLEM() As Char
            Get
                Return _HW_ISPROBLEM
            End Get
            Set(ByVal value As Char)
               _HW_ISPROBLEM = value
            End Set
        End Property 
        <Column(Storage:="_CPU_USAGE", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property CPU_USAGE() As Double
            Get
                Return _CPU_USAGE
            End Get
            Set(ByVal value As Double)
               _CPU_USAGE = value
            End Set
        End Property 
        <Column(Storage:="_RAM_USAGE", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property RAM_USAGE() As Double
            Get
                Return _RAM_USAGE
            End Get
            Set(ByVal value As Double)
               _RAM_USAGE = value
            End Set
        End Property 
        <Column(Storage:="_DISK_USAGE", DbType:="Float NOT NULL ",CanBeNull:=false)>  _
        Public Property DISK_USAGE() As Double
            Get
                Return _DISK_USAGE
            End Get
            Set(ByVal value As Double)
               _DISK_USAGE = value
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
        <Column(Storage:="_VALID_START_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property VALID_START_DATE() As DateTime
            Get
                Return _VALID_START_DATE
            End Get
            Set(ByVal value As DateTime)
               _VALID_START_DATE = value
            End Set
        End Property 
        <Column(Storage:="_VALID_EXPIRE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property VALID_EXPIRE_DATE() As DateTime
            Get
                Return _VALID_EXPIRE_DATE
            End Get
            Set(ByVal value As DateTime)
               _VALID_EXPIRE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_LAST_SYNC_TIME", DbType:="DateTime")>  _
        Public Property LAST_SYNC_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _LAST_SYNC_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LAST_SYNC_TIME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _MS_LOCATION_ID = 0
            _COM_NAME = ""
            _IP_ADDRESS = ""
            _MAC_ADDRESS = ""
            _ONLINE_STATUS = "Y"
            _TODAY_AVAILABLE = 0
            _HW_ISPROBLEM = "N"
            _CPU_USAGE = 0
            _RAM_USAGE = 0
            _DISK_USAGE = 0
            _ACTIVE_STATUS = "Y"
            _VALID_START_DATE = New DateTime(1,1,1)
            _VALID_EXPIRE_DATE = New DateTime(1,1,1)
            _LAST_SYNC_TIME = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into MS_KIOSK table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_KIOSK table successfully.
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


        '/// Returns an indication whether the record of MS_KIOSK by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doChkData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_KIOSK by specified ID key is retrieved successfully.
        '/// <param name=cID>The ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsKioskServerLinqDB
            Dim p(1) As SQLParameter
            p(0) = DB.SetBigInt("@_ID", cID)
            Return doGetData("ID = @_ID", trans, p)
        End Function


        '/// Returns an indication whether the record of MS_KIOSK by specified COM_NAME key is retrieved successfully.
        '/// <param name=cCOM_NAME>The COM_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCOM_NAME(cCOM_NAME As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_COM_NAME", cCOM_NAME) 
            Return doChkData("COM_NAME = @_COM_NAME", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_KIOSK by specified COM_NAME key is retrieved successfully.
        '/// <param name=cCOM_NAME>The COM_NAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCOM_NAME(cCOM_NAME As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_COM_NAME", cCOM_NAME) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("COM_NAME = @_COM_NAME And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_KIOSK by specified IP_ADDRESS key is retrieved successfully.
        '/// <param name=cIP_ADDRESS>The IP_ADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByIP_ADDRESS(cIP_ADDRESS As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_IP_ADDRESS", cIP_ADDRESS) 
            Return doChkData("IP_ADDRESS = @_IP_ADDRESS", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_KIOSK by specified IP_ADDRESS key is retrieved successfully.
        '/// <param name=cIP_ADDRESS>The IP_ADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByIP_ADDRESS(cIP_ADDRESS As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_IP_ADDRESS", cIP_ADDRESS) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("IP_ADDRESS = @_IP_ADDRESS And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_KIOSK by specified MAC_ADDRESS key is retrieved successfully.
        '/// <param name=cMAC_ADDRESS>The MAC_ADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMAC_ADDRESS(cMAC_ADDRESS As String, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MAC_ADDRESS", cMAC_ADDRESS) 
            Return doChkData("MAC_ADDRESS = @_MAC_ADDRESS", trans, cmdPara)
        End Function

        '/// Returns an duplicate data record of MS_KIOSK by specified MAC_ADDRESS key is retrieved successfully.
        '/// <param name=cMAC_ADDRESS>The MAC_ADDRESS key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMAC_ADDRESS(cMAC_ADDRESS As String, cID As Long, trans As SQLTransaction) As Boolean
            Dim cmdPara(2)  As SQLParameter
            cmdPara(0) = DB.SetText("@_MAC_ADDRESS", cMAC_ADDRESS) 
            cmdPara(1) = DB.SetBigInt("@_ID", cID) 
            Return doChkData("MAC_ADDRESS = @_MAC_ADDRESS And ID <> @_ID", trans, cmdPara)
        End Function


        '/// Returns an indication whether the record of MS_KIOSK by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As Boolean
            Return doChkData(whText, trans, cmdPara)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_KIOSK table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_KIOSK table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_KIOSK table successfully.
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
            Dim cmbParam(18) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MS_LOCATION_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_LOCATION_ID

            cmbParam(6) = New SqlParameter("@_COM_NAME", SqlDbType.VarChar)
            cmbParam(6).Value = _COM_NAME

            cmbParam(7) = New SqlParameter("@_IP_ADDRESS", SqlDbType.VarChar)
            cmbParam(7).Value = _IP_ADDRESS

            cmbParam(8) = New SqlParameter("@_MAC_ADDRESS", SqlDbType.VarChar)
            cmbParam(8).Value = _MAC_ADDRESS

            cmbParam(9) = New SqlParameter("@_ONLINE_STATUS", SqlDbType.Char)
            cmbParam(9).Value = _ONLINE_STATUS

            cmbParam(10) = New SqlParameter("@_TODAY_AVAILABLE", SqlDbType.Float)
            cmbParam(10).Value = _TODAY_AVAILABLE

            cmbParam(11) = New SqlParameter("@_HW_ISPROBLEM", SqlDbType.Char)
            cmbParam(11).Value = _HW_ISPROBLEM

            cmbParam(12) = New SqlParameter("@_CPU_USAGE", SqlDbType.Float)
            cmbParam(12).Value = _CPU_USAGE

            cmbParam(13) = New SqlParameter("@_RAM_USAGE", SqlDbType.Float)
            cmbParam(13).Value = _RAM_USAGE

            cmbParam(14) = New SqlParameter("@_DISK_USAGE", SqlDbType.Float)
            cmbParam(14).Value = _DISK_USAGE

            cmbParam(15) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.Char)
            cmbParam(15).Value = _ACTIVE_STATUS

            cmbParam(16) = New SqlParameter("@_VALID_START_DATE", SqlDbType.DateTime)
            cmbParam(16).Value = _VALID_START_DATE

            cmbParam(17) = New SqlParameter("@_VALID_EXPIRE_DATE", SqlDbType.DateTime)
            cmbParam(17).Value = _VALID_EXPIRE_DATE

            cmbParam(18) = New SqlParameter("@_LAST_SYNC_TIME", SqlDbType.DateTime)
            If _LAST_SYNC_TIME.Value.Year > 1 Then 
                cmbParam(18).Value = _LAST_SYNC_TIME.Value
            Else
                cmbParam(18).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_KIOSK by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_location_id")) = False Then _ms_location_id = Convert.ToInt64(Rdr("ms_location_id"))
                        If Convert.IsDBNull(Rdr("com_name")) = False Then _com_name = Rdr("com_name").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("mac_address")) = False Then _mac_address = Rdr("mac_address").ToString()
                        If Convert.IsDBNull(Rdr("online_status")) = False Then _online_status = Rdr("online_status").ToString()
                        If Convert.IsDBNull(Rdr("today_available")) = False Then _today_available = Convert.ToDouble(Rdr("today_available"))
                        If Convert.IsDBNull(Rdr("hw_isproblem")) = False Then _hw_isproblem = Rdr("hw_isproblem").ToString()
                        If Convert.IsDBNull(Rdr("cpu_usage")) = False Then _cpu_usage = Convert.ToDouble(Rdr("cpu_usage"))
                        If Convert.IsDBNull(Rdr("ram_usage")) = False Then _ram_usage = Convert.ToDouble(Rdr("ram_usage"))
                        If Convert.IsDBNull(Rdr("disk_usage")) = False Then _disk_usage = Convert.ToDouble(Rdr("disk_usage"))
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
                        If Convert.IsDBNull(Rdr("valid_start_date")) = False Then _valid_start_date = Convert.ToDateTime(Rdr("valid_start_date"))
                        If Convert.IsDBNull(Rdr("valid_expire_date")) = False Then _valid_expire_date = Convert.ToDateTime(Rdr("valid_expire_date"))
                        If Convert.IsDBNull(Rdr("last_sync_time")) = False Then _last_sync_time = Convert.ToDateTime(Rdr("last_sync_time"))
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


        '/// Returns an indication whether the record of MS_KIOSK by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction, cmdPara() As SQLParameter) As MsKioskServerLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_location_id")) = False Then _ms_location_id = Convert.ToInt64(Rdr("ms_location_id"))
                        If Convert.IsDBNull(Rdr("com_name")) = False Then _com_name = Rdr("com_name").ToString()
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("mac_address")) = False Then _mac_address = Rdr("mac_address").ToString()
                        If Convert.IsDBNull(Rdr("online_status")) = False Then _online_status = Rdr("online_status").ToString()
                        If Convert.IsDBNull(Rdr("today_available")) = False Then _today_available = Convert.ToDouble(Rdr("today_available"))
                        If Convert.IsDBNull(Rdr("hw_isproblem")) = False Then _hw_isproblem = Rdr("hw_isproblem").ToString()
                        If Convert.IsDBNull(Rdr("cpu_usage")) = False Then _cpu_usage = Convert.ToDouble(Rdr("cpu_usage"))
                        If Convert.IsDBNull(Rdr("ram_usage")) = False Then _ram_usage = Convert.ToDouble(Rdr("ram_usage"))
                        If Convert.IsDBNull(Rdr("disk_usage")) = False Then _disk_usage = Convert.ToDouble(Rdr("disk_usage"))
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Rdr("active_status").ToString()
                        If Convert.IsDBNull(Rdr("valid_start_date")) = False Then _valid_start_date = Convert.ToDateTime(Rdr("valid_start_date"))
                        If Convert.IsDBNull(Rdr("valid_expire_date")) = False Then _valid_expire_date = Convert.ToDateTime(Rdr("valid_expire_date"))
                        If Convert.IsDBNull(Rdr("last_sync_time")) = False Then _last_sync_time = Convert.ToDateTime(Rdr("last_sync_time"))
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


        'Get Insert Statement for table MS_KIOSK
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, MS_LOCATION_ID, COM_NAME, IP_ADDRESS, MAC_ADDRESS, ONLINE_STATUS, TODAY_AVAILABLE, HW_ISPROBLEM, CPU_USAGE, RAM_USAGE, DISK_USAGE, ACTIVE_STATUS, VALID_START_DATE, VALID_EXPIRE_DATE, LAST_SYNC_TIME)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.MS_LOCATION_ID, INSERTED.COM_NAME, INSERTED.IP_ADDRESS, INSERTED.MAC_ADDRESS, INSERTED.ONLINE_STATUS, INSERTED.TODAY_AVAILABLE, INSERTED.HW_ISPROBLEM, INSERTED.CPU_USAGE, INSERTED.RAM_USAGE, INSERTED.DISK_USAGE, INSERTED.ACTIVE_STATUS, INSERTED.VALID_START_DATE, INSERTED.VALID_EXPIRE_DATE, INSERTED.LAST_SYNC_TIME"
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_MS_LOCATION_ID" & ", "
                sql += "@_COM_NAME" & ", "
                sql += "@_IP_ADDRESS" & ", "
                sql += "@_MAC_ADDRESS" & ", "
                sql += "@_ONLINE_STATUS" & ", "
                sql += "@_TODAY_AVAILABLE" & ", "
                sql += "@_HW_ISPROBLEM" & ", "
                sql += "@_CPU_USAGE" & ", "
                sql += "@_RAM_USAGE" & ", "
                sql += "@_DISK_USAGE" & ", "
                sql += "@_ACTIVE_STATUS" & ", "
                sql += "@_VALID_START_DATE" & ", "
                sql += "@_VALID_EXPIRE_DATE" & ", "
                sql += "@_LAST_SYNC_TIME"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_KIOSK
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "MS_LOCATION_ID = " & "@_MS_LOCATION_ID" & ", "
                Sql += "COM_NAME = " & "@_COM_NAME" & ", "
                Sql += "IP_ADDRESS = " & "@_IP_ADDRESS" & ", "
                Sql += "MAC_ADDRESS = " & "@_MAC_ADDRESS" & ", "
                Sql += "ONLINE_STATUS = " & "@_ONLINE_STATUS" & ", "
                Sql += "TODAY_AVAILABLE = " & "@_TODAY_AVAILABLE" & ", "
                Sql += "HW_ISPROBLEM = " & "@_HW_ISPROBLEM" & ", "
                Sql += "CPU_USAGE = " & "@_CPU_USAGE" & ", "
                Sql += "RAM_USAGE = " & "@_RAM_USAGE" & ", "
                Sql += "DISK_USAGE = " & "@_DISK_USAGE" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" & ", "
                Sql += "VALID_START_DATE = " & "@_VALID_START_DATE" & ", "
                Sql += "VALID_EXPIRE_DATE = " & "@_VALID_EXPIRE_DATE" & ", "
                Sql += "LAST_SYNC_TIME = " & "@_LAST_SYNC_TIME" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_KIOSK
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_KIOSK
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, MS_LOCATION_ID, COM_NAME, IP_ADDRESS, MAC_ADDRESS, ONLINE_STATUS, TODAY_AVAILABLE, HW_ISPROBLEM, CPU_USAGE, RAM_USAGE, DISK_USAGE, ACTIVE_STATUS, VALID_START_DATE, VALID_EXPIRE_DATE, LAST_SYNC_TIME FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
