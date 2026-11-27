Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

' Halaman tambah/edit customer (pisah dari daftar, pola sama dengan layanan/kucing).
Public Class FormCustomerEdit

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property CustomerId As Integer = 0

    Private ReadOnly ep As New ErrorProvider()

    Private ReadOnly Property IsEdit As Boolean
        Get
            Return CustomerId > 0
        End Get
    End Property

    Private Sub FormCustomerEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ep.ContainerControl = Me
        Navigator.Register("customerEdit", Me)
        StandardNav.ApplyMenu(btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                              btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun)
        StandardNav.Wire(Me, btnMenuDashboard, btnMenuLayanan, btnMenuCustomer,
                         btnMenuPemeriksaanKucing, btnMenuReservasi, btnMenuLaporan, btnMenuAkun, btnLogout)

        lblJudul.Text = If(IsEdit, "Edit Customer", "Tambah Customer")
        Text = lblJudul.Text

        If IsEdit Then
            Try
                If Not LoadData() Then
                    MessageBox.Show("Data customer tidak ditemukan.", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Kembali()
                End If
            Catch ex As Exception
                MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            txtNamaLengkap.Focus()
        End If
    End Sub

    Private Function LoadData() As Boolean
        Dim dt As DataTable = GetTable(
            "SELECT full_name, phone, address, email FROM customers WHERE customer_id=@id",
            P("@id", CustomerId))
        If dt.Rows.Count = 0 Then Return False

        Dim r As DataRow = dt.Rows(0)
        txtNamaLengkap.Text = Convert.ToString(r("full_name"))
        txtEmail.Text = Convert.ToString(r("email"))
        txtNoTelepon.Text = Convert.ToString(r("phone"))
        txtAlamat.Text = Convert.ToString(r("address"))
        Return True
    End Function

    Private Function ValidateInput() As Boolean
        ep.Clear()
        Dim valid As Boolean = True
        Dim fullName As String = txtNamaLengkap.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()

        If fullName.Length < 3 Then
            ep.SetError(txtNamaLengkap, "Nama lengkap minimal 3 karakter.")
            valid = False
        End If
        If Not Regex.IsMatch(txtNoTelepon.Text.Trim(), "^[0-9+() -]{8,20}$") Then
            ep.SetError(txtNoTelepon, "Nomor telepon tidak valid.")
            valid = False
        End If
        If txtAlamat.Text.Trim() = String.Empty Then
            ep.SetError(txtAlamat, "Alamat wajib diisi.")
            valid = False
        End If
        If Not Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            ep.SetError(txtEmail, "Format email tidak valid.")
            valid = False
        End If

        If valid Then
            Dim duplicate As Integer = Convert.ToInt32(Scalar(
                "SELECT COUNT(*) FROM customers WHERE email=@email AND customer_id<>@id",
                P("@email", email), P("@id", CustomerId)))
            If duplicate > 0 Then
                ep.SetError(txtEmail, "Email sudah dipakai customer lain.")
                valid = False
            End If
        End If

        If Not valid Then
            MessageBox.Show("Periksa kembali data yang ditandai.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return valid
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Not ValidateInput() Then Return

        Try
            If IsEdit Then
                Exec("UPDATE customers SET full_name=@fullName, phone=@phone, address=@address, email=@email " &
                     "WHERE customer_id=@id",
                     P("@fullName", txtNamaLengkap.Text.Trim()), P("@phone", txtNoTelepon.Text.Trim()),
                     P("@address", txtAlamat.Text.Trim()), P("@email", txtEmail.Text.Trim()),
                     P("@id", CustomerId))
            Else
                Exec("INSERT INTO customers (full_name, phone, address, email) VALUES (@fullName, @phone, @address, @email)",
                     P("@fullName", txtNamaLengkap.Text.Trim()), P("@phone", txtNoTelepon.Text.Trim()),
                     P("@address", txtAlamat.Text.Trim()), P("@email", txtEmail.Text.Trim()))
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

        MessageBox.Show(If(IsEdit, "Data customer berhasil diubah.", "Customer berhasil disimpan."),
                        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Kembali()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kembali()
    End Sub

    Private Sub Kembali()
        Navigator.Go(Me, "customer", Function() New FormCustomer())
    End Sub
End Class
