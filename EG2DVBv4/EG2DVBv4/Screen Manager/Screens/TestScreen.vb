Public Class TestScreen
    Inherits BaseScreen
    Private TestText As String = "We can't have nice things!"
    Private TextPos As New Vector2(20, 195)
    Private IsAlive As Boolean = True
    Private LifeSpan As Double = 0
    Public Sub New()
        Name = "TestScreen"
    End Sub
    Public Overrides Sub Update()
        If LifeSpan < 5000 Then
            LifeSpan += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        Else
            IsAlive = False
        End If

        If IsAlive = False Then
            Me.State = ScreenState.ShutDown
        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, TestText, TextPos, Color.Red)
        Globals.SpriteBatch.End()
    End Sub
End Class
