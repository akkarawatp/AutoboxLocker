Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports ImageCapture.Org.Mentalis.Files

Public Class frmImageCapture
    Private WithEvents cam As New DSCamCapture


    Private Sub TestImageCapture_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()

            If My.Application.CommandLineArgs.Count > 0 Then
                Dim DepositTransNo As String = My.Application.CommandLineArgs.Item(0).ToString

                Dim ini As New IniReader(Application.StartupPath & "\ConfigDevice.ini")
                ini.Section = "CaptureSetting"
                Dim CamIndex As Integer = ini.ReadInteger("CameraIndex")
                Dim ImageCapturePath As String = ini.ReadString("ImageCapturePath")
                If Directory.Exists(ImageCapturePath) = False Then
                    Directory.CreateDirectory(ImageCapturePath)
                End If

                Dim pbImage As New PictureBox
                Dim si As Integer = DSCamCapture.FrameSizes.s640x480
                Dim SelectedSize As DSCamCapture.FrameSizes = CType(si, DSCamCapture.FrameSizes)
                If cam.ConnectToDevice(CamIndex, 15, pbImage.ClientSize, SelectedSize, pbImage.Handle) Then
                    AddHandler cam.FrameSaved, AddressOf CamFrameSaved
                    cam.Start()

                    Dim fName As String = DepositTransNo & ".jpg"
                    Dim SaveAs As String = Path.Combine(ImageCapturePath, fName)
                    If File.Exists(SaveAs) = True Then
                        Try
                            File.SetAttributes(SaveAs, FileAttributes.Normal)
                            File.Delete(SaveAs)
                        Catch ex As Exception

                        End Try
                    End If

                    cam.SaveCurrentFrame(SaveAs, Imaging.ImageFormat.Jpeg)
                End If
            End If
        Catch ex As Exception
            Application.Exit()
        End Try
    End Sub

    Private Sub CamFrameSaved()
        cam.Dispose()
        Application.Exit()
    End Sub
End Class