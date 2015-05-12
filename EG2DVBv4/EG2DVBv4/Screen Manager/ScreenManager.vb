Public Enum ScreenState
    Active
    ShutDown
    Hidden
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
            If Globals.WindowFocused Then
                FoundScreen.HandleInput()
            End If
            FoundScreen.Update()
        Next
    End Sub
    Public Sub Draw()
        For Each FoundScreen As BaseScreen In Screens
            If FoundScreen.State = ScreenState.Active Then
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
End Class