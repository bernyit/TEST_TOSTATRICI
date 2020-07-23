Public Class DB_TOST







    Public Shared Sub EliminaRicetta(ByVal nrRicetta As Integer)

        Using TTA_RICETTE As DBTableAdapters.ricetteTableAdapter = New DBTableAdapters.ricetteTableAdapter
            Using TTA_RICETTE_COMPONENTI As DBTableAdapters.ricetta_componentiTableAdapter = New DBTableAdapters.ricetta_componentiTableAdapter

                TTA_RICETTE.sp_RICETTE_EliminaRicettaX(nrRicetta)
                TTA_RICETTE_COMPONENTI.sp_RICETTA_COMPONENTI_EliminaRicettaX(nrRicetta)

            End Using
        End Using

    End Sub

    Public Shared Sub inserisciRicetta(ByVal nrRicetta As Integer, ByVal nomeRicetta As String, ByVal descrizione As String, ByVal dettaglio As String)

        Using TTA_RICETTE As DBTableAdapters.ricetteTableAdapter = New DBTableAdapters.ricetteTableAdapter

            TTA_RICETTE.sp_RICETTE_InserisciNuovaRicetta(nrRicetta, nomeRicetta, descrizione, dettaglio)

        End Using

    End Sub

    Public Shared Sub inserisciComponenteRicetta(ByVal nrRicetta As Integer, ByVal indice As String, ByVal id_componente As Integer, ByVal kg_set As Decimal, ByVal kg_tol As Decimal, ByVal selezione_fl As Integer)


        Using TTA_RICETTE_COMPONENTI As DBTableAdapters.ricetta_componentiTableAdapter = New DBTableAdapters.ricetta_componentiTableAdapter

            TTA_RICETTE_COMPONENTI.sp_RICETTA_COMPONENTI_InserisciNuovoComponenteRicetta(nrRicetta, indice, id_componente, kg_set, kg_tol, selezione_fl)

        End Using

    End Sub

End Class
