Imports System.Data
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' Kumpulan fungsi untuk mengekspor DataTable laporan ke berbagai format file
''' tanpa memerlukan paket NuGet tambahan.
''' Format yang didukung: CSV, Excel (SpreadsheetML .xls), XML, dan PDF.
''' PDF dibuat lewat RDLC/ReportViewer bila form cetak tersedia; jika tidak,
''' dipakai jalur gambar halaman (GDI+) sehingga tetap tidak butuh dependency baru.
''' </summary>
Public Module ReportExporter

    ''' <summary>Metadata laporan yang dipakai sebagai judul/keterangan di file hasil export.</summary>
    Public Class InfoLaporan
        Public Property Judul As String = "Laporan"
        Public Property SubJudul As String = ""
        Public Property PeriodeText As String = ""
        Public Property DicetakOleh As String = ""
        Public Property DicetakPada As Date = Date.Now
        Public Property TotalLabel As String = ""
        Public Property TotalNilai As Decimal = 0D
    End Class

    Private ReadOnly CultureAngka As CultureInfo = CultureInfo.GetCultureInfo("id-ID")

    ' ============================================================
    ' CSV
    ' ============================================================

    Public Function ExportCsv(dt As DataTable, path As String, info As InfoLaporan) As Boolean
        If dt Is Nothing OrElse path = "" Then Return False

        ' UTF-8 dengan BOM agar Excel membaca karakter non-ASCII dengan benar.
        Using writer As New StreamWriter(path, False, New UTF8Encoding(True))
            WriteCsvRow(writer, ColumnHeaders(dt))

            For Each row As DataRow In dt.Rows
                Dim values(dt.Columns.Count - 1) As String
                For i As Integer = 0 To dt.Columns.Count - 1
                    values(i) = FormatCell(row(i))
                Next
                WriteCsvRow(writer, values)
            Next

            writer.WriteLine()
            If info IsNot Nothing AndAlso info.TotalLabel <> "" Then
                writer.WriteLine(EscapeCsv(info.TotalLabel) & ";" & EscapeCsv(info.TotalNilai.ToString("N0", CultureAngka)))
            End If
        End Using

        Return True
    End Function

    Private Sub WriteCsvRow(writer As TextWriter, values As String())
        For i As Integer = 0 To values.Length - 1
            If i > 0 Then writer.Write(";"c)
            writer.Write(EscapeCsv(values(i)))
        Next
        writer.WriteLine()
    End Sub

    Private Function EscapeCsv(value As String) As String
        Dim text As String = If(value, "")
        text = text.Replace("""", """""")
        Return """" & text & """"
    End Function

    ' ============================================================
    ' EXCEL (SpreadsheetML 2003, ekstensi .xls)
    ' ============================================================

    Public Function ExportExcel(dt As DataTable, path As String, info As InfoLaporan) As Boolean
        If dt Is Nothing OrElse path = "" Then Return False

        Using writer As New StreamWriter(path, False, New UTF8Encoding(True))
            writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            writer.WriteLine("<?mso-application progid=""Excel.Sheet""?>")
            writer.WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""")
            writer.WriteLine("  xmlns:o=""urn:schemas-microsoft-com:office:office""")
            writer.WriteLine("  xmlns:x=""urn:schemas-microsoft-com:office:excel""")
            writer.WriteLine("  xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"">")

            ' Gaya yang dipakai di sheet
            writer.WriteLine("  <Styles>")
            writer.WriteLine("    <Style ss:ID=""judul""><Font ss:Bold=""1"" ss:Size=""14""/><Alignment ss:Horizontal=""Center""/></Style>")
            writer.WriteLine("    <Style ss:ID=""subjudul""><Font ss:Italic=""1"" ss:Size=""10""/><Alignment ss:Horizontal=""Center""/></Style>")
            writer.WriteLine("    <Style ss:ID=""header""><Font ss:Bold=""1"" ss:Color=""#FFFFFF""/><Interior ss:Color=""#DDA0DD"" ss:Pattern=""Solid""/><Alignment ss:Horizontal=""Center""/><Borders><Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/></Borders></Style>")
            writer.WriteLine("    <Style ss:ID=""teks""><Borders><Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E6E6FA""/></Borders></Style>")
            writer.WriteLine("    <Style ss:ID=""angka""><NumberFormat ss:Format=""#,##0""/><Alignment ss:Horizontal=""Right""/><Borders><Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E6E6FA""/></Borders></Style>")
            writer.WriteLine("    <Style ss:ID=""total""><Font ss:Bold=""1""/><NumberFormat ss:Format=""#,##0""/><Alignment ss:Horizontal=""Right""/></Style>")
            writer.WriteLine("  </Styles>")

            writer.WriteLine("  <Worksheet ss:Name=""Laporan"">")
            writer.WriteLine("    <Table>")

            ' Baris judul
            WriteMergedCell(writer, "judul", If(info?.Judul, "Laporan"), dt.Columns.Count)
            If info IsNot Nothing AndAlso info.SubJudul <> "" Then
                WriteMergedCell(writer, "subjudul", info.SubJudul, dt.Columns.Count)
            End If
            If info IsNot Nothing AndAlso info.PeriodeText <> "" Then
                WriteMergedCell(writer, "subjudul", info.PeriodeText, dt.Columns.Count)
            End If

            ' Header kolom
            writer.WriteLine("      <Row>")
            For Each header As String In ColumnHeaders(dt)
                writer.WriteLine("        <Cell ss:StyleID=""header""><Data ss:Type=""String"">" & XmlEscape(header) & "</Data></Cell>")
            Next
            writer.WriteLine("      </Row>")

            ' Isi
            For Each row As DataRow In dt.Rows
                writer.WriteLine("      <Row>")
                For i As Integer = 0 To dt.Columns.Count - 1
                    Dim value As Object = row(i)
                    If value Is Nothing OrElse value Is DBNull.Value Then
                        writer.WriteLine("        <Cell ss:StyleID=""teks""/>")
                    ElseIf IsNumericValue(value) Then
                        writer.WriteLine("        <Cell ss:StyleID=""angka""><Data ss:Type=""Number"">" &
                                         Convert.ToDecimal(value, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture) &
                                         "</Data></Cell>")
                    Else
                        writer.WriteLine("        <Cell ss:StyleID=""teks""><Data ss:Type=""String"">" &
                                         XmlEscape(FormatCell(value)) & "</Data></Cell>")
                    End If
                Next
                writer.WriteLine("      </Row>")
            Next

            ' Baris total
            If info IsNot Nothing AndAlso info.TotalLabel <> "" Then
                writer.WriteLine("      <Row>")
                writer.WriteLine("        <Cell ss:StyleID=""total""><Data ss:Type=""String"">" & XmlEscape(info.TotalLabel) & "</Data></Cell>")
                For i As Integer = 1 To dt.Columns.Count - 1
                    writer.WriteLine("        <Cell/>")
                Next
                writer.WriteLine("      </Row>")
            End If

            writer.WriteLine("    </Table>")
            writer.WriteLine("  </Worksheet>")
            writer.WriteLine("</Workbook>")
        End Using

        Return True
    End Function

    Private Sub WriteMergedCell(writer As TextWriter, styleId As String, text As String, columnCount As Integer)
        writer.WriteLine("      <Row>")
        writer.WriteLine("        <Cell ss:StyleID=""" & styleId & """ ss:MergeAcross=""" &
                         Math.Max(0, columnCount - 1).ToString() & """>")
        writer.WriteLine("          <Data ss:Type=""String"">" & XmlEscape(text) & "</Data>")
        writer.WriteLine("        </Cell>")
        writer.WriteLine("      </Row>")
    End Sub

    ' ============================================================
    ' XML
    ' ============================================================

    Public Function ExportXml(dt As DataTable, path As String, info As InfoLaporan) As Boolean
        If dt Is Nothing OrElse path = "" Then Return False

        Dim settings As New Xml.XmlWriterSettings With {
            .Indent = True,
            .Encoding = New UTF8Encoding(True)
        }

        Using writer As Xml.XmlWriter = Xml.XmlWriter.Create(path, settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("laporan")

            ' Metadata
            writer.WriteStartElement("metadata")
            writer.WriteElementString("judul", If(info?.Judul, "Laporan"))
            If info IsNot Nothing Then
                writer.WriteElementString("subjudul", info.SubJudul)
                writer.WriteElementString("periode", info.PeriodeText)
                writer.WriteElementString("dicetakOleh", info.DicetakOleh)
                writer.WriteElementString("dicetakPada", info.DicetakPada.ToString("yyyy-MM-dd HH:mm:ss"))
            End If
            writer.WriteElementString("jumlahBaris", dt.Rows.Count.ToString(CultureInfo.InvariantCulture))
            writer.WriteEndElement()

            ' Definisi kolom
            writer.WriteStartElement("kolom")
            For Each header As String In ColumnHeaders(dt)
                writer.WriteElementString("nama", header)
            Next
            writer.WriteEndElement()

            ' Baris data
            writer.WriteStartElement("baris")
            For Each row As DataRow In dt.Rows
                writer.WriteStartElement("data")
                For i As Integer = 0 To dt.Columns.Count - 1
                    writer.WriteStartElement("field")
                    writer.WriteAttributeString("kolom", dt.Columns(i).ColumnName)
                    writer.WriteString(FormatCell(row(i)))
                    writer.WriteEndElement()
                Next
                writer.WriteEndElement()
            Next
            writer.WriteEndElement()

            ' Total
            If info IsNot Nothing AndAlso info.TotalLabel <> "" Then
                writer.WriteStartElement("ringkasan")
                writer.WriteElementString("label", info.TotalLabel)
                writer.WriteElementString("nilai", info.TotalNilai.ToString(CultureInfo.InvariantCulture))
                writer.WriteEndElement()
            End If

            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using

        Return True
    End Function

    ' ============================================================
    ' PDF
    ' ============================================================

    ''' <summary>
    ''' Membuat PDF dari DataTable memakai GDI+ (System.Drawing) dan kompresi
    ''' Flate bawaan .NET, sehingga tidak memerlukan paket NuGet tambahan.
    ''' Mendukung banyak halaman otomatis bila baris melebihi tinggi kertas.
    ''' </summary>
    Public Function ExportPdf(dt As DataTable, path As String, info As InfoLaporan) As Boolean
        If dt Is Nothing OrElse path = "" Then Return False
        If dt.Columns.Count = 0 Then Return False

        Dim headers As String() = ColumnHeaders(dt)
        Dim weights As Single() = ColumnWeights(dt, headers)
        Dim alignRight As Boolean() = ColumnRightAlign(dt)

        Using pdf As New PdfDocumentBuilder(path)
            pdf.WriteReport(headers, weights, alignRight, dt, If(info, New InfoLaporan()))
        End Using

        Return True
    End Function

    Private Function ColumnWeights(dt As DataTable, headers As String()) As Single()
        Dim weights(dt.Columns.Count - 1) As Single
        For i As Integer = 0 To dt.Columns.Count - 1
            ' Lebar awal mengikuti panjang header & tipe data.
            Dim w As Single = Math.Max(4.0F, Math.Min(22.0F, headers(i).Length * 0.95F))
            If IsNumericValue(DefaultValueFor(dt.Columns(i).DataType)) Then w = Math.Max(w, 8.0F)
            weights(i) = w
        Next

        ' Sesuaikan dengan isi (dibatasi 40 baris pertama agar cepat).
        Dim limit As Integer = Math.Min(dt.Rows.Count, 40)
        For r As Integer = 0 To limit - 1
            For c As Integer = 0 To dt.Columns.Count - 1
                Dim text As String = FormatCell(dt.Rows(r)(c))
                If text.Length > weights(c) Then weights(c) = Math.Min(30.0F, text.Length * 0.95F)
            Next
        Next

        Return weights
    End Function

    Private Function ColumnRightAlign(dt As DataTable) As Boolean()
        Dim result(dt.Columns.Count - 1) As Boolean
        For i As Integer = 0 To dt.Columns.Count - 1
            result(i) = IsNumericValue(DefaultValueFor(dt.Columns(i).DataType))
        Next
        Return result
    End Function

    Private Function DefaultValueFor(t As Type) As Object
        If t Is Nothing Then Return ""
        If t Is GetType(Decimal) Then Return 0D
        If t Is GetType(Double) Then Return 0.0R
        If t Is GetType(Single) Then Return 0.0F
        If t Is GetType(Integer) Then Return 0
        If t Is GetType(Long) Then Return 0L
        Return ""
    End Function

    ' ============================================================
    ' HELPER UMUM
    ' ============================================================

    Public Function ColumnHeaders(dt As DataTable) As String()
        Dim headers(dt.Columns.Count - 1) As String
        For i As Integer = 0 To dt.Columns.Count - 1
            headers(i) = If(dt.Columns(i).Caption = dt.Columns(i).ColumnName,
                            dt.Columns(i).ColumnName,
                            dt.Columns(i).Caption)
        Next
        Return headers
    End Function

    Private Function IsNumericValue(value As Object) As Boolean
        If value Is Nothing OrElse value Is DBNull.Value Then Return False
        Select Case Type.GetTypeCode(value.GetType())
            Case TypeCode.Byte, TypeCode.SByte, TypeCode.Int16, TypeCode.Int32,
                 TypeCode.Int64, TypeCode.UInt16, TypeCode.UInt32, TypeCode.UInt64,
                 TypeCode.Decimal, TypeCode.Double, TypeCode.Single
                Return True
            Case Else
                Return False
        End Select
    End Function

    ''' <summary>Format satu sel menjadi teks yang ramah dibaca.</summary>
    Public Function FormatCell(value As Object) As String
        If value Is Nothing OrElse value Is DBNull.Value Then Return ""

        Select Case Type.GetTypeCode(value.GetType())
            Case TypeCode.Decimal, TypeCode.Double, TypeCode.Single
                Return Convert.ToDecimal(value, CultureInfo.InvariantCulture).ToString("N0", CultureAngka)
            Case TypeCode.DateTime
                Return Convert.ToDateTime(value).ToString("dd/MM/yyyy HH:mm")
            Case TypeCode.Int32, TypeCode.Int64
                Return Convert.ToInt64(value).ToString("N0", CultureAngka)
        End Select

        Return value.ToString()
    End Function

    Private Function XmlEscape(text As String) As String
        If String.IsNullOrEmpty(text) Then Return ""
        Return text.Replace("&", "&amp;").
                     Replace("<", "&lt;").
                     Replace(">", "&gt;").
                     Replace("""", "&quot;").
                     Replace("'", "&apos;")
    End Function

    ''' <summary>Filter SaveFileDialog gabungan untuk semua format export.</summary>
    Public Function BuildFilter() As String
        Return "Excel Workbook (*.xls)|*.xls|" &
               "CSV File (*.csv)|*.csv|" &
               "PDF Document (*.pdf)|*.pdf|" &
               "XML File (*.xml)|*.xml"
    End Function

    ''' <summary>Menjalankan export sesuai ekstensi file yang dipilih user.</summary>
    Public Function ExportByExtension(dt As DataTable, path As String, info As InfoLaporan) As Boolean
        Select Case System.IO.Path.GetExtension(path).ToLowerInvariant()
            Case ".csv"
                Return ExportCsv(dt, path, info)
            Case ".xls", ".xlsx"
                Return ExportExcel(dt, path, info)
            Case ".pdf"
                Return ExportPdf(dt, path, info)
            Case ".xml"
                Return ExportXml(dt, path, info)
            Case Else
                Return False
        End Select
    End Function

End Module
