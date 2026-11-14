<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDataPaketLayanan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        btnMenuCustomer = New Button()
        btnMenuLayanan = New Button()
        Label9 = New Label()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel3 = New Panel()
        Panel4 = New Panel()
        Panel5 = New Panel()
        dgvLayanan = New DataGridView()
        ID = New DataGridViewTextBoxColumn()
        Nama = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        Jenis = New DataGridViewTextBoxColumn()
        Harga = New DataGridViewTextBoxColumn()
        Satuan = New DataGridViewTextBoxColumn()
        txtCari = New TextBox()
        Label8 = New Label()
        btnKosongkan = New Button()
        btnHapus = New Button()
        btnUbah = New Button()
        btnSimpan = New Button()
        cboStatus = New ComboBox()
        cboSatuan = New ComboBox()
        Label7 = New Label()
        Label6 = New Label()
        txtHarga = New TextBox()
        cboJenis = New ComboBox()
        txtNamaLayanan = New TextBox()
        txtIdLayanan = New TextBox()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        btnPemeriksaanKucing = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel5.SuspendLayout()
        CType(dgvLayanan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.SeaShell
        Panel1.Controls.Add(btnPemeriksaanKucing)
        Panel1.Controls.Add(btnMenuCustomer)
        Panel1.Controls.Add(btnMenuLayanan)
        Panel1.Controls.Add(Label9)
        Panel1.Location = New Point(10, 10)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(246, 638)
        Panel1.TabIndex = 0
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
        btnMenuCustomer.TabIndex = 2
        btnMenuCustomer.Text = "Customer"
        btnMenuCustomer.UseVisualStyleBackColor = False
        ' 
        ' btnMenuLayanan
        ' 
        btnMenuLayanan.BackColor = Color.Plum
        btnMenuLayanan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuLayanan.ForeColor = Color.DarkOliveGreen
        btnMenuLayanan.Location = New Point(38, 160)
        btnMenuLayanan.Margin = New Padding(2)
        btnMenuLayanan.Name = "btnMenuLayanan"
        btnMenuLayanan.Size = New Size(165, 37)
        btnMenuLayanan.TabIndex = 1
        btnMenuLayanan.Text = "Paket Layanan"
        btnMenuLayanan.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Snap ITC", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Plum
        Label9.Location = New Point(29, 50)
        Label9.Margin = New Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(181, 77)
        Label9.TabIndex = 0
        Label9.Text = "OMI"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightYellow
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Panel3)
        Panel2.Location = New Point(256, 10)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(890, 84)
        Panel2.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkOliveGreen
        Label1.Location = New Point(24, 23)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(270, 37)
        Label1.TabIndex = 1
        Label1.Text = "Data Paket Layanan"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Panel4)
        Panel3.Location = New Point(0, 83)
        Panel3.Margin = New Padding(2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(723, 415)
        Panel3.TabIndex = 0
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(0, 0)
        Panel4.Margin = New Padding(2)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(476, 261)
        Panel4.TabIndex = 0
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.Thistle
        Panel5.Controls.Add(dgvLayanan)
        Panel5.Controls.Add(txtCari)
        Panel5.Controls.Add(Label8)
        Panel5.Controls.Add(btnKosongkan)
        Panel5.Controls.Add(btnHapus)
        Panel5.Controls.Add(btnUbah)
        Panel5.Controls.Add(btnSimpan)
        Panel5.Controls.Add(cboStatus)
        Panel5.Controls.Add(cboSatuan)
        Panel5.Controls.Add(Label7)
        Panel5.Controls.Add(Label6)
        Panel5.Controls.Add(txtHarga)
        Panel5.Controls.Add(cboJenis)
        Panel5.Controls.Add(txtNamaLayanan)
        Panel5.Controls.Add(txtIdLayanan)
        Panel5.Controls.Add(Label5)
        Panel5.Controls.Add(Label4)
        Panel5.Controls.Add(Label3)
        Panel5.Controls.Add(Label2)
        Panel5.Location = New Point(256, 94)
        Panel5.Margin = New Padding(2)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(890, 554)
        Panel5.TabIndex = 2
        ' 
        ' dgvLayanan
        ' 
        dgvLayanan.BackgroundColor = Color.Thistle
        dgvLayanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLayanan.Columns.AddRange(New DataGridViewColumn() {ID, Nama, Status, Jenis, Harga, Satuan})
        dgvLayanan.Location = New Point(24, 316)
        dgvLayanan.Margin = New Padding(2)
        dgvLayanan.Name = "dgvLayanan"
        dgvLayanan.RowHeadersWidth = 62
        dgvLayanan.Size = New Size(839, 222)
        dgvLayanan.TabIndex = 18
        ' 
        ' ID
        ' 
        ID.HeaderText = "ID "
        ID.MinimumWidth = 8
        ID.Name = "ID"
        ID.Resizable = DataGridViewTriState.True
        ID.Width = 150
        ' 
        ' Nama
        ' 
        Nama.HeaderText = "Nama Layanan"
        Nama.MinimumWidth = 8
        Nama.Name = "Nama"
        Nama.Width = 150
        ' 
        ' Status
        ' 
        Status.HeaderText = "Status"
        Status.MinimumWidth = 8
        Status.Name = "Status"
        Status.Width = 150
        ' 
        ' Jenis
        ' 
        Jenis.HeaderText = "Jenis Layanan"
        Jenis.MinimumWidth = 8
        Jenis.Name = "Jenis"
        Jenis.Width = 150
        ' 
        ' Harga
        ' 
        Harga.HeaderText = "Harga"
        Harga.MinimumWidth = 8
        Harga.Name = "Harga"
        Harga.Width = 150
        ' 
        ' Satuan
        ' 
        Satuan.HeaderText = "Satuan"
        Satuan.MinimumWidth = 8
        Satuan.Name = "Satuan"
        Satuan.Width = 150
        ' 
        ' txtCari
        ' 
        txtCari.BackColor = Color.Snow
        txtCari.Location = New Point(157, 265)
        txtCari.Margin = New Padding(2)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(215, 27)
        txtCari.TabIndex = 17
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.DarkOliveGreen
        Label8.Location = New Point(24, 262)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(122, 28)
        Label8.TabIndex = 16
        Label8.Text = "Cari Layanan"
        ' 
        ' btnKosongkan
        ' 
        btnKosongkan.BackColor = Color.LightYellow
        btnKosongkan.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnKosongkan.ForeColor = Color.DarkOliveGreen
        btnKosongkan.Location = New Point(774, 34)
        btnKosongkan.Margin = New Padding(2)
        btnKosongkan.Name = "btnKosongkan"
        btnKosongkan.Size = New Size(98, 27)
        btnKosongkan.TabIndex = 15
        btnKosongkan.Text = "Kosongkan"
        btnKosongkan.UseVisualStyleBackColor = False
        ' 
        ' btnHapus
        ' 
        btnHapus.BackColor = Color.LightYellow
        btnHapus.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnHapus.ForeColor = Color.DarkOliveGreen
        btnHapus.Location = New Point(774, 168)
        btnHapus.Margin = New Padding(2)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(90, 27)
        btnHapus.TabIndex = 14
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = False
        ' 
        ' btnUbah
        ' 
        btnUbah.BackColor = Color.LightYellow
        btnUbah.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnUbah.ForeColor = Color.DarkOliveGreen
        btnUbah.Location = New Point(663, 168)
        btnUbah.Margin = New Padding(2)
        btnUbah.Name = "btnUbah"
        btnUbah.Size = New Size(90, 27)
        btnUbah.TabIndex = 13
        btnUbah.Text = "Ubah"
        btnUbah.UseVisualStyleBackColor = False
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.LightYellow
        btnSimpan.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnSimpan.ForeColor = Color.DarkOliveGreen
        btnSimpan.Location = New Point(551, 170)
        btnSimpan.Margin = New Padding(2)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(90, 27)
        btnSimpan.TabIndex = 12
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' cboStatus
        ' 
        cboStatus.BackColor = Color.Snow
        cboStatus.FormattingEnabled = True
        cboStatus.Location = New Point(551, 77)
        cboStatus.Margin = New Padding(2)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(184, 28)
        cboStatus.TabIndex = 11
        ' 
        ' cboSatuan
        ' 
        cboSatuan.BackColor = Color.Snow
        cboSatuan.FormattingEnabled = True
        cboSatuan.Location = New Point(551, 34)
        cboSatuan.Margin = New Padding(2)
        cboSatuan.Name = "cboSatuan"
        cboSatuan.Size = New Size(184, 28)
        cboSatuan.TabIndex = 10
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.DarkOliveGreen
        Label7.Location = New Point(454, 78)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(65, 28)
        Label7.TabIndex = 9
        Label7.Text = "Status"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.DarkOliveGreen
        Label6.Location = New Point(454, 34)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(72, 28)
        Label6.TabIndex = 8
        Label6.Text = "Satuan"
        ' 
        ' txtHarga
        ' 
        txtHarga.BackColor = Color.Snow
        txtHarga.Location = New Point(211, 172)
        txtHarga.Margin = New Padding(2)
        txtHarga.Name = "txtHarga"
        txtHarga.Size = New Size(186, 27)
        txtHarga.TabIndex = 7
        ' 
        ' cboJenis
        ' 
        cboJenis.BackColor = Color.Snow
        cboJenis.FormattingEnabled = True
        cboJenis.Location = New Point(211, 126)
        cboJenis.Margin = New Padding(2)
        cboJenis.Name = "cboJenis"
        cboJenis.Size = New Size(186, 28)
        cboJenis.TabIndex = 6
        ' 
        ' txtNamaLayanan
        ' 
        txtNamaLayanan.BackColor = Color.Snow
        txtNamaLayanan.Location = New Point(211, 80)
        txtNamaLayanan.Margin = New Padding(2)
        txtNamaLayanan.Name = "txtNamaLayanan"
        txtNamaLayanan.Size = New Size(186, 27)
        txtNamaLayanan.TabIndex = 5
        ' 
        ' txtIdLayanan
        ' 
        txtIdLayanan.BackColor = Color.Snow
        txtIdLayanan.Location = New Point(211, 37)
        txtIdLayanan.Margin = New Padding(2)
        txtIdLayanan.Name = "txtIdLayanan"
        txtIdLayanan.Size = New Size(186, 27)
        txtIdLayanan.TabIndex = 4
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.DarkOliveGreen
        Label5.Location = New Point(24, 170)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(106, 28)
        Label5.TabIndex = 3
        Label5.Text = "Harga (Rp)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.DarkOliveGreen
        Label4.Location = New Point(24, 123)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(129, 28)
        Label4.TabIndex = 2
        Label4.Text = "Jenis Layanan"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.DarkOliveGreen
        Label3.Location = New Point(24, 78)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(140, 28)
        Label3.TabIndex = 1
        Label3.Text = "Nama Layanan"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkOliveGreen
        Label2.Location = New Point(24, 34)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(107, 28)
        Label2.TabIndex = 0
        Label2.Text = "ID Layanan"
        ' 
        ' btnPemeriksaanKucing
        ' 
        btnPemeriksaanKucing.BackColor = Color.Plum
        btnPemeriksaanKucing.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPemeriksaanKucing.ForeColor = Color.SeaShell
        btnPemeriksaanKucing.Location = New Point(38, 280)
        btnPemeriksaanKucing.Margin = New Padding(2)
        btnPemeriksaanKucing.Name = "btnPemeriksaanKucing"
        btnPemeriksaanKucing.Size = New Size(165, 37)
        btnPemeriksaanKucing.TabIndex = 3
        btnPemeriksaanKucing.Text = "Pemeriksaan Kucing"
        btnPemeriksaanKucing.UseVisualStyleBackColor = False
        ' 
        ' FormDataPaketLayanan
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1156, 658)
        Controls.Add(Panel5)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "FormDataPaketLayanan"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormDataPaketLayanan"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(dgvLayanan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtHarga As TextBox
    Friend WithEvents cboJenis As ComboBox
    Friend WithEvents txtNamaLayanan As TextBox
    Friend WithEvents txtIdLayanan As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnUbah As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents cboSatuan As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnKosongkan As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents txtCari As TextBox
    Friend WithEvents dgvLayanan As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Jenis As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    Friend WithEvents Satuan As DataGridViewTextBoxColumn
    Friend WithEvents Label9 As Label
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents btnPemeriksaanKucing As Button

End Class
