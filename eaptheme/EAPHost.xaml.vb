Imports System
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Interop
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Windows.Threading

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

    Friend Enum AccentState
        ACCENT_DISABLED = 0
        ACCENT_ENABLE_GRADIENT = 1
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2
        ACCENT_ENABLE_BLURBEHIND = 3
        ACCENT_ENABLE_ACRYLICBLURBEHIND = 4
        ACCENT_INVALID_STATE = 5
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure AccentPolicy
        Public AccentState As AccentState
        Public AccentFlags As UInteger
        Public GradientColor As UInteger
        Public AnimationId As UInteger
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure WindowCompositionAttributeData
        Public Attribute As WindowCompositionAttribute
        Public Data As IntPtr
        Public SizeOfData As Integer
    End Structure

    Friend Enum WindowCompositionAttribute
        WCA_ACCENT_POLICY = 19
    End Enum


    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function
    Friend Shared Function SetWindowCompositionAttribute(ByVal hwnd As IntPtr, ByRef data As WindowCompositionAttributeData) As Integer
        Return Nothing
    End Function

    Private _blurOpacity As UInteger

    Public Property BlurOpacity As Double
        Get
            Return _blurOpacity
        End Get
        Set(ByVal value As Double)
            _blurOpacity = CUInt(value)
            EnableBlur()
        End Set
    End Property

    Private _blurBackgroundColor As UInteger = &H990000

    Private Sub EnableBlur()

        Dim windowHelper = New WindowInteropHelper(Me)
        Dim accent = New AccentPolicy()
        accent.AccentState = AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND
        accent.GradientColor = (_blurOpacity << 24) Or (_blurBackgroundColor)

        Dim accentStructSize = Marshal.SizeOf(accent)

        Dim accentPtr = Marshal.AllocHGlobal(accentStructSize)
        Marshal.StructureToPtr(accent, accentPtr, False)

        Dim data = New WindowCompositionAttributeData()
        data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY
        data.SizeOfData = accentStructSize
        data.Data = accentPtr

        SetWindowCompositionAttribute(windowHelper.Handle, data)

        Marshal.FreeHGlobal(accentPtr)
    End Sub

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
        Me.DragMove()
        If Me.Top <= 0 Then
            Me.Top = 0
        End If
    End Sub

    Public Sub New()
        DataContext = Me
        InitializeComponent()
    End Sub

    Private Sub EAPHost_SourceInitialized(sender As Object, e As EventArgs) Handles EAPHost.SourceInitialized
        InitializeWindowSource(sender, e)
    End Sub


    Dim ft_min As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}


    Private Sub ell_close_MouseEnter(sender As Object, e As MouseEventArgs) Handles ell_close.MouseEnter
        Dim ft_close As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}
        ft_close.Start()
        AddHandler ft_close.Tick, Sub()
                                      ell_close.Opacity -= 0.1
                                      If ell_close.Opacity <= 0.1 Then
                                          ell_close.Opacity = 0.1
                                          ft_close.Stop()
                                      End If
                                  End Sub
    End Sub

    Private Sub ell_close_MouseLeave(sender As Object, e As MouseEventArgs) Handles ell_close.MouseLeave
        Dim ft_close As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}
        ft_close.Start()
        AddHandler ft_close.Tick, Sub()
                                      ell_close.Opacity += 0.1
                                      If ell_close.Opacity >= 1 Then
                                          ell_close.Opacity = 1
                                          ft_close.Stop()
                                      End If
                                  End Sub
    End Sub

    Private Sub ell_maximize_MouseEnter(sender As Object, e As MouseEventArgs) Handles ell_maximize.MouseEnter
        Dim ft_close As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}
        ft_close.Start()
        AddHandler ft_close.Tick, Sub()
                                      ell_maximize.Opacity -= 0.1
                                      If ell_maximize.Opacity <= 0.1 Then
                                          ell_maximize.Opacity = 0.1
                                          ft_close.Stop()
                                      End If
                                  End Sub
    End Sub

    Private Sub ell_maximize_MouseLeave(sender As Object, e As MouseEventArgs) Handles ell_maximize.MouseLeave
        Dim ft_close As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}
        ft_close.Start()
        AddHandler ft_close.Tick, Sub()
                                      ell_maximize.Opacity += 0.1
                                      If ell_maximize.Opacity >= 1 Then
                                          ell_maximize.Opacity = 1
                                          ft_close.Stop()
                                      End If
                                  End Sub
    End Sub

    Private Sub ell_minimize_MouseEnter(sender As Object, e As MouseEventArgs) Handles ell_minimize.MouseEnter
        Dim ft_close As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}
        ft_close.Start()
        AddHandler ft_close.Tick, Sub()
                                      ell_minimize.Opacity -= 0.1
                                      If ell_minimize.Opacity <= 0.1 Then
                                          ell_minimize.Opacity = 0.1
                                          ft_close.Stop()
                                      End If
                                  End Sub
    End Sub

    Private Sub ell_minimize_MouseLeave(sender As Object, e As MouseEventArgs) Handles ell_minimize.MouseLeave
        Dim ft_close As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}
        ft_close.Start()
        AddHandler ft_close.Tick, Sub()
                                      ell_minimize.Opacity += 0.1
                                      If ell_minimize.Opacity >= 1 Then
                                          ell_minimize.Opacity = 1
                                          ft_close.Stop()
                                      End If
                                  End Sub
    End Sub

    Private Sub ell_close_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles ell_close.MouseLeftButtonUp
        ' EAPContainer.Visibility = Visibility.Hidden
        Dim ft_close As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}
        ft_close.Start()
        AddHandler ft_close.Tick, Sub()
                                      Me.Opacity -= 0.1
                                      If Me.Opacity <= 0 Then
                                          Me.Opacity = 0
                                          ft_close.Stop()
                                          Me.Close()
                                      End If
                                  End Sub
    End Sub

    Private Sub EAPHost_Activated(sender As Object, e As EventArgs) Handles EAPHost.Activated
        rect_cont.Stroke = New SolidColorBrush(Color.FromArgb(100, 56, 149, 241))
        rect_header.BorderBrush = New SolidColorBrush(Color.FromArgb(100, 56, 149, 241))
        rect_back.Opacity = 0.3

        ' Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "\controller.dll")
        ' Dim ty As Type = a.GetType("controller.RunningAppService.RunningAppMethod")
        ' Dim ihost As Object = Activator.CreateInstance(ty)
        ' ihost.AppWindowLocation(AppID) = New System.Drawing.Point(Me.Left, Me.Top)
        ' ihost.SetActiveApp(Me)
    End Sub

    Private Sub EAPHost_Deactivated(sender As Object, e As EventArgs) Handles EAPHost.Deactivated
        rect_cont.Stroke = New SolidColorBrush(Color.FromArgb(100, 180, 180, 180))
        rect_header.BorderBrush = New SolidColorBrush(Color.FromArgb(100, 180, 180, 180))
        rect_back.Opacity = 0.1
    End Sub

    Private Sub lbl_header_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles lbl_header.MouseLeftButtonUp, rect_header.MouseLeftButtonUp
        If Me.Top < -10 Then
            Me.Top = 0
        End If
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

    Private _appicon As System.Drawing.Image
    Public Property AppIcon As System.Drawing.Image
        Get
            Return _appicon
        End Get
        Set(value As System.Drawing.Image)
            _appicon = value
        End Set
    End Property

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
            Return Me.Title
        End Get
        Set(value As String)
            Me.Title = value
            lbl_header.Content = Me.Title
        End Set
    End Property

