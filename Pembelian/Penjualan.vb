
Imports System.Data.Odbc
Public Class Penjualan

    Dim TglMySQL As String
    Sub kondisiAwal()
        LBLjam.Text = TimeOfDay
        Label1.Text = ""
        TextBox1.Text = ""
        LBLKembali.Text = ""
        Tbnampro.Visible = False
        LblNama.Text = "LAYANAN"
        BTinput.Enabled = False
        BTcetak.Enabled = False
        TBhp.Text = ""
        TBnama.Text = ""
        TBalamat.Text = ""
        GunaButton2.Enabled = False
        BTcetak.Enabled = False
        GChs.Visible = False
        GunaGroupBox2.Enabled = False
        TBtime.Text = Today
        Call NomorOtomatis()
        Call BuatKolom()
        'GunaTextBox1.Text = Format(GunaTextBox1, "###,###,###")


    End Sub
    Public Function formatUangKeBilangan(ByVal N As String) As Double
        formatUangKeBilangan = Replace(N, ",", "")
    End Function
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
    'Public Sub formatUangTot(ByVal Text As TextBox)
    '    If Len(Text.Text) > 0 Then
    '        Text.Text = FormatNumber(CDbl(Text.Text), 0)
    '        Dim x As Integer = Text.SelectionStart.ToString
    '        If x = 0 Then
    '            Text.SelectionStart = Len(Text.Text)
    '            Text.SelectionLength = 0
    '        Else
    '            Text.SelectionStart = x
    '            Text.SelectionLength = 0
    '        End If
    '    End If
    'End Sub
    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from jual where IDJUAL in (select max(IDJUAL) From jual)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "JB /" + Format(Now, "MM") + "/" + Format(Now, "yyyy") + "/" + "00001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 5) + 1
            UrutanKode = "JB /" + Format(Now, "MM") + "/" + Format(Now, "yyyy") + "/" + Microsoft.VisualBasic.Right("00000" & Hitung, 5)

        End If
        TBfaktur.Text = UrutanKode
    End Sub
    Sub hairstylist()
        Call Koneksi()
        GChs.Items.Clear()
        Cmd = New OdbcCommand("Select NAMA from pegawai", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GChs.Items.Add(Rd.Item(0))
        Loop
    End Sub
    Sub BuatKolom()
        GDV1.Columns.Clear()
        GDV1.Columns.Add("KODE", "KODE")
        GDV1.Columns.Add("NAMA", "NAMA")
        GDV1.Columns.Add("MERK", "MERK")
        GDV1.Columns.Add("HARGA", "HARGA")
        GDV1.Columns.Add("JUMLAH", "JUMLAH")
        GDV1.Columns.Add("SUBTOTAL", "SUBTOTAL")
        GDV1.Columns.Add("HAIRSTYLIST", "HAIRSTYLIST")
    End Sub
    

    Sub RumusSubtotal()
        Dim hitung As Integer = 0
        For i As Integer = 0 To GDV1.Rows.Count - 1

            hitung = hitung + (GDV1.Rows(i).Cells(5).Value)
            Label1.Text = hitung
            Label1.Text = Format(hitung, "###,###,###")
        Next

    End Sub
    Sub clear()
        TBKode.Text = ""
        TBLayan.Text = ""
        Tbnampro.Text = ""
        GChs.Text = ""
        Tbjum.Text = ""
        TBhareg.Text = ""

    End Sub
    Private Sub Penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()

        
    End Sub
    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub GunaButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GunaButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        GunaGroupBox2.Enabled = True
        DataCostumer.ShowDialog()

    End Sub

    Private Sub GunaRadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaRadioButton1.CheckedChanged

        LblNama.Text = "LAYANAN"
        GChs.Visible = True
        TBstok.Visible = False
        GunaLabel7.Visible = False
        Call hairstylist()

        Call clear()

        Tbnampro.Visible = False
    End Sub

    Private Sub GunaRadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaRadioButton2.CheckedChanged

        LblNama.Text = "PRODUK"
        GChs.Visible = True
        Tbnampro.Visible = True
        TBstok.Visible = True
        GunaLabel7.Visible = True

        Call clear()
    End Sub

    Private Sub GunaRadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaRadioButton3.CheckedChanged
        LblNama.Text = "KOPI"
        GChs.Visible = False
        Tbnampro.Visible = False
        TBstok.Visible = False
        GunaLabel7.Visible = False
        Call clear()

    End Sub

    Private Sub GunaButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton3.Click

        DataCostumer.ShowDialog()
        GunaGroupBox2.Enabled = True
        'If GunaRadioButton1.Checked = True Then
        '    DataLayanan.ShowDialog()
        '    LblNama.Text = "LAYANAN"
        '    GChs.Visible = True
        '    TBstok.Visible = False
        '    GunaLabel7.Visible = False
        '    Call hairstylist()
        '    Tbnampro.Visible = False
        'ElseIf GunaRadioButton2.Checked = True Then
        '    DataProduk.ShowDialog()
        '    LblNama.Text = "PRODUK"
        '    GChs.Visible = False
        '    Tbnampro.Visible = True
        '    TBstok.Visible = True
        '    GunaLabel7.Visible = True

        'End If
        'GunaRadioButton1.Checked = True
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'BTinput.Enabled = True
        'If GunaButton1.Text = "CARI" And GunaRadioButton1.Checked Then
        '    DataLayanan.ShowDialog()
        'ElseIf GunaButton1.Text = "CARI" And GunaRadioButton2.Checked Then
        '    DataProduk.ShowDialog()
        'Else
        '    If GunaButton1.Text = "CARI" And GunaRadioButton3.Checked Then
        '        DataKopi.ShowDialog()
        '    End If

        'End If
    End Sub

    Private Sub GunaGroupBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox2.Click

    End Sub

    Private Sub BTinput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTinput.Click
        

        If GunaRadioButton1.Checked Then
            If TBfaktur.Text = "" Or TBhp.Text = "" Or TBnama.Text = "" Or TBalamat.Text = "" Or TBKode.Text = "" Or TBLayan.Text = "" Or Tbjum.Text = "" Or TBhareg.Text = "" Or GChs.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FORM")
            Else
                GDV1.Rows.Add(New String() {TBKode.Text, TBLayan.Text, Tbnampro.Text, TBhareg.Text, Tbjum.Text, Val(Microsoft.VisualBasic.Str(TBhareg.Text) * Val(Tbjum.Text)), GChs.Text})
                BTcetak.Enabled = True
                Call RumusSubtotal()
                Call clear()
            End If
        End If

        If GunaRadioButton2.Checked Then
            If TBfaktur.Text = "" Or TBhp.Text = "" Or TBnama.Text = "" Or TBalamat.Text = "" Or TBKode.Text = "" Or TBLayan.Text = "" Or Tbjum.Text = "" Or TBhareg.Text = "" Then
                MsgBox("Silahkan Masukan Kode Barang dan Tekan ENTER!")
            Else
                If Val(TBstok.Text) < Val(Tbjum.Text) Then
                    MsgBox("Stok Barang Kurang")
                Else
                    GDV1.Rows.Add(New String() {TBKode.Text, TBLayan.Text, Tbnampro.Text, TBhareg.Text, Tbjum.Text, Val(Microsoft.VisualBasic.Str(TBhareg.Text) * Val(Tbjum.Text)), GChs.Text})
                    BTcetak.Enabled = True
                    Call RumusSubtotal()
                    Call clear()
                End If
            End If
        End If


        If GunaRadioButton3.Checked Then
            If TBfaktur.Text = "" Or TBhp.Text = "" Or TBnama.Text = "" Or TBalamat.Text = "" Or TBKode.Text = "" Or TBLayan.Text = "" Or Tbjum.Text = "" Or TBhareg.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FORM")
            Else
                GDV1.Rows.Add(New String() {TBKode.Text, TBLayan.Text, Tbnampro.Text, TBhareg.Text, Tbjum.Text, Val(Microsoft.VisualBasic.Str(TBhareg.Text) * Val(Tbjum.Text))})
                BTcetak.Enabled = True
                Call RumusSubtotal()
                Call clear()
            End If
        End If




    End Sub

    Private Sub TBhareg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBhareg.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            BTinput.Focus()
            'TBhareg.Text = FormatNumber(TBhareg.Text, 0)
        End If
    End Sub

    Private Sub TBhareg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBhareg.TextChanged
        'TBhareg.Text = Format(TBhareg.Text, 0)
    End Sub

    Private Sub Tbjum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tbjum.KeyPress
        If e.KeyChar = Chr(13) Then
            TBhareg.Focus()
        End If
    End Sub

    Private Sub Tbjum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbjum.TextChanged

    End Sub

    Private Sub BTbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTbatal.Click
        Me.Close()
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        If MessageBox.Show("Hapus Barang : " & GDV1.Item(1, GDV1.CurrentRow.Index).Value & "?", "KONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If GDV1.CurrentRow.Index <> GDV1.NewRowIndex Then
                GDV1.Rows.RemoveAt(GDV1.CurrentRow.Index)
                Call RumusSubtotal()
                GunaButton2.Enabled = False
            End If
        End If
    End Sub

    Private Sub BTcetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTcetak.Click
        If TBfaktur.Text = "" Then
            MsgBox("Silhkan Isi Semua Filed")
        Else



            TglMySQL = Format(Today, "yyyy-MM-dd    ")
            Dim SimpanJual As String = "Insert into jual (IDJUAL,USERID,NOHP,TANGGAL,JAM,BIAYA) values ('" & TBfaktur.Text & "','" & MenuUtama.LBLnip.Text & "','" & TBhp.Text & "','" & TglMySQL & "','" & LBLjam.Text & "','" & Label1.Text & "')"
            Cmd = New OdbcCommand(SimpanJual, Conn)
            Cmd.ExecuteNonQuery()

            For Baris As Integer = 0 To GDV1.Rows.Count - 2
                Cmd = New OdbcCommand("select * from barang where KODE = '" & GDV1.Rows(Baris).Cells(0).Value & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Dim detailProduk As String = "Insert into detailjual values('" & TBfaktur.Text & "','" & GDV1.Rows(Baris).Cells(0).Value & "','" & GDV1.Rows(Baris).Cells(3).Value & "','" & GDV1.Rows(Baris).Cells(4).Value & "','" & GDV1.Rows(Baris).Cells(5).Value & "', '" & GDV1.Rows(Baris).Cells(6).Value & "')"
                    Cmd = New OdbcCommand(detailProduk, Conn)
                    Cmd.ExecuteNonQuery()
                End If

                Cmd = New OdbcCommand("select * from layanan where KODEL = '" & GDV1.Rows(Baris).Cells(0).Value & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Dim detailLayan As String = "Insert into detaillayan values('" & TBfaktur.Text & "','" & GDV1.Rows(Baris).Cells(0).Value & "','" & GDV1.Rows(Baris).Cells(3).Value & "','" & GDV1.Rows(Baris).Cells(4).Value & "','" & GDV1.Rows(Baris).Cells(5).Value & "' , '" & GDV1.Rows(Baris).Cells(6).Value & "')"
                    Cmd = New OdbcCommand(detailLayan, Conn)
                    Cmd.ExecuteNonQuery()
                End If

                Cmd = New OdbcCommand("select * from kopi where KODE = '" & GDV1.Rows(Baris).Cells(0).Value & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Dim detailkopi As String = "Insert into detailkopi values('" & TBfaktur.Text & "','" & GDV1.Rows(Baris).Cells(0).Value & "','" & GDV1.Rows(Baris).Cells(3).Value & "','" & GDV1.Rows(Baris).Cells(4).Value & "','" & GDV1.Rows(Baris).Cells(5).Value & "')"
                    Cmd = New OdbcCommand(detailkopi, Conn)
                    Cmd.ExecuteNonQuery()
                End If





                'Dim SimpanDetail As String = "Insert into detailjual values('" & TBfaktur.Text & "','" & GDV1.Rows(Baris).Cells(0).Value & "','" & GDV1.Rows(Baris).Cells(3).Value & "','" & GDV1.Rows(Baris).Cells(4).Value & "','" & GDV1.Rows(Baris).Cells(5).Value & "')"
                'Cmd = New OdbcCommand(SimpanDetail, Conn)
                'Cmd.ExecuteNonQuery()



                If GDV1.Rows(Baris).Cells(1).Value = "Cuci Gunting Wanita" Then
                    'Dim fee As String = "Insert into fee values('" & TBfaktur.Text & "','" & TglMySQL & "','" & GChs.Text & "','" & GDV1.Rows(Baris).Cells(1).Value & "','" & GDV1.Rows(Baris).Cells(3).Value & "','" & GDV1.Rows(Baris).Cells(3).Value * (45 / 100) & "')"
                    'Cmd = New OdbcCommand(fee, Conn)
                    'Cmd.ExecuteNonQuery()
                Else
                    If GDV1.Rows(Baris).Cells(1).Value = "Cuci Gunting Pria" Then
                        'Dim fee As String = "Insert into fee values('" & TBfaktur.Text & "','" & TglMySQL & "','" & GChs.Text & "','" & GDV1.Rows(Baris).Cells(1).Value & "','" & GDV1.Rows(Baris).Cells(3).Value & "','" & GDV1.Rows(Baris).Cells(3).Value * (60 / 100) & "')"
                        'Cmd = New OdbcCommand(fee, Conn)
                        'Cmd.ExecuteNonQuery()

                    Else

                        If GDV1.Rows(Baris).Cells(1).Value = "Cuci Paket Blow" Then
                            'Dim fee As String = "Insert into fee values('" & TBfaktur.Text & "','" & TglMySQL & "','" & GChs.Text & "','" & GDV1.Rows(Baris).Cells(1).Value & "','" & GDV1.Rows(Baris).Cells(3).Value & "','" & GDV1.Rows(Baris).Cells(3).Value * (45 / 100) & "')"
                            'Cmd = New OdbcCommand(fee, Conn)
                            'Cmd.ExecuteNonQuery()


                        End If
                    End If


                    Cmd = New OdbcCommand("select * from barang where KODE = '" & GDV1.Rows(Baris).Cells(0).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        Dim KurangiStok As String = "Update barang set JUMLAH = '" & Rd.Item("JUMLAH") - GDV1.Rows(Baris).Cells(4).Value & "' where KODE='" & GDV1.Rows(Baris).Cells(0).Value & "'"
                        Cmd = New OdbcCommand(KurangiStok, Conn)
                        Cmd.ExecuteNonQuery()
                    End If

                    Cmd = New OdbcCommand("select * from barang where KODE = '" & GDV1.Rows(Baris).Cells(0).Value & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        Dim KurangiTotal As String = "Update barang set TOTAL = '" & Rd.Item("JUMLAH") * Rd.Item("HPP") & "' where KODE='" & GDV1.Rows(Baris).Cells(0).Value & "'"
                        Cmd = New OdbcCommand(KurangiTotal, Conn)
                        Cmd.ExecuteNonQuery()
                    End If
                End If
            Next
            MsgBox("Data Berhasil Disimpan")
            WAstruk.ShowDialog()
            Call kondisiAwal()


        End If
    End Sub

    'Sub isibox()
    '    'GDV1.Columns.Clear()
    '    'GDV1.Columns.Add("KODE", "KODE")0
    '    'GDV1.Columns.Add("NAMA", "NAMA")1
    '    'GDV1.Columns.Add("MERK", "MERK")2
    '    'GDV1.Columns.Add("HARGA", "HARGA")3
    '    'GDV1.Columns.Add("JUMLAH", "JUMLAH")4
    '    'GDV1.Columns.Add("SUBTOTAL", "SUBTOTAL")5
    '    'GDV1.Columns.Add("HAIRSTYLIST", "HAIRSTYLIST")6
    '    Dim pesan As String = ""
    '    For Baris As Integer = 0 To GDV1.Rows.Count - 2
    '        Dim DATANYA = "JORDAN BARABER DAN COFEE" + Environment.NewLine + TBfaktur.Text + Environment.NewLine + TBnama.Text + Environment.NewLine + "PRODUK & LAYANAN :" + GDV1.Rows(Baris).Cells(1).Value + Environment.NewLine + "MERK :" & GDV1.Rows(Baris).Cells(2).Value + Environment.NewLine + "HARGA : " & GDV1.Rows(Baris).Cells(3).Value + Environment.NewLine + "JUMLAH: " & GDV1.Rows(Baris).Cells(4).Value + Environment.NewLine + "SUBTOTAL RP : " & GDV1.Rows(Baris).Cells(5).Value + Environment.NewLine + "HAIRSTYLIST :" & GDV1.Rows(Baris).Cells(6).Value + Environment.NewLine + " TERIMAKASIH ATAS KUNJUNGAN ANDA.... "
    '        pesan = pesan & "" & Environment.NewLine & DATANYA & "" & Environment.NewLine


    '        'ListBox1.Items.Add(" JORDAN BARABER DAN COFEE ")
    '        'ListBox1.Items.Add(TBfaktur.Text)
    '        'ListBox1.Items.Add(TBnama.Text)
    '        'ListBox1.Items.Add(TBalamat.Text)
    '        'ListBox1.Items.Add("PRODUK & LAYANAN :" & GDV1.Rows(Baris).Cells(1).Value)
    '        'ListBox1.Items.Add("MERK :" & GDV1.Rows(Baris).Cells(2).Value)
    '        'ListBox1.Items.Add("HARGA : " & GDV1.Rows(Baris).Cells(3).Value)
    '        'ListBox1.Items.Add("JUMLAH: " & GDV1.Rows(Baris).Cells(4).Value)
    '        'ListBox1.Items.Add("SUBTOTAL RP : " & GDV1.Rows(Baris).Cells(5).Value)
    '        'ListBox1.Items.Add("HAIRSTYLIST :" & GDV1.Rows(Baris).Cells(6).Value)
    '        'ListBox1.Items.Add(" TERIMAKASIH ATAS KUNJUNGAN ANDA.... ")
    '        'GunaTextBox1.Text = "JORDAN BARABER DAN COFEE" + Environment.NewLine + TBfaktur.Text + Environment.NewLine + TBnama.Text + Environment.NewLine + "PRODUK & LAYANAN :" + GDV1.Rows(Baris).Cells(1).Value + Environment.NewLine + "MERK :" & GDV1.Rows(Baris).Cells(2).Value + Environment.NewLine + "HARGA : " & GDV1.Rows(Baris).Cells(3).Value + Environment.NewLine + "JUMLAH: " & GDV1.Rows(Baris).Cells(4).Value + Environment.NewLine + "SUBTOTAL RP : " & GDV1.Rows(Baris).Cells(5).Value + Environment.NewLine + "HAIRSTYLIST :" & GDV1.Rows(Baris).Cells(6).Value + Environment.NewLine + " TERIMAKASIH ATAS KUNJUNGAN ANDA.... "


    '    Next



    'End Sub
   
    Private Sub GChs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GChs.SelectedIndexChanged
        GunaLabel13.Text = GChs.Text
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GDV1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GDV1.CellContentClick
        GunaButton2.Enabled = True
    End Sub

    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        IsStart = True
        With BotWA
            .Show()
        End With
        Me.Focus()
    End Sub

    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
        Application.DoEvents()
        IsStart = False
        BotWA.Button1.PerformClick()
    End Sub

    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaButton6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaTextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        elemen.Show()
        elemen.Focus()
    End Sub

    Private Sub GunaTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        
    End Sub

    Private Sub GunaTextBox1_TextChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaGroupBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox3.Click
        GunaButton2.Enabled = False
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            LBLKembali.Text = TextBox1.Text - Label1.Text
            BTcetak.Enabled = True
            BTcetak.Focus()
            LBLKembali.Text = FormatNumber(LBLKembali.Text, 0)
        End If
    End Sub

   
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        formatUang(TextBox1)
    End Sub

    Private Sub LBLhs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        BTinput.Enabled = True
        If GunaButton1.Text = "CARI" And GunaRadioButton1.Checked Then
            DataLayanan.ShowDialog()
        ElseIf GunaButton1.Text = "CARI" And GunaRadioButton2.Checked Then
            DataProduk.ShowDialog()
        Else
            If GunaButton1.Text = "CARI" And GunaRadioButton3.Checked Then
                DataKopi.ShowDialog()
            End If

        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBLjam.Text = TimeOfDay
    End Sub

    Private Sub LBLjam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLjam.Click

    End Sub

    Private Sub GunaButton6_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton6.Click
        Form2.ShowDialog()
    End Sub
End Class