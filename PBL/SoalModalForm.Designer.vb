<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SoalModalForm
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
    Friend WithEvents lblKategori As System.Windows.Forms.Label
    Friend WithEvents cmbKategori As System.Windows.Forms.ComboBox

    Friend WithEvents lblNomor As System.Windows.Forms.Label
    Friend WithEvents pnlNomorBox As System.Windows.Forms.Panel
    Friend WithEvents txtNomor As System.Windows.Forms.TextBox

    Friend WithEvents lblTeks As System.Windows.Forms.Label
    Friend WithEvents pnlTeksBox As System.Windows.Forms.Panel
    Friend WithEvents txtTeks As System.Windows.Forms.TextBox

    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlMainCard = New System.Windows.Forms.Panel()
        pnlBody = New System.Windows.Forms.Panel()
        cmbStatus = New System.Windows.Forms.ComboBox()
        lblStatus = New System.Windows.Forms.Label()
        pnlTeksBox = New System.Windows.Forms.Panel()
        txtTeks = New System.Windows.Forms.TextBox()
        lblTeks = New System.Windows.Forms.Label()
        pnlNomorBox = New System.Windows.Forms.Panel()
        txtNomor = New System.Windows.Forms.TextBox()
        lblNomor = New System.Windows.Forms.Label()
        cmbKategori = New System.Windows.Forms.ComboBox()
        lblKategori = New System.Windows.Forms.Label()
        pnlFooter = New System.Windows.Forms.Panel()
        btnBatal = New System.Windows.Forms.Button()
        btnSimpan = New System.Windows.Forms.Button()
        pnlHeader = New System.Windows.Forms.Panel()
        btnClose = New System.Windows.Forms.Button()
        lblSubtitle = New System.Windows.Forms.Label()
        lblTitle = New System.Windows.Forms.Label()
        pnlMainCard.SuspendLayout()
        pnlBody.SuspendLayout()
        pnlTeksBox.SuspendLayout()
        pnlNomorBox.SuspendLayout()
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
        pnlMainCard.Size = New System.Drawing.Size(620, 510)
        pnlMainCard.TabIndex = 0
        '
        ' pnlBody
        '
        pnlBody.AutoScroll = True
        pnlBody.Controls.Add(cmbStatus)
        pnlBody.Controls.Add(lblStatus)
        pnlBody.Controls.Add(pnlTeksBox)
        pnlBody.Controls.Add(lblTeks)
        pnlBody.Controls.Add(pnlNomorBox)
        pnlBody.Controls.Add(lblNomor)
        pnlBody.Controls.Add(cmbKategori)
        pnlBody.Controls.Add(lblKategori)
        pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        pnlBody.Location = New System.Drawing.Point(0, 74)
        pnlBody.Name = "pnlBody"
        pnlBody.Padding = New System.Windows.Forms.Padding(28, 16, 28, 16)
        pnlBody.Size = New System.Drawing.Size(620, 368)
        pnlBody.TabIndex = 1
        '
        ' cmbStatus
        '
        cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmbStatus.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        cmbStatus.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        cmbStatus.FormattingEnabled = True
        cmbStatus.Items.AddRange(New Object() {"Aktif (Ditampilkan dalam kuisioner)", "Nonaktif (Disembunyikan)"})
        cmbStatus.Location = New System.Drawing.Point(28, 312)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New System.Drawing.Size(564, 28)
        cmbStatus.TabIndex = 4
        '
        ' lblStatus
        '
        lblStatus.AutoSize = True
        lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblStatus.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblStatus.Location = New System.Drawing.Point(28, 292)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New System.Drawing.Size(79, 13)
        lblStatus.TabIndex = 6
        lblStatus.Text = "STATUS SOAL"
        '
        ' pnlTeksBox
        '
        pnlTeksBox.BackColor = System.Drawing.Color.White
        pnlTeksBox.Controls.Add(txtTeks)
        pnlTeksBox.Location = New System.Drawing.Point(28, 168)
        pnlTeksBox.Name = "pnlTeksBox"
        pnlTeksBox.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        pnlTeksBox.Size = New System.Drawing.Size(564, 106)
        pnlTeksBox.TabIndex = 3
        '
        ' txtTeks
        '
        txtTeks.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtTeks.Dock = System.Windows.Forms.DockStyle.Fill
        txtTeks.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        txtTeks.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        txtTeks.Location = New System.Drawing.Point(10, 8)
        txtTeks.Multiline = True
        txtTeks.Name = "txtTeks"
        txtTeks.PlaceholderText = "Tuliskan kalimat pernyataan evaluasi dosen di sini..."
        txtTeks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        txtTeks.Size = New System.Drawing.Size(544, 90)
        txtTeks.TabIndex = 0
        '
        ' lblTeks
        '
        lblTeks.AutoSize = True
        lblTeks.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblTeks.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblTeks.Location = New System.Drawing.Point(28, 148)
        lblTeks.Name = "lblTeks"
        lblTeks.Size = New System.Drawing.Size(211, 13)
        lblTeks.TabIndex = 4
        lblTeks.Text = "PERNYATAAN / TEKS SOAL KUISIONER"
        '
        ' pnlNomorBox
        '
        pnlNomorBox.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlNomorBox.Controls.Add(txtNomor)
        pnlNomorBox.Location = New System.Drawing.Point(28, 96)
        pnlNomorBox.Name = "pnlNomorBox"
        pnlNomorBox.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        pnlNomorBox.Size = New System.Drawing.Size(564, 38)
        pnlNomorBox.TabIndex = 2
        '
        ' txtNomor
        '
        txtNomor.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtNomor.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtNomor.Dock = System.Windows.Forms.DockStyle.Fill
        txtNomor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0F, System.Drawing.FontStyle.Bold)
        txtNomor.ForeColor = System.Drawing.Color.FromArgb(CByte(71), CByte(85), CByte(105))
        txtNomor.Location = New System.Drawing.Point(10, 8)
        txtNomor.Name = "txtNomor"
        txtNomor.ReadOnly = True
        txtNomor.Size = New System.Drawing.Size(544, 16)
        txtNomor.TabIndex = 0
        txtNomor.TabStop = False
        '
        ' lblNomor
        '
        lblNomor.AutoSize = True
        lblNomor.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblNomor.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblNomor.Location = New System.Drawing.Point(28, 76)
        lblNomor.Name = "lblNomor"
        lblNomor.Size = New System.Drawing.Size(275, 13)
        lblNomor.TabIndex = 2
        lblNomor.Text = "NOMOR URUT SOAL (OTOMATIS BERDASARKAN KATEGORI)"
        '
        ' cmbKategori
        '
        cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cmbKategori.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        cmbKategori.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        cmbKategori.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        cmbKategori.FormattingEnabled = True
        cmbKategori.Items.AddRange(New Object() {"1. Kompetensi Pedagogik", "2. Kompetensi Profesional", "3. Kompetensi Kepribadian", "4. Kompetensi Sosial"})
        cmbKategori.Location = New System.Drawing.Point(28, 34)
        cmbKategori.Name = "cmbKategori"
        cmbKategori.Size = New System.Drawing.Size(564, 28)
        cmbKategori.TabIndex = 1
        '
        ' lblKategori
        '
        lblKategori.AutoSize = True
        lblKategori.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0F, System.Drawing.FontStyle.Bold)
        lblKategori.ForeColor = System.Drawing.Color.FromArgb(CByte(100), CByte(116), CByte(139))
        lblKategori.Location = New System.Drawing.Point(28, 14)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New System.Drawing.Size(135, 13)
        lblKategori.TabIndex = 0
        lblKategori.Text = "KATEGORI KOMPETENSI"
        '
        ' pnlFooter
        '
        pnlFooter.BackColor = System.Drawing.Color.FromArgb(CByte(248), CByte(250), CByte(252))
        pnlFooter.Controls.Add(btnBatal)
        pnlFooter.Controls.Add(btnSimpan)
        pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        pnlFooter.Location = New System.Drawing.Point(0, 442)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New System.Windows.Forms.Padding(28, 14, 28, 14)
        pnlFooter.Size = New System.Drawing.Size(620, 68)
        pnlFooter.TabIndex = 2
        '
        ' btnBatal
        '
        btnBatal.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        btnBatal.BackColor = System.Drawing.Color.White
        btnBatal.Cursor = System.Windows.Forms.Cursors.Hand
        btnBatal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CByte(226), CByte(232), CByte(240))
        btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnBatal.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold)
        btnBatal.ForeColor = System.Drawing.Color.FromArgb(CByte(51), CByte(65), CByte(85))
        btnBatal.Location = New System.Drawing.Point(384, 15)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New System.Drawing.Size(88, 36)
        btnBatal.TabIndex = 1
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = False
        '
        ' btnSimpan
        '
        btnSimpan.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right
        btnSimpan.BackColor = System.Drawing.Color.FromArgb(CByte(10), CByte(37), CByte(88))
        btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        btnSimpan.FlatAppearance.BorderSize = 0
        btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btnSimpan.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold)
        btnSimpan.ForeColor = System.Drawing.Color.White
        btnSimpan.Location = New System.Drawing.Point(482, 15)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New System.Drawing.Size(110, 36)
        btnSimpan.TabIndex = 0
        btnSimpan.Text = "Simpan Soal"
        btnSimpan.UseVisualStyleBackColor = False
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
        pnlHeader.Padding = New System.Windows.Forms.Padding(28, 14, 28, 12)
        pnlHeader.Size = New System.Drawing.Size(620, 74)
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
        btnClose.Location = New System.Drawing.Point(566, 16)
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
        lblSubtitle.Text = "Lengkapi butir pernyataan instrumen evaluasi dosen"
        '
        ' lblTitle
        '
        lblTitle.AutoSize = True
        lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold)
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(CByte(15), CByte(23), CByte(42))
        lblTitle.Location = New System.Drawing.Point(26, 16)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New System.Drawing.Size(189, 21)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Tambah Soal Kuisioner"
        '
        ' SoalModalForm
        '
        AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        BackColor = System.Drawing.Color.White
        ClientSize = New System.Drawing.Size(620, 510)
        Controls.Add(pnlMainCard)
        Font = New System.Drawing.Font("Segoe UI", 9.0F)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Name = "SoalModalForm"
        ShowInTaskbar = False
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "Kelola Soal Kuisioner"
        pnlMainCard.ResumeLayout(False)
        pnlBody.ResumeLayout(False)
        pnlBody.PerformLayout()
        pnlTeksBox.ResumeLayout(False)
        pnlTeksBox.PerformLayout()
        pnlNomorBox.ResumeLayout(False)
        pnlNomorBox.PerformLayout()
        pnlFooter.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub

End Class

