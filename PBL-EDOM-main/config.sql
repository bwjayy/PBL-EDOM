-- Skrip Setup Database EDOM (PBL)
-- Kompatibel dengan MySQL / MariaDB (XAMPP phpMyAdmin)

CREATE DATABASE IF NOT EXISTS edom_pbl;
USE edom_pbl;

-- 1. Hapus tabel lama jika ada (urutan disesuaikan relasi foreign key)
DROP TABLE IF EXISTS mahasiswa_profiles;
DROP TABLE IF EXISTS dosen_profiles;
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

-- 6. Data Master Program Studi
INSERT INTO study_programs (id, code, name) VALUES
(1, 'TI',  'Teknik Informatika'),
(2, 'TMJ', 'Teknik Multimedia dan Jaringan'),
(3, 'TMD', 'Teknik Multimedia Digital'),
(4, 'RKS', 'Rekayasa Keamanan Siber');

-- 7. Data Akun Pengujian (Testing Accounts)
-- Admin TI:     admin.ti@pnj.ac.id        | Kata Sandi: admin123
-- Dosen TI:     bambang.warsuta@pnj.ac.id  | Kata Sandi: dosen123
-- Mahasiswa TI: rahmat.ti@pnj.ac.id       | Kata Sandi: mhs123

INSERT INTO users (id, study_program_id, name, email, password_hash, role) VALUES
(1, 1, 'Admin TI PNJ', 'admin.ti@pnj.ac.id', 'admin123', 'admin'),
(2, 1, 'Bambang Warsuta', 'bambang.warsuta@pnj.ac.id', 'dosen123', 'dosen'),
(3, 1, 'Muhammad Rahmat', 'rahmat.ti@pnj.ac.id', 'mhs123', 'mahasiswa');

INSERT INTO dosen_profiles (user_id, nidn, gelar_depan, gelar_belakang) VALUES
(2, '0012057801', 'Dr.', 'S.Kom., M.T.');

INSERT INTO mahasiswa_profiles (user_id, nim, angkatan) VALUES
(3, '2207421035', 2022);
