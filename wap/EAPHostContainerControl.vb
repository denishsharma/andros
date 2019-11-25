Public Class EAPHostContainerControl

    Public _AppContainer As UserControl
    Public heighty As Double
    Public widthx As Double
    Public Sub New()
        InitializeComponent()

        Me.BackColor = System.Drawing.Color.WhiteSmoke
        _windowtext = "App" : Me.Tag = "App"
        _appname = "App" : _appversion = "1.0"

        _appid = New Random().Next(100, 9999)
        _appguid = New Random().Next(1000000, 999999999)
    End Sub

    Public Sub AppContainer(container As UserControl)
        _AppContainer = container
    End Sub


    Public Sub WindowHeight(y As Double)
        heighty = y
    End Sub

    Public Sub WindowWidth(x As Double)
        widthx = x
    End Sub

#Region "Properties"

    Public _Argument As String
    Public Property Argument As String
        Get
            Return _Argument
        End Get
        Set(value As String)
            _Argument = value
        End Set
    End Property

    Private _windowtext As String
    Public Property WindowText As String
        Get
            Return _windowtext
        End Get
        Set(value As String)
            _windowtext = value
            Me.Tag = value
        End Set
    End Property

    Private _appid As String
    Public ReadOnly Property AppID As String
        Get
            Return _appid
        End Get
    End Property

    Public _appguid As String
    Private ReadOnly Property AppGUID As String
        Get
            Return _appguid
        End Get
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


#End Region

End Class
