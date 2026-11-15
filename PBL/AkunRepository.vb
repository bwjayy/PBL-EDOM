Imports System.Data
Imports System.Linq

Public Class UserAccountModel
    Public Property Id As Long
    Public Property Role As String = "mahasiswa" ' "dosen" atau "mahasiswa"
    Public Property Nama As String = ""
    Public Property Email As String = ""
    Public Property PasswordHash As String = ""
    Public Property ProdiId As Integer = 1
    Public Property Prodi As String = "Teknik Informatika"

    ' Khusus Dosen
    Public Property Nidn As String = ""
    Public Property GelarDepan As String = ""
    Public Property GelarBelakang As String = ""

    ' Khusus Mahasiswa
    Public Property Nim As String = ""
    Public Property Angkatan As Integer = 2022
    Public Property StatusEdom As String = "Selesai"

    ' Soft Delete Flag
    Public Property IsDeleted As Boolean = False

    Public ReadOnly Property Status As String
        Get
            Return If(IsDeleted, "Nonaktif", "Aktif")
        End Get
    End Property

    Public ReadOnly Property Identitas As String
        Get
            If Role.ToLower() = "dosen" Then
                Return If(String.IsNullOrWhiteSpace(Nidn), "-", Nidn.Trim())
            End If
            Return If(String.IsNullOrWhiteSpace(Nim), "-", Nim.Trim())
        End Get
    End Property

    Public ReadOnly Property NamaLengkapGelar As String
        Get
            If Role.ToLower() = "dosen" Then
                Dim hasil As String = Nama.Trim()
                If Not String.IsNullOrWhiteSpace(GelarDepan) Then hasil = GelarDepan.Trim() & " " & hasil
                If Not String.IsNullOrWhiteSpace(GelarBelakang) Then hasil = hasil & ", " & GelarBelakang.Trim()
                Return hasil
            End If
            Return Nama.Trim()
        End Get
    End Property
End Class

