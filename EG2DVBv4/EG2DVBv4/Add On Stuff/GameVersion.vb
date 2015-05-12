Public Class GameVersion
    Public Shared ReadOnly Release As Integer = 0
    Public Shared ReadOnly Update As Integer = 0
    Public Shared ReadOnly Snapshot As Integer = 0
    Public Shared ReadOnly DevStatus As Char = "I"
    'I = Indev(In Development)
    'B = BETA
    'A = ALPHA
    'O = Official (Or finished)
    Public Shared Function Vers() As String
        Return "Version: " & Release & "." & Update & "." & Snapshot & "_" & DevStatus
    End Function
End Class