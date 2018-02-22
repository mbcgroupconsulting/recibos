<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpleadosXCliente
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
        Me.pnlVentana = New System.Windows.Forms.Panel()
        Me.btnDepto = New System.Windows.Forms.Button()
        Me.btnPuestoN = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbActivos = New System.Windows.Forms.RadioButton()
        Me.lbldireccion = New System.Windows.Forms.Label()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdnuevo = New System.Windows.Forms.Button()
        Me.cmdmostrar = New System.Windows.Forms.Button()
        Me.cboempresas = New System.Windows.Forms.ComboBox()
        Me.cboclientes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbosucursales = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdexcel = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.pnlVentana.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVentana
        '
        Me.pnlVentana.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlVentana.Controls.Add(Me.btnDepto)
        Me.pnlVentana.Controls.Add(Me.btnPuestoN)
        Me.pnlVentana.Controls.Add(Me.txtCodigo)
        Me.pnlVentana.Controls.Add(Me.Panel1)
        Me.pnlVentana.Controls.Add(Me.lbldireccion)
        Me.pnlVentana.Controls.Add(Me.lsvLista)
        Me.pnlVentana.Controls.Add(Me.Button1)
        Me.pnlVentana.Controls.Add(Me.cmdnuevo)
        Me.pnlVentana.Controls.Add(Me.cmdmostrar)
        Me.pnlVentana.Controls.Add(Me.cboempresas)
        Me.pnlVentana.Controls.Add(Me.cboclientes)
        Me.pnlVentana.Controls.Add(Me.Label2)
        Me.pnlVentana.Controls.Add(Me.Label1)
        Me.pnlVentana.Location = New System.Drawing.Point(5, 6)
        Me.pnlVentana.Name = "pnlVentana"
        Me.pnlVentana.Size = New System.Drawing.Size(1012, 414)
        Me.pnlVentana.TabIndex = 12
        '
        'btnDepto
        '
        Me.btnDepto.Location = New System.Drawing.Point(842, 63)
        Me.btnDepto.Name = "btnDepto"
        Me.btnDepto.Size = New System.Drawing.Size(130, 41)
        Me.btnDepto.TabIndex = 24
        Me.btnDepto.Text = "Agregar Dpto."
        Me.btnDepto.UseVisualStyleBackColor = True
        '
        'btnPuestoN
        '
        Me.btnPuestoN.Location = New System.Drawing.Point(841, 6)
        Me.btnPuestoN.Name = "btnPuestoN"
        Me.btnPuestoN.Size = New System.Drawing.Size(131, 51)
        Me.btnPuestoN.TabIndex = 23
        Me.btnPuestoN.Text = "Agrear Puesto a empresa"
        Me.btnPuestoN.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(223, 93)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(180, 26)
        Me.txtCodigo.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbTodos)
        Me.Panel1.Controls.Add(Me.rbActivos)
        Me.Panel1.Location = New System.Drawing.Point(497, 93)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 26)
        Me.Panel1.TabIndex = 21
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(123, 2)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(130, 22)
        Me.rbTodos.TabIndex = 1
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Activos/Inactivos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbActivos
        '
        Me.rbActivos.AutoSize = True
        Me.rbActivos.Checked = True
        Me.rbActivos.Location = New System.Drawing.Point(7, 2)
        Me.rbActivos.Name = "rbActivos"
        Me.rbActivos.Size = New System.Drawing.Size(98, 22)
        Me.rbActivos.TabIndex = 0
        Me.rbActivos.TabStop = True
        Me.rbActivos.Text = "Solo activos"
        Me.rbActivos.UseVisualStyleBackColor = True
        '
        'lbldireccion
        '
        Me.lbldireccion.AutoSize = True
        Me.lbldireccion.Location = New System.Drawing.Point(486, 39)
        Me.lbldireccion.Name = "lbldireccion"
        Me.lbldireccion.Size = New System.Drawing.Size(77, 18)
        Me.lbldireccion.TabIndex = 20
        Me.lbldireccion.Text = "Sucursales:"
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
        Me.lsvLista.Location = New System.Drawing.Point(5, 124)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(1004, 287)
        Me.lsvLista.TabIndex = 19
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(409, 93)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 26)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdnuevo
        '
        Me.cmdnuevo.Location = New System.Drawing.Point(117, 93)
        Me.cmdnuevo.Name = "cmdnuevo"
        Me.cmdnuevo.Size = New System.Drawing.Size(75, 26)
        Me.cmdnuevo.TabIndex = 17
        Me.cmdnuevo.Text = "Nuevo"
        Me.cmdnuevo.UseVisualStyleBackColor = True
        '
        'cmdmostrar
        '
        Me.cmdmostrar.Location = New System.Drawing.Point(21, 93)
        Me.cmdmostrar.Name = "cmdmostrar"
        Me.cmdmostrar.Size = New System.Drawing.Size(75, 26)
        Me.cmdmostrar.TabIndex = 16
        Me.cmdmostrar.Text = "Mostrar"
        Me.cmdmostrar.UseVisualStyleBackColor = True
        '
        'cboempresas
        '
        Me.cboempresas.FormattingEnabled = True
        Me.cboempresas.Location = New System.Drawing.Point(489, 10)
        Me.cboempresas.Name = "cboempresas"
        Me.cboempresas.Size = New System.Drawing.Size(340, 26)
        Me.cboempresas.TabIndex = 13
        '
        'cboclientes
        '
        Me.cboclientes.FormattingEnabled = True
        Me.cboclientes.Location = New System.Drawing.Point(81, 10)
        Me.cboclientes.Name = "cboclientes"
        Me.cboclientes.Size = New System.Drawing.Size(340, 26)
        Me.cboclientes.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(427, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Empresa:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Cliente:"
        '
        'cbosucursales
        '
        Me.cbosucursales.FormattingEnabled = True
        Me.cbosucursales.Location = New System.Drawing.Point(122, 446)
        Me.cbosucursales.Name = "cbosucursales"
        Me.cbosucursales.Size = New System.Drawing.Size(330, 26)
        Me.cbosucursales.TabIndex = 15
        Me.cbosucursales.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 449)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 18)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Sucursales:"
        Me.Label3.Visible = False
        '
        'cmdexcel
        '
        Me.cmdexcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdexcel.Location = New System.Drawing.Point(902, 446)
        Me.cmdexcel.Name = "cmdexcel"
        Me.cmdexcel.Size = New System.Drawing.Size(112, 26)
        Me.cmdexcel.TabIndex = 24
        Me.cmdexcel.Text = "Enviar a excel"
        Me.cmdexcel.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(751, 447)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(145, 24)
        Me.btnExport.TabIndex = 25
        Me.btnExport.Text = "Exportar CONTPAQ"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmEmpleadosXCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1021, 484)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.cmdexcel)
        Me.Controls.Add(Me.pnlVentana)
        Me.Controls.Add(Me.cbosucursales)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmEmpleadosXCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empleados asociados a una empresa y cliente"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlVentana.ResumeLayout(False)
        Me.pnlVentana.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlVentana As Panel
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents rbActivos As RadioButton
    Friend WithEvents lbldireccion As Label
    Friend WithEvents lsvLista As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents cmdnuevo As Button
    Friend WithEvents cmdmostrar As Button
    Friend WithEvents cbosucursales As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboempresas As ComboBox
    Friend WithEvents cboclientes As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdexcel As Button
    Friend WithEvents btnPuestoN As System.Windows.Forms.Button
    Friend WithEvents btnDepto As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
End Class
