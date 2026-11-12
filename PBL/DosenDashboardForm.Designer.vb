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
        dgvMatkul = New System.Windows.Forms.DataGridView()
        lblTableSub = New System.Windows.Forms.Label()
        lblTableTitle = New System.Windows.Forms.Label()
        pnlKpiRow = New System.Windows.Forms.Panel()
        cardResponden = New System.Windows.Forms.Panel()
        lblKpi3Sub = New System.Windows.Forms.Label()
        lblKpi3Value = New System.Windows.Forms.Label()
        lblKpi3Title = New System.Windows.Forms.Label()
        cardKategori = New System.Windows.Forms.Panel()
        lblKpi2Sub = New System.Windows.Forms.Label()
        lblKpi2Badge = New System.Windows.Forms.Label()
        lblKpi2Title = New System.Windows.Forms.Label()
        cardSkor = New System.Windows.Forms.Panel()
        lblKpi1Sub = New System.Windows.Forms.Label()
        lblKpi1Value = New System.Windows.Forms.Label()
        lblKpi1Title = New System.Windows.Forms.Label()
        pnlAiBanner = New System.Windows.Forms.Panel()
        lblAiDesc = New System.Windows.Forms.Label()
        lblAiTitle = New System.Windows.Forms.Label()
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
        CType(dgvMatkul, System.ComponentModel.ISupportInitialize).BeginInit()
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
        lblSidebarUserRole.Text = "Dosen • NIDN: 0012057801"
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
        lblSidebarUserName.Text = "Nama Dosen"
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
        btnNavDashboard.Text = "Rekap Hasil EDOM"
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
        pnlContent.Controls.Add(pnlAiBanner)
        pnlContent.Location = New System.Drawing.Point(32, 24)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New System.Drawing.Size(896, 630)
        pnlContent.TabIndex = 0
        '
        ' pnlTableCard
        '
        pnlTableCard.BackColor = System.Drawing.Color.White
        pnlTableCard.Controls.Add(dgvMatkul)
        pnlTableCard.Controls.Add(lblTableSub)
        pnlTableCard.Controls.Add(lblTableTitle)
        pnlTableCard.Location = New System.Drawing.Point(0, 246)
        pnlTableCard.Name = "pnlTableCard"
        pnlTableCard.Padding = New System.Windows.Forms.Padding(20)
        pnlTableCard.Size = New System.Drawing.Size(896, 360)
        pnlTableCard.TabIndex = 2
        '
        ' dgvMatkul
        '
        dgvMatkul.AllowUserToAddRows = False
        dgvMatkul.AllowUserToDeleteRows = False
        dgvMatkul.BackgroundColor = System.Drawing.Color.White
        dgvMatkul.BorderStyle = System.Windows.Forms.BorderStyle.None
        dgvMatkul.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        dgvMatkul.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
        dgvMatkul.ColumnHeadersHeight = 42
        dgvMatkul.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CByte(241), CByte(245), CByte(249))
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        dgvMatkul.DefaultCellStyle = dataGridViewCellStyle2
        dgvMatkul.EnableHeadersVisualStyles = False
        dgvMatkul.Location = New System.Drawing.Point(20, 70)
        dgvMatkul.Name = "dgvMatkul"
        dgvMatkul.ReadOnly = True
        dgvMatkul.RowHeadersVisible = False
        dgvMatkul.RowTemplate.Height = 48
        dgvMatkul.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        dgvMatkul.Size = New System.Drawing.Size(856, 266)
        dgvMatkul.TabIndex = 2
        '
        ' lblTableSub
        '
        lblTableSub.AutoSize = True
        lblTableSub.Font = New System.Drawing.Font("Segoe UI", 8.25F)
        lblTableSub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblTableSub.Location = New System.Drawing.Point(20, 42)
        lblTableSub.Name = "lblTableSub"
        lblTableSub.Size = New System.Drawing.Size(325, 13)
        lblTableSub.TabIndex = 1
        lblTableSub.Text = "Hasil agregasi evaluasi mahasiswa per kelas semester aktif"
        '
        ' lblTableTitle
        '
        lblTableTitle.AutoSize = True
        lblTableTitle.Font = New System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold)
        lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblTableTitle.Location = New System.Drawing.Point(20, 20)
        lblTableTitle.Name = "lblTableTitle"
        lblTableTitle.Size = New System.Drawing.Size(262, 20)
        lblTableTitle.TabIndex = 0
        lblTableTitle.Text = "Rincian Evaluasi per Mata Kuliah"
        '
        ' pnlKpiRow
        '
        pnlKpiRow.Controls.Add(cardResponden)
        pnlKpiRow.Controls.Add(cardKategori)
        pnlKpiRow.Controls.Add(cardSkor)
        pnlKpiRow.Location = New System.Drawing.Point(0, 106)
        pnlKpiRow.Name = "pnlKpiRow"
        pnlKpiRow.Size = New System.Drawing.Size(896, 120)
        pnlKpiRow.TabIndex = 1
        '
        ' cardResponden
        '
        cardResponden.BackColor = System.Drawing.Color.White
        cardResponden.Controls.Add(lblKpi3Sub)
        cardResponden.Controls.Add(lblKpi3Value)
        cardResponden.Controls.Add(lblKpi3Title)
        cardResponden.Location = New System.Drawing.Point(608, 0)
        cardResponden.Name = "cardResponden"
        cardResponden.Padding = New System.Windows.Forms.Padding(18)
        cardResponden.Size = New System.Drawing.Size(288, 120)
        cardResponden.TabIndex = 2
        '
        ' lblKpi3Sub
        '
        lblKpi3Sub.AutoSize = True
        lblKpi3Sub.Font = New System.Drawing.Font("Segoe UI", 8.0F)
        lblKpi3Sub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi3Sub.Location = New System.Drawing.Point(18, 86)
        lblKpi3Sub.Name = "lblKpi3Sub"
        lblKpi3Sub.Size = New System.Drawing.Size(182, 13)
        lblKpi3Sub.TabIndex = 2
        lblKpi3Sub.Text = "Partisipasi 91.8% mahasiswa kelas"
        '
        ' lblKpi3Value
        '
        lblKpi3Value.AutoSize = True
        lblKpi3Value.Font = New System.Drawing.Font("Segoe UI", 18.0F, System.Drawing.FontStyle.Bold)
        lblKpi3Value.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblKpi3Value.Location = New System.Drawing.Point(18, 44)
        lblKpi3Value.Name = "lblKpi3Value"
        lblKpi3Value.Size = New System.Drawing.Size(177, 32)
        lblKpi3Value.TabIndex = 1
        lblKpi3Value.Text = "45 Responden"
        '
        ' lblKpi3Title
        '
        lblKpi3Title.AutoSize = True
        lblKpi3Title.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        lblKpi3Title.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi3Title.Location = New System.Drawing.Point(18, 18)
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.Size = New System.Drawing.Size(134, 13)
        lblKpi3Title.TabIndex = 0
        lblKpi3Title.Text = "MAHASISWA PENILAI"
        '
        ' cardKategori
        '
        cardKategori.BackColor = System.Drawing.Color.White
        cardKategori.Controls.Add(lblKpi2Sub)
        cardKategori.Controls.Add(lblKpi2Badge)
        cardKategori.Controls.Add(lblKpi2Title)
        cardKategori.Location = New System.Drawing.Point(304, 0)
        cardKategori.Name = "cardKategori"
        cardKategori.Padding = New System.Windows.Forms.Padding(18)
        cardKategori.Size = New System.Drawing.Size(288, 120)
        cardKategori.TabIndex = 1
        '
        ' lblKpi2Sub
        '
        lblKpi2Sub.AutoSize = True
        lblKpi2Sub.Font = New System.Drawing.Font("Segoe UI", 8.0F)
        lblKpi2Sub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi2Sub.Location = New System.Drawing.Point(18, 86)
        lblKpi2Sub.Name = "lblKpi2Sub"
        lblKpi2Sub.Size = New System.Drawing.Size(186, 13)
        lblKpi2Sub.TabIndex = 2
        lblKpi2Sub.Text = "Derajat Keanggotaan Fuzzy μ = 0.92"
        '
        ' lblKpi2Badge
        '
        lblKpi2Badge.BackColor = System.Drawing.Color.FromArgb(CByte(236), CByte(253), CByte(245))
        lblKpi2Badge.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold)
        lblKpi2Badge.ForeColor = System.Drawing.Color.FromArgb(CByte(4), CByte(120), CByte(87))
        lblKpi2Badge.Location = New System.Drawing.Point(18, 44)
        lblKpi2Badge.Name = "lblKpi2Badge"
        lblKpi2Badge.Size = New System.Drawing.Size(170, 32)
        lblKpi2Badge.TabIndex = 1
        lblKpi2Badge.Text = "SANGAT BAIK"
        lblKpi2Badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        ' lblKpi2Title
        '
        lblKpi2Title.AutoSize = True
        lblKpi2Title.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        lblKpi2Title.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi2Title.Location = New System.Drawing.Point(18, 18)
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.Size = New System.Drawing.Size(139, 13)
        lblKpi2Title.TabIndex = 0
        lblKpi2Title.Text = "PREDIKAT EVALUASI AI"
        '
        ' cardSkor
        '
        cardSkor.BackColor = System.Drawing.Color.White
        cardSkor.Controls.Add(lblKpi1Sub)
        cardSkor.Controls.Add(lblKpi1Value)
        cardSkor.Controls.Add(lblKpi1Title)
        cardSkor.Location = New System.Drawing.Point(0, 0)
        cardSkor.Name = "cardSkor"
        cardSkor.Padding = New System.Windows.Forms.Padding(18)
        cardSkor.Size = New System.Drawing.Size(288, 120)
        cardSkor.TabIndex = 0
        '
        ' lblKpi1Sub
        '
        lblKpi1Sub.AutoSize = True
        lblKpi1Sub.Font = New System.Drawing.Font("Segoe UI", 8.0F)
        lblKpi1Sub.ForeColor = System.Drawing.Color.FromArgb(CByte(5), CByte(150), CByte(105))
        lblKpi1Sub.Location = New System.Drawing.Point(18, 86)
        lblKpi1Sub.Name = "lblKpi1Sub"
        lblKpi1Sub.Size = New System.Drawing.Size(183, 13)
        lblKpi1Sub.TabIndex = 2
        lblKpi1Sub.Text = "▲ +2.4 poin di atas rata-rata prodi"
        '
        ' lblKpi1Value
        '
        lblKpi1Value.AutoSize = True
        lblKpi1Value.Font = New System.Drawing.Font("Segoe UI", 18.0F, System.Drawing.FontStyle.Bold)
        lblKpi1Value.ForeColor = System.Drawing.Color.FromArgb(CByte(10), CByte(37), CByte(88))
        lblKpi1Value.Location = New System.Drawing.Point(18, 44)
        lblKpi1Value.Name = "lblKpi1Value"
        lblKpi1Value.Size = New System.Drawing.Size(138, 32)
        lblKpi1Value.TabIndex = 1
        lblKpi1Value.Text = "87.5 / 100"
        '
        ' lblKpi1Title
        '
        lblKpi1Title.AutoSize = True
        lblKpi1Title.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold)
        lblKpi1Title.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi1Title.Location = New System.Drawing.Point(18, 18)
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.Size = New System.Drawing.Size(155, 13)
        lblKpi1Title.TabIndex = 0
        lblKpi1Title.Text = "SKOR INDEKS EDOM (AI)"
        '
        ' pnlAiBanner
        '
        pnlAiBanner.BackColor = System.Drawing.Color.FromArgb(CByte(239), CByte(246), CByte(255))
        pnlAiBanner.Controls.Add(lblAiDesc)
        pnlAiBanner.Controls.Add(lblAiTitle)
        pnlAiBanner.Location = New System.Drawing.Point(0, 0)
        pnlAiBanner.Name = "pnlAiBanner"
        pnlAiBanner.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)
        pnlAiBanner.Size = New System.Drawing.Size(896, 86)
        pnlAiBanner.TabIndex = 0
        '
        ' lblAiDesc
        '
        lblAiDesc.Font = New System.Drawing.Font("Segoe UI", 8.5F)
        lblAiDesc.ForeColor = System.Drawing.Color.FromArgb(CByte(30), CByte(58), CByte(138))
        lblAiDesc.Location = New System.Drawing.Point(18, 38)
        lblAiDesc.Name = "lblAiDesc"
        lblAiDesc.Size = New System.Drawing.Size(858, 36)
        lblAiDesc.TabIndex = 1
        lblAiDesc.Text = "Hasil evaluasi semester berjalan dihitung menggunakan metode Fuzzy Inference System (FIS) berdasarkan akumulasi persepsi kuesioner mahasiswa pada kompetensi pedagogik, profesional, kepribadian, dan sosial."
        '
        ' lblAiTitle
        '
        lblAiTitle.AutoSize = True
        lblAiTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold)
        lblAiTitle.ForeColor = System.Drawing.Color.FromArgb(CByte(30), CByte(58), CByte(138))
        lblAiTitle.Location = New System.Drawing.Point(18, 14)
        lblAiTitle.Name = "lblAiTitle"
        lblAiTitle.Size = New System.Drawing.Size(325, 17)
        lblAiTitle.TabIndex = 0
        lblAiTitle.Text = "Hasil Evaluasi Kinerja Dosen (Metode Fuzzy Logic)"
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
        lblBadgeProdi.Text = "Homebase: Teknik Informatika (TI)"
        lblBadgeProdi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        ' lblBreadcrumbSub
        '
        lblBreadcrumbSub.AutoSize = True
        lblBreadcrumbSub.Font = New System.Drawing.Font("Segoe UI", 8.25F)
        lblBreadcrumbSub.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblBreadcrumbSub.Location = New System.Drawing.Point(32, 40)
        lblBreadcrumbSub.Name = "lblBreadcrumbSub"
        lblBreadcrumbSub.Size = New System.Drawing.Size(269, 13)
        lblBreadcrumbSub.TabIndex = 1
        lblBreadcrumbSub.Text = "Semester Gasal 2026/2027 • Evaluasi Dosen Jurusan TIK"
        '
        ' lblBreadcrumbTitle
        '
        lblBreadcrumbTitle.AutoSize = True
        lblBreadcrumbTitle.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold)
        lblBreadcrumbTitle.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblBreadcrumbTitle.Location = New System.Drawing.Point(32, 16)
        lblBreadcrumbTitle.Name = "lblBreadcrumbTitle"
        lblBreadcrumbTitle.Size = New System.Drawing.Size(207, 21)
        lblBreadcrumbTitle.TabIndex = 0
        lblBreadcrumbTitle.Text = "Dashboard Evaluasi Dosen"
        '
        ' DosenDashboardForm
        '
        AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        ClientSize = New System.Drawing.Size(1200, 750)
        Controls.Add(pnlMainContainer)
        Controls.Add(pnlSidebar)
        Font = New System.Drawing.Font("Segoe UI", 9.0F)
        MinimumSize = New System.Drawing.Size(1024, 680)
        Name = "DosenDashboardForm"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Text = "EDOM PNJ - Dashboard Dosen"
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
        CType(dgvMatkul, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
