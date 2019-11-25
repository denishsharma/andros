
Imports System.Windows.Media.Animation
Imports controller.RunningAppService

Public Class NormalButton

    Public Property Icon As ImageSource
        Get
            Return SBicon.Source
        End Get
        Set(value As ImageSource)
            If value Is Nothing Then
                SBicon.Source = BitmapToImageSource(My.Resources.ApplicationIcon)
            Else
                SBicon.Source = value
            End If
        End Set
    End Property

    Public Property AppID As Integer

    Public Property IsActive As Boolean
    Public Property IsOpened As Boolean = False
    Public Property IsSelected As Boolean = False


    Private Sub SBfront_MouseEnter(sender As Object, e As MouseEventArgs) Handles SBfront.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.1}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0.1
        If IsActive = True Then
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
            SBback.BeginAnimation(OpacityProperty, d2)
            SBback.Opacity = 0.2
        End If
        If IsActive = False Then
            Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 40}
            SBstatus.BeginAnimation(WidthProperty, d)
        End If
    End Sub

    Private Sub SBfront_MouseLeave(sender As Object, e As MouseEventArgs) Handles SBfront.MouseLeave
        If IsActive = False Then
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            SBback.BeginAnimation(OpacityProperty, d1)
            SBback.Opacity = 0
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
            SBclicked.BeginAnimation(OpacityProperty, d2)
            SBclicked.Opacity = 0
            Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 20}
            SBstatus.BeginAnimation(WidthProperty, d)
        ElseIf IsActive = True Then
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            SBback.BeginAnimation(OpacityProperty, d1)
            SBback.Opacity = 0
        End If
    End Sub

    Private Sub SBfront_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseDown

    End Sub

    Private Sub SBfront_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseUp
        If IsActive = False Then
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
            SBclicked.BeginAnimation(OpacityProperty, d2)
            SBclicked.Opacity = 0
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.1}
            SBback.BeginAnimation(OpacityProperty, d1)
            SBback.Opacity = 0.1
        End If
    End Sub

    Public Sub LeaveMouse()
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0
        Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 20}
        SBstatus.BeginAnimation(WidthProperty, d)
    End Sub

    Public Sub EnterMouse()
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.1}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0.1
        Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 40}
        SBstatus.BeginAnimation(WidthProperty, d)
    End Sub

    Public Sub Active()
        Dim uiel As UIElement = Parent
        Dim wp As WrapPanel = CType(uiel, WrapPanel)
        For Each n As NormalButton In wp.Children
            If n IsNot Me Then
                n.IsActive = False
                n.IsSelected = False
                n.LeaveMouse()
            ElseIf n Is Me Then
                IsActive = True
                IsSelected = true 
            End If
        Next

        Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        SBback.BeginAnimation(OpacityProperty, d5)
        SBback.Opacity = 0
        Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.4}
        SBclicked.BeginAnimation(OpacityProperty, d6)
        SBclicked.Opacity = 0.4
        If IsOpened = True Then
            Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 40}
            SBstatus.BeginAnimation(WidthProperty, d)
        ElseIf IsOpened = False Then
            Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(10)), .To = 1}
            SBstatus.BeginAnimation(OpacityProperty, d3)
            SBback.Opacity = 1
            Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .From = 0, .To = 40}
            SBstatus.BeginAnimation(WidthProperty, d)
            IsOpened = True
        End If

    End Sub

    Public Sub AppHasExited()
        IsOpened = False
        IsActive = False
        IsSelected = False


        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0
        Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        SBstatus.BeginAnimation(WidthProperty, d)
        Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        SBstatus.BeginAnimation(OpacityProperty, d3)
        SBback.Opacity = 0
        IsEnabled = False
        Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(200)), .To = 0}
        AddHandler d4.Completed, Sub()
                                     Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .From = 40, .To = 0}
                                     AddHandler d5.Completed, Sub()
                                                                  Dim uiel As UIElement = Parent
                                                                  Dim wp As WrapPanel = CType(uiel, WrapPanel)
                                                                  For Each n As NormalButton In wp.Children
                                                                      If n Is Me Then
                                                                          wp.Children.Remove(n)
                                                                          Exit For
                                                                      End If
                                                                  Next
                                                              End Sub
                                     BeginAnimation(WidthProperty, d5)
                                 End Sub


        BeginAnimation(OpacityProperty, d4)

    End Sub

    Dim i As Integer = 0
    Dim t As New Threading.DispatcherTimer With {.Interval = TimeSpan.FromSeconds(0.1)}

    Private Sub SBfront_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseRightButtonDown
        t.Start()
        AddHandler t.Tick, Sub()
                               i += 1
                           End Sub
    End Sub

    Private Sub SBfront_DragEnter(sender As Object, e As DragEventArgs) Handles SBfront.DragEnter
        Dim btn_to_move As NormalButton = CType(e.Data.GetData(DataFormats.Serializable), NormalButton)
        Dim uiel As UIElement = Parent
        Dim wp As WrapPanel = CType(uiel, WrapPanel)
        Dim where_to_move As Integer = wp.Children.IndexOf(CType(e.Source.Parent.Parent, UIElement))
        Dim what_to_move As Integer = wp.Children.IndexOf(btn_to_move)
        wp.Children.RemoveAt(what_to_move)
        wp.Children.Insert(where_to_move, btn_to_move)
    End Sub

    Dim ismouseDown As Boolean

    Private Sub SBfront_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseLeftButtonDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.4}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0.4
        ismouseDown = True

        ' Dim data As DataObject = New DataObject(DataFormats.Serializable, CType(e.Source.Parent.Parent, NormalButton))
        ' DragDrop.DoDragDrop(CType(e.Source.Parent.Parent, DependencyObject), data, DragDropEffects.All)


    End Sub

    Private Sub SBfront_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseLeftButtonUp
        If ismouseDown = True Then
            'MsgBox(IsActive)

            '  MsgBox(RunningAppMethod.LastActiveApp.AppID)

            If IsSelected = True Then
                IsSelected = False

            ElseIf IsSelected = False Then
                IsSelected = True

            End If


            If IsActive = True Then

                ' MsgBox(RunningAppMethod.GetActiveAppID())
                IsActive = False
                Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.1}
                SBback.BeginAnimation(OpacityProperty, d3)
                SBback.Opacity = 0.1
                Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 40}
                SBstatus.BeginAnimation(WidthProperty, d)
                Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
                SBclicked.BeginAnimation(OpacityProperty, d4)
                SBclicked.Opacity = 0

                '  RunningAppMethod.RemoveActiveApp(RunningAppMethod.GetAppById(AppID))

            ElseIf IsActive = False Then
                Dim uiel As UIElement = Parent
                Dim wp As WrapPanel = CType(uiel, WrapPanel)
                For Each n As NormalButton In wp.Children
                    If n IsNot e.Source.parent.parent Then
                        n.IsActive = False
                        n.LeaveMouse()
                    End If
                Next
                IsActive = True

                Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
                SBback.BeginAnimation(OpacityProperty, d5)
                SBback.Opacity = 0
                Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.4}
                SBclicked.BeginAnimation(OpacityProperty, d6)
                SBclicked.Opacity = 0.4
                If IsOpened = True Then
                    Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 40}
                    SBstatus.BeginAnimation(WidthProperty, d)

                    RunningAppMethod.SetActiveApp(RunningAppMethod.GetAppById(AppID))
                ElseIf IsOpened = False Then
                    Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(10)), .To = 1}
                    SBstatus.BeginAnimation(OpacityProperty, d3)
                    SBback.Opacity = 1
                    Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .From = 0, .To = 40}
                    SBstatus.BeginAnimation(WidthProperty, d)
                    IsOpened = True
                End If
            End If

            ' MsgBox("Active: " + CStr(IsActive) + vbNewLine + "Selected: " + CStr(IsSelected))

        End If
        ismouseDown = False
    End Sub

    Private Sub SBfront_MouseRightButtonUp(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseRightButtonUp
        If i > 3 Then
            t.Stop()
            AppHasExited()
            i = 0
        ElseIf i < 3 Then
            t.Stop()
            i = 0

            IsOpened = False
            IsActive = False

            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            SBback.BeginAnimation(OpacityProperty, d1)
            SBback.Opacity = 0
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            SBclicked.BeginAnimation(OpacityProperty, d2)
            SBclicked.Opacity = 0
            Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
            SBstatus.BeginAnimation(WidthProperty, d)
            Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
            SBstatus.BeginAnimation(OpacityProperty, d3)
            SBback.Opacity = 0
        End If
    End Sub
End Class
