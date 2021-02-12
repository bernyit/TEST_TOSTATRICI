Imports System.Data.SqlClient
Imports System.Text

Public Class DB_PLC

    Shared DBobjLock As New Object

    Structure strBilance
        Dim opzionale As Boolean
        Dim obbligatoria As Boolean
    End Structure

    Structure strComponenteRicetta
        Dim indice As Integer
        Dim idComponente As Integer
        Dim kgSet As Decimal
        Dim kgTol As Decimal
        Dim fuoriLinea As Boolean
        Dim fattibileConB1 As Boolean
        Dim fattibileConB2 As Boolean
        Dim fattibileConB3 As Boolean
        Dim fattibileConB4 As Boolean
        Dim fattibileConB5 As Boolean
        Dim fattibileConXBilance As Int16
        Dim fattibilitaPerPlc As UInt16
    End Structure

    Structure strRicetta
        Dim idRicetta
        Dim componenti() As strComponenteRicetta
        Dim ricettaFattibile As Boolean
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
        Dim bilancia As Integer
    End Structure

    Structure strOrdineProduzioneRicetta
        Dim idComponente As Integer
        Dim kgSet As Decimal
        Dim kgTol As Decimal
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
            componenteRicetta.kgSet = comp.kgSet
            componenteRicetta.kgTol = comp.kgTol
            componenteRicetta.multiSilos = False
            componenteRicetta.fuoriLinea = comp.fuoriLinea
            componenteRicetta.listasilos = New List(Of strSilosPerRicetta)

            If comp.fuoriLinea = False Then

                Using TTA_DOSAGGIO As PLCTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter = New PLCTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter
                    Using data = TTA_DOSAGGIO.GetDataByComponenteEBilancia(comp.idComponente, b1, b2, b3)




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
                                    newSilos.bilancia = item.bilancia
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

    Public Shared Sub aggiornaComposizioneBilanceOnline(ByVal tostatrice As Integer, ByVal ricetta As Integer, programma As List(Of strOrdineProduzioneRicetta))





        Using TTA_TOST_BILANCE As PLCTableAdapters.tostatrici_bilance_onlineTableAdapter = New PLCTableAdapters.tostatrici_bilance_onlineTableAdapter
            TTA_TOST_BILANCE.DeleteComposizionePerTostatrice(tostatrice)


            Dim nrComponente As Integer = 0
            For Each item In programma
                nrComponente += 1
                Dim nrSilos As Integer = 0
                If item.fuoriLinea = False Then
                    For Each silos In item.listasilos
                        nrSilos += 1

                        TTA_TOST_BILANCE.InsertQuery(silos.bilancia, tostatrice, ricetta, nrComponente, item.idComponente, item.kgSet, item.kgTol, nrSilos, silos.silos)

                    Next
                Else
                    TTA_TOST_BILANCE.InsertQuery(10, tostatrice, ricetta, nrComponente, item.idComponente, item.kgSet, item.kgTol, nrSilos, 0)
                End If


            Next


        End Using


    End Sub








    Public Shared Function verificaFattibilita(ByVal idRicetta As Integer) As strRicetta

        Dim bilance(5) As strBilance
        Dim ricetta As New strRicetta
        ricetta.idRicetta = idRicetta

        Dim kgBilancia1, kgBilancia2, kgBilancia3, kgBilancia4, kgBilancia5 As Decimal


        Using TTA As DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceTableAdapter = New DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceTableAdapter
            Try

                Using actData = TTA.GetDataByIdRicetta(idRicetta)

                    If ReferenceEquals(actData, Nothing) = False Then

                        Dim progressivo As Integer = 0

                        For Each componente In actData
                            ReDim Preserve ricetta.componenti(progressivo)
                            ricetta.componenti(progressivo).indice = progressivo
                            ricetta.componenti(progressivo).idComponente = componente.id_componente
                            ricetta.componenti(progressivo).kgSet = componente.kg_set
                            ricetta.componenti(progressivo).kgTol = componente.kg_tol
                            ricetta.componenti(progressivo).fuoriLinea = componente.selezione_fl
                            Try
                                kgBilancia1 = componente.disponibileB1
                                If kgBilancia1 > componente.kg_set Then
                                    ricetta.componenti(progressivo).fattibileConB1 = True
                                    ricetta.componenti(progressivo).fattibileConXBilance += 1
                                End If

                            Catch ex As Exception

                            End Try
                            Try
                                kgBilancia2 = componente.disponibileB2
                                If kgBilancia2 > componente.kg_set Then
                                    ricetta.componenti(progressivo).fattibileConB2 = True
                                    ricetta.componenti(progressivo).fattibileConXBilance += 1
                                End If
                            Catch ex As Exception

                            End Try
                            Try
                                kgBilancia3 = componente.disponibileB3
                                If kgBilancia3 > componente.kg_set Then
                                    ricetta.componenti(progressivo).fattibileConB3 = True
                                    ricetta.componenti(progressivo).fattibileConXBilance += 1
                                End If
                            Catch ex As Exception

                            End Try
                            Try
                                kgBilancia4 = componente.disponibileB4
                                If kgBilancia4 > componente.kg_set Then
                                    ricetta.componenti(progressivo).fattibileConB4 = True
                                    ricetta.componenti(progressivo).fattibileConXBilance += 1
                                End If

                            Catch ex As Exception

                            End Try
                            Try
                                kgBilancia5 = componente.disponibileB5
                                If kgBilancia5 > componente.kg_set Then
                                    ricetta.componenti(progressivo).fattibileConB5 = True
                                    ricetta.componenti(progressivo).fattibileConXBilance += 1
                                End If
                            Catch ex As Exception

                            End Try

                            progressivo += 1
                        Next

                    End If
                End Using


                'DB.LOG_Insert(BeIT_LogType.Information, BeIT_LogArea.Socket, BeIT_LogZone.PLC, BeIT_LogOperation.Write, "Created PDO: " + PdoId)

            Catch ex As Exception

                'CElviLOG.writeLogFile(CElviLOG.ELogType.Alarm, CElviLOG.EPartner.General, "Create PDO: " + PdoId + " " + ex.Message)

            End Try

        End Using

        Dim auxwordPlc As UInt16
        ricetta.ricettaFattibile = True
        For Each componente In ricetta.componenti
            If componente.fattibileConB1 = False And componente.fattibileConB2 = False And componente.fattibileConB3 = False And
                    componente.fattibileConB4 = False And componente.fattibileConB5 = False And componente.fuoriLinea = False Then
                ricetta.ricettaFattibile = False
            End If



            assegnaFattibilitaBilanciaPerPlc(0, componente.fattibileConB1, componente.fattibileConXBilance, auxwordPlc)
            assegnaFattibilitaBilanciaPerPlc(1, componente.fattibileConB2, componente.fattibileConXBilance, auxwordPlc)
            assegnaFattibilitaBilanciaPerPlc(2, componente.fattibileConB3, componente.fattibileConXBilance, auxwordPlc)
            assegnaFattibilitaBilanciaPerPlc(3, componente.fattibileConB4, componente.fattibileConXBilance, auxwordPlc)
            assegnaFattibilitaBilanciaPerPlc(4, componente.fattibileConB5, componente.fattibileConXBilance, auxwordPlc)
            assegnaFattibilitaBilanciaPerPlc(5, componente.fuoriLinea, componente.fattibileConXBilance, auxwordPlc)
        Next


        Return ricetta
    End Function


    Private Shared Sub assegnaFattibilitaPerPlc(ByVal bitNr As UInt16, ByRef word As UInt16)

        Dim auxWord As UInt16 = 1 << bitNr

        word = word Xor auxWord
    End Sub

    Private Shared Sub assegnaFattibilitaBilanciaPerPlc(ByVal bilancia As UInt16, ByVal fattibile As Boolean, ByVal fattbileConXbilance As Int16, ByRef word As UInt16)

        Dim auxWordObbligatorio As UInt16 = 1 << bilancia

        Dim auxWordOpzionale As UInt16 = 1 << bilancia

        If opzionale = True Then
            word = word Xor auxWordOpzionale
        End If

        If obbligatorio = True Then
            word = word Xor auxWordObbligatorio
            word = word And Not auxWordOpzionale
        End If

    End Sub

End Class
