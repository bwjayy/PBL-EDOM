# PBL-EDOM (Evaluasi Dosen Oleh Mahasiswa)

Aplikasi Desktop berbasis **Visual Basic .NET (.NET 8 Windows Forms)** untuk pengisian kuesioner **Evaluasi Dosen Oleh Mahasiswa (EDOM)** di lingkungan **Politeknik Negeri Jakarta (PNJ)**.

---

## 🎨 Tampilan & Fitur Antarmuka (UI)

* **Dual-Tone Login Page (`LoginForm`)**:
  * Tampilan *split-screen* modern dengan panel kiri *Midnight Slate* (`#0F172A`) dan panel kanan putih bersih.
  * Form login responsif dengan kolom NIM/Username dan Kata Sandi.
  * Dukungan transisi langsung ke dashboard tanpa backend rumit (*pure UI*).

* **Modern EDOM Dashboard (`Form1`)**:
  * **Sidebar Navigasi Kiri (`#0F172A`)**: Logo monogram modern bergradien, menu navigasi aktif, profil mahasiswa, dan tombol logout.
  * **Top Bar Navigasi**: Breadcrumb status semester, live search filter pencarian mata kuliah/dosen, serta selector Tahun Akademik.
  * **3 Kartu Ringkasan Metrik (KPI Widgets)**:
    1. *Total Mata Kuliah*: Jumlah mata kuliah aktif semester berjalan (Kelas 3C).
    2. *Progress Pengisian EDOM*: Menghitung persentase kuesioner yang telah diisi lengkap dengan *dynamic progress bar*.
    3. *Batas Pengisian*: Informasi tenggat waktu pengisian kuesioner.
  * **Tabel Kuesioner Interaktif**:
    * Menggunakan *pill badge* warna lembut (*Belum Terisi* merah muda & *Sudah Terisi* hijau muda).
    * Tombol aksi *"✎ Isi Kuisioner"* untuk membuka formulir modal evaluasi dosen.

---

## 💻 Kebutuhan Sistem & Teknologi

* **Framework**: .NET 8.0 Windows (`net8.0-windows`)
* **IDE**: Visual Studio 2022 (Community / Professional / Enterprise)
* **Bahasa**: Visual Basic .NET (VB.NET)
* **UI Framework**: Windows Forms (WinForms)

---

## 🚀 Cara Menjalankan Proyek

1. Clone repositori ini:
   ```bash
   git clone https://github.com/bwjayy/PBL-EDOM.git
   ```
2. Buka berkas solusi `PBL.sln` di **Visual Studio 2022**.
3. Pastikan target framework adalah `.NET 8.0-windows`.
4. Tekan **F5** atau klik tombol **Start** untuk menjalankan aplikasi.
