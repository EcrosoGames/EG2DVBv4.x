Imports System.Windows.Forms

Public Class Debug_Console
    Private Sub txtInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtInput.Text <> Nothing Then
                'This is where you can add in fancy debug commands
                'Added this to allow for better debugging while the game is running
                Select Case txtInput.Text
                    Case "ListScreens"
                        RichTextBox1.Text += (Debug.Screens)
                    Case "Vsync"
                        Vsync.Switch()
                        RichTextBox1.Text += "Vsync is now " & Vsync.Synced
                    Case "ClearSM"
                        Dim screens() As BaseScreen = ScreenManager.Screens.ToArray
                        ScreenManager.StateChange(screens, ScreenState.Shutdown, 4)
                End Select
                txtInput.Clear()
                RichTextBox1.Text += vbCrLf
            End If
        End If
    End Sub
    Private Sub Debug_Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Shared GameInput As Boolean = True
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkInput.CheckedChanged
        Me.GameInput = chkInput.Checked
    End Sub

    Private Sub Debug_Console_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.GameInput = True
    End Sub
End Class