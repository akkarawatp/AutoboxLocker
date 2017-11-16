Imports System.Reflection
Imports System.Windows.Forms
Imports System.IO
Imports KioskLinqDB.ConnectDB
Imports KioskLinqDB.TABLE
Imports ServerLinqDB.ConnectDB
Imports ServerLinqDB.TABLE

Public Class LogFileENG

#Region "Kiosk Error Log"
    Public Shared Sub CreateKioskErrorLog(CreateBy As String, LogMsg As String, KioskID As Long)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        Try
            Dim lnq As New TbLogErrorKioskLinqDB
            lnq.MS_KIOSK_ID = KioskID
            lnq.CLASS_NAME = ClassName
            lnq.FUNCTION_NAME = FunctionName & " Line No : " & LineNo
            lnq.ERROR_TIME = DateTime.Now
            lnq.ERROR_DESC = LogMsg
            lnq.SYNC_TO_SERVER = "N"

            Dim trans As New KioskTransactionDB
            Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = lnq.InsertData(CreateBy, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                CreateTextErrorLog(ret.ErrorMessage & Environment.NewLine & "CreateBy=" & CreateBy & "&ClassName=" & ClassName & "&FunctionName=" & FunctionName & "&KioskID=" & KioskID & Environment.NewLine & LogMsg)
            End If
        Catch ex As Exception
            CreateTextErrorLog("Exception : " & ex.Message & " " & ex.StackTrace & Environment.NewLine & "CreateBy=" & CreateBy & "&ClassName=" & ClassName & "&FunctionName=" & FunctionName & "&KioskID=" & KioskID & Environment.NewLine & LogMsg)
        End Try

    End Sub

    Public Shared Sub CreateTextErrorLog(LogMsg As String)
        Try
            Dim frame As StackFrame = New StackFrame(1, True)
            Dim ClassName As String = frame.GetMethod.ReflectedType.Name
            Dim FunctionName As String = frame.GetMethod.Name
            Dim LineNo As Integer = frame.GetFileLineNumber

            Dim MY As String = DateTime.Now.ToString("yyyyMM")
            Dim DD As String = DateTime.Now.ToString("dd")
            Dim LogFolder As String = Application.StartupPath & "\ErrorLog\" & MY & "\" & DD & "\"
            If Directory.Exists(LogFolder) = False Then
                Directory.CreateDirectory(LogFolder)
            End If

            Dim FileName As String = LogFolder & ClassName & "_" & DateTime.Now.ToString("yyyyMMddHH") & ".txt"
            Dim obj As New StreamWriter(FileName, True)
            obj.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & " " & FunctionName & " Line No :" & LineNo & Environment.NewLine & LogMsg & Environment.NewLine & Environment.NewLine)
            obj.Flush()
            obj.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Shared Sub CreateLogAgent(MsKioskID As Long, ClassName As String, FunctionName As String, LineNo As Int16, LogMsg As String, LogType As Int16)
        ''### Current Class and Function name
        'Dim m As MethodBase = MethodBase.GetCurrentMethod()
        'Dim ThisClassName As String = m.ReflectedType.Name
        'Dim ThisFunctionName As String = m.Name

        Try
            Dim lnq As New TbLogKioskAgentKioskLinqDB
            lnq.MS_KIOSK_ID = MsKioskID
            lnq.LOG_TIME = DateTime.Now
            lnq.LOG_TYPE = LogType.ToString
            lnq.LOG_MESSAGE = LogMsg
            lnq.CLASS_NAME = ClassName
            lnq.FUNCTION_NAME = FunctionName
            lnq.LINE_NO = LineNo
            lnq.SYNC_TO_SERVER = "N"

            Dim trans As New KioskTransactionDB
            Dim ret As KioskLinqDB.ConnectDB.ExecuteDataInfo = lnq.InsertData(Environment.MachineName, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                CreateTextErrorLog(ret.ErrorMessage & Environment.NewLine & "ClassName=" & ClassName & "&FunctionName=" & FunctionName & "&KioskID=" & MsKioskID & "&LogType=" & LogType & Environment.NewLine & LogMsg)
            End If
        Catch ex As Exception
            CreateTextErrorLog("Exception : " & ex.Message & " " & ex.StackTrace & Environment.NewLine & "ClassName=" & ClassName & "&FunctionName=" & FunctionName & "&KioskID=" & MsKioskID & "&LogType=" & LogType & Environment.NewLine & LogMsg)
        End Try
    End Sub

    Public Shared Sub CreateLogAgent(MsKioskID As Long, LogMsg As String)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber
        CreateLogAgent(MsKioskID, ClassName, FunctionName, LineNo, LogMsg, AgentLogType.TransLog)
    End Sub

    Public Shared Sub CreateErrorLogAgent(MsKioskID As Long, LogMsg As String)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        CreateLogAgent(MsKioskID, ClassName, FunctionName, LineNo, LogMsg, AgentLogType.ErrorLog)
    End Sub

    Public Shared Sub CreateExceptionLogAgent(MsKioskID As Long, ExMessage As String, ExStackTrace As String)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        CreateLogAgent(MsKioskID, ClassName, FunctionName, LineNo, "Exception : " & ExMessage & vbNewLine & ExStackTrace, AgentLogType.ExceptionLog)
    End Sub

    Public Shared Sub TestTraceFrame()
        '### Current Class and Function name
        Dim m As MethodBase = MethodBase.GetCurrentMethod()
        Dim ThisClassName As String = m.ReflectedType.Name
        Dim ThisFunctionName As String = m.Name



        Dim frame As StackFrame = New StackFrame(1, True)
        Dim CallFromAppName As String = frame.GetMethod.Module.FullyQualifiedName
        Dim CallFromClassName As String = frame.GetMethod.ReflectedType.Name
        Dim CallFromMethod As String = frame.GetMethod.Name
        Dim CallFromFile As String = frame.GetFileName
        Dim CallFromLineNo As String = frame.GetFileLineNumber


        Dim aaa As String = ""
    End Sub


    Private Enum AgentLogType
        TransLog = 1
        ErrorLog = 2
        ExceptionLog = 3
    End Enum
#End Region

#Region "Window Service Log"
    Public Shared Sub CreateHartbeat(TimerName As String)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        Try
            Dim hbPath As String = Application.StartupPath & "\HeartBeat\" & ClassName & "\"
            If Directory.Exists(hbPath) = False Then
                Directory.CreateDirectory(hbPath)
            End If

            Dim FileName As String = hbPath & FunctionName & "_Timer_" & TimerName & ".txt"
            Dim obj As New StreamWriter(FileName, False)
            obj.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
            obj.Flush()
            obj.Close()
        Catch ex As Exception
            ''### Current Class and Function name
            'Dim m As MethodBase = MethodBase.GetCurrentMethod()
            'Dim ThisClassName As String = m.ReflectedType.Name
            'Dim ThisFunctionName As String = m.Name

            CreateTextErrorLog("Exception : " & ex.Message & " " & ex.StackTrace & "&ClassName=" & ClassName & "&FunctionName=" & FunctionName & "&LineNo=" & LineNo & "&TimerName=" & TimerName)
        End Try
    End Sub

    Public Shared Sub CreateServerLogAgent(LogMsg As String)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber
        CreateServerLogAgent(ClassName, FunctionName, LineNo, LogMsg, AgentLogType.TransLog)
    End Sub

    Public Shared Sub CreateServerErrorLogAgent(LogMsg As String)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        CreateServerLogAgent(ClassName, FunctionName, LineNo, LogMsg, AgentLogType.ErrorLog)
    End Sub

    Public Shared Sub CreateServerExceptionLogAgent(ExMessage As String, ExStackTrace As String)
        Dim frame As StackFrame = New StackFrame(1, True)
        Dim ClassName As String = frame.GetMethod.ReflectedType.Name
        Dim FunctionName As String = frame.GetMethod.Name
        Dim LineNo As Integer = frame.GetFileLineNumber

        CreateServerLogAgent(ClassName, FunctionName, LineNo, "Exception : " & ExMessage & vbNewLine & ExStackTrace, AgentLogType.ExceptionLog)
    End Sub


    Private Shared Sub CreateServerLogAgent(ClassName As String, FunctionName As String, LineNo As Int16, LogMsg As String, LogType As Int16)
        ''### Current Class and Function name
        'Dim m As MethodBase = MethodBase.GetCurrentMethod()
        'Dim ThisClassName As String = m.ReflectedType.Name
        'Dim ThisFunctionName As String = m.Name

        Try
            Dim lnq As New TbLogServerAgentServerLinqDB
            lnq.LOG_TYPE = LogType.ToString
            lnq.LOG_MESSAGE = LogMsg
            lnq.CLASS_NAME = ClassName
            lnq.FUNCTION_NAME = FunctionName
            lnq.LINE_NO = LineNo

            Dim trans As New ServerTransactionDB
            Dim ret As ServerLinqDB.ConnectDB.ExecuteDataInfo = lnq.InsertData(Environment.MachineName, trans.Trans)
            If ret.IsSuccess = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                CreateTextErrorLog(ret.ErrorMessage & Environment.NewLine & "ClassName=" & ClassName & "&FunctionName=" & FunctionName & "&LogType=" & LogType & Environment.NewLine & LogMsg)
            End If
        Catch ex As Exception
            CreateTextErrorLog("Exception : " & ex.Message & " " & ex.StackTrace & Environment.NewLine & "ClassName=" & ClassName & "&FunctionName=" & FunctionName & "&LogType=" & LogType & Environment.NewLine & LogMsg)
        End Try
    End Sub

#End Region

End Class
