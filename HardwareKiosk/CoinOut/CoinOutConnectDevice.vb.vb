Imports CoinOut.Org.Mentalis.Files

Public Class CoinOutConnectDevice

    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"
    Dim CoinOut As New CoinOutClass
    Dim _CoinValue As Integer
    Dim CoinIDValue As Integer

    Public Property CoinValue() As Integer
        Get
            Return _CoinValue
        End Get
        Set(ByVal value As Integer)
            _CoinValue = value
            lblHead.Text = "Coin Out " & _CoinValue
        End Set
    End Property

    Public Property CoinID() As Integer
        Get
            Return CoinIDValue
        End Get
        Set(ByVal value As Integer)
            CoinIDValue = value
        End Set
    End Property

    Private Sub FormConnectDevice_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        BindSetting()
        Connect(cbComport.Text)
    End Sub

    Private Sub DataReceived(ByVal ReceiveData As String)
        'กรณีถ้าเครื่องไม่มีเงิน แล้วเพิ่งใส่เงินมา จะได้รับ Enable BA, if hopper problems recovered ซึ่งแปลว่าเครื่องพร้อมใช้งานแล้ว
        If ReceiveData = "" Then Exit Sub
        ReceiveData = CoinOut.ParserStatusCommand(ReceiveData)
        If ReceiveData = "Ready" Or ReceiveData = "Enable BA, if hopper problems recovered" Then
            txtStatus.Text = "Ready"
            txtStatus.ForeColor = Drawing.Color.Lime
        Else
            txtStatus.Text = ReceiveData
            txtStatus.ForeColor = Drawing.Color.Red
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
        cbComport.SelectedIndex = cbComport.FindStringExact(ini.ReadString("CoinOut" & _CoinValue & "Comport"))
        ini = Nothing
    End Sub

    Private Sub cbbComport_MouseCaptureChanged(sender As Object, e As System.EventArgs)
        BindSetting()
    End Sub

    Sub Connect(ByVal Comport As String)
        If CoinOut.ConnectCoinOutDevice(Comport) = True Then
            AddHandler CoinOut.MySerialPort.DataReceived, AddressOf CoinOut.MySerialPortDataReceived
            AddHandler CoinOut.ReceiveEvent, AddressOf DataReceived
            BindpbStatus(True)
        Else
            txtStatus.Text = ""
            BindpbStatus(False)
        End If
    End Sub

    Sub BindpbStatus(ByVal Status As Boolean)
        If Status = True Then
            CheckStatus()
        Else
            txtStatus.Text = "Disconnected"
            txtStatus.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Private Sub cbbComport_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        'If txtStatus.Text = "Disconnected" Then
        '    MessageBox.Show("กรุณาเชื่อมต่ออุปกรณ์ !!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        Dim f As New CoinOutTestDevice
        f.lblHead.Text = "Coin Out " & _CoinValue
        f.lblComport.Text = cbComport.Text
        CoinOut.Disconnect()
        If f.ShowDialog() = DialogResult.OK Then
            If CoinOut.ConnectCoinOutDevice(cbComport.Text) = True Then
                BindpbStatus(True)
            Else
                txtStatus.Text = ""
                BindpbStatus(False)
            End If
        End If
    End Sub

    Public Sub CheckStatus()
        Dim Msg As String = CoinOut.CheckStatusDeviceCoinOut()
        If Msg <> "" Then
            txtStatus.Text = Msg
        End If
    End Sub

    Private Sub cbComport_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbComport.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("CoinOut" & _CoinValue & "Comport", cbComport.Text)
        cbComport.SelectedIndex = cbComport.FindStringExact(ini.ReadString("CoinOut" & _CoinValue & "Comport"))
        Connect(cbComport.Text)
    End Sub
End Class
