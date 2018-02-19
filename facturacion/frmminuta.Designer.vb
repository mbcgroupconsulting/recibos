<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmminuta
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
        Me.grbfechas = New System.Windows.Forms.GroupBox()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.cmdgenerar = New System.Windows.Forms.Button()
        Me.grbtipoempresa = New System.Windows.Forms.GroupBox()
        Me.rdbflujo = New System.Windows.Forms.RadioButton()
        Me.rdbnomina = New System.Windows.Forms.RadioButton()
        Me.grbfechas.SuspendLayout()
        Me.grbtipoempresa.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbfechas
        '
        Me.grbfechas.Controls.Add(Me.dtpfechafin)
        Me.grbfechas.Controls.Add(Me.Label4)
        Me.grbfechas.Controls.Add(Me.Label1)
        Me.grbfechas.Controls.Add(Me.dtpfechainicio)
        Me.grbfechas.Location = New System.Drawing.Point(11, 104)
        Me.grbfechas.Name = "grbfechas"
        Me.grbfechas.Size = New System.Drawing.Size(234, 93)
        Me.grbfechas.TabIndex = 8
        Me.grbfechas.TabStop = False
        Me.grbfechas.Text = "Rango de fechas"
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(122, 47)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechafin.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(118, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 19)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Fecha fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(10, 49)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 20)
        Me.dtpfechainicio.TabIndex = 37
        '
        'cmdgenerar
        '
        Me.cmdgenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdgenerar.Location = New System.Drawing.Point(68, 205)
        Me.cmdgenerar.Name = "cmdgenerar"
        Me.cmdgenerar.Size = New System.Drawing.Size(128, 46)
        Me.cmdgenerar.TabIndex = 7
        Me.cmdgenerar.Text = "Generar"
        Me.cmdgenerar.UseVisualStyleBackColor = True
        '
        'grbtipoempresa
        '
        Me.grbtipoempresa.Controls.Add(Me.rdbflujo)
        Me.grbtipoempresa.Controls.Add(Me.rdbnomina)
        Me.grbtipoempresa.Location = New System.Drawing.Point(12, 12)
        Me.grbtipoempresa.Name = "grbtipoempresa"
        Me.grbtipoempresa.Size = New System.Drawing.Size(233, 76)
        Me.grbtipoempresa.TabIndex = 9
        Me.grbtipoempresa.TabStop = False
        Me.grbtipoempresa.Text = "Tipo de factura"
        '
        'rdbflujo
        '
        Me.rdbflujo.AutoSize = True
        Me.rdbflujo.Location = New System.Drawing.Point(169, 32)
        Me.rdbflujo.Name = "rdbflujo"
        Me.rdbflujo.Size = New System.Drawing.Size(47, 17)
        Me.rdbflujo.TabIndex = 1
        Me.rdbflujo.Text = "Flujo"
        Me.rdbflujo.UseVisualStyleBackColor = True
        '
        'rdbnomina
        '
        Me.rdbnomina.AutoSize = True
        Me.rdbnomina.Checked = True
        Me.rdbnomina.Location = New System.Drawing.Point(15, 32)
        Me.rdbnomina.Name = "rdbnomina"
        Me.rdbnomina.Size = New System.Drawing.Size(149, 17)
        Me.rdbnomina.TabIndex = 0
        Me.rdbnomina.TabStop = True
        Me.rdbnomina.Text = "Nominas + Flujos Externos"
        Me.rdbnomina.UseVisualStyleBackColor = True
        '
        'frmminuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 263)
        Me.Controls.Add(Me.grbtipoempresa)
        Me.Controls.Add(Me.grbfechas)
        Me.Controls.Add(Me.cmdgenerar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmminuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmminuta"
        Me.grbfechas.ResumeLayout(False)
        Me.grbfechas.PerformLayout()
        Me.grbtipoempresa.ResumeLayout(False)
        Me.grbtipoempresa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbfechas As GroupBox
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents cmdgenerar As Button
    Friend WithEvents grbtipoempresa As GroupBox
    Friend WithEvents rdbflujo As RadioButton
    Friend WithEvents rdbnomina As RadioButton
End Class
