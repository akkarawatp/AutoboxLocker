Namespace Data
    Module ConstantsData
        Public Enum KioskLanguage
            Thai = 1
            English = 2
            China = 3
            Japan = 4
        End Enum

        'Public Enum TransectionType
        '    Kiosk = 1
        '    StaffConsole = 2
        'End Enum

        Public Enum TransactionType
            DepositBelonging = 1
            CollectBelonging = 2
            StaffConsole = 3
        End Enum

#Region "Device Info"
        Public Enum DeviceID
            BankNoteIn = 1
            BankNoteOut_20 = 2
            BankNoteOut_100 = 3
            CoinIn = 4
            CoinOut_1 = 5
            CoinOut_5 = 6
            Printer = 7
            WebCamera = 8
            BankNoteOut_50 = 9
            CoinOut_2 = 10
            CoinOut_10 = 11
            BankNoteOut_500 = 12
            NetworkConnection = 13
            QRCodeReader = 14
            SolenoidBoard = 15
            LEDBoard = 16
            SensorBoard = 17

        End Enum

        Public Enum DeviceType
            BanknoteIn = 1
            BanknoteOut = 2
            CoinIn = 3
            CoinOut = 4
            Printer = 5
            'IdCardAndPassportScanner = 6
            NetworkConnection = 7
            QRCodeScanner = 8
            SolenoidBoard = 9
            LEDBoard = 10
            SensorBoard = 11
        End Enum

        Public Enum BanknoteInStatus
            Ready = 1
            Unavailable = 0
            Disconnected = 2
            Power_OFF = 3
            Motor_Failure = 4
            Checksum_Error = 5
            Bill_Jam = 6
            Bill_Remove = 7
            Stacker_Open = 8
            Sensor_Problem = 9
            Bill_Fish = 10
        End Enum

        Public Enum CoinInStatus
            Ready = 1
            Unavailable = 0
            Disconnected = 2
            Sersor_1_Problem = 3
            Sersor_2_Problem = 4
            Sersor_3_Problem = 5
        End Enum

        Public Enum BanknoteOutStatus
            Ready = 1
            Disconnected = 2
            Single_machine_payout = 3
            Multiple_machine_payout = 4
            'Payout_Successful = 5
            Payout_fails = 6
            Empty_note = 7
            Stock_less = 8
            Note_jam = 9
            Over_length = 10
            Note_Not_Exit = 11
            Sensor_Error = 12
            Double_note_error = 13
            Motor_Error = 14
            Dispensing_busy = 15
            Sensor_adjusting = 16
            Checksum_Error = 17
            Low_power_Error = 18
        End Enum


        Public Enum CoinOutStatus
            Ready = 1
            Disconnected = 2
            Enable_BA_if_hopper_problems_recovered = 3
            Inhibit_BA_if_hopper_problems_occurred = 4
            Mortor_Problem = 5
            Insufficient_Coin = 6
            Dedects_coin_dispensing_activity_after_suspending_the_dispene_signal = 7
            Reserved = 8
            Prism_Sersor_Failure = 9
            Shaft_Sersor_Failure = 10
        End Enum



        Public Enum PassportScanerStatus
            Ready = 1
            Disconnected = 2
        End Enum

        Public Enum PrinterStatus
            Online = 1
            Disconnected = 2
            Offline = 3
        End Enum

        Public Enum IPCamStatus
            Ready = 1
            Disconnected = 2
        End Enum

        Public Enum QRCodeStatus
            Ready = 1
            Disconnected = 2
        End Enum
        Public Enum NetworkStatus
            Ready = 1
            Disconnected = 2
        End Enum

        Public Enum BoardStatus
            Ready = 1
            Disconnected = 2
        End Enum
#End Region
    End Module

End Namespace
