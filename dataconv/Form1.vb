Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim d As String = "-1.1i"
        'MsgBox(NSI.Value(d) + ", " + NSI.Type(d))
        'Close()
        'MsgBox(Conversion.NumberSystemJuggling(10, "i<>c"))

        'creating two  bit arrays of size 8
        Dim ba1 As BitArray = New BitArray(8)
        Dim ba2 As BitArray = New BitArray(16)
        Dim a() As Byte = {255}
        Dim b() As Byte = {1}
        'storing the values 60, and 13 into the bit arrays
        ba1 = New BitArray(a)
        ba2 = New BitArray(b)
        'content of ba1
        Console.WriteLine("Bit array ba1: 1")
        Dim i As Integer

        For i = 0 To ba1.Count - 1
            Console.Write("{0 } ", ba1(i))
        Next i
        Console.WriteLine()
        'content of ba2
        Console.WriteLine("Bit array ba2: 1")

        For i = 0 To ba2.Count - 1
            Console.Write("{0 } ", ba2(i))
        Next i
        Console.WriteLine()
        Dim ba3 As BitArray = New BitArray(8)
        ba3 = ba1.And(ba2)
        'content of ba3
        Console.WriteLine("Bit array ba3 after AND operation: 12")

        For i = 0 To ba3.Count - 1
            Console.Write("{0 } ", ba3(i))
        Next i
        Console.WriteLine()
        ba3 = ba1.Or(ba2)
        'content of ba3
        Console.WriteLine("Bit array ba3 after OR operation: 61")

        For i = 0 To ba3.Count - 1
            Console.Write("{0 } ", ba3(i))
        Next i
        Console.WriteLine()
        Console.ReadKey()
    End Sub
End Class