Imports System.Windows.Forms

' Utility kecil: bikin hash BCrypt untuk password baru di OMI.
' Output sengaja ditulis ke Console supaya muncul di terminal saat dijalankan dotnet run.
Public Class FormHash
    Inherits Form

    Private txtInput As TextBox
    Private btnHash As Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "BCrypt Hash Generator"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.ClientSize = New System.Drawing.Size(420, 170)

        Dim lbl As New Label() With {
            .Text = "Password:",
            .Location = New System.Drawing.Point(20, 24),
            .AutoSize = True,
            .Font = New System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
        }
        txtInput = New TextBox() With {
            .Location = New System.Drawing.Point(20, 50),
            .Size = New System.Drawing.Size(360, 30),
            .PasswordChar = "*"c,
            .Font = New System.Drawing.Font("Segoe UI", 10F)
        }
        btnHash = New Button() With {
            .Text = "Hash",
            .Location = New System.Drawing.Point(20, 100),
            .Size = New System.Drawing.Size(120, 36),
            .Font = New System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
        }
        AddHandler btnHash.Click, AddressOf btnHash_Click

        Me.Controls.Add(lbl)
        Me.Controls.Add(txtInput)
        Me.Controls.Add(btnHash)
        Me.AcceptButton = btnHash
    End Sub

    Private Sub btnHash_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtInput.Text) Then
            MessageBox.Show("Isi password dulu.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' workFactor 11 -> $2a$11$..., sama dengan hash seed di perbaikan_hash.sql.
        Dim hash As String = BCrypt.Net.BCrypt.HashPassword(txtInput.Text, 11)
        Console.WriteLine("Plain : " & txtInput.Text)
        Console.WriteLine("BCrypt: " & hash)
        Console.WriteLine()
    End Sub
End Class
