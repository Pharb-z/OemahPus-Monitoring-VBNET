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
                    End If
                Case "btnMenuLaporan"
                    If UserSession.CurrentRole = "StafOperasional" Then
                        b.Visible = True
                        b.Text = "Laporan Harian"
                    End If
                Case "btnMenuReservasi"
                    If UserSession.CurrentRole = "StafAntarJemput" Then b.Text = "Jadwal Antar Jemput"
                Case "btnMenuCustomer"
                    If UserSession.CurrentRole = "Owner" Then b.Text = "Kandang"
                Case "btnMenuPemeriksaanKucing"
                    If UserSession.CurrentRole = "Owner" Then b.Text = "Riwayat"
            End Select
        Next
    End Sub

    Public Sub Wire(f As Form, dash As Button, layanan As Button, customer As Button,
                    medis As Button, reservasi As Button, laporan As Button, logout As Button)
        AddHandler dash.Click, Sub(s As Object, e As EventArgs)
                                   Navigator.Go(f, "dashboard", Function() New FormDashboard())
                               End Sub
        AddHandler layanan.Click, Sub(s As Object, e As EventArgs) GoLayanan(f)
        AddHandler customer.Click, Sub(s As Object, e As EventArgs) GoCustomer(f)
        AddHandler medis.Click, Sub(s As Object, e As EventArgs) GoMedis(f)
        AddHandler reservasi.Click, Sub(s As Object, e As EventArgs) GoReservasi(f)
        AddHandler laporan.Click, Sub(s As Object, e As EventArgs) GoLaporan(f)
        AddHandler logout.Click, Sub(s As Object, e As EventArgs)
                                     If MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
                                     Navigator.Clear()
                                     FormLogin.Show()
                                     f.Close()
                                 End Sub
    End Sub

    Private Sub GoLayanan(f As Form)
        If UserSession.CurrentRole = "StafOperasional" Then
            Navigator.Go(f, "riwayatLayanan", Function() New FormRiwayatLayanan())
        Else
            Navigator.Go(f, "layanan", Function() New FormDataPaketLayanan())
        End If
    End Sub

    Private Sub GoCustomer(f As Form)
        If UserSession.CurrentRole = "Owner" Then
            Navigator.Go(f, "kandang", Function() New FormKandang())
        Else
            Navigator.Go(f, "customer", Function() New FormCustomer())
        End If
    End Sub

    Private Sub GoMedis(f As Form)
        If UserSession.CurrentRole = "Owner" Then
            Navigator.Go(f, "riwayatOwner", Function() New FormRiwayatOwner())
        Else
            Navigator.Go(f, "medis", Function() New FormMedisKucing())
        End If
    End Sub

    Private Sub GoReservasi(f As Form)
        If UserSession.CurrentRole = "StafAntarJemput" Then
            Navigator.Go(f, "jadwal", Function() New FormJadwalAntarJemput())
        Else
            Navigator.Go(f, "reservasi", Function() New FormReservasi())
        End If
    End Sub

    Private Sub GoLaporan(f As Form)
        If UserSession.CurrentRole = "StafOperasional" Then
            Navigator.Go(f, "dailyReport", Function() New FormDailyReport())
        Else
            Navigator.Go(f, "laporan", Function() New FormReport())
        End If
    End Sub
End Module
