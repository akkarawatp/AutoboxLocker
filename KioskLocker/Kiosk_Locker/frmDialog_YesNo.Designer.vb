<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_YesNo
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
        Me.pnlDialog = New System.Windows.Forms.Panel()
        Me.btnNo = New System.Windows.Forms.Panel()
        Me.lblNo = New System.Windows.Forms.Label()
        Me.btnYes = New System.Windows.Forms.Panel()
        Me.lblYes = New System.Windows.Forms.Label()
        Me.lblLine2 = New System.Windows.Forms.Label()
        Me.lblLine1 = New System.Windows.Forms.Label()
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
        Me.pnlDialog.Controls.Add(Me.btnNo)
        Me.pnlDialog.Controls.Add(Me.btnYes)
        Me.pnlDialog.Controls.Add(Me.lblLine2)
        Me.pnlDialog.Controls.Add(Me.lblLine1)
        Me.pnlDialog.Location = New System.Drawing.Point(12, 12)
        Me.pnlDialog.Name = "pnlDialog"
        Me.pnlDialog.Size = New System.Drawing.Size(894, 351)
        Me.pnlDialog.TabIndex = 0
        '
        'btnNo
        '
        Me.btnNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        'Me.btnNo.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnColWhite
        Me.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNo.Controls.Add(Me.lblNo)
        Me.btnNo.Location = New System.Drawing.Point(470, 252)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(200, 71)
        Me.btnNo.TabIndex = 38
        '
        'lblNo
        '
        Me.lblNo.BackColor = System.Drawing.Color.Transparent
        Me.lblNo.Font = New System.Drawing.Font("DB HelvethaicaAIS X 55 Regular", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.Location = New System.Drawing.Point(45, 12)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(111, 44)
        Me.lblNo.TabIndex = 40
        Me.lblNo.Text = "NO"
        Me.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnYes
        '
        Me.btnYes.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        'Me.btnYes.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnColWhite
        Me.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYes.Controls.Add(Me.lblYes)
        Me.btnYes.Location = New System.Drawing.Point(224, 252)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(200, 71)
        Me.btnYes.TabIndex = 37
        '
        'lblYes
        '
        Me.lblYes.BackColor = System.Drawing.Color.Transparent
        Me.lblYes.Font = New System.Drawing.Font("DB HelvethaicaAIS X 55 Regular", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblYes.ForeColor = System.Drawing.Color.Black
        Me.lblYes.Location = New System.Drawing.Point(45, 12)
        Me.lblYes.Name = "lblYes"
        Me.lblYes.Size = New System.Drawing.Size(111, 44)
        Me.lblYes.TabIndex = 39
        Me.lblYes.Text = "YES"
        Me.lblYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLine2
        '
        Me.lblLine2.BackColor = System.Drawing.Color.Transparent
        Me.lblLine2.Font = New System.Drawing.Font("DB HelvethaicaAIS X 55 Regular", 35.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLine2.ForeColor = System.Drawing.Color.White
        Me.lblLine2.Location = New System.Drawing.Point(17, 98)
        Me.lblLine2.Name = "lblLine2"
        Me.lblLine2.Size = New System.Drawing.Size(851, 48)
        Me.lblLine2.TabIndex = 36
        Me.lblLine2.Text = "Are you sure to back to select another package?"
        '
        'lblLine1
        '
        Me.lblLine1.BackColor = System.Drawing.Color.Transparent
        Me.lblLine1.Font = New System.Drawing.Font("DB HelvethaicaAIS X 55 Regular", 35.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLine1.ForeColor = System.Drawing.Color.White
        Me.lblLine1.Location = New System.Drawing.Point(17, 32)
        Me.lblLine1.Name = "lblLine1"
        Me.lblLine1.Size = New System.Drawing.Size(851, 57)
        Me.lblLine1.TabIndex = 33
        Me.lblLine1.Text = "Your paid money will not return if you back."
        '
        'frmDialog_YesNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(918, 375)
        Me.Controls.Add(Me.pnlDialog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDialog_YesNo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBuyNewSim_Payment_Dialog"
        Me.pnlDialog.ResumeLayout(False)
        Me.btnNo.ResumeLayout(False)
        Me.btnYes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDialog As Panel
    Friend WithEvents lblLine1 As Label
    Friend WithEvents lblLine2 As Label
    Friend WithEvents btnNo As Panel
    Friend WithEvents lblNo As Label
    Friend WithEvents btnYes As Panel
    Friend WithEvents lblYes As Label
End Class
