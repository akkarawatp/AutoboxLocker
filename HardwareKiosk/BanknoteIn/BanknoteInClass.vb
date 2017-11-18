
Imports System.IO.Ports
Imports System.Threading
Imports Engine.ConverterENG
Imports USBClassLibrary

Public Class BanknoteInClass

    Private MySerialPort As New SerialPort

    Public Enum List_Command
        Enable_Device = 1
        Disable_Device = 2
        Check_Status = 3
        Reset_Device = 4
    End Enum

    Public Enum List_ReceiveCommand
        Ready = 1
        Unavailable = 0
        Disconnected = 2
        Power_OFF = 3
        Motor_Failure = 4
        Checksum_Error = 5
        Bill_Jam = 6
        Bill_Remove = 7
        Stacker_Open = 8
        Sensor_Problem = 9
        Bill_Fish = 10
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
            Case List_ReceiveCommand.Power_OFF
                ret = "Power OFF"
            Case List_ReceiveCommand.Motor_Failure
                ret = "Motor Failure"
            Case List_ReceiveCommand.Checksum_Error
                ret = "Checksum Error"
            Case List_ReceiveCommand.Bill_Jam
                ret = "Bill Jam"
            Case List_ReceiveCommand.Bill_Remove
                ret = "Bill Remove"
            Case List_ReceiveCommand.Stacker_Open
                ret = "Stacker Open"
            Case List_ReceiveCommand.Sensor_Problem
                ret = "Sensor Problem"
            Case List_ReceiveCommand.Bill_Fish
                ret = "Bill Fish"
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
        cbb.Items.Insert(List_Command.Reset_Device, "Reset Device")
        cbb.SelectedIndex = 0
    End Sub

    Public Function EnableDeviceCashIn() As String
        Try
            SendDataDeviceCashIn("3E")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function DisableDeviceCashIn() As String
        Try
            SendDataDeviceCashIn("5E")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function CheckStatusDeviceCashIn() As String
        Try
            SendDataDeviceCashIn("0C")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ResetDeviceCashIn() As String
        Try
            SendDataDeviceCashIn("30")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function SendDataDeviceCashIn(ByVal data As String) As String
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




    Public Function ConnectBanknoteInDevice(ByVal Comport As String) As Boolean
        Try
            If MySerialPort.IsOpen Then MySerialPort.Close()
            MySerialPort.PortName = Comport
            MySerialPort.BaudRate = 9600
            MySerialPort.DataBits = 8
            MySerialPort.StopBits = IO.Ports.StopBits.One
            MySerialPort.DtrEnable = True
            MySerialPort.Parity = IO.Ports.Parity.Even
            MySerialPort.Open()

            AddHandler MySerialPort.DataReceived, AddressOf MySerialPortDataReceived
            Return True
        Catch ex As Exception
            If MySerialPort.IsOpen Then MySerialPort.Close()
            RemoveHandler MySerialPort.DataReceived, AddressOf MySerialPortDataReceived
            Return False
        End Try
    End Function

    Public Sub Disconnect()
        If MySerialPort.IsOpen Then MySerialPort.Close()
        RemoveHandler MySerialPort.DataReceived, AddressOf MySerialPortDataReceived
    End Sub

    Public Function ParserReceiveData(ByVal Hex As String) As String
        Select Case Hex.Replace("3F", "").Trim
            Case "80 8F"
                'จะได้รับมาตอนเปิดเครื่อง เราต้องส่ง 02 กลับไปเพื่อเริ่มใช้งานอุปกรณ์
                Dim str As String = "02"
                Dim Msg As String = SendDataDeviceCashIn(str)
                If Msg <> "" Then
                    Return Msg
                End If
                Thread.Sleep(400)
                Msg = SendDataDeviceCashIn(str)
                If Msg <> "" Then
                    Return Msg
                End If
                CheckStatusDeviceCashIn()
                Return ""
            Case "81 40"
                'ตอบ 02 กลับไปเพื่อยืนยันการรับแบงค์
                Dim str As String = "02"
                Dim Msg As String = SendDataDeviceCashIn(str)
                For i = 1 To 3
                    Thread.Sleep(100)
                    Msg = SendDataDeviceCashIn(str)
                    If Msg <> "" Then
                        Return Msg
                    End If
                Next
                Return "ReceiveCash 20"
            Case "81 41"
                'ตอบ 02 กลับไปเพื่อยืนยันการรับแบงค์
                Dim str As String = "02"
                Dim Msg As String = SendDataDeviceCashIn(str)
                For i = 1 To 3
                    Thread.Sleep(400)
                    Msg = SendDataDeviceCashIn(str)
                    If Msg <> "" Then
                        Return Msg
                    End If
                Next
                Return "ReceiveCash 50"
            Case "81 42"
                'ตอบ 02 กลับไปเพื่อยืนยันการรับแบงค์
                Dim str As String = "02"
                Dim Msg As String = SendDataDeviceCashIn(str)
                For i = 1 To 2
                    Thread.Sleep(400)
                    Msg = SendDataDeviceCashIn(str)
                    If Msg <> "" Then
                        Return Msg
                    End If
                Next
                Return "ReceiveCash 100"
            Case "81 43"
                'ตอบ 02 กลับไปเพื่อยืนยันการรับแบงค์
                Dim str As String = "02"
                Dim Msg As String = SendDataDeviceCashIn(str)
                For i = 1 To 2
                    Thread.Sleep(400)
                    Msg = SendDataDeviceCashIn(str)
                    If Msg <> "" Then
                        Return Msg
                    End If
                Next
                Return "ReceiveCash 500"
            Case "81 44"
                'ตอบ 02 กลับไปเพื่อยืนยันการรับแบงค์
                Dim str As String = "02"
                Dim Msg As String = SendDataDeviceCashIn(str)
                For i = 1 To 2
                    Thread.Sleep(400)
                    Msg = SendDataDeviceCashIn(str)
                    If Msg <> "" Then
                        Return Msg
                    End If
                Next
                Return "ReceiveCash 1000"
            Case "00"
                Return List_ReceiveCommand.Power_OFF
            Case "10"
                'รับธนบัตรเรียบร้อยแล้ว
                Return ""
            Case "20"
                Return List_ReceiveCommand.Motor_Failure
            Case "21"
                Return List_ReceiveCommand.Checksum_Error
            Case "22"
                Return List_ReceiveCommand.Bill_Jam
            Case "23"
                Return List_ReceiveCommand.Bill_Remove
            Case "24"
                Return List_ReceiveCommand.Stacker_Open
            Case "25"
                Return List_ReceiveCommand.Sensor_Problem
            Case "27"
                Return List_ReceiveCommand.Bill_Fish
            Case "29"
                'Bill Reject
                Return ""
            Case "2A"
                'Invalid Command
                Return ""
            Case "2E"
                'Reserved
                Return ""
            Case "2F"
                'Response when Error Status is Exclusion
                Return ""
            Case "3E"
                Return List_ReceiveCommand.Ready
            Case "5E"
                Return List_ReceiveCommand.Unavailable
            Case Else
                Return Hex.Trim
        End Select
    End Function

    Public Event ReceiveEvent(ByVal ReceiveData As String)
    Private Sub MySerialPortDataReceived()
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
