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
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_replyId = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_lotto = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_erroreCiclo = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_pesoBilancia = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_sequenzaRichiesta = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_combinazioneBilance = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_ricettaNr = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_tostatriceNr = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_idRichiesta = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_sync = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_sync1 = New System.Windows.Forms.Label()
        Me.lbl_FromPlc_CrudoMsg013_sync2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_singoloSilos = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_codiceProdotto = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_fineRicetta = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_tolleranzaPeso = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_silosPrelievo = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_sync1 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_sync2 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_sync = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_lotto = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_pesoDaPrelevare = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_idRichiesta = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_tostatriceNr = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_combinazioneBilance = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_ricettaNr = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.lbl_ToPlc_CrudoMsg013_silosMultipli = New System.Windows.Forms.Label()
        Me.btnImportRecipes = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label55)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_replyId)
        Me.GroupBox7.Controls.Add(Me.Label38)
        Me.GroupBox7.Controls.Add(Me.Label39)
        Me.GroupBox7.Controls.Add(Me.Label40)
        Me.GroupBox7.Controls.Add(Me.Label41)
        Me.GroupBox7.Controls.Add(Me.Label44)
        Me.GroupBox7.Controls.Add(Me.Label46)
        Me.GroupBox7.Controls.Add(Me.Label47)
        Me.GroupBox7.Controls.Add(Me.Label48)
        Me.GroupBox7.Controls.Add(Me.Label49)
        Me.GroupBox7.Controls.Add(Me.Label50)
        Me.GroupBox7.Controls.Add(Me.Label51)
        Me.GroupBox7.Controls.Add(Me.Label52)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_lotto)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_erroreCiclo)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_pesoBilancia)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_sequenzaRichiesta)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_combinazioneBilance)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_ricettaNr)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_tostatriceNr)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_idRichiesta)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_sync)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_sync1)
        Me.GroupBox7.Controls.Add(Me.lbl_FromPlc_CrudoMsg013_sync2)
        Me.GroupBox7.Location = New System.Drawing.Point(929, 141)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(362, 273)
        Me.GroupBox7.TabIndex = 41
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "MSG004 - CARICO DA PULIZIA A DOSAGGIO"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(19, 81)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(38, 13)
        Me.Label55.TabIndex = 49
        Me.Label55.Text = "replyId"
        '
        'lbl_FromPlc_CrudoMsg013_replyId
        '
        Me.lbl_FromPlc_CrudoMsg013_replyId.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_replyId.Location = New System.Drawing.Point(140, 81)
        Me.lbl_FromPlc_CrudoMsg013_replyId.Name = "lbl_FromPlc_CrudoMsg013_replyId"
        Me.lbl_FromPlc_CrudoMsg013_replyId.Size = New System.Drawing.Size(170, 13)
        Me.lbl_FromPlc_CrudoMsg013_replyId.TabIndex = 50
        Me.lbl_FromPlc_CrudoMsg013_replyId.Text = "lbl_FromPlc_CrudoMsg013_replyId"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(19, 193)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(103, 13)
        Me.Label38.TabIndex = 47
        Me.Label38.Text = "ultimo silos scaricato"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(19, 210)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(59, 13)
        Me.Label39.TabIndex = 48
        Me.Label39.Text = "errore ciclo"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(19, 33)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(35, 13)
        Me.Label40.TabIndex = 46
        Me.Label40.Text = "sync1"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(19, 49)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(35, 13)
        Me.Label41.TabIndex = 45
        Me.Label41.Text = "sync2"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(19, 65)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(29, 13)
        Me.Label44.TabIndex = 44
        Me.Label44.Text = "sync"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(19, 227)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(31, 13)
        Me.Label46.TabIndex = 43
        Me.Label46.Text = "Lotto"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(19, 177)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(70, 13)
        Me.Label47.TabIndex = 42
        Me.Label47.Text = "peso Bilancia"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(19, 97)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(57, 13)
        Me.Label48.TabIndex = 41
        Me.Label48.Text = "id richiesta"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(19, 113)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(64, 13)
        Me.Label49.TabIndex = 40
        Me.Label49.Text = "tostatrice Nr"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(19, 161)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(100, 13)
        Me.Label50.TabIndex = 37
        Me.Label50.Text = "sequenza Richiesta"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(19, 129)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(48, 13)
        Me.Label51.TabIndex = 38
        Me.Label51.Text = "ricetta nr"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(19, 145)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(110, 13)
        Me.Label52.TabIndex = 39
        Me.Label52.Text = "combinazione Bilance"
        '
        'lbl_FromPlc_CrudoMsg013_lotto
        '
        Me.lbl_FromPlc_CrudoMsg013_lotto.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_lotto.Location = New System.Drawing.Point(140, 233)
        Me.lbl_FromPlc_CrudoMsg013_lotto.Name = "lbl_FromPlc_CrudoMsg013_lotto"
        Me.lbl_FromPlc_CrudoMsg013_lotto.Size = New System.Drawing.Size(159, 13)
        Me.lbl_FromPlc_CrudoMsg013_lotto.TabIndex = 26
        Me.lbl_FromPlc_CrudoMsg013_lotto.Text = "lbl_FromPlc_CrudoMsg013_lotto"
        '
        'lbl_FromPlc_CrudoMsg013_erroreCiclo
        '
        Me.lbl_FromPlc_CrudoMsg013_erroreCiclo.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_erroreCiclo.Location = New System.Drawing.Point(140, 216)
        Me.lbl_FromPlc_CrudoMsg013_erroreCiclo.Name = "lbl_FromPlc_CrudoMsg013_erroreCiclo"
        Me.lbl_FromPlc_CrudoMsg013_erroreCiclo.Size = New System.Drawing.Size(189, 13)
        Me.lbl_FromPlc_CrudoMsg013_erroreCiclo.TabIndex = 24
        Me.lbl_FromPlc_CrudoMsg013_erroreCiclo.Text = "lbl_FromPlc_CrudoMsg013_erroreCiclo"
        '
        'lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato
        '
        Me.lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato.Location = New System.Drawing.Point(140, 199)
        Me.lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato.Name = "lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato"
        Me.lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato.Size = New System.Drawing.Size(233, 13)
        Me.lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato.TabIndex = 22
        Me.lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato.Text = "lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato"
        '
        'lbl_FromPlc_CrudoMsg013_pesoBilancia
        '
        Me.lbl_FromPlc_CrudoMsg013_pesoBilancia.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_pesoBilancia.Location = New System.Drawing.Point(140, 182)
        Me.lbl_FromPlc_CrudoMsg013_pesoBilancia.Name = "lbl_FromPlc_CrudoMsg013_pesoBilancia"
        Me.lbl_FromPlc_CrudoMsg013_pesoBilancia.Size = New System.Drawing.Size(199, 13)
        Me.lbl_FromPlc_CrudoMsg013_pesoBilancia.TabIndex = 20
        Me.lbl_FromPlc_CrudoMsg013_pesoBilancia.Text = "lbl_FromPlc_CrudoMsg013_pesoBilancia"
        '
        'lbl_FromPlc_CrudoMsg013_sequenzaRichiesta
        '
        Me.lbl_FromPlc_CrudoMsg013_sequenzaRichiesta.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_sequenzaRichiesta.Location = New System.Drawing.Point(140, 165)
        Me.lbl_FromPlc_CrudoMsg013_sequenzaRichiesta.Name = "lbl_FromPlc_CrudoMsg013_sequenzaRichiesta"
        Me.lbl_FromPlc_CrudoMsg013_sequenzaRichiesta.Size = New System.Drawing.Size(229, 13)
        Me.lbl_FromPlc_CrudoMsg013_sequenzaRichiesta.TabIndex = 18
        Me.lbl_FromPlc_CrudoMsg013_sequenzaRichiesta.Text = "lbl_FromPlc_CrudoMsg013_sequenzaRichiesta"
        '
        'lbl_FromPlc_CrudoMsg013_combinazioneBilance
        '
        Me.lbl_FromPlc_CrudoMsg013_combinazioneBilance.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_combinazioneBilance.Location = New System.Drawing.Point(140, 148)
        Me.lbl_FromPlc_CrudoMsg013_combinazioneBilance.Name = "lbl_FromPlc_CrudoMsg013_combinazioneBilance"
        Me.lbl_FromPlc_CrudoMsg013_combinazioneBilance.Size = New System.Drawing.Size(239, 13)
        Me.lbl_FromPlc_CrudoMsg013_combinazioneBilance.TabIndex = 16
        Me.lbl_FromPlc_CrudoMsg013_combinazioneBilance.Text = "lbl_FromPlc_CrudoMsg013_combinazioneBilance"
        '
        'lbl_FromPlc_CrudoMsg013_ricettaNr
        '
        Me.lbl_FromPlc_CrudoMsg013_ricettaNr.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_ricettaNr.Location = New System.Drawing.Point(140, 131)
        Me.lbl_FromPlc_CrudoMsg013_ricettaNr.Name = "lbl_FromPlc_CrudoMsg013_ricettaNr"
        Me.lbl_FromPlc_CrudoMsg013_ricettaNr.Size = New System.Drawing.Size(179, 13)
        Me.lbl_FromPlc_CrudoMsg013_ricettaNr.TabIndex = 14
        Me.lbl_FromPlc_CrudoMsg013_ricettaNr.Text = "lbl_FromPlc_CrudoMsg013_ricettaNr"
        '
        'lbl_FromPlc_CrudoMsg013_tostatriceNr
        '
        Me.lbl_FromPlc_CrudoMsg013_tostatriceNr.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_tostatriceNr.Location = New System.Drawing.Point(140, 114)
        Me.lbl_FromPlc_CrudoMsg013_tostatriceNr.Name = "lbl_FromPlc_CrudoMsg013_tostatriceNr"
        Me.lbl_FromPlc_CrudoMsg013_tostatriceNr.Size = New System.Drawing.Size(193, 13)
        Me.lbl_FromPlc_CrudoMsg013_tostatriceNr.TabIndex = 13
        Me.lbl_FromPlc_CrudoMsg013_tostatriceNr.Text = "lbl_FromPlc_CrudoMsg013_tostatriceNr"
        '
        'lbl_FromPlc_CrudoMsg013_idRichiesta
        '
        Me.lbl_FromPlc_CrudoMsg013_idRichiesta.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_idRichiesta.Location = New System.Drawing.Point(140, 97)
        Me.lbl_FromPlc_CrudoMsg013_idRichiesta.Name = "lbl_FromPlc_CrudoMsg013_idRichiesta"
        Me.lbl_FromPlc_CrudoMsg013_idRichiesta.Size = New System.Drawing.Size(191, 13)
        Me.lbl_FromPlc_CrudoMsg013_idRichiesta.TabIndex = 12
        Me.lbl_FromPlc_CrudoMsg013_idRichiesta.Text = "lbl_FromPlc_CrudoMsg013_idRichiesta"
        '
        'lbl_FromPlc_CrudoMsg013_sync
        '
        Me.lbl_FromPlc_CrudoMsg013_sync.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_sync.Location = New System.Drawing.Point(140, 67)
        Me.lbl_FromPlc_CrudoMsg013_sync.Name = "lbl_FromPlc_CrudoMsg013_sync"
        Me.lbl_FromPlc_CrudoMsg013_sync.Size = New System.Drawing.Size(161, 13)
        Me.lbl_FromPlc_CrudoMsg013_sync.TabIndex = 10
        Me.lbl_FromPlc_CrudoMsg013_sync.Text = "lbl_FromPlc_CrudoMsg013_sync"
        '
        'lbl_FromPlc_CrudoMsg013_sync1
        '
        Me.lbl_FromPlc_CrudoMsg013_sync1.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_sync1.Location = New System.Drawing.Point(140, 33)
        Me.lbl_FromPlc_CrudoMsg013_sync1.Name = "lbl_FromPlc_CrudoMsg013_sync1"
        Me.lbl_FromPlc_CrudoMsg013_sync1.Size = New System.Drawing.Size(167, 13)
        Me.lbl_FromPlc_CrudoMsg013_sync1.TabIndex = 8
        Me.lbl_FromPlc_CrudoMsg013_sync1.Text = "lbl_FromPlc_CrudoMsg013_sync1"
        '
        'lbl_FromPlc_CrudoMsg013_sync2
        '
        Me.lbl_FromPlc_CrudoMsg013_sync2.AutoSize = True
        Me.lbl_FromPlc_CrudoMsg013_sync2.Location = New System.Drawing.Point(140, 50)
        Me.lbl_FromPlc_CrudoMsg013_sync2.Name = "lbl_FromPlc_CrudoMsg013_sync2"
        Me.lbl_FromPlc_CrudoMsg013_sync2.Size = New System.Drawing.Size(167, 13)
        Me.lbl_FromPlc_CrudoMsg013_sync2.TabIndex = 9
        Me.lbl_FromPlc_CrudoMsg013_sync2.Text = "lbl_FromPlc_CrudoMsg013_sync2"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label56)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_singoloSilos)
        Me.GroupBox4.Controls.Add(Me.Label54)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_codiceProdotto)
        Me.GroupBox4.Controls.Add(Me.Label53)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_fineRicetta)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_tolleranzaPeso)
        Me.GroupBox4.Controls.Add(Me.Label43)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_silosPrelievo)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_sync1)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_sync2)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_sync)
        Me.GroupBox4.Controls.Add(Me.Label33)
        Me.GroupBox4.Controls.Add(Me.Label36)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.Label62)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_lotto)
        Me.GroupBox4.Controls.Add(Me.Label70)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_pesoDaPrelevare)
        Me.GroupBox4.Controls.Add(Me.Label75)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_idRichiesta)
        Me.GroupBox4.Controls.Add(Me.Label77)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_tostatriceNr)
        Me.GroupBox4.Controls.Add(Me.Label79)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_combinazioneBilance)
        Me.GroupBox4.Controls.Add(Me.Label81)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_ricettaNr)
        Me.GroupBox4.Controls.Add(Me.Label83)
        Me.GroupBox4.Controls.Add(Me.lbl_ToPlc_CrudoMsg013_silosMultipli)
        Me.GroupBox4.Location = New System.Drawing.Point(1320, 141)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(359, 324)
        Me.GroupBox4.TabIndex = 40
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "MSG004 - RICHIESTA CARICO DA PULIZIA A DOSAGGIO"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(26, 155)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(63, 13)
        Me.Label56.TabIndex = 44
        Me.Label56.Text = "singolo silos"
        '
        'lbl_ToPlc_CrudoMsg013_singoloSilos
        '
        Me.lbl_ToPlc_CrudoMsg013_singoloSilos.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_singoloSilos.Location = New System.Drawing.Point(138, 155)
        Me.lbl_ToPlc_CrudoMsg013_singoloSilos.Name = "lbl_ToPlc_CrudoMsg013_singoloSilos"
        Me.lbl_ToPlc_CrudoMsg013_singoloSilos.Size = New System.Drawing.Size(184, 13)
        Me.lbl_ToPlc_CrudoMsg013_singoloSilos.TabIndex = 45
        Me.lbl_ToPlc_CrudoMsg013_singoloSilos.Text = "lbl_ToPlc_CrudoMsg013_singoloSilos"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(26, 223)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(81, 13)
        Me.Label54.TabIndex = 42
        Me.Label54.Text = "codice prodotto"
        '
        'lbl_ToPlc_CrudoMsg013_codiceProdotto
        '
        Me.lbl_ToPlc_CrudoMsg013_codiceProdotto.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_codiceProdotto.Location = New System.Drawing.Point(138, 223)
        Me.lbl_ToPlc_CrudoMsg013_codiceProdotto.Name = "lbl_ToPlc_CrudoMsg013_codiceProdotto"
        Me.lbl_ToPlc_CrudoMsg013_codiceProdotto.Size = New System.Drawing.Size(201, 13)
        Me.lbl_ToPlc_CrudoMsg013_codiceProdotto.TabIndex = 43
        Me.lbl_ToPlc_CrudoMsg013_codiceProdotto.Text = "lbl_ToPlc_CrudoMsg013_codiceProdotto"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(26, 188)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(56, 13)
        Me.Label53.TabIndex = 40
        Me.Label53.Text = "fine ricetta"
        '
        'lbl_ToPlc_CrudoMsg013_fineRicetta
        '
        Me.lbl_ToPlc_CrudoMsg013_fineRicetta.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_fineRicetta.Location = New System.Drawing.Point(138, 188)
        Me.lbl_ToPlc_CrudoMsg013_fineRicetta.Name = "lbl_ToPlc_CrudoMsg013_fineRicetta"
        Me.lbl_ToPlc_CrudoMsg013_fineRicetta.Size = New System.Drawing.Size(180, 13)
        Me.lbl_ToPlc_CrudoMsg013_fineRicetta.TabIndex = 41
        Me.lbl_ToPlc_CrudoMsg013_fineRicetta.Text = "lbl_ToPlc_CrudoMsg013_fineRicetta"
        '
        'lbl_ToPlc_CrudoMsg013_tolleranzaPeso
        '
        Me.lbl_ToPlc_CrudoMsg013_tolleranzaPeso.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_tolleranzaPeso.Location = New System.Drawing.Point(138, 255)
        Me.lbl_ToPlc_CrudoMsg013_tolleranzaPeso.Name = "lbl_ToPlc_CrudoMsg013_tolleranzaPeso"
        Me.lbl_ToPlc_CrudoMsg013_tolleranzaPeso.Size = New System.Drawing.Size(198, 13)
        Me.lbl_ToPlc_CrudoMsg013_tolleranzaPeso.TabIndex = 39
        Me.lbl_ToPlc_CrudoMsg013_tolleranzaPeso.Text = "lbl_ToPlc_CrudoMsg013_tolleranzaPeso"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(26, 205)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(67, 13)
        Me.Label43.TabIndex = 35
        Me.Label43.Text = "silos prelievo"
        '
        'lbl_ToPlc_CrudoMsg013_silosPrelievo
        '
        Me.lbl_ToPlc_CrudoMsg013_silosPrelievo.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_silosPrelievo.Location = New System.Drawing.Point(138, 205)
        Me.lbl_ToPlc_CrudoMsg013_silosPrelievo.Name = "lbl_ToPlc_CrudoMsg013_silosPrelievo"
        Me.lbl_ToPlc_CrudoMsg013_silosPrelievo.Size = New System.Drawing.Size(187, 13)
        Me.lbl_ToPlc_CrudoMsg013_silosPrelievo.TabIndex = 38
        Me.lbl_ToPlc_CrudoMsg013_silosPrelievo.Text = "lbl_ToPlc_CrudoMsg013_silosPrelievo"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(26, 255)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(78, 13)
        Me.Label45.TabIndex = 36
        Me.Label45.Text = "tolleranza peso"
        '
        'lbl_ToPlc_CrudoMsg013_sync1
        '
        Me.lbl_ToPlc_CrudoMsg013_sync1.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_sync1.Location = New System.Drawing.Point(138, 42)
        Me.lbl_ToPlc_CrudoMsg013_sync1.Name = "lbl_ToPlc_CrudoMsg013_sync1"
        Me.lbl_ToPlc_CrudoMsg013_sync1.Size = New System.Drawing.Size(157, 13)
        Me.lbl_ToPlc_CrudoMsg013_sync1.TabIndex = 27
        Me.lbl_ToPlc_CrudoMsg013_sync1.Text = "lbl_ToPlc_CrudoMsg013_sync1"
        '
        'lbl_ToPlc_CrudoMsg013_sync2
        '
        Me.lbl_ToPlc_CrudoMsg013_sync2.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_sync2.Location = New System.Drawing.Point(138, 58)
        Me.lbl_ToPlc_CrudoMsg013_sync2.Name = "lbl_ToPlc_CrudoMsg013_sync2"
        Me.lbl_ToPlc_CrudoMsg013_sync2.Size = New System.Drawing.Size(157, 13)
        Me.lbl_ToPlc_CrudoMsg013_sync2.TabIndex = 26
        Me.lbl_ToPlc_CrudoMsg013_sync2.Text = "lbl_ToPlc_CrudoMsg013_sync2"
        '
        'lbl_ToPlc_CrudoMsg013_sync
        '
        Me.lbl_ToPlc_CrudoMsg013_sync.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_sync.Location = New System.Drawing.Point(138, 74)
        Me.lbl_ToPlc_CrudoMsg013_sync.Name = "lbl_ToPlc_CrudoMsg013_sync"
        Me.lbl_ToPlc_CrudoMsg013_sync.Size = New System.Drawing.Size(151, 13)
        Me.lbl_ToPlc_CrudoMsg013_sync.TabIndex = 25
        Me.lbl_ToPlc_CrudoMsg013_sync.Text = "lbl_ToPlc_CrudoMsg013_sync"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(26, 42)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(35, 13)
        Me.Label33.TabIndex = 24
        Me.Label33.Text = "sync1"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(26, 58)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(35, 13)
        Me.Label36.TabIndex = 23
        Me.Label36.Text = "sync2"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(26, 74)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(29, 13)
        Me.Label37.TabIndex = 22
        Me.Label37.Text = "sync"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(26, 272)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(31, 13)
        Me.Label62.TabIndex = 20
        Me.Label62.Text = "Lotto"
        '
        'lbl_ToPlc_CrudoMsg013_lotto
        '
        Me.lbl_ToPlc_CrudoMsg013_lotto.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_lotto.Location = New System.Drawing.Point(138, 272)
        Me.lbl_ToPlc_CrudoMsg013_lotto.Name = "lbl_ToPlc_CrudoMsg013_lotto"
        Me.lbl_ToPlc_CrudoMsg013_lotto.Size = New System.Drawing.Size(149, 13)
        Me.lbl_ToPlc_CrudoMsg013_lotto.TabIndex = 21
        Me.lbl_ToPlc_CrudoMsg013_lotto.Text = "lbl_ToPlc_CrudoMsg013_lotto"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(26, 239)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(92, 13)
        Me.Label70.TabIndex = 18
        Me.Label70.Text = "peso da prelevare"
        '
        'lbl_ToPlc_CrudoMsg013_pesoDaPrelevare
        '
        Me.lbl_ToPlc_CrudoMsg013_pesoDaPrelevare.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_pesoDaPrelevare.Location = New System.Drawing.Point(138, 239)
        Me.lbl_ToPlc_CrudoMsg013_pesoDaPrelevare.Name = "lbl_ToPlc_CrudoMsg013_pesoDaPrelevare"
        Me.lbl_ToPlc_CrudoMsg013_pesoDaPrelevare.Size = New System.Drawing.Size(211, 13)
        Me.lbl_ToPlc_CrudoMsg013_pesoDaPrelevare.TabIndex = 19
        Me.lbl_ToPlc_CrudoMsg013_pesoDaPrelevare.Text = "lbl_ToPlc_CrudoMsg013_pesoDaPrelevare"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(26, 90)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(57, 13)
        Me.Label75.TabIndex = 16
        Me.Label75.Text = "id richiesta"
        '
        'lbl_ToPlc_CrudoMsg013_idRichiesta
        '
        Me.lbl_ToPlc_CrudoMsg013_idRichiesta.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_idRichiesta.Location = New System.Drawing.Point(138, 90)
        Me.lbl_ToPlc_CrudoMsg013_idRichiesta.Name = "lbl_ToPlc_CrudoMsg013_idRichiesta"
        Me.lbl_ToPlc_CrudoMsg013_idRichiesta.Size = New System.Drawing.Size(181, 13)
        Me.lbl_ToPlc_CrudoMsg013_idRichiesta.TabIndex = 17
        Me.lbl_ToPlc_CrudoMsg013_idRichiesta.Text = "lbl_ToPlc_CrudoMsg013_idRichiesta"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(26, 106)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(64, 13)
        Me.Label77.TabIndex = 14
        Me.Label77.Text = "tostatrice Nr"
        '
        'lbl_ToPlc_CrudoMsg013_tostatriceNr
        '
        Me.lbl_ToPlc_CrudoMsg013_tostatriceNr.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_tostatriceNr.Location = New System.Drawing.Point(138, 106)
        Me.lbl_ToPlc_CrudoMsg013_tostatriceNr.Name = "lbl_ToPlc_CrudoMsg013_tostatriceNr"
        Me.lbl_ToPlc_CrudoMsg013_tostatriceNr.Size = New System.Drawing.Size(183, 13)
        Me.lbl_ToPlc_CrudoMsg013_tostatriceNr.TabIndex = 15
        Me.lbl_ToPlc_CrudoMsg013_tostatriceNr.Text = "lbl_ToPlc_CrudoMsg013_tostatriceNr"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(26, 171)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(61, 13)
        Me.Label79.TabIndex = 0
        Me.Label79.Text = "silos multipli"
        '
        'lbl_ToPlc_CrudoMsg013_combinazioneBilance
        '
        Me.lbl_ToPlc_CrudoMsg013_combinazioneBilance.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_combinazioneBilance.Location = New System.Drawing.Point(138, 138)
        Me.lbl_ToPlc_CrudoMsg013_combinazioneBilance.Name = "lbl_ToPlc_CrudoMsg013_combinazioneBilance"
        Me.lbl_ToPlc_CrudoMsg013_combinazioneBilance.Size = New System.Drawing.Size(229, 13)
        Me.lbl_ToPlc_CrudoMsg013_combinazioneBilance.TabIndex = 13
        Me.lbl_ToPlc_CrudoMsg013_combinazioneBilance.Text = "lbl_ToPlc_CrudoMsg013_combinazioneBilance"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(26, 122)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(48, 13)
        Me.Label81.TabIndex = 4
        Me.Label81.Text = "ricetta nr"
        '
        'lbl_ToPlc_CrudoMsg013_ricettaNr
        '
        Me.lbl_ToPlc_CrudoMsg013_ricettaNr.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_ricettaNr.Location = New System.Drawing.Point(138, 122)
        Me.lbl_ToPlc_CrudoMsg013_ricettaNr.Name = "lbl_ToPlc_CrudoMsg013_ricettaNr"
        Me.lbl_ToPlc_CrudoMsg013_ricettaNr.Size = New System.Drawing.Size(169, 13)
        Me.lbl_ToPlc_CrudoMsg013_ricettaNr.TabIndex = 12
        Me.lbl_ToPlc_CrudoMsg013_ricettaNr.Text = "lbl_ToPlc_CrudoMsg013_ricettaNr"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(26, 138)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(110, 13)
        Me.Label83.TabIndex = 5
        Me.Label83.Text = "combinazione Bilance"
        '
        'lbl_ToPlc_CrudoMsg013_silosMultipli
        '
        Me.lbl_ToPlc_CrudoMsg013_silosMultipli.AutoSize = True
        Me.lbl_ToPlc_CrudoMsg013_silosMultipli.Location = New System.Drawing.Point(138, 171)
        Me.lbl_ToPlc_CrudoMsg013_silosMultipli.Name = "lbl_ToPlc_CrudoMsg013_silosMultipli"
        Me.lbl_ToPlc_CrudoMsg013_silosMultipli.Size = New System.Drawing.Size(181, 13)
        Me.lbl_ToPlc_CrudoMsg013_silosMultipli.TabIndex = 8
        Me.lbl_ToPlc_CrudoMsg013_silosMultipli.Text = "lbl_ToPlc_CrudoMsg013_silosMultipli"
        '
        'btnImportRecipes
        '
        Me.btnImportRecipes.Location = New System.Drawing.Point(929, 12)
        Me.btnImportRecipes.Name = "btnImportRecipes"
        Me.btnImportRecipes.Size = New System.Drawing.Size(256, 53)
        Me.btnImportRecipes.TabIndex = 42
        Me.btnImportRecipes.Text = "IMPORTA RICETTE DA FILE"
        Me.btnImportRecipes.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1845, 591)
        Me.Controls.Add(Me.btnImportRecipes)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox4)
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
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label55 As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_replyId As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_lotto As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_erroreCiclo As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_ultimoSilosScaricato As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_pesoBilancia As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_sequenzaRichiesta As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_combinazioneBilance As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_ricettaNr As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_tostatriceNr As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_idRichiesta As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_sync As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_sync1 As Label
    Friend WithEvents lbl_FromPlc_CrudoMsg013_sync2 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label56 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_singoloSilos As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_codiceProdotto As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_fineRicetta As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_tolleranzaPeso As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_silosPrelievo As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_sync1 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_sync2 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_sync As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_lotto As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_pesoDaPrelevare As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_idRichiesta As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_tostatriceNr As Label
    Friend WithEvents Label79 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_combinazioneBilance As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_ricettaNr As Label
    Friend WithEvents Label83 As Label
    Friend WithEvents lbl_ToPlc_CrudoMsg013_silosMultipli As Label
    Friend WithEvents btnImportRecipes As Button
End Class
