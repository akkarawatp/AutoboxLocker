Imports System.Data.SqlClient
Imports AutoboxLocker.Data
Imports System.Management
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE

Public Class frmMain

    Dim DT_ADS As New DataTable
    Dim Ads_Rec As Int32
    Dim Ads_Interval As Integer

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WebCam.Dispose()
        Application.Exit()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Application.CommandLineArgs.Count > 0 Then
            'ถ้าเปิดโปรแกรมมาจากตอนเริ่ม Boot เครื่อง ให้รอก่อน 3 นาที
            Threading.Thread.Sleep(3 * 1000 * 60)
        End If

    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Cursor.Hide()
        CheckForIllegalCrossThreadCalls = False

        'Check DB Connect at Startup
        Dim CurTime As DateTime = DateTime.Now
        Dim IsConnect As Boolean = False
        Do
            IsConnect = KioskDB.ChkConnection()
            If IsConnect = False Then
                If CurTime.AddMinutes(10) < DateTime.Now Then
                    'ถ้ารอนานเกิน 10 นาที
                    ShowFormError("Out of service", "Cannot Connect Kiosk Database", KioskConfig.SelectForm, Data.KioskConfigData.KioskLockerStep.Main_GetKioskSystemData, True)
                    Exit Sub
                End If
            End If
        Loop Until IsConnect = True

        tmKioskHeartbeat_Tick(Nothing, Nothing)
        StartupHeartbeat()

        GetKioskSystemData()
        If KioskData.KioskID = "" Then
            ShowFormError("Out of service", "Invalid Kiosk Informaiton", KioskConfig.SelectForm, Data.KioskConfigData.KioskLockerStep.Main_GetKioskSystemData, True)
            Exit Sub
        End If

        GetKioskConfig()
        SetAppScreenList()
        SetAlarmMasterList()
        ServiceRateData.SetServiceRateData(KioskData.KioskID)

        'จะต้องรู้ KioskID ก่อนถึงจะสามารถระบุ Form ได้
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.Main

        DeviceInfoList = New DataTable
        SetListDeviceInfo()
        If DeviceInfoList.Rows.Count > 0 Then
            GetKioskDeviceConfig()   'ข้อมูลการตั้งค่า Comport ของ HW
            InitCabinetInfo()

#If DEBUG = False Then
            StartInitialDevice()
#End If
            SetLEDStatus()

            Application.DoEvents()
            Dim fHome As New frmHome
            fHome.MdiParent = Me
            fHome.Show()

            CheckKioskScreenSaver()
            'GetAdsInfo()
        Else
            InsertErrorLog("Cannot Load Device Infomation List", 0, 0, 0, KioskConfig.SelectForm, 0)
            ShowFormError("Out of service", "Load Device Fail", KioskConfig.SelectForm, 0, True)
        End If
    End Sub


