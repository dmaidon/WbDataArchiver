Imports System.IO

Namespace Modules
    Friend Module SettingsRoutines

        Friend Sub LoadWbSettings()
            TimesRun = My.Settings.TimesRun + 1
            My.Settings.TimesRun = TimesRun
            My.Settings.Save()

            Dim setFile As String = Path.Combine(SetDir, "settings.csv")
            Using reader As New FileIO.TextFieldParser(setFile)
                With reader
                    .TextFieldType = FileIO.FieldType.Delimited
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
                With FrmMain
                    .Rtb.AppendText($"Settings file ({setFile}) read and loaded into memory.{vbLf}{vbLf}")
                    .Rtb.AppendText($"Current update interval: {WbSet(3)} seconds{vbLf}")
                    .TsslTr.Text = String.Format(.TsslTr.Tag.ToString, TimesRun)
                End With

            End Using
        End Sub

    End Module
End Namespace