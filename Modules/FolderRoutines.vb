Imports System.IO

Namespace Modules
    Friend Module FolderRoutines
        Public Sub CreateProgramFolders()
            ArcDirYr = Path.Combine(ArcDir, CType(Now.Year, String))
            Dim fName As New List(Of String)({SetDir, ArcDir, LogDir, ArcDirYr}) 'ArcDirYears, ArcDirDays, ArcDirDaily
            With FrmMain
                For j = 0 To fName.Count - 1
                    Try
                        If Not Directory.Exists(fName(j)) Then
                            Directory.CreateDirectory(fName(j))
                            PrintLog($"{fName(j)} created.{vbLf}")
                        End If
                    Catch ex As Exception
                        PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.Source, ex.GetBaseException.ToString)
                    Finally
                        'a
                    End Try
                Next
            End With
        End Sub
    End Module
End Namespace