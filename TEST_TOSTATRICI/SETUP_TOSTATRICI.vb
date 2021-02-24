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
        Dim fattibileConXBilance As Int16
        Dim fattibilitaPerPlc As UInt16
        Dim pioritaMassima As UInt16
    End Structure

    Structure strRicetta
        Dim idRicetta
        Dim componenti() As strComponenteRicetta
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




    Public Shared Function calcolaCombinazioni_PocheBilance(ByVal bilance As BILANCE.strSelezioneBilance, ByVal nrRicetta As Int16, ByVal componente As strComponenteRicetta) As List(Of strBilancePerRicetta)


        Dim bilanciaScelta As Int16 = 0
        Dim filtroSelezione As BILANCE.strSelezioneBilance
        Dim listaBilance As New List(Of strBilancePerRicetta) ' lista delle bilance da usare
        Using TTA_DOSAGGIO As DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter = New DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter
            Using TTA_DISPONIBILITA As DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceConPrioritaTableAdapter = New DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceConPrioritaTableAdapter


                Using disponibilita = TTA_DISPONIBILITA.GetDataByIdRicettaComponente(nrRicetta, componente.idComponente) 'conta solo i silos abilitati allo scarico
                    If ReferenceEquals(disponibilita, Nothing) = False Then
                        If disponibilita.Count > 0 Then


                            If disponibilita(0).PRIORITA_B1 Then

                            End If
                            'restituisce l'elenco dei silos con il componente indicato, ordinati per:
                            'prima i silos da cui è stato scaricato di più
                            'poi i silos caricati prima
                            Using data = TTA_DOSAGGIO.sp_VIEW_MAGAZZINO_DOSAGGIO_TOTALE_GetDataByComponenteE5Bilance(componente.idComponente,
                                                                                                     bilance.selezioneB1,
                                                                                                     bilance.selezioneB2,
                                                                                                     bilance.selezioneB3,
                                                                                                     bilance.selezioneB4,
                                                                                                     bilance.selezioneB5)

                                    ' ??????????? nel caso di più silos, che peso mettiamo ????????? Sempre tutto quello che ci serve, perchè non siamo certi del peso reale nel silos.

                                    'per scegliere la bilancia, andiamo alla ricerca del silos piu vecchio, oppure già iniziato
                                    For Each item In data
                                        If item.abilitatoAlloScarico = True Then      ' questo silos è abilitato allo scarico
                                            If bilanciaScelta = 0 Then               'sceglie una bilancia che ha disponibilità di tutto il prodotto
                                                Select Case item.bilancia
                                                    Case 1
                                                        If bilance.selezioneB1 Then
                                                            If disponibilita(0).disponibileB1 > componente.kgSet Then bilanciaScelta = item.bilancia
                                                        End If
                                                    Case 2
                                                        If bilance.selezioneB2 Then
                                                            If disponibilita(0).disponibileB2 > componente.kgSet Then bilanciaScelta = item.bilancia
                                                        End If
                                                    Case 3
                                                        If bilance.selezioneB3 Then
                                                            If disponibilita(0).disponibileB3 > componente.kgSet Then bilanciaScelta = item.bilancia
                                                        End If
                                                    Case 4
                                                        If bilance.selezioneB4 Then
                                                            If disponibilita(0).disponibileB4 > componente.kgSet Then bilanciaScelta = item.bilancia
                                                        End If
                                                    Case 5
                                                        If bilance.selezioneB5 Then
                                                            If disponibilita(0).disponibileB5 > componente.kgSet Then bilanciaScelta = item.bilancia
                                                        End If
                                                End Select
                                            End If

                                            If item.bilancia = bilanciaScelta Then   'e il silos è collegato alla stessa bilancia già scelta con il primo silos

                                                Dim newBilancia As strBilancePerRicetta
                                                newBilancia.idComponente = item.id_codice_componente
                                                newBilancia.kg = componente.kgSet
                                                newBilancia.bilancia = item.bilancia
                                                newBilancia.componenteRicetta = componente
                                                listaBilance.Add(newBilancia)
                                                Exit For
                                            End If
                                        End If

                                    Next
                                End Using
                            End If
                        End If
                End Using
            End Using
        End Using

        If bilanciaScelta = 0 Then Throw New Exception
        Return listaBilance
    End Function




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

                            For Each componente In actData
                                ReDim Preserve ricetta.componenti(progressivo)
                                ricetta.componenti(progressivo).indice = progressivo
                                ricetta.componenti(progressivo).idComponente = componente.id_componente
                                ricetta.componenti(progressivo).kgSet = componente.kg_set
                                ricetta.componenti(progressivo).kgTol = componente.kg_tol
                                ricetta.componenti(progressivo).fuoriLinea = componente.selezione_fl
                                ricetta.componenti(progressivo).pioritaMassima = SETUP_TOSTATRICI.ritornaPriorita(componente)

                                Try
                                    kgBilancia1 = componente.disponibileB1
                                    If kgBilancia1 > componente.kg_set Then
                                        If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B1 Then
                                            ricetta.componenti(progressivo).fattibileConB1 = True
                                            ricetta.componenti(progressivo).fattibileConXBilance += 1
                                        End If
                                    End If

                                Catch ex As Exception

                                End Try
                                Try
                                    kgBilancia2 = componente.disponibileB2
                                    If kgBilancia2 > componente.kg_set Then
                                        If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B2 Then
                                            ricetta.componenti(progressivo).fattibileConB2 = True
                                            ricetta.componenti(progressivo).fattibileConXBilance += 1
                                        End If

                                    End If
                                Catch ex As Exception

                                End Try
                                Try
                                    kgBilancia3 = componente.disponibileB3
                                    If kgBilancia3 > componente.kg_set Then
                                        If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B3 Then
                                            ricetta.componenti(progressivo).fattibileConB3 = True
                                            ricetta.componenti(progressivo).fattibileConXBilance += 1
                                        End If
                                    End If
                                Catch ex As Exception

                                End Try
                                Try
                                    kgBilancia4 = componente.disponibileB4
                                    If kgBilancia4 > componente.kg_set Then
                                        If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B4 Then
                                            ricetta.componenti(progressivo).fattibileConB4 = True
                                            ricetta.componenti(progressivo).fattibileConXBilance += 1
                                        End If

                                    End If

                                Catch ex As Exception

                                End Try
                                Try
                                    kgBilancia5 = componente.disponibileB5
                                    If kgBilancia5 > componente.kg_set Then
                                        If ricetta.componenti(progressivo).pioritaMassima = componente.PRIORITA_B5 Then
                                            ricetta.componenti(progressivo).fattibileConB5 = True
                                            ricetta.componenti(progressivo).fattibileConXBilance += 1
                                        End If

                                    End If
                                Catch ex As Exception

                                End Try

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
                    assegnaFattibilitaBilanciaPerPlc(5, componente.fuoriLinea, componente.fattibileConXBilance, ricetta.compinazionePerPlc)
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

End Class
