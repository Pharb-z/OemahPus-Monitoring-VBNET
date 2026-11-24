Imports System.Data

Public Class FormRiwayatLayanan

    Private Sub FormRiwayatLayanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("riwayatLayanan", Me)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnLogout)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan)
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            dgvLaporan.DataSource = GetTable(
                "SELECT d.report_no, d.report_date, d.session, c.cat_name, d.condition_status, " &
                "d.eating_status, d.activity_notes FROM daily_reports d " &
                "INNER JOIN stay_records s ON d.stay_id=s.stay_id " &
                "INNER JOIN reservations r ON s.reservation_id=r.reservation_id " &
                "INNER JOIN cats c ON r.cat_id=c.cat_id ORDER BY d.report_date DESC, d.report_id DESC")

            dgvStay.DataSource = GetTable(
                "SELECT r.reservation_no, c.cat_name, s.checkin_at, s.checkout_at, " &
                "s.weight_kg, s.temperature_c, s.parasite_found, s.health_notes, r.status " &
                "FROM stay_records s INNER JOIN reservations r ON s.reservation_id=r.reservation_id " &
                "INNER JOIN cats c ON r.cat_id=c.cat_id ORDER BY s.checkin_at DESC")
        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvLaporan_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvLaporan.CellFormatting
        If e.RowIndex < 0 OrElse dgvLaporan.Columns(e.ColumnIndex).Name <> "condition_status" Then Return
        e.CellStyle.BackColor = ModuleStatus.BackColor(If(e.Value, "").ToString())
    End Sub

    Private Sub dgvStay_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvStay.CellFormatting
        If e.RowIndex < 0 OrElse dgvStay.Columns(e.ColumnIndex).Name <> "status" Then Return
        e.CellStyle.BackColor = ModuleStatus.BackColor(If(e.Value, "").ToString())
    End Sub
End Class
