Imports System.Windows.Media.Animation

Public Class ANDwindow
    Private Sub ANDWwindow_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles ANDWwindow.Closing

        CloseWindow()
    End Sub

    Private Sub ANDWwindow_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles ANDWwindow.MouseLeftButtonUp

    End Sub

    Public Sub CloseWindow()
        Dim o As Window = Owner
        Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(40)), .To = 0}
        AddHandler d3.Completed, Sub()
                                     Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(30)), .To = 0}
                                     AddHandler d1.Completed, Sub()
                                                                  o.Close()
                                                              End Sub
                                     o.BeginAnimation(OpacityProperty, d1)
                                 End Sub
        BeginAnimation(OpacityProperty, d3)

    End Sub

    Private Sub ANDWwindow_MouseRightButtonUp(sender As Object, e As MouseButtonEventArgs) Handles ANDWwindow.MouseRightButtonUp
        CloseWindow()
    End Sub

    Private Sub HeaderRect_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles headerRect.MouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub ANDWwindow_Loaded(sender As Object, e As RoutedEventArgs) Handles ANDWwindow.Loaded
        Dim n As New List(Of RadioButton)
        n.AddRange({rb1, rb2, rb3})
        rb1.ListOfRadioButons = n
    End Sub

    Private Sub Tb2_ToogleStateChanged() Handles tb2.ToogleStateChanged
        If tb2.IsTrue = True Then
            tb1.Enabled = True
        Else
            tb1.Enabled = False
        End If
    End Sub

End Class
