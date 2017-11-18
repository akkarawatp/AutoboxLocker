Imports System.Data
Imports ServerLinqDB.ConnectDB
Partial Class frmChangePassword
    Inherits System.Web.UI.Page
    Protected ReadOnly Property UserName As String
        Get
            Try
                Return Session("UserName")
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property



    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtCurrentPassword.Attributes.Add("value", txtCurrentPassword.Text)
        txtPassword.Attributes.Add("value", txtPassword.Text)
        txtConfirmPassword.Attributes.Add("value", txtConfirmPassword.Text)

    End Sub

    Function ChangePassword(username As String, oldpassword As String, newpassword As String) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            ret = Engine.UserENG.ChangePassword(username, oldpassword, newpassword)
        Catch ex As Exception
            ret = New ExecuteDataInfo
        End Try

        Return ret
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim CurrentPassword = txtCurrentPassword.Text.Trim
        Dim newpassword = txtPassword.Text.Trim
        Dim passwordconfirm = txtConfirmPassword.Text.Trim

        If CurrentPassword = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please enter your current password.')", True)
            Exit Sub
        End If

        If newpassword = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please enter your new password.')", True)
            Exit Sub
        End If

        If newpassword <> passwordconfirm Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Password and Confirm Password does not match.')", True)
            Exit Sub
        End If

        Dim ret As New ExecuteDataInfo
        ret = ChangePassword(UserName, CurrentPassword, newpassword)
        If ret.IsSuccess Then
            Session.Remove("List_User_Functional")
            Session.Remove("List_User_Location")
            Session.Remove("UserName")

            'ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Success,Please Login with your new password.')", True)
            Response.Redirect("frmLogin.aspx")
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('" & ret.ErrorMessage.ToString.Replace("'", "''") & "')", True)
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        txtCurrentPassword.Attributes.Clear()
        txtPassword.Attributes.Clear()
        txtConfirmPassword.Attributes.Clear()

        txtCurrentPassword.Text = ""
        txtPassword.Text = ""
        txtConfirmPassword.Text = ""
    End Sub
End Class
