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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
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
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
        Me.ListView1.Location = New System.Drawing.Point(478, 12)
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
        Me.Button3.Location = New System.Drawing.Point(44, 137)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(205, 79)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "VERIFICA FATTIBILITA' COMBINAZIONE "
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblCombinazioneFattibile
        '
        Me.lblCombinazioneFattibile.AutoSize = True
        Me.lblCombinazioneFattibile.Location = New System.Drawing.Point(273, 170)
        Me.lblCombinazioneFattibile.Name = "lblCombinazioneFattibile"
        Me.lblCombinazioneFattibile.Size = New System.Drawing.Size(41, 13)
        Me.lblCombinazioneFattibile.TabIndex = 16
        Me.lblCombinazioneFattibile.Text = "Ricetta"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(44, 233)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(205, 79)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "TROVA SILOS PER RICETTA E COMBINAZIONE"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form2021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
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
End Class
