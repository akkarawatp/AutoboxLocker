Imports CoinIn.Org.Mentalis.Files
Imports System.IO.Ports
Imports Engine.ConverterENG
Imports System.Threading

Public Class CoinInClass

    Public MySerialPort As New SerialPort
    'Dim INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Public Enum List_Command
        Enable_Device = 1
        Disable_Device = 2
        Check_Status = 3
        Get_Version_Firmware = 4
    End Enum

    Public Enum List_ReceiveCommand
        Ready = 1
        Unavailable = 0
        Disconnected = 2
        Sersor_1_Problem = 3
        Sersor_2_Problem = 4
        Sersor_3_Problem = 5
    End Enum

    Function ParserStatusCommand(ReceiveCommandID As List_ReceiveCommand)
        Dim ret As String = ""
        Select Case ReceiveCommandID
            Case List_ReceiveCommand.Ready
                ret = "Ready"
            Case List_ReceiveCommand.Unavailable
                ret = "Unavailable"
            Case List_ReceiveCommand.Disconnected
                ret = "Disconnected"
            Case List_ReceiveCommand.Sersor_1_Problem
                ret = "Sersor 1 Problem"
            Case List_ReceiveCommand.Sersor_2_Problem
                ret = "Sersor 2 Problem"
            Case List_ReceiveCommand.Sersor_3_Problem
                ret = "Sersor 3 Problem"
            Case Else
                ret = ReceiveCommandID
        End Select
        Return ret
    End Function

    Public Sub BindCommand(ByRef cbb As ComboBox)
        cbb.Items.Clear()
        cbb.Items.Insert(0, "------- Select -------")
        cbb.Items.Insert(List_Command.Enable_Device, "Enable Device")
        cbb.Items.Insert(List_Command.Disable_Device, "Disable Device")
        cbb.Items.Insert(List_Command.Check_Status, "Check Status")
        cbb.Items.Insert(List_Command.Get_Version_Firmware, "Get Version Firmware")
        cbb.SelectedIndex = 0
    End Sub

    Public Function EnableDeviceCoinIn() As String
        Try
            SendDataDeviceCoinIn("9005010399")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function DisableDeviceCoinIn() As String
        Try
            SendDataDeviceCoinIn("900502039A")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function CheckStatusDeviceCoinIn() As String
        Try
            SendDataDeviceCoinIn("90051103A9")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function GetVersionFirmware() As String
        Try
            SendDataDeviceCoinIn("900503039B")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function SendDataDeviceCoinIn(ByVal data As String) As String
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

    Public Function ParserReceiveData(ByVal Hex As String) As String
        Select Case Hex.Trim
            Case "90 06 12 01 03 AC"
                Return "ReceiveCoin 1"
            Case "90 06 12 06 03 B1"
                Return "ReceiveCoin 1"
            Case "90 06 12 02 03 AD"
                Return "ReceiveCoin 2"
            Case "90 06 12 05 03 B0"
                Return "ReceiveCoin 2"
            Case "90 06 12 03 03 AE"
                Return "ReceiveCoin 5"
            Case "90 06 12 04 03 AF"
                Return "ReceiveCoin 10"
            Case "90 05 50 03 E8"
                Return ""
            Case "90 05 11 03 A9"
                Return List_ReceiveCommand.Ready
            Case "90 05 14 03 AC"
                Return List_ReceiveCommand.Unavailable
            Case "90 06 16 01 03 B0"
                Return List_ReceiveCommand.Sersor_1_Problem
            Case "90 06 16 02 03 B1"
                Return List_ReceiveCommand.Sersor_2_Problem
            Case "90 06 16 03 03 B2"
                Return List_ReceiveCommand.Sersor_3_Problem
            Case Else
                Return Hex.Trim
        End Select
    End Function

    Public Function ConnectCoinInDevice(ByVal Comport As String) As Boolean
        Try
            If MySerialPort.IsOpen Then MySerialPort.Close()
            MySerialPort.PortName = Comport
            MySerialPort.BaudRate = 9600
            MySerialPort.DataBits = 8
            MySerialPort.StopBits = IO.Ports.StopBits.One
            MySerialPort.DtrEnable = True
            MySerialPort.Parity = IO.Ports.Parity.None
            MySerialPort.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub Disconnect()
        If MySerialPort.IsOpen Then MySerialPort.Close()
    End Sub

    Public Event ReceiveEvent(ByVal ReceiveData As String)

    Public Sub MySerialPortDataReceived()
        Try
            Thread.Sleep(100)
            Dim Hex As String = ""
            For i As Integer = 0 To MySerialPort.BytesToRead - 1
                Dim d As Integer = MySerialPort.ReadByte
                Dim b(0) As Byte
                b(0) = d
                Hex &= BytesToHexString(b) & " "
            Next
            Dim ReceiveData As String = ParserReceiveData(Hex)
            RaiseEvent ReceiveEvent(ReceiveData)
        Catch ex As Exception : End Try

    End Sub
End Class
