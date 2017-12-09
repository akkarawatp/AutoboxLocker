Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports MiniboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE

Public Class frmDepositThankyou

    Dim _IsCloseLocker As Boolean = False
    Dim _CallOpenLocker As Boolean = False
    Dim _RepeatCallOpen As Integer = 0
    Dim _MaxRepeatCallOpen As Integer = 1

    'Private Delegate Sub myDelegate(data As String)
    'Private myForm As myDelegate

    Private Sub frmDepositThankyou_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False

        'lblTimeOut.Text = TimeOut
        KioskConfig.SelectForm = KioskLockerForm.DepositThankYou
        'SetChildFormLanguage()
    End Sub


    Private Sub frmDepositThankyou_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CheckForIllegalCrossThreadCalls = False
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = False
        Me.WindowState = FormWindowState.Maximized
        'Delete Temp QRCode
        If Directory.Exists(Application.StartupPath & "\QRCode") = True Then
            For Each f As String In Directory.GetFiles(Application.StartupPath & "\QRCode")
                File.Delete(f)
            Next
        End If
        InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_OpenForm, "", False)

        Application.DoEvents()
        If DepositOpenLocker() = True Then
            'Open Sensor
            If BoardSensor.ConnectSensorDevice(KioskConfig.SensorComport) = True Then
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_StartSensor, "", False)

                'ใช้ Sensor เพื่อตรวจจับว่าลูกค้าได้ปิดตู้แล้วจริงๆ จึงกลับหน้าแรก
                BoardSensor.SensorRequestData(Deposit.LockerPinSendor)
                AddHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
                _CallOpenLocker = True
                TimerCheckCloseLocker.Enabled = True
                TimerCheckCloseLocker.Start()
            Else
                'ถ้าตู้เปิดแล้วแต่ Sensor ไม่ทำงาน ให้ปิด LED
                BoardLED.LEDStop(Deposit.LockerPinLED)


                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_StartSensor, " Sensor ไม่สามารถใช้งานได้", True)
                UpdateDeviceStatus(Data.ConstantsData.DeviceID.SensorBoard, Data.ConstantsData.BoardStatus.Disconnected)
            End If
        End If

        Application.DoEvents()
    End Sub

    Private Sub SensorDataReceived(ByVal ReceiveData As String)
        Engine.LogFileENG.CreateTextErrorLog("Deposit Sensor : " & ReceiveData)

        If ReceiveData.Trim = "" Then Exit Sub
        'lblSensorFlag.Text = IIf(ReceiveData.Trim = "0", "Open", "Close")
        'Engine.LogFileENG.CreateTextErrorLog("Deposit Sensor : " & ReceiveData)

        If ReceiveData.Trim = "1" Then  '0=OPEN, 1=CLOSE
            _IsCloseLocker = True
        Else
            _CallOpenLocker = False
            _IsCloseLocker = False
            BoardSensor.SensorRequestData(Deposit.LockerPinSendor)
        End If
        Application.DoEvents()
    End Sub

    Private Function DepositOpenLocker() As Boolean
        Dim ret As Boolean = False
        'Open Locker
        If OpenLocker(Deposit.LockerID, Deposit.LockerPinSolenoid, Deposit.LockerPinSendor, KioskLockerStep.DepositPrintQRCode_OpenLocker) = True Then
            InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, Deposit.LockerName, False)

            'Update เวลาที่จบ Transaction เมื่อเปิดตู้สำเร็จ
            'เวลาที่จบ Transaction
            'Dim ret As Boolean = False
            Dim UpdateRetry As Integer = 0  'จำนวนครั้งที่ Update
            Dim MaxRetry As Integer = 3   'จำนวนครั้งมากสุดที่ Update
            For UpdateRetry = 1 To MaxRetry
                Deposit.TransStatus = DepositTransactionData.TransactionStatus.Success
                If UpdateServiceTransaction(Deposit).IsSuccess = True Then
                    InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, "ปรับปรุงสถานะสำเร็จ", False)
                    ret = True
                    Exit For
                Else
                    InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, "UpdateRetry=" & UpdateRetry, True)
                End If
            Next

            If ret = False Then
                'ถ้า Update Trans Status ไม่ได้ ให้คืนเงิน
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, "ปรับปรุงสถานะไม่สำเร็จ คืนเงินให้ลูกค้า " & (Deposit.PaidAmount - Deposit.ChangeAmount) & " บาท", True)
                UpdateDepositStatus(Deposit.DepositTransactionID, DepositTransactionData.TransactionStatus.Problem, KioskLockerStep.DepositPrintQRCode_OpenLocker)

                ReturnMoney(Deposit.PaidAmount - Deposit.ChangeAmount, Deposit, Collect)
                BoardLED.LEDStop(Deposit.LockerPinLED)
                ShowFormError("Out of Service", "Cannot open locker", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, True)
            End If
        Else
            'ถ้าเปิดตู้ไม่ได้ ให้คืนเงิน
            ReturnMoney(Deposit.PaidAmount - Deposit.ChangeAmount, Deposit, Collect)

            InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, "เปิดตู้ไม่สำเร็จ คืนเงินให้ลูกค้า " & (Deposit.PaidAmount - Deposit.ChangeAmount) & " บาท", True)
            UpdateDepositStatus(Deposit.DepositTransactionID, DepositTransactionData.TransactionStatus.Problem, KioskLockerStep.DepositPrintQRCode_OpenLocker)

            BoardLED.LEDStop(Deposit.LockerPinLED)
            ShowFormError("Out of Service", "Cannot open locker", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, True)
        End If

        Return ret
    End Function



    Private Sub btnCloseLocker_Click(sender As Object, e As EventArgs) Handles btnCloseLocker.Click
        SensorDataReceived("1")
    End Sub

    Private Sub TimerCheckCloseLocker_Tick(sender As Object, e As EventArgs) Handles TimerCheckCloseLocker.Tick
        TimerCheckCloseLocker.Enabled = False
        If _IsCloseLocker = True Then


            InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, "", False)

            'Update เวลาที่จบ Transaction เมื่อเปิดตู้สำเร็จ
            'เวลาที่จบ Transaction
            Dim ret As Boolean = False
            Dim UpdateRetry As Integer = 0  'จำนวนครั้งที่ Update
            Dim MaxRetry As Integer = 3   'จำนวนครั้งมากสุดที่ Update
            For UpdateRetry = 1 To MaxRetry
                Application.DoEvents()
                Deposit.TransStatus = DepositTransactionData.TransactionStatus.Success
                If UpdateServiceTransaction(Deposit).IsSuccess = True Then
                    'If UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Success, KioskLockerStep.DepositThankYou_CloseLocker).IsSuccess = True Then
                    InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, "ปรับปรุงสถานะสำเร็จ", False)
                    ret = True
                    Exit For
                Else
                    InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, "UpdateRetry=" & UpdateRetry, True)
                End If
            Next

            If ret = False Then
                Application.DoEvents()

                'ถ้า Update Trans Status ไม่ได้ ให้คืนเงิน
                Deposit.TransStatus = DepositTransactionData.TransactionStatus.Problem
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, "ปรับปรุงสถานะไม่สำเร็จ", True)
                UpdateDepositStatus(Deposit.DepositTransactionID, DepositTransactionData.TransactionStatus.Problem, KioskLockerStep.DepositThankYou_CloseLocker)

                BoardLED.LEDStop(Deposit.LockerPinLED)
                frmLoading.Close()

                ShowFormError("Out of Service", "Cannot Update Transaction Status", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, True)
            Else
                'เมื่อปิดตู้ ก็อัพเดท Status ว่าปิดตู้แล้วด้วยนะ
                Dim lnq As New MsLockerKioskLinqDB
                lnq.GetDataByPK(Deposit.LockerID, Nothing)
                If lnq.ID > 0 Then
                    lnq.OPEN_CLOSE_STATUS = "C"  'Locker ปิด
                    lnq.SYNC_TO_SERVER = "N"

                    Dim trans As New KioskTransactionDB
                    If lnq.UpdateData(KioskData.ComputerName, trans.Trans).IsSuccess = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                    Application.DoEvents()
                End If
                lnq = Nothing

                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_LEDBlinkOff, Deposit.LockerName, False)
                BoardLED.LEDStop(Deposit.LockerPinLED)
                SetLockerList()

                Application.DoEvents()
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_BackToHome, "การทำรายการเสร็จสมบูรณ์", False)

                TimerCheckCloseLocker.Stop()
                Application.DoEvents()

                BoardSensor.Disconnect()
                RemoveHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
                Threading.Thread.Sleep(1000)

                Me.Close()
                frmMain.GoToHome()
                'frmLoading.Close()
            End If
        Else
            TimerCheckCloseLocker.Enabled = True
        End If
    End Sub

    Private Sub frmDepositThankyou_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        RemoveHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
    End Sub

End Class