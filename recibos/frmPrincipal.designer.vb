<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Recibos Via Sindicato"}, 11, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Recibos Via Fiscal"}, 4, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Recibos Sindicato"}, 13, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Recibo TMM Fiscal"}, 4, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Guo Aguinaldo"}, 5, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Importacion Guo"}, 10, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Altas Guo"}, 1, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Importacion Flujos"}, 15, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Fiscal TMMxT"}, 9, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Sindicato TMMxT"}, 12, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Exportar nomina TMM"}, 16, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Exportar gastos viaje"}, 18, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Exportar anticipos nomina"}, 17, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Asimilados Marinos"}, 0, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Simple Maecco Sindicato"}, 0, System.Drawing.Color.Black, System.Drawing.Color.Empty, Nothing)
        Me.pnlBar = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkCBB = New System.Windows.Forms.CheckBox()
        Me.chkCFDI = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lsvPanel = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuInicio = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContpaqToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerEmpresasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImssToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerEmpresasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlujoBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubirAControlTesoreriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlujoCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsociarComisiónClienteFlujoCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalcularFlujoCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescargarReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsociarComisiónClienteFlujoNominaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarCalculoManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaNominasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarEmpleadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpresasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoEmpresasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PromotoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientePromotorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaneaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ASIMILADOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlTesoreriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlTesoreriaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FondeoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NominaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JuridicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarFlujosConceptosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesFlujosConceptosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarFlujosConceptosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContratToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComisionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConciliacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubirDatosBancoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarDatosBancoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConciliarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Conciliar10ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GastosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarGastosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarGastosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KioskoClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsociarClientesEmpresasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarDatoContabilidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarDatosNominasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarDatosJuridicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlBar.SuspendLayout()
        Me.MenuInicio.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBar
        '
        Me.pnlBar.Controls.Add(Me.CheckBox1)
        Me.pnlBar.Controls.Add(Me.chkCBB)
        Me.pnlBar.Controls.Add(Me.chkCFDI)
        Me.pnlBar.Controls.Add(Me.Label1)
        Me.pnlBar.Controls.Add(Me.lblUsuario)
        Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBar.Location = New System.Drawing.Point(0, 436)
        Me.pnlBar.Name = "pnlBar"
        Me.pnlBar.Size = New System.Drawing.Size(724, 41)
        Me.pnlBar.TabIndex = 5
        '
        'CheckBox1
        '
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.CheckBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CheckBox1.Location = New System.Drawing.Point(3, 1)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(84, 39)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Menú"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'chkCBB
        '
        Me.chkCBB.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkCBB.BackColor = System.Drawing.SystemColors.Control
        Me.chkCBB.Image = CType(resources.GetObject("chkCBB.Image"), System.Drawing.Image)
        Me.chkCBB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkCBB.Location = New System.Drawing.Point(418, 1)
        Me.chkCBB.Name = "chkCBB"
        Me.chkCBB.Size = New System.Drawing.Size(153, 39)
        Me.chkCBB.TabIndex = 4
        Me.chkCBB.Text = "Facturación CBB"
        Me.chkCBB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCBB.UseVisualStyleBackColor = True
        Me.chkCBB.Visible = False
        '
        'chkCFDI
        '
        Me.chkCFDI.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkCFDI.BackColor = System.Drawing.SystemColors.Control
        Me.chkCFDI.Image = CType(resources.GetObject("chkCFDI.Image"), System.Drawing.Image)
        Me.chkCFDI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkCFDI.Location = New System.Drawing.Point(264, 1)
        Me.chkCFDI.Name = "chkCFDI"
        Me.chkCFDI.Size = New System.Drawing.Size(153, 39)
        Me.chkCFDI.TabIndex = 3
        Me.chkCFDI.Text = "Facturación CFDI"
        Me.chkCFDI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCFDI.UseVisualStyleBackColor = True
        Me.chkCFDI.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(91, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.lblUsuario.Location = New System.Drawing.Point(146, 11)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(71, 20)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Usuario"
        '
        'lsvPanel
        '
        Me.lsvPanel.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.lsvPanel.BackColor = System.Drawing.Color.White
        Me.lsvPanel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvPanel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvPanel.ForeColor = System.Drawing.Color.White
        Me.lsvPanel.FullRowSelect = True
        Me.lsvPanel.HideSelection = False
        Me.lsvPanel.HoverSelection = True
        ListViewItem1.ToolTipText = "Crear recibos via sindicato"
        ListViewItem2.ToolTipText = "Crear recibos via fiscal"
        ListViewItem3.ToolTipText = "Crear recibos sindicato Lupita"
        ListViewItem5.ToolTipText = "Genera recibos aguinaldo"
        Me.lsvPanel.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15})
        Me.lsvPanel.LargeImageList = Me.ImageList1
        Me.lsvPanel.Location = New System.Drawing.Point(0, 0)
        Me.lsvPanel.Name = "lsvPanel"
        Me.lsvPanel.ShowItemToolTips = True
        Me.lsvPanel.Size = New System.Drawing.Size(724, 477)
        Me.lsvPanel.TabIndex = 3
        Me.lsvPanel.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "invoice48x48.png")
        Me.ImageList1.Images.SetKeyName(1, "stock_certificate.png")
        Me.ImageList1.Images.SetKeyName(2, "Contents.png")
        Me.ImageList1.Images.SetKeyName(3, "1304468698_Gnome-Preferences-System-64.png")
        Me.ImageList1.Images.SetKeyName(4, "sales-report48x48.png")
        Me.ImageList1.Images.SetKeyName(5, "ChangeUser.png")
        Me.ImageList1.Images.SetKeyName(6, "1304468741_Gnome-Preferences-Other-64.png")
        Me.ImageList1.Images.SetKeyName(7, "preferences-desktop-wallpaper.png")
        Me.ImageList1.Images.SetKeyName(8, "User 7.png")
        Me.ImageList1.Images.SetKeyName(9, "User 5.png")
        Me.ImageList1.Images.SetKeyName(10, "InBox.png")
        Me.ImageList1.Images.SetKeyName(11, "Cash.png")
        Me.ImageList1.Images.SetKeyName(12, "1362225841_clients.png")
        Me.ImageList1.Images.SetKeyName(13, "1362226941_coins.png")
        Me.ImageList1.Images.SetKeyName(14, "1362227659_userconfig.png")
        Me.ImageList1.Images.SetKeyName(15, "atm-48.png")
        Me.ImageList1.Images.SetKeyName(16, "1474867410_upload.png")
        Me.ImageList1.Images.SetKeyName(17, "1474867386_advantage_cloud.png")
        Me.ImageList1.Images.SetKeyName(18, "1474867277_web.png")
        '
        'MenuInicio
        '
        Me.MenuInicio.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuInicio.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.MenuInicio.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuInicio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MenuInicio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContpaqToolStripMenuItem, Me.ImssToolStripMenuItem, Me.FlujoBToolStripMenuItem, Me.FlujoCToolStripMenuItem, Me.AltaNominasToolStripMenuItem, Me.CatalogosToolStripMenuItem, Me.PlaneaciónToolStripMenuItem, Me.FacturacionToolStripMenuItem, Me.ControlTesoreriaToolStripMenuItem, Me.NominaToolStripMenuItem, Me.JuridicoToolStripMenuItem, Me.ComisionesToolStripMenuItem, Me.ConciliacionToolStripMenuItem, Me.GastosToolStripMenuItem, Me.KioskoClientesToolStripMenuItem, Me.mnuSalir})
        Me.MenuInicio.Name = "MenuInicio"
        Me.MenuInicio.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional

        Me.MenuInicio.Size = New System.Drawing.Size(203, 634)

        ''   Me.MenuInicio.Size = New System.Drawing.Size(206, 612)

        '
        'ContpaqToolStripMenuItem
        '
        Me.ContpaqToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerEmpresasToolStripMenuItem})
        Me.ContpaqToolStripMenuItem.Name = "ContpaqToolStripMenuItem"
        Me.ContpaqToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.ContpaqToolStripMenuItem.Text = "Contpaq"
        '
        'VerEmpresasToolStripMenuItem
        '
        Me.VerEmpresasToolStripMenuItem.Name = "VerEmpresasToolStripMenuItem"
        Me.VerEmpresasToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.VerEmpresasToolStripMenuItem.Text = "Ver Empresas"
        '
        'ImssToolStripMenuItem
        '
        Me.ImssToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerEmpresasToolStripMenuItem1})
        Me.ImssToolStripMenuItem.Name = "ImssToolStripMenuItem"
        Me.ImssToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.ImssToolStripMenuItem.Text = "Imss"
        '
        'VerEmpresasToolStripMenuItem1
        '
        Me.VerEmpresasToolStripMenuItem1.Name = "VerEmpresasToolStripMenuItem1"
        Me.VerEmpresasToolStripMenuItem1.Size = New System.Drawing.Size(166, 24)
        Me.VerEmpresasToolStripMenuItem1.Text = "Ver Empresas"
        '
        'FlujoBToolStripMenuItem
        '
        Me.FlujoBToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SubirAControlTesoreriaToolStripMenuItem})
        Me.FlujoBToolStripMenuItem.Name = "FlujoBToolStripMenuItem"
        Me.FlujoBToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.FlujoBToolStripMenuItem.Text = "Flujo B"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(237, 24)
        Me.ToolStripMenuItem1.Text = "Listar"
        '
        'SubirAControlTesoreriaToolStripMenuItem
        '
        Me.SubirAControlTesoreriaToolStripMenuItem.Name = "SubirAControlTesoreriaToolStripMenuItem"
        Me.SubirAControlTesoreriaToolStripMenuItem.Size = New System.Drawing.Size(237, 24)
        Me.SubirAControlTesoreriaToolStripMenuItem.Text = "Subir a control tesoreria"
        '
        'FlujoCToolStripMenuItem
        '
        Me.FlujoCToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsociarComisiónClienteFlujoCToolStripMenuItem, Me.CalcularFlujoCToolStripMenuItem, Me.DescargarReporteToolStripMenuItem, Me.AsociarComisiónClienteFlujoNominaToolStripMenuItem, Me.GuardarCalculoManualToolStripMenuItem})
        Me.FlujoCToolStripMenuItem.Name = "FlujoCToolStripMenuItem"
        Me.FlujoCToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.FlujoCToolStripMenuItem.Text = "Flujo C"
        '
        'AsociarComisiónClienteFlujoCToolStripMenuItem
        '
        Me.AsociarComisiónClienteFlujoCToolStripMenuItem.Name = "AsociarComisiónClienteFlujoCToolStripMenuItem"
        Me.AsociarComisiónClienteFlujoCToolStripMenuItem.Size = New System.Drawing.Size(327, 24)
        Me.AsociarComisiónClienteFlujoCToolStripMenuItem.Text = "Asociar comisión cliente flujo c"
        '
        'CalcularFlujoCToolStripMenuItem
        '
        Me.CalcularFlujoCToolStripMenuItem.Name = "CalcularFlujoCToolStripMenuItem"
        Me.CalcularFlujoCToolStripMenuItem.Size = New System.Drawing.Size(327, 24)
        Me.CalcularFlujoCToolStripMenuItem.Text = "Calcular flujo c"
        '
        'DescargarReporteToolStripMenuItem
        '
        Me.DescargarReporteToolStripMenuItem.Name = "DescargarReporteToolStripMenuItem"
        Me.DescargarReporteToolStripMenuItem.Size = New System.Drawing.Size(327, 24)
        Me.DescargarReporteToolStripMenuItem.Text = "Descargar reporte por empresa"
        '
        'AsociarComisiónClienteFlujoNominaToolStripMenuItem
        '
        Me.AsociarComisiónClienteFlujoNominaToolStripMenuItem.Name = "AsociarComisiónClienteFlujoNominaToolStripMenuItem"
        Me.AsociarComisiónClienteFlujoNominaToolStripMenuItem.Size = New System.Drawing.Size(327, 24)
        Me.AsociarComisiónClienteFlujoNominaToolStripMenuItem.Text = "Asociar comisión cliente flujo nomina"
        '
        'GuardarCalculoManualToolStripMenuItem
        '
        Me.GuardarCalculoManualToolStripMenuItem.Name = "GuardarCalculoManualToolStripMenuItem"
        Me.GuardarCalculoManualToolStripMenuItem.Size = New System.Drawing.Size(327, 24)
        Me.GuardarCalculoManualToolStripMenuItem.Text = "Guardar Calculo Manual"
        '
        'AltaNominasToolStripMenuItem
        '
        Me.AltaNominasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MostrarEmpleadosToolStripMenuItem, Me.ImportarToolStripMenuItem})
        Me.AltaNominasToolStripMenuItem.Name = "AltaNominasToolStripMenuItem"
        Me.AltaNominasToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.AltaNominasToolStripMenuItem.Text = "Alta nominas"
        '
        'MostrarEmpleadosToolStripMenuItem
        '
        Me.MostrarEmpleadosToolStripMenuItem.Name = "MostrarEmpleadosToolStripMenuItem"
        Me.MostrarEmpleadosToolStripMenuItem.Size = New System.Drawing.Size(214, 24)
        Me.MostrarEmpleadosToolStripMenuItem.Text = "Mostrar empleados"
        '
        'ImportarToolStripMenuItem
        '
        Me.ImportarToolStripMenuItem.Name = "ImportarToolStripMenuItem"
        Me.ImportarToolStripMenuItem.Size = New System.Drawing.Size(214, 24)
        Me.ImportarToolStripMenuItem.Text = "Importar empleados"
        '
        'CatalogosToolStripMenuItem
        '
        Me.CatalogosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.EmpresasToolStripMenuItem, Me.TipoEmpresasToolStripMenuItem, Me.PromotoresToolStripMenuItem, Me.ClientePromotorToolStripMenuItem})
        Me.CatalogosToolStripMenuItem.Name = "CatalogosToolStripMenuItem"
        Me.CatalogosToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.CatalogosToolStripMenuItem.Text = "Catalogos"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'EmpresasToolStripMenuItem
        '
        Me.EmpresasToolStripMenuItem.Name = "EmpresasToolStripMenuItem"
        Me.EmpresasToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.EmpresasToolStripMenuItem.Text = "Empresas"
        '
        'TipoEmpresasToolStripMenuItem
        '
        Me.TipoEmpresasToolStripMenuItem.Name = "TipoEmpresasToolStripMenuItem"
        Me.TipoEmpresasToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.TipoEmpresasToolStripMenuItem.Text = "Tipo Empresas"
        '
        'PromotoresToolStripMenuItem
        '
        Me.PromotoresToolStripMenuItem.Name = "PromotoresToolStripMenuItem"
        Me.PromotoresToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.PromotoresToolStripMenuItem.Text = "Promotores"
        '
        'ClientePromotorToolStripMenuItem
        '
        Me.ClientePromotorToolStripMenuItem.Name = "ClientePromotorToolStripMenuItem"
        Me.ClientePromotorToolStripMenuItem.Size = New System.Drawing.Size(193, 24)
        Me.ClientePromotorToolStripMenuItem.Text = "Cliente-Promotor"
        '
        'PlaneaciónToolStripMenuItem
        '
        Me.PlaneaciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SAToolStripMenuItem, Me.ASIMILADOSToolStripMenuItem})
        Me.PlaneaciónToolStripMenuItem.Name = "PlaneaciónToolStripMenuItem"
        Me.PlaneaciónToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.PlaneaciónToolStripMenuItem.Text = "Planeación"
        '
        'SAToolStripMenuItem
        '
        Me.SAToolStripMenuItem.Name = "SAToolStripMenuItem"
        Me.SAToolStripMenuItem.Size = New System.Drawing.Size(151, 24)
        Me.SAToolStripMenuItem.Text = "SA"
        '
        'ASIMILADOSToolStripMenuItem
        '
        Me.ASIMILADOSToolStripMenuItem.Name = "ASIMILADOSToolStripMenuItem"
        Me.ASIMILADOSToolStripMenuItem.Size = New System.Drawing.Size(151, 24)
        Me.ASIMILADOSToolStripMenuItem.Text = "Asimilados"
        '
        'FacturacionToolStripMenuItem
        '
        Me.FacturacionToolStripMenuItem.Name = "FacturacionToolStripMenuItem"
        Me.FacturacionToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.FacturacionToolStripMenuItem.Text = "Facturacion"
        '
        'ControlTesoreriaToolStripMenuItem
        '
        Me.ControlTesoreriaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ControlTesoreriaToolStripMenuItem1, Me.FondeoToolStripMenuItem})
        Me.ControlTesoreriaToolStripMenuItem.Name = "ControlTesoreriaToolStripMenuItem"
        Me.ControlTesoreriaToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.ControlTesoreriaToolStripMenuItem.Text = "Tesoreria"
        '
        'ControlTesoreriaToolStripMenuItem1
        '
        Me.ControlTesoreriaToolStripMenuItem1.Name = "ControlTesoreriaToolStripMenuItem1"
        Me.ControlTesoreriaToolStripMenuItem1.Size = New System.Drawing.Size(189, 24)
        Me.ControlTesoreriaToolStripMenuItem1.Text = "Control tesoreria"
        '
        'FondeoToolStripMenuItem
        '
        Me.FondeoToolStripMenuItem.Name = "FondeoToolStripMenuItem"
        Me.FondeoToolStripMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.FondeoToolStripMenuItem.Text = "Fondeo"
        '
        'NominaToolStripMenuItem
        '
        Me.NominaToolStripMenuItem.Name = "NominaToolStripMenuItem"
        Me.NominaToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.NominaToolStripMenuItem.Text = "Nomina"
        '
        'JuridicoToolStripMenuItem
        '
        Me.JuridicoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MostrarFlujosConceptosToolStripMenuItem, Me.ReportesFlujosConceptosToolStripMenuItem, Me.ImportarFlujosConceptosToolStripMenuItem, Me.ContratToolStripMenuItem})
        Me.JuridicoToolStripMenuItem.Name = "JuridicoToolStripMenuItem"
        Me.JuridicoToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.JuridicoToolStripMenuItem.Text = "Juridico"
        '
        'MostrarFlujosConceptosToolStripMenuItem
        '
        Me.MostrarFlujosConceptosToolStripMenuItem.Name = "MostrarFlujosConceptosToolStripMenuItem"
        Me.MostrarFlujosConceptosToolStripMenuItem.Size = New System.Drawing.Size(255, 24)
        Me.MostrarFlujosConceptosToolStripMenuItem.Text = "Mostrar Flujos-Conceptos"
        '
        'ReportesFlujosConceptosToolStripMenuItem
        '
        Me.ReportesFlujosConceptosToolStripMenuItem.Name = "ReportesFlujosConceptosToolStripMenuItem"
        Me.ReportesFlujosConceptosToolStripMenuItem.Size = New System.Drawing.Size(255, 24)
        Me.ReportesFlujosConceptosToolStripMenuItem.Text = "Reportes Flujos-Conceptos"
        '
        'ImportarFlujosConceptosToolStripMenuItem
        '
        Me.ImportarFlujosConceptosToolStripMenuItem.Name = "ImportarFlujosConceptosToolStripMenuItem"
        Me.ImportarFlujosConceptosToolStripMenuItem.Size = New System.Drawing.Size(255, 24)
        Me.ImportarFlujosConceptosToolStripMenuItem.Text = "Importar Flujos-Conceptos"
        '
        'ContratToolStripMenuItem
        '
        Me.ContratToolStripMenuItem.Name = "ContratToolStripMenuItem"
        Me.ContratToolStripMenuItem.Size = New System.Drawing.Size(255, 24)
        Me.ContratToolStripMenuItem.Text = "Contratros Empresas"
        '
        'ComisionesToolStripMenuItem
        '
        Me.ComisionesToolStripMenuItem.Name = "ComisionesToolStripMenuItem"
        Me.ComisionesToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.ComisionesToolStripMenuItem.Text = "Comisiones"
        '
        'ConciliacionToolStripMenuItem
        '
        Me.ConciliacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SubirDatosBancoToolStripMenuItem, Me.MostrarDatosBancoToolStripMenuItem, Me.ConciliarToolStripMenuItem, Me.Conciliar10ToolStripMenuItem})
        Me.ConciliacionToolStripMenuItem.Name = "ConciliacionToolStripMenuItem"
        Me.ConciliacionToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.ConciliacionToolStripMenuItem.Text = "Conciliacion"
        '
        'SubirDatosBancoToolStripMenuItem
        '
        Me.SubirDatosBancoToolStripMenuItem.Name = "SubirDatosBancoToolStripMenuItem"
        Me.SubirDatosBancoToolStripMenuItem.Size = New System.Drawing.Size(215, 24)
        Me.SubirDatosBancoToolStripMenuItem.Text = "Subir datos Banco"
        '
        'MostrarDatosBancoToolStripMenuItem
        '
        Me.MostrarDatosBancoToolStripMenuItem.Name = "MostrarDatosBancoToolStripMenuItem"
        Me.MostrarDatosBancoToolStripMenuItem.Size = New System.Drawing.Size(215, 24)
        Me.MostrarDatosBancoToolStripMenuItem.Text = "Mostrar datos Banco"
        '
        'ConciliarToolStripMenuItem
        '
        Me.ConciliarToolStripMenuItem.Name = "ConciliarToolStripMenuItem"
        Me.ConciliarToolStripMenuItem.Size = New System.Drawing.Size(215, 24)
        Me.ConciliarToolStripMenuItem.Text = "Conciliar"
        '
        'Conciliar10ToolStripMenuItem
        '
        Me.Conciliar10ToolStripMenuItem.Name = "Conciliar10ToolStripMenuItem"
        Me.Conciliar10ToolStripMenuItem.Size = New System.Drawing.Size(215, 24)
        Me.Conciliar10ToolStripMenuItem.Text = "Conciliar 1.0"
        '
        'GastosToolStripMenuItem
        '
        Me.GastosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarGastosToolStripMenuItem, Me.MostrarGastosToolStripMenuItem})
        Me.GastosToolStripMenuItem.Name = "GastosToolStripMenuItem"
        Me.GastosToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.GastosToolStripMenuItem.Text = "Gastos"
        '
        'ImportarGastosToolStripMenuItem
        '
        Me.ImportarGastosToolStripMenuItem.Name = "ImportarGastosToolStripMenuItem"
        Me.ImportarGastosToolStripMenuItem.Size = New System.Drawing.Size(183, 24)
        Me.ImportarGastosToolStripMenuItem.Text = "Importar gastos"
        '
        'MostrarGastosToolStripMenuItem
        '
        Me.MostrarGastosToolStripMenuItem.Name = "MostrarGastosToolStripMenuItem"
        Me.MostrarGastosToolStripMenuItem.Size = New System.Drawing.Size(183, 24)
        Me.MostrarGastosToolStripMenuItem.Text = "Mostrar gastos"
        '
        'KioskoClientesToolStripMenuItem
        '
        Me.KioskoClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsociarClientesEmpresasToolStripMenuItem, Me.AgregarDatoContabilidadToolStripMenuItem, Me.AgregarDatosNominasToolStripMenuItem, Me.AgregarDatosJuridicoToolStripMenuItem})
        Me.KioskoClientesToolStripMenuItem.Name = "KioskoClientesToolStripMenuItem"
        Me.KioskoClientesToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.KioskoClientesToolStripMenuItem.Text = "Kiosko Clientes"
        '
        'AsociarClientesEmpresasToolStripMenuItem
        '
        Me.AsociarClientesEmpresasToolStripMenuItem.Name = "AsociarClientesEmpresasToolStripMenuItem"
        Me.AsociarClientesEmpresasToolStripMenuItem.Size = New System.Drawing.Size(261, 24)
        Me.AsociarClientesEmpresasToolStripMenuItem.Text = "Asociar Clientes-Empresas"
        '
        'AgregarDatoContabilidadToolStripMenuItem
        '
        Me.AgregarDatoContabilidadToolStripMenuItem.Name = "AgregarDatoContabilidadToolStripMenuItem"
        Me.AgregarDatoContabilidadToolStripMenuItem.Size = New System.Drawing.Size(261, 24)
        Me.AgregarDatoContabilidadToolStripMenuItem.Text = "Agregar datos contabilidad"
        '
        'AgregarDatosNominasToolStripMenuItem
        '
        Me.AgregarDatosNominasToolStripMenuItem.Name = "AgregarDatosNominasToolStripMenuItem"
        Me.AgregarDatosNominasToolStripMenuItem.Size = New System.Drawing.Size(261, 24)
        Me.AgregarDatosNominasToolStripMenuItem.Text = "Agregar datos nominas"
        '
        'AgregarDatosJuridicoToolStripMenuItem
        '
        Me.AgregarDatosJuridicoToolStripMenuItem.Name = "AgregarDatosJuridicoToolStripMenuItem"
        Me.AgregarDatosJuridicoToolStripMenuItem.Size = New System.Drawing.Size(261, 24)
        Me.AgregarDatosJuridicoToolStripMenuItem.Text = "Agregar datos imss"
        '
        'mnuSalir
        '
        Me.mnuSalir.Image = CType(resources.GetObject("mnuSalir.Image"), System.Drawing.Image)
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(202, 38)
        Me.mnuSalir.Text = "Salir del sistema"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(449, 170)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(309, 213)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'frmPrincipal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(724, 477)
        Me.Controls.Add(Me.pnlBar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lsvPanel)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlBar.ResumeLayout(False)
        Me.pnlBar.PerformLayout()
        Me.MenuInicio.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBar As System.Windows.Forms.Panel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkCBB As System.Windows.Forms.CheckBox
    Friend WithEvents chkCFDI As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lsvPanel As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MenuInicio As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CatalogosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmpresasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoEmpresasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AltaNominasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NominaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComisionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PromotoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConciliacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlTesoreriaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GastosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarGastosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostrarGastosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContpaqToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerEmpresasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FlujoBToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SubirAControlTesoreriaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlaneaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImssToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerEmpresasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ASIMILADOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientePromotorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KioskoClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsociarClientesEmpresasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregarDatoContabilidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregarDatosNominasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregarDatosJuridicoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FlujoCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsociarComisiónClienteFlujoCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalcularFlujoCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DescargarReporteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsociarComisiónClienteFlujoNominaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarCalculoManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JuridicoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostrarFlujosConceptosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesFlujosConceptosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostrarEmpleadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubirDatosBancoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MostrarDatosBancoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConciliarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Conciliar10ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlTesoreriaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FondeoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents ContratToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportarFlujosConceptosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
