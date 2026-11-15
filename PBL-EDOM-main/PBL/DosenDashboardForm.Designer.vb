<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DosenDashboardForm
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

    ' AI Info Banner
    Friend WithEvents pnlAiBanner As System.Windows.Forms.Panel
    Friend WithEvents lblAiTitle As System.Windows.Forms.Label
    Friend WithEvents lblAiDesc As System.Windows.Forms.Label

    ' KPI Cards
    Friend WithEvents pnlKpiRow As System.Windows.Forms.Panel
    Friend WithEvents cardSkor As System.Windows.Forms.Panel
    Friend WithEvents lblKpi1Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi1Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi1Sub As System.Windows.Forms.Label

    Friend WithEvents cardKategori As System.Windows.Forms.Panel
    Friend WithEvents lblKpi2Badge As System.Windows.Forms.Label
    Friend WithEvents lblKpi2Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi2Sub As System.Windows.Forms.Label

    Friend WithEvents cardResponden As System.Windows.Forms.Panel
    Friend WithEvents lblKpi3Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi3Title As System.Windows.Forms.Label
    Friend WithEvents lblKpi3Sub As System.Windows.Forms.Label

    ' Table Area
    Friend WithEvents pnlTableCard As System.Windows.Forms.Panel
    Friend WithEvents lblTableTitle As System.Windows.Forms.Label
    Friend WithEvents lblTableSub As System.Windows.Forms.Label
    Friend WithEvents dgvMatkul As System.Windows.Forms.DataGridView

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DosenDashboardForm))
        pnlSidebar = New Panel()
        pnlUserCard = New Panel()
        btnLogout = New Button()
        lblSidebarUserRole = New Label()
        lblSidebarUserName = New Label()
        picUserAvatar = New PictureBox()
        pnlNavContainer = New Panel()
        ChartHasilEdom = New DataVisualization.Charting.Chart()
        btnNavDashboard = New Button()
        lblNavHeader = New Label()
        pnlBrand = New Panel()
        lblSidebarSub = New Label()
        lblSidebarBrand = New Label()
        picSidebarLogo = New PictureBox()
        pnlMainContainer = New Panel()
        pnlScrollBody = New Panel()
        pnlContent = New Panel()
        pnlTableCard = New Panel()
        dgvMatkul = New DataGridView()
        lblTableSub = New Label()
        lblTableTitle = New Label()
        pnlKpiRow = New Panel()
        cardResponden = New Panel()
        lblKpi3Sub = New Label()
        lblKpi3Value = New Label()
        lblKpi3Title = New Label()
        cardKategori = New Panel()
        lblKpi2Sub = New Label()
        lblKpi2Badge = New Label()
        lblKpi2Title = New Label()
        cardSkor = New Panel()
        lblKpi1Sub = New Label()
        lblKpi1Value = New Label()
        lblKpi1Title = New Label()
        pnlAiBanner = New Panel()
        lblAiDesc = New Label()
        lblAiTitle = New Label()
        pnlTopbar = New Panel()
        lblBadgeProdi = New Label()
        lblBreadcrumbSub = New Label()
        lblBreadcrumbTitle = New Label()
        pnlSidebar.SuspendLayout()
        pnlUserCard.SuspendLayout()
        CType(picUserAvatar, ComponentModel.ISupportInitialize).BeginInit()
        pnlNavContainer.SuspendLayout()
        CType(ChartHasilEdom, ComponentModel.ISupportInitialize).BeginInit()
        pnlBrand.SuspendLayout()
        CType(picSidebarLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlMainContainer.SuspendLayout()
        pnlScrollBody.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlTableCard.SuspendLayout()
        CType(dgvMatkul, ComponentModel.ISupportInitialize).BeginInit()
        pnlKpiRow.SuspendLayout()
        cardResponden.SuspendLayout()
        cardKategori.SuspendLayout()
        cardSkor.SuspendLayout()
        pnlAiBanner.SuspendLayout()
        pnlTopbar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.White
        pnlSidebar.Controls.Add(pnlUserCard)
        pnlSidebar.Controls.Add(pnlNavContainer)
        pnlSidebar.Controls.Add(pnlBrand)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Margin = New Padding(4, 5, 4, 5)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(343, 1050)
        pnlSidebar.TabIndex = 0
        ' 
        ' pnlUserCard
        ' 
        pnlUserCard.Controls.Add(btnLogout)
        pnlUserCard.Controls.Add(lblSidebarUserRole)
        pnlUserCard.Controls.Add(lblSidebarUserName)
        pnlUserCard.Controls.Add(picUserAvatar)
        pnlUserCard.Dock = DockStyle.Bottom
        pnlUserCard.Location = New Point(0, 867)
        pnlUserCard.Margin = New Padding(4, 5, 4, 5)
        pnlUserCard.Name = "pnlUserCard"
        pnlUserCard.Size = New Size(343, 183)
        pnlUserCard.TabIndex = 2
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.White
        btnLogout.Cursor = Cursors.Hand
        btnLogout.FlatAppearance.BorderColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        btnLogout.ForeColor = Color.FromArgb(CByte(220), CByte(38), CByte(38))
        btnLogout.Location = New Point(23, 113)
        btnLogout.Margin = New Padding(4, 5, 4, 5)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(297, 50)
        btnLogout.TabIndex = 3
        btnLogout.Text = "Keluar"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' lblSidebarUserRole
        ' 
        lblSidebarUserRole.AutoEllipsis = True
        lblSidebarUserRole.Font = New Font("Segoe UI", 7.75F)
        lblSidebarUserRole.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSidebarUserRole.Location = New Point(89, 63)
        lblSidebarUserRole.Margin = New Padding(4, 0, 4, 0)
        lblSidebarUserRole.Name = "lblSidebarUserRole"
        lblSidebarUserRole.Size = New Size(231, 30)
        lblSidebarUserRole.TabIndex = 2
        lblSidebarUserRole.Text = "Dosen • NIDN: 0012057801"
        ' 
        ' lblSidebarUserName
        ' 
        lblSidebarUserName.AutoEllipsis = True
        lblSidebarUserName.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblSidebarUserName.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblSidebarUserName.Location = New Point(89, 30)
        lblSidebarUserName.Margin = New Padding(4, 0, 4, 0)
        lblSidebarUserName.Name = "lblSidebarUserName"
        lblSidebarUserName.Size = New Size(231, 33)
        lblSidebarUserName.TabIndex = 1
        lblSidebarUserName.Text = "Nama Dosen"
        ' 
        ' picUserAvatar
        ' 
        picUserAvatar.Location = New Point(23, 27)
        picUserAvatar.Margin = New Padding(4, 5, 4, 5)
        picUserAvatar.Name = "picUserAvatar"
        picUserAvatar.Size = New Size(54, 63)
        picUserAvatar.TabIndex = 0
        picUserAvatar.TabStop = False
        ' 
        ' pnlNavContainer
        ' 
        pnlNavContainer.Controls.Add(ChartHasilEdom)
        pnlNavContainer.Controls.Add(btnNavDashboard)
        pnlNavContainer.Controls.Add(lblNavHeader)
        pnlNavContainer.Dock = DockStyle.Fill
        pnlNavContainer.Location = New Point(0, 120)
        pnlNavContainer.Margin = New Padding(4, 5, 4, 5)
        pnlNavContainer.Name = "pnlNavContainer"
        pnlNavContainer.Padding = New Padding(23, 27, 23, 0)
        pnlNavContainer.Size = New Size(343, 930)
        pnlNavContainer.TabIndex = 1
        ' 
        ' ChartHasilEdom
        ' 
        ChartArea1.Name = "ChartArea1"
        ChartHasilEdom.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        ChartHasilEdom.Legends.Add(Legend1)
        ChartHasilEdom.Location = New Point(-11, 204)
        ChartHasilEdom.Name = "ChartHasilEdom"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        ChartHasilEdom.Series.Add(Series1)
        ChartHasilEdom.Size = New Size(477, 479)
        ChartHasilEdom.TabIndex = 2
        ChartHasilEdom.Text = "Chart1"
        ' 
        ' btnNavDashboard
        ' 
        btnNavDashboard.BackColor = Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnNavDashboard.Cursor = Cursors.Hand
        btnNavDashboard.FlatAppearance.BorderSize = 0
        btnNavDashboard.FlatStyle = FlatStyle.Flat
        btnNavDashboard.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        btnNavDashboard.ForeColor = Color.White
        btnNavDashboard.Location = New Point(23, 63)
        btnNavDashboard.Margin = New Padding(4, 5, 4, 5)
        btnNavDashboard.Name = "btnNavDashboard"
        btnNavDashboard.Size = New Size(297, 63)
        btnNavDashboard.TabIndex = 1
        btnNavDashboard.Text = "Rekap Hasil EDOM"
        btnNavDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnNavDashboard.UseVisualStyleBackColor = False
        ' 
        ' lblNavHeader
        ' 
        lblNavHeader.AutoSize = True
        lblNavHeader.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblNavHeader.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblNavHeader.Location = New Point(23, 27)
        lblNavHeader.Margin = New Padding(4, 0, 4, 0)
        lblNavHeader.Name = "lblNavHeader"
        lblNavHeader.Size = New Size(113, 20)
        lblNavHeader.TabIndex = 0
        lblNavHeader.Text = "MENU UTAMA"
        ' 
        ' pnlBrand
        ' 
        pnlBrand.Controls.Add(lblSidebarSub)
        pnlBrand.Controls.Add(lblSidebarBrand)
        pnlBrand.Controls.Add(picSidebarLogo)
        pnlBrand.Dock = DockStyle.Top
        pnlBrand.Location = New Point(0, 0)
        pnlBrand.Margin = New Padding(4, 5, 4, 5)
        pnlBrand.Name = "pnlBrand"
        pnlBrand.Size = New Size(343, 120)
        pnlBrand.TabIndex = 0
        ' 
        ' lblSidebarSub
        ' 
        lblSidebarSub.AutoSize = True
        lblSidebarSub.Font = New Font("Segoe UI", 7.5F)
        lblSidebarSub.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSidebarSub.Location = New Point(83, 67)
        lblSidebarSub.Margin = New Padding(4, 0, 4, 0)
        lblSidebarSub.Name = "lblSidebarSub"
        lblSidebarSub.Size = New Size(171, 20)
        lblSidebarSub.TabIndex = 2
        lblSidebarSub.Text = "Politeknik Negeri Jakarta"
        ' 
        ' lblSidebarBrand
        ' 
        lblSidebarBrand.AutoSize = True
        lblSidebarBrand.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblSidebarBrand.ForeColor = Color.FromArgb(CByte(10), CByte(37), CByte(88))
        lblSidebarBrand.Location = New Point(83, 30)
        lblSidebarBrand.Margin = New Padding(4, 0, 4, 0)
        lblSidebarBrand.Name = "lblSidebarBrand"
        lblSidebarBrand.Size = New Size(138, 32)
        lblSidebarBrand.TabIndex = 1
        lblSidebarBrand.Text = "EDOM PNJ"
        ' 
        ' picSidebarLogo
        ' 
        picSidebarLogo.Location = New Point(23, 30)
        picSidebarLogo.Margin = New Padding(4, 5, 4, 5)
        picSidebarLogo.Name = "picSidebarLogo"
        picSidebarLogo.Size = New Size(51, 60)
        picSidebarLogo.TabIndex = 0
        picSidebarLogo.TabStop = False
        ' 
        ' pnlMainContainer
        ' 
        pnlMainContainer.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlMainContainer.Controls.Add(pnlScrollBody)
        pnlMainContainer.Controls.Add(pnlTopbar)
        pnlMainContainer.Dock = DockStyle.Fill
        pnlMainContainer.Location = New Point(343, 0)
        pnlMainContainer.Margin = New Padding(4, 5, 4, 5)
        pnlMainContainer.Name = "pnlMainContainer"
        pnlMainContainer.Size = New Size(1371, 1050)
        pnlMainContainer.TabIndex = 1
        ' 
        ' pnlScrollBody
        ' 
        pnlScrollBody.AutoScroll = True
        pnlScrollBody.Controls.Add(pnlContent)
        pnlScrollBody.Dock = DockStyle.Fill
        pnlScrollBody.Location = New Point(0, 120)
        pnlScrollBody.Margin = New Padding(4, 5, 4, 5)
        pnlScrollBody.Name = "pnlScrollBody"
        pnlScrollBody.Size = New Size(1371, 930)
        pnlScrollBody.TabIndex = 1
        ' 
        ' pnlContent
        ' 
        pnlContent.Controls.Add(pnlTableCard)
        pnlContent.Controls.Add(pnlKpiRow)
        pnlContent.Controls.Add(pnlAiBanner)
        pnlContent.Location = New Point(46, 40)
        pnlContent.Margin = New Padding(4, 5, 4, 5)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1280, 1050)
        pnlContent.TabIndex = 0
        ' 
        ' pnlTableCard
        ' 
        pnlTableCard.BackColor = Color.White
        pnlTableCard.Controls.Add(dgvMatkul)
        pnlTableCard.Controls.Add(lblTableSub)
        pnlTableCard.Controls.Add(lblTableTitle)
        pnlTableCard.Location = New Point(0, 410)
        pnlTableCard.Margin = New Padding(4, 5, 4, 5)
        pnlTableCard.Name = "pnlTableCard"
        pnlTableCard.Padding = New Padding(29, 33, 29, 33)
        pnlTableCard.Size = New Size(1280, 600)
        pnlTableCard.TabIndex = 2
        ' 
        ' dgvMatkul
        ' 
        dgvMatkul.AllowUserToAddRows = False
        dgvMatkul.AllowUserToDeleteRows = False
        dgvMatkul.BackgroundColor = Color.White
        dgvMatkul.BorderStyle = BorderStyle.None
        dgvMatkul.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvMatkul.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvMatkul.ColumnHeadersHeight = 42
        dgvMatkul.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvMatkul.DefaultCellStyle = DataGridViewCellStyle2
        dgvMatkul.EnableHeadersVisualStyles = False
        dgvMatkul.Location = New Point(29, 117)
        dgvMatkul.Margin = New Padding(4, 5, 4, 5)
        dgvMatkul.Name = "dgvMatkul"
        dgvMatkul.ReadOnly = True
        dgvMatkul.RowHeadersVisible = False
        dgvMatkul.RowHeadersWidth = 62
        dgvMatkul.RowTemplate.Height = 48
        dgvMatkul.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMatkul.Size = New Size(1223, 443)
        dgvMatkul.TabIndex = 2
        ' 
        ' lblTableSub
        ' 
        lblTableSub.AutoSize = True
        lblTableSub.Font = New Font("Segoe UI", 8.25F)
        lblTableSub.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblTableSub.Location = New Point(29, 70)
        lblTableSub.Margin = New Padding(4, 0, 4, 0)
        lblTableSub.Name = "lblTableSub"
        lblTableSub.Size = New Size(449, 23)
        lblTableSub.TabIndex = 1
        lblTableSub.Text = "Hasil agregasi evaluasi mahasiswa per kelas semester aktif"
        ' 
        ' lblTableTitle
        ' 
        lblTableTitle.AutoSize = True
        lblTableTitle.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        lblTableTitle.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblTableTitle.Location = New Point(29, 33)
        lblTableTitle.Margin = New Padding(4, 0, 4, 0)
        lblTableTitle.Name = "lblTableTitle"
        lblTableTitle.Size = New Size(363, 31)
        lblTableTitle.TabIndex = 0
        lblTableTitle.Text = "Rincian Evaluasi per Mata Kuliah"
        ' 
        ' pnlKpiRow
        ' 
        pnlKpiRow.Controls.Add(cardResponden)
        pnlKpiRow.Controls.Add(cardKategori)
        pnlKpiRow.Controls.Add(cardSkor)
        pnlKpiRow.Location = New Point(0, 177)
        pnlKpiRow.Margin = New Padding(4, 5, 4, 5)
        pnlKpiRow.Name = "pnlKpiRow"
        pnlKpiRow.Size = New Size(1280, 200)
        pnlKpiRow.TabIndex = 1
        ' 
        ' cardResponden
        ' 
        cardResponden.BackColor = Color.White
        cardResponden.Controls.Add(lblKpi3Sub)
        cardResponden.Controls.Add(lblKpi3Value)
        cardResponden.Controls.Add(lblKpi3Title)
        cardResponden.Location = New Point(869, 0)
        cardResponden.Margin = New Padding(4, 5, 4, 5)
        cardResponden.Name = "cardResponden"
        cardResponden.Padding = New Padding(26, 30, 26, 30)
        cardResponden.Size = New Size(411, 200)
        cardResponden.TabIndex = 2
        ' 
        ' lblKpi3Sub
        ' 
        lblKpi3Sub.AutoSize = True
        lblKpi3Sub.Font = New Font("Segoe UI", 8F)
        lblKpi3Sub.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi3Sub.Location = New Point(26, 143)
        lblKpi3Sub.Margin = New Padding(4, 0, 4, 0)
        lblKpi3Sub.Name = "lblKpi3Sub"
        lblKpi3Sub.Size = New Size(247, 21)
        lblKpi3Sub.TabIndex = 2
        lblKpi3Sub.Text = "Partisipasi 91.8% mahasiswa kelas"
        ' 
        ' lblKpi3Value
        ' 
        lblKpi3Value.AutoSize = True
        lblKpi3Value.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblKpi3Value.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblKpi3Value.Location = New Point(26, 73)
        lblKpi3Value.Margin = New Padding(4, 0, 4, 0)
        lblKpi3Value.Name = "lblKpi3Value"
        lblKpi3Value.Size = New Size(259, 48)
        lblKpi3Value.TabIndex = 1
        lblKpi3Value.Text = "45 Responden"
        ' 
        ' lblKpi3Title
        ' 
        lblKpi3Title.AutoSize = True
        lblKpi3Title.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        lblKpi3Title.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi3Title.Location = New Point(26, 30)
        lblKpi3Title.Margin = New Padding(4, 0, 4, 0)
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.Size = New Size(176, 23)
        lblKpi3Title.TabIndex = 0
        lblKpi3Title.Text = "MAHASISWA PENILAI"
        ' 
        ' cardKategori
        ' 
        cardKategori.BackColor = Color.White
        cardKategori.Controls.Add(lblKpi2Sub)
        cardKategori.Controls.Add(lblKpi2Badge)
        cardKategori.Controls.Add(lblKpi2Title)
        cardKategori.Location = New Point(434, 0)
        cardKategori.Margin = New Padding(4, 5, 4, 5)
        cardKategori.Name = "cardKategori"
        cardKategori.Padding = New Padding(26, 30, 26, 30)
        cardKategori.Size = New Size(411, 200)
        cardKategori.TabIndex = 1
        ' 
        ' lblKpi2Sub
        ' 
        lblKpi2Sub.AutoSize = True
        lblKpi2Sub.Font = New Font("Segoe UI", 8F)
        lblKpi2Sub.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi2Sub.Location = New Point(26, 143)
        lblKpi2Sub.Margin = New Padding(4, 0, 4, 0)
        lblKpi2Sub.Name = "lblKpi2Sub"
        lblKpi2Sub.Size = New Size(260, 21)
        lblKpi2Sub.TabIndex = 2
        lblKpi2Sub.Text = "Derajat Keanggotaan Fuzzy μ = 0.92"
        ' 
        ' lblKpi2Badge
        ' 
        lblKpi2Badge.BackColor = Color.FromArgb(CByte(236), CByte(253), CByte(245))
        lblKpi2Badge.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblKpi2Badge.ForeColor = Color.FromArgb(CByte(4), CByte(120), CByte(87))
        lblKpi2Badge.Location = New Point(26, 73)
        lblKpi2Badge.Margin = New Padding(4, 0, 4, 0)
        lblKpi2Badge.Name = "lblKpi2Badge"
        lblKpi2Badge.Size = New Size(243, 53)
        lblKpi2Badge.TabIndex = 1
        lblKpi2Badge.Text = "SANGAT BAIK"
        lblKpi2Badge.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblKpi2Title
        ' 
        lblKpi2Title.AutoSize = True
        lblKpi2Title.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        lblKpi2Title.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi2Title.Location = New Point(26, 30)
        lblKpi2Title.Margin = New Padding(4, 0, 4, 0)
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.Size = New Size(187, 23)
        lblKpi2Title.TabIndex = 0
        lblKpi2Title.Text = "PREDIKAT EVALUASI AI"
        ' 
        ' cardSkor
        ' 
        cardSkor.BackColor = Color.White
        cardSkor.Controls.Add(lblKpi1Sub)
        cardSkor.Controls.Add(lblKpi1Value)
        cardSkor.Controls.Add(lblKpi1Title)
        cardSkor.Location = New Point(0, 0)
        cardSkor.Margin = New Padding(4, 5, 4, 5)
        cardSkor.Name = "cardSkor"
        cardSkor.Padding = New Padding(26, 30, 26, 30)
        cardSkor.Size = New Size(411, 200)
        cardSkor.TabIndex = 0
        ' 
        ' lblKpi1Sub
        ' 
        lblKpi1Sub.AutoSize = True
        lblKpi1Sub.Font = New Font("Segoe UI", 8F)
        lblKpi1Sub.ForeColor = Color.FromArgb(CByte(5), CByte(150), CByte(105))
        lblKpi1Sub.Location = New Point(26, 143)
        lblKpi1Sub.Margin = New Padding(4, 0, 4, 0)
        lblKpi1Sub.Name = "lblKpi1Sub"
        lblKpi1Sub.Size = New Size(249, 21)
        lblKpi1Sub.TabIndex = 2
        lblKpi1Sub.Text = "▲ +2.4 poin di atas rata-rata prodi"
        ' 
        ' lblKpi1Value
        ' 
        lblKpi1Value.AutoSize = True
        lblKpi1Value.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblKpi1Value.ForeColor = Color.FromArgb(CByte(10), CByte(37), CByte(88))
        lblKpi1Value.Location = New Point(26, 73)
        lblKpi1Value.Margin = New Padding(4, 0, 4, 0)
        lblKpi1Value.Name = "lblKpi1Value"
        lblKpi1Value.Size = New Size(192, 48)
        lblKpi1Value.TabIndex = 1
        lblKpi1Value.Text = "87.5 / 100"
        ' 
        ' lblKpi1Title
        ' 
        lblKpi1Title.AutoSize = True
        lblKpi1Title.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        lblKpi1Title.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi1Title.Location = New Point(26, 30)
        lblKpi1Title.Margin = New Padding(4, 0, 4, 0)
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.Size = New Size(203, 23)
        lblKpi1Title.TabIndex = 0
        lblKpi1Title.Text = "SKOR INDEKS EDOM (AI)"
        ' 
        ' pnlAiBanner
        ' 
        pnlAiBanner.BackColor = Color.FromArgb(CByte(239), CByte(246), CByte(255))
        pnlAiBanner.Controls.Add(lblAiDesc)
        pnlAiBanner.Controls.Add(lblAiTitle)
        pnlAiBanner.Location = New Point(0, 0)
        pnlAiBanner.Margin = New Padding(4, 5, 4, 5)
        pnlAiBanner.Name = "pnlAiBanner"
        pnlAiBanner.Padding = New Padding(26, 23, 26, 23)
        pnlAiBanner.Size = New Size(1280, 143)
        pnlAiBanner.TabIndex = 0
        ' 
        ' lblAiDesc
        ' 
        lblAiDesc.Font = New Font("Segoe UI", 8.5F)
        lblAiDesc.ForeColor = Color.FromArgb(CByte(30), CByte(58), CByte(138))
        lblAiDesc.Location = New Point(26, 63)
        lblAiDesc.Margin = New Padding(4, 0, 4, 0)
        lblAiDesc.Name = "lblAiDesc"
        lblAiDesc.Size = New Size(1226, 60)
        lblAiDesc.TabIndex = 1
        lblAiDesc.Text = resources.GetString("lblAiDesc.Text")
        ' 
        ' lblAiTitle
        ' 
        lblAiTitle.AutoSize = True
        lblAiTitle.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        lblAiTitle.ForeColor = Color.FromArgb(CByte(30), CByte(58), CByte(138))
        lblAiTitle.Location = New Point(26, 23)
        lblAiTitle.Margin = New Padding(4, 0, 4, 0)
        lblAiTitle.Name = "lblAiTitle"
        lblAiTitle.Size = New Size(466, 28)
        lblAiTitle.TabIndex = 0
        lblAiTitle.Text = "Hasil Evaluasi Kinerja Dosen (Metode Fuzzy Logic)"
        ' 
        ' pnlTopbar
        ' 
        pnlTopbar.BackColor = Color.White
        pnlTopbar.Controls.Add(lblBadgeProdi)
        pnlTopbar.Controls.Add(lblBreadcrumbSub)
        pnlTopbar.Controls.Add(lblBreadcrumbTitle)
        pnlTopbar.Dock = DockStyle.Top
        pnlTopbar.Location = New Point(0, 0)
        pnlTopbar.Margin = New Padding(4, 5, 4, 5)
        pnlTopbar.Name = "pnlTopbar"
        pnlTopbar.Size = New Size(1371, 120)
        pnlTopbar.TabIndex = 0
        ' 
        ' lblBadgeProdi
        ' 
        lblBadgeProdi.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblBadgeProdi.BackColor = Color.FromArgb(CByte(239), CByte(246), CByte(255))
        lblBadgeProdi.Font = New Font("Segoe UI Semibold", 8.5F, FontStyle.Bold)
        lblBadgeProdi.ForeColor = Color.FromArgb(CByte(37), CByte(99), CByte(235))
        lblBadgeProdi.Location = New Point(957, 33)
        lblBadgeProdi.Margin = New Padding(4, 0, 4, 0)
        lblBadgeProdi.Name = "lblBadgeProdi"
        lblBadgeProdi.Size = New Size(371, 53)
        lblBadgeProdi.TabIndex = 2
        lblBadgeProdi.Text = "Homebase: Teknik Informatika (TI)"
        lblBadgeProdi.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblBreadcrumbSub
        ' 
        lblBreadcrumbSub.AutoSize = True
        lblBreadcrumbSub.Font = New Font("Segoe UI", 8.25F)
        lblBreadcrumbSub.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblBreadcrumbSub.Location = New Point(46, 67)
        lblBreadcrumbSub.Margin = New Padding(4, 0, 4, 0)
        lblBreadcrumbSub.Name = "lblBreadcrumbSub"
        lblBreadcrumbSub.Size = New Size(432, 23)
        lblBreadcrumbSub.TabIndex = 1
        lblBreadcrumbSub.Text = "Semester Gasal 2026/2027 • Evaluasi Dosen Jurusan TIK"
        ' 
        ' lblBreadcrumbTitle
        ' 
        lblBreadcrumbTitle.AutoSize = True
        lblBreadcrumbTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblBreadcrumbTitle.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblBreadcrumbTitle.Location = New Point(46, 27)
        lblBreadcrumbTitle.Margin = New Padding(4, 0, 4, 0)
        lblBreadcrumbTitle.Name = "lblBreadcrumbTitle"
        lblBreadcrumbTitle.Size = New Size(316, 32)
        lblBreadcrumbTitle.TabIndex = 0
        lblBreadcrumbTitle.Text = "Dashboard Evaluasi Dosen"
        ' 
        ' DosenDashboardForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        ClientSize = New Size(1714, 1050)
        Controls.Add(pnlMainContainer)
        Controls.Add(pnlSidebar)
        Font = New Font("Segoe UI", 9F)
        Margin = New Padding(4, 5, 4, 5)
        MinimumSize = New Size(1453, 1006)
        Name = "DosenDashboardForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "EDOM PNJ - Dashboard Dosen"
        pnlSidebar.ResumeLayout(False)
        pnlUserCard.ResumeLayout(False)
        CType(picUserAvatar, ComponentModel.ISupportInitialize).EndInit()
        pnlNavContainer.ResumeLayout(False)
        pnlNavContainer.PerformLayout()
        CType(ChartHasilEdom, ComponentModel.ISupportInitialize).EndInit()
        pnlBrand.ResumeLayout(False)
        pnlBrand.PerformLayout()
        CType(picSidebarLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlMainContainer.ResumeLayout(False)
        pnlScrollBody.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlTableCard.ResumeLayout(False)
        pnlTableCard.PerformLayout()
        CType(dgvMatkul, ComponentModel.ISupportInitialize).EndInit()
        pnlKpiRow.ResumeLayout(False)
        cardResponden.ResumeLayout(False)
        cardResponden.PerformLayout()
        cardKategori.ResumeLayout(False)
        cardKategori.PerformLayout()
        cardSkor.ResumeLayout(False)
        cardSkor.PerformLayout()
        pnlAiBanner.ResumeLayout(False)
        pnlAiBanner.PerformLayout()
        pnlTopbar.ResumeLayout(False)
        pnlTopbar.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents ChartHasilEdom As DataVisualization.Charting.Chart
End Class
