Public Class TOSTATRICI

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

    Private _ricetta As Integer = 0

    Private _matrix = New Integer(9, 3) {
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0},
                                            {0, 0, 0, 0}
                                        }

    Private _combinazioniPerPlc As New List(Of Integer)

    Private _combinazioni As New List(Of Integer())

    Public Sub New()

    End Sub


    Public Sub creaMatrice(ByVal idRicetta As Integer)

        _matrix = DB_PLC.creaMatrice(idRicetta)
        _ricetta = idRicetta

    End Sub


    Public Sub calcolaCombinazioni()

        Dim retVal = New Integer(3) {0, 0, 0, 0}

        calcolaCombinazione(retVal, _matrix, 0)

    End Sub



    '#####################################################################################################################################################################

    Private Sub calcolaCombinazione(ByVal retVal As Integer(), ByVal matrix As Integer(,), ByVal row As Integer)
        If row < 9 Then

            For column = 0 To 3

                If matrix(row, column) > 0 Then
                    Dim newRetVal = New Integer(3) {0, 0, 0, 0}
                    Array.Copy(retVal, newRetVal, 4)

                    newRetVal(column) = 1
                    If matrix(row + 1, 0) = 0 And matrix(row + 1, 1) = 0 And matrix(row + 1, 2) = 0 And matrix(row + 1, 3) = 0 Then
                        'Debug.Write(newRetVal & vbCrLf)
                        _combinazioni.Add(newRetVal)
                    Else
                        calcolaCombinazione(newRetVal, matrix, row + 1)
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub stampaCombinazioni()
        Debug.Write("-------------------------------" & vbCrLf)
        Debug.Write("Ricetta " & _ricetta & vbCrLf)
        For Each combinazione In _combinazioni
            Debug.Write(combinazione(0) & combinazione(1) & combinazione(2) & combinazione(3) & vbCrLf)
        Next
        If _combinazioni.Count = 0 Then
            Debug.Write("NON ESEGUIBILE" & vbCrLf)
        End If
        convertiCombinazioniPerPlc2()
        Debug.Write("-------------------------------" & vbCrLf)
    End Sub

    Public Sub convertiCombinazioniPerPlc()

        If _combinazioni.Count = 0 Then
            Debug.Write("NON FATTIBILE" & vbCrLf)
        Else
            For Each combinazione In _combinazioni
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




    Public Function convertiCombinazioniPerPlc2() As List(Of Integer)

        Dim retVal As New List(Of Integer)

        If _combinazioni.Count = 0 Then
            Debug.Write("NON FATTIBILE" & vbCrLf)
        Else
            For Each combinazione In _combinazioni

                Dim combinazioneInteger As Integer
                Dim plcId As Integer = 0
                combinazioneInteger = combinazione(0) * 1000
                combinazioneInteger += combinazione(1) * 100
                combinazioneInteger += combinazione(2) * 10
                combinazioneInteger += combinazione(3) * 1


                Select Case combinazioneInteger
                    Case 1000
                        plcId = 1
                    Case 100
                        plcId = 2
                    Case 10
                        plcId = 3
                    Case 1
                        plcId = 4
                    Case 1001
                        plcId = 5
                    Case 101
                        plcId = 6
                    Case 11
                        plcId = 7
                    Case 1100
                        plcId = 8
                    Case 1010
                        plcId = 9
                    Case 110
                        plcId = 10
                    Case 1101
                        plcId = 11
                    Case 1011
                        plcId = 12
                    Case 111
                        plcId = 13
                    Case 1110
                        plcId = 14
                    Case 1111
                        plcId = 15
                End Select

                If plcId > 0 Then
                    If retVal.Contains(plcId) = False Then
                        retVal.Add(plcId)
                        Debug.Write("Plc Id " & plcId & vbCrLf)
                    End If

                End If


            Next
        End If


        Return retVal

    End Function

End Class
