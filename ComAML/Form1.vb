Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(String.IsNullOrWhiteSpace("   "))
        ' Dim w = Hex(137).PadLeft(4, "0"c)
        ' MsgBox(w)
        ' MsgBox(w.TrimStart("0"c))
        Dim t As New Tokenize
        ' MsgBox(t.TypeOfCodeLine(txt_code.Text).ToString)
        t.LoadCode(txt_code.Text)
        For Each l In t.ListOfCodeLine
            rtb1.AppendText(l + vbNewLine)
        Next
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles rtb1.TextChanged

    End Sub
End Class
