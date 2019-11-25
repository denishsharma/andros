Module ClassInstance

    Public Function CreateClassInstance(path As String, className As String) As Object
        Return Activator.CreateInstance(Reflection.Assembly.LoadFile(path).GetType(className))
    End Function

End Module
