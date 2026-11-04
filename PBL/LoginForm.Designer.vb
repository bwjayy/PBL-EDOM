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
    Friend WithEvents lblHeroDesc As System.Windows.Forms.Label
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
    Friend WithEvents pnlHint As System.Windows.Forms.Panel
    Friend WithEvents lblHintText As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.picBrandLogo = New System.Windows.Forms.PictureBox()
        Me.lblBrandTitle = New System.Windows.Forms.Label()
        Me.lblBrandSubtitle = New System.Windows.Forms.Label()
        Me.lblHeroDesc = New System.Windows.Forms.Label()
        Me.lblBadgeSemester = New System.Windows.Forms.Label()

        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.lblLoginTitle = New System.Windows.Forms.Label()
        Me.lblLoginSub = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.pnlUsernameUnderline = New System.Windows.Forms.Panel()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.pnlPasswordUnderline = New System.Windows.Forms.Panel()
        Me.chkRemember = New System.Windows.Forms.CheckBox()
        Me.lblForgotPassword = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.pnlHint = New System.Windows.Forms.Panel()
        Me.lblHintText = New System.Windows.Forms.Label()

        CType(Me.picBrandLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeft.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.pnlHint.SuspendLayout()
        Me.SuspendLayout()

        '
        ' pnlLeft (Secondary Dark Navy - #0F172A)
        '
        Me.pnlLeft.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.pnlLeft.Controls.Add(Me.lblBadgeSemester)
        Me.pnlLeft.Controls.Add(Me.lblHeroDesc)
        Me.pnlLeft.Controls.Add(Me.lblBrandSubtitle)
        Me.pnlLeft.Controls.Add(Me.lblBrandTitle)
        Me.pnlLeft.Controls.Add(Me.picBrandLogo)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Padding = New System.Windows.Forms.Padding(36)
        Me.pnlLeft.Size = New System.Drawing.Size(340, 520)
        Me.pnlLeft.TabIndex = 0

        '
        ' picBrandLogo
        '
        Me.picBrandLogo.Location = New System.Drawing.Point(36, 45)
        Me.picBrandLogo.Name = "picBrandLogo"
        Me.picBrandLogo.Size = New System.Drawing.Size(54, 54)
        Me.picBrandLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picBrandLogo.TabIndex = 0
        Me.picBrandLogo.TabStop = False

        '
        ' lblBrandTitle
        '
        Me.lblBrandTitle.AutoSize = True
        Me.lblBrandTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblBrandTitle.ForeColor = System.Drawing.Color.White
        Me.lblBrandTitle.Location = New System.Drawing.Point(32, 115)
        Me.lblBrandTitle.Name = "lblBrandTitle"
        Me.lblBrandTitle.Size = New System.Drawing.Size(147, 30)
        Me.lblBrandTitle.TabIndex = 1
        Me.lblBrandTitle.Text = "EDOM Portal"

        '
        ' lblBrandSubtitle
        '
        Me.lblBrandSubtitle.AutoSize = True
        Me.lblBrandSubtitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblBrandSubtitle.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199) ' Tertiary Cyan #0284C7
        Me.lblBrandSubtitle.Location = New System.Drawing.Point(34, 148)
        Me.lblBrandSubtitle.Name = "lblBrandSubtitle"
        Me.lblBrandSubtitle.Size = New System.Drawing.Size(202, 17)
        Me.lblBrandSubtitle.TabIndex = 2
        Me.lblBrandSubtitle.Text = "Politeknik Negeri Jakarta (PNJ)"

        '
        ' lblHeroDesc
        '
        Me.lblHeroDesc.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblHeroDesc.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
        Me.lblHeroDesc.Location = New System.Drawing.Point(34, 195)
        Me.lblHeroDesc.Name = "lblHeroDesc"
        Me.lblHeroDesc.Size = New System.Drawing.Size(265, 110)
        Me.lblHeroDesc.TabIndex = 3
        Me.lblHeroDesc.Text = "Sistem evaluasi dosen oleh mahasiswa secara transparan, objektif, dan terintegrasi" &
    " untuk peningkatan mutu akademik perkuliahan semester berjalan."

        '
        ' lblBadgeSemester
        '
        Me.lblBadgeSemester.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBadgeSemester.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblBadgeSemester.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblBadgeSemester.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.lblBadgeSemester.Location = New System.Drawing.Point(36, 435)
        Me.lblBadgeSemester.Name = "lblBadgeSemester"
        Me.lblBadgeSemester.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.lblBadgeSemester.Size = New System.Drawing.Size(265, 34)
        Me.lblBadgeSemester.TabIndex = 4
        Me.lblBadgeSemester.Text = "Tahun Akademik: 2026/2027 Ganjil"
        Me.lblBadgeSemester.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '
        ' pnlRight (Pure White Card Form)
        '
        Me.pnlRight.BackColor = System.Drawing.Color.White
        Me.pnlRight.Controls.Add(Me.pnlHint)
        Me.pnlRight.Controls.Add(Me.btnLogin)
        Me.pnlRight.Controls.Add(Me.lblForgotPassword)
        Me.pnlRight.Controls.Add(Me.chkRemember)
        Me.pnlRight.Controls.Add(Me.pnlPasswordUnderline)
        Me.pnlRight.Controls.Add(Me.txtPassword)
        Me.pnlRight.Controls.Add(Me.lblPassword)
        Me.pnlRight.Controls.Add(Me.pnlUsernameUnderline)
        Me.pnlRight.Controls.Add(Me.txtUsername)
        Me.pnlRight.Controls.Add(Me.lblUsername)
        Me.pnlRight.Controls.Add(Me.lblLoginSub)
        Me.pnlRight.Controls.Add(Me.lblLoginTitle)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(340, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Padding = New System.Windows.Forms.Padding(48, 40, 48, 30)
        Me.pnlRight.Size = New System.Drawing.Size(484, 520)
        Me.pnlRight.TabIndex = 1

        '
        ' lblLoginTitle
        '
        Me.lblLoginTitle.AutoSize = True
        Me.lblLoginTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblLoginTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblLoginTitle.Location = New System.Drawing.Point(44, 40)
        Me.lblLoginTitle.Name = "lblLoginTitle"
        Me.lblLoginTitle.Size = New System.Drawing.Size(193, 30)
        Me.lblLoginTitle.TabIndex = 0
        Me.lblLoginTitle.Text = "Selamat Datang 👋"

        '
        ' lblLoginSub
        '
        Me.lblLoginSub.AutoSize = True
        Me.lblLoginSub.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblLoginSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139) ' Neutral Slate #64748B
        Me.lblLoginSub.Location = New System.Drawing.Point(46, 73)
        Me.lblLoginSub.Name = "lblLoginSub"
        Me.lblLoginSub.Size = New System.Drawing.Size(262, 17)
        Me.lblLoginSub.TabIndex = 1
        Me.lblLoginSub.Text = "Silakan masuk dengan akun mahasiswa Anda"

        '
        ' lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI Semibold", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblUsername.Location = New System.Drawing.Point(46, 118)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(106, 17)
        Me.lblUsername.TabIndex = 2
        Me.lblUsername.Text = "NIM / Username"

        '
        ' txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtUsername.Location = New System.Drawing.Point(48, 142)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.PlaceholderText = "Masukkan NIM atau Username bebas..."
        Me.txtUsername.Size = New System.Drawing.Size(388, 19)
        Me.txtUsername.TabIndex = 3
        Me.txtUsername.Text = "2207411001"

        '
        ' pnlUsernameUnderline
        '
        Me.pnlUsernameUnderline.BackColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.pnlUsernameUnderline.Location = New System.Drawing.Point(48, 168)
        Me.pnlUsernameUnderline.Name = "pnlUsernameUnderline"
        Me.pnlUsernameUnderline.Size = New System.Drawing.Size(388, 2)
        Me.pnlUsernameUnderline.TabIndex = 4

        '
        ' lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI Semibold", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblPassword.Location = New System.Drawing.Point(46, 190)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(73, 17)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.Text = "Kata Sandi"

        '
        ' txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtPassword.Location = New System.Drawing.Point(48, 214)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.PlaceholderText = "Masukkan kata sandi..."
        Me.txtPassword.Size = New System.Drawing.Size(388, 19)
        Me.txtPassword.TabIndex = 6
        Me.txtPassword.Text = "password123"

        '
        ' pnlPasswordUnderline
        '
        Me.pnlPasswordUnderline.BackColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.pnlPasswordUnderline.Location = New System.Drawing.Point(48, 240)
        Me.pnlPasswordUnderline.Name = "pnlPasswordUnderline"
        Me.pnlPasswordUnderline.Size = New System.Drawing.Size(388, 2)
        Me.pnlPasswordUnderline.TabIndex = 7

        '
        ' chkRemember
        '
        Me.chkRemember.AutoSize = True
        Me.chkRemember.Checked = True
        Me.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRemember.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.chkRemember.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.chkRemember.Location = New System.Drawing.Point(48, 258)
        Me.chkRemember.Name = "chkRemember"
        Me.chkRemember.Size = New System.Drawing.Size(84, 19)
        Me.chkRemember.TabIndex = 8
        Me.chkRemember.Text = "Ingat saya"
        Me.chkRemember.UseVisualStyleBackColor = True

        '
        ' lblForgotPassword
        '
        Me.lblForgotPassword.AutoSize = True
        Me.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblForgotPassword.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblForgotPassword.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199) ' Tertiary Cyan
        Me.lblForgotPassword.Location = New System.Drawing.Point(336, 258)
        Me.lblForgotPassword.Name = "lblForgotPassword"
        Me.lblForgotPassword.Size = New System.Drawing.Size(100, 15)
        Me.lblForgotPassword.TabIndex = 9
        Me.lblForgotPassword.Text = "Lupa kata sandi?"

        '
        ' btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(30, 58, 138) ' Primary Blue #1E3A8A
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(48, 300)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(388, 44)
        Me.btnLogin.TabIndex = 10
        Me.btnLogin.Text = "Masuk ke Dashboard"
        Me.btnLogin.UseVisualStyleBackColor = False

        '
        ' pnlHint
        '
        Me.pnlHint.BackColor = System.Drawing.Color.FromArgb(241, 245, 249) ' Soft Gray #F1F5F9
        Me.pnlHint.Controls.Add(Me.lblHintText)
        Me.pnlHint.Location = New System.Drawing.Point(48, 365)
        Me.pnlHint.Name = "pnlHint"
        Me.pnlHint.Padding = New System.Windows.Forms.Padding(14, 10, 14, 10)
        Me.pnlHint.Size = New System.Drawing.Size(388, 70)
        Me.pnlHint.TabIndex = 11

        '
        ' lblHintText
        '
        Me.lblHintText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHintText.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblHintText.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblHintText.Location = New System.Drawing.Point(14, 10)
        Me.lblHintText.Name = "lblHintText"
        Me.lblHintText.Size = New System.Drawing.Size(360, 50)
        Me.lblHintText.TabIndex = 0
        Me.lblHintText.Text = "💡 Demo UI: Pengisian bebas tanpa validasi/backend." & vbCrLf & "Cukup klik 'Masuk ke Dash" &
    "board' untuk langsung membuka Dashboard."

        '
        ' LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(824, 520)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.pnlLeft)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Masuk - EDOM Portal (Politeknik Negeri Jakarta)"

        CType(Me.picBrandLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeft.PerformLayout()
        Me.pnlRight.ResumeLayout(False)
        Me.pnlRight.PerformLayout()
        Me.pnlHint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

End Class

