<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstatusNomina
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
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cboNomina = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(140, 44)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 28)
        Me.cmdAceptar.TabIndex = 0
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cboNomina
        '
        Me.cboNomina.FormattingEnabled = True
        Me.cboNomina.Items.AddRange(New Object() {"Pediente", "Pagado", "Financiado"})
        Me.cboNomina.Location = New System.Drawing.Point(12, 12)
        Me.cboNomina.Name = "cboNomina"
        Me.cboNomina.Size = New System.Drawing.Size(203, 26)
        Me.cboNomina.TabIndex = 1
        '
        'frmEstatusNomina
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(224, 81)
        Me.Controls.Add(Me.cboNomina)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEstatusNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione el estatus de la nomina"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cboNomina As System.Windows.Forms.ComboBox
End Class
