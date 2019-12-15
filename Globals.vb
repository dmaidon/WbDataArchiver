Imports System.IO

Module Globals
    'Public Const CPY As String = "©2019, PAROLE Software - all rigths reserved."

    Public ReadOnly SetDir As String = Path.Combine(Application.StartupPath, "Settings")
    Public ReadOnly ArcDir As String = Path.Combine(Application.StartupPath, "Archives")
    Public ReadOnly LogDir As String = Path.Combine(Application.StartupPath, "Logs")

    'Public ReadOnly ArcDirDays As String = Path.Combine(ArcDir, "Days")
    'Public ReadOnly ArcDirDaily As String = Path.Combine(ArcDir, "Daily")
    'Public ReadOnly ArcDirYears As String = Path.Combine(ArcDir, "Years")
    Public ArcDirYr As String

    Public LogFile As String
    Public ReadOnly Separator As String = StrDup(35, "-"c)

    Public ReadOnly WbSet As New List(Of String)

    Public MidDuration As TimeSpan
    Public MidUpdate As Date

    Public CurDuration As TimeSpan
    Public CurUpdate As Date

    Public MoEndTime As Date

    Public TimesRun As Long
End Module