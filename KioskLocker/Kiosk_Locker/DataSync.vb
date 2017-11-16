Imports System.Data
Imports System.Data.SqlClient
Public Class DataSync

    'Dim DBService As New ServerDBService.ServerDBService
    'Dim DataProvider As New ServerDataProvider.ServerDataProvider

#Region "Public Method"
    Dim Last_Error As String = ""


    Public Function RunSyncByKoisk(ByVal KO_ID As Integer, ByVal KioskConnectionString As String) As Boolean
        'Dim tb_Koisk_Sync_Job As DataTable = DataProvider.tb_Koisk_Sync_Job(0, KO_ID)
        'Dim tb_Kiosk As DataTable = DataProvider.tb_Kiosk(0)

        'For i As Integer = 0 To tb_Koisk_Sync_Job.Rows.Count - 1
        '    Dim JOB_ID As Integer = tb_Koisk_Sync_Job.Rows(i).Item("Job_ID")
        '    KO_ID = tb_Koisk_Sync_Job.Rows(i).Item("KO_ID")
        '    Dim Command_Type_ID As Sync_Command_Type = tb_Koisk_Sync_Job.Rows(i).Item("Command_Type_ID")
        '    Dim Command_Detail As String = tb_Koisk_Sync_Job.Rows(i).Item("Command_Detail").ToString
        '    Dim Command_Condition As String = tb_Koisk_Sync_Job.Rows(i).Item("Command_Condition").ToString

        '    tb_Kiosk.DefaultView.RowFilter = "KO_ID=" & KO_ID
        '    If tb_Kiosk.DefaultView.Count = 0 Then Continue For
        '    Dim DB_Server As String = tb_Kiosk.DefaultView(0).Item("DB_Server").ToString
        '    Dim DB_Database As String = tb_Kiosk.DefaultView(0).Item("DB_Database").ToString
        '    Dim DB_User As String = tb_Kiosk.DefaultView(0).Item("DB_User").ToString
        '    Dim DB_Password As String = tb_Kiosk.DefaultView(0).Item("DB_Password").ToString

        '    Last_Error = ""
        '    Dim Success As Boolean = RunSyncByProperty(KO_ID, DB_Server, DB_Database, DB_User, DB_Password, Command_Type_ID, Command_Detail, Command_Condition, KioskConnectionString)
        '    If Not Success Then
        '        '------------------- Keep Log ------------------
        '        DBService.Update_SyncJob(JOB_ID, DateTime.FromOADate(0), tb_Koisk_Sync_Job.Rows(i).Item("NumberOfRetry") + 1, Now, Last_Error)
        '    Else
        '        DBService.Drop_SyncJob(JOB_ID, 0)
        '    End If
        'Next
        Return True
    End Function

    Public Function RunSyncByJob(ByVal JOB_ID As Integer, ByVal KioskConnectionString As String) As Boolean
        'Dim tb_Koisk_Sync_Job As DataTable = DataProvider.tb_Koisk_Sync_Job(JOB_ID, 0)
        'Dim tb_Kiosk As DataTable = DataProvider.tb_Kiosk(0)

        'For i As Integer = 0 To tb_Koisk_Sync_Job.Rows.Count - 1
        '    JOB_ID = tb_Koisk_Sync_Job.Rows(i).Item("Job_ID")
        '    Dim KO_ID As Integer = tb_Koisk_Sync_Job.Rows(i).Item("KO_ID")
        '    Dim Command_Type_ID As Sync_Command_Type = tb_Koisk_Sync_Job.Rows(i).Item("Command_Type_ID")
        '    Dim Command_Detail As String = tb_Koisk_Sync_Job.Rows(i).Item("Command_Detail").ToString
        '    Dim Command_Condition As String = tb_Koisk_Sync_Job.Rows(i).Item("Command_Condition").ToString

        '    tb_Kiosk.DefaultView.RowFilter = "KO_ID=" & KO_ID
        '    If tb_Kiosk.DefaultView.Count = 0 Then Continue For
        '    Dim DB_Server As String = tb_Kiosk.DefaultView(0).Item("DB_Server").ToString
        '    Dim DB_Database As String = tb_Kiosk.DefaultView(0).Item("DB_Database").ToString
        '    Dim DB_User As String = tb_Kiosk.DefaultView(0).Item("DB_User").ToString
        '    Dim DB_Password As String = tb_Kiosk.DefaultView(0).Item("DB_Password").ToString

        '    Last_Error = ""
        '    Dim Success As Boolean = RunSyncByProperty(KO_ID, DB_Server, DB_Database, DB_User, DB_Password, Command_Type_ID, Command_Detail, Command_Condition, KioskConnectionString)
        '    If Not Success Then
        '        '------------------- Keep Log ------------------
        '        DBService.Update_SyncJob(JOB_ID, DateTime.FromOADate(0), tb_Koisk_Sync_Job.Rows(i).Item("NumberOfRetry") + 1, Now, Last_Error)
        '    Else
        '        DBService.Drop_SyncJob(JOB_ID, 0)
        '    End If
        'Next
        Return True
    End Function

    Public Function RunSyncByProperty(ByVal KO_ID As Integer,
        ByVal DB_Server As String, ByVal DB_Database As String, ByVal DB_User As String, ByVal DB_Password As String,
        ByVal Command_Type_ID As Integer, ByVal Command_Detail As String, ByVal Command_Condition As String, ByVal KioskConnectionString As String) As Boolean

        Dim Conn As New SqlConnection(KioskConnectionString)
        Try
            Conn.Open()
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try

        Select Case CType(Command_Type_ID, Sync_Command_Type)
            Case Sync_Command_Type.CustomQuery
                Try
                    Dim Comm As New SqlCommand
                    With Comm
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = Command_Detail
                        .ExecuteNonQuery()
                        .Dispose()
                    End With
                    Conn.Close()
                    Conn.Dispose()
                    Comm.Dispose()
                Catch ex As Exception
                    Conn.Close()
                    Last_Error = ex.Message
                    Return False
                End Try
            Case Sync_Command_Type.DropData
                Try
                    Dim Comm As New SqlCommand
                    With Comm
                        .CommandType = CommandType.Text
                        .Connection = Conn
                        .CommandText = "DELETE FROM " & Command_Detail & vbLf
                        If Command_Condition <> "" Then
                            .CommandText &= "WHERE " & Command_Condition & vbLf
                        End If
                        .ExecuteNonQuery()
                        .Dispose()
                    End With
                    Conn.Close()
                    Conn.Dispose()
                    Comm.Dispose()
                Catch ex As Exception
                    Conn.Close()
                    Last_Error = ex.Message
                    Return False
                End Try
            Case Sync_Command_Type.EditData

                'Dim DT As New DataTable
                'Try
                '    Select Case Command_Detail.ToUpper
                '        Case "tb_Amphur".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Amphur", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Amphur(DataProvider.tb_Amphur(""), DT, DA)
                '        Case "tb_Application".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Application", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Application(DataProvider.tb_Application(0), DT, DA)
                '        Case "tb_Auth".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Auth", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Auth(DataProvider.tb_Auth(0), DT, DA)
                '        Case "tb_Bill_Company_Location".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Bill_Company_Location", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Bill_Company_Location(DataProvider.tb_Bill_Company_Location(0, ""), DT, DA)
                '        Case "tb_Customer".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Customer", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Customer(DataProvider.tb_Customer(0), DT, DA)
                '        Case "tb_Device".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Device", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Device(DataProvider.tb_Device(0), DT, DA)
                '        Case "tb_Device_Status".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Device_Status", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Device_Status(DataProvider.tb_Device_Status(0, 0), DT, DA)
                '        Case "tb_Device_Type".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Device_Type", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Device_Type(DataProvider.tb_Device_Type(0), DT, DA)
                '        Case "tb_Functional".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Functional", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Functional(DataProvider.tb_Functional(0, 0), DT, DA)
                '        Case "tb_Functional_Zone".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Functional_Zone", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Functional_Zone(DataProvider.tb_Functional_Zone(0, 0), DT, DA)
                '        Case "tb_Kiosk_Ads".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Kiosk_Ads", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Kiosk_Ads(KO_ID, DataProvider.tb_Kiosk_Ads(KO_ID, 0), DT, DA)
                '        Case "tb_Kiosk_Bundled_Product".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Kiosk_Bundled_Product", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Kiosk_Bundled_Product(KO_ID, DataProvider.tb_Kiosk_Bundled_Product(KO_ID, 0), DT, DA)
                '        Case "tb_Koisk_Sync_Job".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Koisk_Sync_Job", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Koisk_Sync_Job(KO_ID, DataProvider.tb_Koisk_Sync_Job(0, KO_ID), DT, DA)
                '        Case "tb_Topup_Choice".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Topup_Choice", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Topup_Choice(DataProvider.tb_Topup_Choice, DT, DA)
                '        Case "tb_Bundled_Product".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Bundled_Product", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Bundled_Product(DataProvider.tb_Bundled_Product(0), DT, DA)
                '        Case "tb_Bill_Company".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Bill_Company", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Bill_Company(DataProvider.tb_Bill_Company(0), DT, DA)
                '        Case "tb_Kiosk".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Kiosk", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Kiosk(DataProvider.tb_Kiosk(KO_ID), DT, DA)
                '        Case "tb_Kiosk_Device".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Kiosk_Device", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Kiosk_Device(DataProvider.tb_Kiosk_Device(0, KO_ID, 0), DT, DA)
                '        Case "tb_Kiosk_SIM_Slot".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Kiosk_SIM_Slot", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Kiosk_SIM_Slot(KO_ID, DataProvider.tb_Kiosk_SIM_Slot(KO_ID, 0, 0), DT, DA)
                '        Case "tb_Location".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Location", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Location(DataProvider.tb_Location(""), DT, DA)
                '        Case "tb_Nationality".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Nationality", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Nationality(DataProvider.tb_Nationality(0), DT, DA)
                '        Case "tb_Network_Scope".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Network_Scope", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Network_Scope(DataProvider.tb_Network_Scope(""), DT, DA)
                '        Case "tb_Product_Package".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Product_Package", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Product_Package(DataProvider.tb_Product_Package(0), DT, DA)
                '        Case "tb_Product_SIM".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Product_SIM", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Product_SIM(DataProvider.tb_Product_SIM(0), DT, DA)
                '        Case "tb_Province".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Province", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Province(DataProvider.tb_Province(""), DT, DA)
                '        Case "tb_User_Location".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_User_Location", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_User_Location(DataProvider.tb_User_Location(0, ""), DT, DA)
                '        Case "tb_Role_Functional".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Role_Functional", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Role_Functional(DataProvider.tb_Role_Functional(0, 0), DT, DA)
                '        Case "tb_Recharge_Type".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Recharge_Type", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Recharge_Type(DataProvider.tb_Recharge_Type(0), DT, DA)
                '        Case "tb_User_Role".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_User_Role", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_User_Role(DataProvider.tb_User_Role(0, 0), DT, DA)
                '        Case "tb_User".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_User", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_User(DataProvider.tb_User(0), DT, DA)
                '        Case "tb_Role".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Role", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Role(DataProvider.tb_Role(0), DT, DA)
                '        Case "tb_Service".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Service", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Service(DataProvider.tb_Service(0), DT, DA)
                '        Case "tb_State_Flow".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_State_Flow", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_State_Flow(DataProvider.tb_State_Flow("", ""), DT, DA)
                '        Case "tb_TXN_Type".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_TXN_Type", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_TXN_Type(DataProvider.tb_TXN_Type(0), DT, DA)
                '        Case "tb_Tumbol".ToUpper
                '            Dim DA As New SqlDataAdapter("SELECT * FROM tb_Tumbol", Conn)
                '            DA.Fill(DT)
                '            Return Bind_tb_Tumbol(DataProvider.tb_Tumbol(""), DT, DA)
                '        Case Else
                '            Conn.Close()
                '            Return True
                '    End Select
                'Catch ex As Exception
                '    Conn.Close()
                '    Last_Error = ex.Message
                '    Return False
                'End Try
        End Select
        Conn.Close()
        Return True
    End Function

    'Public Function ReportKioskStatusTable(ByVal TB As DataTable) As Boolean
    '    Return DBService.ReportKioskAllStatusTable(TB)
    'End Function

    'Public Function ReportKioskStatus(ByVal KO_ID As Integer, ByVal D_ID As Integer, ByVal Current_Qty As Integer, ByVal DS_ID As Integer, ByVal StatusTime As DateTime) As Boolean
    '    Return DBService.ReportKioskAllStatus(KO_ID, D_ID, Current_Qty, DS_ID, StatusTime)
    'End Function

