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
        Me.TimerCheckOpenClose = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSetPointer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.pnlCancel = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Label()
        Me.btnPointer = New System.Windows.Forms.Button()
        Me.TimerCheckAutoSleep = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.pnlFooter.SuspendLayout()
        Me.pnlCancel.SuspendLayout()
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
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.Transparent
        Me.pnlFooter.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.bgMainFooter
        Me.pnlFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlFooter.Controls.Add(Me.pnlCancel)
        Me.pnlFooter.Location = New System.Drawing.Point(0, 688)
        Me.pnlFooter.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(1024, 80)
        Me.pnlFooter.TabIndex = 11
        '
        'pnlCancel
        '
        Me.pnlCancel.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnBG
        Me.pnlCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCancel.Controls.Add(Me.btnCancel)
        Me.pnlCancel.Location = New System.Drawing.Point(454, 2)
        Me.pnlCancel.Name = "pnlCancel"
        Me.pnlCancel.Size = New System.Drawing.Size(116, 44)
        Me.pnlCancel.TabIndex = 4
        Me.pnlCancel.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(3, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(110, 27)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "ยกเลิก"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPointer
        '
        Me.btnPointer.BackColor = System.Drawing.Color.White
        Me.btnPointer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPointer.ForeColor = System.Drawing.Color.White
        Me.btnPointer.Location = New System.Drawing.Point(3, 711)
        Me.btnPointer.Name = "btnPointer"
        Me.btnPointer.Size = New System.Drawing.Size(55, 47)
        Me.btnPointer.TabIndex = 51
        Me.btnPointer.Text = "1"
        Me.btnPointer.UseVisualStyleBackColor = False
        '
        'TimerCheckAutoSleep
        '
        Me.TimerCheckAutoSleep.Enabled = True
        Me.TimerCheckAutoSleep.Interval = 60000
        '
        'pnlHead
        '
        Me.pnlHead.BackColor = System.Drawing.Color.Transparent
        Me.pnlHead.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.bgMainHeader
        Me.pnlHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHead.Location = New System.Drawing.Point(0, 0)
        Me.pnlHead.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(1024, 20)
        Me.pnlHead.TabIndex = 45
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.btnPointer)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlCancel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHead As Panel
    Friend WithEvents TimerCheckOpenClose As Timer
    Friend WithEvents btnPointer As Button
    Friend WithEvents TimerSetPointer As Timer
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents TimerCheckAutoSleep As Timer
    Friend WithEvents btnCancel As Label
    Friend WithEvents pnlCancel As Panel
End Class
