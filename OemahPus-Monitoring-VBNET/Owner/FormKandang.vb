Imports System.Data

Public Class FormKandang
    Private selectedId As Integer

    Private Sub FormKandang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("kandang", Me)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnLogout)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan)
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("Tersedia")
        cmbStatus.Items.Add("Terisi")
        cmbStatus.Items.Add("Perawatan")
        LoadData()
        ClearInputs()
    End Sub

    Private Sub LoadData()
        dgvKandang.DataSource = GetTable(
            "SELECT cage_id, cage_code, size_cm, status FROM cages ORDER BY cage_id")
    End Sub

    Private Sub ClearInputs()
        selectedId = 0
        txtKode.Clear()
        txtUkuran.Text = "100x80"
        cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub dgvKandang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKandang.CellClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvKandang.Rows.Count Then Return
        Dim row As DataGridViewRow = dgvKandang.Rows(e.RowIndex)
        If row.Cells("cage_id").Value Is Nothing OrElse row.Cells("cage_id").Value Is DBNull.Value Then Return
        selectedId = Convert.ToInt32(row.Cells("cage_id").Value)
        txtKode.Text = Convert.ToString(row.Cells("cage_code").Value)
        txtUkuran.Text = Convert.ToString(row.Cells("size_cm").Value)
        cmbStatus.Text = Convert.ToString(row.Cells("status").Value)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrWhiteSpace(txtKode.Text) Then
            MessageBox.Show("Kode kandang wajib diisi.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cmbStatus.SelectedIndex < 0 Then
            MessageBox.Show("Pilih status.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            If selectedId = 0 Then
                Exec("INSERT INTO cages (cage_code, size_cm, status) VALUES (@kode, @ukuran, @status)",
                     P("@kode", txtKode.Text.Trim()), P("@ukuran", txtUkuran.Text.Trim()),
                     P("@status", cmbStatus.Text))
            Else
                Exec("UPDATE cages SET cage_code=@kode, size_cm=@ukuran, status=@status WHERE cage_id=@id",
                     P("@kode", txtKode.Text.Trim()), P("@ukuran", txtUkuran.Text.Trim()),
                     P("@status", cmbStatus.Text), P("@id", selectedId))
            End If
            LoadData()
            ClearInputs()
            MessageBox.Show("Data kandang tersimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvKandang_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvKandang.CellFormatting
        If e.RowIndex < 0 OrElse dgvKandang.Columns(e.ColumnIndex).Name <> "status" Then Return
        e.CellStyle.BackColor = ModuleStatus.BackColor(If(e.Value, "").ToString())
    End Sub
End Class
