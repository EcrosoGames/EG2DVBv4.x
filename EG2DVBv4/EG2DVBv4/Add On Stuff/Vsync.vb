Public Class Vsync
    Public Shared Synced As Boolean = True
    Public Shared Function Switch() As Boolean
        If Synced Then
            Synced = False
        Else
            Synced = True
        End If
        Game1.Change = True
        Return True
    End Function
End Class