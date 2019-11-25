Public Class AppFormService

    Public Class AppMethodInstance

        Private host As Object
        Private Property appID As String
        Private Property appGUID As String
        ''' <summary>
        ''' Controller must be in same directory.
        ''' </summary>
        Sub New()
            Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "\controller.dll")
            Dim ty As Type = a.GetType("controller.RunningAppService.RunningAppMethod")
            host = Activator.CreateInstance(ty)
        End Sub
        ''' <summary>
        ''' Specify the path of controller.
        ''' </summary>
        ''' <param name="controllerPath">File path of controller</param>
        Sub New(controllerPath As String)
            Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(controllerPath)
            Dim ty As Type = a.GetType("controller.RunningAppService.RunningAppMethod")
            host = Activator.CreateInstance(ty)
        End Sub

        ''' <summary>
        ''' Get active App ID.
        ''' </summary>
        ''' <returns>App ID of Focused App</returns>
        Public Function GetActiveAppID() As String
            Return host.GetActiveAppID
        End Function

        ''' <summary>
        ''' Get tite of window or app.
        ''' </summary>
        ''' <returns>Window Title of Focused App</returns>
        Public Function GetWindowText() As String
            Return host.GetWindowText(appID)
        End Function
        ''' <summary>
        ''' Get tite of window or app.
        ''' </summary>
        ''' <param name="appid">AppID of window or app.</param>
        ''' <returns>Window Title of Focused App</returns>
        Public Function GetWindowText(appid As String) As String
            Return host.GetWindowText(appid)
        End Function

        ''' <summary>
        ''' Load App ID of Focused App in Instance.
        ''' </summary>
        Public Sub LoadActiveAppID()
            appID = host.GetActiveAppID()
            appGUID = host.GetRunningAppGUID(appID)
        End Sub

        ''' <summary>
        ''' Check if app is running.WW
        ''' </summary>
        ''' <returns></returns>
        Public Function IsAppRunning() As Boolean
            Return host.IsAppRunning(appID)
        End Function
        ''' <summary>
        ''' Check if app is running.
        ''' </summary>
        ''' <returns></returns>
        Public Function IsAppRunning(appid As String) As Boolean
            Return host.IsAppRunning(appid)
        End Function
    End Class

End Class
