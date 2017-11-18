Imports System.Globalization
Imports System.Text
Imports System.Drawing
Imports System.IO

Public Class ConverterENG
    Public Enum EncodeType
        _DEFAULT = 0
        _ASCII = 1
        _UNICODE = 2
        _UTF32 = 3
        _UTF7 = 4
        _UTF8 = 5
    End Enum

    Public Shared Function StreamToByte(ByVal Stream As System.IO.Stream) As Byte() ' Convert Specify Stream To Byte
        Dim Result() As Byte
        ReDim Result(Stream.Length - 1)
        Stream.Read(Result, 0, Stream.Length)
        StreamToByte = Result.Clone
    End Function

    Public Shared Function ByteToStream(ByVal Buffer() As Byte) As System.IO.MemoryStream ' Convert Byte To Stream
        ByteToStream = New System.IO.MemoryStream(Buffer)
    End Function

    Public Shared Function BitmapToByte(bmp As Bitmap) As Byte()
        Dim result() As Byte
        If bmp IsNot Nothing Then
            Dim stream As New MemoryStream
            bmp.Save(stream, Imaging.ImageFormat.Jpeg)
            result = stream.ToArray()
        End If

        Return result
    End Function

    Public Shared Function StringToByte(ByVal Str As String, Optional ByVal Encoding As Integer = EncodeType._DEFAULT) As Byte()
        Select Case Encoding
            Case EncodeType._ASCII
                Return System.Text.Encoding.ASCII.GetBytes(Str)
            Case EncodeType._UNICODE
                Return System.Text.Encoding.Unicode.GetBytes(Str)
            Case EncodeType._UTF32
                Return System.Text.Encoding.UTF32.GetBytes(Str)
            Case EncodeType._UTF7
                Return System.Text.Encoding.UTF7.GetBytes(Str)
            Case EncodeType._UTF8
                Return System.Text.Encoding.UTF8.GetBytes(Str)
            Case Else
                Return System.Text.Encoding.Default.GetBytes(Str)
        End Select
    End Function

    Public Shared Function ByteToString(ByVal Buffer() As Byte, Optional ByVal Encoding As Integer = EncodeType._DEFAULT) As String
        System.Text.Encoding.Default.GetString(Buffer, 0, Buffer.Length)
        Select Case Encoding
            Case EncodeType._ASCII
                Return System.Text.Encoding.ASCII.GetString(Buffer, 0, Buffer.Length)
            Case EncodeType._UNICODE
                Return System.Text.Encoding.Unicode.GetString(Buffer, 0, Buffer.Length)
            Case EncodeType._UTF32
                Return System.Text.Encoding.UTF32.GetString(Buffer, 0, Buffer.Length)
            Case EncodeType._UTF7
                Return System.Text.Encoding.UTF7.GetString(Buffer, 0, Buffer.Length)
            Case EncodeType._UTF8
                Return System.Text.Encoding.UTF8.GetString(Buffer, 0, Buffer.Length)
            Case Else
                Return System.Text.Encoding.Default.GetString(Buffer, 0, Buffer.Length)
        End Select
    End Function

    Public Shared Function ToMonthNameEN(ByVal MonthID As Integer) As String
        Select Case MonthID
            Case 1 : Return "January"
            Case 2 : Return "February"
            Case 3 : Return "March"
            Case 4 : Return "April"
            Case 5 : Return "May"
            Case 6 : Return "June"
            Case 7 : Return "July"
            Case 8 : Return "August"
            Case 9 : Return "September"
            Case 10 : Return "October"
            Case 11 : Return "November"
            Case 12 : Return "December"
            Case Else : Return "Unknow"
        End Select
    End Function

    Public Shared Function StringToDate(ByVal InputString As String, ByVal Format As String) As DateTime
        Dim Provider As CultureInfo = CultureInfo.GetCultureInfo("en-US")
        Return DateTime.ParseExact(InputString, Format, Provider)
    End Function

    Public Shared Function DateToString(ByVal InputDate As DateTime, ByVal Format As String) As String
        Return InputDate.ToString(Format)
    End Function

    Public Shared Function ConvertHexToBytes(ByVal Hex As String) As Byte()
        Dim result = New Byte((Hex.Length + 1) \ 2 - 1) {}
        Dim offset = 0
        If Hex.Length Mod 2 = 1 Then
            ' If length of Hex is odd, the first character has an implicit 0 prepended.
            result(0) = CByte(Convert.ToUInt32(Hex(0) & "", 16))
            offset = 1
        End If
        For i As Integer = 0 To Hex.Length \ 2 - 1
            result(i + offset) = CByte(Convert.ToUInt32(Hex.Substring(i * 2 + offset, 2), 16))
        Next
        Return result
    End Function

    Public Shared Function BytesToHexString(ByVal bytes() As Byte) As String
        Dim sb As New StringBuilder(bytes.Length * 2)
        For Each b As Byte In bytes
            sb.AppendFormat("{0:X2}", b)
        Next b
        Return sb.ToString()
    End Function
End Class
