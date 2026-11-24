Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Text

''' <summary>
''' Pembuat PDF sederhana tanpa library eksternal.
''' Setiap halaman dirender dengan GDI+ (System.Drawing) ke bitmap, lalu bitmap
''' disimpan sebagai JPEG dan ditempatkan di PDF sebagai Image XObject
''' (filter DCTDecode). Tidak memerlukan paket NuGet tambahan.
''' </summary>
Friend Class PdfDocumentBuilder
    Implements IDisposable

    ' Ukuran halaman A4 dalam point (1 point = 1/72 inci)
    Private Const PageWidthPt As Single = 595.0F
    Private Const PageHeightPt As Single = 842.0F
    Private Const MarginLeftPt As Single = 36.0F
    Private Const MarginRightPt As Single = 36.0F
    Private Const MarginTopPt As Single = 36.0F
    Private Const MarginBottomPt As Single = 46.0F
    Private Const RowHeightPt As Single = 15.0F
    Private Const HeaderHeightPt As Single = 18.0F

    ' Render pada 150 DPI agar teks tetap tajam saat dicetak.
    Private Const RenderDpi As Single = 150.0F

    Private ReadOnly _path As String
    Private ReadOnly _pages As New List(Of Byte())()
    Private ReadOnly _imageWidth As Integer
    Private ReadOnly _imageHeight As Integer
    Private _disposed As Boolean

    Public Sub New(path As String)
        _path = path
        _imageWidth = CInt(PageWidthPt * RenderDpi / 72.0F)
        _imageHeight = CInt(PageHeightPt * RenderDpi / 72.0F)
    End Sub

    ''' <summary>Membuat seluruh halaman laporan lalu menuliskannya ke file PDF.</summary>
    Public Sub WriteReport(headers As String(), weights As Single(),
                           alignRight As Boolean(), dt As DataTable,
                           info As ReportExporter.InfoLaporan)

        If headers Is Nothing OrElse headers.Length = 0 Then Return

        Dim laporan As ReportExporter.InfoLaporan = If(info, New ReportExporter.InfoLaporan())
        Dim usableWidth As Single = PageWidthPt - MarginLeftPt - MarginRightPt

        Dim totalWeight As Single = 0.0F
        For Each w As Single In weights
            totalWeight += w
        Next
        If totalWeight <= 0.0F Then totalWeight = 1.0F

        Dim colWidths(headers.Length - 1) As Single
        For i As Integer = 0 To headers.Length - 1
            colWidths(i) = usableWidth * (weights(i) / totalWeight)
        Next

        Dim startRow As Integer = 0
        Dim pageNumber As Integer = 1
        Dim safety As Integer = 0

        Do
            Dim rowsToDraw As Integer = RowsPerPage(startRow, dt, laporan)
            _pages.Add(RenderPage(dt, headers, colWidths, alignRight, laporan,
                                  startRow, rowsToDraw, pageNumber))

            startRow += rowsToDraw
            pageNumber += 1
            safety += 1
        Loop While startRow < dt.Rows.Count AndAlso safety < 5000

        WritePdfFile()
    End Sub

    ' ------------------------------------------------------------
    ' Tata letak
    ' ------------------------------------------------------------

    Private Function ContentTopPt(startRow As Integer, info As ReportExporter.InfoLaporan) As Single
        Dim top As Single = MarginTopPt
        top += 22.0F                                     ' judul
        If info IsNot Nothing AndAlso info.SubJudul <> "" Then top += 14.0F
        If info IsNot Nothing AndAlso info.PeriodeText <> "" Then top += 14.0F
        top += 10.0F                                     ' jarak
        top += HeaderHeightPt                            ' header kolom
        Return top
    End Function

    Private Function RowsPerPage(startRow As Integer, dt As DataTable,
                                 info As ReportExporter.InfoLaporan) As Integer
        Dim available As Single = PageHeightPt - MarginBottomPt - ContentTopPt(startRow, info)
        Dim count As Integer = CInt(Math.Floor(available / RowHeightPt))

        ' Halaman terakhir butuh baris tambahan untuk ringkasan total.
        Dim sisaBaris As Integer = dt.Rows.Count - startRow
        If sisaBaris <= count Then count = Math.Max(1, count - 1)

        Return Math.Max(1, count)
    End Function

    ' ------------------------------------------------------------
    ' Render halaman
    ' ------------------------------------------------------------

    Private Function RenderPage(dt As DataTable, headers As String(), colWidths As Single(),
                                alignRight As Boolean(), info As ReportExporter.InfoLaporan,
                                startRow As Integer, rowsToDraw As Integer,
                                pageNumber As Integer) As Byte()

        Dim scale As Single = RenderDpi / 72.0F

        Using bmp As New Bitmap(_imageWidth, _imageHeight)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                g.Clear(Color.White)
                g.ScaleTransform(scale, scale)

                Const FontFamilyName As String = "Segoe UI"

                ' --- Judul & metadata ---
                Dim y As Single = MarginTopPt

                Using fJudul As New Font(FontFamilyName, 15.0F, FontStyle.Bold)
                    DrawCentered(g, info.Judul, fJudul, Brushes.Black, y)
                End Using
                y += 22.0F

                Using fMeta As New Font(FontFamilyName, 8.0F, FontStyle.Regular)
                    If info.SubJudul <> "" Then
                        DrawCentered(g, info.SubJudul, fMeta, Brushes.DimGray, y)
                        y += 14.0F
                    End If
                    If info.PeriodeText <> "" Then
                        DrawCentered(g, info.PeriodeText, fMeta, Brushes.DimGray, y)
                        y += 14.0F
                    End If
                End Using

                y += 10.0F

                ' --- Header tabel ---
                Using bgHeader As New SolidBrush(Color.FromArgb(221, 160, 221))
                    g.FillRectangle(bgHeader, MarginLeftPt, y,
                                    PageWidthPt - MarginLeftPt - MarginRightPt, HeaderHeightPt)
                End Using

                Using fHeader As New Font(FontFamilyName, 8.0F, FontStyle.Bold)
                    Dim x As Single = MarginLeftPt
                    For i As Integer = 0 To headers.Length - 1
                        Dim rect As New RectangleF(x + 3.0F, y + 2.0F, colWidths(i) - 6.0F, HeaderHeightPt - 4.0F)
                        Using sf As New StringFormat()
                            sf.Trimming = StringTrimming.EllipsisCharacter
                            sf.FormatFlags = StringFormatFlags.NoWrap
                            If alignRight(i) Then sf.Alignment = StringAlignment.Far
                            g.DrawString(headers(i), fHeader, Brushes.White, rect, sf)
                        End Using
                        x += colWidths(i)
                    Next
                End Using

                y += HeaderHeightPt

                ' --- Baris data ---
                Using fCell As New Font(FontFamilyName, 7.5F, FontStyle.Regular)
                    Using linePen As New Pen(Color.FromArgb(230, 230, 250), 0.5F)
                        For rowNo As Integer = 0 To rowsToDraw - 1
                            Dim index As Integer = startRow + rowNo
                            If index >= dt.Rows.Count Then Exit For

                            If rowNo Mod 2 = 1 Then
                                Using bgZebra As New SolidBrush(Color.FromArgb(255, 250, 240))
                                    g.FillRectangle(bgZebra, MarginLeftPt, y,
                                                    PageWidthPt - MarginLeftPt - MarginRightPt, RowHeightPt)
                                End Using
                            End If

                            Dim row As DataRow = dt.Rows(index)
                            Dim x As Single = MarginLeftPt

                            For i As Integer = 0 To dt.Columns.Count - 1
                                Dim rect As New RectangleF(x + 3.0F, y + 1.5F, colWidths(i) - 6.0F, RowHeightPt - 3.0F)
                                Using sf As New StringFormat()
                                    sf.Trimming = StringTrimming.EllipsisCharacter
                                    sf.FormatFlags = StringFormatFlags.NoWrap
                                    If alignRight(i) Then sf.Alignment = StringAlignment.Far
                                    g.DrawString(ReportExporter.FormatCell(row(i)), fCell, Brushes.Black, rect, sf)
                                End Using
                                x += colWidths(i)
                            Next

                            g.DrawLine(linePen, MarginLeftPt, y + RowHeightPt,
                                       PageWidthPt - MarginRightPt, y + RowHeightPt)
                            y += RowHeightPt
                        Next
                    End Using
                End Using

                ' --- Ringkasan pada halaman terakhir ---
                Dim lastPage As Boolean = (startRow + rowsToDraw) >= dt.Rows.Count
                If lastPage AndAlso info.TotalLabel <> "" Then
                    y += 8.0F
                    Using fTotal As New Font(FontFamilyName, 9.0F, FontStyle.Bold)
                        Dim rect As New RectangleF(MarginLeftPt, y,
                                                   PageWidthPt - MarginLeftPt - MarginRightPt, 16.0F)
                        Using sf As New StringFormat()
                            sf.Alignment = StringAlignment.Far
                            g.DrawString(info.TotalLabel & ": Rp " &
                                         info.TotalNilai.ToString("N0", CultureInfo.GetCultureInfo("id-ID")),
                                         fTotal, Brushes.DarkOliveGreen, rect, sf)
                        End Using
                    End Using
                End If

                ' --- Footer ---
                Using fFooter As New Font(FontFamilyName, 7.5F, FontStyle.Regular)
                    Dim footer As String = ""
                    If info.DicetakOleh <> "" Then footer = "Dicetak oleh: " & info.DicetakOleh & "  |  "
                    footer &= "Halaman " & pageNumber.ToString(CultureInfo.InvariantCulture)
                    g.DrawString(footer, fFooter, Brushes.Gray,
                                 MarginLeftPt, PageHeightPt - MarginBottomPt + 10.0F)
                End Using
            End Using

            Return EncodeJpeg(bmp)
        End Using
    End Function

    Private Sub DrawCentered(g As Graphics, text As String, font As Font, brush As Brush, y As Single)
        Dim rect As New RectangleF(MarginLeftPt, y, PageWidthPt - MarginLeftPt - MarginRightPt, font.Height + 4.0F)
        Using sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.Trimming = StringTrimming.EllipsisCharacter
            g.DrawString(text, font, brush, rect, sf)
        End Using
    End Sub

    Private Function EncodeJpeg(bmp As Bitmap) As Byte()
        Using ms As New MemoryStream()
            Dim codec As ImageCodecInfo = Nothing
            For Each candidate As ImageCodecInfo In ImageCodecInfo.GetImageEncoders()
                If candidate.FormatID = ImageFormat.Jpeg.Guid Then
                    codec = candidate
                    Exit For
                End If
            Next

            If codec IsNot Nothing Then
                Using parameters As New EncoderParameters(1)
                    parameters.Param(0) = New EncoderParameter(Imaging.Encoder.Quality, 85L)
                    bmp.Save(ms, codec, parameters)
                End Using
            Else
                bmp.Save(ms, ImageFormat.Jpeg)
            End If

            Return ms.ToArray()
        End Using
    End Function

    ' ------------------------------------------------------------
    ' Penulisan struktur file PDF
    ' ------------------------------------------------------------

    Private Sub WritePdfFile()
        Dim pageCount As Integer = _pages.Count
        If pageCount = 0 Then Return

        ' Objek: 1 = Catalog, 2 = Pages, lalu tiap halaman memakai 3 objek
        ' (Page, Contents, Image).
        Dim objectCount As Integer = 2 + pageCount * 3
        Dim offsets(objectCount + 1) As Long

        Using fs As New FileStream(_path, FileMode.Create, FileAccess.Write)
            WriteAscii(fs, "%PDF-1.4" & vbLf)
            fs.Write({37, 226, 227, 207, 211}, 0, 5)   ' komentar biner penanda
            WriteAscii(fs, vbLf)

            ' --- 1: Catalog ---
            WriteObject(fs, offsets, 1, Ascii("<</Type /Catalog /Pages 2 0 R>>"))

            ' --- 2: Pages ---
            Dim kids As New StringBuilder()
            For p As Integer = 0 To pageCount - 1
                If p > 0 Then kids.Append(" ")
                kids.Append((3 + p * 3).ToString(CultureInfo.InvariantCulture)).Append(" 0 R")
            Next

            WriteObject(fs, offsets, 2, Ascii("<</Type /Pages /Kids [" & kids.ToString() & "] /Count " &
                                              pageCount.ToString(CultureInfo.InvariantCulture) & ">>"))

            ' --- Halaman ---
            For p As Integer = 0 To pageCount - 1
                Dim pageObj As Integer = 3 + p * 3
                Dim contentObj As Integer = pageObj + 1
                Dim imageObj As Integer = pageObj + 2

                Dim pageDict As String =
                    "<</Type /Page /Parent 2 0 R /MediaBox [0 0 " &
                    PageWidthPt.ToString("0.##", CultureInfo.InvariantCulture) & " " &
                    PageHeightPt.ToString("0.##", CultureInfo.InvariantCulture) & "] " &
                    "/Resources <</XObject <</Im0 " & imageObj.ToString(CultureInfo.InvariantCulture) &
                    " 0 R>> /ProcSet [/PDF /ImageC]>> " &
                    "/Contents " & contentObj.ToString(CultureInfo.InvariantCulture) & " 0 R>>"
                WriteObject(fs, offsets, pageObj, Ascii(pageDict))

                ' Content stream: gambar memenuhi seluruh halaman.
                Dim content As String =
                    "q" & vbLf &
                    PageWidthPt.ToString("0.##", CultureInfo.InvariantCulture) & " 0 0 " &
                    PageHeightPt.ToString("0.##", CultureInfo.InvariantCulture) & " 0 0 cm" & vbLf &
                    "/Im0 Do" & vbLf & "Q" & vbLf
                WriteObject(fs, offsets, contentObj, StreamPayload(Ascii(content), Nothing))

                ' Image XObject (JPEG dari GDI+, jadi filter DCTDecode).
                Dim imageDict As String =
                    "<</Type /XObject /Subtype /Image /Width " &
                    _imageWidth.ToString(CultureInfo.InvariantCulture) &
                    " /Height " & _imageHeight.ToString(CultureInfo.InvariantCulture) &
                    " /ColorSpace /DeviceRGB /BitsPerComponent 8 /Filter /DCTDecode>>"
                WriteObject(fs, offsets, imageObj, StreamPayload(Ascii(imageDict), _pages(p)))
            Next

            ' --- xref table ---
            Dim xrefPos As Long = fs.Position
            Dim totalObjects As Integer = objectCount + 1

            WriteAscii(fs, "xref" & vbLf & "0 " & totalObjects.ToString(CultureInfo.InvariantCulture) & vbLf)
            WriteAscii(fs, "0000000000 65535 f " & vbLf)
            For i As Integer = 1 To objectCount
                WriteAscii(fs, offsets(i).ToString("0000000000", CultureInfo.InvariantCulture) & " 00000 n " & vbLf)
            Next

            WriteAscii(fs, "trailer" & vbLf & "<</Size " & totalObjects.ToString(CultureInfo.InvariantCulture) &
                       " /Root 1 0 R>>" & vbLf & "startxref" & vbLf &
                       xrefPos.ToString(CultureInfo.InvariantCulture) & vbLf & "%%EOF")
        End Using
    End Sub

    ''' <summary>Menyusun payload objek berupa stream (dictionary + data).</summary>
    Private Function StreamPayload(dict As Byte(), data As Byte()) As Byte()
        Dim length As Integer = If(data Is Nothing, 0, data.Length)
        Dim withLength As Byte() = Ascii(Encoding.ASCII.GetString(dict).TrimEnd(">"c) &
                                        " /Length " & length.ToString(CultureInfo.InvariantCulture) & ">>" &
                                        vbCrLf & "stream" & vbLf)

        Using ms As New MemoryStream()
            ms.Write(withLength, 0, withLength.Length)
            If length > 0 Then ms.Write(data, 0, length)
            Dim tail As Byte() = Ascii(vbLf & "endstream")
            ms.Write(tail, 0, tail.Length)
            Return ms.ToArray()
        End Using
    End Function

    Private Sub WriteObject(fs As Stream, offsets As Long(), id As Integer, payload As Byte())
        offsets(id) = fs.Position
        WriteAscii(fs, id.ToString(CultureInfo.InvariantCulture) & " 0 obj" & vbLf)
        fs.Write(payload, 0, payload.Length)
        WriteAscii(fs, vbLf & "endobj" & vbLf)
    End Sub

    Private Function Ascii(text As String) As Byte()
        Return Encoding.ASCII.GetBytes(text)
    End Function

    Private Sub WriteAscii(fs As Stream, text As String)
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(text)
        fs.Write(bytes, 0, bytes.Length)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _disposed Then Return
        _disposed = True
        _pages.Clear()
    End Sub
End Class
