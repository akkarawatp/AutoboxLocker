<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSC_StockAndHardware
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TimerCheckDoorClose = New System.Windows.Forms.Timer(Me.components)
        Me.lblOpenAll = New System.Windows.Forms.Label()
        Me.lblLockerSetting = New System.Windows.Forms.Label()
        Me.lblDeviceSetting = New System.Windows.Forms.Label()
        Me.lblKioskSetting = New System.Windows.Forms.Label()
        Me.lblFillMoney = New System.Windows.Forms.Label()
        Me.lblFillPaper = New System.Windows.Forms.Label()
        Me.btnOpenAll = New System.Windows.Forms.Panel()
        Me.btnLockerSetting = New System.Windows.Forms.Panel()
        Me.btnDeviceSetting = New System.Windows.Forms.Panel()
        Me.btnKioskSetting = New System.Windows.Forms.Panel()
        Me.btnFillMoney = New System.Windows.Forms.Panel()
        Me.btnFillPaper = New System.Windows.Forms.Panel()
        Me.lblCollect = New System.Windows.Forms.Label()
        Me.btnCollect = New System.Windows.Forms.Panel()
        Me.pbStatusCoinIn = New System.Windows.Forms.PictureBox()
        Me.pbStatusBanknoteIn = New System.Windows.Forms.PictureBox()
        Me.pbStatusCoinOut5 = New System.Windows.Forms.PictureBox()
        Me.pbStatusBanknoteOut20 = New System.Windows.Forms.PictureBox()
        Me.pbStatusBanknoteOut100 = New System.Windows.Forms.PictureBox()
        Me.pbStatusPrinter = New System.Windows.Forms.PictureBox()
        Me.pbStatusWebcam = New System.Windows.Forms.PictureBox()
        Me.pbStatusNetwork = New System.Windows.Forms.PictureBox()
        Me.pbStatusQRCode = New System.Windows.Forms.PictureBox()
        Me.pbStatusSolenoid = New System.Windows.Forms.PictureBox()
        Me.pbStatusLED = New System.Windows.Forms.PictureBox()
        Me.pbStatusSensor = New System.Windows.Forms.PictureBox()
        Me.lblStockCoinOut5 = New System.Windows.Forms.Label()
        Me.lblTotalCoinOut5 = New System.Windows.Forms.Label()
        Me.lblStockCoinIn = New System.Windows.Forms.Label()
        Me.lblTotalCoinIn = New System.Windows.Forms.Label()
        Me.lblStockBanknoteIn = New System.Windows.Forms.Label()
        Me.lblTotalBanknoteIn = New System.Windows.Forms.Label()
        Me.lblStockBanknote20 = New System.Windows.Forms.Label()
        Me.lblTotalBanknote20 = New System.Windows.Forms.Label()
        Me.lblStockBanknote100 = New System.Windows.Forms.Label()
        Me.lblTotalBanknote100 = New System.Windows.Forms.Label()
        Me.lblStockPrinter = New System.Windows.Forms.Label()
        Me.lblTotalPrinter = New System.Windows.Forms.Label()
        Me.pgStockCoinIn = New MiniboxLocker.ucStockProgress()
        Me.pgStockCoinOut5 = New MiniboxLocker.ucStockProgress()
        Me.pgStockBanknote20 = New MiniboxLocker.ucStockProgress()
        Me.pgStockBanknoteIn = New MiniboxLocker.ucStockProgress()
        Me.pgStockBanknote100 = New MiniboxLocker.ucStockProgress()
        Me.pgStockPrinter = New MiniboxLocker.ucStockProgress()
        Me.btnServiceRate = New System.Windows.Forms.Panel()
        Me.lblServiceRate = New System.Windows.Forms.Label()
        Me.btnOpenAll.SuspendLayout()
        Me.btnLockerSetting.SuspendLayout()
        Me.btnDeviceSetting.SuspendLayout()
        Me.btnKioskSetting.SuspendLayout()
        Me.btnFillMoney.SuspendLayout()
        Me.btnFillPaper.SuspendLayout()
        Me.btnCollect.SuspendLayout()
        CType(Me.pbStatusCoinIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusBanknoteIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusCoinOut5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusBanknoteOut20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusBanknoteOut100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusPrinter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusWebcam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusSolenoid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusLED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStatusSensor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnServiceRate.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimerCheckDoorClose
        '
        Me.TimerCheckDoorClose.Enabled = True
        Me.TimerCheckDoorClose.Interval = 2000
        '
        'lblOpenAll
        '
        Me.lblOpenAll.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblOpenAll.BackColor = System.Drawing.Color.Transparent
        Me.lblOpenAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblOpenAll.ForeColor = System.Drawing.Color.White
        Me.lblOpenAll.Location = New System.Drawing.Point(42, 14)
        Me.lblOpenAll.Name = "lblOpenAll"
        Me.lblOpenAll.Size = New System.Drawing.Size(73, 25)
        Me.lblOpenAll.TabIndex = 35
        Me.lblOpenAll.Text = "Open All"
        Me.lblOpenAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLockerSetting
        '
        Me.lblLockerSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLockerSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblLockerSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblLockerSetting.ForeColor = System.Drawing.Color.White
        Me.lblLockerSetting.Location = New System.Drawing.Point(20, 14)
        Me.lblLockerSetting.Name = "lblLockerSetting"
        Me.lblLockerSetting.Size = New System.Drawing.Size(120, 25)
        Me.lblLockerSetting.TabIndex = 35
        Me.lblLockerSetting.Text = "Locker Setting"
        Me.lblLockerSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDeviceSetting
        '
        Me.lblDeviceSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDeviceSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblDeviceSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblDeviceSetting.ForeColor = System.Drawing.Color.White
        Me.lblDeviceSetting.Location = New System.Drawing.Point(20, 16)
        Me.lblDeviceSetting.Name = "lblDeviceSetting"
        Me.lblDeviceSetting.Size = New System.Drawing.Size(118, 25)
        Me.lblDeviceSetting.TabIndex = 35
        Me.lblDeviceSetting.Text = "Device Setting"
        Me.lblDeviceSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKioskSetting
        '
        Me.lblKioskSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblKioskSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblKioskSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblKioskSetting.ForeColor = System.Drawing.Color.White
        Me.lblKioskSetting.Location = New System.Drawing.Point(22, 15)
        Me.lblKioskSetting.Name = "lblKioskSetting"
        Me.lblKioskSetting.Size = New System.Drawing.Size(111, 25)
        Me.lblKioskSetting.TabIndex = 35
        Me.lblKioskSetting.Text = "Kiosk Setting"
        Me.lblKioskSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFillMoney
        '
        Me.lblFillMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFillMoney.BackColor = System.Drawing.Color.Transparent
        Me.lblFillMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFillMoney.ForeColor = System.Drawing.Color.White
        Me.lblFillMoney.Location = New System.Drawing.Point(23, 14)
        Me.lblFillMoney.Name = "lblFillMoney"
        Me.lblFillMoney.Size = New System.Drawing.Size(109, 26)
        Me.lblFillMoney.TabIndex = 35
        Me.lblFillMoney.Text = "Fill Money"
        Me.lblFillMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFillPaper
        '
        Me.lblFillPaper.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFillPaper.BackColor = System.Drawing.Color.Transparent
        Me.lblFillPaper.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblFillPaper.ForeColor = System.Drawing.Color.White
        Me.lblFillPaper.Location = New System.Drawing.Point(27, 14)
        Me.lblFillPaper.Name = "lblFillPaper"
        Me.lblFillPaper.Size = New System.Drawing.Size(104, 26)
        Me.lblFillPaper.TabIndex = 35
        Me.lblFillPaper.Text = "Fill Paper"
        Me.lblFillPaper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOpenAll
        '
        Me.btnOpenAll.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOpenAll.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnOpenAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenAll.Controls.Add(Me.lblOpenAll)
        Me.btnOpenAll.Location = New System.Drawing.Point(586, 751)
        Me.btnOpenAll.Name = "btnOpenAll"
        Me.btnOpenAll.Size = New System.Drawing.Size(157, 52)
        Me.btnOpenAll.TabIndex = 67
        '
        'btnLockerSetting
        '
        Me.btnLockerSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnLockerSetting.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnLockerSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLockerSetting.Controls.Add(Me.lblLockerSetting)
        Me.btnLockerSetting.Location = New System.Drawing.Point(399, 748)
        Me.btnLockerSetting.Name = "btnLockerSetting"
        Me.btnLockerSetting.Size = New System.Drawing.Size(159, 55)
        Me.btnLockerSetting.TabIndex = 66
        '
        'btnDeviceSetting
        '
        Me.btnDeviceSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDeviceSetting.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnDeviceSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeviceSetting.Controls.Add(Me.lblDeviceSetting)
        Me.btnDeviceSetting.Location = New System.Drawing.Point(216, 748)
        Me.btnDeviceSetting.Name = "btnDeviceSetting"
        Me.btnDeviceSetting.Size = New System.Drawing.Size(157, 55)
        Me.btnDeviceSetting.TabIndex = 66
        '
        'btnKioskSetting
        '
        Me.btnKioskSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnKioskSetting.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnKioskSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnKioskSetting.Controls.Add(Me.lblKioskSetting)
        Me.btnKioskSetting.Location = New System.Drawing.Point(42, 748)
        Me.btnKioskSetting.Name = "btnKioskSetting"
        Me.btnKioskSetting.Size = New System.Drawing.Size(157, 55)
        Me.btnKioskSetting.TabIndex = 65
        '
        'btnFillMoney
        '
        Me.btnFillMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFillMoney.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnFillMoney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFillMoney.Controls.Add(Me.lblFillMoney)
        Me.btnFillMoney.Location = New System.Drawing.Point(216, 679)
        Me.btnFillMoney.Name = "btnFillMoney"
        Me.btnFillMoney.Size = New System.Drawing.Size(157, 54)
        Me.btnFillMoney.TabIndex = 64
        '
        'btnFillPaper
        '
        Me.btnFillPaper.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFillPaper.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnFillPaper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFillPaper.Controls.Add(Me.lblFillPaper)
        Me.btnFillPaper.Location = New System.Drawing.Point(42, 678)
        Me.btnFillPaper.Name = "btnFillPaper"
        Me.btnFillPaper.Size = New System.Drawing.Size(158, 55)
        Me.btnFillPaper.TabIndex = 63
        '
        'lblCollect
        '
        Me.lblCollect.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCollect.BackColor = System.Drawing.Color.Transparent
        Me.lblCollect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCollect.ForeColor = System.Drawing.Color.White
        Me.lblCollect.Location = New System.Drawing.Point(23, 14)
        Me.lblCollect.Name = "lblCollect"
        Me.lblCollect.Size = New System.Drawing.Size(109, 26)
        Me.lblCollect.TabIndex = 35
        Me.lblCollect.Text = "Collect"
        Me.lblCollect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCollect
        '
        Me.btnCollect.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCollect.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnCollect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCollect.Controls.Add(Me.lblCollect)
        Me.btnCollect.Location = New System.Drawing.Point(586, 680)
        Me.btnCollect.Name = "btnCollect"
        Me.btnCollect.Size = New System.Drawing.Size(157, 53)
        Me.btnCollect.TabIndex = 65
        '
        'pbStatusCoinIn
        '
        Me.pbStatusCoinIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusCoinIn.Location = New System.Drawing.Point(42, 242)
        Me.pbStatusCoinIn.Name = "pbStatusCoinIn"
        Me.pbStatusCoinIn.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusCoinIn.TabIndex = 68
        Me.pbStatusCoinIn.TabStop = False
        '
        'pbStatusBanknoteIn
        '
        Me.pbStatusBanknoteIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusBanknoteIn.Location = New System.Drawing.Point(216, 242)
        Me.pbStatusBanknoteIn.Name = "pbStatusBanknoteIn"
        Me.pbStatusBanknoteIn.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusBanknoteIn.TabIndex = 69
        Me.pbStatusBanknoteIn.TabStop = False
        '
        'pbStatusCoinOut5
        '
        Me.pbStatusCoinOut5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusCoinOut5.Location = New System.Drawing.Point(42, 309)
        Me.pbStatusCoinOut5.Name = "pbStatusCoinOut5"
        Me.pbStatusCoinOut5.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusCoinOut5.TabIndex = 70
        Me.pbStatusCoinOut5.TabStop = False
        '
        'pbStatusBanknoteOut20
        '
        Me.pbStatusBanknoteOut20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusBanknoteOut20.Location = New System.Drawing.Point(216, 309)
        Me.pbStatusBanknoteOut20.Name = "pbStatusBanknoteOut20"
        Me.pbStatusBanknoteOut20.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusBanknoteOut20.TabIndex = 71
        Me.pbStatusBanknoteOut20.TabStop = False
        '
        'pbStatusBanknoteOut100
        '
        Me.pbStatusBanknoteOut100.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusBanknoteOut100.Location = New System.Drawing.Point(216, 376)
        Me.pbStatusBanknoteOut100.Name = "pbStatusBanknoteOut100"
        Me.pbStatusBanknoteOut100.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusBanknoteOut100.TabIndex = 72
        Me.pbStatusBanknoteOut100.TabStop = False
        '
        'pbStatusPrinter
        '
        Me.pbStatusPrinter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusPrinter.Location = New System.Drawing.Point(42, 376)
        Me.pbStatusPrinter.Name = "pbStatusPrinter"
        Me.pbStatusPrinter.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusPrinter.TabIndex = 73
        Me.pbStatusPrinter.TabStop = False
        '
        'pbStatusWebcam
        '
        Me.pbStatusWebcam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusWebcam.Location = New System.Drawing.Point(42, 443)
        Me.pbStatusWebcam.Name = "pbStatusWebcam"
        Me.pbStatusWebcam.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusWebcam.TabIndex = 74
        Me.pbStatusWebcam.TabStop = False
        '
        'pbStatusNetwork
        '
        Me.pbStatusNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusNetwork.Location = New System.Drawing.Point(216, 443)
        Me.pbStatusNetwork.Name = "pbStatusNetwork"
        Me.pbStatusNetwork.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusNetwork.TabIndex = 75
        Me.pbStatusNetwork.TabStop = False
        '
        'pbStatusQRCode
        '
        Me.pbStatusQRCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusQRCode.Location = New System.Drawing.Point(42, 510)
        Me.pbStatusQRCode.Name = "pbStatusQRCode"
        Me.pbStatusQRCode.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusQRCode.TabIndex = 76
        Me.pbStatusQRCode.TabStop = False
        '
        'pbStatusSolenoid
        '
        Me.pbStatusSolenoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusSolenoid.Location = New System.Drawing.Point(216, 510)
        Me.pbStatusSolenoid.Name = "pbStatusSolenoid"
        Me.pbStatusSolenoid.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusSolenoid.TabIndex = 77
        Me.pbStatusSolenoid.TabStop = False
        '
        'pbStatusLED
        '
        Me.pbStatusLED.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusLED.Location = New System.Drawing.Point(42, 577)
        Me.pbStatusLED.Name = "pbStatusLED"
        Me.pbStatusLED.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusLED.TabIndex = 78
        Me.pbStatusLED.TabStop = False
        '
        'pbStatusSensor
        '
        Me.pbStatusSensor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStatusSensor.Location = New System.Drawing.Point(216, 577)
        Me.pbStatusSensor.Name = "pbStatusSensor"
        Me.pbStatusSensor.Size = New System.Drawing.Size(172, 65)
        Me.pbStatusSensor.TabIndex = 79
        Me.pbStatusSensor.TabStop = False
        '
        'lblStockCoinOut5
        '
        Me.lblStockCoinOut5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblStockCoinOut5.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockCoinOut5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.lblStockCoinOut5.Location = New System.Drawing.Point(675, 258)
        Me.lblStockCoinOut5.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStockCoinOut5.Name = "lblStockCoinOut5"
        Me.lblStockCoinOut5.Size = New System.Drawing.Size(72, 38)
        Me.lblStockCoinOut5.TabIndex = 81
        Me.lblStockCoinOut5.Text = "500"
        Me.lblStockCoinOut5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalCoinOut5
        '
        Me.lblTotalCoinOut5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTotalCoinOut5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCoinOut5.ForeColor = System.Drawing.Color.Black
        Me.lblTotalCoinOut5.Location = New System.Drawing.Point(675, 298)
        Me.lblTotalCoinOut5.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalCoinOut5.Name = "lblTotalCoinOut5"
        Me.lblTotalCoinOut5.Size = New System.Drawing.Size(74, 20)
        Me.lblTotalCoinOut5.TabIndex = 82
        Me.lblTotalCoinOut5.Text = "/500"
        Me.lblTotalCoinOut5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStockCoinIn
        '
        Me.lblStockCoinIn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblStockCoinIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockCoinIn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.lblStockCoinIn.Location = New System.Drawing.Point(484, 360)
        Me.lblStockCoinIn.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStockCoinIn.Name = "lblStockCoinIn"
        Me.lblStockCoinIn.Size = New System.Drawing.Size(72, 38)
        Me.lblStockCoinIn.TabIndex = 83
        Me.lblStockCoinIn.Text = "500"
        Me.lblStockCoinIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalCoinIn
        '
        Me.lblTotalCoinIn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTotalCoinIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCoinIn.ForeColor = System.Drawing.Color.Black
        Me.lblTotalCoinIn.Location = New System.Drawing.Point(444, 400)
        Me.lblTotalCoinIn.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalCoinIn.Name = "lblTotalCoinIn"
        Me.lblTotalCoinIn.Size = New System.Drawing.Size(142, 20)
        Me.lblTotalCoinIn.TabIndex = 84
        Me.lblTotalCoinIn.Text = "/500"
        Me.lblTotalCoinIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStockBanknoteIn
        '
        Me.lblStockBanknoteIn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblStockBanknoteIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockBanknoteIn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.lblStockBanknoteIn.Location = New System.Drawing.Point(486, 550)
        Me.lblStockBanknoteIn.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStockBanknoteIn.Name = "lblStockBanknoteIn"
        Me.lblStockBanknoteIn.Size = New System.Drawing.Size(72, 38)
        Me.lblStockBanknoteIn.TabIndex = 85
        Me.lblStockBanknoteIn.Text = "500"
        Me.lblStockBanknoteIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalBanknoteIn
        '
        Me.lblTotalBanknoteIn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTotalBanknoteIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBanknoteIn.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBanknoteIn.Location = New System.Drawing.Point(446, 588)
        Me.lblTotalBanknoteIn.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalBanknoteIn.Name = "lblTotalBanknoteIn"
        Me.lblTotalBanknoteIn.Size = New System.Drawing.Size(140, 20)
        Me.lblTotalBanknoteIn.TabIndex = 86
        Me.lblTotalBanknoteIn.Text = "/500"
        Me.lblTotalBanknoteIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStockBanknote20
        '
        Me.lblStockBanknote20.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblStockBanknote20.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockBanknote20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.lblStockBanknote20.Location = New System.Drawing.Point(675, 369)
        Me.lblStockBanknote20.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStockBanknote20.Name = "lblStockBanknote20"
        Me.lblStockBanknote20.Size = New System.Drawing.Size(72, 38)
        Me.lblStockBanknote20.TabIndex = 87
        Me.lblStockBanknote20.Text = "500"
        Me.lblStockBanknote20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalBanknote20
        '
        Me.lblTotalBanknote20.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTotalBanknote20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBanknote20.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBanknote20.Location = New System.Drawing.Point(675, 410)
        Me.lblTotalBanknote20.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalBanknote20.Name = "lblTotalBanknote20"
        Me.lblTotalBanknote20.Size = New System.Drawing.Size(74, 20)
        Me.lblTotalBanknote20.TabIndex = 88
        Me.lblTotalBanknote20.Text = "/500"
        Me.lblTotalBanknote20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStockBanknote100
        '
        Me.lblStockBanknote100.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblStockBanknote100.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockBanknote100.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.lblStockBanknote100.Location = New System.Drawing.Point(675, 482)
        Me.lblStockBanknote100.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStockBanknote100.Name = "lblStockBanknote100"
        Me.lblStockBanknote100.Size = New System.Drawing.Size(72, 38)
        Me.lblStockBanknote100.TabIndex = 89
        Me.lblStockBanknote100.Text = "500"
        Me.lblStockBanknote100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalBanknote100
        '
        Me.lblTotalBanknote100.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTotalBanknote100.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBanknote100.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBanknote100.Location = New System.Drawing.Point(675, 521)
        Me.lblTotalBanknote100.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalBanknote100.Name = "lblTotalBanknote100"
        Me.lblTotalBanknote100.Size = New System.Drawing.Size(74, 20)
        Me.lblTotalBanknote100.TabIndex = 90
        Me.lblTotalBanknote100.Text = "/500"
        Me.lblTotalBanknote100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStockPrinter
        '
        Me.lblStockPrinter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblStockPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockPrinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.lblStockPrinter.Location = New System.Drawing.Point(656, 584)
        Me.lblStockPrinter.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStockPrinter.Name = "lblStockPrinter"
        Me.lblStockPrinter.Size = New System.Drawing.Size(54, 28)
        Me.lblStockPrinter.TabIndex = 91
        Me.lblStockPrinter.Text = "500"
        Me.lblStockPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPrinter
        '
        Me.lblTotalPrinter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTotalPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPrinter.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPrinter.Location = New System.Drawing.Point(711, 592)
        Me.lblTotalPrinter.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalPrinter.Name = "lblTotalPrinter"
        Me.lblTotalPrinter.Size = New System.Drawing.Size(39, 20)
        Me.lblTotalPrinter.TabIndex = 92
        Me.lblTotalPrinter.Text = "/500"
        Me.lblTotalPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgStockCoinIn
        '
        Me.pgStockCoinIn.Location = New System.Drawing.Point(458, 434)
        Me.pgStockCoinIn.MaxValue = 500
        Me.pgStockCoinIn.MinValue = 1
        Me.pgStockCoinIn.Name = "pgStockCoinIn"
        Me.pgStockCoinIn.Size = New System.Drawing.Size(128, 7)
        Me.pgStockCoinIn.TabIndex = 93
        Me.pgStockCoinIn.Value = 0
        '
        'pgStockCoinOut5
        '
        Me.pgStockCoinOut5.Location = New System.Drawing.Point(620, 325)
        Me.pgStockCoinOut5.MaxValue = 500
        Me.pgStockCoinOut5.MinValue = 1
        Me.pgStockCoinOut5.Name = "pgStockCoinOut5"
        Me.pgStockCoinOut5.Size = New System.Drawing.Size(128, 7)
        Me.pgStockCoinOut5.TabIndex = 94
        Me.pgStockCoinOut5.Value = 0
        '
        'pgStockBanknote20
        '
        Me.pgStockBanknote20.Location = New System.Drawing.Point(620, 437)
        Me.pgStockBanknote20.MaxValue = 500
        Me.pgStockBanknote20.MinValue = 1
        Me.pgStockBanknote20.Name = "pgStockBanknote20"
        Me.pgStockBanknote20.Size = New System.Drawing.Size(128, 7)
        Me.pgStockBanknote20.TabIndex = 95
        Me.pgStockBanknote20.Value = 0
        '
        'pgStockBanknoteIn
        '
        Me.pgStockBanknoteIn.Location = New System.Drawing.Point(458, 615)
        Me.pgStockBanknoteIn.MaxValue = 500
        Me.pgStockBanknoteIn.MinValue = 1
        Me.pgStockBanknoteIn.Name = "pgStockBanknoteIn"
        Me.pgStockBanknoteIn.Size = New System.Drawing.Size(128, 7)
        Me.pgStockBanknoteIn.TabIndex = 96
        Me.pgStockBanknoteIn.Value = 0
        '
        'pgStockBanknote100
        '
        Me.pgStockBanknote100.Location = New System.Drawing.Point(620, 548)
        Me.pgStockBanknote100.MaxValue = 500
        Me.pgStockBanknote100.MinValue = 1
        Me.pgStockBanknote100.Name = "pgStockBanknote100"
        Me.pgStockBanknote100.Size = New System.Drawing.Size(128, 7)
        Me.pgStockBanknote100.TabIndex = 97
        Me.pgStockBanknote100.Value = 0
        '
        'pgStockPrinter
        '
        Me.pgStockPrinter.Location = New System.Drawing.Point(673, 618)
        Me.pgStockPrinter.MaxValue = 500
        Me.pgStockPrinter.MinValue = 1
        Me.pgStockPrinter.Name = "pgStockPrinter"
        Me.pgStockPrinter.Size = New System.Drawing.Size(70, 7)
        Me.pgStockPrinter.TabIndex = 98
        Me.pgStockPrinter.Value = 0
        '
        'btnServiceRate
        '
        Me.btnServiceRate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnServiceRate.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnServiceRate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnServiceRate.Controls.Add(Me.lblServiceRate)
        Me.btnServiceRate.Location = New System.Drawing.Point(401, 678)
        Me.btnServiceRate.Name = "btnServiceRate"
        Me.btnServiceRate.Size = New System.Drawing.Size(157, 53)
        Me.btnServiceRate.TabIndex = 66
        '
        'lblServiceRate
        '
        Me.lblServiceRate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblServiceRate.BackColor = System.Drawing.Color.Transparent
        Me.lblServiceRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblServiceRate.ForeColor = System.Drawing.Color.White
        Me.lblServiceRate.Location = New System.Drawing.Point(23, 14)
        Me.lblServiceRate.Name = "lblServiceRate"
        Me.lblServiceRate.Size = New System.Drawing.Size(109, 26)
        Me.lblServiceRate.TabIndex = 35
        Me.lblServiceRate.Text = "Service Rate"
        Me.lblServiceRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSC_StockAndHardware
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgSCStockAndHardware
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(768, 1024)
        Me.Controls.Add(Me.btnServiceRate)
        Me.Controls.Add(Me.pgStockPrinter)
        Me.Controls.Add(Me.pgStockBanknote100)
        Me.Controls.Add(Me.pgStockBanknoteIn)
        Me.Controls.Add(Me.pgStockBanknote20)
        Me.Controls.Add(Me.pgStockCoinOut5)
        Me.Controls.Add(Me.pgStockCoinIn)
        Me.Controls.Add(Me.lblTotalPrinter)
        Me.Controls.Add(Me.lblStockPrinter)
        Me.Controls.Add(Me.lblTotalBanknote100)
        Me.Controls.Add(Me.lblStockBanknote100)
        Me.Controls.Add(Me.lblTotalBanknote20)
        Me.Controls.Add(Me.lblStockBanknote20)
        Me.Controls.Add(Me.lblTotalBanknoteIn)
        Me.Controls.Add(Me.lblStockBanknoteIn)
        Me.Controls.Add(Me.lblTotalCoinIn)
        Me.Controls.Add(Me.lblStockCoinIn)
        Me.Controls.Add(Me.lblTotalCoinOut5)
        Me.Controls.Add(Me.lblStockCoinOut5)
        Me.Controls.Add(Me.pbStatusSensor)
        Me.Controls.Add(Me.pbStatusLED)
        Me.Controls.Add(Me.pbStatusSolenoid)
        Me.Controls.Add(Me.pbStatusQRCode)
        Me.Controls.Add(Me.pbStatusNetwork)
        Me.Controls.Add(Me.pbStatusWebcam)
        Me.Controls.Add(Me.pbStatusPrinter)
        Me.Controls.Add(Me.pbStatusBanknoteOut100)
        Me.Controls.Add(Me.pbStatusBanknoteOut20)
        Me.Controls.Add(Me.pbStatusCoinOut5)
        Me.Controls.Add(Me.pbStatusBanknoteIn)
        Me.Controls.Add(Me.pbStatusCoinIn)
        Me.Controls.Add(Me.btnCollect)
        Me.Controls.Add(Me.btnOpenAll)
        Me.Controls.Add(Me.btnLockerSetting)
        Me.Controls.Add(Me.btnDeviceSetting)
        Me.Controls.Add(Me.btnKioskSetting)
        Me.Controls.Add(Me.btnFillMoney)
        Me.Controls.Add(Me.btnFillPaper)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_StockAndHardware"
        Me.btnOpenAll.ResumeLayout(False)
        Me.btnLockerSetting.ResumeLayout(False)
        Me.btnDeviceSetting.ResumeLayout(False)
        Me.btnKioskSetting.ResumeLayout(False)
        Me.btnFillMoney.ResumeLayout(False)
        Me.btnFillPaper.ResumeLayout(False)
        Me.btnCollect.ResumeLayout(False)
        CType(Me.pbStatusCoinIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusBanknoteIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusCoinOut5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusBanknoteOut20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusBanknoteOut100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusPrinter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusWebcam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusSolenoid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusLED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStatusSensor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnServiceRate.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFillPaper As Label
    Friend WithEvents lblFillMoney As Label
    Friend WithEvents lblKioskSetting As Label
    Friend WithEvents lblDeviceSetting As Label
    Friend WithEvents lblLockerSetting As Label
    Friend WithEvents lblOpenAll As Label
    Friend WithEvents TimerCheckDoorClose As Timer
    Friend WithEvents btnOpenAll As Panel
    Friend WithEvents btnLockerSetting As Panel
    Friend WithEvents btnDeviceSetting As Panel
    Friend WithEvents btnKioskSetting As Panel
    Friend WithEvents btnFillMoney As Panel
    Friend WithEvents btnFillPaper As Panel
    Friend WithEvents lblCollect As Label
    Friend WithEvents btnCollect As Panel
    Friend WithEvents pbStatusCoinIn As PictureBox
    Friend WithEvents pbStatusBanknoteIn As PictureBox
    Friend WithEvents pbStatusCoinOut5 As PictureBox
    Friend WithEvents pbStatusBanknoteOut20 As PictureBox
    Friend WithEvents pbStatusBanknoteOut100 As PictureBox
    Friend WithEvents pbStatusPrinter As PictureBox
    Friend WithEvents pbStatusWebcam As PictureBox
    Friend WithEvents pbStatusNetwork As PictureBox
    Friend WithEvents pbStatusQRCode As PictureBox
    Friend WithEvents pbStatusSolenoid As PictureBox
    Friend WithEvents pbStatusLED As PictureBox
    Friend WithEvents pbStatusSensor As PictureBox
    Friend WithEvents lblStockCoinOut5 As Label
    Friend WithEvents lblTotalCoinOut5 As Label
    Friend WithEvents lblStockCoinIn As Label
    Friend WithEvents lblTotalCoinIn As Label
    Friend WithEvents lblStockBanknoteIn As Label
    Friend WithEvents lblTotalBanknoteIn As Label
    Friend WithEvents lblStockBanknote20 As Label
    Friend WithEvents lblTotalBanknote20 As Label
    Friend WithEvents lblStockBanknote100 As Label
    Friend WithEvents lblTotalBanknote100 As Label
    Friend WithEvents lblStockPrinter As Label
    Friend WithEvents lblTotalPrinter As Label
    Friend WithEvents pgStockCoinIn As ucStockProgress
    Friend WithEvents pgStockCoinOut5 As ucStockProgress
    Friend WithEvents pgStockBanknote20 As ucStockProgress
    Friend WithEvents pgStockBanknoteIn As ucStockProgress
    Friend WithEvents pgStockBanknote100 As ucStockProgress
    Friend WithEvents pgStockPrinter As ucStockProgress
    Friend WithEvents btnServiceRate As Panel
    Friend WithEvents lblServiceRate As Label
End Class
