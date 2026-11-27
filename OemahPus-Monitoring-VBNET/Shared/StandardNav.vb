Imports System.Windows.Forms

' Sidebar 6-slot standar, dipakai form StafOperasional / StafAntarJemput / Owner.
' Target tiap slot bergantung role supaya tombol lama tetap relevan di form baru.
Module StandardNav
    ' RBAC asli tetap ModuleAccess; ini cuma membuka 2 slot tambahan untuk
    ' StafOperasional dan mengganti caption sesuai form tujuan per role.
    Public Sub ApplyMenu(ParamArray buttons As Button())
        ApplyMenuAccess(buttons)
        For Each b In buttons
            If b Is Nothing Then Continue For
            Select Case b.Name
                Case "btnMenuLayanan"
                    If UserSession.CurrentRole = "StafOperasional" Then
                        b.Visible = True
                        b.Text = "Riwayat Layanan"
                    ElseIf UserSession.CurrentRole = "StafAntarJemput" Then
                        b.Visible = True
                        b.Text = "Detail Pesanan"
                    End If
                Case "btnMenuLaporan"
                    If UserSession.CurrentRole = "StafOperasional" Then
                        b.Visible = True
                        b.Text = "Laporan Harian"
                    End If
                Case "btnMenuReservasi"
                    If UserSession.CurrentRole = "StafAntarJemput" Then
                        b.Visible = True
                        b.Text = "Jadwal Antar Jemput"
                    ElseIf UserSession.CurrentRole = "StafOperasional" Then
                        b.Visible = True
                        b.Text = "Check In & Out"
                    End If
                Case "btnMenuCustomer"
                    If UserSession.CurrentRole = "Owner" Then b.Text = "Kandang"
                Case "btnMenuPemeriksaanKucing"
                    If UserSession.CurrentRole = "Owner" Then b.Text = "Riwayat"
            End Select
        Next
    End Sub

    ' Form tanpa tombol Logout cukup pakai versi menu saja.
    Public Sub WireMenu(f As Form, dash As Button, layanan As Button, customer As Button,
                        medis As Button, reservasi As Button, laporan As Button, akun As Button)
        AddHandler dash.Click, Sub(s As Object, e As EventArgs)
                                   Navigator.Go(f, "dashboard", Function() New FormDashboard())
                               End Sub
        AddHandler layanan.Click, Sub(s As Object, e As EventArgs) GoLayanan(f)
        AddHandler customer.Click, Sub(s As Object, e As EventArgs) GoCustomer(f)
        AddHandler medis.Click, Sub(s As Object, e As EventArgs) GoMedis(f)
        AddHandler reservasi.Click, Sub(s As Object, e As EventArgs) GoReservasi(f)
        AddHandler laporan.Click, Sub(s As Object, e As EventArgs) GoLaporan(f)
        AddHandler akun.Click, Sub(s As Object, e As EventArgs)
                                   Navigator.Go(f, "akun", Function() New FormAkunSaya())
                               End Sub
    End Sub

    Public Sub Wire(f As Form, dash As Button, layanan As Button, customer As Button,
                    medis As Button, reservasi As Button, laporan As Button,
                    akun As Button, logout As Button)
        WireMenu(f, dash, layanan, customer, medis, reservasi, laporan, akun)
        AddHandler logout.Click, Sub(s As Object, e As EventArgs)
                                     If MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
                                     Navigator.Clear()
                                     FormLogin.Show()
                                     f.Close()
                                 End Sub
    End Sub

    Public Sub GoLayanan(f As Form)
        If UserSession.CurrentRole = "StafOperasional" Then
            Navigator.Go(f, "riwayatLayanan", Function() New FormRiwayatLayanan())
        ElseIf UserSession.CurrentRole = "StafAntarJemput" Then
            GoDetailPesanan(f)
        Else
            Navigator.Go(f, "layanan", Function() New FormDataPaketLayanan())
        End If
    End Sub

    Public Sub GoCustomer(f As Form)
        If UserSession.CurrentRole = "Owner" Then
            Navigator.Go(f, "kandang", Function() New FormKandang())
        Else
            Navigator.Go(f, "customer", Function() New FormCustomer())
        End If
    End Sub

    Public Sub GoMedis(f As Form)
        If UserSession.CurrentRole = "Owner" Then
            Navigator.Go(f, "riwayatOwner", Function() New FormRiwayatOwner())
        Else
            Navigator.Go(f, "medis", Function() New FormMedisKucing())
        End If
    End Sub

    Public Sub GoReservasi(f As Form)
        If UserSession.CurrentRole = "StafOperasional" Then
            Navigator.Go(f, "checkInOut", Function() New FormCheckInOut())
        Else
            Navigator.Go(f, "jadwal", Function() New FormJadwalAntarJemput())
        End If
    End Sub

    Public Sub GoLaporan(f As Form)
        If UserSession.CurrentRole = "StafOperasional" Then
            Navigator.Go(f, "dailyReport", Function() New FormDailyReport())
        Else
            Navigator.Go(f, "laporan", Function() New FormReport())
        End If
    End Sub

    ' Slot "Detail Pesanan" kurir butuh id pengiriman; pakai tugas terdekat yang belum selesai,
    ' kalau kosong arahkan ke Jadwal (mengikuti perilaku prototipe yang mengalihkan tanpa ?id).
    Private Sub GoDetailPesanan(f As Form)
        Try
            Dim id As Object = Scalar(
                "SELECT delivery_id FROM deliveries WHERE assigned_to=@uid " &
                "ORDER BY (status='Selesai'), schedule_at LIMIT 1",
                P("@uid", UserSession.CurrentUserId))
            If id Is Nothing OrElse id Is DBNull.Value Then
                MessageBox.Show("Belum ada tugas antar jemput. Membuka menu Jadwal.",
                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Navigator.Go(f, "jadwal", Function() New FormJadwalAntarJemput())
                Return
            End If
            Dim target As New FormDetailAntarJemput()
            target.DeliveryId = Convert.ToInt32(id)
            Navigator.GoWithInstance(f, "detailAntarJemput", target, String.Empty)
        Catch ex As Exception
            MessageBox.Show("Gagal membuka detail pesanan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
