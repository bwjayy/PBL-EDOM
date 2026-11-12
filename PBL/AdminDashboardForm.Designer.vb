<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminDashboardForm
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
    Friend WithEvents lblNavHeader As System.Windows.Forms.Label
    Friend WithEvents btnNavDashboard As System.Windows.Forms.Button
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
    Friend WithEvents lblBadgeProdi As System.Windows.Forms.Label

    ' Scrollable Body
    Friend WithEvents pnlScrollBody As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel

    ' KPI Cards
    Friend WithEvents pnlKpiRow As System.Windows.Forms.Panel
    Friend WithEvents cardDosen As System.Windows.Forms.Panel
    Friend WithEvents lblKpi1Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi1Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi1Sub As System.Windows.Forms.Label

    Friend WithEvents cardMhs As System.Windows.Forms.Panel
    Friend WithEvents lblKpi2Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi2Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi2Sub As System.Windows.Forms.Label

    Friend WithEvents cardKelas As System.Windows.Forms.Panel
    Friend WithEvents lblKpi3Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi3Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi3Sub As System.Windows.Forms.Label

    ' Table Area & Toolbar
    Friend WithEvents pnlTableCard As System.Windows.Forms.Panel
    Friend WithEvents pnlTableToolbar As System.Windows.Forms.Panel
    Friend WithEvents btnTabDosen As System.Windows.Forms.Button
    Friend WithEvents btnTabMahasiswa As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents pnlSearchBox As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchIcon As System.Windows.Forms.Label
    Friend WithEvents lblTableTitle As System.Windows.Forms.Label
    Friend WithEvents lblTableSub As System.Windows.Forms.Label
    Friend WithEvents dgvAdminData As System.Windows.Forms.DataGridView

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim dataGridViewCellStyle1 As New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle2 As New System.Windows.Forms.DataGridViewCellStyle()
        pnlSidebar = New System.Windows.Forms.Panel()
        pnlUserCard = New System.Windows.Forms.Panel()
        btnLogout = New System.Windows.Forms.Button()
        lblSidebarUserRole = New System.Windows.Forms.Label()
        lblSidebarUserName = New System.Windows.Forms.Label()
        picUserAvatar = New System.Windows.Forms.PictureBox()
        pnlNavContainer = New System.Windows.Forms.Panel()
        btnNavDashboard = New System.Windows.Forms.Button()
        lblNavHeader = New System.Windows.Forms.Label()
        pnlBrand = New System.Windows.Forms.Panel()
        lblSidebarSub = New System.Windows.Forms.Label()
        lblSidebarBrand = New System.Windows.Forms.Label()
        picSidebarLogo = New System.Windows.Forms.PictureBox()
        pnlMainContainer = New System.Windows.Forms.Panel()
        pnlScrollBody = New System.Windows.Forms.Panel()
        pnlContent = New System.Windows.Forms.Panel()
        pnlTableCard = New System.Windows.Forms.Panel()
        dgvAdminData = New System.Windows.Forms.DataGridView()
        pnlTableToolbar = New System.Windows.Forms.Panel()
        btnRefresh = New System.Windows.Forms.Button()
        pnlSearchBox = New System.Windows.Forms.Panel()
        txtSearch = New System.Windows.Forms.TextBox()
        lblSearchIcon = New System.Windows.Forms.Label()
        btnTabMahasiswa = New System.Windows.Forms.Button()
        btnTabDosen = New System.Windows.Forms.Button()
        lblTableSub = New System.Windows.Forms.Label()
        lblTableTitle = New System.Windows.Forms.Label()
        pnlKpiRow = New System.Windows.Forms.Panel()
        cardKelas = New System.Windows.Forms.Panel()
        lblKpi3Sub = New System.Windows.Forms.Label()
        lblKpi3Value = New System.Windows.Forms.Label()
        lblKpi3Title = New System.Windows.Forms.Label()
        cardMhs = New System.Windows.Forms.Panel()
        lblKpi2Sub = New System.Windows.Forms.Label()
        lblKpi2Value = New System.Windows.Forms.Label()
        lblKpi2Title = New System.Windows.Forms.Label()
        cardDosen = New System.Windows.Forms.Panel()
        lblKpi1Sub = New System.Windows.Forms.Label()
        lblKpi1Value = New System.Windows.Forms.Label()
        lblKpi1Title = New System.Windows.Forms.Label()
        pnlTopbar = New System.Windows.Forms.Panel()
        lblBadgeProdi = New System.Windows.Forms.Label()
        lblBreadcrumbSub = New System.Windows.Forms.Label()
        lblBreadcrumbTitle = New System.Windows.Forms.Label()
        pnlSidebar.SuspendLayout()
        pnlUserCard.SuspendLayout()
        CType(picUserAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        pnlNavContainer.SuspendLayout()
        pnlBrand.SuspendLayout()
        CType(picSidebarLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        pnlMainContainer.SuspendLayout()
        pnlScrollBody.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlTableCard.SuspendLayout()
        CType(dgvAdminData, System.ComponentModel.ISupportInitialize).BeginInit()
        pnlTableToolbar.SuspendLayout()
        pnlSearchBox.SuspendLayout()
        pnlKpiRow.SuspendLayout()
        cardKelas.SuspendLayout()
        cardMhs.SuspendLayout()
        cardDosen.SuspendLayout()
        pnlTopbar.SuspendLayout()
        SuspendLayout()
        '
        ' pnlSidebar
        '
        pnlSidebar.BackColor = System.Drawing.Color.White
        pnlSidebar.Controls.Add(pnlUserCard)
        pnlSidebar.Controls.Add(pnlNavContainer)
        pnlSidebar.Controls.Add(pnlBrand)
        pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        pnlSidebar.Location = New System.Drawing.Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New System.Drawing.Size(240, 750)
        pnlSidebar.TabIndex = 0
        '
        ' pnlUserCard
        '
        pnlUserCard.Controls.Add(btnLogout)
        pnlUserCard.Controls.Add(lblSidebarUserRole)
        pnlUserCard.Controls.Add(lblSidebarUserName)
        pnlUserCard.Controls.Add(picUserAvatar)
        pnlUserCard.Dock = System.Windows.Forms.DockStyle.Bottom
        pnlUserCard.Location = New System.Drawing.Point(0, 640)
        pnlUserCard.Name = "pnlUserCard"
        pnlUserCard.Size = New System.Drawing.Size(240, 110)
        pnlUserCard.TabIndex = 2
        '
        ' btnLogout
        '
        btnLogout.BackColor = System.Drawing.Color.White
        btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        btnLogout.ForeColor = System.Drawing.Color.FromArgb(CByte(220), CByte(38), CByte(38))
        btnLogout.Location = New System.Drawing.Point(16, 68)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New System.Drawing.Size(208, 30)
        btnLogout.TabIndex = 3
        btnLogout.Text = "Keluar"
        btnLogout.UseVisualStyleBackColor = False
        '
        ' lblSidebarUserRole
        '
        lblSidebarUserRole.AutoEllipsis = True
        lblSidebarUserRole.Font = New System.Drawing.Font("Segoe UI", 7.75F)
        lblSidebarUserRole.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSidebarUserRole.Location = New System.Drawing.Point(62, 38)
        lblSidebarUserRole.Name = "lblSidebarUserRole"
        lblSidebarUserRole.Size = New System.Drawing.Size(162, 18)
        lblSidebarUserRole.TabIndex = 2
        lblSidebarUserRole.Text = "Admin Program Studi"
        '
        ' lblSidebarUserName
        '
        lblSidebarUserName.AutoEllipsis = True
        lblSidebarUserName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0F, System.Drawing.FontStyle.Bold)
        lblSidebarUserName.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblSidebarUserName.Location = New System.Drawing.Point(62, 18)
        lblSidebarUserName.Name = "lblSidebarUserName"
        lblSidebarUserName.Size = New System.Drawing.Size(162, 20)
        lblSidebarUserName.TabIndex = 1
        lblSidebarUserName.Text = "Nama Admin"
        '
        ' picUserAvatar
        '
        picUserAvatar.Location = New System.Drawing.Point(16, 16)
        picUserAvatar.Name = "picUserAvatar"
        picUserAvatar.Size = New System.Drawing.Size(38, 38)
        picUserAvatar.TabIndex = 0
        picUserAvatar.TabStop = False
        '
        ' pnlNavContainer
        '
        pnlNavContainer.Controls.Add(btnNavDashboard)
        pnlNavContainer.Controls.Add(lblNavHeader)
        pnlNavContainer.Dock = System.Windows.Forms.DockStyle.Fill
        pnlNavContainer.Location = New System.Drawing.Point(0, 72)
        pnlNavContainer.Name = "pnlNavContainer"
        pnlNavContainer.Padding = New System.Windows.Forms.Padding(16, 16, 16, 0)
        pnlNavContainer.Size = New System.Drawing.Size(240, 678)
        pnlNavContainer.TabIndex = 1
        '
        ' btnNavDashboard
        '
        btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        btnNavDashboard.FlatAppearance.BorderSize = 0
        btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnNavDashboard.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0F, System.Drawing.FontStyle.Bold)
        btnNavDashboard.ForeColor = System.Drawing.Color.White
        btnNavDashboard.Location = New System.Drawing.Point(16, 38)
        btnNavDashboard.Name = "btnNavDashboard"
        btnNavDashboard.Size = New System.Drawing.Size(208, 38)
        btnNavDashboard.TabIndex = 1
        btnNavDashboard.Text = "Kelola Data Prodi"
        btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        btnNavDashboard.UseVisualStyleBackColor = False
        '
        ' lblNavHeader
        '
        lblNavHeader.AutoSize = True
        lblNavHeader.Font = New System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold)
        lblNavHeader.ForeColor = System.Drawing.Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblNavHeader.Location = New System.Drawing.Point(16, 16)
        lblNavHeader.Name = "lblNavHeader"
        lblNavHeader.Size = New System.Drawing.Size(68, 12)
        lblNavHeader.TabIndex = 0
        lblNavHeader.Text = "MENU UTAMA"
        '
        ' pnlBrand
        '
        pnlBrand.Controls.Add(lblSidebarSub)
        pnlBrand.Controls.Add(lblSidebarBrand)
        pnlBrand.Controls.Add(picSidebarLogo)
        pnlBrand.Dock = System.Windows.Forms.DockStyle.Top
        pnlBrand.Location = New System.Drawing.Point(0, 0)
        pnlBrand.Name = "pnlBrand"
        pnlBrand.Size = New System.Drawing.Size(240, 72)
        pnlBrand.TabIndex = 0
        '
        ' lblSidebarSub
        '
        lblSidebarSub.AutoSize = True
        lblSidebarSub.Font = New System.Drawing.Font("Segoe UI", 7.5F)
        lblSidebarSub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSidebarSub.Location = New System.Drawing.Point(58, 40)
        lblSidebarSub.Name = "lblSidebarSub"
        lblSidebarSub.Size = New System.Drawing.Size(126, 12)
        lblSidebarSub.TabIndex = 2
        lblSidebarSub.Text = "Politeknik Negeri Jakarta"
        '
        ' lblSidebarBrand
        '
        lblSidebarBrand.AutoSize = True
        lblSidebarBrand.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold)
        lblSidebarBrand.ForeColor = System.Drawing.Color.FromArgb(CByte(10), CByte(37), CByte(88))
        lblSidebarBrand.Location = New System.Drawing.Point(58, 18)
        lblSidebarBrand.Name = "lblSidebarBrand"
        lblSidebarBrand.Size = New System.Drawing.Size(97, 21)
        lblSidebarBrand.TabIndex = 1
        lblSidebarBrand.Text = "EDOM PNJ"
        '
        ' picSidebarLogo
        '
        picSidebarLogo.Location = New System.Drawing.Point(16, 18)
        picSidebarLogo.Name = "picSidebarLogo"
        picSidebarLogo.Size = New System.Drawing.Size(36, 36)
        picSidebarLogo.TabIndex = 0
        picSidebarLogo.TabStop = False
        '
        ' pnlMainContainer
        '
        pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlMainContainer.Controls.Add(pnlScrollBody)
        pnlMainContainer.Controls.Add(pnlTopbar)
        pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        pnlMainContainer.Location = New System.Drawing.Point(240, 0)
        pnlMainContainer.Name = "pnlMainContainer"
        pnlMainContainer.Size = New System.Drawing.Size(960, 750)
        pnlMainContainer.TabIndex = 1
        '
        ' pnlScrollBody
        '
        pnlScrollBody.AutoScroll = True
        pnlScrollBody.Controls.Add(pnlContent)
        pnlScrollBody.Dock = System.Windows.Forms.DockStyle.Fill
        pnlScrollBody.Location = New System.Drawing.Point(0, 72)
        pnlScrollBody.Name = "pnlScrollBody"
        pnlScrollBody.Size = New System.Drawing.Size(960, 678)
        pnlScrollBody.TabIndex = 1
        '
        ' pnlContent
        '
        pnlContent.Controls.Add(pnlTableCard)
        pnlContent.Controls.Add(pnlKpiRow)
        pnlContent.Location = New System.Drawing.Point(32, 24)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New System.Drawing.Size(896, 630)
        pnlContent.TabIndex = 0
        '
        ' pnlTableCard
        '
        pnlTableCard.BackColor = System.Drawing.Color.White
        pnlTableCard.Controls.Add(dgvAdminData)
        pnlTableCard.Controls.Add(pnlTableToolbar)
        pnlTableCard.Controls.Add(lblTableSub)
        pnlTableCard.Controls.Add(lblTableTitle)
        pnlTableCard.Location = New System.Drawing.Point(0, 146)
        pnlTableCard.Name = "pnlTableCard"
        pnlTableCard.Padding = New System.Windows.Forms.Padding(20)
        pnlTableCard.Size = New System.Drawing.Size(896, 460)
        pnlTableCard.TabIndex = 1
        '
        ' dgvAdminData
        '
        dgvAdminData.AllowUserToAddRows = False
        dgvAdminData.AllowUserToDeleteRows = False
        dgvAdminData.BackgroundColor = System.Drawing.Color.White
        dgvAdminData.BorderStyle = System.Windows.Forms.BorderStyle.None
        dgvAdminData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        dgvAdminData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
        dgvAdminData.ColumnHeadersHeight = 42
        dgvAdminData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CByte(241), CByte(245), CByte(249))
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        dgvAdminData.DefaultCellStyle = dataGridViewCellStyle2
        dgvAdminData.EnableHeadersVisualStyles = False
        dgvAdminData.Location = New System.Drawing.Point(20, 118)
        dgvAdminData.Name = "dgvAdminData"
        dgvAdminData.ReadOnly = True
        dgvAdminData.RowHeadersVisible = False
        dgvAdminData.RowTemplate.Height = 46
        dgvAdminData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        dgvAdminData.Size = New System.Drawing.Size(856, 320)
        dgvAdminData.TabIndex = 3
        '
        ' pnlTableToolbar
        '
        pnlTableToolbar.Controls.Add(btnRefresh)
        pnlTableToolbar.Controls.Add(pnlSearchBox)
        pnlTableToolbar.Controls.Add(btnTabMahasiswa)
        pnlTableToolbar.Controls.Add(btnTabDosen)
        pnlTableToolbar.Location = New System.Drawing.Point(20, 68)
        pnlTableToolbar.Name = "pnlTableToolbar"
        pnlTableToolbar.Size = New System.Drawing.Size(856, 42)
        pnlTableToolbar.TabIndex = 2
        '
        ' btnRefresh
        '
        btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        btnRefresh.BackColor = System.Drawing.Color.White
        btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnRefresh.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        btnRefresh.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        btnRefresh.Location = New System.Drawing.Point(756, 4)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New System.Drawing.Size(100, 32)
        btnRefresh.TabIndex = 3
        btnRefresh.Text = "Perbarui Data"
        btnRefresh.UseVisualStyleBackColor = False
        '
        ' pnlSearchBox
        '
        pnlSearchBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        pnlSearchBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlSearchBox.Controls.Add(txtSearch)
        pnlSearchBox.Controls.Add(lblSearchIcon)
        pnlSearchBox.Location = New System.Drawing.Point(510, 4)
        pnlSearchBox.Name = "pnlSearchBox"
        pnlSearchBox.Size = New System.Drawing.Size(236, 32)
        pnlSearchBox.TabIndex = 2
        '
        ' txtSearch
        '
        txtSearch.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        txtSearch.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtSearch.Location = New System.Drawing.Point(36, 8)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Nama, NIDN, atau NIM..."
        txtSearch.Size = New System.Drawing.Size(190, 16)
        txtSearch.TabIndex = 1
        '
        ' lblSearchIcon
        '
        lblSearchIcon.AutoSize = True
        lblSearchIcon.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        lblSearchIcon.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSearchIcon.Location = New System.Drawing.Point(6, 8)
        lblSearchIcon.Name = "lblSearchIcon"
        lblSearchIcon.Size = New System.Drawing.Size(28, 13)
        lblSearchIcon.TabIndex = 0
        lblSearchIcon.Text = "Cari:"
        '
        ' btnTabMahasiswa
        '
        btnTabMahasiswa.BackColor = System.Drawing.Color.White
        btnTabMahasiswa.Cursor = System.Windows.Forms.Cursors.Hand
        btnTabMahasiswa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnTabMahasiswa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnTabMahasiswa.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold)
        btnTabMahasiswa.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        btnTabMahasiswa.Location = New System.Drawing.Point(146, 4)
        btnTabMahasiswa.Name = "btnTabMahasiswa"
        btnTabMahasiswa.Size = New System.Drawing.Size(140, 32)
        btnTabMahasiswa.TabIndex = 1
        btnTabMahasiswa.Text = "Data Mahasiswa"
        btnTabMahasiswa.UseVisualStyleBackColor = False
        '
        ' btnTabDosen
        '
        btnTabDosen.BackColor = System.Drawing.Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnTabDosen.Cursor = System.Windows.Forms.Cursors.Hand
        btnTabDosen.FlatAppearance.BorderSize = 0
        btnTabDosen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnTabDosen.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold)
        btnTabDosen.ForeColor = System.Drawing.Color.White
        btnTabDosen.Location = New System.Drawing.Point(0, 4)
        btnTabDosen.Name = "btnTabDosen"
        btnTabDosen.Size = New System.Drawing.Size(138, 32)
        btnTabDosen.TabIndex = 0
        btnTabDosen.Text = "Data Dosen Prodi"
        btnTabDosen.UseVisualStyleBackColor = False
        '
        ' lblTableSub
        '
        lblTableSub.AutoSize = True
        lblTableSub.Font = New System.Drawing.Font("Segoe UI", 8.25F)
        lblTableSub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblTableSub.Location = New System.Drawing.Point(20, 42)
        lblTableSub.Name = "lblTableSub"
        lblTableSub.Size = New System.Drawing.Size(357, 13)
        lblTableSub.TabIndex = 1
        lblTableSub.Text = "Data sivitas akademika yang terafiliasi dengan program studi aktif"
        '
        ' lblTableTitle
        '
        lblTableTitle.AutoSize = True
        lblTableTitle.Font = New System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold)
        lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblTableTitle.Location = New System.Drawing.Point(20, 20)
        lblTableTitle.Name = "lblTableTitle"
        lblTableTitle.Size = New System.Drawing.Size(206, 20)
        lblTableTitle.TabIndex = 0
        lblTableTitle.Text = "Daftar Pengguna Prodi Aktif"
        '
        ' pnlKpiRow
        '
        pnlKpiRow.Controls.Add(cardKelas)
        pnlKpiRow.Controls.Add(cardMhs)
        pnlKpiRow.Controls.Add(cardDosen)
        pnlKpiRow.Location = New System.Drawing.Point(0, 0)
        pnlKpiRow.Name = "pnlKpiRow"
        pnlKpiRow.Size = New System.Drawing.Size(896, 120)
        pnlKpiRow.TabIndex = 0
        '
        ' cardKelas
        '
        cardKelas.BackColor = System.Drawing.Color.White
        cardKelas.Controls.Add(lblKpi3Sub)
        cardKelas.Controls.Add(lblKpi3Value)
        cardKelas.Controls.Add(lblKpi3Title)
        cardKelas.Location = New System.Drawing.Point(608, 0)
        cardKelas.Name = "cardKelas"
        cardKelas.Padding = New System.Windows.Forms.Padding(18)
        cardKelas.Size = New System.Drawing.Size(288, 120)
        cardKelas.TabIndex = 2
        '
        ' lblKpi3Sub
        '
        lblKpi3Sub.AutoSize = True
        lblKpi3Sub.Font = New System.Drawing.Font("Segoe UI", 8.0F)
        lblKpi3Sub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi3Sub.Location = New System.Drawing.Point(18, 86)
        lblKpi3Sub.Name = "lblKpi3Sub"
        lblKpi3Sub.Size = New System.Drawing.Size(187, 13)
        lblKpi3Sub.TabIndex = 2
        lblKpi3Sub.Text = "Tersebar di semester 1, 3, dan 5"
        '
        ' lblKpi3Value
        '
        lblKpi3Value.AutoSize = True
        lblKpi3Value.Font = New System.Drawing.Font("Segoe UI", 18.0F, System.Drawing.FontStyle.Bold)
        lblKpi3Value.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblKpi3Value.Location = New System.Drawing.Point(18, 44)
        lblKpi3Value.Name = "lblKpi3Value"
        lblKpi3Value.Size = New System.Drawing.Size(147, 32)
        lblKpi3Value.TabIndex = 1
        lblKpi3Value.Text = "16 Kelas Aktif"
        '
        ' lblKpi3Title
        '
        lblKpi3Title.AutoSize = True
        lblKpi3Title.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        lblKpi3Title.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi3Title.Location = New System.Drawing.Point(18, 18)
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.Size = New System.Drawing.Size(126, 13)
        lblKpi3Title.TabIndex = 0
        lblKpi3Title.Text = "TOTAL KELAS SEMESTER"
        '
        ' cardMhs
        '
        cardMhs.BackColor = System.Drawing.Color.White
        cardMhs.Controls.Add(lblKpi2Sub)
        cardMhs.Controls.Add(lblKpi2Value)
        cardMhs.Controls.Add(lblKpi2Title)
        cardMhs.Location = New System.Drawing.Point(304, 0)
        cardMhs.Name = "cardMhs"
        cardMhs.Padding = New System.Windows.Forms.Padding(18)
        cardMhs.Size = New System.Drawing.Size(288, 120)
        cardMhs.TabIndex = 1
        '
        ' lblKpi2Sub
        '
        lblKpi2Sub.AutoSize = True
        lblKpi2Sub.Font = New System.Drawing.Font("Segoe UI", 8.0F)
        lblKpi2Sub.ForeColor = System.Drawing.Color.FromArgb(CByte(5), CByte(150), CByte(105))
        lblKpi2Sub.Location = New System.Drawing.Point(18, 86)
        lblKpi2Sub.Name = "lblKpi2Sub"
        lblKpi2Sub.Size = New System.Drawing.Size(184, 13)
        lblKpi2Sub.TabIndex = 2
        lblKpi2Sub.Text = "85% telah menyelesaikan EDOM"
        '
        ' lblKpi2Value
        '
        lblKpi2Value.AutoSize = True
        lblKpi2Value.Font = New System.Drawing.Font("Segoe UI", 18.0F, System.Drawing.FontStyle.Bold)
        lblKpi2Value.ForeColor = System.Drawing.Color.FromArgb(CByte(10), CByte(37), CByte(88))
        lblKpi2Value.Location = New System.Drawing.Point(18, 44)
        lblKpi2Value.Name = "lblKpi2Value"
        lblKpi2Value.Size = New System.Drawing.Size(188, 32)
        lblKpi2Value.TabIndex = 1
        lblKpi2Value.Text = "142 Mahasiswa"
        '
        ' lblKpi2Title
        '
        lblKpi2Title.AutoSize = True
        lblKpi2Title.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        lblKpi2Title.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi2Title.Location = New System.Drawing.Point(18, 18)
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.Size = New System.Drawing.Size(147, 13)
        lblKpi2Title.TabIndex = 0
        lblKpi2Title.Text = "MAHASISWA AKTIF PRODI"
        '
        ' cardDosen
        '
        cardDosen.BackColor = System.Drawing.Color.White
        cardDosen.Controls.Add(lblKpi1Sub)
        cardDosen.Controls.Add(lblKpi1Value)
        cardDosen.Controls.Add(lblKpi1Title)
        cardDosen.Location = New System.Drawing.Point(0, 0)
        cardDosen.Name = "cardDosen"
        cardDosen.Padding = New System.Windows.Forms.Padding(18)
        cardDosen.Size = New System.Drawing.Size(288, 120)
        cardDosen.TabIndex = 0
        '
        ' lblKpi1Sub
        '
        lblKpi1Sub.AutoSize = True
        lblKpi1Sub.Font = New System.Drawing.Font("Segoe UI", 8.0F)
        lblKpi1Sub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi1Sub.Location = New System.Drawing.Point(18, 86)
        lblKpi1Sub.Name = "lblKpi1Sub"
        lblKpi1Sub.Size = New System.Drawing.Size(183, 13)
        lblKpi1Sub.TabIndex = 2
        lblKpi1Sub.Text = "Homebase prodi aktif semester ini"
        '
        ' lblKpi1Value
        '
        lblKpi1Value.AutoSize = True
        lblKpi1Value.Font = New System.Drawing.Font("Segoe UI", 18.0F, System.Drawing.FontStyle.Bold)
        lblKpi1Value.ForeColor = System.Drawing.Color.FromArgb(CByte(10), CByte(37), CByte(88))
        lblKpi1Value.Location = New System.Drawing.Point(18, 44)
        lblKpi1Value.Name = "lblKpi1Value"
        lblKpi1Value.Size = New System.Drawing.Size(117, 32)
        lblKpi1Value.TabIndex = 1
        lblKpi1Value.Text = "18 Dosen"
        '
        ' lblKpi1Title
        '
        lblKpi1Title.AutoSize = True
        lblKpi1Title.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        lblKpi1Title.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi1Title.Location = New System.Drawing.Point(18, 18)
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.Size = New System.Drawing.Size(115, 13)
        lblKpi1Title.TabIndex = 0
        lblKpi1Title.Text = "TOTAL DOSEN PRODI"
        '
        ' pnlTopbar
        '
        pnlTopbar.BackColor = System.Drawing.Color.White
        pnlTopbar.Controls.Add(lblBadgeProdi)
        pnlTopbar.Controls.Add(lblBreadcrumbSub)
        pnlTopbar.Controls.Add(lblBreadcrumbTitle)
        pnlTopbar.Dock = System.Windows.Forms.DockStyle.Top
        pnlTopbar.Location = New System.Drawing.Point(0, 0)
        pnlTopbar.Name = "pnlTopbar"
        pnlTopbar.Size = New System.Drawing.Size(960, 72)
        pnlTopbar.TabIndex = 0
        '
        ' lblBadgeProdi
        '
        lblBadgeProdi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        lblBadgeProdi.BackColor = System.Drawing.Color.FromArgb(CByte(239), CByte(246), CByte(255))
        lblBadgeProdi.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold)
        lblBadgeProdi.ForeColor = System.Drawing.Color.FromArgb(CByte(37), CByte(99), CByte(235))
        lblBadgeProdi.Location = New System.Drawing.Point(670, 20)
        lblBadgeProdi.Name = "lblBadgeProdi"
        lblBadgeProdi.Size = New System.Drawing.Size(260, 32)
        lblBadgeProdi.TabIndex = 2
        lblBadgeProdi.Text = "Prodi: Teknik Informatika (TI)"
        lblBadgeProdi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        ' lblBreadcrumbSub
        '
        lblBreadcrumbSub.AutoSize = True
        lblBreadcrumbSub.Font = New System.Drawing.Font("Segoe UI", 8.25F)
        lblBreadcrumbSub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblBreadcrumbSub.Location = New System.Drawing.Point(32, 40)
        lblBreadcrumbSub.Name = "lblBreadcrumbSub"
        lblBreadcrumbSub.Size = New System.Drawing.Size(306, 13)
        lblBreadcrumbSub.TabIndex = 1
        lblBreadcrumbSub.Text = "Kelola data dosen, mahasiswa, dan pemantauan kuesioner"
        '
        ' lblBreadcrumbTitle
        '
        lblBreadcrumbTitle.AutoSize = True
        lblBreadcrumbTitle.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold)
        lblBreadcrumbTitle.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblBreadcrumbTitle.Location = New System.Drawing.Point(32, 16)
        lblBreadcrumbTitle.Name = "lblBreadcrumbTitle"
        lblBreadcrumbTitle.Size = New System.Drawing.Size(305, 21)
        lblBreadcrumbTitle.TabIndex = 0
        lblBreadcrumbTitle.Text = "Dashboard Admin - Program Studi TI"
        '
        ' AdminDashboardForm
        '
        AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        ClientSize = New System.Drawing.Size(1200, 750)
        Controls.Add(pnlMainContainer)
        Controls.Add(pnlSidebar)
        Font = New System.Drawing.Font("Segoe UI", 9.0F)
        MinimumSize = New System.Drawing.Size(1024, 680)
        Name = "AdminDashboardForm"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Text = "EDOM PNJ - Dashboard Admin Prodi"
        pnlSidebar.ResumeLayout(False)
        pnlUserCard.ResumeLayout(False)
        CType(picUserAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        pnlNavContainer.ResumeLayout(False)
        pnlNavContainer.PerformLayout()
        pnlBrand.ResumeLayout(False)
        pnlBrand.PerformLayout()
        CType(picSidebarLogo, System.ComponentModel.ISupportInitialize).EndInit()
        pnlMainContainer.ResumeLayout(False)
        pnlScrollBody.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlTableCard.ResumeLayout(False)
        pnlTableCard.PerformLayout()
        CType(dgvAdminData, System.ComponentModel.ISupportInitialize).EndInit()
        pnlTableToolbar.ResumeLayout(False)
        pnlSearchBox.ResumeLayout(False)
        pnlSearchBox.PerformLayout()
        pnlKpiRow.ResumeLayout(False)
        cardKelas.ResumeLayout(False)
        cardKelas.PerformLayout()
        cardMhs.ResumeLayout(False)
        cardMhs.PerformLayout()
        cardDosen.ResumeLayout(False)
        cardDosen.PerformLayout()
        pnlTopbar.ResumeLayout(False)
        pnlTopbar.PerformLayout()
        ResumeLayout(False)
    End Sub
End Class
