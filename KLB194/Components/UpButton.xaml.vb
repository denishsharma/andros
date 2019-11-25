Imports System.Windows.Media.Animation

Public Class UpButton

    Private Sub FrontRect_MouseEnter(sender As Object, e As MouseEventArgs) Handles frontRect.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.03}
        hoverCircle.BeginAnimation(OpacityProperty, d1)

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .From = 0, .To = 28}
        hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
    End Sub

    Private Sub frontRect_MouseLeave(sender As Object, e As MouseEventArgs) Handles frontRect.MouseLeave
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(150)), .To = 0}
        hoverCircle.BeginAnimation(OpacityProperty, d1)

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(150)), .To = 0}
        hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
    End Sub

    Private Sub FrontRect_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles frontRect.MouseDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(1)), .To = 0.1}
        hoverCircle.BeginAnimation(OpacityProperty, d1)

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(1)), .To = 32}
        hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
    End Sub

    Private Sub frontRect_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles frontRect.MouseUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.03}
        hoverCircle.BeginAnimation(OpacityProperty, d1)

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 28}
        hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
    End Sub
End Class
