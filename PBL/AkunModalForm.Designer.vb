<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AkunModalForm
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

    Friend WithEvents pnlMainCard As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button

    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button

    Friend WithEvents pnlBody As System.Windows.Forms.Panel

    ' Input Controls
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents cmbRole As System.Windows.Forms.ComboBox

    Friend WithEvents lblNama As System.Windows.Forms.Label
    Friend WithEvents pnlNamaBox As System.Windows.Forms.Panel
    Friend WithEvents txtNama As System.Windows.Forms.TextBox

    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents pnlEmailBox As System.Windows.Forms.Panel
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox

    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents pnlPasswordBox As System.Windows.Forms.Panel
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents picTogglePassword As System.Windows.Forms.PictureBox
    Friend WithEvents lblPasswordHint As System.Windows.Forms.Label

    Friend WithEvents lblProdi As System.Windows.Forms.Label
    Friend WithEvents cmbProdi As System.Windows.Forms.ComboBox

    ' Dynamic Role Panels
    Friend WithEvents pnlDosenFields As System.Windows.Forms.Panel
    Friend WithEvents lblNidn As System.Windows.Forms.Label
    Friend WithEvents pnlNidnBox As System.Windows.Forms.Panel
    Friend WithEvents txtNidn As System.Windows.Forms.TextBox
    Friend WithEvents lblGelarDepan As System.Windows.Forms.Label
    Friend WithEvents pnlGelarDBox As System.Windows.Forms.Panel
    Friend WithEvents txtGelarDepan As System.Windows.Forms.TextBox
    Friend WithEvents lblGelarBelakang As System.Windows.Forms.Label
    Friend WithEvents pnlGelarBBox As System.Windows.Forms.Panel
    Friend WithEvents txtGelarBelakang As System.Windows.Forms.TextBox

    Friend WithEvents pnlMahasiswaFields As System.Windows.Forms.Panel
    Friend WithEvents lblNim As System.Windows.Forms.Label
    Friend WithEvents pnlNimBox As System.Windows.Forms.Panel
    Friend WithEvents txtNim As System.Windows.Forms.TextBox
    Friend WithEvents lblAngkatan As System.Windows.Forms.Label
    Friend WithEvents pnlAngkatanBox As System.Windows.Forms.Panel
    Friend WithEvents txtAngkatan As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlMainCard = New System.Windows.Forms.Panel()
        pnlBody = New System.Windows.Forms.Panel()
        pnlMahasiswaFields = New System.Windows.Forms.Panel()
        pnlAngkatanBox = New System.Windows.Forms.Panel()
        txtAngkatan = New System.Windows.Forms.TextBox()
        lblAngkatan = New System.Windows.Forms.Label()
        pnlNimBox = New System.Windows.Forms.Panel()
        txtNim = New System.Windows.Forms.TextBox()
        lblNim = New System.Windows.Forms.Label()
        pnlDosenFields = New System.Windows.Forms.Panel()
        pnlGelarBBox = New System.Windows.Forms.Panel()
        txtGelarBelakang = New System.Windows.Forms.TextBox()
        lblGelarBelakang = New System.Windows.Forms.Label()
        pnlGelarDBox = New System.Windows.Forms.Panel()
        txtGelarDepan = New System.Windows.Forms.TextBox()
        lblGelarDepan = New System.Windows.Forms.Label()
        pnlNidnBox = New System.Windows.Forms.Panel()
        txtNidn = New System.Windows.Forms.TextBox()
        lblNidn = New System.Windows.Forms.Label()
        cmbProdi = New System.Windows.Forms.ComboBox()
        lblProdi = New System.Windows.Forms.Label()
        lblPasswordHint = New System.Windows.Forms.Label()
        pnlPasswordBox = New System.Windows.Forms.Panel()
        picTogglePassword = New System.Windows.Forms.PictureBox()
        txtPassword = New System.Windows.Forms.TextBox()
        lblPassword = New System.Windows.Forms.Label()
        pnlEmailBox = New System.Windows.Forms.Panel()
        txtEmail = New System.Windows.Forms.TextBox()
        lblEmail = New System.Windows.Forms.Label()
        pnlNamaBox = New System.Windows.Forms.Panel()
        txtNama = New System.Windows.Forms.TextBox()
        lblNama = New System.Windows.Forms.Label()
        cmbRole = New System.Windows.Forms.ComboBox()
        lblRole = New System.Windows.Forms.Label()
        pnlFooter = New System.Windows.Forms.Panel()
        btnSimpan = New System.Windows.Forms.Button()
        btnBatal = New System.Windows.Forms.Button()
        pnlHeader = New System.Windows.Forms.Panel()
        btnClose = New System.Windows.Forms.Button()
        lblSubtitle = New System.Windows.Forms.Label()
        lblTitle = New System.Windows.Forms.Label()
        pnlMainCard.SuspendLayout()
        pnlBody.SuspendLayout()
        pnlMahasiswaFields.SuspendLayout()
        pnlAngkatanBox.SuspendLayout()
        pnlNimBox.SuspendLayout()
        pnlDosenFields.SuspendLayout()
        pnlGelarBBox.SuspendLayout()
        pnlGelarDBox.SuspendLayout()
        pnlNidnBox.SuspendLayout()
        pnlPasswordBox.SuspendLayout()
        CType(picTogglePassword, System.ComponentModel.ISupportInitialize).BeginInit()
        pnlEmailBox.SuspendLayout()
        pnlNamaBox.SuspendLayout()
        pnlFooter.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMainCard
        ' 
        pnlMainCard.BackColor = System.Drawing.Color.White
        pnlMainCard.Controls.Add(pnlBody)
        pnlMainCard.Controls.Add(pnlFooter)
        pnlMainCard.Controls.Add(pnlHeader)
        pnlMainCard.Dock = System.Windows.Forms.DockStyle.Fill
        pnlMainCard.Location = New System.Drawing.Point(0, 0)
        pnlMainCard.Name = "pnlMainCard"
        pnlMainCard.Size = New System.Drawing.Size(560, 680)
        pnlMainCard.TabIndex = 0
        ' 
        ' pnlBody
        ' 
        pnlBody.AutoScroll = True
        pnlBody.BackColor = System.Drawing.Color.White
        pnlBody.Controls.Add(pnlMahasiswaFields)
        pnlBody.Controls.Add(pnlDosenFields)
        pnlBody.Controls.Add(cmbProdi)
        pnlBody.Controls.Add(lblProdi)
        pnlBody.Controls.Add(lblPasswordHint)
        pnlBody.Controls.Add(pnlPasswordBox)
        pnlBody.Controls.Add(lblPassword)
        pnlBody.Controls.Add(pnlEmailBox)
        pnlBody.Controls.Add(lblEmail)
        pnlBody.Controls.Add(pnlNamaBox)
        pnlBody.Controls.Add(lblNama)
        pnlBody.Controls.Add(cmbRole)
        pnlBody.Controls.Add(lblRole)
        pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        pnlBody.Location = New System.Drawing.Point(0, 72)
        pnlBody.Name = "pnlBody"
        pnlBody.Padding = New System.Windows.Forms.Padding(28, 12, 28, 20)
        pnlBody.Size = New System.Drawing.Size(560, 540)
        pnlBody.TabIndex = 1
        ' 
        ' pnlMahasiswaFields
        ' 
        pnlMahasiswaFields.Controls.Add(pnlAngkatanBox)
        pnlMahasiswaFields.Controls.Add(lblAngkatan)
        pnlMahasiswaFields.Controls.Add(pnlNimBox)
        pnlMahasiswaFields.Controls.Add(lblNim)
        pnlMahasiswaFields.Location = New System.Drawing.Point(28, 386)
        pnlMahasiswaFields.Name = "pnlMahasiswaFields"
        pnlMahasiswaFields.Size = New System.Drawing.Size(488, 76)
        pnlMahasiswaFields.TabIndex = 12
        ' 
        ' pnlAngkatanBox
        ' 
        pnlAngkatanBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlAngkatanBox.Controls.Add(txtAngkatan)
        pnlAngkatanBox.Location = New System.Drawing.Point(256, 26)
        pnlAngkatanBox.Name = "pnlAngkatanBox"
        pnlAngkatanBox.Size = New System.Drawing.Size(232, 38)
        pnlAngkatanBox.TabIndex = 3
        ' 
        ' txtAngkatan
        ' 
        txtAngkatan.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtAngkatan.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtAngkatan.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        txtAngkatan.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtAngkatan.Location = New System.Drawing.Point(12, 9)
        txtAngkatan.Name = "txtAngkatan"
        txtAngkatan.PlaceholderText = "Contoh: 2024"
        txtAngkatan.Size = New System.Drawing.Size(208, 17)
        txtAngkatan.TabIndex = 0
        ' 
        ' lblAngkatan
        ' 
        lblAngkatan.AutoSize = True
        lblAngkatan.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblAngkatan.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblAngkatan.Location = New System.Drawing.Point(256, 8)
        lblAngkatan.Name = "lblAngkatan"
        lblAngkatan.Size = New System.Drawing.Size(76, 13)
        lblAngkatan.TabIndex = 2
        lblAngkatan.Text = "ANGKATAN *"
        ' 
        ' pnlNimBox
        ' 
        pnlNimBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlNimBox.Controls.Add(txtNim)
        pnlNimBox.Location = New System.Drawing.Point(0, 26)
        pnlNimBox.Name = "pnlNimBox"
        pnlNimBox.Size = New System.Drawing.Size(240, 38)
        pnlNimBox.TabIndex = 1
        ' 
        ' txtNim
        ' 
        txtNim.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtNim.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtNim.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        txtNim.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtNim.Location = New System.Drawing.Point(12, 9)
        txtNim.Name = "txtNim"
        txtNim.PlaceholderText = "Nomor Induk Mahasiswa"
        txtNim.Size = New System.Drawing.Size(216, 17)
        txtNim.TabIndex = 0
        ' 
        ' lblNim
        ' 
        lblNim.AutoSize = True
        lblNim.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblNim.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblNim.Location = New System.Drawing.Point(0, 8)
        lblNim.Name = "lblNim"
        lblNim.Size = New System.Drawing.Size(193, 13)
        lblNim.TabIndex = 0
        lblNim.Text = "NIM (NOMOR INDUK MAHASISWA) *"
        ' 
        ' pnlDosenFields
        ' 
        pnlDosenFields.Controls.Add(pnlGelarBBox)
        pnlDosenFields.Controls.Add(lblGelarBelakang)
        pnlDosenFields.Controls.Add(pnlGelarDBox)
        pnlDosenFields.Controls.Add(lblGelarDepan)
        pnlDosenFields.Controls.Add(pnlNidnBox)
        pnlDosenFields.Controls.Add(lblNidn)
        pnlDosenFields.Location = New System.Drawing.Point(28, 386)
        pnlDosenFields.Name = "pnlDosenFields"
        pnlDosenFields.Size = New System.Drawing.Size(488, 140)
        pnlDosenFields.TabIndex = 11
        pnlDosenFields.Visible = False
        ' 
        ' pnlGelarBBox
        ' 
        pnlGelarBBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlGelarBBox.Controls.Add(txtGelarBelakang)
        pnlGelarBBox.Location = New System.Drawing.Point(256, 88)
        pnlGelarBBox.Name = "pnlGelarBBox"
        pnlGelarBBox.Size = New System.Drawing.Size(232, 38)
        pnlGelarBBox.TabIndex = 5
        ' 
        ' txtGelarBelakang
        ' 
        txtGelarBelakang.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtGelarBelakang.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtGelarBelakang.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        txtGelarBelakang.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtGelarBelakang.Location = New System.Drawing.Point(12, 9)
        txtGelarBelakang.Name = "txtGelarBelakang"
        txtGelarBelakang.PlaceholderText = "Contoh: S.Kom., M.T."
        txtGelarBelakang.Size = New System.Drawing.Size(208, 17)
        txtGelarBelakang.TabIndex = 0
        ' 
        ' lblGelarBelakang
        ' 
        lblGelarBelakang.AutoSize = True
        lblGelarBelakang.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblGelarBelakang.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblGelarBelakang.Location = New System.Drawing.Point(256, 70)
        lblGelarBelakang.Name = "lblGelarBelakang"
        lblGelarBelakang.Size = New System.Drawing.Size(161, 13)
        lblGelarBelakang.TabIndex = 4
        lblGelarBelakang.Text = "GELAR BELAKANG (OPSIONAL)"
        ' 
        ' pnlGelarDBox
        ' 
        pnlGelarDBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlGelarDBox.Controls.Add(txtGelarDepan)
        pnlGelarDBox.Location = New System.Drawing.Point(0, 88)
        pnlGelarDBox.Name = "pnlGelarDBox"
        pnlGelarDBox.Size = New System.Drawing.Size(240, 38)
        pnlGelarDBox.TabIndex = 3
        ' 
        ' txtGelarDepan
        ' 
        txtGelarDepan.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtGelarDepan.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtGelarDepan.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        txtGelarDepan.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtGelarDepan.Location = New System.Drawing.Point(12, 9)
        txtGelarDepan.Name = "txtGelarDepan"
        txtGelarDepan.PlaceholderText = "Contoh: Dr. / Ir."
        txtGelarDepan.Size = New System.Drawing.Size(216, 17)
        txtGelarDepan.TabIndex = 0
        ' 
        ' lblGelarDepan
        ' 
        lblGelarDepan.AutoSize = True
        lblGelarDepan.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblGelarDepan.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblGelarDepan.Location = New System.Drawing.Point(0, 70)
        lblGelarDepan.Name = "lblGelarDepan"
        lblGelarDepan.Size = New System.Drawing.Size(141, 13)
        lblGelarDepan.TabIndex = 2
        lblGelarDepan.Text = "GELAR DEPAN (OPSIONAL)"
        ' 
        ' pnlNidnBox
        ' 
        pnlNidnBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlNidnBox.Controls.Add(txtNidn)
        pnlNidnBox.Location = New System.Drawing.Point(0, 24)
        pnlNidnBox.Name = "pnlNidnBox"
        pnlNidnBox.Size = New System.Drawing.Size(488, 38)
        pnlNidnBox.TabIndex = 1
        ' 
        ' txtNidn
        ' 
        txtNidn.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtNidn.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtNidn.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        txtNidn.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtNidn.Location = New System.Drawing.Point(12, 9)
        txtNidn.Name = "txtNidn"
        txtNidn.PlaceholderText = "10 Digit NIDN Dosen"
        txtNidn.Size = New System.Drawing.Size(464, 17)
        txtNidn.TabIndex = 0
        ' 
        ' lblNidn
        ' 
        lblNidn.AutoSize = True
        lblNidn.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblNidn.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblNidn.Location = New System.Drawing.Point(0, 6)
        lblNidn.Name = "lblNidn"
        lblNidn.Size = New System.Drawing.Size(236, 13)
        lblNidn.TabIndex = 0
        lblNidn.Text = "NIDN (NOMOR INDUK DOSEN NASIONAL) *"
        ' 
        ' cmbProdi
        ' 
        cmbProdi.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cmbProdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmbProdi.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        cmbProdi.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        cmbProdi.FormattingEnabled = True
        cmbProdi.Items.AddRange(New Object() {"Teknik Informatika", "Teknik Multimedia dan Jaringan", "Teknik Multimedia Digital", "Rekayasa Keamanan Siber"})
        cmbProdi.Location = New System.Drawing.Point(28, 336)
        cmbProdi.Name = "cmbProdi"
        cmbProdi.Size = New System.Drawing.Size(488, 25)
        cmbProdi.TabIndex = 10
        ' 
        ' lblProdi
        ' 
        lblProdi.AutoSize = True
        lblProdi.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblProdi.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblProdi.Location = New System.Drawing.Point(28, 316)
        lblProdi.Name = "lblProdi"
        lblProdi.Size = New System.Drawing.Size(107, 13)
        lblProdi.TabIndex = 9
        lblProdi.Text = "PROGRAM STUDI *"
        ' 
        ' lblPasswordHint
        ' 
        lblPasswordHint.AutoSize = True
        lblPasswordHint.Font = New System.Drawing.Font("Segoe UI", 7.5F)
        lblPasswordHint.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblPasswordHint.Location = New System.Drawing.Point(28, 290)
        lblPasswordHint.Name = "lblPasswordHint"
        lblPasswordHint.Size = New System.Drawing.Size(95, 12)
        lblPasswordHint.TabIndex = 8
        lblPasswordHint.Text = "Minimal 6 karakter"
        ' 
        ' pnlPasswordBox
        ' 
        pnlPasswordBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlPasswordBox.Controls.Add(picTogglePassword)
        pnlPasswordBox.Controls.Add(txtPassword)
        pnlPasswordBox.Location = New System.Drawing.Point(28, 248)
        pnlPasswordBox.Name = "pnlPasswordBox"
        pnlPasswordBox.Size = New System.Drawing.Size(488, 38)
        pnlPasswordBox.TabIndex = 7
        ' 
        ' picTogglePassword
        ' 
        picTogglePassword.Cursor = System.Windows.Forms.Cursors.Hand
        picTogglePassword.Location = New System.Drawing.Point(452, 9)
        picTogglePassword.Name = "picTogglePassword"
        picTogglePassword.Size = New System.Drawing.Size(24, 20)
        picTogglePassword.TabIndex = 1
        picTogglePassword.TabStop = False
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        txtPassword.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtPassword.Location = New System.Drawing.Point(12, 9)
        txtPassword.Name = "txtPassword"
        txtPassword.PlaceholderText = "Masukkan kata sandi baru"
        txtPassword.Size = New System.Drawing.Size(434, 17)
        txtPassword.TabIndex = 0
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblPassword.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblPassword.Location = New System.Drawing.Point(28, 228)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New System.Drawing.Size(80, 13)
        lblPassword.TabIndex = 6
        lblPassword.Text = "KATA SANDI *"
        ' 
        ' pnlEmailBox
        ' 
        pnlEmailBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlEmailBox.Controls.Add(txtEmail)
        pnlEmailBox.Location = New System.Drawing.Point(28, 174)
        pnlEmailBox.Name = "pnlEmailBox"
        pnlEmailBox.Size = New System.Drawing.Size(488, 38)
        pnlEmailBox.TabIndex = 5
        ' 
        ' txtEmail
        ' 
        txtEmail.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        txtEmail.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtEmail.Location = New System.Drawing.Point(12, 9)
        txtEmail.Name = "txtEmail"
        txtEmail.PlaceholderText = "nama@pnj.ac.id"
        txtEmail.Size = New System.Drawing.Size(464, 17)
        txtEmail.TabIndex = 0
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblEmail.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblEmail.Location = New System.Drawing.Point(28, 154)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New System.Drawing.Size(96, 13)
        lblEmail.TabIndex = 4
        lblEmail.Text = "EMAIL KAMPUS *"
        ' 
        ' pnlNamaBox
        ' 
        pnlNamaBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlNamaBox.Controls.Add(txtNama)
        pnlNamaBox.Location = New System.Drawing.Point(28, 100)
        pnlNamaBox.Name = "pnlNamaBox"
        pnlNamaBox.Size = New System.Drawing.Size(488, 38)
        pnlNamaBox.TabIndex = 3
        ' 
        ' txtNama
        ' 
        txtNama.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtNama.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtNama.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        txtNama.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtNama.Location = New System.Drawing.Point(12, 9)
        txtNama.Name = "txtNama"
        txtNama.PlaceholderText = "Nama lengkap pengguna tanpa gelar"
        txtNama.Size = New System.Drawing.Size(464, 17)
        txtNama.TabIndex = 0
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblNama.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblNama.Location = New System.Drawing.Point(28, 80)
        lblNama.Name = "lblNama"
        lblNama.Size = New System.Drawing.Size(102, 13)
        lblNama.TabIndex = 2
        lblNama.Text = "NAMA LENGKAP *"
        ' 
        ' cmbRole
        ' 
        cmbRole.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmbRole.Font = New System.Drawing.Font("Segoe UI", 9.5F)
        cmbRole.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        cmbRole.FormattingEnabled = True
        cmbRole.Items.AddRange(New Object() {"Mahasiswa", "Dosen"})
        cmbRole.Location = New System.Drawing.Point(28, 36)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New System.Drawing.Size(488, 25)
        cmbRole.TabIndex = 1
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblRole.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        lblRole.Location = New System.Drawing.Point(28, 16)
        lblRole.Name = "lblRole"
        lblRole.Size = New System.Drawing.Size(126, 13)
        lblRole.TabIndex = 0
        lblRole.Text = "JENIS AKUN / PERAN *"
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlFooter.Controls.Add(btnSimpan)
        pnlFooter.Controls.Add(btnBatal)
        pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        pnlFooter.Location = New System.Drawing.Point(0, 612)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New System.Windows.Forms.Padding(28, 14, 28, 14)
        pnlFooter.Size = New System.Drawing.Size(560, 68)
        pnlFooter.TabIndex = 2
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        btnSimpan.BackColor = System.Drawing.Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        btnSimpan.FlatAppearance.BorderSize = 0
        btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnSimpan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0F, System.Drawing.FontStyle.Bold)
        btnSimpan.ForeColor = System.Drawing.Color.White
        btnSimpan.Location = New System.Drawing.Point(392, 15)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New System.Drawing.Size(140, 38)
        btnSimpan.TabIndex = 1
        btnSimpan.Text = "Simpan Akun"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' btnBatal
        ' 
        btnBatal.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        btnBatal.BackColor = System.Drawing.Color.White
        btnBatal.Cursor = System.Windows.Forms.Cursors.Hand
        btnBatal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnBatal.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0F, System.Drawing.FontStyle.Bold)
        btnBatal.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        btnBatal.Location = New System.Drawing.Point(292, 15)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New System.Drawing.Size(90, 38)
        btnBatal.TabIndex = 0
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = False
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = System.Drawing.Color.White
        pnlHeader.Controls.Add(btnClose)
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        pnlHeader.Location = New System.Drawing.Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New System.Windows.Forms.Padding(28, 16, 28, 12)
        pnlHeader.Size = New System.Drawing.Size(560, 72)
        pnlHeader.TabIndex = 0
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        btnClose.BackColor = System.Drawing.Color.White
        btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnClose.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Bold)
        btnClose.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        btnClose.Location = New System.Drawing.Point(504, 16)
        btnClose.Name = "btnClose"
        btnClose.Size = New System.Drawing.Size(36, 36)
        btnClose.TabIndex = 2
        btnClose.Text = "✕"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.25F)
        lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSubtitle.Location = New System.Drawing.Point(28, 42)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New System.Drawing.Size(262, 13)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Lengkapi data kredensial akun mahasiswa atau dosen"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New System.Drawing.Font("Segoe UI", 13.0F, System.Drawing.FontStyle.Bold)
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblTitle.Location = New System.Drawing.Point(26, 16)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New System.Drawing.Size(175, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Tambah Akun Baru"
        ' 
        ' AkunModalForm
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 17.0F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        BackColor = System.Drawing.Color.White
        ClientSize = New System.Drawing.Size(560, 680)
        Controls.Add(pnlMainCard)
        Font = New System.Drawing.Font("Segoe UI", 9.5F)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Name = "AkunModalForm"
        ShowInTaskbar = False
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "Manajemen Akun"
        pnlMainCard.ResumeLayout(False)
        pnlBody.ResumeLayout(False)
        pnlBody.PerformLayout()
        pnlMahasiswaFields.ResumeLayout(False)
        pnlMahasiswaFields.PerformLayout()
        pnlAngkatanBox.ResumeLayout(False)
        pnlAngkatanBox.PerformLayout()
        pnlNimBox.ResumeLayout(False)
        pnlNimBox.PerformLayout()
        pnlDosenFields.ResumeLayout(False)
        pnlDosenFields.PerformLayout()
        pnlGelarBBox.ResumeLayout(False)
        pnlGelarBBox.PerformLayout()
        pnlGelarDBox.ResumeLayout(False)
        pnlGelarDBox.PerformLayout()
        pnlNidnBox.ResumeLayout(False)
        pnlNidnBox.PerformLayout()
        pnlPasswordBox.ResumeLayout(False)
        pnlPasswordBox.PerformLayout()
        CType(picTogglePassword, System.ComponentModel.ISupportInitialize).EndInit()
        pnlEmailBox.ResumeLayout(False)
        pnlEmailBox.PerformLayout()
        pnlNamaBox.ResumeLayout(False)
        pnlNamaBox.PerformLayout()
        pnlFooter.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub

End Class

