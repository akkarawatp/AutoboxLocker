<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDepositPrintQRCode
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
        Me.lblTimeOut = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblLabelNotification = New System.Windows.Forms.Label()
        Me.lblChangeAmt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbIconQRCode = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbIconQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTimeOut
        '
        Me.lblTimeOut.AutoSize = True
        Me.lblTimeOut.Location = New System.Drawing.Point(534, 9)
        Me.lblTimeOut.Name = "lblTimeOut"
        Me.lblTimeOut.Size = New System.Drawing.Size(13, 13)
        Me.lblTimeOut.TabIndex = 40
        Me.lblTimeOut.Text = "0"
        Me.lblTimeOut.Visible = False
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(12, 41)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 85)
        Me.lblTitle.TabIndex = 43
        Me.lblTitle.Text = "รับ QR Code และ เงินทอน"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabelNotification
        '
        Me.lblLabelNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelNotification.Font = New System.Drawing.Font("Thai Sans Lite", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabelNotification.ForeColor = System.Drawing.Color.Red
        Me.lblLabelNotification.Location = New System.Drawing.Point(12, 452)
        Me.lblLabelNotification.Name = "lblLabelNotification"
        Me.lblLabelNotification.Size = New System.Drawing.Size(1000, 75)
        Me.lblLabelNotification.TabIndex = 92
        Me.lblLabelNotification.Text = "กรุณาเก็บ QR Code นี้ไว้" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "สำหรับใช้เปิดช่องฝากเพื่อรับสัมภาระคืน"
        Me.lblLabelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLabelNotification.Visible = False
        '
        'lblChangeAmt
        '
        Me.lblChangeAmt.Font = New System.Drawing.Font("Thai Sans Lite", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeAmt.Location = New System.Drawing.Point(654, 128)
        Me.lblChangeAmt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblChangeAmt.Name = "lblChangeAmt"
        Me.lblChangeAmt.Size = New System.Drawing.Size(219, 116)
        Me.lblChangeAmt.TabIndex = 93
        Me.lblChangeAmt.Text = "8888"
        Me.lblChangeAmt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Thai Sans Lite", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(831, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 72)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "฿"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.AutoboxLocker.My.Resources.Resources.IconReceiveChange
        Me.PictureBox2.Location = New System.Drawing.Point(693, 247)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(140, 174)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 96
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AutoboxLocker.My.Resources.Resources.IconRods
        Me.PictureBox1.Location = New System.Drawing.Point(508, 128)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(10, 321)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 95
        Me.PictureBox1.TabStop = False
        '
        'pbIconQRCode
        '
        Me.pbIconQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbIconQRCode.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.IconPrintQRCode
        Me.pbIconQRCode.Location = New System.Drawing.Point(97, 128)
        Me.pbIconQRCode.Name = "pbIconQRCode"
        Me.pbIconQRCode.Size = New System.Drawing.Size(286, 321)
        Me.pbIconQRCode.TabIndex = 44
        Me.pbIconQRCode.TabStop = False
        '
        'frmDepositPrintQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblChangeAmt)
        Me.Controls.Add(Me.lblLabelNotification)
        Me.Controls.Add(Me.pbIconQRCode)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTimeOut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDepositPrintQRCode"
        Me.Text = "ขอบคุณที่ใช้บริการ"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbIconQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTimeOut As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pbIconQRCode As PictureBox
    Friend WithEvents lblLabelNotification As Label
    Friend WithEvents lblChangeAmt As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
