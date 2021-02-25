Public Class BILANCE

    Enum enuBilance
        B1_OBBLIGATORIA = 0
        B2_OBBLIGATORIA = 1
        B3_OBBLIGATORIA = 2
        B4_OBBLIGATORIA = 3
        B5_OBBLIGATORIA = 4
        FL_OBBLIGATORIA = 7
        B1_OPZIONALE = 8
        B2_OPZIONALE = 9
        B3_OPZIONALE = 10
        B4_OPZIONALE = 11
        B5_OPZIONALE = 12
    End Enum

    Structure strSelezioneBilance
        Dim selezioneB1 As UInt16
        Dim selezioneB2 As UInt16
        Dim selezioneB3 As UInt16
        Dim selezioneB4 As UInt16
        Dim selezioneB5 As UInt16
        Dim spare1 As UInt16
        Dim spare2 As UInt16
        Dim selezioneFL As UInt16
    End Structure


    Public Shared Function spacchettaSelezione(ByVal combinazioneBilance As UInt16)

        Dim result As strSelezioneBilance

        result.selezioneB1 = combinazioneBilance And 1
        result.selezioneB2 = combinazioneBilance And 2
        result.selezioneB3 = combinazioneBilance And 4
        result.selezioneB4 = combinazioneBilance And 8
        result.selezioneB5 = combinazioneBilance And 16
        result.spare1 = combinazioneBilance And 32
        result.spare2 = combinazioneBilance And 64
        result.selezioneFL = combinazioneBilance And 128


        Return result
    End Function

    Public Shared Function bitBilancia(ByVal bilancia As enuBilance)

        Dim mask As UInt16 = 1 << bilancia

        Return mask
    End Function

    Public Shared Function combinazioneFattibileColor(ByVal bilancia As enuBilance, ByVal wordCombinazioni As UInt16) As Color

        Dim combinazioneOK As Color = Color.Gray

        Dim auxword As UInt16 = bitBilancia(bilancia)

        If (auxword And wordCombinazioni) > 0 Then
            combinazioneOK = Color.LightGreen
        End If


        Return combinazioneOK
    End Function

    Enum enuPesateSequenza
        START_PRODUZIONE = 1
        SILOS_SUCCESSIVO = 2
        PRODOTTO_SUCCESSIVO = 3
        FINE_CICLO = 5
    End Enum

    Public Shared Sub CalcolaProssimoSilos(ByVal msgDaPlc As GMK_LEVEL2_TOSTATRICI.strTelFromPlc_1X_RichiestaSilosPerBilanciaX, ByVal bilancia As Int16)


        Dim sequenza As enuPesateSequenza = msgDaPlc.sequenzaRichiesta '1=START PRODUZIONE, 2=SILOS SUCCESSIVO, 3=PRODOTTO SUCCESSIVO, 5=FINE CICLO
        Dim msgPerplc As GMK_LEVEL2_TOSTATRICI.strTelToPlc_1x_SilosDaScaricare
        Dim prossimoSilos As strProgrammaBilancia
        Select Case sequenza
            Case enuPesateSequenza.START_PRODUZIONE
                'verifica quale componente prelevare, leggendo da tabella tostatrici_setup_programma
                'cerca  il primo silos (già iniziato, poi il più vecchio) abilitato allo scarico
                'e lo comunica al plc
                prossimoSilos = trovaSilosDaScaricare(msgDaPlc.tostatriceNr, msgDaPlc.ricettaNr, msgDaPlc.idRichiesta, bilancia)
            Case enuPesateSequenza.SILOS_SUCCESSIVO
                'se il plc chiede silos successivo, dobbiamo cercare lo stesso componente precedentemente inviato
                '(informazione data da msgDaPlc.indice_componente)
                prossimoSilos = trovaSilosDaScaricare(msgDaPlc.tostatriceNr, msgDaPlc.ricettaNr, msgDaPlc.idRichiesta, bilancia)
            Case enuPesateSequenza.PRODOTTO_SUCCESSIVO
                'in questo caso, salviamo che il prodotto è completato, andiamo a cercare l'indice_componente successivo
                'cerchiamo il silos e lo inviamo a plc
                ricettaImpostaComponenteCompletato(msgDaPlc.tostatriceNr, bilancia, msgDaPlc.indice_componente)
                prossimoSilos = trovaSilosDaScaricare(msgDaPlc.tostatriceNr, msgDaPlc.ricettaNr, msgDaPlc.idRichiesta, bilancia)
            Case enuPesateSequenza.FINE_CICLO
                'ultima pesata della bilancia, usata solo per calcolare il peso dell'ultimo componente

        End Select


        msgPerplc.idRichiesta = msgDaPlc.idRichiesta
        msgPerplc.tostatriceNr = msgDaPlc.tostatriceNr
        msgPerplc.ricettaNr = msgDaPlc.ricettaNr
        msgPerplc.combinazioneBilance = 0
        msgPerplc.SingoloSilos = 0  ' C'è un solo silos sopra questa bilancia con lo stesso componente, abilitato allo scarico
        msgPerplc.SilosMultipli = 0 ' Ci sono più silos sopra questa bilancia con lo stesso componente, abilitati allo scarico
        msgPerplc.FineRicetta = 0   ' Non ci sono altri componenti da scaricare su questa bilancia
        msgPerplc.silosPrelievo = prossimoSilos.prossimoSilosDaScaricare
        msgPerplc.codiceProdotto = prossimoSilos.idComponente
        msgPerplc.pesoDaPrelevare = prossimoSilos.totaleKgPerBilancia   'è il peso totale da scaricare, quello della ricetta.
        msgPerplc.tolleranzaPeso = 0
        msgPerplc.lotto = 0


    End Sub


    Structure strProgrammaBilancia
        Dim idComponente As Int16
        Dim prossimoSilosDaScaricare As Int16
        Dim quantitaSilos As Int16
        Dim componentiEseguiti As Int16
        Dim componentiDaEseguire As Int16
        Dim totaleComponentiPerBilancia As Int16
        Dim totaleKgPerBilancia As Int16
    End Structure

    Private Shared Function trovaSilosDaScaricare(ByVal tostatrice As Int16, ByVal ricetta As Int16, ByVal idRichiesta As Int32, ByVal bilancia As Int16) As strProgrammaBilancia

        Dim programmaBilancia As strProgrammaBilancia

        Using TTA As New DBTableAdapters.tostatrici_Setup_ProgrammaTableAdapter
            Using programma = TTA.sp_TOSTATRICI_SETUP_PROGRAMMA_SelectByBilancia(tostatrice, ricetta, idRichiesta, bilancia)
                If ReferenceEquals(programma, Nothing) = False Then
                    programmaBilancia.totaleComponentiPerBilancia = programma.Count
                    programmaBilancia.componentiDaEseguire = programmaBilancia.totaleComponentiPerBilancia
                    If programmaBilancia.totaleComponentiPerBilancia > 0 Then
                        For Each componente In programma
                            programmaBilancia.totaleKgPerBilancia += componente.kg_set

                            If componente.eseguito = True Then
                                programmaBilancia.componentiEseguiti += 1
                                programmaBilancia.componentiDaEseguire -= 1
                            Else
                                If programmaBilancia.prossimoSilosDaScaricare = 0 Then
                                    programmaBilancia.idComponente = componente.id_componente
                                    Using TTA_SILOS As New DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter
                                        Using elencoSilos = TTA_SILOS.sp_VIEW_MAGAZZINO_DOSAGGIO_TOTALE_GetSilosDaScaricare(programmaBilancia.idComponente, bilancia)
                                            If ReferenceEquals(elencoSilos, Nothing) = False Then
                                                If elencoSilos.Count > 0 Then
                                                    programmaBilancia.prossimoSilosDaScaricare = elencoSilos(0).IdSilos
                                                End If
                                            End If
                                        End Using
                                    End Using
                                End If

                            End If
                        Next
                    End If
                End If
            End Using
        End Using

        Return programmaBilancia
    End Function

    Private Shared Sub ricettaImpostaComponenteCompletato(ByVal tostatrice As Int16, ByVal bilancia As Int16, ByVal indiceComponente As Int16)
        Using TTA As New DBTableAdapters.tostatrici_Setup_ProgrammaTableAdapter
            TTA.sp_TOSTATRICI_SETUP_PROGRAMMA_ImpostaComponenteEseguito(tostatrice, indiceComponente)
        End Using
    End Sub
End Class
