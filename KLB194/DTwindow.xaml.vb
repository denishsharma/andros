Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Class DTwindow

    Dim NumberOfDaysInMonth As Integer
    Dim NowMonth As Integer
    Dim NowYear As Integer

    Public Property OwnerButton As UserControl

    Private Sub DTwindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        '   RenderCalender(Now)
    End Sub

    Public Sub RenderCalender(y As Integer, m As Integer)

        For Each n As DayLabel In dateCont.Children
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(150)), .To = 0}
            AddHandler d1.Completed, Sub()
                                         dateCont.Children.Remove(n)
                                     End Sub
            n.BeginAnimation(OpacityProperty, d1)
        Next


        Dim CurrentMonth As Integer = m
        Dim CurrentYear As Integer = y
        Dim CurrentDate As Date = Now()

        Dim NewDate As Date = New Date(Now.Year, Now.Month, Now.Day)

        Dim CurrentDateInfo As String = NewDate.DayOfWeek.ToString + ", " + NewDate.ToString("MMMM dd, yyyy")

        Dim CurrentTime As String = Date.Now.ToString("HH:mm")
        lblTime.Content = CurrentTime

        Dim t As New DispatcherTimer With {.IsEnabled = True}
        t.Start()
        AddHandler t.Tick, Sub()
                               lblTime.Content = Date.Now.ToString("HH:mm")
                           End Sub

        lblCurrentDateInfo.Content = CurrentDateInfo

        lblMonthYear.Content = MonthName(CurrentMonth) + ", " + CStr(CurrentYear)


        Dim NumberOfDaysInMonth As Integer = Date.DaysInMonth(CurrentYear, CurrentMonth)


        Dim LeadingDays As Integer
        Dim RemaingDays As Integer

        Dim FirstDayOfMonth As Integer = New Date(CurrentYear, CurrentMonth, 1).DayOfWeek



        If FirstDayOfMonth = 0 Then
            LeadingDays = 6
        Else
            LeadingDays = FirstDayOfMonth - 1
        End If

        RemaingDays = 49 - (NumberOfDaysInMonth + LeadingDays)

        If LeadingDays > 0 Then
            For h = 0 To LeadingDays - 1
                Dim PreviousMonthDate As Date = New Date(CurrentYear, CurrentMonth, 1).AddDays(-LeadingDays + h)
                Dim dl As New DayLabel With {.DateText = PreviousMonthDate.Day, .IsNotInCurrentMonth = True}
                dl.Day = PreviousMonthDate.DayOfWeek
                Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
                d1.BeginAnimation(OpacityProperty, d1)
                dateCont.Children.Add(dl)
            Next
        End If

        For i = 1 To NumberOfDaysInMonth
            Dim NowMonthDate As Date = New Date(CurrentYear, CurrentMonth, i)
            Dim dl As New DayLabel With {.DateText = NowMonthDate.Day}
            dl.FullDate = New Date(CurrentYear, CurrentMonth, i)
            If dl.FullDate.ToShortDateString = CurrentDate.ToShortDateString Then
                dl.IsCurrentDate = True
            End If
            dl.Day = NowMonthDate.DayOfWeek

            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
            d1.BeginAnimation(OpacityProperty, d1)
            dateCont.Children.Add(dl)
        Next

        For j = 0 To RemaingDays - 1
            Dim NextMonthDate As Date = New Date(CurrentYear, CurrentMonth, NumberOfDaysInMonth).AddDays(j + 1)
            Dim dl As New DayLabel With {.DateText = NextMonthDate.Day, .IsNotInCurrentMonth = True}
            dl.Day = NextMonthDate.DayOfWeek

            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
            d1.BeginAnimation(OpacityProperty, d1)
            dateCont.Children.Add(dl)
        Next

        CheckIfNow()
    End Sub

    Private Sub LblOpenDT_MouseEnter(sender As Object, e As MouseEventArgs) Handles lblOpenDT.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.1}
        OpenDTBack.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub lblOpenDT_MouseLeave(sender As Object, e As MouseEventArgs) Handles lblOpenDT.MouseLeave
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        OpenDTBack.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub lblOpenDT_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles lblOpenDT.MouseLeftButtonDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(1)), .To = 0.2}
        OpenDTBack.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub lblOpenDT_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles lblOpenDT.MouseLeftButtonUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.1}
        OpenDTBack.BeginAnimation(OpacityProperty, d1)


        CloseDT()
    End Sub

    Private Sub DTWwindow_Deactivated(sender As Object, e As EventArgs) Handles DTWwindow.Deactivated
        CloseDT()
    End Sub

    Public Sub CloseDT()
        MethodKLB194.IsOpen = False
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(130)), .To = 0}
        Dim d3 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(130)), .To = Top + 40}
        AddHandler d2.Completed, Sub()
                                     Close()
                                 End Sub
        BeginAnimation(OpacityProperty, d2)
        BeginAnimation(TopProperty, d3)

    End Sub

    Private Sub DTwindow_Initialized(sender As Object, e As EventArgs) Handles Me.Initialized
        NowYear = Now.Year
        NowMonth = Now.Month
        RenderCalender(NowYear, NowMonth)
    End Sub

    Private Sub BackWindowRect_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles backWindowRect.MouseDown
        CloseDT()
    End Sub

    Private Sub BtnUp_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnUp.MouseLeftButtonUp
        If NowMonth = 1 Then
            NowYear = NowYear - 1
            NowMonth = 12
        Else
            NowMonth = NowMonth - 1
        End If
        RenderCalender(NowYear, NowMonth)
    End Sub

    Private Sub BtnDown_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnDown.MouseLeftButtonUp
        If NowMonth = 12 Then
            NowYear = NowYear + 1
            NowMonth = 1
        Else
            NowMonth = NowMonth + 1
        End If
        RenderCalender(NowYear, NowMonth)
    End Sub

    Sub CheckIfNow()
        If NowMonth = Now.Month And NowYear = Now.Year Then
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
            NowBack.BeginAnimation(OpacityProperty, d1)
            AddHandler d1.Completed, Sub()
                                         lblNow.Visibility = Visibility.Hidden
                                         NowBack.Visibility = Visibility.Hidden
                                     End Sub
            lblNow.BeginAnimation(OpacityProperty, d1)

        Else
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.6}
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.05}
            AddHandler d1.Completed, Sub()
                                         lblNow.Visibility = Visibility.Visible
                                         NowBack.Visibility = Visibility.Visible
                                     End Sub
            lblNow.BeginAnimation(OpacityProperty, d1)
            NowBack.BeginAnimation(OpacityProperty, d2)
        End If
    End Sub

    Private Sub LblNow_MouseEnter(sender As Object, e As MouseEventArgs) Handles lblNow.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.2}
        NowBack.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub lblNow_MouseLeave(sender As Object, e As MouseEventArgs) Handles lblNow.MouseLeave
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.06}
        NowBack.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub lblNow_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles lblNow.MouseLeftButtonDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(1)), .To = 0.1}
        NowBack.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub lblNow_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles lblNow.MouseLeftButtonUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.2}
        NowBack.BeginAnimation(OpacityProperty, d1)

        NowYear = Now.Year
        NowMonth = Now.Month
        RenderCalender(Now.Year, Now.Month)
    End Sub

    ' Private Sub LblMonthYear_MouseEnter(sender As Object, e As MouseEventArgs) Handles lblMonthYear.MouseEnter
    '     Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.6}
    '     lblMonthYear.BeginAnimation(OpacityProperty, d1)
    ' End Sub
    '
    ' Private Sub lblMonthYear_MouseLeave(sender As Object, e As MouseEventArgs) Handles lblMonthYear.MouseLeave
    '     Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
    '     lblMonthYear.BeginAnimation(OpacityProperty, d1)
    ' End Sub
    '
    ' Private Sub lblMonthYear_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles lblMonthYear.MouseLeftButtonDown
    '     Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.8}
    '     lblMonthYear.BeginAnimation(OpacityProperty, d1)
    ' End Sub
    '
    ' Private Sub lblMonthYear_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles lblMonthYear.MouseLeftButtonUp
    '     Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.6}
    '     lblMonthYear.BeginAnimation(OpacityProperty, d1)
    ' End Sub
End Class
