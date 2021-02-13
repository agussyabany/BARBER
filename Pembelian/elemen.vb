Public Class elemen
    Private Sub GunaButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton1.Click
        With My.Settings
            .elcarikontak = TBhareg.Text
            .Save()
            MsgBox("SUKSES")
            Me.Close()
        End With
    End Sub

    Private Sub GunaButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GunaButton2.Click
        With My.Settings
            .elisipesankontak = GunaTextBox1.Text
            .Save()
            MsgBox("SUKSES")
            Me.Close()
        End With
    End Sub

    Private Sub Handle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class