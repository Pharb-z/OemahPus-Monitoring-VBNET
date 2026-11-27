<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMedisEdit
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
        Me.cmbNamaKucing = New ComboBox()
        Me.Label4 = New Label()
        Me.dtpTanggalPemeriksaan = New DateTimePicker()
        Me.Label5 = New Label()
        Me.txtBeratBadan = New TextBox()
        Me.Label6 = New Label()
        Me.txtSuhuTubuh = New TextBox()
        Me.Label7 = New Label()
        Me.cmbTemuanParasit = New ComboBox()
        Me.Label8 = New Label()
        Me.txtCatatanKesehatan = New TextBox()
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
        Me.btnMenuCustomer.ForeColor = Color.SeaShell
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
        Me.btnMenuPemeriksaanKucing.ForeColor = Color.DarkOliveGreen
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
        Me.lblJudul.Text = "Tambah Pemeriksaan"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnBatal)
        Me.Panel3.Controls.Add(Me.btnSimpan)
        Me.Panel3.Controls.Add(Me.txtCatatanKesehatan)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.cmbTemuanParasit)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtSuhuTubuh)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtBeratBadan)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.dtpTanggalPemeriksaan)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.cmbNamaKucing)
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
        Me.Label3.Location = New Point(60, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(380, 23)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Nama Kucing"
        '
        ' cmbNamaKucing
        '
        Me.cmbNamaKucing.BackColor = Color.White
        Me.cmbNamaKucing.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.cmbNamaKucing.ForeColor = Color.DarkOliveGreen
        Me.cmbNamaKucing.Location = New Point(60, 68)
        Me.cmbNamaKucing.Name = "cmbNamaKucing"
        Me.cmbNamaKucing.Size = New Size(380, 30)
        Me.cmbNamaKucing.TabIndex = 15
        '
        ' Label4
        '
        Me.Label4.AutoSize = False
        Me.Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label4.ForeColor = Color.DarkOliveGreen
        Me.Label4.Location = New Point(480, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(350, 23)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Tanggal Pemeriksaan"
        '
        ' dtpTanggalPemeriksaan
        '
        Me.dtpTanggalPemeriksaan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.dtpTanggalPemeriksaan.Location = New Point(480, 68)
        Me.dtpTanggalPemeriksaan.Name = "dtpTanggalPemeriksaan"
        Me.dtpTanggalPemeriksaan.Size = New Size(350, 30)
        Me.dtpTanggalPemeriksaan.TabIndex = 17
        '
        ' Label5
        '
        Me.Label5.AutoSize = False
        Me.Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label5.ForeColor = Color.DarkOliveGreen
        Me.Label5.Location = New Point(60, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(380, 23)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Berat Badan (kg)"
        '
        ' txtBeratBadan
        '
        Me.txtBeratBadan.BackColor = Color.White
        Me.txtBeratBadan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtBeratBadan.ForeColor = Color.DarkOliveGreen
        Me.txtBeratBadan.Location = New Point(60, 166)
        Me.txtBeratBadan.Name = "txtBeratBadan"
        Me.txtBeratBadan.Size = New Size(380, 30)
        Me.txtBeratBadan.TabIndex = 19
        '
        ' Label6
        '
        Me.Label6.AutoSize = False
        Me.Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label6.ForeColor = Color.DarkOliveGreen
        Me.Label6.Location = New Point(480, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(350, 23)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Suhu Tubuh (°C)"
        '
        ' txtSuhuTubuh
        '
        Me.txtSuhuTubuh.BackColor = Color.White
        Me.txtSuhuTubuh.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtSuhuTubuh.ForeColor = Color.DarkOliveGreen
        Me.txtSuhuTubuh.Location = New Point(480, 166)
        Me.txtSuhuTubuh.Name = "txtSuhuTubuh"
        Me.txtSuhuTubuh.Size = New Size(350, 30)
        Me.txtSuhuTubuh.TabIndex = 21
        '
        ' Label7
        '
        Me.Label7.AutoSize = False
        Me.Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label7.ForeColor = Color.DarkOliveGreen
        Me.Label7.Location = New Point(60, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(380, 23)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Temuan Parasit"
        '
        ' cmbTemuanParasit
        '
        Me.cmbTemuanParasit.BackColor = Color.White
        Me.cmbTemuanParasit.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.cmbTemuanParasit.ForeColor = Color.DarkOliveGreen
        Me.cmbTemuanParasit.Location = New Point(60, 264)
        Me.cmbTemuanParasit.Name = "cmbTemuanParasit"
        Me.cmbTemuanParasit.Size = New Size(380, 30)
        Me.cmbTemuanParasit.TabIndex = 23
        '
        ' Label8
        '
        Me.Label8.AutoSize = False
        Me.Label8.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label8.ForeColor = Color.DarkOliveGreen
        Me.Label8.Location = New Point(60, 334)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(770, 23)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Catatan Kesehatan"
        '
        ' txtCatatanKesehatan
        '
        Me.txtCatatanKesehatan.BackColor = Color.White
        Me.txtCatatanKesehatan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtCatatanKesehatan.ForeColor = Color.DarkOliveGreen
        Me.txtCatatanKesehatan.Location = New Point(60, 362)
        Me.txtCatatanKesehatan.Multiline = True
        Me.txtCatatanKesehatan.Name = "txtCatatanKesehatan"
        Me.txtCatatanKesehatan.ScrollBars = ScrollBars.Vertical
        Me.txtCatatanKesehatan.Size = New Size(770, 100)
        Me.txtCatatanKesehatan.TabIndex = 25
        '
        ' btnSimpan
        '
        Me.btnSimpan.BackColor = Color.MediumVioletRed
        Me.btnSimpan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnSimpan.ForeColor = Color.SeaShell
        Me.btnSimpan.Location = New Point(60, 490)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New Size(180, 40)
        Me.btnSimpan.TabIndex = 26
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        ' btnBatal
        '
        Me.btnBatal.BackColor = Color.LightGoldenrodYellow
        Me.btnBatal.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnBatal.ForeColor = Color.DarkOliveGreen
        Me.btnBatal.Location = New Point(260, 490)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New Size(180, 40)
        Me.btnBatal.TabIndex = 27
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        ' FormMedisEdit
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
        Me.Name = "FormMedisEdit"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Pemeriksaan Kucing"
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
    Friend WithEvents cmbNamaKucing As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTanggalPemeriksaan As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBeratBadan As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSuhuTubuh As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbTemuanParasit As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCatatanKesehatan As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBatal As Button
End Class
