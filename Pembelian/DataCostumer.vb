Imports System.Data.Odbc
Public Class DataCostumer
    Sub kondisiAwal()
        GunaTextBox1.Focus()
        Call Koneksi()
        Da = New OdbcDataAdapter("Select * From pelanggan", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pelanggan")
        GunaDataGridView1.DataSource = Ds.Tables("pelanggan")
        GunaDataGridView1.ReadOnly = True
    End Sub
    Private Sub DataBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()

    End Sub





    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged
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

    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        MasterPelanggan1.ShowDialog()
    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = GunaDataGridView1.CurrentRow.Index
        Cmd = New OdbcCommand("Select * from pelanggan where NOHP='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            GunaTextBox1.Focus()
        Else

            Penjualan.TBhp.Text = Rd.Item("NOHP")
            Penjualan.TBnama.Text = Rd.Item("NAMA")
            Penjualan.TBalamat.Text = Rd.Item("ALAMAT")

            

            Me.Close()


        End If
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub GunaButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        Call Koneksi()
        Cmd = New OdbcCommand("SELECT * FROM pelanggan ORDER BY NAMA ASC", Conn)
        Dim rd As OdbcDataReader
        rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT * FROM pelanggan ORDER BY NAMA ASC", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "KetemuData")
            GunaDataGridView1.DataSource = Ds.Tables("KetemuData")
            GunaDataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub GunaButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton3.Click
        Call Koneksi()
        Cmd = New OdbcCommand("SELECT * FROM pelanggan ORDER BY NAMA DESC", Conn)
        Dim rd As OdbcDataReader
        rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call Koneksi()
            Da = New OdbcDataAdapter("SELECT * FROM pelanggan ORDER BY NAMA DESC", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "KetemuData")
            GunaDataGridView1.DataSource = Ds.Tables("KetemuData")
            GunaDataGridView1.ReadOnly = True
        End If
    End Sub
End Class