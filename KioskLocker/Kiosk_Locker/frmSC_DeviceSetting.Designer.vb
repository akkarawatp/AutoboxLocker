<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSC_DeviceSetting
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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Panel()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Panel()
        Me.lblSave = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbBanknoteOut20 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbBanknoteIn = New System.Windows.Forms.ComboBox()
        Me.cbBanknoteOut100 = New System.Windows.Forms.ComboBox()
        Me.cbCoinIn = New System.Windows.Forms.ComboBox()
        Me.cbCoinOut5 = New System.Windows.Forms.ComboBox()
        Me.cbBoardSolenoid = New System.Windows.Forms.ComboBox()
        Me.cbBoardSensor = New System.Windows.Forms.ComboBox()
        Me.cbBoardLED = New System.Windows.Forms.ComboBox()
        Me.cbPrinterName = New System.Windows.Forms.ComboBox()
        Me.txtQRCodeVID = New System.Windows.Forms.TextBox()
        Me.cbWebCamera = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancel.SuspendLayout()
        Me.btnSave.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 39.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(65, 14)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(939, 58)
        Me.lblHeader.TabIndex = 46
        Me.lblHeader.Text = "Device Setting"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(68, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 33)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "เครื่องรับธนบัตร"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(71, 332)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 33)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "แผงควบคุม Sensor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(68, 374)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(204, 33)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "แผงควบคุม LED"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(68, 290)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(261, 33)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "แผงควบคุม Solenoid"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Controls.Add(Me.lblCancel)
        Me.btnCancel.Location = New System.Drawing.Point(599, 678)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(239, 78)
        Me.btnCancel.TabIndex = 63
        '
        'lblCancel
        '
        Me.lblCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCancel.ForeColor = System.Drawing.Color.Black
        Me.lblCancel.Location = New System.Drawing.Point(44, 11)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(149, 54)
        Me.lblCancel.TabIndex = 35
        Me.lblCancel.Text = "Cancel"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSave.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.Controls.Add(Me.lblSave)
        Me.btnSave.Location = New System.Drawing.Point(287, 678)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(239, 78)
        Me.btnSave.TabIndex = 62
        '
        'lblSave
        '
        Me.lblSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSave.BackColor = System.Drawing.Color.Transparent
        Me.lblSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblSave.ForeColor = System.Drawing.Color.Black
        Me.lblSave.Location = New System.Drawing.Point(37, 11)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(164, 54)
        Me.lblSave.TabIndex = 35
        Me.lblSave.Text = "Save"
        Me.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(71, 418)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(318, 33)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "เครื่องอ่าน QR Code  VID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(68, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(304, 33)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "เครื่องทอนธนบัตร 20 บาท"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbBanknoteOut20
        '
        Me.cbBanknoteOut20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbBanknoteOut20.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanknoteOut20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbBanknoteOut20.FormattingEnabled = True
        Me.cbBanknoteOut20.Location = New System.Drawing.Point(394, 124)
        Me.cbBanknoteOut20.Name = "cbBanknoteOut20"
        Me.cbBanknoteOut20.Size = New System.Drawing.Size(199, 37)
        Me.cbBanknoteOut20.TabIndex = 69
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(68, 165)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(320, 33)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "เครื่องทอนธนบัตร 100 บาท"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(68, 207)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(187, 33)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "เครื่องรับเหรียญ"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(68, 249)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(284, 33)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "เครื่องทอนเหรียญ 5 บาท"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(71, 456)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 33)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "เครื่องพิมพ์ Slip"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbBanknoteIn
        '
        Me.cbBanknoteIn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbBanknoteIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanknoteIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbBanknoteIn.FormattingEnabled = True
        Me.cbBanknoteIn.Location = New System.Drawing.Point(394, 82)
        Me.cbBanknoteIn.Name = "cbBanknoteIn"
        Me.cbBanknoteIn.Size = New System.Drawing.Size(199, 37)
        Me.cbBanknoteIn.TabIndex = 78
        '
        'cbBanknoteOut100
        '
        Me.cbBanknoteOut100.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbBanknoteOut100.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanknoteOut100.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbBanknoteOut100.FormattingEnabled = True
        Me.cbBanknoteOut100.Location = New System.Drawing.Point(394, 166)
        Me.cbBanknoteOut100.Name = "cbBanknoteOut100"
        Me.cbBanknoteOut100.Size = New System.Drawing.Size(199, 37)
        Me.cbBanknoteOut100.TabIndex = 79
        '
        'cbCoinIn
        '
        Me.cbCoinIn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbCoinIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCoinIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbCoinIn.FormattingEnabled = True
        Me.cbCoinIn.Location = New System.Drawing.Point(394, 208)
        Me.cbCoinIn.Name = "cbCoinIn"
        Me.cbCoinIn.Size = New System.Drawing.Size(199, 37)
        Me.cbCoinIn.TabIndex = 80
        '
        'cbCoinOut5
        '
        Me.cbCoinOut5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbCoinOut5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCoinOut5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbCoinOut5.FormattingEnabled = True
        Me.cbCoinOut5.Location = New System.Drawing.Point(394, 250)
        Me.cbCoinOut5.Name = "cbCoinOut5"
        Me.cbCoinOut5.Size = New System.Drawing.Size(199, 37)
        Me.cbCoinOut5.TabIndex = 81
        '
        'cbBoardSolenoid
        '
        Me.cbBoardSolenoid.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbBoardSolenoid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBoardSolenoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbBoardSolenoid.FormattingEnabled = True
        Me.cbBoardSolenoid.Location = New System.Drawing.Point(394, 291)
        Me.cbBoardSolenoid.Name = "cbBoardSolenoid"
        Me.cbBoardSolenoid.Size = New System.Drawing.Size(199, 37)
        Me.cbBoardSolenoid.TabIndex = 82
        '
        'cbBoardSensor
        '
        Me.cbBoardSensor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbBoardSensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBoardSensor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbBoardSensor.FormattingEnabled = True
        Me.cbBoardSensor.Location = New System.Drawing.Point(394, 333)
        Me.cbBoardSensor.Name = "cbBoardSensor"
        Me.cbBoardSensor.Size = New System.Drawing.Size(199, 37)
        Me.cbBoardSensor.TabIndex = 83
        '
        'cbBoardLED
        '
        Me.cbBoardLED.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbBoardLED.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBoardLED.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbBoardLED.FormattingEnabled = True
        Me.cbBoardLED.Location = New System.Drawing.Point(394, 375)
        Me.cbBoardLED.Name = "cbBoardLED"
        Me.cbBoardLED.Size = New System.Drawing.Size(199, 37)
        Me.cbBoardLED.TabIndex = 84
        '
        'cbPrinterName
        '
        Me.cbPrinterName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbPrinterName.FormattingEnabled = True
        Me.cbPrinterName.Location = New System.Drawing.Point(394, 457)
        Me.cbPrinterName.Name = "cbPrinterName"
        Me.cbPrinterName.Size = New System.Drawing.Size(453, 37)
        Me.cbPrinterName.TabIndex = 86
        '
        'txtQRCodeVID
        '
        Me.txtQRCodeVID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtQRCodeVID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQRCodeVID.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQRCodeVID.Location = New System.Drawing.Point(395, 418)
        Me.txtQRCodeVID.MaxLength = 15
        Me.txtQRCodeVID.Name = "txtQRCodeVID"
        Me.txtQRCodeVID.Size = New System.Drawing.Size(198, 33)
        Me.txtQRCodeVID.TabIndex = 87
        Me.txtQRCodeVID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbWebCamera
        '
        Me.cbWebCamera.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbWebCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWebCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbWebCamera.FormattingEnabled = True
        Me.cbWebCamera.Location = New System.Drawing.Point(394, 498)
        Me.cbWebCamera.Name = "cbWebCamera"
        Me.cbWebCamera.Size = New System.Drawing.Size(453, 37)
        Me.cbWebCamera.TabIndex = 90
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(72, 497)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(195, 33)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "กล้อง Webcam"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSC_DeviceSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 764)
        Me.Controls.Add(Me.txtQRCodeVID)
        Me.Controls.Add(Me.cbWebCamera)
        Me.Controls.Add(Me.cbPrinterName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbBoardLED)
        Me.Controls.Add(Me.cbBoardSensor)
        Me.Controls.Add(Me.cbBoardSolenoid)
        Me.Controls.Add(Me.cbCoinOut5)
        Me.Controls.Add(Me.cbCoinIn)
        Me.Controls.Add(Me.cbBanknoteOut100)
        Me.Controls.Add(Me.cbBanknoteIn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbBanknoteOut20)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_DeviceSetting"
        Me.Text = "frmSC_KioskSetting"
        Me.btnCancel.ResumeLayout(False)
        Me.btnSave.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCancel As Panel
    Friend WithEvents lblCancel As Label
    Friend WithEvents btnSave As Panel
    Friend WithEvents lblSave As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cbBanknoteOut20 As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cbBanknoteIn As ComboBox
    Friend WithEvents cbBanknoteOut100 As ComboBox
    Friend WithEvents cbCoinIn As ComboBox
    Friend WithEvents cbCoinOut5 As ComboBox
    Friend WithEvents cbBoardSolenoid As ComboBox
    Friend WithEvents cbBoardSensor As ComboBox
    Friend WithEvents cbBoardLED As ComboBox
    Friend WithEvents cbPrinterName As ComboBox
    Friend WithEvents txtQRCodeVID As TextBox
    Friend WithEvents cbWebCamera As ComboBox
    Friend WithEvents Label4 As Label
End Class
