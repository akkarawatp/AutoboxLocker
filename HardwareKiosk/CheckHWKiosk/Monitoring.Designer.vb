<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Monitoring
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
        Me.TestSensor1 = New BoardSensor.TestSensor()
        Me.BarcodeScannerConnectDavice1 = New QRCodeScanner.BarcodeScannerConnectDavice()
        Me.PrinterConnectDevice1 = New Printer.PrinterConnectDevice()
        Me.CoinOutConnectDevice1 = New CoinOut.CoinOutConnectDevice()
        Me.CashOutConnectDevice2 = New BanknoteOut.CashOutConnectDevice()
        Me.CashOutConnectDevice1 = New BanknoteOut.CashOutConnectDevice()
        Me.CoinInConnectDevice1 = New CoinIn.CoinInConnectDevice()
        Me.CashInConnectDevice1 = New BanknoteIn.BanknoteInConnectDevice()
        Me.TestLED1 = New BoardLED.TestLED()
        Me.TestSolenoid1 = New BoardSolenoid.TestSolenoid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbCaptureImage = New System.Windows.Forms.PictureBox()
        Me.cbCamera = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.TimerCheckCamera = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.pbCaptureImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TestSensor1
        '
        Me.TestSensor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TestSensor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TestSensor1.Location = New System.Drawing.Point(3, 376)
        Me.TestSensor1.Margin = New System.Windows.Forms.Padding(4)
        Me.TestSensor1.Name = "TestSensor1"
        Me.TestSensor1.Size = New System.Drawing.Size(320, 157)
        Me.TestSensor1.TabIndex = 8
        '
        'BarcodeScannerConnectDavice1
        '
        Me.BarcodeScannerConnectDavice1.BackColor = System.Drawing.Color.White
        Me.BarcodeScannerConnectDavice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BarcodeScannerConnectDavice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BarcodeScannerConnectDavice1.Location = New System.Drawing.Point(648, 166)
        Me.BarcodeScannerConnectDavice1.Margin = New System.Windows.Forms.Padding(4)
        Me.BarcodeScannerConnectDavice1.Name = "BarcodeScannerConnectDavice1"
        Me.BarcodeScannerConnectDavice1.Size = New System.Drawing.Size(320, 96)
        Me.BarcodeScannerConnectDavice1.TabIndex = 6
        '
        'PrinterConnectDevice1
        '
        Me.PrinterConnectDevice1.BackColor = System.Drawing.Color.White
        Me.PrinterConnectDevice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrinterConnectDevice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.PrinterConnectDevice1.Location = New System.Drawing.Point(648, 266)
        Me.PrinterConnectDevice1.Margin = New System.Windows.Forms.Padding(4)
        Me.PrinterConnectDevice1.Name = "PrinterConnectDevice1"
        Me.PrinterConnectDevice1.Size = New System.Drawing.Size(320, 99)
        Me.PrinterConnectDevice1.TabIndex = 5
        '
        'CoinOutConnectDevice1
        '
        Me.CoinOutConnectDevice1.BackColor = System.Drawing.Color.White
        Me.CoinOutConnectDevice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CoinOutConnectDevice1.CoinID = 5
        Me.CoinOutConnectDevice1.CoinValue = 5
        Me.CoinOutConnectDevice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CoinOutConnectDevice1.Location = New System.Drawing.Point(325, 166)
        Me.CoinOutConnectDevice1.Margin = New System.Windows.Forms.Padding(4)
        Me.CoinOutConnectDevice1.Name = "CoinOutConnectDevice1"
        Me.CoinOutConnectDevice1.Size = New System.Drawing.Size(320, 99)
        Me.CoinOutConnectDevice1.TabIndex = 4
        '
        'CashOutConnectDevice2
        '
        Me.CashOutConnectDevice2.BackColor = System.Drawing.Color.White
        Me.CashOutConnectDevice2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CashOutConnectDevice2.CashID = 3
        Me.CashOutConnectDevice2.CashValue = 100
        Me.CashOutConnectDevice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CashOutConnectDevice2.Location = New System.Drawing.Point(3, 269)
        Me.CashOutConnectDevice2.Margin = New System.Windows.Forms.Padding(4)
        Me.CashOutConnectDevice2.Name = "CashOutConnectDevice2"
        Me.CashOutConnectDevice2.Size = New System.Drawing.Size(320, 99)
        Me.CashOutConnectDevice2.TabIndex = 3
        '
        'CashOutConnectDevice1
        '
        Me.CashOutConnectDevice1.BackColor = System.Drawing.Color.White
        Me.CashOutConnectDevice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CashOutConnectDevice1.CashID = 18
        Me.CashOutConnectDevice1.CashValue = 20
        Me.CashOutConnectDevice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CashOutConnectDevice1.Location = New System.Drawing.Point(3, 166)
        Me.CashOutConnectDevice1.Margin = New System.Windows.Forms.Padding(4)
        Me.CashOutConnectDevice1.Name = "CashOutConnectDevice1"
        Me.CashOutConnectDevice1.Size = New System.Drawing.Size(320, 99)
        Me.CashOutConnectDevice1.TabIndex = 2
        '
        'CoinInConnectDevice1
        '
        Me.CoinInConnectDevice1.BackColor = System.Drawing.Color.White
        Me.CoinInConnectDevice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CoinInConnectDevice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CoinInConnectDevice1.Location = New System.Drawing.Point(325, 3)
        Me.CoinInConnectDevice1.Margin = New System.Windows.Forms.Padding(4)
        Me.CoinInConnectDevice1.Name = "CoinInConnectDevice1"
        Me.CoinInConnectDevice1.Size = New System.Drawing.Size(320, 160)
        Me.CoinInConnectDevice1.TabIndex = 1
        '
        'CashInConnectDevice1
        '
        Me.CashInConnectDevice1.BackColor = System.Drawing.Color.White
        Me.CashInConnectDevice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CashInConnectDevice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CashInConnectDevice1.Location = New System.Drawing.Point(3, 3)
        Me.CashInConnectDevice1.Margin = New System.Windows.Forms.Padding(4)
        Me.CashInConnectDevice1.Name = "CashInConnectDevice1"
        Me.CashInConnectDevice1.Size = New System.Drawing.Size(320, 160)
        Me.CashInConnectDevice1.TabIndex = 0
        '
        'TestLED1
        '
        Me.TestLED1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TestLED1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TestLED1.Location = New System.Drawing.Point(325, 376)
        Me.TestLED1.Margin = New System.Windows.Forms.Padding(4)
        Me.TestLED1.Name = "TestLED1"
        Me.TestLED1.Size = New System.Drawing.Size(320, 157)
        Me.TestLED1.TabIndex = 9
        '
        'TestSolenoid1
        '
        Me.TestSolenoid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TestSolenoid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TestSolenoid1.Location = New System.Drawing.Point(648, 376)
        Me.TestSolenoid1.Margin = New System.Windows.Forms.Padding(4)
        Me.TestSolenoid1.Name = "TestSolenoid1"
        Me.TestSolenoid1.Size = New System.Drawing.Size(320, 157)
        Me.TestSolenoid1.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pbCaptureImage)
        Me.Panel1.Controls.Add(Me.cbCamera)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btnTest)
        Me.Panel1.Controls.Add(Me.lblHead)
        Me.Panel1.Location = New System.Drawing.Point(648, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 160)
        Me.Panel1.TabIndex = 11
        '
        'pbCaptureImage
        '
        Me.pbCaptureImage.Location = New System.Drawing.Point(87, 64)
        Me.pbCaptureImage.Name = "pbCaptureImage"
        Me.pbCaptureImage.Size = New System.Drawing.Size(159, 90)
        Me.pbCaptureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCaptureImage.TabIndex = 33
        Me.pbCaptureImage.TabStop = False
        '
        'cbCamera
        '
        Me.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCamera.FormattingEnabled = True
        Me.cbCamera.Location = New System.Drawing.Point(87, 37)
        Me.cbCamera.Name = "cbCamera"
        Me.cbCamera.Size = New System.Drawing.Size(159, 21)
        Me.cbCamera.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Camera :"
        '
        'btnTest
        '
        Me.btnTest.BackgroundImage = Global.CheckHardware.My.Resources.Resources.buttonPlay
        Me.btnTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTest.FlatAppearance.BorderSize = 0
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTest.Location = New System.Drawing.Point(286, 4)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(32, 32)
        Me.btnTest.TabIndex = 29
        Me.btnTest.UseVisualStyleBackColor = False
        '
        'lblHead
        '
        Me.lblHead.BackColor = System.Drawing.Color.SteelBlue
        Me.lblHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.White
        Me.lblHead.Location = New System.Drawing.Point(2, 4)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(283, 30)
        Me.lblHead.TabIndex = 28
        Me.lblHead.Text = "Camera"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerCheckCamera
        '
        '
        'Monitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 733)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TestSolenoid1)
        Me.Controls.Add(Me.TestLED1)
        Me.Controls.Add(Me.TestSensor1)
        Me.Controls.Add(Me.BarcodeScannerConnectDavice1)
        Me.Controls.Add(Me.PrinterConnectDevice1)
        Me.Controls.Add(Me.CoinOutConnectDevice1)
        Me.Controls.Add(Me.CashOutConnectDevice2)
        Me.Controls.Add(Me.CashOutConnectDevice1)
        Me.Controls.Add(Me.CoinInConnectDevice1)
        Me.Controls.Add(Me.CashInConnectDevice1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Name = "Monitoring"
        Me.Text = "Monitoring"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbCaptureImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CashInConnectDevice1 As BanknoteIn.BanknoteInConnectDevice
    Friend WithEvents CoinInConnectDevice1 As CoinIn.CoinInConnectDevice
    Friend WithEvents CashOutConnectDevice1 As BanknoteOut.CashOutConnectDevice
    Friend WithEvents CashOutConnectDevice2 As BanknoteOut.CashOutConnectDevice
    Friend WithEvents CoinOutConnectDevice1 As CoinOut.CoinOutConnectDevice
    Friend WithEvents PrinterConnectDevice1 As Printer.PrinterConnectDevice
    Friend WithEvents BarcodeScannerConnectDavice1 As QRCodeScanner.BarcodeScannerConnectDavice
    Friend WithEvents TestSensor1 As BoardSensor.TestSensor
    Friend WithEvents TestLED1 As BoardLED.TestLED
    Friend WithEvents TestSolenoid1 As BoardSolenoid.TestSolenoid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnTest As Button
    Friend WithEvents lblHead As Label
    Friend WithEvents cbCamera As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents pbCaptureImage As PictureBox
    Friend WithEvents TimerCheckCamera As Timer
End Class
