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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.txtCoinInMoney = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Panel()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Panel()
        Me.lblConfirm = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBanknoteInMoney = New System.Windows.Forms.TextBox()
        Me.btnCheckOutMoney = New System.Windows.Forms.Panel()
        Me.lblCheckOutMoney = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCoinOut5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalCoinOut5 = New System.Windows.Forms.Label()
        Me.lblTotalBanknoteOut20 = New System.Windows.Forms.Label()
        Me.txtBanknoteOut20 = New System.Windows.Forms.TextBox()
        Me.lblTotalBanknoteOut100 = New System.Windows.Forms.Label()
        Me.txtBanknoteOut100 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalMoney = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnFillAllFull = New System.Windows.Forms.Panel()
        Me.lblFillAllFull = New System.Windows.Forms.Label()
        Me.lblMaxCoin5 = New System.Windows.Forms.Label()
        Me.lblMaxBanknote20 = New System.Windows.Forms.Label()
        Me.lblMaxBanknote100 = New System.Windows.Forms.Label()
        Me.btnCancel.SuspendLayout()
        Me.btnConfirm.SuspendLayout()
        Me.btnCheckOutMoney.SuspendLayout()
        Me.btnFillAllFull.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(43, 45)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(939, 97)
        Me.lblHeader.TabIndex = 44
        Me.lblHeader.Text = "Fill Money"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCoinInMoney
        '
        Me.txtCoinInMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCoinInMoney.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCoinInMoney.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCoinInMoney.Enabled = False
        Me.txtCoinInMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoinInMoney.Location = New System.Drawing.Point(510, 208)
        Me.txtCoinInMoney.MaxLength = 15
        Me.txtCoinInMoney.Name = "txtCoinInMoney"
        Me.txtCoinInMoney.Size = New System.Drawing.Size(190, 31)
        Me.txtCoinInMoney.TabIndex = 52
        Me.txtCoinInMoney.Text = "0.00"
        Me.txtCoinInMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(75, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(325, 42)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "จำนวนเงินในเครื่องรับเหรียญ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Controls.Add(Me.lblCancel)
        Me.btnCancel.Location = New System.Drawing.Point(562, 687)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(185, 54)
        Me.btnCancel.TabIndex = 55
        '
        'lblCancel
        '
        Me.lblCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCancel.BackColor = System.Drawing.Color.Transparent
        Me.lblCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCancel.ForeColor = System.Drawing.Color.Black
        Me.lblCancel.Location = New System.Drawing.Point(20, 13)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(144, 29)
        Me.lblCancel.TabIndex = 35
        Me.lblCancel.Text = "ยกเลิก"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnConfirm.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirm.Controls.Add(Me.lblConfirm)
        Me.btnConfirm.Location = New System.Drawing.Point(367, 687)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(185, 54)
        Me.btnConfirm.TabIndex = 54
        '
        'lblConfirm
        '
        Me.lblConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblConfirm.BackColor = System.Drawing.Color.Transparent
        Me.lblConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblConfirm.ForeColor = System.Drawing.Color.Black
        Me.lblConfirm.Location = New System.Drawing.Point(10, 14)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(164, 29)
        Me.lblConfirm.TabIndex = 35
        Me.lblConfirm.Text = "ยืนยัน"
        Me.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(75, 244)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(325, 42)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "จำนวนเงินในเครื่องรับธนบัตร"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBanknoteInMoney
        '
        Me.txtBanknoteInMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBanknoteInMoney.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtBanknoteInMoney.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBanknoteInMoney.Enabled = False
        Me.txtBanknoteInMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanknoteInMoney.Location = New System.Drawing.Point(510, 250)
        Me.txtBanknoteInMoney.MaxLength = 15
        Me.txtBanknoteInMoney.Name = "txtBanknoteInMoney"
        Me.txtBanknoteInMoney.Size = New System.Drawing.Size(190, 31)
        Me.txtBanknoteInMoney.TabIndex = 57
        Me.txtBanknoteInMoney.Text = "0.00"
        Me.txtBanknoteInMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCheckOutMoney
        '
        Me.btnCheckOutMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCheckOutMoney.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnCheckOutMoney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCheckOutMoney.Controls.Add(Me.lblCheckOutMoney)
        Me.btnCheckOutMoney.Location = New System.Drawing.Point(539, 291)
        Me.btnCheckOutMoney.Name = "btnCheckOutMoney"
        Me.btnCheckOutMoney.Size = New System.Drawing.Size(163, 44)
        Me.btnCheckOutMoney.TabIndex = 55
        '
        'lblCheckOutMoney
        '
        Me.lblCheckOutMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCheckOutMoney.BackColor = System.Drawing.Color.Transparent
        Me.lblCheckOutMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCheckOutMoney.ForeColor = System.Drawing.Color.Black
        Me.lblCheckOutMoney.Location = New System.Drawing.Point(3, 5)
        Me.lblCheckOutMoney.Name = "lblCheckOutMoney"
        Me.lblCheckOutMoney.Size = New System.Drawing.Size(157, 35)
        Me.lblCheckOutMoney.TabIndex = 35
        Me.lblCheckOutMoney.Text = "นำออกทั้งหมด"
        Me.lblCheckOutMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(75, 377)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(411, 31)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "จำนวนเหรียญ 5 บาทในเครื่องทอน"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(75, 419)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(411, 31)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "จำนวนธนบัตร 20 บาทในเครื่องทอน"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(75, 461)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(411, 31)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "จำนวนธนบัตร 100 บาทในเครื่องทอน"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCoinOut5
        '
        Me.txtCoinOut5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCoinOut5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCoinOut5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoinOut5.Location = New System.Drawing.Point(510, 377)
        Me.txtCoinOut5.MaxLength = 15
        Me.txtCoinOut5.Name = "txtCoinOut5"
        Me.txtCoinOut5.Size = New System.Drawing.Size(190, 31)
        Me.txtCoinOut5.TabIndex = 61
        Me.txtCoinOut5.Text = "0"
        Me.txtCoinOut5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(706, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 42)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "บาท"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(706, 244)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 42)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "บาท"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalCoinOut5
        '
        Me.lblTotalCoinOut5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalCoinOut5.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCoinOut5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTotalCoinOut5.ForeColor = System.Drawing.Color.White
        Me.lblTotalCoinOut5.Location = New System.Drawing.Point(706, 377)
        Me.lblTotalCoinOut5.Name = "lblTotalCoinOut5"
        Me.lblTotalCoinOut5.Size = New System.Drawing.Size(177, 31)
        Me.lblTotalCoinOut5.TabIndex = 64
        Me.lblTotalCoinOut5.Text = "/ 500 เหรียญ"
        Me.lblTotalCoinOut5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalBanknoteOut20
        '
        Me.lblTotalBanknoteOut20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalBanknoteOut20.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalBanknoteOut20.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTotalBanknoteOut20.ForeColor = System.Drawing.Color.White
        Me.lblTotalBanknoteOut20.Location = New System.Drawing.Point(705, 419)
        Me.lblTotalBanknoteOut20.Name = "lblTotalBanknoteOut20"
        Me.lblTotalBanknoteOut20.Size = New System.Drawing.Size(164, 31)
        Me.lblTotalBanknoteOut20.TabIndex = 66
        Me.lblTotalBanknoteOut20.Text = "/ 500 ใบ"
        Me.lblTotalBanknoteOut20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBanknoteOut20
        '
        Me.txtBanknoteOut20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBanknoteOut20.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBanknoteOut20.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanknoteOut20.Location = New System.Drawing.Point(509, 419)
        Me.txtBanknoteOut20.MaxLength = 15
        Me.txtBanknoteOut20.Name = "txtBanknoteOut20"
        Me.txtBanknoteOut20.Size = New System.Drawing.Size(190, 31)
        Me.txtBanknoteOut20.TabIndex = 65
        Me.txtBanknoteOut20.Text = "0"
        Me.txtBanknoteOut20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalBanknoteOut100
        '
        Me.lblTotalBanknoteOut100.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalBanknoteOut100.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalBanknoteOut100.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTotalBanknoteOut100.ForeColor = System.Drawing.Color.White
        Me.lblTotalBanknoteOut100.Location = New System.Drawing.Point(705, 461)
        Me.lblTotalBanknoteOut100.Name = "lblTotalBanknoteOut100"
        Me.lblTotalBanknoteOut100.Size = New System.Drawing.Size(164, 31)
        Me.lblTotalBanknoteOut100.TabIndex = 68
        Me.lblTotalBanknoteOut100.Text = "/ 500 ใบ"
        Me.lblTotalBanknoteOut100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBanknoteOut100
        '
        Me.txtBanknoteOut100.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBanknoteOut100.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBanknoteOut100.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanknoteOut100.Location = New System.Drawing.Point(509, 461)
        Me.txtBanknoteOut100.MaxLength = 15
        Me.txtBanknoteOut100.Name = "txtBanknoteOut100"
        Me.txtBanknoteOut100.Size = New System.Drawing.Size(190, 31)
        Me.txtBanknoteOut100.TabIndex = 67
        Me.txtBanknoteOut100.Text = "0"
        Me.txtBanknoteOut100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(640, 599)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(164, 31)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "บาท"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalMoney
        '
        Me.txtTotalMoney.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTotalMoney.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotalMoney.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalMoney.Enabled = False
        Me.txtTotalMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMoney.Location = New System.Drawing.Point(444, 599)
        Me.txtTotalMoney.MaxLength = 15
        Me.txtTotalMoney.Name = "txtTotalMoney"
        Me.txtTotalMoney.Size = New System.Drawing.Size(190, 31)
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
        Me.Label9.Location = New System.Drawing.Point(220, 599)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(220, 31)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "จำนวนเงินทั้งหมด"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFillAllFull
        '
        Me.btnFillAllFull.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFillAllFull.BackgroundImage = Global.AutoboxLocker.My.Resources.Resources.btnColWhite
        Me.btnFillAllFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFillAllFull.Controls.Add(Me.lblFillAllFull)
        Me.btnFillAllFull.Location = New System.Drawing.Point(539, 498)
        Me.btnFillAllFull.Name = "btnFillAllFull"
        Me.btnFillAllFull.Size = New System.Drawing.Size(163, 44)
        Me.btnFillAllFull.TabIndex = 56
        '
        'lblFillAllFull
        '
        Me.lblFillAllFull.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFillAllFull.BackColor = System.Drawing.Color.Transparent
        Me.lblFillAllFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblFillAllFull.ForeColor = System.Drawing.Color.Black
        Me.lblFillAllFull.Location = New System.Drawing.Point(3, 5)
        Me.lblFillAllFull.Name = "lblFillAllFull"
        Me.lblFillAllFull.Size = New System.Drawing.Size(157, 35)
        Me.lblFillAllFull.TabIndex = 35
        Me.lblFillAllFull.Text = "เติมเต็มจำนวน"
        Me.lblFillAllFull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMaxCoin5
        '
        Me.lblMaxCoin5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblMaxCoin5.BackColor = System.Drawing.Color.Transparent
        Me.lblMaxCoin5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblMaxCoin5.ForeColor = System.Drawing.Color.White
        Me.lblMaxCoin5.Location = New System.Drawing.Point(849, 377)
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
        Me.lblMaxBanknote20.Location = New System.Drawing.Point(811, 419)
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
        Me.lblMaxBanknote100.Location = New System.Drawing.Point(811, 461)
        Me.lblMaxBanknote100.Name = "lblMaxBanknote100"
        Me.lblMaxBanknote100.Size = New System.Drawing.Size(34, 31)
        Me.lblMaxBanknote100.TabIndex = 74
        Me.lblMaxBanknote100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMaxBanknote100.Visible = False
        '
        'frmSC_FillMoney
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.lblMaxBanknote100)
        Me.Controls.Add(Me.lblMaxBanknote20)
        Me.Controls.Add(Me.lblMaxCoin5)
        Me.Controls.Add(Me.btnFillAllFull)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTotalMoney)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblTotalBanknoteOut100)
        Me.Controls.Add(Me.txtBanknoteOut100)
        Me.Controls.Add(Me.lblTotalBanknoteOut20)
        Me.Controls.Add(Me.txtBanknoteOut20)
        Me.Controls.Add(Me.lblTotalCoinOut5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCoinOut5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCheckOutMoney)
        Me.Controls.Add(Me.txtBanknoteInMoney)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCoinInMoney)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSC_FillMoney"
        Me.Text = "frmSC_FillPaper"
        Me.btnCancel.ResumeLayout(False)
        Me.btnConfirm.ResumeLayout(False)
        Me.btnCheckOutMoney.ResumeLayout(False)
        Me.btnFillAllFull.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents txtCoinInMoney As TextBox
    Friend WithEvents btnCancel As Panel
    Friend WithEvents lblCancel As Label
    Friend WithEvents btnConfirm As Panel
    Friend WithEvents lblConfirm As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBanknoteInMoney As TextBox
    Friend WithEvents btnCheckOutMoney As Panel
    Friend WithEvents lblCheckOutMoney As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCoinOut5 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTotalCoinOut5 As Label
    Friend WithEvents lblTotalBanknoteOut20 As Label
    Friend WithEvents txtBanknoteOut20 As TextBox
    Friend WithEvents lblTotalBanknoteOut100 As Label
    Friend WithEvents txtBanknoteOut100 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTotalMoney As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnFillAllFull As Panel
    Friend WithEvents lblFillAllFull As Label
    Friend WithEvents lblMaxCoin5 As Label
    Friend WithEvents lblMaxBanknote20 As Label
    Friend WithEvents lblMaxBanknote100 As Label
End Class
