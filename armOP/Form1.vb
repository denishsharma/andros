Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MsgBox((3 * CInt(10 / 3)) + (10 Mod 3))
        ' Close()

        Dim b, b2 As New Binary(8)
        Dim by, by2 As Byte()
        by = {4} : by2 = {3}
        b.Input("1001")
        b2.Input("10")


        ' b.DoubleBinary = True
        ' b.SetDoubleBinary("2")
        ' MsgBox(b.ReturnAllBinary)

        Dim vdm As Reflection.Assembly = Reflection.Assembly.LoadFile("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Test2\andros\dataconv\bin\Debug\dataconv.dll")
        Dim tyvdm As Type = vdm.GetType("dataconv.Conversion")
        Dim ivdm As Object = Activator.CreateInstance(tyvdm)
        Dim v = 10 << 2
        Console.Write(Convert.ToString(10, 2).PadLeft(Convert.ToString(v, 2).Length, "0"c) + vbNewLine)
        Console.Write(Convert.ToString(v, 2) + vbNewLine + vbNewLine)
        Dim rrv As Integer = 1
        Console.Write(b.ReturnBinaryWithSign + ": " + CStr(ivdm.NumberSystemJuggling(b.ReturnBinaryWithSign, "i<>b")) + vbNewLine)
        Console.Write(b.RotateBitRight(rrv).ReturnBinaryWithSign + ": " + CStr(ivdm.NumberSystemJuggling(b.RotateBitRight(rrv).ReturnBinaryWithSign, "i<>b")) + vbNewLine)
        Console.Write(b2.ReturnBinaryWithSign + ": " + CStr(ivdm.NumberSystemJuggling(b2.ReturnBinaryWithSign, "i<>b")) + vbNewLine)
        ' Console.Write(CStr(b2.LogicalAnd(b).ReturnBinary) + ": " + CStr(ivdm.NumberSystemJuggling(b2.LogicalAnd(b).ReturnBinary, "i<>b")) + vbNewLine)

        ' Console.Write(DivideBinary(b, b2).ReturnAllBinary + ": " + CStr(ivdm.NumberSystemJuggling(DivideBinary(b, b2).ReturnAllBinary, "d<>b")) + vbNewLine)
        Console.Write(DivideBinaryQR(b, b2)(0).ReturnBinary + ": " + CStr(ivdm.NumberSystemJuggling(DivideBinaryQR(b, b2)(0).ReturnBinary, "d<>b")) + vbNewLine)
        Console.Write(DivideBinaryQR(b, b2)(1).ReturnBinary + ": " + CStr(ivdm.NumberSystemJuggling(DivideBinaryQR(b, b2)(1).ReturnBinary, "d<>b")) + vbNewLine)

        Console.WriteLine()
        Console.ReadKey()
    End Sub
End Class
