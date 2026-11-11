Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class LoginForm

    Private ReadOnly colorNavy As Color = Color.FromArgb(10, 37, 88)
    Private ReadOnly colorNavyHover As Color = Color.FromArgb(14, 48, 112)
    Private ReadOnly colorMuted As Color = Color.FromArgb(148, 163, 184)
    Private ReadOnly colorBorder As Color = Color.FromArgb(226, 232, 240)

    Private emailFocused As Boolean = False
    Private passwordFocused As Boolean = False

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyCardRegion()
        ApplyInputRegions()
        CenterCard()
    End Sub

    Private Sub LoginForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CenterCard()
        Me.Invalidate()
    End Sub

    Private Sub CenterCard()
        If pnlCard Is Nothing Then Return
        pnlCard.Left = (Me.ClientSize.Width - pnlCard.Width) \ 2
        pnlCard.Top = Math.Max(20, (Me.ClientSize.Height - pnlCard.Height) \ 2)
    End Sub

    Private Sub ApplyCardRegion()
        pnlCard.Region = New Region(GetRoundedPath(New Rectangle(0, 0, pnlCard.Width, pnlCard.Height), 14))
        btnLogin.Region = New Region(GetRoundedPath(New Rectangle(0, 0, btnLogin.Width, btnLogin.Height), 8))
    End Sub

    Private Sub ApplyInputRegions()
        pnlEmailInput.Region = New Region(GetRoundedPath(New Rectangle(0, 0, pnlEmailInput.Width, pnlEmailInput.Height), 8))
        pnlPasswordInput.Region = New Region(GetRoundedPath(New Rectangle(0, 0, pnlPasswordInput.Width, pnlPasswordInput.Height), 8))
    End Sub

    ' Soft ambient shadow under floating card
    Private Sub LoginForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If pnlCard Is Nothing Then Return
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim shadowRect As New Rectangle(pnlCard.Left - 4, pnlCard.Top - 2, pnlCard.Width + 8, pnlCard.Height + 10)
        Using shadowPath As GraphicsPath = GetRoundedPath(shadowRect, 18),
              shadowBrush As New SolidBrush(Color.FromArgb(16, 0, 0, 0))
            e.Graphics.FillPath(shadowBrush, shadowPath)
        End Using
    End Sub

    Private Sub pnlCard_Paint(sender As Object, e As PaintEventArgs) Handles pnlCard.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlCard.Width - 1, pnlCard.Height - 1)
        Using path As GraphicsPath = GetRoundedPath(rect, 14), penBdr As New Pen(colorBorder, 1.0!)
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    Private Sub pnlEmailInput_Paint(sender As Object, e As PaintEventArgs) Handles pnlEmailInput.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlEmailInput.Width - 1, pnlEmailInput.Height - 1)
        Dim bdrColor As Color = If(emailFocused, colorNavy, colorBorder)
        Using path As GraphicsPath = GetRoundedPath(rect, 8), penBdr As New Pen(bdrColor, If(emailFocused, 1.5!, 1.0!))
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    Private Sub pnlPasswordInput_Paint(sender As Object, e As PaintEventArgs) Handles pnlPasswordInput.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, pnlPasswordInput.Width - 1, pnlPasswordInput.Height - 1)
        Dim bdrColor As Color = If(passwordFocused, colorNavy, colorBorder)
        Using path As GraphicsPath = GetRoundedPath(rect, 8), penBdr As New Pen(bdrColor, If(passwordFocused, 1.5!, 1.0!))
            e.Graphics.DrawPath(penBdr, path)
        End Using
    End Sub

    ' Outline envelope vector
    Private Sub picMailIcon_Paint(sender As Object, e As PaintEventArgs) Handles picMailIcon.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim c As Color = If(emailFocused, colorNavy, colorMuted)
        Using pen As New Pen(c, 1.4!)
            Dim r As New Rectangle(1, 3, 17, 13)
            Using path As GraphicsPath = GetRoundedPath(r, 2)
                e.Graphics.DrawPath(pen, path)
            End Using
            e.Graphics.DrawLine(pen, 2, 4, 9, 10)
            e.Graphics.DrawLine(pen, 17, 4, 10, 10)
        End Using
    End Sub

    ' Outline padlock vector
    Private Sub picLockIcon_Paint(sender As Object, e As PaintEventArgs) Handles picLockIcon.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim c As Color = If(passwordFocused, colorNavy, colorMuted)
        Using pen As New Pen(c, 1.4!)
            e.Graphics.DrawArc(pen, 5, 2, 9, 8, 180, 180)
            e.Graphics.DrawLine(pen, 5, 6, 5, 8)
            e.Graphics.DrawLine(pen, 14, 6, 14, 8)
            Dim r As New Rectangle(3, 8, 13, 10)
            Using path As GraphicsPath = GetRoundedPath(r, 2)
                e.Graphics.DrawPath(pen, path)
            End Using
            Using br As New SolidBrush(c)
                e.Graphics.FillEllipse(br, 8.5!, 11.5!, 2.0!, 2.0!)
            End Using
        End Using
    End Sub

    ' Toggle eye vector with slash when password is masked
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

    Private Sub picTogglePassword_Click(sender As Object, e As EventArgs) Handles picTogglePassword.Click
        txtPassword.UseSystemPasswordChar = Not txtPassword.UseSystemPasswordChar
        picTogglePassword.Invalidate()
    End Sub

    Private Sub txtEmail_Enter(sender As Object, e As EventArgs) Handles txtEmail.Enter
        emailFocused = True
        pnlEmailInput.Invalidate()
        picMailIcon.Invalidate()
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        emailFocused = False
        pnlEmailInput.Invalidate()
        picMailIcon.Invalidate()
    End Sub

    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        passwordFocused = True
        pnlPasswordInput.Invalidate()
        picLockIcon.Invalidate()
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        passwordFocused = False
        pnlPasswordInput.Invalidate()
        picLockIcon.Invalidate()
    End Sub

    Private Sub FocusEmail(sender As Object, e As EventArgs) Handles pnlEmailInput.Click, picMailIcon.Click
        txtEmail.Focus()
    End Sub

    Private Sub FocusPassword(sender As Object, e As EventArgs) Handles pnlPasswordInput.Click, picLockIcon.Click
        txtPassword.Focus()
    End Sub

    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = colorNavyHover
    End Sub

    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = colorNavy
    End Sub

    Private Sub Inputs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dashboard As New Form1()
        dashboard.Show()
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
