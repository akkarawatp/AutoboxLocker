Imports Microsoft.VisualBasic
Imports System.Data
Public Class MasterPromotionData
    Dim _Promotion As New DataTable("Promotion")
    Dim _PromotionHour As New DataTable("PromotionHour")

    Public Property Promotion As DataTable
        Get
            Return _Promotion
        End Get
        Set(value As DataTable)
            _Promotion = value
        End Set
    End Property

    Public Property PromotionHour As DataTable
        Get
            Return _PromotionHour
        End Get
        Set(value As DataTable)
            _PromotionHour = value
        End Set
    End Property

End Class
