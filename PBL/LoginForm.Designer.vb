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

    Friend WithEvents pnlCard As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents pnlEmailInput As System.Windows.Forms.Panel
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents pnlPasswordInput As System.Windows.Forms.Panel
    Friend WithEvents picLockIcon As System.Windows.Forms.PictureBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlCard = New Panel()
        btnLogin = New Button()
        pnlPasswordInput = New Panel()
        txtPassword = New TextBox()
        picLockIcon = New PictureBox()
        lblPassword = New Label()
        pnlEmailInput = New Panel()
        txtEmail = New TextBox()
        lblEmail = New Label()
        lblSubtitle = New Label()
        lblTitle = New Label()
        picTogglePassword = New PictureBox()
        picMailIcon = New PictureBox()
        pnlCard.SuspendLayout()
        pnlPasswordInput.SuspendLayout()
        CType(picLockIcon, ComponentModel.ISupportInitialize).BeginInit()
        pnlEmailInput.SuspendLayout()
        CType(picTogglePassword, ComponentModel.ISupportInitialize).BeginInit()
        CType(picMailIcon, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlCard
        ' 
        pnlCard.BackColor = Color.White
        pnlCard.Controls.Add(btnLogin)
        pnlCard.Controls.Add(pnlPasswordInput)
        pnlCard.Controls.Add(lblPassword)
        pnlCard.Controls.Add(pnlEmailInput)
        pnlCard.Controls.Add(lblEmail)
        pnlCard.Controls.Add(lblSubtitle)
        pnlCard.Controls.Add(lblTitle)
        pnlCard.Location = New Point(160, 95)
        pnlCard.Name = "pnlCard"
        pnlCard.Size = New Size(400, 360)
        pnlCard.TabIndex = 0
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(32, 276)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(336, 44)
        btnLogin.TabIndex = 6
        btnLogin.Text = "➔   Masuk"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' pnlPasswordInput
        ' 
        pnlPasswordInput.BackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        pnlPasswordInput.Controls.Add(picTogglePassword)
        pnlPasswordInput.Controls.Add(txtPassword)
        pnlPasswordInput.Controls.Add(picLockIcon)
        pnlPasswordInput.Cursor = Cursors.IBeam
        pnlPasswordInput.Location = New Point(32, 212)
        pnlPasswordInput.Name = "pnlPasswordInput"
        pnlPasswordInput.Size = New Size(336, 42)
        pnlPasswordInput.TabIndex = 5
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 9.75F)
        txtPassword.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtPassword.Location = New Point(36, 11)
        txtPassword.Name = "txtPassword"
        txtPassword.PlaceholderText = "Masukkan kata sandi"
        txtPassword.Size = New Size(262, 22)
        txtPassword.TabIndex = 1
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' picLockIcon
        ' 
        picLockIcon.Location = New Point(10, 11)
        picLockIcon.Name = "picLockIcon"
        picLockIcon.Size = New Size(20, 20)
        picLockIcon.TabIndex = 0
        picLockIcon.TabStop = False
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI Semibold", 8.5F, FontStyle.Bold)
        lblPassword.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
        lblPassword.Location = New Point(32, 188)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(81, 20)
        lblPassword.TabIndex = 4
        lblPassword.Text = "Kata Sandi"
        ' 
        ' pnlEmailInput
        ' 
        pnlEmailInput.BackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        pnlEmailInput.Controls.Add(txtEmail)
        pnlEmailInput.Controls.Add(picMailIcon)
        pnlEmailInput.Cursor = Cursors.IBeam
        pnlEmailInput.Location = New Point(32, 134)
        pnlEmailInput.Name = "pnlEmailInput"
        pnlEmailInput.Size = New Size(336, 42)
        pnlEmailInput.TabIndex = 3
        ' 
        ' txtEmail
        ' 
        txtEmail.BackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.Font = New Font("Segoe UI", 9.75F)
        txtEmail.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtEmail.Location = New Point(36, 11)
        txtEmail.Name = "txtEmail"
        txtEmail.PlaceholderText = "nama@univ.ac.id atau NIP"
        txtEmail.Size = New Size(290, 22)
        txtEmail.TabIndex = 1
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI Semibold", 8.5F, FontStyle.Bold)
        lblEmail.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
        lblEmail.Location = New Point(32, 110)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(185, 20)
        lblEmail.TabIndex = 2
        lblEmail.Text = "Email Institusi / NIP / NIM"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 9.25F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSubtitle.Location = New Point(0, 68)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(400, 24)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Masuk ke Akun Portal Anda"
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblTitle.Location = New Point(0, 32)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(400, 35)
        lblTitle.TabIndex = 0
        lblTitle.Text = "EDOM"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picTogglePassword
        ' 
        picTogglePassword.Cursor = Cursors.Hand
        picTogglePassword.Location = New Point(304, 11)
        picTogglePassword.Name = "picTogglePassword"
        picTogglePassword.Size = New Size(22, 20)
        picTogglePassword.TabIndex = 2
        picTogglePassword.TabStop = False
        ' 
        ' picMailIcon
        ' 
        picMailIcon.Location = New Point(10, 11)
        picMailIcon.Name = "picMailIcon"
        picMailIcon.Size = New Size(20, 20)
        picMailIcon.TabIndex = 0
        picMailIcon.TabStop = False
        ' 
        ' LoginForm
        ' 
        AcceptButton = btnLogin
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        ClientSize = New Size(720, 560)
        Controls.Add(pnlCard)
        Font = New Font("Segoe UI", 9.0F)
        MinimumSize = New Size(480, 460)
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "EDOM Portal - Masuk"
        pnlCard.ResumeLayout(False)
        pnlCard.PerformLayout()
        pnlPasswordInput.ResumeLayout(False)
        pnlPasswordInput.PerformLayout()
        CType(picLockIcon, ComponentModel.ISupportInitialize).EndInit()
        pnlEmailInput.ResumeLayout(False)
        pnlEmailInput.PerformLayout()
        CType(picTogglePassword, ComponentModel.ISupportInitialize).EndInit()
        CType(picMailIcon, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents picTogglePassword As PictureBox
    Friend WithEvents picMailIcon As PictureBox

End Class
