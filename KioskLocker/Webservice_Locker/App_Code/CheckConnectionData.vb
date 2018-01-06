Imports Microsoft.VisualBasic

Public Class CheckConnectionData
    Dim _IsSuccess As Boolean = False
    Dim _DbInfo As String = ""
    Dim _ErrorMessage As String = ""

    Public Property IsSuccess As Boolean
        Get
            Return _IsSuccess
        End Get
        Set(value As Boolean)
            _IsSuccess = value
        End Set
    End Property
    Public Property DbInfo As String
        Get
            Return _DbInfo.Trim()
        End Get
        Set(value As String)
            _DbInfo = value
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
