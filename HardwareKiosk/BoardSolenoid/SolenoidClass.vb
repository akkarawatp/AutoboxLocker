Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.Threading

Public Class SolenoidClass
    Private MySerialPort As New SerialPort

    Public Function ConnectSolenoidDevice(ByVal Comport As String) As Boolean
        Try
            If MySerialPort.IsOpen Then MySerialPort.Close()
            MySerialPort.PortName = Comport
            MySerialPort.BaudRate = 9600
            MySerialPort.Parity = Parity.None
            MySerialPort.StopBits = StopBits.One
            MySerialPort.DataBits = 8
            MySerialPort.Handshake = Handshake.None
            MySerialPort.Open()

            Return True
        Catch ex As Exception
            MySerialPort.Close()
            Return False
        End Try
    End Function

    Public Sub Disconnect()
        If MySerialPort.IsOpen Then MySerialPort.Close()
    End Sub

    Public Sub BindSolenoidPin(ByRef cbb As ComboBox)
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

        dt.Rows.Add("9", "10")
        dt.Rows.Add("10", "11")
        dt.Rows.Add("11", "12")
        dt.Rows.Add("12", "13")
        dt.Rows.Add("13", "14")
        dt.Rows.Add("14", "15")
        dt.Rows.Add("15", "16")
        dt.Rows.Add("16", "17")
        dt.Rows.Add("17", "18")
        dt.Rows.Add("18", "19")

        dt.Rows.Add("19", "20")
        dt.Rows.Add("20", "21")
        dt.Rows.Add("21", "22")
        dt.Rows.Add("22", "23")
        dt.Rows.Add("23", "24")
        dt.Rows.Add("24", "25")
        dt.Rows.Add("25", "26")
        dt.Rows.Add("26", "27")
        dt.Rows.Add("27", "28")
        dt.Rows.Add("28", "29")

        dt.Rows.Add("29", "30")
        dt.Rows.Add("30", "31")
        dt.Rows.Add("31", "32")
        dt.Rows.Add("32", "33")
        dt.Rows.Add("33", "34")
        dt.Rows.Add("34", "35")
        dt.Rows.Add("35", "36")
        dt.Rows.Add("36", "37")
        dt.Rows.Add("37", "38")
        dt.Rows.Add("38", "39")

        dt.Rows.Add("39", "40")
        dt.Rows.Add("40", "41")
        dt.Rows.Add("41", "42")
        dt.Rows.Add("42", "43")
        dt.Rows.Add("43", "44")
        dt.Rows.Add("44", "45")
        dt.Rows.Add("45", "46")
        dt.Rows.Add("46", "47")
        dt.Rows.Add("47", "48")
        dt.Rows.Add("48", "49")

        dt.Rows.Add("49", "50")
        dt.Rows.Add("50", "51")

        cbb.DataSource = dt
        cbb.SelectedIndex = 0
    End Sub


    Public Sub SolenoidOpen(_Pin As String)
        If _Pin = "" Then Exit Sub
        Try
            Dim data As Byte() = {_Pin, LED_Command.OPEN_Solenoid}
            If Not MySerialPort.IsOpen Then MySerialPort.Open()
            MySerialPort.Write(data, 0, data.Length)

        Catch ex As Exception
            'ถ้ามีปัญหาตอนสั่งเปิด ให้สั่งเปิดซ้ำอีกครั้ง
            Try
                System.Threading.Thread.Sleep(1000)
                Dim data As Byte() = {_Pin, LED_Command.OPEN_Solenoid}
                If Not MySerialPort.IsOpen Then MySerialPort.Open()
                MySerialPort.Write(data, 0, data.Length)
            Catch ex1 As Exception

            End Try

        End Try

        'สั่งเปิดค้างไวั 1 วิแล้วให้สั่งปิดทันที เดี๋ยวกลไกมันไหม้
        System.Threading.Thread.Sleep(1000)
        SolenoidClose(_Pin)
    End Sub

    Public Sub SolenoidClose(_Pin As String)
        If _Pin = "" Then Exit Sub

        Try
            Dim data As Byte() = {_Pin, LED_Command.Close_Solenoid}
            If Not MySerialPort.IsOpen Then MySerialPort.Open()
            MySerialPort.Write(data, 0, data.Length)
        Catch ex As Exception
            'ถ้ามีปัญหาตอนปิด Solenoid ให้สั่งปิดซ้ำอีกครั้ง
            Try
                System.Threading.Thread.Sleep(2000)
                Dim data As Byte() = {_Pin, LED_Command.Close_Solenoid}
                If Not MySerialPort.IsOpen Then MySerialPort.Open()
                MySerialPort.Write(data, 0, data.Length)
            Catch ex1 As Exception

            End Try
        End Try

    End Sub

    Private Enum LED_Command
        OPEN_Solenoid = 1
        Close_Solenoid = 0
    End Enum
End Class
