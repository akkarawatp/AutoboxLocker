Imports QRCodeScanner.Org.Mentalis.Files
Imports System.Windows.Forms
Imports USBClassLibrary

Public Class QRCodeClass

    'Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Public Function ConnectQRCodeDevice(VID As String)
        Try
            Dim USBPort As New USBClass
            Dim ListOfUSBDeviceProperties As New List(Of USBClass.DeviceProperties)()
            Dim MyUSBDeviceConnected As Boolean = False
            If USBClass.GetUSBDevice(VID, "", ListOfUSBDeviceProperties, True) = True Then
                Return True
            End If
        Catch ex As Exception : End Try
        Return False
    End Function
End Class
