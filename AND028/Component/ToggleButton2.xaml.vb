Imports System.Windows.Media.Animation

Public Class ToggleButton2

    Public Event ToogleStateChanged()

    Private _istrue As Boolean = False
    Public Property IsTrue As Boolean
        Get
            Return _istrue
        End Get
        Set(value As Boolean)
            _istrue = value
            If _istrue = True Then
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
                indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

                Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indCircle.BeginAnimation(OpacityProperty, d6) : backRect.BeginAnimation(OpacityProperty, d6)

                Dim d5 As New ThicknessAnimation With {.Duration = TimeSpan.FromMilliseconds(100)}
                d5.From = New Thickness(2, 5, 24, 5) : d5.To = New Thickness(24, 5, 2, 5)
                indCircle.BeginAnimation(MarginProperty, d5)

                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
                backRect.BeginAnimation(OpacityProperty, d3)
            ElseIf _istrue = False Then
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

                Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indCircle.BeginAnimation(OpacityProperty, d) : backRect.BeginAnimation(OpacityProperty, d)

                Dim d5 As New ThicknessAnimation With {.Duration = TimeSpan.FromMilliseconds(100)}
                d5.To = New Thickness(2, 5, 24, 5) : d5.From = New Thickness(24, 5, 2, 5)
                indCircle.BeginAnimation(MarginProperty, d5)

                Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indHoverCircle.BeginAnimation(OpacityProperty, d2) : backHoverRect.BeginAnimation(OpacityProperty, d2)
            End If
            CheckEnabled()
            RaiseEvent ToogleStateChanged()
        End Set
    End Property

    Public _enabled As Boolean = True
    Public Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
            CheckEnabled()
        End Set
    End Property

    Private Sub CheckEnabled()
        If _enabled = True Then
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            indDisabledCircleRight.BeginAnimation(OpacityProperty, d2) : indDisabledCircle.BeginAnimation(OpacityProperty, d2)
            If _istrue = True Then
                Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                backRect.BeginAnimation(OpacityProperty, d5)
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indDisabledCircle.BeginAnimation(OpacityProperty, d4)
                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indCircle.BeginAnimation(OpacityProperty, d3)
            ElseIf _istrue = False Then
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indDisabledCircleRight.BeginAnimation(OpacityProperty, d4)
                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indNormCircle.BeginAnimation(OpacityProperty, d3)
            End If
        ElseIf _enabled = False Then
            If _istrue = True Then
                Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
                backRect.BeginAnimation(OpacityProperty, d5)
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indDisabledCircle.BeginAnimation(OpacityProperty, d4)
                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indCircle.BeginAnimation(OpacityProperty, d3)
                Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indDisabledCircleRight.BeginAnimation(OpacityProperty, d2)
            ElseIf _istrue = False Then
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indDisabledCircleRight.BeginAnimation(OpacityProperty, d4)
                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indNormCircle.BeginAnimation(OpacityProperty, d3)
                Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indDisabledCircle.BeginAnimation(OpacityProperty, d2)
            End If
        End If
    End Sub

    Private Sub FrontRect_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles frontRect.MouseLeftButtonUp
        Try
            If Enabled = True Then
                If IsTrue = False Then

                    Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                    indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
                    indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

                    Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                    indCircle.BeginAnimation(OpacityProperty, d6) : backRect.BeginAnimation(OpacityProperty, d6)

                    Dim d5 As New ThicknessAnimation With {.Duration = TimeSpan.FromMilliseconds(100)}
                    d5.From = New Thickness(2, 5, 24, 5) : d5.To = New Thickness(24, 5, 2, 5)
                    indCircle.BeginAnimation(MarginProperty, d5)
                    IsTrue = True

                    Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
                    backRect.BeginAnimation(OpacityProperty, d3)
                ElseIf IsTrue = True Then

                    Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                    indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
                    indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

                    Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                    indCircle.BeginAnimation(OpacityProperty, d) : backRect.BeginAnimation(OpacityProperty, d)


                    Dim d5 As New ThicknessAnimation With {.Duration = TimeSpan.FromMilliseconds(100)}
                    d5.To = New Thickness(2, 5, 24, 5) : d5.From = New Thickness(24, 5, 2, 5)
                    indCircle.BeginAnimation(MarginProperty, d5)
                    IsTrue = False

                    Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                    indNormCircle.BeginAnimation(OpacityProperty, d2) : backNormRect.BeginAnimation(OpacityProperty, d2)
                    Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                    indHoverCircle.BeginAnimation(OpacityProperty, d1) : backHoverRect.BeginAnimation(OpacityProperty, d1)

                    Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 10}
                    indNormCircle.BeginAnimation(WidthProperty, d6) : indNormCircle.BeginAnimation(HeightProperty, d6)
                    indCircle.BeginAnimation(WidthProperty, d6) : indCircle.BeginAnimation(HeightProperty, d6)
                    indHoverCircle.BeginAnimation(WidthProperty, d6) : indHoverCircle.BeginAnimation(HeightProperty, d6)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frontRect_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles frontRect.MouseLeftButtonDown

    End Sub

    Private Sub frontRect_MouseEnter(sender As Object, e As MouseEventArgs) Handles frontRect.MouseEnter
        If Enabled = True Then
            Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 10}
            indNormCircle.BeginAnimation(WidthProperty, d6) : indNormCircle.BeginAnimation(HeightProperty, d6)
            indCircle.BeginAnimation(WidthProperty, d6) : indCircle.BeginAnimation(HeightProperty, d6)
            indHoverCircle.BeginAnimation(WidthProperty, d6) : indHoverCircle.BeginAnimation(HeightProperty, d6)

            If IsTrue = True Then
                Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
                backRect.BeginAnimation(OpacityProperty, d5)
            Else
                Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indNormCircle.BeginAnimation(OpacityProperty, d5) : backNormRect.BeginAnimation(OpacityProperty, d5)
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
            End If
        End If
    End Sub

    Private Sub frontRect_MouseLeave(sender As Object, e As MouseEventArgs) Handles frontRect.MouseLeave
        If Enabled = True Then
            Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 12}
            indNormCircle.BeginAnimation(WidthProperty, d6) : indNormCircle.BeginAnimation(HeightProperty, d6)
            indCircle.BeginAnimation(WidthProperty, d6) : indCircle.BeginAnimation(HeightProperty, d6)
            indHoverCircle.BeginAnimation(WidthProperty, d6) : indHoverCircle.BeginAnimation(HeightProperty, d6)

            If IsTrue = True Then
                Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                backRect.BeginAnimation(OpacityProperty, d5)
            Else
                Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indNormCircle.BeginAnimation(OpacityProperty, d5) : backNormRect.BeginAnimation(OpacityProperty, d5)
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
            End If
        End If
    End Sub

    Private Sub TBcontrol_Loaded(sender As Object, e As RoutedEventArgs) Handles TBcontrol.Loaded
        If Enabled = True Then
            If IsTrue = True Then
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
                indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

                Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indCircle.BeginAnimation(OpacityProperty, d6) : backRect.BeginAnimation(OpacityProperty, d6)

                Dim d5 As New ThicknessAnimation With {.Duration = TimeSpan.FromMilliseconds(100)}
                d5.From = New Thickness(2, 5, 24, 5) : d5.To = New Thickness(24, 5, 2, 5)
                indCircle.BeginAnimation(MarginProperty, d5)

                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
                backRect.BeginAnimation(OpacityProperty, d3)
            End If
        End If
    End Sub
End Class
