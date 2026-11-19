Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Windows.Forms

Public Class Form1

    Private ReadOnly colorNavy As Color = Color.FromArgb(10, 37, 88)
    Private ReadOnly colorNavyHover As Color = Color.FromArgb(14, 48, 112)
    Private ReadOnly colorBorder As Color = Color.FromArgb(226, 232, 240)
    Private ReadOnly colorMuted As Color = Color.FromArgb(100, 116, 139)
    Private ReadOnly colorDark As Color = Color.FromArgb(15, 23, 42)
    Private ReadOnly colorAmber As Color = Color.FromArgb(217, 119, 6)
    Private ReadOnly colorAmberBg As Color = Color.FromArgb(254, 243, 199)
    Private ReadOnly colorAmberText As Color = Color.FromArgb(180, 83, 9)
    Private ReadOnly colorGreen As Color = Color.FromArgb(5, 150, 105)
    Private ReadOnly colorGreenBg As Color = Color.FromArgb(236, 253, 245)
    Private ReadOnly colorBlue As Color = Color.FromArgb(37, 99, 235)
    Private ReadOnly colorBlueBg As Color = Color.FromArgb(239, 246, 255)

    Private currentTab As String = "ALL"
    Private edomLocked As Boolean = False
    Private isInitializing As Boolean = True
    Private lblTableEmpty As Label

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UserSession.IsLoggedIn Then
            lblSidebarUserName.Text = UserSession.Nama
            lblSidebarUserRole.Text = "Mahasiswa • " & If(String.IsNullOrWhiteSpace(UserSession.ProdiCode), "TI", UserSession.ProdiCode)
            lblBreadcrumbTitle.Text = "Selamat datang kembali, " & UserSession.Nama
            lblAlertText.Text = "Pengisian EDOM bersifat wajib bagi seluruh mahasiswa Program Studi " &
                                If(String.IsNullOrWhiteSpace(UserSession.NamaProdi), "Teknik Informatika", UserSession.NamaProdi) &
                                " sebagai syarat percetakan Kartu Hasil Studi (KHS)."
        End If

        cboTahunAkademik.Items.AddRange(New Object() {"2026/2027 Ganjil", "2025/2026 Genap", "2025/2026 Ganjil"})
        cboTahunAkademik.SelectedIndex = 0

        SetupDataGridView()
        SetupEmptyStateLabel()
        isInitializing = False

        LoadMahasiswaCourses()
        RefreshEdomLockStatus()
        ApplyControlRegions()
        AturLayoutResponsif()
    End Sub

    Private Sub SetupEmptyStateLabel()
        lblTableEmpty = New Label With {
            .Visible = False,
            .Font = New Font("Segoe UI", 9.5!),
            .ForeColor = colorMuted,
            .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.White,
            .Location = New Point(21, dgvEdom.Top + 12),
            .Size = New Size(dgvEdom.Width, 90),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        }
        pnlTableCard.Controls.Add(lblTableEmpty)
        lblTableEmpty.BringToFront()
    End Sub

    Private Sub UpdateCountdownBadgeDefault()
        Dim deadline As New DateTime(2026, 12, 23)
        Dim sisaHari As Integer = (deadline - DateTime.Today).Days
        If sisaHari > 0 AndAlso sisaHari <= 90 Then
            lblCountdownBadge.Text = "Sisa " & sisaHari.ToString() & " Hari Lagi"
        ElseIf sisaHari <= 0 Then
            lblCountdownBadge.Text = "Periode Berakhir"
        Else
            lblCountdownBadge.Text = "Sisa " & sisaHari.ToString() & " Hari Lagi"
        End If
        lblCountdownBadge.BackColor = colorAmberBg
        lblCountdownBadge.ForeColor = Color.FromArgb(146, 64, 14)
        lblCountdownBadge.PerformLayout()
        UpdateCountdownBadgeRegion()
    End Sub

    Private Sub RefreshEdomLockStatus()
        Try
            edomLocked = EdomLockService.IsLocked(UserSession.StudyProgramId)
        Catch
            ' Block submission when lock state cannot be verified from DB.
            edomLocked = True
        End Try
        If edomLocked Then
            lblCountdownBadge.Text = "EDOM Dikunci Admin"
            lblCountdownBadge.BackColor = Color.FromArgb(254, 226, 226)
            lblCountdownBadge.ForeColor = Color.FromArgb(185, 28, 28)
            lblCountdownBadge.PerformLayout()
            UpdateCountdownBadgeRegion()
        Else
            UpdateCountdownBadgeDefault()
        End If
        dgvEdom.Invalidate()
    End Sub

    Private Sub ApplyControlRegions()
        btnNavDashboard.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnNavDashboard.Width, btnNavDashboard.Height), 8))
        btnLogout.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnLogout.Width, btnLogout.Height), 6))
        btnTabAll.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnTabAll.Width, btnTabAll.Height), 6))
        btnTabPending.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnTabPending.Width, btnTabPending.Height), 6))
        UpdateCountdownBadgeRegion()
    End Sub

    Private Sub UpdateCountdownBadgeRegion()
        If lblCountdownBadge IsNot Nothing AndAlso lblCountdownBadge.Width > 0 AndAlso lblCountdownBadge.Height > 0 Then
            lblCountdownBadge.Region = New Region(GetRoundedPath(New Rectangle(0, 0, lblCountdownBadge.Width, lblCountdownBadge.Height), 6))
        End If
    End Sub

    Private Sub lblCountdownBadge_SizeChanged(sender As Object, e As EventArgs) Handles lblCountdownBadge.SizeChanged
        UpdateCountdownBadgeRegion()
    End Sub

    Private Sub cboTahunAkademik_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTahunAkademik.SelectedIndexChanged
        If isInitializing Then Return
        LoadMahasiswaCourses()
    End Sub

    Private Sub LoadMahasiswaCourses()
        dgvEdom.Rows.Clear()
        Dim semester As String = If(cboTahunAkademik.SelectedItem IsNot Nothing, cboTahunAkademik.SelectedItem.ToString(), "2026/2027 Ganjil")

        Try
            Dim offerings = EdomEvaluationRepository.GetOfferingsForMahasiswa(UserSession.UserId, UserSession.StudyProgramId, semester)
            Dim no As Integer = 1
            For Each item In offerings
                Dim statusText As String = If(item.SudahTerisi, "• Sudah Terisi", "• Belum Terisi")
                Dim aksiText As String = If(item.SudahTerisi, "Selesai", "Isi Kuisioner")
                Dim rowIdx = dgvEdom.Rows.Add(no, item.DisplayMatkul, item.DosenNama, statusText, aksiText)
                dgvEdom.Rows(rowIdx).Tag = item
                no += 1
            Next

            lblKpi1Value.Text = offerings.Count.ToString() & " Matakuliah"
            btnTabAll.Text = "Semua (" & offerings.Count.ToString() & ")"

            If offerings.Count = 0 Then
                dgvEdom.Visible = False
                lblTableEmpty.Text = "Belum ada mata kuliah terdaftar untuk semester " & semester & ". Pilih semester aktif di kanan atas."
                lblTableEmpty.Visible = True
                pnlTableCard.Height = lblTableEmpty.Bottom + 24
            Else
                lblTableEmpty.Visible = False
                dgvEdom.Visible = True
                dgvEdom.Height = dgvEdom.ColumnHeadersHeight + (dgvEdom.Rows.Count * dgvEdom.RowTemplate.Height) + 4
                pnlTableCard.Height = dgvEdom.Top + dgvEdom.Height + 24
            End If

            UpdateProgressKpi()
            ApplyFilter()
        Catch ex As Exception
            dgvEdom.Visible = False
            lblKpi1Value.Text = "- Matakuliah"
            lblKpi2Value.Text = "Gagal memuat data"
            pnlProgressBarFill.Width = 0
            lblTableEmpty.Text = "Gagal memuat daftar mata kuliah dari database: " & ex.Message
            lblTableEmpty.Visible = True
            pnlTableCard.Height = lblTableEmpty.Bottom + 24
        End Try

        AturLayoutResponsif()
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
        dgvEdom.RowTemplate.Height = 52
        dgvEdom.ColumnHeadersHeight = 42

        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colNo", .HeaderText = "NO", .Width = 55,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colMatkul", .HeaderText = "MATA KULIAH",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 45.0!,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Padding = New Padding(12, 0, 10, 0)}
        })

        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colDosen", .HeaderText = "DOSEN PENGAMPU",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 35.0!,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Padding = New Padding(10, 0, 10, 0)}
        })

        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colStatus", .HeaderText = "STATUS", .Width = 145,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colAksi", .HeaderText = "AKSI", .Width = 135,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
    End Sub

    ' Render pill badge status dan tombol aksi kustom menyerupai referensi
    Private Sub dgvEdom_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvEdom.CellPainting
        If e.RowIndex < 0 Then Return

        ' Status Pill
        If e.ColumnIndex = 3 AndAlso e.Value IsNot Nothing Then
            e.PaintBackground(e.CellBounds, True)
            Dim text As String = e.Value.ToString()
            Dim pillRect As New Rectangle(e.CellBounds.X + (e.CellBounds.Width - 116) \ 2, e.CellBounds.Y + (e.CellBounds.Height - 26) \ 2, 116, 26)

            Dim isSelesai As Boolean = text.Contains("Sudah Terisi")
            Dim bgPill As Color = If(isSelesai, colorGreenBg, colorAmberBg)
            Dim txtPill As Color = If(isSelesai, colorGreen, colorAmberText)

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using path As GraphicsPath = GetRoundedPath(pillRect, 13), brBg As New SolidBrush(bgPill)
                e.Graphics.FillPath(brBg, path)
            End Using

            Using fontPill As New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold),
                  brText As New SolidBrush(txtPill),
                  sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString(text, fontPill, brText, pillRect, sf)
            End Using
            e.Handled = True
            Return
        End If

        ' Action Button Pill
        If e.ColumnIndex = 4 Then
            e.PaintBackground(e.CellBounds, True)
            Dim btnRect As New Rectangle(e.CellBounds.X + (e.CellBounds.Width - 110) \ 2, e.CellBounds.Y + (e.CellBounds.Height - 30) \ 2, 110, 30)

            Dim statusText As String = If(dgvEdom.Rows(e.RowIndex).Cells(3).Value IsNot Nothing, dgvEdom.Rows(e.RowIndex).Cells(3).Value.ToString(), "")
            Dim isSelesai As Boolean = statusText.Contains("Sudah Terisi")

            Dim btnBg As Color = If(isSelesai, Color.FromArgb(241, 245, 249), If(edomLocked, Color.FromArgb(226, 232, 240), colorNavy))
            Dim btnFore As Color = If(isSelesai, colorGreen, If(edomLocked, colorMuted, Color.White))
            Dim btnText As String = If(isSelesai, "✓ Selesai", If(edomLocked, "EDOM Dikunci", "Isi Kuisioner"))

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using path As GraphicsPath = GetRoundedPath(btnRect, 6), brBg As New SolidBrush(btnBg)
                e.Graphics.FillPath(brBg, path)
            End Using

            Using fontBtn As New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold),
                  brText As New SolidBrush(btnFore),
                  sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString(btnText, fontBtn, brText, btnRect, sf)
            End Using
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub dgvEdom_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEdom.CellClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = 4 Then
            RefreshEdomLockStatus()
            Dim row = dgvEdom.Rows(e.RowIndex)
            Dim offering = TryCast(row.Tag, CourseOfferingItem)
            If offering Is Nothing Then Return

            Dim status = If(row.Cells(3).Value IsNot Nothing, row.Cells(3).Value.ToString(), "")

            If edomLocked Then
                MessageBox.Show("Periode pengisian EDOM telah dikunci oleh admin program studi.", "EDOM Dikunci", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If status.Contains("Sudah Terisi") OrElse offering.SudahTerisi Then
                MessageBox.Show("Kuisioner untuk mata kuliah ini sudah selesai diisi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using overlay As New Form()
                overlay.StartPosition = FormStartPosition.Manual
                overlay.FormBorderStyle = FormBorderStyle.None
                overlay.Opacity = 0.5R
                overlay.BackColor = Color.FromArgb(15, 23, 42)
                overlay.ShowInTaskbar = False
                overlay.Bounds = Me.Bounds

                overlay.Show(Me)

                Using popup As New KuisionerModalForm(offering.OfferingId, offering.DisplayMatkul, offering.DosenNama)
                    If popup.ShowDialog(overlay) = DialogResult.OK Then
                        LoadMahasiswaCourses()
                    End If
                End Using

                overlay.Close()
            End Using
        End If
    End Sub

    Private Sub UpdateProgressKpi()
        Dim doneCount As Integer = 0
        Dim totalCount As Integer = dgvEdom.Rows.Count
        For Each r As DataGridViewRow In dgvEdom.Rows
            Dim s = If(r.Cells(3).Value IsNot Nothing, r.Cells(3).Value.ToString(), "")
            If s.Contains("Sudah Terisi") Then doneCount += 1
        Next

        Dim percent As Integer = If(totalCount > 0, CInt((doneCount / totalCount) * 100), 0)
        lblKpi2Value.Text = doneCount.ToString() & " / " & totalCount.ToString() & " Selesai (" & percent.ToString() & "%)"
        pnlProgressBarFill.Width = CInt((percent / 100.0!) * pnlProgressBarBg.Width)
        btnTabPending.Text = "Belum Terisi (" & (totalCount - doneCount).ToString() & ")"
    End Sub

    Private Sub pnlSidebar_Paint(sender As Object, e As PaintEventArgs) Handles pnlSidebar.Paint
        Using penBdr As New Pen(colorBorder, 1.0!)
            e.Graphics.DrawLine(penBdr, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height)
        End Using
    End Sub

    Private Sub pnlTopbar_Paint(sender As Object, e As PaintEventArgs) Handles pnlTopbar.Paint
        Using penBdr As New Pen(colorBorder, 1.0!)
            e.Graphics.DrawLine(penBdr, 0, pnlTopbar.Height - 1, pnlTopbar.Width, pnlTopbar.Height - 1)
        End Using
    End Sub

    Private Sub pnlUserCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlUserCard.Paint
        Using penBdr As New Pen(colorBorder, 1.0!)
            e.Graphics.DrawLine(penBdr, 0, 0, pnlUserCard.Width, 0)
        End Using
    End Sub

    Private Sub picSidebarLogo_Paint(sender As Object, e As PaintEventArgs) Handles picSidebarLogo.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(1, 1, picSidebarLogo.Width - 3, picSidebarLogo.Height - 3)
        Using path As GraphicsPath = GetRoundedPath(rect, 8), br As New SolidBrush(colorNavy)
            e.Graphics.FillPath(br, path)
        End Using
        Using fontLogo As New Font("Segoe UI", 13.0!, FontStyle.Bold), brWhite As New SolidBrush(Color.White)
            e.Graphics.DrawString("E", fontLogo, brWhite, rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End Using
    End Sub

    Private Sub picUserAvatar_Paint(sender As Object, e As PaintEventArgs) Handles picUserAvatar.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(1, 1, picUserAvatar.Width - 3, picUserAvatar.Height - 3)
        Using brBg As New SolidBrush(colorNavy)
            e.Graphics.FillEllipse(brBg, rect)
        End Using
        Dim initials As String = If(UserSession.IsLoggedIn, UserSession.GetInitials(), "BW")
        Using fontAvatar As New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold), brText As New SolidBrush(Color.White)
            e.Graphics.DrawString(initials, fontAvatar, brText, rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End Using
    End Sub

    Private Sub ModernCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlTableCard.Paint
        Dim pnl = CType(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 10), br As New SolidBrush(Color.White), penBdr As New Pen(colorBorder, 1.0!)
            e.Graphics.FillPath(br, path)
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    Private Sub cardTotalMatkul_Paint(sender As Object, e As PaintEventArgs) Handles cardTotalMatkul.Paint
        DrawKpiCard(cardTotalMatkul, e.Graphics, colorBlueBg, colorBlue, 1)
    End Sub

    Private Sub cardProgress_Paint(sender As Object, e As PaintEventArgs) Handles cardProgress.Paint
        DrawKpiCard(cardProgress, e.Graphics, colorAmberBg, colorAmber, 2)
    End Sub

    Private Sub cardDeadline_Paint(sender As Object, e As PaintEventArgs) Handles cardDeadline.Paint
        DrawKpiCard(cardDeadline, e.Graphics, colorGreenBg, colorGreen, 3)
    End Sub

    Private Sub DrawKpiCard(card As Panel, g As Graphics, badgeBg As Color, iconColor As Color, iconType As Integer)
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, card.Width - 1, card.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 10), br As New SolidBrush(Color.White), penBdr As New Pen(colorBorder, 1.0!)
            g.FillPath(br, path)
            g.DrawPath(penBdr, path)
        End Using

        ' Top-right rounded badge icon
        Dim badgeRect As New Rectangle(card.Width - 46, 16, 30, 30)
        Using bPath As GraphicsPath = GetRoundedPath(badgeRect, 6), bBr As New SolidBrush(badgeBg)
            g.FillPath(bBr, bPath)
        End Using

        Using penIcon As New Pen(iconColor, 1.4!)
            Select Case iconType
                Case 1 ' Document outline
                    Dim docRect As New Rectangle(badgeRect.X + 8, badgeRect.Y + 7, 13, 16)
                    g.DrawRectangle(penIcon, docRect)
                    g.DrawLine(penIcon, docRect.X + 3, docRect.Y + 4, docRect.Right - 3, docRect.Y + 4)
                    g.DrawLine(penIcon, docRect.X + 3, docRect.Y + 8, docRect.Right - 3, docRect.Y + 8)
                Case 2 ' Clipboard / Clock
                    Dim boxRect As New Rectangle(badgeRect.X + 7, badgeRect.Y + 7, 15, 16)
                    g.DrawRectangle(penIcon, boxRect)
                    g.DrawArc(penIcon, badgeRect.X + 11, badgeRect.Y + 4, 7, 5, 180, 180)
                Case 3 ' Calendar with checkmark
                    Dim calRect As New Rectangle(badgeRect.X + 7, badgeRect.Y + 9, 16, 13)
                    Using path As GraphicsPath = GetRoundedPath(calRect, 2)
                        g.DrawPath(penIcon, path)
                    End Using
                    g.DrawLine(penIcon, calRect.X, calRect.Y + 4, calRect.Right, calRect.Y + 4)
                    g.DrawLine(penIcon, calRect.X + 4, calRect.Y - 2, calRect.X + 4, calRect.Y)
                    g.DrawLine(penIcon, calRect.Right - 4, calRect.Y - 2, calRect.Right - 4, calRect.Y)
                    Dim pts() As Point = {New Point(calRect.X + 4, calRect.Y + 8), New Point(calRect.X + 7, calRect.Y + 11), New Point(calRect.Right - 4, calRect.Y + 6)}
                    g.DrawLines(penIcon, pts)
            End Select
        End Using
    End Sub

    Private Sub pnlAlert_Paint(sender As Object, e As PaintEventArgs) Handles pnlAlert.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlAlert.Width - 1, pnlAlert.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 8), br As New SolidBrush(Color.FromArgb(239, 246, 255)), penBdr As New Pen(Color.FromArgb(191, 219, 254), 1.0!)
            e.Graphics.FillPath(br, path)
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    Private Sub pnlSearchBox_Paint(sender As Object, e As PaintEventArgs) Handles pnlSearchBox.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlSearchBox.Width - 1, pnlSearchBox.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 14), br As New SolidBrush(Color.FromArgb(248, 250, 252)), penBdr As New Pen(colorBorder, 1.0!)
            e.Graphics.FillPath(br, path)
            e.Graphics.DrawPath(penBdr, path)
        End Using

        ' Search magnifying glass glyph
        Using penIcon As New Pen(colorMuted, 1.4!)
            e.Graphics.DrawEllipse(penIcon, 12, 11, 9, 9)
            e.Graphics.DrawLine(penIcon, 19, 18, 24, 23)
        End Using
    End Sub

    ' Filter Tab buttons
    Private Sub btnTabAll_Click(sender As Object, e As EventArgs) Handles btnTabAll.Click
        currentTab = "ALL"
        btnTabAll.BackColor = colorNavy
        btnTabAll.ForeColor = Color.White
        btnTabPending.BackColor = Color.FromArgb(241, 245, 249)
        btnTabPending.ForeColor = colorMuted
        ApplyFilter()
    End Sub

    Private Sub btnTabPending_Click(sender As Object, e As EventArgs) Handles btnTabPending.Click
        currentTab = "PENDING"
        btnTabPending.BackColor = colorNavy
        btnTabPending.ForeColor = Color.White
        btnTabAll.BackColor = Color.FromArgb(241, 245, 249)
        btnTabAll.ForeColor = colorMuted
        ApplyFilter()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        dgvEdom.CurrentCell = Nothing
        Dim q As String = txtSearch.Text.Trim().ToLower()
        For Each row As DataGridViewRow In dgvEdom.Rows
            Dim matkul As String = If(row.Cells(1).Value IsNot Nothing, row.Cells(1).Value.ToString().ToLower(), "")
            Dim dosen As String = If(row.Cells(2).Value IsNot Nothing, row.Cells(2).Value.ToString().ToLower(), "")
            Dim status As String = If(row.Cells(3).Value IsNot Nothing, row.Cells(3).Value.ToString(), "")
            Dim matchText As Boolean = String.IsNullOrEmpty(q) OrElse matkul.Contains(q) OrElse dosen.Contains(q)
            Dim matchTab As Boolean = (currentTab = "ALL") OrElse (currentTab = "PENDING" AndAlso status.Contains("Belum Terisi"))
            row.Visible = matchText AndAlso matchTab
        Next
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar dari sistem?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If konfirmasi = DialogResult.Yes Then
            UserSession.Clear()
            Dim login As New LoginForm()
            login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Application.OpenForms.OfType(Of LoginForm)().Count = 0 AndAlso
           Application.OpenForms.OfType(Of DosenDashboardForm)().Count = 0 AndAlso
           Application.OpenForms.OfType(Of AdminDashboardForm)().Count = 0 Then
            Application.Exit()
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize, pnlScrollBody.Resize
        AturLayoutResponsif()
    End Sub

    Private Sub AturLayoutResponsif()
        If pnlContent Is Nothing OrElse pnlScrollBody Is Nothing Then Return
        Dim w As Integer = Math.Max(840, pnlScrollBody.ClientSize.Width - 64)
        pnlContent.Left = 32
        pnlContent.Width = w

        Dim cardSpacing As Integer = 16
        Dim cardHeight As Integer = 130
        Dim cardWidth As Integer = (w - (cardSpacing * 2)) \ 3

        cardTotalMatkul.SetBounds(0, 0, cardWidth, cardHeight)
        cardProgress.SetBounds(cardTotalMatkul.Right + cardSpacing, 0, cardWidth, cardHeight)
        cardDeadline.SetBounds(cardProgress.Right + cardSpacing, 0, cardWidth, cardHeight)
        pnlKpiRow.Height = cardHeight + 4
        pnlKpiRow.Width = w

        pnlProgressBarBg.Width = Math.Max(120, cardWidth - 40)

        pnlAlert.Width = w
        lblAlertText.Width = w - 40

        pnlTableCard.Width = w
        dgvEdom.Width = w - 42
        If lblTableEmpty IsNot Nothing Then lblTableEmpty.Width = w - 42
        lblTablePeriode.Left = w - lblTablePeriode.Width - 21
        pnlContent.Height = pnlTableCard.Bottom + 32
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
