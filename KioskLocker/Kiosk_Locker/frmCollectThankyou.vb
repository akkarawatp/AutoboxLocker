Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports MiniboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE

Public Class frmCollectThankyou

    Dim _IsCloseLocker As Boolean = False
    Dim _CallOpenLocker As Boolean = False

    Private Sub frmPickupThankyou_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        KioskConfig.SelectForm = KioskLockerForm.CollectThankYou
        'SetChildFormLanguage()
    End Sub



    Private Sub frmPickupThankyou_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_OpenForm, "", False)
        Me.WindowState = FormWindowState.Maximized
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = False

        If Collect.PaidTime.Year = 1 Then
            Collect.PaidTime = DateTime.Now
            UpdateCollectTransaction(Collect)
        End If

        Dim ConnectSensor As Boolean = False
        If IsNoCheckDevice = True Then
            ConnectSensor = True
            btnOpenLocker.Visible = True
        Else
            ConnectSensor = BoardSensor.ConnectSensorDevice(KioskConfig.SensorComport)
            'ใช้ Sensor เพื่อตรวจจับว่าลูกค้าได้ปิดตู้แล้วจริงๆ จึงกลับหน้าแรก
            BoardSensor.SensorRequestData(Collect.LockerPinSendor)
            AddHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
        End If

        If ConnectSensor = True Then
            _CallOpenLocker = True
            'lblChangeAmt.Text = Collect.ChangeAmount

            TimerCheckCloseLocker.Enabled = True
            TimerCheckCloseLocker.Start()
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_StartSensor, "", False)
        Else
            'ถ้า Sensor ไม่ทำงาน ให้ทอนเงิน และคืนมัดจำเลย เพราะตู้ได้เปิดออกแล้ว
            If Collect.ChangeAmount > 0 Then
                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_StartSensor, "Sensor ไม่สามารถใช้งานได้ ทอนเงินและคืนมัดจำ " & Collect.ChangeAmount & " บาท", False)
                ChangeMoney(Collect.ChangeAmount, Deposit, Collect)
            End If

            BoardLED.LEDStop(Collect.LockerPinLED)

            UpdateDeviceStatus(Data.ConstantsData.DeviceID.SensorBoard, Data.ConstantsData.BoardStatus.Disconnected)
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_StartSensor, "Sensor ไม่สามารถใช้งานได้", True)
            ShowFormError("Out of Service", "Sensor ไม่สามารถใช้งานได้", KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_StartSensor, True)
            Exit Sub
        End If

        Application.DoEvents()
    End Sub

    Private Sub SensorDataReceived(ByVal ReceiveData As String)
        If ReceiveData.Trim = "" Then Exit Sub

        If ReceiveData.Trim = "1" Then  '0=OPEN, 1=CLOSE
            _IsCloseLocker = True
            Threading.Thread.Sleep(1000)

        Else
            BoardSensor.SensorRequestData(Collect.LockerPinSendor)
        End If
        Application.DoEvents()
    End Sub

    Private Sub btnCloseLocker_Click(sender As Object, e As EventArgs)
        '_CallOpenLocker = False
        SensorDataReceived("1")
    End Sub

    Private Sub frmPickupThankyou_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        RemoveHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
    End Sub

    Private Sub TimerCheckCloseLocker_Tick(sender As Object, e As EventArgs) Handles TimerCheckCloseLocker.Tick
        TimerCheckCloseLocker.Enabled = False
        If _IsCloseLocker = True And _CallOpenLocker = True Then
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_CloseLocker, Collect.LockerName, False)

            'เมื่อปิดตู้ ก็อัพเดท Status ว่าปิดตู้แล้วด้วยนะ
            Dim sql As String = "update ms_locker "
            sql += " set open_close_status='C'"
            sql += " , current_available = 'Y'"
            sql += " , sync_to_server = 'N'"
            sql += " where id=@_LOCKER_ID"

            Dim trans As New KioskTransactionDB
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_LOCKER_ID", Collect.LockerID)
            If KioskDB.ExecuteNonQuery(sql, trans.Trans, p).IsSuccess = True Then
                trans.CommitTransaction()
                Application.DoEvents()

                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_CloseLocker, "ปรับปรุงสถานะช่องฝาก " & Collect.LockerName, False)
            Else
                trans.RollbackTransaction()

                Threading.Thread.Sleep(1000)
                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_CloseLocker, "ปรับปรุงสถานะช่องฝาก " & Collect.LockerName & " ไม่สำเร็จ ทำซ้ำอีกครั้ง", True)

                trans = New KioskTransactionDB
                ReDim p(1)
                p(0) = KioskDB.SetBigInt("@_LOCKER_ID", Collect.LockerID)
                If KioskDB.ExecuteNonQuery(sql, trans.Trans, p).IsSuccess = True Then
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_CloseLocker, "ปรับปรุงสถานะช่องฝาก " & Collect.LockerName & " อีกครั้งสำเร็จ", False)
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
                Application.DoEvents()
            End If

            'ทอนเงิน และคืนมัดจำ
            If Collect.ChangeAmount > 0 Then
                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_ChangeMoney, Collect.ChangeAmount & " บาท", False)
                ChangeMoney(Collect.ChangeAmount, Deposit, Collect)
            End If


            Application.DoEvents()
            'อัพเดท Status=Success ต้องทำหลังเปิดตู้ได้
            'เวลาที่จบ Transaction
            Dim ret As Boolean = False
            Dim UpdateRetry As Integer = 0  'จำนวนครั้งที่ Update
            Dim MaxRetry As Integer = 3   'จำนวนครั้งมากสุดที่ Update
            For UpdateRetry = 1 To MaxRetry
                Application.DoEvents()

                Collect.TransStatus = CollectTransactionData.TransactionStatus.Success
                If UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.Success, KioskLockerStep.PickupThankYou_CloseLocker).IsSuccess = True Then
                    ret = True
                    Exit For
                Else
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_CloseLocker, "UpdateRetry=" & UpdateRetry, True)
                End If
            Next

            Application.DoEvents()
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_LEDStart, Collect.LockerName, False)
            BoardLED.LEDStop(Collect.LockerPinLED)
            Threading.Thread.Sleep(1000)
            BoardLED.LEDStart(Collect.LockerPinLED)
            SetLockerList()

            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.PickupThankYou_BackToHome, "การทำรายการเสร็จสมบูรณ์", False)

            TimerCheckCloseLocker.Stop()
            BoardSensor.Disconnect()
            Application.DoEvents()
            RemoveHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
            Threading.Thread.Sleep(1000)

            Me.Close()
            frmMain.GoToHome()
        Else
            TimerCheckCloseLocker.Enabled = True
        End If
    End Sub

    Private Sub btnOpenLocker_Click(sender As Object, e As EventArgs) Handles btnOpenLocker.Click
        _IsCloseLocker = True
    End Sub
End Class