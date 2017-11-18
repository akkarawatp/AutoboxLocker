Imports TITWebService
Imports System.Data
Imports Engine
Partial Class frmLogin
    Inherits System.Web.UI.Page
    Dim BL As New LockerBL

    Public Function LoginTIT(vUserName As String, vPassword As String) As Engine.LoginReturnData
        Dim ret As New Engine.LoginReturnData
        Try
            ret = UserENG.LoginTIT(vUserName, vPassword, "ATB-Locker", "WebAdmin", HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.Browser.Browser, HttpContext.Current.Request.Browser.Version, HttpContext.Current.Request.Url.AbsoluteUri)
        Catch ex As Exception
            ret = New Engine.LoginReturnData
        End Try

        Return ret
    End Function

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim ret As New Engine.LoginReturnData
        ret = LoginTIT(txtUserName.Text, txtPassword.Text)
        Dim LoginInfo As New LockerBL
        If ret.LoginStatus = True Then
            Session("UserName") = ret.LoginUsername
            SetUserFunctionalInfo(ret.LoginUsername)
            If ret.ForceChangePwd = "Y" Then
                'ให้ Redirec ไปหน้าจอสำหรับเปลี่ยนรหัสผ่านก่อน
                Session("ForceChangePW") = "Y"
                Response.Redirect("frmChangePassword.aspx")
            Else
                Session("ForceChangePW") = "N"
                Response.Redirect("frmDashboardOverview.aspx")
            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('invalid username or password. please try agian.')", True)
        End If

        'Session("UserName") = "admin"
        'Response.Redirect("frmDashboardOverview.aspx")
    End Sub

    Private Function GetUserLocationID(dt As DataTable) As String
        Dim ret As String = ""
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                If ret = "" Then
                    ret = dr("id")
                Else
                    ret += "," & dr("id")
                End If
            Next
        End If
        Return ret
    End Function

    Private Sub SetUserFunctionalInfo(Username As String)
        Try
            If Username.Trim <> "" Then
                'Session("List_User") = BL.GetList_User(userID)
                Session("List_User_Functional") = BL.GetList_User_Functional(0, 0, 0, Username)
                Session("List_User_Location") = BL.GetList_User_Location(Username, "Y")
                Session("List_User_LocationID") = GetUserLocationID(Session("List_User_Location"))
            Else
                'Session("List_User_Functional") = New DataTable
                'Session("List_User_Location") = ""
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
            End If
        Catch ex As Exception
            'Response.Write("Exception :  " + ex.Message & vbNewLine & ex.StackTrace)
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End Try

    End Sub

End Class
