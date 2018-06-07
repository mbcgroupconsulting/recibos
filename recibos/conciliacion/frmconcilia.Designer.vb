<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmconcilia
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmconcilia))
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.txtidempresa = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtcomision = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbobanco = New System.Windows.Forms.ComboBox()
        Me.cboempresa = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Nudrango = New System.Windows.Forms.NumericUpDown()
        Me.rdbrango = New System.Windows.Forms.RadioButton()
        Me.rdbIguales = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkfecha = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NudSaldo = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NudAbono = New System.Windows.Forms.NumericUpDown()
        Me.NudCargo = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NudConcepto = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NudFecha = New System.Windows.Forms.NumericUpDown()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tsbProcesar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbreportes = New System.Windows.Forms.ToolStripButton()
        Me.tsbExcel = New System.Windows.Forms.ToolStripButton()
        Me.pnlProgreso = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar()
        Me.tsbDeleted = New System.Windows.Forms.ToolStripButton()
        Me.pnlCatalogo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Nudrango, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlProgreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(829, 565)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.cmdCerrar.Size = New System.Drawing.Size(104, 43)
        Me.cmdCerrar.TabIndex = 39
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.txtidempresa)
        Me.pnlCatalogo.Controls.Add(Me.Label15)
        Me.pnlCatalogo.Controls.Add(Me.txtcomision)
        Me.pnlCatalogo.Controls.Add(Me.Label14)
        Me.pnlCatalogo.Controls.Add(Me.Label13)
        Me.pnlCatalogo.Controls.Add(Me.cbobanco)
        Me.pnlCatalogo.Controls.Add(Me.cboempresa)
        Me.pnlCatalogo.Controls.Add(Me.Label10)
        Me.pnlCatalogo.Controls.Add(Me.Label9)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechafin)
        Me.pnlCatalogo.Controls.Add(Me.Label1)
        Me.pnlCatalogo.Controls.Add(Me.Label3)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechainicio)
        Me.pnlCatalogo.Controls.Add(Me.Panel1)
        Me.pnlCatalogo.Controls.Add(Me.CheckBox1)
        Me.pnlCatalogo.Controls.Add(Me.chkfecha)
        Me.pnlCatalogo.Controls.Add(Me.GroupBox1)
        Me.pnlCatalogo.Controls.Add(Me.chkAll)
        Me.pnlCatalogo.Controls.Add(Me.lsvLista)
        Me.pnlCatalogo.Enabled = False
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 58)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(945, 501)
        Me.pnlCatalogo.TabIndex = 38
        '
        'txtidempresa
        '
        Me.txtidempresa.Location = New System.Drawing.Point(395, 109)
        Me.txtidempresa.Name = "txtidempresa"
        Me.txtidempresa.Size = New System.Drawing.Size(65, 27)
        Me.txtidempresa.TabIndex = 57
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(28, 109)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(361, 19)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "Identificador de la empresa en el catalogo de clientes:"
        '
        'txtcomision
        '
        Me.txtcomision.Location = New System.Drawing.Point(587, 60)
        Me.txtcomision.Name = "txtcomision"
        Me.txtcomision.Size = New System.Drawing.Size(342, 27)
        Me.txtcomision.TabIndex = 55
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(646, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(285, 13)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "En caso de ser mas de un identificador separarlo por comas (,)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(502, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 19)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Comisiones:"
        '
        'cbobanco
        '
        Me.cbobanco.FormattingEnabled = True
        Me.cbobanco.Location = New System.Drawing.Point(26, 60)
        Me.cbobanco.Name = "cbobanco"
        Me.cbobanco.Size = New System.Drawing.Size(471, 27)
        Me.cbobanco.TabIndex = 50
        '
        'cboempresa
        '
        Me.cboempresa.FormattingEnabled = True
        Me.cboempresa.Location = New System.Drawing.Point(26, 16)
        Me.cboempresa.Name = "cboempresa"
        Me.cboempresa.Size = New System.Drawing.Size(471, 27)
        Me.cboempresa.TabIndex = 49
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 19)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Banco"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, -2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 19)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Empresa"
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(826, 1)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechafin.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(792, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 19)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Fin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(640, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 19)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(690, 1)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechainicio.TabIndex = 43
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Nudrango)
        Me.Panel1.Controls.Add(Me.rdbrango)
        Me.Panel1.Controls.Add(Me.rdbIguales)
        Me.Panel1.Location = New System.Drawing.Point(506, 108)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(340, 30)
        Me.Panel1.TabIndex = 42
        '
        'Nudrango
        '
        Me.Nudrango.DecimalPlaces = 2
        Me.Nudrango.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nudrango.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Nudrango.Location = New System.Drawing.Point(254, 1)
        Me.Nudrango.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Nudrango.Name = "Nudrango"
        Me.Nudrango.Size = New System.Drawing.Size(72, 27)
        Me.Nudrango.TabIndex = 21
        '
        'rdbrango
        '
        Me.rdbrango.AutoSize = True
        Me.rdbrango.Location = New System.Drawing.Point(160, 3)
        Me.rdbrango.Name = "rdbrango"
        Me.rdbrango.Size = New System.Drawing.Size(89, 23)
        Me.rdbrango.TabIndex = 1
        Me.rdbrango.Text = "Rango - +"
        Me.rdbrango.UseVisualStyleBackColor = True
        '
        'rdbIguales
        '
        Me.rdbIguales.AutoSize = True
        Me.rdbIguales.Checked = True
        Me.rdbIguales.Location = New System.Drawing.Point(3, 3)
        Me.rdbIguales.Name = "rdbIguales"
        Me.rdbIguales.Size = New System.Drawing.Size(151, 23)
        Me.rdbIguales.TabIndex = 0
        Me.rdbIguales.TabStop = True
        Me.rdbIguales.Text = "Cantidades iguales"
        Me.rdbIguales.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(503, 35)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(320, 23)
        Me.CheckBox1.TabIndex = 40
        Me.CheckBox1.Text = "Sobreescribir datos guardados anteriormente"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkfecha
        '
        Me.chkfecha.AutoSize = True
        Me.chkfecha.Checked = True
        Me.chkfecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkfecha.Location = New System.Drawing.Point(503, 6)
        Me.chkfecha.Name = "chkfecha"
        Me.chkfecha.Size = New System.Drawing.Size(136, 23)
        Me.chkfecha.TabIndex = 39
        Me.chkfecha.Text = "Rango de fechas"
        Me.chkfecha.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NudSaldo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.NudAbono)
        Me.GroupBox1.Controls.Add(Me.NudCargo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.NudConcepto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.NudFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(129, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(618, 53)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecciona las columnas de información"
        '
        'NudSaldo
        '
        Me.NudSaldo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudSaldo.Location = New System.Drawing.Point(544, 24)
        Me.NudSaldo.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NudSaldo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudSaldo.Name = "NudSaldo"
        Me.NudSaldo.Size = New System.Drawing.Size(45, 27)
        Me.NudSaldo.TabIndex = 26
        Me.NudSaldo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(500, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 19)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Saldo:"
        '
        'NudAbono
        '
        Me.NudAbono.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudAbono.Location = New System.Drawing.Point(449, 25)
        Me.NudAbono.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NudAbono.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudAbono.Name = "NudAbono"
        Me.NudAbono.Size = New System.Drawing.Size(45, 27)
        Me.NudAbono.TabIndex = 24
        Me.NudAbono.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudCargo
        '
        Me.NudCargo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudCargo.Location = New System.Drawing.Point(341, 24)
        Me.NudCargo.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NudCargo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCargo.Name = "NudCargo"
        Me.NudCargo.Size = New System.Drawing.Size(46, 27)
        Me.NudCargo.TabIndex = 23
        Me.NudCargo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(395, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 19)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Abono:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(293, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 19)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Cargo:"
        '
        'NudConcepto
        '
        Me.NudConcepto.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudConcepto.Location = New System.Drawing.Point(220, 25)
        Me.NudConcepto.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudConcepto.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudConcepto.Name = "NudConcepto"
        Me.NudConcepto.Size = New System.Drawing.Size(72, 27)
        Me.NudConcepto.TabIndex = 20
        Me.NudConcepto.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(146, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 19)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Concepto:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 19)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Fecha:"
        '
        'NudFecha
        '
        Me.NudFecha.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFecha.Location = New System.Drawing.Point(61, 25)
        Me.NudFecha.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudFecha.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFecha.Name = "NudFecha"
        Me.NudFecha.Size = New System.Drawing.Size(73, 27)
        Me.NudFecha.TabIndex = 17
        Me.NudFecha.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(3, 163)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(107, 22)
        Me.chkAll.TabIndex = 4
        Me.chkAll.Text = "Marcar todos"
        Me.chkAll.UseVisualStyleBackColor = False
        '
        'lsvLista
        '
        Me.lsvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvLista.CheckBoxes = True
        Me.lsvLista.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvLista.FullRowSelect = True
        Me.lsvLista.GridLines = True
        Me.lsvLista.HideSelection = False
        Me.lsvLista.Location = New System.Drawing.Point(1, 200)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(937, 294)
        Me.lsvLista.TabIndex = 2
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'lblRuta
        '
        Me.lblRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(-1, 569)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(604, 39)
        Me.lblRuta.TabIndex = 37
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbImportar, Me.tsbGuardar, Me.tsbProcesar, Me.tsbCancelar, Me.tsbreportes, Me.tsbExcel, Me.tsbDeleted})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(945, 54)
        Me.ToolStrip1.TabIndex = 36
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.recibos.My.Resources.Resources._1361007999_document_new
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(131, 51)
        Me.tsbNuevo.Text = "Cargar resumen banco"
        Me.tsbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbImportar
        '
        Me.tsbImportar.Enabled = False
        Me.tsbImportar.Image = Global.recibos.My.Resources.Resources._1361008137_export_excel
        Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportar.Name = "tsbImportar"
        Me.tsbImportar.Size = New System.Drawing.Size(99, 51)
        Me.tsbImportar.Text = "Importar archivo"
        Me.tsbImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbGuardar
        '
        Me.tsbGuardar.AutoSize = False
        Me.tsbGuardar.Enabled = False
        Me.tsbGuardar.Image = Global.recibos.My.Resources.Resources._1361008510_save_diskette_floppy_disk
        Me.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGuardar.Name = "tsbGuardar"
        Me.tsbGuardar.Size = New System.Drawing.Size(100, 51)
        Me.tsbGuardar.Text = "Conciliar archivo"
        Me.tsbGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbProcesar
        '
        Me.tsbProcesar.Enabled = False
        Me.tsbProcesar.Image = CType(resources.GetObject("tsbProcesar.Image"), System.Drawing.Image)
        Me.tsbProcesar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbProcesar.Name = "tsbProcesar"
        Me.tsbProcesar.Size = New System.Drawing.Size(98, 51)
        Me.tsbProcesar.Text = "Procesar archivo"
        Me.tsbProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbProcesar.Visible = False
        '
        'tsbCancelar
        '
        Me.tsbCancelar.AutoSize = False
        Me.tsbCancelar.Enabled = False
        Me.tsbCancelar.Image = Global.recibos.My.Resources.Resources._1361008659_cancel
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(90, 51)
        Me.tsbCancelar.Text = "Cancelar"
        Me.tsbCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbreportes
        '
        Me.tsbreportes.AutoSize = False
        Me.tsbreportes.Image = CType(resources.GetObject("tsbreportes.Image"), System.Drawing.Image)
        Me.tsbreportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbreportes.Name = "tsbreportes"
        Me.tsbreportes.Size = New System.Drawing.Size(90, 51)
        Me.tsbreportes.Text = "Reportes"
        Me.tsbreportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbExcel
        '
        Me.tsbExcel.Image = CType(resources.GetObject("tsbExcel.Image"), System.Drawing.Image)
        Me.tsbExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExcel.Name = "tsbExcel"
        Me.tsbExcel.Size = New System.Drawing.Size(83, 51)
        Me.tsbExcel.Text = "Exportar Excel"
        Me.tsbExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'pnlProgreso
        '
        Me.pnlProgreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlProgreso.Controls.Add(Me.Label2)
        Me.pnlProgreso.Controls.Add(Me.pgbProgreso)
        Me.pnlProgreso.Location = New System.Drawing.Point(248, 368)
        Me.pnlProgreso.Name = "pnlProgreso"
        Me.pnlProgreso.Size = New System.Drawing.Size(449, 84)
        Me.pnlProgreso.TabIndex = 40
        Me.pnlProgreso.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Procesando registros"
        '
        'pgbProgreso
        '
        Me.pgbProgreso.Location = New System.Drawing.Point(17, 12)
        Me.pgbProgreso.Name = "pgbProgreso"
        Me.pgbProgreso.Size = New System.Drawing.Size(413, 30)
        Me.pgbProgreso.TabIndex = 0
        '
        'tsbDeleted
        '
        Me.tsbDeleted.Image = Global.recibos.My.Resources.Resources.cubo_de_basura
        Me.tsbDeleted.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleted.Name = "tsbDeleted"
        Me.tsbDeleted.Size = New System.Drawing.Size(43, 51)
        Me.tsbDeleted.Text = "Borrar"
        Me.tsbDeleted.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbDeleted.Visible = False
        '
        'frmconcilia
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(945, 613)
        Me.Controls.Add(Me.pnlProgreso)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmconcilia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conciliación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Nudrango, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlProgreso.ResumeLayout(False)
        Me.pnlProgreso.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCerrar As Button
    Friend WithEvents pnlCatalogo As Panel
    Friend WithEvents cbobanco As ComboBox
    Friend WithEvents cboempresa As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Nudrango As NumericUpDown
    Friend WithEvents rdbrango As RadioButton
    Friend WithEvents rdbIguales As RadioButton
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents chkfecha As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents NudSaldo As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents NudAbono As NumericUpDown
    Friend WithEvents NudCargo As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents NudConcepto As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NudFecha As NumericUpDown
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents lsvLista As ListView
    Friend WithEvents lblRuta As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbNuevo As ToolStripButton
    Friend WithEvents tsbImportar As ToolStripButton
    Friend WithEvents tsbGuardar As ToolStripButton
    Friend WithEvents tsbProcesar As ToolStripButton
    Friend WithEvents tsbCancelar As ToolStripButton
    Friend WithEvents tsbreportes As ToolStripButton
    Friend WithEvents tsbExcel As ToolStripButton
    Friend WithEvents pnlProgreso As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents pgbProgreso As ProgressBar
    Friend WithEvents txtcomision As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtidempresa As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents tsbDeleted As System.Windows.Forms.ToolStripButton
End Class
