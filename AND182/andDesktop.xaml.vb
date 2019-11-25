Imports controller.RunningAppService

Class andDesktopWindow
    Private Sub andDesktopWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim l As New List(Of List(Of String))
        l = WapService.GetAppsFromDirToListOfApps("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Test2\andros\andros\bin\Debug\Apps\")

        For Each m As List(Of String) In l
            Dim a As New DesktopIcon
            a.Text = m(0) : a.FullPathOfApp = m(1) : a.IconType = 1
            appCont.Children.Add(a)
        Next

        Dim d As New IO.DirectoryInfo("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Andros\Andros\")
        For Each m As IO.DirectoryInfo In d.GetDirectories
            Dim a As New DesktopIcon
            a.Text = m.Name : a.IconType = 0
            appCont.Children.Add(a)
        Next

        Dim dl As New List(Of DesktopIcon)
        For Each dm As DesktopIcon In appCont.Children
            dl.Add(dm)
        Next

        For Each dm As DesktopIcon In appCont.Children
            dm.ListOfDesktopIcons = dl
        Next
    End Sub

    Private Sub andDesktopWindow_Deactivated(sender As Object, e As EventArgs) Handles Me.Deactivated
        For Each dm As DesktopIcon In appCont.Children
            If dm.isc = False Then
                dm.MakeFasle()
            End If
        Next
    End Sub

    Private Sub AppContBack_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles appContBack.MouseDown
        For Each dm As DesktopIcon In appCont.Children
            If dm.isc = False Then
                dm.MakeFasle()
            End If
        Next
    End Sub

    Private Sub AppContBack_MouseRightButtonUp(sender As Object, e As MouseButtonEventArgs) Handles appContBack.MouseRightButtonUp
        Dim cm As New DesktopCM
        cm.ShowMenu(e.GetPosition(Me).X, e.GetPosition(Me).Y, Me)
    End Sub
End Class

