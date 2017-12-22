Public Class CollectTransactionData
    Dim _KioskID As String = ""
    Dim _DepositTransNo As String = ""
    Dim _CollectTransactionID As Long = 0
    Dim _TransactionNo As String = ""
    Dim _TransStatus As TransactionStatus = TransactionStatus.Inprogress
    Dim _LostQRCode As String = "Z"

    Dim _LockerID As Integer = 0
    Dim _LockerName As String = ""
    Dim _CabinetID As Integer = 0
    Dim _CabinetModelID As Integer = 0
    Dim _LockerPinSolenoid As Integer = 0
    Dim _LockerPinLED As Integer = 0
    Dim _LockerPinSensor As String = "0"

    Dim _DepositPaidTime As New DateTime(1, 1, 1)
    Dim _PaidTime As New DateTime(1, 1, 1)
    Dim _PickupTime As New DateTime(1, 1, 1)
    Dim _DepositAmount As Integer = 0
    Dim _ServiceAmount As Integer = 0
    Dim _IsFine As Boolean = False
    Dim _FineAmount As Integer = 0
    Dim _PaidAmount As Integer = 0
    Dim _CustomerImage As Byte()

    Dim _ReceiveCoin1 As Integer = 0
    Dim _ReceiveCoin2 As Integer = 0
    Dim _ReceiveCoin5 As Integer = 0
    Dim _ReceiveCoin10 As Integer = 0
    Dim _ReceiveBankNote20 As Integer = 0
    Dim _ReceiveBankNote50 As Integer = 0
    Dim _ReceiveBankNote100 As Integer = 0
    Dim _ReceiveBankNote500 As Integer = 0
    Dim _ReceiveBankNote1000 As Integer = 0

    Dim _ChangeAmount As Integer = 0
    Dim _ChangeCoin1 As Integer = 0
    Dim _ChangeCoin2 As Integer = 0
    Dim _ChangeCoin5 As Integer = 0
    Dim _ChangeCoin10 As Integer = 0
    Dim _ChangeBankNote20 As Integer = 0
    Dim _ChangeBankNote50 As Integer = 0
    Dim _ChangeBankNote100 As Integer = 0
    Dim _ChangeBankNote500 As Integer = 0

    'Dim _AppStepID As Int16 = 0


    Public Sub New(KioskID As String)
        _KioskID = KioskID
    End Sub

    Public Property DepositTransNo As String
        Get
            Return _DepositTransNo
        End Get
        Set(value As String)
            _DepositTransNo = value
        End Set
    End Property
    Public Property CollectTransactionID As Long
        Get
            Return _CollectTransactionID
        End Get
        Set(value As Long)
            _CollectTransactionID = value
        End Set
    End Property

    Public Property TransactionNo As String
        Get
            Return _TransactionNo.Trim
        End Get
        Set(value As String)
            _TransactionNo = value
        End Set
    End Property

    Public Property TransStatus As TransactionStatus
        Get
            Return _TransStatus
        End Get
        Set(value As TransactionStatus)
            _TransStatus = value
        End Set
    End Property

    Public Property LostQRCode As String
        Get
            Return _LostQRCode.Trim
        End Get
        Set(value As String)
            _LostQRCode = value
        End Set
    End Property

    Public Property LockerID As Integer
        Get
            Return _LockerID
        End Get
        Set(value As Integer)
            _LockerID = value
        End Set
    End Property
    Public Property LockerName As String
        Get
            Return _LockerName.Trim
        End Get
        Set(value As String)
            _LockerName = value
        End Set
    End Property
    Public Property CabinetID As Integer
        Get
            Return _CabinetID
        End Get
        Set(value As Integer)
            _CabinetID = value
        End Set
    End Property
    Public Property CabinetModelID As Integer
        Get
            Return _CabinetModelID
        End Get
        Set(value As Integer)
            _CabinetModelID = value
        End Set
    End Property

    Public Property LockerPinSolenoid As Integer
        Get
            Return _LockerPinSolenoid
        End Get
        Set(value As Integer)
            _LockerPinSolenoid = value
        End Set
    End Property
    Public Property LockerPinLED As Integer
        Get
            Return _LockerPinLED
        End Get
        Set(value As Integer)
            _LockerPinLED = value
        End Set
    End Property
    Public Property LockerPinSendor As String
        Get
            Return _LockerPinSensor
        End Get
        Set(value As String)
            _LockerPinSensor = value
        End Set
    End Property

    Public Property DepositPaidTime As DateTime
        Get
            Return _DepositPaidTime
        End Get
        Set(value As DateTime)
            _DepositPaidTime = value
        End Set
    End Property


    Public Property PaidTime As DateTime
        Get
            Return _PaidTime
        End Get
        Set(value As DateTime)
            _PaidTime = value
        End Set
    End Property

    Public Property PickupTime As DateTime
        Get
            Return _PickupTime
        End Get
        Set(value As DateTime)
            _PickupTime = value
        End Set
    End Property

    Public Property DepositAmount As Integer
        Get
            Return _DepositAmount
        End Get
        Set(value As Integer)
            _DepositAmount = value
        End Set
    End Property
    Public Property ServiceAmount As Integer
        Get
            Return _ServiceAmount
        End Get
        Set(value As Integer)
            _ServiceAmount = value
        End Set
    End Property
    Public Property IsFine As Boolean
        Get
            Return _IsFine
        End Get
        Set(value As Boolean)
            _IsFine = value
        End Set
    End Property
    Public Property FineAmount As Integer
        Get
            Return _FineAmount
        End Get
        Set(value As Integer)
            _FineAmount = value
        End Set
    End Property
    Public Property PaidAmount As Integer
        Get
            Return _PaidAmount
        End Get
        Set(value As Integer)
            _PaidAmount = value
        End Set
    End Property
    Public Property CustomerImage As Byte()
        Get
            Return _CustomerImage
        End Get
        Set(value As Byte())
            _CustomerImage = value
        End Set
    End Property
    Public Property ReceiveCoin1 As Integer
        Get
            Return _ReceiveCoin1
        End Get
        Set(value As Integer)
            _ReceiveCoin1 = value
        End Set
    End Property

    Public Property ReceiveCoin2 As Integer
        Get
            Return _ReceiveCoin2
        End Get
        Set(value As Integer)
            _ReceiveCoin2 = value
        End Set
    End Property
    Public Property ReceiveCoin5 As Integer
        Get
            Return _ReceiveCoin5
        End Get
        Set(value As Integer)
            _ReceiveCoin5 = value
        End Set
    End Property
    Public Property ReceiveCoin10 As Integer
        Get
            Return _ReceiveCoin10
        End Get
        Set(value As Integer)
            _ReceiveCoin10 = value
        End Set
    End Property
    Public Property ReceiveBankNote20 As Integer
        Get
            Return _ReceiveBankNote20
        End Get
        Set(value As Integer)
            _ReceiveBankNote20 = value
        End Set
    End Property

    Public Property ReceiveBankNote50 As Integer
        Get
            Return _ReceiveBankNote50
        End Get
        Set(value As Integer)
            _ReceiveBankNote50 = value
        End Set
    End Property

    Public Property ReceiveBankNote100 As Integer
        Get
            Return _ReceiveBankNote100
        End Get
        Set(value As Integer)
            _ReceiveBankNote100 = value
        End Set
    End Property

    Public Property ReceiveBankNote500 As Integer
        Get
            Return _ReceiveBankNote500
        End Get
        Set(value As Integer)
            _ReceiveBankNote500 = value
        End Set
    End Property

    Public Property ReceiveBankNote1000 As Integer
        Get
            Return _ReceiveBankNote1000
        End Get
        Set(value As Integer)
            _ReceiveBankNote1000 = value
        End Set
    End Property

    Public Property ChangeAmount As Integer
        Get
            Return _ChangeAmount
        End Get
        Set(value As Integer)
            _ChangeAmount = value
        End Set
    End Property
    Public Property ChangeCoin1 As Integer
        Get
            Return _ChangeCoin1
        End Get
        Set(value As Integer)
            _ChangeCoin1 = value
        End Set
    End Property
    Public Property ChangeCoin2 As Integer
        Get
            Return _ChangeCoin2
        End Get
        Set(value As Integer)
            _ChangeCoin2 = value
        End Set
    End Property
    Public Property ChangeCoin5 As Integer
        Get
            Return _ChangeCoin5
        End Get
        Set(value As Integer)
            _ChangeCoin5 = value
        End Set
    End Property
    Public Property ChangeCoin10 As Integer
        Get
            Return _ChangeCoin10
        End Get
        Set(value As Integer)
            _ChangeCoin10 = value
        End Set
    End Property
    Public Property ChangeBankNote20 As Integer
        Get
            Return _ChangeBankNote20
        End Get
        Set(value As Integer)
            _ChangeBankNote20 = value
        End Set
    End Property
    Public Property ChangeBankNote50 As Integer
        Get
            Return _ChangeBankNote50
        End Get
        Set(value As Integer)
            _ChangeBankNote50 = value
        End Set
    End Property
    Public Property ChangeBankNote100 As Integer
        Get
            Return _ChangeBankNote100
        End Get
        Set(value As Integer)
            _ChangeBankNote100 = value
        End Set
    End Property
    Public Property ChangeBankNote500 As Integer
        Get
            Return _ChangeBankNote500
        End Get
        Set(value As Integer)
            _ChangeBankNote500 = value
        End Set
    End Property


    Public Enum TransactionStatus
        Inprogress = 0
        Success = 1
        Cancel = 2
        Problem = 3
        TimeOut = 4
        CancelByAdmin = 5
    End Enum


End Class
