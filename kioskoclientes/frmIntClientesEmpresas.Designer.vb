<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIntClientesEmpresas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIntClientesEmpresas))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmdnuevo = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.pnlProveedores = New System.Windows.Forms.Panel()
        Me.cmdborrarfactura = New System.Windows.Forms.Button()
        Me.cmdagregar = New System.Windows.Forms.Button()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cbocliente = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboempresa = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlProveedores.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdcancelar)
        Me.Panel1.Controls.Add(Me.cmdbuscar)
        Me.Panel1.Controls.Add(Me.cmdnuevo)
        Me.Panel1.Controls.Add(Me.cmdsalir)
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(670, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 380)
        Me.Panel1.TabIndex = 66
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdcancelar.Image = CType(resources.GetObject("cmdcancelar.Image"), System.Drawing.Image)
        Me.cmdcancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcancelar.Location = New System.Drawing.Point(7, 148)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(87, 72)
        Me.cmdcancelar.TabIndex = 37
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdbuscar.Location = New System.Drawing.Point(7, 224)
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
        Me.cmdsalir.Location = New System.Drawing.Point(7, 299)
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
        Me.cmdguardar.Location = New System.Drawing.Point(7, 75)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(87, 72)
        Me.cmdguardar.TabIndex = 34
        Me.cmdguardar.Text = "Guardar"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdguardar.UseVisualStyleBackColor = True
        '
        'pnlProveedores
        '
        Me.pnlProveedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProveedores.Controls.Add(Me.cmdborrarfactura)
        Me.pnlProveedores.Controls.Add(Me.cmdagregar)
        Me.pnlProveedores.Controls.Add(Me.lsvLista)
        Me.pnlProveedores.Controls.Add(Me.cbocliente)
        Me.pnlProveedores.Controls.Add(Me.Label21)
        Me.pnlProveedores.Controls.Add(Me.cboempresa)
        Me.pnlProveedores.Controls.Add(Me.Label23)
        Me.pnlProveedores.Enabled = False
        Me.pnlProveedores.Location = New System.Drawing.Point(7, 7)
        Me.pnlProveedores.Name = "pnlProveedores"
        Me.pnlProveedores.Size = New System.Drawing.Size(654, 380)
        Me.pnlProveedores.TabIndex = 65
        '
        'cmdborrarfactura
        '
        Me.cmdborrarfactura.Location = New System.Drawing.Point(254, 76)
        Me.cmdborrarfactura.Name = "cmdborrarfactura"
        Me.cmdborrarfactura.Size = New System.Drawing.Size(123, 29)
        Me.cmdborrarfactura.TabIndex = 90
        Me.cmdborrarfactura.Text = "Borrar Empresa"
        Me.cmdborrarfactura.UseVisualStyleBackColor = True
        '
        'cmdagregar
        '
        Me.cmdagregar.Location = New System.Drawing.Point(92, 76)
        Me.cmdagregar.Name = "cmdagregar"
        Me.cmdagregar.Size = New System.Drawing.Size(156, 29)
        Me.cmdagregar.TabIndex = 89
        Me.cmdagregar.Text = "Agregar Empresa"
        Me.cmdagregar.UseVisualStyleBackColor = True
        '
        'lsvLista
        '
        Me.lsvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvLista.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lsvLista.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvLista.FullRowSelect = True
        Me.lsvLista.GridLines = True
        Me.lsvLista.HideSelection = False
        Me.lsvLista.Location = New System.Drawing.Point(92, 124)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(542, 239)
        Me.lsvLista.TabIndex = 64
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Empresa"
        Me.ColumnHeader1.Width = 500
        '
        'cbocliente
        '
        Me.cbocliente.FormattingEnabled = True
        Me.cbocliente.Location = New System.Drawing.Point(92, 8)
        Me.cbocliente.Name = "cbocliente"
        Me.cbocliente.Size = New System.Drawing.Size(542, 27)
        Me.cbocliente.TabIndex = 63
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(35, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 19)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Cliente:"
        '
        'cboempresa
        '
        Me.cboempresa.FormattingEnabled = True
        Me.cboempresa.Location = New System.Drawing.Point(92, 40)
        Me.cboempresa.Name = "cboempresa"
        Me.cboempresa.Size = New System.Drawing.Size(542, 27)
        Me.cboempresa.TabIndex = 50
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(25, 43)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 19)
        Me.Label23.TabIndex = 49
        Me.Label23.Text = "Empresa:"
        '
        'frmIntClientesEmpresas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(782, 394)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlProveedores)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmIntClientesEmpresas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asociar clientes con empresas"
        Me.Panel1.ResumeLayout(False)
        Me.pnlProveedores.ResumeLayout(False)
        Me.pnlProveedores.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdcancelar As Button
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents cmdnuevo As Button
    Friend WithEvents cmdsalir As Button
    Friend WithEvents cmdguardar As Button
    Friend WithEvents pnlProveedores As Panel
    Friend WithEvents cbocliente As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cboempresa As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents lsvLista As ListView
    Friend WithEvents cmdborrarfactura As Button
    Friend WithEvents cmdagregar As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
