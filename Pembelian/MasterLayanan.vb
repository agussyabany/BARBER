Imports System.Data.Odbc
Public Class MasterLayanan
    Sub kondisiAwal()
        GunaTextBox1.Text = ""
        GunaTextBox2.Text = ""
        GunaButton3.Enabled = True
        GunaButton3.Text = "TAMBAH"
        GunaTextBox1.Enabled = False
        GunaButton1.Enabled = False
        GunaButton2.Enabled = False
        Call NomorOtomatis()
        Call Koneksi()
        Da = New OdbcDataAdapter("Select KODEL,LAYANAN,HARGA From layanan", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "layanan")
        GunaDataGridView1.DataSource = Ds.Tables("layanan")
        GunaDataGridView1.ReadOnly = True
    End Sub
    Private Sub MasterLayanan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()

    End Sub
    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from layanan where KODEL in (select max(KODEL) From layanan)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "L" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            UrutanKode = "L" + Microsoft.VisualBasic.Right("000" & Hitung, 3)

        End If
        TBuser.Text = UrutanKode
    End Sub
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
    Sub siapIsi()
        GunaTextBox1.Enabled = True
        GunaTextBox2.Enabled = True
        GunaButton1.Enabled = True
        GunaTextBox1.Focus()
    End Sub
    Private Sub GunaButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton6.Click
        Me.Close()
    End Sub

    Private Sub GunaButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton3.Click
        If GunaButton3.Text = "TAMBAH" Then
            GunaButton3.Text = "SIMPAN"

            Call siapIsi()
        Else
            If GunaTextBox1.Text = "" Or GunaTextBox2.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else

                Call Koneksi()
                Dim InputData As String = "Insert into layanan values ('" & TBuser.Text & "','" & GunaTextBox1.Text & "','" & GunaTextBox2.Text & "')"
                Cmd = New OdbcCommand(InputData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Input Data BARBERSHOP Berhasil")
                Call kondisiAwal()
            End If
        End If
    End Sub

    Private Sub GunaDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GunaDataGridView1.CellContentClick
        GunaButton3.Enabled = False
        GunaButton1.Enabled = True
        GunaButton2.Enabled = True
        GunaButton4.Enabled = True
        If GunaButton3.Text = "TAMBAH" Then

            Call Koneksi()
            Dim i As Integer
            i = GunaDataGridView1.CurrentRow.Index
            Cmd = New OdbcCommand("Select * from layanan where KODEL='" & GunaDataGridView1.Item(0, i).Value & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                GunaButton1.Focus()
            Else
                TBuser.Text = Rd.Item("KODEL")
                GunaTextBox1.Text = Rd.Item("LAYANAN")
                GunaTextBox2.Text = Rd.Item("HARGA")
                
                GunaTextBox1.Focus()

            End If
        End If
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        GunaButton2.Text = "HAPUS"
        GunaButton3.Enabled = False
        GunaButton1.Enabled = False



        If MessageBox.Show("ANDA YAKIN AKAN MENGHAPUS DATA...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Call Koneksi()
            Dim HapusData As String = "Delete from layanan where KODEL ='" & TBuser.Text & " '"
            Cmd = New OdbcCommand(HapusData, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Hapus Data Berhasil")
            Call kondisiAwal()

        End If
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        If GunaButton1.Text = "UBAH" Then
            GunaButton1.Text = "UPDATE"
            GunaButton3.Enabled = False
            GunaButton2.Enabled = False

            Call siapIsi()


        Else
            If TBuser.Text = "" Or GunaTextBox1.Text = "" Or GunaTextBox2.Text = "" Then
                MsgBox("SILAHKAN ISI SEMUA FIELD")
            Else
                Call Koneksi()
                Dim UpdateData As String = "Update layanan set LAYANAN= '" & GunaTextBox1.Text & "',HARGA='" & GunaTextBox2.Text & "' where KODEL='" & TBuser.Text & "'"
                Cmd = New OdbcCommand(UpdateData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("UPDATE DATA BERHASIL")
                Call kondisiAwal()
            End If
        End If
    End Sub

    Private Sub GunaTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GunaTextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaTextBox2.Focus()
        End If
    End Sub
    Dim f, g As Double
    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged
        
    End Sub

    Private Sub GunaTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GunaTextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaButton3.Focus()
            'GunaTextBox2.Text = FormatNumber(GunaTextBox2.Text, 0)
        End If
    End Sub

    

    Private Sub GunaTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox2.TextChanged

    End Sub

    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        Call kondisiAwal()
    End Sub

    Private Sub GunaButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton5.Click
        If MessageBox.Show("CETAK DATA ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'AxCrystalReport1.SelectionFormula = "totext({pegawai.IDCARD})"
            AxCrystalReport1.ReportFileName = "daftarLayanan.rpt"
            AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
            AxCrystalReport1.RetrieveDataFiles()
            AxCrystalReport1.Action = 1
            Call kondisiAwal()

        End If
    End Sub
End Class