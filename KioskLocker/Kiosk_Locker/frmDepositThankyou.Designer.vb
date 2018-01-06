<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDepositThankyou
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
        Me.lblTimeOut = New System.Windows.Forms.Label()
        Me.btnCloseLocker = New System.Windows.Forms.Button()
        Me.TimerCheckCloseLocker = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblTimeOut
        '
        Me.lblTimeOut.AutoSize = True
        Me.lblTimeOut.Location = New System.Drawing.Point(534, 9)
        Me.lblTimeOut.Name = "lblTimeOut"
        Me.lblTimeOut.Size = New System.Drawing.Size(13, 13)
        Me.lblTimeOut.TabIndex = 40
        Me.lblTimeOut.Text = "0"
        Me.lblTimeOut.Visible = False
        '
        'btnCloseLocker
        '
        Me.btnCloseLocker.Location = New System.Drawing.Point(48, 245)
        Me.btnCloseLocker.Name = "btnCloseLocker"
        Me.btnCloseLocker.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseLocker.TabIndex = 95
        Me.btnCloseLocker.Text = "ปิดตู้"
        Me.btnCloseLocker.UseVisualStyleBackColor = True
        '
        'TimerCheckCloseLocker
        '
        Me.TimerCheckCloseLocker.Interval = 500
        '
        'frmDepositThankyou
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgDepositThankyou
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(768, 1024)
        Me.Controls.Add(Me.btnCloseLocker)
        Me.Controls.Add(Me.lblTimeOut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDepositThankyou"
        Me.Text = "ขอบคุณที่ใช้บริการ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTimeOut As Label
    Friend WithEvents btnCloseLocker As Button
    Friend WithEvents TimerCheckCloseLocker As Timer
End Class
