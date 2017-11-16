Imports System
Imports System.Runtime.InteropServices
Imports Microsoft.Win32.SafeHandles
Imports System.ComponentModel
Imports System.Threading


Public Class AutoWakeUP
    <DllImport("kernel32.dll")>
    Public Shared Function CreateWaitableTimer(lpTimerAttributes As IntPtr, bManualReset As Boolean, lpTimerName As String) As SafeWaitHandle
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function SetWaitableTimer(hTimer As SafeWaitHandle, <[In]> ByRef pDueTime As Long, lPeriod As Integer, pfnCompletionRoutine As IntPtr, lpArgToCompletionRoutine As IntPtr, fResume As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Event Woken As EventHandler

    Private bgWorker As New BackgroundWorker()

    Public Sub New()
        AddHandler bgWorker.DoWork, AddressOf bgWorker_DoWork
        AddHandler bgWorker.RunWorkerCompleted, AddressOf bgWorker_RunWorkerCompleted
    End Sub

    Public Sub SetWakeUpTime(time As DateTime)
        bgWorker.RunWorkerAsync(time.ToFileTime())
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        RaiseEvent Woken(Me, New EventArgs())
    End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As DoWorkEventArgs)
        Dim waketime As Long = CLng(e.Argument)

        Using handle As SafeWaitHandle = CreateWaitableTimer(IntPtr.Zero, True, Me.[GetType]().Assembly.GetName().Name.ToString() & "Timer")
            If SetWaitableTimer(handle, waketime, 0, IntPtr.Zero, IntPtr.Zero, True) Then
                Using wh As New EventWaitHandle(False, EventResetMode.AutoReset)
                    wh.SafeWaitHandle = handle
                    wh.WaitOne()
                End Using
            Else
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
        End Using
    End Sub
End Class
