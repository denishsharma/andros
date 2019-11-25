Public Class AndrosLicense

    Public ReadOnly IsLicensed As Boolean = False

    Public Shared Sub Activate(key As LicenseArgument)

    End Sub


End Class

Public Class LicenseArgument
    Public Hash As String
    Public Sub SetHash(hashdata As String)
        Hash = hashdata
    End Sub
End Class