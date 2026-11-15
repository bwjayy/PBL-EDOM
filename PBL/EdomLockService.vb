Imports System.Data

''' <summary>Pengaturan penguncian EDOM yang disimpan per program studi.</summary>
Public Module EdomLockService

    Public Function IsLocked(studyProgramId As Integer) As Boolean
        If studyProgramId <= 0 Then Throw New InvalidOperationException("Program studi pengguna belum ditentukan.")

        Dim parameters As New Dictionary(Of String, Object) From {{"studyProgramId", studyProgramId}}
        Dim value As Object = ModKoneksi.ExecuteScalar(
            "SELECT is_locked FROM edom_settings WHERE study_program_id = @studyProgramId", parameters)

        Return value IsNot Nothing AndAlso value IsNot DBNull.Value AndAlso Convert.ToBoolean(value)
    End Function

    Public Sub SetLocked(studyProgramId As Integer, locked As Boolean)
        If studyProgramId <= 0 Then Throw New InvalidOperationException("Program studi admin belum ditentukan.")

        Dim parameters As New Dictionary(Of String, Object) From {
            {"studyProgramId", studyProgramId},
            {"isLocked", If(locked, 1, 0)}
        }

        Dim changed As Integer = ModKoneksi.ExecuteNonQuery(
            "UPDATE edom_settings SET is_locked = @isLocked, updated_at = CURRENT_TIMESTAMP WHERE study_program_id = @studyProgramId", parameters)
        If changed = 0 Then
            ModKoneksi.ExecuteNonQuery(
                "INSERT INTO edom_settings (study_program_id, is_locked) VALUES (@studyProgramId, @isLocked)", parameters)
        End If
    End Sub
End Module
