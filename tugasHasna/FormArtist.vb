Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Tls
Public Class FormArtist
    Public Sub FetchData()
        Dim connString As String = "Server=localhost;Database=crud_artis;Uid=root;"
        Dim dt As New DataTable()

        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()
                Dim query As String = "Select * from artist"
                Using CMd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(CMd)
                        adapter.Fill(dt)
                    End Using
                End Using
                dgvArtist.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)

            End Try
        End Using
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click

    End Sub

    Private Sub FormArtist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FetchData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Modal As New ModalForm()
        Modal.ShowDialog()
    End Sub
End Class