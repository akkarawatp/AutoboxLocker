<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHome
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
        Me.lblLabelNotification = New System.Windows.Forms.Label()
        Me.lblCollect = New System.Windows.Forms.Label()
        Me.lblDeposit = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblLabelNotification
        '
        Me.lblLabelNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelNotification.Font = New System.Drawing.Font("Thai Sans Lite", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabelNotification.ForeColor = System.Drawing.Color.Red
        Me.lblLabelNotification.Location = New System.Drawing.Point(133, 691)
        Me.lblLabelNotification.Name = "lblLabelNotification"
        Me.lblLabelNotification.Size = New System.Drawing.Size(755, 64)
        Me.lblLabelNotification.TabIndex = 94
        Me.lblLabelNotification.Text = "เหรียญสำหรับทอนชนิด 5 บาท หมด" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "กรุณาชำระเงินให้พอดี"
        Me.lblLabelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLabelNotification.Visible = False
        '
        'lblCollect
        '
        Me.lblCollect.BackColor = System.Drawing.Color.White
        Me.lblCollect.Font = New System.Drawing.Font("Thai Sans Lite", 40.0!, System.Drawing.FontStyle.Bold)
        Me.lblCollect.Image = Global.MiniboxLocker.My.Resources.Resources.imgButtonIconCollect
        Me.lblCollect.Location = New System.Drawing.Point(523, 208)
        Me.lblCollect.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCollect.Name = "lblCollect"
        Me.lblCollect.Size = New System.Drawing.Size(350, 484)
        Me.lblCollect.TabIndex = 17
        Me.lblCollect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDeposit
        '
        Me.lblDeposit.BackColor = System.Drawing.Color.White
        Me.lblDeposit.Font = New System.Drawing.Font("Thai Sans Lite", 40.0!, System.Drawing.FontStyle.Bold)
        Me.lblDeposit.Image = Global.MiniboxLocker.My.Resources.Resources.imgButtonIconDeposit
        Me.lblDeposit.Location = New System.Drawing.Point(127, 224)
        Me.lblDeposit.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDeposit.Name = "lblDeposit"
        Me.lblDeposit.Size = New System.Drawing.Size(347, 467)
        Me.lblDeposit.TabIndex = 17
        Me.lblDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgHome
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.lblCollect)
        Me.Controls.Add(Me.lblDeposit)
        Me.Controls.Add(Me.lblLabelNotification)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmHome"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDeposit As Label
    Friend WithEvents lblCollect As Label
    Friend WithEvents lblLabelNotification As Label
End Class
