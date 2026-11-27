<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomerEdit
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
        Me.btnMenuLayanan = New Button()
        Me.btnMenuCustomer = New Button()
        Me.btnMenuPemeriksaanKucing = New Button()
        Me.btnMenuReservasi = New Button()
        Me.btnMenuLaporan = New Button()
        Me.btnMenuAkun = New Button()
        Me.btnLogout = New Button()
        Me.Panel2 = New Panel()
        Me.lblJudul = New Label()
        Me.Panel3 = New Panel()
        Me.pnlCard = New Panel()
        Me.Label3 = New Label()
        Me.txtNamaLengkap = New TextBox()
        Me.Label4 = New Label()
        Me.txtEmail = New TextBox()
        Me.Label5 = New Label()
        Me.txtNoTelepon = New TextBox()
        Me.Label6 = New Label()
        Me.txtAlamat = New TextBox()
        Me.btnSimpan = New Button()
        Me.btnBatal = New Button()
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
        Me.Panel1.Controls.Add(Me.btnMenuLaporan)
        Me.Panel1.Controls.Add(Me.btnMenuReservasi)
        Me.Panel1.Controls.Add(Me.btnMenuPemeriksaanKucing)
        Me.Panel1.Controls.Add(Me.btnMenuCustomer)
        Me.Panel1.Controls.Add(Me.btnMenuLayanan)
        Me.Panel1.Controls.Add(Me.btnMenuDashboard)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New Point(10, 10)
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
        Me.btnMenuDashboard.Name = "btnMenuDashboard"
        Me.btnMenuDashboard.Size = New Size(165, 37)
        Me.btnMenuDashboard.TabIndex = 2
        Me.btnMenuDashboard.Text = "Dashboard"
        Me.btnMenuDashboard.UseVisualStyleBackColor = False
        '
        ' btnMenuLayanan
        '
        Me.btnMenuLayanan.BackColor = Color.Plum
        Me.btnMenuLayanan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuLayanan.ForeColor = Color.SeaShell
        Me.btnMenuLayanan.Location = New Point(38, 220)
        Me.btnMenuLayanan.Name = "btnMenuLayanan"
        Me.btnMenuLayanan.Size = New Size(165, 37)
        Me.btnMenuLayanan.TabIndex = 3
        Me.btnMenuLayanan.Text = "Paket Layanan"
        Me.btnMenuLayanan.UseVisualStyleBackColor = False
        '
        ' btnMenuCustomer
        '
        Me.btnMenuCustomer.BackColor = Color.Plum
        Me.btnMenuCustomer.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuCustomer.ForeColor = Color.DarkOliveGreen
        Me.btnMenuCustomer.Location = New Point(38, 280)
        Me.btnMenuCustomer.Name = "btnMenuCustomer"
        Me.btnMenuCustomer.Size = New Size(165, 37)
        Me.btnMenuCustomer.TabIndex = 4
        Me.btnMenuCustomer.Text = "Customer"
        Me.btnMenuCustomer.UseVisualStyleBackColor = False
        '
        ' btnMenuPemeriksaanKucing
        '
        Me.btnMenuPemeriksaanKucing.BackColor = Color.Plum
        Me.btnMenuPemeriksaanKucing.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuPemeriksaanKucing.ForeColor = Color.SeaShell
        Me.btnMenuPemeriksaanKucing.Location = New Point(38, 340)
        Me.btnMenuPemeriksaanKucing.Name = "btnMenuPemeriksaanKucing"
        Me.btnMenuPemeriksaanKucing.Size = New Size(165, 37)
        Me.btnMenuPemeriksaanKucing.TabIndex = 5
        Me.btnMenuPemeriksaanKucing.Text = "Pemeriksaan Kucing"
        Me.btnMenuPemeriksaanKucing.UseVisualStyleBackColor = False
        '
        ' btnMenuReservasi
        '
        Me.btnMenuReservasi.BackColor = Color.Plum
        Me.btnMenuReservasi.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuReservasi.ForeColor = Color.SeaShell
        Me.btnMenuReservasi.Location = New Point(38, 400)
        Me.btnMenuReservasi.Name = "btnMenuReservasi"
        Me.btnMenuReservasi.Size = New Size(165, 37)
        Me.btnMenuReservasi.TabIndex = 6
        Me.btnMenuReservasi.Text = "Reservasi"
        Me.btnMenuReservasi.UseVisualStyleBackColor = False
        '
        ' btnMenuLaporan
        '
        Me.btnMenuLaporan.BackColor = Color.Plum
        Me.btnMenuLaporan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuLaporan.ForeColor = Color.SeaShell
        Me.btnMenuLaporan.Location = New Point(38, 460)
        Me.btnMenuLaporan.Name = "btnMenuLaporan"
        Me.btnMenuLaporan.Size = New Size(165, 37)
        Me.btnMenuLaporan.TabIndex = 7
        Me.btnMenuLaporan.Text = "Laporan"
        Me.btnMenuLaporan.UseVisualStyleBackColor = False
        '
        ' btnMenuAkun
        '
        Me.btnMenuAkun.BackColor = Color.Plum
        Me.btnMenuAkun.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuAkun.ForeColor = Color.SeaShell
        Me.btnMenuAkun.Location = New Point(38, 520)
        Me.btnMenuAkun.Name = "btnMenuAkun"
        Me.btnMenuAkun.Size = New Size(165, 37)
        Me.btnMenuAkun.TabIndex = 8
        Me.btnMenuAkun.Text = "Akun Saya"
        Me.btnMenuAkun.UseVisualStyleBackColor = False
        '
        ' btnLogout
        '
        Me.btnLogout.BackColor = Color.Plum
        Me.btnLogout.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnLogout.ForeColor = Color.SeaShell
        Me.btnLogout.Location = New Point(38, 580)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New Size(165, 37)
        Me.btnLogout.TabIndex = 9
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        ' Panel2
        '
        Me.Panel2.BackColor = Color.LightGoldenrodYellow
        Me.Panel2.Controls.Add(Me.lblJudul)
        Me.Panel2.Location = New Point(256, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(890, 84)
        Me.Panel2.TabIndex = 10
        '
        ' lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblJudul.ForeColor = Color.DarkOliveGreen
        Me.lblJudul.Location = New Point(16, 16)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New Size(400, 46)
        Me.lblJudul.TabIndex = 11
        Me.lblJudul.Text = "Tambah Customer"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnBatal)
        Me.Panel3.Controls.Add(Me.btnSimpan)
        Me.Panel3.Controls.Add(Me.txtAlamat)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtNoTelepon)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtEmail)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtNamaLengkap)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.pnlCard)
        Me.Panel3.Location = New Point(256, 94)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Size(890, 554)
        Me.Panel3.TabIndex = 12
        ' 
        ' pnlCard
        ' 
        Me.pnlCard.BackColor = Color.White
        Me.pnlCard.BorderStyle = BorderStyle.FixedSingle
        Me.pnlCard.Location = New Point(16, 16)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New Size(858, 522)
        Me.pnlCard.TabIndex = 13
        '
        ' Label3
        '
        Me.Label3.AutoSize = False
        Me.Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label3.ForeColor = Color.DarkOliveGreen
        Me.Label3.Location = New Point(60, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(380, 23)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Nama Lengkap"
        '
        ' txtNamaLengkap
        '
        Me.txtNamaLengkap.BackColor = Color.White
        Me.txtNamaLengkap.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtNamaLengkap.ForeColor = Color.DarkOliveGreen
        Me.txtNamaLengkap.Location = New Point(60, 58)
        Me.txtNamaLengkap.Name = "txtNamaLengkap"
        Me.txtNamaLengkap.Size = New Size(380, 30)
        Me.txtNamaLengkap.TabIndex = 15
        '
        ' Label4
        '
        Me.Label4.AutoSize = False
        Me.Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label4.ForeColor = Color.DarkOliveGreen
        Me.Label4.Location = New Point(480, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(350, 23)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Email"
        '
        ' txtEmail
        '
        Me.txtEmail.BackColor = Color.White
        Me.txtEmail.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtEmail.ForeColor = Color.DarkOliveGreen
        Me.txtEmail.Location = New Point(480, 58)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New Size(350, 30)
        Me.txtEmail.TabIndex = 17
        '
        ' Label5
        '
        Me.Label5.AutoSize = False
        Me.Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label5.ForeColor = Color.DarkOliveGreen
        Me.Label5.Location = New Point(60, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(380, 23)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "No Telepon"
        '
        ' txtNoTelepon
        '
        Me.txtNoTelepon.BackColor = Color.White
        Me.txtNoTelepon.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtNoTelepon.ForeColor = Color.DarkOliveGreen
        Me.txtNoTelepon.Location = New Point(60, 156)
        Me.txtNoTelepon.Name = "txtNoTelepon"
        Me.txtNoTelepon.Size = New Size(380, 30)
        Me.txtNoTelepon.TabIndex = 19
        '
        ' Label6
        '
        Me.Label6.AutoSize = False
        Me.Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label6.ForeColor = Color.DarkOliveGreen
        Me.Label6.Location = New Point(60, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(770, 23)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Alamat"
        '
        ' txtAlamat
        '
        Me.txtAlamat.BackColor = Color.White
        Me.txtAlamat.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtAlamat.ForeColor = Color.DarkOliveGreen
        Me.txtAlamat.Location = New Point(60, 254)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.ScrollBars = ScrollBars.Vertical
        Me.txtAlamat.Size = New Size(770, 100)
        Me.txtAlamat.TabIndex = 21
        '
        ' btnSimpan
        '
        Me.btnSimpan.BackColor = Color.MediumVioletRed
        Me.btnSimpan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnSimpan.ForeColor = Color.SeaShell
        Me.btnSimpan.Location = New Point(60, 390)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New Size(180, 40)
        Me.btnSimpan.TabIndex = 22
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        ' btnBatal
        '
        Me.btnBatal.BackColor = Color.LightGoldenrodYellow
        Me.btnBatal.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnBatal.ForeColor = Color.DarkOliveGreen
        Me.btnBatal.Location = New Point(260, 390)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New Size(180, 40)
        Me.btnBatal.TabIndex = 23
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        ' FormCustomerEdit
        '
        Me.AutoScaleDimensions = New SizeF(8F, 20F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1156, 658)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCustomerEdit"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Customer"
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
    Friend WithEvents lblJudul As Label
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents btnMenuPemeriksaanKucing As Button
    Friend WithEvents btnMenuReservasi As Button
    Friend WithEvents btnMenuLaporan As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNamaLengkap As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNoTelepon As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBatal As Button
End Class