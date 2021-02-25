Public Class SETUP_TOSTATRICI

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
        Dim fattibileConFL As Boolean
        Dim fattibileConXBilance As Int16
        Dim fattibilitaPerPlc As UInt16
        Dim pioritaMassima As UInt16
    End Structure

    Structure strRicetta
        Dim idRicetta
        Dim componenti As List(Of strComponenteRicetta)
        Dim ricettaFattibile As Boolean
        Dim compinazionePerPlc As UInt16
    End Structure

    Structure strBilancePerRicetta
        Dim idComponente As Int16
        Dim kg As Decimal
        Dim bilancia As Int16
        Dim componenteRicetta As strComponenteRicetta
    End Structure




    'Public Shared Function verificaFattibilita(ByVal idRicetta As Integer) As strRicetta

    '    Dim bilance(5) As strBilance
    '    Dim ricetta As New strRicetta
    '    Dim ricettaEsistente As Boolean
    '    ricetta.idRicetta = idRicetta

    '    Dim kgBilancia1, kgBilancia2, kgBilancia3, kgBilancia4, kgBilancia5 As Decimal


    '    Using TTA As DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceConPrioritaTableAdapter = New DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceConPrioritaTableAdapter
    '        Try

    '            Using actData = TTA.GetDataByIdRicetta(idRicetta)

    '                If ReferenceEquals(actData, Nothing) = False Then
    '                    If actData.Count > 0 Then
    '                        ricettaEsistente = True
    '                        Dim progressivo As Integer = 0

    '                        For Each componente In actData
    '                            ReDim Preserve ricetta.componenti(progressivo)
    '                            ricetta.componenti(progressivo).indice = progressivo
    '                            ricetta.componenti(progressivo).idComponente = componente.id_componente
    '                            ricetta.componenti(progressivo).kgSet = componente.kg_set
    '                            ricetta.componenti(progressivo).kgTol = componente.kg_tol
    '                            ricetta.componenti(progressivo).fuoriLinea = componente.selezione_fl
    '                            ricetta.componenti(progressivo).pioritaMassima = ritornaPriorita(componente)

    '                            Try
    '                                kgBilancia1 = componente.disponibileB1
    '                                If kgBilancia1 > componente.kg_set Then
    '                                    If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B1 Then
    '                                        ricetta.componenti(progressivo).fattibileConB1 = True
    '                                        ricetta.componenti(progressivo).fattibileConXBilance += 1
    '                                    End If
    '                                End If

    '                            Catch ex As Exception

    '                            End Try
    '                            Try
    '                                kgBilancia2 = componente.disponibileB2
    '                                If kgBilancia2 > componente.kg_set Then
    '                                    If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B2 Then
    '                                        ricetta.componenti(progressivo).fattibileConB2 = True
    '                                        ricetta.componenti(progressivo).fattibileConXBilance += 1
    '                                    End If

    '                                End If
    '                            Catch ex As Exception

    '                            End Try
    '                            Try
    '                                kgBilancia3 = componente.disponibileB3
    '                                If kgBilancia3 > componente.kg_set Then
    '                                    If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B3 Then
    '                                        ricetta.componenti(progressivo).fattibileConB3 = True
    '                                        ricetta.componenti(progressivo).fattibileConXBilance += 1
    '                                    End If
    '                                End If
    '                            Catch ex As Exception

    '                            End Try
    '                            Try
    '                                kgBilancia4 = componente.disponibileB4
    '                                If kgBilancia4 > componente.kg_set Then
    '                                    If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B4 Then
    '                                        ricetta.componenti(progressivo).fattibileConB4 = True
    '                                        ricetta.componenti(progressivo).fattibileConXBilance += 1
    '                                    End If

    '                                End If

    '                            Catch ex As Exception

    '                            End Try
    '                            Try
    '                                kgBilancia5 = componente.disponibileB5
    '                                If kgBilancia5 > componente.kg_set Then
    '                                    If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B5 Then
    '                                        ricetta.componenti(progressivo).fattibileConB5 = True
    '                                        ricetta.componenti(progressivo).fattibileConXBilance += 1
    '                                    End If

    '                                End If
    '                            Catch ex As Exception

    '                            End Try

    '                            progressivo += 1
    '                        Next

    '                    End If
    '                End If
    '            End Using


    '            'DB.LOG_Insert(BeIT_LogType.Information, BeIT_LogArea.Socket, BeIT_LogZone.PLC, BeIT_LogOperation.Write, "Created PDO: " + PdoId)

    '        Catch ex As Exception

    '            'CElviLOG.writeLogFile(CElviLOG.ELogType.Alarm, CElviLOG.EPartner.General, "Create PDO: " + PdoId + " " + ex.Message)

    '        End Try

    '    End Using


    '    If ricettaEsistente Then
    '        ricetta.ricettaFattibile = True

    '        For Each componente In ricetta.componenti
    '            If componente.fattibileConB1 = False And componente.fattibileConB2 = False And componente.fattibileConB3 = False And
    '                    componente.fattibileConB4 = False And componente.fattibileConB5 = False And componente.fuoriLinea = False Then
    '                ricetta.ricettaFattibile = False
    '            End If
    '        Next

    '        If ricetta.ricettaFattibile Then
    '            ricetta.compinazionePerPlc = 0
    '            For Each componente In ricetta.componenti
    '                assegnaFattibilitaBilanciaPerPlc(0, componente.fattibileConB1, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
    '                assegnaFattibilitaBilanciaPerPlc(1, componente.fattibileConB2, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
    '                assegnaFattibilitaBilanciaPerPlc(2, componente.fattibileConB3, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
    '                assegnaFattibilitaBilanciaPerPlc(3, componente.fattibileConB4, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
    '                assegnaFattibilitaBilanciaPerPlc(4, componente.fattibileConB5, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
    '                assegnaFattibilitaBilanciaPerPlc(5, componente.fuoriLinea, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
    '            Next
    '        End If
    '    End If
    '    Return ricetta
    'End Function






    Public Shared Function ritornaPriorita(ByVal row As DB.view_RicettaComponenti_disponibilitaBilanceConPrioritaRow) As UInt16

        Dim priorita As Int16 = 0
        If row.PRIORITA_B1 > priorita Then priorita = row.PRIORITA_B1
        If row.PRIORITA_B2 > priorita Then priorita = row.PRIORITA_B2
        If row.PRIORITA_B3 > priorita Then priorita = row.PRIORITA_B3
        If row.PRIORITA_B4 > priorita Then priorita = row.PRIORITA_B4
        If row.PRIORITA_B5 > priorita Then priorita = row.PRIORITA_B5

        Return priorita

    End Function




    ' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    ' TENTATIVO DI RAGGRUPPAMENTO IN UNA CLASSE


    ''' <summary>
    ''' Questa funzione si basa sulla vista "view_RicettaComponenti_disponibilitaBilanceConPriorita"
    '''In questa vista, per ogni componente della ricetta, viene mostrato quanti kg sono disponibili per ogni bilancia.
    '''inoltre per ogni bilancia, viene indicato, nella priorità, quanti componenti della ricetta sono presenti in quella bilancia
    '''                          |  disponibileB1  PRIORITA_B1 
    '''                          |  disponibileB2  PRIORITA_B2 
    ''' id_ricetta id_componente |  disponibileB3  PRIORITA_B3 
    '''                          |  disponibileB4  PRIORITA_B4 
    '''                          |  disponibileB5  PRIORITA_B5
    '''                          
    ''' Per ogni componente, sceglie le bilance in modo da utilizzarne il minor numero possibile
    ''' esempio: Se è possibile eseguire la ricetta con B1 oppure con B1+B2, il sistema mostrerà solo la combinazione B1
    ''' </summary>
    ''' <param name="idRicetta"></param>
    ''' <returns></returns>
    Public Shared Function verificaFattibilita(ByVal idRicetta As Integer) As strRicetta

        Dim ricetta As New strRicetta
        Dim ricettaEsistente As Boolean = False

        ricetta.idRicetta = idRicetta

        Dim kgBilancia1, kgBilancia2, kgBilancia3, kgBilancia4, kgBilancia5 As Decimal


        Using TTA As DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceConPrioritaTableAdapter = New DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceConPrioritaTableAdapter
            Try

                Using actData = TTA.GetDataByIdRicetta(idRicetta)

                    If ReferenceEquals(actData, Nothing) = False Then
                        If actData.Count > 0 Then
                            ricettaEsistente = True
                            Dim progressivo As Integer = 0
                            ricetta.componenti = New List(Of strComponenteRicetta)
                            For Each componenteDB In actData
                                Dim newComponente As New strComponenteRicetta
                                newComponente.indice = progressivo
                                newComponente.idComponente = componenteDB.id_componente
                                newComponente.kgSet = componenteDB.kg_set
                                newComponente.kgTol = componenteDB.kg_tol
                                newComponente.fuoriLinea = componenteDB.selezione_fl
                                newComponente.pioritaMassima = SETUP_TOSTATRICI.ritornaPriorita(componenteDB)

                                Try
                                    kgBilancia1 = componenteDB.disponibileB1
                                    If kgBilancia1 > componenteDB.kg_set Then
                                        If newComponente.pioritaMassima = componenteDB.PRIORITA_B1 Then
                                            newComponente.fattibileConB1 = True
                                            newComponente.fattibileConXBilance += 1
                                        End If
                                    End If

                                Catch ex As Exception

                                End Try
                                Try
                                    kgBilancia2 = componenteDB.disponibileB2
                                    If kgBilancia2 > componenteDB.kg_set Then
                                        If newComponente.pioritaMassima = componenteDB.PRIORITA_B2 Then
                                            newComponente.fattibileConB2 = True
                                            newComponente.fattibileConXBilance += 1
                                        End If

                                    End If
                                Catch ex As Exception

                                End Try
                                Try
                                    kgBilancia3 = componenteDB.disponibileB3
                                    If kgBilancia3 > componenteDB.kg_set Then
                                        If newComponente.pioritaMassima = componenteDB.PRIORITA_B3 Then
                                            newComponente.fattibileConB3 = True
                                            newComponente.fattibileConXBilance += 1
                                        End If
                                    End If
                                Catch ex As Exception

                                End Try
                                Try
                                    kgBilancia4 = componenteDB.disponibileB4
                                    If kgBilancia4 > componenteDB.kg_set Then
                                        If newComponente.pioritaMassima = componenteDB.PRIORITA_B4 Then
                                            newComponente.fattibileConB4 = True
                                            newComponente.fattibileConXBilance += 1
                                        End If

                                    End If

                                Catch ex As Exception

                                End Try
                                Try
                                    kgBilancia5 = componenteDB.disponibileB5
                                    If kgBilancia5 > componenteDB.kg_set Then
                                        If newComponente.pioritaMassima = componenteDB.PRIORITA_B5 Then
                                            newComponente.fattibileConB5 = True
                                            newComponente.fattibileConXBilance += 1
                                        End If

                                    End If
                                Catch ex As Exception

                                End Try

                                ricetta.componenti.Add(newComponente)

                                progressivo += 1
                            Next

                        End If
                    End If
                End Using


                'DB.LOG_Insert(BeIT_LogType.Information, BeIT_LogArea.Socket, BeIT_LogZone.PLC, BeIT_LogOperation.Write, "Created PDO: " + PdoId)

            Catch ex As Exception

                'CElviLOG.writeLogFile(CElviLOG.ELogType.Alarm, CElviLOG.EPartner.General, "Create PDO: " + PdoId + " " + ex.Message)

            End Try

        End Using


        If ricettaEsistente Then
            ricetta.ricettaFattibile = True

            For Each componente In ricetta.componenti
                If componente.fattibileConB1 = False And componente.fattibileConB2 = False And componente.fattibileConB3 = False And
                        componente.fattibileConB4 = False And componente.fattibileConB5 = False And componente.fuoriLinea = False Then
                    ricetta.ricettaFattibile = False
                End If
            Next

            If ricetta.ricettaFattibile Then
                ricetta.compinazionePerPlc = 0
                For Each componente In ricetta.componenti
                    assegnaFattibilitaBilanciaPerPlc(0, componente.fattibileConB1, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(1, componente.fattibileConB2, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(2, componente.fattibileConB3, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(3, componente.fattibileConB4, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(4, componente.fattibileConB5, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(7, componente.fuoriLinea, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                Next
            End If
        End If
        Return ricetta
    End Function



    Public Shared Function verificaFattibilita2(ByVal idRicetta As Integer, ByVal combinazioneSelezionata As UInt16) As strRicetta

        Dim ricetta As New strRicetta
        Dim bilanceAbilitate As BILANCE.strSelezioneBilance
        Dim ricettaEsistente As Boolean = False

        bilanceAbilitate = BILANCE.spacchettaSelezione(combinazioneSelezionata)
        ricetta.idRicetta = idRicetta

        Dim kgBilancia1, kgBilancia2, kgBilancia3, kgBilancia4, kgBilancia5 As Decimal


        Using TTA As DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceConPrioritaTableAdapter = New DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceConPrioritaTableAdapter
            Try

                Using actData = TTA.GetDataByIdRicetta(idRicetta)

                    If ReferenceEquals(actData, Nothing) = False Then
                        If actData.Count > 0 Then
                            ricettaEsistente = True
                            Dim progressivo As Integer = 0
                            ricetta.componenti = New List(Of strComponenteRicetta)
                            For Each componenteDB In actData
                                Dim newComponente As New strComponenteRicetta
                                newComponente.indice = progressivo
                                newComponente.idComponente = componenteDB.id_componente
                                newComponente.kgSet = componenteDB.kg_set
                                newComponente.kgTol = componenteDB.kg_tol
                                newComponente.fuoriLinea = componenteDB.selezione_fl
                                newComponente.pioritaMassima = SETUP_TOSTATRICI.ritornaPriorita(componenteDB)

                                Try
                                    If bilanceAbilitate.selezioneB1 > 0 Then
                                        kgBilancia1 = componenteDB.disponibileB1
                                        If kgBilancia1 > componenteDB.kg_set Then
                                            If newComponente.pioritaMassima = componenteDB.PRIORITA_B1 Then
                                                newComponente.fattibileConB1 = True
                                                newComponente.fattibileConXBilance += 1
                                            End If
                                        End If
                                    End If


                                Catch ex As Exception

                                End Try
                                Try
                                    If bilanceAbilitate.selezioneB2 > 0 Then
                                        kgBilancia2 = componenteDB.disponibileB2
                                        If kgBilancia2 > componenteDB.kg_set Then
                                            If newComponente.pioritaMassima = componenteDB.PRIORITA_B2 Then
                                                newComponente.fattibileConB2 = True
                                                newComponente.fattibileConXBilance += 1
                                            End If

                                        End If
                                    End If

                                Catch ex As Exception

                                End Try
                                Try
                                    If bilanceAbilitate.selezioneB3 > 0 Then
                                        kgBilancia3 = componenteDB.disponibileB3
                                        If kgBilancia3 > componenteDB.kg_set Then
                                            If newComponente.pioritaMassima = componenteDB.PRIORITA_B3 Then
                                                newComponente.fattibileConB3 = True
                                                newComponente.fattibileConXBilance += 1
                                            End If
                                        End If
                                    End If

                                Catch ex As Exception

                                End Try
                                Try
                                    If bilanceAbilitate.selezioneB4 > 0 Then
                                        kgBilancia4 = componenteDB.disponibileB4
                                        If kgBilancia4 > componenteDB.kg_set Then
                                            If newComponente.pioritaMassima = componenteDB.PRIORITA_B4 Then
                                                newComponente.fattibileConB4 = True
                                                newComponente.fattibileConXBilance += 1
                                            End If

                                        End If
                                    End If


                                Catch ex As Exception

                                End Try
                                Try
                                    If bilanceAbilitate.selezioneB5 > 0 Then
                                        kgBilancia5 = componenteDB.disponibileB5
                                        If kgBilancia5 > componenteDB.kg_set Then
                                            If newComponente.pioritaMassima = componenteDB.PRIORITA_B5 Then
                                                newComponente.fattibileConB5 = True
                                                newComponente.fattibileConXBilance += 1
                                            End If

                                        End If
                                    End If

                                Catch ex As Exception

                                End Try

                                If bilanceAbilitate.selezioneFL > 0 Then
                                    If newComponente.fuoriLinea Then
                                        newComponente.fattibileConFL = True
                                    End If
                                End If

                                ricetta.componenti.Add(newComponente)

                                progressivo += 1
                            Next

                        End If
                    End If
                End Using


                'DB.LOG_Insert(BeIT_LogType.Information, BeIT_LogArea.Socket, BeIT_LogZone.PLC, BeIT_LogOperation.Write, "Created PDO: " + PdoId)

            Catch ex As Exception

                'CElviLOG.writeLogFile(CElviLOG.ELogType.Alarm, CElviLOG.EPartner.General, "Create PDO: " + PdoId + " " + ex.Message)

            End Try

        End Using


        If ricettaEsistente Then
            ricetta.ricettaFattibile = True

            For Each componente In ricetta.componenti
                If componente.fattibileConB1 = False And componente.fattibileConB2 = False And componente.fattibileConB3 = False And
                        componente.fattibileConB4 = False And componente.fattibileConB5 = False And componente.fattibileConFL = False Then
                    ricetta.ricettaFattibile = False
                End If
            Next

            If ricetta.ricettaFattibile Then
                ricetta.compinazionePerPlc = 0
                For Each componente In ricetta.componenti
                    assegnaFattibilitaBilanciaPerPlc(0, componente.fattibileConB1, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(1, componente.fattibileConB2, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(2, componente.fattibileConB3, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(3, componente.fattibileConB4, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(4, componente.fattibileConB5, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                    assegnaFattibilitaBilanciaPerPlc(7, componente.fattibileConFL, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
                Next
            End If
        End If
        Return ricetta
    End Function

    Private Shared Sub assegnaFattibilitaBilanciaPerPlc(ByVal bilancia As UInt16, ByVal componenteFattibileConBilancia As Boolean, ByVal componenteFattibileConXbilance As Int16, ByRef word As UInt16, Optional forzaObbligatorio As Boolean = False)

        'combinazione per plc:
        'bit    bilancia
        '0      B1 OBBLIGATORIA
        '1      B2 OBBLIGATORIA
        '2      B3 OBBLIGATORIA
        '3      B4 OBBLIGATORIA
        '4      B5 OBBLIGATORIA
        '5      
        '6
        '7      FUORI LINEA OBBLIGATORIA
        '8      B1 OPZIONALE
        '9      B2 OPZIONALE
        '10     B3 OPZIONALE
        '11     B4 OPZIONALE
        '12     B5 OPZIONALE
        '13     
        '14
        '15     FUORI LINEA OPZIONALE (CASO CHE NON SI PRESENTA MAI)

        Dim auxWordObbligatorio As UInt16 = 1 << bilancia

        Dim auxWordOpzionale As UInt16 = 1 << (bilancia + 8)


        If componenteFattibileConBilancia Then 'se posso usare la bilancia
            If componenteFattibileConXbilance > 1 Then 'ma ne posso usare anche un'altra
                Dim temp As UInt16 = word And auxWordObbligatorio 'verifica se è già settato il bit di bilancia obbligatoria
                If temp = 0 Then ' e la bilancia non è già obbligatoria per un altro componente
                    word = word Or auxWordOpzionale    'setta il bit della bilancia opzionale
                End If
            Else ' se devo obbligatoriamente usare questa bilancia
                word = word Or auxWordObbligatorio     'setta bit della bilancia obbligatoria
                word = word And (Not auxWordOpzionale)    'resetta il bit della bilancia opzionale
            End If
        End If


    End Sub

    Public Shared Function leggiUltimaRichiesta(ByVal tostatrice As Int16) As Int16

        Dim ultimaCombinazioneRichiesta As Int16 = 0
        Using TTA As DBTableAdapters.tostatrici_Setup_RichiesteTableAdapter = New DBTableAdapters.tostatrici_Setup_RichiesteTableAdapter
            Using data = TTA.sp_TOSTATRICI_SETUP_RICHIESTE_LeggiUltimaRichiesta(tostatrice)
                If ReferenceEquals(data, Nothing) = False Then
                    If data.Count > 0 Then
                        ultimaCombinazioneRichiesta = data(0).combinazione
                    End If
                End If
            End Using
        End Using
        Return ultimaCombinazioneRichiesta
    End Function

    Public Shared Function ricettaAncoraFattibile(ByVal tostatrice As Int16, ByVal idRicetta As Integer, ByVal combinazioneSelezionata As UInt16) As Boolean
        Dim ultimaRichiesta As Int16
        Dim result As Boolean
        Dim calcolo = verificaFattibilita2(idRicetta, combinazioneSelezionata)

        If combinazioneSelezionata > 0 Then
            If calcolo.compinazionePerPlc = combinazioneSelezionata Then 'quello scelto e quello che farebbe il livello 2 sono uguali
                ultimaRichiesta = leggiUltimaRichiesta(tostatrice)  'ultima richiesta confermata da PLC
                If ultimaRichiesta = calcolo.compinazionePerPlc Then
                    result = True
                End If
            End If
        End If


        Return result
    End Function

End Class
