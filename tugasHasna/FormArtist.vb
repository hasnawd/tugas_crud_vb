Imports MySql.Data.MySqlClient

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

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private dtpBirthdate As New DateTimePicker() ' DateTimePicker untuk edit tanggal lahir
    Private currentRow As Integer = -1 ' Menyimpan baris yang sedang diedit
    Private isDatePickerVisible As Boolean = False

    Private Sub FormArtist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FetchData()
        Me.Enabled = True
        dgvArtist.Enabled = True
        dgvArtist.ReadOnly = False
        Button1.Enabled = True
        Button2.Enabled = True
        dgvArtist.AllowUserToAddRows = False ' Agar user tidak bisa menambah baris baru langsung
        dgvArtist.Columns("id_artist").ReadOnly = True



        ' Setup DateTimePicker
        dtpBirthdate.Format = DateTimePickerFormat.Short
        dtpBirthdate.Visible = False
        Controls.Add(dtpBirthdate)

        ' Mencegah klik di luar kontrol DateTimePicker
        AddHandler Me.Click, AddressOf FormArtist_Click
        AddHandler dtpBirthdate.ValueChanged, AddressOf dtpBirthdate_ValueChanged

        ' Menambahkan kolom tombol hapus
        Dim deleteColumn As New DataGridViewButtonColumn()
        deleteColumn.Name = "Delete"
        deleteColumn.HeaderText = "Action"
        deleteColumn.Text = "Hapus"
        deleteColumn.UseColumnTextForButtonValue = True

        ' Menambahkan kolom hapus di urutan terakhir
        dgvArtist.Columns.Add(deleteColumn)

        '' Mengatur posisi kolom hapus di ujung kanan
        dgvArtist.Columns("Delete").DisplayIndex = dgvArtist.Columns.Count - 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Modal As New ModalForm
        Modal.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Count As Integer = 0
        Dim connString As String = "Server=localhost;Database=crud_artis;Uid=root;"

        Count = 0
        MessageBox.Show("Logout berhasil")
        UserForm.Show()
        Me.Hide()
    End Sub


    Private Sub dgvArtist_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArtist.CellContentClick
        ' Memastikan bahwa yang diklik adalah tombol hapus (Delete)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvArtist.Columns("Delete").Index Then
            ' Ambil ID dari baris yang dipilih
            Dim id_artist As Integer = Convert.ToInt32(dgvArtist.Rows(e.RowIndex).Cells("id_artist").Value)

            ' Tanyakan kepada pengguna apakah mereka yakin ingin menghapus data
            Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                ' Jika pengguna setuju, hapus data dari database
                Dim connString As String = "Server=localhost;Database=crud_artis;Uid=root;"
                Using conn As New MySqlConnection(connString)
                    Try
                        conn.Open()

                        ' Query untuk menghapus data
                        Dim query As String = "DELETE FROM artist WHERE id_artist = @id"

                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@id", id_artist)

                            ' Eksekusi query
                            Dim resultDelete As Integer = cmd.ExecuteNonQuery()
                            If resultDelete > 0 Then
                                MessageBox.Show("Data berhasil dihapus!", "Hapus Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ' Update DataGridView setelah menghapus
                                FetchData()
                            Else
                                MessageBox.Show("Gagal menghapus data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End If
        End If
    End Sub

    ''' Menyimpan perubahan data di DataGridView ke database.
    Private Sub dgvArtist_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArtist.CellEndEdit
        ' Pastikan bukan header yang diedit
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgvArtist.Columns(e.ColumnIndex).Name
            Dim newValue As Object = dgvArtist.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            ' Panggil fungsi update jika bukan kolom id_artist
            If columnName <> "id_artist" Then
                UpdateDatabase(e.RowIndex, columnName, newValue)
            End If
        End If
    End Sub

    ''' Fungsi untuk menyimpan perubahan ke database.
    Private Sub UpdateDatabase(rowIndex As Integer, columnName As String, newValue As Object)
        Dim connString As String = "Server=localhost;Database=crud_artis;Uid=root;"
        Using conn As New MySqlConnection(connString)
            Try
                conn.Open()

                ' Ambil ID baris yang diedit
                Dim id_artist As Integer = Convert.ToInt32(dgvArtist.Rows(rowIndex).Cells("id_artist").Value)

                ' Query Update
                Dim query As String = $"UPDATE artist SET {columnName} = @value WHERE id_artist = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@value", newValue)
                    cmd.Parameters.AddWithValue("@id", id_artist)

                    Dim result As Integer = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        MessageBox.Show($"{columnName} berhasil diperbarui!", "Update Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Gagal memperbarui data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub dgvArtist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArtist.CellClick
        If e.RowIndex >= 0 AndAlso dgvArtist.Columns(e.ColumnIndex).Name = "birthdate" Then
            ' Simpan baris yang sedang diedit
            currentRow = e.RowIndex

            ' Tampilkan DateTimePicker di atas kolom yang diklik
            Dim cellRect As Rectangle = dgvArtist.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            dtpBirthdate.Location = New Point(cellRect.Left, cellRect.Bottom)
            dtpBirthdate.Size = New Size(cellRect.Width, 25)
            dtpBirthdate.Visible = True
            dtpBirthdate.BringToFront()

            ' Set agar grid tidak bisa diklik saat DateTimePicker muncul
            isDatePickerVisible = True
            dgvArtist.Enabled = False
        End If
    End Sub

    ''' Menyimpan perubahan tanggal lahir ke DataGridView dan database.
    Private Sub dtpBirthdate_ValueChanged(sender As Object, e As EventArgs)
        ' Update nilai di DataGridView
        dgvArtist.Rows(currentRow).Cells("birthdate").Value = dtpBirthdate.Value.ToString("yyyy-MM-dd")

        ' Panggil fungsi update ke database
        UpdateDatabase(currentRow, "birthdate", dtpBirthdate.Value.ToString("yyyy-MM-dd"))

        ' Sembunyikan DateTimePicker setelah update
        dtpBirthdate.Visible = False
        dgvArtist.Enabled = True ' Mengaktifkan kembali interaksi dengan grid
        isDatePickerVisible = False
    End Sub

    Private Sub dtpBirthdate_LostFocus(sender As Object, e As EventArgs)
        SaveBirthdateToDatabase()
    End Sub

    ''' Simpan perubahan ke database saat user menekan Enter.
    Private Sub dtpBirthdate_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Then
            SaveBirthdateToDatabase()
        End If
    End Sub

    ''' Fungsi untuk menyimpan perubahan tanggal lahir ke database.
    Private Sub SaveBirthdateToDatabase()
        If currentRow >= 0 Then
            ' Ambil nilai baru dari DateTimePicker
            Dim newDate As String = dtpBirthdate.Value.ToString("yyyy-MM-dd")

            ' Masukkan nilai ke DataGridView
            dgvArtist.Rows(currentRow).Cells("birthdate").Value = newDate

            ' Panggil fungsi update ke database
            UpdateDatabase(currentRow, "birthdate", newDate)

            ' Sembunyikan DateTimePicker
            dtpBirthdate.Visible = False
            currentRow = -1 ' Reset row index
        End If
    End Sub

    Private Sub FormArtist_Click(sender As Object, e As EventArgs)
        ' Jika DateTimePicker terlihat, sembunyikan setelah klik di luar
        If isDatePickerVisible AndAlso Not dtpBirthdate.ClientRectangle.Contains(dtpBirthdate.PointToClient(MousePosition)) Then
            dtpBirthdate.Visible = False
            dgvArtist.Enabled = True
            isDatePickerVisible = False
        End If
    End Sub
End Class