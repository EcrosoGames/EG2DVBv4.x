Public Class Options
    Inherits BaseScreen

    Private Entries As New List(Of MenuEntry)
    Private MenuSelect As Integer = 0

    Private MenuSize As New Vector2(250, 160)
    Private MenuPos As New Vector2(120, 80)

    Public Sub New()
        Name = "Options"
        State = ScreenState.Active

        ' ADD ENTRIES HERE
        AddEntry("Game Resolution: " & Globals.GameSize.X & "," & Globals.GameSize.Y, True)
        AddEntry("Vsync: " & Vsync.Synced, True)
        AddEntry("Back To Main", True)
        AddEntry("Hint: Press 'F1' to show Deug Screen", False)
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
        ' MENU UP
        If Input.KeyPressed(Keys.Up) Or Input.KeyPressed(Keys.W) Then
            MenuSelect -= 1
            If MenuSelect < 0 Then MenuSelect = Entries.Count - 1
            ' SKIP DISABLED ENTRIES
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect -= 1
                If MenuSelect < 0 Then MenuSelect = Entries.Count - 1
            Loop
        End If

        ' MENU DOWN
        If Input.KeyPressed(Keys.Down) Or Input.KeyPressed(Keys.S) Then
            MenuSelect += 1
            If MenuSelect > Entries.Count - 1 Then MenuSelect = 0
            ' SKIP DISABLED ENTRIES
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect += 1
                If MenuSelect > Entries.Count - 1 Then MenuSelect = 0
            Loop
        End If

        ' INVOKE MENU ITEM
        If Input.KeyPressed(Keys.Enter) Then
            Select Case MenuSelect
                Case 0
                    'Graphic Res
                    Select Case Globals.GameSize.X
                        Case 640 '480
                            Globals.GameSize = New Vector2(1280, 720)
                            Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
                            Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
                            Globals.Graphics.ApplyChanges()
                            Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, False, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents)
                            Entries(MenuSelect).Text = "Game Resolution: 1280,720"
                        Case 1280 '720
                            Globals.GameSize = New Vector2(1920, 1080)
                            Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
                            Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
                            Globals.Graphics.ApplyChanges()
                            Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, False, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents)
                            Entries(MenuSelect).Text = "Game Resolution: 1920,1080"
                        Case 1920 '1080
                            Globals.GameSize = New Vector2(640, 480)
                            Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
                            Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
                            Globals.Graphics.ApplyChanges()
                            Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, False, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents)
                            Entries(MenuSelect).Text = "Game Resolution: 640,480"
                    End Select
                Case 1
                    Vsync.Switch()
                    Entries(MenuSelect).Text = "Vsync: " & Vsync.Synced
                Case 2
                    ScreenManager.UnloadScreen("Options")
                    ScreenManager.AddScreen(New TitleScreen())
                    ScreenManager.AddScreen(New MainMenu())
            End Select
        End If
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()
        ' Draw Menu Graphics

        ' Draw Menu Options
        Dim MenuY As Integer = MenuPos.Y + 20
        For x = 0 To Entries.Count - 1
            If x = MenuSelect Then
                Globals.SpriteBatch.DrawString(Fonts.MotorWerk_16, Entries.Item(x).Text, New Vector2(Globals.GameSize.X / 2 - Fonts.MotorWerk_16.MeasureString(Entries.Item(x).Text).X / 2, Globals.GameSize.Y / 4 + MenuY), New Color(174, 0, 0))
            ElseIf Entries.Item(x).Enabled = True Then
                Globals.SpriteBatch.DrawString(Fonts.MotorWerk_16, Entries.Item(x).Text, New Vector2(Globals.GameSize.X / 2 - Fonts.MotorWerk_16.MeasureString(Entries.Item(x).Text).X / 2, Globals.GameSize.Y / 4 + MenuY), Color.White)
            Else
                Globals.SpriteBatch.DrawString(Fonts.MotorWerk_16, Entries.Item(x).Text, New Vector2(Globals.GameSize.X / 2 - Fonts.MotorWerk_16.MeasureString(Entries.Item(x).Text).X / 2, Globals.GameSize.Y / 4 + MenuY), Color.Gray)
            End If

            MenuY += 30
        Next
        Globals.SpriteBatch.End()
    End Sub
End Class
