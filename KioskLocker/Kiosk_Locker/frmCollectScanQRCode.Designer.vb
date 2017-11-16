<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtQRCode = New System.Windows.Forms.TextBox()
        Me.TimerTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.pbQRCode = New System.Windows.Forms.PictureBox()
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 53)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 67)
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "สแกน QR Code"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'pbQRCode
        '
        Me.pbQRCode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbQRCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbQRCode.Image = Global.AutoboxLocker.My.Resources.Resources.IconQRCode
        Me.pbQRCode.Location = New System.Drawing.Point(175, 171)
        Me.pbQRCode.Name = "pbQRCode"
        Me.pbQRCode.Size = New System.Drawing.Size(677, 342)
        Me.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbQRCode.TabIndex = 14
        Me.pbQRCode.TabStop = False
        '
        'frmCollectScanQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.pbQRCode)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtQRCode)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCollectScanQRCode"
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As Label
    Friend WithEvents pbQRCode As PictureBox
    Friend WithEvents txtQRCode As TextBox
    Friend WithEvents TimerTimeOut As Timer
End Class
