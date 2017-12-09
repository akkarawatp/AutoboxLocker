Imports System.Data.SqlClient
Imports MiniboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Public Class frmCollectScanQRCode

    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Dim TimeOutCheckTime As DateTime = DateTime.Now


    Private Sub frmPickupScanQRCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.BackColor = bgColor

        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.CollectScanQRCode
    End Sub

    Private Sub frmPickupScanQRCode_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = True
        Me.WindowState = FormWindowState.Maximized

        txtQRCode.Text = ""
        txtQRCode.Focus()
        txtQRCode.Select()

        frmDepositPayment.MdiParent = frmMain
        SetDDLLocker()
        Application.DoEvents()

        InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_OpenForm, "", False)
        frmLoading.Close()
    End Sub

    Private Sub SetDDLLocker()
        LockerList.DefaultView.RowFilter = "current_available='N'"
        Dim lDt As New DataTable
        lDt = LockerList.DefaultView.ToTable.Copy
        If lDt.Rows.Count > 0 Then
            Dim dr As DataRow = lDt.NewRow
            dr("id") = 0
            dr("locker_name") = ""
            lDt.Rows.InsertAt(dr, 0)

            cbLocker.DataSource = lDt
            cbLocker.ValueMember = "id"
            cbLocker.DisplayMember = "locker_name"
        End If

        LockerList.DefaultView.RowFilter = ""
    End Sub



    Private Sub txtQRCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQRCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TimerTimeOut.Enabled = False
            frmLoading.Show(frmMain)
            Application.DoEvents()

            InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_CheckDataQRCode, "", False)
            If CheckDataQRCode(txtQRCode.Text) = True Then
                Collect.LostQRCode = "N"
                UpdateCollectTransaction(Collect)

                Me.Close()
                frmDepositPayment.Show()
            Else
                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_CheckDataQRCode, "QR Code ไม่ถูกต้อง Deposit Trans No=" & Collect.DepositTransNo, True)
                txtQRCode.Text = ""
                frmLoading.Close()

                Dim frm As New frmDialog_OK
                frm.lblMessage.Text = "Invalid QR Code"
                frm.ShowDialog(Me)
                TimerTimeOut.Enabled = True
            End If
            SendKioskAlarm("LOCKER_OUT_OF_SERVICE", False)
        End If
    End Sub

    Private Function CheckDataQRCode(QRCode As String) As Boolean
        Dim ret As Boolean = False
        Try
            'Check QR Code Digit
            '## QRCode Format TransactionID + TransactionNo + ID + Len(TransactionID)
            Dim str() As String = Split(QRCode, "ID")
            If str.Length = 2 Then
                Dim idLen As Int16 = Convert.ToInt16(str(1))
                Dim ServiceTransactionID As Long = Convert.ToInt64(str(0).Substring(0, idLen))
                Dim TransactionNo As String = str(0).Substring(idLen)
                Collect.DepositTransNo = TransactionNo

                Dim sql As String = "select t.id, t.trans_no, t.ms_locker_id, l.locker_name, l.pin_solenoid, l.pin_led, l.pin_sensor,  "
                sql += " t.service_rate, t.service_rate_limit_day, t.deposit_amt, t.paid_time, c.ms_cabinet_model_id "
                sql += " from TB_DEPOSIT_TRANSACTION t"
                sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
                sql += " inner join MS_CABINET c on c.id=l.ms_cabinet_id"
                sql += " where t.id=@_ID and t.trans_no=@_TRANSACTION_NO "
                sql += " and t.trans_status=@_TRANS_STATUS"
                sql += " and t.paid_time is not null "

                Dim p(3) As SqlParameter
                p(0) = KioskDB.SetBigInt("@_ID", ServiceTransactionID)
                p(1) = KioskDB.SetText("@_TRANSACTION_NO", TransactionNo)
                p(2) = KioskDB.SetText("@_TRANS_STATUS", Convert.ToInt16(DepositTransactionData.TransactionStatus.Success))

                Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
                If dt.Rows.Count > 0 Then
                    'กรณีพบข้อมูล ให้ตรวจสอบจะต้องไม่มีรายการรับคืนที่ Success แล้ว
                    sql = "select top 1 id "
                    sql += " from TB_PICKUP_TRANSACTION "
                    sql += " where deposit_trans_no=@_DEPOSIT_TRANS_NO "
                    sql += " and trans_status=@_PICKUP_TRANS_STATUS "

                    ReDim p(2)
                    p(0) = KioskDB.SetText("@_DEPOSIT_TRANS_NO", TransactionNo)
                    p(1) = KioskDB.SetText("@_PICKUP_TRANS_STATUS", Convert.ToInt16(CollectTransactionData.TransactionStatus.Success))

                    Dim pDt As DataTable = KioskDB.ExecuteTable(sql, p)
                    If pDt.Rows.Count = 0 Then
                        Dim dr As DataRow = dt.Rows(0)
                        ret = SetPickupInitialInformation(dr)
                    Else
                        ret = False
                    End If
                    pDt.Dispose()
                Else
                    '#################################################################################
                    'ถ้าไม่เจอให้หาจาก Service Transaction ที่มี Status Inprogress และมี deposit_trans_no ตรงกัน
                    '#################################################################################
                    sql = "select t.id, t.trans_no, t.ms_locker_id, l.locker_name, l.pin_solenoid, l.pin_led, l.pin_sensor,  "
                    sql += " t.service_rate, t.service_rate_limit_day, t.deposit_amt, t.paid_time, c.ms_cabinet_model_id "
                    sql += " from TB_DEPOSIT_TRANSACTION t"
                    sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
                    sql += " inner join MS_CABINET c on c.id=l.ms_cabinet_id"
                    sql += " where t.id=@_ID and t.trans_no=@_TRANSACTION_NO "
                    sql += " and t.trans_status=@_TRANS_STATUS"

                    Dim pp(3) As SqlParameter
                    pp(0) = KioskDB.SetBigInt("@_ID", ServiceTransactionID)
                    pp(1) = KioskDB.SetText("@_TRANSACTION_NO", TransactionNo)
                    p(2) = KioskDB.SetText("@_TRANS_STATUS", Convert.ToInt16(DepositTransactionData.TransactionStatus.Inprogress))

                    dt = KioskDB.ExecuteTable(sql, pp)
                    If dt.Rows.Count > 0 Then
                        Dim dr As DataRow = dt.Rows(0)
                        ret = SetPickupInitialInformation(dr)
                        If ret = True Then
                            Dim lnq As TbDepositTransactionKioskLinqDB = UpdateServiceTransactionKiosk(TransactionNo, KioskLockerStep.PickupScanQRCode_CheckDataQRCode)
                            If lnq.ID > 0 Then
                                If lnq.PAID_TIME.Value.Year <> 1 Then
                                    Collect.DepositPaidTime = lnq.PAID_TIME
                                Else
                                    Collect.DepositPaidTime = lnq.TRANS_END_TIME
                                End If
                            Else
                                ret = False
                            End If
                            lnq = Nothing
                        End If
                    Else
                        '#################################################################################
                        'ถ้าไม่เจออีก ให้หาจาก Service Transaction ที่ Server เลยโลด
                        '#################################################################################
                        Dim sP(2) As SqlParameter
                        sP(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_ID", ServiceTransactionID)
                        sP(1) = ServerLinqDB.ConnectDB.ServerDB.SetText("@_TRANSACTION_NO", TransactionNo)

                        dt = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, sP)
                        If dt.Rows.Count > 0 Then
                            Dim dr As DataRow = dt.Rows(0)
                            ret = SetPickupInitialInformation(dr)
                            If ret = True Then
                                Dim lnq As ServerLinqDB.TABLE.TbDepositTransactionServerLinqDB = UpdateServiceTransactionServer(TransactionNo, KioskLockerStep.PickupScanQRCode_CheckDataQRCode)
                                If lnq.ID > 0 Then
                                    If lnq.PAID_TIME.Value.Year <> 1 Then
                                        Collect.DepositPaidTime = lnq.PAID_TIME
                                    Else
                                        Collect.DepositPaidTime = lnq.TRANS_END_TIME
                                    End If
                                Else
                                    ret = False
                                End If
                                lnq = Nothing
                            End If
                        End If
                    End If
                End If
                dt.Dispose()
            Else
                ret = False
            End If

        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function


    Private Function SetPickupInitialInformation(dr As DataRow) As Boolean
        Dim ret As Boolean = False
        Try
            Collect.DepositTransNo = dr("trans_no")
            Collect.LockerID = Convert.ToInt64(dr("ms_locker_id"))
            Collect.LockerName = dr("locker_name").ToString
            If Convert.IsDBNull(dr("pin_solenoid")) = False Then Collect.LockerPinSolenoid = Convert.ToInt16(dr("pin_solenoid"))
            If Convert.IsDBNull(dr("pin_led")) = False Then Collect.LockerPinLED = Convert.ToInt16(dr("pin_led"))
            If Convert.IsDBNull(dr("pin_sensor")) = False Then Collect.LockerPinSendor = dr("pin_sensor")

            Collect.DepositAmount = Convert.ToInt64(dr("deposit_amt"))   'เงินค่ามัดจำที่ลูกค้าจ่ายแล้ว
            'Collect.ServiceRate = Convert.ToInt64(dr("service_rate"))
            'Collect.ServiceRateLimitDay = Convert.ToInt64(dr("service_rate_limit_day"))
            Collect.CabinetModelID = Convert.ToInt64(dr("ms_cabinet_model_id"))
            If Convert.IsDBNull(dr("paid_time")) = False Then
                Collect.DepositPaidTime = Convert.ToDateTime(dr("paid_time"))
            Else
                Collect.DepositPaidTime = Convert.ToDateTime(dr("trans_end_time"))
            End If

            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_CalServiceAmount, "", False)
            Collect.PickupTime = DateTime.Now
            Collect.ServiceAmount = PickupCalServiceAmount()

            Dim re As ExecuteDataInfo = UpdateCollectTransaction(Collect)
            ret = re.IsSuccess
        Catch ex As Exception
            ret = False
            InsertErrorLog("Exception " & ex.Message & vbNewLine & ex.StackTrace, "", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_CheckDataQRCode)
        End Try
        Return ret
    End Function

    'Private Function SetPickupInformation(dr As DataRow) As Boolean

    '    Collect.DepositTransNo = dr("trans_no")
    '    Collect.LockerID = Convert.ToInt64(dr("ms_locker_id"))
    '    Collect.LockerName = dr("locker_name").ToString
    '    If Convert.IsDBNull(dr("pin_solenoid")) = False Then Collect.LockerPinSolenoid = Convert.ToInt16(dr("pin_solenoid"))
    '    If Convert.IsDBNull(dr("pin_led")) = False Then Collect.LockerPinLED = Convert.ToInt16(dr("pin_led"))
    '    If Convert.IsDBNull(dr("pin_sensor")) = False Then Collect.LockerPinSendor = dr("pin_sensor")

    '    Collect.DepositAmount = Convert.ToInt64(dr("deposit_amt"))
    '    Collect.CabinetModelID = Convert.ToInt64(dr("ms_cabinet_model_id"))
    '    If Convert.IsDBNull(dr("paid_time")) = False Then
    '        Collect.DepositPaidTime = Convert.ToDateTime(dr("paid_time"))
    '    Else
    '        Collect.DepositPaidTime = Convert.ToDateTime(dr("trans_end_time"))
    '    End If

    '    Collect.PickupTime = DateTime.Now
    '    Collect.ServiceAmount = PickupCalServiceAmount()

    '    Dim re As ExecuteDataInfo = UpdateCollectTransaction(Collect)
    '    Return re.IsSuccess
    'End Function

    Private Sub TimerTimeOut_Tick(sender As Object, e As EventArgs) Handles TimerTimeOut.Tick
        'TimeOut = TimeOut - 1
        Application.DoEvents()
        'lblTimeOut.Text = TimeOut
        If TimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
            InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_Timeout, "", False)
            TimerTimeOut.Enabled = False
            UpdateCollectStatus(Collect.CollectTransactionID, DepositTransactionData.TransactionStatus.TimeOut, KioskLockerStep.PickupScanQRCode_Timeout)

            frmMain.CloseAllChildForm()
            Dim f As New frmHome
            f.MdiParent = frmMain
            f.Show()
        End If
    End Sub

    Private Sub frmPickupScanQRCode_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        txtQRCode.Focus()
    End Sub

    Private Sub frmPickupScanQRCode_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        txtQRCode.Focus()
    End Sub
