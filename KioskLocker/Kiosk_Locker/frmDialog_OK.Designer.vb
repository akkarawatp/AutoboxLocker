<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDialog_OK
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
        Me.pnlDialog = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Panel()
        Me.lblOK = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.pnlDialog.SuspendLayout()
        Me.btnOK.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDialog
        '
        Me.pnlDialog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDialog.Controls.Add(Me.btnOK)
        Me.pnlDialog.Controls.Add(Me.lblMessage)
        Me.pnlDialog.Location = New System.Drawing.Point(12, 12)
        Me.pnlDialog.Name = "pnlDialog"
        Me.pnlDialog.Size = New System.Drawing.Size(767, 435)
        Me.pnlDialog.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Controls.Add(Me.lblOK)
        Me.btnOK.Location = New System.Drawing.Point(283, 332)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(200, 71)
        Me.btnOK.TabIndex = 38
        '
        'lblOK
        '
        Me.lblOK.BackColor = System.Drawing.Color.Transparent
        Me.lblOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblOK.ForeColor = System.Drawing.Color.Black
        Me.lblOK.Location = New System.Drawing.Point(45, 12)
        Me.lblOK.Name = "lblOK"
        Me.lblOK.Size = New System.Drawing.Size(111, 44)
        Me.lblOK.TabIndex = 39
        Me.lblOK.Text = "OK"
        Me.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(17, 32)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(747, 297)
        Me.lblMessage.TabIndex = 33
        Me.lblMessage.Text = "Scanning Unsuccessful  !!!"
        '
        'frmDialog_OK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(791, 459)
        Me.Controls.Add(Me.pnlDialog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDialog_OK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDialog_OK"
        Me.pnlDialog.ResumeLayout(False)
        Me.btnOK.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDialog As Panel
    Friend WithEvents lblMessage As Label
    Friend WithEvents btnOK As Panel
    Friend WithEvents lblOK As Label
End Class
