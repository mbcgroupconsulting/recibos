<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecibosLupita
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
        Me.UcVisor1 = New ucVisor()
        Me.SuspendLayout()
        '
        'UcVisor1
        '
        Me.UcVisor1.Conectado = False
        Me.UcVisor1.crReporte = Nothing
        Me.UcVisor1.DataSource = Nothing
        Me.UcVisor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcVisor1.Filtros = Nothing
        Me.UcVisor1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcVisor1.Location = New System.Drawing.Point(0, 0)
        Me.UcVisor1.Name = "UcVisor1"
        Me.UcVisor1.Parametros = Nothing
        Me.UcVisor1.Reporte = Nothing
        Me.UcVisor1.Seleccion = Nothing
        Me.UcVisor1.Size = New System.Drawing.Size(685, 452)
        Me.UcVisor1.TabIndex = 1
        '
        'frmRecibosLupita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 452)
        Me.Controls.Add(Me.UcVisor1)
        Me.Name = "frmRecibosLupita"
        Me.Text = "Recibos sindicato lupita"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcVisor1 As ucVisor
End Class
