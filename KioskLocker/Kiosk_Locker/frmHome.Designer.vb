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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlPickup = New System.Windows.Forms.Panel()
        Me.lblPickup = New System.Windows.Forms.Label()
        Me.pnlDeposit = New System.Windows.Forms.Panel()
        Me.lblDeposit = New System.Windows.Forms.Label()
        Me.lblLabelNotification = New System.Windows.Forms.Label()
        Me.pnlPickup.SuspendLayout()
        Me.pnlDeposit.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.Font = New System.Drawing.Font("Thai Sans Lite", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 53)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1000, 80)
        Me.lblTitle.TabIndex = 12
        Me.lblTitle.Text = "เลือกการใช้งาน"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPickup
        '
        Me.pnlPickup.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.IconPickup
        Me.pnlPickup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPickup.Controls.Add(Me.lblPickup)
        Me.pnlPickup.Enabled = False
        Me.pnlPickup.Location = New System.Drawing.Point(552, 183)
        Me.pnlPickup.Name = "pnlPickup"
        Me.pnlPickup.Size = New System.Drawing.Size(255, 255)
        Me.pnlPickup.TabIndex = 18
        '
        'lblPickup
        '
        Me.lblPickup.BackColor = System.Drawing.Color.Transparent
        Me.lblPickup.Font = New System.Drawing.Font("Thai Sans Lite", 40.0!, System.Drawing.FontStyle.Bold)
        Me.lblPickup.Location = New System.Drawing.Point(7, 174)
        Me.lblPickup.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPickup.Name = "lblPickup"
        Me.lblPickup.Size = New System.Drawing.Size(241, 76)
        Me.lblPickup.TabIndex = 17
        Me.lblPickup.Text = "รับคืน"
        Me.lblPickup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDeposit
        '
        Me.pnlDeposit.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.IconDeposit
        Me.pnlDeposit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlDeposit.Controls.Add(Me.lblDeposit)
        Me.pnlDeposit.Enabled = False
        Me.pnlDeposit.Location = New System.Drawing.Point(221, 183)
        Me.pnlDeposit.Name = "pnlDeposit"
        Me.pnlDeposit.Size = New System.Drawing.Size(255, 255)
        Me.pnlDeposit.TabIndex = 16
        '
        'lblDeposit
        '
        Me.lblDeposit.BackColor = System.Drawing.Color.Transparent
        Me.lblDeposit.Font = New System.Drawing.Font("Thai Sans Lite", 40.0!, System.Drawing.FontStyle.Bold)
        Me.lblDeposit.Location = New System.Drawing.Point(7, 174)
        Me.lblDeposit.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDeposit.Name = "lblDeposit"
        Me.lblDeposit.Size = New System.Drawing.Size(241, 76)
        Me.lblDeposit.TabIndex = 17
        Me.lblDeposit.Text = "ฝาก"
        Me.lblDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabelNotification
        '
        Me.lblLabelNotification.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLabelNotification.Font = New System.Drawing.Font("Thai Sans Lite", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabelNotification.ForeColor = System.Drawing.Color.Red
        Me.lblLabelNotification.Location = New System.Drawing.Point(135, 441)
        Me.lblLabelNotification.Name = "lblLabelNotification"
        Me.lblLabelNotification.Size = New System.Drawing.Size(755, 64)
        Me.lblLabelNotification.TabIndex = 94
        Me.lblLabelNotification.Text = "เหรียญสำหรับทอนชนิด 5 บาท หมด" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "กรุณาชำระเงินให้พอดี"
        Me.lblLabelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLabelNotification.Visible = False
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 553)
        Me.Controls.Add(Me.lblLabelNotification)
        Me.Controls.Add(Me.pnlPickup)
        Me.Controls.Add(Me.pnlDeposit)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmHome"
        Me.pnlPickup.ResumeLayout(False)
        Me.pnlDeposit.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlDeposit As Panel
    Friend WithEvents lblDeposit As Label
    Friend WithEvents pnlPickup As Panel
    Friend WithEvents lblPickup As Label
    Friend WithEvents lblLabelNotification As Label
End Class
