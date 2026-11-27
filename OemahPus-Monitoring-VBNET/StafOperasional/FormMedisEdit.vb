Imports MySql.Data.MySqlClient

' Halaman tambah/edit pemeriksaan kucing (pisah dari daftar).
Public Class FormMedisEdit

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property ExamId As Integer = 0

    Private ReadOnly ep As New ErrorProvider()

    Private ReadOnly Property IsEdit As Boolean
        Get
            Return ExamId > 0
        End Get
    End Property

    Private Sub FormMedisEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ep.ContainerControl = Me
        Navigator.Register("medisEdit", Me)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                              btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun, btnLogout)

        lblJudul.Text = If(IsEdit, "Edit Pemeriksaan", "Tambah Pemeriksaan")
        Text = lblJudul.Text

        cmbTemuanParasit.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTemuanParasit.Items.Clear()
        cmbTemuanParasit.Items.AddRange(New Object() {"Belum Diperiksa", "Tidak Ditemukan", "Ditemukan"})

        dtpTanggalPemeriksaan.Value = DateTime.Now

        Try
            LoadCats()
            If IsEdit Then
                If Not LoadData() Then
                    MessageBox.Show("Data pemeriksaan tidak ditemukan.", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Kembali()
                End If
            Else
                cmbNamaKucing.SelectedIndex = -1
                cmbTemuanParasit.SelectedIndex = -1
                cmbNamaKucing.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Kucing bawaan: yang belum pernah diperiksa; saat edit, kucing terpilih ikut dimasukkan.
    Private Sub LoadCats()
        Dim dt As DataTable = GetTable(
            "SELECT c.cat_id, CONCAT(c.cat_name, ' - ', cu.full_name) AS cat_display " &
            "FROM cats c INNER JOIN customers cu ON c.customer_id = cu.customer_id " &
            "WHERE NOT EXISTS (SELECT 1 FROM cat_examinations ce WHERE ce.cat_id = c.cat_id) " &
            "   OR c.cat_id = @current " &
            "ORDER BY c.cat_name ASC", P("@current", ExamId))
        cmbNamaKucing.DataSource = dt
        cmbNamaKucing.DisplayMember = "cat_display"
        cmbNamaKucing.ValueMember = "cat_id"
        cmbNamaKucing.SelectedIndex = -1
    End Sub

    Private Function LoadData() As Boolean
        Dim dt As DataTable = GetTable(
            "SELECT cat_id, examination_date, weight, body_temperature, parasite_finding, health_notes " &
            "FROM cat_examinations WHERE examination_id=@id", P("@id", ExamId))
        If dt.Rows.Count = 0 Then Return False

        Dim r As DataRow = dt.Rows(0)
        cmbNamaKucing.SelectedValue = Convert.ToInt32(r("cat_id"))
        dtpTanggalPemeriksaan.Value = Convert.ToDateTime(r("examination_date"))
        txtBeratBadan.Text = Convert.ToString(r("weight"))
        txtSuhuTubuh.Text = Convert.ToString(r("body_temperature"))
        SelectOrAdd(cmbTemuanParasit, Convert.ToString(r("parasite_finding")))
        txtCatatanKesehatan.Text = Convert.ToString(r("health_notes"))
        Return True
    End Function

    Private Sub SelectOrAdd(cbo As ComboBox, value As String)
        Dim idx As Integer = cbo.FindStringExact(value)
        If idx < 0 Then idx = cbo.Items.Add(value)
        cbo.SelectedIndex = idx
    End Sub

    Private Function ValidateInput() As Boolean
        ep.Clear()
        Dim valid As Boolean = True
        Dim weight As Decimal
        Dim temperature As Decimal

        If cmbNamaKucing.SelectedIndex < 0 Then
            ep.SetError(cmbNamaKucing, "Pilih kucing terlebih dahulu.")
            valid = False
        End If
        If Not Decimal.TryParse(txtBeratBadan.Text.Trim(), weight) OrElse weight <= 0 Then
            ep.SetError(txtBeratBadan, "Berat badan harus berupa angka lebih dari 0.")
            valid = False
        End If
        If Not Decimal.TryParse(txtSuhuTubuh.Text.Trim(), temperature) OrElse temperature <= 0 Then
            ep.SetError(txtSuhuTubuh, "Suhu tubuh harus berupa angka lebih dari 0.")
            valid = False
        End If
        If cmbTemuanParasit.SelectedIndex < 0 Then
            ep.SetError(cmbTemuanParasit, "Pilih hasil pemeriksaan parasit.")
            valid = False
        End If
        If dtpTanggalPemeriksaan.Value.Date > DateTime.Today Then
            ep.SetError(dtpTanggalPemeriksaan, "Tanggal pemeriksaan tidak boleh di masa depan.")
            valid = False
        End If

        If Not valid Then
            MessageBox.Show("Periksa kembali data yang ditandai.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return valid
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Not ValidateInput() Then Return

        Dim notes As Object = If(String.IsNullOrWhiteSpace(txtCatatanKesehatan.Text),
                                 CType(DBNull.Value, Object), txtCatatanKesehatan.Text.Trim())

        Try
            If IsEdit Then
                Exec("UPDATE cat_examinations SET cat_id=@catId, examination_date=@examDate, " &
                     "weight=@weight, body_temperature=@temperature, parasite_finding=@parasite, " &
                     "health_notes=@notes WHERE examination_id=@id",
                     P("@catId", Convert.ToInt32(cmbNamaKucing.SelectedValue)),
                     P("@examDate", dtpTanggalPemeriksaan.Value),
                     P("@weight", Decimal.Parse(txtBeratBadan.Text.Trim())),
                     P("@temperature", Decimal.Parse(txtSuhuTubuh.Text.Trim())),
                     P("@parasite", cmbTemuanParasit.Text), P("@notes", notes), P("@id", ExamId))
            Else
                If UserSession.CurrentUserId <= 0 Then
                    MessageBox.Show("Informasi user yang login tidak ditemukan.", "Login",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                Exec("INSERT INTO cat_examinations (cat_id, examined_by, examination_date, " &
                     "weight, body_temperature, parasite_finding, health_notes) " &
                     "VALUES (@catId, @examinedBy, @examDate, @weight, @temperature, @parasite, @notes)",
                     P("@catId", Convert.ToInt32(cmbNamaKucing.SelectedValue)),
                     P("@examinedBy", UserSession.CurrentUserId),
                     P("@examDate", dtpTanggalPemeriksaan.Value),
                     P("@weight", Decimal.Parse(txtBeratBadan.Text.Trim())),
                     P("@temperature", Decimal.Parse(txtSuhuTubuh.Text.Trim())),
                     P("@parasite", cmbTemuanParasit.Text), P("@notes", notes))
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

        MessageBox.Show(If(IsEdit, "Data pemeriksaan berhasil diubah.", "Data pemeriksaan berhasil disimpan."),
                        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Kembali()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kembali()
    End Sub

    Private Sub Kembali()
        Navigator.Go(Me, "medis", Function() New FormMedisKucing())
    End Sub
End Class
