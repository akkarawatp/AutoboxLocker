<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarcodeScannerConnectDavice
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
        Me.txtVID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtVID
        '
        Me.txtVID.Enabled = False
        Me.txtVID.Location = New System.Drawing.Point(81, 38)
        Me.txtVID.Name = "txtVID"
        Me.txtVID.Size = New System.Drawing.Size(105, 23)
        Me.txtVID.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "VID :"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.Black
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtStatus.ForeColor = System.Drawing.Color.Red
        Me.txtStatus.Location = New System.Drawing.Point(81, 67)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(234, 23)
        Me.txtStatus.TabIndex = 51
        Me.txtStatus.Text = "Disconnected"
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Status :"
        '
        'lblHead
        '
        Me.lblHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHead.BackColor = System.Drawing.Color.SteelBlue
        Me.lblHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.White
        Me.lblHead.Location = New System.Drawing.Point(2, 2)
        Me.lblHead.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(316, 30)
        Me.lblHead.TabIndex = 47
        Me.lblHead.Text = "QR Code Scanner"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BarcodeScannerConnectDavice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.txtVID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblHead)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "BarcodeScannerConnectDavice"
        Me.Size = New System.Drawing.Size(320, 96)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtVID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblHead As System.Windows.Forms.Label
End Class
