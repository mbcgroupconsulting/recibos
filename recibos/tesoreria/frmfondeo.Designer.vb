<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFondeo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFondeo))
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.chkAllEmpresas = New System.Windows.Forms.CheckBox()
        Me.cboempresa = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.chkfecha = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbBuscar = New System.Windows.Forms.ToolStripButton()
        Me.tsbProcesar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.pnlProgreso = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar()
        Me.pnlCatalogo.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlProgreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(1092, 567)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.cmdCerrar.Size = New System.Drawing.Size(104, 43)
        Me.cmdCerrar.TabIndex = 43
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.chkAllEmpresas)
        Me.pnlCatalogo.Controls.Add(Me.cboempresa)
        Me.pnlCatalogo.Controls.Add(Me.Label9)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechafin)
        Me.pnlCatalogo.Controls.Add(Me.Label1)
        Me.pnlCatalogo.Controls.Add(Me.Label3)
        Me.pnlCatalogo.Controls.Add(Me.dtpfechainicio)
        Me.pnlCatalogo.Controls.Add(Me.chkfecha)
        Me.pnlCatalogo.Controls.Add(Me.chkAll)
        Me.pnlCatalogo.Controls.Add(Me.lsvLista)
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 60)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(1208, 501)
        Me.pnlCatalogo.TabIndex = 42
        '
        'chkAllEmpresas
        '
        Me.chkAllEmpresas.AutoSize = True
        Me.chkAllEmpresas.Location = New System.Drawing.Point(222, 50)
        Me.chkAllEmpresas.Name = "chkAllEmpresas"
        Me.chkAllEmpresas.Size = New System.Drawing.Size(156, 23)
        Me.chkAllEmpresas.TabIndex = 50
        Me.chkAllEmpresas.Text = "Todas las empresas"
        Me.chkAllEmpresas.UseVisualStyleBackColor = True
        '
        'cboempresa
        '
        Me.cboempresa.FormattingEnabled = True
        Me.cboempresa.Location = New System.Drawing.Point(102, 16)
        Me.cboempresa.Name = "cboempresa"
        Me.cboempresa.Size = New System.Drawing.Size(471, 27)
        Me.cboempresa.TabIndex = 49
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
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(770, 48)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechafin.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(736, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 19)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Fin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(585, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 19)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(635, 49)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechainicio.TabIndex = 43
        '
        'chkfecha
        '
        Me.chkfecha.AutoSize = True
        Me.chkfecha.Checked = True
        Me.chkfecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkfecha.Location = New System.Drawing.Point(635, 20)
        Me.chkfecha.Name = "chkfecha"
        Me.chkfecha.Size = New System.Drawing.Size(136, 23)
        Me.chkfecha.TabIndex = 39
        Me.chkfecha.Text = "Rango de fechas"
        Me.chkfecha.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(3, 59)
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
        Me.lsvLista.Location = New System.Drawing.Point(1, 83)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(1200, 411)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbBuscar, Me.tsbProcesar, Me.tsbCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1208, 54)
        Me.ToolStrip1.TabIndex = 40
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbBuscar
        '
        Me.tsbBuscar.Image = Global.recibos.My.Resources.Resources._1359876031_folder_search
        Me.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBuscar.Name = "tsbBuscar"
        Me.tsbBuscar.Size = New System.Drawing.Size(78, 51)
        Me.tsbBuscar.Text = "Buscar datos"
        Me.tsbBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbBuscar.ToolTipText = "Cargar datos"
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
        'pnlProgreso
        '
        Me.pnlProgreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlProgreso.Controls.Add(Me.Label2)
        Me.pnlProgreso.Controls.Add(Me.pgbProgreso)
        Me.pnlProgreso.Location = New System.Drawing.Point(380, 320)
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
        'frmFondeo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1208, 613)
        Me.Controls.Add(Me.pnlProgreso)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmFondeo"
        Me.Text = "Realizar conciliación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlProgreso.ResumeLayout(False)
        Me.pnlProgreso.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlCatalogo As System.Windows.Forms.Panel
    Friend WithEvents cboempresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpfechafin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpfechainicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkfecha As System.Windows.Forms.CheckBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents lsvLista As System.Windows.Forms.ListView
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbProcesar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlProgreso As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pgbProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkAllEmpresas As System.Windows.Forms.CheckBox
End Class
