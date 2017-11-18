
Namespace Data

    Public Class KioskConfigData
        Dim _KioskID As String = ""
        Dim _SelectForm As KioskLockerForm

        'Dim _Language As String = Data.ConstantsData.KioskLanguage.Thai
        Dim _LocationCode As String = ""
        Dim _LocationName As String = ""
        Dim _KioskOpenTime As String = ""
        Dim _KioskCloseTime As String = ""
        Dim _KioskOpen24Hours As Boolean = False
        Dim _IsLoginSSO As Boolean = False
        Dim _ScreenSaverSec As Integer = 0
        Dim _TimeOutSec As Integer = 0
        Dim _ShowMsgSec As Integer = 0
        Dim _PaymentExtendSec As Integer = 0
        Dim _PincodeLen As Integer = 0
        Dim _ContactCenterTelno As String = ""
        Dim _SleepTime As String = ""
        Dim _SleepDuration As Integer = 0

        Dim _WebserviceLockerURL As String = ""
        Dim _WebServiceAlarmURL As String = ""
        Dim _LockerPCPosition As Integer = 0

        Dim _SolenoidComport As String = ""
        Dim _SensorComport As String = ""
        Dim _LedComport As String = ""

        Dim _CashINComport As String = ""
        Dim _CashOUT20Comport As String = ""
        Dim _CashOUT50Comport As String = ""
        Dim _CashOUT100Comport As String = ""
        Dim _CashOUT500Comport As String = ""

        Dim _CoinINComport As String = ""
        Dim _CoinOut1Comport As String = ""
        Dim _CoinOut2Comport As String = ""
        Dim _CoinOut5Comport As String = ""
        Dim _CoinOut10Comport As String = ""

        Dim _WebCameraVID As String = ""
        Dim _WebCameraDeviceName As String = ""
        Dim _WebCameraIndex As Integer = -1

        Dim _QRCodeVID As String = ""
        Dim _PrinterDeviceName As String = ""

        Dim _SyncMasterInterval As Integer = 0
        Dim _SyncTransInterval As Integer = 0
        Dim _SyncLogInterval As Integer = 0



        'Dim _ShiftNo As Int32 = 0
        'Dim _ShiftDate As New DateTime(1, 1, 1)
        'Dim _ShiftOpenUser As String = ""

        Public Sub New(KioskID As String)
            _KioskID = KioskID
        End Sub

        Public Property SelectForm As KioskLockerForm
            Get
                Return _SelectForm
            End Get
            Set(value As KioskLockerForm)
                _SelectForm = value
            End Set
        End Property

        Public Property LocationCode As String
            Get
                Return _LocationCode.Trim
            End Get
            Set(value As String)
                _LocationCode = value
            End Set
        End Property

        Public Property LocationName As String
            Get
                Return _LocationName.Trim
            End Get
            Set(value As String)
                _LocationName = value
            End Set
        End Property

        'Public Property Language As String
        '    Get
        '        Return _Language.Trim
        '    End Get
        '    Set(value As String)
        '        _Language = value
        '    End Set
        'End Property

        Public Property KioskOpenTime As String
            Get
                Return _KioskOpenTime.Trim
            End Get
            Set(value As String)
                _KioskOpenTime = value
            End Set
        End Property
        Public Property KioskCloseTime As String
            Get
                Return _KioskCloseTime.Trim
            End Get
            Set(value As String)
                _KioskCloseTime = value
            End Set
        End Property
        Public Property KioskOpen24Hours As Boolean
            Get
                Return _KioskOpen24Hours
            End Get
            Set(value As Boolean)
                _KioskOpen24Hours = value
            End Set
        End Property
        Public Property IsLoginSSO As Boolean
            Get
                Return _IsLoginSSO
            End Get
            Set(value As Boolean)
                _IsLoginSSO = value
            End Set
        End Property
        Public Property ScreenSaverSec As Integer
            Get
                Return _ScreenSaverSec
            End Get
            Set(value As Integer)
                _ScreenSaverSec = value
            End Set
        End Property
        Public Property TimeOutSec As Integer
            Get
                Return _TimeOutSec
            End Get
            Set(value As Integer)
                _TimeOutSec = value
            End Set
        End Property
        Public Property ShowMsgSec As Integer
            Get
                Return _ShowMsgSec
            End Get
            Set(value As Integer)
                _ShowMsgSec = value
            End Set
        End Property
        Public Property PaymentExtendSec As Integer
            Get
                Return _PaymentExtendSec
            End Get
            Set(value As Integer)
                _PaymentExtendSec = value
            End Set
        End Property
        Public Property PincodeLen As Integer
            Get
                Return _PincodeLen
            End Get
            Set(value As Integer)
                _PincodeLen = value
            End Set
        End Property
        Public Property ContactCenterTelno As String
            Get
                Return _ContactCenterTelno.Trim
            End Get
            Set(value As String)
                _ContactCenterTelno = value
            End Set
        End Property
        Public Property SleepTime As String
            Get
                Return _SleepTime.Trim
            End Get
            Set(value As String)
                _SleepTime = value
            End Set
        End Property
        Public Property SleepDuration As Integer
            Get
                Return _SleepDuration
            End Get
            Set(value As Integer)
                _SleepDuration = value
            End Set
        End Property

        Public Property WebserviceLockerURL As String
            Get
                Return _WebserviceLockerURL.Trim
            End Get
            Set(value As String)
                _WebserviceLockerURL = value
            End Set
        End Property
        Public Property WebServiceAlarmURL As String
            Get
                Return _WebServiceAlarmURL.Trim
            End Get
            Set(value As String)
                _WebServiceAlarmURL = value
            End Set
        End Property
        Public Property LockerPCPosition As Integer
            Get
                Return _LockerPCPosition
            End Get
            Set(value As Integer)
                _LockerPCPosition = value
            End Set
        End Property
        Public Property SolenoidComport As String
            Get
                Return _SolenoidComport.Trim
            End Get
            Set(value As String)
                _SolenoidComport = value
            End Set
        End Property
        Public Property LEDComport As String
            Get
                Return _LedComport.Trim
            End Get
            Set(value As String)
                _LedComport = value
            End Set
        End Property
        Public Property SensorComport As String
            Get
                Return _SensorComport.Trim
            End Get
            Set(value As String)
                _SensorComport = value
            End Set
        End Property

        Public Property CoinInComport As String
            Get
                Return _CoinINComport.Trim
            End Get
            Set(value As String)
                _CoinINComport = value
            End Set
        End Property
        Public Property CoinOut1Comport As String
            Get
                Return _CoinOut1Comport.Trim
            End Get
            Set(value As String)
                _CoinOut1Comport = value
            End Set
        End Property
        Public Property CoinOut2Comport As String
            Get
                Return _CoinOut2Comport.Trim
            End Get
            Set(value As String)
                _CoinOut2Comport = value
            End Set
        End Property
        Public Property CoinOut5Comport As String
            Get
                Return _CoinOut5Comport.Trim
            End Get
            Set(value As String)
                _CoinOut5Comport = value
            End Set
        End Property
        Public Property CoinOut10Comport As String
            Get
                Return _CoinOut10Comport.Trim
            End Get
            Set(value As String)
                _CoinOut10Comport = value
            End Set
        End Property

        Public Property CashInComport As String
            Get
                Return _CashINComport.Trim
            End Get
            Set(value As String)
                _CashINComport = value
            End Set
        End Property
        Public Property CashOUT20Comport As String
            Get
                Return _CashOUT20Comport.Trim
            End Get
            Set(value As String)
                _CashOUT20Comport = value
            End Set
        End Property
        Public Property CashOUT50Comport As String
            Get
                Return _CashOUT50Comport.Trim
            End Get
            Set(value As String)
                _CashOUT50Comport = value
            End Set
        End Property
        Public Property CashOUT100Comport As String
            Get
                Return _CashOUT100Comport.Trim
            End Get
            Set(value As String)
                _CashOUT100Comport = value
            End Set
        End Property
        Public Property CashOUT500Comport As String
            Get
                Return _CashOUT500Comport.Trim
            End Get
            Set(value As String)
                _CashOUT500Comport = value
            End Set
        End Property

        Public Property WebCameraVID As String
            Get
                Return _WebCameraVID.Trim
            End Get
            Set(value As String)
                _WebCameraVID = value
            End Set
        End Property
        Public Property WebCameraDeviceName As String
            Get
                Return _WebCameraDeviceName.Trim
            End Get
            Set(value As String)
                _WebCameraDeviceName = value
            End Set
        End Property
        Public Property WebCameraIndex As Integer
            Get
                Return _WebCameraIndex
            End Get
            Set(value As Integer)
                _WebCameraIndex = value
            End Set
        End Property

        Public Property QRCodeVID As String
            Get
                Return _QRCodeVID.Trim
            End Get
            Set(value As String)
                _QRCodeVID = value
            End Set
        End Property
        Public Property PrinterDeviceName As String
            Get
                Return _PrinterDeviceName.Trim
            End Get
            Set(value As String)
                _PrinterDeviceName = value
            End Set
        End Property
        Public Property SyncMasterInterval As Integer
            Get
                Return _SyncMasterInterval
            End Get
            Set(value As Integer)
                _SyncMasterInterval = value
            End Set
        End Property
        Public Property SyncTransInterval As Integer
            Get
                Return _SyncTransInterval
            End Get
            Set(value As Integer)
                _SyncTransInterval = value
            End Set
        End Property
        Public Property SyncLogInterval As Integer
            Get
                Return _SyncLogInterval
            End Get
            Set(value As Integer)
                _SyncLogInterval = value
            End Set
        End Property

        Public Enum KioskLockerForm
            Main = 1
            Home = 2
            DepositSelectLocker = 3
            DepositSetPinCode = 4
            DepositPayment = 5
            DepositPrintQRCode = 6
            DepositThankYou = 7

            CollectSelectDocument = 23
            CollectScanQRCode = 8
            CollectConformOpenLocker = 9
            CollectScanPersonInfo = 10
            CollectPayment = 11
            CollectThankYou = 12

            LockerError = 13
            OutOfService = 14

            StaffConsoleLogin = 15
            StaffConsoleStoakAndHardware = 16
            StaffConsoleFillPaper = 17
            StaffConsoleFillMoney = 18
            StaffConsoleKioskSetting = 19
            StaffConsoleDeviceSetting = 20
            StaffConsoleLockerSetting = 21

            ScreenSaver = 22
        End Enum
		
		Public Enum KioskLockerStep
			Main_GetKioskSystemData = 101
			Main_GetDeviceInfo = 102
			Main_StartPassportDevice = 103
			Main_StartMoneyDevice= 104
			Main_StartBoardDevice=105
			Main_LoadLockerList = 106
			Main_LoadCabinetList = 107
			Main_LoadCabinetModelList = 108
			Main_LoadAppScreenList = 109
			Main_OpenFormLoginStaffConsole = 110
			Main_ChangeLangTH = 111
            Main_ChangeLangEN = 112
			Main_ChangeLangCH = 113
			Main_ChangeLangJP = 114
            Main_Cancel = 115
            Main_GetKioskConfig = 116
            Main_SetLEDStatus = 117
            Main_KioskTimeOpen = 118
            Main_KioskTimeClose = 119
            Main_BackToHome = 120
            Main_KioskTimeSleep = 121
            Main_KioskTimeWakeUp = 122

            Home_CheckHardwareStatus = 201
			Home_CheckStockQty = 202
			Home_LoadLockerList = 203
			Home_ClickDeposit = 204
			Home_ClickPickup = 205

            DepositSelectLocker_OpenForm = 301
            DepositSelectLocker_SelectLocker = 302
            DepositSelectLocker_LoadLockerList = 303

            DepositSetPinCode_OpenForm = 401
            DepositSetPinCode_ConfirmPinCodeSuccess = 402
            DepositSetPinCode_ConfirmPinCodeFail = 403
            DepositSetPinCode_ConnectWebcamSuccess = 404
            DepositSetPinCode_ConnectWebcamFail = 405
            DepositSetPinCode_CaptureImageSuccess = 406
            'DepositScanPersonInfo_CheckPassportExpire = 407
            'DepositScanPersonInfo_RemoveIdCard = 408
            'DepositScanPersonInfo_InsertIdCard = 409
            'DepositScanPersonInfo_InsertPassport = 410
            DepositSetPinCode_Timeout = 411

            DepositPayment_OpenForm = 501
            DepositPayment_CheckHardwareStatus = 502
            DepositPayment_CheckStockQty = 503
            DepositPayment_StartDeviceBanknoteIn = 504
            DepositPayment_StartDeviceCoinIn = 505
            DepositPayment_ReceiveBankNote = 506
            DepositPayment_ReceiveCoin = 507
            DepositPayment_PaidSuccess = 508
            DepositPayment_ShowExtend = 509  'แสดง Dialog Extend Timeout
            DepositPayment_OKExtend = 510
            DepositPayment_CancelExtend = 511
            DepositPayment_PaidTimeOut = 512
            DepositPayment_ReturnMoney = 513

            DepositPrintQRCode_OpenForm = 601
            DepositPrintQRCode_OpenLocker = 602
            DepositPrintQRCode_ChangeMoney = 603
            DepositPrintQRCode_LEDBlinkOn = 604
            DepositPrintQRCode_PrintSlip = 605
            DepositPrintQRCode_ReturnMoney = 606    'OpenLockerFail

            DepositThankYou_OpenForm = 701
            DepositThankYou_StartSensor = 702
            DepositThankYou_CloseLocker = 703
            DepositThankYou_LEDBlinkOff = 704
            DepositThankYou_BackToHome = 705

            PickupSelectDoc_OpenForm = 2301
            PickupSelectDoc_ClickQRCode = 2302
            PickupSelectDoc_ClickIDCard = 2303
            PickupSelectDoc_Timeout = 2304

            PickupScanQRCode_OpenForm = 801
            PickupScanQRCode_CheckDataQRCode = 802
            PickupScanQRCode_CalServiceAmount = 803
            'PickupScanQRCode_ClickQRCodeLost = 804
            PickupScanQRCode_Timeout = 805

            PickupPayment_OpenForm = 1101
            PickupPayment_CheckHardwareStatus = 1102
            PickupPayment_CheckStockQty = 1103
            PickupPayment_StartDeviceBanknoteIn = 1104
            PickupPayment_StartDeviceCoinIn = 1105
            PickupPayment_ReceiveBankNote = 1106
            PickupPayment_ReceiveCoin = 1107
            PickupPayment_PaidSuccess = 1108
            PickupPayment_ShowExtend = 1109  'แสดง Dialog Extend Timeout
            PickupPayment_OKExtend = 1110
            PickupPayment_CancelExtend = 1111
            PickupPayment_PaidTimeOut = 1112
            PickupPayment_ReturnMoney = 1113

            'New Requirement
            PickupPayment_ClickConfirmOpenLocker = 1114
            PickupPayment_OpenLocker = 1115
            PickupPayment_LEDBlinkOn = 1116
            PickupPayment_OpenLockerFailReturnMoney = 1117    'OpenLockerFail

            'PickupScanPersonInfo_OpenForm = 1001
            'PickupScanPersonInfo_CheckPassportDevice = 1002
            'PickupScanPersonInfo_CheckIDCardDevice = 1003
            'PickupScanPersonInfo_ScanIDCard = 1004
            'PickupScanPersonInfo_ScanPassport = 1005
            'PickupScanPersonInfo_CheckIDCardExpire = 1006
            'PickupScanPersonInfo_CheckPassportExpire = 1007
            'PickupScanPersonInfo_GetPickupWithScanIDCard = 1008
            'PickupScanPersonInfo_GetPickupWithScanPassport = 1009
            'PickupScanPersonInfo_HaveData = 1010
            'PickupScanPersonInfo_NoPersonData = 1011
            'PickupScanPersonInfo_GetPickupDataFail = 1012
            'PickupScanPersonInfo_RemoveIdCard = 1013
            'PickupScanPersonInfo_InsertIdCard = 1014
            'PickupScanPersonInfo_InsertPassport = 1015
            'PickupScanPersonInfo_Timeout = 1016

            PickupThankYou_OpenForm = 1201
            PickupThankYou_StartSensor = 1202
            PickupThankYou_CloseLocker = 1203
            PickupThankYou_LEDStart = 1204
            PickupThankYou_ChangeMoney = 1205
            PickupThankYou_BackToHome = 1206

            StaffConsoleLogin_OpenFOrm = 1501
			StaffConsoleLogin_ClickLogin = 1502
			StaffConsoleLogin_LoginValidate = 1503
			StaffConsoleLogin_GetAuthorize = 1504
			StaffConsoleLogin_CreateTransaction = 1505			
			StaffConsoleLogin_UpdateHardwareAndStock = 1506
			StaffConsoleLogin_ClickCancel = 1507

            StaffConsoleStockAndHardware_OpenForm = 1601
            StaffConsoleStockAndHardware_GetKioskConfig = 1602
            StaffConsoleStockAndHardware_SetStockAndHardwareStatus = 1603
            StaffConsoleStockAndHardware_CheckAuthorize = 1604
            StaffConsoleStockAndHardware_ClickClose = 1605
            StaffConsoleStockAndHardware_ClickFillPaper = 1606
            StaffConsoleStockAndHardware_ClickFillMoney = 1607
            StaffConsoleStockAndHardware_ClickKioskSetting = 1608
            StaffConsoleStockAndHardware_ClickDeviceSetting = 1609
            StaffConsoleStockAndHardware_ClickLockerSetting = 1610
            StaffConsoleStockAndHardware_ClickOpenAll = 1611
            StaffConsoleStockAndHardware_ClickExitProgram = 1612

            StaffConsoleFillPaper_OpenForm = 1701
			StaffConsoleFillPaper_CheckAuthorize = 1702
			StaffConsoleFillPaper_ClickConfirm = 1703
			StaffConsoleFillPaper_ClickCancel = 1704
			
			StaffConsoleFillMoney_OpenFOrm = 1801
			StaffConsoleFillMoney_CheckKioskMoney = 1802
			StaffConsoleFillMoney_InsertFillMoney = 1803
			StaffConsoleFillMoney_CheckAuthorize = 1804
			StaffConsoleFillMoney_ClickCheckOutMoney = 1805
			StaffConsoleFillMoney_ClickFillAllFull = 1806
			StaffConsoleFillMoney_ClickConfirm = 1807
			StaffConsoleFillMoney_ClickCancel = 1808
			
			StaffConsoleKioskSetting_OpenForm = 1901
            StaffConsoleKioskSetting_SetKioskSetting = 1902
            StaffConsoleKioskSetting_CheckAuthorize = 1903
			StaffConsoleKioskSetting_ClickSave = 1904
			StaffConsoleKioskSetting_ClickCancel = 1905
			
			StaffConsoleDeviceSetting_OpenForm = 2001
			StaffConsoleDeviceSetting_SetDefaultSetting = 2002
			StaffConsoleDeviceSetting_CheckAuthorize = 2003
			StaffConsoleDeviceSetting_ClickSave = 2004
			StaffConsoleDeviceSetting_ClickCancel = 2005
			
			StaffConsoleLockerSetting_OpenForm = 2101
			StaffConsoleLockerSetting_LoadCabinetInfo = 2102
			StaffConsoleLockerSetting_AdjustLayout = 2103
			StaffConsoleLockerSetting_CheckAuthorize = 2104
			StaffConsoleLockerSetting_ClickSave = 2105
			StaffConsoleLockerSetting_ClickClose = 2106
			StaffConsoleLockerSetting_CabinetAdd = 2107
			StaffConsoleLockerSetting_CabinetEdit = 2108
			StaffConsoleLockerSetting_CabinetDelete = 2109
			StaffConsoleLockerSetting_LockerDbClick = 2110
			
        End Enum
    End Class
End Namespace


