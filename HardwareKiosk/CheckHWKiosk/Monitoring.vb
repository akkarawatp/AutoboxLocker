Imports CoinIn.Org.Mentalis.Files

Public Class Monitoring
    Private WithEvents cam As New WebCamera.DSCamCapture
    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Private Sub Monitoring_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim ini As New IniReader(INIFileName)
        ini.Section = "CaptureSetting"
        cbCamera.Items.AddRange(cam.GetCaptureDevices)
        cbCamera.SelectedIndex = ini.ReadString("CameraIndex")
        ini = Nothing
    End Sub

    Private Sub cbCamera_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbCamera.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "CaptureSetting"
        ini.Write("CameraIndex", cbCamera.SelectedIndex)
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim CaptureApp As String = Application.StartupPath & "\WebCamera.exe"

        If IO.File.Exists(CaptureApp) = True Then
            pbCaptureImage.Image = Nothing

            Dim ini As New IniReader(INIFileName)
            ini.Section = "CaptureSetting"
            Dim ImageCapturePath As String = ini.ReadString("ImageCapturePath")
            If IO.Directory.Exists(ImageCapturePath) = False Then
                IO.Directory.CreateDirectory(ImageCapturePath)
            End If

            For Each f As String In IO.Directory.GetFiles(ImageCapturePath)
                Try
                    IO.File.Delete(f)
                Catch ex As Exception

                End Try
            Next

            Dim ImageFileName As String = DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim startInfo As New ProcessStartInfo
            startInfo.CreateNoWindow = False
            startInfo.UseShellExecute = False
            startInfo.FileName = CaptureApp
            startInfo.WindowStyle = ProcessWindowStyle.Hidden
            startInfo.Arguments = ImageFileName

            Try
                Using p As Process = Process.Start(startInfo)
                    p.WaitForExit()
                End Using

                If IO.File.Exists(ini.ReadString("ImageCapturePath") & ImageFileName & ".jpg") = True Then
                    ini.Section = "CaptureSetting"
                    pbCaptureImage.Image = Image.FromFile(ini.ReadString("ImageCapturePath") & ImageFileName & ".jpg")
                    pbCaptureImage.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            Catch ex As Exception

            End Try
            ini = Nothing
        End If
    End Sub
End Class

