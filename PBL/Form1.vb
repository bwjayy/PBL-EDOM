Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class Form1

    ' Model data Mata Kuliah (Pure UI Mock Data)
    Public Class MatkulItem
        Public Property No As Integer
        Public Property KodeMatkul As String
        Public Property NamaMatkul As String
        Public Property DosenPengampu As String
        Public Property Status As String
    End Class

    Private semuaMatkul As New List(Of MatkulItem)()
    Private matkulTampil As New List(Of MatkulItem)()

    Private hoveredRowIndex As Integer = -1
    Private hoveredColIndex As Integer = -1

    ' Design System Palette (Dari Referensi Gambar)
    Private ReadOnly primaryBlue As Color = Color.FromArgb(30, 58, 138)     ' #1E3A8A (Primary)
    Private ReadOnly primaryHover As Color = Color.FromArgb(2, 132, 199)    ' #0284C7 (Tertiary Cyan Hover)
    Private ReadOnly secondaryDark As Color = Color.FromArgb(15, 23, 42)    ' #0F172A (Secondary Dark)
    Private ReadOnly tertiaryCyan As Color = Color.FromArgb(2, 132, 199)    ' #0284C7 (Tertiary)
    Private ReadOnly neutralSlate As Color = Color.FromArgb(100, 116, 139)  ' #64748B (Neutral)
    Private ReadOnly bgSlate As Color = Color.FromArgb(241, 245, 249)       ' #F1F5F9 (Background)
    Private ReadOnly cardBorderColor As Color = Color.FromArgb(226, 232, 240) ' #E2E8F0

    ' Pill Badge Colors
    Private ReadOnly badgeRedBg As Color = Color.FromArgb(254, 226, 226)    ' #FEE2E2
    Private ReadOnly badgeRedText As Color = Color.FromArgb(220, 38, 38)     ' #DC2626
    Private ReadOnly badgeGreenBg As Color = Color.FromArgb(220, 252, 231)  ' #DCFCE7
    Private ReadOnly badgeGreenText As Color = Color.FromArgb(22, 163, 74)   ' #16A34A

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup Dropdown Tahun Akademik
        cboTahunAkademik.Items.AddRange(New Object() {
            "2026/2027 Ganjil",
            "2025/2026 Genap",
            "2025/2026 Ganjil"
        })
        cboTahunAkademik.SelectedIndex = 0

        ' Inisialisasi Data 10 Mata Kuliah EDOM Kelas 3C
        InisialisasiDataMatkul()

        ' Setup DataGridView Modern
        SetupDataGridView()

        ' Refresh Tampilan & KPI Card
        UpdateFilterData()
        AturLayoutResponsif()
    End Sub

    Private Sub InisialisasiDataMatkul()
        semuaMatkul.Clear()
        semuaMatkul.Add(New MatkulItem With {.No = 1, .KodeMatkul = "TIK309", .NamaMatkul = "Grafika Komputer (3C)", .DosenPengampu = "ANGGI MARDIYONO", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 2, .KodeMatkul = "TIK308", .NamaMatkul = "Analisis dan Desain Sistem Informasi (3C)", .DosenPengampu = "ANITA HIDAYATI", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 3, .KodeMatkul = "TIK306", .NamaMatkul = "Pemrograman Web Lanjut (3C)", .DosenPengampu = "ASEP TAUFIK MUHARRAM", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 4, .KodeMatkul = "TIK302", .NamaMatkul = "Manajemen Proyek TIK (3C)", .DosenPengampu = "BAMBANG WARSUTA", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 5, .KodeMatkul = "TIK301", .NamaMatkul = "Pemrograman Visual (3C)", .DosenPengampu = "CHAIRUL FIKRI", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 6, .KodeMatkul = "TIK310", .NamaMatkul = "Sistem Terdistribusi (3C)", .DosenPengampu = "DEFIANA ARNALDY", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 7, .KodeMatkul = "TIK305", .NamaMatkul = "Metode Numerik (3C)", .DosenPengampu = "FAJAR SEPTIAN", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 8, .KodeMatkul = "TIK303", .NamaMatkul = "Desain UI/UX (3C)", .DosenPengampu = "IWAN SONJAYA", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 9, .KodeMatkul = "TIK307", .NamaMatkul = "Pemrograman Basis Data (3C)", .DosenPengampu = "RISNA SARI", .Status = "Belum Terisi"})
        semuaMatkul.Add(New MatkulItem With {.No = 10, .KodeMatkul = "TIK304", .NamaMatkul = "Kecerdasan Buatan (3C)", .DosenPengampu = "RIZKI ELISA NALAWATI", .Status = "Belum Terisi"})
    End Sub

    Private Sub SetupDataGridView()
        dgvEdom.Columns.Clear()
        dgvEdom.AutoGenerateColumns = False
        dgvEdom.RowHeadersVisible = False
        dgvEdom.AllowUserToResizeRows = False
        dgvEdom.AllowUserToResizeColumns = False
        dgvEdom.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEdom.MultiSelect = False
        dgvEdom.BackgroundColor = Color.White
        dgvEdom.BorderStyle = BorderStyle.None
        dgvEdom.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvEdom.GridColor = Color.FromArgb(241, 245, 249)
        dgvEdom.RowTemplate.Height = 56
        dgvEdom.ColumnHeadersHeight = 44

        ' 1. NO
        Dim colNo As New DataGridViewTextBoxColumn()
        colNo.Name = "colNo"
        colNo.HeaderText = "NO"
        colNo.Width = 55
        colNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvEdom.Columns.Add(colNo)

        ' 2. MATAKULIAH
        Dim colMatkul As New DataGridViewTextBoxColumn()
        colMatkul.Name = "colMatkul"
        colMatkul.HeaderText = "MATA KULIAH"
        colMatkul.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colMatkul.FillWeight = 42.0!
        colMatkul.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colMatkul.DefaultCellStyle.Padding = New Padding(12, 0, 10, 0)
        dgvEdom.Columns.Add(colMatkul)

        ' 3. DOSEN PENGAMPU
        Dim colDosen As New DataGridViewTextBoxColumn()
        colDosen.Name = "colDosen"
        colDosen.HeaderText = "DOSEN PENGAMPU"
        colDosen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDosen.FillWeight = 32.0!
        colDosen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colDosen.DefaultCellStyle.Padding = New Padding(10, 0, 10, 0)
        dgvEdom.Columns.Add(colDosen)

        ' 4. STATUS (Pill Badge)
        Dim colStatus As New DataGridViewTextBoxColumn()
        colStatus.Name = "colStatus"
        colStatus.HeaderText = "STATUS"
        colStatus.Width = 140
        colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvEdom.Columns.Add(colStatus)

        ' 5. AKSI (Modern Primary Button)
        Dim colAksi As New DataGridViewTextBoxColumn()
        colAksi.Name = "colAksi"
        colAksi.HeaderText = "AKSI"
        colAksi.Width = 140
        colAksi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvEdom.Columns.Add(colAksi)
    End Sub

    ' Filter data berdasarkan pencarian & muat ke DataGridView
    Private Sub UpdateFilterData()
        Dim keyword As String = txtSearch.Text.Trim().ToLower()
        matkulTampil.Clear()

        For Each item In semuaMatkul
            If String.IsNullOrEmpty(keyword) OrElse
               item.NamaMatkul.ToLower().Contains(keyword) OrElse
               item.KodeMatkul.ToLower().Contains(keyword) OrElse
               item.DosenPengampu.ToLower().Contains(keyword) Then
                matkulTampil.Add(item)
            End If
        Next

        dgvEdom.Rows.Clear()
        For Each item In matkulTampil
            Dim displayText As String = item.KodeMatkul & " - " & item.NamaMatkul
            Dim rowIndex As Integer = dgvEdom.Rows.Add(item.No, displayText, item.DosenPengampu, item.Status, "Isi Kuisioner")
            dgvEdom.Rows(rowIndex).Tag = item
        Next

        'lblTableCountBadge.Text = matkulTampil.Count.ToString() & " Mata Kuliah"

        ' Update KPI Stat Cards
        UpdateKpiCards()

        ' Sesuaikan tinggi DataGridView
        Dim totalRowHeight As Integer = dgvEdom.ColumnHeadersHeight + (Math.Max(1, dgvEdom.Rows.Count) * dgvEdom.RowTemplate.Height) + 10
        dgvEdom.Height = totalRowHeight
        pnlTableCard.Height = dgvEdom.Top + dgvEdom.Height + 25
        pnlContent.Height = pnlTableCard.Top + pnlTableCard.Height + 20
    End Sub

    ' Hitung dan Update Widget KPI Cards
    Private Sub UpdateKpiCards()
        Dim total As Integer = semuaMatkul.Count
        Dim selesai As Integer = 0
        For Each m In semuaMatkul
            If m.Status = "Sudah Terisi" Then selesai += 1
        Next

        Dim persentase As Integer = If(total > 0, CInt((selesai / total) * 100), 0)

        lblKpi1Value.Text = total.ToString() & " Matakuliah"
        lblKpi2Value.Text = selesai.ToString() & " / " & total.ToString() & " Selesai (" & persentase.ToString() & "%)"

        ' Animasi Lebar Bar Progress
        Dim maxBarWidth As Integer = pnlProgressBarBg.Width
        Dim fillWidth As Integer = CInt((persentase / 100.0!) * maxBarWidth)
        pnlProgressBarFill.Width = fillWidth

        If persentase = 100 Then
            pnlProgressBarFill.BackColor = Color.FromArgb(16, 185, 129) ' Green
            lblKpi2Value.ForeColor = Color.FromArgb(16, 185, 129)
        Else
            pnlProgressBarFill.BackColor = tertiaryCyan
            lblKpi2Value.ForeColor = primaryBlue
        End If
    End Sub

    ' Real-time search filter
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        UpdateFilterData()
    End Sub

    ' =========================================================================
    ' CUSTOM CELL PAINTING: PILL STATUS BADGE & ROUNDED ACTION BUTTON
    ' =========================================================================
    Private Sub dgvEdom_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvEdom.CellPainting
        If e.RowIndex < 0 Then Return

        Dim isSelected As Boolean = (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected
        Dim rowBgColor As Color = If(isSelected, Color.FromArgb(248, 250, 252), Color.White)

        ' 1. Custom Status Badge (Modern Rounded Pill Shape)
        If e.ColumnIndex = dgvEdom.Columns("colStatus").Index Then
            e.Graphics.FillRectangle(New SolidBrush(rowBgColor), e.CellBounds)
            Using penLine As New Pen(Color.FromArgb(241, 245, 249))
                e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1)
            End Using

            Dim statusText As String = If(e.Value IsNot Nothing, e.Value.ToString(), "")
            Dim isSudah As Boolean = (statusText = "Sudah Terisi")

            Dim pillWidth As Integer = 110
            Dim pillHeight As Integer = 28
            Dim pillX As Integer = e.CellBounds.Left + (e.CellBounds.Width - pillWidth) \ 2
            Dim pillY As Integer = e.CellBounds.Top + (e.CellBounds.Height - pillHeight) \ 2
            Dim pillRect As New Rectangle(pillX, pillY, pillWidth, pillHeight)

            Dim bgPill As Color = If(isSudah, badgeGreenBg, badgeRedBg)
            Dim textPill As Color = If(isSudah, badgeGreenText, badgeRedText)
            Dim displayLabel As String = If(isSudah, "✓  Terisi", "•  Belum Terisi")

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using path As GraphicsPath = GetRoundedPath(pillRect, 14)
                Using brPill As New SolidBrush(bgPill)
                    e.Graphics.FillPath(brPill, path)
                End Using
            End Using

            Using fontPill As New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
                Using brText As New SolidBrush(textPill)
                    Dim sf As New StringFormat With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    e.Graphics.DrawString(displayLabel, fontPill, brText, pillRect, sf)
                End Using
            End Using

            e.Handled = True
            Return
        End If

        ' 2. Custom Action Button (#1E3A8A Primary Pill Button)
        If e.ColumnIndex = dgvEdom.Columns("colAksi").Index Then
            e.Graphics.FillRectangle(New SolidBrush(rowBgColor), e.CellBounds)
            Using penLine As New Pen(Color.FromArgb(241, 245, 249))
                e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1)
            End Using

            Dim item As MatkulItem = TryCast(dgvEdom.Rows(e.RowIndex).Tag, MatkulItem)
            Dim isSudah As Boolean = (item IsNot Nothing AndAlso item.Status = "Sudah Terisi")

            Dim btnWidth As Integer = 120
            Dim btnHeight As Integer = 34
            Dim btnX As Integer = e.CellBounds.Left + (e.CellBounds.Width - btnWidth) \ 2
            Dim btnY As Integer = e.CellBounds.Top + (e.CellBounds.Height - btnHeight) \ 2
            Dim btnRect As New Rectangle(btnX, btnY, btnWidth, btnHeight)

            Dim isHovered As Boolean = (e.RowIndex = hoveredRowIndex AndAlso e.ColumnIndex = hoveredColIndex)
            Dim btnBgColor As Color
            Dim btnTextColor As Color = Color.White

            If isSudah Then
                btnBgColor = Color.FromArgb(241, 245, 249) ' Outlined style
                btnTextColor = Color.FromArgb(71, 85, 105)
            ElseIf isHovered Then
                btnBgColor = primaryHover
            Else
                btnBgColor = primaryBlue
            End If

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using path As GraphicsPath = GetRoundedPath(btnRect, 8)
                Using brBtn As New SolidBrush(btnBgColor)
                    e.Graphics.FillPath(brBtn, path)
                End Using
                If isSudah Then
                    Using penBorder As New Pen(Color.FromArgb(203, 213, 225), 1.0!)
                        e.Graphics.DrawPath(penBorder, path)
                    End Using
                End If
            End Using

            Dim btnLabel As String = If(isSudah, "Lihat / Edit", "✎  Isi Kuisioner")
            Using fontBtn As New Font("Segoe UI Semibold", 8.75!, FontStyle.Bold)
                Using brText As New SolidBrush(btnTextColor)
                    Dim sf As New StringFormat With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    e.Graphics.DrawString(btnLabel, fontBtn, brText, btnRect, sf)
                End Using
            End Using

            e.Handled = True
            Return
        End If

        ' Default bottom divider untuk kolom lainnya
        e.Paint(e.CellBounds, DataGridViewPaintParts.All)
        Using penLine As New Pen(Color.FromArgb(241, 245, 249))
            e.Graphics.DrawLine(penLine, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1)
        End Using
        e.Handled = True
    End Sub

    ' Hover Cursor Handler
    Private Sub dgvEdom_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEdom.CellMouseMove
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgvEdom.Columns("colAksi").Index Then
            Dim cellRect As Rectangle = dgvEdom.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
            Dim btnWidth As Integer = 120
            Dim btnHeight As Integer = 34
            Dim btnX As Integer = (cellRect.Width - btnWidth) \ 2
            Dim btnY As Integer = (cellRect.Height - btnHeight) \ 2
            Dim btnRect As New Rectangle(btnX, btnY, btnWidth, btnHeight)

            If btnRect.Contains(e.Location) Then
                dgvEdom.Cursor = Cursors.Hand
                If hoveredRowIndex <> e.RowIndex OrElse hoveredColIndex <> e.ColumnIndex Then
                    hoveredRowIndex = e.RowIndex
                    hoveredColIndex = e.ColumnIndex
                    dgvEdom.InvalidateCell(e.ColumnIndex, e.RowIndex)
                End If
                Return
            End If
        End If

        If dgvEdom.Cursor <> Cursors.Default Then dgvEdom.Cursor = Cursors.Default
        If hoveredRowIndex <> -1 Then
            Dim prevRow As Integer = hoveredRowIndex
            Dim prevCol As Integer = hoveredColIndex
            hoveredRowIndex = -1
            hoveredColIndex = -1
            dgvEdom.InvalidateCell(prevCol, prevRow)
        End If
    End Sub

    Private Sub dgvEdom_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEdom.CellMouseLeave
        dgvEdom.Cursor = Cursors.Default
        If hoveredRowIndex <> -1 Then
            Dim prevRow As Integer = hoveredRowIndex
            Dim prevCol As Integer = hoveredColIndex
            hoveredRowIndex = -1
            hoveredColIndex = -1
            dgvEdom.InvalidateCell(prevCol, prevRow)
        End If
    End Sub

    ' Logout / Keluar kembali ke Login Page
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Close()
    End Sub

    ' =========================================================================
    ' CUSTOM PAINTING LOGO, AVATAR, DAN CARD BORDERS
    ' =========================================================================
    Private Sub picSidebarLogo_Paint(sender As Object, e As PaintEventArgs) Handles picSidebarLogo.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(2, 2, picSidebarLogo.Width - 5, picSidebarLogo.Height - 5)
        Using path As GraphicsPath = GetRoundedPath(rect, 12)
            Using br As New LinearGradientBrush(rect, primaryBlue, tertiaryCyan, 45.0!)
                e.Graphics.FillPath(br, path)
            End Using
        End Using

        Using fontLogo As New Font("Segoe UI", 16.0!, FontStyle.Bold)
            Using brWhite As New SolidBrush(Color.White)
                Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString("E", fontLogo, brWhite, rect, sf)
            End Using
        End Using
    End Sub

    Private Sub picUserAvatar_Paint(sender As Object, e As PaintEventArgs) Handles picUserAvatar.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(1, 1, picUserAvatar.Width - 3, picUserAvatar.Height - 3)
        Using brBg As New SolidBrush(primaryBlue)
            e.Graphics.FillEllipse(brBg, rect)
        End Using

        Using fontAvatar As New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold)
            Using brText As New SolidBrush(Color.White)
                Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString("BW", fontAvatar, brText, rect, sf)
            End Using
        End Using
    End Sub

    ' Card Paint Helpers
    Private Sub cardTotalMatkul_Paint(sender As Object, e As PaintEventArgs) Handles cardTotalMatkul.Paint, cardProgress.Paint, cardDeadline.Paint
        Dim pnl = CType(sender, Panel)
        DrawModernCardBorder(e.Graphics, pnl.ClientRectangle)
    End Sub

    Private Sub pnlTableCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlTableCard.Paint
        DrawModernCardBorder(e.Graphics, pnlTableCard.ClientRectangle)
    End Sub

    Private Sub pnlAlert_Paint(sender As Object, e As PaintEventArgs) Handles pnlAlert.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlAlert.Width - 1, pnlAlert.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 8)
            Using br As New SolidBrush(Color.FromArgb(239, 246, 255))
                e.Graphics.FillPath(br, path)
            End Using
            Using penBdr As New Pen(Color.FromArgb(191, 219, 254), 1.0!)
                e.Graphics.DrawPath(penBdr, path)
            End Using
        End Using
    End Sub

    Private Sub pnlSearchBox_Paint(sender As Object, e As PaintEventArgs) Handles pnlSearchBox.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlSearchBox.Width - 1, pnlSearchBox.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 16)
            Using br As New SolidBrush(Color.FromArgb(248, 250, 252))
                e.Graphics.FillPath(br, path)
            End Using
            Using penBdr As New Pen(Color.FromArgb(226, 232, 240), 1.0!)
                e.Graphics.DrawPath(penBdr, path)
            End Using
        End Using
    End Sub

    Private Sub DrawModernCardBorder(g As Graphics, rect As Rectangle)
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim drawRect As New Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(drawRect, 10)
            Using br As New SolidBrush(Color.White)
                g.FillPath(br, path)
            End Using
            Using penBdr As New Pen(cardBorderColor, 1.0!)
                g.DrawPath(penBdr, path)
            End Using
        End Using
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

    ' Atur Ukuran Responsif
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize, pnlScrollBody.Resize
        AturLayoutResponsif()
    End Sub

    Private Sub AturLayoutResponsif()
        If pnlContent Is Nothing OrElse pnlScrollBody Is Nothing Then Return

        ' Lebar area konten: kurangi margin kiri 32px dan margin kanan 32px (total 64px)
        Dim availWidth As Integer = pnlScrollBody.ClientSize.Width - 64
        If availWidth < 860 Then availWidth = 860

        pnlContent.Left = 32
        pnlContent.Width = availWidth

        ' Lebar 3 Card KPI seimbang
        Dim cardSpacing As Integer = 16
        Dim cardWidth As Integer = (availWidth - (cardSpacing * 2)) \ 3
        cardTotalMatkul.Left = 0
        cardTotalMatkul.Width = cardWidth

        cardProgress.Left = cardTotalMatkul.Right + cardSpacing
        cardProgress.Width = cardWidth

        cardDeadline.Left = cardProgress.Right + cardSpacing
        cardDeadline.Width = cardWidth

        pnlKpiRow.Width = availWidth

        If pnlProgressBarBg IsNot Nothing Then
            pnlProgressBarBg.Width = Math.Max(100, cardProgress.ClientSize.Width - 36)
        End If
        UpdateKpiCards()

        If pnlAlert IsNot Nothing Then
            pnlAlert.Width = availWidth
            lblAlertText.Width = pnlAlert.ClientSize.Width - 65
        End If

        If pnlTableCard IsNot Nothing Then
            pnlTableCard.Width = availWidth
            If dgvEdom IsNot Nothing Then
                dgvEdom.Width = pnlTableCard.ClientSize.Width - 42
            End If
            If lblTablePeriode IsNot Nothing Then
                lblTablePeriode.Left = pnlTableCard.ClientSize.Width - lblTablePeriode.Width - 24
            End If
            pnlContent.Height = pnlTableCard.Top + pnlTableCard.Height + 35
        End If

        pnlContent.Invalidate(True)
    End Sub

    ' Filter Tahun Akademik berubah
    Private Sub cboTahunAkademik_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTahunAkademik.SelectedIndexChanged
        UpdateFilterData()
    End Sub

    Private Sub dgvEdom_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEdom.CellContentClick

    End Sub
End Class
