Public Class Binary

    Public ReadOnly Property Base As Integer = 2
    Private BinaryLength As Integer = 0
    Private Bits As New BinaryBitArray
    Private _db As String = "0"

    Public Property IsNegative As Boolean = False
    Public Property DoubleBinary As Boolean = False

    Public ReadOnly Property GetDoubleBinary() As String
        Get
            If DoubleBinary = True Then
                Return _db
            End If
            Return "0"
        End Get
    End Property

    Public Sub SetDoubleBinary(bindata As String)
        _db = bindata
    End Sub

    Sub New()

    End Sub
    Sub New(length As Integer)
        BinaryLength = length
    End Sub
    Sub New(inputdata As String)
        Input(inputdata)
    End Sub

    Public Sub Input(data As String)

        Dim s As Boolean
        If data.StartsWith("-") Then
            s = True
            data = data.TrimStart("-")
        End If

        If s = True Then
            IsNegative = True
        Else
            IsNegative = False
        End If

        If BinaryLength > 0 Then
            Dim lb As New BinaryBitArray(BinaryLength)
            data = data.PadLeft(BinaryLength, "0"c)
            Dim bc As Char() = data.ToCharArray(0, BinaryLength)
            For Each b In bc
                If b = "0" Or b = "1" Then
                    lb.Add(b)
                Else
                    Bits = New BinaryBitArray()
                    Exit Sub
                End If
            Next
            Bits = lb
        ElseIf Not BinaryLength > 0 Then
            Dim lb As New BinaryBitArray(data.Length)
            For Each b In data
                If b = "0" Or b = "1" Then
                    lb.Add(b)
                Else
                    Bits = New BinaryBitArray()
                    Exit Sub
                End If
            Next
            Bits = lb
        End If
    End Sub
    Public Sub Input(bytes As Byte())
        Bits = New BinaryBitArray(bytes)
    End Sub
    Public Sub Input(bitarray As BinaryBitArray)
        Bits = bitarray
    End Sub

    Public Function ReturnBinaryWithSign() As String
        If IsNegative = True Then
            Return "-" + Bits.ReturnBits()
        ElseIf IsNegative = False Then
            Return Bits.ReturnBits()
        End If
        Return Nothing
    End Function

    Public Function ReturnAllBinary() As String
        If DoubleBinary = True Then
            Return ReturnBinaryWithSign() + "." + GetDoubleBinary
        ElseIf DoubleBinary = False Then
            Return ReturnBinaryWithSign()
        End If
        Return Nothing
    End Function

    Public Function ReturnBinary() As String
        Return Bits.ReturnBits()
    End Function

    Public Function Count() As Integer
        Return Bits.Count
    End Function

    Public Function Length() As Integer
        Return Bits.Length
    End Function

    Public Function ReturnBitsToList() As List(Of String)
        Return Bits.ReturnBitsToList
    End Function

    Public Sub SetValue(index As Integer, value As Boolean)
        Bits.SetValue(index, value)
    End Sub

    Public Function GetValue(index As Integer) As Boolean
        Return Bits.GetValue(index)
    End Function

    Public Function RotateBitsLeft() As Binary
        Dim nb As New Binary
        nb.Input(Bits.RotateBitsLeft(1))
        Return nb
    End Function

    Public Function RotateBitsLeft(times As Integer) As Binary
        Dim nb As New Binary
        nb.Input(Bits.RotateBitsLeft(times))
        Return nb
    End Function

    Public Function RotateBitRight() As Binary
        Dim nb As New Binary
        nb.Input(Bits.RotateBitRight(1))
        Return nb
    End Function

    Public Function RotateBitRight(times As Integer) As Binary
        Dim nb As New Binary
        nb.Input(Bits.RotateBitRight(times))
        Return nb
    End Function

    Public Function LogicalAnd(bin As Binary) As Binary
        Dim l As Integer = 0
        Dim d1, d2 As String : d1 = "" : d2 = ""
        If Length() >= bin.Length() Then
            l = Length()
            d1 = ReturnBinary()
            d2 = bin.ReturnBinary.PadLeft(l, "0"c)
        Else
            l = bin.Length()
            d2 = bin.ReturnBinary()
            d1 = ReturnBinary.PadLeft(l, "0"c)
        End If

        Dim nb1, nb2, nb As New Binary(l)
        Dim ba As New BinaryBitArray(l)
        nb1.Input(d1) : nb2.Input(d2)


        For i = 0 To l - 1
            If nb1.GetValue(i) = True And nb2.GetValue(i) = True Then
                ba.Add("1")
            Else
                ba.Add("0")
            End If
        Next

        nb.Input(ba)

        Return nb
    End Function

    Public Function LogicalOr(bin As Binary) As Binary
        Dim l As Integer = 0
        Dim d1, d2 As String : d1 = "" : d2 = ""
        If Length() >= bin.Length() Then
            l = Length()
            d1 = ReturnBinary()
            d2 = bin.ReturnBinary.PadLeft(l, "0"c)
        Else
            l = bin.Length()
            d2 = bin.ReturnBinary()
            d1 = ReturnBinary.PadLeft(l, "0"c)
        End If

        Dim nb1, nb2, nb As New Binary(l)
        Dim ba As New BinaryBitArray(l)
        nb1.Input(d1) : nb2.Input(d2)


        For i = 0 To l - 1
            If nb1.GetValue(i) = False And nb2.GetValue(i) = False Then
                ba.Add("0")
            Else
                ba.Add("1")
            End If
        Next

        nb.Input(ba)

        Return nb
    End Function

    Public Function LogicalXor(bin As Binary) As Binary
        Dim l As Integer = 0
        Dim d1, d2 As String : d1 = "" : d2 = ""
        If Length() >= bin.Length() Then
            l = Length()
            d1 = ReturnBinary()
            d2 = bin.ReturnBinary.PadLeft(l, "0"c)
        Else
            l = bin.Length()
            d2 = bin.ReturnBinary()
            d1 = ReturnBinary.PadLeft(l, "0"c)
        End If

        Dim nb1, nb2, nb As New Binary(l)
        Dim ba As New BinaryBitArray(l)
        nb1.Input(d1) : nb2.Input(d2)


        For i = 0 To l - 1
            If (nb1.GetValue(i) = False And nb2.GetValue(i) = False) Or (nb1.GetValue(i) = True And nb2.GetValue(i) = True) Then
                ba.Add("0")
            Else
                ba.Add("1")
            End If
        Next

        nb.Input(ba)

        Return nb
    End Function

    Public Function LogicalNot() As Binary
        Dim b As New Binary(Length)
        b.Input(Bits.LogicalNot)
        Return b
    End Function

    Public Function IsNullBinary() As Boolean
        Dim i As Integer = ReturnBinary()
        If i = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ToInt32() As Integer
        Dim s As Boolean
        Dim data = ReturnBinaryWithSign()
        If data.StartsWith("-") Then
            s = True
            data = data.TrimStart("-")
        End If

        If s = True Then
            Return (0 - Convert.ToInt32(Data, 2))
        Else
            Return Convert.ToInt32(Data, 2)
        End If
    End Function

