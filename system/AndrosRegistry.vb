Public Module AndrosRegistry

    Public Sub CreateSubKey(subKey As String)
        My.Computer.Registry.CurrentUser.CreateSubKey(subKey)
    End Sub

    Public Sub SetValue(keyName As String, valueName As String, value As Object)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" + keyName, valueName, value)
    End Sub

    Public Function GetValue(keyName As String, valueName As String) As Object
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\" + keyName, valueName, Nothing) IsNot Nothing Then
            Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\" + keyName, valueName, Nothing)
        Else
            Return "Value does not exist."
        End If
    End Function

    Public Sub DeleteSubKey(subKey As String)
        My.Computer.Registry.CurrentUser.DeleteSubKey(subKey)
    End Sub

End Module
