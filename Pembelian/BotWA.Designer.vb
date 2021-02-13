<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BotWA
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
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tmkirimtanpakontak = New System.Windows.Forms.Timer(Me.components)
        Me.tmkirimkontak = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(44, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(183, 44)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "LOGOUT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(44, 173)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(183, 44)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "KIRIM TANPA KONTAK"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tmkirimtanpakontak
        '
        '
        'tmkirimkontak
        '
        '
        'BotWA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "BotWA"
        Me.Text = "BotWA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tmkirimtanpakontak As System.Windows.Forms.Timer
    Friend WithEvents tmkirimkontak As System.Windows.Forms.Timer
End Class
