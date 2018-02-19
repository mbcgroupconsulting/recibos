<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecibosSLupita
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecibosSLupita))
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtmm = New System.Windows.Forms.RadioButton()
        Me.rbalimentos = New System.Windows.Forms.RadioButton()
        Me.rbcroc = New System.Windows.Forms.RadioButton()
        Me.rbctm = New System.Windows.Forms.RadioButton()
        Me.rbctmlogo = New System.Windows.Forms.RadioButton()
        Me.NudColumnaC = New System.Windows.Forms.NumericUpDown()
        Me.NudColumnaN = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NudFilaF = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NudFilaI = New System.Windows.Forms.NumericUpDown()
        Me.txtlugar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tsbProcesar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.pnlProgreso = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar()
        Me.pnlCatalogo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudColumnaC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudColumnaN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFilaF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudFilaI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlProgreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.GroupBox1)
        Me.pnlCatalogo.Controls.Add(Me.NudColumnaC)
        Me.pnlCatalogo.Controls.Add(Me.NudColumnaN)
        Me.pnlCatalogo.Controls.Add(Me.Label7)
        Me.pnlCatalogo.Controls.Add(Me.Label6)
        Me.pnlCatalogo.Controls.Add(Me.NudFilaF)
        Me.pnlCatalogo.Controls.Add(Me.Label5)
        Me.pnlCatalogo.Controls.Add(Me.Label4)
        Me.pnlCatalogo.Controls.Add(Me.NudFilaI)
        Me.pnlCatalogo.Controls.Add(Me.txtlugar)
        Me.pnlCatalogo.Controls.Add(Me.Label3)
        Me.pnlCatalogo.Controls.Add(Me.Label1)
        Me.pnlCatalogo.Controls.Add(Me.dtpfecha)
        Me.pnlCatalogo.Controls.Add(Me.chkAll)
        Me.pnlCatalogo.Controls.Add(Me.lsvLista)
        Me.pnlCatalogo.Enabled = False
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 51)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(843, 431)
        Me.pnlCatalogo.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtmm)
        Me.GroupBox1.Controls.Add(Me.rbalimentos)
        Me.GroupBox1.Controls.Add(Me.rbcroc)
        Me.GroupBox1.Controls.Add(Me.rbctm)
        Me.GroupBox1.Controls.Add(Me.rbctmlogo)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(756, 38)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de sindicato y formato"
        '
        'rbtmm
        '
        Me.rbtmm.AutoSize = True
        Me.rbtmm.Location = New System.Drawing.Point(487, 15)
        Me.rbtmm.Name = "rbtmm"
        Me.rbtmm.Size = New System.Drawing.Size(50, 17)
        Me.rbtmm.TabIndex = 4
        Me.rbtmm.Text = "TMM"
        Me.rbtmm.UseVisualStyleBackColor = True
        '
        'rbalimentos
        '
        Me.rbalimentos.AutoSize = True
        Me.rbalimentos.Location = New System.Drawing.Point(279, 15)
        Me.rbalimentos.Name = "rbalimentos"
        Me.rbalimentos.Size = New System.Drawing.Size(95, 17)
        Me.rbalimentos.TabIndex = 3
        Me.rbalimentos.Text = "CTM alimentos"
        Me.rbalimentos.UseVisualStyleBackColor = True
        '
        'rbcroc
        '
        Me.rbcroc.AutoSize = True
        Me.rbcroc.Location = New System.Drawing.Point(405, 15)
        Me.rbcroc.Name = "rbcroc"
        Me.rbcroc.Size = New System.Drawing.Size(55, 17)
        Me.rbcroc.TabIndex = 2
        Me.rbcroc.Text = "CROC"
        Me.rbcroc.UseVisualStyleBackColor = True
        '
        'rbctm
        '
        Me.rbctm.AutoSize = True
        Me.rbctm.Location = New System.Drawing.Point(160, 15)
        Me.rbctm.Name = "rbctm"
        Me.rbctm.Size = New System.Drawing.Size(87, 17)
        Me.rbctm.TabIndex = 1
        Me.rbctm.Text = "CTM sin logo"
        Me.rbctm.UseVisualStyleBackColor = True
        '
        'rbctmlogo
        '
        Me.rbctmlogo.AutoSize = True
        Me.rbctmlogo.Checked = True
        Me.rbctmlogo.Location = New System.Drawing.Point(39, 15)
        Me.rbctmlogo.Name = "rbctmlogo"
        Me.rbctmlogo.Size = New System.Drawing.Size(93, 17)
        Me.rbctmlogo.TabIndex = 0
        Me.rbctmlogo.TabStop = True
        Me.rbctmlogo.Text = "CTM Con logo"
        Me.rbctmlogo.UseVisualStyleBackColor = True
        '
        'NudColumnaC
        '
        Me.NudColumnaC.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudColumnaC.Location = New System.Drawing.Point(717, 82)
        Me.NudColumnaC.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NudColumnaC.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudColumnaC.Name = "NudColumnaC"
        Me.NudColumnaC.Size = New System.Drawing.Size(45, 27)
        Me.NudColumnaC.TabIndex = 16
        Me.NudColumnaC.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudColumnaN
        '
        Me.NudColumnaN.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudColumnaN.Location = New System.Drawing.Point(539, 82)
        Me.NudColumnaN.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NudColumnaN.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudColumnaN.Name = "NudColumnaN"
        Me.NudColumnaN.Size = New System.Drawing.Size(46, 27)
        Me.NudColumnaN.TabIndex = 15
        Me.NudColumnaN.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(586, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Columna cantidad:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(418, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Columna nombre:"
        '
        'NudFilaF
        '
        Me.NudFilaF.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFilaF.Location = New System.Drawing.Point(345, 82)
        Me.NudFilaF.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudFilaF.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFilaF.Name = "NudFilaF"
        Me.NudFilaF.Size = New System.Drawing.Size(72, 27)
        Me.NudFilaF.TabIndex = 12
        Me.NudFilaF.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(277, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fila Final:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(122, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fila Inicial:"
        '
        'NudFilaI
        '
        Me.NudFilaI.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFilaI.Location = New System.Drawing.Point(200, 82)
        Me.NudFilaI.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudFilaI.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFilaI.Name = "NudFilaI"
        Me.NudFilaI.Size = New System.Drawing.Size(73, 27)
        Me.NudFilaI.TabIndex = 9
        Me.NudFilaI.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtlugar
        '
        Me.txtlugar.Location = New System.Drawing.Point(140, 11)
        Me.txtlugar.Name = "txtlugar"
        Me.txtlugar.Size = New System.Drawing.Size(331, 20)
        Me.txtlugar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(-3, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Lugar de expedicion:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(474, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fecha del recibo:"
        '
        'dtpfecha
        '
        Me.dtpfecha.Location = New System.Drawing.Point(595, 11)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(202, 20)
        Me.dtpfecha.TabIndex = 5
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(3, 83)
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
        Me.lsvLista.Location = New System.Drawing.Point(1, 110)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(835, 314)
        Me.lsvLista.TabIndex = 2
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbImportar, Me.tsbGuardar, Me.tsbProcesar, Me.tsbCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(843, 54)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.recibos.My.Resources.Resources._1361007999_document_new
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(102, 51)
        Me.tsbNuevo.Text = "Agregar catálogo"
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
        Me.tsbGuardar.Size = New System.Drawing.Size(90, 51)
        Me.tsbGuardar.Text = "Generar recibos"
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
        'lblRuta
        '
        Me.lblRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(4, 489)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(604, 39)
        Me.lblRuta.TabIndex = 23
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(736, 486)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.cmdCerrar.Size = New System.Drawing.Size(104, 43)
        Me.cmdCerrar.TabIndex = 22
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'pnlProgreso
        '
        Me.pnlProgreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlProgreso.Controls.Add(Me.Label2)
        Me.pnlProgreso.Controls.Add(Me.pgbProgreso)
        Me.pnlProgreso.Location = New System.Drawing.Point(197, 224)
        Me.pnlProgreso.Name = "pnlProgreso"
        Me.pnlProgreso.Size = New System.Drawing.Size(449, 84)
        Me.pnlProgreso.TabIndex = 24
        Me.pnlProgreso.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Procesando articulos"
        '
        'pgbProgreso
        '
        Me.pgbProgreso.Location = New System.Drawing.Point(17, 12)
        Me.pgbProgreso.Name = "pgbProgreso"
        Me.pgbProgreso.Size = New System.Drawing.Size(413, 30)
        Me.pgbProgreso.TabIndex = 0
        '
        'frmRecibosSLupita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 533)
        Me.Controls.Add(Me.pnlProgreso)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Name = "frmRecibosSLupita"
        Me.Text = "Generar recibos sindicato lupita"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudColumnaC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudColumnaN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFilaF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudFilaI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlProgreso.ResumeLayout(False)
        Me.pnlProgreso.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlCatalogo As System.Windows.Forms.Panel
    Friend WithEvents txtlugar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents lsvLista As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbProcesar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlProgreso As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pgbProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NudFilaI As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudFilaF As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudColumnaC As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudColumnaN As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbcroc As System.Windows.Forms.RadioButton
    Friend WithEvents rbctm As System.Windows.Forms.RadioButton
    Friend WithEvents rbctmlogo As System.Windows.Forms.RadioButton
    Friend WithEvents rbalimentos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtmm As System.Windows.Forms.RadioButton
End Class
