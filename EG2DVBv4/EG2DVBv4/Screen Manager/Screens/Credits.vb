Public Class Credits
    Inherits BaseScreen

    Private Entries As New List(Of MenuEntry)
    Private MenuSelect As Integer = 0

    Private MenuSize As New Vector2(250, 160)
    Private MenuPos As New Vector2(120, 80)

    Public Sub New()
        Name = "Credits"
        State = ScreenState.Active

        ' ADD ENTRIES HERE
        AddEntry("Back To Main", True)
        AddEntry("Engine By: Brandon Ecroso", False)
        AddEntry("Engine Based off of Aardaerimus D'Aritonyss' design", False)
        AddEntry("Textures By: Brandon Ecroso", False)
        AddEntry("Language: VB.NET (XNA 4.0 framework)", False)
        AddEntry("Version: EG2DVB ver. " & Engine_Version.Vers, False)
        AddEntry("Game by: Author", False)
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
        ' INVOKE MENU ITEM
        If Input.KeyPressed(Keys.Enter) Then
            Select Case MenuSelect
                Case 0
                    ScreenManager.UnloadScreen("Credits")
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
