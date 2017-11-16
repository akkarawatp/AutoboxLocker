<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLockerError
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
        Me.lblDetail = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblDetail
        '
        Me.lblDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblDetail.Font = New System.Drawing.Font("Superspace Regular", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblDetail.ForeColor = System.Drawing.Color.Red
        Me.lblDetail.Location = New System.Drawing.Point(12, 171)
        Me.lblDetail.Name = "lblDetail"
        Me.lblDetail.Size = New System.Drawing.Size(1000, 131)
        Me.lblDetail.TabIndex = 3
        Me.lblDetail.Text = "Out of Service"
        Me.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmLockerError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.lblDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLockerError"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDetail As Label
End Class
