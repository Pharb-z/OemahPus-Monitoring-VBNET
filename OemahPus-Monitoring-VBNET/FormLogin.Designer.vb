<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Label1 = New Label()
        lblSelamatDatang = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        btnLogin = New Button()
        btnRegister = New Button()
        Panel1 = New Panel()
        chkShowPassword = New CheckBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3015, 469)
        Label1.Margin = New Padding(15, 0, 15, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(565, 68)
        Label1.TabIndex = 0
        Label1.Text = "Selamat Datang"
        ' 
        ' lblSelamatDatang
        ' 
        lblSelamatDatang.AutoSize = True
        lblSelamatDatang.ForeColor = Color.DarkSlateBlue
        lblSelamatDatang.Location = New Point(477, 30)
        lblSelamatDatang.Name = "lblSelamatDatang"
        lblSelamatDatang.Size = New Size(159, 68)
        lblSelamatDatang.TabIndex = 1
        lblSelamatDatang.Text = "OMI"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkSlateBlue
        Label2.Location = New Point(347, 98)
        Label2.Name = "Label2"
        Label2.Size = New Size(431, 37)
        Label2.TabIndex = 2
        Label2.Text = "OemahPus Monitoring Information"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(308, 108)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 25)
        Label3.TabIndex = 3
        Label3.Text = "Username"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(306, 188)
        Label4.Name = "Label4"
        Label4.Size = New Size(91, 25)
        Label4.TabIndex = 4
        Label4.Text = "Password"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(308, 136)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(356, 32)
        txtUsername.TabIndex = 5
        txtUsername.Tag = ""
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(306, 216)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(356, 32)
        txtPassword.TabIndex = 6
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' btnLogin
        ' 
        btnLogin.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogin.Location = New Point(542, 294)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(120, 40)
        btnLogin.TabIndex = 7
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' btnRegister
        ' 
        btnRegister.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRegister.Location = New Point(1134, 489)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(120, 40)
        btnRegister.TabIndex = 8
        btnRegister.Text = "Register"
        btnRegister.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightGoldenrodYellow
        Panel1.Controls.Add(chkShowPassword)
        Panel1.Controls.Add(btnRegister)
        Panel1.Controls.Add(btnLogin)
        Panel1.Controls.Add(txtPassword)
        Panel1.Controls.Add(txtUsername)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(100, 161)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(953, 440)
        Panel1.TabIndex = 6
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkShowPassword.Location = New Point(308, 254)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(163, 24)
        chkShowPassword.TabIndex = 9
        chkShowPassword.Text = "Tampilkan Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' FormLogin
        ' 
        AutoScaleDimensions = New SizeF(42F, 68F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Lavender
        ClientSize = New Size(1156, 658)
        Controls.Add(Panel1)
        Controls.Add(Label2)
        Controls.Add(lblSelamatDatang)
        Controls.Add(Label1)
        Font = New Font("Broadway", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(15, 10, 15, 10)
        Name = "FormLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormLogin"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblSelamatDatang As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnRegister As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkShowPassword As CheckBox
End Class
