<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        btnMenuLaporan = New Button()
        btnMenuAkun = New Button()
        btnLogout = New Button()
        btnMenuReservasi = New Button()
        btnMenuPemeriksaanKucing = New Button()
        btnMenuCustomer = New Button()
        btnMenuDashboard = New Button()
        btnMenuLayanan = New Button()
        Label1 = New Label()
        Panel2 = New Panel()
        Label2 = New Label()
        Panel3 = New Panel()
        pnlCard = New Panel()
        lblTotalCaption = New Label()
        lblGrandTotal = New Label()
        lblJumlahCaption = New Label()
        lblJumlahReservasi = New Label()
        lblRingkasanCaption = New Label()
        lblRingkasanNilai = New Label()
        btnExport = New Button()
        btnCetak = New Button()
        btnReset = New Button()
        lblPeriodeCaption = New Label()
        dtpDari = New DateTimePicker()
        lblSampai = New Label()
        dtpSampai = New DateTimePicker()
        lblCariCaption = New Label()
        txtCari = New TextBox()
        cmbJenis = New ComboBox()
        dgvLaporan = New DataGridView()
        lblStatus = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvLaporan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.SeaShell
        Panel1.Controls.Add(btnMenuLaporan)
        Panel1.Controls.Add(btnLogout)
        Panel1.Controls.Add(btnMenuAkun)
        Panel1.Controls.Add(btnMenuReservasi)
        Panel1.Controls.Add(btnMenuPemeriksaanKucing)
        Panel1.Controls.Add(btnMenuCustomer)
        Panel1.Controls.Add(btnMenuDashboard)
        Panel1.Controls.Add(btnMenuLayanan)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(10, 10)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(246, 638)
        Panel1.TabIndex = 0
        ' 
        ' btnMenuLaporan
        ' 
        btnMenuLaporan.BackColor = Color.Plum
        btnMenuLaporan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuLaporan.ForeColor = Color.DarkOliveGreen
        btnMenuLaporan.Location = New Point(38, 460)
        btnMenuLaporan.Margin = New Padding(2)
        btnMenuLaporan.Name = "btnMenuLaporan"
        btnMenuLaporan.Size = New Size(165, 37)
        btnMenuLaporan.TabIndex = 1
        btnMenuLaporan.Text = "Laporan"
        btnMenuLaporan.UseVisualStyleBackColor = False
        '
        ' btnMenuAkun
        '
        btnMenuAkun.BackColor = Color.Plum
        btnMenuAkun.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuAkun.ForeColor = Color.SeaShell
        btnMenuAkun.Location = New Point(38, 520)
        btnMenuAkun.Margin = New Padding(2)
        btnMenuAkun.Name = "btnMenuAkun"
        btnMenuAkun.Size = New Size(165, 37)
        btnMenuAkun.TabIndex = 2
        btnMenuAkun.Text = "Akun Saya"
        btnMenuAkun.UseVisualStyleBackColor = False
        '
        ' btnLogout
        '
        btnLogout.BackColor = Color.Plum
        btnLogout.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.SeaShell
        btnLogout.Location = New Point(38, 580)
        btnLogout.Margin = New Padding(2)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(165, 37)
        btnLogout.TabIndex = 3
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnMenuReservasi
        ' 
        btnMenuReservasi.BackColor = Color.Plum
        btnMenuReservasi.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuReservasi.ForeColor = Color.SeaShell
        btnMenuReservasi.Location = New Point(38, 400)
        btnMenuReservasi.Margin = New Padding(2)
        btnMenuReservasi.Name = "btnMenuReservasi"
        btnMenuReservasi.Size = New Size(165, 37)
        btnMenuReservasi.TabIndex = 4
        btnMenuReservasi.Text = "Reservasi"
        btnMenuReservasi.UseVisualStyleBackColor = False
        ' 
        ' btnMenuPemeriksaanKucing
        ' 
        btnMenuPemeriksaanKucing.BackColor = Color.Plum
        btnMenuPemeriksaanKucing.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuPemeriksaanKucing.ForeColor = Color.SeaShell
        btnMenuPemeriksaanKucing.Location = New Point(38, 340)
        btnMenuPemeriksaanKucing.Margin = New Padding(2)
        btnMenuPemeriksaanKucing.Name = "btnMenuPemeriksaanKucing"
        btnMenuPemeriksaanKucing.Size = New Size(165, 37)
        btnMenuPemeriksaanKucing.TabIndex = 5
        btnMenuPemeriksaanKucing.Text = "Pemeriksaan Kucing"
        btnMenuPemeriksaanKucing.UseVisualStyleBackColor = False
        ' 
        ' btnMenuCustomer
        ' 
        btnMenuCustomer.BackColor = Color.Plum
        btnMenuCustomer.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuCustomer.ForeColor = Color.SeaShell
        btnMenuCustomer.Location = New Point(38, 280)
        btnMenuCustomer.Margin = New Padding(2)
        btnMenuCustomer.Name = "btnMenuCustomer"
        btnMenuCustomer.Size = New Size(165, 37)
        btnMenuCustomer.TabIndex = 6
        btnMenuCustomer.Text = "Customer"
        btnMenuCustomer.UseVisualStyleBackColor = False
        ' 
        ' btnMenuLayanan
        ' 
        ' btnMenuDashboard
        btnMenuDashboard.BackColor = Color.Plum
        btnMenuDashboard.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuDashboard.ForeColor = Color.SeaShell
        btnMenuDashboard.Location = New Point(38, 160)
        btnMenuDashboard.Margin = New Padding(2)
        btnMenuDashboard.Name = "btnMenuDashboard"
        btnMenuDashboard.Size = New Size(165, 37)
        btnMenuDashboard.TabIndex = 7
        btnMenuDashboard.Text = "Dashboard"
        btnMenuDashboard.UseVisualStyleBackColor = False
        btnMenuLayanan.BackColor = Color.Plum
        btnMenuLayanan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuLayanan.ForeColor = Color.SeaShell
        btnMenuLayanan.Location = New Point(38, 220)
        btnMenuLayanan.Margin = New Padding(2)
        btnMenuLayanan.Name = "btnMenuLayanan"
        btnMenuLayanan.Size = New Size(165, 37)
        btnMenuLayanan.TabIndex = 8
        btnMenuLayanan.Text = "Paket Layanan"
        btnMenuLayanan.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Snap ITC", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Plum
        Label1.Location = New Point(29, 50)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(181, 77)
        Label1.TabIndex = 9
        Label1.Text = "OMI"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightGoldenrodYellow
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(256, 10)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(890, 84)
        Panel2.TabIndex = 10
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkOliveGreen
        Label2.Location = New Point(16, 16)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(151, 46)
        Label2.TabIndex = 11
        Label2.Text = "Laporan "
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Thistle
        Panel3.Controls.Add(lblStatus)
        Panel3.Controls.Add(dgvLaporan)
        Panel3.Controls.Add(lblCariCaption)
        Panel3.Controls.Add(txtCari)
        Panel3.Controls.Add(cmbJenis)
        Panel3.Controls.Add(lblPeriodeCaption)
        Panel3.Controls.Add(dtpDari)
        Panel3.Controls.Add(lblSampai)
        Panel3.Controls.Add(dtpSampai)
        Panel3.Controls.Add(btnReset)
        Panel3.Controls.Add(lblTotalCaption)
        Panel3.Controls.Add(lblGrandTotal)
        Panel3.Controls.Add(lblJumlahCaption)
        Panel3.Controls.Add(lblJumlahReservasi)
        Panel3.Controls.Add(lblRingkasanCaption)
        Panel3.Controls.Add(lblRingkasanNilai)
        Panel3.Controls.Add(btnExport)
        Panel3.Controls.Add(btnCetak)
        Panel3.Controls.Add(pnlCard)
        Panel3.Location = New Point(256, 94)
        Panel3.Margin = New Padding(2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(890, 554)
        Panel3.TabIndex = 12
        ' 
        ' pnlCard
        ' 
        pnlCard.BackColor = Color.White
        pnlCard.BorderStyle = BorderStyle.FixedSingle
        pnlCard.Location = New Point(16, 16)
        pnlCard.Name = "pnlCard"
        pnlCard.Size = New Size(858, 522)
        pnlCard.TabIndex = 13
        ' 
        ' lblCariCaption
        ' 
        lblCariCaption.AutoSize = True
        lblCariCaption.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblCariCaption.ForeColor = Color.DarkOliveGreen
        lblCariCaption.Location = New Point(316, 22)
        lblCariCaption.Name = "lblCariCaption"
        lblCariCaption.Size = New Size(36, 20)
        lblCariCaption.TabIndex = 14
        lblCariCaption.Text = "Cari"
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(358, 20)
        txtCari.Margin = New Padding(2)
        txtCari.Name = "txtCari"
        txtCari.PlaceholderText = "kata kunci..."
        txtCari.Size = New Size(233, 27)
        txtCari.TabIndex = 15
        ' 
        ' cmbJenis
        ' 
        cmbJenis.DropDownStyle = ComboBoxStyle.DropDownList
        cmbJenis.FormattingEnabled = True
        cmbJenis.Location = New Point(24, 20)
        cmbJenis.Margin = New Padding(2)
        cmbJenis.Name = "cmbJenis"
        cmbJenis.Size = New Size(270, 28)
        cmbJenis.TabIndex = 16
        ' 
        ' lblPeriodeCaption
        ' 
        lblPeriodeCaption.AutoSize = True
        lblPeriodeCaption.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblPeriodeCaption.ForeColor = Color.DarkOliveGreen
        lblPeriodeCaption.Location = New Point(24, 62)
        lblPeriodeCaption.Name = "lblPeriodeCaption"
        lblPeriodeCaption.Size = New Size(56, 20)
        lblPeriodeCaption.TabIndex = 17
        lblPeriodeCaption.Text = "Periode"
        ' 
        ' dtpDari
        ' 
        dtpDari.Format = DateTimePickerFormat.Short
        dtpDari.Location = New Point(90, 58)
        dtpDari.Name = "dtpDari"
        dtpDari.Size = New Size(150, 27)
        dtpDari.TabIndex = 18
        ' 
        ' lblSampai
        ' 
        lblSampai.AutoSize = True
        lblSampai.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblSampai.ForeColor = Color.DarkOliveGreen
        lblSampai.Location = New Point(252, 62)
        lblSampai.Name = "lblSampai"
        lblSampai.Size = New Size(21, 20)
        lblSampai.TabIndex = 19
        lblSampai.Text = "s/d"
        ' 
        ' dtpSampai
        ' 
        dtpSampai.Format = DateTimePickerFormat.Short
        dtpSampai.Location = New Point(282, 58)
        dtpSampai.Name = "dtpSampai"
        dtpSampai.Size = New Size(150, 27)
        dtpSampai.TabIndex = 20
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.LightGoldenrodYellow
        btnReset.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnReset.ForeColor = Color.DarkOliveGreen
        btnReset.Location = New Point(450, 58)
        btnReset.Margin = New Padding(2)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(110, 40)
        btnReset.TabIndex = 21
        btnReset.Text = "Reset Filter"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' lblTotalCaption
        ' 
        lblTotalCaption.AutoSize = True
        lblTotalCaption.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblTotalCaption.ForeColor = Color.DarkOliveGreen
        lblTotalCaption.Location = New Point(24, 100)
        lblTotalCaption.Name = "lblTotalCaption"
        lblTotalCaption.Size = New Size(135, 23)
        lblTotalCaption.TabIndex = 22
        lblTotalCaption.Text = "Total Pendapatan"
        ' 
        ' lblGrandTotal
        ' 
        lblGrandTotal.AutoSize = True
        lblGrandTotal.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblGrandTotal.ForeColor = Color.MediumVioletRed
        lblGrandTotal.Location = New Point(24, 124)
        lblGrandTotal.Name = "lblGrandTotal"
        lblGrandTotal.Size = New Size(41, 23)
        lblGrandTotal.TabIndex = 23
        lblGrandTotal.Text = "Rp 0"
        ' 
        ' lblJumlahCaption
        ' 
        lblJumlahCaption.AutoSize = True
        lblJumlahCaption.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblJumlahCaption.ForeColor = Color.DarkOliveGreen
        lblJumlahCaption.Location = New Point(260, 100)
        lblJumlahCaption.Name = "lblJumlahCaption"
        lblJumlahCaption.Size = New Size(99, 23)
        lblJumlahCaption.TabIndex = 24
        lblJumlahCaption.Text = "Jumlah Data"
        ' 
        ' lblJumlahReservasi
        ' 
        lblJumlahReservasi.AutoSize = True
        lblJumlahReservasi.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblJumlahReservasi.ForeColor = Color.MediumVioletRed
        lblJumlahReservasi.Location = New Point(260, 124)
        lblJumlahReservasi.Name = "lblJumlahReservasi"
        lblJumlahReservasi.Size = New Size(18, 23)
        lblJumlahReservasi.TabIndex = 25
        lblJumlahReservasi.Text = "0"
        ' 
        ' lblRingkasanCaption
        ' 
        lblRingkasanCaption.AutoSize = True
        lblRingkasanCaption.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblRingkasanCaption.ForeColor = Color.DarkOliveGreen
        lblRingkasanCaption.Location = New Point(450, 100)
        lblRingkasanCaption.Name = "lblRingkasanCaption"
        lblRingkasanCaption.Size = New Size(120, 23)
        lblRingkasanCaption.TabIndex = 26
        lblRingkasanCaption.Text = "Ringkasan"
        ' 
        ' lblRingkasanNilai
        ' 
        lblRingkasanNilai.AutoSize = True
        lblRingkasanNilai.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblRingkasanNilai.ForeColor = Color.MediumVioletRed
        lblRingkasanNilai.Location = New Point(450, 124)
        lblRingkasanNilai.Name = "lblRingkasanNilai"
        lblRingkasanNilai.Size = New Size(18, 23)
        lblRingkasanNilai.TabIndex = 27
        lblRingkasanNilai.Text = "-"
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.LightGoldenrodYellow
        btnExport.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnExport.ForeColor = Color.DarkOliveGreen
        btnExport.Location = New Point(650, 100)
        btnExport.Margin = New Padding(2)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(100, 40)
        btnExport.TabIndex = 28
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' btnCetak
        ' 
        btnCetak.BackColor = Color.MediumVioletRed
        btnCetak.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnCetak.ForeColor = Color.SeaShell
        btnCetak.Location = New Point(762, 100)
        btnCetak.Margin = New Padding(2)
        btnCetak.Name = "btnCetak"
        btnCetak.Size = New Size(100, 40)
        btnCetak.TabIndex = 29
        btnCetak.Text = "Cetak"
        btnCetak.UseVisualStyleBackColor = False
        ' 
        ' dgvLaporan
        ' 
        dgvLaporan.AllowUserToAddRows = False
        dgvLaporan.AllowUserToDeleteRows = False
        dgvLaporan.AllowUserToResizeRows = False
        dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvLaporan.BackgroundColor = Color.Thistle
        dgvLaporan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLaporan.Location = New Point(24, 160)
        dgvLaporan.Margin = New Padding(2)
        dgvLaporan.Name = "dgvLaporan"
        dgvLaporan.MultiSelect = False
        dgvLaporan.ReadOnly = True
        dgvLaporan.RowHeadersVisible = False
        dgvLaporan.RowHeadersWidth = 51
        dgvLaporan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLaporan.Size = New Size(842, 344)
        dgvLaporan.TabIndex = 30
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 9F, FontStyle.Italic)
        lblStatus.ForeColor = Color.DarkOliveGreen
        lblStatus.Location = New Point(24, 516)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(0, 20)
        lblStatus.TabIndex = 31
        ' 
        ' FormReport
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1156, 658)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Margin = New Padding(2)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Name = "FormReport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Laporan"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(dgvLaporan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlCard As Panel
    Friend WithEvents btnMenuLaporan As Button
    Friend WithEvents btnMenuAkun As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnMenuReservasi As Button
    Friend WithEvents btnMenuPemeriksaanKucing As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbJenis As ComboBox
    Friend WithEvents dgvLaporan As DataGridView
    Friend WithEvents btnExport As Button
    Friend WithEvents txtCari As TextBox
    Friend WithEvents btnCetak As Button
    Friend WithEvents lblTotalCaption As Label
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents lblJumlahCaption As Label
    Friend WithEvents lblJumlahReservasi As Label
    Friend WithEvents lblRingkasanCaption As Label
    Friend WithEvents lblRingkasanNilai As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents lblPeriodeCaption As Label
    Friend WithEvents dtpDari As DateTimePicker
    Friend WithEvents lblSampai As Label
    Friend WithEvents dtpSampai As DateTimePicker
    Friend WithEvents lblCariCaption As Label
    Friend WithEvents lblStatus As Label

End Class
