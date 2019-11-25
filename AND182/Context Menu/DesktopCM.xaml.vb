Imports System.Windows.Media.Animation
Imports System.Windows.Forms

Public Class DesktopCM


    Dim cm As SortByCM

    Private Sub RectBack_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles rectBack.MouseDown
        CloseMenu()
    End Sub

    Public Sub CloseMenu()
        If cm IsNot Nothing Then
            cm.CloseMenu()
        End If

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        AddHandler d2.Completed, Sub()
                                     Close()

                                 End Sub
        BeginAnimation(OpacityProperty, d2)
    End Sub

    Public Sub ShowMenu(x As Double, y As Double, w As andDesktopWindow)
        Dim l, t, rl, rt As Double
        l = x - 10 : t = y - 10

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
    End Sub

    Private Sub DCMwindow_Deactivated(sender As Object, e As EventArgs) Handles DCMwindow.Deactivated
        CloseMenu()
    End Sub

    Private Sub DCMwindow_Initialized(sender As Object, e As EventArgs) Handles DCMwindow.Initialized

    End Sub

    Private Sub SortbyCMI_OnMoreSelectedStateChanged(sender As Object, e As Input.MouseEventArgs, v As Boolean) Handles sortbyCMI.OnMoreSelectedStateChanged
        If v = False Then
            spSortBy.Opacity = 0
            spSortBy.Height = 254
            spSortBy.Visibility = Visibility.Visible

            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
            spSortBy.BeginAnimation(OpacityProperty, d2)
            Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 112}
            spSortBy.BeginAnimation(HeightProperty, d3)
            Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 208}
            BeginAnimation(HeightProperty, d4)
        ElseIf v = True Then
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            AddHandler d2.Completed, Sub()
                                         spSortBy.Opacity = 0
                                         spSortBy.Height = 0
                                         spSortBy.Visibility = Visibility.Visible
                                     End Sub
            spSortBy.BeginAnimation(OpacityProperty, d2)
            Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            spSortBy.BeginAnimation(HeightProperty, d3)
            Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 294}
            BeginAnimation(HeightProperty, d4)
        End If


        If viewCMI.IsSelected = True Then
            Dim d12 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            AddHandler d12.Completed, Sub()
                                          spView.Opacity = 0
                                          spView.Height = 0
                                          spView.Visibility = Visibility.Visible
                                      End Sub
            spView.BeginAnimation(OpacityProperty, d12)
            Dim d13 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            spView.BeginAnimation(HeightProperty, d13)
            viewCMI.IsSelected = False
        End If
    End Sub

    Private Sub ViewCMI_OnMoreSelectedStateChanged(sender As Object, e As Input.MouseEventArgs, v As Boolean) Handles viewCMI.OnMoreSelectedStateChanged
        If v = False Then
            spView.Opacity = 0
            spView.Height = 254
            spView.Visibility = Visibility.Visible

            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
            spView.BeginAnimation(OpacityProperty, d2)
            Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 122}
            spView.BeginAnimation(HeightProperty, d3)
            Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 190}
            BeginAnimation(HeightProperty, d4)
        ElseIf v = True Then
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            AddHandler d2.Completed, Sub()
                                         spView.Opacity = 0
                                         spView.Height = 0
                                         spView.Visibility = Visibility.Visible
                                     End Sub
            spView.BeginAnimation(OpacityProperty, d2)
            Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            spView.BeginAnimation(HeightProperty, d3)
            Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 294}
            BeginAnimation(HeightProperty, d4)
        End If


        If sortbyCMI.IsSelected = True Then
            Dim d12 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            AddHandler d12.Completed, Sub()
                                          spSortBy.Opacity = 0
                                          spSortBy.Height = 0
                                          spSortBy.Visibility = Visibility.Visible
                                      End Sub
            spSortBy.BeginAnimation(OpacityProperty, d12)
            Dim d13 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            spSortBy.BeginAnimation(HeightProperty, d13)
            sortbyCMI.IsSelected = False
        End If
    End Sub
End Class
