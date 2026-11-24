Imports System.Data

Public Class FormProfilKucing
    Private selectedId As Integer
    Private customerId As Integer

    Private Sub FormProfilKucing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("profil", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuReservasiPelanggan,
                          btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuReservasiPelanggan,
                        btnMenuRiwayat, btnMenuAkun)

        cmbGender.Items.Clear()
        cmbGender.Items.Add("Jantan")
        cmbGender.Items.Add("Betina")
        cmbGender.DropDownStyle = ComboBoxStyle.DropDownList

        Try
            customerId = EnsureCustomerId()
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        SetInputs(False)
    End Sub

    ' Akun Pelanggan belum punya baris customers: dibuat sekali agar cats punya FK.
    Private Function EnsureCustomerId() As Integer
        Dim found As Object = Scalar(
            "SELECT customer_id FROM customers WHERE user_id=@uid",
            P("@uid", UserSession.CurrentUserId))
        If found IsNot Nothing AndAlso found IsNot DBNull.Value Then Return Convert.ToInt32(found)

        Exec("INSERT INTO customers (user_id, full_name, phone) VALUES (@uid, @nama, '-')",
             P("@uid", UserSession.CurrentUserId), P("@nama", UserSession.CurrentFullName))
        Return Convert.ToInt32(Scalar("SELECT LAST_INSERT_ID()"))
    End Function

    Private Sub LoadGrid()
        Dim table As DataTable = GetTable(
            "SELECT cat_id, cat_name, breed, gender, birth_date, fur_color, notes " &
            "FROM cats WHERE customer_id=@cid ORDER BY cat_name",
            P("@cid", customerId))
        dgvKucing.DataSource = table
        If table.Columns.Contains("cat_name") Then dgvKucing.Columns("cat_name").HeaderText = "Nama Kucing"
        If table.Columns.Contains("breed") Then dgvKucing.Columns("breed").HeaderText = "Ras"
        If table.Columns.Contains("gender") Then dgvKucing.Columns("gender").HeaderText = "Jenis Kelamin"
        If table.Columns.Contains("fur_color") Then dgvKucing.Columns("fur_color").HeaderText = "Warna Bulu"
        If table.Columns.Contains("notes") Then dgvKucing.Columns("notes").HeaderText = "Catatan"
    End Sub

    Private Sub SetInputs(enabled As Boolean)
        txtNama.Enabled = enabled
        txtRas.Enabled = enabled
        cmbGender.Enabled = enabled
        dtpLahir.Enabled = enabled
        txtWarna.Enabled = enabled
        txtCatatan.Enabled = enabled
        chkVaksin.Enabled = enabled
        btnSimpan.Enabled = enabled
    End Sub

    Private Sub ClearInputs()
        selectedId = 0
        txtNama.Clear()
        txtRas.Clear()
        cmbGender.SelectedIndex = -1
        dtpLahir.Value = Today
        txtWarna.Clear()
        txtCatatan.Clear()
        chkVaksin.Checked = False
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        ClearInputs()
        SetInputs(True)
        txtNama.Focus()
    End Sub

    Private Sub dgvKucing_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKucing.CellClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvKucing.Rows.Count Then Return
        Dim row As DataGridViewRow = dgvKucing.Rows(e.RowIndex)
        If row.Cells("cat_id").Value Is Nothing OrElse row.Cells("cat_id").Value Is DBNull.Value Then Return

        selectedId = Convert.ToInt32(row.Cells("cat_id").Value)
        txtNama.Text = If(row.Cells("cat_name").Value, "").ToString()
        txtRas.Text = If(row.Cells("breed").Value, "").ToString()
        cmbGender.Text = If(row.Cells("gender").Value, "").ToString()
        Dim lahir As Object = row.Cells("birth_date").Value
        If lahir IsNot Nothing AndAlso lahir IsNot DBNull.Value Then dtpLahir.Value = Convert.ToDateTime(lahir)
        txtWarna.Text = If(row.Cells("fur_color").Value, "").ToString()
        txtCatatan.Text = If(row.Cells("notes").Value, "").ToString()
        SetInputs(True)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama kucing wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cmbGender.SelectedIndex < 0 Then
            MessageBox.Show("Pilih jenis kelamin.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If selectedId = 0 Then
                Exec("INSERT INTO cats (customer_id, cat_name, breed, fur_color, gender, birth_date, is_vaccinated, notes) " &
                     "VALUES (@cid, @nama, @ras, @warna, @gender, @lahir, @vaksin, @catatan)",
                     P("@cid", customerId), P("@nama", txtNama.Text.Trim()), P("@ras", txtRas.Text.Trim()),
                     P("@warna", txtWarna.Text.Trim()), P("@gender", cmbGender.Text),
                     P("@lahir", dtpLahir.Value.Date), P("@vaksin", chkVaksin.Checked),
                     P("@catatan", txtCatatan.Text.Trim()))
            Else
                Exec("UPDATE cats SET cat_name=@nama, breed=@ras, fur_color=@warna, gender=@gender, " &
                     "birth_date=@lahir, is_vaccinated=@vaksin, notes=@catatan WHERE cat_id=@id",
                     P("@nama", txtNama.Text.Trim()), P("@ras", txtRas.Text.Trim()),
                     P("@warna", txtWarna.Text.Trim()), P("@gender", cmbGender.Text),
                     P("@lahir", dtpLahir.Value.Date), P("@vaksin", chkVaksin.Checked),
                     P("@catatan", txtCatatan.Text.Trim()), P("@id", selectedId))
            End If
            LoadGrid()
            ClearInputs()
            SetInputs(False)
            MessageBox.Show("Data kucing tersimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedId = 0 Then
            MessageBox.Show("Pilih kucing yang akan dihapus.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim used As Object = Scalar("SELECT COUNT(*) FROM reservations WHERE cat_id=@id", P("@id", selectedId))
        If Convert.ToInt32(used) > 0 Then
            MessageBox.Show("Kucing masih dipakai reservasi, tidak bisa dihapus.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Hapus kucing ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            Exec("DELETE FROM cats WHERE cat_id=@id", P("@id", selectedId))
            LoadGrid()
            ClearInputs()
            SetInputs(False)
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
