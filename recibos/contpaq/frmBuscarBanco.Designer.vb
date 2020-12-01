<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarBanco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarBanco))
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.lsvBancos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.cbBancos = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NudFilaI = New System.Windows.Forms.NumericUpDown()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsucursal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcuentacargo = New System.Windows.Forms.TextBox()
        Me.txttipo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtempresa = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbocliente = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        CType(Me.NudFilaI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtbuscar
        '
        Me.txtbuscar.Location = New System.Drawing.Point(124, -48)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(481, 27)
        Me.txtbuscar.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-8, -40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 19)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Buscar por nombre:"
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Image = Global.recibos.My.Resources.Resources._1358748424_shutdown
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(779, 501)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(78, 30)
        Me.cmdCerrar.TabIndex = 21
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = CType(resources.GetObject("cmdBuscar.Image"), System.Drawing.Image)
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(611, -51)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(88, 30)
        Me.cmdBuscar.TabIndex = 20
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'lsvBancos
        '
        Me.lsvBancos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader6, Me.ColumnHeader5, Me.ColumnHeader7})
        Me.lsvBancos.FullRowSelect = True
        Me.lsvBancos.GridLines = True
        Me.lsvBancos.Location = New System.Drawing.Point(3, 21)
        Me.lsvBancos.MultiSelect = False
        Me.lsvBancos.Name = "lsvBancos"
        Me.lsvBancos.Size = New System.Drawing.Size(781, 197)
        Me.lsvBancos.TabIndex = 28
        Me.lsvBancos.UseCompatibleStateImageBehavior = False
        Me.lsvBancos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Banco"
        Me.ColumnHeader1.Width = 170
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Numero de Cliente"
        Me.ColumnHeader2.Width = 185
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Cuenta Cargo"
        Me.ColumnHeader3.Width = 162
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Sucursal"
        Me.ColumnHeader4.Width = 109
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Tipo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 19)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Banco:"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.recibos.My.Resources.Resources._1358748424_shutdown
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(762, 437)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 30)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Cerrar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnAsignar
        '
        Me.btnAsignar.Image = CType(resources.GetObject("btnAsignar.Image"), System.Drawing.Image)
        Me.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignar.Location = New System.Drawing.Point(596, 12)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(176, 30)
        Me.btnAsignar.TabIndex = 24
        Me.btnAsignar.Text = "Asignar/Modificar"
        Me.btnAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignar.UseVisualStyleBackColor = True
        '
        'cbBancos
        '
        Me.cbBancos.FormattingEnabled = True
        Me.cbBancos.Location = New System.Drawing.Point(89, 16)
        Me.cbBancos.Name = "cbBancos"
        Me.cbBancos.Size = New System.Drawing.Size(484, 27)
        Me.cbBancos.TabIndex = 29
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lsvBancos)
        Me.Panel1.Location = New System.Drawing.Point(26, 173)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(802, 242)
        Me.Panel1.TabIndex = 30
        '
        'NudFilaI
        '
        Me.NudFilaI.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFilaI.Location = New System.Drawing.Point(733, 131)
        Me.NudFilaI.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudFilaI.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFilaI.Name = "NudFilaI"
        Me.NudFilaI.Size = New System.Drawing.Size(53, 22)
        Me.NudFilaI.TabIndex = 61
        Me.NudFilaI.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(645, 82)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(111, 27)
        Me.dtpFecha.TabIndex = 60
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(718, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 19)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Secuencial"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(642, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 19)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Fecha de pago"
        '
        'txtsucursal
        '
        Me.txtsucursal.Location = New System.Drawing.Point(215, 131)
        Me.txtsucursal.Name = "txtsucursal"
        Me.txtsucursal.Size = New System.Drawing.Size(87, 27)
        Me.txtsucursal.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 19)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "No de Cuenta Cargo"
        '
        'txtcuentacargo
        '
        Me.txtcuentacargo.Location = New System.Drawing.Point(25, 131)
        Me.txtcuentacargo.Name = "txtcuentacargo"
        Me.txtcuentacargo.Size = New System.Drawing.Size(172, 27)
        Me.txtcuentacargo.TabIndex = 54
        '
        'txttipo
        '
        Me.txttipo.Location = New System.Drawing.Point(425, 82)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(198, 27)
        Me.txttipo.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(422, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 19)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Tipo Archivo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(212, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 19)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Referencia Empresa"
        '
        'txtempresa
        '
        Me.txtempresa.Location = New System.Drawing.Point(215, 83)
        Me.txtempresa.Name = "txtempresa"
        Me.txtempresa.Size = New System.Drawing.Size(198, 27)
        Me.txtempresa.TabIndex = 50
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 19)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "No Cliente"
        '
        'cbocliente
        '
        Me.cbocliente.FormattingEnabled = True
        Me.cbocliente.Location = New System.Drawing.Point(25, 82)
        Me.cbocliente.Name = "cbocliente"
        Me.cbocliente.Size = New System.Drawing.Size(172, 27)
        Me.cbocliente.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(224, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 19)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Sucursal"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(308, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 19)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Descripción"
        '
        'txtdescripcion
        '
        Me.txtdescripcion.Location = New System.Drawing.Point(311, 131)
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(374, 27)
        Me.txtdescripcion.TabIndex = 63
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Empresa"
        Me.ColumnHeader6.Width = 129
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Descripcion"
        '
        'frmBuscarBanco
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(849, 479)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtdescripcion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.NudFilaI)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsucursal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtcuentacargo)
        Me.Controls.Add(Me.txttipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtempresa)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbocliente)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbBancos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnAsignar)
        Me.Controls.Add(Me.txtbuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBuscarBanco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Banco"
        Me.Panel1.ResumeLayout(False)
        CType(Me.NudFilaI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtbuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents lsvBancos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents cbBancos As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NudFilaI As System.Windows.Forms.NumericUpDown
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtsucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcuentacargo As System.Windows.Forms.TextBox
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtempresa As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbocliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtdescripcion As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
End Class
