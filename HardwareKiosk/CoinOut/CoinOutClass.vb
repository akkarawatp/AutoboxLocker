Imports CoinOut.Org.Mentalis.Files
Imports System.IO.Ports
Imports Engine.ConverterENG
Imports System.Threading

Public Class CoinOutClass

    Public MySerialPort As New SerialPort
    'Dim INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Public Enum List_Command
        Check_Status = 1
        Reset_Device = 2
    End Enum

    Public Enum List_ReceiveCommand
        Ready = 1
        Disconnected = 2
        Enable_BA_if_hopper_problems_recovered = 3
        Inhibit_BA_if_hopper_problems_occurred = 4
        Mortor_Problem = 5
        Insufficient_Coin = 6
        Dedects_coin_dispensing_activity_after_suspending_the_dispene_signal = 7
        Reserved = 8
        Prism_Sersor_Failure = 9
        Shaft_Sersor_Failure = 10
    End Enum

    Function ParserStatusCommand(ReceiveCommandID As List_ReceiveCommand)
        Dim ret As String = ""
        Select Case ReceiveCommandID
            Case List_ReceiveCommand.Ready
                ret = "Ready"
            Case List_ReceiveCommand.Disconnected
                ret = "Disconnected"
            Case List_ReceiveCommand.Enable_BA_if_hopper_problems_recovered
                ret = "Enable BA, if hopper problems recovered"
            Case List_ReceiveCommand.Inhibit_BA_if_hopper_problems_occurred
                ret = "Inhibit BA, if hopper problems occurred"
            Case List_ReceiveCommand.Mortor_Problem
                ret = "Mortor Problem"
            Case List_ReceiveCommand.Insufficient_Coin
                ret = "Insufficient Coin"
            Case List_ReceiveCommand.Dedects_coin_dispensing_activity_after_suspending_the_dispene_signal
                ret = "Dedects coin dispensing activity after suspending the dispene signal"
            Case List_ReceiveCommand.Reserved
                ret = "Reserved"
            Case List_ReceiveCommand.Prism_Sersor_Failure
                ret = "Prism Sersor Failure"
            Case List_ReceiveCommand.Shaft_Sersor_Failure
                ret = "Shaft Sersor Failure"
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

    Public Function CheckStatusDeviceCoinOut() As String
        Try
            SendDataDeviceCoinOut("70")
            SendDataDeviceCoinOut("72")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ResetDeviceCoinOut() As String
        Try
            SendDataDeviceCoinOut("70")
            SendDataDeviceCoinOut("73")
            SendDataDeviceCoinOut("80")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function PayCoinOut(ByVal Num As Int32) As String
        Try
            Dim Pay As String = ""
            Select Case Num - 1
                Case 10
                    Pay = "a"
                Case 11
                    Pay = "b"
                Case 12
                    Pay = "c"
                Case 13
                    Pay = "d"
                Case 14
                    Pay = "e"
                Case 15
                    Pay = "f"
                Case Else
                    Pay = Num - 1
            End Select
            Dim Count As String = "4" & Pay
            Dim str As String = "81xx"
            str = str.Replace("xx", Count)
            SendDataDeviceCoinOut(str)
            SendDataDeviceCoinOut("10")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function GetPayCoinOutCommand(ByVal Num As Int32) As String
        Try
            Dim Pay As String = ""
            Select Case Num - 1
                Case 10
                    Pay = "a"
                Case 11
                    Pay = "b"
                Case 12
                    Pay = "c"
                Case 13
                    Pay = "d"
                Case 14
                    Pay = "e"
                Case 15
                    Pay = "f"
                Case Else
                    Pay = Num - 1
            End Select
            Dim Count As String = "4" & Pay

            Dim str As String = "81xx"
            str = str.Replace("xx", Count)
            Return str
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

    '        ''ส่ง 808f เพือ่ให้ Device เริ่มทำงาน
    '        'SendDataDeviceCoinOut("808f")
    '        'SendDataDeviceCoinOut("72")
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Public Function ConnectCoinOutDevice(ByVal Comport As String) As Boolean
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
        ConnectCoinOutDevice("")
    End Sub

    Public Function ParserReceiveData(ByVal Hex As String) As String
        For i As Integer = 0 To MySerialPort.BytesToRead - 1
            Dim d As Integer = MySerialPort.ReadByte
            Dim b(0) As Byte
            b(0) = d
            Hex &= BytesToHexString(b) & " "
        Next

        '12 คือ เครื่องทอนเงินตอบกลับมาเพื่อให้เราส่ง Command อื่นเข้าไปต่อ ซึ่งไม่จำเป็นต้องแสดง
        Select Case Hex.Replace("12", "").Trim
            Case ""
                Return ""
            Case "00"
                Return List_ReceiveCommand.Ready
            Case "3E"
                'Enable BA, if hopper problems recovered
                Return List_ReceiveCommand.Enable_BA_if_hopper_problems_recovered
            Case "5E" '
                'Inhibit BA, if hopper problems occurred
                Return List_ReceiveCommand.Inhibit_BA_if_hopper_problems_occurred
            Case "01"
                Return List_ReceiveCommand.Mortor_Problem
            Case "02"
                Return List_ReceiveCommand.Insufficient_Coin
            Case "03"
                Return List_ReceiveCommand.Dedects_coin_dispensing_activity_after_suspending_the_dispene_signal
            Case "04"
                Return List_ReceiveCommand.Reserved
            Case "05"
                Return List_ReceiveCommand.Prism_Sersor_Failure
            Case "06"
                Return List_ReceiveCommand.Shaft_Sersor_Failure
            Case Else
                Return Hex.Trim
        End Select
    End Function

    Public Event ReceiveEvent(ByVal ReceiveData As String)
    Public Sub MySerialPortDataReceived()
        Thread.Sleep(100)
        Dim Hex As String = ""
        Try
            If Not MySerialPort.IsOpen Then MySerialPort.Open()
            For i As Integer = 0 To MySerialPort.BytesToRead - 1
                Dim d As Integer = MySerialPort.ReadByte
                Dim b(0) As Byte
                b(0) = d
                Hex &= BytesToHexString(b) & " "
            Next
        Catch ex As Exception : End Try
        Dim ReceiveData As String = ParserReceiveData(Hex)
        RaiseEvent ReceiveEvent(ReceiveData)
    End Sub

    Public Function SendDataDeviceCoinOut(ByVal data As String) As String
        Try
            If Not MySerialPort.IsOpen Then MySerialPort.Open()
            Dim txt As String = data.Replace(" ", "")
            Dim b As Byte() = ConvertHexToBytes(txt)
            Thread.Sleep(500)
            MySerialPort.Write(b, 0, b.Length)
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
End Class
