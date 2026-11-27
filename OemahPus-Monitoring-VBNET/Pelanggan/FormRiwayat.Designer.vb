<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRiwayat
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
        Me.dgvReservasi = New DataGridView()
        Me.Label4 = New Label()
        Me.dgvPembayaran = New DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvReservasi, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPembayaran, ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label2.Text = "Riwayat"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.dgvPembayaran)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.dgvReservasi)
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
        Me.Label3.Location = New Point(24, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(400, 23)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Reservasi Saya"
        '
        ' dgvReservasi
        '
        Me.dgvReservasi.AllowUserToAddRows = False
        Me.dgvReservasi.AllowUserToDeleteRows = False
        Me.dgvReservasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReservasi.BackColor = Color.Thistle
        Me.dgvReservasi.BackgroundColor = Color.Thistle
        Me.dgvReservasi.Location = New Point(24, 46)
        Me.dgvReservasi.Name = "dgvReservasi"
        Me.dgvReservasi.ReadOnly = True
        Me.dgvReservasi.RowHeadersVisible = False
        Me.dgvReservasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvReservasi.Size = New Size(842, 220)
        Me.dgvReservasi.TabIndex = 14
        '
        ' Label4
        '
        Me.Label4.AutoSize = False
        Me.Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label4.ForeColor = Color.DarkOliveGreen
        Me.Label4.Location = New Point(24, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(400, 23)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Pembayaran"
        '
        ' dgvPembayaran
        '
        Me.dgvPembayaran.AllowUserToAddRows = False
        Me.dgvPembayaran.AllowUserToDeleteRows = False
        Me.dgvPembayaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPembayaran.BackColor = Color.Thistle
        Me.dgvPembayaran.BackgroundColor = Color.Thistle
        Me.dgvPembayaran.Location = New Point(24, 310)
        Me.dgvPembayaran.Name = "dgvPembayaran"
        Me.dgvPembayaran.ReadOnly = True
        Me.dgvPembayaran.RowHeadersVisible = False
        Me.dgvPembayaran.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvPembayaran.Size = New Size(842, 220)
        Me.dgvPembayaran.TabIndex = 16
        '
        ' FormRiwayat
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
        Me.Name = "FormRiwayat"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Riwayat"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvReservasi, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPembayaran, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvReservasi As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvPembayaran As DataGridView
End Class
