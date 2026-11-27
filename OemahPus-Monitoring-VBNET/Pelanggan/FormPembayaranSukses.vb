Imports System.Data
Imports System.IO

' Bukti pembayaran (prototipe, halaman 12). Simulasi, bukan bukti sah.
Public Class FormPembayaranSukses

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property PaymentNo As String = String.Empty

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property ReservationNo As String = String.Empty

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property Amount As Decimal = 0

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property Method As String = String.Empty

    Private Sub FormPembayaranSukses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("pembayaranSukses", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                          btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                        btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)

        txtBukti.Multiline = True
        txtBukti.ReadOnly = True
        txtRincian.Multiline = True
        txtRincian.ReadOnly = True

        Dim paidAt As String = "-"
        Dim status As String = "Valid"
        Try
            Dim table As DataTable = GetTable(
                "SELECT paid_at, status FROM payments WHERE payment_no=@no", P("@no", PaymentNo))
            If table.Rows.Count > 0 Then
                Dim row As DataRow = table.Rows(0)
                If row("paid_at") IsNot DBNull.Value Then
                    paidAt = Convert.ToDateTime(row("paid_at")).ToString("dd-MM-yyyy HH:mm")
                End If
                status = Convert.ToString(row("status"))
            End If
        Catch ex As Exception
            paidAt = "- (" & ex.Message & ")"
        End Try

        txtBukti.Text = "No. Pembayaran : " & PaymentNo & Environment.NewLine &
                        "No. Reservasi  : " & ReservationNo & Environment.NewLine &
                        "Metode         : " & Method & Environment.NewLine &
                        "Tanggal        : " & paidAt & Environment.NewLine &
                        "Status         : " & status
        txtRincian.Text = "Total tagihan  : Rp " & Amount.ToString("N0") & Environment.NewLine &
                          "DP dibayar     : Rp 100.000" & Environment.NewLine &
                          Environment.NewLine &
                          "Catatan: ini simulasi prototipe," & Environment.NewLine &
                          "bukan bukti transaksi yang sah."
    End Sub

    Private Sub btnLihatRiwayat_Click(sender As Object, e As EventArgs) Handles btnLihatRiwayat.Click
        Navigator.Go(Me, "riwayat", Function() New FormRiwayat())
    End Sub

    Private Sub btnUnduhBukti_Click(sender As Object, e As EventArgs) Handles btnUnduhBukti.Click
        Using sfd As New SaveFileDialog()
            sfd.Title = "Simpan Bukti Pembayaran"
            sfd.Filter = "Berkas Teks (*.txt)|*.txt"
            sfd.FileName = "Bukti_" & If(String.IsNullOrWhiteSpace(ReservationNo), "pembayaran", ReservationNo)
            If sfd.ShowDialog(Me) <> DialogResult.OK Then Return

            Try
                File.WriteAllText(sfd.FileName,
                    "OMI - OemahPus Monitoring Information" & Environment.NewLine &
                    "BUKTI PEMBAYARAN (SIMULASI)" & Environment.NewLine &
                    New String("-"c, 40) & Environment.NewLine &
                    txtBukti.Text & Environment.NewLine & Environment.NewLine &
                    txtRincian.Text & Environment.NewLine)
                If MessageBox.Show("Bukti disimpan ke:" & vbCrLf & sfd.FileName & vbCrLf & vbCrLf &
                                   "Buka sekarang?", "Unduh Sukses",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Diagnostics.Process.Start(New Diagnostics.ProcessStartInfo(sfd.FileName) With {.UseShellExecute = True})
                End If
            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan bukti: " & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class
