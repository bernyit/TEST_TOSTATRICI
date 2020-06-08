Public Class TOSTATRICI_OK

    Enum enuCombinazioniBilance
        B1 = 1
        B2 = 2
        B3 = 3
        FL = 4
        B1_FL = 5
        B2_FL = 6
        B3_FL = 7
        B1_B2 = 8
        B2_B3 = 10
        B1_B2_FL = 11
        B1_B3_FL = 12
        B2_B3_FL = 13
        B1_B2_B3 = 14
        B1_B2_B3_FL = 15
    End Enum

    Dim ricetta As Integer = 0

    Dim matrix = New Integer(9, 3) {{0, 1, 0, 0}, {0, 0, 1, 0}, {0, 0, 1, 1}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}

    Dim combinazioniPerPlc As New List(Of Integer)

    Dim combinazioni3 As New List(Of Integer())
    Dim combinazioni2 As New List(Of String)
    Dim combinazioni As New List(Of String)

    Public Sub New()

    End Sub


    Public Sub creaMatrice(ByVal idRicetta As Integer)

        matrix = DB_PLC.creaMatrice(idRicetta)
        ricetta = idRicetta

    End Sub


    Public Sub calcolaCombinazioni()

        Dim retVal As String = ""
        Dim retVal2 As String = ""
        Dim retVal3 = New Integer(3) {0, 0, 0, 0}

        calcolaCombinazione(retVal, matrix, 0)

        calcolaCombinazione2(retVal2, matrix, 0)

        calcolaCombinazione3(retVal3, matrix, 0)

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


    '#####################################################################################################################################################################

    Private Sub calcolaCombinazione2(ByVal retVal As String, ByVal matrix As Integer(,), ByVal row As Integer)
        If row < 9 Then

            For column = 0 To 3

                If matrix(row, column) > 0 Then
                    Dim newRetVal = retVal & column
                    If matrix(row + 1, 0) = 0 And matrix(row + 1, 1) = 0 And matrix(row + 1, 2) = 0 And matrix(row + 1, 3) = 0 Then
                        'Debug.Write(newRetVal & vbCrLf)
                        combinazioni2.Add(newRetVal)
                    Else
                        calcolaCombinazione2(newRetVal, matrix, row + 1)
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub stampaCombinazioni2()
        Debug.Write("-------------------------------" & vbCrLf)
        Debug.Write("Ricetta " & ricetta & vbCrLf)
        For Each combinazione In combinazioni2
            Debug.Write(combinazione & vbCrLf)
        Next
        If combinazioni2.Count = 0 Then
            Debug.Write("NON ESEGUIBILE" & vbCrLf)
        End If
        Debug.Write("-------------------------------" & vbCrLf)
    End Sub


    '#####################################################################################################################################################################

    Private Sub calcolaCombinazione3(ByVal retVal As Integer(), ByVal matrix As Integer(,), ByVal row As Integer)
        If row < 9 Then

            For column = 0 To 3

                If matrix(row, column) > 0 Then
                    Dim newRetVal = New Integer(3) {0, 0, 0, 0}
                    Array.Copy(retVal, newRetVal, 4)

                    newRetVal(column) = 1
                    If matrix(row + 1, 0) = 0 And matrix(row + 1, 1) = 0 And matrix(row + 1, 2) = 0 And matrix(row + 1, 3) = 0 Then
                        'Debug.Write(newRetVal & vbCrLf)
                        combinazioni3.Add(newRetVal)
                    Else
                        calcolaCombinazione3(newRetVal, matrix, row + 1)
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub stampaCombinazioni3()
        Debug.Write("-------------------------------" & vbCrLf)
        Debug.Write("Ricetta " & ricetta & vbCrLf)
        For Each combinazione In combinazioni3
            Debug.Write(combinazione(0) & combinazione(1) & combinazione(2) & combinazione(3) & vbCrLf)
        Next
        If combinazioni3.Count = 0 Then
            Debug.Write("NON ESEGUIBILE" & vbCrLf)
        End If
        Debug.Write("-------------------------------" & vbCrLf)
        convertiCombinazioniPerPlc()
    End Sub
    Public Sub convertiCombinazioniPerPlc()

        If combinazioni2.Count = 0 Then
            Debug.Write("NON FATTIBILE" & vbCrLf)
        Else
            For Each combinazione In combinazioni3
                Dim firstElement = True

                If (combinazione(0)) Then
                    Debug.Write("B1")
                    firstElement = False
                End If

                If (combinazione(1)) Then
                    If firstElement = False Then
                        Debug.Write("+")
                    End If
                    Debug.Write("B2")
                    firstElement = False
                End If

                If (combinazione(2)) Then
                    If firstElement = False Then
                        Debug.Write("+")
                    End If
                    Debug.Write("B3")
                    firstElement = False
                End If

                If (combinazione(3)) Then
                    If firstElement = False Then
                        Debug.Write("+")
                    End If
                    Debug.Write("FL")
                    firstElement = False
                End If
                Debug.Write(vbCrLf)
            Next
        End If


    End Sub

End Class
