<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSC_KioskSetting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtKioskID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTimeOut = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtScreenServer = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtExtend = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbNetworkDevice = New System.Windows.Forms.ComboBox()
        Me.txtIPAddress = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMacAddress = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkLoginSSO = New System.Windows.Forms.CheckBox()
        Me.txtOpenTimeH = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtOpenTimeM = New System.Windows.Forms.TextBox()
        Me.txtCloseTimeM = New System.Windows.Forms.TextBox()
        Me.txtCloseTimeH = New System.Windows.Forms.TextBox()
        Me.chkKioskOpen24 = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtContactCenter = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtSleepTimeM = New System.Windows.Forms.TextBox()
        Me.txtSleepTimeH = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtSleepDuration = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSyncLogInterval = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtSyncTransInterval = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSyncMasterInterval = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtPincodeLenght = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Panel()
        Me.pbCheckOpen24 = New System.Windows.Forms.PictureBox()
        CType(Me.pbCheckOpen24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtKioskID
        '
        Me.txtKioskID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtKioskID.BackColor = System.Drawing.SystemColors.Control
        Me.txtKioskID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKioskID.Enabled = False
        Me.txtKioskID.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtKioskID.Location = New System.Drawing.Point(160, 204)
        Me.txtKioskID.MaxLength = 15
        Me.txtKioskID.Name = "txtKioskID"
        Me.txtKioskID.Size = New System.Drawing.Size(208, 28)
        Me.txtKioskID.TabIndex = 1
        Me.txtKioskID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(70, 204)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 24)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Kiosk ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTimeOut
        '
        Me.txtTimeOut.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTimeOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTimeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtTimeOut.Location = New System.Drawing.Point(163, 502)
        Me.txtTimeOut.MaxLength = 15
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.Size = New System.Drawing.Size(78, 28)
        Me.txtTimeOut.TabIndex = 3
        Me.txtTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 502)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 24)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Kiosk Time Out"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtMessage.Location = New System.Drawing.Point(163, 551)
        Me.txtMessage.MaxLength = 15
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(78, 28)
        Me.txtMessage.TabIndex = 4
        Me.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 554)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 24)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Kiosk Message"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(827, 712)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 33)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Sec"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Visible = False
        '
        'txtScreenServer
        '
        Me.txtScreenServer.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtScreenServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtScreenServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScreenServer.Location = New System.Drawing.Point(614, 712)
        Me.txtScreenServer.MaxLength = 15
        Me.txtScreenServer.Name = "txtScreenServer"
        Me.txtScreenServer.Size = New System.Drawing.Size(207, 33)
        Me.txtScreenServer.TabIndex = 2
        Me.txtScreenServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtScreenServer.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(574, 713)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(187, 31)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Screen Server"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Visible = False
        '
        'txtExtend
        '
        Me.txtExtend.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtExtend.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtExtend.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtExtend.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtExtend.Location = New System.Drawing.Point(582, 204)
        Me.txtExtend.MaxLength = 15
        Me.txtExtend.Name = "txtExtend"
        Me.txtExtend.Size = New System.Drawing.Size(91, 28)
        Me.txtExtend.TabIndex = 5
        Me.txtExtend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(424, 204)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(148, 24)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Payment Extend"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(6, 253)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(142, 24)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Network Device"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbNetworkDevice
        '
        Me.cbNetworkDevice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbNetworkDevice.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.cbNetworkDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNetworkDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbNetworkDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.cbNetworkDevice.ForeColor = System.Drawing.Color.Black
        Me.cbNetworkDevice.FormattingEnabled = True
        Me.cbNetworkDevice.Location = New System.Drawing.Point(160, 250)
        Me.cbNetworkDevice.Name = "cbNetworkDevice"
        Me.cbNetworkDevice.Size = New System.Drawing.Size(208, 33)
        Me.cbNetworkDevice.TabIndex = 69
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIPAddress.BackColor = System.Drawing.SystemColors.Control
        Me.txtIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIPAddress.Enabled = False
        Me.txtIPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtIPAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIPAddress.Location = New System.Drawing.Point(160, 302)
        Me.txtIPAddress.MaxLength = 15
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(208, 28)
        Me.txtIPAddress.TabIndex = 70
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(46, 303)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 24)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "IP Address"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMacAddress
        '
        Me.txtMacAddress.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMacAddress.BackColor = System.Drawing.SystemColors.Control
        Me.txtMacAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMacAddress.Enabled = False
        Me.txtMacAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtMacAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMacAddress.Location = New System.Drawing.Point(160, 350)
        Me.txtMacAddress.MaxLength = 15
        Me.txtMacAddress.Name = "txtMacAddress"
        Me.txtMacAddress.Size = New System.Drawing.Size(208, 28)
        Me.txtMacAddress.TabIndex = 72
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(29, 352)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 24)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Mac Address"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(511, 646)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 31)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "Login SSO"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Visible = False
        '
        'chkLoginSSO
        '
        Me.chkLoginSSO.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkLoginSSO.AutoSize = True
        Me.chkLoginSSO.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkLoginSSO.Location = New System.Drawing.Point(825, 651)
        Me.chkLoginSSO.Name = "chkLoginSSO"
        Me.chkLoginSSO.Size = New System.Drawing.Size(15, 14)
        Me.chkLoginSSO.TabIndex = 75
        Me.chkLoginSSO.UseVisualStyleBackColor = True
        Me.chkLoginSSO.Visible = False
        '
        'txtOpenTimeH
        '
        Me.txtOpenTimeH.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtOpenTimeH.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtOpenTimeH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOpenTimeH.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtOpenTimeH.Location = New System.Drawing.Point(159, 452)
        Me.txtOpenTimeH.MaxLength = 2
        Me.txtOpenTimeH.Name = "txtOpenTimeH"
        Me.txtOpenTimeH.Size = New System.Drawing.Size(28, 28)
        Me.txtOpenTimeH.TabIndex = 79
        Me.txtOpenTimeH.Text = "00"
        Me.txtOpenTimeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(0, 451)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(156, 24)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Kiosk Open Time"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpenTimeM
        '
        Me.txtOpenTimeM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtOpenTimeM.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtOpenTimeM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOpenTimeM.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtOpenTimeM.Location = New System.Drawing.Point(214, 451)
        Me.txtOpenTimeM.MaxLength = 2
        Me.txtOpenTimeM.Name = "txtOpenTimeM"
        Me.txtOpenTimeM.Size = New System.Drawing.Size(29, 28)
        Me.txtOpenTimeM.TabIndex = 81
        Me.txtOpenTimeM.Text = "00"
        Me.txtOpenTimeM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCloseTimeM
        '
        Me.txtCloseTimeM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCloseTimeM.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCloseTimeM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCloseTimeM.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtCloseTimeM.Location = New System.Drawing.Point(347, 452)
        Me.txtCloseTimeM.MaxLength = 2
        Me.txtCloseTimeM.Name = "txtCloseTimeM"
        Me.txtCloseTimeM.Size = New System.Drawing.Size(31, 28)
        Me.txtCloseTimeM.TabIndex = 84
        Me.txtCloseTimeM.Text = "00"
        Me.txtCloseTimeM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCloseTimeH
        '
        Me.txtCloseTimeH.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCloseTimeH.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCloseTimeH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCloseTimeH.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtCloseTimeH.Location = New System.Drawing.Point(291, 452)
        Me.txtCloseTimeH.MaxLength = 2
        Me.txtCloseTimeH.Name = "txtCloseTimeH"
        Me.txtCloseTimeH.Size = New System.Drawing.Size(30, 28)
        Me.txtCloseTimeH.TabIndex = 83
        Me.txtCloseTimeH.Text = "00"
        Me.txtCloseTimeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkKioskOpen24
        '
        Me.chkKioskOpen24.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkKioskOpen24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.chkKioskOpen24.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkKioskOpen24.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkKioskOpen24.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkKioskOpen24.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkKioskOpen24.Location = New System.Drawing.Point(190, 408)
        Me.chkKioskOpen24.Name = "chkKioskOpen24"
        Me.chkKioskOpen24.Size = New System.Drawing.Size(22, 25)
        Me.chkKioskOpen24.TabIndex = 87
        Me.chkKioskOpen24.UseVisualStyleBackColor = True
        Me.chkKioskOpen24.Visible = False
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(11, 399)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(139, 24)
        Me.Label21.TabIndex = 88
        Me.Label21.Text = "Open 24 Hours"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactCenter
        '
        Me.txtContactCenter.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtContactCenter.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtContactCenter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContactCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtContactCenter.Location = New System.Drawing.Point(585, 255)
        Me.txtContactCenter.MaxLength = 15
        Me.txtContactCenter.Name = "txtContactCenter"
        Me.txtContactCenter.Size = New System.Drawing.Size(159, 28)
        Me.txtContactCenter.TabIndex = 92
        Me.txtContactCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(442, 259)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(134, 24)
        Me.Label24.TabIndex = 93
        Me.Label24.Text = "Contact Center"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSleepTimeM
        '
        Me.txtSleepTimeM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSleepTimeM.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtSleepTimeM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSleepTimeM.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSleepTimeM.Location = New System.Drawing.Point(634, 306)
        Me.txtSleepTimeM.MaxLength = 2
        Me.txtSleepTimeM.Name = "txtSleepTimeM"
        Me.txtSleepTimeM.Size = New System.Drawing.Size(35, 28)
        Me.txtSleepTimeM.TabIndex = 96
        Me.txtSleepTimeM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSleepTimeH
        '
        Me.txtSleepTimeH.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSleepTimeH.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtSleepTimeH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSleepTimeH.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSleepTimeH.Location = New System.Drawing.Point(580, 306)
        Me.txtSleepTimeH.MaxLength = 2
        Me.txtSleepTimeH.Name = "txtSleepTimeH"
        Me.txtSleepTimeH.Size = New System.Drawing.Size(31, 28)
        Me.txtSleepTimeH.TabIndex = 94
        Me.txtSleepTimeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(465, 306)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(107, 24)
        Me.Label26.TabIndex = 95
        Me.Label26.Text = "Sleep Time"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSleepDuration
        '
        Me.txtSleepDuration.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSleepDuration.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtSleepDuration.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSleepDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSleepDuration.Location = New System.Drawing.Point(582, 356)
        Me.txtSleepDuration.MaxLength = 15
        Me.txtSleepDuration.Name = "txtSleepDuration"
        Me.txtSleepDuration.Size = New System.Drawing.Size(87, 28)
        Me.txtSleepDuration.TabIndex = 98
        Me.txtSleepDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(438, 356)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(134, 24)
        Me.Label27.TabIndex = 99
        Me.Label27.Text = "Sleep Duration"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSyncLogInterval
        '
        Me.txtSyncLogInterval.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSyncLogInterval.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtSyncLogInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSyncLogInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSyncLogInterval.Location = New System.Drawing.Point(582, 549)
        Me.txtSyncLogInterval.MaxLength = 15
        Me.txtSyncLogInterval.Name = "txtSyncLogInterval"
        Me.txtSyncLogInterval.Size = New System.Drawing.Size(91, 28)
        Me.txtSyncLogInterval.TabIndex = 6
        Me.txtSyncLogInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(419, 553)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 24)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Sync Log Interval"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(403, 502)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(169, 24)
        Me.Label23.TabIndex = 90
        Me.Label23.Text = "Sync Trans Interval"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSyncTransInterval
        '
        Me.txtSyncTransInterval.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSyncTransInterval.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtSyncTransInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSyncTransInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSyncTransInterval.Location = New System.Drawing.Point(582, 500)
        Me.txtSyncTransInterval.MaxLength = 15
        Me.txtSyncTransInterval.Name = "txtSyncTransInterval"
        Me.txtSyncTransInterval.Size = New System.Drawing.Size(91, 28)
        Me.txtSyncTransInterval.TabIndex = 89
        Me.txtSyncTransInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(679, 505)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 20)
        Me.Label22.TabIndex = 91
        Me.Label22.Text = "Min"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(679, 455)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 20)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Min"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSyncMasterInterval
        '
        Me.txtSyncMasterInterval.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSyncMasterInterval.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtSyncMasterInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSyncMasterInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSyncMasterInterval.Location = New System.Drawing.Point(580, 452)
        Me.txtSyncMasterInterval.MaxLength = 15
        Me.txtSyncMasterInterval.Name = "txtSyncMasterInterval"
        Me.txtSyncMasterInterval.Size = New System.Drawing.Size(93, 28)
        Me.txtSyncMasterInterval.TabIndex = 76
        Me.txtSyncMasterInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(395, 455)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 24)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Sync Master Interval"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(679, 554)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(34, 20)
        Me.Label29.TabIndex = 101
        Me.Label29.Text = "Min"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(679, 411)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(41, 20)
        Me.Label30.TabIndex = 104
        Me.Label30.Text = "Digit"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPincodeLenght
        '
        Me.txtPincodeLenght.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPincodeLenght.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtPincodeLenght.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPincodeLenght.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtPincodeLenght.Location = New System.Drawing.Point(582, 405)
        Me.txtPincodeLenght.MaxLength = 15
        Me.txtPincodeLenght.Name = "txtPincodeLenght"
        Me.txtPincodeLenght.Size = New System.Drawing.Size(91, 28)
        Me.txtPincodeLenght.TabIndex = 102
        Me.txtPincodeLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(429, 407)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(143, 24)
        Me.Label31.TabIndex = 103
        Me.Label31.Text = "Pincode Lenght"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonCancel
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Location = New System.Drawing.Point(373, 712)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(137, 51)
        Me.btnCancel.TabIndex = 63
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSave.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonConfirm
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.Location = New System.Drawing.Point(214, 712)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(137, 51)
        Me.btnSave.TabIndex = 62
        '
        'pbCheckOpen24
        '
        Me.pbCheckOpen24.BackColor = System.Drawing.Color.Transparent
        Me.pbCheckOpen24.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.imgCheckboxUncheck
        Me.pbCheckOpen24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbCheckOpen24.Location = New System.Drawing.Point(159, 399)
        Me.pbCheckOpen24.Name = "pbCheckOpen24"
        Me.pbCheckOpen24.Size = New System.Drawing.Size(31, 31)
        Me.pbCheckOpen24.TabIndex = 105
        Me.pbCheckOpen24.TabStop = False
        '
        'frmSC_KioskSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgSCKioskSetting
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(768, 1024)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.pbCheckOpen24)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtPincodeLenght)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtSleepDuration)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtSleepTimeM)
        Me.Controls.Add(Me.txtSleepTimeH)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtContactCenter)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtSyncTransInterval)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.chkKioskOpen24)
        Me.Controls.Add(Me.txtCloseTimeM)
        Me.Controls.Add(Me.txtCloseTimeH)
        Me.Controls.Add(Me.txtOpenTimeM)
        Me.Controls.Add(Me.txtOpenTimeH)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtSyncMasterInterval)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkLoginSSO)
        Me.Controls.Add(Me.txtMacAddress)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbNetworkDevice)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtExtend)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtScreenServer)
        Me.Controls.Add(Me.txtSyncLogInterval)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTimeOut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtKioskID)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_KioskSetting"
        Me.Text = "frmSC_KioskSetting"
        CType(Me.pbCheckOpen24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtKioskID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTimeOut As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtScreenServer As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCancel As Panel
    Friend WithEvents btnSave As Panel
    Friend WithEvents txtExtend As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cbNetworkDevice As ComboBox
    Friend WithEvents txtIPAddress As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMacAddress As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents chkLoginSSO As CheckBox
    Friend WithEvents txtOpenTimeH As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtOpenTimeM As TextBox
    Friend WithEvents txtCloseTimeM As TextBox
    Friend WithEvents txtCloseTimeH As TextBox
    Friend WithEvents chkKioskOpen24 As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtContactCenter As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtSleepTimeM As TextBox
    Friend WithEvents txtSleepTimeH As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtSleepDuration As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtSyncLogInterval As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtSyncTransInterval As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtSyncMasterInterval As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents txtPincodeLenght As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents pbCheckOpen24 As PictureBox
End Class
