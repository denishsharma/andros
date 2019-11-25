Public Class iTokens

    Public TokenDictionary As New Dictionary(Of String, String)
    Public BreakpointsCharacter As New List(Of String)
    Public KeywordsKey, KeywordsValue, NumbersKey, NumbersValue, EscapeCharactersKey, EscapeCharactersValue, OperatorsKey, OperatorsValue As New List(Of String)

    Public Sub LoadBreakpointsCharacter()
        BreakpointsCharacter.AddRange({"[SPACE]", "[NEWLINE]", "[EOF]", "[EOL]", "(", ")", "[", "]", "{", "}", "<", "=", ">", ".", ",", """", "'"})
    End Sub

    Public Function IsCharacterBreakpoint(ichar As String) As Boolean
        If BreakpointsCharacter.Contains(ichar) Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Function IsEscapeCharacter(ichar As String) As Boolean
        If EscapeCharactersValue.Contains(ichar) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub LoadTokenDictionary()
        ' Keywords
        LoadKeywordsKeyValuePair()
        For i = 0 To KeywordsKey.Count - 1
            TokenDictionary.Add(KeywordsKey(i).ToUpper, KeywordsValue(i))
        Next

        'Numbers
        LoadNumbersKeyValuePair()
        For i = 0 To NumbersKey.Count - 1
            TokenDictionary.Add(NumbersKey(i).ToUpper, NumbersValue(i))
        Next

        'Escape Characters
        LoadEscapeCharactersKeyValuePair()
        For i = 0 To EscapeCharactersKey.Count - 1
            TokenDictionary.Add(EscapeCharactersKey(i).ToUpper, EscapeCharactersValue(i))
        Next


        'Strings
        TokenDictionary.Add("StringQuote".ToUpper, """")

        'Characters
        TokenDictionary.Add("CharachterQuote".ToUpper, "'")

        'Comments
        TokenDictionary.Add("CommentStart".ToUpper, "//")

        'Operators
        LoadOperatorsKeyValuePair()
        For i = 0 To OperatorsKey.Count - 1
            TokenDictionary.Add(OperatorsKey(i).ToUpper, OperatorsValue(i))
        Next

        'Parenthesis
        TokenDictionary.Add("LeftParenthesis".ToUpper, "(")
        TokenDictionary.Add("RightParenthesis", ")")

        'Brackets
        TokenDictionary.Add("LeftSquareBracket".ToUpper, "[")
        TokenDictionary.Add("RightSquareBracket".ToUpper, "]")
        TokenDictionary.Add("LeftCurlyBracket".ToUpper, "{")
        TokenDictionary.Add("RightCurlyBracket".ToUpper, "}")

        'Seperator of Array and Parameter
        TokenDictionary.Add("SeperatorArray", ",")

        'End Of Line
        TokenDictionary.Add("EndOfLine", ";")
        TokenDictionary.Add("EndOfCodeBreakpoint", "[EOL]")

        'End Of File
        TokenDictionary.Add("EndOfFile", "[EOF]")

        'Special Breakpoints
        TokenDictionary.Add("SpaceSpecialBreakpoint", "[SPACE]")
        TokenDictionary.Add("NewLineSpecialBreakpoint", "[NEWLINE]")
    End Sub

    Public Sub LoadKeywordsKeyValuePair()
        LoadKeywordsKey() : LoadKeywordsValue()
    End Sub

    Private Sub LoadKeywordsKey()
        KeywordsKey.AddRange({"Object", "String", "Character", "Boolean", "Integer", "Float", "Double", "Byte", "Short", "Date", "LogicalAndKeyword",
                             "LogicalOrKeyword", "LogicalNotKeyword", "If", "Else", "ElseIf", "Class", "Return", "Of", "For", "Next", "While", "True", "False", "None", "Variable",
                             "Break", "Import", "With", "In", "Try", "Catch", "Call", "End", "Get", "Set", "Print", "Expression"})
    End Sub

    Private Sub LoadKeywordsValue()
        KeywordsValue.AddRange({"obj", "string", "char", "bool", "int", "float", "double", "byte", "short", "date", "and",
                               "or", "not", "if", "else", "elseif", "class", "return", "of", "for", "next", "while", "true", "false", "none", "var",
                               "break", "import", "with", "in", "try", "catch", "call", "end", "get", "set", "print", "expr"})
    End Sub

    Public Sub LoadNumbersKeyValuePair()
        LoadNumbersKey() : LoadNumbersValue()
    End Sub

    Private Sub LoadNumbersKey()
        NumbersKey.AddRange({"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"})
    End Sub

    Private Sub LoadNumbersValue()
        NumbersValue.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
    End Sub

    Public Sub LoadEscapeCharactersKeyValuePair()
        LoadEscapeCharactersKey() : LoadEscapeCharactersValue()
    End Sub

    Private Sub LoadEscapeCharactersKey()
        EscapeCharactersKey.AddRange({"SingleQuoteEC", "DoubleQuoteEC", "BackSlashEC", "UnicodeEC", "AlertEC", "BackspaceEC", "FormFeedEC", "NewLineEC", "CarriageReturnEC",
                             "HorizontalTabEC", "VerticalQuoteEC"})
    End Sub

    Private Sub LoadEscapeCharactersValue()
        EscapeCharactersValue.AddRange({"\'", "\""", "\\", "\0", "\a", "\b", "\f", "\n", "\r", "\t", "\v"})
    End Sub

    Public Sub LoadOperatorsKeyValuePair()
        LoadOperatorsKey() : LoadOperatorsValue()
    End Sub

    Private Sub LoadOperatorsKey()
        OperatorsKey.AddRange({"Add", "Subtract", "Divide", "Multiply", "Remainder", "LessThan", "GreaterThan", "LessThanOrEqual", "GreaterThanOrEqual",
                              "LogicalNotOperator", "NotEqual", "Exponent", "LeftShiftBit", "RightShiftBit", "Assignment", "Equal", "StrictlyEqual",
                              "LogicalOrOperator", "LogicalAndOperator"})
    End Sub

    Private Sub LoadOperatorsValue()
        OperatorsValue.AddRange({"+", "-", "/", "*", "%", "<", ">", "<=", ">=", "!", "!=", "^", "<<", ">>", "=", "==", "===", "||", "&&", ""})
    End Sub

    Public Function TokenizeToCharacter(input As String) As List(Of iTokenziedCharacter)
        Dim t As New List(Of iTokenziedCharacter)
        Dim nli, cli As Integer
        For Each l As String In input
            Dim tc As New iTokenziedCharacter
            If l = vbLf Then
                tc.Add("[NEWLINE]", nli, cli, True)
                nli += 1
                cli = 0
            ElseIf l = " " Then
                tc.Add("[SPACE]", nli, cli, True)
                cli += 1
            ElseIf l = ";" Then
                tc.Add("[EOL]", nli, cli, True)
                cli += 1
            Else
                tc.Add(l, nli, cli, False)
                cli += 1
            End If
            t.Add(tc)
        Next
        t.Add(New iTokenziedCharacter("[EOF]", nli, cli, True))

        Dim u As New List(Of iTokenziedCharacter)
        For i = 0 To t.Count - 1
            Dim tc As New iTokenziedCharacter
            If t.Count = 1 Then
                tc.Add(t(i).GetCharacter, "[BOF]", "", t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
            ElseIf t.Count > 0 Then
                If i = 0 Then
                    tc.Add(t(i).GetCharacter, "[BOF]", t(i + 1).GetCharacter, t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
                ElseIf i = t.Count - 1 Then
                    tc.Add(t(i).GetCharacter, t(i - 1).GetCharacter, "[NOCHARAHEAD]", t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
                ElseIf i > 1 Then
                    tc.Add(t(i).GetCharacter, t(i - 1).GetCharacter, t(i + 1).GetCharacter, t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
                ElseIf i = 1 Then
                    tc.Add(t(i).GetCharacter, t(i - 1).GetCharacter, t(i + 1).GetCharacter, t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
                End If
                u.Add(tc)
            End If
        Next

        Return u
    End Function

    Public Shared Function GetTokenType(input As String) As TokenTypes


        Return Nothing
    End Function

    Public Enum TokenTypes
        iKEYWORD = 0
        iNUMBER = 1
        iSTRING = 2
        iCHARACTER = 3
        iCOMMENT = 4
        iOPERATOR = 5
        iPARENTHESIS = 6
        iBRACKETS = 7
        iENDOFLINE = 8
    End Enum

End Class

Module iTokenModule

    Public Function PeakBehind(ichar As iTokenziedCharacter) As String
        Return ichar.GetPrecedingCharacter
    End Function

    Public Function PeakAhead(ichar As iTokenziedCharacter) As String
        Return ichar.GetSucceedingCharacter
    End Function

    Public Function IsCharacterInOrder(t As List(Of iTokenziedCharacter)) As Boolean
        ' Dim u As New List(Of iTokenziedCharacter)
        ' Dim bc, nc, cc As String
        ' For i = 0 To t.Count - 1
        '     bc = t(i).GetPrecedingCharacter : nc = t(i).GetSucceedingCharacter : cc = t(i).GetCharacter
        '
        '     If t.Count = 1 Then
        '         tc.Add(t(i).GetCharacter, "[BOF]", "", t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
        '     ElseIf t.Count > 0 Then
        '         If i = 0 Then
        '             tc.Add(t(i).GetCharacter, "[BOF]", t(i + 1).GetCharacter, t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
        '         ElseIf i = t.Count - 1 Then
        '             tc.Add(t(i).GetCharacter, t(i - 1).GetCharacter, "[NOCHARAHEAD]", t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
        '         ElseIf i > 1 Then
        '             tc.Add(t(i).GetCharacter, t(i - 1).GetCharacter, t(i + 1).GetCharacter, t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
        '         ElseIf i = 1 Then
        '             tc.Add(t(i).GetCharacter, t(i - 1).GetCharacter, t(i + 1).GetCharacter, t(i).GetLine, t(i).GetColumn, t(i).IsSpecialBreakpoint)
        '         End If
        '         u.Add(tc)
        '     End If
        ' Next
        Return Nothing
    End Function

End Module

Public Class iTokenziedCharacter
    Private Character As String
    Private PrecedingCharacter As String
    Private SucceedingCharacter As String
    Private Line As Integer
    Private Column As Integer
    Private SpecialBreakpoint As Boolean

    Sub New()

    End Sub
    Sub New(tchar As String, tline As Integer, tcol As Integer, sbp As Boolean)
        Character = tchar : Line = tline : Column = tcol : SpecialBreakpoint = sbp
    End Sub
    Sub New(tchar As String, pchar As String, schar As String, tline As Integer, tcol As Integer, sbp As Boolean)
        Character = tchar : PrecedingCharacter = pchar : SucceedingCharacter = schar : Line = tline : Column = tcol : SpecialBreakpoint = sbp
    End Sub

    Public Sub Add(tchar As String, tline As Integer, tcol As Integer, sbp As Boolean)
        Character = tchar : Line = tline : Column = tcol : SpecialBreakpoint = sbp
    End Sub
    Public Sub Add(tchar As String, pchar As String, schar As String, tline As Integer, tcol As Integer, sbp As Boolean)
        Character = tchar : PrecedingCharacter = pchar : SucceedingCharacter = schar : Line = tline : Column = tcol : SpecialBreakpoint = sbp
    End Sub

    Public ReadOnly Property GetCharacter() As String
        Get
            Return Character
        End Get
    End Property

    Public ReadOnly Property GetPrecedingCharacter() As String
        Get
            Return PrecedingCharacter
        End Get
    End Property


    Public ReadOnly Property GetSucceedingCharacter() As String
        Get
            Return SucceedingCharacter
        End Get
    End Property


    Public ReadOnly Property GetLine() As Integer
        Get
            Return Line
        End Get
    End Property

    Public ReadOnly Property GetColumn() As Integer
        Get
            Return Column
        End Get
    End Property

    Public ReadOnly Property IsSpecialBreakpoint() As Boolean
        Get
            Return SpecialBreakpoint
        End Get
    End Property

End Class

Public Class iIdentifierTokens
    Inherits iTokens

    Public Function GetTokenKey(itoken As String, toks As iTokens) As String
        For Each i In toks.TokenDictionary
            If i.Value = itoken Then
                Return "[" + i.Key.ToUpper + "]"
            ElseIf Not i.Value = itoken Then
                Return itoken
            End If
        Next
        Return Nothing
    End Function

    Public Function BuildTokens(input As List(Of iTokenziedCharacter)) As List(Of iIdentifiedToken)
        Dim StringQuoteBreakpoint As Integer = -1
        Dim breakpoint As Boolean = False
        Dim ecbrepakpoint As Integer = -1
        Dim ecstring As String = ""

        LoadTokenDictionary()

        Dim ichar As String
        Dim w As String = ""
        Dim ws As New List(Of iIdentifiedToken)
        Dim len, col, line As Integer

        Dim pi As Integer = 0
        For i = 0 To input.Count - 1
            ichar = input(i).GetCharacter
            col = input(i).GetColumn
            line = input(i).GetLine


            Dim wd As New iIdentifiedToken


            If IsCharacterBreakpoint(ichar) And ecbrepakpoint = -1 Then

                wd.Add(w, len, line, col - len, "", False)
                ws.Add(wd)
                w = ""



                If input(i).IsSpecialBreakpoint = True Then
                    ws.Add(New iIdentifiedToken(ichar, 1, line, col - len, "[SBP]", True))
                Else
                    ws.Add(New iIdentifiedToken(ichar, 1, line, col - len, "[SOMEBREAKPOINT]", False))
                End If

                len = 0

            Else
                ' len += 1
                ' w += ichar


                ' Escape char
                If ichar = "\" And ecstring = "" Then
                    ecbrepakpoint = 0
                    ecstring += "\"

                Else
                    If ecbrepakpoint = 0 Then
                        ecstring += ichar
                        If IsEscapeCharacter(ecstring) = True Then
                            wd.Add(w, len, line, col - len, "", False)
                            ws.Add(wd)
                            w = ""
                            len = 0

                            ws.Add(New iIdentifiedToken(ecstring, len, line, col - len, "", False))
                            ecstring = ""
                        Else
                            ecbrepakpoint = -1
                            len += 1
                            w += ecstring
                            ecstring = ""
                        End If

                    Else
                        ecstring = ""
                        ecbrepakpoint = -1
                        len += 1
                        w += ichar
                    End If
                End If
                'End Escape char

            End If
        Next

        Dim k As New List(Of iIdentifiedToken)
        For i = 0 To ws.Count - 1
            Dim kd As New iIdentifiedToken
            If Not ws(i).GetWord = "" Then
                kd.Add(ws(i).GetWord, ws(i).GetLength, ws(i).GetLine, ws(i).GetColumn, ws(i).GetIdentifierType, ws(i).IsSpecialBreakpoint)
                k.Add(kd)
            End If
        Next

        Dim p As New List(Of iIdentifiedToken)
        Dim sindex As Integer = TokenDictionary.Count

        For i = 0 To k.Count - 1
            Dim pd As New iIdentifiedToken
            For Each j In TokenDictionary
                If j.Value = k(i).GetWord Then
                    pd.Add(k(i).GetWord, k(i).GetLength, k(i).GetLine, k(i).GetColumn, "[" + j.Key.ToUpper + "]", k(i).IsSpecialBreakpoint)
                    p.Add(pd)
                    Exit For
                Else
                    sindex -= 1
                End If
            Next

            If sindex = 0 Then
                pd.Add(k(i).GetWord, k(i).GetLength, k(i).GetLine, k(i).GetColumn, "[SOMETEXT]", k(i).IsSpecialBreakpoint)
                p.Add(pd)
            End If

            sindex = TokenDictionary.Count
        Next


        Dim c As New List(Of iIdentifiedToken)
        Dim qString As String = ""
        For i = 0 To p.Count - 1
            Dim cd As New iIdentifiedToken

            If p(i).GetIdentifierType = ToUpper("StringQuote") Then
                If StringQuoteBreakpoint = -1 Then
                    StringQuoteBreakpoint = 1
                Else
                    StringQuoteBreakpoint = 0
                End If
            ElseIf p(i).GetIdentifierType = ToUpper("escapecharactersymbol") Then

            Else
                If StringQuoteBreakpoint = -1 Then
                    c.Add(p(i))
                End If

            End If

            If StringQuoteBreakpoint = 1 Then
                If p(i).IsSpecialBreakpoint = True Then
                    If p(i).GetWord = ToUpper("space") Then
                        qString += " "
                    End If
                Else

                    qString += p(i).GetWord
                End If

            ElseIf StringQuoteBreakpoint = 0 Then
                cd.Add(qString.Remove(0, 1), qString.Length - 1, ws(i).GetLine, ws(i).GetColumn, "[STRINGVALUE]", False)
                c.Add(cd)
                qString = ""
                StringQuoteBreakpoint = -1
            End If
        Next

        Return p
    End Function

    Private Function ToUpper(input As String) As String
        Return "[" + input.ToUpper + "]"
    End Function

    Private Function ToKEY(input As String) As String
        Return Nothing
    End Function

End Class

Public Class iIdentifiedToken
    Private Word As String
    Private IdentifierType As String
    Private Length As Integer
    Private Line As Integer
    Private Column As Integer
    Private SpecialBreakpoint As Boolean

    Sub New()

    End Sub
    Sub New(tword As String, tlength As Integer, tline As Integer, tcol As Integer, itype As String, sbp As Boolean)
        Word = tword : Line = tline : Column = tcol : Length = tlength : IdentifierType = itype : SpecialBreakpoint = sbp
    End Sub


    Public Sub Add(tword As String, tlength As Integer, tline As Integer, tcol As Integer, itype As String, sbp As Boolean)
        Word = tword : Line = tline : Column = tcol : Length = tlength : IdentifierType = itype : SpecialBreakpoint = sbp
    End Sub

    Public ReadOnly Property GetWord() As String
        Get
            Return Word
        End Get
    End Property

    Public ReadOnly Property GetLine() As Integer
        Get
            Return Line
        End Get
    End Property

    Public ReadOnly Property GetColumn() As Integer
        Get
            Return Column
        End Get
    End Property

    Public ReadOnly Property GetLength() As Integer
        Get
            Return Length
        End Get
    End Property

    Public ReadOnly Property GetIdentifierType() As String
        Get
            Return IdentifierType
        End Get
    End Property

    Public ReadOnly Property IsSpecialBreakpoint() As Boolean
        Get
            Return SpecialBreakpoint
        End Get
    End Property
End Class