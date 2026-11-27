Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Text.RegularExpressions

' Halaman tambah/edit layanan (pisah dari daftar, mengikuti prototipe admin-tambah-layanan).
Public Class FormLayananEdit

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property ServiceId As Integer = 0

    Private ReadOnly ep As New ErrorProvider()

    Private ReadOnly Property IsEdit As Boolean
        Get
            Return ServiceId > 0
        End Get
    End Property

    Private Sub FormLayananEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("layananEdit", Me)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                              btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun, btnLogout)

        ep.ContainerControl = Me
        cboJenis.DropDownStyle = ComboBoxStyle.DropDownList
        cboSatuan.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList

        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Aktif", "Nonaktif"})
        lblJudul.Text = If(IsEdit, "Edit Layanan", "Tambah Layanan")
        Text = lblJudul.Text

        Try
            FillCombos()
            If IsEdit Then
                If Not LoadData() Then
                    MessageBox.Show("Data layanan tidak ditemukan.", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Kembali()
                    Return
                End If
            Else
                cboStatus.SelectedIndex = 0
                txtNama.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Isi ComboBox = daftar bawaan + nilai yang sudah ada di tabel services.
    Private Sub FillCombos()
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

    Private Sub SelectOrAdd(cbo As ComboBox, value As String)
        Dim idx As Integer = cbo.FindStringExact(value)
        If idx < 0 Then idx = cbo.Items.Add(value)
        cbo.SelectedIndex = idx
    End Sub

    Private Function LoadData() As Boolean
        Dim dt As DataTable = GetTable(
            "SELECT service_name, service_type, price, unit, is_active " &
            "FROM services WHERE service_id=@id", P("@id", ServiceId))
        If dt.Rows.Count = 0 Then Return False

        Dim r As DataRow = dt.Rows(0)
        txtNama.Text = r("service_name").ToString()
        SelectOrAdd(cboJenis, r("service_type").ToString())
        txtHarga.Text = Convert.ToDecimal(r("price")).ToString("0")
        SelectOrAdd(cboSatuan, r("unit").ToString())
        cboStatus.SelectedIndex = cboStatus.FindStringExact(
            If(Convert.ToInt32(r("is_active")) = 1, "Aktif", "Nonaktif"))
        Return True
    End Function

    Private Sub txtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHarga.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Function ValidateInput() As Boolean
        ep.Clear()
        Dim ok As Boolean = True

        Dim nm As String = txtNama.Text.Trim()
        If nm = "" Then
            ep.SetError(txtNama, "Nama layanan wajib diisi.") : ok = False
        ElseIf nm.Length < 3 Then
            ep.SetError(txtNama, "Nama minimal 3 karakter.") : ok = False
        Else
            Dim dup As Integer = Convert.ToInt32(Scalar(
                "SELECT COUNT(*) FROM services WHERE service_name=@n AND service_id<>@id",
                P("@n", nm), P("@id", ServiceId)))
            If dup > 0 Then
                ep.SetError(txtNama, "Nama layanan sudah ada.") : ok = False
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

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Not ValidateInput() Then Return

        Dim aktif As Integer = If(cboStatus.Text = "Aktif", 1, 0)
        Try
            If IsEdit Then
                Exec("UPDATE services SET service_name=@nm, service_type=@tp, price=@pr, unit=@un, is_active=@ac " &
                     "WHERE service_id=@id",
                     P("@nm", txtNama.Text.Trim()), P("@tp", cboJenis.Text),
                     P("@pr", Decimal.Parse(txtHarga.Text.Trim())), P("@un", cboSatuan.Text),
                     P("@ac", aktif), P("@id", ServiceId))
            Else
                Exec("INSERT INTO services (service_name, service_type, price, unit, is_active) " &
                     "VALUES (@nm, @tp, @pr, @un, @ac)",
                     P("@nm", txtNama.Text.Trim()), P("@tp", cboJenis.Text),
                     P("@pr", Decimal.Parse(txtHarga.Text.Trim())), P("@un", cboSatuan.Text),
                     P("@ac", aktif))
            End If
        Catch ex As MySqlException
            MessageBox.Show("Kesalahan database (" & ex.Number & "): " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        MessageBox.Show(If(IsEdit, "Data layanan berhasil diubah.", "Layanan berhasil disimpan."),
                        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Kembali()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kembali()
    End Sub

    Private Sub Kembali()
        Navigator.Go(Me, "layanan", Function() New FormDataPaketLayanan())
    End Sub
End Class