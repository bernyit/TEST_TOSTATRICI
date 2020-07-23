
Imports System.IO
Imports System.Text

Public Class RICETTE

    '"E:\_Cloud\OneDrive - ELVI SPA\LAVORO ELVI\GIMOKA IND 4.0\LIVELLO 2\Report PLC\Ricette Dettaglio 20200720"
    Dim recipePath As String = ""

    Private Function leggiFileConfig() As String

        Dim strfilename As String = Application.StartupPath & "\config.csv"
        Dim SR As StreamReader = New StreamReader(strfilename)
        Dim filedata As String = SR.ReadLine

        Return filedata
    End Function


    Public Sub importaRicette()

        Dim folder As String = leggiFileConfig()


        Dim separator As Char = ";"

        MsgBox(Now.Second)
        For i As Integer = 1 To 200

            Try
                Dim strfilename As String = folder & "\ricetta_" & i & ".csv"

                Dim SR As StreamReader = New StreamReader(strfilename, Encoding.Default)
                Dim filedata As String = SR.ReadToEnd

                filedata = filedata.Replace(vbLf, "")
                filedata = filedata.Replace("""", String.Empty)


                spacchettaRicetta(filedata, i)

            Catch ex As Exception
                Try
                    DB_TOST.EliminaRicetta(i)
                    DB_TOST.inserisciRicetta(i, "ERRORE!", "", "")
                    'elimina ricetta
                    'log eccezione ricetta
                Catch ex1 As Exception


                End Try
            End Try


        Next
        MsgBox(Now.Second)

    End Sub



    Private Sub spacchettaRicetta(ByVal recipeData As String, ByVal nrRicetta As Integer)

        Dim arrRow() As String = recipeData.Split(Convert.ToChar(Keys.Return))

        Dim rowCounter As Integer = 0


        For Each row In arrRow

            If row.Length > 0 Then
                Dim items() As String = row.Split(";")

                If rowCounter = 0 Then


                    Dim nomeRicetta, descrizione, dettaglio As String

                    nomeRicetta = items(0)
                    descrizione = items(1)
                    dettaglio = items(2)

                    DB_TOST.EliminaRicetta(nrRicetta)
                    DB_TOST.inserisciRicetta(nrRicetta, nomeRicetta, descrizione, dettaglio)

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

                    If id_componente > 0 Then
                        DB_TOST.inserisciComponenteRicetta(nrRicetta, indice, id_componente, kg_set, kg_tol, selezione_fl)
                    End If


                End If
            End If


            rowCounter += 1
        Next

    End Sub


End Class
