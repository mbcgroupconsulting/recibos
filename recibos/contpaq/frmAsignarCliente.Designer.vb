﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignarCliente))
        Me.cboClientes = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.lblcliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSubsidio = New System.Windows.Forms.ComboBox()
        Me.grbSubsidio = New System.Windows.Forms.GroupBox()
        Me.rdbRestar = New System.Windows.Forms.RadioButton()
        Me.rdbSumar = New System.Windows.Forms.RadioButton()
        Me.rdbNada = New System.Windows.Forms.RadioButton()
        Me.chkSubsidio = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.grbSubsidio.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboClientes
        '
        Me.cboClientes.FormattingEnabled = True
        Me.cboClientes.Location = New System.Drawing.Point(12, 30)
        Me.cboClientes.Name = "cboClientes"
        Me.cboClientes.Size = New System.Drawing.Size(633, 26)
        Me.cboClientes.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(547, 73)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(98, 80)
        Me.Panel1.TabIndex = 41
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
        'lblcliente
        '
        Me.lblcliente.AutoSize = True
        Me.lblcliente.Location = New System.Drawing.Point(12, 67)
        Me.lblcliente.Name = "lblcliente"
        Me.lblcliente.Size = New System.Drawing.Size(0, 18)
        Me.lblcliente.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(315, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione al cliente a quien pertenece la nomina"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 18)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Subsidio al empleo ocupado"
        '
        'cboSubsidio
        '
        Me.cboSubsidio.FormattingEnabled = True
        Me.cboSubsidio.Items.AddRange(New Object() {"Subs al Empleo acreditado", "Subsidio al Empleo (sp)"})
        Me.cboSubsidio.Location = New System.Drawing.Point(12, 124)
        Me.cboSubsidio.Name = "cboSubsidio"
        Me.cboSubsidio.Size = New System.Drawing.Size(519, 26)
        Me.cboSubsidio.TabIndex = 44
        '
        'grbSubsidio
        '
        Me.grbSubsidio.Controls.Add(Me.rdbRestar)
        Me.grbSubsidio.Controls.Add(Me.rdbSumar)
        Me.grbSubsidio.Controls.Add(Me.rdbNada)
        Me.grbSubsidio.Location = New System.Drawing.Point(12, 156)
        Me.grbSubsidio.Name = "grbSubsidio"
        Me.grbSubsidio.Size = New System.Drawing.Size(280, 108)
        Me.grbSubsidio.TabIndex = 45
        Me.grbSubsidio.TabStop = False
        Me.grbSubsidio.Text = "Como ocupar el subsidiio para el Subtotal"
        '
        'rdbRestar
        '
        Me.rdbRestar.AutoSize = True
        Me.rdbRestar.Location = New System.Drawing.Point(15, 81)
        Me.rdbRestar.Name = "rdbRestar"
        Me.rdbRestar.Size = New System.Drawing.Size(188, 22)
        Me.rdbRestar.TabIndex = 2
        Me.rdbRestar.Text = "Restar subsidio al subtotal"
        Me.rdbRestar.UseVisualStyleBackColor = True
        '
        'rdbSumar
        '
        Me.rdbSumar.AutoSize = True
        Me.rdbSumar.Location = New System.Drawing.Point(15, 53)
        Me.rdbSumar.Name = "rdbSumar"
        Me.rdbSumar.Size = New System.Drawing.Size(188, 22)
        Me.rdbSumar.TabIndex = 1
        Me.rdbSumar.Text = "Sumar subsidio al subtotal"
        Me.rdbSumar.UseVisualStyleBackColor = True
        '
        'rdbNada
        '
        Me.rdbNada.AutoSize = True
        Me.rdbNada.Checked = True
        Me.rdbNada.Location = New System.Drawing.Point(15, 25)
        Me.rdbNada.Name = "rdbNada"
        Me.rdbNada.Size = New System.Drawing.Size(218, 22)
        Me.rdbNada.TabIndex = 0
        Me.rdbNada.TabStop = True
        Me.rdbNada.Text = "No tomar en cuenta el subsidio"
        Me.rdbNada.UseVisualStyleBackColor = True
        '
        'chkSubsidio
        '
        Me.chkSubsidio.AutoSize = True
        Me.chkSubsidio.Location = New System.Drawing.Point(324, 181)
        Me.chkSubsidio.Name = "chkSubsidio"
        Me.chkSubsidio.Size = New System.Drawing.Size(273, 22)
        Me.chkSubsidio.TabIndex = 46
        Me.chkSubsidio.Text = "El subsidio debe aparecer en el reporte."
        Me.chkSubsidio.UseVisualStyleBackColor = True
        '
        'frmAsignarCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(650, 274)
        Me.Controls.Add(Me.chkSubsidio)
        Me.Controls.Add(Me.grbSubsidio)
        Me.Controls.Add(Me.cboSubsidio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblcliente)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cboClientes)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmAsignarCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar cliente a la nomina"
        Me.Panel1.ResumeLayout(False)
        Me.grbSubsidio.ResumeLayout(False)
        Me.grbSubsidio.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents lblcliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSubsidio As System.Windows.Forms.ComboBox
    Friend WithEvents grbSubsidio As System.Windows.Forms.GroupBox
    Friend WithEvents rdbRestar As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSumar As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNada As System.Windows.Forms.RadioButton
    Friend WithEvents chkSubsidio As System.Windows.Forms.CheckBox
End Class