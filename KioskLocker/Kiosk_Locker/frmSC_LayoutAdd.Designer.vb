<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSC_LayoutAdd
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Panel()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Panel()
        Me.lblOK = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.pnlDialog.SuspendLayout()
        Me.btnCancel.SuspendLayout()
        Me.btnOK.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDialog
        '
        Me.pnlDialog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDialog.Controls.Add(Me.Label1)
        Me.pnlDialog.Controls.Add(Me.cmbModel)
        Me.pnlDialog.Controls.Add(Me.btnCancel)
        Me.pnlDialog.Controls.Add(Me.btnOK)
        Me.pnlDialog.Controls.Add(Me.lblHeader)
        Me.pnlDialog.Location = New System.Drawing.Point(12, 12)
        Me.pnlDialog.Name = "pnlDialog"
        Me.pnlDialog.Size = New System.Drawing.Size(560, 254)
        Me.pnlDialog.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(109, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 37)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "รุ่น"
        '
        'cmbModel
        '
        Me.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbModel.FormattingEnabled = True
        Me.cmbModel.Location = New System.Drawing.Point(168, 77)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(200, 39)
        Me.cmbModel.TabIndex = 41
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        'Me.btnCancel.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Controls.Add(Me.lblCancel)
        Me.btnCancel.Location = New System.Drawing.Point(275, 165)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(200, 71)
        Me.btnCancel.TabIndex = 40
        '
        'lblCancel
        '
        Me.lblCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCancel.ForeColor = System.Drawing.Color.Black
        Me.lblCancel.Location = New System.Drawing.Point(20, 12)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(153, 44)
        Me.lblCancel.TabIndex = 39
        Me.lblCancel.Text = "Cancel"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        'Me.btnOK.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Controls.Add(Me.lblOK)
        Me.btnOK.Location = New System.Drawing.Point(69, 165)
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
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(6, 7)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(147, 65)
        Me.lblHeader.TabIndex = 33
        Me.lblHeader.Text = "เพิ่มตู้"
        '
        'frmSC_LayoutAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(584, 278)
        Me.Controls.Add(Me.pnlDialog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_LayoutAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlDialog.ResumeLayout(False)
        Me.btnCancel.ResumeLayout(False)
        Me.btnOK.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDialog As Panel
    Friend WithEvents lblHeader As Label
    Friend WithEvents btnOK As Panel
    Friend WithEvents lblOK As Label
    Friend WithEvents btnCancel As Panel
    Friend WithEvents lblCancel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbModel As ComboBox
End Class
