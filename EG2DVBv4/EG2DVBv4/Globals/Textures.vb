Public Class Textures
    'Public Shared texture As Texture2D
    Public Shared Null As Texture2D
    Public Shared Sub Load()
        'texture = Globals.Content.Load(Of Texture2D)("GFX/name")
        Null = Globals.Content.Load(Of Texture2D)("GFX/menuscreen")
    End Sub
End Class
