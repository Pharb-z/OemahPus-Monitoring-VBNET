Imports System.Data

Public Class FormDailyReport
    Private selectedStayId As Integer
    Private selectedCat As String = String.Empty

    Private Sub FormDailyReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("dailyReport", Me)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnLogout)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan)
        dtpTanggal.Value = Today
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            dgvAktif.DataSource = GetTable(
                "SELECT s.stay_id, r.reservation_no, c.cat_name, cu.full_name AS pemilik, " &
                "s.checkin_at, s.weight_kg, s.temperature_c, s.health_notes " &
                "FROM stay_records s " &
                "INNER JOIN reservations r ON s.reservation_id = r.reservation_id " &
                "INNER JOIN cats c ON r.cat_id = c.cat_id " &
                "INNER JOIN customers cu ON r.customer_id = cu.customer_id " &
                "WHERE s.checkout_at IS NULL AND DATE(s.checkin_at)=@d " &
                "ORDER BY s.checkin_at",
                P("@d", dtpTanggal.Value.Date))
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpTanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggal.ValueChanged
        LoadData()
    End Sub

    Private Sub dgvAktif_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAktif.CellClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvAktif.Rows.Count Then Return
        Dim row As DataGridViewRow = dgvAktif.Rows(e.RowIndex)
        If row.Cells("stay_id").Value Is Nothing OrElse row.Cells("stay_id").Value Is DBNull.Value Then Return
        selectedStayId = Convert.ToInt32(row.Cells("stay_id").Value)
        selectedCat = Convert.ToString(row.Cells("cat_name").Value)
    End Sub

    Private Sub btnBuatLaporan_Click(sender As Object, e As EventArgs) Handles btnBuatLaporan.Click
        If selectedStayId = 0 Then
            MessageBox.Show("Pilih kucing yang dititipkan.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim target As New FormBuatLaporan()
        target.StayId = selectedStayId
        target.CatName = selectedCat
        Navigator.GoWithInstance(Me, "buatLaporan", target, String.Empty)
    End Sub

    Private Sub btnCheckInOut_Click(sender As Object, e As EventArgs) Handles btnCheckInOut.Click
        Navigator.Go(Me, "checkInOut", Function() New FormCheckInOut())
    End Sub

    Private Sub btnRiwayat_Click(sender As Object, e As EventArgs) Handles btnRiwayat.Click
        Navigator.Go(Me, "riwayatLayanan", Function() New FormRiwayatLayanan())
    End Sub
End Class
