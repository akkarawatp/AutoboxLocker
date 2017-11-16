Namespace Data
    Public Class KioskLockerStateData

        Public Enum StateModule
            Home = 1
            ChooseService = 2
            BuyNewSim = 3
            TopUp = 4
            StaffConsole = 5
        End Enum

        Public Enum StateStep_Home
            CheckHardware = 1
            CheckHardwareError = 2
            CheckHardwareOutOfService = 3
            ResetTransection = 4
            ShowFormSelectLanguage = 5
            SelectLanguage = 6
            CheckShift = 7
            CheckShiftError = 8
            CheckShiftOutOfService = 9
        End Enum


        Public Enum StateStep_BSM
            ShowFormSelectPackage = 1
            SelectPackage = 2
            ScanPassport = 3
            ScanPassportFail = 4
            CheckHardware = 5
            CheckHardwareError = 6
            CheckHardwareOutOfService = 7
            CheckShift = 8
            CheckShiftError = 9
            CheckShiftOutOfService = 10
            ShowFormPayment = 11
            PaymentCancel = 12
            PaymentTimeOut = 13
            PaymentRepay = 14
            Dispenser = 15
            ScanBarcode = 16
            DispenserDropSim = 17
            DispenserRepeat = 18
            DispenserCheckSameCaseConfig = 19
            DispenserRepay = 20
            DispenserNotice = 21
            DispenserOutOfService = 22
            StartWebservice = 23
            WS_CheckMobileNoFromAIS = 24
            WS_PI = 25
            WS_FirstAct = 26
            WS_TopUp = 27
            WS_GetAccountNo = 28
            WS_GetSimSerialBos = 29
            WS_GetSimSerialNonBos = 30
            WS_GenReceiptBos = 31
            WS_GenReceiptNonBos = 32
            WS_AddPackage = 33
            WS_StockTDM = 34
            WS_ErrorRepay = 35
            WS_DropSim = 36
            WS_ErrorCheckSameCaseConfig = 37
            WS_OutOfService = 38
            Change = 39
            ConfirmationSlip = 40
            Success = 41
        End Enum

        Public Enum StateStep_TOP
            ShowFormInsertMobile = 1
            ValidateMobileNo = 2
            FormatMobileNoInvalid = 3
            CheckMobileNoFromAIS = 4
            CheckMobileNoFromAISError = 5
            ShowFormSelectTopUp = 6
            ChooseTopUp = 7
            CheckHardware = 8
            CheckHardwareError = 9
            CheckHardwareOutOfService = 10
            CheckShift = 11
            CheckShiftError = 12
            CheckShiftOutOfService = 13
            ShowFormPayment = 14
            PaymentCancel = 15
            PaymentTimeOut = 16
            PaymentRepay = 17
            StartWebservice = 18
            WS_TopUp = 19
            WS_GetAccountNo = 20
            WS_GetSimSerialBos = 21
            WS_GetSimSerialNonBos = 22
            WS_GenReceiptBos = 23
            WS_GenReceiptNonBos = 24
            WS_ErrorRepay = 25
            WS_ErrorCheckSameCaseConfig = 26
            WS_OutOfService = 27
            Change = 28
            ConfirmationSlip = 29
            Success = 30
        End Enum

        Public Enum StateStep_SCC
            ShowFormLogin = 1
            LoginCancel = 2
            ValidateLogin = 3
            LoginNotice = 4
            CheckHardware = 5
            ShowFormHardwareStatus = 6
            ShowFormFillPaper = 7
            FillPaperConfirm = 8
            FillPaperCancel = 9
            ShowFormFillSIM = 10
            FillSIMConfirm = 11
            FillSIMCancel = 12
            ShowformKioskSetting = 13
            KioskSettingConfirm = 14
            KioskSettingCancel = 15
            CheckShift = 16
            ShowFormOpenCloseShiftLogin = 17
            OpenCloseShiftLoginCancel = 18
            OpenCloseShiftValidateLogin = 19
            OpenCloseShiftLoginNotice = 20
            ShowformOpenShift = 21
            OpenShiftNotice = 22
            OpenShiftCancel = 23
            OpenShiftSuccess = 24
            ShowFormCloseShift = 25
            CloseShiftNotice = 26
            CloseShiftCancel = 27
            CloseShiftSuccess = 28
            OpenShift = 29
            CloseShift = 30
        End Enum
    End Class
End Namespace

