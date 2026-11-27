Public Class FormAkunSaya
    Private customerId As Integer
    Private isPelanggan As Boolean

    Private Sub FormAkunSaya_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("akun", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                          btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                        btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)

        txtUsername.Text = UserSession.CurrentUsername
        txtUsername.ReadOnly = True
        txtPassLama.PasswordChar = "*"c
        txtPassBaru.PasswordChar = "*"c
        txtKonfirmasi.PasswordChar = "*"c

        ' Pelanggan punya baris customers (nama/telepon/email/alamat).
        ' Role lain hanya pakai users: sembunyikan field khusus pelanggan.
        isPelanggan = String.Equals(UserSession.CurrentRole, "Pelanggan", StringComparison.OrdinalIgnoreCase)
        If isPelanggan Then
            Try
                customerId = CustomerService.EnsureCustomerId()
                LoadCustomer()
            Catch ex As Exception
                MessageBox.Show("Gagal memuat data akun: " & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            HideCustomerFields()
            txtNama.Text = UserSession.CurrentFullName
        End If
    End Sub

    Private Sub HideCustomerFields()
        lblTelepon.Visible = False : txtTelepon.Visible = False
        lblEmail.Visible = False : txtEmail.Visible = False
        lblAlamat.Visible = False : txtAlamat.Visible = False
    End Sub

    ' Sumber nama/telepon/email/alamat = tabel customers (dipakai wizard reservasi).
    Private Sub LoadCustomer()
        Dim table As DataTable = GetTable(
            "SELECT full_name, phone, email, address FROM customers WHERE customer_id=@cid",
            P("@cid", customerId))
        If table.Rows.Count = 0 Then
            txtNama.Text = UserSession.CurrentFullName
            Return
        End If
        Dim row As DataRow = table.Rows(0)
        txtNama.Text = Convert.ToString(row("full_name"))
        txtTelepon.Text = Convert.ToString(row("phone"))
        txtEmail.Text = Convert.ToString(row("email"))
        txtAlamat.Text = Convert.ToString(row("address"))
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
            If isPelanggan Then
                Exec("UPDATE customers SET full_name=@nama, phone=@telpon, email=@email, address=@alamat " &
                     "WHERE customer_id=@cid",
                     P("@nama", txtNama.Text.Trim()), P("@telpon", txtTelepon.Text.Trim()),
                     P("@email", txtEmail.Text.Trim()), P("@alamat", txtAlamat.Text.Trim()),
                     P("@cid", customerId))
            End If
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
