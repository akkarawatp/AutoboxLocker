Imports System.Data
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE
Imports System.Data.SqlClient

Public Class frmMasterLocation
    Inherits System.Web.UI.Page

    Dim BL As New LockerBL
    Const FunctionalID As Int16 = 8
    Const FunctionalZoneID As Int16 = 4

    Protected ReadOnly Property UserName As String
        Get
            Try
                Return Session("UserName")
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Public Property EditLocationCode As String
        Get
            Try
                Return ViewState("location_code")
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(value As String)
            ViewState("location_code") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
        If ufDt Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End If

        If ufDt.Rows.Count > 0 Then
            Dim auDt As DataTable = BL.GetList_User_Functional(0, FunctionalZoneID, FunctionalID, Session("Username"))
            If auDt.Rows.Count = 0 Then
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
                Exit Sub
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()

        If Not IsPostBack Then
            BindList()
        Else
            initFormPlugin()
        End If
    End Sub

    Protected Sub SetAuthorizedLevel(ByVal DT As DataTable)
        'AuthorizedLevel = BL.GetFunctionalAuthorized(DT, FN_ID)
    End Sub

    Private Sub initFormPlugin()
        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Plugin", "initFormPlugin();", True)
    End Sub

    Private Sub BindList()
        Dim DT As DataTable = BL.GetList_Location("")
        rptList.DataSource = DT
        rptList.DataBind()

        lblTotalList.Text = FormatNumber(DT.Rows.Count, 0)

        'ColEdit.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
        'ColDelete.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
        'btnAdd.Visible = AuthorizedLevel = TSKBL.AuthorizedLevel.Edit
        EditLocationCode = ""
        pnlList.Visible = True
        pnlEdit.Visible = False


        'ตรวจสอบสิทธิ์การแก้ไขข้อมูล
        Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
        If ufDt Is Nothing Then
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
        End If

        If ufDt.Rows.Count > 0 Then
            Dim auDt As DataTable = BL.GetList_User_Functional(2, FunctionalZoneID, FunctionalID, Session("Username"))
            If auDt.Rows.Count = 0 Then
                btnAdd.Visible = False

                For i As Integer = 0 To rptList.Items.Count - 1
                    Dim btnEdit As Button = rptList.Items(i).FindControl("btnEdit")
                    Dim btnDelete As Button = rptList.Items(i).FindControl("btnDelete")

                    btnEdit.Text = "View"
                    btnDelete.Enabled = False
                Next
            End If
            auDt.Dispose()
        End If
        ufDt.Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        ClearEditForm()

        pnlList.Visible = False
        pnlEdit.Visible = True

        CurrentTab = Tab.ServiceRate
    End Sub

    Private Sub ClearEditForm()
        EditLocationCode = ""
        txtLocationCode.Text = ""
        txtLocationName.Text = ""
        chkActive.Checked = False
        lblEditMode.Text = "Add"

        lphDt = GetDataCurrentPromotion(0)

        ClearFormServiceRate()
        FillDataPromotion(0)
    End Sub

    Private Sub ClearFormServiceRate()

        'Get Service Rate Information 
        cmDt = getDataCabinetModel()
        hourDt = GetHourList()
        srdDt = GetDataServiceRateDeposit(0)
        sroDt = GetDataServiceRateOvernight(0)
        srhDt = GetDataServiceRateHour(0)

        rptDepositCabinetModel.DataSource = cmDt
        rptDepositCabinetModel.DataBind()

        rptOvernightRate.DataSource = cmDt
        rptOvernightRate.DataBind()

        rptRateHeadModel.DataSource = cmDt
        rptRateHeadModel.DataBind()

        rptServiceRateHour.DataSource = hourDt
        rptServiceRateHour.DataBind()
    End Sub



    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click

        If txtLocationCode.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Location Code');", True)
            Exit Sub
        End If
        If txtLocationName.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Location Name');", True)
            Exit Sub
        End If

        Dim DT As DataTable = BL.GetList_Location("")
        DT.DefaultView.RowFilter = "location_Code='" & txtLocationCode.Text.Replace("'", "''") & "' AND location_code <>'" & EditLocationCode.Replace("'", "''") & "'"
        If DT.DefaultView.Count > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('This Location Code is already existed');", True)
            Exit Sub
        End If

#Region "Validate Service Rate Information"
        ''''###########################################################
        'Validate Service Rate Information
        'Validate Deposit Data
        For i As Integer = 0 To rptDepositCabinetModel.Items.Count - 1
            Dim txtDepositRate As TextBox = rptDepositCabinetModel.Items(i).FindControl("txtDepositRate")
            If txtDepositRate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Deposit');", True)
                Exit Sub
            End If
        Next

        'Validate Service Rate Data
        For i As Integer = 0 To rptServiceRateHour.Items.Count - 1
            Dim rptRateHourModel As Repeater = rptServiceRateHour.Items(i).FindControl("rptRateHourModel")

            For j As Integer = 0 To rptRateHourModel.Items.Count - 1
                Dim txtServiceRate As TextBox = rptRateHourModel.Items(j).FindControl("txtServiceRate")
                If txtServiceRate.Text.Trim = "" Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Service Rate');", True)
                    Exit Sub
                End If
            Next
        Next

        'Validate Overnight Rate
        For i As Integer = 0 To rptOvernightRate.Items.Count - 1
            Dim txtOvernightRate As TextBox = rptOvernightRate.Items(i).FindControl("txtOvernightRate")
            If txtOvernightRate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Next day');", True)
                Exit Sub
            End If
        Next
        ''''###########################################################
#End Region

