Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Class overlay
    Private Sub OverlayWindow_Initialized(sender As Object, e As EventArgs) Handles overlayWindow.Initialized
        Dim d As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(1000)), .From = 0, .To = 0.5, .RepeatBehavior = RepeatBehavior.Forever, .AutoReverse = True}
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(1000)), .From = 0.3, .To = 0, .RepeatBehavior = RepeatBehavior.Forever, .AutoReverse = True}
        elBack.BeginAnimation(OpacityProperty, d) : elBack1.BeginAnimation(OpacityProperty, d1)

        Dim i As Integer = 0
        Dim t As New DispatcherTimer With {.Interval = TimeSpan.FromSeconds(1)}
        t.Start()
        AddHandler t.Tick, Sub()
                               i += 1
                               If i >= 4 Then
                                   t.Stop()
                                   i = 0

                                   Dim c As Object = Activator.CreateInstance(Reflection.Assembly.LoadFile("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Test2\andros\AND182\bin\Debug\AND182.dll").GetType("AND182.MethodAND182"))
                                   c.ShowDesktop(Me)
                               End If
                           End Sub
    End Sub
End Class
