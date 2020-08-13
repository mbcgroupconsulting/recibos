<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcontpaqnominas3
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcontpaqnominas3))
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.pnlProgreso = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar()
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.btnReporteExcel = New System.Windows.Forms.Button()
        Me.cmdBorrar = New System.Windows.Forms.Button()
        Me.cmdGuardarSueldo = New System.Windows.Forms.Button()
        Me.chkAguinaldo = New System.Windows.Forms.CheckBox()
        Me.chkgrupo = New System.Windows.Forms.CheckBox()
        Me.chkinter = New System.Windows.Forms.CheckBox()
        Me.cbobancos = New System.Windows.Forms.ComboBox()
        Me.chkSindicato = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.cmdreiniciar = New System.Windows.Forms.Button()
        Me.cmdincidencias = New System.Windows.Forms.Button()
        Me.cmdexcel = New System.Windows.Forms.Button()
        Me.cmdlayouts = New System.Windows.Forms.Button()
        Me.cmdreciboss = New System.Windows.Forms.Button()
        Me.cmdguardarfinal = New System.Windows.Forms.Button()
        Me.cmdguardarnomina = New System.Windows.Forms.Button()
        Me.cmdcalcular = New System.Windows.Forms.Button()
        Me.dtgDatos = New System.Windows.Forms.DataGridView()
        Me.cmdverdatos = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboperiodo = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbDatos = New System.Windows.Forms.ToolStripButton()
        Me.tsbEmpleados = New System.Windows.Forms.ToolStripButton()
        Me.tsbPeriodos = New System.Windows.Forms.ToolStripButton()
        Me.tsbpuestos = New System.Windows.Forms.ToolStripButton()
        Me.tsbdeptos = New System.Windows.Forms.ToolStripButton()
        Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
        Me.tsbLayout = New System.Windows.Forms.ToolStripButton()
        Me.tsbIEmpleados = New System.Windows.Forms.ToolStripButton()
        Me.tsbAguinaldo = New System.Windows.Forms.ToolStripButton()
        Me.tsbCliente = New System.Windows.Forms.ToolStripButton()
        Me.tsbEmpresa = New System.Windows.Forms.ToolStripButton()
        Me.tsbExportarExcelEmpleado = New System.Windows.Forms.ToolStripButton()
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Igualar0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesactivarIgualarA0ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlProgreso.SuspendLayout()
        Me.pnlCatalogo.SuspendLayout()
        CType(Me.dtgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.cmenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(14, 509)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(65, 19)
        Me.lblEmpresa.TabIndex = 37
        Me.lblEmpresa.Text = "empresa"
        '
        'lblCliente
        '
        Me.lblCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(12, 484)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(53, 19)
        Me.lblCliente.TabIndex = 36
        Me.lblCliente.Text = "cliente"
        '
        'pnlProgreso
        '
        Me.pnlProgreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlProgreso.Controls.Add(Me.Label2)
        Me.pnlProgreso.Controls.Add(Me.pgbProgreso)
        Me.pnlProgreso.Location = New System.Drawing.Point(524, 253)
        Me.pnlProgreso.Name = "pnlProgreso"
        Me.pnlProgreso.Size = New System.Drawing.Size(449, 84)
        Me.pnlProgreso.TabIndex = 35
        Me.pnlProgreso.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Procesando recibos"
        '
        'pgbProgreso
        '
        Me.pgbProgreso.Location = New System.Drawing.Point(17, 12)
        Me.pgbProgreso.Name = "pgbProgreso"
        Me.pgbProgreso.Size = New System.Drawing.Size(413, 30)
        Me.pgbProgreso.TabIndex = 0
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.btnReporteExcel)
        Me.pnlCatalogo.Controls.Add(Me.cmdBorrar)
        Me.pnlCatalogo.Controls.Add(Me.cmdGuardarSueldo)
        Me.pnlCatalogo.Controls.Add(Me.chkAguinaldo)
        Me.pnlCatalogo.Controls.Add(Me.chkgrupo)
        Me.pnlCatalogo.Controls.Add(Me.chkinter)
        Me.pnlCatalogo.Controls.Add(Me.cbobancos)
        Me.pnlCatalogo.Controls.Add(Me.chkSindicato)
        Me.pnlCatalogo.Controls.Add(Me.chkAll)
        Me.pnlCatalogo.Controls.Add(Me.cmdreiniciar)
        Me.pnlCatalogo.Controls.Add(Me.cmdincidencias)
        Me.pnlCatalogo.Controls.Add(Me.cmdexcel)
        Me.pnlCatalogo.Controls.Add(Me.cmdlayouts)
        Me.pnlCatalogo.Controls.Add(Me.cmdreciboss)
        Me.pnlCatalogo.Controls.Add(Me.cmdguardarfinal)
        Me.pnlCatalogo.Controls.Add(Me.cmdguardarnomina)
        Me.pnlCatalogo.Controls.Add(Me.cmdcalcular)
        Me.pnlCatalogo.Controls.Add(Me.dtgDatos)
        Me.pnlCatalogo.Controls.Add(Me.cmdverdatos)
        Me.pnlCatalogo.Controls.Add(Me.Label1)
        Me.pnlCatalogo.Controls.Add(Me.cboperiodo)
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 80)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(1497, 390)
        Me.pnlCatalogo.TabIndex = 34
        '
        'btnReporteExcel
        '
        Me.btnReporteExcel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporteExcel.Location = New System.Drawing.Point(956, 33)
        Me.btnReporteExcel.Name = "btnReporteExcel"
        Me.btnReporteExcel.Size = New System.Drawing.Size(103, 28)
        Me.btnReporteExcel.TabIndex = 23
        Me.btnReporteExcel.Text = "Reporte Excel"
        Me.btnReporteExcel.UseVisualStyleBackColor = True
        '
        'cmdBorrar
        '
        Me.cmdBorrar.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBorrar.Location = New System.Drawing.Point(1243, 4)
        Me.cmdBorrar.Name = "cmdBorrar"
        Me.cmdBorrar.Size = New System.Drawing.Size(111, 27)
        Me.cmdBorrar.TabIndex = 22
        Me.cmdBorrar.Text = "Borrar Nomina"
        Me.cmdBorrar.UseVisualStyleBackColor = True
        '
        'cmdGuardarSueldo
        '
        Me.cmdGuardarSueldo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarSueldo.Location = New System.Drawing.Point(482, 3)
        Me.cmdGuardarSueldo.Name = "cmdGuardarSueldo"
        Me.cmdGuardarSueldo.Size = New System.Drawing.Size(132, 27)
        Me.cmdGuardarSueldo.TabIndex = 21
        Me.cmdGuardarSueldo.Text = "Guardar Sueldo Ord."
        Me.cmdGuardarSueldo.UseVisualStyleBackColor = True
        '
        'chkAguinaldo
        '
        Me.chkAguinaldo.AutoSize = True
        Me.chkAguinaldo.BackColor = System.Drawing.Color.Transparent
        Me.chkAguinaldo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAguinaldo.Location = New System.Drawing.Point(212, 36)
        Me.chkAguinaldo.Name = "chkAguinaldo"
        Me.chkAguinaldo.Size = New System.Drawing.Size(120, 22)
        Me.chkAguinaldo.TabIndex = 20
        Me.chkAguinaldo.Text = "Solo Aguinaldo"
        Me.chkAguinaldo.UseVisualStyleBackColor = False
        '
        'chkgrupo
        '
        Me.chkgrupo.AutoSize = True
        Me.chkgrupo.BackColor = System.Drawing.Color.Transparent
        Me.chkgrupo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkgrupo.Location = New System.Drawing.Point(871, 36)
        Me.chkgrupo.Name = "chkgrupo"
        Me.chkgrupo.Size = New System.Drawing.Size(65, 22)
        Me.chkgrupo.TabIndex = 19
        Me.chkgrupo.Text = "Grupo"
        Me.chkgrupo.UseVisualStyleBackColor = False
        '
        'chkinter
        '
        Me.chkinter.AutoSize = True
        Me.chkinter.BackColor = System.Drawing.Color.Transparent
        Me.chkinter.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkinter.Location = New System.Drawing.Point(433, 37)
        Me.chkinter.Name = "chkinter"
        Me.chkinter.Size = New System.Drawing.Size(110, 22)
        Me.chkinter.TabIndex = 18
        Me.chkinter.Text = "Interbancario"
        Me.chkinter.UseVisualStyleBackColor = False
        '
        'cbobancos
        '
        Me.cbobancos.FormattingEnabled = True
        Me.cbobancos.Location = New System.Drawing.Point(541, 33)
        Me.cbobancos.Name = "cbobancos"
        Me.cbobancos.Size = New System.Drawing.Size(252, 27)
        Me.cbobancos.TabIndex = 17
        '
        'chkSindicato
        '
        Me.chkSindicato.AutoSize = True
        Me.chkSindicato.BackColor = System.Drawing.Color.Transparent
        Me.chkSindicato.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSindicato.Location = New System.Drawing.Point(343, 37)
        Me.chkSindicato.Name = "chkSindicato"
        Me.chkSindicato.Size = New System.Drawing.Size(84, 22)
        Me.chkSindicato.TabIndex = 16
        Me.chkSindicato.Text = "Sindicato"
        Me.chkSindicato.UseVisualStyleBackColor = False
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(59, 36)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(107, 22)
        Me.chkAll.TabIndex = 15
        Me.chkAll.Text = "Marcar todos"
        Me.chkAll.UseVisualStyleBackColor = False
        '
        'cmdreiniciar
        '
        Me.cmdreiniciar.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreiniciar.Location = New System.Drawing.Point(1126, 3)
        Me.cmdreiniciar.Name = "cmdreiniciar"
        Me.cmdreiniciar.Size = New System.Drawing.Size(111, 27)
        Me.cmdreiniciar.TabIndex = 14
        Me.cmdreiniciar.Text = "Reiniciar Nomina"
        Me.cmdreiniciar.UseVisualStyleBackColor = True
        '
        'cmdincidencias
        '
        Me.cmdincidencias.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdincidencias.Location = New System.Drawing.Point(1009, 3)
        Me.cmdincidencias.Name = "cmdincidencias"
        Me.cmdincidencias.Size = New System.Drawing.Size(111, 27)
        Me.cmdincidencias.TabIndex = 13
        Me.cmdincidencias.Text = "Excel Incidencias"
        Me.cmdincidencias.UseVisualStyleBackColor = True
        '
        'cmdexcel
        '
        Me.cmdexcel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexcel.Location = New System.Drawing.Point(910, 3)
        Me.cmdexcel.Name = "cmdexcel"
        Me.cmdexcel.Size = New System.Drawing.Size(93, 27)
        Me.cmdexcel.TabIndex = 12
        Me.cmdexcel.Text = "Enviar a Excel"
        Me.cmdexcel.UseVisualStyleBackColor = True
        '
        'cmdlayouts
        '
        Me.cmdlayouts.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlayouts.Location = New System.Drawing.Point(799, 34)
        Me.cmdlayouts.Name = "cmdlayouts"
        Me.cmdlayouts.Size = New System.Drawing.Size(66, 27)
        Me.cmdlayouts.TabIndex = 11
        Me.cmdlayouts.Text = "Layout"
        Me.cmdlayouts.UseVisualStyleBackColor = True
        '
        'cmdreciboss
        '
        Me.cmdreciboss.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreciboss.Location = New System.Drawing.Point(784, 3)
        Me.cmdreciboss.Name = "cmdreciboss"
        Me.cmdreciboss.Size = New System.Drawing.Size(122, 27)
        Me.cmdreciboss.TabIndex = 10
        Me.cmdreciboss.Text = "Recibos Sindicato"
        Me.cmdreciboss.UseVisualStyleBackColor = True
        '
        'cmdguardarfinal
        '
        Me.cmdguardarfinal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardarfinal.Location = New System.Drawing.Point(687, 3)
        Me.cmdguardarfinal.Name = "cmdguardarfinal"
        Me.cmdguardarfinal.Size = New System.Drawing.Size(92, 27)
        Me.cmdguardarfinal.TabIndex = 9
        Me.cmdguardarfinal.Text = "Guardar Final"
        Me.cmdguardarfinal.UseVisualStyleBackColor = True
        '
        'cmdguardarnomina
        '
        Me.cmdguardarnomina.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardarnomina.Location = New System.Drawing.Point(620, 3)
        Me.cmdguardarnomina.Name = "cmdguardarnomina"
        Me.cmdguardarnomina.Size = New System.Drawing.Size(63, 27)
        Me.cmdguardarnomina.TabIndex = 8
        Me.cmdguardarnomina.Text = "Guardar"
        Me.cmdguardarnomina.UseVisualStyleBackColor = True
        '
        'cmdcalcular
        '
        Me.cmdcalcular.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcalcular.Location = New System.Drawing.Point(413, 3)
        Me.cmdcalcular.Name = "cmdcalcular"
        Me.cmdcalcular.Size = New System.Drawing.Size(63, 27)
        Me.cmdcalcular.TabIndex = 7
        Me.cmdcalcular.Text = "Calcular"
        Me.cmdcalcular.UseVisualStyleBackColor = True
        '
        'dtgDatos
        '
        Me.dtgDatos.AllowUserToAddRows = False
        Me.dtgDatos.AllowUserToDeleteRows = False
        Me.dtgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDatos.Location = New System.Drawing.Point(1, 65)
        Me.dtgDatos.Name = "dtgDatos"
        Me.dtgDatos.Size = New System.Drawing.Size(1489, 307)
        Me.dtgDatos.TabIndex = 6
        '
        'cmdverdatos
        '
        Me.cmdverdatos.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdverdatos.Location = New System.Drawing.Point(338, 3)
        Me.cmdverdatos.Name = "cmdverdatos"
        Me.cmdverdatos.Size = New System.Drawing.Size(71, 27)
        Me.cmdverdatos.TabIndex = 5
        Me.cmdverdatos.Text = "Ver datos"
        Me.cmdverdatos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Periodo:"
        '
        'cboperiodo
        '
        Me.cboperiodo.FormattingEnabled = True
        Me.cboperiodo.Location = New System.Drawing.Point(80, 3)
        Me.cboperiodo.Name = "cboperiodo"
        Me.cboperiodo.Size = New System.Drawing.Size(252, 27)
        Me.cboperiodo.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDatos, Me.tsbEmpleados, Me.tsbPeriodos, Me.tsbpuestos, Me.tsbdeptos, Me.tsbImportar, Me.tsbLayout, Me.tsbIEmpleados, Me.tsbAguinaldo, Me.tsbCliente, Me.tsbEmpresa, Me.tsbExportarExcelEmpleado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1497, 54)
        Me.ToolStrip1.TabIndex = 33
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbDatos
        '
        Me.tsbDatos.Image = CType(resources.GetObject("tsbDatos.Image"), System.Drawing.Image)
        Me.tsbDatos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDatos.Name = "tsbDatos"
        Me.tsbDatos.Size = New System.Drawing.Size(90, 51)
        Me.tsbDatos.Text = "Importar Datos"
        Me.tsbDatos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbEmpleados
        '
        Me.tsbEmpleados.Image = CType(resources.GetObject("tsbEmpleados.Image"), System.Drawing.Image)
        Me.tsbEmpleados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEmpleados.Name = "tsbEmpleados"
        Me.tsbEmpleados.Size = New System.Drawing.Size(118, 51)
        Me.tsbEmpleados.Text = "Importar Empleados"
        Me.tsbEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbPeriodos
        '
        Me.tsbPeriodos.Image = CType(resources.GetObject("tsbPeriodos.Image"), System.Drawing.Image)
        Me.tsbPeriodos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPeriodos.Name = "tsbPeriodos"
        Me.tsbPeriodos.Size = New System.Drawing.Size(106, 51)
        Me.tsbPeriodos.Text = "Importar Períodos"
        Me.tsbPeriodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbpuestos
        '
        Me.tsbpuestos.Image = CType(resources.GetObject("tsbpuestos.Image"), System.Drawing.Image)
        Me.tsbpuestos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbpuestos.Name = "tsbpuestos"
        Me.tsbpuestos.Size = New System.Drawing.Size(101, 51)
        Me.tsbpuestos.Text = "Importar Puestos"
        Me.tsbpuestos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbdeptos
        '
        Me.tsbdeptos.Image = CType(resources.GetObject("tsbdeptos.Image"), System.Drawing.Image)
        Me.tsbdeptos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbdeptos.Name = "tsbdeptos"
        Me.tsbdeptos.Size = New System.Drawing.Size(96, 51)
        Me.tsbdeptos.Text = "Importar deptos"
        Me.tsbdeptos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbImportar
        '
        Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
        Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportar.Name = "tsbImportar"
        Me.tsbImportar.Size = New System.Drawing.Size(70, 51)
        Me.tsbImportar.Text = "Incidencias"
        Me.tsbImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbImportar.ToolTipText = "Importar incidencias"
        '
        'tsbLayout
        '
        Me.tsbLayout.AutoSize = False
        Me.tsbLayout.Image = CType(resources.GetObject("tsbLayout.Image"), System.Drawing.Image)
        Me.tsbLayout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLayout.Name = "tsbLayout"
        Me.tsbLayout.Size = New System.Drawing.Size(90, 51)
        Me.tsbLayout.Text = "Layouts"
        Me.tsbLayout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbLayout.Visible = False
        '
        'tsbIEmpleados
        '
        Me.tsbIEmpleados.Image = CType(resources.GetObject("tsbIEmpleados.Image"), System.Drawing.Image)
        Me.tsbIEmpleados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbIEmpleados.Name = "tsbIEmpleados"
        Me.tsbIEmpleados.Size = New System.Drawing.Size(69, 51)
        Me.tsbIEmpleados.Text = "Empleados"
        Me.tsbIEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbAguinaldo
        '
        Me.tsbAguinaldo.Image = CType(resources.GetObject("tsbAguinaldo.Image"), System.Drawing.Image)
        Me.tsbAguinaldo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAguinaldo.Name = "tsbAguinaldo"
        Me.tsbAguinaldo.Size = New System.Drawing.Size(66, 51)
        Me.tsbAguinaldo.Text = "Aguinaldo"
        Me.tsbAguinaldo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbCliente
        '
        Me.tsbCliente.Image = CType(resources.GetObject("tsbCliente.Image"), System.Drawing.Image)
        Me.tsbCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCliente.Name = "tsbCliente"
        Me.tsbCliente.Size = New System.Drawing.Size(99, 51)
        Me.tsbCliente.Text = "Cliente asignado"
        Me.tsbCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbEmpresa
        '
        Me.tsbEmpresa.Image = CType(resources.GetObject("tsbEmpresa.Image"), System.Drawing.Image)
        Me.tsbEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEmpresa.Name = "tsbEmpresa"
        Me.tsbEmpresa.Size = New System.Drawing.Size(106, 51)
        Me.tsbEmpresa.Text = "Empresa asignada"
        Me.tsbEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbExportarExcelEmpleado
        '
        Me.tsbExportarExcelEmpleado.Image = CType(resources.GetObject("tsbExportarExcelEmpleado.Image"), System.Drawing.Image)
        Me.tsbExportarExcelEmpleado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportarExcelEmpleado.Name = "tsbExportarExcelEmpleado"
        Me.tsbExportarExcelEmpleado.Size = New System.Drawing.Size(116, 51)
        Me.tsbExportarExcelEmpleado.Text = "Exportar Empleados"
        Me.tsbExportarExcelEmpleado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Igualar0, Me.DesactivarIgualarA0ToolStripMenuItem})
        Me.cmenu.Name = "cmenu"
        Me.cmenu.Size = New System.Drawing.Size(186, 48)
        '
        'Igualar0
        '
        Me.Igualar0.Name = "Igualar0"
        Me.Igualar0.Size = New System.Drawing.Size(185, 22)
        Me.Igualar0.Text = "Igualar a 0"
        '
        'DesactivarIgualarA0ToolStripMenuItem
        '
        Me.DesactivarIgualarA0ToolStripMenuItem.Name = "DesactivarIgualarA0ToolStripMenuItem"
        Me.DesactivarIgualarA0ToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.DesactivarIgualarA0ToolStripMenuItem.Text = "Desactivar igualar a 0"
        '
        'frmcontpaqnominas3
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1497, 533)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.pnlProgreso)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmcontpaqnominas3"
        Me.Text = "Version simplificado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlProgreso.ResumeLayout(False)
        Me.pnlProgreso.PerformLayout()
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        CType(Me.dtgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents pnlProgreso As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pgbProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents pnlCatalogo As System.Windows.Forms.Panel
    Friend WithEvents cmdBorrar As System.Windows.Forms.Button
    Friend WithEvents cmdGuardarSueldo As System.Windows.Forms.Button
    Friend WithEvents chkAguinaldo As System.Windows.Forms.CheckBox
    Friend WithEvents chkgrupo As System.Windows.Forms.CheckBox
    Friend WithEvents chkinter As System.Windows.Forms.CheckBox
    Friend WithEvents cbobancos As System.Windows.Forms.ComboBox
    Friend WithEvents chkSindicato As System.Windows.Forms.CheckBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmdreiniciar As System.Windows.Forms.Button
    Friend WithEvents cmdincidencias As System.Windows.Forms.Button
    Friend WithEvents cmdexcel As System.Windows.Forms.Button
    Friend WithEvents cmdlayouts As System.Windows.Forms.Button
    Friend WithEvents cmdreciboss As System.Windows.Forms.Button
    Friend WithEvents cmdguardarfinal As System.Windows.Forms.Button
    Friend WithEvents cmdguardarnomina As System.Windows.Forms.Button
    Friend WithEvents cmdcalcular As System.Windows.Forms.Button
    Friend WithEvents dtgDatos As System.Windows.Forms.DataGridView
    Friend WithEvents cmdverdatos As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboperiodo As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbDatos As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEmpleados As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPeriodos As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbpuestos As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbdeptos As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbLayout As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbIEmpleados As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAguinaldo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEmpresa As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExportarExcelEmpleado As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Igualar0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesactivarIgualarA0ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnReporteExcel As System.Windows.Forms.Button
End Class
