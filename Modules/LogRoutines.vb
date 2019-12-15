Imports System.IO

Namespace Modules
    Friend Module LogRoutines
        Friend Sub StartLogFile()
            LogFile = Path.Combine(LogDir, $"wbda-{Now.ToShortDateString.Replace("/", "")}_{TimesRun}.log")
            PrintLog($"Timesrun: {TimesRun}{vbLf}Filename: {LogFile}{vbLf}")
        End Sub

        Friend Sub SaveLogs(Optional saveKey As Boolean = True)
            If saveKey Then
                PrintLog($"¥{vbLf}")
            End If
            FrmMain.RtbLog.SaveFile(LogFile, RichTextBoxStreamType.PlainText)
        End Sub

        Friend Sub PrintLog(txt As String)
            FrmMain.RtbLog.AppendText(txt)
        End Sub

        Friend Sub PrintErr(msg As String, trg As String, stk As String, src As String, Optional gbe As String = "- Empty -")
            Dim errSeparator = $"{StrDup(15, "-"c)} ERROR {StrDup(15, "-"c)}"
            Dim em =
                $"   Error:{vbLf}{msg}{vbLf}{vbLf}   Location:{vbLf}{trg}{vbLf}{vbLf}   Trace:{vbLf}{stk}{vbLf}{vbLf}   Source:{vbLf}{src}{vbLf}{vbLf}   Base Exception:{vbLf}{ _
                    gbe}{vbLf}"
            With FrmMain
                .RtbLog.AppendText($"{vbLf}{errSeparator}{vbLf}Time: {Now:T}{vbLf}")
                .RtbLog.AppendText(em)
                .RtbLog.AppendText($"{Separator}{vbLf}{vbLf}")
            End With
        End Sub
    End Module
End Namespace