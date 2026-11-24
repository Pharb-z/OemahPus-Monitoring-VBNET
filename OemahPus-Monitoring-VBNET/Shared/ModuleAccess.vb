Module ModuleAccess
    ' ponytail: menu visibility only; action-level RBAC (read-only form mode) comes with FormReservasi step.
    Public Function CanView(menuKey As String) As Boolean
        If String.Equals(menuKey, "dashboard", StringComparison.OrdinalIgnoreCase) Then Return True

        Select Case UserSession.CurrentRole
            Case "Owner"
                Return True
            Case "StafOperasional"
                Return menuKey = "customer" OrElse menuKey = "medis" OrElse menuKey = "reservasi"
            Case "StafAntarJemput"
                Return menuKey = "reservasi"
            Case "Pelanggan"
                Return menuKey = "profil" OrElse menuKey = "reservasiPelanggan" OrElse
                       menuKey = "riwayat" OrElse menuKey = "akun"
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
            End Select

            button.Visible = CanView(key)
        Next
    End Sub

#If DEBUG Then
    Public Sub SelfCheck()
        Dim saved As String = UserSession.CurrentRole
        UserSession.CurrentRole = "Owner"
        System.Diagnostics.Debug.Assert(CanView("layanan") AndAlso CanView("laporan"))
        UserSession.CurrentRole = "StafOperasional"
        System.Diagnostics.Debug.Assert(Not CanView("layanan") AndAlso CanView("medis"))
        UserSession.CurrentRole = "StafAntarJemput"
        System.Diagnostics.Debug.Assert(Not CanView("customer") AndAlso CanView("reservasi"))
        UserSession.CurrentRole = "Pelanggan"
        System.Diagnostics.Debug.Assert(Not CanView("laporan") AndAlso CanView("profil"))
        UserSession.CurrentRole = saved
    End Sub
#End If
End Module
