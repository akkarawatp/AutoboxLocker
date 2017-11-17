Imports System.Management
Public Class frmTest


    Public Function getCPU_ID() As String

        Dim cpuID As String = String.Empty
        Dim mc As ManagementClass = New ManagementClass("Win32_Processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo As ManagementObject In moc
            cpuID += mo.Qualifiers.Item("UUID").Value
        Next
        Return cpuID
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtCPU_ID.Text = getCPU_ID()
        txtProcessorID.Text = nsProcessorID.CPUId.GetProcessorId
        txtProcessorName.Text = ProcessorName()
        txtMainBoardID.Text = nsProcessorID.CPUId.GetMotherBoardID
    End Sub
End Class