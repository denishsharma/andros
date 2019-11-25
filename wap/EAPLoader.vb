Public Class EAPLoader



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="apppath">Path of an app.</param>
    ''' <param name="host">EAPHost</param>
    Public Sub LoadEAP(apppath As String, host As EAPHost)
        Dim dt As ExternalAppService.AppDataFile = LoadDataFile(apppath)
        Dim app As Reflection.Assembly = Reflection.Assembly.LoadFile(apppath)
        Dim ai As ExternalAppService.EAPHostContainer = CType(app.CreateInstance(dt.AppType, True), ExternalAppService.EAPHostContainer)
        ai.HostContainer.Argument = ""
        ai.LoadSettings()
        Dim ihost As New Forms.Integration.WindowsFormsHost()
        ai.HostContainer._AppContainer.Margin = New Thickness(0, 0, 0, 0)
        Forms.Integration.ElementHost.EnableModelessKeyboardInterop(host)
        host.Width = ai.HostContainer.widthx + 22
        host.Height = ai.HostContainer.heighty + 52
        If ai.HostContainer._AppContainer.MinHeight < 52 Then
            host.EAPContainer.Children.Add(ai.HostContainer._AppContainer)
            host.MinHeight = 78
        Else
            host.MinHeight = ai.HostContainer._AppContainer.MinHeight + 52
        End If
        If ai.HostContainer._AppContainer.MinWidth < 300 Then
            host.MinWidth = 300
        Else
            host.MinWidth = ai.HostContainer._AppContainer.MinWidth + 22
        End If
        host.AppTitle = ai.HostContainer.WindowText
        host.AppID = ai.HostContainer.AppID
        host._appguid = ai.HostContainer._appguid
        host.AppName = ai.HostContainer.AppName
        host.AppVersion = ai.HostContainer.AppVersion
        host.AppIcon = ai.HostContainer.AppIcon
        host.AppDeveloper = ai.HostContainer.AppDeveloper
        host.Show()
    End Sub
    Public Sub LoadEAP(apppath As String, host As EAPHost, arg As String)
        Dim dt As ExternalAppService.AppDataFile = LoadDataFile(apppath)
        Dim app As Reflection.Assembly = Reflection.Assembly.LoadFile(apppath)
        Dim ai As ExternalAppService.EAPHostContainer = CType(app.CreateInstance(dt.AppType, True), ExternalAppService.EAPHostContainer)
        ai.HostContainer._Argument = arg
        ai.LoadSettings()
        Dim ihost As New Forms.Integration.WindowsFormsHost()
        ai.HostContainer._AppContainer.Margin = New Thickness(0, 0, 0, 0)
        Forms.Integration.ElementHost.EnableModelessKeyboardInterop(host)
        host.Width = ai.HostContainer.widthx + 22
        host.Height = ai.HostContainer.heighty + 52
        If ai.HostContainer._AppContainer.MinHeight < 52 Then
            host.EAPContainer.Children.Add(ai.HostContainer._AppContainer)
            host.MinHeight = 78
        Else
            host.MinHeight = ai.HostContainer._AppContainer.MinHeight + 52
        End If
        If ai.HostContainer._AppContainer.MinWidth < 300 Then
            host.MinWidth = 300
        Else
            host.MinWidth = ai.HostContainer._AppContainer.MinWidth + 22
        End If
        host.AppTitle = ai.HostContainer.WindowText
        host.AppID = ai.HostContainer.AppID
        host._appguid = ai.HostContainer._appguid
        host.AppName = ai.HostContainer.AppName
        host.AppVersion = ai.HostContainer.AppVersion
        host.AppIcon = ai.HostContainer.AppIcon
        host.AppDeveloper = ai.HostContainer.AppDeveloper
        host.Show()
    End Sub

    Public Shared Function LoadDataFile(path As String) As ExternalAppService.AppDataFile
        Dim fsFile As IO.FileStream = Nothing
        Dim decoder As Runtime.Serialization.Formatters.Binary.BinaryFormatter = Nothing
        Try
            fsFile = IO.File.Open(path & ".dt", IO.FileMode.Open, IO.FileAccess.Read)
            decoder = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Return CType(decoder.Deserialize(fsFile), ExternalAppService.AppDataFile)
        Finally
            If (Not IsNothing(fsFile)) Then
                fsFile.Dispose()
            End If
        End Try
    End Function

End Class
