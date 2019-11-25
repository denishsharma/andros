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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_type = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_func = New System.Windows.Forms.ListBox()
        Me.rtb_code = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lb_arrayitem = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.rtb2 = New System.Windows.Forms.RichTextBox()
        Me.rtb3 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Type:"
        '
        'lbl_type
        '
        Me.lbl_type.AutoSize = True
        Me.lbl_type.Location = New System.Drawing.Point(52, 12)
        Me.lbl_type.Name = "lbl_type"
        Me.lbl_type.Size = New System.Drawing.Size(28, 13)
        Me.lbl_type.TabIndex = 1
        Me.lbl_type.Text = "Text"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 401)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Functions:"
        '
        'lb_func
        '
        Me.lb_func.FormattingEnabled = True
        Me.lb_func.Location = New System.Drawing.Point(15, 417)
        Me.lb_func.Name = "lb_func"
        Me.lb_func.Size = New System.Drawing.Size(120, 134)
        Me.lb_func.TabIndex = 3
        '
        'rtb_code
        '
        Me.rtb_code.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb_code.Location = New System.Drawing.Point(15, 32)
        Me.rtb_code.Name = "rtb_code"
        Me.rtb_code.Size = New System.Drawing.Size(240, 337)
        Me.rtb_code.TabIndex = 4
        Me.rtb_code.Text = ""
        Me.rtb_code.WordWrap = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 375)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Run"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lb_arrayitem
        '
        Me.lb_arrayitem.FormattingEnabled = True
        Me.lb_arrayitem.Location = New System.Drawing.Point(141, 417)
        Me.lb_arrayitem.Name = "lb_arrayitem"
        Me.lb_arrayitem.Size = New System.Drawing.Size(120, 134)
        Me.lb_arrayitem.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(96, 375)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Show"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(525, 32)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(167, 337)
        Me.RichTextBox1.TabIndex = 4
        Me.RichTextBox1.Text = "string Array1[] {" & Global.Microsoft.VisualBasic.ChrW(10) & "    a, b, c, d" & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "string Array2[] {" & Global.Microsoft.VisualBasic.ChrW(10) & "    e, f, g, h" & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "string Ar" &
    "ray3[] {" & Global.Microsoft.VisualBasic.ChrW(10) & "    i, j, k, l" & Global.Microsoft.VisualBasic.ChrW(10) & "}"
        Me.RichTextBox1.WordWrap = False
        '
        'rtb2
        '
        Me.rtb2.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb2.Location = New System.Drawing.Point(261, 32)
        Me.rtb2.Name = "rtb2"
        Me.rtb2.Size = New System.Drawing.Size(258, 337)
        Me.rtb2.TabIndex = 4
        Me.rtb2.Text = ""
        Me.rtb2.WordWrap = False
        '
        'rtb3
        '
        Me.rtb3.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb3.Location = New System.Drawing.Point(698, 32)
        Me.rtb3.Name = "rtb3"
        Me.rtb3.Size = New System.Drawing.Size(258, 337)
        Me.rtb3.TabIndex = 6
        Me.rtb3.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 558)
        Me.Controls.Add(Me.rtb3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rtb2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.rtb_code)
        Me.Controls.Add(Me.lb_arrayitem)
        Me.Controls.Add(Me.lb_func)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_type)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "H Com"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_type As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lb_func As ListBox
    Friend WithEvents rtb_code As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lb_arrayitem As ListBox
    Friend WithEvents Button2 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents rtb2 As RichTextBox
    Friend WithEvents rtb3 As RichTextBox
End Class
