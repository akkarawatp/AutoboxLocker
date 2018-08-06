Imports System.Web
Imports System.Reflection
Imports System.Text
Public Class LogMessageBuilder
    Inherits Dictionary(Of String, String)

    Protected Const lastLogTimeKey As String = "__LAST_LOG_TIME_KEY__"
    Protected Const totalLogTimeKey As String = "__TOTAL_LOG_TIME_KEY__"
    Protected _prefixMsg As String = String.Empty
    Protected _suffixMsg As String = String.Empty
    Private Shared _threadDbContexts As New Hashtable

    Protected Property FirstLogtime As DateTime
        Get
            If HttpContext.Current IsNot Nothing Then  'กรณีเป็น Web app
                If HttpContext.Current.Items.Contains(totalLogTimeKey) = False Then
                    HttpContext.Current.Items(totalLogTimeKey) = DateTime.Now
                End If
            End If

            Return Convert.ToDateTime(HttpContext.Current.Items(totalLogTimeKey))

            SyncLock _threadDbContexts.SyncRoot

                If Not _threadDbContexts.Contains(totalLogTimeKey) Then
                    _threadDbContexts(totalLogTimeKey) = DateTime.Now
                End If

                Return CType(_threadDbContexts(totalLogTimeKey), DateTime)
            End SyncLock
        End Get
        Set(ByVal Value As DateTime)
            If Not HttpContext.Current Is Nothing Then
                HttpContext.Current.Items(totalLogTimeKey) = Value
            Else
                _threadDbContexts(totalLogTimeKey) = Value
            End If
        End Set
    End Property


    Protected Property LastLogTime() As DateTime
        Get
            If Not HttpContext.Current Is Nothing Then
                If Not HttpContext.Current.Items.Contains(lastLogTimeKey) Then
                    HttpContext.Current.Items(lastLogTimeKey) = DateTime.Now
                End If

                Return CType(HttpContext.Current.Items(lastLogTimeKey), DateTime)
            End If
            SyncLock (_threadDbContexts.SyncRoot) ' ใช้ในกรณีเป็น Standalone App

                If Not _threadDbContexts.Contains(lastLogTimeKey) Then
                    _threadDbContexts(lastLogTimeKey) = DateTime.Now
                End If

                Return CType(_threadDbContexts(lastLogTimeKey), DateTime)
            End SyncLock
        End Get
        Set(ByVal Value As DateTime)
            If Not HttpContext.Current Is Nothing Then
                HttpContext.Current.Items(lastLogTimeKey) = Value
            Else ' ใช้ในกรณีเป็น Standalone App Then 
                _threadDbContexts(lastLogTimeKey) = Value
            End If
        End Set
    End Property

    Public ReadOnly Property TotalTime() As String
        Get
            Return (LastLogTime - FirstLogtime).TotalMilliseconds.ToString()
        End Get
    End Property

    Protected ReadOnly Property ElapseTime() As String
        Get
            Dim _ElapseTime As Double = DateTime.Now.Subtract(LastLogTime).TotalMilliseconds
            LastLogTime = Now

            Return _ElapseTime.ToString()
        End Get
    End Property

    Private Function IsPrimitiveType(ByVal _Type As Type) As Boolean
        Return (_Type = GetType(Object) Or Type.GetTypeCode(_Type) <> TypeCode.Object)
    End Function

    Public Function SetPrefixMsg(ByVal msg As String) As LogMessageBuilder
        _prefixMsg = msg
        Return Me
    End Function

    Public Function SetSuffixMsg(ByVal msg As String) As LogMessageBuilder
        _suffixMsg = msg
        Return Me
    End Function

    Public Overloads Function Add(ByVal key As String, ByVal value As Object) As LogMessageBuilder
        MyBase.Add(key, value.ConvertToString())
        Return Me
    End Function

    Public Overloads Function Add(ByVal key As String, ByVal value As Integer) As LogMessageBuilder
        MyBase.Add(key, value.ToString())
        Return Me
    End Function

    Public Overloads Function Add(ByVal key As String, ByVal value As Long) As LogMessageBuilder
        MyBase.Add(key, value.ToString())
        Return Me
    End Function

    Public Overloads Function Add(ByVal key As String, ByVal value As String) As LogMessageBuilder
        MyBase.Add(key, value)
        Return Me
    End Function

    Public Function AddObject(ByVal obj As Object, Optional exclude() As String = Nothing) As LogMessageBuilder
        Return AddObject(obj, Nothing, exclude)
    End Function


    Public Function AddObject(ByVal obj As Object, ByVal parent As Object, Optional exclude() As String = Nothing) As LogMessageBuilder
        If obj Is Nothing Then
            Return Me
        End If

        Dim parentName As String = parent <> IIf(Nothing, parent.GetType().Name, String.Empty)

        Dim prop As PropertyInfo
        For Each prop In obj.GetType().GetProperties()
            Try
                If exclude IsNot Nothing And (exclude.Contains(prop.Name) Or exclude.Contains(parentName + "::" + prop.Name)) Then
                    Continue For
                End If

                Dim _type As Type = prop.PropertyType
                Dim value As Object = prop.GetValue(obj, Nothing)

                If Not Not IsPrimitiveType(_type) And value Is Nothing Then
                    AddObject(value, obj, exclude)
                    Continue For
                End If

                If Not parent Is Nothing Then
                    MyBase.Add(parentName + "::" + prop.Name, value <> IIf(Nothing, value.ToString(), String.Empty))
                Else
                    MyBase.Add(prop.Name, value <> IIf(Nothing, value.ToString(), String.Empty))
                End If
            Catch
                If Not parent Is Nothing Then
                    MyBase.Add(parentName + "::" + prop.Name, "N/A")
                Else
                    MyBase.Add(prop.Name, "N/A")
                End If
            End Try
        Next

        Return Me
    End Function

    Public Overloads Function Remove(ByVal key As String) As LogMessageBuilder
        MyBase.Remove(key)
        Return Me
    End Function

    Public Overloads Function Clear() As LogMessageBuilder
        _prefixMsg = String.Empty
        _suffixMsg = String.Empty
        MyBase.Clear()
        Return Me
    End Function

    Public Function ToInputLogString() As String
        Dim builder As New StringBuilder()
        builder.Append("ElapsedTime: " + ElapseTime + ": TotalTime: " + TotalTime + ": I:--START--")

        If Not String.IsNullOrEmpty(_prefixMsg) Then
            builder.Append(":--" + _prefixMsg + "--")
        End If

        Dim key As String
        For Each key In Keys
            builder.Append(":" + key + "/" + Me(key))
        Next

        If Not String.IsNullOrEmpty(_suffixMsg) Then
            builder.Append(":--" + _suffixMsg + "--")
        End If

        Return builder.ToString()
    End Function

    Public Function ToOutputLogString() As String
        Dim builder As New StringBuilder()
        builder.Append("ElapsedTime: " + ElapseTime + ": TotalTime: " + TotalTime + ": O")

        If Not String.IsNullOrEmpty(_prefixMsg) Then
            builder.Append(":--" + _prefixMsg + "--")
        End If

        Dim key As String
        For Each key In Keys
            builder.Append(":" + key + "/" + Me(key))
        Next

        If Not String.IsNullOrEmpty(_suffixMsg) Then
            builder.Append(":--" + _suffixMsg + "--")
        End If

        Return builder.ToString()
    End Function

    Public Function ToSuccessLogString() As String
        Dim builder As New StringBuilder()
        builder.Append("ElapsedTime: " + ElapseTime + ": TotalTime: " + TotalTime + ":O:--SUCCESS--")

        If Not String.IsNullOrEmpty(_prefixMsg) Then
            builder.Append(":--" + _prefixMsg + "--")
        End If

        Dim key As String
        For Each key In Keys
            builder.Append(":" + key + "/" + Me(key))
        Next

        If Not String.IsNullOrEmpty(_suffixMsg) Then
            builder.Append(":--" + _suffixMsg + "--")
        End If

        Return builder.ToString()
    End Function

    Public Function ToFailLogString() As String
        Dim builder As New StringBuilder()
        builder.Append("ElapsedTime: " + ElapseTime + ": TotalTime: " + TotalTime + ":O:--FAIL--")

        If Not String.IsNullOrEmpty(_prefixMsg) Then
            builder.Append(":--" + _prefixMsg + "--")
        End If

        Dim key As String
        For Each key In Keys
            builder.Append(":" + key + "/" + Me(key))
        Next

        If Not String.IsNullOrEmpty(_suffixMsg) Then
            builder.Append(":--" + _suffixMsg + "--")
        End If

        Return builder.ToString()
    End Function
End Class
