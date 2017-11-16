<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSC_FillPaper
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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Panel()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Panel()
        Me.lblConfirm = New System.Windows.Forms.Label()
        Me.btnCancel.SuspendLayout()
        Me.btnConfirm.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(43, 132)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(939, 97)
        Me.lblHeader.TabIndex = 44
        Me.lblHeader.Text = "Fill Paper"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtValue
        '
        Me.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!)
        Me.txtValue.Location = New System.Drawing.Point(535, 398)
        Me.txtValue.MaxLength = 15
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(374, 61)
        Me.txtValue.TabIndex = 52
        Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMax
        '
        Me.txtMax.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMax.BackColor = System.Drawing.Color.LightGray
        Me.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMax.Enabled = False
        Me.txtMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!)
        Me.txtMax.Location = New System.Drawing.Point(535, 508)
        Me.txtMax.MaxLength = 15
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(374, 61)
        Me.txtMax.TabIndex = 53
        Me.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 39.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(71, 508)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(458, 61)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "จำนวนครั้งพิมพ์สูงสุด"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 39.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(82, 398)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(447, 61)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "จำนวนครั้งที่พิมพ์ได้"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Controls.Add(Me.lblCancel)
        Me.btnCancel.Location = New System.Drawing.Point(730, 610)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(185, 78)
        Me.btnCancel.TabIndex = 55
        '
        'lblCancel
        '
        Me.lblCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCancel.ForeColor = System.Drawing.Color.Black
        Me.lblCancel.Location = New System.Drawing.Point(20, 11)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(144, 54)
        Me.lblCancel.TabIndex = 35
        Me.lblCancel.Text = "Cancel"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnConfirm.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirm.Controls.Add(Me.lblConfirm)
        Me.btnConfirm.Location = New System.Drawing.Point(535, 610)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(185, 78)
        Me.btnConfirm.TabIndex = 54
        '
        'lblConfirm
        '
        Me.lblConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblConfirm.BackColor = System.Drawing.Color.Transparent
        Me.lblConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblConfirm.ForeColor = System.Drawing.Color.Black
        Me.lblConfirm.Location = New System.Drawing.Point(10, 11)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(164, 54)
        Me.lblConfirm.TabIndex = 35
        Me.lblConfirm.Text = "Confirm"
        Me.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSC_FillPaper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.txtMax)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_FillPaper"
        Me.Text = "frmSC_FillPaper"
        Me.btnCancel.ResumeLayout(False)
        Me.btnConfirm.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents txtValue As TextBox
    Friend WithEvents txtMax As TextBox
    Friend WithEvents btnCancel As Panel
    Friend WithEvents lblCancel As Label
    Friend WithEvents btnConfirm As Panel
    Friend WithEvents lblConfirm As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
