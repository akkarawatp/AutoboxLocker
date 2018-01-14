Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class PrinterTestDevice

    Dim Printer As New PrinterClass
    Dim FontIDAutomation As System.Drawing.Text.PrivateFontCollection

    Private Sub CashInTestDevice_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        sp.Close()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub FormTestDevice_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        lblPrinterName.Focus()
        CheckStatusPrinter()

        FontIDAutomation = LoadFont(My.Resources.IDAutomationHC39M_Free, FontIDAutomation)
    End Sub

    Public Function LoadFont(FontResources() As Byte, _pfc As PrivateFontCollection) As PrivateFontCollection
        Try
            If _pfc Is Nothing Then _pfc = New PrivateFontCollection
            ''INIT THE FONT COLLECTION
            'LOAD MEMORY POINTER FOR FONT RESOURCE
            Dim fontMemPointer As IntPtr = Marshal.AllocCoTaskMem(FontResources.Length)
            'COPY THE DATA TO THE MEMORY LOCATION
            Marshal.Copy(FontResources, 0, fontMemPointer, FontResources.Length)
            'LOAD THE MEMORY FONT INTO THE PRIVATE FONT COLLECTION
            _pfc.AddMemoryFont(fontMemPointer, FontResources.Length)
            'FREE UNSAFE MEMORY
            Marshal.FreeCoTaskMem(fontMemPointer)
        Catch ex As Exception
            'ERROR LOADING FONT. HANDLE EXCEPTION HERE
            _pfc = New PrivateFontCollection
        End Try
        Return _pfc
    End Function

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        ' Printer.PrintConfirmationSlipNewSim(lblPrinterName.Text, "AUTOBOX", "AUTOBOX", "49", "150", "100", "0897682500", "000", "001")

        'PrintSlip(lblPrinterName.Text, "00120160521163218", "M01", "Airport Rail link Suvanabhumi Airport")
        _lastPrintY = 0
        Dim p As New PrintDocument
        p.PrintController = New Printing.StandardPrintController
        p.PrinterSettings.PrinterName = lblPrinterName.Text

        Dim mgn As New Margins(0, 0, 0, 0)
        p.DefaultPageSettings.Margins = mgn
        'Dim pkCustomSize1 As New PaperSize("Custom Paper Size", 100, 50)
        'p.DefaultPageSettings.PaperSize = pkCustomSize1
        AddHandler p.PrintPage, AddressOf p_PrintPage
        p.Print()
    End Sub

    Private ReadOnly Property GetFrontIDAutomation3of9(ByVal Size As Single, ByVal style As FontStyle) As Font
        Get
            Return New Font(FontIDAutomation.Families(0), Size, style)
        End Get

    End Property

    Private Sub p_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs)
        Dim fn10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim fn10B As New Font("Calibri", 10, FontStyle.Bold)
        Dim fn11b As New Font("Calibri", 11, FontStyle.Bold)
        Dim fn16b As New Font("Calibri", 16, FontStyle.Bold)

        'e.PageSettings.PaperSize.Width = 80
        'e.PageSettings.Margins.Left = 0
        'e.PageSettings.Margins.Right = 0


        'Dim imgLogo As Image = Image.FromFile("SlipLogo.bmp")

        PrintImage(Image.FromFile("SlipLogo.png"), Align.Center, e)
        PrintText("Document No : 00120160521163218", fn10, Align.Left, e)
        PrintText("Your Locker Number : M01", fn16b, Align.Center, e)
        PrintText("Location:Airport Rail link Suvanabhumi Airport", fn10, Align.Left, e)

        Dim BarcodeText As String = "00120160521163218"
        PrintText(BarcodeText, GetFrontIDAutomation3of9(8, FontStyle.Regular), Align.Center, e)
        'PrintBarcodeText(BarcodeText, GetFrontIDAutomation3of9(8, FontStyle.Regular), e)
        PrintImage(GenerateBarcodeImage(BarcodeText, e), Align.Center, e)


        Dim borderTop As Integer = _lastPrintY - 2
        PrintText("Use this QR-code to collect your luggage", fn10B, Align.Center, e)
        PrintText("Warning : This QR-Code can be used only 1 time", fn10B, Align.Center, e)

        Dim borderH As Integer = (_lastPrintY + 2 - borderTop)
        PrintRectankle(0, borderTop, borderH, e)

        PrintText("In case of lost QR code and cannot open your locker", fn10, Align.Center, e)
        'PrintImage(Image.FromFile("SlipWarning.bmp"), Align.Left, e)
        e.HasMorePages = False
    End Sub




