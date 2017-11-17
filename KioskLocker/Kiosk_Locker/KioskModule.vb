
Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Threading
Imports AutoboxLocker.Data
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Imports System.Net

Module KioskModule

    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"
    Public KioskData As New KioskSystemData
    Public KioskConfig As New KioskConfigData(KioskData.KioskID)
    Public ServiceID As TransactionType
    Public Customer As New DepositTransactionData(KioskData.KioskID)
    Public Collect As New CollectTransactionData(KioskData.KioskID)
    Public StaffConsole As New StaffConsoleLogonData(KioskData.KioskID)
    Public bgColor As Color = Color.FromName("White") 'Color.FromArgb(140, 198, 62)
    Public CabinetList As New DataTable
    Public CabinetModelList As New DataTable
    Public LockerList As New DataTable
    Public DeviceInfoList As New DataTable
    Public DeviceStatusList As New DataTable
    'Public DeviceList As New DataTable
    Public AppScreenList As New DataTable
    Public AppStepList As New DataTable
    Public AlarmMasterList As New DataTable
    'Public LangMasterList As New DataTable
    'Public LangNotificationList As New DataTable
    Public ServiceRateData As New MSServerRateData
    Public THB_CH As String = "泰铢"
    Public THB_JP As String = "THB"
    Public THB_EN As String = "THB"

    Public OutOfService As Boolean

    'Hardware Interface
    Public BanknoteIn As New BanknoteIn.BanknoteInClass
    Public BanknoteOut_20 As New BanknoteOut.BanknoteOutClass
    Public BanknoteOut_50 As New BanknoteOut.BanknoteOutClass
    Public BanknoteOut_100 As New BanknoteOut.BanknoteOutClass
    Public BanknoteOut_500 As New BanknoteOut.BanknoteOutClass

    Public CoinIn As New CoinIn.CoinInClass
    Public CoinOut_1 As New CoinOut.CoinOutClass
    Public CoinOut_2 As New CoinOut.CoinOutClass
    Public CoinOut_5 As New CoinOut.CoinOutClass
    Public CoinOut_10 As New CoinOut.CoinOutClass

    Public Printer As New Printer.PrinterClass
    Public QRCode As New QRCodeScanner.QRCodeClass

    Public BoardSolenoid As New BoardSolenoid.SolenoidClass
    Public BoardLED As New BoardLED.LEDClass
    Public BoardSensor As New BoardSensor.SensorClass

    Private tmKioskHeartbeat As System.Timers.Timer
    Public Sub tmKioskHeartbeat_Tick(sender As Object, e As System.Timers.ElapsedEventArgs)
        Engine.LogFileENG.CreateHartbeat("tmKioskHeartbeat")
    End Sub
    Public Sub StartupHeartbeat()
        tmKioskHeartbeat = New System.Timers.Timer
        tmKioskHeartbeat.Interval = 1000 * 60 * 3
        AddHandler tmKioskHeartbeat.Elapsed, AddressOf tmKioskHeartbeat_Tick
        tmKioskHeartbeat.Start()
        tmKioskHeartbeat.Enabled = True
    End Sub


    Public Sub getMyVersion()
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly.GetName().Version
        Dim MyVersion As String = version.Major & "." & version.Minor & "." & version.Build
        frmMain.Text = Replace(frmMain.Text, "[%V%]", MyVersion)
    End Sub

    'Public Function getConnectionString() As String
    '    Return "Data Source=.;Initial Catalog=TSK;Integrated Security=True;Connect Timeout=1;"
    'End Function

    Public Function genNewTransectionNo() As String

        Dim CurrTime As String = DateTime.Now.ToString("yyyyMMddHHmmss", New Globalization.CultureInfo("en-US"))

        Return KioskData.KioskID.PadLeft(3, "0") & CurrTime
    End Function

    Public Sub ProcessTimeOut()


        frmMain.CloseAllChildForm()
        Dim f As New frmHome
        f.MdiParent = frmMain
        f.Show()
    End Sub

    Public Function Plexiglass(dialog As Form, MainForm As Form) As DialogResult
        Using plexi = New Form()
            plexi.FormBorderStyle = FormBorderStyle.None
            plexi.Bounds = Screen.FromPoint(dialog.Location).Bounds
            plexi.StartPosition = FormStartPosition.Manual
            plexi.AutoScaleMode = AutoScaleMode.None
            plexi.ShowInTaskbar = False
            plexi.BackColor = Color.Black
            plexi.Opacity = 0.45
            plexi.Show(MainForm)
            dialog.StartPosition = FormStartPosition.CenterParent
            Return dialog.ShowDialog(plexi)
        End Using
    End Function



#Region "Change Money"

    Public Function ChangeMoney(ByVal ChangeAmount As Integer, Cust As DepositTransactionData, Pick As CollectTransactionData) As Boolean
        'ทอนเงิน
        Try
            If ChangeAmount = 0 Then
                Return True
            End If

            Dim sql As String = "select ms_device_id device_id, current_qty kiosk_current_qty"
            sql += " from MS_KIOSK_DEVICE "
            sql += " where ms_kiosk_id=@_KIOSK_ID "

            'เอามาเฉพาะเครื่องทอนเหรียญกับทอนแบงค์
            DeviceInfoList.DefaultView.RowFilter = "device_type_id in (2,4) and type_active_status='Y' and device_active_status='Y'"
            If DeviceInfoList.DefaultView.Count > 0 Then
                Dim tmp As String = ""
                For Each drv As DataRowView In DeviceInfoList.DefaultView
                    If tmp = "" Then
                        tmp = drv("device_id")
                    Else
                        tmp += "," & drv("device_id")
                    End If
                Next
                sql += " and ms_device_id in (" & tmp & ")"
            End If
            DeviceInfoList.DefaultView.RowFilter = ""


            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", Convert.ToInt64(KioskData.KioskID))

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                dt.Columns.Add("device_type_id", GetType(Long))
                dt.Columns.Add("unit_value", GetType(Long))

                For i As Integer = 0 To dt.Rows.Count - 1
                    DeviceInfoList.DefaultView.RowFilter = "device_id='" & dt.Rows(i)("device_id") & "'"
                    If DeviceInfoList.DefaultView.Count > 0 Then
                        dt.Rows(i)("device_type_id") = DeviceInfoList.DefaultView(0)("device_type_id")
                        dt.Rows(i)("unit_value") = DeviceInfoList.DefaultView(0)("unit_value")
                    End If
                    DeviceInfoList.DefaultView.RowFilter = ""
                Next


                dt.DefaultView.Sort = "unit_value desc"
                dt = dt.DefaultView.ToTable

                For i As Integer = 0 To dt.Rows.Count - 1
                    If ChangeAmount <= 0 Then Exit For

                    Dim dr As DataRow = dt.Rows(i)
                    Dim vDeviceTypeID As Integer = Convert.ToInt16(dr("device_type_id"))
                    Dim vDeviceID As Integer = Convert.ToInt16(dr("device_id"))

                    Dim CurrentQty As Integer = Convert.ToInt16(dr("kiosk_current_qty"))
                    Dim UnitValue As Integer = Convert.ToInt16(dr("unit_value"))

                    Dim Num As Integer = 0
                    Do Until ChangeAmount < UnitValue
                        If CurrentQty > 0 Then   'มีเหลือใน Stock อยู่หรือไม่
                            Num += 1
                            ChangeAmount = ChangeAmount - Convert.ToInt16(dr("unit_value"))
                            CurrentQty -= 1  'หักยอดคงเหลือออกจาก Stock
                        Else
                            'ถ้าเงินหมดจาก Stock ให้ออกจาก Loop เลย เพื่อทำการทอนเงินท่าที่มีอยู่
                            Exit Do
                        End If
                    Loop

                    If Num > 0 Then
                        Select Case vDeviceTypeID
                            Case DeviceType.BanknoteOut
                                ChangeBanknote(vDeviceID, Num, Cust, Pick)
                            Case DeviceType.CoinOut
                                If Num > 10 Then
                                    Do Until Num <= 0
                                        If Num >= 10 Then
                                            Thread.Sleep(500)
                                            ChangeCoin(vDeviceID, 10, Cust, Pick)
                                        Else
                                            ChangeCoin(vDeviceID, Num, Cust, Pick)
                                        End If
                                        Num -= 10
                                    Loop
                                Else
                                    ChangeCoin(vDeviceID, Num, Cust, Pick)
                                End If
                        End Select
                    End If
                Next
            End If
            dt.Dispose()

            Return True
        Catch ex As Exception
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace, Customer.DepositTransNo, Collect.TransactionNo, 0, KioskConfig.SelectForm, 0)
        End Try
        Return False
    End Function

    Public Function ReturnMoney(PaidAmount As Integer, Cust As DepositTransactionData, Pick As CollectTransactionData) As Boolean
        'คืนเงิน
        Return ChangeMoney(PaidAmount, Cust, Pick)
    End Function
    Private Function ChangeBanknote(ByVal vDeviceID As DeviceID, ByVal Num As Int32, Cust As DepositTransactionData, Pick As CollectTransactionData) As Boolean
        Select Case vDeviceID
            Case DeviceID.BankNoteOut_20
                If BanknoteOut_20.ConnectBanknoteOutDevice(KioskConfig.CashOUT20Comport) Then
                    If BanknoteOut_20.PayCashOut(Num) = "" Then
                        If ServiceID = TransactionType.DepositBelonging Then
                            Cust.ChangeBankNote20 += Num
                            UpdateServiceTransaction(Cust)
                        ElseIf ServiceID = TransactionType.CollectBelonging Then
                            Pick.ChangeBankNote20 += Num
                            UpdateCollectTransaction(Pick)
                        End If

                        'UpdateTransactionStock(vDeviceID, Num)
                        UpdateKioskCurrentQty(vDeviceID, Num * -1, Num * -20, False)
                        Return True
                    End If
                End If
                BanknoteOut_20.Disconnect()
            Case DeviceID.BankNoteOut_50
                If BanknoteOut_50.ConnectBanknoteOutDevice(KioskConfig.CashOUT50Comport) Then
                    If BanknoteOut_50.PayCashOut(Num) = "" Then
                        If ServiceID = TransactionType.DepositBelonging Then
                            Cust.ChangeBankNote50 += Num
                            UpdateServiceTransaction(Cust)
                        ElseIf ServiceID = TransactionType.CollectBelonging Then
                            Pick.ChangeBankNote50 += Num
                            UpdateCollectTransaction(Pick)
                        End If

                        'UpdateTransactionStock(vDeviceID, Num)
                        UpdateKioskCurrentQty(vDeviceID, Num * -1, Num * -50, False)
                        Return True
                    End If
                End If
                BanknoteOut_50.Disconnect()
            Case DeviceID.BankNoteOut_100
                If BanknoteOut_100.ConnectBanknoteOutDevice(KioskConfig.CashOUT100Comport) Then
                    If BanknoteOut_100.PayCashOut(Num) = "" Then
                        If ServiceID = TransactionType.DepositBelonging Then
                            Cust.ChangeBankNote100 += Num
                            UpdateServiceTransaction(Cust)
                        ElseIf ServiceID = TransactionType.CollectBelonging Then
                            Pick.ChangeBankNote100 += Num
                            UpdateCollectTransaction(Pick)
                        End If

                        'UpdateTransactionStock(vDeviceID, Num)
                        UpdateKioskCurrentQty(vDeviceID, Num * -1, Num * -100, False)
                        Return True
                    End If

                End If
                BanknoteOut_100.Disconnect()
            Case DeviceID.BankNoteOut_500
                If BanknoteOut_500.ConnectBanknoteOutDevice(KioskConfig.CashOUT500Comport) Then
                    If BanknoteOut_500.PayCashOut(Num) = "" Then
                        If ServiceID = TransactionType.DepositBelonging Then
                            Cust.ChangeBankNote500 += Num
                            UpdateServiceTransaction(Cust)
                        ElseIf ServiceID = TransactionType.CollectBelonging Then
                            Pick.ChangeBankNote500 += Num
                            UpdateCollectTransaction(Pick)
                        End If

                        'UpdateTransactionStock(vDeviceID, Num)
                        UpdateKioskCurrentQty(vDeviceID, Num * -1, Num * -500, False)
                        Return True
                    End If

                End If
                BanknoteOut_500.Disconnect()
        End Select
        Return False
    End Function

    Private Function ChangeCoin(ByVal vDeviceID As DeviceID, ByVal Num As Int32, Cust As DepositTransactionData, Pick As CollectTransactionData) As Boolean
        Select Case vDeviceID
            Case DeviceID.CoinOut_1
                If CoinOut_1.ConnectCoinOutDevice(KioskConfig.CoinOut1Comport) Then
                    If CoinOut_1.PayCoinOut(Num) = "" Then
                        If ServiceID = TransactionType.DepositBelonging Then
                            Cust.ChangeCoin1 += Num
                            UpdateServiceTransaction(Cust)
                        ElseIf ServiceID = TransactionType.CollectBelonging Then
                            Pick.ChangeCoin1 += Num
                            UpdateCollectTransaction(Pick)
                        End If

                        UpdateKioskCurrentQty(vDeviceID, Num * -1, Num * -1, False)
                        Return True
                    End If

                End If
            Case DeviceID.CoinOut_2
                If CoinOut_2.ConnectCoinOutDevice(KioskConfig.CoinOut2Comport) Then
                    If CoinOut_2.PayCoinOut(Num) = "" Then
                        If ServiceID = TransactionType.DepositBelonging Then
                            Cust.ChangeCoin2 += Num
                            UpdateServiceTransaction(Cust)
                        ElseIf ServiceID = TransactionType.CollectBelonging Then
                            Pick.ChangeCoin2 += Num
                            UpdateCollectTransaction(Pick)
                        End If

                        'UpdateTransactionStock(vDeviceID, Num)
                        UpdateKioskCurrentQty(vDeviceID, Num * -1, Num * -2, False)
                        Return True
                    End If
                End If
            Case DeviceID.CoinOut_5
                If CoinOut_5.ConnectCoinOutDevice(KioskConfig.CoinOut5Comport) Then
                    If CoinOut_5.PayCoinOut(Num) = "" Then
                        If ServiceID = TransactionType.DepositBelonging Then
                            Cust.ChangeCoin5 += Num
                            UpdateServiceTransaction(Cust)
                        ElseIf ServiceID = TransactionType.CollectBelonging Then
                            Pick.ChangeCoin5 += Num
                            UpdateCollectTransaction(Pick)
                        End If

                        'UpdateTransactionStock(vDeviceID, Num)
                        UpdateKioskCurrentQty(vDeviceID, Num * -1, Num * -5, False)
                        Return True
                    End If

                End If
            Case DeviceID.CoinOut_10
                If CoinOut_10.ConnectCoinOutDevice(KioskConfig.CoinOut10Comport) Then
                    If CoinOut_10.PayCoinOut(Num) = "" Then
                        If ServiceID = TransactionType.DepositBelonging Then
                            Cust.ChangeCoin10 += Num
                            UpdateServiceTransaction(Cust)
                        ElseIf ServiceID = TransactionType.CollectBelonging Then
                            Pick.ChangeCoin10 += Num
                            UpdateCollectTransaction(Pick)
                        End If

                        'UpdateTransactionStock(vDeviceID, Num)
                        UpdateKioskCurrentQty(vDeviceID, Num * -1, Num * -10, False)
                        Return True
                    End If

                End If
        End Select
        Return False
    End Function


    'Private Sub UpdateTransactionStock(vDeviceID As Long, StockQty As Integer)
    '    'อัพเดทจำนวน Stock เงินใน Transaction

    '    If ServiceID = TransactionType.DepositBelonging Then
    '        Select Case vDeviceID
    '            Case DeviceID.CoinOut_1
    '                Customer.ChangeCoin1 += StockQty
    '            Case DeviceID.CoinOut_2
    '                Customer.ChangeCoin2 += StockQty
    '            Case DeviceID.CoinOut_5
    '                Customer.ChangeCoin5 += StockQty
    '            Case DeviceID.CoinOut_10
    '                Customer.ChangeCoin10 += StockQty
    '            Case DeviceID.BankNoteOut_20
    '                Customer.ChangeBankNote20 += StockQty
    '            Case DeviceID.BankNoteOut_50
    '                Customer.ChangeBankNote50 += StockQty
    '            Case DeviceID.BankNoteOut_100
    '                Customer.ChangeBankNote100 += StockQty
    '            Case DeviceID.BankNoteOut_500
    '                Customer.ChangeBankNote500 += StockQty
    '        End Select

    '        UpdateServiceTransaction(Customer)

    '    ElseIf ServiceID = TransactionType.CollectBelonging Then
    '        Select Case vDeviceID
    '            Case DeviceID.CoinOut_1
    '                Collect.ChangeCoin1 += StockQty
    '            Case DeviceID.CoinOut_2
    '                Collect.ChangeCoin2 += StockQty
    '            Case DeviceID.CoinOut_5
    '                Collect.ChangeCoin5 += StockQty
    '            Case DeviceID.CoinOut_10
    '                Collect.ChangeCoin10 += StockQty
    '            Case DeviceID.BankNoteOut_20
    '                Collect.ChangeBankNote20 += StockQty
    '            Case DeviceID.BankNoteOut_50
    '                Collect.ChangeBankNote50 += StockQty
    '            Case DeviceID.BankNoteOut_100
    '                Collect.ChangeBankNote100 += StockQty
    '            Case DeviceID.BankNoteOut_500
    '                Collect.ChangeBankNote500 += StockQty
    '        End Select

    '        UpdateCollectTransaction(Collect)
    '    End If
    'End Sub
