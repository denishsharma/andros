Imports System.Windows.Media.Animation
Imports System.Windows.Window

Public Class MethodKLB463

    Public Shared Sub Invoke(o As Window)
        Dim c As New C1287
        c.Topmost = True
        c.OwnerWindow = o
        o.Topmost = False
        c.Opacity = 0
        c.Show()
        c.Top = c.Top + 40

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = c.Top - 40}
        c.BeginAnimation(OpacityProperty, d2) : c.BeginAnimation(TopProperty, d3)
    End Sub

End Class
