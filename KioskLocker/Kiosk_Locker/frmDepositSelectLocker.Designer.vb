﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDepositSelectLocker
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
        Me.components = New System.ComponentModel.Container()
        Me.pnlCabinetLayout = New System.Windows.Forms.Panel()
        Me.pnlLayoutPC = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.UcCabinet10 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet9 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet8 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet7 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet6 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet5 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet4 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet3 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet2 = New MiniboxLocker.ucCabinet()
        Me.UcCabinet1 = New MiniboxLocker.ucCabinet()
        Me.TimerTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.pnlCabinetLayout.SuspendLayout()
        Me.pnlLayoutPC.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabinetLayout
        '
        Me.pnlCabinetLayout.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlCabinetLayout.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgLayoutSelectLocker
        Me.pnlCabinetLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCabinetLayout.Controls.Add(Me.pnlLayoutPC)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet10)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet9)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet8)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet7)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet6)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet5)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet4)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet3)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet2)
        Me.pnlCabinetLayout.Controls.Add(Me.UcCabinet1)
        Me.pnlCabinetLayout.Location = New System.Drawing.Point(0, 298)
        Me.pnlCabinetLayout.Name = "pnlCabinetLayout"
        Me.pnlCabinetLayout.Size = New System.Drawing.Size(761, 392)
        Me.pnlCabinetLayout.TabIndex = 45
        '
        'pnlLayoutPC
        '
        Me.pnlLayoutPC.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlLayoutPC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlLayoutPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLayoutPC.Controls.Add(Me.PictureBox2)
        Me.pnlLayoutPC.Location = New System.Drawing.Point(481, 5)
        Me.pnlLayoutPC.Name = "pnlLayoutPC"
        Me.pnlLayoutPC.Size = New System.Drawing.Size(68, 379)
        Me.pnlLayoutPC.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.MiniboxLocker.My.Resources.Resources.IconLockerControl
        Me.PictureBox2.Location = New System.Drawing.Point(2, 134)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(62, 31)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'UcCabinet10
        '
        Me.UcCabinet10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet10.CabinetActiveStatus = "N"
        Me.UcCabinet10.CabinetID = CType(0, Long)
        Me.UcCabinet10.CabinetModelID = CType(0, Long)
        Me.UcCabinet10.CabinetName = "J"
        Me.UcCabinet10.Location = New System.Drawing.Point(682, 5)
        Me.UcCabinet10.LockerActiveQty = 0
        Me.UcCabinet10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet10.Name = "UcCabinet10"
        Me.UcCabinet10.OrderLayoutNo = 10
        Me.UcCabinet10.Size = New System.Drawing.Size(68, 379)
        Me.UcCabinet10.TabIndex = 10
        '
        'UcCabinet9
        '
        Me.UcCabinet9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet9.CabinetActiveStatus = "N"
        Me.UcCabinet9.CabinetID = CType(0, Long)
        Me.UcCabinet9.CabinetModelID = CType(0, Long)
        Me.UcCabinet9.CabinetName = "I"
        Me.UcCabinet9.Location = New System.Drawing.Point(615, 5)
        Me.UcCabinet9.LockerActiveQty = 0
        Me.UcCabinet9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet9.Name = "UcCabinet9"
        Me.UcCabinet9.OrderLayoutNo = 9
        Me.UcCabinet9.Size = New System.Drawing.Size(68, 379)
        Me.UcCabinet9.TabIndex = 9
        '
        'UcCabinet8
        '
        Me.UcCabinet8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet8.CabinetActiveStatus = "N"
        Me.UcCabinet8.CabinetID = CType(0, Long)
        Me.UcCabinet8.CabinetModelID = CType(0, Long)
        Me.UcCabinet8.CabinetName = "H"
        Me.UcCabinet8.Location = New System.Drawing.Point(548, 5)
        Me.UcCabinet8.LockerActiveQty = 0
        Me.UcCabinet8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet8.Name = "UcCabinet8"
        Me.UcCabinet8.OrderLayoutNo = 8
        Me.UcCabinet8.Size = New System.Drawing.Size(68, 379)
        Me.UcCabinet8.TabIndex = 8
        '
        'UcCabinet7
        '
        Me.UcCabinet7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet7.CabinetActiveStatus = "N"
        Me.UcCabinet7.CabinetID = CType(0, Long)
        Me.UcCabinet7.CabinetModelID = CType(0, Long)
        Me.UcCabinet7.CabinetName = "G"
        Me.UcCabinet7.Location = New System.Drawing.Point(414, 5)
        Me.UcCabinet7.LockerActiveQty = 0
        Me.UcCabinet7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet7.Name = "UcCabinet7"
        Me.UcCabinet7.OrderLayoutNo = 7
        Me.UcCabinet7.Size = New System.Drawing.Size(68, 380)
        Me.UcCabinet7.TabIndex = 7
        '
        'UcCabinet6
        '
        Me.UcCabinet6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet6.CabinetActiveStatus = "N"
        Me.UcCabinet6.CabinetID = CType(0, Long)
        Me.UcCabinet6.CabinetModelID = CType(0, Long)
        Me.UcCabinet6.CabinetName = "F"
        Me.UcCabinet6.Location = New System.Drawing.Point(347, 5)
        Me.UcCabinet6.LockerActiveQty = 0
        Me.UcCabinet6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet6.Name = "UcCabinet6"
        Me.UcCabinet6.OrderLayoutNo = 6
        Me.UcCabinet6.Size = New System.Drawing.Size(68, 380)
        Me.UcCabinet6.TabIndex = 6
        '
        'UcCabinet5
        '
        Me.UcCabinet5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet5.CabinetActiveStatus = "N"
        Me.UcCabinet5.CabinetID = CType(0, Long)
        Me.UcCabinet5.CabinetModelID = CType(0, Long)
        Me.UcCabinet5.CabinetName = "E"
        Me.UcCabinet5.Location = New System.Drawing.Point(280, 5)
        Me.UcCabinet5.LockerActiveQty = 0
        Me.UcCabinet5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet5.Name = "UcCabinet5"
        Me.UcCabinet5.OrderLayoutNo = 5
        Me.UcCabinet5.Size = New System.Drawing.Size(68, 380)
        Me.UcCabinet5.TabIndex = 5
        '
        'UcCabinet4
        '
        Me.UcCabinet4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet4.CabinetActiveStatus = "N"
        Me.UcCabinet4.CabinetID = CType(0, Long)
        Me.UcCabinet4.CabinetModelID = CType(0, Long)
        Me.UcCabinet4.CabinetName = "D"
        Me.UcCabinet4.Location = New System.Drawing.Point(213, 5)
        Me.UcCabinet4.LockerActiveQty = 0
        Me.UcCabinet4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet4.Name = "UcCabinet4"
        Me.UcCabinet4.OrderLayoutNo = 4
        Me.UcCabinet4.Size = New System.Drawing.Size(68, 380)
        Me.UcCabinet4.TabIndex = 4
        '
        'UcCabinet3
        '
        Me.UcCabinet3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet3.CabinetActiveStatus = "N"
        Me.UcCabinet3.CabinetID = CType(0, Long)
        Me.UcCabinet3.CabinetModelID = CType(0, Long)
        Me.UcCabinet3.CabinetName = "C"
        Me.UcCabinet3.Location = New System.Drawing.Point(146, 5)
        Me.UcCabinet3.LockerActiveQty = 0
        Me.UcCabinet3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet3.Name = "UcCabinet3"
        Me.UcCabinet3.OrderLayoutNo = 3
        Me.UcCabinet3.Size = New System.Drawing.Size(68, 380)
        Me.UcCabinet3.TabIndex = 3
        '
        'UcCabinet2
        '
        Me.UcCabinet2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet2.CabinetActiveStatus = "N"
        Me.UcCabinet2.CabinetID = CType(0, Long)
        Me.UcCabinet2.CabinetModelID = CType(0, Long)
        Me.UcCabinet2.CabinetName = "B"
        Me.UcCabinet2.Location = New System.Drawing.Point(79, 5)
        Me.UcCabinet2.LockerActiveQty = 0
        Me.UcCabinet2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet2.Name = "UcCabinet2"
        Me.UcCabinet2.OrderLayoutNo = 2
        Me.UcCabinet2.Size = New System.Drawing.Size(68, 380)
        Me.UcCabinet2.TabIndex = 2
        '
        'UcCabinet1
        '
        Me.UcCabinet1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcCabinet1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcCabinet1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcCabinet1.CabinetActiveStatus = "N"
        Me.UcCabinet1.CabinetID = CType(0, Long)
        Me.UcCabinet1.CabinetModelID = CType(0, Long)
        Me.UcCabinet1.CabinetName = "A"
        Me.UcCabinet1.Location = New System.Drawing.Point(12, 5)
        Me.UcCabinet1.LockerActiveQty = 0
        Me.UcCabinet1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcCabinet1.Name = "UcCabinet1"
        Me.UcCabinet1.OrderLayoutNo = 1
        Me.UcCabinet1.Size = New System.Drawing.Size(68, 380)
        Me.UcCabinet1.TabIndex = 0
        '
        'TimerTimeOut
        '
        Me.TimerTimeOut.Interval = 1000
        '
        'frmDepositSelectLocker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgDepositSelectLocker
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(768, 1024)
        Me.Controls.Add(Me.pnlCabinetLayout)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDepositSelectLocker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlCabinetLayout.ResumeLayout(False)
        Me.pnlLayoutPC.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabinetLayout As Panel
    Friend WithEvents UcCabinet10 As ucCabinet
    Friend WithEvents UcCabinet9 As ucCabinet
    Friend WithEvents UcCabinet8 As ucCabinet
    Friend WithEvents UcCabinet7 As ucCabinet
    Friend WithEvents UcCabinet6 As ucCabinet
    Friend WithEvents UcCabinet5 As ucCabinet
    Friend WithEvents UcCabinet4 As ucCabinet
    Friend WithEvents UcCabinet3 As ucCabinet
    Friend WithEvents UcCabinet2 As ucCabinet
    Friend WithEvents pnlLayoutPC As Panel
    Friend WithEvents UcCabinet1 As ucCabinet
    Friend WithEvents TimerTimeOut As Timer
    Friend WithEvents PictureBox2 As PictureBox
End Class
