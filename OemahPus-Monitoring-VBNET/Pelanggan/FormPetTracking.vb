Imports System.Data

' Pet Tracking pelanggan: penitipan aktif + laporan harian terbaru milik user login.
' Read-only, sumber stay_records + daily_reports (schema OmiDB).
Public Class FormPetTracking

    Private Sub FormPetTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("tracking", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                          btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                        btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            dgvPenitipan.DataSource = GetTable(
                "SELECT c.cat_name, cg.cage_code, s.checkin_at, r.check_out_date, r.status " &
                "FROM stay_records s " &
                "INNER JOIN reservations r ON s.reservation_id = r.reservation_id " &
                "INNER JOIN customers cu ON r.customer_id = cu.customer_id " &
                "INNER JOIN cats c ON r.cat_id = c.cat_id " &
                "LEFT JOIN cages cg ON r.cage_id = cg.cage_id " &
                "WHERE cu.user_id=@uid AND s.checkout_at IS NULL " &
                "ORDER BY s.checkin_at DESC",
                P("@uid", UserSession.CurrentUserId))

            dgvLaporan.DataSource = GetTable(
                "SELECT dr.report_date, dr.session, c.cat_name, cg.cage_code, " &
                "dr.eating_status, dr.condition_status, dr.activity_notes " &
                "FROM daily_reports dr " &
                "INNER JOIN stay_records s ON dr.stay_id = s.stay_id " &
                "INNER JOIN reservations r ON s.reservation_id = r.reservation_id " &
                "INNER JOIN customers cu ON r.customer_id = cu.customer_id " &
                "INNER JOIN cats c ON r.cat_id = c.cat_id " &
                "LEFT JOIN cages cg ON r.cage_id = cg.cage_id " &
                "WHERE cu.user_id=@uid " &
                "ORDER BY dr.report_date DESC LIMIT 20",
                P("@uid", UserSession.CurrentUserId))
        Catch ex As Exception
            MessageBox.Show("Gagal memuat pet tracking: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
        Handles dgvPenitipan.CellFormatting, dgvLaporan.CellFormatting
        Dim grid As DataGridView = TryCast(sender, DataGridView)
        If grid Is Nothing OrElse e.RowIndex < 0 Then Return
        Dim name As String = grid.Columns(e.ColumnIndex).Name
        If name <> "status" AndAlso name <> "condition_status" Then Return
        e.CellStyle.BackColor = ModuleStatus.BackColor(If(e.Value, "").ToString())
    End Sub

    Private Sub FormPetTracking_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then LoadData()
    End Sub
End Class
