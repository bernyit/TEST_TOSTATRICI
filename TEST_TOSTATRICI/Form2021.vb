Public Class Form2021
    Private Sub Form2021_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idRicetta As Int16
        idRicetta = Integer.Parse(txtNrRicetta.Text)
        calcolaFattibilita(idRicetta)
    End Sub





    Private Sub calcolaFattibilita(ByVal idRicetta As Int16)

        DB_PLC.verificaFattibilita(idRicetta)


    End Sub

End Class