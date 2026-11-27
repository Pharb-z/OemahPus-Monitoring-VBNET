Imports System.Data

Public Class FormBuatLaporan
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property StayId As Integer

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property CatName As String = String.Empty

    Private currentNo As String = String.Empty

    Private Sub FormBuatLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("buatLaporan", Me)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan,
                         btnMenuAkun, btnLogout)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)

        cmbSesi.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSesi.Items.Clear()
        cmbSesi.Items.Add("Pagi")
        cmbSesi.Items.Add("Sore")
        cmbSesi.SelectedIndex = 0
        cmbKondisi.DropDownStyle = ComboBoxStyle.DropDownList
        cmbKondisi.Items.Clear()
        cmbKondisi.Items.Add("Sehat")
        cmbKondisi.Items.Add("Perlu Perhatian")
        cmbKondisi.Items.Add("Sakit")
        cmbKondisi.SelectedIndex = 0

        dtpTanggal.Value = Today
        lblKucing.Text = "Kucing: " & If(String.IsNullOrWhiteSpace(CatName), "-", CatName)
        RefreshNo()
    End Sub

    Private Sub RefreshNo()
        Try
            currentNo = DocNumber.NextNo("LRP")
            lblNo.Text = "No. Laporan: " & currentNo
        Catch ex As Exception
            currentNo = String.Empty
            lblNo.Text = "No. Laporan: - (" & ex.Message & ")"
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If StayId = 0 Then
            MessageBox.Show("Tidak ada kucing yang dipilih.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            If String.IsNullOrWhiteSpace(currentNo) Then currentNo = DocNumber.NextNo("LRP")
            Dim no As String = currentNo
            Exec("INSERT INTO daily_reports (report_no, stay_id, reported_by, report_date, session, " &
                 "condition_status, eating_status, activity_notes) " &
                 "VALUES (@no, @stay, @by, @date, @sesi, @kondisi, @makan, @catatan)",
                 P("@no", no), P("@stay", StayId), P("@by", UserSession.CurrentUserId),
                 P("@date", dtpTanggal.Value.Date), P("@sesi", cmbSesi.Text),
                 P("@kondisi", cmbKondisi.Text), P("@makan", txtMakan.Text.Trim()),
                 P("@catatan", txtAktivitas.Text.Trim()))
            MessageBox.Show("Laporan " & no & " tersimpan.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMakan.Clear()
            txtAktivitas.Clear()
            RefreshNo()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan laporan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Navigator.Go(Me, "dailyReport", Function() New FormDailyReport())
    End Sub
End Class
