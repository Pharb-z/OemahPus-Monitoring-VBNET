Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class FormCustomer
    Private ReadOnly ep As New ErrorProvider()
    Private selectedId As Integer
    Private initDone As Boolean

    Private Sub FormCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ep.ContainerControl = Me
        Navigator.Register("customer", Me)
        ConfigureGrid()
        txtIdCustomer.ReadOnly = True
        LoadGrid()
        ClearForm()
    End Sub

    Private Sub FormCustomer_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Visible OrElse Not initDone Then Return
        LoadGrid()
    End Sub

    Private Sub ConfigureGrid()
        With dgvCustomer
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

    Private Sub LoadGrid()
        Try
            Dim keyword As String = "%" & txtCari.Text.Trim() & "%"
            Dim table As DataTable = GetTable(
                "SELECT customer_id, full_name, phone, address, email " &
                "FROM customers " &
                "WHERE full_name LIKE @keyword OR phone LIKE @keyword OR " &
                "email LIKE @keyword " &
                "ORDER BY customer_id DESC", P("@keyword", keyword))

            dgvCustomer.DataSource = table
            SetHeader("customer_id", "ID")
            SetHeader("full_name", "Nama Lengkap")
            SetHeader("phone", "No Telepon")
            SetHeader("address", "Alamat")
            SetHeader("email", "Email")
            dgvCustomer.ClearSelection()
            initDone = True
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data customer: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetHeader(columnName As String, headerText As String)
        If dgvCustomer.Columns.Contains(columnName) Then
            dgvCustomer.Columns(columnName).HeaderText = headerText
        End If
    End Sub

    Private Sub dgvCustomer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomer.CellClick
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvCustomer.Rows(e.RowIndex)
        selectedId = Convert.ToInt32(row.Cells("customer_id").Value)
        txtIdCustomer.Text = selectedId.ToString()
        txtNamaLengkap.Text = CellText(row, "full_name")
        txtNoTelepon.Text = CellText(row, "phone")
        txtAlamat.Text = CellText(row, "address")
        txtEmail.Text = CellText(row, "email")
        ep.Clear()
        SetMode(True)
    End Sub

    Private Function CellText(row As DataGridViewRow, columnName As String) As String
        If row.Cells(columnName).Value Is Nothing OrElse row.Cells(columnName).Value Is DBNull.Value Then
            Return String.Empty
        End If
        Return row.Cells(columnName).Value.ToString()
    End Function

    Private Sub ClearForm()
        selectedId = 0
        txtIdCustomer.Text = "(otomatis)"
        txtNamaLengkap.Clear()
        txtNoTelepon.Clear()
        txtAlamat.Clear()
        txtEmail.Clear()
        ep.Clear()
        dgvCustomer.ClearSelection()
        SetMode(False)
        txtNamaLengkap.Focus()
    End Sub

    Private Sub SetMode(edit As Boolean)
        btnSimpan.Enabled = Not edit
        btnUbah.Enabled = edit
        btnHapus.Enabled = edit
    End Sub

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
                "SELECT COUNT(*) FROM customers WHERE (email=@email) AND customer_id<>@id",
                P("@email", email), P("@id", selectedId)))
            If duplicate > 0 Then
                ep.SetError(txtEmail, "Nama akun atau email sudah digunakan.")
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
            Exec("INSERT INTO customers (full_name, phone, address, email) " &
                 "VALUES (@fullName, @phone, @address, @email)",
                 P("@fullName", txtNamaLengkap.Text.Trim()),
                 P("@phone", txtNoTelepon.Text.Trim()),
                 P("@address", txtAlamat.Text.Trim()),
                 P("@email", txtEmail.Text.Trim()))
            MessageBox.Show("Customer berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadGrid()
            ClearForm()
        Catch ex As MySqlException
            ShowDatabaseError(ex)
        Catch ex As Exception
            ShowGeneralError(ex)
        End Try
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If selectedId = 0 Then Return
        If Not ValidateInput() Then Return
        Try
            Exec("UPDATE customers SET full_name=@fullName, phone=@phone, address=@address, " &
                 "email=@email WHERE customer_id=@id",
                 P("@fullName", txtNamaLengkap.Text.Trim()),
                 P("@phone", txtNoTelepon.Text.Trim()),
                 P("@address", txtAlamat.Text.Trim()),
                 P("@email", txtEmail.Text.Trim()),
                 P("@id", selectedId))
            MessageBox.Show("Data customer berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadGrid()
            ClearForm()
        Catch ex As MySqlException
            ShowDatabaseError(ex)
        Catch ex As Exception
            ShowGeneralError(ex)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedId = 0 Then Return
        If MessageBox.Show("Hapus customer '" & txtNamaLengkap.Text & "'?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Exec("DELETE FROM customers WHERE customer_id=@id", P("@id", selectedId))
            MessageBox.Show("Customer berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadGrid()
            ClearForm()
        Catch ex As MySqlException
            ShowDatabaseError(ex)
        Catch ex As Exception
            ShowGeneralError(ex)
        End Try
    End Sub

    Private Sub btnKosongkan_Click(sender As Object, e As EventArgs) Handles btnKosongkan.Click
        ClearForm()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If initDone Then LoadGrid()
    End Sub

    Private Sub btnMenuLayanan_Click(sender As Object, e As EventArgs) Handles btnMenuLayanan.Click
        If Navigator.GetRegistered("layanan") Is Nothing Then
            Navigator.Register("layanan", New FormDataPaketLayanan())
        End If
        Navigator.NavigateTo(Me, "layanan")
    End Sub

    Private Sub btnMenuCustomer_Click(sender As Object, e As EventArgs) Handles btnMenuCustomer.Click
        Show()
    End Sub

    Private Sub ShowDatabaseError(ex As MySqlException)
        MessageBox.Show("Kesalahan database (" & ex.Number & "): " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ShowGeneralError(ex As Exception)
        MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub dgvCustomer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomer.CellContentClick

    End Sub
End Class