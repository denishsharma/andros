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
        AppContainer(appc)
        WindowHeight(340)
        WindowWidth(340)
    End Sub

End Class
