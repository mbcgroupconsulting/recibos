<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteConceptoJuridico
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
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chktodas = New System.Windows.Forms.CheckBox()
        Me.cmdgeneral = New System.Windows.Forms.Button()
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
        Me.pnlCatalogo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.Panel2)
        Me.pnlCatalogo.Controls.Add(Me.cmdgeneral)
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
        Me.pnlCatalogo.Location = New System.Drawing.Point(6, 6)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(982, 603)
        Me.pnlCatalogo.TabIndex = 23
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chktodas)
        Me.Panel2.Location = New System.Drawing.Point(454, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(448, 29)
        Me.Panel2.TabIndex = 45
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
        'cmdgeneral
        '
        Me.cmdgeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdgeneral.Location = New System.Drawing.Point(256, 152)
        Me.cmdgeneral.Name = "cmdgeneral"
        Me.cmdgeneral.Size = New System.Drawing.Size(179, 29)
        Me.cmdgeneral.TabIndex = 38
        Me.cmdgeneral.Text = "Generar a excel"
        Me.cmdgeneral.UseVisualStyleBackColor = True
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(112, 124)
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
        Me.Panel1.Size = New System.Drawing.Size(958, 40)
        Me.Panel1.TabIndex = 35
        '
        'rdbbuscar
        '
        Me.rdbbuscar.AutoSize = True
        Me.rdbbuscar.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbbuscar.Location = New System.Drawing.Point(312, 6)
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
        Me.lsvLista.Location = New System.Drawing.Point(10, 197)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(958, 399)
        Me.lsvLista.TabIndex = 34
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.Location = New System.Drawing.Point(50, 152)
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
        Me.Label10.Location = New System.Drawing.Point(572, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 19)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Factura a buscar"
        '
        'cboclientes
        '
        Me.cboclientes.FormattingEnabled = True
        Me.cboclientes.Items.AddRange(New Object() {"Activa", "Cancelada"})
        Me.cboclientes.Location = New System.Drawing.Point(216, 121)
        Me.cboclientes.Name = "cboclientes"
        Me.cboclientes.Size = New System.Drawing.Size(354, 21)
        Me.cboclientes.TabIndex = 20
        '
        'txtbuscar
        '
        Me.txtbuscar.Location = New System.Drawing.Point(576, 121)
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
        Me.Label5.Location = New System.Drawing.Point(212, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 19)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Clientes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(112, 102)
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
        Me.Label1.Location = New System.Drawing.Point(10, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(10, 124)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechainicio.TabIndex = 5
        '
        'frmReporteConceptoJuridico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 615)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Name = "frmReporteConceptoJuridico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReporteConceptoJuridico"
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCatalogo As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chktodas As CheckBox
    Friend WithEvents cmdgeneral As Button
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdbbuscar As RadioButton
    Friend WithEvents rdbcliente As RadioButton
    Friend WithEvents rdbfechas As RadioButton
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
End Class
