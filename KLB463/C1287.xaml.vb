Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Windows.Interop
Imports controller.RunningAppService

Class C1287 : Inherits Window
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

    Private _blurBackgroundColor As UInteger = &H1

    Private Sub EnableBlur()

        Dim windowHelper = New WindowInteropHelper(Me)
        Dim accent = New AccentPolicy With {
            .AccentState = AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND,
            .GradientColor = (_blurOpacity << 24) Or (_blurBackgroundColor + &H1)
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

    Public Property OwnerWindow As Window

    Private Sub CW1287_Loaded(sender As Object, e As RoutedEventArgs) Handles CW1287.Loaded
        BlurOpacity = 150
        EnableBlur()
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height)
        Me.Left = 0
        Me.Width = Screen.PrimaryScreen.Bounds.Width

        ' For Each f In My.Computer.FileSystem.GetFiles("C:\Users\Mohinish\Documents\Denish\TESTICONS")
        '     contNB.Children.Add(New NormalButton With {.Icon = New BitmapImage(New Uri(f))})
        ' Next
    End Sub

    Private Sub CW1287_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles CW1287.MouseDoubleClick

    End Sub

    Private Sub CW1287_Deactivated(sender As Object, e As EventArgs) Handles CW1287.Deactivated
        For Each n As NormalButton In contNB.Children
            n.IsActive = False
            n.LeaveMouse()
        Next
    End Sub

    Private Sub ShowDesktopbtn_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles showDesktopbtn.MouseLeftButtonUp
        Dim ando As Object = CreateClassInstance("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Test2\andros\AND028\bin\Debug\AND028.dll", "AND028.MethodAND028")
        ando.ShowOverlay()
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        DataContext = Me
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.

        AddHandler RunningAppMethod.AppListLengthChanged, Sub()
                                                              If RunningAppMethod.CurrentAddedApp.Count > 0 Then
                                                                  If RunningAppMethod.CurrentAddedApp(0) IsNot Nothing Then
                                                                      Dim nb As New NormalButton With {.Icon = RunningAppMethod.CurrentAddedApp(0).AppIcon, .AppID = RunningAppMethod.CurrentAddedApp(0).AppID}
                                                                      contNB.Children.Add(nb)
                                                                      ' nb.Active()
                                                                  End If
                                                              End If

                                                              If RunningAppMethod.CurrentRemovedApp.Count > 0 Then
                                                                  Dim l As New List(Of NormalButton)
                                                                  l.Clear()
                                                                  For Each nb As NormalButton In contNB.Children
                                                                      l.Add(nb)
                                                                  Next

                                                                  Dim na As NormalButton = l.Find(Function(a)
                                                                                                      If a.AppID = RunningAppMethod.CurrentRemovedApp(0).AppID Then
                                                                                                          Return True
                                                                                                      End If
                                                                                                      Return Nothing
                                                                                                  End Function)
                                                                  If na IsNot Nothing Then
                                                                      na.AppHasExited()
                                                                  End If
                                                              End If
                                                          End Sub
        AddHandler RunningAppMethod.ActiveAppChanged, Sub()
                                                          Try
                                                              For Each n As NormalButton In contNB.Children
                                                                  If RunningAppMethod.ActiveApp.Count > 0 Then
                                                                      Try
                                                                          If n.AppID = RunningAppMethod.GetActiveAppID Then
                                                                              n.Active()
                                                                          End If
                                                                      Catch ex As Exception

                                                                      End Try
                                                                  Else

                                                                      AddHandler OwnerWindow.Deactivated, Sub()
                                                                                                              Try
                                                                                                                  If RunningAppMethod.LastActiveApp IsNot Nothing Then
                                                                                                                      If Not n.AppID = RunningAppMethod.LastActiveApp.AppID Then
                                                                                                                          n.IsActive = False
                                                                                                                          n.IsSelected = False
                                                                                                                          n.LeaveMouse()
                                                                                                                      End If
                                                                                                                  End If
                                                                                                              Catch ex As Exception

                                                                                                              End Try
                                                                                                          End Sub
                                                                  End If

                                                                  AddHandler OwnerWindow.Activated, Sub()
                                                                                                        n.IsActive = False
                                                                                                        n.IsSelected = False
                                                                                                        n.LeaveMouse()
                                                                                                    End Sub
                                                              Next
                                                          Catch ex As Exception

                                                          End Try
                                                      End Sub
    End Sub

    Private Sub RectBack_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles rectBack.MouseDown
        For Each n As NormalButton In contNB.Children
            n.IsActive = False
            n.LeaveMouse()
        Next
    End Sub
End Class


Public Module CommonMethods

    Public Function CreateClassInstance(path As String, className As String) As Object
        Return Activator.CreateInstance(Reflection.Assembly.LoadFile(path).GetType(className))
    End Function

    Public Function BitmapToImageSource(ByVal bitmap As System.Drawing.Bitmap) As BitmapImage
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
End Module