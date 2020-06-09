<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnLeggiRicetta = New System.Windows.Forms.Button()
        Me.btnCalcolaFattibilità = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtNrRicetta = New System.Windows.Forms.TextBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.btnSilosPrelievoBatchRicetta = New System.Windows.Forms.Button()
        Me.txtCombinazione = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLeggiRicetta
        '
        Me.btnLeggiRicetta.Location = New System.Drawing.Point(46, 23)
        Me.btnLeggiRicetta.Name = "btnLeggiRicetta"
        Me.btnLeggiRicetta.Size = New System.Drawing.Size(143, 53)
        Me.btnLeggiRicetta.TabIndex = 0
        Me.btnLeggiRicetta.Text = "Leggi Ricetta"
        Me.btnLeggiRicetta.UseVisualStyleBackColor = True
        '
        'btnCalcolaFattibilità
        '
        Me.btnCalcolaFattibilità.Location = New System.Drawing.Point(46, 236)
        Me.btnCalcolaFattibilità.Name = "btnCalcolaFattibilità"
        Me.btnCalcolaFattibilità.Size = New System.Drawing.Size(143, 53)
        Me.btnCalcolaFattibilità.TabIndex = 1
        Me.btnCalcolaFattibilità.Text = "Calcola Fattibilità Ricetta"
        Me.btnCalcolaFattibilità.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(207, 23)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(581, 112)
        Me.DataGridView1.TabIndex = 3
        '
        'txtNrRicetta
        '
        Me.txtNrRicetta.Location = New System.Drawing.Point(119, 82)
        Me.txtNrRicetta.Name = "txtNrRicetta"
        Me.txtNrRicetta.Size = New System.Drawing.Size(70, 20)
        Me.txtNrRicetta.TabIndex = 4
        Me.txtNrRicetta.Text = "27"
        '
        'btnTest
        '
        Me.btnTest.BackColor = System.Drawing.Color.ForestGreen
        Me.btnTest.Location = New System.Drawing.Point(535, 356)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(253, 82)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "CALCOLA FATTIBILITA' TUTTE LE RICETTE"
        Me.btnTest.UseVisualStyleBackColor = False
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(281, 141)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(197, 297)
        Me.TreeView1.TabIndex = 6
        '
        'btnSilosPrelievoBatchRicetta
        '
        Me.btnSilosPrelievoBatchRicetta.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnSilosPrelievoBatchRicetta.Location = New System.Drawing.Point(535, 268)
        Me.btnSilosPrelievoBatchRicetta.Name = "btnSilosPrelievoBatchRicetta"
        Me.btnSilosPrelievoBatchRicetta.Size = New System.Drawing.Size(253, 82)
        Me.btnSilosPrelievoBatchRicetta.TabIndex = 7
        Me.btnSilosPrelievoBatchRicetta.Text = "CALCOLA SILOS PER BATCH RICETTA"
        Me.btnSilosPrelievoBatchRicetta.UseVisualStyleBackColor = False
        '
        'txtCombinazione
        '
        Me.txtCombinazione.Location = New System.Drawing.Point(119, 108)
        Me.txtCombinazione.Name = "txtCombinazione"
        Me.txtCombinazione.Size = New System.Drawing.Size(70, 20)
        Me.txtCombinazione.TabIndex = 8
        Me.txtCombinazione.Text = "15"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Ricetta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Combinazione"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCombinazione)
        Me.Controls.Add(Me.btnSilosPrelievoBatchRicetta)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.txtNrRicetta)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnCalcolaFattibilità)
        Me.Controls.Add(Me.btnLeggiRicetta)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnLeggiRicetta As Button
    Friend WithEvents btnCalcolaFattibilità As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtNrRicetta As TextBox
    Friend WithEvents btnTest As Button
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents btnSilosPrelievoBatchRicetta As Button
    Friend WithEvents txtCombinazione As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
