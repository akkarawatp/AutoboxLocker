Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports AutoboxLocker.Data
Imports AutoboxLocker.Data.KioskConfigData
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE



Public Class frmDepositPayment

    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Dim TimeOutCheckTime As DateTime = DateTime.Now

    Private Delegate Sub myDelegate(data As String)
    Private myForm As myDelegate
    Private PaidAmt As myDelegate
    Private RestartBanknoteIn As myDelegate

    Dim PayTimeOut As Boolean = False

    Private Sub frmDepositPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.BackColor = bgColor

        If ServiceID = ConstantsData.TransactionType.CollectBelonging Then
            KioskConfig.SelectForm = KioskLockerForm.CollectPayment
            myForm = AddressOf CollectPaymentComplete
        Else
            KioskConfig.SelectForm = KioskLockerForm.DepositPayment
            myForm = AddressOf OpenFormDepositPrintQRCode
        End If

        RestartBanknoteIn = AddressOf ReEnabledBanknoteIn

        SetChildFormLanguage()
        'SetControlLanguage()
        PaidAmt = AddressOf PaidLabel
    End Sub


    Private Sub frmDepositPayment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        BanknoteIn.DisableDeviceCashIn()
        CoinIn.DisableDeviceCoinIn()

        RemoveHandler BanknoteIn.ReceiveEvent, AddressOf BanknoteInDataReceived
        RemoveHandler CoinIn.ReceiveEvent, AddressOf CoinInDataReceived
    End Sub

    Private Sub frmDepositPayment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmMain.pnlAds.Visible = False
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = True
        CheckForIllegalCrossThreadCalls = False

        SetPaymentInformation()
        Application.DoEvents()

        If IsInitialDevice = True Then
            StartPaymentInitialDevice()
            TimeOutCheckTime = DateTime.Now
        End If


        If ServiceID = TransactionType.DepositBelonging Then
            InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPayment_OpenForm, "ค่ามัดจำ " & Customer.DepositAmount & " บาท", False)
        ElseIf ServiceID = TransactionType.CollectBelonging Then
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupPayment_OpenForm, "ค่าบริการ " & Collect.ServiceAmount & " บาท ค่ามัดจำ " & Collect.DepositAmount & " บาท", False)
        End If

    End Sub

