Public Class ucStockProgress
    Dim _MinValue As Integer = 1
    Dim _MaxValue As Integer = 100
    Dim _Value As Integer = 1
    Dim _Direction As ProgressDirection = ProgressDirection.LeftToRight

    Public Property MinValue As Integer
        Get
            Return _MinValue
        End Get
        Set(value As Integer)
            _MinValue = value
        End Set
    End Property
    Public Property MaxValue As Integer
        Get
            Return _MaxValue
        End Get
        Set(value As Integer)
            _MaxValue = value
        End Set
    End Property
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(value As Integer)
            _Value = value

            If _Direction = ProgressDirection.LeftToRight Then
                lblProgress.Left = (_Value * (Me.Width / _MaxValue)) - Me.Width
            Else
                lblProgress.Left = (Me.Width - (_Value * (Me.Width / _MaxValue))) * -1
            End If

        End Set
    End Property
    Public WriteOnly Property BarColor As Color
        Set(value As Color)
            lblProgress.BackColor = value
        End Set
    End Property
    Public WriteOnly Property Direction As ProgressDirection
        Set(value As ProgressDirection)
            _Direction = value
        End Set
    End Property

    Private Sub ucStockProgress_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        lblProgress.Width = Me.Width
        lblProgress.Height = Me.Height
        lblProgress.Left = (_Value * (Me.Width / _MaxValue)) - Me.Width
    End Sub

    Public Enum ProgressDirection
        LeftToRight = 1
        RightToLeft = 2
    End Enum
End Class
