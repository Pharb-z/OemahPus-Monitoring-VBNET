<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Kerangka
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
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel4 = New Panel()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Label1 = New Label()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(250, 704)
        Panel1.TabIndex = 3
        ' 
        ' Panel2
        ' 
        Panel2.Location = New Point(262, 12)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(900, 148)
        Panel2.TabIndex = 4
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(FlowLayoutPanel1)
        Panel3.Location = New Point(262, 160)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(430, 556)
        Panel3.TabIndex = 4
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(698, 160)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(464, 556)
        Panel4.TabIndex = 0
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Location = New Point(17, 175)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(401, 225)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(135, 20)
        Label1.TabIndex = 1
        Label1.Text = "Daftar Kucing Saya"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1167, 714)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "Form1"
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel

End Class
