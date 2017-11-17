Imports System.Windows.Forms
Imports BoardSensor.Org.Mentalis.Files

Public Class TestSensor
    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Private Delegate Sub myDelegate(data As String)
    Private SensorStatus As myDelegate

    Dim Sensor As New SensorClass

    Private Sub Sensor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        BindComport()
        Connect()
        Sensor.BindSensorPin(cbbPin)

        SensorStatus = AddressOf DisplayStatus
    End Sub

    Private Sub DisplayStatus(data As String)
        TextBox1.Text = IIf(data.Trim = "0", "OPEN", "CLOSE")
        Application.DoEvents()
    End Sub

    Sub BindComport()
        cbbComport.Items.Clear()
        cbbComport.Items.Add("")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbbComport.Items.Add(sp)
        Next

        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        cbbComport.SelectedIndex = cbbComport.FindStringExact(ini.ReadString("SensorComport"))
        ini = Nothing
    End Sub

    Sub Connect()
        If Sensor.ConnectSensorDevice(cbbComport.Text) = True Then
            BindpbStatus(True)
        Else
            BindpbStatus(False)
        End If
    End Sub

    Private Sub SensorDataReceived(ByVal ReceiveData As String)
        If ReceiveData.Trim = "" Then Exit Sub
        '0=OPEN, 1=CLOSE
        'SensorStatus
        Me.Invoke(SensorStatus, ReceiveData)

        Sensor.SensorRequestData(cbbPin.SelectedValue)
    End Sub

    Private Sub cbbComport_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cbbComport.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("SensorComport", cbbComport.Text)
        Connect()
    End Sub

    Sub BindpbStatus(ByVal Status As Boolean)
        If Status = True Then
            lblStatus.Text = "Connected"
            lblStatus.ForeColor = Drawing.Color.Lime
        Else
            lblStatus.Text = "Disconnected"
            lblStatus.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Private Sub btnLeftStart_Click(sender As Object, e As EventArgs) Handles btnLeftStart.Click
        Sensor.SensorRequestData(cbbPin.SelectedValue)
        'AddHandler Sensor.MySerialPort.DataReceived, AddressOf Sensor.MySerialPortDataReceived
        AddHandler Sensor.SensorReceiveData, AddressOf SensorDataReceived

    End Sub

    Private Sub btnLeftStop_Click(sender As Object, e As EventArgs) Handles btnLeftStop.Click
        RemoveHandler Sensor.SensorReceiveData, AddressOf SensorDataReceived
    End Sub

    Private Sub cbbPin_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbbPin.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("SensorComport", cbbPin.SelectedValue.ToString)
    End Sub
End Class
