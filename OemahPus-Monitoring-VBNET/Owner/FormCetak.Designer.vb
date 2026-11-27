<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCetak
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
        btnKembali = New Button()
        btnPrint = New Button()
        btnExportExcel = New Button()
        btnExportPdf = New Button()
        Label1 = New Label()
        rvLaporan = New Microsoft.Reporting.WinForms.ReportViewer()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightGoldenrodYellow
        Panel1.Controls.Add(btnKembali)
        Panel1.Controls.Add(btnPrint)
        Panel1.Controls.Add(btnExportExcel)
        Panel1.Controls.Add(btnExportPdf)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(10, 10)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1136, 84)
        Panel1.TabIndex = 0
        ' 
        ' btnExportPdf
        ' 
        btnExportPdf.BackColor = Color.Thistle
        btnExportPdf.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnExportPdf.ForeColor = Color.DarkOliveGreen
        btnExportPdf.Location = New Point(590, 26)
        btnExportPdf.Margin = New Padding(2)
        btnExportPdf.Name = "btnExportPdf"
        btnExportPdf.Size = New Size(110, 30)
        btnExportPdf.TabIndex = 1
        btnExportPdf.Text = "Export PDF"
        btnExportPdf.UseVisualStyleBackColor = False
        ' 
        ' btnExportExcel
        ' 
        btnExportExcel.BackColor = Color.Thistle
        btnExportExcel.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnExportExcel.ForeColor = Color.DarkOliveGreen
        btnExportExcel.Location = New Point(708, 26)
        btnExportExcel.Margin = New Padding(2)
        btnExportExcel.Name = "btnExportExcel"
        btnExportExcel.Size = New Size(120, 30)
        btnExportExcel.TabIndex = 2
        btnExportExcel.Text = "Export Excel"
        btnExportExcel.UseVisualStyleBackColor = False
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.Thistle
        btnPrint.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnPrint.ForeColor = Color.DarkOliveGreen
        btnPrint.Location = New Point(836, 26)
        btnPrint.Margin = New Padding(2)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(80, 30)
        btnPrint.TabIndex = 3
        btnPrint.Text = "Print"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' btnKembali
        ' 
        btnKembali.BackColor = Color.LightGoldenrodYellow
        btnKembali.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnKembali.ForeColor = Color.DarkOliveGreen
        btnKembali.Location = New Point(1006, 26)
        btnKembali.Margin = New Padding(2)
        btnKembali.Name = "btnKembali"
        btnKembali.Size = New Size(110, 30)
        btnKembali.TabIndex = 4
        btnKembali.Text = "Kembali"
        btnKembali.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DarkOliveGreen
        Label1.Location = New Point(16, 16)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(151, 46)
        Label1.TabIndex = 5
        Label1.Text = "Cetak Laporan"
        ' 
        ' rvLaporan
        ' 
        rvLaporan.Location = New Point(10, 104)
        rvLaporan.Name = "rvLaporan"
        rvLaporan.Size = New Size(1136, 544)
        rvLaporan.TabIndex = 6
        ' 
        ' FormCetak
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1156, 658)
        Controls.Add(rvLaporan)
        Controls.Add(Panel1)
        Margin = New Padding(2)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Name = "FormCetak"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Cetak Laporan"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnKembali As Button
    Friend WithEvents btnExportPdf As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents rvLaporan As Microsoft.Reporting.WinForms.ReportViewer

End Class
