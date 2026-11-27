Imports System.Data

' Daftar profil kucing. Tambah/Ubah dibuka di halaman terpisah (FormKucingEdit).
Public Class FormProfilKucing
    Private customerId As Integer

    Private Sub FormProfilKucing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("profil", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                          btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                        btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)
        dgvKucing.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Try
            customerId = CustomerService.EnsureCustomerId()
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormProfilKucing_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Me.Visible OrElse customerId = 0 Then Return
        Try
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadGrid()
        Dim table As DataTable = GetTable(
            "SELECT cat_id, cat_name, breed, gender, birth_date, fur_color, notes " &
            "FROM cats WHERE customer_id=@cid ORDER BY cat_name",
            P("@cid", customerId))
        dgvKucing.DataSource = table
        If table.Columns.Contains("cat_name") Then dgvKucing.Columns("cat_name").HeaderText = "Nama Kucing"
        If table.Columns.Contains("breed") Then dgvKucing.Columns("breed").HeaderText = "Ras"
        If table.Columns.Contains("gender") Then dgvKucing.Columns("gender").HeaderText = "Jenis Kelamin"
        If table.Columns.Contains("birth_date") Then dgvKucing.Columns("birth_date").HeaderText = "Tanggal Lahir"
        If table.Columns.Contains("fur_color") Then dgvKucing.Columns("fur_color").HeaderText = "Warna Bulu"
        If table.Columns.Contains("notes") Then dgvKucing.Columns("notes").HeaderText = "Catatan"
        dgvKucing.ClearSelection()
    End Sub

    Private Function SelectedCatId() As Integer
        If dgvKucing.CurrentRow Is Nothing Then Return 0
        Dim v As Object = dgvKucing.CurrentRow.Cells("cat_id").Value
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        Return Convert.ToInt32(v)
    End Function

    ' Buang instance edit lama supaya tidak menumpuk form tersembunyi.
    Private Sub BukaEdit(catId As Integer)
        Dim target As New FormKucingEdit() With {.CatId = catId}
        Navigator.GetRegistered("kucingEdit")?.Dispose()
        Navigator.GoWithInstance(Me, "kucingEdit", target, String.Empty)
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        BukaEdit(0)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim id As Integer = SelectedCatId()
        If id = 0 Then
            MessageBox.Show("Pilih kucing yang akan diubah.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        BukaEdit(id)
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim id As Integer = SelectedCatId()
        If id = 0 Then
            MessageBox.Show("Pilih kucing yang akan dihapus.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim used As Object = Scalar("SELECT COUNT(*) FROM reservations WHERE cat_id=@id", P("@id", id))
        If Convert.ToInt32(used) > 0 Then
            MessageBox.Show("Kucing masih dipakai reservasi, tidak bisa dihapus.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Hapus kucing ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            Exec("DELETE FROM cats WHERE cat_id=@id AND customer_id=@cid",
                 P("@id", id), P("@cid", customerId))
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class