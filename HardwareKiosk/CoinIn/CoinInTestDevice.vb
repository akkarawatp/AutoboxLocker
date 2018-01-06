Imports System.Threading

Public Class CoinInTestDevice

    Dim CoinIn As New CoinInClass

    Private Sub CoinInTestDevice_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.DialogResult = DialogResult.OK
        CloseComport()
    End Sub

    Private Sub FormTestDevice_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        lblComport.Focus()
        Connect(lblComport.Text)
        CoinIn.BindCommand(cbb)
        CheckStatus()
    End Sub

    Sub OpenComport()
        Connect(lblComport.Text)
    End Sub

    Sub CloseComport()
        Connect("")
    End Sub

    Private Sub Connect(ByVal Comport As String)
        If CoinIn.ConnectCoinInDevice(Comport) = True Then
            btnOpenComport.BackColor = Drawing.Color.Gray
            btnCloseComport.BackColor = Drawing.Color.Red
            lblStatus.Text = "Status : Connected"
            lblStatus.ForeColor = Drawing.Color.Green
            pnlCommand.Enabled = True
            'AddHandler CoinIn.MySerialPort.DataReceived, AddressOf CoinIn.MySerialPortDataReceived
            AddHandler CoinIn.ReceiveEvent, AddressOf DataReceived
        Else
            btnOpenComport.BackColor = Drawing.Color.Green
            btnCloseComport.BackColor = Drawing.Color.Gray
            lblStatus.Text = "Status : Disconnected"
            lblStatus.ForeColor = Drawing.Color.Red
            pnlCommand.Enabled = False
            txtReceive.Text = ""
            txtSend.Text = ""
        End If
    End Sub

    Private Sub DataReceived(ByVal ReceiveData As String)
        If InStr(ReceiveData, "ReceiveCoin") > 0 Then
            ReceiveData = ReceiveData.Replace("ReceiveCoin", "").Trim()
            txtReceive.Text &= "ได้รับเหรียญ " & ReceiveData & " บาท" & vbCrLf
        ElseIf ReceiveData <> "" Then
            txtReceive.Text &= CoinIn.ParserStatusCommand(ReceiveData) & vbCrLf
        End If
    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenComport.Click
        If btnOpenComport.BackColor = Drawing.Color.Gray Then Exit Sub
        OpenComport()
    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseComport.Click
        If btnCloseComport.BackColor = Drawing.Color.Gray Then Exit Sub
        CloseComport()
    End Sub

    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        If txtSend.Text.Trim = "" Then
            MessageBox.Show("Please enter Send Command", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim DataSend As String = txtSend.Text
        txtReceive.Text = ""
        txtSend.Text = ""
        Application.DoEvents()
        Dim Msg As String = CoinIn.SendDataDeviceCoinIn(DataSend)
        If Msg <> "" Then
            txtReceive.Text = Msg
        End If
        If DataSend.Replace(" ", "") = "9005010399" Or DataSend.Replace(" ", "") = "900502039A" Then
            Thread.Sleep(500)
            CheckStatus()
        End If
    End Sub

    Private Sub cbb_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cbb.SelectionChangeCommitted
        Select Case cbb.SelectedIndex
            Case CoinIn.List_Command.Enable_Device
                txtSend.Text = "9005010399"
            Case CoinIn.List_Command.Disable_Device
                txtSend.Text = "900502039A"
            Case CoinIn.List_Command.Check_Status
                txtSend.Text = "90051103A9"
            Case CoinIn.List_Command.Get_Version_Firmware
                txtSend.Text = "900503039B"
            Case Else
                txtSend.Text = ""
        End Select
    End Sub

    Sub CheckStatus()
        Dim Msg As String = CoinIn.CheckStatusDeviceCoinIn()
        If Msg <> "" Then
            txtReceive.Text = Msg
        End If
    End Sub

End Class