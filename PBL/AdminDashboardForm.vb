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
    Private lblEdomLockStatus As Label
    Private lblEdomLockDescription As Label
    Private btnEdomLock As Button

    ' State & Komponen Manajemen Akun
    Private currentMenu As String = "DASHBOARD" ' "DASHBOARD" atau "MANAJEMEN_AKUN"
    Private akunCurrentRoleFilter As String = "ALL" ' "ALL", "DOSEN", atau "MAHASISWA"
    Private akunSearchFocused As Boolean = False

    Private Sub AdminDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblSidebarUserName.Text = If(UserSession.IsLoggedIn AndAlso Not String.IsNullOrWhiteSpace(UserSession.Nama), UserSession.Nama, "Admin")
        lblSidebarUserRole.Text = "admin"
        lblBadgeProdi.Visible = False

        PopulateProdiFilter()
        InitManajemenAkunView()
        SetupEdomLockControls()
        RefreshEdomLockStatus()
        ApplyControlRegions()
        SwitchMenu("DASHBOARD")
        AturLayoutResponsif()
    End Sub

    Private Sub SetupEdomLockControls()
        Dim lockCard As New Panel With {
            .Name = "pnlEdomLock", .BackColor = Color.White, .Left = 0, .Top = 132,
            .Height = 72, .Width = pnlContent.Width - 1, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        }
        lblEdomLockStatus = New Label With {
            .AutoSize = False, .Location = New Point(18, 10), .Size = New Size(190, 22),
            .Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold), .ForeColor = colorDark
        }
        lblEdomLockDescription = New Label With {
            .AutoSize = False, .Location = New Point(18, 34), .Size = New Size(600, 24),
            .Font = New Font("Segoe UI", 8.0!), .ForeColor = colorMuted
        }
        btnEdomLock = New Button With {
            .Name = "btnEdomLock", .Text = "Kunci EDOM", .Size = New Size(138, 36),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right, .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(185, 28, 28), .ForeColor = Color.White,
            .Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold), .Cursor = Cursors.Hand
        }
        btnEdomLock.FlatAppearance.BorderSize = 0
        AddHandler btnEdomLock.Click, AddressOf btnEdomLock_Click
        lockCard.Controls.Add(lblEdomLockStatus)
        lockCard.Controls.Add(lblEdomLockDescription)
        lockCard.Controls.Add(btnEdomLock)
        pnlContent.Controls.Add(lockCard)
        lockCard.BringToFront()
        btnEdomLock.Location = New Point(lockCard.Width - btnEdomLock.Width - 18, 18)
        pnlTableCard.Top = 218
        pnlContent.Height = Math.Max(pnlContent.Height, pnlTableCard.Bottom + 24)
    End Sub

    Private Sub RefreshEdomLockStatus()
        Try
            Dim studyProgramId = GetSelectedStudyProgramId()
            If studyProgramId <= 0 Then
                lblEdomLockStatus.Text = "Pilih program studi"
                lblEdomLockStatus.ForeColor = colorMuted
                lblEdomLockDescription.Text = "Pilih program studi pada filter untuk melihat atau mengubah status EDOM."
                btnEdomLock.Enabled = False
                Return
            End If

            Dim locked = EdomLockService.IsLocked(studyProgramId)
            lblEdomLockStatus.Text = If(locked, "EDOM TERKUNCI", "EDOM TERBUKA")
            lblEdomLockStatus.ForeColor = If(locked, Color.FromArgb(185, 28, 28), Color.FromArgb(5, 150, 105))
            lblEdomLockDescription.Text = If(locked, "Mahasiswa tidak dapat mengisi atau mengirim evaluasi.", "Pengisian EDOM masih dibuka untuk mahasiswa prodi ini.")
            btnEdomLock.Text = If(locked, "Buka Kembali", "Kunci EDOM")
            btnEdomLock.BackColor = If(locked, colorNavy, Color.FromArgb(185, 28, 28))
            btnEdomLock.Enabled = String.Equals(UserSession.Role, "admin", StringComparison.OrdinalIgnoreCase)
        Catch ex As Exception
            lblEdomLockStatus.Text = "Status EDOM tidak tersedia"
            lblEdomLockDescription.Text = "Periksa koneksi database dan pastikan tabel edom_settings sudah dibuat."
            btnEdomLock.Enabled = False
        End Try
    End Sub

    Private Sub btnEdomLock_Click(sender As Object, e As EventArgs)
        If Not String.Equals(UserSession.Role, "admin", StringComparison.OrdinalIgnoreCase) Then Return
        Try
            Dim studyProgramId = GetSelectedStudyProgramId()
            If studyProgramId <= 0 Then
                MessageBox.Show("Pilih satu program studi terlebih dahulu.", "Program Studi Belum Dipilih", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim currentlyLocked = EdomLockService.IsLocked(studyProgramId)
            Dim nextLocked = Not currentlyLocked
            Dim message = If(nextLocked,
                "Kunci pengisian EDOM untuk seluruh mahasiswa program studi ini?",
                "Buka kembali pengisian EDOM untuk mahasiswa program studi ini?")
            If MessageBox.Show(message, "Konfirmasi Penguncian EDOM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

            EdomLockService.SetLocked(studyProgramId, nextLocked)
            RefreshEdomLockStatus()
            MessageBox.Show(If(nextLocked, "Pengisian EDOM berhasil dikunci.", "Pengisian EDOM berhasil dibuka kembali."), "Status EDOM", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Status EDOM gagal diperbarui. Pastikan database dan tabel edom_settings tersedia." & vbCrLf & ex.Message,
                            "Gagal Mengubah Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetSelectedStudyProgramId() As Integer
        If cmbFilterProdi.SelectedIndex <= 0 OrElse cmbFilterProdi.SelectedItem Is Nothing Then Return 0

        Try
            Dim parameters As New Dictionary(Of String, Object) From {
                {"name", cmbFilterProdi.SelectedItem.ToString()}
            }
            Dim result = ModKoneksi.ExecuteScalar("SELECT id FROM study_programs WHERE name = @name", parameters)
            If result IsNot Nothing AndAlso result IsNot DBNull.Value Then Return Convert.ToInt32(result)
        Catch
        End Try

        Select Case cmbFilterProdi.SelectedItem.ToString().Trim().ToLower()
            Case "teknik informatika" : Return 1
            Case "teknik multimedia dan jaringan" : Return 2
            Case "teknik multimedia digital" : Return 3
            Case "rekayasa keamanan siber" : Return 4
            Case Else : Return 0
        End Select
    End Function

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
        btnNavManajemenAkun.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnNavManajemenAkun.Width, btnNavManajemenAkun.Height), 8))
        btnLogout.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnLogout.Width, btnLogout.Height), 6))
        If lblBadgeProdi.Visible Then
            lblBadgeProdi.Region = New Region(GetRoundedPath(New Rectangle(0, 0, lblBadgeProdi.Width, lblBadgeProdi.Height), 8))
        End If
        btnTabDosen.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnTabDosen.Width, btnTabDosen.Height), 6))
        btnTabMahasiswa.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnTabMahasiswa.Width, btnTabMahasiswa.Height), 6))
        btnRefresh.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnRefresh.Width, btnRefresh.Height), 6))
        pnlSearchBox.Region = New Region(GetRoundedPath(New Rectangle(0, 0, pnlSearchBox.Width, pnlSearchBox.Height), 6))

        If btnTambahAkun IsNot Nothing Then
            btnTambahAkun.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnTambahAkun.Width, btnTambahAkun.Height), 6))
        End If
        If btnAkunTabAll IsNot Nothing Then
            btnAkunTabAll.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnAkunTabAll.Width, btnAkunTabAll.Height), 6))
            btnAkunTabDosen.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnAkunTabDosen.Width, btnAkunTabDosen.Height), 6))
            btnAkunTabMahasiswa.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnAkunTabMahasiswa.Width, btnAkunTabMahasiswa.Height), 6))
            If btnAkunTabNonaktif IsNot Nothing Then
                btnAkunTabNonaktif.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnAkunTabNonaktif.Width, btnAkunTabNonaktif.Height), 6))
            End If
        End If
        If pnlAkunSearchBox IsNot Nothing Then
            pnlAkunSearchBox.Region = New Region(GetRoundedPath(New Rectangle(0, 0, pnlAkunSearchBox.Width, pnlAkunSearchBox.Height), 6))
        End If
    End Sub

    ' Navigasi Menu Sidebar
    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        SwitchMenu("DASHBOARD")
    End Sub

    Private Sub btnNavManajemenAkun_Click(sender As Object, e As EventArgs) Handles btnNavManajemenAkun.Click
        SwitchMenu("MANAJEMEN_AKUN")
    End Sub

    Public Sub SwitchMenu(menu As String)
        currentMenu = menu
        If menu = "DASHBOARD" Then
            btnNavDashboard.BackColor = colorNavy
            btnNavDashboard.ForeColor = Color.White
            btnNavManajemenAkun.BackColor = Color.Transparent
            btnNavManajemenAkun.ForeColor = colorMuted

            pnlContent.Visible = True
            If pnlContentAkun IsNot Nothing Then pnlContentAkun.Visible = False

            lblBreadcrumbTitle.Text = "Dashboard Admin - Monitoring Prodi"
            lblBreadcrumbSub.Text = "Selamat datang, " & lblSidebarUserName.Text & " (Monitoring seluruh sivitas akademika)"
            SwitchTab(currentTab)
        Else
            btnNavManajemenAkun.BackColor = colorNavy
            btnNavManajemenAkun.ForeColor = Color.White
            btnNavDashboard.BackColor = Color.Transparent
            btnNavDashboard.ForeColor = colorMuted

            pnlContent.Visible = False
            If pnlContentAkun IsNot Nothing Then pnlContentAkun.Visible = True

            lblBreadcrumbTitle.Text = "Manajemen Akun - Sistem EDOM"
            lblBreadcrumbSub.Text = "Kelola kredensial, buat akun baru, ubah kata sandi, dan hapus akun sivitas akademika"
            LoadDataAkun()
        End If
        AturLayoutResponsif()
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
                "WHERE u.role = 'dosen' AND COALESCE(u.is_deleted, 0) = 0 " &
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
                "WHERE u.role = 'mahasiswa' AND COALESCE(u.is_deleted, 0) = 0 " &
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
        dgvAdminData.CurrentCell = Nothing
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
        If btnEdomLock IsNot Nothing Then RefreshEdomLockStatus()
    End Sub

    Private Sub btnTabDosen_Click(sender As Object, e As EventArgs) Handles btnTabDosen.Click
        SwitchTab("DOSEN")
    End Sub

    Private Sub btnTabMahasiswa_Click(sender As Object, e As EventArgs) Handles btnTabMahasiswa.Click
        SwitchTab("MAHASISWA")
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If currentMenu = "DASHBOARD" Then
            SwitchTab(currentTab)
        Else
            LoadDataAkun()
        End If
        MessageBox.Show("Data berhasil diperbarui dari server.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        Dim lockCard = pnlContent.Controls("pnlEdomLock")
        If lockCard IsNot Nothing Then
            lockCard.Width = w
            btnEdomLock.Left = lockCard.ClientSize.Width - btnEdomLock.Width - 18
        End If

        If pnlContentAkun IsNot Nothing Then
            pnlContentAkun.Left = 32
            pnlContentAkun.Width = w
            pnlAkunKpiRow.Width = w

            cardAkunTotal.Width = cardW
            cardAkunDosen.Width = cardW
            cardAkunDosen.Left = cardW + 16
            cardAkunMhs.Width = cardW
            cardAkunMhs.Left = (cardW * 2) + 32

            pnlAkunTableCard.Width = w
            pnlAkunHeaderRow.Width = w - 40
            pnlAkunFilterToolbar.Width = w - 40
            dgvAkun.Width = w - 40

            btnTambahAkun.Left = pnlAkunHeaderRow.Width - btnTambahAkun.Width
            pnlAkunSearchBox.Left = pnlAkunFilterToolbar.Width - pnlAkunSearchBox.Width
            cmbAkunFilterProdi.Left = pnlAkunSearchBox.Left - cmbAkunFilterProdi.Width - 12
        End If
    End Sub

    ' ==========================================================
    ' MANAJEMEN AKUN VIEW & CRUD (Khusus Role Admin)
    ' ==========================================================
    Private Sub InitManajemenAkunView()
        If pnlContentAkun IsNot Nothing Then Return

        pnlContentAkun = New Panel With {
            .Location = New Point(32, 24),
            .Size = New Size(896, 630),
            .Visible = False
        }

        ' KPI Row
        pnlAkunKpiRow = New Panel With {.Location = New Point(0, 0), .Size = New Size(896, 120)}
        cardAkunTotal = CreateKpiCard("TOTAL AKUN TERDAFTAR", "0 Akun", "Sivitas akademika aktif", Color.FromArgb(37, 99, 235), lblAkunTotalValue)
        cardAkunDosen = CreateKpiCard("AKUN DOSEN", "0 Dosen", "Dosen pengajar aktif", Color.FromArgb(5, 150, 105), lblAkunDosenValue)
        cardAkunMhs = CreateKpiCard("AKUN MAHASISWA", "0 Mahasiswa", "Mahasiswa pengisi EDOM", Color.FromArgb(217, 119, 6), lblAkunMhsValue)

        pnlAkunKpiRow.Controls.Add(cardAkunMhs)
        pnlAkunKpiRow.Controls.Add(cardAkunDosen)
        pnlAkunKpiRow.Controls.Add(cardAkunTotal)

        ' Table Card
        pnlAkunTableCard = New Panel With {
            .BackColor = Color.White,
            .Location = New Point(0, 136),
            .Padding = New Padding(20),
            .Size = New Size(896, 490)
        }

        ' Header Row
        pnlAkunHeaderRow = New Panel With {.Dock = DockStyle.Top, .Height = 50}
        lblAkunTableTitle = New Label With {
            .Text = "Manajemen Akun Sivitas Akademika",
            .Font = New Font("Segoe UI", 11.0!, FontStyle.Bold),
            .ForeColor = colorDark,
            .Location = New Point(0, 4),
            .AutoSize = True
        }
        lblAkunTableSub = New Label With {
            .Text = "Kelola kredensial, buat akun baru, ubah kata sandi, dan hapus akun dosen atau mahasiswa",
            .Font = New Font("Segoe UI", 8.25!),
            .ForeColor = colorMuted,
            .Location = New Point(0, 26),
            .AutoSize = True
        }
        btnTambahAkun = New Button With {
            .Text = "+ Tambah Akun Baru",
            .Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold),
            .BackColor = colorNavy,
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Size = New Size(160, 36),
            .Cursor = Cursors.Hand
        }
        btnTambahAkun.FlatAppearance.BorderSize = 0
        AddHandler btnTambahAkun.Click, AddressOf btnTambahAkun_Click

        pnlAkunHeaderRow.Controls.Add(btnTambahAkun)
        pnlAkunHeaderRow.Controls.Add(lblAkunTableSub)
        pnlAkunHeaderRow.Controls.Add(lblAkunTableTitle)

        ' Filter Toolbar
        pnlAkunFilterToolbar = New Panel With {.Dock = DockStyle.Top, .Height = 44}
        btnAkunTabAll = CreateTabButton("Semua (0)", 0, True, 88)
        btnAkunTabDosen = CreateTabButton("Dosen (0)", 93, False, 88)
        btnAkunTabMahasiswa = CreateTabButton("Mahasiswa (0)", 186, False, 105)
        btnAkunTabNonaktif = CreateTabButton("Nonaktif (0)", 296, False, 98)

        AddHandler btnAkunTabAll.Click, Sub() SetAkunRoleFilter("ALL")
        AddHandler btnAkunTabDosen.Click, Sub() SetAkunRoleFilter("DOSEN")
        AddHandler btnAkunTabMahasiswa.Click, Sub() SetAkunRoleFilter("MAHASISWA")
        AddHandler btnAkunTabNonaktif.Click, Sub() SetAkunRoleFilter("NONAKTIF")

        cmbAkunFilterProdi = New ComboBox With {
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 8.5!),
            .ForeColor = colorDark,
            .Width = 190,
            .Height = 32
        }
        cmbAkunFilterProdi.Items.AddRange(New Object() {
            "Semua Program Studi",
            "Teknik Informatika",
            "Teknik Multimedia dan Jaringan",
            "Teknik Multimedia Digital",
            "Rekayasa Keamanan Siber"
        })
        cmbAkunFilterProdi.SelectedIndex = 0
        AddHandler cmbAkunFilterProdi.SelectedIndexChanged, Sub() FilterAkunData()

        pnlAkunSearchBox = New Panel With {
            .BackColor = Color.FromArgb(248, 250, 252),
            .Width = 220,
            .Height = 32
        }
        txtAkunSearch = New TextBox With {
            .BorderStyle = BorderStyle.None,
            .BackColor = Color.FromArgb(248, 250, 252),
            .Font = New Font("Segoe UI", 8.5!),
            .ForeColor = colorDark,
            .PlaceholderText = "Cari nama, email, identitas...",
            .Location = New Point(10, 7),
            .Width = 200
        }
        AddHandler txtAkunSearch.TextChanged, Sub() FilterAkunData()
        AddHandler txtAkunSearch.Enter, Sub()
                                            akunSearchFocused = True
                                            pnlAkunSearchBox.Invalidate()
                                        End Sub
        AddHandler txtAkunSearch.Leave, Sub()
                                            akunSearchFocused = False
                                            pnlAkunSearchBox.Invalidate()
                                        End Sub
        AddHandler pnlAkunSearchBox.Paint, AddressOf pnlAkunSearchBox_Paint
        pnlAkunSearchBox.Controls.Add(txtAkunSearch)

        pnlAkunFilterToolbar.Controls.Add(btnAkunTabAll)
        pnlAkunFilterToolbar.Controls.Add(btnAkunTabDosen)
        pnlAkunFilterToolbar.Controls.Add(btnAkunTabMahasiswa)
        pnlAkunFilterToolbar.Controls.Add(btnAkunTabNonaktif)
        pnlAkunFilterToolbar.Controls.Add(cmbAkunFilterProdi)
        pnlAkunFilterToolbar.Controls.Add(pnlAkunSearchBox)

        ' DataGridView Akun
        dgvAkun = New DataGridView With {
            .Dock = DockStyle.Fill,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .AllowUserToResizeRows = False,
            .BackgroundColor = Color.White,
            .BorderStyle = BorderStyle.None,
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
            .ColumnHeadersHeight = 44,
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            .GridColor = Color.FromArgb(241, 245, 249),
            .MultiSelect = False,
            .ReadOnly = True,
            .RowHeadersVisible = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        }
        dgvAkun.EnableHeadersVisualStyles = False
        dgvAkun.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
        dgvAkun.ColumnHeadersDefaultCellStyle.ForeColor = colorMuted
        dgvAkun.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold)
        dgvAkun.DefaultCellStyle.Font = New Font("Segoe UI", 8.75!)
        dgvAkun.DefaultCellStyle.ForeColor = colorDark
        dgvAkun.DefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249)
        dgvAkun.DefaultCellStyle.SelectionForeColor = colorDark

        InitDgvAkunColumns()
        AddHandler dgvAkun.CellPainting, AddressOf dgvAkun_CellPainting
        AddHandler dgvAkun.CellClick, AddressOf dgvAkun_CellClick

        pnlAkunTableCard.Controls.Add(dgvAkun)
        pnlAkunTableCard.Controls.Add(pnlAkunFilterToolbar)
        pnlAkunTableCard.Controls.Add(pnlAkunHeaderRow)

        AddHandler pnlAkunTableCard.Paint, AddressOf ModernCard_Paint

        pnlContentAkun.Controls.Add(pnlAkunTableCard)
        pnlContentAkun.Controls.Add(pnlAkunKpiRow)

        pnlScrollBody.Controls.Add(pnlContentAkun)
    End Sub

    Private Function CreateKpiCard(title As String, val As String, subText As String, subColor As Color, ByRef outValLabel As Label) As Panel
        Dim pnl As New Panel With {.BackColor = Color.White, .Padding = New Padding(18), .Size = New Size(288, 120)}
        Dim lblTitle As New Label With {
            .Text = title,
            .Font = New Font("Segoe UI Semibold", 8.25!, FontStyle.Bold),
            .ForeColor = colorMuted,
            .Location = New Point(18, 18),
            .AutoSize = True
        }
        outValLabel = New Label With {
            .Text = val,
            .Font = New Font("Segoe UI", 18.0!, FontStyle.Bold),
            .ForeColor = colorDark,
            .Location = New Point(18, 44),
            .AutoSize = True
        }
        Dim lblSub As New Label With {
            .Text = subText,
            .Font = New Font("Segoe UI", 8.0!),
            .ForeColor = subColor,
            .Location = New Point(18, 86),
            .AutoSize = True
        }
        pnl.Controls.Add(lblSub)
        pnl.Controls.Add(outValLabel)
        pnl.Controls.Add(lblTitle)
        AddHandler pnl.Paint, AddressOf ModernCard_Paint
        Return pnl
    End Function

    Private Function CreateTabButton(text As String, leftPos As Integer, isActive As Boolean, Optional width As Integer = 90) As Button
        Dim btn As New Button With {
            .Text = text,
            .Left = leftPos,
            .Top = 6,
            .Height = 32,
            .Width = width,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI Semibold", 8.25!, FontStyle.Bold),
            .BackColor = If(isActive, colorNavy, Color.White),
            .ForeColor = If(isActive, Color.White, colorMuted),
            .Cursor = Cursors.Hand
        }
        btn.FlatAppearance.BorderColor = colorBorder
        btn.FlatAppearance.BorderSize = If(isActive, 0, 1)
        Return btn
    End Function

    Private Sub InitDgvAkunColumns()
        dgvAkun.Columns.Clear()
        dgvAkun.AutoGenerateColumns = False
        dgvAkun.RowTemplate.Height = 48

        dgvAkun.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAkunNo", .HeaderText = "NO", .Width = 45, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvAkun.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAkunIdentitas", .HeaderText = "NIM / NIDN", .Width = 105, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter, .Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)}})
        dgvAkun.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAkunNama", .HeaderText = "NAMA LENGKAP & GELAR", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 32.0!})
        dgvAkun.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAkunEmail", .HeaderText = "EMAIL KAMPUS", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .FillWeight = 28.0!})
        dgvAkun.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAkunRole", .HeaderText = "JENIS AKUN", .Width = 95, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvAkun.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAkunProdi", .HeaderText = "PROGRAM STUDI", .Width = 150})
        dgvAkun.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAkunStatus", .HeaderText = "STATUS", .Width = 85, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
        dgvAkun.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colAkunAksi", .HeaderText = "TINDAKAN", .Width = 145, .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}})
    End Sub

    Public Sub LoadDataAkun()
        If dgvAkun Is Nothing Then Return
        dgvAkun.Rows.Clear()

        Dim list = AkunRepository.GetAllAccounts()

        ' Update KPI
        Dim countActive = list.Where(Function(a) Not a.IsDeleted).Count()
        Dim countDosen = list.Where(Function(a) Not a.IsDeleted AndAlso a.Role.ToLower() = "dosen").Count()
        Dim countMhs = list.Where(Function(a) Not a.IsDeleted AndAlso a.Role.ToLower() = "mahasiswa").Count()
        Dim countNonaktif = list.Where(Function(a) a.IsDeleted).Count()

        If lblAkunTotalValue IsNot Nothing Then lblAkunTotalValue.Text = countActive.ToString() & " Akun"
        If lblAkunDosenValue IsNot Nothing Then lblAkunDosenValue.Text = countDosen.ToString() & " Dosen"
        If lblAkunMhsValue IsNot Nothing Then lblAkunMhsValue.Text = countMhs.ToString() & " Mahasiswa"

        If btnAkunTabAll IsNot Nothing Then btnAkunTabAll.Text = "Semua (" & countActive.ToString() & ")"
        If btnAkunTabDosen IsNot Nothing Then btnAkunTabDosen.Text = "Dosen (" & countDosen.ToString() & ")"
        If btnAkunTabMahasiswa IsNot Nothing Then btnAkunTabMahasiswa.Text = "Mahasiswa (" & countMhs.ToString() & ")"
        If btnAkunTabNonaktif IsNot Nothing Then btnAkunTabNonaktif.Text = "Nonaktif (" & countNonaktif.ToString() & ")"

        Dim no As Integer = 1
        For Each acc In list
            Dim rowIndex = dgvAkun.Rows.Add(
                no,
                acc.Identitas,
                acc.NamaLengkapGelar,
                acc.Email,
                If(acc.Role.ToLower() = "dosen", "Dosen", "Mahasiswa"),
                acc.Prodi,
                acc.Status,
                ""
            )
            dgvAkun.Rows(rowIndex).Tag = acc
            no += 1
        Next

        FilterAkunData()
    End Sub

    Private Sub SetAkunRoleFilter(role As String)
        akunCurrentRoleFilter = role
        If btnAkunTabAll IsNot Nothing Then
            btnAkunTabAll.BackColor = If(role = "ALL", colorNavy, Color.White)
            btnAkunTabAll.ForeColor = If(role = "ALL", Color.White, colorMuted)
            btnAkunTabAll.FlatAppearance.BorderSize = If(role = "ALL", 0, 1)

            btnAkunTabDosen.BackColor = If(role = "DOSEN", colorNavy, Color.White)
            btnAkunTabDosen.ForeColor = If(role = "DOSEN", Color.White, colorMuted)
            btnAkunTabDosen.FlatAppearance.BorderSize = If(role = "DOSEN", 0, 1)

            btnAkunTabMahasiswa.BackColor = If(role = "MAHASISWA", colorNavy, Color.White)
            btnAkunTabMahasiswa.ForeColor = If(role = "MAHASISWA", Color.White, colorMuted)
            btnAkunTabMahasiswa.FlatAppearance.BorderSize = If(role = "MAHASISWA", 0, 1)

            If btnAkunTabNonaktif IsNot Nothing Then
                btnAkunTabNonaktif.BackColor = If(role = "NONAKTIF", colorNavy, Color.White)
                btnAkunTabNonaktif.ForeColor = If(role = "NONAKTIF", Color.White, colorMuted)
                btnAkunTabNonaktif.FlatAppearance.BorderSize = If(role = "NONAKTIF", 0, 1)
            End If
        End If
        FilterAkunData()
    End Sub

    Private Sub FilterAkunData()
        If dgvAkun Is Nothing Then Return
        dgvAkun.CurrentCell = Nothing
        Dim q As String = If(txtAkunSearch IsNot Nothing, txtAkunSearch.Text.Trim().ToLower(), "")
        Dim selectedProdi As String = ""
        If cmbAkunFilterProdi IsNot Nothing AndAlso cmbAkunFilterProdi.SelectedIndex > 0 Then
            selectedProdi = cmbAkunFilterProdi.SelectedItem.ToString().Trim().ToLower()
        End If

        For Each row As DataGridViewRow In dgvAkun.Rows
            Dim acc = TryCast(row.Tag, UserAccountModel)
            If acc Is Nothing Then Continue For

            Dim matchRole As Boolean = False
            Select Case akunCurrentRoleFilter
                Case "ALL"
                    matchRole = Not acc.IsDeleted
                Case "DOSEN"
                    matchRole = (Not acc.IsDeleted) AndAlso (acc.Role.ToLower() = "dosen")
                Case "MAHASISWA"
                    matchRole = (Not acc.IsDeleted) AndAlso (acc.Role.ToLower() = "mahasiswa")
                Case "NONAKTIF"
                    matchRole = acc.IsDeleted
                Case Else
                    matchRole = Not acc.IsDeleted
            End Select

            Dim matchProdi As Boolean = String.IsNullOrEmpty(selectedProdi) OrElse acc.Prodi.ToLower() = selectedProdi

            Dim matchSearch As Boolean = String.IsNullOrEmpty(q) OrElse
                                         acc.Nama.ToLower().Contains(q) OrElse
                                         acc.Email.ToLower().Contains(q) OrElse
                                         acc.Identitas.ToLower().Contains(q)

            row.Visible = matchRole AndAlso matchProdi AndAlso matchSearch
        Next
    End Sub

    Private Sub dgvAkun_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 Then Return

        ' Pill Badge Role (Dosen / Mahasiswa)
        If e.ColumnIndex = 4 AndAlso e.Value IsNot Nothing Then
            e.PaintBackground(e.CellBounds, True)
            Dim isDosen = e.Value.ToString().ToLower().Contains("dosen")
            Dim pillRect As New Rectangle(e.CellBounds.X + (e.CellBounds.Width - 84) \ 2, e.CellBounds.Y + (e.CellBounds.Height - 24) \ 2, 84, 24)
            Dim bgPill = If(isDosen, Color.FromArgb(239, 246, 255), Color.FromArgb(236, 253, 245))
            Dim txtPill = If(isDosen, Color.FromArgb(29, 78, 216), Color.FromArgb(4, 120, 87))

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using path = GetRoundedPath(pillRect, 12), brBg As New SolidBrush(bgPill)
                e.Graphics.FillPath(brBg, path)
            End Using
            Using fontPill As New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold),
                  brText As New SolidBrush(txtPill),
                  sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString(If(isDosen, "Dosen", "Mahasiswa"), fontPill, brText, pillRect, sf)
            End Using
            e.Handled = True
            Return
        End If

        ' Pill Badge Status (Aktif / Nonaktif)
        If e.ColumnIndex = 6 AndAlso e.Value IsNot Nothing Then
            e.PaintBackground(e.CellBounds, True)
            Dim isNonaktif = e.Value.ToString().ToLower().Contains("nonaktif")
            Dim pillRect As New Rectangle(e.CellBounds.X + (e.CellBounds.Width - 76) \ 2, e.CellBounds.Y + (e.CellBounds.Height - 24) \ 2, 76, 24)
            Dim bgPill = If(isNonaktif, Color.FromArgb(254, 242, 242), Color.FromArgb(236, 253, 245))
            Dim txtPill = If(isNonaktif, Color.FromArgb(220, 38, 38), Color.FromArgb(4, 120, 87))

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using path = GetRoundedPath(pillRect, 12), brBg As New SolidBrush(bgPill)
                e.Graphics.FillPath(brBg, path)
            End Using
            Using fontPill As New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold),
                  brText As New SolidBrush(txtPill),
                  sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString(If(isNonaktif, "Nonaktif", "Aktif"), fontPill, brText, pillRect, sf)
            End Using
            e.Handled = True
            Return
        End If

        ' Tombol Aksi (Col 7: Edit & Hapus / Pulihkan)
        If e.ColumnIndex = 7 Then
            e.PaintBackground(e.CellBounds, True)
            Dim btnH As Integer = 26
            Dim btnY As Integer = e.CellBounds.Y + (e.CellBounds.Height - btnH) \ 2

            ' Edit Button
            Dim editRect As New Rectangle(e.CellBounds.X + 6, btnY, 50, btnH)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using pathEdit = GetRoundedPath(editRect, 5),
                  brEditBg As New SolidBrush(Color.FromArgb(239, 246, 255)),
                  penEditBdr As New Pen(Color.FromArgb(191, 219, 254), 1.0!)
                e.Graphics.FillPath(brEditBg, pathEdit)
                e.Graphics.DrawPath(penEditBdr, pathEdit)
            End Using
            Using fontBtn As New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold),
                  brText As New SolidBrush(colorNavy),
                  sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                e.Graphics.DrawString("Edit", fontBtn, brText, editRect, sf)
            End Using

            ' Tombol Hapus (Soft Delete) atau Pulihkan
            Dim acc = TryCast(dgvAkun.Rows(e.RowIndex).Tag, UserAccountModel)
            Dim isDeleted = If(acc IsNot Nothing, acc.IsDeleted, False)

            If Not isDeleted Then
                Dim hapusRect As New Rectangle(e.CellBounds.X + 62, btnY, 58, btnH)
                Using pathHapus = GetRoundedPath(hapusRect, 5),
                      brHapusBg As New SolidBrush(Color.FromArgb(254, 242, 242)),
                      penHapusBdr As New Pen(Color.FromArgb(254, 202, 202), 1.0!)
                    e.Graphics.FillPath(brHapusBg, pathHapus)
                    e.Graphics.DrawPath(penHapusBdr, pathHapus)
                End Using
                Using fontBtn As New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold),
                      brText As New SolidBrush(Color.FromArgb(220, 38, 38)),
                      sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    e.Graphics.DrawString("Hapus", fontBtn, brText, hapusRect, sf)
                End Using
            Else
                Dim pulihkanRect As New Rectangle(e.CellBounds.X + 62, btnY, 70, btnH)
                Using pathRestore = GetRoundedPath(pulihkanRect, 5),
                      brRestoreBg As New SolidBrush(Color.FromArgb(236, 253, 245)),
                      penRestoreBdr As New Pen(Color.FromArgb(167, 243, 208), 1.0!)
                    e.Graphics.FillPath(brRestoreBg, pathRestore)
                    e.Graphics.DrawPath(penRestoreBdr, pathRestore)
                End Using
                Using fontBtn As New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold),
                      brText As New SolidBrush(Color.FromArgb(5, 150, 105)),
                      sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                    e.Graphics.DrawString("Pulihkan", fontBtn, brText, pulihkanRect, sf)
                End Using
            End If

            e.Handled = True
            Return
        End If
    End Sub

    Private Sub dgvAkun_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = 7 Then
            Dim row = dgvAkun.Rows(e.RowIndex)
            Dim targetAcc = TryCast(row.Tag, UserAccountModel)
            If targetAcc Is Nothing Then Return

            Dim clickPt = dgvAkun.PointToClient(Cursor.Position)
            Dim cellDisplay = dgvAkun.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
            Dim relX = clickPt.X - cellDisplay.X

            If relX >= 6 AndAlso relX <= 56 Then
                ' EDIT AKUN
                ShowAkunModal(targetAcc)
            ElseIf relX >= 62 AndAlso relX <= 136 Then
                If Not targetAcc.IsDeleted Then
                    ' SOFT DELETE AKUN
                    Dim konfirmasi = MessageBox.Show(
                        "Apakah Anda yakin ingin menonaktifkan akun '" & targetAcc.Nama & "' (" & targetAcc.Role & ")?" & vbCrLf & vbCrLf &
                        "Catatan: Tindakan ini bersifat Soft Delete. Akun akan dinonaktifkan sehingga tidak dapat masuk ke sistem, namun seluruh data tetap tersimpan.",
                        "Konfirmasi Nonaktifkan Akun", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    If konfirmasi = DialogResult.Yes Then
                        Dim err As String = ""
                        If AkunRepository.SoftDeleteAccount(targetAcc.Id, err) Then
                            MessageBox.Show("Akun '" & targetAcc.Nama & "' berhasil dinonaktifkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadDataAkun()
                        Else
                            MessageBox.Show("Gagal menonaktifkan akun: " & err, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    ' PULIHKAN AKUN
                    Dim konfirmasi = MessageBox.Show(
                        "Apakah Anda yakin ingin memulihkan (mengaktifkan kembali) akun '" & targetAcc.Nama & "'?",
                        "Konfirmasi Pulihkan Akun", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If konfirmasi = DialogResult.Yes Then
                        Dim err As String = ""
                        If AkunRepository.RestoreAccount(targetAcc.Id, err) Then
                            MessageBox.Show("Akun '" & targetAcc.Nama & "' berhasil diaktifkan kembali.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadDataAkun()
                        Else
                            MessageBox.Show("Gagal mengaktifkan kembali akun: " & err, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnTambahAkun_Click(sender As Object, e As EventArgs)
        ShowAkunModal(Nothing)
    End Sub

    Private Sub ShowAkunModal(Optional accToEdit As UserAccountModel = Nothing)
        Using overlay As New Form()
            overlay.StartPosition = FormStartPosition.Manual
            overlay.FormBorderStyle = FormBorderStyle.None
            overlay.Opacity = 0.5R
            overlay.BackColor = Color.FromArgb(15, 23, 42)
            overlay.ShowInTaskbar = False
            overlay.Bounds = Me.Bounds
            overlay.Show(Me)

            Using modal As New AkunModalForm(accToEdit)
                If modal.ShowDialog(overlay) = DialogResult.OK Then
                    LoadDataAkun()
                End If
            End Using

            overlay.Close()
        End Using
    End Sub

    Private Sub pnlAkunSearchBox_Paint(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlAkunSearchBox.Width - 1, pnlAkunSearchBox.Height - 1)
        Dim bdrColor As Color = If(akunSearchFocused, colorNavy, colorBorder)
        Using path As GraphicsPath = GetRoundedPath(rect, 6), penBdr As New Pen(bdrColor, If(akunSearchFocused, 1.5!, 1.0!))
            e.Graphics.DrawPath(penBdr, path)
        End Using
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
