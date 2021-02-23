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
        Dim pioritaMassima As UInt16
    End Structure

    Structure strRicetta
        Dim idRicetta
        Dim componenti() As strComponenteRicetta
        Dim ricettaFattibile As Boolean
        Dim compinazionePerPlc As UInt16
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

    Structure strBilancePerRicetta
        Dim idComponente As Int16
        Dim kg As Decimal
        Dim bilancia As Int16
        Dim componenteRicetta As strComponenteRicetta
    End Structure


    Structure strSilosPerRicetta
        Dim silos As Int16
        Dim progressivoSilos As Int16
        Dim idComponente As Int16
        Dim kg As Decimal
        Dim bilancia As Int16
        Dim componenteRicetta As strComponenteRicetta
    End Structure

    Structure strOrdineProduzioneRicetta
        Dim idRicetta As Integer
        Dim idComponente As Integer
        Dim kgSet As Decimal
        Dim kgTol As Decimal
        Dim multiSilos As Boolean
        Dim fuoriLinea As Boolean
        Dim listasilos As List(Of strSilosPerRicetta)
    End Structure




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



    Public Shared Function verificaFattibilita(ByVal idRicetta As Integer, ByVal combinazioneSelezionata As UInt16) As Boolean

        Dim ricettaFattibile As Boolean

        Dim contatoreComponenti As Int16
        Dim contatoreComponentiFattibili As Int16

        Dim bilanceSelezionate As BILANCE.strSelezioneBilance
        bilanceSelezionate = BILANCE.spacchettaSelezione(combinazioneSelezionata)

        Try
            Using TTA As DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceTableAdapter = New DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceTableAdapter

                Using actData = TTA.GetDataByIdRicetta(idRicetta)
                    If ReferenceEquals(actData, Nothing) = False Then
                        If actData.Count > 0 Then
                            For Each componente In actData
                                Dim contatoreFattibilitaComponente As Int16 = 0
                                contatoreComponenti += 1
                                If bilanceSelezionate.selezioneB1 Then
                                    Try
                                        If componente.disponibileB1 > componente.kg_set Then
                                            contatoreFattibilitaComponente += 1
                                        End If
                                    Catch ex As Exception

                                    End Try
                                End If
                                If bilanceSelezionate.selezioneB2 Then
                                    Try
                                        If componente.disponibileB2 > componente.kg_set Then
                                            contatoreFattibilitaComponente += 1
                                        End If
                                    Catch ex As Exception

                                    End Try

                                End If
                                If bilanceSelezionate.selezioneB3 Then
                                    Try
                                        If componente.disponibileB3 > componente.kg_set Then
                                            contatoreFattibilitaComponente += 1
                                        End If
                                    Catch ex As Exception

                                    End Try

                                End If
                                If bilanceSelezionate.selezioneB4 Then
                                    Try
                                        If componente.disponibileB4 > componente.kg_set Then
                                            contatoreFattibilitaComponente += 1
                                        End If
                                    Catch ex As Exception

                                    End Try

                                End If
                                If bilanceSelezionate.selezioneB5 Then
                                    Try
                                        If componente.disponibileB5 > componente.kg_set Then
                                            contatoreFattibilitaComponente += 1
                                        End If
                                    Catch ex As Exception

                                    End Try

                                End If
                                If bilanceSelezionate.selezioneFL Then
                                    'FL Sempre disponibile
                                    contatoreFattibilitaComponente = 1
                                End If
                                If contatoreFattibilitaComponente > 0 Then
                                    contatoreComponentiFattibili += 1
                                End If
                            Next
                        End If
                    End If

                End Using
            End Using

            If contatoreComponenti = contatoreComponentiFattibili Then
                ricettaFattibile = True
            End If

        Catch ex As Exception
            ricettaFattibile = False
        End Try

        Return ricettaFattibile

    End Function




    Public Shared Function verificaFattibilita(ByVal idRicetta As Integer) As strRicetta

        Dim bilance(5) As strBilance
        Dim ricetta As New strRicetta
        Dim ricettaEsistente As Boolean
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


    Private Shared Sub assegnaFattibilitaPerPlc(ByVal bitNr As UInt16, ByRef word As UInt16)

        Dim auxWord As UInt16 = 1 << bitNr

        word = word Xor auxWord
    End Sub

    Private Shared Sub assegnaFattibilitaBilanciaPerPlc(ByVal bilancia As UInt16, ByVal componenteFattibileConBilancia As Boolean, ByVal componenteFattibileConXbilance As Int16, ByRef word As UInt16, Optional forzaObbligatorio As Boolean = False)

        'combinazione per plc:
        'bit    bilancia
        '0      B1 OBBLIGATORIA
        '1      B2 OBBLIGATORIA
        '2      B3 OBBLIGATORIA
        '3      B4 OBBLIGATORIA
        '4      B5 OBBLIGATORIA
        '5      FUORI LINEA OBBLIGATORIA
        '6
        '7
        '8      B1 OPZIONALE
        '9      B2 OPZIONALE
        '10     B3 OPZIONALE
        '11     B4 OPZIONALE
        '12     B5 OPZIONALE
        '13     FUORI LINEA OPZIONALE (CASO CHE NON SI PRESENTA MAI)
        '14
        '15

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


    '###################################   CALCOLA SILOS
    Structure strSetupTostatrice
        Dim idRichiesta As UInt32
        Dim tostatrice As Int16
        Dim idRicetta As Int16
        Dim combinazioneBilance As UInt16
        Dim ricetta As strRicetta
        Dim fattibile As Boolean
    End Structure


    Public Shared Sub calcolaBilanceNew(ByVal idRichiesta As UInt64, ByVal tostatrice As UInt16, ByVal idRicetta As Integer, ByVal combinazioneBilance As UInt16)


        Dim nuovoSetup As strSetupTostatrice
        nuovoSetup.idRichiesta = idRichiesta
        nuovoSetup.tostatrice = tostatrice
        nuovoSetup.idRicetta = idRicetta
        nuovoSetup.combinazioneBilance = combinazioneBilance
        nuovoSetup.ricetta = leggiComponentiRicetta(idRicetta)

        Dim bilanceSelezionate As BILANCE.strSelezioneBilance
        bilanceSelezionate = BILANCE.spacchettaSelezione(combinazioneBilance)

        Try
            Dim listaBilancePerRicetta As New List(Of strBilancePerRicetta)
            For Each comp In nuovoSetup.ricetta.componenti ' scansiona tutti i componenti alla ricerca del silos
                Dim listabilancePerComponente = definisciBilanciaPerComponente(bilanceSelezionate, nuovoSetup.idRicetta, comp)
                listaBilancePerRicetta.AddRange(listabilancePerComponente)
            Next

            deleteSetupTostatrice(nuovoSetup.tostatrice)

            Dim contatore As UInt16 = 0
            For Each bilancia In listaBilancePerRicetta
                contatore += 1
                inserisciSetupTostatrice(nuovoSetup, bilancia, contatore)
            Next
            nuovoSetup.fattibile = True
        Catch ex As Exception
            nuovoSetup.fattibile = False
            'se c'è un eccezione, vuol dire che non abbiamo trovato il componente cercato e che quindi la ricetta non è fattibile
        End Try

        inserisciNuovaRichiesta(nuovoSetup)
    End Sub


    Public Shared Sub calcolaSilosNew(ByVal idRichiesta As UInt64, ByVal tostatrice As UInt16, ByVal idRicetta As Integer, ByVal combinazioneBilance As UInt16)


        Dim nuovoSetup As strSetupTostatrice
        nuovoSetup.idRichiesta = idRichiesta
        nuovoSetup.tostatrice = tostatrice
        nuovoSetup.idRicetta = idRicetta
        nuovoSetup.combinazioneBilance = combinazioneBilance
        nuovoSetup.ricetta = leggiComponentiRicetta(idRicetta)

        Dim bilanceSelezionate As BILANCE.strSelezioneBilance
        bilanceSelezionate = BILANCE.spacchettaSelezione(combinazioneBilance)

        Try
            Dim listaSilosPerRicetta As New List(Of strSilosPerRicetta)
            For Each comp In nuovoSetup.ricetta.componenti ' scansiona tutti i componenti alla ricerca del silos
                Dim listaSilosPerComponente = trovaSilosPerComponente(bilanceSelezionate, nuovoSetup.idRicetta, comp)
                listaSilosPerRicetta.AddRange(listaSilosPerComponente)
            Next

            deleteSetupTostatrice(nuovoSetup.tostatrice)

            Dim contatore As UInt16 = 0
            For Each silos In listaSilosPerRicetta
                contatore += 1
                inserisciSetupTostatrice(nuovoSetup, silos, contatore)
            Next
            nuovoSetup.fattibile = True
        Catch ex As Exception
            nuovoSetup.fattibile = False
            'se c'è un eccezione, vuol dire che non abbiamo trovato il componente cercato e che quindi la ricetta non è fattibile
        End Try

        inserisciNuovaRichiesta(nuovoSetup)
    End Sub


    Public Shared Function definisciBilanciaPerComponente(ByVal bilance As BILANCE.strSelezioneBilance, ByVal nrRicetta As Int16, ByVal componente As strComponenteRicetta) As List(Of strBilancePerRicetta)

        Dim bilanciaScelta As Int16 = 0
        Dim listaBilance As New List(Of strBilancePerRicetta) ' lista delle bilance da usare
        Using TTA_DOSAGGIO As DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter = New DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter
            Using TTA_DISPONIBILITA As DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceTableAdapter = New DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceTableAdapter


                Using disponibilita = TTA_DISPONIBILITA.GetDataByIdRicettaComponente(nrRicetta, componente.idComponente) 'conta solo i silos abilitati allo scarico
                    If ReferenceEquals(disponibilita, Nothing) = False Then
                        If disponibilita.Count > 0 Then
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


    Public Shared Function trovaSilosPerComponente(ByVal bilance As BILANCE.strSelezioneBilance, ByVal nrRicetta As Int16, ByVal componente As strComponenteRicetta) As List(Of strSilosPerRicetta)

        Dim contatoreSilos As Int16 = 0 'contatore dei silos necessari per il componente richiesto
        Dim pesoResiduoDaPrelevare As Decimal = componente.kgSet ' inizializza peso da prelevare, nel caso un silos non sia sufficiente
        Dim listaSilos As New List(Of strSilosPerRicetta) ' lista dei silos trovati con il componente
        Using TTA_DOSAGGIO As DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter = New DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter
            Using TTA_DISPONIBILITA As DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceTableAdapter = New DBTableAdapters.view_RicettaComponenti_disponibilitaBilanceTableAdapter


                Using disponibilta = TTA_DISPONIBILITA.GetDataByIdRicettaComponente(nrRicetta, componente.idComponente)
                    If ReferenceEquals(disponibilta, Nothing) = False Then
                        If disponibilta.Count > 0 Then
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
                                Dim bilanciaUsata As Int16 = 0
                                For Each item In data
                                    If pesoResiduoDaPrelevare > 0 Then              'se ho ancora prodotto da prelevare
                                        If item.abilitatoAlloScarico = True Then      ' e questo silos è abilitato allo scarico
                                            If bilanciaUsata = 0 Then               'sceglie una bilancia che ha disponibilità di tutto il prodotto
                                                Select Case item.bilancia
                                                    Case 1
                                                        If disponibilta(0).disponibileB1 > componente.kgSet Then bilanciaUsata = item.bilancia
                                                    Case 2
                                                        If disponibilta(0).disponibileB2 > componente.kgSet Then bilanciaUsata = item.bilancia
                                                    Case 3
                                                        If disponibilta(0).disponibileB3 > componente.kgSet Then bilanciaUsata = item.bilancia
                                                    Case 4
                                                        If disponibilta(0).disponibileB4 > componente.kgSet Then bilanciaUsata = item.bilancia
                                                    Case 5
                                                        If disponibilta(0).disponibileB5 > componente.kgSet Then bilanciaUsata = item.bilancia
                                                End Select
                                            End If

                                            If item.bilancia = bilanciaUsata Then   'e il silos è collegato alla stessa bilancia già scelta con il primo silos
                                                Dim pesoDaPrelevareNelSilos As Decimal
                                                contatoreSilos = contatoreSilos + 1     'incrementa il contatore dei silos trovati
                                                If item.quantitaRimanente >= pesoResiduoDaPrelevare Then   'quantità presente nel silos superiore alla quantità necessaria. OK
                                                    pesoDaPrelevareNelSilos = pesoResiduoDaPrelevare        'prendo tutto quello che mi serve
                                                    pesoResiduoDaPrelevare = 0
                                                Else                                                'quantità non sufficiente. sarà necessario un altro silos
                                                    pesoDaPrelevareNelSilos = item.quantitaRimanente    'preleva solo quello che c'è
                                                    pesoResiduoDaPrelevare = pesoResiduoDaPrelevare - item.quantitaRimanente  'memorizza la quantità mancante
                                                End If

                                                Dim newSilos As strSilosPerRicetta
                                                newSilos.silos = item.IdSilos
                                                newSilos.idComponente = item.id_codice_componente
                                                newSilos.kg = pesoDaPrelevareNelSilos
                                                newSilos.bilancia = item.bilancia
                                                newSilos.progressivoSilos = contatoreSilos
                                                newSilos.componenteRicetta = componente
                                                listaSilos.Add(newSilos)

                                            End If
                                        End If
                                    End If
                                Next
                            End Using
                        End If
                    End If
                End Using
            End Using
        End Using

        If contatoreSilos = 0 Then Throw New Exception
        Return listaSilos
    End Function







    'Public Shared Function trovaSilosPerTostatrice(ByVal idRichiesta As UInt64, ByVal tostatrice As UInt16, ByVal idRicetta As Integer, ByVal combinazioneBilance As UInt16) As List(Of strOrdineProduzioneRicetta)

    '    Dim ricetta = leggiComponentiRicetta(idRicetta)

    '    'bit    bilancia
    '    '0      B1 
    '    '1      B2 
    '    '2      B3 
    '    '3      B4 
    '    '4      B5 
    '    '5      FUORI LINEA 
    '    Dim selezioneB1, selezioneB2, selezioneB3, selezioneB4, selezioneB5, selezioneFL As UInt16

    '    selezioneB1 = combinazioneBilance And 1
    '    selezioneB2 = combinazioneBilance And 2
    '    selezioneB3 = combinazioneBilance And 4
    '    selezioneB4 = combinazioneBilance And 8
    '    selezioneB5 = combinazioneBilance And 16
    '    selezioneFL = combinazioneBilance And 32

    '    Dim programma As New List(Of strOrdineProduzioneRicetta)

    '    deleteSetupTostatrice(tostatrice)
    '    For Each comp In ricetta.componenti

    '        Dim componenteRicetta As New strOrdineProduzioneRicetta

    '        componenteRicetta.idComponente = comp.idComponente
    '        componenteRicetta.kgSet = comp.kgSet
    '        componenteRicetta.kgTol = comp.kgTol
    '        componenteRicetta.fuoriLinea = comp.fuoriLinea
    '        componenteRicetta.listasilos = New List(Of strSilosPerRicetta)

    '        If comp.fuoriLinea = False Then

    '            Using TTA_DOSAGGIO As DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter = New DBTableAdapters.viewMagazzinoDosaggio_TotaleTableAdapter
    '                Using data = TTA_DOSAGGIO.sp_VIEW_MAGAZZINO_DOSAGGIO_TOTALE_GetDataByComponenteE5Bilance(comp.idComponente, selezioneB1, selezioneB2, selezioneB3, selezioneB4, selezioneB5)

    '                    Dim pesoResiduo As Decimal = comp.kgSet

    '                    For Each item In data
    '                        If pesoResiduo > 0 Then
    '                            If item.abilitatoAlloScarico = True Then
    '                                Dim pesoDaPrelevareNelSilos As Decimal

    '                                If item.quantitaRimanente >= pesoResiduo Then
    '                                    pesoDaPrelevareNelSilos = pesoResiduo
    '                                Else
    '                                    pesoDaPrelevareNelSilos = item.quantitaRimanente
    '                                    pesoResiduo = pesoResiduo - item.quantitaRimanente
    '                                End If

    '                                Dim newSilos As strSilosPerRicetta
    '                                newSilos.silos = item.IdSilos
    '                                newSilos.idComponente = item.id_codice_componente
    '                                newSilos.kg = pesoResiduo
    '                                newSilos.bilancia = item.bilancia

    '                                componenteRicetta.listasilos.Add(newSilos)

    '                                inserisciSetupTostatrice(idRichiesta, tostatrice, newSilos, idRicetta, comp)

    '                            End If
    '                        End If

    '                    Next

    '                End Using

    '            End Using


    '        End If

    '        programma.Add(componenteRicetta)


    '    Next

    '    Return programma
    'End Function

    Private Shared Sub deleteSetupTostatrice(ByVal tostatrice As Int16)
        Using TTA As DBTableAdapters.tostatrici_Setup_ProgrammaTableAdapter = New DBTableAdapters.tostatrici_Setup_ProgrammaTableAdapter
            TTA.DeleteTostatrice(tostatrice)
        End Using
    End Sub

    'Private Shared Sub inserisciSetupTostatrice(ByVal idRichiesta As UInt64, ByVal tostatrice As Int16, ByVal silos As strSilosPerRicetta, ByVal idRicetta As Integer, ByVal componenteRicetta As strComponenteRicetta)
    '    Using TTA As DBTableAdapters.tostatrici_setupTableAdapter = New DBTableAdapters.tostatrici_setupTableAdapter
    '        TTA.InsertSilos(tostatrice, idRicetta, componenteRicetta.indice, idRichiesta, componenteRicetta.idComponente, componenteRicetta.kgSet, componenteRicetta.kgTol, componenteRicetta.fuoriLinea, silos.silos, silos.bilancia, False)
    '    End Using
    'End Sub

    Private Shared Sub inserisciSetupTostatrice(ByVal setupTostatrice As strSetupTostatrice, ByVal silos As strSilosPerRicetta, ByVal contatore As UInt16)
        'Using TTA As DBTableAdapters.tostatrici_Setup_ProgrammaTableAdapter = New DBTableAdapters.tostatrici_Setup_ProgrammaTableAdapter
        '    TTA.InsertSilos(setupTostatrice.tostatrice,         'NR TOSTATRICE
        '                    setupTostatrice.idRicetta,          'ID RICETTA
        '                    contatore,                          'PROGRESSIVO COMPONENTE
        '                    setupTostatrice.idRichiesta,        'ID RICHIESTA
        '                    silos.idComponente,                 'ID COMPONENTE
        '                    silos.componenteRicetta.kgSet,      'KG DA RICETTA
        '                    silos.componenteRicetta.kgTol,      'TOLLERANZA DA RICETTA
        '                    silos.componenteRicetta.fuoriLinea, 'SELEZIONE FUORI LINEA
        '                    silos.progressivoSilos,             'PROGRESSIVO SILOS PER COMPONENTE
        '                    silos.silos,                        'NR SILOS
        '                    silos.kg,                           'PESO PREVISTO DA PRELEVARE NEL SILOS
        '                    silos.bilancia,                     'SILOS APPARTENENTE A BILANCIA NR
        '                    False, 0, 0)
        'End Using
    End Sub

    Private Shared Sub inserisciSetupTostatrice(ByVal setupTostatrice As strSetupTostatrice, ByVal silos As strBilancePerRicetta, ByVal contatore As UInt16)
        Using TTA As DBTableAdapters.tostatrici_Setup_ProgrammaTableAdapter = New DBTableAdapters.tostatrici_Setup_ProgrammaTableAdapter
            TTA.InsertSilos(setupTostatrice.tostatrice,         'NR TOSTATRICE
                            setupTostatrice.idRicetta,          'ID RICETTA
                            contatore,                          'PROGRESSIVO COMPONENTE
                            setupTostatrice.idRichiesta,        'ID RICHIESTA
                            silos.idComponente,                 'ID COMPONENTE
                            silos.componenteRicetta.kgSet,      'KG DA RICETTA
                            silos.componenteRicetta.kgTol,      'TOLLERANZA DA RICETTA
                            silos.componenteRicetta.fuoriLinea, 'SELEZIONE FUORI LINEA
                            0,                                  'ULTIMO SILOS SCARICATO
                            silos.kg,                           'PESO PREVISTO DA PRELEVARE NEL SILOS
                            silos.bilancia,                     'SILOS APPARTENENTE A BILANCIA NR
                            False,                              'ESEGUITO   
                            0)                                  'PESO SCARICATO
        End Using
    End Sub


    Private Shared Sub inserisciNuovaRichiesta(ByVal nuovaRichiesta As strSetupTostatrice)
        Using TTA As DBTableAdapters.tostatrici_Setup_RichiesteTableAdapter = New DBTableAdapters.tostatrici_Setup_RichiesteTableAdapter
            TTA.InsertRichiesta(nuovaRichiesta.idRichiesta, nuovaRichiesta.tostatrice, nuovaRichiesta.ricetta.idRicetta, nuovaRichiesta.combinazioneBilance, Now, nuovaRichiesta.fattibile)
        End Using
    End Sub
End Class
