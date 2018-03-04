Imports System.Web
Imports System.Data.SqlClient
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports log4net

Public Class UserENG
    Shared _logMsg As New LogMessageBuilder()
    Private Shared ReadOnly Property Logger As ILog
        Get
            Return LogManager.GetLogger(GetType(UserENG))
        End Get
    End Property
    Public Shared Function LoginTIT(vUserName As String, vPassword As String, SystemCode As String, ModuleName As String, ClientIP As String, ClientBrowser As String, BrowserVersion As String, ServerURL As String) As LoginReturnData
        Dim ret As New LoginReturnData
        Try
            Dim uLnq As New MsUserAccountServerLinqDB
            uLnq.ChkDataByUSERNAME(vUserName, Nothing)
            If uLnq.ID > 0 Then
                If uLnq.ACTIVE_STATUS = "Y" Then
                    Dim pwd As String = ServerDB.EnCripPwd(vPassword)
                    If uLnq.PASSWD = pwd Then
                        ret = InsertLoginHistory(uLnq, SystemCode, ModuleName, ClientIP, ClientBrowser, BrowserVersion, ServerURL)
                    Else
                        ret.LoginStatus = False
                        ret.ErrorMessage = "Invalid Password"
                    End If
                Else
                    ret.LoginStatus = False
                    ret.ErrorMessage = "User is Inactive"
                End If
            Else
                ret.LoginStatus = False
                ret.ErrorMessage = "User is not Authorize for " & SystemCode & " System"
            End If
            uLnq = Nothing

        Catch ex As Exception
            ret.LoginStatus = False
            ret.ErrorMessage = "LoginTIT Exception : " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function


    Private Shared Function InsertLoginHistory(uData As MsUserAccountServerLinqDB, SystemCode As String, ModuleName As String, ClientIP As String, ClientBrowser As String, BrowserVersion As String, ServerURL As String) As LoginReturnData
        Dim ret As New LoginReturnData
        Try
            Dim lnq As New TbLoginHistoryServerLinqDB
            lnq.TOKEN = Guid.NewGuid.ToString
            lnq.USERNAME = uData.USERNAME
            lnq.FIRST_NAME = uData.FIRST_NAME
            lnq.LAST_NAME = uData.LAST_NAME
            lnq.COMPANY_NAME = uData.COMPANY_NAME
            lnq.SYS_CODE = SystemCode & "." & ModuleName
            lnq.LOGON_TIME = DateTime.Now
            lnq.CLIENT_IP = ClientIP
            lnq.CLIENT_BROWSER = "Browser :" + ClientBrowser + " Version :" & BrowserVersion
            lnq.SERVER_URL = IIf(ServerURL.Trim <> "", ServerURL, HttpContext.Current.Request.Url.AbsoluteUri)
            'lnq.WEBSERVICE_URL = HttpContext.Current.Request.Url.AbsoluteUri

            Dim trans As New ServerTransactionDB
            Dim re As ExecuteDataInfo = lnq.InsertData(uData.USERNAME, trans.Trans)
            If re.IsSuccess = True Then
                trans.CommitTransaction()
                ret.LoginStatus = True
                ret.Token = lnq.TOKEN
                ret.LoginUsername = uData.USERNAME
                ret.LoginFirstName = uData.FIRST_NAME
                ret.LoginLastName = uData.LAST_NAME
                ret.LoginCompanyName = uData.COMPANY_NAME
                ret.ForceChangePwd = uData.FORCE_CHANGE_PWD
            Else
                trans.RollbackTransaction()
                ret.LoginStatus = False
                ret.ErrorMessage = lnq.ErrorMessage
            End If
        Catch ex As Exception
            ret.LoginStatus = False
            ret.ErrorMessage = "InsertLoginHistory Exception : " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    Public Shared Function ChangePassword(UserName As String, OldPassword As String, NewPassword As String) As ExecuteDataInfo
        Dim ret As ExecuteDataInfo
        Try
            Dim lnq As New MsUserAccountServerLinqDB
            lnq.ChkDataByUSERNAME(UserName, Nothing)
            If lnq.ID > 0 Then
                If lnq.PASSWD = ServerDB.EnCripPwd(OldPassword) Then
                    lnq.PASSWD = ServerDB.EnCripPwd(NewPassword)
                    lnq.FORCE_CHANGE_PWD = "N"

                    Dim trans As New ServerTransactionDB
                    ret = lnq.UpdateData(UserName, trans.Trans)
                    If ret.IsSuccess = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                Else
                    ret.IsSuccess = False
                    ret.ErrorMessage = "Invalid Old Password"
                End If
            Else
                ret.IsSuccess = False
                ret.ErrorMessage = "Invalid Username"
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception : " & ex.Message & vbNewLine & ex.StackTrace
        End Try

        Return ret
    End Function

    Public Shared Function ResetUserPassword(UserName As String, NewPassword As String) As ExecuteDataInfo
        Dim ret As ExecuteDataInfo
        Try
            Dim lnq As New MsUserAccountServerLinqDB
            lnq.ChkDataByUSERNAME(UserName, Nothing)
            If lnq.ID > 0 Then
                lnq.PASSWD = ServerDB.EnCripPwd(NewPassword)
                lnq.FORCE_CHANGE_PWD = "Y"

                Dim trans As New ServerTransactionDB
                ret = lnq.UpdateData(UserName, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                ret = New ExecuteDataInfo
                ret.IsSuccess = False
                ret.ErrorMessage = "Invalid Username"
            End If
            lnq = Nothing

        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception : " & ex.Message & vbNewLine & ex.StackTrace
        End Try

        Return ret
    End Function


    Public Shared Function GetListUser(AccountNo As String, FirstName As String, LastName As String, CompanyName As String, UserName As String, ActiveStatus As String) As DataTable
        Dim ret As New DataTable
        Dim wh As String = " 1=1 "

        Dim p(6) As SqlParameter
        If AccountNo.Trim <> "" Then
            wh += " and u.account_no like '%' + @_ACCOUNT_NO + '%'"
            p(0) = ServerDB.SetText("@_ACCOUNT_NO", AccountNo)
        End If
        If FirstName.Trim <> "" Then
            wh += " and u.first_name like '%' + @_FIRST_NAME + '%'"
            p(1) = ServerDB.SetText("@_FIRST_NAME", FirstName)
        End If
        If LastName.Trim <> "" Then
            wh += " and u.last_name like '%' + @_LAST_NAME + '%'"
            p(2) = ServerDB.SetText("@_LAST_NAME", LastName)
        End If
        If CompanyName.Trim <> "" Then
            wh += " and u.company_name like '%' + @_COMPANY_NAME + '%'"
            p(3) = ServerDB.SetText("@_COMPANY_NAME", CompanyName)
        End If
        If UserName.Trim <> "" Then
            wh += " and u.username like '%' + @_USERNAME + '%'"
            p(4) = ServerDB.SetText("@_USERNAME", UserName)
        End If
        If ActiveStatus.Trim <> "" Then
            wh += " and u.active_status = @_ACTIVE_STATUS"
            p(5) = ServerDB.SetText("@_ACTIVE_STATUS", ActiveStatus)
        End If

        Dim sql As String = "select u.* "
        sql += " from ms_user_account u"
        sql += " where " & wh

        ret = ServerDB.ExecuteTable(sql, Nothing, p)
        ret.TableName = "GetListUser"
        Return ret
    End Function


    Public Shared Function InsertUserAccount(FirstName As String, LastName As String, CompanyName As String, Email As String, MobileNo As String, UserName As String, PassWD As String, ActiveStatus As String) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo

        If FirstName.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "FirstName is require"
            Return ret
        End If

        If LastName.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "LastName is require"
            Return ret
        End If

        If CompanyName.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "CompanyName is require"
            Return ret
        End If
        If UserName.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "Username is require"
            Return ret
        End If
        If PassWD.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "Password is require"
        End If

        If ActiveStatus.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "ActiveStatus is require"
            Return ret
        End If

        Dim AccountNo As String = DateTime.Now.ToString("yyyyMMddHHmmssfff")
        ret = SaveUserAccount(0, AccountNo, FirstName, LastName, CompanyName, Email, MobileNo, UserName, PassWD, True, ActiveStatus)

        Return ret
    End Function

    Public Shared Function EditUserAccount(UserID As Long, FirstName As String, LastName As String, CompanyName As String, Email As String, MobileNo As String, ActiveStatus As String) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        If UserID <= 0 Then
            ret.IsSuccess = False
            ret.ErrorMessage = "UserID is require"
            Return ret
        End If

        If FirstName.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "FirstName is require"
            Return ret
        End If

        If LastName.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "LastName is require"
            Return ret
        End If

        If CompanyName.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "CompanyName is require"
            Return ret
        End If

        If ActiveStatus.Trim = "" Then
            ret.IsSuccess = False
            ret.ErrorMessage = "ActiveStatus is require"
            Return ret
        End If

        Dim lnq As New MsUserAccountServerLinqDB
        lnq.GetDataByPK(UserID, Nothing)
        If lnq.ID > 0 Then
            Dim ForceChangePwd As Boolean = False
            ret = SaveUserAccount(lnq.ID, lnq.ACCOUNT_NO, FirstName, LastName, CompanyName, Email, MobileNo, lnq.USERNAME, ServerDB.DeCripPwd(lnq.PASSWD), ForceChangePwd, ActiveStatus)
        Else
            ret.IsSuccess = False
            ret.ErrorMessage = "Invalid UserID"
        End If
        lnq = Nothing

        Return ret
    End Function



    Private Shared Function SaveUserAccount(UserID As Long, AccountNo As String, FirstName As String, LastName As String, CompanyName As String, Email As String, MobileNo As String, UserName As String, Passwd As String, ForceChangePwd As Boolean, ActiveStatus As String) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Dim lnq As New MsUserAccountServerLinqDB

        If lnq.ChkDuplicateByUSERNAME(UserName, UserID, Nothing) = True Then
            ret.IsSuccess = False
            ret.ErrorMessage = "Duplicate Username"
            Return ret
        End If

        lnq.GetDataByPK(UserID, Nothing)
        lnq.ACCOUNT_NO = AccountNo
        lnq.FIRST_NAME = FirstName
        lnq.LAST_NAME = LastName
        lnq.COMPANY_NAME = CompanyName
        lnq.EMAIL = Email
        lnq.MOBILE_NO = MobileNo
        lnq.USERNAME = UserName
        lnq.PASSWD = ServerDB.EnCripPwd(Passwd)
        lnq.FORCE_CHANGE_PWD = IIf(ForceChangePwd = True, "Y", "N")
        lnq.ACTIVE_STATUS = ActiveStatus

        Dim trans As New ServerTransactionDB
        If lnq.ID > 0 Then
            ret = lnq.UpdateData(UserName, trans.Trans)
        Else
            ret = lnq.InsertData(UserName, trans.Trans)
        End If

        If ret.IsSuccess = True Then
            trans.CommitTransaction()
            ret.NewID = lnq.ID
        Else
            trans.RollbackTransaction()
        End If
        lnq = Nothing

        Return ret
    End Function

    Public Shared Function DeleteUserAccount(UserID As Long) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        If UserID <= 0 Then
            ret.IsSuccess = False
            ret.ErrorMessage = "UserID is require"
            Return ret
        End If

        Dim trans As New ServerTransactionDB
        Dim lnq As New MsUserAccountServerLinqDB
        ret = lnq.DeleteByPK(UserID, trans.Trans)
        If ret.IsSuccess = True Then
            trans.CommitTransaction()
        Else
            trans.RollbackTransaction()
        End If
        lnq = Nothing

        Return ret
    End Function

    Public Shared Function CheckDuplicateUserAccount(UserName As String, UserID As Long) As Boolean
        Dim ret As Boolean = False
        Dim lnq As New MsUserAccountServerLinqDB
        ret = lnq.ChkDuplicateByUSERNAME(UserName, UserID, Nothing)
        lnq = Nothing

        Return ret
    End Function
End Class
