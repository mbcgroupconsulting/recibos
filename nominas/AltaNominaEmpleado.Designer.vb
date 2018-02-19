<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaNominaEmpleado
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
        Me.pnlVentana = New System.Windows.Forms.Panel()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbActivos = New System.Windows.Forms.RadioButton()
        Me.lbldireccion = New System.Windows.Forms.Label()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdnuevo = New System.Windows.Forms.Button()
        Me.cmdmostrar = New System.Windows.Forms.Button()
        Me.cbosucursales = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboempresas = New System.Windows.Forms.ComboBox()
        Me.cboclientes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdexcel = New System.Windows.Forms.Button()
        Me.pnlVentana.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVentana
        '
        Me.pnlVentana.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlVentana.Controls.Add(Me.txtCodigo)
        Me.pnlVentana.Controls.Add(Me.Panel1)
        Me.pnlVentana.Controls.Add(Me.lbldireccion)
        Me.pnlVentana.Controls.Add(Me.lsvLista)
        Me.pnlVentana.Controls.Add(Me.Button1)
        Me.pnlVentana.Controls.Add(Me.cmdnuevo)
        Me.pnlVentana.Controls.Add(Me.cmdmostrar)
        Me.pnlVentana.Controls.Add(Me.cbosucursales)
        Me.pnlVentana.Controls.Add(Me.Label3)
        Me.pnlVentana.Controls.Add(Me.cboempresas)
        Me.pnlVentana.Controls.Add(Me.cboclientes)
        Me.pnlVentana.Controls.Add(Me.Label2)
        Me.pnlVentana.Controls.Add(Me.Label1)
        Me.pnlVentana.Location = New System.Drawing.Point(5, 3)
        Me.pnlVentana.Name = "pnlVentana"
        Me.pnlVentana.Size = New System.Drawing.Size(863, 437)
        Me.pnlVentana.TabIndex = 10
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
        Me.lsvLista.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvLista.FullRowSelect = True
        Me.lsvLista.GridLines = True
        Me.lsvLista.HideSelection = False
        Me.lsvLista.Location = New System.Drawing.Point(5, 124)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(855, 310)
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
        'cbosucursales
        '
        Me.cbosucursales.FormattingEnabled = True
        Me.cbosucursales.Location = New System.Drawing.Point(91, 47)
        Me.cbosucursales.Name = "cbosucursales"
        Me.cbosucursales.Size = New System.Drawing.Size(330, 26)
        Me.cbosucursales.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 18)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Sucursales:"
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
        'cmdexcel
        '
        Me.cmdexcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdexcel.Location = New System.Drawing.Point(756, 446)
        Me.cmdexcel.Name = "cmdexcel"
        Me.cmdexcel.Size = New System.Drawing.Size(112, 26)
        Me.cmdexcel.TabIndex = 23
        Me.cmdexcel.Text = "Enviar a excel"
        Me.cmdexcel.UseVisualStyleBackColor = True
        '
        'AltaNominaEmpleado
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(872, 484)
        Me.Controls.Add(Me.cmdexcel)
        Me.Controls.Add(Me.pnlVentana)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AltaNominaEmpleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta nomina"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlVentana.ResumeLayout(False)
        Me.pnlVentana.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlVentana As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdnuevo As System.Windows.Forms.Button
    Friend WithEvents cmdmostrar As System.Windows.Forms.Button
    Friend WithEvents cbosucursales As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboempresas As System.Windows.Forms.ComboBox
    Friend WithEvents cboclientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lsvLista As System.Windows.Forms.ListView
    Friend WithEvents lbldireccion As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbActivos As System.Windows.Forms.RadioButton
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cmdexcel As Button
End Class
