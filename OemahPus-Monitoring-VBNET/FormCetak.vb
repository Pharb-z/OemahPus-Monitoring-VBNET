Imports Microsoft.Reporting.WinForms
Imports System.Data
Imports System.IO

Public Class FormCetak

    ' Nama resource embedded = RootNamespace + "." + nama file (tanpa folder).
    Private Const RESOURCE_PREFIX As String = "OemahPus_Monitoring_VBNET."

    Private _dt As DataTable
    Private _jenis As String
    Private _info As ReportExporter.InfoLaporan
    Private _rendered As Boolean

    Private Sub FormCetak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Navigator.Register("cetak", Me)

        rvLaporan.ProcessingMode = ProcessingMode.Local
        rvLaporan.ShowToolBar = True
        rvLaporan.ZoomMode = ZoomMode.PageWidth

        ' Pastikan tombol export mengikuti ketersediaan data.
        SetTombolAktif(False)
    End Sub

    ''' <summary>Dipanggil FormReport sebelum form ditampilkan.</summary>
    Public Sub Siapkan(dt As DataTable, jenis As String, info As ReportExporter.InfoLaporan)
        _dt = dt
        _jenis = jenis
        _info = info
        _rendered = False
    End Sub

    Private Sub FormCetak_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Visible Then Return
        If _dt Is Nothing Then Return
        If _rendered Then Return
        RenderLaporan()
    End Sub

    Private Sub SetTombolAktif(aktif As Boolean)
        btnExportPdf.Enabled = aktif
        btnExportExcel.Enabled = aktif
    End Sub

    ' ============================================================
    ' RENDER RDLC
    ' ============================================================

    Private Sub RenderLaporan()
        Dim namaReport As String = NamaReportUntuk(_jenis)
        Dim namaResource As String = RESOURCE_PREFIX & namaReport

        If namaReport = "" Then
            MessageBox.Show("Jenis laporan tidak dikenali: " & _jenis,
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Cek resource lebih dulu: hint EmbeddedResource hanya relevan bila file
        ' memang tidak ikut ter-embed. Untuk kegagalan render, hint itu justru
        ' menyesatkan.
        If Not ResourceTersedia(namaResource) Then
            MessageBox.Show(
                "File laporan tidak ditemukan di dalam aplikasi: " & namaResource & vbCrLf & vbCrLf &
                "Pastikan file RDLC ada di folder Reports dan sudah ditandai " &
                "sebagai EmbeddedResource pada project.",
                "Error Laporan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim namaDataset As String = NamaDatasetUntuk(_jenis)

            rvLaporan.LocalReport.DataSources.Clear()
            rvLaporan.LocalReport.ReportPath = Nothing
            rvLaporan.LocalReport.ReportEmbeddedResource = Nothing

            ' ReportViewerCore tidak andal mencari resource lewat
            ' ReportEmbeddedResource, jadi definisi RDLC dibaca langsung dari
            ' manifest assembly lalu dimuat sebagai stream.
            Using stream As IO.Stream = BukaStreamReport(namaResource)
                If stream Is Nothing Then
                    MessageBox.Show(
                        "File laporan tidak dapat dibuka: " & namaResource,
                        "Error Laporan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                rvLaporan.LocalReport.LoadReportDefinition(stream)
            End Using

            ' DataTable perlu dibungkus BindingSource agar perubahan tipe kolom
            ' (mis. DBNull) tidak menggagalkan render.
            Dim source As New BindingSource()
            source.DataSource = _dt
            rvLaporan.LocalReport.DataSources.Add(New ReportDataSource(namaDataset, source))

            rvLaporan.LocalReport.SetParameters({
                New ReportParameter("ReportTitle", "Laporan " & _jenis),
                New ReportParameter("PrintDate", Date.Now.ToString("dd/MM/yyyy HH:mm")),
                New ReportParameter("Periode", If(_info?.PeriodeText, "")),
                New ReportParameter("DicetakOleh", If(_info?.DicetakOleh, ""))
            })

            rvLaporan.RefreshReport()

            _rendered = True
            SetTombolAktif(_dt IsNot Nothing AndAlso _dt.Rows.Count > 0)

        Catch ex As Exception
            ' Tampilkan pesan asli beserta rantai inner exception agar penyebab
            ' sebenarnya (mis. kesalahan definisi RDLC) langsung terlihat.
            MessageBox.Show(
                "Gagal memuat laporan " & namaReport & ":" & vbCrLf & vbCrLf &
                RantaiPesan(ex),
                "Error Laporan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>Membuka stream definisi RDLC dari resource embedded assembly.</summary>
    Private Function BukaStreamReport(namaResource As String) As IO.Stream
        Return GetType(FormCetak).Assembly.GetManifestResourceStream(namaResource)
    End Function

    ''' <summary>Memastikan resource RDLC benar-benar ter-embed di assembly.</summary>
    Private Function ResourceTersedia(namaResource As String) As Boolean
        Dim asm As Reflection.Assembly = GetType(FormCetak).Assembly
        Return Array.IndexOf(asm.GetManifestResourceNames(), namaResource) >= 0
    End Function

    ''' <summary>Menggabungkan pesan exception beserta seluruh inner exception.</summary>
    Private Function RantaiPesan(ex As Exception) As String
        Dim sb As New Text.StringBuilder()
        Dim current As Exception = ex
        Dim level As Integer = 0

        While current IsNot Nothing AndAlso level <= 5
            If level > 0 Then sb.AppendLine().Append("  -> ")
            sb.Append(current.Message)
            current = current.InnerException
            level += 1
        End While

        Return sb.ToString()
    End Function

    Private Function NamaReportUntuk(jenis As String) As String
        Select Case jenis
            Case "Reservasi" : Return "RptReservasi.rdlc"
            Case "Pendapatan" : Return "RptPendapatan.rdlc"
            Case "Pemeriksaan Kucing" : Return "RptPemeriksaan.rdlc"
            Case Else : Return ""
        End Select
    End Function

    Private Function NamaDatasetUntuk(jenis As String) As String
        Select Case jenis
            Case "Reservasi" : Return "ReservasiDataset"
            Case "Pendapatan" : Return "PendapatanDataset"
            Case "Pemeriksaan Kucing" : Return "PemeriksaanDataset"
            Case Else : Return "Dataset"
        End Select
    End Function

    ' ============================================================
    ' EXPORT DARI REPORTVIEWER (PDF / Excel)
    ' ============================================================

    Private Sub btnExportPdf_Click(sender As Object, e As EventArgs) Handles btnExportPdf.Click
        ExportMelaluiReportViewer("PDF", "pdf", "PDF Document (*.pdf)|*.pdf")
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        ExportMelaluiReportViewer("EXCELOPENXML", "xlsx", "Excel Workbook (*.xlsx)|*.xlsx")
    End Sub

    Private Sub ExportMelaluiReportViewer(formatRender As String, ekstensi As String, filter As String)
        If _dt Is Nothing OrElse _dt.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk diekspor.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Title = "Simpan Laporan " & _jenis & " (" & ekstensi.ToUpperInvariant() & ")"
            sfd.Filter = filter
            sfd.DefaultExt = ekstensi
            sfd.AddExtension = True
            sfd.FileName = "Laporan_" & _jenis.Replace(" ", "_") & "_" &
                           Date.Now.ToString("yyyyMMdd_HHmm") & "." & ekstensi

            If sfd.ShowDialog(Me) <> DialogResult.OK Then Return

            Try
                Dim warnings As Warning() = Nothing
                Dim streamids As String() = Nothing
                Dim mimeType As String = ""
                Dim encoding As String = ""
                Dim extension As String = ""
                Dim bytes As Byte() = rvLaporan.LocalReport.Render(
                    formatRender, Nothing, mimeType, encoding, extension, streamids, warnings)

                File.WriteAllBytes(sfd.FileName, bytes)

                MessageBox.Show("Laporan berhasil disimpan ke:" & vbCrLf & sfd.FileName,
                                "Export Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Gagal mengekspor laporan: " & ex.Message,
                                "Export Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' ============================================================
    ' CETAK LANGSUNG
    ' ============================================================

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            rvLaporan.PrintDialog()
        Catch ex As Exception
            MessageBox.Show("Gagal membuka dialog cetak: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Dim laporan As Form = Navigator.GetRegistered("laporan")
        If laporan IsNot Nothing Then
            laporan.Show()
            Me.Hide()
            Navigator.MarkNavigatedFrom("laporan")
        Else
            Navigator.Go(Me, "laporan", Function() New FormReport())
        End If
    End Sub

End Class
