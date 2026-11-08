Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class FormDataPaketLayanan

    ' ===== Variabel =====
    Private ReadOnly ep As New ErrorProvider()
    Private selectedId As Integer = 0
    Private initDone As Boolean = False

    ' ===== Saat form dibuka =====
    Private Sub FormDataPaketLayanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ep.ContainerControl = Me
        Navigator.Register("layanan", Me)
        SetupGrid()

        cboJenis.DropDownStyle = ComboBoxStyle.DropDownList
        cboSatuan.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Aktif", "Nonaktif"})
        txtIdLayanan.ReadOnly = True
    End Sub

    Private Sub FormDataPaketLayanan_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Me.Visible Then Return
        Try
            RefreshCombos()
            LoadGrid()
            If Not initDone Then
                initDone = True
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal terhubung ke database:" & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===================== TAMPILAN TABEL =====================
    Private Sub SetupGrid()
        With dgvLayanan
            .Columns.Clear()
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    ' ===================== COMBOBOX =====================
    ' Isi ComboBox = daftar bawaan + nilai yang sudah ada di tabel services
    Private Sub RefreshCombos()
        FillCombo(cboJenis, {}, "service_type")
        FillCombo(cboSatuan, {"Hari", "Kunjungan", "Sekali Antar", "Paket"}, "unit")
    End Sub

    Private Sub FillCombo(cbo As ComboBox, defaults As String(), column As String)
        Dim current As String = cbo.Text
        Dim items As New List(Of String)(defaults)
        Dim dt As DataTable = GetTable(
            $"SELECT DISTINCT {column} FROM services WHERE {column} IS NOT NULL AND {column} <> '' ORDER BY {column}")
        For Each r As DataRow In dt.Rows
            Dim v As String = r(0).ToString()
            If Not items.Exists(Function(x) String.Equals(x, v, StringComparison.OrdinalIgnoreCase)) Then
                items.Add(v)
            End If
        Next
        cbo.Items.Clear()
        cbo.Items.AddRange(items.ToArray())
        If current <> "" Then cbo.SelectedIndex = cbo.FindStringExact(current)
    End Sub

    ' Pilih item; kalau belum ada di daftar, tambahkan dulu
    Private Sub SelectOrAdd(cbo As ComboBox, value As String)
        Dim idx As Integer = cbo.FindStringExact(value)
        If idx < 0 Then idx = cbo.Items.Add(value)
        cbo.SelectedIndex = idx
    End Sub

    ' ===================== READ (tampilkan data) =====================
    Private Sub LoadGrid()
        Try
            Dim kw As String = "%" & txtCari.Text.Trim() & "%"
            Dim dt As DataTable = GetTable(
                "SELECT service_id, service_name, " &
                "       CASE WHEN is_active = 1 THEN 'Aktif' ELSE 'Nonaktif' END AS status_text, " &
                "       service_type, price, unit " &
                "FROM services WHERE service_name LIKE @k OR service_type LIKE @k " &
                "ORDER BY service_id DESC", P("@k", kw))
            dgvLayanan.DataSource = dt

            dgvLayanan.Columns("service_id").HeaderText = "ID"
            dgvLayanan.Columns("service_name").HeaderText = "Nama Layanan"
            dgvLayanan.Columns("status_text").HeaderText = "Status"
            dgvLayanan.Columns("service_type").HeaderText = "Jenis Layanan"
            dgvLayanan.Columns("price").HeaderText = "Harga"
            dgvLayanan.Columns("unit").HeaderText = "Satuan"
            dgvLayanan.Columns("price").DefaultCellStyle.Format = "N0"
            dgvLayanan.Columns("price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvLayanan.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Klik baris tabel -> isi ke kotak-kotak
    Private Sub dgvLayanan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLayanan.CellClick
        If e.RowIndex < 0 Then Return
        Dim r As DataGridViewRow = dgvLayanan.Rows(e.RowIndex)

        selectedId = Convert.ToInt32(r.Cells("service_id").Value)
        txtIdLayanan.Text = selectedId.ToString()
        txtNamaLayanan.Text = r.Cells("service_name").Value.ToString()
        SelectOrAdd(cboJenis, r.Cells("service_type").Value.ToString())
        txtHarga.Text = Convert.ToDecimal(r.Cells("price").Value).ToString("0")
        SelectOrAdd(cboSatuan, r.Cells("unit").Value.ToString())
        cboStatus.SelectedIndex = cboStatus.FindStringExact(r.Cells("status_text").Value.ToString())

        ep.Clear()
        SetMode(True)
    End Sub

    Private Sub ClearForm()
        selectedId = 0
        txtIdLayanan.Text = "(otomatis)"      ' ID dibuat database (AUTO_INCREMENT)
        txtNamaLayanan.Clear()
        cboJenis.SelectedIndex = -1
        txtHarga.Clear()
        cboSatuan.SelectedIndex = -1
        cboStatus.SelectedIndex = 0           ' default: Aktif
        ep.Clear()
        dgvLayanan.ClearSelection()
        SetMode(False)
        txtNamaLayanan.Focus()
    End Sub

    Private Sub SetMode(edit As Boolean)
        btnSimpan.Enabled = Not edit
        btnUbah.Enabled = edit
        btnHapus.Enabled = edit
    End Sub

    Private Sub btnKosongkan_Click(sender As Object, e As EventArgs) Handles btnKosongkan.Click
        ClearForm()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        LoadGrid()
    End Sub

    ' Kotak Harga hanya menerima angka
    Private Sub txtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHarga.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    ' ===================== VALIDASI =====================
    Private Function ValidateInput() As Boolean
        ep.Clear()
        Dim ok As Boolean = True

        Dim nm As String = txtNamaLayanan.Text.Trim()
        If nm = "" Then
            ep.SetError(txtNamaLayanan, "Nama layanan wajib diisi.") : ok = False
        ElseIf nm.Length < 3 Then
            ep.SetError(txtNamaLayanan, "Nama minimal 3 karakter.") : ok = False
        Else
            Dim dup As Integer = Convert.ToInt32(Scalar(
                "SELECT COUNT(*) FROM services WHERE service_name=@n AND service_id<>@id",
                P("@n", nm), P("@id", selectedId)))
            If dup > 0 Then
                ep.SetError(txtNamaLayanan, "Nama layanan sudah ada.") : ok = False
            End If
        End If

        If cboJenis.SelectedIndex < 0 Then
            ep.SetError(cboJenis, "Pilih jenis layanan.") : ok = False
        End If

        Dim pr As String = txtHarga.Text.Trim()
        If pr = "" Then
            ep.SetError(txtHarga, "Harga wajib diisi.") : ok = False
        ElseIf Not Regex.IsMatch(pr, "^[0-9]+$") Then
            ep.SetError(txtHarga, "Harga hanya boleh angka.") : ok = False
        ElseIf Decimal.Parse(pr) <= 0 Then
            ep.SetError(txtHarga, "Harga harus lebih dari 0.") : ok = False
        End If

        If cboSatuan.SelectedIndex < 0 Then
            ep.SetError(cboSatuan, "Pilih satuan.") : ok = False
        End If
        If cboStatus.SelectedIndex < 0 Then
            ep.SetError(cboStatus, "Pilih status.") : ok = False
        End If

        If Not ok Then
            MessageBox.Show("Periksa kembali isian yang ditandai.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return ok
    End Function

    ' Aktif = 1, Nonaktif = 0 (kolom is_active)
    Private Function IsActiveValue() As Integer
        Return If(cboStatus.Text = "Aktif", 1, 0)
    End Function

    ' ===================== CREATE (Simpan) =====================
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If selectedId <> 0 Then
            MessageBox.Show("Data sedang dipilih. Tekan 'Kosongkan' untuk menambah data baru.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not ValidateInput() Then Return

        Try
            Exec("INSERT INTO services (service_name, service_type, price, unit, is_active) " &
                 "VALUES (@nm, @tp, @pr, @un, @ac)",
                 P("@nm", txtNamaLayanan.Text.Trim()), P("@tp", cboJenis.Text),
                 P("@pr", Decimal.Parse(txtHarga.Text.Trim())), P("@un", cboSatuan.Text),
                 P("@ac", IsActiveValue()))
            MessageBox.Show("Layanan berhasil disimpan.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshCombos()
            LoadGrid()
            ClearForm()
        Catch ex As MySqlException
            MessageBox.Show("Kesalahan database (" & ex.Number & "): " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===================== UPDATE (Ubah) =====================
    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If selectedId = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not ValidateInput() Then Return

        Try
            Exec("UPDATE services SET service_name=@nm, service_type=@tp, price=@pr, unit=@un, is_active=@ac " &
                 "WHERE service_id=@id",
                 P("@nm", txtNamaLayanan.Text.Trim()), P("@tp", cboJenis.Text),
                 P("@pr", Decimal.Parse(txtHarga.Text.Trim())), P("@un", cboSatuan.Text),
                 P("@ac", IsActiveValue()), P("@id", selectedId))
            MessageBox.Show("Data layanan berhasil diubah.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshCombos()
            LoadGrid()
            ClearForm()
        Catch ex As MySqlException
            MessageBox.Show("Kesalahan database (" & ex.Number & "): " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===================== DELETE (Hapus) =====================
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedId = 0 Then
            MessageBox.Show("Pilih data pada tabel terlebih dahulu.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Hapus layanan '" & txtNamaLayanan.Text & "'?",
                           "Konfirmasi", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Exec("DELETE FROM services WHERE service_id=@id", P("@id", selectedId))
            MessageBox.Show("Data layanan berhasil dihapus.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadGrid()
            ClearForm()
        Catch ex As MySqlException When ex.Number = 1451
            MessageBox.Show("Layanan sudah dipakai pada reservasi sehingga tidak dapat dihapus." & vbCrLf &
                            "Ubah Status menjadi 'Nonaktif' lalu tekan Ubah.",
                            "Tidak dapat dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===================== NAVIGASI SIDEBAR =====================
    Private Sub btnMenuLayanan_Click(sender As Object, e As EventArgs) Handles btnMenuLayanan.Click
        Navigator.NavigateTo(Me, "layanan")
    End Sub

    Private Sub btnMenuCustomer_Click(sender As Object, e As EventArgs) Handles btnMenuCustomer.Click
        If Navigator.GetRegistered("customer") Is Nothing Then
            Navigator.Register("customer", New FormCustomer())
        End If
        Navigator.NavigateTo(Me, "customer")
    End Sub

    Private Sub FormDataPaketLayanan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub cboJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJenis.SelectedIndexChanged

    End Sub
End Class