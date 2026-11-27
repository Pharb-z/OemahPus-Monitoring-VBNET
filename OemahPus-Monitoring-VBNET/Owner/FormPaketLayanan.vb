Imports MySql.Data.MySqlClient

' Daftar paket layanan. Tambah/Ubah dibuka di halaman terpisah (FormLayananEdit).
Public Class FormDataPaketLayanan

    Private Sub FormDataPaketLayanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("layanan", Me)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                              btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun, btnLogout)
        SetupGrid()
    End Sub

    Private Sub FormDataPaketLayanan_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Me.Visible Then Return
        Try
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Gagal terhubung ke database:" & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupGrid()
        ' Styling grid dipindah ke designer; di sini cukup reset kolom + generate otomatis.
        dgvLayanan.Columns.Clear()
        dgvLayanan.AutoGenerateColumns = True
    End Sub

    Private Sub LoadGrid()
        Try
            Dim kw As String = "%" & txtCari.Text.Trim() & "%"
            Dim dt As DataTable = GetTable(
                "SELECT service_id, service_name, " &
                "       CASE WHEN is_active = 1 THEN 'Aktif' ELSE 'Nonaktif' END AS status_text, " &
                "       service_type, price, unit " &
                "FROM services WHERE service_name LIKE @k OR service_type LIKE @k " &
                "ORDER BY service_id DESC", P("@k", kw))
            dgvLayanan.DataSource = dt

            dgvLayanan.Columns("service_id").HeaderText = "ID"
            dgvLayanan.Columns("service_name").HeaderText = "Nama Layanan"
            dgvLayanan.Columns("status_text").HeaderText = "Status"
            dgvLayanan.Columns("service_type").HeaderText = "Jenis Layanan"
            dgvLayanan.Columns("price").HeaderText = "Harga"
            dgvLayanan.Columns("unit").HeaderText = "Satuan"
            dgvLayanan.Columns("price").DefaultCellStyle.Format = "N0"
            dgvLayanan.Columns("price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvLayanan.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        LoadGrid()
    End Sub

    Private Function SelectedServiceId() As Integer
        If dgvLayanan.CurrentRow Is Nothing Then Return 0
        Dim v As Object = dgvLayanan.CurrentRow.Cells("service_id").Value
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        Return Convert.ToInt32(v)
    End Function

    ' Buang instance edit lama supaya tidak menumpuk form tersembunyi.
    Private Sub BukaEdit(serviceId As Integer)
        Dim target As New FormLayananEdit() With {.ServiceId = serviceId}
        Navigator.GetRegistered("layananEdit")?.Dispose()
        Navigator.GoWithInstance(Me, "layananEdit", target, String.Empty)
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        BukaEdit(0)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim id As Integer = SelectedServiceId()
        If id = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        BukaEdit(id)
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim id As Integer = SelectedServiceId()
        If id = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim nama As String = dgvLayanan.CurrentRow.Cells("service_name").Value.ToString()
        If MessageBox.Show("Hapus layanan '" & nama & "'?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Exec("DELETE FROM services WHERE service_id=@id", P("@id", id))
            MessageBox.Show("Data layanan berhasil dihapus.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadGrid()
        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show("Layanan sudah dipakai pada reservasi sehingga tidak dapat dihapus." & vbCrLf &
                            "Ubah Status menjadi 'Nonaktif' lewat tombol Ubah.",
                            "Tidak dapat dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class