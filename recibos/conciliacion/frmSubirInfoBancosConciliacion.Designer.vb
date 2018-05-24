<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubirInfoBancosConciliacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubirInfoBancosConciliacion))
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.cbobanco = New System.Windows.Forms.ComboBox()
        Me.cboempresa = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.pnlCatalogo.SuspendLayout()
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
        Me.cmdCerrar.Location = New System.Drawing.Point(829, 567)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.cmdCerrar.Size = New System.Drawing.Size(104, 43)
        Me.cmdCerrar.TabIndex = 43
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
        Me.pnlCatalogo.Controls.Add(Me.cbobanco)
        Me.pnlCatalogo.Controls.Add(Me.cboempresa)
        Me.pnlCatalogo.Controls.Add(Me.Label10)
        Me.pnlCatalogo.Controls.Add(Me.Label9)
        Me.pnlCatalogo.Controls.Add(Me.GroupBox1)
        Me.pnlCatalogo.Controls.Add(Me.chkAll)
        Me.pnlCatalogo.Controls.Add(Me.lsvLista)
        Me.pnlCatalogo.Enabled = False
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 60)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(945, 501)
        Me.pnlCatalogo.TabIndex = 42
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
        Me.GroupBox1.Location = New System.Drawing.Point(129, 90)
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
        Me.chkAll.Location = New System.Drawing.Point(3, 117)
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
        Me.lsvLista.Location = New System.Drawing.Point(1, 149)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(937, 345)
        Me.lsvLista.TabIndex = 2
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'lblRuta
        '
        Me.lblRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(-1, 571)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(604, 39)
        Me.lblRuta.TabIndex = 41
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGuardar, Me.tsbImportar, Me.tsbProcesar, Me.tsbCancelar, Me.tsbreportes, Me.tsbExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(945, 54)
        Me.ToolStrip1.TabIndex = 40
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
        Me.tsbImportar.Visible = False
        '
        'tsbGuardar
        '
        Me.tsbGuardar.AutoSize = False
        Me.tsbGuardar.Enabled = False
        Me.tsbGuardar.Image = Global.recibos.My.Resources.Resources._1361008510_save_diskette_floppy_disk
        Me.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGuardar.Name = "tsbGuardar"
        Me.tsbGuardar.Size = New System.Drawing.Size(100, 51)
        Me.tsbGuardar.Text = "Guardar datos"
        Me.tsbGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbGuardar.ToolTipText = "Guardar datos"
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
        Me.tsbreportes.Visible = False
        '
        'tsbExcel
        '
        Me.tsbExcel.Image = CType(resources.GetObject("tsbExcel.Image"), System.Drawing.Image)
        Me.tsbExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExcel.Name = "tsbExcel"
        Me.tsbExcel.Size = New System.Drawing.Size(83, 51)
        Me.tsbExcel.Text = "Exportar Excel"
        Me.tsbExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbExcel.Visible = False
        '
        'pnlProgreso
        '
        Me.pnlProgreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlProgreso.Controls.Add(Me.Label2)
        Me.pnlProgreso.Controls.Add(Me.pgbProgreso)
        Me.pnlProgreso.Location = New System.Drawing.Point(248, 320)
        Me.pnlProgreso.Name = "pnlProgreso"
        Me.pnlProgreso.Size = New System.Drawing.Size(449, 84)
        Me.pnlProgreso.TabIndex = 44
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
        'frmSubirInfoBancosConciliacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(945, 613)
        Me.Controls.Add(Me.pnlProgreso)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSubirInfoBancosConciliacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subir Información de bancos para conciliar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
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
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlCatalogo As System.Windows.Forms.Panel
    Friend WithEvents cbobanco As System.Windows.Forms.ComboBox
    Friend WithEvents cboempresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NudSaldo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NudAbono As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudCargo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NudConcepto As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NudFecha As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents lsvLista As System.Windows.Forms.ListView
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbProcesar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbreportes As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlProgreso As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pgbProgreso As System.Windows.Forms.ProgressBar
End Class
