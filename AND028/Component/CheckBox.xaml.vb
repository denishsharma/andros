Imports System.Windows.Media.Animation

Public Class CheckBox

    Public Property IsTrue As Boolean = False


    Public Property Text As String
        Get
            Return labelText.Content
        End Get
        Set(value As String)
            labelText.Content = value
        End Set
    End Property

    Private Sub FrontRect_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles frontRect.MouseLeftButtonUp
        Try
            If IsTrue = False Then

                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
                indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

                Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indCircle.BeginAnimation(OpacityProperty, d6) : backRect.BeginAnimation(OpacityProperty, d6)

                IsTrue = True

                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
                backRect.BeginAnimation(OpacityProperty, d3)
            ElseIf IsTrue = True Then

                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

                Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indCircle.BeginAnimation(OpacityProperty, d) : backRect.BeginAnimation(OpacityProperty, d)

                IsTrue = False

                Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indHoverCircle.BeginAnimation(OpacityProperty, d2) : backHoverRect.BeginAnimation(OpacityProperty, d2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frontRect_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles frontRect.MouseLeftButtonDown

    End Sub

    Private Sub frontRect_MouseEnter(sender As Object, e As MouseEventArgs) Handles frontRect.MouseEnter
        If IsTrue = True Then
            Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
            backRect.BeginAnimation(OpacityProperty, d5)
        Else
            Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            indNormCircle.BeginAnimation(OpacityProperty, d5) : backNormRect.BeginAnimation(OpacityProperty, d5)
            Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
            indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
        End If
    End Sub

    Private Sub frontRect_MouseLeave(sender As Object, e As MouseEventArgs) Handles frontRect.MouseLeave
        If IsTrue = True Then
            Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
            backRect.BeginAnimation(OpacityProperty, d5)
        Else
            Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
            indNormCircle.BeginAnimation(OpacityProperty, d5) : backNormRect.BeginAnimation(OpacityProperty, d5)
            Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
        End If
    End Sub

    Private Sub CBcontrol_Loaded(sender As Object, e As RoutedEventArgs) Handles CBcontrol.Loaded
        If IsTrue = True Then
            Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
            indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

            Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
            indCircle.BeginAnimation(OpacityProperty, d6) : backRect.BeginAnimation(OpacityProperty, d6)

            Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
            backRect.BeginAnimation(OpacityProperty, d3)
        End If
    End Sub
End Class
