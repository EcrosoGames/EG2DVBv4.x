Public Class RNG
    Public Shared Function Free(ByVal Lo As Integer, ByVal Hi As Integer) As Integer
        Static Gen As System.Random = New System.Random()
        Return Gen.Next(Lo, Hi + 1)
    End Function
    Public Shared Gen As System.Random
    Public Shared Function Fixed(ByVal Lo As Integer, ByVal Hi As Integer, ByVal Seed As Integer, Optional ByVal Reset As Boolean = False) As Integer
        If Reset Then Gen = New System.Random(Seed)
        Return Gen.Next(Lo, Hi + 1)
    End Function
End Class