<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TsslVer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslCpy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslClock = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.TsslTr = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslCU = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslMU = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslYU = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TmrDataUpdate = New System.Timers.Timer()
        Me.TmrClock = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkShowPw = New System.Windows.Forms.CheckBox()
        Me.TxtIP = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TmrMidnight = New System.Timers.Timer()
        Me.Rtb = New System.Windows.Forms.RichTextBox()
        Me.TmrMonth = New System.Timers.Timer()
        Me.StatusStrip1.SuspendLayout
        Me.StatusStrip2.SuspendLayout
        CType(Me.TmrDataUpdate,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox1.SuspendLayout
        CType(Me.TmrMidnight,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TmrMonth,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 7!)
        Me.StatusStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsslVer, Me.TsslCpy, Me.TsslClock})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 180)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = true
        Me.StatusStrip1.Size = New System.Drawing.Size(553, 22)
        Me.StatusStrip1.SizingGrip = false
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TsslVer
        '
        Me.TsslVer.Name = "TsslVer"
        Me.TsslVer.Size = New System.Drawing.Size(18, 17)
        Me.TsslVer.Text = "ver"
        '
        'TsslCpy
        '
        Me.TsslCpy.Font = New System.Drawing.Font("Segoe UI", 7!, System.Drawing.FontStyle.Italic)
        Me.TsslCpy.ForeColor = System.Drawing.Color.Maroon
        Me.TsslCpy.Name = "TsslCpy"
        Me.TsslCpy.Size = New System.Drawing.Size(503, 17)
        Me.TsslCpy.Spring = true
        Me.TsslCpy.Text = "cpy"
        '
        'TsslClock
        '
        Me.TsslClock.Name = "TsslClock"
        Me.TsslClock.Size = New System.Drawing.Size(17, 17)
        Me.TsslClock.Text = "tm"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Font = New System.Drawing.Font("Segoe UI", 7!)
        Me.StatusStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsslTr, Me.TsslCU, Me.TsslMU, Me.TsslYU})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 158)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.ShowItemToolTips = true
        Me.StatusStrip2.Size = New System.Drawing.Size(553, 22)
        Me.StatusStrip2.SizingGrip = false
        Me.StatusStrip2.TabIndex = 1
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'TsslTr
        '
        Me.TsslTr.Name = "TsslTr"
        Me.TsslTr.Size = New System.Drawing.Size(12, 17)
        Me.TsslTr.Tag = "Tr: {0}"
        Me.TsslTr.Text = "~"
        '
        'TsslCU
        '
        Me.TsslCU.ForeColor = System.Drawing.Color.Maroon
        Me.TsslCU.Name = "TsslCU"
        Me.TsslCU.Size = New System.Drawing.Size(12, 17)
        Me.TsslCU.Tag = "CurUp: {0}"
        Me.TsslCU.Text = "~"
        '
        'TsslMU
        '
        Me.TsslMU.ForeColor = System.Drawing.Color.Purple
        Me.TsslMU.Name = "TsslMU"
        Me.TsslMU.Size = New System.Drawing.Size(12, 17)
        Me.TsslMU.Tag = "MidUp: {0}"
        Me.TsslMU.Text = "~"
        '
        'TsslYU
        '
        Me.TsslYU.ForeColor = System.Drawing.Color.SeaGreen
        Me.TsslYU.Name = "TsslYU"
        Me.TsslYU.Size = New System.Drawing.Size(12, 17)
        Me.TsslYU.Tag = "YrUp: {0}"
        Me.TsslYU.Text = "~"
        '
        'TmrDataUpdate
        '
        Me.TmrDataUpdate.SynchronizingObject = Me
        '
        'TmrClock
        '
        Me.TmrClock.Enabled = true
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Controls.Add(Me.ChkShowPw)
        Me.GroupBox1.Controls.Add(Me.TxtIP)
        Me.GroupBox1.Controls.Add(Me.TxtPassword)
        Me.GroupBox1.Controls.Add(Me.TxtName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(137, 143)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Weatherbridge Login"
        '
        'ChkShowPw
        '
        Me.ChkShowPw.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkShowPw.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkShowPw.Checked = true
        Me.ChkShowPw.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkShowPw.FlatAppearance.BorderSize = 0
        Me.ChkShowPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkShowPw.Image = Global.WbDataArchiver.My.Resources.Resources.eye_icon
        Me.ChkShowPw.Location = New System.Drawing.Point(113, 74)
        Me.ChkShowPw.Name = "ChkShowPw"
        Me.ChkShowPw.Size = New System.Drawing.Size(18, 18)
        Me.ChkShowPw.TabIndex = 3
        Me.ChkShowPw.UseVisualStyleBackColor = true
        '
        'TxtIP
        '
        Me.TxtIP.Location = New System.Drawing.Point(7, 113)
        Me.TxtIP.Name = "TxtIP"
        Me.TxtIP.Size = New System.Drawing.Size(106, 18)
        Me.TxtIP.TabIndex = 2
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(7, 74)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(106, 18)
        Me.TxtPassword.TabIndex = 1
        Me.TxtPassword.UseSystemPasswordChar = true
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(7, 35)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(106, 18)
        Me.TxtName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(7, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "IP Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(7, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'TmrMidnight
        '
        Me.TmrMidnight.SynchronizingObject = Me
        '
        'Rtb
        '
        Me.Rtb.BackColor = System.Drawing.SystemColors.Info
        Me.Rtb.Location = New System.Drawing.Point(156, 8)
        Me.Rtb.Name = "Rtb"
        Me.Rtb.ReadOnly = true
        Me.Rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.Rtb.ShowSelectionMargin = true
        Me.Rtb.Size = New System.Drawing.Size(390, 143)
        Me.Rtb.TabIndex = 3
        Me.Rtb.TabStop = false
        Me.Rtb.Text = ""
        '
        'TmrMonth
        '
        Me.TmrMonth.SynchronizingObject = Me
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 202)
        Me.Controls.Add(Me.Rtb)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.WbDataArchiver.My.MySettings.Default, "MainFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Location = Global.WbDataArchiver.My.MySettings.Default.MainFormLocation
        Me.MaximizeBox = false
        Me.Name = "FrmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StatusStrip1.ResumeLayout(false)
        Me.StatusStrip1.PerformLayout
        Me.StatusStrip2.ResumeLayout(false)
        Me.StatusStrip2.PerformLayout
        CType(Me.TmrDataUpdate,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.TmrMidnight,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TmrMonth,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TsslVer As ToolStripStatusLabel
    Friend WithEvents TsslCpy As ToolStripStatusLabel
    Friend WithEvents TsslClock As ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents TmrDataUpdate As Timers.Timer
    Friend WithEvents TmrClock As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtIP As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ChkShowPw As CheckBox
    Friend WithEvents TmrMidnight As Timers.Timer
    Friend WithEvents TsslTr As ToolStripStatusLabel
    Friend WithEvents TsslMU As ToolStripStatusLabel
    Friend WithEvents TsslCU As ToolStripStatusLabel
    Friend WithEvents Rtb As RichTextBox
    Friend WithEvents TmrMonth As Timers.Timer
    Friend WithEvents TsslYU As ToolStripStatusLabel
End Class
