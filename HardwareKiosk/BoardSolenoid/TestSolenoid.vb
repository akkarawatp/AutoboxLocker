Imports System.Windows.Forms
Imports BoardSolenoid.Org.Mentalis.Files

Public Class TestSolenoid
    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Dim sol As New SolenoidClass

    Private Sub Sensor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        BindComport()
        Connect()
        sol.BindSolenoidPin(cbbPin)
    End Sub

    Sub BindComport()
        cbbComport.Items.Clear()
        cbbComport.Items.Add("")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbbComport.Items.Add(sp)
        Next

        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        cbbComport.SelectedIndex = cbbComport.FindStringExact(ini.ReadString("SolenoidComport"))
        ini = Nothing
    End Sub

    Sub Connect()
        If sol.ConnectSolenoidDevice(cbbComport.Text) = True Then
            BindpbStatus(True)
        Else
            BindpbStatus(False)
        End If
    End Sub


    Private Sub cbbComport_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cbbComport.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("SolenoidComport", cbbComport.Text)
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

    Private Sub btnSolenoidOpen_Click(sender As Object, e As EventArgs) Handles btnSolenoidOpen.Click
        sol.SolenoidOpen(cbbPin.SelectedValue)
    End Sub

    Private Sub cbbPin_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbbPin.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("SolenoidComport", cbbPin.SelectedValue.ToString)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        sol.SolenoidClose(cbbPin.SelectedValue)
    End Sub
End Class
