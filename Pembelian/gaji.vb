Imports System.Data.Odbc
Public Class gaji
    Dim TglMySQL As String

    Sub kondisiAwal()
        GCjabat.Items.Clear()
        GCjabat.Items.Add("HAIR STYLIST")
        GCjabat.Items.Add("CAPSTER")
        GCjabat.Items.Add("BARBER")
        TBtime.Text = Today
        GCBln.Items.Clear()
        GCBln.Items.Add("1")
        GCBln.Items.Add("2")
        GCBln.Items.Add("3")
        GCBln.Items.Add("4")
        GCBln.Items.Add("5")
        GCBln.Items.Add("6")
        GCBln.Items.Add("7")
        GCBln.Items.Add("8")
        GCBln.Items.Add("9")
        GCBln.Items.Add("10")
        GCBln.Items.Add("11")
        GCBln.Items.Add("12")
    End Sub


    Private Sub GunaButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton4.Click
        Me.Close()
    End Sub

    Private Sub gaji_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiAwal()
    End Sub
    Sub RumusSubtotalHB()
        Dim hitung As Integer = 0
        hitung = Val(LBLfeeLayan.Text) + Val(LBLfeeProd.Text)
        LBLsub.Text = hitung
        LBLsub.Text = Format(hitung, "###,###,###")
    End Sub
    Sub RumusSubtotalC()
        Dim hitung As Integer = 0
        hitung = Val(LBLfeeLayan.Text) + Val(LBLfeeProd.Text) + Val(TBjumhadir.Text) + Val(TBLemJum.Text)
        LBLsub.Text = hitung
        LBLsub.Text = Format(hitung, "###,###,###")
    End Sub
    Sub takeHome()
        Dim hitung As Integer = 0
        hitung = Val(LBLfeeLayan.Text) + Val(LBLfeeProd.Text) + Val(TBjumhadir.Text) + Val(TBLemJum.Text) - Val(Tbpot.Text)
        LBLtHp.Text = hitung
        LBLtHp.Text = Format(hitung, "###,###,###")
    End Sub
    Private Sub GCjabat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCjabat.SelectedIndexChanged
        LBLsub.Text = ""
        If GCjabat.Text = "HAIR STYLIST" Then

            Call Koneksi()
            GCPegawai.Items.Clear()
            Cmd = New OdbcCommand("Select NAMA from pegawai where JABATAN='HAIR STYLIST'", Conn)
            Rd = Cmd.ExecuteReader
            Do While Rd.Read
                GCPegawai.Items.Add(Rd.Item(0))
            Loop
        End If


        If GCjabat.Text = "BARBER" Then

            Call Koneksi()
            GCPegawai.Items.Clear()
            Cmd = New OdbcCommand("Select NAMA from pegawai where JABATAN='BARBER'", Conn)
            Rd = Cmd.ExecuteReader
            Do While Rd.Read
                GCPegawai.Items.Add(Rd.Item(0))
            Loop

        End If

        If GCjabat.Text = "CAPSTER" Then

            Call Koneksi()
            GCPegawai.Items.Clear()
            Cmd = New OdbcCommand("Select NAMA from pegawai where JABATAN='CAPSTER'", Conn)
            Rd = Cmd.ExecuteReader
            Do While Rd.Read
                GCPegawai.Items.Add(Rd.Item(0))
            Loop

        End If
    End Sub

    Private Sub GCPegawai_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCPegawai.SelectedIndexChanged
        TBjumhadir.Text = ""
        TbHhadir.Text = ""
        TBLemJum.Text = ""
        TTbHRlem.Text = ""



        If GCjabat.Text = "HAIR STYLIST" Then

            Call Koneksi()
            Cmd = New OdbcCommand("SELECT jual.TANGGAL,detaillayan.TOTAL,detaillayan.JUMLAH,SUM(detaillayan.TOTAL) AS duitnya,SUM(detaillayan.JUMLAH) AS jumlah_layan FROM(detaillayan) LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL  WHERE MONTH(TANGGAL) ='" & GCBln.Text & "' and PEGAWAI = '" & GCPegawai.Text & "' and YEAR(TANGGAL)='" & GNThn.Value & "' ", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            lblTotlayan.Text = Rd.Item("jumlah_layan").ToString
            LBLjumlAyan.Text = Rd.Item("duitnya").ToString
            LBLfeeLayan.Text = Rd.Item("duitnya") * (40 / 100)

            Cmd = New OdbcCommand("SELECT jual.TANGGAL,detailjual.TOTAL,detailjual.JUMLAH,SUM(detailjual.TOTAL) AS PRODUK,SUM(detailjual.JUMLAH) AS BANYAK FROM(detailjual) LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL  WHERE MONTH(TANGGAL) ='" & GCBln.Text & "' and PEGAWAI = '" & GCPegawai.Text & "' and YEAR(TANGGAL)='" & GNThn.Value & "' ", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not IsDBNull(Rd.Item("BANYAK")) Then
                LblTotProd.Text = Rd.Item("BANYAK").ToString
                LBLfeeProd.Text = Rd.Item("BANYAK") * (15000).ToString

            Else
                LblTotProd.Text = "0"
                LBLfeeProd.Text = "0"
            End If
            Call RumusSubtotalHB()
            Tbpot.Focus()
        End If


        If GCjabat.Text = "BARBER" Then

            Call Koneksi()
            Cmd = New OdbcCommand("SELECT jual.TANGGAL,detaillayan.TOTAL,detaillayan.JUMLAH,SUM(detaillayan.TOTAL) AS duitnya,SUM(detaillayan.JUMLAH) AS jumlah_layan FROM(detaillayan) LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL  WHERE MONTH(TANGGAL) ='" & GCBln.Text & "' and PEGAWAI = '" & GCPegawai.Text & "' and YEAR(TANGGAL)='" & GNThn.Value & "' ", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            lblTotlayan.Text = Rd.Item("jumlah_layan")
            LBLjumlAyan.Text = Rd.Item("duitnya")
            LBLfeeLayan.Text = Rd.Item("duitnya") * (33 / 100)

            Cmd = New OdbcCommand("SELECT jual.TANGGAL,detailjual.TOTAL,detailjual.JUMLAH,SUM(detailjual.TOTAL) AS PRODUK,SUM(detailjual.JUMLAH) AS BANYAK FROM(detailjual) LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL  WHERE MONTH(TANGGAL) ='" & GCBln.Text & "' and PEGAWAI = '" & GCPegawai.Text & "' and YEAR(TANGGAL)='" & GNThn.Value & "' ", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not IsDBNull(Rd.Item("BANYAK")) Then
                LblTotProd.Text = Rd.Item("BANYAK").ToString
                LBLfeeProd.Text = Rd.Item("BANYAK") * (15000).ToString

            Else
                LblTotProd.Text = "0"
                LBLfeeProd.Text = "0"
            End If
            Call RumusSubtotalHB()
            Tbpot.Focus()
        End If

        If GCjabat.Text = "CAPSTER" Then

            Call Koneksi()
            Cmd = New OdbcCommand("SELECT jual.TANGGAL,detaillayan.TOTAL,detaillayan.JUMLAH,SUM(detaillayan.TOTAL) AS duitnya,SUM(detaillayan.JUMLAH) AS jumlah_layan FROM(detaillayan) LEFT JOIN jual ON detaillayan.IDJUAL=jual.IDJUAL  WHERE MONTH(TANGGAL) ='" & GCBln.Text & "' and PEGAWAI = '" & GCPegawai.Text & "' and YEAR(TANGGAL)='" & GNThn.Value & "' ", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            lblTotlayan.Text = Rd.Item("jumlah_layan")
            LBLjumlAyan.Text = Rd.Item("duitnya")
            LBLfeeLayan.Text = Rd.Item("duitnya") * (15 / 100)

            Cmd = New OdbcCommand("SELECT jual.TANGGAL,detailjual.TOTAL,detailjual.JUMLAH,SUM(detailjual.TOTAL) AS PRODUK,SUM(detailjual.JUMLAH) AS BANYAK FROM(detailjual) LEFT JOIN jual ON detailjual.IDJUAL=jual.IDJUAL  WHERE MONTH(TANGGAL) ='" & GCBln.Text & "' and PEGAWAI = '" & GCPegawai.Text & "' and YEAR(TANGGAL)='" & GNThn.Value & "' ", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not IsDBNull(Rd.Item("BANYAK")) Then
                LblTotProd.Text = Rd.Item("BANYAK").ToString
                LBLfeeProd.Text = Rd.Item("BANYAK") * (15000).ToString

            Else
                LblTotProd.Text = "0"
                LBLfeeProd.Text = "0"
            End If
            TbHhadir.Focus()

        End If
    End Sub

    Private Sub GunaTextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TbHhadir.KeyPress
        If e.KeyChar = Chr(13) Then

            TTbHRlem.Focus()
            If TbHhadir.Text = "" Then
                MsgBox("SILAHKAN ISI JUMLAH HARI")
            Else
                If GCPegawai.Text = "Khusnul" Then
                    TBjumhadir.Text = TbHhadir.Text * 65000
                Else

                    If GCPegawai.Text = "Widya" Then
                        TBjumhadir.Text = TbHhadir.Text * 55000

                    Else

                        If GCPegawai.Text = "Haris" Then
                            TBjumhadir.Text = TbHhadir.Text * 60000

                        Else
                            If GCjabat.Text = "CAPSTER" Then
                                TBjumhadir.Text = TbHhadir.Text * 40000
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub GunaTextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbHhadir.TextChanged

    End Sub

    Private Sub GunaTextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBLemJum.TextChanged

    End Sub

    Private Sub GunaTextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TTbHRlem.KeyPress
        If e.KeyChar = Chr(13) Then
            Call RumusSubtotalC()
            Tbpot.Focus()
            If TbHhadir.Text = "" Then
                MsgBox("SILAHKAN ISI JUMLAH HARI")
            Else
                TBLemJum.Text = TTbHRlem.Text * 15000
            End If
        End If
    End Sub

    Private Sub GunaTextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTbHRlem.TextChanged

    End Sub

    Private Sub GunaLabel12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBLsub.Click

    End Sub

    Private Sub GunaTextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tbpot.KeyPress
        If e.KeyChar = Chr(13) Then
            If Tbpot.Text = "" Then
                MsgBox("SILHAKAN ISI POTONGAN")
            Else

                Call takeHome()
            End If
        End If
    End Sub

    Private Sub GunaTextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbpot.TextChanged

    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click

        If GCjabat.Text = "" Or GCPegawai.Text = "" Or Tbpot.Text = "" Then
            MsgBox("Silhkan Isi Semua Filed")
        Else
            If MessageBox.Show(" ANDA YAKIN AKAN GAJIAN HARI INI?", "KONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                TglMySQL = Format(Today, "yyyy-MM-dd    ")
                Dim SimpanGaji As String = "Insert into gaji (tgl,jabatan,nama,layanan,fee_layanan,produk,fee_produk,hadir_hari,hadir_jumlah,lembur_hari,lembur_jumlah,sub,potong,bulan,tahun,take_home) values ('" & TglMySQL & "','" & GCjabat.Text & "','" & GCPegawai.Text & "','" & LBLjumlAyan.Text & "','" & LBLfeeLayan.Text & "','" & LblTotProd.Text & "','" & LBLfeeProd.Text & "','" & TbHhadir.Text & "','" & TBjumhadir.Text & "','" & TTbHRlem.Text & "','" & TBLemJum.Text & "','" & LBLsub.Text & "','" & Tbpot.Text & "','" & GCBln.Text & "','" & GNThn.Text & "','" & LBLtHp.Text & "')"
                Cmd = New OdbcCommand(SimpanGaji, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("GAJI BERHASIL DIPROSES")
            End If
        End If

    End Sub
End Class