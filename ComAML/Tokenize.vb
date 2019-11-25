Imports System.Text.RegularExpressions

Public Class Tokenize

    Public Shared InstructionDictionary As New Dictionary(Of String, String)

    Private Shared ListOfInstruction As New List(Of Instruction)


    Private CodeLinePatterns() As String = {"([a-zA-Z]+)\s+([a-zA-Z@#]|[a-zA-Z0-9@#]+)\s*,\s*([a-zA-Z@#]|[a-zA-Z0-9@#]+)",
        "([a-zA-Z]+)\s+([a-zA-Z0-9@#\[\]]+)", "(.+)"}

    Public ListOfCodeLine As New List(Of String)

    Public Sub LoadCode(data As String)
        Dim l, m As New List(Of String)
        Dim o() = Split(data, vbNewLine)
        For Each i In o
            l.Add(i)
        Next
        For Each i In l
            If Not String.IsNullOrWhiteSpace(i) Then
                m.Add(i)
            End If
        Next
        ListOfCodeLine = m
    End Sub

    Public Function ProcessOutLine(line As String) As String
        Select Case TypeOfCodeLine(line)
            Case 0
                Dim m As Match = Regex.Match(line, CodeLinePatterns(0), RegexOptions.Singleline)
                Return "Ins: " + m.Groups(1).Value + ", Arg1: " + m.Groups(2).Value + ", Arg2: " + m.Groups(3).Value
            Case 1
                Dim m As Match = Regex.Match(line, CodeLinePatterns(1), RegexOptions.Singleline)
                Return "Ins: " + m.Groups(1).Value + ", Arg1: " + m.Groups(2).Value
            Case 2
                Dim m As Match = Regex.Match(line, CodeLinePatterns(2), RegexOptions.Singleline)
                Return "Ins: " + m.Groups(1).Value
        End Select
        Return Nothing
    End Function

    Public Function TypeOfCodeLine(line As String) As CodeLineTypes
        Dim m1 As Match = Regex.Match(line, CodeLinePatterns(0), RegexOptions.Singleline)
        If m1.Success Then
            Return CodeLineTypes.TwoArgument
        Else
            Dim m2 As Match = Regex.Match(line, CodeLinePatterns(1), RegexOptions.Singleline)
            If m2.Success Then
                Return CodeLineTypes.OneArgument
            Else
                Dim m3 As Match = Regex.Match(line, CodeLinePatterns(2), RegexOptions.Singleline)
                Return CodeLineTypes.NoArgument
            End If
        End If
    End Function

    Public Enum CodeLineTypes
        TwoArgument = 0
        OneArgument = 1
        NoArgument = 2
    End Enum

End Class

Public Class Instruction
    Public Shared Name As String
    Public Shared Type As Tokenize.CodeLineTypes
    Public Shared AddressingMode As String

End Class