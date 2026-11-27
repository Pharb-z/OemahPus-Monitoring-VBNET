<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegister
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        lblInfo = New Label()
        btnBack = New Button()
        btnRegister = New Button()
        txtConfirm = New TextBox()
        lblConfirm = New Label()
        chkShowPassword = New CheckBox()
        txtPassword = New TextBox()
        txtUsername = New TextBox()
        txtPhone = New TextBox()
        txtEmail = New TextBox()
        lblPassword = New Label()
        lblUsername = New Label()
        lblPhone = New Label()
        lblEmail = New Label()
        lblOemahPus = New Label()
        lblOMI = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        '
        ' Panel1
        '
        Panel1.BackColor = Color.LightGoldenrodYellow
        Panel1.Controls.Add(lblInfo)
        Panel1.Controls.Add(btnBack)
        Panel1.Controls.Add(btnRegister)
        Panel1.Controls.Add(txtConfirm)
        Panel1.Controls.Add(lblConfirm)
        Panel1.Controls.Add(chkShowPassword)
        Panel1.Controls.Add(txtPassword)
        Panel1.Controls.Add(txtUsername)
        Panel1.Controls.Add(txtPhone)
        Panel1.Controls.Add(txtEmail)
        Panel1.Controls.Add(lblPassword)
        Panel1.Controls.Add(lblUsername)
        Panel1.Controls.Add(lblPhone)
        Panel1.Controls.Add(lblEmail)
        Panel1.Location = New Point(106, 120)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(953, 510)
        Panel1.TabIndex = 0
        '
        ' lblInfo
        '
        lblInfo.AutoSize = True
        lblInfo.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblInfo.ForeColor = Color.DarkOliveGreen
        lblInfo.Location = New Point(308, 362)
        lblInfo.Name = "lblInfo"
        lblInfo.Size = New Size(360, 25)
        lblInfo.TabIndex = 1
        lblInfo.Text = "Akun baru berperan sebagai Pelanggan."
        '
        ' btnBack
        '
        btnBack.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnBack.Location = New Point(492, 398)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(170, 40)
        btnBack.TabIndex = 2
        btnBack.Text = "Kembali ke Login"
        btnBack.UseVisualStyleBackColor = True
        '
        ' btnRegister
        '
        btnRegister.BackColor = Color.LightGoldenrodYellow
        btnRegister.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegister.ForeColor = Color.DarkOliveGreen
        btnRegister.Location = New Point(308, 398)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(170, 40)
        btnRegister.TabIndex = 3
        btnRegister.Text = "Register"
        btnRegister.UseVisualStyleBackColor = False
        '
        ' txtConfirm
        '
        txtConfirm.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtConfirm.Location = New Point(306, 302)
        txtConfirm.Name = "txtConfirm"
        txtConfirm.Size = New Size(356, 32)
        txtConfirm.TabIndex = 4
        txtConfirm.UseSystemPasswordChar = True
        '
        ' lblConfirm
        '
        lblConfirm.AutoSize = True
        lblConfirm.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblConfirm.Location = New Point(306, 274)
        lblConfirm.Name = "lblConfirm"
        lblConfirm.Size = New Size(150, 25)
        lblConfirm.TabIndex = 5
        lblConfirm.Text = "Konfirmasi Password"
        '
        ' chkShowPassword
        '
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkShowPassword.Location = New Point(308, 338)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(163, 24)
        chkShowPassword.TabIndex = 6
        chkShowPassword.Text = "Tampilkan Password"
        chkShowPassword.UseVisualStyleBackColor = True
        '
        ' txtPassword
        '
        txtPassword.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(306, 238)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(356, 32)
        txtPassword.TabIndex = 7
        txtPassword.UseSystemPasswordChar = True
        '
        ' txtUsername
        '
        txtUsername.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(308, 174)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(356, 32)
        txtUsername.TabIndex = 8
        txtUsername.Tag = ""
        '
        ' txtPhone
        '
        txtPhone.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPhone.Location = New Point(308, 112)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(356, 32)
        txtPhone.TabIndex = 9
        '
        ' txtEmail
        '
        txtEmail.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(308, 50)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(356, 32)
        txtEmail.TabIndex = 10
        '
        ' lblPassword
        '
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPassword.Location = New Point(306, 210)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(91, 25)
        lblPassword.TabIndex = 11
        lblPassword.Text = "Password"
        '
        ' lblUsername
        '
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUsername.Location = New Point(308, 146)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(97, 25)
        lblUsername.TabIndex = 12
        lblUsername.Text = "Username"
        '
        ' lblPhone
        '
        lblPhone.AutoSize = True
        lblPhone.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPhone.Location = New Point(308, 84)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(165, 25)
        lblPhone.TabIndex = 13
        lblPhone.Text = "Phone Number"
        '
        ' lblEmail
        '
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmail.Location = New Point(308, 22)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(62, 25)
        lblEmail.TabIndex = 14
        lblEmail.Text = "Email"
        '
        ' lblOemahPus
        '
        lblOemahPus.AutoSize = True
        lblOemahPus.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblOemahPus.ForeColor = Color.DarkSlateBlue
        lblOemahPus.Location = New Point(359, 66)
        lblOemahPus.Name = "lblOemahPus"
        lblOemahPus.Size = New Size(431, 37)
        lblOemahPus.TabIndex = 15
        lblOemahPus.Text = "OemahPus Monitoring Information"
        '
        ' lblOMI
        '
        lblOMI.AutoSize = True
        lblOMI.Font = New Font("Broadway", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblOMI.ForeColor = Color.DarkSlateBlue
        lblOMI.Location = New Point(484, 0)
        lblOMI.Name = "lblOMI"
        lblOMI.Size = New Size(156, 68)
        lblOMI.TabIndex = 16
        lblOMI.Text = "OMI"
        '
        ' FormRegister
        '
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1156, 658)
        Controls.Add(lblOMI)
        Controls.Add(lblOemahPus)
        Controls.Add(Panel1)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Name = "FormRegister"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Register — OMI"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblInfo As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnRegister As Button
    Friend WithEvents txtConfirm As TextBox
    Friend WithEvents lblConfirm As Label
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblOemahPus As Label
    Friend WithEvents lblOMI As Label
End Class
