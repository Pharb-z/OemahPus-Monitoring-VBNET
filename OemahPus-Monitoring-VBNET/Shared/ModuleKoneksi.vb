Imports MySql.Data.MySqlClient

Module ModuleKoneksi
    ' Connection String disesuaikan dengan host 127.0.0.1 dan port 3306
    Public strKoneksi As String = "server=127.0.0.1;port=3306;user id=root;password=;database=OmiDB"
    Public koneksi As MySqlConnection

    ' Sub untuk membuka koneksi ke database
    Public Sub BukaKoneksi()
        Try
            ' Mengecek apakah koneksi belum ada atau sedang tertutup
            If koneksi Is Nothing OrElse koneksi.State = ConnectionState.Closed Then
                koneksi = New MySqlConnection(strKoneksi)
                koneksi.Open()
            End If
        Catch ex As Exception
            ' Pesan ini akan muncul jika koneksi gagal (misalnya MySQL belum dinyalakan)
            MessageBox.Show("Gagal terhubung ke database: " & ex.Message, "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Sub untuk menutup koneksi database
    Public Sub TutupKoneksi()
        Try
            If koneksi IsNot Nothing AndAlso koneksi.State = ConnectionState.Open Then
                koneksi.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menutup koneksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module