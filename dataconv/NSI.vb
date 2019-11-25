Imports System.Text.RegularExpressions

Public Class NSI

    'Binary: ([10]+)(b|B)       ; 10101b
    'Octal: ([0-9]+)(c|C)       ; 12321c
    'Hexadecimal: ([0-9A-Fa-f]+)(h|H)       ; 0Ah
    'Integer: ([0-9]+)(i|I|)        ; 123 123i
    'Float: (^\d*\.?\d*)(f|F|)       ; 12.028 12.028f

    Private Shared pattern() As String = {"(^[10]+)(b|B)", "(^[0-9]+)(c|C)", "(^[0-9A-Fa-f]+)(h|H)", "(^[0-9]+)(i|I|)", "(^\d*\.\d{0,6})(f|F|)", "(^\d*\.\d{0,6})(iru|IRU|ird|IRD|imf|IMF)(\d*)"}

    Public Shared Function Identify(data As String) As String()
        Try
            Dim d() As String = {"", ""}
            If data.StartsWith("+") Or data.StartsWith("-") Then
                d = {data.Substring(0, 1), data.Remove(0, 1)}
            Else
                d = {"", data}
            End If

            If d(1).EndsWith("f") Or d(1).EndsWith("F") Then
                If Regex.IsMatch(d(1), pattern(4)) Then
                    If Regex.Match(d(1), pattern(4)).Groups(1).Value.StartsWith(".") Then
                        Return {d(0) + "0" + Regex.Match(d(1), pattern(4)).Groups(1).Value, "F"}
                    ElseIf Regex.Match(d(1), pattern(4)).Groups(1).Value.EndsWith(".") Then
                        Return {CDbl(d(0) + Regex.Match(d(1), pattern(4)).Groups(1).Value + "0"), "F"}
                    Else
                        Return {CDbl(d(0) + Regex.Match(d(1), pattern(4)).Groups(1).Value), "F"}
                    End If
                Else
                    d(1) = d(1).Substring(0, d(1).Length - 1) + ".0F"
                    Return {d(0) + Regex.Match(d(1), pattern(4)).Groups(1).Value, "F"}
                End If
                Exit Function
            ElseIf d(1).EndsWith("i") Or d(1).EndsWith("I") Then
                If d(1).StartsWith(".") Then
                    d(1) = "0" + d(1)
                End If

                If Regex.IsMatch(d(1), pattern(3)) Then
                    Return {CInt(d(0) + Regex.Match(d(1), pattern(3)).Groups(1).Value), "I"}
                End If
                Exit Function

            ElseIf d(1).EndsWith("iru") Or d(1).EndsWith("IRU") Then
                If d(1).StartsWith(".") Then
                    d(1) = "0" + d(1)
                End If

                If Regex.IsMatch(d(1), pattern(4)) Then
                    Return {CInt(Math.Ceiling(CDec(d(0) + Regex.Match(d(1), pattern(5)).Groups(1).Value))), "I"}
                End If
                Exit Function

            ElseIf d(1).EndsWith("ird") Or d(1).EndsWith("IRD") Then
                If d(1).StartsWith(".") Then
                    d(1) = "0" + d(1)
                End If

                If Regex.IsMatch(d(1), pattern(4)) Then
                    Return {CInt(Math.Floor(CDec(d(0) + Regex.Match(d(1), pattern(5)).Groups(1).Value))), "I"}
                End If
                Exit Function


            ElseIf d(1).Contains("imf") Or d(1).Contains("IMF") Then
                If d(1).StartsWith(".") Then
                    d(1) = "0" + d(1)
                End If
                Dim m As Integer = 0

                If Regex.IsMatch(d(1), pattern(5)) Then
                    If Not Regex.Match(d(1), pattern(5)).Groups(3).Value = "" Then
                        m = CInt(Regex.Match(d(1), pattern(5)).Groups(3).Value)
                    Else
                        m = 0
                    End If

                    Dim pv As String = ""
                    Dim iv As Integer = 0
                    iv = CInt(Value(Regex.Match(d(1), pattern(5)).Groups(1).Value + "i"))
                    pv = Regex.Match(Regex.Match(d(1), pattern(5)).Groups(1).Value, ".\d+$").Value
                    iv = iv * m
                    Return {d(0) + CStr(iv) + pv, "F"}

                End If
                Exit Function

                ' Binary, Octal, Hex
            ElseIf data.EndsWith("c") Or data.EndsWith("C") Then
                If Regex.IsMatch(data, pattern(1)) Then
                    Return {Regex.Match(data, pattern(1)).Groups(1).Value, "C"}
                End If
                Return {"Not Octal", "ERROR"}
                Exit Function
            ElseIf data.EndsWith("b") Or data.EndsWith("B") Then
                If Regex.IsMatch(data, pattern(0)) Then
                    Return {Regex.Match(data, pattern(0)).Groups(1).Value, "B"}
                End If
                Return {"Not Binary", "ERROR"}
                Exit Function
            ElseIf data.EndsWith("h") Or data.EndsWith("H") Then
                If Regex.IsMatch(data, pattern(2)) Then
                    Return {Regex.Match(data, pattern(2)).Groups(1).Value, "H"}
                End If
                Return {"Not Hexadecimal", "ERROR"}
                Exit Function
            End If


            If d(1).StartsWith(".") OrElse d(1).Contains(".") AndAlso Not d(1).EndsWith(".") Then
                If Regex.IsMatch(d(1), pattern(4)) Then
                    If Regex.Match(d(1), pattern(4)).Groups(1).Value.StartsWith(".") Then
                        Return {d(0) + "0" + Regex.Match(d(1), pattern(4)).Groups(1).Value, "F"}
                    Else
                        Return {d(0) + Regex.Match(d(1), pattern(4)).Groups(1).Value, "F"}
                    End If
                Else
                    d(1) = d(1).Substring(0, d(1).Length - 1) + ".0F"
                    Return {Regex.Match(d(1), pattern(4)).Groups(1).Value, "F"}
                End If
                Exit Function
            ElseIf d(1).EndsWith(".") OrElse d(1).EndsWith("") Then
                If Regex.IsMatch(d(1), pattern(3)) Then
                    Return {d(0) + Regex.Match(d(1), pattern(3)).Groups(1).Value, "I"}
                End If
                Exit Function
            End If
        Catch ex As Exception
            Return {"Not", ""}
        End Try
    End Function

    Public Shared Function Value(data As String) As String
        Try
            Return Identify(data)(0)
        Catch ex As Exception
            Return "Cannot parse value."
        End Try
    End Function

    Public Shared Function Type(data As String) As String
        Try
            Return Identify(data)(1)
        Catch ex As Exception
            Return "Cannot identify type"
        End Try
    End Function

End Class