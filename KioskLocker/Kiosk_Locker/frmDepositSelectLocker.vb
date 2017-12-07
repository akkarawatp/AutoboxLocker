Imports System.Data.SqlClient
Imports KioskLinqDB.ConnectDB
Imports AutoboxLocker.Data.KioskConfigData
Public Class frmDepositSelectLocker
    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Dim TimeOutCheckTime As DateTime = DateTime.Now

    Private Sub frmDepositSelectLocker_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        Me.BackColor = bgColor

        If ServiceID = Data.ConstantsData.TransactionType.DepositBelonging Then
            KioskConfig.SelectForm = KioskLockerForm.DepositSelectLocker
        ElseIf ServiceID = Data.ConstantsData.TransactionType.CollectBelonging Then
            KioskConfig.SelectForm = KioskLockerForm.StaffConsoleCollectSelectLocker
        End If
    End Sub
    Private Sub frmDepositSelectLocker_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'หน้าจอ เลือกช่องฝากใช้สำหรับกรณี
        'ลูกค้าทำรายการฝาก
        'Staff Console ทำรายการรับคืนเพื่อเปิดตู้ให้ลูกค้า
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = True
        Me.WindowState = FormWindowState.Maximized

        Application.DoEvents()
        If ServiceID = Data.ConstantsData.TransactionType.DepositBelonging Then
            InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_OpenForm, "", False)
        ElseIf ServiceID = Data.ConstantsData.TransactionType.CollectBelonging Then
            InsertLogTransactionActivity("", Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleCollectSelectLocker_OpenForm, "", False)
        End If

        TimeOutCheckTime = DateTime.Now
        TimerTimeOut.Enabled = True
        frmLoading.Close()
    End Sub

    Dim AllPadding As Integer = 1
    Dim PcWidth As Integer = 75

    Public Sub LoadLockerList()
        Try
            InsertLogTransactionActivity("", "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_LoadLockerList, "", False)
            Dim cbWith As Integer = 0
            UcCabinet1.LoadCabinetData(False, CabinetList)
            If UcCabinet1.LockerActiveQty > 0 Then
                cbWith += UcCabinet1.Width + AllPadding
            End If

            UcCabinet2.LoadCabinetData(False, CabinetList)
            If UcCabinet2.LockerActiveQty > 0 Then
                cbWith += UcCabinet2.Width + AllPadding
            End If

            UcCabinet3.LoadCabinetData(False, CabinetList)
            If UcCabinet3.LockerActiveQty > 0 Then
                cbWith += UcCabinet3.Width + AllPadding
            End If

            UcCabinet4.LoadCabinetData(False, CabinetList)
            If UcCabinet4.LockerActiveQty > 0 Then
                cbWith += UcCabinet4.Width + AllPadding
            End If

            UcCabinet5.LoadCabinetData(False, CabinetList)
            If UcCabinet5.LockerActiveQty > 0 Then
                cbWith += UcCabinet5.Width + AllPadding
            End If

            UcCabinet6.LoadCabinetData(False, CabinetList)
            If UcCabinet6.LockerActiveQty > 0 Then
                cbWith += UcCabinet6.Width + AllPadding
            End If

            UcCabinet7.LoadCabinetData(False, CabinetList)
            If UcCabinet7.LockerActiveQty > 0 Then
                cbWith += UcCabinet7.Width + AllPadding
            End If

            UcCabinet8.LoadCabinetData(False, CabinetList)
            If UcCabinet8.LockerActiveQty > 0 Then
                cbWith += UcCabinet8.Width + AllPadding
            End If

            UcCabinet9.LoadCabinetData(False, CabinetList)
            If UcCabinet9.LockerActiveQty > 0 Then
                cbWith += UcCabinet9.Width + AllPadding
            Else
                UcCabinet9.Visible = False
            End If

            UcCabinet10.LoadCabinetData(False, CabinetList)
            If UcCabinet10.LockerActiveQty > 0 Then
                cbWith += UcCabinet10.Width + AllPadding
            Else
                UcCabinet10.Visible = False
            End If


            'วิธีการคำนวณ 
            'ความกว้างทั้งหมดคือ (oQty*61)
            Dim AllCabinetWidth As Integer = (cbWith + PcWidth + AllPadding)

            pnlCabinetLayout.Width = AllCabinetWidth + 15
            pnlCabinetLayout.Left = (Me.Width / 2) - (pnlCabinetLayout.Width / 2)



            Dim pLeft As Integer = (pnlCabinetLayout.Width / 2) - (AllCabinetWidth / 2) + 1
            pLeft = SetCabinetPosition(UcCabinet1, pLeft, 1)
            pLeft = SetCabinetPosition(UcCabinet2, pLeft, 2)
            pLeft = SetCabinetPosition(UcCabinet3, pLeft, 3)
            pLeft = SetCabinetPosition(UcCabinet4, pLeft, 4)
            pLeft = SetCabinetPosition(UcCabinet5, pLeft, 5)
            pLeft = SetCabinetPosition(UcCabinet6, pLeft, 6)
            pLeft = SetCabinetPosition(UcCabinet7, pLeft, 7)
            pLeft = SetCabinetPosition(UcCabinet8, pLeft, 8)
            pLeft = SetCabinetPosition(UcCabinet9, pLeft, 9)
            pLeft = SetCabinetPosition(UcCabinet10, pLeft, 10)
        Catch ex As Exception
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace, Deposit.DepositTransNo, 0, 0, KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_LoadLockerList)
        End Try

    End Sub

    Private Function SetCabinetPosition(uc As ucCabinet, pLeft As Integer, ucSeq As Integer) As Integer
        If KioskConfig.LockerPCPosition = ucSeq Then
            pnlLayoutPC.Left = pLeft
            pLeft = pLeft + PcWidth + AllPadding
        End If

        If uc.LockerActiveQty > 0 Then
            uc.Left = pLeft
            pLeft = pLeft + uc.Width + AllPadding
        Else
            uc.Visible = False
        End If
        Application.DoEvents()
        Return pLeft
    End Function



    Private Sub UcCabinet1_LockerClick(f As ucLockerInfo) Handles UcCabinet1.LockerClick, UcCabinet2.LockerClick, UcCabinet3.LockerClick, UcCabinet4.LockerClick, UcCabinet5.LockerClick, UcCabinet6.LockerClick, UcCabinet7.LockerClick, UcCabinet8.LockerClick, UcCabinet9.LockerClick, UcCabinet10.LockerClick
        'MessageBox.Show(LockerID)

        If ServiceID = Data.ConstantsData.TransactionType.DepositBelonging Then
            If f.LockerAvailable = ucLockerInfo.AvailableStatus.Availabled Then
                TimeOutCheckTime = DateTime.Now
                TimerTimeOut.Enabled = False
                TimerTimeOut.Stop()

                frmLoading.Show(frmMain)

                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_SelectLocker, " " & f.txtLockerName.Text, False)

                Application.DoEvents()

                Deposit.LockerID = f.LockerID
                Deposit.LockerName = f.txtLockerName.Text
                Deposit.CabinetID = f.CabinetID
                Deposit.CabinetModelID = f.CabinetModelID
                Deposit.LockerPinSolenoid = f.cbSolenoidPin.SelectedValue
                Deposit.LockerPinLED = f.cbLEDPin.SelectedValue
                Deposit.LockerPinSendor = f.cbSensorPin.SelectedValue

                'เลือกช่องฝากแล้วก็ Update Transaction โลด
                If UpdateServiceTransaction(Deposit).IsSuccess = True Then
                    Me.Close()

                    frmDepositSetPINCode.MdiParent = frmMain
                    frmDepositSetPINCode.Show()
                    frmLoading.Close()
                End If

            ElseIf f.LockerAvailable = ucLockerInfo.AvailableStatus.NotAvailable AndAlso f.LockerAvailable = ucLockerInfo.AvailableStatus.InActive Then
                'ถ้าสถานะ ไม่ว่าง ก็ให้อยู่นิ่งๆ ไม่ต้องทำอะไร
            End If

        ElseIf ServiceID = Data.ConstantsData.TransactionType.CollectBelonging Then
            'กรณีรับคืนจาก StaffConsole ให้คำนวณค่าฝาก และแสดงหน้าจอชำระเงิน

            If f.LockerAvailable = ucLockerInfo.AvailableStatus.NotAvailable Then
                TimeOutCheckTime = DateTime.Now
                TimerTimeOut.Enabled = False
                TimerTimeOut.Stop()

                frmLoading.Show(frmMain)

                If SetPickupInitialInformation(f.LockerID) = True Then
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleCollectSelectLocker_SelectLocker, " " & f.txtLockerName.Text, False)

                    Collect.PickupTime = DateTime.Now
                    Collect.ServiceAmount = PickupCalServiceAmount()   'ค่าบริการที่ระบบคำนวณได้
                    Collect.LostQRCode = "Y"

                    If UpdateCollectTransaction(Collect).IsSuccess = True Then
                        Me.Close()
                        Application.DoEvents()
                        WebCam = New WebCamera.DSCamCapture
                        frmDepositPayment.MdiParent = frmMain
                        frmDepositPayment.Show()
                    Else
                        frmLoading.Close()
                    End If
                Else
                    frmLoading.Close()
                End If
            ElseIf f.LockerAvailable = ucLockerInfo.AvailableStatus.Availabled AndAlso f.LockerAvailable = ucLockerInfo.AvailableStatus.InActive Then
                'กรณีรับคืนจาก StaffConsole ถ้าเป็นตู้ที่ว่างอยู่ ก็ไม่ให้คลิกได้ เพราะจะรับคืน จะไปคลิกตู้ว่างทำไม
            End If
        End If


    End Sub




    Private Function SetPickupInitialInformation(LockerID As Long) As Boolean
        Dim ret As Boolean = False
        Try
            Dim sql As String = "select t.id, t.trans_no, t.ms_locker_id, l.locker_name, l.pin_solenoid, l.pin_led, l.pin_sensor,  "
            sql += " t.service_rate, t.service_rate_limit_day, t.deposit_amt, t.paid_time, c.ms_cabinet_model_id "
            sql += " from TB_DEPOSIT_TRANSACTION t"
            sql += " inner join MS_LOCKER l on l.id=t.ms_locker_id"
            sql += " inner join MS_CABINET c on c.id=l.ms_cabinet_id"
            sql += " where t.ms_locker_id=@_LOCKER_ID "
            sql += " and t.trans_status=@_TRANS_STATUS"
            sql += " and t.paid_time is not null "

            Dim p(2) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_LOCKER_ID", LockerID)
            p(1) = KioskDB.SetText("@_TRANS_STATUS", Convert.ToInt16(DepositTransactionData.TransactionStatus.Success))

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                Collect.DepositTransNo = dr("trans_no")
                Collect.LockerID = Convert.ToInt64(dr("ms_locker_id"))
                Collect.LockerName = dr("locker_name").ToString
                If Convert.IsDBNull(dr("pin_solenoid")) = False Then Collect.LockerPinSolenoid = Convert.ToInt16(dr("pin_solenoid"))
                If Convert.IsDBNull(dr("pin_led")) = False Then Collect.LockerPinLED = Convert.ToInt16(dr("pin_led"))
                If Convert.IsDBNull(dr("pin_sensor")) = False Then Collect.LockerPinSendor = dr("pin_sensor")

                Collect.DepositAmount = Convert.ToInt64(dr("deposit_amt"))   'เงินค่ามัดจำที่ลูกค้าจ่ายแล้ว
                Collect.CabinetModelID = Convert.ToInt64(dr("ms_cabinet_model_id"))
                If Convert.IsDBNull(dr("paid_time")) = False Then
                    Collect.DepositPaidTime = Convert.ToDateTime(dr("paid_time"))
                End If

                Dim re As ExecuteDataInfo = UpdateCollectTransaction(Collect)
                ret = re.IsSuccess
            Else
                ret = False
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = False
            InsertErrorLog("Exception " & ex.Message & vbNewLine & ex.StackTrace, "", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupScanQRCode_CheckDataQRCode)
        End Try
        Return ret
    End Function

    Private Sub TimerTimeOut_Tick(sender As Object, e As EventArgs) Handles TimerTimeOut.Tick
        If KioskConfig.SelectForm = KioskLockerForm.DepositSelectLocker Then
            Application.DoEvents()
            'lblTimeOut.Text = TimeOut
            If TimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
                TimerTimeOut.Enabled = False
                TimerTimeOut.Stop()

                UpdateDepositStatus(Deposit.DepositTransactionID, DepositTransactionData.TransactionStatus.TimeOut, KioskLockerStep.DepositSelectLocker_SelectLocker)
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_SelectLocker, " ลูกค้าไม่ทำรายการภายในเวลาที่กำหนด", False)

                frmMain.CloseAllChildForm()
                Dim f As New frmHome
                f.MdiParent = frmMain
                f.Show()
            End If
        End If

    End Sub
End Class