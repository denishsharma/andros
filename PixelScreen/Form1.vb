Public Class Form1

    Public Sub DrawPixel(x As Integer, y As Integer, color As Brush)
        Me.CreateGraphics.FillRectangle(color, x, y, 1, 1)

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ' DrawPixel(e.X, e.Y, Brushes.White)
        Me.Text = "X: " + CStr(e.X) + "  Y: " + CStr(e.Y)
    End Sub


    Dim Test As String = "Drawing text onto the screen"
    Dim stringFont As New Font("Arial", 24, FontStyle.Bold)
    Dim string_format As New StringFormat()


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim rect As Rectangle = New Rectangle(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2, 300, 300)
        rect.Inflate(2, 2)
        Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
            Using lgb As New Drawing2D.LinearGradientBrush(rect, Color.Red, Color.Orange, 90, True)
                g.FillRectangle(lgb, rect)
                g.DrawString(Test, stringFont, Brushes.Black, rect, string_format)
            End Using
        End Using
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.CreateGraphics.FillRectangle(Brushes.White, 100, 100, 2, 10)
        ' string_format.Alignment = StringAlignment.Center
        ' string_format.LineAlignment = StringAlignment.Near
        '
        ' Timer1.Interval = 1000
        ' Timer1.Start()
        '   Dim isPrime() As Boolean
        '   Dim i As Long
        '   Dim x As Long
        '   Dim ub As Long = 10
        '
        '
        '
        '   ReDim isPrime(0 To ub)
        '
        '   For i = 2 To ub
        '       isPrime(i) = True
        '   Next i
        '
        '   For i = 2 To ub
        '       If isPrime(i) = True Then
        '           x = i
        '           Do While x + i <= ub
        '               x = x + i
        '               isPrime(x) = False
        '           Loop
        '       End If
        '   Next i
        '
        '   For i = 2 To ub
        '       If isPrime(i) Then
        '           '  Me.Text = "X: " + CStr(i) + "  Y: " + CStr(i + 1)
        '       End If
        '   Next i
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' Dim isPrime() As Boolean
        ' Dim i As Long
        ' Dim x As Long
        ' Dim ub As Long = 1000
        '
        '
        '
        ' ReDim isPrime(0 To ub)
        '
        ' For i = 2 To ub
        '     isPrime(i) = True
        ' Next i
        '
        ' For i = 2 To ub
        '     If isPrime(i) = True Then
        '         x = i
        '         Do While x + i <= ub
        '             x = x + i
        '             isPrime(x) = False
        '         Loop
        '     End If
        ' Next i
        '
        ' For i = 2 To ub
        '     If isPrime(i) Then
        '         e.Graphics.FillRectangle(Brushes.White, i + 1, 10 + CInt(Math.Atan(i)), 2, 2)
        '     End If
        ' Next i
        '
    End Sub
End Class
