Public Enum ScreenState
    Active
    ShutDown
    Hidden
    Special
End Enum
Public Class ScreenManager
    Private Shared Screens As New List(Of BaseScreen)
    Private Shared NewScreens As New List(Of BaseScreen)
    Private DebugScreen As New Debug()
    Public Sub New()
        AddScreen(DebugScreen)
    End Sub
    Public Sub Update()
        DebugScreen.Screens = "Screens: "
        Dim RemoveScreens As New List(Of BaseScreen)
        For Each FoundScreen As BaseScreen In Screens
            If FoundScreen.State = ScreenState.ShutDown Then
                RemoveScreens.Add(FoundScreen)
            Else
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
        Screens.Remove(DebugScreen)
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
            If Globals.WindowFocused And FoundScreen.State = ScreenState.Active Then
                FoundScreen.HandleInput()
            ElseIf Globals.WindowFocused And FoundScreen.State = ScreenState.Special Then
                FoundScreen.HandleInput()
            End If
            If FoundScreen.State = ScreenState.Active Or FoundScreen.State = ScreenState.Special Then
                FoundScreen.Update()
            End If
        Next
    End Sub
    Public Sub Draw()
        For Each FoundScreen As BaseScreen In Screens
            If Not FoundScreen.Name = "Debug" And FoundScreen.State = ScreenState.Active Then
                FoundScreen.Draw()
            End If
        Next
        For Each FoundScreen As BaseScreen In Screens
            If FoundScreen.Name = "Debug" And FoundScreen.State = ScreenState.Active Then
                FoundScreen.Draw()
            End If
        Next
    End Sub
    Public Shared Sub AddScreen(screen As BaseScreen)
        NewScreens.Add(screen)
    End Sub
    Public Shared Sub UnloadScreen(screen As String)
        For Each FoundScreen As BaseScreen In Screens
            If FoundScreen.Name = screen Then
                FoundScreen.Unload()
                Exit For
            End If
        Next
    End Sub
    Public Shared Sub PauseAll(Optional exempt As String = "HELP")
        For Each FoundScreen As BaseScreen In Screens
            If Not FoundScreen.Name = "Debug" And Globals.WindowFocused And FoundScreen.State = ScreenState.Active And FoundScreen.Name <> exempt Then
                FoundScreen.State = ScreenState.Hidden
            End If
            FoundScreen.Update()
        Next
    End Sub
    Public Shared Function Find(Optional Def As String = "Naming") As Boolean
        For Each FoundScreen As BaseScreen In Screens
            If FoundScreen.Name = Def Then
                Return True
            Else
                Return False
            End If
        Next
    End Function
    Public Shared Sub KillAll(Optional exempt As String = "Game Over")
        For Each FoundScreen As BaseScreen In Screens
            If Not FoundScreen.Name = "Debug" And Globals.WindowFocused And FoundScreen.State = ScreenState.Active And FoundScreen.Name <> exempt Then
                FoundScreen.Unload()
            End If
            FoundScreen.Update()
        Next
    End Sub
    Public Shared Sub ResumeAll()
        If Screens.Count > 0 Then
            For i = Screens.Count - 1 To 0 Step -1
                If Screens(i).GrabFocus Then
                    Screens(i).Focused = True
                    Exit For
                End If
            Next
        End If
        For Each FoundScreen As BaseScreen In Screens
            If Globals.WindowFocused And FoundScreen.State = ScreenState.Hidden Then
                FoundScreen.State = ScreenState.Active
            End If
            FoundScreen.Update()
        Next
    End Sub
End Class