#Region "Input Pin Code"

    Private Function CheckDepositDataByPinCode(PinCode As String, LockerID As Long) As Boolean
        Dim ret As Boolean = False
        Try
            Dim sql As String = "select t.id, t.trans_no, t.ms_locker_id, l.locker_name, l.pin_solenoid, l.pin_led, l.pin_sensor,  "
            sql += " t.deposit_amt, t.paid_time, t.trans_end_time, c.ms_cabinet_model_id "
            sql += " from TB_DEPOSIT_TRANSACTION t"
            sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
            sql += " inner join MS_CABINET c on c.id=l.ms_cabinet_id "
            sql += " where 1=1 "
            sql += " and t.pin_code=@_PIN_CODE and t.ms_locker_id=@_LOCKER_ID "
            sql += " and t.trans_status=@_TRANS_STATUS"
            sql += " and t.paid_time is not null"
            sql += " order by t.paid_time "

            Dim p(3) As SqlParameter
            p(0) = KioskDB.SetText("@_PIN_CODE", PinCode)
            p(1) = KioskDB.SetBigInt("@_LOCKER_ID", LockerID)
            p(2) = KioskDB.SetText("@_TRANS_STATUS", Convert.ToInt16(DepositTransactionData.TransactionStatus.Success))

            Dim lnq As New TbDepositTransactionKioskLinqDB
            Dim dt As DataTable = lnq.GetListBySql(sql, Nothing, p)
            If dt.Rows.Count > 0 Then
                For Each tmpDr As DataRow In dt.Rows
                    Dim DepositTransNo As String = tmpDr("trans_no")

                    'กรณีพบข้อมูล ให้ตรวจสอบจะต้องไม่มีรายการรับคืนที่ Success แล้ว
                    sql = "select top 1 id "
                    sql += " from TB_PICKUP_TRANSACTION "
                    sql += " where deposit_trans_no=@_DEPOSIT_TRANS_NO "
                    sql += " and ms_locker_id=@_LOCKER_ID"
                    sql += " and trans_status=@_PICKUP_TRANS_STATUS "

                    ReDim p(3)
                    p(0) = KioskDB.SetText("@_DEPOSIT_TRANS_NO", DepositTransNo)
                    p(1) = KioskDB.SetBigInt("@_LOCKER_ID", LockerID)
                    p(2) = KioskDB.SetText("@_PICKUP_TRANS_STATUS", Convert.ToInt16(CollectTransactionData.TransactionStatus.Success))

                    Dim pDt As DataTable = KioskDB.ExecuteTable(sql, p)
                    If pDt.Rows.Count = 0 Then
                        InsertLogTransactionActivity(DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_HaveData, "", False)

                        ret = SetPickupInitialInformation(tmpDr)
                        Exit For
                    Else
                        InsertLogTransactionActivity(DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_HaveData, "รายการฝาก TransNo=" & DepositTransNo & " ได้มีการรับคืนแล้ว จึงไม่สามารถทำรายการรับคืนได้อีก", False)
                        ret = False
                    End If
                    pDt.Dispose()
                Next
            Else
                InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_NoDataFound, "", False)

                Dim MsStepID As Long = KioskLockerStep.PickupScanQRCode_GetPickupWithPinCode

                '#################################################################################
                'ถ้าไม่เจอให้หาจาก Service Transaction ที่มี Status Inprogress และมี deposit_trans_no ตรงกัน
                '#################################################################################
                sql = "select t.id, t.trans_no, t.ms_locker_id, l.locker_name, l.pin_solenoid, l.pin_led, l.pin_sensor,  "
                sql += " t.deposit_amt, t.paid_time, c.ms_cabinet_model_id "
                sql += " from TB_DEPOSIT_TRANSACTION t"
                sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
                sql += " inner join MS_CABINET c on c.id=l.ms_cabinet_id "
                sql += " where t.trans_status=0 "  'Inprogress
                sql += " and t.pin_code=@_PIN_CODE and t.ms_locker_id=@_LOCKER_ID"

                ReDim p(2)
                p(0) = KioskDB.SetText("@_PIN_CODE", PinCode)
                p(1) = KioskDB.SetBigInt("@_LOCKER_ID", LockerID)
                dt = KioskDB.ExecuteTable(sql, p)
                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)
                    ret = SetPickupInitialInformation(dr)
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
                    ReDim p(2)
                    p(0) = KioskDB.SetText("@_PIN_CODE", PinCode)
                    p(1) = KioskDB.SetBigInt("@_LOCKER_ID", LockerID)

                    dt = ServerLinqDB.ConnectDB.ServerDB.ExecuteTable(sql, p)
                    If dt.Rows.Count > 0 Then
                        Dim dr As DataRow = dt.Rows(0)
                        ret = SetPickupInitialInformation(dr)
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
            InsertErrorLog("Exception : " & ex.Message & " " & ex.StackTrace, Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_GetPickupDataFail)
        End Try

        Return ret
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        TimerTimeOut.Enabled = False
        frmLoading.Show(frmMain)
        Application.DoEvents()
        InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_GetPickupWithPinCode, "", False)

        If CheckDepositDataByPinCode(txtPincode.Text, cbLocker.SelectedValue) = True Then
            Collect.LostQRCode = "Y"
            UpdateCollectTransaction(Collect)

            Me.Close()
            frmDepositPayment.Show()
        Else
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_GetPickupWithPinCode, "Pin Code ไม่ถูกต้อง Deposit Trans No=" & Collect.DepositTransNo, True)
            txtQRCode.Text = ""
            frmLoading.Close()

            ShowDialogErrorMessage("Invalid PIN Code")
            txtPincode.Text = ""
            TimerTimeOut.Enabled = True
            txtQRCode.Focus()
        End If
    End Sub
    Private Sub InsertNumber(ByVal Num As Int16)
        txtPincode.Text = txtPincode.Text & Num
        TimeOutCheckTime = DateTime.Now
        txtQRCode.Focus()
    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        txtPincode.Text = ""
        TimeOutCheckTime = DateTime.Now
        txtQRCode.Focus()
    End Sub

    Private Sub btnNumber0_Click(sender As Object, e As EventArgs) Handles btnNumber0.Click
        InsertNumber(0)
    End Sub

    Private Sub btnNumber1_Click(sender As Object, e As EventArgs) Handles btnNumber1.Click
        InsertNumber(1)
    End Sub

    Private Sub btnNumber2_Click(sender As Object, e As EventArgs) Handles btnNumber2.Click
        InsertNumber(2)
    End Sub

    Private Sub btnNumber3_Click(sender As Object, e As EventArgs) Handles btnNumber3.Click
        InsertNumber(3)
    End Sub

    Private Sub btnNumber4_Click(sender As Object, e As EventArgs) Handles btnNumber4.Click
        InsertNumber(4)
    End Sub

    Private Sub btnNumber5_Click(sender As Object, e As EventArgs) Handles btnNumber5.Click
        InsertNumber(5)
    End Sub

    Private Sub btnNumber6_Click(sender As Object, e As EventArgs) Handles btnNumber6.Click
        InsertNumber(6)
    End Sub

    Private Sub btnNumber7_Click(sender As Object, e As EventArgs) Handles btnNumber7.Click
        InsertNumber(7)
    End Sub

    Private Sub btnNumber8_Click(sender As Object, e As EventArgs) Handles btnNumber8.Click
        InsertNumber(8)
    End Sub

    Private Sub btnNumber9_Click(sender As Object, e As EventArgs) Handles btnNumber9.Click
        InsertNumber(9)
    End Sub

    Private Sub btnNumber_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNumber0.MouseDown, btnNumber1.MouseDown, btnNumber2.MouseDown, btnNumber3.MouseDown, btnNumber4.MouseDown, btnNumber5.MouseDown, btnNumber6.MouseDown, btnNumber7.MouseDown, btnNumber8.MouseDown, btnNumber9.MouseDown
        Dim btn As PictureBox = sender
        btn.BackColor = Color.Gray
    End Sub

    Private Sub btnNumber_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNumber0.MouseUp, btnNumber1.MouseUp, btnNumber2.MouseUp, btnNumber3.MouseUp, btnNumber4.MouseUp, btnNumber5.MouseUp, btnNumber6.MouseUp, btnNumber7.MouseUp, btnNumber8.MouseUp, btnNumber9.MouseUp
        Dim btn As PictureBox = sender
        btn.BackColor = Color.Transparent
    End Sub



#End Region
End Class