﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportacionAltas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportacionAltas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tsbProcesar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.pnlCatalogo = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.pnlProgreso = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlCatalogo.SuspendLayout()
        Me.pnlProgreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbImportar, Me.tsbGuardar, Me.tsbProcesar, Me.tsbCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(840, 54)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.recibos.My.Resources.Resources._1361007999_document_new
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(102, 51)
        Me.tsbNuevo.Text = "Agregar catálogo"
        Me.tsbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbImportar
        '
        Me.tsbImportar.Enabled = False
        Me.tsbImportar.Image = Global.recibos.My.Resources.Resources._1361008137_export_excel
        Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportar.Name = "tsbImportar"
        Me.tsbImportar.Size = New System.Drawing.Size(99, 51)
        Me.tsbImportar.Text = "Importar archivo"
        Me.tsbImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbGuardar
        '
        Me.tsbGuardar.AutoSize = False
        Me.tsbGuardar.Enabled = False
        Me.tsbGuardar.Image = Global.recibos.My.Resources.Resources._1361008510_save_diskette_floppy_disk
        Me.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGuardar.Name = "tsbGuardar"
        Me.tsbGuardar.Size = New System.Drawing.Size(90, 51)
        Me.tsbGuardar.Text = "Generar recibos"
        Me.tsbGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbProcesar
        '
        Me.tsbProcesar.Enabled = False
        Me.tsbProcesar.Image = CType(resources.GetObject("tsbProcesar.Image"), System.Drawing.Image)
        Me.tsbProcesar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbProcesar.Name = "tsbProcesar"
        Me.tsbProcesar.Size = New System.Drawing.Size(98, 51)
        Me.tsbProcesar.Text = "Procesar archivo"
        Me.tsbProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbProcesar.Visible = False
        '
        'tsbCancelar
        '
        Me.tsbCancelar.AutoSize = False
        Me.tsbCancelar.Enabled = False
        Me.tsbCancelar.Image = Global.recibos.My.Resources.Resources._1361008659_cancel
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(90, 51)
        Me.tsbCancelar.Text = "Cancelar"
        Me.tsbCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCatalogo.Controls.Add(Me.ComboBox1)
        Me.pnlCatalogo.Controls.Add(Me.Label3)
        Me.pnlCatalogo.Controls.Add(Me.chkAll)
        Me.pnlCatalogo.Controls.Add(Me.lsvLista)
        Me.pnlCatalogo.Enabled = False
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 51)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(840, 335)
        Me.pnlCatalogo.TabIndex = 20
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(194, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(283, 27)
        Me.ComboBox1.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-3, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Empresa a la que pertenecen:"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(3, 38)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(107, 22)
        Me.chkAll.TabIndex = 4
        Me.chkAll.Text = "Marcar todos"
        Me.chkAll.UseVisualStyleBackColor = False
        '
        'lsvLista
        '
        Me.lsvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvLista.CheckBoxes = True
        Me.lsvLista.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvLista.FullRowSelect = True
        Me.lsvLista.GridLines = True
        Me.lsvLista.HideSelection = False
        Me.lsvLista.Location = New System.Drawing.Point(1, 63)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(832, 265)
        Me.lsvLista.TabIndex = 2
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'lblRuta
        '
        Me.lblRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(2, 389)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(604, 39)
        Me.lblRuta.TabIndex = 21
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(731, 389)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.cmdCerrar.Size = New System.Drawing.Size(104, 43)
        Me.cmdCerrar.TabIndex = 22
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'pnlProgreso
        '
        Me.pnlProgreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlProgreso.Controls.Add(Me.Label2)
        Me.pnlProgreso.Controls.Add(Me.pgbProgreso)
        Me.pnlProgreso.Location = New System.Drawing.Point(196, 176)
        Me.pnlProgreso.Name = "pnlProgreso"
        Me.pnlProgreso.Size = New System.Drawing.Size(449, 84)
        Me.pnlProgreso.TabIndex = 23
        Me.pnlProgreso.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Procesando articulos"
        '
        'pgbProgreso
        '
        Me.pgbProgreso.Location = New System.Drawing.Point(17, 12)
        Me.pgbProgreso.Name = "pgbProgreso"
        Me.pgbProgreso.Size = New System.Drawing.Size(413, 30)
        Me.pgbProgreso.TabIndex = 0
        '
        'ImportacionAltas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 437)
        Me.Controls.Add(Me.pnlProgreso)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.pnlCatalogo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ImportacionAltas"
        Me.Text = "Importacion Altas Guo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        Me.pnlProgreso.ResumeLayout(False)
        Me.pnlProgreso.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbProcesar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlCatalogo As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents lsvLista As System.Windows.Forms.ListView
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlProgreso As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pgbProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
