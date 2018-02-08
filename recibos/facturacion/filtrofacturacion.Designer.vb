<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class filtrofacturacion
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
        Me.cmdgenerar = New System.Windows.Forms.Button()
        Me.grbtipoempresa = New System.Windows.Forms.GroupBox()
        Me.rdbtodas = New System.Windows.Forms.RadioButton()
        Me.rdbflujo = New System.Windows.Forms.RadioButton()
        Me.rdbnomina = New System.Windows.Forms.RadioButton()
        Me.grbtipoempresa.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdgenerar
        '
        Me.cmdgenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdgenerar.Location = New System.Drawing.Point(72, 94)
        Me.cmdgenerar.Name = "cmdgenerar"
        Me.cmdgenerar.Size = New System.Drawing.Size(128, 46)
        Me.cmdgenerar.TabIndex = 5
        Me.cmdgenerar.Text = "Generar"
        Me.cmdgenerar.UseVisualStyleBackColor = True
        '
        'grbtipoempresa
        '
        Me.grbtipoempresa.Controls.Add(Me.rdbtodas)
        Me.grbtipoempresa.Controls.Add(Me.rdbflujo)
        Me.grbtipoempresa.Controls.Add(Me.rdbnomina)
        Me.grbtipoempresa.Location = New System.Drawing.Point(12, 12)
        Me.grbtipoempresa.Name = "grbtipoempresa"
        Me.grbtipoempresa.Size = New System.Drawing.Size(247, 76)
        Me.grbtipoempresa.TabIndex = 6
        Me.grbtipoempresa.TabStop = False
        Me.grbtipoempresa.Text = "Tipo de factura"
        '
        'rdbtodas
        '
        Me.rdbtodas.AutoSize = True
        Me.rdbtodas.Location = New System.Drawing.Point(180, 32)
        Me.rdbtodas.Name = "rdbtodas"
        Me.rdbtodas.Size = New System.Drawing.Size(55, 17)
        Me.rdbtodas.TabIndex = 2
        Me.rdbtodas.Text = "Todas"
        Me.rdbtodas.UseVisualStyleBackColor = True
        '
        'rdbflujo
        '
        Me.rdbflujo.AutoSize = True
        Me.rdbflujo.Location = New System.Drawing.Point(111, 32)
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
        Me.rdbnomina.Location = New System.Drawing.Point(19, 32)
        Me.rdbnomina.Name = "rdbnomina"
        Me.rdbnomina.Size = New System.Drawing.Size(66, 17)
        Me.rdbnomina.TabIndex = 0
        Me.rdbnomina.TabStop = True
        Me.rdbnomina.Text = "Nominas"
        Me.rdbnomina.UseVisualStyleBackColor = True
        '
        'filtrofacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 145)
        Me.Controls.Add(Me.grbtipoempresa)
        Me.Controls.Add(Me.cmdgenerar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "filtrofacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.grbtipoempresa.ResumeLayout(False)
        Me.grbtipoempresa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdgenerar As Button
    Friend WithEvents grbtipoempresa As GroupBox
    Friend WithEvents rdbtodas As RadioButton
    Friend WithEvents rdbflujo As RadioButton
    Friend WithEvents rdbnomina As RadioButton
End Class
