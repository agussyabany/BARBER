Imports System.Data.Odbc
Public Class MasterKategori
    Sub KondisiAwal()

        TBuser.Enabled = False
        GunaTextBox1.Enabled = False
        TBuser.Text = ""
        GunaButton1.Enabled = True
        GunaButton1.Text = "TAMBAH"
        GunaButton3.Text = "UBAH"
        GunaButton4.Text = "HAPUS"
        GunaButton3.Enabled = False
        GunaButton4.Enabled = False
        GunaButton5.Enabled = False
        Call NomorOtomatis()

        Call Koneksi()
        Da = New OdbcDataAdapter("Select ID,KATEGORI From kategori", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "kategori")
        GunaDataGridView1.DataSource = Ds.Tables("kategori")
        GunaDataGridView1.ReadOnly = True
    End Sub
    Private Sub MasterKategori_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()

    End Sub
    Sub siapIsi()

        TBuser.Enabled = True

        TBuser.Focus()
    End Sub
    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from kategori where ID in (select max(ID) From kategori)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "KT" + "01"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 2) + 1
            UrutanKode = "KT" + Microsoft.VisualBasic.Right("00" & Hitung, 2)

        End If
        GunaTextBox1.Text = UrutanKode
    End Sub
    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        If GunaButton1.Text = "TAMBAH" Then
            GunaButton1.Text = "SIMPAN"

            Call siapIsi()
        Else
            If TBuser.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else
                Call Koneksi()
                Dim InputData As String = "Insert into kategori values ('" & GunaTextBox1.Text & "','" & TBuser.Text & "')"
                Cmd = New OdbcCommand(InputData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Input Data Berhasil")
                Call KondisiAwal()
            End If
        End If
    End Sub
    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        GunaButton1.Enabled = False
        GunaButton3.Enabled = True
        GunaButton4.Enabled = True
        GunaButton5.Enabled = True
        If GunaButton1.Text = "TAMBAH" Then

            Call Koneksi()
            Dim i As Integer
            i = GunaDataGridView1.CurrentRow.Index
            Cmd = New OdbcCommand("Select * from kategori where ID='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                GunaButton1.Focus()
            Else

                GunaTextBox1.Text = Rd.Item("ID")
                TBuser.Text = Rd.Item("KATEGORI")
                TBuser.Focus()

            End If
        End If
    End Sub
    Private Sub GunaButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton3.Click
        If GunaButton3.Text = "UBAH" Then
            GunaButton3.Text = "UPDATE"
            GunaButton1.Enabled = False
            GunaButton4.Enabled = False

            Call siapIsi()


        Else
            If TBuser.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else
                Call Koneksi()
                Dim UpdateData As String = "Update kategori set KATEGORI= '" & TBuser.Text & "' where ID='" & GunaTextBox1.Text & "'"
                Cmd = New OdbcCommand(UpdateData, Conn)
                Cmd.ExecuteNonQuery()
                Call KondisiAwal()
                MsgBox("UPDATE DATA BERHASIL")

            End If
        End If
    End Sub
    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        GunaButton4.Text = "HAPUS"
        GunaButton1.Enabled = False
        GunaButton3.Enabled = False


        If MessageBox.Show("ANDA YAKIN AKAN MENGHAPUS DATA...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Call Koneksi()
            Dim HapusData As String = "Delete from kategori where ID ='" & GunaTextBox1.Text & " '"
            Cmd = New OdbcCommand(HapusData, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Hapus Data Berhasil")
            Call KondisiAwal()
        End If
    End Sub
    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
        Call KondisiAwal()
    End Sub
    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub TBuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBuser.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaButton1.Focus()
        End If
    End Sub

    Private Sub TBuser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBuser.TextChanged

    End Sub

    Private Sub GunaButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton6.Click
        Me.Close()
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        Me.Close()
    End Sub
End Class