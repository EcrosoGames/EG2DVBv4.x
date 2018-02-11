<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Debug_Console
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.chkInput = New System.Windows.Forms.CheckBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'txtInput
        '
        Me.txtInput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtInput.Location = New System.Drawing.Point(0, 338)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(624, 20)
        Me.txtInput.TabIndex = 1
        '
        'chkInput
        '
        Me.chkInput.AutoSize = True
        Me.chkInput.Checked = True
        Me.chkInput.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInput.Location = New System.Drawing.Point(503, 315)
        Me.chkInput.Name = "chkInput"
        Me.chkInput.Size = New System.Drawing.Size(109, 17)
        Me.chkInput.TabIndex = 2
        Me.chkInput.Text = "Allow Game Input"
        Me.chkInput.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(624, 358)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'Debug_Console
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 358)
        Me.Controls.Add(Me.chkInput)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.RichTextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Debug_Console"
        Me.Text = "Debug Console"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInput As Windows.Forms.TextBox
    Friend WithEvents chkInput As Windows.Forms.CheckBox
    Friend WithEvents RichTextBox1 As Windows.Forms.RichTextBox
End Class
