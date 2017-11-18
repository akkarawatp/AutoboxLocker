Imports CashOut.Org.Mentalis.Files
Imports System.IO.Ports
Imports Engine.ConverterENG
Imports System.Threading

Public Class BanknoteOutClass

    Public MySerialPort As New SerialPort
    '    Dim INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Public Enum List_Command
        Check_Status = 1
        Reset_Device = 2
    End Enum

    Public Enum List_ReceiveCommand
        Ready = 1
        Disconnected = 2
        Single_machine_payout = 3
        Multiple_machine_payout = 4
        Payout_Successful = 5
        Payout_fails = 6
        Empty_note = 7
        Stock_less = 8
        Note_jam = 9
        Over_length = 10
        Note_Not_Exit = 11
        Sensor_Error = 12
        Double_note_error = 13
        Motor_Error = 14
        Dispensing_busy = 15
        Sensor_adjusting = 16
        Checksum_Error = 17
        Low_power_Error = 18
    End Enum

    Function ParserStatusCommand(ReceiveCommandID As List_ReceiveCommand)
        Dim ret As String = ""
        Select Case ReceiveCommandID
            Case List_ReceiveCommand.Ready
                ret = "Ready"
            Case List_ReceiveCommand.Disconnected
                ret = "Disconnected"
            Case List_ReceiveCommand.Single_machine_payout
                ret = "Single machine payout"
            Case List_ReceiveCommand.Multiple_machine_payout
                ret = "Multiple machine payout"
            Case List_ReceiveCommand.Payout_Successful
                ret = "Payout Successful"
            Case List_ReceiveCommand.Payout_fails
                ret = "Payout fails"
            Case List_ReceiveCommand.Empty_note
                ret = "Empty note"
            Case List_ReceiveCommand.Stock_less
                ret = "Stock less"
            Case List_ReceiveCommand.Note_jam
                ret = "Note jam"
            Case List_ReceiveCommand.Over_length
                ret = "Over length"
            Case List_ReceiveCommand.Note_Not_Exit
                ret = "Note not exit"
            Case List_ReceiveCommand.Sensor_Error
                ret = "Sensor error"
            Case List_ReceiveCommand.Double_note_error
                ret = "Double note error"
            Case List_ReceiveCommand.Motor_Error
                ret = "Motor error"
            Case List_ReceiveCommand.Dispensing_busy
                ret = "Dispensing busy"
            Case List_ReceiveCommand.Sensor_adjusting
                ret = "Sensor adjusting"
            Case List_ReceiveCommand.Checksum_Error
                ret = "Checksum error"
            Case List_ReceiveCommand.Low_power_Error
                ret = "Low power error"
            Case Else
                ret = ReceiveCommandID
        End Select
        Return ret
    End Function

    Public Sub BindCommand(ByRef cbb As ComboBox)
        cbb.Items.Clear()
        cbb.Items.Insert(0, "------- Select -------")
        cbb.Items.Insert(List_Command.Check_Status, "Check Status")
        cbb.Items.Insert(List_Command.Reset_Device, "Reset Device")
        cbb.SelectedIndex = 0
    End Sub

    Public Function CheckStatusDeviceCashOut() As String
        Try
            SendDataDeviceCashOut("011000110022")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function RefreshDeviceCashOut() As String
        Try
            SendDataDeviceCashOut("011000120023")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function PayCashOut(ByVal Num As Int32) As String
        Try
            Dim Count As String = Hex(Num).PadLeft(2, "0")
            Dim Sum As String = Hex(Num + 33).PadLeft(2, "0")
            Dim str As String = "01100010xxyy"
            str = str.Replace("xx", Count).Replace("yy", Sum)
            SendDataDeviceCashOut(str)
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function GetPayCashOutCommand(ByVal Num As Int32) As String
        Try
            Dim Count As String = Hex(Num).PadLeft(2, "0")
            Dim Sum As String = Hex(Num + 33).PadLeft(2, "0")
            Dim str As String = "01100010xxyy"
            str = str.Replace("xx", Count).Replace("yy", Sum)
            Return str
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function SendDataDeviceCashOut(ByVal data As String) As String
        Try
            Thread.Sleep(100)
            If Not MySerialPort.IsOpen Then MySerialPort.Open()
            Dim txt As String = data.Replace(" ", "")
            Dim b As Byte() = ConvertHexToBytes(txt)
            MySerialPort.Write(b, 0, b.Length)
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    'Public Function ConnectDevice(ByVal Comport As String) As Boolean
    '    Try
    '        If MySerialPort.IsOpen Then MySerialPort.Close()
    '        MySerialPort.PortName = Comport
    '        MySerialPort.BaudRate = 9600
    '        MySerialPort.DataBits = 8
    '        MySerialPort.StopBits = IO.Ports.StopBits.One
    '        MySerialPort.DtrEnable = True
    '        MySerialPort.Parity = IO.Ports.Parity.Even
    '        MySerialPort.Open()
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Public Function ConnectBanknoteOutDevice(ByVal Comport As String) As Boolean
        Try
            If MySerialPort.IsOpen Then MySerialPort.Close()
            MySerialPort.PortName = Comport
            MySerialPort.BaudRate = 9600
            MySerialPort.DataBits = 8
            MySerialPort.StopBits = IO.Ports.StopBits.One
            MySerialPort.DtrEnable = True
            MySerialPort.Parity = IO.Ports.Parity.Even
            MySerialPort.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub Disconnect()
        ConnectBanknoteOutDevice("")
    End Sub
    Public Function ParserReceiveData(ByVal Hex As String) As String
        If Hex = "" Then Return ""
        For i As Integer = 0 To MySerialPort.BytesToRead - 1
            Dim d As Integer = MySerialPort.ReadByte
            Dim b(0) As Byte
            b(0) = d
            Hex &= BytesToHexString(b) & " "
        Next

        If Hex.Length >= 8 Then
            Select Case Hex.Trim.Replace(" ", "").Substring(0, 8)
                Case "01 10 00 10".Replace(" ", "")
                    Return List_ReceiveCommand.Single_machine_payout
                Case "01 10 01 13".Replace(" ", "")
                    Return List_ReceiveCommand.Multiple_machine_payout
                Case "01 01 00 AA".Replace(" ", "")
                    Return List_ReceiveCommand.Payout_Successful
                Case "01 01 00 BB".Replace(" ", "")
                    Return List_ReceiveCommand.Payout_fails
                Case "01 01 00 00".Replace(" ", "")
                    Return List_ReceiveCommand.Ready
                Case "01 01 00 01".Replace(" ", "")
                    Return List_ReceiveCommand.Empty_note
                Case "01 01 00 02".Replace(" ", "")
                    Return List_ReceiveCommand.Stock_less
                Case "01 01 00 03".Replace(" ", "")
                    Return List_ReceiveCommand.Note_jam
                Case "01 01 00 04".Replace(" ", "")
                    Return List_ReceiveCommand.Over_length
                Case "01 01 00 05".Replace(" ", "")
                    Return List_ReceiveCommand.Note_Not_Exit
                Case "01 01 00 06".Replace(" ", "")
                    Return List_ReceiveCommand.Sensor_Error
                Case "01 01 00 07".Replace(" ", "")
                    Return List_ReceiveCommand.Double_note_error
                Case "01 01 00 08".Replace(" ", "")
                    Return List_ReceiveCommand.Motor_Error
                Case "01 01 00 09".Replace(" ", "")
                    Return List_ReceiveCommand.Dispensing_busy
                Case "01 01 00 0A".Replace(" ", "")
                    Return List_ReceiveCommand.Sensor_adjusting
                Case "01 01 00 0B".Replace(" ", "")
                    Return List_ReceiveCommand.Checksum_Error
                Case "01 01 00 0C".Replace(" ", "")
                    Return List_ReceiveCommand.Low_power_Error
                Case Else
                    Return Hex.Trim
            End Select
        End If
        Return ""
    End Function

    Public Event ReceiveEvent(ByVal ReceiveData As String)
    Public Sub MySerialPortDataReceived()
        Thread.Sleep(100)
        Try
            Dim Hex As String = ""
            For i As Integer = 0 To MySerialPort.BytesToRead - 1
                Dim d As Integer = MySerialPort.ReadByte
                Dim b(0) As Byte
                b(0) = d
                Hex &= BytesToHexString(b) & " "
            Next

            Dim ReceiveData As String = ParserReceiveData(Hex)
            RaiseEvent ReceiveEvent(ReceiveData)
        Catch ex As Exception

        End Try
    End Sub
End Class
