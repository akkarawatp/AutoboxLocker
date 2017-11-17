Imports System
Imports System.Management
Namespace nsProcessorID
    Public Class CPUId

        Public Shared Function GetProcessorId() As String
            Dim strProcessorId As String = ""
            Dim query As New SelectQuery("Win32_processor")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strProcessorId = info("processorId").ToString()
            Next
            Return strProcessorId
        End Function


        Public Shared Function GetMotherBoardID() As String
            Dim strMotherBoardID As String = ""
            Dim query As New SelectQuery("Win32_BaseBoard")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strMotherBoardID = info("SerialNumber").ToString()
            Next
            Return strMotherBoardID
        End Function
    End Class

End Namespace
