''' <summary>
''' Modul statis global untuk menyimpan data sesi pengguna yang sedang aktif di aplikasi EDOM.
''' </summary>
Public Module UserSession

    Public Property UserId As Long = 0
    Public Property Nama As String = String.Empty
    Public Property Email As String = String.Empty
    Public Property Role As String = String.Empty ' "admin", "dosen", "mahasiswa"
    Public Property StudyProgramId As Integer = 0
    Public Property NamaProdi As String = String.Empty
    Public Property ProdiCode As String = String.Empty

    ' Informasi Tambahan Profil
    Public Property NIDN As String = String.Empty
    Public Property GelarDepan As String = String.Empty
    Public Property GelarBelakang As String = String.Empty
    Public Property NIM As String = String.Empty
    Public Property Angkatan As Integer = 0

    ''' <summary>
    ''' Memeriksa apakah ada user yang sedang login.
    ''' </summary>
    Public ReadOnly Property IsLoggedIn As Boolean
        Get
            Return UserId > 0 AndAlso Not String.IsNullOrWhiteSpace(Role)
        End Get
    End Property

    ''' <summary>
    ''' Mendapatkan inisial nama untuk avatar (maksimal 2 huruf).
    ''' </summary>
    Public Function GetInitials() As String
        If String.IsNullOrWhiteSpace(Nama) Then Return "US"
        Dim parts = Nama.Trim().Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        If parts.Length = 1 Then
            Return parts(0).Substring(0, Math.Min(2, parts(0).Length)).ToUpper()
        Else
            Return (parts(0).Substring(0, 1) & parts(1).Substring(0, 1)).ToUpper()
        End If
    End Function

    ''' <summary>
    ''' Mendapatkan nama lengkap dengan gelar depan dan belakang (khusus dosen).
    ''' </summary>
    Public Function GetNamaLengkapGelar() As String
        Dim hasil As String = Nama
        If Not String.IsNullOrWhiteSpace(GelarDepan) Then
            hasil = GelarDepan.Trim() & " " & hasil
        End If
        If Not String.IsNullOrWhiteSpace(GelarBelakang) Then
            hasil = hasil & ", " & GelarBelakang.Trim()
        End If
        Return hasil
    End Function

    ''' <summary>
    ''' Mengosongkan seluruh data session (digunakan saat logout).
    ''' </summary>
    Public Sub Clear()
        UserId = 0
        Nama = String.Empty
        Email = String.Empty
        Role = String.Empty
        StudyProgramId = 0
        NamaProdi = String.Empty
        ProdiCode = String.Empty
        NIDN = String.Empty
        GelarDepan = String.Empty
        GelarBelakang = String.Empty
        NIM = String.Empty
        Angkatan = 0
    End Sub

End Module
