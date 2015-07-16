Public Class Fonts
    Public Shared Georgia_16 As SpriteFont
    Public Shared Arial_8 As SpriteFont
    Public Shared MotorWerk_16 As SpriteFont
    Public Shared PXfont As Texture2D
    Public Shared Sub Load()
        Georgia_16 = Globals.Content.Load(Of SpriteFont)("Fonts/Georgia_16")
        Arial_8 = Globals.Content.Load(Of SpriteFont)("Fonts/Arial_8")
        MotorWerk_16 = Globals.Content.Load(Of SpriteFont)("Fonts/Motorwerk_16")
        PXfont = Globals.Content.Load(Of Texture2D)("GFX/PxFont")
    End Sub
End Class