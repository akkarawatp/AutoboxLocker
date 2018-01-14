Imports System.Data.SqlClient
Imports System.IO
Imports MiniboxLocker.Data.KioskConfigData
Imports BoardSolenoid
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text.PrivateFontCollection
'Imports PrinterClassDll

Public Class frmDepositPrintQRCode

    Dim TimeOut As Int32 = KioskConfig.ShowMsgSec
    Dim ThankTimeOut As Boolean = False

    Private Sub frmDepositPrintQRCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        CheckForIllegalCrossThreadCalls = False
        lblTimeOut.Text = TimeOut
        KioskConfig.SelectForm = KioskLockerForm.DepositPrintQRCode
        'SetChildFormLanguage()
    End Sub

    Private Sub frmDepositPrintQRCode_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = False
        Me.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_OpenForm, "", False)
    End Sub

    Public Sub PaymentCompletePrintQRCode()
        Try
            'เวลาที่พิมพ์ Slip เสร็จ
            Deposit.PaidTime = DateTime.Now
            'lblChangeAmt.Text = Deposit.ChangeAmount
            Application.DoEvents()
            PrintSlip()
            If Deposit.ChangeAmount > 0 Then
                InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_ChangeMoney, Deposit.ChangeAmount & " บาท", False)
                ChangeMoney(Deposit.ChangeAmount, Deposit, Collect)
            End If

            InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_LEDBlinkOn, Deposit.LockerName, False)
            BoardLED.LEDBlinkOn(Deposit.LockerPinLED)

            Application.DoEvents()
            CheckTimeOpenLocker()
        Catch ex As Exception
            InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_PrintSlip, "Update Status ไม่สำเร็จ คืนเงินให้ลูกค้า " & (Deposit.PaidAmount - Deposit.ChangeAmount) & " บาท", True)
            UpdateDepositStatus(Deposit.DepositTransactionID, DepositTransactionData.TransactionStatus.Problem, KioskLockerStep.DepositPrintQRCode_ChangeMoney)
            ReturnMoney(Deposit.PaidAmount - Deposit.ChangeAmount, Deposit, Collect)
            BoardLED.LEDStop(Deposit.LockerPinLED)
            ShowFormError("Out of Service", "Cannot change money", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_ChangeMoney, True)
        End Try
    End Sub


    Private Sub CheckTimeOpenLocker()
        '    'หน่วงเวลาตาม Timeout
        Threading.Thread.Sleep(TimeOut * 1000)
        Me.Close()
        frmDepositThankyou.MdiParent = frmMain
        frmDepositThankyou.Show()
    End Sub

