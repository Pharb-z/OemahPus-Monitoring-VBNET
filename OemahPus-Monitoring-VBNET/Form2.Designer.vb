<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Label9 = New Label()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        btnStatusPembayaran = New Button()
        btnLaporan = New Button()
        btnRiwayat = New Button()
        btnReservasi = New Button()
        btnProfil = New Button()
        btnHome = New Button()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel3 = New Panel()
        btnSimpan = New Button()
        btnTambahReservasi = New Button()
        cbStatus = New ComboBox()
        txtRawatInap = New TextBox()
        dtmCheckOut = New DateTimePicker()
        dtmCheckIn = New DateTimePicker()
        txtNamaPemilik = New TextBox()
        txtNamaKucing = New TextBox()
        txtIDReservasi = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TextBox1 = New TextBox()
        DataGridView1 = New DataGridView()
        reservation_id = New DataGridViewTextBoxColumn()
        cat_name = New DataGridViewTextBoxColumn()
        customer_name = New DataGridViewTextBoxColumn()
        check_in = New DataGridViewTextBoxColumn()
        check_out = New DataGridViewTextBoxColumn()
        status = New DataGridViewTextBoxColumn()
        update = New DataGridViewButtonColumn()
        hapus = New DataGridViewButtonColumn()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(255), CByte(244), CByte(238))
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(btnStatusPembayaran)
        Panel1.Controls.Add(btnLaporan)
        Panel1.Controls.Add(btnRiwayat)
        Panel1.Controls.Add(btnReservasi)
        Panel1.Controls.Add(btnProfil)
        Panel1.Controls.Add(btnHome)
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(336, 780)
        Panel1.TabIndex = 0
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Broadway", 28.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.LightPink
        Label9.Location = New Point(84, 59)
        Label9.Name = "Label9"
        Label9.Size = New Size(148, 63)
        Label9.TabIndex = 1
        Label9.Text = "OMI"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.paw__1_
        PictureBox2.Location = New Point(268, 102)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(34, 37)
        PictureBox2.TabIndex = 24
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.paw__1_
        PictureBox1.Location = New Point(238, 59)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(34, 37)
        PictureBox1.TabIndex = 18
        PictureBox1.TabStop = False
        ' 
        ' btnStatusPembayaran
        ' 
        btnStatusPembayaran.BackColor = Color.FromArgb(CByte(255), CByte(182), CByte(200))
        btnStatusPembayaran.Location = New Point(48, 585)
        btnStatusPembayaran.Name = "btnStatusPembayaran"
        btnStatusPembayaran.Size = New Size(243, 34)
        btnStatusPembayaran.TabIndex = 23
        btnStatusPembayaran.Text = "Status Pembayaran"
        btnStatusPembayaran.UseVisualStyleBackColor = False
        ' 
        ' btnLaporan
        ' 
        btnLaporan.BackColor = Color.FromArgb(CByte(255), CByte(182), CByte(200))
        btnLaporan.Location = New Point(48, 522)
        btnLaporan.Name = "btnLaporan"
        btnLaporan.Size = New Size(243, 34)
        btnLaporan.TabIndex = 22
        btnLaporan.Text = "Laporan Harian"
        btnLaporan.UseVisualStyleBackColor = False
        ' 
        ' btnRiwayat
        ' 
        btnRiwayat.BackColor = Color.FromArgb(CByte(255), CByte(182), CByte(200))
        btnRiwayat.Location = New Point(48, 452)
        btnRiwayat.Name = "btnRiwayat"
        btnRiwayat.Size = New Size(243, 34)
        btnRiwayat.TabIndex = 21
        btnRiwayat.Text = "Riwayat Penitipan"
        btnRiwayat.UseVisualStyleBackColor = False
        ' 
        ' btnReservasi
        ' 
        btnReservasi.BackColor = Color.FromArgb(CByte(255), CByte(182), CByte(200))
        btnReservasi.Location = New Point(48, 387)
        btnReservasi.Name = "btnReservasi"
        btnReservasi.Size = New Size(243, 34)
        btnReservasi.TabIndex = 20
        btnReservasi.Text = "Reservasi Penitipan"
        btnReservasi.UseVisualStyleBackColor = False
        ' 
        ' btnProfil
        ' 
        btnProfil.BackColor = Color.FromArgb(CByte(255), CByte(182), CByte(200))
        btnProfil.Location = New Point(48, 321)
        btnProfil.Name = "btnProfil"
        btnProfil.Size = New Size(243, 34)
        btnProfil.TabIndex = 19
        btnProfil.Text = "Profil Kucing"
        btnProfil.UseVisualStyleBackColor = False
        ' 
        ' btnHome
        ' 
        btnHome.BackColor = Color.FromArgb(CByte(255), CByte(182), CByte(200))
        btnHome.Location = New Point(48, 254)
        btnHome.Name = "btnHome"
        btnHome.Size = New Size(243, 34)
        btnHome.TabIndex = 18
        btnHome.Text = "Home"
        btnHome.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(218))
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(354, 12)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1077, 86)
        Panel2.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(390, 54)
        Label1.TabIndex = 0
        Label1.Text = "Reservasi Penitipan"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(229), CByte(222), CByte(239))
        Panel3.Controls.Add(btnSimpan)
        Panel3.Controls.Add(btnTambahReservasi)
        Panel3.Controls.Add(cbStatus)
        Panel3.Controls.Add(txtRawatInap)
        Panel3.Controls.Add(dtmCheckOut)
        Panel3.Controls.Add(dtmCheckIn)
        Panel3.Controls.Add(txtNamaPemilik)
        Panel3.Controls.Add(txtNamaKucing)
        Panel3.Controls.Add(txtIDReservasi)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(Label3)
        Panel3.Location = New Point(354, 104)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1077, 327)
        Panel3.TabIndex = 2
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(218))
        btnSimpan.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnSimpan.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        btnSimpan.Location = New Point(938, 265)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(116, 49)
        btnSimpan.TabIndex = 17
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' btnTambahReservasi
        ' 
        btnTambahReservasi.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(218))
        btnTambahReservasi.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnTambahReservasi.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        btnTambahReservasi.Location = New Point(60, 45)
        btnTambahReservasi.Name = "btnTambahReservasi"
        btnTambahReservasi.Size = New Size(220, 34)
        btnTambahReservasi.TabIndex = 16
        btnTambahReservasi.Text = "+ Tambah Reservasi"
        btnTambahReservasi.UseVisualStyleBackColor = False
        ' 
        ' cbStatus
        ' 
        cbStatus.FormattingEnabled = True
        cbStatus.Items.AddRange(New Object() {"Sedang Dilayani", "Sudah Dilayani"})
        cbStatus.Location = New Point(216, 275)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(182, 33)
        cbStatus.TabIndex = 15
        ' 
        ' txtRawatInap
        ' 
        txtRawatInap.Location = New Point(216, 230)
        txtRawatInap.Name = "txtRawatInap"
        txtRawatInap.ReadOnly = True
        txtRawatInap.Size = New Size(150, 31)
        txtRawatInap.TabIndex = 14
        ' 
        ' dtmCheckOut
        ' 
        dtmCheckOut.Location = New Point(763, 129)
        dtmCheckOut.Name = "dtmCheckOut"
        dtmCheckOut.Size = New Size(291, 31)
        dtmCheckOut.TabIndex = 13
        ' 
        ' dtmCheckIn
        ' 
        dtmCheckIn.Location = New Point(763, 92)
        dtmCheckIn.Name = "dtmCheckIn"
        dtmCheckIn.Size = New Size(291, 31)
        dtmCheckIn.TabIndex = 12
        ' 
        ' txtNamaPemilik
        ' 
        txtNamaPemilik.Location = New Point(216, 190)
        txtNamaPemilik.Name = "txtNamaPemilik"
        txtNamaPemilik.Size = New Size(291, 31)
        txtNamaPemilik.TabIndex = 11
        ' 
        ' txtNamaKucing
        ' 
        txtNamaKucing.Location = New Point(216, 149)
        txtNamaKucing.Name = "txtNamaKucing"
        txtNamaKucing.Size = New Size(291, 31)
        txtNamaKucing.TabIndex = 9
        ' 
        ' txtIDReservasi
        ' 
        txtIDReservasi.Location = New Point(216, 106)
        txtIDReservasi.Name = "txtIDReservasi"
        txtIDReservasi.ReadOnly = True
        txtIDReservasi.Size = New Size(150, 31)
        txtIDReservasi.TabIndex = 8
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label8.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        Label8.Location = New Point(58, 275)
        Label8.Name = "Label8"
        Label8.Size = New Size(71, 28)
        Label8.TabIndex = 7
        Label8.Text = "Status"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label7.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        Label7.Location = New Point(58, 231)
        Label7.Name = "Label7"
        Label7.Size = New Size(109, 28)
        Label7.TabIndex = 6
        Label7.Text = "Lama Inap"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label6.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        Label6.Location = New Point(651, 135)
        Label6.Name = "Label6"
        Label6.Size = New Size(110, 28)
        Label6.TabIndex = 5
        Label6.Text = "Check-Out"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label5.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        Label5.Location = New Point(651, 98)
        Label5.Name = "Label5"
        Label5.Size = New Size(93, 28)
        Label5.TabIndex = 4
        Label5.Text = "Check-In"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label4.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        Label4.Location = New Point(58, 190)
        Label4.Name = "Label4"
        Label4.Size = New Size(143, 28)
        Label4.TabIndex = 3
        Label4.Text = "Nama Pemilik"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label2.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        Label2.Location = New Point(60, 147)
        Label2.Name = "Label2"
        Label2.Size = New Size(139, 28)
        Label2.TabIndex = 1
        Label2.Text = "Nama Kucing"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label3.ForeColor = Color.FromArgb(CByte(110), CByte(137), CByte(95))
        Label3.Location = New Point(60, 107)
        Label3.Name = "Label3"
        Label3.Size = New Size(129, 28)
        Label3.TabIndex = 2
        Label3.Text = "ID Reservasi"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(216, 68)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(291, 31)
        TextBox1.TabIndex = 9
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = SystemColors.ControlLightLight
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {reservation_id, cat_name, customer_name, check_in, check_out, status, update, hapus})
        DataGridView1.Location = New Point(354, 437)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1077, 355)
        DataGridView1.TabIndex = 3
        ' 
        ' reservation_id
        ' 
        reservation_id.HeaderText = "ID Reservasi"
        reservation_id.MinimumWidth = 8
        reservation_id.Name = "reservation_id"
        reservation_id.ReadOnly = True
        reservation_id.Width = 90
        ' 
        ' cat_name
        ' 
        cat_name.HeaderText = "Nama Kucing"
        cat_name.MinimumWidth = 8
        cat_name.Name = "cat_name"
        cat_name.ReadOnly = True
        cat_name.Width = 170
        ' 
        ' customer_name
        ' 
        customer_name.HeaderText = "Nama Pemilik"
        customer_name.MinimumWidth = 8
        customer_name.Name = "customer_name"
        customer_name.ReadOnly = True
        customer_name.Width = 170
        ' 
        ' check_in
        ' 
        check_in.HeaderText = "Check-In"
        check_in.MinimumWidth = 8
        check_in.Name = "check_in"
        check_in.ReadOnly = True
        check_in.Width = 150
        ' 
        ' check_out
        ' 
        check_out.HeaderText = "Check-Out"
        check_out.MinimumWidth = 8
        check_out.Name = "check_out"
        check_out.ReadOnly = True
        check_out.Width = 150
        ' 
        ' status
        ' 
        status.HeaderText = "Status"
        status.MinimumWidth = 8
        status.Name = "status"
        status.ReadOnly = True
        status.Width = 120
        ' 
        ' update
        ' 
        update.HeaderText = "Update"
        update.MinimumWidth = 8
        update.Name = "update"
        update.ReadOnly = True
        update.Resizable = DataGridViewTriState.True
        update.SortMode = DataGridViewColumnSortMode.Automatic
        update.Text = "Update"
        update.UseColumnTextForButtonValue = True
        update.Width = 80
        ' 
        ' hapus
        ' 
        hapus.HeaderText = "Hapus"
        hapus.MinimumWidth = 8
        hapus.Name = "hapus"
        hapus.ReadOnly = True
        hapus.Resizable = DataGridViewTriState.True
        hapus.SortMode = DataGridViewColumnSortMode.Automatic
        hapus.Text = "Hapus"
        hapus.UseColumnTextForButtonValue = True
        hapus.Width = 80
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1441, 804)
        Controls.Add(DataGridView1)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form2"
        Text = "Form2"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNamaKucing As TextBox
    Friend WithEvents txtIDReservasi As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRawatInap As TextBox
    Friend WithEvents dtmCheckOut As DateTimePicker
    Friend WithEvents dtmCheckIn As DateTimePicker
    Friend WithEvents txtNamaPemilik As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnTambahReservasi As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnReservasi As Button
    Friend WithEvents btnProfil As Button
    Friend WithEvents btnStatusPembayaran As Button
    Friend WithEvents btnLaporan As Button
    Friend WithEvents btnRiwayat As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents reservation_id As DataGridViewTextBoxColumn
    Friend WithEvents cat_name As DataGridViewTextBoxColumn
    Friend WithEvents customer_name As DataGridViewTextBoxColumn
    Friend WithEvents check_in As DataGridViewTextBoxColumn
    Friend WithEvents check_out As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents update As DataGridViewButtonColumn
    Friend WithEvents hapus As DataGridViewButtonColumn
End Class
