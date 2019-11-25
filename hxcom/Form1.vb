Imports System.Text.RegularExpressions

Public Class Form1

    'Regex
    'Import: import\s\s*(.*?)\s*;
    'New Line (EOL): \s*(.*?);
    'Class Array Constructor: \s*([a-zA-Z]|[a-zA-Z0-9_]+)\s*([a-zA-Z]|[a-zA-Z0-9_]+)\[\s*(\d+|)\s*\]\s*\{\s*(.*?)\s*\}
    'OLD Class InArray Constructor: ([a-zA-Z]|[a-zA-Z0-9_]+)\s*\:\s*(.*?)\s*\;
    'NEW Class InArray Constructor: Seperator ","
    'Function: ([a-zA-Z]|[a-zA-Z0-9_]+)(?=\((.*?)\);)
    'Function Body: ([a-zA-Z_]|[a-zA-Z0-9_]+)(?=\((.*?)\)\s*(([a-zA-Z_]|[a-zA-Z0-9_]+)|)\s*\{\s*(.*?)\s*\})
    'Variable String: var\s*([a-zA-Z_]|[a-zA-Z0-9_]+)\s*=\s*\"(.*?)\"\s*;
    'Variable Function: var\s*([a-zA-Z_]|[a-zA-Z0-9_]+)\s*=\s*([a-zA-Z]|[a-zA-Z0-9_]+)(?=\((.*?)\);)

    Dim arrayDic As New Dictionary(Of String, List(Of String))

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As New Tokens
        t.LoadBreakpointsCharacter()
        MsgBox(t.BreakpointsCharacter.Count)
        Dim matches As MatchCollection = Regex.Matches(rtb_code.Text, "\s*([a-zA-Z]|[a-zA-Z0-9_]+)\s*([a-zA-Z]|[a-zA-Z0-9_]+)\[\s*(\d+|)\s*\]\s*\{\s*(.*?)\s*\}", RegexOptions.Singleline)
        lb_func.Items.Clear()

        For Each m As Match In matches
            For Each c As Capture In m.Groups(2).Captures
                lb_func.Items.Add(c.Value)
            Next
        Next
    End Sub

    Private Sub lb_func_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_func.SelectedIndexChanged
        Dim a As String = lb_func.SelectedItem
        ' rtb_code.SelectionBackColor = Color.Transparent
        ' rtb_code.Select(rtb_code.Find(a), a.Length)
        ' rtb_code.SelectionBackColor = Color.CadetBlue
        ' rtb_code.SelectionStart = rtb_code.Find(a)
        ' rtb_code.SelectionLength = a.Length
        ' MsgBox(a)
    End Sub

    Private Sub lb_arrayitem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_arrayitem.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim t As New iTokens
        t.LoadTokenDictionary()
        '
        '
        Dim toks As New List(Of iTokenziedCharacter)
        toks = t.TokenizeToCharacter(RichTextBox1.Text)
        ' rtb_code.Clear()
        rtb2.Clear()
        ' rtb3.Clear()
        ' Dim wb As New WordBuilder
        ' Dim tb As New IdentifierTokens
        ' wb.LoadBreakpointsCharacter()
        ' tb.LoadBreakpointsCharacter()
        '
        '
        ' Dim w1 As New List(Of Word)
        ' w1 = wb.BuildWords(toks)
        ' ' MsgBox("Cleared")
        '
        ' Dim w As New List(Of IdentifiedToken)
        ' w = tb.BuildTokens(toks)
        '
        For i = 0 To toks.Count - 1
            rtb2.AppendText("[" + CStr(toks(i).GetLine) + ", " + CStr(toks(i).GetColumn) + "]" + ": " + CStr(toks(i).GetCharacter + " " + iTokenModule.PeakBehind(toks(i)) + " " + iTokenModule.PeakAhead(toks(i)) + vbNewLine))
        Next
        '
        ' For i = 0 To w1.Count - 1
        '     rtb3.AppendText("[" + CStr(w1(i).GetLine) + ", " + CStr(w1(i).GetColumn) + ", " + CStr(w1(i).GetLength) + "]" + ": " + w1(i).GetWord + vbNewLine)
        ' Next
        '
        ' For i = 0 To w.Count - 1
        '     rtb_code.AppendText("[" + CStr(w(i).GetLine) + ", " + CStr(w(i).GetColumn) + ", " + CStr(w(i).GetLength) + "]" + ": " + w(i).GetWord + vbNewLine)
        ' Next

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Button2.PerformClick()
    End Sub


End Class
