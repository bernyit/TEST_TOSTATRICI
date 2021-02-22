Public Class Form2021
    Private Sub Form2021_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idRicetta As Int16
        idRicetta = Integer.Parse(txtNrRicetta.Text)
        calcolaFattibilita(idRicetta)
    End Sub





    Private Sub calcolaFattibilita(ByVal idRicetta As Int16)


        For i As Integer = 1 To 200
            Dim recipe = DB_PLC.verificaFattibilita(i)


            lblCombinazionePlc.Text = Convert.ToString(recipe.compinazionePerPlc, 2).PadLeft(16, "0"c)

            ListView1.Items.Add(New ListViewItem(New String() {i, lblCombinazionePlc.Text, recipe.compinazionePerPlc}))

        Next


        'Dim ricetta = DB_PLC.verificaFattibilita(idRicetta)

        'lblCombinazionePlc.Text = Convert.ToString(ricetta.compinazionePerPlc, 2).PadLeft(16, "0"c)

        'Dim z As Boolean
        'z = 1
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
        If DB_PLC.verificaFattibilita(32, 5) = True Then ' ricetta 32 e combinazione 5 = 101 = BILANCIA 1 E 3
            lblCombinazioneFattibile.Text = "OK"
        Else
            lblCombinazioneFattibile.Text = "NOT OK"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim id As UInt32
        id = (DateTime.Now - New DateTime(1970, 1, 1)).TotalSeconds
        'DB_PLC.calcolaSilosNew(id, 3, 89, 7)
        DB_PLC.calcolaBilanceNew(id, 3, 89, 7)



    End Sub
End Class