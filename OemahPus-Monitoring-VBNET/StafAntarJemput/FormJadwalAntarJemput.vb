Imports System.Data

Public Class FormJadwalAntarJemput
    Private Sub FormJadwalAntarJemput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("jadwal", Me)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnLogout)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan)
        dtpTanggal.Value = Today
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim sql As String =
                "SELECT d.delivery_id, d.delivery_no, r.reservation_no, d.delivery_type, " &
                "d.schedule_at, d.address, d.status, c.cat_name, cu.full_name AS pemilik " &
                "FROM deliveries d INNER JOIN reservations r ON d.reservation_id=r.reservation_id " &
                "INNER JOIN cats c ON r.cat_id=c.cat_id " &
                "INNER JOIN customers cu ON r.customer_id=cu.customer_id "
            If chkSemua.Checked Then
                sql &= "WHERE d.assigned_to=@uid "
            Else
                sql &= "WHERE d.assigned_to=@uid AND DATE(d.schedule_at)=@d "
            End If
            sql &= "ORDER BY d.schedule_at"

            If chkSemua.Checked Then
                dgvJadwal.DataSource = GetTable(sql, P("@uid", UserSession.CurrentUserId))
            Else
                dgvJadwal.DataSource = GetTable(sql, P("@uid", UserSession.CurrentUserId),
                                                P("@d", dtpTanggal.Value.Date))
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat jadwal: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpTanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggal.ValueChanged
        If Not chkSemua.Checked Then LoadData()
    End Sub

    Private Sub chkSemua_CheckedChanged(sender As Object, e As EventArgs) Handles chkSemua.CheckedChanged
        dtpTanggal.Enabled = Not chkSemua.Checked
        LoadData()
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        If dgvJadwal.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih jadwal terlebih dahulu.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim id As Integer = Convert.ToInt32(dgvJadwal.CurrentRow.Cells("delivery_id").Value)
        Dim target As New FormDetailAntarJemput()
        target.DeliveryId = id
        Navigator.GoWithInstance(Me, "detailAntarJemput", target, String.Empty)
    End Sub

    Private Sub btnLihatReservasi_Click(sender As Object, e As EventArgs) Handles btnLihatReservasi.Click
        Dim target As New FormReservasi()
        target.ReadOnlyMode = True
        Navigator.GoWithInstance(Me, "reservasiView", target, String.Empty)
    End Sub

    Private Sub dgvJadwal_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvJadwal.CellFormatting
        If e.RowIndex < 0 OrElse dgvJadwal.Columns(e.ColumnIndex).Name <> "status" Then Return
        e.CellStyle.BackColor = ModuleStatus.BackColor(If(e.Value, "").ToString())
    End Sub
End Class
