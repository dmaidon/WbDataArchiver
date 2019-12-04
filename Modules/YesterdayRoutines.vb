Imports System.Globalization
Imports System.IO

Namespace Modules
    Friend Module YesterdayRoutines
        Private _yd As String
        Private ReadOnly YData As New List(Of String)

        Friend Async Sub WriteYesterdayData()
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Const fmt = "yyyyMMddHHmmss"
            Const f2 = "H:mm"
            Dim a As String

            Try
                _yd = Path.Combine(ArcDirDaily, $"{(Now.ToString("MMMyyyy", CultureInfo.CurrentCulture))}.csv")
                YData.Add($"{Now.AddDays(-1).ToString("MM-dd-yyyy", CultureInfo.CurrentCulture)}")
                YData.Add(Gwd("th*temp-ydmax=F.1:*"))
                a = Gwd("th*temp-ydmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                YData.Add(a)

                YData.Add(Gwd("th*temp-ydmin=F.1:*"))
                a = Gwd("th*temp-ydmintime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                YData.Add(a)

                YData.Add(Gwd("th*hum-ydmax:*"))
                YData.Add(Gwd("th*hum-ydmin:*"))
                YData.Add(Gwd("th*dew-ydmax=F.1:*"))
                YData.Add(Gwd("th*dew-ydmin=F.1:*"))
                YData.Add(Gwd("th*heatindex-ydmax=F.1:*"))
                a = Gwd("th*heatindex-ydmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                YData.Add(a)

                YData.Add(Gwd("thb*press-ydmax:*"))
                YData.Add(Gwd("thb*press-ydmin:*"))
                YData.Add(Gwd("thb*seapress-ydmax:*"))
                YData.Add(Gwd("thb*seapress-ydmin:*"))
                YData.Add(Gwd("wind*wind-ydmax=mph.1:*"))
                a = Gwd("wind*wind-ydmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                YData.Add(a)

                YData.Add(Gwd("wind*avgwind-ydavg=mph.1:*"))
                YData.Add(Gwd("wind*dir-ydavg:*"))
                YData.Add(Gwd("wind*chill-ydmin=F.1:*"))
                a = Gwd("wind*chill-ydmintime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                YData.Add(a)

                YData.Add(Gwd("rain*rate-ydmax=in.3:*"))
                YData.Add(Gwd("rain*total-ydaysum=in.3:*"))
                YData.Add(Gwd("uv*index-ydmax:*"))
                a = Gwd("uv*index-ydmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                YData.Add(a)

                YData.Add(Gwd("sol*rad-ydmax:*"))
                a = Gwd("sol*rad-ydmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                YData.Add(a)

                YData.Add(Gwd("rain*total-sum24h=in.2:0"))

                Dim aa = ""
                If Not File.Exists(_yd) Then
                    aa =
                        "Date,High Temp,High Temp Time,Low Temp,Low Temp Time,Max Humidity,Min Humidity,Max Dew Point,Min Dewpoint,Max Heat Index,Max Heat Index Time,Max Baro Press,Min Baro Press,Max Sea Level Press,Min Sea level Press,Max Wind Spd,Max Wind Spd Time,Average Wind Speed,Wind Direction,Min Wind Chill,Min Wind Chill Time,Rain Rate,Rain Total,Max UV Index,Max UV Index Time, Max SolarRad,Max SolarRad Time, Rain Total 24Hrs" _
                        & vbLf
                End If

                Using w As New StreamWriter(_yd, True)
                    Await w.WriteAsync(aa & String.Join(",", YData) & vbLf)
                    YData.Clear()
                End Using
                FrmMain.Rtb.AppendText($"Yesterday data updated @ {Now:T}{vbLf}")
            Catch ex As Exception
                'PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.Source, ex.GetBaseException.ToString)
                FrmMain.Rtb.AppendText(ex.Message & ex.StackTrace & ex.Source & vbLf)
            Finally
                'a
            End Try
        End Sub

    End Module
End Namespace