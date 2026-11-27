<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReservasiWizard
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
        Me.lblStep1 = New Label()
        Me.Label3 = New Label()
        Me.txtNamaPemesan = New TextBox()
        Me.Label4 = New Label()
        Me.txtTelepon = New TextBox()
        Me.Label5 = New Label()
        Me.txtAlamat = New TextBox()
        Me.Label6 = New Label()
        Me.txtCatatan = New TextBox()
        Me.Label7 = New Label()
        Me.cmbKucing = New ComboBox()
        Me.chkPickup = New CheckBox()
        Me.btnNext1 = New Button()
        Me.lblStep2 = New Label()
        Me.dgvLayanan = New DataGridView()
        Me.lblTotal2 = New Label()
        Me.btnBack2 = New Button()
        Me.btnNext2 = New Button()
        Me.lblStep3 = New Label()
        Me.Label8 = New Label()
        Me.dtpCheckIn = New DateTimePicker()
        Me.Label9 = New Label()
        Me.dtpCheckOut = New DateTimePicker()
        Me.Label10 = New Label()
        Me.txtRingkasan = New TextBox()
        Me.btnBack3 = New Button()
        Me.btnAjukan = New Button()
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
        Me.Label2.Text = "Reservasi"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnAjukan)
        Me.Panel3.Controls.Add(Me.btnBack3)
        Me.Panel3.Controls.Add(Me.txtRingkasan)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.dtpCheckOut)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.dtpCheckIn)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.lblStep3)
        Me.Panel3.Controls.Add(Me.btnNext2)
        Me.Panel3.Controls.Add(Me.btnBack2)
        Me.Panel3.Controls.Add(Me.lblTotal2)
        Me.Panel3.Controls.Add(Me.dgvLayanan)
        Me.Panel3.Controls.Add(Me.lblStep2)
        Me.Panel3.Controls.Add(Me.btnNext1)
        Me.Panel3.Controls.Add(Me.chkPickup)
        Me.Panel3.Controls.Add(Me.cmbKucing)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtCatatan)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtAlamat)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtTelepon)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtNamaPemesan)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.lblStep1)
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
        ' lblStep1
        '
        Me.lblStep1.AutoSize = False
        Me.lblStep1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblStep1.ForeColor = Color.DarkOliveGreen
        Me.lblStep1.Location = New Point(24, 18)
        Me.lblStep1.Name = "lblStep1"
        Me.lblStep1.Size = New Size(500, 23)
        Me.lblStep1.TabIndex = 13
        Me.lblStep1.Text = "Langkah 1 / 3 - Data Pemesan"
        '
        ' Label3
        '
        Me.Label3.AutoSize = False
        Me.Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label3.ForeColor = Color.DarkOliveGreen
        Me.Label3.Location = New Point(24, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(250, 23)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Nama Pemesan"
        '
        ' txtNamaPemesan
        '
        Me.txtNamaPemesan.BackColor = Color.White
        Me.txtNamaPemesan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtNamaPemesan.ForeColor = Color.DarkOliveGreen
        Me.txtNamaPemesan.Location = New Point(24, 86)
        Me.txtNamaPemesan.Name = "txtNamaPemesan"
        Me.txtNamaPemesan.Size = New Size(400, 30)
        Me.txtNamaPemesan.TabIndex = 15
        Me.txtNamaPemesan.Text = ""
        '
        ' Label4
        '
        Me.Label4.AutoSize = False
        Me.Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label4.ForeColor = Color.DarkOliveGreen
        Me.Label4.Location = New Point(24, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(250, 23)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "No. Telepon"
        '
        ' txtTelepon
        '
        Me.txtTelepon.BackColor = Color.White
        Me.txtTelepon.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtTelepon.ForeColor = Color.DarkOliveGreen
        Me.txtTelepon.Location = New Point(24, 154)
        Me.txtTelepon.Name = "txtTelepon"
        Me.txtTelepon.Size = New Size(250, 30)
        Me.txtTelepon.TabIndex = 17
        Me.txtTelepon.Text = ""
        '
        ' Label5
        '
        Me.Label5.AutoSize = False
        Me.Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label5.ForeColor = Color.DarkOliveGreen
        Me.Label5.Location = New Point(24, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(250, 23)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Alamat"
        '
        ' txtAlamat
        '
        Me.txtAlamat.BackColor = Color.White
        Me.txtAlamat.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtAlamat.ForeColor = Color.DarkOliveGreen
        Me.txtAlamat.Location = New Point(24, 222)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New Size(540, 60)
        Me.txtAlamat.TabIndex = 19
        Me.txtAlamat.Text = ""
        '
        ' Label6
        '
        Me.Label6.AutoSize = False
        Me.Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label6.ForeColor = Color.DarkOliveGreen
        Me.Label6.Location = New Point(24, 292)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(250, 23)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Catatan Kesehatan"
        '
        ' txtCatatan
        '
        Me.txtCatatan.BackColor = Color.White
        Me.txtCatatan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtCatatan.ForeColor = Color.DarkOliveGreen
        Me.txtCatatan.Location = New Point(24, 320)
        Me.txtCatatan.Name = "txtCatatan"
        Me.txtCatatan.Size = New Size(540, 60)
        Me.txtCatatan.TabIndex = 21
        Me.txtCatatan.Text = ""
        '
        ' Label7
        '
        Me.Label7.AutoSize = False
        Me.Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label7.ForeColor = Color.DarkOliveGreen
        Me.Label7.Location = New Point(600, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(250, 23)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Pilih Kucing"
        '
        ' cmbKucing
        '
        Me.cmbKucing.BackColor = Color.White
        Me.cmbKucing.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.cmbKucing.ForeColor = Color.DarkOliveGreen
        Me.cmbKucing.Location = New Point(600, 86)
        Me.cmbKucing.Name = "cmbKucing"
        Me.cmbKucing.Size = New Size(260, 30)
        Me.cmbKucing.TabIndex = 23
        '
        ' chkPickup
        '
        Me.chkPickup.AutoSize = True
        Me.chkPickup.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.chkPickup.ForeColor = Color.DarkOliveGreen
        Me.chkPickup.Location = New Point(600, 130)
        Me.chkPickup.Name = "chkPickup"
        Me.chkPickup.Size = New Size(260, 24)
        Me.chkPickup.TabIndex = 24
        Me.chkPickup.Text = "Butuh Antar Jemput"
        Me.chkPickup.UseVisualStyleBackColor = True
        '
        ' btnNext1
        '
        Me.btnNext1.BackColor = Color.LightGoldenrodYellow
        Me.btnNext1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnNext1.ForeColor = Color.DarkOliveGreen
        Me.btnNext1.Location = New Point(700, 480)
        Me.btnNext1.Margin = New Padding(2)
        Me.btnNext1.Name = "btnNext1"
        Me.btnNext1.Size = New Size(160, 40)
        Me.btnNext1.TabIndex = 25
        Me.btnNext1.Text = "Selanjutnya"
        Me.btnNext1.UseVisualStyleBackColor = False
        '
        ' lblStep2
        '
        Me.lblStep2.AutoSize = False
        Me.lblStep2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblStep2.ForeColor = Color.DarkOliveGreen
        Me.lblStep2.Location = New Point(24, 18)
        Me.lblStep2.Name = "lblStep2"
        Me.lblStep2.Size = New Size(500, 23)
        Me.lblStep2.TabIndex = 26
        Me.lblStep2.Text = "Langkah 2 / 3 - Paket Layanan"
        '
        ' dgvLayanan
        '
        Me.dgvLayanan.AllowUserToAddRows = False
        Me.dgvLayanan.AllowUserToDeleteRows = False
        Me.dgvLayanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLayanan.BackColor = Color.Thistle
        Me.dgvLayanan.BackgroundColor = Color.Thistle
        Me.dgvLayanan.Location = New Point(24, 58)
        Me.dgvLayanan.Name = "dgvLayanan"
        Me.dgvLayanan.ReadOnly = True
        Me.dgvLayanan.RowHeadersVisible = False
        Me.dgvLayanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvLayanan.Size = New Size(540, 380)
        Me.dgvLayanan.TabIndex = 27
        '
        ' lblTotal2
        '
        Me.lblTotal2.AutoSize = False
        Me.lblTotal2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblTotal2.ForeColor = Color.DarkOliveGreen
        Me.lblTotal2.Location = New Point(590, 70)
        Me.lblTotal2.Name = "lblTotal2"
        Me.lblTotal2.Size = New Size(270, 30)
        Me.lblTotal2.TabIndex = 28
        Me.lblTotal2.Text = "Total: Rp 0"
        '
        ' btnBack2
        '
        Me.btnBack2.BackColor = Color.LightGoldenrodYellow
        Me.btnBack2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnBack2.ForeColor = Color.DarkOliveGreen
        Me.btnBack2.Location = New Point(590, 480)
        Me.btnBack2.Margin = New Padding(2)
        Me.btnBack2.Name = "btnBack2"
        Me.btnBack2.Size = New Size(160, 40)
        Me.btnBack2.TabIndex = 29
        Me.btnBack2.Text = "Kembali"
        Me.btnBack2.UseVisualStyleBackColor = False
        '
        ' btnNext2
        '
        Me.btnNext2.BackColor = Color.LightGoldenrodYellow
        Me.btnNext2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnNext2.ForeColor = Color.DarkOliveGreen
        Me.btnNext2.Location = New Point(590, 430)
        Me.btnNext2.Margin = New Padding(2)
        Me.btnNext2.Name = "btnNext2"
        Me.btnNext2.Size = New Size(160, 40)
        Me.btnNext2.TabIndex = 30
        Me.btnNext2.Text = "Selanjutnya"
        Me.btnNext2.UseVisualStyleBackColor = False
        '
        ' lblStep3
        '
        Me.lblStep3.AutoSize = False
        Me.lblStep3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblStep3.ForeColor = Color.DarkOliveGreen
        Me.lblStep3.Location = New Point(24, 18)
        Me.lblStep3.Name = "lblStep3"
        Me.lblStep3.Size = New Size(500, 23)
        Me.lblStep3.TabIndex = 31
        Me.lblStep3.Text = "Langkah 3 / 3 - Konfirmasi"
        '
        ' Label8
        '
        Me.Label8.AutoSize = False
        Me.Label8.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label8.ForeColor = Color.DarkOliveGreen
        Me.Label8.Location = New Point(24, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(200, 23)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Check In"
        '
        ' dtpCheckIn
        '
        Me.dtpCheckIn.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.dtpCheckIn.Location = New Point(24, 88)
        Me.dtpCheckIn.Name = "dtpCheckIn"
        Me.dtpCheckIn.Size = New Size(260, 30)
        Me.dtpCheckIn.TabIndex = 33
        '
        ' Label9
        '
        Me.Label9.AutoSize = False
        Me.Label9.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label9.ForeColor = Color.DarkOliveGreen
        Me.Label9.Location = New Point(24, 130)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New Size(200, 23)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Check Out"
        '
        ' dtpCheckOut
        '
        Me.dtpCheckOut.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.dtpCheckOut.Location = New Point(24, 158)
        Me.dtpCheckOut.Name = "dtpCheckOut"
        Me.dtpCheckOut.Size = New Size(260, 30)
        Me.dtpCheckOut.TabIndex = 35
        '
        ' Label10
        '
        Me.Label10.AutoSize = False
        Me.Label10.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label10.ForeColor = Color.DarkOliveGreen
        Me.Label10.Location = New Point(320, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New Size(200, 23)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Ringkasan"
        '
        ' txtRingkasan
        '
        Me.txtRingkasan.BackColor = Color.White
        Me.txtRingkasan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtRingkasan.ForeColor = Color.DarkOliveGreen
        Me.txtRingkasan.Location = New Point(320, 88)
        Me.txtRingkasan.Name = "txtRingkasan"
        Me.txtRingkasan.Size = New Size(540, 220)
        Me.txtRingkasan.TabIndex = 37
        Me.txtRingkasan.Text = ""
        '
        ' btnBack3
        '
        Me.btnBack3.BackColor = Color.LightGoldenrodYellow
        Me.btnBack3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnBack3.ForeColor = Color.DarkOliveGreen
        Me.btnBack3.Location = New Point(590, 480)
        Me.btnBack3.Margin = New Padding(2)
        Me.btnBack3.Name = "btnBack3"
        Me.btnBack3.Size = New Size(160, 40)
        Me.btnBack3.TabIndex = 38
        Me.btnBack3.Text = "Kembali"
        Me.btnBack3.UseVisualStyleBackColor = False
        '
        ' btnAjukan
        '
        Me.btnAjukan.BackColor = Color.MediumVioletRed
        Me.btnAjukan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnAjukan.ForeColor = Color.SeaShell
        Me.btnAjukan.Location = New Point(590, 430)
        Me.btnAjukan.Margin = New Padding(2)
        Me.btnAjukan.Name = "btnAjukan"
        Me.btnAjukan.Size = New Size(160, 40)
        Me.btnAjukan.TabIndex = 39
        Me.btnAjukan.Text = "Ajukan Reservasi"
        Me.btnAjukan.UseVisualStyleBackColor = False
        '
        ' FormReservasiWizard
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
        Me.Name = "FormReservasiWizard"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Reservasi"
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
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuProfil As Button
    Friend WithEvents btnMenuTracking As Button
    Friend WithEvents btnMenuReservasiPelanggan As Button
    Friend WithEvents btnMenuRiwayat As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblStep1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNamaPemesan As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTelepon As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCatatan As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbKucing As ComboBox
    Friend WithEvents chkPickup As CheckBox
    Friend WithEvents btnNext1 As Button
    Friend WithEvents lblStep2 As Label
    Friend WithEvents dgvLayanan As DataGridView
    Friend WithEvents lblTotal2 As Label
    Friend WithEvents btnBack2 As Button
    Friend WithEvents btnNext2 As Button
    Friend WithEvents lblStep3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpCheckIn As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpCheckOut As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents txtRingkasan As TextBox
    Friend WithEvents btnBack3 As Button
    Friend WithEvents btnAjukan As Button
End Class
