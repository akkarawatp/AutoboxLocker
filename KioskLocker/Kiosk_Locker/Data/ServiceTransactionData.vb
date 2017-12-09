Imports MiniboxLocker.Data
Public Class DepositTransactionData
    Dim _KioskID As String = ""
    Dim _DepositTransactionID As Long = 0
    Dim _DepositTransNo As String = ""
    Dim _TransStatus As TransactionStatus = TransactionStatus.Inprogress

    Dim _LockerID As Integer = 0
    Dim _LockerName As String = ""
    Dim _CabinetID As Integer = 0
    Dim _CabinetModelID As Integer = 0
    Dim _LockerPinSolenoid As Integer = 0
    Dim _LockerPinLED As Integer = 0
    Dim _LockerPinSensor As String = "0"

    Dim _PinCode As String = ""

    'Dim _PassportNo As String = ""
    'Dim _IDCardNo As String = ""
    'Dim _NationCode As String = ""
    'Dim _FirstName As String = ""
    'Dim _LastName As String = ""
    'Dim _Birthdate As New DateTime(1, 1, 1)
    'Dim _Gender As String = ""
    'Dim _PassportExpireDate As New DateTime(1, 1, 1)
    'Dim _IDCardExpireDate As New DateTime(1, 1, 1)
    Dim _CustomerImage As Byte()

    Dim _ServiceRate As Integer = 0
    Dim _ServiceRateLimitDay As Integer = 0
    Dim _DepositAmount As Integer = 0
    Dim _PaidAmount As Integer = 0
    Dim _PaidTime As New DateTime(1, 1, 1)

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

    Public Sub New(KioskID As String)
        _KioskID = KioskID
    End Sub

    Public Property DepositTransactionID As Long
        Get
            Return _DepositTransactionID
        End Get
        Set(value As Long)
            _DepositTransactionID = value
        End Set
    End Property

    Public Property DepositTransNo As String
        Get
            Return _DepositTransNo.Trim
        End Get
        Set(value As String)
            _DepositTransNo = value
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
    Public Property PinCode As String
        Get
            Return _PinCode.Trim
        End Get
        Set(value As String)
            _PinCode = value
        End Set
    End Property

    'Public Property PassportNo As String
    '    Get
    '        Return _PassportNo.Trim
    '    End Get
    '    Set(value As String)
    '        _PassportNo = value
    '    End Set
    'End Property

    'Public Property IDCardNo As String
    '    Get
    '        Return _IDCardNo.Trim()
    '    End Get
    '    Set(value As String)
    '        _IDCardNo = value
    '    End Set
    'End Property
    'Public Property NationCode As String
    '    Get
    '        Return _NationCode.Trim
    '    End Get
    '    Set(value As String)
    '        _NationCode = value
    '    End Set
    'End Property
    'Public Property FirstName As String
    '    Get
    '        Return _FirstName.Trim
    '    End Get
    '    Set(value As String)
    '        _FirstName = value
    '    End Set
    'End Property
    'Public Property LastName As String
    '    Get
    '        Return _LastName.Trim
    '    End Get
    '    Set(value As String)
    '        _LastName = value
    '    End Set
    'End Property
    'Public Property BirthDate As DateTime
    '    Get
    '        Return _Birthdate
    '    End Get
    '    Set(value As DateTime)
    '        _Birthdate = value
    '    End Set
    'End Property
    'Public Property Gender As String
    '    Get
    '        Return _Gender.Trim
    '    End Get
    '    Set(value As String)
    '        _Gender = value
    '    End Set
    'End Property
    'Public Property PassportExpireDate As DateTime
    '    Get
    '        Return _PassportExpireDate
    '    End Get
    '    Set(value As DateTime)
    '        _PassportExpireDate = value
    '    End Set
    'End Property
    'Public Property IDCardExpireDate As DateTime
    '    Get
    '        Return _IDCardExpireDate
    '    End Get
    '    Set(value As DateTime)
    '        _IDCardExpireDate = value
    '    End Set
    'End Property

    Public Property CustomerImage As Byte()
        Get
            Return _CustomerImage
        End Get
        Set(value As Byte())
            _CustomerImage = value
        End Set
    End Property

    Public Property ServiceRate As Integer
        Get
            Return _ServiceRate
        End Get
        Set(value As Integer)
            _ServiceRate = value
        End Set
    End Property
    Public Property ServiceRateLimitDay As Integer
        Get
            Return _ServiceRateLimitDay
        End Get
        Set(value As Integer)
            _ServiceRateLimitDay = value
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
    Public Property PaidAmount As Integer
        Get
            Return _PaidAmount
        End Get
        Set(value As Integer)
            _PaidAmount = value
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
