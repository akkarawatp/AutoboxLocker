Imports System.Threading

Public Class CoinOutTestDevice

    Dim CoinOut As New CoinOutClass

    Private Sub CoinInTestDevice_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.DialogResult = DialogResult.OK
        CoinOut.Disconnect()
    End Sub

    Private Sub FormTestDevice_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        lblComport.Focus()
        OpenComport()
        CoinOut.BindCommand(cbb)

    End Sub

    Sub OpenComport()
        Connect(lblComport.Text)
    End Sub

    Sub CloseComport()
        Connect("")
    End Sub

    Private Sub Connect(ByVal Comport As String)
        If CoinOut.ConnectCoinOutDevice(Comport) = True Then
            btnOpenComport.BackColor = Drawing.Color.Gray
            btnCloseComport.BackColor = Drawing.Color.Red
            lblStatus.Text = "Status : Connected"
            lblStatus.ForeColor = Drawing.Color.Green
            pnlCommand.Enabled = True
            AddHandler CoinOut.MySerialPort.DataReceived, AddressOf CoinOut.MySerialPortDataReceived
            AddHandler CoinOut.ReceiveEvent, AddressOf DataReceived
            CoinOut.ResetDeviceCoinOut()
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
        'กรณีมีการทอนเหรียญ Coin Out จะส่ง Command 02 , 3E , 5E มา ทำให้การแปลความหมายสับสน 
        '02 = Insufficient Coin
        '3E = Enable BA, if hopper problems recovered
        '5E = Inhibit BA, if hopper problems occurred
        'จึงไม่แสดงข้อความพวกนี้ ซึ่งอาจทำให้เกิดความสับสนได้
        If ReceiveData = "" Then Exit Sub
        Try
            ReceiveData = CoinOut.ParserStatusCommand(ReceiveData)
            Select Case ReceiveData
                Case "Insufficient Coin", "Enable BA, if hopper problems recovered", "Inhibit BA, if hopper problems occurred"
                    Exit Sub
            End Select
        Catch ex As Exception : End Try

        If ReceiveData <> "" Then
            txtReceive.Text &= ReceiveData & vbCrLf
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

        Dim cmd() As String = DataSend.Split("|")
        For i As Int32 = 0 To cmd.Length - 1
            Dim Msg As String = CoinOut.SendDataDeviceCoinOut(cmd(i))
            If Msg <> "" Then
                txtReceive.Text = Msg
            End If
        Next

        'If DataSend.Replace(" ", "") <> "70|72" Then
        '    Thread.Sleep(1000)
        '    CheckStatus()
        'End If
    End Sub

    Private Sub cbb_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cbb.SelectionChangeCommitted
        Select Case cbb.SelectedIndex
            Case CoinOut.List_Command.Check_Status
                txtSend.Text = "70|72"
            Case CoinOut.List_Command.Reset_Device
                txtSend.Text = "70|73|80"
            Case Else
                txtSend.Text = ""
        End Select
    End Sub

    Sub CheckStatus()
        Dim Msg As String = CoinOut.CheckStatusDeviceCoinOut()
        If Msg <> "" Then
            txtReceive.Text = Msg
        End If
    End Sub

    Private Sub btnSelectCommand_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectCommand.Click
        'txtSend.Text = CoinOut.GetPayCoinOutCommand(nud.Value)
        CoinOut.PayCoinOut(nud.Value)
    End Sub

End Class