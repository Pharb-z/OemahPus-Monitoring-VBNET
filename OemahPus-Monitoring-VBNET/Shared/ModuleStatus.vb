Imports System.Drawing

' ponytail: warna badge status, tiru omiStatusBadge di prototipe.
' Conek: ganti lookup ini kalau Figma token dipakai di WinForms.
Module ModuleStatus
    Public Function BackColor(status As String) As Color
        Select Case status
            Case "Selesai", "Disetujui", "Valid", "Lunas", "Sehat", "Tersedia", "Dijadwalkan"
                Return Color.FromArgb(198, 239, 206)
            Case "Menunggu", "Perlu Perhatian", "Perawatan", "Tidak Valid"
                Return Color.FromArgb(255, 235, 156)
            Case "Berlangsung", "Terisi", "CheckIn", "Dalam Perjalanan", "Dikonfirmasi"
                Return Color.FromArgb(255, 242, 204)
            Case "Dibatalkan", "Ditolak", "Sakit"
                Return Color.FromArgb(255, 199, 206)
            Case Else
                Return Color.FromArgb(217, 217, 217)
        End Select
    End Function
End Module
