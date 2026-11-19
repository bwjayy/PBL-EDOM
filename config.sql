-- Skrip Setup Database EDOM (PBL)
-- Kompatibel dengan MySQL / MariaDB (XAMPP phpMyAdmin)

CREATE DATABASE IF NOT EXISTS edom_pbl;
USE edom_pbl;

-- 1. Hapus tabel lama jika ada (urutan disesuaikan relasi foreign key)
DROP TABLE IF EXISTS edom_answers;
DROP TABLE IF EXISTS course_offerings;
DROP TABLE IF EXISTS edom_questions;
DROP TABLE IF EXISTS mahasiswa_profiles;
DROP TABLE IF EXISTS dosen_profiles;
DROP TABLE IF EXISTS edom_settings;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS study_programs;

-- 2. Tabel Program Studi
CREATE TABLE study_programs (
    id INT PRIMARY KEY,
    code VARCHAR(10) NOT NULL UNIQUE,
    name VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 3. Tabel Pengguna (Akun Login)
CREATE TABLE users (
    id BIGINT PRIMARY KEY,
    study_program_id INT NULL,
    name VARCHAR(150) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role VARCHAR(20) NOT NULL, -- 'admin', 'dosen', 'mahasiswa'
    is_deleted TINYINT(1) NOT NULL DEFAULT 0,
    CONSTRAINT fk_users_study_programs FOREIGN KEY (study_program_id) REFERENCES study_programs(id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 4. Tabel Profil Dosen
CREATE TABLE dosen_profiles (
    user_id BIGINT PRIMARY KEY,
    nidn VARCHAR(20) NOT NULL,
    gelar_depan VARCHAR(20) DEFAULT NULL,
    gelar_belakang VARCHAR(50) DEFAULT NULL,
    CONSTRAINT fk_dosen_profiles_user FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 5. Tabel Profil Mahasiswa
CREATE TABLE mahasiswa_profiles (
    user_id BIGINT PRIMARY KEY,
    nim VARCHAR(20) NOT NULL,
    angkatan INT NOT NULL,
    CONSTRAINT fk_mahasiswa_profiles_user FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE edom_settings (
    study_program_id INT PRIMARY KEY,
    is_locked TINYINT(1) NOT NULL DEFAULT 0,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT fk_edom_settings_program FOREIGN KEY (study_program_id) REFERENCES study_programs(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 5b. Tabel Soal Kuisioner EDOM Dinamis
CREATE TABLE IF NOT EXISTS edom_questions (
    id BIGINT PRIMARY KEY,
    nomor INT NOT NULL,
    kategori_index INT NOT NULL,
    kategori_judul VARCHAR(100) NOT NULL,
    teks TEXT NOT NULL,
    is_active TINYINT(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 5c. Tabel Mata Kuliah & Dosen Pengampu
CREATE TABLE IF NOT EXISTS course_offerings (
    id INT PRIMARY KEY,
    study_program_id INT NOT NULL,
    dosen_id BIGINT NOT NULL,
    kode_mk VARCHAR(20) NOT NULL,
    nama_mk VARCHAR(150) NOT NULL,
    kelas VARCHAR(20) NOT NULL,
    sks INT NOT NULL DEFAULT 3,
    semester VARCHAR(30) NOT NULL DEFAULT '2026/2027 Ganjil',
    CONSTRAINT fk_offerings_program FOREIGN KEY (study_program_id) REFERENCES study_programs(id) ON DELETE CASCADE,
    CONSTRAINT fk_offerings_dosen FOREIGN KEY (dosen_id) REFERENCES users(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 5d. Tabel Jawaban Evaluasi EDOM Mahasiswa
CREATE TABLE IF NOT EXISTS edom_answers (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    mahasiswa_id BIGINT NOT NULL,
    offering_id INT NOT NULL,
    question_id BIGINT NOT NULL,
    kategori_index INT NOT NULL,
    nilai TINYINT NOT NULL,
    submitted_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_mhs_offering_question (mahasiswa_id, offering_id, question_id),
    CONSTRAINT fk_answers_mahasiswa FOREIGN KEY (mahasiswa_id) REFERENCES users(id) ON DELETE CASCADE,
    CONSTRAINT fk_answers_offering FOREIGN KEY (offering_id) REFERENCES course_offerings(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 6. Data Master Program Studi
INSERT INTO study_programs (id, code, name) VALUES
(1, 'TI',  'Teknik Informatika'),
(2, 'TMJ', 'Teknik Multimedia dan Jaringan'),
(3, 'TMD', 'Teknik Multimedia Digital'),
(4, 'RKS', 'Rekayasa Keamanan Siber');

-- 7. Data Akun Pengujian (Testing Accounts)
-- Admin:        admin@pnj.ac.id            | Kata Sandi: admin123
-- Dosen TI:      bambang.warsuta@pnj.ac.id  | Kata Sandi: dosen123
-- Mahasiswa TI:  rahmat.ti@pnj.ac.id        | Kata Sandi: mhs123
-- Dosen TMJ:     anita.hidayati@pnj.ac.id   | Kata Sandi: dosen123
-- Mahasiswa TMJ: ahmad.fauzi@pnj.ac.id      | Kata Sandi: mhs123

INSERT INTO users (id, study_program_id, name, email, password_hash, role) VALUES
(1, NULL, 'Admin', 'admin@pnj.ac.id', 'admin123', 'admin'),
(2, 1, 'Bambang Warsuta', 'bambang.warsuta@pnj.ac.id', 'dosen123', 'dosen'),
(3, 1, 'Muhammad Rahmat', 'rahmat.ti@pnj.ac.id', 'mhs123', 'mahasiswa'),
(4, 2, 'Anita Hidayati', 'anita.hidayati@pnj.ac.id', 'dosen123', 'dosen'),
(5, 2, 'Ahmad Fauzi', 'ahmad.fauzi@pnj.ac.id', 'mhs123', 'mahasiswa');

INSERT INTO dosen_profiles (user_id, nidn, gelar_depan, gelar_belakang) VALUES
(2, '0012057801', 'Dr.', 'S.Kom., M.T.'),
(4, '0014088202', '', 'S.Kom., M.Kom.');

INSERT INTO mahasiswa_profiles (user_id, nim, angkatan) VALUES
(3, '2207421035', 2022),
(5, '2207421001', 2022);

-- 7b. Data Mata Kuliah & Dosen Pengampu Semester Aktif
INSERT INTO course_offerings (id, study_program_id, dosen_id, kode_mk, nama_mk, kelas, sks, semester) VALUES
(1, 1, 2, 'TIK302', 'Manajemen Proyek TIK', 'TI-3C', 3, '2026/2027 Ganjil'),
(2, 1, 2, 'TIK301', 'Pemrograman Visual', 'TI-3C', 3, '2026/2027 Ganjil'),
(3, 1, 2, 'TIK304', 'Kecerdasan Buatan (AI)', 'TI-3C', 3, '2026/2027 Ganjil'),
(4, 2, 4, 'TMJ308', 'Analisis dan Desain Sistem Informasi', 'TMJ-3A', 3, '2026/2027 Ganjil'),
(5, 2, 4, 'TMJ306', 'Pemrograman Web Lanjut', 'TMJ-3A', 3, '2026/2027 Ganjil'),
(6, 3, 2, 'TMD301', 'Pemrograman Visual', 'TMD-3A', 3, '2026/2027 Ganjil'),
(7, 4, 4, 'RKS302', 'Keamanan Sistem Informasi', 'RKS-3A', 3, '2026/2027 Ganjil');

-- 8. Data Master 27 Butir Instrumen Soal Kuisioner EDOM
INSERT INTO edom_questions (id, nomor, kategori_index, kategori_judul, teks, is_active) VALUES
(1, 1, 1, '1. Kompetensi Pedagogik', 'Kesiapan memberikan kuliah dan/atau praktek/praktikum', 1),
(2, 2, 1, '1. Kompetensi Pedagogik', 'Keteraturan dan ketertiban penyelenggaraan perkuliahan', 1),
(3, 3, 1, '1. Kompetensi Pedagogik', 'Kemampuan menghidupkan suasana kelas', 1),
(4, 4, 1, '1. Kompetensi Pedagogik', 'Kejelasan penyampaian materi dan jawaban terhadap pertanyaan di kelas', 1),
(5, 5, 1, '1. Kompetensi Pedagogik', 'Pemanfaatan media dan teknologi pembelajaran', 1),
(6, 6, 1, '1. Kompetensi Pedagogik', 'Keanekaragaman cara pengukuran/penilaian hasil belajar', 1),
(7, 7, 1, '1. Kompetensi Pedagogik', 'Pemberian umpan balik terhadap tugas/penilaian', 1),
(8, 8, 1, '1. Kompetensi Pedagogik', 'Kesesuaian materi ujian dan/atau tugas dengan tujuan mata kuliah', 1),
(9, 9, 1, '1. Kompetensi Pedagogik', 'Kesesuaian nilai yang diberikan dengan hasil belajar', 1),
(10, 1, 2, '2. Kompetensi Profesional', 'Kemampuan menjelaskan pokok bahasan/topik secara tepat sesuai GBPP dan SAP', 1),
(11, 2, 2, '2. Kompetensi Profesional', 'Kemampuan memberi contoh relevan dari konsep yang diajarkan berdasarkan Program Studi', 1),
(12, 3, 2, '2. Kompetensi Profesional', 'Kemampuan menjelaskan keterkaitan bidang/topik yang diajarkan dengan bidang/topik lain', 1),
(13, 4, 2, '2. Kompetensi Profesional', 'Kemampuan menjelaskan keterkaitan bidang/topik yang diajarkan dengan konteks kehidupan', 1),
(14, 5, 2, '2. Kompetensi Profesional', 'Penguasaan akan isu-isu mutakhir dalam bidang yang diajarkan (kemutakhiran bahan kuliah)', 1),
(15, 6, 2, '2. Kompetensi Profesional', 'Penggunaan hasil-hasil penelitian untuk meningkatkan kualitas perkuliahan', 1),
(16, 7, 2, '2. Kompetensi Profesional', 'Pelibatan mahasiswa dalam penelitian/kajian dan atau pengembangan/desain dosen', 1),
(17, 8, 2, '2. Kompetensi Profesional', 'Kemampuan menggunakan beragam teknologi komunikasi', 1),
(18, 1, 3, '3. Kompetensi Kepribadian', 'Kewibawaan sebagai pribadi dosen', 1),
(19, 2, 3, '3. Kompetensi Kepribadian', 'Kearifan dalam mengambil keputusan', 1),
(20, 3, 3, '3. Kompetensi Kepribadian', 'Menjadi contoh dalam bersikap dan berperilaku', 1),
(21, 4, 3, '3. Kompetensi Kepribadian', 'Satu kata dan tindakan', 1),
(22, 5, 3, '3. Kompetensi Kepribadian', 'Kemampuan mengendalikan diri dalam berbagai situasi dan kondisi', 1),
(23, 6, 3, '3. Kompetensi Kepribadian', 'Adil dalam memperlakukan mahasiswa', 1),
(24, 1, 4, '4. Kompetensi Sosial', 'Kemampuan menyampaikan pendapat', 1),
(25, 2, 4, '4. Kompetensi Sosial', 'Kemampuan menerima kritik, saran, dan pendapat dari mahasiswa', 1),
(26, 3, 4, '4. Kompetensi Sosial', 'Mengenal dengan baik mahasiswa yang mengikuti kuliahnya', 1),
(27, 4, 4, '4. Kompetensi Sosial', 'Toleransi terhadap keberagaman mahasiswa', 1);
