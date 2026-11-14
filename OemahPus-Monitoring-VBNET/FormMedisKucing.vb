
Imports MySql.Data.MySqlClient

Public Class FormMedisKucing

    Private ReadOnly ep As New ErrorProvider()
    Private selectedId As Integer
    Private initDone As Boolean

    Private Sub FormMedisKucing_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        ep.ContainerControl = Me

        Navigator.Register("medis", Me)

        ConfigureGrid()
        ConfigureComboBox()

        LoadCats()
        LoadGrid()
        ClearForm()

    End Sub

    Private Sub FormMedisKucing_VisibleChanged(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.VisibleChanged

        If Not Visible OrElse Not initDone Then Return

        LoadCats()
        LoadGrid()

    End Sub

    ' =========================
    ' KONFIGURASI KOMPONEN
    ' =========================

    Private Sub ConfigureGrid()

        With dgvPemeriksaan

            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill

        End With

    End Sub

    Private Sub ConfigureComboBox()

        With cmbTemuanParasit

            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Clear()
            .Items.Add("Belum Diperiksa")
            .Items.Add("Tidak Ditemukan")
            .Items.Add("Ditemukan")
            .SelectedIndex = -1

        End With

    End Sub

    ' =========================
    ' LOAD DATA KUCING
    ' =========================

    Private Sub LoadCats()

        Try

            Dim table As DataTable = GetTable(
            "SELECT c.cat_id, " &
            "CONCAT(c.cat_name, ' - ', cu.full_name) AS cat_display " &
            "FROM cats c " &
            "INNER JOIN customers cu " &
            "ON c.customer_id = cu.customer_id " &
            "WHERE NOT EXISTS (" &
                "SELECT 1 FROM cat_examinations ce " &
                "WHERE ce.cat_id = c.cat_id" &
            ") " &
            "ORDER BY c.cat_name ASC"
        )

            cmbNamaKucing.DataSource = Nothing
            cmbNamaKucing.DataSource = table
            cmbNamaKucing.DisplayMember = "cat_display"
            cmbNamaKucing.ValueMember = "cat_id"
            cmbNamaKucing.SelectedIndex = -1

        Catch ex As Exception

            ShowGeneralError(ex)

        End Try

    End Sub

    ' =========================
    ' LOAD DATA PEMERIKSAAN
    ' =========================

    Private Sub LoadGrid()

        Try

            Dim keyword As String =
                "%" & txtCari.Text.Trim() & "%"

            Dim table As DataTable = GetTable(
                "SELECT ce.examination_id, ce.cat_id, " &
                "c.cat_name, cu.full_name AS owner_name, " &
                "u.username AS examiner, " &
                "ce.examination_date, ce.weight, " &
                "ce.body_temperature, ce.parasite_finding, " &
                "ce.health_notes " &
                "FROM cat_examinations ce " &
                "INNER JOIN cats c ON ce.cat_id = c.cat_id " &
                "INNER JOIN customers cu ON c.customer_id = cu.customer_id " &
                "INNER JOIN users u ON ce.examined_by = u.user_id " &
                "WHERE c.cat_name LIKE @keyword " &
                "OR cu.full_name LIKE @keyword " &
                "OR u.username LIKE @keyword " &
                "OR ce.parasite_finding LIKE @keyword " &
                "OR ce.health_notes LIKE @keyword " &
                "ORDER BY ce.examination_date DESC",
                P("@keyword", keyword)
            )

            dgvPemeriksaan.DataSource = table

            SetHeader("examination_id", "ID")
            SetHeader("cat_id", "ID Kucing")
            SetHeader("cat_name", "Nama Kucing")
            SetHeader("owner_name", "Pemilik")
            SetHeader("examiner", "Pemeriksa")
            SetHeader("examination_date", "Tanggal Pemeriksaan")
            SetHeader("weight", "Berat (kg)")
            SetHeader("body_temperature", "Suhu (°C)")
            SetHeader("parasite_finding", "Temuan Parasit")
            SetHeader("health_notes", "Catatan Kesehatan")

            dgvPemeriksaan.Columns("examination_id").Visible = False
            dgvPemeriksaan.Columns("cat_id").Visible = False

            dgvPemeriksaan.ClearSelection()

            initDone = True

        Catch ex As Exception

            ShowGeneralError(ex)

        End Try

    End Sub

    Private Sub SetHeader(
        columnName As String,
        headerText As String
    )

        If dgvPemeriksaan.Columns.Contains(columnName) Then

            dgvPemeriksaan.Columns(columnName).HeaderText =
                headerText

        End If

    End Sub

    ' =========================
    ' MEMILIH DATA GRID
    ' =========================

    Private Sub dgvPemeriksaan_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvPemeriksaan.CellClick

        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow =
            dgvPemeriksaan.Rows(e.RowIndex)

        selectedId =
            Convert.ToInt32(row.Cells("examination_id").Value)

        cmbNamaKucing.SelectedValue =
            Convert.ToInt32(row.Cells("cat_id").Value)

        dtpTanggalPemeriksaan.Value =
            Convert.ToDateTime(row.Cells("examination_date").Value)

        txtBeratBadan.Text =
            CellText(row, "weight")

        txtSuhuTubuh.Text =
            CellText(row, "body_temperature")

        cmbTemuanParasit.SelectedItem =
            CellText(row, "parasite_finding")

        txtCatatanKesehatan.Text =
            CellText(row, "health_notes")

        ep.Clear()

        SetMode(True)

    End Sub

    Private Function CellText(
        row As DataGridViewRow,
        columnName As String
    ) As String

        If row.Cells(columnName).Value Is Nothing OrElse
            row.Cells(columnName).Value Is DBNull.Value Then

            Return String.Empty

        End If

        Return row.Cells(columnName).Value.ToString()

    End Function

    ' =========================
    ' KOSONGKAN FORM
    ' =========================

    Private Sub ClearForm()

        selectedId = 0

        cmbNamaKucing.SelectedIndex = -1

        dtpTanggalPemeriksaan.Value = DateTime.Now

        txtBeratBadan.Clear()
        txtSuhuTubuh.Clear()
        cmbTemuanParasit.SelectedIndex = -1
        txtCatatanKesehatan.Clear()

        ep.Clear()

        dgvPemeriksaan.ClearSelection()

        SetMode(False)

        cmbNamaKucing.Focus()

    End Sub

    Private Sub SetMode(edit As Boolean)

        btnSimpan.Enabled = Not edit
        btnUbah.Enabled = edit
        btnHapus.Enabled = edit

    End Sub

    ' =========================
    ' VALIDASI INPUT
    ' =========================

    Private Function ValidateInput() As Boolean

        ep.Clear()

        Dim valid As Boolean = True
        Dim weight As Decimal
        Dim temperature As Decimal

        If cmbNamaKucing.SelectedIndex < 0 Then

            ep.SetError(
                cmbNamaKucing,
                "Pilih kucing terlebih dahulu."
            )

            valid = False

        End If

        If Not Decimal.TryParse(
            txtBeratBadan.Text.Trim(),
            weight
        ) OrElse weight <= 0 Then

            ep.SetError(
                txtBeratBadan,
                "Berat badan harus berupa angka lebih dari 0."
            )

            valid = False

        End If

        If Not Decimal.TryParse(
            txtSuhuTubuh.Text.Trim(),
            temperature
        ) OrElse temperature <= 0 Then

            ep.SetError(
                txtSuhuTubuh,
                "Suhu tubuh harus berupa angka lebih dari 0."
            )

            valid = False

        End If

        If cmbTemuanParasit.SelectedIndex < 0 Then

            ep.SetError(
                cmbTemuanParasit,
                "Pilih hasil pemeriksaan parasit."
            )

            valid = False

        End If

        If dtpTanggalPemeriksaan.Value.Date >
            DateTime.Today Then

            ep.SetError(
                dtpTanggalPemeriksaan,
                "Tanggal pemeriksaan tidak boleh di masa depan."
            )

            valid = False

        End If

        If Not valid Then

            MessageBox.Show(
                "Periksa kembali data yang ditandai.",
                "Validasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

        End If

        Return valid

    End Function

    ' =========================
    ' SIMPAN DATA
    ' =========================

    Private Sub btnSimpan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSimpan.Click

        If Not ValidateInput() Then Return

        If UserSession.CurrentUserId <= 0 Then

            MessageBox.Show(
                "Informasi user yang login tidak ditemukan.",
                "Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Exec(
        "INSERT INTO cat_examinations " &
        "(cat_id, examined_by, examination_date, " &
        "weight, body_temperature, parasite_finding, health_notes) " &
        "VALUES " &
        "(@catId, @examinedBy, @examDate, " &
        "@weight, @temperature, @parasite, @notes)",
        P("@catId", Convert.ToInt32(cmbNamaKucing.SelectedValue)),
        P("@examinedBy", UserSession.CurrentUserId),
        P("@examDate", dtpTanggalPemeriksaan.Value),
        P("@weight", Decimal.Parse(txtBeratBadan.Text.Trim())),
        P("@temperature", Decimal.Parse(txtSuhuTubuh.Text.Trim())),
        P("@parasite", cmbTemuanParasit.Text),
        P("@notes", If(
            String.IsNullOrWhiteSpace(txtCatatanKesehatan.Text),
            CType(DBNull.Value, Object),
            txtCatatanKesehatan.Text.Trim()
        ))
    )

            MessageBox.Show(
        "Data pemeriksaan berhasil disimpan.",
        "Sukses",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    )

            LoadGrid()
            ClearForm()

        Catch ex As MySqlException
            ShowDatabaseError(ex)

        Catch ex As Exception
            ShowGeneralError(ex)

        End Try

    End Sub

    ' =========================
    ' UBAH DATA
    ' =========================

    Private Sub btnUbah_Click(
    sender As Object,
    e As EventArgs
) Handles btnUbah.Click

        If selectedId = 0 Then Return
        If Not ValidateInput() Then Return

        Try

            Exec(
            "UPDATE cat_examinations SET " &
            "cat_id=@catId, " &
            "examination_date=@examDate, " &
            "weight=@weight, " &
            "body_temperature=@temperature, " &
            "parasite_finding=@parasite, " &
            "health_notes=@notes " &
            "WHERE examination_id=@id",
            P("@catId", Convert.ToInt32(cmbNamaKucing.SelectedValue)),
            P("@examDate", dtpTanggalPemeriksaan.Value),
            P("@weight", Decimal.Parse(txtBeratBadan.Text.Trim())),
            P("@temperature", Decimal.Parse(txtSuhuTubuh.Text.Trim())),
            P("@parasite", cmbTemuanParasit.Text),
            P("@notes", If(
                String.IsNullOrWhiteSpace(txtCatatanKesehatan.Text),
                CType(DBNull.Value, Object),
                txtCatatanKesehatan.Text.Trim()
            )),
            P("@id", selectedId)
        )

            MessageBox.Show(
            "Data pemeriksaan berhasil diubah.",
            "Sukses",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

            LoadGrid()
            ClearForm()

        Catch ex As MySqlException
            ShowDatabaseError(ex)

        Catch ex As Exception
            ShowGeneralError(ex)

        End Try

    End Sub


    ' =========================
    ' HAPUS DATA
    ' =========================

    Private Sub btnHapus_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnHapus.Click

        If selectedId = 0 Then Return

        If MessageBox.Show(
            "Hapus riwayat pemeriksaan ini?",
            "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        ) <> DialogResult.Yes Then Return

        Try

            Exec(
                "DELETE FROM cat_examinations " &
                "WHERE examination_id=@id",
                P("@id", selectedId)
            )

            MessageBox.Show(
                "Data pemeriksaan berhasil dihapus.",
                "Sukses",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            LoadGrid()
            ClearForm()

        Catch ex As MySqlException

            ShowDatabaseError(ex)

        Catch ex As Exception

            ShowGeneralError(ex)

        End Try

    End Sub

    ' =========================
    ' TOMBOL KOSONGKAN
    ' =========================

    Private Sub btnKosongkan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnKosongkan.Click

        ClearForm()

    End Sub

    ' =========================
    ' PENCARIAN
    ' =========================

    Private Sub txtCari_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtCari.TextChanged

        If initDone Then LoadGrid()

    End Sub

    ' =========================
    ' PESAN ERROR
    ' =========================

    Private Sub ShowDatabaseError(ex As MySqlException)

        MessageBox.Show(
            "Kesalahan database (" & ex.Number & "): " &
            ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

    End Sub

    Private Sub ShowGeneralError(ex As Exception)

        MessageBox.Show(
            "Terjadi kesalahan: " & ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

    End Sub

End Class
