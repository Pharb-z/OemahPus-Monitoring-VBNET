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
        Panel4 = New Panel()
        DataGridView1 = New DataGridView()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        TextBox1 = New TextBox()
        TextBox3 = New TextBox()
        DateTimePicker1 = New DateTimePicker()
        TextBox2 = New TextBox()
        TextBox4 = New TextBox()
        Label7 = New Label()
        ComboBox1 = New ComboBox()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Label8 = New Label()
        TextBox5 = New TextBox()
        Label9 = New Label()
        NamaKucing = New DataGridViewTextBoxColumn()
        BeratBadan = New DataGridViewTextBoxColumn()
        TemuanParasit = New DataGridViewTextBoxColumn()
        CatatanKesehatan = New DataGridViewTextBoxColumn()
        SuhuTubuh = New DataGridViewTextBoxColumn()
        TanggalPemeriksaan = New DataGridViewTextBoxColumn()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Location = New Point(52, 25)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(0, 0)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(373, 294)
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
        Panel2.Location = New Point(12, 12)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(308, 798)
        Panel2.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Snap ITC", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Plum
        Label1.Location = New Point(36, 55)
        Label1.Name = "Label1"
        Label1.Size = New Size(221, 93)
        Label1.TabIndex = 3
        Label1.Text = "OMI"
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Plum
        Button3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.DarkOliveGreen
        Button3.Location = New Point(51, 360)
        Button3.Name = "Button3"
        Button3.Size = New Size(206, 46)
        Button3.TabIndex = 2
        Button3.Text = "Pemeriksaan Kucing"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Plum
        Button2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.SeaShell
        Button2.Location = New Point(48, 278)
        Button2.Name = "Button2"
        Button2.Size = New Size(206, 46)
        Button2.TabIndex = 1
        Button2.Text = "Customer"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Plum
        Button1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.SeaShell
        Button1.Location = New Point(48, 201)
        Button1.Name = "Button1"
        Button1.Size = New Size(206, 46)
        Button1.TabIndex = 0
        Button1.Text = "Paket Layanan"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightGoldenrodYellow
        Panel3.Controls.Add(Label9)
        Panel3.Location = New Point(320, 12)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1112, 105)
        Panel3.TabIndex = 4
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Thistle
        Panel4.Controls.Add(TextBox5)
        Panel4.Controls.Add(Label8)
        Panel4.Controls.Add(Button7)
        Panel4.Controls.Add(Button6)
        Panel4.Controls.Add(Button5)
        Panel4.Controls.Add(Button4)
        Panel4.Controls.Add(ComboBox1)
        Panel4.Controls.Add(Label7)
        Panel4.Controls.Add(TextBox4)
        Panel4.Controls.Add(TextBox2)
        Panel4.Controls.Add(DateTimePicker1)
        Panel4.Controls.Add(TextBox3)
        Panel4.Controls.Add(TextBox1)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(Label5)
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(Label3)
        Panel4.Controls.Add(Label2)
        Panel4.Controls.Add(DataGridView1)
        Panel4.Location = New Point(320, 118)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1112, 692)
        Panel4.TabIndex = 5
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.Thistle
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {NamaKucing, BeratBadan, TemuanParasit, CatatanKesehatan, SuhuTubuh, TanggalPemeriksaan})
        DataGridView1.Location = New Point(35, 81)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1041, 219)
        DataGridView1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkOliveGreen
        Label2.Location = New Point(35, 329)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 28)
        Label2.TabIndex = 1
        Label2.Text = "Nama"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.DarkOliveGreen
        Label3.Location = New Point(35, 413)
        Label3.Name = "Label3"
        Label3.Size = New Size(193, 28)
        Label3.TabIndex = 2
        Label3.Text = "Tanggal Pemeriksaan"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.DarkOliveGreen
        Label4.Location = New Point(35, 508)
        Label4.Name = "Label4"
        Label4.Size = New Size(116, 28)
        Label4.TabIndex = 3
        Label4.Text = "Suhu Tubuh"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.DarkOliveGreen
        Label5.Location = New Point(622, 329)
        Label5.Name = "Label5"
        Label5.Size = New Size(116, 28)
        Label5.TabIndex = 4
        Label5.Text = "Berat Badan"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.DarkOliveGreen
        Label6.Location = New Point(622, 508)
        Label6.Name = "Label6"
        Label6.Size = New Size(173, 28)
        Label6.TabIndex = 5
        Label6.Text = "Catatan Kesehatan"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(35, 360)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(298, 31)
        TextBox1.TabIndex = 6
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(35, 539)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(298, 31)
        TextBox3.TabIndex = 8
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(35, 444)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(298, 31)
        DateTimePicker1.TabIndex = 9
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(622, 360)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(298, 31)
        TextBox2.TabIndex = 10
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(622, 539)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(377, 31)
        TextBox4.TabIndex = 11
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.DarkOliveGreen
        Label7.Location = New Point(622, 413)
        Label7.Name = "Label7"
        Label7.Size = New Size(141, 28)
        Label7.TabIndex = 12
        Label7.Text = "Temuan Parasit"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(622, 442)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(298, 33)
        ComboBox1.TabIndex = 13
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.LightGoldenrodYellow
        Button4.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Button4.ForeColor = Color.DarkOliveGreen
        Button4.Location = New Point(286, 623)
        Button4.Name = "Button4"
        Button4.Size = New Size(112, 34)
        Button4.TabIndex = 14
        Button4.Text = "Simpan"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.LightGoldenrodYellow
        Button5.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Button5.ForeColor = Color.DarkOliveGreen
        Button5.Location = New Point(414, 623)
        Button5.Name = "Button5"
        Button5.Size = New Size(112, 34)
        Button5.TabIndex = 15
        Button5.Text = "Ubah"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.LightGoldenrodYellow
        Button6.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Button6.ForeColor = Color.DarkOliveGreen
        Button6.Location = New Point(545, 623)
        Button6.Name = "Button6"
        Button6.Size = New Size(112, 34)
        Button6.TabIndex = 16
        Button6.Text = "Hapus"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button7
        ' 
        Button7.BackColor = Color.LightGoldenrodYellow
        Button7.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Button7.ForeColor = Color.DarkOliveGreen
        Button7.Location = New Point(675, 623)
        Button7.Name = "Button7"
        Button7.Size = New Size(120, 34)
        Button7.TabIndex = 17
        Button7.Text = "Kosongkan"
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.DarkOliveGreen
        Label8.Location = New Point(35, 30)
        Label8.Name = "Label8"
        Label8.Size = New Size(46, 28)
        Label8.TabIndex = 18
        Label8.Text = "Cari"
        ' 
        ' TextBox5
        ' 
        TextBox5.Location = New Point(95, 30)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(238, 31)
        TextBox5.TabIndex = 19
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.DarkOliveGreen
        Label9.Location = New Point(35, 36)
        Label9.Name = "Label9"
        Label9.Size = New Size(321, 45)
        Label9.TabIndex = 0
        Label9.Text = "Pemeriksaan Kucing"
        ' 
        ' NamaKucing
        ' 
        NamaKucing.HeaderText = "Nama"
        NamaKucing.MinimumWidth = 8
        NamaKucing.Name = "NamaKucing"
        NamaKucing.Width = 150
        ' 
        ' BeratBadan
        ' 
        BeratBadan.HeaderText = "Berat Badan"
        BeratBadan.MinimumWidth = 8
        BeratBadan.Name = "BeratBadan"
        BeratBadan.Width = 150
        ' 
        ' TemuanParasit
        ' 
        TemuanParasit.HeaderText = "Temuan Parasit"
        TemuanParasit.MinimumWidth = 8
        TemuanParasit.Name = "TemuanParasit"
        TemuanParasit.Width = 150
        ' 
        ' CatatanKesehatan
        ' 
        CatatanKesehatan.HeaderText = "Catatan"
        CatatanKesehatan.MinimumWidth = 8
        CatatanKesehatan.Name = "CatatanKesehatan"
        CatatanKesehatan.Width = 150
        ' 
        ' SuhuTubuh
        ' 
        SuhuTubuh.HeaderText = "Suhu Tubuh"
        SuhuTubuh.MinimumWidth = 8
        SuhuTubuh.Name = "SuhuTubuh"
        SuhuTubuh.Width = 150
        ' 
        ' TanggalPemeriksaan
        ' 
        TanggalPemeriksaan.HeaderText = "Tanggal"
        TanggalPemeriksaan.MinimumWidth = 8
        TanggalPemeriksaan.Name = "TanggalPemeriksaan"
        TanggalPemeriksaan.Width = 150
        ' 
        ' FormMedisKucing
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1445, 822)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(TableLayoutPanel1)
        Name = "FormMedisKucing"
        Text = "FormMedisKucing"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents NamaKucing As DataGridViewTextBoxColumn
    Friend WithEvents BeratBadan As DataGridViewTextBoxColumn
    Friend WithEvents TemuanParasit As DataGridViewTextBoxColumn
    Friend WithEvents CatatanKesehatan As DataGridViewTextBoxColumn
    Friend WithEvents SuhuTubuh As DataGridViewTextBoxColumn
    Friend WithEvents TanggalPemeriksaan As DataGridViewTextBoxColumn
End Class
