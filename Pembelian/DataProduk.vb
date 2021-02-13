Imports System.Data.Odbc
Public Class DataProduk
    Sub kondisiAwal()
        GunaTextBox1.Focus()
        Call Koneksi()
        Da = New OdbcDataAdapter("Select KODE,NAMA,MERK,JUMLAH,SATUAN,HJUAL,KATEGORI From barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "barang")
        GunaDataGridView1.DataSource = Ds.Tables("barang")
        GunaDataGridView1.ReadOnly = True
    End Sub
    Private Sub DataProduk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()

    End Sub





    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = GunaDataGridView1.CurrentRow.Index
        Cmd = New OdbcCommand("Select * from barang where KODE='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            GunaTextBox1.Focus()
        Else

            Penjualan.TBKode.Text = Rd.Item("KODE")
            Penjualan.TBLayan.Text = Rd.Item("NAMA")
            Penjualan.Tbnampro.Text = Rd.Item("MERK")
            Penjualan.TBhareg.Text = Rd.Item("HJUAL")
            'Penjualan.TBhareg.Text = FormatNumber(Penjualan.TBhareg.Text, 0)
            Penjualan.TBstok.Text = Rd.Item("JUMLAH")



            Me.Close()


        End If
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub GunaButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        Form1.ShowDialog()
    End Sub

    Private Sub GunaButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaTextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged
        Call Koneksi()
        Cmd = New OdbcCommand("select * from pelanggan where NAMA Like '%" & GunaTextBox1.Text & "%'", Conn)
        Dim rd As OdbcDataReader
        rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call Koneksi()
            Da = New OdbcDataAdapter("select * from pelanggan where NAMA Like '%" & GunaTextBox1.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "KetemuData")
            GunaDataGridView1.DataSource = Ds.Tables("KetemuData")
            GunaDataGridView1.ReadOnly = True
        End If
    End Sub
End Class