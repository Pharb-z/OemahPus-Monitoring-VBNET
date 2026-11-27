Module ModuleAccess
    ' ponytail: menu visibility only; reservasi hanya untuk Pelanggan, kurir pakai slot Jadwal.
    Public Function CanView(menuKey As String) As Boolean
        If String.Equals(menuKey, "dashboard", StringComparison.OrdinalIgnoreCase) Then Return True

        Select Case UserSession.CurrentRole
            Case "Owner"
                Return menuKey = "layanan" OrElse menuKey = "customer" OrElse menuKey = "medis" OrElse
                       menuKey = "laporan" OrElse menuKey = "akun"
            Case "StafOperasional"
                Return menuKey = "customer" OrElse menuKey = "medis" OrElse menuKey = "akun"
            Case "StafAntarJemput"
                Return menuKey = "reservasi" OrElse menuKey = "akun"
            Case "Pelanggan"
                Return menuKey = "profil" OrElse menuKey = "reservasiPelanggan" OrElse
                       menuKey = "riwayat" OrElse menuKey = "akun" OrElse menuKey = "tracking"
            Case Else
                Return False
        End Select
    End Function

    Public Sub ApplyMenuAccess(ParamArray buttons As Button())
        For Each button In buttons
            If button Is Nothing Then Continue For

            Dim key As String = String.Empty
            Select Case button.Name
                Case "btnMenuDashboard" : key = "dashboard"
                Case "btnMenuLayanan" : key = "layanan"
                Case "btnMenuCustomer" : key = "customer"
                Case "btnMenuPemeriksaanKucing" : key = "medis"
                Case "btnMenuReservasi" : key = "reservasi"
                Case "btnMenuLaporan" : key = "laporan"
                Case "btnMenuProfil" : key = "profil"
                Case "btnMenuReservasiPelanggan" : key = "reservasiPelanggan"
                Case "btnMenuRiwayat" : key = "riwayat"
                Case "btnMenuAkun" : key = "akun"
                Case "btnMenuTracking" : key = "tracking"
            End Select

            button.Visible = CanView(key)
        Next
    End Sub

#If DEBUG Then
    Public Sub SelfCheck()
        Dim saved As String = UserSession.CurrentRole
        UserSession.CurrentRole = "Owner"
        System.Diagnostics.Debug.Assert(CanView("layanan") AndAlso CanView("laporan"))
        System.Diagnostics.Debug.Assert(Not CanView("reservasi"))
        UserSession.CurrentRole = "StafOperasional"
        System.Diagnostics.Debug.Assert(Not CanView("layanan") AndAlso CanView("medis") AndAlso CanView("akun"))
        System.Diagnostics.Debug.Assert(Not CanView("reservasi"))
        UserSession.CurrentRole = "StafAntarJemput"
        System.Diagnostics.Debug.Assert(Not CanView("customer") AndAlso CanView("reservasi"))
        UserSession.CurrentRole = "Pelanggan"
        System.Diagnostics.Debug.Assert(Not CanView("laporan") AndAlso CanView("profil"))
        System.Diagnostics.Debug.Assert(CanView("tracking") AndAlso Not CanView("customer"))
        System.Diagnostics.Debug.Assert(CanView("akun"))
        UserSession.CurrentRole = saved
    End Sub
#End If
End Module
