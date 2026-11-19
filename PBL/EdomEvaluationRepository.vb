Imports System.Data
Imports System.Data.Common

Public Class CourseOfferingItem
    Public Property OfferingId As Integer
    Public Property KodeMk As String = String.Empty
    Public Property NamaMk As String = String.Empty
    Public Property Kelas As String = String.Empty
    Public Property Sks As Integer = 3
    Public Property Semester As String = String.Empty
    Public Property DosenId As Long
    Public Property DosenNama As String = String.Empty
    Public Property SudahTerisi As Boolean

    Public ReadOnly Property DisplayMatkul As String
        Get
            Return $"{KodeMk} - {NamaMk} ({Kelas})"
        End Get
    End Property
End Class

Public Class AnswerInput
    Public Property QuestionId As Long
    Public Property KategoriIndex As Integer
    Public Property Nilai As Integer
End Class

Public Class DosenCourseSummary
    Public Property OfferingId As Integer
    Public Property KodeMk As String = String.Empty
    Public Property NamaMk As String = String.Empty
    Public Property Kelas As String = String.Empty
    Public Property Sks As Integer = 3
    Public Property RespondenCount As Integer
    Public Property AvgPedagogik As Double?
    Public Property AvgProfesional As Double?
    Public Property AvgKepribadian As Double?
    Public Property AvgSosial As Double?

    Public ReadOnly Property HasCompleteCategories As Boolean
        Get
            Return RespondenCount > 0 AndAlso
                   AvgPedagogik.HasValue AndAlso
                   AvgProfesional.HasValue AndAlso
                   AvgKepribadian.HasValue AndAlso
                   AvgSosial.HasValue
        End Get
    End Property
End Class

