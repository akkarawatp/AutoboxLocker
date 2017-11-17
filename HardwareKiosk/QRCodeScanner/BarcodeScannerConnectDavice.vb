Imports System.Windows.Forms
Imports QRCodeScanner.Org.Mentalis.Files

Public Class BarcodeScannerConnectDavice

    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"
    Dim CS As New QRCodeClass

    Private Sub txtVID_KeyUp(sender As Object, e As KeyEventArgs) Handles txtVID.KeyUp
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("QRCodeVID", txtVID.Text)
        ini = Nothing
        Connect()

    End Sub

    Sub Connect()
        Try
            If CS.ConnectQRCodeDevice(txtVID.Text) Then
                txtStatus.Text = "Ready"
                txtStatus.ForeColor = Drawing.Color.Lime
                Exit Sub
            End If
        Catch ex As Exception : End Try
        txtStatus.Text = "Disconnected"
        txtStatus.ForeColor = Drawing.Color.Red
    End Sub

    Private Sub BarcodeScannerConnectDavice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        txtVID.Text = ini.ReadString("QRCodeVID")
        txtVID.Enabled = True
        ini = Nothing
        Connect()
    End Sub
End Class
