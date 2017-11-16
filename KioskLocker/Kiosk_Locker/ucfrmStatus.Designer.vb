<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucfrmStatus
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.lblDetail = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pb)
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(203, 32)
        Me.pnlHeader.TabIndex = 0
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(1, 1)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(30, 30)
        Me.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb.TabIndex = 68
        Me.pb.TabStop = False
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Black
        Me.lblHeader.Location = New System.Drawing.Point(30, 2)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(170, 27)
        Me.lblHeader.TabIndex = 67
        Me.lblHeader.Text = "Cash Out"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDetail
        '
        Me.pnlDetail.BackColor = System.Drawing.Color.Green
        Me.pnlDetail.Controls.Add(Me.lblDetail)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Location = New System.Drawing.Point(0, 32)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(203, 37)
        Me.pnlDetail.TabIndex = 1
        '
        'lblDetail
        '
        Me.lblDetail.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDetail.BackColor = System.Drawing.Color.Transparent
        Me.lblDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblDetail.ForeColor = System.Drawing.Color.Black
        Me.lblDetail.Location = New System.Drawing.Point(-8, 3)
        Me.lblDetail.Name = "lblDetail"
        Me.lblDetail.Size = New System.Drawing.Size(208, 26)
        Me.lblDetail.TabIndex = 67
        Me.lblDetail.Text = "Ready"
        Me.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucfrmStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlDetail)
        Me.Controls.Add(Me.pnlHeader)
        Me.Margin = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.Name = "ucfrmStatus"
        Me.Size = New System.Drawing.Size(203, 69)
        Me.pnlHeader.ResumeLayout(False)
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblHeader As Label
    Friend WithEvents pnlDetail As Panel
    Friend WithEvents lblDetail As Label
    Friend WithEvents pb As PictureBox
End Class
