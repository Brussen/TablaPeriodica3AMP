# Barra de búsqueda modular 🔥🔥🔥
yamililio quiere que escriba como maruisio para que el detector de ia ia ia yeye no salte cffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff

bueno, dejando eso de lado,

**Código Completo:**

    Public Class Form1
          Dim IdleMsg As String = "Busca elementos en la tabla..."
          Private Sub search_Enter(sender As Object, e As EventArgs) Handles Searchbox.Enter
              Searchbox.Text = ""
          End Sub
          Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles Searchbox.TextChanged
              Dim text As String
      
              text = Searchbox.Text
      
              Dim Matched As Boolean = False
      
              For Each control As Control In Me.Controls
                  If TypeOf control Is Button Then
                      If control.Tag?.ToString = "periodicelement" Then
                          text = text.Normalize(NormalizationForm.FormD)
                          Dim normalText As New StringBuilder(text.Length)
                          For i As Integer = 0 To text.Length - 1
                              Dim c As Char = text(i)
                              If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark Then
                                  normalText.Append(Char.ToLowerInvariant(c))
                              End If
                          Next
                          If Not String.IsNullOrWhiteSpace(text) And Not Searchbox.Text = IdleMsg Then
                              Dim normal As String = normalText.ToString
                              If chkExact.Checked = True Then
                                  If comboFilterType.Text = "Nombre, Simbolo, #" Then
                                      Matched = control.Name.ToLower.Contains(normal) And (control.Name.ToLower)(6) = normal(0)
                                      If Matched = False Then
                                          If normal.Length = 1 Then
                                              Matched = (control.Text.ToLower)(0) = normal(0)
                                          ElseIf normal.Length > 1 Then
                                              Matched = (control.Text.ToLower) = normal
                                          End If
                                      End If
                                      If Matched = False Then
                                          Dim num As New StringBuilder(text.Length)
                                          num.Append(control.Name(3))
                                          num.Append(control.Name(4))
                                          num.Append(control.Name(5))
                                          Matched = Val(text) = Val(num.ToString)
                                      End If
                                  ElseIf comboFilterType.Text = "Nombre o Simbolo" Then
                                      Matched = control.Name.ToLower.Contains(normal) And (control.Name.ToLower)(6) = normal(0)
                                      If Matched = False Then
                                          If normal.Length = 1 Then
                                              Matched = (control.Text.ToLower)(0) = normal(0)
                                          ElseIf normal.Length > 1 Then
                                              Matched = (control.Text.ToLower) = normal
                                          End If
                                      End If
                                  ElseIf comboFilterType.Text = "Nombre" Then
                                      Matched = control.Name.ToLower.Contains(normal) And (control.Name.ToLower)(6) = normal(0)
                                  ElseIf comboFilterType.Text = "Simbolo" Then
                                      If normal.Length = 1 Then
                                          Matched = (control.Text.ToLower)(0) = normal(0)
                                      ElseIf normal.Length > 1 Then
                                          Matched = (control.Text.ToLower) = normal
                                      End If
                                  End If
                              Else
                                  If comboFilterType.Text = "Nombre, Simbolo, #" Then
                                      Matched = control.Name.ToLower.Contains(normal) Or Matched = control.Text.ToLower.Contains(normal)
                                      If Matched = False Then
                                          Dim num As New StringBuilder(text.Length)
                                          num.Append(control.Name(3))
                                          num.Append(control.Name(4))
                                          num.Append(control.Name(5))
                                          Matched = Val(text) = Val(num.ToString)
                                      End If
                                  ElseIf comboFilterType.Text = "Nombre o Simbolo" Then
                                      Matched = control.Name.ToLower.Contains(normal) Or Matched = control.Text.ToLower.Contains(normal)
                                  ElseIf comboFilterType.Text = "Nombre" Then
                                      Matched = control.Name.ToLower.Contains(normal)
                                  ElseIf comboFilterType.Text = "Simbolo" Then
                                      Matched = control.Text.ToLower.Contains(normal)
                                  End If
                              End If
      
                              If comboFilterType.Text = "Numero (#)" Then
                                  Dim num As New StringBuilder(text.Length)
                                  num.Append(control.Name(3))
                                  num.Append(control.Name(4))
                                  num.Append(control.Name(5))
                                  Matched = Val(text) = Val(num.ToString)
                              End If
      
                              If Matched = True Then
                                  control.Visible = True
                              Else
                                  control.Visible = False
                              End If
                          Else
                              control.Visible = True
                          End If
                      End If
                  End If
              Next
      
      
          End Sub
      
          Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
              Searchbox.Text = IdleMsg
          End Sub
          Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
              Searchbox.Text = IdleMsg
              ActiveControl = Nothing
          End Sub
      
          Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
              Close()
          End Sub
      
          Private Sub btnShowFilter_Click(sender As Object, e As EventArgs) Handles btnShowFilter.Click
              If GroupBox1.Height > 70 Then
                  GroupBox1.Height = 23
              Else
                  GroupBox1.Height = 78
              End If
              ActiveControl = Nothing
          End Sub
      End Class

