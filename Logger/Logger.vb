﻿Imports System.IO
Public Class Logger
    Private Stream As StreamWriter
    Public Prefix As String
    Public AddTime As Boolean
    Public AddDate As Boolean

    ''' <summary>
    ''' Will create a new Logger
    ''' </summary>
    ''' <param name="LogLocation">The location of the log file, can an existing file, or it can create a new one. You can log on the same file at the same time using multiple loggers.</param>
    ''' <param name="LogPrefix">The prefix of each log (e.g. 'Log: ' followed by the rest of the log)</param>
    ''' <param name="LogAddTime">Whether to add the time after the prefix, and before the log</param>
    ''' <param name="LogAddDate">Whether to add the date after the prefix and time (time not needed), and before the log</param>
    ''' <remarks>The same file can have multiple loggers on it at once, allowing different prefixes etc.</remarks>
    Public Sub New(ByVal LogLocation As String, Optional ByVal LogPrefix As String = "", Optional ByVal LogAddTime As Boolean = True, Optional ByVal LogAddDate As Boolean = True)
        Stream = New StreamWriter(LogLocation, True)
        Prefix = LogPrefix
        AddTime = LogAddTime
        AddDate = LogAddDate
    End Sub

    ''' <summary>
    ''' Will log a string into the log file using the logger ID and a string.
    ''' </summary>
    ''' <param name="LogString">The string to log</param>
    ''' <returns>The full string that was logged</returns>
    ''' <remarks></remarks>
    Public Function Log(ByVal LogString As String)
        Dim StringToLog As String = ""
        If Prefix IsNot "" Then
            StringToLog = Prefix & " "
        End If
        If AddDate Then
            StringToLog = StringToLog & "[" & Today.ToShortDateString & "] "
        End If
        If AddTime Then
            StringToLog = StringToLog & "[" & Hour(Now) & ":" & Minute(Now) & ":" & Second(Now) & "] "
        End If
        StringToLog = StringToLog & LogString
        Stream.WriteLine(StringToLog)
        Stream.Flush()
        Return StringToLog
    End Function

    ''' <summary>
    ''' Will dispose of the logger
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose()
        Stream.Dispose()
        Me.Dispose()
    End Sub
End Class
