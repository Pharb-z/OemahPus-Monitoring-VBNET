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
        TextBox1 = New TextBox()
        Panel1 = New Panel()
        TextBox2 = New TextBox()
        Button1 = New Button()
        btnRegister = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3015, 469)
        Label1.Margin = New Padding(15, 0, 15, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(676, 82)
        Label1.TabIndex = 0
        Label1.Text = "Selamat Datang"
        ' 
        ' lblSelamatDatang
        ' 
        lblSelamatDatang.AutoSize = True
        lblSelamatDatang.ForeColor = Color.DarkSlateBlue
        lblSelamatDatang.Location = New Point(620, 69)
        lblSelamatDatang.Name = "lblSelamatDatang"
        lblSelamatDatang.Size = New Size(191, 82)
        lblSelamatDatang.TabIndex = 1
        lblSelamatDatang.Text = "OMI"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DarkSlateBlue
        Label2.Location = New Point(471, 142)
        Label2.Name = "Label2"
        Label2.Size = New Size(518, 45)
        Label2.TabIndex = 2
        Label2.Text = "OemahPus Monitoring Information"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(398, 172)
        Label3.Name = "Label3"
        Label3.Size = New Size(111, 30)
        Label3.TabIndex = 3
        Label3.Text = "Username"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(398, 259)
        Label4.Name = "Label4"
        Label4.Size = New Size(103, 30)
        Label4.TabIndex = 4
        Label4.Text = "Password"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(547, 169)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(303, 37)
        TextBox1.TabIndex = 5
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightGoldenrodYellow
        Panel1.Controls.Add(btnRegister)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(73, 211)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1294, 555)
        Panel1.TabIndex = 6
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.Location = New Point(547, 259)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(303, 37)
        TextBox2.TabIndex = 6
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(633, 340)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 40)
        Button1.TabIndex = 7
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = True
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
        ' FormLogin
        ' 
        AutoScaleDimensions = New SizeF(50F, 82F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Lavender
        ClientSize = New Size(1445, 822)
        Controls.Add(Panel1)
        Controls.Add(Label2)
        Controls.Add(lblSelamatDatang)
        Controls.Add(Label1)
        Font = New Font("Broadway", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(15, 10, 15, 10)
        Name = "FormLogin"
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
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnRegister As Button
End Class