#Region "Validate Promotion Information"
        Dim IsChkValidPromotion As Boolean = False
        If lblPublishStatus.Text = "0" Then
            If txtPromotionName.Text.Trim <> "" Or txtPromotionStartDate.Text.Trim <> "" Or txtPromotionEndDate.Text.Trim <> "" Or CheckValidPromotion() = True Then
                IsChkValidPromotion = True
            End If
        End If

        If IsChkValidPromotion = True Then
            If txtPromotionName.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Promotion Name');", True)
                Exit Sub
            End If

            If txtPromotionStartDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Select Promotion Period From');", True)
                Exit Sub
            End If

            If txtPromotionEndDate.Text.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Select Promotion Period To');", True)
                Exit Sub
            End If

            If Converter.ConvertTextToDate(txtPromotionStartDate.Text) > Converter.ConvertTextToDate(txtPromotionEndDate.Text) Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('The promotion period start date must be less than end date');", True)
                Exit Sub
            End If

            If Converter.ConvertTextToDate(txtPromotionStartDate.Text) <= DateTime.Now.Date Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('The promotion period start date must be date in advance');", True)
                Exit Sub
            End If

            If CheckPromotionDateOverlap(EditLocationCode, lblLocationPromotionID.Text) = True Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Promotion period date is overlap');", True)
                Exit Sub
            End If

            For i As Integer = 0 To rptPromotionRateHour.Items.Count - 1
                Dim rptPromotionRateHourModel As Repeater = rptPromotionRateHour.Items(i).FindControl("rptPromotionRateHourModel")

                For j As Integer = 0 To rptPromotionRateHourModel.Items.Count - 1
                    Dim txtPromotionRate As TextBox = rptPromotionRateHourModel.Items(j).FindControl("txtPromotionRate")
                    If txtPromotionRate.Text.Trim = "" Then
                        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Insert Promotion Rate');", True)
                        Exit Sub
                    End If
                Next
            Next
        End If

