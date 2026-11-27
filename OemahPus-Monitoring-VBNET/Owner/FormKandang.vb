Imports MySql.Data.MySqlClient

' Daftar kandang. Tambah/Ubah dibuka di halaman terpisah (FormKandangEdit).
Public Class FormKandang

    Private Sub FormKandang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("kandang", Me)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                              btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun, btnLogout)
        LoadData()
    End Sub

    Private Sub FormKandang_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Visible Then Return
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim kw As String = "%" & txtCari.Text.Trim() & "%"
            Dim dt As DataTable = GetTable(
                "SELECT cage_id, cage_code, size_cm, status FROM cages " &
                "WHERE cage_code LIKE @k OR status LIKE @k " &
                "ORDER BY cage_id", P("@k", kw))
            dgvKandang.DataSource = dt
            If dgvKandang.Columns.Contains("cage_id") Then dgvKandang.Columns("cage_id").HeaderText = "ID"
            If dgvKandang.Columns.Contains("cage_code") Then dgvKandang.Columns("cage_code").HeaderText = "Kode Kandang"
            If dgvKandang.Columns.Contains("size_cm") Then dgvKandang.Columns("size_cm").HeaderText = "Ukuran (cm)"
            If dgvKandang.Columns.Contains("status") Then dgvKandang.Columns("status").HeaderText = "Status"
            dgvKandang.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data kandang: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        LoadData()
    End Sub

    Private Function SelectedKandangId() As Integer
        If dgvKandang.CurrentRow Is Nothing Then Return 0
        Dim v As Object = dgvKandang.CurrentRow.Cells("cage_id").Value
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        Return Convert.ToInt32(v)
    End Function

    ' Buang instance edit lama supaya tidak menumpuk form tersembunyi.
    Private Sub BukaEdit(kandangId As Integer)
        Dim target As New FormKandangEdit() With {.KandangId = kandangId}
        Navigator.GetRegistered("kandangEdit")?.Dispose()
        Navigator.GoWithInstance(Me, "kandangEdit", target, String.Empty)
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        BukaEdit(0)
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        Dim id As Integer = SelectedKandangId()
        If id = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        BukaEdit(id)
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim id As Integer = SelectedKandangId()
        If id = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim kode As String = dgvKandang.CurrentRow.Cells("cage_code").Value.ToString()
        If MessageBox.Show("Hapus kandang '" & kode & "'?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Exec("DELETE FROM cages WHERE cage_id=@id", P("@id", id))
            MessageBox.Show("Data kandang berhasil dihapus.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show("Kandang sudah dipakai pada reservasi sehingga tidak dapat dihapus.",
                            "Tidak dapat dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