#Region "Initial Form Show"
    Dim IsInitialDevice As Boolean = True   'ต้องสั่งให้เครื่องรับเงินเริ่มทำงานมั้ย

    Private Sub SetPaymentInformation()
        Try
            If ServiceID = ConstantsData.TransactionType.CollectBelonging Then
                'แสดงรายละเอียด เวลาการใช้บริการ
                'pnlServiceTime.Visible = True
                'SetServiceTimeInfo()

                'จัดตำแหน่ง Control ในกรณีรับคืน
                pnlLockerName.Location = New Point(496, 61)
                pnlServiceAmt.Location = New Point(pnlLockerName.Location.X, pnlLockerName.Location.Y + pnlLockerName.Height + 8)
                pnlDepositAmt.Location = New Point(pnlServiceAmt.Location.X, pnlServiceAmt.Location.Y + pnlServiceAmt.Height + 8)
                pnlServiceAmt.Visible = True

                lblLockerName.Text = Collect.LockerName
                lblServiceAmt.Text = Collect.ServiceAmount
                lblDepositAmt.Text = Collect.DepositAmount   'ค่ามัดจำ 
                lblPaidAmt.Text = 0

                lblLabelChange.Visible = True
                lblChangeAmt.Visible = True
                lblChangeTHB.Visible = True

                If Collect.DepositAmount > Collect.ServiceAmount Then
                    'ถ้าค่ามัดจำ มากกว่าค่าบริการ
                    'ให้แสดงจำนวนเงินที่ทอน และปุ่มเปิดประตู

                    Collect.ChangeAmount = (Collect.DepositAmount - Collect.ServiceAmount)
                    lblChangeAmt.Text = Collect.ChangeAmount
                    lblPaidRemain.Text = 0

                    CollectPaymentComplete()
                    IsInitialDevice = False  'จ่ายเงินครบแล้ว เครื่องรับเงินไม่ต้องทำงานก็ได้

                    tmPaymentTimeOut.Enabled = False
                    tmPaymentTimeOut.Stop()
                Else
                    lblChangeAmt.Text = 0
                    lblPaidRemain.Text = Collect.ServiceAmount - Collect.DepositAmount
                End If
            Else
                SetDepositMoneyAmt()

                lblLockerName.Text = Customer.LockerName
                lblDepositAmt.Text = Customer.DepositAmount
                lblPaidRemain.Text = Customer.DepositAmount

                Customer.ChangeAmount = Customer.PaidAmount - Customer.DepositAmount

                frmDepositPrintQRCode.MdiParent = frmMain
            End If
        Catch ex As Exception
            Dim _err As String = "Exception : " & ex.Message & vbNewLine & ex.StackTrace

            If ServiceID = ConstantsData.TransactionType.CollectBelonging Then
                InsertErrorLog(_err, Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_OpenForm)
            ElseIf ServiceID = ConstantsData.TransactionType.DepositBelonging Then
                InsertErrorLog(_err, Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_OpenForm)
            End If
        End Try
    End Sub

    Public Sub StartPaymentInitialDevice()
        Dim MsAppStepID As Int16 = KioskLockerStep.DepositPayment_StartDeviceBanknoteIn
        Try
            If BanknoteIn.ConnectBanknoteInDevice(KioskConfig.CashInComport) = True Then
                BanknoteIn.DisableDeviceCashIn()
                Threading.Thread.Sleep(500)
                BanknoteIn.EnableDeviceCashIn()
                'RemoveHandler BanknoteIn.MySerialPort.DataReceived, AddressOf BanknoteIn.MySerialPortDataReceived
                RemoveHandler BanknoteIn.ReceiveEvent, AddressOf BanknoteInDataReceived
                'AddHandler BanknoteIn.MySerialPort.DataReceived, AddressOf BanknoteIn.MySerialPortDataReceived
                AddHandler BanknoteIn.ReceiveEvent, AddressOf BanknoteInDataReceived

                If ServiceID = TransactionType.DepositBelonging Then
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID, "", False)
                ElseIf ServiceID = TransactionType.CollectBelonging Then
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "", False)
                End If

                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Ready)
                SendKioskAlarm("CASH_IN_Disconnected", False)

                'เครื่องรับเหรียญเริ่มทำงาน
                MsAppStepID = KioskLockerStep.DepositPayment_StartDeviceCoinIn
                If CoinIn.ConnectCoinInDevice(KioskConfig.CoinInComport) = True Then
                    CoinIn.DisableDeviceCoinIn()
                    Threading.Thread.Sleep(500)
                    CoinIn.EnableDeviceCoinIn()
                    RemoveHandler CoinIn.MySerialPort.DataReceived, AddressOf CoinIn.MySerialPortDataReceived
                    RemoveHandler CoinIn.ReceiveEvent, AddressOf CoinInDataReceived
                    AddHandler CoinIn.MySerialPort.DataReceived, AddressOf CoinIn.MySerialPortDataReceived
                    AddHandler CoinIn.ReceiveEvent, AddressOf CoinInDataReceived

                    If ServiceID = TransactionType.DepositBelonging Then
                        MsAppStepID = KioskLockerStep.DepositPayment_StartDeviceCoinIn
                        InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID, "", False)
                    ElseIf ServiceID = TransactionType.CollectBelonging Then
                        MsAppStepID = KioskLockerStep.PickupPayment_StartDeviceCoinIn
                        InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "", False)
                    End If

                    UpdateDeviceStatus(DeviceID.CoinIn, CoinInStatus.Ready)
                    SendKioskAlarm("COIN_IN_DISCONNECTED", False)
                Else
                    If ServiceID = TransactionType.DepositBelonging Then
                        MsAppStepID = KioskLockerStep.DepositPayment_StartDeviceCoinIn

                        UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Problem, MsAppStepID)
                        InsertErrorLog("เครื่องรับเหรียญ ไม่สามารถใช้งานได้", Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID)
                        InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้", True)
                    ElseIf ServiceID = TransactionType.CollectBelonging Then
                        MsAppStepID = KioskLockerStep.DepositPayment_StartDeviceCoinIn
                        UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.Problem, MsAppStepID)
                        InsertErrorLog("เครื่องรับเหรียญ ไม่สามารถใช้งานได้", Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
                        InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้", True)
                    End If

                    UpdateDeviceStatus(DeviceID.CoinIn, CoinInStatus.Disconnected)
                    SendKioskAlarm("COIN_IN_DISCONNECTED", True)

                    ShowFormError("Out of Service", "เครื่องรับเหรียญ ไม่สามารถใช้งานได้", KioskConfig.SelectForm, MsAppStepID, True)
                    Exit Sub
                End If
            Else
                If ServiceID = TransactionType.DepositBelonging Then
                    MsAppStepID = KioskLockerStep.PickupPayment_StartDeviceBanknoteIn
                    UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Problem, MsAppStepID)
                    InsertErrorLog("เครื่องรับธนบัตร ไม่สามารถใช้งานได้", Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID)
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้", True)
                ElseIf ServiceID = TransactionType.CollectBelonging Then
                    MsAppStepID = KioskLockerStep.PickupPayment_StartDeviceBanknoteIn
                    UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.Problem, MsAppStepID)
                    InsertErrorLog("เครื่องรับธนบัตร ไม่สามารถใช้งานได้", Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้", True)
                End If

                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Disconnected)
                SendKioskAlarm("CASH_IN_Disconnected", True)

                ShowFormError("Out of Service", "เครื่องรับธนบัตร ไม่สามารถใช้งานได้", KioskConfig.SelectForm, MsAppStepID, True)
                Exit Sub
            End If

            tmPaymentTimeOut.Enabled = True
        Catch ex As Exception
            If ServiceID = TransactionType.DepositBelonging Then
                UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Problem, MsAppStepID)
                InsertErrorLog("เครื่อรับธนบัตรหรือเครื่องรับเหรียญ ไม่สามารถใช้งานได้", Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID)
                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้", True)
            ElseIf ServiceID = TransactionType.CollectBelonging Then
                MsAppStepID = KioskLockerStep.DepositPayment_StartDeviceCoinIn
                UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.Problem, MsAppStepID)
                InsertErrorLog("เครื่อรับธนบัตรหรือเครื่องรับเหรียญ ไม่สามารถใช้งานได้", Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้", True)
            End If

            ShowFormError("Out of Service", "เครื่อรับธนบัตรหรือเครื่องรับเหรียญ ไม่สามารถใช้งานได้", KioskConfig.SelectForm, MsAppStepID, True)
            Exit Sub
        End Try
    End Sub

    Private Sub SetDepositMoneyAmt()
        Try
            'ค่ามัดจำที่ต้องจ่ายเมื่อทำรายการฝาก
            ServiceRateData.ServiceRateDepositList.DefaultView.RowFilter = "ms_cabinet_model_id='" & Customer.CabinetModelID & "'"
            If ServiceRateData.ServiceRateDepositList.DefaultView.Count > 0 Then
                Customer.DepositAmount = ServiceRateData.ServiceRateDepositList.DefaultView(0)("service_rate")
            End If
            ServiceRateData.ServiceRateDepositList.DefaultView.RowFilter = ""

        Catch ex As Exception
            Dim _err As String = "Exception : " & ex.Message & vbNewLine & ex.StackTrace
            If ServiceID = TransactionType.DepositBelonging Then
                InsertErrorLog(_err, Customer.DepositTransNo, 0, 0, KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_OpenForm)
            ElseIf ServiceID = TransactionType.CollectBelonging Then
                InsertErrorLog(_err, Collect.DepositTransNo, Collect.TransactionNo, 0, KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_OpenForm)
            End If

        End Try
    End Sub

#End Region

    Private Sub BackgroundPayment()
        Dim MsAppStepID As KioskLockerStep
        Try
            If ServiceID = Data.ConstantsData.TransactionType.DepositBelonging Then
                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPayment_CheckHardwareStatus, "", False)
            ElseIf ServiceID = Data.ConstantsData.TransactionType.CollectBelonging Then
                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupPayment_CheckHardwareStatus, "", False)
            End If

            'ตรวจสอบและส่ง Alarm เมื่อเครื่องเชื่อมอินเตอร์เน็ตได้
            UpdateAllDeviceStatusByComPort()
            UpdateAllDeviceStatusByUsbPort()

            'เช็คการเชื่อมต่ออุปกรณ์ และ Stock QTY
            Dim Msg As String = ""
            Msg = CheckStockAndStatusAllDevice()
            If Msg <> "" Then
                If ServiceID = Data.ConstantsData.TransactionType.DepositBelonging Then
                    MsAppStepID = KioskLockerStep.DepositPayment_CheckHardwareStatus
                    UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Problem, MsAppStepID)
                    InsertErrorLog(Msg, Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID)
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้", True)
                ElseIf ServiceID = Data.ConstantsData.TransactionType.CollectBelonging Then
                    MsAppStepID = KioskLockerStep.PickupPayment_CheckHardwareStatus
                    UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.Problem, MsAppStepID)
                    InsertErrorLog(Msg, Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้", True)
                End If

                ShowFormError("", "", KioskConfig.SelectForm, MsAppStepID, True)
            End If
        Catch ex As Exception
            Dim _err As String = "Exception BackgroundPayment " & ex.Message & vbNewLine & ex.StackTrace
            If ServiceID = Data.ConstantsData.TransactionType.DepositBelonging Then
                MsAppStepID = KioskLockerStep.DepositPayment_CheckHardwareStatus
                UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.Problem, MsAppStepID)
                InsertErrorLog(_err, Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID)
                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้" & _err, True)
            ElseIf ServiceID = Data.ConstantsData.TransactionType.CollectBelonging Then
                MsAppStepID = KioskLockerStep.PickupPayment_CheckHardwareStatus
                UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.Problem, MsAppStepID)
                InsertErrorLog(_err, Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "ไม่สามารถใช้งานได้" & _err, True)
            End If

            ShowFormError("", "", KioskConfig.SelectForm, MsAppStepID, True)
        End Try

    End Sub


    Private Sub PaidLabel(data As String)
        lblPaidAmt.Text = data

        Dim PaidRemain As Integer = 0
        If ServiceID = ConstantsData.TransactionType.CollectBelonging Then
            If (Collect.PaidAmount + Collect.DepositAmount) >= Collect.ServiceAmount Then
                lblChangeAmt.Text = Collect.ChangeAmount
            End If

            PaidRemain = Collect.ServiceAmount - (Collect.PaidAmount + Collect.DepositAmount)
        ElseIf ServiceID = ConstantsData.TransactionType.DepositBelonging Then
            If Customer.PaidAmount >= Customer.DepositAmount Then
                lblChangeAmt.Text = Customer.ChangeAmount
            End If

            PaidRemain = Customer.DepositAmount - Customer.PaidAmount
        End If

        If PaidRemain < 0 Then
            PaidRemain = 0
        End If
        lblPaidRemain.Text = PaidRemain

        Application.DoEvents()
    End Sub

    Private Sub BanknoteInDataReceived(ByVal ReceiveData As String)
        If InStr(ReceiveData, "ReceiveCash") > 0 Then
            TimeOutCheckTime = DateTime.Now
            ReceiveData = ReceiveData.Replace("ReceiveCash", "").Trim()

            If ServiceID = ConstantsData.TransactionType.DepositBelonging Then
                'กรณีฝากของ
                Customer.PaidAmount = Customer.PaidAmount + CInt(ReceiveData)
                Customer.ChangeAmount = Customer.PaidAmount - Customer.DepositAmount

                Me.Invoke(PaidAmt, Customer.PaidAmount.ToString)  'Update หน้าจอก่อนแล้วค่อยไปทำอย่างอื่น

                Select Case ReceiveData
                    Case 20
                        Customer.ReceiveBankNote20 += 1
                    Case 50
                        Customer.ReceiveBankNote50 += 1
                    Case 100
                        Customer.ReceiveBankNote100 += 1
                    Case 500
                        Customer.ReceiveBankNote500 += 1
                    Case 1000
                        Customer.ReceiveBankNote1000 += 1
                End Select
                'UpdateServiceTransaction(Customer)

                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_ReceiveBankNote, ReceiveData & " บาท", False)
                UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.BankNoteIn, 1, ReceiveData, False)

                If Customer.PaidAmount >= Customer.DepositAmount Then
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_PaidSuccess, " จำนวนเงินที่จ่าย " & Customer.PaidAmount, False)
                    Me.Invoke(myForm, "")
                Else
                    Me.Invoke(RestartBanknoteIn, "")
                End If

            ElseIf ServiceID = ConstantsData.TransactionType.CollectBelonging Then
                'กรณีรับของคืน
                Collect.PaidAmount = Collect.PaidAmount + CInt(ReceiveData)
                Collect.ChangeAmount = (Collect.PaidAmount + Collect.DepositAmount) - Collect.ServiceAmount

                Me.Invoke(PaidAmt, Collect.PaidAmount.ToString) 'อัพเดทหน้าจอก่อนแล้วค่อยทำอย่างอื่น

                Select Case ReceiveData
                    Case 20
                        Collect.ReceiveBankNote20 += 1
                    Case 50
                        Collect.ReceiveBankNote50 += 1
                    Case 100
                        Collect.ReceiveBankNote100 += 1
                    Case 500
                        Collect.ReceiveBankNote500 += 1
                    Case 1000
                        Collect.ReceiveBankNote1000 += 1
                End Select
                'UpdatePickupTransaction(Pickup)

                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_ReceiveBankNote, ReceiveData & " บาท", False)
                UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.BankNoteIn, 1, ReceiveData, False)

                If (Collect.PaidAmount + Collect.DepositAmount) >= Collect.ServiceAmount Then
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_PaidSuccess, " จำนวนเงินที่จ่าย " & Collect.PaidAmount, False)
                    Me.Invoke(myForm, "")
                Else
                    Me.Invoke(RestartBanknoteIn, "")
                End If
            End If
        End If
    End Sub

    Private Sub ReEnabledBanknoteIn(data As String)
        BanknoteIn.DisableDeviceCashIn()

        Threading.Thread.Sleep(500)
        BanknoteIn.EnableDeviceCashIn()
    End Sub

    Private Sub CoinInDataReceived(ByVal ReceiveData As String)
        If InStr(ReceiveData, "ReceiveCoin") > 0 Then
            TimeOutCheckTime = DateTime.Now
            ReceiveData = ReceiveData.Replace("ReceiveCoin", "").Trim()

            If ServiceID = ConstantsData.TransactionType.DepositBelonging Then
                ' กรณีฝากของ
                Customer.PaidAmount = Customer.PaidAmount + CInt(ReceiveData)
                Customer.ChangeAmount = Customer.PaidAmount - Customer.DepositAmount

                Me.Invoke(PaidAmt, Customer.PaidAmount.ToString)  'อัพเดทหน้าจอก่อนแล้วค่อยทำอย่างอื่น

                Select Case ReceiveData
                    Case 1
                        Customer.ReceiveCoin1 += 1
                    Case 2
                        Customer.ReceiveCoin2 += 1
                    Case 5
                        Customer.ReceiveCoin5 += 1
                    Case 10
                        Customer.ReceiveCoin10 += 1
                End Select

                UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.CoinIn, 1, ReceiveData, False)

                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_ReceiveCoin, ReceiveData & " บาท", False)
                If Customer.PaidAmount >= Customer.DepositAmount Then
                    'จ่ายครบแล้ว
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_PaidSuccess, " จำนวนเงินที่จ่าย " & Customer.PaidAmount, False)
                    Me.Invoke(myForm, "")
                End If

            ElseIf ServiceID = ConstantsData.TransactionType.CollectBelonging Then
                'กรณีรับของ

                Collect.PaidAmount = Collect.PaidAmount + CInt(ReceiveData)
                Collect.ChangeAmount = (Collect.PaidAmount + Collect.DepositAmount) - Collect.ServiceAmount

                Me.Invoke(PaidAmt, Collect.PaidAmount.ToString) 'อัพเดทหน้าจอก่อนแล้วค่อยทำอย่างอื่น

                Select Case ReceiveData
                    Case 1
                        Collect.ReceiveCoin1 += 1
                    Case 2
                        Collect.ReceiveCoin2 += 1
                    Case 5
                        Collect.ReceiveCoin5 += 1
                    Case 10
                        Collect.ReceiveCoin10 += 1
                End Select
                UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.CoinIn, 1, ReceiveData, False)

                InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_ReceiveCoin, ReceiveData & " บาท", False)
                If (Collect.PaidAmount + Collect.DepositAmount) >= Collect.ServiceAmount Then
                    'จ่ายครบแล้ว
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_PaidSuccess, " จำนวนเงินที่จ่าย " & Collect.PaidAmount, False)
                    Me.Invoke(myForm, "")
                End If
            End If

        End If
    End Sub

    Private Sub OpenFormDepositPrintQRCode(data As String)
        'กรณีฝาก เมื่อจ่ายครบแล้ว
        BanknoteIn.DisableDeviceCashIn()
        CoinIn.DisableDeviceCoinIn()
        RemoveHandler BanknoteIn.ReceiveEvent, AddressOf BanknoteInDataReceived
        RemoveHandler CoinIn.ReceiveEvent, AddressOf CoinInDataReceived
        tmPaymentTimeOut.Enabled = False
        tmPaymentTimeOut.Stop()

        frmDepositPrintQRCode.Show()
        Application.DoEvents()
        frmDepositPrintQRCode.PaymentCompletePrintQRCode()
        Me.Close()

    End Sub

