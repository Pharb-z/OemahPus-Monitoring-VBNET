Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Module DatabaseHelper
    Private Function OpenConnection() As MySqlConnection
        Dim connection As New MySqlConnection(ModuleKoneksi.strKoneksi)
        connection.Open()
        Return connection
    End Function

    Public Sub EnsureDatabaseSchema()
        Using connection As MySqlConnection = OpenConnection()
            Using command As New MySqlCommand(
                "CREATE TABLE IF NOT EXISTS customers (" &
                "customer_id INT NOT NULL AUTO_INCREMENT, " &
                "full_name VARCHAR(100) NOT NULL, " &
                "phone VARCHAR(25) NOT NULL, " &
                "address VARCHAR(255) NOT NULL, " &
                "username VARCHAR(50) NOT NULL, " &
                "email VARCHAR(120) NOT NULL, " &
                "PRIMARY KEY (customer_id), " &
                "UNIQUE KEY uq_customers_username (username), " &
                "UNIQUE KEY uq_customers_email (email)" &
                ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4", connection)
                command.ExecuteNonQuery()
            End Using

            Using command As New MySqlCommand(
                "CREATE TABLE IF NOT EXISTS services (" &
                "service_id INT NOT NULL AUTO_INCREMENT, " &
                "service_name VARCHAR(100) NOT NULL, " &
                "service_type VARCHAR(50) NOT NULL, " &
                "price DECIMAL(15,2) NOT NULL DEFAULT 0, " &
                "unit VARCHAR(50) NOT NULL, " &
                "is_active TINYINT(1) NOT NULL DEFAULT 1, " &
                "PRIMARY KEY (service_id), " &
                "UNIQUE KEY uq_services_name (service_name)" &
                ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4", connection)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function P(name As String, value As Object) As MySqlParameter
        Return New MySqlParameter(name, If(value Is Nothing, DBNull.Value, value))
    End Function

    Public Function GetTable(sql As String, ParamArray parameters() As MySqlParameter) As DataTable
        Using connection As MySqlConnection = OpenConnection(), command As New MySqlCommand(sql, connection)
            If parameters IsNot Nothing Then command.Parameters.AddRange(parameters)
            Using adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function

    Public Function Scalar(sql As String, ParamArray parameters() As MySqlParameter) As Object
        Using connection As MySqlConnection = OpenConnection(), command As New MySqlCommand(sql, connection)
            If parameters IsNot Nothing Then command.Parameters.AddRange(parameters)
            Return command.ExecuteScalar()
        End Using
    End Function

    Public Function Exec(sql As String, ParamArray parameters() As MySqlParameter) As Integer
        Using connection As MySqlConnection = OpenConnection(), command As New MySqlCommand(sql, connection)
            If parameters IsNot Nothing Then command.Parameters.AddRange(parameters)
            Return command.ExecuteNonQuery()
        End Using
    End Function
End Module

Module Navigator
    Private ReadOnly forms As New Dictionary(Of String, Form)()

    Public Sub Register(key As String, form As Form)
        If String.IsNullOrWhiteSpace(key) OrElse form Is Nothing Then Return
        forms(key) = form
    End Sub

    Public Function GetRegistered(key As String) As Form
        Dim form As Form = Nothing
        If forms.TryGetValue(key, form) AndAlso Not form.IsDisposed Then Return form
        forms.Remove(key)
        Return Nothing
    End Function

    Public Sub NavigateTo(current As Form, key As String)
        Dim target As Form = GetRegistered(key)
        If target Is Nothing Then Return
        If target Is current Then Return
        target.Show()
        current.Hide()
    End Sub
End Module
