Imports System.Data.Odbc
Public Class Form2
    Dim TglMySQL As String
    Sub hairstylist()
        Call Koneksi()
        GCPegawai.Items.Clear()
        Cmd = New OdbcCommand("Select NAMA from pegawai where JABATAN= '" & GCjabat.Text & "' ", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GCPegawai.Items.Add(Rd.Item(0))
        Loop
    End Sub
    

    Sub kondisiAwal()
        GunaLabel7.Visible = False
        GCjabat.Items.Clear()
        GCjabat.Items.Add("HAIR STYLIST")
        GCjabat.Items.Add("CAPSTER")
        GCjabat.Items.Add("BARBER")


        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.Visible = False
        DateTimePicker2.Visible = False

        GCFilrter.Items.Clear()
        GCFilrter.Items.Add("SEMUA DATA")
        GCFilrter.Items.Add("TAHUN")
        GCFilrter.Items.Add("BULAN")
        GCFilrter.Items.Add("TANGGAL")
        GCBln.Visible = False
        GNThn.Visible = False
        GCBln.Items.Clear()
        GCBln.Items.Add("1")
        GCBln.Items.Add("2")
        GCBln.Items.Add("3")
        GCBln.Items.Add("4")
        GCBln.Items.Add("5")
        GCBln.Items.Add("6")
        GCBln.Items.Add("7")
        GCBln.Items.Add("8")
        GCBln.Items.Add("9")
        GCBln.Items.Add("10")
        GCBln.Items.Add("11")
        GCBln.Items.Add("12")



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

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Call hairstylist()
        Call kondisiAwal()

    End Sub

    Private Sub GCjenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCFilrter.SelectedIndexChanged
        If GCFilrter.Text = "SEMUA DATA" Then
            GunaLabel7.Visible = False
            GCBln.Visible = False
            GNThn.Visible = False
            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False

            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where PEGAWAI='" & GCPegawai.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detaillayan")
            GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
            GunaDataGridView1.ReadOnly = True
            Call jumlah()
            Call jumlahTR()
            'Call fee()


            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where PEGAWAI='" & GCPegawai.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailjual")
            GunaDataGridView2.DataSource = Ds.Tables("detailjual")
            GunaDataGridView2.ReadOnly = True
            Call jumlahProd()
            Call jumlahTRProd()
            
        Else
            If GCFilrter.Text = "TANGGAL" Then
                GunaLabel7.Visible = True
                GunaLabel7.Text = "TANGGAL"
                GCBln.Visible = False
                GNThn.Visible = False
                DateTimePicker1.Visible = True
                DateTimePicker2.Visible = True
            Else
                If GCFilrter.Text = "BULAN" Then
                    GunaLabel7.Visible = True
                    GunaLabel7.Text = "BULAN DAN TAHUN"
                    GCBln.Visible = True
                    GNThn.Visible = True
                    DateTimePicker1.Visible = False
                    DateTimePicker2.Visible = False


                End If
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "' and PEGAWAI='" & GCPegawai.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detaillayan")
        GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
        GunaDataGridView1.ReadOnly = True
        Call jumlah()
        Call jumlahTR()



        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "' and PEGAWAI='" & GCPegawai.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detailjual")
        GunaDataGridView2.DataSource = Ds.Tables("detailjual")
        GunaDataGridView2.ReadOnly = True
        Call jumlahProd()
        Call jumlahTRProd()
       
    End Sub

    Private Sub GCPegawai_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCPegawai.SelectedIndexChanged
        If DateTimePicker1.Visible = True Then
            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where TANGGAL= '" & DateTimePicker1.Text & "' and PEGAWAI='" & GCPegawai.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detaillayan")
            GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
            GunaDataGridView1.ReadOnly = True
            Call jumlah()
            Call jumlahTR()
            'Call fee()


            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where TANGGAL= '" & DateTimePicker1.Text & "' and PEGAWAI='" & GCPegawai.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailjual")
            GunaDataGridView2.DataSource = Ds.Tables("detailjual")
            GunaDataGridView2.ReadOnly = True
            Call jumlahProd()
            Call jumlahTRProd()
            
        Else
            If GCFilrter.Text = "SEMUA DATA" Then
                Call Koneksi()
                Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where PEGAWAI='" & GCPegawai.Text & "'", Conn)
                Ds = New DataSet
                Da.Fill(Ds, "detaillayan")
                GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
                GunaDataGridView1.ReadOnly = True
                Call jumlah()
                Call jumlahTR()
               

                Call Koneksi()
                Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where PEGAWAI='" & GCPegawai.Text & "'", Conn)
                Ds = New DataSet
                Da.Fill(Ds, "detailjual")
                GunaDataGridView2.DataSource = Ds.Tables("detailjual")
                GunaDataGridView2.ReadOnly = True
                Call jumlahProd()
                Call jumlahTRProd()
               
            Else
                If GCFilrter.Text = "BULAN" Then
                    Call Koneksi()
                    Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where YEAR(TANGGAL)='" & GNThn.Value & "'  and PEGAWAI='" & GCPegawai.Text & "' and MONTH(TANGGAL)= '" & GCBln.Text & "'", Conn)
                    Ds = New DataSet
                    Da.Fill(Ds, "detaillayan")
                    GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
                    GunaDataGridView1.ReadOnly = True
                    Call jumlah()
                    Call jumlahTR()
                    

                    Call Koneksi()
                    Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where  MONTH(TANGGAL)= '" & GCBln.Text & "' and PEGAWAI='" & GCPegawai.Text & "' and YEAR(TANGGAL)='" & GNThn.Value & "'", Conn)
                    Ds = New DataSet
                    Da.Fill(Ds, "detailjual")
                    GunaDataGridView2.DataSource = Ds.Tables("detailjual")
                    GunaDataGridView2.ReadOnly = True
                    Call jumlahProd()
                    Call jumlahTRProd()
                    
                End If
            End If
        End If
        Cmd = New OdbcCommand("Select * from pegawai where NAMA ='" & GCPegawai.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()



    End Sub

    Private Sub lblFEE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lblFEE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

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

   

    Private Sub GunaComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCBln.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT jual.TANGGAL,jual.JAM,pelanggan.NAMA,layanan.LAYANAN,detaillayan.JUMLAH,detaillayan.TOTAL From(detaillayan) LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP where TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "' and PEGAWAI='" & GCPegawai.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detaillayan")
        GunaDataGridView1.DataSource = Ds.Tables("detaillayan")
        GunaDataGridView1.ReadOnly = True
        Call jumlah()
        Call jumlahTR()



        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT barang.NAMA,barang.MERK,jual.TANGGAL,pelanggan.NAMA,detailjual.HARGA,detailjual.PEGAWAI From(detailjual) LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP Where TANGGAL between '" & DateTimePicker1.Text & "' and '" & DateTimePicker2.Text & "' and PEGAWAI='" & GCPegawai.Text & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "detailjual")
        GunaDataGridView2.DataSource = Ds.Tables("detailjual")
        GunaDataGridView2.ReadOnly = True
        Call jumlahProd()
        Call jumlahTRProd()
        
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

    'Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
    '    'If GCFilrter.Text = "" Or GCPegawai.Text = "" Or TBomz.Text = "" Or GunaLabel6.Text = "" Or TBfee.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or LBLbr.Text = "" Or TBtot.Text = "" Then
    '    '    MsgBox("DATA TIDAK LENGKAP")
    '    'Else
    '    '    TglMySQL = Format(Today, "yyyy-MM-dd")
    '    '    Dim SimpanFee As String = "Insert into fee (PEGAWAI,TGL,BULAN,OMZET,TRANSLAYAN,PRODUK,TRANSPRODUK,FEEPRODUK,FEELAYAN,TOTAL) values ('" & GCPegawai.Text & "','" & TglMySQL & "','" & GCBln.Text & "','" & Val(Microsoft.VisualBasic.Int(TBomz.Text)) & "','" & Val(Microsoft.VisualBasic.Int(GunaLabel6.Text)) & "','" & Val(Microsoft.VisualBasic.Int(TBtot.Text)) & "','" & Val(Microsoft.VisualBasic.Int(LBLbr.Text)) & "','" & Val(Microsoft.VisualBasic.Int(TextBox1.Text)) & "','" & Val(Microsoft.VisualBasic.Int(TBfee.Text)) & "' ,'" & Val(Microsoft.VisualBasic.Int(TextBox2.Text)) & "')"
    '    '    Cmd = New OdbcCommand(SimpanFee, Conn)
    '    '    Cmd.ExecuteNonQuery()
    '    '    MsgBox("FEE SUDAH DIPROSES")
    '    '    WAgaji.ShowDialog()
    '    'End If
    'End Sub

    Private Sub GunaComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCjabat.SelectedIndexChanged
        If GCjabat.Text = "HAIR STYLIST" Then

            Call Koneksi()
            GCPegawai.Items.Clear()
            Cmd = New OdbcCommand("Select NAMA from pegawai where JABATAN='HAIR STYLIST'", Conn)
            Rd = Cmd.ExecuteReader
            Do While Rd.Read
                GCPegawai.Items.Add(Rd.Item(0))
            Loop

        End If

        If GCjabat.Text = "BARBER" Then

            Call Koneksi()
            GCPegawai.Items.Clear()
            Cmd = New OdbcCommand("Select NAMA from pegawai where JABATAN='BARBER'", Conn)
            Rd = Cmd.ExecuteReader
            Do While Rd.Read
                GCPegawai.Items.Add(Rd.Item(0))
            Loop

        End If

        If GCjabat.Text = "CAPSTER" Then

            Call Koneksi()
            GCPegawai.Items.Clear()
            Cmd = New OdbcCommand("Select NAMA from pegawai where JABATAN='CAPSTER'", Conn)
            Rd = Cmd.ExecuteReader
            Do While Rd.Read
                GCPegawai.Items.Add(Rd.Item(0))
            Loop

        End If
    End Sub

    Private Sub GunaNumeric2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GNThn.ValueChanged

    End Sub
End Class