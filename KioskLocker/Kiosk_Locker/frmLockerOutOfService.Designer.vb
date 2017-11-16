<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLockerOutOfService
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
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl1
        '
        Me.lbl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl1.Font = New System.Drawing.Font("DB HelvethaicaAIS X 55 Regular", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.White
        Me.lbl1.Location = New System.Drawing.Point(12, 517)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(1056, 131)
        Me.lbl1.TabIndex = 4
        Me.lbl1.Text = "The kiosk is now on maintenance mode, "
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2
        '
        Me.lbl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl2.Font = New System.Drawing.Font("DB HelvethaicaAIS X 55 Regular", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl2.ForeColor = System.Drawing.Color.White
        Me.lbl2.Location = New System.Drawing.Point(12, 648)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(1056, 130)
        Me.lbl2.TabIndex = 5
        Me.lbl2.Text = "please go to AIS Counter."
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmVM_OutOfService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 1500)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.lbl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmVM_OutOfService"
        Me.Text = "frmVW_OutOfService"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl1 As Label
    Friend WithEvents lbl2 As Label
End Class
