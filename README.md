# PBL-EDOM (Evaluasi Dosen Oleh Mahasiswa)

Aplikasi Desktop berbasis **Visual Basic .NET (.NET 8 Windows Forms)** untuk pengisian kuesioner **Evaluasi Dosen Oleh Mahasiswa (EDOM)** di lingkungan **Politeknik Negeri Jakarta (PNJ)**.

---

##  Kebutuhan Sistem & Teknologi

* **Framework**: .NET 8.0 Windows (`net8.0-windows`)
* **IDE**: Visual Studio 2022 (Community / Professional / Enterprise)
* **Bahasa**: Visual Basic .NET (VB.NET)
* **UI Framework**: Windows Forms (WinForms)

---

##  Cara Menjalankan Proyek

### 1. Setup Database (XAMPP / MySQL)
1. Buka **XAMPP Control Panel** dan jalankan modul **MySQL** (dan Apache jika memakai phpMyAdmin).
2. Buka **phpMyAdmin** di browser (`http://localhost/phpmyadmin`).
3. Pilih menu **Import**, lalu pilih berkas `config.sql` yang ada di direktori utama repositori ini.
4. Klik tombol **Import** di bagian bawah. Database `edom_pbl` dan seluruh tabel serta data testing akan otomatis terbuat.

> Catatan: Secara default aplikasi diarahkan ke port MySQL lokal. Jika port MySQL Anda diubah (misalnya 3307), pengaturan port dapat disesuaikan pada berkas `PBL/ModKoneksi.vb`.

### 2. Menjalankan Aplikasi
1. Buka berkas solusi `PBL.sln` di **Visual Studio 2022**.
2. Pastikan target framework adalah `.NET 8.0-windows`.
3. Tekan **F5** atau klik tombol **Start** untuk menjalankan aplikasi.

### 3. Akun Pengujian (Testing Accounts)
| Peran (Role) | Email / Username | Kata Sandi | Halaman |
| :--- | :--- | :--- | :--- |
| **Admin Prodi** | `admin.ti@pnj.ac.id` | `admin123` | Dashboard Admin Prodi |
| **Dosen** | `bambang.warsuta@pnj.ac.id` | `dosen123` | Dashboard Dosen |
| **Mahasiswa** | `rahmat.ti@pnj.ac.id` | `mhs123` | Dashboard Mahasiswa |

