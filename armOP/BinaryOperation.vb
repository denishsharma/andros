Public Module BinaryOperation

    Public Function AddBinary(bin1 As Binary, bin2 As Binary) As Binary
        Dim l As Integer = 0
        If bin1.Length >= bin2.Length() Then
            l = bin1.Length
        Else
            l = bin2.Length()
        End If
        Dim nb As New Binary
        Dim i1, i2 As Integer
        i1 = bin1.ToInt32 : i2 = bin2.ToInt32
        Dim ia = i1 + i2

        If ia < 0 Then
            ia = ia * -1
        End If

        Dim a = Convert.ToString(ia, 2).PadLeft(l, "0"c)
        nb.Input(a)

        If i1 + i2 < 0 Then
            nb.IsNegative = True
        Else
            nb.IsNegative = False
        End If

        Return nb
    End Function

    Public Function SubtractBinary(bin1 As Binary, bin2 As Binary) As Binary
        Dim l As Integer = 0
        If bin1.Length >= bin2.Length() Then
            l = bin1.Length
        Else
            l = bin2.Length()
        End If
        Dim nb As New Binary
        Dim i1, i2 As Integer
        i1 = bin1.ToInt32 : i2 = (bin2.ToInt32 * -1)
        Dim ia = i1 + i2

        If ia < 0 Then
            ia = ia * -1
        End If

        Dim a = Convert.ToString(ia, 2).PadLeft(l, "0"c)
        nb.Input(a)

        If i1 + i2 < 0 Then
            nb.IsNegative = True
        Else
            nb.IsNegative = False
        End If

        Return nb
    End Function

    Public Function MultiplyBinary(bin1 As Binary, bin2 As Binary) As Binary
        Dim l As Integer = 0
        If bin1.Length >= bin2.Length() Then
            l = bin1.Length
        Else
            l = bin2.Length()
        End If
        Dim nb As New Binary
        Dim i1, i2 As Integer
        i1 = bin1.ToInt32 : i2 = bin2.ToInt32
        Dim ia = i1 * i2

        If ia < 0 Then
            ia = ia * -1
        End If

        Dim a = Convert.ToString(ia, 2).PadLeft(l, "0"c)
        nb.Input(a)

        If i1 * i2 < 0 Then
            nb.IsNegative = True
        Else
            nb.IsNegative = False
        End If

        Return nb
    End Function

    Public Function DivideBinary(dividend As Binary, divisior As Binary) As Binary
        Dim l As Integer = 0
        If dividend.Length >= divisior.Length() Then
            l = dividend.Length
        Else
            l = divisior.Length()
        End If

        Dim nb As New Binary
        Dim i1, i2 As Integer
        i1 = dividend.ToInt32 : i2 = divisior.ToInt32
        Dim ia As Single = (i1 / i2)

        Dim ans() As String = {"0", "0"}
        If ia < 0 Then
            ia = ia * -1

        End If

        If CStr(ia).Contains(".") Then
            ans = Split(CStr(ia), ".")
            nb.DoubleBinary = True
        Else
            ans = {CStr(ia), "0"}
            nb.DoubleBinary = False
        End If

        Dim a() As String = {Convert.ToString(CInt(ans(0)), 2).PadLeft(l, "0"c), Convert.ToString(CInt(ans(1)), 2)}
        nb.Input(a(0)) : nb.SetDoubleBinary(a(1))

        If i1 / i2 < 0 Then
            nb.IsNegative = True
        Else
            nb.IsNegative = False
        End If

        Return nb
    End Function

    Public Function DivideBinaryQR(dividend As Binary, divisior As Binary) As Binary()
        Dim l As Integer = 0
        If dividend.Length >= divisior.Length() Then
            l = dividend.Length
        Else
            l = divisior.Length()
        End If

        Dim nbq, nbr As New Binary
        Dim i1, i2 As Integer
        i1 = dividend.ToInt32 : i2 = divisior.ToInt32
        If i1 > 0 And i2 > 0 Then
            Dim q As Integer = (i1 / i2)
            Dim r As Integer = i1 Mod i2

            Dim ans() As String = {q, r}

            Dim a() As String = {Convert.ToString(CInt(ans(0)), 2).PadLeft(l, "0"c), Convert.ToString(CInt(ans(1)), 2).PadLeft(l, "0"c)}
            nbq.Input(a(0)) : nbr.Input(a(1))

            nbq.IsNegative = False : nbr.IsNegative = False

            Return {nbq, nbr}
        Else
            Return {New Binary("0"), New Binary("0")}
        End If
    End Function

End Module