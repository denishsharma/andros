Imports System.Windows.Forms
Imports System.Windows.Media.Animation

Public Class SortByCM
    Dim wd As Window

    Private Sub RectBack_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles rectBack.MouseDown
        CloseMenu()
    End Sub

    Public Sub CloseMenu()
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        AddHandler d2.Completed, Sub()
                                     Close()
                                     wd.Tag = 0
                                 End Sub
        BeginAnimation(OpacityProperty, d2)
    End Sub

    Public Sub ShowMenu(x As Double, y As Double, w As Window)
        Dim l, t, rl, rt As Double
        l = w.Left - 10 + w.Width - 15 : t = w.Top + y - 20

        rl = (l + Width - 10) - Screen.PrimaryScreen.Bounds.Width : rt = (t + Height + 30) - Screen.PrimaryScreen.Bounds.Height

        If rl >= 0 Then
            l = Screen.PrimaryScreen.Bounds.Width - (Width - 10)
        End If

        If rt > 0 Then
            t = t - Height + 20
        End If

        Opacity = 0
        Left = l : Top = t

        Show()

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 1}
        BeginAnimation(OpacityProperty, d2)
        w.Tag = 1
        wd = w
    End Sub

    Private Sub SBCMwindow_Initialized(sender As Object, e As EventArgs) Handles SBCMwindow.Initialized

    End Sub

    Private Sub SBCMwindow_Deactivated(sender As Object, e As EventArgs) Handles SBCMwindow.Deactivated
        CloseMenu()
    End Sub
End Class
