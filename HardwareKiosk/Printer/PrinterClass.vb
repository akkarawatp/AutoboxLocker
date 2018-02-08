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

End Class
