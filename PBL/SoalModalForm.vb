Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class SoalModalForm

    Private ReadOnly colorNavy As Color = Color.FromArgb(10, 37, 88)
    Private ReadOnly colorBorder As Color = Color.FromArgb(226, 232, 240)
    Private ReadOnly colorMuted As Color = Color.FromArgb(100, 116, 139)

    Private ReadOnly isEditMode As Boolean
    Private ReadOnly targetSoal As SoalKuisionerModel
    Private focusedBox As Panel = Nothing

    Public Sub New(Optional soalToEdit As SoalKuisionerModel = Nothing)
        InitializeComponent()
        targetSoal = soalToEdit
        isEditMode = (soalToEdit IsNot Nothing)
    End Sub

    Private Sub SoalModalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyRegions()
        PositionCloseButton()

        If isEditMode Then
            lblTitle.Text = "Edit Soal Kuisioner"
            lblSubtitle.Text = "Perbarui teks atau status butir pernyataan evaluasi"
            btnSimpan.Text = "Simpan Perubahan"

            If targetSoal.KategoriIndex >= 1 AndAlso targetSoal.KategoriIndex <= 4 Then
                cmbKategori.SelectedIndex = targetSoal.KategoriIndex - 1
            Else
                cmbKategori.SelectedIndex = 0
            End If

            txtNomor.Text = "Nomor " & targetSoal.Nomor.ToString() & " (Kategori " & SoalKuisionerRepository.GetKategoriShortName(targetSoal.KategoriIndex) & ")"
            txtTeks.Text = targetSoal.Teks
            cmbStatus.SelectedIndex = If(targetSoal.IsActive, 0, 1)
        Else
            lblTitle.Text = "Tambah Soal Kuisioner"
            lblSubtitle.Text = "Tambahkan butir pernyataan baru ke dalam instrumen EDOM"
            btnSimpan.Text = "Tambah Soal"

            cmbKategori.SelectedIndex = 0
            UpdateNomorDisplay()
            cmbStatus.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbKategori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKategori.SelectedIndexChanged
        If Not isEditMode Then
            UpdateNomorDisplay()
        ElseIf targetSoal IsNot Nothing Then
            Dim katIdx = cmbKategori.SelectedIndex + 1
            If katIdx <> targetSoal.KategoriIndex Then
                Dim nextNo = SoalKuisionerRepository.GetNextNomor(katIdx)
                txtNomor.Text = "Nomor " & nextNo.ToString() & " (Otomatis urutan baru pada kategori ini)"
            Else
                txtNomor.Text = "Nomor " & targetSoal.Nomor.ToString() & " (Kategori " & SoalKuisionerRepository.GetKategoriShortName(targetSoal.KategoriIndex) & ")"
            End If
        End If
    End Sub

    Private Sub UpdateNomorDisplay()
        Dim katIdx = cmbKategori.SelectedIndex + 1
        Dim nextNo = SoalKuisionerRepository.GetNextNomor(katIdx)
        txtNomor.Text = "Nomor " & nextNo.ToString() & " (Otomatis urutan ke-" & nextNo.ToString() & " pada kategori ini)"
    End Sub

    Private Sub ApplyRegions()
        Me.Region = New Region(GetRoundedPath(New Rectangle(0, 0, Me.Width, Me.Height), 12))
        btnBatal.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnBatal.Width, btnBatal.Height), 6))
        btnSimpan.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnSimpan.Width, btnSimpan.Height), 6))
        btnClose.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnClose.Width, btnClose.Height), 6))

        If pnlNomorBox IsNot Nothing Then
            pnlNomorBox.Region = New Region(GetRoundedPath(New Rectangle(0, 0, pnlNomorBox.Width, pnlNomorBox.Height), 6))
        End If
        If pnlTeksBox IsNot Nothing Then
            pnlTeksBox.Region = New Region(GetRoundedPath(New Rectangle(0, 0, pnlTeksBox.Width, pnlTeksBox.Height), 6))
        End If
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

    Private Sub SoalModalForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using penBdr As New Pen(Color.FromArgb(203, 213, 225), 1.0!)
            e.Graphics.DrawPath(penBdr, GetRoundedPath(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), 12))
        End Using
    End Sub

    Private Sub Input_Enter(sender As Object, e As EventArgs) Handles txtTeks.Enter
        Dim tb = CType(sender, TextBox)
        focusedBox = TryCast(tb.Parent, Panel)
        If focusedBox IsNot Nothing Then focusedBox.Invalidate()
    End Sub

    Private Sub Input_Leave(sender As Object, e As EventArgs) Handles txtTeks.Leave
        Dim prevBox = focusedBox
        focusedBox = Nothing
        If prevBox IsNot Nothing Then prevBox.Invalidate()
    End Sub

    Private Sub Box_Paint(sender As Object, e As PaintEventArgs) Handles pnlNomorBox.Paint, pnlTeksBox.Paint
        Dim box = CType(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim isFocus = (box Is focusedBox)
        Dim bdrColor = If(isFocus, colorNavy, colorBorder)
        Using path = GetRoundedPath(New Rectangle(0, 0, box.Width - 1, box.Height - 1), 6),
              pen As New Pen(bdrColor, If(isFocus, 1.5!, 1.0!))
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

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

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim katIndex = cmbKategori.SelectedIndex + 1
        Dim teksSoal = txtTeks.Text.Trim()
        Dim isActive = (cmbStatus.SelectedIndex = 0)

        If String.IsNullOrWhiteSpace(teksSoal) OrElse teksSoal.Length < 5 Then
            MessageBox.Show("Teks pernyataan soal wajib diisi dan minimal terdiri dari 5 karakter.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTeks.Focus()
            Return
        End If

        Dim err As String = ""
        If Not isEditMode Then
            Dim newSoal As New SoalKuisionerModel With {
                .KategoriIndex = katIndex,
                .KategoriJudul = SoalKuisionerRepository.GetKategoriTitle(katIndex),
                .Teks = teksSoal,
                .IsActive = isActive
            }

            If Not SoalKuisionerRepository.CreateSoal(newSoal, err) Then
                MessageBox.Show(err, "Gagal Menambahkan Soal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            MessageBox.Show("Butir soal kuisioner berhasil ditambahkan ke bank soal.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            targetSoal.KategoriIndex = katIndex
            targetSoal.KategoriJudul = SoalKuisionerRepository.GetKategoriTitle(katIndex)
            targetSoal.Teks = teksSoal
            targetSoal.IsActive = isActive

            If Not SoalKuisionerRepository.UpdateSoal(targetSoal, err) Then
                MessageBox.Show(err, "Gagal Memperbarui Soal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            MessageBox.Show("Perubahan butir soal kuisioner berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

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

