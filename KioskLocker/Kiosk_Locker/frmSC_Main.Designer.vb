<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSC_Main
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
        Me.TimerCheckOpenClose = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSetPointer = New System.Windows.Forms.Timer(Me.components)
        Me.TimerCheckAutoSleep = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnExitProgram = New System.Windows.Forms.PictureBox()
        Me.pnlHead.SuspendLayout()
        CType(Me.btnExitProgram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerCheckOpenClose
        '
        Me.TimerCheckOpenClose.Interval = 10000
        '
        'TimerSetPointer
        '
        Me.TimerSetPointer.Interval = 2000
        '
        'TimerCheckAutoSleep
        '
        Me.TimerCheckAutoSleep.Enabled = True
        Me.TimerCheckAutoSleep.Interval = 60000
        '
        'pnlHead
        '
        Me.pnlHead.BackColor = System.Drawing.Color.Transparent
        Me.pnlHead.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgSCHeader
        Me.pnlHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHead.Controls.Add(Me.lblTitle)
        Me.pnlHead.Controls.Add(Me.btnExitProgram)
        Me.pnlHead.Location = New System.Drawing.Point(0, 0)
        Me.pnlHead.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(768, 113)
        Me.pnlHead.TabIndex = 45
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(143, 39)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(423, 42)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "lblTitle"
        '
        'btnExitProgram
        '
        Me.btnExitProgram.BackColor = System.Drawing.Color.White
        Me.btnExitProgram.Image = Global.MiniboxLocker.My.Resources.Resources.imgButtonExitProgram
        Me.btnExitProgram.Location = New System.Drawing.Point(570, 32)
        Me.btnExitProgram.Name = "btnExitProgram"
        Me.btnExitProgram.Size = New System.Drawing.Size(166, 56)
        Me.btnExitProgram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnExitProgram.TabIndex = 0
        Me.btnExitProgram.TabStop = False
        '
        'frmSC_Main
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(768, 1024)
        Me.Controls.Add(Me.pnlHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.Name = "frmSC_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.pnlHead.ResumeLayout(False)
        CType(Me.btnExitProgram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHead As Panel
    Friend WithEvents TimerCheckOpenClose As Timer
    Friend WithEvents TimerSetPointer As Timer
    Friend WithEvents TimerCheckAutoSleep As Timer
    Friend WithEvents btnExitProgram As PictureBox
    Friend WithEvents lblTitle As Label
End Class
