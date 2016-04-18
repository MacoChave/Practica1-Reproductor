Class AnalizadorLexico
    Dim estado As Integer
    Dim lexema As String
    Dim caracter As Char
    Dim tipoCaracter As Integer
    Dim fila As Integer
    Dim columna As Integer
    Dim tokenReconocido As New Token
    Dim errorEncontrado As New Errores

    Public Sub analizar(texto As String)
        texto = texto + "#"
        estado = 0
        fila = 1
        columna = 1
        For i As Integer = 0 To texto.Length - 1 Step 1
            caracter = texto.Chars(i)
            tipoCaracter = obtenerTipo(caracter)
            Select Case estado
                Case 0
                    Select Case tipoCaracter
                        Case 0 'APERTURA DE ETIQUETA
                            estado = 1
                            tokenReconocido = New Token
                            tokenReconocido._id = tipoCaracter
                            tokenReconocido._lexema = caracter
                            tokenReconocido._token = "Apertura de etiqueta"
                            listaTokens.Add(tokenReconocido)
                            columna += 1
                        Case 3 'NUMERO
                            estado = 7
                            lexema = caracter
                            columna += 1
                        Case 4 ' LETRA MAYUSCULA
                            estado = 5
                            lexema = caracter
                            columna += 1
                        Case 5 'LETRA MINUSCULA
                            estado = 7
                            lexema = caracter
                            columna += 1
                        Case 7 'ESPACIO
                            estado = 7
                            lexema = caracter
                            columna += 1
                        Case 9 'CARACTER DESCONOCIDO
                            estado = 7
                            lexema = caracter
                            columna += 1
                        Case 7 'SALTO DE LINEA
                            fila += 1
                            columna = 0
                    End Select
                Case 1
                    Select Case tipoCaracter
                        Case 1 'MUERTE DE ETIQUETA
                            estado = 3
                            tokenReconocido = New Token
                            tokenReconocido._id = tipoCaracter
                            tokenReconocido._lexema = caracter
                            tokenReconocido._token = "Muerte de etiqueta"
                            listaTokens.Add(tokenReconocido)
                            columna += 1
                        Case 5 'LETRA MINUSCULA
                            estado = 2
                            lexema = caracter
                            columna += 1
                        Case Else
                            errorEncontrado = New Errores
                            errorEncontrado._fila = fila
                            errorEncontrado._columna = columna
                            errorEncontrado._caracter = caracter
                            errorEncontrado._descripcion = "Se esperaba una palabra reservada"
                            columna += 1
                    End Select
                Case 2
                    Select Case tipoCaracter
                        Case 2 'CIERRE ETIQUETA
                            estado = 4
                            tokenReconocido = New Token
                            tokenReconocido._id = tipoCaracter
                            tokenReconocido._lexema = lexema
                            tokenReconocido._token = "Palabra reservada"
                            lexema = caracter
                            columna += 1
                        Case 5 'LETRA MINUSCULA
                            lexema = lexema + caracter
                            columna += 1
                        Case Else
                            errorEncontrado = New Errores
                            errorEncontrado._fila = fila
                            errorEncontrado._columna = columna
                            errorEncontrado._caracter = caracter
                            errorEncontrado._descripcion = "Se esperaba una palabra reservada"
                            lexema = ""
                            columna += 1
                    End Select
                Case 3
                    Select Case tipoCaracter
                        Case 5 'LETRA MINUSCULA
                            estado = 2
                            lexema = caracter
                            columna += 1
                        Case Else
                            errorEncontrado = New Errores
                            errorEncontrado._fila = fila
                            errorEncontrado._columna = columna
                            errorEncontrado._caracter = caracter
                            errorEncontrado._descripcion = "Se esperaba una palabra reservada"
                            lexema = ""
                            columna += 1
                    End Select
                Case 4
                    'ACEPTACIÓN
                    Select Case tipoCaracter
                        Case 8 'SALTO DE LINEA
                            tokenReconocido = New Token
                            tokenReconocido._id = tipoCaracter
                            tokenReconocido._lexema = caracter
                            tokenReconocido._token = "Etiqueta de cierre"
                            listaTokens.Add(tokenReconocido)
                            lexema = ""
                            fila += 1
                            columna = 1
                            estado = 0
                        Case Else
                            tokenReconocido = New Token
                            tokenReconocido._id = tipoCaracter
                            tokenReconocido._lexema = caracter
                            tokenReconocido._token = "Etiqueta de cierre"
                            listaTokens.Add(tokenReconocido)
                            lexema = ""
                            i -= 1
                            estado = 0
                    End Select
                Case 5
                    Select Case tipoCaracter
                        Case 3 'NUMERO
                            lexema = lexema + caracter
                            columna += 1
                            estado = 6
                        Case 4 'LETRA MAYUSCULA
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case 5 'LETRA MINUSCULA
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case 7 'ESPACIO
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case 8 'SALTO DE LINEA
                            errorEncontrado = New Errores
                            errorEncontrado._fila = fila
                            errorEncontrado._columna = columna
                            errorEncontrado._caracter = caracter
                            errorEncontrado._descripcion = "No se esperaba un salto de linea"
                            columna = 1
                            fila += 1
                            lexema = ""
                            estado = 0
                        Case 9 'CARACTER DESCONOCIDO
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case Else
                    End Select
                Case 6
                    'ACEPTACION
                    Select Case tipoCaracter
                        Case 0 'APERTURA DE ETIQUETA
                            tokenReconocido = New Token
                            tokenReconocido._id = tipoCaracter
                            tokenReconocido._lexema = lexema
                            tokenReconocido._token = "Reservada Nota"
                            lexema = ""
                            estado = 0
                            columna += 1
                            i -= 1
                        Case 3 'NUMERO
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case 4 'LETRA MAYUSCULA
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case 5 'LETRA MINUSCULA
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case 7 'ESPACIO
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case 9 'CARACTER DESCONOCIDO
                            lexema = lexema + caracter
                            columna += 1
                            estado = 7
                        Case 8 'SALTO DE LINEA
                            errorEncontrado = New Errores
                            errorEncontrado._fila = fila
                            errorEncontrado._columna = columna
                            errorEncontrado._caracter = caracter
                            errorEncontrado._descripcion = "No se esperaba un salto de linea"
                            columna = 1
                            fila += 1
                            lexema = ""
                    End Select
                Case 7
                    'ACEPTACION
                    Select Case tipoCaracter
                        Case 0 'APERTURA DE ETIQUETA
                            tokenReconocido = New Token
                            tokenReconocido._id = tipoCaracter
                            tokenReconocido._lexema = lexema
                            tokenReconocido._token = "CADENA DE CARACTERES"
                            i -= 1
                            columna += 1
                            estado = 0
                        Case 3 'NUMERO
                            lexema = lexema + caracter
                            columna += 1
                        Case 4 'LETRA MINUSCULA
                            lexema = lexema + caracter
                            columna += 1
                        Case 5 'LETRA MAYUSCULA
                            lexema = lexema + caracter
                            columna += 1
                        Case 7 'ESPACIO
                            lexema = lexema + caracter
                            columna += 1
                        Case 8 'SALTO DE LINEA
                            errorEncontrado = New Errores
                            errorEncontrado._fila = fila
                            errorEncontrado._columna = columna
                            errorEncontrado._caracter = caracter
                            errorEncontrado._descripcion = "No se esperaba un salto de linea"
                            fila += 1
                            columna = 1
                        Case 9 'CARACTER DESCONOCIDO
                            lexema = lexema + caracter
                            columna += 1
                    End Select
            End Select
        Next
    End Sub

    Private Function obtenerTipo(caracter As Char) As Integer
        Select Case caracter
            Case "<"
                tipoCaracter = 0 'APERTURA DE ETIQUETA
            Case "/"
                tipoCaracter = 1 'MUERTE DE ETIQUETA
            Case ">"
                tipoCaracter = 2 'CIERRE DE ETIQUETA
            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                tipoCaracter = 3 'NUMERO
            Case "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z"
                tipoCaracter = 4 'LETRA MAYUSCULA
            Case "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z"
                tipoCaracter = 5 'LETRA MINUSCULA
            Case "#"
                tipoCaracter = 6 'SHARP
            Case Chr(32)
                tipoCaracter = 7 'ESPACIO
            Case Chr(13)
                tipoCaracter = 8 'SALTO DE LÍNEA
            Case Else
                tipoCaracter = 9 'CARACTER DESCONOCIDO
        End Select
        Return tipoCaracter
    End Function
    'INICIALIZAR TOKEN
    'tokenAnalizado = New Token
    'tokenAnalizado._lexema = 
    'tokenAnalizado._token =
    'tokenAnalizado._id = 
    'AGREGARLO A LA LISTA DE TOKENS
    'listaToken.Add(tokenAnalizado)
End Class
