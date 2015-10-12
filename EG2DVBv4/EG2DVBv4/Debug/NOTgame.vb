Public Class NOTgame
    Inherits BaseScreen
    Private Music As SoundEffect
    Private AniTime As Double = 0
    Dim Antitime As Integer = 0
    Public Sub New()
        Name = "MainMenu"
        State = ScreenState.Active
        Music = Soundz.Sound.LoadSound("Sound")
        ScreenManager.AddScreen(New TextHandler)
    End Sub
    Public Overrides Sub HandleInput()
        If Input.KeyPressed(Keys.T) Then
            TextHandler.SetText("NOPE.AVI0123", 10, 0, 0, Color.Black, Color.White, 100)
            TextHandler.ReadText(True, 50)
            MusicKeeper.Plai(Music)
        End If
        If Input.KeyPressed(Keys.Y) Then
            TextHandler.SetText("This is a test of the automatic text handler!", 2, 30, 500, Color.Gold, Color.Gray, 50)
            TextHandler.ReadText(True, 10)
            MusicKeeper.Edeet(1)
        End If
        If Input.KeyPressed(Keys.U) Then
            MusicKeeper.Edeet(0)
        End If
    End Sub
    Public Overrides Sub Update()
        'Example of how to control your updates
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 255 Then
            AniTime = 0

        End If
        Antitime = AniTime * 2
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        Globals.SpriteBatch.End()
    End Sub
End Class