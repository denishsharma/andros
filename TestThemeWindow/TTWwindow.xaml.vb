Imports System.Windows.Media.Animation
Imports System
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Interop
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Windows.Threading

Class TTWwindow : Inherits Window

    Private Const WM_SYSCOMMAND As Integer = &H112
    Private hwndSource As HwndSource

    Private Sub InitializeWindowSource(sender As Object, e As EventArgs)
        hwndSource = TryCast(PresentationSource.FromVisual(DirectCast(sender, Visual)), HwndSource)
        hwndSource.AddHook(New HwndSourceHook(AddressOf WndProc))
    End Sub

    Private retInt As IntPtr = IntPtr.Zero

    Private Function WndProc(hwnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr, ByRef handled As Boolean) As IntPtr
        Debug.WriteLine("WndProc messages: " + msg.ToString())
        '
        ' Check incoming window system messages
        '
        If msg = WM_SYSCOMMAND Then
            Debug.WriteLine("WndProc messages: " + msg.ToString())
        End If

        Return IntPtr.Zero
    End Function

    Public Enum ResizeDirection
        Left = 1
        Right = 2
        Top = 3
        TopLeft = 4
        TopRight = 5
        Bottom = 6
        BottomLeft = 7
        BottomRight = 8
    End Enum

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    Private Sub ResizeWindow(direction As ResizeDirection)
        SendMessage(hwndSource.Handle, WM_SYSCOMMAND, IntPtr.op_Explicit(61440 + direction), IntPtr.Zero)
    End Sub

    Private Sub ResetCursor(sender As Object, e As MouseEventArgs)
        If Mouse.LeftButton <> MouseButtonState.Pressed Then
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub Resize(sender As Object, e As MouseButtonEventArgs)
        Dim clickedRectangle As Rectangle = TryCast(sender, Rectangle)

        Select Case clickedRectangle.Name
            Case "topa"
                Me.Cursor = Cursors.SizeNS
                ResizeWindow(ResizeDirection.Top)
                Exit Select
            Case "bottom"
                Me.Cursor = Cursors.SizeNS
                ResizeWindow(ResizeDirection.Bottom)
                Exit Select
            Case "lefta"
                Me.Cursor = Cursors.SizeWE
                ResizeWindow(ResizeDirection.Left)
                Exit Select
            Case "right"
                Me.Cursor = Cursors.SizeWE
                ResizeWindow(ResizeDirection.Right)
                Exit Select
            Case "topLeft"
                Me.Cursor = Cursors.SizeNWSE
                ResizeWindow(ResizeDirection.TopLeft)
                Exit Select
            Case "topRight"
                Me.Cursor = Cursors.SizeNESW
                ResizeWindow(ResizeDirection.TopRight)
                Exit Select
            Case "bottomLeft"
                Me.Cursor = Cursors.SizeNESW
                ResizeWindow(ResizeDirection.BottomLeft)
                Exit Select
            Case "bottomRight"
                Me.Cursor = Cursors.SizeNWSE
                ResizeWindow(ResizeDirection.BottomRight)
                Exit Select
            Case Else
                Exit Select
        End Select
    End Sub

    Private Sub DisplayResizeCursor(sender As Object, e As MouseEventArgs)
        Dim clickedRectangle As Rectangle = TryCast(sender, Rectangle)

        Select Case clickedRectangle.Name
            Case "topa"
                Me.Cursor = Cursors.SizeNS
                Exit Select
            Case "bottom"
                Me.Cursor = Cursors.SizeNS
                Exit Select
            Case "lefta"
                Me.Cursor = Cursors.SizeWE
                Exit Select
            Case "right"
                Me.Cursor = Cursors.SizeWE
                Exit Select
            Case "topLeft"
                Me.Cursor = Cursors.SizeNWSE
                Exit Select
            Case "topRight"
                Me.Cursor = Cursors.SizeNESW
                Exit Select
            Case "bottomLeft"
                Me.Cursor = Cursors.SizeNESW
                Exit Select
            Case "bottomRight"
                Me.Cursor = Cursors.SizeNWSE
                Exit Select
            Case Else
                Exit Select
        End Select
    End Sub

    Private Sub Drag(sender As Object, e As MouseButtonEventArgs)
        DragMove()
        If Top <= 0 Then
            Top = 0
        End If
    End Sub

    Private Sub TTWWwindow_Deactivated(sender As Object, e As EventArgs) Handles TTWWwindow.Deactivated
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.2}
        shadowBack.BeginAnimation(OpacityProperty, d1)
        shadowBackDeactivate.BeginAnimation(OpacityProperty, d2)
    End Sub

    Private Sub TTWWwindow_Activated(sender As Object, e As EventArgs) Handles TTWWwindow.Activated
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.2}
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        shadowBack.BeginAnimation(OpacityProperty, d1)
        shadowBackDeactivate.BeginAnimation(OpacityProperty, d2)
    End Sub

    Private Sub CloseRect_MouseEnter(sender As Object, e As MouseEventArgs) Handles closeRect.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.4}
        ell_close.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub closeRect_MouseLeave(sender As Object, e As MouseEventArgs) Handles closeRect.MouseLeave
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        ell_close.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub closeRect_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles closeRect.MouseLeftButtonDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.9}
        ell_close.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub closeRect_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles closeRect.MouseLeftButtonUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.4}
        ell_close.BeginAnimation(OpacityProperty, d1)

        Dim d4 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = Top + 20}
        Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        BeginAnimation(TopProperty, d4)
        AddHandler d5.Completed, Sub()
                                     Close()
                                 End Sub
        BeginAnimation(OpacityProperty, d5)

    End Sub

    Private Sub maximizeRect_MouseEnter(sender As Object, e As MouseEventArgs) Handles maximizeRect.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.4}
        ell_maximize.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub maximizeRect_MouseLeave(sender As Object, e As MouseEventArgs) Handles maximizeRect.MouseLeave
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        ell_maximize.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub maximizeRect_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles maximizeRect.MouseLeftButtonDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.9}
        ell_maximize.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub maximizeRect_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles maximizeRect.MouseLeftButtonUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.4}
        ell_maximize.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub minimizeRect_MouseEnter(sender As Object, e As MouseEventArgs) Handles minimizeRect.MouseEnter
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.4}
        ell_minimize.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub minimizeRect_MouseLeave(sender As Object, e As MouseEventArgs) Handles minimizeRect.MouseLeave
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        ell_minimize.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub minimizeRect_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles minimizeRect.MouseLeftButtonDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.9}
        ell_minimize.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub minimizeRect_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles minimizeRect.MouseLeftButtonUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.4}
        ell_minimize.BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub TTWwindow_SourceInitialized(sender As Object, e As EventArgs) Handles Me.SourceInitialized
        InitializeWindowSource(sender, e)
    End Sub

    Private Sub HeaderOverRect_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles headerOverRect.PreviewMouseLeftButtonDown
        Drag(sender, e)
    End Sub
End Class
