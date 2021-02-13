Imports System.Data.Odbc
Public Class fee
    Sub hairstylist()

        Call Koneksi()
        GChs.Items.Clear()
        Cmd = New OdbcCommand("Select NAMA from pegawai", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GChs.Items.Add(Rd.Item(0))
        Loop
    End Sub

    Private Sub GunaLabel14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaLabel14.Click

    End Sub

    Private Sub GChs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GChs.SelectedIndexChanged
        Call Koneksi()

        Cmd = New OdbcCommand("Select * from fee where NAMA='" & GChs.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
           

            Da = New OdbcDataAdapter("SELECT IDJUAL,TGL,LAYANAN,HARGA,FEE FROM fee WHERE NAMA = '" & GChs.Text & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "fee")
            GunaDataGridView1.DataSource = Ds.Tables("fee")
            GunaDataGridView1.ReadOnly = True
            'GunaDataGridView1.Columns.Clear()
            'Call kondisiAwal()



        End If
    End Sub

    Private Sub fee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call hairstylist()
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        Me.Close()
    End Sub
End Class