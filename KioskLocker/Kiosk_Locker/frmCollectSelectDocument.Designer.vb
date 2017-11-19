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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.TimerTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.pnlPinCode = New System.Windows.Forms.Panel()
        Me.lblCaptionPinCode = New System.Windows.Forms.Label()
        Me.pnlQRCode = New System.Windows.Forms.Panel()
        Me.lblQRCode = New System.Windows.Forms.Label()
        Me.lblQRCodeNotification = New System.Windows.Forms.Label()
        Me.lblLabelIDCardNotification = New System.Windows.Forms.Label()
        Me.lblImagePinCode = New System.Windows.Forms.Label()
        Me.pnlPinCode.SuspendLayout()
        Me.pnlQRCode.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 38)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 82)
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "เลือกเอกสารที่จะใช้เปิดตู้ล็อกเกอร์"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerTimeOut
        '
        Me.TimerTimeOut.Enabled = True
        Me.TimerTimeOut.Interval = 1000
        '
        'pnlPinCode
        '
        Me.pnlPinCode.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnPickupOpenLocker
        Me.pnlPinCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPinCode.Controls.Add(Me.lblImagePinCode)
        Me.pnlPinCode.Controls.Add(Me.lblCaptionPinCode)
        Me.pnlPinCode.Location = New System.Drawing.Point(548, 166)
        Me.pnlPinCode.Name = "pnlPinCode"
        Me.pnlPinCode.Size = New System.Drawing.Size(280, 280)
        Me.pnlPinCode.TabIndex = 15
        '
        'lblCaptionPinCode
        '
        Me.lblCaptionPinCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCaptionPinCode.Font = New System.Drawing.Font("Thai Sans Lite", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCaptionPinCode.Location = New System.Drawing.Point(0, 198)
        Me.lblCaptionPinCode.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCaptionPinCode.Name = "lblCaptionPinCode"
        Me.lblCaptionPinCode.Size = New System.Drawing.Size(280, 53)
        Me.lblCaptionPinCode.TabIndex = 19
        Me.lblCaptionPinCode.Text = "รหัสส่วนตัว"
        Me.lblCaptionPinCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlQRCode
        '
        Me.pnlQRCode.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.IconPickupQRCode
        Me.pnlQRCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlQRCode.Controls.Add(Me.lblQRCode)
        Me.pnlQRCode.Location = New System.Drawing.Point(173, 166)
        Me.pnlQRCode.Name = "pnlQRCode"
        Me.pnlQRCode.Size = New System.Drawing.Size(280, 280)
        Me.pnlQRCode.TabIndex = 14
        '
        'lblQRCode
        '
        Me.lblQRCode.BackColor = System.Drawing.Color.Transparent
        Me.lblQRCode.Font = New System.Drawing.Font("Thai Sans Lite", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblQRCode.Location = New System.Drawing.Point(0, 199)
        Me.lblQRCode.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQRCode.Name = "lblQRCode"
        Me.lblQRCode.Size = New System.Drawing.Size(280, 50)
        Me.lblQRCode.TabIndex = 18
        Me.lblQRCode.Text = "QR Code"
        Me.lblQRCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQRCodeNotification
        '
        Me.lblQRCodeNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblQRCodeNotification.Font = New System.Drawing.Font("Thai Sans Lite", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblQRCodeNotification.ForeColor = System.Drawing.Color.Red
        Me.lblQRCodeNotification.Location = New System.Drawing.Point(144, 449)
        Me.lblQRCodeNotification.Name = "lblQRCodeNotification"
        Me.lblQRCodeNotification.Size = New System.Drawing.Size(340, 64)
        Me.lblQRCodeNotification.TabIndex = 95
        Me.lblQRCodeNotification.Text = "เครื่องไม่สามารถ สแกน QR Code"
        Me.lblQRCodeNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblQRCodeNotification.Visible = False
        '
        'lblLabelIDCardNotification
        '
        Me.lblLabelIDCardNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelIDCardNotification.Font = New System.Drawing.Font("Thai Sans Lite", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabelIDCardNotification.ForeColor = System.Drawing.Color.Red
        Me.lblLabelIDCardNotification.Location = New System.Drawing.Point(502, 449)
        Me.lblLabelIDCardNotification.Name = "lblLabelIDCardNotification"
        Me.lblLabelIDCardNotification.Size = New System.Drawing.Size(368, 64)
        Me.lblLabelIDCardNotification.TabIndex = 96
        Me.lblLabelIDCardNotification.Text = "เครื่องไม่สามารถ อ่านเอกสาร"
        Me.lblLabelIDCardNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLabelIDCardNotification.Visible = False
        '
        'lblImagePinCode
        '
        Me.lblImagePinCode.BackColor = System.Drawing.Color.Transparent
        Me.lblImagePinCode.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblImagePinCode.Location = New System.Drawing.Point(0, 66)
        Me.lblImagePinCode.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImagePinCode.Name = "lblImagePinCode"
        Me.lblImagePinCode.Size = New System.Drawing.Size(280, 53)
        Me.lblImagePinCode.TabIndex = 20
        Me.lblImagePinCode.Text = "******"
        Me.lblImagePinCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCollectSelectDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.lblLabelIDCardNotification)
        Me.Controls.Add(Me.lblQRCodeNotification)
        Me.Controls.Add(Me.pnlPinCode)
        Me.Controls.Add(Me.pnlQRCode)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCollectSelectDocument"
        Me.pnlPinCode.ResumeLayout(False)
        Me.pnlQRCode.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Label
    Friend WithEvents TimerTimeOut As Timer
    Friend WithEvents pnlQRCode As Panel
    Friend WithEvents pnlPinCode As Panel
    Friend WithEvents lblCaptionPinCode As Label
    Friend WithEvents lblQRCode As Label
    Friend WithEvents lblQRCodeNotification As Label
    Friend WithEvents lblLabelIDCardNotification As Label
    Friend WithEvents lblImagePinCode As Label
End Class
