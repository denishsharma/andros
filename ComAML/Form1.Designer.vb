<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txt_code = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rtb1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'txt_code
        '
        Me.txt_code.AcceptsTab = True
        Me.txt_code.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_code.Location = New System.Drawing.Point(12, 12)
        Me.txt_code.Name = "txt_code"
        Me.txt_code.Size = New System.Drawing.Size(388, 307)
        Me.txt_code.TabIndex = 0
        Me.txt_code.Text = resources.GetString("txt_code.Text")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 325)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Tokenize"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rtb1
        '
        Me.rtb1.AcceptsTab = True
        Me.rtb1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb1.Location = New System.Drawing.Point(406, 12)
        Me.rtb1.Name = "rtb1"
        Me.rtb1.Size = New System.Drawing.Size(289, 307)
        Me.rtb1.TabIndex = 2
        Me.rtb1.TabStop = False
        Me.rtb1.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 359)
        Me.Controls.Add(Me.rtb1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_code)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txt_code As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents rtb1 As RichTextBox
End Class
