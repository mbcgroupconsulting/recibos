<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmcapturafactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcapturafactura))
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.chkFlujoNom = New System.Windows.Forms.CheckBox()
        Me.chkFlujoC = New System.Windows.Forms.CheckBox()
        Me.cmdDetFacturas = New System.Windows.Forms.Button()
        Me.txtnomina = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chkflujob = New System.Windows.Forms.CheckBox()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.txtperiodo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbotipofactura = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblmodificado = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblcapturado = New System.Windows.Forms.Label()
        Me.pnlcolores = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbocolor = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbopago = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chknota = New System.Windows.Forms.CheckBox()
        Me.pnlnota = New System.Windows.Forms.Panel()
        Me.txtserien = New System.Windows.Forms.TextBox()
        Me.txtnumnota = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboserie = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdagregar = New System.Windows.Forms.Button()
        Me.txtcomentario = New System.Windows.Forms.TextBox()
        Me.txtpago = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.txtiva = New System.Windows.Forms.TextBox()
        Me.txtimporte = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbocliente = New System.Windows.Forms.ComboBox()
        Me.cboestatus = New System.Windows.Forms.ComboBox()
        Me.txtnumfactura = New System.Windows.Forms.TextBox()
        Me.cboempresa = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbAbono = New System.Windows.Forms.ToolStripButton()
        Me.chkintermediaria = New System.Windows.Forms.CheckBox()
        Me.chkiva = New System.Windows.Forms.CheckBox()
        Me.chkPatrona = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tsbExel = New System.Windows.Forms.ToolStripButton()
        Me.pnlCatalogo.SuspendLayout()
        Me.pnlcolores.SuspendLayout()
        Me.pnlnota.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.chkFlujoNom)
        Me.pnlCatalogo.Controls.Add(Me.chkFlujoC)
        Me.pnlCatalogo.Controls.Add(Me.cmdDetFacturas)
        Me.pnlCatalogo.Controls.Add(Me.txtnomina)
        Me.pnlCatalogo.Controls.Add(Me.Label24)
        Me.pnlCatalogo.Controls.Add(Me.chkflujob)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechafin)
        Me.pnlCatalogo.Controls.Add(Me.Label22)
        Me.pnlCatalogo.Controls.Add(Me.Label23)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechainicio)
        Me.pnlCatalogo.Controls.Add(Me.txtperiodo)
        Me.pnlCatalogo.Controls.Add(Me.Label21)
        Me.pnlCatalogo.Controls.Add(Me.cbotipofactura)
        Me.pnlCatalogo.Controls.Add(Me.Label18)
        Me.pnlCatalogo.Controls.Add(Me.lblmodificado)
        Me.pnlCatalogo.Controls.Add(Me.Label20)
        Me.pnlCatalogo.Controls.Add(Me.Label19)
        Me.pnlCatalogo.Controls.Add(Me.lblcapturado)
        Me.pnlCatalogo.Controls.Add(Me.pnlcolores)
        Me.pnlCatalogo.Controls.Add(Me.cbopago)
        Me.pnlCatalogo.Controls.Add(Me.Label15)
        Me.pnlCatalogo.Controls.Add(Me.chknota)
        Me.pnlCatalogo.Controls.Add(Me.pnlnota)
        Me.pnlCatalogo.Controls.Add(Me.cboserie)
        Me.pnlCatalogo.Controls.Add(Me.Label12)
        Me.pnlCatalogo.Controls.Add(Me.lsvLista)
        Me.pnlCatalogo.Controls.Add(Me.cmdcancelar)
        Me.pnlCatalogo.Controls.Add(Me.cmdagregar)
        Me.pnlCatalogo.Controls.Add(Me.txtcomentario)
        Me.pnlCatalogo.Controls.Add(Me.txtpago)
        Me.pnlCatalogo.Controls.Add(Me.Label11)
        Me.pnlCatalogo.Controls.Add(Me.Label10)
        Me.pnlCatalogo.Controls.Add(Me.Label9)
        Me.pnlCatalogo.Controls.Add(Me.txttotal)
        Me.pnlCatalogo.Controls.Add(Me.txtiva)
        Me.pnlCatalogo.Controls.Add(Me.txtimporte)
        Me.pnlCatalogo.Controls.Add(Me.Label8)
        Me.pnlCatalogo.Controls.Add(Me.Label2)
        Me.pnlCatalogo.Controls.Add(Me.cbocliente)
        Me.pnlCatalogo.Controls.Add(Me.cboestatus)
        Me.pnlCatalogo.Controls.Add(Me.txtnumfactura)
        Me.pnlCatalogo.Controls.Add(Me.cboempresa)
        Me.pnlCatalogo.Controls.Add(Me.Label7)
        Me.pnlCatalogo.Controls.Add(Me.Label6)
        Me.pnlCatalogo.Controls.Add(Me.Label5)
        Me.pnlCatalogo.Controls.Add(Me.Label4)
        Me.pnlCatalogo.Controls.Add(Me.Label3)
        Me.pnlCatalogo.Controls.Add(Me.Label1)
        Me.pnlCatalogo.Controls.Add(Me.dtpfecha)
        Me.pnlCatalogo.Controls.Add(Me.chkActivo)
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 51)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(1322, 489)
        Me.pnlCatalogo.TabIndex = 21
        '
        'chkFlujoNom
        '
        Me.chkFlujoNom.AutoSize = True
        Me.chkFlujoNom.BackColor = System.Drawing.Color.Transparent
        Me.chkFlujoNom.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFlujoNom.Location = New System.Drawing.Point(1051, 26)
        Me.chkFlujoNom.Name = "chkFlujoNom"
        Me.chkFlujoNom.Size = New System.Drawing.Size(91, 22)
        Me.chkFlujoNom.TabIndex = 66
        Me.chkFlujoNom.Text = "Flujo Nom"
        Me.chkFlujoNom.UseVisualStyleBackColor = False
        '
        'chkFlujoC
        '
        Me.chkFlujoC.AutoSize = True
        Me.chkFlujoC.BackColor = System.Drawing.Color.Transparent
        Me.chkFlujoC.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFlujoC.Location = New System.Drawing.Point(976, 26)
        Me.chkFlujoC.Name = "chkFlujoC"
        Me.chkFlujoC.Size = New System.Drawing.Size(69, 22)
        Me.chkFlujoC.TabIndex = 65
        Me.chkFlujoC.Text = "Flujo C"
        Me.chkFlujoC.UseVisualStyleBackColor = False
        '
        'cmdDetFacturas
        '
        Me.cmdDetFacturas.Location = New System.Drawing.Point(523, 61)
        Me.cmdDetFacturas.Name = "cmdDetFacturas"
        Me.cmdDetFacturas.Size = New System.Drawing.Size(34, 34)
        Me.cmdDetFacturas.TabIndex = 62
        Me.cmdDetFacturas.Text = "..."
        Me.cmdDetFacturas.UseVisualStyleBackColor = True
        '
        'txtnomina
        '
        Me.txtnomina.Location = New System.Drawing.Point(806, 71)
        Me.txtnomina.Name = "txtnomina"
        Me.txtnomina.Size = New System.Drawing.Size(109, 20)
        Me.txtnomina.TabIndex = 26
        Me.txtnomina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(802, 50)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(99, 19)
        Me.Label24.TabIndex = 61
        Me.Label24.Text = "Retención ISN"
        '
        'chkflujob
        '
        Me.chkflujob.AutoSize = True
        Me.chkflujob.BackColor = System.Drawing.Color.Transparent
        Me.chkflujob.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkflujob.Location = New System.Drawing.Point(873, 25)
        Me.chkflujob.Name = "chkflujob"
        Me.chkflujob.Size = New System.Drawing.Size(97, 22)
        Me.chkflujob.TabIndex = 60
        Me.chkflujob.Text = "Flujo Belen"
        Me.chkflujob.UseVisualStyleBackColor = False
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(459, 163)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechafin.TabIndex = 55
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(455, 142)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 19)
        Me.Label22.TabIndex = 54
        Me.Label22.Text = "Fecha fin"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(336, 143)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(86, 19)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(336, 165)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechainicio.TabIndex = 52
        '
        'txtperiodo
        '
        Me.txtperiodo.Location = New System.Drawing.Point(320, 116)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.Size = New System.Drawing.Size(239, 20)
        Me.txtperiodo.TabIndex = 31
        Me.txtperiodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(316, 97)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 19)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "Periodo"
        '
        'cbotipofactura
        '
        Me.cbotipofactura.FormattingEnabled = True
        Me.cbotipofactura.Items.AddRange(New Object() {"Nomina", "Flujo", "Asesoria-Cliente"})
        Me.cbotipofactura.Location = New System.Drawing.Point(7, 24)
        Me.cbotipofactura.Name = "cbotipofactura"
        Me.cbotipofactura.Size = New System.Drawing.Size(100, 21)
        Me.cbotipofactura.TabIndex = 49
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 4)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 19)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "Tipo factura"
        '
        'lblmodificado
        '
        Me.lblmodificado.AutoSize = True
        Me.lblmodificado.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmodificado.Location = New System.Drawing.Point(6, 164)
        Me.lblmodificado.Name = "lblmodificado"
        Me.lblmodificado.Size = New System.Drawing.Size(87, 19)
        Me.lblmodificado.TabIndex = 47
        Me.lblmodificado.Text = "Pago/Abono"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 97)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 19)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Capturado"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 143)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(81, 19)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "Modificado"
        '
        'lblcapturado
        '
        Me.lblcapturado.AutoSize = True
        Me.lblcapturado.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcapturado.Location = New System.Drawing.Point(6, 116)
        Me.lblcapturado.Name = "lblcapturado"
        Me.lblcapturado.Size = New System.Drawing.Size(87, 19)
        Me.lblcapturado.TabIndex = 44
        Me.lblcapturado.Text = "Pago/Abono"
        '
        'pnlcolores
        '
        Me.pnlcolores.Controls.Add(Me.Label17)
        Me.pnlcolores.Controls.Add(Me.cbocolor)
        Me.pnlcolores.Controls.Add(Me.Label16)
        Me.pnlcolores.Enabled = False
        Me.pnlcolores.Location = New System.Drawing.Point(924, 103)
        Me.pnlcolores.Name = "pnlcolores"
        Me.pnlcolores.Size = New System.Drawing.Size(180, 83)
        Me.pnlcolores.TabIndex = 43
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(175, 31)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Amarillo-Pendiente, Verde-Pagado, Rojo-Cancelado"
        '
        'cbocolor
        '
        Me.cbocolor.FormattingEnabled = True
        Me.cbocolor.Items.AddRange(New Object() {"Ninguno", "Amarillo", "Verde", "Rojo", "Fiusha", "Azul"})
        Me.cbocolor.Location = New System.Drawing.Point(3, 24)
        Me.cbocolor.Name = "cbocolor"
        Me.cbocolor.Size = New System.Drawing.Size(167, 21)
        Me.cbocolor.TabIndex = 46
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 2)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 19)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Colores"
        '
        'cbopago
        '
        Me.cbopago.FormattingEnabled = True
        Me.cbopago.Items.AddRange(New Object() {"Pendiente", "Depositado"})
        Me.cbopago.Location = New System.Drawing.Point(113, 165)
        Me.cbopago.Name = "cbopago"
        Me.cbopago.Size = New System.Drawing.Size(206, 21)
        Me.cbopago.TabIndex = 42
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(113, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 19)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Estado del pago"
        '
        'chknota
        '
        Me.chknota.AutoSize = True
        Me.chknota.BackColor = System.Drawing.Color.Transparent
        Me.chknota.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chknota.Location = New System.Drawing.Point(1109, 103)
        Me.chknota.Name = "chknota"
        Me.chknota.Size = New System.Drawing.Size(123, 22)
        Me.chknota.TabIndex = 40
        Me.chknota.Text = "Nota de credito"
        Me.chknota.UseVisualStyleBackColor = False
        '
        'pnlnota
        '
        Me.pnlnota.Controls.Add(Me.txtserien)
        Me.pnlnota.Controls.Add(Me.txtnumnota)
        Me.pnlnota.Controls.Add(Me.Label14)
        Me.pnlnota.Controls.Add(Me.Label13)
        Me.pnlnota.Enabled = False
        Me.pnlnota.Location = New System.Drawing.Point(1109, 126)
        Me.pnlnota.Name = "pnlnota"
        Me.pnlnota.Size = New System.Drawing.Size(196, 57)
        Me.pnlnota.TabIndex = 38
        '
        'txtserien
        '
        Me.txtserien.Location = New System.Drawing.Point(7, 28)
        Me.txtserien.Name = "txtserien"
        Me.txtserien.Size = New System.Drawing.Size(45, 20)
        Me.txtserien.TabIndex = 45
        Me.txtserien.Tag = ""
        '
        'txtnumnota
        '
        Me.txtnumnota.Location = New System.Drawing.Point(70, 29)
        Me.txtnumnota.Name = "txtnumnota"
        Me.txtnumnota.Size = New System.Drawing.Size(112, 20)
        Me.txtnumnota.TabIndex = 44
        Me.txtnumnota.Tag = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(66, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 19)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Num. nota credito"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 19)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Serie"
        '
        'cboserie
        '
        Me.cboserie.FormattingEnabled = True
        Me.cboserie.Items.AddRange(New Object() {"A", "B", "C", "D"})
        Me.cboserie.Location = New System.Drawing.Point(522, 24)
        Me.cboserie.Name = "cboserie"
        Me.cboserie.Size = New System.Drawing.Size(51, 21)
        Me.cboserie.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(518, 4)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 19)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Serie"
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
        Me.lsvLista.Location = New System.Drawing.Point(15, 192)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(1305, 285)
        Me.lsvLista.TabIndex = 34
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.Location = New System.Drawing.Point(785, 143)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(131, 43)
        Me.cmdcancelar.TabIndex = 33
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'cmdagregar
        '
        Me.cmdagregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdagregar.Location = New System.Drawing.Point(577, 143)
        Me.cmdagregar.Name = "cmdagregar"
        Me.cmdagregar.Size = New System.Drawing.Size(202, 43)
        Me.cmdagregar.TabIndex = 32
        Me.cmdagregar.Text = "Agregar/Modificar"
        Me.cmdagregar.UseVisualStyleBackColor = True
        '
        'txtcomentario
        '
        Me.txtcomentario.Location = New System.Drawing.Point(584, 117)
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.Size = New System.Drawing.Size(334, 20)
        Me.txtcomentario.TabIndex = 32
        Me.txtcomentario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpago
        '
        Me.txtpago.Location = New System.Drawing.Point(113, 117)
        Me.txtpago.Name = "txtpago"
        Me.txtpago.Size = New System.Drawing.Size(186, 20)
        Me.txtpago.TabIndex = 30
        Me.txtpago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(581, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 19)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Comentario"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1034, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 19)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Estatus"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(113, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 19)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Pago/Abono"
        '
        'txttotal
        '
        Me.txttotal.Location = New System.Drawing.Point(929, 71)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(109, 20)
        Me.txttotal.TabIndex = 27
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtiva
        '
        Me.txtiva.Location = New System.Drawing.Point(683, 71)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(109, 20)
        Me.txtiva.TabIndex = 25
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtimporte
        '
        Me.txtimporte.Location = New System.Drawing.Point(564, 71)
        Me.txtimporte.Name = "txtimporte"
        Me.txtimporte.Size = New System.Drawing.Size(109, 20)
        Me.txtimporte.TabIndex = 24
        Me.txtimporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(679, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 19)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Iva"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(929, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Total"
        '
        'cbocliente
        '
        Me.cbocliente.FormattingEnabled = True
        Me.cbocliente.Location = New System.Drawing.Point(113, 71)
        Me.cbocliente.Name = "cbocliente"
        Me.cbocliente.Size = New System.Drawing.Size(396, 21)
        Me.cbocliente.TabIndex = 21
        '
        'cboestatus
        '
        Me.cboestatus.FormattingEnabled = True
        Me.cboestatus.Items.AddRange(New Object() {"Activa", "Cancelada"})
        Me.cboestatus.Location = New System.Drawing.Point(698, 25)
        Me.cboestatus.Name = "cboestatus"
        Me.cboestatus.Size = New System.Drawing.Size(164, 21)
        Me.cboestatus.TabIndex = 20
        '
        'txtnumfactura
        '
        Me.txtnumfactura.Location = New System.Drawing.Point(579, 26)
        Me.txtnumfactura.Name = "txtnumfactura"
        Me.txtnumfactura.Size = New System.Drawing.Size(109, 20)
        Me.txtnumfactura.TabIndex = 19
        '
        'cboempresa
        '
        Me.cboempresa.FormattingEnabled = True
        Me.cboempresa.Location = New System.Drawing.Point(113, 25)
        Me.cboempresa.Name = "cboempresa"
        Me.cboempresa.Size = New System.Drawing.Size(396, 21)
        Me.cboempresa.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(560, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 19)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Importe"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(113, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 19)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Cliente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(703, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Estado de la factura"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(580, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Num. de factura"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(113, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Empresa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fecha"
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(7, 72)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(96, 20)
        Me.dtpfecha.TabIndex = 5
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.Color.Transparent
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(1044, 72)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(15, 14)
        Me.chkActivo.TabIndex = 4
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbAbono, Me.tsbExel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(240, 48)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.recibos.My.Resources.Resources._1361007999_document_new
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(86, 45)
        Me.tsbNuevo.Text = "Listar Facturas"
        Me.tsbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbAbono
        '
        Me.tsbAbono.Image = CType(resources.GetObject("tsbAbono.Image"), System.Drawing.Image)
        Me.tsbAbono.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAbono.Name = "tsbAbono"
        Me.tsbAbono.Size = New System.Drawing.Size(67, 45)
        Me.tsbAbono.Text = "Abono S/F"
        Me.tsbAbono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'chkintermediaria
        '
        Me.chkintermediaria.AutoSize = True
        Me.chkintermediaria.BackColor = System.Drawing.Color.Transparent
        Me.chkintermediaria.Checked = True
        Me.chkintermediaria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkintermediaria.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkintermediaria.Location = New System.Drawing.Point(11, 3)
        Me.chkintermediaria.Name = "chkintermediaria"
        Me.chkintermediaria.Size = New System.Drawing.Size(112, 22)
        Me.chkintermediaria.TabIndex = 56
        Me.chkintermediaria.Text = "Intermediaria"
        Me.chkintermediaria.UseVisualStyleBackColor = False
        '
        'chkiva
        '
        Me.chkiva.AutoSize = True
        Me.chkiva.BackColor = System.Drawing.Color.Transparent
        Me.chkiva.Checked = True
        Me.chkiva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkiva.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkiva.Location = New System.Drawing.Point(130, 3)
        Me.chkiva.Name = "chkiva"
        Me.chkiva.Size = New System.Drawing.Size(45, 22)
        Me.chkiva.TabIndex = 57
        Me.chkiva.Text = "Iva"
        Me.chkiva.UseVisualStyleBackColor = False
        '
        'chkPatrona
        '
        Me.chkPatrona.AutoSize = True
        Me.chkPatrona.BackColor = System.Drawing.Color.Transparent
        Me.chkPatrona.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPatrona.Location = New System.Drawing.Point(181, 3)
        Me.chkPatrona.Name = "chkPatrona"
        Me.chkPatrona.Size = New System.Drawing.Size(75, 22)
        Me.chkPatrona.TabIndex = 58
        Me.chkPatrona.Text = "Patrona"
        Me.chkPatrona.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkPatrona)
        Me.Panel1.Controls.Add(Me.chkintermediaria)
        Me.Panel1.Controls.Add(Me.chkiva)
        Me.Panel1.Location = New System.Drawing.Point(267, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(274, 35)
        Me.Panel1.TabIndex = 59
        '
        'tsbExel
        '
        Me.tsbExel.Image = CType(resources.GetObject("tsbExel.Image"), System.Drawing.Image)
        Me.tsbExel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExel.Name = "tsbExel"
        Me.tsbExel.Size = New System.Drawing.Size(38, 45)
        Me.tsbExel.Text = "Excel"
        Me.tsbExel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbExel.Visible = False
        '
        'frmcapturafactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1322, 542)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Name = "frmcapturafactura"
        Me.Text = "Captura de facturas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        Me.pnlcolores.ResumeLayout(False)
        Me.pnlcolores.PerformLayout()
        Me.pnlnota.ResumeLayout(False)
        Me.pnlnota.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCatalogo As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboempresa As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbocliente As ComboBox
    Friend WithEvents cboestatus As ComboBox
    Friend WithEvents txtnumfactura As TextBox
    Friend WithEvents txttotal As TextBox
    Friend WithEvents txtiva As TextBox
    Friend WithEvents txtimporte As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmdcancelar As Button
    Friend WithEvents cmdagregar As Button
    Friend WithEvents txtcomentario As TextBox
    Friend WithEvents txtpago As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lsvLista As ListView
    Friend WithEvents cboserie As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cbopago As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents chknota As CheckBox
    Friend WithEvents pnlnota As Panel
    Friend WithEvents txtserien As TextBox
    Friend WithEvents txtnumnota As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents pnlcolores As Panel
    Friend WithEvents cbocolor As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblmodificado As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblcapturado As Label
    Friend WithEvents cbotipofactura As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtperiodo As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents chkintermediaria As CheckBox
    Friend WithEvents chkiva As CheckBox
    Friend WithEvents chkPatrona As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkflujob As CheckBox
    Friend WithEvents tsbAbono As ToolStripButton
    Friend WithEvents txtnomina As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cmdDetFacturas As Button
    Friend WithEvents chkFlujoNom As CheckBox
    Friend WithEvents chkFlujoC As CheckBox
    Friend WithEvents tsbExel As System.Windows.Forms.ToolStripButton
End Class
