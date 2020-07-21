
Imports System.IO

Public Class RICETTE



    Public Sub importaRicette(ByVal folder As String)

        Dim separator As Char = ";"

        For i As Integer = 1 To 200

            Dim strfilename As String = folder & "\ricetta_" & i & ".csv"

            Dim SR As StreamReader = New StreamReader(strfilename)
            Dim filedata As String = SR.ReadToEnd

            filedata = filedata.Replace(vbLf, "")
            filedata = filedata.Replace("""", String.Empty)


            spacchettaRicetta(filedata, i)

        Next


    End Sub



    Private Sub spacchettaRicetta(ByVal recipeData As String, ByVal nrRicetta As Integer)

        Dim arrRow() As String = recipeData.Split(Convert.ToChar(Keys.Return))

        Dim rowCounter As Integer = 0

        Try
            For Each row In arrRow


                Dim items() As String = row.Split(";")

                If rowCounter = 0 Then


                    Dim nomeRicetta, descrizione, dettaglio As String

                    nomeRicetta = items(0)
                    descrizione = items(1)
                    dettaglio = items(2)

                    DB_PLC.EliminaRicetta(nrRicetta)
                    DB_PLC.inserisciRicetta(nrRicetta, nomeRicetta, descrizione, dettaglio)

                Else


                    Dim indice As String
                    Dim id_componente As Integer
                    Dim kg_set As Decimal
                    Dim kg_tol As Decimal
                    Dim selezione_fl As Integer

                    indice = rowCounter
                    id_componente = Integer.Parse(items(1))
                    kg_set = Decimal.Parse(items(2))
                    kg_tol = Decimal.Parse(items(3))
                    selezione_fl = Integer.Parse(items(4))

                    DB_PLC.inserisciComponenteRicetta(nrRicetta, indice, id_componente, kg_set, kg_tol, selezione_fl)

                End If
                If items(0) = 0 Then

                End If

                rowCounter += 1
            Next
        Catch ex As Exception
            'elimina ricetta
            'log eccezione ricetta
        End Try

    End Sub


End Class
