Public Class Form1

    Dim ricetta As DB_PLC.strRicetta

    Enum enuCombinazioniBilance
        B1 = 1
        B2 = 2
        B3 = 3
        FL = 4
        B1_FL = 5
        B2_FL = 6
        B3_FL = 7
        B1_B2 = 8
        B2_B3 = 10
        B1_B2_FL = 11
        B1_B3_FL = 12
        B2_B3_FL = 13
        B1_B2_B3 = 14
        B1_B2_B3_FL = 15
    End Enum





    Private Sub btnLeggiRicetta_Click(sender As Object, e As EventArgs) Handles btnLeggiRicetta.Click

        Dim nrRicetta As Integer

        Try
            nrRicetta = Integer.Parse(txtNrRicetta.Text)

            fai(nrRicetta)
        Catch ex As Exception
            MsgBox("numero ricetta non valido")
        End Try

    End Sub

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        inizializzaListBox()
    End Sub


    Structure strPrelievoComponente
        Dim idSilos As Integer
        Dim componente As DB_PLC.strComponenteRicetta

    End Structure

    Private Sub fai(ByVal idRicetta As Integer)


        ricetta = DB_PLC.leggiComponentiRicetta(idRicetta)

        compilaListBoxRicetta(ricetta)
    End Sub


    Private Sub inizializzaListBox()

        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "id"
        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(1).Name = "idComponente"
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Name = "kgSet"
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Name = "kgTol"
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Name = "fuoriLinea"
        DataGridView1.Columns(4).Width = 100

    End Sub



    Private Sub compilaListBoxRicetta(ByVal ricetta As DB_PLC.strRicetta)

        DataGridView1.Rows.Clear()

        For Each componente In ricetta.componenti
            Dim row As String() = New String() {componente.indice + 1, componente.idComponente, componente.kgSet, componente.kgTol, componente.fuoriLinea}
            DataGridView1.Rows.Add(row)
        Next

    End Sub

    Private Sub calcolaFattibilita(ByRef ricetta As DB_PLC.strRicetta)

        Dim idComponenti() As Integer
        Dim pesi() As Decimal

        'Dim i As Integer = 0
        ReDim idComponenti(ricetta.componenti.Count - 1)
        ReDim pesi(ricetta.componenti.Count - 1)

        '  DB_PLC.fattibilitaRicetta(TreeView1, ricetta)

        For i As Integer = 0 To ricetta.componenti.Count - 1
            DB_PLC.fattibilitaComponente(ricetta.componenti(i))
        Next


        For Each componente In ricetta.componenti

        Next


    End Sub


    Private Sub btnCalcolaFattibilità_Click(sender As Object, e As EventArgs) Handles btnCalcolaFattibilità.Click


        Dim idRicetta As Integer
        idRicetta = Integer.Parse(txtNrRicetta.Text)

        Dim a As New TOSTATRICI(4)
        a.creaMatrice(idRicetta)
        a.calcolaCombinazioni()

        a.stampaCombinazioni()



    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click


        calcolaTutteLeRicette()

    End Sub


    Private Sub calcolaTutteLeRicette()
        For i As Integer = 1 To 200
            Dim a As New TOSTATRICI(3)
            a.creaMatrice(i)
            a.calcolaCombinazioni()
            'a.stampaCombinazioni()
            'a.stampaCombinazioni2()
            a.stampaCombinazioni()
            'a.convertiCombinazioniPerPlc()
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSilosPrelievoBatchRicetta_Click(sender As Object, e As EventArgs) Handles btnSilosPrelievoBatchRicetta.Click

        Dim idRicetta As Integer
        Dim combinazione As Integer
        idRicetta = Integer.Parse(txtNrRicetta.Text)
        combinazione = Integer.Parse(txtCombinazione.Text)
        Dim a As New TOSTATRICI(4)
        a.creaMatrice(idRicetta)
        a.trovaSilosRicetta(idRicetta, combinazione)

    End Sub




    Private Sub btnImportRecipes_Click(sender As Object, e As EventArgs) Handles btnImportRecipes.Click

        Dim r As New RICETTE
        r.importaRicette("E:\_Cloud\OneDrive - ELVI SPA\LAVORO ELVI\GIMOKA IND 4.0\LIVELLO 2\Report PLC\Ricette Dettaglio 20200720")


    End Sub


End Class
