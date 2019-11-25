Public Class WINPROC

    Public Shared Function ExecuteScript(ByVal BatchScriptLines As List(Of String)) As String
        Dim OutputString As String = String.Empty
        Using Process As New Process
            AddHandler Process.OutputDataReceived, Sub(sendingProcess As Object, outLine As DataReceivedEventArgs)
                                                       OutputString = OutputString & outLine.Data & vbCrLf
                                                   End Sub
            Process.StartInfo.FileName = "cmd"
            Process.StartInfo.UseShellExecute = False
            Process.StartInfo.CreateNoWindow = True
            Process.StartInfo.RedirectStandardInput = True
            Process.StartInfo.RedirectStandardOutput = True
            Process.StartInfo.RedirectStandardError = True
            Process.Start()
            Process.BeginOutputReadLine()
            Using InputStream As system.IO.StreamWriter = Process.StandardInput
                InputStream.AutoFlush = True
                For Each ScriptLine As String In BatchScriptLines
                    InputStream.Write(ScriptLine & vbCrLf)
                Next
            End Using
            Do
                Application.DoEvents()
            Loop Until Process.HasExited
        End Using
        Return OutputString
    End Function

    Public Shared Function ExecuteDiskPartScript(ByVal BatchScriptLines As List(Of String)) As String
        Dim l As New List(Of String)
        l.Add("diskpart") : l.AddRange(BatchScriptLines.ToArray)
        Return ExecuteScript(l)
    End Function

End Class