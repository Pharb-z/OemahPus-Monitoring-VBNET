Imports MySql.Data.MySqlClient

' Daftar customer. Tambah/Ubah dibuka di halaman terpisah (FormCustomerEdit).
Public Class FormCustomer

    Private Sub FormCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("customer", Me)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                              btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun, btnLogout)
        LoadGrid()
    End Sub

    Private Sub FormCustomer_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Visible Then Return
        LoadGrid()
    End Sub

    Private Sub LoadGrid()
        Try
            Dim keyword As String = "%" & txtCari.Text.Trim() & "%"
            Dim dt As DataTable = GetTable(
                "SELECT customer_id, full_name, phone, address, email FROM customers " &
                "WHERE full_name LIKE @keyword OR phone LIKE @keyword OR email LIKE @keyword " &
                "ORDER BY customer_id DESC", P("@keyword", keyword))
            dgvCustomer.DataSource = dt
            If dgvCustomer.Columns.Contains("customer_id") Then dgvCustomer.Columns("customer_id").HeaderText = "ID"
            If dgvCustomer.Columns.Contains("full_name") Then dgvCustomer.Columns("full_name").HeaderText = "Nama Lengkap"
            If dgvCustomer.Columns.Contains("phone") Then dgvCustomer.Columns("phone").HeaderText = "No Telepon"
            If dgvCustomer.Columns.Contains("address") Then dgvCustomer.Columns("address").HeaderText = "Alamat"
            If dgvCustomer.Columns.Contains("email") Then dgvCustomer.Columns("email").HeaderText = "Email"
            dgvCustomer.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data customer: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        LoadGrid()
    End Sub

    Private Function SelectedCustomerId() As Integer
        If dgvCustomer.CurrentRow Is Nothing Then Return 0
        Dim v As Object = dgvCustomer.CurrentRow.Cells("customer_id").Value
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        Return Convert.ToInt32(v)
    End Function

    ' Buang instance edit lama supaya tidak menumpuk form tersembunyi.
    Private Sub BukaEdit(customerId As Integer)
        Dim target As New FormCustomerEdit() With {.CustomerId = customerId}
        Navigator.GetRegistered("customerEdit")?.Dispose()
        Navigator.GoWithInstance(Me, "customerEdit", target, String.Empty)
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        BukaEdit(0)
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        Dim id As Integer = SelectedCustomerId()
        If id = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        BukaEdit(id)
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim id As Integer = SelectedCustomerId()
        If id = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim nama As String = dgvCustomer.CurrentRow.Cells("full_name").Value.ToString()
        If MessageBox.Show("Hapus customer '" & nama & "'?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Exec("DELETE FROM customers WHERE customer_id=@id", P("@id", id))
            MessageBox.Show("Customer berhasil dihapus.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadGrid()
        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show("Customer masih terkait dengan data kucing atau reservasi sehingga tidak dapat dihapus.",
                            "Tidak dapat dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
