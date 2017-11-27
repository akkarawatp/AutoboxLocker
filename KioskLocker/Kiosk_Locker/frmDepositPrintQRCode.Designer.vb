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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepositPrintQRCode))
        Me.lblTimeOut = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbIconQRCode = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.pbIconQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 40.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(12, 80)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 124)
        Me.lblTitle.TabIndex = 43
        Me.lblTitle.Text = "รับ QR Code " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "และเงินทอน(ถ้ามี)"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbIconQRCode
        '
        Me.pbIconQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbIconQRCode.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.IconPrintQRCode
        Me.pbIconQRCode.Location = New System.Drawing.Point(328, 273)
        Me.pbIconQRCode.Name = "pbIconQRCode"
        Me.pbIconQRCode.Size = New System.Drawing.Size(380, 322)
        Me.pbIconQRCode.TabIndex = 44
        Me.pbIconQRCode.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(48, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 80)
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'frmDepositPrintQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pbIconQRCode)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTimeOut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDepositPrintQRCode"
        Me.Text = "ขอบคุณที่ใช้บริการ"
        CType(Me.pbIconQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTimeOut As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pbIconQRCode As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
