Imports System.Net
Imports System.IO
Imports System.Net.Sockets
Imports System.Data.SqlClient
Imports CheckHardware.Org.Mentalis.Files

Module CheckHardwareModule

    Public INIFileName As String = Application.StartupPath & "\ConfigDevice.ini"

    Public BackEnd As BackEnd_
    Public Structure BackEnd_
        Dim POS_ID As String
    End Structure
    Public ConnStr As String

    Public Enum HW
        CASHIN = 55
        CASHOUT100 = 100
        CASHOUT20 = 20
        CASHOUT50 = 50
        COININ = 66
        COINOUT1 = 1
        COINOUT5 = 5
        IPCAM = 44
    End Enum

    Public Sub KeepHWCondition(ByVal Hardware As HW, ByVal Condition As Boolean)
        Dim HW_ID As String = ""
        Select Case Hardware
            Case HW.CASHIN
                HW_ID = "CASHIN"
            Case HW.CASHOUT100
                HW_ID = "CASHOUT100"
            Case HW.CASHOUT20
                HW_ID = "CASHOUT20"
            Case HW.CASHOUT50
                HW_ID = "CASHOUT50"
            Case HW.COININ
                HW_ID = "COININ"
            Case HW.COINOUT1
                HW_ID = "COINOUT1"
            Case HW.COINOUT5
                HW_ID = "COINOUT5"
            Case HW.IPCAM
                HW_ID = "IPCAM"
            Case Else
                Exit Sub
        End Select
        Dim DA As New SqlDataAdapter("SELECT TOP 1 * FROM tb_HW_Condition WHERE HW_ID='" & HW_ID & "' ORDER BY Update_Time DESC", ConnStr)
        Dim DT As New DataTable
        DA.Fill(DT)
        If DT.Rows(0).Item("HW_Condition") <> Condition Then
            Dim DR As DataRow = DT.NewRow
            DR("HW_ID") = HW_ID
            DR("HW_Condition") = Condition
            DR("Update_Time") = Now
            DT.Rows.Add(DR)
            Dim cmd As New SqlCommandBuilder(DA)
            DA.Update(DT)
        End If
    End Sub

    Public SessionCollection As New ArrayList
    Public Class SessionCommunications
        Public theClient As Socket
        Public remoteIpAddress As System.Net.IPAddress
        Public thePort As Int32

        Public Sub New(ByVal _client As Socket, ByVal _port As Int32)
            theClient = _client
            thePort = _port
        End Sub

        Public Sub Close()
            Try
                theClient.Blocking = False
                theClient.Close()
            Catch ex As Exception : End Try
        End Sub

    End Class

    Function ChenkTextNull(txt As String) As Boolean
        If txt Is Nothing Then
            Return False
        End If
        txt = txt.Replace(vbNullChar, "")

        If txt.Trim = "" Then
            Return False
        End If
        Return True
    End Function

    Public Function TestConnection(ByVal ConnectionString As String) As Boolean
        Dim TestConn As New SqlConnection
        Try
            TestConn.ConnectionString = ConnectionString
            TestConn.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Sub BindConnectintString()
        Dim ini As New IniReader(INIFileName)
        ini.Section = "Setting"
        ConnStr = "Data Source=" & ini.ReadString("ServerName") & ";Initial Catalog=" & ini.ReadString("Database") & ";User ID=" & ini.ReadString("Username") & ";Password=" & ini.ReadString("Password") & ";Connect Timeout=1;"
    End Sub

    Function GetCashCoinQty(ByVal Type As Integer) As Integer
        Dim Qty As Integer = 0
        Dim SQL As String = "SELECT * FROM tb_Exchange_Movement WHERE Ex_ID = " & Type
        Dim DA As New SqlDataAdapter(SQL, ConnStr)
        Dim DT As New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            Qty = DT.Rows(0).Item("M_Qty")
        End If
        Return Qty
    End Function

    Sub UpdateCashCoinQty(ByVal Type As Integer, ByVal QtySend As Integer)
        Dim SQL As String = "SELECT * FROM tb_Exchange_Movement WHERE Ex_ID = " & Type
        Dim DA As New SqlDataAdapter(SQL, ConnStr)
        Dim DT As New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            Dim DR As DataRow
            DR = DT.Rows(0)
            DR("M_Qty") = DT.Rows(0).Item("M_Qty") - QtySend
            Dim cmb As New SqlCommandBuilder(DA)
            DA.Update(DT)
        End If
    End Sub

    Sub CutStockProduct(ByVal Prod_ID As Integer, ByVal Qty As Integer)
        Dim SQL As String = "SELECT * FROM tb_Product WHERE Prod_ID = " & Prod_ID
        Dim DA As New SqlDataAdapter(SQL, ConnStr)
        Dim DT As New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            Dim DR As DataRow
            DR = DT.Rows(0)
            DR("Stock_Qty") = DT.Rows(0).Item("Stock_Qty") - Qty
            Dim cmb As New SqlCommandBuilder(DA)
            DA.Update(DT)
        End If
    End Sub

End Module

