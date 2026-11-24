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
                        btnMenuProfil, btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)
        ApplyRoleMenuLabels()
        LoadDashboardMetrics()
    End Sub

    ' Slot sidebar lama dipakai ulang per role; RBAC aslinya tetap di ModuleAccess.
    Private Sub ApplyRoleMenuLabels()
        Select Case UserSession.CurrentRole
            Case "StafOperasional"
                btnMenuLayanan.Visible = True
                btnMenuLayanan.Text = "Riwayat Layanan"
                btnMenuLaporan.Visible = True
                btnMenuLaporan.Text = "Laporan Harian"
            Case "StafAntarJemput"
                btnMenuReservasi.Text = "Jadwal Antar Jemput"
            Case "Owner"
                btnMenuCustomer.Text = "Kandang"
                btnMenuPemeriksaanKucing.Text = "Riwayat"
        End Select
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

    ' KPI cards + Top 5 layanan (schema OmiDB, adaptasi dari dbtrial di modul Week 13)
    Private Sub LoadDashboardMetrics()
        Try
            ConfigureChart()

            lblTotalTrx.Text = Convert.ToInt32(Scalar(
                "SELECT COUNT(*) FROM reservations WHERE DATE(reservation_date) = CURDATE()"
            )).ToString()

            Dim revenue As Decimal = Convert.ToDecimal(Scalar(
                "SELECT IFNULL(SUM(amount), 0) FROM payments " &
                "WHERE status = 'Valid' AND DATE(paid_at) = CURDATE()"
            ))
            lblTotalRevenue.Text = "Rp " & revenue.ToString("N0")

            Dim sql As String =
                "SELECT s.service_name, SUM(rd.qty) AS total_qty " &
                "FROM reservation_details rd " &
                "JOIN services s ON rd.service_id = s.service_id " &
                "GROUP BY s.service_id, s.service_name " &
                "ORDER BY total_qty DESC LIMIT 5"

            Dim dt As DataTable = GetTable(sql)
            chrTopLayanan.DataSource = dt
            With chrTopLayanan.Series("TopLayanan")
                .XValueMember = "service_name"
                .YValueMembers = "total_qty"
                .ChartType = SeriesChartType.Column
                .IsValueShownAsLabel = True
            End With
            chrTopLayanan.Legends(0).Enabled = False
            chrTopLayanan.DataBind()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data dashboard: " & ex.Message, "Dashboard Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
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

    Private Sub btnMenuLayanan_Click(sender As Object, e As EventArgs) Handles btnMenuLayanan.Click
        If UserSession.CurrentRole = "StafOperasional" Then
            Navigator.Go(Me, "riwayatLayanan", Function() New FormRiwayatLayanan())
        Else
            Navigator.Go(Me, "layanan", Function() New FormDataPaketLayanan())
        End If
    End Sub

    Private Sub btnMenuCustomer_Click(sender As Object, e As EventArgs) Handles btnMenuCustomer.Click
        If UserSession.CurrentRole = "Owner" Then
            Navigator.Go(Me, "kandang", Function() New FormKandang())
        Else
            Navigator.Go(Me, "customer", Function() New FormCustomer())
        End If
    End Sub

    Private Sub btnMenuPemeriksaanKucing_Click(sender As Object, e As EventArgs) Handles btnMenuPemeriksaanKucing.Click
        If UserSession.CurrentRole = "Owner" Then
            Navigator.Go(Me, "riwayatOwner", Function() New FormRiwayatOwner())
        Else
            Navigator.Go(Me, "medis", Function() New FormMedisKucing())
        End If
    End Sub

    Private Sub btnMenuReservasi_Click(sender As Object, e As EventArgs) Handles btnMenuReservasi.Click
        If UserSession.CurrentRole = "StafAntarJemput" Then
            Navigator.Go(Me, "jadwal", Function() New FormJadwalAntarJemput())
            Return
        End If
        Dim target As FormReservasi = TryCast(Navigator.GetRegistered("reservasi"), FormReservasi)
        If target Is Nothing Then
            target = New FormReservasi()
            target.ReadOnlyMode = (UserSession.CurrentRole = "StafAntarJemput")
        End If
        Navigator.GoWithInstance(Me, "reservasi", target, String.Empty)
    End Sub

    Private Sub btnMenuLaporan_Click(sender As Object, e As EventArgs) Handles btnMenuLaporan.Click
        If UserSession.CurrentRole = "StafOperasional" Then
            Navigator.Go(Me, "dailyReport", Function() New FormDailyReport())
        Else
            Navigator.Go(Me, "laporan", Function() New FormReport())
        End If
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
