Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

' Pembayaran QRIS (prototipe, halaman 11). QR hanya ilustrasi; tak ada gateway.
Public Class FormPembayaranQris

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property PaymentNo As String = String.Empty

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property ReservationNo As String = String.Empty

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Friend Property Amount As Decimal = 0

    Private ReadOnly tmr As New System.Windows.Forms.Timer()
    Private sisaDetik As Integer = 24 * 60

    Private Sub FormPembayaranQris_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("pembayaranQris", Me)
        PelangganNav.Wire(Me, btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                          btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun, btnLogout)
        ApplyMenuAccess(btnMenuDashboard, btnMenuProfil, btnMenuTracking,
                        btnMenuReservasiPelanggan, btnMenuRiwayat, btnMenuAkun)

        lblReservasi.Text = If(String.IsNullOrWhiteSpace(ReservationNo), "-", ReservationNo)
        lblNominal.Text = "IDR. " & Amount.ToString("N0")

        tmr.Interval = 1000
        AddHandler tmr.Tick, AddressOf TimerTick
        MulaiTimer()
    End Sub

    Private Sub MulaiTimer()
        sisaDetik = 24 * 60
        lblExpired.Visible = False
        btnSimulasi.Enabled = True
        PerbaruiTimer()
        tmr.Start()
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs)
        sisaDetik -= 1
        If sisaDetik <= 0 Then
            tmr.Stop()
            lblTimer.Text = "00:00"
            lblExpired.Visible = True
            btnSimulasi.Enabled = False
            Return
        End If
        PerbaruiTimer()
    End Sub

    Private Sub PerbaruiTimer()
        lblTimer.Text = TimeSpan.FromSeconds(sisaDetik).ToString("mm\:ss")
    End Sub

    Private Sub FormPembayaranQris_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        tmr.Stop()
        tmr.Dispose()
    End Sub

    ' ---- QR ilustrasi (digambar, bukan gambar asli) ----
    Private Sub pnlQr_Paint(sender As Object, e As PaintEventArgs) Handles pnlQr.Paint
        GambarQr(e.Graphics, pnlQr.ClientRectangle)
    End Sub

    Private Sub GambarQr(g As Graphics, r As Rectangle)
        g.Clear(Color.White)
        Dim n As Integer = 21
        Dim cell As Integer = Math.Max(2, Math.Min(r.Width, r.Height) \ n)
        Dim size As Integer = cell * n
        Dim ox As Integer = r.X + (r.Width - size) \ 2
        Dim oy As Integer = r.Y + (r.Height - size) \ 2

        Dim rnd As New Random(SeedStabil(ReservationNo))
        For y As Integer = 0 To n - 1
            For x As Integer = 0 To n - 1
                If rnd.Next(2) = 1 Then
                    g.FillRectangle(Brushes.Black, ox + x * cell, oy + y * cell, cell, cell)
                End If
            Next
        Next

        GambarFinder(g, ox, oy, cell)
        GambarFinder(g, ox + (n - 7) * cell, oy, cell)
        GambarFinder(g, ox, oy + (n - 7) * cell, cell)
    End Sub

    Private Sub GambarFinder(g As Graphics, ox As Integer, oy As Integer, cell As Integer)
        g.FillRectangle(Brushes.White, ox, oy, cell * 7, cell * 7)
        g.FillRectangle(Brushes.Black, ox, oy, cell * 7, cell * 7)
        g.FillRectangle(Brushes.White, ox + cell, oy + cell, cell * 5, cell * 5)
        g.FillRectangle(Brushes.Black, ox + cell * 2, oy + cell * 2, cell * 3, cell * 3)
    End Sub

    ' Hash stabil (GetHashCode string tak deterministik antar proses).
    Private Function SeedStabil(s As String) As Integer
        Dim seed As Integer = 7
        If String.IsNullOrEmpty(s) Then Return seed
        For Each ch As Char In s
            seed = (seed * 31 + AscW(ch)) And &H7FFFFFFF
        Next
        Return If(seed = 0, 7, seed)
    End Function

    Private Sub btnSimulasi_Click(sender As Object, e As EventArgs) Handles btnSimulasi.Click
        tmr.Stop()
        Try
            Exec("UPDATE payments SET status='Valid' WHERE payment_no=@no", P("@no", PaymentNo))
        Catch ex As Exception
            MessageBox.Show("Gagal menandai pembayaran: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim target As New FormPembayaranSukses()
        target.PaymentNo = PaymentNo
        target.ReservationNo = ReservationNo
        target.Amount = Amount
        target.Method = "QRIS"
        Navigator.GoWithInstance(Me, "pembayaranSukses", target, String.Empty)
    End Sub

    Private Sub btnUnduhQr_Click(sender As Object, e As EventArgs) Handles btnUnduhQr.Click
        Using sfd As New SaveFileDialog()
            sfd.Title = "Simpan Kode QR"
            sfd.Filter = "Gambar PNG (*.png)|*.png"
            sfd.FileName = "QRIS_" & If(String.IsNullOrWhiteSpace(ReservationNo), "pembayaran", ReservationNo)
            If sfd.ShowDialog(Me) <> DialogResult.OK Then Return

            Try
                Using bmp As New Bitmap(240, 240)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        GambarQr(g, New Rectangle(0, 0, 240, 240))
                    End Using
                    bmp.Save(sfd.FileName, ImageFormat.Png)
                End Using
                MessageBox.Show("Kode QR disimpan (ilustrasi simulasi):" & vbCrLf & sfd.FileName,
                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Gagal menyimpan QR: " & ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Navigator.Go(Me, "riwayat", Function() New FormRiwayat())
    End Sub
End Class
