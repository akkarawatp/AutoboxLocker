﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCollectScanQRCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCollectScanQRCode))
        Me.txtQRCode = New System.Windows.Forms.TextBox()
        Me.TimerTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPincode = New System.Windows.Forms.TextBox()
        Me.btnNumber0 = New System.Windows.Forms.PictureBox()
        Me.btnDel = New System.Windows.Forms.PictureBox()
        Me.btnNumber9 = New System.Windows.Forms.PictureBox()
        Me.btnNumber8 = New System.Windows.Forms.PictureBox()
        Me.btnNumber7 = New System.Windows.Forms.PictureBox()
        Me.btnNumber6 = New System.Windows.Forms.PictureBox()
        Me.btnNumber5 = New System.Windows.Forms.PictureBox()
        Me.btnNumber4 = New System.Windows.Forms.PictureBox()
        Me.btnNumber3 = New System.Windows.Forms.PictureBox()
        Me.btnNumber2 = New System.Windows.Forms.PictureBox()
        Me.btnNumber1 = New System.Windows.Forms.PictureBox()
        Me.cbLocker = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.PictureBox()
        Me.pbQRCode = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.btnNumber0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNumber1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtQRCode
        '
        Me.txtQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtQRCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQRCode.Location = New System.Drawing.Point(378, 248)
        Me.txtQRCode.Name = "txtQRCode"
        Me.txtQRCode.Size = New System.Drawing.Size(249, 16)
        Me.txtQRCode.TabIndex = 0
        '
        'TimerTimeOut
        '
        Me.TimerTimeOut.Enabled = True
        Me.TimerTimeOut.Interval = 1000
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(48, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 80)
        Me.PictureBox1.TabIndex = 110
        Me.PictureBox1.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 40.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(12, 65)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 137)
        Me.lblTitle.TabIndex = 109
        Me.lblTitle.Text = "เลือกเอกสาร" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ที่จะใช้เปิดตู้ล็อกเกอร์"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.imgCollectSelectDocument
        Me.Panel1.Controls.Add(Me.txtPincode)
        Me.Panel1.Controls.Add(Me.btnNumber0)
        Me.Panel1.Controls.Add(Me.btnDel)
        Me.Panel1.Controls.Add(Me.btnNumber9)
        Me.Panel1.Controls.Add(Me.btnNumber8)
        Me.Panel1.Controls.Add(Me.btnNumber7)
        Me.Panel1.Controls.Add(Me.btnNumber6)
        Me.Panel1.Controls.Add(Me.btnNumber5)
        Me.Panel1.Controls.Add(Me.btnNumber4)
        Me.Panel1.Controls.Add(Me.btnNumber3)
        Me.Panel1.Controls.Add(Me.btnNumber2)
        Me.Panel1.Controls.Add(Me.btnNumber1)
        Me.Panel1.Controls.Add(Me.cbLocker)
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.pbQRCode)
        Me.Panel1.Location = New System.Drawing.Point(177, 238)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(671, 322)
        Me.Panel1.TabIndex = 111
        '
        'txtPincode
        '
        Me.txtPincode.BackColor = System.Drawing.Color.White
        Me.txtPincode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPincode.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPincode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtPincode.Location = New System.Drawing.Point(65, 217)
        Me.txtPincode.Name = "txtPincode"
        Me.txtPincode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPincode.Size = New System.Drawing.Size(100, 31)
        Me.txtPincode.TabIndex = 14
        Me.txtPincode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnNumber0
        '
        Me.btnNumber0.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber0.Location = New System.Drawing.Point(295, 216)
        Me.btnNumber0.Name = "btnNumber0"
        Me.btnNumber0.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber0.TabIndex = 13
        Me.btnNumber0.TabStop = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.Transparent
        Me.btnDel.Location = New System.Drawing.Point(239, 216)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(52, 52)
        Me.btnDel.TabIndex = 12
        Me.btnDel.TabStop = False
        '
        'btnNumber9
        '
        Me.btnNumber9.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber9.Location = New System.Drawing.Point(350, 161)
        Me.btnNumber9.Name = "btnNumber9"
        Me.btnNumber9.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber9.TabIndex = 11
        Me.btnNumber9.TabStop = False
        '
        'btnNumber8
        '
        Me.btnNumber8.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber8.Location = New System.Drawing.Point(295, 161)
        Me.btnNumber8.Name = "btnNumber8"
        Me.btnNumber8.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber8.TabIndex = 10
        Me.btnNumber8.TabStop = False
        '
        'btnNumber7
        '
        Me.btnNumber7.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber7.Location = New System.Drawing.Point(239, 161)
        Me.btnNumber7.Name = "btnNumber7"
        Me.btnNumber7.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber7.TabIndex = 9
        Me.btnNumber7.TabStop = False
        '
        'btnNumber6
        '
        Me.btnNumber6.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber6.Location = New System.Drawing.Point(350, 105)
        Me.btnNumber6.Name = "btnNumber6"
        Me.btnNumber6.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber6.TabIndex = 8
        Me.btnNumber6.TabStop = False
        '
        'btnNumber5
        '
        Me.btnNumber5.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber5.Location = New System.Drawing.Point(295, 105)
        Me.btnNumber5.Name = "btnNumber5"
        Me.btnNumber5.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber5.TabIndex = 7
        Me.btnNumber5.TabStop = False
        '
        'btnNumber4
        '
        Me.btnNumber4.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber4.Location = New System.Drawing.Point(239, 105)
        Me.btnNumber4.Name = "btnNumber4"
        Me.btnNumber4.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber4.TabIndex = 6
        Me.btnNumber4.TabStop = False
        '
        'btnNumber3
        '
        Me.btnNumber3.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber3.Location = New System.Drawing.Point(350, 50)
        Me.btnNumber3.Name = "btnNumber3"
        Me.btnNumber3.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber3.TabIndex = 5
        Me.btnNumber3.TabStop = False
        '
        'btnNumber2
        '
        Me.btnNumber2.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber2.Location = New System.Drawing.Point(295, 50)
        Me.btnNumber2.Name = "btnNumber2"
        Me.btnNumber2.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber2.TabIndex = 4
        Me.btnNumber2.TabStop = False
        '
        'btnNumber1
        '
        Me.btnNumber1.BackColor = System.Drawing.Color.Transparent
        Me.btnNumber1.Location = New System.Drawing.Point(239, 50)
        Me.btnNumber1.Name = "btnNumber1"
        Me.btnNumber1.Size = New System.Drawing.Size(52, 52)
        Me.btnNumber1.TabIndex = 3
        Me.btnNumber1.TabStop = False
        '
        'cbLocker
        '
        Me.cbLocker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLocker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbLocker.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbLocker.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cbLocker.FormattingEnabled = True
        Me.cbLocker.Location = New System.Drawing.Point(33, 97)
        Me.cbLocker.Name = "cbLocker"
        Me.cbLocker.Size = New System.Drawing.Size(170, 47)
        Me.cbLocker.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Location = New System.Drawing.Point(351, 216)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(52, 52)
        Me.btnOK.TabIndex = 1
        Me.btnOK.TabStop = False
        '
        'pbQRCode
        '
        Me.pbQRCode.BackColor = System.Drawing.Color.Transparent
        Me.pbQRCode.Location = New System.Drawing.Point(490, 3)
        Me.pbQRCode.Name = "pbQRCode"
        Me.pbQRCode.Size = New System.Drawing.Size(180, 318)
        Me.pbQRCode.TabIndex = 0
        Me.pbQRCode.TabStop = False
        '
        'frmCollectScanQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtQRCode)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCollectScanQRCode"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnNumber0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNumber1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQRCode As TextBox
    Friend WithEvents TimerTimeOut As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cbLocker As ComboBox
    Friend WithEvents btnOK As PictureBox
    Friend WithEvents pbQRCode As PictureBox
    Friend WithEvents btnNumber0 As PictureBox
    Friend WithEvents btnDel As PictureBox
    Friend WithEvents btnNumber9 As PictureBox
    Friend WithEvents btnNumber8 As PictureBox
    Friend WithEvents btnNumber7 As PictureBox
    Friend WithEvents btnNumber6 As PictureBox
    Friend WithEvents btnNumber5 As PictureBox
    Friend WithEvents btnNumber4 As PictureBox
    Friend WithEvents btnNumber3 As PictureBox
    Friend WithEvents btnNumber2 As PictureBox
    Friend WithEvents btnNumber1 As PictureBox
    Friend WithEvents txtPincode As TextBox
End Class