''' <summary>
''' Repository untuk operasi CRUD akun pengguna dengan dukungan database MySQL dan in-memory fallback.
''' </summary>
Public Module AkunRepository

    Private ReadOnly inMemoryAccounts As New List(Of UserAccountModel)()
    Private isInitialized As Boolean = False
    Private columnChecked As Boolean = False

    Private Sub EnsureColumnExists()
        If columnChecked Then Return
        Try
            ModKoneksi.ExecuteNonQuery("ALTER TABLE users ADD COLUMN is_deleted TINYINT(1) NOT NULL DEFAULT 0")
        Catch
        End Try
        columnChecked = True
    End Sub

    Public Sub EnsureInitialized()
        If isInitialized Then Return
        EnsureColumnExists()

        ' Data awal sesuai schema database_edom.sql
        inMemoryAccounts.Clear()

        ' Akun Admin Master (untuk login offline)
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 1,
            .Role = "admin",
            .Nama = "Admin",
            .Email = "admin@pnj.ac.id",
            .PasswordHash = "admin123",
            .ProdiId = 0,
            .Prodi = "Seluruh Jurusan"
        })

        ' Dosen
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 2,
            .Role = "dosen",
            .Nama = "Bambang Warsuta",
            .Email = "bambang.warsuta@pnj.ac.id",
            .PasswordHash = "dosen123",
            .ProdiId = 1,
            .Prodi = "Teknik Informatika",
            .Nidn = "0012057801",
            .GelarDepan = "Dr.",
            .GelarBelakang = "S.Kom., M.T."
        })
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 4,
            .Role = "dosen",
            .Nama = "Anita Hidayati",
            .Email = "anita.hidayati@pnj.ac.id",
            .PasswordHash = "dosen123",
            .ProdiId = 2,
            .Prodi = "Teknik Multimedia dan Jaringan",
            .Nidn = "0014088202",
            .GelarDepan = "",
            .GelarBelakang = "S.Kom., M.Kom."
        })
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 6,
            .Role = "dosen",
            .Nama = "Asep Taufik Muharram",
            .Email = "asep.taufik@pnj.ac.id",
            .PasswordHash = "dosen123",
            .ProdiId = 3,
            .Prodi = "Teknik Multimedia Digital",
            .Nidn = "0022037901",
            .GelarDepan = "",
            .GelarBelakang = "S.T., M.Kom."
        })
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 7,
            .Role = "dosen",
            .Nama = "Chairul Fikri",
            .Email = "chairul.fikri@pnj.ac.id",
            .PasswordHash = "dosen123",
            .ProdiId = 4,
            .Prodi = "Rekayasa Keamanan Siber",
            .Nidn = "0018098503",
            .GelarDepan = "",
            .GelarBelakang = "S.T., M.Sc."
        })
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 8,
            .Role = "dosen",
            .Nama = "Defiana Arnaldy",
            .Email = "defiana.arnaldy@pnj.ac.id",
            .PasswordHash = "dosen123",
            .ProdiId = 1,
            .Prodi = "Teknik Informatika",
            .Nidn = "0025118704",
            .GelarDepan = "",
            .GelarBelakang = "S.Kom., M.Si."
        })

        ' Mahasiswa
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 3,
            .Role = "mahasiswa",
            .Nama = "Muhammad Rahmat",
            .Email = "rahmat.ti@pnj.ac.id",
            .PasswordHash = "mhs123",
            .ProdiId = 1,
            .Prodi = "Teknik Informatika",
            .Nim = "2207421035",
            .Angkatan = 2022,
            .StatusEdom = "Selesai"
        })
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 5,
            .Role = "mahasiswa",
            .Nama = "Ahmad Fauzi",
            .Email = "ahmad.fauzi@pnj.ac.id",
            .PasswordHash = "mhs123",
            .ProdiId = 2,
            .Prodi = "Teknik Multimedia dan Jaringan",
            .Nim = "2207421001",
            .Angkatan = 2022,
            .StatusEdom = "Selesai"
        })
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 9,
            .Role = "mahasiswa",
            .Nama = "Bima Arya Prasetya",
            .Email = "bima.arya@pnj.ac.id",
            .PasswordHash = "mhs123",
            .ProdiId = 3,
            .Prodi = "Teknik Multimedia Digital",
            .Nim = "2207421002",
            .Angkatan = 2022,
            .StatusEdom = "Belum Lengkap"
        })
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 10,
            .Role = "mahasiswa",
            .Nama = "Citra Kirana Lestari",
            .Email = "citra.lestari@pnj.ac.id",
            .PasswordHash = "mhs123",
            .ProdiId = 4,
            .Prodi = "Rekayasa Keamanan Siber",
            .Nim = "2207421003",
            .Angkatan = 2022,
            .StatusEdom = "Selesai"
        })
        inMemoryAccounts.Add(New UserAccountModel With {
            .Id = 11,
            .Role = "mahasiswa",
            .Nama = "Dinda Ayu Rahmawati",
            .Email = "dinda.ayu@pnj.ac.id",
            .PasswordHash = "mhs123",
            .ProdiId = 1,
            .Prodi = "Teknik Informatika",
            .Nim = "2207421004",
            .Angkatan = 2022,
            .StatusEdom = "Selesai"
        })

        isInitialized = True
    End Sub

    ''' <summary>
    ''' Mengambil seluruh data akun (Dosen & Mahasiswa).
    ''' </summary>
    Public Function GetAllAccounts() As List(Of UserAccountModel)
        EnsureInitialized()

        Try
            Dim sql As String =
                "SELECT u.*, " &
                "       COALESCE(sp.name, 'Umum') AS prodi_name, " &
                "       dp.nidn, dp.gelar_depan, dp.gelar_belakang, " &
                "       mp.nim, mp.angkatan " &
                "FROM users u " &
                "LEFT JOIN study_programs sp ON u.study_program_id = sp.id " &
                "LEFT JOIN dosen_profiles dp ON u.id = dp.user_id " &
                "LEFT JOIN mahasiswa_profiles mp ON u.id = mp.user_id " &
                "WHERE u.role IN ('dosen', 'mahasiswa') " &
                "ORDER BY u.role ASC, u.name ASC"

            Dim dt As DataTable = ModKoneksi.ExecuteQuery(sql)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim listFromDb As New List(Of UserAccountModel)()
                For Each r As DataRow In dt.Rows
                    Dim isDel As Boolean = False
                    If dt.Columns.Contains("is_deleted") AndAlso Not IsDBNull(r("is_deleted")) Then
                        isDel = (Convert.ToInt32(r("is_deleted")) = 1)
                    End If

                    Dim item As New UserAccountModel With {
                        .Id = Convert.ToInt64(r("id")),
                        .Role = r("role").ToString().Trim().ToLower(),
                        .Nama = r("name").ToString().Trim(),
                        .Email = r("email").ToString().Trim(),
                        .PasswordHash = If(IsDBNull(r("password_hash")), "", r("password_hash").ToString()),
                        .ProdiId = If(IsDBNull(r("study_program_id")), 1, Convert.ToInt32(r("study_program_id"))),
                        .Prodi = r("prodi_name").ToString().Trim(),
                        .Nidn = If(IsDBNull(r("nidn")), "", r("nidn").ToString().Trim()),
                        .GelarDepan = If(IsDBNull(r("gelar_depan")), "", r("gelar_depan").ToString().Trim()),
                        .GelarBelakang = If(IsDBNull(r("gelar_belakang")), "", r("gelar_belakang").ToString().Trim()),
                        .Nim = If(IsDBNull(r("nim")), "", r("nim").ToString().Trim()),
                        .Angkatan = If(IsDBNull(r("angkatan")), 2022, Convert.ToInt32(r("angkatan"))),
                        .StatusEdom = "Selesai",
                        .IsDeleted = isDel
                    }
                    listFromDb.Add(item)
                Next
                Return listFromDb
            End If
        Catch ex As Exception
        End Try

        ' Fallback ke in-memory jika database tidak aktif
        Return inMemoryAccounts.Where(Function(a) a.Role.ToLower() <> "admin").ToList()
    End Function

    ''' <summary>
    ''' Menambahkan akun baru (Mahasiswa atau Dosen) ke database dan in-memory.
    ''' </summary>
    Public Function CreateAccount(acc As UserAccountModel, ByRef errorMsg As String) As Boolean
        EnsureInitialized()

        ' Validasi Email Duplikat
        Dim all = GetAllAccounts()
        If all.Any(Function(a) a.Email.Equals(acc.Email.Trim(), StringComparison.OrdinalIgnoreCase)) Then
            errorMsg = "Email '" & acc.Email & "' sudah digunakan oleh akun lain."
            Return False
        End If

        ' Generate ID baru
        Dim newId As Long = 1
        Try
            Dim maxObj = ModKoneksi.ExecuteScalar("SELECT COALESCE(MAX(id), 0) + 1 FROM users")
            If maxObj IsNot Nothing AndAlso Not IsDBNull(maxObj) Then
                newId = Convert.ToInt64(maxObj)
            End If
        Catch
            If inMemoryAccounts.Count > 0 Then
                newId = inMemoryAccounts.Max(Function(a) a.Id) + 1
            Else
                newId = 12
            End If
        End Try
        acc.Id = newId

        ' Simpan ke Database
        Try
            Dim pUser As New Dictionary(Of String, Object) From {
                {"id", acc.Id},
                {"prodi_id", acc.ProdiId},
                {"name", acc.Nama},
                {"email", acc.Email},
                {"password", acc.PasswordHash},
                {"role", acc.Role.ToLower()}
            }
            Dim sqlUser = "INSERT INTO users (id, study_program_id, name, email, password_hash, role) " &
                          "VALUES (@id, @prodi_id, @name, @email, @password, @role)"
            ModKoneksi.ExecuteNonQuery(sqlUser, pUser)

            If acc.Role.ToLower() = "dosen" Then
                Dim pDosen As New Dictionary(Of String, Object) From {
                    {"user_id", acc.Id},
                    {"nidn", acc.Nidn},
                    {"gelar_depan", acc.GelarDepan},
                    {"gelar_belakang", acc.GelarBelakang}
                }
                Dim sqlDosen = "INSERT INTO dosen_profiles (user_id, nidn, gelar_depan, gelar_belakang) " &
                               "VALUES (@user_id, @nidn, @gelar_depan, @gelar_belakang)"
                ModKoneksi.ExecuteNonQuery(sqlDosen, pDosen)
            ElseIf acc.Role.ToLower() = "mahasiswa" Then
                Dim pMhs As New Dictionary(Of String, Object) From {
                    {"user_id", acc.Id},
                    {"nim", acc.Nim},
                    {"angkatan", acc.Angkatan}
                }
                Dim sqlMhs = "INSERT INTO mahasiswa_profiles (user_id, nim, angkatan) " &
                             "VALUES (@user_id, @nim, @angkatan)"
                ModKoneksi.ExecuteNonQuery(sqlMhs, pMhs)
            End If
        Catch ex As Exception
            ' Abaikan error DB jika offline, data tetap tersimpan di in-memory
        End Try

        ' Simpan ke in-memory
        inMemoryAccounts.Add(acc)
        errorMsg = ""
        Return True
    End Function

    ''' <summary>
    ''' Memperbarui data akun (nama, email, prodi, profil) dan merubah password jika diisi.
    ''' </summary>
    Public Function UpdateAccount(acc As UserAccountModel, newPassword As String, ByRef errorMsg As String) As Boolean
        EnsureInitialized()

        ' Validasi Email Duplikat
        Dim all = GetAllAccounts()
        If all.Any(Function(a) a.Id <> acc.Id AndAlso a.Email.Equals(acc.Email.Trim(), StringComparison.OrdinalIgnoreCase)) Then
            errorMsg = "Email '" & acc.Email & "' sudah digunakan oleh akun lain."
            Return False
        End If

        Dim updatePassword As Boolean = Not String.IsNullOrWhiteSpace(newPassword)
        If updatePassword Then
            acc.PasswordHash = newPassword.Trim()
        End If

        ' Update Database
        Try
            Dim pUser As New Dictionary(Of String, Object) From {
                {"id", acc.Id},
                {"name", acc.Nama},
                {"email", acc.Email},
                {"prodi_id", acc.ProdiId}
            }
            Dim sqlUser As String
            If updatePassword Then
                pUser.Add("password", acc.PasswordHash)
                sqlUser = "UPDATE users SET name = @name, email = @email, study_program_id = @prodi_id, password_hash = @password WHERE id = @id"
            Else
                sqlUser = "UPDATE users SET name = @name, email = @email, study_program_id = @prodi_id WHERE id = @id"
            End If
            ModKoneksi.ExecuteNonQuery(sqlUser, pUser)

            If acc.Role.ToLower() = "dosen" Then
                Dim pDosen As New Dictionary(Of String, Object) From {
                    {"user_id", acc.Id},
                    {"nidn", acc.Nidn},
                    {"gelar_depan", acc.GelarDepan},
                    {"gelar_belakang", acc.GelarBelakang}
                }
                ' Upsert dosen_profiles
                Dim sqlDosen = "INSERT INTO dosen_profiles (user_id, nidn, gelar_depan, gelar_belakang) " &
                               "VALUES (@user_id, @nidn, @gelar_depan, @gelar_belakang) " &
                               "ON DUPLICATE KEY UPDATE nidn = @nidn, gelar_depan = @gelar_depan, gelar_belakang = @gelar_belakang"
                ModKoneksi.ExecuteNonQuery(sqlDosen, pDosen)
            ElseIf acc.Role.ToLower() = "mahasiswa" Then
                Dim pMhs As New Dictionary(Of String, Object) From {
                    {"user_id", acc.Id},
                    {"nim", acc.Nim},
                    {"angkatan", acc.Angkatan}
                }
                ' Upsert mahasiswa_profiles
                Dim sqlMhs = "INSERT INTO mahasiswa_profiles (user_id, nim, angkatan) " &
                             "VALUES (@user_id, @nim, @angkatan) " &
                             "ON DUPLICATE KEY UPDATE nim = @nim, angkatan = @angkatan"
                ModKoneksi.ExecuteNonQuery(sqlMhs, pMhs)
            End If
        Catch ex As Exception
        End Try

        ' Update in-memory
        Dim existing = inMemoryAccounts.FirstOrDefault(Function(a) a.Id = acc.Id)
        If existing IsNot Nothing Then
            existing.Nama = acc.Nama
            existing.Email = acc.Email
            existing.ProdiId = acc.ProdiId
            existing.Prodi = acc.Prodi
            If updatePassword Then existing.PasswordHash = acc.PasswordHash
            existing.Nidn = acc.Nidn
            existing.GelarDepan = acc.GelarDepan
            existing.GelarBelakang = acc.GelarBelakang
            existing.Nim = acc.Nim
            existing.Angkatan = acc.Angkatan
        End If

        errorMsg = ""
        Return True
    End Function

    ''' <summary>
    ''' Menonaktifkan akun (Soft Delete) tanpa menghapus data secara permanen.
    ''' </summary>
    Public Function SoftDeleteAccount(userId As Long, ByRef errorMsg As String) As Boolean
        EnsureInitialized()

        Try
            Dim p As New Dictionary(Of String, Object) From {{"user_id", userId}}
            ModKoneksi.ExecuteNonQuery("UPDATE users SET is_deleted = 1 WHERE id = @user_id", p)
        Catch ex As Exception
        End Try

        Dim target = inMemoryAccounts.FirstOrDefault(Function(a) a.Id = userId)
        If target IsNot Nothing Then
            target.IsDeleted = True
        End If

        errorMsg = ""
        Return True
    End Function

    ''' <summary>
    ''' Mengaktifkan kembali akun yang dinonaktifkan (Restore dari soft delete).
    ''' </summary>
    Public Function RestoreAccount(userId As Long, ByRef errorMsg As String) As Boolean
        EnsureInitialized()

        Try
            Dim p As New Dictionary(Of String, Object) From {{"user_id", userId}}
            ModKoneksi.ExecuteNonQuery("UPDATE users SET is_deleted = 0 WHERE id = @user_id", p)
        Catch ex As Exception
        End Try

        Dim target = inMemoryAccounts.FirstOrDefault(Function(a) a.Id = userId)
        If target IsNot Nothing Then
            target.IsDeleted = False
        End If

        errorMsg = ""
        Return True
    End Function

    ''' <summary>
    ''' Fitur delete admin strictly soft delete.
    ''' </summary>
    Public Function DeleteAccount(userId As Long, ByRef errorMsg As String) As Boolean
        Return SoftDeleteAccount(userId, errorMsg)
    End Function

    ''' <summary>
    ''' Autentikasi offline jika database server tidak aktif.
    ''' </summary>
    Public Function AuthenticateOffline(emailOrUser As String, password As String) As UserAccountModel
        EnsureInitialized()
        Dim trimmedEmail = emailOrUser.Trim()
        Dim found = inMemoryAccounts.FirstOrDefault(Function(a) (a.Email.Equals(trimmedEmail, StringComparison.OrdinalIgnoreCase) OrElse a.Nama.Equals(trimmedEmail, StringComparison.OrdinalIgnoreCase)) AndAlso a.PasswordHash = password)
        Return found
    End Function

    ''' <summary>
    ''' Mendapatkan nama prodi berdasarkan ID
    ''' </summary>
    Public Function GetProdiName(id As Integer) As String
        Select Case id
            Case 1 : Return "Teknik Informatika"
            Case 2 : Return "Teknik Multimedia dan Jaringan"
            Case 3 : Return "Teknik Multimedia Digital"
            Case 4 : Return "Rekayasa Keamanan Siber"
            Case Else : Return "Umum"
        End Select
    End Function

    ''' <summary>
    ''' Mendapatkan ID prodi berdasarkan nama
    ''' </summary>
    Public Function GetProdiId(name As String) As Integer
        Select Case name.Trim().ToLower()
            Case "teknik informatika" : Return 1
            Case "teknik multimedia dan jaringan" : Return 2
            Case "teknik multimedia digital" : Return 3
            Case "rekayasa keamanan siber" : Return 4
            Case Else : Return 1
        End Select
    End Function

End Module

