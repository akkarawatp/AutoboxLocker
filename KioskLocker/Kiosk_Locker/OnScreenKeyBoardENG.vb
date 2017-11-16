Public Class OnScreenKeyBoardENG

    Private Shared oskProcess As Process

    Public Shared Sub OpenKeyboard()
        If oskProcess Is Nothing OrElse oskProcess.HasExited Then
            If oskProcess IsNot Nothing AndAlso oskProcess.HasExited Then
                oskProcess.Close()
            End If
            oskProcess = Process.Start("osk")
        End If
    End Sub

    Public Shared Sub CloseKeyboard()
        'If oskProcess IsNot Nothing Then
        '    If oskProcess.HasExited Then
        '        'CloseMainWindow would generally be preferred but the OSK doesn't respond.
        '        oskProcess.Kill()
        '    End If
        '    oskProcess.Close()
        '    oskProcess = Nothing
        'End If

        For Each p As Process In Process.GetProcessesByName("osk")
            p.Kill()
        Next
    End Sub


End Class