#Region "Print With PrintDocument"

    Dim _lastPrintY As Integer = 0
    Protected ReadOnly Property lastPrintY() As Integer
        Get
            Return _lastPrintY
        End Get
    End Property

    Protected Sub PrintRectankle(PosX As Integer, PosY As Integer, h As Integer, ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        Dim brsh As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))
        Dim vPen As New Pen(brsh)
        Dim vRect As New Rectangle(PosX, PosY, e.PageSettings.PrintableArea.Width - 1, h)

        e.Graphics.DrawRectangle(vPen, vRect)
    End Sub

    'Protected Sub PrintBarcodeText(ByVal BarcodeText As String, ByVal fnt As System.Drawing.Font, ByRef e As System.Drawing.Printing.PrintPageEventArgs, Optional AddNewLine As Boolean = True)
    '    Dim w As Integer = e.Graphics.MeasureString(BarcodeText, fnt).Width
    '    Dim h As Integer = e.Graphics.MeasureString(BarcodeText, fnt).Height
    '    Dim x As Integer = 0
    '    'Dim y As Integer = e.PageSettings.PrintableArea.Top + lastPrintY
    '    Dim y As Integer = 0
    '    Dim brsh As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))

    '    x = e.PageSettings.PrintableArea.Width / 2 - h / 2
    '    'y = lastPrintY
    '    e.Graphics.TranslateTransform(0, 0)
    '    e.Graphics.RotateTransform(90)
    '    e.Graphics.DrawString(BarcodeText, fnt, brsh, x, y)
    '    If AddNewLine = True Then
    '        _lastPrintY = y + w
    '    End If
    '    e.Graphics.RotateTransform(-90)
    'End Sub

    Protected Sub PrintText(ByVal txt As String, ByVal fnt As System.Drawing.Font, ByVal align As Align, ByRef e As System.Drawing.Printing.PrintPageEventArgs)
        Dim w As Integer = e.Graphics.MeasureString(txt, fnt).Width
        Dim h As Integer = e.Graphics.MeasureString(txt, fnt).Height
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim brsh As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))
        Select Case align
            Case 0 'Default, LEFT
                x = e.PageSettings.PrintableArea.Left
                y = e.PageSettings.PrintableArea.Top + lastPrintY
            Case 1 'CENTER
                x = e.PageSettings.PrintableArea.Width / 2 - w / 2
                y = e.PageSettings.PrintableArea.Top + lastPrintY
            Case 2 'RIGHT
                x = e.PageSettings.PrintableArea.Right - w
                y = e.PageSettings.PrintableArea.Top + lastPrintY
        End Select
        e.Graphics.DrawString(txt, fnt, brsh, x, y)
        'TextRenderer.DrawText(e.Graphics, txt, fnt, New Point(x, y), SystemColors.ControlText)
        _lastPrintY = y + h
    End Sub

    Protected Sub PrintImage(ByVal img As System.Drawing.Image, ByVal align As Int16, ByRef e As System.Drawing.Printing.PrintPageEventArgs)
        Dim w As Integer = img.Width
        Dim h As Integer = img.Height
        Dim x As Integer = 0
        Dim y As Integer = 0
        Select Case align
            Case 0 'Default, LEFT
                x = e.PageSettings.PrintableArea.Left
                y = e.PageSettings.PrintableArea.Top + lastPrintY
            Case 1 'CENTER
                x = e.PageSettings.PrintableArea.Width / 2 - w / 2
                y = e.PageSettings.PrintableArea.Top + lastPrintY
            Case 2 'RIGHT
                x = e.PageSettings.PrintableArea.Right - w
                y = e.PageSettings.PrintableArea.Top + lastPrintY
        End Select
        e.Graphics.DrawImage(img, x, y)
        _lastPrintY = y + h
        img.Dispose()
    End Sub

    Protected Enum Align As Short
        Left = 0
        Center = 1
        Right = 2
    End Enum
