<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCheckInOut
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
        Me.btnMenuLayanan = New Button()
        Me.btnMenuCustomer = New Button()
        Me.btnMenuPemeriksaanKucing = New Button()
        Me.btnMenuReservasi = New Button()
        Me.btnMenuLaporan = New Button()
        Me.btnLogout = New Button()
        Me.Panel2 = New Panel()
        Me.Label2 = New Label()
        Me.Panel3 = New Panel()
        Me.Label3 = New Label()
        Me.cmbMode = New ComboBox()
        Me.Label4 = New Label()
        Me.cmbReservasi = New ComboBox()
        Me.Label5 = New Label()
        Me.txtBerat = New TextBox()
        Me.Label6 = New Label()
        Me.txtSuhu = New TextBox()
        Me.chkParasit = New CheckBox()
        Me.Label7 = New Label()
        Me.txtCatatan = New TextBox()
        Me.lblInfo = New Label()
        Me.btnProses = New Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Label1.TabIndex = 0
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
        Me.btnMenuDashboard.TabIndex = 1
        Me.btnMenuDashboard.Text = "Dashboard"
        Me.btnMenuDashboard.UseVisualStyleBackColor = False
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
        Me.btnMenuLayanan.TabIndex = 2
        Me.btnMenuLayanan.Text = "Riwayat Layanan"
        Me.btnMenuLayanan.UseVisualStyleBackColor = False
        '
        ' btnMenuCustomer
        '
        Me.btnMenuCustomer.BackColor = Color.Plum
        Me.btnMenuCustomer.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnMenuCustomer.ForeColor = Color.DarkOliveGreen
        Me.btnMenuCustomer.Location = New Point(38, 280)
        Me.btnMenuCustomer.Margin = New Padding(2)
        Me.btnMenuCustomer.Name = "btnMenuCustomer"
        Me.btnMenuCustomer.Size = New Size(165, 37)
        Me.btnMenuCustomer.TabIndex = 3
        Me.btnMenuCustomer.Text = "Customer"
        Me.btnMenuCustomer.UseVisualStyleBackColor = False
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
        Me.btnMenuPemeriksaanKucing.TabIndex = 4
        Me.btnMenuPemeriksaanKucing.Text = "Pemeriksaan Kucing"
        Me.btnMenuPemeriksaanKucing.UseVisualStyleBackColor = False
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
        Me.btnMenuReservasi.TabIndex = 5
        Me.btnMenuReservasi.Text = "Reservasi"
        Me.btnMenuReservasi.UseVisualStyleBackColor = False
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
        Me.btnMenuLaporan.TabIndex = 6
        Me.btnMenuLaporan.Text = "Laporan Harian"
        Me.btnMenuLaporan.UseVisualStyleBackColor = False
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
        Me.btnLogout.TabIndex = 7
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
        Me.Panel2.TabIndex = 1
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
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Check In / Check Out"
        '
        ' Panel3
        '
        Me.Panel3.BackColor = Color.Thistle
        Me.Panel3.Controls.Add(Me.btnProses)
        Me.Panel3.Controls.Add(Me.lblInfo)
        Me.Panel3.Controls.Add(Me.txtCatatan)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.chkParasit)
        Me.Panel3.Controls.Add(Me.txtSuhu)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtBerat)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.cmbReservasi)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.cmbMode)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New Point(256, 94)
        Me.Panel3.Margin = New Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Size(890, 554)
        Me.Panel3.TabIndex = 2
        '
        ' Label3
        '
        Me.Label3.AutoSize = False
        Me.Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label3.ForeColor = Color.DarkOliveGreen
        Me.Label3.Location = New Point(24, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(200, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Mode"
        '
        ' cmbMode
        '
        Me.cmbMode.BackColor = Color.White
        Me.cmbMode.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.cmbMode.ForeColor = Color.DarkOliveGreen
        Me.cmbMode.Location = New Point(24, 48)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New Size(240, 30)
        Me.cmbMode.TabIndex = 0
        '
        ' Label4
        '
        Me.Label4.AutoSize = False
        Me.Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label4.ForeColor = Color.DarkOliveGreen
        Me.Label4.Location = New Point(24, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(240, 23)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Reservasi"
        '
        ' cmbReservasi
        '
        Me.cmbReservasi.BackColor = Color.White
        Me.cmbReservasi.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.cmbReservasi.ForeColor = Color.DarkOliveGreen
        Me.cmbReservasi.Location = New Point(24, 128)
        Me.cmbReservasi.Name = "cmbReservasi"
        Me.cmbReservasi.Size = New Size(540, 30)
        Me.cmbReservasi.TabIndex = 0
        '
        ' Label5
        '
        Me.Label5.AutoSize = False
        Me.Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label5.ForeColor = Color.DarkOliveGreen
        Me.Label5.Location = New Point(24, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(200, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Berat (kg)"
        '
        ' txtBerat
        '
        Me.txtBerat.BackColor = Color.White
        Me.txtBerat.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtBerat.ForeColor = Color.DarkOliveGreen
        Me.txtBerat.Location = New Point(24, 208)
        Me.txtBerat.Name = "txtBerat"
        Me.txtBerat.Size = New Size(180, 30)
        Me.txtBerat.TabIndex = 0
        Me.txtBerat.Text = ""
        '
        ' Label6
        '
        Me.Label6.AutoSize = False
        Me.Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label6.ForeColor = Color.DarkOliveGreen
        Me.Label6.Location = New Point(230, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(200, 23)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Suhu (Â°C)"
        '
        ' txtSuhu
        '
        Me.txtSuhu.BackColor = Color.White
        Me.txtSuhu.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtSuhu.ForeColor = Color.DarkOliveGreen
        Me.txtSuhu.Location = New Point(230, 208)
        Me.txtSuhu.Name = "txtSuhu"
        Me.txtSuhu.Size = New Size(180, 30)
        Me.txtSuhu.TabIndex = 0
        Me.txtSuhu.Text = ""
        '
        ' chkParasit
        '
        Me.chkParasit.AutoSize = True
        Me.chkParasit.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.chkParasit.ForeColor = Color.DarkOliveGreen
        Me.chkParasit.Location = New Point(440, 208)
        Me.chkParasit.Name = "chkParasit"
        Me.chkParasit.Size = New Size(200, 24)
        Me.chkParasit.TabIndex = 0
        Me.chkParasit.Text = "Ada parasit"
        Me.chkParasit.UseVisualStyleBackColor = True
        '
        ' Label7
        '
        Me.Label7.AutoSize = False
        Me.Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.Label7.ForeColor = Color.DarkOliveGreen
        Me.Label7.Location = New Point(24, 260)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(280, 23)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Catatan Kesehatan"
        '
        ' txtCatatan
        '
        Me.txtCatatan.BackColor = Color.White
        Me.txtCatatan.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Me.txtCatatan.ForeColor = Color.DarkOliveGreen
        Me.txtCatatan.Location = New Point(24, 288)
        Me.txtCatatan.Name = "txtCatatan"
        Me.txtCatatan.Size = New Size(620, 90)
        Me.txtCatatan.TabIndex = 0
        Me.txtCatatan.Text = ""
        '
        ' lblInfo
        '
        Me.lblInfo.AutoSize = False
        Me.lblInfo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.lblInfo.ForeColor = Color.DarkOliveGreen
        Me.lblInfo.Location = New Point(24, 392)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New Size(620, 30)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = ""
        '
        ' btnProses
        '
        Me.btnProses.BackColor = Color.LightGoldenrodYellow
        Me.btnProses.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Me.btnProses.ForeColor = Color.DarkOliveGreen
        Me.btnProses.Location = New Point(24, 448)
        Me.btnProses.Margin = New Padding(2)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New Size(220, 37)
        Me.btnProses.TabIndex = 0
        Me.btnProses.Text = "Proses Check In"
        Me.btnProses.UseVisualStyleBackColor = False
        '
        ' FormCheckInOut
        '
        Me.AutoScaleDimensions = New SizeF(8F, 20F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1156, 658)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New Padding(2)
        Me.Name = "FormCheckInOut"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Check In / Check Out"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMenuDashboard As Button
    Friend WithEvents btnMenuLayanan As Button
    Friend WithEvents btnMenuCustomer As Button
    Friend WithEvents btnMenuPemeriksaanKucing As Button
    Friend WithEvents btnMenuReservasi As Button
    Friend WithEvents btnMenuLaporan As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMode As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbReservasi As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBerat As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSuhu As TextBox
    Friend WithEvents chkParasit As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCatatan As TextBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents btnProses As Button
End Class
