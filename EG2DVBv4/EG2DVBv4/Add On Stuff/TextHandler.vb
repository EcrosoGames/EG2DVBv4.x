﻿Public Class TextHandler
    Inherits BaseScreen
    Public Shared TXT As String = ""
    Public Shared REC As Rectangle
    Public Shared Sub SetText(ByVal st As String, ByVal siz As Integer, ByVal x As Integer, ByVal y As Integer)
        TXT = st
        FontSize = siz
        PosText(x, y)
    End Sub
    Public Shared Sub PosText(ByVal x As Integer, ByVal y As Integer)
        REC = New Rectangle(x, y, 0, 0)
        REC.Width = 5 * FontSize * (TXT.Length) + 2 + TXT.Length
        REC.Height = 7 * FontSize + 2
    End Sub
    Public Shared Sub ReadText(ByVal t As Boolean, ByVal sp As Integer)
        BookMark = 0
        SPD = 0
        Speed = sp
        Read = t
    End Sub
    Public Sub New()
        Name = "Text"
        State = ScreenState.Active
    End Sub
    Public Shared Anitime As Integer = 0
    Public Overrides Sub Update()
        'Example of how to control your updates
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If Anitime > 10 Then
            Anitime = 0
            If Read Then
                SPD += 1
                If SPD = Speed Then
                    SPD = 0
                    If BookMark < TXT.Length Then
                        BookMark += 1
                    End If
                End If
            End If
        End If
    End Sub
    Public Shared Speed As Integer = 1
    Public Shared SPD As Integer = 0
    Public Shared BookMark As Integer = 0
    Public Shared Read As Boolean = False
    Public Shared FontSize As Integer = 10
    Public Shared FontType As String = "Px5"
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        If Read Then
            Globals.SpriteBatch.Draw(Textures.Null, REC, Color.White)
            For q As Integer = 0 To BookMark - 1
                If FontType = "Px5" Then
                    Globals.SpriteBatch.Draw(Fonts.PXfont, New Rectangle(TextHandler.REC.X + q * (5 * FontSize) + q + 1, TextHandler.REC.Y + 1, 5 * FontSize, 7 * FontSize), New Rectangle(TextHandler.Convert(TXT.Substring(q, 1)), 1, 5, 7), Color.Black)
                ElseIf FontType = "Px7" Then
                    Globals.SpriteBatch.Draw(Fonts.PXfont, New Rectangle(q * FontSize, TextHandler.REC.Y, FontSize, FontSize), New Rectangle(0, 0, 0, 0), Color.Black)
                End If
            Next
        End If
        Globals.SpriteBatch.End()
    End Sub
    Public Shared Function Convert(ByVal st As String)
        Select Case Asc(st)
            Case 32 To 126
                Return Asc(st) * 6
            Case Else

        End Select
    End Function
End Class