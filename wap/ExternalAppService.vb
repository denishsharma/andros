Namespace ExternalAppService

    <Serializable()>
    Public Class AppDataFile
        ''' <summary>
        ''' Contains app information.
        ''' </summary>
        ''' <param name="appname">Name of an app.</param>
        ''' <param name="apptype">App source type. projectname.formname (eg: testapp.app)</param>
        Public Sub New(appname As String, apptype As String)
            Me.AppName = appname : Me.AppType = apptype
        End Sub
        ''' <summary>
        ''' Contains app information.
        ''' </summary>
        ''' <param name="appname">Name of an app.</param>
        ''' <param name="apptype">App source type. projectname.formname (eg: testapp.app)</param>
        ''' <param name="appicon">App icon path.</param>
        Public Sub New(appname As String, apptype As String, appicon As String)
            Me.AppName = appname : Me.AppType = apptype : Me.AppIcon = appicon
        End Sub
        ''' <summary>
        ''' Contains app information.
        ''' </summary>
        ''' <param name="appname">Name of an app.</param>
        ''' <param name="apptype">App source type. projectname.formname (eg: testapp.app)</param>
        ''' <param name="appicon">App icon path.</param>
        ''' <param name="appdeveloper">App Developer.</param>
        Public Sub New(appname As String, apptype As String, appicon As String, appdeveloper As String)
            Me.AppName = appname : Me.AppType = apptype : Me.AppIcon = appicon : Me.AppDeveloper = appdeveloper
        End Sub
        ''' <summary>
        ''' Contains app information.
        ''' </summary>
        ''' <param name="appname">Name of an app.</param>
        ''' <param name="apptype">App source type. projectname.formname (eg: testapp.app)</param>
        ''' <param name="appicon">App icon path.</param>
        ''' <param name="appdeveloper">Developers of an app.</param>
        ''' <param name="appversion">Version of an app.</param>
        Public Sub New(appname As String, apptype As String, appicon As String, appdeveloper As String, appversion As String)
            Me.AppName = appname : Me.AppType = apptype : Me.AppIcon = appicon : Me.AppDeveloper = appdeveloper : Me.AppVersion = appversion
        End Sub


        Private _n As String
        Public Property AppName() As String
            Get
                Return _n
            End Get
            Set(ByVal value As String)
                _n = value
            End Set
        End Property

        Private _t As String
        Public Property AppType() As String
            Get
                Return _t
            End Get
            Set(ByVal value As String)
                _t = value
            End Set
        End Property

        Private _i As String
        Public Property AppIcon() As String
            Get
                Return _i
            End Get
            Set(ByVal value As String)
                _i = value
            End Set
        End Property

        Private _d As String
        Public Property AppDeveloper() As String
            Get
                Return _d
            End Get
            Set(value As String)
                _d = value
            End Set
        End Property

        Private _v As String
        Public Property AppVersion() As String
            Get
                Return _v
            End Get
            Set(value As String)
                _v = value
            End Set
        End Property

    End Class

    Public Interface EAPHostContainer
        Sub LoadSettings()
        Property HostContainer As EAPHostContainerControl
    End Interface

    Public Class AppDataFileCreator

        ''' <summary>
        ''' Create an AppData (.dt) file for an app.
        ''' </summary>
        ''' <param name="appname">Name of an app.</param>
        ''' <param name="apptype">App source type. projectname.formname (eg: testapp.app)</param>
        ''' <param name="apppath">Full path of an app.</param>
        Public Shared Sub Create(appname As String, apptype As String, apppath As String)
            Dim fs As IO.FileStream = IO.File.Open(apppath & ".dt", IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
            Dim encoder As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            encoder.Serialize(fs, New AppDataFile(appname, apptype))
        End Sub
        ''' <summary>
        ''' Create an AppData (.dt) file for an app.
        ''' </summary>
        ''' <param name="appname">Name of an app.</param>
        ''' <param name="apptype">App source type. projectname.formname (eg: testapp.app)</param>
        ''' <param name="appicon">App icon path.</param>
        ''' <param name="apppath">Full path of an app.</param>
        Public Shared Sub Create(appname As String, apptype As String, appicon As String, apppath As String)
            Dim fs As IO.FileStream = IO.File.Open(apppath & ".dt", IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
            Dim encoder As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            encoder.Serialize(fs, New AppDataFile(appname, apptype, appicon))
        End Sub
        ''' <summary>
        ''' Create an AppData (.dt) file for an app.
        ''' </summary>
        ''' <param name="appname">Name of an app.</param>
        ''' <param name="apptype">App source type. projectname.formname (eg: testapp.app)</param>
        ''' <param name="appicon">App icon path.</param>
        ''' <param name="apppath">Full path of an app.</param>
        ''' <param name="appdeveloper">Developer of an app.</param>
        Public Shared Sub Create(appname As String, apptype As String, appicon As String, apppath As String, appdeveloper As String)
            Dim fs As IO.FileStream = IO.File.Open(apppath & ".dt", IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
            Dim encoder As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            encoder.Serialize(fs, New AppDataFile(appname, apptype, appicon, appdeveloper))
        End Sub
        ''' <summary>
        ''' Create an AppData (.dt) file for an app.
        ''' </summary>
        ''' <param name="appname">Name of an app.</param>
        ''' <param name="apptype">App source type. projectname.formname (eg: testapp.app)</param>
        ''' <param name="appicon">App icon path.</param>
        ''' <param name="apppath">Full path of an app.</param>
        ''' <param name="appdeveloper">Developer of an app.</param>
        ''' <param name="appversion">Version of an app.</param>
        Public Shared Sub Create(appname As String, apptype As String, appicon As String, apppath As String, appdeveloper As String, appversion As String)
            Dim fs As IO.FileStream = IO.File.Open(apppath & ".dt", IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
            Dim encoder As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            encoder.Serialize(fs, New AppDataFile(appname, apptype, appicon, appdeveloper, appversion))
        End Sub

    End Class

End Namespace