#Region "Start Device"
    Private Sub StartInitialDevice()
        StartMoneyDevice()
        StartBoardDevice()
    End Sub

    Private Sub StartBoardDevice()

        If DeviceInfoList.Rows.Count > 0 Then
            For i As Integer = 0 To DeviceInfoList.Rows.Count - 1
                If Convert.IsDBNull(DeviceInfoList.Rows(i)("comport_vid")) = True Then
                    Continue For
                End If

                Dim Comport As String = DeviceInfoList.Rows(i)("comport_vid").ToString
                Select Case DeviceInfoList.Rows(i).Item("device_id")
                    Case Data.ConstantsData.DeviceID.SolenoidBoard
                        If BoardSolenoid.ConnectSolenoidDevice(Comport) = True Then
                            UpdateDeviceStatus(Data.ConstantsData.DeviceID.SolenoidBoard, Data.ConstantsData.BoardStatus.Ready)
                            SendKioskAlarm("BOARD_SOLENOID_DISCONNECTED", False)
                        Else
                            UpdateDeviceStatus(Data.ConstantsData.DeviceID.SolenoidBoard, Data.ConstantsData.BoardStatus.Disconnected)
                            SendKioskAlarm("BOARD_SOLENOID_DISCONNECTED", True)
                        End If
                    Case Data.ConstantsData.DeviceID.LEDBoard
                        If BoardLED.ConnectLEDDevice(Comport) = True Then
                            UpdateDeviceStatus(Data.ConstantsData.DeviceID.LEDBoard, Data.ConstantsData.BoardStatus.Ready)
                            SendKioskAlarm("BOARD_LED_DISCONNECTED", False)
                        Else
                            UpdateDeviceStatus(Data.ConstantsData.DeviceID.LEDBoard, Data.ConstantsData.BoardStatus.Disconnected)
                            SendKioskAlarm("BOARD_LED_DISCONNECTED", True)
                        End If
                    Case Data.ConstantsData.DeviceID.SensorBoard
                        If BoardSensor.ConnectSensorDevice(Comport) = True Then
                            UpdateDeviceStatus(Data.ConstantsData.DeviceID.SensorBoard, Data.ConstantsData.BoardStatus.Ready)
                            SendKioskAlarm("BOARD_SENSOR_DISCONNECTED", False)
                        Else
                            UpdateDeviceStatus(Data.ConstantsData.DeviceID.SensorBoard, Data.ConstantsData.BoardStatus.Disconnected)
                            SendKioskAlarm("BOARD_SENSOR_DISCONNECTED", True)
                        End If
                End Select
            Next

            InsertLogTransactionActivity("", "", "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_StartBoardDevice, "", False)
        End If
    End Sub


    Private Sub StartMoneyDevice()
        Try
            If DeviceInfoList.Rows.Count > 0 Then
                For i As Int32 = 0 To DeviceInfoList.Rows.Count - 1
                    If Convert.IsDBNull(DeviceInfoList.Rows(i)("comport_vid")) = True Then
                        Continue For
                    End If

                    Dim Comport As String = DeviceInfoList.Rows(i)("comport_vid").ToString
                    Select Case DeviceInfoList.Rows(i).Item("device_id")
                        Case Data.ConstantsData.DeviceID.CoinOut_1
                            If CoinOut_1.ConnectCoinOutDevice(Comport) = True Then
                                CoinOut_1.ResetDeviceCoinOut()
                                SendKioskAlarm("COIN_OUT_DISCONNECTED", False)
                            Else
                                SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
                            End If
                        Case Data.ConstantsData.DeviceID.CoinOut_2
                            If CoinOut_2.ConnectCoinOutDevice(Comport) = True Then
                                CoinOut_2.ResetDeviceCoinOut()
                                SendKioskAlarm("COIN_OUT_DISCONNECTED", False)
                            Else
                                SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
                            End If
                        Case Data.ConstantsData.DeviceID.CoinOut_5
                            If CoinOut_5.ConnectCoinOutDevice(Comport) = True Then
                                CoinOut_5.ResetDeviceCoinOut()
                                SendKioskAlarm("COIN_OUT_DISCONNECTED", False)
                            Else
                                SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
                            End If
                        Case Data.ConstantsData.DeviceID.CoinOut_10
                            If CoinOut_10.ConnectCoinOutDevice(Comport) = True Then
                                CoinOut_10.ResetDeviceCoinOut()
                                SendKioskAlarm("COIN_OUT_DISCONNECTED", False)
                            Else
                                SendKioskAlarm("COIN_OUT_DISCONNECTED", True)
                            End If
                        Case Data.ConstantsData.DeviceID.BankNoteOut_20
                            If BanknoteOut_20.ConnectBanknoteOutDevice(Comport) = True Then
                                BanknoteOut_20.RefreshDeviceCashOut()
                                SendKioskAlarm("CASH_OUT_DISCONNECTED", False)
                            Else
                                SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
                            End If
                        Case Data.ConstantsData.DeviceID.BankNoteOut_50
                            If BanknoteOut_50.ConnectBanknoteOutDevice(Comport) = True Then
                                BanknoteOut_50.RefreshDeviceCashOut()
                                SendKioskAlarm("CASH_OUT_DISCONNECTED", False)
                            Else
                                SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
                            End If
                        Case Data.ConstantsData.DeviceID.BankNoteOut_100
                            If BanknoteOut_100.ConnectBanknoteOutDevice(Comport) = True Then
                                BanknoteOut_100.RefreshDeviceCashOut()
                                SendKioskAlarm("CASH_OUT_DISCONNECTED", False)
                            Else
                                SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
                            End If
                        Case Data.ConstantsData.DeviceID.BankNoteOut_500
                            If BanknoteOut_500.ConnectBanknoteOutDevice(Comport) = True Then
                                BanknoteOut_500.RefreshDeviceCashOut()
                                SendKioskAlarm("CASH_OUT_DISCONNECTED", False)
                            Else
                                SendKioskAlarm("CASH_OUT_DISCONNECTED", True)
                            End If
                    End Select
                Next

                InsertLogTransactionActivity("", "", "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_StartMoneyDevice, "", False)
            End If
        Catch ex As Exception
            InsertLogTransactionActivity("", "", "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_StartMoneyDevice, ex.Message & vbNewLine & ex.StackTrace, True)
        End Try
    End Sub

    'Private Sub StartPassportDevice()

    '    Try
    '        Dim lnq As New MsKioskDeviceKioskLinqDB
    '        lnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(Data.ConstantsData.DeviceID.IDCardPassportScanner, KioskData.KioskID, Nothing)
    '        If lnq.ID > 0 Then
    '            If PassportScanner.StartPassportDevice(lnq.DRIVER_NAME2) = True Then
    '                'Driver Name2 คือเครื่องอ่าน Passport
    '                InsertLogTransactionActivity("", "", "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_StartPassportDevice, "", False)
    '                SendKioskAlarm("PASSPORT_SCANNER_DISCONNECTED", False)
    '            Else
    '                SendKioskAlarm("PASSPORT_SCANNER_DISCONNECTED", True)
    '            End If
    '        End If
    '        lnq = Nothing

    '    Catch ex As Exception
    '        InsertErrorLog("Exception " & ex.Message & ex.StackTrace, 0, 0, 0, KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_StartPassportDevice)
    '    End Try

    'End Sub
#End Region


    Private Sub InitCabinetInfo()
        SetCabinetModel()
        SetCabinetInformation()
        SetLockerList()
    End Sub

    'Private Sub GetAdsInfo()
    '    Try
    '        DT_ADS = New DataTable
    '        DT_ADS.Columns.Add("Ads_Image", GetType(Image))
    '        DT_ADS.Columns.Add("Ads_Sec", GetType(Int16))

    '        For Each f As String In Directory.GetFiles(Application.StartupPath & "\Ads", "*.png")
    '            Dim dr As DataRow = DT_ADS.NewRow
    '            dr("Ads_Image") = Image.FromFile(f)
    '            dr("Ads_Sec") = 5
    '            DT_ADS.Rows.Add(dr)
    '        Next

    '        If DT_ADS.Rows.Count = 1 Then
    '            TimerAds.Enabled = False
    '            Dim ImgAds As Image = DirectCast(DT_ADS.Rows(0).Item("Ads_Image"), Image)
    '            pnlAds.BackgroundImage = ImgAds
    '        ElseIf DT_ADS.Rows.Count > 1 Then
    '            TimerAds.Enabled = True
    '            Ads_Rec = 0
    '        Else
    '            TimerAds.Enabled = False
    '            Dim ImgAds As Bitmap = New Bitmap(Application.StartupPath & "/Ads_Nothing.png")
    '            pnlAds.BackgroundImage = ImgAds
    '            pnlAds.BackgroundImageLayout = ImageLayout.Stretch
    '        End If
    '    Catch ex As Exception
    '        InsertErrorLog(ex.Message & vbNewLine & ex.StackTrace, 0, 0, 0, KioskConfig.SelectForm, Data.KioskConfigData.KioskLockerStep.Main_LoadAppScreenList)
    '    End Try
    'End Sub

    Private Sub SetAppScreenList()
        AppScreenList = New DataTable
        AppStepList = New DataTable

        Dim lnq As New MsAppScreenKioskLinqDB
        AppScreenList = lnq.GetDataList("", "", Nothing, Nothing)

        Dim stLnq As New MsAppStepKioskLinqDB
        AppStepList = stLnq.GetDataList("", "", Nothing, Nothing)
        InsertLogTransactionActivity("", "", "", KioskConfigData.KioskLockerForm.Main, KioskConfigData.KioskLockerStep.Main_LoadAppScreenList, "", False)
    End Sub

    'Private Sub SetLangMasterList()
    '    LangMasterList = New DataTable
    '    Dim lnq As New MsKioskScreenControlKioskLinqDB
    '    LangMasterList = lnq.GetDataList("", "", Nothing, Nothing)
    'End Sub

    'Private Sub SetLangNotificationList()
    '    LangNotificationList = New DataTable
    '    Dim lnq As New MsKioskNotificationTextKioskLinqDB
    '    LangNotificationList = lnq.GetDataList("", "", Nothing, Nothing)
    'End Sub

    Private Sub SetAlarmMasterList()
        Try
            Dim sql As String = "select alarm_problem, alarm_code,eng_desc, sms_message"
            sql += " from MS_MASTER_MONITORING_ALARM "
            AlarmMasterList = KioskDB.ExecuteTable(sql)
            AlarmMasterList.TableName = "AlarmMasterList"
        Catch ex As Exception
            AlarmMasterList = New DataTable
        End Try
    End Sub




    Private Function GetCardLanDesc() As String
        Dim CardLanDesc As String = ""
        Dim ini As New AutoboxLocker.Org.Mentalis.Files.IniReader(INIFileName)
        ini.Section = "Setting"
        CardLanDesc = ini.ReadString("CardLanDesc").ToString
        ini = Nothing
        Return CardLanDesc
    End Function

    Private Sub GetKioskSystemData()
        'หาข้อมูลของเครื่อง PC ทำเฉพาะครั้งแรกที่เปิดโปรแกรมและเก็บค่านี้ไว้ตลอด
        Try
            KioskData.ComputerName = Environment.MachineName
            KioskData.CardLanDesc = GetCardLanDesc()
            Dim IsNetworkDevice As Boolean = False

            Try
                'Network Information
                Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
                Dim moc As ManagementObjectCollection = mc.GetInstances()

                For Each mo As ManagementObject In moc
                    If CStr(mo("Description")).Trim = KioskData.CardLanDesc Then
                        If mo("IPEnabled") = True Then
                            KioskData.IpAddress = mo("IPAddress")(0)
                            KioskData.MacAddress = mo("MacAddress").ToString().Replace(":", "-")
                            IsNetworkDevice = True
                            Exit For
                        Else
                            InsertErrorLog("Cannot found Network Device " + KioskData.CardLanDesc, 0, 0, 0, KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_GetKioskSystemData)
                        End If
                    End If
                    mo.Dispose()
                Next
            Catch ex As Exception
                InsertErrorLog("Exception 1: " & ex.Message & vbNewLine & ex.StackTrace, 0, 0, 0, KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_GetKioskSystemData)
            End Try

            'หา Kiosk Configuration 
            Dim sql As String = "select top 1 id, ms_kiosk_id, location_code,location_name, mac_address,ip_address "
            sql += " from CF_KIOSK_SYSCONFIG"

            Dim dt As DataTable = KioskDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)

                'กำหนดค่าให้สำหรับตัวแปรที่จะต้องใช้ในโปรแกรม
                KioskData.KioskID = dr("ms_kiosk_id")  '############ KioskID  ##################
                'KioskData.LocationCode = dr("location_code")
                'KioskData.LocationName = dr("location_name")

                If IsNetworkDevice = False Then
                    KioskData.IpAddress = dr("ip_address")
                    KioskData.MacAddress = dr("mac_address")
                Else
                    'Update KIOSK SYSCONFIG
                    sql = " update CF_KIOSK_SYSCONFIG "
                    sql += " set mac_address=@_MAC_ADDRESS "
                    sql += " , ip_address=@_IP_ADDRESS "
                    sql += " , sync_to_server='N'"
                    sql += " where id=@_ID"

                    Dim p(3) As SqlParameter
                    p(0) = KioskDB.SetText("@_MAC_ADDRESS", KioskData.MacAddress)
                    p(1) = KioskDB.SetText("@_IP_ADDRESS", KioskData.IpAddress) '
                    p(2) = KioskDB.SetBigInt("@_ID", Convert.ToInt64(dr("id")))

                    Dim trans As New KioskTransactionDB
                    Dim re As ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, trans.Trans, p)
                    If re.IsSuccess = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        InsertErrorLog(re.ErrorMessage, 0, 0, 0, KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_GetKioskSystemData)
                    End If
                End If

                'Update ชื่อของอุปกรณ์ Network
                Dim kdLnq As New MsKioskDeviceKioskLinqDB
                kdLnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(Data.ConstantsData.DeviceID.NetworkConnection, KioskData.KioskID, Nothing)

                If kdLnq.ID > 0 Then
                    kdLnq.DRIVER_NAME1 = KioskData.CardLanDesc
                    Dim trans As New KioskTransactionDB
                    Dim koRe As ExecuteDataInfo = kdLnq.UpdateData(KioskData.ComputerName, trans.Trans)
                    If koRe.IsSuccess = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        InsertErrorLog(koRe.ErrorMessage, 0, 0, 0, KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_GetKioskSystemData)
                    End If
                    'Else
                    '    InsertErrorLog("Cannot found Kiosk Network Connection :" & kdLnq.ErrorMessage, 0, 0, 0, KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_GetKioskSystemData)
                    '    ShowFormError("Attention", "Cannot found Kiosk  Network Connection", KioskConfig.SelectForm, 0, True)
                    '    Exit Sub
                End If
                kdLnq = Nothing
            End If
            dt.Dispose()

            InsertLogTransactionActivity("", "", "", KioskConfigData.KioskLockerForm.Main, KioskConfigData.KioskLockerStep.Main_GetKioskSystemData, "ตรวจสอบข้อมูล Kiosk System", False)
        Catch ex As Exception
            InsertErrorLog("Exception 2: " & ex.Message & vbNewLine & ex.StackTrace, 0, 0, 0, KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_GetKioskSystemData)
        End Try
    End Sub

    'Private Sub TimerAds_Tick(sender As Object, e As EventArgs) Handles TimerAds.Tick
    '    Dim ImgAds As Image = DirectCast(DT_ADS.Rows(Ads_Rec).Item("Ads_Image"), Image)
    '    Ads_Interval = CInt(DT_ADS.Rows(Ads_Rec).Item("Ads_Sec")) * 1000
    '    pnlAds.BackgroundImage = ImgAds
    '    TimerAds.Interval = Ads_Interval

    '    If Ads_Rec >= DT_ADS.Rows.Count - 1 Then
    '        Ads_Rec = 0
    '    Else
    '        Ads_Rec += 1
    '    End If
    'End Sub

    Sub CloseAllChildForm()
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me Then
                My.Application.OpenForms.Item(i).Close()
            End If
        Next i
    End Sub

    Sub CloseAllChildForm(ShowFrm As Form)
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me Then
                If My.Application.OpenForms.Item(i) IsNot ShowFrm Then
                    My.Application.OpenForms.Item(i).Close()
                End If
            End If
        Next i
    End Sub

    '#Region "Change Language"
    '    Private Sub btnJP_Click(sender As Object, e As EventArgs) Handles btnJP.Click
    '        InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_ChangeLangJP, "", False)
    '        KioskConfig.Language = Data.ConstantsData.KioskLanguage.Japan
    '        ChangeFormMainLanguage()
    '        SetChildFormLanguage()

    '        Dim frm As Form = Me.ActiveMdiChild
    '        If frm.Name = "frmHome" Then
    '            DirectCast(frm, frmHome).SetLabelNotificationText()
    '        ElseIf frm.Name = "frmCollectSelectDocument" Then
    '            DirectCast(frm, frmCollectSelectDocument).SetLabelNotificationText()
    '        End If
    '    End Sub

    '    Private Sub btnEN_Click(sender As Object, e As EventArgs) Handles btnEN.Click
    '        InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_ChangeLangEN, "", False)
    '        KioskConfig.Language = Data.ConstantsData.KioskLanguage.English
    '        ChangeFormMainLanguage()
    '        SetChildFormLanguage()

    '        Dim frm As Form = Me.ActiveMdiChild
    '        If frm.Name = "frmHome" Then
    '            DirectCast(frm, frmHome).SetLabelNotificationText()
    '        ElseIf frm.Name = "frmCollectSelectDocument" Then
    '            DirectCast(frm, frmCollectSelectDocument).SetLabelNotificationText()
    '        End If

    '    End Sub

    '    Private Sub btnCH_Click(sender As Object, e As EventArgs) Handles btnCH.Click
    '        InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_ChangeLangCH, "", False)
    '        KioskConfig.Language = Data.ConstantsData.KioskLanguage.China
    '        ChangeFormMainLanguage()
    '        SetChildFormLanguage()

    '        Dim frm As Form = Me.ActiveMdiChild
    '        If frm.Name = "frmHome" Then
    '            DirectCast(frm, frmHome).SetLabelNotificationText()
    '        ElseIf frm.Name = "frmCollectSelectDocument" Then
    '            DirectCast(frm, frmCollectSelectDocument).SetLabelNotificationText()
    '        End If
    '    End Sub

    '    Private Sub btnTH_Click(sender As Object, e As EventArgs) Handles btnTH.Click
    '        InsertLogTransactionActivity(Customer.DepositTransNo, Collect.TransactionNo, "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_ChangeLangTH, "", False)
    '        KioskConfig.Language = Data.ConstantsData.KioskLanguage.Thai
    '        ChangeFormMainLanguage()
    '        SetChildFormLanguage()

    '        Dim frm As Form = Me.ActiveMdiChild
    '        If frm.Name = "frmHome" Then
    '            DirectCast(frm, frmHome).SetLabelNotificationText()
    '        ElseIf frm.Name = "frmCollectSelectDocument" Then
    '            DirectCast(frm, frmCollectSelectDocument).SetLabelNotificationText()
    '        End If
    '    End Sub

    '    Public Sub ChangeFormMainLanguage()
    '        Dim fldName As String = ""
    '        Select Case KioskConfig.Language
    '            Case Data.ConstantsData.KioskLanguage.Thai
    '                fldName = "TH_Display"
    '            Case Data.ConstantsData.KioskLanguage.English
    '                fldName = "EN_Display"
    '            Case Data.ConstantsData.KioskLanguage.China
    '                fldName = "CH_Display"
    '            Case Data.KioskLanguage.Japan
    '                fldName = "JP_Display"
    '        End Select

    '        LangMasterList.DefaultView.RowFilter = "ms_app_screen_id='" & Convert.ToInt16(Data.KioskConfigData.KioskLockerForm.Main) & "'"
    '        If LangMasterList.DefaultView.Count > 0 Then
    '            For Each dr As DataRowView In LangMasterList.DefaultView
    '                Dim ControlName As String = dr("Control_Name")
    '                Dim cc() As Control = Me.Controls.Find(ControlName, True)
    '                If cc.Length > 0 Then
    '                    cc(0).Text = dr(fldName)

    '                    Dim FontSize As Int16 = dr("font_size")
    '                    Dim FontStyle As FontStyle = Convert.ToInt16(dr("font_style"))
    '                    cc(0).Font = New Font("Thai Sans Lite", FontSize, FontStyle)

    '                    If KioskConfig.Language = Data.ConstantsData.KioskLanguage.China Then
    '                        FontSize = FontSize * 0.7
    '                        cc(0).Font = New Font("Hiragino GB W3", FontSize, FontStyle)

    '                        'cc(0).Font = New Font("Songti SC Black", FontSize, FontStyle)
    '                    ElseIf KioskConfig.Language = Data.ConstantsData.KioskLanguage.Japan Then
    '                        FontSize = FontSize * 0.7

    '                        cc(0).Font = New Font("MS Gothic", FontSize, FontStyle)
    '                        'cc(0).Font = New Font("ＭＳ Ｐゴシック", FontSize, FontStyle)
    '                    End If
    '                End If
    '            Next
    '        End If
    '        LangMasterList.DefaultView.RowFilter = ""
    '        Application.DoEvents()
    '    End Sub


    '#End Region

#Region "Download Screen Saver"
    Private Sub CheckKioskScreenSaver()
        Try
            'Dim ws As New ServerDataProvider.ServerDataProvider
            'ws.Url = My.Settings.AIS_Kiosk_ServerDataProvider_ServerDataProvider
            'ws.Timeout = 120000
            'Dim dt As DataTable = ws.CheckNewScreenSaver(Kiosk.KioskID)  'ตรวจสอบว่ามีไฟล์ VDO มาใหม่
            'If dt.Rows.Count > 0 Then
            '    For Each dr As DataRow In dt.Rows
            '        Dim TbKioskScreenSaverID As Long = Convert.ToInt64(dr("id"))

            '        Dim ini As New IniReader(INIFileName)
            '        ini.Section = "Setting"

            '        Dim PathNAS As String = ini.ReadString("PathNAS").ToString()
            '        If PathNAS = "" Then
            '            PathNAS = "D:\TempScreenSaverPath\"
            '        End If
            '        ini = Nothing

            '        Dim FileInNAS = PathNAS & TbKioskScreenSaverID & ".avi"

            '        If File.Exists(FileInNAS) = True Then

            '            'ทำการลบไฟล์เก่า (VDO.avi) แล้วแทนที่ด้วยไฟล์ใหม่
            '            Dim VdoFile As String = Application.StartupPath & "\VDO.avi"
            '            If File.Exists(VdoFile) = True Then
            '                Try
            '                    File.SetAttributes(VdoFile, FileAttributes.Normal)
            '                    File.Delete(VdoFile)
            '                Catch ex As Exception

            '                End Try
            '            End If

            '            File.Move(FileInNAS, VdoFile)

            '            ws.Update_VDO_Content_Status(TbKioskScreenSaverID) 'อัพเดท Status เมื่อ Download เสร็จ
            '        End If
            '    Next
            'End If
            'dt.Dispose()
            'ws.Dispose()
        Catch ex As Exception

        End Try
    End Sub


#End Region


    Private Sub TimerSetPointer_Tick(sender As Object, e As EventArgs) Handles TimerSetPointer.Tick
        btnPointer.Parent = Me
        btnPointer.Text = "1"
        'btnPointer.Left = 0
        'btnPointer.Top = 0

        'Move to buttom left
        btnPointer.Location = New Point(0, Me.Height - btnPointer.Height)
        btnPointer.BringToFront()
        Application.DoEvents()

        TimerSetPointer.Enabled = False
    End Sub

    Private Sub btnPointer_Click(sender As Object, e As EventArgs) Handles btnPointer.Click
        TimerSetPointer.Stop()
        btnPointer.Parent = Me
        If btnPointer.Text = "1" Then
            btnPointer.Text = "2"

            'Move to buttom right
            btnPointer.Location = New Point(Me.Width - btnPointer.Width, Me.Height - btnPointer.Height)
            btnPointer.BringToFront()
        ElseIf btnPointer.Text = "2" Then
            btnPointer.Text = "3"

            'Move to top right
            btnPointer.Location = New Point(Me.Width - btnPointer.Width, 0)
            btnPointer.BringToFront()
        ElseIf btnPointer.Text = "3" Then
            btnPointer.Text = "4"

            'Move to buttom right
            btnPointer.Location = New Point(Me.Width - btnPointer.Width, Me.Height - btnPointer.Height)
            btnPointer.BringToFront()
        ElseIf btnPointer.Text = "4" Then
            InsertLogTransactionActivity("", "", "", KioskConfig.KioskLockerForm.Main, KioskConfig.KioskLockerStep.Main_OpenFormLoginStaffConsole, "", False)

            'TimerOpenClose.Stop()
            TimerCheckOpenClose.Enabled = False

            TimerSetPointer.Enabled = True
            Dim frm As New frmSC_LogIn
            frm.ShowDialog(Me)
        End If
        TimerSetPointer.Enabled = True
        TimerSetPointer.Start()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, pnlCancel.Click
        InsertLogTransactionActivity(Deposit.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfig.KioskLockerStep.Main_Cancel, "", False)
        If ServiceID = Data.ConstantsData.TransactionType.DepositBelonging Then
            'กรณีฝาก
            If KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.DepositSelectLocker Then
                'เมื่อกดปุ่มยกเลิกในหน้าจอเลือกช่องฝาก
                Deposit.TransStatus = DepositTransactionData.TransactionStatus.Inprogress
            ElseIf KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.DepositSetPinCode Then
                'เมื่อกดปุ่มยกเลิกในหน้าจอกำหนดรหัสส่วนตัว
                Deposit.TransStatus = DepositTransactionData.TransactionStatus.Inprogress
            Else
                Deposit.TransStatus = DepositTransactionData.TransactionStatus.Cancel
            End If

            Dim ret As ExecuteDataInfo = UpdateDepositStatus(Deposit.DepositTransactionID, Deposit.TransStatus, KioskConfig.KioskLockerStep.Main_Cancel)
            If ret.IsSuccess = True Then
                If KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.DepositPayment Then
                    If Deposit.PaidAmount > 0 Then
                        InsertLogTransactionActivity(Deposit.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfig.KioskLockerStep.DepositPayment_ReturnMoney, Deposit.PaidAmount & " บาท", False)
                        ReturnMoney(Deposit.PaidAmount, Deposit, Collect)
                    End If
                End If
            Else
                ShowFormError("Attention", "Out of service", KioskConfig.SelectForm, True)
                InsertErrorLog(ret.ErrorMessage, Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskConfig.KioskLockerStep.Main_Cancel)
            End If
            ret = Nothing
        ElseIf ServiceID = Data.ConstantsData.TransactionType.CollectBelonging Then
            'กรณีรับคืน
            If KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.CollectSelectDocument Then
                'เมื่อกดปุ่มยกเลิกในหน้าจอเลือกเอกสาร
                Collect.TransStatus = CollectTransactionData.TransactionStatus.Inprogress
            ElseIf KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.CollectScanQRCode Then
                'เมื่อกดปุ่มยกเลิกในหน้าจอสแกน QR Code
                Collect.TransStatus = CollectTransactionData.TransactionStatus.Inprogress
            ElseIf KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.CollectByPincode Then
                'เมื่อกดปุ่มยกเลิกในหน้าจอใส่รหัสส่วนตัว
                Collect.TransStatus = CollectTransactionData.TransactionStatus.Inprogress
            Else
                Collect.TransStatus = CollectTransactionData.TransactionStatus.Cancel
            End If

            Dim ret As ExecuteDataInfo = UpdateCollectStatus(Collect.CollectTransactionID, Collect.TransStatus, KioskConfig.KioskLockerStep.Main_Cancel)
            If ret.IsSuccess = True Then
                If KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.CollectPayment Then
                    If Collect.PaidAmount > 0 Then
                        InsertLogTransactionActivity(Deposit.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfig.KioskLockerStep.PickupPayment_ReturnMoney, Collect.PaidAmount & " บาท", False)
                        ReturnMoney(Collect.PaidAmount, Deposit, Collect)
                    End If
                End If
            Else
                ShowFormError("Attention", "Out of service", KioskConfig.SelectForm, True)
                InsertErrorLog(ret.ErrorMessage, "", Collect.DepositTransNo, "", KioskConfig.SelectForm, KioskConfig.KioskLockerStep.Main_Cancel)
            End If
        End If

        Try
            CloseAllChildForm()

            'ไม่ว่าจะยกเลิกที่หน้าจอไหน ก็แค่ Update Transaction เป็น Cancel แล้วก็กลับหน้าแรก
            InsertLogTransactionActivity(Deposit.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfig.KioskLockerStep.Main_BackToHome, "", False)
            Dim f As New frmHome
            f.MdiParent = Me
            f.Show()

            Application.DoEvents()
        Catch ex As Exception
            InsertLogTransactionActivity(Deposit.DepositTransNo, Collect.TransactionNo, "", KioskConfig.SelectForm, KioskConfig.KioskLockerStep.Main_Cancel, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, False)
        End Try

    End Sub

    Dim IsCloseTime As Boolean = False
    Private Sub TimerCheckOpenClose_Tick(sender As Object, e As EventArgs) Handles TimerCheckOpenClose.Tick
        If KioskConfig.KioskOpen24Hours = True Then Exit Sub

        TimerCheckOpenClose.Enabled = False
        If KioskConfig.SelectForm <> KioskConfigData.KioskLockerForm.OutOfService Then
            If CheckOpenCloseTime() = False Then
                'Close Time
                If IsCloseTime = False Then
                    IsCloseTime = True

                    InsertLogTransactionActivity("", "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_KioskTimeClose, "", False)
                    CloseAllChildForm()
                    Dim f_err As New frmLockerError
                    f_err.MdiParent = Me
                    f_err.Show()
                    btnPointer.Visible = True
                End If
            Else
                If IsCloseTime = True Then
                    IsCloseTime = False
                    InsertLogTransactionActivity("", "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_KioskTimeOpen, "", False)
                    CloseAllChildForm()
                    Dim f As New frmHome
                    f.MdiParent = Me
                    f.Show()

                    CheckKioskScreenSaver()
                    'GetAdsInfo()
                End If
            End If
        End If

        TimerCheckOpenClose.Enabled = True
    End Sub

    Private Sub TimerCheckAutoSleep_Tick(sender As Object, e As EventArgs) Handles TimerCheckAutoSleep.Tick
        If KioskConfig.KioskOpen24Hours = True Then Exit Sub

        If DateTime.Now.ToString("HH:mm") = KioskConfig.SleepTime Then
            InsertLogTransactionActivity("", "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_KioskTimeSleep, "", False)

            Dim wup As New AutoWakeUP
            AddHandler wup.Woken, AddressOf AutoWakeUP_Woken
            wup.SetWakeUpTime(DateTime.Now.AddMinutes(KioskConfig.SleepDuration))
            System.Threading.Thread.Sleep(1000)
            TimerCheckAutoSleep.Enabled = False

            Application.SetSuspendState(PowerState.Suspend, False, False)
        End If
    End Sub


    Private Sub AutoWakeUP_Woken(sender As Object, e As EventArgs)
        InsertLogTransactionActivity("", "", "", KioskConfig.SelectForm, KioskConfigData.KioskLockerStep.Main_KioskTimeWakeUp, "", False)
        Threading.Thread.Sleep(60000)

        Process.Start("shutdown", "-r -t 20")   'Restart ภายใน 20 วินาที
        'System.Diagnostics.Process.Start("shutdown", "-s -t 20")   'Shutdown ภายใน 20 วินาที
        'System.Diagnostics.Process.Start("shutdown", "-l -t 20")   'Logoff ภายใน 20 วินาที
        'first we write function that will call the shutdown procedure System.Diagnostics.Process.Start()
        'Then we call the shutdown procedure: ("shutdown",
        'after we called it we will have to name the process we want to do:  
        'to make it shutdown we Write after the comma "-s"
        'And to make it restart we write after the comma "-r"
        'And to make it logoff we write after the comma "-l"
        TimerCheckAutoSleep.Enabled = True
    End Sub
End Class