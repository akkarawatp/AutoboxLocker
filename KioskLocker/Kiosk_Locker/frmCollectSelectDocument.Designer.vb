<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCollectSelectDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCollectSelectDocument))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.TimerTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.lblQRCodeNotification = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.PictureBox()
        Me.pbQRCode = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.btnOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 40.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(12, 50)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 124)
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "เลือกเอกสาร" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ที่จะใช้เปิดตู้ล็อกเกอร์"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerTimeOut
        '
        Me.TimerTimeOut.Enabled = True
        Me.TimerTimeOut.Interval = 1000
        '
        'lblQRCodeNotification
        '
        Me.lblQRCodeNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblQRCodeNotification.Font = New System.Drawing.Font("Thai Sans Lite", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblQRCodeNotification.ForeColor = System.Drawing.Color.Red
        Me.lblQRCodeNotification.Location = New System.Drawing.Point(579, 517)
        Me.lblQRCodeNotification.Name = "lblQRCodeNotification"
        Me.lblQRCodeNotification.Size = New System.Drawing.Size(340, 40)
        Me.lblQRCodeNotification.TabIndex = 95
        Me.lblQRCodeNotification.Text = "เครื่องไม่สามารถ สแกน QR Code"
        Me.lblQRCodeNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblQRCodeNotification.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.imgCollectSelectDocument
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.pbQRCode)
        Me.Panel1.Location = New System.Drawing.Point(164, 192)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(671, 322)
        Me.Panel1.TabIndex = 97
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
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(48, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 80)
        Me.PictureBox1.TabIndex = 108
        Me.PictureBox1.TabStop = False
        '
        'frmCollectSelectDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblQRCodeNotification)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCollectSelectDocument"
        Me.Panel1.ResumeLayout(False)
        CType(Me.btnOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Label
    Friend WithEvents TimerTimeOut As Timer
    Friend WithEvents lblQRCodeNotification As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pbQRCode As PictureBox
    Friend WithEvents btnOK As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
