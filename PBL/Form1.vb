Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class Form1

    ' Design System Palette
    Private ReadOnly primaryBlue As Color = Color.FromArgb(30, 58, 138)       ' #1E3A8A
    Private ReadOnly tertiaryCyan As Color = Color.FromArgb(2, 132, 199)      ' #0284C7
    Private ReadOnly cardBorderColor As Color = Color.FromArgb(226, 232, 240) ' #E2E8F0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Dropdown Tahun Akademik
        cboTahunAkademik.Items.AddRange(New Object() {"2026/2027 Ganjil", "2025/2026 Genap", "2025/2026 Ganjil"})
        cboTahunAkademik.SelectedIndex = 0

        ' Setup DataGridView
        SetupDataGridView()

        ' Static Data 10 Mata Kuliah EDOM Kelas 3C
        Dim data = {
            New Object() {1, "TIK309 - Grafika Komputer (3C)", "ANGGI MARDIYONO", "• Belum Terisi"},
            New Object() {2, "TIK308 - Analisis dan Desain Sistem Informasi (3C)", "ANITA HIDAYATI", "• Belum Terisi"},
            New Object() {3, "TIK306 - Pemrograman Web Lanjut (3C)", "ASEP TAUFIK MUHARRAM", "• Belum Terisi"},
            New Object() {4, "TIK302 - Manajemen Proyek TIK (3C)", "BAMBANG WARSUTA", "• Belum Terisi"},
            New Object() {5, "TIK301 - Pemrograman Visual (3C)", "CHAIRUL FIKRI", "• Belum Terisi"},
            New Object() {6, "TIK310 - Sistem Terdistribusi (3C)", "DEFIANA ARNALDY", "• Belum Terisi"},
            New Object() {7, "TIK305 - Metode Numerik (3C)", "FAJAR SEPTIAN", "• Belum Terisi"},
            New Object() {8, "TIK303 - Desain UI/UX (3C)", "IWAN SONJAYA", "• Belum Terisi"},
            New Object() {9, "TIK307 - Pemrograman Basis Data (3C)", "RISNA SARI", "• Belum Terisi"},
            New Object() {10, "TIK304 - Kecerdasan Buatan (3C)", "RIZKI ELISA NALAWATI", "• Belum Terisi"}
        }
        For Each row In data
            dgvEdom.Rows.Add(row)
        Next

        ' Sesuaikan tinggi DataGridView & Container
        dgvEdom.Height = dgvEdom.ColumnHeadersHeight + (dgvEdom.Rows.Count * dgvEdom.RowTemplate.Height) + 10
        pnlTableCard.Height = dgvEdom.Top + dgvEdom.Height + 25

        ' Static KPI Cards
        lblKpi1Value.Text = "10 Matakuliah"
        lblKpi2Value.Text = "0 / 10 Selesai (0%)"
        pnlProgressBarFill.Width = 0

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
        dgvEdom.ColumnHeadersHeight = 44

        ' 1. NO
        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colNo", .HeaderText = "NO", .Width = 55,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        ' 2. MATAKULIAH
        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colMatkul", .HeaderText = "MATA KULIAH",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 45.0!,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Padding = New Padding(12, 0, 10, 0)}
        })

        ' 3. DOSEN PENGAMPU
        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colDosen", .HeaderText = "DOSEN PENGAMPU",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 35.0!,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Padding = New Padding(10, 0, 10, 0)}
        })

        ' 4. STATUS (Pill / Text)
        dgvEdom.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "colStatus", .HeaderText = "STATUS", .Width = 140,
            .DefaultCellStyle = New DataGridViewCellStyle With {
                .Alignment = DataGridViewContentAlignment.MiddleCenter,
                .ForeColor = Color.FromArgb(220, 38, 38),
                .Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
            }
        })

        ' 5. AKSI (Native Flat Button)
        Dim colAksi As New DataGridViewButtonColumn With {
            .Name = "colAksi", .HeaderText = "AKSI", .Width = 140,
            .FlatStyle = FlatStyle.Flat, .Text = "Isi Kuisioner", .UseColumnTextForButtonValue = True
        }
        colAksi.DefaultCellStyle.BackColor = primaryBlue
        colAksi.DefaultCellStyle.ForeColor = Color.White
        colAksi.DefaultCellStyle.SelectionBackColor = primaryBlue
        colAksi.DefaultCellStyle.SelectionForeColor = Color.White
        colAksi.DefaultCellStyle.Padding = New Padding(10, 8, 10, 8)
        dgvEdom.Columns.Add(colAksi)
    End Sub

    ' Real-time search filter menggunakan native row visibility
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim q As String = txtSearch.Text.Trim().ToLower()
        For Each row As DataGridViewRow In dgvEdom.Rows
            Dim matkul As String = If(row.Cells(1).Value IsNot Nothing, row.Cells(1).Value.ToString().ToLower(), "")
            Dim dosen As String = If(row.Cells(2).Value IsNot Nothing, row.Cells(2).Value.ToString().ToLower(), "")
            row.Visible = String.IsNullOrEmpty(q) OrElse matkul.Contains(q) OrElse dosen.Contains(q)
        Next
    End Sub

    ' Logout kembali ke Login Form
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Close()
    End Sub

    ' =========================================================================
    ' MODERN UI COSMETICS: LOGO, AVATAR, & ROUNDED CARD BORDERS
    ' =========================================================================
    Private Sub picSidebarLogo_Paint(sender As Object, e As PaintEventArgs) Handles picSidebarLogo.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(2, 2, picSidebarLogo.Width - 5, picSidebarLogo.Height - 5)
        Using path As GraphicsPath = GetRoundedPath(rect, 12)
            Using br As New LinearGradientBrush(rect, primaryBlue, tertiaryCyan, 45.0!)
                e.Graphics.FillPath(br, path)
            End Using
        End Using
        Using fontLogo As New Font("Segoe UI", 16.0!, FontStyle.Bold), brWhite As New SolidBrush(Color.White)
            e.Graphics.DrawString("E", fontLogo, brWhite, rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End Using
    End Sub

    Private Sub picUserAvatar_Paint(sender As Object, e As PaintEventArgs) Handles picUserAvatar.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(1, 1, picUserAvatar.Width - 3, picUserAvatar.Height - 3)
        Using brBg As New SolidBrush(primaryBlue)
            e.Graphics.FillEllipse(brBg, rect)
        End Using
        Using fontAvatar As New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold), brText As New SolidBrush(Color.White)
            e.Graphics.DrawString("BW", fontAvatar, brText, rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End Using
    End Sub

    Private Sub ModernCard_Paint(sender As Object, e As PaintEventArgs) Handles cardTotalMatkul.Paint, cardProgress.Paint, cardDeadline.Paint, pnlTableCard.Paint
        Dim pnl = CType(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 10), br As New SolidBrush(Color.White), penBdr As New Pen(cardBorderColor, 1.0!)
            e.Graphics.FillPath(br, path)
            e.Graphics.DrawPath(penBdr, path)
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
        Using path As GraphicsPath = GetRoundedPath(rect, 16), br As New SolidBrush(Color.FromArgb(248, 250, 252)), penBdr As New Pen(cardBorderColor, 1.0!)
            e.Graphics.FillPath(br, path)
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    Private Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2
        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' Layout Responsif Lebar Penuh
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize, pnlScrollBody.Resize
        AturLayoutResponsif()
    End Sub

    Private Sub AturLayoutResponsif()
        If pnlContent Is Nothing OrElse pnlScrollBody Is Nothing Then Return
        Dim w As Integer = Math.Max(860, pnlScrollBody.ClientSize.Width - 64)
        pnlContent.Left = 32
        pnlContent.Width = w

        Dim cardWidth As Integer = (w - 32) \ 3
        cardTotalMatkul.SetBounds(0, 0, cardWidth, cardTotalMatkul.Height)
        cardProgress.SetBounds(cardTotalMatkul.Right + 16, 0, cardWidth, cardProgress.Height)
        cardDeadline.SetBounds(cardProgress.Right + 16, 0, cardWidth, cardDeadline.Height)
        pnlKpiRow.Width = w

        pnlAlert.Width = w
        lblAlertText.Width = w - 65

        pnlTableCard.Width = w
        dgvEdom.Width = w - 42
        lblTablePeriode.Left = w - lblTablePeriode.Width - 24
        pnlContent.Height = pnlTableCard.Bottom + 35
    End Sub

End Class
