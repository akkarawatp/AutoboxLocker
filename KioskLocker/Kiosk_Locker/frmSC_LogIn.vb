Imports System.DirectoryServices.AccountManagement
Imports MiniboxLocker.Data
Imports MiniboxLocker.Data.KioskConfigData
Imports MiniboxLocker.ServiceTransactionData
Imports KioskLinqDB.ConnectDB
Imports Engine

Public Class frmSC_LogIn
    Private Sub frmSC_LogIn_Load(sender As Object, e As EventArgs) Handles Me.Load
        KioskConfig.SelectForm = KioskLockerForm.StaffConsoleLogin
        Me.ControlBox = False
    End Sub

    Private Sub frmSC_LogIn_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Me.WindowState = FormWindowState.Maximized
        txtUsername.Focus()
        KioskConfig.SelectForm = KioskLockerForm.StaffConsoleLogin
        StaffConsole = New StaffConsoleLogonData(KioskData.KioskID)
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_OpenFOrm, "", False)
    End Sub

    Private Sub lblCancel_Click(sender As Object, e As EventArgs) Handles lblCancel.Click
        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_ClickCancel, "", False)
        frmMain.TimerCheckOpenClose.Enabled = True
        Me.Close()
        frmMain.Show()
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLogin_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles lblLogin.Click

        InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_ClickLogin, "", False)

        If txtUsername.Text.Trim = "" Then
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_LoginValidate, "Please enter Username", False)
            ShowDialogErrorMessageSC("Please enter Username")
            Exit Sub
        End If
        If txtPassword.Text.Trim = "" Then
            InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_LoginValidate, "Please enter Password", False)
            ShowDialogErrorMessageSC("Please enter Password")
            Exit Sub
        End If

        If KioskConfig.IsLoginSSO = True Then
            frmLoading.Show(frmSC_Main)
            Application.DoEvents()

            Dim WS As New Webservice_Locker.ATBLockerWebService
            WS.Url = KioskConfig.WebserviceLockerURL
            WS.Timeout = 10000

            Dim SSOLogin As Webservice_Locker.LoginReturnData = LogInSSO(txtUsername.Text, txtPassword.Text, WS)
            If SSOLogin.LoginStatus = True Then
                If SSOLogin.ErrorMessage <> "" Then
                    ShowDialogErrorMessageSC(SSOLogin.ErrorMessage)
                End If

                InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_GetAuthorize, "", False)
                Dim aDt As DataTable = WS.GetKioskStaffConsoleAuthorize(txtUsername.Text, KioskData.KioskID)
                If aDt.Rows.Count = 0 Then
                    InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_GetAuthorize, "You not have authorization", True)
                    ShowDialogErrorMessageSC("You not have authorization")
                    Exit Sub
                End If

                InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_CreateTransaction, "", False)
                Dim ret As ExecuteDataInfo = CreateNewStaffConsoleTransaction(txtUsername.Text, SSOLogin.LoginFirstName, SSOLogin.LoginLastName, SSOLogin.LoginCompanyName, "1")
                If ret.IsSuccess = False Then
                    InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_CreateTransaction, "Cannot Create Staff Console Transaction", True)
                    ShowDialogErrorMessageSC("Cannot Create Staff Console Transection")
                    InsertErrorLog(ret.ErrorMessage, 0, 0, 0, KioskConfig.SelectForm, 0)
                    Exit Sub
                End If
                StaffConsole.AuthorizeInfo = aDt

                InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_UpdateHardwareAndStock, "", False)

                'ตรวจสอบและส่ง Alarm เมื่อเครื่องเชื่อมอินเตอร์เน็ตได้
                UpdateAllDeviceStatusByComPort()
                UpdateAllDeviceStatusByUsbPort()
                txtUsername.Text = ""
                txtPassword.Text = ""
                Me.Close()
                frmSC_Main.Show()
            Else
                InsertLogTransactionActivity(StaffConsole.TransNo, KioskConfig.SelectForm, KioskLockerStep.StaffConsoleLogin_LoginValidate, SSOLogin.ErrorMessage, True)
                ShowDialogErrorMessageSC(SSOLogin.ErrorMessage)
                InsertErrorLog(SSOLogin.ErrorMessage, 0, 0, 0, KioskConfig.SelectForm, 0)
                frmLoading.Close()
            End If
            WS.Dispose()

            'Else
            '    'Login With Windows Account
            '    Dim pc As New PrincipalContext(ContextType.Machine)
            '    If pc.ValidateCredentials(txtUsername.Text.Trim, txtPassword.Text.Trim) Then
            '        Dim ret As ExecuteDataInfo = CreateNewStaffConsoleTransaction(txtUsername.Text, "", "", "", "2")

            '        If ret.IsSuccess = False Then
            '            ShowDialogErrorMessage("Cannot Login Staff Console Transection with Window Authentication")
            '            InsertErrorLog(ret.ErrorMessage, 0, 0, 0, KioskConfig.SelectForm, 0)
            '            Exit Sub
            '        End If

            '        Me.Hide()
            '        frmMain.CloseAllChildForm()

            '        Dim f As New frmSC_StockAndHardware
            '        f.MdiParent = frmMain
            '        f.Show()
            '    Else
            '        'InsertLogTransactionActivity(Customer.TransactionNo, StateModule.StaffConsole, StateStep_SCC.LoginNotice, "Invalid Username or Password")
            '        ShowDialogErrorMessageSC("Invalid Username or Password")
            '    End If
            '    pc.Dispose()
        End If
    End Sub


End Class