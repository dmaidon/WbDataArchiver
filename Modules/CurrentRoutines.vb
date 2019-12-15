Imports System.Globalization
Imports System.IO

Namespace Modules
    Module CurrentRoutines
        Private _cd As String
        Private ReadOnly DData As New List(Of String)

        Friend Async Sub WriteCurrentData()
            'write information to YYYY folder (Ex: /Archives/2019/12212019.csv)
            Try
                _cd = Path.Combine(ArcDirYr, $"{Now.ToString("MMddyyyy", CultureInfo.CurrentCulture)}.csv")
                DData.Add($"{Now.ToString("HH:mm", CultureInfo.CurrentCulture)}")
                DData.Add(Gwd("th*temp-act=F.1:*"))
                DData.Add(Gwd("th*hum-act:*"))
                DData.Add(Gwd("th*dew-act=F.1:*"))
                DData.Add(Gwd("th*heatindex-act=F.1:*"))
                DData.Add(Gwd("thb*press-act:*"))
                DData.Add(Gwd("thb*seapress-act:*"))
                DData.Add(Gwd("wind*wind-act=mph.1:*"))
                DData.Add(Gwd("wind*avgwind-act=mph.1:*"))
                DData.Add(Gwd("wind*dir-act:*"))
                DData.Add(Gwd("wind*chill-act=F.1:*"))
                DData.Add(Gwd("rain*rate-act=in.3:*"))
                DData.Add(Gwd("rain*total-act=in.3:*"))
                DData.Add(Gwd("uv*index-act:0"))
                DData.Add(Gwd("sol*rad-act:0"))
                DData.Add(Gwd("sol*evo-act=in.3:0"))
                DData.Add($"{CalculateCloudBase(CDbl(DData(1)), CDbl(DData(3))):F2}")
                DData.Add(Gwd("rain*total-sumday=in.2:0"))

                Dim aa = ""
                If Not File.Exists(_cd) Then
                    aa = $"#Date: {Now.ToString("dddd MMMM d yyyy", CultureInfo.CurrentCulture)}{vbLf _
                        }Time,Temp,Humidity,Dewpoint,Heat Index,Baro Press,Sea Level Press,Wind Spd,Avg Wind Spd,Wind Dir,Wind Chill,Rain Rate,Rain Total Year,UV Index,SolarRad,Evapo,Cloud Base, Rain Total Today{ _
                        vbLf}"
                End If
                Using w As New StreamWriter(_cd, True)
                    Await w.WriteAsync(aa & String.Join(",", DData) & vbLf).ConfigureAwait(True)
                    DData.Clear()
                End Using
                PrintLog($"Current data updated @ {Now:T}{vbLf}")
            Catch ex As Exception
                PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.Source, ex.GetBaseException.ToString)
            Finally
                'a
            End Try
        End Sub
    End Module
End Namespace