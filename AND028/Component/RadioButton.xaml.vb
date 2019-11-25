Imports System.Windows.Media.Animation

Public Class RadioButton

    Public ListOfRadioButons As New List(Of RadioButton)

    Public Sub AssociatedRadioButtonsList()
        If ListOfRadioButons.Count > 0 Then
            For Each m As RadioButton In ListOfRadioButons
                m.ListOfRadioButons = ListOfRadioButons
                m.MakeFasle()
            Next
        End If

        Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        indHoverCircle.BeginAnimation(OpacityProperty, d4) : backHoverRect.BeginAnimation(OpacityProperty, d4)
        indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

        Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        indCircle.BeginAnimation(OpacityProperty, d6) : backRect.BeginAnimation(OpacityProperty, d6)

        IsTrue = True

        Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
        backRect.BeginAnimation(OpacityProperty, d3)
    End Sub

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

                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
                backRect.BeginAnimation(OpacityProperty, d3)
            ElseIf _istrue = False Then
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

                Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indCircle.BeginAnimation(OpacityProperty, d) : backRect.BeginAnimation(OpacityProperty, d)

                Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                indHoverCircle.BeginAnimation(OpacityProperty, d2) : backHoverRect.BeginAnimation(OpacityProperty, d2)
            End If
        End Set
    End Property

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
                AssociatedRadioButtonsList()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MakeFasle()
        Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        indNormCircle.BeginAnimation(OpacityProperty, d4) : backNormRect.BeginAnimation(OpacityProperty, d4)

        Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        indCircle.BeginAnimation(OpacityProperty, d) : backRect.BeginAnimation(OpacityProperty, d)

        IsTrue = False

        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        indHoverCircle.BeginAnimation(OpacityProperty, d2) : backHoverRect.BeginAnimation(OpacityProperty, d2)
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

    Private Sub RBcontrol_Loaded(sender As Object, e As RoutedEventArgs) Handles RBcontrol.Loaded
        If IsTrue Then
            If ListOfRadioButons.Count > 0 Then
                For Each m As RadioButton In ListOfRadioButons
                    m.ListOfRadioButons = ListOfRadioButons
                    m.MakeFasle()
                Next
            End If

            IsTrue = True

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
