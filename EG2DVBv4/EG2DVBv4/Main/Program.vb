#If WINDOWS Or XBOX Then
Module Program
    Sub Main(ByVal args As String())
        Using game As New Game1()
            Soundz.Sound.Initialize(game)
            game.Run()
        End Using
    End Sub
End Module
#End If