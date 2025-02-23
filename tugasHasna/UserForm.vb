Imports MySql.Data.MySqlClient

Public Class UserForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connString As String = "Server=localhost;Database=crud_artis;Uid=root;"
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM user WHERE email=@email AND password=@password"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@email", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@password", TextBox2.Text)

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Login berhasil")

                        ' Cari FormMain yang sedang tersembunyi
                        Dim frmMain As FormMain = CType(Application.OpenForms("FormMain"), FormMain)
                        If frmMain IsNot Nothing Then
                            frmMain.isLoggedIn = True
                            frmMain.UpdateMenu()
                            frmMain.Show() ' Tampilkan kembali FormMain
                        End If

                        Me.Close() ' Tutup form login
                    Else
                        MessageBox.Show("Username / password salah")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub
End Class
