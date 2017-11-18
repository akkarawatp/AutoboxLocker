Imports BanknoteIn.Org.Mentalis.Files
Imports System.Threading
Imports USBClassLibrary

Public Class BanknoteInConnectDevice

    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"
    Dim BanknoteIn As New BanknoteInClass

    Private Sub FormConnectDevice_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        BindSetting()
        Connect()
    End Sub

    Private Sub DataReceived(ByVal ReceiveData As String)
        If InStr(ReceiveData, "ReceiveCash") > 0 Then
            If lb.Items.Count = 3 Then
                lb.Items.RemoveAt(2)
            End If
            ReceiveData = ReceiveData.Replace("ReceiveCash", "").Trim()
            Dim Time As String = Date.Now.Hour.ToString.PadLeft(2, "0") + ":" + Date.Now.Minute.ToString.PadLeft(2, "0") + ":" + Date.Now.Second.ToString.PadLeft(2, "0")
            lb.Items.Insert(0, Time & "   " & "ได้รับธนบัตร " & ReceiveData & " บาท")
        ElseIf ReceiveData <> "" Then
            txtStatus.Text = BanknoteIn.ParserStatusCommand(ReceiveData)
            If ReceiveData = BanknoteIn.List_ReceiveCommand.Ready Or ReceiveData = BanknoteIn.List_ReceiveCommand.Unavailable Then
                txtStatus.ForeColor = Drawing.Color.Lime
            Else
                txtStatus.ForeColor = Drawing.Color.Red
            End If
        End If

    End Sub

    Sub BindSetting()
        cbComport.Items.Clear()
        cbComport.Items.Add("")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbComport.Items.Add(sp)
        Next

        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        cbComport.SelectedIndex = cbComport.FindStringExact(ini.ReadString("CashInComport"))

        ini = Nothing
    End Sub

    Private Sub cbbComport_MouseCaptureChanged(sender As Object, e As System.EventArgs)
        BindSetting()
    End Sub

    Private Sub Connect()
        If BanknoteIn.ConnectBanknoteInDevice(cbComport.Text) = True Then
            'AddHandler BanknoteIn.MySerialPort.DataReceived, AddressOf BanknoteIn.MySerialPortDataReceived
            AddHandler BanknoteIn.ReceiveEvent, AddressOf DataReceived
            BindpbStatus(True)
        Else
            txtStatus.Text = ""
            BindpbStatus(False)
        End If
    End Sub

    Private Sub BindpbStatus(ByVal Status As Boolean)
        If Status = True Then
            CheckStatus()
            txtStatus.Text = BanknoteIn.ParserStatusCommand(BanknoteIn.List_ReceiveCommand.Ready)
        Else
            txtStatus.Text = BanknoteIn.ParserStatusCommand(BanknoteIn.List_ReceiveCommand.Disconnected)
            txtStatus.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        'If txtStatus.Text <> Cashin.ParserErrorText(Cashin.List_ReceiveCommand.Ready) And txtStatus.Text <> Cashin.ParserErrorText(Cashin.List_ReceiveCommand.Unavailable) Then
        '    MessageBox.Show("การเชื่อมต่ออุปกรณ์มีปัญหา !!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        BanknoteIn.Disconnect()

        Dim f As New BanknoteInTestDevice
        f.lblHead.Text = lblHead.Text
        f.lblComport.Text = cbComport.Text
        If f.ShowDialog() = DialogResult.OK Then
            If BanknoteIn.ConnectBanknoteInDevice(cbComport.Text) = True Then
                BindpbStatus(True)
            Else
                txtStatus.Text = ""
                BindpbStatus(False)
            End If
        End If
    End Sub

    Public Sub CheckStatus()
        Dim Msg As String = BanknoteIn.CheckStatusDeviceCashIn
        If Msg <> "" Then
            txtStatus.Text = Msg
        End If
    End Sub

    Public Sub EnableDevice()
        Dim Msg As String = BanknoteIn.EnableDeviceCashIn
        If Msg <> "" Then
            txtStatus.Text = Msg
        End If
    End Sub

    Public Sub DisableDevice()
        Dim Msg As String = BanknoteIn.DisableDeviceCashIn

        If Msg <> "" Then
            txtStatus.Text = Msg
        End If
    End Sub

    Private Sub cbComport_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbComport.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("CashINComport", cbComport.Text)
        cbComport.SelectedIndex = cbComport.FindStringExact(ini.ReadString("CashInComport"))
        ini = Nothing
        Connect()
    End Sub
End Class
