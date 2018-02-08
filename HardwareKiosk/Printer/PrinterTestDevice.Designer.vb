<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PrinterTestDevice
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
        Me.lblHead = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.sp = New System.IO.Ports.SerialPort(Me.components)
        Me.lblPrinterName = New System.Windows.Forms.Label()
        Me.pnlConnection = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnPrintWithPrinterClass = New System.Windows.Forms.Button()
        Me.pnlConnection.SuspendLayout()
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
        Me.lblHead.Size = New System.Drawing.Size(388, 38)
        Me.lblHead.TabIndex = 33
        Me.lblHead.Text = "Printer"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(11, 171)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(367, 27)
        Me.btnPrint.TabIndex = 46
        Me.btnPrint.Text = "Print Test"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 17)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Printer :"
        '
        'lblPrinterName
        '
        Me.lblPrinterName.BackColor = System.Drawing.Color.White
        Me.lblPrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPrinterName.ForeColor = System.Drawing.Color.Navy
        Me.lblPrinterName.Location = New System.Drawing.Point(75, 43)
        Me.lblPrinterName.Name = "lblPrinterName"
        Me.lblPrinterName.Size = New System.Drawing.Size(279, 23)
        Me.lblPrinterName.TabIndex = 0
        Me.lblPrinterName.Text = "COM 1"
        Me.lblPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlConnection
        '
        Me.pnlConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConnection.Controls.Add(Me.Label1)
        Me.pnlConnection.Controls.Add(Me.lblStatus)
        Me.pnlConnection.Controls.Add(Me.lblPrinterName)
        Me.pnlConnection.Controls.Add(Me.Label7)
        Me.pnlConnection.Location = New System.Drawing.Point(11, 52)
        Me.pnlConnection.Name = "pnlConnection"
        Me.pnlConnection.Size = New System.Drawing.Size(367, 113)
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
        Me.lblStatus.Location = New System.Drawing.Point(75, 76)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(279, 23)
        Me.lblStatus.TabIndex = 50
        Me.lblStatus.Text = "Status : Online"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPrintWithPrinterClass
        '
        Me.btnPrintWithPrinterClass.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnPrintWithPrinterClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintWithPrinterClass.ForeColor = System.Drawing.Color.White
        Me.btnPrintWithPrinterClass.Location = New System.Drawing.Point(12, 204)
        Me.btnPrintWithPrinterClass.Name = "btnPrintWithPrinterClass"
        Me.btnPrintWithPrinterClass.Size = New System.Drawing.Size(364, 27)
        Me.btnPrintWithPrinterClass.TabIndex = 52
        Me.btnPrintWithPrinterClass.Text = "Print With Printer Class"
        Me.btnPrintWithPrinterClass.UseVisualStyleBackColor = False
        '
        'PrinterTestDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 249)
        Me.Controls.Add(Me.btnPrintWithPrinterClass)
        Me.Controls.Add(Me.pnlConnection)
        Me.Controls.Add(Me.lblHead)
        Me.Controls.Add(Me.btnPrint)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PrinterTestDevice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test Device"
        Me.pnlConnection.ResumeLayout(False)
        Me.pnlConnection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents sp As System.IO.Ports.SerialPort
    Friend WithEvents lblPrinterName As System.Windows.Forms.Label
    Friend WithEvents pnlConnection As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnPrintWithPrinterClass As Button
End Class
