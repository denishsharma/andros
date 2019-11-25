Public Class MemoryManagement

End Class

Public Module VirtualMemoryManagement

    Public Function ParseMemoryBlock(mb As MemoryBlock) As String
        If Not mb Is Nothing Then
            Dim a, c As String
            a = mb.MemoryAddress : c = mb.MemoryContent
            Return ("<MemoryBlock address=" + """" + a + """" + " content=" + """" + c + """" + " />")
        Else
            Return Nothing
        End If
    End Function

    Public Function SizeOfBlock(mb As MemoryBlock) As String
        If mb IsNot Nothing Then
            Return CStr(ConvertStringToBinary(mb.MemoryContent).Length) + " bits"
        Else
            Return Nothing
        End If
    End Function

    Public Function ConvertStringToHex(data As String) As String
        Dim i As String = ""
        For Each c As Char In data
            i &= Convert.ToString(Convert.ToInt32(c), 16)
        Next
        Return i.ToUpper
    End Function

    Public Function ConvertStringToBinary(data As String) As String
        Dim bin As New Text.StringBuilder
        For Each ch As Char In ConvertStringToHex(data)
            bin.Append(Convert.ToString(Convert.ToInt32(ch, 16), 2).PadLeft(4, "0"c))
        Next
        Return bin.ToString
    End Function

    Public Function ConvertHexToString(data As String) As String
        Dim com As String = ""
        For x = 0 To data.Length - 1 Step 2
            com &= ChrW(CInt("&H" & data.Substring(x, 2)))
        Next
        Return com
    End Function

    Public Function ConvertBinaryToString(data As String) As String
        Dim Characters As String = System.Text.RegularExpressions.Regex.Replace(data, "[^01]", "")
        Dim ByteArray((Characters.Length / 8) - 1) As Byte
        For Index As Integer = 0 To ByteArray.Length - 1
            ByteArray(Index) = Convert.ToByte(Characters.Substring(Index * 8, 8), 2)
        Next
        Return Text.Encoding.ASCII.GetString(ByteArray)
    End Function

    Public Function ConvertIntegerToHex(int As Integer) As String
        Return Hex(int).PadLeft(8, "0"c)
    End Function

    Public Function ConvertHexToInteger(hex As String) As Integer
        Return Convert.ToInt32(ProperHex(hex), 16)
    End Function

    Public Function ProperHex(hex As String) As String
        Dim s As String = hex.TrimStart("0"c)
        If s = "" Then
            Return "0"
        Else
            Return s
        End If
    End Function

End Module

Public Module VirtualDumpMemoryManagement

    Dim vdm As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Test2\andros\SCR094\bin\Debug\SCR094.dll")
    Dim tyvdm As Type = vdm.GetType("SCR094.VirtualDumpMemory")
    Dim ivdm As Object = Activator.CreateInstance(tyvdm)

    Public Sub CreateDumpMemoryLengthOf(length As Integer)
        ivdm.CreateDumpMemoryLengthOf(length)
    End Sub

    Public Sub CreateMemoryBlock(address As String, content As String)
        ivdm.CreateMemoryBlock(address, content)
    End Sub

    Public Sub RemoveMemoryBlock(address As String)
        ivdm.RemoveMemoryBlock(address)
    End Sub

    Public Sub ExchangeMemoryContent(address1 As String, address2 As String)
        ivdm.ExchangeMemoryContent(address1, address2)
    End Sub

    Public Sub MoveContentToMemoryBlock(address As String, content As String)
        ivdm.MoveContentToMemoryBlock(address, content)
    End Sub

    Public Function ReadMemoryContent(address As String) As String
        Return ivdm.ReadMemoryContent(address)
    End Function

    Public Function DumpMemoryCount() As Integer
        Return ivdm.DumpMemoryCount()
    End Function

    Public Sub CleanDumpMemory()
        ivdm.CleanDumpMemory()
    End Sub

    Public Function GetMemoryBlock(address As String) As MemoryBlock
        Return ivdm.GetMemoryBlock(address)
    End Function

    Public Function ExportDumpMemory() As String
        Dim l As New List(Of String)
        l = ivdm.ExportDumpMemoryToList()
        Dim o As String = ""
        For Each i In l
            o += i + vbNewLine
        Next
        Return o
    End Function

    Public Sub ClearAndImportFromMemoryData(data As String)
        ivdm.ClearAndImportFromMemoryData(data)
    End Sub

    Public Function CombineContentOf(address As String()) As String
        Return ivdm.CombineContentOf(address)
    End Function

    Public Function CombineContentOf(startAddress As String, lengthOfBlock As Integer) As String
        Return ivdm.CombineContentOf(startAddress, lengthOfBlock)
    End Function

End Module


Public Class MemoryBlock
    Public NextMemoryBlockAddress As String
    Public MemoryContent As String
    Public BlockSize As Byte()
    Public MemoryAddress As String

    Sub New()
    End Sub
    Sub New(address As Integer, content As String)
        MemoryContent = ConvertStringToHex(content) : MemoryAddress = ConvertIntegerToHex(address) : BlockSize = Text.Encoding.ASCII.GetBytes(content)
    End Sub

    Public Sub SetContent(content As String)
        MemoryContent = ConvertStringToHex(content)
        BlockSize = Text.Encoding.ASCII.GetBytes(content)
    End Sub

    Public Function GetMemoryAddress() As String
        Return MemoryAddress
    End Function

    Public Function GetMemoryContent() As String
        Return MemoryContent
    End Function

End Class
