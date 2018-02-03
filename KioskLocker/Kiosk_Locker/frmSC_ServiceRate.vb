Imports MiniboxLocker.Data
Imports MiniboxLocker.Data.KioskConfigData
Imports KioskLinqDB.TABLE

Public Class frmSC_ServiceRate

    Dim Warning As Integer = 0
    Dim Critical As Integer = 0
    Dim Max As Integer = 0

    Private Sub frmSC_ServiceRate_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleServiceRate
    End Sub

    Private Sub frmSC_ServiceRate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmSC_Main.lblTitle.Text = "SERVICE RATE"
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleServiceRate_OpenForm, "", False)

        SetData()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleServiceRate_CheckAuthorize, "", False)
        SetStaffConsoleAuthorize()
        Application.DoEvents()

        frmLoading.Close()
    End Sub

    Private Sub SetData()
        If String.IsNullOrEmpty(KioskData.KioskID) = False Then
            ServiceRateData.SetServiceRateData(KioskData.KioskID)

            If ServiceRateData.ServiceRateDepositList.Rows.Count = 3 Then
                'ค่ามัดจำ
                lblDepositSR.Text = ServiceRateData.ServiceRateDepositList.Rows(0)("service_rate")
                lblDepositMR.Text = ServiceRateData.ServiceRateDepositList.Rows(1)("service_rate")
                lblDepositLR.Text = ServiceRateData.ServiceRateDepositList.Rows(2)("service_rate")
            End If

            If ServiceRateData.ServiceRateOvernightList.Rows.Count = 3 Then
                'ค่าบริการในวันถัดไป
                lblNextDaySR.Text = ServiceRateData.ServiceRateOvernightList.Rows(0)("service_rate")
                lblNextDayMR.Text = ServiceRateData.ServiceRateOvernightList.Rows(1)("service_rate")
                lblNextDayLR.Text = ServiceRateData.ServiceRateOvernightList.Rows(2)("service_rate")
            End If

            If ServiceRateData.ServiceFineRateList.Rows.Count = 3 Then
                'ค่าปรับ
                lblFineSR.Text = ServiceRateData.ServiceFineRateList.Rows(0)("service_rate")
                lblFineMR.Text = ServiceRateData.ServiceFineRateList.Rows(1)("service_rate")
                lblFineLR.Text = ServiceRateData.ServiceFineRateList.Rows(2)("service_rate")
            End If

            If ServiceRateData.ServiceRateHourList.Rows.Count > 0 Then
                flpServiceRateHour.Controls.Clear()
                'ค่าบริการรายชั่วโมง
                For i As Integer = 1 To 24
                    ServiceRateData.ServiceRateHourList.DefaultView.RowFilter = "service_hour=" & i

                    Dim dt As DataTable = ServiceRateData.ServiceRateHourList.DefaultView.ToTable.Copy
                    If dt.Rows.Count > 0 Then
                        'New Label Hours
                        Dim lblHours As New Label
                        lblHours.Text = dt.Rows(0)("service_hour")
                        lblHours.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                        lblHours.AutoSize = False
                        lblHours.TextAlign = ContentAlignment.MiddleCenter
                        lblHours.Size = New Size(80, 30)
                        lblHours.Location = New Point(0, 0)
                        lblHours.Margin = New Padding(0)
                        lblHours.BorderStyle = BorderStyle.FixedSingle
                        flpServiceRateHour.Controls.Add(lblHours)

                        dt.DefaultView.RowFilter = "ms_cabinet_model_id = " & ConstantsData.CabinetModelId.SR
                        Dim dv As DataView = dt.DefaultView
                        If dv.Count > 0 Then
                            'New Label Service Rate by Locker Size
                            Dim lblSRRate As New Label
                            lblSRRate.Text = dt(0)("service_rate")
                            lblSRRate.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                            lblSRRate.AutoSize = False
                            lblSRRate.TextAlign = ContentAlignment.MiddleCenter
                            lblSRRate.BorderStyle = BorderStyle.FixedSingle
                            lblSRRate.Size = New Size(100, 30)
                            lblSRRate.Location = New Point(80, 0)
                            lblSRRate.Margin = New Padding(0)
                            flpServiceRateHour.Controls.Add(lblSRRate)
                        End If
                        dt.DefaultView.RowFilter = ""

                        dt.DefaultView.RowFilter = "ms_cabinet_model_id = " & ConstantsData.CabinetModelId.MR
                        If dv.Count > 0 Then
                            'New Label Service Rate by Locker Size
                            Dim lblMRRate As New Label
                            lblMRRate.Text = dt(0)("service_rate")
                            lblMRRate.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                            lblMRRate.AutoSize = False
                            lblMRRate.TextAlign = ContentAlignment.MiddleCenter
                            lblMRRate.BorderStyle = BorderStyle.FixedSingle
                            lblMRRate.Size = New Size(100, 30)
                            lblMRRate.Location = New Point(180, 0)
                            lblMRRate.Margin = New Padding(0)
                            flpServiceRateHour.Controls.Add(lblMRRate)
                        End If
                        dt.DefaultView.RowFilter = ""

                        dt.DefaultView.RowFilter = "ms_cabinet_model_id = " & ConstantsData.CabinetModelId.LR
                        If dv.Count > 0 Then
                            'New Label Service Rate by Locker Size
                            Dim lblLRRate As New Label
                            lblLRRate.Text = dt(0)("service_rate")
                            lblLRRate.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                            lblLRRate.AutoSize = False
                            lblLRRate.TextAlign = ContentAlignment.MiddleCenter
                            lblLRRate.BorderStyle = BorderStyle.FixedSingle
                            lblLRRate.Size = New Size(100, 30)
                            lblLRRate.Location = New Point(180, 0)
                            lblLRRate.Margin = New Padding(0)
                            flpServiceRateHour.Controls.Add(lblLRRate)
                        End If
                        dt.DefaultView.RowFilter = ""

                        Application.DoEvents()
                    End If
                    ServiceRateData.ServiceRateHourList.DefaultView.RowFilter = ""
                Next

            End If
        End If
    End Sub

    Private Sub SetStaffConsoleAuthorize()
        If StaffConsole.AuthorizeInfo.Rows.Count > 0 Then
            AppScreenList.DefaultView.RowFilter = "id='" & Convert.ToInt16(KioskConfig.SelectForm) & "'"
            If AppScreenList.DefaultView.Count > 0 Then
                btnSyncData.Visible = False

                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=30 and authorization_name='Edit'"
                If StaffConsole.AuthorizeInfo.DefaultView.Count > 0 Then
                    btnSyncData.Visible = True
                End If
                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""
            End If
            AppScreenList.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub lblCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmLoading.Show(frmSC_Main)
        Application.DoEvents()
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleServiceRate_ClickCancel, "", False)
        Me.Close()
        frmSC_StockAndHardware.MdiParent = frmSC_Main
        frmSC_StockAndHardware.Show()
    End Sub

    Private Sub lblSyncData_Click(sender As Object, e As EventArgs) Handles lblSyncData.Click
        If MessageBox.Show("การทำงานนี้อาจใช้เวลานาน และจำเป็นต้องมีการเชื่อมต่ออินเตอร์เน็ต" & vbCrLf & "ต้องการทำรายการต่อไปหรือไม่?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            frmLoading.Show(frmSC_Main)
            Application.DoEvents()

            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleServiceRate_ClickSyncData, "", False)
            Engine.SyncMasterDataENG.SyncAllKioskMaster(KioskData.KioskID)
            Engine.SyncMasterDataENG.PullMasterServiceRate(KioskData.KioskID)
            Engine.SyncMasterDataENG.SyncMasterPromotion(KioskData.KioskID)
            Engine.SyncMasterDataENG.UpdateKioskPromotionExpired(KioskData.KioskID)

            SetData()
            frmLoading.Close()
        End If

    End Sub
End Class