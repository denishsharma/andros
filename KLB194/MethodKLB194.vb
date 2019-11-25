Imports System.Windows.Media.Animation
Imports System.Windows.Window
Imports System.Windows.Forms

Public Class MethodKLB194

    Public Shared IsOpen As Boolean = False

    Public Shared Sub ShowDateAndTime(o As Controls.UserControl)
        Dim w As New DTwindow
        w.Opacity = 0
        w.OwnerButton = o
        w.Show()
        w.Left = Screen.PrimaryScreen.Bounds.Width - w.Width
        w.Top = Screen.PrimaryScreen.Bounds.Height - (w.Height - 30)
        w.Top = w.Top + 40
        Dim t As Double = w.Top - 110
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = t}
        w.BeginAnimation(TopProperty, d2)
        Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        w.BeginAnimation(OpacityProperty, d3)
        IsOpen = True
    End Sub

    Public Shared Sub CloseDateAndTime()

    End Sub

End Class
