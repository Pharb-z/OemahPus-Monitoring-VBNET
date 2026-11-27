Imports System.Windows.Forms.DataVisualization.Charting

Public Class FormDashboard
    Private isLoggingOut As Boolean = False

    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If DEBUG Then
        ModuleAccess.SelfCheck()
#End If
        Navigator.Register("dashboard", Me)
        lblUserInfo.Text = $"User: {UserSession.CurrentFullName} | Role: {UserSession.CurrentRole}"
        ApplyMenuAccess(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                        btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan,
                        btnMenuProfil, btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun,
                        btnMenuTracking)
        ' Label + visibilitas slot dipusatkan di StandardNav agar tidak duplikat.
        StandardNav.ApplyMenu(btnMenuLayanan, btnMenuCustomer, btnMenuPemeriksaanKucing,
                              btnMenuReservasi, btnMenuLaporan)
        LoadDashboardMetrics()
    End Sub

    Private Sub FormDashboard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then LoadDashboardMetrics()
    End Sub

    ' Chart config dipindah keluar InitializeComponent: designer tidak bisa parse
    ' indexer ChartAreas(0).AxisX.Title di kode yang dihasilkan designer.
    Private Sub ConfigureChart()
        chrTopLayanan.BackColor = Color.SeaShell

        chrTopLayanan.ChartAreas.Clear()
        chrTopLayanan.ChartAreas.Add(New ChartArea("Main"))
        Dim area As ChartArea = chrTopLayanan.ChartAreas(0)
        area.BackColor = Color.SeaShell
        area.AxisX.Title = "Layanan"
        area.AxisY.Title = "Jumlah"
        area.AxisX.TitleForeColor = Color.DarkOliveGreen
        area.AxisY.TitleForeColor = Color.DarkOliveGreen
        area.AxisX.LabelStyle.ForeColor = Color.DarkOliveGreen
        area.AxisY.LabelStyle.ForeColor = Color.DarkOliveGreen
        area.AxisX.LineColor = Color.Plum
        area.AxisY.LineColor = Color.Plum

        chrTopLayanan.Legends.Clear()
        chrTopLayanan.Legends.Add(New Legend("Legend"))
        chrTopLayanan.Series.Clear()
        Dim series As New Series("TopLayanan")
        series.Color = Color.MediumVioletRed
        chrTopLayanan.Series.Add(series)
    End Sub

    ' Isi dashboard berbeda per role. Data omzet hanya untuk Owner.
    Private Sub LoadDashboardMetrics()
        Try
            Select Case UserSession.CurrentRole
                Case "Owner"
                    LoadOwnerDashboard()
                Case "StafOperasional"
                    LoadStafDashboard()
                Case "StafAntarJemput"
                    LoadKurirDashboard()
                Case "Pelanggan"
                    LoadPelangganDashboard()
                Case Else
                    pnlChartBox.Visible = False
                    dgvDashboard.Visible = False
            End Select
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data dashboard: " & ex.Message, "Dashboard Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ShowMainPanel(showChart As Boolean)
        pnlChartBox.Visible = showChart
        dgvDashboard.Visible = Not showChart
    End Sub

    Private Sub LoadOwnerDashboard()
        lblCaptionTrx.Text = "RESERVASI HARI INI"
        lblTotalTrx.Text = Convert.ToInt32(Scalar(
            "SELECT COUNT(*) FROM reservations WHERE DATE(reservation_date) = CURDATE()")).ToString()

        Dim revenue As Decimal = Convert.ToDecimal(Scalar(
            "SELECT IFNULL(SUM(amount), 0) FROM payments " &
            "WHERE status = 'Valid' AND DATE(paid_at) = CURDATE()"))
        lblCaptionRevenue.Text = "PENDAPATAN VALID HARI INI"
        lblTotalRevenue.Text = "Rp " & revenue.ToString("N0")

        ShowMainPanel(True)
        ConfigureChart()
        Dim dt As DataTable = GetTable(
            "SELECT s.service_name, SUM(rd.qty) AS total_qty " &
            "FROM reservation_details rd JOIN services s ON rd.service_id = s.service_id " &
            "GROUP BY s.service_id, s.service_name ORDER BY total_qty DESC LIMIT 5")
        chrTopLayanan.DataSource = dt
        With chrTopLayanan.Series("TopLayanan")
            .XValueMember = "service_name"
            .YValueMembers = "total_qty"
            .ChartType = SeriesChartType.Column
            .IsValueShownAsLabel = True
        End With
        chrTopLayanan.Legends(0).Enabled = False
        chrTopLayanan.DataBind()
    End Sub

    Private Sub LoadStafDashboard()
        lblCaptionTrx.Text = "KUCING MENGINAP"
        lblTotalTrx.Text = Convert.ToInt32(Scalar(
            "SELECT COUNT(*) FROM stay_records WHERE checkout_at IS NULL")).ToString()
        lblCaptionRevenue.Text = "CHECK-IN HARI INI"
        lblTotalRevenue.Text = Convert.ToInt32(Scalar(
            "SELECT COUNT(*) FROM stay_records WHERE DATE(checkin_at) = CURDATE()")).ToString()

        ShowMainPanel(False)
        dgvDashboard.DataSource = GetTable(
            "SELECT c.cat_name, cu.full_name AS pemilik, s.checkin_at, " &
            "cg.cage_code, r.status FROM stay_records s " &
            "INNER JOIN reservations r ON s.reservation_id = r.reservation_id " &
            "INNER JOIN cats c ON r.cat_id = c.cat_id " &
            "INNER JOIN customers cu ON r.customer_id = cu.customer_id " &
            "LEFT JOIN cages cg ON r.cage_id = cg.cage_id " &
            "WHERE s.checkout_at IS NULL ORDER BY s.checkin_at")
    End Sub

    Private Sub LoadKurirDashboard()
        lblCaptionTrx.Text = "TUGAS HARI INI"
        lblTotalTrx.Text = Convert.ToInt32(Scalar(
            "SELECT COUNT(*) FROM deliveries WHERE assigned_to=@uid AND DATE(schedule_at)=CURDATE()",
            P("@uid", UserSession.CurrentUserId))).ToString()
        lblCaptionRevenue.Text = "SELESAI HARI INI"
        lblTotalRevenue.Text = Convert.ToInt32(Scalar(
            "SELECT COUNT(*) FROM deliveries WHERE assigned_to=@uid AND status='Selesai' " &
            "AND DATE(schedule_at)=CURDATE()", P("@uid", UserSession.CurrentUserId))).ToString()

        ShowMainPanel(False)
        dgvDashboard.DataSource = GetTable(
            "SELECT d.delivery_no, d.delivery_type, d.address, d.schedule_at, d.status " &
            "FROM deliveries d WHERE d.assigned_to=@uid AND DATE(d.schedule_at)=CURDATE() " &
            "ORDER BY d.schedule_at", P("@uid", UserSession.CurrentUserId))
    End Sub

    Private Sub LoadPelangganDashboard()
        Dim cid As Object = Scalar("SELECT customer_id FROM customers WHERE user_id=@uid",
                                   P("@uid", UserSession.CurrentUserId))
        Dim customerKey As Integer = If(cid Is Nothing OrElse cid Is DBNull.Value, 0, Convert.ToInt32(cid))

        lblCaptionTrx.Text = "KUCING SAYA"
        lblTotalTrx.Text = Convert.ToInt32(Scalar(
            "SELECT COUNT(*) FROM cats WHERE customer_id=@cid", P("@cid", customerKey))).ToString()
        lblCaptionRevenue.Text = "RESERVASI AKTIF"
        lblTotalRevenue.Text = Convert.ToInt32(Scalar(
            "SELECT COUNT(*) FROM reservations WHERE customer_id=@cid " &
            "AND status IN ('Menunggu','Dikonfirmasi','CheckIn')",
            P("@cid", customerKey))).ToString()

        ShowMainPanel(False)
        dgvDashboard.DataSource = GetTable(
            "SELECT r.reservation_no, c.cat_name, r.check_in_date, r.check_out_date, r.status " &
            "FROM reservations r INNER JOIN cats c ON r.cat_id = c.cat_id " &
            "WHERE r.customer_id=@cid ORDER BY r.reservation_date DESC LIMIT 10",
            P("@cid", customerKey))
    End Sub

    Private Sub dgvDashboard_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDashboard.CellFormatting
        If e.RowIndex < 0 OrElse dgvDashboard.Columns(e.ColumnIndex).Name <> "status" Then Return
        e.CellStyle.BackColor = ModuleStatus.BackColor(If(e.Value, "").ToString())
    End Sub

    Private Sub btnMenuDashboard_Click(sender As Object, e As EventArgs) Handles btnMenuDashboard.Click
        LoadDashboardMetrics()
    End Sub

    Private Sub btnMenuProfil_Click(sender As Object, e As EventArgs) Handles btnMenuProfil.Click
        Navigator.Go(Me, "profil", Function() New FormProfilKucing())
    End Sub

    Private Sub btnMenuReservasiPelanggan_Click(sender As Object, e As EventArgs) Handles btnMenuReservasiPelanggan.Click
        Navigator.Go(Me, "reservasiPelanggan", Function() New FormReservasiWizard())
    End Sub

    Private Sub btnMenuRiwayat_Click(sender As Object, e As EventArgs) Handles btnMenuRiwayat.Click
        Navigator.Go(Me, "riwayat", Function() New FormRiwayat())
    End Sub

    Private Sub btnMenuAkun_Click(sender As Object, e As EventArgs) Handles btnMenuAkun.Click
        Navigator.Go(Me, "akun", Function() New FormAkunSaya())
    End Sub

    Private Sub btnMenuTracking_Click(sender As Object, e As EventArgs) Handles btnMenuTracking.Click
        Navigator.Go(Me, "tracking", Function() New FormPetTracking())
    End Sub

    Private Sub btnMenuLayanan_Click(sender As Object, e As EventArgs) Handles btnMenuLayanan.Click
        StandardNav.GoLayanan(Me)
    End Sub

    Private Sub btnMenuCustomer_Click(sender As Object, e As EventArgs) Handles btnMenuCustomer.Click
        StandardNav.GoCustomer(Me)
    End Sub

    Private Sub btnMenuPemeriksaanKucing_Click(sender As Object, e As EventArgs) Handles btnMenuPemeriksaanKucing.Click
        StandardNav.GoMedis(Me)
    End Sub

    ' Reservasi hanya untuk Pelanggan; slot ini khusus kurir = Jadwal Antar Jemput.
    Private Sub btnMenuReservasi_Click(sender As Object, e As EventArgs) Handles btnMenuReservasi.Click
        StandardNav.GoReservasi(Me)
    End Sub

    Private Sub btnMenuLaporan_Click(sender As Object, e As EventArgs) Handles btnMenuLaporan.Click
        StandardNav.GoLaporan(Me)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim answer = MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer <> DialogResult.Yes Then Return

        isLoggingOut = True
        Navigator.Clear()
        FormLogin.Show()
        If Not Me.IsDisposed Then Me.Close()
    End Sub

    Private Sub FormDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not isLoggingOut Then
            isLoggingOut = True
            Application.Exit()
        End If
    End Sub
End Class
