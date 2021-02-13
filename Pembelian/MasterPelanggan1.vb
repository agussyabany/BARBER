Imports System.Data.Odbc
Public Class MasterPelanggan1
    Sub KondisiAwal()
        TBNama.Enabled = False
        TBuser.Enabled = False
        GunaTextBox1.Enabled = False
        TBNama.Text = ""
        TBuser.Text = ""
        GunaTextBox1.Text = ""
        
        GunaButton1.Enabled = True
        GunaButton1.Text = "TAMBAH"
        GunaButton3.Text = "UBAH"
        GunaButton4.Text = "HAPUS"
        GunaButton3.Enabled = False
        GunaButton4.Enabled = False
        GunaButton5.Enabled = False

        Call Koneksi()
        Da = New OdbcDataAdapter("Select NOHP,NAMA,ALAMAT From pelanggan", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pelanggan")
        GunaDataGridView1.DataSource = Ds.Tables("pelanggan")

        GunaDataGridView1.ReadOnly = True
    End Sub
    Private Sub MasterPelanggan1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()

    End Sub
    Sub siapIsi()
        TBNama.Enabled = True
        TBuser.Enabled = True
        GunaTextBox1.Enabled = True
        TBNama.Focus()
    End Sub
    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        If GunaButton1.Text = "TAMBAH" Then
            GunaButton1.Text = "SIMPAN"

            Call siapIsi()
        Else
            If TBNama.Text = "" Or TBuser.Text = "" Or GunaTextBox1.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else
                Call Koneksi()
                Dim InputData As String = "Insert into pelanggan values ('" & TBNama.Text & "','" & TBuser.Text & "','" & GunaTextBox1.Text & "')"
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

    Private Sub GunaTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GunaTextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaButton1.Focus()
        End If
    End Sub

    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged
        
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        Me.Close()
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
            Cmd = New OdbcCommand("Select * from pelanggan where NOHP='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                GunaButton1.Focus()
            Else

                TBNama.Text = Rd.Item("NOHP")
                TBuser.Text = Rd.Item("NAMA")
                GunaTextBox1.Text = Rd.Item("ALAMAT")

                TBNama.Focus()

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
            If TBNama.Text = "" Or TBuser.Text = "" Or GunaTextBox1.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else
                Call Koneksi()
                Dim UpdateData As String = "Update pelanggan set NAMA= '" & TBuser.Text & "',ALAMAT='" & GunaTextBox1.Text & "' where NOHP='" & TBNama.Text & "'"
                Cmd = New OdbcCommand(UpdateData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("UPDATE DATA BERHASIL")
                Call KondisiAwal()
            End If
        End If
    End Sub

    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        GunaButton4.Text = "HAPUS"
        GunaButton1.Enabled = False
        GunaButton3.Enabled = False


        If MessageBox.Show("ANDA YAKIN AKAN MENGHAPUS DATA...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Call Koneksi()
            Dim HapusData As String = "Delete from pelanggan where NOHP ='" & TBNama.Text & " '"
            Cmd = New OdbcCommand(HapusData, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Hapus Data Berhasil")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
        Call KondisiAwal()
    End Sub

    Private Sub GunaButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton6.Click
        If MessageBox.Show("CETAK DATA ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'AxCrystalReport1.SelectionFormula = "totext({pegawai.IDCARD})"
            AxCrystalReport1.ReportFileName = "daftarPelanggan.rpt"
            AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
            AxCrystalReport1.RetrieveDataFiles()
            AxCrystalReport1.Action = 1
            Call KondisiAwal()

        End If
    End Sub
End Class