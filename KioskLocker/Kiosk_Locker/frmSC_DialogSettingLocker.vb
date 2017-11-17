Imports KioskLinqDB.TABLE
Imports KioskLinqDB.ConnectDB
Imports AutoboxLocker.Data.KioskConfigData
Imports System.Data.SqlClient
Public Class frmSC_DialogSettingLocker
    Dim _LockerID As Long = 0
    Public WriteOnly Property LockerID As Long
        Set(value As Long)
            _LockerID = value

        End Set
    End Property

    Private Sub LoadLockerInfo()
        Try
            Dim lnq As New MsLockerKioskLinqDB
            lnq.GetDataByPK(_LockerID, Nothing)
            If lnq.ID > 0 Then
                'lblLayoutName.Text = lnq.LAYOUT_NAME
                txtLockerName.Text = lnq.LOCKER_NAME
                cbSolenoidPin.SelectedValue = lnq.PIN_SOLENOID
                cbLEDPin.SelectedValue = lnq.PIN_LED
                cbSensorPin.SelectedValue = lnq.PIN_SENSOR
                lblLockerSize.Text = lnq.MODEL_NAME

                'Check Current Transaction
                If CheckCurrentStatus(lnq.ID, lnq.CURRENT_AVAILABLE) = False Then
                    lblAvailable.BackColor = Color.SkyBlue
                    lblAvailable.ForeColor = Color.Black
                    lblAvailable.Text = "Available"
                    btnCancelByAdmin.Visible = False
                Else
                    lblAvailable.BackColor = Color.Black
                    lblAvailable.ForeColor = Color.White
                    lblAvailable.Text = "Unavailable"
                    btnCancelByAdmin.Visible = True
                End If
                chkActive.Checked = (lnq.ACTIVE_STATUS = "Y")
            End If
            lnq = Nothing
        Catch ex As Exception

        End Try
    End Sub


    Private Function CheckCurrentStatus(LockerID As Long, LockerCurrentAvaiilable As Char) As Boolean
        Dim ret As Boolean = False
        Try
            Dim DepositTransNo As String = CheckDepositTransNoCollect(LockerID)
            If DepositTransNo <> "" Then
                ret = True  'ตู้ไม่ว่าง
            Else
                'กรณีไม่พบข้อมูล ตรวจสอบว่าสถานะตู้เป็นไม่ว่างหรือไม่
                If LockerCurrentAvaiilable = "N" Then
                    ret = True  'ตู้ไม่ว่าง
                End If
            End If
        Catch ex As Exception

        End Try

        Return ret
    End Function

    Private Sub frmSC_SettingLocker_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CheckForIllegalCrossThreadCalls = False
        KioskConfig.SelectForm = KioskLockerForm.StaffConsoleLockerSetting
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Open form frmSC_SettingLocker", False)

        'Dim sol As New BoardSolenoid.SolenoidClass
        BoardSolenoid.BindSolenoidPin(cbSolenoidPin)

        'Dim led As New BoardLED.LEDClass
        BoardLED.BindLEDPin(cbLEDPin)

        'Dim sensor As New BoardSensor.SensorClass
        BoardSensor.BindSensorPin(cbSensorPin)

        LoadLockerInfo()
    End Sub

    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles lblSave.Click, btnSave.Click
        Try
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Save Data", False)

            Dim lnq As New MsLockerKioskLinqDB
            If lnq.ChkDuplicateByLOCKER_NAME_MS_KIOSK_ID(txtLockerName.Text, KioskData.KioskID, _LockerID, Nothing) = True Then
                InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Save Fail Duplicate Locker Name" + txtLockerName.Text, True)
                MessageBox.Show("Duplicate Locker Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lnq = Nothing
                Exit Sub
            End If

            lnq.GetDataByPK(_LockerID, Nothing)
            If lnq.ID > 0 Then
                'lnq.LAYOUT_NAME = lblLayoutName.Text
                lnq.LOCKER_NAME = txtLockerName.Text
                lnq.PIN_SOLENOID = cbSolenoidPin.SelectedValue
                lnq.PIN_LED = cbLEDPin.SelectedValue
                lnq.PIN_SENSOR = cbSensorPin.SelectedValue
                lnq.ACTIVE_STATUS = IIf(chkActive.Checked = True, "Y", "N")
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                Dim ret As ExecuteDataInfo = lnq.UpdateData(StaffConsole.Username, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                    SetLockerList()

                    InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Save Success", False)
                    MessageBox.Show("บันทีกข้อมูลเรียบร้อย", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    trans.RollbackTransaction()
                    InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Save Fail " & ret.ErrorMessage, True)
                    InsertErrorLogSC(StaffConsole.Username, ret.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                    MessageBox.Show(ret.ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Save Fail " & ex.Message & vbCrLf & ex.StackTrace, True)
            InsertErrorLogSC(StaffConsole.Username, ex.Message & vbCrLf & ex.StackTrace, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Close Form", False)
        Me.Close()
    End Sub

    Private Sub btnOpenSoleniod_Click(sender As Object, e As EventArgs) Handles btnOpenSoleniod.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Open Solenoid Pin " & cbSolenoidPin.SelectedValue, False)
        BoardSolenoid.SolenoidOpen(cbSolenoidPin.SelectedValue)
    End Sub

    Private Sub btnStartLED_Click(sender As Object, e As EventArgs) Handles btnStartLED.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Start LED Pin " & cbLEDPin.SelectedValue, False)
        BoardLED.LEDStart(cbLEDPin.SelectedValue)
    End Sub

    Private Sub btnBlink_Click(sender As Object, e As EventArgs) Handles btnBlink.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Blink LED Pin " & cbLEDPin.SelectedValue, False)
        BoardLED.LEDBlinkOn(cbLEDPin.SelectedValue)
    End Sub

    Private Sub btnStopLED_Click(sender As Object, e As EventArgs) Handles btnStopLED.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Stop LED Pin " & cbLEDPin.SelectedValue, False)
        BoardLED.LEDStop(cbLEDPin.SelectedValue)
    End Sub

    Private Sub btnStartSensor_Click(sender As Object, e As EventArgs) Handles btnStartSensor.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Start Sensor Pin " & cbSensorPin.SelectedValue, False)
        BoardSensor.SensorRequestData(cbSensorPin.SelectedValue)
        AddHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
    End Sub

    Private Sub btnStopSensor_Click(sender As Object, e As EventArgs) Handles btnStopSensor.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Stop Sensor Pin " & cbSensorPin.SelectedValue, False)
        RemoveHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
    End Sub

    Private Sub SensorDataReceived(ByVal ReceiveData As String)
        If ReceiveData = "" Then Exit Sub
        lblSensorFlag.Text = IIf(ReceiveData.Trim = "0", "Open", "Close")
        Application.DoEvents()
        BoardSensor.SensorRequestData(cbSensorPin.SelectedValue)
    End Sub

    Private Function CheckDepositTransNoCollect(LockerID As Long) As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select t.id, t.trans_no, t.ms_locker_id "
            sql += " from TB_DEPOSIT_TRANSACTION t"
            sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
            sql += " where t.ms_locker_id=@_LOCKER_ID "
            sql += " and t.trans_status=@_TRANS_STATUS "
            sql += " and t.paid_time is not null "

            Dim p(2) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_LOCKER_ID", LockerID)
            p(1) = KioskDB.SetInt("@_TRANS_STATUS", Convert.ToInt16(DepositTransactionData.TransactionStatus.Success))

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(dt.Rows.Count - 1)

                'กรณีพบข้อมูล ให้ตรวจสอบจะต้องไม่มีรายการรับคืนที่ Success แล้ว
                sql = "select id, trans_status "
                sql += " from TB_PICKUP_TRANSACTION "
                sql += " where deposit_trans_no=@_DEPOSIT_TRANS_NO "
                'sql += " and trans_status not in (" & Convert.ToInt16(CollectTransactionData.TransactionStatus.Success) & ") "

                ReDim p(1)
                p(0) = KioskDB.SetText("@_DEPOSIT_TRANS_NO", dr("trans_no"))
                'p(1) = KioskDB.SetInt("@_PICKUP_TRANS_STATUS", Convert.ToInt16(CollectTransactionData.TransactionStatus.Success))

                Dim pDt As DataTable = KioskDB.ExecuteTable(sql, p)
                If pDt IsNot Nothing Then
                    If pDt.Rows.Count > 0 Then
                        'ถ้ามีรายการรับคืน ให้ตรวจสอบว่าจะต้องไม่มีรายการรับคืนที่สำเร็จ
                        pDt.DefaultView.RowFilter = "trans_status=" & Convert.ToInt16(CollectTransactionData.TransactionStatus.Success)
                        If pDt.DefaultView.Count = 0 Then
                            ret = dr("trans_no")
                        End If
                        pDt.DefaultView.RowFilter = ""
                    Else
                        'ถ้าไม่มีรายการรับคืนเลย
                        ret = dr("trans_no")
                    End If
                End If
                pDt.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = ""
        End Try
        Return ret
    End Function

    Private Sub btnCancelByAdmin_Click(sender As Object, e As EventArgs) Handles btnCancelByAdmin.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Cancel by Admin Locker " & txtLockerName.Text, False)
        Try
            Dim DepositTransNo As String = CheckDepositTransNoCollect(_LockerID)
            Dim CollectTransNo As String = ""
            Dim ret As New ExecuteDataInfo
            Dim trans As New KioskTransactionDB

            If DepositTransNo.Trim <> "" Then
                Dim dLnq As New TbDepositTransactionKioskLinqDB
                dLnq.ChkDataByTRANS_NO(DepositTransNo, trans.Trans)
                If dLnq.ID > 0 Then
                    dLnq.TRANS_STATUS = Convert.ToInt16(DepositTransactionData.TransactionStatus.CancelByAdmin).ToString
                    dLnq.SYNC_TO_SERVER = "N"

                    ret = dLnq.UpdateData(StaffConsole.Username, trans.Trans)
                    If ret.IsSuccess = True Then
                        InsertLogTransactionActivity(DepositTransNo, "", StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Clear Deposit Transaction No " & DepositTransNo, False)

                        Dim p(1) As SqlParameter
                        p(0) = KioskDB.SetText("@_DEPOSIT_TRANS_NO", dLnq.TRANS_NO)

                        Dim pLnq As New TbPickupTransactionKioskLinqDB
                        pLnq.ChkDataByWhere("deposit_trans_no=@_DEPOSIT_TRANS_NO", trans.Trans, p)

                        If pLnq.ID > 0 Then
                            CollectTransNo = pLnq.TRANSACTION_NO

                            pLnq.TRANS_STATUS = Convert.ToInt16(CollectTransactionData.TransactionStatus.CancelByAdmin).ToString
                            pLnq.SYNC_TO_SERVER = "N"

                            ret = pLnq.UpdateData(StaffConsole.Username, trans.Trans)
                            If ret.IsSuccess = True Then
                                InsertLogTransactionActivity(DepositTransNo, pLnq.TRANSACTION_NO, StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Clear Collect Transaction No " & pLnq.TRANSACTION_NO, False)
                            End If
                        End If
                    End If
                Else
                    'เคสนี้ไม่น่าเกิด
                    ret.IsSuccess = True
                End If
            Else
                'ถ้าไม่มีรายการฝากเลย ให้ Clear Status ของช่องฝากอย่างเดียว
                ret.IsSuccess = True
            End If

            If ret.IsSuccess = True Then
                Dim lnq As New MsLockerKioskLinqDB
                lnq.GetDataByPK(_LockerID, trans.Trans)
                If lnq.ID > 0 Then
                    lnq.CURRENT_AVAILABLE = "Y"
                    lnq.SYNC_TO_SERVER = "N"

                    ret = lnq.UpdateData(StaffConsole.Username, trans.Trans)
                    If ret.IsSuccess = True Then
                        trans.CommitTransaction()

                        lblAvailable.BackColor = Color.SkyBlue
                        lblAvailable.Text = "Available"
                        lblAvailable.ForeColor = Color.Black
                        btnCancelByAdmin.Visible = False
                        SetLockerList()

                        InsertLogTransactionActivity(DepositTransNo, CollectTransNo, StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Clear Status Success", False)
                        MessageBox.Show("Clear Status ตู้ที่ " & txtLockerName.Text & " เรียบร้อย", "Clear Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    Else
                        trans.RollbackTransaction()
                        InsertLogTransactionActivity(DepositTransNo, CollectTransNo, StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Clear Status Fail " & ret.ErrorMessage, True)
                        InsertErrorLogSC(StaffConsole.Username, ret.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                        MessageBox.Show(ret.ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    trans.RollbackTransaction()
                    InsertLogTransactionActivity(DepositTransNo, CollectTransNo, StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "No Locker Data " & lnq.ErrorMessage, True)
                    InsertErrorLogSC(StaffConsole.Username, lnq.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                    MessageBox.Show(lnq.ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                lnq = Nothing
            Else
                trans.RollbackTransaction()
                InsertLogTransactionActivity(DepositTransNo, CollectTransNo, StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, ret.ErrorMessage, True)
                InsertErrorLogSC(StaffConsole.Username, ret.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                MessageBox.Show(ret.ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.KioskLockerForm.StaffConsoleLockerSetting, KioskLockerStep.StaffConsoleLockerSetting_LockerDbClick, "Clear Status Fail " & ex.Message & vbCrLf & ex.StackTrace, True)
            InsertErrorLogSC(StaffConsole.Username, ex.Message & vbCrLf & ex.StackTrace, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class