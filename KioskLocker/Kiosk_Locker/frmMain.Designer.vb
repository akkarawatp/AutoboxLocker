<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.TimerAds = New System.Windows.Forms.Timer(Me.components)
        Me.TimerCheckOpenClose = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSetPointer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.pnlCancel = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Label()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.btnPointer = New System.Windows.Forms.Button()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.pnlLang = New System.Windows.Forms.Panel()
        Me.btnEN = New System.Windows.Forms.PictureBox()
        Me.btnCH = New System.Windows.Forms.PictureBox()
        Me.btnTH = New System.Windows.Forms.PictureBox()
        Me.btnJP = New System.Windows.Forms.PictureBox()
        Me.pnlAds = New System.Windows.Forms.Panel()
        Me.TimerCheckAutoSleep = New System.Windows.Forms.Timer(Me.components)
        Me.pnlFooter.SuspendLayout()
        Me.pnlCancel.SuspendLayout()
        Me.pnlHead.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLang.SuspendLayout()
        CType(Me.btnEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnJP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerAds
        '
        '
        'TimerCheckOpenClose
        '
        Me.TimerCheckOpenClose.Interval = 10000
        '
        'TimerSetPointer
        '
        Me.TimerSetPointer.Interval = 2000
        '
        'pnlFooter
        '
        Me.pnlFooter.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.bgMainFooter
        Me.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlFooter.Controls.Add(Me.pnlCancel)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 562)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(1024, 103)
        Me.pnlFooter.TabIndex = 11
        Me.pnlFooter.Visible = False
        '
        'pnlCancel
        '
        Me.pnlCancel.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnBG
        Me.pnlCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCancel.Controls.Add(Me.btnCancel)
        Me.pnlCancel.Location = New System.Drawing.Point(834, 30)
        Me.pnlCancel.Name = "pnlCancel"
        Me.pnlCancel.Size = New System.Drawing.Size(116, 44)
        Me.pnlCancel.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Font = New System.Drawing.Font("Thai Sans Lite", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(3, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(110, 27)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "取消"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlHead
        '
        Me.pnlHead.BackColor = System.Drawing.SystemColors.Window
        Me.pnlHead.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.bgMainHeader
        Me.pnlHead.Controls.Add(Me.btnPointer)
        Me.pnlHead.Controls.Add(Me.pbLogo)
        Me.pnlHead.Controls.Add(Me.pnlLang)
        Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHead.Location = New System.Drawing.Point(0, 0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(1024, 108)
        Me.pnlHead.TabIndex = 45
        '
        'btnPointer
        '
        Me.btnPointer.BackColor = System.Drawing.Color.White
        Me.btnPointer.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnPointer.FlatAppearance.BorderSize = 0
        Me.btnPointer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnPointer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnPointer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPointer.ForeColor = System.Drawing.Color.Transparent
        Me.btnPointer.Location = New System.Drawing.Point(0, 0)
        Me.btnPointer.Name = "btnPointer"
        Me.btnPointer.Size = New System.Drawing.Size(55, 47)
        Me.btnPointer.TabIndex = 51
        Me.btnPointer.Text = "1"
        Me.btnPointer.UseVisualStyleBackColor = False
        '
        'pbLogo
        '
        Me.pbLogo.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.logo
        Me.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbLogo.Location = New System.Drawing.Point(56, 10)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(140, 80)
        Me.pbLogo.TabIndex = 50
        Me.pbLogo.TabStop = False
        '
        'pnlLang
        '
        Me.pnlLang.BackColor = System.Drawing.Color.Transparent
        Me.pnlLang.Controls.Add(Me.btnEN)
        Me.pnlLang.Controls.Add(Me.btnCH)
        Me.pnlLang.Controls.Add(Me.btnTH)
        Me.pnlLang.Controls.Add(Me.btnJP)
        Me.pnlLang.Location = New System.Drawing.Point(725, 27)
        Me.pnlLang.Name = "pnlLang"
        Me.pnlLang.Size = New System.Drawing.Size(257, 46)
        Me.pnlLang.TabIndex = 48
        '
        'btnEN
        '
        Me.btnEN.BackColor = System.Drawing.Color.Transparent
        Me.btnEN.Image = Global.AutoboxLocker.My.Resources.Resources.English_Icon
        Me.btnEN.Location = New System.Drawing.Point(67, 0)
        Me.btnEN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEN.Name = "btnEN"
        Me.btnEN.Size = New System.Drawing.Size(59, 46)
        Me.btnEN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnEN.TabIndex = 3
        Me.btnEN.TabStop = False
        '
        'btnCH
        '
        Me.btnCH.BackColor = System.Drawing.Color.Transparent
        Me.btnCH.Image = Global.AutoboxLocker.My.Resources.Resources.China_Icon
        Me.btnCH.Location = New System.Drawing.Point(133, 0)
        Me.btnCH.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCH.Name = "btnCH"
        Me.btnCH.Size = New System.Drawing.Size(59, 46)
        Me.btnCH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnCH.TabIndex = 4
        Me.btnCH.TabStop = False
        '
        'btnTH
        '
        Me.btnTH.BackColor = System.Drawing.Color.Transparent
        Me.btnTH.Image = Global.AutoboxLocker.My.Resources.Resources.Thai_Icon
        Me.btnTH.Location = New System.Drawing.Point(1, 0)
        Me.btnTH.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTH.Name = "btnTH"
        Me.btnTH.Size = New System.Drawing.Size(59, 46)
        Me.btnTH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnTH.TabIndex = 6
        Me.btnTH.TabStop = False
        '
        'btnJP
        '
        Me.btnJP.BackColor = System.Drawing.Color.Transparent
        Me.btnJP.Image = Global.AutoboxLocker.My.Resources.Resources.Japan_icon
        Me.btnJP.Location = New System.Drawing.Point(199, 0)
        Me.btnJP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnJP.Name = "btnJP"
        Me.btnJP.Size = New System.Drawing.Size(59, 46)
        Me.btnJP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnJP.TabIndex = 5
        Me.btnJP.TabStop = False
        '
        'pnlAds
        '
        Me.pnlAds.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.bgMainFooter
        Me.pnlAds.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAds.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAds.Location = New System.Drawing.Point(0, 665)
        Me.pnlAds.Name = "pnlAds"
        Me.pnlAds.Size = New System.Drawing.Size(1024, 103)
        Me.pnlAds.TabIndex = 10
        '
        'TimerCheckAutoSleep
        '
        Me.TimerCheckAutoSleep.Enabled = True
        Me.TimerCheckAutoSleep.Interval = 60000
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHead)
        Me.Controls.Add(Me.pnlAds)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlCancel.ResumeLayout(False)
        Me.pnlHead.ResumeLayout(False)
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLang.ResumeLayout(False)
        CType(Me.btnEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnJP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerAds As Timer
    Friend WithEvents pnlAds As Panel
    Friend WithEvents btnTH As PictureBox
    Friend WithEvents btnEN As PictureBox
    Friend WithEvents btnJP As PictureBox
    Friend WithEvents btnCH As PictureBox
    Friend WithEvents pnlLang As Panel
    Friend WithEvents pnlHead As Panel
    Friend WithEvents TimerCheckOpenClose As Timer
    Friend WithEvents btnPointer As Button
    Friend WithEvents TimerSetPointer As Timer
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents TimerCheckAutoSleep As Timer
    Friend WithEvents btnCancel As Label
    Friend WithEvents pnlCancel As Panel
End Class
