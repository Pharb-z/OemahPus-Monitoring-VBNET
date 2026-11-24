Imports System.Data
Imports MySql.Data.MySqlClient

Public Class FormReservasi

    ' StafAntarJemput hanya melihat jadwal reservasi.
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property ReadOnlyMode As Boolean = False

    ' Menyimpan status apakah form sedang dalam mode tambah
    Private modeTambah As Boolean = False

    ' =========================
    ' FORM LOAD
    ' =========================

    Private Sub FormReservasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Navigator.Register("reservasi", Me)
        ApplyMenuAccess(btnMenuLayanan, btnMenuCustomer, btnMenuPemeriksaanKucing,
                        btnMenuReservasi, btnMenuLaporan, btnMenuDashboard)

        btnTambah.Enabled = Not ReadOnlyMode
        SetInputEnabled(False)

        txtIdReservasi.ReadOnly = True
        txtNamaPemilik.ReadOnly = True
        txtLamaInap.ReadOnly = True

        cmbNamaKucing.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList

        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("Menunggu")
        cmbStatus.Items.Add("Dikonfirmasi")
        cmbStatus.Items.Add("Ditolak")

        LoadCats()
        LoadGrid()

    End Sub

    ' =========================
    ' MENGATUR INPUT FORM
    ' =========================
    Private Sub SetInputEnabled(status As Boolean)

        Dim enabled As Boolean = status AndAlso Not ReadOnlyMode
        cmbNamaKucing.Enabled = enabled
        cmbStatus.Enabled = enabled
        dtpCheckIn.Enabled = enabled
        dtpCheckOut.Enabled = enabled
        btnSimpan.Enabled = enabled

    End Sub

    ' =========================
    ' MEMBUAT NOMOR RESERVASI
    ' =========================
    Private Function GenerateReservationNo() As String

        Return "RSV" & DateTime.Now.ToString("yyyyMMddHHmmssfff")

    End Function

    ' =========================
    ' LOAD DATA KUCING
    ' =========================
    Private Sub LoadCats()

        Try
            Dim table As DataTable = GetTable(
                "SELECT c.cat_id, c.customer_id, " &
                "c.cat_name, cu.full_name, " &
                "CONCAT(c.cat_name, ' - ', cu.full_name) AS cat_display " &
                "FROM cats c " &
                "INNER JOIN customers cu " &
                "ON c.customer_id = cu.customer_id " &
                "ORDER BY c.cat_name ASC"
            )

            cmbNamaKucing.DataSource = Nothing
            cmbNamaKucing.DataSource = table
            cmbNamaKucing.DisplayMember = "cat_display"
            cmbNamaKucing.ValueMember = "cat_id"
            cmbNamaKucing.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show(
                "Gagal memuat data kucing: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

    ' =========================
    ' KETIKA KUCING DIPILIH
    ' =========================
    Private Sub cmbNamaKucing_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbNamaKucing.SelectedIndexChanged

        If cmbNamaKucing.SelectedItem Is Nothing Then
            txtNamaPemilik.Clear()
            Return
        End If

        Dim row As DataRowView =
            TryCast(cmbNamaKucing.SelectedItem, DataRowView)

        If row IsNot Nothing Then
            txtNamaPemilik.Text = row("full_name").ToString()
        End If

    End Sub

    ' =========================
    ' HITUNG LAMA INAP
    ' =========================
    Private Sub HitungLamaInap()

        Dim lama As Integer =
            DateDiff(
                DateInterval.Day,
                dtpCheckIn.Value.Date,
                dtpCheckOut.Value.Date
            )

        txtLamaInap.Text = Math.Max(0, lama).ToString()

    End Sub

    Private Sub dtpCheckIn_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles dtpCheckIn.ValueChanged

        HitungLamaInap()

    End Sub

    Private Sub dtpCheckOut_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles dtpCheckOut.ValueChanged

        HitungLamaInap()

    End Sub

    ' =========================
    ' TOMBOL TAMBAH
    ' =========================
    Private Sub btnTambah_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnTambah.Click

        modeTambah = True

        txtIdReservasi.Text = GenerateReservationNo()

        cmbNamaKucing.SelectedIndex = -1
        txtNamaPemilik.Clear()
        txtLamaInap.Clear()

        dtpCheckIn.Value = Date.Today
        dtpCheckOut.Value = Date.Today.AddDays(1)

        cmbStatus.SelectedItem = "Menunggu"

        SetInputEnabled(True)

        cmbNamaKucing.Focus()

    End Sub

    ' =========================
    ' VALIDASI INPUT
    ' =========================
    Private Function ValidateInput() As Boolean

        If Not modeTambah Then
            MessageBox.Show("Klik tombol Tambah terlebih dahulu.")
            Return False
        End If

        If cmbNamaKucing.SelectedIndex = -1 Then
            MessageBox.Show("Silakan pilih nama kucing.")
            cmbNamaKucing.Focus()
            Return False
        End If

        If cmbStatus.SelectedIndex = -1 Then
            MessageBox.Show("Silakan pilih status reservasi.")
            cmbStatus.Focus()
            Return False
        End If

        If dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date Then
            MessageBox.Show("Tanggal Check-Out harus setelah tanggal Check-In.")
            Return False
        End If

        If UserSession.CurrentUserId <= 0 Then
            MessageBox.Show("Data pengguna yang login tidak valid.")
            Return False
        End If

        Return True

    End Function

    ' =========================
    ' CEK BENTROK RESERVASI
    ' =========================
    Private Function IsReservationConflict(
        catId As Integer,
        checkIn As Date,
        checkOut As Date
    ) As Boolean

        Dim jumlah As Object = Scalar(
            "SELECT COUNT(*) FROM reservations " &
            "WHERE cat_id = @catId " &
            "AND status NOT IN ('Ditolak', 'Dibatalkan') " &
            "AND check_in_date < @checkOut " &
            "AND check_out_date > @checkIn",
            P("@catId", catId),
            P("@checkIn", checkIn),
            P("@checkOut", checkOut)
        )

        Return Convert.ToInt32(jumlah) > 0

    End Function

    ' =========================
    ' TOMBOL SIMPAN
    ' =========================
    Private Sub btnSimpan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSimpan.Click

        If Not ValidateInput() Then Return

        Try
            Dim catId As Integer =
                Convert.ToInt32(cmbNamaKucing.SelectedValue)

            Dim row As DataRowView =
                CType(cmbNamaKucing.SelectedItem, DataRowView)

            Dim customerId As Integer =
                Convert.ToInt32(row("customer_id"))

            Dim checkIn As Date = dtpCheckIn.Value.Date
            Dim checkOut As Date = dtpCheckOut.Value.Date

            ' Cek apakah kucing sudah memiliki reservasi
            If IsReservationConflict(catId, checkIn, checkOut) Then

                MessageBox.Show(
                    "Kucing ini sudah memiliki reservasi pada tanggal tersebut.",
                    "Reservasi Bertabrakan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            ' Simpan reservasi ke database

            Exec(
        "INSERT INTO reservations " &
        "(reservation_no, customer_id, cat_id, created_by, " &
        "check_in_date, check_out_date, status) " &
        "VALUES " &
        "(@reservationNo, @customerId, @catId, @createdBy, " &
        "@checkIn, @checkOut, @status)",
        P("@reservationNo", txtIdReservasi.Text.Trim()),
        P("@customerId", customerId),
        P("@catId", catId),
        P("@createdBy", UserSession.CurrentUserId),
        P("@checkIn", checkIn),
        P("@checkOut", checkOut),
        P("@status", cmbStatus.Text)
    )

            ' Muat ulang DataGridView
            LoadGrid()

            ' Kembalikan form ke kondisi awal
            modeTambah = False
            SetInputEnabled(False)

            MessageBox.Show("Reservasi berhasil disimpan!", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MySqlException
            MessageBox.Show("Gagal menyimpan reservasi: " & ex.Message,
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    ' =========================
    ' LOAD DATA RESERVASI
    ' =========================
    Private Sub LoadGrid()

        Try
            Dim table As DataTable = GetTable(
                "SELECT r.reservation_id, " &
                "r.reservation_no AS `ID Reservasi`, " &
                "c.cat_name AS `Nama Kucing`, " &
                "cu.full_name AS `Nama Pemilik`, " &
                "r.check_in_date AS `Check-In`, " &
                "r.check_out_date AS `Check-Out`, " &
                "r.status AS `Status` " &
                "FROM reservations r " &
                "INNER JOIN cats c ON r.cat_id = c.cat_id " &
                "INNER JOIN customers cu ON r.customer_id = cu.customer_id " &
                "ORDER BY r.reservation_id DESC"
            )

            dgvReservasi.DataSource = table

            dgvReservasi.Columns("reservation_id").Visible = False

            dgvReservasi.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill

            dgvReservasi.ReadOnly = True
            dgvReservasi.AllowUserToAddRows = False
            dgvReservasi.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect

        Catch ex As Exception

            MessageBox.Show(
                "Gagal memuat data reservasi: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    ' =========================
    ' NAVIGASI SIDEBAR
    ' =========================
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

    Private Sub btnMenuLaporan_Click(sender As Object, e As EventArgs) Handles btnMenuLaporan.Click
        Navigator.Go(Me, "laporan", Function() New FormReport())
    End Sub

End Class