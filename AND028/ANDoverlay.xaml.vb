Imports System.Runtime.InteropServices
Imports System.Windows.Interop

Class ANDoverlay : Inherits Window
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


    <DllImport("user32.dll")>
    Friend Shared Function SetWindowCompositionAttribute(ByVal hwnd As IntPtr, ByRef data As WindowCompositionAttributeData) As Integer
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

    Private _blurBackgroundColor As UInteger = &H0

    Public Sub New()
        DataContext = Me
        InitializeComponent()
    End Sub

    Private Sub EnableBlur()

        Dim windowHelper = New WindowInteropHelper(Me)
        Dim accent = New AccentPolicy With {
            .AccentState = AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND,
            .GradientColor = (_blurOpacity << 24) Or (_blurBackgroundColor + &H0)
        }

        Dim accentStructSize = Marshal.SizeOf(accent)

        Dim accentPtr = Marshal.AllocHGlobal(accentStructSize)
        Marshal.StructureToPtr(accent, accentPtr, False)

        Dim data = New WindowCompositionAttributeData With {
            .Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
            .SizeOfData = accentStructSize,
            .Data = accentPtr
        }

        SetWindowCompositionAttribute(windowHelper.Handle, data)

        Marshal.FreeHGlobal(accentPtr)
    End Sub

    Private Sub ANDOwindow_Loaded(sender As Object, e As RoutedEventArgs) Handles ANDOwindow.Loaded
        BlurOpacity = 150
        '  EnableBlur()
    End Sub
End Class
