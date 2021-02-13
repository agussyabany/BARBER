Imports System.Data.Odbc
Public Class DataBarang
    Sub kondisiAwal()
        GunaTextBox1.Focus()
        Call Koneksi()
        Da = New OdbcDataAdapter("Select KODE,NAMA,MERK,JUMLAH,SATUAN,KATEGORI From barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "barang")
        GunaDataGridView1.DataSource = Ds.Tables("barang")
        GunaDataGridView1.ReadOnly = True
    End Sub
    Private Sub DataBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()

    End Sub

   

    

    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged

    End Sub

    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        Form1.ShowDialog()
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

            Pembelian.TBkobar.Text = Rd.Item("KODE")
            Pembelian.TBnambar.Text = Rd.Item("NAMA")
            Pembelian.TBmerk.Text = Rd.Item("MERK")
            Pembelian.TBsatuan.Text = Rd.Item("SATUAN")
            Pembelian.TBkat.Text = Rd.Item("KATEGORI")

            Me.Close()
            Pembelian.TBharbel.Focus()

        End If
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub
End Class