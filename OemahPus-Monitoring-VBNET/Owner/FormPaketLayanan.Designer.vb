<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDataPaketLayanan
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
        Me.Label9 = New Label()
        Me.btnMenuDashboard = New Button()
        Me.btnMenuLayanan = New Button()
        Me.btnMenuCustomer = New Button()
        Me.btnMenuPemeriksaanKucing = New Button()
        Me.btnMenuReservasi = New Button()
        Me.btnMenuLaporan = New Button()
        Me.btnMenuAkun = New Button()
        Me.btnLogout = New Button()
        Me.Panel2 = New Panel()
        Me.Label1 = New Label()
        Me.Panel3 = New Panel()
        Me.pnlCard = New Panel()
        Me.dgvLayanan = New DataGridView()
        Me.ID = New DataGridViewTextBoxColumn()
        Me.Nama = New DataGridViewTextBoxColumn()
        Me.Status = New DataGridViewTextBoxColumn()
        Me.Jenis = New DataGridViewTextBoxColumn()
        Me.Harga = New DataGridViewTextBoxColumn()
        Me.Satuan = New DataGridViewTextBoxColumn()
        Me.txtCari = New TextBox()
        Me.Label8 = New Label()
        Me.btnTambah = New Button()
        Me.btnEdit = New Button()
        Me.btnHapus = New Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvLayanan, ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New Point(10, 10)
        Me.Panel1.Margin = New Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(246, 638)
        Me.Panel1.TabIndex = 0
        '
        ' Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New Font("Snap ITC", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.Label9.ForeColor = Color.Plum
        Me.Label9.Location = New Point(29, 50)
        Me.Label9.Margin = New Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New Size(181, 77)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "OMI"
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
        ' btnMenuLayanan
        '
        Me.btnMenuLayanan.BackColor = Color.Plum
        Me.btnMenuLayanan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuLayanan.ForeColor = Color.DarkOliveGreen
        Me.btnMenuLayanan.Location = New Point(38, 220)
        Me.btnMenuLayanan.Margin = New Padding(2)
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
        Me.btnMenuCustomer.ForeColor = Color.SeaShell
        Me.btnMenuCustomer.Location = New Point(38, 280)
        Me.btnMenuCustomer.Margin = New Padding(2)
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
        Me.btnMenuPemeriksaanKucing.Margin = New Padding(2)
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
        Me.btnMenuReservasi.Margin = New Padding(2)
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
        Me.btnMenuLaporan.Margin = New Padding(2)
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
        Me.btnMenuAkun.Margin = New Padding(2)
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
        Me.btnLogout.Margin = New Padding(2)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New Size(165, 37)
        Me.btnLogout.TabIndex = 9
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        ' Panel2
        '
        Me.Panel2.BackColor = Color.LightGoldenrodYellow
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New Point(256, 10)
        Me.Panel2.Margin = New Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(890, 84)
        Me.Panel2.TabIndex = 10
        '
        ' Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label1.ForeColor = Color.DarkOliveGreen
        Me.Label1.Location = New Point(16, 16)
        Me.Label1.Margin = New Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(331, 46)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Data Paket Layanan"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnHapus)
        Me.Panel3.Controls.Add(Me.btnEdit)
        Me.Panel3.Controls.Add(Me.btnTambah)
        Me.Panel3.Controls.Add(Me.dgvLayanan)
        Me.Panel3.Controls.Add(Me.txtCari)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.pnlCard)
        Me.Panel3.Location = New Point(256, 94)
        Me.Panel3.Margin = New Padding(2)
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
        ' dgvLayanan
        '
        Me.dgvLayanan.AllowUserToAddRows = False
        Me.dgvLayanan.AllowUserToDeleteRows = False
        Me.dgvLayanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLayanan.BackgroundColor = Color.Thistle
        Me.dgvLayanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLayanan.Columns.AddRange(New DataGridViewColumn() {Me.ID, Me.Nama, Me.Status, Me.Jenis, Me.Harga, Me.Satuan})
        Me.dgvLayanan.Location = New Point(24, 70)
        Me.dgvLayanan.Margin = New Padding(2)
        Me.dgvLayanan.Name = "dgvLayanan"
        Me.dgvLayanan.MultiSelect = False
        Me.dgvLayanan.ReadOnly = True
        Me.dgvLayanan.RowHeadersVisible = False
        Me.dgvLayanan.RowHeadersWidth = 62
        Me.dgvLayanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvLayanan.Size = New Size(842, 460)
        Me.dgvLayanan.TabIndex = 14
        '
        ' ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.MinimumWidth = 8
        Me.ID.Name = "ID"
        Me.ID.Width = 60
        '
        ' Nama
        '
        Me.Nama.HeaderText = "Nama Layanan"
        Me.Nama.MinimumWidth = 8
        Me.Nama.Name = "Nama"
        Me.Nama.Width = 150
        '
        ' Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 8
        Me.Status.Name = "Status"
        Me.Status.Width = 150
        '
        ' Jenis
        '
        Me.Jenis.HeaderText = "Jenis Layanan"
        Me.Jenis.MinimumWidth = 8
        Me.Jenis.Name = "Jenis"
        Me.Jenis.Width = 150
        '
        ' Harga
        '
        Me.Harga.HeaderText = "Harga"
        Me.Harga.MinimumWidth = 8
        Me.Harga.Name = "Harga"
        Me.Harga.Width = 150
        '
        ' Satuan
        '
        Me.Satuan.HeaderText = "Satuan"
        Me.Satuan.MinimumWidth = 8
        Me.Satuan.Name = "Satuan"
        Me.Satuan.Width = 150
        '
        ' txtCari
        '
        Me.txtCari.BackColor = Color.White
        Me.txtCari.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtCari.ForeColor = Color.DarkOliveGreen
        Me.txtCari.Location = New Point(157, 20)
        Me.txtCari.Margin = New Padding(2)
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
        Me.Label8.Margin = New Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(122, 28)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Cari Layanan"
        '
        ' btnTambah
        '
        Me.btnTambah.BackColor = Color.MediumVioletRed
        Me.btnTambah.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnTambah.ForeColor = Color.SeaShell
        Me.btnTambah.Location = New Point(544, 18)
        Me.btnTambah.Margin = New Padding(2)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New Size(100, 34)
        Me.btnTambah.TabIndex = 17
        Me.btnTambah.Text = "Tambah"
        Me.btnTambah.UseVisualStyleBackColor = False
        '
        ' btnEdit
        '
        Me.btnEdit.BackColor = Color.LightGoldenrodYellow
        Me.btnEdit.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnEdit.ForeColor = Color.DarkOliveGreen
        Me.btnEdit.Location = New Point(654, 18)
        Me.btnEdit.Margin = New Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New Size(100, 34)
        Me.btnEdit.TabIndex = 18
        Me.btnEdit.Text = "Ubah"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        ' btnHapus
        '
        Me.btnHapus.BackColor = Color.LightGoldenrodYellow
        Me.btnHapus.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnHapus.ForeColor = Color.DarkOliveGreen
        Me.btnHapus.Location = New Point(764, 18)
        Me.btnHapus.Margin = New Padding(2)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New Size(100, 34)
        Me.btnHapus.TabIndex = 19
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        ' FormDataPaketLayanan
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
        Me.Name = "FormDataPaketLayanan"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Data Paket Layanan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvLayanan, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlCard As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents btnMenuPemeriksaanKucing As Button
    Friend WithEvents btnMenuReservasi As Button
    Friend WithEvents btnMenuLaporan As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents dgvLayanan As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Jenis As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    Friend WithEvents Satuan As DataGridViewTextBoxColumn
    Friend WithEvents txtCari As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnHapus As Button
End Class