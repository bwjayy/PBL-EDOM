<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
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

    ' Controls
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents lblBrandTitle As System.Windows.Forms.Label
    Friend WithEvents lblBrandSubtitle As System.Windows.Forms.Label
    Friend WithEvents lblBadgeSemester As System.Windows.Forms.Label
    Friend WithEvents picBrandLogo As System.Windows.Forms.PictureBox

    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents lblLoginTitle As System.Windows.Forms.Label
    Friend WithEvents lblLoginSub As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents pnlUsernameUnderline As System.Windows.Forms.Panel
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents pnlPasswordUnderline As System.Windows.Forms.Panel
    Friend WithEvents chkRemember As System.Windows.Forms.CheckBox
    Friend WithEvents lblForgotPassword As System.Windows.Forms.Label
    Friend WithEvents btnLogin As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlLeft = New Panel()
        lblBadgeSemester = New Label()
        lblBrandSubtitle = New Label()
        lblBrandTitle = New Label()
        picBrandLogo = New PictureBox()
        pnlRight = New Panel()
        btnLogin = New Button()
        lblForgotPassword = New Label()
        chkRemember = New CheckBox()
        pnlPasswordUnderline = New Panel()
        txtPassword = New TextBox()
        lblPassword = New Label()
        pnlUsernameUnderline = New Panel()
        txtUsername = New TextBox()
        lblUsername = New Label()
        lblLoginSub = New Label()
        lblLoginTitle = New Label()
        pnlLeft.SuspendLayout()
        CType(picBrandLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        pnlLeft.Controls.Add(lblBadgeSemester)
        pnlLeft.Controls.Add(lblBrandSubtitle)
        pnlLeft.Controls.Add(lblBrandTitle)
        pnlLeft.Controls.Add(picBrandLogo)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Margin = New Padding(3, 4, 3, 4)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Padding = New Padding(41, 48, 41, 48)
        pnlLeft.Size = New Size(389, 693)
        pnlLeft.TabIndex = 0
        ' 
        ' lblBadgeSemester
        ' 
        lblBadgeSemester.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblBadgeSemester.BackColor = Color.FromArgb(CByte(30), CByte(41), CByte(59))
        lblBadgeSemester.Font = New Font("Segoe UI Semibold", 8.5F, FontStyle.Bold)
        lblBadgeSemester.ForeColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        lblBadgeSemester.Location = New Point(41, 580)
        lblBadgeSemester.Name = "lblBadgeSemester"
        lblBadgeSemester.Padding = New Padding(11, 8, 11, 8)
        lblBadgeSemester.Size = New Size(303, 45)
        lblBadgeSemester.TabIndex = 4
        lblBadgeSemester.Text = "Tahun Akademik: 2026/2027 Ganjil"
        lblBadgeSemester.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblBrandSubtitle
        ' 
        lblBrandSubtitle.AutoSize = True
        lblBrandSubtitle.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        lblBrandSubtitle.ForeColor = Color.FromArgb(CByte(2), CByte(132), CByte(199))
        lblBrandSubtitle.Location = New Point(39, 197)
        lblBrandSubtitle.Name = "lblBrandSubtitle"
        lblBrandSubtitle.Size = New Size(247, 23)
        lblBrandSubtitle.TabIndex = 2
        lblBrandSubtitle.Text = "Politeknik Negeri Jakarta (PNJ)"
        ' 
        ' lblBrandTitle
        ' 
        lblBrandTitle.AutoSize = True
        lblBrandTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblBrandTitle.ForeColor = Color.White
        lblBrandTitle.Location = New Point(37, 153)
        lblBrandTitle.Name = "lblBrandTitle"
        lblBrandTitle.Size = New Size(183, 37)
        lblBrandTitle.TabIndex = 1
        lblBrandTitle.Text = "EDOM Portal"
        ' 
        ' picBrandLogo
        ' 
        picBrandLogo.Location = New Point(41, 60)
        picBrandLogo.Margin = New Padding(3, 4, 3, 4)
        picBrandLogo.Name = "picBrandLogo"
        picBrandLogo.Size = New Size(62, 72)
        picBrandLogo.SizeMode = PictureBoxSizeMode.CenterImage
        picBrandLogo.TabIndex = 0
        picBrandLogo.TabStop = False
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.White
        pnlRight.Controls.Add(btnLogin)
        pnlRight.Controls.Add(lblForgotPassword)
        pnlRight.Controls.Add(chkRemember)
        pnlRight.Controls.Add(pnlPasswordUnderline)
        pnlRight.Controls.Add(txtPassword)
        pnlRight.Controls.Add(lblPassword)
        pnlRight.Controls.Add(pnlUsernameUnderline)
        pnlRight.Controls.Add(txtUsername)
        pnlRight.Controls.Add(lblUsername)
        pnlRight.Controls.Add(lblLoginSub)
        pnlRight.Controls.Add(lblLoginTitle)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(389, 0)
        pnlRight.Margin = New Padding(3, 4, 3, 4)
        pnlRight.Name = "pnlRight"
        pnlRight.Padding = New Padding(55, 53, 55, 40)
        pnlRight.Size = New Size(553, 693)
        pnlRight.TabIndex = 1
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(30), CByte(58), CByte(138))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(55, 400)
        btnLogin.Margin = New Padding(3, 4, 3, 4)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(443, 59)
        btnLogin.TabIndex = 10
        btnLogin.Text = "Masuk ke Dashboard"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' lblForgotPassword
        ' 
        lblForgotPassword.AutoSize = True
        lblForgotPassword.Cursor = Cursors.Hand
        lblForgotPassword.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        lblForgotPassword.ForeColor = Color.FromArgb(CByte(2), CByte(132), CByte(199))
        lblForgotPassword.Location = New Point(384, 344)
        lblForgotPassword.Name = "lblForgotPassword"
        lblForgotPassword.Size = New Size(122, 20)
        lblForgotPassword.TabIndex = 9
        lblForgotPassword.Text = "Lupa kata sandi?"
        ' 
        ' chkRemember
        ' 
        chkRemember.AutoSize = True
        chkRemember.Checked = True
        chkRemember.CheckState = CheckState.Checked
        chkRemember.Font = New Font("Segoe UI", 9.0F)
        chkRemember.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        chkRemember.Location = New Point(55, 344)
        chkRemember.Margin = New Padding(3, 4, 3, 4)
        chkRemember.Name = "chkRemember"
        chkRemember.Size = New Size(98, 24)
        chkRemember.TabIndex = 8
        chkRemember.Text = "Ingat saya"
        chkRemember.UseVisualStyleBackColor = True
        ' 
        ' pnlPasswordUnderline
        ' 
        pnlPasswordUnderline.BackColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
        pnlPasswordUnderline.Location = New Point(55, 320)
        pnlPasswordUnderline.Margin = New Padding(3, 4, 3, 4)
        pnlPasswordUnderline.Name = "pnlPasswordUnderline"
        pnlPasswordUnderline.Size = New Size(443, 3)
        pnlPasswordUnderline.TabIndex = 7
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 10.5F)
        txtPassword.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtPassword.Location = New Point(55, 285)
        txtPassword.Margin = New Padding(3, 4, 3, 4)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.PlaceholderText = "Masukkan kata sandi..."
        txtPassword.Size = New Size(443, 24)
        txtPassword.TabIndex = 6
        txtPassword.Text = "password123"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI Semibold", 9.25F, FontStyle.Bold)
        lblPassword.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
        lblPassword.Location = New Point(53, 253)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(86, 21)
        lblPassword.TabIndex = 5
        lblPassword.Text = "Kata Sandi"
        ' 
        ' pnlUsernameUnderline
        ' 
        pnlUsernameUnderline.BackColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
        pnlUsernameUnderline.Location = New Point(55, 224)
        pnlUsernameUnderline.Margin = New Padding(3, 4, 3, 4)
        pnlUsernameUnderline.Name = "pnlUsernameUnderline"
        pnlUsernameUnderline.Size = New Size(443, 3)
        pnlUsernameUnderline.TabIndex = 4
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Segoe UI", 10.5F)
        txtUsername.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtUsername.Location = New Point(55, 189)
        txtUsername.Margin = New Padding(3, 4, 3, 4)
        txtUsername.Name = "txtUsername"
        txtUsername.PlaceholderText = "Masukkan NIM atau Username bebas..."
        txtUsername.Size = New Size(443, 24)
        txtUsername.TabIndex = 3
        txtUsername.Text = "2207411001"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI Semibold", 9.25F, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
        lblUsername.Location = New Point(53, 157)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(130, 21)
        lblUsername.TabIndex = 2
        lblUsername.Text = "NIM / Username"
        ' 
        ' lblLoginSub
        ' 
        lblLoginSub.AutoSize = True
        lblLoginSub.Font = New Font("Segoe UI", 9.25F)
        lblLoginSub.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblLoginSub.Location = New Point(53, 97)
        lblLoginSub.Name = "lblLoginSub"
        lblLoginSub.Size = New Size(325, 21)
        lblLoginSub.TabIndex = 1
        lblLoginSub.Text = "Silakan masuk dengan akun mahasiswa Anda"
        ' 
        ' lblLoginTitle
        ' 
        lblLoginTitle.AutoSize = True
        lblLoginTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblLoginTitle.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblLoginTitle.Location = New Point(50, 53)
        lblLoginTitle.Name = "lblLoginTitle"
        lblLoginTitle.Size = New Size(222, 37)
        lblLoginTitle.TabIndex = 0
        lblLoginTitle.Text = "Selamat Datang"
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(942, 693)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Masuk - EDOM Portal (Politeknik Negeri Jakarta)"
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        CType(picBrandLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)

    End Sub

End Class

