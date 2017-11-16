Namespace Data
    Public Class StaffConsoleLogonData
        Dim _KioskID As String = "0"
        Dim _TransNo As String = ""
        Dim _TransactionID As Long = 0
        Dim _StartTime As New DateTime(1, 1, 1)
        Dim _EndTime As System.Nullable(Of DateTime) = New DateTime(1, 1, 1)
        Dim _Username As String = ""
        Dim _FirstName As String = ""
        Dim _LastName As String = ""
        Dim _LoginTime As New DateTime(1, 1, 1)
        Dim _LoginBy As String = ""
        Dim _MsAppStepID As System.Nullable(Of Long)
        Dim _AuthorizeInfo As New DataTable

        Public Sub New(KioskID As String)
            _KioskID = KioskID
        End Sub

        Public Property TransNo As String
            Get
                Return _TransNo.Trim
            End Get
            Set(value As String)
                _TransNo = value
            End Set
        End Property
        Public Property TransactionID As Long
            Get
                Return _TransactionID
            End Get
            Set(value As Long)
                _TransactionID = value
            End Set
        End Property
        Public Property StartTime As DateTime
            Get
                Return _StartTime
            End Get
            Set(value As DateTime)
                _StartTime = value
            End Set
        End Property
        Public Property EndTime As System.Nullable(Of DateTime)
            Get
                Return _EndTime
            End Get
            Set(value As System.Nullable(Of DateTime))
                _EndTime = value
            End Set
        End Property
        Public Property Username As String
            Get
                Return _Username.Trim
            End Get
            Set(value As String)
                _Username = value
            End Set
        End Property
        Public Property FirstName As String
            Get
                Return _FirstName.Trim
            End Get
            Set(value As String)
                _FirstName = value
            End Set
        End Property
        Public Property LastName As String
            Get
                Return _LastName.Trim
            End Get
            Set(value As String)
                _LastName = value
            End Set
        End Property
        Public Property LoginTime As DateTime
            Get
                Return _LoginTime
            End Get
            Set(value As DateTime)
                _LoginTime = value
            End Set
        End Property
        Public Property LoginBy As String
            Get
                Return _LoginBy.Trim
            End Get
            Set(value As String)
                _LoginBy = value
            End Set
        End Property
        Public Property MsAppStepID As System.Nullable(Of Long)
            Get
                Return _MsAppStepID
            End Get
            Set(value As System.Nullable(Of Long))
                _MsAppStepID = value
            End Set
        End Property
        Public Property AuthorizeInfo As DataTable
            Get
                Return _AuthorizeInfo
            End Get
            Set(value As DataTable)
                _AuthorizeInfo = value
            End Set
        End Property
    End Class
End Namespace

