<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpresas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpresas))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdNotario = New System.Windows.Forms.Button()
        Me.cmdlista = New System.Windows.Forms.Button()
        Me.cmdsucursal = New System.Windows.Forms.Button()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmdnuevo = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.txtnombre2 = New System.Windows.Forms.TextBox()
        Me.txtcalle = New System.Windows.Forms.TextBox()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.txtcolonia = New System.Windows.Forms.TextBox()
        Me.txtmunicipio = New System.Windows.Forms.TextBox()
        Me.txtcp = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboestados = New System.Windows.Forms.ComboBox()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.txttelefono2 = New System.Windows.Forms.TextBox()
        Me.txtcontacto = New System.Windows.Forms.TextBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.cbostatus = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtint = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtrfc = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbotipoempresa = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtlocalidad = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlEmpresa = New System.Windows.Forms.Panel()
        Me.dtConstitucion = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtVolumen = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtIntrumento = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtObjetoSocialP = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtRepresentanteP = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtfactor = New System.Windows.Forms.TextBox()
        Me.txtfraccion = New System.Windows.Forms.TextBox()
        Me.cbonivel = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbomatriz = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtpatronal = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.pnlEmpresa.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdNotario)
        Me.Panel1.Controls.Add(Me.cmdlista)
        Me.Panel1.Controls.Add(Me.cmdsucursal)
        Me.Panel1.Controls.Add(Me.cmdcancelar)
        Me.Panel1.Controls.Add(Me.cmdbuscar)
        Me.Panel1.Controls.Add(Me.cmdnuevo)
        Me.Panel1.Controls.Add(Me.cmdsalir)
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(698, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 658)
        Me.Panel1.TabIndex = 37
        '
        'cmdNotario
        '
        Me.cmdNotario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdNotario.Image = Global.recibos.My.Resources.Resources.bloggif_5aa81d204bc8d
        Me.cmdNotario.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdNotario.Location = New System.Drawing.Point(11, 453)
        Me.cmdNotario.Name = "cmdNotario"
        Me.cmdNotario.Size = New System.Drawing.Size(87, 72)
        Me.cmdNotario.TabIndex = 41
        Me.cmdNotario.Text = "Notario"
        Me.cmdNotario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdNotario.UseVisualStyleBackColor = True
        '
        'cmdlista
        '
        Me.cmdlista.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdlista.Image = CType(resources.GetObject("cmdlista.Image"), System.Drawing.Image)
        Me.cmdlista.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdlista.Location = New System.Drawing.Point(11, 376)
        Me.cmdlista.Name = "cmdlista"
        Me.cmdlista.Size = New System.Drawing.Size(87, 72)
        Me.cmdlista.TabIndex = 40
        Me.cmdlista.Text = "Empresas"
        Me.cmdlista.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdlista.UseVisualStyleBackColor = True
        '
        'cmdsucursal
        '
        Me.cmdsucursal.Image = CType(resources.GetObject("cmdsucursal.Image"), System.Drawing.Image)
        Me.cmdsucursal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdsucursal.Location = New System.Drawing.Point(9, 300)
        Me.cmdsucursal.Name = "cmdsucursal"
        Me.cmdsucursal.Size = New System.Drawing.Size(87, 72)
        Me.cmdsucursal.TabIndex = 39
        Me.cmdsucursal.Text = "Sucursal"
        Me.cmdsucursal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsucursal.UseVisualStyleBackColor = True
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdcancelar.Image = CType(resources.GetObject("cmdcancelar.Image"), System.Drawing.Image)
        Me.cmdcancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcancelar.Location = New System.Drawing.Point(7, 149)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(87, 72)
        Me.cmdcancelar.TabIndex = 38
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
        Me.cmdsalir.Location = New System.Drawing.Point(11, 579)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre Fiscal:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Calle:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(407, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Número:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Colonia:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Municipio:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(97, 324)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "C.P.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(64, 358)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 19)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Telefono:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(350, 358)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 19)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Telefono 2:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(62, 527)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 19)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Contacto:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(84, 556)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 19)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Email:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(470, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 19)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Estatus:"
        '
        'txtnombre
        '
        Me.txtnombre.Location = New System.Drawing.Point(130, 42)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(544, 27)
        Me.txtnombre.TabIndex = 1
        '
        'txtnombre2
        '
        Me.txtnombre2.Location = New System.Drawing.Point(130, 75)
        Me.txtnombre2.Name = "txtnombre2"
        Me.txtnombre2.Size = New System.Drawing.Size(544, 27)
        Me.txtnombre2.TabIndex = 2
        '
        'txtcalle
        '
        Me.txtcalle.Location = New System.Drawing.Point(130, 147)
        Me.txtcalle.Name = "txtcalle"
        Me.txtcalle.Size = New System.Drawing.Size(264, 27)
        Me.txtcalle.TabIndex = 4
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(474, 147)
        Me.txtnumero.MaxLength = 5
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(200, 27)
        Me.txtnumero.TabIndex = 5
        '
        'txtcolonia
        '
        Me.txtcolonia.Location = New System.Drawing.Point(130, 216)
        Me.txtcolonia.Name = "txtcolonia"
        Me.txtcolonia.Size = New System.Drawing.Size(544, 27)
        Me.txtcolonia.TabIndex = 7
        '
        'txtmunicipio
        '
        Me.txtmunicipio.Location = New System.Drawing.Point(130, 283)
        Me.txtmunicipio.Name = "txtmunicipio"
        Me.txtmunicipio.Size = New System.Drawing.Size(544, 27)
        Me.txtmunicipio.TabIndex = 9
        '
        'txtcp
        '
        Me.txtcp.Location = New System.Drawing.Point(130, 316)
        Me.txtcp.MaxLength = 5
        Me.txtcp.Name = "txtcp"
        Me.txtcp.Size = New System.Drawing.Size(216, 27)
        Me.txtcp.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(374, 324)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 19)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Estado:"
        '
        'cboestados
        '
        Me.cboestados.FormattingEnabled = True
        Me.cboestados.Location = New System.Drawing.Point(428, 316)
        Me.cboestados.Name = "cboestados"
        Me.cboestados.Size = New System.Drawing.Size(246, 27)
        Me.cboestados.TabIndex = 11
        '
        'txttelefono
        '
        Me.txttelefono.Location = New System.Drawing.Point(130, 350)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(216, 27)
        Me.txttelefono.TabIndex = 12
        '
        'txttelefono2
        '
        Me.txttelefono2.Location = New System.Drawing.Point(428, 351)
        Me.txttelefono2.Name = "txttelefono2"
        Me.txttelefono2.Size = New System.Drawing.Size(246, 27)
        Me.txttelefono2.TabIndex = 13
        '
        'txtcontacto
        '
        Me.txtcontacto.Location = New System.Drawing.Point(130, 519)
        Me.txtcontacto.Name = "txtcontacto"
        Me.txtcontacto.Size = New System.Drawing.Size(544, 27)
        Me.txtcontacto.TabIndex = 20
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(130, 551)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(544, 27)
        Me.txtemail.TabIndex = 21
        '
        'cbostatus
        '
        Me.cbostatus.FormattingEnabled = True
        Me.cbostatus.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.cbostatus.Location = New System.Drawing.Point(537, 4)
        Me.cbostatus.Name = "cbostatus"
        Me.cbostatus.Size = New System.Drawing.Size(138, 27)
        Me.cbostatus.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(65, 188)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 19)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Num. Int:"
        '
        'txtint
        '
        Me.txtint.Location = New System.Drawing.Point(130, 183)
        Me.txtint.Name = "txtint"
        Me.txtint.Size = New System.Drawing.Size(264, 27)
        Me.txtint.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(87, 116)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 19)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "R.F.C.:"
        '
        'txtrfc
        '
        Me.txtrfc.Location = New System.Drawing.Point(130, 108)
        Me.txtrfc.MaxLength = 13
        Me.txtrfc.Name = "txtrfc"
        Me.txtrfc.Size = New System.Drawing.Size(264, 27)
        Me.txtrfc.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(34, 386)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 19)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Tipo empresa:"
        '
        'cbotipoempresa
        '
        Me.cbotipoempresa.FormattingEnabled = True
        Me.cbotipoempresa.Location = New System.Drawing.Point(131, 386)
        Me.cbotipoempresa.Name = "cbotipoempresa"
        Me.cbotipoempresa.Size = New System.Drawing.Size(216, 27)
        Me.cbotipoempresa.TabIndex = 14
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 421)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(125, 19)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Registro patronal:"
        '
        'txtlocalidad
        '
        Me.txtlocalidad.Location = New System.Drawing.Point(131, 250)
        Me.txtlocalidad.Name = "txtlocalidad"
        Me.txtlocalidad.Size = New System.Drawing.Size(544, 27)
        Me.txtlocalidad.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(58, 253)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 19)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Localidad:"
        '
        'pnlEmpresa
        '
        Me.pnlEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlEmpresa.Controls.Add(Me.dtConstitucion)
        Me.pnlEmpresa.Controls.Add(Me.Label27)
        Me.pnlEmpresa.Controls.Add(Me.txtVolumen)
        Me.pnlEmpresa.Controls.Add(Me.Label26)
        Me.pnlEmpresa.Controls.Add(Me.txtIntrumento)
        Me.pnlEmpresa.Controls.Add(Me.Label25)
        Me.pnlEmpresa.Controls.Add(Me.txtObjetoSocialP)
        Me.pnlEmpresa.Controls.Add(Me.Label24)
        Me.pnlEmpresa.Controls.Add(Me.txtRepresentanteP)
        Me.pnlEmpresa.Controls.Add(Me.Label20)
        Me.pnlEmpresa.Controls.Add(Me.txtfactor)
        Me.pnlEmpresa.Controls.Add(Me.txtfraccion)
        Me.pnlEmpresa.Controls.Add(Me.cbonivel)
        Me.pnlEmpresa.Controls.Add(Me.Label23)
        Me.pnlEmpresa.Controls.Add(Me.Label22)
        Me.pnlEmpresa.Controls.Add(Me.Label21)
        Me.pnlEmpresa.Controls.Add(Me.cbomatriz)
        Me.pnlEmpresa.Controls.Add(Me.Label19)
        Me.pnlEmpresa.Controls.Add(Me.txtpatronal)
        Me.pnlEmpresa.Controls.Add(Me.Label12)
        Me.pnlEmpresa.Controls.Add(Me.txtlocalidad)
        Me.pnlEmpresa.Controls.Add(Me.Label18)
        Me.pnlEmpresa.Controls.Add(Me.cbotipoempresa)
        Me.pnlEmpresa.Controls.Add(Me.Label17)
        Me.pnlEmpresa.Controls.Add(Me.txtrfc)
        Me.pnlEmpresa.Controls.Add(Me.Label16)
        Me.pnlEmpresa.Controls.Add(Me.txtint)
        Me.pnlEmpresa.Controls.Add(Me.Label15)
        Me.pnlEmpresa.Controls.Add(Me.cbostatus)
        Me.pnlEmpresa.Controls.Add(Me.txtemail)
        Me.pnlEmpresa.Controls.Add(Me.txtcontacto)
        Me.pnlEmpresa.Controls.Add(Me.txttelefono2)
        Me.pnlEmpresa.Controls.Add(Me.txttelefono)
        Me.pnlEmpresa.Controls.Add(Me.cboestados)
        Me.pnlEmpresa.Controls.Add(Me.Label14)
        Me.pnlEmpresa.Controls.Add(Me.txtcp)
        Me.pnlEmpresa.Controls.Add(Me.txtmunicipio)
        Me.pnlEmpresa.Controls.Add(Me.txtcolonia)
        Me.pnlEmpresa.Controls.Add(Me.txtnumero)
        Me.pnlEmpresa.Controls.Add(Me.txtcalle)
        Me.pnlEmpresa.Controls.Add(Me.txtnombre2)
        Me.pnlEmpresa.Controls.Add(Me.txtnombre)
        Me.pnlEmpresa.Controls.Add(Me.Label13)
        Me.pnlEmpresa.Controls.Add(Me.Label11)
        Me.pnlEmpresa.Controls.Add(Me.Label10)
        Me.pnlEmpresa.Controls.Add(Me.Label9)
        Me.pnlEmpresa.Controls.Add(Me.Label8)
        Me.pnlEmpresa.Controls.Add(Me.Label7)
        Me.pnlEmpresa.Controls.Add(Me.Label6)
        Me.pnlEmpresa.Controls.Add(Me.Label5)
        Me.pnlEmpresa.Controls.Add(Me.Label4)
        Me.pnlEmpresa.Controls.Add(Me.Label3)
        Me.pnlEmpresa.Controls.Add(Me.Label2)
        Me.pnlEmpresa.Controls.Add(Me.Label1)
        Me.pnlEmpresa.Enabled = False
        Me.pnlEmpresa.Location = New System.Drawing.Point(3, 19)
        Me.pnlEmpresa.Name = "pnlEmpresa"
        Me.pnlEmpresa.Size = New System.Drawing.Size(689, 723)
        Me.pnlEmpresa.TabIndex = 38
        '
        'dtConstitucion
        '
        Me.dtConstitucion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtConstitucion.Location = New System.Drawing.Point(559, 659)
        Me.dtConstitucion.Name = "dtConstitucion"
        Me.dtConstitucion.Size = New System.Drawing.Size(96, 27)
        Me.dtConstitucion.TabIndex = 55
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(463, 662)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(94, 19)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "Constitución:"
        '
        'txtVolumen
        '
        Me.txtVolumen.Location = New System.Drawing.Point(349, 659)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(108, 27)
        Me.txtVolumen.TabIndex = 53
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(282, 663)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 19)
        Me.Label26.TabIndex = 52
        Me.Label26.Text = "Volumen:"
        '
        'txtIntrumento
        '
        Me.txtIntrumento.Location = New System.Drawing.Point(135, 659)
        Me.txtIntrumento.Name = "txtIntrumento"
        Me.txtIntrumento.Size = New System.Drawing.Size(146, 27)
        Me.txtIntrumento.TabIndex = 51
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(-2, 662)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(142, 19)
        Me.Label25.TabIndex = 50
        Me.Label25.Text = "Instrumento Publico:"
        '
        'txtObjetoSocialP
        '
        Me.txtObjetoSocialP.Location = New System.Drawing.Point(130, 621)
        Me.txtObjetoSocialP.Name = "txtObjetoSocialP"
        Me.txtObjetoSocialP.Size = New System.Drawing.Size(544, 27)
        Me.txtObjetoSocialP.TabIndex = 49
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(34, 624)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(99, 19)
        Me.Label24.TabIndex = 48
        Me.Label24.Text = "Objeto Social:"
        '
        'txtRepresentanteP
        '
        Me.txtRepresentanteP.Location = New System.Drawing.Point(151, 584)
        Me.txtRepresentanteP.Name = "txtRepresentanteP"
        Me.txtRepresentanteP.Size = New System.Drawing.Size(523, 27)
        Me.txtRepresentanteP.TabIndex = 47
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(-6, 587)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(162, 19)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Representante Patrona:"
        '
        'txtfactor
        '
        Me.txtfactor.Location = New System.Drawing.Point(130, 487)
        Me.txtfactor.Name = "txtfactor"
        Me.txtfactor.Size = New System.Drawing.Size(544, 27)
        Me.txtfactor.TabIndex = 19
        '
        'txtfraccion
        '
        Me.txtfraccion.Location = New System.Drawing.Point(130, 454)
        Me.txtfraccion.Name = "txtfraccion"
        Me.txtfraccion.Size = New System.Drawing.Size(544, 27)
        Me.txtfraccion.TabIndex = 18
        '
        'cbonivel
        '
        Me.cbonivel.FormattingEnabled = True
        Me.cbonivel.Items.AddRange(New Object() {"I Ordinario", "II Bajo", "III Medio", "IV Alto", "V Maximo"})
        Me.cbonivel.Location = New System.Drawing.Point(458, 421)
        Me.cbonivel.Name = "cbonivel"
        Me.cbonivel.Size = New System.Drawing.Size(217, 27)
        Me.cbonivel.TabIndex = 17
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(16, 490)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(117, 19)
        Me.Label23.TabIndex = 45
        Me.Label23.Text = "Factor de riesgo:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(66, 457)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 19)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "Fracción:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(353, 426)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(110, 19)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Nivel de riesgo:"
        '
        'cbomatriz
        '
        Me.cbomatriz.FormattingEnabled = True
        Me.cbomatriz.Items.AddRange(New Object() {"Matriz", "Sucursal"})
        Me.cbomatriz.Location = New System.Drawing.Point(462, 388)
        Me.cbomatriz.Name = "cbomatriz"
        Me.cbomatriz.Size = New System.Drawing.Size(212, 27)
        Me.cbomatriz.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(350, 391)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 19)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Matriz/Sucursal:"
        '
        'txtpatronal
        '
        Me.txtpatronal.Location = New System.Drawing.Point(131, 419)
        Me.txtpatronal.MaxLength = 12
        Me.txtpatronal.Name = "txtpatronal"
        Me.txtpatronal.Size = New System.Drawing.Size(216, 27)
        Me.txtpatronal.TabIndex = 16
        '
        'frmEmpresas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(812, 749)
        Me.Controls.Add(Me.pnlEmpresa)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmEmpresas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo Empresas"
        Me.Panel1.ResumeLayout(False)
        Me.pnlEmpresa.ResumeLayout(False)
        Me.pnlEmpresa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdbuscar As System.Windows.Forms.Button
    Friend WithEvents cmdnuevo As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtnombre2 As System.Windows.Forms.TextBox
    Friend WithEvents txtcalle As System.Windows.Forms.TextBox
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents txtcolonia As System.Windows.Forms.TextBox
    Friend WithEvents txtmunicipio As System.Windows.Forms.TextBox
    Friend WithEvents txtcp As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboestados As System.Windows.Forms.ComboBox
    Friend WithEvents txttelefono As System.Windows.Forms.TextBox
    Friend WithEvents txttelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents txtcontacto As System.Windows.Forms.TextBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents cbostatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtint As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtrfc As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbotipoempresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtlocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlEmpresa As System.Windows.Forms.Panel
    Friend WithEvents txtpatronal As System.Windows.Forms.TextBox
    Friend WithEvents cmdsucursal As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbomatriz As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtfactor As System.Windows.Forms.TextBox
    Friend WithEvents txtfraccion As System.Windows.Forms.TextBox
    Friend WithEvents cbonivel As System.Windows.Forms.ComboBox
    Friend WithEvents cmdlista As Button
    Friend WithEvents txtRepresentanteP As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtObjetoSocialP As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtVolumen As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtIntrumento As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdNotario As System.Windows.Forms.Button
    Friend WithEvents dtConstitucion As System.Windows.Forms.DateTimePicker
End Class
