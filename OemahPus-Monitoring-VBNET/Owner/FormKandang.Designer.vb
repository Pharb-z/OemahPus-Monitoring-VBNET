<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKandang
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
        Me.Label2 = New Label()
        Me.Panel3 = New Panel()
        Me.pnlCard = New Panel()
        Me.dgvKandang = New DataGridView()
        Me.txtCari = New TextBox()
        Me.Label8 = New Label()
        Me.btnTambah = New Button()
        Me.btnUbah = New Button()
        Me.btnHapus = New Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvKandang, ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnMenuCustomer.Text = "Kandang"
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
        Me.btnMenuPemeriksaanKucing.Text = "Riwayat"
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
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New Point(256, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(890, 84)
        Me.Panel2.TabIndex = 10
        '
        ' Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label2.ForeColor = Color.DarkOliveGreen
        Me.Label2.Location = New Point(16, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(400, 46)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Data Kandang"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnHapus)
        Me.Panel3.Controls.Add(Me.btnUbah)
        Me.Panel3.Controls.Add(Me.btnTambah)
        Me.Panel3.Controls.Add(Me.dgvKandang)
        Me.Panel3.Controls.Add(Me.txtCari)
        Me.Panel3.Controls.Add(Me.Label8)
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
        ' dgvKandang
        '
        Me.dgvKandang.AllowUserToAddRows = False
        Me.dgvKandang.AllowUserToDeleteRows = False
        Me.dgvKandang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvKandang.BackColor = Color.Thistle
        Me.dgvKandang.BackgroundColor = Color.Thistle
        Me.dgvKandang.Location = New Point(24, 70)
        Me.dgvKandang.Name = "dgvKandang"
        Me.dgvKandang.ReadOnly = True
        Me.dgvKandang.RowHeadersVisible = False
        Me.dgvKandang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvKandang.Size = New Size(842, 460)
        Me.dgvKandang.TabIndex = 14
        '
        ' txtCari
        '
        Me.txtCari.BackColor = Color.White
        Me.txtCari.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtCari.ForeColor = Color.DarkOliveGreen
        Me.txtCari.Location = New Point(157, 20)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New Size(300, 30)
        Me.txtCari.TabIndex = 15
        '
        ' Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.Label8.ForeColor = Color.DarkOliveGreen
        Me.Label8.Location = New Point(24, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(115, 28)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Cari Kandang"
        '
        ' btnTambah
        '
        Me.btnTambah.BackColor = Color.MediumVioletRed
        Me.btnTambah.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnTambah.ForeColor = Color.SeaShell
        Me.btnTambah.Location = New Point(544, 18)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New Size(100, 34)
        Me.btnTambah.TabIndex = 17
        Me.btnTambah.Text = "Tambah"
        Me.btnTambah.UseVisualStyleBackColor = False
        '
        ' btnUbah
        '
        Me.btnUbah.BackColor = Color.LightGoldenrodYellow
        Me.btnUbah.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnUbah.ForeColor = Color.DarkOliveGreen
        Me.btnUbah.Location = New Point(654, 18)
        Me.btnUbah.Name = "btnUbah"
        Me.btnUbah.Size = New Size(100, 34)
        Me.btnUbah.TabIndex = 18
        Me.btnUbah.Text = "Ubah"
        Me.btnUbah.UseVisualStyleBackColor = False
        '
        ' btnHapus
        '
        Me.btnHapus.BackColor = Color.LightGoldenrodYellow
        Me.btnHapus.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnHapus.ForeColor = Color.DarkOliveGreen
        Me.btnHapus.Location = New Point(764, 18)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New Size(100, 34)
        Me.btnHapus.TabIndex = 19
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        ' FormKandang
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
        Me.Name = "FormKandang"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Data Kandang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvKandang, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlCard As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents btnMenuPemeriksaanKucing As Button
    Friend WithEvents btnMenuReservasi As Button
    Friend WithEvents btnMenuLaporan As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents dgvKandang As DataGridView
    Friend WithEvents txtCari As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnUbah As Button
    Friend WithEvents btnHapus As Button
End Class
