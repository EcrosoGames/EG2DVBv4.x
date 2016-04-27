Public Class GameVersion
    'Info
    Public Shared ReadOnly Name As String = "TITLE!"
    Public Shared ReadOnly Author As String = "Brandon Ecroso"
    Public Shared ReadOnly Artist As String = "Brandon Ecroso"
    Public Shared ReadOnly Programmer As String = "Brandon Ecroso"
    Public Shared ReadOnly Musician As String = "Brandon Ecroso"

    'Version
    Public Shared ReadOnly Release As Integer = 0
    Public Shared ReadOnly Update As Integer = 0
    Public Shared ReadOnly Snapshot As Integer = 0
    Public Shared ReadOnly DevStatus As Char = "I"
    Public Shared ReadOnly ReleaseDate As String = "DD/MM/YYYY"
    'I = Indev(In Development)
    'B = BETA
    'A = ALPHA
    'O = Official (Or finished)
    Public Shared Function Vers() As String
        Return "Version: " & Release & "." & Update & "." & Snapshot & "_" & DevStatus
    End Function
End Class