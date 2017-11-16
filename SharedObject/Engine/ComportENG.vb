Imports USBClassLibrary
Public Class ComportENG
    Public Shared Function GetComportByVID(VID As String) As String
        Dim ret As String = ""
        Try
            Dim USBPort As New USBClass
            Dim ListOfUSBDeviceProperties As New List(Of USBClass.DeviceProperties)()
            If USBClass.GetUSBDevice(VID, "", ListOfUSBDeviceProperties, True) = True Then
                ret = ListOfUSBDeviceProperties.Item(0).COMPort
            End If

        Catch ex As Exception
            ret = ""
        End Try
        Return ret
    End Function
End Class
