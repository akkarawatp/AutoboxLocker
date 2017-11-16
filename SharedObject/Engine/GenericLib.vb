Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Globalization
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.IO

Public Class GenericLib

    Public Function IsFormatFileName(ByVal FileName As String) As Boolean
        Dim ExceptChars As String = "/\:*?""<>|;"
        For i As Integer = 1 To Len(ExceptChars)
            If InStr(FileName, Mid(ExceptChars, i)) > 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function IsValidEmailFormat(ByVal input As String) As Boolean
        Return Regex.IsMatch(input, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function

    Public Function OriginalFileName(ByVal FullPath As String) As String
        Return FullPath.Substring(FullPath.LastIndexOf("\") + 1)
    End Function

    Public Function ReportMonthThai(ByVal MonthID As Integer) As String
        Select Case MonthID
            Case 1
                Return "มกราคม"
            Case 2
                Return "กุมภาพันธ์"
            Case 3
                Return "มีนาคม"
            Case 4
                Return "เมษายน"
            Case 5
                Return "พฤษภาคม"
            Case 6
                Return "มิถุนายน"
            Case 7
                Return "กรกฎาคม"
            Case 8
                Return "สิงหาคม"
            Case 9
                Return "กันยายน"
            Case 10
                Return "ตุลาคม"
            Case 11
                Return "พฤศจิกายน"
            Case 12
                Return "ธันวาคม"
            Case Else
                Return ""
        End Select
    End Function

    Public Function ReportMonthThaiShort(ByVal MonthID As Integer) As String
        Select Case MonthID
            Case 1
                Return "ม.ค."
            Case 2
                Return "ก.พ."
            Case 3
                Return "มี.ค."
            Case 4
                Return "เม.ย."
            Case 5
                Return "พ.ค."
            Case 6
                Return "มิ.ย."
            Case 7
                Return "ก.ค."
            Case 8
                Return "ส.ค."
            Case 9
                Return "ก.ย."
            Case 10
                Return "ต.ค."
            Case 11
                Return "พ.ย."
            Case 12
                Return "ธ.ค."
            Case Else
                Return ""
        End Select
    End Function

    Public Function ReportMonthEnglish(ByVal MonthID As Integer) As String
        Select Case MonthID
            Case 1
                Return "January"
            Case 2
                Return "February"
            Case 3
                Return "March"
            Case 4
                Return "April"
            Case 5
                Return "May"
            Case 6
                Return "June"
            Case 7
                Return "July"
            Case 8
                Return "August"
            Case 9
                Return "September"
            Case 10
                Return "October"
            Case 11
                Return "November"
            Case 12
                Return "December"
            Case Else
                Return ""
        End Select
    End Function

    Public Function ReportShotMonthEnglish(ByVal MonthID As Integer) As String
        Select Case MonthID
            Case 1
                Return "Jan"
            Case 2
                Return "Feb"
            Case 3
                Return "Mar"
            Case 4
                Return "Apr"
            Case 5
                Return "May"
            Case 6
                Return "Jun"
            Case 7
                Return "Jul"
            Case 8
                Return "Aug"
            Case 9
                Return "Sep"
            Case 10
                Return "Oct"
            Case 11
                Return "Nov"
            Case 12
                Return "Dec"
            Case Else
                Return ""
        End Select
    End Function

    Public Function ReportMonthEnglishToNumber(ByVal DateFullName As Integer) As String
        Select Case DateFullName
            Case "January"
                Return 1
            Case "February"
                Return 2
            Case "March"
                Return 3
            Case "April"
                Return 4
            Case "May"
                Return 5
            Case "June"
                Return 6
            Case "July"
                Return 7
            Case "August"
                Return 8
            Case "September"
                Return 9
            Case "October"
                Return 10
            Case "November"
                Return 11
            Case "December"
                Return 12
            Case Else
                Return ""
        End Select
    End Function

    Public Function GetImageContentType(ByVal SrcImg As System.Drawing.Image) As String
        Select Case SrcImg.RawFormat.Guid
            Case Drawing.Imaging.ImageFormat.Bmp.Guid
                Return "image/tiff"
            Case Drawing.Imaging.ImageFormat.Jpeg.Guid
                Return "image/jpeg"
            Case Drawing.Imaging.ImageFormat.Gif.Guid
                Return "image/gif"
            Case Drawing.Imaging.ImageFormat.Png.Guid
                Return "image/png"
            Case Else '------------- Default Format ---------------
                Return ""
        End Select
    End Function

    Public Function IsContentTypeImage(ByVal ContentType As String) As Boolean
        Select Case ContentType.ToLower
            Case "image/tiff", "image/jpeg", "image/gif", "image/png"
                Return True
            Case Else '------------- Default Format ---------------
                Return False
        End Select
    End Function


    'Public Sub ForceDeleteFolder(ByVal Path As String)
    '    On Error Resume Next
    '    ForceDeleteFileInFolder(Path)
    '    My.Computer.FileSystem.DeleteDirectory(Path, FileIO.DeleteDirectoryOption.DeleteAllContents, FileIO.RecycleOption.DeletePermanently)
    'End Sub

    'Public Sub ForceDeleteFileInFolder(ByVal Path As String)
    '    On Error Resume Next
    '    For Each foundFile As String In My.Computer.FileSystem.GetFiles(Path, "*.*")
    '        My.Computer.FileSystem.DeleteFile(foundFile, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
    '    Next
    'End Sub

    Public Function CompactDecimal(ByVal Number As String) As String
        Return Val(Number).ToString
    End Function

    Public Sub PushArray_String(ByRef TheArray() As String, ByVal AppendedValue As String)
        Array.Resize(TheArray, TheArray.Length + 1)
        TheArray(TheArray.Length - 1) = AppendedValue
    End Sub

    Public Sub PushArray_Integer(ByRef TheArray() As Integer, ByVal AppendedValue As Integer)
        Array.Resize(TheArray, TheArray.Length + 1)
        TheArray(TheArray.Length - 1) = AppendedValue
    End Sub

#Region "DateFormat"
    Public Function ReportThaiPassTime(ByVal TheTime As DateTime) As String
        Dim Result As String = ""
        'Result = ReportThaiDate(TheTime) & " "
        If DateDiff(DateInterval.Day, TheTime, Now) = 0 Then
            Result &= "(วันนี้)"
        ElseIf DateDiff(DateInterval.Day, TheTime, Now) = 1 Then
            Result &= "(เมื่อวาน)"
        ElseIf DateDiff(DateInterval.Day, TheTime, Now) = 2 Then
            Result &= "(เมื่อวานซืน)"
        ElseIf DateDiff(DateInterval.Weekday, TheTime, Now) = 0 Then
            Result &= "(สัปดาห์นี้)"
        ElseIf DateDiff(DateInterval.Weekday, TheTime, Now) = 1 Then
            Result &= "(สัปดาห์ที่แล้ว)"
        ElseIf DateDiff(DateInterval.Weekday, TheTime, Now) < 4 Then
            Result &= "(" & DateDiff(DateInterval.Weekday, TheTime, Now) & " สัปดาห์ที่แล้ว)"
        ElseIf DateDiff(DateInterval.Month, TheTime, Now) = 1 Then
            Result &= "(เดือนที่แล้ว)"
        Else
            Result &= "(" & DateDiff(DateInterval.Month, TheTime, Now) & " เดือนที่แล้ว)"
        End If
        Return Result
    End Function

    Public Function ReportEngPassTime(ByVal TheTime As DateTime) As String
        Dim Result As String = ""
        If DateDiff(DateInterval.Month, TheTime, Now) > 1 Then
            Result &= "(" & DateDiff(DateInterval.Month, TheTime, Now) & " months ago)"
        ElseIf DateDiff(DateInterval.Month, TheTime, Now) = 1 Then
            Result &= "(last month)"
        ElseIf DateDiff(DateInterval.Weekday, TheTime, Now) > 1 Then
            Result &= "(" & DateDiff(DateInterval.Weekday, TheTime, Now) & " weeks ago)"
        ElseIf DateDiff(DateInterval.Weekday, TheTime, Now) = 1 Then
            Result &= "(last week)"
        ElseIf DateDiff(DateInterval.Day, TheTime, Now) = 1 Then
            Result &= "(yesterday)"
        ElseIf DateDiff(DateInterval.Day, TheTime, Now) > 1 Then
            Result &= "(" & DateDiff(DateInterval.Day, TheTime, Now) & " days ago)"
        ElseIf DateDiff(DateInterval.Hour, TheTime, Now) > 1 Then
            Result &= "(" & DateDiff(DateInterval.Hour, TheTime, Now) & " hours ago)"
        Else
            Result &= "(" & DateDiff(DateInterval.Minute, TheTime, Now) & " minutes ago)"
        End If
        Return Result
    End Function

    Public Function IsValidDate(ByVal TheDate As String, ByVal Culture As System.Globalization.CultureInfo) As DateTime
        Try
            Dim provider As System.IFormatProvider = Culture
            Return DateTime.Parse(TheDate, provider)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetJavascriptTimestamp(ByVal input As DateTime) As Long
        Dim Span As TimeSpan = New System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks)
        Dim T As DateTime = input.Subtract(Span)
        Return T.Ticks / 10000
    End Function

#End Region

End Class