#End Region

#Region "Set Cabinet Info"
    Public Sub SetLockerList()
        Dim lnq As New MsLockerKioskLinqDB
        Dim wh As String = "ms_kiosk_id=@_KIOSK_ID "
        Dim p(1) As SqlParameter
        p(0) = KioskDB.SetBigInt("@_KIOSK_ID", KioskData.KioskID)
        LockerList = lnq.GetDataList(wh, "", Nothing, p)

        Dim DepositTransNo As String = Customer.DepositTransNo
        If Customer.DepositTransNo = "" Then
            DepositTransNo = Collect.DepositTransNo
        End If

        InsertLogTransactionActivity(DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, KioskConfig.KioskLockerStep.Main_LoadLockerList, "", False)
        lnq = Nothing
    End Sub

    Public Sub SetCabinetInformation()
        Dim sql As String = "select c.id, c.ms_cabinet_model_id, c.order_layout, c.active_status"
        sql += " from ms_cabinet c"
        sql += " where c.active_status='Y'"
        sql += " and ms_kiosk_id=@_KIOSK_ID"
        sql += " order by c.cabinet_no"

        Dim p(1) As SqlParameter
        p(0) = KioskDB.SetBigInt("@_KIOSK_ID", KioskData.KioskID)

        CabinetList = KioskDB.ExecuteTable(sql, Nothing, p)

        InsertLogTransactionActivity("", "", "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_LoadCabinetList, "", False)
    End Sub

    Public Sub SetCabinetModel()
        Dim ret As New DataTable
        Dim sql As String = "select id, model_name, locker_qty, active_status"
        sql += " from ms_cabinet_model "
        sql += " where active_status='Y'"
        sql += " order by id"

        CabinetModelList = KioskDB.ExecuteTable(sql)
        InsertLogTransactionActivity("", "", "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_LoadCabinetModelList, "", False)
    End Sub
#End Region

    Public Function GetDate() As String
        Dim YY As Int32 = Now.Year
        If YY > 2500 Then
            YY = YY - 543
        End If
        Dim MM As Int32 = Now.Month
        Dim DD As Int32 = Now.Day
        Return YY.ToString & "-" & MM.ToString.PadLeft(2, "0") & "-" & DD.ToString.PadLeft(2, "0")
    End Function

    Public Sub ShowDialogErrorMessageSC(ByVal Message As String)
        Dim f As New frmDialog_OK
        f.lblMessage.Text = Message
        f.pnlDialog.BackColor = Color.FromArgb(97, 78, 72)
        Plexiglass(f, frmMain)
    End Sub

    Public Sub ShowDialogErrorMessage(ByVal Message As String)
        Dim f As New frmDialog_OK
        f.lblMessage.Text = Message
        f.pnlDialog.BackColor = bgColor
        Plexiglass(f, frmMain)
    End Sub

#Region "Device Status"
    Public Sub SetListDeviceInfo()
        Dim ret As New DataTable
        Dim sql As String = "select * "
        sql += " from v_kiosk_device_info "
        sql += " where device_active_status='Y'"
        sql += " and ms_kiosk_id=@_KIOSK_ID"

        Dim p(1) As SqlParameter
        p(0) = KioskDB.SetBigInt("@_KIOSK_ID", Convert.ToInt64(KioskData.KioskID))
        DeviceInfoList = KioskDB.ExecuteTable(sql, p)

        sql = " select id, status_name, is_problem "
        sql += " from ms_device_status "
        DeviceStatusList = KioskDB.ExecuteTable(sql)

        InsertLogTransactionActivity("", "", "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_GetDeviceInfo, "", False)
    End Sub

    'Public Function AddAlarmDt(AlarmProblem As String, IsAlarm As Boolean, AlarmDt As DataTable) As DataTable
    '    Dim dr As DataRow = AlarmDt.NewRow
    '    dr("AlarmProblem") = AlarmProblem
    '    dr("IsAlarm") = IsAlarm
    '    AlarmDt.Rows.Add(dr)

    '    Return AlarmDt
    'End Function

    Function UpdateAllDeviceStatusByComPort() As String
        Dim Msg As String = ""
        Try
            Dim Dt As DataTable = DeviceInfoList 'KioskDB.ExecuteTable(sql, p)
            If Dt.Rows.Count > 0 Then
                For i As Integer = 0 To Dt.Rows.Count - 1
                    If Convert.IsDBNull(Dt.Rows(i)("comport_vid")) = True Then
                        Continue For
                    End If

                    Dim Comport As String = Dt.Rows(i)("comport_vid").ToString
                    Dim vDeviceID As Long = Convert.ToInt64(Dt.Rows(i)("device_id"))
                    Select Case Dt.Rows(i).Item("device_type_id")
                        Case DeviceType.BanknoteIn
                            If BanknoteIn.ConnectBanknoteInDevice(Comport) = True Then
                                'BanknoteIn.DisableDeviceCashIn()
                                'AddHandler BanknoteIn.MySerialPort.DataReceived, AddressOf BanknoteIn.MySerialPortDataReceived
                                AddHandler BanknoteIn.ReceiveEvent, AddressOf DataReceivedCashIn
                                UpdateDeviceStatus(vDeviceID, BanknoteInStatus.Ready)
                                SendKioskAlarm("CASH_IN_Disconnected", False)

                                BanknoteIn.CheckStatusDeviceCashIn()
                            Else
                                UpdateDeviceStatus(vDeviceID, BanknoteInStatus.Disconnected)
                                SendKioskAlarm("CASH_IN_Disconnected", True)
                            End If
                        Case DeviceType.CoinIn
                            If CoinIn.ConnectCoinInDevice(Comport) = True Then
                                AddHandler CoinIn.MySerialPort.DataReceived, AddressOf CoinIn.MySerialPortDataReceived
                                AddHandler CoinIn.ReceiveEvent, AddressOf DataReceivedCoinIn
                                UpdateDeviceStatus(vDeviceID, CoinInStatus.Ready)
                                SendKioskAlarm("COIN_IN_DISCONNECTED", False)

                                CoinIn.CheckStatusDeviceCoinIn()
                            Else
                                UpdateDeviceStatus(vDeviceID, CoinInStatus.Disconnected)
                                SendKioskAlarm("COIN_IN_DISCONNECTED", True)
                            End If
                        Case DeviceType.BanknoteOut
                            Select Case vDeviceID
                                Case DeviceID.BankNoteOut_20
                                    If BanknoteOut_20.ConnectBanknoteOutDevice(Comport) = True Then
                                        AddHandler BanknoteOut_20.MySerialPort.DataReceived, AddressOf BanknoteOut_20.MySerialPortDataReceived
                                        AddHandler BanknoteOut_20.ReceiveEvent, AddressOf DataReceivedCashOut20
                                        UpdateDeviceStatus(vDeviceID, BanknoteOutStatus.Ready)
                                        SendKioskAlarm("CASH_OUT_DISCONNECTED", False)

                                        BanknoteOut_20.CheckStatusDeviceCashOut()
                                    Else
                                        UpdateDeviceStatus(vDeviceID, BanknoteOutStatus.Disconnected)
                                        SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
                                    End If
                                Case DeviceID.BankNoteOut_50
                                    If BanknoteOut_50.ConnectBanknoteOutDevice(Comport) = True Then
                                        AddHandler BanknoteOut_50.MySerialPort.DataReceived, AddressOf BanknoteOut_50.MySerialPortDataReceived
                                        AddHandler BanknoteOut_50.ReceiveEvent, AddressOf DataReceivedCashOut50
                                        UpdateDeviceStatus(vDeviceID, BanknoteOutStatus.Ready)
                                        SendKioskAlarm("CASH_OUT_DISCONNECTED", False)

                                        BanknoteOut_50.CheckStatusDeviceCashOut()
                                    Else
                                        UpdateDeviceStatus(vDeviceID, BanknoteOutStatus.Disconnected)
                                        SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
                                    End If
                                Case DeviceID.BankNoteOut_100
                                    If BanknoteOut_100.ConnectBanknoteOutDevice(Comport) = True Then
                                        AddHandler BanknoteOut_100.MySerialPort.DataReceived, AddressOf BanknoteOut_100.MySerialPortDataReceived
                                        AddHandler BanknoteOut_100.ReceiveEvent, AddressOf DataReceivedCashOut100
                                        UpdateDeviceStatus(vDeviceID, BanknoteOutStatus.Ready)
                                        SendKioskAlarm("CASH_OUT_DISCONNECTED", False)

                                        BanknoteOut_100.CheckStatusDeviceCashOut()
                                    Else
                                        UpdateDeviceStatus(vDeviceID, BanknoteOutStatus.Disconnected)
                                        SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
                                    End If
                                Case DeviceID.BankNoteOut_500
                                    If BanknoteOut_500.ConnectBanknoteOutDevice(Comport) = True Then
                                        AddHandler BanknoteOut_500.MySerialPort.DataReceived, AddressOf BanknoteOut_500.MySerialPortDataReceived
                                        AddHandler BanknoteOut_500.ReceiveEvent, AddressOf DataReceivedCashOut500
                                        UpdateDeviceStatus(vDeviceID, BanknoteOutStatus.Ready)
                                        SendKioskAlarm("CASH_OUT_DISCONNECTED", False)

                                        BanknoteOut_500.CheckStatusDeviceCashOut()
                                    Else
                                        UpdateDeviceStatus(vDeviceID, BanknoteOutStatus.Disconnected)
                                        SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
                                    End If
                            End Select
                        Case DeviceType.CoinOut
                            Select Case vDeviceID
                                Case DeviceID.CoinOut_1
                                    If CoinOut_1.ConnectCoinOutDevice(Comport) = True Then
                                        AddHandler CoinOut_1.MySerialPort.DataReceived, AddressOf CoinOut_1.MySerialPortDataReceived
                                        AddHandler CoinOut_1.ReceiveEvent, AddressOf DataReceivedCoinOut1
                                        UpdateDeviceStatus(vDeviceID, CoinOutStatus.Ready)
                                        SendKioskAlarm("COIN_OUT_DISCONNECTED", False)

                                        CoinOut_1.CheckStatusDeviceCoinOut()
                                    Else
                                        UpdateDeviceStatus(vDeviceID, CoinOutStatus.Disconnected)
                                        SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
                                    End If
                                Case DeviceID.CoinOut_2
                                    If CoinOut_2.ConnectCoinOutDevice(Comport) = True Then
                                        AddHandler CoinOut_2.MySerialPort.DataReceived, AddressOf CoinOut_2.MySerialPortDataReceived
                                        AddHandler CoinOut_2.ReceiveEvent, AddressOf DataReceivedCoinOut2
                                        UpdateDeviceStatus(vDeviceID, CoinOutStatus.Ready)
                                        SendKioskAlarm("COIN_OUT_DISCONNECTED", False)

                                        CoinOut_2.CheckStatusDeviceCoinOut()
                                    Else
                                        UpdateDeviceStatus(vDeviceID, CoinOutStatus.Disconnected)
                                        SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
                                    End If
                                Case DeviceID.CoinOut_5
                                    If CoinOut_5.ConnectCoinOutDevice(Comport) = True Then
                                        AddHandler CoinOut_5.MySerialPort.DataReceived, AddressOf CoinOut_5.MySerialPortDataReceived
                                        AddHandler CoinOut_5.ReceiveEvent, AddressOf DataReceivedCoinOut5
                                        UpdateDeviceStatus(vDeviceID, CoinOutStatus.Ready)
                                        SendKioskAlarm("COIN_OUT_DISCONNECTED", False)

                                        CoinOut_5.CheckStatusDeviceCoinOut()
                                    Else
                                        UpdateDeviceStatus(vDeviceID, CoinOutStatus.Disconnected)
                                        SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
                                    End If
                                Case DeviceID.CoinOut_10
                                    If CoinOut_10.ConnectCoinOutDevice(Comport) = True Then
                                        AddHandler CoinOut_10.MySerialPort.DataReceived, AddressOf CoinOut_10.MySerialPortDataReceived
                                        AddHandler CoinOut_10.ReceiveEvent, AddressOf DataReceivedCoinOut10
                                        UpdateDeviceStatus(vDeviceID, CoinOutStatus.Ready)
                                        SendKioskAlarm("COIN_OUT_DISCONNECTED", False)

                                        CoinOut_10.CheckStatusDeviceCoinOut()
                                    Else
                                        UpdateDeviceStatus(vDeviceID, CoinOutStatus.Disconnected)
                                        SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
                                    End If
                            End Select
                        Case DeviceType.LEDBoard
                            If BoardLED.ConnectLEDDevice(Comport) = True Then
                                UpdateDeviceStatus(vDeviceID, BoardStatus.Ready)
                                SendKioskAlarm("BOARD_LED_DISCONNECTED", False)
                            Else
                                UpdateDeviceStatus(vDeviceID, BoardStatus.Disconnected)
                                SendKioskAlarm("BOARD_LED_DISCONNECTED", True)
                            End If
                        Case DeviceType.SolenoidBoard
                            If BoardSolenoid.ConnectSolenoidDevice(Comport) = True Then
                                UpdateDeviceStatus(vDeviceID, BoardStatus.Ready)
                                SendKioskAlarm("BOARD_SOLENOID_DISCONNECTED", False)
                            Else
                                UpdateDeviceStatus(vDeviceID, BoardStatus.Disconnected)
                                SendKioskAlarm("BOARD_SOLENOID_DISCONNECTED", True)
                            End If
                        Case DeviceType.SensorBoard
                            If BoardSensor.ConnectSensorDevice(Comport) = True Then
                                UpdateDeviceStatus(vDeviceID, BoardStatus.Ready)
                                SendKioskAlarm("BOARD_SENSOR_DISCONNECTED", False)
                            Else
                                UpdateDeviceStatus(vDeviceID, BoardStatus.Disconnected)
                                SendKioskAlarm("BOARD_SENSOR_DISCONNECTED", True)
                            End If
                    End Select
                Next
            End If
            Dt.Dispose()

        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return Msg
    End Function

    Function UpdateAllDeviceStatusByUsbPort() As String
        'เป็นฟังก์ชั่นสำหรับ Update Check Status ของ Hardware เพื่อเก็บข้อมูลลงใน DB
        Dim Msg As String = ""
        Try
            If DeviceInfoList.Rows.Count > 0 Then
                For i As Integer = 0 To DeviceInfoList.Rows.Count - 1
                    Dim dr As DataRow = DeviceInfoList.Rows(i)
                    Dim DeviceTypeID As Long = Convert.ToInt64(dr("device_type_id"))
                    Dim DeviceID As Long = Convert.ToInt64(dr("device_id"))
                    Dim VID As String = dr("comport_vid").ToString

                    Select Case DeviceTypeID
                        'Case DeviceType.IdCardAndPassportScanner
                        '    If PassportScanner.StartPassportDevice(KioskConfig.PassportDeviceName) = True Then
                        '        If PassportScanner.ConnectPassportDevice(VID) = True Then
                        '            UpdateDeviceStatus(DeviceID.ToString, PassportScanerStatus.Ready)
                        '            SendKioskAlarm("PASSPORT_SCANNER_DISCONNECTED", False)
                        '        Else
                        '            UpdateDeviceStatus(DeviceID.ToString, PassportScanerStatus.Disconnected)
                        '            SendKioskAlarm("PASSPORT_SCANNER_DISCONNECTED", True)
                        '        End If
                        '    Else
                        '        UpdateDeviceStatus(DeviceID.ToString, PassportScanerStatus.Disconnected)
                        '        SendKioskAlarm("PASSPORT_SCANNER_DISCONNECTED", True)
                        '    End If
                        Case DeviceType.Printer
                            If Convert.IsDBNull(dr("driver_name1")) = False Then
                                Dim pntSts As String = Printer.CheckPrinterStatus(dr("driver_name1"))
                                UpdateDeviceStatus(DeviceID.ToString, pntSts)

                                If pntSts = PrinterStatus.Offline Then
                                    SendKioskAlarm("PRINTER_OFFLINE", True)
                                Else
                                    SendKioskAlarm("PRINTER_OFFLINE", False)
                                End If
                            End If
                        Case DeviceType.QRCodeScanner
                            If QRCode.ConnectQRCodeDevice(VID) = True Then
                                UpdateDeviceStatus(DeviceID.ToString, QRCodeStatus.Ready)
                                SendKioskAlarm("QRCODE_SCANNER_DISCONNECTED", False)
                            Else
                                UpdateDeviceStatus(DeviceID.ToString, QRCodeStatus.Disconnected)
                                SendKioskAlarm("QRCODE_SCANNER_DISCONNECTED", True)
                            End If
                        Case DeviceType.NetworkConnection
                            '###################################################################
                            '################## กรณีทำงานแบบออฟไลน์ ไม่ต้องเช็ค Network

                            'If ServerLinqDB.ConnectDB.ServerDB.ChkConnection() = True Then
                            '    UpdateDeviceStatus(DeviceID.ToString, NetworkStatus.Ready)
                            '    SendKioskAlarm("NET_DISCONNECTED", False)
                            'Else
                            '    UpdateDeviceStatus(DeviceID.ToString, NetworkStatus.Disconnected)
                            '    SendKioskAlarm("NET_DISCONNECTED", True)
                            'End If
                            '####################################################################
                    End Select
                Next
            End If

        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return Msg
    End Function

    Public Sub UpdateDeviceStatus(ByVal DeviceID As String, ByVal StatusID As String)
        Try
            Dim lnq As New MsKioskDeviceKioskLinqDB
            lnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(Convert.ToInt16(DeviceID), KioskData.KioskID, Nothing)
            If lnq.ID > 0 Then
                lnq.MS_DEVICE_STATUS_ID = Convert.ToInt16(StatusID)
                lnq.SYNC_TO_SERVER = "N"
                lnq.SYNC_TO_KIOSK = "Y"

                Dim trans As New KioskTransactionDB
                Dim ret As ExecuteDataInfo = lnq.UpdateData(KioskData.ComputerName, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    InsertErrorLog(ret.ErrorMessage & vbNewLine & "&DeviceID=" & DeviceID & "&StatusID=" & StatusID, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, 0)
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "&DeviceID=" & DeviceID & "&StatusID=" & StatusID, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, 0)
        End Try
    End Sub

    Public Event CashInReceiveEvent(ByVal ReceiveData As String)
    Private Sub DataReceivedCashIn(ByVal ReceiveData As String)
        Select Case ReceiveData
            Case BanknoteInStatus.Ready
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Ready)
                Exit Sub
            Case BanknoteInStatus.Unavailable
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Ready)
                Exit Sub
            Case BanknoteInStatus.Disconnected
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Disconnected)
                SendKioskAlarm("CASH_IN_Disconnected", True)
                Exit Sub
            Case BanknoteInStatus.Power_OFF
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Power_OFF)
                SendKioskAlarm("CASH_IN_POWER_OFF", True)
                Exit Sub
            Case BanknoteInStatus.Motor_Failure
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Motor_Failure)
                SendKioskAlarm("CASH_IN_MOTOR_FAILURE", True)
                Exit Sub
            Case BanknoteInStatus.Checksum_Error
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Checksum_Error)
                SendKioskAlarm("CASH_IN_CHECKSUM_ERROR", True)
                Exit Sub
            Case BanknoteInStatus.Bill_Jam
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Bill_Jam)
                SendKioskAlarm("CASH_IN_BILL_JAM", True)
                Exit Sub
            Case BanknoteInStatus.Bill_Remove
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Bill_Remove)
                SendKioskAlarm("CASH_IN_BILL_REMOVE", True)
                Exit Sub
            Case BanknoteInStatus.Stacker_Open
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Stacker_Open)
                SendKioskAlarm("CASH_IN_STACKER_OPEN", True)
                Exit Sub
            Case BanknoteInStatus.Sensor_Problem
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Sensor_Problem)
                SendKioskAlarm("CASH_IN_SENSOR_PROBLEM", True)
                Exit Sub
            Case BanknoteInStatus.Bill_Fish
                UpdateDeviceStatus(DeviceID.BankNoteIn, BanknoteInStatus.Bill_Fish)
                SendKioskAlarm("CASH_IN_BILL_FISH", True)
                Exit Sub
        End Select

        If InStr(ReceiveData, "ReceiveCash") > 0 Then
            RaiseEvent CashInReceiveEvent(ReceiveData)
        End If
    End Sub

    Public Event CoinInReceiveEvent(ByVal ReceiveData As String)
    Private Sub DataReceivedCoinIn(ByVal ReceiveData As String)
        Select Case ReceiveData
            Case CoinInStatus.Ready
                UpdateDeviceStatus(DeviceID.CoinIn, CoinInStatus.Ready)
                Exit Sub
            Case CoinInStatus.Unavailable
                UpdateDeviceStatus(DeviceID.CoinIn, CoinInStatus.Ready)
                Exit Sub
            Case CoinInStatus.Ready
                UpdateDeviceStatus(DeviceID.CoinIn, CoinInStatus.Disconnected)
                SendKioskAlarm("COIN_IN_DISCONNECTED", True)
                Exit Sub
            Case CoinInStatus.Sersor_1_Problem
                UpdateDeviceStatus(DeviceID.CoinIn, CoinInStatus.Sersor_1_Problem)
                SendKioskAlarm("COIN_IN_SERSOR_1_PROBLEM", True)
                Exit Sub
            Case CoinInStatus.Sersor_2_Problem
                UpdateDeviceStatus(DeviceID.CoinIn, CoinInStatus.Sersor_2_Problem)
                SendKioskAlarm("COIN_IN_SERSOR_2_PROBLEM", True)
                Exit Sub
            Case CoinInStatus.Sersor_3_Problem
                UpdateDeviceStatus(DeviceID.CoinIn, CoinInStatus.Sersor_3_Problem)
                SendKioskAlarm("COIN_IN_SERSOR_3_PROBLEM", True)
                Exit Sub
        End Select

        If InStr(ReceiveData, "ReceiveCoin") > 0 Then
            RaiseEvent CoinInReceiveEvent(ReceiveData)
        End If
    End Sub

    Private Sub DataReceivedCashOut20(ByVal ReceiveData As String)
        UpdateDataReceivedBanknoteOut(ReceiveData, DeviceID.BankNoteOut_20)
    End Sub
    Private Sub DataReceivedCashOut50(ByVal ReceiveData As String)
        UpdateDataReceivedBanknoteOut(ReceiveData, DeviceID.BankNoteOut_50)
    End Sub
    Private Sub DataReceivedCashOut100(ByVal ReceiveData As String)
        UpdateDataReceivedBanknoteOut(ReceiveData, DeviceID.BankNoteOut_100)
    End Sub
    Private Sub DataReceivedCashOut500(ByVal ReceiveData As String)
        UpdateDataReceivedBanknoteOut(ReceiveData, DeviceID.BankNoteOut_500)
    End Sub

    Private Sub UpdateDataReceivedBanknoteOut(ByVal ReceiveData As String, ByVal DeviceID As String)
        Select Case ReceiveData
            Case BanknoteOutStatus.Ready
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Ready)
            Case BanknoteOutStatus.Disconnected
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Disconnected)
                SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
            Case BanknoteOutStatus.Single_machine_payout
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Single_machine_payout)
                SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
            Case BanknoteOutStatus.Multiple_machine_payout
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Multiple_machine_payout)
                SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
            'Case BanknoteOutStatus.Payout_Successful
            '    UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Payout_Successful)
            Case BanknoteOutStatus.Payout_fails
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Payout_fails)
                SendKioskAlarm("CASH_OUT_PAYOUT_FAILS", True)
            Case BanknoteOutStatus.Empty_note
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Empty_note)
                SendKioskAlarm("CASH_OUT_EMPTY_NOTE", True)
            Case BanknoteOutStatus.Stock_less
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Stock_less)

                SendKioskAlarm("CASH_OUT_STOCK_LESS", True)
            Case BanknoteOutStatus.Note_jam
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Note_jam)
                SendKioskAlarm("CASH_OUT_NOTE_JAM", True)
            Case BanknoteOutStatus.Over_length
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Over_length)
                SendKioskAlarm("CASH_OUT_OVER_LENGTH", True)
            Case BanknoteOutStatus.Note_Not_Exit
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Note_Not_Exit)
                SendKioskAlarm("CASH_OUT_NOTE_NOT_EXIT", True)
            Case BanknoteOutStatus.Sensor_Error
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Sensor_Error)
                SendKioskAlarm("CASH_OUT_SENSOR_ERROR", True)
            Case BanknoteOutStatus.Double_note_error
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Double_note_error)
                SendKioskAlarm("CASH_OUT_DOUBLE_NOTE_ERROR", True)
            Case BanknoteOutStatus.Motor_Error
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Motor_Error)
                SendKioskAlarm("CASH_OUT_MOTOR_ERROR", True)
            Case BanknoteOutStatus.Dispensing_busy
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Dispensing_busy)
                SendKioskAlarm("CASH_OUT_DISPENSING_BUSY", True)
            Case BanknoteOutStatus.Sensor_adjusting
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Sensor_adjusting)
                SendKioskAlarm("CASH_OUT_SENSOR_ADJUSTING", True)
            Case BanknoteOutStatus.Checksum_Error
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Checksum_Error)
                SendKioskAlarm("CASH_OUT_CHECKSUM_ERROR", True)
            Case BanknoteOutStatus.Low_power_Error
                UpdateDeviceStatus(DeviceID, BanknoteOutStatus.Low_power_Error)
                SendKioskAlarm("CASH_OUT_LOW_POWER_ERROR", True)
        End Select
    End Sub

    Private Sub DataReceivedCoinOut1(ByVal ReceiveData As String)
        UpdateDataReceivedCoinOut(ReceiveData, DeviceID.CoinOut_1)
    End Sub
    Private Sub DataReceivedCoinOut2(ByVal ReceiveData As String)
        UpdateDataReceivedCoinOut(ReceiveData, DeviceID.CoinOut_2)
    End Sub
    Private Sub DataReceivedCoinOut5(ByVal ReceiveData As String)
        UpdateDataReceivedCoinOut(ReceiveData, DeviceID.CoinOut_5)
    End Sub
    Private Sub DataReceivedCoinOut10(ByVal ReceiveData As String)
        UpdateDataReceivedCoinOut(ReceiveData, DeviceID.CoinOut_10)
    End Sub

    Private Sub UpdateDataReceivedCoinOut(ByVal ReceiveData As String, ByVal DeviceID As String)
        Select Case ReceiveData
            Case CoinOutStatus.Ready
                UpdateDeviceStatus(DeviceID, CoinOutStatus.Ready)
            Case CoinOutStatus.Disconnected
                UpdateDeviceStatus(DeviceID, CoinOutStatus.Disconnected)
                SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
            'Case CoinOutStatus.Enable_BA_if_hopper_problems_recovered
            '    UpdateDeviceStatus(DeviceID, CoinOutStatus.Enable_BA_if_hopper_problems_recovered)
            'Case CoinOutStatus.Inhibit_BA_if_hopper_problems_occurred
            '    UpdateDeviceStatus(DeviceID, CoinOutStatus.Inhibit_BA_if_hopper_problems_occurred)
            Case CoinOutStatus.Mortor_Problem
                UpdateDeviceStatus(DeviceID, CoinOutStatus.Mortor_Problem)
                SendKioskAlarm("COIN_OUT_MORTOR_PROBLEM", True)
            'Case CoinOutStatus.Insufficient_Coin
            '    UpdateDeviceStatus(DeviceID, CoinOutStatus.Insufficient_Coin)
            Case CoinOutStatus.Dedects_coin_dispensing_activity_after_suspending_the_dispene_signal
                UpdateDeviceStatus(DeviceID, CoinOutStatus.Dedects_coin_dispensing_activity_after_suspending_the_dispene_signal)
                SendKioskAlarm("COIN_OUT_DISPENSE_AFTER_SUSPENED", True)
            Case CoinOutStatus.Reserved
                UpdateDeviceStatus(DeviceID, CoinOutStatus.Reserved)
                SendKioskAlarm("COIN_OUT_RESERVED", True)
            Case CoinOutStatus.Prism_Sersor_Failure
                UpdateDeviceStatus(DeviceID, CoinOutStatus.Prism_Sersor_Failure)
                SendKioskAlarm("COIN_OUT_PRISM_SERSOR_FAILURE", True)
            Case CoinOutStatus.Shaft_Sersor_Failure
                UpdateDeviceStatus(DeviceID, CoinOutStatus.Shaft_Sersor_Failure)
                SendKioskAlarm("COIN_OUT_SHAFT_SERSOR_FAILURE", True)
        End Select
    End Sub

    Public Function CheckStockAndStatusAllDevice() As String
        Dim ret As String = ""
        Dim DeviceMsg As String = ""
        Dim StockMsg As String = ""
        Try
            'จะต้องคิวรี่ใหม่ทุกครั้ง เพราะ Status อาจมีการเปลี่ยนแปลง
            Dim sql As String = "select ms_device_id,ms_device_status_id,max_qty,warning_qty, critical_qty, current_qty"
            sql += " from MS_KIOSK_DEVICE "
            sql += " where ms_kiosk_id=@_KIOSK_ID"

            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", KioskData.KioskID)

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, Nothing, p)
            If dt.Rows.Count > 0 Then
                'ตรวจสอบการทำงานเพื่อส่ง Alarm
                InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfigData.KioskLockerForm.Home, KioskConfigData.KioskLockerStep.Home_CheckHardwareStatus, "Start Check Hardware", False)
                InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfigData.KioskLockerForm.Home, KioskConfigData.KioskLockerStep.Home_CheckStockQty, "Start Check Stock", False)
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(i)
                    Dim StatusName As String = ""
                    Dim StatusIsProblem As String = ""
                    Dim DeviceName As String = ""
                    Dim DeviceTypeId As Long = 0
                    Dim movement As String = ""
                    Dim DeviceID As Long = dr("ms_device_id")

                    'Check Hardware Status
                    DeviceStatusList.DefaultView.RowFilter = "id='" & dr("ms_device_status_id") & "'"
                    If DeviceStatusList.DefaultView.Count > 0 Then
                        StatusName = DeviceStatusList.DefaultView(0)("status_name")
                        StatusIsProblem = DeviceStatusList.DefaultView(0)("is_problem")
                    End If
                    DeviceStatusList.DefaultView.RowFilter = ""
                    '#####################################################################


                    'Check Stock Status
                    DeviceInfoList.DefaultView.RowFilter = "device_id='" & DeviceID & "'"
                    If DeviceInfoList.DefaultView.Count > 0 Then
                        DeviceName = DeviceInfoList.DefaultView(0)("device_name_en")
                        DeviceTypeId = DeviceInfoList.DefaultView(0)("device_type_id")

                        If Convert.IsDBNull(DeviceInfoList.DefaultView(0)("movement_direction")) = False Then
                            movement = DeviceInfoList.DefaultView(0)("movement_direction")  '1 คือ ฝั่งรับ,  -1 คือ ฝั่งจ่าย,  0 คือ ไม่นับ Stock
                        Else
                            movement = "0"
                        End If
                    End If
                    DeviceInfoList.DefaultView.RowFilter = ""

                    If StatusIsProblem = "Y" Then
                        DeviceMsg = DeviceMsg & DeviceName & " Status Is " & StatusName & vbCrLf
                    End If

                    Dim CriticalQty As Integer = Convert.ToInt16(dr("critical_qty"))
                    Dim CurrentQty As Integer = Convert.ToInt16(dr("current_qty"))
                    Dim IsAlarm As Boolean = False
                    Select Case DeviceTypeId
                        Case DeviceType.BanknoteIn, DeviceType.BanknoteOut, DeviceType.CoinIn, DeviceType.CoinOut, DeviceType.Printer
                            If CInt(movement) = 1 Then
                                If CInt(CurrentQty) >= CInt(CriticalQty) Then
                                    StockMsg = StockMsg & DeviceName & " Stock Is Critical" & vbCrLf
                                    IsAlarm = True
                                End If
                            ElseIf CInt(movement) = -1 Then
                                If CurrentQty <= CInt(CriticalQty) Then
                                    StockMsg = StockMsg & DeviceName & " Stock Is Critical" & vbCrLf
                                    IsAlarm = True
                                End If
                            End If
                    End Select

                    Dim AlarmProblem As String = ""
                    Select Case DeviceTypeId
                        Case DeviceType.BanknoteIn
                            AlarmProblem = "CASH_IN_STOCK_CRITICAL"
                        Case DeviceType.BanknoteOut
                            AlarmProblem = "CASH_OUT_STOCK_CRITICAL"
                        Case DeviceType.CoinIn
                            AlarmProblem = "COIN_IN_STOCK_CRITICAL"
                        Case DeviceType.CoinOut
                            AlarmProblem = "COIN_OUT_STOCK_CRITICAL"
                        Case DeviceType.Printer
                            AlarmProblem = "PRINTER_STOCK_CRITICAL"
                    End Select

                    If AlarmProblem.Trim <> "" Then
                        SendKioskAlarm(AlarmProblem, IsAlarm)
                    End If
                    '##########################################################################
                Next

                If DeviceMsg.Trim <> "" Then
                    InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfigData.KioskLockerForm.Home, KioskConfigData.KioskLockerStep.Home_CheckHardwareStatus, DeviceMsg, True)
                End If
                If StockMsg.Trim <> "" Then
                    InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfigData.KioskLockerForm.Home, KioskConfigData.KioskLockerStep.Home_CheckStockQty, StockMsg, True)
                End If


                '-------------------------------------------------------------------------------
                'ตรวจสอบเงื่อนไขเพื่อหยุดการทำงานของตู้
                Dim DTStatus As DataTable = GetStatusAllDeviceDT()
                If DTStatus.Rows.Count > 0 Then
                    'ถ้า แผงควบคุม Solenoid, แผงควบคุม LED, แผงควบคุม Sensor อย่างใดอย่างนึงใช้งานไม่ได้ (ms_device_status<>1)ให้แสดง Error
                    Dim tmpdr() As DataRow = DTStatus.Select("(device_id = " & DeviceID.SolenoidBoard & " or device_id = " & DeviceID.LEDBoard & "  or device_id = " & DeviceID.SensorBoard & ") and ms_device_status_id <> 1")
                    If tmpdr.Length > 0 Then
                        Return "Error"
                    End If

                    'ถ้าเครื่องรับเหรียญ กับเครื่องรับธนบัตร ใช้งานไม่ได้พร้อมกัน ให้แสดง Error
                    tmpdr = DTStatus.Select("(device_id = " & DeviceID.CoinIn & " and ms_device_status_id <> 1) or (device_id = " & DeviceID.BankNoteIn & " and ms_device_status_id <> 1 ) ")
                    If tmpdr.Length = 2 Then
                        Return "Error"
                    End If

                    'ถ้าเครื่องอ่าน Passport กับเครื่องอ่าน QR Code ใช้งานไม่ได้พร้อมกันให้แสดง Error
                    tmpdr = DTStatus.Select("(device_id = " & DeviceID.IDCardPassportScanner & " or device_id = " & DeviceID.QRCodeReader & ") and ms_device_status_id <> 1")
                    If tmpdr.Length = 2 Then
                        Return "Error"
                    End If

                    ''ถ้าเครื่องทอนเหรียญ 5 บาท ใช้งานไม่ได้ (ms_device_status<>1) ให้แสดง Error
                    'tmpdr = DTStatus.Select("device_id = " & DeviceID.CoinOut_5 & " and ms_device_status_id <> 1")
                    'If tmpdr.Length > 0 Then
                    '    Return "Error"
                    'End If

                    '' ถ้าเหรียญ 5 หมด
                    'tmpdr = DTStatus.Select("device_id = " & DeviceID.CoinOut_5 & "  and stock_status = 'Critical'")
                    'If tmpdr.Length > 0 Then
                    '    Return "Error"
                    'End If

                    'ถ้าเครื่องรับเหรียญกับรับแบงค์ใช้งานไม่ได้พร้อมกัน
                    tmpdr = DTStatus.Select("( device_id = " & DeviceID.CoinIn & " or device_id = " & DeviceID.BankNoteIn & " ) and ms_device_status_id <> 1")
                    If tmpdr.Length = 2 Then
                        Return "Error"
                    End If
                End If

                '##############################################################################
            End If

            dt.Dispose()
        Catch ex As Exception
            InsertErrorLog("Exceptin : " & ex.Message & vbNewLine & ex.StackTrace, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, 0)
            ret += "Check Device Status Fail"
        End Try

        Return ret
    End Function

    Public Function GetStatusAllDeviceDT() As DataTable
        Dim sql As String = "select d.id device_id, d.device_name_th," & vbNewLine
        sql += "    (case dt.movement_direction " & vbNewLine
        sql += "        when 1 then" & vbNewLine
        sql += "            Case when kd.current_qty>=kd.critical_qty then 'Critical'" & vbNewLine
        sql += "                when kd.current_qty>=kd.warning_qty then 'Warning'" & vbNewLine
        sql += "                Else 'Normal'" & vbNewLine
        sql += "            End" & vbNewLine
        sql += "        when -1 then" & vbNewLine
        sql += "            Case when kd.current_qty<=kd.critical_qty then 'Critical'" & vbNewLine
        sql += "                when kd.current_qty<=kd.warning_qty then 'Warning'" & vbNewLine
        sql += "                Else 'Normal'" & vbNewLine
        sql += "            End" & vbNewLine
        sql += "        End) stock_status," & vbNewLine
        sql += " kd.ms_device_status_id" & vbNewLine
        sql += " From MS_KIOSK_DEVICE kd" & vbNewLine
        sql += " inner Join MS_DEVICE d on d.id=kd.ms_device_id" & vbNewLine
        sql += " inner join MS_DEVICE_TYPE dt on dt.id=d.ms_device_type_id" & vbNewLine
        'sql += "  where kd.ms_kiosk_id in (select id from MS_KIOSK where ms_location_id=@_LOCATION_ID)" & vbNewLine
        sql += " And d.active_status='Y'"

        Dim DT As DataTable = KioskDB.ExecuteTable(sql)
        Return DT
    End Function

    Public Function GetStatusByDeviceID(DeviceID As Long) As DataTable
        Dim ret As New DataTable
        Dim dt As DataTable = GetStatusAllDeviceDT()
        If dt.Rows.Count > 0 Then
            dt.DefaultView.RowFilter = "device_id=" & DeviceID
            If dt.DefaultView.Count > 0 Then
                ret = dt.DefaultView.ToTable.Copy
            End If
        End If
        dt.Dispose()

        Return ret
    End Function
