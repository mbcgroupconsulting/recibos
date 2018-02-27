<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnexarFacturaConciliacion
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
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.cmdagregar = New System.Windows.Forms.Button()
        Me.chknominas = New System.Windows.Forms.CheckBox()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.chktodas = New System.Windows.Forms.CheckBox()
        Me.pnlCatalogo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.cmdagregar)
        Me.pnlCatalogo.Controls.Add(Me.chknominas)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechafin)
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
        Me.pnlCatalogo.Controls.Add(Me.chktodas)
        Me.pnlCatalogo.Location = New System.Drawing.Point(6, 9)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(832, 525)
        Me.pnlCatalogo.TabIndex = 24
        '
        'cmdagregar
        '
        Me.cmdagregar.Location = New System.Drawing.Point(410, 139)
        Me.cmdagregar.Name = "cmdagregar"
        Me.cmdagregar.Size = New System.Drawing.Size(189, 29)
        Me.cmdagregar.TabIndex = 38
        Me.cmdagregar.Text = "Agregar Facturas Seleccionadas"
        Me.cmdagregar.UseVisualStyleBackColor = True
        '
        'chknominas
        '
        Me.chknominas.AutoSize = True
        Me.chknominas.BackColor = System.Drawing.Color.Transparent
        Me.chknominas.Checked = True
        Me.chknominas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chknominas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chknominas.Location = New System.Drawing.Point(596, 24)
        Me.chknominas.Name = "chknominas"
        Me.chknominas.Size = New System.Drawing.Size(222, 22)
        Me.chknominas.TabIndex = 37
        Me.chknominas.Text = "Facturas de nominas solamente"
        Me.chknominas.UseVisualStyleBackColor = False
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(133, 113)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechafin.TabIndex = 36
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbbuscar)
        Me.Panel1.Controls.Add(Me.rdbcliente)
        Me.Panel1.Controls.Add(Me.rdbfechas)
        Me.Panel1.Location = New System.Drawing.Point(10, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 34)
        Me.Panel1.TabIndex = 35
        '
        'rdbbuscar
        '
        Me.rdbbuscar.AutoSize = True
        Me.rdbbuscar.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbbuscar.Location = New System.Drawing.Point(345, 6)
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
        Me.rdbcliente.Location = New System.Drawing.Point(192, 6)
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
        Me.rdbfechas.Location = New System.Drawing.Point(16, 6)
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
        Me.lsvLista.CheckBoxes = True
        Me.lsvLista.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvLista.FullRowSelect = True
        Me.lsvLista.GridLines = True
        Me.lsvLista.HideSelection = False
        Me.lsvLista.Location = New System.Drawing.Point(10, 174)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(808, 336)
        Me.lsvLista.TabIndex = 34
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Location = New System.Drawing.Point(248, 139)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(156, 29)
        Me.cmdbuscar.TabIndex = 32
        Me.cmdbuscar.Text = "Realizar busqueda"
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(609, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 19)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Factura a buscar"
        '
        'cboclientes
        '
        Me.cboclientes.FormattingEnabled = True
        Me.cboclientes.Items.AddRange(New Object() {"Activa", "Cancelada"})
        Me.cboclientes.Location = New System.Drawing.Point(248, 112)
        Me.cboclientes.Name = "cboclientes"
        Me.cboclientes.Size = New System.Drawing.Size(354, 21)
        Me.cboclientes.TabIndex = 20
        '
        'txtbuscar
        '
        Me.txtbuscar.Location = New System.Drawing.Point(613, 112)
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
        Me.Label5.Location = New System.Drawing.Point(244, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Clientes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(129, 93)
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
        Me.Label1.Location = New System.Drawing.Point(10, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(10, 115)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechainicio.TabIndex = 5
        '
        'chktodas
        '
        Me.chktodas.AutoSize = True
        Me.chktodas.BackColor = System.Drawing.Color.Transparent
        Me.chktodas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktodas.Location = New System.Drawing.Point(454, 24)
        Me.chktodas.Name = "chktodas"
        Me.chktodas.Size = New System.Drawing.Size(145, 22)
        Me.chktodas.TabIndex = 4
        Me.chktodas.Text = "Todas las empresas"
        Me.chktodas.UseVisualStyleBackColor = False
        '
        'frmAnexarFacturaConciliacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(844, 542)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Name = "frmAnexarFacturaConciliacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anexar facturas a conciliación"
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCatalogo As System.Windows.Forms.Panel
    Friend WithEvents cmdagregar As System.Windows.Forms.Button
    Friend WithEvents chknominas As System.Windows.Forms.CheckBox
    Friend WithEvents dtpfechafin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbbuscar As System.Windows.Forms.RadioButton
    Friend WithEvents rdbcliente As System.Windows.Forms.RadioButton
    Friend WithEvents rdbfechas As System.Windows.Forms.RadioButton
    Friend WithEvents lsvLista As System.Windows.Forms.ListView
    Friend WithEvents cmdbuscar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboclientes As System.Windows.Forms.ComboBox
    Friend WithEvents txtbuscar As System.Windows.Forms.TextBox
    Friend WithEvents cboempresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpfechainicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents chktodas As System.Windows.Forms.CheckBox
End Class
