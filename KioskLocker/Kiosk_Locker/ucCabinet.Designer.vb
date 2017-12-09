<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCabinet
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pbMoveRight = New System.Windows.Forms.PictureBox()
        Me.pbMoveLeft = New System.Windows.Forms.PictureBox()
        Me.pbDelete = New System.Windows.Forms.PictureBox()
        CType(Me.pbMoveRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMoveLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbMoveRight
        '
        Me.pbMoveRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pbMoveRight.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.iconButtonStepRight
        Me.pbMoveRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbMoveRight.Location = New System.Drawing.Point(71, 292)
        Me.pbMoveRight.Name = "pbMoveRight"
        Me.pbMoveRight.Size = New System.Drawing.Size(24, 24)
        Me.pbMoveRight.TabIndex = 7
        Me.pbMoveRight.TabStop = False
        '
        'pbMoveLeft
        '
        Me.pbMoveLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pbMoveLeft.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.iconButtonStepLeft
        Me.pbMoveLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbMoveLeft.Location = New System.Drawing.Point(1, 292)
        Me.pbMoveLeft.Name = "pbMoveLeft"
        Me.pbMoveLeft.Size = New System.Drawing.Size(24, 24)
        Me.pbMoveLeft.TabIndex = 6
        Me.pbMoveLeft.TabStop = False
        '
        'pbDelete
        '
        Me.pbDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pbDelete.BackgroundImage = Global.MiniboxLocker.My.Resources.Resources.icon_cabinet_delete
        Me.pbDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDelete.Location = New System.Drawing.Point(36, 292)
        Me.pbDelete.Name = "pbDelete"
        Me.pbDelete.Size = New System.Drawing.Size(24, 24)
        Me.pbDelete.TabIndex = 5
        Me.pbDelete.TabStop = False
        '
        'ucCabinet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pbMoveRight)
        Me.Controls.Add(Me.pbMoveLeft)
        Me.Controls.Add(Me.pbDelete)
        Me.Name = "ucCabinet"
        Me.Size = New System.Drawing.Size(97, 318)
        CType(Me.pbMoveRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMoveLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbDelete As PictureBox
    Friend WithEvents pbMoveLeft As PictureBox
    Friend WithEvents pbMoveRight As PictureBox
End Class
