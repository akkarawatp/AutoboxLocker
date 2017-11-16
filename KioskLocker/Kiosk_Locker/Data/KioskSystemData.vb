Namespace Data
    Public Class KioskSystemData
        Dim _CardLanDesc As String = ""
        Dim _KioskID As String = ""
        Dim _LocationCode As String = ""
        Dim _LocationName As String = ""
        Dim _IpAddress As String = ""
        Dim _MacAddress As String = ""
        Dim _ComputerName As String = ""


        Public Property CardLanDesc As String
            Get
                Return _CardLanDesc.Trim
            End Get
            Set(value As String)
                _CardLanDesc = value
            End Set
        End Property

        Public Property KioskID As String
            Get
                Return _KioskID.Trim
            End Get
            Set(value As String)
                _KioskID = value
            End Set
        End Property

        'Public Property LocationCode As String
        '    Get
        '        Return _LocationCode.Trim
        '    End Get
        '    Set(value As String)
        '        _LocationCode = value
        '    End Set
        'End Property

        'Public Property LocationName As String
        '    Get
        '        Return _LocationName.Trim
        '    End Get
        '    Set(value As String)
        '        _LocationName = value
        '    End Set
        'End Property

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
        Public Property ComputerName As String
            Get
                Return _ComputerName.Trim
            End Get
            Set(value As String)
                _ComputerName = value
            End Set
        End Property


    End Class
End Namespace