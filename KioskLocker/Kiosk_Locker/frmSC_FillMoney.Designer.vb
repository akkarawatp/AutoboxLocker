<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSC_FillMoney
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
        Me.txtCoinInMoney = New System.Windows.Forms.TextBox()
        Me.txtBanknoteInMoney = New System.Windows.Forms.TextBox()
        Me.txtCoinOut5 = New System.Windows.Forms.TextBox()
        Me.lblTotalCoinOut5 = New System.Windows.Forms.Label()
        Me.lblTotalBanknoteOut20 = New System.Windows.Forms.Label()
        Me.txtBanknoteOut20 = New System.Windows.Forms.TextBox()
        Me.lblTotalBanknoteOut100 = New System.Windows.Forms.Label()
        Me.txtBanknoteOut100 = New System.Windows.Forms.TextBox()
        Me.txtTotalMoney = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMaxCoin5 = New System.Windows.Forms.Label()
        Me.lblMaxBanknote20 = New System.Windows.Forms.Label()
        Me.lblMaxBanknote100 = New System.Windows.Forms.Label()
        Me.btnFillAllFull = New System.Windows.Forms.Panel()
        Me.lblFillAllFull = New System.Windows.Forms.Label()
        Me.btnCheckOutMoney = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Panel()
        Me.btnConfirm = New System.Windows.Forms.Panel()
        Me.btnFillAllFull.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCoinInMoney
        '
        Me.txtCoinInMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCoinInMoney.BackColor = System.Drawing.Color.White
        Me.txtCoinInMoney.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCoinInMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoinInMoney.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.txtCoinInMoney.Location = New System.Drawing.Point(66, 338)
        Me.txtCoinInMoney.MaxLength = 15
        Me.txtCoinInMoney.Name = "txtCoinInMoney"
        Me.txtCoinInMoney.ReadOnly = True
        Me.txtCoinInMoney.Size = New System.Drawing.Size(161, 46)
        Me.txtCoinInMoney.TabIndex = 52
        Me.txtCoinInMoney.Text = "0.00"
        Me.txtCoinInMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBanknoteInMoney
        '
        Me.txtBanknoteInMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBanknoteInMoney.BackColor = System.Drawing.Color.White
        Me.txtBanknoteInMoney.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBanknoteInMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanknoteInMoney.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.txtBanknoteInMoney.Location = New System.Drawing.Point(52, 498)
        Me.txtBanknoteInMoney.MaxLength = 15
        Me.txtBanknoteInMoney.Name = "txtBanknoteInMoney"
        Me.txtBanknoteInMoney.ReadOnly = True
        Me.txtBanknoteInMoney.Size = New System.Drawing.Size(184, 46)
        Me.txtBanknoteInMoney.TabIndex = 57
        Me.txtBanknoteInMoney.Text = "0.00"
        Me.txtBanknoteInMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCoinOut5
        '
        Me.txtCoinOut5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCoinOut5.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCoinOut5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCoinOut5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoinOut5.Location = New System.Drawing.Point(492, 276)
        Me.txtCoinOut5.MaxLength = 15
        Me.txtCoinOut5.Name = "txtCoinOut5"
        Me.txtCoinOut5.Size = New System.Drawing.Size(128, 31)
        Me.txtCoinOut5.TabIndex = 0
        Me.txtCoinOut5.Text = "0"
        Me.txtCoinOut5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalCoinOut5
        '
        Me.lblTotalCoinOut5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalCoinOut5.BackColor = System.Drawing.Color.White
        Me.lblTotalCoinOut5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.lblTotalCoinOut5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTotalCoinOut5.Location = New System.Drawing.Point(638, 279)
        Me.lblTotalCoinOut5.Name = "lblTotalCoinOut5"
        Me.lblTotalCoinOut5.Size = New System.Drawing.Size(123, 31)
        Me.lblTotalCoinOut5.TabIndex = 64
        Me.lblTotalCoinOut5.Text = "/ 500 เหรียญ"
        Me.lblTotalCoinOut5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalBanknoteOut20
        '
        Me.lblTotalBanknoteOut20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalBanknoteOut20.BackColor = System.Drawing.Color.White
        Me.lblTotalBanknoteOut20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.lblTotalBanknoteOut20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTotalBanknoteOut20.Location = New System.Drawing.Point(638, 343)
        Me.lblTotalBanknoteOut20.Name = "lblTotalBanknoteOut20"
        Me.lblTotalBanknoteOut20.Size = New System.Drawing.Size(97, 31)
        Me.lblTotalBanknoteOut20.TabIndex = 66
        Me.lblTotalBanknoteOut20.Text = "/ 500 ใบ"
        Me.lblTotalBanknoteOut20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBanknoteOut20
        '
        Me.txtBanknoteOut20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBanknoteOut20.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtBanknoteOut20.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBanknoteOut20.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanknoteOut20.Location = New System.Drawing.Point(492, 343)
        Me.txtBanknoteOut20.MaxLength = 15
        Me.txtBanknoteOut20.Name = "txtBanknoteOut20"
        Me.txtBanknoteOut20.Size = New System.Drawing.Size(128, 31)
        Me.txtBanknoteOut20.TabIndex = 1
        Me.txtBanknoteOut20.Text = "0"
        Me.txtBanknoteOut20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalBanknoteOut100
        '
        Me.lblTotalBanknoteOut100.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalBanknoteOut100.BackColor = System.Drawing.Color.White
        Me.lblTotalBanknoteOut100.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTotalBanknoteOut100.ForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTotalBanknoteOut100.Location = New System.Drawing.Point(638, 415)
        Me.lblTotalBanknoteOut100.Name = "lblTotalBanknoteOut100"
        Me.lblTotalBanknoteOut100.Size = New System.Drawing.Size(97, 31)
        Me.lblTotalBanknoteOut100.TabIndex = 68
        Me.lblTotalBanknoteOut100.Text = "/ 500 ใบ"
        Me.lblTotalBanknoteOut100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBanknoteOut100
        '
        Me.txtBanknoteOut100.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBanknoteOut100.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtBanknoteOut100.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBanknoteOut100.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanknoteOut100.Location = New System.Drawing.Point(492, 414)
        Me.txtBanknoteOut100.MaxLength = 15
        Me.txtBanknoteOut100.Name = "txtBanknoteOut100"
        Me.txtBanknoteOut100.Size = New System.Drawing.Size(128, 31)
        Me.txtBanknoteOut100.TabIndex = 2
        Me.txtBanknoteOut100.Text = "0"
        Me.txtBanknoteOut100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalMoney
        '
        Me.txtTotalMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTotalMoney.BackColor = System.Drawing.Color.White
        Me.txtTotalMoney.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 38.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalMoney.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.txtTotalMoney.Location = New System.Drawing.Point(385, 486)
        Me.txtTotalMoney.MaxLength = 15
        Me.txtTotalMoney.Name = "txtTotalMoney"
        Me.txtTotalMoney.ReadOnly = True
        Me.txtTotalMoney.Size = New System.Drawing.Size(254, 58)
        Me.txtTotalMoney.TabIndex = 70
        Me.txtTotalMoney.Text = "0.00"
        Me.txtTotalMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(149, 673)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(220, 31)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "จำนวนเงินทั้งหมด"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaxCoin5
        '
        Me.lblMaxCoin5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblMaxCoin5.BackColor = System.Drawing.Color.Transparent
        Me.lblMaxCoin5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblMaxCoin5.ForeColor = System.Drawing.Color.White
        Me.lblMaxCoin5.Location = New System.Drawing.Point(721, 377)
        Me.lblMaxCoin5.Name = "lblMaxCoin5"
        Me.lblMaxCoin5.Size = New System.Drawing.Size(34, 31)
        Me.lblMaxCoin5.TabIndex = 72
        Me.lblMaxCoin5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMaxCoin5.Visible = False
        '
        'lblMaxBanknote20
        '
        Me.lblMaxBanknote20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblMaxBanknote20.BackColor = System.Drawing.Color.Transparent
        Me.lblMaxBanknote20.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblMaxBanknote20.ForeColor = System.Drawing.Color.White
        Me.lblMaxBanknote20.Location = New System.Drawing.Point(629, 445)
        Me.lblMaxBanknote20.Name = "lblMaxBanknote20"
        Me.lblMaxBanknote20.Size = New System.Drawing.Size(34, 31)
        Me.lblMaxBanknote20.TabIndex = 73
        Me.lblMaxBanknote20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMaxBanknote20.Visible = False
        '
        'lblMaxBanknote100
        '
        Me.lblMaxBanknote100.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblMaxBanknote100.BackColor = System.Drawing.Color.Transparent
        Me.lblMaxBanknote100.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblMaxBanknote100.ForeColor = System.Drawing.Color.White
        Me.lblMaxBanknote100.Location = New System.Drawing.Point(683, 461)
        Me.lblMaxBanknote100.Name = "lblMaxBanknote100"
        Me.lblMaxBanknote100.Size = New System.Drawing.Size(34, 31)
        Me.lblMaxBanknote100.TabIndex = 74
        Me.lblMaxBanknote100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMaxBanknote100.Visible = False
        '
        'btnFillAllFull
        '
        Me.btnFillAllFull.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFillAllFull.BackColor = System.Drawing.Color.White
        Me.btnFillAllFull.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonOrange
        Me.btnFillAllFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFillAllFull.Controls.Add(Me.lblFillAllFull)
        Me.btnFillAllFull.ForeColor = System.Drawing.Color.White
        Me.btnFillAllFull.Location = New System.Drawing.Point(556, 582)
        Me.btnFillAllFull.Name = "btnFillAllFull"
        Me.btnFillAllFull.Size = New System.Drawing.Size(183, 51)
        Me.btnFillAllFull.TabIndex = 56
        '
        'lblFillAllFull
        '
        Me.lblFillAllFull.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFillAllFull.BackColor = System.Drawing.Color.Transparent
        Me.lblFillAllFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblFillAllFull.ForeColor = System.Drawing.Color.White
        Me.lblFillAllFull.Location = New System.Drawing.Point(13, 8)
        Me.lblFillAllFull.Name = "lblFillAllFull"
        Me.lblFillAllFull.Size = New System.Drawing.Size(157, 35)
        Me.lblFillAllFull.TabIndex = 35
        Me.lblFillAllFull.Text = "เติมเต็มจำนวน"
        Me.lblFillAllFull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCheckOutMoney
        '
        Me.btnCheckOutMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCheckOutMoney.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonCheckOutMoney
        Me.btnCheckOutMoney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCheckOutMoney.Location = New System.Drawing.Point(52, 582)
        Me.btnCheckOutMoney.Name = "btnCheckOutMoney"
        Me.btnCheckOutMoney.Size = New System.Drawing.Size(216, 50)
        Me.btnCheckOutMoney.TabIndex = 55
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonCancel
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Location = New System.Drawing.Point(430, 590)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 43)
        Me.btnCancel.TabIndex = 55
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnConfirm.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.btnButtonConfirm
        Me.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirm.Location = New System.Drawing.Point(307, 590)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(116, 43)
        Me.btnConfirm.TabIndex = 54
        '
        'frmSC_FillMoney
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgSCFillMoney
        Me.ClientSize = New System.Drawing.Size(768, 1024)
        Me.Controls.Add(Me.lblMaxBanknote100)
        Me.Controls.Add(Me.lblMaxBanknote20)
        Me.Controls.Add(Me.lblMaxCoin5)
        Me.Controls.Add(Me.btnFillAllFull)
        Me.Controls.Add(Me.txtTotalMoney)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblTotalBanknoteOut100)
        Me.Controls.Add(Me.txtBanknoteOut100)
        Me.Controls.Add(Me.lblTotalBanknoteOut20)
        Me.Controls.Add(Me.txtBanknoteOut20)
        Me.Controls.Add(Me.lblTotalCoinOut5)
        Me.Controls.Add(Me.txtCoinOut5)
        Me.Controls.Add(Me.btnCheckOutMoney)
        Me.Controls.Add(Me.txtBanknoteInMoney)
        Me.Controls.Add(Me.txtCoinInMoney)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_FillMoney"
        Me.Text = "frmSC_FillPaper"
        Me.btnFillAllFull.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoinInMoney As TextBox
    Friend WithEvents btnCancel As Panel
    Friend WithEvents btnConfirm As Panel
    Friend WithEvents txtBanknoteInMoney As TextBox
    Friend WithEvents btnCheckOutMoney As Panel
    Friend WithEvents txtCoinOut5 As TextBox
    Friend WithEvents lblTotalCoinOut5 As Label
    Friend WithEvents lblTotalBanknoteOut20 As Label
    Friend WithEvents txtBanknoteOut20 As TextBox
    Friend WithEvents lblTotalBanknoteOut100 As Label
    Friend WithEvents txtBanknoteOut100 As TextBox
    Friend WithEvents txtTotalMoney As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnFillAllFull As Panel
    Friend WithEvents lblFillAllFull As Label
    Friend WithEvents lblMaxCoin5 As Label
    Friend WithEvents lblMaxBanknote20 As Label
    Friend WithEvents lblMaxBanknote100 As Label
End Class
