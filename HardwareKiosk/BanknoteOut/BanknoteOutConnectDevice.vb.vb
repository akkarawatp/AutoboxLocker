
Imports BanknoteOut.Org.Mentalis.Files

Public Class CashOutConnectDevice

    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"
    Dim BanknoteOut As New BanknoteOutClass
    Dim _CashValue As Integer
    Dim CashIDValue As Integer

    Public Property CashValue() As Integer
        Get
            Return _CashValue
        End Get
        Set(ByVal value As Integer)
            _CashValue = value
            lblHead.Text = "Cash Out " & _CashValue
        End Set
    End Property

    Public Property CashID() As Integer
        Get
            Return CashIDValue
        End Get
        Set(ByVal value As Integer)
            CashIDValue = value
        End Set
    End Property

    Private Sub FormConnectDevice_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        BindSetting()
        Connect(cbComport.Text)
    End Sub

    Private Sub DataReceived(ByVal ReceiveData As String)
        If ReceiveData = "" Then Exit Sub
        ReceiveData = BanknoteOut.ParserStatusCommand(ReceiveData)
        If ReceiveData = "Ready" Then
            txtStatus.Text = ReceiveData
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
        cbComport.SelectedIndex = cbComport.FindStringExact(ini.ReadString("CashOut" & _CashValue & "Comport"))
        ini = Nothing
    End Sub


    Sub Connect(ByVal Comport As String)
        If BanknoteOut.ConnectBanknoteOutDevice(Comport) = True Then
            AddHandler BanknoteOut.MySerialPort.DataReceived, AddressOf BanknoteOut.MySerialPortDataReceived
            AddHandler BanknoteOut.ReceiveEvent, AddressOf DataReceived
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

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        'If txtStatus.Text <> "Ready" Then
        '    MessageBox.Show("การเชื่อมต่ออุปกรณ์มีปัญหา !!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        Dim f As New BanknoteOutTestDevice
        f.lblHead.Text = "Cash Out " & _CashValue
        f.lblComport.Text = cbComport.Text
        BanknoteOut.Disconnect()
        If f.ShowDialog() = DialogResult.OK Then
            If BanknoteOut.ConnectBanknoteOutDevice(cbComport.Text) = True Then
                BindpbStatus(True)
            Else
                txtStatus.Text = ""
                cbComport.Text = ""
                BindpbStatus(False)
            End If
        End If
    End Sub

    Private Sub CheckStatus()
        Dim Msg As String = BanknoteOut.CheckStatusDeviceCashOut()
        If Msg <> "" Then
            txtStatus.Text = Msg
            cbComport.Text = ""
        End If
    End Sub

    Private Sub cbComport_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbComport.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("CashOut" & _CashValue & "Comport", cbComport.Text)
        cbComport.SelectedIndex = cbComport.FindStringExact(ini.ReadString("CashOut" & _CashValue & "Comport"))
        Connect(cbComport.Text)
        ini = Nothing
    End Sub
End Class
