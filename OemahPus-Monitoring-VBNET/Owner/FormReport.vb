Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO

Public Class FormReport

    ' ===== Konstanta jenis laporan =====
    Private Const JENIS_RESERVASI As String = "Reservasi"
    Private Const JENIS_PENDAPATAN As String = "Pendapatan"
    Private Const JENIS_PEMERIKSAAN As String = "Pemeriksaan Kucing"

    ' ===== Variabel =====
    Private initDone As Boolean = False
    Private _modeFallbackPendapatan As Boolean = False

    ' ===== FORM LOAD =====
    Private Sub FormReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("laporan", Me)
        ApplyMenuAccess(btnMenuLayanan, btnMenuCustomer, btnMenuPemeriksaanKucing,
                        btnMenuReservasi, btnMenuLaporan, btnMenuDashboard)

        ConfigureComboBox()
        ConfigureGrid()
        ConfigureFilter()

        initDone = True
        LoadData()
    End Sub

    Private Sub FormReport_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Visible OrElse Not initDone Then Return
        ' Saat kembali dari form cetak, hasil filter dibiarkan apa adanya.
        If Navigator.ConsumeSuppressRefresh("laporan") Then Return
        LoadData()
    End Sub

    ' =====================
    ' KONFIGURASI KOMPONEN
    ' =====================

    Private Sub ConfigureComboBox()
        cmbJenis.Items.Clear()
        cmbJenis.Items.AddRange({JENIS_RESERVASI, JENIS_PENDAPATAN, JENIS_PEMERIKSAAN})
        cmbJenis.DropDownStyle = ComboBoxStyle.DropDownList
        cmbJenis.SelectedIndex = 0
    End Sub

    Private Sub ConfigureFilter()
        ' Default filter: bulan berjalan.
        Dim today As Date = Date.Today
        dtpDari.Value = New Date(today.Year, today.Month, 1)
        dtpSampai.Value = New Date(today.Year, today.Month, 1).AddMonths(1).AddDays(-1)
    End Sub

    Private Sub ConfigureGrid()
        With dgvLaporan
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToResizeRows = False
        End With
    End Sub

    ' =====================
    ' PROPERTI BANTU
    ' =====================

    Private ReadOnly Property JenisTerpilih As String
        Get
            Return If(cmbJenis.SelectedItem Is Nothing, JENIS_RESERVASI, cmbJenis.SelectedItem.ToString())
        End Get
    End Property

    Private ReadOnly Property TabelAktif As DataTable
        Get
            Return TryCast(dgvLaporan.DataSource, DataTable)
        End Get
    End Property

    Private ReadOnly Property AdaData As Boolean
        Get
            Dim dt As DataTable = TabelAktif
            Return dt IsNot Nothing AndAlso dt.Rows.Count > 0
        End Get
    End Property

    ' =====================
    ' LOAD DATA (DINAMIS)
    ' =====================

    Private Sub LoadData()
        If Not initDone Then Return

        Try
            Dim keyword As String = "%" & txtCari.Text.Trim() & "%"
            Dim dari As Date = dtpDari.Value.Date
            Dim sampai As Date = dtpSampai.Value.Date

            ' Validasi rentang tanggal agar query tidak menghasilkan data kosong
            ' yang membingungkan pengguna.
            If sampai < dari Then
                MessageBox.Show("Tanggal 'Sampai' tidak boleh lebih awal dari tanggal 'Dari'.",
                                "Validasi Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpSampai.Value = dari
                sampai = dari
            End If

            Select Case JenisTerpilih
                Case JENIS_RESERVASI
                    _modeFallbackPendapatan = False
                    LoadReservasiReport(keyword, dari, sampai)
                Case JENIS_PENDAPATAN
                    LoadPendapatanReport(keyword, dari, sampai)
                Case JENIS_PEMERIKSAAN
                    _modeFallbackPendapatan = False
                    LoadPemeriksaanReport(keyword, dari, sampai)
            End Select

            UpdateAggregation()

        Catch ex As MySqlException
            KosongkanGrid()
            ShowDatabaseError(ex)
        Catch ex As Exception
            KosongkanGrid()
            ShowGeneralError(ex)
        End Try
    End Sub

    Private Sub KosongkanGrid()
        dgvLaporan.DataSource = Nothing
        UpdateAggregation()
    End Sub

    ' ===== LAPORAN RESERVASI =====
    Private Sub LoadReservasiReport(keyword As String, dari As Date, sampai As Date)
        Dim dt As DataTable = GetTable(
            "SELECT r.reservation_no, cu.full_name AS customer_name, " &
            "c.cat_name, r.check_in_date, r.check_out_date, " &
            "r.total_amount, r.status " &
            "FROM reservations r " &
            "INNER JOIN customers cu ON r.customer_id = cu.customer_id " &
            "INNER JOIN cats c ON r.cat_id = c.cat_id " &
            "WHERE r.check_in_date BETWEEN @dari AND @sampai " &
            "AND (r.reservation_no LIKE @k OR cu.full_name LIKE @k " &
            "OR c.cat_name LIKE @k OR r.status LIKE @k) " &
            "ORDER BY r.check_in_date DESC, r.reservation_id DESC",
            P("@dari", dari), P("@sampai", sampai), P("@k", keyword))

        dgvLaporan.DataSource = dt
        FormatGridHeaders_Reservasi()
    End Sub

    Private Sub FormatGridHeaders_Reservasi()
        SetHeader("reservation_no", "No. Reservasi")
        SetHeader("customer_name", "Nama Customer")
        SetHeader("cat_name", "Nama Kucing")
        SetHeader("check_in_date", "Check-In")
        SetHeader("check_out_date", "Check-Out")
        SetHeader("total_amount", "Total Tagihan")
        SetHeader("status", "Status")

        FormatTanggal("check_in_date")
        FormatTanggal("check_out_date")
        FormatAngka("total_amount")
    End Sub

    ' ===== LAPORAN PENDAPATAN =====
    ' Sumber utama: tabel payments. Bila belum ada pembayaran yang tercatat
    ' pada periode tersebut, laporan memakai total_amount reservasi sebagai
    ' perkiraan pendapatan (ditandai pada kolom "Sumber").
    Private Sub LoadPendapatanReport(keyword As String, dari As Date, sampai As Date)
        Dim dtPembayaran As DataTable = GetTable(
            "SELECT p.payment_no, cu.full_name AS customer_name, " &
            "DATE(p.paid_at) AS tanggal, p.payment_type, p.amount, " &
            "p.status AS payment_status, p.method, " &
            "'Pembayaran' AS sumber " &
            "FROM payments p " &
            "INNER JOIN reservations r ON p.reservation_id = r.reservation_id " &
            "INNER JOIN customers cu ON r.customer_id = cu.customer_id " &
            "WHERE DATE(p.paid_at) BETWEEN @dari AND @sampai " &
            "AND (p.payment_no LIKE @k OR cu.full_name LIKE @k " &
            "OR p.status LIKE @k OR p.method LIKE @k) " &
            "ORDER BY p.paid_at DESC, p.payment_id DESC",
            P("@dari", dari), P("@sampai", sampai), P("@k", keyword))

        If dtPembayaran.Rows.Count > 0 Then
            _modeFallbackPendapatan = False
            dgvLaporan.DataSource = dtPembayaran
            FormatGridHeaders_Pendapatan(False)
            Return
        End If

        ' Fallback: hitung dari total_amount reservasi.
        Dim dtReservasi As DataTable = GetTable(
            "SELECT r.reservation_no AS payment_no, cu.full_name AS customer_name, " &
            "r.check_in_date AS tanggal, r.status AS payment_status, " &
            "r.total_amount AS amount, '-' AS method, " &
            "'Tagihan Reservasi' AS sumber " &
            "FROM reservations r " &
            "INNER JOIN customers cu ON r.customer_id = cu.customer_id " &
            "WHERE r.check_in_date BETWEEN @dari AND @sampai " &
            "AND (r.reservation_no LIKE @k OR cu.full_name LIKE @k OR r.status LIKE @k) " &
            "ORDER BY r.check_in_date DESC, r.reservation_id DESC",
            P("@dari", dari), P("@sampai", sampai), P("@k", keyword))

        _modeFallbackPendapatan = True
        dgvLaporan.DataSource = dtReservasi
        FormatGridHeaders_Pendapatan(True)
    End Sub

    Private Sub FormatGridHeaders_Pendapatan(isFallback As Boolean)
        SetHeader("payment_no", "No. Pembayaran")
        SetHeader("customer_name", "Nama Customer")
        SetHeader("tanggal", "Tanggal")
        SetHeader("amount", "Jumlah")
        SetHeader("payment_status", "Status")
        SetHeader("method", "Metode")
        SetHeader("sumber", "Sumber")

        If dgvLaporan.Columns.Contains("sumber") Then
            dgvLaporan.Columns("sumber").Visible = isFallback
        End If
        If dgvLaporan.Columns.Contains("payment_type") Then
            SetHeader("payment_type", "Jenis")
        End If

        FormatTanggal("tanggal")
        FormatAngka("amount")
    End Sub

    ' ===== LAPORAN PEMERIKSAAN KUCING =====
    Private Sub LoadPemeriksaanReport(keyword As String, dari As Date, sampai As Date)
        Dim dt As DataTable = GetTable(
            "SELECT c.cat_name, cu.full_name AS owner_name, " &
            "ce.examination_date, ce.weight, ce.body_temperature, " &
            "ce.parasite_finding, ce.health_notes " &
            "FROM cat_examinations ce " &
            "INNER JOIN cats c ON ce.cat_id = c.cat_id " &
            "INNER JOIN customers cu ON c.customer_id = cu.customer_id " &
            "WHERE DATE(ce.examination_date) BETWEEN @dari AND @sampai " &
            "AND (c.cat_name LIKE @k OR cu.full_name LIKE @k " &
            "OR ce.parasite_finding LIKE @k) " &
            "ORDER BY ce.examination_date DESC",
            P("@dari", dari), P("@sampai", sampai), P("@k", keyword))

        dgvLaporan.DataSource = dt
        FormatGridHeaders_Pemeriksaan()
    End Sub

    Private Sub FormatGridHeaders_Pemeriksaan()
        SetHeader("cat_name", "Nama Kucing")
        SetHeader("owner_name", "Pemilik")
        SetHeader("examination_date", "Tanggal Pemeriksaan")
        SetHeader("weight", "Berat (kg)")
        SetHeader("body_temperature", "Suhu (°C)")
        SetHeader("parasite_finding", "Temuan Parasit")
        SetHeader("health_notes", "Catatan Kesehatan")

        FormatTanggal("examination_date")
    End Sub

    ' ===== Helper format kolom =====
    Private Sub SetHeader(columnName As String, headerText As String)
        If dgvLaporan.Columns.Contains(columnName) Then
            dgvLaporan.Columns(columnName).HeaderText = headerText
        End If
    End Sub

    Private Sub FormatAngka(columnName As String)
        If dgvLaporan.Columns.Contains(columnName) Then
            dgvLaporan.Columns(columnName).DefaultCellStyle.Format = "N0"
            dgvLaporan.Columns(columnName).DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub FormatTanggal(columnName As String)
        If dgvLaporan.Columns.Contains(columnName) Then
            dgvLaporan.Columns(columnName).DefaultCellStyle.Format = "dd/MM/yyyy"
        End If
    End Sub

    ' =====================
    ' AGREGASI
    ' =====================

    Private Sub UpdateAggregation()
        Dim dt As DataTable = TabelAktif

        ' Judul kartu agregasi menyesuaikan jenis laporan.
        Select Case JenisTerpilih
            Case JENIS_PEMERIKSAAN
                lblTotalCaption.Text = "Total Pemeriksaan"
                lblRingkasanCaption.Text = "Parasit Ditemukan"
            Case JENIS_RESERVASI
                lblTotalCaption.Text = "Total Tagihan"
                lblRingkasanCaption.Text = "Reservasi Dikonfirmasi"
            Case Else
                lblTotalCaption.Text = "Total Pendapatan"
                lblRingkasanCaption.Text = "Pembayaran Valid"
        End Select

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            lblGrandTotal.Text = If(JenisTerpilih = JENIS_PEMERIKSAAN, "0", "Rp 0")
            lblJumlahReservasi.Text = "0"
            lblRingkasanNilai.Text = "0"
            lblStatus.Text = "Tidak ada data pada filter yang dipilih."
            lblStatus.ForeColor = Color.Firebrick
            SetTombolAksiAktif(False)
            Return
        End If

        Dim jumlah As Integer = dt.Rows.Count

        Select Case JenisTerpilih
            Case JENIS_PEMERIKSAAN
                lblGrandTotal.Text = jumlah.ToString("N0")
                lblRingkasanNilai.Text = CountWhere(dt, "parasite_finding", "Ditemukan").ToString("N0")

            Case JENIS_RESERVASI
                Dim total As Decimal = SumColumn(dt, "total_amount")
                lblGrandTotal.Text = "Rp " & total.ToString("N0")
                lblRingkasanNilai.Text = CountWhere(dt, "status", "Dikonfirmasi").ToString("N0")

            Case Else
                Dim total As Decimal = SumColumn(dt, "amount")
                lblGrandTotal.Text = "Rp " & total.ToString("N0")
                lblRingkasanNilai.Text = CountWhere(dt, "payment_status", "Valid").ToString("N0")
        End Select

        lblJumlahReservasi.Text = jumlah.ToString("N0")

        ' Keterangan tambahan agar pengguna tahu sumber angka.
        If JenisTerpilih = JENIS_PENDAPATAN AndAlso _modeFallbackPendapatan Then
            lblStatus.Text = "Belum ada pembayaran tercatat pada periode ini. " &
                             "Angka diambil dari total tagihan reservasi."
            lblStatus.ForeColor = Color.DarkOrange
        Else
            lblStatus.Text = "Menampilkan " & jumlah.ToString("N0") & " baris data."
            lblStatus.ForeColor = Color.DarkOliveGreen
        End If

        SetTombolAksiAktif(True)
    End Sub

    Private Sub SetTombolAksiAktif(aktif As Boolean)
        btnExport.Enabled = aktif
        btnCetak.Enabled = aktif
    End Sub

    ''' <summary>Menjumlahkan kolom numerik dengan aman terhadap DBNull.</summary>
    Private Function SumColumn(dt As DataTable, columnName As String) As Decimal
        If dt Is Nothing OrElse Not dt.Columns.Contains(columnName) Then Return 0D

        Dim total As Decimal = 0D
        For Each row As DataRow In dt.Rows
            Dim value As Object = row(columnName)
            If value Is Nothing OrElse value Is DBNull.Value Then Continue For

            If TypeOf value Is Decimal Then
                total += Convert.ToDecimal(value)
            ElseIf TypeOf value Is Double OrElse TypeOf value Is Single Then
                total += Convert.ToDecimal(value)
            ElseIf TypeOf value Is Long OrElse TypeOf value Is Integer Then
                total += Convert.ToDecimal(value)
            Else
                ' Tipe teks: coba parse dengan culture lokal lalu invariant.
                Dim hasil As Decimal
                If Decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, hasil) OrElse
                   Decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, hasil) Then
                    total += hasil
                End If
            End If
        Next
        Return total
    End Function

    ''' <summary>Menghitung baris yang kolomnya sama dengan nilai tertentu.</summary>
    Private Function CountWhere(dt As DataTable, columnName As String, nilai As String) As Integer
        If dt Is Nothing OrElse Not dt.Columns.Contains(columnName) Then Return 0

        Dim count As Integer = 0
        For Each row As DataRow In dt.Rows
            Dim value As Object = row(columnName)
            If value IsNot Nothing AndAlso value IsNot DBNull.Value AndAlso
               String.Equals(value.ToString(), nilai, StringComparison.OrdinalIgnoreCase) Then
                count += 1
            End If
        Next
        Return count
    End Function

    ' =====================
    ' EVENT HANDLERS
    ' =====================

    Private Sub cmbJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenis.SelectedIndexChanged
        If initDone Then LoadData()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If initDone Then LoadData()
    End Sub

    Private Sub dtpDari_ValueChanged(sender As Object, e As EventArgs) Handles dtpDari.ValueChanged
        If initDone Then LoadData()
    End Sub

    Private Sub dtpSampai_ValueChanged(sender As Object, e As EventArgs) Handles dtpSampai.ValueChanged
        If initDone Then LoadData()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim today As Date = Date.Today
        initDone = False
        txtCari.Clear()
        dtpDari.Value = New Date(today.Year, today.Month, 1)
        dtpSampai.Value = New Date(today.Year, today.Month, 1).AddMonths(1).AddDays(-1)
        initDone = True
        LoadData()
    End Sub

    ' =====================
    ' EXPORT
    ' =====================

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportLaporan()
    End Sub

    Private Sub ExportLaporan()
        Dim dt As DataTable = TabelAktif
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk diekspor. Ubah filter pencarian terlebih dahulu.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim jenis As String = JenisTerpilih
        Using sfd As New SaveFileDialog()
            sfd.Title = "Simpan Laporan " & jenis
            sfd.Filter = ReportExporter.BuildFilter()
            sfd.FilterIndex = 1
            sfd.AddExtension = True
            sfd.DefaultExt = "xls"
            sfd.FileName = "Laporan_" & jenis.Replace(" ", "_") & "_" &
                           Date.Now.ToString("yyyyMMdd_HHmm")

            If sfd.ShowDialog(Me) <> DialogResult.OK Then Return

            Try
                Dim info As ReportExporter.InfoLaporan = BuatInfoLaporan(jenis, dt)
                Dim berhasil As Boolean = ReportExporter.ExportByExtension(dt, sfd.FileName, info)

                If berhasil Then
                    If MessageBox.Show("Laporan berhasil disimpan ke:" & vbCrLf & sfd.FileName & vbCrLf & vbCrLf &
                                       "Buka file sekarang?", "Export Sukses",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        BukaFile(sfd.FileName)
                    End If
                Else
                    MessageBox.Show("Format file tidak dikenali.", "Export Gagal",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As UnauthorizedAccessException
                MessageBox.Show("Tidak bisa menulis ke file tersebut. Pilih lokasi lain atau tutup file yang sedang dibuka.",
                                "Export Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As IOException
                MessageBox.Show("Gagal menyimpan file: " & ex.Message,
                                "Export Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                ShowGeneralError(ex)
            End Try
        End Using
    End Sub

    Private Function BuatInfoLaporan(jenis As String, dt As DataTable) As ReportExporter.InfoLaporan
        Dim totalLabel As String = lblTotalCaption.Text
        Dim nilai As Decimal = 0D

        If JenisTerpilih = JENIS_PEMERIKSAAN Then
            nilai = dt.Rows.Count
        Else
            nilai = SumColumn(dt, If(dt.Columns.Contains("amount"), "amount", "total_amount"))
        End If

        Return New ReportExporter.InfoLaporan With {
            .Judul = "Laporan " & jenis & " - OemahPus Monitoring Information",
            .SubJudul = "Jumlah data: " & dt.Rows.Count.ToString("N0") &
                        "  |  " & lblRingkasanCaption.Text & ": " & lblRingkasanNilai.Text,
            .PeriodeText = "Periode: " & dtpDari.Value.ToString("dd/MM/yyyy") &
                           " s/d " & dtpSampai.Value.ToString("dd/MM/yyyy") &
                           If(txtCari.Text.Trim() = "", "", "  |  Kata kunci: """ & txtCari.Text.Trim() & """") &
                           If(_modeFallbackPendapatan AndAlso jenis = JENIS_PENDAPATAN,
                              "  |  Sumber: total tagihan reservasi", ""),
            .DicetakOleh = If(UserSession.CurrentFullName <> "", UserSession.CurrentFullName, UserSession.CurrentUsername),
            .DicetakPada = Date.Now,
            .TotalLabel = totalLabel,
            .TotalNilai = nilai
        }
    End Function

    Private Sub BukaFile(path As String)
        Try
            Dim psi As New Diagnostics.ProcessStartInfo(path) With {.UseShellExecute = True}
            Diagnostics.Process.Start(psi)
        Catch ex As Exception
            MessageBox.Show("File tersimpan, tetapi gagal dibuka otomatis:" & vbCrLf & ex.Message,
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    ' =====================
    ' CETAK (buka FormCetak)
    ' =====================

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Dim dt As DataTable = TabelAktif
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk dicetak. Ubah filter pencarian terlebih dahulu.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim jenis As String = JenisTerpilih

            Dim cetak As FormCetak = TryCast(Navigator.GetRegistered("cetak"), FormCetak)
            If cetak Is Nothing Then cetak = New FormCetak()

            cetak.Siapkan(dt, jenis, BuatInfoLaporan(jenis, dt))
            Navigator.GoWithInstance(Me, "cetak", cetak, "laporan")

        Catch ex As Exception
            ShowGeneralError(ex)
        End Try
    End Sub

    ' =====================
    ' NAVIGASI SIDEBAR
    ' =====================

    Private Sub btnMenuDashboard_Click(sender As Object, e As EventArgs) Handles btnMenuDashboard.Click
        Navigator.Go(Me, "dashboard", Function() New FormDashboard())
    End Sub

    Private Sub btnMenuLayanan_Click(sender As Object, e As EventArgs) Handles btnMenuLayanan.Click
        Navigator.Go(Me, "layanan", Function() New FormDataPaketLayanan())
    End Sub

    Private Sub btnMenuCustomer_Click(sender As Object, e As EventArgs) Handles btnMenuCustomer.Click
        Navigator.Go(Me, "customer", Function() New FormCustomer())
    End Sub

    Private Sub btnMenuPemeriksaanKucing_Click(sender As Object, e As EventArgs) Handles btnMenuPemeriksaanKucing.Click
        Navigator.Go(Me, "medis", Function() New FormMedisKucing())
    End Sub

    Private Sub btnMenuReservasi_Click(sender As Object, e As EventArgs) Handles btnMenuReservasi.Click
        Navigator.Go(Me, "reservasi", Function() New FormReservasi())
    End Sub

    ' btnMenuLaporan = Laporan (current form), tidak perlu aksi

    ' =====================
    ' ERROR HANDLERS
    ' =====================

    Private Sub ShowDatabaseError(ex As MySqlException)
        MessageBox.Show(
            "Kesalahan database (" & ex.Number & "): " & ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
    End Sub

    Private Sub ShowGeneralError(ex As Exception)
        MessageBox.Show(
            "Terjadi kesalahan: " & ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
    End Sub

End Class
