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
        Panel2 = New Panel()
        Panel3 = New Panel()
        Label1 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Label2 = New Label()
        ComboBox1 = New ComboBox()
        DataGridView1 = New DataGridView()
        TextBox1 = New TextBox()
        Button5 = New Button()
        Button6 = New Button()
        IDReservasi = New DataGridViewTextBoxColumn()
        NamaCustomer = New DataGridViewTextBoxColumn()
        TanggalReservasi = New DataGridViewTextBoxColumn()
        TotalTagihan = New DataGridViewTextBoxColumn()
        StatusPembayaran = New DataGridViewTextBoxColumn()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.SeaShell
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(308, 798)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightGoldenrodYellow
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(320, 12)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1112, 105)
        Panel2.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Thistle
        Panel3.Controls.Add(Button6)
        Panel3.Controls.Add(Button5)
        Panel3.Controls.Add(TextBox1)
        Panel3.Controls.Add(DataGridView1)
        Panel3.Controls.Add(ComboBox1)
        Panel3.Location = New Point(320, 118)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1112, 692)
        Panel3.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Snap ITC", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Plum
        Label1.Location = New Point(36, 62)
        Label1.Name = "Label1"
        Label1.Size = New Size(221, 93)
        Label1.TabIndex = 0
        Label1.Text = "OMI"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Plum
        Button1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(48, 200)
        Button1.Name = "Button1"
        Button1.Size = New Size(206, 46)
        Button1.TabIndex = 1
        Button1.Text = "Paket Layanan"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Plum
        Button2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(48, 275)
        Button2.Name = "Button2"
        Button2.Size = New Size(206, 46)
        Button2.TabIndex = 2
        Button2.Text = "Customer"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.Plum
        Button3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(48, 350)
        Button3.Name = "Button3"
        Button3.Size = New Size(206, 46)
        Button3.TabIndex = 3
        Button3.Text = "Pemeriksaan Kucing"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.Plum
        Button4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(48, 427)
        Button4.Name = "Button4"
        Button4.Size = New Size(206, 46)
        Button4.TabIndex = 4
        Button4.Text = "Laporan"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkOliveGreen
        Label2.Location = New Point(35, 36)
        Label2.Name = "Label2"
        Label2.Size = New Size(151, 45)
        Label2.TabIndex = 0
        Label2.Text = "Laporan "
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(31, 54)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(290, 33)
        ComboBox1.TabIndex = 0
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {IDReservasi, NamaCustomer, TanggalReservasi, TotalTagihan, StatusPembayaran})
        DataGridView1.Location = New Point(31, 218)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1049, 446)
        DataGridView1.TabIndex = 1
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(338, 56)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(233, 31)
        TextBox1.TabIndex = 2
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.LightGoldenrodYellow
        Button5.Location = New Point(925, 155)
        Button5.Name = "Button5"
        Button5.Size = New Size(139, 34)
        Button5.TabIndex = 3
        Button5.Text = "Export CSV"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.LightGoldenrodYellow
        Button6.Location = New Point(781, 155)
        Button6.Name = "Button6"
        Button6.Size = New Size(127, 34)
        Button6.TabIndex = 4
        Button6.Text = "Cetak"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' IDReservasi
        ' 
        IDReservasi.HeaderText = "ID"
        IDReservasi.MinimumWidth = 8
        IDReservasi.Name = "IDReservasi"
        IDReservasi.Width = 150
        ' 
        ' NamaCustomer
        ' 
        NamaCustomer.HeaderText = "Nama"
        NamaCustomer.MinimumWidth = 8
        NamaCustomer.Name = "NamaCustomer"
        NamaCustomer.Width = 150
        ' 
        ' TanggalReservasi
        ' 
        TanggalReservasi.HeaderText = "Tanggal"
        TanggalReservasi.MinimumWidth = 8
        TanggalReservasi.Name = "TanggalReservasi"
        TanggalReservasi.Width = 150
        ' 
        ' TotalTagihan
        ' 
        TotalTagihan.HeaderText = "Total Tagihan"
        TotalTagihan.MinimumWidth = 8
        TotalTagihan.Name = "TotalTagihan"
        TotalTagihan.Width = 150
        ' 
        ' StatusPembayaran
        ' 
        StatusPembayaran.HeaderText = "Status"
        StatusPembayaran.MinimumWidth = 8
        StatusPembayaran.Name = "StatusPembayaran"
        StatusPembayaran.Width = 150
        ' 
        ' FormReport
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1445, 822)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "FormReport"
        Text = "FormReport"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents IDReservasi As DataGridViewTextBoxColumn
    Friend WithEvents NamaCustomer As DataGridViewTextBoxColumn
    Friend WithEvents TanggalReservasi As DataGridViewTextBoxColumn
    Friend WithEvents TotalTagihan As DataGridViewTextBoxColumn
    Friend WithEvents StatusPembayaran As DataGridViewTextBoxColumn
End Class
