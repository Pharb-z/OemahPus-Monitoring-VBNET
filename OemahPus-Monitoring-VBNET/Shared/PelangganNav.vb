Imports System.Windows.Forms

' Menu + logout handling dipakai semua form Pelanggan, supaya tidak duplikat handler.
Module PelangganNav
    Public Sub Wire(f As Form, dashboard As Button, profil As Button, tracking As Button,
                    reservasi As Button, riwayat As Button, akun As Button, logout As Button)
        AddHandler dashboard.Click, Sub(s As Object, e As EventArgs)
                                        Navigator.Go(f, "dashboard", Function() New FormDashboard())
                                    End Sub
        AddHandler profil.Click, Sub(s As Object, e As EventArgs)
                                     Navigator.Go(f, "profil", Function() New FormProfilKucing())
                                 End Sub
        AddHandler tracking.Click, Sub(s As Object, e As EventArgs)
                                       Navigator.Go(f, "tracking", Function() New FormPetTracking())
                                   End Sub
        AddHandler reservasi.Click, Sub(s As Object, e As EventArgs)
                                        Navigator.Go(f, "reservasiPelanggan", Function() New FormReservasiWizard())
                                    End Sub
        AddHandler riwayat.Click, Sub(s As Object, e As EventArgs)
                                      Navigator.Go(f, "riwayat", Function() New FormRiwayat())
                                  End Sub
        AddHandler akun.Click, Sub(s As Object, e As EventArgs)
                                   Navigator.Go(f, "akun", Function() New FormAkunSaya())
                               End Sub
        AddHandler logout.Click, Sub(s As Object, e As EventArgs)
                                     If MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
                                     Navigator.Clear()
                                     FormLogin.Show()
                                     f.Close()
                                 End Sub
    End Sub
End Module
