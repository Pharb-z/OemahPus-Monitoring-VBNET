<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDashboard
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New Panel()
        Me.btnMenuLaporan = New Button()
        Me.btnMenuReservasi = New Button()
        Me.btnMenuPemeriksaanKucing = New Button()
        Me.btnMenuCustomer = New Button()
        Me.btnMenuLayanan = New Button()
        Me.btnMenuDashboard = New Button()
        Me.btnMenuProfil = New Button()
        Me.btnMenuReservasiPelanggan = New Button()
        Me.btnMenuRiwayat = New Button()
        Me.btnMenuAkun = New Button()
        Me.btnMenuTracking = New Button()
        Me.Label9 = New Label()
        Me.btnLogout = New Button()
        Me.Panel2 = New Panel()
        Me.lblUserInfo = New Label()
        Me.lblPageTitle = New Label()
        Me.Panel3 = New Panel()
        Me.pnlChartBox = New Panel()
        Me.chrTopLayanan = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvDashboard = New DataGridView()
        Me.pnlCardRevenue = New Panel()
        Me.lblTotalRevenue = New Label()
        Me.lblCaptionRevenue = New Label()
        Me.pnlCardTrx = New Panel()
        Me.lblTotalTrx = New Label()
        Me.lblCaptionTrx = New Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlChartBox.SuspendLayout()
        CType(Me.chrTopLayanan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDashboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCardRevenue.SuspendLayout()
        Me.pnlCardTrx.SuspendLayout()
        Me.SuspendLayout()
        '
        ' Panel1
        '
        Me.Panel1.BackColor = Color.SeaShell
        Me.Panel1.Controls.Add(Me.btnLogout)
        Me.Panel1.Controls.Add(Me.btnMenuLaporan)
        Me.Panel1.Controls.Add(Me.btnMenuReservasi)
        Me.Panel1.Controls.Add(Me.btnMenuPemeriksaanKucing)
        Me.Panel1.Controls.Add(Me.btnMenuCustomer)
        Me.Panel1.Controls.Add(Me.btnMenuLayanan)
        Me.Panel1.Controls.Add(Me.btnMenuDashboard)
        Me.Panel1.Controls.Add(Me.btnMenuProfil)
        Me.Panel1.Controls.Add(Me.btnMenuReservasiPelanggan)
        Me.Panel1.Controls.Add(Me.btnMenuRiwayat)
        Me.Panel1.Controls.Add(Me.btnMenuAkun)
        Me.Panel1.Controls.Add(Me.btnMenuTracking)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New Point(10, 10)
        Me.Panel1.Margin = New Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(246, 638)
        Me.Panel1.TabIndex = 0
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
        Me.btnMenuLaporan.TabIndex = 1
        Me.btnMenuLaporan.Text = "Laporan"
        Me.btnMenuLaporan.UseVisualStyleBackColor = False
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
        Me.btnMenuReservasi.TabIndex = 2
        Me.btnMenuReservasi.Text = "Reservasi"
        Me.btnMenuReservasi.UseVisualStyleBackColor = False
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
        Me.btnMenuPemeriksaanKucing.TabIndex = 3
        Me.btnMenuPemeriksaanKucing.Text = "Pemeriksaan Kucing"
        Me.btnMenuPemeriksaanKucing.UseVisualStyleBackColor = False
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
        ' btnMenuLayanan
        '
        Me.btnMenuLayanan.BackColor = Color.Plum
        Me.btnMenuLayanan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuLayanan.ForeColor = Color.SeaShell
        Me.btnMenuLayanan.Location = New Point(38, 220)
        Me.btnMenuLayanan.Margin = New Padding(2)
        Me.btnMenuLayanan.Name = "btnMenuLayanan"
        Me.btnMenuLayanan.Size = New Size(165, 37)
        Me.btnMenuLayanan.TabIndex = 5
        Me.btnMenuLayanan.Text = "Paket Layanan"
        Me.btnMenuLayanan.UseVisualStyleBackColor = False
        '
        ' btnMenuDashboard
        '
        Me.btnMenuDashboard.BackColor = Color.Plum
        Me.btnMenuDashboard.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuDashboard.ForeColor = Color.DarkOliveGreen
        Me.btnMenuDashboard.Location = New Point(38, 160)
        Me.btnMenuDashboard.Margin = New Padding(2)
        Me.btnMenuDashboard.Name = "btnMenuDashboard"
        Me.btnMenuDashboard.Size = New Size(165, 37)
        Me.btnMenuDashboard.TabIndex = 6
        Me.btnMenuDashboard.Text = "Dashboard"
        Me.btnMenuDashboard.UseVisualStyleBackColor = False
        '
        ' Label9
        '
        '
        ' btnMenuProfil
        '
        Me.btnMenuProfil.BackColor = Color.Plum
        Me.btnMenuProfil.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuProfil.ForeColor = Color.SeaShell
        Me.btnMenuProfil.Location = New Point(38, 220)
        Me.btnMenuProfil.Margin = New Padding(2)
        Me.btnMenuProfil.Name = "btnMenuProfil"
        Me.btnMenuProfil.Size = New Size(165, 37)
        Me.btnMenuProfil.TabIndex = 7
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
        Me.btnMenuReservasiPelanggan.TabIndex = 8
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
        Me.btnMenuRiwayat.TabIndex = 9
        Me.btnMenuRiwayat.Text = "Riwayat"
        Me.btnMenuRiwayat.UseVisualStyleBackColor = False
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
        Me.btnMenuAkun.TabIndex = 10
        Me.btnMenuAkun.Text = "Akun Saya"
        Me.btnMenuAkun.UseVisualStyleBackColor = False
        '
        ' btnMenuTracking
        '
        Me.btnMenuTracking.BackColor = Color.Plum
        Me.btnMenuTracking.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuTracking.ForeColor = Color.SeaShell
        Me.btnMenuTracking.Location = New Point(38, 460)
        Me.btnMenuTracking.Margin = New Padding(2)
        Me.btnMenuTracking.Name = "btnMenuTracking"
        Me.btnMenuTracking.Size = New Size(165, 37)
        Me.btnMenuTracking.TabIndex = 11
        Me.btnMenuTracking.Text = "Pet Tracking"
        Me.btnMenuTracking.UseVisualStyleBackColor = False
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
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "OMI"
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
        Me.btnLogout.TabIndex = 13
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        ' Panel2
        '
        Me.Panel2.BackColor = Color.LightGoldenrodYellow
        Me.Panel2.Controls.Add(Me.lblUserInfo)
        Me.Panel2.Controls.Add(Me.lblPageTitle)
        Me.Panel2.Location = New Point(256, 10)
        Me.Panel2.Margin = New Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(890, 84)
        Me.Panel2.TabIndex = 14
        '
        ' lblPageTitle
        '
        Me.lblPageTitle.AutoSize = True
        Me.lblPageTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblPageTitle.ForeColor = Color.DarkOliveGreen
        Me.lblPageTitle.Location = New Point(16, 16)
        Me.lblPageTitle.Margin = New Padding(2, 0, 2, 0)
        Me.lblPageTitle.Name = "lblPageTitle"
        Me.lblPageTitle.Size = New Size(150, 46)
        Me.lblPageTitle.TabIndex = 15
        Me.lblPageTitle.Text = "Dashboard"
        '
        ' lblUserInfo
        '
        Me.lblUserInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.lblUserInfo.AutoSize = True
        Me.lblUserInfo.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblUserInfo.ForeColor = Color.DarkOliveGreen
        Me.lblUserInfo.Location = New Point(560, 48)
        Me.lblUserInfo.Margin = New Padding(2, 0, 2, 0)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Size = New Size(120, 23)
        Me.lblUserInfo.TabIndex = 16
        Me.lblUserInfo.Text = "User: - | Role: -"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.pnlChartBox)
        Me.Panel3.Controls.Add(Me.dgvDashboard)
        Me.Panel3.Controls.Add(Me.pnlCardRevenue)
        Me.Panel3.Controls.Add(Me.pnlCardTrx)
        Me.Panel3.Location = New Point(256, 94)
        Me.Panel3.Margin = New Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Size(890, 554)
        Me.Panel3.TabIndex = 17
        '
        ' pnlCardTrx
        '
        Me.pnlCardTrx.BackColor = Color.LightGoldenrodYellow
        Me.pnlCardTrx.Controls.Add(Me.lblTotalTrx)
        Me.pnlCardTrx.Controls.Add(Me.lblCaptionTrx)
        Me.pnlCardTrx.Location = New Point(24, 24)
        Me.pnlCardTrx.Margin = New Padding(2)
        Me.pnlCardTrx.Name = "pnlCardTrx"
        Me.pnlCardTrx.Size = New Size(260, 110)
        Me.pnlCardTrx.TabIndex = 18
        '
        ' lblCaptionTrx
        '
        Me.lblCaptionTrx.AutoSize = True
        Me.lblCaptionTrx.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblCaptionTrx.ForeColor = Color.DarkOliveGreen
        Me.lblCaptionTrx.Location = New Point(14, 12)
        Me.lblCaptionTrx.Margin = New Padding(2, 0, 2, 0)
        Me.lblCaptionTrx.Name = "lblCaptionTrx"
        Me.lblCaptionTrx.Size = New Size(160, 23)
        Me.lblCaptionTrx.TabIndex = 19
        Me.lblCaptionTrx.Text = "RESERVASI HARI INI"
        '
        ' lblTotalTrx
        '
        Me.lblTotalTrx.AutoSize = True
        Me.lblTotalTrx.Font = New Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblTotalTrx.ForeColor = Color.MediumVioletRed
        Me.lblTotalTrx.Location = New Point(14, 46)
        Me.lblTotalTrx.Margin = New Padding(2, 0, 2, 0)
        Me.lblTotalTrx.Name = "lblTotalTrx"
        Me.lblTotalTrx.Size = New Size(60, 51)
        Me.lblTotalTrx.TabIndex = 20
        Me.lblTotalTrx.Text = "0"
        '
        ' pnlCardRevenue
        '
        Me.pnlCardRevenue.BackColor = Color.LightGoldenrodYellow
        Me.pnlCardRevenue.Controls.Add(Me.lblTotalRevenue)
        Me.pnlCardRevenue.Controls.Add(Me.lblCaptionRevenue)
        Me.pnlCardRevenue.Location = New Point(310, 24)
        Me.pnlCardRevenue.Margin = New Padding(2)
        Me.pnlCardRevenue.Name = "pnlCardRevenue"
        Me.pnlCardRevenue.Size = New Size(300, 110)
        Me.pnlCardRevenue.TabIndex = 21
        '
        ' lblCaptionRevenue
        '
        Me.lblCaptionRevenue.AutoSize = True
        Me.lblCaptionRevenue.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblCaptionRevenue.ForeColor = Color.DarkOliveGreen
        Me.lblCaptionRevenue.Location = New Point(14, 12)
        Me.lblCaptionRevenue.Margin = New Padding(2, 0, 2, 0)
        Me.lblCaptionRevenue.Name = "lblCaptionRevenue"
        Me.lblCaptionRevenue.Size = New Size(220, 23)
        Me.lblCaptionRevenue.TabIndex = 22
        Me.lblCaptionRevenue.Text = "PENDAPATAN VALID HARI INI"
        '
        ' lblTotalRevenue
        '
        Me.lblTotalRevenue.AutoSize = True
        Me.lblTotalRevenue.Font = New Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblTotalRevenue.ForeColor = Color.MediumVioletRed
        Me.lblTotalRevenue.Location = New Point(14, 46)
        Me.lblTotalRevenue.Margin = New Padding(2, 0, 2, 0)
        Me.lblTotalRevenue.Name = "lblTotalRevenue"
        Me.lblTotalRevenue.Size = New Size(90, 51)
        Me.lblTotalRevenue.TabIndex = 23
        Me.lblTotalRevenue.Text = "Rp 0"
        '
        ' pnlChartBox
        '
        Me.pnlChartBox.BackColor = Color.Thistle
        Me.pnlChartBox.Controls.Add(Me.chrTopLayanan)
        Me.pnlChartBox.Location = New Point(24, 160)
        Me.pnlChartBox.Margin = New Padding(2)
        Me.pnlChartBox.Name = "pnlChartBox"
        Me.pnlChartBox.Size = New Size(820, 360)
        Me.pnlChartBox.TabIndex = 24
        '
        ' chrTopLayanan
        '
        Me.chrTopLayanan.BackColor = Color.SeaShell
        Me.chrTopLayanan.Dock = DockStyle.Fill
        Me.chrTopLayanan.Name = "chrTopLayanan"
        '
        ' dgvDashboard
        '
        Me.dgvDashboard.AllowUserToAddRows = False
        Me.dgvDashboard.AllowUserToDeleteRows = False
        Me.dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDashboard.BackgroundColor = Color.Thistle
        Me.dgvDashboard.Location = New Point(24, 160)
        Me.dgvDashboard.Name = "dgvDashboard"
        Me.dgvDashboard.ReadOnly = True
        Me.dgvDashboard.RowHeadersVisible = False
        Me.dgvDashboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvDashboard.Size = New Size(820, 360)
        Me.dgvDashboard.TabIndex = 25
        Me.dgvDashboard.Visible = False
        '
        ' FormDashboard
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
        Me.Name = "FormDashboard"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "FormDashboard"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlChartBox.ResumeLayout(False)
        CType(Me.chrTopLayanan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDashboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCardRevenue.ResumeLayout(False)
        Me.pnlCardRevenue.PerformLayout()
        Me.pnlCardTrx.ResumeLayout(False)
        Me.pnlCardTrx.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuProfil As Button
    Friend WithEvents btnMenuReservasiPelanggan As Button
    Friend WithEvents btnMenuRiwayat As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnMenuTracking As Button
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents btnMenuPemeriksaanKucing As Button
    Friend WithEvents btnMenuReservasi As Button
    Friend WithEvents btnMenuLaporan As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblPageTitle As Label
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents pnlCardTrx As Panel
    Friend WithEvents lblCaptionTrx As Label
    Friend WithEvents lblTotalTrx As Label
    Friend WithEvents pnlCardRevenue As Panel
    Friend WithEvents lblCaptionRevenue As Label
    Friend WithEvents lblTotalRevenue As Label
    Friend WithEvents pnlChartBox As Panel
    Friend WithEvents chrTopLayanan As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dgvDashboard As DataGridView
End Class
