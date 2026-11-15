-- Jalankan sekali pada database edom_pbl yang sudah digunakan.
-- MySQL / MariaDB
USE edom_pbl;

CREATE TABLE IF NOT EXISTS edom_settings (
    study_program_id INT PRIMARY KEY,
    is_locked TINYINT(1) NOT NULL DEFAULT 0,
    updated_by BIGINT NULL,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT fk_edom_settings_program FOREIGN KEY (study_program_id) REFERENCES study_programs(id) ON DELETE CASCADE,
    CONSTRAINT fk_edom_settings_admin FOREIGN KEY (updated_by) REFERENCES users(id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- SQL Server: gunakan bagian ini sebagai pengganti perintah CREATE TABLE di atas.
/*
USE edom_pbl;
GO
IF OBJECT_ID('edom_settings', 'U') IS NULL
BEGIN
    CREATE TABLE edom_settings (
        study_program_id INT PRIMARY KEY FOREIGN KEY REFERENCES study_programs(id) ON DELETE CASCADE,
        is_locked BIT NOT NULL DEFAULT 0,
        updated_by BIGINT NULL FOREIGN KEY REFERENCES users(id) ON DELETE SET NULL,
        updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
    );
END;
GO
*/
