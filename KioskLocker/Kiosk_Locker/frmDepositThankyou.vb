Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports AutoboxLocker.Data.KioskConfigData
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
        Me.BackColor = bgColor
        Me.WindowState = FormWindowState.Maximized
        'lblTimeOut.Text = TimeOut
        KioskConfig.SelectForm = KioskLockerForm.DepositThankYou
        'SetChildFormLanguage()
    End Sub


    Private Sub frmDepositThankyou_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CheckForIllegalCrossThreadCalls = False
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = False
        'Delete Temp QRCode
        If Directory.Exists(Application.StartupPath & "\QRCode") = True Then
            For Each f As String In Directory.GetFiles(Application.StartupPath & "\QRCode")
                File.Delete(f)
            Next
        End If
        InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_OpenForm, "", False)

        Application.DoEvents()
        If DepositOpenLocker() = True Then
            'Open Sensor
            If BoardSensor.ConnectSensorDevice(KioskConfig.SensorComport) = True Then
                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_StartSensor, "", False)

                'ใช้ Sensor เพื่อตรวจจับว่าลูกค้าได้ปิดตู้แล้วจริงๆ จึงกลับหน้าแรก
                BoardSensor.SensorRequestData(Customer.LockerPinSendor)
                AddHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
                _CallOpenLocker = True
                TimerCheckCloseLocker.Enabled = True
                TimerCheckCloseLocker.Start()
            Else
                'ถ้าตู้เปิดแล้วแต่ Sensor ไม่ทำงาน ให้ปิด LED
                BoardLED.LEDStop(Customer.LockerPinLED)


                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_StartSensor, " Sensor ไม่สามารถใช้งานได้", True)
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
            BoardSensor.SensorRequestData(Customer.LockerPinSendor)
        End If
        Application.DoEvents()
    End Sub

    Private Function DepositOpenLocker() As Boolean
        Dim ret As Boolean = False
        'Open Locker
        If OpenLocker(Customer.LockerID, Customer.LockerPinSolenoid, Customer.LockerPinSendor, KioskLockerStep.DepositPrintQRCode_OpenLocker) = True Then
            InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, Customer.LockerName, False)

            'Update เวลาที่จบ Transaction เมื่อเปิดตู้สำเร็จ
            'เวลาที่จบ Transaction
            'Dim ret As Boolean = False
            Dim UpdateRetry As Integer = 0  'จำนวนครั้งที่ Update
            Dim MaxRetry As Integer = 3   'จำนวนครั้งมากสุดที่ Update
            For UpdateRetry = 1 To MaxRetry
                Customer.TransStatus = DepositTransactionData.TransactionStatus.Success
                If UpdateServiceTransaction(Customer).IsSuccess = True Then
                    'If UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Success, KioskLockerStep.DepositPrintQRCode_OpenLocker).IsSuccess = True Then

                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, "ปรับปรุงสถานะสำเร็จ", False)
                    ret = True
                    Exit For
                Else
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, "UpdateRetry=" & UpdateRetry, True)
                End If
            Next

            If ret = False Then
                'ถ้า Update Trans Status ไม่ได้ ให้คืนเงิน
                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, "ปรับปรุงสถานะไม่สำเร็จ คืนเงินให้ลูกค้า " & (Customer.PaidAmount - Customer.ChangeAmount) & " บาท", True)
                UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Problem, KioskLockerStep.DepositPrintQRCode_OpenLocker)

                ReturnMoney(Customer.PaidAmount - Customer.ChangeAmount, Customer, Collect)
                BoardLED.LEDStop(Customer.LockerPinLED)
                ShowFormError("Out of Service", "Cannot open locker", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, True)
            End If
        Else
            'ถ้าเปิดตู้ไม่ได้ ให้คืนเงิน
            ReturnMoney(Customer.PaidAmount - Customer.ChangeAmount, Customer, Collect)

            InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenLocker, "เปิดตู้ไม่สำเร็จ คืนเงินให้ลูกค้า " & (Customer.PaidAmount - Customer.ChangeAmount) & " บาท", True)
            UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Problem, KioskLockerStep.DepositPrintQRCode_OpenLocker)

            BoardLED.LEDStop(Customer.LockerPinLED)
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


            InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, "", False)

            'Update เวลาที่จบ Transaction เมื่อเปิดตู้สำเร็จ
            'เวลาที่จบ Transaction
            Dim ret As Boolean = False
            Dim UpdateRetry As Integer = 0  'จำนวนครั้งที่ Update
            Dim MaxRetry As Integer = 3   'จำนวนครั้งมากสุดที่ Update
            For UpdateRetry = 1 To MaxRetry
                Application.DoEvents()
                Customer.TransStatus = DepositTransactionData.TransactionStatus.Success
                If UpdateServiceTransaction(Customer).IsSuccess = True Then
                    'If UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Success, KioskLockerStep.DepositThankYou_CloseLocker).IsSuccess = True Then
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, "ปรับปรุงสถานะสำเร็จ", False)
                    ret = True
                    Exit For
                Else
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, "UpdateRetry=" & UpdateRetry, True)
                End If
            Next

            If ret = False Then
                Application.DoEvents()

                'ถ้า Update Trans Status ไม่ได้ ให้คืนเงิน
                Customer.TransStatus = DepositTransactionData.TransactionStatus.Problem
                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, "ปรับปรุงสถานะไม่สำเร็จ", True)
                UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Problem, KioskLockerStep.DepositThankYou_CloseLocker)

                BoardLED.LEDStop(Customer.LockerPinLED)
                frmLoading.Close()

                ShowFormError("Out of Service", "Cannot Update Transaction Status", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_CloseLocker, True)
            Else
                'เมื่อปิดตู้ ก็อัพเดท Status ว่าปิดตู้แล้วด้วยนะ
                Dim lnq As New MsLockerKioskLinqDB
                lnq.GetDataByPK(Customer.LockerID, Nothing)
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

                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_LEDBlinkOff, Customer.LockerName, False)
                BoardLED.LEDStop(Customer.LockerPinLED)
                SetLockerList()

                Application.DoEvents()
                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositThankYou_BackToHome, "การทำรายการเสร็จสมบูรณ์", False)
                Dim f As New frmHome
                f.MdiParent = frmMain
                f.Show()
                TimerCheckCloseLocker.Stop()
                Application.DoEvents()

                BoardSensor.Disconnect()
                RemoveHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
                Threading.Thread.Sleep(1000)

                frmLoading.Close()
                Me.Close()
            End If
        Else
            TimerCheckCloseLocker.Enabled = True
        End If
    End Sub

    Private Sub frmDepositThankyou_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        RemoveHandler BoardSensor.SensorReceiveData, AddressOf SensorDataReceived
    End Sub

End Class