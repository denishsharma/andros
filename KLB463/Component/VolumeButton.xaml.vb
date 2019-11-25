Imports System.Windows.Media.Animation

Public Class VolumeButton
    Private Sub SBfront_MouseEnter(sender As Object, e As MouseEventArgs) Handles SBfront.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0.2
    End Sub

    Private Sub SBfront_MouseLeave(sender As Object, e As MouseEventArgs) Handles SBfront.MouseLeave
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0
    End Sub

    Private Sub SBfront_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0.2
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0
    End Sub

    Private Sub SBfront_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseLeftButtonDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0.2
    End Sub
End Class
