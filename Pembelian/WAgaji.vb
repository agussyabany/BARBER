Imports System.Data.Odbc
Public Class WAgaji

    Private Sub GunaButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton6.Click
        BotWA.Button2.PerformClick()
        'idgtjn = TBhareg.Text
        'pesankirim = GunaTextBox1.Text
    End Sub

    Private Sub GunaGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox1.Click

    End Sub

    Sub KondisiAwal()

        'GunaTextBox2.Text = Penjualan.TBfaktur.Text
        'Call isibox()

    End Sub
    Sub isibox()
        'Call Koneksi()
        'Cmd = New OdbcCommand("Select jual.IDJUAL,pelanggan.NAMA,jual.NOHP,jual.TANGGAL,jual.JAM,jual.BIAYA,layanan.LAYANAN,detaillayan.HARGA,detaillayan.JUMLAH,detaillayan.TOTAL,detaillayan.JUMLAH,detaillayan.PEGAWAI,barang.NAMA,detailjual.HARGA,detailjual.JUMLAH,detailjual.TOTAL,detailjual.PEGAWAI from(jual) LEFT JOIN pelanggan ON jual.NOHP=pelanggan.NOHP LEFT JOIN layanan ON detaillayan.KODEL=layanan.KODEL LEFT JOIN barang ON detailjual.KODE=barang.KODE LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL where IDJUAL='" & GunaTextBox2.Text & "'", Conn)
        'Rd = Cmd.ExecuteReader
        'Rd.Read()
        'If Rd.HasRows Then
        '    GunaTextBox1.Text = "Kepada+yang+terhormat+Bapak%2FIbu+%2C+terimakasih+telah+melakukan+transaksi+JORDAN++HAIR+STUDIO%2C+berikut+nota+transaksi+Bapak%2FIbu+%F0%9F%99%8F+%3A%0D%0A-------------------------------------------------%0D%0AJORDAN+HAIR+STUDIO%0D%0A0811584523%0D%0AOUTLET%0D%0AJl.+Imam+Bonjol+%0D%0ASamarinda+Kaltim%0D%0A%0D%0ABuka+Setiap+Hari+%0D%0A-------------------------------------------------%0D%0APelanggan+%3A+pak+" + Rd.Item("NAMA") + "%0D%0ANo.+Telp+%3A+" + Rd.Item("NOHP") + "%0D%0A-------------------------------------------------%0D%0AStatus+%3A+LUNAS%0D%0ANo.+Nota+%3A" + Rd.Item("IDJUAL") + "%0D%0ATgl.+Transaksi+%3A+" + Rd.Item("TANGGAL") + "%0D%0A-------------------------------------------------%0D%0ADetail+Layanan+%3A%0D%0A" + Rd.Item("KODEL") + "K%0D%0A" + Rd.Item("LAYANAN") + "%28satuan%29+x" + Rd.Item("HARGA") + "%3D+40.000%0D%0A-------------------------------------------------%0D%0ASUBTOTAL+%3A" + Rd.Item("TOTAL") + "%0D%0ADISKON+%3A+0%0D%0ATOTAL+%3A+" + Rd.Item("BIAYA") + "%0D%0A%0D%0A-------------------------------------------------%0D%0AHair+Stylist+%3A" + Rd.Item("PEGAWAI") + "%0D%0A-------------------------------------------------%0D%0ACatatan+%3A"



        '    'Penjualan.TBKode.Text = Rd.Item("KODE")
        '    'Penjualan.TBLayan.Text = Rd.Item("NAMA")
        '    'Penjualan.Tbnampro.Text = Rd.Item("MERK")
        '    'Penjualan.TBhareg.Text = Rd.Item("HJUAL")
        '    ''Penjualan.TBhareg.Text = FormatNumber(Penjualan.TBhareg.Text, 0)
        '    'Penjualan.TBstok.Text = Rd.Item("JUMLAH")


        'End If

        'Dim pesan As String = ""

        'Dim DATANYA = "JORDAN+HAIR+STUDIO%0D%0A0811584523%0D%0AOUTLET%0D%0AJl.+Imam+Bonjol+%0D%0ASamarinda+Kaltim%0D%0A-------------------------------------------------%0D%0A%0D%0AKepada+yang+terhormat+Bapak%2FIbu++Rekan+Dan+Karyawan+%0D%0AJORDAN+HAIR+STUDIO%F0%9F%99%8F+Berikut+adalah+Laporan++Fee+Dan+Atau+Gajih+Bulan+%3A%0D%0A" + Form2.GCBln.Text + "-------------------------------------------------%0D%0ANAMA+%3A+" + Form2.GCPegawai.Text + "%0D%0ANo.+Telp+" + Form2.GunaLabel11.Text + "%0D%0A-------------------------------------------------%0D%0ATotal+Layanan+++++++++++%3A++" + Form2.TBomz.Text + "%0D%0ATransaksi+Layanan+++%3A++" + Form2.GunaLabel6.Text + "%0D%0ATransaksi+Produk+++++%3A+++" + Form2.LBLbr.Text + "%0D%0A+%3A+%0D%0A-------------------------------------------------%0D%0AFee+Layanan+40%25+%3A++" + Form2.TBfee.Text + "%0D%0AFee+Produk++++++++++++%3A++" + Form2.TextBox1.Text + "%0D%0A%0D%0A-------------------------------------------------%0D%0ASUBTOTAL+++%3A++" + Form2.TextBox2.Text + "%0D%0APOTONGAN+%3A+0%0D%0ATOTAL+%3A+" + Form2.TextBox2.Text + "%2CA%0D%0A%0D%0A-------------------------------------------------%0D%0ATETAP+SEMANGAT%21%21%0D%0A-------------------------------------------------%0D%0ACatatan+%3A"
        'pesan = pesan & "" & Environment.NewLine & DATANYA & "" & Environment.NewLine

        'GunaTextBox1.Text = pesan



        'Dim pesan As String = ""
        'For Baris As Integer = 0 To Penjualan.GDV1.Rows.Count - 2
        '    Dim DATANYA = "JORDAN BARBER" + Environment.NewLine + Penjualan.TBfaktur.Text + Environment.NewLine + Penjualan.TBnama.Text + Environment.NewLine + "PRODUK DAN LAYANAN :" + Penjualan.GDV1.Rows(Baris).Cells(1).Value + Environment.NewLine + "MERK :" & Penjualan.GDV1.Rows(Baris).Cells(2).Value + Environment.NewLine + "HARGA : " & Penjualan.GDV1.Rows(Baris).Cells(3).Value + Environment.NewLine + "JUMLAH: " & Penjualan.GDV1.Rows(Baris).Cells(4).Value + Environment.NewLine + "SUBTOTAL RP : " & Penjualan.GDV1.Rows(Baris).Cells(5).Value + Environment.NewLine + "HAIRSTYLIST :" & Penjualan.GDV1.Rows(Baris).Cells(6).Value + Environment.NewLine + " TERIMAKASIH ATAS KUNJUNGAN ANDA.... "
        '    pesan = pesan & "" & Environment.NewLine & DATANYA & "" & Environment.NewLine



        '    'GunaTextBox1.Text = "JORDAN BARABER DAN COFEE" + Environment.NewLine + TBfaktur.Text + Environment.NewLine + TBnama.Text + Environment.NewLine + "PRODUK & LAYANAN :" + GDV1.Rows(Baris).Cells(1).Value + Environment.NewLine + "MERK :" & GDV1.Rows(Baris).Cells(2).Value + Environment.NewLine + "HARGA : " & GDV1.Rows(Baris).Cells(3).Value + Environment.NewLine + "JUMLAH: " & GDV1.Rows(Baris).Cells(4).Value + Environment.NewLine + "SUBTOTAL RP : " & GDV1.Rows(Baris).Cells(5).Value + Environment.NewLine + "HAIRSTYLIST :" & GDV1.Rows(Baris).Cells(6).Value + Environment.NewLine + " TERIMAKASIH ATAS KUNJUNGAN ANDA.... "


        'Next
        'GunaTextBox1.Text = pesan


    End Sub

    Private Sub WAgaji_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged

    End Sub
End Class