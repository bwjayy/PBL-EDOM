Imports System.Data
Imports System.Linq

Public Class SoalKuisionerModel
    Public Property Id As Long
    Public Property Nomor As Integer
    Public Property KategoriIndex As Integer
    Public Property KategoriJudul As String = ""
    Public Property Teks As String = ""
    Public Property IsActive As Boolean = True
    Public Property CreatedAt As DateTime = DateTime.Now

    Public ReadOnly Property StatusText As String
        Get
            Return If(IsActive, "Aktif", "Nonaktif")
        End Get
    End Property

    Public ReadOnly Property KategoriBadgeName As String
        Get
            Select Case KategoriIndex
                Case 1 : Return "Pedagogik"
                Case 2 : Return "Profesional"
                Case 3 : Return "Kepribadian"
                Case 4 : Return "Sosial"
                Case Else : Return "Umum"
            End Select
        End Get
    End Property
End Class

Public Module SoalKuisionerRepository

    Private ReadOnly inMemorySoal As New List(Of SoalKuisionerModel)()
    Private isInitialized As Boolean = False
    Private tableChecked As Boolean = False

    Private Function IsAdmin() As Boolean
        If Not UserSession.IsLoggedIn Then Return False
        Dim r = UserSession.Role.Trim().ToLower()
        Return (r = "admin" OrElse r = "superadmin")
    End Function

    Public Function GetKategoriTitle(index As Integer) As String
        Select Case index
            Case 1 : Return "1. Kompetensi Pedagogik"
            Case 2 : Return "2. Kompetensi Profesional"
            Case 3 : Return "3. Kompetensi Kepribadian"
            Case 4 : Return "4. Kompetensi Sosial"
            Case Else : Return "Kompetensi Umum"
        End Select
    End Function

    Public Function GetKategoriShortName(index As Integer) As String
        Select Case index
            Case 1 : Return "Pedagogik"
            Case 2 : Return "Profesional"
            Case 3 : Return "Kepribadian"
            Case 4 : Return "Sosial"
            Case Else : Return "Umum"
        End Select
    End Function

    Private Sub EnsureTableExists()
        If tableChecked Then Return
        Try
            Dim sqlCreateTable As String =
                "CREATE TABLE IF NOT EXISTS edom_questions (" &
                "    id BIGINT PRIMARY KEY, " &
                "    nomor INT NOT NULL, " &
                "    kategori_index INT NOT NULL, " &
                "    kategori_judul VARCHAR(100) NOT NULL, " &
                "    teks TEXT NOT NULL, " &
                "    is_active TINYINT(1) NOT NULL DEFAULT 1" &
                ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"
            ModKoneksi.ExecuteNonQuery(sqlCreateTable)
        Catch
        End Try
        tableChecked = True
    End Sub

    Public Sub EnsureInitialized()
        If isInitialized Then Return
        EnsureTableExists()

        inMemorySoal.Clear()

        ' Kategori 1: Pedagogik (Nomor 1 s/d 9)
        Dim pedagogik = {
            "Kesiapan memberikan kuliah dan/atau praktek/praktikum",
            "Keteraturan dan ketertiban penyelenggaraan perkuliahan",
            "Kemampuan menghidupkan suasana kelas",
            "Kejelasan penyampaian materi dan jawaban terhadap pertanyaan di kelas",
            "Pemanfaatan media dan teknologi pembelajaran",
            "Keanekaragaman cara pengukuran/penilaian hasil belajar",
            "Pemberian umpan balik terhadap tugas/penilaian",
            "Kesesuaian materi ujian dan/atau tugas dengan tujuan mata kuliah",
            "Kesesuaian nilai yang diberikan dengan hasil belajar"
        }
        For i = 0 To pedagogik.Length - 1
            inMemorySoal.Add(New SoalKuisionerModel With {
                .Id = i + 1,
                .Nomor = i + 1,
                .KategoriIndex = 1,
                .KategoriJudul = GetKategoriTitle(1),
                .Teks = pedagogik(i),
                .IsActive = True
            })
        Next

        ' Kategori 2: Profesional (Nomor 1 s/d 8)
        Dim profesional = {
            "Kemampuan menjelaskan pokok bahasan/topik secara tepat sesuai GBPP dan SAP",
            "Kemampuan memberi contoh relevan dari konsep yang diajarkan berdasarkan Program Studi",
            "Kemampuan menjelaskan keterkaitan bidang/topik yang diajarkan dengan bidang/topik lain",
            "Kemampuan menjelaskan keterkaitan bidang/topik yang diajarkan dengan konteks kehidupan",
            "Penguasaan akan isu-isu mutakhir dalam bidang yang diajarkan (kemutakhiran bahan kuliah)",
            "Penggunaan hasil-hasil penelitian untuk meningkatkan kualitas perkuliahan",
            "Pelibatan mahasiswa dalam penelitian/kajian dan atau pengembangan/desain dosen",
            "Kemampuan menggunakan beragam teknologi komunikasi"
        }
        For i = 0 To profesional.Length - 1
            inMemorySoal.Add(New SoalKuisionerModel With {
                .Id = 10 + i,
                .Nomor = i + 1,
                .KategoriIndex = 2,
                .KategoriJudul = GetKategoriTitle(2),
                .Teks = profesional(i),
                .IsActive = True
            })
        Next

        ' Kategori 3: Kepribadian (Nomor 1 s/d 6)
        Dim kepribadian = {
            "Kewibawaan sebagai pribadi dosen",
            "Kearifan dalam mengambil keputusan",
            "Menjadi contoh dalam bersikap dan berperilaku",
            "Satu kata dan tindakan",
            "Kemampuan mengendalikan diri dalam berbagai situasi dan kondisi",
            "Adil dalam memperlakukan mahasiswa"
        }
        For i = 0 To kepribadian.Length - 1
            inMemorySoal.Add(New SoalKuisionerModel With {
                .Id = 18 + i,
                .Nomor = i + 1,
                .KategoriIndex = 3,
                .KategoriJudul = GetKategoriTitle(3),
                .Teks = kepribadian(i),
                .IsActive = True
            })
        Next

        ' Kategori 4: Sosial (Nomor 1 s/d 4)
        Dim sosial = {
            "Kemampuan menyampaikan pendapat",
            "Kemampuan menerima kritik, saran, dan pendapat dari mahasiswa",
            "Mengenal dengan baik mahasiswa yang mengikuti kuliahnya",
            "Toleransi terhadap keberagaman mahasiswa"
        }
        For i = 0 To sosial.Length - 1
            inMemorySoal.Add(New SoalKuisionerModel With {
                .Id = 24 + i,
                .Nomor = i + 1,
                .KategoriIndex = 4,
                .KategoriJudul = GetKategoriTitle(4),
                .Teks = sosial(i),
                .IsActive = True
            })
        Next

        ' Seed database jika tabel masih kosong
        Try
            Dim countObj = ModKoneksi.ExecuteScalar("SELECT COUNT(*) FROM edom_questions")
            If countObj IsNot Nothing AndAlso Convert.ToInt32(countObj) = 0 Then
                For Each item In inMemorySoal
                    Dim p As New Dictionary(Of String, Object) From {
                        {"id", item.Id},
                        {"nomor", item.Nomor},
                        {"kategori_index", item.KategoriIndex},
                        {"kategori_judul", item.KategoriJudul},
                        {"teks", item.Teks},
                        {"is_active", If(item.IsActive, 1, 0)}
                    }
                    Dim sql = "INSERT INTO edom_questions (id, nomor, kategori_index, kategori_judul, teks, is_active) " &
                              "VALUES (@id, @nomor, @kategori_index, @kategori_judul, @teks, @is_active)"
                    ModKoneksi.ExecuteNonQuery(sql, p)
                Next
            Else
                ' Pastikan penomoran per-kategori rapi (migrasi data terdahulu jika nomor masih bersambung)
                ResequenceAllCategories()
            End If
        Catch
        End Try

        isInitialized = True
    End Sub

    ''' <summary>
    ''' Mengurutkan ulang nomor soal secara berurutan (1, 2, 3...) khusus di dalam satu kategori.
    ''' </summary>
    Public Sub ResequenceCategory(kategoriIndex As Integer)
        Try
            Dim sql = "SELECT id FROM edom_questions WHERE kategori_index = @kategori_index ORDER BY nomor ASC, id ASC"
            Dim pKat As New Dictionary(Of String, Object) From {{"kategori_index", kategoriIndex}}
            Dim dt As DataTable = ModKoneksi.ExecuteQuery(sql, pKat)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim curNo As Integer = 1
                For Each r As DataRow In dt.Rows
                    Dim qId = Convert.ToInt64(r("id"))
                    Dim pUpd As New Dictionary(Of String, Object) From {
                        {"id", qId},
                        {"nomor", curNo}
                    }
                    ModKoneksi.ExecuteNonQuery("UPDATE edom_questions SET nomor = @nomor WHERE id = @id", pUpd)
                    Dim mem = inMemorySoal.FirstOrDefault(Function(s) s.Id = qId)
                    If mem IsNot Nothing Then mem.Nomor = curNo
                    curNo += 1
                Next
                Return
            End If
        Catch
        End Try

        ' Fallback in-memory
        Dim memList = inMemorySoal.Where(Function(s) s.KategoriIndex = kategoriIndex).OrderBy(Function(s) s.Nomor).ThenBy(Function(s) s.Id).ToList()
        Dim noIdx As Integer = 1
        For Each item In memList
            item.Nomor = noIdx
            noIdx += 1
        Next
    End Sub

    Public Sub ResequenceAllCategories()
        For kat = 1 To 4
            ResequenceCategory(kat)
        Next
    End Sub

    Public Function GetAllSoal() As List(Of SoalKuisionerModel)
        EnsureInitialized()

        Try
            Dim sql = "SELECT id, nomor, kategori_index, kategori_judul, teks, is_active FROM edom_questions ORDER BY kategori_index ASC, nomor ASC, id ASC"
            Dim dt As DataTable = ModKoneksi.ExecuteQuery(sql)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim list As New List(Of SoalKuisionerModel)()
                For Each r As DataRow In dt.Rows
                    list.Add(New SoalKuisionerModel With {
                        .Id = Convert.ToInt64(r("id")),
                        .Nomor = Convert.ToInt32(r("nomor")),
                        .KategoriIndex = Convert.ToInt32(r("kategori_index")),
                        .KategoriJudul = r("kategori_judul").ToString(),
                        .Teks = r("teks").ToString(),
                        .IsActive = (Convert.ToInt32(r("is_active")) = 1)
                    })
                Next
                Return list
            End If
        Catch
        End Try

        Return inMemorySoal.OrderBy(Function(s) s.KategoriIndex).ThenBy(Function(s) s.Nomor).ThenBy(Function(s) s.Id).ToList()
    End Function

    Public Function GetActiveSoal() As List(Of SoalKuisionerModel)
        Return GetAllSoal().Where(Function(s) s.IsActive).OrderBy(Function(s) s.KategoriIndex).ThenBy(Function(s) s.Nomor).ThenBy(Function(s) s.Id).ToList()
    End Function

    Public Function GetNextNomor(kategoriIndex As Integer) As Integer
        EnsureInitialized()
        Dim list = GetAllSoal().Where(Function(s) s.KategoriIndex = kategoriIndex).ToList()
        If list.Count = 0 Then Return 1
        Return list.Max(Function(s) s.Nomor) + 1
    End Function

    Public Function CreateSoal(soal As SoalKuisionerModel, ByRef errorMsg As String) As Boolean
        EnsureInitialized()

        If Not IsAdmin() Then
            errorMsg = "Akses ditolak: Hanya Administrator yang berhak menambah soal kuisioner."
            Return False
        End If

        If String.IsNullOrWhiteSpace(soal.Teks) OrElse soal.Teks.Trim().Length < 5 Then
            errorMsg = "Teks pernyataan soal minimal harus terdiri dari 5 karakter."
            Return False
        End If

        If soal.KategoriIndex < 1 OrElse soal.KategoriIndex > 4 Then
            soal.KategoriIndex = 1
        End If
        soal.KategoriJudul = GetKategoriTitle(soal.KategoriIndex)

        ' Nomor otomatis mengikuti urutan soal pada kategori terpilih
        soal.Nomor = GetNextNomor(soal.KategoriIndex)

        Dim newId As Long = 1
        Try
            Dim maxObj = ModKoneksi.ExecuteScalar("SELECT COALESCE(MAX(id), 0) + 1 FROM edom_questions")
            If maxObj IsNot Nothing AndAlso Not IsDBNull(maxObj) Then
                newId = Convert.ToInt64(maxObj)
            End If
        Catch
            If inMemorySoal.Count > 0 Then
                newId = inMemorySoal.Max(Function(s) s.Id) + 1
            Else
                newId = 1
            End If
        End Try
        soal.Id = newId

        Try
            Dim p As New Dictionary(Of String, Object) From {
                {"id", soal.Id},
                {"nomor", soal.Nomor},
                {"kategori_index", soal.KategoriIndex},
                {"kategori_judul", soal.KategoriJudul},
                {"teks", soal.Teks.Trim()},
                {"is_active", If(soal.IsActive, 1, 0)}
            }
            Dim sql = "INSERT INTO edom_questions (id, nomor, kategori_index, kategori_judul, teks, is_active) " &
                      "VALUES (@id, @nomor, @kategori_index, @kategori_judul, @teks, @is_active)"
            ModKoneksi.ExecuteNonQuery(sql, p)
        Catch
        End Try

        inMemorySoal.Add(soal)
        errorMsg = ""
        Return True
    End Function

    Public Function UpdateSoal(soal As SoalKuisionerModel, ByRef errorMsg As String) As Boolean
        EnsureInitialized()

        If Not IsAdmin() Then
            errorMsg = "Akses ditolak: Hanya Administrator yang berhak merubah soal kuisioner."
            Return False
        End If

        If String.IsNullOrWhiteSpace(soal.Teks) OrElse soal.Teks.Trim().Length < 5 Then
            errorMsg = "Teks pernyataan soal minimal harus terdiri dari 5 karakter."
            Return False
        End If

        If soal.KategoriIndex < 1 OrElse soal.KategoriIndex > 4 Then
            soal.KategoriIndex = 1
        End If
        soal.KategoriJudul = GetKategoriTitle(soal.KategoriIndex)

        ' Cek jika kategori berubah, nomor disesuaikan ke urutan kategori baru
        Dim oldSoal = GetAllSoal().FirstOrDefault(Function(s) s.Id = soal.Id)
        Dim oldKat As Integer = If(oldSoal IsNot Nothing, oldSoal.KategoriIndex, soal.KategoriIndex)
        If oldKat <> soal.KategoriIndex Then
            soal.Nomor = GetNextNomor(soal.KategoriIndex)
        End If

        Try
            Dim p As New Dictionary(Of String, Object) From {
                {"id", soal.Id},
                {"nomor", soal.Nomor},
                {"kategori_index", soal.KategoriIndex},
                {"kategori_judul", soal.KategoriJudul},
                {"teks", soal.Teks.Trim()},
                {"is_active", If(soal.IsActive, 1, 0)}
            }
            Dim sql = "UPDATE edom_questions SET nomor = @nomor, kategori_index = @kategori_index, " &
                      "kategori_judul = @kategori_judul, teks = @teks, is_active = @is_active WHERE id = @id"
            ModKoneksi.ExecuteNonQuery(sql, p)
        Catch
        End Try

        Dim existing = inMemorySoal.FirstOrDefault(Function(s) s.Id = soal.Id)
        If existing IsNot Nothing Then
            existing.Nomor = soal.Nomor
            existing.KategoriIndex = soal.KategoriIndex
            existing.KategoriJudul = soal.KategoriJudul
            existing.Teks = soal.Teks.Trim()
            existing.IsActive = soal.IsActive
        End If

        If oldKat <> soal.KategoriIndex Then
            ResequenceCategory(oldKat)
        End If

        errorMsg = ""
        Return True
    End Function

    Public Function DeleteSoal(id As Long, ByRef errorMsg As String) As Boolean
        EnsureInitialized()

        If Not IsAdmin() Then
            errorMsg = "Akses ditolak: Hanya Administrator yang berhak menghapus soal kuisioner."
            Return False
        End If

        Dim targetSoal = GetAllSoal().FirstOrDefault(Function(s) s.Id = id)
        Dim katIdx As Integer = If(targetSoal IsNot Nothing, targetSoal.KategoriIndex, 1)

        Try
            Dim p As New Dictionary(Of String, Object) From {{"id", id}}
            ModKoneksi.ExecuteNonQuery("DELETE FROM edom_questions WHERE id = @id", p)
        Catch
        End Try

        Dim existing = inMemorySoal.FirstOrDefault(Function(s) s.Id = id)
        If existing IsNot Nothing Then
            inMemorySoal.Remove(existing)
        End If

        ' Rapikan kembali nomor urutan di kategori terkait
        ResequenceCategory(katIdx)

        errorMsg = ""
        Return True
    End Function

    Public Function ToggleStatusSoal(id As Long, ByRef errorMsg As String) As Boolean
        EnsureInitialized()

        If Not IsAdmin() Then
            errorMsg = "Akses ditolak: Hanya Administrator yang berhak mengubah status soal kuisioner."
            Return False
        End If

        Dim all = GetAllSoal()
        Dim target = all.FirstOrDefault(Function(s) s.Id = id)
        If target Is Nothing Then
            errorMsg = "Soal tidak ditemukan."
            Return False
        End If

        Dim newStatus As Boolean = Not target.IsActive
        Try
            Dim p As New Dictionary(Of String, Object) From {
                {"id", id},
                {"is_active", If(newStatus, 1, 0)}
            }
            ModKoneksi.ExecuteNonQuery("UPDATE edom_questions SET is_active = @is_active WHERE id = @id", p)
        Catch
        End Try

        Dim mem = inMemorySoal.FirstOrDefault(Function(s) s.Id = id)
        If mem IsNot Nothing Then
            mem.IsActive = newStatus
        End If

        errorMsg = ""
        Return True
    End Function

End Module
