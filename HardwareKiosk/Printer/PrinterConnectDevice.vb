﻿Imports System.Drawing.Printing
Imports Printer.Org.Mentalis.Files
Imports System.IO

Public Class PrinterConnectDevice

    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"
    Dim Printer As New PrinterClass

    Private Sub PrinterConnectDevice_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim pkInstalledPrinters As String = ""
        cbbPrinter.Items.Add("")
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            cbbPrinter.Items.Add(pkInstalledPrinters)
        Next

        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        cbbPrinter.SelectedIndex = cbbPrinter.FindStringExact(ini.ReadString("Printer"))
        CheckStatusPrinter()

        'Dim MS As New ManagementObjectSearcher("SELECT * FROM Win32_diskdrive where interfacetype = 'USB'")

        'Dim DeviceID As String = ""
        'For Each MD As ManagementObject In MS.Get()
        '    For Each Data As PropertyData In MD.Properties
        '         cbbPrinter.Items.Add(Convert.ToString(Data.Value))
        '    Next
        'Next

        'Dim com1 As IO.Ports.SerialPort = Nothing
        'com1 = My.Computer.Ports.OpenSerialPort("COM3")
    End Sub

    Private Sub cbbPrinter_SelectionChangeCommitted1(sender As Object, e As System.EventArgs) Handles cbbPrinter.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("Printer", cbbPrinter.Text)
        CheckStatusPrinter()
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        'If txtStatus.Text = "Offline" Then
        '    MessageBox.Show("กรุณาเชื่อมต่ออุปกรณ์ !!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        Dim f As New PrinterTestDevice
        f.lblHead.Text = "Printer " & cbbPrinter.Text
        f.lblPrinterName.Text = cbbPrinter.Text

        If f.ShowDialog() = DialogResult.OK Then
            CheckStatusPrinter()
        End If
    End Sub

    Sub CheckStatusPrinter()
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("Printer", cbbPrinter.Text)

        txtStatus.Text = Printer.CheckPrinterStatus(cbbPrinter.Text)
        Select Case txtStatus.Text
            Case Printer.PrinterStatus.Online
                txtStatus.Text = "Online"
                txtStatus.ForeColor = Color.Lime
            Case Printer.PrinterStatus.Offline
                txtStatus.Text = "Offline"
                txtStatus.ForeColor = Color.Red
            Case Else
                txtStatus.Text = "Unknow"
                txtStatus.ForeColor = Color.Red
        End Select
        'Dim engine As CustomPrinterEngine = New CustomPrinterEngine(cbbPrinter.Text)
        'engine.getPaperStatus()
        'Dim a As String = ""
    End Sub


End Class
