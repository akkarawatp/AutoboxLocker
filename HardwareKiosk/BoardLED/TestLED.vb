Imports System.Windows.Forms
Imports BoardLED.Org.Mentalis.Files

Public Class TestLED
    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Dim LED As New LEDClass
    'Dim SensorIDValue As Integer

    '

    Private Sub Sensor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        BindComport()
        Connect()
        LED.BindLEDPin(cbbPin)
    End Sub

    Sub BindComport()
        cbbComport.Items.Clear()
        cbbComport.Items.Add("")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbbComport.Items.Add(sp)
        Next

        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"

        cbbComport.SelectedIndex = cbbComport.FindStringExact(ini.ReadString("LEDComport"))
        ini = Nothing
    End Sub

    Sub Connect()
        If LED.ConnectLEDDevice(cbbComport.Text) = True Then
            BindpbStatus(True)
        Else
            BindpbStatus(False)
        End If
    End Sub


    Private Sub cbbComport_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cbbComport.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("LEDComport", cbbComport.Text)
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
        LED.LEDStart(cbbPin.SelectedValue)
    End Sub

    Private Sub btnLeftStop_Click(sender As Object, e As EventArgs) Handles btnLeftStop.Click
        LED.LEDStop(cbbPin.SelectedValue)
    End Sub

    Private Sub cbbPin_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbbPin.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("LEDComport", cbbPin.SelectedValue.ToString)
    End Sub

    Private Sub btnBlink_Click(sender As Object, e As EventArgs) Handles btnBlink.Click
        LED.LEDBlinkOn(cbbPin.SelectedValue)
    End Sub
End Class
