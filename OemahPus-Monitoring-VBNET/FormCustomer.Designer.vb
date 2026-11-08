<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomer
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
        btnMenuCustomer = New Button()
        btnMenuLayanan = New Button()
        Label9 = New Label()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel3 = New Panel()
        btnKosongkan = New Button()
        btnHapus = New Button()
        btnUbah = New Button()
        btnSimpan = New Button()
        dgvCustomer = New DataGridView()
        NoCustomer = New DataGridViewTextBoxColumn()
        NamaAkun = New DataGridViewTextBoxColumn()
        Email = New DataGridViewTextBoxColumn()
        Alamat = New DataGridViewTextBoxColumn()
        NamaLengkap = New DataGridViewTextBoxColumn()
        NoTelepon = New DataGridViewTextBoxColumn()
        Label8 = New Label()
        txtCari = New TextBox()
        txtAlamat = New TextBox()
        txtEmail = New TextBox()
        txtNamaAkun = New TextBox()
        txtNoTelepon = New TextBox()
        txtNamaLengkap = New TextBox()
        txtIdCustomer = New TextBox()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvCustomer, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.SeaShell
        Panel1.Controls.Add(btnMenuCustomer)
        Panel1.Controls.Add(btnMenuLayanan)
        Panel1.Controls.Add(Label9)
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(308, 798)
        Panel1.TabIndex = 0
        ' 
        ' btnMenuCustomer
        ' 
        btnMenuCustomer.BackColor = Color.Plum
        btnMenuCustomer.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuCustomer.ForeColor = Color.SeaShell
        btnMenuCustomer.Location = New Point(48, 278)
        btnMenuCustomer.Name = "btnMenuCustomer"
        btnMenuCustomer.Size = New Size(206, 46)
        btnMenuCustomer.TabIndex = 2
        btnMenuCustomer.Text = "Customer"
        btnMenuCustomer.UseVisualStyleBackColor = False
        ' 
        ' btnMenuLayanan
        ' 
        btnMenuLayanan.BackColor = Color.Plum
        btnMenuLayanan.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMenuLayanan.ForeColor = Color.SeaShell
        btnMenuLayanan.Location = New Point(48, 201)
        btnMenuLayanan.Name = "btnMenuLayanan"
        btnMenuLayanan.Size = New Size(206, 46)
        btnMenuLayanan.TabIndex = 1
        btnMenuLayanan.Text = "Paket Layanan"
        btnMenuLayanan.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Snap ITC", 36.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.Plum
        Label9.Location = New Point(36, 55)
        Label9.Name = "Label9"
        Label9.Size = New Size(218, 93)
        Label9.TabIndex = 0
        Label9.Text = "OMI"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightGoldenrodYellow
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(320, 12)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1113, 105)
        Panel2.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkOliveGreen
        Label1.Location = New Point(45, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(243, 45)
        Label1.TabIndex = 0
        Label1.Text = "Data Customer"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Thistle
        Panel3.Controls.Add(btnKosongkan)
        Panel3.Controls.Add(btnHapus)
        Panel3.Controls.Add(btnUbah)
        Panel3.Controls.Add(btnSimpan)
        Panel3.Controls.Add(dgvCustomer)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(txtCari)
        Panel3.Controls.Add(txtAlamat)
        Panel3.Controls.Add(txtEmail)
        Panel3.Controls.Add(txtNamaAkun)
        Panel3.Controls.Add(txtNoTelepon)
        Panel3.Controls.Add(txtNamaLengkap)
        Panel3.Controls.Add(txtIdCustomer)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(Label2)
        Panel3.Location = New Point(320, 117)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1113, 693)
        Panel3.TabIndex = 2
        ' 
        ' btnKosongkan
        ' 
        btnKosongkan.BackColor = Color.LightGoldenrodYellow
        btnKosongkan.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnKosongkan.ForeColor = Color.DarkOliveGreen
        btnKosongkan.Location = New Point(975, 239)
        btnKosongkan.Name = "btnKosongkan"
        btnKosongkan.Size = New Size(118, 34)
        btnKosongkan.TabIndex = 18
        btnKosongkan.Text = "Kosongkan"
        btnKosongkan.UseVisualStyleBackColor = False
        ' 
        ' btnHapus
        ' 
        btnHapus.BackColor = Color.LightGoldenrodYellow
        btnHapus.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnHapus.ForeColor = Color.DarkOliveGreen
        btnHapus.Location = New Point(845, 239)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(112, 34)
        btnHapus.TabIndex = 17
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = False
        ' 
        ' btnUbah
        ' 
        btnUbah.BackColor = Color.LightGoldenrodYellow
        btnUbah.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUbah.ForeColor = Color.DarkOliveGreen
        btnUbah.Location = New Point(717, 239)
        btnUbah.Name = "btnUbah"
        btnUbah.Size = New Size(112, 34)
        btnUbah.TabIndex = 16
        btnUbah.Text = "Ubah"
        btnUbah.UseVisualStyleBackColor = False
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.LightGoldenrodYellow
        btnSimpan.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSimpan.ForeColor = Color.DarkOliveGreen
        btnSimpan.Location = New Point(580, 239)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(112, 34)
        btnSimpan.TabIndex = 15
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' dgvCustomer
        ' 
        dgvCustomer.BackgroundColor = Color.Thistle
        dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCustomer.Columns.AddRange(New DataGridViewColumn() {NoCustomer, NamaAkun, Email, Alamat, NamaLengkap, NoTelepon})
        dgvCustomer.Location = New Point(30, 350)
        dgvCustomer.Name = "dgvCustomer"
        dgvCustomer.RowHeadersWidth = 62
        dgvCustomer.Size = New Size(1016, 311)
        dgvCustomer.TabIndex = 14
        ' 
        ' NoCustomer
        ' 
        NoCustomer.HeaderText = "NoCustomer"
        NoCustomer.MinimumWidth = 8
        NoCustomer.Name = "NoCustomer"
        NoCustomer.Width = 150
        ' 
        ' NamaAkun
        ' 
        NamaAkun.HeaderText = "Nama Akun"
        NamaAkun.MinimumWidth = 8
        NamaAkun.Name = "NamaAkun"
        NamaAkun.Width = 150
        ' 
        ' Email
        ' 
        Email.HeaderText = "Email"
        Email.MinimumWidth = 8
        Email.Name = "Email"
        Email.Width = 150
        ' 
        ' Alamat
        ' 
        Alamat.HeaderText = "Alamat"
        Alamat.MinimumWidth = 8
        Alamat.Name = "Alamat"
        Alamat.Width = 150
        ' 
        ' NamaLengkap
        ' 
        NamaLengkap.HeaderText = "Nama"
        NamaLengkap.MinimumWidth = 8
        NamaLengkap.Name = "NamaLengkap"
        NamaLengkap.Width = 150
        ' 
        ' NoTelepon
        ' 
        NoTelepon.HeaderText = "No Telepon"
        NoTelepon.MinimumWidth = 8
        NoTelepon.Name = "NoTelepon"
        NoTelepon.Width = 150
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.DarkOliveGreen
        Label8.Location = New Point(30, 271)
        Label8.Name = "Label8"
        Label8.Size = New Size(111, 32)
        Label8.TabIndex = 13
        Label8.Text = "Cari Data"
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(172, 274)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(275, 31)
        txtCari.TabIndex = 12
        ' 
        ' txtAlamat
        ' 
        txtAlamat.Location = New Point(780, 157)
        txtAlamat.Name = "txtAlamat"
        txtAlamat.Size = New Size(266, 31)
        txtAlamat.TabIndex = 11
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(780, 100)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(266, 31)
        txtEmail.TabIndex = 10
        ' 
        ' txtNamaAkun
        ' 
        txtNamaAkun.Location = New Point(780, 46)
        txtNamaAkun.Name = "txtNamaAkun"
        txtNamaAkun.Size = New Size(266, 31)
        txtNamaAkun.TabIndex = 9
        ' 
        ' txtNoTelepon
        ' 
        txtNoTelepon.Location = New Point(264, 157)
        txtNoTelepon.Name = "txtNoTelepon"
        txtNoTelepon.Size = New Size(275, 31)
        txtNoTelepon.TabIndex = 8
        ' 
        ' txtNamaLengkap
        ' 
        txtNamaLengkap.Location = New Point(264, 100)
        txtNamaLengkap.Name = "txtNamaLengkap"
        txtNamaLengkap.Size = New Size(275, 31)
        txtNamaLengkap.TabIndex = 7
        ' 
        ' txtIdCustomer
        ' 
        txtIdCustomer.Location = New Point(264, 46)
        txtIdCustomer.Name = "txtIdCustomer"
        txtIdCustomer.Size = New Size(275, 31)
        txtIdCustomer.TabIndex = 6
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12.0F)
        Label7.ForeColor = Color.DarkOliveGreen
        Label7.Location = New Point(604, 154)
        Label7.Name = "Label7"
        Label7.Size = New Size(88, 32)
        Label7.TabIndex = 5
        Label7.Text = "Alamat"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12.0F)
        Label6.ForeColor = Color.DarkOliveGreen
        Label6.Location = New Point(604, 43)
        Label6.Name = "Label6"
        Label6.Size = New Size(139, 32)
        Label6.TabIndex = 4
        Label6.Text = "Nama Akun"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12.0F)
        Label5.ForeColor = Color.DarkOliveGreen
        Label5.Location = New Point(604, 97)
        Label5.Name = "Label5"
        Label5.Size = New Size(71, 32)
        Label5.TabIndex = 3
        Label5.Text = "Email"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12.0F)
        Label4.ForeColor = Color.DarkOliveGreen
        Label4.Location = New Point(30, 154)
        Label4.Name = "Label4"
        Label4.Size = New Size(138, 32)
        Label4.TabIndex = 2
        Label4.Text = "No Telepon"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12.0F)
        Label3.ForeColor = Color.DarkOliveGreen
        Label3.Location = New Point(30, 97)
        Label3.Name = "Label3"
        Label3.Size = New Size(174, 32)
        Label3.TabIndex = 1
        Label3.Text = "Nama Lengkap"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12.0F)
        Label2.ForeColor = Color.DarkOliveGreen
        Label2.Location = New Point(30, 43)
        Label2.Name = "Label2"
        Label2.Size = New Size(156, 32)
        Label2.TabIndex = 0
        Label2.Text = "No Customer"
        ' 
        ' FormCustomer
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1445, 822)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "FormCustomer"
        Text = "FormCustomer"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(dgvCustomer, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtIdCustomer As TextBox
    Friend WithEvents txtNamaLengkap As TextBox
    Friend WithEvents txtNoTelepon As TextBox
    Friend WithEvents txtNamaAkun As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents txtCari As TextBox
    Friend WithEvents dgvCustomer As DataGridView
    Friend WithEvents Label8 As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnKosongkan As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnUbah As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents NoCustomer As DataGridViewTextBoxColumn
    Friend WithEvents NamaAkun As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Alamat As DataGridViewTextBoxColumn
    Friend WithEvents NamaLengkap As DataGridViewTextBoxColumn
    Friend WithEvents NoTelepon As DataGridViewTextBoxColumn
End Class
