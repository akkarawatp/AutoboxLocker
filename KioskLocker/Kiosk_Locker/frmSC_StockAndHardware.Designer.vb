<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSC_StockAndHardware
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.flpHWStatus = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.flpM_Stock = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnFillPaper = New System.Windows.Forms.Panel()
        Me.lblFillPaper = New System.Windows.Forms.Label()
        Me.btnFillMoney = New System.Windows.Forms.Panel()
        Me.lblFillMoney = New System.Windows.Forms.Label()
        Me.btnKioskSetting = New System.Windows.Forms.Panel()
        Me.lblKioskSetting = New System.Windows.Forms.Label()
        Me.btnDeviceSetting = New System.Windows.Forms.Panel()
        Me.lblDeviceSetting = New System.Windows.Forms.Label()
        Me.btnLockerSetting = New System.Windows.Forms.Panel()
        Me.lblLockerSetting = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Panel()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.btnOpenAll = New System.Windows.Forms.Panel()
        Me.lblOpenAll = New System.Windows.Forms.Label()
        Me.TimerCheckDoorClose = New System.Windows.Forms.Timer(Me.components)
        Me.btnCollect = New System.Windows.Forms.Panel()
        Me.lblCollect = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.btnFillPaper.SuspendLayout()
        Me.btnFillMoney.SuspendLayout()
        Me.btnKioskSetting.SuspendLayout()
        Me.btnDeviceSetting.SuspendLayout()
        Me.btnLockerSetting.SuspendLayout()
        Me.btnExit.SuspendLayout()
        Me.btnOpenAll.SuspendLayout()
        Me.btnCollect.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGreen
        Me.Panel1.Controls.Add(Me.pbClose)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 47)
        Me.Panel1.TabIndex = 0
        '
        'pbClose
        '
        Me.pbClose.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.IconClose
        Me.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbClose.Location = New System.Drawing.Point(973, 0)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(48, 44)
        Me.pbClose.TabIndex = 67
        Me.pbClose.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(27, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 40)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Hardware Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'flpHWStatus
        '
        Me.flpHWStatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.flpHWStatus.Location = New System.Drawing.Point(1, 0)
        Me.flpHWStatus.Name = "flpHWStatus"
        Me.flpHWStatus.Size = New System.Drawing.Size(1022, 272)
        Me.flpHWStatus.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.flpHWStatus)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 306)
        Me.Panel2.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGreen
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 353)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1024, 47)
        Me.Panel5.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(27, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(318, 40)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Material Stock"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.flpM_Stock)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 400)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1024, 277)
        Me.Panel7.TabIndex = 6
        '
        'flpM_Stock
        '
        Me.flpM_Stock.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.flpM_Stock.Location = New System.Drawing.Point(1, 0)
        Me.flpM_Stock.Margin = New System.Windows.Forms.Padding(1)
        Me.flpM_Stock.Name = "flpM_Stock"
        Me.flpM_Stock.Size = New System.Drawing.Size(1020, 259)
        Me.flpM_Stock.TabIndex = 1
        '
        'btnFillPaper
        '
        Me.btnFillPaper.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFillPaper.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnFillPaper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFillPaper.Controls.Add(Me.lblFillPaper)
        Me.btnFillPaper.Location = New System.Drawing.Point(9, 714)
        Me.btnFillPaper.Name = "btnFillPaper"
        Me.btnFillPaper.Size = New System.Drawing.Size(113, 37)
        Me.btnFillPaper.TabIndex = 63
        '
        'lblFillPaper
        '
        Me.lblFillPaper.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFillPaper.BackColor = System.Drawing.Color.Transparent
        Me.lblFillPaper.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblFillPaper.ForeColor = System.Drawing.Color.Black
        Me.lblFillPaper.Location = New System.Drawing.Point(4, 5)
        Me.lblFillPaper.Name = "lblFillPaper"
        Me.lblFillPaper.Size = New System.Drawing.Size(104, 26)
        Me.lblFillPaper.TabIndex = 35
        Me.lblFillPaper.Text = "Fill Paper"
        Me.lblFillPaper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnFillMoney
        '
        Me.btnFillMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFillMoney.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnFillMoney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFillMoney.Controls.Add(Me.lblFillMoney)
        Me.btnFillMoney.Location = New System.Drawing.Point(127, 714)
        Me.btnFillMoney.Name = "btnFillMoney"
        Me.btnFillMoney.Size = New System.Drawing.Size(116, 37)
        Me.btnFillMoney.TabIndex = 64
        '
        'lblFillMoney
        '
        Me.lblFillMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFillMoney.BackColor = System.Drawing.Color.Transparent
        Me.lblFillMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFillMoney.ForeColor = System.Drawing.Color.Black
        Me.lblFillMoney.Location = New System.Drawing.Point(3, 6)
        Me.lblFillMoney.Name = "lblFillMoney"
        Me.lblFillMoney.Size = New System.Drawing.Size(109, 26)
        Me.lblFillMoney.TabIndex = 35
        Me.lblFillMoney.Text = "Fill Money"
        Me.lblFillMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnKioskSetting
        '
        Me.btnKioskSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnKioskSetting.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnKioskSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnKioskSetting.Controls.Add(Me.lblKioskSetting)
        Me.btnKioskSetting.Location = New System.Drawing.Point(406, 714)
        Me.btnKioskSetting.Name = "btnKioskSetting"
        Me.btnKioskSetting.Size = New System.Drawing.Size(114, 37)
        Me.btnKioskSetting.TabIndex = 65
        '
        'lblKioskSetting
        '
        Me.lblKioskSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblKioskSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblKioskSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblKioskSetting.ForeColor = System.Drawing.Color.Black
        Me.lblKioskSetting.Location = New System.Drawing.Point(1, 7)
        Me.lblKioskSetting.Name = "lblKioskSetting"
        Me.lblKioskSetting.Size = New System.Drawing.Size(111, 25)
        Me.lblKioskSetting.TabIndex = 35
        Me.lblKioskSetting.Text = "Kiosk Setting"
        Me.lblKioskSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDeviceSetting
        '
        Me.btnDeviceSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDeviceSetting.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnDeviceSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeviceSetting.Controls.Add(Me.lblDeviceSetting)
        Me.btnDeviceSetting.Location = New System.Drawing.Point(526, 714)
        Me.btnDeviceSetting.Name = "btnDeviceSetting"
        Me.btnDeviceSetting.Size = New System.Drawing.Size(124, 37)
        Me.btnDeviceSetting.TabIndex = 66
        '
        'lblDeviceSetting
        '
        Me.lblDeviceSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDeviceSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblDeviceSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblDeviceSetting.ForeColor = System.Drawing.Color.Black
        Me.lblDeviceSetting.Location = New System.Drawing.Point(3, 7)
        Me.lblDeviceSetting.Name = "lblDeviceSetting"
        Me.lblDeviceSetting.Size = New System.Drawing.Size(118, 25)
        Me.lblDeviceSetting.TabIndex = 35
        Me.lblDeviceSetting.Text = "Device Setting"
        Me.lblDeviceSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLockerSetting
        '
        Me.btnLockerSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnLockerSetting.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnLockerSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLockerSetting.Controls.Add(Me.lblLockerSetting)
        Me.btnLockerSetting.Location = New System.Drawing.Point(655, 714)
        Me.btnLockerSetting.Name = "btnLockerSetting"
        Me.btnLockerSetting.Size = New System.Drawing.Size(126, 37)
        Me.btnLockerSetting.TabIndex = 66
        '
        'lblLockerSetting
        '
        Me.lblLockerSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLockerSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblLockerSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblLockerSetting.ForeColor = System.Drawing.Color.Black
        Me.lblLockerSetting.Location = New System.Drawing.Point(3, 6)
        Me.lblLockerSetting.Name = "lblLockerSetting"
        Me.lblLockerSetting.Size = New System.Drawing.Size(120, 25)
        Me.lblLockerSetting.TabIndex = 35
        Me.lblLockerSetting.Text = "Locker Setting"
        Me.lblLockerSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnExit.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.Controls.Add(Me.lblExit)
        Me.btnExit.Location = New System.Drawing.Point(908, 714)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(113, 37)
        Me.btnExit.TabIndex = 67
        '
        'lblExit
        '
        Me.lblExit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblExit.BackColor = System.Drawing.Color.Transparent
        Me.lblExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblExit.ForeColor = System.Drawing.Color.Black
        Me.lblExit.Location = New System.Drawing.Point(4, 7)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(107, 25)
        Me.lblExit.TabIndex = 35
        Me.lblExit.Text = "Exit Program"
        Me.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOpenAll
        '
        Me.btnOpenAll.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOpenAll.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnOpenAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenAll.Controls.Add(Me.lblOpenAll)
        Me.btnOpenAll.Location = New System.Drawing.Point(785, 714)
        Me.btnOpenAll.Name = "btnOpenAll"
        Me.btnOpenAll.Size = New System.Drawing.Size(79, 37)
        Me.btnOpenAll.TabIndex = 67
        '
        'lblOpenAll
        '
        Me.lblOpenAll.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblOpenAll.BackColor = System.Drawing.Color.Transparent
        Me.lblOpenAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblOpenAll.ForeColor = System.Drawing.Color.Black
        Me.lblOpenAll.Location = New System.Drawing.Point(3, 6)
        Me.lblOpenAll.Name = "lblOpenAll"
        Me.lblOpenAll.Size = New System.Drawing.Size(73, 25)
        Me.lblOpenAll.TabIndex = 35
        Me.lblOpenAll.Text = "Open All"
        Me.lblOpenAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerCheckDoorClose
        '
        Me.TimerCheckDoorClose.Enabled = True
        Me.TimerCheckDoorClose.Interval = 2000
        '
        'btnCollect
        '
        Me.btnCollect.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCollect.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnCollect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCollect.Controls.Add(Me.lblCollect)
        Me.btnCollect.Location = New System.Drawing.Point(249, 714)
        Me.btnCollect.Name = "btnCollect"
        Me.btnCollect.Size = New System.Drawing.Size(116, 37)
        Me.btnCollect.TabIndex = 65
        '
        'lblCollect
        '
        Me.lblCollect.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCollect.BackColor = System.Drawing.Color.Transparent
        Me.lblCollect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCollect.ForeColor = System.Drawing.Color.Black
        Me.lblCollect.Location = New System.Drawing.Point(3, 6)
        Me.lblCollect.Name = "lblCollect"
        Me.lblCollect.Size = New System.Drawing.Size(109, 26)
        Me.lblCollect.TabIndex = 35
        Me.lblCollect.Text = "Collect"
        Me.lblCollect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSC_StockAndHardware
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.btnCollect)
        Me.Controls.Add(Me.btnOpenAll)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnLockerSetting)
        Me.Controls.Add(Me.btnDeviceSetting)
        Me.Controls.Add(Me.btnKioskSetting)
        Me.Controls.Add(Me.btnFillMoney)
        Me.Controls.Add(Me.btnFillPaper)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_StockAndHardware"
        Me.Text = "frmSC_StockAndHardware"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.btnFillPaper.ResumeLayout(False)
        Me.btnFillMoney.ResumeLayout(False)
        Me.btnKioskSetting.ResumeLayout(False)
        Me.btnDeviceSetting.ResumeLayout(False)
        Me.btnLockerSetting.ResumeLayout(False)
        Me.btnExit.ResumeLayout(False)
        Me.btnOpenAll.ResumeLayout(False)
        Me.btnCollect.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents flpHWStatus As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents flpM_Stock As FlowLayoutPanel
    Friend WithEvents pbClose As PictureBox
    Friend WithEvents btnFillPaper As Panel
    Friend WithEvents lblFillPaper As Label
    Friend WithEvents btnFillMoney As Panel
    Friend WithEvents lblFillMoney As Label
    Friend WithEvents btnKioskSetting As Panel
    Friend WithEvents lblKioskSetting As Label
    Friend WithEvents btnDeviceSetting As Panel
    Friend WithEvents lblDeviceSetting As Label
    Friend WithEvents btnLockerSetting As Panel
    Friend WithEvents lblLockerSetting As Label
    Friend WithEvents btnExit As Panel
    Friend WithEvents lblExit As Label
    Friend WithEvents btnOpenAll As Panel
    Friend WithEvents lblOpenAll As Label
    Friend WithEvents TimerCheckDoorClose As Timer
    Friend WithEvents btnCollect As Panel
    Friend WithEvents lblCollect As Label
End Class
