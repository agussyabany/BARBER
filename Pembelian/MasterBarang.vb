Imports System.Data.Odbc
Public Class Form1
    Sub kondisiAwal()
        GunaTextBox1.Text = ""
        GunaTextBox3.Text = ""
        GunaButton3.Enabled = True
        GunaButton3.Text = "TAMBAH"
        GunaButton1.Text = "UBAH"
        GunaTextBox1.Enabled = False
        GunaTextBox3.Enabled = False
        GunaComboBox1.Enabled = False
        GunaComboBox2.Enabled = False
        GunaButton1.Enabled = False
        GunaButton2.Enabled = False
        Call NomorOtomatis()
        Call Koneksi()
        Da = New OdbcDataAdapter("Select KODE,NAMA,MERK,JUMLAH,SATUAN,KATEGORI From barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "barang")
        GunaDataGridView1.DataSource = Ds.Tables("barang")
        GunaDataGridView1.ReadOnly = True
        Call kategori()
        Call satuan()
    End Sub

    Sub kategori()
        Call Koneksi()
        GunaComboBox1.Items.Clear()
        Cmd = New OdbcCommand("Select KATEGORI from kategori", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GunaComboBox1.Items.Add(Rd.Item(0))
        Loop
    End Sub
    Sub satuan()
        Call Koneksi()
        GunaComboBox2.Items.Clear()
        Cmd = New OdbcCommand("Select SATUAN from satuan", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            GunaComboBox2.Items.Add(Rd.Item(0))
        Loop
    End Sub
    Private Sub MasterUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()

    End Sub
    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from barang where KODE in (select max(KODE) From barang)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "D" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            UrutanKode = "D" + Microsoft.VisualBasic.Right("000" & Hitung, 3)

        End If
        TBuser.Text = UrutanKode
    End Sub
    Sub siapIsi()
        GunaTextBox1.Enabled = True
        GunaTextBox3.Enabled = True
        GunaComboBox1.Enabled = True
        GunaComboBox2.Enabled = True
        GunaButton1.Enabled = True
        GunaTextBox1.Focus()
    End Sub
    Private Sub GunaButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton6.Click
        Me.Close()
    End Sub

    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub GunaButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       


    End Sub

    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub GunaTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub GunaTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
       
    End Sub

    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaTextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      
    End Sub

    Private Sub GunaTextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox1.Click

    End Sub

    Private Sub GunaButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton3.Click
        If GunaButton3.Text = "TAMBAH" Then
            GunaButton3.Text = "SIMPAN"

            Call siapIsi()
        Else
            If GunaTextBox1.Text = "" Or GunaComboBox1.Text = "" Or GunaComboBox2.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else

                Call Koneksi()
                Dim InputData As String = "Insert into barang (KODE,NAMA,MERK,SATUAN,KATEGORI) values ('" & TBuser.Text & "','" & GunaTextBox1.Text & "','" & GunaTextBox3.Text & "','" & GunaComboBox2.Text & "','" & GunaComboBox1.Text & "')"
                Cmd = New OdbcCommand(InputData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Input Data BARBERSHOP Berhasil")
                Call kondisiAwal()
            End If
        End If
    End Sub

    Private Sub GunaDataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        GunaButton3.Enabled = False
        GunaButton1.Enabled = True
        GunaButton2.Enabled = True
        GunaButton4.Enabled = True
        If GunaButton3.Text = "TAMBAH" Then

            Call Koneksi()
            Dim i As Integer
            i = GunaDataGridView1.CurrentRow.Index
            Cmd = New OdbcCommand("Select * from barang where KODE='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                GunaButton1.Focus()
            Else
                TBuser.Text = Rd.Item("KODE")
                GunaTextBox1.Text = Rd.Item("NAMA")
                GunaTextBox3.Text = Rd.Item("MERK")
                GunaComboBox1.Text = Rd.Item("KATEGORI")
                GunaComboBox2.Text = Rd.Item("SATUAN")
                GunaTextBox1.Focus()

            End If
        End If
    End Sub

    Private Sub GunaButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        If GunaButton1.Text = "UBAH" Then
            GunaButton1.Text = "UPDATE"
            GunaButton3.Enabled = False
            GunaButton2.Enabled = False

            Call siapIsi()


        Else
            If TBuser.Text = "" Or GunaTextBox1.Text = "" Or GunaComboBox1.Text = "" Or GunaComboBox2.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else
                Call Koneksi()
                Dim UpdateData As String = "Update barang set NAMA= '" & GunaTextBox1.Text & "',MERK= '" & GunaTextBox3.Text & "',SATUAN='" & GunaComboBox2.Text & "',KATEGORI='" & GunaComboBox1.Text & "' where KODE='" & TBuser.Text & "'"
                Cmd = New OdbcCommand(UpdateData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("UPDATE DATA BERHASIL")
                Call kondisiAwal()
            End If
        End If
    End Sub

    Private Sub GunaButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        GunaButton2.Text = "HAPUS"
        GunaButton3.Enabled = False
        GunaButton1.Enabled = False



        If MessageBox.Show("ANDA YAKIN AKAN MENGHAPUS DATA...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Call Koneksi()
            Dim HapusData As String = "Delete from barang where KODE ='" & TBuser.Text & " '"
            Cmd = New OdbcCommand(HapusData, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Hapus Data Berhasil")
            Call kondisiAwal()

        End If
    End Sub

    Private Sub GunaButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        Call kondisiAwal()
    End Sub

    Private Sub GunaTextBox1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GunaTextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaTextBox3.Focus()
        End If
    End Sub

    Private Sub GunaTextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged

    End Sub

    Private Sub GunaTextBox3_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GunaTextBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaComboBox1.Focus()
        End If
    End Sub

    Private Sub GunaTextBox3_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox3.TextChanged
        
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaComboBox1.SelectedIndexChanged

    End Sub

    Private Sub GunaTextBox2_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox2.TextChanged
        Call Koneksi()
        Cmd = New OdbcCommand("select KODE,NAMA,MERK,JUMLAH,SATUAN,KATEGORI from barang where NAMA Like '%" & GunaComboBox2.Text & "%'", Conn)
        Dim rd As OdbcDataReader
        rd = Cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call Koneksi()
            Da = New OdbcDataAdapter("select KODE,NAMA,MERK,JUMLAH,SATUAN,KATEGORI from barang where NAMA Like '%" & GunaComboBox2.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "KetemuData")
            GunaDataGridView1.DataSource = Ds.Tables("KetemuData")
            GunaDataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
        If MessageBox.Show("CETAK DATA ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'AxCrystalReport1.SelectionFormula = "totext({pegawai.IDCARD})"
            AxCrystalReport1.ReportFileName = "daftarBarang.rpt"
            AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
            AxCrystalReport1.RetrieveDataFiles()
            AxCrystalReport1.Action = 1
            Call kondisiAwal()

        End If
    End Sub
End Class