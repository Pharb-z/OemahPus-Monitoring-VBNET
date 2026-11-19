<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCetask
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
        PrintPreviewControl1 = New PrintPreviewControl()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(344, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(229, 70)
        Label1.TabIndex = 0
        Label1.Text = "Laporan"
        ' 
        ' PrintPreviewControl1
        ' 
        PrintPreviewControl1.BackColor = SystemColors.Control
        PrintPreviewControl1.Location = New Point(38, 218)
        PrintPreviewControl1.Name = "PrintPreviewControl1"
        PrintPreviewControl1.Size = New Size(894, 498)
        PrintPreviewControl1.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(557, 157)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 2
        Button1.Text = "Print"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(675, 157)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 34)
        Button2.TabIndex = 3
        Button2.Text = "Zoom In"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(793, 157)
        Button3.Name = "Button3"
        Button3.Size = New Size(112, 34)
        Button3.TabIndex = 4
        Button3.Text = "Zoom Out"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' FormCetask
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(965, 743)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(PrintPreviewControl1)
        Controls.Add(Label1)
        Name = "FormCetask"
        Text = "FormCetask"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PrintPreviewControl1 As PrintPreviewControl
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
