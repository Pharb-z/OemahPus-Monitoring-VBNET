Imports System.Data

Public Class FormCheckInOut
    Private Sub FormCheckInOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("checkInOut", Me)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan,
                         btnMenuAkun, btnLogout)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)

        cmbMode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMode.Items.Clear()
        cmbMode.Items.Add("Check In")
        cmbMode.Items.Add("Check Out")
        cmbMode.SelectedIndex = 0
        cmbReservasi.DropDownStyle = ComboBoxStyle.DropDownList
        LoadReservations()
        lblInfo.Text = "Check In: reservasi Dikonfirmasi belum punya catatan menginap."
    End Sub

    Private Sub LoadReservations()
        Try
            Dim table As DataTable
            If cmbMode.Text = "Check Out" Then
                table = GetTable(
                    "SELECT s.stay_id AS id, r.reservation_no, c.cat_name " &
                    "FROM stay_records s INNER JOIN reservations r ON s.reservation_id=r.reservation_id " &
                    "INNER JOIN cats c ON r.cat_id=c.cat_id WHERE s.checkout_at IS NULL " &
                    "ORDER BY s.checkin_at")
                lblInfo.Text = "Check Out: pilih kucing yang masih menginap."
            Else
                table = GetTable(
                    "SELECT r.reservation_id AS id, r.reservation_no, c.cat_name " &
                    "FROM reservations r INNER JOIN cats c ON r.cat_id=c.cat_id " &
                    "WHERE r.status='Dikonfirmasi' AND NOT EXISTS " &
                    "(SELECT 1 FROM stay_records s WHERE s.reservation_id=r.reservation_id) " &
                    "ORDER BY r.check_in_date")
                lblInfo.Text = "Check In: reservasi Dikonfirmasi belum punya catatan menginap."
            End If
            cmbReservasi.DataSource = table
            cmbReservasi.DisplayMember = "reservation_no"
            cmbReservasi.ValueMember = "id"
        Catch ex As Exception
            MessageBox.Show("Gagal memuat reservasi: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
        If cmbMode.SelectedIndex < 0 Then Return
        ClearInputs()
        LoadReservations()
    End Sub

    Private Sub ClearInputs()
        txtBerat.Clear()
        txtSuhu.Clear()
        chkParasit.Checked = False
        txtCatatan.Clear()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If cmbReservasi.SelectedValue Is Nothing Then
            MessageBox.Show("Pilih reservasi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim id As Integer = Convert.ToInt32(cmbReservasi.SelectedValue)

        Try
            Dim ok As Boolean
            If cmbMode.Text = "Check In" Then
                ok = ProcessCheckIn(id)
            Else
                ok = ProcessCheckOut(id)
            End If
            If ok Then
                ClearInputs()
                LoadReservations()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memproses: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ProcessCheckIn(stayReservationId As Integer) As Boolean
        Dim berat As Decimal
        Dim suhu As Decimal
        If Not Decimal.TryParse(txtBerat.Text.Trim(), berat) OrElse berat <= 0 Then
            MessageBox.Show("Berat harus angka lebih dari 0.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If Not Decimal.TryParse(txtSuhu.Text.Trim(), suhu) OrElse suhu <= 0 Then
            MessageBox.Show("Suhu harus angka lebih dari 0.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Exec("INSERT INTO stay_records (reservation_id, checked_in_by, weight_kg, temperature_c, " &
             "parasite_found, health_notes) VALUES (@rid, @by, @berat, @suhu, @parasit, @catatan)",
             P("@rid", stayReservationId), P("@by", UserSession.CurrentUserId),
             P("@berat", berat), P("@suhu", suhu), P("@parasit", chkParasit.Checked),
             P("@catatan", txtCatatan.Text.Trim()))
        Exec("UPDATE reservations SET status='CheckIn' WHERE reservation_id=@id",
             P("@id", stayReservationId))

        Dim cage As Object = Scalar("SELECT cage_id FROM cages WHERE status='Tersedia' ORDER BY cage_id LIMIT 1")
        If cage IsNot Nothing AndAlso cage IsNot DBNull.Value Then
            Dim cageId As Integer = Convert.ToInt32(cage)
            Exec("UPDATE cages SET status='Terisi' WHERE cage_id=@id", P("@id", cageId))
            Exec("UPDATE reservations SET cage_id=@cid WHERE reservation_id=@id",
                 P("@cid", cageId), P("@id", stayReservationId))
        End If
        MessageBox.Show("Check In berhasil.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function

    Private Function ProcessCheckOut(stayId As Integer) As Boolean
        Dim cage As Object = Scalar("SELECT cage_id FROM reservations WHERE reservation_id=" &
                                    "(SELECT reservation_id FROM stay_records WHERE stay_id=@sid)",
                                    P("@sid", stayId))
        Exec("UPDATE stay_records SET checkout_at=NOW(), checked_out_by=@by WHERE stay_id=@sid",
             P("@by", UserSession.CurrentUserId), P("@sid", stayId))
        Exec("UPDATE reservations SET status='Selesai' WHERE reservation_id=" &
             "(SELECT reservation_id FROM stay_records WHERE stay_id=@sid)", P("@sid", stayId))
        If cage IsNot Nothing AndAlso cage IsNot DBNull.Value Then
            Exec("UPDATE cages SET status='Tersedia' WHERE cage_id=@id", P("@id", Convert.ToInt32(cage)))
        End If
        MessageBox.Show("Check Out berhasil.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function
End Class
