Imports System.Windows.Media.Animation
Imports System.Windows.Window

Public Class MethodAND028

    Public Shared Sub ShowOverlay()
        Dim o As New ANDoverlay
        Dim w As New ANDwindow
        o.Show()
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(30)), .To = 1}
        AddHandler d1.Completed, Sub()
                                     w.Owner = o
                                     w.Opacity = 0
                                     w.Show()
                                     w.Top = w.Top - 40
                                     Dim t As Double = w.Top + 40
                                     Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = t}
                                     w.BeginAnimation(TopProperty, d2)
                                     Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                                     w.BeginAnimation(OpacityProperty, d3)
                                 End Sub
        o.BeginAnimation(OpacityProperty, d1)
    End Sub

End Class
