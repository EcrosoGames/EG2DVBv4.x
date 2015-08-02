Public Class MusicKeeper
    Public Shared Timepassed As Single
    Public Shared Timelimit As Single
    Public Shared Done As Boolean = False
    Public Shared Sub Keeptrack()
        Timepassed += Globals.GameTime.ElapsedGameTime.TotalSeconds
        If Timepassed >= Timelimit Then
            Done = True
        End If
    End Sub
End Class