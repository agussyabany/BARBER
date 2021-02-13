Imports System.Data.Odbc
Public Class capster
    Dim TglMySQL As String
    Sub hairstylist()
        Call Koneksi()
        GunaComboBox1.Items.Clear()
        Cmd = New OdbcCommand("Select NAMA from pegawai where JABATAN= 'CAPSTER' ", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GunaComboBox1.Items.Add(Rd.Item(0))
        Loop
    End Sub
    Sub fee()
        TBfee.Text = TBomz.Text * Val(15 / 100)
    End Sub
    Sub feeProd()
        TextBox1.Text = LBLbr.Text * 15000
    End Sub

    Sub kondisiAwal()
        Call hairstylist()
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
    Sub totalFEE()
        Try
            TextBox2.Text = Val(Microsoft.VisualBasic.Int(TBfee.Text)) + Val(Microsoft.VisualBasic.Int(TextBox1.Text))
        Catch ex As Exception

        End Try

    End Sub
    Sub jumlah()
        Dim A As Integer
        For line As Integer = 0 To GunaDataGridView1.RowCount - 1
            A = A + GunaDataGridView1.Rows(line).Cells(5).Value
        Next
        TBomz.Text = A
    End Sub
    Sub jumlahProd()
        Dim A As Integer
        For line As Integer = 0 To GunaDataGridView2.RowCount - 1
            A = A + GunaDataGridView2.Rows(line).Cells(4).Value
        Next

        TBtot.Text = A
    End Sub
    Sub jumlahTRProd()
        Dim JmlTRP
        JmlTRP = GunaDataGridView2.RowCount - 1
        LBLbr.Text = JmlTRP
    End Sub
    Sub jumlahTR()
        Dim JmlTR
        JmlTR = GunaDataGridView1.RowCount - 1
        GunaLabel6.Text = JmlTR
    End Sub
    Public Sub formatUang(ByVal Text As TextBox)
        If Len(Text.Text) > 0 Then
            Text.Text = FormatNumber(CDbl(Text.Text), 0)
            Dim x As Integer = Text.SelectionStart.ToString
            If x = 0 Then
                Text.SelectionStart = Len(Text.Text)
                Text.SelectionLength = 0
            Else
                Text.SelectionStart = x
                Text.SelectionLength = 0
            End If
        End If
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub capster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()
    End Sub

    Private Sub GCjenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCjenis.SelectedIndexChanged
        If GCjenis.Text = "SEMUA DATA" Then
            GunaLabel7.Visible = False
            GunaComboBox2.Visible = False
            GunaNumeric2.Visible = False
            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False

            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detaillayan")
            GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
            GunaDataGridView1.ReadOnly = True
            Call jumlah()
            Call jumlahTR()
            Call fee()
            Call totalFEE()

            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailjual")
            GunaDataGridView2.DataSource = Ds.Tables("detailjual")
            GunaDataGridView2.ReadOnly = True
            Call jumlahProd()
            Call jumlahTRProd()
            Call feeProd()
            Call totalFEE()
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
        Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "' and PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detaillayan")
        GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
        GunaDataGridView1.ReadOnly = True
        Call jumlah()
        Call jumlahTR()
        Call fee()
        Call totalFEE()

        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "' and PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detailjual")
        GunaDataGridView2.DataSource = Ds.Tables("detailjual")
        GunaDataGridView2.ReadOnly = True
        Call jumlahProd()
        Call jumlahTRProd()
        Call feeProd()
        Call totalFEE()
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        If DateTimePicker1.Visible = True Then
            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where TANGGAL= '" & DateTimePicker1.Text & "' and PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detaillayan")
            GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
            GunaDataGridView1.ReadOnly = True
            Call jumlah()
            Call jumlahTR()
            Call fee()
            Call totalFEE()

            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where TANGGAL= '" & DateTimePicker1.Text & "' and PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailjual")
            GunaDataGridView2.DataSource = Ds.Tables("detailjual")
            GunaDataGridView2.ReadOnly = True
            Call jumlahProd()
            Call jumlahTRProd()
            Call feeProd()
            Call totalFEE()
        Else
            If GCjenis.Text = "SEMUA DATA" Then
                Call Koneksi()
                Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
                Ds = New DataSet
                Da.Fill(Ds, "detaillayan")
                GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
                GunaDataGridView1.ReadOnly = True
                Call jumlah()
                Call jumlahTR()
                Call fee()
                Call totalFEE()

                Call Koneksi()
                Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
                Ds = New DataSet
                Da.Fill(Ds, "detailjual")
                GunaDataGridView2.DataSource = Ds.Tables("detailjual")
                GunaDataGridView2.ReadOnly = True
                Call jumlahProd()
                Call jumlahTRProd()
                Call feeProd()
                Call totalFEE()
            Else
                If GCjenis.Text = "BULAN" Then
                    Call Koneksi()
                    Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where MONTH(TANGGAL)= '" & GunaComboBox2.Text & "' and PEGAWAI='" & GunaComboBox1.Text & "' and YEAR(TANGGAL)='" & GunaNumeric2.Text & "' ", Conn)
                    Ds = New DataSet
                    Da.Fill(Ds, "detaillayan")
                    GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
                    GunaDataGridView1.ReadOnly = True
                    Call jumlah()
                    Call jumlahTR()
                    Call fee()
                    Call totalFEE()

                    Call Koneksi()
                    Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where  MONTH(TANGGAL)= '" & GunaComboBox2.Text & "' and PEGAWAI='" & GunaComboBox1.Text & "' and YEAR(TANGGAL)='" & GunaNumeric2.Text & "'", Conn)
                    Ds = New DataSet
                    Da.Fill(Ds, "detailjual")
                    GunaDataGridView2.DataSource = Ds.Tables("detailjual")
                    GunaDataGridView2.ReadOnly = True
                    Call jumlahProd()
                    Call jumlahTRProd()
                    Call feeProd()
                    Call totalFEE()
                End If
            End If
        End If
        Cmd = New OdbcCommand("Select * from pegawai where NAMA ='" & GunaComboBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        GunaLabel11.Text = Rd.Item("NOHP")

    End Sub

    Private Sub lblFEE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lblFEE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text.Trim() <> "" Then
                TextBox1.Text = CDec(TextBox1.Text).ToString("N0")
                TextBox1.SelectionStart = TextBox1.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaComboBox2.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "' and PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detaillayan")
        GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
        GunaDataGridView1.ReadOnly = True
        Call jumlah()
        Call jumlahTR()
        Call fee()
        Call totalFEE()

        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "' and PEGAWAI='" & GunaComboBox1.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detailjual")
        GunaDataGridView2.DataSource = Ds.Tables("detailjual")
        GunaDataGridView2.ReadOnly = True
        Call jumlahProd()
        Call jumlahTRProd()
        Call feeProd()
        Call totalFEE()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Try
            If TextBox2.Text.Trim() <> "" Then
                TextBox2.Text = CDec(TextBox2.Text).ToString("N0")
                TextBox2.SelectionStart = TextBox2.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TBtot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBtot.TextChanged
        Try
            If TBtot.Text.Trim() <> "" Then
                TBtot.Text = CDec(TBtot.Text).ToString("N0")
                TBtot.SelectionStart = TBtot.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaGroupBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox2.Click

    End Sub

    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
        If GCjenis.Text = "" Or GunaComboBox1.Text = "" Or TBomz.Text = "" Or GunaLabel6.Text = "" Or TBfee.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or LBLbr.Text = "" Or TBtot.Text = "" Then
            MsgBox("DATA TIDAK LENGKAP")
        Else
            TglMySQL = Format(Today, "yyyy-MM-dd")
            Dim SimpanFee As String = "Insert into fee (PEGAWAI,TGL,BULAN,OMZET,TRANSLAYAN,PRODUK,TRANSPRODUK,FEEPRODUK,FEELAYAN,TOTAL) values ('" & GunaComboBox1.Text & "','" & TglMySQL & "','" & GunaComboBox2.Text & "','" & Val(Microsoft.VisualBasic.Int(TBomz.Text)) & "','" & Val(Microsoft.VisualBasic.Int(GunaLabel6.Text)) & "','" & Val(Microsoft.VisualBasic.Int(TBtot.Text)) & "','" & Val(Microsoft.VisualBasic.Int(LBLbr.Text)) & "','" & Val(Microsoft.VisualBasic.Int(TextBox1.Text)) & "','" & Val(Microsoft.VisualBasic.Int(TBfee.Text)) & "' ,'" & Val(Microsoft.VisualBasic.Int(TextBox2.Text)) & "')"
            Cmd = New OdbcCommand(SimpanFee, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("FEE SUDAH DIPROSES")
            WAgaji.ShowDialog()
        End If
    End Sub
End Class