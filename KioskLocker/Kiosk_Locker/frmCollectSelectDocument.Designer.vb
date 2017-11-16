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
        Me.pnlIDCard = New System.Windows.Forms.Panel()
        Me.lblPassport = New System.Windows.Forms.Label()
        Me.lblIDCard = New System.Windows.Forms.Label()
        Me.pnlQRCode = New System.Windows.Forms.Panel()
        Me.lblQRCode = New System.Windows.Forms.Label()
        Me.lblQRCodeNotification = New System.Windows.Forms.Label()
        Me.lblLabelIDCardNotification = New System.Windows.Forms.Label()
        Me.pnlIDCard.SuspendLayout()
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
        'pnlIDCard
        '
        Me.pnlIDCard.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.IconPickupIDCard
        Me.pnlIDCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlIDCard.Controls.Add(Me.lblPassport)
        Me.pnlIDCard.Controls.Add(Me.lblIDCard)
        Me.pnlIDCard.Location = New System.Drawing.Point(548, 166)
        Me.pnlIDCard.Name = "pnlIDCard"
        Me.pnlIDCard.Size = New System.Drawing.Size(280, 280)
        Me.pnlIDCard.TabIndex = 15
        '
        'lblPassport
        '
        Me.lblPassport.BackColor = System.Drawing.Color.Transparent
        Me.lblPassport.Font = New System.Drawing.Font("Thai Sans Lite", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPassport.Location = New System.Drawing.Point(0, 210)
        Me.lblPassport.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPassport.Name = "lblPassport"
        Me.lblPassport.Size = New System.Drawing.Size(280, 50)
        Me.lblPassport.TabIndex = 20
        Me.lblPassport.Text = "หนังสือเดินทาง"
        Me.lblPassport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIDCard
        '
        Me.lblIDCard.BackColor = System.Drawing.Color.Transparent
        Me.lblIDCard.Font = New System.Drawing.Font("Thai Sans Lite", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblIDCard.Location = New System.Drawing.Point(0, 167)
        Me.lblIDCard.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIDCard.Name = "lblIDCard"
        Me.lblIDCard.Size = New System.Drawing.Size(280, 53)
        Me.lblIDCard.TabIndex = 19
        Me.lblIDCard.Text = "บัตรประชาชน /"
        Me.lblIDCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'frmCollectSelectDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.lblLabelIDCardNotification)
        Me.Controls.Add(Me.lblQRCodeNotification)
        Me.Controls.Add(Me.pnlIDCard)
        Me.Controls.Add(Me.pnlQRCode)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCollectSelectDocument"
        Me.pnlIDCard.ResumeLayout(False)
        Me.pnlQRCode.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Label
    Friend WithEvents TimerTimeOut As Timer
    Friend WithEvents pnlQRCode As Panel
    Friend WithEvents pnlIDCard As Panel
    Friend WithEvents lblPassport As Label
    Friend WithEvents lblIDCard As Label
    Friend WithEvents lblQRCode As Label
    Friend WithEvents lblQRCodeNotification As Label
    Friend WithEvents lblLabelIDCardNotification As Label
End Class