End Class


Public Class BinaryBitArray

    Private ArrayLength As Integer
    Private bits As New List(Of String)
    Private ba As New BitArray(ArrayLength)

    Sub New()

    End Sub
    Sub New(length As Integer)
        bits.Capacity = length
        ArrayLength = length
    End Sub
    Sub New(bytes As Byte())
        ba = New BitArray(bytes)

        For i = 0 To ba.Count - 1
            If ba(ba.Count - 1 - i) = True Then
                Add("1")
            ElseIf ba(ba.Count - 1 - i) = False Then
                Add("0")
            End If
        Next
    End Sub

    Public Function Count() As Integer
        Return bits.Count
    End Function

    Public Function Length() As Integer
        Return bits.Capacity
    End Function

    Public Sub Add(input As String)
        bits.Add(input)
    End Sub

    Public Function ReturnBitsToList() As List(Of String)
        Return bits
    End Function

    Public Function RotateBitsLeft(times As Integer) As BinaryBitArray
        Dim ba As New List(Of String)
        Dim nba As New BinaryBitArray(Length)
        ba = bits.Skip(times).Concat(bits.Take(times)).ToList
        For Each b In ba
            nba.Add(b)
        Next
        Return nba
    End Function

    Public Function RotateBitRight(times As Integer) As BinaryBitArray
        Dim t As Integer = 0
        If Length() - times < 0 Then
            t = Length() - ((Length() - times) * -1)
        Else
            t = Length() - times
        End If
        Return RotateBitsLeft(t)
    End Function

    Public Sub SetValue(index As Integer, value As Boolean)
        If value = True Then
            bits(index) = "1"
        ElseIf value = False Then
            bits(index) = "0"
        End If
    End Sub

    Public Function GetValue(index As Integer) As Boolean
        If bits(index) = "1" Then
            Return True
        ElseIf bits(index) = "0" Then
            Return False
        End If
        Return Nothing
    End Function

    Public Function LogicalNot() As BinaryBitArray
        Dim ba As New BinaryBitArray(Length)
        For Each bit In bits
            If bit = "1" Then
                ba.Add("0")
            ElseIf bit = "0" Then
                ba.Add("1")
            End If
        Next
        Return ba
    End Function

    Public Function ReturnBits() As String
        Dim b As String = ""
        For Each bit In bits
            b += bit
        Next
        Return b
    End Function


End Class