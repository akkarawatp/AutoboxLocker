Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class PrinterTestDevice

    Dim Printer As New PrinterClass

    Private Sub CashInTestDevice_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        sp.Close()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim p As New PrintDocument
        p.PrintController = New Printing.StandardPrintController
        p.PrinterSettings.PrinterName = lblPrinterName.Text

        Dim mgn As New Margins(0, 0, 0, 0)
        p.DefaultPageSettings.Margins = mgn
        AddHandler p.PrintPage, AddressOf p_PrintPage
        p.Print()
    End Sub

    Private Sub p_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs)
        Dim fn5 As New Font("Calibri", 5, FontStyle.Regular)
        Dim fn7 As New Font("Calibri", 7, FontStyle.Regular)
        Dim fn7b As New Font("Calibri", 7, FontStyle.Bold)
        Dim fn8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim fn8b As New Font("Calibri", 8, FontStyle.Bold)
        Dim fn10b As New Font("Calibri", 9.5, FontStyle.Bold)
        Dim fn15b As New Font("Calibri", 15, FontStyle.Bold)

        Dim imgLogo As Image = Image.FromFile("SlipLogo.png")
        PrintImage(Image.FromFile("SlipLogo.png"), Align.Center, e, 0)

        Dim DepositTime As String = DateTime.Now.ToString("dd-MMM-yy, HH:mm", New Globalization.CultureInfo("en-US"))
        PrintText(DepositTime.ToUpper, fn8, Align.Center, e, 50)
        PrintText("M01", fn15b, Align.Center, e, 65)
        PrintText("West Bus 02", fn8, Align.Center, e, 90)

        Dim qrCode As String = GenerateQRCode()
        If qrCode.Trim <> "" Then
            PrintImage(Image.FromFile(qrCode), Align.Center, e, 100)
        End If
        PrintText("Use this slip to take back your luggage", fn7b, Align.Center, e, 290)
        PrintText("Warning : This barode can be used only 1 time", fn7b, Align.Center, e, 300)

        PrintText("For any help, please contact our service center", fn7, Align.Center, e, 320)
        PrintText("Tel. 089XXXXXXX (in service time)", fn7, Align.Center, e, 330)
        PrintText("Thank you for using our service", fn8b, Align.Center, e, 340)
        e.HasMorePages = False
    End Sub

#Region "Print With PrintDocument"
    Protected Sub PrintText(ByVal txt As String, ByVal fnt As System.Drawing.Font, ByRef e As System.Drawing.Printing.PrintPageEventArgs, x As Integer, y As Integer)
        Dim w As Integer = e.Graphics.MeasureString(txt, fnt).Width
        Dim h As Integer = e.Graphics.MeasureString(txt, fnt).Height
        Dim brsh As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))
        e.Graphics.DrawString(txt, fnt, brsh, x, y)
    End Sub
    Protected Sub PrintText(ByVal txt As String, ByVal fnt As System.Drawing.Font, ByVal align As Align, ByRef e As System.Drawing.Printing.PrintPageEventArgs, y As Integer)
        Dim w As Integer = e.Graphics.MeasureString(txt, fnt).Width
        Dim h As Integer = e.Graphics.MeasureString(txt, fnt).Height
        Dim x As Integer = 0
        Dim brsh As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))
        Select Case align
            Case 0 'Default, LEFT
                x = e.PageSettings.PrintableArea.Left
            Case 1 'CENTER
                x = e.PageSettings.PrintableArea.Width / 2 - w / 2
            Case 2 'RIGHT
                x = e.PageSettings.PrintableArea.Right - w
        End Select
        e.Graphics.DrawString(txt, fnt, brsh, x, y)
    End Sub

    Protected Sub PrintImage(ByVal img As System.Drawing.Image, ByVal align As Align, ByRef e As System.Drawing.Printing.PrintPageEventArgs, y As Integer)
        Dim w As Integer = img.Width
        Dim h As Integer = img.Height
        Dim x As Integer = 0
        Select Case align
            Case 0 'Default, LEFT
                x = e.PageSettings.PrintableArea.Left
            Case 1 'CENTER
                x = e.PageSettings.PrintableArea.Width / 2 - w / 2
            Case 2 'RIGHT
                x = e.PageSettings.PrintableArea.Right - w
        End Select
        e.Graphics.DrawImage(img, x, y)
        img.Dispose()
    End Sub

    Protected Enum Align As Short
        Left = 0
        Center = 1
        Right = 2
    End Enum
#End Region

