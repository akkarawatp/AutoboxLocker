Imports System.Data

Public Class MasterServiceRateData
    Dim _ServiceRate As New DataTable
    Dim _ServiceRateDeposit As New DataTable
    Dim _ServiceRateHour As New DataTable
    Dim _ServiceRateOverNight As DataTable

    Public Property ServiceRate As DataTable
        Get
            Return _ServiceRate
        End Get
        Set(value As DataTable)
            _ServiceRate = value
        End Set
    End Property
    Public Property ServiceRateDeposit As DataTable
        Get
            Return _ServiceRateDeposit
        End Get
        Set(value As DataTable)
            _ServiceRateDeposit = value
        End Set
    End Property
    Public Property ServiceRateHour As DataTable
        Get
            Return _ServiceRateHour
        End Get
        Set(value As DataTable)
            _ServiceRateHour = value
        End Set
    End Property
    Public Property ServiceRateOverNight As DataTable
        Get
            Return _ServiceRateOverNight
        End Get
        Set(value As DataTable)
            _ServiceRateOverNight = value
        End Set
    End Property
End Class
