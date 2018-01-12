<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDepositPayment
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
        Me.tmPaymentTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.btn1000 = New System.Windows.Forms.Button()
        Me.btn500 = New System.Windows.Forms.Button()
        Me.btn100 = New System.Windows.Forms.Button()
        Me.btn50 = New System.Windows.Forms.Button()
        Me.btn20 = New System.Windows.Forms.Button()
        Me.btn10 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.lblLockerName = New System.Windows.Forms.Label()
        Me.lblPaidRemain = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tmPaymentTimeOut
        '
        Me.tmPaymentTimeOut.Interval = 1000
        '
        'btn1000
        '
        Me.btn1000.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn1000.Location = New System.Drawing.Point(6, 25)
        Me.btn1000.Name = "btn1000"
        Me.btn1000.Size = New System.Drawing.Size(75, 23)
        Me.btn1000.TabIndex = 68
        Me.btn1000.Text = "1000"
        Me.btn1000.UseVisualStyleBackColor = True
        Me.btn1000.Visible = False
        '
        'btn500
        '
        Me.btn500.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn500.Location = New System.Drawing.Point(87, 25)
        Me.btn500.Name = "btn500"
        Me.btn500.Size = New System.Drawing.Size(75, 23)
        Me.btn500.TabIndex = 69
        Me.btn500.Text = "500"
        Me.btn500.UseVisualStyleBackColor = True
        Me.btn500.Visible = False
        '
        'btn100
        '
        Me.btn100.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn100.Location = New System.Drawing.Point(168, 25)
        Me.btn100.Name = "btn100"
        Me.btn100.Size = New System.Drawing.Size(75, 23)
        Me.btn100.TabIndex = 70
        Me.btn100.Text = "100"
        Me.btn100.UseVisualStyleBackColor = True
        Me.btn100.Visible = False
        '
        'btn50
        '
        Me.btn50.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn50.Location = New System.Drawing.Point(249, 25)
        Me.btn50.Name = "btn50"
        Me.btn50.Size = New System.Drawing.Size(75, 23)
        Me.btn50.TabIndex = 71
        Me.btn50.Text = "50"
        Me.btn50.UseVisualStyleBackColor = True
        Me.btn50.Visible = False
        '
        'btn20
        '
        Me.btn20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn20.Location = New System.Drawing.Point(330, 25)
        Me.btn20.Name = "btn20"
        Me.btn20.Size = New System.Drawing.Size(75, 23)
        Me.btn20.TabIndex = 72
        Me.btn20.Text = "20"
        Me.btn20.UseVisualStyleBackColor = True
        Me.btn20.Visible = False
        '
        'btn10
        '
        Me.btn10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn10.Location = New System.Drawing.Point(411, 25)
        Me.btn10.Name = "btn10"
        Me.btn10.Size = New System.Drawing.Size(75, 23)
        Me.btn10.TabIndex = 73
        Me.btn10.Text = "10"
        Me.btn10.UseVisualStyleBackColor = True
        Me.btn10.Visible = False
        '
        'btn5
        '
        Me.btn5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn5.Location = New System.Drawing.Point(492, 25)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(75, 23)
        Me.btn5.TabIndex = 74
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        Me.btn5.Visible = False
        '
        'btn2
        '
        Me.btn2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn2.Location = New System.Drawing.Point(573, 25)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(75, 23)
        Me.btn2.TabIndex = 75
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        Me.btn2.Visible = False
        '
        'btn1
        '
        Me.btn1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn1.Location = New System.Drawing.Point(654, 25)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(75, 23)
        Me.btn1.TabIndex = 76
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        Me.btn1.Visible = False
        '
        'lblLockerName
        '
        Me.lblLockerName.BackColor = System.Drawing.Color.Transparent
        Me.lblLockerName.Font = New System.Drawing.Font("Thai Sans Lite", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLockerName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLockerName.Location = New System.Drawing.Point(537, 433)
        Me.lblLockerName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLockerName.Name = "lblLockerName"
        Me.lblLockerName.Size = New System.Drawing.Size(176, 87)
        Me.lblLockerName.TabIndex = 82
        Me.lblLockerName.Text = "M05"
        Me.lblLockerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPaidRemain
        '
        Me.lblPaidRemain.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPaidRemain.BackColor = System.Drawing.Color.Transparent
        Me.lblPaidRemain.Font = New System.Drawing.Font("Thai Sans Lite", 69.74999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaidRemain.ForeColor = System.Drawing.Color.Black
        Me.lblPaidRemain.Location = New System.Drawing.Point(478, 613)
        Me.lblPaidRemain.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPaidRemain.Name = "lblPaidRemain"
        Me.lblPaidRemain.Size = New System.Drawing.Size(222, 101)
        Me.lblPaidRemain.TabIndex = 92
        Me.lblPaidRemain.Text = "0000"
        Me.lblPaidRemain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("Thai Sans Lite", 30.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(689, 667)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 41)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "฿"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmDepositPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgDepositPayment
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(768, 1024)
        Me.Controls.Add(Me.lblLockerName)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn10)
        Me.Controls.Add(Me.btn20)
        Me.Controls.Add(Me.btn50)
        Me.Controls.Add(Me.btn100)
        Me.Controls.Add(Me.btn500)
        Me.Controls.Add(Me.btn1000)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPaidRemain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDepositPayment"
        Me.Text = "Payment"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents tmPaymentTimeOut As Timer
    Friend WithEvents btn1000 As Button
    Friend WithEvents btn500 As Button
    Friend WithEvents btn100 As Button
    Friend WithEvents btn50 As Button
    Friend WithEvents btn20 As Button
    Friend WithEvents btn10 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents lblLockerName As Label
    Friend WithEvents lblPaidRemain As Label
    Friend WithEvents Label1 As Label
End Class
