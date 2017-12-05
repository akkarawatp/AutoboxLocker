Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Public Class ucLockerInfo
    Dim _LockerID As Integer = 0
    Dim _CabinetID As Integer = 0
    Dim _CabinetModelID As Integer = 0
    Dim _IsSetting As Boolean = False
    Dim _AvailableStatus As AvailableStatus = AvailableStatus.Availabled

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        BoardSolenoid.BindSolenoidPin(cbSolenoidPin)
        BoardLED.BindLEDPin(cbLEDPin)
        BoardSensor.BindSensorPin(cbSensorPin)
    End Sub



    Public Event LockerClick(sender As ucLockerInfo, e As EventArgs)
    Public Property LockerID As Integer
        Get
            Return _LockerID
        End Get
        Set(value As Integer)
            _LockerID = value
        End Set
    End Property
    Public Property CabinetID As Integer
        Get
            Return _CabinetID
        End Get
        Set(value As Integer)
            _CabinetID = value
        End Set
    End Property
    Public Property CabinetModelID As Integer
        Get
            Return _CabinetModelID
        End Get
        Set(value As Integer)
            _CabinetModelID = value
        End Set
    End Property


    Public WriteOnly Property IsSetting As Boolean
        Set(value As Boolean)
            _IsSetting = value

            If value = False Then
                pbLockerName.Visible = _IsSetting
                txtLockerName.Visible = _IsSetting
                cbSolenoidPin.Visible = _IsSetting
                cbSensorPin.Visible = _IsSetting
                cbLEDPin.Visible = _IsSetting
                lblSensorPin.Visible = _IsSetting
                lblSolinoidPin.Visible = _IsSetting
                'lblName.Visible = _IsSetting
                lblLEDPin.Visible = _IsSetting
            End If
        End Set
    End Property

    Public Property LockerAvailable As AvailableStatus
        Get
            Return _AvailableStatus
        End Get
        Set(value As AvailableStatus)
            _AvailableStatus = value

            If _IsSetting = False Then
                If _AvailableStatus = AvailableStatus.Availabled Then
                    Me.BackColor = Color.White
                    lblName.BackColor = Color.White
                    lblName.ForeColor = Color.Black
                    AddHandler lblName.Click, AddressOf ucLockerInfo_Click
                ElseIf _AvailableStatus = AvailableStatus.NotAvailable Then
                    Me.BackColor = Color.FromArgb(232, 88, 88)
                    lblName.BackColor = Color.FromArgb(232, 88, 88)
                    lblName.ForeColor = Color.White
                    AddHandler lblName.Click, AddressOf ucLockerInfo_Click
                ElseIf _AvailableStatus = AvailableStatus.InActive Then
                    Me.BackColor = Color.Gray
                End If
            End If
            Application.DoEvents()
        End Set
    End Property


    Private Sub ucLockerInfo_Click(sender As Object, e As EventArgs) Handles Me.Click
        If _IsSetting = False Then
            Me.Enabled = False
            RaiseEvent LockerClick(Me, e)
            Me.Enabled = True
        End If
    End Sub

    Private Sub ucLockerInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Me.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub ucLockerInfo_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Me.BorderStyle = BorderStyle.None
    End Sub

    Public Enum AvailableStatus
        Availabled = 1
        NotAvailable = 2
        InActive = 3
    End Enum

    Private Sub LoadLockerPinSetting()
        Try
            Dim lnq As New MsLockerKioskLinqDB
            lnq.GetDataByPK(_LockerID, Nothing)
            If lnq.ID > 0 Then
                txtLockerName.Text = lnq.LOCKER_NAME
                cbSolenoidPin.SelectedValue = lnq.PIN_SOLENOID
                cbLEDPin.SelectedValue = lnq.PIN_LED
                cbSensorPin.SelectedValue = lnq.PIN_SENSOR
            End If
            lnq = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ucLockerInfo_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        If _IsSetting = True Then
            Dim frm As New frmSC_DialogSettingLocker
            frm.LockerID = _LockerID
            frm.ShowDialog()
            LoadLockerPinSetting()

        End If
    End Sub
End Class
