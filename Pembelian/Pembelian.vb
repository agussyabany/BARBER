Imports System.Data.Odbc
Public Class Pembelian
    Dim TglMySQL As String
    Sub kondisiAwal()
        BTsimpan.Enabled = False
        BThapus.Enabled = True
        'TBfaktur.Text = ""
        GCsup.Text = ""
        GCjenis.Text = ""
        TBkobar.Text = ""
        TBnambar.Text = ""
        TBmerk.Text = ""
        TBsatuan.Text = ""
        TBkat.Text = ""
        TBharbel.Text = ""
        TBharju.Text = ""
        TBjumbel.Text = ""
        TBtime.Text = Today
        Call suplier()
        GCjenis.Items.Clear()
        GCjenis.Items.Add("TUNAI")
        GCjenis.Items.Add("INVOICE")
        Call BuatKolom()
    End Sub

    Sub suplier()
        Call Koneksi()
        GCsup.Items.Clear()
        Cmd = New OdbcCommand("Select NAMA from suplier", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GCsup.Items.Add(Rd.Item(0))
        Loop
    End Sub
    Sub BuatKolom()
        GunaDataGridView1.Columns.Clear()
        GunaDataGridView1.Columns.Add("KODE", "KODE")
        GunaDataGridView1.Columns.Add("NAMA", "NAMA")
        GunaDataGridView1.Columns.Add("MERK", "MERK")
        GunaDataGridView1.Columns.Add("SATUAN", "SATUAN")
        GunaDataGridView1.Columns.Add("HARGA", "HARGA")
        GunaDataGridView1.Columns.Add("JUMLAH", "JUMLAH")
        GunaDataGridView1.Columns.Add("SUBTOTAL", "SUBTOTAL")
        GunaDataGridView1.Columns.Add("KATEGORI", "KATEGORI")
        GunaDataGridView1.Columns.Add("JUAL", "JUAL")



    End Sub
    Sub clear()
        TBkobar.Text = ""
        TBnambar.Text = ""
        TBmerk.Text = ""
        TBsatuan.Text = ""
        TBkat.Text = ""
        TBharbel.Text = ""
        TBharju.Text = ""
        TBjumbel.Text = ""
    End Sub
    Sub RumusSubtotal()
        Dim hitung As Integer = 0
        For i As Integer = 0 To GunaDataGridView1.Rows.Count - 1
            hitung = hitung + GunaDataGridView1.Rows(i).Cells(6).Value
            GunaLabel17.Text = hitung
            'GunaLabel17.Text = Format(hitung, "###,###,###")
        Next
    End Sub

    Private Sub Pembelian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()

    End Sub
    Private Sub GunaLabel10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaLabel10.Click

    End Sub
    
    Private Sub GunaLabel11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaLabel11.Click

    End Sub

    Private Sub GunaLinePanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaLinePanel1.Paint

    End Sub

    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBtime.TextChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Call clear()
        BTsimpan.Enabled = False
        DataBarang.ShowDialog()
    End Sub

    Private Sub GunaButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton6.Click
        Me.Close()
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        MasterSuplier.ShowDialog()
    End Sub

    Private Sub GCjenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCjenis.SelectedIndexChanged
        If GCjenis.Text = "TUNAI" Then GDTinvo.Visible = False Else GDTinvo.Visible = True



    End Sub

    Private Sub TBharbel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBharbel.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            TBjumbel.Focus()
        End If
    End Sub

    Private Sub TBharbel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBharbel.TextChanged

    End Sub

    Private Sub TBharju_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBharju.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TBharju_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBharju.TextChanged

    End Sub

    Private Sub TBkat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBkat.TextChanged
        If TBkat.Text = "" Then GunaButton1.Focus() Else TBharbel.Focus()
    End Sub

    Private Sub BTinput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTinput.Click
        If TBfaktur.Text = "" Or GCsup.Text = "" Or GCjenis.Text = "" Or TBnambar.Text = "" Or TBsatuan.Text = "" Or TBkat.Text = "" Or TBharbel.Text = "" Or TBharju.Text = "" Or TBjumbel.Text = "" Then
            MsgBox("Silahkan Masukan Kode BArang dan Tekan ENTER!")
        Else
            GunaDataGridView1.Rows.Add(New String() {TBkobar.Text, TBnambar.Text, TBmerk.Text, TBsatuan.Text, TBharbel.Text, TBjumbel.Text, Val(Microsoft.VisualBasic.Str(TBharbel.Text)) * Val(TBjumbel.Text), TBkat.Text, TBharju.Text})
            BTsimpan.Enabled = True
            Call RumusSubtotal()
            Call clear()

            
            


        End If

    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        BThapus.Enabled = True
    End Sub

    Private Sub BThapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BThapus.Click
        If MessageBox.Show("Hapus Barang : " & GunaDataGridView1.Item(1, GunaDataGridView1.CurrentRow.Index).Value & "?", "KONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If GunaDataGridView1.CurrentRow.Index <> GunaDataGridView1.NewRowIndex Then
                GunaDataGridView1.Rows.RemoveAt(GunaDataGridView1.CurrentRow.Index)
                Call RumusSubtotal()
                BThapus.Enabled = False
            End If
        End If
    End Sub

    Private Sub BTsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTsimpan.Click
        'If TBfaktur.Text = "" Or GCsup.Text = "" Or GCjenis.Text = "" Or TBnambar.Text = "" Or TBsatuan.Text = "" Or TBkat.Text = "" Then
        '    MsgBox("Silahkan Masukan Kode BArang dan Tekan ENTER!")
        'Else
        If MessageBox.Show("Apakah Ingin Menyimpan Transaksi?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If GCjenis.Text = "TUNAI" Then
                TglMySQL = Format(Today, "yyyy-MM-dd")
                Dim SimpanBeli As String = "Insert into pembelian (FAKTUR,TANGGAL,SUPLIER,JENIS,TOTAL) values ('" & TBfaktur.Text & "','" & TglMySQL & "','" & GCsup.Text & "','" & GCjenis.Text & "','" & GunaLabel17.Text & "')"
                Cmd = New OdbcCommand(SimpanBeli, Conn)
                Cmd.ExecuteNonQuery()

                For Baris As Integer = 0 To GunaDataGridView1.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into detailbeli values('" & TBfaktur.Text & "','" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(4).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(5).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(6).Value & "')"
                    Cmd = New OdbcCommand(SimpanDetail, Conn)
                    Cmd.ExecuteNonQuery()

                    Cmd = New OdbcCommand("select * from barang where KODE = '" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    Dim UpdateTblBrg As String = "Update barang set JUMLAH = '" & Rd.Item("JUMLAH") + GunaDataGridView1.Rows(Baris).Cells(5).Value & "',HBELI='" & Val(Microsoft.VisualBasic.Str(GunaDataGridView1.Rows(Baris).Cells(4).Value)) & "',HPP='" & (Rd.Item("TOTAL") + GunaDataGridView1.Rows(Baris).Cells(6).Value) / (Rd.Item("JUMLAH") + GunaDataGridView1.Rows(Baris).Cells(5).Value) & "' where KODE='" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'"
                    Cmd = New OdbcCommand(UpdateTblBrg, Conn)
                    Cmd.ExecuteNonQuery()

                    Cmd = New OdbcCommand("select * from barang where KODE = '" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    Dim UpdateTotal As String = "Update barang set TOTAL='" & Rd.Item("JUMLAH") * Rd.Item("HPP") & "' where KODE='" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'"
                    Cmd = New OdbcCommand(UpdateTotal, Conn)
                    Cmd.ExecuteNonQuery()

                    Cmd = New OdbcCommand("select * from barang where KODE = '" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    Dim UpdateHjual As String = "Update barang set HJUAL='" & GunaDataGridView1.Rows(Baris).Cells(8).Value & "' where KODE='" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'"
                    Cmd = New OdbcCommand(UpdateHjual, Conn)
                    Cmd.ExecuteNonQuery()
                Next
                Call kondisiAwal()
                MsgBox("Transaksi Berhasil")

            ElseIf GCjenis.Text = "INVOICE" Then
                TglMySQL = Format(Today, "yyyy-MM-dd")
                Dim SimpanBeli As String = "Insert into pembelian (FAKTUR,TANGGAL,SUPLIER,JENIS,DEADLINE,TOTAL) values ('" & TBfaktur.Text & "','" & TglMySQL & "','" & GCsup.Text & "','" & GCjenis.Text & "','" & GDTinvo.Text & "','" & GunaLabel17.Text & "')"
                Cmd = New OdbcCommand(SimpanBeli, Conn)
                Cmd.ExecuteNonQuery()


                For Baris As Integer = 0 To GunaDataGridView1.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into detailbeli values('" & TBfaktur.Text & "','" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(4).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(5).Value & "','" & GunaDataGridView1.Rows(Baris).Cells(6).Value & "')"
                    Cmd = New OdbcCommand(SimpanDetail, Conn)
                    Cmd.ExecuteNonQuery()

                    Cmd = New OdbcCommand("select * from barang where KODE = '" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    Dim UpdateTblBrg As String = "Update barang set JUMLAH = '" & Rd.Item("JUMLAH") + GunaDataGridView1.Rows(Baris).Cells(5).Value & "',HBELI='" & Val(Microsoft.VisualBasic.Str(GunaDataGridView1.Rows(Baris).Cells(4).Value)) & "',HPP='" & (Rd.Item("TOTAL") + GunaDataGridView1.Rows(Baris).Cells(6).Value) / (Rd.Item("JUMLAH") + GunaDataGridView1.Rows(Baris).Cells(5).Value) & "' where KODE='" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'"
                    Cmd = New OdbcCommand(UpdateTblBrg, Conn)
                    Cmd.ExecuteNonQuery()

                    Cmd = New OdbcCommand("select * from barang where KODE = '" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    Dim UpdateTotal As String = "Update barang set TOTAL='" & Rd.Item("JUMLAH") * Rd.Item("HPP") & "' where KODE='" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'"
                    Cmd = New OdbcCommand(UpdateTotal, Conn)
                    Cmd.ExecuteNonQuery()

                    Cmd = New OdbcCommand("select * from barang where KODE = '" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    Dim UpdateHjual As String = "Update barang set HJUAL='" & Val(Microsoft.VisualBasic.Str(TBharju.Text)) & "' where KODE='" & GunaDataGridView1.Rows(Baris).Cells(0).Value & "'"
                    Cmd = New OdbcCommand(UpdateHjual, Conn)
                    Cmd.ExecuteNonQuery()
                Next
                Call kondisiAwal()
                MsgBox("Transaksi Berhasil")

            End If
        End If
        
    End Sub

    Private Sub TBjumbel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBjumbel.KeyPress
        

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        

        If e.KeyChar = Chr(13) Then
            If TBjumbel.Text = "" Then
                MsgBox("ISI JUMLAH BELI")
            Else
                TBhpp.Text = ((Rd.Item("TOTAL") + (TBharbel.Text * TBjumbel.Text)) / (Rd.Item("JUMLAH") + TBjumbel.Text))
                TBharju.Text = TBhpp.Text + (TBhpp.Text * (20 / 100))
                BTinput.Focus()
                TBharbel.Text = Format(CInt(TBharbel.Text), 0)
                TBharju.Text = Format(CInt(TBharju.Text), 0)
                TBhpp.Text = Format(CInt(TBhpp.Text), 0)
                'GunaDataGridView1.Columns.Clear()
                'GunaDataGridView1.Columns.Add("KODE", "KODE")0
                'GunaDataGridView1.Columns.Add("NAMA", "NAMA")1
                'GunaDataGridView1.Columns.Add("MERK", "MERK")2
                'GunaDataGridView1.Columns.Add("SATUAN", "SATUAN")3
                'GunaDataGridView1.Columns.Add("HARGA", "HARGA")4
                'GunaDataGridView1.Columns.Add("JUMLAH", "JUMLAH")5
                'GunaDataGridView1.Columns.Add("SUBTOTAL", "SUBTOTAL")6
                'GunaDataGridView1.Columns.Add("KATEGORI", "KATEGORI")7
            End If

        End If
    End Sub

    Private Sub TBjumbel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBjumbel.TextChanged

    End Sub

    Private Sub GunaGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox1.Click

    End Sub
End Class