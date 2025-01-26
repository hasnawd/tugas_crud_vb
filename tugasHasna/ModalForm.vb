Imports MySql.Data.MySqlClient
Public Class ModalForm
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim connString As String = "Server=localhost;Database=crud_artis;Uid=root;"

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "Insert into artist (name_artist, birthdate, birthplace, height, categories_artist)
values (@name, @birthdate, @birthplace, @height, @categories)"

                Using CMd As New MySqlCommand(query, conn)
                    CMd.Parameters.AddWithValue("@name", TextBox1.Text)
                    CMd.Parameters.AddWithValue("@birthdate", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                    CMd.Parameters.AddWithValue("@birthplace", TextBox2.Text)
                    CMd.Parameters.AddWithValue("@height", TextBox3.Text)
                    CMd.Parameters.AddWithValue("@categories", ComboBox1.Text)

                    Dim result As Integer = CMd.ExecuteNonQuery()
                    If result > 0 Then
                        MessageBox.Show("Data berhasil ditambahkan")
                        FormArtist.FetchData()
                        Me.Close()
                    Else
                        MessageBox.Show("Gagal menambahkan data")
                    End If

                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)

            End Try
        End Using
    End Sub
End Class