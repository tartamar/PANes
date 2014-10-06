Imports VBScript_RegExp_55

Public Class Form1

    'RE Function
    Function Extraer_Tarjeta(ByVal PathOrigen As String, ByVal pathDestino As String, ByVal Cadena_Expresion As String) As Boolean

        Dim obj_Expresion As RegExp, Match, Matches
        Dim fso As Object, fil As Object, contenido As String, sal As Object

        'Create and Read Files
        fso = CreateObject("Scripting.FileSystemObject")

        'Read source file
        fil = fso.OpenTextFile(PathOrigen, 1)

        contenido = fil.ReadAll

        'Create file destination
        sal = fso.CreateTextFile(pathDestino, True)

        'RegExp
        obj_Expresion = New RegExp

        'RE to Pattern
        obj_Expresion.Pattern = Cadena_Expresion
        obj_Expresion.IgnoreCase = True
        obj_Expresion.Global = True

        'Execute - Content
        Matches = obj_Expresion.Execute(contenido)

        'Read a colection and write txt file
        For Each Match In Matches
            sal.WriteLine(Match.Value)
            ListBox1.Items.Add(Match.Value)
        Next

        'Close files
        sal.Close()
        fil.Close()

        'End
        MsgBox(" File Complete ", vbInformation)
        Extraer_Tarjeta = True

        Exit Function

        'Error
errSub:
        MsgBox(Err.Description, vbCritical)
        Extraer_Tarjeta = False

    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Search.Click
        'Check text
        If TextBox1.Text = "" Then
            MsgBox("Source File is empy")
        Else
            If TextBox2.Text = "" Then
                MsgBox("Destination File is empy")
            Else
                'Basic credit card
                'Call Extraer_direccion_Email(TextBox1.Text, TextBox2.Text, "^(\d{4}[- ]){3}\d{4}|\d{16}$")
                Call Extraer_Tarjeta(TextBox1.Text, TextBox2.Text, "(\d[\s|-]?){12,15}\d")
            End If
        End If

    End Sub
End Class