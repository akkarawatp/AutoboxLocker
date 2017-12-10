﻿Public Class ucAuthorizeSelector2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Enum Role
        View = 1
        NA = 0
    End Enum

    Public Property IsVisible As Boolean
        Get
            Return chkVisible.Checked
        End Get
        Set(value As Boolean)
            Me.Visible = value
            chkVisible.Checked = value
        End Set
    End Property

    Public Property IsEnable As Boolean
        Get
            Return chkEnable.Checked
        End Get
        Set(value As Boolean)
            aRoleNA.Enabled = value
            aRoleView.Enabled = value
            chkEnable.Checked = value
        End Set
    End Property

    Public Property SelectedRole As Role
        Get
            Select Case True
                Case aRoleView.CssClass.IndexOf("success") > -1
                    Return Role.View
                Case Else
                    Return Role.NA
            End Select
        End Get
        Set(value As Role)
            '----------------- Deselected All---------------
            aRoleView.Text = "<i class=""climacon moon new""></i> View"
            aRoleNA.Text = "<i class=""climacon moon new""></i> N/A"

            aRoleView.CssClass = "btn btn-warning"
            aRoleNA.CssClass = "btn btn-warning"

            Select Case value
                Case Role.View
                    aRoleView.Text = "<i class=""fa fa-check""></i> View"
                    aRoleView.CssClass = "btn btn-success"
                Case Else
                    aRoleNA.Text = "<i class=""fa fa-times""></i> N/A"
                    aRoleNA.CssClass = "btn btn-warning"
            End Select

        End Set
    End Property

    Private Sub aSlot_Click(sender As Object, e As System.EventArgs) Handles aRoleView.Click, aRoleNA.Click
        Dim a As LinkButton = sender
        SelectedRole = a.Attributes("role")
    End Sub

End Class