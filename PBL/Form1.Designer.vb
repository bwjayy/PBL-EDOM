<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
    Friend WithEvents pnlBrand As System.Windows.Forms.Panel
    Friend WithEvents picSidebarLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblSidebarBrand As System.Windows.Forms.Label
    Friend WithEvents lblSidebarSub As System.Windows.Forms.Label
    Friend WithEvents pnlNavContainer As System.Windows.Forms.Panel
    Friend WithEvents btnNavDashboard As System.Windows.Forms.Button
    Friend WithEvents btnNavMatkul As System.Windows.Forms.Button
    Friend WithEvents btnNavStatistik As System.Windows.Forms.Button
    Friend WithEvents btnNavBantuan As System.Windows.Forms.Button
    Friend WithEvents pnlUserCard As System.Windows.Forms.Panel
    Friend WithEvents picUserAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents lblSidebarUserName As System.Windows.Forms.Label
    Friend WithEvents lblSidebarUserRole As System.Windows.Forms.Label
    Friend WithEvents btnLogout As System.Windows.Forms.Button

    ' Main Area Controls
    Friend WithEvents pnlMainContainer As System.Windows.Forms.Panel
    Friend WithEvents pnlTopbar As System.Windows.Forms.Panel
    Friend WithEvents lblBreadcrumbTitle As System.Windows.Forms.Label
    Friend WithEvents lblBreadcrumbSub As System.Windows.Forms.Label
    Friend WithEvents pnlSearchBox As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchIcon As System.Windows.Forms.Label
    Friend WithEvents cboTahunAkademik As System.Windows.Forms.ComboBox

    ' Scrollable Body
    Friend WithEvents pnlScrollBody As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel

    ' KPI Stat Cards
    Friend WithEvents pnlKpiRow As System.Windows.Forms.Panel
    Friend WithEvents cardTotalMatkul As System.Windows.Forms.Panel
    Friend WithEvents lblKpi1Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi1Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi1Badge As System.Windows.Forms.Label

    Friend WithEvents cardProgress As System.Windows.Forms.Panel
    Friend WithEvents lblKpi2Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi2Title As System.Windows.Forms.Label
    Friend WithEvents pnlProgressBarBg As System.Windows.Forms.Panel
    Friend WithEvents pnlProgressBarFill As System.Windows.Forms.Panel

    Friend WithEvents cardDeadline As System.Windows.Forms.Panel
    Friend WithEvents lblKpi3Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi3Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi3Sub As System.Windows.Forms.Label

    ' Alert / Info Banner
    Friend WithEvents pnlAlert As System.Windows.Forms.Panel
    Friend WithEvents lblAlertIcon As System.Windows.Forms.Label
    Friend WithEvents lblAlertText As System.Windows.Forms.Label

    ' Main Table Card
    Friend WithEvents pnlTableCard As System.Windows.Forms.Panel
    Friend WithEvents lblTableTitle As System.Windows.Forms.Label
    Friend WithEvents lblTableCountBadge As System.Windows.Forms.Label
    Friend WithEvents lblTablePeriode As System.Windows.Forms.Label
    Friend WithEvents dgvEdom As System.Windows.Forms.DataGridView

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.pnlUserCard = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblSidebarUserRole = New System.Windows.Forms.Label()
        Me.lblSidebarUserName = New System.Windows.Forms.Label()
        Me.picUserAvatar = New System.Windows.Forms.PictureBox()
        Me.pnlNavContainer = New System.Windows.Forms.Panel()
        Me.btnNavBantuan = New System.Windows.Forms.Button()
        Me.btnNavStatistik = New System.Windows.Forms.Button()
        Me.btnNavMatkul = New System.Windows.Forms.Button()
        Me.btnNavDashboard = New System.Windows.Forms.Button()
        Me.pnlBrand = New System.Windows.Forms.Panel()
        Me.lblSidebarSub = New System.Windows.Forms.Label()
        Me.lblSidebarBrand = New System.Windows.Forms.Label()
        Me.picSidebarLogo = New System.Windows.Forms.PictureBox()

        Me.pnlMainContainer = New System.Windows.Forms.Panel()
        Me.pnlScrollBody = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()

        Me.pnlTableCard = New System.Windows.Forms.Panel()
        Me.dgvEdom = New System.Windows.Forms.DataGridView()
        Me.lblTablePeriode = New System.Windows.Forms.Label()
        Me.lblTableCountBadge = New System.Windows.Forms.Label()
        Me.lblTableTitle = New System.Windows.Forms.Label()

        Me.pnlAlert = New System.Windows.Forms.Panel()
        Me.lblAlertText = New System.Windows.Forms.Label()
        Me.lblAlertIcon = New System.Windows.Forms.Label()

        Me.pnlKpiRow = New System.Windows.Forms.Panel()
        Me.cardDeadline = New System.Windows.Forms.Panel()
        Me.lblKpi3Sub = New System.Windows.Forms.Label()
        Me.lblKpi3Value = New System.Windows.Forms.Label()
        Me.lblKpi3Title = New System.Windows.Forms.Label()

        Me.cardProgress = New System.Windows.Forms.Panel()
        Me.pnlProgressBarBg = New System.Windows.Forms.Panel()
        Me.pnlProgressBarFill = New System.Windows.Forms.Panel()
        Me.lblKpi2Value = New System.Windows.Forms.Label()
        Me.lblKpi2Title = New System.Windows.Forms.Label()

        Me.cardTotalMatkul = New System.Windows.Forms.Panel()
        Me.lblKpi1Badge = New System.Windows.Forms.Label()
        Me.lblKpi1Value = New System.Windows.Forms.Label()
        Me.lblKpi1Title = New System.Windows.Forms.Label()

        Me.pnlTopbar = New System.Windows.Forms.Panel()
        Me.cboTahunAkademik = New System.Windows.Forms.ComboBox()
        Me.pnlSearchBox = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearchIcon = New System.Windows.Forms.Label()
        Me.lblBreadcrumbSub = New System.Windows.Forms.Label()
        Me.lblBreadcrumbTitle = New System.Windows.Forms.Label()

        Me.pnlSidebar.SuspendLayout()
        Me.pnlUserCard.SuspendLayout()
        CType(Me.picUserAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavContainer.SuspendLayout()
        Me.pnlBrand.SuspendLayout()
        CType(Me.picSidebarLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMainContainer.SuspendLayout()
        Me.pnlScrollBody.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlTableCard.SuspendLayout()
        CType(Me.dgvEdom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAlert.SuspendLayout()
        Me.pnlKpiRow.SuspendLayout()
        Me.cardDeadline.SuspendLayout()
        Me.cardProgress.SuspendLayout()
        Me.pnlProgressBarBg.SuspendLayout()
        Me.cardTotalMatkul.SuspendLayout()
        Me.pnlTopbar.SuspendLayout()
        Me.pnlSearchBox.SuspendLayout()
        Me.SuspendLayout()

        '
        ' pnlSidebar (Secondary Dark Navy - #0F172A)
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.pnlSidebar.Controls.Add(Me.pnlUserCard)
        Me.pnlSidebar.Controls.Add(Me.pnlNavContainer)
        Me.pnlSidebar.Controls.Add(Me.pnlBrand)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(260, 800)
        Me.pnlSidebar.TabIndex = 0

        '
        ' pnlBrand
        '
        Me.pnlBrand.Controls.Add(Me.lblSidebarSub)
        Me.pnlBrand.Controls.Add(Me.lblSidebarBrand)
        Me.pnlBrand.Controls.Add(Me.picSidebarLogo)
        Me.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBrand.Location = New System.Drawing.Point(0, 0)
        Me.pnlBrand.Name = "pnlBrand"
        Me.pnlBrand.Padding = New System.Windows.Forms.Padding(20, 20, 20, 10)
        Me.pnlBrand.Size = New System.Drawing.Size(260, 84)
        Me.pnlBrand.TabIndex = 0

        '
        ' picSidebarLogo
        '
        Me.picSidebarLogo.Location = New System.Drawing.Point(20, 20)
        Me.picSidebarLogo.Name = "picSidebarLogo"
        Me.picSidebarLogo.Size = New System.Drawing.Size(44, 44)
        Me.picSidebarLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picSidebarLogo.TabIndex = 0
        Me.picSidebarLogo.TabStop = False

        '
        ' lblSidebarBrand
        '
        Me.lblSidebarBrand.AutoSize = True
        Me.lblSidebarBrand.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblSidebarBrand.ForeColor = System.Drawing.Color.White
        Me.lblSidebarBrand.Location = New System.Drawing.Point(70, 20)
        Me.lblSidebarBrand.Name = "lblSidebarBrand"
        Me.lblSidebarBrand.Size = New System.Drawing.Size(124, 25)
        Me.lblSidebarBrand.TabIndex = 1
        Me.lblSidebarBrand.Text = "EDOM Portal"

        '
        ' lblSidebarSub
        '
        Me.lblSidebarSub.AutoSize = True
        Me.lblSidebarSub.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblSidebarSub.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199) ' Tertiary Cyan #0284C7
        Me.lblSidebarSub.Location = New System.Drawing.Point(72, 45)
        Me.lblSidebarSub.Name = "lblSidebarSub"
        Me.lblSidebarSub.Size = New System.Drawing.Size(147, 15)
        Me.lblSidebarSub.TabIndex = 2
        Me.lblSidebarSub.Text = "Politeknik Negeri Jakarta"

        '
        ' pnlNavContainer
        '
        Me.pnlNavContainer.Controls.Add(Me.btnNavBantuan)
        Me.pnlNavContainer.Controls.Add(Me.btnNavStatistik)
        Me.pnlNavContainer.Controls.Add(Me.btnNavMatkul)
        Me.pnlNavContainer.Controls.Add(Me.btnNavDashboard)
        Me.pnlNavContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNavContainer.Location = New System.Drawing.Point(0, 84)
        Me.pnlNavContainer.Name = "pnlNavContainer"
        Me.pnlNavContainer.Padding = New System.Windows.Forms.Padding(16, 12, 16, 12)
        Me.pnlNavContainer.Size = New System.Drawing.Size(260, 716)
        Me.pnlNavContainer.TabIndex = 1

        '
        ' btnNavDashboard (Active - Primary Blue #1E3A8A)
        '
        Me.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(30, 58, 138)
        Me.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnNavDashboard.FlatAppearance.BorderSize = 0
        Me.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavDashboard.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnNavDashboard.ForeColor = System.Drawing.Color.White
        Me.btnNavDashboard.Location = New System.Drawing.Point(16, 12)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.btnNavDashboard.Size = New System.Drawing.Size(228, 44)
        Me.btnNavDashboard.TabIndex = 0
        Me.btnNavDashboard.Text = "🏠  Dashboard EDOM"
        Me.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNavDashboard.UseVisualStyleBackColor = False

        '
        ' btnNavMatkul
        '
        Me.btnNavMatkul.BackColor = System.Drawing.Color.Transparent
        Me.btnNavMatkul.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavMatkul.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnNavMatkul.FlatAppearance.BorderSize = 0
        Me.btnNavMatkul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavMatkul.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnNavMatkul.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.btnNavMatkul.Location = New System.Drawing.Point(16, 56)
        Me.btnNavMatkul.Name = "btnNavMatkul"
        Me.btnNavMatkul.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.btnNavMatkul.Size = New System.Drawing.Size(228, 44)
        Me.btnNavMatkul.TabIndex = 1
        Me.btnNavMatkul.Text = "📋  Daftar Mata Kuliah"
        Me.btnNavMatkul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNavMatkul.UseVisualStyleBackColor = False

        '
        ' btnNavStatistik
        '
        Me.btnNavStatistik.BackColor = System.Drawing.Color.Transparent
        Me.btnNavStatistik.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavStatistik.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnNavStatistik.FlatAppearance.BorderSize = 0
        Me.btnNavStatistik.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavStatistik.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnNavStatistik.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.btnNavStatistik.Location = New System.Drawing.Point(16, 100)
        Me.btnNavStatistik.Name = "btnNavStatistik"
        Me.btnNavStatistik.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.btnNavStatistik.Size = New System.Drawing.Size(228, 44)
        Me.btnNavStatistik.TabIndex = 2
        Me.btnNavStatistik.Text = "📊  Statistik Pengisian"
        Me.btnNavStatistik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNavStatistik.UseVisualStyleBackColor = False

        '
        ' btnNavBantuan
        '
        Me.btnNavBantuan.BackColor = System.Drawing.Color.Transparent
        Me.btnNavBantuan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavBantuan.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnNavBantuan.FlatAppearance.BorderSize = 0
        Me.btnNavBantuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavBantuan.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnNavBantuan.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.btnNavBantuan.Location = New System.Drawing.Point(16, 144)
        Me.btnNavBantuan.Name = "btnNavBantuan"
        Me.btnNavBantuan.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.btnNavBantuan.Size = New System.Drawing.Size(228, 44)
        Me.btnNavBantuan.TabIndex = 3
        Me.btnNavBantuan.Text = "ℹ️  Panduan & Kriteria"
        Me.btnNavBantuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNavBantuan.UseVisualStyleBackColor = False

        '
        ' pnlUserCard (Bottom Profile Card in Sidebar)
        '
        Me.pnlUserCard.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.pnlUserCard.Controls.Add(Me.btnLogout)
        Me.pnlUserCard.Controls.Add(Me.lblSidebarUserRole)
        Me.pnlUserCard.Controls.Add(Me.lblSidebarUserName)
        Me.pnlUserCard.Controls.Add(Me.picUserAvatar)
        Me.pnlUserCard.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlUserCard.Location = New System.Drawing.Point(0, 686)
        Me.pnlUserCard.Name = "pnlUserCard"
        Me.pnlUserCard.Padding = New System.Windows.Forms.Padding(16, 12, 16, 12)
        Me.pnlUserCard.Size = New System.Drawing.Size(260, 114)
        Me.pnlUserCard.TabIndex = 2

        '
        ' picUserAvatar
        '
        Me.picUserAvatar.Location = New System.Drawing.Point(16, 14)
        Me.picUserAvatar.Name = "picUserAvatar"
        Me.picUserAvatar.Size = New System.Drawing.Size(38, 38)
        Me.picUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picUserAvatar.TabIndex = 0
        Me.picUserAvatar.TabStop = False

        '
        ' lblSidebarUserName
        '
        Me.lblSidebarUserName.AutoSize = True
        Me.lblSidebarUserName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblSidebarUserName.ForeColor = System.Drawing.Color.White
        Me.lblSidebarUserName.Location = New System.Drawing.Point(58, 14)
        Me.lblSidebarUserName.Name = "lblSidebarUserName"
        Me.lblSidebarUserName.Size = New System.Drawing.Size(120, 17)
        Me.lblSidebarUserName.TabIndex = 1
        Me.lblSidebarUserName.Text = "Bagus Wijaya C. U."

        '
        ' lblSidebarUserRole
        '
        Me.lblSidebarUserRole.AutoSize = True
        Me.lblSidebarUserRole.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblSidebarUserRole.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblSidebarUserRole.Location = New System.Drawing.Point(60, 34)
        Me.lblSidebarUserRole.Name = "lblSidebarUserRole"
        Me.lblSidebarUserRole.Size = New System.Drawing.Size(117, 15)
        Me.lblSidebarUserRole.TabIndex = 2
        Me.lblSidebarUserRole.Text = "Mahasiswa • TI-3C"

        '
        ' btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnLogout.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnLogout.Location = New System.Drawing.Point(16, 64)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(228, 32)
        Me.btnLogout.TabIndex = 3
        Me.btnLogout.Text = "🚪 Keluar dari Akun"
        Me.btnLogout.UseVisualStyleBackColor = False

        '
        ' pnlMainContainer (Right Side)
        '
        Me.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(241, 245, 249) ' #F1F5F9 Soft Slate
        Me.pnlMainContainer.Controls.Add(Me.pnlScrollBody)
        Me.pnlMainContainer.Controls.Add(Me.pnlTopbar)
        Me.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainContainer.Location = New System.Drawing.Point(260, 0)
        Me.pnlMainContainer.Name = "pnlMainContainer"
        Me.pnlMainContainer.Size = New System.Drawing.Size(980, 800)
        Me.pnlMainContainer.TabIndex = 1

        '
        ' pnlTopbar (White Clean Top Navigation)
        '
        Me.pnlTopbar.BackColor = System.Drawing.Color.White
        Me.pnlTopbar.Controls.Add(Me.cboTahunAkademik)
        Me.pnlTopbar.Controls.Add(Me.pnlSearchBox)
        Me.pnlTopbar.Controls.Add(Me.lblBreadcrumbSub)
        Me.pnlTopbar.Controls.Add(Me.lblBreadcrumbTitle)
        Me.pnlTopbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopbar.Name = "pnlTopbar"
        Me.pnlTopbar.Padding = New System.Windows.Forms.Padding(28, 12, 28, 12)
        Me.pnlTopbar.Size = New System.Drawing.Size(980, 68)
        Me.pnlTopbar.TabIndex = 0

        '
        ' lblBreadcrumbTitle
        '
        Me.lblBreadcrumbTitle.AutoSize = True
        Me.lblBreadcrumbTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblBreadcrumbTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblBreadcrumbTitle.Location = New System.Drawing.Point(24, 14)
        Me.lblBreadcrumbTitle.Name = "lblBreadcrumbTitle"
        Me.lblBreadcrumbTitle.Size = New System.Drawing.Size(262, 21)
        Me.lblBreadcrumbTitle.TabIndex = 0
        Me.lblBreadcrumbTitle.Text = "Evaluasi Dosen Mengajar (EDOM)"

        '
        ' lblBreadcrumbSub
        '
        Me.lblBreadcrumbSub.AutoSize = True
        Me.lblBreadcrumbSub.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblBreadcrumbSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblBreadcrumbSub.Location = New System.Drawing.Point(26, 38)
        Me.lblBreadcrumbSub.Name = "lblBreadcrumbSub"
        Me.lblBreadcrumbSub.Size = New System.Drawing.Size(225, 15)
        Me.lblBreadcrumbSub.TabIndex = 1
        Me.lblBreadcrumbSub.Text = "Semester Ganjil • Kelas TI-3C • Angkatan 22"

        '
        ' cboTahunAkademik (Top Right Dropdown)
        '
        Me.cboTahunAkademik.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTahunAkademik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTahunAkademik.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cboTahunAkademik.FormattingEnabled = True
        Me.cboTahunAkademik.Location = New System.Drawing.Point(768, 20)
        Me.cboTahunAkademik.Name = "cboTahunAkademik"
        Me.cboTahunAkademik.Size = New System.Drawing.Size(184, 25)
        Me.cboTahunAkademik.TabIndex = 3

        '
        ' pnlSearchBox (Modern Search Pill)
        '
        Me.pnlSearchBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSearchBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlSearchBox.Controls.Add(Me.txtSearch)
        Me.pnlSearchBox.Controls.Add(Me.lblSearchIcon)
        Me.pnlSearchBox.Location = New System.Drawing.Point(490, 17)
        Me.pnlSearchBox.Name = "pnlSearchBox"
        Me.pnlSearchBox.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlSearchBox.Size = New System.Drawing.Size(262, 34)
        Me.pnlSearchBox.TabIndex = 2

        '
        ' lblSearchIcon
        '
        Me.lblSearchIcon.AutoSize = True
        Me.lblSearchIcon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblSearchIcon.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblSearchIcon.Location = New System.Drawing.Point(8, 9)
        Me.lblSearchIcon.Name = "lblSearchIcon"
        Me.lblSearchIcon.Size = New System.Drawing.Size(21, 15)
        Me.lblSearchIcon.TabIndex = 0
        Me.lblSearchIcon.Text = "🔍"

        '
        ' txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtSearch.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.txtSearch.Location = New System.Drawing.Point(34, 8)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.PlaceholderText = "Cari mata kuliah / dosen..."
        Me.txtSearch.Size = New System.Drawing.Size(218, 17)
        Me.txtSearch.TabIndex = 1

        '
        ' pnlScrollBody
        '
        Me.pnlScrollBody.AutoScroll = True
        Me.pnlScrollBody.Controls.Add(Me.pnlContent)
        Me.pnlScrollBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlScrollBody.Location = New System.Drawing.Point(0, 68)
        Me.pnlScrollBody.Name = "pnlScrollBody"
        Me.pnlScrollBody.Padding = New System.Windows.Forms.Padding(28, 20, 28, 30)
        Me.pnlScrollBody.Size = New System.Drawing.Size(980, 732)
        Me.pnlScrollBody.TabIndex = 1

        '
        ' pnlContent (Container inside scroll panel)
        '
        Me.pnlContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContent.AutoSize = True
        Me.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlContent.Controls.Add(Me.pnlTableCard)
        Me.pnlContent.Controls.Add(Me.pnlAlert)
        Me.pnlContent.Controls.Add(Me.pnlKpiRow)
        Me.pnlContent.Location = New System.Drawing.Point(28, 20)
        Me.pnlContent.MinimumSize = New System.Drawing.Size(860, 600)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(924, 860)
        Me.pnlContent.TabIndex = 0

        '
        ' pnlKpiRow (Top 3 Modern Summary Cards)
        '
        Me.pnlKpiRow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKpiRow.Controls.Add(Me.cardDeadline)
        Me.pnlKpiRow.Controls.Add(Me.cardProgress)
        Me.pnlKpiRow.Controls.Add(Me.cardTotalMatkul)
        Me.pnlKpiRow.Location = New System.Drawing.Point(0, 0)
        Me.pnlKpiRow.Name = "pnlKpiRow"
        Me.pnlKpiRow.Size = New System.Drawing.Size(924, 105)
        Me.pnlKpiRow.TabIndex = 0

        '
        ' cardTotalMatkul (Card 1)
        '
        Me.cardTotalMatkul.BackColor = System.Drawing.Color.White
        Me.cardTotalMatkul.Controls.Add(Me.lblKpi1Badge)
        Me.cardTotalMatkul.Controls.Add(Me.lblKpi1Value)
        Me.cardTotalMatkul.Controls.Add(Me.lblKpi1Title)
        Me.cardTotalMatkul.Location = New System.Drawing.Point(0, 0)
        Me.cardTotalMatkul.Name = "cardTotalMatkul"
        Me.cardTotalMatkul.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)
        Me.cardTotalMatkul.Size = New System.Drawing.Size(292, 100)
        Me.cardTotalMatkul.TabIndex = 0

        '
        ' lblKpi1Title
        '
        Me.lblKpi1Title.AutoSize = True
        Me.lblKpi1Title.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblKpi1Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblKpi1Title.Location = New System.Drawing.Point(16, 14)
        Me.lblKpi1Title.Name = "lblKpi1Title"
        Me.lblKpi1Title.Size = New System.Drawing.Size(109, 15)
        Me.lblKpi1Title.TabIndex = 0
        Me.lblKpi1Title.Text = "TOTAL MATA KULIAH"

        '
        ' lblKpi1Value
        '
        Me.lblKpi1Value.AutoSize = True
        Me.lblKpi1Value.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblKpi1Value.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpi1Value.Location = New System.Drawing.Point(14, 34)
        Me.lblKpi1Value.Name = "lblKpi1Value"
        Me.lblKpi1Value.Size = New System.Drawing.Size(161, 32)
        Me.lblKpi1Value.TabIndex = 1
        Me.lblKpi1Value.Text = "10 Matakuliah"

        '
        ' lblKpi1Badge
        '
        Me.lblKpi1Badge.AutoSize = True
        Me.lblKpi1Badge.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblKpi1Badge.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199)
        Me.lblKpi1Badge.Location = New System.Drawing.Point(16, 68)
        Me.lblKpi1Badge.Name = "lblKpi1Badge"
        Me.lblKpi1Badge.Size = New System.Drawing.Size(155, 15)
        Me.lblKpi1Badge.TabIndex = 2
        Me.lblKpi1Badge.Text = "Semester 3C • TI Terakreditasi"

        '
        ' cardProgress (Card 2 - Progress EDOM)
        '
        Me.cardProgress.BackColor = System.Drawing.Color.White
        Me.cardProgress.Controls.Add(Me.pnlProgressBarBg)
        Me.cardProgress.Controls.Add(Me.lblKpi2Value)
        Me.cardProgress.Controls.Add(Me.lblKpi2Title)
        Me.cardProgress.Location = New System.Drawing.Point(312, 0)
        Me.cardProgress.Name = "cardProgress"
        Me.cardProgress.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)
        Me.cardProgress.Size = New System.Drawing.Size(292, 100)
        Me.cardProgress.TabIndex = 1

        '
        ' lblKpi2Title
        '
        Me.lblKpi2Title.AutoSize = True
        Me.lblKpi2Title.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblKpi2Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblKpi2Title.Location = New System.Drawing.Point(16, 14)
        Me.lblKpi2Title.Name = "lblKpi2Title"
        Me.lblKpi2Title.Size = New System.Drawing.Size(130, 15)
        Me.lblKpi2Title.TabIndex = 0
        Me.lblKpi2Title.Text = "PROGRESS PENGISIAN"

        '
        ' lblKpi2Value
        '
        Me.lblKpi2Value.AutoSize = True
        Me.lblKpi2Value.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblKpi2Value.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138) ' Primary Blue
        Me.lblKpi2Value.Location = New System.Drawing.Point(14, 34)
        Me.lblKpi2Value.Name = "lblKpi2Value"
        Me.lblKpi2Value.Size = New System.Drawing.Size(188, 32)
        Me.lblKpi2Value.TabIndex = 1
        Me.lblKpi2Value.Text = "0 / 10 Selesai (0%)"

        '
        ' pnlProgressBarBg
        '
        Me.pnlProgressBarBg.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.pnlProgressBarBg.Controls.Add(Me.pnlProgressBarFill)
        Me.pnlProgressBarBg.Location = New System.Drawing.Point(18, 72)
        Me.pnlProgressBarBg.Name = "pnlProgressBarBg"
        Me.pnlProgressBarBg.Size = New System.Drawing.Size(256, 8)
        Me.pnlProgressBarBg.TabIndex = 2

        '
        ' pnlProgressBarFill
        '
        Me.pnlProgressBarFill.BackColor = System.Drawing.Color.FromArgb(2, 132, 199) ' Tertiary Cyan
        Me.pnlProgressBarFill.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlProgressBarFill.Location = New System.Drawing.Point(0, 0)
        Me.pnlProgressBarFill.Name = "pnlProgressBarFill"
        Me.pnlProgressBarFill.Size = New System.Drawing.Size(0, 8)
        Me.pnlProgressBarFill.TabIndex = 0

        '
        ' cardDeadline (Card 3 - Batas Pengisian)
        '
        Me.cardDeadline.BackColor = System.Drawing.Color.White
        Me.cardDeadline.Controls.Add(Me.lblKpi3Sub)
        Me.cardDeadline.Controls.Add(Me.lblKpi3Value)
        Me.cardDeadline.Controls.Add(Me.lblKpi3Title)
        Me.cardDeadline.Location = New System.Drawing.Point(624, 0)
        Me.cardDeadline.Name = "cardDeadline"
        Me.cardDeadline.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)
        Me.cardDeadline.Size = New System.Drawing.Size(292, 100)
        Me.cardDeadline.TabIndex = 2

        '
        ' lblKpi3Title
        '
        Me.lblKpi3Title.AutoSize = True
        Me.lblKpi3Title.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblKpi3Title.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblKpi3Title.Location = New System.Drawing.Point(16, 14)
        Me.lblKpi3Title.Name = "lblKpi3Title"
        Me.lblKpi3Title.Size = New System.Drawing.Size(107, 15)
        Me.lblKpi3Title.TabIndex = 0
        Me.lblKpi3Title.Text = "BATAS PENGISIAN"

        '
        ' lblKpi3Value
        '
        Me.lblKpi3Value.AutoSize = True
        Me.lblKpi3Value.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblKpi3Value.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpi3Value.Location = New System.Drawing.Point(14, 34)
        Me.lblKpi3Value.Name = "lblKpi3Value"
        Me.lblKpi3Value.Size = New System.Drawing.Size(155, 32)
        Me.lblKpi3Value.TabIndex = 1
        Me.lblKpi3Value.Text = "23 Des 2026"

        '
        ' lblKpi3Sub
        '
        Me.lblKpi3Sub.AutoSize = True
        Me.lblKpi3Sub.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblKpi3Sub.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129) ' Green
        Me.lblKpi3Sub.Location = New System.Drawing.Point(16, 68)
        Me.lblKpi3Sub.Name = "lblKpi3Sub"
        Me.lblKpi3Sub.Size = New System.Drawing.Size(184, 15)
        Me.lblKpi3Sub.TabIndex = 2
        Me.lblKpi3Sub.Text = "🟢 Periode Terbuka (Aktif)"

        '
        ' pnlAlert (Modern Notice Banner)
        '
        Me.pnlAlert.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAlert.BackColor = System.Drawing.Color.FromArgb(239, 246, 255) ' Soft Blue Tint #EFF6FF
        Me.pnlAlert.Controls.Add(Me.lblAlertText)
        Me.pnlAlert.Controls.Add(Me.lblAlertIcon)
        Me.pnlAlert.Location = New System.Drawing.Point(0, 118)
        Me.pnlAlert.Name = "pnlAlert"
        Me.pnlAlert.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.pnlAlert.Size = New System.Drawing.Size(924, 48)
        Me.pnlAlert.TabIndex = 1

        '
        ' lblAlertIcon
        '
        Me.lblAlertIcon.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblAlertIcon.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199)
        Me.lblAlertIcon.Location = New System.Drawing.Point(12, 10)
        Me.lblAlertIcon.Name = "lblAlertIcon"
        Me.lblAlertIcon.Size = New System.Drawing.Size(26, 26)
        Me.lblAlertIcon.TabIndex = 0
        Me.lblAlertIcon.Text = "ℹ️"
        Me.lblAlertIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '
        ' lblAlertText
        '
        Me.lblAlertText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAlertText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblAlertText.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138)
        Me.lblAlertText.Location = New System.Drawing.Point(44, 11)
        Me.lblAlertText.Name = "lblAlertText"
        Me.lblAlertText.Size = New System.Drawing.Size(864, 25)
        Me.lblAlertText.TabIndex = 1
        Me.lblAlertText.Text = "Pengisian EDOM bersifat wajib bagi seluruh mahasiswa kelas 3C sebagai syarat perc" &
    "etakan Kartu Hasil Studi (KHS)."
        Me.lblAlertText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        '
        ' pnlTableCard (Modern Table Container)
        '
        Me.pnlTableCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTableCard.BackColor = System.Drawing.Color.White
        Me.pnlTableCard.Controls.Add(Me.dgvEdom)
        Me.pnlTableCard.Controls.Add(Me.lblTablePeriode)
        Me.pnlTableCard.Controls.Add(Me.lblTableCountBadge)
        Me.pnlTableCard.Controls.Add(Me.lblTableTitle)
        Me.pnlTableCard.Location = New System.Drawing.Point(0, 180)
        Me.pnlTableCard.Name = "pnlTableCard"
        Me.pnlTableCard.Padding = New System.Windows.Forms.Padding(20, 18, 20, 20)
        Me.pnlTableCard.Size = New System.Drawing.Size(924, 650)
        Me.pnlTableCard.TabIndex = 2

        '
        ' lblTableTitle
        '
        Me.lblTableTitle.AutoSize = True
        Me.lblTableTitle.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblTableTitle.Location = New System.Drawing.Point(18, 16)
        Me.lblTableTitle.Name = "lblTableTitle"
        Me.lblTableTitle.Size = New System.Drawing.Size(268, 21)
        Me.lblTableTitle.TabIndex = 0
        Me.lblTableTitle.Text = "Daftar Mata Kuliah Semester Ini"

        '
        ' lblTableCountBadge
        '
        Me.lblTableCountBadge.AutoSize = True
        Me.lblTableCountBadge.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.lblTableCountBadge.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTableCountBadge.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138)
        Me.lblTableCountBadge.Location = New System.Drawing.Point(292, 18)
        Me.lblTableCountBadge.Name = "lblTableCountBadge"
        Me.lblTableCountBadge.Padding = New System.Windows.Forms.Padding(8, 2, 8, 2)
        Me.lblTableCountBadge.Size = New System.Drawing.Size(100, 19)
        Me.lblTableCountBadge.TabIndex = 1
        Me.lblTableCountBadge.Text = "10 Mata Kuliah"
        Me.lblTableCountBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '
        ' lblTablePeriode
        '
        Me.lblTablePeriode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTablePeriode.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblTablePeriode.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblTablePeriode.Location = New System.Drawing.Point(420, 18)
        Me.lblTablePeriode.Name = "lblTablePeriode"
        Me.lblTablePeriode.Size = New System.Drawing.Size(484, 20)
        Me.lblTablePeriode.TabIndex = 2
        Me.lblTablePeriode.Text = "Periode Pengisian: Senin, 30 Nov 2026 s/d Rabu, 23 Des 2026"
        Me.lblTablePeriode.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        '
        ' dgvEdom (Modern Flat Table)
        '
        Me.dgvEdom.AllowUserToAddRows = False
        Me.dgvEdom.AllowUserToDeleteRows = False
        Me.dgvEdom.AllowUserToResizeRows = False
        Me.dgvEdom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEdom.BackgroundColor = System.Drawing.Color.White
        Me.dgvEdom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEdom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal

        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEdom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
        Me.dgvEdom.ColumnHeadersHeight = 44
        Me.dgvEdom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEdom.DefaultCellStyle = dataGridViewCellStyle2

        Me.dgvEdom.EnableHeadersVisualStyles = False
        Me.dgvEdom.GridColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.dgvEdom.Location = New System.Drawing.Point(18, 52)
        Me.dgvEdom.MultiSelect = False
        Me.dgvEdom.Name = "dgvEdom"
        Me.dgvEdom.ReadOnly = True
        Me.dgvEdom.RowHeadersVisible = False
        Me.dgvEdom.RowTemplate.Height = 56
        Me.dgvEdom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEdom.Size = New System.Drawing.Size(886, 580)
        Me.dgvEdom.TabIndex = 3

        '
        ' Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.ClientSize = New System.Drawing.Size(1240, 800)
        Me.Controls.Add(Me.pnlMainContainer)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MinimumSize = New System.Drawing.Size(1050, 700)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EDOM Portal - Sistem Evaluasi Dosen Mengajar (Politeknik Negeri Jakarta)"

        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlUserCard.ResumeLayout(False)
        Me.pnlUserCard.PerformLayout()
        CType(Me.picUserAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavContainer.ResumeLayout(False)
        Me.pnlBrand.ResumeLayout(False)
        Me.pnlBrand.PerformLayout()
        CType(Me.picSidebarLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMainContainer.ResumeLayout(False)
        Me.pnlScrollBody.ResumeLayout(False)
        Me.pnlScrollBody.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlTableCard.ResumeLayout(False)
        Me.pnlTableCard.PerformLayout()
        CType(Me.dgvEdom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAlert.ResumeLayout(False)
        Me.pnlKpiRow.ResumeLayout(False)
        Me.cardDeadline.ResumeLayout(False)
        Me.cardDeadline.PerformLayout()
        Me.cardProgress.ResumeLayout(False)
        Me.cardProgress.PerformLayout()
        Me.pnlProgressBarBg.ResumeLayout(False)
        Me.cardTotalMatkul.ResumeLayout(False)
        Me.cardTotalMatkul.PerformLayout()
        Me.pnlTopbar.ResumeLayout(False)
        Me.pnlTopbar.PerformLayout()
        Me.pnlSearchBox.ResumeLayout(False)
        Me.pnlSearchBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

End Class