Public Module EdomEvaluationRepository

    Private tablesChecked As Boolean = False

    Public Sub EnsureTablesReady()
        If tablesChecked Then Return

        Dim sqlOfferings As String =
            "CREATE TABLE IF NOT EXISTS course_offerings (" &
            "    id INT PRIMARY KEY, " &
            "    study_program_id INT NOT NULL, " &
            "    dosen_id BIGINT NOT NULL, " &
            "    kode_mk VARCHAR(20) NOT NULL, " &
            "    nama_mk VARCHAR(150) NOT NULL, " &
            "    kelas VARCHAR(20) NOT NULL, " &
            "    sks INT NOT NULL DEFAULT 3, " &
            "    semester VARCHAR(30) NOT NULL DEFAULT '2026/2027 Ganjil', " &
            "    CONSTRAINT fk_offerings_program FOREIGN KEY (study_program_id) REFERENCES study_programs(id) ON DELETE CASCADE, " &
            "    CONSTRAINT fk_offerings_dosen FOREIGN KEY (dosen_id) REFERENCES users(id) ON DELETE CASCADE" &
            ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"

        ' Denormalize kategori_index so deleting a question later never orphans or wipes past responses.
        Dim sqlAnswers As String =
            "CREATE TABLE IF NOT EXISTS edom_answers (" &
            "    id BIGINT AUTO_INCREMENT PRIMARY KEY, " &
            "    mahasiswa_id BIGINT NOT NULL, " &
            "    offering_id INT NOT NULL, " &
            "    question_id BIGINT NOT NULL, " &
            "    kategori_index INT NOT NULL, " &
            "    nilai TINYINT NOT NULL, " &
            "    submitted_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, " &
            "    UNIQUE KEY uq_mhs_offering_question (mahasiswa_id, offering_id, question_id), " &
            "    CONSTRAINT fk_answers_mahasiswa FOREIGN KEY (mahasiswa_id) REFERENCES users(id) ON DELETE CASCADE, " &
            "    CONSTRAINT fk_answers_offering FOREIGN KEY (offering_id) REFERENCES course_offerings(id) ON DELETE CASCADE" &
            ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;"

        ModKoneksi.ExecuteNonQuery(sqlOfferings)
        ModKoneksi.ExecuteNonQuery(sqlAnswers)

        Dim countObj = ModKoneksi.ExecuteScalar("SELECT COUNT(*) FROM course_offerings")
        If countObj IsNot Nothing AndAlso Convert.ToInt32(countObj) = 0 Then
            SeedDefaultOfferings()
        End If

        tablesChecked = True
    End Sub

    Private Sub SeedDefaultOfferings()
        Dim seeds = {
            (1, 1, 2L, "TIK302", "Manajemen Proyek TIK", "TI-3C", 3),
            (2, 1, 2L, "TIK301", "Pemrograman Visual", "TI-3C", 3),
            (3, 1, 2L, "TIK304", "Kecerdasan Buatan (AI)", "TI-3C", 3),
            (4, 2, 4L, "TMJ308", "Analisis dan Desain Sistem Informasi", "TMJ-3A", 3),
            (5, 2, 4L, "TMJ306", "Pemrograman Web Lanjut", "TMJ-3A", 3),
            (6, 3, 2L, "TMD301", "Pemrograman Visual", "TMD-3A", 3),
            (7, 4, 4L, "RKS302", "Keamanan Sistem Informasi", "RKS-3A", 3)
        }

        For Each s In seeds
            Try
                Dim p As New Dictionary(Of String, Object) From {
                    {"id", s.Item1},
                    {"prodi", s.Item2},
                    {"dosen", s.Item3},
                    {"kode", s.Item4},
                    {"nama", s.Item5},
                    {"kelas", s.Item6},
                    {"sks", s.Item7}
                }
                ModKoneksi.ExecuteNonQuery(
                    "INSERT IGNORE INTO course_offerings (id, study_program_id, dosen_id, kode_mk, nama_mk, kelas, sks, semester) " &
                    "VALUES (@id, @prodi, @dosen, @kode, @nama, @kelas, @sks, '2026/2027 Ganjil')", p)
            Catch
            End Try
        Next
    End Sub

    Public Function GetOfferingsForMahasiswa(mahasiswaId As Long, studyProgramId As Integer, semester As String) As List(Of CourseOfferingItem)
        EnsureTablesReady()

        Dim sql As String =
            "SELECT co.id, co.kode_mk, co.nama_mk, co.kelas, co.sks, co.semester, co.dosen_id, " &
            "       u.name AS dosen_name, dp.gelar_depan, dp.gelar_belakang, " &
            "       EXISTS(SELECT 1 FROM edom_answers a WHERE a.mahasiswa_id = @mhsId AND a.offering_id = co.id) AS sudah_terisi " &
            "FROM course_offerings co " &
            "INNER JOIN users u ON u.id = co.dosen_id " &
            "LEFT JOIN dosen_profiles dp ON dp.user_id = u.id " &
            "WHERE co.study_program_id = @prodiId AND co.semester = @semester " &
            "ORDER BY co.id ASC"

        Dim p As New Dictionary(Of String, Object) From {
            {"mhsId", mahasiswaId},
            {"prodiId", studyProgramId},
            {"semester", semester}
        }

        Dim dt As DataTable = ModKoneksi.ExecuteQuery(sql, p)
        Dim list As New List(Of CourseOfferingItem)()
        For Each r As DataRow In dt.Rows
            Dim nama As String = r("dosen_name").ToString().Trim()
            Dim gelarD As String = If(IsDBNull(r("gelar_depan")), "", r("gelar_depan").ToString().Trim())
            Dim gelarB As String = If(IsDBNull(r("gelar_belakang")), "", r("gelar_belakang").ToString().Trim())
            If Not String.IsNullOrEmpty(gelarD) Then nama = gelarD & " " & nama
            If Not String.IsNullOrEmpty(gelarB) Then nama = nama & ", " & gelarB

            list.Add(New CourseOfferingItem With {
                .OfferingId = Convert.ToInt32(r("id")),
                .KodeMk = r("kode_mk").ToString(),
                .NamaMk = r("nama_mk").ToString(),
                .Kelas = r("kelas").ToString(),
                .Sks = Convert.ToInt32(r("sks")),
                .Semester = r("semester").ToString(),
                .DosenId = Convert.ToInt64(r("dosen_id")),
                .DosenNama = nama,
                .SudahTerisi = (Convert.ToInt32(r("sudah_terisi")) = 1)
            })
        Next
        Return list
    End Function

    Public Function HasSubmitted(mahasiswaId As Long, offeringId As Integer) As Boolean
        EnsureTablesReady()
        Dim p As New Dictionary(Of String, Object) From {
            {"mhsId", mahasiswaId},
            {"offeringId", offeringId}
        }
        Dim cnt = ModKoneksi.ExecuteScalar(
            "SELECT COUNT(*) FROM edom_answers WHERE mahasiswa_id = @mhsId AND offering_id = @offeringId", p)
        Return cnt IsNot Nothing AndAlso Convert.ToInt32(cnt) > 0
    End Function

    Public Sub SaveAnswers(mahasiswaId As Long, offeringId As Integer, answers As List(Of AnswerInput))
        EnsureTablesReady()

        If mahasiswaId <= 0 Then Throw New InvalidOperationException("Sesi mahasiswa tidak valid.")
        If offeringId <= 0 Then Throw New InvalidOperationException("Mata kuliah tidak valid.")
        If answers Is Nothing OrElse answers.Count = 0 Then Throw New InvalidOperationException("Daftar jawaban kosong.")

        For Each ans In answers
            If ans.Nilai < 1 OrElse ans.Nilai > 3 Then
                Throw New ArgumentOutOfRangeException("nilai", "Setiap jawaban harus bernilai 1, 2, atau 3.")
            End If
            If ans.KategoriIndex < 1 OrElse ans.KategoriIndex > 4 Then
                Throw New ArgumentOutOfRangeException("kategori_index", "Kategori soal harus berada pada rentang 1 sampai 4.")
            End If
        Next

        If HasSubmitted(mahasiswaId, offeringId) Then
            Throw New InvalidOperationException("Kuisioner untuk mata kuliah ini sudah pernah Anda kirim.")
        End If

        ' Wrap all question inserts in one transaction so partial submissions cannot occur.
        Using conn As DbConnection = ModKoneksi.OpenConnection()
            Using tx As DbTransaction = conn.BeginTransaction()
                Try
                    Dim sql As String =
                        "INSERT INTO edom_answers (mahasiswa_id, offering_id, question_id, kategori_index, nilai) " &
                        "VALUES (@mhsId, @offeringId, @qId, @katIdx, @nilai)"

                    For Each ans In answers
                        Dim p As New Dictionary(Of String, Object) From {
                            {"mhsId", mahasiswaId},
                            {"offeringId", offeringId},
                            {"qId", ans.QuestionId},
                            {"katIdx", ans.KategoriIndex},
                            {"nilai", ans.Nilai}
                        }
                        Using cmd As DbCommand = ModKoneksi.CreateCommand(sql, conn, p)
                            cmd.Transaction = tx
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Public Function GetDosenEvaluations(dosenId As Long, Optional semester As String = "2026/2027 Ganjil") As List(Of DosenCourseSummary)
        EnsureTablesReady()

        Dim sql As String =
            "SELECT co.id, co.kode_mk, co.nama_mk, co.kelas, co.sks, " &
            "       COUNT(DISTINCT a.mahasiswa_id) AS responden_count, " &
            "       AVG(CASE WHEN a.kategori_index = 1 THEN a.nilai END) AS avg_ped, " &
            "       AVG(CASE WHEN a.kategori_index = 2 THEN a.nilai END) AS avg_pro, " &
            "       AVG(CASE WHEN a.kategori_index = 3 THEN a.nilai END) AS avg_kep, " &
            "       AVG(CASE WHEN a.kategori_index = 4 THEN a.nilai END) AS avg_sos " &
            "FROM course_offerings co " &
            "LEFT JOIN edom_answers a ON a.offering_id = co.id " &
            "WHERE co.dosen_id = @dosenId AND co.semester = @semester " &
            "GROUP BY co.id, co.kode_mk, co.nama_mk, co.kelas, co.sks " &
            "ORDER BY co.id ASC"

        Dim p As New Dictionary(Of String, Object) From {
            {"dosenId", dosenId},
            {"semester", semester}
        }

        Dim dt As DataTable = ModKoneksi.ExecuteQuery(sql, p)
        Dim list As New List(Of DosenCourseSummary)()
        For Each r As DataRow In dt.Rows
            list.Add(New DosenCourseSummary With {
                .OfferingId = Convert.ToInt32(r("id")),
                .KodeMk = r("kode_mk").ToString(),
                .NamaMk = r("nama_mk").ToString(),
                .Kelas = r("kelas").ToString(),
                .Sks = Convert.ToInt32(r("sks")),
                .RespondenCount = Convert.ToInt32(r("responden_count")),
                .AvgPedagogik = ToNullableDouble(r("avg_ped")),
                .AvgProfesional = ToNullableDouble(r("avg_pro")),
                .AvgKepribadian = ToNullableDouble(r("avg_kep")),
                .AvgSosial = ToNullableDouble(r("avg_sos"))
            })
        Next
        Return list
    End Function

    Public Function GetDosenOverallSummary(dosenId As Long, Optional semester As String = "2026/2027 Ganjil") As DosenCourseSummary
        EnsureTablesReady()

        Dim sql As String =
            "SELECT COUNT(DISTINCT CONCAT(a.mahasiswa_id, '-', a.offering_id)) AS total_evaluasi, " &
            "       AVG(CASE WHEN a.kategori_index = 1 THEN a.nilai END) AS avg_ped, " &
            "       AVG(CASE WHEN a.kategori_index = 2 THEN a.nilai END) AS avg_pro, " &
            "       AVG(CASE WHEN a.kategori_index = 3 THEN a.nilai END) AS avg_kep, " &
            "       AVG(CASE WHEN a.kategori_index = 4 THEN a.nilai END) AS avg_sos " &
            "FROM course_offerings co " &
            "INNER JOIN edom_answers a ON a.offering_id = co.id " &
            "WHERE co.dosen_id = @dosenId AND co.semester = @semester"

        Dim p As New Dictionary(Of String, Object) From {
            {"dosenId", dosenId},
            {"semester", semester}
        }

        Dim dt As DataTable = ModKoneksi.ExecuteQuery(sql, p)
        If dt.Rows.Count = 0 Then Return New DosenCourseSummary()

        Dim r = dt.Rows(0)
        Return New DosenCourseSummary With {
            .RespondenCount = Convert.ToInt32(r("total_evaluasi")),
            .AvgPedagogik = ToNullableDouble(r("avg_ped")),
            .AvgProfesional = ToNullableDouble(r("avg_pro")),
            .AvgKepribadian = ToNullableDouble(r("avg_kep")),
            .AvgSosial = ToNullableDouble(r("avg_sos"))
        }
    End Function

    Private Function ToNullableDouble(val As Object) As Double?
        If val Is Nothing OrElse IsDBNull(val) Then Return Nothing
        Return Convert.ToDouble(val)
    End Function

End Module
