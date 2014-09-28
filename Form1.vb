Imports VBScript_RegExp_55

Public Class Form1

    'función para ejecutar la expesión regular
    Function Extraer_direccion_Email(ByVal PathOrigen As String, _
                                ByVal pathDestino As String, _
                                ByVal Cadena_Expresion As String) As Boolean

        Dim obj_Expresion As RegExp, Match, Matches


        Dim fso As Object, fil As Object, contenido As String, sal As Object

        'Nuevo objeto para crear leer y los archivos con Fso
        fso = CreateObject("Scripting.FileSystemObject")

        'Lee el archivo de origen y lo almacena en contenido
        fil = fso.OpenTextFile(PathOrigen, 1)

        contenido = fil.ReadAll

        'Crea un archivo para guardar las direcciones de email
        sal = fso.CreateTextFile(pathDestino, True)

        'Nuevo objeto de tipo RegExp para poder utilizar las expresiones regulares
        obj_Expresion = New RegExp

        'Se le pasa la expresion regular a la propiedad Pattern
        obj_Expresion.Pattern = Cadena_Expresion

        obj_Expresion.IgnoreCase = True

        obj_Expresion.Global = True

        ' Método Execute para pasarle el contenido del archivo a Evaluar
        Matches = obj_Expresion.Execute(contenido)

        ' recorre en la colección las direcciones y las escribe en el archivo txt de salida y las agrega al control List

        For Each Match In Matches
            sal.WriteLine(Match.Value)
            ListBox1.Items.Add(Match.Value)
        Next

        'Cierra los archivos
        sal.Close()
        fil.Close()

        'Fin
        MsgBox(" Finalizado ", vbInformation)
        Extraer_direccion_Email = True

        Exit Function

        'Error
errSub:
        MsgBox(Err.Description, vbCritical)
        Extraer_direccion_Email = False

    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Search.Click

        'Basic credit card
        'Call Extraer_direccion_Email(TextBox1.Text, TextBox2.Text, "^(\d{4}[- ]){3}\d{4}|\d{16}$")
        Call Extraer_direccion_Email(TextBox1.Text, TextBox2.Text, "(\d[\s|-]?){12,15}\d")

    End Sub
End Class