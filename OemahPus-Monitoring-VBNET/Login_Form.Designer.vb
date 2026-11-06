<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login_Form
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
        Panel2 = New Panel()
        Label1 = New Label()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(132, 126)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(900, 432)
        Panel2.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(393, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(82, 20)
        Label1.TabIndex = 0
        Label1.Text = "Login Page"
        ' 
        ' Login_Form
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1167, 714)
        Controls.Add(Panel2)
        Name = "Login_Form"
        Text = "Form1"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label

End Class
