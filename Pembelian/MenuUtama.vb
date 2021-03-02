Imports System.Data.Odbc
Public Class MenuUtama
    Sub tertutup()
        LoginPanel.Visible = True
        GunaAdvenceButton1.Visible = False
        GunaAdvenceButton2.Visible = False
        GunaAdvenceButton3.Visible = False
        GunaAdvenceButton4.Visible = False
        GunaAdvenceButton5.Visible = False

    End Sub
    Sub terbuka()
        LoginPanel.Visible = False
        GunaAdvenceButton1.Visible = True
        GunaAdvenceButton2.Visible = True
        GunaAdvenceButton3.Visible = True
        GunaAdvenceButton4.Visible = True
        GunaAdvenceButton5.Visible = True

    End Sub
    

    Private Sub MenuUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tertutup()
        Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 40, 13, Guna.UI.WinForms.VerHorAlign.VerticalRight)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaAdvenceButton1, Color.Black, 40, 13, Guna.UI.WinForms.VerHorAlign.VerticalRight)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaAdvenceButton2, Color.Black, 40, 13, Guna.UI.WinForms.VerHorAlign.VerticalRight)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaAdvenceButton3, Color.Black, 40, 13, Guna.UI.WinForms.VerHorAlign.VerticalRight)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaAdvenceButton4, Color.Black, 40, 13, Guna.UI.WinForms.VerHorAlign.VerticalRight)
    End Sub
    Sub identitas()
        Call Koneksi()
        Cmd = New OdbcCommand("select * from user", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then

            LBLNama.Text = Rd!namPeg
            'LBLjab.Text = Rd!jabatan
            'LBLnip.Text = Rd!NIP

        End If
    End Sub

    Private Sub GunaAdvenceButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GunaAdvenceButton1.CheckedChanged
        If GunaAdvenceButton1.Checked Then
            Page1.BringToFront()
        End If
    End Sub

    Private Sub GunaAdvenceButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GunaAdvenceButton2.CheckedChanged
        If GunaAdvenceButton2.Checked Then
            Page2.BringToFront()
        End If
    End Sub

    Private Sub GunaAdvenceButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GunaAdvenceButton3.CheckedChanged
        If GunaAdvenceButton3.Checked Then
            Page3.BringToFront()
        End If
    End Sub

    Private Sub GunaAdvenceButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GunaAdvenceButton4.CheckedChanged
        If GunaAdvenceButton4.Checked Then
            Page4.BringToFront()
        End If
    End Sub

    'Private Sub GunaAdvenceButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GunaAdvenceButton5.CheckedChanged
    'If GunaAdvenceButton5.Checked Then
    'Call tertutup()
    'End If
    'End Sub

    Private Sub GunaAdvenceButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaAdvenceButton5.Click
        Me.Close()


    End Sub


    Private Sub GunaTileButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton1.Click
        Pembelian.ShowDialog()
    End Sub
    Private Sub GunaPictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub GunaTileButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        If GunaTextBox1.Text = "" Or GunaTextBox2.Text = "" Then
            MsgBox("SILAHKAN ISI USER DAN PASSWORD")
        Else
            Call Koneksi()
            Cmd = New OdbcCommand("Select * From user where USERNAME='" & GunaTextBox1.Text & "' and PASSWORD = '" & GunaTextBox2.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call terbuka()


                LBLNama.Text = Rd!NAMA
                LBLjab.Text = Rd!LEVEL
                LBLnip.Text = Rd!USERID
                time.ShowDialog()
                'If FormMenuUtama.STlabel6.Text = "USER" Then
                'FormMenuUtama.AdminToolStripMenuItem.Enabled = False
                'End If

            Else
                MsgBox("Kode Admin Atau Password Salah!")
            End If
        End If

    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        Me.Close()
    End Sub

    Private Sub GunaTileButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaTileButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MasterUser.ShowDialog()
    End Sub

    Private Sub GunaTileButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaTileButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaTileButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaTileButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GunaTileButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton17.Click
        Penjualan.ShowDialog()
    End Sub

    Private Sub GunaTileButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MasterUser.ShowDialog()
    End Sub

    Private Sub GunaTileButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton2.Click
        Master_Pelanggan.ShowDialog()
    End Sub

    Private Sub GunaTileButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton3.Click
        MasterUser.ShowDialog()
    End Sub

    Private Sub LoginPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles LoginPanel.Paint

    End Sub

    Private Sub GunaTileButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton4.Click
        MasterPelanggan1.ShowDialog()
    End Sub

    Private Sub GunaTileButton5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton5.Click
        MasterSatuan.ShowDialog()
    End Sub

    Private Sub GunaTileButton10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton10.Click
        MasterKategori.ShowDialog()
    End Sub

    Private Sub GunaTileButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton11.Click
        Form1.ShowDialog()
    End Sub

    Private Sub GunaAdvenceButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaAdvenceButton4.Click

    End Sub

    Private Sub GunaTileButton6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton6.Click
        MasterLayanan.ShowDialog()
    End Sub

    Private Sub GunaTileButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton12.Click
        MasterKopi.ShowDialog()
    End Sub

    Private Sub GunaTileButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton20.Click
        MasterSuplier.ShowDialog()
    End Sub

    Private Sub GunaPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GunaPanel1.Paint

    End Sub

    Private Sub GunaTileButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton15.Click
        elemen.ShowDialog()
    End Sub

    Private Sub GunaTileButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton8.Click
        LaporanBeli.ShowDialog()
    End Sub

    Private Sub GunaTileButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton9.Click
        LaporanJual.ShowDialog()
    End Sub

    Private Sub GunaTileButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton13.Click
        angsur.ShowDialog()
    End Sub

    Private Sub GunaTileButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton19.Click
        fee.ShowDialog()
    End Sub

    Private Sub GunaTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GunaTextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaTextBox2.Focus()

        End If
    End Sub

    Private Sub GunaTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox1.TextChanged

    End Sub

    Private Sub GunaTileButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton21.Click
        keluar.ShowDialog()
    End Sub

    Private Sub GunaTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GunaTextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            GunaButton1.Focus()

        End If
    End Sub

    Private Sub GunaTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTextBox2.TextChanged
       
    End Sub

    Private Sub GunaTileButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaTileButton14.Click
        gaji.ShowDialog()
    End Sub
End Class