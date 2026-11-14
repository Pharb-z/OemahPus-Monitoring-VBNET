<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMedisKucing
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
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Label1 = New Label()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Panel3 = New Panel()
        Label9 = New Label()
        Panel4 = New Panel()
        cmbNamaKucing = New ComboBox()
        txtCari = New TextBox()
        Label8 = New Label()
        btnKosongkan = New Button()
        btnHapus = New Button()
        btnUbah = New Button()
        btnSimpan = New Button()
        cmbTemuanParasit = New ComboBox()
        Label7 = New Label()
        txtCatatanKesehatan = New TextBox()
        txtBeratBadan = New TextBox()
        dtpTanggalPemeriksaan = New DateTimePicker()
        txtSuhuTubuh = New TextBox()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        dgvPemeriksaan = New DataGridView()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        CType(dgvPemeriksaan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Location = New Point(42, 20)
        TableLayoutPanel1.Margin = New Padding(2)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(0, 0)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(298, 235)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(0, 0)
        Panel1.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.SeaShell
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Button3)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(Button1)
        Panel2.Location = New Point(10, 10)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(246, 638)
        Panel2.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Snap ITC", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Plum
        Label1.Location = New Point(29, 50)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(184, 77)
        Label1.TabIndex = 3
        Label1.Text = "OMI"
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Plum
        Button3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.DarkOliveGreen
        Button3.Location = New Point(38, 280)
        Button3.Margin = New Padding(2)
        Button3.Name = "Button3"
        Button3.Size = New Size(165, 37)
        Button3.TabIndex = 2
        Button3.Text = "Pemeriksaan Kucing"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Plum
        Button2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.SeaShell
        Button2.Location = New Point(38, 220)
        Button2.Margin = New Padding(2)
        Button2.Name = "Button2"
        Button2.Size = New Size(165, 37)
        Button2.TabIndex = 1
        Button2.Text = "Customer"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Plum
        Button1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.SeaShell
        Button1.Location = New Point(38, 160)
        Button1.Margin = New Padding(2)
        Button1.Name = "Button1"
        Button1.Size = New Size(165, 37)
        Button1.TabIndex = 0
        Button1.Text = "Paket Layanan"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightGoldenrodYellow
        Panel3.Controls.Add(Label9)
        Panel3.Location = New Point(256, 10)
        Panel3.Margin = New Padding(2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(890, 84)
        Panel3.TabIndex = 4
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.DarkOliveGreen
        Label9.Location = New Point(28, 29)
        Label9.Margin = New Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(275, 37)
        Label9.TabIndex = 0
        Label9.Text = "Pemeriksaan Kucing"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Thistle
        Panel4.Controls.Add(cmbNamaKucing)
        Panel4.Controls.Add(txtCari)
        Panel4.Controls.Add(Label8)
        Panel4.Controls.Add(btnKosongkan)
        Panel4.Controls.Add(btnHapus)
        Panel4.Controls.Add(btnUbah)
        Panel4.Controls.Add(btnSimpan)
        Panel4.Controls.Add(cmbTemuanParasit)
        Panel4.Controls.Add(Label7)
        Panel4.Controls.Add(txtCatatanKesehatan)
        Panel4.Controls.Add(txtBeratBadan)
        Panel4.Controls.Add(dtpTanggalPemeriksaan)
        Panel4.Controls.Add(txtSuhuTubuh)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(Label5)
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(Label3)
        Panel4.Controls.Add(Label2)
        Panel4.Controls.Add(dgvPemeriksaan)
        Panel4.Location = New Point(256, 94)
        Panel4.Margin = New Padding(2)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(890, 554)
        Panel4.TabIndex = 5
        ' 
        ' cmbNamaKucing
        ' 
        cmbNamaKucing.FormattingEnabled = True
        cmbNamaKucing.Location = New Point(28, 289)
        cmbNamaKucing.Name = "cmbNamaKucing"
        cmbNamaKucing.Size = New Size(239, 28)
        cmbNamaKucing.TabIndex = 20
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(76, 24)
        txtCari.Margin = New Padding(2)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(191, 27)
        txtCari.TabIndex = 19
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.DarkOliveGreen
        Label8.Location = New Point(28, 24)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(40, 23)
        Label8.TabIndex = 18
        Label8.Text = "Cari"
        ' 
        ' btnKosongkan
        ' 
        btnKosongkan.BackColor = Color.LightGoldenrodYellow
        btnKosongkan.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnKosongkan.ForeColor = Color.DarkOliveGreen
        btnKosongkan.Location = New Point(540, 498)
        btnKosongkan.Margin = New Padding(2)
        btnKosongkan.Name = "btnKosongkan"
        btnKosongkan.Size = New Size(96, 27)
        btnKosongkan.TabIndex = 17
        btnKosongkan.Text = "Kosongkan"
        btnKosongkan.UseVisualStyleBackColor = False
        ' 
        ' btnHapus
        ' 
        btnHapus.BackColor = Color.LightGoldenrodYellow
        btnHapus.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnHapus.ForeColor = Color.DarkOliveGreen
        btnHapus.Location = New Point(436, 498)
        btnHapus.Margin = New Padding(2)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(90, 27)
        btnHapus.TabIndex = 16
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = False
        ' 
        ' btnUbah
        ' 
        btnUbah.BackColor = Color.LightGoldenrodYellow
        btnUbah.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnUbah.ForeColor = Color.DarkOliveGreen
        btnUbah.Location = New Point(331, 498)
        btnUbah.Margin = New Padding(2)
        btnUbah.Name = "btnUbah"
        btnUbah.Size = New Size(90, 27)
        btnUbah.TabIndex = 15
        btnUbah.Text = "Ubah"
        btnUbah.UseVisualStyleBackColor = False
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.LightGoldenrodYellow
        btnSimpan.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnSimpan.ForeColor = Color.DarkOliveGreen
        btnSimpan.Location = New Point(229, 498)
        btnSimpan.Margin = New Padding(2)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(90, 27)
        btnSimpan.TabIndex = 14
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' cmbTemuanParasit
        ' 
        cmbTemuanParasit.FormattingEnabled = True
        cmbTemuanParasit.Location = New Point(498, 354)
        cmbTemuanParasit.Margin = New Padding(2)
        cmbTemuanParasit.Name = "cmbTemuanParasit"
        cmbTemuanParasit.Size = New Size(239, 28)
        cmbTemuanParasit.TabIndex = 13
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.DarkOliveGreen
        Label7.Location = New Point(498, 330)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(125, 23)
        Label7.TabIndex = 12
        Label7.Text = "Temuan Parasit"
        ' 
        ' txtCatatanKesehatan
        ' 
        txtCatatanKesehatan.Location = New Point(498, 431)
        txtCatatanKesehatan.Margin = New Padding(2)
        txtCatatanKesehatan.Name = "txtCatatanKesehatan"
        txtCatatanKesehatan.Size = New Size(302, 27)
        txtCatatanKesehatan.TabIndex = 11
        ' 
        ' txtBeratBadan
        ' 
        txtBeratBadan.Location = New Point(498, 288)
        txtBeratBadan.Margin = New Padding(2)
        txtBeratBadan.Name = "txtBeratBadan"
        txtBeratBadan.Size = New Size(239, 27)
        txtBeratBadan.TabIndex = 10
        ' 
        ' dtpTanggalPemeriksaan
        ' 
        dtpTanggalPemeriksaan.Location = New Point(28, 355)
        dtpTanggalPemeriksaan.Margin = New Padding(2)
        dtpTanggalPemeriksaan.Name = "dtpTanggalPemeriksaan"
        dtpTanggalPemeriksaan.Size = New Size(239, 27)
        dtpTanggalPemeriksaan.TabIndex = 9
        ' 
        ' txtSuhuTubuh
        ' 
        txtSuhuTubuh.Location = New Point(28, 431)
        txtSuhuTubuh.Margin = New Padding(2)
        txtSuhuTubuh.Name = "txtSuhuTubuh"
        txtSuhuTubuh.Size = New Size(239, 27)
        txtSuhuTubuh.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.DarkOliveGreen
        Label6.Location = New Point(498, 406)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(154, 23)
        Label6.TabIndex = 5
        Label6.Text = "Catatan Kesehatan"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.DarkOliveGreen
        Label5.Location = New Point(498, 263)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(103, 23)
        Label5.TabIndex = 4
        Label5.Text = "Berat Badan"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.DarkOliveGreen
        Label4.Location = New Point(28, 406)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 23)
        Label4.TabIndex = 3
        Label4.Text = "Suhu Tubuh"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.DarkOliveGreen
        Label3.Location = New Point(28, 330)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(169, 23)
        Label3.TabIndex = 2
        Label3.Text = "Tanggal Pemeriksaan"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkOliveGreen
        Label2.Location = New Point(28, 263)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(56, 23)
        Label2.TabIndex = 1
        Label2.Text = "Nama"
        ' 
        ' dgvPemeriksaan
        ' 
        dgvPemeriksaan.BackgroundColor = Color.Thistle
        dgvPemeriksaan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPemeriksaan.Location = New Point(28, 65)
        dgvPemeriksaan.Margin = New Padding(2)
        dgvPemeriksaan.Name = "dgvPemeriksaan"
        dgvPemeriksaan.RowHeadersWidth = 62
        dgvPemeriksaan.Size = New Size(833, 175)
        dgvPemeriksaan.TabIndex = 0
        ' 
        ' FormMedisKucing
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1156, 658)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(TableLayoutPanel1)
        Margin = New Padding(2)
        Name = "FormMedisKucing"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormMedisKucing"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(dgvPemeriksaan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvPemeriksaan As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSuhuTubuh As TextBox
    Friend WithEvents txtBeratBadan As TextBox
    Friend WithEvents dtpTanggalPemeriksaan As DateTimePicker
    Friend WithEvents txtCatatanKesehatan As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbTemuanParasit As ComboBox
    Friend WithEvents btnKosongkan As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnUbah As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents txtCari As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbNamaKucing As ComboBox
End Class
