<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSC_DialogSettingLocker
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
        Me.pnlDialog = New System.Windows.Forms.Panel()
        Me.btnCancelByAdmin = New System.Windows.Forms.Button()
        Me.lblAvailable = New System.Windows.Forms.Label()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.btnBlink = New System.Windows.Forms.Button()
        Me.lblSensorFlag = New System.Windows.Forms.Label()
        Me.btnStopSensor = New System.Windows.Forms.Button()
        Me.btnStopLED = New System.Windows.Forms.Button()
        Me.cbSensorPin = New System.Windows.Forms.ComboBox()
        Me.cbLEDPin = New System.Windows.Forms.ComboBox()
        Me.cbSolenoidPin = New System.Windows.Forms.ComboBox()
        Me.txtLockerName = New System.Windows.Forms.TextBox()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.lblLockerSize = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStartSensor = New System.Windows.Forms.Button()
        Me.btnStartLED = New System.Windows.Forms.Button()
        Me.btnOpenSoleniod = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Panel()
        Me.lblSave = New System.Windows.Forms.Label()
        Me.pnlDialog.SuspendLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnSave.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDialog
        '
        Me.pnlDialog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDialog.BackColor = System.Drawing.SystemColors.Control
        Me.pnlDialog.Controls.Add(Me.btnCancelByAdmin)
        Me.pnlDialog.Controls.Add(Me.lblAvailable)
        Me.pnlDialog.Controls.Add(Me.chkActive)
        Me.pnlDialog.Controls.Add(Me.btnBlink)
        Me.pnlDialog.Controls.Add(Me.lblSensorFlag)
        Me.pnlDialog.Controls.Add(Me.btnStopSensor)
        Me.pnlDialog.Controls.Add(Me.btnStopLED)
        Me.pnlDialog.Controls.Add(Me.cbSensorPin)
        Me.pnlDialog.Controls.Add(Me.cbLEDPin)
        Me.pnlDialog.Controls.Add(Me.cbSolenoidPin)
        Me.pnlDialog.Controls.Add(Me.txtLockerName)
        Me.pnlDialog.Controls.Add(Me.pbClose)
        Me.pnlDialog.Controls.Add(Me.lblLockerSize)
        Me.pnlDialog.Controls.Add(Me.Label6)
        Me.pnlDialog.Controls.Add(Me.Label4)
        Me.pnlDialog.Controls.Add(Me.btnStartSensor)
        Me.pnlDialog.Controls.Add(Me.btnStartLED)
        Me.pnlDialog.Controls.Add(Me.btnOpenSoleniod)
        Me.pnlDialog.Controls.Add(Me.Label3)
        Me.pnlDialog.Controls.Add(Me.Label2)
        Me.pnlDialog.Controls.Add(Me.Label1)
        Me.pnlDialog.Controls.Add(Me.btnSave)
        Me.pnlDialog.Location = New System.Drawing.Point(12, 12)
        Me.pnlDialog.Name = "pnlDialog"
        Me.pnlDialog.Size = New System.Drawing.Size(375, 279)
        Me.pnlDialog.TabIndex = 1
        '
        'btnCancelByAdmin
        '
        Me.btnCancelByAdmin.Location = New System.Drawing.Point(243, 163)
        Me.btnCancelByAdmin.Name = "btnCancelByAdmin"
        Me.btnCancelByAdmin.Size = New System.Drawing.Size(99, 26)
        Me.btnCancelByAdmin.TabIndex = 65
        Me.btnCancelByAdmin.Text = "Cancel by Admin"
        Me.btnCancelByAdmin.UseVisualStyleBackColor = True
        Me.btnCancelByAdmin.Visible = False
        '
        'lblAvailable
        '
        Me.lblAvailable.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAvailable.Location = New System.Drawing.Point(121, 165)
        Me.lblAvailable.Name = "lblAvailable"
        Me.lblAvailable.Size = New System.Drawing.Size(114, 24)
        Me.lblAvailable.TabIndex = 64
        Me.lblAvailable.Text = "Available"
        Me.lblAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkActive
        '
        Me.chkActive.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(124, 206)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(89, 17)
        Me.chkActive.TabIndex = 63
        Me.chkActive.Text = "Active Status"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'btnBlink
        '
        Me.btnBlink.Location = New System.Drawing.Point(236, 86)
        Me.btnBlink.Name = "btnBlink"
        Me.btnBlink.Size = New System.Drawing.Size(52, 26)
        Me.btnBlink.TabIndex = 62
        Me.btnBlink.Text = "Blink"
        Me.btnBlink.UseVisualStyleBackColor = True
        '
        'lblSensorFlag
        '
        Me.lblSensorFlag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblSensorFlag.Location = New System.Drawing.Point(302, 120)
        Me.lblSensorFlag.Name = "lblSensorFlag"
        Me.lblSensorFlag.Size = New System.Drawing.Size(58, 19)
        Me.lblSensorFlag.TabIndex = 61
        Me.lblSensorFlag.Text = "0"
        '
        'btnStopSensor
        '
        Me.btnStopSensor.Location = New System.Drawing.Point(243, 116)
        Me.btnStopSensor.Name = "btnStopSensor"
        Me.btnStopSensor.Size = New System.Drawing.Size(52, 26)
        Me.btnStopSensor.TabIndex = 60
        Me.btnStopSensor.Text = "Stop"
        Me.btnStopSensor.UseVisualStyleBackColor = True
        '
        'btnStopLED
        '
        Me.btnStopLED.Location = New System.Drawing.Point(290, 86)
        Me.btnStopLED.Name = "btnStopLED"
        Me.btnStopLED.Size = New System.Drawing.Size(52, 26)
        Me.btnStopLED.TabIndex = 59
        Me.btnStopLED.Text = "Stop"
        Me.btnStopLED.UseVisualStyleBackColor = True
        '
        'cbSensorPin
        '
        Me.cbSensorPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSensorPin.FormattingEnabled = True
        Me.cbSensorPin.Location = New System.Drawing.Point(125, 116)
        Me.cbSensorPin.Name = "cbSensorPin"
        Me.cbSensorPin.Size = New System.Drawing.Size(53, 21)
        Me.cbSensorPin.TabIndex = 58
        '
        'cbLEDPin
        '
        Me.cbLEDPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLEDPin.FormattingEnabled = True
        Me.cbLEDPin.Location = New System.Drawing.Point(125, 88)
        Me.cbLEDPin.Name = "cbLEDPin"
        Me.cbLEDPin.Size = New System.Drawing.Size(53, 21)
        Me.cbLEDPin.TabIndex = 57
        '
        'cbSolenoidPin
        '
        Me.cbSolenoidPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSolenoidPin.FormattingEnabled = True
        Me.cbSolenoidPin.Location = New System.Drawing.Point(125, 59)
        Me.cbSolenoidPin.Name = "cbSolenoidPin"
        Me.cbSolenoidPin.Size = New System.Drawing.Size(53, 21)
        Me.cbSolenoidPin.TabIndex = 56
        '
        'txtLockerName
        '
        Me.txtLockerName.Location = New System.Drawing.Point(124, 33)
        Me.txtLockerName.Name = "txtLockerName"
        Me.txtLockerName.Size = New System.Drawing.Size(161, 20)
        Me.txtLockerName.TabIndex = 55
        '
        'pbClose
        '
        Me.pbClose.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.IconClose
        Me.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbClose.Location = New System.Drawing.Point(340, 3)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(30, 31)
        Me.pbClose.TabIndex = 52
        Me.pbClose.TabStop = False
        '
        'lblLockerSize
        '
        Me.lblLockerSize.AutoSize = True
        Me.lblLockerSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLockerSize.Location = New System.Drawing.Point(129, 7)
        Me.lblLockerSize.Name = "lblLockerSize"
        Me.lblLockerSize.Size = New System.Drawing.Size(32, 20)
        Me.lblLockerSize.TabIndex = 51
        Me.lblLockerSize.Text = "SR"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(75, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 20)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Size :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 20)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Locker Name :"
        '
        'btnStartSensor
        '
        Me.btnStartSensor.Location = New System.Drawing.Point(184, 116)
        Me.btnStartSensor.Name = "btnStartSensor"
        Me.btnStartSensor.Size = New System.Drawing.Size(52, 26)
        Me.btnStartSensor.TabIndex = 47
        Me.btnStartSensor.Text = "Start"
        Me.btnStartSensor.UseVisualStyleBackColor = True
        '
        'btnStartLED
        '
        Me.btnStartLED.Location = New System.Drawing.Point(184, 86)
        Me.btnStartLED.Name = "btnStartLED"
        Me.btnStartLED.Size = New System.Drawing.Size(52, 26)
        Me.btnStartLED.TabIndex = 46
        Me.btnStartLED.Text = "Start"
        Me.btnStartLED.UseVisualStyleBackColor = True
        '
        'btnOpenSoleniod
        '
        Me.btnOpenSoleniod.Location = New System.Drawing.Point(184, 56)
        Me.btnOpenSoleniod.Name = "btnOpenSoleniod"
        Me.btnOpenSoleniod.Size = New System.Drawing.Size(114, 26)
        Me.btnOpenSoleniod.TabIndex = 45
        Me.btnOpenSoleniod.Text = "Open"
        Me.btnOpenSoleniod.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "SensorPin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 20)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "LedPin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "SoleniodPin"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnColWhite
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.Controls.Add(Me.lblSave)
        Me.btnSave.Location = New System.Drawing.Point(144, 229)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 37)
        Me.btnSave.TabIndex = 38
        '
        'lblSave
        '
        Me.lblSave.BackColor = System.Drawing.Color.Transparent
        Me.lblSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblSave.ForeColor = System.Drawing.Color.Black
        Me.lblSave.Location = New System.Drawing.Point(14, 7)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(64, 23)
        Me.lblSave.TabIndex = 39
        Me.lblSave.Text = "Save"
        Me.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSC_DialogSettingLocker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(399, 303)
        Me.Controls.Add(Me.pnlDialog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_DialogSettingLocker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDialog_OK"
        Me.pnlDialog.ResumeLayout(False)
        Me.pnlDialog.PerformLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnSave.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDialog As Panel
    Friend WithEvents btnSave As Panel
    Friend WithEvents lblSave As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnStartSensor As Button
    Friend WithEvents btnStartLED As Button
    Friend WithEvents btnOpenSoleniod As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lblLockerSize As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents pbClose As PictureBox
    Friend WithEvents txtLockerName As TextBox
    Friend WithEvents cbSolenoidPin As ComboBox
    Friend WithEvents cbLEDPin As ComboBox
    Friend WithEvents cbSensorPin As ComboBox
    Friend WithEvents btnStopLED As Button
    Friend WithEvents btnStopSensor As Button
    Friend WithEvents lblSensorFlag As Label
    Friend WithEvents btnBlink As Button
    Friend WithEvents lblAvailable As Label
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents btnCancelByAdmin As Button
End Class
