Imports System.Data

Public Class FormRiwayatOwner

    Private Sub FormRiwayatOwner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("riwayatOwner", Me)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnLogout)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan)
        cmbJenis.DropDownStyle = ComboBoxStyle.DropDownList
        cmbJenis.Items.Clear()
        cmbJenis.Items.Add("Reservasi")
        cmbJenis.Items.Add("Pembayaran")
        cmbJenis.Items.Add("Medis")
        cmbJenis.SelectedIndex = 0
    End Sub

    Private Sub cmbJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenis.SelectedIndexChanged
        If cmbJenis.SelectedIndex < 0 Then Return
        Try
            Select Case cmbJenis.Text
                Case "Reservasi"
                    dgvRiwayat.DataSource = GetTable(
                        "SELECT r.reservation_no, c.cat_name, cu.full_name AS pemilik, r.check_in_date, " &
                        "r.check_out_date, r.status, r.total_amount FROM reservations r " &
                        "INNER JOIN cats c ON r.cat_id=c.cat_id " &
                        "INNER JOIN customers cu ON r.customer_id=cu.customer_id " &
                        "ORDER BY r.reservation_date DESC")
                Case "Pembayaran"
                    dgvRiwayat.DataSource = GetTable(
                        "SELECT p.payment_no, r.reservation_no, p.payment_type, p.method, p.amount, " &
                        "p.status, p.paid_at FROM payments p " &
                        "INNER JOIN reservations r ON p.reservation_id=r.reservation_id " &
                        "ORDER BY p.paid_at DESC")
                Case Else
                    dgvRiwayat.DataSource = GetTable(
                        "SELECT d.report_no, d.report_date, d.session, c.cat_name, d.condition_status, " &
                        "d.eating_status, d.activity_notes FROM daily_reports d " &
                        "INNER JOIN stay_records s ON d.stay_id=s.stay_id " &
                        "INNER JOIN reservations r ON s.reservation_id=r.reservation_id " &
                        "INNER JOIN cats c ON r.cat_id=c.cat_id " &
                        "ORDER BY d.report_date DESC, d.report_id DESC")
            End Select
        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvRiwayat_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvRiwayat.CellFormatting
        If e.RowIndex < 0 OrElse dgvRiwayat.Columns(e.ColumnIndex).Name <> "status" Then Return
        e.CellStyle.BackColor = ModuleStatus.BackColor(If(e.Value, "").ToString())
    End Sub
End Class
