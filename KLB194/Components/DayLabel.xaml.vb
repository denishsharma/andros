Imports System.Windows.Media.Animation

Public Class DayLabel

    Public Property DateText As String
        Get
            Return labelText.Content
        End Get
        Set(value As String)
            labelText.Content = value
        End Set
    End Property

    Private _isnotincurrmonth As Boolean = False
    Public Property IsNotInCurrentMonth As Boolean
        Get
            Return _isnotincurrmonth
        End Get
        Set(value As Boolean)
            _isnotincurrmonth = value
            CheckIfNotCurrentMonth()
        End Set
    End Property

    Sub CheckIfNotCurrentMonth()
        If _isnotincurrmonth = True Then
            labelText.Foreground = New SolidColorBrush(Color.FromRgb(209, 209, 209))
        ElseIf _isnotincurrmonth = False Then
            CheckCurrentDay()
        End If
    End Sub

    Private _iscurrdate As Boolean = False
    Public Property IsCurrentDate As Boolean
        Get
            Return _iscurrdate
        End Get
        Set(value As Boolean)
            _iscurrdate = value
            CheckLabelDay()
        End Set
    End Property

    Private _day As Days
    Public Property Day As Days
        Get
            Return _day
        End Get
        Set(value As Days)
            _day = value
            CheckLabelDay()
        End Set
    End Property
    Enum Days
        Mo = 1 : Fr = 5
        Tu = 2 : Sa = 6
        We = 3 : Su = 0
        Th = 4
    End Enum

    Public Property FullDate As Date

    Public Sub CheckLabelDay()
        If Not _day = Days.Su Then
            If _isnotincurrmonth = True Then
                labelText.Foreground = New SolidColorBrush(Color.FromRgb(209, 209, 209))
            ElseIf _isnotincurrmonth = False Then
                If _iscurrdate = True Then
                    hoverCircle.Opacity = 0.9
                    hoverCircle.Height = 44 : hoverCircle.Width = 44
                    hoverCircle.Fill = New SolidColorBrush(Color.FromRgb(0, 135, 242))
                    labelText.Foreground = Brushes.White
                ElseIf _iscurrdate = False Then
                    hoverCircle.Opacity = 0
                    hoverCircle.Fill = Brushes.Black
                    labelText.Foreground = New SolidColorBrush(Color.FromRgb(87, 87, 87))
                End If
            End If

        ElseIf _day = Days.Su Then
            If _isnotincurrmonth = True Then
                labelText.Foreground = New SolidColorBrush(Color.FromRgb(209, 209, 209))
            ElseIf _isnotincurrmonth = False Then
                If _iscurrdate = False Then
                    labelText.Foreground = New SolidColorBrush(Color.FromRgb(255, 98, 98))
                ElseIf _iscurrdate = True Then
                    hoverCircle.Opacity = 0.9
                    hoverCircle.Height = 44 : hoverCircle.Width = 44
                    hoverCircle.Fill = New SolidColorBrush(Color.FromRgb(0, 135, 242))
                    labelText.Foreground = Brushes.White
                End If
            End If
        End If
    End Sub

    Public Sub CheckCurrentDay()
        If _iscurrdate = True Then
            hoverCircle.Opacity = 0.9
            hoverCircle.Height = 44 : hoverCircle.Width = 44
            hoverCircle.Fill = New SolidColorBrush(Color.FromRgb(0, 135, 242))
            labelText.Foreground = Brushes.White
        ElseIf _iscurrdate = False Then
            hoverCircle.Opacity = 0
            hoverCircle.Fill = Brushes.Black
            labelText.Foreground = New SolidColorBrush(Color.FromRgb(87, 87, 87))
            CheckLabelDay()
        End If
    End Sub

    Private Sub LabelText_MouseEnter(sender As Object, e As MouseEventArgs) Handles labelText.MouseEnter
        If IsCurrentDate = True Then
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
            hoverCircle.BeginAnimation(OpacityProperty, d1)
        Else
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.1}
            hoverCircle.BeginAnimation(OpacityProperty, d1)
        End If

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 35}
        hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
    End Sub

    Private Sub labelText_MouseLeave(sender As Object, e As MouseEventArgs) Handles labelText.MouseLeave
        If IsCurrentDate = True Then
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(150)), .To = 1}
            hoverCircle.BeginAnimation(OpacityProperty, d1)

            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(150)), .To = 44}
            hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
        Else
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(150)), .To = 0}
            hoverCircle.BeginAnimation(OpacityProperty, d1)

            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(150)), .To = 0}
            hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
        End If
    End Sub

    Private Sub labelText_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles labelText.MouseLeftButtonDown
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(150)), .To = 44}
        hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
    End Sub

    Private Sub labelText_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles labelText.MouseLeftButtonUp
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 35}
        hoverCircle.BeginAnimation(WidthProperty, d2) : hoverCircle.BeginAnimation(HeightProperty, d2)
    End Sub
End Class
