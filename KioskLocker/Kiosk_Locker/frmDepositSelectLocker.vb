'Imports System.Data.SqlClient
Imports AutoboxLocker.Data.KioskConfigData
'Imports AutoboxLocker.Data.KioskLockerStateData
'Imports AutoboxLocker.ServiceTransactionData
Public Class frmDepositSelectLocker
    Dim TimeOut As Int32 = KioskConfig.TimeOutSec
    Dim TimeOutCheckTime As DateTime = DateTime.Now

    Private Sub frmDepositSelectLocker_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ControlBox = False
        Me.BackColor = bgColor
        KioskConfig.SelectForm = KioskLockerForm.DepositSelectLocker
        SetChildFormLanguage()
    End Sub
    Private Sub frmDepositSelectLocker_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        frmMain.pnlAds.Visible = False
        frmMain.pnlFooter.Visible = True
        frmMain.pnlCancel.Visible = True

        Application.DoEvents()
        InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_OpenForm, "", False)
        TimeOutCheckTime = DateTime.Now
        TimerTimeOut.Enabled = True

    End Sub

    Dim AllPadding As Integer = 1
    Dim PcWidth As Integer = 75

    Public Sub LoadLockerList()
        Try
            InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_LoadLockerList, "", False)
            Dim cbWith As Integer = 0

            UcCabinet1.LoadCabinetData(False, CabinetList)
            If UcCabinet1.LockerActiveQty > 0 Then
                cbWith += UcCabinet1.Width + AllPadding
            End If

            UcCabinet2.LoadCabinetData(False, CabinetList)
            If UcCabinet2.LockerActiveQty > 0 Then
                cbWith += UcCabinet2.Width + AllPadding
            End If

            UcCabinet3.LoadCabinetData(False, CabinetList)
            If UcCabinet3.LockerActiveQty > 0 Then
                cbWith += UcCabinet3.Width + AllPadding
            End If

            UcCabinet4.LoadCabinetData(False, CabinetList)
            If UcCabinet4.LockerActiveQty > 0 Then
                cbWith += UcCabinet4.Width + AllPadding
            End If

            UcCabinet5.LoadCabinetData(False, CabinetList)
            If UcCabinet5.LockerActiveQty > 0 Then
                cbWith += UcCabinet5.Width + AllPadding
            End If

            UcCabinet6.LoadCabinetData(False, CabinetList)
            If UcCabinet6.LockerActiveQty > 0 Then
                cbWith += UcCabinet6.Width + AllPadding
            End If

            UcCabinet7.LoadCabinetData(False, CabinetList)
            If UcCabinet7.LockerActiveQty > 0 Then
                cbWith += UcCabinet7.Width + AllPadding
            End If

            UcCabinet8.LoadCabinetData(False, CabinetList)
            If UcCabinet8.LockerActiveQty > 0 Then
                cbWith += UcCabinet8.Width + AllPadding
            End If

            UcCabinet9.LoadCabinetData(False, CabinetList)
            If UcCabinet9.LockerActiveQty > 0 Then
                cbWith += UcCabinet9.Width + AllPadding
            Else
                UcCabinet9.Visible = False
            End If

            UcCabinet10.LoadCabinetData(False, CabinetList)
            If UcCabinet10.LockerActiveQty > 0 Then
                cbWith += UcCabinet10.Width + AllPadding
            Else
                UcCabinet10.Visible = False
            End If


            'วิธีการคำนวณ 
            'ความกว้างทั้งหมดคือ (oQty*61)
            Dim pLeft As Integer = (pnlCabinetLayout.Width / 2) - ((cbWith + PcWidth + AllPadding) / 2)
            pLeft = SetCabinetPosition(UcCabinet1, pLeft, 1)
            pLeft = SetCabinetPosition(UcCabinet2, pLeft, 2)
            pLeft = SetCabinetPosition(UcCabinet3, pLeft, 3)
            pLeft = SetCabinetPosition(UcCabinet4, pLeft, 4)
            pLeft = SetCabinetPosition(UcCabinet5, pLeft, 5)
            pLeft = SetCabinetPosition(UcCabinet6, pLeft, 6)
            pLeft = SetCabinetPosition(UcCabinet7, pLeft, 7)
            pLeft = SetCabinetPosition(UcCabinet8, pLeft, 8)
            pLeft = SetCabinetPosition(UcCabinet9, pLeft, 9)
            pLeft = SetCabinetPosition(UcCabinet10, pLeft, 10)
        Catch ex As Exception
            InsertErrorLog("Exception : " & ex.Message & vbNewLine & ex.StackTrace, Customer.DepositTransNo, 0, 0, KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_LoadLockerList)
        End Try

    End Sub

    Private Function SetCabinetPosition(uc As ucCabinet, pLeft As Integer, ucSeq As Integer) As Integer
        If KioskConfig.LockerPCPosition = ucSeq Then
            pnlLayoutPC.Left = pLeft
            pLeft = pLeft + PcWidth + AllPadding
        End If

        If uc.LockerActiveQty > 0 Then
            uc.Left = pLeft
            pLeft = pLeft + uc.Width + AllPadding
        Else
            uc.Visible = False
        End If
        Application.DoEvents()
        Return pLeft
    End Function



    Private Sub UcCabinet1_LockerClick(f As ucLockerInfo) Handles UcCabinet1.LockerClick, UcCabinet2.LockerClick, UcCabinet3.LockerClick, UcCabinet4.LockerClick, UcCabinet5.LockerClick, UcCabinet6.LockerClick, UcCabinet7.LockerClick, UcCabinet8.LockerClick, UcCabinet9.LockerClick, UcCabinet10.LockerClick
        'MessageBox.Show(LockerID)

        If f.LockerAvailable = ucLockerInfo.AvailableStatus.Availabled Then
            TimeOutCheckTime = DateTime.Now
            TimerTimeOut.Enabled = False
            TimerTimeOut.Stop()

            frmLoading.Show(frmMain)
            InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_SelectLocker, " " & f.txtLockerName.Text, False)

            Application.DoEvents()

            Customer.LockerID = f.LockerID
            Customer.LockerName = f.txtLockerName.Text
            Customer.CabinetID = f.CabinetID
            Customer.CabinetModelID = f.CabinetModelID
            Customer.LockerPinSolenoid = f.cbSolenoidPin.SelectedValue
            Customer.LockerPinLED = f.cbLEDPin.SelectedValue
            Customer.LockerPinSendor = f.cbSensorPin.SelectedValue

            'เลือกช่องฝากแล้วก็ Update Transaction โลด
            If UpdateServiceTransaction(Customer).IsSuccess = True Then
                'frmDepositScanPassport.MdiParent = frmMain
                'frmDepositScanPassport.pnlProcessing.Left = (frmDepositScanPassport.Width / 2) - (frmDepositScanPassport.pnlProcessing.Width / 2)
                'frmDepositScanPassport.pnlProcessing.Top = 35
                'frmDepositScanPassport.pnlProcessing.Visible = True

                'frmDepositScanPassport.Show()
                'frmDepositScanPassport.lblTitle.Visible = True
                'Application.DoEvents()
                'frmDepositScanPassport.StartInitialDevice()
                'frmDepositScanPassport.pnlProcessing.Visible = False
                frmLoading.Close()

                Me.Close()
            End If
        ElseIf f.LockerAvailable = ucLockerInfo.AvailableStatus.NotAvailable AndAlso f.LockerAvailable = ucLockerInfo.AvailableStatus.NoActive Then
            'ถ้าสถานะ ไม่ว่าง ก็ให้อยู่นิ่งๆ ไม่ต้องทำอะไร
        End If
    End Sub

    Private Sub TimerTimeOut_Tick(sender As Object, e As EventArgs) Handles TimerTimeOut.Tick
        If KioskConfig.SelectForm = KioskLockerForm.DepositSelectLocker Then
            Application.DoEvents()
            'lblTimeOut.Text = TimeOut
            If TimeOutCheckTime.AddSeconds(TimeOut) <= DateTime.Now Then
                TimerTimeOut.Enabled = False
                TimerTimeOut.Stop()

                UpdateDepositStatus(Customer.ServiceTransactionID, DepositTransactionData.TransactionStatus.TimeOut, KioskLockerStep.DepositSelectLocker_SelectLocker)
                InsertLogTransactionActivity(Customer.DepositTransNo, "", "", KioskConfig.SelectForm, KioskLockerStep.DepositSelectLocker_SelectLocker, " ลูกค้าไม่ทำรายการภายในเวลาที่กำหนด", False)

                frmMain.CloseAllChildForm()
                Dim f As New frmHome
                f.MdiParent = frmMain
                f.Show()
            End If
        End If

    End Sub
End Class