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
        Me.txtNrRicetta.Location = New System.Drawing.Point(46, 82)
        Me.txtNrRicetta.Name = "txtNrRicetta"
        Me.txtNrRicetta.Size = New System.Drawing.Size(143, 20)
        Me.txtNrRicetta.TabIndex = 4
        Me.txtNrRicetta.Text = "27"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(545, 221)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(208, 124)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "TEST"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(281, 141)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(197, 297)
        Me.TreeView1.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
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
End Class
