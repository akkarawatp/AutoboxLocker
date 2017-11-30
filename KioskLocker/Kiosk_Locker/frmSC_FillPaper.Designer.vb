<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSC_FillPaper
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
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Panel()
        Me.btnConfirm = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'txtValue
        '
        Me.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.txtValue.Location = New System.Drawing.Point(561, 251)
        Me.txtValue.MaxLength = 15
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(306, 46)
        Me.txtValue.TabIndex = 52
        Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMax
        '
        Me.txtMax.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMax.Enabled = False
        Me.txtMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.txtMax.Location = New System.Drawing.Point(561, 359)
        Me.txtMax.MaxLength = 15
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(303, 46)
        Me.txtMax.TabIndex = 53
        Me.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonCancel
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Location = New System.Drawing.Point(717, 424)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(171, 62)
        Me.btnCancel.TabIndex = 55
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnConfirm.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnButtonConfirm
        Me.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirm.Location = New System.Drawing.Point(538, 424)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(173, 62)
        Me.btnConfirm.TabIndex = 54
        '
        'frmSC_FillPaper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.bgSCFillPaper
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.txtMax)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_FillPaper"
        Me.Text = "frmSC_FillPaper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtValue As TextBox
    Friend WithEvents txtMax As TextBox
    Friend WithEvents btnCancel As Panel
    Friend WithEvents btnConfirm As Panel
End Class
