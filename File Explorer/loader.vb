Imports wap
Imports wap.ExternalAppService

Public Class loader
    Inherits EAPHostContainerControl
    Implements EAPHostContainer

    Public Property HostContainer As EAPHostContainerControl Implements EAPHostContainer.HostContainer
        Get
            Return Me
        End Get
        Set(value As EAPHostContainerControl)
        End Set
    End Property

    Public Sub LoadSettings() Implements EAPHostContainer.LoadSettings
        Dim appc As New app_container
        appc.ar = Argument
        AppContainer(appc)
        WindowHeight(640)
        WindowWidth(940)
    End Sub

End Class
