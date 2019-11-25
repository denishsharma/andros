Imports System
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Interop
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Windows.Threading
Imports System.Windows.Media.Animation
Imports System.IO

Public Class EAPHost : Inherits Window

    Private Const WM_SYSCOMMAND As Integer = &H112
    Private hwndSource As HwndSource

    Public AppGridContainer As Grid = EAPContainer

    Public Function GetAppContainer() As UserControl
        For Each elm As UIElement In EAPContainer.Children
            If TypeOf elm Is UserControl Then
                Return elm
            End If
        Next
        Return Nothing
    End Function

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
                VerticalAlignment = VerticalAlignment.Bottom
                Me.Cursor = Cursors.SizeNS
                ResizeWindow(ResizeDirection.Top)
                Exit Select
            Case "bottom"
                VerticalAlignment = VerticalAlignment.Top
                Me.Cursor = Cursors.SizeNS
                ResizeWindow(ResizeDirection.Bottom)
                Exit Select
            Case "lefta"
                HorizontalAlignment = HorizontalAlignment.Right
                Me.Cursor = Cursors.SizeWE
                ResizeWindow(ResizeDirection.Left)
                Exit Select
            Case "right"
                HorizontalAlignment = HorizontalAlignment.Left
                Me.Cursor = Cursors.SizeWE
                ResizeWindow(ResizeDirection.Right)
                Exit Select
            Case "topLeft"
                HorizontalAlignment = HorizontalAlignment.Right
                VerticalAlignment = VerticalAlignment.Bottom
                Me.Cursor = Cursors.SizeNWSE
                ResizeWindow(ResizeDirection.TopLeft)
                Exit Select
            Case "topRight"
                HorizontalAlignment = HorizontalAlignment.Left
                VerticalAlignment = VerticalAlignment.Bottom
                Me.Cursor = Cursors.SizeNESW
                ResizeWindow(ResizeDirection.TopRight)
                Exit Select
            Case "bottomLeft"
                HorizontalAlignment = HorizontalAlignment.Right
                VerticalAlignment = VerticalAlignment.Top
                Me.Cursor = Cursors.SizeNESW
                ResizeWindow(ResizeDirection.BottomLeft)
                Exit Select
            Case "bottomRight"
                HorizontalAlignment = HorizontalAlignment.Left
                VerticalAlignment = VerticalAlignment.Top
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

        Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        AddHandler d5.Completed, Sub()
                                     If Owner.OwnedWindows.Count > 1 Then
                                         Close()
                                     Else
                                         Owner.Focus()
                                         Close()
                                     End If
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

        Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        Dim d6 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(40)), .From = Top, .To = Top + 40, .AutoReverse = False}
        BeginAnimation(TopProperty, d6)
        AddHandler d5.Completed, Sub()
                                     Hide()
                                 End Sub
        BeginAnimation(OpacityProperty, d5)
    End Sub

    Private Sub TTWwindow_SourceInitialized(sender As Object, e As EventArgs) Handles Me.SourceInitialized
        InitializeWindowSource(sender, e)
    End Sub

    Private Sub HeaderOverRect_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles headerOverRect.PreviewMouseLeftButtonDown
        Drag(sender, e)
    End Sub

    Private Sub EAPHost_Activated(sender As Object, e As EventArgs) Handles EAPHost.Activated
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.2}
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        shadowBack.BeginAnimation(OpacityProperty, d1)
        shadowBackDeactivate.BeginAnimation(OpacityProperty, d2)

        Dim ihost As Object = CreateClassInstance(Forms.Application.StartupPath + "\controller.dll", "controller.RunningAppService.RunningAppMethod")
        ihost.AppWindowLocation(AppID) = New System.Drawing.Point(Left, Top)
        ihost.SetActiveApp(Me)
    End Sub

    Private Sub EAPHost_Deactivated(sender As Object, e As EventArgs) Handles EAPHost.Deactivated
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0}
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 0.2}
        shadowBack.BeginAnimation(OpacityProperty, d1)
        shadowBackDeactivate.BeginAnimation(OpacityProperty, d2)

        Dim ihost As Object = CreateClassInstance(Forms.Application.StartupPath + "\controller.dll", "controller.RunningAppService.RunningAppMethod")
        ihost.AppWindowLocation(AppID) = New System.Drawing.Point(Left, Top)
        ihost.RemoveActiveApp(Me)
    End Sub