#End Region

    '#Region "QR Code Processing"
    '    Private Function GenerateQRCode() As String
    '        Dim ret As String = ""
    '        '## QRCode Format TransactionID + TransactionNo + ID + Len(TransactionID)
    '        Dim QRCode As String = "123400120160521163218ID4"

    '        Dim obj As New WolfSoftware.Library_NET.BarcodeControl
    '        obj.Unlock("Phantom 2008", "WSFCX-0100-100883561")
    '        obj.CurrentCode = 1014
    '        obj.DataToEncode = QRCode  'ขนาดของ QR จะขึ้นอยู่กับความยาวของ Data
    '        Dim pic As New Bitmap(obj.GetCode(1080)) 'The bitmap you created
    '        pic.SetResolution(1080, 1080)
    '        Dim path As String = Application.StartupPath() & "\QRCode"
    '        If IO.Directory.Exists(path) = False Then
    '            IO.Directory.CreateDirectory(path)
    '        End If

    '        Try
    '            For Each f As String In Directory.GetFiles(path)
    '                File.Delete(f)
    '            Next

    '            Dim FileName As String = path & "\" & QRCode & ".bmp"
    '            pic.Save(FileName, Imaging.ImageFormat.Bmp)

    '            If IO.File.Exists(FileName) = True Then
    '                ret = CropImage(FileName)
    '            End If
    '        Catch ex As Exception

    '        End Try

    '        Return ret
    '    End Function

    '    Private Function CropImage(fileName As String) As String
    '        'Dim fileName = "C:\file.jpg"
    '        Dim ret As String = fileName
    '        Dim CropRect As New Rectangle(300, 170, 530, 530)   'กำหนด Area ที่จะทำการ Crop
    '        Dim OriginalImage = Image.FromFile(ret)
    '        Dim crpImg = New Bitmap(CropRect.Width, CropRect.Height)
    '        Using grp = Graphics.FromImage(crpImg)
    '            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
    '            OriginalImage.Dispose()

    '            crpImg = ResizeImage(crpImg, New Drawing.Size(200, 200))
    '            crpImg.Save(ret, Imaging.ImageFormat.Bmp)
    '        End Using

    '        Return ret
    '    End Function


    '    Public Shared Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
    '        Dim newWidth As Integer
    '        Dim newHeight As Integer
    '        If preserveAspectRatio Then
    '            Dim originalWidth As Integer = image.Width
    '            Dim originalHeight As Integer = image.Height
    '            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
    '            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
    '            Dim percent As Single = If(percentHeight < percentWidth,
    '                    percentHeight, percentWidth)
    '            newWidth = CInt(originalWidth * percent)
    '            newHeight = CInt(originalHeight * percent)
    '        Else
    '            newWidth = size.Width
    '            newHeight = size.Height
    '        End If
    '        Dim newImage As Image = New Bitmap(newWidth, newHeight)
    '        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
    '            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
    '            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
    '        End Using
    '        Return newImage
    '    End Function
    '#End Region


    Private Function GenerateBarcodeImage(BarcodeText As String, ByRef e As System.Drawing.Printing.PrintPageEventArgs) As Image
        Dim font As Font = GetFrontIDAutomation3of9(8, FontStyle.Regular)
        Dim width As Integer = CInt(e.Graphics.MeasureString(BarcodeText, font).Width)
        Dim height As Integer = CInt(e.Graphics.MeasureString(BarcodeText, font).Height)
        Dim bitmap = New Bitmap(width + 3, height)
        Dim graphics As Graphics = Graphics.FromImage(bitmap)
        graphics.Clear(Color.White)
        graphics.SmoothingMode = SmoothingMode.HighQuality
        'graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixel
        graphics.TextContrast = 0
        graphics.DrawString(BarcodeText, font, New SolidBrush(Color.FromArgb(0, 0, 0)), 0, 0)
        graphics.Flush()
        graphics.Dispose()
        bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Return bitmap
    End Function

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