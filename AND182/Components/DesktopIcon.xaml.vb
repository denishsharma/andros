Imports System.Drawing
Imports System.IO
Imports System.Windows.Media.Animation

Public Class DesktopIcon

    Public Shared SelectedItems As New List(Of DesktopIcon)
    Dim down As Boolean = False
    Public Property IsSelected As Boolean = False

    Public isc As Boolean = False

    Private _keydown As Boolean = False

    Public Property Icon As ImageSource
        Get

        End Get
        Set(value As ImageSource)

        End Set
    End Property

    Public Property FullPathOfApp As String

    Public Property Text As String
        Get
            Return label.Content
        End Get
        Set(value As String)
            label.Content = value
            labelBack.Content = value
        End Set
    End Property

    Private _icontype As IconTypes = IconTypes.Folder
    Public Property IconType As IconTypes
        Get
            Return _icontype
        End Get
        Set(value As IconTypes)
            _icontype = value
            CheckIconType()
        End Set
    End Property

    Enum IconTypes
        Folder = 0
        Application = 1
        ImageThumbnail = 2
        Other = 3
    End Enum

    Public Sub CheckIconType()
        If _icontype = 0 Then
            image.Source = BitmapToImageSource(My.Resources.FolderIcon)
        ElseIf _icontype = 1 Then
            image.Source = BitmapToImageSource(My.Resources.ApplicationIcon)
        End If
    End Sub

    Private Function BitmapToImageSource(ByVal bitmap As Bitmap) As BitmapImage
        Using memory As MemoryStream = New MemoryStream()
            bitmap.Save(memory, Imaging.ImageFormat.Png)
            memory.Position = 0
            Dim bitmapimage As BitmapImage = New BitmapImage()
            bitmapimage.BeginInit()
            bitmapimage.StreamSource = memory
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad
            bitmapimage.EndInit()
            Return bitmapimage
        End Using
    End Function

    Public ListOfDesktopIcons As New List(Of DesktopIcon)

    Public Sub AssociatedDesktopIconsList()
        If _keydown = False Then
            SelectedItems.Clear()
            If ListOfDesktopIcons.Count > 0 Then
                For Each m As DesktopIcon In ListOfDesktopIcons
                    m.MakeFasle()
                Next
            End If
        End If

        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(10)), .To = 0.3}
        rectBack.BeginAnimation(OpacityProperty, d1)

        IsSelected = True
        SelectedItems.Add(Me)
    End Sub

    Public Sub MakeFasle()
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
        rectBack.BeginAnimation(OpacityProperty, d1)
        Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.4}
        labelBack.BeginAnimation(OpacityProperty, d2)

        isc = False
        IsSelected = False
        SelectedItems.Remove(Me)
    End Sub

    Private Sub RectFront_MouseEnter(sender As Object, e As MouseEventArgs) Handles rectFront.MouseEnter
        If isc = False Then
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
            rectBack.BeginAnimation(OpacityProperty, d1)
        End If
    End Sub

    Private Sub rectFront_MouseLeave(sender As Object, e As MouseEventArgs) Handles rectFront.MouseLeave
        If IsSelected = True Then
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(10)), .To = 0.3}
            rectBack.BeginAnimation(OpacityProperty, d1)
        Else
            Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0}
            rectBack.BeginAnimation(OpacityProperty, d1)
            Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.4}
            labelBack.BeginAnimation(OpacityProperty, d2)
        End If
    End Sub

    Private Sub rectFront_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles rectFront.MouseDown
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(10)), .To = 0.25}
        rectBack.BeginAnimation(OpacityProperty, d1)



        If e.ClickCount = 2 Then
            If _icontype = 1 Then
                If File.Exists(FullPathOfApp) Then
                    ' MsgBox(e.Source.Parent.Parent.Parent.Parent.Parent.ToString)
                    Dim eapl As New wap.EAPLoader : Dim eaph As New wap.EAPHost
                    eapl.LoadEAP(FullPathOfApp, eaph, FullPathOfApp)
                    eaph.Topmost = False
                    eaph.Owner = e.Source.Parent.Parent.Parent.Parent.Parent
                    controller.RunningAppService.RunningAppMethod.SetActiveApp(eaph)
                End If
            End If
        ElseIf e.ClickCount = 1 Then

            down = True

        End If
    End Sub

    Private Sub rectFront_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles rectFront.MouseUp
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.3}
        rectBack.BeginAnimation(OpacityProperty, d1)

        If down = True Then
            If _keydown = False Then
                ' If IsSelected = False Then
                AssociatedDesktopIconsList()
                ' End If
            Else
                If IsSelected = True Then
                    Dim d2 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .To = 0.2}
                    rectBack.BeginAnimation(OpacityProperty, d2)

                    IsSelected = False
                    SelectedItems.Remove(Me)
                Else
                    AssociatedDesktopIconsList()
                End If
            End If
            down = False
        End If
    End Sub

    Private Sub DIcontrol_Initialized(sender As Object, e As EventArgs) Handles DIcontrol.Initialized
        Dim d1 As New DoubleAnimation With {.Duration = New Duration(TimeSpan.FromMilliseconds(70)), .From = 0, .To = 1}
        BeginAnimation(OpacityProperty, d1)
    End Sub

    Private Sub DIcontrol_Loaded(sender As Object, e As RoutedEventArgs) Handles DIcontrol.Loaded
        Dim w = Window.GetWindow(Me)
        AddHandler w.KeyDown, AddressOf HandleKeyPress
        AddHandler w.KeyUp, AddressOf HandleKeyUp
    End Sub

    Private Sub HandleKeyPress(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.LeftCtrl Then
            _keydown = True
        End If
    End Sub

    Private Sub HandleKeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.LeftCtrl Then
            _keydown = False
        End If
    End Sub

    Private Sub rectFront_MouseRightButtonUp(sender As Object, e As MouseButtonEventArgs) Handles rectFront.MouseRightButtonUp
        isc = True

        If _icontype = IconTypes.Application Then
            Dim p As Window = e.Source.Parent.Parent.Parent.Parent.Parent
            Dim cm As New ApplicationCM
            cm.ShowMenu(e.GetPosition(p).X, e.GetPosition(p).Y)


            AddHandler cm.Closed, Sub()
                                      isc = False
                                      MakeFasle()
                                  End Sub
        ElseIf _icontype = IconTypes.Folder Then
            Dim p As Window = e.Source.Parent.Parent.Parent.Parent.Parent
            Dim cm As New FolderCM
            cm.ShowMenu(e.GetPosition(p).X, e.GetPosition(p).Y)


            AddHandler cm.Closed, Sub()
                                      isc = False
                                      MakeFasle()
                                  End Sub
        End If
    End Sub
End Class
