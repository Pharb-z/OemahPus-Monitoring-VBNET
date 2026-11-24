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
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuReservasiPelanggan,
                          btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuReservasiPelanggan,
                        btnMenuRiwayat, btnMenuAkun)

        txtRincian.Multiline = True
        txtRincian.ReadOnly = True
        cmbMetode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMetode.Items.Clear()
        cmbMetode.Items.Add("QRIS")
        cmbMetode.Items.Add("Transfer")
        cmbMetode.Items.Add("Tunai")
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
        Dim resId As Object = Scalar("SELECT reservation_id FROM reservations WHERE reservation_no=@no", P("@no", ReservationNo))
        If resId Is Nothing OrElse resId Is DBNull.Value Then
            MessageBox.Show("Reservasi tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            paymentNo = "PAY" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
            ' Pembayaran QRIS di prototipe murni simulasi: langsung ditandai Valid.
            Exec("INSERT INTO payments (payment_no, reservation_id, payment_type, method, amount, status) " &
                 "VALUES (@no, @rid, 'DP', @method, @amount, 'Valid')",
                 P("@no", paymentNo), P("@rid", Convert.ToInt32(resId)),
                 P("@method", cmbMetode.Text), P("@amount", Amount))

            lblStatus.Text = "Status: Valid (simulasi berhasil)"
            txtRincian.Text &= Environment.NewLine & "No. Pembayaran: " & paymentNo &
                               Environment.NewLine & "Metode: " & cmbMetode.Text &
                               Environment.NewLine & "Bukti ini hanya simulasi, bukan bukti sah."
            btnBayar.Enabled = False
            MessageBox.Show("Pembayaran simulasi berhasil.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
