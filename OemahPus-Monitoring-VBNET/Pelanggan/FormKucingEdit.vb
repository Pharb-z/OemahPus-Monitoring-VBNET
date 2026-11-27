Imports System.Data

' Halaman tambah/edit profil kucing (pisah dari daftar, mengikuti prototipe tambah/edit-kucing).
Public Class FormKucingEdit

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property CatId As Integer = 0

    Private customerId As Integer

    Private ReadOnly Property IsEdit As Boolean
        Get
            Return CatId > 0
        End Get
    End Property

    Private Sub FormKucingEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("kucingEdit", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                          btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                        btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)

        cmbGender.Items.Clear()
        cmbGender.Items.Add("Jantan")
        cmbGender.Items.Add("Betina")
        cmbGender.DropDownStyle = ComboBoxStyle.DropDownList

        lblJudul.Text = If(IsEdit, "Edit Profil Kucing", "Tambah Profil Kucing")
        Text = lblJudul.Text

        Try
            customerId = CustomerService.EnsureCustomerId()
            If IsEdit Then
                If Not LoadData() Then
                    MessageBox.Show("Data kucing tidak ditemukan.", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Kembali()
                    Return
                End If
            Else
                dtpLahir.Value = Today
                txtNama.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function LoadData() As Boolean
        Dim table As DataTable = GetTable(
            "SELECT cat_name, breed, gender, birth_date, fur_color, is_vaccinated, notes " &
            "FROM cats WHERE cat_id=@id AND customer_id=@cid",
            P("@id", CatId), P("@cid", customerId))
        If table.Rows.Count = 0 Then Return False

        Dim row As DataRow = table.Rows(0)
        txtNama.Text = If(row("cat_name"), "").ToString()
        txtRas.Text = If(row("breed"), "").ToString()
        cmbGender.Text = If(row("gender"), "").ToString()
        Dim lahir As Object = row("birth_date")
        If lahir IsNot Nothing AndAlso lahir IsNot DBNull.Value Then dtpLahir.Value = Convert.ToDateTime(lahir)
        txtWarna.Text = If(row("fur_color"), "").ToString()
        txtCatatan.Text = If(row("notes"), "").ToString()
        chkVaksin.Checked = Convert.ToInt32(row("is_vaccinated")) = 1
        Return True
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama kucing wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Return
        End If
        If cmbGender.SelectedIndex < 0 Then
            MessageBox.Show("Pilih jenis kelamin.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbGender.Focus()
            Return
        End If

        Try
            If IsEdit Then
                Exec("UPDATE cats SET cat_name=@nama, breed=@ras, fur_color=@warna, gender=@gender, " &
                     "birth_date=@lahir, is_vaccinated=@vaksin, notes=@catatan " &
                     "WHERE cat_id=@id AND customer_id=@cid",
                     P("@nama", txtNama.Text.Trim()), P("@ras", txtRas.Text.Trim()),
                     P("@warna", txtWarna.Text.Trim()), P("@gender", cmbGender.Text),
                     P("@lahir", dtpLahir.Value.Date), P("@vaksin", chkVaksin.Checked),
                     P("@catatan", txtCatatan.Text.Trim()), P("@id", CatId), P("@cid", customerId))
            Else
                Exec("INSERT INTO cats (customer_id, cat_name, breed, fur_color, gender, birth_date, is_vaccinated, notes) " &
                     "VALUES (@cid, @nama, @ras, @warna, @gender, @lahir, @vaksin, @catatan)",
                     P("@cid", customerId), P("@nama", txtNama.Text.Trim()), P("@ras", txtRas.Text.Trim()),
                     P("@warna", txtWarna.Text.Trim()), P("@gender", cmbGender.Text),
                     P("@lahir", dtpLahir.Value.Date), P("@vaksin", chkVaksin.Checked),
                     P("@catatan", txtCatatan.Text.Trim()))
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        MessageBox.Show("Data kucing tersimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Kembali()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kembali()
    End Sub

    Private Sub Kembali()
        Navigator.Go(Me, "profil", Function() New FormProfilKucing())
    End Sub
End Class