#End Region


    Public Sub ShowFormError(ByVal Header As String, ByVal Detail As String, ByVal MsAppScreenID As Long, MsAppStepID As Long, Optional ByVal ApplicationOutOfService As Boolean = False)
        Try
            If ApplicationOutOfService = True Then
                InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, MsAppScreenID, MsAppStepID, Header & vbNewLine & Detail, True)
            End If
            OutOfService = ApplicationOutOfService


            Dim f_err As New frmLockerError
            'f_err.lblHeader.Text = Herder
            'f_err.lblDetail.Text = Detail
            f_err.MdiParent = frmMain
            f_err.Show()
            frmMain.CloseAllChildForm(f_err)
            frmMain.btnPointer.Visible = True
        Catch ex As Exception

        End Try
    End Sub

#Region "Transaction"
    Public Function CreateNewDepositTransaction() As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            Dim lnq As New TbServiceTransactionKioskLinqDB
            lnq.TRANS_NO = genNewTransectionNo()
            lnq.TRANS_START_TIME = DateTime.Now
            lnq.MS_KIOSK_ID = KioskData.KioskID
            'lnq.TRANSACTION_SERVICE = "1"  'Deposit Belonging

            Dim trans As New KioskTransactionDB
            ret = lnq.InsertData(KioskData.MacAddress, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()

                ServiceID = ConstantsData.TransactionType.DepositBelonging
                Customer.ServiceTransactionID = lnq.ID
                Customer.DepositTransNo = lnq.TRANS_NO
                Customer.TransStatus = DepositTransactionData.TransactionStatus.Inprogress
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing

        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception | " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    Public Function UpdateServiceTransaction(Cust As DepositTransactionData) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        If Cust.ServiceTransactionID = 0 Then Return ret

        Dim MsAppStepID As Int16 = 0
        Try
            Dim vDateNow As DateTime = DateTime.Now
            Dim lnq As New TbServiceTransactionKioskLinqDB
            lnq.GetDataByPK(Cust.ServiceTransactionID, Nothing)
            If lnq.ID > 0 Then
                lnq.TRANS_END_TIME = vDateNow
                If Cust.LockerID > 0 Then lnq.MS_LOCKER_ID = Cust.LockerID
                lnq.PASSPORT_NO = Cust.PassportNo
                lnq.IDCARD_NO = Cust.IDCardNo
                lnq.NATION_CODE = Cust.NationCode
                lnq.FIRST_NAME = Cust.FirstName
                lnq.LAST_NAME = Cust.LastName
                lnq.GENDER = Cust.Gender
                lnq.BIRTH_DATE = Cust.BirthDate
                lnq.PASSPORT_EXPIRE_DATE = Cust.PassportExpireDate
                lnq.IDCARD_EXPIRE_DATE = Cust.IDCardExpireDate
                lnq.CUST_IMAGE = Cust.CustomerImage
                lnq.SERVICE_RATE = Cust.ServiceRate
                lnq.SERVICE_RATE_LIMIT_DAY = Cust.ServiceRateLimitDay
                lnq.DEPOSIT_AMT = Cust.DepositAmount
                lnq.PAID_TIME = Cust.PaidTime
                lnq.RECEIVE_COIN1 = Cust.ReceiveCoin1
                lnq.RECEIVE_COIN2 = Cust.ReceiveCoin2
                lnq.RECEIVE_COIN5 = Cust.ReceiveCoin5
                lnq.RECEIVE_COIN10 = Cust.ReceiveCoin10
                lnq.RECEIVE_BANKNOTE20 = Cust.ReceiveBankNote20
                lnq.RECEIVE_BANKNOTE50 = Cust.ReceiveBankNote50
                lnq.RECEIVE_BANKNOTE100 = Cust.ReceiveBankNote100
                lnq.RECEIVE_BANKNOTE500 = Cust.ReceiveBankNote500
                lnq.RECEIVE_BANKNOTE1000 = Cust.ReceiveBankNote1000
                lnq.CHANGE_COIN1 = Cust.ChangeCoin1
                lnq.CHANGE_COIN2 = Cust.ChangeCoin2
                lnq.CHANGE_COIN5 = Cust.ChangeCoin5
                lnq.CHANGE_COIN10 = Cust.ChangeCoin10
                lnq.CHANGE_BANKNOTE20 = Cust.ChangeBankNote20
                lnq.CHANGE_BANKNOTE50 = Cust.ChangeBankNote50
                lnq.CHANGE_BANKNOTE100 = Cust.ChangeBankNote100
                lnq.CHANGE_BANKNOTE500 = Cust.ChangeBankNote500
                lnq.TRANS_STATUS = Convert.ToInt16(Cust.TransStatus).ToString
                lnq.MS_APP_SCREEN_ID = Convert.ToInt16(KioskConfig.SelectForm).ToString

                MsAppStepID = GetLastActivityStepID(Cust.DepositTransNo, "")
                lnq.MS_APP_STEP_ID = MsAppStepID
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                ret = lnq.UpdateData(KioskData.MacAddress, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    InsertErrorLog(ret.ErrorMessage, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, MsAppStepID)
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, MsAppStepID)
        End Try

        Return ret
    End Function

    Public Function UpdateDepositStatus(ServiceTransactionID As Long, TransStatus As DepositTransactionData.TransactionStatus, MsAppStepID As KioskConfigData.KioskLockerStep) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            Dim sql As String = " update tb_service_transaction "
            sql += " set trans_end_time = getdate()"
            sql += ", trans_status=@_TRANS_STATUS"
            sql += ", ms_app_screen_id=@_MS_APP_SCREEN_ID"
            sql += ", ms_app_step_id=@_MS_APP_STEP_ID"
            sql += ", updated_by = @_UPDATED_BY"
            sql += ", updated_date=getdate()"
            sql += " where id=@_ID"

            Dim p(5) As SqlParameter
            p(0) = KioskDB.SetText("@_TRANS_STATUS", Convert.ToInt16(TransStatus).ToString)
            p(1) = KioskDB.SetBigInt("@_MS_APP_SCREEN_ID", Convert.ToInt16(KioskConfig.SelectForm))
            p(2) = KioskDB.SetBigInt("@_MS_APP_STEP_ID", Convert.ToInt16(MsAppStepID))
            p(3) = KioskDB.SetText("@_UPDATED_BY", KioskData.MacAddress)
            p(4) = KioskDB.SetBigInt("@_ID", ServiceTransactionID)

            Dim trans As New KioskTransactionDB
            ret = KioskDB.ExecuteNonQuery(sql, trans.Trans, p)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()
                Customer.TransStatus = TransStatus
            Else
                trans.RollbackTransaction()
                InsertErrorLog(ret.ErrorMessage, Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID)
            End If
        Catch ex As Exception
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception " & ex.Message & vbNewLine & ex.StackTrace
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace, Customer.DepositTransNo, "", "", KioskConfig.SelectForm, MsAppStepID)
        End Try
        Return ret
    End Function

    Public Function CreateNewPickupTransaction() As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            Dim lnq As New TbPickupTransactionKioskLinqDB
            lnq.TRANSACTION_NO = genNewTransectionNo()
            lnq.TRANS_START_TIME = DateTime.Now
            lnq.MS_KIOSK_ID = KioskData.KioskID
            'lnq.TRANSACTION_SERVICE = "2"  'Pickup Belonging

            Dim trans As New KioskTransactionDB
            ret = lnq.InsertData(KioskData.ComputerName, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()

                ServiceID = ConstantsData.TransactionType.CollectBelonging  'จำเป็นต้องมีเพื่อใช้แยก Service
                Collect.CollectTransactionID = lnq.ID
                Collect.TransactionNo = lnq.TRANSACTION_NO
                Collect.TransStatus = DepositTransactionData.TransactionStatus.Inprogress
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing

        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception | " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function


    Private Function GetLastActivityStepID(DepositTransNo As String, CollectTransNo As String) As Long
        Dim ret As Long = 0
        Try
            Dim p(1) As SqlParameter
            Dim sql As String = " select top 1 id, ms_app_step_id"
            sql += " from TB_LOG_TRANSACTION_ACTIVITY "
            sql += " where ms_app_step_id > 0 "
            If DepositTransNo.Trim <> "" Then
                sql += " and deposit_trans_no = @_TRANS_NO"
                p(0) = KioskDB.SetText("@_TRANS_NO", DepositTransNo)
            ElseIf CollectTransNo.Trim <> "" Then
                sql += " and pickup_trans_no = @_TRANS_NO"
                p(0) = KioskDB.SetText("@_TRANS_NO", CollectTransNo)
            End If
            sql += " order by id desc"

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                If Convert.IsDBNull(dt.Rows(0)("ms_app_step_id")) = False Then
                    ret = Convert.ToInt64(dt.Rows(0)("ms_app_step_id"))
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = 0
        End Try
        Return ret
    End Function

    Public Function UpdateCollectTransaction(pick As CollectTransactionData) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        If pick.CollectTransactionID = 0 Then Return ret

        Try
            Dim vDateNow As DateTime = DateTime.Now
            Dim lnq As New TbPickupTransactionKioskLinqDB
            lnq.GetDataByPK(pick.CollectTransactionID, Nothing)
            If lnq.ID > 0 Then
                lnq.TRANS_END_TIME = vDateNow
                If pick.LockerID > 0 Then lnq.MS_LOCKER_ID = pick.LockerID
                lnq.DEPOSIT_TRANS_NO = pick.DepositTransNo
                lnq.LOST_QR_CODE = pick.LostQRCode
                lnq.SERVICE_AMT = pick.ServiceAmount
                lnq.PICKUP_TIME = pick.PickupTime
                lnq.PAID_TIME = pick.PaidTime
                lnq.RECEIVE_COIN1 = pick.ReceiveCoin1
                lnq.RECEIVE_COIN2 = pick.ReceiveCoin2
                lnq.RECEIVE_COIN5 = pick.ReceiveCoin5
                lnq.RECEIVE_COIN10 = pick.ReceiveCoin10
                lnq.RECEIVE_BANKNOTE20 = pick.ReceiveBankNote20
                lnq.RECEIVE_BANKNOTE50 = pick.ReceiveBankNote50
                lnq.RECEIVE_BANKNOTE100 = pick.ReceiveBankNote100
                lnq.RECEIVE_BANKNOTE500 = pick.ReceiveBankNote500
                lnq.RECEIVE_BANKNOTE1000 = pick.ReceiveBankNote1000
                lnq.CHANGE_COIN1 = pick.ChangeCoin1
                lnq.CHANGE_COIN2 = pick.ChangeCoin2
                lnq.CHANGE_COIN5 = pick.ChangeCoin5
                lnq.CHANGE_COIN10 = pick.ChangeCoin10
                lnq.CHANGE_BANKNOTE20 = pick.ChangeBankNote20
                lnq.CHANGE_BANKNOTE50 = pick.ChangeBankNote50
                lnq.CHANGE_BANKNOTE100 = pick.ChangeBankNote100
                lnq.CHANGE_BANKNOTE500 = pick.ChangeBankNote500
                lnq.TRANS_STATUS = Convert.ToInt16(pick.TransStatus).ToString
                lnq.MS_APP_SCREEN_ID = KioskConfig.SelectForm
                lnq.MS_APP_STEP_ID = GetLastActivityStepID("", pick.TransactionNo)
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                ret = lnq.UpdateData(KioskData.ComputerName, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    InsertErrorLog(ret.ErrorMessage, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, lnq.MS_APP_STEP_ID)
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception | " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    Public Function UpdateCollectStatus(CollectTransactionID As Long, TransStatus As DepositTransactionData.TransactionStatus, MsAppStepID As KioskConfigData.KioskLockerStep) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            Dim sql As String = " update tb_pickup_transaction "
            sql += " set trans_end_time = getdate()"
            sql += ", trans_status=@_TRANS_STATUS"
            sql += ", ms_app_screen_id=@_MS_APP_SCREEN_ID"
            sql += ", ms_app_step_id=@_MS_APP_STEP_ID"
            sql += ", updated_by = @_UPDATED_BY"
            sql += ", updated_date=getdate()"
            sql += " where id=@_ID"

            Dim p(5) As SqlParameter
            p(0) = KioskDB.SetText("@_TRANS_STATUS", Convert.ToInt16(TransStatus).ToString)
            p(1) = KioskDB.SetBigInt("@_MS_APP_SCREEN_ID", Convert.ToInt16(KioskConfig.SelectForm))
            p(2) = KioskDB.SetBigInt("@_MS_APP_STEP_ID", Convert.ToInt16(MsAppStepID))
            p(3) = KioskDB.SetText("@_UPDATED_BY", KioskData.MacAddress)
            p(4) = KioskDB.SetBigInt("@_ID", CollectTransactionID)

            Dim trans As New KioskTransactionDB
            ret = KioskDB.ExecuteNonQuery(sql, trans.Trans, p)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                InsertErrorLog(ret.ErrorMessage, "", Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
            End If
        Catch ex As Exception
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception " & ex.Message & vbNewLine & ex.StackTrace
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace, "", Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
        End Try
        Return ret
    End Function


#Region "Update Service Transaction at Collect "
    Public Function UpdateServiceTransactionServer(DepositTransNo As String, MsStepID As Long) As ServerLinqDB.TABLE.TbServiceTransactionServerLinqDB
        Dim lnq As New ServerLinqDB.TABLE.TbServiceTransactionServerLinqDB
        Try
            lnq.ChkDataByTRANS_NO(DepositTransNo, Nothing)
            If lnq.ID > 0 Then
                If lnq.PAID_TIME.Value.Year = 1 Then
                    lnq.PAID_TIME = IIf(lnq.TRANS_END_TIME.Value.Year = 1, lnq.TRANS_END_TIME, lnq.TRANS_START_TIME)
                End If
                lnq.TRANS_STATUS = Convert.ToInt16(DepositTransactionData.TransactionStatus.Success).ToString
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New ServerLinqDB.ConnectDB.ServerTransactionDB
                Dim ret As ServerLinqDB.ConnectDB.ExecuteDataInfo = lnq.UpdateData(KioskData.MacAddress, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    InsertErrorLog(ret.ErrorMessage, "", Collect.TransactionNo, "", KioskConfig.SelectForm, MsStepID)
                End If
            End If
        Catch ex As Exception
            InsertErrorLog("Exception " & ex.Message & vbNewLine & ex.StackTrace, "", Collect.TransactionNo, "", KioskConfig.SelectForm, MsStepID)
            lnq = New ServerLinqDB.TABLE.TbServiceTransactionServerLinqDB
        End Try
        Return lnq
    End Function

    Public Function UpdateServiceTransactionKiosk(DepositTransNo As String, MsStepID As Long) As TbServiceTransactionKioskLinqDB
        Dim lnq As New TbServiceTransactionKioskLinqDB
        Try
            lnq.ChkDataByTRANS_NO(DepositTransNo, Nothing)
            If lnq.ID > 0 Then
                If Convert.IsDBNull(lnq.PAID_TIME) = True Then
                    lnq.PAID_TIME = IIf(Convert.IsDBNull(lnq.TRANS_END_TIME) = False, lnq.TRANS_END_TIME, lnq.TRANS_START_TIME)
                End If
                lnq.TRANS_STATUS = Convert.ToInt16(DepositTransactionData.TransactionStatus.Success).ToString
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                Dim ret As ExecuteDataInfo = lnq.UpdateData(KioskData.MacAddress, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    InsertErrorLog(ret.ErrorMessage, "", Collect.TransactionNo, "", KioskConfig.SelectForm, MsStepID)
                End If
            End If

        Catch ex As Exception
            InsertErrorLog("Exception " & ex.Message & vbNewLine & ex.StackTrace, "", Collect.TransactionNo, "", KioskConfig.SelectForm, MsStepID)
            lnq = New TbServiceTransactionKioskLinqDB
        End Try
        Return lnq
    End Function
#End Region


    Public Function CreateNewStaffConsoleTransaction(vUserName As String, FirstName As String, LastName As String, CompanyName As String, LoginBy As String) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            Dim lnq As New TbStaffConsoleTransactionKioskLinqDB
            lnq.TRANS_NO = genNewTransectionNo()
            lnq.TRANS_START_TIME = DateTime.Now
            lnq.MS_KIOSK_ID = KioskData.KioskID
            lnq.LOGIN_USERNAME = vUserName
            lnq.LOGIN_FIRST_NAME = FirstName
            lnq.LOGIN_LAST_NAME = LastName
            lnq.LOGIN_COMPANY_NAME = CompanyName
            lnq.LOGIN_BY = LoginBy

            Dim trans As New KioskTransactionDB
            ret = lnq.InsertData(KioskData.IpAddress, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()

                ServiceID = TransactionType.StaffConsole

                StaffConsole.TransNo = lnq.TRANS_NO
                StaffConsole.TransactionID = lnq.ID
                StaffConsole.StartTime = lnq.TRANS_START_TIME
                StaffConsole.FirstName = lnq.LOGIN_FIRST_NAME
                StaffConsole.LastName = lnq.LOGIN_LAST_NAME
                StaffConsole.LoginTime = lnq.TRANS_START_TIME
                StaffConsole.Username = vUserName
                StaffConsole.LoginBy = lnq.LOGIN_BY
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception | " & ex.Message & vbNewLine & ex.StackTrace
            InsertErrorLog("Exception | " & ex.Message & vbNewLine & ex.StackTrace, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, 0)
        End Try
        Return ret
    End Function

    Public Function UpdateKioskCurrentQty(ByVal DeviceID As DeviceID, ByVal Value As Integer, MoneyValue As Integer, ByVal FillSkock As Boolean) As Boolean
        Dim ret As Boolean = False
        Try
            Dim CurrentQty As Integer = 0
            Dim dLnq As New MsKioskDeviceKioskLinqDB
            dLnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(DeviceID, KioskData.KioskID, Nothing)

            If dLnq.ID > 0 Then
                Dim CurrentMoney As Integer = 0

                If FillSkock = True Then
                    'ถ้าเป็นการเติมของใส่ Stock
                    CurrentQty = Value
                    CurrentMoney = MoneyValue
                Else
                    CurrentQty = dLnq.CURRENT_QTY + Value

                    If dLnq.CURRENT_MONEY Is Nothing Then
                        dLnq.CURRENT_MONEY = 0
                    End If
                    CurrentMoney = dLnq.CURRENT_MONEY.Value + MoneyValue
                End If

                dLnq.CURRENT_QTY = CurrentQty
                dLnq.CURRENT_MONEY = CurrentMoney
                dLnq.SYNC_TO_KIOSK = "Y"
                dLnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                Dim re As ExecuteDataInfo = dLnq.UpdateData(KioskData.ComputerName, trans.Trans)
                If re.IsSuccess = True Then
                    trans.CommitTransaction()

                    Dim DeviceTypeId As Long = 0
                    DeviceInfoList.DefaultView.RowFilter = "device_id='" & DeviceID & "'"
                    If DeviceInfoList.DefaultView.Count > 0 Then
                        DeviceTypeId = DeviceInfoList.DefaultView(0)("device_type_id")

                        If Convert.IsDBNull(DeviceInfoList.DefaultView(0)("movement_direction")) = False Then
                            '1 คือ ฝั่งรับ,  -1 คือ ฝั่งจ่าย,  0 คือ ไม่นับ Stock
                            Dim movement As String = DeviceInfoList.DefaultView(0)("movement_direction")
                            Dim IsAlarm As Boolean = False

                            If CInt(movement) = 1 Then
                                If CInt(CurrentQty) >= dLnq.CRITICAL_QTY Then
                                    IsAlarm = True
                                End If
                            ElseIf CInt(movement) = -1 Then
                                If CurrentQty <= dLnq.CRITICAL_QTY Then
                                    IsAlarm = True
                                End If
                            End If

                            Dim AlarmProblem As String = ""
                            Select Case DeviceTypeId
                                Case DeviceType.BanknoteIn
                                    AlarmProblem = "CASH_IN_STOCK_CRITICAL"
                                Case DeviceType.BanknoteOut
                                    AlarmProblem = "CASH_OUT_STOCK_CRITICAL"
                                Case DeviceType.CoinIn
                                    AlarmProblem = "COIN_IN_STOCK_CRITICAL"
                                Case DeviceType.CoinOut
                                    AlarmProblem = "COIN_OUT_STOCK_CRITICAL"
                                Case DeviceType.Printer
                                    AlarmProblem = "PRINTER_STOCK_CRITICAL"
                            End Select

                            SendKioskAlarm(AlarmProblem, IsAlarm)
                        End If
                    End If
                    DeviceInfoList.DefaultView.RowFilter = ""
                Else
                    trans.RollbackTransaction()
                    ret = False
                    InsertErrorLog(re.ErrorMessage, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, 0)
                End If
            Else
                ret = False
                InsertErrorLog(dLnq.ErrorMessage, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, 0)
            End If
        Catch ex As Exception
            ret = False
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace, Customer.DepositTransNo, Collect.TransactionNo, StaffConsole.TransactionID, KioskConfig.SelectForm, 0)
        End Try

        Return ret
    End Function

    Public Sub InsertLogTransactionActivity(StaffConsoleTransNo As String, MsAppScreenID As Long, MsAppStepCode As Long, LogMsg As String, IsProblem As Boolean)
        InsertLogTransactionActivity("", "", StaffConsoleTransNo, MsAppScreenID, MsAppStepCode, LogMsg, IsProblem)
    End Sub
    Public Sub InsertLogTransactionActivity(DepositTransNo As String, CollectTransNo As String, StaffConsoleTransNo As String, MsAppScreenID As Long, MsAppStepCode As Long, LogMsg As String, IsProblem As Boolean)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        Dim CreateBy As String = ClassName & "." & FunctionName
        Dim MsAppStepID As Long = 0
        Try
            Try
                AppStepList.DefaultView.RowFilter = "app_step_code='" & MsAppStepCode & "'"
                If AppStepList.DefaultView.Count > 0 Then
                    MsAppStepID = AppStepList.DefaultView(0)("id")

                    If LogMsg.Trim = "" Then
                        LogMsg = AppStepList.DefaultView(0)("step_name_th")
                    Else
                        LogMsg = AppStepList.DefaultView(0)("step_name_th") & " " & LogMsg
                    End If
                Else

                End If
                AppStepList.DefaultView.RowFilter = ""
            Catch ex As Exception

            End Try


            Dim lnq As New TbLogTransactionActivityKioskLinqDB
            lnq.MS_KIOSK_ID = KioskData.KioskID
            lnq.TRANS_DATE = DateTime.Now
            lnq.DEPOSIT_TRANS_NO = DepositTransNo
            lnq.PICKUP_TRANS_NO = CollectTransNo
            lnq.STAFF_CONSOLE_TRANS_NO = StaffConsoleTransNo
            lnq.MS_APP_SCREEN_ID = MsAppScreenID
            lnq.MS_APP_STEP_ID = MsAppStepID
            lnq.LOG_DESC = LogMsg
            lnq.IS_PROBLEM = IIf(IsProblem = True, "Y", "N")
            lnq.SYNC_TO_SERVER = "N"

            Dim trans As New KioskTransactionDB
            Dim ret As ExecuteDataInfo = lnq.InsertData(CreateBy, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()
                SendKioskAlarm("KIOSK_ERROR_INSERT_LOG_ACTIVITY", False)
            Else
                trans.RollbackTransaction()
                SendKioskAlarm("KIOSK_ERROR_INSERT_LOG_ACTIVITY", True)

                Dim _Err As String = ret.ErrorMessage & vbNewLine
                _Err += "ClassName=" & ClassName & "&FunctionName=" & FunctionName & vbNewLine
                _Err += "&DepositTransNo=" & DepositTransNo & "&CollectTransNo=" & CollectTransNo & "&StaffConsoleTransNo=" & StaffConsoleTransNo & vbNewLine
                _Err += "&MsAppStepID=" & MsAppStepID & " &MsAppStepID=" & MsAppStepID & vbNewLine
                _Err += "&LogMsg=" & LogMsg & "&IsProblem=" & IsProblem
                InsertErrorLog(_Err, DepositTransNo, CollectTransNo, StaffConsoleTransNo, MsAppScreenID, MsAppStepID)
            End If

        Catch ex As Exception
            SendKioskAlarm("KIOSK_ERROR_INSERT_LOG_ACTIVITY", True)

            Dim _Err As String = "Exception : " & ex.Message & " " & ex.StackTrace & vbNewLine
            _Err += "ClassName=" & ClassName & "&FunctionName=" & FunctionName & vbNewLine
            _Err += "&DepositTransNo=" & DepositTransNo & "&CollectTransNo=" & CollectTransNo & "&StaffConsoleTransNo=" & StaffConsoleTransNo & vbNewLine
            _Err += "&MsAppScreenID=" & MsAppScreenID & " &MsAppStepCode=" & MsAppStepCode & vbNewLine
            _Err += "&LogMsg=" & LogMsg & "&IsProblem=" & LogMsg
            InsertErrorLog(_Err, DepositTransNo, CollectTransNo, StaffConsoleTransNo, MsAppScreenID, MsAppStepID)
        End Try
    End Sub

    Public Sub InsertErrorLogSC(CreatedBy As String, ErrorMessage As String, StaffConsoleTransNo As String, MsAppScreenID As Long, MsAppStepID As Long)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        'Dim CreatedBy As String = Environment.MachineName
        Try
            Dim lnq As New TbLogErrorKioskLinqDB
            lnq.MS_KIOSK_ID = IIf(KioskData.KioskID = "", 0, KioskData.KioskID)
            lnq.CLASS_NAME = ClassName
            lnq.FUNCTION_NAME = FunctionName & " Line No :" & LineNo
            lnq.ERROR_TIME = DateTime.Now
            lnq.ERROR_DESC = ErrorMessage
            lnq.DEPOSIT_TRANS_NO = ""
            lnq.PICKUP_TRANS_NO = ""
            lnq.STAFF_CONSOLE_TRANS_NO = StaffConsoleTransNo
            lnq.MS_APP_SCREEN_ID = MsAppScreenID
            lnq.MS_APP_STEP_ID = MsAppStepID
            lnq.SYNC_TO_SERVER = "N"

            Dim trans As New KioskTransactionDB
            Dim ret As ExecuteDataInfo = lnq.InsertData(CreatedBy, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()

                Dim _Err As String = ret.ErrorMessage & vbNewLine
                _Err += "ClassName=" & ClassName & "&FunctionName=" & FunctionName & vbNewLine
                _Err += "&CreatedBy=" & CreatedBy & "&StaffConsoleTransNo=" & StaffConsoleTransNo
                _Err += "&MsAppStepID=" & MsAppStepID & " &MsAppStepID=" & MsAppStepID & vbNewLine
                _Err += "&ErrorMessage=" & ErrorMessage
                Engine.LogFileENG.CreateKioskErrorLog(CreatedBy, _Err, IIf(KioskData.KioskID = "", 0, KioskData.KioskID))
            End If
        Catch ex As Exception
            Dim _Err As String = "Exception : " & ex.Message & " " & ex.StackTrace & vbNewLine
            _Err += "ClassName=" & ClassName & "&FunctionName=" & FunctionName & vbNewLine
            _Err += "&CreatedBy=" & CreatedBy & "&StaffConsoleTransNo=" & StaffConsoleTransNo
            _Err += "&MsAppStepID=" & MsAppStepID & " &MsAppStepID=" & MsAppStepID & vbNewLine
            _Err += "&ErrorMessage=" & ErrorMessage
            Engine.LogFileENG.CreateKioskErrorLog(CreatedBy, _Err, KioskData.KioskID)
        End Try

        'SendKioskAlarm("KIOSK_INSERT_ERROR_LOG", True)
    End Sub

    Public Sub InsertErrorLog(ErrorMessage As String, DepositTransNo As String, CollectTransNo As String, StaffConsoleTransNo As String, MsAppScreenID As Long, MsAppStepID As Long)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        Dim CreatedBy As String = Environment.MachineName
        Try
            Dim lnq As New TbLogErrorKioskLinqDB
            lnq.MS_KIOSK_ID = IIf(KioskData.KioskID = "", 0, KioskData.KioskID)
            lnq.CLASS_NAME = ClassName
            lnq.FUNCTION_NAME = FunctionName & " Line No :" & LineNo
            lnq.ERROR_TIME = DateTime.Now
            lnq.ERROR_DESC = ErrorMessage
            lnq.DEPOSIT_TRANS_NO = DepositTransNo
            lnq.PICKUP_TRANS_NO = CollectTransNo
            lnq.STAFF_CONSOLE_TRANS_NO = StaffConsoleTransNo
            lnq.MS_APP_SCREEN_ID = MsAppScreenID
            lnq.MS_APP_STEP_ID = MsAppStepID
            lnq.SYNC_TO_SERVER = "N"

            Dim trans As New KioskTransactionDB
            Dim ret As ExecuteDataInfo = lnq.InsertData(CreatedBy, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()

                Dim _Err As String = ret.ErrorMessage & vbNewLine
                _Err += "ClassName=" & ClassName & "&FunctionName=" & FunctionName & vbNewLine
                _Err += "&DepositTransNo=" & DepositTransNo & vbNewLine
                _Err += "&MsAppStepID=" & MsAppStepID & " &MsAppStepID=" & MsAppStepID & vbNewLine
                _Err += "&ErrorMessage=" & ErrorMessage
                Engine.LogFileENG.CreateKioskErrorLog(CreatedBy, _Err, IIf(KioskData.KioskID = "", 0, KioskData.KioskID))
            End If
        Catch ex As Exception
            Dim _Err As String = "Exception : " & ex.Message & " " & ex.StackTrace & vbNewLine
            _Err += "ClassName=" & ClassName & "&FunctionName=" & FunctionName & vbNewLine
            _Err += "&DepositTransNo=" & DepositTransNo & vbNewLine
            _Err += "&MsAppStepID=" & MsAppStepID & " &MsAppStepID=" & MsAppStepID & vbNewLine
            _Err += "&ErrorMessage=" & ErrorMessage
            Engine.LogFileENG.CreateKioskErrorLog(CreatedBy, _Err, KioskData.KioskID)
        End Try

        If KioskData.KioskID <> "" Then
            SendKioskAlarm("KIOSK_INSERT_ERROR_LOG", True)
        End If


    End Sub
#End Region

#Region "Call Webservice Locker"

    Public Function LogInSSO(ByVal Username As String, ByVal Password As String, WS As Webservice_Locker.ATBLockerWebService) As Webservice_Locker.LoginReturnData
        Dim ret As New Webservice_Locker.LoginReturnData
        Try
            ret = WS.KioskLoginStaffConsole(Username, Password, "Locker Staff Console", KioskData.KioskID)
        Catch ex As Exception
            ret = New Webservice_Locker.LoginReturnData
            ret.ErrorMessage = ex.Message & " " & ex.StackTrace
        End Try

        Return ret
    End Function

#End Region

#Region "Call Webservice Alarm"
    Public Sub SendKioskAlarm(AlarmProblem As String, IsProblem As Boolean)
        Dim DepositTransNo As String = Customer.DepositTransNo
        If DepositTransNo = "" Then
            DepositTransNo = Collect.DepositTransNo
        End If

        Try
            Dim ret As New ExecuteDataInfo
            Dim trans As New KioskTransactionDB
            Dim lnq As New MsKioskAlarmKioskLinqDB
            lnq.ChkDataByALARM_PROBLEM_MS_KIOSK_ID(AlarmProblem, KioskData.KioskID, trans.Trans)
            If lnq.ID > 0 Then
                If IsProblem <> (lnq.IS_ALARM = "Y") Then
                    lnq.IS_SEND_ALARM = "N"
                    lnq.LAST_SEND_TIME = New DateTime(1, 1, 1)

                    ret = lnq.UpdateData(Environment.NewLine, trans.Trans)
                Else
                    ret.IsSuccess = True
                End If
            Else
                lnq.MS_KIOSK_ID = KioskData.KioskID
                lnq.ALARM_PROBLEM = AlarmProblem
                lnq.IS_ALARM = IIf(IsProblem = True, "Y", "N")
                lnq.IS_SEND_ALARM = "N"
                lnq.LAST_SEND_TIME = New DateTime(1, 1, 1)

                ret = lnq.InsertData(Environment.NewLine, trans.Trans)
            End If

            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                InsertErrorLog(ret.ErrorMessage, DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            End If

            lnq = Nothing
        Catch ex As Exception
            InsertErrorLog("Exception SendKioskAlarm " & ex.Message & vbNewLine & ex.StackTrace, DepositTransNo, Collect.TransactionNo, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
        End Try


        'Try
        '    If AlarmMasterList.Rows.Count > 0 Then
        '        AlarmMasterList.DefaultView.RowFilter = "alarm_problem='" & AlarmProblem & "'"
        '        If AlarmMasterList.DefaultView.Count > 0 Then
        '            Dim ws As New AlarmWebReference.ApplicationWebservice
        '            ws.Timeout = 10000
        '            ws.Url = KioskConfig.WebServiceAlarmURL
        '            'ws.Url = "http://localhost:37814/ApplicationWebservice.asmx?WSDL"

        '            Dim ret As String = ws.SendAlarmOtherApp(KioskData.MacAddress, AlarmMasterList.DefaultView.ToTable.Copy, IsProblem, KioskConfig.LocationName, "Left & Lug Service Info " & KioskConfig.LocationName, "Alarm Left & Lug " & AlarmProblem)
        '            ws.Dispose()
        '        End If
        '        AlarmMasterList.DefaultView.RowFilter = ""
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Public Function CheckInternetConnection(URL As String) As Boolean
        If URL = "" Then Return False

        Dim ret = False
        Dim req As WebRequest = WebRequest.Create(URL)
        Dim resp As WebResponse
        Try
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            req.Timeout = 500
            resp = req.GetResponse
            resp.Close()
            req = Nothing
            ret = True
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

#End Region

    '#Region "Change Language"
    '    Public Sub SetLanguage(MsStepID As Long)
    '        'Language
    '        Dim sql As String = " update tb_Kiosk_Screen_Control "
    '        If KioskConfig.Language = KioskLanguage.China Then
    '            sql += " set Current_Display = isnull(CH_Display,Default_Display)"
    '        ElseIf KioskConfig.Language = KioskLanguage.English Then
    '            sql += " set Current_Display = isnull(EN_Display,Default_Display)"
    '            'ElseIf Kiosk.Language = KioskLanguage.Russia Then
    '            '    sql += " set Current_Display = isnull(RU_Display,Default_Display)"
    '        ElseIf KioskConfig.Language = KioskLanguage.Thai Then
    '            sql += " set Current_Display = isnull(TH_Display,Default_Display)"
    '        ElseIf KioskConfig.Language = KioskLanguage.Japan Then

    '        End If

    '        Try
    '            Dim trans As New KioskTransactionDB
    '            Dim ret As ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, trans.Trans)
    '            If ret.IsSuccess = True Then
    '                trans.CommitTransaction()
    '            Else
    '                trans.RollbackTransaction()
    '                InsertErrorLog(ret.ErrorMessage, Customer.DepositTransNo, Collect.TransactionNo, 0, KioskConfig.SelectForm, MsStepID)
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Public Function GetControlLanguage(KOS_ID As Int32) As DataTable
    '        Dim dt As DataTable
    '        Try
    '            Dim sql As String = "select Control_Name, Current_Display, Display_Type "
    '            sql += " from tb_Kiosk_Screen_Control"
    '            sql += " where kos_id=@_KOS_ID"
    '            Dim param(1) As SqlParameter
    '            param(0) = KioskDB.SetInt("@_KOS_ID", KOS_ID)

    '            dt = KioskDB.ExecuteTable(sql, param)

    '        Catch ex As Exception
    '            dt = New DataTable
    '        End Try
    '        Return dt
    '    End Function
    '#End Region

#Region "Font Setting"
    'PRIVATE FONT COLLECTION TO HOLD THE DYNAMIC FONT


    'Public ReadOnly Property GetFont_DB_HelvethaicaAIS_X_65_Med(ByVal Size As Single, ByVal style As FontStyle) As Font
    '    Get
    '        Return New Font(Kiosk.DB_HelvethaicaAIS_X_65_Med.Families(0), Size, style)
    '    End Get

    'End Property

    'Public ReadOnly Property GetFont_DB_HelvethaicaAIS_X_55_Regular(ByVal Size As Single, ByVal style As FontStyle) As Font
    '    Get
    '        Return New Font(Kiosk.DB_HelvethaicaAIS_X_55_Regular.Families(0), Size, style)
    '    End Get
    'End Property

    Public Function LoadFont(FontResources() As Byte, _pfc As PrivateFontCollection) As PrivateFontCollection
        Try
            If _pfc Is Nothing Then _pfc = New PrivateFontCollection
            ''INIT THE FONT COLLECTION
            'LOAD MEMORY POINTER FOR FONT RESOURCE
            Dim fontMemPointer As IntPtr = Marshal.AllocCoTaskMem(FontResources.Length)
            'COPY THE DATA TO THE MEMORY LOCATION
            Marshal.Copy(FontResources, 0, fontMemPointer, FontResources.Length)
            'LOAD THE MEMORY FONT INTO THE PRIVATE FONT COLLECTION
            _pfc.AddMemoryFont(fontMemPointer, FontResources.Length)
            'FREE UNSAFE MEMORY
            Marshal.FreeCoTaskMem(fontMemPointer)
        Catch ex As Exception
            'ERROR LOADING FONT. HANDLE EXCEPTION HERE
            _pfc = New PrivateFontCollection
        End Try
        Return _pfc
    End Function


#End Region


    Public Function OpenLocker(LockerID As Long, PinSolenoid As Integer, PinSensor As String, MsAppStepID As Long) As Boolean
        Dim ret As Boolean = False

        Dim DepositTransNo As String = Customer.DepositTransNo
        If Customer.DepositTransNo = "" Then
            DepositTransNo = Collect.DepositTransNo
        End If

        Try
            ''ต้องสั่ง Connect เพื่อ Check Hardware Status มาแล้วตั้งแต่หน้า Home
            BoardSolenoid.SolenoidOpen(PinSolenoid)

            Dim lnq As New MsLockerKioskLinqDB
            lnq.GetDataByPK(LockerID, Nothing)
            If lnq.ID > 0 Then
                lnq.OPEN_CLOSE_STATUS = "O"  'Locker เปิด
                lnq.CURRENT_AVAILABLE = "N"  'Locker ไม่ว่างแล้ว (มีคนใช้อยู่)
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                If lnq.UpdateData(KioskData.ComputerName, trans.Trans).IsSuccess = True Then
                    trans.CommitTransaction()
                    ret = True
                Else
                    trans.RollbackTransaction()
                    InsertErrorLog(lnq.ErrorMessage, DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
                    InsertLogTransactionActivity(DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "", True)
                End If
            End If
            lnq = Nothing

            'สั่งเปิดตู้ซ้ำ เผื่อกรณีตู้ไม่เปิดออกในครั้งแรก
            Thread.Sleep(2000)
            BoardSolenoid.SolenoidOpen(PinSolenoid)
        Catch ex As Exception
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace, DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID)
            InsertLogTransactionActivity(DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, MsAppStepID, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, True)
            ShowFormError("Out of Service", "", KioskConfig.SelectForm, MsAppStepID, True)
        End Try

        Return ret
    End Function


    Public Sub GetKioskConfig()
        'กำหนดค่า Config ของ Kiosk ทุกครั้งที่เข้าหน้าแรก
        Try
            Dim lnq As New CfKioskSysconfigKioskLinqDB
            lnq.ChkDataByMS_KIOSK_ID(KioskData.KioskID, Nothing)
            If lnq.ID > 0 Then
                KioskConfig = New KioskConfigData(KioskData.KioskID)
                KioskConfig.IsLoginSSO = IIf(lnq.LOGIN_SSO = "Y", True, False)

                KioskConfig.KioskOpen24Hours = IIf(lnq.KIOSK_OPEN24 = "Y", True, False)
                If KioskConfig.KioskOpen24Hours = False Then
                    Dim oTime() As String = Split(lnq.KIOSK_OPEN_TIME, "-")
                    If oTime.Length = 2 Then
                        KioskConfig.KioskOpenTime = oTime(0)
                        KioskConfig.KioskCloseTime = oTime(1)
                    Else
                        KioskConfig.KioskOpenTime = "00:00"
                        KioskConfig.KioskCloseTime = "00:00"
                    End If
                Else
                    KioskConfig.KioskOpenTime = "00:00"
                    KioskConfig.KioskCloseTime = "00:00"
                End If

                KioskConfig.LocationCode = lnq.LOCATION_CODE
                KioskConfig.LocationName = lnq.LOCATION_NAME
                KioskConfig.WebserviceLockerURL = lnq.LOCKER_WEBSERVICE_URL
                KioskConfig.WebServiceAlarmURL = lnq.ALARM_WEBSERVICE_URL
                KioskConfig.ScreenSaverSec = lnq.SCREEN_SAVER_SEC
                KioskConfig.TimeOutSec = lnq.TIME_OUT_SEC
                KioskConfig.ShowMsgSec = lnq.SHOW_MSG_SEC
                KioskConfig.CardExpireMonth = lnq.CARD_EXPIRE_MONTH
                KioskConfig.PassportExpireMonth = lnq.PASSPORT_EXPIRE_MONTH
                KioskConfig.PaymentExtendSec = lnq.PAYMENT_EXTEND_SEC
                KioskConfig.LockerPCPosition = lnq.LOCKER_PC_POSITION
                KioskConfig.ContactCenterTelno = lnq.CONTACT_CENTER_TELNO
                KioskConfig.SleepTime = lnq.SLEEP_TIME
                KioskConfig.SleepDuration = lnq.SLEEP_DURATION
            End If
            lnq = Nothing

            InsertLogTransactionActivity("", "", "", KioskConfigData.KioskLockerForm.Main, KioskConfigData.KioskLockerStep.Main_GetKioskConfig, "", False)
        Catch ex As Exception
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Cannot get Kiosk config information", Customer.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_GetKioskConfig)
            ShowFormError("", "", KioskConfigData.KioskLockerForm.Main, KioskConfigData.KioskLockerStep.Main_GetKioskConfig, True)
        End Try
    End Sub

    Public Sub GetKioskDeviceConfig()
        Try
            ''กำหนดค่า Hardware Config COMPORT
            Dim dDt As DataTable = DeviceInfoList
            If dDt.Rows.Count > 0 Then
                For i As Integer = 0 To dDt.Rows.Count - 1
                    Dim dDr As DataRow = dDt.Rows(i)
                    If dDr("type_active_status") = "Y" AndAlso dDr("device_active_status") = "Y" Then

                        Select Case Convert.ToInt16(dDr("device_id"))
                            Case DeviceID.BankNoteIn
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CashInComport = dDr("comport_vid")
                                End If
                            Case DeviceID.BankNoteOut_20
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CashOUT20Comport = dDr("comport_vid")
                                End If

                            Case DeviceID.BankNoteOut_50
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CashOUT50Comport = dDr("comport_vid")
                                End If

                            Case DeviceID.BankNoteOut_100
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CashOUT100Comport = dDr("comport_vid")
                                End If

                            Case DeviceID.BankNoteOut_500
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CashOUT500Comport = dDr("comport_vid")
                                End If

                            Case DeviceID.CoinIn
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CoinInComport = dDr("comport_vid")
                                End If

                            Case DeviceID.CoinOut_1
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CoinOut1Comport = dDr("comport_vid")
                                End If

                            Case DeviceID.CoinOut_2
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CoinOut2Comport = dDr("comport_vid")
                                End If

                            Case DeviceID.CoinOut_5
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CoinOut5Comport = dDr("comport_vid")
                                End If

                            Case DeviceID.CoinOut_10
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.CoinOut10Comport = dDr("comport_vid")
                                End If

                            Case DeviceID.Printer
                                If Convert.IsDBNull(dDr("driver_name1")) = False Then
                                    KioskConfig.PrinterDeviceName = dDr("driver_name1")
                                End If

                            Case DeviceID.IDCardPassportScanner
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.IDCardPassportVID = dDr("comport_vid")
                                End If

                                If Convert.IsDBNull(dDr("driver_name1")) = False Then
                                    KioskConfig.IDCardNoDeviceName = dDr("driver_name1")
                                End If
                                If Convert.IsDBNull(dDr("driver_name2")) = False Then
                                    KioskConfig.PassportDeviceName = dDr("driver_name2")
                                End If

                            Case DeviceID.NetworkConnection

                            Case DeviceID.QRCodeReader
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.QRCodeVID = dDr("comport_vid")
                                End If

                            Case DeviceID.SolenoidBoard
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.SolenoidComport = dDr("comport_vid")
                                End If

                            Case DeviceID.LEDBoard
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.LEDComport = dDr("comport_vid")
                                End If

                            Case DeviceID.SensorBoard
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    KioskConfig.SensorComport = dDr("comport_vid")
                                End If

                        End Select
                    End If
                Next
                InsertLogTransactionActivity("", "", "", KioskConfigData.KioskLockerForm.Main, KioskConfigData.KioskLockerStep.Main_GetDeviceInfo, "", False)
            Else
                InsertErrorLog("Cannot get Kiosk config information", Customer.DepositTransNo, Collect.DepositTransNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_GetDeviceInfo)
                ShowDialogErrorMessage("Cannot get Kiosk setting information")
            End If
            dDt.Dispose()

        Catch ex As Exception

        End Try
    End Sub



    Public Sub SetChildFormLanguage()
        Dim fldName As String = ""
        'Dim fntName As New Font("Thai Sans Lite", FontStyle.Bold)
        Select Case KioskConfig.Language
            Case Data.ConstantsData.KioskLanguage.Thai
                fldName = "TH_Display"
            Case Data.ConstantsData.KioskLanguage.English
                fldName = "EN_Display"
            Case Data.ConstantsData.KioskLanguage.China
                fldName = "CH_Display"
            Case Data.KioskLanguage.Japan
                fldName = "JP_Display"
        End Select

        Try
            LangMasterList.DefaultView.RowFilter = "ms_app_screen_id='" & Convert.ToInt16(KioskConfig.SelectForm) & "'"
            If LangMasterList.DefaultView.Count > 0 Then
                AppScreenList.DefaultView.RowFilter = "id='" & Convert.ToInt16(KioskConfig.SelectForm) & "'"
                If AppScreenList.DefaultView.Count > 0 Then
                    Dim frm As Form = Application.OpenForms(AppScreenList.DefaultView(0)("form_name"))

                    For Each dr As DataRowView In LangMasterList.DefaultView
                        Dim ControlName As String = dr("Control_Name")
                        Dim cc() As Control = frm.Controls.Find(ControlName, True)
                        If cc.Length > 0 Then
                            cc(0).Text = dr(fldName)

                            Dim FontSize As Int16 = dr("font_size")
                            Dim FontStyle As FontStyle = Convert.ToInt16(dr("font_style"))
                            cc(0).Font = New Font("Thai Sans Lite", FontSize, FontStyle)

                            If KioskConfig.Language = Data.ConstantsData.KioskLanguage.China Then
                                FontSize = FontSize * 0.7
                                cc(0).Font = New Font("Hiragino Sans GB W3", FontSize, FontStyle)

                                'cc(0).Font = New Font("Songti SC Black", FontSize, FontStyle)
                            ElseIf KioskConfig.Language = Data.ConstantsData.KioskLanguage.Japan Then
                                FontSize = FontSize * 0.7

                                cc(0).Font = New Font("MS Gothic", FontSize, FontStyle)
                                'cc(0).Font = New Font("ＭＳ Ｐゴシック", FontSize, FontStyle)
                            End If
                        End If
                    Next

                    If KioskConfig.SelectForm = KioskConfigData.KioskLockerForm.CollectSelectDocument Then
                        Select Case KioskConfig.Language
                            Case Data.ConstantsData.KioskLanguage.China, Data.ConstantsData.KioskLanguage.Japan
                                DirectCast(frm, frmCollectSelectDocument).lblPassport.Top = DirectCast(frm, frmCollectSelectDocument).lblQRCode.Top
                            Case Else
                                DirectCast(frm, frmCollectSelectDocument).lblPassport.Top = 210
                        End Select
                    End If
                End If
                AppScreenList.DefaultView.RowFilter = ""


            End If
            LangMasterList.DefaultView.RowFilter = ""
        Catch ex As Exception

        End Try
    End Sub

    'Public Function GetNotificationText(_id As Long) As String
    '    Dim ret As String = ""

    '    Dim fldName As String = ""
    '    Select Case KioskConfig.Language
    '        Case Data.ConstantsData.KioskLanguage.Thai
    '            fldName = "TH_Display"
    '        Case Data.ConstantsData.KioskLanguage.English
    '            fldName = "EN_Display"
    '        Case Data.ConstantsData.KioskLanguage.China
    '            fldName = "CH_Display"
    '        Case Data.KioskLanguage.Japan
    '            fldName = "JP_Display"
    '    End Select
    '    Try
    '        LangNotificationList.DefaultView.RowFilter = "id=" & _id
    '        If LangNotificationList.DefaultView.Count > 0 Then
    '            ret = LangNotificationList.DefaultView(0)(fldName)
    '        End If
    '        LangNotificationList.DefaultView.RowFilter = ""
    '    Catch ex As Exception

    '    End Try
    '    Return ret
    'End Function



    Public Function PickupCalServiceAmount() As Integer
        'คำนวณค่าใช้บริการ
        Dim ret As Integer = 0
        Try
            'หาวันเวลาที่เปิดปิด โดยอ้างอิงจากวันที่เริ่มใช้บริการ
            If KioskConfig.KioskOpen24Hours = False Then
                Dim OpenTime As DateTime = New DateTime(Collect.DepositPaidTime.Year, Collect.DepositPaidTime.Month, Collect.DepositPaidTime.Day, KioskConfig.KioskOpenTime.Split(":")(0), KioskConfig.KioskOpenTime.Split(":")(1), 0)
                Dim CloseTime As New DateTime

                If KioskConfig.KioskOpenTime > KioskConfig.KioskCloseTime Then
                    'กรณีตั้งค่าการเปิดบริการข้ามวัน เช่น 06.00 - 01.00  (หกโมงเช้าถึง ตี 1)
                    Dim CloseDay As DateTime = Collect.DepositPaidTime.AddDays(1)
                    CloseTime = New DateTime(CloseDay.Year, CloseDay.Month, CloseDay.Day, KioskConfig.KioskCloseTime.Split(":")(0), KioskConfig.KioskCloseTime.Split(":")(1), 0)
                Else
                    CloseTime = New DateTime(Collect.DepositPaidTime.Year, Collect.DepositPaidTime.Month, Collect.DepositPaidTime.Day, KioskConfig.KioskCloseTime.Split(":")(0), KioskConfig.KioskCloseTime.Split(":")(1), 0)
                End If

                'ถ้าช่วงเวลาที่ใช้บริการอยู่ในช่วงเวลาที่ เปิด ปิด แสดงว่าเป็นการใช้บริการ 1 วัน
                If Collect.DepositPaidTime >= OpenTime And Collect.PickupTime <= CloseTime Then
                    Dim ServiceSec As Integer = DateDiff(DateInterval.Second, Collect.DepositPaidTime, Collect.PickupTime)
                    Dim ServiceHour As Integer = Math.Ceiling(ServiceSec / 60 / 60) 'จำนวนชั่วโมงปัดเศษขึ้นเสมอ

                    '###########################
                    ret = CalServiceAmountDay1(ServiceHour, Collect.DepositPaidTime)
                Else
                    'กรณีเกิน 1 วัน
                    'ค่าบริการวันแรก ให้คิดตั้งแต่เริ่มใช้บริการ จนถึงเวลาที่ปิดทำการ
                    Dim ServiceSec As Integer = DateDiff(DateInterval.Second, Collect.DepositPaidTime, CloseTime)
                    Dim ServiceHour As Integer = Math.Ceiling(ServiceSec / 60 / 60) 'จำนวนชั่วโมงในวันที่มาฝาก ปัดเศษขึ้นเสมอ

                    ret = CalServiceAmountDay1(ServiceHour, Collect.DepositPaidTime)

                    'วันถัดๆ มา ให้นับตามจำนวนวัน
                    Dim DayQty As Integer = DateDiff(DateInterval.Day, Collect.DepositPaidTime.Date, Collect.PickupTime.Date)

                    'ในกรณีที่กำหนดให้ช่วงเวลาเปิดทำการข้ามวัน เช่น 6 โมงเช้า ถึง ตี 1
                    If KioskConfig.KioskOpenTime > KioskConfig.KioskCloseTime Then
                        'กรณีตั้งค่าการเปิดบริการข้ามวัน เช่น 06.00 - 01.00  (หกโมงเช้าถึง ตี 1)
                        'ให้หาช่วงเวลานับตั้งแต่เที่ยงคืน จนถึงเวลาที่ปิดทำการ เพื่อเช็คว่าเป็นการมารับของในช่วงนี้หรือป่าว ถ้าเป็นการมารับของช่วงนี้จะได้หักออก 1 วัน
                        Dim CloseDay As DateTime = Collect.PickupTime
                        Dim ChkStartTime As New DateTime(CloseDay.Year, CloseDay.Month, CloseDay.Day, 0, 0, 0)  'เที่ยงคืนของการข้ามวัน

                        'เวลาที่ปิดทำการข้ามวัน
                        CloseTime = New DateTime(CloseDay.Year, CloseDay.Month, CloseDay.Day, KioskConfig.KioskCloseTime.Split(":")(0), KioskConfig.KioskCloseTime.Split(":")(1), 0)

                        If ChkStartTime <= Collect.PickupTime And Collect.PickupTime <= CloseTime Then
                            'ถ้าช่วงมารับของอยู่ในช่วงเที่ยงคืน ถึงเวลาปิดทำการ ให้หักวันออก 1 วัน
                            DayQty -= 1
                        End If
                    Else
                        CloseTime = New DateTime(Collect.PickupTime.Year, Collect.PickupTime.Month, Collect.PickupTime.Day, KioskConfig.KioskCloseTime.Split(":")(0), KioskConfig.KioskCloseTime.Split(":")(1), 0)
                    End If

                    ServiceRateData.ServiceRateOvernightList.DefaultView.RowFilter = "ms_cabinet_model_id='" & Collect.CabinetModelID & "'"
                    If ServiceRateData.ServiceRateOvernightList.DefaultView.Count > 0 Then
                        ret = ret + (Convert.ToInt16(ServiceRateData.ServiceRateOvernightList.DefaultView(0)("service_rate")) * DayQty)
                    End If
                    ServiceRateData.ServiceRateOvernightList.DefaultView.RowFilter = ""
                End If
            Else

                'กรณีเป็นการเปิดทำการ 24 ชั่วโมง
                Dim ServiceSec As Integer = DateDiff(DateInterval.Second, Collect.DepositPaidTime, Collect.PickupTime)
                Dim ServiceHour As Integer = Math.Ceiling(ServiceSec / 60 / 60) 'จำนวนชั่วโมงในวันที่มาฝาก ปัดเศษขึ้นเสมอ

                If ServiceHour <= 24 Then
                    'กรณีไม่ครบ 1 วัน
                    ret = CalServiceAmountDay1(ServiceHour, Collect.DepositPaidTime)
                Else
                    'ถ้าเกิน 1 วัน 
                    ret = CalServiceAmountDay1(24, Collect.DepositPaidTime)    'สำหรับวันแรก

                    'สำหรับวันถัดไป ให้นับจำนวนวันได้เลย
                    Dim ServiceDay As Integer = Math.Ceiling(ServiceSec / 60 / 60 / 24) - 1  'หักวันแรกออก

                    ServiceRateData.ServiceRateOvernightList.DefaultView.RowFilter = "ms_cabinet_model_id='" & Collect.CabinetModelID & "'"
                    If ServiceRateData.ServiceRateOvernightList.DefaultView.Count > 0 Then
                        ret = ret + (Convert.ToInt16(ServiceRateData.ServiceRateOvernightList.DefaultView(0)("service_rate")) * ServiceDay)
                    End If
                    ServiceRateData.ServiceRateOvernightList.DefaultView.RowFilter = ""
                End If
            End If
        Catch ex As Exception
            InsertLogTransactionActivity(Collect.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupScanQRCode_CalServiceAmount, "Exception PickupCalServiceAmount " & ex.Message & " " & ex.StackTrace, True)
        End Try
        Return ret
    End Function


    Private Function CalServiceAmountDay1(ServiceHour As Integer, DepositPaidTime As DateTime) As Integer
        'function สำหรับคำนวณค่าบริการรายชั่วโมงสำหรับการฝากในวันแรก
        Dim ret As Integer = 0
        Try
            Dim vDepositDate As String = DepositPaidTime.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim sql As String = "select ph.promotion_hour, ph.service_rate "
            sql += " from MS_KIOSK_PROMOTION p "
            sql += " inner join MS_KIOSK_PROMOTION_HOUR ph on p.id=ph.ms_kiosk_promotion_id "
            sql += " where '" & vDepositDate & "' between convert(varchar(8),p.start_date,112) And convert(varchar(8),p.end_date,112) "
            sql += " and ph.ms_cabinet_model_id = @_CABINET_MODEL_ID"
            sql += " and ph.promotion_hour <= @_PROMOTION_HOUR"

            Dim p(2) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_CABINET_MODEL_ID", Collect.CabinetModelID)
            p(1) = KioskDB.SetInt("@_PROMOTION_HOUR", ServiceHour)

            Dim dt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dt.Rows.Count > 0 Then
                'ถ้าอยู่ในช่วง Promotion
                For Each dr As DataRow In dt.Rows
                    ret += Convert.ToInt16(dr("service_rate"))
                Next
            Else
                'ถ้าไม่มี Promotion ให้คิดค่าบริการตามช่วงเวลาตามปรกติ
                ServiceRateData.ServiceRateHourList.DefaultView.RowFilter = "ms_cabinet_model_id='" & Collect.CabinetModelID & "' and service_hour<='" & ServiceHour & "'"
                If ServiceRateData.ServiceRateHourList.DefaultView.Count > 0 Then
                    For Each dr As DataRowView In ServiceRateData.ServiceRateHourList.DefaultView
                        ret += Convert.ToInt16(dr("service_rate"))
                    Next
                End If
                ServiceRateData.ServiceRateHourList.DefaultView.RowFilter = ""
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = 0
            InsertLogTransactionActivity("", Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.PickupScanQRCode_CalServiceAmount, "Exception CalServiceAmountDay1 " & ex.Message & " " & ex.StackTrace, True)
        End Try
        Return ret
    End Function


    Public Sub SetLEDStatus()
        'Update LED Status
        SetLockerList()

        If LockerList.Rows.Count > 0 Then
            If BoardLED.ConnectLEDDevice(KioskConfig.LEDComport) = True Then
                UpdateDeviceStatus(DeviceID.LEDBoard, BoardStatus.Ready)
                SendKioskAlarm("BOARD_LED_DISCONNECTED", False)

                For Each dr As DataRow In LockerList.Rows
                    If Convert.ToInt16(dr("pin_led")) > 0 Then
                        Thread.Sleep(500)
                        If dr("current_available") = "Y" Then
                            BoardLED.LEDStart(dr("pin_led"))
                        Else
                            BoardLED.LEDStop(dr("pin_led"))
                        End If
                    End If
                Next

                InsertLogTransactionActivity("", "", "", KioskConfigData.KioskLockerForm.Main, KioskConfigData.KioskLockerStep.Main_SetLEDStatus, "", False)
            Else
                UpdateDeviceStatus(DeviceID.LEDBoard, BoardStatus.Disconnected)
                SendKioskAlarm("BOARD_LED_DISCONNECTED", True)
                InsertErrorLog("ไม่สามารถเชื่อมต่อกับแผงควบคุม LED", "", "", "", KioskConfigData.KioskLockerForm.Main, KioskConfigData.KioskLockerStep.Main_SetLEDStatus)
            End If
        End If
    End Sub

    Public Function CheckOpenCloseTime() As Boolean
        Dim ret As Boolean = False  'CloseTime
        Dim vNow As DateTime = DateTime.Now

        Dim OpenHour As Integer = Split(KioskConfig.KioskOpenTime, ":")(0)
        Dim OpenMin As Integer = Split(KioskConfig.KioskOpenTime, ":")(1)

        Dim CloseHour As Integer = Split(KioskConfig.KioskCloseTime, ":")(0)
        Dim CloseMin As Integer = Split(KioskConfig.KioskCloseTime, ":")(1)

        Dim vOpenTime As New DateTime(1, 1, 1, OpenHour, OpenMin, 0)
        Dim vCloseTime As New DateTime(1, 1, 1, CloseHour, CloseMin, 0)
        If OpenHour > CloseHour Then
            'กรณีกำหนดเวลาเปิดปิดข้ามวัน
            vCloseTime = vCloseTime.AddDays(1)
        End If

        Dim vCurrTime As DateTime = vOpenTime
        Do
            If vCurrTime.ToString("HH:mm") = vNow.ToString("HH:mm") Then
                ret = True  'OpenTime
                Exit Do
            End If

            vCurrTime = vCurrTime.AddMinutes(1)
        Loop While vCurrTime <= vCloseTime

        Return ret
    End Function
End Module
