Imports System.Data.SqlClient
Imports System.IO
Imports Kiosk_Locker.Data
Imports Kiosk_Locker.Data.KioskConfigData


Public Class frmPickupConfirmOpenLocker

    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Private Sub frmPickupConfirmOpenLocker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        KioskConfig.SelectForm = KioskLockerForm.PickupConformOpenLocker
        SetChildFormLanguage()
        SetControlLanguage()
    End Sub

    Public Sub SetControlLanguage()
        Try
            Dim THBText As String = THB_EN
            If KioskConfig.Language = KioskLanguage.Thai Then
                THBText = "บาท"
            Else
                If KioskConfig.Language = KioskLanguage.English Then
                    THBText = THB_EN
                ElseIf KioskConfig.Language = KioskLanguage.China Then
                    THBText = THB_CH
                ElseIf KioskConfig.Language = KioskLanguage.Japan Then
                    THBText = THB_JP
                End If
            End If
            lblChangeTHB.Text = THBText
            Application.DoEvents()
        Catch ex As Exception
            Dim _err As String = "Exception : " & ex.Message & " " & ex.StackTrace
            InsertLogTransactionActivity(_err, Pickup.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupConformOpenLocker_OpenForm, "", False)
        End Try
    End Sub

    Private Sub frmPickupConfirmOpenLocker_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        InsertLogTransactionActivity(Pickup.DepositTransNo, Pickup.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupConformOpenLocker_OpenForm, "", False)
        Me.WindowState = FormWindowState.Maximized
        frmMain.pnlAds.Visible = False
        frmMain.pnlFooter.Visible = True
        frmMain.btnCancel.Visible = False
        Application.DoEvents()

        Pickup.PaidTime = DateTime.Now

        InsertLogTransactionActivity(Pickup.DepositTransNo, Pickup.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupConformOpenLocker_LEDBlinkOn, Pickup.LockerName, False)
        BoardLED.LEDBlinkOn(Pickup.LockerPinLED)
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        InsertLogTransactionActivity(Pickup.DepositTransNo, Pickup.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupConformOpenLocker_ClickOpenLocker, Pickup.LockerName, False)

        frmLoading.Show(frmMain)
        ConfirmOpenLocker()
        frmLoading.Close()
    End Sub

    Private Sub ConfirmOpenLocker()
        If OpenLocker(Pickup.LockerID, Pickup.LockerPinSolenoid, Pickup.LockerPinSendor, KioskLockerStep.PickupConformOpenLocker_ReturnMoney) = True Then
            InsertLogTransactionActivity(Pickup.DepositTransNo, Pickup.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupConformOpenLocker_ClickOpenLocker, "ช่องฝาก " & Pickup.LockerName & " ถูกเปิดออก", False)

            Application.DoEvents()

            Dim f As New frmPickupThankyou
            f.MdiParent = frmMain
            f.Show()
            Application.DoEvents()

            frmMain.CloseAllChildForm(f)
        Else
            InsertLogTransactionActivity(Pickup.DepositTransNo, Pickup.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupConformOpenLocker_ReturnMoney, "", True)

            'เปิดตู้ไม่ได้ คืนเงินเต็มจำนวน
            ReturnMoney(Pickup.PaidAmount, Customer, Pickup)
            BoardLED.LEDStop(Pickup.LockerPinLED)
            ShowFormError("Out of Service", "Cannot open Locker " & Pickup.LockerName, KioskConfig.SelectForm, KioskLockerStep.PickupConformOpenLocker_ReturnMoney, True)
        End If
    End Sub

    Private Sub tmTimeOut_Tick(sender As Object, e As EventArgs) Handles tmTimeOut.Tick
        TimeOut = TimeOut - 1
        Application.DoEvents()
        lblTimeOut.Text = TimeOut
        If TimeOut = 0 Then
            InsertLogTransactionActivity(Pickup.DepositTransNo, Pickup.TransactionNo, "", KioskConfig.SelectForm, KioskLockerStep.PickupConformOpenLocker_TimeOutOpenLocker, Pickup.LockerName, False)
            tmTimeOut.Enabled = False
            ConfirmOpenLocker()
        End If
    End Sub
End Class