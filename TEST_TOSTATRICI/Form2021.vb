﻿Public Class Form2021
    Private Sub Form2021_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idRicetta As Int16
        idRicetta = Integer.Parse(txtNrRicetta.Text)
        Dim tostatriceNr As Int16 = 1
        calcolaFattibilita(idRicetta, tostatriceNr)
    End Sub





    Private Sub calcolaFattibilita(ByVal idRicetta As Int16, ByVal tostatriceNr As Int16)

        Dim min, max As Int16

        If idRicetta = 0 Then
            min = 1
            max = 200
        Else
            min = idRicetta
            max = idRicetta
        End If


        For i As Integer = min To max
            Dim filtroBilance As UInt16 = 0
            Select Case tostatriceNr
                Case 1
                    filtroBilance = &B1110_0111_1110_0111 ' esclude bilance 4,5
                Case 2
                    filtroBilance = &B1110_0111_1110_0111 ' esclude bilance 4,5
                Case 3
                    filtroBilance = &B1111_1111_1111_1111
                Case 4
                    filtroBilance = &B1111_1111_1111_1111
            End Select
            Dim recipe = SETUP_TOSTATRICI.verificaFattibilita2(i, filtroBilance)

            lblCombinazionePlc.Text = Convert.ToString(recipe.compinazionePerPlc, 2).PadLeft(16, "0"c)
            mostraBilanceSelezionate(recipe.compinazionePerPlc)
            ListView1.Items.Add(New ListViewItem(New String() {i, lblCombinazionePlc.Text, recipe.compinazionePerPlc}))

        Next


        'Dim ricetta = DB_PLC.verificaFattibilita(idRicetta)

        'lblCombinazionePlc.Text = Convert.ToString(ricetta.compinazionePerPlc, 2).PadLeft(16, "0"c)

        'Dim z As Boolean
        'z = 1
    End Sub


    Private Sub mostraBilanceSelezionate(ByVal combinazioneBilance As UInt16)
        lblB1_Necessaria.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B1_OBBLIGATORIA, combinazioneBilance)
        lblB2_Necessaria.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B2_OBBLIGATORIA, combinazioneBilance)
        lblB3_Necessaria.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B3_OBBLIGATORIA, combinazioneBilance)
        lblB4_Necessaria.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B4_OBBLIGATORIA, combinazioneBilance)
        lblB5_Necessaria.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B5_OBBLIGATORIA, combinazioneBilance)
        lblFL_Necessaria.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.FL_OBBLIGATORIA, combinazioneBilance)
        lblB1_Opzionale.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B1_OPZIONALE, combinazioneBilance)
        lblB2_Opzionale.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B2_OPZIONALE, combinazioneBilance)
        lblB3_Opzionale.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B3_OPZIONALE, combinazioneBilance)
        lblB4_Opzionale.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B4_OPZIONALE, combinazioneBilance)
        lblB5_Opzionale.BackColor = BILANCE.combinazioneFattibileColor(BILANCE.enuBilance.B5_OPZIONALE, combinazioneBilance)
    End Sub


    Private Sub test()
        For currentRow As Integer = 1 To 200



            ListView1.Items.Add(New ListViewItem(New String() {"Item in column 1", "Item in column 2", "Item in column 3"}))

            ' Create the listviewitem with the value from the first column
            Dim item = New ListViewItem("a")


            item.SubItems.Add("b")


            ' Finally, the whole ListViewItem is added to the ListView
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        test()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim idRicetta, combinazione As Int16
        idRicetta = Integer.Parse(txtVerificaFattibilitaRicetta.Text)
        combinazione = Integer.Parse(txtVerificaFattibilitaCombinazione2.Text)
        'If DB_PLC.verificaFattibilita(32, 5) = True Then ' ricetta 32 e combinazione 5 = 101 = BILANCIA 1 E 3
        '    lblCombinazioneFattibile.Text = "OK"
        'Else
        '    lblCombinazioneFattibile.Text = "NOT OK"
        'End If
        Dim result = SETUP_TOSTATRICI.verificaFattibilita2(idRicetta, combinazione)
        lblVerificaFattibilitaCombinazione.Text = result.compinazionePerPlc
        'If result.ricettaFattibile Then
        '    lblCombinazioneFattibile.Text = "OK"
        'Else
        '    lblCombinazioneFattibile.Text = "NOT OK"
        'End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim id As UInt32
        id = (DateTime.Now - New DateTime(1970, 1, 1)).TotalSeconds
        'DB_PLC.calcolaSilosNew(id, 3, 89, 7)
        DB_PLC.calcolaBilanceNew(id, 3, 89, 7)



    End Sub

    Private Sub btnCalcolaProssimoSilos_Click(sender As Object, e As EventArgs) Handles btnCalcolaProssimoSilos.Click

        Dim msgDaPlc As New GMK_LEVEL2_TOSTATRICI.strTelFromPlc_1X_RichiestaSilosPerBilanciaX
        msgDaPlc.tostatriceNr = 3
        msgDaPlc.idRichiesta = 1613989848

        msgDaPlc.indice_componente = 4
        msgDaPlc.ricettaNr = 89
        msgDaPlc.sequenzaRichiesta = BILANCE.enuPesateSequenza.PRODOTTO_SUCCESSIVO

        BILANCE.CalcolaProssimoSilos(msgDaPlc, 1)

    End Sub

    Private Sub btnAggiungiPesata_Click(sender As Object, e As EventArgs) Handles btnAggiungiPesata.Click

        Dim msg As New GMK_LEVEL2_TOSTATRICI.strTelFromPlc_1X_RichiestaSilosPerBilanciaX
        msg.tostatriceNr = 3
        msg.idRichiesta = 1613989848

        msg.indice_componente = 4
        msg.ricettaNr = 89
        msg.sequenzaRichiesta = BILANCE.enuPesateSequenza.PRODOTTO_SUCCESSIVO
        msg.ultimoSilosScaricato = (Now.Second Mod 20) + 1
        BILANCE.aggiungiPesata(msg.tostatriceNr, 1, msg.indice_componente, msg.ultimoSilosScaricato, 1)

    End Sub
End Class