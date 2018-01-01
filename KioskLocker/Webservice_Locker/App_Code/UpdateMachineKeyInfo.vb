Imports Microsoft.VisualBasic

Public Class UpdateMachineKeyInfo
    Dim _IsSuccess As Boolean = False
    Dim _KioskId As Long = 0
    Dim _IpAddress As String = ""
    Dim _MacAddress As String = ""
    Dim _LocationCode As String = ""
    Dim _LocationName As String = ""
    Dim _KioskSysconfig As New ServerLinqDB.TABLE.CfKioskSysconfigServerLinqDB
    Dim _ErrorMessage As String = ""

    Public Property IsSuccess As Boolean
        Get
            Return _IsSuccess
        End Get
        Set(value As Boolean)
            _IsSuccess = value
        End Set
    End Property
    Public Property KioskID As Long
        Get
            Return _KioskId
        End Get
        Set(value As Long)
            _KioskId = value
        End Set
    End Property

    Public Property IpAddress As String
        Get
            Return _IpAddress.Trim
        End Get
        Set(value As String)
            _IpAddress = value
        End Set
    End Property

    Public Property MacAddress As String
        Get
            Return _MacAddress.Trim
        End Get
        Set(value As String)
            _MacAddress = value
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
    Public Property KioskSysconfig As ServerLinqDB.TABLE.CfKioskSysconfigServerLinqDB
        Get
            Return _KioskSysconfig
        End Get
        Set(value As ServerLinqDB.TABLE.CfKioskSysconfigServerLinqDB)
            _KioskSysconfig = value
        End Set
    End Property

    Public Property ErrorMessage As String
        Get
            Return _ErrorMessage.Trim
        End Get
        Set(value As String)
            _ErrorMessage = value
        End Set
    End Property
End Class
