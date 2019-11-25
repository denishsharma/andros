Public Class Lexer

End Class


Public Class WordBuilder
    Inherits Tokens
    Private ReadOnly iSpecialBreakpoint As Boolean

    Public Function BuildWords(input As List(Of TokenziedCharacter)) As List(Of Word)
        Dim breakpoint As Boolean = False
        Dim ecbrepakpoint As Integer = -1
        LoadBreakpointsCharacter()
        Dim ichar As String
        Dim w As String = ""
        Dim ws As New List(Of Word)
        Dim len, col, line As Integer

        For i = 0 To input.Count - 1
            ichar = input(i).GetCharacter

            col = input(i).GetColumn
            line = input(i).GetLine

            Dim wd As New Word

            If IsCharacterBreakpoint(ichar) Then
                wd.Add(w, len, line, col - len)
                ws.Add(wd)
                w = ""
                len = 0
            Else
                If ichar = "\" Then
                    ecbrepakpoint = 0
                Else
                    If ecbrepakpoint = 0 Then
                        If ichar = "n" Then

                        Else
                            ecbrepakpoint = -1
                            len += 1
                            w += ichar
                        End If

                    Else
                        ecbrepakpoint = -1
                        len += 1
                        w += ichar
                    End If
                End If
            End If


        Next

        Dim k As New List(Of Word)
        For i = 0 To ws.Count - 1
            Dim kd As New Word
            If Not ws(i).GetWord = "" Then
                kd.Add(ws(i).GetWord, ws(i).GetLength, ws(i).GetLine, ws(i).GetColumn)
                k.Add(kd)
            End If
        Next

        Return k
    End Function

    Private Function RefineWordList(input As List(Of Word)) As List(Of Word)
        MsgBox(input.Count)
        For i = 0 To input.Count - 1
            If input(i).GetWord = "" Then

            End If
        Next
        Return input
    End Function

End Class

Public Class Word
    Private Word As String
    Private Length As Integer
    Private Line As Integer
    Private Column As Integer

    Public Sub Add(tword As String, tlength As Integer, tline As Integer, tcol As Integer)
        Word = tword : Line = tline : Column = tcol : Length = tlength
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
End Class