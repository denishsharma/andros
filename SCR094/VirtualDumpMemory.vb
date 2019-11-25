Imports SCR130
Imports System.Text.RegularExpressions

Public Class VirtualDumpMemory

    Public Shared DumpMemory As New List(Of MemoryBlock)

    Public Shared Sub CreateDumpMemoryLengthOf(length As Integer)
        DumpMemory.Capacity = length
        For i = 0 To length - 1
            DumpMemory.Add(New MemoryBlock(i, ""))
        Next i
    End Sub

    Public Shared Sub CreateMemoryBlock(address As Integer, content As String)
        If address > -1 Then
            If DumpMemory.Count > 0 Then
                Dim mb As MemoryBlock = DumpMemory.Find(Function(a)
                                                            If a.GetMemoryAddress = ConvertIntegerToHex(address) Then
                                                                Return True
                                                            End If
                                                            Return Nothing
                                                        End Function)
                If Not mb Is Nothing Then
                    MsgBox("Address already exist.")
                Else
                    DumpMemory.Add(New MemoryBlock(address, content))
                End If
            Else
                DumpMemory.Add(New MemoryBlock(address, content))
            End If
        End If
    End Sub

    Public Shared Sub RemoveMemoryBlock(address As Integer)
        If Not address = "" Then
            If DumpMemory.Count > 0 Then
                Dim mb As MemoryBlock = DumpMemory.Find(Function(a)
                                                            If ProperHex(a.GetMemoryAddress) = ProperHex(address) Then
                                                                Return True
                                                            End If
                                                            Return Nothing
                                                        End Function)
                If Not mb Is Nothing Then
                    DumpMemory.Remove(mb)
                Else
                    MsgBox("Address doesn't exist.")
                End If
            Else
                MsgBox("Dump Memory is empty.")
            End If
        End If
    End Sub

    Public Shared Sub ExchangeMemoryContent(address1 As String, address2 As String)
        Dim mb1, mb2 As New MemoryBlock : Dim t As String = ""
        For Each mb As MemoryBlock In DumpMemory
            If ProperHex(mb.GetMemoryAddress) = ProperHex(address2) Then
                mb2 = mb
            ElseIf ProperHex(mb.GetMemoryAddress) = ProperHex(address1) Then
                mb1 = mb
            End If
        Next
        t = mb2.GetMemoryContent
        mb2.SetContent(mb1.GetMemoryContent)
        mb1.SetContent(t)
    End Sub

    Public Shared Sub MoveContentToMemoryBlock(address As String, content As String)
        For Each mb As MemoryBlock In DumpMemory
            If ProperHex(mb.GetMemoryAddress) = ProperHex(address) Then
                mb.SetContent(content)
            End If
        Next
    End Sub

    Public Shared Function ReadMemoryContent(address As String) As String
        Dim mb As MemoryBlock = DumpMemory.Find(Function(a)
                                                    If ProperHex(a.GetMemoryAddress) = ProperHex(address) Then
                                                        Return True
                                                    End If
                                                    Return Nothing
                                                End Function)
        If Not mb Is Nothing Then
            Return ConvertHexToString(mb.GetMemoryContent)
        Else
            Return ""
        End If
        Return Nothing
    End Function

    Public Shared Function GetMemoryBlock(address As String) As MemoryBlock
        For Each mb As MemoryBlock In DumpMemory
            If ProperHex(mb.GetMemoryAddress) = ProperHex(address) Then
                Return mb
            End If
        Next
        Return Nothing
    End Function

    Public Shared Function DumpMemoryCount() As Integer
        Return DumpMemory.Count
    End Function

    Public Shared Sub CleanDumpMemory()
        DumpMemory.Clear()
    End Sub

    Public Shared Function ExportDumpMemoryToList() As List(Of String)
        Dim l As New List(Of String)
        For Each mb As MemoryBlock In DumpMemory
            l.Add(ParseMemoryBlock(mb))
        Next
        Return l
    End Function

    Public Shared Sub ClearAndImportFromMemoryData(data As String)
        CleanDumpMemory()
        Dim mc As MatchCollection = Regex.Matches(data, "<MemoryBlock\s*address\s*=\s*\" + """" + "\s*([a-zA-Z]|[a-zA-Z0-9]+)\s*\" + """" + "\s*content\s*=\s*\" + """" + "(.*?)\" + """" + "\s*\/>")
        For Each m As Match In mc
            CreateMemoryBlock(ConvertHexToInteger(m.Groups(1).Value), ConvertHexToString(m.Groups(2).Value))
        Next m
    End Sub

    Public Shared Function CombineContentOf(address As String()) As String
        Dim c As String = ""
        For i = 0 To address.Count - 1
            c += ReadMemoryContent(address(i))
        Next
        Return c
    End Function

    Public Shared Function CombineContentOf(startAddress As String, lengthOfBlock As Integer) As String
        Dim c As String = "" : Dim j As Integer = ConvertHexToInteger(startAddress)
        For i = 0 To lengthOfBlock - 1
            c += ReadMemoryContent(ConvertIntegerToHex(j))
            j += 1
        Next
        Return c
    End Function

End Class
