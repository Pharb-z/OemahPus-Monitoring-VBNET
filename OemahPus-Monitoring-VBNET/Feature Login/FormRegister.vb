Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class FormRegister
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property NewUserId As Integer

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property NewUsername As String = String.Empty

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property NewFullName As String = String.Empty

    Private Sub FormRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEmail.Focus()
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
        txtConfirm.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim phone As String = txtPhone.Text.Trim()
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(phone) OrElse
           String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) OrElse
           String.IsNullOrWhiteSpace(txtConfirm.Text) Then
            Fail("Semua kolom wajib diisi.")
            Return
        End If
        If Not Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            Fail("Format email belum benar.")
            Return
        End If
        Dim digitCount As Integer = Regex.Matches(phone, "\d").Count
        If Not Regex.IsMatch(phone, "^[0-9+\-\s]+$") OrElse digitCount < 8 OrElse digitCount > 20 Then
            Fail("Nomor HP hanya boleh angka, 8-20 digit.")
            Return
        End If
        If username.Length < 3 Then
            Fail("Username minimal 3 karakter.")
            Return
        End If
        If password.Length < 6 Then
            Fail("Password minimal 6 karakter.")
            Return
        End If
        If password <> txtConfirm.Text Then
            Fail("Password dan konfirmasi tidak sama.")
            Return
        End If

        Try
            If Convert.ToInt32(Scalar("SELECT COUNT(*) FROM users WHERE username=@u", P("@u", username))) > 0 Then
                Fail("Username atau email sudah terdaftar.")
                Return
            End If
            If Convert.ToInt32(Scalar("SELECT COUNT(*) FROM customers WHERE email=@e", P("@e", email))) > 0 Then
                Fail("Username atau email sudah terdaftar.")
                Return
            End If

            ' full_name wajib di tabel users; prototipe signup tidak punya kolomnya.
            Dim fullName As String = username
            Exec("INSERT INTO users (username, password_hash, full_name, role, is_active) " &
                 "VALUES (@u, @h, @n, 'Pelanggan', 1)",
                 P("@u", username), P("@h", BCrypt.Net.BCrypt.HashPassword(password)),
                 P("@n", fullName))
            Dim id As Integer = Convert.ToInt32(Scalar("SELECT LAST_INSERT_ID()"))

            ' ponytail: dua Exec tanpa transaksi; EnsureCustomerId di form Pelanggan
            ' menambal baris customers kalau insert ini gagal.
            Exec("INSERT INTO customers (user_id, full_name, phone, email) VALUES (@id, @n, @p, @e)",
                 P("@id", id), P("@n", fullName), P("@p", phone), P("@e", email))

            NewUserId = id
            NewUsername = username
            NewFullName = fullName
            MessageBox.Show("Registrasi berhasil. Selamat datang di OMI!", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            Close()
        Catch ex As MySqlException When ex.Number = 1062
            Fail("Username atau email sudah terdaftar.")
        Catch ex As Exception
            MessageBox.Show("Gagal mendaftar: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Fail(message As String)
        lblInfo.Text = message
        MessageBox.Show(message, "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
End Class
