<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCollectThankyou
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
        Me.TimerCheckCloseLocker = New System.Windows.Forms.Timer(Me.components)
        Me.btnCloseLocker = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TimerCheckCloseLocker
        '
        Me.TimerCheckCloseLocker.Interval = 500
        '
        'btnCloseLocker
        '
        Me.btnCloseLocker.Location = New System.Drawing.Point(55, 373)
        Me.btnCloseLocker.Name = "btnCloseLocker"
        Me.btnCloseLocker.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseLocker.TabIndex = 99
        Me.btnCloseLocker.Text = "ปิดตู้"
        Me.btnCloseLocker.UseVisualStyleBackColor = True
        Me.btnCloseLocker.Visible = False
        '
        'frmCollectThankyou
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.bgCollectThankyou
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(768, 780)
        Me.Controls.Add(Me.btnCloseLocker)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCollectThankyou"
        Me.Text = "ขอบคุณที่ใช้บริการ"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents TimerCheckCloseLocker As Timer
    Friend WithEvents btnCloseLocker As Button
End Class