#End Region

        Dim trans As New ServerTransactionDB
        Dim lnqLoc As New MsLocationServerLinqDB
        lnqLoc.ChkDataByLOCATION_CODE(EditLocationCode, trans.Trans)
        With lnqLoc
            .LOCATION_CODE = txtLocationCode.Text.Replace("'", "''")
            .LOCATION_NAME = txtLocationName.Text.Replace("'", "''")
            .ACTIVE_STATUS = IIf(chkActive.Checked, "Y", "N")
        End With

        Dim ret As New ExecuteDataInfo
        If lnqLoc.ID = 0 Then
            ret = lnqLoc.InsertData(UserName, trans.Trans)
        Else
            ret = lnqLoc.UpdateData(UserName, trans.Trans)
        End If
        If ret.IsSuccess = True Then
            'ret = DeleteCurrentServiceRate(lnqLoc.ID, trans)
            If ret.IsSuccess = True Then

                ret = SaveServiceRateData(lnqLoc.ID, trans)
                If ret.IsSuccess = True Then
                    If lblPublishStatus.Text = "0" And IsChkValidPromotion = True Then
                        'ถ้ามีการคีย์ข้อมูล Promotion เข้ามาด้วย
                        ret = SavePromotionData(lnqLoc.ID, trans)
                    End If

                    If ret.IsSuccess = True Then
                        trans.CommitTransaction()
                        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Save success');", True)
                        BindList()
                    Else
                        trans.RollbackTransaction()
                        ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", """") & "');", True)
                    End If
                Else
                    trans.RollbackTransaction()
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", """") & "');", True)
                End If
            Else
                trans.RollbackTransaction()
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", """") & "');", True)
            End If
        Else
            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage.Replace("'", """") & "');", True)
        End If
    End Sub

    Private Function CheckValidPromotion() As Boolean
        Dim ret As Boolean = False
        For i As Integer = 0 To rptPromotionRateHour.Items.Count - 1
            Dim rptPromotionRateHourModel As Repeater = rptPromotionRateHour.Items(i).FindControl("rptPromotionRateHourModel")

            For j As Integer = 0 To rptPromotionRateHourModel.Items.Count - 1
                Dim txtPromotionRate As TextBox = rptPromotionRateHourModel.Items(j).FindControl("txtPromotionRate")
                If txtPromotionRate.Text.Trim <> "" Then
                    Return True
                End If
            Next
        Next
        Return ret
    End Function
    Private Function CheckPromotionDateOverlap(LocationCode As String, MsLocationPromotionID As Long) As Boolean
        Dim ret As Boolean = False
        Dim sql As String = " select lp.id, 1 as g " & Environment.NewLine
        sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=lp.ms_location_id " & Environment.NewLine
        sql += " where l.location_code=@_LOCATION_CODE " & Environment.NewLine
        sql += " and lp.id<>@_LOCATION_PROMOTION_ID " & Environment.NewLine
        sql += " And @_END_DATE between convert(varchar(8),lp.start_date,112) And convert(varchar(8), lp.end_date,112) " & Environment.NewLine
        sql += " union all " & Environment.NewLine
        sql += " Select lp.id, 2 As g " & Environment.NewLine
        sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=lp.ms_location_id " & Environment.NewLine
        sql += " where l.location_code=@_LOCATION_CODE " & Environment.NewLine
        sql += " and lp.id<>@_LOCATION_PROMOTION_ID " & Environment.NewLine
        sql += " and @_START_DATE<=convert(varchar(8),lp.start_date,112)  " & Environment.NewLine
        sql += " And @_END_DATE>=convert(varchar(8), lp.end_date,112) " & Environment.NewLine
        sql += " union all " & Environment.NewLine
        sql += " Select lp.id, 3 As g " & Environment.NewLine
        sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=lp.ms_location_id " & Environment.NewLine
        sql += " where l.location_code=@_LOCATION_CODE " & Environment.NewLine
        sql += " and lp.id<>@_LOCATION_PROMOTION_ID " & Environment.NewLine
        sql += " and @_START_DATE>=convert(varchar(8),lp.start_date,112)  " & Environment.NewLine
        sql += " And @_END_DATE<=convert(varchar(8), lp.end_date,112) " & Environment.NewLine
        sql += " union all " & Environment.NewLine
        sql += " Select lp.id, 4 As g " & Environment.NewLine
        sql += " from MS_LOCATION_PROMOTION lp " & Environment.NewLine
        sql += " inner join MS_LOCATION l on l.id=lp.ms_location_id " & Environment.NewLine
        sql += " where l.location_code=@_LOCATION_CODE " & Environment.NewLine
        sql += " and lp.id<>@_LOCATION_PROMOTION_ID " & Environment.NewLine
        sql += " and @_START_DATE between convert(varchar(8),lp.start_date,112) and convert(varchar(8), lp.end_date,112) " & Environment.NewLine

        Dim vStartDate As String = Converter.ConvertTextToDate(txtPromotionStartDate.Text).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Dim vEndDate As String = Converter.ConvertTextToDate(txtPromotionEndDate.Text).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

        Dim p(4) As SqlParameter
        p(0) = ServerDB.SetText("@_START_DATE", vStartDate)
        p(1) = ServerDB.SetText("@_END_DATE", vEndDate)
        p(3) = ServerDB.SetText("@_LOCATION_CODE", LocationCode)
        p(4) = ServerDB.SetBigInt("@_LOCATION_PROMOTION_ID", MsLocationPromotionID)

        Dim dt As DataTable = ServerDB.ExecuteTable(sql, p)
        If dt.Rows.Count > 0 Then
            ret = True
        End If
        dt.Dispose()

        Return ret

    End Function

    Private Function DeletePromotionData(MsLocationPromotionID As Long, trans As ServerTransactionDB) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            'Delete ข้อมูลเดิมออกก่อน
            Dim sql As String = "delete from MS_LOCATION_PROMOTION_SYNC "
            sql += " where ms_location_promotion_id=@_LOCATION_PROMOTION_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_LOCATION_PROMOTION_ID", MsLocationPromotionID)

            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
            If ret.IsSuccess = True Then
                sql = " delete from MS_LOCATION_PROMOTION_HOUR "
                sql += " where ms_location_promotion_id=@_LOCATION_PROMOTION_ID"
                ReDim p(1)
                p(0) = ServerDB.SetBigInt("@_LOCATION_PROMOTION_ID", MsLocationPromotionID)

                ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)

                If ret.IsSuccess = True Then
                    sql = " delete from MS_LOCATION_PROMOTION where id=@_LOCATION_PROMOTION_ID"
                    ReDim p(1)
                    p(0) = ServerDB.SetBigInt("@_LOCATION_PROMOTION_ID", MsLocationPromotionID)

                    ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
                End If
            End If
        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "DeleteCurrentServiceRate Exception " & ex.Message & ex.StackTrace
        End Try
        Return ret
    End Function

    Private Function SavePromotionData(MsLocationID As Long, trans As ServerTransactionDB) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            If lblPublishStatus.Text = "0" Then
                'ต้องเป็น Promotion ที่ยังไม่ Active เพราะ ถ้าเป็นกรณีที่ Promotion Active จะแก้ไขไม่ได้อยู่แล้ว

                Dim MsLocationPromotionID As Long = lblLocationPromotionID.Text
                ret = DeletePromotionData(MsLocationPromotionID, trans)

                If ret.IsSuccess = True Then
                    'Insert ใหม่เลย
                    Dim lpLnq As New MsLocationPromotionServerLinqDB
                    lpLnq.MS_LOCATION_ID = MsLocationID
                    lpLnq.PROMOTION_CODE = DateTime.Now.ToString("yyyyMMddHHmmss", New Globalization.CultureInfo("en-US"))
                    lpLnq.PROMOTION_NAME = txtPromotionName.Text
                    lpLnq.START_DATE = Converter.ConvertTextToDate(txtPromotionStartDate.Text)
                    lpLnq.END_DATE = Converter.ConvertTextToDate(txtPromotionEndDate.Text)
                    lpLnq.PUBLISH_STATUS = "0"  'Inprogress

                    ret = lpLnq.InsertData(UserName, trans.Trans)
                    If ret.IsSuccess = True Then
                        lblLocationPromotionID.Text = lpLnq.ID
                        For i As Integer = 0 To rptPromotionRateHour.Items.Count - 1
                            Dim lblPromotionRateHour As Label = rptPromotionRateHour.Items(i).FindControl("lblPromotionRateHour")
                            Dim rptPromotionRateHourModel As Repeater = rptPromotionRateHour.Items(i).FindControl("rptPromotionRateHourModel")

                            For j As Integer = 0 To rptPromotionRateHourModel.Items.Count - 1
                                Dim lblPromotionHourCabinetModelID As Label = rptPromotionRateHourModel.Items(j).FindControl("lblPromotionHourCabinetModelID")
                                Dim txtPromotionRate As TextBox = rptPromotionRateHourModel.Items(j).FindControl("txtPromotionRate")

                                Dim lphLnq As New MsLocationPromotionHourServerLinqDB
                                lphLnq.MS_LOCATION_PROMOTION_ID = lpLnq.ID
                                lphLnq.MS_CABINET_MODEL_ID = Convert.ToInt64(lblPromotionHourCabinetModelID.Text)
                                lphLnq.PROMOTION_HOUR = Convert.ToInt16(lblPromotionRateHour.Text)
                                lphLnq.SERVICE_RATE = Convert.ToInt16(txtPromotionRate.Text)

                                ret = lphLnq.InsertData(UserName, trans.Trans)
                                If ret.IsSuccess = False Then
                                    Return ret
                                End If
                            Next
                        Next
                    End If
                End If
            Else
                ret.IsSuccess = True
            End If
        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "DeleteCurrentServiceRate Exception " & ex.Message & ex.StackTrace
        End Try
        Return ret
    End Function

    Private Function SaveServiceRateData(MsLocationID As Long, trans As ServerTransactionDB) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            Dim lnq As New MsServiceRateServerLinqDB
            lnq.ChkDataByMS_LOCATION_ID(MsLocationID, trans.Trans)

            lnq.MS_LOCATION_ID = MsLocationID

            If lnq.ID > 0 Then
                ret = lnq.UpdateData(UserName, trans.Trans)
            Else
                ret = lnq.InsertData(UserName, trans.Trans)
            End If


            If ret.IsSuccess = True Then
                'Insert/Update MS_SERVICE_RATE_DEPOSIT
                For i As Integer = 0 To rptDepositCabinetModel.Items.Count - 1
                    Dim lblDepositCabinetModelID As Label = rptDepositCabinetModel.Items(i).FindControl("lblDepositCabinetModelID")
                    Dim txtDepositRate As TextBox = rptDepositCabinetModel.Items(i).FindControl("txtDepositRate")
                    Dim dLnq As New MsServiceRateDepositServerLinqDB
                    dLnq.ChkDataByMS_CABINET_MODEL_ID_MS_SERVICE_RATE_ID(lblDepositCabinetModelID.Text, lnq.ID, trans.Trans)

                    dLnq.MS_SERVICE_RATE_ID = lnq.ID
                    dLnq.MS_CABINET_MODEL_ID = lblDepositCabinetModelID.Text
                    dLnq.DEPOSIT_RATE = txtDepositRate.Text

                    If dLnq.ID > 0 Then
                        ret = dLnq.UpdateData(UserName, trans.Trans)
                    Else
                        ret = dLnq.InsertData(UserName, trans.Trans)
                    End If

                    If ret.IsSuccess = False Then
                        Return ret
                    End If
                    dLnq = Nothing
                Next

                'Insert/Update MS_SERVICE_RATE_HOUR
                For i As Integer = 0 To rptServiceRateHour.Items.Count - 1
                    Dim lblServiceRateHour As Label = rptServiceRateHour.Items(i).FindControl("lblServiceRateHour")
                    Dim rptRateHourModel As Repeater = rptServiceRateHour.Items(i).FindControl("rptRateHourModel")

                    For j As Integer = 0 To rptRateHourModel.Items.Count - 1
                        Dim lblHourCabinetModelID As Label = rptRateHourModel.Items(j).FindControl("lblHourCabinetModelID")
                        Dim txtServiceRate As TextBox = rptRateHourModel.Items(j).FindControl("txtServiceRate")

                        Dim hLnq As New MsServiceRateHourServerLinqDB
                        hLnq.ChkDataByMS_CABINET_MODEL_ID_MS_SERVICE_RATE_ID_SERVICE_HOUR(lblHourCabinetModelID.Text, lnq.ID, lblServiceRateHour.Text, trans.Trans)

                        hLnq.MS_SERVICE_RATE_ID = lnq.ID
                        hLnq.MS_CABINET_MODEL_ID = lblHourCabinetModelID.Text
                        hLnq.SERVICE_HOUR = lblServiceRateHour.Text
                        hLnq.SERVICE_RATE = txtServiceRate.Text


                        If hLnq.ID > 0 Then
                            ret = hLnq.UpdateData(UserName, trans.Trans)
                        Else
                            ret = hLnq.InsertData(UserName, trans.Trans)
                        End If

                        If ret.IsSuccess = False Then
                            Return ret
                        End If
                        hLnq = Nothing
                    Next
                Next

                'Insert/Update MS_SERVICE_RATE_OVERNIGHT
                For i As Integer = 0 To rptOvernightRate.Items.Count - 1
                    Dim lblOvernightCabinetModelID As Label = rptOvernightRate.Items(i).FindControl("lblOvernightCabinetModelID")
                    Dim txtOvernightRate As TextBox = rptOvernightRate.Items(i).FindControl("txtOvernightRate")

                    Dim oLnq As New MsServiceRateOvernightServerLinqDB
                    oLnq.ChkDataByMS_CABINET_MODEL_ID_MS_SERVICE_RATE_ID(lblOvernightCabinetModelID.Text, lnq.ID, trans.Trans)

                    oLnq.MS_SERVICE_RATE_ID = lnq.ID
                    oLnq.MS_CABINET_MODEL_ID = lblOvernightCabinetModelID.Text
                    oLnq.SERVICE_RATE_DAY = txtOvernightRate.Text

                    If oLnq.ID > 0 Then
                        ret = oLnq.UpdateData(UserName, trans.Trans)
                    Else
                        ret = oLnq.InsertData(UserName, trans.Trans)
                    End If

                    If ret.IsSuccess = False Then
                        Return ret
                    End If
                    oLnq = Nothing
                Next
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "DeleteCurrentServiceRate Exception " & ex.Message & ex.StackTrace
        End Try
        Return ret
    End Function

    Private Function DeleteCurrentServiceRate(MsLocationID As Long, trans As ServerTransactionDB) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            Dim sql As String = "delete from MS_SERVICE_RATE_OVERNIGHT "
            sql += " where ms_service_rate_id in (select id from MS_SERVICE_RATE where ms_location_id=@_LOCATION_ID)"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_LOCATION_ID", MsLocationID)

            ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
            If ret.IsSuccess = True Then

                sql = "delete from MS_SERVICE_RATE_DEPOSIT "
                sql += " where ms_service_rate_id in (select id from MS_SERVICE_RATE where ms_location_id=@_LOCATION_ID)"
                ReDim p(1)
                p(0) = ServerDB.SetBigInt("@_LOCATION_ID", MsLocationID)

                ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
                If ret.IsSuccess = True Then

                    sql = "delete from MS_SERVICE_RATE_HOUR "
                    sql += " where ms_service_rate_id in (select id from MS_SERVICE_RATE where ms_location_id=@_LOCATION_ID)"
                    ReDim p(1)
                    p(0) = ServerDB.SetBigInt("@_LOCATION_ID", MsLocationID)

                    ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
                    If ret.IsSuccess = True Then

                        sql = "delete from MS_SERVICE_RATE where ms_location_id=@_LOCATION_ID"
                        ReDim p(1)
                        p(0) = ServerDB.SetBigInt("@_LOCATION_ID", MsLocationID)

                        ret = ServerDB.ExecuteNonQuery(sql, trans.Trans, p)
                    End If
                End If
            End If
        Catch ex As Exception
            ret = New ExecuteDataInfo
            ret.IsSuccess = False
            ret.ErrorMessage = "DeleteCurrentServiceRate Exception " & ex.Message & ex.StackTrace
        End Try
        Return ret
    End Function

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        BindList()
    End Sub

    Private Sub rptList_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptList.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim td As HtmlTableCell = e.Item.FindControl("td")
        Dim lblLocCode As Label = e.Item.FindControl("lblLocCode")
        Dim lblLocName As Label = e.Item.FindControl("lblLocName")
        Dim lblKiosk As Label = e.Item.FindControl("lblKiosk")

        Dim btnEdit As Button = e.Item.FindControl("btnEdit")
        Dim btnDelete As Button = e.Item.FindControl("btnDelete")
        Dim cfmDelete As AjaxControlToolkit.ConfirmButtonExtender = e.Item.FindControl("cfmDelete")

        Dim ColEdit As HtmlTableCell = e.Item.FindControl("ColEdit")
        Dim ColDelete As HtmlTableCell = e.Item.FindControl("ColDelete")

        lblLocCode.Text = e.Item.DataItem("location_code").ToString
        lblLocName.Text = e.Item.DataItem("location_name").ToString

        If Not e.Item.DataItem("active_status").ToString = "Y" Then
            td.Attributes("class") = "text-danger"
        Else
            td.Attributes("class") = "text-success"
        End If

        lblKiosk.Text = FormatNumber(e.Item.DataItem("Total_Kiosk"), 0)
        btnEdit.CommandArgument = e.Item.DataItem("location_code")
        btnDelete.CommandArgument = e.Item.DataItem("location_code")
        cfmDelete.ConfirmText = "Confirm to delete " & e.Item.DataItem("location_name").ToString & " ?"
    End Sub

    Dim cmDt As DataTable
    Dim hourDt As DataTable

    Dim srdDt As DataTable  'MS_SERVICE_RATE_DEPOSIT
    Dim sroDt As DataTable  'MS_SERVICE_RATE_OVERNIGHT
    Dim srhDt As DataTable  'MS_SERVICE_RATE_HOUR

    Dim lphDt As DataTable  'MS_LOCATION_PROMOTION_HOUR
    Private Sub rptList_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptList.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                ClearEditForm()
                Dim Loc_Code As String = e.CommandArgument
                EditLocationCode = Loc_Code

                Dim DT As DataTable = BL.GetList_Location(Loc_Code)
                If DT.Rows.Count = 0 Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & Loc_Code.Replace("'", """") & " is not found!');", True)
                    Exit Sub
                End If

                txtLocationCode.Text = DT.Rows(0).Item("location_code").ToString
                txtLocationName.Text = DT.Rows(0).Item("location_name").ToString

                'Get Service Rate Information 
                cmDt = getDataCabinetModel()
                hourDt = GetHourList()
                srdDt = GetDataServiceRateDeposit(Convert.ToInt64(DT.Rows(0).Item("ms_service_rate_id")))
                sroDt = GetDataServiceRateOvernight(Convert.ToInt64(DT.Rows(0).Item("ms_service_rate_id")))
                srhDt = GetDataServiceRateHour(Convert.ToInt64(DT.Rows(0).Item("ms_service_rate_id")))

                rptDepositCabinetModel.DataSource = cmDt
                rptDepositCabinetModel.DataBind()

                rptOvernightRate.DataSource = cmDt
                rptOvernightRate.DataBind()

                rptRateHeadModel.DataSource = cmDt
                rptRateHeadModel.DataBind()

                rptServiceRateHour.DataSource = hourDt
                rptServiceRateHour.DataBind()

                'Get Promotion Information
                lphDt = GetDataCurrentPromotion(Convert.ToInt64(DT.Rows(0)("id")))
                If lphDt.Rows.Count > 0 Then
                    FillDataPromotion(lphDt.Rows(0)("id"))
                Else
                    FillDataPromotion(0)
                End If

                'rptPromotionRate.DataSource = cmDt
                'rptPromotionRate.DataBind()

                'rptPromotionRateHour.DataSource = hourDt
                'rptPromotionRateHour.DataBind()

                'txtPromotionCode.Text = ""
                'txtPromotionName.Text = ""
                'txtPromotionStartDate.Text = ""
                'txtPromotionEndDate.Text = ""
                'likPublishPromotion.Visible = False
                'lblIsActivePromotion.Text = "N"

                ''Dim IsCurrentPromotion As Boolean = False
                'If lphDt.Rows.Count > 0 Then
                '    Dim lphDr As DataRow = lphDt.Rows(0)

                '    lblLocationPromotionID.Text = lphDr("id")
                '    txtPromotionCode.Text = lphDr("promotion_code")
                '    txtPromotionName.Text = lphDr("promotion_name")
                '    txtPromotionStartDate.Text = Convert.ToDateTime(lphDr("start_date")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
                '    txtPromotionEndDate.Text = Convert.ToDateTime(lphDr("end_date")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))


                '    likPublishPromotion.Visible = True

                '    'ถ้ามี Promotion ให้ Disable Textbox เกี่ยวกับ Promotion เพื่อไม่ให้แก้ไขข้อมูลได้
                '    'ถ้ามีข้อมูลให้ตรวจสอบ Status = 1 หรือไม่
                '    If lphDr("publish_status") = "1" Then

                '        likPublishPromotion.Visible = False
                '        lblIsActivePromotion.Text = "Y"
                '    End If
                'End If

                'If lblIsActivePromotion.Text = "N" Then
                '    'ถ้ายังไม่มี Promotion ที่ Active ก็เปิดช่องให้สามารถกรอก Promotion ใหม่ได้เลย
                '    txtPromotionName.Enabled = True
                '    txtPromotionStartDate.Enabled = True
                '    txtPromotionEndDate.Enabled = True

                '    For i As Integer = 0 To rptPromotionRateHour.Items.Count - 1
                '        Dim rptPromotionRateHourModel As Repeater = rptPromotionRateHour.Items(i).FindControl("rptPromotionRateHourModel")

                '        For j As Integer = 0 To rptPromotionRateHourModel.Items.Count - 1
                '            Dim txtPromotionRate As TextBox = rptPromotionRateHourModel.Items(j).FindControl("txtPromotionRate")
                '            txtPromotionRate.Enabled = True
                '        Next
                '    Next
                'End If

                ''Set Repeater Promotion History
                rptPromotionHis.DataSource = GetDataLocationPromotion(Convert.ToInt64(DT.Rows(0)("id")))
                rptPromotionHis.DataBind()


                chkActive.Checked = IIf(DT.Rows(0).Item("active_status").ToString() = "Y", True, False)
                lblEditMode.Text = "Edit"

                pnlList.Visible = False
                pnlEdit.Visible = True

                CurrentTab = Tab.ServiceRate


#Region "ตรวจสอบสิทธิ์การแก้ไขข้อมูล"
                'ตรวจสอบสิทธิ์การแก้ไขข้อมูล
                Dim ufDt As DataTable = DirectCast(Session("List_User_Functional"), DataTable)
                If ufDt Is Nothing Then
                    Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl)
                End If
                If ufDt.Rows.Count > 0 Then
                    Dim auDt As DataTable = BL.GetList_User_Functional(2, FunctionalZoneID, FunctionalID, Session("Username"))
                    If auDt.Rows.Count = 0 Then
                        txtLocationCode.Enabled = False
                        txtLocationName.Enabled = False

                        'Disable Deposit Data
                        For i As Integer = 0 To rptDepositCabinetModel.Items.Count - 1
                            Dim txtDepositRate As TextBox = rptDepositCabinetModel.Items(i).FindControl("txtDepositRate")
                            txtDepositRate.Enabled = False
                        Next

                        'Disable Service Rate Data
                        For i As Integer = 0 To rptServiceRateHour.Items.Count - 1
                            Dim rptRateHourModel As Repeater = rptServiceRateHour.Items(i).FindControl("rptRateHourModel")

                            For j As Integer = 0 To rptRateHourModel.Items.Count - 1
                                Dim txtServiceRate As TextBox = rptRateHourModel.Items(j).FindControl("txtServiceRate")
                                txtServiceRate.Enabled = False
                            Next
                        Next

                        'Disable Overnight Rate
                        For i As Integer = 0 To rptOvernightRate.Items.Count - 1
                            Dim txtOvernightRate As TextBox = rptOvernightRate.Items(i).FindControl("txtOvernightRate")
                            txtOvernightRate.Enabled = False
                        Next

                        chkActive.Enabled = False
                        btnSave.Visible = False
                    End If
                    auDt.Dispose()
                End If
                ufDt.Dispose()
#End Region
            Case "Delete"
                Dim ret As String = BL.DeleteMasterLocation(e.CommandArgument)
                If ret = "" Then
                    BindList()
                Else
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.Replace("'", """") & " is not found!');", True)
                End If

        End Select
    End Sub

#Region "Service Rate Data"
    Private Function getDataCabinetModel() As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select id, model_name "
            sql += " from MS_CABINET_MODEL cm "
            sql += " where active_status='Y'"
            sql += " order by id"
            ret = ServerDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    Private Function GetDataServiceRateDeposit(MsServiceRateID As Long) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select ms_cabinet_model_id, deposit_rate"
            sql += " from MS_SERVICE_RATE_DEPOSIT "
            sql += " where ms_service_rate_id=@_SERVICE_RATE_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_SERVICE_RATE_ID", MsServiceRateID)

            ret = ServerDB.ExecuteTable(sql, p)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    Private Function GetDataServiceRateOvernight(MsServiceRateID As Long) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select ms_cabinet_model_id, service_rate_day "
            sql += " from MS_SERVICE_RATE_OVERNIGHT "
            sql += " where ms_service_rate_id=@_SERVICE_RATE_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_SERVICE_RATE_ID", MsServiceRateID)

            ret = ServerDB.ExecuteTable(sql, p)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    Private Function GetDataServiceRateHour(MsServiceRateID As Long) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select ms_cabinet_model_id, service_hour, service_rate "
            sql += " from MS_SERVICE_RATE_HOUR "
            sql += " where ms_service_rate_id=@_SERVICE_RATE_ID"
            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_SERVICE_RATE_ID", MsServiceRateID)

            ret = ServerDB.ExecuteTable(sql, p)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Private Sub rptDepositCabinetModel_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptDepositCabinetModel.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblDepositCabinetModelID As Label = e.Item.FindControl("lblDepositCabinetModelID")
        Dim lblDepositCabinetModelName As Label = e.Item.FindControl("lblDepositCabinetModelName")
        Dim txtDepositRate As TextBox = e.Item.FindControl("txtDepositRate")

        lblDepositCabinetModelID.Text = e.Item.DataItem("id")
        lblDepositCabinetModelName.Text = e.Item.DataItem("model_name")

        If srdDt.Rows.Count > 0 Then
            srdDt.DefaultView.RowFilter = "ms_cabinet_model_id='" & lblDepositCabinetModelID.Text & "'"
            If srdDt.DefaultView.Count > 0 Then
                txtDepositRate.Text = srdDt.DefaultView(0)("deposit_rate")
            End If
            srdDt.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub rptOvernightRate_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptOvernightRate.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblOvernightCabinetModelID As Label = e.Item.FindControl("lblOvernightCabinetModelID")
        Dim lblOvernightCabinetModelName As Label = e.Item.FindControl("lblOvernightCabinetModelName")
        Dim txtOvernightRate As TextBox = e.Item.FindControl("txtOvernightRate")

        lblOvernightCabinetModelID.Text = e.Item.DataItem("id")
        lblOvernightCabinetModelName.Text = e.Item.DataItem("model_name")

        If sroDt.Rows.Count > 0 Then
            sroDt.DefaultView.RowFilter = "ms_cabinet_model_id='" & lblOvernightCabinetModelID.Text & "'"
            If sroDt.DefaultView.Count > 0 Then
                txtOvernightRate.Text = sroDt.DefaultView(0)("service_rate_day")
            End If
            sroDt.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub rptRateHeadModel_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptRateHeadModel.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblRateHeadModelName As Label = e.Item.FindControl("lblRateHeadModelName")
        lblRateHeadModelName.Text = e.Item.DataItem("model_name")
    End Sub

    Private Function GetHourList() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("HOUR")

        For i As Integer = 1 To 24
            Dim dr As DataRow = dt.NewRow
            dr("HOUR") = i
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Private Sub rptServiceRateHour_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptServiceRateHour.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblServiceRateHour As Label = e.Item.FindControl("lblServiceRateHour")
        Dim rptRateHourModel As Repeater = e.Item.FindControl("rptRateHourModel")
        AddHandler rptRateHourModel.ItemDataBound, AddressOf rptRateHourModel_ItemDataBound

        lblServiceRateHour.Text = e.Item.DataItem("HOUR")
        rptRateHourModel.DataSource = cmDt
        rptRateHourModel.DataBind()
    End Sub

    Private Sub rptRateHourModel_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblServiceRateHour As Label = e.Item.Parent.Parent.FindControl("lblServiceRateHour")
        Dim lblHourCabinetModelID As Label = e.Item.FindControl("lblHourCabinetModelID")
        Dim txtServiceRate As TextBox = e.Item.FindControl("txtServiceRate")

        lblHourCabinetModelID.Text = e.Item.DataItem("id")
        If srhDt.Rows.Count > 0 Then
            srhDt.DefaultView.RowFilter = "service_hour='" & lblServiceRateHour.Text & "' and ms_cabinet_model_id='" & lblHourCabinetModelID.Text & "'"
            If srhDt.DefaultView.Count > 0 Then
                txtServiceRate.Text = srhDt.DefaultView(0)("service_rate")
            End If
            srhDt.DefaultView.RowFilter = ""
        End If
    End Sub
