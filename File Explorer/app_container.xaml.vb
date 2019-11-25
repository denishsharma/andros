Public Class app_container

    Public Property ar As String = "Argu"


    Private Sub app_cont_Loaded(sender As Object, e As RoutedEventArgs) Handles app_cont.Loaded
        Dim load As New loader
        lbl1.Content = ar
    End Sub
End Class
