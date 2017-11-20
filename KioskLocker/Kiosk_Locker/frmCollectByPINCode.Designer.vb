<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCollectByPINCode
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.TimerTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.txtPinCode = New System.Windows.Forms.TextBox()
        Me.lblLabelNotification = New System.Windows.Forms.Label()
        Me.btn1 = New System.Windows.Forms.PictureBox()
        Me.btn2 = New System.Windows.Forms.PictureBox()
        Me.btn3 = New System.Windows.Forms.PictureBox()
        Me.btn6 = New System.Windows.Forms.PictureBox()
        Me.btn5 = New System.Windows.Forms.PictureBox()
        Me.btn4 = New System.Windows.Forms.PictureBox()
        Me.btn9 = New System.Windows.Forms.PictureBox()
        Me.btn8 = New System.Windows.Forms.PictureBox()
        Me.btn7 = New System.Windows.Forms.PictureBox()
        Me.btnBackSpace = New System.Windows.Forms.PictureBox()
        Me.btn0 = New System.Windows.Forms.PictureBox()
        Me.btnClear = New System.Windows.Forms.PictureBox()
        CType(Me.btn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBackSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 32)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 90)
        Me.lblTitle.TabIndex = 46
        Me.lblTitle.Text = "ใส่รหัสส่วนตัว"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerTimeOut
        '
        Me.TimerTimeOut.Interval = 1000
        '
        'txtPinCode
        '
        Me.txtPinCode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPinCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPinCode.Enabled = False
        Me.txtPinCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPinCode.Location = New System.Drawing.Point(103, 182)
        Me.txtPinCode.MaxLength = 15
        Me.txtPinCode.Name = "txtPinCode"
        Me.txtPinCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPinCode.Size = New System.Drawing.Size(374, 46)
        Me.txtPinCode.TabIndex = 47
        Me.txtPinCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLabelNotification
        '
        Me.lblLabelNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelNotification.Font = New System.Drawing.Font("Thai Sans Lite", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabelNotification.ForeColor = System.Drawing.Color.Red
        Me.lblLabelNotification.Location = New System.Drawing.Point(12, 501)
        Me.lblLabelNotification.Name = "lblLabelNotification"
        Me.lblLabelNotification.Size = New System.Drawing.Size(1000, 43)
        Me.lblLabelNotification.TabIndex = 93
        Me.lblLabelNotification.Text = "กรุณาใส่รหัสส่วนตัว {0} หลักสำหรับรับคืนสัมภาระ"
        Me.lblLabelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn1
        '
        Me.btn1.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber1
        Me.btn1.Location = New System.Drawing.Point(609, 158)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(70, 70)
        Me.btn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn1.TabIndex = 94
        Me.btn1.TabStop = False
        '
        'btn2
        '
        Me.btn2.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber2
        Me.btn2.Location = New System.Drawing.Point(688, 158)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(70, 70)
        Me.btn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn2.TabIndex = 95
        Me.btn2.TabStop = False
        '
        'btn3
        '
        Me.btn3.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber3
        Me.btn3.Location = New System.Drawing.Point(767, 158)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(70, 70)
        Me.btn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn3.TabIndex = 96
        Me.btn3.TabStop = False
        '
        'btn6
        '
        Me.btn6.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber6
        Me.btn6.Location = New System.Drawing.Point(767, 231)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(70, 70)
        Me.btn6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn6.TabIndex = 99
        Me.btn6.TabStop = False
        '
        'btn5
        '
        Me.btn5.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber5
        Me.btn5.Location = New System.Drawing.Point(688, 231)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(70, 70)
        Me.btn5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn5.TabIndex = 98
        Me.btn5.TabStop = False
        '
        'btn4
        '
        Me.btn4.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber4
        Me.btn4.Location = New System.Drawing.Point(609, 231)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(70, 70)
        Me.btn4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn4.TabIndex = 97
        Me.btn4.TabStop = False
        '
        'btn9
        '
        Me.btn9.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber9
        Me.btn9.Location = New System.Drawing.Point(767, 304)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(70, 70)
        Me.btn9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn9.TabIndex = 102
        Me.btn9.TabStop = False
        '
        'btn8
        '
        Me.btn8.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber8
        Me.btn8.Location = New System.Drawing.Point(688, 304)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(70, 70)
        Me.btn8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn8.TabIndex = 101
        Me.btn8.TabStop = False
        '
        'btn7
        '
        Me.btn7.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber7
        Me.btn7.Location = New System.Drawing.Point(609, 304)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(70, 70)
        Me.btn7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn7.TabIndex = 100
        Me.btn7.TabStop = False
        '
        'btnBackSpace
        '
        Me.btnBackSpace.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonBackSpace
        Me.btnBackSpace.Location = New System.Drawing.Point(767, 377)
        Me.btnBackSpace.Name = "btnBackSpace"
        Me.btnBackSpace.Size = New System.Drawing.Size(70, 70)
        Me.btnBackSpace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnBackSpace.TabIndex = 105
        Me.btnBackSpace.TabStop = False
        '
        'btn0
        '
        Me.btn0.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonNumber0
        Me.btn0.Location = New System.Drawing.Point(688, 377)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(70, 70)
        Me.btn0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn0.TabIndex = 104
        Me.btn0.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Image = Global.AutoboxLocker.My.Resources.Resources.imgButtonClear
        Me.btnClear.Location = New System.Drawing.Point(609, 377)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(70, 70)
        Me.btnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClear.TabIndex = 103
        Me.btnClear.TabStop = False
        '
        'frmCollectByPINCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.btnBackSpace)
        Me.Controls.Add(Me.btn0)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.lblLabelNotification)
        Me.Controls.Add(Me.txtPinCode)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCollectByPINCode"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.btn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBackSpace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As Label
    Friend WithEvents TimerTimeOut As Timer
    Friend WithEvents txtPinCode As TextBox
    Friend WithEvents lblLabelNotification As Label
    Friend WithEvents btn1 As PictureBox
    Friend WithEvents btn2 As PictureBox
    Friend WithEvents btn3 As PictureBox
    Friend WithEvents btn6 As PictureBox
    Friend WithEvents btn5 As PictureBox
    Friend WithEvents btn4 As PictureBox
    Friend WithEvents btn9 As PictureBox
    Friend WithEvents btn8 As PictureBox
    Friend WithEvents btn7 As PictureBox
    Friend WithEvents btnBackSpace As PictureBox
    Friend WithEvents btn0 As PictureBox
    Friend WithEvents btnClear As PictureBox
End Class
