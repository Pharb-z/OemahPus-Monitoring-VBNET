<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReservasi
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
        btnMenuReservasi = New Button()
        btnMenuLaporan = New Button()
        Label9 = New Label()
        btnMenuPemeriksaanKucing = New Button()
        btnMenuCustomer = New Button()
        btnMenuLayanan = New Button()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel3 = New Panel()
        cmbNamaKucing = New ComboBox()
        dgvReservasi = New DataGridView()
        btnSimpan = New Button()
        btnTambah = New Button()
        cmbStatus = New ComboBox()
        txtLamaInap = New TextBox()
        dtpCheckOut = New DateTimePicker()
        dtpCheckIn = New DateTimePicker()
        txtNamaPemilik = New TextBox()
        txtIdReservasi = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TextBox1 = New TextBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvReservasi, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(255), CByte(244), CByte(238))
        Panel1.Controls.Add(btnMenuLaporan)
        Panel1.Controls.Add(btnMenuReservasi)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(btnMenuPemeriksaanKucing)
        Panel1.Controls.Add(btnMenuCustomer)
        Panel1.Controls.Add(btnMenuLayanan)
        Panel1.Location = New Point(10, 10)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(246, 638)
        Panel1.TabIndex = 0
        ' 
        ' btnMenuReservasi
        ' 
        btnMenuReservasi.BackColor = Color.Plum
        btnMenuReservasi.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuReservasi.ForeColor = Color.DarkOliveGreen
        btnMenuReservasi.Location = New Point(38, 340)
        btnMenuReservasi.Margin = New Padding(2)
        btnMenuReservasi.Name = "btnMenuReservasi"
        btnMenuReservasi.Size = New Size(165, 37)
        btnMenuReservasi.TabIndex = 33
        btnMenuReservasi.Text = "Reservasi"
        btnMenuReservasi.UseVisualStyleBackColor = False
        ' 
        ' btnMenuLaporan
        ' 
        btnMenuLaporan.BackColor = Color.Plum
        btnMenuLaporan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuLaporan.ForeColor = Color.SeaShell
        btnMenuLaporan.Location = New Point(38, 400)
        btnMenuLaporan.Margin = New Padding(2)
        btnMenuLaporan.Name = "btnMenuLaporan"
        btnMenuLaporan.Size = New Size(165, 37)
        btnMenuLaporan.TabIndex = 34
        btnMenuLaporan.Text = "Laporan"
        btnMenuLaporan.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Snap ITC", 36F)
        Label9.ForeColor = Color.Plum
        Label9.Location = New Point(29, 50)
        Label9.Margin = New Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(181, 77)
        Label9.TabIndex = 32
        Label9.Text = "OMI"
        ' 
        ' btnMenuPemeriksaanKucing
        ' 
        btnMenuPemeriksaanKucing.BackColor = Color.Plum
        btnMenuPemeriksaanKucing.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuPemeriksaanKucing.ForeColor = Color.SeaShell
        btnMenuPemeriksaanKucing.Location = New Point(38, 280)
        btnMenuPemeriksaanKucing.Margin = New Padding(2)
        btnMenuPemeriksaanKucing.Name = "btnMenuPemeriksaanKucing"
        btnMenuPemeriksaanKucing.Size = New Size(165, 37)
        btnMenuPemeriksaanKucing.TabIndex = 31
        btnMenuPemeriksaanKucing.Text = "Pemeriksaan Kucing"
        btnMenuPemeriksaanKucing.UseVisualStyleBackColor = False
        ' 
        ' btnMenuCustomer
        ' 
        btnMenuCustomer.BackColor = Color.Plum
        btnMenuCustomer.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuCustomer.ForeColor = Color.SeaShell
        btnMenuCustomer.Location = New Point(38, 220)
        btnMenuCustomer.Margin = New Padding(2)
        btnMenuCustomer.Name = "btnMenuCustomer"
        btnMenuCustomer.Size = New Size(165, 37)
        btnMenuCustomer.TabIndex = 30
        btnMenuCustomer.Text = "Customer"
        btnMenuCustomer.UseVisualStyleBackColor = False
        ' 
        ' btnMenuLayanan
        ' 
        btnMenuLayanan.BackColor = Color.Plum
        btnMenuLayanan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuLayanan.ForeColor = Color.SeaShell
        btnMenuLayanan.Location = New Point(38, 160)
        btnMenuLayanan.Margin = New Padding(2)
        btnMenuLayanan.Name = "btnMenuLayanan"
        btnMenuLayanan.Size = New Size(165, 37)
        btnMenuLayanan.TabIndex = 29
        btnMenuLayanan.Text = "Paket Layanan"
        btnMenuLayanan.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(218))
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(260, 10)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(890, 84)
        Panel2.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkOliveGreen
        Label1.Location = New Point(16, 16)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(328, 46)
        Label1.TabIndex = 0
        Label1.Text = "Reservasi Penitipan"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(229), CByte(222), CByte(239))
        Panel3.Controls.Add(cmbNamaKucing)
        Panel3.Controls.Add(dgvReservasi)
        Panel3.Controls.Add(btnSimpan)
        Panel3.Controls.Add(btnTambah)
        Panel3.Controls.Add(cmbStatus)
        Panel3.Controls.Add(txtLamaInap)
        Panel3.Controls.Add(dtpCheckOut)
        Panel3.Controls.Add(dtpCheckIn)
        Panel3.Controls.Add(txtNamaPemilik)
        Panel3.Controls.Add(txtIdReservasi)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(Label3)
        Panel3.Location = New Point(260, 98)
        Panel3.Margin = New Padding(2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(890, 554)
        Panel3.TabIndex = 2
        ' 
        ' cmbNamaKucing
        ' 
        cmbNamaKucing.DropDownStyle = ComboBoxStyle.DropDownList
        cmbNamaKucing.FormattingEnabled = True
        cmbNamaKucing.Location = New Point(173, 117)
        cmbNamaKucing.Name = "cmbNamaKucing"
        cmbNamaKucing.Size = New Size(234, 28)
        cmbNamaKucing.TabIndex = 18
        ' 
        ' dgvReservasi
        ' 
        dgvReservasi.BackgroundColor = SystemColors.ControlLightLight
        dgvReservasi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReservasi.Location = New Point(46, 267)
        dgvReservasi.Margin = New Padding(2)
        dgvReservasi.Name = "dgvReservasi"
        dgvReservasi.RowHeadersWidth = 62
        dgvReservasi.Size = New Size(778, 255)
        dgvReservasi.TabIndex = 3
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(218))
        btnSimpan.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnSimpan.ForeColor = Color.DarkOliveGreen
        btnSimpan.Location = New Point(732, 212)
        btnSimpan.Margin = New Padding(2)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(93, 39)
        btnSimpan.TabIndex = 17
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' btnTambah
        ' 
        btnTambah.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(218))
        btnTambah.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnTambah.ForeColor = Color.DarkOliveGreen
        btnTambah.Location = New Point(48, 36)
        btnTambah.Margin = New Padding(2)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(176, 33)
        btnTambah.TabIndex = 16
        btnTambah.Text = "+ Tambah Reservasi"
        btnTambah.UseVisualStyleBackColor = False
        ' 
        ' cmbStatus
        ' 
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.FormattingEnabled = True
        cmbStatus.Items.AddRange(New Object() {"Sedang Dilayani", "Sudah Dilayani"})
        cmbStatus.Location = New Point(173, 220)
        cmbStatus.Margin = New Padding(2)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(234, 28)
        cmbStatus.TabIndex = 15
        ' 
        ' txtLamaInap
        ' 
        txtLamaInap.Location = New Point(173, 184)
        txtLamaInap.Margin = New Padding(2)
        txtLamaInap.Name = "txtLamaInap"
        txtLamaInap.ReadOnly = True
        txtLamaInap.Size = New Size(234, 27)
        txtLamaInap.TabIndex = 14
        ' 
        ' dtpCheckOut
        ' 
        dtpCheckOut.Location = New Point(592, 119)
        dtpCheckOut.Margin = New Padding(2)
        dtpCheckOut.Name = "dtpCheckOut"
        dtpCheckOut.Size = New Size(234, 27)
        dtpCheckOut.TabIndex = 13
        ' 
        ' dtpCheckIn
        ' 
        dtpCheckIn.Location = New Point(592, 86)
        dtpCheckIn.Margin = New Padding(2)
        dtpCheckIn.Name = "dtpCheckIn"
        dtpCheckIn.Size = New Size(234, 27)
        dtpCheckIn.TabIndex = 12
        ' 
        ' txtNamaPemilik
        ' 
        txtNamaPemilik.Location = New Point(173, 152)
        txtNamaPemilik.Margin = New Padding(2)
        txtNamaPemilik.Name = "txtNamaPemilik"
        txtNamaPemilik.ReadOnly = True
        txtNamaPemilik.Size = New Size(234, 27)
        txtNamaPemilik.TabIndex = 11
        ' 
        ' txtIdReservasi
        ' 
        txtIdReservasi.Location = New Point(173, 85)
        txtIdReservasi.Margin = New Padding(2)
        txtIdReservasi.Name = "txtIdReservasi"
        txtIdReservasi.ReadOnly = True
        txtIdReservasi.Size = New Size(234, 27)
        txtIdReservasi.TabIndex = 8
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label8.ForeColor = Color.DarkOliveGreen
        Label8.Location = New Point(46, 220)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(60, 23)
        Label8.TabIndex = 7
        Label8.Text = "Status"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label7.ForeColor = Color.DarkOliveGreen
        Label7.Location = New Point(46, 185)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(93, 23)
        Label7.TabIndex = 6
        Label7.Text = "Lama Inap"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label6.ForeColor = Color.DarkOliveGreen
        Label6.Location = New Point(471, 118)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(94, 23)
        Label6.TabIndex = 5
        Label6.Text = "Check-Out"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label5.ForeColor = Color.DarkOliveGreen
        Label5.Location = New Point(471, 85)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(79, 23)
        Label5.TabIndex = 4
        Label5.Text = "Check-In"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label4.ForeColor = Color.DarkOliveGreen
        Label4.Location = New Point(46, 152)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(121, 23)
        Label4.TabIndex = 3
        Label4.Text = "Nama Pemilik"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.ForeColor = Color.DarkOliveGreen
        Label2.Location = New Point(48, 118)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(117, 23)
        Label2.TabIndex = 1
        Label2.Text = "Nama Kucing"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.ForeColor = Color.DarkOliveGreen
        Label3.Location = New Point(48, 86)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(107, 23)
        Label3.TabIndex = 2
        Label3.Text = "ID Reservasi"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(216, 68)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(291, 27)
        TextBox1.TabIndex = 9
        ' 
        ' FormReservasi
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1156, 658)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Margin = New Padding(2)
        Name = "FormReservasi"
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(dgvReservasi, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtIdReservasi As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtLamaInap As TextBox
    Friend WithEvents dtpCheckOut As DateTimePicker
    Friend WithEvents dtpCheckIn As DateTimePicker
    Friend WithEvents txtNamaPemilik As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents dgvReservasi As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnMenuPemeriksaanKucing As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents btnMenuReservasi As Button
    Friend WithEvents btnMenuLaporan As Button
    Friend WithEvents cmbNamaKucing As ComboBox
End Class
