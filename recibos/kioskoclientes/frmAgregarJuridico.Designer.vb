﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarJuridico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregarJuridico))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdDeleted = New System.Windows.Forms.Button()
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
        Me.cbomes = New System.Windows.Forms.ComboBox()
        Me.cboanio = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdarchivo = New System.Windows.Forms.Button()
        Me.cmdBorrarArchivo = New System.Windows.Forms.Button()
        Me.lsvArchivo = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboclientes = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlProveedores.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdDeleted)
        Me.Panel1.Controls.Add(Me.cmdcancelar)
        Me.Panel1.Controls.Add(Me.cmdbuscar)
        Me.Panel1.Controls.Add(Me.cmdnuevo)
        Me.Panel1.Controls.Add(Me.cmdsalir)
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(638, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 480)
        Me.Panel1.TabIndex = 69
        '
        'cmdDeleted
        '
        Me.cmdDeleted.Image = CType(resources.GetObject("cmdDeleted.Image"), System.Drawing.Image)
        Me.cmdDeleted.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdDeleted.Location = New System.Drawing.Point(3, 313)
        Me.cmdDeleted.Name = "cmdDeleted"
        Me.cmdDeleted.Size = New System.Drawing.Size(87, 72)
        Me.cmdDeleted.TabIndex = 39
        Me.cmdDeleted.Text = "Eliminar"
        Me.cmdDeleted.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDeleted.UseVisualStyleBackColor = True
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdcancelar.Image = CType(resources.GetObject("cmdcancelar.Image"), System.Drawing.Image)
        Me.cmdcancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcancelar.Location = New System.Drawing.Point(7, 158)
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
        Me.cmdbuscar.Location = New System.Drawing.Point(7, 235)
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
        Me.cmdsalir.Location = New System.Drawing.Point(8, 401)
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
        Me.pnlProveedores.Controls.Add(Me.cbomes)
        Me.pnlProveedores.Controls.Add(Me.cboanio)
        Me.pnlProveedores.Controls.Add(Me.Label2)
        Me.pnlProveedores.Controls.Add(Me.Label1)
        Me.pnlProveedores.Controls.Add(Me.cmdarchivo)
        Me.pnlProveedores.Controls.Add(Me.cmdBorrarArchivo)
        Me.pnlProveedores.Controls.Add(Me.lsvArchivo)
        Me.pnlProveedores.Controls.Add(Me.cboclientes)
        Me.pnlProveedores.Controls.Add(Me.Label23)
        Me.pnlProveedores.Enabled = False
        Me.pnlProveedores.Location = New System.Drawing.Point(3, 7)
        Me.pnlProveedores.Name = "pnlProveedores"
        Me.pnlProveedores.Size = New System.Drawing.Size(629, 569)
        Me.pnlProveedores.TabIndex = 68
        '
        'cmdborrarfactura
        '
        Me.cmdborrarfactura.Location = New System.Drawing.Point(235, 41)
        Me.cmdborrarfactura.Name = "cmdborrarfactura"
        Me.cmdborrarfactura.Size = New System.Drawing.Size(123, 29)
        Me.cmdborrarfactura.TabIndex = 102
        Me.cmdborrarfactura.Text = "Borrar Empleados"
        Me.cmdborrarfactura.UseVisualStyleBackColor = True
        '
        'cmdagregar
        '
        Me.cmdagregar.Location = New System.Drawing.Point(73, 41)
        Me.cmdagregar.Name = "cmdagregar"
        Me.cmdagregar.Size = New System.Drawing.Size(156, 29)
        Me.cmdagregar.TabIndex = 101
        Me.cmdagregar.Text = "Ver empleados"
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
        Me.lsvLista.Location = New System.Drawing.Point(7, 76)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(608, 191)
        Me.lsvLista.TabIndex = 100
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Empleado"
        Me.ColumnHeader1.Width = 597
        '
        'cbomes
        '
        Me.cbomes.FormattingEnabled = True
        Me.cbomes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbomes.Location = New System.Drawing.Point(361, 285)
        Me.cbomes.Name = "cbomes"
        Me.cbomes.Size = New System.Drawing.Size(159, 27)
        Me.cbomes.TabIndex = 99
        '
        'cboanio
        '
        Me.cboanio.FormattingEnabled = True
        Me.cboanio.Items.AddRange(New Object() {"2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030"})
        Me.cboanio.Location = New System.Drawing.Point(210, 285)
        Me.cboanio.Name = "cboanio"
        Me.cboanio.Size = New System.Drawing.Size(82, 27)
        Me.cboanio.TabIndex = 98
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(314, 288)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Mes:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(166, 288)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 19)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Año:"
        '
        'cmdarchivo
        '
        Me.cmdarchivo.Location = New System.Drawing.Point(15, 273)
        Me.cmdarchivo.Name = "cmdarchivo"
        Me.cmdarchivo.Size = New System.Drawing.Size(123, 29)
        Me.cmdarchivo.TabIndex = 94
        Me.cmdarchivo.Text = "Buscar Archivo.."
        Me.cmdarchivo.UseVisualStyleBackColor = True
        '
        'cmdBorrarArchivo
        '
        Me.cmdBorrarArchivo.Location = New System.Drawing.Point(15, 308)
        Me.cmdBorrarArchivo.Name = "cmdBorrarArchivo"
        Me.cmdBorrarArchivo.Size = New System.Drawing.Size(123, 29)
        Me.cmdBorrarArchivo.TabIndex = 93
        Me.cmdBorrarArchivo.Text = "Borrar archivo"
        Me.cmdBorrarArchivo.UseVisualStyleBackColor = True
        '
        'lsvArchivo
        '
        Me.lsvArchivo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvArchivo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lsvArchivo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvArchivo.FullRowSelect = True
        Me.lsvArchivo.GridLines = True
        Me.lsvArchivo.HideSelection = False
        Me.lsvArchivo.Location = New System.Drawing.Point(15, 343)
        Me.lsvArchivo.MultiSelect = False
        Me.lsvArchivo.Name = "lsvArchivo"
        Me.lsvArchivo.Size = New System.Drawing.Size(600, 219)
        Me.lsvArchivo.TabIndex = 92
        Me.lsvArchivo.UseCompatibleStateImageBehavior = False
        Me.lsvArchivo.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Archivo"
        Me.ColumnHeader2.Width = 488
        '
        'cboclientes
        '
        Me.cboclientes.FormattingEnabled = True
        Me.cboclientes.Location = New System.Drawing.Point(73, 6)
        Me.cboclientes.Name = "cboclientes"
        Me.cboclientes.Size = New System.Drawing.Size(542, 27)
        Me.cboclientes.TabIndex = 50
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(-1, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(76, 19)
        Me.Label23.TabIndex = 49
        Me.Label23.Text = "Empresas:"
        '
        'frmAgregarJuridico
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(739, 588)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlProveedores)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmAgregarJuridico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar datos Juridico"
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
    Friend WithEvents cbomes As ComboBox
    Friend WithEvents cboanio As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdarchivo As Button
    Friend WithEvents cmdBorrarArchivo As Button
    Friend WithEvents lsvArchivo As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label23 As Label
    Friend WithEvents cmdDeleted As System.Windows.Forms.Button
    Friend WithEvents cboclientes As System.Windows.Forms.ComboBox
    Friend WithEvents cmdborrarfactura As System.Windows.Forms.Button
    Friend WithEvents cmdagregar As System.Windows.Forms.Button
    Friend WithEvents lsvLista As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
End Class
