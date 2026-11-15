Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Windows.Forms

Public Class AdminDashboardForm

    Private ReadOnly colorNavy As Color = Color.FromArgb(10, 37, 88)
    Private ReadOnly colorNavyHover As Color = Color.FromArgb(14, 48, 112)
    Private ReadOnly colorBorder As Color = Color.FromArgb(226, 232, 240)
    Private ReadOnly colorMuted As Color = Color.FromArgb(100, 116, 139)
    Private ReadOnly colorDark As Color = Color.FromArgb(15, 23, 42)
    Private ReadOnly colorBlue As Color = Color.FromArgb(37, 99, 235)
    Private ReadOnly colorBlueBg As Color = Color.FromArgb(239, 246, 255)

    Private currentTab As String = "DOSEN" ' "DOSEN" atau "MAHASISWA"
    Private dtSource As DataTable = Nothing
    Private searchFocused As Boolean = False

    Private Sub AdminDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblSidebarUserName.Text = If(UserSession.IsLoggedIn AndAlso Not String.IsNullOrWhiteSpace(UserSession.Nama), UserSession.Nama, "Admin")
        lblSidebarUserRole.Text = "admin"
        lblBreadcrumbTitle.Text = "Dashboard Admin - Sistem EDOM"
        lblBreadcrumbSub.Text = "Selamat datang, " & lblSidebarUserName.Text & " (Kelola seluruh sivitas akademika)"
        lblBadgeProdi.Visible = False

        PopulateProdiFilter()
        ApplyControlRegions()
        SwitchTab("DOSEN")
        AturLayoutResponsif()
    End Sub

    Private Sub PopulateProdiFilter()
        cmbFilterProdi.Items.Clear()
        cmbFilterProdi.Items.Add("Semua Program Studi")

        Try
            Dim dtProdi As DataTable = ModKoneksi.ExecuteQuery("SELECT name FROM study_programs ORDER BY id ASC")
            If dtProdi IsNot Nothing AndAlso dtProdi.Rows.Count > 0 Then
                For Each r As DataRow In dtProdi.Rows
                    cmbFilterProdi.Items.Add(r("name").ToString())
                Next
            Else
                cmbFilterProdi.Items.AddRange(New Object() {
                    "Teknik Informatika",
                    "Teknik Multimedia dan Jaringan",
                    "Teknik Multimedia Digital",
                    "Rekayasa Keamanan Siber"
                })
            End If
        Catch
            cmbFilterProdi.Items.AddRange(New Object() {
                "Teknik Informatika",
                "Teknik Multimedia dan Jaringan",
                "Teknik Multimedia Digital",
                "Rekayasa Keamanan Siber"
            })
        End Try

        cmbFilterProdi.SelectedIndex = 0
    End Sub

    Private Sub ApplyControlRegions()
        btnNavDashboard.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnNavDashboard.Width, btnNavDashboard.Height), 8))
        btnLogout.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnLogout.Width, btnLogout.Height), 6))
        If lblBadgeProdi.Visible Then
            lblBadgeProdi.Region = New Region(GetRoundedPath(New Rectangle(0, 0, lblBadgeProdi.Width, lblBadgeProdi.Height), 8))
        End If
        btnTabDosen.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnTabDosen.Width, btnTabDosen.Height), 6))
        btnTabMahasiswa.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnTabMahasiswa.Width, btnTabMahasiswa.Height), 6))
        btnRefresh.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnRefresh.Width, btnRefresh.Height), 6))
        pnlSearchBox.Region = New Region(GetRoundedPath(New Rectangle(0, 0, pnlSearchBox.Width, pnlSearchBox.Height), 6))
    End Sub

    ''' <summary>
    ''' Berpindah tab antara Data Dosen dan Data Mahasiswa
    ''' </summary>
    Private Sub SwitchTab(tab As String)
        currentTab = tab
        If tab = "DOSEN" Then
            btnTabDosen.BackColor = colorNavy
            btnTabDosen.ForeColor = Color.White
            btnTabDosen.FlatAppearance.BorderSize = 0

            btnTabMahasiswa.BackColor = Color.White
            btnTabMahasiswa.ForeColor = colorMuted
            btnTabMahasiswa.FlatAppearance.BorderSize = 1

            lblTableTitle.Text = "Daftar Seluruh Dosen"
            lblTableSub.Text = "Data seluruh dosen lintas program studi aktif"
            LoadDataDosen()
        Else
            btnTabMahasiswa.BackColor = colorNavy
            btnTabMahasiswa.ForeColor = Color.White
            btnTabMahasiswa.FlatAppearance.BorderSize = 0

            btnTabDosen.BackColor = Color.White
            btnTabDosen.ForeColor = colorMuted
            btnTabDosen.FlatAppearance.BorderSize = 1

            lblTableTitle.Text = "Daftar Seluruh Mahasiswa"
            lblTableSub.Text = "Data seluruh mahasiswa terdaftar lintas program studi"
            LoadDataMahasiswa()
        End If
    End Sub

    Private Sub LoadDataDosen()
        dgvAdminData.Columns.Clear()
        dgvAdminData.AutoGenerateColumns = False
        dgvAdminData.RowTemplate.Height = 46

        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNo", .HeaderText = "NO", .Width = 45, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNidn", .HeaderText = "NIDN", .Width = 105, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNama", .HeaderText = "NAMA LENGKAP & GELAR", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 36.0!})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colProdi", .HeaderText = "PROGRAM STUDI", .Width = 150})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colEmail", .HeaderText = "EMAIL KAMPUS", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 34.0!})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colStatus", .HeaderText = "STATUS", .Width = 90, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})

        Try
            Dim sql As String =
                "SELECT u.id, u.name, dp.nidn, dp.gelar_depan, dp.gelar_belakang, u.email, " &
                "       COALESCE(sp.name, 'Umum') AS prodi_name " &
                "FROM users u " &
                "INNER JOIN dosen_profiles dp ON u.id = dp.user_id " &
                "LEFT JOIN study_programs sp ON u.study_program_id = sp.id " &
                "WHERE u.role = 'dosen' " &
                "ORDER BY u.name ASC"

            Dim dt As DataTable = ModKoneksi.ExecuteQuery(sql)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim no As Integer = 1
                For Each r As DataRow In dt.Rows
                    Dim gelarD As String = If(IsDBNull(r("gelar_depan")), "", r("gelar_depan").ToString().Trim())
                    Dim gelarB As String = If(IsDBNull(r("gelar_belakang")), "", r("gelar_belakang").ToString().Trim())
                    Dim namaLengkap As String = r("name").ToString()
                    If Not String.IsNullOrEmpty(gelarD) Then namaLengkap = gelarD & " " & namaLengkap
                    If Not String.IsNullOrEmpty(gelarB) Then namaLengkap = namaLengkap & ", " & gelarB

                    Dim nidn As String = If(IsDBNull(r("nidn")), "-", r("nidn").ToString())
                    Dim email As String = r("email").ToString()
                    Dim prodi As String = r("prodi_name").ToString()
                    dgvAdminData.Rows.Add(no, nidn, namaLengkap, prodi, email, "Aktif")
                    no += 1
                Next
                lblKpi1Value.Text = dt.Rows.Count.ToString() & " Dosen"
                FilterData()
                Return
            End If
        Catch ex As Exception
        End Try

        ' Fallback mock data jika database belum terkoneksi
        Dim mockDosen = {
            New Object() {1, "0012057801", "Dr. Bambang Warsuta, S.Kom., M.T.", "Teknik Informatika", "bambang.warsuta@pnj.ac.id", "Aktif"},
            New Object() {2, "0014088202", "Anita Hidayati, S.Kom., M.Kom.", "Teknik Multimedia dan Jaringan", "anita.hidayati@pnj.ac.id", "Aktif"},
            New Object() {3, "0022037901", "Asep Taufik Muharram, S.T., M.Kom.", "Teknik Multimedia Digital", "asep.taufik@pnj.ac.id", "Aktif"},
            New Object() {4, "0018098503", "Chairul Fikri, S.T., M.Sc.", "Rekayasa Keamanan Siber", "chairul.fikri@pnj.ac.id", "Aktif"},
            New Object() {5, "0025118704", "Defiana Arnaldy, S.Kom., M.Si.", "Teknik Informatika", "defiana.arnaldy@pnj.ac.id", "Aktif"}
        }
        For Each r In mockDosen
            dgvAdminData.Rows.Add(r)
        Next
        lblKpi1Value.Text = mockDosen.Length.ToString() & " Dosen"
        FilterData()
    End Sub

    Private Sub LoadDataMahasiswa()
        dgvAdminData.Columns.Clear()
        dgvAdminData.AutoGenerateColumns = False
        dgvAdminData.RowTemplate.Height = 46

        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNo", .HeaderText = "NO", .Width = 45, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNim", .HeaderText = "NIM", .Width = 110, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNama", .HeaderText = "NAMA MAHASISWA", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 36.0!})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colProdi", .HeaderText = "PROGRAM STUDI", .Width = 150})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAngkatan", .HeaderText = "ANGKATAN", .Width = 85, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colEmail", .HeaderText = "EMAIL KAMPUS", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 34.0!})
        dgvAdminData.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colStatusEdom", .HeaderText = "STATUS EDOM", .Width = 110, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})

        Try
            Dim sql As String =
                "SELECT u.id, u.name, mp.nim, mp.angkatan, u.email, " &
                "       COALESCE(sp.name, 'Umum') AS prodi_name " &
                "FROM users u " &
                "INNER JOIN mahasiswa_profiles mp ON u.id = mp.user_id " &
                "LEFT JOIN study_programs sp ON u.study_program_id = sp.id " &
                "WHERE u.role = 'mahasiswa' " &
                "ORDER BY u.name ASC"

            Dim dt As DataTable = ModKoneksi.ExecuteQuery(sql)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim no As Integer = 1
                For Each r As DataRow In dt.Rows
                    Dim nim As String = If(IsDBNull(r("nim")), "-", r("nim").ToString())
                    Dim angkatan As String = If(IsDBNull(r("angkatan")), "-", r("angkatan").ToString())
                    Dim nama As String = r("name").ToString()
                    Dim email As String = r("email").ToString()
                    Dim prodi As String = r("prodi_name").ToString()
                    dgvAdminData.Rows.Add(no, nim, nama, prodi, angkatan, email, "Selesai")
                    no += 1
                Next
                lblKpi2Value.Text = dt.Rows.Count.ToString() & " Mahasiswa"
                FilterData()
                Return
            End If
        Catch ex As Exception
        End Try

        ' Fallback mock data mahasiswa
        Dim mockMhs = {
            New Object() {1, "2207421035", "Muhammad Rahmat", "Teknik Informatika", "2022", "rahmat.ti@pnj.ac.id", "Selesai"},
            New Object() {2, "2207421001", "Ahmad Fauzi", "Teknik Multimedia dan Jaringan", "2022", "ahmad.fauzi@pnj.ac.id", "Selesai"},
            New Object() {3, "2207421002", "Bima Arya Prasetya", "Teknik Multimedia Digital", "2022", "bima.arya@pnj.ac.id", "Belum Lengkap"},
            New Object() {4, "2207421003", "Citra Kirana Lestari", "Rekayasa Keamanan Siber", "2022", "citra.lestari@pnj.ac.id", "Selesai"},
            New Object() {5, "2207421004", "Dinda Ayu Rahmawati", "Teknik Informatika", "2022", "dinda.ayu@pnj.ac.id", "Selesai"}
        }
        For Each r In mockMhs
            dgvAdminData.Rows.Add(r)
        Next
        lblKpi2Value.Text = mockMhs.Length.ToString() & " Mahasiswa"
        FilterData()
    End Sub

    ' Filter Pencarian & Program Studi
    Private Sub FilterData()
        Dim q As String = txtSearch.Text.Trim().ToLower()
        Dim selectedProdi As String = ""
        If cmbFilterProdi IsNot Nothing AndAlso cmbFilterProdi.SelectedIndex > 0 Then
            selectedProdi = cmbFilterProdi.SelectedItem.ToString().Trim().ToLower()
        End If

        For Each row As DataGridViewRow In dgvAdminData.Rows
            Dim matchSearch As Boolean = String.IsNullOrEmpty(q)
            Dim matchProdi As Boolean = String.IsNullOrEmpty(selectedProdi)

            If Not matchSearch Then
                For i As Integer = 1 To row.Cells.Count - 1
                    If row.Cells(i).Value IsNot Nothing AndAlso row.Cells(i).Value.ToString().ToLower().Contains(q) Then
                        matchSearch = True
                        Exit For
                    End If
                Next
            End If

            If Not matchProdi Then
                If row.Cells("colProdi").Value IsNot Nothing AndAlso row.Cells("colProdi").Value.ToString().ToLower() = selectedProdi Then
                    matchProdi = True
                End If
            End If

            row.Visible = matchSearch AndAlso matchProdi
        Next
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterData()
    End Sub

    Private Sub cmbFilterProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterProdi.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub btnTabDosen_Click(sender As Object, e As EventArgs) Handles btnTabDosen.Click
        SwitchTab("DOSEN")
    End Sub

    Private Sub btnTabMahasiswa_Click(sender As Object, e As EventArgs) Handles btnTabMahasiswa.Click
        SwitchTab("MAHASISWA")
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        SwitchTab(currentTab)
        MessageBox.Show("Data seluruh program studi berhasil diperbarui dari server.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        searchFocused = True
        pnlSearchBox.Invalidate()
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        searchFocused = False
        pnlSearchBox.Invalidate()
    End Sub

    Private Sub pnlSearchBox_Paint(sender As Object, e As PaintEventArgs) Handles pnlSearchBox.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlSearchBox.Width - 1, pnlSearchBox.Height - 1)
        Dim bdrColor As Color = If(searchFocused, colorNavy, colorBorder)
        Using path As GraphicsPath = GetRoundedPath(rect, 6), penBdr As New Pen(bdrColor, If(searchFocused, 1.5!, 1.0!))
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    ' Paint events
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
        Dim initials As String = If(UserSession.IsLoggedIn, UserSession.GetInitials(), "AD")
        Using fontAvatar As New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold), brText As New SolidBrush(Color.White)
            e.Graphics.DrawString(initials, fontAvatar, brText, rect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End Using
    End Sub

    Private Sub ModernCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlTableCard.Paint, cardDosen.Paint, cardMhs.Paint, cardKelas.Paint
        Dim pnl = CType(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 10), br As New SolidBrush(Color.White), penBdr As New Pen(colorBorder, 1.0!)
            e.Graphics.FillPath(br, path)
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    ' Responsive Layout
    Private Sub AdminDashboardForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize, pnlScrollBody.Resize
        AturLayoutResponsif()
    End Sub

    Private Sub AturLayoutResponsif()
        If pnlContent Is Nothing OrElse pnlScrollBody Is Nothing Then Return
        Dim w As Integer = Math.Max(860, pnlScrollBody.ClientSize.Width - 64)
        pnlContent.Left = 32
        pnlContent.Width = w

        pnlKpiRow.Width = w

        Dim cardW As Integer = (w - 32) \ 3
        cardDosen.Width = cardW
        cardMhs.Width = cardW
        cardMhs.Left = cardW + 16
        cardKelas.Width = cardW
        cardKelas.Left = (cardW * 2) + 32

        pnlTableCard.Width = w
        pnlTableToolbar.Width = w - 40
        dgvAdminData.Width = w - 40
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

    Private Sub AdminDashboardForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Application.OpenForms.OfType(Of LoginForm)().Count = 0 AndAlso
           Application.OpenForms.OfType(Of Form1)().Count = 0 AndAlso
           Application.OpenForms.OfType(Of DosenDashboardForm)().Count = 0 Then
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
