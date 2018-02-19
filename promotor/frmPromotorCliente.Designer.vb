<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromotorCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPromotorCliente))
        Me.pnlProveedores = New System.Windows.Forms.Panel()
        Me.cmdgastos = New System.Windows.Forms.Button()
        Me.pnlotroiva = New System.Windows.Forms.Panel()
        Me.nudotropromotoriva = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbootropromotoriva = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkotropromotoriva = New System.Windows.Forms.CheckBox()
        Me.chkresto = New System.Windows.Forms.CheckBox()
        Me.pnlresto = New System.Windows.Forms.Panel()
        Me.nudpromotorresto = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbopromotorresto = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbocliente = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbopromotor = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.pnlcomision = New System.Windows.Forms.Panel()
        Me.nudcantidadcomision = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbocomisionprofijo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.nudpromotorinicial = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudpromotorcomision = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboprocomision = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkcalculos = New System.Windows.Forms.CheckBox()
        Me.chkSumarComision = New System.Windows.Forms.CheckBox()
        Me.nudpromotor = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlOtro = New System.Windows.Forms.Panel()
        Me.nudOtropromotor = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboprootro = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkOtro = New System.Windows.Forms.CheckBox()
        Me.nudempresa = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudrepartir = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmdnuevo = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.pnlProveedores.SuspendLayout()
        Me.pnlotroiva.SuspendLayout()
        CType(Me.nudotropromotoriva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlresto.SuspendLayout()
        CType(Me.nudpromotorresto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlcomision.SuspendLayout()
        CType(Me.nudcantidadcomision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudpromotorinicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudpromotorcomision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudpromotor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtro.SuspendLayout()
        CType(Me.nudOtropromotor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudempresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudrepartir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlProveedores
        '
        Me.pnlProveedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProveedores.Controls.Add(Me.cmdgastos)
        Me.pnlProveedores.Controls.Add(Me.pnlotroiva)
        Me.pnlProveedores.Controls.Add(Me.chkotropromotoriva)
        Me.pnlProveedores.Controls.Add(Me.chkresto)
        Me.pnlProveedores.Controls.Add(Me.pnlresto)
        Me.pnlProveedores.Controls.Add(Me.cbocliente)
        Me.pnlProveedores.Controls.Add(Me.Label21)
        Me.pnlProveedores.Controls.Add(Me.cbopromotor)
        Me.pnlProveedores.Controls.Add(Me.Label23)
        Me.pnlProveedores.Controls.Add(Me.pnlcomision)
        Me.pnlProveedores.Controls.Add(Me.chkcalculos)
        Me.pnlProveedores.Controls.Add(Me.chkSumarComision)
        Me.pnlProveedores.Controls.Add(Me.nudpromotor)
        Me.pnlProveedores.Controls.Add(Me.Label4)
        Me.pnlProveedores.Controls.Add(Me.pnlOtro)
        Me.pnlProveedores.Controls.Add(Me.chkOtro)
        Me.pnlProveedores.Controls.Add(Me.nudempresa)
        Me.pnlProveedores.Controls.Add(Me.Label3)
        Me.pnlProveedores.Controls.Add(Me.nudrepartir)
        Me.pnlProveedores.Controls.Add(Me.Label5)
        Me.pnlProveedores.Enabled = False
        Me.pnlProveedores.Location = New System.Drawing.Point(12, 7)
        Me.pnlProveedores.Name = "pnlProveedores"
        Me.pnlProveedores.Size = New System.Drawing.Size(842, 514)
        Me.pnlProveedores.TabIndex = 63
        '
        'cmdgastos
        '
        Me.cmdgastos.Location = New System.Drawing.Point(644, 8)
        Me.cmdgastos.Name = "cmdgastos"
        Me.cmdgastos.Size = New System.Drawing.Size(154, 36)
        Me.cmdgastos.TabIndex = 68
        Me.cmdgastos.Text = "Gastos Fijos"
        Me.cmdgastos.UseVisualStyleBackColor = True
        '
        'pnlotroiva
        '
        Me.pnlotroiva.Controls.Add(Me.nudotropromotoriva)
        Me.pnlotroiva.Controls.Add(Me.Label2)
        Me.pnlotroiva.Controls.Add(Me.cbootropromotoriva)
        Me.pnlotroiva.Controls.Add(Me.Label12)
        Me.pnlotroiva.Location = New System.Drawing.Point(92, 203)
        Me.pnlotroiva.Name = "pnlotroiva"
        Me.pnlotroiva.Size = New System.Drawing.Size(730, 42)
        Me.pnlotroiva.TabIndex = 67
        '
        'nudotropromotoriva
        '
        Me.nudotropromotoriva.DecimalPlaces = 1
        Me.nudotropromotoriva.Location = New System.Drawing.Point(633, 5)
        Me.nudotropromotoriva.Name = "nudotropromotoriva"
        Me.nudotropromotoriva.Size = New System.Drawing.Size(64, 27)
        Me.nudotropromotoriva.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(548, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 19)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "% Promotor:"
        '
        'cbootropromotoriva
        '
        Me.cbootropromotoriva.FormattingEnabled = True
        Me.cbootropromotoriva.Location = New System.Drawing.Point(86, 5)
        Me.cbootropromotoriva.Name = "cbootropromotoriva"
        Me.cbootropromotoriva.Size = New System.Drawing.Size(456, 27)
        Me.cbootropromotoriva.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 19)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Promotor:"
        '
        'chkotropromotoriva
        '
        Me.chkotropromotoriva.AutoSize = True
        Me.chkotropromotoriva.Location = New System.Drawing.Point(92, 179)
        Me.chkotropromotoriva.Name = "chkotropromotoriva"
        Me.chkotropromotoriva.Size = New System.Drawing.Size(120, 23)
        Me.chkotropromotoriva.TabIndex = 66
        Me.chkotropromotoriva.Text = "Otro promotor"
        Me.chkotropromotoriva.UseVisualStyleBackColor = True
        '
        'chkresto
        '
        Me.chkresto.AutoSize = True
        Me.chkresto.Location = New System.Drawing.Point(92, 423)
        Me.chkresto.Name = "chkresto"
        Me.chkresto.Size = New System.Drawing.Size(157, 23)
        Me.chkresto.TabIndex = 65
        Me.chkresto.Text = "Reparto Remanente"
        Me.chkresto.UseVisualStyleBackColor = True
        '
        'pnlresto
        '
        Me.pnlresto.Controls.Add(Me.nudpromotorresto)
        Me.pnlresto.Controls.Add(Me.Label10)
        Me.pnlresto.Controls.Add(Me.cbopromotorresto)
        Me.pnlresto.Controls.Add(Me.Label11)
        Me.pnlresto.Location = New System.Drawing.Point(92, 452)
        Me.pnlresto.Name = "pnlresto"
        Me.pnlresto.Size = New System.Drawing.Size(730, 42)
        Me.pnlresto.TabIndex = 64
        '
        'nudpromotorresto
        '
        Me.nudpromotorresto.DecimalPlaces = 1
        Me.nudpromotorresto.Location = New System.Drawing.Point(633, 6)
        Me.nudpromotorresto.Name = "nudpromotorresto"
        Me.nudpromotorresto.Size = New System.Drawing.Size(64, 27)
        Me.nudpromotorresto.TabIndex = 49
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(548, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 19)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "% Promotor:"
        '
        'cbopromotorresto
        '
        Me.cbopromotorresto.FormattingEnabled = True
        Me.cbopromotorresto.Location = New System.Drawing.Point(86, 5)
        Me.cbopromotorresto.Name = "cbopromotorresto"
        Me.cbopromotorresto.Size = New System.Drawing.Size(456, 27)
        Me.cbopromotorresto.TabIndex = 47
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 19)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Promotor:"
        '
        'cbocliente
        '
        Me.cbocliente.FormattingEnabled = True
        Me.cbocliente.Location = New System.Drawing.Point(92, 8)
        Me.cbocliente.Name = "cbocliente"
        Me.cbocliente.Size = New System.Drawing.Size(542, 27)
        Me.cbocliente.TabIndex = 63
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(35, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 19)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Cliente:"
        '
        'cbopromotor
        '
        Me.cbopromotor.FormattingEnabled = True
        Me.cbopromotor.Location = New System.Drawing.Point(92, 40)
        Me.cbopromotor.Name = "cbopromotor"
        Me.cbopromotor.Size = New System.Drawing.Size(542, 27)
        Me.cbopromotor.TabIndex = 50
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(22, 43)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 19)
        Me.Label23.TabIndex = 49
        Me.Label23.Text = "Promotor:"
        '
        'pnlcomision
        '
        Me.pnlcomision.Controls.Add(Me.nudcantidadcomision)
        Me.pnlcomision.Controls.Add(Me.Label13)
        Me.pnlcomision.Controls.Add(Me.cbocomisionprofijo)
        Me.pnlcomision.Controls.Add(Me.Label14)
        Me.pnlcomision.Controls.Add(Me.nudpromotorinicial)
        Me.pnlcomision.Controls.Add(Me.Label9)
        Me.pnlcomision.Controls.Add(Me.nudpromotorcomision)
        Me.pnlcomision.Controls.Add(Me.Label7)
        Me.pnlcomision.Controls.Add(Me.cboprocomision)
        Me.pnlcomision.Controls.Add(Me.Label8)
        Me.pnlcomision.Location = New System.Drawing.Point(92, 303)
        Me.pnlcomision.Name = "pnlcomision"
        Me.pnlcomision.Size = New System.Drawing.Size(730, 111)
        Me.pnlcomision.TabIndex = 48
        '
        'nudcantidadcomision
        '
        Me.nudcantidadcomision.DecimalPlaces = 1
        Me.nudcantidadcomision.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nudcantidadcomision.Location = New System.Drawing.Point(616, 41)
        Me.nudcantidadcomision.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudcantidadcomision.Name = "nudcantidadcomision"
        Me.nudcantidadcomision.Size = New System.Drawing.Size(110, 27)
        Me.nudcantidadcomision.TabIndex = 55
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(548, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 19)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Cantidad:"
        '
        'cbocomisionprofijo
        '
        Me.cbocomisionprofijo.FormattingEnabled = True
        Me.cbocomisionprofijo.Location = New System.Drawing.Point(86, 41)
        Me.cbocomisionprofijo.Name = "cbocomisionprofijo"
        Me.cbocomisionprofijo.Size = New System.Drawing.Size(456, 27)
        Me.cbocomisionprofijo.TabIndex = 53
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 19)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = "Promo Fijo:"
        '
        'nudpromotorinicial
        '
        Me.nudpromotorinicial.DecimalPlaces = 1
        Me.nudpromotorinicial.Location = New System.Drawing.Point(96, 75)
        Me.nudpromotorinicial.Name = "nudpromotorinicial"
        Me.nudpromotorinicial.Size = New System.Drawing.Size(64, 27)
        Me.nudpromotorinicial.TabIndex = 51
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 19)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "% P Inicial:"
        '
        'nudpromotorcomision
        '
        Me.nudpromotorcomision.DecimalPlaces = 1
        Me.nudpromotorcomision.Location = New System.Drawing.Point(642, 5)
        Me.nudpromotorcomision.Name = "nudpromotorcomision"
        Me.nudpromotorcomision.Size = New System.Drawing.Size(64, 27)
        Me.nudpromotorcomision.TabIndex = 49
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(548, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 19)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "% Promotor:"
        '
        'cboprocomision
        '
        Me.cboprocomision.FormattingEnabled = True
        Me.cboprocomision.Location = New System.Drawing.Point(86, 5)
        Me.cboprocomision.Name = "cboprocomision"
        Me.cboprocomision.Size = New System.Drawing.Size(456, 27)
        Me.cboprocomision.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 19)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Promotor:"
        '
        'chkcalculos
        '
        Me.chkcalculos.AutoSize = True
        Me.chkcalculos.Location = New System.Drawing.Point(94, 280)
        Me.chkcalculos.Name = "chkcalculos"
        Me.chkcalculos.Size = New System.Drawing.Size(198, 23)
        Me.chkcalculos.TabIndex = 47
        Me.chkcalculos.Text = "Agregar calculos comisión"
        Me.chkcalculos.UseVisualStyleBackColor = True
        '
        'chkSumarComision
        '
        Me.chkSumarComision.AutoSize = True
        Me.chkSumarComision.Location = New System.Drawing.Point(94, 256)
        Me.chkSumarComision.Name = "chkSumarComision"
        Me.chkSumarComision.Size = New System.Drawing.Size(132, 23)
        Me.chkSumarComision.TabIndex = 46
        Me.chkSumarComision.Text = "Sumar Comisión"
        Me.chkSumarComision.UseVisualStyleBackColor = True
        '
        'nudpromotor
        '
        Me.nudpromotor.DecimalPlaces = 1
        Me.nudpromotor.Location = New System.Drawing.Point(397, 76)
        Me.nudpromotor.Name = "nudpromotor"
        Me.nudpromotor.Size = New System.Drawing.Size(64, 27)
        Me.nudpromotor.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(312, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 19)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "% Promotor:"
        '
        'pnlOtro
        '
        Me.pnlOtro.Controls.Add(Me.nudOtropromotor)
        Me.pnlOtro.Controls.Add(Me.Label6)
        Me.pnlOtro.Controls.Add(Me.cboprootro)
        Me.pnlOtro.Controls.Add(Me.Label1)
        Me.pnlOtro.Location = New System.Drawing.Point(92, 134)
        Me.pnlOtro.Name = "pnlOtro"
        Me.pnlOtro.Size = New System.Drawing.Size(730, 38)
        Me.pnlOtro.TabIndex = 43
        '
        'nudOtropromotor
        '
        Me.nudOtropromotor.DecimalPlaces = 1
        Me.nudOtropromotor.Location = New System.Drawing.Point(633, 5)
        Me.nudOtropromotor.Name = "nudOtropromotor"
        Me.nudOtropromotor.Size = New System.Drawing.Size(64, 27)
        Me.nudOtropromotor.TabIndex = 49
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(548, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 19)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "% Promotor:"
        '
        'cboprootro
        '
        Me.cboprootro.FormattingEnabled = True
        Me.cboprootro.Location = New System.Drawing.Point(86, 5)
        Me.cboprootro.Name = "cboprootro"
        Me.cboprootro.Size = New System.Drawing.Size(456, 27)
        Me.cboprootro.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 19)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Promotor:"
        '
        'chkOtro
        '
        Me.chkOtro.AutoSize = True
        Me.chkOtro.Location = New System.Drawing.Point(92, 110)
        Me.chkOtro.Name = "chkOtro"
        Me.chkOtro.Size = New System.Drawing.Size(120, 23)
        Me.chkOtro.TabIndex = 42
        Me.chkOtro.Text = "Otro promotor"
        Me.chkOtro.UseVisualStyleBackColor = True
        '
        'nudempresa
        '
        Me.nudempresa.DecimalPlaces = 1
        Me.nudempresa.Enabled = False
        Me.nudempresa.Location = New System.Drawing.Point(92, 76)
        Me.nudempresa.Name = "nudempresa"
        Me.nudempresa.Size = New System.Drawing.Size(64, 27)
        Me.nudempresa.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 19)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "% Empresa:"
        '
        'nudrepartir
        '
        Me.nudrepartir.DecimalPlaces = 1
        Me.nudrepartir.Location = New System.Drawing.Point(242, 76)
        Me.nudrepartir.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.nudrepartir.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudrepartir.Name = "nudrepartir"
        Me.nudrepartir.Size = New System.Drawing.Size(64, 27)
        Me.nudrepartir.TabIndex = 16
        Me.nudrepartir.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(165, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "% Repartir:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdcancelar)
        Me.Panel1.Controls.Add(Me.cmdbuscar)
        Me.Panel1.Controls.Add(Me.cmdnuevo)
        Me.Panel1.Controls.Add(Me.cmdsalir)
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(863, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 380)
        Me.Panel1.TabIndex = 64
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdcancelar.Image = CType(resources.GetObject("cmdcancelar.Image"), System.Drawing.Image)
        Me.cmdcancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcancelar.Location = New System.Drawing.Point(7, 148)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(87, 72)
        Me.cmdcancelar.TabIndex = 37
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdbuscar.Location = New System.Drawing.Point(7, 224)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(87, 72)
        Me.cmdbuscar.TabIndex = 36
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'cmdnuevo
        '
        Me.cmdnuevo.Image = CType(resources.GetObject("cmdnuevo.Image"), System.Drawing.Image)
        Me.cmdnuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdnuevo.Location = New System.Drawing.Point(7, 2)
        Me.cmdnuevo.Name = "cmdnuevo"
        Me.cmdnuevo.Size = New System.Drawing.Size(87, 72)
        Me.cmdnuevo.TabIndex = 33
        Me.cmdnuevo.Text = "Nuevo"
        Me.cmdnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdnuevo.UseVisualStyleBackColor = True
        '
        'cmdsalir
        '
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdsalir.Location = New System.Drawing.Point(7, 299)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(87, 72)
        Me.cmdsalir.TabIndex = 37
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'cmdguardar
        '
        Me.cmdguardar.Image = CType(resources.GetObject("cmdguardar.Image"), System.Drawing.Image)
        Me.cmdguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdguardar.Location = New System.Drawing.Point(7, 75)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(87, 72)
        Me.cmdguardar.TabIndex = 34
        Me.cmdguardar.Text = "Guardar"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdguardar.UseVisualStyleBackColor = True
        '
        'frmPromotorCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(974, 527)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlProveedores)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPromotorCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asociar Cliente-Promotor"
        Me.pnlProveedores.ResumeLayout(False)
        Me.pnlProveedores.PerformLayout()
        Me.pnlotroiva.ResumeLayout(False)
        Me.pnlotroiva.PerformLayout()
        CType(Me.nudotropromotoriva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlresto.ResumeLayout(False)
        Me.pnlresto.PerformLayout()
        CType(Me.nudpromotorresto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlcomision.ResumeLayout(False)
        Me.pnlcomision.PerformLayout()
        CType(Me.nudcantidadcomision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudpromotorinicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudpromotorcomision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudpromotor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtro.ResumeLayout(False)
        Me.pnlOtro.PerformLayout()
        CType(Me.nudOtropromotor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudempresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudrepartir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlProveedores As Panel
    Friend WithEvents cbocliente As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cbopromotor As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents pnlcomision As Panel
    Friend WithEvents nudpromotorinicial As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents nudpromotorcomision As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents cboprocomision As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chkcalculos As CheckBox
    Friend WithEvents chkSumarComision As CheckBox
    Friend WithEvents nudpromotor As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlOtro As Panel
    Friend WithEvents nudOtropromotor As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents cboprootro As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkOtro As CheckBox
    Friend WithEvents nudempresa As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents nudrepartir As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdcancelar As Button
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents cmdnuevo As Button
    Friend WithEvents cmdsalir As Button
    Friend WithEvents cmdguardar As Button
    Friend WithEvents chkresto As CheckBox
    Friend WithEvents pnlresto As Panel
    Friend WithEvents nudpromotorresto As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents cbopromotorresto As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents pnlotroiva As Panel
    Friend WithEvents nudotropromotoriva As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents cbootropromotoriva As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkotropromotoriva As CheckBox
    Friend WithEvents nudcantidadcomision As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents cbocomisionprofijo As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmdgastos As Button
End Class
