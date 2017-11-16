<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDepositPayment
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
        Me.tmPaymentTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.btn1000 = New System.Windows.Forms.Button()
        Me.btn500 = New System.Windows.Forms.Button()
        Me.btn100 = New System.Windows.Forms.Button()
        Me.btn50 = New System.Windows.Forms.Button()
        Me.btn20 = New System.Windows.Forms.Button()
        Me.btn10 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.lblLabelPaid = New System.Windows.Forms.Label()
        Me.lblPaidAmt = New System.Windows.Forms.Label()
        Me.lblPaidTHB = New System.Windows.Forms.Label()
        Me.lblLabelDepositAmt = New System.Windows.Forms.Label()
        Me.lblDepositAmt = New System.Windows.Forms.Label()
        Me.lblDepositTHB = New System.Windows.Forms.Label()
        Me.pnlLockerName = New System.Windows.Forms.Panel()
        Me.lblLabelLockerName = New System.Windows.Forms.Label()
        Me.lblLockerName = New System.Windows.Forms.Label()
        Me.lblLabelChange = New System.Windows.Forms.Label()
        Me.lblChangeAmt = New System.Windows.Forms.Label()
        Me.lblChangeTHB = New System.Windows.Forms.Label()
        Me.lblPaidRemain = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPleasePaid = New System.Windows.Forms.Label()
        Me.pnlPickupOpenLocker = New System.Windows.Forms.Panel()
        Me.lblCollectOpenLocker = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tmOpenLockerTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.lblPleasePaidComplete = New System.Windows.Forms.Label()
        Me.pnlServiceAmt = New System.Windows.Forms.Panel()
        Me.lblServiceTHB = New System.Windows.Forms.Label()
        Me.lblServiceAmt = New System.Windows.Forms.Label()
        Me.lblLabelServiceAmt = New System.Windows.Forms.Label()
        Me.pnlDepositAmt = New System.Windows.Forms.Panel()
        Me.pnlLockerName.SuspendLayout()
        Me.pnlPickupOpenLocker.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlServiceAmt.SuspendLayout()
        Me.pnlDepositAmt.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmPaymentTimeOut
        '
        Me.tmPaymentTimeOut.Interval = 1000
        '
        'btn1000
        '
        Me.btn1000.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn1000.Location = New System.Drawing.Point(27, 23)
        Me.btn1000.Name = "btn1000"
        Me.btn1000.Size = New System.Drawing.Size(75, 23)
        Me.btn1000.TabIndex = 68
        Me.btn1000.Text = "1000"
        Me.btn1000.UseVisualStyleBackColor = True
        Me.btn1000.Visible = False
        '
        'btn500
        '
        Me.btn500.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn500.Location = New System.Drawing.Point(108, 23)
        Me.btn500.Name = "btn500"
        Me.btn500.Size = New System.Drawing.Size(75, 23)
        Me.btn500.TabIndex = 69
        Me.btn500.Text = "500"
        Me.btn500.UseVisualStyleBackColor = True
        Me.btn500.Visible = False
        '
        'btn100
        '
        Me.btn100.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn100.Location = New System.Drawing.Point(189, 23)
        Me.btn100.Name = "btn100"
        Me.btn100.Size = New System.Drawing.Size(75, 23)
        Me.btn100.TabIndex = 70
        Me.btn100.Text = "100"
        Me.btn100.UseVisualStyleBackColor = True
        Me.btn100.Visible = False
        '
        'btn50
        '
        Me.btn50.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn50.Location = New System.Drawing.Point(270, 23)
        Me.btn50.Name = "btn50"
        Me.btn50.Size = New System.Drawing.Size(75, 23)
        Me.btn50.TabIndex = 71
        Me.btn50.Text = "50"
        Me.btn50.UseVisualStyleBackColor = True
        Me.btn50.Visible = False
        '
        'btn20
        '
        Me.btn20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn20.Location = New System.Drawing.Point(351, 23)
        Me.btn20.Name = "btn20"
        Me.btn20.Size = New System.Drawing.Size(75, 23)
        Me.btn20.TabIndex = 72
        Me.btn20.Text = "20"
        Me.btn20.UseVisualStyleBackColor = True
        Me.btn20.Visible = False
        '
        'btn10
        '
        Me.btn10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn10.Location = New System.Drawing.Point(432, 23)
        Me.btn10.Name = "btn10"
        Me.btn10.Size = New System.Drawing.Size(75, 23)
        Me.btn10.TabIndex = 73
        Me.btn10.Text = "10"
        Me.btn10.UseVisualStyleBackColor = True
        Me.btn10.Visible = False
        '
        'btn5
        '
        Me.btn5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn5.Location = New System.Drawing.Point(513, 23)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(75, 23)
        Me.btn5.TabIndex = 74
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        Me.btn5.Visible = False
        '
        'btn2
        '
        Me.btn2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn2.Location = New System.Drawing.Point(594, 23)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(75, 23)
        Me.btn2.TabIndex = 75
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        Me.btn2.Visible = False
        '
        'btn1
        '
        Me.btn1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn1.Location = New System.Drawing.Point(675, 23)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(75, 23)
        Me.btn1.TabIndex = 76
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        Me.btn1.Visible = False
        '
        'lblLabelPaid
        '
        Me.lblLabelPaid.BackColor = System.Drawing.Color.Transparent
        Me.lblLabelPaid.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabelPaid.Location = New System.Drawing.Point(509, 442)
        Me.lblLabelPaid.Name = "lblLabelPaid"
        Me.lblLabelPaid.Size = New System.Drawing.Size(196, 56)
        Me.lblLabelPaid.TabIndex = 87
        Me.lblLabelPaid.Text = "รับเงินแล้ว"
        Me.lblLabelPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPaidAmt
        '
        Me.lblPaidAmt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPaidAmt.BackColor = System.Drawing.Color.Transparent
        Me.lblPaidAmt.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaidAmt.ForeColor = System.Drawing.Color.Black
        Me.lblPaidAmt.Location = New System.Drawing.Point(742, 442)
        Me.lblPaidAmt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPaidAmt.Name = "lblPaidAmt"
        Me.lblPaidAmt.Size = New System.Drawing.Size(114, 56)
        Me.lblPaidAmt.TabIndex = 83
        Me.lblPaidAmt.Text = "0"
        Me.lblPaidAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPaidTHB
        '
        Me.lblPaidTHB.BackColor = System.Drawing.Color.Transparent
        Me.lblPaidTHB.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaidTHB.Location = New System.Drawing.Point(849, 442)
        Me.lblPaidTHB.Name = "lblPaidTHB"
        Me.lblPaidTHB.Size = New System.Drawing.Size(35, 56)
        Me.lblPaidTHB.TabIndex = 89
        Me.lblPaidTHB.Text = "฿"
        Me.lblPaidTHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLabelDepositAmt
        '
        Me.lblLabelDepositAmt.BackColor = System.Drawing.Color.Transparent
        Me.lblLabelDepositAmt.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabelDepositAmt.Location = New System.Drawing.Point(13, 2)
        Me.lblLabelDepositAmt.Name = "lblLabelDepositAmt"
        Me.lblLabelDepositAmt.Size = New System.Drawing.Size(278, 50)
        Me.lblLabelDepositAmt.TabIndex = 85
        Me.lblLabelDepositAmt.Text = "Initial Storage Fee"
        Me.lblLabelDepositAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepositAmt
        '
        Me.lblDepositAmt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDepositAmt.BackColor = System.Drawing.Color.Transparent
        Me.lblDepositAmt.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepositAmt.ForeColor = System.Drawing.Color.Black
        Me.lblDepositAmt.Location = New System.Drawing.Point(257, 2)
        Me.lblDepositAmt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDepositAmt.Name = "lblDepositAmt"
        Me.lblDepositAmt.Size = New System.Drawing.Size(103, 40)
        Me.lblDepositAmt.TabIndex = 56
        Me.lblDepositAmt.Text = "000"
        Me.lblDepositAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDepositTHB
        '
        Me.lblDepositTHB.BackColor = System.Drawing.Color.Transparent
        Me.lblDepositTHB.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepositTHB.Location = New System.Drawing.Point(353, 2)
        Me.lblDepositTHB.Name = "lblDepositTHB"
        Me.lblDepositTHB.Size = New System.Drawing.Size(35, 40)
        Me.lblDepositTHB.TabIndex = 86
        Me.lblDepositTHB.Text = "฿"
        Me.lblDepositTHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlLockerName
        '
        Me.pnlLockerName.BackColor = System.Drawing.Color.White
        Me.pnlLockerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLockerName.Controls.Add(Me.lblLabelLockerName)
        Me.pnlLockerName.Controls.Add(Me.lblLockerName)
        Me.pnlLockerName.Location = New System.Drawing.Point(496, 61)
        Me.pnlLockerName.Name = "pnlLockerName"
        Me.pnlLockerName.Size = New System.Drawing.Size(400, 52)
        Me.pnlLockerName.TabIndex = 92
        '
        'lblLabelLockerName
        '
        Me.lblLabelLockerName.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabelLockerName.Location = New System.Drawing.Point(13, 2)
        Me.lblLabelLockerName.Name = "lblLabelLockerName"
        Me.lblLabelLockerName.Size = New System.Drawing.Size(196, 50)
        Me.lblLabelLockerName.TabIndex = 81
        Me.lblLabelLockerName.Text = "Storage Box"
        Me.lblLabelLockerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLockerName
        '
        Me.lblLockerName.BackColor = System.Drawing.Color.Transparent
        Me.lblLockerName.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblLockerName.Location = New System.Drawing.Point(273, 2)
        Me.lblLockerName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLockerName.Name = "lblLockerName"
        Me.lblLockerName.Size = New System.Drawing.Size(95, 40)
        Me.lblLockerName.TabIndex = 82
        Me.lblLockerName.Text = "M05"
        Me.lblLockerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabelChange
        '
        Me.lblLabelChange.BackColor = System.Drawing.Color.Transparent
        Me.lblLabelChange.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabelChange.Location = New System.Drawing.Point(512, 492)
        Me.lblLabelChange.Name = "lblLabelChange"
        Me.lblLabelChange.Size = New System.Drawing.Size(150, 47)
        Me.lblLabelChange.TabIndex = 88
        Me.lblLabelChange.Text = "เงินทอน"
        Me.lblLabelChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChangeAmt
        '
        Me.lblChangeAmt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblChangeAmt.BackColor = System.Drawing.Color.Transparent
        Me.lblChangeAmt.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblChangeAmt.ForeColor = System.Drawing.Color.Black
        Me.lblChangeAmt.Location = New System.Drawing.Point(742, 492)
        Me.lblChangeAmt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblChangeAmt.Name = "lblChangeAmt"
        Me.lblChangeAmt.Size = New System.Drawing.Size(114, 47)
        Me.lblChangeAmt.TabIndex = 84
        Me.lblChangeAmt.Text = "0"
        Me.lblChangeAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblChangeTHB
        '
        Me.lblChangeTHB.BackColor = System.Drawing.Color.Transparent
        Me.lblChangeTHB.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblChangeTHB.Location = New System.Drawing.Point(850, 492)
        Me.lblChangeTHB.Name = "lblChangeTHB"
        Me.lblChangeTHB.Size = New System.Drawing.Size(35, 47)
        Me.lblChangeTHB.TabIndex = 90
        Me.lblChangeTHB.Text = "฿"
        Me.lblChangeTHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPaidRemain
        '
        Me.lblPaidRemain.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPaidRemain.BackColor = System.Drawing.Color.Transparent
        Me.lblPaidRemain.Font = New System.Drawing.Font("Thai Sans Lite", 120.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaidRemain.ForeColor = System.Drawing.Color.Black
        Me.lblPaidRemain.Location = New System.Drawing.Point(453, 241)
        Me.lblPaidRemain.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPaidRemain.Name = "lblPaidRemain"
        Me.lblPaidRemain.Size = New System.Drawing.Size(432, 181)
        Me.lblPaidRemain.TabIndex = 92
        Me.lblPaidRemain.Text = "8888"
        Me.lblPaidRemain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(849, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 41)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "฿"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPleasePaid
        '
        Me.lblPleasePaid.BackColor = System.Drawing.Color.Transparent
        Me.lblPleasePaid.Font = New System.Drawing.Font("Thai Sans Lite", 34.0!, System.Drawing.FontStyle.Bold)
        Me.lblPleasePaid.Location = New System.Drawing.Point(503, 232)
        Me.lblPleasePaid.Name = "lblPleasePaid"
        Me.lblPleasePaid.Size = New System.Drawing.Size(516, 62)
        Me.lblPleasePaid.TabIndex = 91
        Me.lblPleasePaid.Text = "Please pay the amount below"
        Me.lblPleasePaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlPickupOpenLocker
        '
        Me.pnlPickupOpenLocker.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnPickupOpenLocker
        Me.pnlPickupOpenLocker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPickupOpenLocker.Controls.Add(Me.lblCollectOpenLocker)
        Me.pnlPickupOpenLocker.Location = New System.Drawing.Point(217, 297)
        Me.pnlPickupOpenLocker.Name = "pnlPickupOpenLocker"
        Me.pnlPickupOpenLocker.Size = New System.Drawing.Size(290, 139)
        Me.pnlPickupOpenLocker.TabIndex = 101
        Me.pnlPickupOpenLocker.Visible = False
        '
        'lblCollectOpenLocker
        '
        Me.lblCollectOpenLocker.BackColor = System.Drawing.Color.Transparent
        Me.lblCollectOpenLocker.Font = New System.Drawing.Font("Thai Sans Lite", 48.0!, System.Drawing.FontStyle.Bold)
        Me.lblCollectOpenLocker.Location = New System.Drawing.Point(3, 22)
        Me.lblCollectOpenLocker.Name = "lblCollectOpenLocker"
        Me.lblCollectOpenLocker.Size = New System.Drawing.Size(284, 81)
        Me.lblCollectOpenLocker.TabIndex = 92
        Me.lblCollectOpenLocker.Text = "เปิดประตู"
        Me.lblCollectOpenLocker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.AutoboxLocker.My.Resources.Resources.IconPayment
        Me.PictureBox1.Location = New System.Drawing.Point(85, 143)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(427, 344)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 100
        Me.PictureBox1.TabStop = False
        '
        'tmOpenLockerTimeOut
        '
        Me.tmOpenLockerTimeOut.Interval = 1000
        '
        'lblPleasePaidComplete
        '
        Me.lblPleasePaidComplete.BackColor = System.Drawing.Color.Transparent
        Me.lblPleasePaidComplete.Font = New System.Drawing.Font("Thai Sans Lite", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPleasePaidComplete.Location = New System.Drawing.Point(-4, 477)
        Me.lblPleasePaidComplete.Name = "lblPleasePaidComplete"
        Me.lblPleasePaidComplete.Size = New System.Drawing.Size(516, 62)
        Me.lblPleasePaidComplete.TabIndex = 102
        Me.lblPleasePaidComplete.Text = "กรุณากด ""เปิดประตู"""
        Me.lblPleasePaidComplete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPleasePaidComplete.Visible = False
        '
        'pnlServiceAmt
        '
        Me.pnlServiceAmt.Controls.Add(Me.lblServiceTHB)
        Me.pnlServiceAmt.Controls.Add(Me.lblServiceAmt)
        Me.pnlServiceAmt.Controls.Add(Me.lblLabelServiceAmt)
        Me.pnlServiceAmt.Location = New System.Drawing.Point(496, 182)
        Me.pnlServiceAmt.Name = "pnlServiceAmt"
        Me.pnlServiceAmt.Size = New System.Drawing.Size(400, 52)
        Me.pnlServiceAmt.TabIndex = 103
        Me.pnlServiceAmt.Visible = False
        '
        'lblServiceTHB
        '
        Me.lblServiceTHB.BackColor = System.Drawing.Color.Transparent
        Me.lblServiceTHB.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblServiceTHB.Location = New System.Drawing.Point(353, 3)
        Me.lblServiceTHB.Name = "lblServiceTHB"
        Me.lblServiceTHB.Size = New System.Drawing.Size(35, 40)
        Me.lblServiceTHB.TabIndex = 89
        Me.lblServiceTHB.Text = "฿"
        Me.lblServiceTHB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblServiceAmt
        '
        Me.lblServiceAmt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblServiceAmt.BackColor = System.Drawing.Color.Transparent
        Me.lblServiceAmt.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblServiceAmt.ForeColor = System.Drawing.Color.Black
        Me.lblServiceAmt.Location = New System.Drawing.Point(237, 3)
        Me.lblServiceAmt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblServiceAmt.Name = "lblServiceAmt"
        Me.lblServiceAmt.Size = New System.Drawing.Size(123, 40)
        Me.lblServiceAmt.TabIndex = 87
        Me.lblServiceAmt.Text = "0000"
        Me.lblServiceAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabelServiceAmt
        '
        Me.lblLabelServiceAmt.BackColor = System.Drawing.Color.Transparent
        Me.lblLabelServiceAmt.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabelServiceAmt.Location = New System.Drawing.Point(13, 3)
        Me.lblLabelServiceAmt.Name = "lblLabelServiceAmt"
        Me.lblLabelServiceAmt.Size = New System.Drawing.Size(196, 50)
        Me.lblLabelServiceAmt.TabIndex = 88
        Me.lblLabelServiceAmt.Text = "ค่าบริการ"
        Me.lblLabelServiceAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDepositAmt
        '
        Me.pnlDepositAmt.Controls.Add(Me.lblLabelDepositAmt)
        Me.pnlDepositAmt.Controls.Add(Me.lblDepositAmt)
        Me.pnlDepositAmt.Controls.Add(Me.lblDepositTHB)
        Me.pnlDepositAmt.Location = New System.Drawing.Point(496, 121)
        Me.pnlDepositAmt.Name = "pnlDepositAmt"
        Me.pnlDepositAmt.Size = New System.Drawing.Size(400, 52)
        Me.pnlDepositAmt.TabIndex = 104
        '
        'frmDepositPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.pnlPickupOpenLocker)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblPleasePaidComplete)
        Me.Controls.Add(Me.pnlServiceAmt)
        Me.Controls.Add(Me.lblPleasePaid)
        Me.Controls.Add(Me.pnlDepositAmt)
        Me.Controls.Add(Me.lblPaidTHB)
        Me.Controls.Add(Me.lblPaidAmt)
        Me.Controls.Add(Me.lblLabelPaid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblLabelChange)
        Me.Controls.Add(Me.pnlLockerName)
        Me.Controls.Add(Me.lblChangeTHB)
        Me.Controls.Add(Me.lblChangeAmt)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn10)
        Me.Controls.Add(Me.btn20)
        Me.Controls.Add(Me.btn50)
        Me.Controls.Add(Me.btn100)
        Me.Controls.Add(Me.btn500)
        Me.Controls.Add(Me.btn1000)
        Me.Controls.Add(Me.lblPaidRemain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDepositPayment"
        Me.Text = "Payment"
        Me.pnlLockerName.ResumeLayout(False)
        Me.pnlPickupOpenLocker.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlServiceAmt.ResumeLayout(False)
        Me.pnlDepositAmt.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents tmPaymentTimeOut As Timer
    Friend WithEvents lblDepositAmt As Label
    Friend WithEvents btn1000 As Button
    Friend WithEvents btn500 As Button
    Friend WithEvents btn100 As Button
    Friend WithEvents btn50 As Button
    Friend WithEvents btn20 As Button
    Friend WithEvents btn10 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents lblLabelLockerName As Label
    Friend WithEvents lblLockerName As Label
    Friend WithEvents lblPaidAmt As Label
    Friend WithEvents lblLabelDepositAmt As Label
    Friend WithEvents lblDepositTHB As Label
    Friend WithEvents lblLabelPaid As Label
    Friend WithEvents lblPaidTHB As Label
    Friend WithEvents pnlLockerName As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblLabelChange As Label
    Friend WithEvents lblChangeAmt As Label
    Friend WithEvents lblChangeTHB As Label
    Friend WithEvents lblPaidRemain As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPleasePaid As Label
    Friend WithEvents pnlPickupOpenLocker As Panel
    Friend WithEvents lblCollectOpenLocker As Label
    Friend WithEvents tmOpenLockerTimeOut As Timer
    Friend WithEvents lblPleasePaidComplete As Label
    Friend WithEvents pnlServiceAmt As Panel
    Friend WithEvents lblServiceTHB As Label
    Friend WithEvents lblServiceAmt As Label
    Friend WithEvents lblLabelServiceAmt As Label
    Friend WithEvents pnlDepositAmt As Panel
End Class
