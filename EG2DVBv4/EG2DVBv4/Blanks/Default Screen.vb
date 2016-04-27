Public Class Default_Screen
    Inherits BaseScreen
    Private AniTime As Double = 0
    Dim Antitime As Integer = 0
    Public Sub New()
        Name = "Screen"
        State = ScreenState.Active
    End Sub
    Public Overrides Sub HandleInput()

    End Sub
    Public Overrides Sub Update()
        'Example of how to control your updates
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 255 Then
            AniTime = 0
            'Please use this so that when people turn off vsync the whole thing doesn't go to hell
        End If
        Antitime = AniTime * 2
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        Globals.SpriteBatch.End()
    End Sub
End Class