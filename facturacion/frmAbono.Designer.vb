<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbono
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdBorrar = New System.Windows.Forms.Button()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.txtimporte = New System.Windows.Forms.TextBox()
        Me.txtcomentario = New System.Windows.Forms.TextBox()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.lblnumfactura = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblabono = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblfaltante = New System.Windows.Forms.Label()
        Me.grbfechas = New System.Windows.Forms.GroupBox()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.grbfechas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Factura Num:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha de pago:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Importe:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Observaciones:"
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Location = New System.Drawing.Point(127, 191)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(91, 27)
        Me.cmdAgregar.TabIndex = 4
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdBorrar
        '
        Me.cmdBorrar.Location = New System.Drawing.Point(379, 191)
        Me.cmdBorrar.Name = "cmdBorrar"
        Me.cmdBorrar.Size = New System.Drawing.Size(91, 27)
        Me.cmdBorrar.TabIndex = 5
        Me.cmdBorrar.Text = "Borrar"
        Me.cmdBorrar.UseVisualStyleBackColor = True
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(125, 87)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(96, 27)
        Me.dtpfecha.TabIndex = 6
        '
        'txtimporte
        '
        Me.txtimporte.Location = New System.Drawing.Point(125, 120)
        Me.txtimporte.Name = "txtimporte"
        Me.txtimporte.Size = New System.Drawing.Size(122, 27)
        Me.txtimporte.TabIndex = 25
        Me.txtimporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcomentario
        '
        Me.txtcomentario.Location = New System.Drawing.Point(125, 153)
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.Size = New System.Drawing.Size(334, 27)
        Me.txtcomentario.TabIndex = 32
        Me.txtcomentario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Location = New System.Drawing.Point(250, 191)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(91, 27)
        Me.cmdcancelar.TabIndex = 33
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.UseVisualStyleBackColor = True
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
        Me.lsvLista.Location = New System.Drawing.Point(3, 244)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(667, 210)
        Me.lsvLista.TabIndex = 34
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'lblnumfactura
        '
        Me.lblnumfactura.AutoSize = True
        Me.lblnumfactura.Location = New System.Drawing.Point(113, 9)
        Me.lblnumfactura.Name = "lblnumfactura"
        Me.lblnumfactura.Size = New System.Drawing.Size(95, 19)
        Me.lblnumfactura.TabIndex = 35
        Me.lblnumfactura.Text = "Factura Num:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(214, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 19)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Total Factura:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbltotal
        '
        Me.lbltotal.Location = New System.Drawing.Point(308, 9)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(97, 19)
        Me.lbltotal.TabIndex = 37
        Me.lbltotal.Text = "Total Factura:"
        Me.lbltotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(222, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Total abono:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblabono
        '
        Me.lblabono.Location = New System.Drawing.Point(308, 38)
        Me.lblabono.Name = "lblabono"
        Me.lblabono.Size = New System.Drawing.Size(97, 19)
        Me.lblabono.TabIndex = 39
        Me.lblabono.Text = "Total Factura:"
        Me.lblabono.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(228, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 19)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Por abonar:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblfaltante
        '
        Me.lblfaltante.Location = New System.Drawing.Point(308, 66)
        Me.lblfaltante.Name = "lblfaltante"
        Me.lblfaltante.Size = New System.Drawing.Size(97, 19)
        Me.lblfaltante.TabIndex = 41
        Me.lblfaltante.Text = "Total Factura:"
        Me.lblfaltante.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grbfechas
        '
        Me.grbfechas.Controls.Add(Me.dtpfechafin)
        Me.grbfechas.Controls.Add(Me.Label8)
        Me.grbfechas.Controls.Add(Me.Label9)
        Me.grbfechas.Controls.Add(Me.dtpfechainicio)
        Me.grbfechas.Location = New System.Drawing.Point(411, 9)
        Me.grbfechas.Name = "grbfechas"
        Me.grbfechas.Size = New System.Drawing.Size(259, 93)
        Me.grbfechas.TabIndex = 42
        Me.grbfechas.TabStop = False
        Me.grbfechas.Text = "Rango de fechas, abonos sin factura"
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(139, 47)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechafin.TabIndex = 40
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(135, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 19)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Fecha fin"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(28, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 19)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(28, 49)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechainicio.TabIndex = 37
        '
        'frmAbono
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(675, 466)
        Me.Controls.Add(Me.grbfechas)
        Me.Controls.Add(Me.lblfaltante)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblabono)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblnumfactura)
        Me.Controls.Add(Me.lsvLista)
        Me.Controls.Add(Me.cmdcancelar)
        Me.Controls.Add(Me.txtcomentario)
        Me.Controls.Add(Me.txtimporte)
        Me.Controls.Add(Me.dtpfecha)
        Me.Controls.Add(Me.cmdBorrar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAbono"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abonos a factura"
        Me.grbfechas.ResumeLayout(False)
        Me.grbfechas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdBorrar As Button
    Friend WithEvents dtpfecha As DateTimePicker
    Friend WithEvents txtimporte As TextBox
    Friend WithEvents txtcomentario As TextBox
    Friend WithEvents cmdcancelar As Button
    Friend WithEvents lsvLista As ListView
    Friend WithEvents lblnumfactura As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbltotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblabono As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblfaltante As Label
    Friend WithEvents grbfechas As GroupBox
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
End Class
