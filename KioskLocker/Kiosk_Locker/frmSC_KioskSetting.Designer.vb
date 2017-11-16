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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.txtKioskID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTimeOut = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtWebserviceURL = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtScreenServer = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Panel()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Panel()
        Me.lblSave = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.txtIDCardExpire = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtOpenTimeH = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtOpenTimeM = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCloseTimeM = New System.Windows.Forms.TextBox()
        Me.txtCloseTimeH = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkKioskOpen24 = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPassportExpire = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtContactCenter = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSleepTimeM = New System.Windows.Forms.TextBox()
        Me.txtSleepTimeH = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtSleepDuration = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnCancel.SuspendLayout()
        Me.btnSave.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(65, 33)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(939, 76)
        Me.lblHeader.TabIndex = 46
        Me.lblHeader.Text = "Kiosk Setting"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKioskID
        '
        Me.txtKioskID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtKioskID.BackColor = System.Drawing.SystemColors.Control
        Me.txtKioskID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKioskID.Enabled = False
        Me.txtKioskID.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtKioskID.Location = New System.Drawing.Point(327, 124)
        Me.txtKioskID.MaxLength = 15
        Me.txtKioskID.Name = "txtKioskID"
        Me.txtKioskID.Size = New System.Drawing.Size(207, 28)
        Me.txtKioskID.TabIndex = 1
        Me.txtKioskID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(68, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 29)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Kiosk ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTimeOut
        '
        Me.txtTimeOut.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTimeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtTimeOut.Location = New System.Drawing.Point(327, 318)
        Me.txtTimeOut.MaxLength = 15
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.Size = New System.Drawing.Size(207, 28)
        Me.txtTimeOut.TabIndex = 3
        Me.txtTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(71, 316)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 29)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Kiosk Time Out"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(574, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 29)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Sec"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(574, 348)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 29)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Sec"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtMessage.Location = New System.Drawing.Point(327, 350)
        Me.txtMessage.MaxLength = 15
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(207, 28)
        Me.txtMessage.TabIndex = 4
        Me.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(68, 348)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(178, 29)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Kiosk Message"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWebserviceURL
        '
        Me.txtWebserviceURL.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtWebserviceURL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWebserviceURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtWebserviceURL.Location = New System.Drawing.Point(327, 570)
        Me.txtWebserviceURL.MaxLength = 15
        Me.txtWebserviceURL.Name = "txtWebserviceURL"
        Me.txtWebserviceURL.Size = New System.Drawing.Size(626, 28)
        Me.txtWebserviceURL.TabIndex = 6
        Me.txtWebserviceURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(71, 568)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(193, 29)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Webservice URL"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(903, 292)
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
        Me.txtScreenServer.Location = New System.Drawing.Point(690, 292)
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
        Me.Label9.Location = New System.Drawing.Point(650, 293)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(187, 31)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Screen Server"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Controls.Add(Me.lblCancel)
        Me.btnCancel.Location = New System.Drawing.Point(519, 670)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(167, 56)
        Me.btnCancel.TabIndex = 63
        '
        'lblCancel
        '
        Me.lblCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCancel.ForeColor = System.Drawing.Color.Black
        Me.lblCancel.Location = New System.Drawing.Point(15, 11)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(138, 32)
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
        Me.btnSave.Location = New System.Drawing.Point(327, 670)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(162, 56)
        Me.btnSave.TabIndex = 62
        '
        'lblSave
        '
        Me.lblSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSave.BackColor = System.Drawing.Color.Transparent
        Me.lblSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblSave.ForeColor = System.Drawing.Color.Black
        Me.lblSave.Location = New System.Drawing.Point(17, 11)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(126, 32)
        Me.lblSave.TabIndex = 35
        Me.lblSave.Text = "Save"
        Me.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(574, 380)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 29)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Sec"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtExtend
        '
        Me.txtExtend.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtExtend.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtExtend.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtExtend.Location = New System.Drawing.Point(327, 382)
        Me.txtExtend.MaxLength = 15
        Me.txtExtend.Name = "txtExtend"
        Me.txtExtend.Size = New System.Drawing.Size(207, 28)
        Me.txtExtend.TabIndex = 5
        Me.txtExtend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(71, 380)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(186, 29)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Payment Extend"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(69, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(183, 29)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Network Device"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbNetworkDevice
        '
        Me.cbNetworkDevice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbNetworkDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNetworkDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.cbNetworkDevice.FormattingEnabled = True
        Me.cbNetworkDevice.Location = New System.Drawing.Point(327, 155)
        Me.cbNetworkDevice.Name = "cbNetworkDevice"
        Me.cbNetworkDevice.Size = New System.Drawing.Size(626, 33)
        Me.cbNetworkDevice.TabIndex = 69
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIPAddress.BackColor = System.Drawing.SystemColors.Control
        Me.txtIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIPAddress.Enabled = False
        Me.txtIPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtIPAddress.Location = New System.Drawing.Point(327, 191)
        Me.txtIPAddress.MaxLength = 15
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(309, 28)
        Me.txtIPAddress.TabIndex = 70
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(69, 191)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(130, 29)
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
        Me.txtMacAddress.Location = New System.Drawing.Point(327, 222)
        Me.txtMacAddress.MaxLength = 15
        Me.txtMacAddress.Name = "txtMacAddress"
        Me.txtMacAddress.Size = New System.Drawing.Size(309, 28)
        Me.txtMacAddress.TabIndex = 72
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(68, 222)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(153, 29)
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
        Me.Label15.Location = New System.Drawing.Point(642, 219)
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
        Me.chkLoginSSO.Location = New System.Drawing.Point(901, 231)
        Me.chkLoginSSO.Name = "chkLoginSSO"
        Me.chkLoginSSO.Size = New System.Drawing.Size(15, 14)
        Me.chkLoginSSO.TabIndex = 75
        Me.chkLoginSSO.UseVisualStyleBackColor = True
        Me.chkLoginSSO.Visible = False
        '
        'txtIDCardExpire
        '
        Me.txtIDCardExpire.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIDCardExpire.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDCardExpire.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtIDCardExpire.Location = New System.Drawing.Point(327, 414)
        Me.txtIDCardExpire.MaxLength = 15
        Me.txtIDCardExpire.Name = "txtIDCardExpire"
        Me.txtIDCardExpire.Size = New System.Drawing.Size(207, 28)
        Me.txtIDCardExpire.TabIndex = 76
        Me.txtIDCardExpire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(71, 412)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 29)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "ID Card Expire"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(574, 414)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 29)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Month"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpenTimeH
        '
        Me.txtOpenTimeH.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtOpenTimeH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOpenTimeH.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtOpenTimeH.Location = New System.Drawing.Point(327, 286)
        Me.txtOpenTimeH.MaxLength = 2
        Me.txtOpenTimeH.Name = "txtOpenTimeH"
        Me.txtOpenTimeH.Size = New System.Drawing.Size(52, 28)
        Me.txtOpenTimeH.TabIndex = 79
        Me.txtOpenTimeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(68, 284)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(201, 29)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Kiosk Open Time"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpenTimeM
        '
        Me.txtOpenTimeM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtOpenTimeM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOpenTimeM.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtOpenTimeM.Location = New System.Drawing.Point(400, 286)
        Me.txtOpenTimeM.MaxLength = 2
        Me.txtOpenTimeM.Name = "txtOpenTimeM"
        Me.txtOpenTimeM.Size = New System.Drawing.Size(52, 28)
        Me.txtOpenTimeM.TabIndex = 81
        Me.txtOpenTimeM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(459, 286)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 29)
        Me.Label18.TabIndex = 82
        Me.Label18.Text = "to"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCloseTimeM
        '
        Me.txtCloseTimeM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCloseTimeM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCloseTimeM.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtCloseTimeM.Location = New System.Drawing.Point(581, 286)
        Me.txtCloseTimeM.MaxLength = 2
        Me.txtCloseTimeM.Name = "txtCloseTimeM"
        Me.txtCloseTimeM.Size = New System.Drawing.Size(52, 28)
        Me.txtCloseTimeM.TabIndex = 84
        Me.txtCloseTimeM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCloseTimeH
        '
        Me.txtCloseTimeH.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCloseTimeH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCloseTimeH.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtCloseTimeH.Location = New System.Drawing.Point(502, 286)
        Me.txtCloseTimeH.MaxLength = 2
        Me.txtCloseTimeH.Name = "txtCloseTimeH"
        Me.txtCloseTimeH.Size = New System.Drawing.Size(52, 28)
        Me.txtCloseTimeH.TabIndex = 83
        Me.txtCloseTimeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(378, 286)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(19, 29)
        Me.Label19.TabIndex = 85
        Me.Label19.Text = ":"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(556, 286)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(19, 29)
        Me.Label20.TabIndex = 86
        Me.Label20.Text = ":"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkKioskOpen24
        '
        Me.chkKioskOpen24.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkKioskOpen24.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkKioskOpen24.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chkKioskOpen24.Location = New System.Drawing.Point(327, 256)
        Me.chkKioskOpen24.Name = "chkKioskOpen24"
        Me.chkKioskOpen24.Size = New System.Drawing.Size(22, 25)
        Me.chkKioskOpen24.TabIndex = 87
        Me.chkKioskOpen24.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(68, 255)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(175, 29)
        Me.Label21.TabIndex = 88
        Me.Label21.Text = "Open 24 Hours"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(574, 446)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 29)
        Me.Label22.TabIndex = 91
        Me.Label22.Text = "Month"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPassportExpire
        '
        Me.txtPassportExpire.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPassportExpire.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassportExpire.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtPassportExpire.Location = New System.Drawing.Point(327, 446)
        Me.txtPassportExpire.MaxLength = 15
        Me.txtPassportExpire.Name = "txtPassportExpire"
        Me.txtPassportExpire.Size = New System.Drawing.Size(207, 28)
        Me.txtPassportExpire.TabIndex = 89
        Me.txtPassportExpire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(71, 444)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(183, 29)
        Me.Label23.TabIndex = 90
        Me.Label23.Text = "Passport Expire"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactCenter
        '
        Me.txtContactCenter.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtContactCenter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContactCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtContactCenter.Location = New System.Drawing.Point(327, 477)
        Me.txtContactCenter.MaxLength = 15
        Me.txtContactCenter.Name = "txtContactCenter"
        Me.txtContactCenter.Size = New System.Drawing.Size(207, 28)
        Me.txtContactCenter.TabIndex = 92
        Me.txtContactCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(71, 475)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(172, 29)
        Me.Label24.TabIndex = 93
        Me.Label24.Text = "Contact Center"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(378, 508)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(19, 29)
        Me.Label25.TabIndex = 97
        Me.Label25.Text = ":"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSleepTimeM
        '
        Me.txtSleepTimeM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSleepTimeM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSleepTimeM.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSleepTimeM.Location = New System.Drawing.Point(400, 508)
        Me.txtSleepTimeM.MaxLength = 2
        Me.txtSleepTimeM.Name = "txtSleepTimeM"
        Me.txtSleepTimeM.Size = New System.Drawing.Size(52, 28)
        Me.txtSleepTimeM.TabIndex = 96
        Me.txtSleepTimeM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSleepTimeH
        '
        Me.txtSleepTimeH.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSleepTimeH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSleepTimeH.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSleepTimeH.Location = New System.Drawing.Point(327, 508)
        Me.txtSleepTimeH.MaxLength = 2
        Me.txtSleepTimeH.Name = "txtSleepTimeH"
        Me.txtSleepTimeH.Size = New System.Drawing.Size(52, 28)
        Me.txtSleepTimeH.TabIndex = 94
        Me.txtSleepTimeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(69, 508)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(139, 29)
        Me.Label26.TabIndex = 95
        Me.Label26.Text = "Sleep Time"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSleepDuration
        '
        Me.txtSleepDuration.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSleepDuration.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSleepDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtSleepDuration.Location = New System.Drawing.Point(327, 539)
        Me.txtSleepDuration.MaxLength = 15
        Me.txtSleepDuration.Name = "txtSleepDuration"
        Me.txtSleepDuration.Size = New System.Drawing.Size(207, 28)
        Me.txtSleepDuration.TabIndex = 98
        Me.txtSleepDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(71, 537)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(173, 29)
        Me.Label27.TabIndex = 99
        Me.Label27.Text = "Sleep Duration"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(576, 537)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(85, 29)
        Me.Label28.TabIndex = 100
        Me.Label28.Text = "Minute"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSC_KioskSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 764)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtSleepDuration)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtSleepTimeM)
        Me.Controls.Add(Me.txtSleepTimeH)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtContactCenter)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtPassportExpire)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.chkKioskOpen24)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtCloseTimeM)
        Me.Controls.Add(Me.txtCloseTimeH)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtOpenTimeM)
        Me.Controls.Add(Me.txtOpenTimeH)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtIDCardExpire)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkLoginSSO)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtMacAddress)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbNetworkDevice)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtExtend)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtScreenServer)
        Me.Controls.Add(Me.txtWebserviceURL)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTimeOut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtKioskID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_KioskSetting"
        Me.Text = "frmSC_KioskSetting"
        Me.btnCancel.ResumeLayout(False)
        Me.btnSave.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents txtKioskID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTimeOut As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtWebserviceURL As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtScreenServer As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCancel As Panel
    Friend WithEvents lblCancel As Label
    Friend WithEvents btnSave As Panel
    Friend WithEvents lblSave As Label
    Friend WithEvents Label10 As Label
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
    Friend WithEvents txtIDCardExpire As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtOpenTimeH As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtOpenTimeM As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCloseTimeM As TextBox
    Friend WithEvents txtCloseTimeH As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents chkKioskOpen24 As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtPassportExpire As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtContactCenter As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtSleepTimeM As TextBox
    Friend WithEvents txtSleepTimeH As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtSleepDuration As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
End Class
