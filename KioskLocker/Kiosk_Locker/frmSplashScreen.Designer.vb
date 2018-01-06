<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplashScreen
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCPUID = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lblReadingKey = New System.Windows.Forms.Label()
        Me.btnDeleteKey = New System.Windows.Forms.Button()
        Me.txtProcessorID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlDBLogin = New System.Windows.Forms.Panel()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDBPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProgressStatus = New System.Windows.Forms.TextBox()
        Me.cbUnRegisLocker = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlDBLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CPU ID"
        '
        'txtCPUID
        '
        Me.txtCPUID.Location = New System.Drawing.Point(123, 38)
        Me.txtCPUID.Name = "txtCPUID"
        Me.txtCPUID.Size = New System.Drawing.Size(538, 20)
        Me.txtCPUID.TabIndex = 1
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(589, 316)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lblReadingKey
        '
        Me.lblReadingKey.AutoSize = True
        Me.lblReadingKey.Location = New System.Drawing.Point(66, 110)
        Me.lblReadingKey.Name = "lblReadingKey"
        Me.lblReadingKey.Size = New System.Drawing.Size(0, 13)
        Me.lblReadingKey.TabIndex = 5
        Me.lblReadingKey.Visible = False
        '
        'btnDeleteKey
        '
        Me.btnDeleteKey.Location = New System.Drawing.Point(18, 316)
        Me.btnDeleteKey.Name = "btnDeleteKey"
        Me.btnDeleteKey.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteKey.TabIndex = 6
        Me.btnDeleteKey.Text = "Delete Key"
        Me.btnDeleteKey.UseVisualStyleBackColor = True
        Me.btnDeleteKey.Visible = False
        '
        'txtProcessorID
        '
        Me.txtProcessorID.Location = New System.Drawing.Point(123, 61)
        Me.txtProcessorID.Name = "txtProcessorID"
        Me.txtProcessorID.Size = New System.Drawing.Size(538, 20)
        Me.txtProcessorID.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Processor ID"
        '
        'pnlDBLogin
        '
        Me.pnlDBLogin.Controls.Add(Me.cbUnRegisLocker)
        Me.pnlDBLogin.Controls.Add(Me.Label8)
        Me.pnlDBLogin.Controls.Add(Me.txtDatabaseName)
        Me.pnlDBLogin.Controls.Add(Me.Label5)
        Me.pnlDBLogin.Controls.Add(Me.txtDBPassword)
        Me.pnlDBLogin.Controls.Add(Me.Label4)
        Me.pnlDBLogin.Location = New System.Drawing.Point(17, 12)
        Me.pnlDBLogin.Name = "pnlDBLogin"
        Me.pnlDBLogin.Size = New System.Drawing.Size(647, 82)
        Me.pnlDBLogin.TabIndex = 10
        Me.pnlDBLogin.Visible = False
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Enabled = False
        Me.txtDatabaseName.Location = New System.Drawing.Point(230, 54)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(232, 20)
        Me.txtDatabaseName.TabIndex = 3
        Me.txtDatabaseName.Text = "Minibox"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(127, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Database Name"
        '
        'txtDBPassword
        '
        Me.txtDBPassword.Location = New System.Drawing.Point(230, 6)
        Me.txtDBPassword.Name = "txtDBPassword"
        Me.txtDBPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtDBPassword.Size = New System.Drawing.Size(232, 20)
        Me.txtDBPassword.TabIndex = 1
        Me.txtDBPassword.Text = "1qaz@WSX"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(85, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Login With sa Password"
        '
        'txtProgressStatus
        '
        Me.txtProgressStatus.Location = New System.Drawing.Point(17, 100)
        Me.txtProgressStatus.Multiline = True
        Me.txtProgressStatus.Name = "txtProgressStatus"
        Me.txtProgressStatus.ReadOnly = True
        Me.txtProgressStatus.Size = New System.Drawing.Size(647, 210)
        Me.txtProgressStatus.TabIndex = 12
        '
        'cbUnRegisLocker
        '
        Me.cbUnRegisLocker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUnRegisLocker.FormattingEnabled = True
        Me.cbUnRegisLocker.Location = New System.Drawing.Point(230, 29)
        Me.cbUnRegisLocker.Name = "cbUnRegisLocker"
        Me.cbUnRegisLocker.Size = New System.Drawing.Size(412, 21)
        Me.cbUnRegisLocker.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(127, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Minibox Locker"
        '
        'frmSplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 344)
        Me.Controls.Add(Me.txtProgressStatus)
        Me.Controls.Add(Me.pnlDBLogin)
        Me.Controls.Add(Me.txtProcessorID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnDeleteKey)
        Me.Controls.Add(Me.lblReadingKey)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.txtCPUID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSplashScreen"
        Me.Text = "Setup New Minibox Locker"
        Me.pnlDBLogin.ResumeLayout(False)
        Me.pnlDBLogin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCPUID As TextBox
    Friend WithEvents btnNext As Button
    Friend WithEvents lblReadingKey As Label
    Friend WithEvents btnDeleteKey As Button
    Friend WithEvents txtProcessorID As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlDBLogin As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDatabaseName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDBPassword As TextBox
    Friend WithEvents txtProgressStatus As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbUnRegisLocker As ComboBox
End Class
