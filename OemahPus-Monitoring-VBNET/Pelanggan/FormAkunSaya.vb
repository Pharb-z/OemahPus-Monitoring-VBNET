Public Class FormAkunSaya

    Private Sub FormAkunSaya_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("akun", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuReservasiPelanggan,
                          btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuReservasiPelanggan,
                        btnMenuRiwayat, btnMenuAkun)

        txtNama.Text = UserSession.CurrentFullName
        txtUsername.Text = UserSession.CurrentUsername
        txtUsername.ReadOnly = True
        txtPassLama.PasswordChar = "*"c
        txtPassBaru.PasswordChar = "*"c
        txtKonfirmasi.PasswordChar = "*"c
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim changePassword As Boolean = Not String.IsNullOrEmpty(txtPassLama.Text) OrElse
                                        Not String.IsNullOrEmpty(txtPassBaru.Text) OrElse
                                        Not String.IsNullOrEmpty(txtKonfirmasi.Text)
        If changePassword Then
            If txtPassBaru.Text <> txtKonfirmasi.Text Then
                MessageBox.Show("Password dan konfirmasi tidak sama.", "Validasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If txtPassBaru.Text.Length < 6 Then
                MessageBox.Show("Password minimal 6 karakter.", "Validasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Try
            Exec("UPDATE users SET full_name=@nama WHERE user_id=@id",
                 P("@nama", txtNama.Text.Trim()), P("@id", UserSession.CurrentUserId))
            Exec("UPDATE customers SET full_name=@nama WHERE user_id=@id",
                 P("@nama", txtNama.Text.Trim()), P("@id", UserSession.CurrentUserId))
            UserSession.CurrentFullName = txtNama.Text.Trim()

            If changePassword Then
                Dim hash As Object = Scalar("SELECT password_hash FROM users WHERE user_id=@id",
                                            P("@id", UserSession.CurrentUserId))
                If hash Is Nothing OrElse hash Is DBNull.Value OrElse
                   Not BCrypt.Net.BCrypt.Verify(txtPassLama.Text, hash.ToString()) Then
                    MessageBox.Show("Password lama salah.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                Exec("UPDATE users SET password_hash=@hash WHERE user_id=@id",
                     P("@hash", BCrypt.Net.BCrypt.HashPassword(txtPassBaru.Text)),
                     P("@id", UserSession.CurrentUserId))
            End If

            txtPassLama.Clear()
            txtPassBaru.Clear()
            txtKonfirmasi.Clear()
            MessageBox.Show("Perubahan tersimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
