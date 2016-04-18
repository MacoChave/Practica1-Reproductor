Public Class Form1
    Dim texto As String
    Dim analisis As New AnalizadorLexico()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnAnalizar_Click(sender As Object, e As EventArgs) Handles btnAnalizar.Click
        texto = txtTexto.Text
        analisis.analizar(texto)

        Dim contarToken As Integer = listaTokens.Count
        Dim t As Integer
        For t = 0 To contarToken - 1
            Console.WriteLine("Item: " + listaTokens.Item(t)._id + " Lexema: " + listaTokens.Item(t)._lexema + " Token: " + listaTokens.Item(t)._token)
        Next

        Dim contarErrores As Integer = listaErrores.Count

        Dim i As Integer
        For i = 0 To contarErrores - 1
            Console.WriteLine("Fila: " + listaErrores.Item(i)._fila + " Columna: " + listaErrores.Item(i)._columna + " Caracter: " + listaErrores.Item(i)._caracter + " Descripcion: " + listaErrores.Item(i)._descripcion)
        Next
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtTexto.Clear()
        txtToken.Clear()
        txtError.Clear()
        listaErrores.Clear()
        listaTokens.Clear()
    End Sub
End Class
