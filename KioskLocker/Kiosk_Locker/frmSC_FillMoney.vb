Imports AutoboxLocker.Data.KioskConfigData
Imports AutoboxLocker.ServiceTransactionData
Imports System.Data.SqlClient
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Public Class frmSC_FillMoney

    Dim _FillMoneyID As Long = 0


    Private Sub frmSC_FillPaper_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        KioskConfig.SelectForm = Data.KioskConfigData.KioskLockerForm.StaffConsoleFillMoney
    End Sub

    Private Function InsertFillMoney(TotalMoneyRemain As Double) As Boolean
        Dim ret As Boolean = False

        Dim CoinInMoney As Double = Convert.ToDouble(Replace(txtCoinInMoney.Text, ",", ""))
        Dim BanknoteInMoney As Double = Convert.ToDouble(Replace(txtBanknoteInMoney.Text, ",", ""))
        Dim Change5Remain As Integer = Convert.ToInt16(Replace(txtCoinOut5.Text, ",", ""))
        Dim Change20Remain As Integer = Convert.ToInt16(Replace(txtBanknoteOut20.Text, ",", ""))
        Dim Change100Remain As Integer = Convert.ToInt16(Replace(txtBanknoteOut100.Text, ",", ""))


        Try
            Dim lnq As New TbFillMoneyKioskLinqDB
            lnq.MS_KIOSK_ID = KioskData.KioskID
            lnq.COIN_MONEY = CoinInMoney
            lnq.BANKNOTE_MONEY = BanknoteInMoney
            lnq.CHANGE1_REMAIN = 0
            lnq.CHANGE2_REMAIN = 0
            lnq.CHANGE5_REMAIN = Change5Remain
            lnq.CHANGE10_REMAIN = 0
            lnq.CHANGE20_REMAIN = Change20Remain
            lnq.CHANGE50_REMAIN = 0
            lnq.CHANGE100_REMAIN = Change100Remain
            lnq.CHANGE500_REMAIN = 0
            lnq.TOTAL_MONEY_REMAIN = TotalMoneyRemain
            lnq.IS_CONFIRM = "Z"  'ยังไม่มีการกดปุ่ม Confirm หรือ Cancel
            lnq.CONFIRM_CANCEL_DATETIME = DateTime.Now
            lnq.SYNC_TO_SERVER = "N"


            Dim trans As New KioskTransactionDB
            Dim re As ExecuteDataInfo
            If lnq.ID = 0 Then
                re = lnq.InsertData(StaffConsole.Username, trans.Trans)
            Else
                re = lnq.UpdateData(StaffConsole.Username, trans.Trans)
            End If

            If re.IsSuccess = True Then
                _FillMoneyID = lnq.ID
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                InsertErrorLogSC(StaffConsole.Username, re.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            End If
            lnq = Nothing
            ret = re.IsSuccess
        Catch ex As Exception
            ret = False
            InsertErrorLogSC(StaffConsole.Username, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
        End Try
        Return ret
    End Function



    Private Sub frmSC_FillPaper_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillMoney_OpenFOrm, "", False)

        Dim sql As String = "select kd.device_id, kd.kiosk_max_qty max_qty, kd.kiosk_current_qty current_qty, kd.kiosk_current_money current_money,kd.unit_value"
        sql += " from v_kiosk_device_info kd "
        sql += " where kd.ms_kiosk_id=@_KIOSK_ID"
        sql += " and kd.type_active_status='Y' and kd.device_active_status='Y'"
        sql += " order by kd.device_name_en"
        Dim p(1) As SqlParameter
        p(0) = KioskDB.SetBigInt("@_KIOSK_ID", Convert.ToInt16(KioskData.KioskID))

        Dim TotalMoney As Integer = 0
        Dim Dt As DataTable = KioskDB.ExecuteTable(sql, p)
        If Dt.Rows.Count > 0 Then
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillMoney_CheckKioskMoney, "", False)

            For i As Integer = 0 To Dt.Rows.Count - 1
                Dim dr As DataRow = Dt.Rows(i)

                Dim vDeviceID As Long = Convert.ToInt64(dr("device_id"))

                Select Case vDeviceID
                    Case Data.ConstantsData.DeviceID.CoinIn
                        If Convert.IsDBNull(dr("current_money")) = False Then
                            txtCoinInMoney.Text = Convert.ToInt64(dr("current_money")).ToString("#,##0.00")
                            TotalMoney += Convert.ToInt64(dr("current_money"))
                        End If
                    Case Data.ConstantsData.DeviceID.BankNoteIn
                        If Convert.IsDBNull(dr("current_money")) = False Then
                            txtBanknoteInMoney.Text = Convert.ToInt64(dr("current_money")).ToString("#,##0.00")
                            TotalMoney += Convert.ToInt64(dr("current_money"))
                        End If
                    Case Data.ConstantsData.DeviceID.CoinOut_5
                        If Convert.IsDBNull(dr("current_qty")) = False Then
                            txtCoinOut5.Text = Convert.ToInt64(dr("current_qty"))
                            TotalMoney += (Convert.ToInt64(dr("current_qty")) * Convert.ToInt16(dr("unit_value")))
                        End If

                        If Convert.IsDBNull(dr("max_qty")) = False Then
                            lblTotalCoinOut5.Text = "/ " & Convert.ToInt16(dr("max_qty")) & " เหรียญ"
                            lblMaxCoin5.Text = Convert.ToInt16(dr("max_qty")).ToString("#,##0")
                        End If
                    Case Data.ConstantsData.DeviceID.BankNoteOut_20
                        If Convert.IsDBNull(dr("current_qty")) = False Then
                            txtBanknoteOut20.Text = Convert.ToInt64(dr("current_qty"))
                            TotalMoney += (Convert.ToInt64(dr("current_qty")) * Convert.ToInt16(dr("unit_value")))
                        End If
                        If Convert.IsDBNull(dr("max_qty")) = False Then
                            lblTotalBanknoteOut20.Text = "/ " & Convert.ToInt16(dr("max_qty")) & " ใบ"
                            lblMaxBanknote20.Text = Convert.ToInt16(dr("max_qty")).ToString("#,##0")
                        End If
                    Case Data.ConstantsData.DeviceID.BankNoteOut_100
                        If Convert.IsDBNull(dr("current_qty")) = False Then
                            txtBanknoteOut100.Text = Convert.ToInt64(dr("current_qty"))
                            TotalMoney += (Convert.ToInt64(dr("current_qty")) * Convert.ToInt16(dr("unit_value")))
                        End If
                        If Convert.IsDBNull(dr("max_qty")) = False Then
                            lblTotalBanknoteOut100.Text = "/ " & Convert.ToInt16(dr("max_qty")) & " ใบ"
                            lblMaxBanknote100.Text = Convert.ToInt16(dr("max_qty")).ToString("#,##0")
                        End If
                End Select
            Next

            txtTotalMoney.Text = TotalMoney.ToString("#,##0.00")
        End If
        Dt.Dispose()

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillMoney_InsertFillMoney, "", False)
        InsertFillMoney(TotalMoney)

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillMoney_CheckAuthorize, "", False)
        SetStaffConsoleAuthorize()
    End Sub

    Private Sub SetStaffConsoleAuthorize()
        If StaffConsole.AuthorizeInfo.Rows.Count > 0 Then
            AppScreenList.DefaultView.RowFilter = "id='" & Convert.ToInt16(KioskConfig.SelectForm) & "'"
            If AppScreenList.DefaultView.Count > 0 Then
                lblCheckOutMoney.Visible = False
                txtCoinOut5.Enabled = False
                txtBanknoteOut20.Enabled = False
                txtBanknoteOut100.Enabled = False
                btnFillAllFull.Visible = False

                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = "ms_functional_id=17 and authorization_name='Edit'"
                If StaffConsole.AuthorizeInfo.DefaultView.Count > 0 Then
                    lblCheckOutMoney.Visible = True
                    txtCoinOut5.Enabled = True
                    txtBanknoteOut20.Enabled = True
                    txtBanknoteOut100.Enabled = True
                    btnFillAllFull.Visible = True
                End If
                StaffConsole.AuthorizeInfo.DefaultView.RowFilter = ""
            End If
            AppScreenList.DefaultView.RowFilter = ""
        End If
    End Sub


    Private Sub lblCancel_Click(sender As Object, e As EventArgs) Handles lblCancel.Click, btnCancel.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillMoney_ClickCancel, "", False)

        ConfirmFillMoney("N")

        Me.Close()
        frmMain.CloseAllChildForm()
        Dim f As New frmSC_StockAndHardware
        f.ShowDialog(frmMain)
    End Sub

    Private Function ConfirmFillMoney(IsConfirm As String) As TbFillMoneyKioskLinqDB
        Dim lnq As New TbFillMoneyKioskLinqDB
        Try
            lnq.GetDataByPK(_FillMoneyID, Nothing)
            If lnq.ID > 0 Then
                lnq.IS_CONFIRM = IsConfirm
                lnq.CHECKOUT_DATETIME = DateTime.Now
                lnq.CHANGE1_QTY = 0
                lnq.CHANGE2_QTY = 0
                lnq.CHANGE5_QTY = 0
                lnq.CHANGE10_QTY = 0
                lnq.CHANGE5_QTY = Convert.ToInt16(Replace(txtCoinOut5.Text, ",", ""))
                lnq.CHANGE10_QTY = 0
                lnq.CHANGE20_QTY = Convert.ToInt16(Replace(txtBanknoteOut20.Text, ",", ""))
                lnq.CHANGE50_QTY = 0
                lnq.CHANGE100_QTY = Convert.ToInt16(Replace(txtBanknoteOut100.Text, ",", ""))
                lnq.CHANGE500_QTY = 0
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB

                Dim re As ExecuteDataInfo = lnq.UpdateData(StaffConsole.Username, trans.Trans)
                If re.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    InsertErrorLogSC(StaffConsole.Username, re.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                    ShowDialogErrorMessageSC("Fill Money Fail")
                End If
            End If
            'lnq = Nothing
        Catch ex As Exception
            InsertErrorLogSC(StaffConsole.Username, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            ShowDialogErrorMessageSC("Fill Money  Fail")
        End Try
        Return lnq
    End Function

    Private Sub lblConfirm_Click(sender As Object, e As EventArgs) Handles lblConfirm.Click, btnConfirm.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillMoney_ClickConfirm, "", False)

        Dim lnq As TbFillMoneyKioskLinqDB = ConfirmFillMoney("Y")
        If lnq.ID > 0 Then
            If lnq.CHECKOUT_RECEIVE_MONEY = "Y" Then
                'ถ้ามีการกดปุ่มนำออกทั้งหมด ให้อัพเดท Stock ของเครือ่งรับเหรียญและรับแบงค์ให้เป็น 0
                UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.CoinIn, 0, 0, True)
                UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.BankNoteIn, 0, 0, True)
            End If

            UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.CoinOut_5, Convert.ToInt16(txtCoinOut5.Text.Replace(",", "")), Convert.ToInt16(txtCoinOut5.Text.Replace(",", "")) * 5, True)
            UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.BankNoteOut_20, Convert.ToInt16(txtBanknoteOut20.Text.Replace(",", "")), Convert.ToInt16(txtBanknoteOut20.Text.Replace(",", "")) * 20, True)
            UpdateKioskCurrentQty(Data.ConstantsData.DeviceID.BankNoteOut_100, Convert.ToInt16(txtBanknoteOut100.Text.Replace(",", "")), Convert.ToInt16(txtBanknoteOut100.Text.Replace(",", "")) * 100, True)
        End If
        lnq = Nothing

        ShowDialogErrorMessageSC("Fill Money Success")
        frmMain.CloseAllChildForm()
        Me.Close()
        Dim f As New frmSC_StockAndHardware
        f.ShowDialog(frmMain)
    End Sub

    Private Sub lblCheckOutMoney_Click(sender As Object, e As EventArgs) Handles lblCheckOutMoney.Click, btnCheckOutMoney.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillMoney_ClickCheckOutMoney, "", False)

        txtBanknoteInMoney.Text = "0.00"
        txtCoinInMoney.Text = "0.00"

        CalTotalMoney()

        UpdateCheckoutMoney()
    End Sub

    Private Sub UpdateCheckoutMoney()
        Try
            Dim lnq As New TbFillMoneyKioskLinqDB
            lnq.GetDataByPK(_FillMoneyID, Nothing)
            If lnq.ID > 0 Then
                lnq.CHECKOUT_RECEIVE_MONEY = "Y"
                lnq.CHECKOUT_DATETIME = DateTime.Now
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB

                Dim ret As ExecuteDataInfo = lnq.UpdateData(StaffConsole.Username, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    InsertErrorLogSC(StaffConsole.Username, ret.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)

                    ShowDialogErrorMessageSC("Update Fail")
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            InsertErrorLogSC(StaffConsole.Username, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            ShowDialogErrorMessageSC("Update Fail")
        End Try
    End Sub

    Private Sub UpdateFillAllFull()
        Try
            Dim lnq As New TbFillMoneyKioskLinqDB
            lnq.GetDataByPK(_FillMoneyID, Nothing)
            If lnq.ID > 0 Then
                lnq.CHECKIN_CHANGE_MONEY = "Y"
                lnq.CHECKIN_DATETIME = DateTime.Now
                lnq.SYNC_TO_SERVER = "N"

                Dim trans As New KioskTransactionDB

                Dim ret As ExecuteDataInfo = lnq.UpdateData(StaffConsole.Username, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    InsertErrorLogSC(StaffConsole.Username, ret.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
                    ShowDialogErrorMessageSC("Update Fail")
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            InsertErrorLogSC(StaffConsole.Username, "Exception : " & ex.Message & vbNewLine & ex.StackTrace, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            ShowDialogErrorMessageSC("Update Fail")
        End Try
    End Sub

    Private Sub lblFillAllFull_Click(sender As Object, e As EventArgs) Handles lblFillAllFull.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleFillMoney_ClickFillAllFull, "", False)

        txtCoinOut5.Text = lblMaxCoin5.Text
        txtBanknoteOut20.Text = lblMaxBanknote20.Text
        txtBanknoteOut100.Text = lblMaxBanknote100.Text

        CalTotalMoney()

        Dim TotalMoney As Double = Convert.ToDouble(txtTotalMoney.Text.Replace(",", ""))
        UpdateFillAllFull()
    End Sub


    Private Sub CalTotalMoney()
        Dim CoinInMoney As Double = Convert.ToDouble(Replace(txtCoinInMoney.Text, ",", ""))
        Dim BanknoteInMoney As Double = Convert.ToDouble(Replace(txtBanknoteInMoney.Text, ",", ""))
        Dim CoinOut5Money As Integer = Convert.ToInt16(Replace(txtCoinOut5.Text, ",", "")) * 5
        Dim BankNote20Money As Integer = Convert.ToInt16(Replace(txtBanknoteOut20.Text, ",", "")) * 20
        Dim BankNote100Money As Integer = Convert.ToInt16(Replace(txtBanknoteOut100.Text, ",", "")) * 100

        Dim TotalMoney As Double = CoinInMoney + BanknoteInMoney + CoinOut5Money + BankNote20Money + BankNote100Money
        txtTotalMoney.Text = TotalMoney.ToString("#,##0.00")
    End Sub

    Private Sub txtMoneyOut_LostFocus(sender As Object, e As EventArgs) Handles txtCoinOut5.LostFocus, txtBanknoteOut20.LostFocus, txtBanknoteOut100.LostFocus
        If DirectCast(sender, TextBox).Text.Trim = "" Then
            DirectCast(sender, TextBox).Text = "0"
        End If
        CalTotalMoney()
    End Sub

    Private Sub txtMoneyOut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCoinOut5.KeyPress, txtBanknoteOut20.KeyPress, txtBanknoteOut100.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
End Class