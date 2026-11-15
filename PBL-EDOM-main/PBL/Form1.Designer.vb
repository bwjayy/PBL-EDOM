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
    Friend WithEvents pnlSearchBox As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboTahunAkademik As System.Windows.Forms.ComboBox

    ' Scrollable Body
    Friend WithEvents pnlScrollBody As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel

    ' KPI Stat Cards
    Friend WithEvents pnlKpiRow As System.Windows.Forms.Panel
    Friend WithEvents cardTotalMatkul As System.Windows.Forms.Panel
    Friend WithEvents lblKpi1Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi1Title As System.Windows.Forms.Label

    Friend WithEvents cardProgress As System.Windows.Forms.Panel
    Friend WithEvents lblKpi2Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi2Title As System.Windows.Forms.Label
    Friend WithEvents pnlProgressBarBg As System.Windows.Forms.Panel
    Friend WithEvents pnlProgressBarFill As System.Windows.Forms.Panel

    Friend WithEvents cardDeadline As System.Windows.Forms.Panel
    Friend WithEvents lblKpi3Value As System.Windows.Forms.Label
    Friend WithEvents lblKpi3Title As System.Windows.Forms.Label

    ' Alert Banner
    Friend WithEvents pnlAlert As System.Windows.Forms.Panel
    Friend WithEvents lblAlertText As System.Windows.Forms.Label

    ' Main Table Card
    Friend WithEvents pnlTableCard As System.Windows.Forms.Panel
    Friend WithEvents lblTableTitle As System.Windows.Forms.Label
    Friend WithEvents lblTablePeriode As System.Windows.Forms.Label
    Friend WithEvents btnTabAll As System.Windows.Forms.Button
    Friend WithEvents btnTabPending As System.Windows.Forms.Button
    Friend WithEvents dgvEdom As System.Windows.Forms.DataGridView

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlSidebar = New Panel()
        pnlUserCard = New Panel()
        btnLogout = New Button()
        lblSidebarUserRole = New Label()
        lblSidebarUserName = New Label()
        picUserAvatar = New PictureBox()
        pnlNavContainer = New Panel()
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
        btnTabPending = New Button()
        btnTabAll = New Button()
        dgvEdom = New DataGridView()
        lblTablePeriode = New Label()
        lblTableTitle = New Label()
        pnlAlert = New Panel()
        lblAlertText = New Label()
        pnlKpiRow = New Panel()
        cardDeadline = New Panel()
        lblKpi3Value = New Label()
        lblKpi3Title = New Label()
        cardProgress = New Panel()
        pnlProgressBarBg = New Panel()
        pnlProgressBarFill = New Panel()
        lblKpi2Value = New Label()
        lblKpi2Title = New Label()
        cardTotalMatkul = New Panel()
        lblKpi1Value = New Label()
        lblKpi1Title = New Label()
        pnlTopbar = New Panel()
        cboTahunAkademik = New ComboBox()
        pnlSearchBox = New Panel()
        txtSearch = New TextBox()
        lblBreadcrumbSub = New Label()
        lblBreadcrumbTitle = New Label()
        pnlSidebar.SuspendLayout()
        pnlUserCard.SuspendLayout()
        CType(picUserAvatar, ComponentModel.ISupportInitialize).BeginInit()
        pnlNavContainer.SuspendLayout()
        pnlBrand.SuspendLayout()
        CType(picSidebarLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlMainContainer.SuspendLayout()
        pnlScrollBody.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlTableCard.SuspendLayout()
        CType(dgvEdom, ComponentModel.ISupportInitialize).BeginInit()
        pnlAlert.SuspendLayout()
        pnlKpiRow.SuspendLayout()
        cardDeadline.SuspendLayout()
        cardProgress.SuspendLayout()
        pnlProgressBarBg.SuspendLayout()
        cardTotalMatkul.SuspendLayout()
        pnlTopbar.SuspendLayout()
        pnlSearchBox.SuspendLayout()
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
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(260, 900)
        pnlSidebar.TabIndex = 0
        ' 
        ' pnlUserCard
        ' 
        pnlUserCard.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlUserCard.Controls.Add(btnLogout)
        pnlUserCard.Controls.Add(lblSidebarUserRole)
        pnlUserCard.Controls.Add(lblSidebarUserName)
        pnlUserCard.Controls.Add(picUserAvatar)
        pnlUserCard.Dock = DockStyle.Bottom
        pnlUserCard.Location = New Point(0, 765)
        pnlUserCard.Name = "pnlUserCard"
        pnlUserCard.Padding = New Padding(16)
        pnlUserCard.Size = New Size(260, 135)
        pnlUserCard.TabIndex = 2
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.White
        btnLogout.Cursor = Cursors.Hand
        btnLogout.FlatAppearance.BorderColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI Semibold", 8.5F, FontStyle.Bold)
        btnLogout.ForeColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnLogout.Location = New Point(16, 80)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(228, 38)
        btnLogout.TabIndex = 3
        btnLogout.Text = "⎋  Keluar dari Akun"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' lblSidebarUserRole
        ' 
        lblSidebarUserRole.AutoSize = True
        lblSidebarUserRole.Font = New Font("Segoe UI", 8.25F)
        lblSidebarUserRole.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSidebarUserRole.Location = New Point(64, 43)
        lblSidebarUserRole.Name = "lblSidebarUserRole"
        lblSidebarUserRole.Size = New Size(124, 19)
        lblSidebarUserRole.TabIndex = 2
        lblSidebarUserRole.Text = "Mahasiswa • TI-3C"
        ' 
        ' lblSidebarUserName
        ' 
        lblSidebarUserName.AutoSize = True
        lblSidebarUserName.Font = New Font("Segoe UI Semibold", 9.25F, FontStyle.Bold)
        lblSidebarUserName.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblSidebarUserName.Location = New Point(63, 20)
        lblSidebarUserName.Name = "lblSidebarUserName"
        lblSidebarUserName.Size = New Size(105, 21)
        lblSidebarUserName.TabIndex = 1
        lblSidebarUserName.Text = "Bagus Wijaya"
        ' 
        ' picUserAvatar
        ' 
        picUserAvatar.Location = New Point(16, 20)
        picUserAvatar.Name = "picUserAvatar"
        picUserAvatar.Size = New Size(40, 40)
        picUserAvatar.SizeMode = PictureBoxSizeMode.CenterImage
        picUserAvatar.TabIndex = 0
        picUserAvatar.TabStop = False
        ' 
        ' pnlNavContainer
        ' 
        pnlNavContainer.Controls.Add(btnNavDashboard)
        pnlNavContainer.Controls.Add(lblNavHeader)
        pnlNavContainer.Dock = DockStyle.Fill
        pnlNavContainer.Location = New Point(0, 96)
        pnlNavContainer.Name = "pnlNavContainer"
        pnlNavContainer.Padding = New Padding(16, 12, 16, 12)
        pnlNavContainer.Size = New Size(260, 804)
        pnlNavContainer.TabIndex = 1
        ' 
        ' btnNavDashboard
        ' 
        btnNavDashboard.BackColor = Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnNavDashboard.Cursor = Cursors.Hand
        btnNavDashboard.Dock = DockStyle.Top
        btnNavDashboard.FlatAppearance.BorderSize = 0
        btnNavDashboard.FlatStyle = FlatStyle.Flat
        btnNavDashboard.Font = New Font("Segoe UI Semibold", 9.25F, FontStyle.Bold)
        btnNavDashboard.ForeColor = Color.White
        btnNavDashboard.Location = New Point(16, 36)
        btnNavDashboard.Name = "btnNavDashboard"
        btnNavDashboard.Padding = New Padding(14, 0, 0, 0)
        btnNavDashboard.Size = New Size(228, 44)
        btnNavDashboard.TabIndex = 0
        btnNavDashboard.Text = "📊  Dashboard EDOM"
        btnNavDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnNavDashboard.UseVisualStyleBackColor = False
        ' 
        ' lblNavHeader
        ' 
        lblNavHeader.Dock = DockStyle.Top
        lblNavHeader.Font = New Font("Segoe UI Semibold", 7.5F, FontStyle.Bold)
        lblNavHeader.ForeColor = Color.FromArgb(CByte(148), CByte(163), CByte(184))
        lblNavHeader.Location = New Point(16, 12)
        lblNavHeader.Name = "lblNavHeader"
        lblNavHeader.Padding = New Padding(4, 0, 0, 0)
        lblNavHeader.Size = New Size(228, 24)
        lblNavHeader.TabIndex = 1
        lblNavHeader.Text = "NAVIGASI MENU"
        lblNavHeader.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' pnlBrand
        ' 
        pnlBrand.Controls.Add(lblSidebarSub)
        pnlBrand.Controls.Add(lblSidebarBrand)
        pnlBrand.Controls.Add(picSidebarLogo)
        pnlBrand.Dock = DockStyle.Top
        pnlBrand.Location = New Point(0, 0)
        pnlBrand.Name = "pnlBrand"
        pnlBrand.Padding = New Padding(16, 20, 16, 12)
        pnlBrand.Size = New Size(260, 96)
        pnlBrand.TabIndex = 0
        ' 
        ' lblSidebarSub
        ' 
        lblSidebarSub.AutoSize = True
        lblSidebarSub.Font = New Font("Segoe UI", 8.25F)
        lblSidebarSub.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSidebarSub.Location = New Point(64, 48)
        lblSidebarSub.Name = "lblSidebarSub"
        lblSidebarSub.Size = New Size(158, 19)
        lblSidebarSub.TabIndex = 2
        lblSidebarSub.Text = "Politeknik Negeri Jakarta"
        ' 
        ' lblSidebarBrand
        ' 
        lblSidebarBrand.AutoSize = True
        lblSidebarBrand.Font = New Font("Segoe UI", 12.5F, FontStyle.Bold)
        lblSidebarBrand.ForeColor = Color.FromArgb(CByte(10), CByte(37), CByte(88))
        lblSidebarBrand.Location = New Point(62, 21)
        lblSidebarBrand.Name = "lblSidebarBrand"
        lblSidebarBrand.Size = New Size(140, 30)
        lblSidebarBrand.TabIndex = 1
        lblSidebarBrand.Text = "EDOM Portal"
        ' 
        ' picSidebarLogo
        ' 
        picSidebarLogo.Location = New Point(16, 21)
        picSidebarLogo.Name = "picSidebarLogo"
        picSidebarLogo.Size = New Size(40, 44)
        picSidebarLogo.SizeMode = PictureBoxSizeMode.CenterImage
        picSidebarLogo.TabIndex = 0
        picSidebarLogo.TabStop = False
        ' 
        ' pnlMainContainer
        ' 
        pnlMainContainer.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlMainContainer.Controls.Add(pnlScrollBody)
        pnlMainContainer.Controls.Add(pnlTopbar)
        pnlMainContainer.Dock = DockStyle.Fill
        pnlMainContainer.Location = New Point(260, 0)
        pnlMainContainer.Name = "pnlMainContainer"
        pnlMainContainer.Size = New Size(1120, 900)
        pnlMainContainer.TabIndex = 1
        ' 
        ' pnlScrollBody
        ' 
        pnlScrollBody.AutoScroll = True
        pnlScrollBody.Controls.Add(pnlContent)
        pnlScrollBody.Dock = DockStyle.Fill
        pnlScrollBody.Location = New Point(0, 84)
        pnlScrollBody.Name = "pnlScrollBody"
        pnlScrollBody.Padding = New Padding(32, 24, 32, 36)
        pnlScrollBody.Size = New Size(1120, 816)
        pnlScrollBody.TabIndex = 1
        ' 
        ' pnlContent
        ' 
        pnlContent.Controls.Add(pnlTableCard)
        pnlContent.Controls.Add(pnlAlert)
        pnlContent.Controls.Add(pnlKpiRow)
        pnlContent.Location = New Point(32, 24)
        pnlContent.MinimumSize = New Size(860, 800)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1056, 1120)
        pnlContent.TabIndex = 0
        ' 
        ' pnlTableCard
        ' 
        pnlTableCard.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlTableCard.BackColor = Color.White
        pnlTableCard.Controls.Add(btnTabPending)
        pnlTableCard.Controls.Add(btnTabAll)
        pnlTableCard.Controls.Add(dgvEdom)
        pnlTableCard.Controls.Add(lblTablePeriode)
        pnlTableCard.Controls.Add(lblTableTitle)
        pnlTableCard.Location = New Point(0, 235)
        pnlTableCard.Name = "pnlTableCard"
        pnlTableCard.Padding = New Padding(21, 20, 21, 24)
        pnlTableCard.Size = New Size(1056, 880)
        pnlTableCard.TabIndex = 2
        ' 
        ' btnTabPending
        ' 
        btnTabPending.BackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        btnTabPending.Cursor = Cursors.Hand
        btnTabPending.FlatAppearance.BorderSize = 0
        btnTabPending.FlatStyle = FlatStyle.Flat
        btnTabPending.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        btnTabPending.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        btnTabPending.Location = New Point(112, 54)
        btnTabPending.Name = "btnTabPending"
        btnTabPending.Size = New Size(120, 28)
        btnTabPending.TabIndex = 5
        btnTabPending.Text = "Belum Terisi (10)"
        btnTabPending.UseVisualStyleBackColor = False
        ' 
        ' btnTabAll
        ' 
        btnTabAll.BackColor = Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnTabAll.Cursor = Cursors.Hand
        btnTabAll.FlatAppearance.BorderSize = 0
        btnTabAll.FlatStyle = FlatStyle.Flat
        btnTabAll.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        btnTabAll.ForeColor = Color.White
        btnTabAll.Location = New Point(21, 54)
        btnTabAll.Name = "btnTabAll"
        btnTabAll.Size = New Size(85, 28)
        btnTabAll.TabIndex = 4
        btnTabAll.Text = "Semua (10)"
        btnTabAll.UseVisualStyleBackColor = False
        ' 
        ' dgvEdom
        ' 
        dgvEdom.AllowUserToAddRows = False
        dgvEdom.AllowUserToDeleteRows = False
        dgvEdom.AllowUserToResizeRows = False
        dgvEdom.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgvEdom.BackgroundColor = Color.White
        dgvEdom.BorderStyle = BorderStyle.None
        dgvEdom.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvEdom.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvEdom.ColumnHeadersHeight = 42
        dgvEdom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvEdom.DefaultCellStyle = DataGridViewCellStyle2
        dgvEdom.EnableHeadersVisualStyles = False
        dgvEdom.GridColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        dgvEdom.Location = New Point(21, 94)
        dgvEdom.MultiSelect = False
        dgvEdom.Name = "dgvEdom"
        dgvEdom.ReadOnly = True
        dgvEdom.RowHeadersVisible = False
        dgvEdom.RowHeadersWidth = 51
        dgvEdom.RowTemplate.Height = 52
        dgvEdom.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEdom.Size = New Size(1013, 760)
        dgvEdom.TabIndex = 3
        ' 
        ' lblTablePeriode
        ' 
        lblTablePeriode.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblTablePeriode.Font = New Font("Segoe UI", 8.5F)
        lblTablePeriode.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblTablePeriode.Location = New Point(480, 20)
        lblTablePeriode.Name = "lblTablePeriode"
        lblTablePeriode.Size = New Size(553, 24)
        lblTablePeriode.TabIndex = 2
        lblTablePeriode.Text = "Periode Pengisian: Senin, 30 Nov 2026 s/d Rabu, 23 Des 2026"
        lblTablePeriode.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblTableTitle
        ' 
        lblTableTitle.AutoSize = True
        lblTableTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblTableTitle.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblTableTitle.Location = New Point(21, 18)
        lblTableTitle.Name = "lblTableTitle"
        lblTableTitle.Size = New Size(292, 25)
        lblTableTitle.TabIndex = 0
        lblTableTitle.Text = "Daftar Mata Kuliah Semester Ini"
        ' 
        ' pnlAlert
        ' 
        pnlAlert.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlAlert.BackColor = Color.FromArgb(CByte(239), CByte(246), CByte(255))
        pnlAlert.Controls.Add(lblAlertText)
        pnlAlert.Location = New Point(0, 154)
        pnlAlert.Name = "pnlAlert"
        pnlAlert.Padding = New Padding(16, 12, 16, 12)
        pnlAlert.Size = New Size(1056, 60)
        pnlAlert.TabIndex = 1
        ' 
        ' lblAlertText
        ' 
        lblAlertText.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblAlertText.Font = New Font("Segoe UI", 8.75F)
        lblAlertText.ForeColor = Color.FromArgb(CByte(30), CByte(58), CByte(138))
        lblAlertText.Location = New Point(18, 12)
        lblAlertText.Name = "lblAlertText"
        lblAlertText.Size = New Size(990, 36)
        lblAlertText.TabIndex = 1
        lblAlertText.Text = "Pengisian EDOM bersifat wajib bagi seluruh mahasiswa kelas 3C sebagai syarat percetakan Kartu Hasil Studi (KHS)."
        lblAlertText.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' pnlKpiRow
        ' 
        pnlKpiRow.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlKpiRow.Controls.Add(cardDeadline)
        pnlKpiRow.Controls.Add(cardProgress)
        pnlKpiRow.Controls.Add(cardTotalMatkul)
        pnlKpiRow.Location = New Point(0, 0)
        pnlKpiRow.Name = "pnlKpiRow"
        pnlKpiRow.Size = New Size(1056, 134)
        pnlKpiRow.TabIndex = 0
        ' 
        ' cardDeadline
        ' 
        cardDeadline.BackColor = Color.White
        cardDeadline.Controls.Add(lblKpi3Value)
        cardDeadline.Controls.Add(lblKpi3Title)
        cardDeadline.Location = New Point(713, 0)
        cardDeadline.Name = "cardDeadline"
        cardDeadline.Padding = New Padding(20, 18, 20, 18)
        cardDeadline.Size = New Size(334, 130)
        cardDeadline.TabIndex = 2
        ' 
        ' lblKpi3Value
        ' 
        lblKpi3Value.AutoSize = True
        lblKpi3Value.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblKpi3Value.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblKpi3Value.Location = New Point(16, 48)
        lblKpi3Value.Name = "lblKpi3Value"
        lblKpi3Value.Size = New Size(277, 41)
        lblKpi3Value.TabIndex = 1
        lblKpi3Value.Text = "23 Desember 2026"
        ' 
        ' lblKpi3Title
        ' 
        lblKpi3Title.AutoSize = True
        lblKpi3Title.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        lblKpi3Title.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi3Title.Location = New Point(18, 18)
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.Size = New Size(125, 19)
        lblKpi3Title.TabIndex = 0
        lblKpi3Title.Text = "BATAS PENGISIAN"
        ' 
        ' cardProgress
        ' 
        cardProgress.BackColor = Color.White
        cardProgress.Controls.Add(pnlProgressBarBg)
        cardProgress.Controls.Add(lblKpi2Value)
        cardProgress.Controls.Add(lblKpi2Title)
        cardProgress.Location = New Point(357, 0)
        cardProgress.Name = "cardProgress"
        cardProgress.Padding = New Padding(20, 18, 20, 18)
        cardProgress.Size = New Size(334, 130)
        cardProgress.TabIndex = 1
        ' 
        ' pnlProgressBarBg
        ' 
        pnlProgressBarBg.BackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        pnlProgressBarBg.Controls.Add(pnlProgressBarFill)
        pnlProgressBarBg.Location = New Point(20, 96)
        pnlProgressBarBg.Name = "pnlProgressBarBg"
        pnlProgressBarBg.Size = New Size(293, 8)
        pnlProgressBarBg.TabIndex = 2
        ' 
        ' pnlProgressBarFill
        ' 
        pnlProgressBarFill.BackColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        pnlProgressBarFill.Dock = DockStyle.Left
        pnlProgressBarFill.Location = New Point(0, 0)
        pnlProgressBarFill.Name = "pnlProgressBarFill"
        pnlProgressBarFill.Size = New Size(0, 8)
        pnlProgressBarFill.TabIndex = 0
        ' 
        ' lblKpi2Value
        ' 
        lblKpi2Value.AutoSize = True
        lblKpi2Value.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblKpi2Value.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblKpi2Value.Location = New Point(16, 48)
        lblKpi2Value.Name = "lblKpi2Value"
        lblKpi2Value.Size = New Size(275, 41)
        lblKpi2Value.TabIndex = 1
        lblKpi2Value.Text = "0 / 10 Selesai (0%)"
        ' 
        ' lblKpi2Title
        ' 
        lblKpi2Title.AutoSize = True
        lblKpi2Title.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        lblKpi2Title.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi2Title.Location = New Point(18, 18)
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.Size = New Size(155, 19)
        lblKpi2Title.TabIndex = 0
        lblKpi2Title.Text = "PROGRESS PENGISIAN"
        ' 
        ' cardTotalMatkul
        ' 
        cardTotalMatkul.BackColor = Color.White
        cardTotalMatkul.Controls.Add(lblKpi1Value)
        cardTotalMatkul.Controls.Add(lblKpi1Title)
        cardTotalMatkul.Location = New Point(0, 0)
        cardTotalMatkul.Name = "cardTotalMatkul"
        cardTotalMatkul.Padding = New Padding(20, 18, 20, 18)
        cardTotalMatkul.Size = New Size(334, 130)
        cardTotalMatkul.TabIndex = 0
        ' 
        ' lblKpi1Value
        ' 
        lblKpi1Value.AutoSize = True
        lblKpi1Value.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblKpi1Value.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblKpi1Value.Location = New Point(16, 48)
        lblKpi1Value.Name = "lblKpi1Value"
        lblKpi1Value.Size = New Size(220, 41)
        lblKpi1Value.TabIndex = 1
        lblKpi1Value.Text = "10 Matakuliah"
        ' 
        ' lblKpi1Title
        ' 
        lblKpi1Title.AutoSize = True
        lblKpi1Title.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold)
        lblKpi1Title.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKpi1Title.Location = New Point(18, 18)
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.Size = New Size(143, 19)
        lblKpi1Title.TabIndex = 0
        lblKpi1Title.Text = "TOTAL MATA KULIAH"
        ' 
        ' pnlTopbar
        ' 
        pnlTopbar.BackColor = Color.White
        pnlTopbar.Controls.Add(cboTahunAkademik)
        pnlTopbar.Controls.Add(pnlSearchBox)
        pnlTopbar.Controls.Add(lblBreadcrumbSub)
        pnlTopbar.Controls.Add(lblBreadcrumbTitle)
        pnlTopbar.Dock = DockStyle.Top
        pnlTopbar.Location = New Point(0, 0)
        pnlTopbar.Name = "pnlTopbar"
        pnlTopbar.Padding = New Padding(32, 16, 32, 16)
        pnlTopbar.Size = New Size(1120, 84)
        pnlTopbar.TabIndex = 0
        ' 
        ' cboTahunAkademik
        ' 
        cboTahunAkademik.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cboTahunAkademik.BackColor = Color.White
        cboTahunAkademik.DropDownStyle = ComboBoxStyle.DropDownList
        cboTahunAkademik.Font = New Font("Segoe UI", 9.0F)
        cboTahunAkademik.ForeColor = Color.FromArgb(CByte(30), CByte(41), CByte(59))
        cboTahunAkademik.FormattingEnabled = True
        cboTahunAkademik.Location = New Point(896, 26)
        cboTahunAkademik.Name = "cboTahunAkademik"
        cboTahunAkademik.Size = New Size(192, 28)
        cboTahunAkademik.TabIndex = 3
        ' 
        ' pnlSearchBox
        ' 
        pnlSearchBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlSearchBox.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlSearchBox.Controls.Add(txtSearch)
        pnlSearchBox.Location = New Point(590, 22)
        pnlSearchBox.Name = "pnlSearchBox"
        pnlSearchBox.Padding = New Padding(10, 7, 10, 7)
        pnlSearchBox.Size = New Size(290, 38)
        pnlSearchBox.TabIndex = 2
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Font = New Font("Segoe UI", 9.0F)
        txtSearch.ForeColor = Color.FromArgb(CByte(30), CByte(41), CByte(59))
        txtSearch.Location = New Point(34, 9)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Cari mata kuliah / dosen..."
        txtSearch.Size = New Size(244, 20)
        txtSearch.TabIndex = 1
        ' 
        ' lblBreadcrumbSub
        ' 
        lblBreadcrumbSub.AutoSize = True
        lblBreadcrumbSub.Font = New Font("Segoe UI Semibold", 8.0F, FontStyle.Bold)
        lblBreadcrumbSub.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblBreadcrumbSub.Location = New Point(30, 48)
        lblBreadcrumbSub.Name = "lblBreadcrumbSub"
        lblBreadcrumbSub.Size = New Size(299, 19)
        lblBreadcrumbSub.TabIndex = 1
        lblBreadcrumbSub.Text = "PORTAL MAHASISWA  >  RINGKASAN EDOM"
        ' 
        ' lblBreadcrumbTitle
        ' 
        lblBreadcrumbTitle.AutoSize = True
        lblBreadcrumbTitle.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblBreadcrumbTitle.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblBreadcrumbTitle.Location = New Point(28, 17)
        lblBreadcrumbTitle.Name = "lblBreadcrumbTitle"
        lblBreadcrumbTitle.Size = New Size(415, 30)
        lblBreadcrumbTitle.TabIndex = 0
        lblBreadcrumbTitle.Text = "Selamat datang kembali, Bagus Wijaya"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        ClientSize = New Size(1380, 900)
        Controls.Add(pnlMainContainer)
        Controls.Add(pnlSidebar)
        Font = New Font("Segoe UI", 9.0F)
        MinimumSize = New Size(1100, 750)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "EDOM Portal - Sistem Evaluasi Dosen Mengajar (Politeknik Negeri Jakarta)"
        pnlSidebar.ResumeLayout(False)
        pnlUserCard.ResumeLayout(False)
        pnlUserCard.PerformLayout()
        CType(picUserAvatar, ComponentModel.ISupportInitialize).EndInit()
        pnlNavContainer.ResumeLayout(False)
        pnlBrand.ResumeLayout(False)
        pnlBrand.PerformLayout()
        CType(picSidebarLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlMainContainer.ResumeLayout(False)
        pnlScrollBody.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlTableCard.ResumeLayout(False)
        pnlTableCard.PerformLayout()
        CType(dgvEdom, ComponentModel.ISupportInitialize).EndInit()
        pnlAlert.ResumeLayout(False)
        pnlKpiRow.ResumeLayout(False)
        cardDeadline.ResumeLayout(False)
        cardDeadline.PerformLayout()
        cardProgress.ResumeLayout(False)
        cardProgress.PerformLayout()
        pnlProgressBarBg.ResumeLayout(False)
        cardTotalMatkul.ResumeLayout(False)
        cardTotalMatkul.PerformLayout()
        pnlTopbar.ResumeLayout(False)
        pnlTopbar.PerformLayout()
        pnlSearchBox.ResumeLayout(False)
        pnlSearchBox.PerformLayout()
        ResumeLayout(False)
    End Sub

End Class
