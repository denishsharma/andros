Public Class Conversion

    Public Shared Function NumberSystemJuggling(data As Object, juggling As String)
        Try
            Select Case juggling
                Case "i<>b"
                    If TypeOf data Is Integer Then
                        Return Convert.ToString(data, 2)
                    ElseIf TypeOf data Is String Then
                        Dim s As Boolean
                        If data.StartsWith("-") Then
                            s = True
                            data = data.TrimStart("-")
                        End If

                        Dim ans() As String = {"0", "0"}
                        Dim d As Double
                        If data.contains(".") Then
                            ans = Split(data, ".")
                        Else
                            ans = {data, "0"}
                        End If

                        d = Convert.ToInt32(ans(0), 2)
                        If s = True Then
                            Return (d * -1)
                        Else
                            Return (d)
                        End If
                    End If
                Case "d<>b"
                    If TypeOf data Is Integer Then
                        Return Convert.ToString(data, 2)
                    ElseIf TypeOf data Is String Then
                        Dim s As Boolean
                        If data.StartsWith("-") Then
                            s = True
                            data = data.TrimStart("-")
                        End If

                        Dim ans() As String = {"0", "0"}
                        Dim d As Double
                        If data.contains(".") Then
                            ans = Split(data, ".")
                        Else
                            ans = {data, "0"}
                        End If

                        d = CDbl(Convert.ToInt32(ans(0), 2) & "." & Convert.ToInt32(ans(1), 2))

                        If s = True Then
                            Return (d * -1)
                        Else
                            Return (d)
                        End If
                    End If
                Case "i<>h"
                    If TypeOf data Is Integer Then
                        Return Convert.ToString(data, 16)
                    ElseIf TypeOf data Is String Then
                        Return Convert.ToInt32(data, 16)
                    End If
                Case "i<>c"
                    If TypeOf data Is Integer Then
                        Return Convert.ToString(data, 8)
                    ElseIf TypeOf data Is String Then
                        Return Convert.ToInt32(data, 8)
                    End If
                Case "b<>h"
                    If TypeOf data Is String And data.EndsWith("b") Then
                        Return Hex(Convert.ToInt32(CStr(data).TrimEnd("b"), 2))
                    ElseIf TypeOf data Is String And data.EndsWith("h") Then
                        Return Convert.ToString(Convert.ToInt32(CStr(data).TrimEnd("h"), 16), 2)
                    End If
                Case "b<>c"
                    If TypeOf data Is String And data.EndsWith("b") Then
                        Return Convert.ToString(Convert.ToInt32(CStr(data).TrimEnd("b"), 2), 8)
                    ElseIf TypeOf data Is String And data.EndsWith("c") Then
                        Return Convert.ToString(Convert.ToInt32(CStr(data).TrimEnd("c"), 8), 2)
                    End If
                Case "h<>c"
                    If TypeOf data Is String And data.EndsWith("h") Then
                        Return Convert.ToString(Convert.ToInt32(CStr(data).TrimEnd("h"), 16), 8)
                    ElseIf TypeOf data Is String And data.EndsWith("c") Then
                        Return Convert.ToString(Convert.ToInt32(CStr(data).TrimEnd("c"), 8), 16)
                    End If
            End Select
        Catch ex As Exception
            Return ex.Message
        End Try
        Return Nothing
    End Function

    Public Shared Function CharactersJuggling()
        Return Nothing
    End Function

End Class

