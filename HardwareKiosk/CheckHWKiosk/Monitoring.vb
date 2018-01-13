Imports CoinIn.Org.Mentalis.Files
Imports WebCamera

Public Class Monitoring
    Private WithEvents cam As New WebCamera.DSCamCapture
    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"
    Private TmpPb As PictureBox

    Private Sub Monitoring_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim ini As New IniReader(INIFileName)
        ini.Section = "CaptureSetting"
        cbCamera.Items.AddRange(cam.GetCaptureDevices)
        cbCamera.SelectedIndex = ini.ReadString("CameraIndex")
        ini = Nothing

        cam = New DSCamCapture
    End Sub

    Private Sub cbCamera_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbCamera.SelectionChangeCommitted
        Dim ini As New IniReader(INIFileName)
        ini.Section = "CaptureSetting"
        ini.Write("CameraIndex", cbCamera.SelectedIndex)
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        If TimerCheckCamera.Enabled = False Then
            TmpPb = New PictureBox
            Try
                Dim si As Integer = DSCamCapture.FrameSizes.s640x480
                Dim SelectedSize As DSCamCapture.FrameSizes = CType(si, DSCamCapture.FrameSizes)
                If cam.ConnectToDevice(cbCamera.SelectedIndex, 10, TmpPb.ClientSize, SelectedSize, TmpPb.Handle) = True Then
                    AddHandler cam.FrameCaptured, AddressOf WebcamFrameCaptured
                    cam.Start()

                    TimerCheckCamera.Enabled = True
                    TimerCheckCamera.Start()
                End If
            Catch ex As Exception

            End Try
            btnTest.BackgroundImage = My.Resources.buttonStop
        Else
            cam.Dispose()
            TimerCheckCamera.Enabled = False
            TimerCheckCamera.Stop()
            btnTest.BackgroundImage = My.Resources.buttonPlay
        End If
        Application.DoEvents()
    End Sub

    Private Sub WebcamFrameCaptured(capImage As Bitmap)
        pbCaptureImage.Image = capImage
    End Sub
    Private Sub TimerCheckCamera_Tick(sender As Object, e As EventArgs) Handles TimerCheckCamera.Tick
        cam.GetCurrentFrame()

        ''TimerCheckCamera.Enabled = False

        'Dim CaptureApp As String = Application.StartupPath & "\WebCamera.exe"

        'If IO.File.Exists(CaptureApp) = True Then
        '    pbCaptureImage.Image = Nothing

        '    Dim ini As New IniReader(INIFileName)
        '    ini.Section = "CaptureSetting"
        '    Dim ImageCapturePath As String = ini.ReadString("ImageCapturePath")
        '    If IO.Directory.Exists(ImageCapturePath) = False Then
        '        IO.Directory.CreateDirectory(ImageCapturePath)
        '    End If

        '    For Each f As String In IO.Directory.GetFiles(ImageCapturePath)
        '        Try
        '            IO.File.Delete(f)
        '        Catch ex As Exception

        '        End Try
        '    Next

        '    Dim ImageFileName As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        '    Dim startInfo As New ProcessStartInfo
        '    startInfo.CreateNoWindow = False
        '    startInfo.UseShellExecute = False
        '    startInfo.FileName = CaptureApp
        '    startInfo.WindowStyle = ProcessWindowStyle.Hidden
        '    startInfo.Arguments = ImageFileName

        '    Try
        '        Using p As Process = Process.Start(startInfo)
        '            p.WaitForExit()
        '        End Using

        '        If IO.File.Exists(ini.ReadString("ImageCapturePath") & ImageFileName & ".jpg") = True Then
        '            ini.Section = "CaptureSetting"
        '            pbCaptureImage.Image = Image.FromFile(ini.ReadString("ImageCapturePath") & ImageFileName & ".jpg")
        '            pbCaptureImage.SizeMode = PictureBoxSizeMode.StretchImage
        '        End If
        '    Catch ex As Exception

        '    End Try
        '    ini = Nothing
        'End If


        ''TimerCheckCamera.Enabled = True
    End Sub
End Class

