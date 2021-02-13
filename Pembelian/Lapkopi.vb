Imports System.Data.Odbc
Public Class Lapkopi
    Dim TglMySQL As String
    Sub kondisiawal()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.Visible = False
        DateTimePicker2.Visible = False
        GCjenis.Items.Clear()
        GCjenis.Items.Add("SEMUA DATA")
        GCjenis.Items.Add("TAHUN")
        GCjenis.Items.Add("BULAN")
        GCjenis.Items.Add("TANGGAL")
        GunaComboBox2.Visible = False
        GunaNumeric2.Visible = False
        GunaComboBox2.Items.Clear()
        GunaComboBox2.Items.Add("1")
        GunaComboBox2.Items.Add("2")
        GunaComboBox2.Items.Add("3")
        GunaComboBox2.Items.Add("4")
        GunaComboBox2.Items.Add("5")
        GunaComboBox2.Items.Add("6")
        GunaComboBox2.Items.Add("7")
        GunaComboBox2.Items.Add("8")
        GunaComboBox2.Items.Add("9")
        GunaComboBox2.Items.Add("10")
        GunaComboBox2.Items.Add("11")
        GunaComboBox2.Items.Add("12")
    End Sub

    Sub jumlah()
        Dim A As Integer
        For line As Integer = 0 To GunaDataGridView1.RowCount - 1
            A = A + GunaDataGridView1.Rows(line).Cells(5).Value
        Next
        'formatUang(TBomz)
        'TBomz.Text = Format(A, "###,###,###")
        TBomz.Text = A
    End Sub
    Sub jumlahTR()
        Dim JmlTR
        JmlTR = GunaDataGridView1.RowCount - 1
        GunaLabel6.Text = JmlTR
    End Sub
    Sub fee()
        TBfee.Text = TBomz.Text * Val(65 / 100)
    End Sub
    Private Sub Lapkopi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GCjenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCjenis.SelectedIndexChanged
        If GCjenis.Text = "SEMUA DATA" Then
            GunaLabel7.Visible = False
            GunaComboBox2.Visible = False
            GunaNumeric2.Visible = False
            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False

            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,kopi.MENU,detailkopi.JUMLAH,detailkopi.TOTAL From(detailkopi) LEFT JOIN kopi ON detailkopi.KODE=kopi.KODE LEFT JOIN jual ON detailkopi.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP ", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailkopi")
            GunaDataGridView1.DataSource = Ds.Tables("detailkopi")
            GunaDataGridView1.ReadOnly = True
            Call jumlah()
            Call jumlahTR()
            Call fee()

            'Call Koneksi()
            'Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
            'Ds = New DataSet
            'Da.Fill(Ds, "detailjual")
            'GunaDataGridView1.DataSource = Ds.Tables("detailjual")
            'GunaDataGridView1.ReadOnly = True
            'Call jumlahProd()
            'Call jumlahTRProd()
        Else
            If GCjenis.Text = "TANGGAL" Then
                GunaLabel7.Visible = True
                GunaLabel7.Text = "TANGGAL"
                GunaComboBox2.Visible = False
                GunaNumeric2.Visible = False
                DateTimePicker1.Visible = True
                DateTimePicker2.Visible = True
            Else
                If GCjenis.Text = "BULAN" Then
                    GunaLabel7.Visible = True
                    GunaLabel7.Text = "BULAN DAN TAHUN"
                    GunaComboBox2.Visible = True
                    GunaNumeric2.Visible = True
                    DateTimePicker1.Visible = False
                    DateTimePicker2.Visible = False



                End If
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,kopi.MENU,detailkopi.JUMLAH,detailkopi.TOTAL From(detailkopi) LEFT JOIN kopi ON detailkopi.KODE=kopi.KODE LEFT JOIN jual ON detailkopi.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP WHERE TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detailkopi")
        GunaDataGridView1.DataSource = Ds.Tables("detailkopi")
        GunaDataGridView1.ReadOnly = True
        Call jumlah()
        Call jumlahTR()
        Call fee()
    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaComboBox2.SelectedIndexChanged
        If GCjenis.Text = "BULAN" Then
            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,kopi.MENU,detailkopi.JUMLAH,detailkopi.TOTAL From(detailkopi) LEFT JOIN kopi ON detailkopi.KODE=kopi.KODE LEFT JOIN jual ON detailkopi.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP WHERE MONTH(TANGGAL)= '" & GunaComboBox2.Text & "' and YEAR(TANGGAL)='" & GunaNumeric2.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailkopi")
            GunaDataGridView1.DataSource = Ds.Tables("detailkopi")
            GunaDataGridView1.ReadOnly = True
            Call jumlah()
            Call jumlahTR()
            Call fee()
        End If
    End Sub

    Private Sub TBfee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBfee.TextChanged
        Try
            If TBfee.Text.Trim() <> "" Then
                TBfee.Text = CDec(TBfee.Text).ToString("N0")
                TBfee.SelectionStart = TBfee.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TBomz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBomz.TextChanged
        Try
            If TBomz.Text.Trim() <> "" Then
                TBomz.Text = CDec(TBomz.Text).ToString("N0")
                TBomz.SelectionStart = TBomz.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
        If GCjenis.Text = "" Or GunaComboBox2.Text = "" Or TBomz.Text = "" Or GunaLabel6.Text = "" Or TBfee.Text = "" Or GunaGroupBox2.Text = "" Then
            MsgBox("DATA TIDAK LENGKAP")
        Else
            TglMySQL = Format(Today, "yyyy-MM-dd")
            Dim SimpanFee As String = "Insert into kofee (TGL,BULAN,OMZET,TRANSAKSI,FEE) values('" & TglMySQL & "','" & GunaComboBox2.Text & "','" & Val(Microsoft.VisualBasic.Int(TBomz.Text)) & "','" & Val(Microsoft.VisualBasic.Int(GunaLabel6.Text)) & "','" & Val(Microsoft.VisualBasic.Int(TBfee.Text)) & "')"
            Cmd = New OdbcCommand(SimpanFee, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("FEE SUDAH DIPROSES")
            WAgaji.ShowDialog()
        End If
    End Sub
End Class