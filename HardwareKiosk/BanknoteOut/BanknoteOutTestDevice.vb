Imports System.Threading

Public Class BanknoteOutTestDevice

    Dim BanknoteOut As New BanknoteOutClass

    Private Sub CoinInTestDevice_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.DialogResult = DialogResult.OK
        BanknoteOut.Disconnect()
    End Sub

    Private Sub FormTestDevice_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        lblComport.Focus()
        OpenComport()
        BanknoteOut.BindCommand(cbb)
        CheckStatus()
    End Sub

    Sub OpenComport()
        Connect(lblComport.Text)
    End Sub

    Sub CloseComport()
        Connect("")
    End Sub

    Private Sub Connect(ByVal Comport As String)
        If BanknoteOut.ConnectBanknoteOutDevice(Comport) = True Then
            btnOpenComport.BackColor = Drawing.Color.Gray
            btnCloseComport.BackColor = Drawing.Color.Red
            lblStatus.Text = "Status : Connected"
            lblStatus.ForeColor = Drawing.Color.Green
            pnlCommand.Enabled = True
            AddHandler BanknoteOut.MySerialPort.DataReceived, AddressOf BanknoteOut.MySerialPortDataReceived
            AddHandler BanknoteOut.ReceiveEvent, AddressOf BanknoteOutDataReceived
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

    Private Sub BanknoteOutDataReceived(ByVal ReceiveData As String)
        Try
            txtReceive.Text &= BanknoteOut.ParserStatusCommand(ReceiveData) & vbCrLf
        Catch ex As Exception

        End Try

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
        Dim Msg As String = BanknoteOut.SendDataDeviceCashOut(DataSend)
        If Msg <> "" Then
            txtReceive.Text = Msg
        End If

        If DataSend.Replace(" ", "") <> "011000110022" Then
            Thread.Sleep(500)
            CheckStatus()
        End If
    End Sub

    Private Sub cbb_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cbb.SelectionChangeCommitted
        Select Case cbb.SelectedIndex
            Case BanknoteOut.List_Command.Check_Status
                txtSend.Text = "011000110022"
            Case BanknoteOut.List_Command.Reset_Device
                txtSend.Text = "011000120023"
            Case Else
                txtSend.Text = ""
        End Select
    End Sub

    Sub CheckStatus()
        Dim Msg As String = BanknoteOut.CheckStatusDeviceCashOut()
        If Msg <> "" Then
            txtReceive.Text = Msg
        End If
    End Sub

    Private Sub btnSelectCommand_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectCommand.Click
        txtSend.Text = BanknoteOut.GetPayCashOutCommand(nud.Value)
    End Sub
End Class