' Halaman tambah/edit kandang (pisah dari daftar, pola sama dengan layanan/kucing).
Public Class FormKandangEdit

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property KandangId As Integer = 0

    Private ReadOnly Property IsEdit As Boolean
        Get
            Return KandangId > 0
        End Get
    End Property

    Private Sub FormKandangEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("kandangEdit", Me)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                              btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun, btnLogout)

        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Tersedia", "Terisi", "Perawatan"})
        cboStatus.SelectedIndex = 0

        lblJudul.Text = If(IsEdit, "Edit Kandang", "Tambah Kandang")
        Text = lblJudul.Text

        If IsEdit Then
            Try
                If Not LoadData() Then
                    MessageBox.Show("Data kandang tidak ditemukan.", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Kembali()
                End If
            Catch ex As Exception
                MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            txtKode.Focus()
        End If
    End Sub

    Private Function LoadData() As Boolean
        Dim dt As DataTable = GetTable(
            "SELECT cage_code, size_cm, status FROM cages WHERE cage_id=@id",
            P("@id", KandangId))
        If dt.Rows.Count = 0 Then Return False

        Dim r As DataRow = dt.Rows(0)
        txtKode.Text = Convert.ToString(r("cage_code"))
        txtUkuran.Text = Convert.ToString(r("size_cm"))
        cboStatus.SelectedIndex = cboStatus.FindStringExact(Convert.ToString(r("status")))
        Return True
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrWhiteSpace(txtKode.Text) Then
            MessageBox.Show("Kode kandang wajib diisi.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKode.Focus()
            Return
        End If
        If cboStatus.SelectedIndex < 0 Then
            MessageBox.Show("Pilih status.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If IsEdit Then
                Exec("UPDATE cages SET cage_code=@kode, size_cm=@ukuran, status=@status WHERE cage_id=@id",
                     P("@kode", txtKode.Text.Trim()), P("@ukuran", txtUkuran.Text.Trim()),
                     P("@status", cboStatus.Text), P("@id", KandangId))
            Else
                Exec("INSERT INTO cages (cage_code, size_cm, status) VALUES (@kode, @ukuran, @status)",
                     P("@kode", txtKode.Text.Trim()), P("@ukuran", txtUkuran.Text.Trim()),
                     P("@status", cboStatus.Text))
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        MessageBox.Show("Data kandang tersimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Kembali()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kembali()
    End Sub

    Private Sub Kembali()
        Navigator.Go(Me, "kandang", Function() New FormKandang())
    End Sub
End Class