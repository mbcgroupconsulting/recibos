<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignarEmpresa))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblempresa = New System.Windows.Forms.Label()
        Me.cboInterPatrona = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboInterExcedente = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(493, 204)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(98, 80)
        Me.Panel1.TabIndex = 44
        '
        'cmdguardar
        '
        Me.cmdguardar.Image = CType(resources.GetObject("cmdguardar.Image"), System.Drawing.Image)
        Me.cmdguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdguardar.Location = New System.Drawing.Point(4, 3)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(87, 72)
        Me.cmdguardar.TabIndex = 34
        Me.cmdguardar.Text = "Guardar"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdguardar.UseVisualStyleBackColor = True
        '
        'cboEmpresa
        '
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Location = New System.Drawing.Point(12, 26)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(579, 26)
        Me.cboEmpresa.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(326, 18)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Seleccione la empresa a quien pertenece la nomina"
        '
        'lblempresa
        '
        Me.lblempresa.AutoSize = True
        Me.lblempresa.Location = New System.Drawing.Point(16, 61)
        Me.lblempresa.Name = "lblempresa"
        Me.lblempresa.Size = New System.Drawing.Size(62, 18)
        Me.lblempresa.TabIndex = 45
        Me.lblempresa.Text = "empresa"
        '
        'cboInterPatrona
        '
        Me.cboInterPatrona.FormattingEnabled = True
        Me.cboInterPatrona.Location = New System.Drawing.Point(12, 113)
        Me.cboInterPatrona.Name = "cboInterPatrona"
        Me.cboInterPatrona.Size = New System.Drawing.Size(579, 26)
        Me.cboInterPatrona.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(299, 18)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Seleccione la empresa intermedia para patrona"
        '
        'cboInterExcedente
        '
        Me.cboInterExcedente.FormattingEnabled = True
        Me.cboInterExcedente.Location = New System.Drawing.Point(12, 166)
        Me.cboInterExcedente.Name = "cboInterExcedente"
        Me.cboInterExcedente.Size = New System.Drawing.Size(579, 26)
        Me.cboInterExcedente.TabIndex = 49
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(317, 18)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Seleccione la empresa intermedia para excedente"
        '
        'frmAsignarEmpresa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(603, 295)
        Me.Controls.Add(Me.cboInterExcedente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboInterPatrona)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblempresa)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cboEmpresa)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmAsignarEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar empresa a la nomina"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblempresa As System.Windows.Forms.Label
    Friend WithEvents cboInterPatrona As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboInterExcedente As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
