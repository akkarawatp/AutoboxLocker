<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CoinInTestDevice
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
        Me.lblHead = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Send = New System.Windows.Forms.Label()
        Me.btnCloseComport = New System.Windows.Forms.Button()
        Me.btnOpenComport = New System.Windows.Forms.Button()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblComport = New System.Windows.Forms.Label()
        Me.pnlConnection = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pnlCommand = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbb = New System.Windows.Forms.ComboBox()
        Me.txtReceive = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlConnection.SuspendLayout()
        Me.pnlCommand.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHead
        '
        Me.lblHead.BackColor = System.Drawing.Color.SteelBlue
        Me.lblHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.White
        Me.lblHead.Location = New System.Drawing.Point(0, 0)
        Me.lblHead.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(971, 38)
        Me.lblHead.TabIndex = 33
        Me.lblHead.Text = "Coin In"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.ForeColor = System.Drawing.Color.White
        Me.btnSend.Location = New System.Drawing.Point(490, 74)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(65, 27)
        Me.btnSend.TabIndex = 46
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 17)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Receive Command :"
        '
        'Send
        '
        Me.Send.AutoSize = True
        Me.Send.Location = New System.Drawing.Point(10, 79)
        Me.Send.Name = "Send"
        Me.Send.Size = New System.Drawing.Size(116, 17)
        Me.Send.TabIndex = 43
        Me.Send.Text = "Send Command :"
        '
        'btnCloseComport
        '
        Me.btnCloseComport.BackColor = System.Drawing.Color.Red
        Me.btnCloseComport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseComport.ForeColor = System.Drawing.Color.White
        Me.btnCloseComport.Location = New System.Drawing.Point(226, 107)
        Me.btnCloseComport.Name = "btnCloseComport"
        Me.btnCloseComport.Size = New System.Drawing.Size(128, 30)
        Me.btnCloseComport.TabIndex = 42
        Me.btnCloseComport.Text = "Close Comport"
        Me.btnCloseComport.UseVisualStyleBackColor = False
        '
        'btnOpenComport
        '
        Me.btnOpenComport.BackColor = System.Drawing.Color.Green
        Me.btnOpenComport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenComport.ForeColor = System.Drawing.Color.White
        Me.btnOpenComport.Location = New System.Drawing.Point(92, 107)
        Me.btnOpenComport.Name = "btnOpenComport"
        Me.btnOpenComport.Size = New System.Drawing.Size(128, 30)
        Me.btnOpenComport.TabIndex = 37
        Me.btnOpenComport.Text = "Open Comport"
        Me.btnOpenComport.UseVisualStyleBackColor = False
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(150, 76)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(334, 23)
        Me.txtSend.TabIndex = 36
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Com Port :"
        '
        'lblComport
        '
        Me.lblComport.BackColor = System.Drawing.Color.White
        Me.lblComport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblComport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblComport.ForeColor = System.Drawing.Color.Navy
        Me.lblComport.Location = New System.Drawing.Point(92, 43)
        Me.lblComport.Name = "lblComport"
        Me.lblComport.Size = New System.Drawing.Size(262, 23)
        Me.lblComport.TabIndex = 0
        Me.lblComport.Text = "COM 1"
        Me.lblComport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlConnection
        '
        Me.pnlConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConnection.Controls.Add(Me.Label1)
        Me.pnlConnection.Controls.Add(Me.lblStatus)
        Me.pnlConnection.Controls.Add(Me.lblComport)
        Me.pnlConnection.Controls.Add(Me.Label7)
        Me.pnlConnection.Controls.Add(Me.btnCloseComport)
        Me.pnlConnection.Controls.Add(Me.btnOpenComport)
        Me.pnlConnection.Location = New System.Drawing.Point(11, 52)
        Me.pnlConnection.Name = "pnlConnection"
        Me.pnlConnection.Size = New System.Drawing.Size(367, 153)
        Me.pnlConnection.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 32)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Connection"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.White
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Green
        Me.lblStatus.Location = New System.Drawing.Point(92, 76)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(262, 23)
        Me.lblStatus.TabIndex = 50
        Me.lblStatus.Text = "Status : Connected"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCommand
        '
        Me.pnlCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCommand.Controls.Add(Me.Label3)
        Me.pnlCommand.Controls.Add(Me.cbb)
        Me.pnlCommand.Controls.Add(Me.txtReceive)
        Me.pnlCommand.Controls.Add(Me.Label2)
        Me.pnlCommand.Controls.Add(Me.Label4)
        Me.pnlCommand.Controls.Add(Me.btnSend)
        Me.pnlCommand.Controls.Add(Me.Send)
        Me.pnlCommand.Controls.Add(Me.txtSend)
        Me.pnlCommand.Location = New System.Drawing.Point(393, 52)
        Me.pnlCommand.Name = "pnlCommand"
        Me.pnlCommand.Size = New System.Drawing.Size(567, 489)
        Me.pnlCommand.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 17)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "List Command :"
        '
        'cbb
        '
        Me.cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbb.FormattingEnabled = True
        Me.cbb.Location = New System.Drawing.Point(150, 43)
        Me.cbb.Name = "cbb"
        Me.cbb.Size = New System.Drawing.Size(167, 24)
        Me.cbb.TabIndex = 56
        '
        'txtReceive
        '
        Me.txtReceive.Location = New System.Drawing.Point(150, 107)
        Me.txtReceive.Multiline = True
        Me.txtReceive.Name = "txtReceive"
        Me.txtReceive.Size = New System.Drawing.Size(405, 369)
        Me.txtReceive.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.CadetBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(565, 32)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Command"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CoinInTestDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 551)
        Me.Controls.Add(Me.pnlCommand)
        Me.Controls.Add(Me.pnlConnection)
        Me.Controls.Add(Me.lblHead)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CoinInTestDevice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test Device"
        Me.pnlConnection.ResumeLayout(False)
        Me.pnlConnection.PerformLayout()
        Me.pnlCommand.ResumeLayout(False)
        Me.pnlCommand.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Send As System.Windows.Forms.Label
    Friend WithEvents btnCloseComport As System.Windows.Forms.Button
    Friend WithEvents btnOpenComport As System.Windows.Forms.Button
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblComport As System.Windows.Forms.Label
    Friend WithEvents pnlConnection As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pnlCommand As System.Windows.Forms.Panel
    Friend WithEvents txtReceive As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbb As System.Windows.Forms.ComboBox
End Class
