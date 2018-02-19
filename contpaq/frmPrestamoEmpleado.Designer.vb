<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrestamoEmpleado
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
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.txtimporte = New System.Windows.Forms.TextBox()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.cmdimprimirpagos = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdpagos = New System.Windows.Forms.Button()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
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
        Me.lsvLista.Location = New System.Drawing.Point(4, 138)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(667, 126)
        Me.lsvLista.TabIndex = 53
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Location = New System.Drawing.Point(241, 105)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(91, 27)
        Me.cmdcancelar.TabIndex = 52
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'txtimporte
        '
        Me.txtimporte.Location = New System.Drawing.Point(126, 37)
        Me.txtimporte.Name = "txtimporte"
        Me.txtimporte.Size = New System.Drawing.Size(122, 26)
        Me.txtimporte.TabIndex = 50
        Me.txtimporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(126, 4)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(96, 26)
        Me.dtpfecha.TabIndex = 49
        '
        'cmdimprimirpagos
        '
        Me.cmdimprimirpagos.Location = New System.Drawing.Point(482, 105)
        Me.cmdimprimirpagos.Name = "cmdimprimirpagos"
        Me.cmdimprimirpagos.Size = New System.Drawing.Size(111, 27)
        Me.cmdimprimirpagos.TabIndex = 48
        Me.cmdimprimirpagos.Text = "Reporte pagos"
        Me.cmdimprimirpagos.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Location = New System.Drawing.Point(128, 105)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(91, 27)
        Me.cmdAgregar.TabIndex = 47
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 18)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Importe:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Fecha prestamo:"
        '
        'cmdpagos
        '
        Me.cmdpagos.Location = New System.Drawing.Point(349, 105)
        Me.cmdpagos.Name = "cmdpagos"
        Me.cmdpagos.Size = New System.Drawing.Size(111, 27)
        Me.cmdpagos.TabIndex = 62
        Me.cmdpagos.Text = "Mostrar pagos"
        Me.cmdpagos.UseVisualStyleBackColor = True
        '
        'txtdescuento
        '
        Me.txtdescuento.Location = New System.Drawing.Point(126, 69)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(122, 26)
        Me.txtdescuento.TabIndex = 63
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 18)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Descuento:"
        '
        'frmPrestamoEmpleado
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(675, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.cmdpagos)
        Me.Controls.Add(Me.lsvLista)
        Me.Controls.Add(Me.cmdcancelar)
        Me.Controls.Add(Me.txtimporte)
        Me.Controls.Add(Me.dtpfecha)
        Me.Controls.Add(Me.cmdimprimirpagos)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPrestamoEmpleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prestamo empleados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lsvLista As ListView
    Friend WithEvents cmdcancelar As Button
    Friend WithEvents txtimporte As TextBox
    Friend WithEvents dtpfecha As DateTimePicker
    Friend WithEvents cmdimprimirpagos As Button
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdpagos As Button
    Friend WithEvents txtdescuento As TextBox
    Friend WithEvents Label1 As Label
End Class
