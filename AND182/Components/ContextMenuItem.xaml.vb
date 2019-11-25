Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Public Class ContextMenuItem
    Public Event OnMoreHover(sender As Object, e As MouseEventArgs)
    Public Event OnMoreSelectedStateChanged(sender As Object, e As MouseEventArgs, v As Boolean)

    Private _isSelected As Boolean = False
    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(value As Boolean)
            _isSelected = value
            If _isSelected = True Then
                PerformAnimation(0, 90)
                Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
                rectBack.BeginAnimation(OpacityProperty, d)
                labelName.Foreground = Brushes.White
            ElseIf _isSelected = False Then
                PerformAnimation(90, 0)
                Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                rectBack.BeginAnimation(OpacityProperty, d)
                labelName.Foreground = Brushes.Black
            End If
        End Set
    End Property

    Public Property ItemName As String
        Get
            Return labelName.Content
        End Get
        Set(value As String)
            labelName.Content = value
        End Set
    End Property

    Public Property IsIconVisible As Visibility
        Get
            Return image.Visibility
        End Get
        Set(value As Visibility)
            image.Visibility = value
        End Set
    End Property

    Private _ismore As Boolean = False
    Public Property IsMore As Boolean
        Get
            Return _ismore
        End Get
        Set(value As Boolean)
            _ismore = value
            If _ismore = True Then
                imageMore.Visibility = Visibility.Visible
            ElseIf _ismore = False Then
                imageMore.Visibility = Visibility.Hidden
            End If
        End Set
    End Property

    Public Property Icon As ImageSource
        Get
            Return image.Source
        End Get
        Set(value As ImageSource)
            image.Source = value
        End Set
    End Property

    Public Property Enabled As Boolean
        Get
            Return IsEnabled
        End Get
        Set(value As Boolean)
            IsEnabled = value
            If IsEnabled = False Then
                labelName.Foreground = New SolidColorBrush(Color.FromRgb(232, 232, 232))
            ElseIf IsEnabled = True Then
                labelName.Foreground = Brushes.Black
            End If
        End Set
    End Property

    Dim down As Boolean = False

    Dim t As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(100)}
    Dim i As Integer = 0

    Private Sub LabelName_MouseEnter(sender As Object, e As MouseEventArgs) Handles labelName.MouseEnter
        labelName.Foreground = Brushes.White

        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
        rectBack.BeginAnimation(OpacityProperty, d1)

        If _ismore = True Then
            t.Start()
            AddHandler t.Tick, Sub()
                                   i += 1
                                   If i >= 3 Then
                                       t.Stop()
                                       i = 0

                                       RaiseEvent OnMoreHover(sender, e)
                                   End If
                               End Sub
        End If
    End Sub

    Private Sub labelName_MouseLeave(sender As Object, e As MouseEventArgs) Handles labelName.MouseLeave
        If _isSelected = False Then
            labelName.Foreground = Brushes.Black

            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            rectBack.BeginAnimation(OpacityProperty, d1)

            t.Stop()
            i = 0
        Else
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(10)), .To = 1}
            rectBack.BeginAnimation(OpacityProperty, d1)
        End If
    End Sub

    Private Sub labelName_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles labelName.MouseLeftButtonDown
        labelName.Foreground = Brushes.White

        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(10)), .To = 1}
        rectBack.BeginAnimation(OpacityProperty, d1)

        down = True
    End Sub

    Private Sub labelName_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles labelName.MouseLeftButtonUp
        Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
        rectBack.BeginAnimation(OpacityProperty, d)

        If down = True Then
            If _ismore = False Then
                Dim p As Window = e.Source.parent.parent.parent.parent.parent

                Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                AddHandler d2.Completed, Sub()
                                             p.Close()
                                         End Sub
                p.BeginAnimation(OpacityProperty, d2)

                down = False


            ElseIf _ismore = True Then

                If _isSelected = True Then
                    PerformAnimation(90, 0)
                    RaiseEvent OnMoreSelectedStateChanged(sender, e, True)
                    _isSelected = False
                ElseIf IsSelected = False Then
                    PerformAnimation(0, 90)
                    RaiseEvent OnMoreSelectedStateChanged(sender, e, False)
                    _isSelected = True
                End If
            End If

        End If
    End Sub

    Private Sub PerformAnimation(ByVal oldValue As Double, ByVal newValue As Double)
        Dim s As Storyboard = New Storyboard()
        Dim animation As DoubleAnimation = New DoubleAnimation()
        animation.From = oldValue
        animation.[To] = newValue
        animation.Duration = New Duration(TimeSpan.FromMilliseconds(70))
        Storyboard.SetTargetName(animation, "rtAngle")
        Storyboard.SetTargetProperty(animation, New PropertyPath(RotateTransform.AngleProperty))
        s.Children.Add(animation)
        s.Begin(imageMore)
    End Sub
End Class
