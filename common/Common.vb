Imports common.DefineRoots

Public Class Common

    Private AndrosSystemRootDirectory As String = FileSystem.Define(FileSystem.FileSystemDefinitions.AndrosSystemRoot)
    Private VersionHost, DataConversionHost As Object

    ''' <summary>
    ''' Required files must be in Andros System Root directory.
    ''' </summary>
    Sub New()
        VersionHost = CreateClassInstance(AndrosSystemRootDirectory + "version.dll", "version.version")
        DataConversionHost = CreateClassInstance(AndrosSystemRootDirectory + "Resources\dataconv.dll", "dataconv.Conversion")
    End Sub

    Public Function NumberSystemJuggling(data As Object, type As NSJugglingTypes) As Object
        Select Case type
            Case 0
                Return DataConversionHost.NumberSystemJuggling(data, "i<>b")
            Case 1
                Return DataConversionHost.NumberSystemJuggling(data, "d<>b")
            Case 2
                Return DataConversionHost.NumberSystemJuggling(data, "i<>h")
            Case 3
                Return DataConversionHost.NumberSystemJuggling(data, "i<>c")
            Case 4
                Return DataConversionHost.NumberSystemJuggling(data, "b<>h")
            Case 5
                Return DataConversionHost.NumberSystemJuggling(data, "b<>c")
            Case 6
                Return DataConversionHost.NumberSystemJuggling(data, "h<>c")
        End Select
        Return Nothing
    End Function

    Enum NSJugglingTypes
        IntegerOrBinary = 0
        DoubleOrBinary = 1
        IntegerOrHex = 2
        IntegerOrOctal = 3
        BinaryOrHex = 4
        BinaryOrOctal = 5
        HexOrOctal = 6
    End Enum

    Public Function GetAndrosSystemVersion() As String
        Return VersionHost.Version()
    End Function

End Class

Public Module CommonMethods

    Public Function CreateClassInstance(path As String, className As String) As Object
        Return Activator.CreateInstance(Reflection.Assembly.LoadFile(path).GetType(className))
    End Function

End Module