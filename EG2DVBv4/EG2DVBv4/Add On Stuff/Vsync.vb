Public Class Vsync
    Public Shared Function Switch() As Boolean
        Game1.Change = True
        Return True
    End Function
End Class