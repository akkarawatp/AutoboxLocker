Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System

Public Class Converter
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

    Public Shared Function ShortMonthENToInt(ByVal ShortMonth As String) As Integer
        Select Case ShortMonth.ToUpper
            Case "Jan".ToUpper
                Return 1
            Case "Feb".ToUpper
                Return 2
            Case "Mar".ToUpper
                Return 3
            Case "Apr".ToUpper
                Return 4
            Case "May".ToUpper
                Return 5
            Case "Jun".ToUpper
                Return 6
            Case "Jul".ToUpper
                Return 7
            Case "Aug".ToUpper
                Return 8
            Case "Sep".ToUpper
                Return 9
            Case "Oct".ToUpper
                Return 10
            Case "Nov".ToUpper
                Return 11
            Case "Dec".ToUpper
                Return 12
            Case Else : Return 0
        End Select
    End Function

    Public Shared Function ToMonthNameTH(ByVal MonthID As Integer) As String
        Select Case MonthID
            Case 1 : Return "มกราคม"
            Case 2 : Return "กุมภาพันธ์"
            Case 3 : Return "มีนาคม"
            Case 4 : Return "เมษายน"
            Case 5 : Return "พฤษภาคม"
            Case 6 : Return "มิถุนายน"
            Case 7 : Return "กรกฎาคม"
            Case 8 : Return "สิงหาคม"
            Case 9 : Return "กันยายน"
            Case 10 : Return "ตุลาคม"
            Case 11 : Return "พฤศจิกายน"
            Case 12 : Return "ธันวาคม"
            Case Else : Return "..."
        End Select
    End Function

    Public Shared Function ToMonthShortTH(ByVal MonthID As Integer) As String
        Select Case MonthID
            Case 1 : Return "ม.ค."
            Case 2 : Return "ก.พ."
            Case 3 : Return "มี.ค."
            Case 4 : Return "เม.ย."
            Case 5 : Return "พ.ค."
            Case 6 : Return "มิ.ย."
            Case 7 : Return "ก.ค."
            Case 8 : Return "ส.ค."
            Case 9 : Return "ก.ย."
            Case 10 : Return "ต.ค."
            Case 11 : Return "พ.ย."
            Case 12 : Return "ธ.ค."
            Case Else : Return "..."
        End Select
    End Function

    Public Shared Function StringToDate(ByVal InputString As String, ByVal Format As String) As DateTime
        Dim Provider As CultureInfo = CultureInfo.GetCultureInfo("en-US")
        Return DateTime.ParseExact(InputString, Format, Provider)
    End Function

    Public Shared Function DateToString(ByVal InputDate As DateTime, ByVal Format As String) As String
        Return InputDate.ToString(Format)
    End Function

    Public Shared Function ConvertTextToDate(ByVal Input As String) As DateTime
        Dim C As New Converter
        Try
            Dim D As String() = Split(Input, " ")
            Return New Date(CInt(D(2)), C.ShortMonthENToInt(D(0)), CInt(D(1)))
        Catch ex As Exception
            Return DateTime.FromOADate(0)
        End Try
    End Function

    Public Shared Function DateToSQLString(ByVal InputDate As DateTime) As String
        Return InputDate.Year & "-" & InputDate.Month.ToString.PadLeft(2, "0") & "-" & InputDate.Day.ToString.PadLeft(2, "0")
    End Function


End Class
