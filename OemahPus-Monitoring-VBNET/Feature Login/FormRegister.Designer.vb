<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegister
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
        chkShowPassword = New CheckBox()
        btnRegister = New Button()
        txtPassword = New TextBox()
        txtUsername = New TextBox()
        lblPassword = New Label()
        lblUsername = New Label()
        lblOemahPus = New Label()
        lblOMI = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightGoldenrodYellow
        Panel1.Controls.Add(chkShowPassword)
        Panel1.Controls.Add(btnRegister)
        Panel1.Controls.Add(txtPassword)
        Panel1.Controls.Add(txtUsername)
        Panel1.Controls.Add(lblPassword)
        Panel1.Controls.Add(lblUsername)
        Panel1.Location = New Point(106, 165)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(953, 440)
        Panel1.TabIndex = 7
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkShowPassword.Location = New Point(308, 254)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(163, 24)
        chkShowPassword.TabIndex = 9
        chkShowPassword.Text = "Tampilkan Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' btnRegister
        ' 
        btnRegister.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRegister.Location = New Point(542, 294)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(120, 40)
        btnRegister.TabIndex = 7
        btnRegister.Text = "Register"
        btnRegister.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(306, 216)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(356, 32)
        txtPassword.TabIndex = 6
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(308, 136)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(356, 32)
        txtUsername.TabIndex = 5
        txtUsername.Tag = ""
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPassword.Location = New Point(306, 188)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(91, 25)
        lblPassword.TabIndex = 4
        lblPassword.Text = "Password"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUsername.Location = New Point(308, 108)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(97, 25)
        lblUsername.TabIndex = 3
        lblUsername.Text = "Username"
        ' 
        ' lblOemahPus
        ' 
        lblOemahPus.AutoSize = True
        lblOemahPus.Font = New Font("Segoe UI", 16.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblOemahPus.ForeColor = Color.DarkSlateBlue
        lblOemahPus.Location = New Point(359, 106)
        lblOemahPus.Name = "lblOemahPus"
        lblOemahPus.Size = New Size(431, 37)
        lblOemahPus.TabIndex = 9
        lblOemahPus.Text = "OemahPus Monitoring Information"
        ' 
        ' lblOMI
        ' 
        lblOMI.AutoSize = True
        lblOMI.Font = New Font("Broadway", 36.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblOMI.ForeColor = Color.DarkSlateBlue
        lblOMI.Location = New Point(484, 38)
        lblOMI.Name = "lblOMI"
        lblOMI.Size = New Size(156, 68)
        lblOMI.TabIndex = 10
        lblOMI.Text = "OMI"
        ' 
        ' FormRegister
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1156, 658)
        Controls.Add(lblOMI)
        Controls.Add(lblOemahPus)
        Controls.Add(Panel1)
        Name = "FormRegister"
        Text = "FormRegister"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblOemahPus As Label
    Friend WithEvents lblOMI As Label
End Class
