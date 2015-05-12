Public Class MenuGFX
    Public Shared Sub DrawMenuGFX(dest As Rectangle, clrColor As Color, bg As Boolean, sb As SpriteBatch, t2d As Texture2D, Optional bgAlpha As Double = 0.99)

        Dim srcImgWidth As Integer = 16
        Dim srcImgHeight As Integer = 16
        Dim sRect As Rectangle
        Dim dRect As Rectangle
        Dim dColor As Color = clrColor

        If bg = True Then
            sRect = New Rectangle(0, 0, 64, 32)
            dRect = New Rectangle(dest.X + 3, dest.Y + 3, dest.Width - 6, dest.Height - 6)
            sb.Draw(t2d, dRect, sRect, dColor * bgAlpha)
        End If

        ' top left corner
        sRect = New Rectangle(64, 0, srcImgWidth, srcImgHeight)
        dRect = New Rectangle(dest.X, dest.Y, srcImgWidth, srcImgHeight)
        sb.Draw(t2d, dRect, sRect, dColor)

        ' top middle
        sRect = New Rectangle(80, 0, srcImgWidth, srcImgHeight)
        dRect = New Rectangle(dest.X + srcImgWidth, dest.Y, dest.Width - (srcImgWidth * 2), srcImgHeight)
        sb.Draw(t2d, dRect, sRect, dColor)

        ' top right corner
        sRect = New Rectangle(112, 0, srcImgWidth, srcImgHeight)
        dRect = New Rectangle(dest.X + dest.Width - srcImgWidth, dest.Y, srcImgWidth, srcImgHeight)
        sb.Draw(t2d, dRect, sRect, dColor)

        ' left side
        sRect = New Rectangle(64, 16, srcImgWidth, srcImgHeight)
        dRect = New Rectangle(dest.X, dest.Y + srcImgHeight, srcImgWidth, dest.Height - (srcImgHeight * 2))
        sb.Draw(t2d, dRect, sRect, dColor)

        ' right side
        sRect = New Rectangle(112, 16, srcImgWidth, srcImgHeight)
        dRect = New Rectangle(dest.X + dest.Width - srcImgWidth, dest.Y + srcImgHeight, srcImgWidth, dest.Height - (srcImgHeight * 2))
        sb.Draw(t2d, dRect, sRect, dColor)

        ' bottom left corner
        sRect = New Rectangle(64, 48, srcImgWidth, srcImgHeight)
        dRect = New Rectangle(dest.X, dest.Y + dest.Height - srcImgHeight, srcImgWidth, srcImgHeight)
        sb.Draw(t2d, dRect, sRect, dColor)

        ' bottom middle
        sRect = New Rectangle(80, 48, srcImgWidth, srcImgHeight)
        dRect = New Rectangle(dest.X + srcImgWidth, dest.Y + dest.Height - srcImgHeight, dest.Width - (srcImgWidth * 2), srcImgHeight)
        sb.Draw(t2d, dRect, sRect, dColor)

        ' bottom right corner
        sRect = New Rectangle(112, 48, srcImgWidth, srcImgHeight)
        dRect = New Rectangle(dest.X + dest.Width - srcImgWidth, dest.Y + dest.Height - srcImgHeight, srcImgWidth, srcImgHeight)
        sb.Draw(t2d, dRect, sRect, dColor)
    End Sub
End Class
