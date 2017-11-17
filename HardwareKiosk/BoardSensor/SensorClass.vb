Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.Threading

Public Class SensorClass

    Public MySerialPort As New SerialPort


    Public Function ConnectSensorDevice(ByVal Comport As String) As Boolean
        Try
            If MySerialPort.IsOpen Then MySerialPort.Close()
            MySerialPort.PortName = Comport
            MySerialPort.BaudRate = 9600
            MySerialPort.Parity = Parity.None
            MySerialPort.StopBits = StopBits.One
            MySerialPort.DataBits = 8
            MySerialPort.Handshake = Handshake.None
            MySerialPort.Open()

            AddHandler MySerialPort.DataReceived, AddressOf MySerialPortDataReceived

            Return True
        Catch ex As Exception
            MySerialPort.Close()
            Return False
        End Try
    End Function

    Public Sub Disconnect()
        If MySerialPort.IsOpen Then MySerialPort.Close()
    End Sub

    Public Sub BindSensorPin(ByRef cbb As ComboBox)
        cbb.Items.Clear()
        cbb.DisplayMember = "Text"
        cbb.ValueMember = "Value"
        Dim dt As New DataTable
        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("--- Select ---", 0)
        dt.Rows.Add("1", "2")
        dt.Rows.Add("2", "3")
        dt.Rows.Add("3", "4")
        dt.Rows.Add("4", "5")
        dt.Rows.Add("5", "6")
        dt.Rows.Add("6", "7")
        dt.Rows.Add("7", "8")
        dt.Rows.Add("8", "9")

        dt.Rows.Add("9", ":")
        dt.Rows.Add("10", ";")
        dt.Rows.Add("11", "<")
        dt.Rows.Add("12", "=")
        dt.Rows.Add("13", ">")
        dt.Rows.Add("14", "?")
        dt.Rows.Add("15", "@")
        dt.Rows.Add("16", "A")
        dt.Rows.Add("17", "B")
        dt.Rows.Add("18", "C")

        dt.Rows.Add("19", "D")
        dt.Rows.Add("20", "E")
        dt.Rows.Add("21", "F")
        dt.Rows.Add("22", "G")
        dt.Rows.Add("23", "H")
        dt.Rows.Add("24", "I")
        dt.Rows.Add("25", "J")
        dt.Rows.Add("26", "K")
        dt.Rows.Add("27", "L")
        dt.Rows.Add("28", "M")

        dt.Rows.Add("29", "N")
        dt.Rows.Add("30", "O")
        dt.Rows.Add("31", "P")
        dt.Rows.Add("32", "Q")
        dt.Rows.Add("33", "R")
        dt.Rows.Add("34", "S")
        dt.Rows.Add("35", "T")
        dt.Rows.Add("36", "U")
        dt.Rows.Add("37", "V")
        dt.Rows.Add("38", "W")

        dt.Rows.Add("39", "X")
        dt.Rows.Add("40", "Y")
        dt.Rows.Add("41", "Z")
        dt.Rows.Add("42", "[")
        dt.Rows.Add("43", "\")
        dt.Rows.Add("44", "]")
        dt.Rows.Add("45", "^")
        dt.Rows.Add("46", "_")
        dt.Rows.Add("47", "'")
        dt.Rows.Add("48", "a")

        dt.Rows.Add("49", "b")
        dt.Rows.Add("50", "c")

        cbb.DataSource = dt
        cbb.SelectedIndex = 0
    End Sub

    Public Event SensorReceiveData(ByVal ReceiveData As String)
    Private Sub MySerialPortDataReceived()
        Try
            Dim Hex As String = ""
            Hex = MySerialPort.ReadExisting()

            If Hex.Trim.Length > 1 Then
                Hex = Hex.Substring(0, 1)
            End If

            RaiseEvent SensorReceiveData(Hex)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SensorRequestData(ByVal Pin As String)
        Try
            Thread.Sleep(200)
            Dim data As Byte() = System.Text.Encoding.ASCII.GetBytes(Pin)
            MySerialPort.Write(data, 0, data.Length)
        Catch ex As Exception
            CreateSensorTextErrorLog(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CreateSensorTextErrorLog(LogMsg As String)
        Try
            Dim frame As StackFrame = New StackFrame(1, True)
            Dim ClassName As String = frame.GetMethod.ReflectedType.Name
            Dim FunctionName As String = frame.GetMethod.Name
            Dim LineNo As Integer = frame.GetFileLineNumber

            Dim MY As String = DateTime.Now.ToString("yyyyMM")
            Dim DD As String = DateTime.Now.ToString("dd")
            Dim LogFolder As String = Application.StartupPath & "\SensorLog\" & MY & "\" & DD & "\"
            If System.IO.Directory.Exists(LogFolder) = False Then
                System.IO.Directory.CreateDirectory(LogFolder)
            End If

            Dim FileName As String = LogFolder & ClassName & "_" & DateTime.Now.ToString("yyyyMMddHH") & ".txt"
            Dim obj As New System.IO.StreamWriter(FileName, True)
            obj.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & " " & FunctionName & " Line No :" & LineNo & Environment.NewLine & LogMsg & Environment.NewLine & Environment.NewLine)
            obj.Flush()
            obj.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
