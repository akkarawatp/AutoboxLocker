Imports System.Management
Imports Printer.Org.Mentalis.Files
Imports PrinterClassDll

Public Class PrinterClass

    'Dim INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Public Enum PrinterStatus
        Online = 1
        Unknow = 2
        Offline = 3
    End Enum
    Public Function CheckPrinterStatus(PrinterName As String) As String
        Try
            Dim scope As New ManagementScope("\root\cimv2")
            scope.Connect()
            ' Select Printers from WMI Object Collections 
            Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Printer")
            Dim MyPrinter As String = ""
            For Each printer As ManagementObject In searcher.[Get]()
                MyPrinter = printer("Name").ToString().ToLower()
                If MyPrinter.Equals(PrinterName.ToLower) Then
                    If printer("WorkOffline").ToString().ToLower().Equals("true") Then
                        ' printer is offline by user 
                        Return PrinterStatus.Offline
                    Else
                        ' printer is not offline 
                        Return PrinterStatus.Online
                    End If
                End If
            Next
        Catch ex As Exception : End Try
        Return PrinterStatus.Unknow
        'Dim prn As New PrinterClassDll.Win32Print
        'prn.SetPrinterName(PrinterName)
    End Function

    'Public Function PrintConfirmationSlipNewSim(PrinterName As String, ByVal CompanyName As String, ByVal Location As String, ByVal ConfirmationNo As String, ByVal SimValue As String, ByVal TopUpValue As String, ByVal MobileNo As String, ByVal TopupReceiptNo As String, ByVal SimReceiptNo As String) As Boolean
    '    Try
    '        Dim prn As New PrinterClassDll.Win32Print
    '        prn.SetPrinterName(PrinterName)
    '        prn.PrintText(" ")
    '        prn.SetDeviceFont(10.5, "FontA1x1", True, False)
    '        prn.PrintText("  WIRELESS Device Supply Co.,LTD.")
    '        prn.SetDeviceFont(9.5, "FontA1x1", True, False)
    '        prn.PrintText("                 Confirmation Slip")
    '        prn.PrintText(" ")
    '        prn.PrintText("Date: " & IIf(Now.Date.Year > 2500, Now.Date.Year - 543, Now.Date.Year) & Now.Date.ToString("-MM-dd"))
    '        prn.PrintText("Time: " & Now.ToString("hh:mm:ss tt"))
    '        prn.PrintText("Location: " & Location)
    '        prn.PrintText("TransectionNo.: " & ConfirmationNo)
    '        prn.PrintText("----------------------------------")
    '        prn.PrintText("Traveller SIM")
    '        prn.PrintText("Mobile Number " & MobileNo & "      " & SetLengthValue(SimValue) & " Bath")
    '        prn.SetDeviceFont(8, "FontA1x1", True, False)
    '        prn.PrintText("(Reference Receipt no.: xxxxxxxxxx)")
    '        prn.SetDeviceFont(9.5, "FontA1x1", True, False)
    '        prn.PrintText(" ")
    '        prn.PrintText("Top Up                                     " & SetLengthValue(TopUpValue) & " Bath")
    '        prn.SetDeviceFont(8, "FontA1x1", True, False)
    '        prn.PrintText("(Reference Receipt no.: xxxxxxxxxx)")
    '        prn.SetDeviceFont(9.5, "FontA1x1", True, False)
    '        prn.PrintText(" ")
    '        prn.PrintText("Total Payment                         " & SetLengthValue(CStr(CInt(SimValue) + CInt(TopUpValue))) & " Bath")
    '        prn.PrintText(" ")
    '        prn.PrintText("            Thank you for using AIS")
    '        prn.EndDoc()
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function SetLengthValue(ByVal Value As String) As String
    '    Select Case Value.Length
    '        Case 1
    '            Value = "   " + Value
    '        Case 2
    '            Value = "  " + Value
    '        Case 3
    '            Value = " " + Value
    '    End Select
    '    Return Value
    'End Function

    'Public Function PrintConfirmationSlipTopUp(PrinterName As String, ByVal CompanyName As String, ByVal Location As String, ByVal ConfirmationNo As String, ByVal TopUpValue As String, ByVal MobileNo As String, ByVal TopupReceiptNo As String) As Boolean
    '    Try
    '        Dim prn As New PrinterClassDll.Win32Print
    '        prn.SetPrinterName(PrinterName)
    '        prn.PrintText(" ")
    '        prn.SetDeviceFont(10.5, "FontA1x1", True, False)
    '        prn.PrintText("  WIRELESS Device Supply Co.,LTD.")
    '        prn.SetDeviceFont(9.5, "FontA1x1", True, False)
    '        prn.PrintText("                 Confirmation Slip")
    '        prn.PrintText(" ")
    '        prn.PrintText("Date: " & IIf(Now.Date.Year > 2500, Now.Date.Year - 543, Now.Date.Year) & Now.Date.ToString("-MM-dd"))
    '        prn.PrintText("Time: " & Now.ToString("hh:mm:ss tt"))
    '        prn.PrintText("Location: " & Location)
    '        prn.PrintText("TransectionNo.: " & ConfirmationNo)
    '        prn.PrintText("----------------------------------")
    '        prn.PrintText("Mobile Number " & MobileNo)
    '        prn.PrintText("Top Up                                     " & SetLengthValue(TopUpValue) & " Bath")
    '        prn.SetDeviceFont(8, "FontA1x1", True, False)
    '        prn.PrintText("(Reference Receipt no.: " & TopupReceiptNo & ")")
    '        prn.SetDeviceFont(9.5, "FontA1x1", True, False)
    '        prn.PrintText(" ")
    '        prn.PrintText("Total Payment                         " & SetLengthValue(TopUpValue) & " Bath")
    '        prn.PrintText(" ")
    '        prn.PrintText("            Thank you for using AIS")
    '        prn.EndDoc()
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
End Class
