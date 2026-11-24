' Ponytail: nomor dokumen harian dari number_sequences.
' Upgrade path: kalau butuh atomik lintas proses, bungkus transaksi MySqlTransaction.
Module DocNumber
    Public Function NextNo(prefix As String) As String
        Dim key As String = Today.ToString("yyyyMMdd")
        Exec("INSERT INTO number_sequences (prefix, seq_date, last_number) VALUES (@p, @d, 1) " &
             "ON DUPLICATE KEY UPDATE last_number = last_number + 1",
             P("@p", prefix), P("@d", Today))
        Dim n As Integer = Convert.ToInt32(Scalar(
            "SELECT last_number FROM number_sequences WHERE prefix=@p AND seq_date=@d",
            P("@p", prefix), P("@d", Today)))
        Return prefix & key & n.ToString("D4")
    End Function
End Module
