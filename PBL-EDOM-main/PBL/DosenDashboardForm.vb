Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class DosenDashboardForm

    Private Sub DosenDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UserSession.IsLoggedIn Then
            lblSidebarUserName.Text = "Dosen"
            lblSidebarUserRole.Text = "Dosen EDOM"
            lblBadgeProdi.Text = "Politeknik Negeri Jakarta"
        End If

        If Me.GetType().GetMethod("ApplyControlRegions") IsNot Nothing Then
            Me.GetType().GetMethod("ApplyControlRegions").Invoke(Me, Nothing)
        End If

        LoadGrafikEdom()
    End Sub

    Private Sub LoadGrafikEdom()
        Try
            If ChartHasilEdom.Series.IndexOf("Series1") >= 0 Then
                ChartHasilEdom.Series("Series1").Points.Clear()
            End If

            Using conn As New MySqlConnection("server=localhost;port=3307;database=edom_pbl;uid=root;pwd=;")
                conn.Open()

                Dim idDosen As Integer = 2 ' Sesuai ID dosen Bambang Warsuta

                Dim query As String = "SELECT CONCAT(m.nama_matkul, ' - ', k.nama_kategori) AS label_mk, AVG(j.skor) AS rata_rata " &
                                      "FROM jawaban_edom j " &
                                      "JOIN pertanyaan p ON j.id_pertanyaan = p.id " &
                                      "JOIN kategori k ON p.id_kategori = k.id " &
                                      "JOIN matakuliah m ON j.id_matkul = m.id " &
                                      "WHERE j.id_dosen = @idDosen " &
                                      "GROUP BY m.id, k.id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idDosen", idDosen)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim labelMatkulKat As String = reader("label_mk").ToString()
                            Dim nilai As Double = Convert.ToDouble(reader("rata_rata"))

                            ChartHasilEdom.Series("Series1").Points.AddXY(labelMatkulKat, nilai)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat grafik EDOM: " & ex.Message, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ChartHasilEdom_Click(sender As Object, e As EventArgs) Handles ChartHasilEdom.Click

    End Sub
End Class