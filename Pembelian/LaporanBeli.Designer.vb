<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanBeli
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LaporanBeli))
        Me.GunaLabel14 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaGroupBox1 = New Guna.UI.WinForms.GunaGroupBox()
        Me.GunaComboBox1 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaDateTimePicker2 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaDateTimePicker1 = New Guna.UI.WinForms.GunaDateTimePicker()
        Me.GunaNumeric2 = New Guna.UI.WinForms.GunaNumeric()
        Me.LBLpilih = New Guna.UI.WinForms.GunaLabel()
        Me.GunaNumeric1 = New Guna.UI.WinForms.GunaNumeric()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.TBharbel = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GCjenis = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaGroupBox2 = New Guna.UI.WinForms.GunaGroupBox()
        Me.GunaDataGridView1 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaGroupBox3 = New Guna.UI.WinForms.GunaGroupBox()
        Me.GunaDataGridView2 = New Guna.UI.WinForms.GunaDataGridView()
        Me.GunaGroupBox4 = New Guna.UI.WinForms.GunaGroupBox()
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.AxCrystalReport1 = New AxCrystal.AxCrystalReport()
        Me.GunaGroupBox1.SuspendLayout()
        Me.GunaGroupBox2.SuspendLayout()
        CType(Me.GunaDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaGroupBox3.SuspendLayout()
        CType(Me.GunaDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaGroupBox4.SuspendLayout()
        CType(Me.AxCrystalReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaLabel14
        '
        Me.GunaLabel14.AutoSize = True
        Me.GunaLabel14.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel14.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.GunaLabel14.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel14.Location = New System.Drawing.Point(12, 9)
        Me.GunaLabel14.Name = "GunaLabel14"
        Me.GunaLabel14.Size = New System.Drawing.Size(249, 32)
        Me.GunaLabel14.TabIndex = 133
        Me.GunaLabel14.Text = "LAPORAN PEMBELIAN"
        '
        'GunaGroupBox1
        '
        Me.GunaGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox1.BaseColor = System.Drawing.SystemColors.ActiveBorder
        Me.GunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox1.BorderSize = 3
        Me.GunaGroupBox1.Controls.Add(Me.GunaComboBox1)
        Me.GunaGroupBox1.Controls.Add(Me.GunaDateTimePicker2)
        Me.GunaGroupBox1.Controls.Add(Me.GunaDateTimePicker1)
        Me.GunaGroupBox1.Controls.Add(Me.GunaNumeric2)
        Me.GunaGroupBox1.Controls.Add(Me.LBLpilih)
        Me.GunaGroupBox1.Controls.Add(Me.GunaNumeric1)
        Me.GunaGroupBox1.Controls.Add(Me.GunaLabel1)
        Me.GunaGroupBox1.Controls.Add(Me.TBharbel)
        Me.GunaGroupBox1.Controls.Add(Me.GunaLabel3)
        Me.GunaGroupBox1.Controls.Add(Me.GCjenis)
        Me.GunaGroupBox1.LineColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox1.Location = New System.Drawing.Point(16, 44)
        Me.GunaGroupBox1.Name = "GunaGroupBox1"
        Me.GunaGroupBox1.Radius = 5
        Me.GunaGroupBox1.Size = New System.Drawing.Size(837, 120)
        Me.GunaGroupBox1.TabIndex = 134
        Me.GunaGroupBox1.Text = "Filter Data Pembelian"
        Me.GunaGroupBox1.TextLocation = New System.Drawing.Point(10, 8)
        '
        'GunaComboBox1
        '
        Me.GunaComboBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBox1.BaseColor = System.Drawing.Color.White
        Me.GunaComboBox1.BorderColor = System.Drawing.Color.Silver
        Me.GunaComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBox1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBox1.Font = New System.Drawing.Font("Times New Roman", 20.0!)
        Me.GunaComboBox1.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBox1.FormattingEnabled = True
        Me.GunaComboBox1.Location = New System.Drawing.Point(360, 34)
        Me.GunaComboBox1.Name = "GunaComboBox1"
        Me.GunaComboBox1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBox1.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBox1.Radius = 6
        Me.GunaComboBox1.Size = New System.Drawing.Size(208, 39)
        Me.GunaComboBox1.TabIndex = 261
        '
        'GunaDateTimePicker2
        '
        Me.GunaDateTimePicker2.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker2.BorderColor = System.Drawing.Color.Silver
        Me.GunaDateTimePicker2.CustomFormat = Nothing
        Me.GunaDateTimePicker2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePicker2.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaDateTimePicker2.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePicker2.Location = New System.Drawing.Point(584, 39)
        Me.GunaDateTimePicker2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePicker2.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePicker2.Name = "GunaDateTimePicker2"
        Me.GunaDateTimePicker2.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker2.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker2.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker2.Size = New System.Drawing.Size(223, 30)
        Me.GunaDateTimePicker2.TabIndex = 260
        Me.GunaDateTimePicker2.Text = "10/17/2020"
        Me.GunaDateTimePicker2.Value = New Date(2020, 10, 17, 20, 34, 37, 143)
        '
        'GunaDateTimePicker1
        '
        Me.GunaDateTimePicker1.BaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker1.BorderColor = System.Drawing.Color.Silver
        Me.GunaDateTimePicker1.CustomFormat = Nothing
        Me.GunaDateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.GunaDateTimePicker1.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaDateTimePicker1.ForeColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.GunaDateTimePicker1.Location = New System.Drawing.Point(360, 39)
        Me.GunaDateTimePicker1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.GunaDateTimePicker1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.GunaDateTimePicker1.Name = "GunaDateTimePicker1"
        Me.GunaDateTimePicker1.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaDateTimePicker1.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDateTimePicker1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaDateTimePicker1.Size = New System.Drawing.Size(223, 30)
        Me.GunaDateTimePicker1.TabIndex = 259
        Me.GunaDateTimePicker1.Text = "10/17/2020"
        Me.GunaDateTimePicker1.Value = New Date(2020, 10, 17, 20, 34, 37, 143)
        '
        'GunaNumeric2
        '
        Me.GunaNumeric2.BaseColor = System.Drawing.Color.White
        Me.GunaNumeric2.BorderColor = System.Drawing.Color.Silver
        Me.GunaNumeric2.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaNumeric2.ButtonForeColor = System.Drawing.Color.White
        Me.GunaNumeric2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaNumeric2.ForeColor = System.Drawing.Color.Black
        Me.GunaNumeric2.Location = New System.Drawing.Point(584, 39)
        Me.GunaNumeric2.Maximum = CType(9999999, Long)
        Me.GunaNumeric2.Minimum = CType(0, Long)
        Me.GunaNumeric2.Name = "GunaNumeric2"
        Me.GunaNumeric2.Size = New System.Drawing.Size(155, 30)
        Me.GunaNumeric2.TabIndex = 258
        Me.GunaNumeric2.Text = "2020"
        Me.GunaNumeric2.Value = CType(2020, Long)
        '
        'LBLpilih
        '
        Me.LBLpilih.AutoSize = True
        Me.LBLpilih.BackColor = System.Drawing.Color.Transparent
        Me.LBLpilih.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LBLpilih.ForeColor = System.Drawing.Color.Black
        Me.LBLpilih.Location = New System.Drawing.Point(305, 44)
        Me.LBLpilih.Name = "LBLpilih"
        Me.LBLpilih.Size = New System.Drawing.Size(49, 19)
        Me.LBLpilih.TabIndex = 257
        Me.LBLpilih.Text = "Pilihan"
        '
        'GunaNumeric1
        '
        Me.GunaNumeric1.BaseColor = System.Drawing.Color.White
        Me.GunaNumeric1.BorderColor = System.Drawing.Color.Silver
        Me.GunaNumeric1.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaNumeric1.ButtonForeColor = System.Drawing.Color.White
        Me.GunaNumeric1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaNumeric1.ForeColor = System.Drawing.Color.Black
        Me.GunaNumeric1.Location = New System.Drawing.Point(399, 39)
        Me.GunaNumeric1.Maximum = CType(9999999, Long)
        Me.GunaNumeric1.Minimum = CType(0, Long)
        Me.GunaNumeric1.Name = "GunaNumeric1"
        Me.GunaNumeric1.Size = New System.Drawing.Size(155, 30)
        Me.GunaNumeric1.TabIndex = 256
        Me.GunaNumeric1.Text = "2020"
        Me.GunaNumeric1.Value = CType(2020, Long)
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel1.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel1.Location = New System.Drawing.Point(23, 86)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(33, 19)
        Me.GunaLabel1.TabIndex = 255
        Me.GunaLabel1.Text = "Cari"
        '
        'TBharbel
        '
        Me.TBharbel.BackColor = System.Drawing.Color.Transparent
        Me.TBharbel.BaseColor = System.Drawing.Color.WhiteSmoke
        Me.TBharbel.BorderColor = System.Drawing.Color.Silver
        Me.TBharbel.BorderSize = 0
        Me.TBharbel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TBharbel.FocusedBaseColor = System.Drawing.Color.White
        Me.TBharbel.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TBharbel.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.TBharbel.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBharbel.ForeColor = System.Drawing.Color.Black
        Me.TBharbel.Location = New System.Drawing.Point(78, 79)
        Me.TBharbel.Name = "TBharbel"
        Me.TBharbel.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TBharbel.Radius = 6
        Me.TBharbel.Size = New System.Drawing.Size(729, 34)
        Me.TBharbel.TabIndex = 254
        Me.TBharbel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaLabel3.ForeColor = System.Drawing.Color.Black
        Me.GunaLabel3.Location = New System.Drawing.Point(23, 44)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(49, 19)
        Me.GunaLabel3.TabIndex = 253
        Me.GunaLabel3.Text = "Pilihan"
        '
        'GCjenis
        '
        Me.GCjenis.BackColor = System.Drawing.Color.Transparent
        Me.GCjenis.BaseColor = System.Drawing.Color.White
        Me.GCjenis.BorderColor = System.Drawing.Color.Silver
        Me.GCjenis.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GCjenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GCjenis.FocusedColor = System.Drawing.Color.Empty
        Me.GCjenis.Font = New System.Drawing.Font("Times New Roman", 20.0!)
        Me.GCjenis.ForeColor = System.Drawing.Color.Black
        Me.GCjenis.FormattingEnabled = True
        Me.GCjenis.Location = New System.Drawing.Point(78, 34)
        Me.GCjenis.Name = "GCjenis"
        Me.GCjenis.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GCjenis.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GCjenis.Radius = 6
        Me.GCjenis.Size = New System.Drawing.Size(208, 39)
        Me.GCjenis.TabIndex = 138
        '
        'GunaGroupBox2
        '
        Me.GunaGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox2.BaseColor = System.Drawing.SystemColors.ActiveBorder
        Me.GunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox2.BorderSize = 3
        Me.GunaGroupBox2.Controls.Add(Me.GunaDataGridView1)
        Me.GunaGroupBox2.LineColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox2.Location = New System.Drawing.Point(16, 171)
        Me.GunaGroupBox2.Name = "GunaGroupBox2"
        Me.GunaGroupBox2.Radius = 5
        Me.GunaGroupBox2.Size = New System.Drawing.Size(416, 312)
        Me.GunaGroupBox2.TabIndex = 135
        Me.GunaGroupBox2.Text = "Data Pembelian"
        Me.GunaGroupBox2.TextLocation = New System.Drawing.Point(10, 8)
        '
        'GunaDataGridView1
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.GunaDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.GunaDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.GunaDataGridView1.ColumnHeadersHeight = 30
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView1.DefaultCellStyle = DataGridViewCellStyle11
        Me.GunaDataGridView1.EnableHeadersVisualStyles = False
        Me.GunaDataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.Location = New System.Drawing.Point(14, 36)
        Me.GunaDataGridView1.Name = "GunaDataGridView1"
        Me.GunaDataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.GunaDataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.GunaDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView1.Size = New System.Drawing.Size(387, 267)
        Me.GunaDataGridView1.TabIndex = 196
        Me.GunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.GunaDataGridView1.ThemeStyle.HeaderStyle.Height = 30
        Me.GunaDataGridView1.ThemeStyle.ReadOnly = False
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaGroupBox3
        '
        Me.GunaGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox3.BaseColor = System.Drawing.SystemColors.ActiveBorder
        Me.GunaGroupBox3.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox3.BorderSize = 3
        Me.GunaGroupBox3.Controls.Add(Me.GunaDataGridView2)
        Me.GunaGroupBox3.LineColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox3.Location = New System.Drawing.Point(438, 171)
        Me.GunaGroupBox3.Name = "GunaGroupBox3"
        Me.GunaGroupBox3.Radius = 5
        Me.GunaGroupBox3.Size = New System.Drawing.Size(416, 312)
        Me.GunaGroupBox3.TabIndex = 136
        Me.GunaGroupBox3.Text = "Detail Data Pembelian"
        Me.GunaGroupBox3.TextLocation = New System.Drawing.Point(10, 8)
        '
        'GunaDataGridView2
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.GunaDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GunaDataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.GunaDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GunaDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GunaDataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.GunaDataGridView2.ColumnHeadersHeight = 30
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GunaDataGridView2.DefaultCellStyle = DataGridViewCellStyle15
        Me.GunaDataGridView2.EnableHeadersVisualStyles = False
        Me.GunaDataGridView2.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.Location = New System.Drawing.Point(12, 36)
        Me.GunaDataGridView2.Name = "GunaDataGridView2"
        Me.GunaDataGridView2.RowHeadersVisible = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        Me.GunaDataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.GunaDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GunaDataGridView2.Size = New System.Drawing.Size(387, 267)
        Me.GunaDataGridView2.TabIndex = 197
        Me.GunaDataGridView2.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.GunaDataGridView2.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.GunaDataGridView2.ThemeStyle.HeaderStyle.Height = 30
        Me.GunaDataGridView2.ThemeStyle.ReadOnly = False
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.Height = 22
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaDataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'GunaGroupBox4
        '
        Me.GunaGroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox4.BaseColor = System.Drawing.SystemColors.ActiveBorder
        Me.GunaGroupBox4.BorderColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox4.BorderSize = 3
        Me.GunaGroupBox4.Controls.Add(Me.AxCrystalReport1)
        Me.GunaGroupBox4.Controls.Add(Me.GunaButton2)
        Me.GunaGroupBox4.LineColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox4.Location = New System.Drawing.Point(16, 489)
        Me.GunaGroupBox4.Name = "GunaGroupBox4"
        Me.GunaGroupBox4.Radius = 5
        Me.GunaGroupBox4.Size = New System.Drawing.Size(837, 105)
        Me.GunaGroupBox4.TabIndex = 136
        Me.GunaGroupBox4.Text = "Cetak Data"
        Me.GunaGroupBox4.TextLocation = New System.Drawing.Point(10, 8)
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GunaButton2.BaseColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GunaButton2.BorderSize = 1
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.GunaButton2.ForeColor = System.Drawing.Color.Black
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageSize = New System.Drawing.Size(10, 10)
        Me.GunaButton2.Location = New System.Drawing.Point(701, 43)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 6
        Me.GunaButton2.Size = New System.Drawing.Size(120, 42)
        Me.GunaButton2.TabIndex = 286
        Me.GunaButton2.Text = "CETAK"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GunaButton1.BaseColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GunaButton1.BorderSize = 1
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.GunaButton1.ForeColor = System.Drawing.Color.Black
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageSize = New System.Drawing.Size(10, 10)
        Me.GunaButton1.Location = New System.Drawing.Point(808, 6)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 6
        Me.GunaButton1.Size = New System.Drawing.Size(47, 32)
        Me.GunaButton1.TabIndex = 287
        Me.GunaButton1.Text = "X"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AxCrystalReport1
        '
        Me.AxCrystalReport1.Enabled = True
        Me.AxCrystalReport1.Location = New System.Drawing.Point(101, 43)
        Me.AxCrystalReport1.Name = "AxCrystalReport1"
        Me.AxCrystalReport1.OcxState = CType(resources.GetObject("AxCrystalReport1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxCrystalReport1.Size = New System.Drawing.Size(28, 28)
        Me.AxCrystalReport1.TabIndex = 287
        '
        'LaporanBeli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(867, 606)
        Me.Controls.Add(Me.GunaButton1)
        Me.Controls.Add(Me.GunaGroupBox4)
        Me.Controls.Add(Me.GunaGroupBox3)
        Me.Controls.Add(Me.GunaGroupBox2)
        Me.Controls.Add(Me.GunaGroupBox1)
        Me.Controls.Add(Me.GunaLabel14)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LaporanBeli"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LaporanBeli"
        Me.GunaGroupBox1.ResumeLayout(False)
        Me.GunaGroupBox1.PerformLayout()
        Me.GunaGroupBox2.ResumeLayout(False)
        CType(Me.GunaDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaGroupBox3.ResumeLayout(False)
        CType(Me.GunaDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaGroupBox4.ResumeLayout(False)
        CType(Me.AxCrystalReport1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GunaLabel14 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaGroupBox1 As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents GCjenis As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents TBharbel As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaGroupBox2 As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents GunaGroupBox3 As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents GunaGroupBox4 As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents GunaDataGridView1 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaDataGridView2 As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents GunaDateTimePicker2 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaDateTimePicker1 As Guna.UI.WinForms.GunaDateTimePicker
    Friend WithEvents GunaNumeric2 As Guna.UI.WinForms.GunaNumeric
    Friend WithEvents LBLpilih As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaNumeric1 As Guna.UI.WinForms.GunaNumeric
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaComboBox1 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents AxCrystalReport1 As AxCrystal.AxCrystalReport
End Class
