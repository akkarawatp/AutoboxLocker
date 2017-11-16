<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCollectThankyou
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
        Me.TimerCheckCloseLocker = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblChangeAmt = New System.Windows.Forms.Label()
        Me.pbIconOpenLocker = New System.Windows.Forms.PictureBox()
        CType(Me.pbIconOpenLocker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(12, 42)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 85)
        Me.lblTitle.TabIndex = 43
        Me.lblTitle.Text = "ประตูช่องฝากเปิดแล้ว"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabelNotification
        '
        Me.lblLabelNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelNotification.Font = New System.Drawing.Font("Thai Sans Lite", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabelNotification.ForeColor = System.Drawing.Color.Red
        Me.lblLabelNotification.Location = New System.Drawing.Point(71, 441)
        Me.lblLabelNotification.Name = "lblLabelNotification"
        Me.lblLabelNotification.Size = New System.Drawing.Size(881, 43)
        Me.lblLabelNotification.TabIndex = 50
        Me.lblLabelNotification.Text = "นำสัมภาระออก > ปิดประตูช่องฝากให้สนิท > รับเงินทอน"
        Me.lblLabelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerCheckCloseLocker
        '
        Me.TimerCheckCloseLocker.Interval = 500
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Thai Sans Lite", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(927, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 41)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "฿"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChangeAmt
        '
        Me.lblChangeAmt.Font = New System.Drawing.Font("Thai Sans Lite", 71.99999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblChangeAmt.Location = New System.Drawing.Point(744, 120)
        Me.lblChangeAmt.Margin = New System.Windows.Forms.Padding(0)
        Me.lblChangeAmt.Name = "lblChangeAmt"
        Me.lblChangeAmt.Size = New System.Drawing.Size(220, 99)
        Me.lblChangeAmt.TabIndex = 97
        Me.lblChangeAmt.Text = "8888"
        Me.lblChangeAmt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbIconOpenLocker
        '
        Me.pbIconOpenLocker.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbIconOpenLocker.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.IconCollectThankYou
        Me.pbIconOpenLocker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbIconOpenLocker.Location = New System.Drawing.Point(71, 124)
        Me.pbIconOpenLocker.Name = "pbIconOpenLocker"
        Me.pbIconOpenLocker.Size = New System.Drawing.Size(881, 308)
        Me.pbIconOpenLocker.TabIndex = 96
        Me.pbIconOpenLocker.TabStop = False
        '
        'frmCollectThankyou
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblChangeAmt)
        Me.Controls.Add(Me.pbIconOpenLocker)
        Me.Controls.Add(Me.lblLabelNotification)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCollectThankyou"
        Me.Text = "ขอบคุณที่ใช้บริการ"
        CType(Me.pbIconOpenLocker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblLabelNotification As Label
    Friend WithEvents TimerCheckCloseLocker As Timer
    Friend WithEvents pbIconOpenLocker As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblChangeAmt As Label
End Class
