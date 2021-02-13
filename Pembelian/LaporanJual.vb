Imports System.Data.Odbc
Public Class LaporanJual

    Sub KondisiAwal()
       GunaNumeric1.Visible = False
        GunaNumeric2.Visible = False
        DateTimePicker1.Visible = False
        CBbulan.Visible = False
        'GunaLabel2.Text = ""
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        GCjenis.Items.Clear()
        GCjenis.Items.Add("KASIR")
        GCjenis.Items.Add("KOPI")
        GCjenis.Items.Add("HAIR STYLIST")
        GCjenis.Items.Add("CAPSTER")
        GCjenis.Items.Add("HAIRSTYLIST2")
        GCjenis.Items.Add("SEMUA DATA")
        GCjenis.Items.Add("TAHUN")
        GCjenis.Items.Add("BULAN")
        GCjenis.Items.Add("TANGGAL")
        GCjenis.Text = ""

        CBbulan.Items.Clear()
        CBbulan.Items.Add("1")
        CBbulan.Items.Add("2")
        CBbulan.Items.Add("3")
        CBbulan.Items.Add("4")
        CBbulan.Items.Add("5")
        CBbulan.Items.Add("6")
        CBbulan.Items.Add("7")
        CBbulan.Items.Add("8")
        CBbulan.Items.Add("9")
        CBbulan.Items.Add("10")
        CBbulan.Items.Add("11")
        CBbulan.Items.Add("12")





    End Sub

    Sub BuatKolom()
        GunaDataGridView2.Columns.Clear()
        GunaDataGridView2.Columns.Add("KODE", "KODE")
        GunaDataGridView2.Columns.Add("NAMA", "NAMA")
        GunaDataGridView2.Columns.Add("MERK", "MERK")
        GunaDataGridView2.Columns.Add("HARGA", "HARGA")
        GunaDataGridView2.Columns.Add("JUMLAH", "JUMLAH")
        GunaDataGridView2.Columns.Add("SUBTOTAL", "SUBTOTAL")
        GunaDataGridView2.Columns.Add("HAIRSTYLIST", "HAIRSTYLIST")

    End Sub
    Private Sub LaporanJual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GCjenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCjenis.SelectedIndexChanged
        If GCjenis.Text = "SEMUA DATA" Then
            'GunaLabel2.Text = ""
            GunaNumeric1.Visible = False
            GunaNumeric2.Visible = False
            DateTimePicker1.Visible = False
            LBLpilih.Visible = False
            Call Koneksi()
            Da = New OdbcDataAdapter("Select jual.IDJUAL,pelanggan.NOHP,pelanggan.NAMA,jual.TANGGAL,jual.JAM,jual.BIAYA From(jual) LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "jual")
            GunaDataGridView1.DataSource = Ds.Tables("jual")
            GunaDataGridView1.ReadOnly = True
            Call jumlah()
            Call jumlahTR()
        Else


            If GCjenis.Text = "TAHUN" Then
                'GunaDataGridView1.Rows.Clear()
                GunaLabel2.Text = ""
                GunaNumeric1.Visible = True
                GunaNumeric2.Visible = False
                DateTimePicker1.Visible = False
                'GunaDateTimePicker2.Visible = False
                CBbulan.Visible = False
                LBLpilih.Visible = True
                LBLpilih.Text = "Tahun"
                Call jumlah()
            Else
                If GCjenis.Text = "BULAN" Then
                    'GunaDataGridView1.Rows.Clear()
                    GunaLabel2.Text = ""
                    GunaNumeric1.Visible = False
                    GunaNumeric2.Visible = True
                    CBbulan.Visible = True
                    DateTimePicker1.Visible = False
                    'GunaDateTimePicker2.Visible = False
                    LBLpilih.Visible = True
                    LBLpilih.Text = "Bulan"
                    Call jumlah()

                Else
                    If GCjenis.Text = "TANGGAL" Then
                        'GunaDataGridView1.Rows.Clear()
                        GunaLabel2.Text = ""
                        'GunaDataGridView1.Columns(3).DefaultCellStyle.Format = "yyyy-MM-dd"
                        GunaNumeric1.Visible = False
                        GunaNumeric2.Visible = False
                        CBbulan.Visible = False
                        DateTimePicker1.Visible = True
                        LBLpilih.Visible = True
                        LBLpilih.Text = "Tanggal"
                        Call Koneksi()
                        Da = New OdbcDataAdapter("Select jual.IDJUAL,pelanggan.NOHP,pelanggan.NAMA,jual.TANGGAL,jual.JAM,jual.BIAYA From(jual) LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where TANGGAL='" & DateTimePicker1.Text & "'", Conn)
                        Ds = New DataSet
                        Da.Fill(Ds, "jual")
                        GunaDataGridView1.DataSource = Ds.Tables("jual")
                        GunaDataGridView1.ReadOnly = True
                        Call jumlah()



                    Else
                        If GCjenis.Text = "HAIR STYLIST" Then
                            Form2.ShowDialog()
                        Else
                            If GCjenis.Text = "KOPI" Then
                                Lapkopi.ShowDialog()
                            Else
                                If GCjenis.Text = "CAPSTER" Then
                                    capster.ShowDialog()
                                Else
                                    If GCjenis.Text = "HAIRSTYLIST2" Then
                                        hairstylist2.ShowDialog()
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = GunaDataGridView1.CurrentRow.Index
        Cmd = New OdbcCommand("Select * from jual where IDJUAL='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT detaillayan.IDJUAL,layanan.LAYANAN,detaillayan.HARGA,detaillayan.JUMLAH,detaillayan.TOTAL,detaillayan.PEGAWAI From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL  where detaillayan.IDJUAL ='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detaillayan")
            GunaDataGridView2.DataSource = Ds.Tables("detaillayan")
            GunaDataGridView2.ReadOnly = True

            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT detailjual.IDJUAL,barang.MERK,detailjual.HARGA,detailjual.JUMLAH,detailjual.TOTAL From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE  where detailjual.IDJUAL ='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailjual")
            GunaDataGridView3.DataSource = Ds.Tables("detailjual")
            GunaDataGridView3.ReadOnly = True

            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT detailkopi.IDJUAL,kopi.MENU,detailkopi.HARGA,detailkopi.JUMLAH,detailkopi.TOTAL From(detailkopi) LEFT JOIN kopi ON detailkopi.KODE=kopi.KODE  where detailkopi.IDJUAL ='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailkopi")
            GunaDataGridView4.DataSource = Ds.Tables("detailkopi")
            GunaDataGridView4.ReadOnly = True
        End If
    End Sub
    Sub jumlah()
        Dim A As Integer
        For line As Integer = 0 To GunaDataGridView1.RowCount - 1
            A = A + GunaDataGridView1.Rows(line).Cells(5).Value
        Next
        GunaLabel2.Text = Format(A, "###,###,###")
    End Sub
    Sub jumlahTR()
        Dim JmlTR
        JmlTR = GunaDataGridView1.RowCount - 1
        GunaLabel6.Text = JmlTR
    End Sub
    Private Sub GunaNumeric1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaNumeric1.ValueChanged
        'Call Koneksi()
        'Da = New OdbcDataAdapter("SELECT FAKTUR,TANGGAL,SUPLIER FROM pembelian WHERE YEAR(TANGGAL) = '" & GunaNumeric1.Value & "'", Conn)
        'Ds = New DataSet
        'Da.Fill(Ds, "pembelian")
        'GunaDataGridView1.DataSource = Ds.Tables("pembelian")
        'GunaDataGridView1.ReadOnly = True
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBbulan.SelectedIndexChanged
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM jual WHERE MONTH(TANGGAL) = '" & CBbulan.Text & "' AND YEAR(TANGGAL) = '" & GunaNumeric2.Value & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "jual")
        GunaDataGridView1.DataSource = Ds.Tables("jual")
        GunaDataGridView1.ReadOnly = True
        Call jumlah()
        Call jumlahTR()
    End Sub

    Private Sub GunaNumeric2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaNumeric2.ValueChanged
        'Call Koneksi()
        'Da = New OdbcDataAdapter("SELECT FAKTUR,TANGGAL,SUPLIER FROM pembelian WHERE YEAR(TANGGAL) = '" & GunaNumeric2.Value & "'", Conn)
        'Ds = New DataSet
        'Da.Fill(Ds, "pembelian")
        'GunaDataGridView1.DataSource = Ds.Tables("pembelian")
        'GunaDataGridView1.ReadOnly = True
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        If GCjenis.Text = "SEMUA DATA" Then
            If MessageBox.Show("CETAK DATA ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                AxCrystalReport1.ReportFileName = "LapJual.rpt"
                AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
                AxCrystalReport1.RetrieveDataFiles()
                AxCrystalReport1.Action = 1
                Call KondisiAwal()
            End If
        End If


        If GCjenis.Text = "TANGGAL" Then
            If MessageBox.Show("CETAK DATA ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                AxCrystalReport1.SelectionFormula = "totext({pembelian.TANGGAL})='" & DateTimePicker1.Text & "'"
                AxCrystalReport1.ReportFileName = "laporanPembelian.rpt"
                AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
                AxCrystalReport1.RetrieveDataFiles()
                AxCrystalReport1.Action = 1
                Call KondisiAwal()
            End If
        End If


    End Sub

    Private Sub GunaDateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaLabel2.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        'If GunaComboBox2.Text = "KESELURUHAN" Then
        '    Call Koneksi()
        '    Da = New OdbcDataAdapter("Select IDJUAL,NOHP,TANGGAL,PEGAWAI,BIAYA From jual where TANGGAL='" & DateTimePicker1.Text & "'", Conn)
        '    Ds = New DataSet
        '    Da.Fill(Ds, "jual")
        '    GunaDataGridView1.DataSource = Ds.Tables("jual")
        '    GunaDataGridView1.ReadOnly = True
        '    Call jumlah()
        '    Call jumlahTR()
        'Else
        Call Koneksi()
        Da = New OdbcDataAdapter("Select jual.IDJUAL,pelanggan.NOHP,pelanggan.NAMA,jual.TANGGAL,jual.JAM,jual.BIAYA From(jual) LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where TANGGAL='" & DateTimePicker1.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "jual")
        GunaDataGridView1.DataSource = Ds.Tables("jual")
        GunaDataGridView1.ReadOnly = True
        Call jumlah()
        Call jumlahTR()
        'End If

    End Sub

    Private Sub GunaButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GunaDataGridView1.Columns.Clear()
    End Sub

    Private Sub GunaGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox1.Click

    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If GunaComboBox2.Text = "KESELURUHAN" Then
        '    Call Koneksi()
        '    Da = New OdbcDataAdapter("Select jual.IDJUAL,pelanggan.NOHP,pelanggan.NAMA,jual.TANGGAL,jual.JAM,jual.BIAYA From(jual) LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP ", Conn)
        '    Ds = New DataSet
        '    Da.Fill(Ds, "jual")
        '    GunaDataGridView1.DataSource = Ds.Tables("jual")
        '    GunaDataGridView1.ReadOnly = True
        '    Call jumlah()
        '    Call jumlahTR()
        'SELECT detaillayan.IDJUAL,layanan.KODEL,layanan.LAYANAN,detaillayan.HARGA,detaillayan.JUMLAH,detaillayan.TOTAL 
        'From(detaillayan) 
        'LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL  
        'where detaillayan.IDJUAL =


        'Else
        '    If DateTimePicker1.Visible = True Then
        '        Call Koneksi()
        '        Da = New OdbcDataAdapter("Select IDJUAL,NOHP,TANGGAL,PEGAWAI,BIAYA From jual where TANGGAL='" & DateTimePicker1.Text & "' and PEGAWAI='" & GunaComboBox2.Text & "'", Conn)
        '        Ds = New DataSet
        '        Da.Fill(Ds, "jual")
        '        GunaDataGridView1.DataSource = Ds.Tables("jual")
        '        GunaDataGridView1.ReadOnly = True
        '        Call jumlah()
        '        Call jumlahTR()
        '    Else
        '        Call Koneksi()
        '        Da = New OdbcDataAdapter("Select IDJUAL,NOHP,TANGGAL,PEGAWAI,BIAYA From jual where PEGAWAI='" & GunaComboBox2.Text & "'", Conn)
        '        Ds = New DataSet
        '        Da.Fill(Ds, "jual")
        '        GunaDataGridView1.DataSource = Ds.Tables("jual")
        '        GunaDataGridView1.ReadOnly = True
        '        Call jumlah()
        '        Call jumlahTR()
        '    End If
        'End If
    End Sub
End Class