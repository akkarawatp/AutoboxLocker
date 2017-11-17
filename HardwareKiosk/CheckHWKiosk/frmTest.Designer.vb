<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtCPU_ID = New System.Windows.Forms.TextBox()
        Me.txtProcessorID = New System.Windows.Forms.TextBox()
        Me.txtMainBoardID = New System.Windows.Forms.TextBox()
        Me.lblCPUID = New System.Windows.Forms.Label()
        Me.lblProcessorID = New System.Windows.Forms.Label()
        Me.lblMainBoardID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProcessorName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(103, 154)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtCPU_ID
        '
        Me.txtCPU_ID.Location = New System.Drawing.Point(103, 39)
        Me.txtCPU_ID.Name = "txtCPU_ID"
        Me.txtCPU_ID.Size = New System.Drawing.Size(379, 20)
        Me.txtCPU_ID.TabIndex = 1
        '
        'txtProcessorID
        '
        Me.txtProcessorID.Location = New System.Drawing.Point(103, 65)
        Me.txtProcessorID.Name = "txtProcessorID"
        Me.txtProcessorID.Size = New System.Drawing.Size(379, 20)
        Me.txtProcessorID.TabIndex = 2
        '
        'txtMainBoardID
        '
        Me.txtMainBoardID.Location = New System.Drawing.Point(103, 116)
        Me.txtMainBoardID.Name = "txtMainBoardID"
        Me.txtMainBoardID.Size = New System.Drawing.Size(379, 20)
        Me.txtMainBoardID.TabIndex = 3
        '
        'lblCPUID
        '
        Me.lblCPUID.AutoSize = True
        Me.lblCPUID.Location = New System.Drawing.Point(12, 42)
        Me.lblCPUID.Name = "lblCPUID"
        Me.lblCPUID.Size = New System.Drawing.Size(43, 13)
        Me.lblCPUID.TabIndex = 4
        Me.lblCPUID.Text = "CPU ID"
        '
        'lblProcessorID
        '
        Me.lblProcessorID.AutoSize = True
        Me.lblProcessorID.Location = New System.Drawing.Point(12, 68)
        Me.lblProcessorID.Name = "lblProcessorID"
        Me.lblProcessorID.Size = New System.Drawing.Size(68, 13)
        Me.lblProcessorID.TabIndex = 5
        Me.lblProcessorID.Text = "Processor ID"
        '
        'lblMainBoardID
        '
        Me.lblMainBoardID.AutoSize = True
        Me.lblMainBoardID.Location = New System.Drawing.Point(12, 119)
        Me.lblMainBoardID.Name = "lblMainBoardID"
        Me.lblMainBoardID.Size = New System.Drawing.Size(71, 13)
        Me.lblMainBoardID.TabIndex = 6
        Me.lblMainBoardID.Text = "Mainboard ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Processor Name"
        '
        'txtProcessorName
        '
        Me.txtProcessorName.Location = New System.Drawing.Point(103, 91)
        Me.txtProcessorName.Name = "txtProcessorName"
        Me.txtProcessorName.Size = New System.Drawing.Size(379, 20)
        Me.txtProcessorName.TabIndex = 7
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 261)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProcessorName)
        Me.Controls.Add(Me.lblMainBoardID)
        Me.Controls.Add(Me.lblProcessorID)
        Me.Controls.Add(Me.lblCPUID)
        Me.Controls.Add(Me.txtMainBoardID)
        Me.Controls.Add(Me.txtProcessorID)
        Me.Controls.Add(Me.txtCPU_ID)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmTest"
        Me.Text = "frmTest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtCPU_ID As TextBox
    Friend WithEvents txtProcessorID As TextBox
    Friend WithEvents txtMainBoardID As TextBox
    Friend WithEvents lblCPUID As Label
    Friend WithEvents lblProcessorID As Label
    Friend WithEvents lblMainBoardID As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProcessorName As TextBox
End Class
