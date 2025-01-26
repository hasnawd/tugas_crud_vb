Imports System.Data.Odbc
Public Class FormLogin
    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("E-mail dan password tidak boleh kosong")
        Else
            Call Koneksi()
            CMd = New OdbcCommand("Select * From user where email='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", Conn)
            Rd = CMd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                'Me.Close()
                FormArtist.Show()
            End If

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class