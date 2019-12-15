Imports System.Globalization
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Namespace Modules
    Friend Module SettingsRoutines
        Friend Sub LoadWbSettings()
            TimesRun = My.Settings.TimesRun + 1
            My.Settings.TimesRun = TimesRun
            My.Settings.Save()
            Dim setFile = Path.Combine(SetDir, "settings.csv")

            Try
                Using reader As New TextFieldParser(setFile)
                    With reader
                        .TextFieldType = FieldType.Delimited
                        .SetDelimiters(",")
                        .TrimWhiteSpace = True
                        .CommentTokens = {"#"}
                    End With
                    Dim curRow As String()
                    While Not reader.EndOfData
                        curRow = reader.ReadFields
                        WbSet.Add(curRow(0))
                        WbSet.Add(curRow(1))
                        WbSet.Add(curRow(2))
                        WbSet.Add(curRow(3))
                    End While
                    With FrmMain
                        .TxtName.Text = WbSet(0)
                        .TxtPassword.Text = WbSet(1)
                        .TxtIP.Text = WbSet(2)
                    End With
                    FrmMain.TsslTr.Text = String.Format(CultureInfo.CurrentCulture, FrmMain.TsslTr.Tag.ToString, TimesRun)
                End Using
            Catch ex As Exception
                PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.Source, ex.GetBaseException.ToString)
            Finally
                'a
            End Try
            PrintLog($"Settings file ({setFile}) read and loaded into memory.{vbLf}{vbLf}")
            PrintLog($"Current update interval: {WbSet(3)} seconds{vbLf}")
        End Sub
    End Module
End Namespace