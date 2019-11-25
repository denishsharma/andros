Imports System.Globalization
Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Public Class ClockButton
    Dim down As Boolean = False
    Dim isopen As Boolean = False

    Dim andDT As Object = CreateClassInstance("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Test2\andros\KLB194\bin\Debug\KLB194.dll", "KLB194.MethodKLB194")

    Private Sub CBcontrol_Loaded(sender As Object, e As RoutedEventArgs) Handles CBcontrol.Loaded
        lblTime.Content = Date.Now.ToString("t")
        lblDate.Content = Date.Today.ToString("dd-MM-yyyy")

        Dim t As New DispatcherTimer With {.IsEnabled = True}
        t.Start()
        AddHandler t.Tick, Sub()
                               lblTime.Content = Date.Now.ToString("t")
                           End Sub
    End Sub

    Private Sub SBfront_MouseEnter(sender As Object, e As MouseEventArgs) Handles SBfront.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0.2
    End Sub

    Private Sub SBfront_MouseLeave(sender As Object, e As MouseEventArgs) Handles SBfront.MouseLeave
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0
    End Sub

    Private Sub SBfront_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0.2
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0

        If down = True Then


            andDT.ShowDateAndTime(Me)

            down = False
        End If
    End Sub

    Private Sub SBfront_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles SBfront.MouseLeftButtonDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        SBback.BeginAnimation(OpacityProperty, d1)
        SBback.Opacity = 0
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
        SBclicked.BeginAnimation(OpacityProperty, d2)
        SBclicked.Opacity = 0.2
        down = True
    End Sub
End Class