# Gifs para que vean como funciona 🫀
<img width="854" height="480" alt="Name, Symbol or Number" src="https://github.com/user-attachments/assets/fcc2484f-b328-46e4-a0dc-476b46598953" />

<img width="854" height="480" alt="Name" src="https://github.com/user-attachments/assets/384e064d-b9be-491a-ab0c-f2170983501f" />

<img width="854" height="480" alt="Symbol" src="https://github.com/user-attachments/assets/5b46b84b-40cc-47d7-b6d8-53fb12459653" />

<img width="854" height="480" alt="Number" src="https://github.com/user-attachments/assets/33cb7f5a-6259-420b-acc9-f07a25220485" />

<img width="640" height="360" alt="Filters" src="https://github.com/user-attachments/assets/d0005bde-a8ec-416f-9c18-bab472632a11" /> <br>
jodete veed porque le pones marca de aguja a mi jif> <br> <br>
Los filtros actuales son: <br> <br>
**☺ Nombre, Simbolo, #** <br>
    Busca elementos utilizando su nombre, símbolo o número atómico. <br>
**☺ Nombre, Simbolo** <br>
    Busca elementos utilizando su nombre o símbolo. <br>
**☺ Nombre** <br>
    Busca elementos utilizando su nombre. <br>
**☺ Simbolo** <br>
    Busca elementos utilizando su símbolo. <br>
**☺ Numero** <br>
    Busca elementos utilizando su número atómico. <br>

# cosas técnicas para gente muy inteli:
(me sentí como los de canva escribiendo eso)


**Cómo añadir nuevos elementos:** <br>
para añadir el resto de elementos que faltan, primero, añade un botón al form, después, utiliza este formato para el nombre: <br> <br>
*btn000nombre* <br> <br> donde 000 es el número atómico (ej.- 001, 024, 156) y nombre es el nombre del elemento. en el texto del botón se pone el símbolo. Luego añadele la etiqueta *periodicelement*  (por esto tiene instrucciones el shampoo) <br> <br> Ahora mismo, el buscador solo busca elementos de máximo 2 letras y minimo 1 en su símbolo, si hacen uno de 3 no sirve. Esto es porque no existen elementos con 3 letras en su simbolo y si añaden uno entonces no es real y en ei trabajo la maestra quiere solo elementos reales, asi que no añadan elementos de fantasia. tampoco se equivoquen poniendole 3 letras al simbolo de un elemento 😊 <br>

**cosas que hize:** <br> <br>
* todo ♥
* Ahora IdleMsg si funciona al cargar el form; el evento Form1_load lo actualiza.
* Se añadieron los filtros de búsqueda (Todavía faltan más, estos son los más básicos.)
* Ahora la barra de búsqueda solo busca en los elementos del form de tipo botón y con la etiqueta "periodicelement".

<br> <br>

**Posibles problemas (???):** <br>
ninguno porque soy el mejor programador de mi casa ♥

<br><br>
en los proximos textos le bajo al reijy boyt
