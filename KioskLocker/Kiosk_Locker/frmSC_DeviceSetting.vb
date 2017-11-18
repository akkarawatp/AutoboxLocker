Imports System.Drawing.Printing
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Imports AutoboxLocker.Data
Imports System.Data.SqlClient
Imports AutoboxLocker.Data.KioskConfigData

Public Class frmSC_DeviceSetting
    Private Sub frmSC_KioskSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleDeviceSetting
        Me.ControlBox = False
        'frmMain.lblSCHeader.Visible = False
    End Sub

    Private Sub frmSC_KioskSetting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleDeviceSetting_OpenForm, "", False)
        CheckForIllegalCrossThreadCalls = False
        BindDDLComport()
        BindDDLPrinter()
        BindDDLWebCamera()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleDeviceSetting_SetDefaultSetting, "", False)
        SetDefaultSetting()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleDeviceSetting_CheckAuthorize, "", False)
        SetStaffConsoleAuthorize()
    End Sub

    Private Sub SetStaffConsoleAuthorize()
        If StaffConsole.AuthorizeInfo.Rows.Count > 0 Then
            AppScreenList.DefaultView.RowFilter = "id='" & Convert.ToInt16(KioskConfig.SelectForm) & "'"
            If AppScreenList.DefaultView.Count > 0 Then
                cbBanknoteIn.Enabled = False
                cbBanknoteOut20.Enabled = False
                cbBanknoteOut100.Enabled = False
                cbCoinIn.Enabled = False
                cbCoinOut5.Enabled = False
                cbBoardSolenoid.Enabled = False
                cbBoardSensor.Enabled = False
                cbBoardLED.Enabled = False
                txtQRCodeVID.Enabled = False
                cbPrinterName.Enabled = False
                cbWebCamera.Enabled = False
                btnSave.Visible = False

                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=19 and authorization_name='Edit'"
                If StaffConsole.AuthorizeInfo.DefaultView.Count > 0 Then
                    cbBanknoteIn.Enabled = True
                    cbBanknoteOut20.Enabled = True
                    cbBanknoteOut100.Enabled = True
                    cbCoinIn.Enabled = True
                    cbCoinOut5.Enabled = True
                    cbBoardSolenoid.Enabled = True
                    cbBoardSensor.Enabled = True
                    cbBoardLED.Enabled = True
                    txtQRCodeVID.Enabled = True
                    cbPrinterName.Enabled = True
                    cbWebCamera.Enabled = True
                    btnSave.Visible = True
                End If
                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""
            End If
            AppScreenList.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub SetDefaultSetting()
        Try
            'กำหนดค่า Hardware Config COMPORT ต้องดึงข้อมูลใหม่ทุกครั้ง เนื่องจากหน้า Setting อาจจะมีการเปลี่ยนแปลงข้อมูล
            Dim sql As String = "select device_id, type_active_status, device_active_status, comport_vid, driver_name1, driver_name2 "
            sql += " from v_kiosk_device_info "
            sql += " where ms_kiosk_id=@_KIOSK_ID"
            Dim p(1) As SqlParameter
            p(0) = KioskDB.SetBigInt("@_KIOSK_ID", Convert.ToInt16(KioskData.KioskID))

            Dim dDt As DataTable = KioskDB.ExecuteTable(sql, p)
            If dDt.Rows.Count > 0 Then
                For i As Integer = 0 To dDt.Rows.Count - 1
                    Dim dDr As DataRow = dDt.Rows(i)
                    If dDr("type_active_status") = "Y" AndAlso dDr("device_active_status") = "Y" Then
                        Select Case Convert.ToInt16(dDr("device_id"))
                            Case DeviceID.BankNoteIn
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    cbBanknoteIn.SelectedIndex = cbBanknoteIn.FindStringExact(dDr("comport_vid"))
                                End If
                            Case DeviceID.BankNoteOut_20
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    cbBanknoteOut20.SelectedIndex = cbBanknoteOut20.FindStringExact(dDr("comport_vid"))
                                End If

                            Case DeviceID.BankNoteOut_50
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then

                                End If

                            Case DeviceID.BankNoteOut_100
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    cbBanknoteOut100.SelectedIndex = cbBanknoteOut100.FindStringExact(dDr("comport_vid"))
                                End If

                            Case DeviceID.BankNoteOut_500
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then

                                End If

                            Case DeviceID.CoinIn
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    cbCoinIn.SelectedIndex = cbCoinIn.FindStringExact(dDr("comport_vid"))
                                End If

                            Case DeviceID.CoinOut_1
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then

                                End If

                            Case DeviceID.CoinOut_2
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then

                                End If

                            Case DeviceID.CoinOut_5
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    cbCoinOut5.SelectedIndex = cbCoinOut5.FindStringExact(dDr("comport_vid"))
                                End If

                            Case DeviceID.CoinOut_10
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then

                                End If

                            Case DeviceID.Printer
                                If Convert.IsDBNull(dDr("driver_name1")) = False Then
                                    cbPrinterName.SelectedIndex = cbPrinterName.FindStringExact(dDr("driver_name1"))
                                End If

                            Case DeviceID.WebCamera
                                If Convert.IsDBNull(dDr("driver_name1")) = False Then
                                    cbWebCamera.SelectedIndex = cbWebCamera.FindStringExact(dDr("driver_name1"))
                                End If

                            Case DeviceID.NetworkConnection

                            Case DeviceID.QRCodeReader
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    txtQRCodeVID.Text = dDr("comport_vid")
                                End If

                            Case DeviceID.SolenoidBoard
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    cbBoardSolenoid.SelectedIndex = cbBoardSolenoid.FindStringExact(dDr("comport_vid"))
                                End If

                            Case DeviceID.LEDBoard
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    cbBoardLED.SelectedIndex = cbBoardLED.FindStringExact(dDr("comport_vid"))
                                End If

                            Case DeviceID.SensorBoard
                                If Convert.IsDBNull(dDr("comport_vid")) = False Then
                                    cbBoardSensor.SelectedIndex = cbBoardSensor.FindStringExact(dDr("comport_vid"))
                                End If
                        End Select
                    End If
                Next
            Else
                InsertErrorLogSC(StaffConsole.Username, "Cannot get Kiosk config information", StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                ShowDialogErrorMessageSC("Cannot get Kiosk setting information")
            End If
            dDt.Dispose()
        Catch ex As Exception
            InsertErrorLogSC(StaffConsole.Username, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            ShowDialogErrorMessageSC("Cannot get Kiosk setting information")
        End Try
    End Sub

    Private Sub BindDDLComport()
        cbBanknoteIn.Items.Clear()
        cbBanknoteIn.Items.Add("")

        cbBanknoteOut20.Items.Clear()
        cbBanknoteOut20.Items.Add("")

        cbBanknoteOut100.Items.Clear()
        cbBanknoteOut100.Items.Add("")

        cbCoinIn.Items.Clear()
        cbCoinIn.Items.Add("")

        cbCoinOut5.Items.Clear()
        cbCoinOut5.Items.Add("")

        cbBoardSolenoid.Items.Clear()
        cbBoardSolenoid.Items.Add("")

        cbBoardSensor.Items.Clear()
        cbBoardSensor.Items.Add("")

        cbBoardLED.Items.Clear()
        cbBoardLED.Items.Add("")

        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbBanknoteIn.Items.Add(sp)
            cbBanknoteOut20.Items.Add(sp)
            cbBanknoteOut100.Items.Add(sp)
            cbCoinIn.Items.Add(sp)
            cbCoinOut5.Items.Add(sp)
            cbBoardSolenoid.Items.Add(sp)
            cbBoardSensor.Items.Add(sp)
            cbBoardLED.Items.Add(sp)
        Next
    End Sub


    Private Sub BindDDLPrinter()
        Dim pkInstalledPrinters As String = ""
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            cbPrinterName.Items.Add(pkInstalledPrinters)
        Next
    End Sub

    Private Sub BindDDLWebCamera()
        cbWebCamera.Items.AddRange(WebCam.GetCaptureDevices)
    End Sub

    Private Sub lblCancel_Click(sender As Object, e As EventArgs) Handles lblCancel.Click, btnCancel.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleDeviceSetting_ClickCancel, "", False)
        frmMain.CloseAllChildForm()
        Dim f As New frmSC_StockAndHardware
        f.ShowDialog(frmMain)
    End Sub

    Private Function UpdateDeviceByDeviceID(vDeviceID As ConstantsData.DeviceID, ComportVID As String, DriverName1 As String, DriverName2 As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New MsKioskDeviceKioskLinqDB
            lnq.ChkDataByMS_DEVICE_ID_MS_KIOSK_ID(vDeviceID, KioskData.KioskID, Nothing)
            If lnq.ID > 0 Then
                lnq.COMPORT_VID = ComportVID
                lnq.DRIVER_NAME1 = DriverName1
                lnq.DRIVER_NAME2 = DriverName2
                lnq.SYNC_TO_KIOSK = "Y"
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB
                Dim re As ExecuteDataInfo = lnq.UpdateData(StaffConsole.Username, trans.Trans)
                If re.IsSuccess = True Then
                    trans.CommitTransaction()
                    ret = True
                Else
                    trans.RollbackTransaction()

                    Dim _err As String = re.ErrorMessage
                    _err += "&vDeviceID=" & vDeviceID
                    _err += "&ComportVID=" & ComportVID
                    _err += "&DriverName1=" & DriverName1
                    _err += "&DriverName2=" & DriverName2
                    InsertErrorLogSC(StaffConsole.Username, _err, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            Dim _err As String = "Exception : " & ex.Message & vbNewLine & ex.StackTrace
            _err += "&vDeviceID=" & vDeviceID
            _err += "&ComportVID=" & ComportVID
            _err += "&DriverName1=" & DriverName1
            _err += "&DriverName2=" & DriverName2
            InsertErrorLogSC(StaffConsole.Username, _err, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
        End Try

        Return ret
    End Function

    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles lblSave.Click, btnSave.Click
        'If cbBanknoteIn.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกเครื่องรับธนบัตร")
        '    Exit Sub
        'End If

        'If cbBanknoteOut20.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกเครื่องทอนธนบัตร 20 บาท")
        '    Exit Sub
        'End If

        'If cbBanknoteOut100.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกเครื่องทอนธนบัตร 100 บาท")
        '    Exit Sub
        'End If

        'If cbCoinIn.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกเครื่องรับเหรียญ")
        '    Exit Sub
        'End If

        'If cbCoinOut5.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกเครื่องทอนเหรียญ 5 บาท")
        '    Exit Sub
        'End If

        'If cbBoardSolenoid.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกแผงควบคุม Solenoid")
        '    Exit Sub
        'End If

        'If cbBoardSensor.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกแผงควบคุม Sensor")
        '    Exit Sub
        'End If

        'If cbBoardLED.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกแผงควบคุม LED")
        '    Exit Sub
        'End If

        'If txtQRCodeVID.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาระบุ VID ของเครื่องอ่าน QR Code")
        '    Exit Sub
        'End If

        'If cbPrinterName.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาเลือกเครื่องพิมพ์ Slip")
        '    Exit Sub
        'End If

        'If txtIDCardPassportVID.Text.Trim = "" Then
        '    ShowDialogErrorMessageSC("กรุณาระบุ VID ของเครื่องอ่านบัตรประชาชนและหนังสือเดินทาง")
        '    Exit Sub
        'End If

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleDeviceSetting_ClickSave, "", False)

        UpdateDeviceByDeviceID(DeviceID.BankNoteIn, cbBanknoteIn.Text, "", "")
        UpdateDeviceByDeviceID(DeviceID.BankNoteOut_20, cbBanknoteOut20.Text, "", "")
        UpdateDeviceByDeviceID(DeviceID.BankNoteOut_100, cbBanknoteOut100.Text, "", "")
        UpdateDeviceByDeviceID(DeviceID.CoinIn, cbCoinIn.Text, "", "")
        UpdateDeviceByDeviceID(DeviceID.CoinOut_5, cbCoinOut5.Text, "", "")

        UpdateDeviceByDeviceID(DeviceID.SolenoidBoard, cbBoardSolenoid.Text, "", "")
        UpdateDeviceByDeviceID(DeviceID.SensorBoard, cbBoardSensor.Text, "", "")
        UpdateDeviceByDeviceID(DeviceID.LEDBoard, cbBoardLED.Text, "", "")

        UpdateDeviceByDeviceID(DeviceID.QRCodeReader, txtQRCodeVID.Text, "", "")
        UpdateDeviceByDeviceID(DeviceID.Printer, "", cbPrinterName.Text, "")
        UpdateDeviceByDeviceID(DeviceID.WebCamera, "", cbWebCamera.Text, cbWebCamera.SelectedIndex)

        SetListDeviceInfo()  'โหลดข้อมูลใหม่เก็บเข้าตัวแปร

        ShowDialogErrorMessageSC("Save Success")

        'ตรวจสอบและส่ง Alarm เมื่อเครื่องเชื่อมอินเตอร์เน็ตได้
        UpdateAllDeviceStatusByComPort()
        UpdateAllDeviceStatusByUsbPort()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, 0, "", False)

        frmMain.CloseAllChildForm()
        Me.Close()
        Dim f As New frmSC_StockAndHardware
        f.ShowDialog()

    End Sub
End Class