#End Region


#Region "Promotion Data"
    Private Sub rptPromotionRate_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptPromotionRate.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblPromotionRateHeadModelName As Label = e.Item.FindControl("lblPromotionRateHeadModelName")
        lblPromotionRateHeadModelName.Text = e.Item.DataItem("model_name")
    End Sub

    Private Sub rptPromotionRateHour_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptPromotionRateHour.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblPromotionRateHour As Label = e.Item.FindControl("lblPromotionRateHour")
        Dim rptPromotionRateHourModel As Repeater = e.Item.FindControl("rptPromotionRateHourModel")
        AddHandler rptPromotionRateHourModel.ItemDataBound, AddressOf rptPromotionRateHourModel_ItemDataBound

        lblPromotionRateHour.Text = e.Item.DataItem("HOUR")
        rptPromotionRateHourModel.DataSource = cmDt
        rptPromotionRateHourModel.DataBind()
    End Sub

    Private Sub rptPromotionRateHourModel_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblPromotionRateHour As Label = e.Item.Parent.Parent.FindControl("lblPromotionRateHour")
        Dim lblPromotionHourCabinetModelID As Label = e.Item.FindControl("lblPromotionHourCabinetModelID")
        Dim txtPromotionRate As TextBox = e.Item.FindControl("txtPromotionRate")

        lblPromotionHourCabinetModelID.Text = e.Item.DataItem("id")
        If lphDt.Rows.Count > 0 Then
            lphDt.DefaultView.RowFilter = "ms_cabinet_model_id='" & lblPromotionHourCabinetModelID.Text & "' and promotion_hour='" & lblPromotionRateHour.Text & "'"
            If lphDt.DefaultView.Count > 0 Then
                txtPromotionRate.Text = lphDt.DefaultView(0)("service_rate")
            End If
            lphDt.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub rptPromotionHis_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptPromotionHis.ItemDataBound
        If e.Item.ItemType <> ListItemType.Item And e.Item.ItemType <> ListItemType.AlternatingItem Then Exit Sub

        Dim lblPromotionCode As Label = e.Item.FindControl("lblPromotionCode")
        Dim lblPromotionName As Label = e.Item.FindControl("lblPromotionName")
        Dim lblPromotionPeriod As Label = e.Item.FindControl("lblPromotionPeriod")
        Dim btnPromotionEdit As Button = e.Item.FindControl("btnPromotionEdit")
        Dim btnPromotionPublish As Button = e.Item.FindControl("btnPromotionPublish")
        Dim btnPromotionDelete As Button = e.Item.FindControl("btnPromotionDelete")
        Dim pTr As HtmlTableRow = e.Item.FindControl("pTr")

        Dim vStartDate As String = Convert.ToDateTime(e.Item.DataItem("start_date")).ToString("d MMM yyyy", New Globalization.CultureInfo("en-US"))
        Dim vEndDate As String = Convert.ToDateTime(e.Item.DataItem("end_date")).ToString("d MMM yyyy", New Globalization.CultureInfo("en-US"))

        lblPromotionCode.Text = e.Item.DataItem("promotion_code")
        lblPromotionName.Text = e.Item.DataItem("promotion_name")
        lblPromotionPeriod.Text = vStartDate & " - " & vEndDate

        If e.Item.DataItem("publish_status").ToString = "1" Then
            'Publish
            pTr.Attributes("class") = "text-primary"

            btnPromotionEdit.Text = "View"
            btnPromotionPublish.Visible = False
            btnPromotionDelete.Visible = False
        ElseIf e.Item.DataItem("publish_status").ToString = "2" Then
            'Expired
            pTr.Attributes("class") = "text-danger"

            btnPromotionEdit.Text = "View"
            btnPromotionPublish.Visible = False
            btnPromotionDelete.Visible = False
        End If

        Dim cfmPromotionDelete As AjaxControlToolkit.ConfirmButtonExtender = e.Item.FindControl("cfmPromotionDelete")
        cfmPromotionDelete.ConfirmText = "Confirm to delete " & e.Item.DataItem("promotion_name").ToString & " ?"
    End Sub



    Private Sub rptPromotionHis_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptPromotionHis.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                Dim MsLocationPromotionID As Long = e.CommandArgument

                cmDt = getDataCabinetModel()
                hourDt = GetHourList()
                lphDt = GetDataPromotion(MsLocationPromotionID)

                FillDataPromotion(MsLocationPromotionID)

            Case "Publish"
                Dim MsLocationPromotionID As Long = e.CommandArgument
                Dim ret As ExecuteDataInfo = SetPublishPromotion(MsLocationPromotionID)
                If ret.IsSuccess = True Then
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Publish Promotion Success');", True)
                    BindList()
                Else
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
                End If
            Case "Delete"
                Dim MsLocationPromotionID As Long = e.CommandArgument
                Dim trans As New ServerTransactionDB
                Dim ret As ExecuteDataInfo = DeletePromotionData(MsLocationPromotionID, trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()

                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Delete Promotion Success');", True)
                    BindList()
                Else
                    trans.RollbackTransaction()
                    ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
                End If
        End Select
    End Sub

    Private Sub FillDataPromotion(MsLocationPromotionID As Long)
        'Get Promotion Information
        rptPromotionRate.DataSource = cmDt
        rptPromotionRate.DataBind()

        rptPromotionRateHour.DataSource = hourDt
        rptPromotionRateHour.DataBind()

        txtPromotionName.Enabled = False
        txtPromotionStartDate.Enabled = False
        txtPromotionEndDate.Enabled = False

        lblLocationPromotionID.Text = "0"
        txtPromotionCode.Text = ""
        txtPromotionName.Text = ""
        txtPromotionStartDate.Text = ""
        txtPromotionEndDate.Text = ""
        likPublishPromotion.Visible = False
        lblPublishStatus.Text = "0"

        'Dim IsCurrentPromotion As Boolean = False
        If lphDt.Rows.Count > 0 Then
            Dim lphDr As DataRow = lphDt.Rows(0)

            lblLocationPromotionID.Text = lphDr("id")
            txtPromotionCode.Text = lphDr("promotion_code")
            txtPromotionName.Text = lphDr("promotion_name")
            txtPromotionStartDate.Text = Convert.ToDateTime(lphDr("start_date")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            txtPromotionEndDate.Text = Convert.ToDateTime(lphDr("end_date")).ToString("MMM dd yyyy", New Globalization.CultureInfo("en-US"))
            lblPublishStatus.Text = lphDr("publish_status")

            'ถ้ามี Promotion ให้ Disable Textbox เกี่ยวกับ Promotion เพื่อไม่ให้แก้ไขข้อมูลได้
            'ถ้ามีข้อมูลให้ตรวจสอบ Status = 1 หรือไม่
            If lphDr("publish_status") = "1" Then
                likPublishPromotion.Visible = False
            ElseIf lphDr("publish_status") = "0" Then
                'Inprogress
                likPublishPromotion.Visible = True
            Else
                likPublishPromotion.Visible = False
            End If
            pnlPromotionDetail.Visible = True
        ElseIf MsLocationPromotionID = 0 Then
            pnlPromotionDetail.Visible = True
        Else
            pnlPromotionDetail.Visible = False
        End If

        If lblPublishStatus.Text = "0" Then
            'ถ้ายังไม่มี Promotion ที่ Active ก็เปิดช่องให้สามารถกรอก Promotion ใหม่ได้เลย
            txtPromotionName.Enabled = True
            txtPromotionStartDate.Enabled = True
            txtPromotionEndDate.Enabled = True

            For i As Integer = 0 To rptPromotionRateHour.Items.Count - 1
                Dim rptPromotionRateHourModel As Repeater = rptPromotionRateHour.Items(i).FindControl("rptPromotionRateHourModel")

                For j As Integer = 0 To rptPromotionRateHourModel.Items.Count - 1
                    Dim txtPromotionRate As TextBox = rptPromotionRateHourModel.Items(j).FindControl("txtPromotionRate")
                    txtPromotionRate.Enabled = True
                Next
            Next
        End If
    End Sub

    Private Function SetPublishPromotion(MsLocationPromotionID As Long) As ExecuteDataInfo
        Dim ret As New ExecuteDataInfo
        Try
            If CheckPromotionDateOverlap(EditLocationCode, MsLocationPromotionID) = True Then
                ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Promotion period date is overlap');", True)
                Return New ExecuteDataInfo
            End If

            Dim lnq As New MsLocationPromotionServerLinqDB
            lnq.GetDataByPK(MsLocationPromotionID, Nothing)
            If lnq.ID > 0 Then
                lnq.PUBLISH_STATUS = "1"

                Dim trans As New ServerTransactionDB
                ret = lnq.UpdateData(UserName, trans.Trans)
                If ret.IsSuccess = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            ret.IsSuccess = False
            ret.ErrorMessage = "Exception " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    Private Function GetDataPromotion(MsLocationPromotionID As Long) As DataTable
        Dim dt As New DataTable
        Try
            'จะต้องหาก่อนว่า Current Promotion ของ MsLocationID นี้คือ Promotion ไหน
            Dim vCurrDate As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim sql As String = "select  lp.id, lp.promotion_code, lp.promotion_name, lp.start_date, lp.end_date, lp.publish_status, "
            sql += " lph.ms_cabinet_model_id, lph.promotion_hour, lph.service_rate"
            sql += " from MS_LOCATION_PROMOTION lp"
            sql += " inner join MS_LOCATION_PROMOTION_HOUR lph on lp.id=lph.ms_location_promotion_id"
            sql += " where lp.id=@_PROMOTION_LOCATION_ID"


            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_PROMOTION_LOCATION_ID", MsLocationPromotionID)

            dt = ServerDB.ExecuteTable(sql, p)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Private Function GetDataCurrentPromotion(MsLocationID As Long) As DataTable
        Dim dt As New DataTable
        Try
            'จะต้องหาก่อนว่า Current Promotion ของ MsLocationID นี้คือ Promotion ไหน
            Dim vCurrDate As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim sql As String = "select  lp.id, lp.promotion_code, lp.promotion_name, lp.start_date, lp.end_date, lp.publish_status, "
            sql += " lph.ms_cabinet_model_id, lph.promotion_hour, lph.service_rate"
            sql += " from MS_LOCATION_PROMOTION lp"
            sql += " inner join MS_LOCATION_PROMOTION_HOUR lph on lp.id=lph.ms_location_promotion_id"
            sql += " where lp.ms_location_id=@_MS_LOCATION_ID"
            sql += " and @_CURR_DATE between convert(varchar(8),lp.start_date,112) and convert(varchar(8), lp.end_date,112)"


            Dim p(2) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_MS_LOCATION_ID", MsLocationID)
            p(1) = ServerDB.SetText("@_CURR_DATE", vCurrDate)

            dt = ServerDB.ExecuteTable(sql, p)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Private Function GetDataLocationPromotion(MsLocationID As Long) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select  lp.id, lp.promotion_code, lp.promotion_name, lp.start_date, lp.end_date, lp.publish_status "
            sql += " from MS_LOCATION_PROMOTION lp"
            sql += " where lp.ms_location_id=@_MS_LOCATION_ID"
            sql += " order by lp.publish_status, lp.start_date"

            Dim p(1) As SqlParameter
            p(0) = ServerDB.SetBigInt("@_MS_LOCATION_ID", MsLocationID)

            dt = ServerDB.ExecuteTable(sql, p)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

#End Region

#Region "Tab"
    Protected Enum Tab
        Unknown = 0
        ServiceRate = 1
        Promotion = 2
    End Enum

    Protected Property CurrentTab As Tab
        Get
            Select Case True
                Case tabServiceRate.Visible
                    Return Tab.ServiceRate
                Case tabPromotion.Visible
                    Return Tab.Promotion
                Case Else
                    Return Tab.Unknown
            End Select
        End Get
        Set(value As Tab)
            tabServiceRate.Visible = False
            tabPromotion.Visible = False
            liTabServiceRate.Attributes("class") = ""
            liTabPromotion.Attributes("class") = ""

            Select Case value
                Case Tab.ServiceRate
                    tabServiceRate.Visible = True
                    liTabServiceRate.Attributes("class") = "active"
                Case Tab.Promotion
                    tabPromotion.Visible = True
                    liTabPromotion.Attributes("class") = "active"
                Case Else
            End Select
        End Set
    End Property

    Private Sub ChangeTab(sender As Object, e As System.EventArgs) Handles btnTabServiceRate.Click, btnTabPromotion.Click
        Select Case True
            Case Equals(sender, btnTabServiceRate)
                CurrentTab = Tab.ServiceRate
            Case Equals(sender, btnTabPromotion)
                CurrentTab = Tab.Promotion
        End Select
    End Sub

    Private Sub likPublishPromotion_Click(sender As Object, e As EventArgs) Handles likPublishPromotion.Click
        Dim ret As ExecuteDataInfo = SetPublishPromotion(lblLocationPromotionID.Text)
        If ret.IsSuccess = True Then
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('Publish Promotion Success');", True)
            BindList()
        Else
            ScriptManager.RegisterStartupScript(Me.Page, GetType(String), "Alert", "alert('" & ret.ErrorMessage & "');", True)
        End If
    End Sub
#End Region
End Class