Imports CoinIn.Org.Mentalis.Files
Imports System.Threading
Imports System.IO.Ports

Public Class CoinInConnectDevice

    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"
    Dim CoinIn As New CoinInClass

    Private Sub FormConnectDevice_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        BindSetting()
        Connect(cbComport.Text)
    End Sub

    Private Sub BindSetting()
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"

        cbComport.Items.Clear()
        cbComport.Items.Add("")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbComport.Items.Add(sp)
        Next
        cbComport.SelectedIndex = cbComport.FindStringExact(ini.ReadString("CoinINComport"))
        ini = Nothing
    End Sub

    Public Event US_ReceiveEvent(ByVal ReceiveData As String)
    Private Sub DataReceived(ByVal ReceiveData As String)
        If InStr(ReceiveData, "ReceiveCoin") > 0 Then
            If lb.Items.Count = 3 Then
                lb.Items.RemoveAt(2)
            End If
            ReceiveData = ReceiveData.Replace("ReceiveCoin", "").Trim()
            Dim Time As String = Date.Now.Hour.ToString.PadLeft(2, "0") + ":" + Date.Now.Minute.ToString.PadLeft(2, "0") + ":" + Date.Now.Second.ToString.PadLeft(2, "0")
            lb.Items.Insert(0, Time & "   " & "ได้รับเหรียญ " & ReceiveData & " บาท")
        ElseIf ReceiveData <> "" Then
            txtStatus.Text = CoinIn.ParserStatusCommand(ReceiveData)
            If ReceiveData = CoinIn.List_ReceiveCommand.Ready Or ReceiveData = CoinIn.List_ReceiveCommand.Unavailable Then
                txtStatus.ForeColor = Drawing.Color.Lime
            Else
                txtStatus.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub


    Private Sub Connect(ByVal Comport As String)
        If CoinIn.ConnectCoinInDevice(Comport) = True Then
            AddHandler CoinIn.MySerialPort.DataReceived, AddressOf CoinIn.MySerialPortDataReceived
            AddHandler CoinIn.ReceiveEvent, AddressOf DataReceived
            BindpbStatus(True)
        Else
            txtStatus.Text = ""
            BindpbStatus(False)
        End If
    End Sub

    Private Sub BindpbStatus(ByVal Status As Boolean)
        If Status = True Then
            CheckStatus()
        Else
            txtStatus.Text = CoinIn.ParserStatusCommand(CoinIn.List_ReceiveCommand.Disconnected)
            txtStatus.ForeColor = Drawing.Color.Red
        End If
    End Sub



    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        'If txtStatus.Text <> CoinIn.ParserErrorText(CoinIn.List_ReceiveCommand.Ready) And txtStatus.Text <> CoinIn.ParserErrorText(CoinIn.List_ReceiveCommand.Unavailable) Then
        '    MessageBox.Show("การเชื่อมต่ออุปกรณ์มีปัญหา !!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        CoinIn.Disconnect()
        Dim f As New CoinInTestDevice
        f.lblHead.Text = lblHead.Text
        f.lblComport.Text = cbComport.Text
        If f.ShowDialog() = DialogResult.OK Then
            If CoinIn.ConnectCoinInDevice(cbComport.Text) = True Then
                BindpbStatus(True)
            Else
                txtStatus.Text = ""
                BindpbStatus(False)
            End If
        End If
    End Sub

    Public Sub CheckStatus()
        Dim Msg As String = CoinIn.CheckStatusDeviceCoinIn()
        If Msg <> "" Then
            txtStatus.Text = Msg
        End If
    End Sub

    Public Sub EnableDevice()
        Dim Msg As String = CoinIn.EnableDeviceCoinIn()

        If Msg <> "" Then
            txtStatus.Text = Msg
        End If
    End Sub

    Public Sub DisableDevice()
        Dim Msg As String = CoinIn.DisableDeviceCoinIn()

        If Msg <> "" Then
            txtStatus.Text = Msg
        End If
    End Sub

    Private Sub cbComport_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbComport.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("CoinINComport", cbComport.Text)
        cbComport.SelectedIndex = cbComport.FindStringExact(ini.ReadString("CoinINComport"))
        Connect(cbComport.Text)
    End Sub
End Class
