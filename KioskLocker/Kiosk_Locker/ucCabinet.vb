Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE

Public Class ucCabinet
    Dim _CabinetID As Long = 0
    Dim _CabinetNo As Integer = 0
    Dim _CabinetName As String = ""
    Dim _CabinetActiveStatus As String = "N"
    Dim _LockerActiveQty As Integer = 0
    Dim _CabinetModelID As Long = 0
    Dim _OrderLayoutNo As Integer = 0

    Dim _IsSetting As Boolean = True

    Public Event LockerClick(f As ucLockerInfo)
    Public Event MoveLeftClick(sender As ucCabinet)
    Public Event MoveRightClick(sender As ucCabinet)
    Public Event DeleteCabinet()

    Public Property CabinetID As Long
        Get
            Return _CabinetID
        End Get
        Set(value As Long)
            _CabinetID = value
        End Set
    End Property

    Public Property CabinetName As String
        Get
            Return _CabinetName.Trim
        End Get
        Set(value As String)
            _CabinetName = value
        End Set
    End Property
    Public Property CabinetActiveStatus As String
        Get
            Return _CabinetActiveStatus.Trim
        End Get
        Set(value As String)
            _CabinetActiveStatus = value
        End Set
    End Property
    Public Property CabinetModelID As Long
        Get
            Return _CabinetModelID
        End Get
        Set(value As Long)
            _CabinetModelID = value
        End Set
    End Property
    Public Property OrderLayoutNo As Integer
        Get
            Return _OrderLayoutNo
        End Get
        Set(value As Integer)
            _OrderLayoutNo = value
        End Set
    End Property
    Public Property LockerActiveQty As Integer
        Get
            Return _LockerActiveQty
        End Get
        Set(value As Integer)
            _LockerActiveQty = value
        End Set
    End Property


    Public Sub LoadCabinetData(IsSetting As Boolean, cData As DataTable)
        _IsSetting = IsSetting
        Try
            If cData.Rows.Count > 0 Then
                cData.DefaultView.RowFilter = "order_layout='" & _OrderLayoutNo & "'"
                If cData.DefaultView.Count > 0 Then
                    Dim LockerQty As Integer = 0

                    CabinetModelList.DefaultView.RowFilter = "id='" & cData.DefaultView(0)("ms_cabinet_model_id") & "'"
                    If CabinetModelList.DefaultView.Count > 0 Then
                        LockerQty = CabinetModelList.DefaultView(0)("locker_qty")
                    End If
                    CabinetModelList.DefaultView.RowFilter = ""

                    SetModelLayout(cData.DefaultView(0)("active_status"), cData.DefaultView(0)("id"), cData.DefaultView(0)("ms_cabinet_model_id"), LockerQty)
                End If
                cData.DefaultView.RowFilter = ""

                If _IsSetting = True Then
                    cData.DefaultView.Sort = "order_layout"

                    If _OrderLayoutNo = cData.DefaultView(0)("order_layout") Then
                        pbMoveLeft.Visible = False
                    End If
                    If _OrderLayoutNo = cData.DefaultView(cData.Rows.Count - 1)("order_layout") Then
                        pbMoveRight.Visible = False
                    End If
                    cData.DefaultView.Sort = ""
                End If
                Application.DoEvents()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetModelLayout(ActiveStatus As String, _ID As Long, CabinetModelID As Long, LockerQty As Integer)
        _CabinetActiveStatus = ActiveStatus

        If ActiveStatus = "N" Then Exit Sub

        _CabinetID = _ID
        _CabinetModelID = CabinetModelID


        Dim fPadding As Integer = 1
        Dim fFooter As Integer = IIf(_IsSetting = True, 60, 0)
        Dim fTop As Integer = 0
        Dim fHeigh As Integer = 0
        If LockerQty > 0 Then
            fHeigh = (Me.Size.Height - ((LockerQty - 1) * fPadding) - fFooter) / LockerQty
        End If

        Dim lDt As New DataTable
        LockerList.DefaultView.RowFilter = "ms_cabinet_id='" & _ID & "'"
        If LockerList.DefaultView.Count > 0 Then
            lDt = LockerList.DefaultView.ToTable.Copy
            _LockerActiveQty = lDt.Rows.Count
        End If
        LockerList.DefaultView.RowFilter = ""

        If _IsSetting = False Then
            If _LockerActiveQty = 0 Then
                Exit Sub
            End If
        End If

        For j = Me.Controls.Count - 1 To 0 Step -1
            If TypeOf Me.Controls(j) Is ucLockerInfo Then
                Me.Controls.RemoveAt(j)
            End If
        Next

        If lDt.Rows.Count > 0 Then
            For i As Integer = 0 To lDt.Rows.Count - 1
                Dim lDr As DataRow = lDt.Rows(i)

                Dim f As New ucLockerInfo
                AddHandler f.LockerClick, AddressOf Me.LockerInfo_ClickLocker


                f.IsSetting = _IsSetting
                f.LockerID = Convert.ToInt64(lDr("id"))
                f.CabinetID = _CabinetID
                f.CabinetModelID = _CabinetModelID

                If Convert.IsDBNull(lDr("locker_name")) = False Then
                    f.lblName.Text = lDr("locker_name").ToString
                    f.txtLockerName.Text = lDr("locker_name").ToString
                End If

                If Convert.ToInt64(lDr("pin_solenoid")) > 0 Then
                    f.cbSolenoidPin.SelectedValue = Convert.ToInt64(lDr("pin_solenoid"))
                End If
                If Convert.ToInt64(lDr("pin_led")) > 0 Then
                    f.cbLEDPin.SelectedValue = Convert.ToInt64(lDr("pin_led"))
                End If
                If Convert.IsDBNull(lDr("pin_sensor")) = False Then
                    f.cbSensorPin.SelectedValue = lDr("pin_sensor").ToString
                End If


                f.BorderStyle = BorderStyle.FixedSingle
                If lDr("active_status") = "N" Then
                    f.LockerAvailable = ucLockerInfo.AvailableStatus.NoActive
                ElseIf lDr("current_available") = "Y" Then
                    f.LockerAvailable = ucLockerInfo.AvailableStatus.Availabled
                ElseIf lDr("current_available") = "N" Then
                    f.LockerAvailable = ucLockerInfo.AvailableStatus.NotAvailable
                End If
                Me.Controls.Add(f)

                f.Top = fTop
                f.Left = (Me.Width / 2) - (f.Width / 2)
                f.Height = fHeigh
                fTop += (fHeigh + fPadding)

                If _IsSetting = False Then
                    f.lblName.Visible = True
                    f.lblName.AutoSize = False
                    f.lblName.Height = 40
                    f.lblName.Font = New Font("Superspace", 24, FontStyle.Bold)
                    'f.lblName.Font = New Font("Thai Sans Lite", 24, FontStyle.Bold)
                    f.lblName.Top = (f.Height / 2) - (f.txtLockerName.Height / 2)
                    f.lblName.Left = 0
                    f.lblName.Width = f.Width
                    f.lblName.BorderStyle = BorderStyle.None
                    f.lblName.TextAlign = ContentAlignment.MiddleCenter
                End If
                Application.DoEvents()
            Next


            'pbAdd.Visible = False   'ซ่อนปุ่มบันทึกเลย
            pbDelete.Visible = True   'แสดงปุ่ม Delete
        Else
            'pbAdd.Visible = True
            pbDelete.Visible = False
        End If
        'lDt.Dispose()

    End Sub

    Private Sub LockerInfo_ClickLocker(f As ucLockerInfo, e As EventArgs)
        RaiseEvent LockerClick(f)
    End Sub

    Private Function UpdateCurrentLocker(lDt As DataTable, ModelName As String, i As Integer, lLnq As MsLockerKioskLinqDB, trans As KioskTransactionDB) As ExecuteDataInfo
        Dim re As New ExecuteDataInfo

        Dim lDr As DataRow = lDt.Rows(i)
        lLnq.GetDataByPK(Convert.ToInt64(lDr("id")), trans.Trans)
        If lLnq.ID > 0 Then
            lLnq.LOCKER_NAME = CabinetName & (i + 1)
            lLnq.ACTIVE_STATUS = "Y"
            lLnq.SYNC_TO_SERVER = "N"

            re = lLnq.UpdateData(StaffConsole.Username, trans.Trans)
            If re.IsSuccess = False Then
                InsertErrorLogSC(StaffConsole.Username, re.ErrorMessage, StaffConsole.TransNo, KioskConfig.SelectForm, 0)
            End If
        End If

        Return re
    End Function

    Public Function SaveLockerData() As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo

        If _CabinetID > 0 Then
            Dim trans As New KioskTransactionDB
            For i As Integer = 0 To Me.Controls.Count - 1
                If TypeOf Me.Controls(i) Is ucLockerInfo Then
                    Dim f As ucLockerInfo = DirectCast(Me.Controls(i), ucLockerInfo)
                    Dim lLnq As New MsLockerKioskLinqDB
                    lLnq.GetDataByPK(f.LockerID, trans.Trans)
                    If lLnq.ID > 0 Then
                        lLnq.LOCKER_NAME = f.txtLockerName.Text.Trim
                        lLnq.PIN_SOLENOID = f.cbSolenoidPin.SelectedValue
                        lLnq.PIN_SENSOR = f.cbSensorPin.SelectedValue
                        lLnq.PIN_LED = f.cbLEDPin.SelectedValue
                        lLnq.SYNC_TO_SERVER = "N"

                        ret = lLnq.UpdateData(StaffConsole.Username, trans.Trans)
                        If ret.IsSuccess = False Then
                            Exit For
                        End If
                    End If
                    lLnq = Nothing
                End If
            Next

            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        End If
        Return ret
    End Function

    Private Sub pbDelete_Click(sender As Object, e As EventArgs) Handles pbDelete.Click
        Try
            If MessageBox.Show("ยืนยันการลบข้อมูล?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
                Exit Sub
            End If

            'หา Server Cabinet ID
            Dim trans As New KioskTransactionDB
            Dim lnq As New MsCabinetKioskLinqDB
            lnq.GetDataByPK(_CabinetID, trans.Trans)

            If lnq.MS_CABINET_ID > 0 Then   'Server Cabinet ID
                Dim sql As String = "update ms_locker "
                sql += " set active_status='N'"
                sql += " where ms_cabinet_id=@_SERVER_CABINET_ID"
                Dim p(1) As SqlClient.SqlParameter
                p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_SERVER_CABINET_ID", lnq.MS_CABINET_ID)

                Dim sTrans As New ServerLinqDB.ConnectDB.ServerTransactionDB
                Dim sRet As ServerLinqDB.ConnectDB.ExecuteDataInfo = ServerLinqDB.ConnectDB.ServerDB.ExecuteNonQuery(sql, sTrans.Trans, p)
                If sRet.IsSuccess = True And sRet.RecordEffected > 0 Then
                    sql = "update ms_cabinet "
                    sql += " set active_status='N' "
                    sql += " where id=@_SERVER_CABINET_ID"
                    ReDim p(1)
                    p(0) = ServerLinqDB.ConnectDB.ServerDB.SetBigInt("@_SERVER_CABINET_ID", lnq.MS_CABINET_ID)

                    sRet = ServerLinqDB.ConnectDB.ServerDB.ExecuteNonQuery(sql, sTrans.Trans, p)
                End If

                If sRet.IsSuccess = True Then
                    'Update ข้อมูลที่ Kiosk
                    sql = "update ms_locker "
                    sql += " set active_status='N'"
                    sql += " where ms_cabinet_id=@_KIOSK_CABINET_ID"
                    ReDim p(1)
                    p(0) = KioskDB.SetBigInt("@_KIOSK_CABINET_ID", lnq.ID)

                    Dim ret As ExecuteDataInfo = KioskDB.ExecuteNonQuery(sql, trans.Trans, p)
                    If ret.IsSuccess = True And ret.RecordEffected > 0 Then
                        sql = "update ms_cabinet "
                        sql += " set active_status='N'"
                        sql += " where id=@_KIOSK_CABINET_ID"
                        ReDim p(1)
                        p(0) = KioskDB.SetBigInt("@_KIOSK_CABINET_ID", lnq.ID)
                        ret = KioskDB.ExecuteNonQuery(sql, trans.Trans, p)
                    End If

                    If ret.IsSuccess = True Then
                        sTrans.CommitTransaction()
                        trans.CommitTransaction()

                        _CabinetActiveStatus = "N"
                        'Raise Event
                        RaiseEvent DeleteCabinet()
                    Else
                        sTrans.RollbackTransaction()
                        trans.RollbackTransaction()
                        ShowDialogErrorMessageSC("ไม่สามารถลบข้อมูลได้")
                    End If
                Else
                    sTrans.RollbackTransaction()
                    ShowDialogErrorMessageSC("ไม่สามารถลบข้อมูลได้")
                End If
            Else
                trans.RollbackTransaction()
                ShowDialogErrorMessageSC("ไม่สามารถลบข้อมูลได้")
            End If

            lnq = Nothing
        Catch ex As Exception
            ShowDialogErrorMessageSC("Exception " & ex.Message)
        End Try
    End Sub

    Private Sub pbMoveLeft_Click(sender As Object, e As EventArgs) Handles pbMoveLeft.Click
        RaiseEvent MoveLeftClick(Me)
    End Sub

    Private Sub pbMoveRight_Click(sender As Object, e As EventArgs) Handles pbMoveRight.Click
        RaiseEvent MoveRightClick(Me)
    End Sub
End Class
