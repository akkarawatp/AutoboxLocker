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
        Me.pbDeposit = New System.Windows.Forms.PictureBox()
        Me.pbCollect = New System.Windows.Forms.PictureBox()
        CType(Me.pbDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCollect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLabelNotification
        '
        Me.lblLabelNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelNotification.Font = New System.Drawing.Font("Thai Sans Lite", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabelNotification.ForeColor = System.Drawing.Color.Red
        Me.lblLabelNotification.Location = New System.Drawing.Point(5, 795)
        Me.lblLabelNotification.Name = "lblLabelNotification"
        Me.lblLabelNotification.Size = New System.Drawing.Size(755, 64)
        Me.lblLabelNotification.TabIndex = 94
        Me.lblLabelNotification.Text = "เหรียญสำหรับทอนชนิด 5 บาท หมด" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "กรุณาชำระเงินให้พอดี"
        Me.lblLabelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLabelNotification.Visible = False
        '
        'pbDeposit
        '
        Me.pbDeposit.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.imgButtonIconDeposit
        Me.pbDeposit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDeposit.Location = New System.Drawing.Point(30, 388)
        Me.pbDeposit.Name = "pbDeposit"
        Me.pbDeposit.Size = New System.Drawing.Size(347, 395)
        Me.pbDeposit.TabIndex = 95
        Me.pbDeposit.TabStop = False
        '
        'pbCollect
        '
        Me.pbCollect.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.imgButtonIconCollect
        Me.pbCollect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbCollect.Location = New System.Drawing.Point(398, 374)
        Me.pbCollect.Name = "pbCollect"
        Me.pbCollect.Size = New System.Drawing.Size(350, 409)
        Me.pbCollect.TabIndex = 96
        Me.pbCollect.TabStop = False
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgHome
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(768, 1006)
        Me.Controls.Add(Me.pbCollect)
        Me.Controls.Add(Me.pbDeposit)
        Me.Controls.Add(Me.lblLabelNotification)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmHome"
        CType(Me.pbDeposit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCollect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblLabelNotification As Label
    Friend WithEvents pbDeposit As PictureBox
    Friend WithEvents pbCollect As PictureBox
End Class
