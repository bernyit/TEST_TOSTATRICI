Public Class TOSTATRICI

    Dim ricetta As Integer = 0

    Dim matrix = New Integer(9, 3) {{0, 1, 0, 0}, {0, 0, 1, 0}, {0, 0, 1, 1}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}

    Dim combinazioni As New List(Of String)
    Public Sub New()

    End Sub



    Public Sub creaMatrice(ByVal idRicetta As Integer)

        matrix = DB_PLC.creaMatrice(idRicetta)
        ricetta = idRicetta

    End Sub


    Public Sub calcolaCombinazioni()

        Dim retVal As String = ""

        calcolaCombinazione(retVal, matrix, 0)

    End Sub


    Public Sub stampaCombinazioni()
        Debug.Write("-------------------------------" & vbCrLf)
        Debug.Write("Ricetta " & ricetta & vbCrLf)
        For Each combinazione In combinazioni
            Debug.Write(combinazione & vbCrLf)
        Next
        If combinazioni.Count = 0 Then
            Debug.Write("NON ESEGUIBILE" & vbCrLf)
        End If
        Debug.Write("-------------------------------" & vbCrLf)
    End Sub

    Private Sub calcolaCombinazione(ByVal retVal As String, ByVal matrix As Integer(,), ByVal row As Integer)
        If row < 9 Then

            For column = 0 To 3

                If matrix(row, column) > 0 Then
                    Dim newRetVal = retVal & decodeScale(column) & "-"
                    If matrix(row + 1, 0) = 0 And matrix(row + 1, 1) = 0 And matrix(row + 1, 2) = 0 And matrix(row + 1, 3) = 0 Then
                        'Debug.Write(newRetVal & vbCrLf)
                        combinazioni.Add(newRetVal)
                    Else
                        calcolaCombinazione(newRetVal, matrix, row + 1)
                    End If
                End If
            Next
        End If
    End Sub


    Private Function decodeScale(ByVal column As Integer) As String
        Dim retVal As String = ""
        Select Case column
            Case 0
                retVal = "B1"
            Case 1
                retVal = "B2"
            Case 2
                retVal = "B3"
            Case 3
                retVal = "FL"
            Case Else
                retVal = "!"
        End Select
        Return retVal
    End Function

End Class
