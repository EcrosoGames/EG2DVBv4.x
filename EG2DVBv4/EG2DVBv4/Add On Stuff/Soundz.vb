Namespace Soundz
    Public Class Sound
        Private Shared Sounds As Dictionary(Of String, SoundEffect)
        Private Shared game As Game
        Public Shared Sub Initialize(game As Game)
            If Sound.game Is Nothing Then Sound.game = game
            If Sounds Is Nothing Then Sounds = New Dictionary(Of String, SoundEffect)
        End Sub
#Region "Sounds"
        Public Shared Function LoadSound(Name As String) As SoundEffect
            If Not Sounds.ContainsKey(Name) Then
                Sounds.Add(Name, game.Content.Load(Of SoundEffect)(String.Format("Sounds/{0}", Name)))
            End If
            Return Sounds.Item(Name)
        End Function
        Public Shared Sub UnloadSound(Name As String)
            If Sounds.ContainsKey(Name) Then
                Sounds.Remove(Name)
            End If
        End Sub
#End Region
    End Class
End Namespace