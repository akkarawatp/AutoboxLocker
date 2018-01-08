Imports System
Imports System.Management
Imports Microsoft.Win32
Imports KioskLinqDB.ConnectDB
Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common
Imports System.IO

Public Class frmSplashScreen
    Dim CurrentStep As Int16 = 0

    Private Sub frmSplashScreen_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
        txtCPUID.Text = GetCPU_ID()
        txtProcessorID.Text = GetProcessorId()

        Dim IdenKey As String = KioskDB.EnCripPwd(txtCPUID.Text & txtProcessorID.Text)
        Dim reg As New ModifyMachineKey
        reg.ShowError = True

        Dim MachingKey As String = reg.Read()
        If String.IsNullOrEmpty(MachingKey) = True Then
            'ถ้าไม่เคยมีการ Gen Key ให้เริ่มขั้นตอนการ Gen ใหม่
            lblReadingKey.Text = IdenKey
            StartNewMachineKey()
        Else
            'ถ้ามีการ Gen Key มาแล้ว ให้ตรวจสอบว่า Key ที่เก็บไว้ตรงกับ Key ที่ Gen หรือไม่
            lblReadingKey.Text = reg.Read()
            If IdenKey <> lblReadingKey.Text Then
                'ถ้า Key ไม่ตรงกัน ก็ให้ Gen ใหม่โลด
                btnDeleteKey_Click(Nothing, Nothing)
                StartNewMachineKey()
            Else
                If reg.ReadInfoKioskID() <> 0 Then
                    'ถ้า Key ตรงกัน ให้เข้าโปรแกรมได้
                    frmMain.Show()
                    Me.Close()
                    Application.DoEvents()
                Else
                    'ถ้าไม่มี Locker Info ให้ลบออกก่อน เพื่อให้เริ่ม Setup ใหม่
                    btnDeleteKey_Click(Nothing, Nothing)
                    StartNewMachineKey()
                End If
            End If
        End If

        reg = Nothing
    End Sub

    Private Sub StartNewMachineKey()
        Me.Visible = True
        'Me.WindowState = FormWindowState.Normal
        SetDDLLockerList()

        CurrentStep = 1
        pnlDBLogin.Show()
    End Sub

    Private Sub SetDDLLockerList()
        Dim ws As New Webservice_Locker.ATBLockerWebService
        Dim dt As DataTable = ws.GetLockerUnRegister(Environment.MachineName)
        If dt Is Nothing Then
            dt.Columns.Add("id", GetType(Long))
            dt.Columns.Add("com_name")
        End If

        Dim dr As DataRow = dt.NewRow
        dr("id") = 0
        dr("com_name") = ""
        dt.Rows.InsertAt(dr, 0)

        cbUnRegisLocker.ValueMember = "id"
        cbUnRegisLocker.DisplayMember = "com_name"
        cbUnRegisLocker.DataSource = dt
    End Sub

    Private Function ValidateData() As Boolean
        Dim ret As Boolean = True
        If cbUnRegisLocker.SelectedValue = 0 Then
            MessageBox.Show("กรุณาเลือก Locker", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Dim LanDesc As String = GetCardLanDesc()
        If LanDesc.Trim = "" Then
            MessageBox.Show("กรุณาระบุ Card Lan", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return ret
    End Function

    Private Sub ActionStep1()
        If ValidateData() = False Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim LanDesc As String = GetCardLanDesc()
        Dim IpAddress As String = ""
        Dim MacAddress As String = ""

        SetProgressStatus("Generate Machine Key")
        Dim IdenKey As String = KioskDB.EnCripPwd(txtCPUID.Text & txtProcessorID.Text)
        Dim reg As New ModifyMachineKey
        reg.ShowError = True
        If reg.Write(IdenKey) = True Then
            SetProgressStatus("Open Database")
            'Login Database With sa Password
            Dim conn As SqlConnection = ConnectDB("sa", txtDBPassword.Text)
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                'MessageBox.Show("Open Database Connect")
                AddHandler conn.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnExecuteInfoMessage)

                If Directory.Exists("C:\DbData\Minibox") = False Then
                    Directory.CreateDirectory("C:\DbData\Minibox")
                End If
                SetProgressStatus("Create Login Autobox")
                Dim DbScriptPath As String = Application.StartupPath & "\DbScript\"
                RunDBScriptFile(conn, DbScriptPath & "01_CreateLoginAutobox.sql")

                SetProgressStatus("Create Database Minibox")
                RunDBScriptFile(conn, DbScriptPath & "02_CreateMiniboxDB.sql")

                conn.ChangeDatabase("Minibox")
                RunDBScriptFile(conn, DbScriptPath & "03_CreateDatabaseObject.sql")

                conn.Close()
                SqlConnection.ClearAllPools()

                SetProgressStatus("ค้นหาอุปกรณ์ Network")
                Try
                    'Network Information
                    Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
                    Dim moc As ManagementObjectCollection = mc.GetInstances()

                    For Each mo As ManagementObject In moc
                        If CStr(mo("Description")).Trim = LanDesc Then
                            If mo("IPEnabled") = True Then
                                IpAddress = mo("IPAddress")(0)
                                MacAddress = mo("MacAddress").ToString().Replace(":", "-")

                                SetProgressStatus("พบอุปกรณ์ Network IP " & IpAddress & "  Mac Address " & MacAddress)
                                Exit For
                            Else
                                SetProgressStatus("Cannot found Network Device " + LanDesc)
                            End If
                        End If
                        mo.Dispose()
                    Next
                Catch ex As Exception
                    SetProgressStatus("Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If IpAddress <> "" And MacAddress <> "" Then
                    SetProgressStatus("Register Machine Key...")
                    Dim ws As New Webservice_Locker.ATBLockerWebService
                    Dim ret As New Webservice_Locker.UpdateMachineKeyInfo
                    ret = ws.UpdateLockerMachineKey(cbUnRegisLocker.SelectedValue, Environment.MachineName, IpAddress, MacAddress, lblReadingKey.Text)
                    If ret.IsSuccess = True Then

                        SetProgressStatus("Update Machine Information")
                        Dim mmk As New ModifyMachineKey
                        If mmk.WriteInfo(ret.KioskID, Environment.MachineName, ret.IpAddress, ret.MacAddress, ret.LocationCode, ret.LocationName) = True Then
                            'Insert Locker CF_KIOSK_SYSCONFIG
                            Dim cfLnq As New KioskLinqDB.TABLE.CfKioskSysconfigKioskLinqDB
                            cfLnq.MS_KIOSK_ID = ret.KioskID
                            cfLnq.MAC_ADDRESS = ret.MacAddress
                            cfLnq.IP_ADDRESS = ret.IpAddress
                            cfLnq.LOCATION_CODE = ret.LocationCode
                            cfLnq.LOCATION_NAME = ret.LocationName

                            With ret.KioskSysconfig
                                cfLnq.LOGIN_SSO = .LOGIN_SSO
                                cfLnq.KIOSK_OPEN24 = .KIOSK_OPEN24
                                cfLnq.SCREEN_SAVER_SEC = .SCREEN_SAVER_SEC
                                cfLnq.TIME_OUT_SEC = .TIME_OUT_SEC
                                cfLnq.SHOW_MSG_SEC = .SHOW_MSG_SEC
                                cfLnq.PAYMENT_EXTEND_SEC = .PAYMENT_EXTEND_SEC
                                cfLnq.PINCODE_LEN = .PINCODE_LEN
                                cfLnq.LOCKER_WEBSERVICE_URL = .LOCKER_WEBSERVICE_URL
                                cfLnq.LOCKER_PC_POSITION = .LOCKER_PC_POSITION
                                cfLnq.SLEEP_TIME = .SLEEP_TIME
                                cfLnq.SLEEP_DURATION = .SLEEP_DURATION
                                cfLnq.CONTACT_CENTER_TELNO = .CONTACT_CENTER_TELNO
                                cfLnq.ALARM_WEBSERVICE_URL = .ALARM_WEBSERVICE_URL
                                cfLnq.INTERVAL_SYNC_TRANSACTION_MIN = .INTERVAL_SYNC_TRANSACTION_MIN
                                cfLnq.INTERVAL_SYNC_MASTER_MIN = .INTERVAL_SYNC_MASTER_MIN
                                cfLnq.INTERVAL_SYNC_LOG_MIN = .INTERVAL_SYNC_LOG_MIN
                                cfLnq.SYNC_TO_SERVER = "Y"
                                cfLnq.SYNC_TO_KIOSK = "Y"
                                cfLnq.MACHINE_KEY = lblReadingKey.Text
                            End With

                            Dim trans As New KioskTransactionDB
                            Dim re As ExecuteDataInfo = cfLnq.InsertData(Environment.MachineName, trans.Trans)
                            If re.IsSuccess = True Then
                                trans.CommitTransaction()

                                SetProgressStatus("กำลังดาวน์โหลดข้อมูลตั้งต้น กรุณารอสักครู่...")
                                Engine.SyncMasterDataENG.SyncAllKioskMaster(ret.KioskID)

                                SetProgressStatus("ดาวน์โหลดข้อมูลสำเร็จ คลิกปุ่ม OK เพื่อเข้าสู่โปรแกรม")

                                btnNext.Text = "OK"
                                Application.DoEvents()
                                CurrentStep = 2
                            Else
                                trans.RollbackTransaction()
                                MessageBox.Show(re.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                        mmk = Nothing
                    End If
                    ws.Dispose()
                End If
            End If
        Else
            SetProgressStatus("Generate Fail")
            MessageBox.Show("Generate Machine Key Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Check Internet Connection
        Dim ws As New Webservice_Locker.ATBLockerWebService
        Dim ret As Webservice_Locker.CheckConnectionData = ws.CheckWebserviceConnection()
        If ret.IsSuccess = True Then
            If CurrentStep = 1 Then
                ActionStep1()
            ElseIf CurrentStep = 2 Then
                frmMain.Show()
                Me.Close()
            End If
        Else
            MessageBox.Show(ret.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        ws.Dispose()
        ret = Nothing
    End Sub

    Private Sub OnExecuteInfoMessage(ByVal sender As Object, ByVal args As SqlInfoMessageEventArgs)
        Dim sqlEvent As SqlError
        For Each sqlEvent In args.Errors
            'Events.FireInformation(sqlEvent.Number, sqlEvent.Procedure, sqlEvent.Message, "", 0, False)
            txtProgressStatus.Text += sqlEvent.Message & vbNewLine
            Application.DoEvents()
        Next
    End Sub

    Private Sub RunDBScriptFile(conn As SqlConnection, ScriptFile As String)
        If File.Exists(ScriptFile) = True Then
            Try
                Dim server As New Server(New ServerConnection(conn))
                server.ConnectionContext.ExecuteNonQuery(File.ReadAllText(ScriptFile))
            Catch ex As Exception
                SetProgressStatus(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ExecuteNonQuery(conn As SqlConnection, sql As String)
        If conn.State = ConnectionState.Open Then
            Dim cmd As New SqlCommand
            Try
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 300
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Connection Not Open")
        End If

    End Sub


    Private Sub SetProgressStatus(txt As String)
        txtProgressStatus.Text += txt & vbNewLine
        Application.DoEvents()
    End Sub

    Private Function ConnectDB(UserID As String, pssWd As String) As SqlConnection
        Dim connStr As String = "Data Source=localhost;Integrated Security=False;Persist Security Info=True;"
        Dim ret As Boolean = True

        Try
            Dim conn As SqlConnection
            Dim pwd As New Security.SecureString()
            For Each ch As Char In pssWd
                pwd.AppendChar(ch)
            Next
            pwd.MakeReadOnly()
            Dim cred As New SqlCredential(UserID, pwd)

            conn = New SqlConnection(connStr, cred)
            conn.Open()
            Return conn
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing
    End Function

    Public Function GetCPU_ID() As String

        Dim cpuID As String = String.Empty
        Dim mc As ManagementClass = New ManagementClass("Win32_Processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo As ManagementObject In moc
            cpuID += mo.Qualifiers.Item("UUID").Value
        Next
        Return cpuID
    End Function

    Private Function GetProcessorId() As String
        Dim strProcessorId As String = ""
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strProcessorId = info("processorId").ToString()
        Next
        Return strProcessorId
    End Function

    Private Function ProcessorName() As String
        Dim ret As String = ""
        ' shows the processor name and speed of the computer
        Dim MyOBJ As Object
        Dim cpu As Object
        MyOBJ = GetObject("WinMgmts:").instancesof("Win32_Processor")
        For Each cpu In MyOBJ
            ret += cpu.Name.ToString + " " + cpu.CurrentClockSpeed.ToString + " Mhz"
        Next
        Return ret
    End Function

    Private Shared Function GetMotherBoardID() As String
        Dim strMotherBoardID As String = ""
        Dim query As New SelectQuery("Win32_BaseBoard")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strMotherBoardID = info("SerialNumber").ToString()
        Next
        Return strMotherBoardID
    End Function

    Private Sub btnDeleteKey_Click(sender As Object, e As EventArgs) Handles btnDeleteKey.Click
        Dim conn As SqlConnection = ConnectDB("sa", "1qaz@WSX")
        conn.ChangeDatabase("master")

        ExecuteNonQuery(conn, "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'Minibox'")
        ExecuteNonQuery(conn, "ALTER DATABASE [Minibox] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE")
        ExecuteNonQuery(conn, "DROP DATABASE [Minibox]")

        ExecuteNonQuery(conn, "DROP LOGIN [autobox]")

        conn.Close()
        SqlConnection.ClearAllPools()


        Dim reg As New ModifyMachineKey
        reg.ShowError = True
        Dim KioskID As Long = reg.ReadInfoKioskID()

        reg.DeleteKey()
        reg.DeleteInfoSection()
        If KioskID > 0 Then
            Dim ws As New Webservice_Locker.ATBLockerWebService
            If ws.ClearLockerMachineKey(reg.ReadInfoKioskID(), Environment.MachineName) <> "true" Then
                MessageBox.Show("Error Clear Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Delete Success")
            End If
            ws.Dispose()
        Else
            MessageBox.Show("Delete Success")
        End If
        reg = Nothing
    End Sub


End Class