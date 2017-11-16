<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_TimeOut
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlDialog = New System.Windows.Forms.Panel()
        Me.lblMessage2 = New System.Windows.Forms.Label()
        Me.btnNo = New System.Windows.Forms.Panel()
        Me.lblNo = New System.Windows.Forms.Label()
        Me.btnYes = New System.Windows.Forms.Panel()
        Me.lblYes = New System.Windows.Forms.Label()
        Me.lblMessage1 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.TimerCount = New System.Windows.Forms.Timer(Me.components)
        Me.pnlDialog.SuspendLayout()
        Me.btnNo.SuspendLayout()
        Me.btnYes.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDialog
        '
        Me.pnlDialog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDialog.BackColor = System.Drawing.Color.White
        Me.pnlDialog.Controls.Add(Me.lblMessage2)
        Me.pnlDialog.Controls.Add(Me.btnNo)
        Me.pnlDialog.Controls.Add(Me.btnYes)
        Me.pnlDialog.Controls.Add(Me.lblMessage1)
        Me.pnlDialog.Controls.Add(Me.lblCount)
        Me.pnlDialog.Location = New System.Drawing.Point(12, 12)
        Me.pnlDialog.Name = "pnlDialog"
        Me.pnlDialog.Size = New System.Drawing.Size(712, 411)
        Me.pnlDialog.TabIndex = 2
        '
        'lblMessage2
        '
        Me.lblMessage2.BackColor = System.Drawing.Color.White
        Me.lblMessage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblMessage2.ForeColor = System.Drawing.Color.Black
        Me.lblMessage2.Location = New System.Drawing.Point(17, 96)
        Me.lblMessage2.Name = "lblMessage2"
        Me.lblMessage2.Size = New System.Drawing.Size(674, 51)
        Me.lblMessage2.TabIndex = 42
        Me.lblMessage2.Text = "Do you want to continue process ?"
        '
        'btnNo
        '
        Me.btnNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNo.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnBG
        Me.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNo.Controls.Add(Me.lblNo)
        Me.btnNo.Location = New System.Drawing.Point(373, 327)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(169, 56)
        Me.btnNo.TabIndex = 40
        '
        'lblNo
        '
        Me.lblNo.BackColor = System.Drawing.Color.Transparent
        Me.lblNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.Location = New System.Drawing.Point(24, 13)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(124, 30)
        Me.lblNo.TabIndex = 39
        Me.lblNo.Text = "ไม่ใช่ / No"
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnYes
        '
        Me.btnYes.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnYes.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnBG
        Me.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYes.Controls.Add(Me.lblYes)
        Me.btnYes.Location = New System.Drawing.Point(170, 327)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(169, 56)
        Me.btnYes.TabIndex = 38
        '
        'lblYes
        '
        Me.lblYes.BackColor = System.Drawing.Color.Transparent
        Me.lblYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblYes.ForeColor = System.Drawing.Color.Black
        Me.lblYes.Location = New System.Drawing.Point(24, 13)
        Me.lblYes.Name = "lblYes"
        Me.lblYes.Size = New System.Drawing.Size(124, 30)
        Me.lblYes.TabIndex = 39
        Me.lblYes.Text = "ใช่ / Yes"
        Me.lblYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMessage1
        '
        Me.lblMessage1.BackColor = System.Drawing.Color.White
        Me.lblMessage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblMessage1.ForeColor = System.Drawing.Color.Black
        Me.lblMessage1.Location = New System.Drawing.Point(17, 41)
        Me.lblMessage1.Name = "lblMessage1"
        Me.lblMessage1.Size = New System.Drawing.Size(550, 55)
        Me.lblMessage1.TabIndex = 33
        Me.lblMessage1.Text = "ต้องการทำรายการต่อหรือไม่ ?"
        '
        'lblCount
        '
        Me.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 100.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Red
        Me.lblCount.Location = New System.Drawing.Point(170, 147)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(372, 158)
        Me.lblCount.TabIndex = 41
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerCount
        '
        Me.TimerCount.Enabled = True
        Me.TimerCount.Interval = 1000
        '
        'frmDialog_TimeOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(736, 435)
        Me.Controls.Add(Me.pnlDialog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDialog_TimeOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDialog_TimeOut"
        Me.pnlDialog.ResumeLayout(False)
        Me.btnNo.ResumeLayout(False)
        Me.btnYes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDialog As Panel
    Friend WithEvents btnNo As Panel
    Friend WithEvents lblNo As Label
    Friend WithEvents btnYes As Panel
    Friend WithEvents lblYes As Label
    Friend WithEvents lblMessage1 As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents TimerCount As Timer
    Friend WithEvents lblMessage2 As Label
End Class
