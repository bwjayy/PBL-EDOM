Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class LoginForm

    ' Warna Palette dari Referensi Gambar
    Private ReadOnly primaryBlue As Color = Color.FromArgb(30, 58, 138)     ' #1E3A8A
    Private ReadOnly secondaryDark As Color = Color.FromArgb(15, 23, 42)    ' #0F172A
    Private ReadOnly tertiaryCyan As Color = Color.FromArgb(2, 132, 199)    ' #0284C7
    Private ReadOnly neutralSlate As Color = Color.FromArgb(100, 116, 139)  ' #64748B
    Private ReadOnly lightBorder As Color = Color.FromArgb(226, 232, 240)   ' #E2E8F0

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 0
    End Sub

    ' Gambar Logo Monogram Modern (E + Gradien Cyan-Blue di Panel Kiri)
    Private Sub picBrandLogo_Paint(sender As Object, e As PaintEventArgs) Handles picBrandLogo.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As New Rectangle(2, 2, picBrandLogo.Width - 5, picBrandLogo.Height - 5)
        Using path As GraphicsPath = GetRoundedPath(rect, 14)
            Using br As New LinearGradientBrush(rect, primaryBlue, tertiaryCyan, 45.0!)
                e.Graphics.FillPath(br, path)
            End Using
        End Using

        Using fontLogo As New Font("Segoe UI", 20.0!, FontStyle.Bold)
            Using brWhite As New SolidBrush(Color.White)
                Dim sf As New StringFormat With {
                    .Alignment = StringAlignment.Center,
                    .LineAlignment = StringAlignment.Center
                }
                e.Graphics.DrawString("E", fontLogo, brWhite, rect, sf)
            End Using
        End Using
    End Sub

    ' Card Hint Rounded Paint
    Private Sub pnlHint_Paint(sender As Object, e As PaintEventArgs) Handles pnlHint.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlHint.Width - 1, pnlHint.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 8)
            Using br As New SolidBrush(Color.FromArgb(241, 245, 249))
                e.Graphics.FillPath(br, path)
            End Using
            Using penBdr As New Pen(lightBorder, 1.0!)
                e.Graphics.DrawPath(penBdr, path)
            End Using
        End Using
    End Sub

    ' Badge Semester Rounded Paint di Panel Kiri
    Private Sub lblBadgeSemester_Paint(sender As Object, e As PaintEventArgs) Handles lblBadgeSemester.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, lblBadgeSemester.Width - 1, lblBadgeSemester.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 6)
            Using br As New SolidBrush(Color.FromArgb(30, 41, 59))
                e.Graphics.FillPath(br, path)
            End Using
            Using penBdr As New Pen(Color.FromArgb(51, 65, 85), 1.0!)
                e.Graphics.DrawPath(penBdr, path)
            End Using
        End Using

        Using fontBadge As New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
            Using brText As New SolidBrush(Color.FromArgb(226, 232, 240))
                Dim sf As New StringFormat With {
                    .Alignment = StringAlignment.Center,
                    .LineAlignment = StringAlignment.Center
                }
                e.Graphics.DrawString(lblBadgeSemester.Text, fontBadge, brText, rect, sf)
            End Using
        End Using
    End Sub

    ' Focus Highlight untuk Input Username
    Private Sub txtUsername_Enter(sender As Object, e As EventArgs) Handles txtUsername.Enter
        pnlUsernameUnderline.BackColor = tertiaryCyan
    End Sub

    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        pnlUsernameUnderline.BackColor = Color.FromArgb(203, 213, 225)
    End Sub

    ' Focus Highlight untuk Input Password
    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        pnlPasswordUnderline.BackColor = tertiaryCyan
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        pnlPasswordUnderline.BackColor = Color.FromArgb(203, 213, 225)
    End Sub

    ' Hover effect tombol Login
    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = tertiaryCyan
    End Sub

    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = primaryBlue
    End Sub

    ' Enter key shortcut
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown, txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnLogin.PerformClick()
        End If
    End Sub

    ' Proses Login (PURE UI: Tanpa validasi/backend, langsung masuk ke Dashboard!)
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Langsung buka Form Dashboard (Form1)
        Dim dashboard As New Form1()
        dashboard.Show()

        ' Sembunyikan form login
        Me.Hide()
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

