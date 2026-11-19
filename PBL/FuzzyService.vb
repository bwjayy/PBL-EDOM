Imports System.Globalization
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports CliWrap
Imports CliWrap.Buffered
Imports Newtonsoft.Json.Linq

Public Class FuzzyResult
    Public Property Skor As Double
    Public Property Predikat As String = String.Empty
    Public Property MuKurang As Double
    Public Property MuCukup As Double
    Public Property MuBaik As Double
End Class

Public Module FuzzyService

    Public Async Function HitungAsync(ped As Double, pro As Double, kep As Double, sos As Double) As Task(Of FuzzyResult)
        ValidateRange("Pedagogik", ped)
        ValidateRange("Profesional", pro)
        ValidateRange("Kepribadian", kep)
        ValidateRange("Sosial", sos)

        Dim scriptPath As String = Path.Combine(Application.StartupPath, "fuzzy_edom.py")
        If Not File.Exists(scriptPath) Then
            Throw New FileNotFoundException("File 'fuzzy_edom.py' tidak ditemukan di: " & scriptPath, scriptPath)
        End If

        ' Use InvariantCulture so Indonesian locale commas do not break Python float parsing.
        Dim args = {
            scriptPath,
            ped.ToString(CultureInfo.InvariantCulture),
            pro.ToString(CultureInfo.InvariantCulture),
            kep.ToString(CultureInfo.InvariantCulture),
            sos.ToString(CultureInfo.InvariantCulture)
        }

        ' shortcut: invokes "python" from PATH; configure executable path if target machines use "py" or a bundled interpreter.
        Dim result = Await Cli.Wrap("python") _
            .WithArguments(args) _
            .WithValidation(CommandResultValidation.None) _
            .ExecuteBufferedAsync()

        If result.ExitCode <> 0 Then
            Dim errMsg As String = If(String.IsNullOrWhiteSpace(result.StandardError), "Proses Python gagal dengan kode " & result.ExitCode.ToString(), result.StandardError.Trim())
            Throw New InvalidOperationException("Python Fuzzy Error: " & errMsg)
        End If

        Dim jsonOutput As String = result.StandardOutput.Trim()
        If String.IsNullOrEmpty(jsonOutput) Then
            Throw New InvalidOperationException("Python Fuzzy tidak mengembalikan output JSON.")
        End If

        Dim json As JObject = JObject.Parse(jsonOutput)
        Dim agregasi As JToken = json("agregasi")

        Return New FuzzyResult With {
            .Skor = json("skor").Value(Of Double)(),
            .Predikat = json("predikat").Value(Of String)(),
            .MuKurang = If(agregasi IsNot Nothing, agregasi("kurang").Value(Of Double)(), 0.0),
            .MuCukup = If(agregasi IsNot Nothing, agregasi("cukup").Value(Of Double)(), 0.0),
            .MuBaik = If(agregasi IsNot Nothing, agregasi("baik").Value(Of Double)(), 0.0)
        }
    End Function

    Private Sub ValidateRange(nama As String, nilai As Double)
        If Double.IsNaN(nilai) OrElse Double.IsInfinity(nilai) OrElse nilai < 1.0 OrElse nilai > 3.0 Then
            Throw New ArgumentOutOfRangeException(nama, $"Nilai rata-rata {nama} harus berada pada rentang 1.0 sampai 3.0.")
        End If
    End Sub

End Module
