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
        Dim fn6 As New Font("Calibri", 6, FontStyle.Regular)
        Dim fn7 As New Font("Calibri", 7, FontStyle.Regular)
        Dim fn8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim fn8B As New Font("Calibri", 8, FontStyle.Bold)
        Dim fn11b As New Font("Calibri", 11, FontStyle.Bold)
        Dim fn16b As New Font("Calibri", 16, FontStyle.Bold)

        'Dim imgLogo As Image = Image.FromFile("SlipLogo.bmp")
        PrintImage(Image.FromFile("SlipLogo.png"), e, 50, 0)
        'PrintText("Trans No : 00120160521163218", fn8, Align.Left, e)
        PrintText(DateTime.Now.ToString("dd MMM yyyy HH:mm:ss"), fn8, e, 50, 50)
        PrintText("M01", fn16b, e, 50, 70)
        PrintText("Pattaya", fn8, e, 50, 100)

        Dim BarcodeText As String = "*001201802092356*"
        PrintBarcodeVertical(e.Graphics, 90, BarcodeText, GetFrontIDAutomation3of9(10, FontStyle.Regular), e)
        'PrintText(BarcodeText, GetFrontCode128(40, FontStyle.Regular), Align.Center, e)
        'PrintImage(GenerateBarcodeImage(BarcodeText, e), Align.Center, e)

        'Dim qrCode As String = GenerateQRCode()
        'If qrCode.Trim <> "" Then
        '    PrintImage(Image.FromFile(qrCode), Align.Center, e)
        'End If

        ''Dim borderTop As Integer = _lastPrintY - 2
        PrintText("Use this QR-code to collect your luggage", fn6, e, 50, 200)
        PrintText("This QR-Code can be used only 1 time", fn6, e, 50, 210)

        'Dim borderH As Integer = (_lastPrintY + 2 - borderTop)
        'PrintRectankle(0, borderTop, borderH, e)
        PrintText("For any help, please contact our service center", fn7, Align.Center, e, 250)
        PrintText("Tel. 089-999-9999 (in service time)", fn7, Align.Center, e, 265)
        PrintText("Thank you for using our service", fn8B, Align.Center, e, 280)

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

    Protected Sub PrintBarcodeVertical(gr As Graphics, angle As Double, ByVal txt As String, ByVal fnt As System.Drawing.Font, ByRef e As System.Drawing.Printing.PrintPageEventArgs)
        Dim w As Integer = e.Graphics.MeasureString(txt, fnt).Width
        Dim h As Integer = e.Graphics.MeasureString(txt, fnt).Height
        Dim x As Integer = 0
        Dim y As Integer = 0
        x = (e.PageSettings.PrintableArea.Width / 2 - h / 2) - 25
        y = 0 ' e.PageSettings.PrintableArea.Top

        Dim state As GraphicsState = gr.Save
        gr.ResetTransform()

        gr.RotateTransform(angle)

        gr.TranslateTransform(x, y, MatrixOrder.Append)

        Dim brsh As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))
        gr.DrawString(txt, fnt, brsh, 0, 0)

        gr.Restore(state)
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
                x = (e.PageSettings.PrintableArea.Width / 2 - w / 2)
                y = e.PageSettings.PrintableArea.Top + lastPrintY
            Case 2 'RIGHT
                x = e.PageSettings.PrintableArea.Right - w
                y = e.PageSettings.PrintableArea.Top + lastPrintY
        End Select
        e.Graphics.DrawImage(img, x, y)
        img.Dispose()
    End Sub

    Protected Sub PrintText(ByVal txt As String, ByVal fnt As System.Drawing.Font, ByRef e As System.Drawing.Printing.PrintPageEventArgs, x As Integer, y As Integer)
        Dim w As Integer = e.Graphics.MeasureString(txt, fnt).Width
        Dim h As Integer = e.Graphics.MeasureString(txt, fnt).Height
        Dim brsh As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))
        e.Graphics.DrawString(txt, fnt, brsh, x, y)
    End Sub

    Protected Sub PrintImage(ByVal img As System.Drawing.Image, ByRef e As System.Drawing.Printing.PrintPageEventArgs, x As Integer, y As Integer)
        Dim w As Integer = img.Width
        Dim h As Integer = img.Height
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

            crpImg = ResizeImage(crpImg, New Drawing.Size(200, 200))
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
    Private Sub PrintWithPrinterClass(PrinterDeviceName As String, TransNo As String, LockerName As String, LocationName As String)
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

    Private Sub btnPrintWithPrinterClass_Click(sender As Object, e As EventArgs) Handles btnPrintWithPrinterClass.Click
        PrintWithPrinterClass("ICT GP58-3", "1234567890", "L15", "BUSSTATION")
    End Sub

#End Region

    '#Region "Print With RawPrinterHelper"

    '    Public Const eClear As String = Chr(27) + "@"
    '    Public Const eCentre As String = Chr(27) + Chr(97) + "1"
    '    Public Const eLeft As String = Chr(27) + Chr(97) + "0"
    '    Public Const eRight As String = Chr(27) + Chr(97) + "2"
    '    Public Const eDrawer As String = eClear + Chr(27) + "p" + Chr(0) + ".}"
    '    Public Const eCut As String = Chr(27) + "i" + vbCrLf
    '    Public Const eSmlText As String = Chr(27) + "!" + Chr(1)
    '    Public Const eNmlText As String = Chr(27) + "!" + Chr(0)
    '    Public Const eInit As String = eNmlText + Chr(13) + Chr(27) +
    '    "c6" + Chr(1) + Chr(27) + "R3" + vbCrLf
    '    Public Const eBigCharOn As String = Chr(27) + "!" + Chr(56)
    '    Public Const eBigCharOff As String = Chr(27) + "!" + Chr(0)

    '    Private prn As New RawPrinterHelper

    '    'Private PrinterName As String = lblPrinterName.Text
    '    Public Sub StartPrint(PrinterName As String)
    '        prn.OpenPrint(PrinterName)
    '    End Sub

    '    Public Sub PrintHeader()
    '        Print(eInit + eCentre + "My Shop")
    '        Print("Tel:0123 456 7890")
    '        Print("Web: www.????.com")
    '        Print("sales@????.com")
    '        Print("VAT Reg No:123 4567 89" + eLeft)
    '        PrintDashes()
    '    End Sub

    '    Public Sub PrintBody()
    '        Print(eSmlText + "Tea                                          T1   1.30")

    '        PrintDashes()

    '        Print(eSmlText + "                                         Total:   1.30")

    '        Print("                                     Paid Card:   1.30")
    '    End Sub

    '    Public Sub PrintFooter()
    '        Print(eCentre + "Thank You For Your Support!" + eLeft)
    '        Print(vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)
    '    End Sub

    '    Public Sub Print(Line As String)
    '        prn.SendStringToPrinter(lblPrinterName.Text, Line + vbLf)
    '    End Sub

    '    Public Sub PrintDashes()
    '        Print(eLeft + eNmlText + "-".PadRight(42, "-"))
    '    End Sub

    '    Public Sub EndPrint()
    '        prn.ClosePrint()
    '    End Sub
    '    Private Sub btnPrint1_Click(sender As Object, e As EventArgs)
    '        StartPrint(lblPrinterName.Text)

    '        If prn.PrinterIsOpen = True Then
    '            PrintHeader()

    '            PrintBody()

    '            PrintFooter()

    '            EndPrint()
    '        End If
    '    End Sub
    '#End Region
End Class