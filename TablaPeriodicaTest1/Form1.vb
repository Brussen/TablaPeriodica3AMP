Imports System.Globalization
Imports System.Text

Public Class Form1
    Dim IdleMsg As String = "Busca elementos en la tabla..."
    Private Sub search_Enter(sender As Object, e As EventArgs) Handles Searchbox.Enter
        Searchbox.Text = ""
    End Sub
    Private Sub search_Exit(sender As Object, e As EventArgs) Handles Searchbox.Leave
        Searchbox.Text = IdleMsg
    End Sub
    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles Searchbox.TextChanged
        Dim text As String

        text = Searchbox.Text

        For Each control As Control In Me.Controls
            If TypeOf control Is Button Then
                text = text.Normalize(NormalizationForm.FormD)
                Dim normalText As New StringBuilder(text.Length)
                For i As Integer = 0 To text.Length - 1
                    Dim c As Char = text(i)
                    If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark Then
                        normalText.Append(Char.ToLowerInvariant(c))
                    End If
                Next
                If Not String.IsNullOrWhiteSpace(text) And Not Searchbox.Text = IdleMsg Then
                    If control.Name.ToLower.Contains("btn" & normalText.ToString) Or control.Text.ToLower.Contains(normalText.ToString) Then
                        control.Enabled = True
                    Else
                        control.Enabled = False
                    End If
                Else
                    control.Enabled = True
                End If
            End If
        Next


    End Sub

    Private Sub Form1_click(sender As Object, e As EventArgs) Handles MyBase.Click
        Me.ActiveControl = Nothing

    End Sub
End Class
