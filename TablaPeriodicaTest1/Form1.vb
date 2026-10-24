Imports System.Globalization
Imports System.Text

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
' no lo vayas a reclamar, yamil /hj