<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComisionFlujosClientesNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComisionFlujosClientesNomina))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlProveedores = New System.Windows.Forms.Panel()
        Me.pnlpromotor4 = New System.Windows.Forms.Panel()
        Me.nudpromotor4 = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbopromotor4 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkpromotor4 = New System.Windows.Forms.CheckBox()
        Me.pnlpromotor3 = New System.Windows.Forms.Panel()
        Me.nudpromotor3 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbopromotor3 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkpromotor3 = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdbTotal = New System.Windows.Forms.RadioButton()
        Me.rdbSubtotal = New System.Windows.Forms.RadioButton()
        Me.pnlpromotor2 = New System.Windows.Forms.Panel()
        Me.nudpromotor2 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbopromotor2 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkpromotor2 = New System.Windows.Forms.CheckBox()
        Me.cbocliente = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.chkSumarIVA = New System.Windows.Forms.CheckBox()
        Me.pnlpromotor1 = New System.Windows.Forms.Panel()
        Me.nudpromotor1 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbopromotor1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkpromotor1 = New System.Windows.Forms.CheckBox()
        Me.nudcomision = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmdnuevo = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlProveedores.SuspendLayout()
        Me.pnlpromotor4.SuspendLayout()
        CType(Me.nudpromotor4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlpromotor3.SuspendLayout()
        CType(Me.nudpromotor3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlpromotor2.SuspendLayout()
        CType(Me.nudpromotor2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlpromotor1.SuspendLayout()
        CType(Me.nudpromotor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudcomision, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Location = New System.Drawing.Point(760, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 380)
        Me.Panel1.TabIndex = 68
        '
        'pnlProveedores
        '
        Me.pnlProveedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlProveedores.Controls.Add(Me.pnlpromotor4)
        Me.pnlProveedores.Controls.Add(Me.chkpromotor4)
        Me.pnlProveedores.Controls.Add(Me.pnlpromotor3)
        Me.pnlProveedores.Controls.Add(Me.chkpromotor3)
        Me.pnlProveedores.Controls.Add(Me.Panel2)
        Me.pnlProveedores.Controls.Add(Me.pnlpromotor2)
        Me.pnlProveedores.Controls.Add(Me.chkpromotor2)
        Me.pnlProveedores.Controls.Add(Me.cbocliente)
        Me.pnlProveedores.Controls.Add(Me.Label21)
        Me.pnlProveedores.Controls.Add(Me.chkSumarIVA)
        Me.pnlProveedores.Controls.Add(Me.pnlpromotor1)
        Me.pnlProveedores.Controls.Add(Me.chkpromotor1)
        Me.pnlProveedores.Controls.Add(Me.nudcomision)
        Me.pnlProveedores.Controls.Add(Me.Label5)
        Me.pnlProveedores.Enabled = False
        Me.pnlProveedores.Location = New System.Drawing.Point(7, 8)
        Me.pnlProveedores.Name = "pnlProveedores"
        Me.pnlProveedores.Size = New System.Drawing.Size(747, 431)
        Me.pnlProveedores.TabIndex = 67
        '
        'pnlpromotor4
        '
        Me.pnlpromotor4.Controls.Add(Me.nudpromotor4)
        Me.pnlpromotor4.Controls.Add(Me.Label7)
        Me.pnlpromotor4.Controls.Add(Me.cbopromotor4)
        Me.pnlpromotor4.Controls.Add(Me.Label8)
        Me.pnlpromotor4.Location = New System.Drawing.Point(12, 370)
        Me.pnlpromotor4.Name = "pnlpromotor4"
        Me.pnlpromotor4.Size = New System.Drawing.Size(728, 41)
        Me.pnlpromotor4.TabIndex = 72
        '
        'nudpromotor4
        '
        Me.nudpromotor4.DecimalPlaces = 2
        Me.nudpromotor4.Location = New System.Drawing.Point(623, 5)
        Me.nudpromotor4.Name = "nudpromotor4"
        Me.nudpromotor4.Size = New System.Drawing.Size(64, 27)
        Me.nudpromotor4.TabIndex = 49
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(538, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 19)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "% Promotor:"
        '
        'cbopromotor4
        '
        Me.cbopromotor4.FormattingEnabled = True
        Me.cbopromotor4.Location = New System.Drawing.Point(76, 3)
        Me.cbopromotor4.Name = "cbopromotor4"
        Me.cbopromotor4.Size = New System.Drawing.Size(456, 27)
        Me.cbopromotor4.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 19)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Promotor:"
        '
        'chkpromotor4
        '
        Me.chkpromotor4.AutoSize = True
        Me.chkpromotor4.Location = New System.Drawing.Point(12, 341)
        Me.chkpromotor4.Name = "chkpromotor4"
        Me.chkpromotor4.Size = New System.Drawing.Size(99, 23)
        Me.chkpromotor4.TabIndex = 71
        Me.chkpromotor4.Text = "Promotor 4"
        Me.chkpromotor4.UseVisualStyleBackColor = True
        '
        'pnlpromotor3
        '
        Me.pnlpromotor3.Controls.Add(Me.nudpromotor3)
        Me.pnlpromotor3.Controls.Add(Me.Label3)
        Me.pnlpromotor3.Controls.Add(Me.cbopromotor3)
        Me.pnlpromotor3.Controls.Add(Me.Label4)
        Me.pnlpromotor3.Location = New System.Drawing.Point(12, 294)
        Me.pnlpromotor3.Name = "pnlpromotor3"
        Me.pnlpromotor3.Size = New System.Drawing.Size(728, 41)
        Me.pnlpromotor3.TabIndex = 70
        '
        'nudpromotor3
        '
        Me.nudpromotor3.DecimalPlaces = 2
        Me.nudpromotor3.Location = New System.Drawing.Point(623, 5)
        Me.nudpromotor3.Name = "nudpromotor3"
        Me.nudpromotor3.Size = New System.Drawing.Size(64, 27)
        Me.nudpromotor3.TabIndex = 49
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(538, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 19)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "% Promotor:"
        '
        'cbopromotor3
        '
        Me.cbopromotor3.FormattingEnabled = True
        Me.cbopromotor3.Location = New System.Drawing.Point(76, 3)
        Me.cbopromotor3.Name = "cbopromotor3"
        Me.cbopromotor3.Size = New System.Drawing.Size(456, 27)
        Me.cbopromotor3.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Promotor:"
        '
        'chkpromotor3
        '
        Me.chkpromotor3.AutoSize = True
        Me.chkpromotor3.Location = New System.Drawing.Point(12, 265)
        Me.chkpromotor3.Name = "chkpromotor3"
        Me.chkpromotor3.Size = New System.Drawing.Size(99, 23)
        Me.chkpromotor3.TabIndex = 69
        Me.chkpromotor3.Text = "Promotor 3"
        Me.chkpromotor3.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdbTotal)
        Me.Panel2.Controls.Add(Me.rdbSubtotal)
        Me.Panel2.Location = New System.Drawing.Point(261, 64)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(395, 42)
        Me.Panel2.TabIndex = 68
        '
        'rdbTotal
        '
        Me.rdbTotal.AutoSize = True
        Me.rdbTotal.Location = New System.Drawing.Point(219, 8)
        Me.rdbTotal.Name = "rdbTotal"
        Me.rdbTotal.Size = New System.Drawing.Size(161, 23)
        Me.rdbTotal.TabIndex = 1
        Me.rdbTotal.Text = "Comisión sobre total"
        Me.rdbTotal.UseVisualStyleBackColor = True
        '
        'rdbSubtotal
        '
        Me.rdbSubtotal.AutoSize = True
        Me.rdbSubtotal.Checked = True
        Me.rdbSubtotal.Location = New System.Drawing.Point(7, 8)
        Me.rdbSubtotal.Name = "rdbSubtotal"
        Me.rdbSubtotal.Size = New System.Drawing.Size(184, 23)
        Me.rdbSubtotal.TabIndex = 0
        Me.rdbSubtotal.TabStop = True
        Me.rdbSubtotal.Text = "Comisión sobre subtotal"
        Me.rdbSubtotal.UseVisualStyleBackColor = True
        '
        'pnlpromotor2
        '
        Me.pnlpromotor2.Controls.Add(Me.nudpromotor2)
        Me.pnlpromotor2.Controls.Add(Me.Label2)
        Me.pnlpromotor2.Controls.Add(Me.cbopromotor2)
        Me.pnlpromotor2.Controls.Add(Me.Label12)
        Me.pnlpromotor2.Location = New System.Drawing.Point(12, 216)
        Me.pnlpromotor2.Name = "pnlpromotor2"
        Me.pnlpromotor2.Size = New System.Drawing.Size(728, 41)
        Me.pnlpromotor2.TabIndex = 67
        '
        'nudpromotor2
        '
        Me.nudpromotor2.DecimalPlaces = 2
        Me.nudpromotor2.Location = New System.Drawing.Point(623, 5)
        Me.nudpromotor2.Name = "nudpromotor2"
        Me.nudpromotor2.Size = New System.Drawing.Size(64, 27)
        Me.nudpromotor2.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(538, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 19)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "% Promotor:"
        '
        'cbopromotor2
        '
        Me.cbopromotor2.FormattingEnabled = True
        Me.cbopromotor2.Location = New System.Drawing.Point(76, 3)
        Me.cbopromotor2.Name = "cbopromotor2"
        Me.cbopromotor2.Size = New System.Drawing.Size(456, 27)
        Me.cbopromotor2.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 19)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Promotor:"
        '
        'chkpromotor2
        '
        Me.chkpromotor2.AutoSize = True
        Me.chkpromotor2.Location = New System.Drawing.Point(12, 187)
        Me.chkpromotor2.Name = "chkpromotor2"
        Me.chkpromotor2.Size = New System.Drawing.Size(99, 23)
        Me.chkpromotor2.TabIndex = 66
        Me.chkpromotor2.Text = "Promotor 2"
        Me.chkpromotor2.UseVisualStyleBackColor = True
        '
        'cbocliente
        '
        Me.cbocliente.FormattingEnabled = True
        Me.cbocliente.Location = New System.Drawing.Point(12, 31)
        Me.cbocliente.Name = "cbocliente"
        Me.cbocliente.Size = New System.Drawing.Size(542, 27)
        Me.cbocliente.TabIndex = 63
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(17, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 19)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Cliente:"
        '
        'chkSumarIVA
        '
        Me.chkSumarIVA.AutoSize = True
        Me.chkSumarIVA.Location = New System.Drawing.Point(174, 74)
        Me.chkSumarIVA.Name = "chkSumarIVA"
        Me.chkSumarIVA.Size = New System.Drawing.Size(81, 23)
        Me.chkSumarIVA.TabIndex = 46
        Me.chkSumarIVA.Text = "Mas IVA"
        Me.chkSumarIVA.UseVisualStyleBackColor = True
        '
        'pnlpromotor1
        '
        Me.pnlpromotor1.Controls.Add(Me.nudpromotor1)
        Me.pnlpromotor1.Controls.Add(Me.Label6)
        Me.pnlpromotor1.Controls.Add(Me.cbopromotor1)
        Me.pnlpromotor1.Controls.Add(Me.Label1)
        Me.pnlpromotor1.Location = New System.Drawing.Point(12, 133)
        Me.pnlpromotor1.Name = "pnlpromotor1"
        Me.pnlpromotor1.Size = New System.Drawing.Size(728, 44)
        Me.pnlpromotor1.TabIndex = 43
        '
        'nudpromotor1
        '
        Me.nudpromotor1.DecimalPlaces = 2
        Me.nudpromotor1.Location = New System.Drawing.Point(623, 5)
        Me.nudpromotor1.Name = "nudpromotor1"
        Me.nudpromotor1.Size = New System.Drawing.Size(64, 27)
        Me.nudpromotor1.TabIndex = 49
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(538, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 19)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "% Promotor:"
        '
        'cbopromotor1
        '
        Me.cbopromotor1.FormattingEnabled = True
        Me.cbopromotor1.Location = New System.Drawing.Point(76, 5)
        Me.cbopromotor1.Name = "cbopromotor1"
        Me.cbopromotor1.Size = New System.Drawing.Size(456, 27)
        Me.cbopromotor1.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 19)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Promotor:"
        '
        'chkpromotor1
        '
        Me.chkpromotor1.AutoSize = True
        Me.chkpromotor1.Location = New System.Drawing.Point(12, 109)
        Me.chkpromotor1.Name = "chkpromotor1"
        Me.chkpromotor1.Size = New System.Drawing.Size(99, 23)
        Me.chkpromotor1.TabIndex = 42
        Me.chkpromotor1.Text = "Promotor 1"
        Me.chkpromotor1.UseVisualStyleBackColor = True
        '
        'nudcomision
        '
        Me.nudcomision.DecimalPlaces = 1
        Me.nudcomision.Location = New System.Drawing.Point(90, 70)
        Me.nudcomision.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.nudcomision.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudcomision.Name = "nudcomision"
        Me.nudcomision.Size = New System.Drawing.Size(64, 27)
        Me.nudcomision.TabIndex = 16
        Me.nudcomision.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "% cobrado:"
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
        'frmComisionFlujosClientesNomina
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(872, 447)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlProveedores)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmComisionFlujosClientesNomina"
        Me.Text = "Comisión Clientes por flujo nominas"
        Me.Panel1.ResumeLayout(False)
        Me.pnlProveedores.ResumeLayout(False)
        Me.pnlProveedores.PerformLayout()
        Me.pnlpromotor4.ResumeLayout(False)
        Me.pnlpromotor4.PerformLayout()
        CType(Me.nudpromotor4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlpromotor3.ResumeLayout(False)
        Me.pnlpromotor3.PerformLayout()
        CType(Me.nudpromotor3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlpromotor2.ResumeLayout(False)
        Me.pnlpromotor2.PerformLayout()
        CType(Me.nudpromotor2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlpromotor1.ResumeLayout(False)
        Me.pnlpromotor1.PerformLayout()
        CType(Me.nudpromotor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudcomision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdcancelar As Button
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents cmdnuevo As Button
    Friend WithEvents cmdsalir As Button
    Friend WithEvents cmdguardar As Button
    Friend WithEvents pnlProveedores As Panel
    Friend WithEvents pnlpromotor4 As Panel
    Friend WithEvents nudpromotor4 As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents cbopromotor4 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chkpromotor4 As CheckBox
    Friend WithEvents pnlpromotor3 As Panel
    Friend WithEvents nudpromotor3 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents cbopromotor3 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkpromotor3 As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdbTotal As RadioButton
    Friend WithEvents rdbSubtotal As RadioButton
    Friend WithEvents pnlpromotor2 As Panel
    Friend WithEvents nudpromotor2 As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents cbopromotor2 As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkpromotor2 As CheckBox
    Friend WithEvents cbocliente As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents chkSumarIVA As CheckBox
    Friend WithEvents pnlpromotor1 As Panel
    Friend WithEvents nudpromotor1 As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents cbopromotor1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkpromotor1 As CheckBox
    Friend WithEvents nudcomision As NumericUpDown
    Friend WithEvents Label5 As Label
End Class