#Region "QR Code Processing"
    Private Function GenerateQRCode() As String
        Dim ret As String = ""
        '## QRCode Format TransactionID + TransactionNo + ID + Len(TransactionID)
        Dim QRCode As String = "123400120160521163218ID4"

        Dim obj As New WolfSoftware.Library_NET.BarcodeControl
        obj.Unlock("Phantom 2008", "WSFCX-0100-100883561")
        obj.CurrentCode = 1014
        obj.DataToEncode = QRCode  'ขนาดของ QR จะขึ้นอยู่กับความยาวของ Data
        Dim pic As New Bitmap(obj.GetCode(1080)) 'The bitmap you created
        pic.SetResolution(1080, 1080)
        Dim path As String = Application.StartupPath() & "\QRCode"
        If IO.Directory.Exists(path) = False Then
            IO.Directory.CreateDirectory(path)
        End If

        Try
            For Each f As String In Directory.GetFiles(path)
                File.Delete(f)
            Next

            Dim FileName As String = path & "\" & QRCode & ".bmp"
            pic.Save(FileName, Imaging.ImageFormat.Bmp)

            If IO.File.Exists(FileName) = True Then
                ret = CropImage(FileName)
            End If
        Catch ex As Exception

        End Try

        Return ret
    End Function

    Private Function CropImage(fileName As String) As String
        'Dim fileName = "C:\file.jpg"
        Dim ret As String = fileName
        Dim CropRect As New Rectangle(300, 170, 530, 530)   'กำหนด Area ที่จะทำการ Crop
        Dim OriginalImage = Image.FromFile(ret)
        Dim crpImg = New Bitmap(CropRect.Width, CropRect.Height)
        Using grp = Graphics.FromImage(crpImg)
            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            OriginalImage.Dispose()

            crpImg = ResizeImage(crpImg, New Drawing.Size(180, 180))
            crpImg.Save(ret, Imaging.ImageFormat.Bmp)
        End Using

        Return ret
    End Function


    Public Shared Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                    percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function
#End Region


    Sub CheckStatusPrinter()
        Dim Status As String = Printer.CheckPrinterStatus("")
        lblStatus.Text = "Status : " & Status
        If Status = "Online" Then
            lblStatus.ForeColor = Color.Green
        Else
            lblStatus.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Printer.PrintConfirmationSlipTopUp("", "", "", "150")
    End Sub




#Region "Print With Printer Class"
    Private Sub PrintSlip(PrinterDeviceName As String, TransNo As String, LockerName As String, LocationName As String)
        Try
            Dim prn As New PrinterClassDll.Win32Print
            prn.SetPrinterName(PrinterDeviceName)



            prn.PrintText(" ")
            prn.PrintImage(Application.StartupPath & "\SlipLogo.bmp")
            prn.SetDeviceFont(10, "Calibri", False, False)
            prn.PrintText("Document No : " & TransNo)
            prn.SetDeviceFont(16, "Calibri", True, False)
            prn.PrintText("     Your Locker Number : " & LockerName)

            prn.SetDeviceFont(10, "Calibri", False, False)
            prn.PrintText("Location : " & LocationName)

            Dim DepositTime As String = DateTime.Now.ToString("dd-mm-yy, h:mm tt")
            Dim CollectTime As String = DateTime.Now.ToString("dd-mm-yy, h:mm tt")

            prn.PrintText("Deposit Date & Time : " & DepositTime)
            prn.PrintText("Please collect your luggage within : " & CollectTime)
            prn.PrintImage(Application.StartupPath & "\SlipLine.bmp")

            prn.SetDeviceFont(11, "Calibri", True, False)
            prn.PrintText("    Use this QR-code to collect your luggage")

            'Dim qrCode As String = GenerateQRCode()
            'If qrCode.Trim <> "" Then
            '    prn.PrintImage(qrCode)
            'End If

            'Dim BarCode As String = Deposit.DepositTransactionID & Deposit.DepositTransNo & "ID" & Deposit.DepositTransactionID.ToString.Length
            'PrintText(BarCode, fnBarcode, Align.Center, e)

            prn.PrintText("  Caution : This QR-Code can be used only 1 time")
            prn.PrintImage(Application.StartupPath & "\SlipLine.bmp")

            prn.SetDeviceFont(10, "Calibri", False, False)
            prn.PrintText("In case of lost QR code and cannot open your locker")
            prn.PrintText("   500 THB will be fined on top of your storage costs.")
            prn.PrintImage(Application.StartupPath & "\SlipLine.bmp")

            prn.PrintText("   For any help, please contact our service center")
            prn.PrintText("       Tel. 02-756-4502 (in service time)")

            prn.SetDeviceFont(10, "Calibri", True, False)
            prn.PrintText("Thank you for using our service & have a nice trip")
            prn.EndDoc()

        Catch ex As Exception
            'InsertErrorLog(KioskData.ComputerName, "frmDepositPrintQRCode", "PrintSlip", "Exception : " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "&TransactionNo=" & Customer.TransactionNo)
        End Try
    End Sub



#End Region



End Class