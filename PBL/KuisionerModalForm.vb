Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Windows.Forms

Public Class KuisionerModalForm

    Private ReadOnly colorNavy As Color = Color.FromArgb(10, 37, 88)
    Private ReadOnly colorBorder As Color = Color.FromArgb(226, 232, 240)
    Private ReadOnly colorMuted As Color = Color.FromArgb(100, 116, 139)
    Private ReadOnly colorGreen As Color = Color.FromArgb(5, 150, 105)

    Private ReadOnly matkulJudul As String
    Private ReadOnly dosenNama As String

    ' Struktur Pertanyaan dan Jawaban
    Public Class SoalEdom
        Public Property Nomor As Integer
        Public Property Teks As String
        Public Property KategoriIndex As Integer
        Public Property Jawaban As Integer = 0 ' 3 = Baik, 2 = Cukup, 1 = Kurang
    End Class

    Private ReadOnly daftarSoal As New List(Of SoalEdom)()
    Private ReadOnly pilPillControls As New Dictionary(Of String, Panel)()

    Public Sub New(matkul As String, dosen As String)
        InitializeComponent()
        matkulJudul = matkul
        dosenNama = dosen
    End Sub

    Private Sub KuisionerModalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AdjustModalSize()
        PositionHeaderControls()
        lblSubtitle.Text = matkulJudul & " • Dosen: " & dosenNama
        ApplyFormRegion()
        InisialisasiDaftarSoal()
        RenderKuisionerCards()
        UpdateCounter()
    End Sub

    Private Sub PositionHeaderControls()
        If btnClose IsNot Nothing AndAlso pnlHeader IsNot Nothing Then
            btnClose.Location = New Point(pnlHeader.ClientSize.Width - btnClose.Width - 24, 18)
            btnClose.BringToFront()
        End If
    End Sub

    Private Sub pnlHeader_Resize(sender As Object, e As EventArgs) Handles pnlHeader.Resize
        PositionHeaderControls()
    End Sub

    Private Sub AdjustModalSize()
        Dim refBounds As Rectangle = If(Me.Owner IsNot Nothing, Me.Owner.Bounds, Screen.PrimaryScreen.WorkingArea)

        ' Popup hampir full (~90% ukuran dashboard) namun menyisakan margin backdrop
        Dim targetW As Integer = Math.Max(1040, Math.Min(1280, CInt(refBounds.Width * 0.9!)))
        Dim targetH As Integer = Math.Max(700, Math.Min(840, CInt(refBounds.Height * 0.9!)))

        Dim screenArea As Rectangle = Screen.FromControl(If(Me.Owner, Me)).WorkingArea
        targetW = Math.Min(targetW, screenArea.Width - 48)
        targetH = Math.Min(targetH, screenArea.Height - 48)

        Me.Size = New Size(targetW, targetH)
        Me.Location = New Point(refBounds.Left + (refBounds.Width - targetW) \ 2,
                                refBounds.Top + (refBounds.Height - targetH) \ 2)
    End Sub

    Private Sub ApplyFormRegion()
        Me.Region = New Region(GetRoundedPath(New Rectangle(0, 0, Me.Width, Me.Height), 12))
        If btnClose IsNot Nothing Then
            btnClose.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnClose.Width, btnClose.Height), 6))
        End If
        If btnBatal IsNot Nothing Then
            btnBatal.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnBatal.Width, btnBatal.Height), 6))
        End If
        If btnKirim IsNot Nothing Then
            btnKirim.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnKirim.Width, btnKirim.Height), 6))
        End If
    End Sub

    Private Sub KuisionerModalForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PositionHeaderControls()
        ApplyFormRegion()
    End Sub

    Private Sub KuisionerModalForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using penBdr As New Pen(Color.FromArgb(203, 213, 225), 1.0!)
            e.Graphics.DrawPath(penBdr, GetRoundedPath(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 12))
        End Using
    End Sub

    ' 27 Butir Instrumen Resmi EDOM 2023 (4 Kategori)
    Private Sub InisialisasiDaftarSoal()
        daftarSoal.Clear()

        ' Kategori 1: Pedagogik (9 soal)
        Dim pedagogik = {
            "Kesiapan memberikan kuliah dan/atau praktek/praktikum",
            "Keteraturan dan ketertiban penyelenggaraan perkuliahan",
            "Kemampuan menghidupkan suasana kelas",
            "Kejelasan penyampaian materi dan jawaban terhadap pertanyaan di kelas",
            "Pemanfaatan media dan teknologi pembelajaran",
            "Keanekaragaman cara pengukuran/penilaian hasil belajar",
            "Pemberian umpan balik terhadap tugas/penilaian",
            "Kesesuaian materi ujian dan/atau tugas dengan tujuan mata kuliah",
            "Kesesuaian nilai yang diberikan dengan hasil belajar"
        }
        For i = 0 To pedagogik.Length - 1
            daftarSoal.Add(New SoalEdom With {.Nomor = i + 1, .Teks = pedagogik(i), .KategoriIndex = 1})
        Next

        ' Kategori 2: Profesional (8 soal)
        Dim profesional = {
            "Kemampuan menjelaskan pokok bahasan/topik secara tepat sesuai GBPP dan SAP",
            "Kemampuan memberi contoh relevan dari konsep yang diajarkan berdasarkan Program Studi",
            "Kemampuan menjelaskan keterkaitan bidang/topik yang diajarkan dengan bidang/topik lain",
            "Kemampuan menjelaskan keterkaitan bidang/topik yang diajarkan dengan konteks kehidupan",
            "Penguasaan akan isu-isu mutakhir dalam bidang yang diajarkan (kemutakhiran bahan kuliah)",
            "Penggunaan hasil-hasil penelitian untuk meningkatkan kualitas perkuliahan",
            "Pelibatan mahasiswa dalam penelitian/kajian dan atau pengembangan/desain dosen",
            "Kemampuan menggunakan beragam teknologi komunikasi"
        }
        For i = 0 To profesional.Length - 1
            daftarSoal.Add(New SoalEdom With {.Nomor = 10 + i, .Teks = profesional(i), .KategoriIndex = 2})
        Next

        ' Kategori 3: Kepribadian (6 soal)
        Dim kepribadian = {
            "Kewibawaan sebagai pribadi dosen",
            "Kearifan dalam mengambil keputusan",
            "Menjadi contoh dalam bersikap dan berperilaku",
            "Satu kata dan tindakan",
            "Kemampuan mengendalikan diri dalam berbagai situasi dan kondisi",
            "Adil dalam memperlakukan mahasiswa"
        }
        For i = 0 To kepribadian.Length - 1
            daftarSoal.Add(New SoalEdom With {.Nomor = 18 + i, .Teks = kepribadian(i), .KategoriIndex = 3})
        Next

        ' Kategori 4: Sosial (4 soal)
        Dim sosial = {
            "Kemampuan menyampaikan pendapat",
            "Kemampuan menerima kritik, saran, dan pendapat dari mahasiswa",
            "Mengenal dengan baik mahasiswa yang mengikuti kuliahnya",
            "Toleransi terhadap keberagaman mahasiswa"
        }
        For i = 0 To sosial.Length - 1
            daftarSoal.Add(New SoalEdom With {.Nomor = 24 + i, .Teks = sosial(i), .KategoriIndex = 4})
        Next
    End Sub

    ' Render 4 Card Kategori secara dinamis dan responsif
    Private Sub RenderKuisionerCards()
        pnlScrollQuestions.SuspendLayout()
        pnlScrollQuestions.Controls.Clear()
        pilPillControls.Clear()

        Dim kategoriData = {
            New With {.Index = 1, .Judul = "1. Kompetensi Pedagogik", .Jumlah = 9},
            New With {.Index = 2, .Judul = "2. Kompetensi Profesional", .Jumlah = 8},
            New With {.Index = 3, .Judul = "3. Kompetensi Kepribadian", .Jumlah = 6},
            New With {.Index = 4, .Judul = "4. Kompetensi Sosial", .Jumlah = 4}
        }

        Dim cardY As Integer = 16
        Dim cardWidth As Integer = pnlScrollQuestions.ClientSize.Width - 48 - SystemInformation.VerticalScrollBarWidth

        For Each kat In kategoriData
            Dim soalKategori = daftarSoal.Where(Function(s) s.KategoriIndex = kat.Index).ToList()
            Dim cardHeight As Integer = 46 + (soalKategori.Count * 48) + 8

            Dim card As New Panel With {
                .BackColor = Color.White,
                .Left = 24,
                .Top = cardY,
                .Width = cardWidth,
                .Height = cardHeight,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            }

            ' Header Kategori
            Dim pnlCardHeader As New Panel With {
                .Dock = DockStyle.Top,
                .Height = 44,
                .BackColor = Color.FromArgb(248, 250, 252),
                .Padding = New Padding(16, 0, 16, 0)
            }

            Dim lblKatTitle As New Label With {
                .Text = kat.Judul,
                .Font = New Font("Segoe UI", 9.5!, FontStyle.Bold),
                .ForeColor = Color.FromArgb(15, 23, 42),
                .AutoSize = False,
                .Dock = DockStyle.Left,
                .Width = 350,
                .TextAlign = ContentAlignment.MiddleLeft
            }

            Dim lblKatBadge As New Label With {
                .Text = kat.Jumlah.ToString() & " pernyataan",
                .Font = New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold),
                .ForeColor = colorMuted,
                .AutoSize = False,
                .Dock = DockStyle.Right,
                .Width = 110,
                .TextAlign = ContentAlignment.MiddleRight
            }

            pnlCardHeader.Controls.Add(lblKatTitle)
            pnlCardHeader.Controls.Add(lblKatBadge)
            card.Controls.Add(pnlCardHeader)

            ' Render Butir Soal di dalam Kategori
            Dim rowY As Integer = 46
            For Each item In soalKategori
                Dim rowPanel As New Panel With {
                    .Left = 0,
                    .Top = rowY,
                    .Width = cardWidth,
                    .Height = 48,
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                }

                ' Nomor (01, 02, ...)
                Dim lblNo As New Label With {
                    .Text = item.Nomor.ToString("D2"),
                    .Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold),
                    .ForeColor = Color.FromArgb(148, 163, 184),
                    .Location = New Point(16, 14),
                    .Size = New Size(28, 20)
                }

                ' Teks Pernyataan
                Dim lblTeks As New Label With {
                    .Text = item.Teks,
                    .Font = New Font("Segoe UI", 9.0!),
                    .ForeColor = Color.FromArgb(30, 41, 59),
                    .Location = New Point(48, 8),
                    .Size = New Size(cardWidth - 390, 34),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                    .TextAlign = ContentAlignment.MiddleLeft
                }

                ' Container Opsi Jawaban (Kurang, Cukup, Baik)
                Dim pnlOptions As New Panel With {
                    .Location = New Point(cardWidth - 325, 7),
                    .Size = New Size(310, 34),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Right
                }

                Dim optKurang = CreateOptionPill(item, 1, "Kurang", 0)
                Dim optCukup = CreateOptionPill(item, 2, "Cukup", 104)
                Dim optBaik = CreateOptionPill(item, 3, "Baik", 208)

                pnlOptions.Controls.Add(optKurang)
                pnlOptions.Controls.Add(optCukup)
                pnlOptions.Controls.Add(optBaik)

                rowPanel.Controls.Add(lblNo)
                rowPanel.Controls.Add(lblTeks)
                rowPanel.Controls.Add(pnlOptions)

                card.Controls.Add(rowPanel)
                rowY += 48
            Next

            ' Border styling untuk Card
            AddHandler card.Paint, Sub(s, pe)
                pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                Dim r As New Rectangle(0, 0, card.Width - 1, card.Height - 1)
                Using pen As New Pen(colorBorder, 1.0!)
                    pe.Graphics.DrawPath(pen, GetRoundedPath(r, 8))
                End Using
            End Sub

            pnlScrollQuestions.Controls.Add(card)
            cardY += cardHeight + 16
        Next

        pnlScrollQuestions.ResumeLayout(True)
    End Sub

    ' Membuat Tombol Pill Radio Jawaban
    Private Function CreateOptionPill(item As SoalEdom, score As Integer, labelText As String, xPos As Integer) As Panel
        Dim pill As New Panel With {
            .Left = xPos,
            .Top = 0,
            .Width = 98,
            .Height = 32,
            .BackColor = Color.White,
            .Cursor = Cursors.Hand
        }

        Dim rb As New RadioButton With {
            .Text = labelText,
            .Font = New Font("Segoe UI", 8.5!),
            .ForeColor = Color.FromArgb(51, 65, 85),
            .BackColor = Color.Transparent,
            .Location = New Point(10, 5),
            .Size = New Size(80, 22),
            .AutoCheck = False,
            .Cursor = Cursors.Hand
        }

        Dim key As String = item.Nomor.ToString() & "_" & score.ToString()
        pilPillControls(key) = pill

        Dim onClick As EventHandler = Sub(s, e)
            item.Jawaban = score
            UpdateRowPillsState(item.Nomor, score)
            UpdateCounter()
        End Sub

        AddHandler pill.Click, onClick
        AddHandler rb.Click, onClick

        ' Custom Border & Fill Paint
        AddHandler pill.Paint, Sub(s, pe)
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Dim isSelected = (item.Jawaban = score)
            Dim rect As New Rectangle(0, 0, pill.Width - 1, pill.Height - 1)
            Dim bdrColor = If(isSelected, colorNavy, colorBorder)
            Dim fillColor = If(isSelected, Color.FromArgb(239, 246, 255), Color.White)

            Using path = GetRoundedPath(rect, 6), brBg As New SolidBrush(fillColor), pen As New Pen(bdrColor, If(isSelected, 1.5!, 1.0!))
                pe.Graphics.FillPath(brBg, path)
                pe.Graphics.DrawPath(pen, path)
            End Using
        End Sub

        pill.Controls.Add(rb)
        Return pill
    End Function

    Private Sub UpdateRowPillsState(soalNomor As Integer, selectedScore As Integer)
        For s = 1 To 3
            Dim key As String = soalNomor.ToString() & "_" & s.ToString()
            If pilPillControls.ContainsKey(key) Then
                Dim pill = pilPillControls(key)
                Dim rb = pill.Controls.OfType(Of RadioButton)().FirstOrDefault()
                If rb IsNot Nothing Then
                    rb.Checked = (s = selectedScore)
                    rb.Font = New Font("Segoe UI", 8.5!, If(s = selectedScore, FontStyle.Bold, FontStyle.Regular))
                    rb.ForeColor = If(s = selectedScore, colorNavy, Color.FromArgb(51, 65, 85))
                End If
                pill.Invalidate()
            End If
        Next
    End Sub

    Private Sub UpdateCounter()
        Dim answered As Integer = daftarSoal.Where(Function(s) s.Jawaban > 0).Count()
        Dim total As Integer = daftarSoal.Count

        If answered = total Then
            lblFooterCounter.Text = total.ToString() & " Pernyataan Lengkap Terisi (100%)"
            lblFooterCounter.ForeColor = colorGreen
            lblFooterHint.Text = "Seluruh pernyataan telah dinilai. Klik 'Kirim Kuisioner' untuk menyimpan."
        Else
            lblFooterCounter.Text = answered.ToString() & " / " & total.ToString() & " Pernyataan Terisi"
            lblFooterCounter.ForeColor = Color.FromArgb(15, 23, 42)
            lblFooterHint.Text = "Pastikan seluruh pernyataan sudah terisi sebelum mengirim."
        End If
    End Sub

    ' Validasi dan Kirim
    Private Sub btnKirim_Click(sender As Object, e As EventArgs) Handles btnKirim.Click
        Dim missingCount As Integer = daftarSoal.Where(Function(s) s.Jawaban = 0).Count()
        If missingCount > 0 Then
            MessageBox.Show("Masih terdapat " & missingCount.ToString() & " pernyataan yang belum dinilai." & vbCrLf &
                            "Silakan lengkapi seluruh kuisioner sebelum mengirimkan evaluasi.",
                            "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("Terima kasih! Kuisioner EDOM untuk mata kuliah " & matkulJudul & " berhasil disimpan.",
                        "Kuisioner Terkirim", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click, btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.BackColor = Color.FromArgb(241, 245, 249)
        btnClose.ForeColor = Color.FromArgb(15, 23, 42)
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackColor = Color.White
        btnClose.ForeColor = Color.FromArgb(100, 116, 139)
    End Sub

    ' Window Dragging from Header
    Private isDragging As Boolean = False
    Private dragCursorPoint As Point
    Private dragFormPoint As Point

    Private Sub pnlHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlHeader.MouseDown, lblTitle.MouseDown, lblSubtitle.MouseDown
        isDragging = True
        dragCursorPoint = Cursor.Position
        dragFormPoint = Me.Location
    End Sub

    Private Sub pnlHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlHeader.MouseMove, lblTitle.MouseMove, lblSubtitle.MouseMove
        If isDragging Then
            Dim diff = Point.Subtract(Cursor.Position, New Size(dragCursorPoint))
            Me.Location = Point.Add(dragFormPoint, New Size(diff))
        End If
    End Sub

    Private Sub pnlHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlHeader.MouseUp, lblTitle.MouseUp, lblSubtitle.MouseUp
        isDragging = False
    End Sub

    Private Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2
        If d > rect.Width Then d = rect.Width
        If d > rect.Height Then d = rect.Height
        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

End Class