Imports System.Windows.Media.Animation
Imports System.Windows.Window

Public Class MethodAND182

    Public Shared Sub ShowDesktop(o As Window)
        Dim w As New andDesktopWindow
        w.Opacity = 0
        w.Topmost = False
        w.Owner = o
        w.Show()
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        AddHandler d2.Completed, Sub()
                                     Dim c As Object = Activator.CreateInstance(Reflection.Assembly.LoadFile("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Test2\andros\KLB463\bin\Debug\KLB463.dll").GetType("KLB463.MethodKLB463"))
                                     c.Invoke(w)

                                     o.Hide()
                                 End Sub
        w.BeginAnimation(OpacityProperty, d2)
    End Sub

End Class
