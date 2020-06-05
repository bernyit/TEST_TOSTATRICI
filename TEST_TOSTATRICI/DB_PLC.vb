Imports System.Data.SqlClient
Imports System.Text

Public Class DB_PLC

    Shared DBobjLock As New Object

    Structure strComponenteRicetta
        Dim indice As Integer
        Dim idComponente As Integer
        Dim kgSet As Decimal
        Dim kgTol As Decimal
        Dim fuoriLinea As Boolean
        Dim fattibileConB1 As Boolean
        Dim fattibileConB2 As Boolean
        Dim fattibileConB3 As Boolean
    End Structure

    Structure strRicetta
        Dim idRicetta
        Dim componenti() As strComponenteRicetta
    End Structure


    Structure strLista
        Dim lista As Hashtable
    End Structure


    Dim listaPercorsi As Hashtable()

    Public Shared Function leggiComponentiRicetta(ByVal idRicetta As Integer) As strRicetta


        Dim ricetta As New strRicetta
        ricetta.idRicetta = idRicetta

        Using TTA_PLC As PLCTableAdapters.ricetta_componentiTableAdapter = New PLCTableAdapters.ricetta_componentiTableAdapter
            Try

                Using actData = TTA_PLC.sp_RICETTA_COMPONENTI_GetComponenti(idRicetta)

                    If ReferenceEquals(actData, Nothing) = False Then

                        Dim progressivo As Integer = 0

                        For Each componente In actData
                            ReDim Preserve ricetta.componenti(progressivo)
                            ricetta.componenti(progressivo).indice = progressivo
                            ricetta.componenti(progressivo).idComponente = componente.id_componente
                            ricetta.componenti(progressivo).kgSet = componente.kg_set
                            ricetta.componenti(progressivo).kgTol = componente.kg_tol
                            ricetta.componenti(progressivo).fuoriLinea = componente.selezione_fl
                            progressivo += 1
                        Next

                    End If
                End Using


                'DB.LOG_Insert(BeIT_LogType.Information, BeIT_LogArea.Socket, BeIT_LogZone.PLC, BeIT_LogOperation.Write, "Created PDO: " + PdoId)

            Catch ex As Exception

                'CElviLOG.writeLogFile(CElviLOG.ELogType.Alarm, CElviLOG.EPartner.General, "Create PDO: " + PdoId + " " + ex.Message)

            End Try

        End Using

        Return ricetta
    End Function



    Structure strFattibilita
        Dim bilancia As Integer
    End Structure

    Public Shared Function fattibilitaComponente(ByVal idComponenti() As Integer, ByVal pesi() As Decimal) As Integer


        'Dim result As 


        Using TTA_PLC As PLCTableAdapters.viewComponentiTotaleDosaggioPerTostaturaTableAdapter = New PLCTableAdapters.viewComponentiTotaleDosaggioPerTostaturaTableAdapter
            Try

                Using actData = TTA_PLC.GetData()

                    Dim query As String = ""

                    For i As Integer = 0 To idComponenti.Count - 1

                        query = query & "([id_codice_Componente] = " & idComponenti(i) & " AND QUANTITA >= " & pesi(i).ToString("0") & ")"

                        If i < idComponenti.Count - 1 Then
                            query = query & " OR "
                        End If
                    Next


                    MsgBox(actData.Count)

                    Dim filteredData = actData.Select(query)
                    MsgBox(filteredData.Count)



                    'For Each item In filteredData
                    '    Trace  item.
                    'Next

                    'If ReferenceEquals(actData, Nothing) = False Then

                    '    Dim progressivo As Integer = 0

                    '    For Each componente In actData
                    '        ReDim Preserve ricetta.componenti(progressivo)
                    '        ricetta.componenti(progressivo).indice = progressivo
                    '        ricetta.componenti(progressivo).idComponente = componente.id_componente
                    '        ricetta.componenti(progressivo).kgSet = componente.kg_set
                    '        ricetta.componenti(progressivo).kgTol = componente.kg_tol
                    '        ricetta.componenti(progressivo).fuoriLinea = componente.selezione_fl
                    '        progressivo += 1
                    '    Next

                    'End If
                End Using


                'DB.LOG_Insert(BeIT_LogType.Information, BeIT_LogArea.Socket, BeIT_LogZone.PLC, BeIT_LogOperation.Write, "Created PDO: " + PdoId)

            Catch ex As Exception

                'CElviLOG.writeLogFile(CElviLOG.ELogType.Alarm, CElviLOG.EPartner.General, "Create PDO: " + PdoId + " " + ex.Message)

            End Try

        End Using

        'Return ricetta
    End Function



    Public Shared Function fattibilitaComponente(ByRef componente As strComponenteRicetta) As strComponenteRicetta

        Using TTA_PLC As PLCTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter = New PLCTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter
            Try

                Using actData = TTA_PLC.GetFattibilitaComponente(componente.idComponente, componente.kgSet)


                    For Each item In actData
                        If item.bilancia = 1 Then
                            componente.fattibileConB1 = True
                        End If
                        If item.bilancia = 2 Then
                            componente.fattibileConB2 = True
                        End If
                        If item.bilancia = 3 Then
                            componente.fattibileConB3 = True
                        End If
                    Next

                End Using


                'DB.LOG_Insert(BeIT_LogType.Information, BeIT_LogArea.Socket, BeIT_LogZone.PLC, BeIT_LogOperation.Write, "Created PDO: " + PdoId)

            Catch ex As Exception

                'CElviLOG.writeLogFile(CElviLOG.ELogType.Alarm, CElviLOG.EPartner.General, "Create PDO: " + PdoId + " " + ex.Message)

            End Try

        End Using

        Return componente
    End Function



    Public Shared Function creaMatrice(ByVal idRicetta As Integer) As Integer(,)

        Dim matrice = New Integer(9, 3) {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
        'Dim matrice(9, 3) As Integer
        Dim retMatrix = New Integer(9, 3) {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
        Using TTA_PLC As PLCTableAdapters.viewRicettaComponenti_join_ComponentiDosaggioPerTostaturaTableAdapter = New PLCTableAdapters.viewRicettaComponenti_join_ComponentiDosaggioPerTostaturaTableAdapter
            Try


                Using actData = TTA_PLC.GetDataByIdRicetta(idRicetta)

                    For Each row In actData

                        If row.selezione_fl = True Then
                            matrice(row.indice - 1, 3) = 1
                        Else
                            Select Case row.BILANCIA
                                Case "B1"
                                    matrice(row.indice - 1, 0) = 1
                                Case "B2"
                                    matrice(row.indice - 1, 1) = 1
                                Case "B3"
                                    matrice(row.indice - 1, 2) = 1
                            End Select
                        End If

                    Next

                End Using


                'DB.LOG_Insert(BeIT_LogType.Information, BeIT_LogArea.Socket, BeIT_LogZone.PLC, BeIT_LogOperation.Write, "Created PDO: " + PdoId)
                retMatrix = matrice
            Catch ex As Exception

                'CElviLOG.writeLogFile(CElviLOG.ELogType.Alarm, CElviLOG.EPartner.General, "Create PDO: " + PdoId + " " + ex.Message)

            End Try

        End Using

        Return retMatrix
    End Function



    Private Sub addNode(ByRef treeNode As TreeNode)

    End Sub


    Private Function Find_Path(ByVal matrix(,) As Integer, ByVal rowSize As Integer, ByVal colSize As Integer, ByVal a As Integer, ByVal b As Integer) As Integer
        If a = (rowSize - 1) AndAlso (b = colSize - 1) Then Return 1
        If matrix(a + 1, b) = 1 AndAlso Find_Path(matrix, rowSize, colSize, a + 1, b) Then Return 1
        If matrix(a, b + 1) = 1 AndAlso Find_Path(matrix, rowSize, colSize, a, b + 1) Then Return 1
        Return 0
    End Function


    Private Shared counter As Integer = 0

    Private Shared Sub combin2(ByVal depth As Integer, ByVal matrix(,) As Integer, ByVal output() As Integer)

        Try

            Dim row() As Integer = getArrayFromMatrix(depth, matrix)

            If (depth = 0) Then
                counter = 0
                output = New Integer((matrix.Length) - 1) {}
                Debug.Print(("matrix length: " + matrix.Length))
            End If

            Dim i As Integer = 0
            Do While (i < row.Length)
                output(depth) = row(i)
                If (depth = (matrix.Length - 1)) Then
                    'print the combination
                    Debug.Print(output.ToString())
                    counter = (counter + 1)
                Else
                    'recursively generate the combination
                    combin2((depth + 1), matrix, output)
                End If

                i = (i + 1)
            Loop
        Catch ex As Exception

        End Try


    End Sub

    Private Shared Function getArrayFromMatrix(ByVal depth As Integer, ByVal matrix(,) As Integer) As Integer()
        Dim result(matrix.Rank - 1) As Integer


        For column As Integer = 0 To matrix.Rank - 1
            result(column) = matrix(depth, column)
        Next

        Return result

    End Function





    Private Sub calcolaCombinazione(ByVal retVal As String, ByVal matrix As Integer(,), ByVal row As Integer)
        If row < 9 Then
            '  Dim oldRetVal As String = retVal
            For column = 0 To 3

                If matrix(row, column) > 0 Then
                    Dim newRetVal = retVal & column
                    If matrix(row + 1, 0) = 0 And matrix(row + 1, 1) = 0 And matrix(row + 1, 2) = 0 And matrix(row + 1, 3) = 0 Then
                        Debug.Write(newRetVal & vbCrLf)
                    Else
                        ' Debug.Write(newRetVal & "->" & vbCrLf)
                        calcolaCombinazione(newRetVal, matrix, row + 1)

                    End If
                End If


            Next
        End If

    End Sub




End Class
