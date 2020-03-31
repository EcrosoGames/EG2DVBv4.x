Public Class Maths
    Public Shared Function Distance(ByVal p1 As Vector2, ByVal p2 As Vector2) As Double
        Dim dist As Double = 0
        dist = Math.Abs(Math.Sqrt((p2.X - p1.X) ^ 2 + (p2.Y - p1.Y) ^ 2))
        Return dist
    End Function
    Public Shared Function Circollision(ByVal p1 As Vector2, ByVal p2 As Vector2, ByVal dist As Vector2) As Boolean
        If Distance(p1, p2) > dist.X And Distance(p1, p2) < dist.Y Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function Collision(ByVal B1 As Rectangle, ByVal B2 As Rectangle, ByVal Vectoring As Boolean) As Boolean
        If Vectoring Then
            If B1.X - B1.Width / 2 < B2.X + B2.Width / 2 And
                         B1.X + B1.Width / 2 > B2.X - B2.Width / 2 And
                        B1.Y - B1.Height / 2 < B2.Y + B2.Height / 2 And
                         B1.Y + B1.Height / 2 > B2.Y - B2.Height / 2 Then
                Return True
            Else
                Return False
            End If
        Else
            If B1.X < B2.X + B2.Width And
             B1.X + B1.Width > B2.X And
             B1.Y < B2.Y + B2.Height And
             B1.Y + B1.Height > B2.Y Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Shared Function Inside(ByVal B1 As Rectangle, ByVal B2 As Rectangle) As Boolean
        If B1.X < B2.X + B2.Width And
            B1.X + B1.Width > B2.X And
            B1.X + B1.Width < B2.X + B2.Width And
            B1.X > B2.X And
            B1.Y < B2.Y + B2.Height And
            B1.Y + B1.Height > B2.Y Then
            Return True
        Else
            Return False
        End If
    End Function
End Class