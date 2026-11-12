Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Windows.Forms

Public Class DosenDashboardForm

    Private ReadOnly colorNavy As Color = Color.FromArgb(10, 37, 88)
    Private ReadOnly colorNavyHover As Color = Color.FromArgb(14, 48, 112)
    Private ReadOnly colorBorder As Color = Color.FromArgb(226, 232, 240)
    Private ReadOnly colorMuted As Color = Color.FromArgb(100, 116, 139)
    Private ReadOnly colorDark As Color = Color.FromArgb(15, 23, 42)

    Private ReadOnly colorGreen As Color = Color.FromArgb(5, 150, 105)
    Private ReadOnly colorGreenBg As Color = Color.FromArgb(236, 253, 245)
    Private ReadOnly colorAmber As Color = Color.FromArgb(217, 119, 6)
    Private ReadOnly colorAmberBg As Color = Color.FromArgb(254, 243, 199)
    Private ReadOnly colorBlue As Color = Color.FromArgb(37, 99, 235)
    Private ReadOnly colorBlueBg As Color = Color.FromArgb(239, 246, 255)

    Private Sub DosenDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UserSession.IsLoggedIn Then
            lblSidebarUserName.Text = UserSession.GetNamaLengkapGelar()
            lblSidebarUserRole.Text = "Dosen • NIDN: " & If(String.IsNullOrWhiteSpace(UserSession.NIDN), "-", UserSession.NIDN)
            lblBadgeProdi.Text = "Homebase: " & If(String.IsNullOrWhiteSpace(UserSession.NamaProdi), "Teknik Informatika", UserSession.NamaProdi) & " (" & UserSession.ProdiCode & ")"
        End If

        ApplyControlRegions()
        SetupDataGridView()
        LoadDataMatkulDosen()
        AturLayoutResponsif()
    End Sub

    Private Sub ApplyControlRegions()
        btnNavDashboard.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnNavDashboard.Width, btnNavDashboard.Height), 8))
        btnLogout.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnLogout.Width, btnLogout.Height), 6))
        lblBadgeProdi.Region = New Region(GetRoundedPath(New Rectangle(0, 0, lblBadgeProdi.Width, lblBadgeProdi.Height), 8))
        lblKpi2Badge.Region = New Region(GetRoundedPath(New Rectangle(0, 0, lblKpi2Badge.Width, lblKpi2Badge.Height), 8))
    End Sub

    Private Sub SetupDataGridView()
        dgvMatkul.Columns.Clear()
        dgvMatkul.AutoGenerateColumns = False
        dgvMatkul.RowHeadersVisible = False
        dgvMatkul.AllowUserToResizeRows = False
        dgvMatkul.AllowUserToResizeColumns = False
        dgvMatkul.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMatkul.MultiSelect = False
        dgvMatkul.BackgroundColor = Color.White
        dgvMatkul.BorderStyle = BorderStyle.None
        dgvMatkul.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvMatkul.GridColor = Color.FromArgb(241, 245, 249)
        dgvMatkul.RowTemplate.Height = 50
        dgvMatkul.ColumnHeadersHeight = 42

        dgvMatkul.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colNo", .HeaderText = "NO", .Width = 50,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
        dgvMatkul.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colKode", .HeaderText = "KODE MK", .Width = 100,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
        dgvMatkul.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colMatkul", .HeaderText = "MATA KULIAH",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 40.0!,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Padding = New Padding(10, 0, 10, 0)}
        })
        dgvMatkul.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colKelas", .HeaderText = "KELAS", .Width = 75,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
        dgvMatkul.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colSks", .HeaderText = "SKS", .Width = 60,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
        dgvMatkul.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colResponden", .HeaderText = "RESPONDEN", .Width = 130,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
        dgvMatkul.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colSkorFuzzy", .HeaderText = "SKOR FUZZY", .Width = 110,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
        dgvMatkul.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colKategoriFuzzy", .HeaderText = "PREDIKAT AI", .Width = 145,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
    End Sub

    Private Sub LoadDataMatkulDosen()
        dgvMatkul.Rows.Clear()
        ' Data mata kuliah yang diampu oleh dosen yang login (dapat disinkronkan dengan database/backend AI)
        Dim data = {
            New Object() {1, "TIK302", "Manajemen Proyek TIK", "TI-3C", "3 SKS", "23 / 25 Mahasiswa", "89.20", "SANGAT BAIK"},
            New Object() {2, "TIK302", "Manajemen Proyek TIK", "TI-3D", "3 SKS", "22 / 24 Mahasiswa", "85.80", "SANGAT BAIK"},
            New Object() {3, "TIK301", "Pemrograman Visual", "TI-3A", "3 SKS", "24 / 24 Mahasiswa", "87.40", "SANGAT BAIK"},
            New Object() {4, "TIK304", "Kecerdasan Buatan (AI)", "TI-3B", "3 SKS", "21 / 25 Mahasiswa", "86.10", "SANGAT BAIK"}
        }

        For Each row In data
            dgvMatkul.Rows.Add(row)
        Next

        ' Sesuaikan tinggi DataGridView dengan jumlah baris
        dgvMatkul.Height = dgvMatkul.ColumnHeadersHeight + (dgvMatkul.Rows.Count * dgvMatkul.RowTemplate.Height) + 4
        pnlTableCard.Height = dgvMatkul.Top + dgvMatkul.Height + 24
    End Sub

    ' Render Pill Badge khusus untuk Status & Predikat Fuzzy
    Private Sub dgvMatkul_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvMatkul.CellPainting
        If e.RowIndex < 0 Then Return

        ' Kolom Predikat AI (Index 7)
        If e.ColumnIndex = 7 AndAlso e.Value IsNot Nothing Then
            e.PaintBackground(e.CellBounds, True)
            Dim text As String = e.Value.ToString()
            Dim isSangatBaik As Boolean = text.ToUpper().Contains("SANGAT BAIK")
            Dim bgCol As Color = If(isSangatBaik, colorGreenBg, colorAmberBg)
            Dim txtCol As Color = If(isSangatBaik, colorGreen, colorAmber)

            Dim pillRect As New Rectangle(e.CellBounds.X + (e.CellBounds.Width - 120) \ 2, e.CellBounds.Y + (e.CellBounds.Height - 26) \ 2, 120, 26)

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using path As GraphicsPath = GetRoundedPath(pillRect, 13), brBg As New SolidBrush(bgCol)
                e.Graphics.FillPath(brBg, path)
            End Using

            Using fontPill As New Font("Segoe UI Semibold", 8.25!, FontStyle.Bold),
                  brText As New SolidBrush(txtCol),
                  sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString(text, fontPill, brText, pillRect, sf)
            End Using
            e.Handled = True
            Return
        End If

        ' Kolom Skor Fuzzy (Index 6)
        If e.ColumnIndex = 6 AndAlso e.Value IsNot Nothing Then
            e.PaintBackground(e.CellBounds, True)
            Dim text As String = e.Value.ToString()
            Using fontSkor As New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold),
                  brText As New SolidBrush(colorNavy),
                  sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString(text, fontSkor, brText, e.CellBounds, sf)
            End Using
            e.Handled = True
            Return
        End If
    End Sub

    ' Event Paint Borders & Card Styling
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
        Dim initials As String = If(UserSession.IsLoggedIn, UserSession.GetInitials(), "DS")
        Using fontAvatar As New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold), brText As New SolidBrush(Color.White)
            e.Graphics.DrawString(initials, fontAvatar, brText, rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End Using
    End Sub

    Private Sub ModernCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlTableCard.Paint, cardSkor.Paint, cardKategori.Paint, cardResponden.Paint
        Dim pnl = CType(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 10), br As New SolidBrush(Color.White), penBdr As New Pen(colorBorder, 1.0!)
            e.Graphics.FillPath(br, path)
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    Private Sub pnlAiBanner_Paint(sender As Object, e As PaintEventArgs) Handles pnlAiBanner.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlAiBanner.Width - 1, pnlAiBanner.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 10), br As New SolidBrush(colorBlueBg), penBdr As New Pen(Color.FromArgb(191, 219, 254), 1.0!)
            e.Graphics.FillPath(br, path)
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    ' Responsive Layout
    Private Sub DosenDashboardForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize, pnlScrollBody.Resize
        AturLayoutResponsif()
    End Sub

    Private Sub AturLayoutResponsif()
        If pnlContent Is Nothing OrElse pnlScrollBody Is Nothing Then Return
        Dim w As Integer = Math.Max(860, pnlScrollBody.ClientSize.Width - 64)
        pnlContent.Left = 32
        pnlContent.Width = w

        pnlAiBanner.Width = w
        lblAiDesc.Width = w - 36
        pnlKpiRow.Width = w

        Dim cardW As Integer = (w - 32) \ 3
        cardSkor.Width = cardW
        cardKategori.Width = cardW
        cardKategori.Left = cardW + 16
        cardResponden.Width = cardW
        cardResponden.Left = (cardW * 2) + 32

        pnlTableCard.Width = w
        dgvMatkul.Width = w - 40
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

    Private Sub DosenDashboardForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Application.OpenForms.OfType(Of LoginForm)().Count = 0 AndAlso
           Application.OpenForms.OfType(Of Form1)().Count = 0 AndAlso
           Application.OpenForms.OfType(Of AdminDashboardForm)().Count = 0 Then
            Application.Exit()
        End If
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
