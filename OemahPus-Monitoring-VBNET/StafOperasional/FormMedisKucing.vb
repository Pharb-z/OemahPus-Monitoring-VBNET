Imports MySql.Data.MySqlClient

' Daftar pemeriksaan kucing. Tambah/Ubah dibuka di halaman terpisah (FormMedisEdit).
Public Class FormMedisKucing

    Private Sub FormMedisKucing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("medis", Me)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                              btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun, btnLogout)
        LoadGrid()
    End Sub

    Private Sub FormMedisKucing_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Visible Then Return
        LoadGrid()
    End Sub

    Private Sub LoadGrid()
        Try
            Dim keyword As String = "%" & txtCari.Text.Trim() & "%"
            Dim dt As DataTable = GetTable(
                "SELECT ce.examination_id, ce.cat_id, c.cat_name, cu.full_name AS owner_name, " &
                "u.username AS examiner, ce.examination_date, ce.weight, ce.body_temperature, " &
                "ce.parasite_finding, ce.health_notes " &
                "FROM cat_examinations ce " &
                "INNER JOIN cats c ON ce.cat_id = c.cat_id " &
                "INNER JOIN customers cu ON c.customer_id = cu.customer_id " &
                "INNER JOIN users u ON ce.examined_by = u.user_id " &
                "WHERE c.cat_name LIKE @keyword OR cu.full_name LIKE @keyword OR u.username LIKE @keyword " &
                "OR ce.parasite_finding LIKE @keyword OR ce.health_notes LIKE @keyword " &
                "ORDER BY ce.examination_date DESC", P("@keyword", keyword))
            dgvPemeriksaan.DataSource = dt

            SetHeader("examination_id", "ID")
            SetHeader("cat_id", "ID Kucing")
            SetHeader("cat_name", "Nama Kucing")
            SetHeader("owner_name", "Pemilik")
            SetHeader("examiner", "Pemeriksa")
            SetHeader("examination_date", "Tanggal Pemeriksaan")
            SetHeader("weight", "Berat (kg)")
            SetHeader("body_temperature", "Suhu (°C)")
            SetHeader("parasite_finding", "Temuan Parasit")
            SetHeader("health_notes", "Catatan Kesehatan")

            dgvPemeriksaan.Columns("examination_id").Visible = False
            dgvPemeriksaan.Columns("cat_id").Visible = False
            dgvPemeriksaan.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pemeriksaan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetHeader(columnName As String, headerText As String)
        If dgvPemeriksaan.Columns.Contains(columnName) Then
            dgvPemeriksaan.Columns(columnName).HeaderText = headerText
        End If
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        LoadGrid()
    End Sub

    Private Function SelectedExamId() As Integer
        If dgvPemeriksaan.CurrentRow Is Nothing Then Return 0
        Dim v As Object = dgvPemeriksaan.CurrentRow.Cells("examination_id").Value
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        Return Convert.ToInt32(v)
    End Function

    ' Buang instance edit lama supaya tidak menumpuk form tersembunyi.
    Private Sub BukaEdit(examId As Integer)
        Dim target As New FormMedisEdit() With {.ExamId = examId}
        Navigator.GetRegistered("medisEdit")?.Dispose()
        Navigator.GoWithInstance(Me, "medisEdit", target, String.Empty)
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        BukaEdit(0)
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        Dim id As Integer = SelectedExamId()
        If id = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        BukaEdit(id)
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim id As Integer = SelectedExamId()
        If id = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Hapus riwayat pemeriksaan ini?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Exec("DELETE FROM cat_examinations WHERE examination_id=@id", P("@id", id))
            MessageBox.Show("Data pemeriksaan berhasil dihapus.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
