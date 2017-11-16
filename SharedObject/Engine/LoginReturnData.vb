Imports Microsoft.VisualBasic

Public Class LoginReturnData
    Dim _LoginStatus As Boolean = False
    Dim _Error As String = ""
    Dim _Token As String = ""
    Dim _Username As String = ""
    Dim _FirstName As String = ""
    Dim _LastName As String = ""
    Dim _CompanyName As String = ""
    Dim _ForceChangePwd As String = ""

    Public Property LoginStatus As Boolean
        Get
            Return _LoginStatus
        End Get
        Set(value As Boolean)
            _LoginStatus = value
        End Set
    End Property
    Public Property Token As String
        Get
            Return _Token.Trim
        End Get
        Set(value As String)
            _Token = value
        End Set
    End Property
    Public Property LoginUsername As String
        Get
            Return _Username.Trim
        End Get
        Set(value As String)
            _Username = value
        End Set
    End Property
    Public Property LoginFirstName As String
        Get
            Return _FirstName.Trim
        End Get
        Set(value As String)
            _FirstName = value
        End Set
    End Property
    Public Property LoginLastName As String
        Get
            Return _LastName.Trim
        End Get
        Set(value As String)
            _LastName = value
        End Set
    End Property
    Public Property LoginCompanyName As String
        Get
            Return _CompanyName.Trim
        End Get
        Set(value As String)
            _CompanyName = value
        End Set
    End Property
    Public Property ForceChangePwd As String
        Get
            Return _ForceChangePwd.Trim
        End Get
        Set(value As String)
            _ForceChangePwd = value
        End Set
    End Property
    Public Property ErrorMessage As String
        Get
            Return _Error.Trim
        End Get
        Set(value As String)
            _Error = value
        End Set
    End Property

End Class
