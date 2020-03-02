Imports System.Globalization
Imports System.IO

Namespace Modules
    Module MonthRoutines
        Private _md As String
        Private ReadOnly MData As New List(Of String)

        Friend Async Sub WriteMonthlyData()
            'write information to YYYY folder (Ex: /Archives/2019)
            _md = If(Now.Day = 1, Path.Combine(ArcDirYr, $"{Now.AddDays(-1).ToString("yyyy", CultureInfo.CurrentCulture)}.csv"), Path.Combine(ArcDirYr, $"{Now.ToString("yyyy", CultureInfo.CurrentCulture)}.csv"))
            Dim provider = CultureInfo.InvariantCulture
            Const fmt = "yyyyMMddHHmmss"
            Const f2 = "MMM d @ H:mm"
            Dim a As String

            Try
                MData.Add($"{Now.ToString("MMMM", CultureInfo.CurrentCulture)}")
                MData.Add(Gwd("th*temp-mmax=F.1:0"))
                a = Gwd("th*temp-mmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                MData.Add(a)

                MData.Add(Gwd("th*temp-mmin=F.1:0"))
                a = Gwd("th*temp-mmintime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                MData.Add(a)

                MData.Add(Gwd("th*hum-mmax:0"))
                MData.Add(Gwd("th*hum-mmin:0"))
                MData.Add(Gwd("th*dew-mmax=F.1:0"))
                MData.Add(Gwd("th*dew-mmin=F.1:0"))
                MData.Add(Gwd("th*heatindex-mmax=F.1:0"))
                a = Gwd("th*heatindex-mmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                MData.Add(a)

                MData.Add(Gwd("thb*press-mmax:0"))
                MData.Add(Gwd("thb*press-mmin:0"))
                MData.Add(Gwd("thb*seapress-mmax:0"))
                MData.Add(Gwd("thb*seapress-mmin:0"))
                MData.Add(Gwd("wind*wind-mmax=mph.1:0"))
                a = Gwd("wind*wind-mmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                MData.Add(a)

                MData.Add(Gwd("wind*avgwind-mavg=mph.1:0"))
                MData.Add(Gwd("wind*dir-mavg:0"))
                MData.Add(Gwd("wind*chill-mmin=F.1:0"))
                a = Gwd("wind*chill-mmintime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                MData.Add(a)

                MData.Add(Gwd("rain*total-monthsum=in.2:0"))
                MData.Add(Gwd("rain*total-yearsum=in.2:0"))
                MData.Add(Gwd("uv*index-mmax:0"))
                a = Gwd("uv*index-mmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                MData.Add(a)

                MData.Add(Gwd("sol*rad-mmax:0"))
                a = Gwd("sol*rad-mmaxtime:*")
                a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
                MData.Add(a)

                Dim aa = ""
                If Not File.Exists(_md) Then
                    aa = $"#Year: {Now.AddDays(-1).ToString("yyyy", CultureInfo.CurrentCulture)}{vbLf _
                        }Month,High Temp,High Temp Date,Low Temp,Low Temp Date,Max Humidity,Min Humidity,Max Dew Point,Min Dewpoint,Max Heat Index,Max Heat Index Date,Max Baro Press,Min Baro Press,Max Sea Level Press,Min Sea level Press,Max Wind Spd,Max Wind Spd Date,Average Wind Speed,Wind Direction,Min Wind Chill,Min Wind Chill Date,Rain Total Month,Rain Total Year,Max UV Index,Max UV Index Date, Max SolarRad,Max SolarRad Date{ _
                        vbLf}"
                End If
                Using w As New StreamWriter(_md, True)
                    Await w.WriteAsync(aa & String.Join(",", MData) & vbLf).ConfigureAwait(True)
                    MData.Clear()
                End Using
                PrintLog($"Monthly data updated @ {Now:T}{vbLf}")
            Catch ex As Exception
                PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.Source, ex.GetBaseException.ToString)
            Finally
                'a
            End Try
        End Sub

    End Module
End Namespace