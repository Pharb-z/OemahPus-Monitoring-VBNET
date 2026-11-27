<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKucingEdit
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
        Me.lblJudul = New Label()
        Me.Panel3 = New Panel()
        Me.pnlCard = New Panel()
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
        Me.chkVaksin = New CheckBox()
        Me.Label8 = New Label()
        Me.txtCatatan = New TextBox()
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
        Me.Panel2.Controls.Add(Me.lblJudul)
        Me.Panel2.Location = New Point(256, 10)
        Me.Panel2.Margin = New Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(890, 84)
        Me.Panel2.TabIndex = 9
        '
        ' lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblJudul.ForeColor = Color.DarkOliveGreen
        Me.lblJudul.Location = New Point(16, 16)
        Me.lblJudul.Margin = New Padding(2, 0, 2, 0)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New Size(400, 46)
        Me.lblJudul.TabIndex = 10
        Me.lblJudul.Text = "Tambah Profil Kucing"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnBatal)
        Me.Panel3.Controls.Add(Me.btnSimpan)
        Me.Panel3.Controls.Add(Me.txtCatatan)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.chkVaksin)
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
        Me.Label3.Location = New Point(60, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(380, 23)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nama Kucing"
        '
        ' txtNama
        '
        Me.txtNama.BackColor = Color.White
        Me.txtNama.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtNama.ForeColor = Color.DarkOliveGreen
        Me.txtNama.Location = New Point(60, 58)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New Size(380, 30)
        Me.txtNama.TabIndex = 14
        '
        ' Label4
        '
        Me.Label4.AutoSize = False
        Me.Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label4.ForeColor = Color.DarkOliveGreen
        Me.Label4.Location = New Point(480, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(350, 23)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Ras"
        '
        ' txtRas
        '
        Me.txtRas.BackColor = Color.White
        Me.txtRas.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtRas.ForeColor = Color.DarkOliveGreen
        Me.txtRas.Location = New Point(480, 58)
        Me.txtRas.Name = "txtRas"
        Me.txtRas.Size = New Size(350, 30)
        Me.txtRas.TabIndex = 16
        '
        ' Label5
        '
        Me.Label5.AutoSize = False
        Me.Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label5.ForeColor = Color.DarkOliveGreen
        Me.Label5.Location = New Point(60, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(380, 23)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Jenis Kelamin"
        '
        ' cmbGender
        '
        Me.cmbGender.BackColor = Color.White
        Me.cmbGender.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.cmbGender.ForeColor = Color.DarkOliveGreen
        Me.cmbGender.Location = New Point(60, 156)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New Size(380, 30)
        Me.cmbGender.TabIndex = 18
        '
        ' Label6
        '
        Me.Label6.AutoSize = False
        Me.Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label6.ForeColor = Color.DarkOliveGreen
        Me.Label6.Location = New Point(480, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(350, 23)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Tanggal Lahir"
        '
        ' dtpLahir
        '
        Me.dtpLahir.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.dtpLahir.Format = DateTimePickerFormat.Short
        Me.dtpLahir.Location = New Point(480, 156)
        Me.dtpLahir.Name = "dtpLahir"
        Me.dtpLahir.Size = New Size(350, 30)
        Me.dtpLahir.TabIndex = 20
        '
        ' Label7
        '
        Me.Label7.AutoSize = False
        Me.Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label7.ForeColor = Color.DarkOliveGreen
        Me.Label7.Location = New Point(60, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(380, 23)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Warna Bulu"
        '
        ' txtWarna
        '
        Me.txtWarna.BackColor = Color.White
        Me.txtWarna.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtWarna.ForeColor = Color.DarkOliveGreen
        Me.txtWarna.Location = New Point(60, 254)
        Me.txtWarna.Name = "txtWarna"
        Me.txtWarna.Size = New Size(380, 30)
        Me.txtWarna.TabIndex = 22
        '
        ' chkVaksin
        '
        Me.chkVaksin.AutoSize = True
        Me.chkVaksin.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.chkVaksin.ForeColor = Color.DarkOliveGreen
        Me.chkVaksin.Location = New Point(480, 256)
        Me.chkVaksin.Name = "chkVaksin"
        Me.chkVaksin.Size = New Size(200, 24)
        Me.chkVaksin.TabIndex = 23
        Me.chkVaksin.Text = "Sudah divaksin"
        Me.chkVaksin.UseVisualStyleBackColor = True
        '
        ' Label8
        '
        Me.Label8.AutoSize = False
        Me.Label8.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label8.ForeColor = Color.DarkOliveGreen
        Me.Label8.Location = New Point(60, 324)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(770, 23)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Catatan"
        '
        ' txtCatatan
        '
        Me.txtCatatan.BackColor = Color.White
        Me.txtCatatan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtCatatan.ForeColor = Color.DarkOliveGreen
        Me.txtCatatan.Location = New Point(60, 352)
        Me.txtCatatan.Multiline = True
        Me.txtCatatan.Name = "txtCatatan"
        Me.txtCatatan.ScrollBars = ScrollBars.Vertical
        Me.txtCatatan.Size = New Size(770, 90)
        Me.txtCatatan.TabIndex = 25
        '
        ' btnSimpan
        '
        Me.btnSimpan.BackColor = Color.MediumVioletRed
        Me.btnSimpan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnSimpan.ForeColor = Color.SeaShell
        Me.btnSimpan.Location = New Point(60, 470)
        Me.btnSimpan.Margin = New Padding(2)
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
        Me.btnBatal.Location = New Point(260, 470)
        Me.btnBatal.Margin = New Padding(2)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New Size(180, 40)
        Me.btnBatal.TabIndex = 27
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        ' FormKucingEdit
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
        Me.Name = "FormKucingEdit"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Profil Kucing"
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
    Friend WithEvents btnMenuProfil As Button
    Friend WithEvents btnMenuTracking As Button
    Friend WithEvents btnMenuReservasiPelanggan As Button
    Friend WithEvents btnMenuRiwayat As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnLogout As Button
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
    Friend WithEvents chkVaksin As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCatatan As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBatal As Button
End Class