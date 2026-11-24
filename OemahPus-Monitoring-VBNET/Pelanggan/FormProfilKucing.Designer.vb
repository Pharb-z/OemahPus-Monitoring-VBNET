<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProfilKucing
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
        Me.btnMenuReservasiPelanggan = New Button()
        Me.btnMenuRiwayat = New Button()
        Me.btnMenuAkun = New Button()
        Me.btnLogout = New Button()
        Me.Panel2 = New Panel()
        Me.Label2 = New Label()
        Me.Panel3 = New Panel()
        Me.dgvKucing = New DataGridView()
        Me.Label3 = New Label()
        Me.txtNama = New TextBox()
        Me.Label4 = New Label()
        Me.txtRas = New TextBox()
        Me.Label5 = New Label()
        Me.cmbGender = New ComboBox()
        Me.Label6 = New Label()
        Me.dtpLahir = New DateTimePicker()
        Me.Label7 = New Label()
        Me.txtWarna = New TextBox()
        Me.Label8 = New Label()
        Me.txtCatatan = New TextBox()
        Me.chkVaksin = New CheckBox()
        Me.btnTambah = New Button()
        Me.btnSimpan = New Button()
        Me.btnHapus = New Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvKucing, ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.TabIndex = 0
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
        Me.btnMenuDashboard.TabIndex = 1
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
        Me.btnMenuProfil.TabIndex = 2
        Me.btnMenuProfil.Text = "Profil Kucing"
        Me.btnMenuProfil.UseVisualStyleBackColor = False
        '
        ' btnMenuReservasiPelanggan
        '
        Me.btnMenuReservasiPelanggan.BackColor = Color.Plum
        Me.btnMenuReservasiPelanggan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuReservasiPelanggan.ForeColor = Color.SeaShell
        Me.btnMenuReservasiPelanggan.Location = New Point(38, 280)
        Me.btnMenuReservasiPelanggan.Margin = New Padding(2)
        Me.btnMenuReservasiPelanggan.Name = "btnMenuReservasiPelanggan"
        Me.btnMenuReservasiPelanggan.Size = New Size(165, 37)
        Me.btnMenuReservasiPelanggan.TabIndex = 3
        Me.btnMenuReservasiPelanggan.Text = "Reservasi"
        Me.btnMenuReservasiPelanggan.UseVisualStyleBackColor = False
        '
        ' btnMenuRiwayat
        '
        Me.btnMenuRiwayat.BackColor = Color.Plum
        Me.btnMenuRiwayat.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuRiwayat.ForeColor = Color.SeaShell
        Me.btnMenuRiwayat.Location = New Point(38, 340)
        Me.btnMenuRiwayat.Margin = New Padding(2)
        Me.btnMenuRiwayat.Name = "btnMenuRiwayat"
        Me.btnMenuRiwayat.Size = New Size(165, 37)
        Me.btnMenuRiwayat.TabIndex = 4
        Me.btnMenuRiwayat.Text = "Riwayat"
        Me.btnMenuRiwayat.UseVisualStyleBackColor = False
        '
        ' btnMenuAkun
        '
        Me.btnMenuAkun.BackColor = Color.Plum
        Me.btnMenuAkun.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuAkun.ForeColor = Color.SeaShell
        Me.btnMenuAkun.Location = New Point(38, 400)
        Me.btnMenuAkun.Margin = New Padding(2)
        Me.btnMenuAkun.Name = "btnMenuAkun"
        Me.btnMenuAkun.Size = New Size(165, 37)
        Me.btnMenuAkun.TabIndex = 5
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
        Me.btnLogout.TabIndex = 6
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
        Me.Panel2.TabIndex = 1
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
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Profil Kucing"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnHapus)
        Me.Panel3.Controls.Add(Me.btnSimpan)
        Me.Panel3.Controls.Add(Me.btnTambah)
        Me.Panel3.Controls.Add(Me.chkVaksin)
        Me.Panel3.Controls.Add(Me.txtCatatan)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtWarna)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.dtpLahir)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.cmbGender)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtRas)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtNama)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.dgvKucing)
        Me.Panel3.Location = New Point(256, 94)
        Me.Panel3.Margin = New Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Size(890, 554)
        Me.Panel3.TabIndex = 2
        '
        ' dgvKucing
        '
        Me.dgvKucing.AllowUserToAddRows = False
        Me.dgvKucing.AllowUserToDeleteRows = False
        Me.dgvKucing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvKucing.BackColor = Color.Thistle
        Me.dgvKucing.BackgroundColor = Color.Thistle
        Me.dgvKucing.Location = New Point(24, 24)
        Me.dgvKucing.Name = "dgvKucing"
        Me.dgvKucing.ReadOnly = True
        Me.dgvKucing.RowHeadersVisible = False
        Me.dgvKucing.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvKucing.Size = New Size(540, 470)
        Me.dgvKucing.TabIndex = 0
        '
        ' Label3
        '
        Me.Label3.AutoSize = False
        Me.Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label3.ForeColor = Color.DarkOliveGreen
        Me.Label3.Location = New Point(590, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(280, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nama Kucing"
        '
        ' txtNama
        '
        Me.txtNama.BackColor = Color.White
        Me.txtNama.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtNama.ForeColor = Color.DarkOliveGreen
        Me.txtNama.Location = New Point(590, 52)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New Size(280, 30)
        Me.txtNama.TabIndex = 0
        Me.txtNama.Text = ""
        '
        ' Label4
        '
        Me.Label4.AutoSize = False
        Me.Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label4.ForeColor = Color.DarkOliveGreen
        Me.Label4.Location = New Point(590, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(280, 23)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ras"
        '
        ' txtRas
        '
        Me.txtRas.BackColor = Color.White
        Me.txtRas.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtRas.ForeColor = Color.DarkOliveGreen
        Me.txtRas.Location = New Point(590, 120)
        Me.txtRas.Name = "txtRas"
        Me.txtRas.Size = New Size(280, 30)
        Me.txtRas.TabIndex = 0
        Me.txtRas.Text = ""
        '
        ' Label5
        '
        Me.Label5.AutoSize = False
        Me.Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label5.ForeColor = Color.DarkOliveGreen
        Me.Label5.Location = New Point(590, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(280, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Jenis Kelamin"
        '
        ' cmbGender
        '
        Me.cmbGender.BackColor = Color.White
        Me.cmbGender.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.cmbGender.ForeColor = Color.DarkOliveGreen
        Me.cmbGender.Location = New Point(590, 188)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New Size(280, 30)
        Me.cmbGender.TabIndex = 0
        '
        ' Label6
        '
        Me.Label6.AutoSize = False
        Me.Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label6.ForeColor = Color.DarkOliveGreen
        Me.Label6.Location = New Point(590, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(280, 23)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tanggal Lahir"
        '
        ' dtpLahir
        '
        Me.dtpLahir.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.dtpLahir.Location = New Point(590, 256)
        Me.dtpLahir.Name = "dtpLahir"
        Me.dtpLahir.Size = New Size(280, 30)
        Me.dtpLahir.TabIndex = 0
        '
        ' Label7
        '
        Me.Label7.AutoSize = False
        Me.Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label7.ForeColor = Color.DarkOliveGreen
        Me.Label7.Location = New Point(590, 296)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(280, 23)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Warna Bulu"
        '
        ' txtWarna
        '
        Me.txtWarna.BackColor = Color.White
        Me.txtWarna.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtWarna.ForeColor = Color.DarkOliveGreen
        Me.txtWarna.Location = New Point(590, 324)
        Me.txtWarna.Name = "txtWarna"
        Me.txtWarna.Size = New Size(280, 30)
        Me.txtWarna.TabIndex = 0
        Me.txtWarna.Text = ""
        '
        ' Label8
        '
        Me.Label8.AutoSize = False
        Me.Label8.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label8.ForeColor = Color.DarkOliveGreen
        Me.Label8.Location = New Point(590, 364)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(280, 23)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Catatan"
        '
        ' txtCatatan
        '
        Me.txtCatatan.BackColor = Color.White
        Me.txtCatatan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtCatatan.ForeColor = Color.DarkOliveGreen
        Me.txtCatatan.Location = New Point(590, 392)
        Me.txtCatatan.Name = "txtCatatan"
        Me.txtCatatan.Size = New Size(280, 70)
        Me.txtCatatan.TabIndex = 0
        Me.txtCatatan.Text = ""
        '
        ' chkVaksin
        '
        Me.chkVaksin.AutoSize = True
        Me.chkVaksin.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.chkVaksin.ForeColor = Color.DarkOliveGreen
        Me.chkVaksin.Location = New Point(590, 476)
        Me.chkVaksin.Name = "chkVaksin"
        Me.chkVaksin.Size = New Size(200, 24)
        Me.chkVaksin.TabIndex = 0
        Me.chkVaksin.Text = "Sudah_divaksin"
        Me.chkVaksin.UseVisualStyleBackColor = True
        '
        ' btnTambah
        '
        Me.btnTambah.BackColor = Color.LightGoldenrodYellow
        Me.btnTambah.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnTambah.ForeColor = Color.DarkOliveGreen
        Me.btnTambah.Location = New Point(590, 514)
        Me.btnTambah.Margin = New Padding(2)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New Size(130, 37)
        Me.btnTambah.TabIndex = 0
        Me.btnTambah.Text = "Tambah"
        Me.btnTambah.UseVisualStyleBackColor = False
        '
        ' btnSimpan
        '
        Me.btnSimpan.BackColor = Color.LightGoldenrodYellow
        Me.btnSimpan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnSimpan.ForeColor = Color.DarkOliveGreen
        Me.btnSimpan.Location = New Point(730, 514)
        Me.btnSimpan.Margin = New Padding(2)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New Size(130, 37)
        Me.btnSimpan.TabIndex = 0
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        ' btnHapus
        '
        Me.btnHapus.BackColor = Color.LightGoldenrodYellow
        Me.btnHapus.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnHapus.ForeColor = Color.DarkOliveGreen
        Me.btnHapus.Location = New Point(590, 560)
        Me.btnHapus.Margin = New Padding(2)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New Size(270, 37)
        Me.btnHapus.TabIndex = 0
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        ' FormProfilKucing
        '
        Me.AutoScaleDimensions = New SizeF(8F, 20F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1156, 658)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New Padding(2)
        Me.Name = "FormProfilKucing"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Profil Kucing"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvKucing, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuProfil As Button
    Friend WithEvents btnMenuReservasiPelanggan As Button
    Friend WithEvents btnMenuRiwayat As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents dgvKucing As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRas As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpLahir As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents txtWarna As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCatatan As TextBox
    Friend WithEvents chkVaksin As CheckBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnHapus As Button
End Class
