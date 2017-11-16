<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScreenServer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScreenServer))
        Me.VDO = New AxWMPLib.AxWindowsMediaPlayer()
        Me.TimerSync = New System.Windows.Forms.Timer(Me.components)
        CType(Me.VDO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VDO
        '
        Me.VDO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VDO.Enabled = True
        Me.VDO.Location = New System.Drawing.Point(0, 0)
        Me.VDO.Name = "VDO"
        Me.VDO.OcxState = CType(resources.GetObject("VDO.OcxState"), System.Windows.Forms.AxHost.State)
        Me.VDO.Size = New System.Drawing.Size(677, 369)
        Me.VDO.TabIndex = 0
        '
        'frmScreenServer
        '
        Me.ClientSize = New System.Drawing.Size(677, 369)
        Me.Controls.Add(Me.VDO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmScreenServer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.VDO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VDO As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents TimerSync As Timer
End Class
