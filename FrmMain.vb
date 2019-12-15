Imports System.ComponentModel
Imports System.Globalization
Imports System.Timers
Imports System.Windows.Forms.VisualStyles
Imports WbDataArchiver.Modules

Friend Class FrmMain
    'https://www.meteobridge.com/wiki/index.php/Templates

    Private _intMid As Long
    Private _intMo As Date

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrintLog($"Log file started: {Now:F}{vbLf}")
        Application.VisualStyleState = VisualStyleState.NoneEnabled
        UpgradeMySettings()
        CreateProgramFolders()
        LoadWbSettings()
        StartLogFile()
        Text = My.Resources.title
        TsslCpy.Text = My.Resources.cpy
        TsslVer.Text = Application.ProductVersion

        WriteCurrentData()
        'set the current data timer interval and start the timer
        TmrDataUpdate.Interval = TimeSpan.FromSeconds(CInt(WbSet(3))).TotalMilliseconds
        TmrDataUpdate.Start()

        'set the update information for the current data countdown
        PrintLog($"Current timer set: {WbSet(3)} seconds{vbLf}")
        CurDuration = New TimeSpan(0, 0, 0, CInt(WbSet(3)))
        CurUpdate = Date.Now + CurDuration

        SetMidnightRollover()
        SetMonthlyRollover()
        SaveLogs()
    End Sub

    ''' <summary>
    '''     Manually update application settings
    ''' </summary>
    Private Shared Sub UpgradeMySettings()
        'https://stackoverflow.com/questions/1702260/losing-vb-net-my-settings-with-each-new-clickonce-deployment-release
        If My.Settings.MustUpgrade Then
            My.Settings.Upgrade()
            My.Settings.MustUpgrade = False
            My.Settings.Save()
        End If
    End Sub

    Private Sub TmrClock_Tick(sender As Object, e As EventArgs) Handles TmrClock.Tick
        TsslClock.Text = $"{Now:T}"

        'countdown to next current data update
        If TmrDataUpdate.Enabled Then
            TsslCU.Text = String.Format(CultureInfo.CurrentCulture, TsslCU.Tag.ToString, $"{DateDiff(DateInterval.Second, Date.Now, CurUpdate):D0}")
        End If

        'countdown to midnight data update for yesterday's data
        If TmrMidnight.Enabled Then
            TsslMU.Text = If _
                (DateDiff(DateInterval.Minute, My.Computer.Clock.LocalTime, MidUpdate) < 1,
                    String.Format(CultureInfo.CurrentCulture, TsslMU.Tag.ToString, $"{DateDiff(DateInterval.Second, Date.Now, MidUpdate):D0}"),
                    String.Format(CultureInfo.CurrentCulture, TsslMU.Tag.ToString, $"{DateDiff(DateInterval.Minute, Date.Now, MidUpdate):D0}"))
        End If

        'countdown to monthly update performed on last day of month at 11:58:50 pm
        Dim t = MoEndTime.Subtract(Now)
        TsslYU.ToolTipText = $"{t.Days} Days {t.Hours} Hrs {t.Minutes} min {t.Seconds} secs"

        If t.TotalSeconds <= 0 AndAlso t.TotalMilliseconds <= 0 Then
            WriteMonthlyData()
            SetMonthlyRollover()
        Else
            TsslYU.Text = If _
                (t.TotalMinutes <= 1, String.Format(CultureInfo.CurrentCulture, TsslYU.Tag.ToString, $"{t.TotalSeconds:N0}"),
                    String.Format(CultureInfo.CurrentCulture, TsslYU.Tag.ToString, $"{t.TotalMinutes:N0}"))
        End If
    End Sub

    Private Shared Sub TmrDataUpdate_Elapsed(sender As Object, e As ElapsedEventArgs) Handles TmrDataUpdate.Elapsed
        WriteCurrentData()
        CurDuration = New TimeSpan(0, 0, 0, CInt(WbSet(3)))
        CurUpdate = Date.Now + CurDuration
        SaveLogs(False)
    End Sub

    Private Sub MidnightUpdate()
        'clear the textbox and start a new day
        RtbLog.Clear()
        WriteYesterdayData()
        PrintLog($"Midnight rollover completed: {Now:F}{vbLf}")
    End Sub

    Private Sub SetMidnightRollover()
        Dim st = New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 1).AddDays(1)
        _intMid = Date2Unix(st) - Date2Unix(Now)
        MidDuration = New TimeSpan(0, 0, 0, CInt(_intMid))
        MidUpdate = Date.Now + MidDuration
        TmrMidnight.Interval = TimeSpan.FromSeconds(_intMid).TotalMilliseconds
        PrintLog($"Midnight timer set: {_intMid} seconds{vbLf}")
        TmrMidnight.Start()
    End Sub

    Private Sub SetMonthlyRollover()
        _intMo = GetLastDayOfMonth()
        MoEndTime = New DateTime(_intMo.Year, _intMo.Month, _intMo.Day, _intMo.Hour, _intMo.Minute, _intMo.Second, 0)
        PrintLog($"End of Month time set: {_intMo}{vbLf}")
    End Sub

    Private Sub ChkShowPw_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowPw.CheckedChanged
        TxtPassword.UseSystemPasswordChar = ChkShowPw.Checked
    End Sub

    Private Sub TmrMidnight_Elapsed(sender As Object, e As ElapsedEventArgs) Handles TmrMidnight.Elapsed
        TmrMidnight.Stop()
        TmrDataUpdate.Stop()
        MidnightUpdate()
        SetMidnightRollover()
        CreateProgramFolders()
        WriteCurrentData()
        CurDuration = New TimeSpan(0, 0, 0, CInt(WbSet(3)))
        CurUpdate = Date.Now + CurDuration
        TmrDataUpdate.Start()
        SaveLogs()
    End Sub

    Private Shared Sub FrmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'save application settings
        My.Settings.Save()
        PrintLog($"Program closed: {Now:F}{vbLf}")
        SaveLogs()
    End Sub
End Class