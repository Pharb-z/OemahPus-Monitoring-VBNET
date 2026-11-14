Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Public Class FormLogin
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True

    End Sub

    ' Menampilkan atau menyembunyikan password
    Private Sub chkShowPassword_CheckedChanged(
        sender As Object,
        e As EventArgs
    ) Handles chkShowPassword.CheckedChanged

        txtPassword.UseSystemPasswordChar =
            Not chkShowPassword.Checked

    End Sub

    ' Proses Login
    Private Sub btnLogin_Click(sender As Object,
                               e As EventArgs) Handles btnLogin.Click

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        ' Validasi input kosong
        If username = "" OrElse password = "" Then

            MessageBox.Show(
                "Username dan password wajib diisi.",
                "Validasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return
        End If

        Try

            ' Mengambil data akun dari database
            Dim dt As DataTable = GetTable(
                "SELECT user_id, username, password_hash, " &
                "full_name, role, is_active " &
                "FROM users WHERE username = @username",
                P("@username", username)
            )

            ' Memeriksa keberadaan akun
            If dt.Rows.Count = 0 Then

                MessageBox.Show(
                    "Username atau password salah.",
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )

                Return
            End If

            Dim user As DataRow = dt.Rows(0)

            Dim passwordHash As String =
                user("password_hash").ToString()

            Dim role As String =
                user("role").ToString()

            Dim isActive As Boolean =
                Convert.ToBoolean(user("is_active"))

            ' Memeriksa password menggunakan BCrypt
            If Not BCrypt.Net.BCrypt.Verify(
                password,
                passwordHash
            ) Then

                MessageBox.Show(
                    "Username atau password salah.",
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )

                Return
            End If

            ' Memeriksa status akun
            If Not isActive Then

                MessageBox.Show(
                    "Akun kamu sedang tidak aktif.",
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return
            End If

            ' Menyimpan informasi pengguna ke UserSession
            UserSession.CurrentUserId =
            Convert.ToInt32(user("user_id"))

            UserSession.CurrentUsername =
            user("username").ToString()

            UserSession.CurrentRole =
            user("role").ToString()

            UserSession.CurrentFullName =
            user("full_name").ToString()

            ' Memeriksa role pengguna
            If role = "Owner" Then

                MessageBox.Show(
                    "Selamat datang di OMI, " &
                    user("full_name").ToString() & "!",
                    "Login Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

                ' Membuka Dashboard Owner
                Dim dashboard As New FormDataPaketLayanan()
                dashboard.Show()

                Me.Hide()

            Else

                MessageBox.Show(
                    "Dashboard untuk role " & role &
                    " belum tersedia.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If

        Catch ex As MySqlException

            ShowDatabaseError(ex)

        Catch ex As Exception

            ShowGeneralError(ex)

        End Try



    End Sub

    ' Menampilkan pesan kesalahan database
    Private Sub ShowDatabaseError(ex As MySqlException)

        MessageBox.Show(
            "Kesalahan database (" & ex.Number & "): " &
            ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

    End Sub

    ' Menampilkan pesan kesalahan umum
    Private Sub ShowGeneralError(ex As Exception)

        MessageBox.Show(
            "Terjadi kesalahan: " & ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )
    End Sub


End Class