﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BanknoteInConnectDevice
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblHead = New System.Windows.Forms.Label()
        Me.lb = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.cbComport = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblHead
        '
        Me.lblHead.AccessibleName = ""
        Me.lblHead.BackColor = System.Drawing.Color.SteelBlue
        Me.lblHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.White
        Me.lblHead.Location = New System.Drawing.Point(2, 2)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(283, 30)
        Me.lblHead.TabIndex = 21
        Me.lblHead.Text = "Cash In"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb
        '
        Me.lb.AccessibleName = ""
        Me.lb.FormattingEnabled = True
        Me.lb.ItemHeight = 16
        Me.lb.Location = New System.Drawing.Point(78, 101)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(234, 52)
        Me.lb.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AccessibleName = ""
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "History :"
        '
        'txtStatus
        '
        Me.txtStatus.AccessibleName = ""
        Me.txtStatus.BackColor = System.Drawing.Color.Black
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtStatus.ForeColor = System.Drawing.Color.Red
        Me.txtStatus.Location = New System.Drawing.Point(78, 70)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(234, 23)
        Me.txtStatus.TabIndex = 33
        Me.txtStatus.Text = "Disconnected"
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AccessibleName = ""
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Status :"
        '
        'Label7
        '
        Me.Label7.AccessibleName = ""
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Com Port :"
        '
        'btnTest
        '
        Me.btnTest.AccessibleName = ""
        Me.btnTest.BackgroundImage = Global.BanknoteIn.My.Resources.Resources.Setting
        Me.btnTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTest.FlatAppearance.BorderSize = 0
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTest.Location = New System.Drawing.Point(286, 2)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(32, 31)
        Me.btnTest.TabIndex = 27
        Me.btnTest.UseVisualStyleBackColor = False
        '
        'cbComport
        '
        Me.cbComport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbComport.FormattingEnabled = True
        Me.cbComport.Location = New System.Drawing.Point(78, 40)
        Me.cbComport.Name = "cbComport"
        Me.cbComport.Size = New System.Drawing.Size(121, 24)
        Me.cbComport.TabIndex = 37
        '
        'CashInConnectDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.cbComport)
        Me.Controls.Add(Me.lb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.lblHead)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CashInConnectDevice"
        Me.Size = New System.Drawing.Size(320, 160)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents lb As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbComport As ComboBox
End Class
