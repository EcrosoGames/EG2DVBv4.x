Public Class MainMenu
    Inherits BaseScreen
    Private Entries As New List(Of MenuEntry)
    Private MenuSelect As Integer = 0
    Private MenuSize As New Vector2(250, 160)
    Private MenuPos As New Vector2(120, 80)
    Private Music As SoundEffect
    Public Sub New()
        Name = "MainMenu"
        State = ScreenState.Active
        AddEntry("New Game", True)
        AddEntry("Options", True)
        AddEntry("Credits", True)
        AddEntry("Quit Game", True)
    End Sub
    Public Sub AddEntry(text As String, enabled As Boolean)
        Dim Entry As MenuEntry
        Entry = New MenuEntry
        With Entry
            .Text = text
            .Enabled = enabled
        End With
        Entries.Add(Entry)
    End Sub
    Public Overrides Sub HandleInput()
        If Input.KeyPressed(Keys.Up) Or Input.KeyPressed(Keys.W) Then
            MenuSelect -= 1
            If MenuSelect < 0 Then MenuSelect = Entries.Count - 1
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect -= 1
                If MenuSelect < 0 Then MenuSelect = Entries.Count - 1
            Loop
        End If
        If Input.KeyPressed(Keys.Down) Or Input.KeyPressed(Keys.S) Then
            MenuSelect += 1
            If MenuSelect > Entries.Count - 1 Then MenuSelect = 0
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect += 1
                If MenuSelect > Entries.Count - 1 Then MenuSelect = 0
            Loop
        End If
        If Input.KeyPressed(Keys.Enter) Then
            Select Case MenuSelect
                Case 0
                    ScreenManager.UnloadScreen("TitleScreen")
                    ScreenManager.UnloadScreen("MainMenu")
                    ScreenManager.AddScreen(New Default_Screen())
                Case 1
                    ScreenManager.UnloadScreen("TitleScreen")
                    ScreenManager.UnloadScreen("MainMenu")
                    ScreenManager.AddScreen(New Options())
                Case 2
                    ScreenManager.UnloadScreen("TitleScreen")
                    ScreenManager.UnloadScreen("MainMenu")
                    ScreenManager.AddScreen(New Credits())
                Case 3
                    End
            End Select
        End If
        If Input.KeyPressed(Keys.T) Then
            Music.Play(1.0F, -0.15F, 0.0F)
        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()
        Dim MenuY As Integer = MenuPos.Y + 20
        For x = 0 To Entries.Count - 1
            If x = MenuSelect Then
                Globals.SpriteBatch.DrawString(Fonts.MotorWerk_16, Entries.Item(x).Text, New Vector2(Globals.GameSize.X / 2 - Fonts.MotorWerk_16.MeasureString(Entries.Item(x).Text).X / 2, Globals.GameSize.Y / 4 + MenuY), New Color(255, 0, 0))
            ElseIf Entries.Item(x).Enabled = True Then
                Globals.SpriteBatch.DrawString(Fonts.MotorWerk_16, Entries.Item(x).Text, New Vector2(Globals.GameSize.X / 2 - Fonts.MotorWerk_16.MeasureString(Entries.Item(x).Text).X / 2, Globals.GameSize.Y / 4 + MenuY), Color.White)
            Else
                Globals.SpriteBatch.DrawString(Fonts.MotorWerk_16, Entries.Item(x).Text, New Vector2(Globals.GameSize.X / 2 - Fonts.MotorWerk_16.MeasureString(Entries.Item(x).Text).X / 2, Globals.GameSize.Y / 4 + MenuY), Color.Gray)
            End If
            MenuY += 30
        Next
        Globals.SpriteBatch.DrawString(Fonts.MotorWerk_16, GameVersion.Vers(), New Vector2(0, Globals.GameSize.Y - Fonts.MotorWerk_16.MeasureString(GameVersion.Vers()).Y), New Color(255, 0, 0))
        Globals.SpriteBatch.End()
    End Sub
End Class