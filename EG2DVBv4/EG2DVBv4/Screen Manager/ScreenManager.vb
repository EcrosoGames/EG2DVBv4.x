Public Enum ScreenState
    Active
    Shutdown
    Debug
    Paused
    Disabled
    Privilaged
End Enum
'Leaving a ton of comments so that I don't get confused every time I go back to this.
Public Class ScreenManager
    Public Shared Screens As New List(Of BaseScreen)
    Private Shared NewScreens As New List(Of BaseScreen)
    Private DebugScreen As New Debug()
    Public Sub New()
        AddScreen(DebugScreen) 'Starts up debug when game starts
    End Sub
    Public Sub Update()
        DebugScreen.Screens = "Screens: "
        Dim RemoveScreens As New List(Of BaseScreen)
        For Each FoundScreen As BaseScreen In Screens
            If FoundScreen.State = ScreenState.Shutdown Then
                RemoveScreens.Add(FoundScreen)
            Else
                Select Case FoundScreen.State
                    Case ScreenState.Active
                        DebugScreen.Screens += "+"
                    Case ScreenState.Shutdown 'Bug if can see this symbol/screen
                        DebugScreen.Screens += "-"
                    Case ScreenState.Debug
                        DebugScreen.Screens += "~"
                    Case ScreenState.Paused
                        DebugScreen.Screens += "="
                    Case ScreenState.Disabled
                        DebugScreen.Screens += "#"
                    Case ScreenState.Privilaged
                        DebugScreen.Screens += "*"
                End Select
                DebugScreen.Screens += FoundScreen.Name + ", "
                FoundScreen.Focused = False
            End If
        Next
        For Each FoundScreen As BaseScreen In RemoveScreens
            Screens.Remove(FoundScreen)
        Next
        For Each FoundScreen As BaseScreen In NewScreens
            Screens.Add(FoundScreen)
        Next
        NewScreens.Clear()
        Screens.Remove(DebugScreen) 'Don't remove this, for some reason it's needed??????
        Screens.Add(DebugScreen)
        If Screens.Count > 0 Then
            For i = Screens.Count - 1 To 0 Step -1
                If Screens(i).GrabFocus Then
                    Screens(i).Focused = True
                    DebugScreen.FocusScreen = "Focused Screen: " + Screens(i).Name
                    Exit For
                End If
            Next
        End If
        For Each FoundScreen As BaseScreen In Screens
            Select Case FoundScreen.State
                Case ScreenState.Active
                    If Debug_Console.GameInput Then FoundScreen.HandleInput()
                    FoundScreen.Update()
                Case ScreenState.Debug
                    If Debug_Console.GameInput Then FoundScreen.HandleInput()
                    FoundScreen.Update()
                Case ScreenState.Privilaged
                    If Debug_Console.GameInput Then FoundScreen.HandleInput()
                    FoundScreen.Update()
            End Select
        Next
    End Sub
    Public Sub Draw()
        For Each FoundScreen As BaseScreen In Screens
            Select Case FoundScreen.State
                Case ScreenState.Active
                    FoundScreen.Draw()
                Case ScreenState.Debug
                    If Globals.Debugging Then FoundScreen.Draw()
                Case ScreenState.Paused
                    FoundScreen.Draw()
                Case ScreenState.Privilaged
                    FoundScreen.Draw()
            End Select
        Next
    End Sub
    Public Shared Sub AddScreen(screen As BaseScreen)
        NewScreens.Add(screen)
    End Sub
    Public Shared Sub RemoveScreen(screen As String)
        For Each FoundScreen As BaseScreen In Screens
            If FoundScreen.Name = screen Then
                FoundScreen.remove()
                Exit For
            End If
        Next
    End Sub
    Public Shared Function Find(Optional Def As String = Nothing) As BaseScreen
        For Each FoundScreen As BaseScreen In Screens
            If Def = FoundScreen.Name Then Return FoundScreen
            Exit For
        Next
    End Function
    Public Shared Sub StateChange(Optional Screens() As BaseScreen = Nothing, Optional state As ScreenState = Nothing, Optional permission As Integer = -1)
        If state = ScreenState.Shutdown Then
            For Each FoundScreen As BaseScreen In Screens
                If permission <> -1 Then
                    If FoundScreen.Permission <= permission Then 'for doing all screens, but making sure important screens are not changed
                        FoundScreen.remove()
                    End If
                Else
                    FoundScreen.remove()
                End If
            Next
        Else
            For Each FoundScreen As BaseScreen In Screens
                For q As Integer = 0 To Screens.Length - 1
                    If FoundScreen.Name = Screens(q).Name Then
                        If permission <> -1 Then
                            If FoundScreen.Permission <= permission Then 'for doing all screens, but making sure important screens are not changed
                                FoundScreen.State = state
                            End If
                        Else
                            FoundScreen.State = state ' changing individual screen states
                        End If
                    End If
                Next
            Next
        End If
    End Sub
End Class