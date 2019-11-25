Public Class AndrosDisk

    Public Shared Sub AttachDisk(path As String)
        Dim BatchScriptLines As New List(Of String)
        BatchScriptLines.AddRange({"diskpart", "select vdisk file=" + path, "detach vdisk"})
        WINPROC.ExecuteScript(BatchScriptLines)
    End Sub

    Public Shared Sub DetachDisk(path As String)
        Dim BatchScriptLines As New List(Of String)
        BatchScriptLines.AddRange({"diskpart", "select vdisk file=" + path, "detach vdisk"})
        WINPROC.ExecuteScript(BatchScriptLines)
    End Sub

    Public Shared Sub FormatDisk()
    End Sub

    Public Shared Sub ChangeDiskLetter(letter As String)
    End Sub

    Public Shared Sub CreateVHD(path As String, size As Integer, label As String, letter As String, formatType As String, type As String)
        Dim BatchScriptLines As New List(Of String)
        BatchScriptLines.AddRange({"diskpart", "create vdisk file=" + path + " maximum=" + CStr(size) + " type=" + type,
                                  "select vdisk file=" + path, "attach vdisk", "create partition primary", "format fs=" + formatType + " label=""" + label + """" + " quick", "assign letter=" + letter})
        WINPROC.ExecuteScript(BatchScriptLines)
    End Sub

    Public Shared Sub ExpandDiskSize(path As String, size As Integer)
    End Sub

    Public Shared Sub RemoveVHD(path As String)
    End Sub

End Class
