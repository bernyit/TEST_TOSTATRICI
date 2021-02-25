<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2021
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNrRicetta = New System.Windows.Forms.TextBox()
        Me.lblCombinazionePlc = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblCombinazioneFattibile = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblFL_Necessaria = New System.Windows.Forms.Label()
        Me.lblB2B3FL = New System.Windows.Forms.Label()
        Me.lblB5_Opzionale = New System.Windows.Forms.Label()
        Me.lblB4_Opzionale = New System.Windows.Forms.Label()
        Me.lblB3_Opzionale = New System.Windows.Forms.Label()
        Me.lblB2_Opzionale = New System.Windows.Forms.Label()
        Me.lblB1_Opzionale = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblB5_Necessaria = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblB4_Necessaria = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblB3_Necessaria = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblB2_Necessaria = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblB1_Necessaria = New System.Windows.Forms.Label()
        Me.txtVerificaFattibilitaRicetta = New System.Windows.Forms.TextBox()
        Me.txtVerificaFattibilitaCombinazione2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblVerificaFattibilitaCombinazione = New System.Windows.Forms.Label()
        Me.btnCalcolaProssimoSilos = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(44, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 79)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "CALCOLA FATTIBILITA'"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(273, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Ricetta"
        '
        'txtNrRicetta
        '
        Me.txtNrRicetta.Location = New System.Drawing.Point(320, 64)
        Me.txtNrRicetta.Name = "txtNrRicetta"
        Me.txtNrRicetta.Size = New System.Drawing.Size(70, 20)
        Me.txtNrRicetta.TabIndex = 10
        Me.txtNrRicetta.Text = "27"
        '
        'lblCombinazionePlc
        '
        Me.lblCombinazionePlc.AutoSize = True
        Me.lblCombinazionePlc.Location = New System.Drawing.Point(410, 67)
        Me.lblCombinazionePlc.Name = "lblCombinazionePlc"
        Me.lblCombinazionePlc.Size = New System.Drawing.Size(39, 13)
        Me.lblCombinazionePlc.TabIndex = 12
        Me.lblCombinazionePlc.Text = "Label2"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.HideSelection = False
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3, ListViewItem4})
        Me.ListView1.Location = New System.Drawing.Point(455, 12)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(310, 426)
        Me.ListView1.TabIndex = 13
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 150
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(443, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 17)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(44, 245)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(205, 79)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "VERIFICA FATTIBILITA' COMBINAZIONE "
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblCombinazioneFattibile
        '
        Me.lblCombinazioneFattibile.AutoSize = True
        Me.lblCombinazioneFattibile.Location = New System.Drawing.Point(273, 259)
        Me.lblCombinazioneFattibile.Name = "lblCombinazioneFattibile"
        Me.lblCombinazioneFattibile.Size = New System.Drawing.Size(41, 13)
        Me.lblCombinazioneFattibile.TabIndex = 16
        Me.lblCombinazioneFattibile.Text = "Ricetta"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(44, 341)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(205, 79)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "TROVA BILANCE PER RICETTA E COMBINAZIONE"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(61, 168)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 96
        Me.Label15.Text = "Opzionale"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(55, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 95
        Me.Label10.Text = "Necessaria"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(381, 120)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(19, 13)
        Me.Label27.TabIndex = 94
        Me.Label27.Text = "FL"
        '
        'lblFL_Necessaria
        '
        Me.lblFL_Necessaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFL_Necessaria.Location = New System.Drawing.Point(380, 135)
        Me.lblFL_Necessaria.Name = "lblFL_Necessaria"
        Me.lblFL_Necessaria.Size = New System.Drawing.Size(22, 14)
        Me.lblFL_Necessaria.TabIndex = 93
        Me.lblFL_Necessaria.Text = "7"
        Me.lblFL_Necessaria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblB2B3FL
        '
        Me.lblB2B3FL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB2B3FL.Location = New System.Drawing.Point(380, 167)
        Me.lblB2B3FL.Name = "lblB2B3FL"
        Me.lblB2B3FL.Size = New System.Drawing.Size(22, 14)
        Me.lblB2B3FL.TabIndex = 92
        Me.lblB2B3FL.Text = "15"
        Me.lblB2B3FL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblB5_Opzionale
        '
        Me.lblB5_Opzionale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB5_Opzionale.Location = New System.Drawing.Point(327, 167)
        Me.lblB5_Opzionale.Name = "lblB5_Opzionale"
        Me.lblB5_Opzionale.Size = New System.Drawing.Size(22, 14)
        Me.lblB5_Opzionale.TabIndex = 91
        Me.lblB5_Opzionale.Text = "12"
        Me.lblB5_Opzionale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblB4_Opzionale
        '
        Me.lblB4_Opzionale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB4_Opzionale.Location = New System.Drawing.Point(276, 167)
        Me.lblB4_Opzionale.Name = "lblB4_Opzionale"
        Me.lblB4_Opzionale.Size = New System.Drawing.Size(22, 14)
        Me.lblB4_Opzionale.TabIndex = 90
        Me.lblB4_Opzionale.Text = "11"
        Me.lblB4_Opzionale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblB3_Opzionale
        '
        Me.lblB3_Opzionale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB3_Opzionale.Location = New System.Drawing.Point(222, 167)
        Me.lblB3_Opzionale.Name = "lblB3_Opzionale"
        Me.lblB3_Opzionale.Size = New System.Drawing.Size(22, 14)
        Me.lblB3_Opzionale.TabIndex = 89
        Me.lblB3_Opzionale.Text = "10"
        Me.lblB3_Opzionale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblB2_Opzionale
        '
        Me.lblB2_Opzionale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB2_Opzionale.Location = New System.Drawing.Point(171, 167)
        Me.lblB2_Opzionale.Name = "lblB2_Opzionale"
        Me.lblB2_Opzionale.Size = New System.Drawing.Size(22, 14)
        Me.lblB2_Opzionale.TabIndex = 88
        Me.lblB2_Opzionale.Text = "9"
        Me.lblB2_Opzionale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblB1_Opzionale
        '
        Me.lblB1_Opzionale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB1_Opzionale.Location = New System.Drawing.Point(120, 167)
        Me.lblB1_Opzionale.Name = "lblB1_Opzionale"
        Me.lblB1_Opzionale.Size = New System.Drawing.Size(22, 14)
        Me.lblB1_Opzionale.TabIndex = 87
        Me.lblB1_Opzionale.Text = "8"
        Me.lblB1_Opzionale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(329, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(20, 13)
        Me.Label16.TabIndex = 86
        Me.Label16.Text = "B5"
        '
        'lblB5_Necessaria
        '
        Me.lblB5_Necessaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB5_Necessaria.Location = New System.Drawing.Point(328, 135)
        Me.lblB5_Necessaria.Name = "lblB5_Necessaria"
        Me.lblB5_Necessaria.Size = New System.Drawing.Size(22, 14)
        Me.lblB5_Necessaria.TabIndex = 85
        Me.lblB5_Necessaria.Text = "4"
        Me.lblB5_Necessaria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(277, 120)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 84
        Me.Label19.Text = "B4"
        '
        'lblB4_Necessaria
        '
        Me.lblB4_Necessaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB4_Necessaria.Location = New System.Drawing.Point(276, 135)
        Me.lblB4_Necessaria.Name = "lblB4_Necessaria"
        Me.lblB4_Necessaria.Size = New System.Drawing.Size(22, 14)
        Me.lblB4_Necessaria.TabIndex = 83
        Me.lblB4_Necessaria.Text = "3"
        Me.lblB4_Necessaria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(224, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 13)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "B3"
        '
        'lblB3_Necessaria
        '
        Me.lblB3_Necessaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB3_Necessaria.Location = New System.Drawing.Point(224, 135)
        Me.lblB3_Necessaria.Name = "lblB3_Necessaria"
        Me.lblB3_Necessaria.Size = New System.Drawing.Size(22, 14)
        Me.lblB3_Necessaria.TabIndex = 81
        Me.lblB3_Necessaria.Text = "2"
        Me.lblB3_Necessaria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(173, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 13)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "B2"
        '
        'lblB2_Necessaria
        '
        Me.lblB2_Necessaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB2_Necessaria.Location = New System.Drawing.Point(172, 135)
        Me.lblB2_Necessaria.Name = "lblB2_Necessaria"
        Me.lblB2_Necessaria.Size = New System.Drawing.Size(22, 14)
        Me.lblB2_Necessaria.TabIndex = 79
        Me.lblB2_Necessaria.Text = "1"
        Me.lblB2_Necessaria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(120, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "B1"
        '
        'lblB1_Necessaria
        '
        Me.lblB1_Necessaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblB1_Necessaria.Location = New System.Drawing.Point(120, 135)
        Me.lblB1_Necessaria.Name = "lblB1_Necessaria"
        Me.lblB1_Necessaria.Size = New System.Drawing.Size(22, 14)
        Me.lblB1_Necessaria.TabIndex = 77
        Me.lblB1_Necessaria.Text = "0"
        Me.lblB1_Necessaria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVerificaFattibilitaRicetta
        '
        Me.txtVerificaFattibilitaRicetta.Location = New System.Drawing.Point(255, 275)
        Me.txtVerificaFattibilitaRicetta.Name = "txtVerificaFattibilitaRicetta"
        Me.txtVerificaFattibilitaRicetta.Size = New System.Drawing.Size(70, 20)
        Me.txtVerificaFattibilitaRicetta.TabIndex = 97
        Me.txtVerificaFattibilitaRicetta.Text = "27"
        '
        'txtVerificaFattibilitaCombinazione2
        '
        Me.txtVerificaFattibilitaCombinazione2.Location = New System.Drawing.Point(344, 275)
        Me.txtVerificaFattibilitaCombinazione2.Name = "txtVerificaFattibilitaCombinazione2"
        Me.txtVerificaFattibilitaCombinazione2.Size = New System.Drawing.Size(70, 20)
        Me.txtVerificaFattibilitaCombinazione2.TabIndex = 99
        Me.txtVerificaFattibilitaCombinazione2.Text = "27"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(341, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Combinazione"
        '
        'lblVerificaFattibilitaCombinazione
        '
        Me.lblVerificaFattibilitaCombinazione.AutoSize = True
        Me.lblVerificaFattibilitaCombinazione.Location = New System.Drawing.Point(341, 298)
        Me.lblVerificaFattibilitaCombinazione.Name = "lblVerificaFattibilitaCombinazione"
        Me.lblVerificaFattibilitaCombinazione.Size = New System.Drawing.Size(73, 13)
        Me.lblVerificaFattibilitaCombinazione.TabIndex = 100
        Me.lblVerificaFattibilitaCombinazione.Text = "Combinazione"
        '
        'btnCalcolaProssimoSilos
        '
        Me.btnCalcolaProssimoSilos.Location = New System.Drawing.Point(39, 451)
        Me.btnCalcolaProssimoSilos.Name = "btnCalcolaProssimoSilos"
        Me.btnCalcolaProssimoSilos.Size = New System.Drawing.Size(205, 79)
        Me.btnCalcolaProssimoSilos.TabIndex = 101
        Me.btnCalcolaProssimoSilos.Text = "CALCOLA PROSSIMO SILOS PER BILANCIA"
        Me.btnCalcolaProssimoSilos.UseVisualStyleBackColor = True
        '
        'Form2021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 567)
        Me.Controls.Add(Me.btnCalcolaProssimoSilos)
        Me.Controls.Add(Me.lblVerificaFattibilitaCombinazione)
        Me.Controls.Add(Me.txtVerificaFattibilitaCombinazione2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtVerificaFattibilitaRicetta)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lblFL_Necessaria)
        Me.Controls.Add(Me.lblB2B3FL)
        Me.Controls.Add(Me.lblB5_Opzionale)
        Me.Controls.Add(Me.lblB4_Opzionale)
        Me.Controls.Add(Me.lblB3_Opzionale)
        Me.Controls.Add(Me.lblB2_Opzionale)
        Me.Controls.Add(Me.lblB1_Opzionale)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lblB5_Necessaria)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblB4_Necessaria)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblB3_Necessaria)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblB2_Necessaria)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblB1_Necessaria)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.lblCombinazioneFattibile)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.lblCombinazionePlc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNrRicetta)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form2021"
        Me.Text = "Form2021"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNrRicetta As TextBox
    Friend WithEvents lblCombinazionePlc As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button2 As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Button3 As Button
    Friend WithEvents lblCombinazioneFattibile As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents lblFL_Necessaria As Label
    Friend WithEvents lblB2B3FL As Label
    Friend WithEvents lblB5_Opzionale As Label
    Friend WithEvents lblB4_Opzionale As Label
    Friend WithEvents lblB3_Opzionale As Label
    Friend WithEvents lblB2_Opzionale As Label
    Friend WithEvents lblB1_Opzionale As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblB5_Necessaria As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblB4_Necessaria As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblB3_Necessaria As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblB2_Necessaria As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblB1_Necessaria As Label
    Friend WithEvents txtVerificaFattibilitaRicetta As TextBox
    Friend WithEvents txtVerificaFattibilitaCombinazione2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblVerificaFattibilitaCombinazione As Label
    Friend WithEvents btnCalcolaProssimoSilos As Button
End Class