#End Region

#Region "Private Method"
    Private Enum Sync_Command_Type
        EditData = 1
        DropData = 2
        CustomQuery = 3
    End Enum

    Private Function Bind_tb_Amphur(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "AMPHUR_ID='" & TBKiosk.Rows(i).Item("AMPHUR_ID").ToString.Replace("'", "''") & "'"
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "AMPHUR_ID='" & TBServer.Rows(i).Item("AMPHUR_ID").ToString.Replace("'", "''") & "'"
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Application(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "App_ID=" & TBKiosk.Rows(i).Item("App_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "App_ID=" & TBServer.Rows(i).Item("App_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Auth(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "Auth_ID=" & TBKiosk.Rows(i).Item("Auth_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "Auth_ID=" & TBServer.Rows(i).Item("Auth_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Bill_Company_Location(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "CMP_ID=" & TBKiosk.Rows(i).Item("CMP_ID") & " AND Loc_Code='" & TBKiosk.Rows(i).Item("Loc_Code").ToString.Replace("'", "''") & "'"
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "CMP_ID=" & TBServer.Rows(i).Item("CMP_ID") & " AND Loc_Code='" & TBServer.Rows(i).Item("Loc_Code").ToString.Replace("'", "''") & "'"
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Customer(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "CUS_ID=" & TBKiosk.Rows(i).Item("CUS_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "CUS_ID=" & TBServer.Rows(i).Item("CUS_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Device(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "D_ID=" & TBKiosk.Rows(i).Item("D_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "D_ID=" & TBServer.Rows(i).Item("D_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Device_Status(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "DT_ID=" & TBKiosk.Rows(i).Item("DT_ID") & " AND DS_ID=" & TBKiosk.Rows(i).Item("DS_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "DT_ID=" & TBServer.Rows(i).Item("DT_ID") & " AND DS_ID=" & TBServer.Rows(i).Item("DS_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Device_Type(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "DT_ID=" & TBKiosk.Rows(i).Item("DT_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "DT_ID=" & TBServer.Rows(i).Item("DT_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Functional(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "FN_ID=" & TBKiosk.Rows(i).Item("FN_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "FN_ID=" & TBServer.Rows(i).Item("FN_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Functional_Zone(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "FN_Zone_ID=" & TBKiosk.Rows(i).Item("FN_Zone_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "FN_Zone_ID=" & TBServer.Rows(i).Item("FN_Zone_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Kiosk_Ads(ByVal KO_ID As Integer, ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "KO_ID=" & KO_ID & " AND Ads_ID=" & TBKiosk.Rows(i).Item("Ads_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "KO_ID=" & KO_ID & " AND Ads_ID=" & TBServer.Rows(i).Item("Ads_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Kiosk_Bundled_Product(ByVal KO_ID As Integer, ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "KO_ID=" & KO_ID & " AND BP_ID=" & TBKiosk.Rows(i).Item("BP_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "KO_ID=" & KO_ID & " AND BP_ID=" & TBServer.Rows(i).Item("BP_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Koisk_Sync_Job(ByVal KO_ID As Integer, ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "KO_ID=" & KO_ID & " AND Job_ID=" & TBKiosk.Rows(i).Item("Job_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "KO_ID=" & KO_ID & " AND Job_ID=" & TBServer.Rows(i).Item("Job_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Topup_Choice(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "Topup_Value=" & TBKiosk.Rows(i).Item("Topup_Value")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "Topup_Value=" & TBServer.Rows(i).Item("Topup_Value")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Bundled_Product(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "BP_ID=" & TBKiosk.Rows(i).Item("BP_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "BP_ID=" & TBServer.Rows(i).Item("BP_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Bill_Company(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "CMP_ID=" & TBKiosk.Rows(i).Item("CMP_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "CMP_ID=" & TBServer.Rows(i).Item("CMP_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Kiosk(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "KO_ID=" & TBKiosk.Rows(i).Item("KO_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "KO_ID=" & TBServer.Rows(i).Item("KO_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Kiosk_Device(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "KD_ID=" & TBKiosk.Rows(i).Item("KD_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "KD_ID=" & TBServer.Rows(i).Item("KD_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Kiosk_SIM_Slot(ByVal KO_ID As Integer, ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "KO_ID=" & KO_ID & " AND D_ID=" & TBKiosk.Rows(i).Item("D_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "KO_ID=" & KO_ID & " AND D_ID=" & TBServer.Rows(i).Item("D_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Location(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "Loc_Code='" & TBKiosk.Rows(i).Item("Loc_Code").ToString.Replace("'", "''") & "'"
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "Loc_Code='" & TBServer.Rows(i).Item("Loc_Code").ToString.Replace("'", "''") & "'"
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Nationality(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "Nation_ID=" & TBKiosk.Rows(i).Item("Nation_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "Nation_ID=" & TBServer.Rows(i).Item("Nation_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Network_Scope(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "NS_Code='" & TBKiosk.Rows(i).Item("NS_Code").ToString.Replace("'", "''") & "'"
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "NS_Code='" & TBServer.Rows(i).Item("NS_Code").ToString.Replace("'", "''") & "'"
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Product_Package(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "PCK_ID=" & TBKiosk.Rows(i).Item("PCK_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "PCK_ID=" & TBServer.Rows(i).Item("PCK_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Product_SIM(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "SIM_ID=" & TBKiosk.Rows(i).Item("SIM_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "SIM_ID=" & TBServer.Rows(i).Item("SIM_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Province(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "PROVINCE_ID='" & TBKiosk.Rows(i).Item("PROVINCE_ID").ToString.Replace("'", "''") & "'"
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "PROVINCE_ID='" & TBServer.Rows(i).Item("PROVINCE_ID").ToString.Replace("'", "''") & "'"
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_User_Location(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "User_ID=" & TBKiosk.Rows(i).Item("User_ID") & " AND Loc_Code='" & TBKiosk.Rows(i).Item("Loc_Code").ToString.Replace("'", "''") & "'"
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "User_ID=" & TBServer.Rows(i).Item("User_ID") & " AND Loc_Code='" & TBServer.Rows(i).Item("Loc_Code").ToString.Replace("'", "''") & "'"
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Recharge_Type(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "RC_Type_ID=" & TBKiosk.Rows(i).Item("RC_Type_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "RC_Type_ID=" & TBServer.Rows(i).Item("RC_Type_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Role_Functional(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "Role_ID=" & TBKiosk.Rows(i).Item("Role_ID") & " AND FN_ID=" & TBKiosk.Rows(i).Item("FN_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "Role_ID=" & TBServer.Rows(i).Item("Role_ID") & " AND FN_ID=" & TBServer.Rows(i).Item("FN_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_User_Role(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "User_ID=" & TBKiosk.Rows(i).Item("User_ID") & " AND Role_ID=" & TBKiosk.Rows(i).Item("Role_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "User_ID=" & TBServer.Rows(i).Item("User_ID") & " AND Role_ID=" & TBServer.Rows(i).Item("Role_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Role(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "Role_ID=" & TBKiosk.Rows(i).Item("Role_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "Role_ID=" & TBServer.Rows(i).Item("Role_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_User(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "User_ID=" & TBKiosk.Rows(i).Item("User_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "User_ID=" & TBServer.Rows(i).Item("User_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Service(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "SV_ID=" & TBKiosk.Rows(i).Item("SV_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "SV_ID=" & TBServer.Rows(i).Item("SV_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_TXN_Type(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "TXN_Type_ID=" & TBKiosk.Rows(i).Item("TXN_Type_ID")
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "TXN_Type_ID=" & TBServer.Rows(i).Item("TXN_Type_ID")
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_State_Flow(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "State_Code='" & TBKiosk.Rows(i).Item("State_Code").ToString.Replace("'", "''") & "'"
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "State_Code='" & TBServer.Rows(i).Item("State_Code").ToString.Replace("'", "''") & "'"
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

    Private Function Bind_tb_Tumbol(ByRef TBServer As DataTable, ByRef TBKiosk As DataTable, ByRef KioskDA As SqlDataAdapter) As Boolean
        Try
            '------------ Remove Unused Row ------------
            For i As Integer = TBKiosk.Rows.Count - 1 To 0 Step -1
                TBServer.DefaultView.RowFilter = "TUMBOL_ID='" & TBKiosk.Rows(i).Item("TUMBOL_ID").ToString.Replace("'", "''") & "'"
                If TBServer.DefaultView.Count = 0 Then TBKiosk.Rows(i).Delete()
            Next

            For i As Integer = 0 To TBServer.Rows.Count - 1
                TBKiosk.DefaultView.RowFilter = "TUMBOL_ID='" & TBServer.Rows(i).Item("TUMBOL_ID").ToString.Replace("'", "''") & "'"
                If TBKiosk.DefaultView.Count = 0 Then  '------------ Add New Item -----------------
                    Dim DR As DataRow = TBKiosk.NewRow
                    DR.ItemArray = TBServer.Rows(i).ItemArray
                    TBKiosk.Rows.Add(DR)
                Else  '------------ Update Item -----------------
                    TBKiosk.DefaultView(0).Row.ItemArray = TBServer.Rows(i).ItemArray
                End If
            Next
            Dim cmd As New SqlCommandBuilder(KioskDA)
            KioskDA.Update(TBKiosk)
            Last_Error = ""
            Return True
        Catch ex As Exception
            Last_Error = ex.Message
            Return False
        End Try
    End Function

#End Region
End Class