#Region "การจ่ายเงินในขั้นตอนการรับคืน"
    Private Sub CollectPaymentComplete()
        'กรณีรับคืน เมื่อจ่ายครบแล้ว
        BanknoteIn.DisableDeviceCashIn()
        CoinIn.DisableDeviceCoinIn()
        RemoveHandler BanknoteIn.ReceiveEvent, AddressOf BanknoteInDataReceived
        RemoveHandler CoinIn.ReceiveEvent, AddressOf CoinInDataReceived

        tmPaymentTimeOut.Enabled = False
        tmPaymentTimeOut.Stop()

        lblPleasePaid.Visible = False

        lblPleasePaidComplete.Location = New Point(503, 232)
        lblPleasePaidComplete.Visible = True
        pnlPickupOpenLocker.Location = New Point(597, 301)
        pnlPickupOpenLocker.Visible = True
        frmMain.pnlCancel.Visible = False
        OpenLockerTimeOutCheckTime = DateTime.Now
        tmOpenLockerTimeOut.Enabled = True

        'Pickup.PaidTime = DateTime.Now
        Collect.PaidTime = DateTime.Now
        UpdateCollectTransaction(Collect)

        InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupPayment_LEDBlinkOn, Collect.LockerName, False)
        BoardLED.LEDBlinkOn(Collect.LockerPinLED)
        Application.DoEvents()
    End Sub

    Dim OpenLockerTimeOutCheckTime As DateTime
    Private Sub tmOpenLockerTimeOut_Tick(sender As Object, e As EventArgs) Handles tmOpenLockerTimeOut.Tick
        If OpenLockerTimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
            tmOpenLockerTimeOut.Enabled = False
            tmOpenLockerTimeOut.Stop()
            lblPickupOpenLocker_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub lblPickupOpenLocker_Click(sender As Object, e As EventArgs) Handles lblCollectOpenLocker.Click, pnlPickupOpenLocker.Click
        tmOpenLockerTimeOut.Enabled = False
        tmOpenLockerTimeOut.Stop()

        InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupPayment_ClickConfirmOpenLocker, Collect.LockerName, False)

        frmLoading.Show(frmMain)
        Application.DoEvents()
        PickupConfirmOpenLocker()
        frmLoading.Close()
    End Sub

    Private Sub PickupConfirmOpenLocker()
        If OpenLocker(Collect.LockerID, Collect.LockerPinSolenoid, Collect.LockerPinSendor, KioskLockerStep.PickupPayment_OpenLocker) = True Then
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupPayment_OpenLocker, "ช่องฝาก " & Collect.LockerName & " ถูกเปิดออก", False)

            Dim f As New frmCollectThankyou
            f.MdiParent = frmMain
            f.Show()
            Application.DoEvents()

            frmMain.CloseAllChildForm(f)
        Else
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupPayment_OpenLockerFailReturnMoney, Collect.PaidAmount & " บาท", True)

            'เปิดตู้ไม่ได้ คืนเงินเต็มจำนวน
            ReturnMoney(Collect.PaidAmount, Customer, Collect)
            BoardLED.LEDStop(Collect.LockerPinLED)
            ShowFormError("Out of Service", "Cannot open Locker " & Collect.LockerName, KioskConfig.SelectForm, KioskLockerStep.PickupPayment_OpenLockerFailReturnMoney, True)
        End If
    End Sub
