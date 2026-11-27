' Satu sumber baris customers untuk user Pelanggan yang sedang login.
' Dipakai Profil Kucing, Wizard Reservasi, dan Akun Saya.
Module CustomerService
    Public Function EnsureCustomerId() As Integer
        Dim found As Object = Scalar(
            "SELECT customer_id FROM customers WHERE user_id=@uid",
            P("@uid", UserSession.CurrentUserId))
        If found IsNot Nothing AndAlso found IsNot DBNull.Value Then Return Convert.ToInt32(found)

        Exec("INSERT INTO customers (user_id, full_name, phone) VALUES (@uid, @nama, '-')",
             P("@uid", UserSession.CurrentUserId), P("@nama", UserSession.CurrentFullName))
        Return Convert.ToInt32(Scalar("SELECT LAST_INSERT_ID()"))
    End Function
End Module
