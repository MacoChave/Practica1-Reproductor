
Public Class Token
    'id, lexema, token
    Private lexema As String
    Private token As String
    Private id As Integer

    Sub New()

    End Sub

    Sub New(lexema As String, token As String, id As Integer)
        Me.lexema = lexema
        Me.token = token
        Me.id = id
    End Sub
    Public Property _lexema As String
        Get
            Return lexema
        End Get
        Set(value As String)
            lexema = value
        End Set
    End Property

    Public Property _token As String
        Get
            Return token
        End Get
        Set(value As String)
            token = value
        End Set
    End Property

    Public Property _id As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
End Class
