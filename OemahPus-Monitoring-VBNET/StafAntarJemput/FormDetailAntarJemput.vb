Imports System.Data

Public Class FormDetailAntarJemput
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property DeliveryId As Integer

    Private Sub FormDetailAntarJemput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("detailAntarJemput", Me)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnLogout)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan)

        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("Dijadwalkan")
        cmbStatus.Items.Add("Dalam Perjalanan")
        cmbStatus.Items.Add("Selesai")
        cmbStatus.Items.Add("Dibatalkan")

        txtResNo.ReadOnly = True
        txtJenis.ReadOnly = True
        txtAlamat.ReadOnly = True
        txtJadwal.ReadOnly = True
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim table As DataTable = GetTable(
            "SELECT d.delivery_no, d.delivery_type, d.schedule_at, d.address, d.status, r.reservation_no " &
            "FROM deliveries d INNER JOIN reservations r ON d.reservation_id=r.reservation_id " &
            "WHERE d.delivery_id=@id", P("@id", DeliveryId))
        If table.Rows.Count = 0 Then
            MessageBox.Show("Data pengiriman tidak ditemukan.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim row As DataRow = table.Rows(0)
        txtResNo.Text = Convert.ToString(row("reservation_no"))
        txtJenis.Text = Convert.ToString(row("delivery_type"))
        txtAlamat.Text = Convert.ToString(row("address"))
        txtJadwal.Text = Convert.ToDateTime(row("schedule_at")).ToString("dd-MM-yyyy HH:mm")
        cmbStatus.Text = Convert.ToString(row("status"))
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If cmbStatus.SelectedIndex < 0 Then
            MessageBox.Show("Pilih status.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            If cmbStatus.Text = "Selesai" Then
                Exec("UPDATE deliveries SET status=@s, completed_at=NOW() WHERE delivery_id=@id",
                     P("@s", cmbStatus.Text), P("@id", DeliveryId))
            Else
                Exec("UPDATE deliveries SET status=@s, completed_at=NULL WHERE delivery_id=@id",
                     P("@s", cmbStatus.Text), P("@id", DeliveryId))
            End If
            MessageBox.Show("Status tersimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan status: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