#End Region

    Private Sub EAPHost_Loaded(sender As Object, e As RoutedEventArgs) Handles EAPHost.Loaded
        Me.Opacity = 0

        EnableBlur()

        Dim ft_close As New DispatcherTimer With {.Interval = TimeSpan.FromMilliseconds(10)}
        ft_close.Start()
        AddHandler ft_close.Tick, Sub()
                                      Me.Opacity += 0.1
                                      If Me.Opacity >= 1 Then
                                          Me.Opacity = 1
                                          ft_close.Stop()

                                      End If
                                  End Sub
        '  Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "\controller.dll")
        '  Dim ty As Type = a.GetType("controller.RunningAppService.RunningAppMethod")
        '  Dim ihost As Object = Activator.CreateInstance(ty)
        '  ihost.AppWindowLocation(AppID) = New System.Drawing.Point(Me.Left, Me.Top)
        '  ihost.AddAppSetActive(Me)
    End Sub

    Private Sub EAPHost_Closed(sender As Object, e As EventArgs) Handles EAPHost.Closed
        '   Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "\controller.dll")
        '   Dim ty As Type = a.GetType("controller.RunningAppService.RunningAppMethod")
        '   Dim ihost As Object = Activator.CreateInstance(ty)
        '   ihost.RemoveApp(Me)
    End Sub

    Private Sub EAPHost_LocationChanged(sender As Object, e As EventArgs) Handles EAPHost.LocationChanged
        ' Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "\controller.dll")
        ' Dim ty As Type = a.GetType("controller.RunningAppService.RunningAppMethod")
        ' Dim ihost As Object = Activator.CreateInstance(ty)
        ' ihost.AppWindowLocation(AppID) = New System.Drawing.Point(Me.Left, Me.Top)
    End Sub
End Class