#End Region
    Private Sub tmPaymentTimeOut_Tick(sender As Object, e As EventArgs) Handles tmPaymentTimeOut.Tick
        Application.DoEvents()
        If KioskConfig.SelectForm = KioskLockerForm.DepositPayment Or KioskConfig.SelectForm = KioskLockerForm.CollectPayment Then
            If TimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
                'ต้องปิดเครื่องรับเหรียญกับรับแบงค์ก่อนเลย
                BanknoteIn.DisableDeviceCashIn()
                CoinIn.DisableDeviceCoinIn()

                tmPaymentTimeOut.Enabled = False
                If ServiceID = TransactionType.DepositBelonging Then
                    InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_ShowExtend, "", False)
                ElseIf ServiceID = TransactionType.CollectBelonging Then
                    InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_ShowExtend, "", False)
                End If

                Dim f As New frmDialog_TimeOut
                If Plexiglass(f, frmMain) = DialogResult.Yes Then
                    If ServiceID = TransactionType.DepositBelonging Then
                        InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_OKExtend, "", False)
                    ElseIf ServiceID = TransactionType.CollectBelonging Then
                        InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_OKExtend, "", False)
                    End If

                    TimeOutCheckTime = DateTime.Now
                    tmPaymentTimeOut.Enabled = True

                    BanknoteIn.EnableDeviceCashIn()
                    CoinIn.EnableDeviceCoinIn()
                Else
                    Dim RtnMsg As String = ""
                    If ServiceID = TransactionType.DepositBelonging Then
                        If Customer.PaidAmount > 0 Then
                            RtnMsg = "คืนเงิน " & Customer.PaidAmount & " บาท"
                            ReturnMoney(Customer.PaidAmount, Customer, Collect)
                        End If

                        UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.TimeOut, KioskConfigData.KioskLockerStep.DepositPayment_CancelExtend)
                        InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.DepositPayment_CancelExtend, RtnMsg, False)

                    ElseIf ServiceID = TransactionType.CollectBelonging Then
                        If Collect.PaidAmount > 0 Then
                            RtnMsg = "คืนเงิน " & Collect.PaidAmount & " บาท"
                            ReturnMoney(Collect.PaidAmount, Customer, Collect)
                        End If

                        UpdateCollectStatus(Collect.CollectTransactionID, CollectTransactionData.TransactionStatus.TimeOut, KioskConfigData.KioskLockerStep.PickupPayment_CancelExtend)
                        InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupPayment_CancelExtend, RtnMsg, False)

                    End If
                    ProcessTimeOut()
                End If
            End If
        End If
    End Sub



    Private Sub btn1000_Click(sender As Object, e As EventArgs) Handles btn1000.Click
        BanknoteInDataReceived("ReceiveCash 1000")
    End Sub
    Private Sub btn500_Click(sender As Object, e As EventArgs) Handles btn500.Click
        BanknoteInDataReceived("ReceiveCash 500")
    End Sub
    Private Sub btn100_Click(sender As Object, e As EventArgs) Handles btn100.Click
        BanknoteInDataReceived("ReceiveCash 100")
    End Sub
    Private Sub btn50_Click(sender As Object, e As EventArgs) Handles btn50.Click
        BanknoteInDataReceived("ReceiveCash 50")
    End Sub
    Private Sub btn20_Click(sender As Object, e As EventArgs) Handles btn20.Click
        BanknoteInDataReceived("ReceiveCash 20")
    End Sub
    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        CoinInDataReceived("ReceiveCoin 10")
    End Sub
    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        CoinInDataReceived("ReceiveCoin 5")
    End Sub
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        CoinInDataReceived("ReceiveCoin 2")
    End Sub
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        CoinInDataReceived("ReceiveCoin 1")
    End Sub


End Class