#Region "Print With PrintDocument"
    Private Sub PrintSlip()
        Try
            InsertLogTransactionActivity(Deposit.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_PrintSlip, "", False)

            Dim p As New PrintDocument
            p.PrintController = New Printing.StandardPrintController
            p.PrinterSettings.PrinterName = KioskConfig.PrinterDeviceName

            AddHandler p.PrintPage, AddressOf p_PrintPage
            p.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

            p.Print()

            UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.Printer, -1, 0, False)
        Catch ex As Exception
            InsertErrorLog("Exception : " & ex.Message & " " & ex.StackTrace, Deposit.DepositTransNo, 0, 0, KioskConfig.SelectForm, KioskLockerStep.DepositPrintQRCode_PrintSlip)
        End Try

    End Sub

    Private ReadOnly Property GetFrontIDAutomation3of9(ByVal Size As Single, ByVal style As FontStyle) As Font
        Get
            Return New Font(FontIDAutomation.Families(0), Size, style)
        End Get

    End Property

    Private Sub p_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs)
        Dim fn5 As New Font("Calibri", 5, FontStyle.Regular)
        Dim fn7 As New Font("Calibri", 7, FontStyle.Regular)
        Dim fn7b As New Font("Calibri", 7, FontStyle.Bold)
        Dim fn8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim fn8b As New Font("Calibri", 8, FontStyle.Bold)
        Dim fn10b As New Font("Calibri", 9.5, FontStyle.Bold)
        Dim fn15b As New Font("Calibri", 15, FontStyle.Bold)
        Dim fnBarcode As Font = GetFrontIDAutomation3of9(8, FontStyle.Regular)

        'Dim imgLogo As Image = Image.FromFile("SlipLogo.bmp")
        Dim imgLogo As Image = Image.FromFile("SlipLogo.png")
        Dim txtLine As String = "----------------------------------------------------"

        PrintImage(imgLogo, Align.Center, e)
        PrintText(" ", fn5, Align.Left, e)

        Dim DepositTime As String = Deposit.PaidTime.ToString("dd-MMM-yy, HH:mm", New Globalization.CultureInfo("en-US"))
        PrintText("Transaction No : " & Deposit.DepositTransNo, fn8, Align.Center, e)
        'PrintText(Deposit.DepositTransNo & " ", fn8, Align.Right, e)

        PrintText("Box Number : " & Deposit.LockerName, fn15b, Align.Center, e)
        'PrintText(Deposit.LockerName & " ", fn15b, Align.Right, e)

        PrintText("Location : " & KioskConfig.LocationName, fn8, Align.Center, e)
        'PrintText(KioskConfig.LocationName & " ", fn8, Align.Right, e)

        PrintText("Date & Time : " & DepositTime.ToUpper, fn8, Align.Center, e)
        'PrintText(DepositTime.ToUpper & " ", fn8, Align.Right, e)

        PrintText(txtLine, fn10b, Align.Center, e)

        'Print Barcode
        'Dim BarCodeImg As Image = GenerateBarcodeImage(Deposit.DepositTransactionID & Deposit.DepositTransNo & "ID" & Deposit.DepositTransactionID.ToString.Length)
        'PrintImage(BarCodeImg, Align.Center, e)

        'Dim BarcodeText As String = Deposit.DepositTransactionID & Deposit.DepositTransNo & "ID" & Deposit.DepositTransactionID.ToString.Length
        'PrintText(BarcodeText, GetFrontIDAutomation3of9(6, FontStyle.Regular), Align.Center, e)

        Dim qrCode As String = GenerateQRCode()
        If qrCode.Trim <> "" Then
            PrintImage(Image.FromFile(qrCode), Align.Center, e)
        End If
        PrintText(" ", fn5, Align.Left, e)

        'วาดกรอบให้กับ 2 บรรทัดข้างล่างนี้
        Dim borderTop As Integer = _lastPrintY - 2
        PrintText("Use this barcode to collect your luggage", fn7b, Align.Center, e)
        PrintText("Warning : This barode can be used only 1 time", fn7b, Align.Center, e)
        Dim borderH As Integer = (_lastPrintY + 2 - borderTop)
        PrintRectankle(0, borderTop, borderH, e)
        PrintText(" ", fn5, Align.Left, e)

        'PrintText("In case of lost QR code and cannot open your locker", fn8, Align.Center, e)
        'PrintText("500 THB will be fined on top of your storage costs.", fn8, Align.Center, e)
        'PrintText(txtLine, fn10b, Align.Center, e)

        PrintText("For any help, please contact our service center", fn7, Align.Center, e)
        PrintText("Tel. " & KioskConfig.ContactCenterTelno & " (in service time)", fn7, Align.Center, e)
        PrintText("Thank you for using our service", fn8b, Align.Center, e)
        e.HasMorePages = False
    End Sub

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

    Protected Sub PrintText(ByVal txt As String, ByVal fnt As System.Drawing.Font, ByVal align As Align, ByRef e As System.Drawing.Printing.PrintPageEventArgs, Optional AddNewLine As Boolean = True)
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
        If AddNewLine = True Then
            _lastPrintY = y + h
        End If

    End Sub

    'Protected Sub PrintBarcodeText(ByVal BarcodeText As String, ByVal fnt As System.Drawing.Font, ByRef e As System.Drawing.Printing.PrintPageEventArgs, Optional AddNewLine As Boolean = True)
    '    Dim w As Integer = e.Graphics.MeasureString(BarcodeText, fnt).Width
    '    Dim h As Integer = e.Graphics.MeasureString(BarcodeText, fnt).Height
    '    Dim x As Integer = 0
    '    Dim y As Integer = 0
    '    Dim brsh As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0))

    '    Dim RotateDx As Integer = 80
    '    x = e.PageSettings.PrintableArea.Width / 2 - w / 2
    '    y = e.PageSettings.PrintableArea.Top + lastPrintY
    '    e.Graphics.TranslateTransform(RotateDx, RotateDx)
    '    e.Graphics.RotateTransform(90)
    '    e.Graphics.DrawString(BarcodeText, fnt, brsh, x, y)
    '    If AddNewLine = True Then
    '        _lastPrintY = y + h + RotateDx
    '    End If

    'End Sub

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

    '#Region "Generate Barcode Image"
    '    Private Function GenerateBarcodeImage(BarcodeText As String, ByRef e As System.Drawing.Printing.PrintPageEventArgs) As Image
    '        Dim font As Font = GetFrontIDAutomation3of9(8, FontStyle.Regular)
    '        Dim width As Integer = CInt(e.Graphics.MeasureString(BarcodeText, font).Width)
    '        Dim height As Integer = CInt(e.Graphics.MeasureString(BarcodeText, font).Height)
    '        Dim bitmap = New Bitmap(width + 3, height)
    '        Dim graphics As Graphics = Graphics.FromImage(bitmap)
    '        graphics.Clear(Color.White)
    '        graphics.SmoothingMode = SmoothingMode.HighQuality
    '        graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
    '        graphics.DrawString(BarcodeText, font, New SolidBrush(Color.FromArgb(255, 255, 255)), 0, 0)
    '        graphics.Flush()
    '        graphics.Dispose()
    '        bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone)
    '        Return bitmap
    '    End Function
    '#End Region

#Region "Generate QR Code"
    Private Function GenerateQRCode() As String
        Dim ret As String = ""
        '## QRCode Format TransactionID + TransactionNo + ID + Len(TransactionID)
        Dim QRCode As String = Deposit.DepositTransactionID & Deposit.DepositTransNo & "ID" & Deposit.DepositTransactionID.ToString.Length

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
        Dim CropRect As New Rectangle(300, 170, 600, 600)   'กำหนด Area ที่จะทำการ Crop
        Dim OriginalImage = Image.FromFile(ret)
        Dim crpImg = New Bitmap(CropRect.Width, CropRect.Height)
        Using grp = Graphics.FromImage(crpImg)
            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            OriginalImage.Dispose()

            crpImg = ResizeImage(crpImg, New Drawing.Size(140, 140))
            crpImg.Save(ret, Imaging.ImageFormat.Bmp)
        End Using

        Return ret
    End Function

    Private Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
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
End Class