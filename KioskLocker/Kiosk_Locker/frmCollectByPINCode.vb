Imports System.Data.SqlClient
Imports AutoboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE

Public Class frmCollectByPINCode
    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Dim TimeOutCheckTime As DateTime = DateTime.Now

    Const DefaultNotictText As String = "กรุณาใส่รหัสส่วนตัว {0} หลักสำหรับรับคืนสัมภาระ"

    Private Sub frmDepositSetPINCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        KioskConfig.SelectForm = KioskLockerForm.CollectByPincode
    End Sub
    Private Sub frmCollectByPINCode_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = True
        lblLabelNotification.Text = String.Format(DefaultNotictText, KioskConfig.PincodeLen)

        Application.DoEvents()
        InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupByPinCode_OpenForm, "", False)
        TimeOutCheckTime = DateTime.Now
        TimerTimeOut.Enabled = True

    End Sub


    Private Sub TimerTimeOut_Tick(sender As Object, e As EventArgs) Handles TimerTimeOut.Tick
        If KioskConfig.SelectForm = KioskLockerForm.CollectByPincode Then
            Application.DoEvents()
            'lblTimeOut.Text = TimeOut
            If TimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
                TimerTimeOut.Enabled = False
                TimerTimeOut.Stop()

                UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.TimeOut, KioskLockerStep.PickupByPinCode_Timeout)
                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupByPinCode_Timeout, " ลูกค้าไม่ทำรายการภายในเวลาที่กำหนด", False)

                frmMain.CloseAllChildForm()
                Dim f As New frmHome
                f.MdiParent = frmMain
                f.Show()
            End If
        End If
    End Sub


    Private Function CheckDepositDataByPinCode(PinCode As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim p(2) As SqlParameter

            Dim sql As String = "select t.id, t.trans_no, t.ms_locker_id, l.locker_name, l.pin_solenoid, l.pin_led, l.pin_sensor,  "
            sql += " t.deposit_amt, t.paid_time, t.trans_end_time, c.ms_cabinet_model_id "
            sql += " from TB_DEPOSIT_TRANSACTION t"
            sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
            sql += " inner join MS_CABINET c on c.id=l.ms_cabinet_id "
            sql += " where 1=1 "
            sql += " and t.pin_code=@_PIN_CODE "
            sql += " and t.trans_status=@_TRANS_STATUS"
            sql += " and t.paid_time is not null"
            sql += " order by t.paid_time "

            p(0) = KioskDB.SetText("@_PIN_CODE", PinCode)
            p(1) = KioskDB.SetText("@_TRANS_STATUS", Convert.ToInt16(DepositTransactionData.TransactionStatus.Success))

            Dim lnq As New TbDepositTransactionKioskLinqDB
            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing, p)
            If dt.Rows.Count > 0 Then
                For Each tmpDr As DataRow In dt.Rows
                    Dim DepositTransNo As String = tmpDr("trans_no")

                    'กรณีพบข้อมูล ให้ตรวจสอบจะต้องไม่มีรายการรับคืนที่ Success แล้ว
                    sql = "select top 1 id "
                    sql += " from TB_PICKUP_TRANSACTION "
                    sql += " where deposit_trans_no=@_DEPOSIT_TRANS_NO "
                    sql += " and trans_status=@_PICKUP_TRANS_STATUS "

                    ReDim p(2)
                    p(0) = KioskDB.SetText("@_DEPOSIT_TRANS_NO", DepositTransNo)
                    p(1) = KioskDB.SetText("@_PICKUP_TRANS_STATUS", Convert.ToInt16(CollectTransactionData.TransactionStatus.Success))

                    Dim pDt As DataTable = KioskDB.ExecuteTable(sql, p)
                    If pDt.Rows.Count = 0 Then
                        InsertLogTransactionActivity(DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupByPinCode_HaveData, "", False)

                        ret = SetPickupInformation(tmpDr)
                        Exit For
                    Else
                        InsertLogTransactionActivity(DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupByPinCode_HaveData, "รายการฝาก TransNo=" & DepositTransNo & " ได้มีการรับคืนแล้ว จึงไม่สามารถทำรายการรับคืนได้อีก", False)
                        ret = False
                    End If
                    pDt.Dispose()
                Next
            Else
                InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupByPinCode_NoDataFound, "", False)

                Dim MsStepID As Long = KioskLockerStep.PickupByPinCode_GetPickupWithPinCode

                '#################################################################################
                'ถ้าไม่เจอให้หาจาก Service Transaction ที่มี Status Inprogress และมี deposit_trans_no ตรงกัน
                '#################################################################################
                sql = "select t.id, t.trans_no, t.ms_locker_id, l.locker_name, l.pin_solenoid, l.pin_led, l.pin_sensor,  "
                sql += " t.deposit_amt, t.paid_time, c.ms_cabinet_model_id "
                sql += " from TB_DEPOSIT_TRANSACTION t"
                sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
                sql += " inner join MS_CABINET c on c.id=l.ms_cabinet_id "
                sql += " where t.trans_status=0 "  'Inprogress
                sql += " and t.pin_code=@_PIN_CODE"

                Dim pp(1) As SqlParameter
                pp(0) = KioskDB.SetText("@_PIN_CODE", PinCode)
                dt = KioskDB.ExecuteTable(sql, pp)
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)
                    ret = SetPickupInformation(dr)
                    If ret = True Then
                        Dim kLnq As TbDepositTransactionKioskLinqDB = UpdateServiceTransactionKiosk(dr("trans_no"), MsStepID)
                        If kLnq.ID > 0 Then
                            Collect.DepositPaidTime = kLnq.PAID_TIME
                        End If
                        kLnq = Nothing
                    End If
                Else
                    '#################################################################################
                    'ถ้าไม่เจออีก ให้หาจาก Service Transaction ที่ Server เลยโลด
                    '#################################################################################
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsStepID, "หารายการฝากที่มี Trans_Status=0 จาก Server ด้วย Pin Code=" & PinCode, False)
                    Dim sP(1) As SqlParameter
                    sP(0) = KioskDB.SetText("@_PIN_CODE", PinCode)
                    dt = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, sP)
                    If dt.Rows.Count > 0 Then
                        Dim dr As DataRow = dt.Rows(0)
                        ret = SetPickupInformation(dr)
                        If ret = True Then
                            Dim sLnq As ServerLinqDB.TABLE.TbDepositTransactionServerLinqDB = UpdateServiceTransactionServer(dr("trans_no"), MsStepID)
                            If sLnq.ID > 0 Then
                                Collect.DepositPaidTime = sLnq.PAID_TIME
                            End If
                            sLnq = Nothing
                        End If
                    End If
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = False
            InsertErrorLog("Exception : " & ex.Message & " " & ex.StackTrace, Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupByPinCode_GetPickupDataFail)
        End Try

        Return ret
    End Function

    Private Function SetPickupInformation(dr As DataRow) As Boolean

        Collect.DepositTransNo = dr("trans_no")
        Collect.LockerID = Convert.ToInt64(dr("ms_locker_id"))
        Collect.LockerName = dr("locker_name").ToString
        If Convert.IsDBNull(dr("pin_solenoid")) = False Then Collect.LockerPinSolenoid = Convert.ToInt16(dr("pin_solenoid"))
        If Convert.IsDBNull(dr("pin_led")) = False Then Collect.LockerPinLED = Convert.ToInt16(dr("pin_led"))
        If Convert.IsDBNull(dr("pin_sensor")) = False Then Collect.LockerPinSendor = dr("pin_sensor")

        Collect.DepositAmount = Convert.ToInt64(dr("deposit_amt"))
        Collect.CabinetModelID = Convert.ToInt64(dr("ms_cabinet_model_id"))
        If Convert.IsDBNull(dr("paid_time")) = False Then
            Collect.DepositPaidTime = Convert.ToDateTime(dr("paid_time"))
        Else
            Collect.DepositPaidTime = Convert.ToDateTime(dr("trans_end_time"))
        End If

        Collect.PickupTime = DateTime.Now
        Collect.ServiceAmount = PickupCalServiceAmount()

        Dim re As ExecuteDataInfo = UpdateCollectTransaction(Collect)
        Return re.IsSuccess
    End Function

