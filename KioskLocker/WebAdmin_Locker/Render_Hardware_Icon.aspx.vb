Imports System.Data
Imports System.Data.SqlClient
Public Class Render_Hardware_Icon
    Inherits System.Web.UI.Page

    Dim C As New Converter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim FieldName As String = "Icon_White"
        Select Case Request.QueryString("C").ToString
            Case "R" '------------- Session
                FieldName = "Icon_Red"
            Case "G" '------------- Database ID
                FieldName = "Icon_Green"
        End Select

        Try
            Dim BL As New LockerBL
            Dim DT As DataTable = BL.GetList_Device(Request.QueryString("D"), "Y")
            Dim b As Byte() = DT.Rows(0).Item(FieldName)
            Dim s As IO.Stream = C.ByteToStream(b)
            Dim img As Drawing.Image = Drawing.Image.FromStream(s)
            Select Case True
                Case Equals(img.RawFormat, Drawing.Imaging.ImageFormat.Jpeg)
                    Response.AddHeader("Content-Type", "Image/Jpeg")
                Case Equals(img.RawFormat, Drawing.Imaging.ImageFormat.Gif)
                    Response.AddHeader("Content-Type", "Image/Gif")
                Case Equals(img.RawFormat, Drawing.Imaging.ImageFormat.Png)
                    Response.AddHeader("Content-Type", "Image/Png")
            End Select
            Response.BinaryWrite(b)
        Catch ex As Exception
            'Response.Redirect("Images/BlackDot.png")
        End Try


    End Sub

End Class