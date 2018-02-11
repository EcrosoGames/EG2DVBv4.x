Public MustInherit Class BaseScreen
    Public Name As String = ""
    Public State As ScreenState = ScreenState.Active
    Public Position As Single
    Public Focused As Boolean = False
    Public GrabFocus As Boolean = True
    Public Permission As Integer = 1
    Public Overridable Sub HandleInput()
    End Sub
    Public Overridable Sub Update()
    End Sub
    Public Overridable Sub Draw()
    End Sub
    Public Overridable Sub remove()
        State = ScreenState.Shutdown
    End Sub
End Class