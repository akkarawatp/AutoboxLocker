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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCollectThankyou))
        Me.TimerCheckCloseLocker = New System.Windows.Forms.Timer(Me.components)
        Me.btnOpenLocker = New System.Windows.Forms.Button()
        Me.lblLabelNotification = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbIconOpenLocker = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbIconOpenLocker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerCheckCloseLocker
        '
        Me.TimerCheckCloseLocker.Interval = 500
        '
        'btnOpenLocker
        '
        Me.btnOpenLocker.Location = New System.Drawing.Point(38, 477)
        Me.btnOpenLocker.Name = "btnOpenLocker"
        Me.btnOpenLocker.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenLocker.TabIndex = 99
        Me.btnOpenLocker.Text = "ปิดตู้"
        Me.btnOpenLocker.UseVisualStyleBackColor = True
        '
        'lblLabelNotification
        '
        Me.lblLabelNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelNotification.Font = New System.Drawing.Font("Thai Sans Lite", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabelNotification.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLabelNotification.Location = New System.Drawing.Point(40, 223)
        Me.lblLabelNotification.Name = "lblLabelNotification"
        Me.lblLabelNotification.Size = New System.Drawing.Size(937, 47)
        Me.lblLabelNotification.TabIndex = 110
        Me.lblLabelNotification.Text = "กรุณาใส่สัมภาระและปิดประตูช่องฝากให้เรียบร้อย"
        Me.lblLabelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 40.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(12, 146)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 80)
        Me.lblTitle.TabIndex = 109
        Me.lblTitle.Text = "ประตูช่องฝากเปิดแล้ว"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(48, 80)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 80)
        Me.PictureBox1.TabIndex = 111
        Me.PictureBox1.TabStop = False
        '
        'pbIconOpenLocker
        '
        Me.pbIconOpenLocker.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbIconOpenLocker.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.pbIconOpenLocker
        Me.pbIconOpenLocker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbIconOpenLocker.Image = Global.AutoboxLocker.My.Resources.Resources.pbIconCloseLocker
        Me.pbIconOpenLocker.Location = New System.Drawing.Point(305, 289)
        Me.pbIconOpenLocker.Name = "pbIconOpenLocker"
        Me.pbIconOpenLocker.Size = New System.Drawing.Size(393, 261)
        Me.pbIconOpenLocker.TabIndex = 112
        Me.pbIconOpenLocker.TabStop = False
        '
        'frmCollectThankyou
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.pbIconOpenLocker)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblLabelNotification)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnOpenLocker)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCollectThankyou"
        Me.Text = "ขอบคุณที่ใช้บริการ"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbIconOpenLocker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents TimerCheckCloseLocker As Timer
    Friend WithEvents btnOpenLocker As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblLabelNotification As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pbIconOpenLocker As PictureBox
End Class
