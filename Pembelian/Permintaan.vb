Imports System.Data.Odbc
Public Class Permintaan
    Dim TglMySQL As String

    Sub kondisiawal()
        Call daftarBarang()
        'TbKodeBar.Text = ""
        TBNamBar.Text = ""
        'GunaComboBox1.Focus()
        TBJum.Text = ""
        TBTot.Text = ""
        TBItem.Text = ""
        Call NobarOtomatis()
        Call MunculKodeBagian()
        BTNBtl.Enabled = False
        Call NomorOtomatis()
        TBtgl.Text = Today
        Call BuatKolom()
        BTNpro.Enabled = False


    End Sub
    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from permintaan where id_perm in (select max(id_perm) From permintaan)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "G /NS /" + Format(Now, "MM") + "/" + Format(Now, "yyyy") + "/" + "00001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 5) + 1
            UrutanKode = "G /NS /" + Format(Now, "MM") + "/" + Format(Now, "yyyy") + "/" + Microsoft.VisualBasic.Right("00000" & Hitung, 5)

        End If
        TBNoOrder.Text = UrutanKode
    End Sub
    Sub NobarOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from barang where id_bar in (select max(id_bar) From barang)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "OPM" + "00001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 5) + 1
            UrutanKode = "OPM" + Microsoft.VisualBasic.Right("00000" & Hitung, 5)

        End If
        TbKodeBar.Text = UrutanKode
    End Sub
    Sub MunculKodeBagian()
        Call Koneksi()
        GunaComboBox1.Items.Clear()
        Cmd = New OdbcCommand("Select * from bagian", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GunaComboBox1.Items.Add(Rd.Item(1))
        Loop

    End Sub
    Sub BuatKolom()
        GunaDataGridView1.Columns.Clear()
        GunaDataGridView1.Columns.Add("Kode", "Kode")
        GunaDataGridView1.Columns.Add("Nama", "Nama Barang")
        GunaDataGridView1.Columns.Add("Harga", "Harga")
        GunaDataGridView1.Columns.Add("Jumlah", "Jumlah")
        GunaDataGridView1.Columns.Add("Satuan", "Satuan")
        GunaDataGridView1.Columns.Add("Subtotal", "Subtotal")


    End Sub
    Sub RumusSubtotal()
        Dim hitung As Integer = 0
        For i As Integer = 0 To GunaDataGridView1.Rows.Count - 1
            hitung = hitung + GunaDataGridView1.Rows(i).Cells(5).Value
            TBTot.Text = hitung
            TBTot.Text = Format(hitung, "###,###,###")
        Next
    End Sub
    Sub RumusCariItem()
        Dim HitungItem As Integer = 0
        For i As Integer = 0 To GunaDataGridView1.Rows.Count - 1
            HitungItem = HitungItem + GunaDataGridView1.Rows(i).Cells(3).Value
            TBItem.Text = HitungItem
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
    
    Private Sub Permintaan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub


    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNkel.Click
        Me.Close()
    End Sub

    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub TBJum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBJum.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then TBsat.Focus()
    End Sub

    Private Sub TBJum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBJum.TextChanged

    End Sub

    Private Sub BTNBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TBKodeBag_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBKodeBag.TextChanged

    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Call Koneksi()
        Cmd = New OdbcCommand("select * from bagian where nama_bag ='" & GunaComboBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            TBKodeBag.Text = Rd!id_bag
            TBNamBar.Focus()
        End If
    End Sub

    Private Sub BTins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTins.Click
        If TBNamBar.Text = "" Or TBJum.Text = "" Then
            MsgBox("Silahkan Masukan Kode BArang dan Tekan ENTER!")

        ElseIf BTins.Text = "INSERT +" Then
            GunaDataGridView1.Rows.Add(New String() {TbKodeBar.Text, TBNamBar.Text, TBharga.Text, TBJum.Text, TBsat.Text, Val(Microsoft.VisualBasic.Str(TBharga.Text)) * Val(TBJum.Text)})

            Call RumusSubtotal()
            Dim SimpanBarang As String = "INSERT INTO barang_beli values('" & TbKodeBar.Text & "','" & TBNamBar.Text & "','" & TBharga.Text & "','" & TBsat.Text & "')"
            Cmd = New OdbcCommand(SimpanBarang, Conn)
            Cmd.ExecuteNonQuery()
            TbKodeBar.Text = ""
            TBNamBar.Text = ""
            TBharga.Text = ""
            TBJum.Text = ""
            TBsat.Text = ""
            Call RumusCariItem()
            BTNpro.Enabled = True
            Call NobarOtomatis()
            Call daftarBarang()


        Else
            If BTins.Text = "INSERT" Then
                GunaDataGridView1.Rows.Add(New String() {TbKodeBar.Text, TBNamBar.Text, TBharga.Text, TBJum.Text, TBsat.Text, Val(Microsoft.VisualBasic.Str(TBharga.Text)) * Val(TBJum.Text)})

                Call RumusSubtotal()
                TbKodeBar.Text = ""
                TBNamBar.Text = ""
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

    Private Sub BTNBtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBtl.Click
        If MessageBox.Show("Hapus Barang : " & GunaDataGridView1.Item(1, GunaDataGridView1.CurrentRow.Index).Value & "?", "KONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If GunaDataGridView1.CurrentRow.Index <> GunaDataGridView1.NewRowIndex Then
                GunaDataGridView1.Rows.RemoveAt(GunaDataGridView1.CurrentRow.Index)
                Call RumusSubtotal()
                BTNBtl.Enabled = False
            End If
        End If
    End Sub

    Private Sub BTNpro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNpro.Click
        If TBKodeBag.Text = "" Then
            MsgBox("Permintaan Tidak Ada, Silahkan Masukan Permintaan Terlebih Dahulu ")
        Else
            If MessageBox.Show("PROSES PERMINTAAN?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                TglMySQL = Format(Today, "yyyy-MM-dd")
                Dim SimpanJual As String = "Insert into permintaan(id_perm,id_bag,total,tgl,NIP) values ('" & TBNoOrder.Text & "','" & TBKodeBag.Text & "','" & TBTot.Text & "','" & TglMySQL & "','" & MenuUtama.LBLnip.Text & "')"
                Cmd = New OdbcCommand(SimpanJual, Conn)
                Cmd.ExecuteNonQuery()

                For Baris As Integer = 0 To GunaDataGridView1.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into det_permintaan(id_perm,id_bar,harga_satuan,jumlah_barang,subtotal) values ('" & TBNoOrder.Text & "','" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(2).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(3).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(5).Value & "')"
                    Cmd = New OdbcCommand(SimpanDetail, Conn)
                    Cmd.ExecuteNonQuery()


                Next

                
            End If
            End If



            Call kondisiawal()
            MsgBox("Proses Pengajuan")
    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        BTNBtl.Enabled = True
    End Sub

    Private Sub TBNamBar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNamBar.KeyPress
        If e.KeyChar = Chr(13) Then TBharga.Focus()
    End Sub

    Private Sub TBNamBar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNamBar.TextChanged
        Call Koneksi()
        Cmd = New OdbcCommand("select * from barang where nama_bar Like '%" & TBNamBar.Text & "%'", Conn)
        Dim rd As OdbcDataReader
        rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call Koneksi()
            Da = New OdbcDataAdapter("select * from barang where nama_bar Like '%" & TBNamBar.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "KetemuData")
            GunaDataGridView2.DataSource = Ds.Tables("KetemuData")
            GunaDataGridView2.ReadOnly = True
        End If
    End Sub

    Private Sub TBtgl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBtgl.TextChanged

    End Sub

    Private Sub TBharga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBharga.KeyPress
        If e.KeyChar = Chr(13) Then TBharga.Text = FormatNumber(TBharga.Text, 0)

        If e.KeyChar = Chr(13) Then TBJum.Focus()


        'If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TBharga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBharga.Leave

    End Sub

    Private Sub TBharga_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBharga.TextChanged
       
    End Sub

    Private Sub TBsat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBsat.KeyPress
        If e.KeyChar = Chr(13) Then BTins.Focus()


    End Sub



    Private Sub TBsat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBsat.TextChanged

    End Sub

    

    Private Sub TbKodeBar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbKodeBar.TextChanged

    End Sub

    Private Sub GunaDataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView2.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = GunaDataGridView2.CurrentRow.Index
        Cmd = New OdbcCommand("Select * from barang where id_bar='" & GunaDataGridView2.Item(0, i).Value & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            TBNamBar.Focus()
        Else
            TbKodeBar.Text = Rd.Item("id_bar")
            TBNamBar.Text = Rd.Item("nama_bar")
            TBharga.Text = Rd.Item("harga")
            TBsat.Text = Rd.Item("satuan")
            BTins.Text = "INSERT"


        End If
    End Sub
End Class