Public Class Profile

    Dim email As String
    Dim name As String
    Dim city As String
    Dim state As String
    Dim country As String
    Dim certificates As String
    Dim link As String
    Dim script As String

    Public Property cScript() As String
        Get
            Return Me.script
        End Get
        Set(ByVal Value As String)
            Me.script = Value
        End Set
    End Property


    Public Property cEmail() As String
        Get
            Return Me.email
        End Get
        Set(ByVal Value As String)
            Me.email = Value
        End Set
    End Property

    Public Property cName() As String
        Get
            Return Me.name
        End Get
        Set(ByVal Value As String)
            Me.name = Value
        End Set
    End Property

    Public Property cCity() As String
        Get
            Return Me.city
        End Get
        Set(ByVal Value As String)
            Me.city = Value
        End Set
    End Property

    Public Property cState() As String
        Get
            Return Me.state
        End Get
        Set(ByVal Value As String)
            Me.state = Value
        End Set
    End Property

    Public Property cCountry() As String
        Get
            Return Me.country
        End Get
        Set(ByVal Value As String)
            Me.country = Value
        End Set
    End Property

    Public Property cCertificates() As String
        Get
            Return Me.certificates
        End Get
        Set(ByVal Value As String)
            Me.certificates = Value
        End Set
    End Property

    Public Property cLink() As String
        Get
            Return Me.link
        End Get
        Set(ByVal Value As String)
            Me.link = Value
        End Set
    End Property

End Class
