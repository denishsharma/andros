Public Class app_container

    Dim loader As New loader
    Private Sub btn1_Click(sender As Object, e As RoutedEventArgs) Handles btn1.Click

        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "\controller.dll")
        Dim ty As Type = a.GetType("controller.RunningAppService.RunningAppMethod")
        Dim ihost As Object = Activator.CreateInstance(ty)
        ihost.SetWindowText(ihost.GetActiveAppID, txt1.Text)

    End Sub

    Private Sub app_cont_Loaded(sender As Object, e As RoutedEventArgs) Handles app_cont.Loaded
        MsgBox(loader.Argument)
    End Sub
End Class
