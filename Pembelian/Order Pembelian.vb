Imports System.Data.Odbc
Public Class Order_Pembelian

    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from or_pembelian where id_pemb in (select max(id_pemb) From or_pembelian)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "OP /" + Format(Now, "MM") + "/" + Format(Now, "yyyy") + "/" + "00001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 5) + 1
            UrutanKode = "OP /" + Format(Now, "MM") + "/" + Format(Now, "yyyy") + "/" + Microsoft.VisualBasic.Right("00000" & Hitung, 5)

        End If
        TBNoOrder.Text = UrutanKode
    End Sub
    Sub NomorAmbil()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from or_pembelian where id_penerimaan in (select max(id_penerimaan) From or_pembelian)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "LP /" + Format(Now, "MM") + "/" + Format(Now, "yyyy") + "/" + "00001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 5) + 1
            UrutanKode = "LP /" + Format(Now, "MM") + "/" + Format(Now, "yyyy") + "/" + Microsoft.VisualBasic.Right("00000" & Hitung, 5)

        End If
        TBnoAmbil.Text = UrutanKode
    End Sub

    Sub NobarOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from barang_beli where id_barbel in (select max(id_barbel) From barang_beli)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "OPB" + "00001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 5) + 1
            UrutanKode = "OPB" + Microsoft.VisualBasic.Right("00000" & Hitung, 5)

        End If
        TbKodeBar.Text = UrutanKode
    End Sub
    Sub RumusSubtotal()
        Dim hitung As Integer = 0
        For i As Integer = 0 To GunaDataGridView2.Rows.Count - 1
            hitung = hitung + GunaDataGridView2.Rows(i).Cells(5).Value
            TBtotal.Text = hitung
            TBtotal.Text = Format(hitung, "###,###,###")
        Next
    End Sub
    Sub RumusCariItem()
        Dim HitungItem As Integer = 0
        For i As Integer = 0 To GunaDataGridView2.Rows.Count - 1
            HitungItem = HitungItem + GunaDataGridView2.Rows(i).Cells(3).Value
            TBitemBeli.Text = HitungItem
        Next
    End Sub
    Sub daftarBarang()
        Call Koneksi()
        Da = New OdbcDataAdapter("Select id_bar,nama_bar,harga,satuan From barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "barang")
        GunaDataGridView2.DataSource = Ds.Tables("barang")
        GunaDataGridView2.ReadOnly = True

    End Sub
    Sub BuatKolom()
        GunaDataGridView2.Columns.Clear()
        GunaDataGridView2.Columns.Add("Kode", "Kode")
        GunaDataGridView2.Columns.Add("Nama", "Nama Barang")
        GunaDataGridView2.Columns.Add("Harga", "Harga")
        GunaDataGridView2.Columns.Add("Jumlah", "Jumlah")
        GunaDataGridView2.Columns.Add("Satuan", "Satuan")
        GunaDataGridView2.Columns.Add("Subtotal", "Subtotal")
        GunaDataGridView2.Columns.Add("Laveransir", "Laveransir")


    End Sub

    Private Sub Order_Pembelian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        Call NomorOtomatis()
        Call NomorAmbil()
        Call NobarOtomatis()
        Call BuatKolom()
        TBtgl.Text = Today
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Call Koneksi()
        GunaComboBox1.Items.Clear()
        Cmd = New OdbcCommand("SELECT * FROM permintaan WHERE tgl ='" & DateTimePicker1.Text & "' and kasi_pembelian3 = ACC", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read()
            GunaComboBox1.Items.Add(Rd.Item(0))
        Loop
    End Sub

    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub BTNkel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNkel.Click
        Me.Close()
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Call Koneksi()
        Cmd = New OdbcCommand("SELECT det_permintaan.id_perm,permintaan.tgl,barang.nama_bar,det_permintaan.harga_satuan,det_permintaan.jumlah_barang,det_permintaan.subtotal,bagian.nama_bag,permintaan.kasi_pembelian,permintaan.kasi_anggaran,permintaan.pel_anggaran,permintaan.kasi_anggaran2,permintaan.kasi_pembelian2,permintaan.kabag_umum,permintaan.dirum,permintaan.kasi_pembelian3,permintaan.total,det_permintaan.status FROM(det_permintaan) LEFT JOIN barang ON det_permintaan.id_bar=barang.id_bar LEFT JOIN permintaan ON det_permintaan.id_perm=permintaan.id_perm LEFT JOIN bagian ON permintaan.id_bag=bagian.id_bag WHERE det_permintaan.id_perm='" & GunaComboBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then

            TbNamBag.Text = Rd!nama_bag
            TBItem.Text = Rd!kasi_pembelian
            TBTot.Text = Rd!total

          

            Da = New OdbcDataAdapter("SELECT barang.id_bar,barang.nama_bar,det_permintaan.harga_satuan,det_permintaan.jumlah_barang,barang.satuan,det_permintaan.subtotal FROM(det_permintaan) LEFT JOIN barang ON det_permintaan.id_bar=barang.id_bar LEFT JOIN permintaan ON det_permintaan.id_perm=permintaan.id_perm LEFT JOIN bagian ON permintaan.id_bag=bagian.id_bag WHERE det_permintaan.id_perm='" & GunaComboBox1.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "det_permintaan")
            GunaDataGridView1.DataSource = Ds.Tables("det_permintaan")

        End If
    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = GunaDataGridView1.CurrentRow.Index
        Cmd = New OdbcCommand("SELECT barang.id_bar,barang.nama_bar,det_permintaan.harga_satuan,det_permintaan.jumlah_barang,barang.satuan,det_permintaan.subtotal,det_permintaan.status FROM(det_permintaan) LEFT JOIN barang ON det_permintaan.id_bar=barang.id_bar LEFT JOIN permintaan ON det_permintaan.id_perm=permintaan.id_perm LEFT JOIN bagian ON permintaan.id_bag=bagian.id_bag WHERE det_permintaan.id_bar='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            TBnamBar.Focus()
        Else
            TBharga.Text = Rd.Item("harga_satuan")
            TBnamBar.Text = Rd.Item("nama_bar")
            TBJum.Text = Rd.Item("jumlah_barang")


        End If
    End Sub

    Private Sub BTins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTins.Click
        If TBnamBar.Text = "" Or TBJum.Text = "" Then
            MsgBox("Silahkan Masukan Kode BArang dan Tekan ENTER!")

        ElseIf BTins.Text = "INSERT +" Then
            GunaDataGridView2.Rows.Add(New String() {TBKodeBAR.Text, TBnamBar.Text, TBharga.Text, TBJum.Text, TBsat.Text, Val(Microsoft.VisualBasic.Str(TBharga.Text)) * Val(TBJum.Text), Tblav.Text})

            Call RumusSubtotal()
            Dim SimpanBarang As String = "INSERT INTO barang_beli values('" & TBKodeBAR.Text & "','" & TBnamBar.Text & "','" & TBharga.Text & "','" & TBsat.Text & "')"
            Cmd = New OdbcCommand(SimpanBarang, Conn)
            Cmd.ExecuteNonQuery()
            TbKodeBar.Text = ""
            TBnamBar.Text = ""
            TBharga.Text = ""
            TBJum.Text = ""
            TBsat.Text = ""
            Call RumusCariItem()
            BTNpro.Enabled = True
            Call NobarOtomatis()
            'Call daftarBarang()


        Else
            If BTins.Text = "INSERT" Then
                GunaDataGridView2.Rows.Add(New String() {TBKodeBAR.Text, TBnamBar.Text, TBharga.Text, TBJum.Text, TBsat.Text, Val(Microsoft.VisualBasic.Str(TBharga.Text)) * Val(TBJum.Text)})

                Call RumusSubtotal()
                TbKodeBar.Text = ""
                TBnamBar.Text = ""
                TBharga.Text = ""
                TBJum.Text = ""
                TBsat.Text = ""
                Call RumusCariItem()
                BTNpro.Enabled = True
                Call NobarOtomatis()
                BTins.Text = "INSERT +"

            End If
        End If
    End Sub

    Private Sub BTNpro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNpro.Click

    End Sub

    Private Sub GunaDataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView3.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = GunaDataGridView2.CurrentRow.Index
        Cmd = New OdbcCommand("Select * from barang_beli where id_barbel='" & GunaDataGridView3.Item(0, i).Value & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            TBnamBar.Focus()
        Else
            TBKodeBAR.Text = Rd.Item("id_bar")
            TBnamBar.Text = Rd.Item("nama_bar")
            TBharga.Text = Rd.Item("harga")
            TBsat.Text = Rd.Item("satuan")
            BTins.Text = "INSERT"


        End If
    End Sub
End Class