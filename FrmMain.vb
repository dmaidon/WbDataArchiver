Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles
Imports WbDataArchiver.Modules

Friend Class FrmMain
    'https://www.meteobridge.com/wiki/index.php/Templates

    Private _intMid As Long
    Private _intMo As Date

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.VisualStyleState = VisualStyleState.NoneEnabled
        UpgradeMySettings()
        CreateProgramFolders()
        Text = My.Resources.title
        TsslCpy.Text = CPY
        TsslVer.Text = Application.ProductVersion
        LoadWbSettings()

        WriteCurrentData()
        TmrDataUpdate.Interval = CInt(WbSet(3)) * 1000
        TmrDataUpdate.Start()
        CurDuration = New TimeSpan(0, 0, 0, CInt(WbSet(3)))
        CurUpdate = Date.Now + CurDuration

        SetMidnightRollover()
        SetMonthlyRollover()
        'MsgBox(GetLastDayOfMonth)
    End Sub

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

        If TmrDataUpdate.Enabled Then
            TsslCU.Text = String.Format(TsslCU.Tag.ToString, $"{DateDiff(DateInterval.Second, Date.Now, CurUpdate):D0}")
        End If

        If TmrMidnight.Enabled Then
            TsslMU.Text = If _
                (DateDiff(DateInterval.Minute, My.Computer.Clock.LocalTime, MidUpdate) < 1,
                 String.Format(TsslMU.Tag.ToString, $"{DateDiff(DateInterval.Second, Date.Now, MidUpdate):D0}"),
                 String.Format(TsslMU.Tag.ToString, $"{DateDiff(DateInterval.Minute, Date.Now, MidUpdate):D0}"))
        End If

        Dim t = MoEndTime.Subtract(Now)
        TsslYU.ToolTipText = $"{t.Days} Days {t.Hours} Hrs {t.Minutes} min {t.Seconds} secs"

        If t.TotalSeconds <= 0 AndAlso t.TotalMilliseconds <= 0 Then
            WriteMonthlyData()
            SetMonthlyRollover()
        Else
            TsslYU.Text = If(t.TotalMinutes <= 1,
                String.Format(TsslYU.Tag.ToString, $"{t.TotalSeconds:N0}"),
                String.Format(TsslYU.Tag.ToString, $"{t.TotalMinutes:N0}"))
        End If
    End Sub

    Private Shared Sub TmrDataUpdate_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TmrDataUpdate.Elapsed
        WriteCurrentData()
        CurDuration = New TimeSpan(0, 0, 0, CInt(WbSet(3)))
        CurUpdate = Date.Now + CurDuration
    End Sub

    Private Shared Sub MidnightUpdate()
        WriteYesterdayData()
    End Sub

    Private Sub SetMidnightRollover()
        Dim st = New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 1).AddDays(1)
        _intMid = Date2Unix(st) - Date2Unix(Now)
        MidDuration = New TimeSpan(0, 0, 0, CInt(_intMid))
        MidUpdate = Date.Now + MidDuration
        TmrMidnight.Interval = TimeSpan.FromSeconds(_intMid).TotalMilliseconds
        TmrMidnight.Start()
    End Sub

    Private Sub SetMonthlyRollover()
        '_intMo = GetFirstDayOfNextMonth() '- Date2Unix(Now)
        _intMo = GetLastDayOfMonth()
        MoEndTime = New DateTime(_intMo.Year, _intMo.Month, _intMo.Day, _intMo.Hour, _intMo.Minute, _intMo.Second, 0)
    End Sub

    Private Sub ChkShowPw_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowPw.CheckedChanged
        TxtPassword.UseSystemPasswordChar = ChkShowPw.Checked
    End Sub

    Private Sub TmrMidnight_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TmrMidnight.Elapsed
        TmrMidnight.Stop()
        MidnightUpdate()
        SetMidnightRollover()
    End Sub

    Private Shared Sub FrmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.Save()
    End Sub

End Class