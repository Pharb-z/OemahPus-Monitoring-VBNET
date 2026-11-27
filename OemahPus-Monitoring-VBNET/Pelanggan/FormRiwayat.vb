Imports System.Data

Public Class FormRiwayat

    Private Sub FormRiwayat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("riwayat", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                          btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                        btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)
        LoadData()
    End Sub

    Public Sub LoadData()
        Try
            dgvReservasi.DataSource = GetTable(
                "SELECT r.reservation_no, r.check_in_date, r.check_out_date, r.status, r.total_amount " &
                "FROM reservations r INNER JOIN customers c ON r.customer_id = c.customer_id " &
                "WHERE c.user_id=@uid ORDER BY r.reservation_date DESC",
                P("@uid", UserSession.CurrentUserId))

            dgvPembayaran.DataSource = GetTable(
                "SELECT p.payment_no, r.reservation_no, p.method, p.amount, p.status, p.paid_at " &
                "FROM payments p INNER JOIN reservations r ON p.reservation_id = r.reservation_id " &
                "INNER JOIN customers c ON r.customer_id = c.customer_id " &
                "WHERE c.user_id=@uid ORDER BY p.paid_at DESC",
                P("@uid", UserSession.CurrentUserId))
        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ColorStatus(grid As DataGridView, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse grid.Columns(e.ColumnIndex).Name <> "status" Then Return
        e.CellStyle.BackColor = ModuleStatus.BackColor(If(e.Value, "").ToString())
    End Sub

    Private Sub dgvReservasi_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvReservasi.CellFormatting
        ColorStatus(dgvReservasi, e)
    End Sub

    Private Sub dgvPembayaran_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPembayaran.CellFormatting
        ColorStatus(dgvPembayaran, e)
    End Sub

    Private Sub FormRiwayat_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then LoadData()
    End Sub
End Class
