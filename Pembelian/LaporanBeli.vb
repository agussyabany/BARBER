Imports System.Data.Odbc
Public Class LaporanBeli
    Sub KondisiAwal()
        GCjenis.Items.Clear()
        GCjenis.Items.Add("SEMUA DATA")
        GCjenis.Items.Add("TAHUN")
        GCjenis.Items.Add("BULAN")
        GCjenis.Items.Add("TANGGAL")
        GCjenis.Text = "SEMUA DATA"
        GunaComboBox1.Items.Clear()

        'For a As Integer = 0 To 11
        '    Dim b As DateTime

        GunaComboBox1.Items.Add("1")
        GunaComboBox1.Items.Add("2")
        GunaComboBox1.Items.Add("3")
        GunaComboBox1.Items.Add("4")
        GunaComboBox1.Items.Add("5")
        GunaComboBox1.Items.Add("6")
        GunaComboBox1.Items.Add("7")
        GunaComboBox1.Items.Add("8")
        GunaComboBox1.Items.Add("9")
        GunaComboBox1.Items.Add("10")
        GunaComboBox1.Items.Add("11")
        GunaComboBox1.Items.Add("12")

        '(Format(b.AddMonths(A), "MMMM"))
        'Next
        'GunaComboBox1.SelectedIndex = 0

    End Sub
    Private Sub LaporanBeli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub


    Private Sub GCjenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCjenis.SelectedIndexChanged
       

        If GCjenis.Text = "SEMUA DATA" Then
            GunaNumeric1.Visible = False
            GunaNumeric2.Visible = False
            GunaDateTimePicker1.Visible = False
            GunaDateTimePicker2.Visible = False
            GunaComboBox1.Visible = False
            LBLpilih.Visible = False
            Call Koneksi()
            Da = New OdbcDataAdapter("Select FAKTUR,TANGGAL,SUPLIER From pembelian", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "pembelian")
            GunaDataGridView1.DataSource = Ds.Tables("pembelian")
            GunaDataGridView1.ReadOnly = True



        Else
            If GCjenis.Text = "TAHUN" Then
                GunaNumeric1.Visible = True
                GunaNumeric2.Visible = False
                GunaDateTimePicker1.Visible = False
                GunaDateTimePicker2.Visible = False
                GunaComboBox1.Visible = False
                LBLpilih.Visible = True
                LBLpilih.Text = "Tahun"

            Else
                If GCjenis.Text = "BULAN" Then
                    GunaNumeric1.Visible = False
                    GunaNumeric2.Visible = True
                    GunaComboBox1.Visible = True
                    GunaDateTimePicker1.Visible = False
                    GunaDateTimePicker2.Visible = False
                    LBLpilih.Visible = True
                    LBLpilih.Text = "Bulan"
                    
                Else
                    If GCjenis.Text = "TANGGAL" Then
                        GunaNumeric1.Visible = False
                        GunaNumeric2.Visible = False
                        GunaComboBox1.Visible = False
                        GunaDateTimePicker1.Visible = True
                        GunaDateTimePicker2.Visible = True
                        LBLpilih.Visible = True
                        LBLpilih.Text = "Mulai"
                    Else
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = GunaDataGridView1.CurrentRow.Index
        Cmd = New OdbcCommand("Select * from pembelian where FAKTUR='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT detailbeli.FAKTUR,barang.KODE,barang.NAMA,detailbeli.HARGA,detailbeli.JUMLAH,detailbeli.TOTAL From(detailbeli) LEFT JOIN barang ON detailbeli.KODE=barang.KODE where detailbeli.FAKTUR ='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailbeli")
            GunaDataGridView2.DataSource = Ds.Tables("detailbeli")
            GunaDataGridView2.ReadOnly = True
        End If
    End Sub

    '"SELECT barang.id_bar,barang.nama_bar,det_permintaan.harga_satuan,det_permintaan.jumlah_barang,barang.satuan,det_permintaan.subtotal,det_permintaan.kode,det_permintaan.status 
    'FROM(det_permintaan) 
    'LEFT JOIN barang ON det_permintaan.id_bar=barang.id_bar LEFT JOIN permintaan ON det_permintaan.id_perm=permintaan.id_perm LEFT JOIN bagian ON permintaan.id_bag=bagian.id_bag 
    'WHERE det_permintaan.id_perm='" & GunaComboBox1.Text & "'", Conn)

    Private Sub GunaNumeric1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaNumeric1.ValueChanged
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT FAKTUR,TANGGAL,SUPLIER FROM pembelian WHERE YEAR(TANGGAL) = '" & GunaNumeric1.Value & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pembelian")
        GunaDataGridView1.DataSource = Ds.Tables("pembelian")
        GunaDataGridView1.ReadOnly = True
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT FAKTUR,TANGGAL,SUPLIER FROM pembelian WHERE MONTH(TANGGAL) = '" & GunaComboBox1.Text & "' AND YEAR(TANGGAL) = '" & GunaNumeric2.Value & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pembelian")
        GunaDataGridView1.DataSource = Ds.Tables("pembelian")
        GunaDataGridView1.ReadOnly = True
    End Sub

    Private Sub GunaNumeric2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaNumeric2.ValueChanged
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT FAKTUR,TANGGAL,SUPLIER FROM pembelian WHERE YEAR(TANGGAL) = '" & GunaNumeric2.Value & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pembelian")
        GunaDataGridView1.DataSource = Ds.Tables("pembelian")
        GunaDataGridView1.ReadOnly = True
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        If GCjenis.Text = "SEMUA DATA" Then
            If MessageBox.Show("CETAK DATA ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                AxCrystalReport1.ReportFileName = "laporanPembelian.rpt"
                AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
                AxCrystalReport1.RetrieveDataFiles()
                AxCrystalReport1.Action = 1
                Call KondisiAwal()
            End If
        End If


            If GCjenis.Text = "TANGGAL" Then
                If MessageBox.Show("CETAK DATA ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    AxCrystalReport1.SelectionFormula = "totext({pembelian.TANGGAL})='" & GunaDateTimePicker1.Text & "'"
                    AxCrystalReport1.ReportFileName = "laporanPembelian.rpt"
                    AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
                    AxCrystalReport1.RetrieveDataFiles()
                    AxCrystalReport1.Action = 1
                    Call KondisiAwal()
                End If
            End If


    End Sub
End Class