<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestSolenoid
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cbbPin = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbbComport = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSolenoidOpen = New System.Windows.Forms.Button()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(84, 126)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(222, 23)
        Me.TextBox1.TabIndex = 62
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Black
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(84, 64)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(222, 24)
        Me.lblStatus.TabIndex = 61
        Me.lblStatus.Text = "Disconnected"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbbPin
        '
        Me.cbbPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbPin.FormattingEnabled = True
        Me.cbbPin.Location = New System.Drawing.Point(229, 37)
        Me.cbbPin.Name = "cbbPin"
        Me.cbbPin.Size = New System.Drawing.Size(77, 24)
        Me.cbbPin.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(187, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Pin :"
        '
        'cbbComport
        '
        Me.cbbComport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbComport.FormattingEnabled = True
        Me.cbbComport.Location = New System.Drawing.Point(84, 37)
        Me.cbbComport.Name = "cbbComport"
        Me.cbbComport.Size = New System.Drawing.Size(91, 24)
        Me.cbbComport.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Com Port :"
        '
        'btnSolenoidOpen
        '
        Me.btnSolenoidOpen.Location = New System.Drawing.Point(84, 91)
        Me.btnSolenoidOpen.Name = "btnSolenoidOpen"
        Me.btnSolenoidOpen.Size = New System.Drawing.Size(107, 29)
        Me.btnSolenoidOpen.TabIndex = 63
        Me.btnSolenoidOpen.Text = "Open"
        Me.btnSolenoidOpen.UseVisualStyleBackColor = True
        '
        'lblHead
        '
        Me.lblHead.BackColor = System.Drawing.Color.SteelBlue
        Me.lblHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.White
        Me.lblHead.Location = New System.Drawing.Point(0, 0)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(320, 30)
        Me.lblHead.TabIndex = 65
        Me.lblHead.Text = "Test Solenoid"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(199, 91)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(107, 29)
        Me.btnClose.TabIndex = 66
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'TestSolenoid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblHead)
        Me.Controls.Add(Me.btnSolenoidOpen)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cbbPin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbbComport)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "TestSolenoid"
        Me.Size = New System.Drawing.Size(320, 159)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cbbPin As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbbComport As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSolenoidOpen As System.Windows.Forms.Button
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
