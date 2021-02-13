Imports System.Data.Odbc
Public Class angsur
    Dim TglMySQL As String
    Sub kondisiAwal()
        Call NomorOtomatis()
        Call hairstylist()
        GunaTextBox3.Text = Today
        Call BuatKolom()
        Call pinjamist()
        'GunaDataGridView1.Columns.Clear()
    End Sub
    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from angsur where KODE in (select max(KODE) From angsur)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "ANG" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            UrutanKode = "ANG" + Microsoft.VisualBasic.Right("000" & Hitung, 3)

        End If
        TBNama.Text = UrutanKode
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
    Sub pinjamist()
        Call Koneksi()
        GunaComboBox1.Items.Clear()
        Cmd = New OdbcCommand("Select NAMA from pegawai", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GunaComboBox1.Items.Add(Rd.Item(0))
        Loop
    End Sub
    Sub BuatKolom()
        GunaDataGridView1.Columns.Clear()
        GunaDataGridView1.Columns.Add("KODE", "KODE")
        GunaDataGridView1.Columns.Add("ANGSURAN", "ANGSURAN")
        GunaDataGridView1.Columns.Add("PERIODE", "PERIODE")

    End Sub
    Private Sub angsur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton3.Click
        If GunaTextBox1.Text = "" Then
            MsgBox("SILAHKAN ISI JANGKA ANGSURAN")
        Else
            GunaLabel4.Text = GunaTextBox2.Text / GunaTextBox1.Text
            Dim i As Integer = 0
            Dim teks As Integer = GunaTextBox1.Text
            Do While i < teks
                GunaDataGridView1.Rows.Add(New String() {TBNama.Text, GunaLabel4.Text, GunaTextBox3.Text})
                i = i + 1

            Loop
        End If
    End Sub
    Sub aksi()





    End Sub
    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
       TglMySQL = Format(Today, "yyyy-MM-dd")
        Dim SimpanAngsur As String = "Insert into angsur values('" & TBNama.Text & "','" & TglMySQL & "','" & GChs.Text & "','" & GunaTextBox2.Text & "','" & GunaTextBox1.Text & "')"
        Cmd = New OdbcCommand(SimpanAngsur, Conn)
        Cmd.ExecuteNonQuery()

        For Baris As Integer = 0 To GunaDataGridView1.Rows.Count - 2
            Dim SimpanDetail As String = "Insert into detailangsur values('" & TBNama.Text & "','" & GunaDataGridView1.Rows(Baris).Cells(1).Value & "','" & TglMySQL & "')"
            Cmd = New OdbcCommand(SimpanDetail, Conn)
            Cmd.ExecuteNonQuery()
        Next
        MsgBox("ANGSURAN TELAH DIBUAT!")
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Call Koneksi()
        
        Cmd = New OdbcCommand("Select * from angsur where NAMA='" & GunaComboBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            GunaTextBox4.Text = Rd.Item("TANGGAL")
            GunaTextBox5.Text = Rd.Item("NOMINAL")
            GunaTextBox6.Text = Rd.Item("TENOR")
            GunaTextBox7.Text = Rd.Item("KODE")

            Da = New OdbcDataAdapter("SELECT * FROM detailangsur WHERE KODE = '" & GunaTextBox7.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "detailangsur")
            GunaDataGridView2.DataSource = Ds.Tables("detailangsur")
            GunaDataGridView2.ReadOnly = True
            'GunaDataGridView1.Columns.Clear()
            'Call kondisiAwal()
            

           
        End If
    End Sub
End Class