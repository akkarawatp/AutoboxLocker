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
        Me.TimerCheckDoorClose = New System.Windows.Forms.Timer(Me.components)
        Me.lblOpenAll = New System.Windows.Forms.Label()
        Me.lblLockerSetting = New System.Windows.Forms.Label()
        Me.lblDeviceSetting = New System.Windows.Forms.Label()
        Me.lblKioskSetting = New System.Windows.Forms.Label()
        Me.lblFillMoney = New System.Windows.Forms.Label()
        Me.lblFillPaper = New System.Windows.Forms.Label()
        Me.btnOpenAll = New System.Windows.Forms.Panel()
        Me.btnLockerSetting = New System.Windows.Forms.Panel()
        Me.btnDeviceSetting = New System.Windows.Forms.Panel()
        Me.btnKioskSetting = New System.Windows.Forms.Panel()
        Me.btnFillMoney = New System.Windows.Forms.Panel()
        Me.btnFillPaper = New System.Windows.Forms.Panel()
        Me.lblCollect = New System.Windows.Forms.Label()
        Me.btnCollect = New System.Windows.Forms.Panel()
        Me.btnOpenAll.SuspendLayout()
        Me.btnLockerSetting.SuspendLayout()
        Me.btnDeviceSetting.SuspendLayout()
        Me.btnKioskSetting.SuspendLayout()
        Me.btnFillMoney.SuspendLayout()
        Me.btnFillPaper.SuspendLayout()
        Me.btnCollect.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimerCheckDoorClose
        '
        Me.TimerCheckDoorClose.Enabled = True
        Me.TimerCheckDoorClose.Interval = 2000
        '
        'lblOpenAll
        '
        Me.lblOpenAll.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblOpenAll.BackColor = System.Drawing.Color.Transparent
        Me.lblOpenAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblOpenAll.ForeColor = System.Drawing.Color.White
        Me.lblOpenAll.Location = New System.Drawing.Point(42, 14)
        Me.lblOpenAll.Name = "lblOpenAll"
        Me.lblOpenAll.Size = New System.Drawing.Size(73, 25)
        Me.lblOpenAll.TabIndex = 35
        Me.lblOpenAll.Text = "Open All"
        Me.lblOpenAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLockerSetting
        '
        Me.lblLockerSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLockerSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblLockerSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblLockerSetting.ForeColor = System.Drawing.Color.White
        Me.lblLockerSetting.Location = New System.Drawing.Point(19, 14)
        Me.lblLockerSetting.Name = "lblLockerSetting"
        Me.lblLockerSetting.Size = New System.Drawing.Size(120, 25)
        Me.lblLockerSetting.TabIndex = 35
        Me.lblLockerSetting.Text = "Locker Setting"
        Me.lblLockerSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDeviceSetting
        '
        Me.lblDeviceSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDeviceSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblDeviceSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblDeviceSetting.ForeColor = System.Drawing.Color.White
        Me.lblDeviceSetting.Location = New System.Drawing.Point(20, 16)
        Me.lblDeviceSetting.Name = "lblDeviceSetting"
        Me.lblDeviceSetting.Size = New System.Drawing.Size(118, 25)
        Me.lblDeviceSetting.TabIndex = 35
        Me.lblDeviceSetting.Text = "Device Setting"
        Me.lblDeviceSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKioskSetting
        '
        Me.lblKioskSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblKioskSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblKioskSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblKioskSetting.ForeColor = System.Drawing.Color.White
        Me.lblKioskSetting.Location = New System.Drawing.Point(22, 15)
        Me.lblKioskSetting.Name = "lblKioskSetting"
        Me.lblKioskSetting.Size = New System.Drawing.Size(111, 25)
        Me.lblKioskSetting.TabIndex = 35
        Me.lblKioskSetting.Text = "Kiosk Setting"
        Me.lblKioskSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFillMoney
        '
        Me.lblFillMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFillMoney.BackColor = System.Drawing.Color.Transparent
        Me.lblFillMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblFillMoney.ForeColor = System.Drawing.Color.White
        Me.lblFillMoney.Location = New System.Drawing.Point(23, 14)
        Me.lblFillMoney.Name = "lblFillMoney"
        Me.lblFillMoney.Size = New System.Drawing.Size(109, 26)
        Me.lblFillMoney.TabIndex = 35
        Me.lblFillMoney.Text = "Fill Money"
        Me.lblFillMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFillPaper
        '
        Me.lblFillPaper.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFillPaper.BackColor = System.Drawing.Color.Transparent
        Me.lblFillPaper.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblFillPaper.ForeColor = System.Drawing.Color.White
        Me.lblFillPaper.Location = New System.Drawing.Point(27, 14)
        Me.lblFillPaper.Name = "lblFillPaper"
        Me.lblFillPaper.Size = New System.Drawing.Size(104, 26)
        Me.lblFillPaper.TabIndex = 35
        Me.lblFillPaper.Text = "Fill Paper"
        Me.lblFillPaper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOpenAll
        '
        Me.btnOpenAll.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOpenAll.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnOpenAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenAll.Controls.Add(Me.lblOpenAll)
        Me.btnOpenAll.Location = New System.Drawing.Point(815, 610)
        Me.btnOpenAll.Name = "btnOpenAll"
        Me.btnOpenAll.Size = New System.Drawing.Size(157, 52)
        Me.btnOpenAll.TabIndex = 67
        '
        'btnLockerSetting
        '
        Me.btnLockerSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnLockerSetting.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnLockerSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLockerSetting.Controls.Add(Me.lblLockerSetting)
        Me.btnLockerSetting.Location = New System.Drawing.Point(815, 547)
        Me.btnLockerSetting.Name = "btnLockerSetting"
        Me.btnLockerSetting.Size = New System.Drawing.Size(157, 55)
        Me.btnLockerSetting.TabIndex = 66
        '
        'btnDeviceSetting
        '
        Me.btnDeviceSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDeviceSetting.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnDeviceSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeviceSetting.Controls.Add(Me.lblDeviceSetting)
        Me.btnDeviceSetting.Location = New System.Drawing.Point(815, 481)
        Me.btnDeviceSetting.Name = "btnDeviceSetting"
        Me.btnDeviceSetting.Size = New System.Drawing.Size(157, 58)
        Me.btnDeviceSetting.TabIndex = 66
        '
        'btnKioskSetting
        '
        Me.btnKioskSetting.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnKioskSetting.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnKioskSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnKioskSetting.Controls.Add(Me.lblKioskSetting)
        Me.btnKioskSetting.Location = New System.Drawing.Point(815, 420)
        Me.btnKioskSetting.Name = "btnKioskSetting"
        Me.btnKioskSetting.Size = New System.Drawing.Size(157, 55)
        Me.btnKioskSetting.TabIndex = 65
        '
        'btnFillMoney
        '
        Me.btnFillMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFillMoney.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnFillMoney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFillMoney.Controls.Add(Me.lblFillMoney)
        Me.btnFillMoney.Location = New System.Drawing.Point(815, 304)
        Me.btnFillMoney.Name = "btnFillMoney"
        Me.btnFillMoney.Size = New System.Drawing.Size(157, 54)
        Me.btnFillMoney.TabIndex = 64
        '
        'btnFillPaper
        '
        Me.btnFillPaper.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFillPaper.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnFillPaper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFillPaper.Controls.Add(Me.lblFillPaper)
        Me.btnFillPaper.Location = New System.Drawing.Point(814, 242)
        Me.btnFillPaper.Name = "btnFillPaper"
        Me.btnFillPaper.Size = New System.Drawing.Size(158, 55)
        Me.btnFillPaper.TabIndex = 63
        '
        'lblCollect
        '
        Me.lblCollect.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCollect.BackColor = System.Drawing.Color.Transparent
        Me.lblCollect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCollect.ForeColor = System.Drawing.Color.White
        Me.lblCollect.Location = New System.Drawing.Point(23, 14)
        Me.lblCollect.Name = "lblCollect"
        Me.lblCollect.Size = New System.Drawing.Size(109, 26)
        Me.lblCollect.TabIndex = 35
        Me.lblCollect.Text = "Collect"
        Me.lblCollect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCollect
        '
        Me.btnCollect.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCollect.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnCollect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCollect.Controls.Add(Me.lblCollect)
        Me.btnCollect.Location = New System.Drawing.Point(815, 362)
        Me.btnCollect.Name = "btnCollect"
        Me.btnCollect.Size = New System.Drawing.Size(157, 53)
        Me.btnCollect.TabIndex = 65
        '
        'frmSC_StockAndHardware
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.bgSCStockAndHardware
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.btnCollect)
        Me.Controls.Add(Me.btnOpenAll)
        Me.Controls.Add(Me.btnLockerSetting)
        Me.Controls.Add(Me.btnDeviceSetting)
        Me.Controls.Add(Me.btnKioskSetting)
        Me.Controls.Add(Me.btnFillMoney)
        Me.Controls.Add(Me.btnFillPaper)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_StockAndHardware"
        Me.btnOpenAll.ResumeLayout(False)
        Me.btnLockerSetting.ResumeLayout(False)
        Me.btnDeviceSetting.ResumeLayout(False)
        Me.btnKioskSetting.ResumeLayout(False)
        Me.btnFillMoney.ResumeLayout(False)
        Me.btnFillPaper.ResumeLayout(False)
        Me.btnCollect.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFillPaper As Label
    Friend WithEvents lblFillMoney As Label
    Friend WithEvents lblKioskSetting As Label
    Friend WithEvents lblDeviceSetting As Label
    Friend WithEvents lblLockerSetting As Label
    Friend WithEvents lblOpenAll As Label
    Friend WithEvents TimerCheckDoorClose As Timer
    Friend WithEvents btnOpenAll As Panel
    Friend WithEvents btnLockerSetting As Panel
    Friend WithEvents btnDeviceSetting As Panel
    Friend WithEvents btnKioskSetting As Panel
    Friend WithEvents btnFillMoney As Panel
    Friend WithEvents btnFillPaper As Panel
    Friend WithEvents lblCollect As Label
    Friend WithEvents btnCollect As Panel
End Class
