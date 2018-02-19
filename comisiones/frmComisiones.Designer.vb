<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComisiones
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
        Me.cmdcomisiones = New System.Windows.Forms.Button()
        Me.grbfechas = New System.Windows.Forms.GroupBox()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.grbtipoempresa = New System.Windows.Forms.GroupBox()
        Me.rdbTodas = New System.Windows.Forms.RadioButton()
        Me.rdbiva = New System.Windows.Forms.RadioButton()
        Me.rdbpatrona = New System.Windows.Forms.RadioButton()
        Me.rdbintermediaria = New System.Windows.Forms.RadioButton()
        Me.cboplaza = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grbfechas.SuspendLayout()
        Me.grbtipoempresa.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdcomisiones
        '
        Me.cmdcomisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcomisiones.Location = New System.Drawing.Point(101, 260)
        Me.cmdcomisiones.Name = "cmdcomisiones"
        Me.cmdcomisiones.Size = New System.Drawing.Size(176, 46)
        Me.cmdcomisiones.TabIndex = 10
        Me.cmdcomisiones.Text = "Generar Comisiones"
        Me.cmdcomisiones.UseVisualStyleBackColor = True
        '
        'grbfechas
        '
        Me.grbfechas.Controls.Add(Me.dtpfechafin)
        Me.grbfechas.Controls.Add(Me.Label4)
        Me.grbfechas.Controls.Add(Me.Label1)
        Me.grbfechas.Controls.Add(Me.dtpfechainicio)
        Me.grbfechas.Location = New System.Drawing.Point(26, 153)
        Me.grbfechas.Name = "grbfechas"
        Me.grbfechas.Size = New System.Drawing.Size(342, 93)
        Me.grbfechas.TabIndex = 12
        Me.grbfechas.TabStop = False
        Me.grbfechas.Text = "Rango de fechas"
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(197, 47)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechafin.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(193, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 19)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Fecha fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(43, 49)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechainicio.TabIndex = 37
        '
        'grbtipoempresa
        '
        Me.grbtipoempresa.Controls.Add(Me.rdbTodas)
        Me.grbtipoempresa.Controls.Add(Me.rdbiva)
        Me.grbtipoempresa.Controls.Add(Me.rdbpatrona)
        Me.grbtipoempresa.Controls.Add(Me.rdbintermediaria)
        Me.grbtipoempresa.Location = New System.Drawing.Point(24, 10)
        Me.grbtipoempresa.Name = "grbtipoempresa"
        Me.grbtipoempresa.Size = New System.Drawing.Size(344, 76)
        Me.grbtipoempresa.TabIndex = 11
        Me.grbtipoempresa.TabStop = False
        Me.grbtipoempresa.Text = "Tipo de empresa"
        '
        'rdbTodas
        '
        Me.rdbTodas.AutoSize = True
        Me.rdbTodas.Checked = True
        Me.rdbTodas.Location = New System.Drawing.Point(13, 32)
        Me.rdbTodas.Name = "rdbTodas"
        Me.rdbTodas.Size = New System.Drawing.Size(65, 23)
        Me.rdbTodas.TabIndex = 3
        Me.rdbTodas.TabStop = True
        Me.rdbTodas.Text = "Todas"
        Me.rdbTodas.UseVisualStyleBackColor = True
        '
        'rdbiva
        '
        Me.rdbiva.AutoSize = True
        Me.rdbiva.Location = New System.Drawing.Point(282, 32)
        Me.rdbiva.Name = "rdbiva"
        Me.rdbiva.Size = New System.Drawing.Size(46, 23)
        Me.rdbiva.TabIndex = 2
        Me.rdbiva.Text = "Iva"
        Me.rdbiva.UseVisualStyleBackColor = True
        '
        'rdbpatrona
        '
        Me.rdbpatrona.AutoSize = True
        Me.rdbpatrona.Location = New System.Drawing.Point(198, 32)
        Me.rdbpatrona.Name = "rdbpatrona"
        Me.rdbpatrona.Size = New System.Drawing.Size(77, 23)
        Me.rdbpatrona.TabIndex = 1
        Me.rdbpatrona.Text = "Patrona"
        Me.rdbpatrona.UseVisualStyleBackColor = True
        '
        'rdbintermediaria
        '
        Me.rdbintermediaria.AutoSize = True
        Me.rdbintermediaria.Location = New System.Drawing.Point(87, 32)
        Me.rdbintermediaria.Name = "rdbintermediaria"
        Me.rdbintermediaria.Size = New System.Drawing.Size(114, 23)
        Me.rdbintermediaria.TabIndex = 0
        Me.rdbintermediaria.Text = "Intermediaria"
        Me.rdbintermediaria.UseVisualStyleBackColor = True
        '
        'cboplaza
        '
        Me.cboplaza.FormattingEnabled = True
        Me.cboplaza.Items.AddRange(New Object() {"Activa", "Cancelada"})
        Me.cboplaza.Location = New System.Drawing.Point(29, 113)
        Me.cboplaza.Name = "cboplaza"
        Me.cboplaza.Size = New System.Drawing.Size(186, 27)
        Me.cboplaza.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Plazas:"
        '
        'frmComisiones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(380, 317)
        Me.Controls.Add(Me.cboplaza)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grbfechas)
        Me.Controls.Add(Me.grbtipoempresa)
        Me.Controls.Add(Me.cmdcomisiones)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmComisiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar comisiones"
        Me.grbfechas.ResumeLayout(False)
        Me.grbfechas.PerformLayout()
        Me.grbtipoempresa.ResumeLayout(False)
        Me.grbtipoempresa.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdcomisiones As Button
    Friend WithEvents grbfechas As GroupBox
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents grbtipoempresa As GroupBox
    Friend WithEvents rdbTodas As RadioButton
    Friend WithEvents rdbiva As RadioButton
    Friend WithEvents rdbpatrona As RadioButton
    Friend WithEvents rdbintermediaria As RadioButton
    Friend WithEvents cboplaza As ComboBox
    Friend WithEvents Label2 As Label
End Class
