Imports System.Data.Odbc
Public Class keluar
    Sub dgvload()
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * from keluar", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "keluar")
        DataGridView2.DataSource = Ds.Tables("keluar")
        DataGridView2.ReadOnly = True
        Call jumlah()
        Call jumlahTR()
    End Sub
    Sub jumlah()
        Dim A As Integer
        For line As Integer = 0 To DataGridView2.RowCount - 1
            A = A + DataGridView2.Rows(line).Cells(4).Value
        Next
        TBomz.Text = A
    End Sub
    Sub jumlahTR()
        Dim A As Integer
        For line As Integer = 0 To DataGridView2.RowCount - 1
            A = A + DataGridView2.Rows(line).Cells(2).Value
        Next
        GunaLabel6.Text = A
    End Sub
    Private Sub keluar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        Call klir()
        Call dgvload()
        
    End Sub
    Sub klir()
        GunaTextBox2.Text = ""
        TBhareg.Text = ""
        TextBox1.Text = ""
        GunaTextBox1.Text = ""
    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GunaTextBox2.Text = "" And TBhareg.Text = "" And GunaTextBox1.Text = "" Then
            MsgBox("SILAHKAN ISI FORM")
        Else
            Dim SimpanJual As String = "Insert into keluar (TGL,NAMA,JUMLAH,SATUAN,TOTAL,KET) values ('" & DateTimePicker1.Text & "','" & GunaTextBox2.Text & "','" & TBhareg.Text & "','" & Val(Microsoft.VisualBasic.Str(TextBox1.Text)) & "','" & Val(Microsoft.VisualBasic.Str(TextBox2.Text)) & "','" & GunaTextBox1.Text & "')"
            Cmd = New OdbcCommand(SimpanJual, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("TRANSAKSI BERHASIL DISIMPAN")
            Call dgvload()
            Call klir()

        End If
    End Sub

    Private Sub TBhareg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBhareg.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub TBhareg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBhareg.TextChanged

    End Sub

    Private Sub GunaTextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            GunaTextBox1.Focus()
        End If
    End Sub

    Private Sub GunaTextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaGroupBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox2.Click

    End Sub

    Private Sub GunaGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaGroupBox1.Click

    End Sub

    Private Sub GunaTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GunaTextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            TBhareg.Focus()
        End If
    End Sub

    Private Sub GunaTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox2.TextChanged

    End Sub

    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaTextBox1.Focus()
            TextBox2.Text = TextBox1.Text * TBhareg.Text
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text.Trim() <> "" Then
                TextBox1.Text = CDec(TextBox1.Text).ToString("N0")
                TextBox1.SelectionStart = TextBox1.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Try
            If TextBox2.Text.Trim() <> "" Then
                TextBox2.Text = CDec(TextBox2.Text).ToString("N0")
                TextBox2.SelectionStart = TextBox2.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TBomz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBomz.TextChanged
        Try
            If TBomz.Text.Trim() <> "" Then
                TBomz.Text = CDec(TBomz.Text).ToString("N0")
                TBomz.SelectionStart = TBomz.TextLength
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class