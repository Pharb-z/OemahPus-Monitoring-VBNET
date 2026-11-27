<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPembayaranQris
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
        Me.lblReservasiCaption = New Label()
        Me.lblReservasi = New Label()
        Me.pnlQr = New Panel()
        Me.lblNominal = New Label()
        Me.lblTimer = New Label()
        Me.lblNote = New Label()
        Me.lblExpired = New Label()
        Me.lblSimNote = New Label()
        Me.btnSimulasi = New Button()
        Me.btnUnduhQr = New Button()
        Me.btnKembali = New Button()
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
        Me.Label2.Text = "Pembayaran QRIS"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnKembali)
        Me.Panel3.Controls.Add(Me.btnUnduhQr)
        Me.Panel3.Controls.Add(Me.btnSimulasi)
        Me.Panel3.Controls.Add(Me.lblSimNote)
        Me.Panel3.Controls.Add(Me.lblExpired)
        Me.Panel3.Controls.Add(Me.lblNote)
        Me.Panel3.Controls.Add(Me.lblTimer)
        Me.Panel3.Controls.Add(Me.lblNominal)
        Me.Panel3.Controls.Add(Me.pnlQr)
        Me.Panel3.Controls.Add(Me.lblReservasi)
        Me.Panel3.Controls.Add(Me.lblReservasiCaption)
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
        ' lblReservasiCaption
        '
        Me.lblReservasiCaption.AutoSize = False
        Me.lblReservasiCaption.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblReservasiCaption.ForeColor = Color.DarkOliveGreen
        Me.lblReservasiCaption.Location = New Point(24, 18)
        Me.lblReservasiCaption.Name = "lblReservasiCaption"
        Me.lblReservasiCaption.Size = New Size(400, 23)
        Me.lblReservasiCaption.TabIndex = 13
        Me.lblReservasiCaption.Text = "Reservasi"
        '
        ' lblReservasi
        '
        Me.lblReservasi.AutoSize = False
        Me.lblReservasi.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblReservasi.ForeColor = Color.MediumVioletRed
        Me.lblReservasi.Location = New Point(24, 44)
        Me.lblReservasi.Name = "lblReservasi"
        Me.lblReservasi.Size = New Size(400, 26)
        Me.lblReservasi.TabIndex = 14
        Me.lblReservasi.Text = "-"
        '
        ' pnlQr
        '
        Me.pnlQr.BackColor = Color.White
        Me.pnlQr.BorderStyle = BorderStyle.FixedSingle
        Me.pnlQr.Location = New Point(24, 84)
        Me.pnlQr.Name = "pnlQr"
        Me.pnlQr.Size = New Size(220, 220)
        Me.pnlQr.TabIndex = 15
        '
        ' lblNominal
        '
        Me.lblNominal.AutoSize = False
        Me.lblNominal.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblNominal.ForeColor = Color.DarkOliveGreen
        Me.lblNominal.Location = New Point(280, 84)
        Me.lblNominal.Name = "lblNominal"
        Me.lblNominal.Size = New Size(560, 40)
        Me.lblNominal.TabIndex = 16
        Me.lblNominal.Text = "IDR. 0"
        '
        ' lblTimer
        '
        Me.lblTimer.AutoSize = False
        Me.lblTimer.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblTimer.ForeColor = Color.MediumVioletRed
        Me.lblTimer.Location = New Point(280, 132)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New Size(560, 30)
        Me.lblTimer.TabIndex = 17
        Me.lblTimer.Text = "24:00"
        '
        ' lblNote
        '
        Me.lblNote.AutoSize = False
        Me.lblNote.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.lblNote.ForeColor = Color.DarkOliveGreen
        Me.lblNote.Location = New Point(280, 172)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New Size(560, 44)
        Me.lblNote.TabIndex = 18
        Me.lblNote.Text = "Pindai kode QR untuk melakukan pembayaran."
        '
        ' lblExpired
        '
        Me.lblExpired.AutoSize = False
        Me.lblExpired.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblExpired.ForeColor = Color.Firebrick
        Me.lblExpired.Location = New Point(280, 222)
        Me.lblExpired.Name = "lblExpired"
        Me.lblExpired.Size = New Size(560, 23)
        Me.lblExpired.TabIndex = 19
        Me.lblExpired.Text = "Waktu pembayaran habis. Silakan buat ulang pembayaran."
        Me.lblExpired.Visible = False
        '
        ' lblSimNote
        '
        Me.lblSimNote.AutoSize = False
        Me.lblSimNote.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.lblSimNote.ForeColor = Color.DarkOrange
        Me.lblSimNote.Location = New Point(24, 320)
        Me.lblSimNote.Name = "lblSimNote"
        Me.lblSimNote.Size = New Size(816, 44)
        Me.lblSimNote.TabIndex = 20
        Me.lblSimNote.Text = "Mode simulasi. Kode QR hanya ilustrasi dan tidak dapat dipindai; prototipe tidak terhubung ke penyedia pembayaran mana pun."
        '
        ' btnSimulasi
        '
        Me.btnSimulasi.BackColor = Color.MediumVioletRed
        Me.btnSimulasi.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnSimulasi.ForeColor = Color.SeaShell
        Me.btnSimulasi.Location = New Point(24, 380)
        Me.btnSimulasi.Margin = New Padding(2)
        Me.btnSimulasi.Name = "btnSimulasi"
        Me.btnSimulasi.Size = New Size(260, 40)
        Me.btnSimulasi.TabIndex = 21
        Me.btnSimulasi.Text = "Simulasikan Pembayaran Berhasil"
        Me.btnSimulasi.UseVisualStyleBackColor = False
        '
        ' btnUnduhQr
        '
        Me.btnUnduhQr.BackColor = Color.LightGoldenrodYellow
        Me.btnUnduhQr.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnUnduhQr.ForeColor = Color.DarkOliveGreen
        Me.btnUnduhQr.Location = New Point(24, 430)
        Me.btnUnduhQr.Margin = New Padding(2)
        Me.btnUnduhQr.Name = "btnUnduhQr"
        Me.btnUnduhQr.Size = New Size(260, 40)
        Me.btnUnduhQr.TabIndex = 22
        Me.btnUnduhQr.Text = "Unduh Kode QR"
        Me.btnUnduhQr.UseVisualStyleBackColor = False
        '
        ' btnKembali
        '
        Me.btnKembali.BackColor = Color.LightGoldenrodYellow
        Me.btnKembali.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnKembali.ForeColor = Color.DarkOliveGreen
        Me.btnKembali.Location = New Point(24, 480)
        Me.btnKembali.Margin = New Padding(2)
        Me.btnKembali.Name = "btnKembali"
        Me.btnKembali.Size = New Size(260, 40)
        Me.btnKembali.TabIndex = 23
        Me.btnKembali.Text = "Kembali ke Riwayat"
        Me.btnKembali.UseVisualStyleBackColor = False
        '
        ' FormPembayaranQris
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
        Me.Name = "FormPembayaranQris"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Pembayaran QRIS"
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
    Friend WithEvents lblReservasiCaption As Label
    Friend WithEvents lblReservasi As Label
    Friend WithEvents pnlQr As Panel
    Friend WithEvents lblNominal As Label
    Friend WithEvents lblTimer As Label
    Friend WithEvents lblNote As Label
    Friend WithEvents lblExpired As Label
    Friend WithEvents lblSimNote As Label
    Friend WithEvents btnSimulasi As Button
    Friend WithEvents btnUnduhQr As Button
    Friend WithEvents btnKembali As Button
End Class
