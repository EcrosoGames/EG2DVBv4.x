Public Class MusicKeeper
    Public Shared mooseke As SoundEffectInstance
    Public Shared Sub Play(ByVal musik As SoundEffect, Optional ByVal looped As Boolean = True, Optional ByVal pitch As Single = 0, Optional ByVal vol As Single = 1)
        mooseke = musik.CreateInstance()
        mooseke.IsLooped = looped
        mooseke.Pitch = pitch
        mooseke.Volume = vol
        mooseke.Play()
    End Sub
    Public Shared Sub Edit(Optional ByVal state As Integer = 1, Optional ByVal vol As Single = 1, Optional ByVal pitch As Single = 0)
        mooseke.Pitch = pitch
        mooseke.Volume = vol
        Select Case state
            Case 0
                mooseke.Resume()
            Case 1
                mooseke.Pause()
            Case 2
                mooseke.Stop()
        End Select
    End Sub
End Class