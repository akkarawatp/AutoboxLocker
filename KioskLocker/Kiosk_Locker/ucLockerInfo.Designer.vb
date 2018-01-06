<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucLockerInfo
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblSolinoidPin = New System.Windows.Forms.Label()
        Me.lblSensorPin = New System.Windows.Forms.Label()
        Me.lblLEDPin = New System.Windows.Forms.Label()
        Me.cbSolenoidPin = New System.Windows.Forms.ComboBox()
        Me.cbLEDPin = New System.Windows.Forms.ComboBox()
        Me.cbSensorPin = New System.Windows.Forms.ComboBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtLockerName = New System.Windows.Forms.Label()
        Me.pbLockerName = New System.Windows.Forms.PictureBox()
        CType(Me.pbLockerName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSolinoidPin
        '
        Me.lblSolinoidPin.AutoSize = True
        Me.lblSolinoidPin.Location = New System.Drawing.Point(-1, 25)
        Me.lblSolinoidPin.Name = "lblSolinoidPin"
        Me.lblSolinoidPin.Size = New System.Drawing.Size(37, 13)
        Me.lblSolinoidPin.TabIndex = 0
        Me.lblSolinoidPin.Text = "SolPin"
        '
        'lblSensorPin
        '
        Me.lblSensorPin.AutoSize = True
        Me.lblSensorPin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblSensorPin.Location = New System.Drawing.Point(3, 112)
        Me.lblSensorPin.Name = "lblSensorPin"
        Me.lblSensorPin.Size = New System.Drawing.Size(55, 13)
        Me.lblSensorPin.TabIndex = 8
        Me.lblSensorPin.Text = "SensorPin"
        '
        'lblLEDPin
        '
        Me.lblLEDPin.AutoSize = True
        Me.lblLEDPin.Location = New System.Drawing.Point(3, 69)
        Me.lblLEDPin.Name = "lblLEDPin"
        Me.lblLEDPin.Size = New System.Drawing.Size(40, 13)
        Me.lblLEDPin.TabIndex = 6
        Me.lblLEDPin.Text = "LedPin"
        '
        'cbSolenoidPin
        '
        Me.cbSolenoidPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSolenoidPin.FormattingEnabled = True
        Me.cbSolenoidPin.Location = New System.Drawing.Point(1, 41)
        Me.cbSolenoidPin.Name = "cbSolenoidPin"
        Me.cbSolenoidPin.Size = New System.Drawing.Size(65, 21)
        Me.cbSolenoidPin.TabIndex = 15
        '
        'cbLEDPin
        '
        Me.cbLEDPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLEDPin.FormattingEnabled = True
        Me.cbLEDPin.Location = New System.Drawing.Point(1, 85)
        Me.cbLEDPin.Name = "cbLEDPin"
        Me.cbLEDPin.Size = New System.Drawing.Size(65, 21)
        Me.cbLEDPin.TabIndex = 16
        '
        'cbSensorPin
        '
        Me.cbSensorPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSensorPin.FormattingEnabled = True
        Me.cbSensorPin.Location = New System.Drawing.Point(1, 128)
        Me.cbSensorPin.Name = "cbSensorPin"
        Me.cbSensorPin.Size = New System.Drawing.Size(65, 21)
        Me.cbSensorPin.TabIndex = 17
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(14, 14)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(37, 13)
        Me.lblName.TabIndex = 18
        Me.lblName.Text = "SolPin"
        Me.lblName.Visible = False
        '
        'txtLockerName
        '
        Me.txtLockerName.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtLockerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtLockerName.ForeColor = System.Drawing.Color.White
        Me.txtLockerName.Location = New System.Drawing.Point(12, 1)
        Me.txtLockerName.Name = "txtLockerName"
        Me.txtLockerName.Size = New System.Drawing.Size(46, 15)
        Me.txtLockerName.TabIndex = 19
        Me.txtLockerName.Text = "S01"
        Me.txtLockerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbLockerName
        '
        Me.pbLockerName.Image = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.pbLockerName.Location = New System.Drawing.Point(0, 0)
        Me.pbLockerName.Name = "pbLockerName"
        Me.pbLockerName.Size = New System.Drawing.Size(68, 16)
        Me.pbLockerName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLockerName.TabIndex = 20
        Me.pbLockerName.TabStop = False
        '
        'ucLockerInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txtLockerName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.cbSensorPin)
        Me.Controls.Add(Me.cbLEDPin)
        Me.Controls.Add(Me.cbSolenoidPin)
        Me.Controls.Add(Me.lblSensorPin)
        Me.Controls.Add(Me.lblLEDPin)
        Me.Controls.Add(Me.lblSolinoidPin)
        Me.Controls.Add(Me.pbLockerName)
        Me.Name = "ucLockerInfo"
        Me.Size = New System.Drawing.Size(68, 152)
        CType(Me.pbLockerName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSolinoidPin As Label
    Friend WithEvents lblSensorPin As Label
    Friend WithEvents lblLEDPin As Label
    Friend WithEvents cbSolenoidPin As ComboBox
    Friend WithEvents cbLEDPin As ComboBox
    Friend WithEvents cbSensorPin As ComboBox
    Friend WithEvents lblName As Label
    Friend WithEvents txtLockerName As Label
    Friend WithEvents pbLockerName As PictureBox
End Class
