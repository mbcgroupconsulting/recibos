<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartamentoAlta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepartamentoAlta))
        Me.pnlTipoEmpresa = New System.Windows.Forms.Panel()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbostatus = New System.Windows.Forms.ComboBox()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmdnuevo = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.pnlTipoEmpresa.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTipoEmpresa
        '
        Me.pnlTipoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTipoEmpresa.Controls.Add(Me.lblEmpresa)
        Me.pnlTipoEmpresa.Controls.Add(Me.txtDescripcion)
        Me.pnlTipoEmpresa.Controls.Add(Me.Label2)
        Me.pnlTipoEmpresa.Controls.Add(Me.cbostatus)
        Me.pnlTipoEmpresa.Controls.Add(Me.txtnombre)
        Me.pnlTipoEmpresa.Controls.Add(Me.Label13)
        Me.pnlTipoEmpresa.Controls.Add(Me.Label1)
        Me.pnlTipoEmpresa.Enabled = False
        Me.pnlTipoEmpresa.Location = New System.Drawing.Point(5, 10)
        Me.pnlTipoEmpresa.Name = "pnlTipoEmpresa"
        Me.pnlTipoEmpresa.Size = New System.Drawing.Size(481, 126)
        Me.pnlTipoEmpresa.TabIndex = 39
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(6, 7)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(65, 19)
        Me.lblEmpresa.TabIndex = 15
        Me.lblEmpresa.Text = "Empresa"
        Me.lblEmpresa.Visible = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(96, 78)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(373, 27)
        Me.txtDescripcion.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Descripción:"
        '
        'cbostatus
        '
        Me.cbostatus.FormattingEnabled = True
        Me.cbostatus.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.cbostatus.Location = New System.Drawing.Point(329, 4)
        Me.cbostatus.Name = "cbostatus"
        Me.cbostatus.Size = New System.Drawing.Size(138, 27)
        Me.cbostatus.TabIndex = 0
        '
        'txtnombre
        '
        Me.txtnombre.Location = New System.Drawing.Point(72, 45)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(397, 27)
        Me.txtnombre.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(262, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 19)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Estatus:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdcancelar)
        Me.Panel1.Controls.Add(Me.cmdbuscar)
        Me.Panel1.Controls.Add(Me.cmdnuevo)
        Me.Panel1.Controls.Add(Me.cmdsalir)
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(3, 138)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(478, 80)
        Me.Panel1.TabIndex = 40
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Image = CType(resources.GetObject("cmdcancelar.Image"), System.Drawing.Image)
        Me.cmdcancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcancelar.Location = New System.Drawing.Point(193, 3)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(87, 72)
        Me.cmdcancelar.TabIndex = 38
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdbuscar.Location = New System.Drawing.Point(286, 3)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(87, 72)
        Me.cmdbuscar.TabIndex = 36
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'cmdnuevo
        '
        Me.cmdnuevo.Image = CType(resources.GetObject("cmdnuevo.Image"), System.Drawing.Image)
        Me.cmdnuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdnuevo.Location = New System.Drawing.Point(7, 2)
        Me.cmdnuevo.Name = "cmdnuevo"
        Me.cmdnuevo.Size = New System.Drawing.Size(87, 72)
        Me.cmdnuevo.TabIndex = 33
        Me.cmdnuevo.Text = "Nuevo"
        Me.cmdnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdnuevo.UseVisualStyleBackColor = True
        '
        'cmdsalir
        '
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdsalir.Location = New System.Drawing.Point(379, 3)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(87, 72)
        Me.cmdsalir.TabIndex = 37
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'cmdguardar
        '
        Me.cmdguardar.Image = CType(resources.GetObject("cmdguardar.Image"), System.Drawing.Image)
        Me.cmdguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdguardar.Location = New System.Drawing.Point(100, 3)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(87, 72)
        Me.cmdguardar.TabIndex = 34
        Me.cmdguardar.Text = "Guardar"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdguardar.UseVisualStyleBackColor = True
        '
        'frmDepartamentoAlta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(493, 230)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTipoEmpresa)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmDepartamentoAlta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo Departamentos"
        Me.pnlTipoEmpresa.ResumeLayout(False)
        Me.pnlTipoEmpresa.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTipoEmpresa As System.Windows.Forms.Panel
    Friend WithEvents cbostatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdbuscar As System.Windows.Forms.Button
    Friend WithEvents cmdnuevo As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
End Class
