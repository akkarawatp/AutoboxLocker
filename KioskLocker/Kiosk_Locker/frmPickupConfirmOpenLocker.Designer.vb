<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPickupConfirmOpenLocker
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
        Me.lblLabelNotification = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.tmTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.lblTimeOut = New System.Windows.Forms.Label()
        Me.pnlTotalAmount = New System.Windows.Forms.Panel()
        Me.lblLabelChange = New System.Windows.Forms.Label()
        Me.lblChangeAmt = New System.Windows.Forms.Label()
        Me.lblChangeTHB = New System.Windows.Forms.Label()
        Me.pnlTotalAmount.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Superspace Bold", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(12, 25)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 108)
        Me.lblTitle.TabIndex = 43
        Me.lblTitle.Text = "เปิดช่องฝากสัมภาระ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "กดปุ่ม ""ยืนยัน"" เพื่อเปิดช่องฝาก"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabelNotification
        '
        Me.lblLabelNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelNotification.Font = New System.Drawing.Font("Superspace Regular", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabelNotification.ForeColor = System.Drawing.Color.Red
        Me.lblLabelNotification.Location = New System.Drawing.Point(12, 449)
        Me.lblLabelNotification.Name = "lblLabelNotification"
        Me.lblLabelNotification.Size = New System.Drawing.Size(1000, 75)
        Me.lblLabelNotification.TabIndex = 93
        Me.lblLabelNotification.Text = "เครื่องจะทอนเงินและคืนเงินมัดจำเมื่อรับสัมภาระคืน" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "และปิดประตูช่องฝากสนิทแล้ว"
        Me.lblLabelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnConfirm.BackgroundImage = Global.Kiosk_Locker.My.Resources.Resources.btnBG
        Me.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirm.FlatAppearance.BorderSize = 0
        Me.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirm.Font = New System.Drawing.Font("Superspace Regular", 33.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnConfirm.ForeColor = System.Drawing.Color.White
        Me.btnConfirm.Location = New System.Drawing.Point(414, 358)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(0)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(197, 79)
        Me.btnConfirm.TabIndex = 94
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'tmTimeOut
        '
        Me.tmTimeOut.Enabled = True
        Me.tmTimeOut.Interval = 1000
        '
        'lblTimeOut
        '
        Me.lblTimeOut.AutoSize = True
        Me.lblTimeOut.Location = New System.Drawing.Point(491, 20)
        Me.lblTimeOut.Name = "lblTimeOut"
        Me.lblTimeOut.Size = New System.Drawing.Size(13, 13)
        Me.lblTimeOut.TabIndex = 95
        Me.lblTimeOut.Text = "0"
        Me.lblTimeOut.Visible = False
        '
        'pnlTotalAmount
        '
        Me.pnlTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlTotalAmount.BackgroundImage = Global.Kiosk_Locker.My.Resources.Resources.IconPaymentAmount
        Me.pnlTotalAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTotalAmount.Controls.Add(Me.lblLabelChange)
        Me.pnlTotalAmount.Controls.Add(Me.lblChangeAmt)
        Me.pnlTotalAmount.Controls.Add(Me.lblChangeTHB)
        Me.pnlTotalAmount.Location = New System.Drawing.Point(417, 148)
        Me.pnlTotalAmount.Name = "pnlTotalAmount"
        Me.pnlTotalAmount.Size = New System.Drawing.Size(190, 190)
        Me.pnlTotalAmount.TabIndex = 96
        '
        'lblLabelChange
        '
        Me.lblLabelChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblLabelChange.Font = New System.Drawing.Font("Superspace Regular", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabelChange.Location = New System.Drawing.Point(-2, 15)
        Me.lblLabelChange.Name = "lblLabelChange"
        Me.lblLabelChange.Size = New System.Drawing.Size(196, 41)
        Me.lblLabelChange.TabIndex = 88
        Me.lblLabelChange.Text = "คืนมัดจำ+เงินทอน"
        Me.lblLabelChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblChangeAmt
        '
        Me.lblChangeAmt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblChangeAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblChangeAmt.Font = New System.Drawing.Font("Superspace Bold", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblChangeAmt.ForeColor = System.Drawing.Color.Black
        Me.lblChangeAmt.Location = New System.Drawing.Point(-12, 41)
        Me.lblChangeAmt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblChangeAmt.Name = "lblChangeAmt"
        Me.lblChangeAmt.Size = New System.Drawing.Size(222, 94)
        Me.lblChangeAmt.TabIndex = 84
        Me.lblChangeAmt.Text = "0"
        Me.lblChangeAmt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblChangeTHB
        '
        Me.lblChangeTHB.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblChangeTHB.Font = New System.Drawing.Font("Superspace Bold", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblChangeTHB.Location = New System.Drawing.Point(0, 124)
        Me.lblChangeTHB.Name = "lblChangeTHB"
        Me.lblChangeTHB.Size = New System.Drawing.Size(190, 48)
        Me.lblChangeTHB.TabIndex = 90
        Me.lblChangeTHB.Text = "บาท"
        Me.lblChangeTHB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPickupConfirmOpenLocker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.pnlTotalAmount)
        Me.Controls.Add(Me.lblTimeOut)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.lblLabelNotification)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPickupConfirmOpenLocker"
        Me.Text = "ขอบคุณที่ใช้บริการ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTotalAmount.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblLabelNotification As Label
    Friend WithEvents btnConfirm As Button
    Friend WithEvents tmTimeOut As Timer
    Friend WithEvents lblTimeOut As Label
    Friend WithEvents pnlTotalAmount As Panel
    Friend WithEvents lblLabelChange As Label
    Friend WithEvents lblChangeAmt As Label
    Friend WithEvents lblChangeTHB As Label
End Class
