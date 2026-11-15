Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class AkunModalForm

    Private ReadOnly colorNavy As Color = Color.FromArgb(10, 37, 88)
    Private ReadOnly colorBorder As Color = Color.FromArgb(226, 232, 240)
    Private ReadOnly colorMuted As Color = Color.FromArgb(100, 116, 139)

    Private ReadOnly isEditMode As Boolean
    Private ReadOnly targetAccount As UserAccountModel
    Private focusedBox As Panel = Nothing

    Public Sub New(Optional accountToEdit As UserAccountModel = Nothing)
        InitializeComponent()
        targetAccount = accountToEdit
        isEditMode = (accountToEdit IsNot Nothing)
    End Sub

    Private Sub AkunModalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyRegions()
        PositionCloseButton()

        If cmbProdi.Items.Count > 0 AndAlso cmbProdi.SelectedIndex < 0 Then
            cmbProdi.SelectedIndex = 0
        End If

        If isEditMode Then
            lblTitle.Text = "Edit Akun Pengguna"
            lblSubtitle.Text = "Perbarui profil dan kata sandi untuk " & targetAccount.Nama
            btnSimpan.Text = "Simpan Perubahan"

            Dim roleName = If(targetAccount.Role.ToLower() = "dosen", "Dosen", "Mahasiswa")
            cmbRole.SelectedItem = roleName
            cmbRole.Enabled = False

            txtNama.Text = targetAccount.Nama
            txtEmail.Text = targetAccount.Email
            cmbProdi.SelectedItem = targetAccount.Prodi

            lblPassword.Text = "KATA SANDI (KOSONGKAN JIKA TIDAK DIUBAH)"
            lblPasswordHint.Text = "Isi hanya bila Anda ingin mereset/mengganti kata sandi akun ini"
            txtPassword.PlaceholderText = "Masukkan kata sandi baru (opsional)"

            If targetAccount.Role.ToLower() = "dosen" Then
                txtNidn.Text = targetAccount.Nidn
                txtGelarDepan.Text = targetAccount.GelarDepan
                txtGelarBelakang.Text = targetAccount.GelarBelakang
            Else
                txtNim.Text = targetAccount.Nim
                txtAngkatan.Text = If(targetAccount.Angkatan > 0, targetAccount.Angkatan.ToString(), "2024")
            End If
        Else
            lblTitle.Text = "Tambah Akun Baru"
            lblSubtitle.Text = "Lengkapi data kredensial akun mahasiswa atau dosen"
            btnSimpan.Text = "Buat Akun"
            cmbRole.SelectedIndex = 0 ' Default Mahasiswa
        End If

        UpdateRoleFieldVisibility()
    End Sub

    Private Sub UpdateRoleFieldVisibility()
        Dim isDosen As Boolean = (cmbRole.SelectedItem IsNot Nothing AndAlso cmbRole.SelectedItem.ToString() = "Dosen")
        pnlDosenFields.Visible = isDosen
        pnlMahasiswaFields.Visible = Not isDosen
    End Sub

    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        UpdateRoleFieldVisibility()
    End Sub

    Private Sub ApplyRegions()
        Me.Region = New Region(GetRoundedPath(New Rectangle(0, 0, Me.Width, Me.Height), 12))
        btnBatal.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnBatal.Width, btnBatal.Height), 6))
        btnSimpan.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnSimpan.Width, btnSimpan.Height), 6))
        btnClose.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnClose.Width, btnClose.Height), 6))

        Dim boxes = {pnlNamaBox, pnlEmailBox, pnlPasswordBox, pnlNidnBox, pnlGelarDBox, pnlGelarBBox, pnlNimBox, pnlAngkatanBox}
        For Each box In boxes
            If box IsNot Nothing Then
                box.Region = New Region(GetRoundedPath(New Rectangle(0, 0, box.Width, box.Height), 6))
            End If
        Next
    End Sub

    Private Sub PositionCloseButton()
        If btnClose IsNot Nothing AndAlso pnlHeader IsNot Nothing Then
            btnClose.Location = New Point(pnlHeader.ClientSize.Width - btnClose.Width - 24, 18)
            btnClose.BringToFront()
        End If
    End Sub

    Private Sub pnlHeader_Resize(sender As Object, e As EventArgs) Handles pnlHeader.Resize
        PositionCloseButton()
    End Sub

    Private Sub AkunModalForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using penBdr As New Pen(Color.FromArgb(203, 213, 225), 1.0!)
            e.Graphics.DrawPath(penBdr, GetRoundedPath(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 12))
        End Using
    End Sub

    ' Input Focus Highlight
    Private Sub Input_Enter(sender As Object, e As EventArgs) Handles txtNama.Enter, txtEmail.Enter, txtPassword.Enter,
                                                                      txtNidn.Enter, txtGelarDepan.Enter, txtGelarBelakang.Enter,
                                                                      txtNim.Enter, txtAngkatan.Enter
        Dim tb = CType(sender, TextBox)
        focusedBox = TryCast(tb.Parent, Panel)
        If focusedBox IsNot Nothing Then focusedBox.Invalidate()
    End Sub

    Private Sub Input_Leave(sender As Object, e As EventArgs) Handles txtNama.Leave, txtEmail.Leave, txtPassword.Leave,
                                                                      txtNidn.Leave, txtGelarDepan.Leave, txtGelarBelakang.Leave,
                                                                      txtNim.Leave, txtAngkatan.Leave
        Dim prevBox = focusedBox
        focusedBox = Nothing
        If prevBox IsNot Nothing Then prevBox.Invalidate()
    End Sub

    Private Sub Box_Paint(sender As Object, e As PaintEventArgs) Handles pnlNamaBox.Paint, pnlEmailBox.Paint, pnlPasswordBox.Paint,
                                                                         pnlNidnBox.Paint, pnlGelarDBox.Paint, pnlGelarBBox.Paint,
                                                                         pnlNimBox.Paint, pnlAngkatanBox.Paint
        Dim box = CType(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim isFocus = (box Is focusedBox)
        Dim bdrColor = If(isFocus, colorNavy, colorBorder)
        Using path = GetRoundedPath(New Rectangle(0, 0, box.Width - 1, box.Height - 1), 6),
              pen As New Pen(bdrColor, If(isFocus, 1.5!, 1.0!))
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    ' Toggle Mask Password
    Private Sub picTogglePassword_Click(sender As Object, e As EventArgs) Handles picTogglePassword.Click
        txtPassword.UseSystemPasswordChar = Not txtPassword.UseSystemPasswordChar
        picTogglePassword.Invalidate()
    End Sub

    Private Sub picTogglePassword_Paint(sender As Object, e As PaintEventArgs) Handles picTogglePassword.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using pen As New Pen(colorMuted, 1.4!)
            Dim ptsTop() As Point = {New Point(2, 9), New Point(10, 4), New Point(18, 9)}
            Dim ptsBtm() As Point = {New Point(2, 9), New Point(10, 14), New Point(18, 9)}
            e.Graphics.DrawCurve(pen, ptsTop)
            e.Graphics.DrawCurve(pen, ptsBtm)
            Using br As New SolidBrush(colorMuted)
                e.Graphics.FillEllipse(br, 8, 7, 4, 4)
            End Using
            If txtPassword.UseSystemPasswordChar Then
                e.Graphics.DrawLine(pen, 3, 3, 17, 15)
            End If
        End Using
    End Sub

    ' Tombol Batal & Tutup
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click, btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.BackColor = Color.FromArgb(241, 245, 249)
        btnClose.ForeColor = Color.FromArgb(15, 23, 42)
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackColor = Color.White
        btnClose.ForeColor = colorMuted
    End Sub

    ' Validasi dan Simpan
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim roleStr = If(cmbRole.SelectedItem IsNot Nothing, cmbRole.SelectedItem.ToString().ToLower(), "mahasiswa")
        Dim nama = txtNama.Text.Trim()
        Dim email = txtEmail.Text.Trim()
        Dim password = txtPassword.Text
        Dim prodiName = If(cmbProdi.SelectedItem IsNot Nothing, cmbProdi.SelectedItem.ToString(), "Teknik Informatika")
        Dim prodiId = AkunRepository.GetProdiId(prodiName)

        ' Validasi Nama
        If String.IsNullOrWhiteSpace(nama) Then
            MessageBox.Show("Nama lengkap pengguna wajib diisi.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Return
        End If

        ' Validasi Email
        If String.IsNullOrWhiteSpace(email) OrElse Not email.Contains("@") Then
            MessageBox.Show("Email kampus tidak valid. Pastikan format email sudah benar (contoh: user@pnj.ac.id).", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        ' Validasi Kata Sandi
        If Not isEditMode Then
            If String.IsNullOrWhiteSpace(password) Then
                MessageBox.Show("Kata sandi awal wajib diisi untuk akun baru.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If
            If password.Length < 4 Then
                MessageBox.Show("Kata sandi terlalu pendek. Gunakan minimal 4 karakter.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If
        Else
            If Not String.IsNullOrWhiteSpace(password) AndAlso password.Length < 4 Then
                MessageBox.Show("Kata sandi baru terlalu pendek. Gunakan minimal 4 karakter.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If
        End If

        ' Validasi Role Specific
        Dim nidnVal As String = ""
        Dim gelarDVal As String = ""
        Dim gelarBVal As String = ""
        Dim nimVal As String = ""
        Dim angkatanVal As Integer = 2024

        If roleStr = "dosen" Then
            nidnVal = txtNidn.Text.Trim()
            If String.IsNullOrWhiteSpace(nidnVal) Then
                MessageBox.Show("Nomor Induk Dosen Nasional (NIDN) wajib diisi.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNidn.Focus()
                Return
            End If
            gelarDVal = txtGelarDepan.Text.Trim()
            gelarBVal = txtGelarBelakang.Text.Trim()
        Else
            nimVal = txtNim.Text.Trim()
            If String.IsNullOrWhiteSpace(nimVal) Then
                MessageBox.Show("Nomor Induk Mahasiswa (NIM) wajib diisi.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNim.Focus()
                Return
            End If
            If Not Integer.TryParse(txtAngkatan.Text.Trim(), angkatanVal) OrElse angkatanVal < 2000 OrElse angkatanVal > 2035 Then
                MessageBox.Show("Tahun angkatan harus berupa angka 4 digit yang valid (contoh: 2024).", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAngkatan.Focus()
                Return
            End If
        End If

        ' Eksekusi Simpan / Update
        Dim err As String = ""
        If Not isEditMode Then
            Dim newAcc As New UserAccountModel With {
                .Role = roleStr,
                .Nama = nama,
                .Email = email,
                .PasswordHash = password,
                .ProdiId = prodiId,
                .Prodi = prodiName,
                .Nidn = nidnVal,
                .GelarDepan = gelarDVal,
                .GelarBelakang = gelarBVal,
                .Nim = nimVal,
                .Angkatan = angkatanVal
            }
            If Not AkunRepository.CreateAccount(newAcc, err) Then
                MessageBox.Show(err, "Gagal Menambahkan Akun", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            MessageBox.Show("Akun " & roleStr & " untuk '" & nama & "' berhasil dibuat.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            targetAccount.Nama = nama
            targetAccount.Email = email
            targetAccount.ProdiId = prodiId
            targetAccount.Prodi = prodiName
            If roleStr = "dosen" Then
                targetAccount.Nidn = nidnVal
                targetAccount.GelarDepan = gelarDVal
                targetAccount.GelarBelakang = gelarBVal
            Else
                targetAccount.Nim = nimVal
                targetAccount.Angkatan = angkatanVal
            End If

            If Not AkunRepository.UpdateAccount(targetAccount, password, err) Then
                MessageBox.Show(err, "Gagal Memperbarui Akun", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim passInfo = If(Not String.IsNullOrWhiteSpace(password), " Kata sandi berhasil diperbarui.", "")
            MessageBox.Show("Perubahan akun untuk '" & nama & "' berhasil disimpan." & passInfo, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' Header Dragging
    Private isDragging As Boolean = False
    Private dragCursorPoint As Point
    Private dragFormPoint As Point

    Private Sub pnlHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlHeader.MouseDown, lblTitle.MouseDown, lblSubtitle.MouseDown
        isDragging = True
        dragCursorPoint = Cursor.Position
        dragFormPoint = Me.Location
    End Sub

    Private Sub pnlHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlHeader.MouseMove, lblTitle.MouseMove, lblSubtitle.MouseMove
        If isDragging Then
            Dim diff = Point.Subtract(Cursor.Position, New Size(dragCursorPoint))
            Me.Location = Point.Add(dragFormPoint, New Size(diff))
        End If
    End Sub

    Private Sub pnlHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlHeader.MouseUp, lblTitle.MouseUp, lblSubtitle.MouseUp
        isDragging = False
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

