<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSucursal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSucursal))
        Me.pnlEmpresa = New System.Windows.Forms.Panel()
        Me.txtpatronal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtlocalidad = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtint = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbostatus = New System.Windows.Forms.ComboBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.txtcontacto = New System.Windows.Forms.TextBox()
        Me.txttelefono2 = New System.Windows.Forms.TextBox()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.cboestados = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtcp = New System.Windows.Forms.TextBox()
        Me.txtmunicipio = New System.Windows.Forms.TextBox()
        Me.txtcolonia = New System.Windows.Forms.TextBox()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.txtcalle = New System.Windows.Forms.TextBox()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmdnuevo = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.pnlEmpresa.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEmpresa
        '
        Me.pnlEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlEmpresa.Controls.Add(Me.txtpatronal)
        Me.pnlEmpresa.Controls.Add(Me.Label12)
        Me.pnlEmpresa.Controls.Add(Me.txtlocalidad)
        Me.pnlEmpresa.Controls.Add(Me.Label18)
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
        Me.pnlEmpresa.Controls.Add(Me.Label1)
        Me.pnlEmpresa.Enabled = False
        Me.pnlEmpresa.Location = New System.Drawing.Point(6, 14)
        Me.pnlEmpresa.Name = "pnlEmpresa"
        Me.pnlEmpresa.Size = New System.Drawing.Size(689, 420)
        Me.pnlEmpresa.TabIndex = 40
        '
        'txtpatronal
        '
        Me.txtpatronal.Location = New System.Drawing.Point(131, 312)
        Me.txtpatronal.MaxLength = 12
        Me.txtpatronal.Name = "txtpatronal"
        Me.txtpatronal.Size = New System.Drawing.Size(216, 27)
        Me.txtpatronal.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(58, 181)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 19)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Localidad:"
        '
        'txtlocalidad
        '
        Me.txtlocalidad.Location = New System.Drawing.Point(131, 178)
        Me.txtlocalidad.Name = "txtlocalidad"
        Me.txtlocalidad.Size = New System.Drawing.Size(544, 27)
        Me.txtlocalidad.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 314)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(125, 19)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Registro patronal:"
        '
        'txtint
        '
        Me.txtint.Location = New System.Drawing.Point(130, 111)
        Me.txtint.Name = "txtint"
        Me.txtint.Size = New System.Drawing.Size(264, 27)
        Me.txtint.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(65, 116)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 19)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Num. Int:"
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
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(130, 378)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(544, 27)
        Me.txtemail.TabIndex = 19
        '
        'txtcontacto
        '
        Me.txtcontacto.Location = New System.Drawing.Point(130, 346)
        Me.txtcontacto.Name = "txtcontacto"
        Me.txtcontacto.Size = New System.Drawing.Size(544, 27)
        Me.txtcontacto.TabIndex = 18
        '
        'txttelefono2
        '
        Me.txttelefono2.Location = New System.Drawing.Point(428, 279)
        Me.txttelefono2.Name = "txttelefono2"
        Me.txttelefono2.Size = New System.Drawing.Size(246, 27)
        Me.txttelefono2.TabIndex = 13
        '
        'txttelefono
        '
        Me.txttelefono.Location = New System.Drawing.Point(130, 278)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(216, 27)
        Me.txttelefono.TabIndex = 12
        '
        'cboestados
        '
        Me.cboestados.FormattingEnabled = True
        Me.cboestados.Location = New System.Drawing.Point(428, 244)
        Me.cboestados.Name = "cboestados"
        Me.cboestados.Size = New System.Drawing.Size(246, 27)
        Me.cboestados.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(374, 252)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 19)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Estado:"
        '
        'txtcp
        '
        Me.txtcp.Location = New System.Drawing.Point(130, 244)
        Me.txtcp.MaxLength = 5
        Me.txtcp.Name = "txtcp"
        Me.txtcp.Size = New System.Drawing.Size(216, 27)
        Me.txtcp.TabIndex = 10
        '
        'txtmunicipio
        '
        Me.txtmunicipio.Location = New System.Drawing.Point(130, 211)
        Me.txtmunicipio.Name = "txtmunicipio"
        Me.txtmunicipio.Size = New System.Drawing.Size(544, 27)
        Me.txtmunicipio.TabIndex = 9
        '
        'txtcolonia
        '
        Me.txtcolonia.Location = New System.Drawing.Point(130, 144)
        Me.txtcolonia.Name = "txtcolonia"
        Me.txtcolonia.Size = New System.Drawing.Size(544, 27)
        Me.txtcolonia.TabIndex = 7
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(474, 75)
        Me.txtnumero.MaxLength = 5
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(200, 27)
        Me.txtnumero.TabIndex = 5
        '
        'txtcalle
        '
        Me.txtcalle.Location = New System.Drawing.Point(130, 75)
        Me.txtcalle.Name = "txtcalle"
        Me.txtcalle.Size = New System.Drawing.Size(264, 27)
        Me.txtcalle.TabIndex = 4
        '
        'txtnombre
        '
        Me.txtnombre.Enabled = False
        Me.txtnombre.Location = New System.Drawing.Point(130, 42)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(544, 27)
        Me.txtnombre.TabIndex = 1
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(84, 383)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 19)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Email:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(62, 354)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 19)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Contacto:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(350, 286)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 19)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Telefono 2:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(64, 286)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 19)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Telefono:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(97, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "C.P.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 219)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Municipio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Colonia:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(407, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Número:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Calle:"
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
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdcancelar)
        Me.Panel1.Controls.Add(Me.cmdbuscar)
        Me.Panel1.Controls.Add(Me.cmdnuevo)
        Me.Panel1.Controls.Add(Me.cmdsalir)
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(701, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 414)
        Me.Panel1.TabIndex = 39
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
        Me.cmdsalir.Location = New System.Drawing.Point(9, 300)
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
        'frmSucursal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(812, 441)
        Me.Controls.Add(Me.pnlEmpresa)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSucursal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo Sucursal"
        Me.pnlEmpresa.ResumeLayout(False)
        Me.pnlEmpresa.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEmpresa As System.Windows.Forms.Panel
    Friend WithEvents txtpatronal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtlocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtint As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbostatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents txtcontacto As System.Windows.Forms.TextBox
    Friend WithEvents txttelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents txttelefono As System.Windows.Forms.TextBox
    Friend WithEvents cboestados As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtcp As System.Windows.Forms.TextBox
    Friend WithEvents txtmunicipio As System.Windows.Forms.TextBox
    Friend WithEvents txtcolonia As System.Windows.Forms.TextBox
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents txtcalle As System.Windows.Forms.TextBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdbuscar As System.Windows.Forms.Button
    Friend WithEvents cmdnuevo As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
End Class
