<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmverfacturascontrol
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.cmdexcel = New System.Windows.Forms.Button()
        Me.cboplaza = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkotras = New System.Windows.Forms.CheckBox()
        Me.chkintermediarias = New System.Windows.Forms.CheckBox()
        Me.chkpatronas = New System.Windows.Forms.CheckBox()
        Me.chktodas = New System.Windows.Forms.CheckBox()
        Me.pnlcolores = New System.Windows.Forms.Panel()
        Me.chkcolor = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbocolor = New System.Windows.Forms.ComboBox()
        Me.cmdminuta = New System.Windows.Forms.Button()
        Me.cmdgeneral = New System.Windows.Forms.Button()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.cmdjannet = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbgrupo = New System.Windows.Forms.RadioButton()
        Me.rdbtodasplazas = New System.Windows.Forms.RadioButton()
        Me.rdbplaza = New System.Windows.Forms.RadioButton()
        Me.rdbpendientes = New System.Windows.Forms.RadioButton()
        Me.rdbbuscar = New System.Windows.Forms.RadioButton()
        Me.rdbcliente = New System.Windows.Forms.RadioButton()
        Me.rdbfechas = New System.Windows.Forms.RadioButton()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboclientes = New System.Windows.Forms.ComboBox()
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.cboempresa = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.pnlCatalogo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlcolores.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.cmdexcel)
        Me.pnlCatalogo.Controls.Add(Me.cboplaza)
        Me.pnlCatalogo.Controls.Add(Me.Label2)
        Me.pnlCatalogo.Controls.Add(Me.Panel2)
        Me.pnlCatalogo.Controls.Add(Me.pnlcolores)
        Me.pnlCatalogo.Controls.Add(Me.cmdminuta)
        Me.pnlCatalogo.Controls.Add(Me.cmdgeneral)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechafin)
        Me.pnlCatalogo.Controls.Add(Me.cmdjannet)
        Me.pnlCatalogo.Controls.Add(Me.Panel1)
        Me.pnlCatalogo.Controls.Add(Me.lsvLista)
        Me.pnlCatalogo.Controls.Add(Me.cmdbuscar)
        Me.pnlCatalogo.Controls.Add(Me.Label10)
        Me.pnlCatalogo.Controls.Add(Me.cboclientes)
        Me.pnlCatalogo.Controls.Add(Me.txtbuscar)
        Me.pnlCatalogo.Controls.Add(Me.cboempresa)
        Me.pnlCatalogo.Controls.Add(Me.Label5)
        Me.pnlCatalogo.Controls.Add(Me.Label4)
        Me.pnlCatalogo.Controls.Add(Me.Label3)
        Me.pnlCatalogo.Controls.Add(Me.Label1)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechainicio)
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 5)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(982, 603)
        Me.pnlCatalogo.TabIndex = 22
        '
        'cmdexcel
        '
        Me.cmdexcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexcel.Location = New System.Drawing.Point(635, 199)
        Me.cmdexcel.Name = "cmdexcel"
        Me.cmdexcel.Size = New System.Drawing.Size(179, 29)
        Me.cmdexcel.TabIndex = 48
        Me.cmdexcel.Text = "Excel"
        Me.cmdexcel.UseVisualStyleBackColor = True
        '
        'cboplaza
        '
        Me.cboplaza.FormattingEnabled = True
        Me.cboplaza.Items.AddRange(New Object() {"Activa", "Cancelada"})
        Me.cboplaza.Location = New System.Drawing.Point(786, 150)
        Me.cboplaza.Name = "cboplaza"
        Me.cboplaza.Size = New System.Drawing.Size(186, 21)
        Me.cboplaza.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(782, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Plazas:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkotras)
        Me.Panel2.Controls.Add(Me.chkintermediarias)
        Me.Panel2.Controls.Add(Me.chkpatronas)
        Me.Panel2.Controls.Add(Me.chktodas)
        Me.Panel2.Location = New System.Drawing.Point(454, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(448, 29)
        Me.Panel2.TabIndex = 45
        '
        'chkotras
        '
        Me.chkotras.AutoSize = True
        Me.chkotras.BackColor = System.Drawing.Color.Transparent
        Me.chkotras.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkotras.Location = New System.Drawing.Point(377, 3)
        Me.chkotras.Name = "chkotras"
        Me.chkotras.Size = New System.Drawing.Size(60, 22)
        Me.chkotras.TabIndex = 7
        Me.chkotras.Text = "Otras"
        Me.chkotras.UseVisualStyleBackColor = False
        '
        'chkintermediarias
        '
        Me.chkintermediarias.AutoSize = True
        Me.chkintermediarias.BackColor = System.Drawing.Color.Transparent
        Me.chkintermediarias.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkintermediarias.Location = New System.Drawing.Point(250, 3)
        Me.chkintermediarias.Name = "chkintermediarias"
        Me.chkintermediarias.Size = New System.Drawing.Size(118, 22)
        Me.chkintermediarias.TabIndex = 6
        Me.chkintermediarias.Text = "Intermediarias"
        Me.chkintermediarias.UseVisualStyleBackColor = False
        '
        'chkpatronas
        '
        Me.chkpatronas.AutoSize = True
        Me.chkpatronas.BackColor = System.Drawing.Color.Transparent
        Me.chkpatronas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkpatronas.Location = New System.Drawing.Point(166, 3)
        Me.chkpatronas.Name = "chkpatronas"
        Me.chkpatronas.Size = New System.Drawing.Size(81, 22)
        Me.chkpatronas.TabIndex = 5
        Me.chkpatronas.Text = "Patronas"
        Me.chkpatronas.UseVisualStyleBackColor = False
        '
        'chktodas
        '
        Me.chktodas.AutoSize = True
        Me.chktodas.BackColor = System.Drawing.Color.Transparent
        Me.chktodas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktodas.Location = New System.Drawing.Point(15, 3)
        Me.chktodas.Name = "chktodas"
        Me.chktodas.Size = New System.Drawing.Size(145, 22)
        Me.chktodas.TabIndex = 4
        Me.chktodas.Text = "Todas las empresas"
        Me.chktodas.UseVisualStyleBackColor = False
        '
        'pnlcolores
        '
        Me.pnlcolores.Controls.Add(Me.chkcolor)
        Me.pnlcolores.Controls.Add(Me.Label17)
        Me.pnlcolores.Controls.Add(Me.cbocolor)
        Me.pnlcolores.Location = New System.Drawing.Point(248, 177)
        Me.pnlcolores.Name = "pnlcolores"
        Me.pnlcolores.Size = New System.Drawing.Size(381, 54)
        Me.pnlcolores.TabIndex = 44
        '
        'chkcolor
        '
        Me.chkcolor.AutoSize = True
        Me.chkcolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkcolor.Location = New System.Drawing.Point(3, 3)
        Me.chkcolor.Name = "chkcolor"
        Me.chkcolor.Size = New System.Drawing.Size(108, 19)
        Me.chkcolor.TabIndex = 48
        Me.chkcolor.Text = "Filtrar por color"
        Me.chkcolor.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(172, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(179, 31)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Amarillo-Pendiente, Verde-Pagado, Rojo-Cancelado"
        '
        'cbocolor
        '
        Me.cbocolor.FormattingEnabled = True
        Me.cbocolor.Items.AddRange(New Object() {"Ninguno", "Amarillo", "Verde", "Rojo"})
        Me.cbocolor.Location = New System.Drawing.Point(3, 24)
        Me.cbocolor.Name = "cbocolor"
        Me.cbocolor.Size = New System.Drawing.Size(167, 21)
        Me.cbocolor.TabIndex = 46
        '
        'cmdminuta
        '
        Me.cmdminuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdminuta.Location = New System.Drawing.Point(639, 238)
        Me.cmdminuta.Name = "cmdminuta"
        Me.cmdminuta.Size = New System.Drawing.Size(179, 29)
        Me.cmdminuta.TabIndex = 39
        Me.cmdminuta.Text = "Excel lupita"
        Me.cmdminuta.UseVisualStyleBackColor = True
        '
        'cmdgeneral
        '
        Me.cmdgeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdgeneral.Location = New System.Drawing.Point(445, 238)
        Me.cmdgeneral.Name = "cmdgeneral"
        Me.cmdgeneral.Size = New System.Drawing.Size(179, 29)
        Me.cmdgeneral.TabIndex = 38
        Me.cmdgeneral.Text = "Generar a excel"
        Me.cmdgeneral.UseVisualStyleBackColor = True
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(112, 154)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechafin.TabIndex = 36
        '
        'cmdjannet
        '
        Me.cmdjannet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdjannet.Location = New System.Drawing.Point(248, 238)
        Me.cmdjannet.Name = "cmdjannet"
        Me.cmdjannet.Size = New System.Drawing.Size(179, 29)
        Me.cmdjannet.TabIndex = 37
        Me.cmdjannet.Text = "Excel jannet"
        Me.cmdjannet.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbgrupo)
        Me.Panel1.Controls.Add(Me.rdbtodasplazas)
        Me.Panel1.Controls.Add(Me.rdbplaza)
        Me.Panel1.Controls.Add(Me.rdbpendientes)
        Me.Panel1.Controls.Add(Me.rdbbuscar)
        Me.Panel1.Controls.Add(Me.rdbcliente)
        Me.Panel1.Controls.Add(Me.rdbfechas)
        Me.Panel1.Location = New System.Drawing.Point(10, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(958, 73)
        Me.Panel1.TabIndex = 35
        '
        'rdbgrupo
        '
        Me.rdbgrupo.AutoSize = True
        Me.rdbgrupo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbgrupo.Location = New System.Drawing.Point(3, 34)
        Me.rdbgrupo.Name = "rdbgrupo"
        Me.rdbgrupo.Size = New System.Drawing.Size(86, 22)
        Me.rdbgrupo.TabIndex = 6
        Me.rdbgrupo.Text = "Por grupo"
        Me.rdbgrupo.UseVisualStyleBackColor = True
        '
        'rdbtodasplazas
        '
        Me.rdbtodasplazas.AutoSize = True
        Me.rdbtodasplazas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtodasplazas.Location = New System.Drawing.Point(793, 6)
        Me.rdbtodasplazas.Name = "rdbtodasplazas"
        Me.rdbtodasplazas.Size = New System.Drawing.Size(122, 22)
        Me.rdbtodasplazas.TabIndex = 5
        Me.rdbtodasplazas.Text = "Todas las plazas"
        Me.rdbtodasplazas.UseVisualStyleBackColor = True
        '
        'rdbplaza
        '
        Me.rdbplaza.AutoSize = True
        Me.rdbplaza.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbplaza.Location = New System.Drawing.Point(711, 6)
        Me.rdbplaza.Name = "rdbplaza"
        Me.rdbplaza.Size = New System.Drawing.Size(82, 22)
        Me.rdbplaza.TabIndex = 4
        Me.rdbplaza.Text = "Por plaza"
        Me.rdbplaza.UseVisualStyleBackColor = True
        '
        'rdbpendientes
        '
        Me.rdbpendientes.AutoSize = True
        Me.rdbpendientes.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbpendientes.Location = New System.Drawing.Point(304, 6)
        Me.rdbpendientes.Name = "rdbpendientes"
        Me.rdbpendientes.Size = New System.Drawing.Size(288, 22)
        Me.rdbpendientes.TabIndex = 3
        Me.rdbpendientes.Text = "Mostrar empresas con facturas pendientes"
        Me.rdbpendientes.UseVisualStyleBackColor = True
        '
        'rdbbuscar
        '
        Me.rdbbuscar.AutoSize = True
        Me.rdbbuscar.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbbuscar.Location = New System.Drawing.Point(597, 6)
        Me.rdbbuscar.Name = "rdbbuscar"
        Me.rdbbuscar.Size = New System.Drawing.Size(112, 22)
        Me.rdbbuscar.TabIndex = 2
        Me.rdbbuscar.Text = "Buscar factura"
        Me.rdbbuscar.UseVisualStyleBackColor = True
        '
        'rdbcliente
        '
        Me.rdbcliente.AutoSize = True
        Me.rdbcliente.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbcliente.Location = New System.Drawing.Point(156, 6)
        Me.rdbcliente.Name = "rdbcliente"
        Me.rdbcliente.Size = New System.Drawing.Size(147, 22)
        Me.rdbcliente.TabIndex = 1
        Me.rdbcliente.Text = "Facturas por cliente"
        Me.rdbcliente.UseVisualStyleBackColor = True
        '
        'rdbfechas
        '
        Me.rdbfechas.AutoSize = True
        Me.rdbfechas.Checked = True
        Me.rdbfechas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbfechas.Location = New System.Drawing.Point(4, 6)
        Me.rdbfechas.Name = "rdbfechas"
        Me.rdbfechas.Size = New System.Drawing.Size(147, 22)
        Me.rdbfechas.TabIndex = 0
        Me.rdbfechas.TabStop = True
        Me.rdbfechas.Text = "Por rango de fechas"
        Me.rdbfechas.UseVisualStyleBackColor = True
        '
        'lsvLista
        '
        Me.lsvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvLista.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvLista.FullRowSelect = True
        Me.lsvLista.GridLines = True
        Me.lsvLista.HideSelection = False
        Me.lsvLista.Location = New System.Drawing.Point(10, 273)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(958, 323)
        Me.lsvLista.TabIndex = 34
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.Location = New System.Drawing.Point(50, 238)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(179, 29)
        Me.cmdbuscar.TabIndex = 32
        Me.cmdbuscar.Text = "Realizar busqueda"
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(572, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 19)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Factura a buscar"
        '
        'cboclientes
        '
        Me.cboclientes.FormattingEnabled = True
        Me.cboclientes.Items.AddRange(New Object() {"Activa", "Cancelada"})
        Me.cboclientes.Location = New System.Drawing.Point(216, 151)
        Me.cboclientes.Name = "cboclientes"
        Me.cboclientes.Size = New System.Drawing.Size(354, 21)
        Me.cboclientes.TabIndex = 20
        '
        'txtbuscar
        '
        Me.txtbuscar.Location = New System.Drawing.Point(576, 151)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(200, 20)
        Me.txtbuscar.TabIndex = 19
        '
        'cboempresa
        '
        Me.cboempresa.FormattingEnabled = True
        Me.cboempresa.Location = New System.Drawing.Point(14, 24)
        Me.cboempresa.Name = "cboempresa"
        Me.cboempresa.Size = New System.Drawing.Size(434, 21)
        Me.cboempresa.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(212, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Clientes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(112, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fecha fin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Empresa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(10, 154)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechainicio.TabIndex = 5
        '
        'frmverfacturascontrol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 615)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmverfacturascontrol"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ver facturas"
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlcolores.ResumeLayout(False)
        Me.pnlcolores.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCatalogo As Panel
    Friend WithEvents lsvLista As ListView
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents cboclientes As ComboBox
    Friend WithEvents txtbuscar As TextBox
    Friend WithEvents cboempresa As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents chktodas As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdbpendientes As RadioButton
    Friend WithEvents rdbbuscar As RadioButton
    Friend WithEvents rdbcliente As RadioButton
    Friend WithEvents rdbfechas As RadioButton
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents cmdjannet As Button
    Friend WithEvents cmdgeneral As Button
    Friend WithEvents cmdminuta As Button
    Friend WithEvents pnlcolores As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents cbocolor As ComboBox
    Friend WithEvents chkcolor As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkotras As CheckBox
    Friend WithEvents chkintermediarias As CheckBox
    Friend WithEvents chkpatronas As CheckBox
    Friend WithEvents cboplaza As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents rdbplaza As RadioButton
    Friend WithEvents rdbtodasplazas As RadioButton
    Friend WithEvents rdbgrupo As RadioButton
    Friend WithEvents cmdexcel As Button
End Class
