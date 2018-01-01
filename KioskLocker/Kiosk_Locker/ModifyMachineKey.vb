Imports MiniboxLocker.Org.Mentalis.Files
Public Class ModifyMachineKey
    Private _ShowError As Boolean = False
    Private Const _BasePath As String = "C:\License\"
    Private Const _KeySection As String = "MachineKey"
    Private Const _LockerSection As String = "LockerInfo"
    Private Const _KeyFileName As String = _BasePath & "MiniboxMachineKey.ini"
    Private Const _MachineKey As String = "MachineKey"

    Public WriteOnly Property ShowError As Boolean
        Set(value As Boolean)
            _ShowError = value
        End Set
    End Property

    Public Function Read() As String
        Dim ret As String = ""
        Try
            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _KeySection
            ret = ini.ReadString(_MachineKey)
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "Reading Key " + _MachineKey.ToUpper())
        End Try

        Return ret
    End Function

    Public Function Write(KeyValue As String) As Boolean
        Dim ret As Boolean = False
        Try
            If IO.Directory.Exists(_BasePath) = False Then
                IO.Directory.CreateDirectory(_BasePath)
            End If

            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _KeySection
            ret = ini.Write(_MachineKey, KeyValue)
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "Writing Key " + _MachineKey.ToUpper())
        End Try
        Return ret
    End Function

#Region "Locker Info"
    Public Function ReadInfoKioskID() As Long
        Dim ret As Long = 0
        Try
            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _LockerSection
            ret = IIf(ini.ReadString("KioskID") = "", 0, ini.ReadString("KioskID"))
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "ReadInfoKioskID")
        End Try
        Return ret
    End Function
    Public Function ReadInfoIPAddress() As String
        Dim ret As String = ""
        Try
            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _LockerSection
            ret = ini.ReadString("IPAddress")
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "ReadInfoIPAddress")
        End Try
        Return ret
    End Function
    Public Function ReadInfoMacAddress() As String
        Dim ret As String = ""
        Try
            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _LockerSection
            ret = ini.ReadString("MacAddress")
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "ReadInfoMacAddress")
        End Try
        Return ret
    End Function
    Public Function ReadInfoLockerComName() As String
        Dim ret As String = ""
        Try
            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _LockerSection
            ret = ini.ReadString("LockerComName")
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "ReadInfoLockerComName")
        End Try
        Return ret
    End Function
    Public Function ReadInfoLocationCode() As String
        Dim ret As String = ""
        Try
            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _LockerSection
            ret = ini.ReadString("LocationCode")
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "ReadInfoLocationCode")
        End Try
        Return ret
    End Function
    Public Function ReadInfoLocationName() As String
        Dim ret As String = ""
        Try
            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _LockerSection
            ret = ini.ReadString("LocationName")
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "ReadInfoLocationName")
        End Try
        Return ret
    End Function

    Public Function WriteInfo(KioskID As Long, LockerComName As String, IpAddress As String, MacAddress As String, LocationCode As String, LocationName As String) As Boolean
        Dim ret As Boolean = False
        Try
            If IO.Directory.Exists(_BasePath) = False Then
                IO.Directory.CreateDirectory(_BasePath)
            End If

            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _LockerSection
            ret = ini.Write("IPAddress", IpAddress)
            If ret = True Then
                ret = ini.Write("MacAddress", MacAddress)
                If ret = True Then
                    ret = ini.Write("LockerComName", LockerComName)
                    If ret = True Then
                        ret = ini.Write("KioskID", KioskID)
                        If ret = True Then
                            ret = ini.Write("LocationCode", LocationCode)
                            If ret = True Then
                                ret = ini.Write("LocationName", LocationName)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ShowErrorMessage(ex, "Writing Info " + _MachineKey.ToUpper())
        End Try
        Return ret
    End Function

    Public Function DeleteInfoSection()
        Dim ret As Boolean = False
        Try
            Dim ini As New IniReader(_KeyFileName)
            ret = ini.DeleteSection(_LockerSection)
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "Deketing Info Section " + _LockerSection.ToUpper())
        End Try
        Return ret
    End Function
#End Region
    Public Function DeleteKey() As Boolean
        Dim ret As Boolean = False
        Try
            Dim ini As New IniReader(_KeyFileName)
            ini.Section = _KeySection
            ret = ini.DeleteKey(_MachineKey)
            ini = Nothing
        Catch ex As Exception
            ShowErrorMessage(ex, "Deketing Key " + _MachineKey.ToUpper())
        End Try

        Return ret
    End Function

    Private Sub ShowErrorMessage(e As Exception, Title As String)
        If _ShowError = True Then
            MessageBox.Show(e.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
