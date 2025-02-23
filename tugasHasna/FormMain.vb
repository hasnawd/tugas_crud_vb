Public Class FormMain
    ' Status login (default: False)
    Public isLoggedIn As Boolean = False

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur FormMain sebagai MDI container
        Me.IsMdiContainer = True
        ' Update menu awal
        UpdateMenu()
    End Sub

    ' Fungsi untuk mengupdate menu berdasarkan status login
    Public Sub UpdateMenu()
        LoginToolStripMenuItem.Visible = Not isLoggedIn
        LogoutToolStripMenuItem.Visible = isLoggedIn
        MasterToolStripMenuItem.Visible = isLoggedIn
    End Sub

    ' Fungsi untuk menampilkan UserForm dan menyembunyikan FormMain
    Private Sub ShowLoginForm()
        Me.Hide() ' Sembunyikan FormMain

        Dim frmLogin As New UserForm()
        frmLogin.ShowDialog() ' Tampilkan sebagai modal (blok FormMain)

        ' Jika login berhasil, tampilkan kembali FormMain
        If isLoggedIn Then
            UpdateMenu()
            Me.Show()
        Else
            ' Jika user menutup login tanpa login, keluar dari aplikasi
            Application.Exit()
        End If
    End Sub

    ' Event handler saat menu Login diklik
    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        ShowLoginForm()
    End Sub

    ' Logout: kembali ke halaman login
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        isLoggedIn = False
        UpdateMenu()
        ShowLoginForm()
    End Sub

    ' Keluar dari aplikasi
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    ' Buka halaman Master Data Artist sebagai form biasa (tanpa MenuStrip)
    Private Sub MasterDataArtistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterDataArtistToolStripMenuItem.Click
        ' Pastikan FormMain sudah aktif sebelum membuka FormArtist
        If Not Me.Visible Then Me.Show()

        Dim frmArtist As New FormArtist()
        frmArtist.Show() ' Gunakan Show() agar tidak ada error
    End Sub
End Class
