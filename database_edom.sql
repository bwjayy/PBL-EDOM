-- Skrip Database PBL-EDOM (Evaluasi Dosen Oleh Mahasiswa)
-- Jurusan Teknik Informatika dan Komputer (TIK) - Politeknik Negeri Jakarta

CREATE DATABASE IF NOT EXISTS edom_pbl;
USE edom_pbl;

-- Tabel Program Studi
DROP TABLE IF EXISTS mahasiswa_profiles;
DROP TABLE IF EXISTS dosen_profiles;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS study_programs;

CREATE TABLE study_programs (
    id INT PRIMARY KEY,
    code VARCHAR(10) NOT NULL UNIQUE,
    name VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Tabel Akun Pengguna (Users)
CREATE TABLE users (
    id BIGINT PRIMARY KEY,
    study_program_id INT NULL,
    name VARCHAR(150) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role VARCHAR(20) NOT NULL,
    CONSTRAINT fk_users_study_programs FOREIGN KEY (study_program_id) REFERENCES study_programs(id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Tabel Profil Khusus Dosen
CREATE TABLE dosen_profiles (
    user_id BIGINT PRIMARY KEY,
    nidn VARCHAR(20) NOT NULL,
    gelar_depan VARCHAR(20) DEFAULT NULL,
    gelar_belakang VARCHAR(50) DEFAULT NULL,
    CONSTRAINT fk_dosen_profiles_user FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Tabel Profil Khusus Mahasiswa
CREATE TABLE mahasiswa_profiles (
    user_id BIGINT PRIMARY KEY,
    nim VARCHAR(20) NOT NULL,
    angkatan INT NOT NULL,
    CONSTRAINT fk_mahasiswa_profiles_user FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data Master Program Studi
INSERT INTO study_programs (id, code, name) VALUES
(1, 'TI',  'Teknik Informatika'),
(2, 'TMJ', 'Teknik Multimedia dan Jaringan'),
(3, 'TMD', 'Teknik Multimedia Digital'),
(4, 'RKS', 'Rekayasa Keamanan Siber');

-- Data Akun Pengujian (3 Role: Admin, Dosen, Mahasiswa)
-- Akun 1: Admin TI     - Email: admin.ti@pnj.ac.id        - Sandi: admin123
-- Akun 2: Dosen TI     - Email: bambang.warsuta@pnj.ac.id  - Sandi: dosen123
-- Akun 3: Mahasiswa TI - Email: rahmat.ti@pnj.ac.id       - Sandi: mhs123

INSERT INTO users (id, study_program_id, name, email, password_hash, role) VALUES
(1, 1, 'Admin TI PNJ', 'admin.ti@pnj.ac.id', 'admin123', 'admin'),
(2, 1, 'Bambang Warsuta', 'bambang.warsuta@pnj.ac.id', 'dosen123', 'dosen'),
(3, 1, 'Muhammad Rahmat', 'rahmat.ti@pnj.ac.id', 'mhs123', 'mahasiswa');

INSERT INTO dosen_profiles (user_id, nidn, gelar_depan, gelar_belakang) VALUES
(2, '0012057801', 'Dr.', 'S.Kom., M.T.');

INSERT INTO mahasiswa_profiles (user_id, nim, angkatan) VALUES
(3, '2207421035', 2022);

-- Alternatif: Skrip Microsoft SQL Server (T-SQL / SSMS)
/*
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'edom_pbl')
BEGIN
    CREATE DATABASE edom_pbl;
END
GO

USE edom_pbl;
GO

IF OBJECT_ID('mahasiswa_profiles', 'U') IS NOT NULL DROP TABLE mahasiswa_profiles;
IF OBJECT_ID('dosen_profiles', 'U') IS NOT NULL DROP TABLE dosen_profiles;
IF OBJECT_ID('users', 'U') IS NOT NULL DROP TABLE users;
IF OBJECT_ID('study_programs', 'U') IS NOT NULL DROP TABLE study_programs;
GO

CREATE TABLE study_programs (
    id INT PRIMARY KEY,
    code VARCHAR(10) NOT NULL UNIQUE,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE users (
    id BIGINT PRIMARY KEY,
    study_program_id INT NULL FOREIGN KEY REFERENCES study_programs(id),
    name VARCHAR(150) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role VARCHAR(20) NOT NULL
);

CREATE TABLE dosen_profiles (
    user_id BIGINT PRIMARY KEY FOREIGN KEY REFERENCES users(id),
    nidn VARCHAR(20) NOT NULL,
    gelar_depan VARCHAR(20) NULL,
    gelar_belakang VARCHAR(50) NULL
);

CREATE TABLE mahasiswa_profiles (
    user_id BIGINT PRIMARY KEY FOREIGN KEY REFERENCES users(id),
    nim VARCHAR(20) NOT NULL,
    angkatan INT NOT NULL
);
GO

INSERT INTO study_programs (id, code, name) VALUES
(1, 'TI',  'Teknik Informatika'),
(2, 'TMJ', 'Teknik Multimedia dan Jaringan'),
(3, 'TMD', 'Teknik Multimedia Digital'),
(4, 'RKS', 'Rekayasa Keamanan Siber');

INSERT INTO users (id, study_program_id, name, email, password_hash, role) VALUES
(1, 1, 'Admin TI PNJ', 'admin.ti@pnj.ac.id', 'admin123', 'admin'),
(2, 1, 'Bambang Warsuta', 'bambang.warsuta@pnj.ac.id', 'dosen123', 'dosen'),
(3, 1, 'Muhammad Rahmat', 'rahmat.ti@pnj.ac.id', 'mhs123', 'mahasiswa');

INSERT INTO dosen_profiles (user_id, nidn, gelar_depan, gelar_belakang) VALUES
(2, '0012057801', 'Dr.', 'S.Kom., M.T.');

INSERT INTO mahasiswa_profiles (user_id, nim, angkatan) VALUES
(3, '2207421035', 2022);
GO
*/

