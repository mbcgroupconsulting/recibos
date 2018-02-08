<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmfiltro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grbtipoempresa = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rdbiva = New System.Windows.Forms.RadioButton()
        Me.rdbpatrona = New System.Windows.Forms.RadioButton()
        Me.rdbintermediaria = New System.Windows.Forms.RadioButton()
        Me.grbestatus = New System.Windows.Forms.GroupBox()
        Me.rdbnopagadas = New System.Windows.Forms.RadioButton()
        Me.rdbpagadas = New System.Windows.Forms.RadioButton()
        Me.rdbTodas = New System.Windows.Forms.RadioButton()
        Me.cmdgenerar = New System.Windows.Forms.Button()
        Me.grbfechas = New System.Windows.Forms.GroupBox()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbPago = New System.Windows.Forms.RadioButton()
        Me.rdbfacturacion = New System.Windows.Forms.RadioButton()
        Me.cmdFacturas = New System.Windows.Forms.Button()
        Me.cmdduplicadas = New System.Windows.Forms.Button()
        Me.cmdabonos = New System.Windows.Forms.Button()
        Me.cmdfacturasabonos = New System.Windows.Forms.Button()
        Me.cmdsinabonos = New System.Windows.Forms.Button()
        Me.cmdabonosmas = New System.Windows.Forms.Button()
        Me.cmdabonos2 = New System.Windows.Forms.Button()
        Me.grbplazas = New System.Windows.Forms.GroupBox()
        Me.cboplaza = New System.Windows.Forms.ComboBox()
        Me.chkplazas = New System.Windows.Forms.CheckBox()
        Me.grbtipoempresa.SuspendLayout()
        Me.grbestatus.SuspendLayout()
        Me.grbfechas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbplazas.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbtipoempresa
        '
        Me.grbtipoempresa.Controls.Add(Me.RadioButton1)
        Me.grbtipoempresa.Controls.Add(Me.rdbiva)
        Me.grbtipoempresa.Controls.Add(Me.rdbpatrona)
        Me.grbtipoempresa.Controls.Add(Me.rdbintermediaria)
        Me.grbtipoempresa.Location = New System.Drawing.Point(22, 12)
        Me.grbtipoempresa.Name = "grbtipoempresa"
        Me.grbtipoempresa.Size = New System.Drawing.Size(328, 76)
        Me.grbtipoempresa.TabIndex = 2
        Me.grbtipoempresa.TabStop = False
        Me.grbtipoempresa.Text = "Tipo de empresa"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(13, 32)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(68, 22)
        Me.RadioButton1.TabIndex = 3
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Todas"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rdbiva
        '
        Me.rdbiva.AutoSize = True
        Me.rdbiva.Location = New System.Drawing.Point(282, 32)
        Me.rdbiva.Name = "rdbiva"
        Me.rdbiva.Size = New System.Drawing.Size(44, 22)
        Me.rdbiva.TabIndex = 2
        Me.rdbiva.Text = "Iva"
        Me.rdbiva.UseVisualStyleBackColor = True
        '
        'rdbpatrona
        '
        Me.rdbpatrona.AutoSize = True
        Me.rdbpatrona.Location = New System.Drawing.Point(198, 32)
        Me.rdbpatrona.Name = "rdbpatrona"
        Me.rdbpatrona.Size = New System.Drawing.Size(78, 22)
        Me.rdbpatrona.TabIndex = 1
        Me.rdbpatrona.Text = "Patrona"
        Me.rdbpatrona.UseVisualStyleBackColor = True
        '
        'rdbintermediaria
        '
        Me.rdbintermediaria.AutoSize = True
        Me.rdbintermediaria.Location = New System.Drawing.Point(87, 32)
        Me.rdbintermediaria.Name = "rdbintermediaria"
        Me.rdbintermediaria.Size = New System.Drawing.Size(110, 22)
        Me.rdbintermediaria.TabIndex = 0
        Me.rdbintermediaria.Text = "Intermediaria"
        Me.rdbintermediaria.UseVisualStyleBackColor = True
        '
        'grbestatus
        '
        Me.grbestatus.Controls.Add(Me.rdbnopagadas)
        Me.grbestatus.Controls.Add(Me.rdbpagadas)
        Me.grbestatus.Controls.Add(Me.rdbTodas)
        Me.grbestatus.Location = New System.Drawing.Point(22, 94)
        Me.grbestatus.Name = "grbestatus"
        Me.grbestatus.Size = New System.Drawing.Size(326, 60)
        Me.grbestatus.TabIndex = 3
        Me.grbestatus.TabStop = False
        Me.grbestatus.Text = "Pagada/No pagada"
        '
        'rdbnopagadas
        '
        Me.rdbnopagadas.AutoSize = True
        Me.rdbnopagadas.Location = New System.Drawing.Point(205, 23)
        Me.rdbnopagadas.Name = "rdbnopagadas"
        Me.rdbnopagadas.Size = New System.Drawing.Size(106, 22)
        Me.rdbnopagadas.TabIndex = 5
        Me.rdbnopagadas.Text = "No pagadas"
        Me.rdbnopagadas.UseVisualStyleBackColor = True
        '
        'rdbpagadas
        '
        Me.rdbpagadas.AutoSize = True
        Me.rdbpagadas.Location = New System.Drawing.Point(102, 23)
        Me.rdbpagadas.Name = "rdbpagadas"
        Me.rdbpagadas.Size = New System.Drawing.Size(84, 22)
        Me.rdbpagadas.TabIndex = 4
        Me.rdbpagadas.Text = "Pagadas"
        Me.rdbpagadas.UseVisualStyleBackColor = True
        '
        'rdbTodas
        '
        Me.rdbTodas.AutoSize = True
        Me.rdbTodas.Checked = True
        Me.rdbTodas.Location = New System.Drawing.Point(13, 23)
        Me.rdbTodas.Name = "rdbTodas"
        Me.rdbTodas.Size = New System.Drawing.Size(68, 22)
        Me.rdbTodas.TabIndex = 3
        Me.rdbTodas.TabStop = True
        Me.rdbTodas.Text = "Todas"
        Me.rdbTodas.UseVisualStyleBackColor = True
        '
        'cmdgenerar
        '
        Me.cmdgenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdgenerar.Location = New System.Drawing.Point(354, 334)
        Me.cmdgenerar.Name = "cmdgenerar"
        Me.cmdgenerar.Size = New System.Drawing.Size(178, 46)
        Me.cmdgenerar.TabIndex = 4
        Me.cmdgenerar.Text = "Generar Control Informativo"
        Me.cmdgenerar.UseVisualStyleBackColor = True
        '
        'grbfechas
        '
        Me.grbfechas.Controls.Add(Me.dtpfechafin)
        Me.grbfechas.Controls.Add(Me.Label4)
        Me.grbfechas.Controls.Add(Me.Label1)
        Me.grbfechas.Controls.Add(Me.dtpfechainicio)
        Me.grbfechas.Location = New System.Drawing.Point(22, 235)
        Me.grbfechas.Name = "grbfechas"
        Me.grbfechas.Size = New System.Drawing.Size(326, 91)
        Me.grbfechas.TabIndex = 6
        Me.grbfechas.TabStop = False
        Me.grbfechas.Text = "Rango de fechas"
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(182, 47)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 24)
        Me.dtpfechafin.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(178, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 19)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Fecha fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(28, 49)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 24)
        Me.dtpfechainicio.TabIndex = 37
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbPago)
        Me.GroupBox1.Controls.Add(Me.rdbfacturacion)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 169)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 60)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de fecha"
        '
        'rdbPago
        '
        Me.rdbPago.AutoSize = True
        Me.rdbPago.Location = New System.Drawing.Point(182, 23)
        Me.rdbPago.Name = "rdbPago"
        Me.rdbPago.Size = New System.Drawing.Size(124, 22)
        Me.rdbPago.TabIndex = 4
        Me.rdbPago.Text = "Fecha de pago"
        Me.rdbPago.UseVisualStyleBackColor = True
        '
        'rdbfacturacion
        '
        Me.rdbfacturacion.AutoSize = True
        Me.rdbfacturacion.Checked = True
        Me.rdbfacturacion.Location = New System.Drawing.Point(13, 23)
        Me.rdbfacturacion.Name = "rdbfacturacion"
        Me.rdbfacturacion.Size = New System.Drawing.Size(136, 22)
        Me.rdbfacturacion.TabIndex = 3
        Me.rdbfacturacion.TabStop = True
        Me.rdbfacturacion.Text = "Fecha de factura"
        Me.rdbfacturacion.UseVisualStyleBackColor = True
        '
        'cmdFacturas
        '
        Me.cmdFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFacturas.Location = New System.Drawing.Point(354, 176)
        Me.cmdFacturas.Name = "cmdFacturas"
        Me.cmdFacturas.Size = New System.Drawing.Size(178, 46)
        Me.cmdFacturas.TabIndex = 7
        Me.cmdFacturas.Text = "Facturas que no estan en el control"
        Me.cmdFacturas.UseVisualStyleBackColor = True
        '
        'cmdduplicadas
        '
        Me.cmdduplicadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdduplicadas.Location = New System.Drawing.Point(354, 228)
        Me.cmdduplicadas.Name = "cmdduplicadas"
        Me.cmdduplicadas.Size = New System.Drawing.Size(178, 46)
        Me.cmdduplicadas.TabIndex = 8
        Me.cmdduplicadas.Text = "Facturas Duplicadas en el Control"
        Me.cmdduplicadas.UseVisualStyleBackColor = True
        '
        'cmdabonos
        '
        Me.cmdabonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdabonos.Location = New System.Drawing.Point(356, 20)
        Me.cmdabonos.Name = "cmdabonos"
        Me.cmdabonos.Size = New System.Drawing.Size(176, 46)
        Me.cmdabonos.TabIndex = 9
        Me.cmdabonos.Text = "Generar Abonos"
        Me.cmdabonos.UseVisualStyleBackColor = True
        '
        'cmdfacturasabonos
        '
        Me.cmdfacturasabonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdfacturasabonos.Location = New System.Drawing.Point(356, 72)
        Me.cmdfacturasabonos.Name = "cmdfacturasabonos"
        Me.cmdfacturasabonos.Size = New System.Drawing.Size(176, 46)
        Me.cmdfacturasabonos.TabIndex = 10
        Me.cmdfacturasabonos.Text = "Fact en el control sin abonos"
        Me.cmdfacturasabonos.UseVisualStyleBackColor = True
        '
        'cmdsinabonos
        '
        Me.cmdsinabonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsinabonos.Location = New System.Drawing.Point(356, 124)
        Me.cmdsinabonos.Name = "cmdsinabonos"
        Me.cmdsinabonos.Size = New System.Drawing.Size(176, 46)
        Me.cmdsinabonos.TabIndex = 11
        Me.cmdsinabonos.Text = "Fact sin abonos"
        Me.cmdsinabonos.UseVisualStyleBackColor = True
        '
        'cmdabonosmas
        '
        Me.cmdabonosmas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdabonosmas.Location = New System.Drawing.Point(354, 280)
        Me.cmdabonosmas.Name = "cmdabonosmas"
        Me.cmdabonosmas.Size = New System.Drawing.Size(178, 46)
        Me.cmdabonosmas.TabIndex = 12
        Me.cmdabonosmas.Text = "Facturas con abonos mayores al total"
        Me.cmdabonosmas.UseVisualStyleBackColor = True
        '
        'cmdabonos2
        '
        Me.cmdabonos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdabonos2.Location = New System.Drawing.Point(354, 386)
        Me.cmdabonos2.Name = "cmdabonos2"
        Me.cmdabonos2.Size = New System.Drawing.Size(176, 46)
        Me.cmdabonos2.TabIndex = 13
        Me.cmdabonos2.Text = "Generar Abonos 0"
        Me.cmdabonos2.UseVisualStyleBackColor = True
        '
        'grbplazas
        '
        Me.grbplazas.Controls.Add(Me.cboplaza)
        Me.grbplazas.Enabled = False
        Me.grbplazas.Location = New System.Drawing.Point(22, 357)
        Me.grbplazas.Name = "grbplazas"
        Me.grbplazas.Size = New System.Drawing.Size(326, 55)
        Me.grbplazas.TabIndex = 14
        Me.grbplazas.TabStop = False
        Me.grbplazas.Text = "Plazas"
        '
        'cboplaza
        '
        Me.cboplaza.FormattingEnabled = True
        Me.cboplaza.Items.AddRange(New Object() {"Activa", "Cancelada"})
        Me.cboplaza.Location = New System.Drawing.Point(59, 23)
        Me.cboplaza.Name = "cboplaza"
        Me.cboplaza.Size = New System.Drawing.Size(186, 26)
        Me.cboplaza.TabIndex = 50
        '
        'chkplazas
        '
        Me.chkplazas.AutoSize = True
        Me.chkplazas.Location = New System.Drawing.Point(22, 332)
        Me.chkplazas.Name = "chkplazas"
        Me.chkplazas.Size = New System.Drawing.Size(98, 22)
        Me.chkplazas.TabIndex = 15
        Me.chkplazas.Text = "Por plazas"
        Me.chkplazas.UseVisualStyleBackColor = True
        '
        'frmfiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 443)
        Me.Controls.Add(Me.chkplazas)
        Me.Controls.Add(Me.grbplazas)
        Me.Controls.Add(Me.cmdabonos2)
        Me.Controls.Add(Me.cmdabonosmas)
        Me.Controls.Add(Me.cmdsinabonos)
        Me.Controls.Add(Me.cmdfacturasabonos)
        Me.Controls.Add(Me.cmdabonos)
        Me.Controls.Add(Me.cmdduplicadas)
        Me.Controls.Add(Me.cmdFacturas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbfechas)
        Me.Controls.Add(Me.cmdgenerar)
        Me.Controls.Add(Me.grbestatus)
        Me.Controls.Add(Me.grbtipoempresa)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmfiltro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.grbtipoempresa.ResumeLayout(False)
        Me.grbtipoempresa.PerformLayout()
        Me.grbestatus.ResumeLayout(False)
        Me.grbestatus.PerformLayout()
        Me.grbfechas.ResumeLayout(False)
        Me.grbfechas.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbplazas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grbtipoempresa As GroupBox
    Friend WithEvents rdbpatrona As RadioButton
    Friend WithEvents rdbintermediaria As RadioButton
    Friend WithEvents rdbiva As RadioButton
    Friend WithEvents grbestatus As GroupBox
    Friend WithEvents rdbnopagadas As RadioButton
    Friend WithEvents rdbpagadas As RadioButton
    Friend WithEvents rdbTodas As RadioButton
    Friend WithEvents cmdgenerar As Button
    Friend WithEvents grbfechas As GroupBox
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdbPago As RadioButton
    Friend WithEvents rdbfacturacion As RadioButton
    Friend WithEvents cmdFacturas As Button
    Friend WithEvents cmdduplicadas As Button
    Friend WithEvents cmdabonos As Button
    Friend WithEvents cmdfacturasabonos As Button
    Friend WithEvents cmdsinabonos As Button
    Friend WithEvents cmdabonosmas As Button
    Friend WithEvents cmdabonos2 As Button
    Friend WithEvents grbplazas As GroupBox
    Friend WithEvents cboplaza As ComboBox
    Friend WithEvents chkplazas As CheckBox
End Class
