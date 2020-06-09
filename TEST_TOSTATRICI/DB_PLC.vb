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


    Structure strSilosPerRicetta
        Dim silos As Integer
        Dim idComponente As Integer
        Dim kg As Decimal
    End Structure

    Structure strOrdineProduzioneRicetta
        Dim idComponente As Integer
        Dim kg As Decimal
        Dim multiSilos As Boolean
        Dim fuoriLinea As Boolean
        Dim listasilos As List(Of strSilosPerRicetta)
    End Structure


    Public Shared Function trovaSilosPerTostatrice(ByVal idRicetta As Integer, ByVal combinazioneBilance As TOSTATRICI.enuCombinazioniBilance) As List(Of strOrdineProduzioneRicetta)



        Dim ricetta = leggiComponentiRicetta(idRicetta)
        Dim b1, b2, b3, fl As Integer


        Dim programma As New List(Of strOrdineProduzioneRicetta)

        'decodifica combinazioneBilance per verificare da quali bilance scaricare
        TOSTATRICI.bilanceInCuiCercare(combinazioneBilance, b1, b2, b3, fl)


        For Each comp In ricetta.componenti

            Dim componenteRicetta As New strOrdineProduzioneRicetta

            componenteRicetta.idComponente = comp.idComponente
            componenteRicetta.kg = comp.kgSet
            componenteRicetta.multiSilos = False
            componenteRicetta.fuoriLinea = comp.fuoriLinea
            componenteRicetta.listasilos = New List(Of strSilosPerRicetta)

            If comp.fuoriLinea = False Then

                Using TTA As PLCTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter = New PLCTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter

                    Using data = TTA.GetDataByComponenteEBilancia(comp.idComponente, b1, b2, b3)

                        Dim pesoResiduo As Decimal = comp.kgSet

                        For Each item In data
                            If pesoResiduo > 0 Then
                                If item.abilitatoAlloScarico = True Then
                                    Dim pesoDaPrelevareNelSilos As Decimal

                                    If item.quantitaRimanente >= pesoResiduo Then
                                        pesoDaPrelevareNelSilos = pesoResiduo
                                    Else
                                        pesoDaPrelevareNelSilos = item.quantitaRimanente
                                        pesoResiduo = pesoResiduo - item.quantitaRimanente
                                    End If

                                    Dim newSilos As strSilosPerRicetta
                                    newSilos.silos = item.IdSilos
                                    newSilos.idComponente = item.id_codice_componente
                                    newSilos.kg = pesoResiduo

                                    componenteRicetta.listasilos.Add(newSilos)

                                End If
                            End If

                        Next

                    End Using

                End Using


            End If

            programma.Add(componenteRicetta)


        Next

        Return programma
    End Function




End Class
