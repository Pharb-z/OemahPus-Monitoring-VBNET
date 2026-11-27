Imports System.Data

Public Class FormPembayaran
    ' ponytail: properti Form perlu atribut ini supaya analyzer WFO1000 tidak menolak.
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property ReservationNo As String = String.Empty

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property Amount As Decimal = 0

    Private paymentNo As String = String.Empty

    Private Sub FormPembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("pembayaran", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                          btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                        btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)

        txtRincian.Multiline = True
        txtRincian.ReadOnly = True
        cmbMetode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMetode.Items.Clear()
        cmbMetode.Items.Add("QRIS")
        cmbMetode.Items.Add("Tunai di Lokasi")
        cmbMetode.SelectedIndex = 0

        If String.IsNullOrWhiteSpace(ReservationNo) Then
            lblStatus.Text = "Status: tidak ada reservasi baru."
            btnBayar.Enabled = False
        Else
            txtRincian.Text = "No. Reservasi: " & ReservationNo & Environment.NewLine &
                              "Total tagihan: Rp " & Amount.ToString("N0") & Environment.NewLine &
                              "DP dibayar: Rp 100.000" & Environment.NewLine &
                              "Catatan: pembayaran di prototipe ini hanya simulasi."
            lblStatus.Text = "Status: Menunggu pembayaran"
        End If
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        If String.IsNullOrWhiteSpace(ReservationNo) Then Return
        If cmbMetode.SelectedIndex < 0 Then
            MessageBox.Show("Pilih metode pembayaran.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim resId As Object = Scalar("SELECT reservation_id FROM reservations WHERE reservation_no=@no", P("@no", ReservationNo))
        If resId Is Nothing OrElse resId Is DBNull.Value Then
            MessageBox.Show("Reservasi tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            paymentNo = "PAY" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
            Dim metode As String = cmbMetode.Text
            Dim isQris As Boolean = String.Equals(metode, "QRIS", StringComparison.OrdinalIgnoreCase)
            ' QRIS menunggu simulasi; tunai langsung valid.
            Dim status As String = If(isQris, "Menunggu", "Valid")
            Exec("INSERT INTO payments (payment_no, reservation_id, payment_type, method, amount, status) " &
                 "VALUES (@no, @rid, 'DP', @method, @amount, @status)",
                 P("@no", paymentNo), P("@rid", Convert.ToInt32(resId)),
                 P("@method", metode), P("@amount", Amount), P("@status", status))

            lblStatus.Text = "Status: " & If(isQris, "Menunggu pembayaran (QRIS)", "Valid (tunai di lokasi)")
            btnBayar.Enabled = False

            If isQris Then
                Dim qris As New FormPembayaranQris()
                qris.PaymentNo = paymentNo
                qris.ReservationNo = ReservationNo
                qris.Amount = Amount
                Navigator.GoWithInstance(Me, "pembayaranQris", qris, String.Empty)
            Else
                Dim sukses As New FormPembayaranSukses()
                sukses.PaymentNo = paymentNo
                sukses.ReservationNo = ReservationNo
                sukses.Amount = Amount
                sukses.Method = metode
                Navigator.GoWithInstance(Me, "pembayaranSukses", sukses, String.Empty)
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan pembayaran: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Navigator.Go(Me, "riwayat", Function() New FormRiwayat())
    End Sub

    Private Sub btnSelesai_Click(sender As Object, e As EventArgs) Handles btnSelesai.Click
        Navigator.Go(Me, "dashboard", Function() New FormDashboard())
    End Sub
End Class
