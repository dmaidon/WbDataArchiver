Imports System.Net

Namespace Modules
    Friend Module MiscellaneousRoutines

        Friend Function Gwd(ds As String) As String
            Try
                Using wc As New WebClient With {
    .UseDefaultCredentials = True,
    .Credentials = New NetworkCredential(WbSet(0), WbSet(1))
    }
                    Return wc.DownloadString(New Uri($"http://{WbSet(2)}/cgi-bin/template.cgi?template=[{ds}]&contenttype=text/plain;charset=iso-8859-1"))
                End Using
            Catch ex As Exception When TypeOf ex Is ArgumentNullException OrElse TypeOf ex Is WebException OrElse TypeOf ex Is NotSupportedException
                FrmMain.Rtb.AppendText(ex.Message & ex.StackTrace & ex.Source & vbLf)
                Return "*"
            Finally
                'a
            End Try
        End Function

        Friend Function CalculateCloudBase(T As Double, dp As Double) As Double
            ''returns altitude in feet
            Return ((T - dp) / 4.4 * 1000)
        End Function

        Friend Function Date2Unix(dateTime As Date) As Long
            Try
                Return CLng(Fix(dateTime.Subtract(New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds))
            Catch ex As Exception
                FrmMain.Rtb.AppendText(ex.Message & ex.StackTrace & ex.Source & vbLf)
                Return 0
            Finally
                'a
            End Try
        End Function

        Friend Function GetFirstDayOfNextMonth() As Date
            Return New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month)).AddDays(1).AddSeconds(1)
        End Function

        Friend Function GetLastDayOfMonth() As Date
            Return New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month)).AddHours(23).AddMinutes(59).AddSeconds(58)
        End Function

    End Module
End Namespace