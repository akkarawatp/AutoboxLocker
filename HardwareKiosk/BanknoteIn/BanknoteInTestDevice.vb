Imports System.Threading

Public Class BanknoteInTestDevice

    Dim BanknoteIn As New BanknoteInClass

    Private Sub CashInTestDevice_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.DialogResult = DialogResult.OK
        CloseComport()
    End Sub

    Private Sub FormTestDevice_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        lblComport.Focus()
        Connect(lblComport.Text)
        BanknoteIn.BindCommand(cbb)
        CheckStatus()
    End Sub

    Sub OpenComport()
        Connect(lblComport.Text)
    End Sub

    Sub CloseComport()
        Connect("")
    End Sub

    Private Sub Connect(ByVal Comport As String)
        If BanknoteIn.ConnectBanknoteInDevice(Comport) = True Then
            btnOpenComport.BackColor = Drawing.Color.Gray
            btnCloseComport.BackColor = Drawing.Color.Red
            lblStatus.Text = "Status : Connected"
            lblStatus.ForeColor = Drawing.Color.Green
            pnlCommand.Enabled = True
            'AddHandler BanknoteIn.MySerialPort.DataReceived, AddressOf BanknoteIn.MySerialPortDataReceived
            AddHandler BanknoteIn.ReceiveEvent, AddressOf DataReceived
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
        If InStr(ReceiveData, "ReceiveCash") > 0 Then
            ReceiveData = ReceiveData.Replace("ReceiveCash", "").Trim()
            txtReceive.Text &= "ได้รับธนบัตร " & ReceiveData & " บาท" & vbCrLf
        ElseIf ReceiveData <> "" Then
            txtReceive.Text &= BanknoteIn.ParserStatusCommand(ReceiveData) & vbCrLf
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

        Application.DoEvents()
        Dim Msg As String = BanknoteIn.SendDataDeviceCashIn(DataSend)
        If Msg <> "" Then
            txtReceive.Text = Msg
        End If

        If txtSend.Text = "3E" Or txtSend.Text = "5E" Or txtSend.Text = "30" Then
            Thread.Sleep(500)
            CheckStatus()
        End If
        txtSend.Text = ""
    End Sub

    Private Sub cbb_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cbb.SelectionChangeCommitted
        Select Case cbb.SelectedIndex
            Case BanknoteIn.List_Command.Enable_Device
                txtSend.Text = "3E"
            Case BanknoteIn.List_Command.Disable_Device
                txtSend.Text = "5E"
            Case BanknoteIn.List_Command.Check_Status
                txtSend.Text = "0C"
            Case BanknoteIn.List_Command.Reset_Device
                txtSend.Text = "30"
            Case Else
                txtSend.Text = ""
        End Select
    End Sub

    Sub CheckStatus()
        Dim Msg As String = BanknoteIn.CheckStatusDeviceCashIn()
        If Msg <> "" Then
            txtReceive.Text = Msg
        End If
    End Sub
End Class