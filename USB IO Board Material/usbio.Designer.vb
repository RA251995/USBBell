<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class usbio
    Inherits MaterialSkin.Controls.MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usbio))
        Me.Status = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerClock = New System.Windows.Forms.Timer(Me.components)
        Me.TimerClock2 = New System.Windows.Forms.Timer(Me.components)
        Me.lBell = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MaterialTabSelector1 = New MaterialSkin.Controls.MaterialTabSelector()
        Me.MaterialTabControl1 = New MaterialSkin.Controls.MaterialTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvTimings = New MaterialSkin.Controls.MaterialListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBell = New MaterialSkin.Controls.MaterialListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bTest = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bDeleteBell = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.bAddBell = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.lvBell_Mod = New MaterialSkin.Controls.MaterialListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvTimings_Mod = New MaterialSkin.Controls.MaterialListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nupDuration = New System.Windows.Forms.NumericUpDown()
        Me.dtpTime = New System.Windows.Forms.DateTimePicker()
        Me.bSave = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.lTime = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MaterialTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.nupDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status.ForeColor = System.Drawing.Color.White
        Me.Status.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Status.Location = New System.Drawing.Point(7, 396)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(161, 18)
        Me.Status.TabIndex = 0
        Me.Status.Text = "USB BELL DISCONNECTED"
        Me.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'TimerClock
        '
        Me.TimerClock.Enabled = True
        Me.TimerClock.Interval = 990
        '
        'TimerClock2
        '
        Me.TimerClock2.Enabled = True
        '
        'lBell
        '
        Me.lBell.AutoSize = True
        Me.lBell.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lBell.ForeColor = System.Drawing.Color.White
        Me.lBell.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lBell.Location = New System.Drawing.Point(315, 397)
        Me.lBell.Name = "lBell"
        Me.lBell.Size = New System.Drawing.Size(32, 18)
        Me.lBell.TabIndex = 71
        Me.lBell.Text = "OFF"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(281, 397)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 18)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "BELL"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(0, -37)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(434, 463)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        '
        'MaterialTabSelector1
        '
        Me.MaterialTabSelector1.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.MaterialTabSelector1.BaseTabControl = Me.MaterialTabControl1
        Me.MaterialTabSelector1.Depth = 0
        Me.MaterialTabSelector1.Location = New System.Drawing.Point(434, 26)
        Me.MaterialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialTabSelector1.Name = "MaterialTabSelector1"
        Me.MaterialTabSelector1.Size = New System.Drawing.Size(367, 38)
        Me.MaterialTabSelector1.TabIndex = 74
        Me.MaterialTabSelector1.Text = "MaterialTabSelector1"
        '
        'MaterialTabControl1
        '
        Me.MaterialTabControl1.Controls.Add(Me.TabPage1)
        Me.MaterialTabControl1.Controls.Add(Me.TabPage2)
        Me.MaterialTabControl1.Depth = 0
        Me.MaterialTabControl1.Location = New System.Drawing.Point(434, 66)
        Me.MaterialTabControl1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialTabControl1.Name = "MaterialTabControl1"
        Me.MaterialTabControl1.SelectedIndex = 0
        Me.MaterialTabControl1.Size = New System.Drawing.Size(367, 448)
        Me.MaterialTabControl1.TabIndex = 75
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lBell)
        Me.TabPage1.Controls.Add(Me.lvTimings)
        Me.TabPage1.Controls.Add(Me.lvBell)
        Me.TabPage1.Controls.Add(Me.bTest)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Status)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(359, 422)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "::::"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvTimings
        '
        Me.lvTimings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvTimings.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lvTimings.Depth = 0
        Me.lvTimings.Font = New System.Drawing.Font("Times New Roman", 24.0!)
        Me.lvTimings.FullRowSelect = True
        Me.lvTimings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvTimings.Location = New System.Drawing.Point(6, 5)
        Me.lvTimings.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.lvTimings.MouseState = MaterialSkin.MouseState.OUT
        Me.lvTimings.MultiSelect = False
        Me.lvTimings.Name = "lvTimings"
        Me.lvTimings.OwnerDraw = True
        Me.lvTimings.Size = New System.Drawing.Size(149, 346)
        Me.lvTimings.TabIndex = 77
        Me.lvTimings.UseCompatibleStateImageBehavior = False
        Me.lvTimings.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "PRESETS"
        Me.ColumnHeader3.Width = 149
        '
        'lvBell
        '
        Me.lvBell.BackColor = System.Drawing.Color.White
        Me.lvBell.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvBell.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader7})
        Me.lvBell.Depth = 0
        Me.lvBell.Font = New System.Drawing.Font("Times New Roman", 24.0!)
        Me.lvBell.FullRowSelect = True
        Me.lvBell.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvBell.Location = New System.Drawing.Point(161, 6)
        Me.lvBell.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.lvBell.MouseState = MaterialSkin.MouseState.OUT
        Me.lvBell.MultiSelect = False
        Me.lvBell.Name = "lvBell"
        Me.lvBell.OwnerDraw = True
        Me.lvBell.Size = New System.Drawing.Size(200, 387)
        Me.lvBell.TabIndex = 76
        Me.lvBell.UseCompatibleStateImageBehavior = False
        Me.lvBell.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "TIME"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DURATION"
        Me.ColumnHeader2.Width = 100
        '
        'bTest
        '
        Me.bTest.Depth = 0
        Me.bTest.Location = New System.Drawing.Point(8, 358)
        Me.bTest.MouseState = MaterialSkin.MouseState.HOVER
        Me.bTest.Name = "bTest"
        Me.bTest.Primary = True
        Me.bTest.Size = New System.Drawing.Size(149, 35)
        Me.bTest.TabIndex = 74
        Me.bTest.Text = "Test On"
        Me.bTest.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.bDeleteBell)
        Me.TabPage2.Controls.Add(Me.bAddBell)
        Me.TabPage2.Controls.Add(Me.lvBell_Mod)
        Me.TabPage2.Controls.Add(Me.lvTimings_Mod)
        Me.TabPage2.Controls.Add(Me.nupDuration)
        Me.TabPage2.Controls.Add(Me.dtpTime)
        Me.TabPage2.Controls.Add(Me.bSave)
        Me.TabPage2.ForeColor = System.Drawing.Color.White
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(359, 422)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ADD/MODIFY"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 308)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 18)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "DURATION"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(45, 277)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 18)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "TIME"
        '
        'bDeleteBell
        '
        Me.bDeleteBell.Depth = 0
        Me.bDeleteBell.Location = New System.Drawing.Point(180, 337)
        Me.bDeleteBell.MouseState = MaterialSkin.MouseState.HOVER
        Me.bDeleteBell.Name = "bDeleteBell"
        Me.bDeleteBell.Primary = True
        Me.bDeleteBell.Size = New System.Drawing.Size(173, 38)
        Me.bDeleteBell.TabIndex = 81
        Me.bDeleteBell.Text = "DELETE"
        Me.bDeleteBell.UseVisualStyleBackColor = True
        '
        'bAddBell
        '
        Me.bAddBell.Depth = 0
        Me.bAddBell.Location = New System.Drawing.Point(6, 337)
        Me.bAddBell.MouseState = MaterialSkin.MouseState.HOVER
        Me.bAddBell.Name = "bAddBell"
        Me.bAddBell.Primary = True
        Me.bAddBell.Size = New System.Drawing.Size(168, 38)
        Me.bAddBell.TabIndex = 80
        Me.bAddBell.Text = "ADD"
        Me.bAddBell.UseVisualStyleBackColor = True
        '
        'lvBell_Mod
        '
        Me.lvBell_Mod.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvBell_Mod.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8})
        Me.lvBell_Mod.Depth = 0
        Me.lvBell_Mod.Font = New System.Drawing.Font("Times New Roman", 24.0!)
        Me.lvBell_Mod.FullRowSelect = True
        Me.lvBell_Mod.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvBell_Mod.Location = New System.Drawing.Point(161, 6)
        Me.lvBell_Mod.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.lvBell_Mod.MouseState = MaterialSkin.MouseState.OUT
        Me.lvBell_Mod.MultiSelect = False
        Me.lvBell_Mod.Name = "lvBell_Mod"
        Me.lvBell_Mod.OwnerDraw = True
        Me.lvBell_Mod.Size = New System.Drawing.Size(198, 323)
        Me.lvBell_Mod.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvBell_Mod.TabIndex = 79
        Me.lvBell_Mod.UseCompatibleStateImageBehavior = False
        Me.lvBell_Mod.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "TIME"
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "DURATION"
        Me.ColumnHeader6.Width = 100
        '
        'lvTimings_Mod
        '
        Me.lvTimings_Mod.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvTimings_Mod.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.lvTimings_Mod.Depth = 0
        Me.lvTimings_Mod.Font = New System.Drawing.Font("Times New Roman", 24.0!)
        Me.lvTimings_Mod.FullRowSelect = True
        Me.lvTimings_Mod.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvTimings_Mod.Location = New System.Drawing.Point(6, 5)
        Me.lvTimings_Mod.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.lvTimings_Mod.MouseState = MaterialSkin.MouseState.OUT
        Me.lvTimings_Mod.MultiSelect = False
        Me.lvTimings_Mod.Name = "lvTimings_Mod"
        Me.lvTimings_Mod.OwnerDraw = True
        Me.lvTimings_Mod.Size = New System.Drawing.Size(149, 266)
        Me.lvTimings_Mod.TabIndex = 78
        Me.lvTimings_Mod.UseCompatibleStateImageBehavior = False
        Me.lvTimings_Mod.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "PRESETS"
        Me.ColumnHeader4.Width = 149
        '
        'nupDuration
        '
        Me.nupDuration.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupDuration.Location = New System.Drawing.Point(89, 308)
        Me.nupDuration.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nupDuration.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupDuration.Name = "nupDuration"
        Me.nupDuration.Size = New System.Drawing.Size(66, 23)
        Me.nupDuration.TabIndex = 7
        Me.nupDuration.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'dtpTime
        '
        Me.dtpTime.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtpTime.CustomFormat = "HH:mm"
        Me.dtpTime.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTime.Location = New System.Drawing.Point(89, 277)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(66, 23)
        Me.dtpTime.TabIndex = 6
        '
        'bSave
        '
        Me.bSave.Depth = 0
        Me.bSave.Location = New System.Drawing.Point(6, 381)
        Me.bSave.MouseState = MaterialSkin.MouseState.HOVER
        Me.bSave.Name = "bSave"
        Me.bSave.Primary = True
        Me.bSave.Size = New System.Drawing.Size(347, 36)
        Me.bSave.TabIndex = 5
        Me.bSave.Text = "SAVE"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'lTime
        '
        Me.lTime.AutoSize = True
        Me.lTime.Font = New System.Drawing.Font("Calibri Light", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTime.ForeColor = System.Drawing.Color.White
        Me.lTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lTime.Location = New System.Drawing.Point(169, 366)
        Me.lTime.Name = "lTime"
        Me.lTime.Size = New System.Drawing.Size(106, 45)
        Me.lTime.TabIndex = 62
        Me.lTime.Text = "00:00"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lTime)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 450)
        Me.Panel1.TabIndex = 76
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = ""
        Me.ColumnHeader8.Width = 18
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = ""
        Me.ColumnHeader7.Width = 20
        '
        'usbio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 513)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MaterialTabControl1)
        Me.Controls.Add(Me.MaterialTabSelector1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "usbio"
        Me.Sizable = False
        Me.Text = "USB Bell"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MaterialTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.nupDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Status As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents TimerClock As Timer
    Friend WithEvents TimerClock2 As Timer
    Friend WithEvents lBell As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MaterialTabSelector1 As MaterialSkin.Controls.MaterialTabSelector
    Friend WithEvents MaterialTabControl1 As MaterialSkin.Controls.MaterialTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lTime As Label
    Friend WithEvents bTest As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents lvBell As MaterialSkin.Controls.MaterialListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents lvTimings As MaterialSkin.Controls.MaterialListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents bSave As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents dtpTime As DateTimePicker
    Friend WithEvents nupDuration As NumericUpDown
    Friend WithEvents lvBell_Mod As MaterialSkin.Controls.MaterialListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents lvTimings_Mod As MaterialSkin.Controls.MaterialListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents bAddBell As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents bDeleteBell As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
End Class
