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
        Me.txt_content = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_address = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_showcontent = New System.Windows.Forms.Button()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.btn_mov = New System.Windows.Forms.Button()
        Me.btn_remove = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_parse = New System.Windows.Forms.Button()
        Me.txt_datamemory = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.btn_cleanimport = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_blocklen = New System.Windows.Forms.TextBox()
        Me.btn_combine = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_content
        '
        Me.txt_content.Location = New System.Drawing.Point(66, 36)
        Me.txt_content.Name = "txt_content"
        Me.txt_content.Size = New System.Drawing.Size(150, 20)
        Me.txt_content.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Content:"
        '
        'txt_address
        '
        Me.txt_address.Location = New System.Drawing.Point(66, 10)
        Me.txt_address.Name = "txt_address"
        Me.txt_address.Size = New System.Drawing.Size(150, 20)
        Me.txt_address.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Address:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(322, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Count"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_showcontent
        '
        Me.btn_showcontent.Location = New System.Drawing.Point(232, 34)
        Me.btn_showcontent.Name = "btn_showcontent"
        Me.btn_showcontent.Size = New System.Drawing.Size(84, 23)
        Me.btn_showcontent.TabIndex = 4
        Me.btn_showcontent.Text = "Show Content"
        Me.btn_showcontent.UseVisualStyleBackColor = True
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(232, 8)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(84, 23)
        Me.btn_add.TabIndex = 5
        Me.btn_add.Text = "Add Block"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'btn_mov
        '
        Me.btn_mov.Location = New System.Drawing.Point(322, 34)
        Me.btn_mov.Name = "btn_mov"
        Me.btn_mov.Size = New System.Drawing.Size(84, 23)
        Me.btn_mov.TabIndex = 3
        Me.btn_mov.Text = "Move Content"
        Me.btn_mov.UseVisualStyleBackColor = True
        '
        'btn_remove
        '
        Me.btn_remove.Location = New System.Drawing.Point(232, 63)
        Me.btn_remove.Name = "btn_remove"
        Me.btn_remove.Size = New System.Drawing.Size(84, 23)
        Me.btn_remove.TabIndex = 10
        Me.btn_remove.Text = "Delete Block"
        Me.btn_remove.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(322, 63)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(84, 23)
        Me.btn_clear.TabIndex = 11
        Me.btn_clear.Text = "Clean Dump"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_parse
        '
        Me.btn_parse.Location = New System.Drawing.Point(144, 63)
        Me.btn_parse.Name = "btn_parse"
        Me.btn_parse.Size = New System.Drawing.Size(72, 23)
        Me.btn_parse.TabIndex = 12
        Me.btn_parse.Text = "Parse Block"
        Me.btn_parse.UseVisualStyleBackColor = True
        '
        'txt_datamemory
        '
        Me.txt_datamemory.Location = New System.Drawing.Point(15, 110)
        Me.txt_datamemory.Name = "txt_datamemory"
        Me.txt_datamemory.Size = New System.Drawing.Size(301, 154)
        Me.txt_datamemory.TabIndex = 13
        Me.txt_datamemory.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Data Memory:"
        '
        'btn_export
        '
        Me.btn_export.Location = New System.Drawing.Point(15, 63)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(123, 23)
        Me.btn_export.TabIndex = 15
        Me.btn_export.Text = "Export Dump Memory"
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'btn_cleanimport
        '
        Me.btn_cleanimport.Location = New System.Drawing.Point(322, 110)
        Me.btn_cleanimport.Name = "btn_cleanimport"
        Me.btn_cleanimport.Size = New System.Drawing.Size(84, 23)
        Me.btn_cleanimport.TabIndex = 16
        Me.btn_cleanimport.Text = "Clean Import"
        Me.btn_cleanimport.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(322, 139)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "SizeOf Block"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(319, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Length Of Block:"
        '
        'txt_blocklen
        '
        Me.txt_blocklen.Location = New System.Drawing.Point(322, 192)
        Me.txt_blocklen.Name = "txt_blocklen"
        Me.txt_blocklen.Size = New System.Drawing.Size(84, 20)
        Me.txt_blocklen.TabIndex = 19
        '
        'btn_combine
        '
        Me.btn_combine.Location = New System.Drawing.Point(322, 218)
        Me.btn_combine.Name = "btn_combine"
        Me.btn_combine.Size = New System.Drawing.Size(84, 23)
        Me.btn_combine.TabIndex = 20
        Me.btn_combine.Text = "Combine"
        Me.btn_combine.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 276)
        Me.Controls.Add(Me.btn_combine)
        Me.Controls.Add(Me.txt_blocklen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_cleanimport)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_datamemory)
        Me.Controls.Add(Me.btn_parse)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_remove)
        Me.Controls.Add(Me.txt_content)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_address)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_mov)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_showcontent)
        Me.Controls.Add(Me.btn_add)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_content As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_address As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents btn_showcontent As Button
    Friend WithEvents btn_add As Button
    Friend WithEvents btn_mov As Button
    Friend WithEvents btn_remove As Button
    Friend WithEvents btn_clear As Button
    Friend WithEvents btn_parse As Button
    Friend WithEvents txt_datamemory As RichTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_export As Button
    Friend WithEvents btn_cleanimport As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_blocklen As TextBox
    Friend WithEvents btn_combine As Button
End Class
