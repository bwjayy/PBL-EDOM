Imports System.Data
Imports System.Data.Common
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Imports Microsoft.Data.SqlClient

''' <summary>
''' Modul Koneksi Database ADO.NET yang mendukung MySQL dan SQL Server secara modular.
''' Default menggunakan MySQL (cocok untuk XAMPP/MariaDB di lingkungan kampus).
''' </summary>
Public Module ModKoneksi

    Public Enum DatabaseType
        MySQL
        SQLServer
    End Enum

    Public CurrentDbProvider As DatabaseType = DatabaseType.MySQL

    ' Konfigurasi MySQL (XAMPP / MariaDB di localhost)
    Public MySqlHost As String = "127.0.0.1"
    Public MySqlPort As Integer = 3307 ' Port XAMPP terpasang (fallback otomatis ke 3306 jika diperlukan)
    Public MySqlDatabase As String = "edom_pbl"
    Public MySqlUser As String = "root"
    Public MySqlPassword As String = ""

    ' Konfigurasi SQL Server (LocalDB / SSMS)
    Public SqlServerHost As String = "(localdb)\MSSQLLocalDB"
    Public SqlServerDatabase As String = "edom_pbl"
    Public SqlServerIntegratedSecurity As Boolean = True
    Public SqlServerUser As String = "sa"
    Public SqlServerPassword As String = ""

    ''' <summary>
    ''' Menghasilkan Connection String sesuai provider yang sedang dipilih.
    ''' </summary>
    Public Function GetConnectionString() As String
        Select Case CurrentDbProvider
            Case DatabaseType.MySQL
                Dim builder As New MySqlConnectionStringBuilder() With {
                    .Server = MySqlHost,
                    .Port = CUInt(MySqlPort),
                    .Database = MySqlDatabase,
                    .UserID = MySqlUser,
                    .Password = MySqlPassword,
                    .SslMode = MySqlSslMode.Disabled,
                    .CharacterSet = "utf8mb4",
                    .ConnectionTimeout = 5
                }
                Return builder.ConnectionString

            Case DatabaseType.SQLServer
                Dim builder As New SqlConnectionStringBuilder() With {
                    .DataSource = SqlServerHost,
                    .InitialCatalog = SqlServerDatabase,
                    .IntegratedSecurity = SqlServerIntegratedSecurity,
                    .TrustServerCertificate = True,
                    .ConnectTimeout = 5
                }
                If Not SqlServerIntegratedSecurity Then
                    builder.UserID = SqlServerUser
                    builder.Password = SqlServerPassword
                End If
                Return builder.ConnectionString

            Case Else
                Throw New NotSupportedException("Provider database tidak didukung.")
        End Select
    End Function

    ''' <summary>
    ''' Membuat instance DbConnection baru (belum dibuka).
    ''' </summary>
    Public Function GetNewConnection() As DbConnection
        Select Case CurrentDbProvider
            Case DatabaseType.MySQL
                Return New MySqlConnection(GetConnectionString())
            Case DatabaseType.SQLServer
                Return New SqlConnection(GetConnectionString())
            Case Else
                Throw New NotSupportedException("Provider database tidak didukung.")
        End Select
    End Function

    ''' <summary>
    ''' Membuat dan membuka koneksi baru dengan toleransi port fallback (3307 & 3306) untuk MySQL XAMPP.
    ''' </summary>
    Public Function OpenConnection() As DbConnection
        If CurrentDbProvider = DatabaseType.MySQL Then
            Try
                Dim conn As DbConnection = GetNewConnection()
                conn.Open()
                Return conn
            Catch ex As Exception
                ' Coba port alternatif (misal port 3306 jika 3307 gagal, atau sebaliknya)
                Dim altPort As Integer = If(MySqlPort = 3307, 3306, 3307)
                Dim origPort As Integer = MySqlPort
                MySqlPort = altPort
                Try
                    Dim connAlt As DbConnection = GetNewConnection()
                    connAlt.Open()
                    Return connAlt
                Catch
                    MySqlPort = origPort
                    Throw
                End Try
            End Try
        Else
            Dim conn As DbConnection = GetNewConnection()
            conn.Open()
            Return conn
        End If
    End Function

    ''' <summary>
    ''' Menguji apakah koneksi ke database berhasil.
    ''' </summary>
    Public Function TestConnection(ByRef errorMessage As String) As Boolean
        Try
            Using conn As DbConnection = OpenConnection()
                errorMessage = String.Empty
                Return True
            End Using
        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Membuat command dan mengikat parameter secara aman untuk mencegah SQL Injection.
    ''' </summary>
    Public Function CreateCommand(query As String, conn As DbConnection, Optional parameters As Dictionary(Of String, Object) = Nothing) As DbCommand
        Dim cmd As DbCommand = conn.CreateCommand()
        cmd.CommandText = query

        If parameters IsNot Nothing Then
            For Each kvp In parameters
                Dim paramName As String = kvp.Key
                If Not paramName.StartsWith("@") Then paramName = "@" & paramName

                Dim param As DbParameter = cmd.CreateParameter()
                param.ParameterName = paramName
                param.Value = If(kvp.Value, DBNull.Value)
                cmd.Parameters.Add(param)
            Next
        End If

        Return cmd
    End Function

    ''' <summary>
    ''' Mengeksekusi query SELECT dan mengembalikan hasilnya dalam bentuk DataTable.
    ''' </summary>
    Public Function ExecuteQuery(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim dt As New DataTable()
        Using conn As DbConnection = OpenConnection()
            Using cmd As DbCommand = CreateCommand(query, conn, parameters)
                Dim adapter As DbDataAdapter = Nothing
                If CurrentDbProvider = DatabaseType.MySQL Then
                    adapter = New MySqlDataAdapter(CType(cmd, MySqlCommand))
                Else
                    adapter = New SqlDataAdapter(CType(cmd, SqlCommand))
                End If
                Using adapter
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Mengeksekusi query INSERT, UPDATE, atau DELETE dan mengembalikan jumlah baris terpengaruh.
    ''' </summary>
    Public Function ExecuteNonQuery(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Integer
        Using conn As DbConnection = OpenConnection()
            Using cmd As DbCommand = CreateCommand(query, conn, parameters)
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Mengeksekusi query yang menghasilkan nilai skalar (satu nilai pada baris 1, kolom 1).
    ''' </summary>
    Public Function ExecuteScalar(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Object
        Using conn As DbConnection = OpenConnection()
            Using cmd As DbCommand = CreateCommand(query, conn, parameters)
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Fungsi bantu untuk memverifikasi kecocokan password (mendukung Plaintext dan SHA-256).
    ''' </summary>
    Public Function VerifyPassword(inputPassword As String, storedHashOrPlain As String) As Boolean
        If String.IsNullOrEmpty(inputPassword) OrElse String.IsNullOrEmpty(storedHashOrPlain) Then
            Return False
        End If

        If inputPassword = storedHashOrPlain Then
            Return True
        End If

        Dim inputHash As String = HashSHA256(inputPassword)
        If String.Equals(inputHash, storedHashOrPlain, StringComparison.OrdinalIgnoreCase) Then
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' Menghasilkan hash SHA-256 dalam bentuk string heksadesimal lowercase.
    ''' </summary>
    Public Function HashSHA256(text As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(text))
            Dim sb As New StringBuilder()
            For Each b As Byte In bytes
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString()
        End Using
    End Function

End Module
