<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class KuisionerModalForm
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

    Friend WithEvents pnlSubHeader As System.Windows.Forms.Panel
    Friend WithEvents lblInstructionLeft As System.Windows.Forms.Label
    Friend WithEvents lblInstructionRight As System.Windows.Forms.Label

    Friend WithEvents pnlScrollQuestions As System.Windows.Forms.Panel

    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents lblFooterCounter As System.Windows.Forms.Label
    Friend WithEvents lblFooterHint As System.Windows.Forms.Label
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnKirim As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlMainCard = New Panel()
        pnlScrollQuestions = New Panel()
        pnlFooter = New Panel()
        btnKirim = New Button()
        btnBatal = New Button()
        lblFooterHint = New Label()
        lblFooterCounter = New Label()
        pnlSubHeader = New Panel()
        lblInstructionRight = New Label()
        lblInstructionLeft = New Label()
        pnlHeader = New Panel()
        btnClose = New Button()
        lblSubtitle = New Label()
        lblTitle = New Label()
        pnlMainCard.SuspendLayout()
        pnlFooter.SuspendLayout()
        pnlSubHeader.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMainCard
        ' 
        pnlMainCard.BackColor = Color.White
        pnlMainCard.Controls.Add(pnlScrollQuestions)
        pnlMainCard.Controls.Add(pnlFooter)
        pnlMainCard.Controls.Add(pnlSubHeader)
        pnlMainCard.Controls.Add(pnlHeader)
        pnlMainCard.Dock = DockStyle.Fill
        pnlMainCard.Location = New Point(0, 0)
        pnlMainCard.Name = "pnlMainCard"
        pnlMainCard.Size = New Size(1220, 800)
        pnlMainCard.TabIndex = 0
        ' 
        ' pnlScrollQuestions
        ' 
        pnlScrollQuestions.AutoScroll = True
        pnlScrollQuestions.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlScrollQuestions.Dock = DockStyle.Fill
        pnlScrollQuestions.Location = New Point(0, 108)
        pnlScrollQuestions.Name = "pnlScrollQuestions"
        pnlScrollQuestions.Padding = New Padding(24, 16, 24, 16)
        pnlScrollQuestions.Size = New Size(1220, 624)
        pnlScrollQuestions.TabIndex = 2
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.White
        pnlFooter.Controls.Add(btnKirim)
        pnlFooter.Controls.Add(btnBatal)
        pnlFooter.Controls.Add(lblFooterHint)
        pnlFooter.Controls.Add(lblFooterCounter)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 732)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New Padding(24, 14, 24, 14)
        pnlFooter.Size = New Size(1220, 68)
        pnlFooter.TabIndex = 3
        ' 
        ' btnKirim
        ' 
        btnKirim.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnKirim.BackColor = Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnKirim.Cursor = Cursors.Hand
        btnKirim.FlatAppearance.BorderSize = 0
        btnKirim.FlatStyle = FlatStyle.Flat
        btnKirim.Font = New Font("Segoe UI Semibold", 9.25F, FontStyle.Bold)
        btnKirim.ForeColor = Color.White
        btnKirim.Location = New Point(1044, 15)
        btnKirim.Name = "btnKirim"
        btnKirim.Size = New Size(152, 38)
        btnKirim.TabIndex = 3
        btnKirim.Text = "Kirim Kuisioner"
        btnKirim.UseVisualStyleBackColor = False
        ' 
        ' btnBatal
        ' 
        btnBatal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBatal.BackColor = Color.White
        btnBatal.Cursor = Cursors.Hand
        btnBatal.FlatAppearance.BorderColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnBatal.FlatStyle = FlatStyle.Flat
        btnBatal.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        btnBatal.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
        btnBatal.Location = New Point(944, 15)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(90, 38)
        btnBatal.TabIndex = 2
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = False
        ' 
        ' lblFooterHint
        ' 
        lblFooterHint.AutoSize = True
        lblFooterHint.Font = New Font("Segoe UI", 8.25F)
        lblFooterHint.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblFooterHint.Location = New Point(24, 38)
        lblFooterHint.Name = "lblFooterHint"
        lblFooterHint.Size = New Size(301, 19)
        lblFooterHint.TabIndex = 1
        lblFooterHint.Text = "Pastikan seluruh pernyataan sudah terisi sebelum mengirim."
        ' 
        ' lblFooterCounter
        ' 
        lblFooterCounter.AutoSize = True
        lblFooterCounter.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        lblFooterCounter.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblFooterCounter.Location = New Point(24, 15)
        lblFooterCounter.Name = "lblFooterCounter"
        lblFooterCounter.Size = New Size(189, 21)
        lblFooterCounter.TabIndex = 0
        lblFooterCounter.Text = "27 Pernyataan Wajib Diisi"
        ' 
        ' pnlSubHeader
        ' 
        pnlSubHeader.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlSubHeader.Controls.Add(lblInstructionRight)
        pnlSubHeader.Controls.Add(lblInstructionLeft)
        pnlSubHeader.Dock = DockStyle.Top
        pnlSubHeader.Location = New Point(0, 74)
        pnlSubHeader.Name = "pnlSubHeader"
        pnlSubHeader.Padding = New Padding(24, 8, 24, 8)
        pnlSubHeader.Size = New Size(1220, 34)
        pnlSubHeader.TabIndex = 1
        ' 
        ' lblInstructionRight
        ' 
        lblInstructionRight.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblInstructionRight.Font = New Font("Segoe UI", 8.25F)
        lblInstructionRight.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblInstructionRight.Location = New Point(920, 8)
        lblInstructionRight.Name = "lblInstructionRight"
        lblInstructionRight.Size = New Size(276, 18)
        lblInstructionRight.TabIndex = 1
        lblInstructionRight.Text = "Pilih satu jawaban pada setiap baris"
        lblInstructionRight.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblInstructionLeft
        ' 
        lblInstructionLeft.AutoSize = True
        lblInstructionLeft.Font = New Font("Segoe UI", 8.25F)
        lblInstructionLeft.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblInstructionLeft.Location = New Point(24, 8)
        lblInstructionLeft.Name = "lblInstructionLeft"
        lblInstructionLeft.Size = New Size(280, 19)
        lblInstructionLeft.TabIndex = 0
        lblInstructionLeft.Text = "Berikan penilaian Anda untuk setiap pernyataan berikut."
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(btnClose)
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(24, 14, 24, 12)
        pnlHeader.Size = New Size(1220, 74)
        pnlHeader.TabIndex = 0
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.BackColor = Color.White
        btnClose.Cursor = Cursors.Hand
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        btnClose.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        btnClose.Location = New Point(1166, 16)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(36, 36)
        btnClose.TabIndex = 2
        btnClose.Text = "✕"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI Semibold", 8.5F, FontStyle.Bold)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblSubtitle.Location = New Point(24, 42)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(400, 19)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "TIK309 - Grafika Komputer (3C) • Dosen: ANGGI MARDIYONO"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblTitle.Location = New Point(22, 14)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(380, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Kuisioner Evaluasi Dosen (EDOM)"
        ' 
        ' KuisionerModalForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1220, 800)
        Controls.Add(pnlMainCard)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.None
        Name = "KuisionerModalForm"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Kuisioner Evaluasi Dosen"
        pnlMainCard.ResumeLayout(False)
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        pnlSubHeader.ResumeLayout(False)
        pnlSubHeader.PerformLayout()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub

End Class
