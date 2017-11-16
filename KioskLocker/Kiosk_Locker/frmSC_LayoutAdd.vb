Imports AutoboxLocker.Data.KioskConfigData
Public Class frmSC_LayoutAdd

    Public CabinetModelID As Integer = 0

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles lblOK.Click, btnOK.Click
        Dim StepID As KioskLockerStep = IIf(CabinetModelID > 0, KioskLockerStep.StaffConsoleLockerSetting_CabinetEdit, KioskLockerStep.StaffConsoleLockerSetting_CabinetAdd)
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, StepID, "Save Cabinet Model ID=" & CabinetModelID, False)
        If cmbModel.SelectedValue = 0 Then
            MessageBox.Show("กรุณาเลือกรุ่น")
            Exit Sub
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Public Sub SetModelDDL()
        'Dim sql As String = "select id, model_name from ms_cabinet_model order by id"
        Dim dt As DataTable = CabinetModelList.Copy 'KioskLinqDB.ConnectDB.KioskDB.ExecuteTable(sql)

        If dt.Columns.Count = 0 Then
            dt.Columns.Add("id")
            dt.Columns.Add("model_name")
        End If

        Dim dr As DataRow = dt.NewRow
        dr("id") = 0
        dr("model_name") = "เลือก"

        dt.Rows.InsertAt(dr, 0)

        cmbModel.DisplayMember = "model_name"
        cmbModel.ValueMember = "id"
        cmbModel.DataSource = dt

        'If dt.Rows.Count > 0 Then
        If CabinetModelID > 0 Then
            cmbModel.SelectedValue = CabinetModelID
        End If
        'End If

    End Sub

    Private Sub lblCancel_Click(sender As Object, e As EventArgs) Handles lblCancel.Click, btnCancel.Click
        Dim StepID As KioskLockerStep = IIf(CabinetModelID > 0, KioskLockerStep.StaffConsoleLockerSetting_CabinetEdit, KioskLockerStep.StaffConsoleLockerSetting_CabinetAdd)
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, StepID, "Click Cancel", False)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmSC_LayoutAdd_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim StepID As KioskLockerStep = IIf(CabinetModelID > 0, KioskLockerStep.StaffConsoleLockerSetting_CabinetEdit, KioskLockerStep.StaffConsoleLockerSetting_CabinetAdd)
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, StepID, "Open Form frmSC_LayoutAdd", False)
        SetModelDDL()
    End Sub

    Private Sub cmbModel_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbModel.SelectionChangeCommitted

        CabinetModelID = cmbModel.SelectedValue
    End Sub
End Class