Imports System.IO

Namespace Modules
    Friend Module FolderRoutines

        Public Sub CreateProgramFolders()
            Dim fName As New List(Of String)({SetDir, ArcDir, ArcDirDays, ArcDirDaily, ArcDirYears})
            With FrmMain
                For j = 0 To fName.Count - 1
                    Try
                        If Not Directory.Exists(fName(j)) Then
                            Directory.CreateDirectory(fName(j))
                        End If
                    Catch ex As Exception
                        'PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.Source, ex.GetBaseException.ToString)
                        FrmMain.Rtb.AppendText(ex.Message & ex.StackTrace & ex.Source & vbLf)
                    Finally
                        'a
                    End Try
                Next
            End With
        End Sub

    End Module
End Namespace