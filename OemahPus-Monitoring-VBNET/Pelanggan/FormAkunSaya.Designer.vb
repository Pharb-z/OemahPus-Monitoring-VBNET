<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAkunSaya
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New Panel()
        Me.Label1 = New Label()
        Me.btnMenuDashboard = New Button()
        Me.btnMenuProfil = New Button()
        Me.btnMenuTracking = New Button()
        Me.btnMenuReservasiPelanggan = New Button()
        Me.btnMenuRiwayat = New Button()
        Me.btnMenuAkun = New Button()
        Me.btnLogout = New Button()
        Me.Panel2 = New Panel()
        Me.Label2 = New Label()
        Me.Panel3 = New Panel()
        Me.pnlCard = New Panel()
        Me.Label3 = New Label()
        Me.txtNama = New TextBox()
        Me.Label4 = New Label()
        Me.txtUsername = New TextBox()
        Me.Label5 = New Label()
        Me.txtPassLama = New TextBox()
        Me.Label6 = New Label()
        Me.txtPassBaru = New TextBox()
        Me.Label7 = New Label()
        Me.txtKonfirmasi = New TextBox()
        Me.btnSimpan = New Button()
        Me.lblInfo = New Label()
        Me.lblTelepon = New Label()
        Me.txtTelepon = New TextBox()
        Me.lblEmail = New Label()
        Me.txtEmail = New TextBox()
        Me.lblAlamat = New Label()
        Me.txtAlamat = New TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        ' Panel1
        '
        Me.Panel1.BackColor = Color.SeaShell
        Me.Panel1.Controls.Add(Me.btnLogout)
        Me.Panel1.Controls.Add(Me.btnMenuAkun)
        Me.Panel1.Controls.Add(Me.btnMenuRiwayat)
        Me.Panel1.Controls.Add(Me.btnMenuReservasiPelanggan)
        Me.Panel1.Controls.Add(Me.btnMenuProfil)
        Me.Panel1.Controls.Add(Me.btnMenuTracking)
        Me.Panel1.Controls.Add(Me.btnMenuDashboard)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New Point(10, 10)
        Me.Panel1.Margin = New Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(246, 638)
        Me.Panel1.TabIndex = 0
        '
        ' Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Snap ITC", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.Label1.ForeColor = Color.Plum
        Me.Label1.Location = New Point(29, 50)
        Me.Label1.Margin = New Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(181, 77)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OMI"
        '
        ' btnMenuDashboard
        '
        Me.btnMenuDashboard.BackColor = Color.Plum
        Me.btnMenuDashboard.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuDashboard.ForeColor = Color.SeaShell
        Me.btnMenuDashboard.Location = New Point(38, 160)
        Me.btnMenuDashboard.Margin = New Padding(2)
        Me.btnMenuDashboard.Name = "btnMenuDashboard"
        Me.btnMenuDashboard.Size = New Size(165, 37)
        Me.btnMenuDashboard.TabIndex = 2
        Me.btnMenuDashboard.Text = "Dashboard"
        Me.btnMenuDashboard.UseVisualStyleBackColor = False
        '
        ' btnMenuProfil
        '
        Me.btnMenuProfil.BackColor = Color.Plum
        Me.btnMenuProfil.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuProfil.ForeColor = Color.DarkOliveGreen
        Me.btnMenuProfil.Location = New Point(38, 220)
        Me.btnMenuProfil.Margin = New Padding(2)
        Me.btnMenuProfil.Name = "btnMenuProfil"
        Me.btnMenuProfil.Size = New Size(165, 37)
        Me.btnMenuProfil.TabIndex = 3
        Me.btnMenuProfil.Text = "Profil Kucing"
        Me.btnMenuProfil.UseVisualStyleBackColor = False
        '
        ' btnMenuTracking
        '
        Me.btnMenuTracking.BackColor = Color.Plum
        Me.btnMenuTracking.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuTracking.ForeColor = Color.SeaShell
        Me.btnMenuTracking.Location = New Point(38, 280)
        Me.btnMenuTracking.Margin = New Padding(2)
        Me.btnMenuTracking.Name = "btnMenuTracking"
        Me.btnMenuTracking.Size = New Size(165, 37)
        Me.btnMenuTracking.TabIndex = 4
        Me.btnMenuTracking.Text = "Pet Tracking"
        Me.btnMenuTracking.UseVisualStyleBackColor = False
        '
        ' btnMenuReservasiPelanggan
        '
        Me.btnMenuReservasiPelanggan.BackColor = Color.Plum
        Me.btnMenuReservasiPelanggan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuReservasiPelanggan.ForeColor = Color.SeaShell
        Me.btnMenuReservasiPelanggan.Location = New Point(38, 340)
        Me.btnMenuReservasiPelanggan.Margin = New Padding(2)
        Me.btnMenuReservasiPelanggan.Name = "btnMenuReservasiPelanggan"
        Me.btnMenuReservasiPelanggan.Size = New Size(165, 37)
        Me.btnMenuReservasiPelanggan.TabIndex = 5
        Me.btnMenuReservasiPelanggan.Text = "Reservasi"
        Me.btnMenuReservasiPelanggan.UseVisualStyleBackColor = False
        '
        ' btnMenuRiwayat
        '
        Me.btnMenuRiwayat.BackColor = Color.Plum
        Me.btnMenuRiwayat.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuRiwayat.ForeColor = Color.SeaShell
        Me.btnMenuRiwayat.Location = New Point(38, 400)
        Me.btnMenuRiwayat.Margin = New Padding(2)
        Me.btnMenuRiwayat.Name = "btnMenuRiwayat"
        Me.btnMenuRiwayat.Size = New Size(165, 37)
        Me.btnMenuRiwayat.TabIndex = 6
        Me.btnMenuRiwayat.Text = "Riwayat"
        Me.btnMenuRiwayat.UseVisualStyleBackColor = False
        '
        ' btnMenuAkun
        '
        Me.btnMenuAkun.BackColor = Color.Plum
        Me.btnMenuAkun.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuAkun.ForeColor = Color.SeaShell
        Me.btnMenuAkun.Location = New Point(38, 460)
        Me.btnMenuAkun.Margin = New Padding(2)
        Me.btnMenuAkun.Name = "btnMenuAkun"
        Me.btnMenuAkun.Size = New Size(165, 37)
        Me.btnMenuAkun.TabIndex = 7
        Me.btnMenuAkun.Text = "Akun Saya"
        Me.btnMenuAkun.UseVisualStyleBackColor = False
        '
        ' btnLogout
        '
        Me.btnLogout.BackColor = Color.Plum
        Me.btnLogout.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnLogout.ForeColor = Color.SeaShell
        Me.btnLogout.Location = New Point(38, 520)
        Me.btnLogout.Margin = New Padding(2)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New Size(165, 37)
        Me.btnLogout.TabIndex = 8
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        ' Panel2
        '
        Me.Panel2.BackColor = Color.LightGoldenrodYellow
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New Point(256, 10)
        Me.Panel2.Margin = New Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(890, 84)
        Me.Panel2.TabIndex = 9
        '
        ' Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label2.ForeColor = Color.DarkOliveGreen
        Me.Label2.Location = New Point(16, 16)
        Me.Label2.Margin = New Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(400, 46)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Akun Saya"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.lblInfo)
        Me.Panel3.Controls.Add(Me.btnSimpan)
        Me.Panel3.Controls.Add(Me.txtAlamat)
        Me.Panel3.Controls.Add(Me.lblAlamat)
        Me.Panel3.Controls.Add(Me.txtEmail)
        Me.Panel3.Controls.Add(Me.lblEmail)
        Me.Panel3.Controls.Add(Me.txtTelepon)
        Me.Panel3.Controls.Add(Me.lblTelepon)
        Me.Panel3.Controls.Add(Me.txtKonfirmasi)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtPassBaru)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtPassLama)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtUsername)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtNama)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.pnlCard)
        Me.Panel3.Location = New Point(256, 94)
        Me.Panel3.Margin = New Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Size(890, 554)
        Me.Panel3.TabIndex = 11
        ' 
        ' pnlCard
        ' 
        Me.pnlCard.BackColor = Color.White
        Me.pnlCard.BorderStyle = BorderStyle.FixedSingle
        Me.pnlCard.Location = New Point(16, 16)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New Size(858, 522)
        Me.pnlCard.TabIndex = 12
        '
        ' Label3
        '
        Me.Label3.AutoSize = False
        Me.Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label3.ForeColor = Color.DarkOliveGreen
        Me.Label3.Location = New Point(24, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(250, 23)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nama Lengkap"
        '
        ' txtNama
        '
        Me.txtNama.BackColor = Color.White
        Me.txtNama.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtNama.ForeColor = Color.DarkOliveGreen
        Me.txtNama.Location = New Point(24, 86)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New Size(400, 30)
        Me.txtNama.TabIndex = 14
        Me.txtNama.Text = ""
        '
        ' Label4
        '
        Me.Label4.AutoSize = False
        Me.Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label4.ForeColor = Color.DarkOliveGreen
        Me.Label4.Location = New Point(24, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(250, 23)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Username"
        '
        ' txtUsername
        '
        Me.txtUsername.BackColor = Color.White
        Me.txtUsername.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtUsername.ForeColor = Color.DarkOliveGreen
        Me.txtUsername.Location = New Point(24, 154)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New Size(400, 30)
        Me.txtUsername.TabIndex = 16
        Me.txtUsername.Text = ""
        '
        ' Label5
        '
        Me.Label5.AutoSize = False
        Me.Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label5.ForeColor = Color.DarkOliveGreen
        Me.Label5.Location = New Point(24, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(250, 23)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Password Lama"
        '
        ' txtPassLama
        '
        Me.txtPassLama.BackColor = Color.White
        Me.txtPassLama.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtPassLama.ForeColor = Color.DarkOliveGreen
        Me.txtPassLama.Location = New Point(24, 234)
        Me.txtPassLama.Name = "txtPassLama"
        Me.txtPassLama.Size = New Size(300, 30)
        Me.txtPassLama.TabIndex = 18
        Me.txtPassLama.Text = ""
        '
        ' Label6
        '
        Me.Label6.AutoSize = False
        Me.Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label6.ForeColor = Color.DarkOliveGreen
        Me.Label6.Location = New Point(24, 274)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(250, 23)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Password Baru"
        '
        ' txtPassBaru
        '
        Me.txtPassBaru.BackColor = Color.White
        Me.txtPassBaru.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtPassBaru.ForeColor = Color.DarkOliveGreen
        Me.txtPassBaru.Location = New Point(24, 302)
        Me.txtPassBaru.Name = "txtPassBaru"
        Me.txtPassBaru.Size = New Size(300, 30)
        Me.txtPassBaru.TabIndex = 20
        Me.txtPassBaru.Text = ""
        '
        ' Label7
        '
        Me.Label7.AutoSize = False
        Me.Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label7.ForeColor = Color.DarkOliveGreen
        Me.Label7.Location = New Point(24, 342)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(250, 23)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Konfirmasi Password"
        '
        ' txtKonfirmasi
        '
        Me.txtKonfirmasi.BackColor = Color.White
        Me.txtKonfirmasi.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtKonfirmasi.ForeColor = Color.DarkOliveGreen
        Me.txtKonfirmasi.Location = New Point(24, 370)
        Me.txtKonfirmasi.Name = "txtKonfirmasi"
        Me.txtKonfirmasi.Size = New Size(300, 30)
        Me.txtKonfirmasi.TabIndex = 22
        Me.txtKonfirmasi.Text = ""
        '
        ' btnSimpan
        '
        Me.btnSimpan.BackColor = Color.MediumVioletRed
        Me.btnSimpan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnSimpan.ForeColor = Color.SeaShell
        Me.btnSimpan.Location = New Point(24, 440)
        Me.btnSimpan.Margin = New Padding(2)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New Size(220, 40)
        Me.btnSimpan.TabIndex = 23
        Me.btnSimpan.Text = "Simpan Perubahan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        ' lblInfo
        '
        Me.lblInfo.AutoSize = False
        Me.lblInfo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblInfo.ForeColor = Color.DarkOliveGreen
        Me.lblInfo.Location = New Point(280, 440)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New Size(560, 37)
        Me.lblInfo.TabIndex = 24
        Me.lblInfo.Text = "Isi kolom password untuk mengubah password."
        '
        ' lblTelepon
        '
        Me.lblTelepon.AutoSize = False
        Me.lblTelepon.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblTelepon.ForeColor = Color.DarkOliveGreen
        Me.lblTelepon.Location = New Point(450, 58)
        Me.lblTelepon.Name = "lblTelepon"
        Me.lblTelepon.Size = New Size(250, 23)
        Me.lblTelepon.TabIndex = 25
        Me.lblTelepon.Text = "Telepon"
        '
        ' txtTelepon
        '
        Me.txtTelepon.BackColor = Color.White
        Me.txtTelepon.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtTelepon.ForeColor = Color.DarkOliveGreen
        Me.txtTelepon.Location = New Point(450, 86)
        Me.txtTelepon.Name = "txtTelepon"
        Me.txtTelepon.Size = New Size(400, 30)
        Me.txtTelepon.TabIndex = 26
        Me.txtTelepon.Text = ""
        '
        ' lblEmail
        '
        Me.lblEmail.AutoSize = False
        Me.lblEmail.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblEmail.ForeColor = Color.DarkOliveGreen
        Me.lblEmail.Location = New Point(450, 126)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New Size(250, 23)
        Me.lblEmail.TabIndex = 27
        Me.lblEmail.Text = "Email"
        '
        ' txtEmail
        '
        Me.txtEmail.BackColor = Color.White
        Me.txtEmail.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtEmail.ForeColor = Color.DarkOliveGreen
        Me.txtEmail.Location = New Point(450, 154)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New Size(400, 30)
        Me.txtEmail.TabIndex = 28
        Me.txtEmail.Text = ""
        '
        ' lblAlamat
        '
        Me.lblAlamat.AutoSize = False
        Me.lblAlamat.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblAlamat.ForeColor = Color.DarkOliveGreen
        Me.lblAlamat.Location = New Point(450, 206)
        Me.lblAlamat.Name = "lblAlamat"
        Me.lblAlamat.Size = New Size(250, 23)
        Me.lblAlamat.TabIndex = 29
        Me.lblAlamat.Text = "Alamat"
        '
        ' txtAlamat
        '
        Me.txtAlamat.BackColor = Color.White
        Me.txtAlamat.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtAlamat.ForeColor = Color.DarkOliveGreen
        Me.txtAlamat.Location = New Point(450, 234)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New Size(400, 90)
        Me.txtAlamat.TabIndex = 30
        Me.txtAlamat.Text = ""
        '
        ' FormAkunSaya
        '
        Me.AutoScaleDimensions = New SizeF(8F, 20F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1156, 658)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New Padding(2)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAkunSaya"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Akun Saya"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlCard As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuProfil As Button
    Friend WithEvents btnMenuTracking As Button
    Friend WithEvents btnMenuReservasiPelanggan As Button
    Friend WithEvents btnMenuRiwayat As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPassLama As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPassBaru As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtKonfirmasi As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblInfo As Label
    Friend WithEvents lblTelepon As Label
    Friend WithEvents txtTelepon As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblAlamat As Label
    Friend WithEvents txtAlamat As TextBox
End Class
