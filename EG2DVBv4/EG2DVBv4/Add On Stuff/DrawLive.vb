Public Class DrawLive
    Public Shared Scren As RenderTarget2D
    Public Shared freedraw As GraphicsDeviceManager
    Public Shared livedraw As SpriteBatch
    Public Shared Sub Send(ByVal tex As Texture2D)
        freedraw = Globals.Graphics
        Scren = New RenderTarget2D(freedraw.GraphicsDevice, tex.Width, tex.Height)
        freedraw.GraphicsDevice.SetRenderTarget(Scren)
        livedraw = New SpriteBatch(freedraw.GraphicsDevice)
        livedraw.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        livedraw.Draw(tex, New Rectangle(0, 0, tex.Width, tex.Height), Color.White)
        livedraw.End()
    End Sub
    Public Shared Sub Modify(ByVal tex As Texture2D, ByVal DrawTo As Rectangle, ByVal col As Color)
        livedraw.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        livedraw.Draw(tex, DrawTo, col)
        livedraw.End()
    End Sub
    Public Shared PermGFX As Texture2D
    Public Shared Function Retrieve() As Texture2D
        freedraw.GraphicsDevice.SetRenderTarget(Nothing)
        Dim col(Scren.Width * Scren.Height - 1) As Color
        Scren.GetData(Of Color)(col)
        PermGFX = New Texture2D(Globals.Graphics.GraphicsDevice, Scren.Width, Scren.Height)
        PermGFX.SetData(Of Color)(col)
        Return PermGFX
        Scren.Dispose()
        livedraw.Dispose()
    End Function
End Class