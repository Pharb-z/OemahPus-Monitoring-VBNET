Imports System.Data

Public Class FormReservasiWizard
    Private currentStep As Integer = 1
    Private customerId As Integer

    Private Sub FormReservasiWizard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("reservasiPelanggan", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuReservasiPelanggan,
                          btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuReservasiPelanggan,
                        btnMenuRiwayat, btnMenuAkun)

        txtAlamat.Multiline = True
        txtCatatan.Multiline = True
        txtRingkasan.Multiline = True
        txtRingkasan.ReadOnly = True
        cmbKucing.DropDownStyle = ComboBoxStyle.DropDownList
        ConfigureGrid()

        Try
            customerId = EnsureCustomerId()
            LoadCats()
            LoadServices()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ShowStep(1)
    End Sub

    Private Function EnsureCustomerId() As Integer
        Dim found As Object = Scalar(
            "SELECT customer_id FROM customers WHERE user_id=@uid",
            P("@uid", UserSession.CurrentUserId))
        If found IsNot Nothing AndAlso found IsNot DBNull.Value Then Return Convert.ToInt32(found)

        Exec("INSERT INTO customers (user_id, full_name, phone) VALUES (@uid, @nama, '-')",
             P("@uid", UserSession.CurrentUserId), P("@nama", UserSession.CurrentFullName))
        Return Convert.ToInt32(Scalar("SELECT LAST_INSERT_ID()"))
    End Function

    Private Sub LoadCats()
        Dim table As DataTable = GetTable(
            "SELECT cat_id, cat_name FROM cats WHERE customer_id=@cid ORDER BY cat_name",
            P("@cid", customerId))
        cmbKucing.DataSource = table
        cmbKucing.DisplayMember = "cat_name"
        cmbKucing.ValueMember = "cat_id"
    End Sub

    Private Sub ConfigureGrid()
        dgvLayanan.AutoGenerateColumns = False
        dgvLayanan.ReadOnly = False
        dgvLayanan.Columns.Clear()
        dgvLayanan.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "service_id", .DataPropertyName = "service_id", .Visible = False})
        dgvLayanan.Columns.Add(New DataGridViewCheckBoxColumn With {
            .Name = "pilih", .HeaderText = "Pilih", .Width = 60})
        dgvLayanan.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "service_name", .HeaderText = "Layanan", .DataPropertyName = "service_name", .ReadOnly = True})
        dgvLayanan.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "price", .HeaderText = "Harga", .DataPropertyName = "price", .ReadOnly = True})
        dgvLayanan.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "qty", .HeaderText = "Qty", .DataPropertyName = "qty"})
    End Sub

    Private Sub LoadServices()
        Dim table As DataTable = GetTable(
            "SELECT service_id, service_name, price, 1 AS qty FROM services WHERE is_active=1 ORDER BY service_name")
        dgvLayanan.DataSource = table
    End Sub

    Private Sub ShowStep(n As Integer)
        currentStep = n
        Dim s1 = (n = 1), s2 = (n = 2), s3 = (n = 3)
        lblStep1.Visible = s1 : Label3.Visible = s1 : txtNamaPemesan.Visible = s1
        Label4.Visible = s1 : txtTelepon.Visible = s1 : Label5.Visible = s1 : txtAlamat.Visible = s1
        Label6.Visible = s1 : txtCatatan.Visible = s1 : Label7.Visible = s1
        cmbKucing.Visible = s1 : chkPickup.Visible = s1 : btnNext1.Visible = s1
        lblStep2.Visible = s2 : dgvLayanan.Visible = s2 : lblTotal2.Visible = s2
        btnBack2.Visible = s2 : btnNext2.Visible = s2
        lblStep3.Visible = s3 : Label8.Visible = s3 : dtpCheckIn.Visible = s3
        Label9.Visible = s3 : dtpCheckOut.Visible = s3 : Label10.Visible = s3
        txtRingkasan.Visible = s3 : btnBack3.Visible = s3 : btnAjukan.Visible = s3
    End Sub

    Private Function TotalNights() As Integer
        Return Math.Max(1, DateDiff(DateInterval.Day, dtpCheckIn.Value.Date, dtpCheckOut.Value.Date))
    End Function

    Private Function HitungTotal() As Decimal
        Dim total As Decimal = 0
        Dim table As DataTable = TryCast(dgvLayanan.DataSource, DataTable)
        If table Is Nothing Then Return 0
        For Each row As DataGridViewRow In dgvLayanan.Rows
            If row.IsNewRow Then Continue For
            Dim picked As Boolean = False
            If row.Cells("pilih").Value IsNot Nothing AndAlso row.Cells("pilih").Value IsNot DBNull.Value Then
                picked = Convert.ToBoolean(row.Cells("pilih").Value)
            End If
            If Not picked Then Continue For
            Dim price As Decimal = Convert.ToDecimal(row.Cells("price").Value)
            Dim qty As Integer = 1
            If row.Cells("qty").Value IsNot Nothing AndAlso row.Cells("qty").Value IsNot DBNull.Value Then
                Integer.TryParse(row.Cells("qty").Value.ToString(), qty)
            End If
            total += price * Math.Max(1, qty)
        Next
        Return total * TotalNights()
    End Function

    Private Sub RefreshRingkasan()
        Dim sb As New Text.StringBuilder()
        sb.AppendLine("Pemesan: " & ReservationDraft.Current.CustomerName)
        sb.AppendLine("Telepon: " & ReservationDraft.Current.Phone)
        sb.AppendLine("Kucing: " & ReservationDraft.Current.CatName)
        sb.AppendLine("Check In: " & dtpCheckIn.Value.ToString("yyyy-MM-dd"))
        sb.AppendLine("Check Out: " & dtpCheckOut.Value.ToString("yyyy-MM-dd"))
        sb.AppendLine("Lama inap: " & TotalNights() & " malam")
        sb.AppendLine("Metode antar-jemput: " & If(chkPickup.Checked, "Ya", "Tidak"))
        sb.AppendLine()
        sb.AppendLine("Rincian layanan:")
        For Each id As Integer In ReservationDraft.Current.ServiceIds
            Dim name As String = Convert.ToString(Scalar("SELECT service_name FROM services WHERE service_id=@id", P("@id", id)))
            sb.AppendLine("- " & name & " x" & ReservationDraft.Current.ServiceQty(id))
        Next
        sb.AppendLine()
        sb.AppendLine("TOTAL: Rp " & HitungTotal().ToString("N0"))
        txtRingkasan.Text = sb.ToString()
    End Sub

    Private Sub btnNext1_Click(sender As Object, e As EventArgs) Handles btnNext1.Click
        If String.IsNullOrWhiteSpace(txtNamaPemesan.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelepon.Text) OrElse
           String.IsNullOrWhiteSpace(txtAlamat.Text) Then
            MessageBox.Show("Nama, telepon, dan alamat wajib diisi.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cmbKucing.SelectedValue Is Nothing Then
            MessageBox.Show("Pilih kucing.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        With ReservationDraft.Current
            .CustomerName = txtNamaPemesan.Text.Trim()
            .Phone = txtTelepon.Text.Trim()
            .Address = txtAlamat.Text.Trim()
            .HealthNotes = txtCatatan.Text.Trim()
            .CatId = Convert.ToInt32(cmbKucing.SelectedValue)
            .CatName = Convert.ToString(cmbKucing.Text)
            .NeedPickup = chkPickup.Checked
        End With
        ShowStep(2)
    End Sub

    Private Sub btnNext2_Click(sender As Object, e As EventArgs) Handles btnNext2.Click
        ReservationDraft.Current.ServiceIds.Clear()
        ReservationDraft.Current.ServiceQty.Clear()
        For Each row As DataGridViewRow In dgvLayanan.Rows
            If row.IsNewRow Then Continue For
            Dim picked As Boolean = False
            If row.Cells("pilih").Value IsNot Nothing AndAlso row.Cells("pilih").Value IsNot DBNull.Value Then
                picked = Convert.ToBoolean(row.Cells("pilih").Value)
            End If
            If Not picked Then Continue For
            Dim id As Integer = Convert.ToInt32(row.Cells("service_id").Value)
            Dim qty As Integer = 1
            If row.Cells("qty").Value IsNot Nothing AndAlso row.Cells("qty").Value IsNot DBNull.Value Then
                Integer.TryParse(row.Cells("qty").Value.ToString(), qty)
            End If
            If qty < 1 Then qty = 1
            ReservationDraft.Current.ServiceIds.Add(id)
            ReservationDraft.Current.ServiceQty(id) = qty
        Next
        If ReservationDraft.Current.ServiceIds.Count = 0 Then
            MessageBox.Show("Pilih minimal satu paket layanan.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        lblTotal2.Text = "Total: Rp " & HitungTotal().ToString("N0")
        RefreshRingkasan()
        ShowStep(3)
    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click
        ShowStep(1)
    End Sub

    Private Sub btnBack3_Click(sender As Object, e As EventArgs) Handles btnBack3.Click
        ShowStep(2)
    End Sub

    Private Sub dtpCheckOut_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckOut.ValueChanged
        If dtpCheckOut.Value.Date < dtpCheckIn.Value.Date Then dtpCheckOut.Value = dtpCheckIn.Value.Date
        If currentStep = 3 Then RefreshRingkasan()
    End Sub

    Private Sub dtpCheckIn_ValueChanged(sender As Object, e As EventArgs) Handles dtpCheckIn.ValueChanged
        If dtpCheckOut.Value.Date < dtpCheckIn.Value.Date Then dtpCheckOut.Value = dtpCheckIn.Value.Date
        If currentStep = 3 Then RefreshRingkasan()
    End Sub

    Private Sub btnAjukan_Click(sender As Object, e As EventArgs) Handles btnAjukan.Click
        Try
            Dim no As String = "RSV" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
            Dim total As Decimal = HitungTotal()
            Exec("INSERT INTO reservations (reservation_no, customer_id, cat_id, created_by, " &
                 "check_in_date, check_out_date, need_pickup, status, dp_amount, total_amount, notes) " &
                 "VALUES (@no, @cid, @cat, @usr, @in, @out, @pickup, 'Menunggu', 100000, @total, @notes)",
                 P("@no", no), P("@cid", customerId), P("@cat", ReservationDraft.Current.CatId),
                 P("@usr", UserSession.CurrentUserId), P("@in", dtpCheckIn.Value.Date),
                 P("@out", dtpCheckOut.Value.Date), P("@pickup", ReservationDraft.Current.NeedPickup),
                 P("@total", total), P("@notes", ReservationDraft.Current.HealthNotes))

            Dim resId As Integer = Convert.ToInt32(Scalar("SELECT LAST_INSERT_ID()"))
            For Each id As Integer In ReservationDraft.Current.ServiceIds
                Dim price As Decimal = Convert.ToDecimal(Scalar("SELECT price FROM services WHERE service_id=@id", P("@id", id)))
                Exec("INSERT INTO reservation_details (reservation_id, service_id, qty, unit_price) VALUES (@rid, @sid, @qty, @price)",
                     P("@rid", resId), P("@sid", id), P("@qty", ReservationDraft.Current.ServiceQty(id)), P("@price", price))
            Next

            Dim target As New FormPembayaran()
            target.ReservationNo = no
            target.Amount = total
            ReservationDraft.Current.Reset()
            Navigator.GoWithInstance(Me, "pembayaran", target, String.Empty)
        Catch ex As Exception
            MessageBox.Show("Gagal mengajukan reservasi: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