#Region "Fill in PIN CODE"

    Private Sub InsertNumber(ByVal Num As Int16)
        txtPinCode.Text = txtPinCode.Text & Num
        TimeOutCheckTime = DateTime.Now

        If txtPinCode.Text.Length = KioskConfig.PincodeLen Then
            TimerTimeOut.Enabled = False
            TimerTimeOut.Stop()

            frmLoading.Show(frmMain)
            If CheckDepositDataByPinCode(txtPinCode.Text) = True Then
                frmDepositPayment.MdiParent = frmMain
                frmDepositPayment.Show()
                frmLoading.Close()
                Application.DoEvents()

                Me.Close()
            Else
                'ยืนยันรหัสส่วนตัวไม่ตรงกัน ให้เริ่มขั้นตอนใหม่
                lblLabelNotification.Text = String.Format(DefaultNotictText, KioskConfig.PincodeLen)
                txtPinCode.Text = ""

                InsertLogTransactionActivity(Deposit.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupByPinCode_GetPickupDataFail, "Error Update Deposit Data", True)
                ShowDialogErrorMessage("รหัสส่วนตัวไม่ถูกต้อง กรุณาลองใหม่อีกครั้ง")
                Application.DoEvents()

                TimeOutCheckTime = DateTime.Now
                TimerTimeOut.Enabled = True
                TimerTimeOut.Start()
            End If
            frmLoading.Close()
        End If
    End Sub
    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        InsertNumber(0)
    End Sub
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        InsertNumber(1)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        InsertNumber(2)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        InsertNumber(3)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        InsertNumber(4)
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        InsertNumber(5)
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        InsertNumber(6)
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        InsertNumber(7)
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        InsertNumber(8)
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        InsertNumber(9)
    End Sub

    Private Sub btnBackSpace_Click(sender As Object, e As EventArgs) Handles btnBackSpace.Click
        If txtPinCode.Text <> "" Then
            txtPinCode.Text = txtPinCode.Text.Substring(0, txtPinCode.Text.Length - 1)
        End If

        TimeOutCheckTime = DateTime.Now
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtPinCode.Text = ""
        TimeOutCheckTime = DateTime.Now
    End Sub
#End Region

End Class