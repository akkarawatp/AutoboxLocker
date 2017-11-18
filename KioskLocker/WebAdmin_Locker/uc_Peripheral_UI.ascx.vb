Imports System.Data
Public Class uc_Peripheral_UI
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Dim StatusList As DataTable
    Public Sub BindPeripheral(ByVal Device As DataTable, ByVal StatusTemplate As DataTable)
        StatusList = StatusTemplate
        rptDevice.DataSource = Device
        rptDevice.DataBind()
    End Sub

    Private Sub rptDevice_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptDevice.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim spanDevice As HtmlGenericControl = e.Item.FindControl("spanDevice")
        Dim iconDevice As Image = e.Item.FindControl("iconDevice")
        Dim lblDeviceName As Label = e.Item.FindControl("lblDeviceName")

        lblDeviceName.Text = e.Item.DataItem("device_name_en").ToString
        spanDevice.Attributes("Title") = e.Item.DataItem("device_name_en").ToString
        iconDevice.ImageUrl = "Render_Hardware_Icon.aspx?C=W&D=" & e.Item.DataItem("ms_device_id")

        If IsDBNull(e.Item.DataItem("ms_device_status_id")) Then
            spanDevice.Attributes("class") = "btn btn-default"
        Else
            'StatusList.DefaultView.RowFilter = "ms_device_type_id=" & e.Item.DataItem("ms_device_type_id") & " AND ms_device_status_id=" & e.Item.DataItem("ms_device_status_id")
            StatusList.DefaultView.RowFilter = " ms_device_status_id=" & e.Item.DataItem("ms_device_status_id")
            If StatusList.DefaultView.Count > 0 AndAlso Not IsDBNull(StatusList.DefaultView(0).Item("Is_Problem")) Then
                If StatusList.DefaultView(0).Item("Is_Problem") = "Y" Then
                    spanDevice.Attributes("class") = "btn btn-danger"
                Else
                    spanDevice.Attributes("class") = "btn btn-info"
                End If
            Else
                spanDevice.Attributes("class") = "btn btn-default"
            End If
        End If
    End Sub

End Class