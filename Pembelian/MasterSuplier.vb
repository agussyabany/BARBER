Imports System.Data.Odbc
Public Class MasterSuplier
    Sub KondisiAwal()
        TBNama.Enabled = False
        TBuser.Enabled = False
        GunaTextBox1.Enabled = False
        TBNama.Text = ""
        TBuser.Text = ""
        GunaTextBox1.Text = ""
        Call NomorOtomatis()
       
        GunaButton1.Enabled = True
        GunaButton1.Text = "TAMBAH"
        GunaButton3.Text = "UBAH"
        GunaButton4.Text = "HAPUS"
        GunaButton3.Enabled = False
        GunaButton4.Enabled = False
        GunaButton5.Enabled = False

        Call Koneksi()
        Da = New OdbcDataAdapter("Select KODE,NAMA,ALAMAT,TLP From suplier", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "suplier")
        GunaDataGridView1.DataSource = Ds.Tables("suplier")

        GunaDataGridView1.ReadOnly = True
    End Sub
    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from suplier where KODE in (select max(KODE) From suplier)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "SP" + "01"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 2) + 1
            UrutanKode = "SP" + Microsoft.VisualBasic.Right("00" & Hitung, 2)

        End If
        GunaTextBox2.Text = UrutanKode
    End Sub
    

    Private Sub Master_Pelanggan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()

    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        Me.Close()
    End Sub

    Sub siapIsi()
        TBNama.Enabled = True
        TBuser.Enabled = True
        GunaTextBox1.Enabled = True
        TBNama.Focus()
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        If GunaButton1.Text = "TAMBAH" Then
            GunaButton1.Text = "SIMPAN"

            Call siapIsi()
        Else
            If GunaTextBox2.Text = "" Or TBNama.Text = "" Or TBuser.Text = "" Or GunaTextBox1.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else
                Call Koneksi()
                Dim InputData As String = "Insert into suplier values ('" & GunaTextBox2.Text & "','" & TBNama.Text & "','" & TBuser.Text & "','" & GunaTextBox1.Text & "')"
                Cmd = New OdbcCommand(InputData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Input Data Berhasil")
                Call KondisiAwal()
            End If
        End If

    End Sub

    Private Sub TBNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNama.KeyPress
        If e.KeyChar = Chr(13) Then
            TBuser.Focus()
        End If
    End Sub

    Private Sub TBNama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNama.TextChanged

    End Sub

    Private Sub TBuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBuser.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaTextBox1.Focus()
        End If
    End Sub

    Private Sub TBuser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBuser.TextChanged

    End Sub

    Private Sub GunaButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton3.Click
        If GunaButton3.Text = "UBAH" Then
            GunaButton3.Text = "UPDATE"
            GunaButton1.Enabled = False
            GunaButton4.Enabled = False

            Call siapIsi()


        Else
            If GunaTextBox2.Text = "" Or TBNama.Text = "" Or TBuser.Text = "" Or GunaTextBox1.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else
                Call Koneksi()
                Dim UpdateData As String = "Update suplier set NAMA= '" & TBNama.Text & "',ALAMAT='" & TBuser.Text & "',TLP='" & GunaTextBox1.Text & "' where KODE='" & GunaTextBox2.Text & "'"
                Cmd = New OdbcCommand(UpdateData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("UPDATE DATA BERHASIL")
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
            Cmd = New OdbcCommand("Select * from suplier where KODE='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                GunaButton1.Focus()
            Else
                GunaTextBox2 = Rd.Item("KODE")
                TBNama.Text = Rd.Item("NAMA")
                TBuser.Text = Rd.Item("ALAMAT")
                GunaTextBox1.Text = Rd.Item("TLP")

                TBNama.Focus()

            End If
        End If
    End Sub

    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click

        GunaButton4.Text = "HAPUS"
        GunaButton1.Enabled = False
        GunaButton3.Enabled = False


        If MessageBox.Show("ANDA YAKIN AKAN MENGHAPUS DATA...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Call Koneksi()
            Dim HapusData As String = "Delete from suplier where KODE ='" & GunaTextBox2.Text & " '"
            Cmd = New OdbcCommand(HapusData, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Hapus Data Berhasil")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
        Call KondisiAwal()
    End Sub

    Private Sub GunaLabel14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaLabel14.Click

    End Sub

    Private Sub GunaLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaLabel3.Click

    End Sub
End Class