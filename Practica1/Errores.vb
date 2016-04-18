
Public Class Errores
    'fila, columna, caracter, descripcion
    Dim fila As Integer
    Dim columna As Integer
    Dim caracter As String
    Dim descripcion As String
    Sub New()

    End Sub
    Sub New(fila As Integer, columna As Integer, caracter As String, descripcion As String)
        Me.fila = fila
        Me.columna = columna
        Me.caracter = caracter
        Me.descripcion = descripcion
    End Sub

    Public Property _fila As Integer
        Get
            Return fila
        End Get
        Set(value As Integer)
            fila = value
        End Set
    End Property

    Public Property _columna As Integer
        Get
            Return columna
        End Get
        Set(value As Integer)
            columna = value
        End Set
    End Property

    Public Property _caracter As String
        Get
            Return caracter
        End Get
        Set(value As String)
            caracter = value
        End Set
    End Property

    Public Property _descripcion As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property
End Class
