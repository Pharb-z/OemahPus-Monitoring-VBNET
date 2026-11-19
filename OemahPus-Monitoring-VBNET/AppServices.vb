Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

''' <summary>
''' Helper akses database. Skema tabel dikelola lewat script
''' backup_OMIDB.sql (bukan dibuat otomatis oleh aplikasi), sehingga
''' di sini hanya tersedia fungsi query.
''' </summary>
Module DatabaseHelper
    Private Function OpenConnection() As MySqlConnection
        Dim connection As New MySqlConnection(ModuleKoneksi.strKoneksi)
        connection.Open()
        Return connection
    End Function

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
    Private _suppressRefresh As String = String.Empty

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

    ''' <summary>
    ''' Menandai bahwa form tujuan baru saja dinavigasi dari form sumber,
    ''' sehingga form sumber tidak perlu memuat ulang datanya saat kembali.
    ''' </summary>
    Public Sub MarkNavigatedFrom(sourceKey As String)
        _suppressRefresh = If(sourceKey, String.Empty)
    End Sub

    ''' <summary>
    ''' Dipanggil form saat kembali terlihat. Mengembalikan True jika form ini
    ''' adalah tujuan navigasi terakhir dan datanya sebaiknya tidak di-refresh.
    ''' </summary>
    Public Function ConsumeSuppressRefresh(forKey As String) As Boolean
        If _suppressRefresh = String.Empty Then Return False
        Dim suppress As Boolean = String.Equals(_suppressRefresh, forKey, StringComparison.Ordinal)
        _suppressRefresh = String.Empty
        Return suppress
    End Function

    Public Sub NavigateTo(current As Form, key As String)
        Dim target As Form = GetRegistered(key)
        If target Is Nothing Then Return
        If target Is current Then Return
        target.Show()
        current.Hide()
    End Sub

    Public Sub Go(current As Form, key As String, create As Func(Of Form))
        Go(current, key, create, String.Empty)
    End Sub

    ''' <summary>
    ''' Menampilkan form tujuan. Jika form belum terdaftar, form dibuat lewat
    ''' <paramref name="create"/> lalu didaftarkan (sebelum ditampilkan), sehingga
    ''' pemanggil tetap bisa mengisi data form terlebih dahulu.
    ''' </summary>
    Public Sub Go(current As Form, key As String, create As Func(Of Form), sourceKey As String)
        Dim target As Form = GetRegistered(key)
        If target Is Nothing Then
            target = create()
            Register(key, target)
        End If
        If target Is current Then Return
        target.Show()
        If current IsNot Nothing Then current.Hide()
        If Not String.IsNullOrWhiteSpace(sourceKey) Then MarkNavigatedFrom(sourceKey)
    End Sub

    ''' <summary>Menampilkan form yang sudah dibuat/diisi tanpa membuat ulang.</summary>
    Public Sub GoWithInstance(current As Form, key As String, target As Form, sourceKey As String)
        If target Is Nothing Then Return
        Register(key, target)
        If target Is current Then Return
        target.Show()
        If current IsNot Nothing Then current.Hide()
        If Not String.IsNullOrWhiteSpace(sourceKey) Then MarkNavigatedFrom(sourceKey)
    End Sub
End Module