#Region "Properties"

    Private _appid As String
    Public Property AppID As String
        Get
            Return _appid
        End Get
        Set(value As String)
            _appid = value
        End Set
    End Property

    Public _appguid As String
    Private Property AppGUID As String
        Get
            Return _appguid
        End Get
        Set(value As String)
            _appguid = value
        End Set
    End Property

    Private _appname As String
    Public Property AppName As String
        Get
            Return _appname
        End Get
        Set(value As String)
            _appname = value
        End Set
    End Property

    Private _appicon As ImageSource
    Public Property AppIcon As ImageSource
        Get
            Return _appicon
        End Get
        Set(value As ImageSource)
            _appicon = value
            If _appicon Is Nothing Then
                image.Source = BitmapToImageSource(My.Resources.ApplicationIcon)
            Else
                image.Source = _appicon
            End If
        End Set
    End Property

    Private Function BitmapToImageSource(ByVal bitmap As System.Drawing.Bitmap) As BitmapImage
        Using memory As MemoryStream = New MemoryStream()
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png)
            memory.Position = 0
            Dim bitmapimage As BitmapImage = New BitmapImage()
            bitmapimage.BeginInit()
            bitmapimage.StreamSource = memory
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad
            bitmapimage.EndInit()
            Return bitmapimage
        End Using
    End Function


    Private _appversion As String
    Public Property AppVersion As String
        Get
            Return _appversion
        End Get
        Set(value As String)
            _appversion = value
        End Set
    End Property

    Private _appdeveloper As String
    Public Property AppDeveloper As String
        Get
            Return _appdeveloper
        End Get
        Set(value As String)
            _appdeveloper = value
        End Set
    End Property

    Private _apptitle As String
    Public Property AppTitle As String
        Get
            Return Title
        End Get
        Set(value As String)
            Title = value
            lblWindowText.Content = Me.Title
        End Set
    End Property

#End Region

    Private Sub EAPHost_Loaded(sender As Object, e As RoutedEventArgs) Handles EAPHost.Loaded
        Opacity = 0

        Dim d5 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(100)), .To = 1}
        AddHandler d5.Completed, Sub()
                                     Opacity = 1
                                 End Sub
        BeginAnimation(OpacityProperty, d5)

        Dim ihost As Object = CreateClassInstance(Forms.Application.StartupPath + "\controller.dll", "controller.RunningAppService.RunningAppMethod")
        ihost.AppWindowLocation(AppID) = New System.Drawing.Point(Me.Left, Me.Top)
        ihost.AddAppSetActive(Me)
    End Sub

    Private Sub EAPHost_Closed(sender As Object, e As EventArgs) Handles EAPHost.Closed
        CloseWindow()
    End Sub

    Public Sub CloseWindow()
        Dim ihost As Object = CreateClassInstance(Forms.Application.StartupPath + "\controller.dll", "controller.RunningAppService.RunningAppMethod")
        ihost.RemoveApp(Me)
    End Sub

    Private Sub EAPHost_LocationChanged(sender As Object, e As EventArgs) Handles EAPHost.LocationChanged
        Dim ihost As Object = CreateClassInstance(System.Windows.Forms.Application.StartupPath + "\controller.dll", "controller.RunningAppService.RunningAppMethod")
        ihost.AppWindowLocation(AppID) = New System.Drawing.Point(Left, Top)
    End Sub
End Class



Public Module CommonMethods

    Public Function CreateClassInstance(path As String, className As String) As Object
        Return Activator.CreateInstance(Reflection.Assembly.LoadFile(path).GetType(className))
    End Function

End Module